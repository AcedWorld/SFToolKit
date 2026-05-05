using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000203 RID: 515
	internal struct XblMultiplayerSessionProperties
	{
		// Token: 0x06000DAF RID: 3503 RVA: 0x0001091D File Offset: 0x0000EB1D
		internal string[] GetKeywords()
		{
			return Converters.PtrToClassArray<string, UTF8StringPtr>(this.Keywords, this.KeywordCount, (UTF8StringPtr s) => s.GetString());
		}

		// Token: 0x06000DB0 RID: 3504 RVA: 0x0001094F File Offset: 0x0000EB4F
		internal T[] GetTurnCollection<T>(Func<uint, T> ctor)
		{
			return Converters.PtrToClassArray<T, uint>(this.TurnCollection, this.TurnCollectionCount, ctor);
		}

		// Token: 0x06000DB1 RID: 3505 RVA: 0x00010963 File Offset: 0x0000EB63
		internal string[] GetServerConnectionStringCandidates()
		{
			return Converters.PtrToClassArray<string, UTF8StringPtr>(this.ServerConnectionStringCandidates, this.ServerConnectionStringCandidatesCount, (UTF8StringPtr s) => s.GetString());
		}

		// Token: 0x06000DB2 RID: 3506 RVA: 0x00010995 File Offset: 0x0000EB95
		internal T[] GetSessionOwnerMemberIds<T>(Func<uint, T> ctor)
		{
			return Converters.PtrToClassArray<T, uint>(this.SessionOwnerMemberIds, this.SessionOwnerMemberIdsCount, ctor);
		}

		// Token: 0x040006F6 RID: 1782
		internal readonly IntPtr Keywords;

		// Token: 0x040006F7 RID: 1783
		internal readonly SizeT KeywordCount;

		// Token: 0x040006F8 RID: 1784
		internal XblMultiplayerSessionRestriction JoinRestriction;

		// Token: 0x040006F9 RID: 1785
		internal XblMultiplayerSessionRestriction ReadRestriction;

		// Token: 0x040006FA RID: 1786
		private readonly IntPtr TurnCollection;

		// Token: 0x040006FB RID: 1787
		private readonly SizeT TurnCollectionCount;

		// Token: 0x040006FC RID: 1788
		internal readonly UTF8StringPtr MatchmakingTargetSessionConstantsJson;

		// Token: 0x040006FD RID: 1789
		internal readonly UTF8StringPtr SessionCustomPropertiesJson;

		// Token: 0x040006FE RID: 1790
		internal readonly UTF8StringPtr MatchmakingServerConnectionString;

		// Token: 0x040006FF RID: 1791
		private readonly IntPtr ServerConnectionStringCandidates;

		// Token: 0x04000700 RID: 1792
		private readonly SizeT ServerConnectionStringCandidatesCount;

		// Token: 0x04000701 RID: 1793
		private readonly IntPtr SessionOwnerMemberIds;

		// Token: 0x04000702 RID: 1794
		private readonly SizeT SessionOwnerMemberIdsCount;

		// Token: 0x04000703 RID: 1795
		internal readonly XblDeviceToken HostDeviceToken;

		// Token: 0x04000704 RID: 1796
		[MarshalAs(UnmanagedType.U1)]
		internal bool Closed;

		// Token: 0x04000705 RID: 1797
		[MarshalAs(UnmanagedType.U1)]
		internal bool Locked;

		// Token: 0x04000706 RID: 1798
		[MarshalAs(UnmanagedType.U1)]
		internal bool AllocateCloudCompute;

		// Token: 0x04000707 RID: 1799
		[MarshalAs(UnmanagedType.U1)]
		internal bool MatchmakingResubmit;
	}
}
