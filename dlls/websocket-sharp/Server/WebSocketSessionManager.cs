using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Timers;

namespace WebSocketSharp.Server
{
	// Token: 0x0200004A RID: 74
	public class WebSocketSessionManager
	{
		// Token: 0x060004E3 RID: 1251 RVA: 0x0001BC48 File Offset: 0x00019E48
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

		// Token: 0x17000180 RID: 384
		// (get) Token: 0x060004E4 RID: 1252 RVA: 0x0001BCC4 File Offset: 0x00019EC4
		internal ServerState State
		{
			get
			{
				return this._state;
			}
		}

		// Token: 0x17000181 RID: 385
		// (get) Token: 0x060004E5 RID: 1253 RVA: 0x0001BCE0 File Offset: 0x00019EE0
		public IEnumerable<string> ActiveIDs
		{
			get
			{
				foreach (KeyValuePair<string, bool> res in this.broadping(WebSocketFrame.EmptyPingBytes))
				{
					bool value = res.Value;
					if (value)
					{
						yield return res.Key;
					}
					res = default(KeyValuePair<string, bool>);
				}
				Dictionary<string, bool>.Enumerator enumerator = default(Dictionary<string, bool>.Enumerator);
				yield break;
				yield break;
			}
		}

		// Token: 0x17000182 RID: 386
		// (get) Token: 0x060004E6 RID: 1254 RVA: 0x0001BD00 File Offset: 0x00019F00
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

		// Token: 0x17000183 RID: 387
		// (get) Token: 0x060004E7 RID: 1255 RVA: 0x0001BD4C File Offset: 0x00019F4C
		public IEnumerable<string> IDs
		{
			get
			{
				bool flag = this._state != ServerState.Start;
				IEnumerable<string> result;
				if (flag)
				{
					result = Enumerable.Empty<string>();
				}
				else
				{
					object sync = this._sync;
					lock (sync)
					{
						bool flag3 = this._state != ServerState.Start;
						if (flag3)
						{
							result = Enumerable.Empty<string>();
						}
						else
						{
							result = this._sessions.Keys.ToList<string>();
						}
					}
				}
				return result;
			}
		}

		// Token: 0x17000184 RID: 388
		// (get) Token: 0x060004E8 RID: 1256 RVA: 0x0001BDD4 File Offset: 0x00019FD4
		public IEnumerable<string> InactiveIDs
		{
			get
			{
				foreach (KeyValuePair<string, bool> res in this.broadping(WebSocketFrame.EmptyPingBytes))
				{
					bool flag = !res.Value;
					if (flag)
					{
						yield return res.Key;
					}
					res = default(KeyValuePair<string, bool>);
				}
				Dictionary<string, bool>.Enumerator enumerator = default(Dictionary<string, bool>.Enumerator);
				yield break;
				yield break;
			}
		}

		// Token: 0x17000185 RID: 389
		public IWebSocketSession this[string id]
		{
			get
			{
				bool flag = id == null;
				if (flag)
				{
					throw new ArgumentNullException("id");
				}
				bool flag2 = id.Length == 0;
				if (flag2)
				{
					throw new ArgumentException("An empty string.", "id");
				}
				IWebSocketSession result;
				this.tryGetSession(id, out result);
				return result;
			}
		}

		// Token: 0x17000186 RID: 390
		// (get) Token: 0x060004EA RID: 1258 RVA: 0x0001BE44 File Offset: 0x0001A044
		// (set) Token: 0x060004EB RID: 1259 RVA: 0x0001BE60 File Offset: 0x0001A060
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
					bool flag2 = !this.canSet();
					if (!flag2)
					{
						this._keepClean = value;
					}
				}
			}
		}

		// Token: 0x17000187 RID: 391
		// (get) Token: 0x060004EC RID: 1260 RVA: 0x0001BEB8 File Offset: 0x0001A0B8
		public IEnumerable<IWebSocketSession> Sessions
		{
			get
			{
				bool flag = this._state != ServerState.Start;
				IEnumerable<IWebSocketSession> result;
				if (flag)
				{
					result = Enumerable.Empty<IWebSocketSession>();
				}
				else
				{
					object sync = this._sync;
					lock (sync)
					{
						bool flag3 = this._state != ServerState.Start;
						if (flag3)
						{
							result = Enumerable.Empty<IWebSocketSession>();
						}
						else
						{
							result = this._sessions.Values.ToList<IWebSocketSession>();
						}
					}
				}
				return result;
			}
		}

		// Token: 0x17000188 RID: 392
		// (get) Token: 0x060004ED RID: 1261 RVA: 0x0001BF40 File Offset: 0x0001A140
		// (set) Token: 0x060004EE RID: 1262 RVA: 0x0001BF58 File Offset: 0x0001A158
		public TimeSpan WaitTime
		{
			get
			{
				return this._waitTime;
			}
			set
			{
				bool flag = value <= TimeSpan.Zero;
				if (flag)
				{
					string message = "It is zero or less.";
					throw new ArgumentOutOfRangeException("value", message);
				}
				object sync = this._sync;
				lock (sync)
				{
					bool flag3 = !this.canSet();
					if (!flag3)
					{
						this._waitTime = value;
					}
				}
			}
		}

		// Token: 0x060004EF RID: 1263 RVA: 0x0001BFD4 File Offset: 0x0001A1D4
		private void broadcast(Opcode opcode, byte[] data, Action completed)
		{
			Dictionary<CompressionMethod, byte[]> dictionary = new Dictionary<CompressionMethod, byte[]>();
			try
			{
				foreach (IWebSocketSession webSocketSession in this.Sessions)
				{
					bool flag = this._state != ServerState.Start;
					if (flag)
					{
						this._log.Error("The service is shutting down.");
						break;
					}
					webSocketSession.Context.WebSocket.Send(opcode, data, dictionary);
				}
				bool flag2 = completed != null;
				if (flag2)
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

		// Token: 0x060004F0 RID: 1264 RVA: 0x0001C0C4 File Offset: 0x0001A2C4
		private void broadcast(Opcode opcode, Stream stream, Action completed)
		{
			Dictionary<CompressionMethod, Stream> dictionary = new Dictionary<CompressionMethod, Stream>();
			try
			{
				foreach (IWebSocketSession webSocketSession in this.Sessions)
				{
					bool flag = this._state != ServerState.Start;
					if (flag)
					{
						this._log.Error("The service is shutting down.");
						break;
					}
					webSocketSession.Context.WebSocket.Send(opcode, stream, dictionary);
				}
				bool flag2 = completed != null;
				if (flag2)
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
				foreach (Stream stream2 in dictionary.Values)
				{
					stream2.Dispose();
				}
				dictionary.Clear();
			}
		}

		// Token: 0x060004F1 RID: 1265 RVA: 0x0001C1FC File Offset: 0x0001A3FC
		private void broadcastAsync(Opcode opcode, byte[] data, Action completed)
		{
			ThreadPool.QueueUserWorkItem(delegate(object state)
			{
				this.broadcast(opcode, data, completed);
			});
		}

		// Token: 0x060004F2 RID: 1266 RVA: 0x0001C240 File Offset: 0x0001A440
		private void broadcastAsync(Opcode opcode, Stream stream, Action completed)
		{
			ThreadPool.QueueUserWorkItem(delegate(object state)
			{
				this.broadcast(opcode, stream, completed);
			});
		}

		// Token: 0x060004F3 RID: 1267 RVA: 0x0001C284 File Offset: 0x0001A484
		private Dictionary<string, bool> broadping(byte[] frameAsBytes)
		{
			Dictionary<string, bool> dictionary = new Dictionary<string, bool>();
			foreach (IWebSocketSession webSocketSession in this.Sessions)
			{
				bool flag = this._state != ServerState.Start;
				if (flag)
				{
					this._log.Error("The service is shutting down.");
					break;
				}
				bool value = webSocketSession.Context.WebSocket.Ping(frameAsBytes, this._waitTime);
				dictionary.Add(webSocketSession.ID, value);
			}
			return dictionary;
		}

		// Token: 0x060004F4 RID: 1268 RVA: 0x0001C32C File Offset: 0x0001A52C
		private bool canSet()
		{
			return this._state == ServerState.Ready || this._state == ServerState.Stop;
		}

		// Token: 0x060004F5 RID: 1269 RVA: 0x0001C358 File Offset: 0x0001A558
		private static string createID()
		{
			return Guid.NewGuid().ToString("N");
		}

		// Token: 0x060004F6 RID: 1270 RVA: 0x0001C37C File Offset: 0x0001A57C
		private void setSweepTimer(double interval)
		{
			this._sweepTimer = new System.Timers.Timer(interval);
			this._sweepTimer.Elapsed += delegate(object sender, ElapsedEventArgs e)
			{
				this.Sweep();
			};
		}

		// Token: 0x060004F7 RID: 1271 RVA: 0x0001C3A4 File Offset: 0x0001A5A4
		private void stop(PayloadData payloadData, bool send)
		{
			byte[] frameAsBytes = send ? WebSocketFrame.CreateCloseFrame(payloadData, false).ToArray() : null;
			object sync = this._sync;
			lock (sync)
			{
				this._state = ServerState.ShuttingDown;
				this._sweepTimer.Enabled = false;
				foreach (IWebSocketSession webSocketSession in this._sessions.Values.ToList<IWebSocketSession>())
				{
					webSocketSession.Context.WebSocket.Close(payloadData, frameAsBytes);
				}
				this._state = ServerState.Stop;
			}
		}

		// Token: 0x060004F8 RID: 1272 RVA: 0x0001C474 File Offset: 0x0001A674
		private bool tryGetSession(string id, out IWebSocketSession session)
		{
			session = null;
			bool flag = this._state != ServerState.Start;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				object sync = this._sync;
				lock (sync)
				{
					bool flag3 = this._state != ServerState.Start;
					if (flag3)
					{
						result = false;
					}
					else
					{
						result = this._sessions.TryGetValue(id, out session);
					}
				}
			}
			return result;
		}

		// Token: 0x060004F9 RID: 1273 RVA: 0x0001C4F4 File Offset: 0x0001A6F4
		internal string Add(IWebSocketSession session)
		{
			object sync = this._sync;
			string result;
			lock (sync)
			{
				bool flag2 = this._state != ServerState.Start;
				if (flag2)
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

		// Token: 0x060004FA RID: 1274 RVA: 0x0001C564 File Offset: 0x0001A764
		internal void Broadcast(Opcode opcode, byte[] data, Dictionary<CompressionMethod, byte[]> cache)
		{
			foreach (IWebSocketSession webSocketSession in this.Sessions)
			{
				bool flag = this._state != ServerState.Start;
				if (flag)
				{
					this._log.Error("The service is shutting down.");
					break;
				}
				webSocketSession.Context.WebSocket.Send(opcode, data, cache);
			}
		}

		// Token: 0x060004FB RID: 1275 RVA: 0x0001C5EC File Offset: 0x0001A7EC
		internal void Broadcast(Opcode opcode, Stream stream, Dictionary<CompressionMethod, Stream> cache)
		{
			foreach (IWebSocketSession webSocketSession in this.Sessions)
			{
				bool flag = this._state != ServerState.Start;
				if (flag)
				{
					this._log.Error("The service is shutting down.");
					break;
				}
				webSocketSession.Context.WebSocket.Send(opcode, stream, cache);
			}
		}

		// Token: 0x060004FC RID: 1276 RVA: 0x0001C674 File Offset: 0x0001A874
		internal Dictionary<string, bool> Broadping(byte[] frameAsBytes, TimeSpan timeout)
		{
			Dictionary<string, bool> dictionary = new Dictionary<string, bool>();
			foreach (IWebSocketSession webSocketSession in this.Sessions)
			{
				bool flag = this._state != ServerState.Start;
				if (flag)
				{
					this._log.Error("The service is shutting down.");
					break;
				}
				bool value = webSocketSession.Context.WebSocket.Ping(frameAsBytes, timeout);
				dictionary.Add(webSocketSession.ID, value);
			}
			return dictionary;
		}

		// Token: 0x060004FD RID: 1277 RVA: 0x0001C718 File Offset: 0x0001A918
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

		// Token: 0x060004FE RID: 1278 RVA: 0x0001C764 File Offset: 0x0001A964
		internal void Start()
		{
			object sync = this._sync;
			lock (sync)
			{
				this._sweepTimer.Enabled = this._keepClean;
				this._state = ServerState.Start;
			}
		}

		// Token: 0x060004FF RID: 1279 RVA: 0x0001C7C0 File Offset: 0x0001A9C0
		internal void Stop(ushort code, string reason)
		{
			bool flag = code == 1005;
			if (flag)
			{
				this.stop(PayloadData.Empty, true);
			}
			else
			{
				this.stop(new PayloadData(code, reason), !code.IsReserved());
			}
		}

		// Token: 0x06000500 RID: 1280 RVA: 0x0001C804 File Offset: 0x0001AA04
		public void Broadcast(byte[] data)
		{
			bool flag = this._state != ServerState.Start;
			if (flag)
			{
				string message = "The current state of the service is not Start.";
				throw new InvalidOperationException(message);
			}
			bool flag2 = data == null;
			if (flag2)
			{
				throw new ArgumentNullException("data");
			}
			bool flag3 = (long)data.Length <= (long)WebSocket.FragmentLength;
			if (flag3)
			{
				this.broadcast(Opcode.Binary, data, null);
			}
			else
			{
				this.broadcast(Opcode.Binary, new MemoryStream(data), null);
			}
		}

		// Token: 0x06000501 RID: 1281 RVA: 0x0001C874 File Offset: 0x0001AA74
		public void Broadcast(string data)
		{
			bool flag = this._state != ServerState.Start;
			if (flag)
			{
				string message = "The current state of the service is not Start.";
				throw new InvalidOperationException(message);
			}
			bool flag2 = data == null;
			if (flag2)
			{
				throw new ArgumentNullException("data");
			}
			byte[] array;
			bool flag3 = !data.TryGetUTF8EncodedBytes(out array);
			if (flag3)
			{
				string message2 = "It could not be UTF-8-encoded.";
				throw new ArgumentException(message2, "data");
			}
			bool flag4 = (long)array.Length <= (long)WebSocket.FragmentLength;
			if (flag4)
			{
				this.broadcast(Opcode.Text, array, null);
			}
			else
			{
				this.broadcast(Opcode.Text, new MemoryStream(array), null);
			}
		}

		// Token: 0x06000502 RID: 1282 RVA: 0x0001C90C File Offset: 0x0001AB0C
		public void Broadcast(Stream stream, int length)
		{
			bool flag = this._state != ServerState.Start;
			if (flag)
			{
				string message = "The current state of the service is not Start.";
				throw new InvalidOperationException(message);
			}
			bool flag2 = stream == null;
			if (flag2)
			{
				throw new ArgumentNullException("stream");
			}
			bool flag3 = !stream.CanRead;
			if (flag3)
			{
				string message2 = "It cannot be read.";
				throw new ArgumentException(message2, "stream");
			}
			bool flag4 = length < 1;
			if (flag4)
			{
				string message3 = "It is less than 1.";
				throw new ArgumentException(message3, "length");
			}
			byte[] array = stream.ReadBytes(length);
			int num = array.Length;
			bool flag5 = num == 0;
			if (flag5)
			{
				string message4 = "No data could be read from it.";
				throw new ArgumentException(message4, "stream");
			}
			bool flag6 = num < length;
			if (flag6)
			{
				string format = "Only {0} byte(s) of data could be read from the stream.";
				string message5 = string.Format(format, num);
				this._log.Warn(message5);
			}
			bool flag7 = num <= WebSocket.FragmentLength;
			if (flag7)
			{
				this.broadcast(Opcode.Binary, array, null);
			}
			else
			{
				this.broadcast(Opcode.Binary, new MemoryStream(array), null);
			}
		}

		// Token: 0x06000503 RID: 1283 RVA: 0x0001CA1C File Offset: 0x0001AC1C
		public void BroadcastAsync(byte[] data, Action completed)
		{
			bool flag = this._state != ServerState.Start;
			if (flag)
			{
				string message = "The current state of the service is not Start.";
				throw new InvalidOperationException(message);
			}
			bool flag2 = data == null;
			if (flag2)
			{
				throw new ArgumentNullException("data");
			}
			bool flag3 = (long)data.Length <= (long)WebSocket.FragmentLength;
			if (flag3)
			{
				this.broadcastAsync(Opcode.Binary, data, completed);
			}
			else
			{
				this.broadcastAsync(Opcode.Binary, new MemoryStream(data), completed);
			}
		}

		// Token: 0x06000504 RID: 1284 RVA: 0x0001CA8C File Offset: 0x0001AC8C
		public void BroadcastAsync(string data, Action completed)
		{
			bool flag = this._state != ServerState.Start;
			if (flag)
			{
				string message = "The current state of the service is not Start.";
				throw new InvalidOperationException(message);
			}
			bool flag2 = data == null;
			if (flag2)
			{
				throw new ArgumentNullException("data");
			}
			byte[] array;
			bool flag3 = !data.TryGetUTF8EncodedBytes(out array);
			if (flag3)
			{
				string message2 = "It could not be UTF-8-encoded.";
				throw new ArgumentException(message2, "data");
			}
			bool flag4 = (long)array.Length <= (long)WebSocket.FragmentLength;
			if (flag4)
			{
				this.broadcastAsync(Opcode.Text, array, completed);
			}
			else
			{
				this.broadcastAsync(Opcode.Text, new MemoryStream(array), completed);
			}
		}

		// Token: 0x06000505 RID: 1285 RVA: 0x0001CB24 File Offset: 0x0001AD24
		public void BroadcastAsync(Stream stream, int length, Action completed)
		{
			bool flag = this._state != ServerState.Start;
			if (flag)
			{
				string message = "The current state of the service is not Start.";
				throw new InvalidOperationException(message);
			}
			bool flag2 = stream == null;
			if (flag2)
			{
				throw new ArgumentNullException("stream");
			}
			bool flag3 = !stream.CanRead;
			if (flag3)
			{
				string message2 = "It cannot be read.";
				throw new ArgumentException(message2, "stream");
			}
			bool flag4 = length < 1;
			if (flag4)
			{
				string message3 = "It is less than 1.";
				throw new ArgumentException(message3, "length");
			}
			byte[] array = stream.ReadBytes(length);
			int num = array.Length;
			bool flag5 = num == 0;
			if (flag5)
			{
				string message4 = "No data could be read from it.";
				throw new ArgumentException(message4, "stream");
			}
			bool flag6 = num < length;
			if (flag6)
			{
				string format = "Only {0} byte(s) of data could be read from the stream.";
				string message5 = string.Format(format, num);
				this._log.Warn(message5);
			}
			bool flag7 = num <= WebSocket.FragmentLength;
			if (flag7)
			{
				this.broadcastAsync(Opcode.Binary, array, completed);
			}
			else
			{
				this.broadcastAsync(Opcode.Binary, new MemoryStream(array), completed);
			}
		}

		// Token: 0x06000506 RID: 1286 RVA: 0x0001CC34 File Offset: 0x0001AE34
		public void CloseSession(string id)
		{
			IWebSocketSession webSocketSession;
			bool flag = !this.TryGetSession(id, out webSocketSession);
			if (flag)
			{
				string message = "The session could not be found.";
				throw new InvalidOperationException(message);
			}
			webSocketSession.Context.WebSocket.Close();
		}

		// Token: 0x06000507 RID: 1287 RVA: 0x0001CC74 File Offset: 0x0001AE74
		public void CloseSession(string id, ushort code, string reason)
		{
			IWebSocketSession webSocketSession;
			bool flag = !this.TryGetSession(id, out webSocketSession);
			if (flag)
			{
				string message = "The session could not be found.";
				throw new InvalidOperationException(message);
			}
			webSocketSession.Context.WebSocket.Close(code, reason);
		}

		// Token: 0x06000508 RID: 1288 RVA: 0x0001CCB4 File Offset: 0x0001AEB4
		public void CloseSession(string id, CloseStatusCode code, string reason)
		{
			IWebSocketSession webSocketSession;
			bool flag = !this.TryGetSession(id, out webSocketSession);
			if (flag)
			{
				string message = "The session could not be found.";
				throw new InvalidOperationException(message);
			}
			webSocketSession.Context.WebSocket.Close(code, reason);
		}

		// Token: 0x06000509 RID: 1289 RVA: 0x0001CCF4 File Offset: 0x0001AEF4
		public bool PingTo(string id)
		{
			IWebSocketSession webSocketSession;
			bool flag = !this.TryGetSession(id, out webSocketSession);
			if (flag)
			{
				string message = "The session could not be found.";
				throw new InvalidOperationException(message);
			}
			return webSocketSession.Context.WebSocket.Ping();
		}

		// Token: 0x0600050A RID: 1290 RVA: 0x0001CD34 File Offset: 0x0001AF34
		public bool PingTo(string message, string id)
		{
			IWebSocketSession webSocketSession;
			bool flag = !this.TryGetSession(id, out webSocketSession);
			if (flag)
			{
				string message2 = "The session could not be found.";
				throw new InvalidOperationException(message2);
			}
			return webSocketSession.Context.WebSocket.Ping(message);
		}

		// Token: 0x0600050B RID: 1291 RVA: 0x0001CD78 File Offset: 0x0001AF78
		public void SendTo(byte[] data, string id)
		{
			IWebSocketSession webSocketSession;
			bool flag = !this.TryGetSession(id, out webSocketSession);
			if (flag)
			{
				string message = "The session could not be found.";
				throw new InvalidOperationException(message);
			}
			webSocketSession.Context.WebSocket.Send(data);
		}

		// Token: 0x0600050C RID: 1292 RVA: 0x0001CDB8 File Offset: 0x0001AFB8
		public void SendTo(string data, string id)
		{
			IWebSocketSession webSocketSession;
			bool flag = !this.TryGetSession(id, out webSocketSession);
			if (flag)
			{
				string message = "The session could not be found.";
				throw new InvalidOperationException(message);
			}
			webSocketSession.Context.WebSocket.Send(data);
		}

		// Token: 0x0600050D RID: 1293 RVA: 0x0001CDF8 File Offset: 0x0001AFF8
		public void SendTo(Stream stream, int length, string id)
		{
			IWebSocketSession webSocketSession;
			bool flag = !this.TryGetSession(id, out webSocketSession);
			if (flag)
			{
				string message = "The session could not be found.";
				throw new InvalidOperationException(message);
			}
			webSocketSession.Context.WebSocket.Send(stream, length);
		}

		// Token: 0x0600050E RID: 1294 RVA: 0x0001CE38 File Offset: 0x0001B038
		public void SendToAsync(byte[] data, string id, Action<bool> completed)
		{
			IWebSocketSession webSocketSession;
			bool flag = !this.TryGetSession(id, out webSocketSession);
			if (flag)
			{
				string message = "The session could not be found.";
				throw new InvalidOperationException(message);
			}
			webSocketSession.Context.WebSocket.SendAsync(data, completed);
		}

		// Token: 0x0600050F RID: 1295 RVA: 0x0001CE78 File Offset: 0x0001B078
		public void SendToAsync(string data, string id, Action<bool> completed)
		{
			IWebSocketSession webSocketSession;
			bool flag = !this.TryGetSession(id, out webSocketSession);
			if (flag)
			{
				string message = "The session could not be found.";
				throw new InvalidOperationException(message);
			}
			webSocketSession.Context.WebSocket.SendAsync(data, completed);
		}

		// Token: 0x06000510 RID: 1296 RVA: 0x0001CEB8 File Offset: 0x0001B0B8
		public void SendToAsync(Stream stream, int length, string id, Action<bool> completed)
		{
			IWebSocketSession webSocketSession;
			bool flag = !this.TryGetSession(id, out webSocketSession);
			if (flag)
			{
				string message = "The session could not be found.";
				throw new InvalidOperationException(message);
			}
			webSocketSession.Context.WebSocket.SendAsync(stream, length, completed);
		}

		// Token: 0x06000511 RID: 1297 RVA: 0x0001CEFC File Offset: 0x0001B0FC
		public void Sweep()
		{
			bool sweeping = this._sweeping;
			if (sweeping)
			{
				this._log.Info("The sweeping is already in progress.");
			}
			else
			{
				object forSweep = this._forSweep;
				lock (forSweep)
				{
					bool sweeping2 = this._sweeping;
					if (sweeping2)
					{
						this._log.Info("The sweeping is already in progress.");
						return;
					}
					this._sweeping = true;
				}
				foreach (string key in this.InactiveIDs)
				{
					bool flag2 = this._state != ServerState.Start;
					if (flag2)
					{
						break;
					}
					object sync = this._sync;
					lock (sync)
					{
						bool flag4 = this._state != ServerState.Start;
						if (flag4)
						{
							break;
						}
						IWebSocketSession webSocketSession;
						bool flag5 = this._sessions.TryGetValue(key, out webSocketSession);
						if (flag5)
						{
							WebSocketState connectionState = webSocketSession.ConnectionState;
							bool flag6 = connectionState == WebSocketState.Open;
							if (flag6)
							{
								webSocketSession.Context.WebSocket.Close(CloseStatusCode.Abnormal);
							}
							else
							{
								bool flag7 = connectionState == WebSocketState.Closing;
								if (!flag7)
								{
									this._sessions.Remove(key);
								}
							}
						}
					}
				}
				this._sweeping = false;
			}
		}

		// Token: 0x06000512 RID: 1298 RVA: 0x0001D098 File Offset: 0x0001B298
		public bool TryGetSession(string id, out IWebSocketSession session)
		{
			bool flag = id == null;
			if (flag)
			{
				throw new ArgumentNullException("id");
			}
			bool flag2 = id.Length == 0;
			if (flag2)
			{
				throw new ArgumentException("An empty string.", "id");
			}
			return this.tryGetSession(id, out session);
		}

		// Token: 0x0400023D RID: 573
		private object _forSweep;

		// Token: 0x0400023E RID: 574
		private volatile bool _keepClean;

		// Token: 0x0400023F RID: 575
		private Logger _log;

		// Token: 0x04000240 RID: 576
		private Dictionary<string, IWebSocketSession> _sessions;

		// Token: 0x04000241 RID: 577
		private volatile ServerState _state;

		// Token: 0x04000242 RID: 578
		private volatile bool _sweeping;

		// Token: 0x04000243 RID: 579
		private System.Timers.Timer _sweepTimer;

		// Token: 0x04000244 RID: 580
		private object _sync;

		// Token: 0x04000245 RID: 581
		private TimeSpan _waitTime;
	}
}
