
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

#pragma warning disable 649, 1572, 1573

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace OpenGL
{
	public partial class Gl
	{
		/// <summary>
		/// Value of GL_TEXTURE_USAGE_ANGLE symbol.
		/// </summary>
		[RequiredByFeature("GL_ANGLE_texture_usage", Api = "gles2")]
		public const int TEXTURE_USAGE_ANGLE = 0x93A2;

		/// <summary>
		/// Value of GL_FRAMEBUFFER_ATTACHMENT_ANGLE symbol.
		/// </summary>
		[RequiredByFeature("GL_ANGLE_texture_usage", Api = "gles2")]
		public const int FRAMEBUFFER_ATTACHMENT_ANGLE = 0x93A3;

	}

}
