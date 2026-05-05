using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEngine.Windows.WebCam
{
	// Token: 0x020002E3 RID: 739
	[NativeConditional("(PLATFORM_WIN || PLATFORM_WINRT) && !PLATFORM_XBOXONE")]
	[NativeHeader("PlatformDependent/Win/Webcam/PhotoCaptureFrame.h")]
	[MovedFrom("UnityEngine.XR.WSA.WebCam")]
	public sealed class PhotoCaptureFrame : IDisposable
	{
		// Token: 0x17000607 RID: 1543
		// (get) Token: 0x06001EF5 RID: 7925 RVA: 0x00032D77 File Offset: 0x00030F77
		// (set) Token: 0x06001EF6 RID: 7926 RVA: 0x00032D7F File Offset: 0x00030F7F
		public int dataLength { get; private set; }

		// Token: 0x17000608 RID: 1544
		// (get) Token: 0x06001EF7 RID: 7927 RVA: 0x00032D88 File Offset: 0x00030F88
		// (set) Token: 0x06001EF8 RID: 7928 RVA: 0x00032D90 File Offset: 0x00030F90
		public bool hasLocationData { get; private set; }

		// Token: 0x17000609 RID: 1545
		// (get) Token: 0x06001EF9 RID: 7929 RVA: 0x00032D99 File Offset: 0x00030F99
		// (set) Token: 0x06001EFA RID: 7930 RVA: 0x00032DA1 File Offset: 0x00030FA1
		public CapturePixelFormat pixelFormat { get; private set; }

		// Token: 0x06001EFB RID: 7931
		[ThreadAndSerializationSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern int GetDataLength();

		// Token: 0x06001EFC RID: 7932
		[ThreadAndSerializationSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern bool GetHasLocationData();

		// Token: 0x06001EFD RID: 7933
		[ThreadAndSerializationSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern CapturePixelFormat GetCapturePixelFormat();

		// Token: 0x06001EFE RID: 7934 RVA: 0x00032DAC File Offset: 0x00030FAC
		public bool TryGetCameraToWorldMatrix(out Matrix4x4 cameraToWorldMatrix)
		{
			cameraToWorldMatrix = Matrix4x4.identity;
			bool hasLocationData = this.hasLocationData;
			bool result;
			if (hasLocationData)
			{
				cameraToWorldMatrix = this.GetCameraToWorldMatrix();
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06001EFF RID: 7935 RVA: 0x00032DE8 File Offset: 0x00030FE8
		[NativeConditional("PLATFORM_WIN && !PLATFORM_XBOXONE", "Matrix4x4f()")]
		[NativeName("GetCameraToWorld")]
		[ThreadAndSerializationSafe]
		private Matrix4x4 GetCameraToWorldMatrix()
		{
			Matrix4x4 result;
			this.GetCameraToWorldMatrix_Injected(out result);
			return result;
		}

		// Token: 0x06001F00 RID: 7936 RVA: 0x00032E00 File Offset: 0x00031000
		public bool TryGetProjectionMatrix(out Matrix4x4 projectionMatrix)
		{
			bool hasLocationData = this.hasLocationData;
			bool result;
			if (hasLocationData)
			{
				projectionMatrix = this.GetProjection();
				result = true;
			}
			else
			{
				projectionMatrix = Matrix4x4.identity;
				result = false;
			}
			return result;
		}

		// Token: 0x06001F01 RID: 7937 RVA: 0x00032E3C File Offset: 0x0003103C
		public bool TryGetProjectionMatrix(float nearClipPlane, float farClipPlane, out Matrix4x4 projectionMatrix)
		{
			bool hasLocationData = this.hasLocationData;
			bool result;
			if (hasLocationData)
			{
				float num = 0.01f;
				bool flag = nearClipPlane < num;
				if (flag)
				{
					nearClipPlane = num;
				}
				bool flag2 = farClipPlane < nearClipPlane + num;
				if (flag2)
				{
					farClipPlane = nearClipPlane + num;
				}
				projectionMatrix = this.GetProjection();
				float num2 = 1f / (farClipPlane - nearClipPlane);
				float m = -(farClipPlane + nearClipPlane) * num2;
				float m2 = -(2f * farClipPlane * nearClipPlane) * num2;
				projectionMatrix.m22 = m;
				projectionMatrix.m23 = m2;
				result = true;
			}
			else
			{
				projectionMatrix = Matrix4x4.identity;
				result = false;
			}
			return result;
		}

		// Token: 0x06001F02 RID: 7938 RVA: 0x00032ED0 File Offset: 0x000310D0
		[ThreadAndSerializationSafe]
		[NativeConditional("PLATFORM_WIN && !PLATFORM_XBOXONE", "Matrix4x4f()")]
		private Matrix4x4 GetProjection()
		{
			Matrix4x4 result;
			this.GetProjection_Injected(out result);
			return result;
		}

		// Token: 0x06001F03 RID: 7939 RVA: 0x00032EE8 File Offset: 0x000310E8
		public void UploadImageDataToTexture(Texture2D targetTexture)
		{
			bool flag = targetTexture == null;
			if (flag)
			{
				throw new ArgumentNullException("targetTexture");
			}
			bool flag2 = this.pixelFormat > CapturePixelFormat.BGRA32;
			if (flag2)
			{
				throw new ArgumentException("Uploading PhotoCaptureFrame to a texture is only supported with BGRA32 CameraFrameFormat!");
			}
			this.UploadImageDataToTexture_Internal(targetTexture);
		}

		// Token: 0x06001F04 RID: 7940
		[NativeName("UploadImageDataToTexture")]
		[ThreadAndSerializationSafe]
		[NativeConditional("(PLATFORM_WIN || PLATFORM_WINRT) && !PLATFORM_XBOXONE")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void UploadImageDataToTexture_Internal(Texture2D targetTexture);

		// Token: 0x06001F05 RID: 7941
		[ThreadAndSerializationSafe]
		[NativeConditional("(PLATFORM_WIN || PLATFORM_WINRT) && !PLATFORM_XBOXONE")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public extern IntPtr GetUnsafePointerToBuffer();

		// Token: 0x06001F06 RID: 7942 RVA: 0x00032F30 File Offset: 0x00031130
		public void CopyRawImageDataIntoBuffer(List<byte> byteBuffer)
		{
			bool flag = byteBuffer == null;
			if (flag)
			{
				throw new ArgumentNullException("byteBuffer");
			}
			byte[] array = new byte[this.dataLength];
			this.CopyRawImageDataIntoBuffer_Internal(array);
			bool flag2 = byteBuffer.Capacity < array.Length;
			if (flag2)
			{
				byteBuffer.Capacity = array.Length;
			}
			byteBuffer.Clear();
			byteBuffer.AddRange(array);
		}

		// Token: 0x06001F07 RID: 7943
		[ThreadAndSerializationSafe]
		[NativeName("CopyRawImageDataIntoBuffer")]
		[NativeConditional("(PLATFORM_WIN || PLATFORM_WINRT) && !PLATFORM_XBOXONE")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		internal extern void CopyRawImageDataIntoBuffer_Internal([Out] byte[] byteArray);

		// Token: 0x06001F08 RID: 7944 RVA: 0x00032F90 File Offset: 0x00031190
		internal PhotoCaptureFrame(IntPtr nativePtr)
		{
			this.m_NativePtr = nativePtr;
			this.dataLength = this.GetDataLength();
			this.hasLocationData = this.GetHasLocationData();
			this.pixelFormat = this.GetCapturePixelFormat();
			GC.AddMemoryPressure((long)this.dataLength);
		}

		// Token: 0x06001F09 RID: 7945 RVA: 0x00032FE0 File Offset: 0x000311E0
		private void Cleanup()
		{
			bool flag = this.m_NativePtr != IntPtr.Zero;
			if (flag)
			{
				GC.RemoveMemoryPressure((long)this.dataLength);
				this.Dispose_Internal();
				this.m_NativePtr = IntPtr.Zero;
			}
		}

		// Token: 0x06001F0A RID: 7946
		[NativeName("Dispose")]
		[ThreadAndSerializationSafe]
		[NativeConditional("(PLATFORM_WIN || PLATFORM_WINRT) && !PLATFORM_XBOXONE")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void Dispose_Internal();

		// Token: 0x06001F0B RID: 7947 RVA: 0x00033023 File Offset: 0x00031223
		public void Dispose()
		{
			this.Cleanup();
			GC.SuppressFinalize(this);
		}

		// Token: 0x06001F0C RID: 7948 RVA: 0x00033034 File Offset: 0x00031234
		~PhotoCaptureFrame()
		{
			this.Cleanup();
		}

		// Token: 0x06001F0D RID: 7949
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void GetCameraToWorldMatrix_Injected(out Matrix4x4 ret);

		// Token: 0x06001F0E RID: 7950
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void GetProjection_Injected(out Matrix4x4 ret);

		// Token: 0x04000A31 RID: 2609
		private IntPtr m_NativePtr;
	}
}
