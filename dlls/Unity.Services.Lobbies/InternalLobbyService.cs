using System;
using Unity.Services.Authentication.Internal;
using Unity.Services.Core.Telemetry.Internal;
using Unity.Services.Lobbies.Apis.Lobby;
using Unity.Services.Lobbies.Http;
using Unity.Services.Wire.Internal;

namespace Unity.Services.Lobbies
{
	// Token: 0x0200000B RID: 11
	internal class InternalLobbyService : ILobbyServiceSdk
	{
		// Token: 0x06000041 RID: 65 RVA: 0x000046EC File Offset: 0x000028EC
		public InternalLobbyService(HttpClient httpClient, IAccessToken accessToken = null, IWire subscriptionFactory = null, IMetrics metrics = null)
		{
			this.LobbyApi = new LobbyApiClient(httpClient, accessToken, null);
			this.Configuration = new Configuration("https://lobby.services.api.unity.com/v1", new int?(10), new int?(4), null);
			this.Wire = subscriptionFactory;
			this.Metrics = metrics;
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000042 RID: 66 RVA: 0x0000473A File Offset: 0x0000293A
		// (set) Token: 0x06000043 RID: 67 RVA: 0x00004742 File Offset: 0x00002942
		public ILobbyApiClient LobbyApi { get; set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000044 RID: 68 RVA: 0x0000474B File Offset: 0x0000294B
		// (set) Token: 0x06000045 RID: 69 RVA: 0x00004753 File Offset: 0x00002953
		public Configuration Configuration { get; set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000046 RID: 70 RVA: 0x0000475C File Offset: 0x0000295C
		// (set) Token: 0x06000047 RID: 71 RVA: 0x00004764 File Offset: 0x00002964
		public IWire Wire { get; set; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000048 RID: 72 RVA: 0x0000476D File Offset: 0x0000296D
		public IMetrics Metrics { get; }
	}
}
