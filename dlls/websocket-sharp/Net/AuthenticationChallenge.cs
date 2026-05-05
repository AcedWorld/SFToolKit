using System;
using System.Collections.Specialized;
using System.Text;

namespace WebSocketSharp.Net
{
	// Token: 0x02000039 RID: 57
	internal class AuthenticationChallenge : AuthenticationBase
	{
		// Token: 0x060003B8 RID: 952 RVA: 0x00017730 File Offset: 0x00015930
		private AuthenticationChallenge(AuthenticationSchemes scheme, NameValueCollection parameters) : base(scheme, parameters)
		{
		}

		// Token: 0x060003B9 RID: 953 RVA: 0x0001773C File Offset: 0x0001593C
		internal AuthenticationChallenge(AuthenticationSchemes scheme, string realm) : base(scheme, new NameValueCollection())
		{
			this.Parameters["realm"] = realm;
			bool flag = scheme == AuthenticationSchemes.Digest;
			if (flag)
			{
				this.Parameters["nonce"] = AuthenticationBase.CreateNonceValue();
				this.Parameters["algorithm"] = "MD5";
				this.Parameters["qop"] = "auth";
			}
		}

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x060003BA RID: 954 RVA: 0x000177B8 File Offset: 0x000159B8
		public string Domain
		{
			get
			{
				return this.Parameters["domain"];
			}
		}

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x060003BB RID: 955 RVA: 0x000177DC File Offset: 0x000159DC
		public string Stale
		{
			get
			{
				return this.Parameters["stale"];
			}
		}

		// Token: 0x060003BC RID: 956 RVA: 0x00017800 File Offset: 0x00015A00
		internal static AuthenticationChallenge CreateBasicChallenge(string realm)
		{
			return new AuthenticationChallenge(AuthenticationSchemes.Basic, realm);
		}

		// Token: 0x060003BD RID: 957 RVA: 0x0001781C File Offset: 0x00015A1C
		internal static AuthenticationChallenge CreateDigestChallenge(string realm)
		{
			return new AuthenticationChallenge(AuthenticationSchemes.Digest, realm);
		}

		// Token: 0x060003BE RID: 958 RVA: 0x00017838 File Offset: 0x00015A38
		internal static AuthenticationChallenge Parse(string value)
		{
			string[] array = value.Split(new char[]
			{
				' '
			}, 2);
			bool flag = array.Length != 2;
			AuthenticationChallenge result;
			if (flag)
			{
				result = null;
			}
			else
			{
				string a = array[0].ToLower();
				result = ((a == "basic") ? new AuthenticationChallenge(AuthenticationSchemes.Basic, AuthenticationBase.ParseParameters(array[1])) : ((a == "digest") ? new AuthenticationChallenge(AuthenticationSchemes.Digest, AuthenticationBase.ParseParameters(array[1])) : null));
			}
			return result;
		}

		// Token: 0x060003BF RID: 959 RVA: 0x000178B4 File Offset: 0x00015AB4
		internal override string ToBasicString()
		{
			return string.Format("Basic realm=\"{0}\"", this.Parameters["realm"]);
		}

		// Token: 0x060003C0 RID: 960 RVA: 0x000178E0 File Offset: 0x00015AE0
		internal override string ToDigestString()
		{
			StringBuilder stringBuilder = new StringBuilder(128);
			string text = this.Parameters["domain"];
			bool flag = text != null;
			if (flag)
			{
				stringBuilder.AppendFormat("Digest realm=\"{0}\", domain=\"{1}\", nonce=\"{2}\"", this.Parameters["realm"], text, this.Parameters["nonce"]);
			}
			else
			{
				stringBuilder.AppendFormat("Digest realm=\"{0}\", nonce=\"{1}\"", this.Parameters["realm"], this.Parameters["nonce"]);
			}
			string text2 = this.Parameters["opaque"];
			bool flag2 = text2 != null;
			if (flag2)
			{
				stringBuilder.AppendFormat(", opaque=\"{0}\"", text2);
			}
			string text3 = this.Parameters["stale"];
			bool flag3 = text3 != null;
			if (flag3)
			{
				stringBuilder.AppendFormat(", stale={0}", text3);
			}
			string text4 = this.Parameters["algorithm"];
			bool flag4 = text4 != null;
			if (flag4)
			{
				stringBuilder.AppendFormat(", algorithm={0}", text4);
			}
			string text5 = this.Parameters["qop"];
			bool flag5 = text5 != null;
			if (flag5)
			{
				stringBuilder.AppendFormat(", qop=\"{0}\"", text5);
			}
			return stringBuilder.ToString();
		}
	}
}
