using System;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;

namespace UnityEngine.UIElements.UIR
{
	// Token: 0x02000452 RID: 1106
	internal class OpacityIdAccelerator : IDisposable
	{
		// Token: 0x06002295 RID: 8853 RVA: 0x00085248 File Offset: 0x00083448
		public void CreateJob(NativeSlice<Vertex> oldVerts, NativeSlice<Vertex> newVerts, Color32 opacityData, int vertexCount)
		{
			JobHandle value = new OpacityIdAccelerator.OpacityIdUpdateJob
			{
				oldVerts = oldVerts,
				newVerts = newVerts,
				opacityData = opacityData
			}.Schedule(vertexCount, 128, default(JobHandle));
			bool flag = this.m_NextJobIndex == this.m_Jobs.Length;
			if (flag)
			{
				this.m_Jobs[0] = JobHandle.CombineDependencies(this.m_Jobs);
				this.m_NextJobIndex = 1;
				JobHandle.ScheduleBatchedJobs();
			}
			int nextJobIndex = this.m_NextJobIndex;
			this.m_NextJobIndex = nextJobIndex + 1;
			this.m_Jobs[nextJobIndex] = value;
		}

		// Token: 0x06002296 RID: 8854 RVA: 0x000852EC File Offset: 0x000834EC
		public void CompleteJobs()
		{
			bool flag = this.m_NextJobIndex > 0;
			if (flag)
			{
				bool flag2 = this.m_NextJobIndex > 1;
				if (flag2)
				{
					JobHandle.CombineDependencies(this.m_Jobs.Slice(0, this.m_NextJobIndex)).Complete();
				}
				else
				{
					this.m_Jobs[0].Complete();
				}
			}
			this.m_NextJobIndex = 0;
		}

		// Token: 0x170007DD RID: 2013
		// (get) Token: 0x06002297 RID: 8855 RVA: 0x00085354 File Offset: 0x00083554
		// (set) Token: 0x06002298 RID: 8856 RVA: 0x0008535C File Offset: 0x0008355C
		private protected bool disposed { protected get; private set; }

		// Token: 0x06002299 RID: 8857 RVA: 0x00085365 File Offset: 0x00083565
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x0600229A RID: 8858 RVA: 0x00085378 File Offset: 0x00083578
		protected virtual void Dispose(bool disposing)
		{
			bool disposed = this.disposed;
			if (!disposed)
			{
				if (disposing)
				{
					this.m_Jobs.Dispose();
				}
				this.disposed = true;
			}
		}

		// Token: 0x04000F79 RID: 3961
		private const int k_VerticesPerBatch = 128;

		// Token: 0x04000F7A RID: 3962
		private const int k_JobLimit = 256;

		// Token: 0x04000F7B RID: 3963
		private NativeArray<JobHandle> m_Jobs = new NativeArray<JobHandle>(256, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);

		// Token: 0x04000F7C RID: 3964
		private int m_NextJobIndex;

		// Token: 0x02000453 RID: 1107
		private struct OpacityIdUpdateJob : IJobParallelFor
		{
			// Token: 0x0600229C RID: 8860 RVA: 0x000853C8 File Offset: 0x000835C8
			public void Execute(int i)
			{
				Vertex value = this.oldVerts[i];
				value.opacityColorPages.r = this.opacityData.r;
				value.opacityColorPages.g = this.opacityData.g;
				value.ids.b = this.opacityData.b;
				this.newVerts[i] = value;
			}

			// Token: 0x04000F7E RID: 3966
			[NativeDisableContainerSafetyRestriction]
			public NativeSlice<Vertex> oldVerts;

			// Token: 0x04000F7F RID: 3967
			[NativeDisableContainerSafetyRestriction]
			public NativeSlice<Vertex> newVerts;

			// Token: 0x04000F80 RID: 3968
			public Color32 opacityData;
		}
	}
}
