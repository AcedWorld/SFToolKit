using System;
using System.Runtime.InteropServices;
using Unity.Collections.LowLevel.Unsafe;

namespace Unity.Networking.Transport
{
	// Token: 0x0200005A RID: 90
	internal struct NetworkProtocol
	{
		// Token: 0x17000033 RID: 51
		// (get) Token: 0x060001BD RID: 445 RVA: 0x0000A584 File Offset: 0x00008784
		public int PaddingSize
		{
			get
			{
				return this.MaxHeaderSize + this.MaxFooterSize;
			}
		}

		// Token: 0x060001BE RID: 446 RVA: 0x0000A594 File Offset: 0x00008794
		public NetworkProtocol(TransportFunctionPointer<NetworkProtocol.ComputePacketOverheadDelegate> computePacketOverhead, TransportFunctionPointer<NetworkProtocol.ProcessReceiveDelegate> processReceive, TransportFunctionPointer<NetworkProtocol.ProcessSendDelegate> processSend, TransportFunctionPointer<NetworkProtocol.ProcessSendConnectionAcceptDelegate> processSendConnectionAccept, TransportFunctionPointer<NetworkProtocol.ConnectDelegate> connect, TransportFunctionPointer<NetworkProtocol.DisconnectDelegate> disconnect, TransportFunctionPointer<NetworkProtocol.ProcessSendPingDelegate> processSendPing, TransportFunctionPointer<NetworkProtocol.ProcessSendPongDelegate> processSendPong, TransportFunctionPointer<NetworkProtocol.UpdateDelegate> update, bool needsUpdate, IntPtr userData, int maxHeaderSize, int maxFooterSize)
		{
			this.ComputePacketOverhead = computePacketOverhead;
			this.ProcessReceive = processReceive;
			this.ProcessSend = processSend;
			this.ProcessSendConnectionAccept = processSendConnectionAccept;
			this.Connect = connect;
			this.Disconnect = disconnect;
			this.ProcessSendPing = processSendPing;
			this.ProcessSendPong = processSendPong;
			this.Update = update;
			this.NeedsUpdate = needsUpdate;
			this.UserData = userData;
			this.MaxHeaderSize = maxHeaderSize;
			this.MaxFooterSize = maxFooterSize;
		}

		// Token: 0x0400013E RID: 318
		public TransportFunctionPointer<NetworkProtocol.ComputePacketOverheadDelegate> ComputePacketOverhead;

		// Token: 0x0400013F RID: 319
		public TransportFunctionPointer<NetworkProtocol.ProcessReceiveDelegate> ProcessReceive;

		// Token: 0x04000140 RID: 320
		public TransportFunctionPointer<NetworkProtocol.ProcessSendDelegate> ProcessSend;

		// Token: 0x04000141 RID: 321
		public TransportFunctionPointer<NetworkProtocol.ProcessSendConnectionAcceptDelegate> ProcessSendConnectionAccept;

		// Token: 0x04000142 RID: 322
		public TransportFunctionPointer<NetworkProtocol.ConnectDelegate> Connect;

		// Token: 0x04000143 RID: 323
		public TransportFunctionPointer<NetworkProtocol.DisconnectDelegate> Disconnect;

		// Token: 0x04000144 RID: 324
		public TransportFunctionPointer<NetworkProtocol.ProcessSendPingDelegate> ProcessSendPing;

		// Token: 0x04000145 RID: 325
		public TransportFunctionPointer<NetworkProtocol.ProcessSendPongDelegate> ProcessSendPong;

		// Token: 0x04000146 RID: 326
		public TransportFunctionPointer<NetworkProtocol.UpdateDelegate> Update;

		// Token: 0x04000147 RID: 327
		[NativeDisableUnsafePtrRestriction]
		public IntPtr UserData;

		// Token: 0x04000148 RID: 328
		public int MaxHeaderSize;

		// Token: 0x04000149 RID: 329
		public int MaxFooterSize;

		// Token: 0x0400014A RID: 330
		public bool NeedsUpdate;

		// Token: 0x0200005B RID: 91
		// (Invoke) Token: 0x060001C0 RID: 448
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int ComputePacketOverheadDelegate(ref NetworkDriver.Connection connection, out int payloadOffset);

		// Token: 0x0200005C RID: 92
		// (Invoke) Token: 0x060001C4 RID: 452
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void ProcessReceiveDelegate(IntPtr stream, ref NetworkInterfaceEndPoint address, int size, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IntPtr userData, ref ProcessPacketCommand command);

		// Token: 0x0200005D RID: 93
		// (Invoke) Token: 0x060001C8 RID: 456
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int ProcessSendDelegate(ref NetworkDriver.Connection connection, bool hasPipeline, ref NetworkSendInterface sendInterface, ref NetworkInterfaceSendHandle sendHandle, ref NetworkSendQueueHandle queueHandle, IntPtr userData);

		// Token: 0x0200005E RID: 94
		// (Invoke) Token: 0x060001CC RID: 460
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void ProcessSendConnectionAcceptDelegate(ref NetworkDriver.Connection connection, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IntPtr userData);

		// Token: 0x0200005F RID: 95
		// (Invoke) Token: 0x060001D0 RID: 464
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void ConnectDelegate(ref NetworkDriver.Connection connection, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IntPtr userData);

		// Token: 0x02000060 RID: 96
		// (Invoke) Token: 0x060001D4 RID: 468
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void DisconnectDelegate(ref NetworkDriver.Connection connection, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IntPtr userData);

		// Token: 0x02000061 RID: 97
		// (Invoke) Token: 0x060001D8 RID: 472
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void ProcessSendPingDelegate(ref NetworkDriver.Connection connection, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IntPtr userData);

		// Token: 0x02000062 RID: 98
		// (Invoke) Token: 0x060001DC RID: 476
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void ProcessSendPongDelegate(ref NetworkDriver.Connection connection, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IntPtr userData);

		// Token: 0x02000063 RID: 99
		// (Invoke) Token: 0x060001E0 RID: 480
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void UpdateDelegate(long updateTime, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IntPtr userData);
	}
}
