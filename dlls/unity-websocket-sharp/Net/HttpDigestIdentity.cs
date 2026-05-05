using System;
using System.Collections.Specialized;
using System.Security.Principal;

namespace UnityWebSocketSharp.Net
{
	// Token: 0x02000031 RID: 49
	internal class HttpDigestIdentity : GenericIdentity
	{
		// Token: 0x0600037A RID: 890 RVA: 0x00010998 File Offset: 0x0000EB98
		internal HttpDigestIdentity(NameValueCollection parameters) : base(parameters["username"], "Digest")
		{
			this._parameters = parameters;
		}

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x0600037B RID: 891 RVA: 0x000109B7 File Offset: 0x0000EBB7
		public string Algorithm
		{
			get
			{
				return this._parameters["algorithm"];
			}
		}

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x0600037C RID: 892 RVA: 0x000109C9 File Offset: 0x0000EBC9
		public string Cnonce
		{
			get
			{
				return this._parameters["cnonce"];
			}
		}

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x0600037D RID: 893 RVA: 0x000109DB File Offset: 0x0000EBDB
		public string Nc
		{
			get
			{
				return this._parameters["nc"];
			}
		}

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x0600037E RID: 894 RVA: 0x000109ED File Offset: 0x0000EBED
		public string Nonce
		{
			get
			{
				return this._parameters["nonce"];
			}
		}

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x0600037F RID: 895 RVA: 0x000109FF File Offset: 0x0000EBFF
		public string Opaque
		{
			get
			{
				return this._parameters["opaque"];
			}
		}

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x06000380 RID: 896 RVA: 0x00010A11 File Offset: 0x0000EC11
		public string Qop
		{
			get
			{
				return this._parameters["qop"];
			}
		}

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x06000381 RID: 897 RVA: 0x00010A23 File Offset: 0x0000EC23
		public string Realm
		{
			get
			{
				return this._parameters["realm"];
			}
		}

		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x06000382 RID: 898 RVA: 0x00010A35 File Offset: 0x0000EC35
		public string Response
		{
			get
			{
				return this._parameters["response"];
			}
		}

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x06000383 RID: 899 RVA: 0x00010A47 File Offset: 0x0000EC47
		public string Uri
		{
			get
			{
				return this._parameters["uri"];
			}
		}

		// Token: 0x06000384 RID: 900 RVA: 0x00010A5C File Offset: 0x0000EC5C
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

		// Token: 0x04000141 RID: 321
		private NameValueCollection _parameters;
	}
}
