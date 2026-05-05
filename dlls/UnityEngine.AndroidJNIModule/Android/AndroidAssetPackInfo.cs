using System;

namespace UnityEngine.Android
{
	// Token: 0x02000013 RID: 19
	public class AndroidAssetPackInfo
	{
		// Token: 0x06000219 RID: 537 RVA: 0x000094EE File Offset: 0x000076EE
		internal AndroidAssetPackInfo(string name, AndroidAssetPackStatus status, ulong size, ulong bytesDownloaded, float transferProgress, AndroidAssetPackError error)
		{
			this.name = name;
			this.status = status;
			this.size = size;
			this.bytesDownloaded = bytesDownloaded;
			this.transferProgress = transferProgress;
			this.error = error;
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600021A RID: 538 RVA: 0x00009525 File Offset: 0x00007725
		public string name { get; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600021B RID: 539 RVA: 0x0000952D File Offset: 0x0000772D
		public AndroidAssetPackStatus status { get; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600021C RID: 540 RVA: 0x00009535 File Offset: 0x00007735
		public ulong size { get; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600021D RID: 541 RVA: 0x0000953D File Offset: 0x0000773D
		public ulong bytesDownloaded { get; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600021E RID: 542 RVA: 0x00009545 File Offset: 0x00007745
		public float transferProgress { get; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600021F RID: 543 RVA: 0x0000954D File Offset: 0x0000774D
		public AndroidAssetPackError error { get; }
	}
}
