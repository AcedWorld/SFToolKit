using System;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000219 RID: 537
	internal struct XblTournamentTeamResult
	{
		// Token: 0x06000DD0 RID: 3536 RVA: 0x000110D6 File Offset: 0x0000F2D6
		internal XblTournamentTeamResult(XblTournamentTeamResult publicObject, DisposableCollection disposableCollection)
		{
			this.Team = new UTF8StringPtr(publicObject.Team, disposableCollection);
			this.GameResult = new XblTournamentGameResultWithRank(publicObject.GameResult);
		}

		// Token: 0x04000772 RID: 1906
		internal readonly UTF8StringPtr Team;

		// Token: 0x04000773 RID: 1907
		internal readonly XblTournamentGameResultWithRank GameResult;
	}
}
