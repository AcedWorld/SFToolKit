using System;
using Unity.Collections;
using Unity.Jobs;

namespace UnityEngine.UIElements.UIR
{
	// Token: 0x02000449 RID: 1097
	internal class JobMerger : IDisposable
	{
		// Token: 0x0600226E RID: 8814 RVA: 0x00084893 File Offset: 0x00082A93
		public JobMerger(int capacity)
		{
			Debug.Assert(capacity > 1);
			this.m_Jobs = new NativeArray<JobHandle>(capacity, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
		}

		// Token: 0x0600226F RID: 8815 RVA: 0x000848B8 File Offset: 0x00082AB8
		public void Add(JobHandle job)
		{
			bool flag = this.m_JobCount < this.m_Jobs.Length;
			if (flag)
			{
				int jobCount = this.m_JobCount;
				this.m_JobCount = jobCount + 1;
				this.m_Jobs[jobCount] = job;
			}
			else
			{
				this.m_Jobs[0] = JobHandle.CombineDependencies(this.m_Jobs);
				this.m_Jobs[1] = job;
				this.m_JobCount = 2;
			}
		}

		// Token: 0x06002270 RID: 8816 RVA: 0x0008492C File Offset: 0x00082B2C
		public JobHandle MergeAndReset()
		{
			JobHandle result = default(JobHandle);
			bool flag = this.m_JobCount > 1;
			if (flag)
			{
				result = JobHandle.CombineDependencies(this.m_Jobs.Slice(0, this.m_JobCount));
			}
			else
			{
				bool flag2 = this.m_JobCount == 1;
				if (flag2)
				{
					result = this.m_Jobs[0];
				}
			}
			this.m_JobCount = 0;
			return result;
		}

		// Token: 0x170007DA RID: 2010
		// (get) Token: 0x06002271 RID: 8817 RVA: 0x0008498F File Offset: 0x00082B8F
		// (set) Token: 0x06002272 RID: 8818 RVA: 0x00084997 File Offset: 0x00082B97
		private protected bool disposed { protected get; private set; }

		// Token: 0x06002273 RID: 8819 RVA: 0x000849A0 File Offset: 0x00082BA0
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06002274 RID: 8820 RVA: 0x000849B4 File Offset: 0x00082BB4
		protected void Dispose(bool disposing)
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

		// Token: 0x04000F5D RID: 3933
		private NativeArray<JobHandle> m_Jobs;

		// Token: 0x04000F5E RID: 3934
		private int m_JobCount;
	}
}
