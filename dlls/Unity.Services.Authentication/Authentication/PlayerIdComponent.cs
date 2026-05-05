using System;
using Unity.Services.Authentication.Internal;
using Unity.Services.Core.Internal;

namespace Unity.Services.Authentication
{
	// Token: 0x02000012 RID: 18
	internal class PlayerIdComponent : IPlayerId, IServiceComponent
	{
		// Token: 0x14000010 RID: 16
		// (add) Token: 0x06000119 RID: 281 RVA: 0x000048D0 File Offset: 0x00002AD0
		// (remove) Token: 0x0600011A RID: 282 RVA: 0x00004908 File Offset: 0x00002B08
		public event Action<string> PlayerIdChanged;

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x0600011B RID: 283 RVA: 0x0000493D File Offset: 0x00002B3D
		// (set) Token: 0x0600011C RID: 284 RVA: 0x00004945 File Offset: 0x00002B45
		public string PlayerId
		{
			get
			{
				return this.m_PlayerId;
			}
			internal set
			{
				this.SetPlayerId(value);
			}
		}

		// Token: 0x0600011D RID: 285 RVA: 0x0000494E File Offset: 0x00002B4E
		internal PlayerIdComponent(IAuthenticationCache cache)
		{
			this.m_Cache = cache;
			this.m_PlayerId = this.GetPlayerId();
		}

		// Token: 0x0600011E RID: 286 RVA: 0x00004969 File Offset: 0x00002B69
		internal void Clear()
		{
			this.m_PlayerId = null;
			this.m_Cache.DeleteKey("player_id");
		}

		// Token: 0x0600011F RID: 287 RVA: 0x00004982 File Offset: 0x00002B82
		internal void Refresh()
		{
			this.m_PlayerId = this.GetPlayerId();
		}

		// Token: 0x06000120 RID: 288 RVA: 0x00004990 File Offset: 0x00002B90
		private string GetPlayerId()
		{
			return this.m_Cache.GetString("player_id");
		}

		// Token: 0x06000121 RID: 289 RVA: 0x000049A4 File Offset: 0x00002BA4
		private void SetPlayerId(string playerId)
		{
			if (this.PlayerId != playerId)
			{
				this.m_PlayerId = playerId;
				this.m_Cache.SetString("player_id", playerId);
				try
				{
					Action<string> playerIdChanged = this.PlayerIdChanged;
					if (playerIdChanged != null)
					{
						playerIdChanged(playerId);
					}
				}
				catch (Exception exception)
				{
					Logger.LogException(exception);
				}
			}
		}

		// Token: 0x0400004B RID: 75
		private const string k_CacheKey = "player_id";

		// Token: 0x0400004C RID: 76
		private string m_PlayerId;

		// Token: 0x0400004E RID: 78
		private readonly IAuthenticationCache m_Cache;
	}
}
