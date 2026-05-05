using System;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using UnityEngine.Bindings;
using UnityEngine.Rendering;

namespace UnityEngine
{
	// Token: 0x02000140 RID: 320
	[NativeHeader("Runtime/Camera/RenderLoops/LightProbeContext.h")]
	[StaticAccessor("LightProbeContextWrapper", StaticAccessorType.DoubleColon)]
	[NativeContainer]
	public struct LightProbesQuery : IDisposable
	{
		// Token: 0x06000905 RID: 2309 RVA: 0x0000E8A4 File Offset: 0x0000CAA4
		public LightProbesQuery(Allocator allocator)
		{
			this.m_LightProbeContextWrapper = LightProbesQuery.Create();
			this.m_AllocatorLabel = allocator;
			UnsafeUtility.LeakRecord(this.m_LightProbeContextWrapper, LeakCategory.LightProbesQuery, 0);
		}

		// Token: 0x06000906 RID: 2310 RVA: 0x0000E8C8 File Offset: 0x0000CAC8
		public void Dispose()
		{
			bool flag = this.m_LightProbeContextWrapper == IntPtr.Zero;
			if (flag)
			{
				throw new ObjectDisposedException("The LightProbesQuery is already disposed.");
			}
			bool flag2 = this.m_AllocatorLabel == Allocator.Invalid;
			if (flag2)
			{
				throw new InvalidOperationException("The LightProbesQuery can not be Disposed because it was not allocated with a valid allocator.");
			}
			bool flag3 = this.m_AllocatorLabel > Allocator.None;
			if (flag3)
			{
				UnsafeUtility.LeakErase(this.m_LightProbeContextWrapper, LeakCategory.LightProbesQuery);
				LightProbesQuery.Destroy(this.m_LightProbeContextWrapper);
				this.m_AllocatorLabel = Allocator.Invalid;
			}
			this.m_LightProbeContextWrapper = IntPtr.Zero;
		}

		// Token: 0x06000907 RID: 2311 RVA: 0x0000E94C File Offset: 0x0000CB4C
		public JobHandle Dispose(JobHandle inputDeps)
		{
			bool flag = this.m_AllocatorLabel == Allocator.Invalid;
			if (flag)
			{
				throw new InvalidOperationException("The LightProbesQuery can not be Disposed because it was not allocated with a valid allocator.");
			}
			bool flag2 = this.m_LightProbeContextWrapper == IntPtr.Zero;
			if (flag2)
			{
				throw new InvalidOperationException("The LightProbesQuery is already disposed.");
			}
			bool flag3 = this.m_AllocatorLabel > Allocator.None;
			JobHandle result;
			if (flag3)
			{
				JobHandle jobHandle = new LightProbesQuery.LightProbesQueryDisposeJob
				{
					Data = new LightProbesQuery.LightProbesQueryDispose
					{
						m_LightProbeContextWrapper = this.m_LightProbeContextWrapper
					}
				}.Schedule(inputDeps);
				this.m_AllocatorLabel = Allocator.Invalid;
				this.m_LightProbeContextWrapper = IntPtr.Zero;
				result = jobHandle;
			}
			else
			{
				this.m_LightProbeContextWrapper = IntPtr.Zero;
				result = inputDeps;
			}
			return result;
		}

		// Token: 0x170001F2 RID: 498
		// (get) Token: 0x06000908 RID: 2312 RVA: 0x0000E9FC File Offset: 0x0000CBFC
		public bool IsCreated
		{
			get
			{
				return this.m_LightProbeContextWrapper != IntPtr.Zero;
			}
		}

		// Token: 0x06000909 RID: 2313
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr Create();

		// Token: 0x0600090A RID: 2314
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void Destroy(IntPtr lightProbeContextWrapper);

		// Token: 0x0600090B RID: 2315 RVA: 0x0000EA1E File Offset: 0x0000CC1E
		public void CalculateInterpolatedLightAndOcclusionProbe(Vector3 position, ref int tetrahedronIndex, out SphericalHarmonicsL2 lightProbe, out Vector4 occlusionProbe)
		{
			LightProbesQuery.CalculateInterpolatedLightAndOcclusionProbe(this.m_LightProbeContextWrapper, position, ref tetrahedronIndex, out lightProbe, out occlusionProbe);
		}

		// Token: 0x0600090C RID: 2316 RVA: 0x0000EA34 File Offset: 0x0000CC34
		public void CalculateInterpolatedLightAndOcclusionProbes(NativeArray<Vector3> positions, NativeArray<int> tetrahedronIndices, NativeArray<SphericalHarmonicsL2> lightProbes, NativeArray<Vector4> occlusionProbes)
		{
			bool flag = tetrahedronIndices.Length < positions.Length;
			if (flag)
			{
				throw new ArgumentException("tetrahedronIndices", "Argument tetrahedronIndices is null or has fewer elements than positions.");
			}
			bool flag2 = lightProbes.Length < positions.Length;
			if (flag2)
			{
				throw new ArgumentException("lightProbes", "Argument lightProbes is null or has fewer elements than positions.");
			}
			bool flag3 = occlusionProbes.Length < positions.Length;
			if (flag3)
			{
				throw new ArgumentException("occlusionProbes", "Argument occlusionProbes is null or has fewer elements than positions.");
			}
			LightProbesQuery.CalculateInterpolatedLightAndOcclusionProbes(this.m_LightProbeContextWrapper, (IntPtr)positions.GetUnsafeReadOnlyPtr<Vector3>(), (IntPtr)tetrahedronIndices.GetUnsafeReadOnlyPtr<int>(), (IntPtr)lightProbes.GetUnsafePtr<SphericalHarmonicsL2>(), (IntPtr)occlusionProbes.GetUnsafePtr<Vector4>(), positions.Length);
		}

		// Token: 0x0600090D RID: 2317 RVA: 0x0000EAF4 File Offset: 0x0000CCF4
		[ThreadSafe]
		private static void CalculateInterpolatedLightAndOcclusionProbe(IntPtr lightProbeContextWrapper, Vector3 position, ref int tetrahedronIndex, out SphericalHarmonicsL2 lightProbe, out Vector4 occlusionProbe)
		{
			LightProbesQuery.CalculateInterpolatedLightAndOcclusionProbe_Injected(lightProbeContextWrapper, ref position, ref tetrahedronIndex, out lightProbe, out occlusionProbe);
		}

		// Token: 0x0600090E RID: 2318
		[ThreadSafe]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void CalculateInterpolatedLightAndOcclusionProbes(IntPtr lightProbeContextWrapper, IntPtr positions, IntPtr tetrahedronIndices, IntPtr lightProbes, IntPtr occlusionProbes, int count);

		// Token: 0x0600090F RID: 2319
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void CalculateInterpolatedLightAndOcclusionProbe_Injected(IntPtr lightProbeContextWrapper, ref Vector3 position, ref int tetrahedronIndex, out SphericalHarmonicsL2 lightProbe, out Vector4 occlusionProbe);

		// Token: 0x04000407 RID: 1031
		[NativeDisableUnsafePtrRestriction]
		internal IntPtr m_LightProbeContextWrapper;

		// Token: 0x04000408 RID: 1032
		internal Allocator m_AllocatorLabel;

		// Token: 0x02000141 RID: 321
		[NativeContainer]
		internal struct LightProbesQueryDispose
		{
			// Token: 0x06000910 RID: 2320 RVA: 0x0000EB02 File Offset: 0x0000CD02
			public void Dispose()
			{
				UnsafeUtility.LeakErase(this.m_LightProbeContextWrapper, LeakCategory.LightProbesQuery);
				LightProbesQuery.Destroy(this.m_LightProbeContextWrapper);
			}

			// Token: 0x04000409 RID: 1033
			[NativeDisableUnsafePtrRestriction]
			internal IntPtr m_LightProbeContextWrapper;
		}

		// Token: 0x02000142 RID: 322
		internal struct LightProbesQueryDisposeJob : IJob
		{
			// Token: 0x06000911 RID: 2321 RVA: 0x0000EB1E File Offset: 0x0000CD1E
			public void Execute()
			{
				this.Data.Dispose();
			}

			// Token: 0x0400040A RID: 1034
			internal LightProbesQuery.LightProbesQueryDispose Data;
		}
	}
}
