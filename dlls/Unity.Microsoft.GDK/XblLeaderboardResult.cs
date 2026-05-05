using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x02000081 RID: 129
	[MovedFrom("Unity.GameCore")]
	public class XblLeaderboardResult
	{
		// Token: 0x0600048F RID: 1167 RVA: 0x0000A00C File Offset: 0x0000820C
		internal XblLeaderboardResult(XblLeaderboardResult interopResult)
		{
			this.TotalRowCount = interopResult.totalRowCount;
			this.Columns = interopResult.GetColumns<XblLeaderboardColumn>((XblLeaderboardColumn c) => new XblLeaderboardColumn(c));
			this.Rows = interopResult.GetRows<XblLeaderboardRow>((XblLeaderboardRow r) => new XblLeaderboardRow(r));
			this.HasNext = interopResult.hasNext.Value;
			this.NextQuery = new XblLeaderboardQuery(interopResult.nextQuery);
		}

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x06000490 RID: 1168 RVA: 0x0000A0A8 File Offset: 0x000082A8
		// (set) Token: 0x06000491 RID: 1169 RVA: 0x0000A0B0 File Offset: 0x000082B0
		public uint TotalRowCount { get; private set; }

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x06000492 RID: 1170 RVA: 0x0000A0B9 File Offset: 0x000082B9
		// (set) Token: 0x06000493 RID: 1171 RVA: 0x0000A0C1 File Offset: 0x000082C1
		public XblLeaderboardColumn[] Columns { get; private set; }

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x06000494 RID: 1172 RVA: 0x0000A0CA File Offset: 0x000082CA
		// (set) Token: 0x06000495 RID: 1173 RVA: 0x0000A0D2 File Offset: 0x000082D2
		public XblLeaderboardRow[] Rows { get; private set; }

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x06000496 RID: 1174 RVA: 0x0000A0DB File Offset: 0x000082DB
		// (set) Token: 0x06000497 RID: 1175 RVA: 0x0000A0E3 File Offset: 0x000082E3
		public bool HasNext { get; private set; }

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x06000498 RID: 1176 RVA: 0x0000A0EC File Offset: 0x000082EC
		// (set) Token: 0x06000499 RID: 1177 RVA: 0x0000A0F4 File Offset: 0x000082F4
		public XblLeaderboardQuery NextQuery { get; private set; }
	}
}
