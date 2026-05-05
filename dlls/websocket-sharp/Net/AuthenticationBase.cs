using System;
using System.Collections.Specialized;
using System.Text;

namespace WebSocketSharp.Net
{
	// Token: 0x0200003B RID: 59
	internal abstract class AuthenticationBase
	{
		// Token: 0x060003D8 RID: 984 RVA: 0x00018236 File Offset: 0x00016436
		protected AuthenticationBase(AuthenticationSchemes scheme, NameValueCollection parameters)
		{
			this._scheme = scheme;
			this.Parameters = parameters;
		}

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x060003D9 RID: 985 RVA: 0x00018250 File Offset: 0x00016450
		public string Algorithm
		{
			get
			{
				return this.Parameters["algorithm"];
			}
		}

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x060003DA RID: 986 RVA: 0x00018274 File Offset: 0x00016474
		public string Nonce
		{
			get
			{
				return this.Parameters["nonce"];
			}
		}

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x060003DB RID: 987 RVA: 0x00018298 File Offset: 0x00016498
		public string Opaque
		{
			get
			{
				return this.Parameters["opaque"];
			}
		}

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x060003DC RID: 988 RVA: 0x000182BC File Offset: 0x000164BC
		public string Qop
		{
			get
			{
				return this.Parameters["qop"];
			}
		}

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x060003DD RID: 989 RVA: 0x000182E0 File Offset: 0x000164E0
		public string Realm
		{
			get
			{
				return this.Parameters["realm"];
			}
		}

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x060003DE RID: 990 RVA: 0x00018304 File Offset: 0x00016504
		public AuthenticationSchemes Scheme
		{
			get
			{
				return this._scheme;
			}
		}

		// Token: 0x060003DF RID: 991 RVA: 0x0001831C File Offset: 0x0001651C
		internal static string CreateNonceValue()
		{
			byte[] array = new byte[16];
			Random random = new Random();
			random.NextBytes(array);
			StringBuilder stringBuilder = new StringBuilder(32);
			foreach (byte b in array)
			{
				stringBuilder.Append(b.ToString("x2"));
			}
			return stringBuilder.ToString();
		}

		// Token: 0x060003E0 RID: 992 RVA: 0x00018384 File Offset: 0x00016584
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
				string value2 = (num < 0) ? text.Trim().Trim(new char[]
				{
					'"'
				}) : ((num < text.Length - 1) ? text.Substring(num + 1).Trim().Trim(new char[]
				{
					'"'
				}) : string.Empty);
				nameValueCollection.Add(name, value2);
			}
			return nameValueCollection;
		}

		// Token: 0x060003E1 RID: 993
		internal abstract string ToBasicString();

		// Token: 0x060003E2 RID: 994
		internal abstract string ToDigestString();

		// Token: 0x060003E3 RID: 995 RVA: 0x00018468 File Offset: 0x00016668
		public override string ToString()
		{
			return (this._scheme == AuthenticationSchemes.Basic) ? this.ToBasicString() : ((this._scheme == AuthenticationSchemes.Digest) ? this.ToDigestString() : string.Empty);
		}

		// Token: 0x04000196 RID: 406
		private AuthenticationSchemes _scheme;

		// Token: 0x04000197 RID: 407
		internal NameValueCollection Parameters;
	}
}
