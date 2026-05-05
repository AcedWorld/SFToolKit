using System;

namespace UnityWebSocketSharp.Net
{
	// Token: 0x02000038 RID: 56
	internal sealed class HttpListenerPrefix
	{
		// Token: 0x060003E1 RID: 993 RVA: 0x00011A95 File Offset: 0x0000FC95
		internal HttpListenerPrefix(string uriPrefix, HttpListener listener)
		{
			this._original = uriPrefix;
			this._listener = listener;
			this.parse(uriPrefix);
		}

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x060003E2 RID: 994 RVA: 0x00011AB2 File Offset: 0x0000FCB2
		public string Host
		{
			get
			{
				return this._host;
			}
		}

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x060003E3 RID: 995 RVA: 0x00011ABA File Offset: 0x0000FCBA
		public bool IsSecure
		{
			get
			{
				return this._secure;
			}
		}

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x060003E4 RID: 996 RVA: 0x00011AC2 File Offset: 0x0000FCC2
		public HttpListener Listener
		{
			get
			{
				return this._listener;
			}
		}

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x060003E5 RID: 997 RVA: 0x00011ACA File Offset: 0x0000FCCA
		public string Original
		{
			get
			{
				return this._original;
			}
		}

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x060003E6 RID: 998 RVA: 0x00011AD2 File Offset: 0x0000FCD2
		public string Path
		{
			get
			{
				return this._path;
			}
		}

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x060003E7 RID: 999 RVA: 0x00011ADA File Offset: 0x0000FCDA
		public string Port
		{
			get
			{
				return this._port;
			}
		}

		// Token: 0x060003E8 RID: 1000 RVA: 0x00011AE4 File Offset: 0x0000FCE4
		private void parse(string uriPrefix)
		{
			if (uriPrefix.StartsWith("https"))
			{
				this._secure = true;
			}
			int length = uriPrefix.Length;
			int num = uriPrefix.IndexOf(':') + 3;
			int num2 = uriPrefix.IndexOf('/', num + 1, length - num - 1);
			int num3 = uriPrefix.LastIndexOf(':', num2 - 1, num2 - num - 1);
			if (uriPrefix[num2 - 1] != ']' && num3 > num)
			{
				this._host = uriPrefix.Substring(num, num3 - num);
				this._port = uriPrefix.Substring(num3 + 1, num2 - num3 - 1);
			}
			else
			{
				this._host = uriPrefix.Substring(num, num2 - num);
				this._port = (this._secure ? "443" : "80");
			}
			this._path = uriPrefix.Substring(num2);
			this._prefix = string.Format("{0}://{1}:{2}{3}", new object[]
			{
				this._secure ? "https" : "http",
				this._host,
				this._port,
				this._path
			});
		}

		// Token: 0x060003E9 RID: 1001 RVA: 0x00011BF0 File Offset: 0x0000FDF0
		public static void CheckPrefix(string uriPrefix)
		{
			if (uriPrefix == null)
			{
				throw new ArgumentNullException("uriPrefix");
			}
			int length = uriPrefix.Length;
			if (length == 0)
			{
				throw new ArgumentException("An empty string.", "uriPrefix");
			}
			if (!uriPrefix.StartsWith("http://") && !uriPrefix.StartsWith("https://"))
			{
				throw new ArgumentException("The scheme is not 'http' or 'https'.", "uriPrefix");
			}
			int num = length - 1;
			if (uriPrefix[num] != '/')
			{
				throw new ArgumentException("It ends without '/'.", "uriPrefix");
			}
			int num2 = uriPrefix.IndexOf(':') + 3;
			if (num2 >= num)
			{
				throw new ArgumentException("No host is specified.", "uriPrefix");
			}
			if (uriPrefix[num2] == ':')
			{
				throw new ArgumentException("No host is specified.", "uriPrefix");
			}
			int num3 = uriPrefix.IndexOf('/', num2, length - num2);
			if (num3 == num2)
			{
				throw new ArgumentException("No host is specified.", "uriPrefix");
			}
			if (uriPrefix[num3 - 1] == ':')
			{
				throw new ArgumentException("No port is specified.", "uriPrefix");
			}
			if (num3 == num - 1)
			{
				throw new ArgumentException("No path is specified.", "uriPrefix");
			}
		}

		// Token: 0x060003EA RID: 1002 RVA: 0x00011D00 File Offset: 0x0000FF00
		public override bool Equals(object obj)
		{
			HttpListenerPrefix httpListenerPrefix = obj as HttpListenerPrefix;
			return httpListenerPrefix != null && this._prefix.Equals(httpListenerPrefix._prefix);
		}

		// Token: 0x060003EB RID: 1003 RVA: 0x00011D2A File Offset: 0x0000FF2A
		public override int GetHashCode()
		{
			return this._prefix.GetHashCode();
		}

		// Token: 0x060003EC RID: 1004 RVA: 0x00011D37 File Offset: 0x0000FF37
		public override string ToString()
		{
			return this._prefix;
		}

		// Token: 0x04000170 RID: 368
		private string _host;

		// Token: 0x04000171 RID: 369
		private HttpListener _listener;

		// Token: 0x04000172 RID: 370
		private string _original;

		// Token: 0x04000173 RID: 371
		private string _path;

		// Token: 0x04000174 RID: 372
		private string _port;

		// Token: 0x04000175 RID: 373
		private string _prefix;

		// Token: 0x04000176 RID: 374
		private bool _secure;
	}
}
