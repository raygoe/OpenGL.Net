
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

// Disable "'token' is obsolete" warnings
#pragma warning disable 618

using System;

namespace OpenWF
{
	/// <summary>
	/// Strongly typed enumeration WFCErrorCode.
	/// </summary>
	public enum WFCErrorCode
	{
		/// <summary>
		/// Strongly typed for value WFC_ERROR_NONE.
		/// </summary>
		ErrorNone = Wfc.ERROR_NONE,

		/// <summary>
		/// Strongly typed for value WFC_ERROR_OUT_OF_MEMORY.
		/// </summary>
		ErrorOutOfMemory = Wfc.ERROR_OUT_OF_MEMORY,

		/// <summary>
		/// Strongly typed for value WFC_ERROR_ILLEGAL_ARGUMENT.
		/// </summary>
		ErrorIllegalArgument = Wfc.ERROR_ILLEGAL_ARGUMENT,

		/// <summary>
		/// Strongly typed for value WFC_ERROR_UNSUPPORTED.
		/// </summary>
		ErrorUnsupported = Wfc.ERROR_UNSUPPORTED,

		/// <summary>
		/// Strongly typed for value WFC_ERROR_BAD_ATTRIBUTE.
		/// </summary>
		ErrorBadAttribute = Wfc.ERROR_BAD_ATTRIBUTE,

		/// <summary>
		/// Strongly typed for value WFC_ERROR_IN_USE.
		/// </summary>
		ErrorInUse = Wfc.ERROR_IN_USE,

		/// <summary>
		/// Strongly typed for value WFC_ERROR_BUSY.
		/// </summary>
		ErrorBusy = Wfc.ERROR_BUSY,

		/// <summary>
		/// Strongly typed for value WFC_ERROR_BAD_DEVICE.
		/// </summary>
		ErrorBadDevice = Wfc.ERROR_BAD_DEVICE,

		/// <summary>
		/// Strongly typed for value WFC_ERROR_BAD_HANDLE.
		/// </summary>
		ErrorBadHandle = Wfc.ERROR_BAD_HANDLE,

		/// <summary>
		/// Strongly typed for value WFC_ERROR_INCONSISTENCY.
		/// </summary>
		ErrorInconsistency = Wfc.ERROR_INCONSISTENCY,

		/// <summary>
		/// Strongly typed for value WFC_ERROR_FORCE_32BIT.
		/// </summary>
		ErrorForce32bit = Wfc.ERROR_FORCE_32BIT,

	}

	/// <summary>
	/// Strongly typed enumeration WFCDeviceFilter.
	/// </summary>
	public enum WFCDeviceFilter
	{
		/// <summary>
		/// Strongly typed for value WFC_DEVICE_FILTER_SCREEN_NUMBER.
		/// </summary>
		DeviceFilterScreenNumber = Wfc.DEVICE_FILTER_SCREEN_NUMBER,

		/// <summary>
		/// Strongly typed for value WFC_DEVICE_FILTER_FORCE_32BIT.
		/// </summary>
		DeviceFilterForce32bit = Wfc.DEVICE_FILTER_FORCE_32BIT,

	}

	/// <summary>
	/// Strongly typed enumeration WFCDeviceAttrib.
	/// </summary>
	public enum WFCDeviceAttrib
	{
		/// <summary>
		/// Strongly typed for value WFC_DEVICE_CLASS.
		/// </summary>
		DeviceClass = Wfc.DEVICE_CLASS,

		/// <summary>
		/// Strongly typed for value WFC_DEVICE_ID.
		/// </summary>
		DeviceId = Wfc.DEVICE_ID,

		/// <summary>
		/// Strongly typed for value WFC_DEVICE_FORCE_32BIT.
		/// </summary>
		DeviceForce32bit = Wfc.DEVICE_FORCE_32BIT,

	}

	/// <summary>
	/// Strongly typed enumeration WFCDeviceClass.
	/// </summary>
	public enum WFCDeviceClass
	{
		/// <summary>
		/// Strongly typed for value WFC_DEVICE_CLASS_FULLY_CAPABLE.
		/// </summary>
		DeviceClassFullyCapable = Wfc.DEVICE_CLASS_FULLY_CAPABLE,

		/// <summary>
		/// Strongly typed for value WFC_DEVICE_CLASS_OFF_SCREEN_ONLY.
		/// </summary>
		DeviceClassOffScreenOnly = Wfc.DEVICE_CLASS_OFF_SCREEN_ONLY,

		/// <summary>
		/// Strongly typed for value WFC_DEVICE_CLASS_FORCE_32BIT.
		/// </summary>
		DeviceClassForce32bit = Wfc.DEVICE_CLASS_FORCE_32BIT,

	}

	/// <summary>
	/// Strongly typed enumeration WFCContextAttrib.
	/// </summary>
	public enum WFCContextAttrib
	{
		/// <summary>
		/// Strongly typed for value WFC_CONTEXT_TYPE.
		/// </summary>
		ContextType = Wfc.CONTEXT_TYPE,

		/// <summary>
		/// Strongly typed for value WFC_CONTEXT_TARGET_HEIGHT.
		/// </summary>
		ContextTargetHeight = Wfc.CONTEXT_TARGET_HEIGHT,

		/// <summary>
		/// Strongly typed for value WFC_CONTEXT_TARGET_WIDTH.
		/// </summary>
		ContextTargetWidth = Wfc.CONTEXT_TARGET_WIDTH,

		/// <summary>
		/// Strongly typed for value WFC_CONTEXT_LOWEST_ELEMENT.
		/// </summary>
		ContextLowestElement = Wfc.CONTEXT_LOWEST_ELEMENT,

		/// <summary>
		/// Strongly typed for value WFC_CONTEXT_ROTATION.
		/// </summary>
		ContextRotation = Wfc.CONTEXT_ROTATION,

		/// <summary>
		/// Strongly typed for value WFC_CONTEXT_BG_COLOR.
		/// </summary>
		ContextBgColor = Wfc.CONTEXT_BG_COLOR,

		/// <summary>
		/// Strongly typed for value WFC_CONTEXT_FORCE_32BIT.
		/// </summary>
		ContextForce32bit = Wfc.CONTEXT_FORCE_32BIT,

	}

	/// <summary>
	/// Strongly typed enumeration WFCContextType.
	/// </summary>
	public enum WFCContextType
	{
		/// <summary>
		/// Strongly typed for value WFC_CONTEXT_TYPE_ON_SCREEN.
		/// </summary>
		ContextTypeOnScreen = Wfc.CONTEXT_TYPE_ON_SCREEN,

		/// <summary>
		/// Strongly typed for value WFC_CONTEXT_TYPE_OFF_SCREEN.
		/// </summary>
		ContextTypeOffScreen = Wfc.CONTEXT_TYPE_OFF_SCREEN,

		/// <summary>
		/// Strongly typed for value WFC_CONTEXT_TYPE_FORCE_32BIT.
		/// </summary>
		ContextTypeForce32bit = Wfc.CONTEXT_TYPE_FORCE_32BIT,

	}

	/// <summary>
	/// Strongly typed enumeration WFCRotation.
	/// </summary>
	public enum WFCRotation
	{
		/// <summary>
		/// Strongly typed for value WFC_ROTATION_0.
		/// </summary>
		Rotation0 = Wfc.ROTATION_0,

		/// <summary>
		/// Strongly typed for value WFC_ROTATION_90.
		/// </summary>
		Rotation90 = Wfc.ROTATION_90,

		/// <summary>
		/// Strongly typed for value WFC_ROTATION_180.
		/// </summary>
		Rotation180 = Wfc.ROTATION_180,

		/// <summary>
		/// Strongly typed for value WFC_ROTATION_270.
		/// </summary>
		Rotation270 = Wfc.ROTATION_270,

		/// <summary>
		/// Strongly typed for value WFC_ROTATION_FORCE_32BIT.
		/// </summary>
		RotationForce32bit = Wfc.ROTATION_FORCE_32BIT,

	}

	/// <summary>
	/// Strongly typed enumeration WFCElementAttrib.
	/// </summary>
	public enum WFCElementAttrib
	{
		/// <summary>
		/// Strongly typed for value WFC_ELEMENT_DESTINATION_RECTANGLE.
		/// </summary>
		ElementDestinationRectangle = Wfc.ELEMENT_DESTINATION_RECTANGLE,

		/// <summary>
		/// Strongly typed for value WFC_ELEMENT_SOURCE.
		/// </summary>
		ElementSource = Wfc.ELEMENT_SOURCE,

		/// <summary>
		/// Strongly typed for value WFC_ELEMENT_SOURCE_RECTANGLE.
		/// </summary>
		ElementSourceRectangle = Wfc.ELEMENT_SOURCE_RECTANGLE,

		/// <summary>
		/// Strongly typed for value WFC_ELEMENT_SOURCE_FLIP.
		/// </summary>
		ElementSourceFlip = Wfc.ELEMENT_SOURCE_FLIP,

		/// <summary>
		/// Strongly typed for value WFC_ELEMENT_SOURCE_ROTATION.
		/// </summary>
		ElementSourceRotation = Wfc.ELEMENT_SOURCE_ROTATION,

		/// <summary>
		/// Strongly typed for value WFC_ELEMENT_SOURCE_SCALE_FILTER.
		/// </summary>
		ElementSourceScaleFilter = Wfc.ELEMENT_SOURCE_SCALE_FILTER,

		/// <summary>
		/// Strongly typed for value WFC_ELEMENT_TRANSPARENCY_TYPES.
		/// </summary>
		ElementTransparencyTypes = Wfc.ELEMENT_TRANSPARENCY_TYPES,

		/// <summary>
		/// Strongly typed for value WFC_ELEMENT_GLOBAL_ALPHA.
		/// </summary>
		ElementGlobalAlpha = Wfc.ELEMENT_GLOBAL_ALPHA,

		/// <summary>
		/// Strongly typed for value WFC_ELEMENT_MASK.
		/// </summary>
		ElementMask = Wfc.ELEMENT_MASK,

		/// <summary>
		/// Strongly typed for value WFC_ELEMENT_FORCE_32BIT.
		/// </summary>
		ElementForce32bit = Wfc.ELEMENT_FORCE_32BIT,

	}

	/// <summary>
	/// Strongly typed enumeration WFCScaleFilter.
	/// </summary>
	public enum WFCScaleFilter
	{
		/// <summary>
		/// Strongly typed for value WFC_SCALE_FILTER_NONE.
		/// </summary>
		ScaleFilterNone = Wfc.SCALE_FILTER_NONE,

		/// <summary>
		/// Strongly typed for value WFC_SCALE_FILTER_FASTER.
		/// </summary>
		ScaleFilterFaster = Wfc.SCALE_FILTER_FASTER,

		/// <summary>
		/// Strongly typed for value WFC_SCALE_FILTER_BETTER.
		/// </summary>
		ScaleFilterBetter = Wfc.SCALE_FILTER_BETTER,

		/// <summary>
		/// Strongly typed for value WFC_SCALE_FILTER_FORCE_32BIT.
		/// </summary>
		ScaleFilterForce32bit = Wfc.SCALE_FILTER_FORCE_32BIT,

	}

	/// <summary>
	/// Strongly typed enumeration WFCTransparencyType.
	/// </summary>
	public enum WFCTransparencyType
	{
		/// <summary>
		/// Strongly typed for value WFC_TRANSPARENCY_NONE.
		/// </summary>
		TransparencyNone = Wfc.TRANSPARENCY_NONE,

		/// <summary>
		/// Strongly typed for value WFC_TRANSPARENCY_ELEMENT_GLOBAL_ALPHA.
		/// </summary>
		TransparencyElementGlobalAlpha = Wfc.TRANSPARENCY_ELEMENT_GLOBAL_ALPHA,

		/// <summary>
		/// Strongly typed for value WFC_TRANSPARENCY_SOURCE.
		/// </summary>
		TransparencySource = Wfc.TRANSPARENCY_SOURCE,

		/// <summary>
		/// Strongly typed for value WFC_TRANSPARENCY_MASK.
		/// </summary>
		TransparencyMask = Wfc.TRANSPARENCY_MASK,

		/// <summary>
		/// Strongly typed for value WFC_TRANSPARENCY_FORCE_32BIT.
		/// </summary>
		TransparencyForce32bit = Wfc.TRANSPARENCY_FORCE_32BIT,

	}

	/// <summary>
	/// Strongly typed enumeration WFCStringID.
	/// </summary>
	public enum WFCStringID
	{
		/// <summary>
		/// Strongly typed for value WFC_VENDOR.
		/// </summary>
		Vendor = Wfc.VENDOR,

		/// <summary>
		/// Strongly typed for value WFC_RENDERER.
		/// </summary>
		Renderer = Wfc.RENDERER,

		/// <summary>
		/// Strongly typed for value WFC_VERSION.
		/// </summary>
		Version = Wfc.VERSION,

		/// <summary>
		/// Strongly typed for value WFC_EXTENSIONS.
		/// </summary>
		Extensions = Wfc.EXTENSIONS,

		/// <summary>
		/// Strongly typed for value WFC_STRINGID_FORCE_32BIT.
		/// </summary>
		StringidForce32bit = Wfc.STRINGID_FORCE_32BIT,

	}

}
