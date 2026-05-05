using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200007F RID: 127
	[MovedFrom("Unity.GameCore")]
	public class XblLeaderboardQuery
	{
		// Token: 0x06000474 RID: 1140 RVA: 0x00009DD4 File Offset: 0x00007FD4
		private XblLeaderboardQuery(ulong xboxUserId, string serviceConfigurationId, string leaderboardName, string statName, XblSocialGroupType socialGroup, string[] additionalColumnleaderboardNames, XblLeaderboardSortOrder order, uint maxItems, ulong skipToXboxUserId, uint skipResultToRank, string continuationToken, XblLeaderboardQueryType queryType)
		{
			this.XboxUserId = xboxUserId;
			this.ServiceConfigurationId = serviceConfigurationId;
			this.LeaderboardName = leaderboardName;
			this.StatName = statName;
			this.SocialGroup = socialGroup;
			this.AdditionalColumnleaderboardNames = additionalColumnleaderboardNames;
			this.Order = order;
			this.MaxItems = maxItems;
			this.SkipToXboxUserId = skipToXboxUserId;
			this.SkipResultToRank = skipResultToRank;
			this.ContinuationToken = continuationToken;
			this.QueryType = queryType;
		}

		// Token: 0x06000475 RID: 1141 RVA: 0x00009E44 File Offset: 0x00008044
		internal XblLeaderboardQuery(XblLeaderboardQuery interopLeaderboardQuery)
		{
			this.XboxUserId = interopLeaderboardQuery.xboxUserId;
			this.ServiceConfigurationId = interopLeaderboardQuery.GetScid();
			this.LeaderboardName = interopLeaderboardQuery.leaderboardName.GetString();
			this.StatName = interopLeaderboardQuery.statName.GetString();
			this.SocialGroup = interopLeaderboardQuery.socialGroup;
			this.AdditionalColumnleaderboardNames = interopLeaderboardQuery.GetAdditionalColumnleaderboardNames();
			this.Order = interopLeaderboardQuery.order;
			this.MaxItems = interopLeaderboardQuery.maxItems;
			this.SkipToXboxUserId = interopLeaderboardQuery.skipToXboxUserId;
			this.SkipResultToRank = interopLeaderboardQuery.skipResultToRank;
			this.ContinuationToken = interopLeaderboardQuery.continuationToken.GetString();
			this.QueryType = interopLeaderboardQuery.queryType;
		}

		// Token: 0x06000476 RID: 1142 RVA: 0x00009F04 File Offset: 0x00008104
		public static int Create(ulong xboxUserId, string serviceConfigurationId, string leaderboardName, string statName, XblSocialGroupType socialGroup, string[] additionalColumnleaderboardNames, XblLeaderboardSortOrder order, uint maxItems, ulong skipToXboxUserId, uint skipResultToRank, string continuationToken, XblLeaderboardQueryType queryType, out XblLeaderboardQuery leaderboardQuery)
		{
			if (!XblLeaderboardQuery.ValidateFields(serviceConfigurationId))
			{
				leaderboardQuery = null;
				return -2147024809;
			}
			leaderboardQuery = new XblLeaderboardQuery(xboxUserId, serviceConfigurationId, leaderboardName, statName, socialGroup, additionalColumnleaderboardNames, order, maxItems, skipToXboxUserId, skipResultToRank, continuationToken, queryType);
			return 0;
		}

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x06000477 RID: 1143 RVA: 0x00009F40 File Offset: 0x00008140
		// (set) Token: 0x06000478 RID: 1144 RVA: 0x00009F48 File Offset: 0x00008148
		public ulong XboxUserId { get; private set; }

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x06000479 RID: 1145 RVA: 0x00009F51 File Offset: 0x00008151
		// (set) Token: 0x0600047A RID: 1146 RVA: 0x00009F59 File Offset: 0x00008159
		public string ServiceConfigurationId { get; private set; }

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x0600047B RID: 1147 RVA: 0x00009F62 File Offset: 0x00008162
		// (set) Token: 0x0600047C RID: 1148 RVA: 0x00009F6A File Offset: 0x0000816A
		public string LeaderboardName { get; private set; }

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x0600047D RID: 1149 RVA: 0x00009F73 File Offset: 0x00008173
		// (set) Token: 0x0600047E RID: 1150 RVA: 0x00009F7B File Offset: 0x0000817B
		public string StatName { get; private set; }

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x0600047F RID: 1151 RVA: 0x00009F84 File Offset: 0x00008184
		// (set) Token: 0x06000480 RID: 1152 RVA: 0x00009F8C File Offset: 0x0000818C
		public XblSocialGroupType SocialGroup { get; private set; }

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x06000481 RID: 1153 RVA: 0x00009F95 File Offset: 0x00008195
		// (set) Token: 0x06000482 RID: 1154 RVA: 0x00009F9D File Offset: 0x0000819D
		public string[] AdditionalColumnleaderboardNames { get; private set; }

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x06000483 RID: 1155 RVA: 0x00009FA6 File Offset: 0x000081A6
		// (set) Token: 0x06000484 RID: 1156 RVA: 0x00009FAE File Offset: 0x000081AE
		public XblLeaderboardSortOrder Order { get; private set; }

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x06000485 RID: 1157 RVA: 0x00009FB7 File Offset: 0x000081B7
		// (set) Token: 0x06000486 RID: 1158 RVA: 0x00009FBF File Offset: 0x000081BF
		public uint MaxItems { get; private set; }

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x06000487 RID: 1159 RVA: 0x00009FC8 File Offset: 0x000081C8
		// (set) Token: 0x06000488 RID: 1160 RVA: 0x00009FD0 File Offset: 0x000081D0
		public ulong SkipToXboxUserId { get; private set; }

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x06000489 RID: 1161 RVA: 0x00009FD9 File Offset: 0x000081D9
		// (set) Token: 0x0600048A RID: 1162 RVA: 0x00009FE1 File Offset: 0x000081E1
		public uint SkipResultToRank { get; private set; }

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x0600048B RID: 1163 RVA: 0x00009FEA File Offset: 0x000081EA
		// (set) Token: 0x0600048C RID: 1164 RVA: 0x00009FF2 File Offset: 0x000081F2
		public string ContinuationToken { get; private set; }

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x0600048D RID: 1165 RVA: 0x00009FFB File Offset: 0x000081FB
		// (set) Token: 0x0600048E RID: 1166 RVA: 0x0000A003 File Offset: 0x00008203
		public XblLeaderboardQueryType QueryType { get; private set; }
	}
}
