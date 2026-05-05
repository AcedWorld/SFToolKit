using System;
using Unity.Services.Lobbies.Internal;

namespace Unity.Services.Lobbies
{
	// Token: 0x02000016 RID: 22
	public static class LobbyService
	{
		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600007D RID: 125 RVA: 0x000048CA File Offset: 0x00002ACA
		// (set) Token: 0x0600007E RID: 126 RVA: 0x000048D1 File Offset: 0x00002AD1
		internal static ILobbyService service { get; set; }

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000080 RID: 128 RVA: 0x000048F8 File Offset: 0x00002AF8
		// (set) Token: 0x06000081 RID: 129 RVA: 0x0000490B File Offset: 0x00002B0B
		public static ILobbyService Instance
		{
			get
			{
				if (LobbyService.service == null)
				{
					LobbyService.InitializeWrappedLobbyService();
				}
				return LobbyService.service;
			}
			internal set
			{
				LobbyService.service = value;
			}
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00004913 File Offset: 0x00002B13
		private static void InitializeWrappedLobbyService()
		{
			ILobbyServiceSdk instance = LobbyServiceSdk.Instance;
			if (instance == null)
			{
				throw new InvalidOperationException("Unable to get ILobbyServiceSdk because Lobby API is not initialized. Make sure you call UnityServices.InitializeAsync().");
			}
			LobbyService.service = new WrappedLobbyService(instance);
		}

		// Token: 0x04000062 RID: 98
		private static readonly Configuration configuration = new Configuration("https://lobby.services.api.unity.com/v1", new int?(10), new int?(4), null);
	}
}
