using System;
using System.Runtime.InteropServices;

namespace Unity.Networking.Transport
{
	// Token: 0x0200004B RID: 75
	public struct NetworkPipelineStage
	{
		// Token: 0x06000188 RID: 392 RVA: 0x00008A6C File Offset: 0x00006C6C
		public NetworkPipelineStage(TransportFunctionPointer<NetworkPipelineStage.ReceiveDelegate> Receive, TransportFunctionPointer<NetworkPipelineStage.SendDelegate> Send, TransportFunctionPointer<NetworkPipelineStage.InitializeConnectionDelegate> InitializeConnection, int ReceiveCapacity, int SendCapacity, int HeaderCapacity, int SharedStateCapacity, int PayloadCapacity = 0)
		{
			this.Receive = Receive;
			this.Send = Send;
			this.InitializeConnection = InitializeConnection;
			this.ReceiveCapacity = ReceiveCapacity;
			this.SendCapacity = SendCapacity;
			this.HeaderCapacity = HeaderCapacity;
			this.SharedStateCapacity = SharedStateCapacity;
			this.PayloadCapacity = PayloadCapacity;
			this.StaticStateStart = (this.StaticStateCapcity = 0);
		}

		// Token: 0x04000102 RID: 258
		public TransportFunctionPointer<NetworkPipelineStage.ReceiveDelegate> Receive;

		// Token: 0x04000103 RID: 259
		public TransportFunctionPointer<NetworkPipelineStage.SendDelegate> Send;

		// Token: 0x04000104 RID: 260
		public TransportFunctionPointer<NetworkPipelineStage.InitializeConnectionDelegate> InitializeConnection;

		// Token: 0x04000105 RID: 261
		public readonly int ReceiveCapacity;

		// Token: 0x04000106 RID: 262
		public readonly int SendCapacity;

		// Token: 0x04000107 RID: 263
		public readonly int HeaderCapacity;

		// Token: 0x04000108 RID: 264
		public readonly int SharedStateCapacity;

		// Token: 0x04000109 RID: 265
		public readonly int PayloadCapacity;

		// Token: 0x0400010A RID: 266
		internal int StaticStateStart;

		// Token: 0x0400010B RID: 267
		internal int StaticStateCapcity;

		// Token: 0x0200004C RID: 76
		[Flags]
		public enum Requests
		{
			// Token: 0x0400010D RID: 269
			None = 0,
			// Token: 0x0400010E RID: 270
			Resume = 1,
			// Token: 0x0400010F RID: 271
			Update = 2,
			// Token: 0x04000110 RID: 272
			SendUpdate = 4,
			// Token: 0x04000111 RID: 273
			Error = 8
		}

		// Token: 0x0200004D RID: 77
		// (Invoke) Token: 0x0600018A RID: 394
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void ReceiveDelegate(ref NetworkPipelineContext ctx, ref InboundRecvBuffer inboundBuffer, ref NetworkPipelineStage.Requests requests, int systemHeadersSize);

		// Token: 0x0200004E RID: 78
		// (Invoke) Token: 0x0600018E RID: 398
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int SendDelegate(ref NetworkPipelineContext ctx, ref InboundSendBuffer inboundBuffer, ref NetworkPipelineStage.Requests requests, int systemHeadersSize);

		// Token: 0x0200004F RID: 79
		// (Invoke) Token: 0x06000192 RID: 402
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public unsafe delegate void InitializeConnectionDelegate(byte* staticInstanceBuffer, int staticInstanceBufferLength, byte* sendProcessBuffer, int sendProcessBufferLength, byte* recvProcessBuffer, int recvProcessBufferLength, byte* sharedProcessBuffer, int sharedProcessBufferLength);
	}
}
