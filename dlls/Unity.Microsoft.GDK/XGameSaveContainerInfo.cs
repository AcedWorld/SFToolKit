using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000128 RID: 296
	[MovedFrom("Unity.GameCore")]
	public class XGameSaveContainerInfo
	{
		// Token: 0x06000775 RID: 1909 RVA: 0x0000CFD1 File Offset: 0x0000B1D1
		internal XGameSaveContainerInfo(XGameSaveContainerInfo interop)
		{
			this.interop = interop;
		}

		// Token: 0x06000776 RID: 1910 RVA: 0x0000CFE0 File Offset: 0x0000B1E0
		public XGameSaveContainerInfo()
		{
			this.interop = default(XGameSaveContainerInfo);
		}

		// Token: 0x170001FA RID: 506
		// (get) Token: 0x06000777 RID: 1911 RVA: 0x0000CFF4 File Offset: 0x0000B1F4
		// (set) Token: 0x06000778 RID: 1912 RVA: 0x0000D001 File Offset: 0x0000B201
		public string Name
		{
			get
			{
				return this.interop.name;
			}
			set
			{
				this.interop.name = value;
			}
		}

		// Token: 0x170001FB RID: 507
		// (get) Token: 0x06000779 RID: 1913 RVA: 0x0000D00F File Offset: 0x0000B20F
		// (set) Token: 0x0600077A RID: 1914 RVA: 0x0000D01C File Offset: 0x0000B21C
		public string DisplayName
		{
			get
			{
				return this.interop.displayName;
			}
			set
			{
				this.interop.displayName = value;
			}
		}

		// Token: 0x170001FC RID: 508
		// (get) Token: 0x0600077B RID: 1915 RVA: 0x0000D02A File Offset: 0x0000B22A
		// (set) Token: 0x0600077C RID: 1916 RVA: 0x0000D037 File Offset: 0x0000B237
		public uint BlobCount
		{
			get
			{
				return this.interop.blobCount;
			}
			set
			{
				this.interop.blobCount = value;
			}
		}

		// Token: 0x170001FD RID: 509
		// (get) Token: 0x0600077D RID: 1917 RVA: 0x0000D045 File Offset: 0x0000B245
		// (set) Token: 0x0600077E RID: 1918 RVA: 0x0000D052 File Offset: 0x0000B252
		public ulong TotalSize
		{
			get
			{
				return this.interop.totalSize;
			}
			set
			{
				this.interop.totalSize = value;
			}
		}

		// Token: 0x170001FE RID: 510
		// (get) Token: 0x0600077F RID: 1919 RVA: 0x0000D060 File Offset: 0x0000B260
		// (set) Token: 0x06000780 RID: 1920 RVA: 0x0000D06D File Offset: 0x0000B26D
		public long LastModifiedTime
		{
			get
			{
				return this.interop.lastModifiedTime;
			}
			set
			{
				this.interop.lastModifiedTime = value;
			}
		}

		// Token: 0x170001FF RID: 511
		// (get) Token: 0x06000781 RID: 1921 RVA: 0x0000D07B File Offset: 0x0000B27B
		// (set) Token: 0x06000782 RID: 1922 RVA: 0x0000D088 File Offset: 0x0000B288
		public bool NeedsSync
		{
			get
			{
				return this.interop.needsSync;
			}
			set
			{
				this.interop.needsSync = value;
			}
		}

		// Token: 0x0400045E RID: 1118
		internal XGameSaveContainerInfo interop;
	}
}
