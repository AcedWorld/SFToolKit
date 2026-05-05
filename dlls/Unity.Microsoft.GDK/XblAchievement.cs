using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000061 RID: 97
	[MovedFrom("Unity.GameCore")]
	public class XblAchievement
	{
		// Token: 0x060003F2 RID: 1010 RVA: 0x00009508 File Offset: 0x00007708
		internal XblAchievement(XblAchievement interopAchievement)
		{
			this.Id = interopAchievement.id.GetString();
			this.ServiceConfigurationId = interopAchievement.serviceConfigurationId.GetString();
			this.Name = interopAchievement.name.GetString();
			this.TitleAssociations = interopAchievement.GetTitleAssociations<XblAchievementTitleAssociation>((XblAchievementTitleAssociation ta) => new XblAchievementTitleAssociation(ta));
			this.ProgressState = interopAchievement.progressState;
			this.Progression = new XblAchievementProgression(interopAchievement.progression);
			this.MediaAssets = interopAchievement.GetMediaAssets<XblAchievementMediaAsset>((XblAchievementMediaAsset ma) => new XblAchievementMediaAsset(ma));
			this.PlatformsAvailableOn = interopAchievement.GetPlatformsAvailableOn();
			this.IsSecret = interopAchievement.isSecret;
			this.UnlockedDescription = interopAchievement.unlockedDescription.GetString();
			this.LockedDescription = interopAchievement.lockedDescription.GetString();
			this.ProductId = interopAchievement.productId.GetString();
			this.Type = interopAchievement.type;
			this.ParticipationType = interopAchievement.participationType;
			this.Available = new XblAchievementTimeWindow(interopAchievement.available);
			this.Rewards = interopAchievement.GetRewards<XblAchievementReward>((XblAchievementReward reward) => new XblAchievementReward(reward));
			this.EstimatedUnlockTime = interopAchievement.estimatedUnlockTime;
			this.DeepLink = interopAchievement.deepLink.GetString();
			this.IsRevoked = interopAchievement.isRevoked;
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x060003F3 RID: 1011 RVA: 0x000096A2 File Offset: 0x000078A2
		// (set) Token: 0x060003F4 RID: 1012 RVA: 0x000096AA File Offset: 0x000078AA
		public string Id { get; private set; }

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x060003F5 RID: 1013 RVA: 0x000096B3 File Offset: 0x000078B3
		// (set) Token: 0x060003F6 RID: 1014 RVA: 0x000096BB File Offset: 0x000078BB
		public string ServiceConfigurationId { get; private set; }

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x060003F7 RID: 1015 RVA: 0x000096C4 File Offset: 0x000078C4
		// (set) Token: 0x060003F8 RID: 1016 RVA: 0x000096CC File Offset: 0x000078CC
		public string Name { get; private set; }

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x060003F9 RID: 1017 RVA: 0x000096D5 File Offset: 0x000078D5
		// (set) Token: 0x060003FA RID: 1018 RVA: 0x000096DD File Offset: 0x000078DD
		public XblAchievementTitleAssociation[] TitleAssociations { get; private set; }

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x060003FB RID: 1019 RVA: 0x000096E6 File Offset: 0x000078E6
		// (set) Token: 0x060003FC RID: 1020 RVA: 0x000096EE File Offset: 0x000078EE
		public XblAchievementProgressState ProgressState { get; private set; }

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x060003FD RID: 1021 RVA: 0x000096F7 File Offset: 0x000078F7
		// (set) Token: 0x060003FE RID: 1022 RVA: 0x000096FF File Offset: 0x000078FF
		public XblAchievementProgression Progression { get; private set; }

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x060003FF RID: 1023 RVA: 0x00009708 File Offset: 0x00007908
		// (set) Token: 0x06000400 RID: 1024 RVA: 0x00009710 File Offset: 0x00007910
		public XblAchievementMediaAsset[] MediaAssets { get; private set; }

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x06000401 RID: 1025 RVA: 0x00009719 File Offset: 0x00007919
		// (set) Token: 0x06000402 RID: 1026 RVA: 0x00009721 File Offset: 0x00007921
		public string[] PlatformsAvailableOn { get; private set; }

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x06000403 RID: 1027 RVA: 0x0000972A File Offset: 0x0000792A
		// (set) Token: 0x06000404 RID: 1028 RVA: 0x00009732 File Offset: 0x00007932
		public bool IsSecret { get; private set; }

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x06000405 RID: 1029 RVA: 0x0000973B File Offset: 0x0000793B
		// (set) Token: 0x06000406 RID: 1030 RVA: 0x00009743 File Offset: 0x00007943
		public string UnlockedDescription { get; private set; }

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x06000407 RID: 1031 RVA: 0x0000974C File Offset: 0x0000794C
		// (set) Token: 0x06000408 RID: 1032 RVA: 0x00009754 File Offset: 0x00007954
		public string LockedDescription { get; private set; }

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x06000409 RID: 1033 RVA: 0x0000975D File Offset: 0x0000795D
		// (set) Token: 0x0600040A RID: 1034 RVA: 0x00009765 File Offset: 0x00007965
		public string ProductId { get; private set; }

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x0600040B RID: 1035 RVA: 0x0000976E File Offset: 0x0000796E
		// (set) Token: 0x0600040C RID: 1036 RVA: 0x00009776 File Offset: 0x00007976
		public XblAchievementType Type { get; private set; }

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x0600040D RID: 1037 RVA: 0x0000977F File Offset: 0x0000797F
		// (set) Token: 0x0600040E RID: 1038 RVA: 0x00009787 File Offset: 0x00007987
		public XblAchievementParticipationType ParticipationType { get; private set; }

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x0600040F RID: 1039 RVA: 0x00009790 File Offset: 0x00007990
		// (set) Token: 0x06000410 RID: 1040 RVA: 0x00009798 File Offset: 0x00007998
		public XblAchievementTimeWindow Available { get; private set; }

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x06000411 RID: 1041 RVA: 0x000097A1 File Offset: 0x000079A1
		// (set) Token: 0x06000412 RID: 1042 RVA: 0x000097A9 File Offset: 0x000079A9
		public XblAchievementReward[] Rewards { get; private set; }

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x06000413 RID: 1043 RVA: 0x000097B2 File Offset: 0x000079B2
		// (set) Token: 0x06000414 RID: 1044 RVA: 0x000097BA File Offset: 0x000079BA
		public ulong EstimatedUnlockTime { get; private set; }

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x06000415 RID: 1045 RVA: 0x000097C3 File Offset: 0x000079C3
		// (set) Token: 0x06000416 RID: 1046 RVA: 0x000097CB File Offset: 0x000079CB
		public string DeepLink { get; private set; }

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x06000417 RID: 1047 RVA: 0x000097D4 File Offset: 0x000079D4
		// (set) Token: 0x06000418 RID: 1048 RVA: 0x000097DC File Offset: 0x000079DC
		public bool IsRevoked { get; private set; }
	}
}
