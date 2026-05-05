using System;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;

namespace UnityWebSocketSharp.Net
{
	// Token: 0x02000024 RID: 36
	internal class AuthenticationResponse
	{
		// Token: 0x0600029D RID: 669 RVA: 0x0000CB52 File Offset: 0x0000AD52
		private AuthenticationResponse(AuthenticationSchemes scheme, NameValueCollection parameters)
		{
			this._scheme = scheme;
			this._parameters = parameters;
		}

		// Token: 0x0600029E RID: 670 RVA: 0x0000CB68 File Offset: 0x0000AD68
		internal AuthenticationResponse(NetworkCredential credentials) : this(AuthenticationSchemes.Basic, new NameValueCollection(), credentials, 0U)
		{
		}

		// Token: 0x0600029F RID: 671 RVA: 0x0000CB78 File Offset: 0x0000AD78
		internal AuthenticationResponse(AuthenticationChallenge challenge, NetworkCredential credentials, uint nonceCount) : this(challenge.Scheme, challenge.Parameters, credentials, nonceCount)
		{
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x0000CB90 File Offset: 0x0000AD90
		internal AuthenticationResponse(AuthenticationSchemes scheme, NameValueCollection parameters, NetworkCredential credentials, uint nonceCount) : this(scheme, parameters)
		{
			this._parameters["username"] = credentials.Username;
			this._parameters["password"] = credentials.Password;
			this._parameters["uri"] = credentials.Domain;
			this._nonceCount = nonceCount;
			if (scheme == AuthenticationSchemes.Digest)
			{
				this.initAsDigest();
			}
		}

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x060002A1 RID: 673 RVA: 0x0000CBF9 File Offset: 0x0000ADF9
		internal uint NonceCount
		{
			get
			{
				if (this._nonceCount >= 4294967295U)
				{
					return 0U;
				}
				return this._nonceCount;
			}
		}

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x060002A2 RID: 674 RVA: 0x0000CC0C File Offset: 0x0000AE0C
		internal NameValueCollection Parameters
		{
			get
			{
				return this._parameters;
			}
		}

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x060002A3 RID: 675 RVA: 0x0000CC14 File Offset: 0x0000AE14
		public string Algorithm
		{
			get
			{
				return this._parameters["algorithm"];
			}
		}

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x060002A4 RID: 676 RVA: 0x0000CC26 File Offset: 0x0000AE26
		public string Cnonce
		{
			get
			{
				return this._parameters["cnonce"];
			}
		}

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x060002A5 RID: 677 RVA: 0x0000CC38 File Offset: 0x0000AE38
		public string Nc
		{
			get
			{
				return this._parameters["nc"];
			}
		}

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x060002A6 RID: 678 RVA: 0x0000CC4A File Offset: 0x0000AE4A
		public string Nonce
		{
			get
			{
				return this._parameters["nonce"];
			}
		}

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x060002A7 RID: 679 RVA: 0x0000CC5C File Offset: 0x0000AE5C
		public string Opaque
		{
			get
			{
				return this._parameters["opaque"];
			}
		}

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x060002A8 RID: 680 RVA: 0x0000CC6E File Offset: 0x0000AE6E
		public string Password
		{
			get
			{
				return this._parameters["password"];
			}
		}

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x060002A9 RID: 681 RVA: 0x0000CC80 File Offset: 0x0000AE80
		public string Qop
		{
			get
			{
				return this._parameters["qop"];
			}
		}

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x060002AA RID: 682 RVA: 0x0000CC92 File Offset: 0x0000AE92
		public string Realm
		{
			get
			{
				return this._parameters["realm"];
			}
		}

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x060002AB RID: 683 RVA: 0x0000CCA4 File Offset: 0x0000AEA4
		public string Response
		{
			get
			{
				return this._parameters["response"];
			}
		}

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x060002AC RID: 684 RVA: 0x0000CCB6 File Offset: 0x0000AEB6
		public AuthenticationSchemes Scheme
		{
			get
			{
				return this._scheme;
			}
		}

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x060002AD RID: 685 RVA: 0x0000CCBE File Offset: 0x0000AEBE
		public string Uri
		{
			get
			{
				return this._parameters["uri"];
			}
		}

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x060002AE RID: 686 RVA: 0x0000CCD0 File Offset: 0x0000AED0
		public string UserName
		{
			get
			{
				return this._parameters["username"];
			}
		}

		// Token: 0x060002AF RID: 687 RVA: 0x0000CCE2 File Offset: 0x0000AEE2
		private static string createA1(string username, string password, string realm)
		{
			return string.Format("{0}:{1}:{2}", username, realm, password);
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x0000CCF4 File Offset: 0x0000AEF4
		private static string createA1(string username, string password, string realm, string nonce, string cnonce)
		{
			string value = AuthenticationResponse.createA1(username, password, realm);
			return string.Format("{0}:{1}:{2}", AuthenticationResponse.hash(value), nonce, cnonce);
		}

		// Token: 0x060002B1 RID: 689 RVA: 0x0000CD1D File Offset: 0x0000AF1D
		private static string createA2(string method, string uri)
		{
			return string.Format("{0}:{1}", method, uri);
		}

		// Token: 0x060002B2 RID: 690 RVA: 0x0000CD2B File Offset: 0x0000AF2B
		private static string createA2(string method, string uri, string entity)
		{
			return string.Format("{0}:{1}:{2}", method, uri, AuthenticationResponse.hash(entity));
		}

		// Token: 0x060002B3 RID: 691 RVA: 0x0000CD40 File Offset: 0x0000AF40
		private static string hash(string value)
		{
			HashAlgorithm hashAlgorithm = MD5.Create();
			byte[] bytes = Encoding.UTF8.GetBytes(value);
			byte[] array = hashAlgorithm.ComputeHash(bytes);
			StringBuilder stringBuilder = new StringBuilder(64);
			foreach (byte b in array)
			{
				stringBuilder.Append(b.ToString("x2"));
			}
			return stringBuilder.ToString();
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x0000CD9C File Offset: 0x0000AF9C
		private void initAsDigest()
		{
			string text = this._parameters["qop"];
			if (text != null)
			{
				if (text.Split(',', StringSplitOptions.None).Contains((string qop) => qop.Trim().ToLower() == "auth"))
				{
					this._parameters["qop"] = "auth";
					this._parameters["cnonce"] = AuthenticationChallenge.CreateNonceValue();
					NameValueCollection parameters = this._parameters;
					string name = "nc";
					string format = "{0:x8}";
					uint num = this._nonceCount + 1U;
					this._nonceCount = num;
					parameters[name] = string.Format(format, num);
				}
				else
				{
					this._parameters["qop"] = null;
				}
			}
			this._parameters["method"] = "GET";
			this._parameters["response"] = AuthenticationResponse.CreateRequestDigest(this._parameters);
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x0000CE8C File Offset: 0x0000B08C
		internal static string CreateRequestDigest(NameValueCollection parameters)
		{
			string username = parameters["username"];
			string password = parameters["password"];
			string realm = parameters["realm"];
			string text = parameters["nonce"];
			string uri = parameters["uri"];
			string text2 = parameters["algorithm"];
			string text3 = parameters["qop"];
			string text4 = parameters["cnonce"];
			string text5 = parameters["nc"];
			string method = parameters["method"];
			string value = (text2 != null && text2.ToLower() == "md5-sess") ? AuthenticationResponse.createA1(username, password, realm, text, text4) : AuthenticationResponse.createA1(username, password, realm);
			string value2 = (text3 != null && text3.ToLower() == "auth-int") ? AuthenticationResponse.createA2(method, uri, parameters["entity"]) : AuthenticationResponse.createA2(method, uri);
			string arg = AuthenticationResponse.hash(value);
			string arg2 = (text3 != null) ? string.Format("{0}:{1}:{2}:{3}:{4}", new object[]
			{
				text,
				text5,
				text4,
				text3,
				AuthenticationResponse.hash(value2)
			}) : string.Format("{0}:{1}", text, AuthenticationResponse.hash(value2));
			return AuthenticationResponse.hash(string.Format("{0}:{1}", arg, arg2));
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x0000CFDC File Offset: 0x0000B1DC
		internal static AuthenticationResponse Parse(string value)
		{
			AuthenticationResponse result;
			try
			{
				string[] array = value.Split(new char[]
				{
					' '
				}, 2);
				if (array.Length != 2)
				{
					result = null;
				}
				else
				{
					string a = array[0].ToLower();
					if (a == "basic")
					{
						NameValueCollection parameters = AuthenticationResponse.ParseBasicCredentials(array[1]);
						result = new AuthenticationResponse(AuthenticationSchemes.Basic, parameters);
					}
					else if (a == "digest")
					{
						NameValueCollection parameters2 = AuthenticationChallenge.ParseParameters(array[1]);
						result = new AuthenticationResponse(AuthenticationSchemes.Digest, parameters2);
					}
					else
					{
						result = null;
					}
				}
			}
			catch
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060002B7 RID: 695 RVA: 0x0000D06C File Offset: 0x0000B26C
		internal static NameValueCollection ParseBasicCredentials(string value)
		{
			NameValueCollection nameValueCollection = new NameValueCollection();
			byte[] bytes = Convert.FromBase64String(value);
			string @string = Encoding.Default.GetString(bytes);
			int num = @string.IndexOf(':');
			string text = @string.Substring(0, num);
			string value2 = (num < @string.Length - 1) ? @string.Substring(num + 1) : string.Empty;
			num = text.IndexOf('\\');
			if (num > -1)
			{
				text = text.Substring(num + 1);
			}
			nameValueCollection["username"] = text;
			nameValueCollection["password"] = value2;
			return nameValueCollection;
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x0000D0F0 File Offset: 0x0000B2F0
		internal string ToBasicString()
		{
			string arg = this._parameters["username"];
			string arg2 = this._parameters["password"];
			string s = string.Format("{0}:{1}", arg, arg2);
			string str = Convert.ToBase64String(Encoding.UTF8.GetBytes(s));
			return "Basic " + str;
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x0000D148 File Offset: 0x0000B348
		internal string ToDigestString()
		{
			StringBuilder stringBuilder = new StringBuilder(256);
			string text = this._parameters["username"];
			string text2 = this._parameters["realm"];
			string text3 = this._parameters["nonce"];
			string text4 = this._parameters["uri"];
			string text5 = this._parameters["response"];
			stringBuilder.AppendFormat("Digest username=\"{0}\", realm=\"{1}\", nonce=\"{2}\", uri=\"{3}\", response=\"{4}\"", new object[]
			{
				text,
				text2,
				text3,
				text4,
				text5
			});
			string text6 = this._parameters["opaque"];
			if (text6 != null)
			{
				stringBuilder.AppendFormat(", opaque=\"{0}\"", text6);
			}
			string text7 = this._parameters["algorithm"];
			if (text7 != null)
			{
				stringBuilder.AppendFormat(", algorithm={0}", text7);
			}
			string text8 = this._parameters["qop"];
			if (text8 != null)
			{
				string arg = this._parameters["cnonce"];
				string arg2 = this._parameters["nc"];
				stringBuilder.AppendFormat(", qop={0}, cnonce=\"{1}\", nc={2}", text8, arg, arg2);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x060002BA RID: 698 RVA: 0x0000D27C File Offset: 0x0000B47C
		public IIdentity ToIdentity()
		{
			if (this._scheme == AuthenticationSchemes.Basic)
			{
				string username = this._parameters["username"];
				string password = this._parameters["password"];
				return new HttpBasicIdentity(username, password);
			}
			if (this._scheme == AuthenticationSchemes.Digest)
			{
				return new HttpDigestIdentity(this._parameters);
			}
			return null;
		}

		// Token: 0x060002BB RID: 699 RVA: 0x0000D2D0 File Offset: 0x0000B4D0
		public override string ToString()
		{
			if (this._scheme == AuthenticationSchemes.Basic)
			{
				return this.ToBasicString();
			}
			if (this._scheme == AuthenticationSchemes.Digest)
			{
				return this.ToDigestString();
			}
			return string.Empty;
		}

		// Token: 0x040000E9 RID: 233
		private uint _nonceCount;

		// Token: 0x040000EA RID: 234
		private NameValueCollection _parameters;

		// Token: 0x040000EB RID: 235
		private AuthenticationSchemes _scheme;
	}
}
