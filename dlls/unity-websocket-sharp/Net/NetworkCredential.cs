using System;

namespace UnityWebSocketSharp.Net
{
	// Token: 0x02000045 RID: 69
	internal class NetworkCredential
	{
		// Token: 0x0600048D RID: 1165 RVA: 0x0001561E File Offset: 0x0001381E
		public NetworkCredential(string username, string password) : this(username, password, null, null)
		{
		}

		// Token: 0x0600048E RID: 1166 RVA: 0x0001562C File Offset: 0x0001382C
		public NetworkCredential(string username, string password, string domain, params string[] roles)
		{
			if (username == null)
			{
				throw new ArgumentNullException("username");
			}
			if (username.Length == 0)
			{
				throw new ArgumentException("An empty string.", "username");
			}
			this._username = username;
			this._password = password;
			this._domain = domain;
			this._roles = roles;
		}

		// Token: 0x1700015C RID: 348
		// (get) Token: 0x0600048F RID: 1167 RVA: 0x00015682 File Offset: 0x00013882
		// (set) Token: 0x06000490 RID: 1168 RVA: 0x00015693 File Offset: 0x00013893
		public string Domain
		{
			get
			{
				return this._domain ?? string.Empty;
			}
			internal set
			{
				this._domain = value;
			}
		}

		// Token: 0x1700015D RID: 349
		// (get) Token: 0x06000491 RID: 1169 RVA: 0x0001569C File Offset: 0x0001389C
		// (set) Token: 0x06000492 RID: 1170 RVA: 0x000156AD File Offset: 0x000138AD
		public string Password
		{
			get
			{
				return this._password ?? string.Empty;
			}
			internal set
			{
				this._password = value;
			}
		}

		// Token: 0x1700015E RID: 350
		// (get) Token: 0x06000493 RID: 1171 RVA: 0x000156B6 File Offset: 0x000138B6
		// (set) Token: 0x06000494 RID: 1172 RVA: 0x000156C7 File Offset: 0x000138C7
		public string[] Roles
		{
			get
			{
				return this._roles ?? NetworkCredential._noRoles;
			}
			internal set
			{
				this._roles = value;
			}
		}

		// Token: 0x1700015F RID: 351
		// (get) Token: 0x06000495 RID: 1173 RVA: 0x000156D0 File Offset: 0x000138D0
		// (set) Token: 0x06000496 RID: 1174 RVA: 0x000156D8 File Offset: 0x000138D8
		public string Username
		{
			get
			{
				return this._username;
			}
			internal set
			{
				this._username = value;
			}
		}

		// Token: 0x0400023A RID: 570
		private string _domain;

		// Token: 0x0400023B RID: 571
		private static readonly string[] _noRoles = new string[0];

		// Token: 0x0400023C RID: 572
		private string _password;

		// Token: 0x0400023D RID: 573
		private string[] _roles;

		// Token: 0x0400023E RID: 574
		private string _username;
	}
}
