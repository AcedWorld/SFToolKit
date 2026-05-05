using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000082 RID: 130
	[MovedFrom("Unity.GameCore")]
	public class XblLeaderboardRow
	{
		// Token: 0x0600049A RID: 1178 RVA: 0x0000A100 File Offset: 0x00008300
		internal XblLeaderboardRow(XblLeaderboardRow interopRow)
		{
			this.Gamertag = Converters.ByteArrayToString(interopRow.gamertag);
			this.ModernGamertag = Converters.ByteArrayToString(interopRow.modernGamertag);
			this.ModernGamertagSuffix = Converters.ByteArrayToString(interopRow.modernGamertagSuffix);
			this.UniqueModernGamertag = Converters.ByteArrayToString(interopRow.uniqueModernGamertag);
			this.XboxUserId = interopRow.xboxUserId;
			this.Percentile = interopRow.percentile;
			this.Rank = interopRow.rank;
			this.GlobalRank = interopRow.globalRank;
			this.ColumnValues = interopRow.GetColumnValues();
		}

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x0600049B RID: 1179 RVA: 0x0000A194 File Offset: 0x00008394
		// (set) Token: 0x0600049C RID: 1180 RVA: 0x0000A19C File Offset: 0x0000839C
		public string Gamertag { get; private set; }

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x0600049D RID: 1181 RVA: 0x0000A1A5 File Offset: 0x000083A5
		// (set) Token: 0x0600049E RID: 1182 RVA: 0x0000A1AD File Offset: 0x000083AD
		public string ModernGamertag { get; private set; }

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x0600049F RID: 1183 RVA: 0x0000A1B6 File Offset: 0x000083B6
		// (set) Token: 0x060004A0 RID: 1184 RVA: 0x0000A1BE File Offset: 0x000083BE
		public string ModernGamertagSuffix { get; private set; }

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x060004A1 RID: 1185 RVA: 0x0000A1C7 File Offset: 0x000083C7
		// (set) Token: 0x060004A2 RID: 1186 RVA: 0x0000A1CF File Offset: 0x000083CF
		public string UniqueModernGamertag { get; private set; }

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x060004A3 RID: 1187 RVA: 0x0000A1D8 File Offset: 0x000083D8
		// (set) Token: 0x060004A4 RID: 1188 RVA: 0x0000A1E0 File Offset: 0x000083E0
		public ulong XboxUserId { get; private set; }

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x060004A5 RID: 1189 RVA: 0x0000A1E9 File Offset: 0x000083E9
		// (set) Token: 0x060004A6 RID: 1190 RVA: 0x0000A1F1 File Offset: 0x000083F1
		public double Percentile { get; private set; }

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x060004A7 RID: 1191 RVA: 0x0000A1FA File Offset: 0x000083FA
		// (set) Token: 0x060004A8 RID: 1192 RVA: 0x0000A202 File Offset: 0x00008402
		public uint Rank { get; private set; }

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x060004A9 RID: 1193 RVA: 0x0000A20B File Offset: 0x0000840B
		// (set) Token: 0x060004AA RID: 1194 RVA: 0x0000A213 File Offset: 0x00008413
		public uint GlobalRank { get; private set; }

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x060004AB RID: 1195 RVA: 0x0000A21C File Offset: 0x0000841C
		// (set) Token: 0x060004AC RID: 1196 RVA: 0x0000A224 File Offset: 0x00008424
		public string[] ColumnValues { get; private set; }
	}
}
