using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine.Bindings;

namespace UnityEngine.Rendering
{
	// Token: 0x02000453 RID: 1107
	[NativeHeader("Runtime/Scripting/ScriptingCommonStructDefinitions.h")]
	[NativeHeader("Runtime/Export/RenderPipeline/ScriptableRenderPipeline.bindings.h")]
	[NativeHeader("Runtime/Graphics/ScriptableRenderLoop/ScriptableCulling.h")]
	public struct CullingResults : IEquatable<CullingResults>
	{
		// Token: 0x06002516 RID: 9494
		[FreeFunction("ScriptableRenderPipeline_Bindings::GetLightIndexCount")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetLightIndexCount(IntPtr cullingResultsPtr);

		// Token: 0x06002517 RID: 9495
		[FreeFunction("ScriptableRenderPipeline_Bindings::GetReflectionProbeIndexCount")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetReflectionProbeIndexCount(IntPtr cullingResultsPtr);

		// Token: 0x06002518 RID: 9496
		[FreeFunction("FillLightAndReflectionProbeIndices")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void FillLightAndReflectionProbeIndices(IntPtr cullingResultsPtr, ComputeBuffer computeBuffer);

		// Token: 0x06002519 RID: 9497
		[FreeFunction("FillLightAndReflectionProbeIndices")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void FillLightAndReflectionProbeIndicesGraphicsBuffer(IntPtr cullingResultsPtr, GraphicsBuffer buffer);

		// Token: 0x0600251A RID: 9498
		[FreeFunction("GetLightIndexMapSize")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetLightIndexMapSize(IntPtr cullingResultsPtr);

		// Token: 0x0600251B RID: 9499
		[FreeFunction("GetReflectionProbeIndexMapSize")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern int GetReflectionProbeIndexMapSize(IntPtr cullingResultsPtr);

		// Token: 0x0600251C RID: 9500
		[FreeFunction("FillLightIndexMapScriptable")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void FillLightIndexMap(IntPtr cullingResultsPtr, IntPtr indexMapPtr, int indexMapSize);

		// Token: 0x0600251D RID: 9501
		[FreeFunction("FillReflectionProbeIndexMapScriptable")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void FillReflectionProbeIndexMap(IntPtr cullingResultsPtr, IntPtr indexMapPtr, int indexMapSize);

		// Token: 0x0600251E RID: 9502
		[FreeFunction("SetLightIndexMapScriptable")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetLightIndexMap(IntPtr cullingResultsPtr, IntPtr indexMapPtr, int indexMapSize);

		// Token: 0x0600251F RID: 9503
		[FreeFunction("SetReflectionProbeIndexMapScriptable")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void SetReflectionProbeIndexMap(IntPtr cullingResultsPtr, IntPtr indexMapPtr, int indexMapSize);

		// Token: 0x06002520 RID: 9504
		[FreeFunction("ScriptableRenderPipeline_Bindings::GetShadowCasterBounds")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool GetShadowCasterBounds(IntPtr cullingResultsPtr, int lightIndex, out Bounds bounds);

		// Token: 0x06002521 RID: 9505
		[FreeFunction("ScriptableRenderPipeline_Bindings::ComputeSpotShadowMatricesAndCullingPrimitives")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool ComputeSpotShadowMatricesAndCullingPrimitives(IntPtr cullingResultsPtr, int activeLightIndex, out Matrix4x4 viewMatrix, out Matrix4x4 projMatrix, out ShadowSplitData shadowSplitData);

		// Token: 0x06002522 RID: 9506
		[FreeFunction("ScriptableRenderPipeline_Bindings::ComputePointShadowMatricesAndCullingPrimitives")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool ComputePointShadowMatricesAndCullingPrimitives(IntPtr cullingResultsPtr, int activeLightIndex, CubemapFace cubemapFace, float fovBias, out Matrix4x4 viewMatrix, out Matrix4x4 projMatrix, out ShadowSplitData shadowSplitData);

		// Token: 0x06002523 RID: 9507 RVA: 0x0003F24C File Offset: 0x0003D44C
		[FreeFunction("ScriptableRenderPipeline_Bindings::ComputeDirectionalShadowMatricesAndCullingPrimitives")]
		private static bool ComputeDirectionalShadowMatricesAndCullingPrimitives(IntPtr cullingResultsPtr, int activeLightIndex, int splitIndex, int splitCount, Vector3 splitRatio, int shadowResolution, float shadowNearPlaneOffset, out Matrix4x4 viewMatrix, out Matrix4x4 projMatrix, out ShadowSplitData shadowSplitData)
		{
			return CullingResults.ComputeDirectionalShadowMatricesAndCullingPrimitives_Injected(cullingResultsPtr, activeLightIndex, splitIndex, splitCount, ref splitRatio, shadowResolution, shadowNearPlaneOffset, out viewMatrix, out projMatrix, out shadowSplitData);
		}

		// Token: 0x170006B4 RID: 1716
		// (get) Token: 0x06002524 RID: 9508 RVA: 0x0003F26E File Offset: 0x0003D46E
		public unsafe NativeArray<VisibleLight> visibleLights
		{
			get
			{
				return this.GetNativeArray<VisibleLight>((void*)this.m_AllocationInfo->visibleLightsPtr, this.m_AllocationInfo->visibleLightCount);
			}
		}

		// Token: 0x170006B5 RID: 1717
		// (get) Token: 0x06002525 RID: 9509 RVA: 0x0003F28C File Offset: 0x0003D48C
		public unsafe NativeArray<VisibleLight> visibleOffscreenVertexLights
		{
			get
			{
				return this.GetNativeArray<VisibleLight>((void*)this.m_AllocationInfo->visibleOffscreenVertexLightsPtr, this.m_AllocationInfo->visibleOffscreenVertexLightCount);
			}
		}

		// Token: 0x170006B6 RID: 1718
		// (get) Token: 0x06002526 RID: 9510 RVA: 0x0003F2AA File Offset: 0x0003D4AA
		public unsafe NativeArray<VisibleReflectionProbe> visibleReflectionProbes
		{
			get
			{
				return this.GetNativeArray<VisibleReflectionProbe>((void*)this.m_AllocationInfo->visibleReflectionProbesPtr, this.m_AllocationInfo->visibleReflectionProbeCount);
			}
		}

		// Token: 0x06002527 RID: 9511 RVA: 0x0003F2C8 File Offset: 0x0003D4C8
		private unsafe NativeArray<T> GetNativeArray<T>(void* dataPointer, int length) where T : struct
		{
			return NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<T>(dataPointer, length, Allocator.Invalid);
		}

		// Token: 0x170006B7 RID: 1719
		// (get) Token: 0x06002528 RID: 9512 RVA: 0x0003F2E4 File Offset: 0x0003D4E4
		public int lightIndexCount
		{
			get
			{
				return CullingResults.GetLightIndexCount(this.ptr);
			}
		}

		// Token: 0x170006B8 RID: 1720
		// (get) Token: 0x06002529 RID: 9513 RVA: 0x0003F304 File Offset: 0x0003D504
		public int reflectionProbeIndexCount
		{
			get
			{
				return CullingResults.GetReflectionProbeIndexCount(this.ptr);
			}
		}

		// Token: 0x170006B9 RID: 1721
		// (get) Token: 0x0600252A RID: 9514 RVA: 0x0003F324 File Offset: 0x0003D524
		public int lightAndReflectionProbeIndexCount
		{
			get
			{
				return CullingResults.GetLightIndexCount(this.ptr) + CullingResults.GetReflectionProbeIndexCount(this.ptr);
			}
		}

		// Token: 0x0600252B RID: 9515 RVA: 0x0003F34D File Offset: 0x0003D54D
		public void FillLightAndReflectionProbeIndices(ComputeBuffer computeBuffer)
		{
			CullingResults.FillLightAndReflectionProbeIndices(this.ptr, computeBuffer);
		}

		// Token: 0x0600252C RID: 9516 RVA: 0x0003F35D File Offset: 0x0003D55D
		public void FillLightAndReflectionProbeIndices(GraphicsBuffer buffer)
		{
			CullingResults.FillLightAndReflectionProbeIndicesGraphicsBuffer(this.ptr, buffer);
		}

		// Token: 0x0600252D RID: 9517 RVA: 0x0003F370 File Offset: 0x0003D570
		public NativeArray<int> GetLightIndexMap(Allocator allocator)
		{
			int lightIndexMapSize = CullingResults.GetLightIndexMapSize(this.ptr);
			NativeArray<int> nativeArray = new NativeArray<int>(lightIndexMapSize, allocator, NativeArrayOptions.UninitializedMemory);
			CullingResults.FillLightIndexMap(this.ptr, (IntPtr)nativeArray.GetUnsafePtr<int>(), lightIndexMapSize);
			return nativeArray;
		}

		// Token: 0x0600252E RID: 9518 RVA: 0x0003F3B1 File Offset: 0x0003D5B1
		public void SetLightIndexMap(NativeArray<int> lightIndexMap)
		{
			CullingResults.SetLightIndexMap(this.ptr, (IntPtr)lightIndexMap.GetUnsafeReadOnlyPtr<int>(), lightIndexMap.Length);
		}

		// Token: 0x0600252F RID: 9519 RVA: 0x0003F3D4 File Offset: 0x0003D5D4
		public NativeArray<int> GetReflectionProbeIndexMap(Allocator allocator)
		{
			int reflectionProbeIndexMapSize = CullingResults.GetReflectionProbeIndexMapSize(this.ptr);
			NativeArray<int> nativeArray = new NativeArray<int>(reflectionProbeIndexMapSize, allocator, NativeArrayOptions.UninitializedMemory);
			CullingResults.FillReflectionProbeIndexMap(this.ptr, (IntPtr)nativeArray.GetUnsafePtr<int>(), reflectionProbeIndexMapSize);
			return nativeArray;
		}

		// Token: 0x06002530 RID: 9520 RVA: 0x0003F415 File Offset: 0x0003D615
		public void SetReflectionProbeIndexMap(NativeArray<int> lightIndexMap)
		{
			CullingResults.SetReflectionProbeIndexMap(this.ptr, (IntPtr)lightIndexMap.GetUnsafeReadOnlyPtr<int>(), lightIndexMap.Length);
		}

		// Token: 0x06002531 RID: 9521 RVA: 0x0003F438 File Offset: 0x0003D638
		public bool GetShadowCasterBounds(int lightIndex, out Bounds outBounds)
		{
			return CullingResults.GetShadowCasterBounds(this.ptr, lightIndex, out outBounds);
		}

		// Token: 0x06002532 RID: 9522 RVA: 0x0003F458 File Offset: 0x0003D658
		public bool ComputeSpotShadowMatricesAndCullingPrimitives(int activeLightIndex, out Matrix4x4 viewMatrix, out Matrix4x4 projMatrix, out ShadowSplitData shadowSplitData)
		{
			return CullingResults.ComputeSpotShadowMatricesAndCullingPrimitives(this.ptr, activeLightIndex, out viewMatrix, out projMatrix, out shadowSplitData);
		}

		// Token: 0x06002533 RID: 9523 RVA: 0x0003F47C File Offset: 0x0003D67C
		public bool ComputePointShadowMatricesAndCullingPrimitives(int activeLightIndex, CubemapFace cubemapFace, float fovBias, out Matrix4x4 viewMatrix, out Matrix4x4 projMatrix, out ShadowSplitData shadowSplitData)
		{
			return CullingResults.ComputePointShadowMatricesAndCullingPrimitives(this.ptr, activeLightIndex, cubemapFace, fovBias, out viewMatrix, out projMatrix, out shadowSplitData);
		}

		// Token: 0x06002534 RID: 9524 RVA: 0x0003F4A4 File Offset: 0x0003D6A4
		public bool ComputeDirectionalShadowMatricesAndCullingPrimitives(int activeLightIndex, int splitIndex, int splitCount, Vector3 splitRatio, int shadowResolution, float shadowNearPlaneOffset, out Matrix4x4 viewMatrix, out Matrix4x4 projMatrix, out ShadowSplitData shadowSplitData)
		{
			return CullingResults.ComputeDirectionalShadowMatricesAndCullingPrimitives(this.ptr, activeLightIndex, splitIndex, splitCount, splitRatio, shadowResolution, shadowNearPlaneOffset, out viewMatrix, out projMatrix, out shadowSplitData);
		}

		// Token: 0x06002535 RID: 9525 RVA: 0x00002669 File Offset: 0x00000869
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		internal void Validate()
		{
		}

		// Token: 0x06002536 RID: 9526 RVA: 0x0003F4D0 File Offset: 0x0003D6D0
		public bool Equals(CullingResults other)
		{
			return this.ptr.Equals(other.ptr) && this.m_AllocationInfo == other.m_AllocationInfo;
		}

		// Token: 0x06002537 RID: 9527 RVA: 0x0003F50C File Offset: 0x0003D70C
		public override bool Equals(object obj)
		{
			bool flag = obj == null;
			return !flag && obj is CullingResults && this.Equals((CullingResults)obj);
		}

		// Token: 0x06002538 RID: 9528 RVA: 0x0003F544 File Offset: 0x0003D744
		public override int GetHashCode()
		{
			int hashCode = this.ptr.GetHashCode();
			return hashCode * 397 ^ this.m_AllocationInfo;
		}

		// Token: 0x06002539 RID: 9529 RVA: 0x0003F578 File Offset: 0x0003D778
		public static bool operator ==(CullingResults left, CullingResults right)
		{
			return left.Equals(right);
		}

		// Token: 0x0600253A RID: 9530 RVA: 0x0003F594 File Offset: 0x0003D794
		public static bool operator !=(CullingResults left, CullingResults right)
		{
			return !left.Equals(right);
		}

		// Token: 0x0600253B RID: 9531
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool ComputeDirectionalShadowMatricesAndCullingPrimitives_Injected(IntPtr cullingResultsPtr, int activeLightIndex, int splitIndex, int splitCount, ref Vector3 splitRatio, int shadowResolution, float shadowNearPlaneOffset, out Matrix4x4 viewMatrix, out Matrix4x4 projMatrix, out ShadowSplitData shadowSplitData);

		// Token: 0x04000DFF RID: 3583
		internal IntPtr ptr;

		// Token: 0x04000E00 RID: 3584
		private unsafe CullingAllocationInfo* m_AllocationInfo;
	}
}
