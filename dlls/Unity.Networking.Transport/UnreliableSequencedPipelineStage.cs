using System;
using AOT;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Networking.Transport.Utilities;

namespace Unity.Networking.Transport
{
	// Token: 0x02000076 RID: 118
	[BurstCompile]
	public struct UnreliableSequencedPipelineStage : INetworkPipelineStage
	{
		// Token: 0x0600020C RID: 524 RVA: 0x0000B5C7 File Offset: 0x000097C7
		public unsafe NetworkPipelineStage StaticInitialize(byte* staticInstanceBuffer, int staticInstanceBufferLength, NetworkSettings settings)
		{
			return new NetworkPipelineStage(UnreliableSequencedPipelineStage.ReceiveFunctionPointer, UnreliableSequencedPipelineStage.SendFunctionPointer, UnreliableSequencedPipelineStage.InitializeConnectionFunctionPointer, UnsafeUtility.SizeOf<int>(), UnsafeUtility.SizeOf<int>(), UnsafeUtility.SizeOf<ushort>(), 0, 0);
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x0600020D RID: 525 RVA: 0x00002C09 File Offset: 0x00000E09
		public int StaticSize
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x0600020E RID: 526 RVA: 0x0000B5F0 File Offset: 0x000097F0
		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(NetworkPipelineStage.ReceiveDelegate))]
		private unsafe static void Receive(ref NetworkPipelineContext ctx, ref InboundRecvBuffer inboundBuffer, ref NetworkPipelineStage.Requests requests, int systemHeaderSize)
		{
			NativeArray<byte> array = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<byte>((void*)inboundBuffer.buffer, inboundBuffer.bufferLength, Allocator.Invalid);
			DataStreamReader dataStreamReader = new DataStreamReader(array);
			int* internalProcessBuffer = (int*)ctx.internalProcessBuffer;
			ushort num = dataStreamReader.ReadUShort();
			if (SequenceHelpers.GreaterThan16(num, (ushort)(*internalProcessBuffer)))
			{
				*internalProcessBuffer = (int)num;
				inboundBuffer = inboundBuffer.Slice(2);
				return;
			}
			inboundBuffer = default(InboundRecvBuffer);
		}

		// Token: 0x0600020F RID: 527 RVA: 0x0000B64C File Offset: 0x0000984C
		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(NetworkPipelineStage.SendDelegate))]
		private unsafe static int Send(ref NetworkPipelineContext ctx, ref InboundSendBuffer inboundBuffer, ref NetworkPipelineStage.Requests requests, int systemHeaderSize)
		{
			int* internalProcessBuffer = (int*)ctx.internalProcessBuffer;
			ctx.header.WriteUShort((ushort)(*internalProcessBuffer));
			*internalProcessBuffer = (int)((ushort)(*internalProcessBuffer + 1));
			return 0;
		}

		// Token: 0x06000210 RID: 528 RVA: 0x0000B677 File Offset: 0x00009877
		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(NetworkPipelineStage.InitializeConnectionDelegate))]
		private unsafe static void InitializeConnection(byte* staticInstanceBuffer, int staticInstanceBufferLength, byte* sendProcessBuffer, int sendProcessBufferLength, byte* recvProcessBuffer, int recvProcessBufferLength, byte* sharedProcessBuffer, int sharedProcessBufferLength)
		{
			if (recvProcessBufferLength > 0)
			{
				*(int*)recvProcessBuffer = -1;
			}
		}

		// Token: 0x0400018A RID: 394
		private static TransportFunctionPointer<NetworkPipelineStage.ReceiveDelegate> ReceiveFunctionPointer = new TransportFunctionPointer<NetworkPipelineStage.ReceiveDelegate>(new NetworkPipelineStage.ReceiveDelegate(UnreliableSequencedPipelineStage.Receive));

		// Token: 0x0400018B RID: 395
		private static TransportFunctionPointer<NetworkPipelineStage.SendDelegate> SendFunctionPointer = new TransportFunctionPointer<NetworkPipelineStage.SendDelegate>(new NetworkPipelineStage.SendDelegate(UnreliableSequencedPipelineStage.Send));

		// Token: 0x0400018C RID: 396
		private static TransportFunctionPointer<NetworkPipelineStage.InitializeConnectionDelegate> InitializeConnectionFunctionPointer = new TransportFunctionPointer<NetworkPipelineStage.InitializeConnectionDelegate>(new NetworkPipelineStage.InitializeConnectionDelegate(UnreliableSequencedPipelineStage.InitializeConnection));
	}
}
