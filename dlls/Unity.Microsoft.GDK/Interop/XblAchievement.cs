using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020001E0 RID: 480
	internal struct XblAchievement
	{
		// Token: 0x06000C2D RID: 3117 RVA: 0x000102E1 File Offset: 0x0000E4E1
		internal T[] GetTitleAssociations<T>(Func<XblAchievementTitleAssociation, T> ctor)
		{
			return Converters.PtrToClassArray<T, XblAchievementTitleAssociation>(this.titleAssociations, this.titleAssociationsCount, ctor);
		}

		// Token: 0x06000C2E RID: 3118 RVA: 0x000102F5 File Offset: 0x0000E4F5
		internal T[] GetMediaAssets<T>(Func<XblAchievementMediaAsset, T> ctor)
		{
			return Converters.PtrToClassArray<T, XblAchievementMediaAsset>(this.mediaAssets, this.mediaAssetsCount, ctor);
		}

		// Token: 0x06000C2F RID: 3119 RVA: 0x00010309 File Offset: 0x0000E509
		internal string[] GetPlatformsAvailableOn()
		{
			return Converters.PtrToClassArray<string, UTF8StringPtr>(this.platformsAvailableOn, this.platformsAvailableOnCount, (UTF8StringPtr s) => s.GetString());
		}

		// Token: 0x06000C30 RID: 3120 RVA: 0x0001033B File Offset: 0x0000E53B
		internal T[] GetRewards<T>(Func<XblAchievementReward, T> ctor)
		{
			return Converters.PtrToClassArray<T, XblAchievementReward>(this.rewards, this.rewardsCount, ctor);
		}

		// Token: 0x04000637 RID: 1591
		internal readonly UTF8StringPtr id;

		// Token: 0x04000638 RID: 1592
		internal readonly UTF8StringPtr serviceConfigurationId;

		// Token: 0x04000639 RID: 1593
		internal readonly UTF8StringPtr name;

		// Token: 0x0400063A RID: 1594
		private readonly IntPtr titleAssociations;

		// Token: 0x0400063B RID: 1595
		private readonly SizeT titleAssociationsCount;

		// Token: 0x0400063C RID: 1596
		internal readonly XblAchievementProgressState progressState;

		// Token: 0x0400063D RID: 1597
		internal readonly XblAchievementProgression progression;

		// Token: 0x0400063E RID: 1598
		private readonly IntPtr mediaAssets;

		// Token: 0x0400063F RID: 1599
		private readonly SizeT mediaAssetsCount;

		// Token: 0x04000640 RID: 1600
		private readonly IntPtr platformsAvailableOn;

		// Token: 0x04000641 RID: 1601
		private readonly SizeT platformsAvailableOnCount;

		// Token: 0x04000642 RID: 1602
		[MarshalAs(UnmanagedType.U1)]
		internal readonly bool isSecret;

		// Token: 0x04000643 RID: 1603
		internal readonly UTF8StringPtr unlockedDescription;

		// Token: 0x04000644 RID: 1604
		internal readonly UTF8StringPtr lockedDescription;

		// Token: 0x04000645 RID: 1605
		internal readonly UTF8StringPtr productId;

		// Token: 0x04000646 RID: 1606
		internal readonly XblAchievementType type;

		// Token: 0x04000647 RID: 1607
		internal readonly XblAchievementParticipationType participationType;

		// Token: 0x04000648 RID: 1608
		internal readonly XblAchievementTimeWindow available;

		// Token: 0x04000649 RID: 1609
		private readonly IntPtr rewards;

		// Token: 0x0400064A RID: 1610
		private readonly SizeT rewardsCount;

		// Token: 0x0400064B RID: 1611
		internal readonly ulong estimatedUnlockTime;

		// Token: 0x0400064C RID: 1612
		internal readonly UTF8StringPtr deepLink;

		// Token: 0x0400064D RID: 1613
		[MarshalAs(UnmanagedType.U1)]
		internal readonly bool isRevoked;
	}
}
