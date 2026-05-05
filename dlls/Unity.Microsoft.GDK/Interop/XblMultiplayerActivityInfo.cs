using System;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000208 RID: 520
	internal struct XblMultiplayerActivityInfo
	{
		// Token: 0x06000DB9 RID: 3513 RVA: 0x00010B70 File Offset: 0x0000ED70
		internal XblMultiplayerActivityInfo(XblMultiplayerActivityInfo publicObject, DisposableCollection disposableCollection)
		{
			this.xuid = publicObject.Xuid;
			this.connectionString = new UTF8StringPtr(publicObject.ConnectionString, disposableCollection);
			this.joinRestriction = publicObject.JoinRestriction;
			this.maxPlayers = new SizeT(publicObject.MaxPlayers);
			this.currentPlayers = new SizeT(publicObject.CurrentPlayers);
			this.groupId = new UTF8StringPtr(publicObject.GroupId, disposableCollection);
			this.platform = publicObject.Platform;
		}

		// Token: 0x0400071E RID: 1822
		internal readonly ulong xuid;

		// Token: 0x0400071F RID: 1823
		internal readonly UTF8StringPtr connectionString;

		// Token: 0x04000720 RID: 1824
		internal readonly XblMultiplayerActivityJoinRestriction joinRestriction;

		// Token: 0x04000721 RID: 1825
		internal readonly SizeT maxPlayers;

		// Token: 0x04000722 RID: 1826
		internal readonly SizeT currentPlayers;

		// Token: 0x04000723 RID: 1827
		internal readonly UTF8StringPtr groupId;

		// Token: 0x04000724 RID: 1828
		internal readonly XblMultiplayerActivityPlatform platform;
	}
}
