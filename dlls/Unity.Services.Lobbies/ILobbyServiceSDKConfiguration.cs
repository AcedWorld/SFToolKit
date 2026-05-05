using System;

namespace Unity.Services.Lobbies
{
	// Token: 0x02000013 RID: 19
	public interface ILobbyServiceSDKConfiguration
	{
		// Token: 0x06000071 RID: 113
		void SetBasePath(string basePath);

		// Token: 0x06000072 RID: 114
		void EnableLocalPlayerLobbyEvents(bool enabled);
	}
}
