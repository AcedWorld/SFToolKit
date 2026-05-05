using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Profiling;
using UnityEngine.Bindings;
using UnityEngine.Rendering;
using UnityEngine.Scripting;

namespace UnityEngine.UIElements.UIR
{
	// Token: 0x02000421 RID: 1057
	[VisibleToOtherModules(new string[]
	{
		"Unity.UIElements"
	})]
	[NativeHeader("ModuleOverrides/com.unity.ui/Core/Native/Renderer/UIRendererUtility.h")]
	internal class Utility
	{
		// Token: 0x06002193 RID: 8595 RVA: 0x0007F098 File Offset: 0x0007D298
		public static void SetVectorArray<T>(MaterialPropertyBlock props, int name, NativeSlice<T> vector4s) where T : struct
		{
			int count = vector4s.Length * vector4s.Stride / 16;
			Utility.SetVectorArray(props, name, new IntPtr(vector4s.GetUnsafePtr<T>()), count);
		}

		// Token: 0x14000042 RID: 66
		// (add) Token: 0x06002194 RID: 8596 RVA: 0x0007F0D0 File Offset: 0x0007D2D0
		// (remove) Token: 0x06002195 RID: 8597 RVA: 0x0007F104 File Offset: 0x0007D304
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event Action<bool> GraphicsResourcesRecreate;

		// Token: 0x14000043 RID: 67
		// (add) Token: 0x06002196 RID: 8598 RVA: 0x0007F138 File Offset: 0x0007D338
		// (remove) Token: 0x06002197 RID: 8599 RVA: 0x0007F16C File Offset: 0x0007D36C
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event Action EngineUpdate;

		// Token: 0x14000044 RID: 68
		// (add) Token: 0x06002198 RID: 8600 RVA: 0x0007F1A0 File Offset: 0x0007D3A0
		// (remove) Token: 0x06002199 RID: 8601 RVA: 0x0007F1D4 File Offset: 0x0007D3D4
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event Action FlushPendingResources;

		// Token: 0x14000045 RID: 69
		// (add) Token: 0x0600219A RID: 8602 RVA: 0x0007F208 File Offset: 0x0007D408
		// (remove) Token: 0x0600219B RID: 8603 RVA: 0x0007F23C File Offset: 0x0007D43C
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event Action<Camera> RegisterIntermediateRenderers;

		// Token: 0x14000046 RID: 70
		// (add) Token: 0x0600219C RID: 8604 RVA: 0x0007F270 File Offset: 0x0007D470
		// (remove) Token: 0x0600219D RID: 8605 RVA: 0x0007F2A4 File Offset: 0x0007D4A4
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event Action<IntPtr> RenderNodeAdd;

		// Token: 0x14000047 RID: 71
		// (add) Token: 0x0600219E RID: 8606 RVA: 0x0007F2D8 File Offset: 0x0007D4D8
		// (remove) Token: 0x0600219F RID: 8607 RVA: 0x0007F30C File Offset: 0x0007D50C
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event Action<IntPtr> RenderNodeExecute;

		// Token: 0x14000048 RID: 72
		// (add) Token: 0x060021A0 RID: 8608 RVA: 0x0007F340 File Offset: 0x0007D540
		// (remove) Token: 0x060021A1 RID: 8609 RVA: 0x0007F374 File Offset: 0x0007D574
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public static event Action<IntPtr> RenderNodeCleanup;

		// Token: 0x060021A2 RID: 8610 RVA: 0x0007F3A7 File Offset: 0x0007D5A7
		[RequiredByNativeCode]
		internal static void RaiseGraphicsResourcesRecreate(bool recreate)
		{
			Action<bool> graphicsResourcesRecreate = Utility.GraphicsResourcesRecreate;
			if (graphicsResourcesRecreate != null)
			{
				graphicsResourcesRecreate(recreate);
			}
		}

		// Token: 0x060021A3 RID: 8611 RVA: 0x0007F3BC File Offset: 0x0007D5BC
		[RequiredByNativeCode]
		internal static void RaiseEngineUpdate()
		{
			bool flag = Utility.EngineUpdate != null;
			if (flag)
			{
				Utility.EngineUpdate();
			}
		}

		// Token: 0x060021A4 RID: 8612 RVA: 0x0007F3E3 File Offset: 0x0007D5E3
		[RequiredByNativeCode]
		internal static void RaiseFlushPendingResources()
		{
			Action flushPendingResources = Utility.FlushPendingResources;
			if (flushPendingResources != null)
			{
				flushPendingResources();
			}
		}

		// Token: 0x060021A5 RID: 8613 RVA: 0x0007F3F7 File Offset: 0x0007D5F7
		[RequiredByNativeCode]
		internal static void RaiseRegisterIntermediateRenderers(Camera camera)
		{
			Action<Camera> registerIntermediateRenderers = Utility.RegisterIntermediateRenderers;
			if (registerIntermediateRenderers != null)
			{
				registerIntermediateRenderers(camera);
			}
		}

		// Token: 0x060021A6 RID: 8614 RVA: 0x0007F40C File Offset: 0x0007D60C
		[RequiredByNativeCode]
		internal static void RaiseRenderNodeAdd(IntPtr userData)
		{
			Action<IntPtr> renderNodeAdd = Utility.RenderNodeAdd;
			if (renderNodeAdd != null)
			{
				renderNodeAdd(userData);
			}
		}

		// Token: 0x060021A7 RID: 8615 RVA: 0x0007F421 File Offset: 0x0007D621
		[RequiredByNativeCode]
		internal static void RaiseRenderNodeExecute(IntPtr userData)
		{
			Action<IntPtr> renderNodeExecute = Utility.RenderNodeExecute;
			if (renderNodeExecute != null)
			{
				renderNodeExecute(userData);
			}
		}

		// Token: 0x060021A8 RID: 8616 RVA: 0x0007F436 File Offset: 0x0007D636
		[RequiredByNativeCode]
		internal static void RaiseRenderNodeCleanup(IntPtr userData)
		{
			Action<IntPtr> renderNodeCleanup = Utility.RenderNodeCleanup;
			if (renderNodeCleanup != null)
			{
				renderNodeCleanup(userData);
			}
		}

		// Token: 0x060021A9 RID: 8617
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr AllocateBuffer(int elementCount, int elementStride, bool vertexBuffer);

		// Token: 0x060021AA RID: 8618
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void FreeBuffer(IntPtr buffer);

		// Token: 0x060021AB RID: 8619
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void UpdateBufferRanges(IntPtr buffer, IntPtr ranges, int rangeCount, int writeRangeStart, int writeRangeEnd);

		// Token: 0x060021AC RID: 8620
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetVectorArray(MaterialPropertyBlock props, int name, IntPtr vector4s, int count);

		// Token: 0x060021AD RID: 8621
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr GetVertexDeclaration(VertexAttributeDescriptor[] vertexAttributes);

		// Token: 0x060021AE RID: 8622 RVA: 0x0007F44C File Offset: 0x0007D64C
		public static void RegisterIntermediateRenderer(Camera camera, Material material, Matrix4x4 transform, Bounds aabb, int renderLayer, int shadowCasting, bool receiveShadows, int sameDistanceSortPriority, ulong sceneCullingMask, int rendererCallbackFlags, IntPtr userData, int userDataSize)
		{
			Utility.RegisterIntermediateRenderer_Injected(camera, material, ref transform, ref aabb, renderLayer, shadowCasting, receiveShadows, sameDistanceSortPriority, sceneCullingMask, rendererCallbackFlags, userData, userDataSize);
		}

		// Token: 0x060021AF RID: 8623
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public unsafe static extern void DrawRanges(IntPtr ib, IntPtr* vertexStreams, int streamCount, IntPtr ranges, int rangeCount, IntPtr vertexDecl);

		// Token: 0x060021B0 RID: 8624
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void SetPropertyBlock(MaterialPropertyBlock props);

		// Token: 0x060021B1 RID: 8625 RVA: 0x0007F474 File Offset: 0x0007D674
		[ThreadSafe]
		public static void SetScissorRect(RectInt scissorRect)
		{
			Utility.SetScissorRect_Injected(ref scissorRect);
		}

		// Token: 0x060021B2 RID: 8626
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void DisableScissor();

		// Token: 0x060021B3 RID: 8627
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool IsScissorEnabled();

		// Token: 0x060021B4 RID: 8628 RVA: 0x0007F47D File Offset: 0x0007D67D
		[ThreadSafe]
		public static IntPtr CreateStencilState(StencilState stencilState)
		{
			return Utility.CreateStencilState_Injected(ref stencilState);
		}

		// Token: 0x060021B5 RID: 8629
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void SetStencilState(IntPtr stencilState, int stencilRef);

		// Token: 0x060021B6 RID: 8630
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool HasMappedBufferRange();

		// Token: 0x060021B7 RID: 8631
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern uint InsertCPUFence();

		// Token: 0x060021B8 RID: 8632
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool CPUFencePassed(uint fence);

		// Token: 0x060021B9 RID: 8633
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void WaitForCPUFencePassed(uint fence);

		// Token: 0x060021BA RID: 8634
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void SyncRenderThread();

		// Token: 0x060021BB RID: 8635 RVA: 0x0007F488 File Offset: 0x0007D688
		[ThreadSafe]
		public static RectInt GetActiveViewport()
		{
			RectInt result;
			Utility.GetActiveViewport_Injected(out result);
			return result;
		}

		// Token: 0x060021BC RID: 8636
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void ProfileDrawChainBegin();

		// Token: 0x060021BD RID: 8637
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void ProfileDrawChainEnd();

		// Token: 0x060021BE RID: 8638
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void NotifyOfUIREvents(bool subscribe);

		// Token: 0x060021BF RID: 8639 RVA: 0x0007F4A0 File Offset: 0x0007D6A0
		[ThreadSafe]
		public static Matrix4x4 GetUnityProjectionMatrix()
		{
			Matrix4x4 result;
			Utility.GetUnityProjectionMatrix_Injected(out result);
			return result;
		}

		// Token: 0x060021C0 RID: 8640 RVA: 0x0007F4B8 File Offset: 0x0007D6B8
		[ThreadSafe]
		public static Matrix4x4 GetDeviceProjectionMatrix()
		{
			Matrix4x4 result;
			Utility.GetDeviceProjectionMatrix_Injected(out result);
			return result;
		}

		// Token: 0x060021C1 RID: 8641
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern bool DebugIsMainThread();

		// Token: 0x060021C4 RID: 8644
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void RegisterIntermediateRenderer_Injected(Camera camera, Material material, ref Matrix4x4 transform, ref Bounds aabb, int renderLayer, int shadowCasting, bool receiveShadows, int sameDistanceSortPriority, ulong sceneCullingMask, int rendererCallbackFlags, IntPtr userData, int userDataSize);

		// Token: 0x060021C5 RID: 8645
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetScissorRect_Injected(ref RectInt scissorRect);

		// Token: 0x060021C6 RID: 8646
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr CreateStencilState_Injected(ref StencilState stencilState);

		// Token: 0x060021C7 RID: 8647
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetActiveViewport_Injected(out RectInt ret);

		// Token: 0x060021C8 RID: 8648
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetUnityProjectionMatrix_Injected(out Matrix4x4 ret);

		// Token: 0x060021C9 RID: 8649
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void GetDeviceProjectionMatrix_Injected(out Matrix4x4 ret);

		// Token: 0x04000E58 RID: 3672
		private static ProfilerMarker s_MarkerRaiseEngineUpdate = new ProfilerMarker("UIR.RaiseEngineUpdate");

		// Token: 0x02000422 RID: 1058
		[Flags]
		internal enum RendererCallbacks
		{
			// Token: 0x04000E5A RID: 3674
			RendererCallback_Init = 1,
			// Token: 0x04000E5B RID: 3675
			RendererCallback_Exec = 2,
			// Token: 0x04000E5C RID: 3676
			RendererCallback_Cleanup = 4
		}

		// Token: 0x02000423 RID: 1059
		internal enum GPUBufferType
		{
			// Token: 0x04000E5E RID: 3678
			Vertex,
			// Token: 0x04000E5F RID: 3679
			Index
		}

		// Token: 0x02000424 RID: 1060
		public class GPUBuffer<T> : IDisposable where T : struct
		{
			// Token: 0x060021CA RID: 8650 RVA: 0x0007F4DE File Offset: 0x0007D6DE
			public GPUBuffer(int elementCount, Utility.GPUBufferType type)
			{
				this.elemCount = elementCount;
				this.elemStride = UnsafeUtility.SizeOf<T>();
				this.buffer = Utility.AllocateBuffer(elementCount, this.elemStride, type == Utility.GPUBufferType.Vertex);
			}

			// Token: 0x060021CB RID: 8651 RVA: 0x0007F510 File Offset: 0x0007D710
			public void Dispose()
			{
				Utility.FreeBuffer(this.buffer);
			}

			// Token: 0x060021CC RID: 8652 RVA: 0x0007F51F File Offset: 0x0007D71F
			public void UpdateRanges(NativeSlice<GfxUpdateBufferRange> ranges, int rangesMin, int rangesMax)
			{
				Utility.UpdateBufferRanges(this.buffer, new IntPtr(ranges.GetUnsafePtr<GfxUpdateBufferRange>()), ranges.Length, rangesMin, rangesMax);
			}

			// Token: 0x170007BF RID: 1983
			// (get) Token: 0x060021CD RID: 8653 RVA: 0x0007F544 File Offset: 0x0007D744
			public int ElementStride
			{
				get
				{
					return this.elemStride;
				}
			}

			// Token: 0x170007C0 RID: 1984
			// (get) Token: 0x060021CE RID: 8654 RVA: 0x0007F55C File Offset: 0x0007D75C
			public int Count
			{
				get
				{
					return this.elemCount;
				}
			}

			// Token: 0x170007C1 RID: 1985
			// (get) Token: 0x060021CF RID: 8655 RVA: 0x0007F574 File Offset: 0x0007D774
			internal IntPtr BufferPointer
			{
				get
				{
					return this.buffer;
				}
			}

			// Token: 0x04000E60 RID: 3680
			private IntPtr buffer;

			// Token: 0x04000E61 RID: 3681
			private int elemCount;

			// Token: 0x04000E62 RID: 3682
			private int elemStride;
		}
	}
}
