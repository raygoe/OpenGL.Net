﻿
// Copyright (C) 2016 Luca Piccioni
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace BindingsGen.GLSpecs
{
	/// <summary>
	/// Utility class for processing C header files to generate XML specification files.
	/// </summary>
	class Header : IRegistry
	{
		#region Constructors

		public Header(string @class)
		{
			if (@class == null)
				throw new ArgumentNullException("class");
			Class = @class;
		}

		#endregion

		#region Class

		public readonly string Class;

		#endregion

		#region Header Parsing

		/// <summary>
		/// Append definitions recognized in a header file.
		/// </summary>
		/// <param name="path">
		/// A <see cref="System.String"/> that specified the path of the header file.
		/// </param>
		public void AppendHeader(string path)
		{
			if (path == null)
				throw new ArgumentNullException("path");

			string headerText;

			// Read the whole header
			using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read)) {
				using (StreamReader sr = new StreamReader(fs)) {
					headerText = sr.ReadToEnd();
				}
			}

			// Remove comments
			string inlineComment = @"//(.*?)\r?\n";
			string blockComment = @"/\*(.*?)\*/";
			
			headerText = Regex.Replace(headerText, String.Format("{0}|{1}", inlineComment, blockComment), delegate (Match match) {
				if (match.Value.StartsWith("/*"))
					return (String.Empty);
				if (match.Value.StartsWith("//"))
					return (Environment.NewLine);
				return (match.Value);
			}, RegexOptions.Singleline);

			// Extract C preprocessor #define directives
			string defineDirective = @"#define (?<Symbol>[\w\d_]+) +(?<Value>.*)\r?\n";

			EnumerantBlock definesBlock = new EnumerantBlock();
			definesBlock.Group = "Defines";

			headerText = Regex.Replace(headerText, defineDirective, delegate (Match match) {
				// Collect symbol/value
				if (match.Value.StartsWith("#define ")) {
					Enumerant enumerant = new Enumerant();

					enumerant.Name = match.Groups["Symbol"].Value;
					enumerant.Value = match.Groups["Value"].Value;
					enumerant.ParentEnumerantBlock = definesBlock;

					definesBlock.Enums.Add(enumerant);

					// Collect enumerant
					_Enumerants.Add(enumerant);

					return (String.Empty);
				}
					
				return (match.Value);
			}, RegexOptions.Multiline);

			// Remove no more necessary C preprocessor
			string preprocessorDirective = @"#(if|ifndef|else|endif|define|include) ?.*\r?\n";

			headerText = Regex.Replace(headerText, preprocessorDirective, String.Empty);

			// Remove new lines
			headerText = Regex.Replace(headerText, @"\r?\n", String.Empty);
			// Remove structures typedefs
			string structTypedef = @"typedef struct ?\{(.*?)\}( +?)(.*?);";
			headerText = Regex.Replace(headerText, structTypedef, String.Empty);
			// Remove multiple spaces
			headerText = Regex.Replace(headerText, @" +", " ");

			// Extract extern "C" scope
			string externBlock = "extern \"C\" {";
			if (headerText.StartsWith(externBlock))
				headerText = headerText.Substring(externBlock.Length, headerText.Length - externBlock.Length - 1);

			// Split into statements
			string[] statements = Regex.Split(headerText, ";");

			foreach (string statement in statements) {
				Match match;

				// Parse enumeration block
				if ((match = Regex.Match(statement, @"typedef enum ?\{(?<Enums>.*)\}( +?)(?<Tag>[\w\d_]+)")).Success) {

					string name = match.Groups["Tag"].Value;

					if (Regex.IsMatch(name, "WF(C|D)boolean"))
						continue;

					#region Enumeration

					EnumerantBlock enumerantBlock = new EnumerantBlock();
					enumerantBlock.Group = "WFD_VERSION_1_0";

					EnumerantGroup enumerantGroup = new EnumerantGroup();
					enumerantGroup.Name = name;

					// Parse enumerations
					string[] enumValues = Regex.Split(match.Groups["Enums"].Value, ",");

					for (int i = 0; i < enumValues.Length; i++) {
						string enumValue = enumValues[i].Trim();

						if ((match = Regex.Match(enumValue, @"(?<Name>(\w|_)+) = (?<Value>.*)")).Success) {
							Enumerant enumerant = new Enumerant();

							enumerant.Name = match.Groups["Name"].Value;
							enumerant.Value = match.Groups["Value"].Value;
							enumerant.ParentEnumerantBlock = enumerantBlock;

							enumerantBlock.Enums.Add(enumerant);

							enumerantGroup.Enums.Add(enumerant);

							// Collect enumerant
							_Enumerants.Add(enumerant);
						}
					}

					_Groups.Add(enumerantGroup);

					#endregion

					continue;

				} else if ((match = Regex.Match(statement, @"WF(D|C)_API_CALL (?<Return>.*) WF(D|C)_APIENTRY (?<Name>.*)\((?<Args>.*)\) WF(D|C)_APIEXIT")).Success) {

					#region Command

					Command command = new Command();

					command.Prototype = new CommandPrototype();
					command.Prototype.Type = match.Groups["Return"].Value;
					command.Prototype.Name = match.Groups["Name"].Value;

					string[] args = Regex.Split(match.Groups["Args"].Value, ",");

					for (int i = 0; i < args.Length; i++) {
						string arg = args[i].Trim();

						// '*' denotes types, not names
						arg = arg.Replace(" **", "** ");
						arg = arg.Replace(" *", "* ");

						if ((match = Regex.Match(arg, @"(?<Type>(\w|_|\*)+) (?<Name>[\w\d_]+)$")).Success) {
							CommandParameter commandParameter = new CommandParameter();

							commandParameter.Name = match.Groups["Name"].Value;
							commandParameter.Type = match.Groups["Type"].Value;

							command.Parameters.Add(commandParameter);
						} else
							throw new InvalidOperationException(String.Format("unable to parse argument '{0}'", arg));
					}

					_Commands.Add(command);

					#endregion

				}
			}

			Feature wfdVersion1 = new Feature();
			FeatureCommand wfdVersion1Feature = new FeatureCommand();

			wfdVersion1.Name = String.Format("{0}_VERSION_1_0", Class.ToUpperInvariant());
			wfdVersion1.Api = Class.ToLowerInvariant();
			wfdVersion1.Number = "1.0";
			wfdVersion1.Requirements.Add(wfdVersion1Feature);

			wfdVersion1Feature.Enums.AddRange(_Enumerants.ConvertAll(delegate(Enumerant input) {
				return new FeatureCommand.Item(input.Name);
			}));

			wfdVersion1Feature.Commands.AddRange(_Commands.ConvertAll(delegate(Command input) {
				return new FeatureCommand.Item(input.Prototype.Name);
			}));

			_Features.Add(wfdVersion1);
		}

		/// <summary>
		/// Regular expression used for recognizing enumeration definition.
		/// </summary>
		private static Regex _RegexEnum = new Regex("^typedef enum");

		/// <summary>
		/// Regular expression used for recognizing enumeration definition.
		/// </summary>
		private static Regex _RegexStatementEnum = new Regex(@"^typedef enum \{ (?<Enum>[\w\d_]+) = (?<Value>[\w\d_]+(,)?)+\}(?<Tag>[\w\d_]+)");

		#endregion

		#region IRegistry Implementation

		public List<Command> Commands { get { return (_Commands); } }

		private readonly List<Command> _Commands = new List<Command>();

		public List<Enumerant> Enumerants { get { return (_Enumerants); } }

		private readonly List<Enumerant> _Enumerants = new List<Enumerant>();

		public List<Extension> Extensions { get { return (new List<Extension>()); } }

		public List<Feature> Features { get { return (_Features); } }

		private readonly List<Feature> _Features = new List<Feature>();

		public List<EnumerantGroup> Groups { get { return (_Groups); } }

		private readonly List<EnumerantGroup> _Groups = new List<EnumerantGroup>();

		public IEnumerable<IFeature> AllFeatures(RegistryContext ctx)
		{
			return Features;
		}

		public Command GetCommand(string name)
		{
			return (_Commands.Find(delegate(Command item) { return (item.Prototype.Name == name); }));
		}

		public Enumerant GetEnumerant(string name)
		{
			return (_Enumerants.Find(delegate(Enumerant item) { return (item.Name == name); }));
		}

		public Enumerant GetEnumerantNoCase(string name)
		{
			return (_Enumerants.Find(delegate(Enumerant item) { return (item.Name.ToLowerInvariant() == name.ToLowerInvariant()); }));
		}

		#endregion
	}
}
