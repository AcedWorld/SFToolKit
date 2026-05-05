using System;
using System.Security.Principal;

namespace WebSocketSharp.Net
{
	// Token: 0x0200002F RID: 47
	public class HttpBasicIdentity : GenericIdentity
	{
		// Token: 0x06000385 RID: 901 RVA: 0x00016C0F File Offset: 0x00014E0F
		internal HttpBasicIdentity(string username, string password) : base(username, "Basic")
		{
			this._password = password;
		}

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x06000386 RID: 902 RVA: 0x00016C28 File Offset: 0x00014E28
		public virtual string Password
		{
			get
			{
				return this._password;
			}
		}

		// Token: 0x04000175 RID: 373
		private string _password;
	}
}
