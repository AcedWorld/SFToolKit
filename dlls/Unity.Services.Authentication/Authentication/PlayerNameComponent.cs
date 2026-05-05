using System;
using Unity.Services.Authentication.Internal;

namespace Unity.Services.Authentication
{
	// Token: 0x02000013 RID: 19
	internal class PlayerNameComponent : IPlayerName
	{
		// Token: 0x14000011 RID: 17
		// (add) Token: 0x06000122 RID: 290 RVA: 0x00004A04 File Offset: 0x00002C04
		// (remove) Token: 0x06000123 RID: 291 RVA: 0x00004A3C File Offset: 0x00002C3C
		public event Action<string> PlayerNameChanged;

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000124 RID: 292 RVA: 0x00004A71 File Offset: 0x00002C71
		// (set) Token: 0x06000125 RID: 293 RVA: 0x00004A79 File Offset: 0x00002C79
		public string PlayerName
		{
			get
			{
				return this.m_PlayerName;
			}
			internal set
			{
				this.SetPlayerName(value);
			}
		}

		// Token: 0x06000126 RID: 294 RVA: 0x00004A82 File Offset: 0x00002C82
		internal PlayerNameComponent(IAuthenticationCache cache)
		{
			this.m_Cache = cache;
			this.m_PlayerName = this.GetPlayerName();
		}

		// Token: 0x06000127 RID: 295 RVA: 0x00004A9D File Offset: 0x00002C9D
		internal void Clear()
		{
			this.m_PlayerName = null;
			this.m_Cache.DeleteKey("player_name");
		}

		// Token: 0x06000128 RID: 296 RVA: 0x00004AB6 File Offset: 0x00002CB6
		internal void Refresh()
		{
			this.m_PlayerName = this.GetPlayerName();
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00004AC4 File Offset: 0x00002CC4
		private string GetPlayerName()
		{
			return this.m_Cache.GetString("player_name");
		}

		// Token: 0x0600012A RID: 298 RVA: 0x00004AD8 File Offset: 0x00002CD8
		private void SetPlayerName(string playerName)
		{
			if (this.PlayerName != playerName)
			{
				this.m_PlayerName = playerName;
				this.m_Cache.SetString("player_name", playerName);
				try
				{
					Action<string> playerNameChanged = this.PlayerNameChanged;
					if (playerNameChanged != null)
					{
						playerNameChanged(playerName);
					}
				}
				catch (Exception exception)
				{
					Logger.LogException(exception);
				}
			}
		}

		// Token: 0x0400004F RID: 79
		private const string k_CacheKey = "player_name";

		// Token: 0x04000050 RID: 80
		private string m_PlayerName;

		// Token: 0x04000052 RID: 82
		private readonly IAuthenticationCache m_Cache;
	}
}
