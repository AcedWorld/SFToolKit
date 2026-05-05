using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200006B RID: 107
	[MovedFrom("Unity.GameCore")]
	public class XblAchievementReward
	{
		// Token: 0x06000435 RID: 1077 RVA: 0x00009A28 File Offset: 0x00007C28
		internal XblAchievementReward(XblAchievementReward interopReward)
		{
			this.Name = interopReward.name.GetString();
			this.Description = interopReward.description.GetString();
			this.Value = interopReward.value.GetString();
			this.RewardType = interopReward.rewardType;
			this.ValueType = interopReward.valueType.GetString();
			this.MediaAsset = interopReward.GetMediaAsset<XblAchievementMediaAsset>((XblAchievementMediaAsset ma) => new XblAchievementMediaAsset(ma));
		}

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x06000436 RID: 1078 RVA: 0x00009AC3 File Offset: 0x00007CC3
		// (set) Token: 0x06000437 RID: 1079 RVA: 0x00009ACB File Offset: 0x00007CCB
		public string Name { get; private set; }

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x06000438 RID: 1080 RVA: 0x00009AD4 File Offset: 0x00007CD4
		// (set) Token: 0x06000439 RID: 1081 RVA: 0x00009ADC File Offset: 0x00007CDC
		public string Description { get; private set; }

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x0600043A RID: 1082 RVA: 0x00009AE5 File Offset: 0x00007CE5
		// (set) Token: 0x0600043B RID: 1083 RVA: 0x00009AED File Offset: 0x00007CED
		public string Value { get; private set; }

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x0600043C RID: 1084 RVA: 0x00009AF6 File Offset: 0x00007CF6
		// (set) Token: 0x0600043D RID: 1085 RVA: 0x00009AFE File Offset: 0x00007CFE
		public XblAchievementRewardType RewardType { get; private set; }

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x0600043E RID: 1086 RVA: 0x00009B07 File Offset: 0x00007D07
		// (set) Token: 0x0600043F RID: 1087 RVA: 0x00009B0F File Offset: 0x00007D0F
		public string ValueType { get; private set; }

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x06000440 RID: 1088 RVA: 0x00009B18 File Offset: 0x00007D18
		// (set) Token: 0x06000441 RID: 1089 RVA: 0x00009B20 File Offset: 0x00007D20
		public XblAchievementMediaAsset MediaAsset { get; private set; }
	}
}
