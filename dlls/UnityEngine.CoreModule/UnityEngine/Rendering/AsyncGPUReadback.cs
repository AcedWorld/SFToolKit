using System;
using System.Runtime.CompilerServices;
using Unity.Collections;
using UnityEngine.Bindings;
using UnityEngine.Experimental.Rendering;

namespace UnityEngine.Rendering
{
	// Token: 0x020003E1 RID: 993
	[StaticAccessor("AsyncGPUReadbackManager::GetInstance()", StaticAccessorType.Dot)]
	public static class AsyncGPUReadback
	{
		// Token: 0x06002173 RID: 8563 RVA: 0x000378C4 File Offset: 0x00035AC4
		internal static void ValidateFormat(Texture src, GraphicsFormat dstformat)
		{
			GraphicsFormat format = GraphicsFormatUtility.GetFormat(src);
			bool flag = !SystemInfo.IsFormatSupported(format, FormatUsage.ReadPixels);
			if (flag)
			{
				Debug.LogError(string.Format("'{0}' doesn't support ReadPixels usage on this platform. Async GPU readback failed.", format));
			}
		}

		// Token: 0x06002174 RID: 8564
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void WaitAllRequests();

		// Token: 0x06002175 RID: 8565 RVA: 0x00037900 File Offset: 0x00035B00
		public static AsyncGPUReadbackRequest Request(ComputeBuffer src, Action<AsyncGPUReadbackRequest> callback = null)
		{
			AsyncGPUReadbackRequest result = AsyncGPUReadback.Request_Internal_ComputeBuffer_1(src, null);
			result.SetScriptingCallback(callback);
			return result;
		}

		// Token: 0x06002176 RID: 8566 RVA: 0x00037928 File Offset: 0x00035B28
		public static AsyncGPUReadbackRequest Request(ComputeBuffer src, int size, int offset, Action<AsyncGPUReadbackRequest> callback = null)
		{
			AsyncGPUReadbackRequest result = AsyncGPUReadback.Request_Internal_ComputeBuffer_2(src, size, offset, null);
			result.SetScriptingCallback(callback);
			return result;
		}

		// Token: 0x06002177 RID: 8567 RVA: 0x00037950 File Offset: 0x00035B50
		public static AsyncGPUReadbackRequest Request(GraphicsBuffer src, Action<AsyncGPUReadbackRequest> callback = null)
		{
			AsyncGPUReadbackRequest result = AsyncGPUReadback.Request_Internal_GraphicsBuffer_1(src, null);
			result.SetScriptingCallback(callback);
			return result;
		}

		// Token: 0x06002178 RID: 8568 RVA: 0x00037978 File Offset: 0x00035B78
		public static AsyncGPUReadbackRequest Request(GraphicsBuffer src, int size, int offset, Action<AsyncGPUReadbackRequest> callback = null)
		{
			AsyncGPUReadbackRequest result = AsyncGPUReadback.Request_Internal_GraphicsBuffer_2(src, size, offset, null);
			result.SetScriptingCallback(callback);
			return result;
		}

		// Token: 0x06002179 RID: 8569 RVA: 0x000379A0 File Offset: 0x00035BA0
		public static AsyncGPUReadbackRequest Request(Texture src, int mipIndex = 0, Action<AsyncGPUReadbackRequest> callback = null)
		{
			AsyncGPUReadbackRequest result = AsyncGPUReadback.Request_Internal_Texture_1(src, mipIndex, null);
			result.SetScriptingCallback(callback);
			return result;
		}

		// Token: 0x0600217A RID: 8570 RVA: 0x000379C8 File Offset: 0x00035BC8
		public static AsyncGPUReadbackRequest Request(Texture src, int mipIndex, TextureFormat dstFormat, Action<AsyncGPUReadbackRequest> callback = null)
		{
			return AsyncGPUReadback.Request(src, mipIndex, GraphicsFormatUtility.GetGraphicsFormat(dstFormat, QualitySettings.activeColorSpace == ColorSpace.Linear), callback);
		}

		// Token: 0x0600217B RID: 8571 RVA: 0x000379F0 File Offset: 0x00035BF0
		public static AsyncGPUReadbackRequest Request(Texture src, int mipIndex, GraphicsFormat dstFormat, Action<AsyncGPUReadbackRequest> callback = null)
		{
			AsyncGPUReadback.ValidateFormat(src, dstFormat);
			AsyncGPUReadbackRequest result = AsyncGPUReadback.Request_Internal_Texture_2(src, mipIndex, dstFormat, null);
			result.SetScriptingCallback(callback);
			return result;
		}

		// Token: 0x0600217C RID: 8572 RVA: 0x00037A20 File Offset: 0x00035C20
		public static AsyncGPUReadbackRequest Request(Texture src, int mipIndex, int x, int width, int y, int height, int z, int depth, Action<AsyncGPUReadbackRequest> callback = null)
		{
			AsyncGPUReadbackRequest result = AsyncGPUReadback.Request_Internal_Texture_3(src, mipIndex, x, width, y, height, z, depth, null);
			result.SetScriptingCallback(callback);
			return result;
		}

		// Token: 0x0600217D RID: 8573 RVA: 0x00037A54 File Offset: 0x00035C54
		public static AsyncGPUReadbackRequest Request(Texture src, int mipIndex, int x, int width, int y, int height, int z, int depth, TextureFormat dstFormat, Action<AsyncGPUReadbackRequest> callback = null)
		{
			return AsyncGPUReadback.Request(src, mipIndex, x, width, y, height, z, depth, GraphicsFormatUtility.GetGraphicsFormat(dstFormat, QualitySettings.activeColorSpace == ColorSpace.Linear), callback);
		}

		// Token: 0x0600217E RID: 8574 RVA: 0x00037A88 File Offset: 0x00035C88
		public static AsyncGPUReadbackRequest Request(Texture src, int mipIndex, int x, int width, int y, int height, int z, int depth, GraphicsFormat dstFormat, Action<AsyncGPUReadbackRequest> callback = null)
		{
			AsyncGPUReadback.ValidateFormat(src, dstFormat);
			AsyncGPUReadbackRequest result = AsyncGPUReadback.Request_Internal_Texture_4(src, mipIndex, x, width, y, height, z, depth, dstFormat, null);
			result.SetScriptingCallback(callback);
			return result;
		}

		// Token: 0x0600217F RID: 8575 RVA: 0x00037AC8 File Offset: 0x00035CC8
		public unsafe static AsyncGPUReadbackRequest RequestIntoNativeArray<T>(ref NativeArray<T> output, ComputeBuffer src, Action<AsyncGPUReadbackRequest> callback = null) where T : struct
		{
			AsyncRequestNativeArrayData asyncRequestNativeArrayData = AsyncRequestNativeArrayData.CreateAndCheckAccess<T>(output);
			AsyncGPUReadbackRequest result = AsyncGPUReadback.Request_Internal_ComputeBuffer_1(src, &asyncRequestNativeArrayData);
			result.SetScriptingCallback(callback);
			return result;
		}

		// Token: 0x06002180 RID: 8576 RVA: 0x00037AFC File Offset: 0x00035CFC
		public unsafe static AsyncGPUReadbackRequest RequestIntoNativeArray<T>(ref NativeArray<T> output, ComputeBuffer src, int size, int offset, Action<AsyncGPUReadbackRequest> callback = null) where T : struct
		{
			AsyncRequestNativeArrayData asyncRequestNativeArrayData = AsyncRequestNativeArrayData.CreateAndCheckAccess<T>(output);
			AsyncGPUReadbackRequest result = AsyncGPUReadback.Request_Internal_ComputeBuffer_2(src, size, offset, &asyncRequestNativeArrayData);
			result.SetScriptingCallback(callback);
			return result;
		}

		// Token: 0x06002181 RID: 8577 RVA: 0x00037B34 File Offset: 0x00035D34
		public unsafe static AsyncGPUReadbackRequest RequestIntoNativeArray<T>(ref NativeArray<T> output, GraphicsBuffer src, Action<AsyncGPUReadbackRequest> callback = null) where T : struct
		{
			AsyncRequestNativeArrayData asyncRequestNativeArrayData = AsyncRequestNativeArrayData.CreateAndCheckAccess<T>(output);
			AsyncGPUReadbackRequest result = AsyncGPUReadback.Request_Internal_GraphicsBuffer_1(src, &asyncRequestNativeArrayData);
			result.SetScriptingCallback(callback);
			return result;
		}

		// Token: 0x06002182 RID: 8578 RVA: 0x00037B68 File Offset: 0x00035D68
		public unsafe static AsyncGPUReadbackRequest RequestIntoNativeArray<T>(ref NativeArray<T> output, GraphicsBuffer src, int size, int offset, Action<AsyncGPUReadbackRequest> callback = null) where T : struct
		{
			AsyncRequestNativeArrayData asyncRequestNativeArrayData = AsyncRequestNativeArrayData.CreateAndCheckAccess<T>(output);
			AsyncGPUReadbackRequest result = AsyncGPUReadback.Request_Internal_GraphicsBuffer_2(src, size, offset, &asyncRequestNativeArrayData);
			result.SetScriptingCallback(callback);
			return result;
		}

		// Token: 0x06002183 RID: 8579 RVA: 0x00037BA0 File Offset: 0x00035DA0
		public unsafe static AsyncGPUReadbackRequest RequestIntoNativeArray<T>(ref NativeArray<T> output, Texture src, int mipIndex = 0, Action<AsyncGPUReadbackRequest> callback = null) where T : struct
		{
			AsyncRequestNativeArrayData asyncRequestNativeArrayData = AsyncRequestNativeArrayData.CreateAndCheckAccess<T>(output);
			AsyncGPUReadbackRequest result = AsyncGPUReadback.Request_Internal_Texture_1(src, mipIndex, &asyncRequestNativeArrayData);
			result.SetScriptingCallback(callback);
			return result;
		}

		// Token: 0x06002184 RID: 8580 RVA: 0x00037BD4 File Offset: 0x00035DD4
		public static AsyncGPUReadbackRequest RequestIntoNativeArray<T>(ref NativeArray<T> output, Texture src, int mipIndex, TextureFormat dstFormat, Action<AsyncGPUReadbackRequest> callback = null) where T : struct
		{
			return AsyncGPUReadback.RequestIntoNativeArray<T>(ref output, src, mipIndex, GraphicsFormatUtility.GetGraphicsFormat(dstFormat, QualitySettings.activeColorSpace == ColorSpace.Linear), callback);
		}

		// Token: 0x06002185 RID: 8581 RVA: 0x00037C00 File Offset: 0x00035E00
		public unsafe static AsyncGPUReadbackRequest RequestIntoNativeArray<T>(ref NativeArray<T> output, Texture src, int mipIndex, GraphicsFormat dstFormat, Action<AsyncGPUReadbackRequest> callback = null) where T : struct
		{
			AsyncGPUReadback.ValidateFormat(src, dstFormat);
			AsyncRequestNativeArrayData asyncRequestNativeArrayData = AsyncRequestNativeArrayData.CreateAndCheckAccess<T>(output);
			AsyncGPUReadbackRequest result = AsyncGPUReadback.Request_Internal_Texture_2(src, mipIndex, dstFormat, &asyncRequestNativeArrayData);
			result.SetScriptingCallback(callback);
			return result;
		}

		// Token: 0x06002186 RID: 8582 RVA: 0x00037C40 File Offset: 0x00035E40
		public static AsyncGPUReadbackRequest RequestIntoNativeArray<T>(ref NativeArray<T> output, Texture src, int mipIndex, int x, int width, int y, int height, int z, int depth, TextureFormat dstFormat, Action<AsyncGPUReadbackRequest> callback = null) where T : struct
		{
			return AsyncGPUReadback.RequestIntoNativeArray<T>(ref output, src, mipIndex, x, width, y, height, z, depth, GraphicsFormatUtility.GetGraphicsFormat(dstFormat, QualitySettings.activeColorSpace == ColorSpace.Linear), callback);
		}

		// Token: 0x06002187 RID: 8583 RVA: 0x00037C78 File Offset: 0x00035E78
		public unsafe static AsyncGPUReadbackRequest RequestIntoNativeArray<T>(ref NativeArray<T> output, Texture src, int mipIndex, int x, int width, int y, int height, int z, int depth, GraphicsFormat dstFormat, Action<AsyncGPUReadbackRequest> callback = null) where T : struct
		{
			AsyncGPUReadback.ValidateFormat(src, dstFormat);
			AsyncRequestNativeArrayData asyncRequestNativeArrayData = AsyncRequestNativeArrayData.CreateAndCheckAccess<T>(output);
			AsyncGPUReadbackRequest result = AsyncGPUReadback.Request_Internal_Texture_4(src, mipIndex, x, width, y, height, z, depth, dstFormat, &asyncRequestNativeArrayData);
			result.SetScriptingCallback(callback);
			return result;
		}

		// Token: 0x06002188 RID: 8584 RVA: 0x00037CC4 File Offset: 0x00035EC4
		public unsafe static AsyncGPUReadbackRequest RequestIntoNativeSlice<T>(ref NativeSlice<T> output, ComputeBuffer src, Action<AsyncGPUReadbackRequest> callback = null) where T : struct
		{
			AsyncRequestNativeArrayData asyncRequestNativeArrayData = AsyncRequestNativeArrayData.CreateAndCheckAccess<T>(output);
			AsyncGPUReadbackRequest result = AsyncGPUReadback.Request_Internal_ComputeBuffer_1(src, &asyncRequestNativeArrayData);
			result.SetScriptingCallback(callback);
			return result;
		}

		// Token: 0x06002189 RID: 8585 RVA: 0x00037CF8 File Offset: 0x00035EF8
		public unsafe static AsyncGPUReadbackRequest RequestIntoNativeSlice<T>(ref NativeSlice<T> output, ComputeBuffer src, int size, int offset, Action<AsyncGPUReadbackRequest> callback = null) where T : struct
		{
			AsyncRequestNativeArrayData asyncRequestNativeArrayData = AsyncRequestNativeArrayData.CreateAndCheckAccess<T>(output);
			AsyncGPUReadbackRequest result = AsyncGPUReadback.Request_Internal_ComputeBuffer_2(src, size, offset, &asyncRequestNativeArrayData);
			result.SetScriptingCallback(callback);
			return result;
		}

		// Token: 0x0600218A RID: 8586 RVA: 0x00037D30 File Offset: 0x00035F30
		public unsafe static AsyncGPUReadbackRequest RequestIntoNativeSlice<T>(ref NativeSlice<T> output, GraphicsBuffer src, Action<AsyncGPUReadbackRequest> callback = null) where T : struct
		{
			AsyncRequestNativeArrayData asyncRequestNativeArrayData = AsyncRequestNativeArrayData.CreateAndCheckAccess<T>(output);
			AsyncGPUReadbackRequest result = AsyncGPUReadback.Request_Internal_GraphicsBuffer_1(src, &asyncRequestNativeArrayData);
			result.SetScriptingCallback(callback);
			return result;
		}

		// Token: 0x0600218B RID: 8587 RVA: 0x00037D64 File Offset: 0x00035F64
		public unsafe static AsyncGPUReadbackRequest RequestIntoNativeSlice<T>(ref NativeSlice<T> output, GraphicsBuffer src, int size, int offset, Action<AsyncGPUReadbackRequest> callback = null) where T : struct
		{
			AsyncRequestNativeArrayData asyncRequestNativeArrayData = AsyncRequestNativeArrayData.CreateAndCheckAccess<T>(output);
			AsyncGPUReadbackRequest result = AsyncGPUReadback.Request_Internal_GraphicsBuffer_2(src, size, offset, &asyncRequestNativeArrayData);
			result.SetScriptingCallback(callback);
			return result;
		}

		// Token: 0x0600218C RID: 8588 RVA: 0x00037D9C File Offset: 0x00035F9C
		public unsafe static AsyncGPUReadbackRequest RequestIntoNativeSlice<T>(ref NativeSlice<T> output, Texture src, int mipIndex = 0, Action<AsyncGPUReadbackRequest> callback = null) where T : struct
		{
			AsyncRequestNativeArrayData asyncRequestNativeArrayData = AsyncRequestNativeArrayData.CreateAndCheckAccess<T>(output);
			AsyncGPUReadbackRequest result = AsyncGPUReadback.Request_Internal_Texture_1(src, mipIndex, &asyncRequestNativeArrayData);
			result.SetScriptingCallback(callback);
			return result;
		}

		// Token: 0x0600218D RID: 8589 RVA: 0x00037DD0 File Offset: 0x00035FD0
		public static AsyncGPUReadbackRequest RequestIntoNativeSlice<T>(ref NativeSlice<T> output, Texture src, int mipIndex, TextureFormat dstFormat, Action<AsyncGPUReadbackRequest> callback = null) where T : struct
		{
			return AsyncGPUReadback.RequestIntoNativeSlice<T>(ref output, src, mipIndex, GraphicsFormatUtility.GetGraphicsFormat(dstFormat, QualitySettings.activeColorSpace == ColorSpace.Linear), callback);
		}

		// Token: 0x0600218E RID: 8590 RVA: 0x00037DFC File Offset: 0x00035FFC
		public unsafe static AsyncGPUReadbackRequest RequestIntoNativeSlice<T>(ref NativeSlice<T> output, Texture src, int mipIndex, GraphicsFormat dstFormat, Action<AsyncGPUReadbackRequest> callback = null) where T : struct
		{
			AsyncGPUReadback.ValidateFormat(src, dstFormat);
			AsyncRequestNativeArrayData asyncRequestNativeArrayData = AsyncRequestNativeArrayData.CreateAndCheckAccess<T>(output);
			AsyncGPUReadbackRequest result = AsyncGPUReadback.Request_Internal_Texture_2(src, mipIndex, dstFormat, &asyncRequestNativeArrayData);
			result.SetScriptingCallback(callback);
			return result;
		}

		// Token: 0x0600218F RID: 8591 RVA: 0x00037E3C File Offset: 0x0003603C
		public static AsyncGPUReadbackRequest RequestIntoNativeSlice<T>(ref NativeSlice<T> output, Texture src, int mipIndex, int x, int width, int y, int height, int z, int depth, TextureFormat dstFormat, Action<AsyncGPUReadbackRequest> callback = null) where T : struct
		{
			return AsyncGPUReadback.RequestIntoNativeSlice<T>(ref output, src, mipIndex, x, width, y, height, z, depth, GraphicsFormatUtility.GetGraphicsFormat(dstFormat, QualitySettings.activeColorSpace == ColorSpace.Linear), callback);
		}

		// Token: 0x06002190 RID: 8592 RVA: 0x00037E74 File Offset: 0x00036074
		public unsafe static AsyncGPUReadbackRequest RequestIntoNativeSlice<T>(ref NativeSlice<T> output, Texture src, int mipIndex, int x, int width, int y, int height, int z, int depth, GraphicsFormat dstFormat, Action<AsyncGPUReadbackRequest> callback = null) where T : struct
		{
			AsyncGPUReadback.ValidateFormat(src, dstFormat);
			AsyncRequestNativeArrayData asyncRequestNativeArrayData = AsyncRequestNativeArrayData.CreateAndCheckAccess<T>(output);
			AsyncGPUReadbackRequest result = AsyncGPUReadback.Request_Internal_Texture_4(src, mipIndex, x, width, y, height, z, depth, dstFormat, &asyncRequestNativeArrayData);
			result.SetScriptingCallback(callback);
			return result;
		}

		// Token: 0x06002191 RID: 8593 RVA: 0x00037EC0 File Offset: 0x000360C0
		[NativeMethod("Request")]
		private unsafe static AsyncGPUReadbackRequest Request_Internal_ComputeBuffer_1([NotNull("ArgumentNullException")] ComputeBuffer buffer, AsyncRequestNativeArrayData* data)
		{
			AsyncGPUReadbackRequest result;
			AsyncGPUReadback.Request_Internal_ComputeBuffer_1_Injected(buffer, data, out result);
			return result;
		}

		// Token: 0x06002192 RID: 8594 RVA: 0x00037ED8 File Offset: 0x000360D8
		[NativeMethod("Request")]
		private unsafe static AsyncGPUReadbackRequest Request_Internal_ComputeBuffer_2([NotNull("ArgumentNullException")] ComputeBuffer src, int size, int offset, AsyncRequestNativeArrayData* data)
		{
			AsyncGPUReadbackRequest result;
			AsyncGPUReadback.Request_Internal_ComputeBuffer_2_Injected(src, size, offset, data, out result);
			return result;
		}

		// Token: 0x06002193 RID: 8595 RVA: 0x00037EF4 File Offset: 0x000360F4
		[NativeMethod("Request")]
		private unsafe static AsyncGPUReadbackRequest Request_Internal_GraphicsBuffer_1([NotNull("ArgumentNullException")] GraphicsBuffer buffer, AsyncRequestNativeArrayData* data)
		{
			AsyncGPUReadbackRequest result;
			AsyncGPUReadback.Request_Internal_GraphicsBuffer_1_Injected(buffer, data, out result);
			return result;
		}

		// Token: 0x06002194 RID: 8596 RVA: 0x00037F0C File Offset: 0x0003610C
		[NativeMethod("Request")]
		private unsafe static AsyncGPUReadbackRequest Request_Internal_GraphicsBuffer_2([NotNull("ArgumentNullException")] GraphicsBuffer src, int size, int offset, AsyncRequestNativeArrayData* data)
		{
			AsyncGPUReadbackRequest result;
			AsyncGPUReadback.Request_Internal_GraphicsBuffer_2_Injected(src, size, offset, data, out result);
			return result;
		}

		// Token: 0x06002195 RID: 8597 RVA: 0x00037F28 File Offset: 0x00036128
		[NativeMethod("Request")]
		private unsafe static AsyncGPUReadbackRequest Request_Internal_Texture_1([NotNull("ArgumentNullException")] Texture src, int mipIndex, AsyncRequestNativeArrayData* data)
		{
			AsyncGPUReadbackRequest result;
			AsyncGPUReadback.Request_Internal_Texture_1_Injected(src, mipIndex, data, out result);
			return result;
		}

		// Token: 0x06002196 RID: 8598 RVA: 0x00037F40 File Offset: 0x00036140
		[NativeMethod("Request")]
		private unsafe static AsyncGPUReadbackRequest Request_Internal_Texture_2([NotNull("ArgumentNullException")] Texture src, int mipIndex, GraphicsFormat dstFormat, AsyncRequestNativeArrayData* data)
		{
			AsyncGPUReadbackRequest result;
			AsyncGPUReadback.Request_Internal_Texture_2_Injected(src, mipIndex, dstFormat, data, out result);
			return result;
		}

		// Token: 0x06002197 RID: 8599 RVA: 0x00037F5C File Offset: 0x0003615C
		[NativeMethod("Request")]
		private unsafe static AsyncGPUReadbackRequest Request_Internal_Texture_3([NotNull("ArgumentNullException")] Texture src, int mipIndex, int x, int width, int y, int height, int z, int depth, AsyncRequestNativeArrayData* data)
		{
			AsyncGPUReadbackRequest result;
			AsyncGPUReadback.Request_Internal_Texture_3_Injected(src, mipIndex, x, width, y, height, z, depth, data, out result);
			return result;
		}

		// Token: 0x06002198 RID: 8600 RVA: 0x00037F80 File Offset: 0x00036180
		[NativeMethod("Request")]
		private unsafe static AsyncGPUReadbackRequest Request_Internal_Texture_4([NotNull("ArgumentNullException")] Texture src, int mipIndex, int x, int width, int y, int height, int z, int depth, GraphicsFormat dstFormat, AsyncRequestNativeArrayData* data)
		{
			AsyncGPUReadbackRequest result;
			AsyncGPUReadback.Request_Internal_Texture_4_Injected(src, mipIndex, x, width, y, height, z, depth, dstFormat, data, out result);
			return result;
		}

		// Token: 0x06002199 RID: 8601
		[MethodImpl(MethodImplOptions.InternalCall)]
		private unsafe static extern void Request_Internal_ComputeBuffer_1_Injected(ComputeBuffer buffer, AsyncRequestNativeArrayData* data, out AsyncGPUReadbackRequest ret);

		// Token: 0x0600219A RID: 8602
		[MethodImpl(MethodImplOptions.InternalCall)]
		private unsafe static extern void Request_Internal_ComputeBuffer_2_Injected(ComputeBuffer src, int size, int offset, AsyncRequestNativeArrayData* data, out AsyncGPUReadbackRequest ret);

		// Token: 0x0600219B RID: 8603
		[MethodImpl(MethodImplOptions.InternalCall)]
		private unsafe static extern void Request_Internal_GraphicsBuffer_1_Injected(GraphicsBuffer buffer, AsyncRequestNativeArrayData* data, out AsyncGPUReadbackRequest ret);

		// Token: 0x0600219C RID: 8604
		[MethodImpl(MethodImplOptions.InternalCall)]
		private unsafe static extern void Request_Internal_GraphicsBuffer_2_Injected(GraphicsBuffer src, int size, int offset, AsyncRequestNativeArrayData* data, out AsyncGPUReadbackRequest ret);

		// Token: 0x0600219D RID: 8605
		[MethodImpl(MethodImplOptions.InternalCall)]
		private unsafe static extern void Request_Internal_Texture_1_Injected(Texture src, int mipIndex, AsyncRequestNativeArrayData* data, out AsyncGPUReadbackRequest ret);

		// Token: 0x0600219E RID: 8606
		[MethodImpl(MethodImplOptions.InternalCall)]
		private unsafe static extern void Request_Internal_Texture_2_Injected(Texture src, int mipIndex, GraphicsFormat dstFormat, AsyncRequestNativeArrayData* data, out AsyncGPUReadbackRequest ret);

		// Token: 0x0600219F RID: 8607
		[MethodImpl(MethodImplOptions.InternalCall)]
		private unsafe static extern void Request_Internal_Texture_3_Injected(Texture src, int mipIndex, int x, int width, int y, int height, int z, int depth, AsyncRequestNativeArrayData* data, out AsyncGPUReadbackRequest ret);

		// Token: 0x060021A0 RID: 8608
		[MethodImpl(MethodImplOptions.InternalCall)]
		private unsafe static extern void Request_Internal_Texture_4_Injected(Texture src, int mipIndex, int x, int width, int y, int height, int z, int depth, GraphicsFormat dstFormat, AsyncRequestNativeArrayData* data, out AsyncGPUReadbackRequest ret);
	}
}
