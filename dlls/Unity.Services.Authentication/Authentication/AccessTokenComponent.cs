using System;
using Unity.Services.Authentication.Internal;
using Unity.Services.Core.Internal;

namespace Unity.Services.Authentication
{
	// Token: 0x02000010 RID: 16
	internal class AccessTokenComponent : IAccessToken, IServiceComponent, IAccessTokenObserver
	{
		// Token: 0x1400000F RID: 15
		// (add) Token: 0x0600010B RID: 267 RVA: 0x00004794 File Offset: 0x00002994
		// (remove) Token: 0x0600010C RID: 268 RVA: 0x000047CC File Offset: 0x000029CC
		public event Action<string> AccessTokenChanged;

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x0600010D RID: 269 RVA: 0x00004801 File Offset: 0x00002A01
		// (set) Token: 0x0600010E RID: 270 RVA: 0x00004809 File Offset: 0x00002A09
		public string AccessToken
		{
			get
			{
				return this.m_AccessToken;
			}
			internal set
			{
				this.SetAccessToken(value);
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x0600010F RID: 271 RVA: 0x00004812 File Offset: 0x00002A12
		// (set) Token: 0x06000110 RID: 272 RVA: 0x0000481A File Offset: 0x00002A1A
		public DateTime? RefreshTime { get; internal set; }

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000111 RID: 273 RVA: 0x00004823 File Offset: 0x00002A23
		// (set) Token: 0x06000112 RID: 274 RVA: 0x0000482B File Offset: 0x00002A2B
		public DateTime? ExpiryTime { get; internal set; }

		// Token: 0x06000113 RID: 275 RVA: 0x00004834 File Offset: 0x00002A34
		internal AccessTokenComponent()
		{
		}

		// Token: 0x06000114 RID: 276 RVA: 0x0000483C File Offset: 0x00002A3C
		internal void Clear()
		{
			this.AccessToken = null;
			this.ExpiryTime = null;
		}

		// Token: 0x06000115 RID: 277 RVA: 0x00004860 File Offset: 0x00002A60
		private void SetAccessToken(string accessToken)
		{
			if (this.m_AccessToken != accessToken)
			{
				this.m_AccessToken = accessToken;
				try
				{
					Action<string> accessTokenChanged = this.AccessTokenChanged;
					if (accessTokenChanged != null)
					{
						accessTokenChanged(this.m_AccessToken);
					}
				}
				catch (Exception exception)
				{
					Logger.LogException(exception);
				}
			}
		}

		// Token: 0x04000049 RID: 73
		private string m_AccessToken;
	}
}
