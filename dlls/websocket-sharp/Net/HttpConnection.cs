using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace WebSocketSharp.Net
{
	// Token: 0x0200001F RID: 31
	internal sealed class HttpConnection
	{
		// Token: 0x06000222 RID: 546 RVA: 0x0000EAE8 File Offset: 0x0000CCE8
		internal HttpConnection(Socket socket, EndPointListener listener)
		{
			this._socket = socket;
			this._listener = listener;
			NetworkStream networkStream = new NetworkStream(socket, false);
			bool isSecure = listener.IsSecure;
			if (isSecure)
			{
				ServerSslConfiguration sslConfiguration = listener.SslConfiguration;
				SslStream sslStream = new SslStream(networkStream, false, sslConfiguration.ClientCertificateValidationCallback);
				sslStream.AuthenticateAsServer(sslConfiguration.ServerCertificate, sslConfiguration.ClientCertificateRequired, sslConfiguration.EnabledSslProtocols, sslConfiguration.CheckCertificateRevocation);
				this._secure = true;
				this._stream = sslStream;
			}
			else
			{
				this._stream = networkStream;
			}
			this._buffer = new byte[HttpConnection._bufferLength];
			this._localEndPoint = socket.LocalEndPoint;
			this._remoteEndPoint = socket.RemoteEndPoint;
			this._sync = new object();
			this._timeoutCanceled = new Dictionary<int, bool>();
			this._timer = new Timer(new TimerCallback(HttpConnection.onTimeout), this, -1, -1);
			this.init(90000);
		}

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x06000223 RID: 547 RVA: 0x0000EBD0 File Offset: 0x0000CDD0
		public bool IsClosed
		{
			get
			{
				return this._socket == null;
			}
		}

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x06000224 RID: 548 RVA: 0x0000EBEC File Offset: 0x0000CDEC
		public bool IsLocal
		{
			get
			{
				return ((IPEndPoint)this._remoteEndPoint).Address.IsLocal();
			}
		}

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x06000225 RID: 549 RVA: 0x0000EC14 File Offset: 0x0000CE14
		public bool IsSecure
		{
			get
			{
				return this._secure;
			}
		}

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x06000226 RID: 550 RVA: 0x0000EC2C File Offset: 0x0000CE2C
		public IPEndPoint LocalEndPoint
		{
			get
			{
				return (IPEndPoint)this._localEndPoint;
			}
		}

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x06000227 RID: 551 RVA: 0x0000EC4C File Offset: 0x0000CE4C
		public IPEndPoint RemoteEndPoint
		{
			get
			{
				return (IPEndPoint)this._remoteEndPoint;
			}
		}

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x06000228 RID: 552 RVA: 0x0000EC6C File Offset: 0x0000CE6C
		public int Reuses
		{
			get
			{
				return this._reuses;
			}
		}

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x06000229 RID: 553 RVA: 0x0000EC84 File Offset: 0x0000CE84
		public Stream Stream
		{
			get
			{
				return this._stream;
			}
		}

		// Token: 0x0600022A RID: 554 RVA: 0x0000EC9C File Offset: 0x0000CE9C
		private void close()
		{
			object sync = this._sync;
			lock (sync)
			{
				bool flag2 = this._socket == null;
				if (flag2)
				{
					return;
				}
				this.disposeTimer();
				this.disposeRequestBuffer();
				this.disposeStream();
				this.closeSocket();
			}
			this._context.Unregister();
			this._listener.RemoveConnection(this);
		}

		// Token: 0x0600022B RID: 555 RVA: 0x0000ED20 File Offset: 0x0000CF20
		private void closeSocket()
		{
			try
			{
				this._socket.Shutdown(SocketShutdown.Both);
			}
			catch
			{
			}
			this._socket.Close();
			this._socket = null;
		}

		// Token: 0x0600022C RID: 556 RVA: 0x0000ED68 File Offset: 0x0000CF68
		private void disposeRequestBuffer()
		{
			bool flag = this._requestBuffer == null;
			if (!flag)
			{
				this._requestBuffer.Dispose();
				this._requestBuffer = null;
			}
		}

		// Token: 0x0600022D RID: 557 RVA: 0x0000ED98 File Offset: 0x0000CF98
		private void disposeStream()
		{
			bool flag = this._stream == null;
			if (!flag)
			{
				this._stream.Dispose();
				this._stream = null;
			}
		}

		// Token: 0x0600022E RID: 558 RVA: 0x0000EDC8 File Offset: 0x0000CFC8
		private void disposeTimer()
		{
			bool flag = this._timer == null;
			if (!flag)
			{
				try
				{
					this._timer.Change(-1, -1);
				}
				catch
				{
				}
				this._timer.Dispose();
				this._timer = null;
			}
		}

		// Token: 0x0600022F RID: 559 RVA: 0x0000EE20 File Offset: 0x0000D020
		private void init(int timeout)
		{
			this._timeout = timeout;
			this._context = new HttpListenerContext(this);
			this._currentLine = new StringBuilder(64);
			this._inputState = InputState.RequestLine;
			this._inputStream = null;
			this._lineState = LineState.None;
			this._outputStream = null;
			this._position = 0;
			this._requestBuffer = new MemoryStream();
		}

		// Token: 0x06000230 RID: 560 RVA: 0x0000EE7C File Offset: 0x0000D07C
		private static void onRead(IAsyncResult asyncResult)
		{
			HttpConnection httpConnection = (HttpConnection)asyncResult.AsyncState;
			int attempts = httpConnection._attempts;
			bool flag = httpConnection._socket == null;
			if (!flag)
			{
				object sync = httpConnection._sync;
				lock (sync)
				{
					bool flag3 = httpConnection._socket == null;
					if (!flag3)
					{
						httpConnection._timer.Change(-1, -1);
						httpConnection._timeoutCanceled[attempts] = true;
						int num = 0;
						try
						{
							num = httpConnection._stream.EndRead(asyncResult);
						}
						catch (Exception)
						{
							httpConnection.close();
							return;
						}
						bool flag4 = num <= 0;
						if (flag4)
						{
							httpConnection.close();
						}
						else
						{
							httpConnection._requestBuffer.Write(httpConnection._buffer, 0, num);
							int length = (int)httpConnection._requestBuffer.Length;
							bool flag5 = httpConnection.processInput(httpConnection._requestBuffer.GetBuffer(), length);
							if (flag5)
							{
								bool flag6 = !httpConnection._context.HasErrorMessage;
								if (flag6)
								{
									httpConnection._context.Request.FinishInitialization();
								}
								bool hasErrorMessage = httpConnection._context.HasErrorMessage;
								if (hasErrorMessage)
								{
									httpConnection._context.SendError();
								}
								else
								{
									Uri url = httpConnection._context.Request.Url;
									HttpListener httpListener;
									bool flag7 = httpConnection._listener.TrySearchHttpListener(url, out httpListener);
									if (flag7)
									{
										bool flag8 = !httpListener.AuthenticateContext(httpConnection._context);
										if (!flag8)
										{
											bool flag9 = !httpListener.RegisterContext(httpConnection._context);
											if (flag9)
											{
												httpConnection._context.ErrorStatusCode = 503;
												httpConnection._context.SendError();
											}
										}
									}
									else
									{
										httpConnection._context.ErrorStatusCode = 404;
										httpConnection._context.SendError();
									}
								}
							}
							else
							{
								httpConnection.BeginReadRequest();
							}
						}
					}
				}
			}
		}

		// Token: 0x06000231 RID: 561 RVA: 0x0000F09C File Offset: 0x0000D29C
		private static void onTimeout(object state)
		{
			HttpConnection httpConnection = (HttpConnection)state;
			int attempts = httpConnection._attempts;
			bool flag = httpConnection._socket == null;
			if (!flag)
			{
				object sync = httpConnection._sync;
				lock (sync)
				{
					bool flag3 = httpConnection._socket == null;
					if (!flag3)
					{
						bool flag4 = httpConnection._timeoutCanceled[attempts];
						if (!flag4)
						{
							httpConnection._context.ErrorStatusCode = 408;
							httpConnection._context.SendError();
						}
					}
				}
			}
		}

		// Token: 0x06000232 RID: 562 RVA: 0x0000F13C File Offset: 0x0000D33C
		private bool processInput(byte[] data, int length)
		{
			try
			{
				for (;;)
				{
					int num;
					string text = this.readLineFrom(data, this._position, length, out num);
					this._position += num;
					bool flag = text == null;
					if (flag)
					{
						break;
					}
					bool flag2 = text.Length == 0;
					if (flag2)
					{
						bool flag3 = this._inputState == InputState.RequestLine;
						if (!flag3)
						{
							goto IL_56;
						}
					}
					else
					{
						bool flag4 = this._inputState == InputState.RequestLine;
						if (flag4)
						{
							this._context.Request.SetRequestLine(text);
							this._inputState = InputState.Headers;
						}
						else
						{
							this._context.Request.AddHeader(text);
						}
						bool hasErrorMessage = this._context.HasErrorMessage;
						if (hasErrorMessage)
						{
							goto Block_8;
						}
					}
				}
				goto IL_FF;
				IL_56:
				bool flag5 = this._position > HttpConnection._maxInputLength;
				if (flag5)
				{
					this._context.ErrorMessage = "Headers too long";
				}
				return true;
				Block_8:
				return true;
			}
			catch (Exception ex)
			{
				this._context.ErrorMessage = ex.Message;
				return true;
			}
			IL_FF:
			bool flag6 = this._position >= HttpConnection._maxInputLength;
			bool result;
			if (flag6)
			{
				this._context.ErrorMessage = "Headers too long";
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000233 RID: 563 RVA: 0x0000F28C File Offset: 0x0000D48C
		private string readLineFrom(byte[] buffer, int offset, int length, out int nread)
		{
			nread = 0;
			for (int i = offset; i < length; i++)
			{
				nread++;
				byte b = buffer[i];
				bool flag = b == 13;
				if (flag)
				{
					this._lineState = LineState.Cr;
				}
				else
				{
					bool flag2 = b == 10;
					if (flag2)
					{
						this._lineState = LineState.Lf;
						break;
					}
					this._currentLine.Append((char)b);
				}
			}
			bool flag3 = this._lineState != LineState.Lf;
			string result;
			if (flag3)
			{
				result = null;
			}
			else
			{
				string text = this._currentLine.ToString();
				this._currentLine.Length = 0;
				this._lineState = LineState.None;
				result = text;
			}
			return result;
		}

		// Token: 0x06000234 RID: 564 RVA: 0x0000F334 File Offset: 0x0000D534
		internal void BeginReadRequest()
		{
			this._attempts++;
			this._timeoutCanceled.Add(this._attempts, false);
			this._timer.Change(this._timeout, -1);
			try
			{
				this._stream.BeginRead(this._buffer, 0, HttpConnection._bufferLength, new AsyncCallback(HttpConnection.onRead), this);
			}
			catch (Exception)
			{
				this.close();
			}
		}

		// Token: 0x06000235 RID: 565 RVA: 0x0000F3BC File Offset: 0x0000D5BC
		internal void Close(bool force)
		{
			bool flag = this._socket == null;
			if (!flag)
			{
				object sync = this._sync;
				lock (sync)
				{
					bool flag3 = this._socket == null;
					if (!flag3)
					{
						if (force)
						{
							bool flag4 = this._outputStream != null;
							if (flag4)
							{
								this._outputStream.Close(true);
							}
							this.close();
						}
						else
						{
							this.GetResponseStream().Close(false);
							bool closeConnection = this._context.Response.CloseConnection;
							if (closeConnection)
							{
								this.close();
							}
							else
							{
								bool flag5 = !this._context.Request.FlushInput();
								if (flag5)
								{
									this.close();
								}
								else
								{
									this.disposeRequestBuffer();
									this._context.Unregister();
									this._reuses++;
									this.init(15000);
									this.BeginReadRequest();
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06000236 RID: 566 RVA: 0x0000F4D4 File Offset: 0x0000D6D4
		public void Close()
		{
			this.Close(false);
		}

		// Token: 0x06000237 RID: 567 RVA: 0x0000F4E0 File Offset: 0x0000D6E0
		public RequestStream GetRequestStream(long contentLength, bool chunked)
		{
			object sync = this._sync;
			RequestStream result;
			lock (sync)
			{
				bool flag2 = this._socket == null;
				if (flag2)
				{
					result = null;
				}
				else
				{
					bool flag3 = this._inputStream != null;
					if (flag3)
					{
						result = this._inputStream;
					}
					else
					{
						byte[] buffer = this._requestBuffer.GetBuffer();
						int num = (int)this._requestBuffer.Length;
						int count = num - this._position;
						this.disposeRequestBuffer();
						this._inputStream = (chunked ? new ChunkedRequestStream(this._stream, buffer, this._position, count, this._context) : new RequestStream(this._stream, buffer, this._position, count, contentLength));
						result = this._inputStream;
					}
				}
			}
			return result;
		}

		// Token: 0x06000238 RID: 568 RVA: 0x0000F5BC File Offset: 0x0000D7BC
		public ResponseStream GetResponseStream()
		{
			object sync = this._sync;
			ResponseStream result;
			lock (sync)
			{
				bool flag2 = this._socket == null;
				if (flag2)
				{
					result = null;
				}
				else
				{
					bool flag3 = this._outputStream != null;
					if (flag3)
					{
						result = this._outputStream;
					}
					else
					{
						HttpListener listener = this._context.Listener;
						bool ignoreWriteExceptions = listener == null || listener.IgnoreWriteExceptions;
						this._outputStream = new ResponseStream(this._stream, this._context.Response, ignoreWriteExceptions);
						result = this._outputStream;
					}
				}
			}
			return result;
		}

		// Token: 0x040000C2 RID: 194
		private int _attempts;

		// Token: 0x040000C3 RID: 195
		private byte[] _buffer;

		// Token: 0x040000C4 RID: 196
		private static readonly int _bufferLength = 8192;

		// Token: 0x040000C5 RID: 197
		private HttpListenerContext _context;

		// Token: 0x040000C6 RID: 198
		private StringBuilder _currentLine;

		// Token: 0x040000C7 RID: 199
		private InputState _inputState;

		// Token: 0x040000C8 RID: 200
		private RequestStream _inputStream;

		// Token: 0x040000C9 RID: 201
		private LineState _lineState;

		// Token: 0x040000CA RID: 202
		private EndPointListener _listener;

		// Token: 0x040000CB RID: 203
		private EndPoint _localEndPoint;

		// Token: 0x040000CC RID: 204
		private static readonly int _maxInputLength = 32768;

		// Token: 0x040000CD RID: 205
		private ResponseStream _outputStream;

		// Token: 0x040000CE RID: 206
		private int _position;

		// Token: 0x040000CF RID: 207
		private EndPoint _remoteEndPoint;

		// Token: 0x040000D0 RID: 208
		private MemoryStream _requestBuffer;

		// Token: 0x040000D1 RID: 209
		private int _reuses;

		// Token: 0x040000D2 RID: 210
		private bool _secure;

		// Token: 0x040000D3 RID: 211
		private Socket _socket;

		// Token: 0x040000D4 RID: 212
		private Stream _stream;

		// Token: 0x040000D5 RID: 213
		private object _sync;

		// Token: 0x040000D6 RID: 214
		private int _timeout;

		// Token: 0x040000D7 RID: 215
		private Dictionary<int, bool> _timeoutCanceled;

		// Token: 0x040000D8 RID: 216
		private Timer _timer;
	}
}
