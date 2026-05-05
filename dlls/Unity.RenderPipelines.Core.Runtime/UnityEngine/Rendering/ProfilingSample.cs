using System;
using Unity.Profiling;
using UnityEngine.Profiling;

namespace UnityEngine.Rendering
{
	// Token: 0x0200007A RID: 122
	[Obsolete("Please use ProfilingScope")]
	[IgnoredByDeepProfiler]
	public struct ProfilingSample : IDisposable
	{
		// Token: 0x060003CB RID: 971 RVA: 0x000102BD File Offset: 0x0000E4BD
		public ProfilingSample(CommandBuffer cmd, string name, CustomSampler sampler = null)
		{
			this.m_Cmd = cmd;
			this.m_Name = name;
			this.m_Disposed = false;
			if (cmd != null && name != "")
			{
				cmd.BeginSample(name);
			}
			this.m_Sampler = sampler;
		}

		// Token: 0x060003CC RID: 972 RVA: 0x000102F2 File Offset: 0x0000E4F2
		public ProfilingSample(CommandBuffer cmd, string format, object arg)
		{
			this = new ProfilingSample(cmd, string.Format(format, arg), null);
		}

		// Token: 0x060003CD RID: 973 RVA: 0x00010303 File Offset: 0x0000E503
		public ProfilingSample(CommandBuffer cmd, string format, params object[] args)
		{
			this = new ProfilingSample(cmd, string.Format(format, args), null);
		}

		// Token: 0x060003CE RID: 974 RVA: 0x00010314 File Offset: 0x0000E514
		public void Dispose()
		{
			this.Dispose(true);
		}

		// Token: 0x060003CF RID: 975 RVA: 0x0001031D File Offset: 0x0000E51D
		private void Dispose(bool disposing)
		{
			if (this.m_Disposed)
			{
				return;
			}
			if (disposing && this.m_Cmd != null && this.m_Name != "")
			{
				this.m_Cmd.EndSample(this.m_Name);
			}
			this.m_Disposed = true;
		}

		// Token: 0x0400021C RID: 540
		private readonly CommandBuffer m_Cmd;

		// Token: 0x0400021D RID: 541
		private readonly string m_Name;

		// Token: 0x0400021E RID: 542
		private bool m_Disposed;

		// Token: 0x0400021F RID: 543
		private CustomSampler m_Sampler;
	}
}
