using System;
using AOT;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Networking.Transport.Utilities;

namespace Unity.Networking.Transport
{
	// Token: 0x02000073 RID: 115
	[BurstCompile]
	public struct ReliableSequencedPipelineStage : INetworkPipelineStage
	{
		// Token: 0x060001FA RID: 506 RVA: 0x0000AE38 File Offset: 0x00009038
		public unsafe NetworkPipelineStage StaticInitialize(byte* staticInstanceBuffer, int staticInstanceBufferLength, NetworkSettings settings)
		{
			ReliableUtility.Parameters reliableStageParameters = ref settings.GetReliableStageParameters();
			UnsafeUtility.MemCpy((void*)staticInstanceBuffer, (void*)(&reliableStageParameters), (long)UnsafeUtility.SizeOf<ReliableUtility.Parameters>());
			return new NetworkPipelineStage(ReliableSequencedPipelineStage.ReceiveFunctionPointer, ReliableSequencedPipelineStage.SendFunctionPointer, ReliableSequencedPipelineStage.InitializeConnectionFunctionPointer, ReliableUtility.ProcessCapacityNeeded(reliableStageParameters), ReliableUtility.ProcessCapacityNeeded(reliableStageParameters), ReliableUtility.PacketHeaderWireSize(reliableStageParameters.WindowSize), ReliableUtility.SharedCapacityNeeded(reliableStageParameters), 0);
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060001FB RID: 507 RVA: 0x0000AE8E File Offset: 0x0000908E
		public int StaticSize
		{
			get
			{
				return UnsafeUtility.SizeOf<ReliableUtility.Parameters>();
			}
		}

		// Token: 0x060001FC RID: 508 RVA: 0x0000AE98 File Offset: 0x00009098
		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(NetworkPipelineStage.ReceiveDelegate))]
		private unsafe static void Receive(ref NetworkPipelineContext ctx, ref InboundRecvBuffer inboundBuffer, ref NetworkPipelineStage.Requests requests, int systemHeaderSize)
		{
			requests = NetworkPipelineStage.Requests.SendUpdate;
			ReliableUtility.ReliableHeader reliableHeader = default(ReliableUtility.ReliableHeader);
			ReliableUtility.Context* internalProcessBuffer = (ReliableUtility.Context*)ctx.internalProcessBuffer;
			ReliableUtility.SharedContext* internalSharedProcessBuffer = (ReliableUtility.SharedContext*)ctx.internalSharedProcessBuffer;
			if (inboundBuffer.buffer != null)
			{
				NativeArray<byte> array = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<byte>((void*)inboundBuffer.buffer, inboundBuffer.bufferLength, Allocator.Invalid);
				DataStreamReader dataStreamReader = new DataStreamReader(array);
				dataStreamReader.ReadBytes((byte*)(&reliableHeader), ReliableUtility.PacketHeaderWireSize(ctx));
				InboundRecvBuffer inboundRecvBuffer = inboundBuffer.Slice(ReliableUtility.PacketHeaderWireSize(ctx));
				inboundBuffer = default(InboundRecvBuffer);
				if (reliableHeader.Type == 1)
				{
					ReliableUtility.ReadAckPacket(ctx, reliableHeader);
				}
				else
				{
					long num = ReliableUtility.Read(ctx, reliableHeader);
					if (num >= 0L)
					{
						ushort num2 = (ushort)(internalProcessBuffer->Delivered + 1L);
						if (num == (long)((ulong)num2))
						{
							internalProcessBuffer->Delivered = num;
							inboundBuffer = inboundRecvBuffer;
						}
						else
						{
							ReliableUtility.SetPacket(ctx.internalProcessBuffer, num, inboundRecvBuffer);
						}
					}
				}
			}
			if (inboundBuffer.buffer == null)
			{
				bool flag = false;
				inboundBuffer = ReliableUtility.ResumeReceive(ctx, 0, ref flag);
			}
			if (ReliableUtility.NeedResumeReceive(ctx))
			{
				requests |= NetworkPipelineStage.Requests.Resume;
			}
		}

		// Token: 0x060001FD RID: 509 RVA: 0x0000AFA8 File Offset: 0x000091A8
		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(NetworkPipelineStage.SendDelegate))]
		private unsafe static int Send(ref NetworkPipelineContext ctx, ref InboundSendBuffer inboundBuffer, ref NetworkPipelineStage.Requests requests, int systemHeaderSize)
		{
			requests = NetworkPipelineStage.Requests.Update;
			ReliableUtility.ReliableHeader reliableHeader = default(ReliableUtility.ReliableHeader);
			ReliableUtility.Context* internalProcessBuffer = (ReliableUtility.Context*)ctx.internalProcessBuffer;
			ReliableUtility.ReleaseAcknowledgedPackets(ctx);
			if (inboundBuffer.bufferLength > 0)
			{
				internalProcessBuffer->LastSentTime = ctx.timestamp;
				if (ReliableUtility.Write(ctx, inboundBuffer, ref reliableHeader) < 0L)
				{
					inboundBuffer = default(InboundSendBuffer);
					requests |= NetworkPipelineStage.Requests.Error;
					return -5;
				}
				ctx.header.Clear();
				ctx.header.WriteBytes((byte*)(&reliableHeader), ReliableUtility.PacketHeaderWireSize(ctx));
				internalProcessBuffer->PreviousTimestamp = ctx.timestamp;
				return 0;
			}
			else
			{
				if (internalProcessBuffer->Resume != -1L)
				{
					internalProcessBuffer->LastSentTime = ctx.timestamp;
					bool flag = false;
					inboundBuffer = ReliableUtility.ResumeSend(ctx, out reliableHeader, ref flag);
					internalProcessBuffer->Resume = ReliableUtility.GetNextSendResumeSequence(ctx);
					if (internalProcessBuffer->Resume != -1L)
					{
						requests |= NetworkPipelineStage.Requests.Resume;
					}
					ctx.header.Clear();
					ctx.header.WriteBytes((byte*)(&reliableHeader), ReliableUtility.PacketHeaderWireSize(ctx));
					internalProcessBuffer->PreviousTimestamp = ctx.timestamp;
					return 0;
				}
				internalProcessBuffer->Resume = ReliableUtility.GetNextSendResumeSequence(ctx);
				if (internalProcessBuffer->Resume != -1L)
				{
					requests |= NetworkPipelineStage.Requests.Resume;
				}
				if (ReliableUtility.ShouldSendAck(ctx))
				{
					internalProcessBuffer->LastSentTime = ctx.timestamp;
					ReliableUtility.WriteAckPacket(ctx, ref reliableHeader);
					ctx.header.WriteBytes((byte*)(&reliableHeader), ReliableUtility.PacketHeaderWireSize(ctx));
					internalProcessBuffer->PreviousTimestamp = ctx.timestamp;
					inboundBuffer.bufferWithHeadersLength = inboundBuffer.headerPadding + 1;
					inboundBuffer.bufferWithHeaders = (byte*)UnsafeUtility.Malloc((long)inboundBuffer.bufferWithHeadersLength, 8, Allocator.Temp);
					inboundBuffer.SetBufferFrombufferWithHeaders();
					return 0;
				}
				internalProcessBuffer->PreviousTimestamp = ctx.timestamp;
				return 0;
			}
		}

		// Token: 0x060001FE RID: 510 RVA: 0x0000B168 File Offset: 0x00009368
		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(NetworkPipelineStage.InitializeConnectionDelegate))]
		private unsafe static void InitializeConnection(byte* staticInstanceBuffer, int staticInstanceBufferLength, byte* sendProcessBuffer, int sendProcessBufferLength, byte* recvProcessBuffer, int recvProcessBufferLength, byte* sharedProcessBuffer, int sharedProcessBufferLength)
		{
			ReliableUtility.Parameters param;
			UnsafeUtility.MemCpy((void*)(&param), (void*)staticInstanceBuffer, (long)UnsafeUtility.SizeOf<ReliableUtility.Parameters>());
			if (sharedProcessBufferLength >= ReliableUtility.SharedCapacityNeeded(param) && sendProcessBufferLength + recvProcessBufferLength >= ReliableUtility.ProcessCapacityNeeded(param) * 2)
			{
				ReliableUtility.InitializeContext(sharedProcessBuffer, sharedProcessBufferLength, sendProcessBuffer, sendProcessBufferLength, recvProcessBuffer, recvProcessBufferLength, param);
			}
		}

		// Token: 0x04000181 RID: 385
		private static TransportFunctionPointer<NetworkPipelineStage.ReceiveDelegate> ReceiveFunctionPointer = new TransportFunctionPointer<NetworkPipelineStage.ReceiveDelegate>(new NetworkPipelineStage.ReceiveDelegate(ReliableSequencedPipelineStage.Receive));

		// Token: 0x04000182 RID: 386
		private static TransportFunctionPointer<NetworkPipelineStage.SendDelegate> SendFunctionPointer = new TransportFunctionPointer<NetworkPipelineStage.SendDelegate>(new NetworkPipelineStage.SendDelegate(ReliableSequencedPipelineStage.Send));

		// Token: 0x04000183 RID: 387
		private static TransportFunctionPointer<NetworkPipelineStage.InitializeConnectionDelegate> InitializeConnectionFunctionPointer = new TransportFunctionPointer<NetworkPipelineStage.InitializeConnectionDelegate>(new NetworkPipelineStage.InitializeConnectionDelegate(ReliableSequencedPipelineStage.InitializeConnection));
	}
}
