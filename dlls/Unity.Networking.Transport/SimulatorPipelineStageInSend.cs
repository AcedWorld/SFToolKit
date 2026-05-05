using System;
using AOT;
using Unity.Burst;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Networking.Transport.Utilities;

namespace Unity.Networking.Transport
{
	// Token: 0x02000075 RID: 117
	[BurstCompile]
	public struct SimulatorPipelineStageInSend : INetworkPipelineStage
	{
		// Token: 0x06000206 RID: 518 RVA: 0x0000B404 File Offset: 0x00009604
		public unsafe NetworkPipelineStage StaticInitialize(byte* staticInstanceBuffer, int staticInstanceBufferLength, NetworkSettings settings)
		{
			SimulatorUtility.Parameters simulatorStageParameters = ref settings.GetSimulatorStageParameters();
			UnsafeUtility.MemCpy((void*)staticInstanceBuffer, (void*)(&simulatorStageParameters), (long)UnsafeUtility.SizeOf<SimulatorUtility.Parameters>());
			return new NetworkPipelineStage(SimulatorPipelineStageInSend.ReceiveFunctionPointer, SimulatorPipelineStageInSend.SendFunctionPointer, SimulatorPipelineStageInSend.InitializeConnectionFunctionPointer, 0, simulatorStageParameters.MaxPacketCount * (simulatorStageParameters.MaxPacketSize + UnsafeUtility.SizeOf<SimulatorUtility.DelayedPacket>()), 0, UnsafeUtility.SizeOf<SimulatorUtility.Context>(), 0);
		}

		// Token: 0x06000207 RID: 519 RVA: 0x0000B458 File Offset: 0x00009658
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

		// Token: 0x06000208 RID: 520 RVA: 0x0000B490 File Offset: 0x00009690
		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(NetworkPipelineStage.SendDelegate))]
		private unsafe static int Send(ref NetworkPipelineContext ctx, ref InboundSendBuffer inboundBuffer, ref NetworkPipelineStage.Requests requests, int systemHeaderSize)
		{
			SimulatorUtility.Context* internalSharedProcessBuffer = (SimulatorUtility.Context*)ctx.internalSharedProcessBuffer;
			SimulatorUtility.Parameters parameters = *(SimulatorUtility.Parameters*)ctx.staticInstanceBuffer;
			SimulatorUtility simulatorUtility = new SimulatorUtility(parameters.MaxPacketCount, parameters.MaxPacketSize, parameters.PacketDelayMs, parameters.PacketJitterMs);
			if (inboundBuffer.headerPadding + inboundBuffer.bufferLength > parameters.MaxPacketSize)
			{
				return -4;
			}
			long timestamp = ctx.timestamp;
			if (inboundBuffer.bufferLength > 0)
			{
				internalSharedProcessBuffer->PacketCount++;
				if (simulatorUtility.ShouldDropPacket(internalSharedProcessBuffer, parameters, timestamp))
				{
					internalSharedProcessBuffer->PacketDropCount++;
					inboundBuffer = default(InboundSendBuffer);
					return 0;
				}
				if (internalSharedProcessBuffer->FuzzFactor > 0)
				{
					simulatorUtility.FuzzPacket(internalSharedProcessBuffer, ref inboundBuffer);
				}
				if (internalSharedProcessBuffer->PacketDelayMs == 0 || !simulatorUtility.DelayPacket(ref ctx, inboundBuffer, ref requests, timestamp))
				{
					return 0;
				}
			}
			InboundSendBuffer inboundSendBuffer = default(InboundSendBuffer);
			if (simulatorUtility.GetDelayedPacket(ref ctx, ref inboundSendBuffer, ref requests, timestamp))
			{
				inboundBuffer = inboundSendBuffer;
				return 0;
			}
			inboundBuffer = default(InboundSendBuffer);
			return 0;
		}

		// Token: 0x06000209 RID: 521 RVA: 0x00003CAF File Offset: 0x00001EAF
		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(NetworkPipelineStage.ReceiveDelegate))]
		private static void Receive(ref NetworkPipelineContext ctx, ref InboundRecvBuffer inboundBuffer, ref NetworkPipelineStage.Requests requests, int systemHeaderSize)
		{
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x0600020A RID: 522 RVA: 0x0000B3AA File Offset: 0x000095AA
		public int StaticSize
		{
			get
			{
				return UnsafeUtility.SizeOf<SimulatorUtility.Parameters>();
			}
		}

		// Token: 0x04000187 RID: 391
		private static TransportFunctionPointer<NetworkPipelineStage.ReceiveDelegate> ReceiveFunctionPointer = new TransportFunctionPointer<NetworkPipelineStage.ReceiveDelegate>(new NetworkPipelineStage.ReceiveDelegate(SimulatorPipelineStageInSend.Receive));

		// Token: 0x04000188 RID: 392
		private static TransportFunctionPointer<NetworkPipelineStage.SendDelegate> SendFunctionPointer = new TransportFunctionPointer<NetworkPipelineStage.SendDelegate>(new NetworkPipelineStage.SendDelegate(SimulatorPipelineStageInSend.Send));

		// Token: 0x04000189 RID: 393
		private static TransportFunctionPointer<NetworkPipelineStage.InitializeConnectionDelegate> InitializeConnectionFunctionPointer = new TransportFunctionPointer<NetworkPipelineStage.InitializeConnectionDelegate>(new NetworkPipelineStage.InitializeConnectionDelegate(SimulatorPipelineStageInSend.InitializeConnection));
	}
}
