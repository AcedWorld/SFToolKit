using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net.WebSockets
{
	// Token: 0x0200082E RID: 2094
	internal sealed class WebSocketHandle
	{
		// Token: 0x060042E9 RID: 17129 RVA: 0x000E8870 File Offset: 0x000E6A70
		public static WebSocketHandle Create()
		{
			return new WebSocketHandle();
		}

		// Token: 0x060042EA RID: 17130 RVA: 0x000E8877 File Offset: 0x000E6A77
		public static bool IsValid(WebSocketHandle handle)
		{
			return handle != null;
		}

		// Token: 0x17000F05 RID: 3845
		// (get) Token: 0x060042EB RID: 17131 RVA: 0x000E8880 File Offset: 0x000E6A80
		public WebSocketCloseStatus? CloseStatus
		{
			get
			{
				WebSocket webSocket = this._webSocket;
				if (webSocket == null)
				{
					return null;
				}
				return webSocket.CloseStatus;
			}
		}

		// Token: 0x17000F06 RID: 3846
		// (get) Token: 0x060042EC RID: 17132 RVA: 0x000E88A6 File Offset: 0x000E6AA6
		public string CloseStatusDescription
		{
			get
			{
				WebSocket webSocket = this._webSocket;
				if (webSocket == null)
				{
					return null;
				}
				return webSocket.CloseStatusDescription;
			}
		}

		// Token: 0x17000F07 RID: 3847
		// (get) Token: 0x060042ED RID: 17133 RVA: 0x000E88B9 File Offset: 0x000E6AB9
		public WebSocketState State
		{
			get
			{
				WebSocket webSocket = this._webSocket;
				if (webSocket == null)
				{
					return this._state;
				}
				return webSocket.State;
			}
		}

		// Token: 0x17000F08 RID: 3848
		// (get) Token: 0x060042EE RID: 17134 RVA: 0x000E88D1 File Offset: 0x000E6AD1
		public string SubProtocol
		{
			get
			{
				WebSocket webSocket = this._webSocket;
				if (webSocket == null)
				{
					return null;
				}
				return webSocket.SubProtocol;
			}
		}

		// Token: 0x060042EF RID: 17135 RVA: 0x00003917 File Offset: 0x00001B17
		public static void CheckPlatformSupport()
		{
		}

		// Token: 0x060042F0 RID: 17136 RVA: 0x000E88E4 File Offset: 0x000E6AE4
		public void Dispose()
		{
			this._state = WebSocketState.Closed;
			WebSocket webSocket = this._webSocket;
			if (webSocket == null)
			{
				return;
			}
			webSocket.Dispose();
		}

		// Token: 0x060042F1 RID: 17137 RVA: 0x000E88FD File Offset: 0x000E6AFD
		public void Abort()
		{
			this._abortSource.Cancel();
			WebSocket webSocket = this._webSocket;
			if (webSocket == null)
			{
				return;
			}
			webSocket.Abort();
		}

		// Token: 0x060042F2 RID: 17138 RVA: 0x000E891A File Offset: 0x000E6B1A
		public Task SendAsync(ArraySegment<byte> buffer, WebSocketMessageType messageType, bool endOfMessage, CancellationToken cancellationToken)
		{
			return this._webSocket.SendAsync(buffer, messageType, endOfMessage, cancellationToken);
		}

		// Token: 0x060042F3 RID: 17139 RVA: 0x000E892C File Offset: 0x000E6B2C
		public ValueTask SendAsync(ReadOnlyMemory<byte> buffer, WebSocketMessageType messageType, bool endOfMessage, CancellationToken cancellationToken)
		{
			return this._webSocket.SendAsync(buffer, messageType, endOfMessage, cancellationToken);
		}

		// Token: 0x060042F4 RID: 17140 RVA: 0x000E893E File Offset: 0x000E6B3E
		public Task<WebSocketReceiveResult> ReceiveAsync(ArraySegment<byte> buffer, CancellationToken cancellationToken)
		{
			return this._webSocket.ReceiveAsync(buffer, cancellationToken);
		}

		// Token: 0x060042F5 RID: 17141 RVA: 0x000E894D File Offset: 0x000E6B4D
		public ValueTask<ValueWebSocketReceiveResult> ReceiveAsync(Memory<byte> buffer, CancellationToken cancellationToken)
		{
			return this._webSocket.ReceiveAsync(buffer, cancellationToken);
		}

		// Token: 0x060042F6 RID: 17142 RVA: 0x000E895C File Offset: 0x000E6B5C
		public Task CloseAsync(WebSocketCloseStatus closeStatus, string statusDescription, CancellationToken cancellationToken)
		{
			return this._webSocket.CloseAsync(closeStatus, statusDescription, cancellationToken);
		}

		// Token: 0x060042F7 RID: 17143 RVA: 0x000E896C File Offset: 0x000E6B6C
		public Task CloseOutputAsync(WebSocketCloseStatus closeStatus, string statusDescription, CancellationToken cancellationToken)
		{
			return this._webSocket.CloseOutputAsync(closeStatus, statusDescription, cancellationToken);
		}

		// Token: 0x060042F8 RID: 17144 RVA: 0x000E897C File Offset: 0x000E6B7C
		public Task ConnectAsyncCore(Uri uri, CancellationToken cancellationToken, ClientWebSocketOptions options)
		{
			WebSocketHandle.<ConnectAsyncCore>d__26 <ConnectAsyncCore>d__;
			<ConnectAsyncCore>d__.<>4__this = this;
			<ConnectAsyncCore>d__.uri = uri;
			<ConnectAsyncCore>d__.cancellationToken = cancellationToken;
			<ConnectAsyncCore>d__.options = options;
			<ConnectAsyncCore>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<ConnectAsyncCore>d__.<>1__state = -1;
			<ConnectAsyncCore>d__.<>t__builder.Start<WebSocketHandle.<ConnectAsyncCore>d__26>(ref <ConnectAsyncCore>d__);
			return <ConnectAsyncCore>d__.<>t__builder.Task;
		}

		// Token: 0x060042F9 RID: 17145 RVA: 0x000E89D8 File Offset: 0x000E6BD8
		private Task<Socket> ConnectSocketAsync(string host, int port, CancellationToken cancellationToken)
		{
			WebSocketHandle.<ConnectSocketAsync>d__27 <ConnectSocketAsync>d__;
			<ConnectSocketAsync>d__.<>4__this = this;
			<ConnectSocketAsync>d__.host = host;
			<ConnectSocketAsync>d__.port = port;
			<ConnectSocketAsync>d__.cancellationToken = cancellationToken;
			<ConnectSocketAsync>d__.<>t__builder = AsyncTaskMethodBuilder<Socket>.Create();
			<ConnectSocketAsync>d__.<>1__state = -1;
			<ConnectSocketAsync>d__.<>t__builder.Start<WebSocketHandle.<ConnectSocketAsync>d__27>(ref <ConnectSocketAsync>d__);
			return <ConnectSocketAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060042FA RID: 17146 RVA: 0x000E8A34 File Offset: 0x000E6C34
		private static byte[] BuildRequestHeader(Uri uri, ClientWebSocketOptions options, string secKey)
		{
			StringBuilder stringBuilder;
			if ((stringBuilder = WebSocketHandle.t_cachedStringBuilder) == null)
			{
				stringBuilder = (WebSocketHandle.t_cachedStringBuilder = new StringBuilder());
			}
			StringBuilder stringBuilder2 = stringBuilder;
			byte[] bytes;
			try
			{
				stringBuilder2.Append("GET ").Append(uri.PathAndQuery).Append(" HTTP/1.1\r\n");
				string value = options.RequestHeaders["Host"];
				stringBuilder2.Append("Host: ");
				if (string.IsNullOrEmpty(value))
				{
					stringBuilder2.Append(uri.IdnHost).Append(':').Append(uri.Port).Append("\r\n");
				}
				else
				{
					stringBuilder2.Append(value).Append("\r\n");
				}
				stringBuilder2.Append("Connection: Upgrade\r\n");
				stringBuilder2.Append("Upgrade: websocket\r\n");
				stringBuilder2.Append("Sec-WebSocket-Version: 13\r\n");
				stringBuilder2.Append("Sec-WebSocket-Key: ").Append(secKey).Append("\r\n");
				foreach (string text in options.RequestHeaders.AllKeys)
				{
					if (!string.Equals(text, "Host", StringComparison.OrdinalIgnoreCase))
					{
						stringBuilder2.Append(text).Append(": ").Append(options.RequestHeaders[text]).Append("\r\n");
					}
				}
				if (options.RequestedSubProtocols.Count > 0)
				{
					stringBuilder2.Append("Sec-WebSocket-Protocol").Append(": ");
					stringBuilder2.Append(options.RequestedSubProtocols[0]);
					for (int j = 1; j < options.RequestedSubProtocols.Count; j++)
					{
						stringBuilder2.Append(", ").Append(options.RequestedSubProtocols[j]);
					}
					stringBuilder2.Append("\r\n");
				}
				if (options.Cookies != null)
				{
					string cookieHeader = options.Cookies.GetCookieHeader(uri);
					if (!string.IsNullOrWhiteSpace(cookieHeader))
					{
						stringBuilder2.Append("Cookie").Append(": ").Append(cookieHeader).Append("\r\n");
					}
				}
				stringBuilder2.Append("\r\n");
				bytes = WebSocketHandle.s_defaultHttpEncoding.GetBytes(stringBuilder2.ToString());
			}
			finally
			{
				stringBuilder2.Clear();
			}
			return bytes;
		}

		// Token: 0x060042FB RID: 17147 RVA: 0x000E8C80 File Offset: 0x000E6E80
		private static KeyValuePair<string, string> CreateSecKeyAndSecWebSocketAccept()
		{
			string text = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
			KeyValuePair<string, string> result;
			using (SHA1 sha = SHA1.Create())
			{
				result = new KeyValuePair<string, string>(text, Convert.ToBase64String(sha.ComputeHash(Encoding.ASCII.GetBytes(text + "258EAFA5-E914-47DA-95CA-C5AB0DC85B11"))));
			}
			return result;
		}

		// Token: 0x060042FC RID: 17148 RVA: 0x000E8CEC File Offset: 0x000E6EEC
		private Task<string> ParseAndValidateConnectResponseAsync(Stream stream, ClientWebSocketOptions options, string expectedSecWebSocketAccept, CancellationToken cancellationToken)
		{
			WebSocketHandle.<ParseAndValidateConnectResponseAsync>d__30 <ParseAndValidateConnectResponseAsync>d__;
			<ParseAndValidateConnectResponseAsync>d__.stream = stream;
			<ParseAndValidateConnectResponseAsync>d__.options = options;
			<ParseAndValidateConnectResponseAsync>d__.expectedSecWebSocketAccept = expectedSecWebSocketAccept;
			<ParseAndValidateConnectResponseAsync>d__.cancellationToken = cancellationToken;
			<ParseAndValidateConnectResponseAsync>d__.<>t__builder = AsyncTaskMethodBuilder<string>.Create();
			<ParseAndValidateConnectResponseAsync>d__.<>1__state = -1;
			<ParseAndValidateConnectResponseAsync>d__.<>t__builder.Start<WebSocketHandle.<ParseAndValidateConnectResponseAsync>d__30>(ref <ParseAndValidateConnectResponseAsync>d__);
			return <ParseAndValidateConnectResponseAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060042FD RID: 17149 RVA: 0x000E8D48 File Offset: 0x000E6F48
		private static void ValidateAndTrackHeader(string targetHeaderName, string targetHeaderValue, string foundHeaderName, string foundHeaderValue, ref bool foundHeader)
		{
			bool flag = string.Equals(targetHeaderName, foundHeaderName, StringComparison.OrdinalIgnoreCase);
			if (!foundHeader)
			{
				if (flag)
				{
					if (!string.Equals(targetHeaderValue, foundHeaderValue, StringComparison.OrdinalIgnoreCase))
					{
						throw new WebSocketException(SR.Format("The '{0}' header value '{1}' is invalid.", targetHeaderName, foundHeaderValue));
					}
					foundHeader = true;
					return;
				}
			}
			else if (flag)
			{
				throw new WebSocketException(SR.Format("Unable to connect to the remote server", Array.Empty<object>()));
			}
		}

		// Token: 0x060042FE RID: 17150 RVA: 0x000E8DA0 File Offset: 0x000E6FA0
		private static Task<string> ReadResponseHeaderLineAsync(Stream stream, CancellationToken cancellationToken)
		{
			WebSocketHandle.<ReadResponseHeaderLineAsync>d__32 <ReadResponseHeaderLineAsync>d__;
			<ReadResponseHeaderLineAsync>d__.stream = stream;
			<ReadResponseHeaderLineAsync>d__.cancellationToken = cancellationToken;
			<ReadResponseHeaderLineAsync>d__.<>t__builder = AsyncTaskMethodBuilder<string>.Create();
			<ReadResponseHeaderLineAsync>d__.<>1__state = -1;
			<ReadResponseHeaderLineAsync>d__.<>t__builder.Start<WebSocketHandle.<ReadResponseHeaderLineAsync>d__32>(ref <ReadResponseHeaderLineAsync>d__);
			return <ReadResponseHeaderLineAsync>d__.<>t__builder.Task;
		}

		// Token: 0x04002853 RID: 10323
		[ThreadStatic]
		private static StringBuilder t_cachedStringBuilder;

		// Token: 0x04002854 RID: 10324
		private static readonly Encoding s_defaultHttpEncoding = Encoding.GetEncoding(28591);

		// Token: 0x04002855 RID: 10325
		private const int DefaultReceiveBufferSize = 4096;

		// Token: 0x04002856 RID: 10326
		private const string WSServerGuid = "258EAFA5-E914-47DA-95CA-C5AB0DC85B11";

		// Token: 0x04002857 RID: 10327
		private readonly CancellationTokenSource _abortSource = new CancellationTokenSource();

		// Token: 0x04002858 RID: 10328
		private WebSocketState _state = WebSocketState.Connecting;

		// Token: 0x04002859 RID: 10329
		private WebSocket _webSocket;
	}
}
