﻿
// Copyright (C) 2015-2016 Luca Piccioni
// 
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.
// 
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public
// License along with this library; if not, write to the Free Software
// Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301
// USA

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;

namespace OpenGL.Objects
{
	/// <summary>
	/// Shaders library.
	/// </summary>
	[XmlRoot("ShadersLibrary")]
	public sealed class ShadersLibrary
	{
		#region Constructors

		/// <summary>
		/// Static constructor.
		/// </summary>
		static ShadersLibrary()
		{
			// Load OpenGL.Objects shaders library
			Merge("OpenGL.Objects.Shaders._ShadersLibrary.xml");
			Merge("OpenGL.Objects.Shaders.Light._ShadersLibrary.xml");
			Merge("OpenGL.Objects.Shaders.Standard._ShadersLibrary.xml");
			Merge("OpenGL.Objects.Shaders.Font._ShadersLibrary.xml");
			Merge("OpenGL.Objects.Shaders.Skybox._ShadersLibrary.xml");
		}

		#endregion

		#region Includes

		/// <summary>
		/// Shader object.
		/// </summary>
		[XmlType("Include")]
		public class Include
		{
			/// <summary>
			/// The path of the shader object source.
			/// </summary>
			[XmlAttribute("Id")]
			public string Id;

			/// <summary>
			/// Preprocessor symbols affecting the shader object compilation.
			/// </summary>
			[XmlElement("Path")]
			public string Path;
		}

		/// <summary>
		/// List of paths specifying shader include sources.
		/// </summary>
		[XmlArray("Includes")]
		[XmlArrayItem("Include")]
		public readonly List<Include> Includes = new List<Include>();

		#endregion

		#region Objects

		/// <summary>
		/// Shader object.
		/// </summary>
		[XmlType("Object")]
		public class Object
		{
			/// <summary>
			/// The path of the shader object source.
			/// </summary>
			[XmlAttribute("Path")]
			public string Path;

			/// <summary>
			/// Shader object stage.
			/// </summary>
			[XmlAttribute("Stage")]
			public ShaderStage Stage = ShaderStage.Vertex;

			/// <summary>
			/// Preprocessor symbols affecting the shader object compilation.
			/// </summary>
			[XmlArray("Symbols")]
			[XmlArrayItem("Symbol")]
			public readonly List<string> Symbols = new List<string>();

			/// <summary>
			/// Create a shader object from this Object.
			/// </summary>
			/// <returns></returns>
			public ShaderObject Create()
			{
				ShaderObject shaderObject = new ShaderObject(Stage);

				// Load source
				shaderObject.LoadSource(Path);

				return (shaderObject);
			}

			/// <summary>
			/// 
			/// </summary>
			/// <param name="cctx"></param>
			/// <returns></returns>
			internal void GetHashInfo(StringBuilder hashMessage, ShaderCompilerContext cctx)
			{
				// Shaders can be compiled at different stages
				hashMessage.Append(Stage);
				// All symbols known for this shader are included
				foreach (string define in cctx.Defines) {
					if (Symbols.Contains(define) == false)
						continue;
					hashMessage.Append(define);
				}
			}
		}

		/// <summary>
		/// List of <see cref="Object"/> instances describing the available shader objects in library.
		/// </summary>
		[XmlArray("Objects")]
		[XmlArrayItem("Object")]
		public readonly List<Object> Objects = new List<Object>();

		/// <summary>
		/// Get the definition of a object.
		/// </summary>
		/// <param name="objectId">
		/// A <see cref="String"/> that specifies the object identifier.
		/// </param>
		/// <returns>
		/// It returns a <see cref="Object"/> describing the object identified with <paramref name="objectId"/>.
		/// </returns>
		public Object GetObject(string objectId)
		{
			if (objectId == null)
				throw new ArgumentNullException("programId");

			return (Objects.Find(delegate(Object item) { return (item.Path == objectId); }));
		}

		#endregion

		#region Programs

		/// <summary>
		/// Shader program tag.
		/// </summary>
		public class ProgramTag
		{
			/// <summary>
			/// Create a ProgramTag from a <see cref="Program"/>.
			/// </summary>
			/// <param name="program">
			/// The <see cref="Program"/> that specifies how to build the shader.
			/// </param>
			internal ProgramTag(Program program)
			{
				if (program == null)
					throw new ArgumentNullException("program");

				Id = program.Id;
				CompilerContext = program.GetCompilerContext();
			}

			/// <summary>
			/// Create a ProgramTag from a <see cref="Program"/>.
			/// </summary>
			/// <param name="program">
			/// The <see cref="Program"/> that specifies how to build the shader.
			/// </param>
			internal ProgramTag(Program program, ShaderCompilerContext cctx) : this(program)
			{
				if (cctx == null)
					throw new ArgumentNullException("cctx");

				CompilerContext.Merge(cctx);
			}

			/// <summary>
			/// The program identifier.
			/// </summary>
			public readonly string Id;

			/// <summary>
			/// Shader compiler paramaters.
			/// </summary>
			public ShaderCompilerContext CompilerContext;
		}

		/// <summary>
		/// Program object.
		/// </summary>
		[XmlType("Program")]
		public class Program
		{
			/// <summary>
			/// The identifier of the shader program.
			/// </summary>
			[XmlAttribute("Id")]
			public string Id;

			/// <summary>
			/// Object linked to this shader program.
			/// </summary>
			[XmlElement("Object")]
			public readonly List<Object> Objects = new List<Object>();

			[XmlType("Attribute")]
			public class Attribute
			{
				/// <summary>
				/// Attribute name.
				/// </summary>
				[XmlAttribute("Name")]
				public string Name;

				/// <summary>
				/// Attribute semantic.
				/// </summary>
				[XmlAttribute("Semantic")]
				public string Semantic;

				/// <summary>
				/// Attribute location.
				/// </summary>
				[XmlAttribute("Location")]
				[DefaultValue(-1)]
				public int Location = -1;
			}

			/// <summary>
			/// 
			/// </summary>
			[XmlElement("Attribute")]
			public readonly List<Attribute> Attributes = new List<Attribute>();

			[XmlType("Uniform")]
			public class Uniform
			{
				/// <summary>
				/// Uniform name.
				/// </summary>
				[XmlAttribute("Name")]
				public string Name;

				/// <summary>
				/// Uniform semantic.
				/// </summary>
				[XmlAttribute("Semantic")]
				public string Semantic;
			}

			/// <summary>
			/// 
			/// </summary>
			[XmlElement("Uniform")]
			public readonly List<Uniform> Uniforms = new List<Uniform>();

			/// <summary>
			/// Create a program from this Program.
			/// </summary>
			/// <returns></returns>
			public ShaderProgram Create()
			{
				return (Create(GetCompilerContext()));
			}

			/// <summary>
			/// Create a program from this Program.
			/// </summary>
			/// <param name="cctx"></param>
			/// <returns></returns>
			public ShaderProgram Create(ShaderCompilerContext cctx)
			{
				if (String.IsNullOrEmpty(Id))
					throw new InvalidOperationException("invalid program identifier");
				if (cctx == null)
					throw new ArgumentNullException("cctx");

				ShaderProgram shaderProgram = new ShaderProgram(Id);

				// Attach required objects
				foreach (Object shaderProgramObject in Objects) {
					ShaderObject shaderObject = new ShaderObject(shaderProgramObject.Stage);

					// Load source
					shaderObject.LoadSource(shaderProgramObject.Path);
					// Attach object
					shaderProgram.AttachShader(shaderObject);
				}

				// Register attributes semantic
				foreach (Attribute attribute in Attributes) {
					shaderProgram.SetAttributeSemantic(attribute.Name, attribute.Semantic);
					if (attribute.Location >= 0)
						shaderProgram.SetAttributeLocation(attribute.Name, attribute.Location);
				}
					
				// Register uniforms semantic
				foreach (Uniform uniform in Uniforms)
					shaderProgram.SetUniformSemantic(uniform.Name, uniform.Semantic);

				shaderProgram.Create(cctx);

				return (shaderProgram);
			}

			internal ShaderCompilerContext GetCompilerContext()
			{
				ShaderCompilerContext shaderCompilerParams = new ShaderCompilerContext();

				foreach (Object shaderProgramObject in Objects) {
					// Take into account required preprocessor symbols
					foreach (string preprocessorSymbol in shaderProgramObject.Symbols)
						shaderCompilerParams.Defines.Add(preprocessorSymbol);
				}

				return (shaderCompilerParams);
			}

			/// <summary>
			/// 
			/// </summary>
			/// <param name="cctx"></param>
			/// <returns></returns>
			internal string GetHashInfo(ShaderCompilerContext cctx)
			{
				StringBuilder hashMessage = new StringBuilder();

				// Take into account the shader program name
				hashMessage.Append(Id);

				// Objects hash
				if (Objects != null) {
					foreach (Object programObject in Objects)
						hashMessage.Append(programObject);
				}

				// Compilation parameters (common to all shaders?)
				hashMessage.Append(cctx.ShaderVersion);

				if (cctx.Includes != null) {
					foreach (string includePath in cctx.Includes)
						hashMessage.Append(includePath);
				}

				hashMessage.Append(cctx.FeedbackVaryingsFormat);

				return (hashMessage.ToString());
			}
		}

		/// <summary>
		/// List of <see cref="Program"/> instances describing the available shader programs in library.
		/// </summary>
		[XmlArray("Programs")]
		[XmlArrayItem("Program")]
		public readonly List<Program> Programs = new List<Program>();

		/// <summary>
		/// Get the definition of a program.
		/// </summary>
		/// <param name="programId">
		/// A <see cref="String"/> that specifies the program identifier.
		/// </param>
		/// <returns>
		/// It returns a <see cref="Program"/> describing the program identified with <paramref name="programId"/>.
		/// </returns>
		public Program GetProgram(string programId)
		{
			if (programId == null)
				throw new ArgumentNullException("programId");

			return (Programs.Find(delegate(Program item) { return (item.Id == programId); }));
		}

		/// <summary>
		/// Create a <see cref="ProgramTag"/> used for creating (lazily) a <see cref="ShaderProgram"/>.
		/// </summary>
		/// <param name="programId">
		/// A <see cref="String"/> that specifies the program identifier.
		/// </param>
		/// <returns>
		/// It returns a <see cref="ProgramTag"/> for creating the program identified with <paramref name="programId"/>.
		/// </returns>
		public ProgramTag CreateProgramTag(string programId)
		{
			Program libraryProgram = GetProgram(programId);
			if (libraryProgram == null)
				throw new ArgumentException("no program with such identifier", "programId");

			return (new ProgramTag(libraryProgram));
		}

		/// <summary>
		/// Create a <see cref="ProgramTag"/> used for creating (lazily) a <see cref="ShaderProgram"/>.
		/// </summary>
		/// <param name="programId">
		/// A <see cref="String"/> that specifies the program identifier.
		/// </param>
		/// <param name="cctx">
		/// A <see cref="ShaderCompilerContext"/> that specifies *additional* parameters to be applied/merged to the default
		/// compiler parameters.
		/// </param>
		/// <returns>
		/// It returns a <see cref="ProgramTag"/> for creating the program identified with <paramref name="programId"/>.
		/// </returns>
		public ProgramTag CreateProgramTag(string programId, ShaderCompilerContext cctx)
		{
			Program libraryProgram = GetProgram(programId);
			if (libraryProgram == null)
				throw new ArgumentException("no program with such identifier", "programId");

			return (new ProgramTag(libraryProgram, cctx));
		}

		/// <summary>
		/// Create a <see cref="ProgramTag"/> used for creating (lazily) a <see cref="ShaderProgram"/>.
		/// </summary>
		/// <param name="programId">
		/// A <see cref="String"/> that specifies the program identifier.
		/// </param>
		/// <param name="cctx">
		/// A <see cref="ShaderCompilerContext"/> that specifies *additional* parameters to be applied/merged to the default
		/// compiler parameters.
		/// </param>
		/// <returns>
		/// It returns a <see cref="ProgramTag"/> for creating the program identified with <paramref name="programId"/>.
		/// </returns>
		public ProgramTag CreateProgramTag(string programId, params string[] defines)
		{
			Program libraryProgram = GetProgram(programId);
			if (libraryProgram == null)
				throw new ArgumentException("no program with such identifier", "programId");

			return (new ProgramTag(libraryProgram, new ShaderCompilerContext(defines)));
		}

		#endregion

		#region Serialization

		/// <summary>
		/// Load a ShadersLibrary from a Stream.
		/// </summary>
		/// <param name="libraryStream">
		/// A <see cref="Stream"/> that reads a <see cref="ShadersLibrary"/> information.
		/// </param>
		/// <returns>
		/// It returns a <see cref="ShadersLibrary"/> read from <paramref name="libraryStream"/>.
		/// </returns>
		private static ShadersLibrary Load(Stream libraryStream)
		{
			if (libraryStream == null)
				throw new ArgumentNullException("libraryStream");

			XmlSerializer xmlSerializer = new XmlSerializer(typeof(ShadersLibrary));

			return ((ShadersLibrary)xmlSerializer.Deserialize(libraryStream));
		}

		/// <summary>
		/// Load a ShadersLibrary from an embedded resource.
		/// </summary>
		/// <param name="resourcePath">
		/// A <see cref="String"/> that specify the embedded resource path.
		/// </param>
		/// <returns>
		/// It returns a <see cref="ShadersLibrary"/> read from <paramref name="resourcePath"/>.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// Exception thrown if <paramref name="resourcePath"/> is null.
		/// </exception>
		/// <exception cref="ArgumentException">
		/// Exception thrown if no embedded resource can be found.
		/// </exception>
		private static ShadersLibrary Load(string resourcePath)
		{
			if (resourcePath == null)
				throw new ArgumentNullException("resourcePath");

			Assembly[] resourceAssemblies = new Assembly[] {
				Assembly.GetExecutingAssembly(),
				Assembly.GetCallingAssembly(),
				Assembly.GetEntryAssembly()
			};
			Stream resourceStream = null;

			try {
				for (int i = 0; i < resourceAssemblies.Length && resourceStream == null; i++) {
					if (resourceAssemblies[i] == null)
						continue;
					resourceStream = resourceAssemblies[i].GetManifestResourceStream(resourcePath);
				}

				if (resourceStream == null)
					throw new ArgumentException("resource path not found", "resourcePath");

				return (Load(resourceStream));
			} finally {
				if (resourceStream != null)
					resourceStream.Dispose();
			}
		}

		#endregion

		#region Singleton

		/// <summary>
		/// Get the only instance of <see cref="ShadersLibrary"/>.
		/// </summary>
		public static ShadersLibrary Instance
		{
			get
			{
				return (_ShadersLibrary);
			}
		}

		/// <summary>
		/// Merge a ShaderLibrary loaded from an embedded resource with <see cref="Instance"/>.
		/// </summary>
		/// <param name="resourcePath">
		/// A <see cref="String"/> that specify the embedded resource path.
		/// </param>
		public static void Merge(string resourcePath)
		{
			ShadersLibrary embeddedShadersLibrary = Load(resourcePath);

			// Merge information
			_ShadersLibrary.Includes.AddRange(embeddedShadersLibrary.Includes);
			_ShadersLibrary.Objects.AddRange(embeddedShadersLibrary.Objects);
			_ShadersLibrary.Programs.AddRange(embeddedShadersLibrary.Programs);
		}

		/// <summary>
		/// The reference instance of <see cref="ShadersLibrary"/>.
		/// </summary>
		private static readonly ShadersLibrary _ShadersLibrary = new ShadersLibrary();

		#endregion
	}
}
