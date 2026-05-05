using System;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000218 RID: 536
	internal struct XblTournamentGameResultWithRank
	{
		// Token: 0x06000DCF RID: 3535 RVA: 0x000110BC File Offset: 0x0000F2BC
		internal XblTournamentGameResultWithRank(XblTournamentGameResultWithRank publicObject)
		{
			this.Result = publicObject.Result;
			this.Ranking = publicObject.Ranking;
		}

		// Token: 0x04000770 RID: 1904
		internal readonly XblTournamentGameResult Result;

		// Token: 0x04000771 RID: 1905
		internal readonly ulong Ranking;
	}
}
