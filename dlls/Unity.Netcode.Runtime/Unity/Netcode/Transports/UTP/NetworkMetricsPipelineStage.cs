using System;
using AOT;
using Unity.Burst;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Networking.Transport;

namespace Unity.Netcode.Transports.UTP
{
	// Token: 0x02000127 RID: 295
	[BurstCompile]
	internal struct NetworkMetricsPipelineStage : INetworkPipelineStage
	{
		// Token: 0x0600094B RID: 2379 RVA: 0x0002352E File Offset: 0x0002172E
		public unsafe NetworkPipelineStage StaticInitialize(byte* staticInstanceBuffer, int staticInstanceBufferLength, NetworkSettings settings)
		{
			return new NetworkPipelineStage(NetworkMetricsPipelineStage.s_ReceiveFunction, NetworkMetricsPipelineStage.s_SendFunction, NetworkMetricsPipelineStage.s_InitializeConnectionFunction, 0, 0, 0, UnsafeUtility.SizeOf<NetworkMetricsContext>(), 0);
		}

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x0600094C RID: 2380 RVA: 0x0000BEB4 File Offset: 0x0000A0B4
		public int StaticSize
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x0600094D RID: 2381 RVA: 0x00023550 File Offset: 0x00021750
		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(NetworkPipelineStage.ReceiveDelegate))]
		private unsafe static void Receive(ref NetworkPipelineContext networkPipelineContext, ref InboundRecvBuffer inboundReceiveBuffer, ref NetworkPipelineStage.Requests requests, int systemHeaderSize)
		{
			NetworkMetricsContext* internalSharedProcessBuffer = (NetworkMetricsContext*)networkPipelineContext.internalSharedProcessBuffer;
			internalSharedProcessBuffer->PacketReceivedCount += 1U;
		}

		// Token: 0x0600094E RID: 2382 RVA: 0x00023570 File Offset: 0x00021770
		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(NetworkPipelineStage.SendDelegate))]
		private unsafe static int Send(ref NetworkPipelineContext networkPipelineContext, ref InboundSendBuffer inboundSendBuffer, ref NetworkPipelineStage.Requests requests, int systemHeaderSize)
		{
			NetworkMetricsContext* internalSharedProcessBuffer = (NetworkMetricsContext*)networkPipelineContext.internalSharedProcessBuffer;
			internalSharedProcessBuffer->PacketSentCount += 1U;
			return 0;
		}

		// Token: 0x0600094F RID: 2383 RVA: 0x00023590 File Offset: 0x00021790
		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(NetworkPipelineStage.InitializeConnectionDelegate))]
		private unsafe static void InitializeConnection(byte* staticInstanceBuffer, int staticInstanceBufferLength, byte* sendProcessBuffer, int sendProcessBufferLength, byte* receiveProcessBuffer, int receiveProcessBufferLength, byte* sharedProcessBuffer, int sharedProcessBufferLength)
		{
			((NetworkMetricsContext*)sharedProcessBuffer)->PacketSentCount = 0U;
			((NetworkMetricsContext*)sharedProcessBuffer)->PacketReceivedCount = 0U;
		}

		// Token: 0x0400038E RID: 910
		private static TransportFunctionPointer<NetworkPipelineStage.ReceiveDelegate> s_ReceiveFunction = new TransportFunctionPointer<NetworkPipelineStage.ReceiveDelegate>(new NetworkPipelineStage.ReceiveDelegate(NetworkMetricsPipelineStage.Receive));

		// Token: 0x0400038F RID: 911
		private static TransportFunctionPointer<NetworkPipelineStage.SendDelegate> s_SendFunction = new TransportFunctionPointer<NetworkPipelineStage.SendDelegate>(new NetworkPipelineStage.SendDelegate(NetworkMetricsPipelineStage.Send));

		// Token: 0x04000390 RID: 912
		private static TransportFunctionPointer<NetworkPipelineStage.InitializeConnectionDelegate> s_InitializeConnectionFunction = new TransportFunctionPointer<NetworkPipelineStage.InitializeConnectionDelegate>(new NetworkPipelineStage.InitializeConnectionDelegate(NetworkMetricsPipelineStage.InitializeConnection));
	}
}
