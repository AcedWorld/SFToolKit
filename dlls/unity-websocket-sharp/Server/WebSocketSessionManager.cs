using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Timers;

namespace UnityWebSocketSharp.Server
{
	// Token: 0x02000022 RID: 34
	internal class WebSocketSessionManager
	{
		// Token: 0x0600025C RID: 604 RVA: 0x0000B86C File Offset: 0x00009A6C
		internal WebSocketSessionManager(Logger log)
		{
			this._log = log;
			this._forSweep = new object();
			this._keepClean = true;
			this._sessions = new Dictionary<string, IWebSocketSession>();
			this._state = ServerState.Ready;
			this._sync = ((ICollection)this._sessions).SyncRoot;
			this._waitTime = TimeSpan.FromSeconds(1.0);
			this.setSweepTimer(60000.0);
		}

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x0600025D RID: 605 RVA: 0x0000B8E2 File Offset: 0x00009AE2
		internal ServerState State
		{
			get
			{
				return this._state;
			}
		}

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x0600025E RID: 606 RVA: 0x0000B8EC File Offset: 0x00009AEC
		public IEnumerable<string> ActiveIDs
		{
			get
			{
				foreach (KeyValuePair<string, bool> keyValuePair in this.broadping(WebSocketSessionManager._rawEmptyPingFrame))
				{
					if (keyValuePair.Value)
					{
						yield return keyValuePair.Key;
					}
				}
				Dictionary<string, bool>.Enumerator enumerator = default(Dictionary<string, bool>.Enumerator);
				yield break;
				yield break;
			}
		}

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x0600025F RID: 607 RVA: 0x0000B8FC File Offset: 0x00009AFC
		public int Count
		{
			get
			{
				object sync = this._sync;
				int count;
				lock (sync)
				{
					count = this._sessions.Count;
				}
				return count;
			}
		}

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x06000260 RID: 608 RVA: 0x0000B944 File Offset: 0x00009B44
		public IEnumerable<string> IDs
		{
			get
			{
				if (this._state != ServerState.Start)
				{
					return Enumerable.Empty<string>();
				}
				object sync = this._sync;
				IEnumerable<string> result;
				lock (sync)
				{
					if (this._state != ServerState.Start)
					{
						result = Enumerable.Empty<string>();
					}
					else
					{
						result = this._sessions.Keys.ToList<string>();
					}
				}
				return result;
			}
		}

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x06000261 RID: 609 RVA: 0x0000B9B4 File Offset: 0x00009BB4
		public IEnumerable<string> InactiveIDs
		{
			get
			{
				foreach (KeyValuePair<string, bool> keyValuePair in this.broadping(WebSocketSessionManager._rawEmptyPingFrame))
				{
					if (!keyValuePair.Value)
					{
						yield return keyValuePair.Key;
					}
				}
				Dictionary<string, bool>.Enumerator enumerator = default(Dictionary<string, bool>.Enumerator);
				yield break;
				yield break;
			}
		}

		// Token: 0x170000A3 RID: 163
		public IWebSocketSession this[string id]
		{
			get
			{
				if (id == null)
				{
					throw new ArgumentNullException("id");
				}
				if (id.Length == 0)
				{
					throw new ArgumentException("An empty string.", "id");
				}
				IWebSocketSession result;
				this.tryGetSession(id, out result);
				return result;
			}
		}

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x06000263 RID: 611 RVA: 0x0000BA02 File Offset: 0x00009C02
		// (set) Token: 0x06000264 RID: 612 RVA: 0x0000BA0C File Offset: 0x00009C0C
		public bool KeepClean
		{
			get
			{
				return this._keepClean;
			}
			set
			{
				object sync = this._sync;
				lock (sync)
				{
					if (this.canSet())
					{
						this._keepClean = value;
					}
				}
			}
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x06000265 RID: 613 RVA: 0x0000BA5C File Offset: 0x00009C5C
		public IEnumerable<IWebSocketSession> Sessions
		{
			get
			{
				if (this._state != ServerState.Start)
				{
					return Enumerable.Empty<IWebSocketSession>();
				}
				object sync = this._sync;
				IEnumerable<IWebSocketSession> result;
				lock (sync)
				{
					if (this._state != ServerState.Start)
					{
						result = Enumerable.Empty<IWebSocketSession>();
					}
					else
					{
						result = this._sessions.Values.ToList<IWebSocketSession>();
					}
				}
				return result;
			}
		}

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x06000266 RID: 614 RVA: 0x0000BACC File Offset: 0x00009CCC
		// (set) Token: 0x06000267 RID: 615 RVA: 0x0000BAD4 File Offset: 0x00009CD4
		public TimeSpan WaitTime
		{
			get
			{
				return this._waitTime;
			}
			set
			{
				if (value <= TimeSpan.Zero)
				{
					string message = "Zero or less.";
					throw new ArgumentOutOfRangeException("value", message);
				}
				object sync = this._sync;
				lock (sync)
				{
					if (this.canSet())
					{
						this._waitTime = value;
					}
				}
			}
		}

		// Token: 0x06000268 RID: 616 RVA: 0x0000BB40 File Offset: 0x00009D40
		private void broadcast(Opcode opcode, byte[] data, Action completed)
		{
			Dictionary<CompressionMethod, byte[]> dictionary = new Dictionary<CompressionMethod, byte[]>();
			try
			{
				foreach (IWebSocketSession webSocketSession in this.Sessions)
				{
					if (this._state != ServerState.Start)
					{
						this._log.Error("The send is cancelled.");
						break;
					}
					webSocketSession.WebSocket.Send(opcode, data, dictionary);
				}
				if (completed != null)
				{
					completed();
				}
			}
			catch (Exception ex)
			{
				this._log.Error(ex.Message);
				this._log.Debug(ex.ToString());
			}
			finally
			{
				dictionary.Clear();
			}
		}

		// Token: 0x06000269 RID: 617 RVA: 0x0000BC08 File Offset: 0x00009E08
		private void broadcast(Opcode opcode, Stream sourceStream, Action completed)
		{
			Dictionary<CompressionMethod, Stream> dictionary = new Dictionary<CompressionMethod, Stream>();
			try
			{
				foreach (IWebSocketSession webSocketSession in this.Sessions)
				{
					if (this._state != ServerState.Start)
					{
						this._log.Error("The send is cancelled.");
						break;
					}
					webSocketSession.WebSocket.Send(opcode, sourceStream, dictionary);
				}
				if (completed != null)
				{
					completed();
				}
			}
			catch (Exception ex)
			{
				this._log.Error(ex.Message);
				this._log.Debug(ex.ToString());
			}
			finally
			{
				foreach (Stream stream in dictionary.Values)
				{
					stream.Dispose();
				}
				dictionary.Clear();
			}
		}

		// Token: 0x0600026A RID: 618 RVA: 0x0000BD10 File Offset: 0x00009F10
		private void broadcastAsync(Opcode opcode, byte[] data, Action completed)
		{
			ThreadPool.QueueUserWorkItem(delegate(object state)
			{
				this.broadcast(opcode, data, completed);
			});
		}

		// Token: 0x0600026B RID: 619 RVA: 0x0000BD44 File Offset: 0x00009F44
		private void broadcastAsync(Opcode opcode, Stream sourceStream, Action completed)
		{
			ThreadPool.QueueUserWorkItem(delegate(object state)
			{
				this.broadcast(opcode, sourceStream, completed);
			});
		}

		// Token: 0x0600026C RID: 620 RVA: 0x0000BD78 File Offset: 0x00009F78
		private Dictionary<string, bool> broadping(byte[] rawFrame)
		{
			Dictionary<string, bool> dictionary = new Dictionary<string, bool>();
			foreach (IWebSocketSession webSocketSession in this.Sessions)
			{
				if (this._state != ServerState.Start)
				{
					dictionary.Clear();
					break;
				}
				bool value = webSocketSession.WebSocket.Ping(rawFrame);
				dictionary.Add(webSocketSession.ID, value);
			}
			return dictionary;
		}

		// Token: 0x0600026D RID: 621 RVA: 0x0000BDF4 File Offset: 0x00009FF4
		private bool canSet()
		{
			return this._state == ServerState.Ready || this._state == ServerState.Stop;
		}

		// Token: 0x0600026E RID: 622 RVA: 0x0000BE10 File Offset: 0x0000A010
		private static string createID()
		{
			return Guid.NewGuid().ToString("N");
		}

		// Token: 0x0600026F RID: 623 RVA: 0x0000BE2F File Offset: 0x0000A02F
		private void setSweepTimer(double interval)
		{
			this._sweepTimer = new Timer(interval);
			this._sweepTimer.Elapsed += delegate(object sender, ElapsedEventArgs e)
			{
				this.Sweep();
			};
		}

		// Token: 0x06000270 RID: 624 RVA: 0x0000BE54 File Offset: 0x0000A054
		private void stop(PayloadData payloadData, bool send)
		{
			byte[] rawFrame = send ? WebSocketFrame.CreateCloseFrame(payloadData, false).ToArray() : null;
			object sync = this._sync;
			lock (sync)
			{
				this._state = ServerState.ShuttingDown;
				this._sweepTimer.Enabled = false;
				foreach (IWebSocketSession webSocketSession in this._sessions.Values.ToList<IWebSocketSession>())
				{
					webSocketSession.WebSocket.Close(payloadData, rawFrame);
				}
				this._state = ServerState.Stop;
			}
		}

		// Token: 0x06000271 RID: 625 RVA: 0x0000BF10 File Offset: 0x0000A110
		private bool tryGetSession(string id, out IWebSocketSession session)
		{
			session = null;
			if (this._state != ServerState.Start)
			{
				return false;
			}
			object sync = this._sync;
			bool result;
			lock (sync)
			{
				if (this._state != ServerState.Start)
				{
					result = false;
				}
				else
				{
					result = this._sessions.TryGetValue(id, out session);
				}
			}
			return result;
		}

		// Token: 0x06000272 RID: 626 RVA: 0x0000BF78 File Offset: 0x0000A178
		internal string Add(IWebSocketSession session)
		{
			object sync = this._sync;
			string result;
			lock (sync)
			{
				if (this._state != ServerState.Start)
				{
					result = null;
				}
				else
				{
					string text = WebSocketSessionManager.createID();
					this._sessions.Add(text, session);
					result = text;
				}
			}
			return result;
		}

		// Token: 0x06000273 RID: 627 RVA: 0x0000BFD8 File Offset: 0x0000A1D8
		internal bool Remove(string id)
		{
			object sync = this._sync;
			bool result;
			lock (sync)
			{
				result = this._sessions.Remove(id);
			}
			return result;
		}

		// Token: 0x06000274 RID: 628 RVA: 0x0000C020 File Offset: 0x0000A220
		internal void Start()
		{
			object sync = this._sync;
			lock (sync)
			{
				this._sweepTimer.Enabled = this._keepClean;
				this._state = ServerState.Start;
			}
		}

		// Token: 0x06000275 RID: 629 RVA: 0x0000C078 File Offset: 0x0000A278
		internal void Stop(ushort code, string reason)
		{
			if (code == 1005)
			{
				this.stop(PayloadData.Empty, true);
				return;
			}
			PayloadData payloadData = new PayloadData(code, reason);
			bool send = !code.IsReservedStatusCode();
			this.stop(payloadData, send);
		}

		// Token: 0x06000276 RID: 630 RVA: 0x0000C0B4 File Offset: 0x0000A2B4
		public void Broadcast(byte[] data)
		{
			if (this._state != ServerState.Start)
			{
				throw new InvalidOperationException("The current state of the service is not Start.");
			}
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			if ((long)data.Length <= (long)WebSocket.FragmentLength)
			{
				this.broadcast(Opcode.Binary, data, null);
				return;
			}
			this.broadcast(Opcode.Binary, new MemoryStream(data), null);
		}

		// Token: 0x06000277 RID: 631 RVA: 0x0000C108 File Offset: 0x0000A308
		public void Broadcast(string data)
		{
			if (this._state != ServerState.Start)
			{
				throw new InvalidOperationException("The current state of the service is not Start.");
			}
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			byte[] array;
			if (!data.TryGetUTF8EncodedBytes(out array))
			{
				throw new ArgumentException("It could not be UTF-8-encoded.", "data");
			}
			if ((long)array.Length <= (long)WebSocket.FragmentLength)
			{
				this.broadcast(Opcode.Text, array, null);
				return;
			}
			this.broadcast(Opcode.Text, new MemoryStream(array), null);
		}

		// Token: 0x06000278 RID: 632 RVA: 0x0000C178 File Offset: 0x0000A378
		public void Broadcast(Stream stream, int length)
		{
			if (this._state != ServerState.Start)
			{
				throw new InvalidOperationException("The current state of the service is not Start.");
			}
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			if (!stream.CanRead)
			{
				throw new ArgumentException("It cannot be read.", "stream");
			}
			if (length < 1)
			{
				throw new ArgumentException("Less than 1.", "length");
			}
			byte[] array = stream.ReadBytes(length);
			int num = array.Length;
			if (num == 0)
			{
				throw new ArgumentException("No data could be read from it.", "stream");
			}
			if (num < length)
			{
				string message = string.Format("Only {0} byte(s) of data could be read from the stream.", num);
				this._log.Warn(message);
			}
			if (num <= WebSocket.FragmentLength)
			{
				this.broadcast(Opcode.Binary, array, null);
				return;
			}
			this.broadcast(Opcode.Binary, new MemoryStream(array), null);
		}

		// Token: 0x06000279 RID: 633 RVA: 0x0000C238 File Offset: 0x0000A438
		public void BroadcastAsync(byte[] data, Action completed)
		{
			if (this._state != ServerState.Start)
			{
				throw new InvalidOperationException("The current state of the service is not Start.");
			}
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			if ((long)data.Length <= (long)WebSocket.FragmentLength)
			{
				this.broadcastAsync(Opcode.Binary, data, completed);
				return;
			}
			this.broadcastAsync(Opcode.Binary, new MemoryStream(data), completed);
		}

		// Token: 0x0600027A RID: 634 RVA: 0x0000C28C File Offset: 0x0000A48C
		public void BroadcastAsync(string data, Action completed)
		{
			if (this._state != ServerState.Start)
			{
				throw new InvalidOperationException("The current state of the service is not Start.");
			}
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			byte[] array;
			if (!data.TryGetUTF8EncodedBytes(out array))
			{
				throw new ArgumentException("It could not be UTF-8-encoded.", "data");
			}
			if ((long)array.Length <= (long)WebSocket.FragmentLength)
			{
				this.broadcastAsync(Opcode.Text, array, completed);
				return;
			}
			this.broadcastAsync(Opcode.Text, new MemoryStream(array), completed);
		}

		// Token: 0x0600027B RID: 635 RVA: 0x0000C2FC File Offset: 0x0000A4FC
		public void BroadcastAsync(Stream stream, int length, Action completed)
		{
			if (this._state != ServerState.Start)
			{
				throw new InvalidOperationException("The current state of the service is not Start.");
			}
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			if (!stream.CanRead)
			{
				throw new ArgumentException("It cannot be read.", "stream");
			}
			if (length < 1)
			{
				throw new ArgumentException("Less than 1.", "length");
			}
			byte[] array = stream.ReadBytes(length);
			int num = array.Length;
			if (num == 0)
			{
				throw new ArgumentException("No data could be read from it.", "stream");
			}
			if (num < length)
			{
				string message = string.Format("Only {0} byte(s) of data could be read from the stream.", num);
				this._log.Warn(message);
			}
			if (num <= WebSocket.FragmentLength)
			{
				this.broadcastAsync(Opcode.Binary, array, completed);
				return;
			}
			this.broadcastAsync(Opcode.Binary, new MemoryStream(array), completed);
		}

		// Token: 0x0600027C RID: 636 RVA: 0x0000C3BC File Offset: 0x0000A5BC
		public void CloseSession(string id)
		{
			IWebSocketSession webSocketSession;
			if (!this.TryGetSession(id, out webSocketSession))
			{
				throw new InvalidOperationException("The session could not be found.");
			}
			webSocketSession.WebSocket.Close();
		}

		// Token: 0x0600027D RID: 637 RVA: 0x0000C3EC File Offset: 0x0000A5EC
		public void CloseSession(string id, ushort code, string reason)
		{
			IWebSocketSession webSocketSession;
			if (!this.TryGetSession(id, out webSocketSession))
			{
				throw new InvalidOperationException("The session could not be found.");
			}
			webSocketSession.WebSocket.Close(code, reason);
		}

		// Token: 0x0600027E RID: 638 RVA: 0x0000C41C File Offset: 0x0000A61C
		public void CloseSession(string id, CloseStatusCode code, string reason)
		{
			IWebSocketSession webSocketSession;
			if (!this.TryGetSession(id, out webSocketSession))
			{
				throw new InvalidOperationException("The session could not be found.");
			}
			webSocketSession.WebSocket.Close(code, reason);
		}

		// Token: 0x0600027F RID: 639 RVA: 0x0000C44C File Offset: 0x0000A64C
		public bool PingTo(string id)
		{
			IWebSocketSession webSocketSession;
			if (!this.TryGetSession(id, out webSocketSession))
			{
				throw new InvalidOperationException("The session could not be found.");
			}
			return webSocketSession.WebSocket.Ping();
		}

		// Token: 0x06000280 RID: 640 RVA: 0x0000C47C File Offset: 0x0000A67C
		public bool PingTo(string message, string id)
		{
			IWebSocketSession webSocketSession;
			if (!this.TryGetSession(id, out webSocketSession))
			{
				throw new InvalidOperationException("The session could not be found.");
			}
			return webSocketSession.WebSocket.Ping(message);
		}

		// Token: 0x06000281 RID: 641 RVA: 0x0000C4AC File Offset: 0x0000A6AC
		public void SendTo(byte[] data, string id)
		{
			IWebSocketSession webSocketSession;
			if (!this.TryGetSession(id, out webSocketSession))
			{
				throw new InvalidOperationException("The session could not be found.");
			}
			webSocketSession.WebSocket.Send(data);
		}

		// Token: 0x06000282 RID: 642 RVA: 0x0000C4DC File Offset: 0x0000A6DC
		public void SendTo(string data, string id)
		{
			IWebSocketSession webSocketSession;
			if (!this.TryGetSession(id, out webSocketSession))
			{
				throw new InvalidOperationException("The session could not be found.");
			}
			webSocketSession.WebSocket.Send(data);
		}

		// Token: 0x06000283 RID: 643 RVA: 0x0000C50C File Offset: 0x0000A70C
		public void SendTo(Stream stream, int length, string id)
		{
			IWebSocketSession webSocketSession;
			if (!this.TryGetSession(id, out webSocketSession))
			{
				throw new InvalidOperationException("The session could not be found.");
			}
			webSocketSession.WebSocket.Send(stream, length);
		}

		// Token: 0x06000284 RID: 644 RVA: 0x0000C53C File Offset: 0x0000A73C
		public void SendToAsync(byte[] data, string id, Action<bool> completed)
		{
			IWebSocketSession webSocketSession;
			if (!this.TryGetSession(id, out webSocketSession))
			{
				throw new InvalidOperationException("The session could not be found.");
			}
			webSocketSession.WebSocket.SendAsync(data, completed);
		}

		// Token: 0x06000285 RID: 645 RVA: 0x0000C56C File Offset: 0x0000A76C
		public void SendToAsync(string data, string id, Action<bool> completed)
		{
			IWebSocketSession webSocketSession;
			if (!this.TryGetSession(id, out webSocketSession))
			{
				throw new InvalidOperationException("The session could not be found.");
			}
			webSocketSession.WebSocket.SendAsync(data, completed);
		}

		// Token: 0x06000286 RID: 646 RVA: 0x0000C59C File Offset: 0x0000A79C
		public void SendToAsync(Stream stream, int length, string id, Action<bool> completed)
		{
			IWebSocketSession webSocketSession;
			if (!this.TryGetSession(id, out webSocketSession))
			{
				throw new InvalidOperationException("The session could not be found.");
			}
			webSocketSession.WebSocket.SendAsync(stream, length, completed);
		}

		// Token: 0x06000287 RID: 647 RVA: 0x0000C5D0 File Offset: 0x0000A7D0
		public void Sweep()
		{
			if (this._sweeping)
			{
				this._log.Trace("The sweep process is already in progress.");
				return;
			}
			object obj = this._forSweep;
			lock (obj)
			{
				if (this._sweeping)
				{
					this._log.Trace("The sweep process is already in progress.");
					return;
				}
				this._sweeping = true;
			}
			foreach (string key in this.InactiveIDs)
			{
				if (this._state != ServerState.Start)
				{
					break;
				}
				obj = this._sync;
				lock (obj)
				{
					if (this._state != ServerState.Start)
					{
						break;
					}
					IWebSocketSession webSocketSession;
					if (this._sessions.TryGetValue(key, out webSocketSession))
					{
						WebSocketState readyState = webSocketSession.WebSocket.ReadyState;
						if (readyState == WebSocketState.Open)
						{
							webSocketSession.WebSocket.Close(CloseStatusCode.Abnormal);
						}
						else if (readyState != WebSocketState.Closing)
						{
							this._sessions.Remove(key);
						}
					}
				}
			}
			this._sweeping = false;
		}

		// Token: 0x06000288 RID: 648 RVA: 0x0000C724 File Offset: 0x0000A924
		public bool TryGetSession(string id, out IWebSocketSession session)
		{
			if (id == null)
			{
				throw new ArgumentNullException("id");
			}
			if (id.Length == 0)
			{
				throw new ArgumentException("An empty string.", "id");
			}
			return this.tryGetSession(id, out session);
		}

		// Token: 0x040000DD RID: 221
		private object _forSweep;

		// Token: 0x040000DE RID: 222
		private volatile bool _keepClean;

		// Token: 0x040000DF RID: 223
		private Logger _log;

		// Token: 0x040000E0 RID: 224
		private static readonly byte[] _rawEmptyPingFrame = WebSocketFrame.CreatePingFrame(false).ToArray();

		// Token: 0x040000E1 RID: 225
		private Dictionary<string, IWebSocketSession> _sessions;

		// Token: 0x040000E2 RID: 226
		private volatile ServerState _state;

		// Token: 0x040000E3 RID: 227
		private volatile bool _sweeping;

		// Token: 0x040000E4 RID: 228
		private Timer _sweepTimer;

		// Token: 0x040000E5 RID: 229
		private object _sync;

		// Token: 0x040000E6 RID: 230
		private TimeSpan _waitTime;
	}
}
