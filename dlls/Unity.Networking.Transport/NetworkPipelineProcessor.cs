using System;
using System.Diagnostics;
using System.Threading;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace Unity.Networking.Transport
{
	// Token: 0x02000055 RID: 85
	internal struct NetworkPipelineProcessor : IDisposable
	{
		// Token: 0x060001A1 RID: 417 RVA: 0x00008D02 File Offset: 0x00006F02
		public int PayloadCapacity(NetworkPipeline pipeline)
		{
			if (pipeline.Id > 0)
			{
				return this.m_Pipelines[pipeline.Id - 1].payloadCapacity;
			}
			return 0;
		}

		// Token: 0x060001A2 RID: 418 RVA: 0x00008D28 File Offset: 0x00006F28
		public NetworkPipelineProcessor.Concurrent ToConcurrent()
		{
			return new NetworkPipelineProcessor.Concurrent
			{
				m_StageCollection = this.m_StageCollection,
				m_StaticInstanceBuffer = this.m_StaticInstanceBuffer,
				m_Pipelines = this.m_Pipelines,
				m_StageList = this.m_StageList,
				m_AccumulatedHeaderCapacity = this.m_AccumulatedHeaderCapacity,
				m_SendStageNeedsUpdateWrite = this.m_SendStageNeedsUpdateRead.AsParallelWriter(),
				sizePerConnection = this.sizePerConnection,
				sendBuffer = this.m_SendBuffer,
				sharedBuffer = this.m_SharedBuffer,
				m_timestamp = this.m_timestamp
			};
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x00008DC8 File Offset: 0x00006FC8
		public unsafe NetworkPipelineProcessor(NetworkSettings settings)
		{
			NetworkPipelineParams pipelineParameters = ref settings.GetPipelineParameters();
			int num = 0;
			for (int i = 0; i < NetworkPipelineStageCollection.m_stages.Count; i++)
			{
				num += NetworkPipelineStageCollection.m_stages[i].StaticSize;
				num = (num + 15 & -16);
			}
			this.m_StaticInstanceBuffer = new NativeArray<byte>(num, Allocator.Persistent, NativeArrayOptions.ClearMemory);
			this.m_StageCollection = new NativeArray<NetworkPipelineStage>(NetworkPipelineStageCollection.m_stages.Count, Allocator.Persistent, NativeArrayOptions.ClearMemory);
			num = 0;
			for (int j = 0; j < NetworkPipelineStageCollection.m_stages.Count; j++)
			{
				NetworkPipelineStage value = NetworkPipelineStageCollection.m_stages[j].StaticInitialize((byte*)this.m_StaticInstanceBuffer.GetUnsafePtr<byte>() + num, NetworkPipelineStageCollection.m_stages[j].StaticSize, settings);
				value.StaticStateStart = num;
				value.StaticStateCapcity = NetworkPipelineStageCollection.m_stages[j].StaticSize;
				this.m_StageCollection[j] = value;
				num += NetworkPipelineStageCollection.m_stages[j].StaticSize;
				num = (num + 15 & -16);
			}
			this.m_StageList = new NativeList<int>(16, Allocator.Persistent);
			this.m_AccumulatedHeaderCapacity = new NativeList<int>(16, Allocator.Persistent);
			this.m_Pipelines = new NativeList<NetworkPipelineProcessor.PipelineImpl>(16, Allocator.Persistent);
			this.m_ReceiveBuffer = new NativeList<byte>(pipelineParameters.initialCapacity, Allocator.Persistent);
			this.m_SendBuffer = new NativeList<byte>(pipelineParameters.initialCapacity, Allocator.Persistent);
			this.m_SharedBuffer = new NativeList<byte>(pipelineParameters.initialCapacity, Allocator.Persistent);
			this.sizePerConnection = new NativeArray<int>(3, Allocator.Persistent, NativeArrayOptions.ClearMemory);
			this.sizePerConnection[0] = 8;
			this.m_ReceiveStageNeedsUpdate = new NativeList<NetworkPipelineProcessor.UpdatePipeline>(128, Allocator.Persistent);
			this.m_SendStageNeedsUpdate = new NativeList<NetworkPipelineProcessor.UpdatePipeline>(128, Allocator.Persistent);
			this.m_SendStageNeedsUpdateRead = new NativeQueue<NetworkPipelineProcessor.UpdatePipeline>(Allocator.Persistent);
			this.m_timestamp = new NativeArray<long>(1, Allocator.Persistent, NativeArrayOptions.ClearMemory);
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x00008FAC File Offset: 0x000071AC
		public void Dispose()
		{
			this.m_StageList.Dispose();
			this.m_AccumulatedHeaderCapacity.Dispose();
			this.m_ReceiveBuffer.Dispose();
			this.m_SendBuffer.Dispose();
			this.m_SharedBuffer.Dispose();
			this.m_Pipelines.Dispose();
			this.sizePerConnection.Dispose();
			this.m_ReceiveStageNeedsUpdate.Dispose();
			this.m_SendStageNeedsUpdate.Dispose();
			this.m_SendStageNeedsUpdateRead.Dispose();
			this.m_timestamp.Dispose();
			this.m_StageCollection.Dispose();
			this.m_StaticInstanceBuffer.Dispose();
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x060001A5 RID: 421 RVA: 0x00009048 File Offset: 0x00007248
		// (set) Token: 0x060001A6 RID: 422 RVA: 0x00009056 File Offset: 0x00007256
		public long Timestamp
		{
			get
			{
				return this.m_timestamp[0];
			}
			internal set
			{
				this.m_timestamp[0] = value;
			}
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x00009068 File Offset: 0x00007268
		public unsafe void initializeConnection(NetworkConnection con)
		{
			int num = (con.m_NetworkId + 1) * this.sizePerConnection[1];
			int num2 = (con.m_NetworkId + 1) * this.sizePerConnection[0];
			int num3 = (con.m_NetworkId + 1) * this.sizePerConnection[2];
			if (this.m_ReceiveBuffer.Length < num)
			{
				this.m_ReceiveBuffer.ResizeUninitialized(num);
			}
			if (this.m_SendBuffer.Length < num2)
			{
				this.m_SendBuffer.ResizeUninitialized(num2);
			}
			if (this.m_SharedBuffer.Length < num3)
			{
				this.m_SharedBuffer.ResizeUninitialized(num3);
			}
			UnsafeUtility.MemClear((void*)((byte*)this.m_ReceiveBuffer.GetUnsafePtr<byte>() + con.m_NetworkId * this.sizePerConnection[1]), (long)this.sizePerConnection[1]);
			UnsafeUtility.MemClear((void*)((byte*)this.m_SendBuffer.GetUnsafePtr<byte>() + con.m_NetworkId * this.sizePerConnection[0]), (long)this.sizePerConnection[0]);
			UnsafeUtility.MemClear((void*)((byte*)this.m_SharedBuffer.GetUnsafePtr<byte>() + con.m_NetworkId * this.sizePerConnection[2]), (long)this.sizePerConnection[2]);
			this.InitializeStages(con.m_NetworkId);
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x000091A4 File Offset: 0x000073A4
		private unsafe void InitializeStages(int networkId)
		{
			for (int i = 0; i < this.m_Pipelines.Length; i++)
			{
				NetworkPipelineProcessor.PipelineImpl pipelineImpl = this.m_Pipelines[i];
				int num = pipelineImpl.receiveBufferOffset + this.sizePerConnection[1] * networkId;
				int num2 = pipelineImpl.sendBufferOffset + this.sizePerConnection[0] * networkId;
				int num3 = pipelineImpl.sharedBufferOffset + this.sizePerConnection[2] * networkId;
				for (int j = pipelineImpl.FirstStageIndex; j < pipelineImpl.FirstStageIndex + pipelineImpl.NumStages; j++)
				{
					NetworkPipelineStage networkPipelineStage = this.m_StageCollection[this.m_StageList[j]];
					byte* sendProcessBuffer = (byte*)this.m_SendBuffer.GetUnsafePtr<byte>() + num2;
					int sendCapacity = networkPipelineStage.SendCapacity;
					byte* recvProcessBuffer = (byte*)this.m_ReceiveBuffer.GetUnsafePtr<byte>() + num;
					int receiveCapacity = networkPipelineStage.ReceiveCapacity;
					byte* sharedProcessBuffer = (byte*)this.m_SharedBuffer.GetUnsafePtr<byte>() + num3;
					int sharedStateCapacity = networkPipelineStage.SharedStateCapacity;
					byte* staticInstanceBuffer = (byte*)this.m_StaticInstanceBuffer.GetUnsafePtr<byte>() + networkPipelineStage.StaticStateStart;
					int staticStateCapcity = networkPipelineStage.StaticStateCapcity;
					networkPipelineStage.InitializeConnection.Ptr.Invoke(staticInstanceBuffer, staticStateCapcity, sendProcessBuffer, sendCapacity, recvProcessBuffer, receiveCapacity, sharedProcessBuffer, sharedStateCapacity);
					num2 += (sendCapacity + 7 & -8);
					num += (receiveCapacity + 7 & -8);
					num3 += (sharedStateCapacity + 7 & -8);
				}
			}
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x00009314 File Offset: 0x00007514
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		private void ValidateStages(params Type[] stages)
		{
			int num = Array.IndexOf<Type>(stages, typeof(ReliableSequencedPipelineStage));
			int num2 = Array.IndexOf<Type>(stages, typeof(FragmentationPipelineStage));
			if (num >= 0 && num2 >= 0 && num2 > num)
			{
				throw new InvalidOperationException("Cannot create pipeline with ReliableSequenced followed by Fragmentation stage. Should reverse their order.");
			}
		}

		// Token: 0x060001AA RID: 426 RVA: 0x0000935C File Offset: 0x0000755C
		public NetworkPipeline CreatePipeline(params Type[] stages)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			NetworkPipelineProcessor.PipelineImpl pipelineImpl = default(NetworkPipelineProcessor.PipelineImpl);
			pipelineImpl.FirstStageIndex = this.m_StageList.Length;
			pipelineImpl.NumStages = stages.Length;
			for (int i = 0; i < stages.Length; i++)
			{
				int index = NetworkPipelineStageCollection.GetStageId(stages[i]).Index;
				this.m_StageList.Add(index);
				this.m_AccumulatedHeaderCapacity.Add(num4);
				num += (this.m_StageCollection[index].ReceiveCapacity + 7 & -8);
				num3 += (this.m_StageCollection[index].SendCapacity + 7 & -8);
				num4 += this.m_StageCollection[index].HeaderCapacity;
				num2 += (this.m_StageCollection[index].SharedStateCapacity + 7 & -8);
				if (num5 == 0)
				{
					num5 = this.m_StageCollection[index].PayloadCapacity;
				}
			}
			pipelineImpl.receiveBufferOffset = this.sizePerConnection[1];
			this.sizePerConnection[1] = this.sizePerConnection[1] + num;
			pipelineImpl.sendBufferOffset = this.sizePerConnection[0];
			this.sizePerConnection[0] = this.sizePerConnection[0] + num3;
			pipelineImpl.sharedBufferOffset = this.sizePerConnection[2];
			this.sizePerConnection[2] = this.sizePerConnection[2] + num2;
			pipelineImpl.headerCapacity = num4;
			pipelineImpl.payloadCapacity = num5;
			this.m_Pipelines.Add(pipelineImpl);
			return new NetworkPipeline
			{
				Id = this.m_Pipelines.Length
			};
		}

		// Token: 0x060001AB RID: 427 RVA: 0x00009518 File Offset: 0x00007718
		public void GetPipelineBuffers(NetworkPipeline pipelineId, NetworkPipelineStageId stageId, NetworkConnection connection, out NativeArray<byte> readProcessingBuffer, out NativeArray<byte> writeProcessingBuffer, out NativeArray<byte> sharedBuffer)
		{
			if (pipelineId.Id < 1 || stageId.IsValid == 0)
			{
				writeProcessingBuffer = default(NativeArray<byte>);
				readProcessingBuffer = default(NativeArray<byte>);
				sharedBuffer = default(NativeArray<byte>);
				return;
			}
			NetworkPipelineProcessor.PipelineImpl pipelineImpl = this.m_Pipelines[pipelineId.Id - 1];
			int num = pipelineImpl.receiveBufferOffset + this.sizePerConnection[1] * connection.InternalId;
			int num2 = pipelineImpl.sendBufferOffset + this.sizePerConnection[0] * connection.InternalId;
			int num3 = pipelineImpl.sharedBufferOffset + this.sizePerConnection[2] * connection.InternalId;
			bool flag = true;
			int i;
			for (i = pipelineImpl.FirstStageIndex; i < pipelineImpl.FirstStageIndex + pipelineImpl.NumStages; i++)
			{
				if (this.m_StageList[i] == stageId.Index)
				{
					flag = false;
					break;
				}
				num2 += (this.m_StageCollection[this.m_StageList[i]].SendCapacity + 7 & -8);
				num += (this.m_StageCollection[this.m_StageList[i]].ReceiveCapacity + 7 & -8);
				num3 += (this.m_StageCollection[this.m_StageList[i]].SharedStateCapacity + 7 & -8);
			}
			if (flag)
			{
				writeProcessingBuffer = default(NativeArray<byte>);
				readProcessingBuffer = default(NativeArray<byte>);
				sharedBuffer = default(NativeArray<byte>);
				return;
			}
			writeProcessingBuffer = this.m_SendBuffer.GetSubArray(num2, this.m_StageCollection[this.m_StageList[i]].SendCapacity);
			readProcessingBuffer = this.m_ReceiveBuffer.GetSubArray(num, this.m_StageCollection[this.m_StageList[i]].ReceiveCapacity);
			sharedBuffer = this.m_SharedBuffer.GetSubArray(num3, this.m_StageCollection[this.m_StageList[i]].SharedStateCapacity);
		}

		// Token: 0x060001AC RID: 428 RVA: 0x00009738 File Offset: 0x00007938
		internal unsafe void UpdateSend(NetworkDriver.Concurrent driver, out int updateCount)
		{
			int* unsafePtr = (int*)this.m_SendBuffer.GetUnsafePtr<byte>();
			for (int i = 0; i < this.m_SendBuffer.Length; i += this.sizePerConnection[0])
			{
				unsafePtr[i / 4] = 0;
			}
			NativeList<NetworkPipelineProcessor.UpdatePipeline> currentUpdates = new NativeList<NetworkPipelineProcessor.UpdatePipeline>(this.m_SendStageNeedsUpdateRead.Count + this.m_SendStageNeedsUpdate.Length, Allocator.Temp);
			NetworkPipelineProcessor.UpdatePipeline updatePipeline;
			while (this.m_SendStageNeedsUpdateRead.TryDequeue(out updatePipeline))
			{
				if (driver.GetConnectionState(updatePipeline.connection) == NetworkConnection.State.Connected)
				{
					NetworkPipelineProcessor.AddSendUpdate(updatePipeline.connection, updatePipeline.stage, updatePipeline.pipeline, currentUpdates);
				}
			}
			for (int j = 0; j < this.m_SendStageNeedsUpdate.Length; j++)
			{
				updatePipeline = this.m_SendStageNeedsUpdate[j];
				if (driver.GetConnectionState(this.m_SendStageNeedsUpdate[j].connection) == NetworkConnection.State.Connected)
				{
					NetworkPipelineProcessor.AddSendUpdate(updatePipeline.connection, updatePipeline.stage, updatePipeline.pipeline, currentUpdates);
				}
			}
			updateCount = currentUpdates.Length;
			NativeList<NetworkPipelineProcessor.UpdatePipeline> currentUpdates2 = new NativeList<NetworkPipelineProcessor.UpdatePipeline>(128, Allocator.Temp);
			for (int k = 0; k < updateCount; k++)
			{
				updatePipeline = currentUpdates[k];
				int num = this.ToConcurrent().ProcessPipelineSend(driver, updatePipeline.stage, updatePipeline.pipeline, updatePipeline.connection, default(NetworkInterfaceSendHandle), 0, currentUpdates2);
				if (num < 0)
				{
					Debug.LogWarning(FixedString.Format("ProcessPipelineSend failed with the following error code {0}.", num));
				}
			}
			for (int l = 0; l < currentUpdates2.Length; l++)
			{
				this.m_SendStageNeedsUpdateRead.Enqueue(currentUpdates2[l]);
			}
		}

		// Token: 0x060001AD RID: 429 RVA: 0x000098F0 File Offset: 0x00007AF0
		private static void AddSendUpdate(NetworkConnection connection, int stageId, NetworkPipeline pipelineId, NativeList<NetworkPipelineProcessor.UpdatePipeline> currentUpdates)
		{
			NetworkPipelineProcessor.UpdatePipeline updatePipeline = new NetworkPipelineProcessor.UpdatePipeline
			{
				connection = connection,
				stage = stageId,
				pipeline = pipelineId
			};
			bool flag = true;
			for (int i = 0; i < currentUpdates.Length; i++)
			{
				if (currentUpdates[i].stage == updatePipeline.stage && currentUpdates[i].pipeline.Id == updatePipeline.pipeline.Id && currentUpdates[i].connection == updatePipeline.connection)
				{
					flag = false;
				}
			}
			if (flag)
			{
				currentUpdates.Add(updatePipeline);
			}
		}

		// Token: 0x060001AE RID: 430 RVA: 0x00009990 File Offset: 0x00007B90
		public void UpdateReceive(NetworkDriver driver, out int updateCount)
		{
			NativeArray<NetworkPipelineProcessor.UpdatePipeline> nativeArray = new NativeArray<NetworkPipelineProcessor.UpdatePipeline>(this.m_ReceiveStageNeedsUpdate.Length, Allocator.Temp, NativeArrayOptions.ClearMemory);
			updateCount = 0;
			for (int i = 0; i < this.m_ReceiveStageNeedsUpdate.Length; i++)
			{
				if (driver.GetConnectionState(this.m_ReceiveStageNeedsUpdate[i].connection) == NetworkConnection.State.Connected)
				{
					int num = updateCount;
					updateCount = num + 1;
					nativeArray[num] = this.m_ReceiveStageNeedsUpdate[i];
				}
			}
			this.m_ReceiveStageNeedsUpdate.Clear();
			for (int j = 0; j < updateCount; j++)
			{
				NetworkPipelineProcessor.UpdatePipeline updatePipeline = nativeArray[j];
				this.ProcessReceiveStagesFrom(driver, updatePipeline.stage, updatePipeline.pipeline, updatePipeline.connection, default(InboundRecvBuffer));
			}
		}

		// Token: 0x060001AF RID: 431 RVA: 0x00009A4C File Offset: 0x00007C4C
		public unsafe void Receive(NetworkDriver driver, NetworkConnection connection, NativeArray<byte> buffer)
		{
			byte b = buffer[0];
			if (b == 0 || (int)b > this.m_Pipelines.Length)
			{
				Debug.LogError("Received a packet with an invalid pipeline.");
				return;
			}
			int startStage = this.m_Pipelines[(int)(b - 1)].NumStages - 1;
			InboundRecvBuffer buffer2;
			buffer2.buffer = (byte*)buffer.GetUnsafePtr<byte>() + 1;
			buffer2.bufferLength = buffer.Length - 1;
			this.ProcessReceiveStagesFrom(driver, startStage, new NetworkPipeline
			{
				Id = (int)b
			}, connection, buffer2);
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x00009AD0 File Offset: 0x00007CD0
		private void ProcessReceiveStagesFrom(NetworkDriver driver, int startStage, NetworkPipeline pipeline, NetworkConnection connection, InboundRecvBuffer buffer)
		{
			NetworkPipelineProcessor.PipelineImpl pipelineImpl = this.m_Pipelines[pipeline.Id - 1];
			int networkId = connection.m_NetworkId;
			NativeList<int> nativeList = new NativeList<int>(16, Allocator.Temp);
			int num = 0;
			int systemHeadersSize = driver.MaxProtocolHeaderSize();
			InboundRecvBuffer inboundRecvBuffer = buffer;
			NetworkPipelineContext networkPipelineContext = new NetworkPipelineContext
			{
				timestamp = this.Timestamp,
				header = default(DataStreamWriter)
			};
			for (;;)
			{
				bool flag = false;
				bool flag2 = false;
				int num2 = pipelineImpl.receiveBufferOffset + this.sizePerConnection[1] * networkId;
				int num3 = pipelineImpl.sharedBufferOffset + this.sizePerConnection[2] * networkId;
				for (int i = 0; i < startStage; i++)
				{
					num2 += (this.m_StageCollection[this.m_StageList[pipelineImpl.FirstStageIndex + i]].ReceiveCapacity + 7 & -8);
					num3 += (this.m_StageCollection[this.m_StageList[pipelineImpl.FirstStageIndex + i]].SharedStateCapacity + 7 & -8);
				}
				for (int j = startStage; j >= 0; j--)
				{
					this.ProcessReceiveStage(j, pipeline, num2, num3, ref networkPipelineContext, ref inboundRecvBuffer, ref nativeList, ref flag, ref flag2, systemHeadersSize);
					if (flag)
					{
						NetworkPipelineProcessor.UpdatePipeline updatePipeline = new NetworkPipelineProcessor.UpdatePipeline
						{
							connection = connection,
							stage = j,
							pipeline = pipeline
						};
						bool flag3 = true;
						for (int k = 0; k < this.m_ReceiveStageNeedsUpdate.Length; k++)
						{
							if (this.m_ReceiveStageNeedsUpdate[k].stage == updatePipeline.stage && this.m_ReceiveStageNeedsUpdate[k].pipeline.Id == updatePipeline.pipeline.Id && this.m_ReceiveStageNeedsUpdate[k].connection == updatePipeline.connection)
							{
								flag3 = false;
							}
						}
						if (flag3)
						{
							this.m_ReceiveStageNeedsUpdate.Add(updatePipeline);
						}
					}
					if (flag2)
					{
						NetworkPipelineProcessor.AddSendUpdate(connection, j, pipeline, this.m_SendStageNeedsUpdate);
					}
					if (inboundRecvBuffer.bufferLength == 0)
					{
						break;
					}
					if (j > 0)
					{
						num2 -= (this.m_StageCollection[this.m_StageList[pipelineImpl.FirstStageIndex + j - 1]].ReceiveCapacity + 7 & -8);
						num3 -= (this.m_StageCollection[this.m_StageList[pipelineImpl.FirstStageIndex + j - 1]].SharedStateCapacity + 7 & -8);
					}
					flag = false;
				}
				if (inboundRecvBuffer.bufferLength != 0)
				{
					driver.PushDataEvent(connection, pipeline.Id, inboundRecvBuffer.buffer, inboundRecvBuffer.bufferLength);
				}
				if (num >= nativeList.Length)
				{
					break;
				}
				startStage = nativeList[num++];
				inboundRecvBuffer = default(InboundRecvBuffer);
			}
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x00009D9C File Offset: 0x00007F9C
		private unsafe void ProcessReceiveStage(int stage, NetworkPipeline pipeline, int internalBufferOffset, int internalSharedBufferOffset, ref NetworkPipelineContext ctx, ref InboundRecvBuffer inboundBuffer, ref NativeList<int> resumeQ, ref bool needsUpdate, ref bool needsSendUpdate, int systemHeadersSize)
		{
			NetworkPipelineProcessor.PipelineImpl pipelineImpl = this.m_Pipelines[pipeline.Id - 1];
			int index = this.m_StageList[pipelineImpl.FirstStageIndex + stage];
			NetworkPipelineStage networkPipelineStage = this.m_StageCollection[index];
			ctx.staticInstanceBuffer = (byte*)this.m_StaticInstanceBuffer.GetUnsafePtr<byte>() + networkPipelineStage.StaticStateStart;
			ctx.staticInstanceBufferLength = networkPipelineStage.StaticStateCapcity;
			ctx.internalProcessBuffer = (byte*)this.m_ReceiveBuffer.GetUnsafePtr<byte>() + internalBufferOffset;
			ctx.internalProcessBufferLength = networkPipelineStage.ReceiveCapacity;
			ctx.internalSharedProcessBuffer = (byte*)this.m_SharedBuffer.GetUnsafePtr<byte>() + internalSharedBufferOffset;
			ctx.internalSharedProcessBufferLength = networkPipelineStage.SharedStateCapacity;
			NetworkPipelineStage.Requests requests = NetworkPipelineStage.Requests.None;
			networkPipelineStage.Receive.Ptr.Invoke(ref ctx, ref inboundBuffer, ref requests, systemHeadersSize);
			if ((requests & NetworkPipelineStage.Requests.Resume) != NetworkPipelineStage.Requests.None)
			{
				resumeQ.Add(stage);
			}
			needsUpdate = ((requests & NetworkPipelineStage.Requests.Update) > NetworkPipelineStage.Requests.None);
			needsSendUpdate = ((requests & NetworkPipelineStage.Requests.SendUpdate) > NetworkPipelineStage.Requests.None);
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x00009E87 File Offset: 0x00008087
		[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
		public static void ValidateSendHandle(NetworkInterfaceSendHandle handle)
		{
			if (handle.data == IntPtr.Zero)
			{
				throw new ArgumentException("Value for NetworkDataStreamParameter.size must be larger then zero.");
			}
		}

		// Token: 0x04000118 RID: 280
		public const int Alignment = 8;

		// Token: 0x04000119 RID: 281
		public const int AlignmentMinusOne = 7;

		// Token: 0x0400011A RID: 282
		private NativeArray<NetworkPipelineStage> m_StageCollection;

		// Token: 0x0400011B RID: 283
		private NativeArray<byte> m_StaticInstanceBuffer;

		// Token: 0x0400011C RID: 284
		private NativeList<int> m_StageList;

		// Token: 0x0400011D RID: 285
		private NativeList<int> m_AccumulatedHeaderCapacity;

		// Token: 0x0400011E RID: 286
		private NativeList<NetworkPipelineProcessor.PipelineImpl> m_Pipelines;

		// Token: 0x0400011F RID: 287
		private NativeList<byte> m_ReceiveBuffer;

		// Token: 0x04000120 RID: 288
		private NativeList<byte> m_SendBuffer;

		// Token: 0x04000121 RID: 289
		private NativeList<byte> m_SharedBuffer;

		// Token: 0x04000122 RID: 290
		private NativeList<NetworkPipelineProcessor.UpdatePipeline> m_ReceiveStageNeedsUpdate;

		// Token: 0x04000123 RID: 291
		private NativeList<NetworkPipelineProcessor.UpdatePipeline> m_SendStageNeedsUpdate;

		// Token: 0x04000124 RID: 292
		private NativeQueue<NetworkPipelineProcessor.UpdatePipeline> m_SendStageNeedsUpdateRead;

		// Token: 0x04000125 RID: 293
		private NativeArray<int> sizePerConnection;

		// Token: 0x04000126 RID: 294
		private NativeArray<long> m_timestamp;

		// Token: 0x04000127 RID: 295
		private const int SendSizeOffset = 0;

		// Token: 0x04000128 RID: 296
		private const int RecveiveSizeOffset = 1;

		// Token: 0x04000129 RID: 297
		private const int SharedSizeOffset = 2;

		// Token: 0x02000056 RID: 86
		public struct Concurrent
		{
			// Token: 0x060001B3 RID: 435 RVA: 0x00009EA6 File Offset: 0x000080A6
			public int SendHeaderCapacity(NetworkPipeline pipeline)
			{
				return this.m_Pipelines[pipeline.Id - 1].headerCapacity;
			}

			// Token: 0x060001B4 RID: 436 RVA: 0x00009EC0 File Offset: 0x000080C0
			public int PayloadCapacity(NetworkPipeline pipeline)
			{
				if (pipeline.Id > 0)
				{
					return this.m_Pipelines[pipeline.Id - 1].payloadCapacity;
				}
				return 0;
			}

			// Token: 0x060001B5 RID: 437 RVA: 0x00009EE8 File Offset: 0x000080E8
			public unsafe int Send(NetworkDriver.Concurrent driver, NetworkPipeline pipeline, NetworkConnection connection, NetworkInterfaceSendHandle sendHandle, int headerSize)
			{
				if (sendHandle.data == IntPtr.Zero)
				{
					return -8;
				}
				int networkId = connection.m_NetworkId;
				int* ptr = (int*)this.sendBuffer.GetUnsafeReadOnlyPtr<byte>();
				ptr += networkId * this.sizePerConnection[0] / 4;
				if (Interlocked.CompareExchange(ref *ptr, 1, 0) != 0)
				{
					driver.AbortSend(sendHandle);
					return -7;
				}
				NativeList<NetworkPipelineProcessor.UpdatePipeline> currentUpdates = new NativeList<NetworkPipelineProcessor.UpdatePipeline>(128, Allocator.Temp);
				int result = this.ProcessPipelineSend(driver, 0, pipeline, connection, sendHandle, headerSize, currentUpdates);
				Interlocked.Exchange(ref *ptr, 0);
				for (int i = 0; i < currentUpdates.Length; i++)
				{
					this.m_SendStageNeedsUpdateWrite.Enqueue(currentUpdates[i]);
				}
				return result;
			}

			// Token: 0x060001B6 RID: 438 RVA: 0x00009FA4 File Offset: 0x000081A4
			internal unsafe int ProcessPipelineSend(NetworkDriver.Concurrent driver, int startStage, NetworkPipeline pipeline, NetworkConnection connection, NetworkInterfaceSendHandle sendHandle, int headerSize, NativeList<NetworkPipelineProcessor.UpdatePipeline> currentUpdates)
			{
				int num = headerSize;
				int num2 = sendHandle.size;
				NetworkPipelineContext networkPipelineContext = default(NetworkPipelineContext);
				networkPipelineContext.timestamp = this.m_timestamp[0];
				NetworkPipelineProcessor.PipelineImpl pipelineImpl = this.m_Pipelines[pipeline.Id - 1];
				int networkId = connection.m_NetworkId;
				int systemHeaderSize = driver.MaxProtocolHeaderSize();
				bool flag = sendHandle.data == IntPtr.Zero;
				int num3 = 0;
				NativeList<int> nativeList = new NativeList<int>(16, Allocator.Temp);
				int num4 = 0;
				InboundSendBuffer inboundSendBuffer = default(InboundSendBuffer);
				if (!flag)
				{
					inboundSendBuffer.bufferWithHeaders = (byte*)((byte*)((void*)sendHandle.data) + num) + 1;
					inboundSendBuffer.bufferWithHeadersLength = sendHandle.size - num - 1;
					inboundSendBuffer.buffer = inboundSendBuffer.bufferWithHeaders + pipelineImpl.headerCapacity;
					inboundSendBuffer.bufferLength = inboundSendBuffer.bufferWithHeadersLength - pipelineImpl.headerCapacity;
				}
				for (;;)
				{
					headerSize = pipelineImpl.headerCapacity;
					int num5 = pipelineImpl.sendBufferOffset + this.sizePerConnection[0] * networkId;
					int num6 = pipelineImpl.sharedBufferOffset + this.sizePerConnection[2] * networkId;
					if (startStage > 0)
					{
						if (inboundSendBuffer.bufferWithHeadersLength > 0)
						{
							break;
						}
						for (int i = 0; i < startStage; i++)
						{
							num5 += (this.m_StageCollection[this.m_StageList[pipelineImpl.FirstStageIndex + i]].SendCapacity + 7 & -8);
							num6 += (this.m_StageCollection[this.m_StageList[pipelineImpl.FirstStageIndex + i]].SharedStateCapacity + 7 & -8);
							headerSize -= this.m_StageCollection[this.m_StageList[pipelineImpl.FirstStageIndex + i]].HeaderCapacity;
						}
					}
					int j = startStage;
					while (j < pipelineImpl.NumStages)
					{
						int headerCapacity = this.m_StageCollection[this.m_StageList[pipelineImpl.FirstStageIndex + j]].HeaderCapacity;
						inboundSendBuffer.headerPadding = headerSize;
						headerSize -= headerCapacity;
						if (headerCapacity > 0 && inboundSendBuffer.bufferWithHeadersLength > 0)
						{
							NativeArray<byte> data = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<byte>((void*)(inboundSendBuffer.bufferWithHeaders + headerSize), headerCapacity, Allocator.Invalid);
							networkPipelineContext.header = new DataStreamWriter(data);
						}
						else
						{
							networkPipelineContext.header = new DataStreamWriter(headerCapacity, Allocator.Temp);
						}
						InboundSendBuffer inboundSendBuffer2 = inboundSendBuffer;
						NetworkPipelineStage.Requests requests = NetworkPipelineStage.Requests.None;
						int num7 = this.ProcessSendStage(j, num5, num6, pipelineImpl, ref nativeList, ref networkPipelineContext, ref inboundSendBuffer, ref requests, systemHeaderSize);
						if ((requests & NetworkPipelineStage.Requests.Update) != NetworkPipelineStage.Requests.None)
						{
							NetworkPipelineProcessor.AddSendUpdate(connection, j, pipeline, currentUpdates);
						}
						if (inboundSendBuffer.bufferWithHeadersLength == 0)
						{
							if ((requests & NetworkPipelineStage.Requests.Error) != NetworkPipelineStage.Requests.None && !flag)
							{
								num2 = num7;
								num3 = num7;
								break;
							}
							break;
						}
						else
						{
							if (inboundSendBuffer.buffer != inboundSendBuffer2.buffer)
							{
								UnsafeUtility.MemCpy((void*)(inboundSendBuffer.bufferWithHeaders + headerSize), networkPipelineContext.header.AsNativeArray().GetUnsafeReadOnlyPtr<byte>(), (long)networkPipelineContext.header.Length);
							}
							if (networkPipelineContext.header.Length < headerCapacity)
							{
								int num8 = headerCapacity - networkPipelineContext.header.Length;
								UnsafeUtility.MemMove((void*)(inboundSendBuffer.buffer - num8), (void*)inboundSendBuffer.buffer, (long)inboundSendBuffer.bufferLength);
							}
							inboundSendBuffer.buffer = inboundSendBuffer.bufferWithHeaders + headerSize;
							inboundSendBuffer.bufferLength = networkPipelineContext.header.Length + inboundSendBuffer.bufferLength;
							num5 += (networkPipelineContext.internalProcessBufferLength + 7 & -8);
							num6 += (networkPipelineContext.internalSharedProcessBufferLength + 7 & -8);
							j++;
						}
					}
					if (inboundSendBuffer.bufferLength != 0)
					{
						DataStreamWriter writer;
						if (sendHandle.data != IntPtr.Zero && inboundSendBuffer.bufferWithHeaders == (byte*)((byte*)((void*)sendHandle.data) + num) + 1)
						{
							if (inboundSendBuffer.buffer != inboundSendBuffer.bufferWithHeaders)
							{
								UnsafeUtility.MemMove((void*)inboundSendBuffer.bufferWithHeaders, (void*)inboundSendBuffer.buffer, (long)inboundSendBuffer.bufferLength);
								inboundSendBuffer.buffer = inboundSendBuffer.bufferWithHeaders;
							}
							((byte*)((void*)sendHandle.data))[num] = (byte)pipeline.Id;
							int size = num + 1 + inboundSendBuffer.bufferLength;
							sendHandle.size = size;
							if ((num2 = driver.CompleteSend(connection, sendHandle, true)) < 0)
							{
								Debug.LogWarning(FixedString.Format("CompleteSend failed with the following error code: {0}", num2));
							}
							sendHandle = default(NetworkInterfaceSendHandle);
						}
						else if (driver.BeginSend(connection, out writer, 0) == 0)
						{
							writer.WriteByte((byte)pipeline.Id);
							writer.WriteBytes(inboundSendBuffer.buffer, inboundSendBuffer.bufferLength);
							if ((num2 = driver.EndSend(writer)) <= 0)
							{
								Debug.Log(FixedString.Format("An error occurred during EndSend. ErrorCode: {0}", num2));
							}
						}
					}
					if (num4 >= nativeList.Length)
					{
						goto IL_4D1;
					}
					startStage = nativeList[num4++];
					inboundSendBuffer = default(InboundSendBuffer);
				}
				Debug.LogError("Can't start from a stage with a buffer");
				return -3;
				IL_4D1:
				if (sendHandle.data != IntPtr.Zero)
				{
					driver.AbortSend(sendHandle);
				}
				if (num3 >= 0)
				{
					return num2;
				}
				return num3;
			}

			// Token: 0x060001B7 RID: 439 RVA: 0x0000A4A8 File Offset: 0x000086A8
			private unsafe int ProcessSendStage(int startStage, int internalBufferOffset, int internalSharedBufferOffset, NetworkPipelineProcessor.PipelineImpl p, ref NativeList<int> resumeQ, ref NetworkPipelineContext ctx, ref InboundSendBuffer inboundBuffer, ref NetworkPipelineStage.Requests requests, int systemHeaderSize)
			{
				int index = p.FirstStageIndex + startStage;
				NetworkPipelineStage networkPipelineStage = this.m_StageCollection[this.m_StageList[index]];
				ctx.accumulatedHeaderCapacity = this.m_AccumulatedHeaderCapacity[index];
				ctx.staticInstanceBuffer = (byte*)this.m_StaticInstanceBuffer.GetUnsafeReadOnlyPtr<byte>() + networkPipelineStage.StaticStateStart;
				ctx.staticInstanceBufferLength = networkPipelineStage.StaticStateCapcity;
				ctx.internalProcessBuffer = (byte*)this.sendBuffer.GetUnsafeReadOnlyPtr<byte>() + internalBufferOffset;
				ctx.internalProcessBufferLength = networkPipelineStage.SendCapacity;
				ctx.internalSharedProcessBuffer = (byte*)this.sharedBuffer.GetUnsafeReadOnlyPtr<byte>() + internalSharedBufferOffset;
				ctx.internalSharedProcessBufferLength = networkPipelineStage.SharedStateCapacity;
				requests = NetworkPipelineStage.Requests.None;
				int result = networkPipelineStage.Send.Ptr.Invoke(ref ctx, ref inboundBuffer, ref requests, systemHeaderSize);
				if ((requests & NetworkPipelineStage.Requests.Resume) != NetworkPipelineStage.Requests.None)
				{
					resumeQ.Add(startStage);
				}
				return result;
			}

			// Token: 0x0400012A RID: 298
			[ReadOnly]
			internal NativeArray<NetworkPipelineStage> m_StageCollection;

			// Token: 0x0400012B RID: 299
			[ReadOnly]
			internal NativeArray<byte> m_StaticInstanceBuffer;

			// Token: 0x0400012C RID: 300
			[ReadOnly]
			internal NativeList<NetworkPipelineProcessor.PipelineImpl> m_Pipelines;

			// Token: 0x0400012D RID: 301
			[ReadOnly]
			internal NativeList<int> m_StageList;

			// Token: 0x0400012E RID: 302
			[ReadOnly]
			internal NativeList<int> m_AccumulatedHeaderCapacity;

			// Token: 0x0400012F RID: 303
			internal NativeQueue<NetworkPipelineProcessor.UpdatePipeline>.ParallelWriter m_SendStageNeedsUpdateWrite;

			// Token: 0x04000130 RID: 304
			[ReadOnly]
			internal NativeArray<int> sizePerConnection;

			// Token: 0x04000131 RID: 305
			[ReadOnly]
			internal NativeList<byte> sharedBuffer;

			// Token: 0x04000132 RID: 306
			[ReadOnly]
			internal NativeList<byte> sendBuffer;

			// Token: 0x04000133 RID: 307
			[ReadOnly]
			internal NativeArray<long> m_timestamp;
		}

		// Token: 0x02000057 RID: 87
		internal struct PipelineImpl
		{
			// Token: 0x04000134 RID: 308
			public int FirstStageIndex;

			// Token: 0x04000135 RID: 309
			public int NumStages;

			// Token: 0x04000136 RID: 310
			public int receiveBufferOffset;

			// Token: 0x04000137 RID: 311
			public int sendBufferOffset;

			// Token: 0x04000138 RID: 312
			public int sharedBufferOffset;

			// Token: 0x04000139 RID: 313
			public int headerCapacity;

			// Token: 0x0400013A RID: 314
			public int payloadCapacity;
		}

		// Token: 0x02000058 RID: 88
		internal struct UpdatePipeline
		{
			// Token: 0x0400013B RID: 315
			public NetworkPipeline pipeline;

			// Token: 0x0400013C RID: 316
			public int stage;

			// Token: 0x0400013D RID: 317
			public NetworkConnection connection;
		}
	}
}
