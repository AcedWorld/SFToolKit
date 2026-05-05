using System;

namespace UnityEngine.Android
{
	// Token: 0x02000012 RID: 18
	public enum AndroidAssetPackError
	{
		// Token: 0x0400002F RID: 47
		NoError,
		// Token: 0x04000030 RID: 48
		AppUnavailable = -1,
		// Token: 0x04000031 RID: 49
		PackUnavailable = -2,
		// Token: 0x04000032 RID: 50
		InvalidRequest = -3,
		// Token: 0x04000033 RID: 51
		DownloadNotFound = -4,
		// Token: 0x04000034 RID: 52
		ApiNotAvailable = -5,
		// Token: 0x04000035 RID: 53
		NetworkError = -6,
		// Token: 0x04000036 RID: 54
		AccessDenied = -7,
		// Token: 0x04000037 RID: 55
		InsufficientStorage = -10,
		// Token: 0x04000038 RID: 56
		PlayStoreNotFound = -11,
		// Token: 0x04000039 RID: 57
		NetworkUnrestricted = -12,
		// Token: 0x0400003A RID: 58
		AppNotOwned = -13,
		// Token: 0x0400003B RID: 59
		InternalError = -100
	}
}
