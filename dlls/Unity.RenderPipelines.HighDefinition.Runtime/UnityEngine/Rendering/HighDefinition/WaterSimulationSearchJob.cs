using System;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200021F RID: 543
	[BurstCompile]
	public struct WaterSimulationSearchJob : IJobParallelFor
	{
		// Token: 0x06000FD0 RID: 4048 RVA: 0x0007A6F8 File Offset: 0x000788F8
		public void Execute(int index)
		{
			WaterSearchParameters wsp = default(WaterSearchParameters);
			wsp.targetPosition = this.targetPositionBuffer[index];
			wsp.startPosition = this.startPositionBuffer[index];
			wsp.error = this.error;
			wsp.maxIterations = this.maxIterations;
			WaterSearchResult waterSearchResult = default(WaterSearchResult);
			HDRenderPipeline.FindWaterSurfaceHeight(this.simSearchData, wsp, out waterSearchResult);
			this.heightBuffer[index] = waterSearchResult.height;
			this.errorBuffer[index] = waterSearchResult.error;
			this.candidateLocationBuffer[index] = waterSearchResult.candidateLocation;
			this.stepCountBuffer[index] = waterSearchResult.numIterations;
		}

		// Token: 0x04001872 RID: 6258
		public WaterSimSearchData simSearchData;

		// Token: 0x04001873 RID: 6259
		[ReadOnly]
		[NativeDisableParallelForRestriction]
		public NativeArray<float3> targetPositionBuffer;

		// Token: 0x04001874 RID: 6260
		[ReadOnly]
		[NativeDisableParallelForRestriction]
		public NativeArray<float3> startPositionBuffer;

		// Token: 0x04001875 RID: 6261
		public float error;

		// Token: 0x04001876 RID: 6262
		public int maxIterations;

		// Token: 0x04001877 RID: 6263
		[WriteOnly]
		[NativeDisableParallelForRestriction]
		public NativeArray<float> heightBuffer;

		// Token: 0x04001878 RID: 6264
		[WriteOnly]
		[NativeDisableParallelForRestriction]
		public NativeArray<float> errorBuffer;

		// Token: 0x04001879 RID: 6265
		[WriteOnly]
		[NativeDisableParallelForRestriction]
		public NativeArray<float3> candidateLocationBuffer;

		// Token: 0x0400187A RID: 6266
		[WriteOnly]
		[NativeDisableParallelForRestriction]
		public NativeArray<int> stepCountBuffer;
	}
}
