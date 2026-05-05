using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace UnityWebSocketSharp.Net
{
	// Token: 0x02000030 RID: 48
	internal sealed class HttpConnection
	{
		// Token: 0x06000360 RID: 864 RVA: 0x0000FFD4 File Offset: 0x0000E1D4
		internal HttpConnection(Socket socket, EndPointListener listener)
		{
			this._socket = socket;
			this._endPointListener = listener;
			NetworkStream networkStream = new NetworkStream(socket, false);
			if (listener.IsSecure)
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
			this.init(new MemoryStream(), 90000);
		}

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x06000361 RID: 865 RVA: 0x000100B7 File Offset: 0x0000E2B7
		public bool IsClosed
		{
			get
			{
				return this._socket == null;
			}
		}

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x06000362 RID: 866 RVA: 0x000100C2 File Offset: 0x0000E2C2
		public bool IsLocal
		{
			get
			{
				return ((IPEndPoint)this._remoteEndPoint).Address.IsLocal();
			}
		}

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x06000363 RID: 867 RVA: 0x000100D9 File Offset: 0x0000E2D9
		public bool IsSecure
		{
			get
			{
				return this._secure;
			}
		}

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x06000364 RID: 868 RVA: 0x000100E1 File Offset: 0x0000E2E1
		public IPEndPoint LocalEndPoint
		{
			get
			{
				return (IPEndPoint)this._localEndPoint;
			}
		}

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x06000365 RID: 869 RVA: 0x000100EE File Offset: 0x0000E2EE
		public IPEndPoint RemoteEndPoint
		{
			get
			{
				return (IPEndPoint)this._remoteEndPoint;
			}
		}

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x06000366 RID: 870 RVA: 0x000100FB File Offset: 0x0000E2FB
		public int Reuses
		{
			get
			{
				return this._reuses;
			}
		}

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x06000367 RID: 871 RVA: 0x00010103 File Offset: 0x0000E303
		public Stream Stream
		{
			get
			{
				return this._stream;
			}
		}

		// Token: 0x06000368 RID: 872 RVA: 0x0001010C File Offset: 0x0000E30C
		private void close()
		{
			object sync = this._sync;
			lock (sync)
			{
				if (this._socket == null)
				{
					return;
				}
				this.disposeTimer();
				this.disposeRequestBuffer();
				this.disposeStream();
				this.closeSocket();
			}
			this._context.Unregister();
			this._endPointListener.RemoveConnection(this);
		}

		// Token: 0x06000369 RID: 873 RVA: 0x00010180 File Offset: 0x0000E380
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

		// Token: 0x0600036A RID: 874 RVA: 0x000101C0 File Offset: 0x0000E3C0
		private static MemoryStream createRequestBuffer(RequestStream inputStream)
		{
			MemoryStream memoryStream = new MemoryStream();
			if (inputStream is ChunkedRequestStream)
			{
				ChunkedRequestStream chunkedRequestStream = (ChunkedRequestStream)inputStream;
				if (chunkedRequestStream.HasRemainingBuffer)
				{
					byte[] remainingBuffer = chunkedRequestStream.RemainingBuffer;
					memoryStream.Write(remainingBuffer, 0, remainingBuffer.Length);
				}
				return memoryStream;
			}
			int count = inputStream.Count;
			if (count > 0)
			{
				memoryStream.Write(inputStream.InitialBuffer, inputStream.Offset, count);
			}
			return memoryStream;
		}

		// Token: 0x0600036B RID: 875 RVA: 0x0001021D File Offset: 0x0000E41D
		private void disposeRequestBuffer()
		{
			if (this._requestBuffer == null)
			{
				return;
			}
			this._requestBuffer.Dispose();
			this._requestBuffer = null;
		}

		// Token: 0x0600036C RID: 876 RVA: 0x0001023A File Offset: 0x0000E43A
		private void disposeStream()
		{
			if (this._stream == null)
			{
				return;
			}
			this._stream.Dispose();
			this._stream = null;
		}

		// Token: 0x0600036D RID: 877 RVA: 0x00010258 File Offset: 0x0000E458
		private void disposeTimer()
		{
			if (this._timer == null)
			{
				return;
			}
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

		// Token: 0x0600036E RID: 878 RVA: 0x000102A4 File Offset: 0x0000E4A4
		private void init(MemoryStream requestBuffer, int timeout)
		{
			this._requestBuffer = requestBuffer;
			this._timeout = timeout;
			this._context = new HttpListenerContext(this);
			this._currentLine = new StringBuilder(64);
			this._inputState = InputState.RequestLine;
			this._inputStream = null;
			this._lineState = LineState.None;
			this._outputStream = null;
			this._position = 0;
		}

		// Token: 0x0600036F RID: 879 RVA: 0x000102FC File Offset: 0x0000E4FC
		private static void onRead(IAsyncResult asyncResult)
		{
			HttpConnection httpConnection = (HttpConnection)asyncResult.AsyncState;
			int attempts = httpConnection._attempts;
			if (httpConnection._socket == null)
			{
				return;
			}
			object sync = httpConnection._sync;
			lock (sync)
			{
				if (httpConnection._socket != null)
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
					if (num <= 0)
					{
						httpConnection.close();
					}
					else
					{
						httpConnection._requestBuffer.Write(httpConnection._buffer, 0, num);
						if (!httpConnection.processRequestBuffer())
						{
							httpConnection.BeginReadRequest();
						}
					}
				}
			}
		}

		// Token: 0x06000370 RID: 880 RVA: 0x000103D0 File Offset: 0x0000E5D0
		private static void onTimeout(object state)
		{
			HttpConnection httpConnection = (HttpConnection)state;
			int attempts = httpConnection._attempts;
			if (httpConnection._socket == null)
			{
				return;
			}
			object sync = httpConnection._sync;
			lock (sync)
			{
				if (httpConnection._socket != null)
				{
					if (!httpConnection._timeoutCanceled[attempts])
					{
						httpConnection._context.SendError(408);
					}
				}
			}
		}

		// Token: 0x06000371 RID: 881 RVA: 0x0001044C File Offset: 0x0000E64C
		private bool processInput(byte[] data, int length)
		{
			HttpListenerRequest request = this._context.Request;
			try
			{
				for (;;)
				{
					int num;
					string text = this.readLineFrom(data, this._position, length, out num);
					this._position += num;
					if (text == null)
					{
						goto IL_8F;
					}
					if (text.Length == 0)
					{
						if (this._inputState != InputState.RequestLine)
						{
							break;
						}
					}
					else
					{
						if (this._inputState == InputState.RequestLine)
						{
							request.SetRequestLine(text);
							this._inputState = InputState.Headers;
						}
						else
						{
							request.AddHeader(text);
						}
						if (this._context.HasErrorMessage)
						{
							goto Block_8;
						}
					}
				}
				if (this._position > HttpConnection._maxInputLength)
				{
					this._context.ErrorMessage = "Headers too long";
				}
				return true;
				Block_8:
				return true;
				IL_8F:;
			}
			catch (Exception)
			{
				this._context.ErrorMessage = "Processing failure";
				return true;
			}
			if (this._position >= HttpConnection._maxInputLength)
			{
				this._context.ErrorMessage = "Headers too long";
				return true;
			}
			return false;
		}

		// Token: 0x06000372 RID: 882 RVA: 0x00010534 File Offset: 0x0000E734
		private bool processRequestBuffer()
		{
			byte[] buffer = this._requestBuffer.GetBuffer();
			int length = (int)this._requestBuffer.Length;
			if (!this.processInput(buffer, length))
			{
				return false;
			}
			HttpListenerRequest request = this._context.Request;
			if (!this._context.HasErrorMessage)
			{
				request.FinishInitialization();
			}
			if (this._context.HasErrorMessage)
			{
				this._context.SendError();
				return true;
			}
			Uri url = request.Url;
			HttpListener httpListener;
			if (!this._endPointListener.TrySearchHttpListener(url, out httpListener))
			{
				this._context.SendError(404);
				return true;
			}
			httpListener.RegisterContext(this._context);
			return true;
		}

		// Token: 0x06000373 RID: 883 RVA: 0x000105D8 File Offset: 0x0000E7D8
		private string readLineFrom(byte[] buffer, int offset, int length, out int nread)
		{
			nread = 0;
			for (int i = offset; i < length; i++)
			{
				nread++;
				byte b = buffer[i];
				if (b == 13)
				{
					this._lineState = LineState.Cr;
				}
				else
				{
					if (b == 10)
					{
						this._lineState = LineState.Lf;
						break;
					}
					this._currentLine.Append((char)b);
				}
			}
			if (this._lineState != LineState.Lf)
			{
				return null;
			}
			string result = this._currentLine.ToString();
			this._currentLine.Length = 0;
			this._lineState = LineState.None;
			return result;
		}

		// Token: 0x06000374 RID: 884 RVA: 0x00010654 File Offset: 0x0000E854
		private MemoryStream takeOverRequestBuffer()
		{
			if (this._inputStream != null)
			{
				return HttpConnection.createRequestBuffer(this._inputStream);
			}
			MemoryStream memoryStream = new MemoryStream();
			byte[] buffer = this._requestBuffer.GetBuffer();
			int num = (int)this._requestBuffer.Length - this._position;
			if (num > 0)
			{
				memoryStream.Write(buffer, this._position, num);
			}
			this.disposeRequestBuffer();
			return memoryStream;
		}

		// Token: 0x06000375 RID: 885 RVA: 0x000106B4 File Offset: 0x0000E8B4
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

		// Token: 0x06000376 RID: 886 RVA: 0x00010734 File Offset: 0x0000E934
		internal void Close(bool force)
		{
			if (this._socket == null)
			{
				return;
			}
			object sync = this._sync;
			lock (sync)
			{
				if (this._socket != null)
				{
					if (force)
					{
						if (this._outputStream != null)
						{
							this._outputStream.Close(true);
						}
						this.close();
					}
					else
					{
						this.GetResponseStream().Close(false);
						if (this._context.Response.CloseConnection)
						{
							this.close();
						}
						else if (!this._context.Request.FlushInput())
						{
							this.close();
						}
						else
						{
							this._context.Unregister();
							this._reuses++;
							MemoryStream memoryStream = this.takeOverRequestBuffer();
							long length = memoryStream.Length;
							this.init(memoryStream, 15000);
							if (length <= 0L || !this.processRequestBuffer())
							{
								this.BeginReadRequest();
							}
						}
					}
				}
			}
		}

		// Token: 0x06000377 RID: 887 RVA: 0x0001082C File Offset: 0x0000EA2C
		public void Close()
		{
			this.Close(false);
		}

		// Token: 0x06000378 RID: 888 RVA: 0x00010838 File Offset: 0x0000EA38
		public RequestStream GetRequestStream(long contentLength, bool chunked)
		{
			object sync = this._sync;
			RequestStream result;
			lock (sync)
			{
				if (this._socket == null)
				{
					result = null;
				}
				else if (this._inputStream != null)
				{
					result = this._inputStream;
				}
				else
				{
					byte[] buffer = this._requestBuffer.GetBuffer();
					int count = (int)this._requestBuffer.Length - this._position;
					this._inputStream = (chunked ? new ChunkedRequestStream(this._stream, buffer, this._position, count, this._context) : new RequestStream(this._stream, buffer, this._position, count, contentLength));
					this.disposeRequestBuffer();
					result = this._inputStream;
				}
			}
			return result;
		}

		// Token: 0x06000379 RID: 889 RVA: 0x000108FC File Offset: 0x0000EAFC
		public ResponseStream GetResponseStream()
		{
			object sync = this._sync;
			ResponseStream result;
			lock (sync)
			{
				if (this._socket == null)
				{
					result = null;
				}
				else if (this._outputStream != null)
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
			return result;
		}

		// Token: 0x0400012A RID: 298
		private int _attempts;

		// Token: 0x0400012B RID: 299
		private byte[] _buffer;

		// Token: 0x0400012C RID: 300
		private static readonly int _bufferLength = 8192;

		// Token: 0x0400012D RID: 301
		private HttpListenerContext _context;

		// Token: 0x0400012E RID: 302
		private StringBuilder _currentLine;

		// Token: 0x0400012F RID: 303
		private EndPointListener _endPointListener;

		// Token: 0x04000130 RID: 304
		private InputState _inputState;

		// Token: 0x04000131 RID: 305
		private RequestStream _inputStream;

		// Token: 0x04000132 RID: 306
		private LineState _lineState;

		// Token: 0x04000133 RID: 307
		private EndPoint _localEndPoint;

		// Token: 0x04000134 RID: 308
		private static readonly int _maxInputLength = 32768;

		// Token: 0x04000135 RID: 309
		private ResponseStream _outputStream;

		// Token: 0x04000136 RID: 310
		private int _position;

		// Token: 0x04000137 RID: 311
		private EndPoint _remoteEndPoint;

		// Token: 0x04000138 RID: 312
		private MemoryStream _requestBuffer;

		// Token: 0x04000139 RID: 313
		private int _reuses;

		// Token: 0x0400013A RID: 314
		private bool _secure;

		// Token: 0x0400013B RID: 315
		private Socket _socket;

		// Token: 0x0400013C RID: 316
		private Stream _stream;

		// Token: 0x0400013D RID: 317
		private object _sync;

		// Token: 0x0400013E RID: 318
		private int _timeout;

		// Token: 0x0400013F RID: 319
		private Dictionary<int, bool> _timeoutCanceled;

		// Token: 0x04000140 RID: 320
		private Timer _timer;
	}
}
