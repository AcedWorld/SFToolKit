using System;
using Unity.Services.Core.Telemetry.Internal;
using Unity.Services.Lobbies.Apis.Lobby;
using Unity.Services.Wire.Internal;

namespace Unity.Services.Lobbies
{
	// Token: 0x0200000D RID: 13
	internal interface ILobbyServiceSdk
	{
		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600004B RID: 75
		ILobbyApiClient LobbyApi { get; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600004C RID: 76
		Configuration Configuration { get; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600004D RID: 77
		// (set) Token: 0x0600004E RID: 78
		IWire Wire { get; set; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600004F RID: 79
		IMetrics Metrics { get; }
	}
}
