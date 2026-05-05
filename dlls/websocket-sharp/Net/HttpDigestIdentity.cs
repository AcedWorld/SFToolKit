using System;
using System.Collections.Specialized;
using System.Security.Principal;

namespace WebSocketSharp.Net
{
	// Token: 0x02000030 RID: 48
	public class HttpDigestIdentity : GenericIdentity
	{
		// Token: 0x06000387 RID: 903 RVA: 0x00016C40 File Offset: 0x00014E40
		internal HttpDigestIdentity(NameValueCollection parameters) : base(parameters["username"], "Digest")
		{
			this._parameters = parameters;
		}

		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x06000388 RID: 904 RVA: 0x00016C64 File Offset: 0x00014E64
		public string Algorithm
		{
			get
			{
				return this._parameters["algorithm"];
			}
		}

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x06000389 RID: 905 RVA: 0x00016C88 File Offset: 0x00014E88
		public string Cnonce
		{
			get
			{
				return this._parameters["cnonce"];
			}
		}

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x0600038A RID: 906 RVA: 0x00016CAC File Offset: 0x00014EAC
		public string Nc
		{
			get
			{
				return this._parameters["nc"];
			}
		}

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x0600038B RID: 907 RVA: 0x00016CD0 File Offset: 0x00014ED0
		public string Nonce
		{
			get
			{
				return this._parameters["nonce"];
			}
		}

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x0600038C RID: 908 RVA: 0x00016CF4 File Offset: 0x00014EF4
		public string Opaque
		{
			get
			{
				return this._parameters["opaque"];
			}
		}

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x0600038D RID: 909 RVA: 0x00016D18 File Offset: 0x00014F18
		public string Qop
		{
			get
			{
				return this._parameters["qop"];
			}
		}

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x0600038E RID: 910 RVA: 0x00016D3C File Offset: 0x00014F3C
		public string Realm
		{
			get
			{
				return this._parameters["realm"];
			}
		}

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x0600038F RID: 911 RVA: 0x00016D60 File Offset: 0x00014F60
		public string Response
		{
			get
			{
				return this._parameters["response"];
			}
		}

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x06000390 RID: 912 RVA: 0x00016D84 File Offset: 0x00014F84
		public string Uri
		{
			get
			{
				return this._parameters["uri"];
			}
		}

		// Token: 0x06000391 RID: 913 RVA: 0x00016DA8 File Offset: 0x00014FA8
		internal bool IsValid(string password, string realm, string method, string entity)
		{
			NameValueCollection nameValueCollection = new NameValueCollection(this._parameters);
			nameValueCollection["password"] = password;
			nameValueCollection["realm"] = realm;
			nameValueCollection["method"] = method;
			nameValueCollection["entity"] = entity;
			string b = AuthenticationResponse.CreateRequestDigest(nameValueCollection);
			return this._parameters["response"] == b;
		}

		// Token: 0x04000176 RID: 374
		private NameValueCollection _parameters;
	}
}
