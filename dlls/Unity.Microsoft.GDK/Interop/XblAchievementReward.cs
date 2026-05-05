using System;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020001E6 RID: 486
	internal struct XblAchievementReward
	{
		// Token: 0x06000C32 RID: 3122 RVA: 0x00010363 File Offset: 0x0000E563
		internal T GetMediaAsset<T>(Func<XblAchievementMediaAsset, T> ctor) where T : class
		{
			return Converters.PtrToClass<T, XblAchievementMediaAsset>(this.mediaAsset, ctor);
		}

		// Token: 0x0400065C RID: 1628
		internal readonly UTF8StringPtr name;

		// Token: 0x0400065D RID: 1629
		internal readonly UTF8StringPtr description;

		// Token: 0x0400065E RID: 1630
		internal readonly UTF8StringPtr value;

		// Token: 0x0400065F RID: 1631
		internal readonly XblAchievementRewardType rewardType;

		// Token: 0x04000660 RID: 1632
		internal readonly UTF8StringPtr valueType;

		// Token: 0x04000661 RID: 1633
		private readonly IntPtr mediaAsset;
	}
}
