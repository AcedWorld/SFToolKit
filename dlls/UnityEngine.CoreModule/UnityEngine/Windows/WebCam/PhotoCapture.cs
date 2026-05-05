using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEngine.Windows.WebCam
{
	// Token: 0x020002DB RID: 731
	[StaticAccessor("PhotoCapture", StaticAccessorType.DoubleColon)]
	[MovedFrom("UnityEngine.XR.WSA.WebCam")]
	[NativeHeader("PlatformDependent/Win/Webcam/PhotoCapture.h")]
	[StructLayout(LayoutKind.Sequential)]
	public class PhotoCapture : IDisposable
	{
		// Token: 0x06001EC6 RID: 7878 RVA: 0x000329D4 File Offset: 0x00030BD4
		private static PhotoCapture.PhotoCaptureResult MakeCaptureResult(PhotoCapture.CaptureResultType resultType, long hResult)
		{
			return new PhotoCapture.PhotoCaptureResult
			{
				resultType = resultType,
				hResult = hResult
			};
		}

		// Token: 0x06001EC7 RID: 7879 RVA: 0x00032A00 File Offset: 0x00030C00
		private static PhotoCapture.PhotoCaptureResult MakeCaptureResult(long hResult)
		{
			PhotoCapture.PhotoCaptureResult result = default(PhotoCapture.PhotoCaptureResult);
			bool flag = hResult == PhotoCapture.HR_SUCCESS;
			PhotoCapture.CaptureResultType resultType;
			if (flag)
			{
				resultType = PhotoCapture.CaptureResultType.Success;
			}
			else
			{
				resultType = PhotoCapture.CaptureResultType.UnknownError;
			}
			result.resultType = resultType;
			result.hResult = hResult;
			return result;
		}

		// Token: 0x17000605 RID: 1541
		// (get) Token: 0x06001EC8 RID: 7880 RVA: 0x00032A44 File Offset: 0x00030C44
		public static IEnumerable<Resolution> SupportedResolutions
		{
			get
			{
				bool flag = PhotoCapture.s_SupportedResolutions == null;
				if (flag)
				{
					PhotoCapture.s_SupportedResolutions = PhotoCapture.GetSupportedResolutions_Internal();
				}
				return PhotoCapture.s_SupportedResolutions;
			}
		}

		// Token: 0x06001EC9 RID: 7881
		[NativeConditional("(PLATFORM_WIN || PLATFORM_WINRT) && !PLATFORM_XBOXONE")]
		[NativeName("GetSupportedResolutions")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern Resolution[] GetSupportedResolutions_Internal();

		// Token: 0x06001ECA RID: 7882 RVA: 0x00032A74 File Offset: 0x00030C74
		public static void CreateAsync(bool showHolograms, PhotoCapture.OnCaptureResourceCreatedCallback onCreatedCallback)
		{
			bool flag = onCreatedCallback == null;
			if (flag)
			{
				throw new ArgumentNullException("onCreatedCallback");
			}
			PhotoCapture.Instantiate_Internal(showHolograms, onCreatedCallback);
		}

		// Token: 0x06001ECB RID: 7883 RVA: 0x00032AA0 File Offset: 0x00030CA0
		public static void CreateAsync(PhotoCapture.OnCaptureResourceCreatedCallback onCreatedCallback)
		{
			bool flag = onCreatedCallback == null;
			if (flag)
			{
				throw new ArgumentNullException("onCreatedCallback");
			}
			PhotoCapture.Instantiate_Internal(false, onCreatedCallback);
		}

		// Token: 0x06001ECC RID: 7884
		[NativeName("Instantiate")]
		[NativeConditional("(PLATFORM_WIN || PLATFORM_WINRT) && !PLATFORM_XBOXONE")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr Instantiate_Internal(bool showHolograms, PhotoCapture.OnCaptureResourceCreatedCallback onCreatedCallback);

		// Token: 0x06001ECD RID: 7885 RVA: 0x00032ACC File Offset: 0x00030CCC
		[RequiredByNativeCode]
		private static void InvokeOnCreatedResourceDelegate(PhotoCapture.OnCaptureResourceCreatedCallback callback, IntPtr nativePtr)
		{
			bool flag = nativePtr == IntPtr.Zero;
			if (flag)
			{
				callback(null);
			}
			else
			{
				callback(new PhotoCapture(nativePtr));
			}
		}

		// Token: 0x06001ECE RID: 7886 RVA: 0x00032B04 File Offset: 0x00030D04
		private PhotoCapture(IntPtr nativeCaptureObject)
		{
			this.m_NativePtr = nativeCaptureObject;
		}

		// Token: 0x06001ECF RID: 7887 RVA: 0x00032B18 File Offset: 0x00030D18
		public void StartPhotoModeAsync(CameraParameters setupParams, PhotoCapture.OnPhotoModeStartedCallback onPhotoModeStartedCallback)
		{
			bool flag = onPhotoModeStartedCallback == null;
			if (flag)
			{
				throw new ArgumentException("onPhotoModeStartedCallback");
			}
			bool flag2 = setupParams.cameraResolutionWidth == 0 || setupParams.cameraResolutionHeight == 0;
			if (flag2)
			{
				throw new ArgumentOutOfRangeException("setupParams", "The camera resolution must be set to a supported resolution.");
			}
			this.StartPhotoMode_Internal(setupParams, onPhotoModeStartedCallback);
		}

		// Token: 0x06001ED0 RID: 7888 RVA: 0x00032B6E File Offset: 0x00030D6E
		[NativeName("StartPhotoMode")]
		[NativeConditional("(PLATFORM_WIN || PLATFORM_WINRT) && !PLATFORM_XBOXONE")]
		private void StartPhotoMode_Internal(CameraParameters setupParams, PhotoCapture.OnPhotoModeStartedCallback onPhotoModeStartedCallback)
		{
			this.StartPhotoMode_Internal_Injected(ref setupParams, onPhotoModeStartedCallback);
		}

		// Token: 0x06001ED1 RID: 7889 RVA: 0x00032B79 File Offset: 0x00030D79
		[RequiredByNativeCode]
		private static void InvokeOnPhotoModeStartedDelegate(PhotoCapture.OnPhotoModeStartedCallback callback, long hResult)
		{
			callback(PhotoCapture.MakeCaptureResult(hResult));
		}

		// Token: 0x06001ED2 RID: 7890
		[NativeConditional("(PLATFORM_WIN || PLATFORM_WINRT) && !PLATFORM_XBOXONE")]
		[NativeName("StopPhotoMode")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void StopPhotoModeAsync(PhotoCapture.OnPhotoModeStoppedCallback onPhotoModeStoppedCallback);

		// Token: 0x06001ED3 RID: 7891 RVA: 0x00032B89 File Offset: 0x00030D89
		[RequiredByNativeCode]
		private static void InvokeOnPhotoModeStoppedDelegate(PhotoCapture.OnPhotoModeStoppedCallback callback, long hResult)
		{
			callback(PhotoCapture.MakeCaptureResult(hResult));
		}

		// Token: 0x06001ED4 RID: 7892 RVA: 0x00032B9C File Offset: 0x00030D9C
		public void TakePhotoAsync(string filename, PhotoCaptureFileOutputFormat fileOutputFormat, PhotoCapture.OnCapturedToDiskCallback onCapturedPhotoToDiskCallback)
		{
			bool flag = onCapturedPhotoToDiskCallback == null;
			if (flag)
			{
				throw new ArgumentNullException("onCapturedPhotoToDiskCallback");
			}
			bool flag2 = string.IsNullOrEmpty(filename);
			if (flag2)
			{
				throw new ArgumentNullException("filename");
			}
			filename = filename.Replace("/", "\\");
			string directoryName = Path.GetDirectoryName(filename);
			bool flag3 = !string.IsNullOrEmpty(directoryName) && !Directory.Exists(directoryName);
			if (flag3)
			{
				throw new ArgumentException("The specified directory does not exist.", "filename");
			}
			FileInfo fileInfo = new FileInfo(filename);
			bool flag4 = fileInfo.Exists && fileInfo.IsReadOnly;
			if (flag4)
			{
				throw new ArgumentException("Cannot write to the file because it is read-only.", "filename");
			}
			this.CapturePhotoToDisk_Internal(filename, fileOutputFormat, onCapturedPhotoToDiskCallback);
		}

		// Token: 0x06001ED5 RID: 7893
		[NativeName("CapturePhotoToDisk")]
		[NativeConditional("(PLATFORM_WIN || PLATFORM_WINRT) && !PLATFORM_XBOXONE")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void CapturePhotoToDisk_Internal(string filename, PhotoCaptureFileOutputFormat fileOutputFormat, PhotoCapture.OnCapturedToDiskCallback onCapturedPhotoToDiskCallback);

		// Token: 0x06001ED6 RID: 7894 RVA: 0x00032C51 File Offset: 0x00030E51
		[RequiredByNativeCode]
		private static void InvokeOnCapturedPhotoToDiskDelegate(PhotoCapture.OnCapturedToDiskCallback callback, long hResult)
		{
			callback(PhotoCapture.MakeCaptureResult(hResult));
		}

		// Token: 0x06001ED7 RID: 7895 RVA: 0x00032C64 File Offset: 0x00030E64
		public void TakePhotoAsync(PhotoCapture.OnCapturedToMemoryCallback onCapturedPhotoToMemoryCallback)
		{
			bool flag = onCapturedPhotoToMemoryCallback == null;
			if (flag)
			{
				throw new ArgumentNullException("onCapturedPhotoToMemoryCallback");
			}
			this.CapturePhotoToMemory_Internal(onCapturedPhotoToMemoryCallback);
		}

		// Token: 0x06001ED8 RID: 7896
		[NativeConditional("(PLATFORM_WIN || PLATFORM_WINRT) && !PLATFORM_XBOXONE")]
		[NativeName("CapturePhotoToMemory")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void CapturePhotoToMemory_Internal(PhotoCapture.OnCapturedToMemoryCallback onCapturedPhotoToMemoryCallback);

		// Token: 0x06001ED9 RID: 7897 RVA: 0x00032C90 File Offset: 0x00030E90
		[RequiredByNativeCode]
		private static void InvokeOnCapturedPhotoToMemoryDelegate(PhotoCapture.OnCapturedToMemoryCallback callback, long hResult, IntPtr photoCaptureFramePtr)
		{
			PhotoCaptureFrame photoCaptureFrame = null;
			bool flag = photoCaptureFramePtr != IntPtr.Zero;
			if (flag)
			{
				photoCaptureFrame = new PhotoCaptureFrame(photoCaptureFramePtr);
			}
			callback(PhotoCapture.MakeCaptureResult(hResult), photoCaptureFrame);
		}

		// Token: 0x06001EDA RID: 7898
		[NativeConditional("(PLATFORM_WIN || PLATFORM_WINRT) && !PLATFORM_XBOXONE")]
		[ThreadAndSerializationSafe]
		[NativeName("GetUnsafePointerToVideoDeviceController")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern IntPtr GetUnsafePointerToVideoDeviceController();

		// Token: 0x06001EDB RID: 7899 RVA: 0x00032CC8 File Offset: 0x00030EC8
		public void Dispose()
		{
			bool flag = this.m_NativePtr != IntPtr.Zero;
			if (flag)
			{
				this.Dispose_Internal();
				this.m_NativePtr = IntPtr.Zero;
			}
			GC.SuppressFinalize(this);
		}

		// Token: 0x06001EDC RID: 7900
		[NativeConditional("(PLATFORM_WIN || PLATFORM_WINRT) && !PLATFORM_XBOXONE")]
		[NativeName("Dispose")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void Dispose_Internal();

		// Token: 0x06001EDD RID: 7901 RVA: 0x00032D08 File Offset: 0x00030F08
		protected override void Finalize()
		{
			try
			{
				bool flag = this.m_NativePtr != IntPtr.Zero;
				if (flag)
				{
					this.DisposeThreaded_Internal();
					this.m_NativePtr = IntPtr.Zero;
				}
			}
			finally
			{
				base.Finalize();
			}
		}

		// Token: 0x06001EDE RID: 7902
		[ThreadAndSerializationSafe]
		[NativeConditional("(PLATFORM_WIN || PLATFORM_WINRT) && !PLATFORM_XBOXONE")]
		[NativeName("DisposeThreaded")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void DisposeThreaded_Internal();

		// Token: 0x06001EDF RID: 7903
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void StartPhotoMode_Internal_Injected(ref CameraParameters setupParams, PhotoCapture.OnPhotoModeStartedCallback onPhotoModeStartedCallback);

		// Token: 0x04000A29 RID: 2601
		internal IntPtr m_NativePtr;

		// Token: 0x04000A2A RID: 2602
		private static Resolution[] s_SupportedResolutions;

		// Token: 0x04000A2B RID: 2603
		private static readonly long HR_SUCCESS;

		// Token: 0x020002DC RID: 732
		public enum CaptureResultType
		{
			// Token: 0x04000A2D RID: 2605
			Success,
			// Token: 0x04000A2E RID: 2606
			UnknownError
		}

		// Token: 0x020002DD RID: 733
		public struct PhotoCaptureResult
		{
			// Token: 0x17000606 RID: 1542
			// (get) Token: 0x06001EE0 RID: 7904 RVA: 0x00032D5C File Offset: 0x00030F5C
			public bool success
			{
				get
				{
					return this.resultType == PhotoCapture.CaptureResultType.Success;
				}
			}

			// Token: 0x04000A2F RID: 2607
			public PhotoCapture.CaptureResultType resultType;

			// Token: 0x04000A30 RID: 2608
			public long hResult;
		}

		// Token: 0x020002DE RID: 734
		// (Invoke) Token: 0x06001EE2 RID: 7906
		public delegate void OnCaptureResourceCreatedCallback(PhotoCapture captureObject);

		// Token: 0x020002DF RID: 735
		// (Invoke) Token: 0x06001EE6 RID: 7910
		public delegate void OnPhotoModeStartedCallback(PhotoCapture.PhotoCaptureResult result);

		// Token: 0x020002E0 RID: 736
		// (Invoke) Token: 0x06001EEA RID: 7914
		public delegate void OnPhotoModeStoppedCallback(PhotoCapture.PhotoCaptureResult result);

		// Token: 0x020002E1 RID: 737
		// (Invoke) Token: 0x06001EEE RID: 7918
		public delegate void OnCapturedToDiskCallback(PhotoCapture.PhotoCaptureResult result);

		// Token: 0x020002E2 RID: 738
		// (Invoke) Token: 0x06001EF2 RID: 7922
		public delegate void OnCapturedToMemoryCallback(PhotoCapture.PhotoCaptureResult result, PhotoCaptureFrame photoCaptureFrame);
	}
}
