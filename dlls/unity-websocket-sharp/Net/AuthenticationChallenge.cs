using System;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Text;

namespace UnityWebSocketSharp.Net
{
	// Token: 0x02000023 RID: 35
	internal class AuthenticationChallenge
	{
		// Token: 0x0600028A RID: 650 RVA: 0x0000C75C File Offset: 0x0000A95C
		private AuthenticationChallenge(AuthenticationSchemes scheme, NameValueCollection parameters)
		{
			this._scheme = scheme;
			this._parameters = parameters;
		}

		// Token: 0x0600028B RID: 651 RVA: 0x0000C774 File Offset: 0x0000A974
		internal AuthenticationChallenge(AuthenticationSchemes scheme, string realm) : this(scheme, new NameValueCollection())
		{
			this._parameters["realm"] = realm;
			if (scheme == AuthenticationSchemes.Digest)
			{
				this._parameters["nonce"] = AuthenticationChallenge.CreateNonceValue();
				this._parameters["algorithm"] = "MD5";
				this._parameters["qop"] = "auth";
			}
		}

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x0600028C RID: 652 RVA: 0x0000C7E1 File Offset: 0x0000A9E1
		internal NameValueCollection Parameters
		{
			get
			{
				return this._parameters;
			}
		}

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x0600028D RID: 653 RVA: 0x0000C7E9 File Offset: 0x0000A9E9
		public string Algorithm
		{
			get
			{
				return this._parameters["algorithm"];
			}
		}

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x0600028E RID: 654 RVA: 0x0000C7FB File Offset: 0x0000A9FB
		public string Domain
		{
			get
			{
				return this._parameters["domain"];
			}
		}

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x0600028F RID: 655 RVA: 0x0000C80D File Offset: 0x0000AA0D
		public string Nonce
		{
			get
			{
				return this._parameters["nonce"];
			}
		}

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x06000290 RID: 656 RVA: 0x0000C81F File Offset: 0x0000AA1F
		public string Opaque
		{
			get
			{
				return this._parameters["opaque"];
			}
		}

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x06000291 RID: 657 RVA: 0x0000C831 File Offset: 0x0000AA31
		public string Qop
		{
			get
			{
				return this._parameters["qop"];
			}
		}

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x06000292 RID: 658 RVA: 0x0000C843 File Offset: 0x0000AA43
		public string Realm
		{
			get
			{
				return this._parameters["realm"];
			}
		}

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x06000293 RID: 659 RVA: 0x0000C855 File Offset: 0x0000AA55
		public AuthenticationSchemes Scheme
		{
			get
			{
				return this._scheme;
			}
		}

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x06000294 RID: 660 RVA: 0x0000C85D File Offset: 0x0000AA5D
		public string Stale
		{
			get
			{
				return this._parameters["stale"];
			}
		}

		// Token: 0x06000295 RID: 661 RVA: 0x0000C86F File Offset: 0x0000AA6F
		internal static AuthenticationChallenge CreateBasicChallenge(string realm)
		{
			return new AuthenticationChallenge(AuthenticationSchemes.Basic, realm);
		}

		// Token: 0x06000296 RID: 662 RVA: 0x0000C878 File Offset: 0x0000AA78
		internal static AuthenticationChallenge CreateDigestChallenge(string realm)
		{
			return new AuthenticationChallenge(AuthenticationSchemes.Digest, realm);
		}

		// Token: 0x06000297 RID: 663 RVA: 0x0000C884 File Offset: 0x0000AA84
		internal static string CreateNonceValue()
		{
			RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
			byte[] array = new byte[16];
			randomNumberGenerator.GetBytes(array);
			StringBuilder stringBuilder = new StringBuilder(32);
			foreach (byte b in array)
			{
				stringBuilder.Append(b.ToString("x2"));
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000298 RID: 664 RVA: 0x0000C8DC File Offset: 0x0000AADC
		internal static AuthenticationChallenge Parse(string value)
		{
			string[] array = value.Split(new char[]
			{
				' '
			}, 2);
			if (array.Length != 2)
			{
				return null;
			}
			string a = array[0].ToLower();
			if (a == "basic")
			{
				NameValueCollection parameters = AuthenticationChallenge.ParseParameters(array[1]);
				return new AuthenticationChallenge(AuthenticationSchemes.Basic, parameters);
			}
			if (a == "digest")
			{
				NameValueCollection parameters2 = AuthenticationChallenge.ParseParameters(array[1]);
				return new AuthenticationChallenge(AuthenticationSchemes.Digest, parameters2);
			}
			return null;
		}

		// Token: 0x06000299 RID: 665 RVA: 0x0000C94C File Offset: 0x0000AB4C
		internal static NameValueCollection ParseParameters(string value)
		{
			NameValueCollection nameValueCollection = new NameValueCollection();
			foreach (string text in value.SplitHeaderValue(new char[]
			{
				','
			}))
			{
				int num = text.IndexOf('=');
				string name = (num > 0) ? text.Substring(0, num).Trim() : null;
				string value2 = (num < 0) ? text.Trim().Trim('"') : ((num < text.Length - 1) ? text.Substring(num + 1).Trim().Trim('"') : string.Empty);
				nameValueCollection.Add(name, value2);
			}
			return nameValueCollection;
		}

		// Token: 0x0600029A RID: 666 RVA: 0x0000CA0C File Offset: 0x0000AC0C
		internal string ToBasicString()
		{
			return string.Format("Basic realm=\"{0}\"", this._parameters["realm"]);
		}

		// Token: 0x0600029B RID: 667 RVA: 0x0000CA28 File Offset: 0x0000AC28
		internal string ToDigestString()
		{
			StringBuilder stringBuilder = new StringBuilder(128);
			string text = this._parameters["domain"];
			string arg = this._parameters["realm"];
			string text2 = this._parameters["nonce"];
			if (text != null)
			{
				stringBuilder.AppendFormat("Digest realm=\"{0}\", domain=\"{1}\", nonce=\"{2}\"", arg, text, text2);
			}
			else
			{
				stringBuilder.AppendFormat("Digest realm=\"{0}\", nonce=\"{1}\"", arg, text2);
			}
			string text3 = this._parameters["opaque"];
			if (text3 != null)
			{
				stringBuilder.AppendFormat(", opaque=\"{0}\"", text3);
			}
			string text4 = this._parameters["stale"];
			if (text4 != null)
			{
				stringBuilder.AppendFormat(", stale={0}", text4);
			}
			string text5 = this._parameters["algorithm"];
			if (text5 != null)
			{
				stringBuilder.AppendFormat(", algorithm={0}", text5);
			}
			string text6 = this._parameters["qop"];
			if (text6 != null)
			{
				stringBuilder.AppendFormat(", qop=\"{0}\"", text6);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x0600029C RID: 668 RVA: 0x0000CB2B File Offset: 0x0000AD2B
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

		// Token: 0x040000E7 RID: 231
		private NameValueCollection _parameters;

		// Token: 0x040000E8 RID: 232
		private AuthenticationSchemes _scheme;
	}
}
