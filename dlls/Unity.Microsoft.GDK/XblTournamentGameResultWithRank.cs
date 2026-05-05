using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x020000C1 RID: 193
	[MovedFrom("Unity.GameCore")]
	public class XblTournamentGameResultWithRank
	{
		// Token: 0x060005B4 RID: 1460 RVA: 0x0000B6DE File Offset: 0x000098DE
		internal XblTournamentGameResultWithRank(XblTournamentGameResultWithRank interopStruct)
		{
			this.Result = interopStruct.Result;
			this.Ranking = interopStruct.Ranking;
		}

		// Token: 0x1700017A RID: 378
		// (get) Token: 0x060005B5 RID: 1461 RVA: 0x0000B6FE File Offset: 0x000098FE
		public XblTournamentGameResult Result { get; }

		// Token: 0x1700017B RID: 379
		// (get) Token: 0x060005B6 RID: 1462 RVA: 0x0000B706 File Offset: 0x00009906
		public ulong Ranking { get; }
	}
}
