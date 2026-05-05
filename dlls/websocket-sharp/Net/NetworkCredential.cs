using System;

namespace WebSocketSharp.Net
{
	// Token: 0x02000031 RID: 49
	public class NetworkCredential
	{
		// Token: 0x06000393 RID: 915 RVA: 0x00016E26 File Offset: 0x00015026
		public NetworkCredential(string username, string password) : this(username, password, null, null)
		{
		}

		// Token: 0x06000394 RID: 916 RVA: 0x00016E34 File Offset: 0x00015034
		public NetworkCredential(string username, string password, string domain, params string[] roles)
		{
			bool flag = username == null;
			if (flag)
			{
				throw new ArgumentNullException("username");
			}
			bool flag2 = username.Length == 0;
			if (flag2)
			{
				throw new ArgumentException("An empty string.", "username");
			}
			this._username = username;
			this._password = password;
			this._domain = domain;
			this._roles = roles;
		}

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x06000395 RID: 917 RVA: 0x00016E98 File Offset: 0x00015098
		// (set) Token: 0x06000396 RID: 918 RVA: 0x00016EB9 File Offset: 0x000150B9
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

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x06000397 RID: 919 RVA: 0x00016EC4 File Offset: 0x000150C4
		// (set) Token: 0x06000398 RID: 920 RVA: 0x00016EE5 File Offset: 0x000150E5
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

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x06000399 RID: 921 RVA: 0x00016EF0 File Offset: 0x000150F0
		// (set) Token: 0x0600039A RID: 922 RVA: 0x00016F11 File Offset: 0x00015111
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

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x0600039B RID: 923 RVA: 0x00016F1C File Offset: 0x0001511C
		// (set) Token: 0x0600039C RID: 924 RVA: 0x00016F34 File Offset: 0x00015134
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

		// Token: 0x04000177 RID: 375
		private string _domain;

		// Token: 0x04000178 RID: 376
		private static readonly string[] _noRoles = new string[0];

		// Token: 0x04000179 RID: 377
		private string _password;

		// Token: 0x0400017A RID: 378
		private string[] _roles;

		// Token: 0x0400017B RID: 379
		private string _username;
	}
}
