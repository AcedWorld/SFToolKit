using System;

namespace UnityEngine.Android
{
	// Token: 0x02000014 RID: 20
	public class AndroidAssetPackState
	{
		// Token: 0x06000220 RID: 544 RVA: 0x00009555 File Offset: 0x00007755
		internal AndroidAssetPackState(string name, AndroidAssetPackStatus status, AndroidAssetPackError error)
		{
			this.name = name;
			this.status = status;
			this.error = error;
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000221 RID: 545 RVA: 0x00009574 File Offset: 0x00007774
		public string name { get; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000222 RID: 546 RVA: 0x0000957C File Offset: 0x0000777C
		public AndroidAssetPackStatus status { get; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000223 RID: 547 RVA: 0x00009584 File Offset: 0x00007784
		public AndroidAssetPackError error { get; }
	}
}
