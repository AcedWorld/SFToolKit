using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200015E RID: 350
	[MovedFrom("Unity.GameCore")]
	public class XPackageInstallationProgress
	{
		// Token: 0x06000852 RID: 2130 RVA: 0x0000DB62 File Offset: 0x0000BD62
		internal XPackageInstallationProgress(XPackageInstallationProgress interop)
		{
			this.interop = interop;
		}

		// Token: 0x06000853 RID: 2131 RVA: 0x0000DB71 File Offset: 0x0000BD71
		public XPackageInstallationProgress()
		{
			this.interop = default(XPackageInstallationProgress);
		}

		// Token: 0x17000249 RID: 585
		// (get) Token: 0x06000854 RID: 2132 RVA: 0x0000DB85 File Offset: 0x0000BD85
		// (set) Token: 0x06000855 RID: 2133 RVA: 0x0000DB92 File Offset: 0x0000BD92
		public ulong TotalBytes
		{
			get
			{
				return this.interop.totalBytes;
			}
			set
			{
				this.interop.totalBytes = value;
			}
		}

		// Token: 0x1700024A RID: 586
		// (get) Token: 0x06000856 RID: 2134 RVA: 0x0000DBA0 File Offset: 0x0000BDA0
		// (set) Token: 0x06000857 RID: 2135 RVA: 0x0000DBAD File Offset: 0x0000BDAD
		public ulong InstalledBytes
		{
			get
			{
				return this.interop.installedBytes;
			}
			set
			{
				this.interop.installedBytes = value;
			}
		}

		// Token: 0x1700024B RID: 587
		// (get) Token: 0x06000858 RID: 2136 RVA: 0x0000DBBB File Offset: 0x0000BDBB
		// (set) Token: 0x06000859 RID: 2137 RVA: 0x0000DBC8 File Offset: 0x0000BDC8
		public ulong LaunchBytes
		{
			get
			{
				return this.interop.launchBytes;
			}
			set
			{
				this.interop.launchBytes = value;
			}
		}

		// Token: 0x1700024C RID: 588
		// (get) Token: 0x0600085A RID: 2138 RVA: 0x0000DBD6 File Offset: 0x0000BDD6
		// (set) Token: 0x0600085B RID: 2139 RVA: 0x0000DBE3 File Offset: 0x0000BDE3
		public bool Launchable
		{
			get
			{
				return this.interop.launchable;
			}
			set
			{
				this.interop.launchable = value;
			}
		}

		// Token: 0x1700024D RID: 589
		// (get) Token: 0x0600085C RID: 2140 RVA: 0x0000DBF1 File Offset: 0x0000BDF1
		// (set) Token: 0x0600085D RID: 2141 RVA: 0x0000DBFE File Offset: 0x0000BDFE
		public bool Completed
		{
			get
			{
				return this.interop.completed;
			}
			set
			{
				this.interop.completed = value;
			}
		}

		// Token: 0x0400050A RID: 1290
		internal XPackageInstallationProgress interop;
	}
}
