using System;
using System.Security.Principal;

namespace UnityWebSocketSharp.Net
{
	// Token: 0x0200002F RID: 47
	internal class HttpBasicIdentity : GenericIdentity
	{
		// Token: 0x0600035D RID: 861 RVA: 0x0000FFA0 File Offset: 0x0000E1A0
		internal HttpBasicIdentity(string username, string password) : base(username, "Basic")
		{
			this._password = password;
		}

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x0600035E RID: 862 RVA: 0x0000FFB5 File Offset: 0x0000E1B5
		public virtual string Password
		{
			get
			{
				return this._password;
			}
		}

		// Token: 0x04000129 RID: 297
		private string _password;
	}
}
