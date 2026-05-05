using System;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace UnityEngine.UIElements.UIR
{
	// Token: 0x02000445 RID: 1093
	internal class JobManager : IDisposable
	{
		// Token: 0x06002263 RID: 8803 RVA: 0x000845DB File Offset: 0x000827DB
		public void Add(ref NudgeJobData job)
		{
			this.m_NudgeJobs.Add(ref job);
		}

		// Token: 0x06002264 RID: 8804 RVA: 0x000845EB File Offset: 0x000827EB
		public void Add(ref ConvertMeshJobData job)
		{
			this.m_ConvertMeshJobs.Add(ref job);
		}

		// Token: 0x06002265 RID: 8805 RVA: 0x000845FB File Offset: 0x000827FB
		public void Add(ref CopyClosingMeshJobData job)
		{
			this.m_CopyClosingMeshJobs.Add(ref job);
		}

		// Token: 0x06002266 RID: 8806 RVA: 0x0008460C File Offset: 0x0008280C
		public void CompleteNudgeJobs()
		{
			foreach (NativeSlice<NudgeJobData> nativeSlice in this.m_NudgeJobs.GetPages())
			{
				this.m_JobMerger.Add(JobProcessor.ScheduleNudgeJobs((IntPtr)nativeSlice.GetUnsafePtr<NudgeJobData>(), nativeSlice.Length));
			}
			this.m_JobMerger.MergeAndReset().Complete();
			this.m_NudgeJobs.Reset();
		}

		// Token: 0x06002267 RID: 8807 RVA: 0x000846A4 File Offset: 0x000828A4
		public void CompleteConvertMeshJobs()
		{
			foreach (NativeSlice<ConvertMeshJobData> nativeSlice in this.m_ConvertMeshJobs.GetPages())
			{
				this.m_JobMerger.Add(JobProcessor.ScheduleConvertMeshJobs((IntPtr)nativeSlice.GetUnsafePtr<ConvertMeshJobData>(), nativeSlice.Length));
			}
			this.m_JobMerger.MergeAndReset().Complete();
			this.m_ConvertMeshJobs.Reset();
		}

		// Token: 0x06002268 RID: 8808 RVA: 0x0008473C File Offset: 0x0008293C
		public void CompleteClosingMeshJobs()
		{
			foreach (NativeSlice<CopyClosingMeshJobData> nativeSlice in this.m_CopyClosingMeshJobs.GetPages())
			{
				this.m_JobMerger.Add(JobProcessor.ScheduleCopyClosingMeshJobs((IntPtr)nativeSlice.GetUnsafePtr<CopyClosingMeshJobData>(), nativeSlice.Length));
			}
			this.m_JobMerger.MergeAndReset().Complete();
			this.m_CopyClosingMeshJobs.Reset();
		}

		// Token: 0x170007D9 RID: 2009
		// (get) Token: 0x06002269 RID: 8809 RVA: 0x000847D4 File Offset: 0x000829D4
		// (set) Token: 0x0600226A RID: 8810 RVA: 0x000847DC File Offset: 0x000829DC
		private protected bool disposed { protected get; private set; }

		// Token: 0x0600226B RID: 8811 RVA: 0x000847E5 File Offset: 0x000829E5
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x0600226C RID: 8812 RVA: 0x000847F8 File Offset: 0x000829F8
		protected void Dispose(bool disposing)
		{
			bool disposed = this.disposed;
			if (!disposed)
			{
				if (disposing)
				{
					this.m_NudgeJobs.Dispose();
					this.m_ConvertMeshJobs.Dispose();
					this.m_CopyClosingMeshJobs.Dispose();
					this.m_JobMerger.Dispose();
				}
				this.disposed = true;
			}
		}

		// Token: 0x04000F37 RID: 3895
		private NativePagedList<NudgeJobData> m_NudgeJobs = new NativePagedList<NudgeJobData>(64);

		// Token: 0x04000F38 RID: 3896
		private NativePagedList<ConvertMeshJobData> m_ConvertMeshJobs = new NativePagedList<ConvertMeshJobData>(64);

		// Token: 0x04000F39 RID: 3897
		private NativePagedList<CopyClosingMeshJobData> m_CopyClosingMeshJobs = new NativePagedList<CopyClosingMeshJobData>(64);

		// Token: 0x04000F3A RID: 3898
		private JobMerger m_JobMerger = new JobMerger(128);
	}
}
