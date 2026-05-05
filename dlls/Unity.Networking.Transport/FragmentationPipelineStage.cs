using System;
using AOT;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Networking.Transport.Utilities;
using UnityEngine;

namespace Unity.Networking.Transport
{
	// Token: 0x0200006E RID: 110
	[BurstCompile]
	public struct FragmentationPipelineStage : INetworkPipelineStage
	{
		// Token: 0x060001EE RID: 494 RVA: 0x0000A9FC File Offset: 0x00008BFC
		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(NetworkPipelineStage.SendDelegate))]
		private unsafe static int Send(ref NetworkPipelineContext ctx, ref InboundSendBuffer inboundBuffer, ref NetworkPipelineStage.Requests requests, int systemHeaderSize)
		{
			FragmentationPipelineStage.FragContext* internalProcessBuffer = (FragmentationPipelineStage.FragContext*)ctx.internalProcessBuffer;
			byte* ptr = ctx.internalProcessBuffer + sizeof(FragmentationPipelineStage.FragContext);
			FragmentationPipelineStage.FragSharedContext* staticInstanceBuffer = (FragmentationPipelineStage.FragSharedContext*)ctx.staticInstanceBuffer;
			FragmentationPipelineStage.FragFlags fragFlags = FragmentationPipelineStage.FragFlags.First;
			int capacity = ctx.header.Capacity;
			int num = systemHeaderSize + 1 + 8;
			int num2 = staticInstanceBuffer->MaxMessageSize - num - inboundBuffer.headerPadding;
			int num3 = num2 - ctx.accumulatedHeaderCapacity;
			if (internalProcessBuffer->endIndex > internalProcessBuffer->startIndex)
			{
				if (inboundBuffer.bufferLength != 0)
				{
					return -3;
				}
				fragFlags &= ~FragmentationPipelineStage.FragFlags.First;
				int num4 = internalProcessBuffer->endIndex - internalProcessBuffer->startIndex;
				if (num4 > num2)
				{
					num4 = num2;
				}
				byte* ptr2 = ptr + internalProcessBuffer->startIndex;
				inboundBuffer.buffer = ptr2;
				inboundBuffer.bufferWithHeaders = ptr2 - inboundBuffer.headerPadding;
				inboundBuffer.bufferLength = num4;
				inboundBuffer.bufferWithHeadersLength = num4 + inboundBuffer.headerPadding;
				internalProcessBuffer->startIndex += num4;
			}
			else if (inboundBuffer.bufferLength > num3)
			{
				int payloadCapacity = staticInstanceBuffer->PayloadCapacity;
				int num5 = inboundBuffer.bufferLength - num3;
				byte* source = inboundBuffer.buffer + num3;
				if (num5 + inboundBuffer.headerPadding > payloadCapacity)
				{
					return -4;
				}
				UnsafeUtility.MemCpy((void*)(ptr + inboundBuffer.headerPadding), (void*)source, (long)num5);
				internalProcessBuffer->startIndex = inboundBuffer.headerPadding;
				internalProcessBuffer->endIndex = num5 + inboundBuffer.headerPadding;
				inboundBuffer.bufferWithHeadersLength -= num5;
				inboundBuffer.bufferLength -= num5;
			}
			if (internalProcessBuffer->endIndex > internalProcessBuffer->startIndex)
			{
				requests |= NetworkPipelineStage.Requests.Resume;
			}
			else
			{
				fragFlags |= FragmentationPipelineStage.FragFlags.Last;
			}
			FragmentationPipelineStage.FragContext* ptr3 = internalProcessBuffer;
			int sequence = ptr3->sequence;
			ptr3->sequence = sequence + 1;
			int num6 = (sequence & 16383) | (int)fragFlags;
			ctx.header.WriteShort((short)num6);
			return 0;
		}

		// Token: 0x060001EF RID: 495 RVA: 0x0000ABA4 File Offset: 0x00008DA4
		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(NetworkPipelineStage.ReceiveDelegate))]
		private unsafe static void Receive(ref NetworkPipelineContext ctx, ref InboundRecvBuffer inboundBuffer, ref NetworkPipelineStage.Requests requests, int systemHeaderSize)
		{
			FragmentationPipelineStage.FragContext* internalProcessBuffer = (FragmentationPipelineStage.FragContext*)ctx.internalProcessBuffer;
			byte* ptr = ctx.internalProcessBuffer + sizeof(FragmentationPipelineStage.FragContext);
			FragmentationPipelineStage.FragSharedContext* staticInstanceBuffer = (FragmentationPipelineStage.FragSharedContext*)ctx.staticInstanceBuffer;
			NativeArray<byte> array = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<byte>((void*)inboundBuffer.buffer, inboundBuffer.bufferLength, Allocator.Invalid);
			DataStreamReader dataStreamReader = new DataStreamReader(array);
			short num = dataStreamReader.ReadShort();
			int num2 = (int)(num & 16383);
			FragmentationPipelineStage.FragFlags fragFlags = (FragmentationPipelineStage.FragFlags)(num & -16384);
			inboundBuffer = inboundBuffer.Slice(2);
			int num3 = internalProcessBuffer->sequence;
			bool flag = (fragFlags & FragmentationPipelineStage.FragFlags.First) > (FragmentationPipelineStage.FragFlags)0;
			bool flag2 = (fragFlags & FragmentationPipelineStage.FragFlags.Last) > (FragmentationPipelineStage.FragFlags)0;
			if (flag)
			{
				num3 = num2;
				internalProcessBuffer->packetError = false;
				internalProcessBuffer->endIndex = 0;
			}
			if (num2 != num3)
			{
				internalProcessBuffer->packetError = true;
				internalProcessBuffer->endIndex = 0;
			}
			if (!internalProcessBuffer->packetError)
			{
				if (!flag2 || internalProcessBuffer->endIndex > 0)
				{
					if (internalProcessBuffer->endIndex + inboundBuffer.bufferLength > staticInstanceBuffer->PayloadCapacity)
					{
						Debug.LogError("Fragmentation capacity exceeded");
						return;
					}
					UnsafeUtility.MemCpy((void*)(ptr + internalProcessBuffer->endIndex), (void*)inboundBuffer.buffer, (long)inboundBuffer.bufferLength);
					internalProcessBuffer->endIndex += inboundBuffer.bufferLength;
				}
				if (flag2 && internalProcessBuffer->endIndex > 0)
				{
					inboundBuffer = new InboundRecvBuffer
					{
						buffer = ptr,
						bufferLength = internalProcessBuffer->endIndex
					};
				}
			}
			if (!flag2 || internalProcessBuffer->packetError)
			{
				inboundBuffer = default(InboundRecvBuffer);
			}
			internalProcessBuffer->sequence = (num2 + 1 & 16383);
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x00003CAF File Offset: 0x00001EAF
		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(NetworkPipelineStage.InitializeConnectionDelegate))]
		private unsafe static void InitializeConnection(byte* staticInstanceBuffer, int staticInstanceBufferLength, byte* sendProcessBuffer, int sendProcessBufferLength, byte* recvProcessBuffer, int recvProcessBufferLength, byte* sharedProcessBuffer, int sharedProcessBufferLength)
		{
		}

		// Token: 0x060001F1 RID: 497 RVA: 0x0000AD0C File Offset: 0x00008F0C
		public unsafe NetworkPipelineStage StaticInitialize(byte* staticInstanceBuffer, int staticInstanceBufferLength, NetworkSettings settings)
		{
			((FragmentationPipelineStage.FragSharedContext*)staticInstanceBuffer)->PayloadCapacity = ref settings.GetFragmentationStageParameters().PayloadCapacity;
			((FragmentationPipelineStage.FragSharedContext*)staticInstanceBuffer)->MaxMessageSize = ref settings.GetNetworkConfigParameters().maxMessageSize;
			return new NetworkPipelineStage(FragmentationPipelineStage.ReceiveFunctionPointer, FragmentationPipelineStage.SendFunctionPointer, FragmentationPipelineStage.InitializeConnectionFunctionPointer, sizeof(FragmentationPipelineStage.FragContext) + ((FragmentationPipelineStage.FragSharedContext*)staticInstanceBuffer)->PayloadCapacity, sizeof(FragmentationPipelineStage.FragContext) + ((FragmentationPipelineStage.FragSharedContext*)staticInstanceBuffer)->PayloadCapacity, 2, 0, ((FragmentationPipelineStage.FragSharedContext*)staticInstanceBuffer)->PayloadCapacity);
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x060001F2 RID: 498 RVA: 0x0000AD75 File Offset: 0x00008F75
		public int StaticSize
		{
			get
			{
				return UnsafeUtility.SizeOf<FragmentationPipelineStage.FragSharedContext>();
			}
		}

		// Token: 0x04000170 RID: 368
		private const int FragHeaderCapacity = 2;

		// Token: 0x04000171 RID: 369
		private static TransportFunctionPointer<NetworkPipelineStage.ReceiveDelegate> ReceiveFunctionPointer = new TransportFunctionPointer<NetworkPipelineStage.ReceiveDelegate>(new NetworkPipelineStage.ReceiveDelegate(FragmentationPipelineStage.Receive));

		// Token: 0x04000172 RID: 370
		private static TransportFunctionPointer<NetworkPipelineStage.SendDelegate> SendFunctionPointer = new TransportFunctionPointer<NetworkPipelineStage.SendDelegate>(new NetworkPipelineStage.SendDelegate(FragmentationPipelineStage.Send));

		// Token: 0x04000173 RID: 371
		private static TransportFunctionPointer<NetworkPipelineStage.InitializeConnectionDelegate> InitializeConnectionFunctionPointer = new TransportFunctionPointer<NetworkPipelineStage.InitializeConnectionDelegate>(new NetworkPipelineStage.InitializeConnectionDelegate(FragmentationPipelineStage.InitializeConnection));

		// Token: 0x0200006F RID: 111
		public struct FragContext
		{
			// Token: 0x04000174 RID: 372
			public int startIndex;

			// Token: 0x04000175 RID: 373
			public int endIndex;

			// Token: 0x04000176 RID: 374
			public int sequence;

			// Token: 0x04000177 RID: 375
			public bool packetError;
		}

		// Token: 0x02000070 RID: 112
		internal struct FragSharedContext
		{
			// Token: 0x04000178 RID: 376
			public int PayloadCapacity;

			// Token: 0x04000179 RID: 377
			public int MaxMessageSize;
		}

		// Token: 0x02000071 RID: 113
		[Flags]
		private enum FragFlags
		{
			// Token: 0x0400017B RID: 379
			First = 32768,
			// Token: 0x0400017C RID: 380
			Last = 16384,
			// Token: 0x0400017D RID: 381
			SeqMask = 16383
		}
	}
}
