using System;
using AOT;
using Unity.Burst;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Networking.Transport.Utilities;

namespace Unity.Networking.Transport
{
	// Token: 0x02000074 RID: 116
	[BurstCompile]
	public struct SimulatorPipelineStage : INetworkPipelineStage
	{
		// Token: 0x06000200 RID: 512 RVA: 0x0000B200 File Offset: 0x00009400
		public unsafe NetworkPipelineStage StaticInitialize(byte* staticInstanceBuffer, int staticInstanceBufferLength, NetworkSettings settings)
		{
			SimulatorUtility.Parameters simulatorStageParameters = ref settings.GetSimulatorStageParameters();
			UnsafeUtility.MemCpy((void*)staticInstanceBuffer, (void*)(&simulatorStageParameters), (long)UnsafeUtility.SizeOf<SimulatorUtility.Parameters>());
			return new NetworkPipelineStage(SimulatorPipelineStage.ReceiveFunctionPointer, SimulatorPipelineStage.SendFunctionPointer, SimulatorPipelineStage.InitializeConnectionFunctionPointer, simulatorStageParameters.MaxPacketCount * (simulatorStageParameters.MaxPacketSize + UnsafeUtility.SizeOf<SimulatorUtility.DelayedPacket>()), 0, 0, UnsafeUtility.SizeOf<SimulatorUtility.Context>(), 0);
		}

		// Token: 0x06000201 RID: 513 RVA: 0x0000B254 File Offset: 0x00009454
		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(NetworkPipelineStage.InitializeConnectionDelegate))]
		private unsafe static void InitializeConnection(byte* staticInstanceBuffer, int staticInstanceBufferLength, byte* sendProcessBuffer, int sendProcessBufferLength, byte* recvProcessBuffer, int recvProcessBufferLength, byte* sharedProcessBuffer, int sharedProcessBufferLength)
		{
			SimulatorUtility.Parameters param = default(SimulatorUtility.Parameters);
			UnsafeUtility.MemCpy((void*)(&param), (void*)staticInstanceBuffer, (long)UnsafeUtility.SizeOf<SimulatorUtility.Parameters>());
			if (sharedProcessBufferLength >= UnsafeUtility.SizeOf<SimulatorUtility.Parameters>())
			{
				SimulatorUtility.InitializeContext(param, sharedProcessBuffer);
			}
		}

		// Token: 0x06000202 RID: 514 RVA: 0x00002C09 File Offset: 0x00000E09
		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(NetworkPipelineStage.SendDelegate))]
		private static int Send(ref NetworkPipelineContext ctx, ref InboundSendBuffer inboundBuffer, ref NetworkPipelineStage.Requests requests, int systemHeaderSize)
		{
			return 0;
		}

		// Token: 0x06000203 RID: 515 RVA: 0x0000B28C File Offset: 0x0000948C
		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(NetworkPipelineStage.ReceiveDelegate))]
		private unsafe static void Receive(ref NetworkPipelineContext ctx, ref InboundRecvBuffer inboundBuffer, ref NetworkPipelineStage.Requests requests, int systemHeaderSize)
		{
			SimulatorUtility.Context* internalSharedProcessBuffer = (SimulatorUtility.Context*)ctx.internalSharedProcessBuffer;
			SimulatorUtility.Parameters parameters = *(SimulatorUtility.Parameters*)ctx.staticInstanceBuffer;
			SimulatorUtility simulatorUtility = new SimulatorUtility(parameters.MaxPacketCount, parameters.MaxPacketSize, parameters.PacketDelayMs, parameters.PacketJitterMs);
			if (inboundBuffer.bufferLength > parameters.MaxPacketSize)
			{
				return;
			}
			long timestamp = ctx.timestamp;
			if (inboundBuffer.bufferLength > 0)
			{
				internalSharedProcessBuffer->PacketCount++;
				if (simulatorUtility.ShouldDropPacket(internalSharedProcessBuffer, parameters, timestamp))
				{
					internalSharedProcessBuffer->PacketDropCount++;
					inboundBuffer = default(InboundRecvBuffer);
					return;
				}
				InboundSendBuffer inboundBuffer2 = default(InboundSendBuffer);
				inboundBuffer2.bufferWithHeaders = inboundBuffer.buffer;
				inboundBuffer2.bufferWithHeadersLength = inboundBuffer.bufferLength;
				inboundBuffer2.buffer = inboundBuffer.buffer;
				inboundBuffer2.bufferLength = inboundBuffer.bufferLength;
				inboundBuffer2.headerPadding = 0;
				if (internalSharedProcessBuffer->PacketDelayMs == 0 || !simulatorUtility.DelayPacket(ref ctx, inboundBuffer2, ref requests, timestamp))
				{
					return;
				}
			}
			InboundSendBuffer inboundSendBuffer = default(InboundSendBuffer);
			if (simulatorUtility.GetDelayedPacket(ref ctx, ref inboundSendBuffer, ref requests, timestamp))
			{
				inboundBuffer.buffer = inboundSendBuffer.bufferWithHeaders;
				inboundBuffer.bufferLength = inboundSendBuffer.bufferWithHeadersLength;
				return;
			}
			inboundBuffer = default(InboundRecvBuffer);
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000204 RID: 516 RVA: 0x0000B3AA File Offset: 0x000095AA
		public int StaticSize
		{
			get
			{
				return UnsafeUtility.SizeOf<SimulatorUtility.Parameters>();
			}
		}

		// Token: 0x04000184 RID: 388
		private static TransportFunctionPointer<NetworkPipelineStage.ReceiveDelegate> ReceiveFunctionPointer = new TransportFunctionPointer<NetworkPipelineStage.ReceiveDelegate>(new NetworkPipelineStage.ReceiveDelegate(SimulatorPipelineStage.Receive));

		// Token: 0x04000185 RID: 389
		private static TransportFunctionPointer<NetworkPipelineStage.SendDelegate> SendFunctionPointer = new TransportFunctionPointer<NetworkPipelineStage.SendDelegate>(new NetworkPipelineStage.SendDelegate(SimulatorPipelineStage.Send));

		// Token: 0x04000186 RID: 390
		private static TransportFunctionPointer<NetworkPipelineStage.InitializeConnectionDelegate> InitializeConnectionFunctionPointer = new TransportFunctionPointer<NetworkPipelineStage.InitializeConnectionDelegate>(new NetworkPipelineStage.InitializeConnectionDelegate(SimulatorPipelineStage.InitializeConnection));
	}
}
