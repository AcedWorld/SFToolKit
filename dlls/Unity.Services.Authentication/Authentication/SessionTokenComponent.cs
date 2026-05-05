using System;

namespace Unity.Services.Authentication
{
	// Token: 0x02000017 RID: 23
	internal class SessionTokenComponent
	{
		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000137 RID: 311 RVA: 0x00004C2B File Offset: 0x00002E2B
		// (set) Token: 0x06000138 RID: 312 RVA: 0x00004C33 File Offset: 0x00002E33
		internal string SessionToken
		{
			get
			{
				return this.m_SessionToken;
			}
			set
			{
				this.SetSessionToken(value);
			}
		}

		// Token: 0x06000139 RID: 313 RVA: 0x00004C3C File Offset: 0x00002E3C
		internal SessionTokenComponent(IAuthenticationCache cache)
		{
			this.m_Cache = cache;
			this.m_SessionToken = this.GetSessionToken();
		}

		// Token: 0x0600013A RID: 314 RVA: 0x00004C57 File Offset: 0x00002E57
		internal void Clear()
		{
			this.m_SessionToken = null;
			this.m_Cache.DeleteKey("session_token");
		}

		// Token: 0x0600013B RID: 315 RVA: 0x00004C70 File Offset: 0x00002E70
		internal void Migrate()
		{
			this.m_Cache.Migrate("session_token");
		}

		// Token: 0x0600013C RID: 316 RVA: 0x00004C82 File Offset: 0x00002E82
		internal void Refresh()
		{
			this.m_SessionToken = this.GetSessionToken();
		}

		// Token: 0x0600013D RID: 317 RVA: 0x00004C90 File Offset: 0x00002E90
		private string GetSessionToken()
		{
			return this.m_Cache.GetString("session_token");
		}

		// Token: 0x0600013E RID: 318 RVA: 0x00004CA2 File Offset: 0x00002EA2
		private void SetSessionToken(string sessionToken)
		{
			this.m_SessionToken = sessionToken;
			this.m_Cache.SetString("session_token", sessionToken);
		}

		// Token: 0x04000056 RID: 86
		private const string k_CacheKey = "session_token";

		// Token: 0x04000057 RID: 87
		private string m_SessionToken;

		// Token: 0x04000058 RID: 88
		private readonly IAuthenticationCache m_Cache;
	}
}
