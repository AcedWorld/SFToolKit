using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x020000C4 RID: 196
	[MovedFrom("Unity.GameCore")]
	public class XblTournamentTeamResult
	{
		// Token: 0x060005B7 RID: 1463 RVA: 0x0000B710 File Offset: 0x00009910
		internal XblTournamentTeamResult(XblTournamentTeamResult interopStruct)
		{
			this.Team = interopStruct.Team.GetString();
			this.GameResult = new XblTournamentGameResultWithRank(interopStruct.GameResult);
		}

		// Token: 0x1700017C RID: 380
		// (get) Token: 0x060005B8 RID: 1464 RVA: 0x0000B748 File Offset: 0x00009948
		public string Team { get; }

		// Token: 0x1700017D RID: 381
		// (get) Token: 0x060005B9 RID: 1465 RVA: 0x0000B750 File Offset: 0x00009950
		public XblTournamentGameResultWithRank GameResult { get; }
	}
}
