using System;
using AOT;
using Unity.Burst;
using Unity.Networking.Transport.Protocols;
using UnityEngine;

namespace Unity.Networking.Transport
{
	// Token: 0x0200007E RID: 126
	[BurstCompile]
	internal struct UnityTransportProtocol : INetworkProtocol, IDisposable
	{
		// Token: 0x0600022A RID: 554 RVA: 0x00003CAF File Offset: 0x00001EAF
		public void Initialize(NetworkSettings settings)
		{
		}

		// Token: 0x0600022B RID: 555 RVA: 0x00003CAF File Offset: 0x00001EAF
		public void Dispose()
		{
		}

		// Token: 0x0600022C RID: 556 RVA: 0x0000BCCE File Offset: 0x00009ECE
		public int Bind(INetworkInterface networkInterface, ref NetworkInterfaceEndPoint localEndPoint)
		{
			if (networkInterface.Bind(localEndPoint) != 0)
			{
				return -1;
			}
			return 0;
		}

		// Token: 0x0600022D RID: 557 RVA: 0x0000BCE1 File Offset: 0x00009EE1
		public int CreateConnectionAddress(INetworkInterface networkInterface, NetworkEndPoint remoteEndpoint, out NetworkInterfaceEndPoint remoteAddress)
		{
			remoteAddress = default(NetworkInterfaceEndPoint);
			return networkInterface.CreateInterfaceEndPoint(remoteEndpoint, out remoteAddress);
		}

		// Token: 0x0600022E RID: 558 RVA: 0x0000BCF2 File Offset: 0x00009EF2
		public NetworkEndPoint GetRemoteEndPoint(INetworkInterface networkInterface, NetworkInterfaceEndPoint address)
		{
			return networkInterface.GetGenericEndPoint(address);
		}

		// Token: 0x0600022F RID: 559 RVA: 0x0000BCFC File Offset: 0x00009EFC
		public NetworkProtocol CreateProtocolInterface()
		{
			return new NetworkProtocol(new TransportFunctionPointer<NetworkProtocol.ComputePacketOverheadDelegate>(new NetworkProtocol.ComputePacketOverheadDelegate(UnityTransportProtocol.ComputePacketOverhead)), new TransportFunctionPointer<NetworkProtocol.ProcessReceiveDelegate>(new NetworkProtocol.ProcessReceiveDelegate(UnityTransportProtocol.ProcessReceive)), new TransportFunctionPointer<NetworkProtocol.ProcessSendDelegate>(new NetworkProtocol.ProcessSendDelegate(UnityTransportProtocol.ProcessSend)), new TransportFunctionPointer<NetworkProtocol.ProcessSendConnectionAcceptDelegate>(new NetworkProtocol.ProcessSendConnectionAcceptDelegate(UnityTransportProtocol.ProcessSendConnectionAccept)), new TransportFunctionPointer<NetworkProtocol.ConnectDelegate>(new NetworkProtocol.ConnectDelegate(UnityTransportProtocol.Connect)), new TransportFunctionPointer<NetworkProtocol.DisconnectDelegate>(new NetworkProtocol.DisconnectDelegate(UnityTransportProtocol.Disconnect)), new TransportFunctionPointer<NetworkProtocol.ProcessSendPingDelegate>(new NetworkProtocol.ProcessSendPingDelegate(UnityTransportProtocol.ProcessSendPing)), new TransportFunctionPointer<NetworkProtocol.ProcessSendPongDelegate>(new NetworkProtocol.ProcessSendPongDelegate(UnityTransportProtocol.ProcessSendPong)), new TransportFunctionPointer<NetworkProtocol.UpdateDelegate>(new NetworkProtocol.UpdateDelegate(UnityTransportProtocol.Update)), false, IntPtr.Zero, 10, 8);
		}

		// Token: 0x06000230 RID: 560 RVA: 0x0000BDB0 File Offset: 0x00009FB0
		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(NetworkProtocol.ComputePacketOverheadDelegate))]
		public static int ComputePacketOverhead(ref NetworkDriver.Connection connection, out int dataOffset)
		{
			dataOffset = 10;
			int num = (connection.DidReceiveData == 0) ? 8 : 0;
			return dataOffset + num;
		}

		// Token: 0x06000231 RID: 561 RVA: 0x0000BDD4 File Offset: 0x00009FD4
		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(NetworkProtocol.ProcessReceiveDelegate))]
		public unsafe static void ProcessReceive(IntPtr stream, ref NetworkInterfaceEndPoint endpoint, int size, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IntPtr userData, ref ProcessPacketCommand command)
		{
			byte* ptr = (byte*)((void*)stream);
			UdpCHeader udpCHeader = *(UdpCHeader*)ptr;
			if (size < 10)
			{
				Debug.LogError("Received an invalid message header");
				command.Type = ProcessPacketCommandType.Drop;
				return;
			}
			UdpCProtocol type = (UdpCProtocol)udpCHeader.Type;
			command.Address = endpoint;
			command.SessionId = udpCHeader.SessionToken;
			if (type != UdpCProtocol.Data && (udpCHeader.Flags & UdpCHeader.HeaderFlags.HasPipeline) != (UdpCHeader.HeaderFlags)0)
			{
				Debug.LogError("Received an invalid non-data message with a pipeline");
				command.Type = ProcessPacketCommandType.Drop;
				return;
			}
			switch (type)
			{
			case UdpCProtocol.ConnectionRequest:
				command.Type = ProcessPacketCommandType.ConnectionRequest;
				return;
			case UdpCProtocol.ConnectionReject:
				command.Type = ProcessPacketCommandType.ConnectionReject;
				return;
			case UdpCProtocol.ConnectionAccept:
				if ((udpCHeader.Flags & UdpCHeader.HeaderFlags.HasConnectToken) == (UdpCHeader.HeaderFlags)0)
				{
					Debug.LogError("Received an invalid ConnectionAccept without a token");
					command.Type = ProcessPacketCommandType.Drop;
					return;
				}
				if (size != 18)
				{
					Debug.LogError("Received an invalid ConnectionAccept with wrong length");
					command.Type = ProcessPacketCommandType.Drop;
					return;
				}
				command.Type = ProcessPacketCommandType.ConnectionAccept;
				command.As.ConnectionAccept.ConnectionToken = *(SessionIdToken*)((void*)(stream + 10));
				return;
			case UdpCProtocol.Disconnect:
				command.Type = ProcessPacketCommandType.Disconnect;
				return;
			case UdpCProtocol.Data:
			{
				int num = size - 10;
				byte hasPipelineByte = ((udpCHeader.Flags & UdpCHeader.HeaderFlags.HasPipeline) != (UdpCHeader.HeaderFlags)0) ? 1 : 0;
				if ((udpCHeader.Flags & UdpCHeader.HeaderFlags.HasConnectToken) > (UdpCHeader.HeaderFlags)0)
				{
					num -= 8;
					command.Type = ProcessPacketCommandType.DataWithImplicitConnectionAccept;
					command.As.DataWithImplicitConnectionAccept.Offset = 10;
					command.As.DataWithImplicitConnectionAccept.Length = num;
					command.As.DataWithImplicitConnectionAccept.HasPipelineByte = hasPipelineByte;
					command.As.DataWithImplicitConnectionAccept.ConnectionToken = *(SessionIdToken*)((void*)(stream + 10 + num));
					return;
				}
				command.Type = ProcessPacketCommandType.Data;
				command.As.Data.Offset = 10;
				command.As.Data.Length = num;
				command.As.Data.HasPipelineByte = hasPipelineByte;
				return;
			}
			case UdpCProtocol.Ping:
				command.Type = ProcessPacketCommandType.Ping;
				return;
			case UdpCProtocol.Pong:
				command.Type = ProcessPacketCommandType.Pong;
				return;
			default:
				command.Type = ProcessPacketCommandType.Drop;
				return;
			}
		}

		// Token: 0x06000232 RID: 562 RVA: 0x0000BFD8 File Offset: 0x0000A1D8
		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(NetworkProtocol.ProcessSendDelegate))]
		public static int ProcessSend(ref NetworkDriver.Connection connection, bool hasPipeline, ref NetworkSendInterface sendInterface, ref NetworkInterfaceSendHandle sendHandle, ref NetworkSendQueueHandle queueHandle, IntPtr userData)
		{
			UnityTransportProtocol.WriteSendMessageHeader(ref connection, hasPipeline, ref sendHandle, 0);
			return sendInterface.EndSendMessage.Ptr.Invoke(ref sendHandle, ref connection.Address, sendInterface.UserData, ref queueHandle);
		}

		// Token: 0x06000233 RID: 563 RVA: 0x0000C008 File Offset: 0x0000A208
		internal unsafe static int WriteSendMessageHeader(ref NetworkDriver.Connection connection, bool hasPipeline, ref NetworkInterfaceSendHandle sendHandle, int offset)
		{
			UdpCHeader.HeaderFlags headerFlags = (UdpCHeader.HeaderFlags)0;
			if (connection.DidReceiveData == 0)
			{
				headerFlags |= UdpCHeader.HeaderFlags.HasConnectToken;
				SessionIdToken* ptr = (SessionIdToken*)((byte*)((void*)sendHandle.data) + sendHandle.size);
				*ptr = connection.ReceiveToken;
				sendHandle.size += 8;
			}
			if (hasPipeline)
			{
				headerFlags |= UdpCHeader.HeaderFlags.HasPipeline;
			}
			UdpCHeader* ptr2 = (UdpCHeader*)((void*)(sendHandle.data + offset));
			*ptr2 = new UdpCHeader
			{
				Type = 4,
				SessionToken = connection.SendToken,
				Flags = headerFlags
			};
			return sendHandle.size - offset;
		}

		// Token: 0x06000234 RID: 564 RVA: 0x0000C09C File Offset: 0x0000A29C
		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(NetworkProtocol.ProcessSendConnectionAcceptDelegate))]
		public unsafe static void ProcessSendConnectionAccept(ref NetworkDriver.Connection connection, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IntPtr userData)
		{
			NetworkInterfaceSendHandle networkInterfaceSendHandle;
			if (sendInterface.BeginSendMessage.Ptr.Invoke(out networkInterfaceSendHandle, sendInterface.UserData, 18) != 0)
			{
				Debug.LogError("Failed to send a ConnectionAccept packet");
				return;
			}
			byte* packet = (byte*)((void*)networkInterfaceSendHandle.data);
			int num = UnityTransportProtocol.WriteConnectionAcceptMessage(ref connection, packet, networkInterfaceSendHandle.capacity);
			if (num < 0)
			{
				sendInterface.AbortSendMessage.Ptr.Invoke(ref networkInterfaceSendHandle, sendInterface.UserData);
				Debug.LogError("Failed to send a ConnectionAccept packet");
				return;
			}
			networkInterfaceSendHandle.size = num;
			if (sendInterface.EndSendMessage.Ptr.Invoke(ref networkInterfaceSendHandle, ref connection.Address, sendInterface.UserData, ref queueHandle) < 0)
			{
				Debug.LogError("Failed to send a ConnectionAccept packet");
				return;
			}
		}

		// Token: 0x06000235 RID: 565 RVA: 0x0000C155 File Offset: 0x0000A355
		internal static int GetConnectionAcceptMessageMaxLength()
		{
			return 18;
		}

		// Token: 0x06000236 RID: 566 RVA: 0x0000C15C File Offset: 0x0000A35C
		internal unsafe static int WriteConnectionAcceptMessage(ref NetworkDriver.Connection connection, byte* packet, int capacity)
		{
			int num = 10;
			if (connection.DidReceiveData == 0)
			{
				num += 8;
			}
			if (num > capacity)
			{
				Debug.LogError("Failed to create a ConnectionAccept packet: size exceeds capacity");
				return -1;
			}
			*(UdpCHeader*)packet = new UdpCHeader
			{
				Type = 2,
				SessionToken = connection.SendToken,
				Flags = (UdpCHeader.HeaderFlags)0
			};
			if (connection.DidReceiveData == 0)
			{
				((UdpCHeader*)packet)->Flags = (((UdpCHeader*)packet)->Flags | UdpCHeader.HeaderFlags.HasConnectToken);
				*(SessionIdToken*)(packet + 10) = connection.ReceiveToken;
			}
			return num;
		}

		// Token: 0x06000237 RID: 567 RVA: 0x0000C1DC File Offset: 0x0000A3DC
		private unsafe static int SendHeaderOnlyMessage(UdpCProtocol type, SessionIdToken token, ref NetworkDriver.Connection connection, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle)
		{
			NetworkInterfaceSendHandle networkInterfaceSendHandle;
			if (sendInterface.BeginSendMessage.Ptr.Invoke(out networkInterfaceSendHandle, sendInterface.UserData, 10) != 0)
			{
				return -1;
			}
			byte* ptr = (byte*)((void*)networkInterfaceSendHandle.data);
			networkInterfaceSendHandle.size = 10;
			if (networkInterfaceSendHandle.size > networkInterfaceSendHandle.capacity)
			{
				sendInterface.AbortSendMessage.Ptr.Invoke(ref networkInterfaceSendHandle, sendInterface.UserData);
				return -1;
			}
			UdpCHeader* ptr2 = (UdpCHeader*)ptr;
			*ptr2 = new UdpCHeader
			{
				Type = (byte)type,
				SessionToken = token,
				Flags = (UdpCHeader.HeaderFlags)0
			};
			if (sendInterface.EndSendMessage.Ptr.Invoke(ref networkInterfaceSendHandle, ref connection.Address, sendInterface.UserData, ref queueHandle) < 0)
			{
				return -1;
			}
			return 10;
		}

		// Token: 0x06000238 RID: 568 RVA: 0x0000C2A4 File Offset: 0x0000A4A4
		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(NetworkProtocol.ConnectDelegate))]
		public static void Connect(ref NetworkDriver.Connection connection, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IntPtr userData)
		{
			UdpCProtocol type = UdpCProtocol.ConnectionRequest;
			SessionIdToken receiveToken = connection.ReceiveToken;
			if (UnityTransportProtocol.SendHeaderOnlyMessage(type, receiveToken, ref connection, ref sendInterface, ref queueHandle) == -1)
			{
				Debug.LogError("Failed to send ConnectionRequest message");
			}
		}

		// Token: 0x06000239 RID: 569 RVA: 0x0000C2D0 File Offset: 0x0000A4D0
		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(NetworkProtocol.DisconnectDelegate))]
		public static void Disconnect(ref NetworkDriver.Connection connection, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IntPtr userData)
		{
			UdpCProtocol type = UdpCProtocol.Disconnect;
			SessionIdToken sendToken = connection.SendToken;
			if (UnityTransportProtocol.SendHeaderOnlyMessage(type, sendToken, ref connection, ref sendInterface, ref queueHandle) == -1)
			{
				Debug.LogError("Failed to send Disconnect message");
			}
		}

		// Token: 0x0600023A RID: 570 RVA: 0x0000C2FC File Offset: 0x0000A4FC
		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(NetworkProtocol.ProcessSendPingDelegate))]
		public static void ProcessSendPing(ref NetworkDriver.Connection connection, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IntPtr userData)
		{
			UdpCProtocol type = UdpCProtocol.Ping;
			SessionIdToken sendToken = connection.SendToken;
			if (UnityTransportProtocol.SendHeaderOnlyMessage(type, sendToken, ref connection, ref sendInterface, ref queueHandle) == -1)
			{
				Debug.LogError("Failed to send Ping message");
			}
		}

		// Token: 0x0600023B RID: 571 RVA: 0x0000C328 File Offset: 0x0000A528
		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(NetworkProtocol.ProcessSendPongDelegate))]
		public static void ProcessSendPong(ref NetworkDriver.Connection connection, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IntPtr userData)
		{
			UdpCProtocol type = UdpCProtocol.Pong;
			SessionIdToken sendToken = connection.SendToken;
			if (UnityTransportProtocol.SendHeaderOnlyMessage(type, sendToken, ref connection, ref sendInterface, ref queueHandle) == -1)
			{
				Debug.LogError("Failed to send Pong message");
			}
		}

		// Token: 0x0600023C RID: 572 RVA: 0x00003CAF File Offset: 0x00001EAF
		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(NetworkProtocol.UpdateDelegate))]
		public static void Update(long updateTime, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IntPtr userData)
		{
		}
	}
}
