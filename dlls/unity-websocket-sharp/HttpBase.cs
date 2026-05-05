using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using UnityWebSocketSharp.Net;

namespace UnityWebSocketSharp
{
	// Token: 0x0200000A RID: 10
	internal abstract class HttpBase
	{
		// Token: 0x06000069 RID: 105 RVA: 0x0000390B File Offset: 0x00001B0B
		protected HttpBase(Version version, NameValueCollection headers)
		{
			this._version = version;
			this._headers = headers;
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600006A RID: 106 RVA: 0x00003921 File Offset: 0x00001B21
		internal byte[] MessageBodyData
		{
			get
			{
				return this._messageBodyData;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600006B RID: 107 RVA: 0x0000392C File Offset: 0x00001B2C
		protected string HeaderSection
		{
			get
			{
				StringBuilder stringBuilder = new StringBuilder(64);
				foreach (string text in this._headers.AllKeys)
				{
					stringBuilder.AppendFormat("{0}: {1}{2}", text, this._headers[text], HttpBase.CrLf);
				}
				stringBuilder.Append(HttpBase.CrLf);
				return stringBuilder.ToString();
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600006C RID: 108 RVA: 0x0000398F File Offset: 0x00001B8F
		public bool HasMessageBody
		{
			get
			{
				return this._messageBodyData != null;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600006D RID: 109 RVA: 0x0000399A File Offset: 0x00001B9A
		public NameValueCollection Headers
		{
			get
			{
				return this._headers;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600006E RID: 110 RVA: 0x000039A2 File Offset: 0x00001BA2
		public string MessageBody
		{
			get
			{
				if (this._messageBody == null)
				{
					this._messageBody = this.getMessageBody();
				}
				return this._messageBody;
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600006F RID: 111
		public abstract string MessageHeader { get; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000070 RID: 112 RVA: 0x000039BE File Offset: 0x00001BBE
		public Version ProtocolVersion
		{
			get
			{
				return this._version;
			}
		}

		// Token: 0x06000071 RID: 113 RVA: 0x000039C8 File Offset: 0x00001BC8
		private string getMessageBody()
		{
			if (this._messageBodyData == null || (long)this._messageBodyData.Length == 0L)
			{
				return string.Empty;
			}
			string text = this._headers["Content-Type"];
			return ((text != null && text.Length > 0) ? HttpUtility.GetEncoding(text) : Encoding.UTF8).GetString(this._messageBodyData);
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00003A24 File Offset: 0x00001C24
		private static byte[] readMessageBodyFrom(Stream stream, string length)
		{
			long num;
			if (!long.TryParse(length, out num))
			{
				throw new ArgumentException("It cannot be parsed.", "length");
			}
			if (num < 0L)
			{
				string message = "It is less than zero.";
				throw new ArgumentOutOfRangeException("length", message);
			}
			if (num > 1024L)
			{
				return stream.ReadBytes(num, 1024);
			}
			if (num <= 0L)
			{
				return null;
			}
			return stream.ReadBytes((int)num);
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00003A88 File Offset: 0x00001C88
		private static string[] readMessageHeaderFrom(Stream stream)
		{
			List<byte> buff = new List<byte>();
			int cnt = 0;
			Action<int> beforeComparing = delegate(int i)
			{
				if (i == -1)
				{
					throw new EndOfStreamException("The header could not be read from the data stream.");
				}
				buff.Add((byte)i);
				int cnt = cnt;
				cnt++;
			};
			for (;;)
			{
				bool flag = stream.ReadByte().IsEqualTo('\r', beforeComparing) && stream.ReadByte().IsEqualTo('\n', beforeComparing) && stream.ReadByte().IsEqualTo('\r', beforeComparing) && stream.ReadByte().IsEqualTo('\n', beforeComparing);
				if (cnt > HttpBase._maxMessageHeaderLength)
				{
					break;
				}
				if (flag)
				{
					goto Block_5;
				}
			}
			throw new InvalidOperationException("The length of the header is greater than the max length.");
			Block_5:
			byte[] bytes = buff.ToArray();
			return Encoding.UTF8.GetString(bytes).Replace(HttpBase.CrLfSp, " ").Replace(HttpBase.CrLfHt, " ").Split(new string[]
			{
				HttpBase.CrLf
			}, StringSplitOptions.RemoveEmptyEntries);
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00003B64 File Offset: 0x00001D64
		internal void WriteTo(Stream stream)
		{
			byte[] array = this.ToByteArray();
			stream.Write(array, 0, array.Length);
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00003B84 File Offset: 0x00001D84
		protected static T Read<T>(Stream stream, Func<string[], T> parser, int millisecondsTimeout) where T : HttpBase
		{
			T t = default(T);
			bool timeout = false;
			Timer timer = new Timer(delegate(object state)
			{
				timeout = true;
				stream.Close();
			}, null, millisecondsTimeout, -1);
			Exception ex = null;
			try
			{
				string[] arg = HttpBase.readMessageHeaderFrom(stream);
				t = parser(arg);
				string text = t.Headers["Content-Length"];
				if (text != null && text.Length > 0)
				{
					t._messageBodyData = HttpBase.readMessageBodyFrom(stream, text);
				}
			}
			catch (Exception ex)
			{
			}
			finally
			{
				timer.Change(-1, -1);
				timer.Dispose();
			}
			if (timeout)
			{
				throw new WebSocketException("A timeout has occurred.");
			}
			if (ex != null)
			{
				throw new WebSocketException("An exception has occurred.", ex);
			}
			return t;
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00003C6C File Offset: 0x00001E6C
		public byte[] ToByteArray()
		{
			byte[] bytes = Encoding.UTF8.GetBytes(this.MessageHeader);
			if (this._messageBodyData == null)
			{
				return bytes;
			}
			return bytes.Concat(this._messageBodyData).ToArray<byte>();
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00003CA5 File Offset: 0x00001EA5
		public override string ToString()
		{
			if (this._messageBodyData == null)
			{
				return this.MessageHeader;
			}
			return this.MessageHeader + this.MessageBody;
		}

		// Token: 0x0400001F RID: 31
		private NameValueCollection _headers;

		// Token: 0x04000020 RID: 32
		private static readonly int _maxMessageHeaderLength = 8192;

		// Token: 0x04000021 RID: 33
		private string _messageBody;

		// Token: 0x04000022 RID: 34
		private byte[] _messageBodyData;

		// Token: 0x04000023 RID: 35
		private Version _version;

		// Token: 0x04000024 RID: 36
		protected static readonly string CrLf = "\r\n";

		// Token: 0x04000025 RID: 37
		protected static readonly string CrLfHt = "\r\n\t";

		// Token: 0x04000026 RID: 38
		protected static readonly string CrLfSp = "\r\n ";
	}
}
