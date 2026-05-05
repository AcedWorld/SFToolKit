using System;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine.Rendering.HighDefinition;

namespace UnityEditor.Rendering.HighDefinition
{
	// Token: 0x02000018 RID: 24
	internal class WaterAmplitudeEvaluator
	{
		// Token: 0x06000020 RID: 32 RVA: 0x00002F68 File Offset: 0x00001168
		private static void EvaluateMaxAmplitude(NativeArray<float4> startBuffer, NativeArray<float4> intBuffer, NativeArray<float4> finBuffer)
		{
			new WaterAmplitudeEvaluator.ReductionStep
			{
				InputBuffer = startBuffer,
				OutputBuffer = intBuffer
			}.Schedule(64, 1, default(JobHandle)).Complete();
			new WaterAmplitudeEvaluator.ReductionStep
			{
				InputBuffer = intBuffer,
				OutputBuffer = finBuffer
			}.Schedule(1, 1, default(JobHandle)).Complete();
		}

		// Token: 0x0400005C RID: 92
		private const int k_NumIterations = 32;

		// Token: 0x0400005D RID: 93
		private const int k_NumTimeSteps = 512;

		// Token: 0x0400005E RID: 94
		private const WaterSimulationResolution resolutionEnum = WaterSimulationResolution.Low64;

		// Token: 0x0400005F RID: 95
		private const int resolution = 64;

		// Token: 0x04000060 RID: 96
		private const int numPixels = 4096;

		// Token: 0x02000249 RID: 585
		[BurstCompile]
		internal struct ReductionStep : IJobParallelFor
		{
			// Token: 0x060010A2 RID: 4258 RVA: 0x0007FBD4 File Offset: 0x0007DDD4
			public void Execute(int index)
			{
				float4 @float = 0f;
				for (int i = 0; i < 64; i++)
				{
					@float = math.max(@float, this.InputBuffer[i + index * 64]);
				}
				this.OutputBuffer[index] = @float;
			}

			// Token: 0x040019EE RID: 6638
			[ReadOnly]
			public NativeArray<float4> InputBuffer;

			// Token: 0x040019EF RID: 6639
			[WriteOnly]
			[NativeDisableParallelForRestriction]
			public NativeArray<float4> OutputBuffer;
		}
	}
}
