using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000205 RID: 517
	internal struct XblMultiplayerSessionQueryResult
	{
		// Token: 0x04000713 RID: 1811
		internal TimeT StartTime;

		// Token: 0x04000714 RID: 1812
		internal XblMultiplayerSessionReference SessionReference;

		// Token: 0x04000715 RID: 1813
		internal XblMultiplayerSessionStatus Status;

		// Token: 0x04000716 RID: 1814
		internal XblMultiplayerSessionVisibility Visibility;

		// Token: 0x04000717 RID: 1815
		[MarshalAs(UnmanagedType.U1)]
		internal bool IsMyTurn;

		// Token: 0x04000718 RID: 1816
		internal ulong Xuid;

		// Token: 0x04000719 RID: 1817
		internal uint AcceptedMemberCount;

		// Token: 0x0400071A RID: 1818
		internal XblMultiplayerSessionRestriction JoinRestriction;
	}
}
