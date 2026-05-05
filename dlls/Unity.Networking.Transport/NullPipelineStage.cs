using System;
using AOT;
using Unity.Burst;

namespace Unity.Networking.Transport
{
	// Token: 0x02000072 RID: 114
	[BurstCompile]
	public struct NullPipelineStage : INetworkPipelineStage
	{
		// Token: 0x060001F4 RID: 500 RVA: 0x00002C09 File Offset: 0x00000E09
		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(NetworkPipelineStage.SendDelegate))]
		private static int Send(ref NetworkPipelineContext ctx, ref InboundSendBuffer inboundBuffer, ref NetworkPipelineStage.Requests requests, int systemHeaderSize)
		{
			return 0;
		}

		// Token: 0x060001F5 RID: 501 RVA: 0x00003CAF File Offset: 0x00001EAF
		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(NetworkPipelineStage.ReceiveDelegate))]
		private static void Receive(ref NetworkPipelineContext ctx, ref InboundRecvBuffer inboundBuffer, ref NetworkPipelineStage.Requests requests, int systemHeaderSize)
		{
		}

		// Token: 0x060001F6 RID: 502 RVA: 0x00003CAF File Offset: 0x00001EAF
		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(NetworkPipelineStage.InitializeConnectionDelegate))]
		private unsafe static void InitializeConnection(byte* staticInstanceBuffer, int staticInstanceBufferLength, byte* sendProcessBuffer, int sendProcessBufferLength, byte* recvProcessBuffer, int recvProcessBufferLength, byte* sharedProcessBuffer, int sharedProcessBufferLength)
		{
		}

		// Token: 0x060001F7 RID: 503 RVA: 0x0000ADCB File Offset: 0x00008FCB
		public unsafe NetworkPipelineStage StaticInitialize(byte* staticInstanceBuffer, int staticInstanceBufferLength, NetworkSettings netParams)
		{
			return new NetworkPipelineStage(NullPipelineStage.ReceiveFunctionPointer, NullPipelineStage.SendFunctionPointer, NullPipelineStage.InitializeConnectionFunctionPointer, 0, 0, 0, 0, 0);
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x060001F8 RID: 504 RVA: 0x00002C09 File Offset: 0x00000E09
		public int StaticSize
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x0400017E RID: 382
		private static TransportFunctionPointer<NetworkPipelineStage.ReceiveDelegate> ReceiveFunctionPointer = new TransportFunctionPointer<NetworkPipelineStage.ReceiveDelegate>(new NetworkPipelineStage.ReceiveDelegate(NullPipelineStage.Receive));

		// Token: 0x0400017F RID: 383
		private static TransportFunctionPointer<NetworkPipelineStage.SendDelegate> SendFunctionPointer = new TransportFunctionPointer<NetworkPipelineStage.SendDelegate>(new NetworkPipelineStage.SendDelegate(NullPipelineStage.Send));

		// Token: 0x04000180 RID: 384
		private static TransportFunctionPointer<NetworkPipelineStage.InitializeConnectionDelegate> InitializeConnectionFunctionPointer = new TransportFunctionPointer<NetworkPipelineStage.InitializeConnectionDelegate>(new NetworkPipelineStage.InitializeConnectionDelegate(NullPipelineStage.InitializeConnection));
	}
}
