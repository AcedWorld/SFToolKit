using System;

namespace Unity.Services.Lobbies
{
	// Token: 0x02000017 RID: 23
	public static class Lobbies
	{
		// Token: 0x06000083 RID: 131 RVA: 0x00004932 File Offset: 0x00002B32
		public static void SetBasePath(string basePath)
		{
			((ILobbyServiceSDKConfiguration)Lobbies.Instance).SetBasePath(basePath);
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000084 RID: 132 RVA: 0x00004944 File Offset: 0x00002B44
		public static ILobbyServiceSDK Instance
		{
			get
			{
				return (ILobbyServiceSDK)LobbyService.Instance;
			}
		}
	}
}
