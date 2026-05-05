using System;

namespace RootMotion
{
	// Token: 0x02000026 RID: 38
	[Serializable]
	public enum InterpolationMode
	{
		// Token: 0x040000EC RID: 236
		None,
		// Token: 0x040000ED RID: 237
		InOutCubic,
		// Token: 0x040000EE RID: 238
		InOutQuintic,
		// Token: 0x040000EF RID: 239
		InOutSine,
		// Token: 0x040000F0 RID: 240
		InQuintic,
		// Token: 0x040000F1 RID: 241
		InQuartic,
		// Token: 0x040000F2 RID: 242
		InCubic,
		// Token: 0x040000F3 RID: 243
		InQuadratic,
		// Token: 0x040000F4 RID: 244
		InElastic,
		// Token: 0x040000F5 RID: 245
		InElasticSmall,
		// Token: 0x040000F6 RID: 246
		InElasticBig,
		// Token: 0x040000F7 RID: 247
		InSine,
		// Token: 0x040000F8 RID: 248
		InBack,
		// Token: 0x040000F9 RID: 249
		OutQuintic,
		// Token: 0x040000FA RID: 250
		OutQuartic,
		// Token: 0x040000FB RID: 251
		OutCubic,
		// Token: 0x040000FC RID: 252
		OutInCubic,
		// Token: 0x040000FD RID: 253
		OutInQuartic,
		// Token: 0x040000FE RID: 254
		OutElastic,
		// Token: 0x040000FF RID: 255
		OutElasticSmall,
		// Token: 0x04000100 RID: 256
		OutElasticBig,
		// Token: 0x04000101 RID: 257
		OutSine,
		// Token: 0x04000102 RID: 258
		OutBack,
		// Token: 0x04000103 RID: 259
		OutBackCubic,
		// Token: 0x04000104 RID: 260
		OutBackQuartic,
		// Token: 0x04000105 RID: 261
		BackInCubic,
		// Token: 0x04000106 RID: 262
		BackInQuartic
	}
}
