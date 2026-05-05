using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Unity.Baselib.LowLevel;
using Unity.Collections;
using Unity.Jobs;
using Unity.Services.Qos.Runner;
using UnityEngine;

namespace Unity.Networking.QoS
{
	// Token: 0x02000006 RID: 6
	internal struct QosJob : IQosJob, IJob
	{
		// Token: 0x06000009 RID: 9 RVA: 0x0000214F File Offset: 0x0000034F
		public JobHandle Schedule<T>(JobHandle dependsOn = default(JobHandle)) where T : struct, IJob
		{
			return this.Schedule(dependsOn);
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600000A RID: 10 RVA: 0x0000215D File Offset: 0x0000035D
		public NativeArray<InternalQosResult> QosResults
		{
			get
			{
				return this._qosResults;
			}
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002168 File Offset: 0x00000368
		internal QosJob(IList<UcgQosServer> qosServers, string title, uint requestsPerEndpoint = 5U, ulong timeoutMs = 10000UL, ulong maxWaitMs = 500UL, uint requestsBetweenPause = 10U, uint requestPauseMs = 1U, uint receiveWaitMs = 10U)
		{
			this = default(QosJob);
			this.RequestsPerEndpoint = requestsPerEndpoint;
			this.TimeoutMs = timeoutMs;
			this.MaxWaitMs = maxWaitMs;
			this.RequestsBetweenPause = requestsBetweenPause;
			this.RequestPauseMs = requestPauseMs;
			this.ReceiveWaitMs = receiveWaitMs;
			this.m_AddressIndexes = new NativeHashMap<FixedString64Bytes, int>((qosServers != null) ? qosServers.Count : 0, Allocator.Persistent);
			this.m_QosServers = new NativeArray<QosJob.InternalQosServer>((qosServers != null) ? qosServers.Count : 0, Allocator.Persistent, NativeArrayOptions.ClearMemory);
			if (qosServers != null)
			{
				int num = 0;
				foreach (UcgQosServer ucgQosServer in qosServers)
				{
					NetworkEndPoint remote;
					if (!NetworkEndPoint.TryParse(ucgQosServer.ipv4, ucgQosServer.port, out remote, NetworkFamily.Ipv4))
					{
						Debug.LogError("QosJob: Invalid IP address " + ucgQosServer.ipv4 + " in QoS Servers list");
					}
					else
					{
						QosJob.InternalQosServer server = new QosJob.InternalQosServer(remote, ucgQosServer.BackoffUntilUtc, num);
						if (this.m_AddressIndexes.ContainsKey(server.Address))
						{
							server.FirstIdx = this.m_AddressIndexes[server.Address];
						}
						else
						{
							this.m_AddressIndexes.Add(server.Address, num);
						}
						this.StoreServer(server);
						num++;
					}
				}
				if (num < this.m_QosServers.Length)
				{
					NativeArray<QosJob.InternalQosServer> nativeArray = new NativeArray<QosJob.InternalQosServer>(num, Allocator.Persistent, NativeArrayOptions.ClearMemory);
					this.m_QosServers.GetSubArray(0, nativeArray.Length).CopyTo(nativeArray);
					this.m_QosServers.Dispose();
					this.m_QosServers = nativeArray;
				}
			}
			this._qosResults = new NativeArray<InternalQosResult>(this.m_QosServers.Length, Allocator.Persistent, NativeArrayOptions.ClearMemory);
			byte[] bytes = Encoding.UTF8.GetBytes(title);
			this.m_TitleBytesUtf8 = new NativeArray<byte>(bytes.Length, Allocator.Persistent, NativeArrayOptions.ClearMemory);
			this.m_TitleBytesUtf8.CopyFrom(bytes);
		}

		// Token: 0x0600000C RID: 12 RVA: 0x0000234C File Offset: 0x0000054C
		public void Dispose()
		{
			if (this.m_AddressIndexes.IsCreated)
			{
				this.m_AddressIndexes.Dispose();
			}
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002368 File Offset: 0x00000568
		public void Execute()
		{
			if (this.m_QosServers.Length == 0)
			{
				return;
			}
			this.m_Requests = 0;
			this.m_Responses = 0;
			this.m_JobExpireTimeUtc = DateTime.UtcNow.AddMilliseconds(this.TimeoutMs);
			ValueTuple<Binding.Baselib_Socket_Handle, Binding.Baselib_ErrorCode> valueTuple = QosJob.CreateAndBindSocket();
			Binding.Baselib_Socket_Handle item = valueTuple.Item1;
			Binding.Baselib_ErrorCode item2 = valueTuple.Item2;
			if (item2 != Binding.Baselib_ErrorCode.Success)
			{
				Debug.LogError(string.Format("QosJob: failed to create and bind the local socket (errorcode {0})", item2));
				return;
			}
			this.ProcessServers(item);
			Binding.Baselib_Socket_Close(item);
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000023E4 File Offset: 0x000005E4
		private void ProcessServers(Binding.Baselib_Socket_Handle socketHandle)
		{
			NetworkEndPoint addr = default(NetworkEndPoint);
			foreach (QosJob.InternalQosServer server in this.m_QosServers)
			{
				if (!server.Duplicate)
				{
					this.ProcessServer(server, socketHandle);
					this.RecvQosResponsesTimed(addr, this.m_JobExpireTimeUtc, socketHandle, false);
				}
			}
			DateTime dateTime = DateTime.UtcNow.AddMilliseconds(this.MaxWaitMs);
			if (this.m_JobExpireTimeUtc < dateTime)
			{
				dateTime = this.m_JobExpireTimeUtc;
			}
			string text = this.EnableReceiveWait();
			if (text != "")
			{
				Debug.LogError(text);
				return;
			}
			this.RecvQosResponsesTimed(addr, dateTime, socketHandle, true);
			foreach (QosJob.InternalQosServer internalQosServer in this.m_QosServers)
			{
				InternalQosResult result = internalQosServer.Duplicate ? this._qosResults[internalQosServer.FirstIdx] : this._qosResults[internalQosServer.Idx];
				this.StoreResult(internalQosServer.Idx, result);
			}
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002528 File Offset: 0x00000728
		private void ProcessServer(QosJob.InternalQosServer server, Binding.Baselib_Socket_Handle socketHandle)
		{
			if (QosHelper.ExpiredUtc(this.m_JobExpireTimeUtc))
			{
				Debug.LogWarning("QosJob: not enough time to process " + server.Address + ".");
				return;
			}
			if (DateTime.UtcNow < server.BackoffUntilUtc)
			{
				Debug.LogWarning("QosJob: skipping " + server.Address + " due to backoff restrictions");
				return;
			}
			InternalQosResult result = this._qosResults[server.Idx];
			Binding.Baselib_ErrorCode baselib_ErrorCode = this.SendQosRequests(server, socketHandle, ref result);
			if (baselib_ErrorCode != Binding.Baselib_ErrorCode.Success)
			{
				Debug.LogError(string.Format("QosJob: failed to send to {0} (errorcode {1})", server.Address, baselib_ErrorCode));
			}
			this.StoreResult(server.Idx, result);
		}

		// Token: 0x06000010 RID: 16 RVA: 0x000025D8 File Offset: 0x000007D8
		private Binding.Baselib_ErrorCode SendQosRequests(QosJob.InternalQosServer server, Binding.Baselib_Socket_Handle socketHandle, ref InternalQosResult result)
		{
			QosRequest qosRequest = new QosRequest
			{
				Title = this.m_TitleBytesUtf8.ToArray(),
				Identifier = (ushort)new Random().Next(0, 65535)
			};
			server.RequestIdentifier = qosRequest.Identifier;
			this.StoreServer(server);
			result.RequestsSent = 0U;
			while (!QosHelper.ExpiredUtc(this.m_JobExpireTimeUtc))
			{
				qosRequest.Timestamp = (ulong)(DateTime.UtcNow.Ticks / 10000L);
				qosRequest.Sequence = (byte)result.RequestsSent;
				ValueTuple<uint, int> valueTuple = qosRequest.Send(socketHandle.handle, server.RemoteEndpoint, this.m_JobExpireTimeUtc);
				uint item = valueTuple.Item1;
				int item2 = valueTuple.Item2;
				if (item2 != 0)
				{
					Debug.LogError(string.Format("QosJob: send returned error code {0}, can't continue", (Binding.Baselib_ErrorCode)item2));
					return (Binding.Baselib_ErrorCode)item2;
				}
				if ((ulong)item != (ulong)((long)qosRequest.Length))
				{
					Debug.LogWarning(string.Format("QosJob: sent {0} of {1} bytes, ignoring this request", item, qosRequest.Length));
					result.InvalidRequests += 1U;
				}
				else
				{
					this.m_Requests++;
					result.RequestsSent += 1U;
					if (this.RequestsBetweenPause > 0U && this.RequestPauseMs > 0U && (long)this.m_Requests % (long)((ulong)this.RequestsBetweenPause) == 0L)
					{
						Thread.Sleep((int)this.RequestPauseMs);
					}
				}
				if (result.RequestsSent >= this.RequestsPerEndpoint)
				{
					return Binding.Baselib_ErrorCode.Success;
				}
			}
			Debug.LogWarning(string.Format("QosJob: not enough time to complete {0} sends to {1} ", this.RequestsPerEndpoint - result.RequestsSent, server.Address));
			return Binding.Baselib_ErrorCode.Timeout;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002760 File Offset: 0x00000960
		private void StoreServer(QosJob.InternalQosServer server)
		{
			this.m_QosServers[server.Idx] = server;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002774 File Offset: 0x00000974
		private void StoreResult(int idx, InternalQosResult result)
		{
			this._qosResults[idx] = result;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002783 File Offset: 0x00000983
		private void RecvQosResponsesTimed(NetworkEndPoint addr, DateTime deadline, Binding.Baselib_Socket_Handle socketHandle, bool wait)
		{
			this.RecvQosResponses(addr, deadline, socketHandle, wait);
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002790 File Offset: 0x00000990
		private void RecvQosResponses(NetworkEndPoint addr, DateTime deadline, Binding.Baselib_Socket_Handle socketHandle, bool wait)
		{
			if (this.m_Requests == this.m_Responses)
			{
				return;
			}
			QosResponse qosResponse = new QosResponse();
			InternalQosResult internalQosResult = this._qosResults[0];
			while (this.m_Requests > this.m_Responses)
			{
				if (QosHelper.ExpiredUtc(deadline))
				{
					return;
				}
				int item = qosResponse.Recv(socketHandle.handle, wait, deadline, ref addr).Item1;
				if (item == 0)
				{
					if (!wait)
					{
						return;
					}
				}
				else if (item != -1)
				{
					int num = this.LookupResult(addr, qosResponse, ref internalQosResult);
					if (num >= 0)
					{
						string str = "";
						if (!qosResponse.Verify(internalQosResult.RequestsSent, ref str))
						{
							Debug.LogWarning("QosJob: ignoring response from " + this.m_QosServers[num].Address + " verify failed with " + str);
							internalQosResult.InvalidResponses += 1U;
						}
						else
						{
							this.m_Responses++;
							internalQosResult.ResponsesReceived += 1U;
							internalQosResult.AddAggregateLatency((uint)qosResponse.LatencyMs);
							ValueTuple<FcType, byte> valueTuple = qosResponse.ParseFlowControl();
							if (valueTuple.Item1 != FcType.None && valueTuple.Item2 > internalQosResult.FcUnits)
							{
								internalQosResult.FcType = valueTuple.Item1;
								internalQosResult.FcUnits = valueTuple.Item2;
							}
						}
						this.StoreResult(num, internalQosResult);
					}
				}
			}
		}

		// Token: 0x06000015 RID: 21 RVA: 0x000028D4 File Offset: 0x00000AD4
		private string EnableReceiveWait()
		{
			return "";
		}

		// Token: 0x06000016 RID: 22 RVA: 0x000028DC File Offset: 0x00000ADC
		private int LookupResult(NetworkEndPoint endPoint, QosResponse response, ref InternalQosResult result)
		{
			int num;
			if (!this.m_AddressIndexes.TryGetValue(endPoint.Address, out num))
			{
				Debug.LogWarning("QosJob: ignoring unexpected response from " + endPoint.Address);
				return -1;
			}
			result = this._qosResults[num];
			QosJob.InternalQosServer internalQosServer = this.m_QosServers[num];
			if (response.Identifier != internalQosServer.RequestIdentifier)
			{
				Debug.LogWarning(string.Format("QosJob: invalid identifier from {0} 0x{1:X4} != 0x{2:X4} ignoring", internalQosServer.Address, response.Identifier, internalQosServer.RequestIdentifier));
				result.InvalidResponses += 1U;
				return -1;
			}
			return num;
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002988 File Offset: 0x00000B88
		private unsafe static ValueTuple<Binding.Baselib_Socket_Handle, Binding.Baselib_ErrorCode> CreateAndBindSocket()
		{
			Binding.Baselib_ErrorState baselib_ErrorState = default(Binding.Baselib_ErrorState);
			Binding.Baselib_Socket_Handle item = Binding.Baselib_Socket_Create(Binding.Baselib_NetworkAddress_Family.IPv4, Binding.Baselib_Socket_Protocol.UDP, &baselib_ErrorState);
			if (baselib_ErrorState.code != Binding.Baselib_ErrorCode.Success)
			{
				Debug.LogError(string.Format("QosJob: Unable to create socket {0}", baselib_ErrorState.code));
			}
			return new ValueTuple<Binding.Baselib_Socket_Handle, Binding.Baselib_ErrorCode>(item, baselib_ErrorState.code);
		}

		// Token: 0x0400000C RID: 12
		private uint RequestsPerEndpoint;

		// Token: 0x0400000D RID: 13
		private ulong TimeoutMs;

		// Token: 0x0400000E RID: 14
		private ulong MaxWaitMs;

		// Token: 0x0400000F RID: 15
		private uint RequestsBetweenPause;

		// Token: 0x04000010 RID: 16
		private uint RequestPauseMs;

		// Token: 0x04000011 RID: 17
		private uint ReceiveWaitMs;

		// Token: 0x04000012 RID: 18
		private NativeArray<InternalQosResult> _qosResults;

		// Token: 0x04000013 RID: 19
		[DeallocateOnJobCompletion]
		private NativeArray<QosJob.InternalQosServer> m_QosServers;

		// Token: 0x04000014 RID: 20
		[DeallocateOnJobCompletion]
		private NativeArray<byte> m_TitleBytesUtf8;

		// Token: 0x04000015 RID: 21
		private NativeHashMap<FixedString64Bytes, int> m_AddressIndexes;

		// Token: 0x04000016 RID: 22
		private DateTime m_JobExpireTimeUtc;

		// Token: 0x04000017 RID: 23
		private int m_Requests;

		// Token: 0x04000018 RID: 24
		private int m_Responses;

		// Token: 0x0200007D RID: 125
		private struct InternalQosServer
		{
			// Token: 0x06000262 RID: 610 RVA: 0x00008A0F File Offset: 0x00006C0F
			public InternalQosServer(NetworkEndPoint remote, DateTime backoffUntilUtc, int idx)
			{
				this.RemoteEndpoint = remote;
				this.BackoffUntilUtc = backoffUntilUtc;
				this.Idx = idx;
				this.m_FirstIdx = idx;
				this.m_RequestIdentifier = 0;
			}

			// Token: 0x1700008D RID: 141
			// (get) Token: 0x06000263 RID: 611 RVA: 0x00008A34 File Offset: 0x00006C34
			// (set) Token: 0x06000264 RID: 612 RVA: 0x00008A3C File Offset: 0x00006C3C
			public int FirstIdx
			{
				get
				{
					return this.m_FirstIdx;
				}
				set
				{
					this.m_FirstIdx = value;
				}
			}

			// Token: 0x1700008E RID: 142
			// (get) Token: 0x06000265 RID: 613 RVA: 0x00008A45 File Offset: 0x00006C45
			// (set) Token: 0x06000266 RID: 614 RVA: 0x00008A4D File Offset: 0x00006C4D
			public ushort RequestIdentifier
			{
				get
				{
					return this.m_RequestIdentifier;
				}
				set
				{
					this.m_RequestIdentifier = value;
				}
			}

			// Token: 0x1700008F RID: 143
			// (get) Token: 0x06000267 RID: 615 RVA: 0x00008A56 File Offset: 0x00006C56
			public bool Duplicate
			{
				get
				{
					return this.m_FirstIdx != this.Idx;
				}
			}

			// Token: 0x17000090 RID: 144
			// (get) Token: 0x06000268 RID: 616 RVA: 0x00008A6C File Offset: 0x00006C6C
			public string Address
			{
				get
				{
					return this.RemoteEndpoint.Address;
				}
			}

			// Token: 0x040000FC RID: 252
			public readonly NetworkEndPoint RemoteEndpoint;

			// Token: 0x040000FD RID: 253
			public readonly DateTime BackoffUntilUtc;

			// Token: 0x040000FE RID: 254
			public readonly int Idx;

			// Token: 0x040000FF RID: 255
			private int m_FirstIdx;

			// Token: 0x04000100 RID: 256
			private ushort m_RequestIdentifier;
		}
	}
}
