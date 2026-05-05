using System;
using System.Diagnostics;
using Unity.Profiling;
using Unity.Profiling.LowLevel;
using Unity.Profiling.LowLevel.Unsafe;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

namespace UnityEngine.Profiling
{
	// Token: 0x020002BD RID: 701
	[UsedByNativeCode]
	[NativeHeader("Runtime/Profiler/Marker.h")]
	[NativeHeader("Runtime/Profiler/ScriptBindings/Sampler.bindings.h")]
	public sealed class CustomSampler : Sampler
	{
		// Token: 0x06001E07 RID: 7687 RVA: 0x00031921 File Offset: 0x0002FB21
		internal CustomSampler()
		{
		}

		// Token: 0x06001E08 RID: 7688 RVA: 0x0003192B File Offset: 0x0002FB2B
		internal CustomSampler(IntPtr ptr)
		{
			this.m_Ptr = ptr;
		}

		// Token: 0x06001E09 RID: 7689 RVA: 0x0003193C File Offset: 0x0002FB3C
		public static CustomSampler Create(string name, bool collectGpuData = false)
		{
			IntPtr intPtr = ProfilerUnsafeUtility.CreateMarker(name, 1, MarkerFlags.AvailabilityNonDevelopment | (collectGpuData ? MarkerFlags.SampleGPU : MarkerFlags.Default), 0);
			bool flag = intPtr == IntPtr.Zero;
			CustomSampler result;
			if (flag)
			{
				result = CustomSampler.s_InvalidCustomSampler;
			}
			else
			{
				result = new CustomSampler(intPtr);
			}
			return result;
		}

		// Token: 0x06001E0A RID: 7690 RVA: 0x00031981 File Offset: 0x0002FB81
		[IgnoredByDeepProfiler]
		[Conditional("ENABLE_PROFILER")]
		public void Begin()
		{
			ProfilerUnsafeUtility.BeginSample(this.m_Ptr);
		}

		// Token: 0x06001E0B RID: 7691 RVA: 0x00031990 File Offset: 0x0002FB90
		[Conditional("ENABLE_PROFILER")]
		[IgnoredByDeepProfiler]
		public void Begin(Object targetObject)
		{
			ProfilerUnsafeUtility.Internal_BeginWithObject(this.m_Ptr, targetObject);
		}

		// Token: 0x06001E0C RID: 7692 RVA: 0x000319A0 File Offset: 0x0002FBA0
		[IgnoredByDeepProfiler]
		[Conditional("ENABLE_PROFILER")]
		public void End()
		{
			ProfilerUnsafeUtility.EndSample(this.m_Ptr);
		}

		// Token: 0x040009EC RID: 2540
		internal static CustomSampler s_InvalidCustomSampler = new CustomSampler();
	}
}
