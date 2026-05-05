using System;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x0200020F RID: 527
	internal struct XblMultiplayerManagerMember
	{
		// Token: 0x06000DC0 RID: 3520 RVA: 0x00010CD0 File Offset: 0x0000EED0
		internal XblMultiplayerManagerMember(XblMultiplayerManagerMember publicObject, DisposableCollection disposableCollection)
		{
			this.MemberId = publicObject.MemberId;
			this.TeamId = new UTF8StringPtr(publicObject.TeamId, disposableCollection);
			this.InitialTeam = new UTF8StringPtr(publicObject.InitialTeam, disposableCollection);
			this.Xuid = publicObject.Xuid;
			this.DebugGamertag = new UTF8StringPtr(publicObject.DebugGamertag, disposableCollection);
			this.IsLocal = new NativeBool(publicObject.IsLocal);
			this.IsInLobby = new NativeBool(publicObject.IsInLobby);
			this.IsInGame = new NativeBool(publicObject.IsInGame);
			this.Status = publicObject.Status;
			this.ConnectionAddress = new UTF8StringPtr(publicObject.ConnectionAddress, disposableCollection);
			this.PropertiesJson = new UTF8StringPtr(publicObject.PropertiesJson, disposableCollection);
			this.DeviceToken = new UTF8StringPtr(publicObject.DeviceToken, disposableCollection);
		}

		// Token: 0x04000732 RID: 1842
		internal readonly uint MemberId;

		// Token: 0x04000733 RID: 1843
		internal readonly UTF8StringPtr TeamId;

		// Token: 0x04000734 RID: 1844
		internal readonly UTF8StringPtr InitialTeam;

		// Token: 0x04000735 RID: 1845
		internal readonly ulong Xuid;

		// Token: 0x04000736 RID: 1846
		internal readonly UTF8StringPtr DebugGamertag;

		// Token: 0x04000737 RID: 1847
		internal readonly NativeBool IsLocal;

		// Token: 0x04000738 RID: 1848
		internal readonly NativeBool IsInLobby;

		// Token: 0x04000739 RID: 1849
		internal readonly NativeBool IsInGame;

		// Token: 0x0400073A RID: 1850
		internal readonly XblMultiplayerSessionMemberStatus Status;

		// Token: 0x0400073B RID: 1851
		internal readonly UTF8StringPtr ConnectionAddress;

		// Token: 0x0400073C RID: 1852
		internal readonly UTF8StringPtr PropertiesJson;

		// Token: 0x0400073D RID: 1853
		internal readonly UTF8StringPtr DeviceToken;
	}
}
