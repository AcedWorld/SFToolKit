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
	// Token: 0x020002E4 RID: 740
	[MovedFrom("UnityEngine.XR.WSA.WebCam")]
	[NativeHeader("PlatformDependent/Win/Webcam/VideoCaptureBindings.h")]
	[StaticAccessor("VideoCaptureBindings", StaticAccessorType.DoubleColon)]
	[StructLayout(LayoutKind.Sequential)]
	public class VideoCapture : IDisposable
	{
		// Token: 0x06001F0F RID: 7951 RVA: 0x00033064 File Offset: 0x00031264
		private static VideoCapture.VideoCaptureResult MakeCaptureResult(VideoCapture.CaptureResultType resultType, long hResult)
		{
			return new VideoCapture.VideoCaptureResult
			{
				resultType = resultType,
				hResult = hResult
			};
		}

		// Token: 0x06001F10 RID: 7952 RVA: 0x00033090 File Offset: 0x00031290
		private static VideoCapture.VideoCaptureResult MakeCaptureResult(long hResult)
		{
			VideoCapture.VideoCaptureResult result = default(VideoCapture.VideoCaptureResult);
			bool flag = hResult == VideoCapture.HR_SUCCESS;
			VideoCapture.CaptureResultType resultType;
			if (flag)
			{
				resultType = VideoCapture.CaptureResultType.Success;
			}
			else
			{
				resultType = VideoCapture.CaptureResultType.UnknownError;
			}
			result.resultType = resultType;
			result.hResult = hResult;
			return result;
		}

		// Token: 0x1700060A RID: 1546
		// (get) Token: 0x06001F11 RID: 7953 RVA: 0x000330D4 File Offset: 0x000312D4
		public static IEnumerable<Resolution> SupportedResolutions
		{
			get
			{
				bool flag = VideoCapture.s_SupportedResolutions == null;
				if (flag)
				{
					VideoCapture.s_SupportedResolutions = VideoCapture.GetSupportedResolutions_Internal();
				}
				return VideoCapture.s_SupportedResolutions;
			}
		}

		// Token: 0x06001F12 RID: 7954
		[NativeConditional("(PLATFORM_WIN || PLATFORM_WINRT) && !PLATFORM_XBOXONE")]
		[NativeName("GetSupportedResolutions")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern Resolution[] GetSupportedResolutions_Internal();

		// Token: 0x06001F13 RID: 7955 RVA: 0x00033104 File Offset: 0x00031304
		public static IEnumerable<float> GetSupportedFrameRatesForResolution(Resolution resolution)
		{
			return VideoCapture.GetSupportedFrameRatesForResolution_Internal(resolution.width, resolution.height);
		}

		// Token: 0x06001F14 RID: 7956
		[NativeConditional("(PLATFORM_WIN || PLATFORM_WINRT) && !PLATFORM_XBOXONE")]
		[NativeName("GetSupportedFrameRatesForResolution")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern float[] GetSupportedFrameRatesForResolution_Internal(int resolutionWidth, int resolutionHeight);

		// Token: 0x1700060B RID: 1547
		// (get) Token: 0x06001F15 RID: 7957
		public extern bool IsRecording { [NativeConditional("(PLATFORM_WIN || PLATFORM_WINRT) && !PLATFORM_XBOXONE")] [NativeMethod("VideoCaptureBindings::IsRecording", HasExplicitThis = true)] [MethodImpl(MethodImplOptions.InternalCall)] get; }

		// Token: 0x06001F16 RID: 7958 RVA: 0x00033130 File Offset: 0x00031330
		public static void CreateAsync(bool showHolograms, VideoCapture.OnVideoCaptureResourceCreatedCallback onCreatedCallback)
		{
			bool flag = onCreatedCallback == null;
			if (flag)
			{
				throw new ArgumentNullException("onCreatedCallback");
			}
			VideoCapture.Instantiate_Internal(showHolograms, onCreatedCallback);
		}

		// Token: 0x06001F17 RID: 7959 RVA: 0x0003315C File Offset: 0x0003135C
		public static void CreateAsync(VideoCapture.OnVideoCaptureResourceCreatedCallback onCreatedCallback)
		{
			bool flag = onCreatedCallback == null;
			if (flag)
			{
				throw new ArgumentNullException("onCreatedCallback");
			}
			VideoCapture.Instantiate_Internal(false, onCreatedCallback);
		}

		// Token: 0x06001F18 RID: 7960
		[NativeName("Instantiate")]
		[NativeConditional("(PLATFORM_WIN || PLATFORM_WINRT) && !PLATFORM_XBOXONE")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Instantiate_Internal(bool showHolograms, VideoCapture.OnVideoCaptureResourceCreatedCallback onCreatedCallback);

		// Token: 0x06001F19 RID: 7961 RVA: 0x00033188 File Offset: 0x00031388
		[RequiredByNativeCode]
		private static void InvokeOnCreatedVideoCaptureResourceDelegate(VideoCapture.OnVideoCaptureResourceCreatedCallback callback, IntPtr nativePtr)
		{
			bool flag = nativePtr == IntPtr.Zero;
			if (flag)
			{
				callback(null);
			}
			else
			{
				callback(new VideoCapture(nativePtr));
			}
		}

		// Token: 0x06001F1A RID: 7962 RVA: 0x000331C0 File Offset: 0x000313C0
		private VideoCapture(IntPtr nativeCaptureObject)
		{
			this.m_NativePtr = nativeCaptureObject;
		}

		// Token: 0x06001F1B RID: 7963 RVA: 0x000331D4 File Offset: 0x000313D4
		public void StartVideoModeAsync(CameraParameters setupParams, VideoCapture.AudioState audioState, VideoCapture.OnVideoModeStartedCallback onVideoModeStartedCallback)
		{
			bool flag = onVideoModeStartedCallback == null;
			if (flag)
			{
				throw new ArgumentNullException("onVideoModeStartedCallback");
			}
			bool flag2 = setupParams.cameraResolutionWidth == 0 || setupParams.cameraResolutionHeight == 0;
			if (flag2)
			{
				throw new ArgumentOutOfRangeException("setupParams", "The camera resolution must be set to a supported resolution.");
			}
			bool flag3 = setupParams.frameRate == 0f;
			if (flag3)
			{
				throw new ArgumentOutOfRangeException("setupParams", "The camera frame rate must be set to a supported recording frame rate.");
			}
			this.StartVideoMode_Internal(setupParams, audioState, onVideoModeStartedCallback);
		}

		// Token: 0x06001F1C RID: 7964 RVA: 0x0003324E File Offset: 0x0003144E
		[NativeConditional("(PLATFORM_WIN || PLATFORM_WINRT) && !PLATFORM_XBOXONE")]
		[NativeMethod("VideoCaptureBindings::StartVideoMode", HasExplicitThis = true)]
		private void StartVideoMode_Internal(CameraParameters cameraParameters, VideoCapture.AudioState audioState, VideoCapture.OnVideoModeStartedCallback onVideoModeStartedCallback)
		{
			this.StartVideoMode_Internal_Injected(ref cameraParameters, audioState, onVideoModeStartedCallback);
		}

		// Token: 0x06001F1D RID: 7965 RVA: 0x0003325A File Offset: 0x0003145A
		[RequiredByNativeCode]
		private static void InvokeOnVideoModeStartedDelegate(VideoCapture.OnVideoModeStartedCallback callback, long hResult)
		{
			callback(VideoCapture.MakeCaptureResult(hResult));
		}

		// Token: 0x06001F1E RID: 7966
		[NativeMethod("VideoCaptureBindings::StopVideoMode", HasExplicitThis = true)]
		[NativeConditional("(PLATFORM_WIN || PLATFORM_WINRT) && !PLATFORM_XBOXONE")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void StopVideoModeAsync([NotNull("ArgumentNullException")] VideoCapture.OnVideoModeStoppedCallback onVideoModeStoppedCallback);

		// Token: 0x06001F1F RID: 7967 RVA: 0x0003326A File Offset: 0x0003146A
		[RequiredByNativeCode]
		private static void InvokeOnVideoModeStoppedDelegate(VideoCapture.OnVideoModeStoppedCallback callback, long hResult)
		{
			callback(VideoCapture.MakeCaptureResult(hResult));
		}

		// Token: 0x06001F20 RID: 7968 RVA: 0x0003327C File Offset: 0x0003147C
		public void StartRecordingAsync(string filename, VideoCapture.OnStartedRecordingVideoCallback onStartedRecordingVideoCallback)
		{
			bool flag = onStartedRecordingVideoCallback == null;
			if (flag)
			{
				throw new ArgumentNullException("onStartedRecordingVideoCallback");
			}
			bool flag2 = string.IsNullOrEmpty(filename);
			if (flag2)
			{
				throw new ArgumentNullException("filename");
			}
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
			this.StartRecordingVideoToDisk_Internal(fileInfo.FullName, onStartedRecordingVideoCallback);
		}

		// Token: 0x06001F21 RID: 7969
		[NativeConditional("(PLATFORM_WIN || PLATFORM_WINRT) && !PLATFORM_XBOXONE")]
		[NativeMethod("VideoCaptureBindings::StartRecordingVideoToDisk", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void StartRecordingVideoToDisk_Internal(string filename, VideoCapture.OnStartedRecordingVideoCallback onStartedRecordingVideoCallback);

		// Token: 0x06001F22 RID: 7970 RVA: 0x00033323 File Offset: 0x00031523
		[RequiredByNativeCode]
		private static void InvokeOnStartedRecordingVideoToDiskDelegate(VideoCapture.OnStartedRecordingVideoCallback callback, long hResult)
		{
			callback(VideoCapture.MakeCaptureResult(hResult));
		}

		// Token: 0x06001F23 RID: 7971
		[NativeMethod("VideoCaptureBindings::StopRecordingVideoToDisk", HasExplicitThis = true)]
		[NativeConditional("(PLATFORM_WIN || PLATFORM_WINRT) && !PLATFORM_XBOXONE")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern void StopRecordingAsync([NotNull("ArgumentNullException")] VideoCapture.OnStoppedRecordingVideoCallback onStoppedRecordingVideoCallback);

		// Token: 0x06001F24 RID: 7972 RVA: 0x00033333 File Offset: 0x00031533
		[RequiredByNativeCode]
		private static void InvokeOnStoppedRecordingVideoToDiskDelegate(VideoCapture.OnStoppedRecordingVideoCallback callback, long hResult)
		{
			callback(VideoCapture.MakeCaptureResult(hResult));
		}

		// Token: 0x06001F25 RID: 7973
		[ThreadAndSerializationSafe]
		[NativeMethod("VideoCaptureBindings::GetUnsafePointerToVideoDeviceController", HasExplicitThis = true)]
		[NativeConditional("(PLATFORM_WIN || PLATFORM_WINRT) && !PLATFORM_XBOXONE")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern IntPtr GetUnsafePointerToVideoDeviceController();

		// Token: 0x06001F26 RID: 7974 RVA: 0x00033344 File Offset: 0x00031544
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

		// Token: 0x06001F27 RID: 7975
		[NativeMethod("VideoCaptureBindings::Dispose", HasExplicitThis = true)]
		[NativeConditional("(PLATFORM_WIN || PLATFORM_WINRT) && !PLATFORM_XBOXONE")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void Dispose_Internal();

		// Token: 0x06001F28 RID: 7976 RVA: 0x00033384 File Offset: 0x00031584
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

		// Token: 0x06001F29 RID: 7977
		[NativeConditional("(PLATFORM_WIN || PLATFORM_WINRT) && !PLATFORM_XBOXONE")]
		[ThreadAndSerializationSafe]
		[NativeMethod("VideoCaptureBindings::DisposeThreaded", HasExplicitThis = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void DisposeThreaded_Internal();

		// Token: 0x06001F2A RID: 7978
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void StartVideoMode_Internal_Injected(ref CameraParameters cameraParameters, VideoCapture.AudioState audioState, VideoCapture.OnVideoModeStartedCallback onVideoModeStartedCallback);

		// Token: 0x04000A35 RID: 2613
		internal IntPtr m_NativePtr;

		// Token: 0x04000A36 RID: 2614
		private static Resolution[] s_SupportedResolutions;

		// Token: 0x04000A37 RID: 2615
		private static readonly long HR_SUCCESS;

		// Token: 0x020002E5 RID: 741
		public enum CaptureResultType
		{
			// Token: 0x04000A39 RID: 2617
			Success,
			// Token: 0x04000A3A RID: 2618
			UnknownError
		}

		// Token: 0x020002E6 RID: 742
		public enum AudioState
		{
			// Token: 0x04000A3C RID: 2620
			MicAudio,
			// Token: 0x04000A3D RID: 2621
			ApplicationAudio,
			// Token: 0x04000A3E RID: 2622
			ApplicationAndMicAudio,
			// Token: 0x04000A3F RID: 2623
			None
		}

		// Token: 0x020002E7 RID: 743
		public struct VideoCaptureResult
		{
			// Token: 0x1700060C RID: 1548
			// (get) Token: 0x06001F2B RID: 7979 RVA: 0x000333D8 File Offset: 0x000315D8
			public bool success
			{
				get
				{
					return this.resultType == VideoCapture.CaptureResultType.Success;
				}
			}

			// Token: 0x04000A40 RID: 2624
			public VideoCapture.CaptureResultType resultType;

			// Token: 0x04000A41 RID: 2625
			public long hResult;
		}

		// Token: 0x020002E8 RID: 744
		// (Invoke) Token: 0x06001F2D RID: 7981
		public delegate void OnVideoCaptureResourceCreatedCallback(VideoCapture captureObject);

		// Token: 0x020002E9 RID: 745
		// (Invoke) Token: 0x06001F31 RID: 7985
		public delegate void OnVideoModeStartedCallback(VideoCapture.VideoCaptureResult result);

		// Token: 0x020002EA RID: 746
		// (Invoke) Token: 0x06001F35 RID: 7989
		public delegate void OnVideoModeStoppedCallback(VideoCapture.VideoCaptureResult result);

		// Token: 0x020002EB RID: 747
		// (Invoke) Token: 0x06001F39 RID: 7993
		public delegate void OnStartedRecordingVideoCallback(VideoCapture.VideoCaptureResult result);

		// Token: 0x020002EC RID: 748
		// (Invoke) Token: 0x06001F3D RID: 7997
		public delegate void OnStoppedRecordingVideoCallback(VideoCapture.VideoCaptureResult result);
	}
}
