using System;

namespace UnityEngine
{
	// Token: 0x0200029A RID: 666
	[Flags]
	public enum DrivenTransformProperties
	{
		// Token: 0x04000970 RID: 2416
		None = 0,
		// Token: 0x04000971 RID: 2417
		All = -1,
		// Token: 0x04000972 RID: 2418
		AnchoredPositionX = 2,
		// Token: 0x04000973 RID: 2419
		AnchoredPositionY = 4,
		// Token: 0x04000974 RID: 2420
		AnchoredPositionZ = 8,
		// Token: 0x04000975 RID: 2421
		Rotation = 16,
		// Token: 0x04000976 RID: 2422
		ScaleX = 32,
		// Token: 0x04000977 RID: 2423
		ScaleY = 64,
		// Token: 0x04000978 RID: 2424
		ScaleZ = 128,
		// Token: 0x04000979 RID: 2425
		AnchorMinX = 256,
		// Token: 0x0400097A RID: 2426
		AnchorMinY = 512,
		// Token: 0x0400097B RID: 2427
		AnchorMaxX = 1024,
		// Token: 0x0400097C RID: 2428
		AnchorMaxY = 2048,
		// Token: 0x0400097D RID: 2429
		SizeDeltaX = 4096,
		// Token: 0x0400097E RID: 2430
		SizeDeltaY = 8192,
		// Token: 0x0400097F RID: 2431
		PivotX = 16384,
		// Token: 0x04000980 RID: 2432
		PivotY = 32768,
		// Token: 0x04000981 RID: 2433
		AnchoredPosition = 6,
		// Token: 0x04000982 RID: 2434
		AnchoredPosition3D = 14,
		// Token: 0x04000983 RID: 2435
		Scale = 224,
		// Token: 0x04000984 RID: 2436
		AnchorMin = 768,
		// Token: 0x04000985 RID: 2437
		AnchorMax = 3072,
		// Token: 0x04000986 RID: 2438
		Anchors = 3840,
		// Token: 0x04000987 RID: 2439
		SizeDelta = 12288,
		// Token: 0x04000988 RID: 2440
		Pivot = 49152
	}
}
