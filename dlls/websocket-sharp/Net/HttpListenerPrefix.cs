using System;

namespace WebSocketSharp.Net
{
	// Token: 0x0200003C RID: 60
	internal sealed class HttpListenerPrefix
	{
		// Token: 0x060003E4 RID: 996 RVA: 0x000184A1 File Offset: 0x000166A1
		internal HttpListenerPrefix(string uriPrefix, HttpListener listener)
		{
			this._original = uriPrefix;
			this._listener = listener;
			this.parse(uriPrefix);
		}

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x060003E5 RID: 997 RVA: 0x000184C4 File Offset: 0x000166C4
		public string Host
		{
			get
			{
				return this._host;
			}
		}

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x060003E6 RID: 998 RVA: 0x000184DC File Offset: 0x000166DC
		public bool IsSecure
		{
			get
			{
				return this._secure;
			}
		}

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x060003E7 RID: 999 RVA: 0x000184F4 File Offset: 0x000166F4
		public HttpListener Listener
		{
			get
			{
				return this._listener;
			}
		}

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x060003E8 RID: 1000 RVA: 0x0001850C File Offset: 0x0001670C
		public string Original
		{
			get
			{
				return this._original;
			}
		}

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x060003E9 RID: 1001 RVA: 0x00018524 File Offset: 0x00016724
		public string Path
		{
			get
			{
				return this._path;
			}
		}

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x060003EA RID: 1002 RVA: 0x0001853C File Offset: 0x0001673C
		public string Port
		{
			get
			{
				return this._port;
			}
		}

		// Token: 0x060003EB RID: 1003 RVA: 0x00018554 File Offset: 0x00016754
		private void parse(string uriPrefix)
		{
			bool flag = uriPrefix.StartsWith("https");
			if (flag)
			{
				this._secure = true;
			}
			int length = uriPrefix.Length;
			int num = uriPrefix.IndexOf(':') + 3;
			int num2 = uriPrefix.IndexOf('/', num + 1, length - num - 1);
			int num3 = uriPrefix.LastIndexOf(':', num2 - 1, num2 - num - 1);
			bool flag2 = uriPrefix[num2 - 1] != ']' && num3 > num;
			if (flag2)
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

		// Token: 0x060003EC RID: 1004 RVA: 0x00018674 File Offset: 0x00016874
		public static void CheckPrefix(string uriPrefix)
		{
			bool flag = uriPrefix == null;
			if (flag)
			{
				throw new ArgumentNullException("uriPrefix");
			}
			int length = uriPrefix.Length;
			bool flag2 = length == 0;
			if (flag2)
			{
				string message = "An empty string.";
				throw new ArgumentException(message, "uriPrefix");
			}
			bool flag3 = uriPrefix.StartsWith("http://") || uriPrefix.StartsWith("https://");
			bool flag4 = !flag3;
			if (flag4)
			{
				string message2 = "The scheme is not 'http' or 'https'.";
				throw new ArgumentException(message2, "uriPrefix");
			}
			int num = length - 1;
			bool flag5 = uriPrefix[num] != '/';
			if (flag5)
			{
				string message3 = "It ends without '/'.";
				throw new ArgumentException(message3, "uriPrefix");
			}
			int num2 = uriPrefix.IndexOf(':') + 3;
			bool flag6 = num2 >= num;
			if (flag6)
			{
				string message4 = "No host is specified.";
				throw new ArgumentException(message4, "uriPrefix");
			}
			bool flag7 = uriPrefix[num2] == ':';
			if (flag7)
			{
				string message5 = "No host is specified.";
				throw new ArgumentException(message5, "uriPrefix");
			}
			int num3 = uriPrefix.IndexOf('/', num2, length - num2);
			bool flag8 = num3 == num2;
			if (flag8)
			{
				string message6 = "No host is specified.";
				throw new ArgumentException(message6, "uriPrefix");
			}
			bool flag9 = uriPrefix[num3 - 1] == ':';
			if (flag9)
			{
				string message7 = "No port is specified.";
				throw new ArgumentException(message7, "uriPrefix");
			}
			bool flag10 = num3 == num - 1;
			if (flag10)
			{
				string message8 = "No path is specified.";
				throw new ArgumentException(message8, "uriPrefix");
			}
		}

		// Token: 0x060003ED RID: 1005 RVA: 0x000187F4 File Offset: 0x000169F4
		public override bool Equals(object obj)
		{
			HttpListenerPrefix httpListenerPrefix = obj as HttpListenerPrefix;
			return httpListenerPrefix != null && this._prefix.Equals(httpListenerPrefix._prefix);
		}

		// Token: 0x060003EE RID: 1006 RVA: 0x00018824 File Offset: 0x00016A24
		public override int GetHashCode()
		{
			return this._prefix.GetHashCode();
		}

		// Token: 0x060003EF RID: 1007 RVA: 0x00018844 File Offset: 0x00016A44
		public override string ToString()
		{
			return this._prefix;
		}

		// Token: 0x04000198 RID: 408
		private string _host;

		// Token: 0x04000199 RID: 409
		private HttpListener _listener;

		// Token: 0x0400019A RID: 410
		private string _original;

		// Token: 0x0400019B RID: 411
		private string _path;

		// Token: 0x0400019C RID: 412
		private string _port;

		// Token: 0x0400019D RID: 413
		private string _prefix;

		// Token: 0x0400019E RID: 414
		private bool _secure;
	}
}
