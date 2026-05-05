using System;

namespace UnityEngine.Android
{
	// Token: 0x02000011 RID: 17
	public enum AndroidAssetPackStatus
	{
		// Token: 0x04000025 RID: 37
		Unknown,
		// Token: 0x04000026 RID: 38
		Pending,
		// Token: 0x04000027 RID: 39
		Downloading,
		// Token: 0x04000028 RID: 40
		Transferring,
		// Token: 0x04000029 RID: 41
		Completed,
		// Token: 0x0400002A RID: 42
		Failed,
		// Token: 0x0400002B RID: 43
		Canceled,
		// Token: 0x0400002C RID: 44
		WaitingForWifi,
		// Token: 0x0400002D RID: 45
		NotInstalled
	}
}
