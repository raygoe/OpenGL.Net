
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
		/// Value of GL_VERTEX_ATTRIB_MAP1_APPLE symbol.
		/// </summary>
		[RequiredByFeature("GL_APPLE_vertex_program_evaluators")]
		public const int VERTEX_ATTRIB_MAP1_APPLE = 0x8A00;

		/// <summary>
		/// Value of GL_VERTEX_ATTRIB_MAP2_APPLE symbol.
		/// </summary>
		[RequiredByFeature("GL_APPLE_vertex_program_evaluators")]
		public const int VERTEX_ATTRIB_MAP2_APPLE = 0x8A01;

		/// <summary>
		/// Value of GL_VERTEX_ATTRIB_MAP1_SIZE_APPLE symbol.
		/// </summary>
		[RequiredByFeature("GL_APPLE_vertex_program_evaluators")]
		public const int VERTEX_ATTRIB_MAP1_SIZE_APPLE = 0x8A02;

		/// <summary>
		/// Value of GL_VERTEX_ATTRIB_MAP1_COEFF_APPLE symbol.
		/// </summary>
		[RequiredByFeature("GL_APPLE_vertex_program_evaluators")]
		public const int VERTEX_ATTRIB_MAP1_COEFF_APPLE = 0x8A03;

		/// <summary>
		/// Value of GL_VERTEX_ATTRIB_MAP1_ORDER_APPLE symbol.
		/// </summary>
		[RequiredByFeature("GL_APPLE_vertex_program_evaluators")]
		public const int VERTEX_ATTRIB_MAP1_ORDER_APPLE = 0x8A04;

		/// <summary>
		/// Value of GL_VERTEX_ATTRIB_MAP1_DOMAIN_APPLE symbol.
		/// </summary>
		[RequiredByFeature("GL_APPLE_vertex_program_evaluators")]
		public const int VERTEX_ATTRIB_MAP1_DOMAIN_APPLE = 0x8A05;

		/// <summary>
		/// Value of GL_VERTEX_ATTRIB_MAP2_SIZE_APPLE symbol.
		/// </summary>
		[RequiredByFeature("GL_APPLE_vertex_program_evaluators")]
		public const int VERTEX_ATTRIB_MAP2_SIZE_APPLE = 0x8A06;

		/// <summary>
		/// Value of GL_VERTEX_ATTRIB_MAP2_COEFF_APPLE symbol.
		/// </summary>
		[RequiredByFeature("GL_APPLE_vertex_program_evaluators")]
		public const int VERTEX_ATTRIB_MAP2_COEFF_APPLE = 0x8A07;

		/// <summary>
		/// Value of GL_VERTEX_ATTRIB_MAP2_ORDER_APPLE symbol.
		/// </summary>
		[RequiredByFeature("GL_APPLE_vertex_program_evaluators")]
		public const int VERTEX_ATTRIB_MAP2_ORDER_APPLE = 0x8A08;

		/// <summary>
		/// Value of GL_VERTEX_ATTRIB_MAP2_DOMAIN_APPLE symbol.
		/// </summary>
		[RequiredByFeature("GL_APPLE_vertex_program_evaluators")]
		public const int VERTEX_ATTRIB_MAP2_DOMAIN_APPLE = 0x8A09;

		/// <summary>
		/// Binding for glEnableVertexAttribAPPLE.
		/// </summary>
		/// <param name="index">
		/// A <see cref="T:UInt32"/>.
		/// </param>
		/// <param name="pname">
		/// A <see cref="T:Int32"/>.
		/// </param>
		[RequiredByFeature("GL_APPLE_vertex_program_evaluators")]
		public static void EnableVertexAttribAPPLE(UInt32 index, Int32 pname)
		{
			Debug.Assert(Delegates.pglEnableVertexAttribAPPLE != null, "pglEnableVertexAttribAPPLE not implemented");
			Delegates.pglEnableVertexAttribAPPLE(index, pname);
			LogFunction("glEnableVertexAttribAPPLE({0}, {1})", index, LogEnumName(pname));
			DebugCheckErrors(null);
		}

		/// <summary>
		/// Binding for glDisableVertexAttribAPPLE.
		/// </summary>
		/// <param name="index">
		/// A <see cref="T:UInt32"/>.
		/// </param>
		/// <param name="pname">
		/// A <see cref="T:Int32"/>.
		/// </param>
		[RequiredByFeature("GL_APPLE_vertex_program_evaluators")]
		public static void DisableVertexAttribAPPLE(UInt32 index, Int32 pname)
		{
			Debug.Assert(Delegates.pglDisableVertexAttribAPPLE != null, "pglDisableVertexAttribAPPLE not implemented");
			Delegates.pglDisableVertexAttribAPPLE(index, pname);
			LogFunction("glDisableVertexAttribAPPLE({0}, {1})", index, LogEnumName(pname));
			DebugCheckErrors(null);
		}

		/// <summary>
		/// Binding for glIsVertexAttribEnabledAPPLE.
		/// </summary>
		/// <param name="index">
		/// A <see cref="T:UInt32"/>.
		/// </param>
		/// <param name="pname">
		/// A <see cref="T:Int32"/>.
		/// </param>
		[RequiredByFeature("GL_APPLE_vertex_program_evaluators")]
		public static bool IsVertexAttribEnabledAPPLE(UInt32 index, Int32 pname)
		{
			bool retValue;

			Debug.Assert(Delegates.pglIsVertexAttribEnabledAPPLE != null, "pglIsVertexAttribEnabledAPPLE not implemented");
			retValue = Delegates.pglIsVertexAttribEnabledAPPLE(index, pname);
			LogFunction("glIsVertexAttribEnabledAPPLE({0}, {1}) = {2}", index, LogEnumName(pname), retValue);
			DebugCheckErrors(retValue);

			return (retValue);
		}

		/// <summary>
		/// Binding for glMapVertexAttrib1dAPPLE.
		/// </summary>
		/// <param name="index">
		/// A <see cref="T:UInt32"/>.
		/// </param>
		/// <param name="size">
		/// A <see cref="T:UInt32"/>.
		/// </param>
		/// <param name="u1">
		/// A <see cref="T:double"/>.
		/// </param>
		/// <param name="u2">
		/// A <see cref="T:double"/>.
		/// </param>
		/// <param name="stride">
		/// A <see cref="T:Int32"/>.
		/// </param>
		/// <param name="order">
		/// A <see cref="T:Int32"/>.
		/// </param>
		/// <param name="points">
		/// A <see cref="T:double[]"/>.
		/// </param>
		[RequiredByFeature("GL_APPLE_vertex_program_evaluators")]
		public static void MapVertexAttrib1APPLE(UInt32 index, UInt32 size, double u1, double u2, Int32 stride, Int32 order, double[] points)
		{
			unsafe {
				fixed (double* p_points = points)
				{
					Debug.Assert(Delegates.pglMapVertexAttrib1dAPPLE != null, "pglMapVertexAttrib1dAPPLE not implemented");
					Delegates.pglMapVertexAttrib1dAPPLE(index, size, u1, u2, stride, order, p_points);
					LogFunction("glMapVertexAttrib1dAPPLE({0}, {1}, {2}, {3}, {4}, {5}, {6})", index, size, u1, u2, stride, order, LogValue(points));
				}
			}
			DebugCheckErrors(null);
		}

		/// <summary>
		/// Binding for glMapVertexAttrib1fAPPLE.
		/// </summary>
		/// <param name="index">
		/// A <see cref="T:UInt32"/>.
		/// </param>
		/// <param name="size">
		/// A <see cref="T:UInt32"/>.
		/// </param>
		/// <param name="u1">
		/// A <see cref="T:float"/>.
		/// </param>
		/// <param name="u2">
		/// A <see cref="T:float"/>.
		/// </param>
		/// <param name="stride">
		/// A <see cref="T:Int32"/>.
		/// </param>
		/// <param name="order">
		/// A <see cref="T:Int32"/>.
		/// </param>
		/// <param name="points">
		/// A <see cref="T:float[]"/>.
		/// </param>
		[RequiredByFeature("GL_APPLE_vertex_program_evaluators")]
		public static void MapVertexAttrib1APPLE(UInt32 index, UInt32 size, float u1, float u2, Int32 stride, Int32 order, float[] points)
		{
			unsafe {
				fixed (float* p_points = points)
				{
					Debug.Assert(Delegates.pglMapVertexAttrib1fAPPLE != null, "pglMapVertexAttrib1fAPPLE not implemented");
					Delegates.pglMapVertexAttrib1fAPPLE(index, size, u1, u2, stride, order, p_points);
					LogFunction("glMapVertexAttrib1fAPPLE({0}, {1}, {2}, {3}, {4}, {5}, {6})", index, size, u1, u2, stride, order, LogValue(points));
				}
			}
			DebugCheckErrors(null);
		}

		/// <summary>
		/// Binding for glMapVertexAttrib2dAPPLE.
		/// </summary>
		/// <param name="index">
		/// A <see cref="T:UInt32"/>.
		/// </param>
		/// <param name="size">
		/// A <see cref="T:UInt32"/>.
		/// </param>
		/// <param name="u1">
		/// A <see cref="T:double"/>.
		/// </param>
		/// <param name="u2">
		/// A <see cref="T:double"/>.
		/// </param>
		/// <param name="ustride">
		/// A <see cref="T:Int32"/>.
		/// </param>
		/// <param name="uorder">
		/// A <see cref="T:Int32"/>.
		/// </param>
		/// <param name="v1">
		/// A <see cref="T:double"/>.
		/// </param>
		/// <param name="v2">
		/// A <see cref="T:double"/>.
		/// </param>
		/// <param name="vstride">
		/// A <see cref="T:Int32"/>.
		/// </param>
		/// <param name="vorder">
		/// A <see cref="T:Int32"/>.
		/// </param>
		/// <param name="points">
		/// A <see cref="T:double[]"/>.
		/// </param>
		[RequiredByFeature("GL_APPLE_vertex_program_evaluators")]
		public static void MapVertexAttrib2APPLE(UInt32 index, UInt32 size, double u1, double u2, Int32 ustride, Int32 uorder, double v1, double v2, Int32 vstride, Int32 vorder, double[] points)
		{
			unsafe {
				fixed (double* p_points = points)
				{
					Debug.Assert(Delegates.pglMapVertexAttrib2dAPPLE != null, "pglMapVertexAttrib2dAPPLE not implemented");
					Delegates.pglMapVertexAttrib2dAPPLE(index, size, u1, u2, ustride, uorder, v1, v2, vstride, vorder, p_points);
					LogFunction("glMapVertexAttrib2dAPPLE({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10})", index, size, u1, u2, ustride, uorder, v1, v2, vstride, vorder, LogValue(points));
				}
			}
			DebugCheckErrors(null);
		}

		/// <summary>
		/// Binding for glMapVertexAttrib2fAPPLE.
		/// </summary>
		/// <param name="index">
		/// A <see cref="T:UInt32"/>.
		/// </param>
		/// <param name="size">
		/// A <see cref="T:UInt32"/>.
		/// </param>
		/// <param name="u1">
		/// A <see cref="T:float"/>.
		/// </param>
		/// <param name="u2">
		/// A <see cref="T:float"/>.
		/// </param>
		/// <param name="ustride">
		/// A <see cref="T:Int32"/>.
		/// </param>
		/// <param name="uorder">
		/// A <see cref="T:Int32"/>.
		/// </param>
		/// <param name="v1">
		/// A <see cref="T:float"/>.
		/// </param>
		/// <param name="v2">
		/// A <see cref="T:float"/>.
		/// </param>
		/// <param name="vstride">
		/// A <see cref="T:Int32"/>.
		/// </param>
		/// <param name="vorder">
		/// A <see cref="T:Int32"/>.
		/// </param>
		/// <param name="points">
		/// A <see cref="T:float[]"/>.
		/// </param>
		[RequiredByFeature("GL_APPLE_vertex_program_evaluators")]
		public static void MapVertexAttrib2APPLE(UInt32 index, UInt32 size, float u1, float u2, Int32 ustride, Int32 uorder, float v1, float v2, Int32 vstride, Int32 vorder, float[] points)
		{
			unsafe {
				fixed (float* p_points = points)
				{
					Debug.Assert(Delegates.pglMapVertexAttrib2fAPPLE != null, "pglMapVertexAttrib2fAPPLE not implemented");
					Delegates.pglMapVertexAttrib2fAPPLE(index, size, u1, u2, ustride, uorder, v1, v2, vstride, vorder, p_points);
					LogFunction("glMapVertexAttrib2fAPPLE({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10})", index, size, u1, u2, ustride, uorder, v1, v2, vstride, vorder, LogValue(points));
				}
			}
			DebugCheckErrors(null);
		}

		internal unsafe static partial class UnsafeNativeMethods
		{
			[SuppressUnmanagedCodeSecurity()]
			[DllImport(Library, EntryPoint = "glEnableVertexAttribAPPLE", ExactSpelling = true)]
			internal extern static void glEnableVertexAttribAPPLE(UInt32 index, Int32 pname);

			[SuppressUnmanagedCodeSecurity()]
			[DllImport(Library, EntryPoint = "glDisableVertexAttribAPPLE", ExactSpelling = true)]
			internal extern static void glDisableVertexAttribAPPLE(UInt32 index, Int32 pname);

			[SuppressUnmanagedCodeSecurity()]
			[DllImport(Library, EntryPoint = "glIsVertexAttribEnabledAPPLE", ExactSpelling = true)]
			[return: MarshalAs(UnmanagedType.I1)]
			internal extern static bool glIsVertexAttribEnabledAPPLE(UInt32 index, Int32 pname);

			[SuppressUnmanagedCodeSecurity()]
			[DllImport(Library, EntryPoint = "glMapVertexAttrib1dAPPLE", ExactSpelling = true)]
			internal extern static unsafe void glMapVertexAttrib1dAPPLE(UInt32 index, UInt32 size, double u1, double u2, Int32 stride, Int32 order, double* points);

			[SuppressUnmanagedCodeSecurity()]
			[DllImport(Library, EntryPoint = "glMapVertexAttrib1fAPPLE", ExactSpelling = true)]
			internal extern static unsafe void glMapVertexAttrib1fAPPLE(UInt32 index, UInt32 size, float u1, float u2, Int32 stride, Int32 order, float* points);

			[SuppressUnmanagedCodeSecurity()]
			[DllImport(Library, EntryPoint = "glMapVertexAttrib2dAPPLE", ExactSpelling = true)]
			internal extern static unsafe void glMapVertexAttrib2dAPPLE(UInt32 index, UInt32 size, double u1, double u2, Int32 ustride, Int32 uorder, double v1, double v2, Int32 vstride, Int32 vorder, double* points);

			[SuppressUnmanagedCodeSecurity()]
			[DllImport(Library, EntryPoint = "glMapVertexAttrib2fAPPLE", ExactSpelling = true)]
			internal extern static unsafe void glMapVertexAttrib2fAPPLE(UInt32 index, UInt32 size, float u1, float u2, Int32 ustride, Int32 uorder, float v1, float v2, Int32 vstride, Int32 vorder, float* points);

		}

		internal unsafe static partial class Delegates
		{
			[SuppressUnmanagedCodeSecurity()]
			internal delegate void glEnableVertexAttribAPPLE(UInt32 index, Int32 pname);

			[ThreadStatic]
			internal static glEnableVertexAttribAPPLE pglEnableVertexAttribAPPLE;

			[SuppressUnmanagedCodeSecurity()]
			internal delegate void glDisableVertexAttribAPPLE(UInt32 index, Int32 pname);

			[ThreadStatic]
			internal static glDisableVertexAttribAPPLE pglDisableVertexAttribAPPLE;

			[SuppressUnmanagedCodeSecurity()]
			internal delegate bool glIsVertexAttribEnabledAPPLE(UInt32 index, Int32 pname);

			[ThreadStatic]
			internal static glIsVertexAttribEnabledAPPLE pglIsVertexAttribEnabledAPPLE;

			[SuppressUnmanagedCodeSecurity()]
			internal unsafe delegate void glMapVertexAttrib1dAPPLE(UInt32 index, UInt32 size, double u1, double u2, Int32 stride, Int32 order, double* points);

			[ThreadStatic]
			internal static glMapVertexAttrib1dAPPLE pglMapVertexAttrib1dAPPLE;

			[SuppressUnmanagedCodeSecurity()]
			internal unsafe delegate void glMapVertexAttrib1fAPPLE(UInt32 index, UInt32 size, float u1, float u2, Int32 stride, Int32 order, float* points);

			[ThreadStatic]
			internal static glMapVertexAttrib1fAPPLE pglMapVertexAttrib1fAPPLE;

			[SuppressUnmanagedCodeSecurity()]
			internal unsafe delegate void glMapVertexAttrib2dAPPLE(UInt32 index, UInt32 size, double u1, double u2, Int32 ustride, Int32 uorder, double v1, double v2, Int32 vstride, Int32 vorder, double* points);

			[ThreadStatic]
			internal static glMapVertexAttrib2dAPPLE pglMapVertexAttrib2dAPPLE;

			[SuppressUnmanagedCodeSecurity()]
			internal unsafe delegate void glMapVertexAttrib2fAPPLE(UInt32 index, UInt32 size, float u1, float u2, Int32 ustride, Int32 uorder, float v1, float v2, Int32 vstride, Int32 vorder, float* points);

			[ThreadStatic]
			internal static glMapVertexAttrib2fAPPLE pglMapVertexAttrib2fAPPLE;

		}
	}

}
