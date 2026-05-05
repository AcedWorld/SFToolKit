using System;
using System.Threading;
using AOT;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Networking.Transport.Protocols;
using Unity.Networking.Transport.TLS;
using Unity.TLS.LowLevel;
using UnityEngine;

namespace Unity.Networking.Transport.Relay
{
	// Token: 0x0200009D RID: 157
	[BurstCompile]
	internal struct RelayNetworkProtocol : INetworkProtocol, IDisposable
	{
		// Token: 0x0600028A RID: 650 RVA: 0x0000DF6C File Offset: 0x0000C16C
		public static ushort SwitchEndianness(ushort value)
		{
			if (DataStreamWriter.IsLittleEndian)
			{
				return (ushort)((int)value << 8 | value >> 8);
			}
			return value;
		}

		// Token: 0x0600028B RID: 651 RVA: 0x0000DF80 File Offset: 0x0000C180
		public unsafe void Initialize(NetworkSettings settings)
		{
			RelayNetworkParameter relayParameters = ref settings.GetRelayParameters();
			NetworkConfigParameter networkConfigParameters = ref settings.GetNetworkConfigParameters();
			if (relayParameters.ServerData.IsSecure == 1)
			{
				ManagedSecureFunctions.Initialize();
			}
			this.UserData = (IntPtr)UnsafeUtility.Malloc((long)UnsafeUtility.SizeOf<RelayNetworkProtocol.RelayProtocolData>(), UnsafeUtility.AlignOf<RelayNetworkProtocol.RelayProtocolData>(), Allocator.Persistent);
			*(RelayNetworkProtocol.RelayProtocolData*)((void*)this.UserData) = new RelayNetworkProtocol.RelayProtocolData
			{
				ServerData = relayParameters.ServerData,
				ConnectionState = RelayNetworkProtocol.RelayConnectionState.Unbound,
				ConnectTimeoutMS = networkConfigParameters.connectTimeoutMS,
				RelayConnectionTimeMS = relayParameters.RelayConnectionTimeMS,
				SecureState = RelayNetworkProtocol.SecuredRelayConnectionState.Unsecure
			};
		}

		// Token: 0x0600028C RID: 652 RVA: 0x0000E01C File Offset: 0x0000C21C
		public unsafe void Dispose()
		{
			RelayNetworkProtocol.RelayProtocolData* ptr = (RelayNetworkProtocol.RelayProtocolData*)((void*)this.UserData);
			if (ptr->SecureClientState.ClientPtr != null)
			{
				SecureNetworkProtocol.DisposeSecureClient(ref ptr->SecureClientState);
			}
			if (this.UserData != (IntPtr)0)
			{
				UnsafeUtility.Free(this.UserData.ToPointer(), Allocator.Persistent);
			}
			this.UserData = 0;
		}

		// Token: 0x0600028D RID: 653 RVA: 0x0000E07C File Offset: 0x0000C27C
		private bool TryExtractParameters<T>(out T config, params INetworkParameter[] param)
		{
			for (int i = 0; i < param.Length; i++)
			{
				if (param[i] is T)
				{
					config = (T)((object)param[i]);
					return true;
				}
			}
			config = default(T);
			return false;
		}

		// Token: 0x0600028E RID: 654 RVA: 0x0000E0BC File Offset: 0x0000C2BC
		public unsafe int Bind(INetworkInterface networkInterface, ref NetworkInterfaceEndPoint localEndPoint)
		{
			if (networkInterface.Bind(localEndPoint) != 0)
			{
				return -1;
			}
			RelayNetworkProtocol.RelayProtocolData* ptr = (RelayNetworkProtocol.RelayProtocolData*)((void*)this.UserData);
			networkInterface.CreateInterfaceEndPoint(ptr->ServerData.Endpoint, out ptr->ServerEndpoint);
			if (ptr->ServerData.IsSecure == 1)
			{
				ptr->ConnectionState = RelayNetworkProtocol.RelayConnectionState.Handshake;
			}
			else
			{
				ptr->ConnectionState = RelayNetworkProtocol.RelayConnectionState.Binding;
			}
			return 0;
		}

		// Token: 0x0600028F RID: 655 RVA: 0x0000E11C File Offset: 0x0000C31C
		public unsafe int CreateConnectionAddress(INetworkInterface networkInterface, NetworkEndPoint endPoint, out NetworkInterfaceEndPoint address)
		{
			RelayNetworkProtocol.RelayProtocolData* ptr = (RelayNetworkProtocol.RelayProtocolData*)((void*)this.UserData);
			address = default(NetworkInterfaceEndPoint);
			fixed (byte* ptr2 = &address.data.FixedElementField)
			{
				*(RelayAllocationId*)ptr2 = ptr->HostAllocationId;
			}
			return 0;
		}

		// Token: 0x06000290 RID: 656 RVA: 0x0000E15C File Offset: 0x0000C35C
		public unsafe NetworkEndPoint GetRemoteEndPoint(INetworkInterface networkInterface, NetworkInterfaceEndPoint address)
		{
			RelayNetworkProtocol.RelayProtocolData* ptr = (RelayNetworkProtocol.RelayProtocolData*)((void*)this.UserData);
			return networkInterface.GetGenericEndPoint(ptr->ServerEndpoint);
		}

		// Token: 0x06000291 RID: 657 RVA: 0x0000E184 File Offset: 0x0000C384
		public NetworkProtocol CreateProtocolInterface()
		{
			return new NetworkProtocol(new TransportFunctionPointer<NetworkProtocol.ComputePacketOverheadDelegate>(new NetworkProtocol.ComputePacketOverheadDelegate(RelayNetworkProtocol.ComputePacketOverhead)), new TransportFunctionPointer<NetworkProtocol.ProcessReceiveDelegate>(new NetworkProtocol.ProcessReceiveDelegate(RelayNetworkProtocol.ProcessReceive)), new TransportFunctionPointer<NetworkProtocol.ProcessSendDelegate>(new NetworkProtocol.ProcessSendDelegate(RelayNetworkProtocol.ProcessSend)), new TransportFunctionPointer<NetworkProtocol.ProcessSendConnectionAcceptDelegate>(new NetworkProtocol.ProcessSendConnectionAcceptDelegate(RelayNetworkProtocol.ProcessSendConnectionAccept)), new TransportFunctionPointer<NetworkProtocol.ConnectDelegate>(new NetworkProtocol.ConnectDelegate(RelayNetworkProtocol.Connect)), new TransportFunctionPointer<NetworkProtocol.DisconnectDelegate>(new NetworkProtocol.DisconnectDelegate(RelayNetworkProtocol.Disconnect)), new TransportFunctionPointer<NetworkProtocol.ProcessSendPingDelegate>(new NetworkProtocol.ProcessSendPingDelegate(RelayNetworkProtocol.ProcessSendPing)), new TransportFunctionPointer<NetworkProtocol.ProcessSendPongDelegate>(new NetworkProtocol.ProcessSendPongDelegate(RelayNetworkProtocol.ProcessSendPong)), new TransportFunctionPointer<NetworkProtocol.UpdateDelegate>(new NetworkProtocol.UpdateDelegate(RelayNetworkProtocol.Update)), true, this.UserData, 48, 8);
		}

		// Token: 0x06000292 RID: 658 RVA: 0x0000E239 File Offset: 0x0000C439
		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(NetworkProtocol.ComputePacketOverheadDelegate))]
		public static int ComputePacketOverhead(ref NetworkDriver.Connection connection, out int dataOffset)
		{
			int num = UnityTransportProtocol.ComputePacketOverhead(ref connection, out dataOffset);
			dataOffset += 38;
			return num + 38;
		}

		// Token: 0x06000293 RID: 659 RVA: 0x0000E24C File Offset: 0x0000C44C
		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(NetworkProtocol.ProcessReceiveDelegate))]
		public unsafe static void ProcessReceive(IntPtr stream, ref NetworkInterfaceEndPoint endpoint, int size, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IntPtr userData, ref ProcessPacketCommand command)
		{
			RelayNetworkProtocol.RelayProtocolData* ptr = (RelayNetworkProtocol.RelayProtocolData*)((void*)userData);
			if (endpoint != ptr->ServerEndpoint)
			{
				command.Type = ProcessPacketCommandType.Drop;
				return;
			}
			if (ptr->ConnectionState == RelayNetworkProtocol.RelayConnectionState.Handshake)
			{
				SecureUserData* ptr2 = (SecureUserData*)((void*)ptr->SecureClientState.ClientConfig->transportUserData);
				SecureNetworkProtocol.SetSecureUserData(stream, size, ref endpoint, ref sendInterface, ref queueHandle, ptr2);
				uint num = Binding.unitytls_client_get_state(ptr->SecureClientState.ClientPtr);
				if (num == 2U || num == 1U)
				{
					do
					{
						SecureNetworkProtocol.SecureHandshakeStep(ref ptr->SecureClientState);
						num = Binding.unitytls_client_get_state(ptr->SecureClientState.ClientPtr);
					}
					while (size != 0 && ptr2->BytesProcessed == 0 && num == 2U);
				}
				if (num == 3U)
				{
					ptr->ConnectionState = RelayNetworkProtocol.RelayConnectionState.Binding;
					ptr->SecureState = RelayNetworkProtocol.SecuredRelayConnectionState.Secured;
				}
				command.Type = ProcessPacketCommandType.Drop;
				return;
			}
			if (ptr->ServerData.IsSecure == 1 && ptr->SecureState != RelayNetworkProtocol.SecuredRelayConnectionState.Secured)
			{
				command.Type = ProcessPacketCommandType.Drop;
				return;
			}
			if (ptr->ServerData.IsSecure == 1 && ptr->SecureState == RelayNetworkProtocol.SecuredRelayConnectionState.Secured)
			{
				SecureUserData* secureUserData = (SecureUserData*)((void*)ptr->SecureClientState.ClientConfig->transportUserData);
				SecureNetworkProtocol.SetSecureUserData(stream, size, ref endpoint, ref sendInterface, ref queueHandle, secureUserData);
				NativeArray<byte> nativeArray = new NativeArray<byte>(1472, Allocator.Temp, NativeArrayOptions.ClearMemory);
				UIntPtr uintPtr = 0;
				if (Binding.unitytls_client_read_data(ptr->SecureClientState.ClientPtr, (byte*)nativeArray.GetUnsafePtr<byte>(), new UIntPtr(1472U), &uintPtr) == 0U)
				{
					UnsafeUtility.MemCpy((void*)stream, nativeArray.GetUnsafePtr<byte>(), (long)((ulong)uintPtr.ToUInt32()));
					if (RelayNetworkProtocol.ProcessRelayData(stream, ref endpoint, (int)uintPtr.ToUInt32(), ref sendInterface, ref queueHandle, ref command, ptr))
					{
						return;
					}
				}
				command.Type = ProcessPacketCommandType.Drop;
				return;
			}
			if (RelayNetworkProtocol.ProcessRelayData(stream, ref endpoint, size, ref sendInterface, ref queueHandle, ref command, ptr))
			{
				return;
			}
			command.Type = ProcessPacketCommandType.Drop;
		}

		// Token: 0x06000294 RID: 660 RVA: 0x0000E404 File Offset: 0x0000C604
		private unsafe static bool ProcessRelayData(IntPtr stream, ref NetworkInterfaceEndPoint endpoint, int size, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, ref ProcessPacketCommand command, RelayNetworkProtocol.RelayProtocolData* protocolData)
		{
			byte* ptr = (byte*)((void*)stream);
			RelayMessageHeader relayMessageHeader = *(RelayMessageHeader*)ptr;
			if (size < 4 || !relayMessageHeader.IsValid())
			{
				command.Type = ProcessPacketCommandType.Drop;
				return true;
			}
			if (protocolData->ServerData.IsSecure == 1 && protocolData->SecureState == RelayNetworkProtocol.SecuredRelayConnectionState.Secured)
			{
				SecureUserData* secureUserData = (SecureUserData*)((void*)protocolData->SecureClientState.ClientConfig->transportUserData);
				SecureNetworkProtocol.SetSecureUserData(stream, size, ref endpoint, ref sendInterface, ref queueHandle, secureUserData);
			}
			protocolData->LastReceiveTime = protocolData->LastUpdateTime;
			RelayMessageType type = relayMessageHeader.Type;
			if (type <= RelayMessageType.Accepted)
			{
				if (type != RelayMessageType.BindReceived)
				{
					if (type == RelayMessageType.Accepted)
					{
						command.Type = ProcessPacketCommandType.Drop;
						if (size != 36)
						{
							Debug.LogError("Received an invalid Relay Accepted message: Wrong length");
							return true;
						}
						if (protocolData->HostAllocationId != default(RelayAllocationId))
						{
							return true;
						}
						RelayMessageAccepted relayMessageAccepted = *(RelayMessageAccepted*)ptr;
						protocolData->HostAllocationId = relayMessageAccepted.FromAllocationId;
						command.Type = ProcessPacketCommandType.AddressUpdate;
						command.Address = default(NetworkInterfaceEndPoint);
						command.SessionId = protocolData->ConnectionReceiveToken;
						command.As.AddressUpdate.NewAddress = default(NetworkInterfaceEndPoint);
						fixed (byte* ptr2 = &command.As.AddressUpdate.NewAddress.data.FixedElementField)
						{
							*(RelayAllocationId*)ptr2 = relayMessageAccepted.FromAllocationId;
						}
						UdpCProtocol type2 = UdpCProtocol.ConnectionRequest;
						SessionIdToken connectionReceiveToken = protocolData->ConnectionReceiveToken;
						if (RelayNetworkProtocol.SendHeaderOnlyHostMessage(type2, connectionReceiveToken, protocolData, ref relayMessageAccepted.FromAllocationId, ref sendInterface, ref queueHandle) < 0)
						{
							Debug.LogError("Failed to send Connection Request message to host.");
							return false;
						}
						return true;
					}
				}
				else
				{
					command.Type = ProcessPacketCommandType.Drop;
					if (size != 4)
					{
						Debug.LogError("Received an invalid Relay Bind Received message: Wrong length");
						return true;
					}
					protocolData->ConnectionState = RelayNetworkProtocol.RelayConnectionState.Bound;
					if (protocolData->ConnectOnBind)
					{
						RelayNetworkProtocol.SendConnectionRequestToRelay(protocolData, ref sendInterface, ref queueHandle);
					}
					command.Type = ProcessPacketCommandType.ProtocolStatusUpdate;
					command.As.ProtocolStatusUpdate.Status = 1;
					return true;
				}
			}
			else if (type != RelayMessageType.Relay)
			{
				if (type == RelayMessageType.Error)
				{
					command.Type = ProcessPacketCommandType.Drop;
					RelayNetworkProtocol.ProcessRelayError(ptr, size, ref command);
					return true;
				}
			}
			else
			{
				RelayMessageRelay relayMessageRelay = *(RelayMessageRelay*)ptr;
				relayMessageRelay.DataLength = RelayNetworkProtocol.SwitchEndianness(relayMessageRelay.DataLength);
				if (size < 38 || size != (int)(38 + relayMessageRelay.DataLength))
				{
					Debug.LogError("Received an invalid Relay Received message: Wrong length");
					command.Type = ProcessPacketCommandType.Drop;
					return true;
				}
				UnityTransportProtocol.ProcessReceive(stream + 38, ref endpoint, size - 38, ref sendInterface, ref queueHandle, IntPtr.Zero, ref command);
				switch (command.Type)
				{
				case ProcessPacketCommandType.ConnectionAccept:
					protocolData->ConnectionState = RelayNetworkProtocol.RelayConnectionState.Connected;
					break;
				case ProcessPacketCommandType.Data:
					command.As.Data.Offset = command.As.Data.Offset + 38;
					break;
				case ProcessPacketCommandType.Disconnect:
					RelayNetworkProtocol.SendRelayDisconnect(protocolData, ref relayMessageRelay.FromAllocationId, ref sendInterface, ref queueHandle);
					break;
				case ProcessPacketCommandType.DataWithImplicitConnectionAccept:
					command.As.DataWithImplicitConnectionAccept.Offset = command.As.DataWithImplicitConnectionAccept.Offset + 38;
					break;
				}
				command.Address = default(NetworkInterfaceEndPoint);
				fixed (byte* ptr2 = &command.Address.data.FixedElementField)
				{
					*(RelayAllocationId*)ptr2 = relayMessageRelay.FromAllocationId;
				}
				return true;
			}
			command.Type = ProcessPacketCommandType.Drop;
			return true;
		}

		// Token: 0x06000295 RID: 661 RVA: 0x0000E708 File Offset: 0x0000C908
		private unsafe static void ProcessRelayError(byte* data, int size, ref ProcessPacketCommand command)
		{
			if (size != 21)
			{
				Debug.LogError("Received an invalid Relay Error message (wrong length).");
				return;
			}
			RelayMessageError relayMessageError = *(RelayMessageError*)data;
			switch (relayMessageError.ErrorCode)
			{
			case 0:
				Debug.LogError("Received error message from Relay: invalid protocol version. Make sure your Unity Transport package is up to date.");
				break;
			case 1:
				Debug.LogError("Received error message from Relay: player timed out due to inactivity.");
				break;
			case 2:
				Debug.LogError("Received error message from Relay: unauthorized.");
				break;
			case 3:
				Debug.LogError("Received error message from Relay: allocation ID client mismatch.");
				break;
			case 4:
				Debug.LogError("Received error message from Relay: allocation ID not found.");
				break;
			case 5:
				Debug.LogError("Received error message from Relay: not connected.");
				break;
			case 6:
				Debug.LogError("Received error message from Relay: self-connect not allowed.");
				break;
			default:
				Debug.LogError(string.Format("Received error message from Relay with unknown error code {0}", relayMessageError.ErrorCode));
				break;
			}
			if (relayMessageError.ErrorCode == 1 || relayMessageError.ErrorCode == 4)
			{
				Debug.LogError("Relay allocation is invalid. See NetworkDriver.GetRelayConnectionStatus and RelayConnectionStatus.AllocationInvalid for details on how to handle this situation.");
				command.Type = ProcessPacketCommandType.ProtocolStatusUpdate;
				command.As.ProtocolStatusUpdate.Status = 2;
			}
		}

		// Token: 0x06000296 RID: 662 RVA: 0x0000E7FC File Offset: 0x0000C9FC
		private unsafe static int SendMessage(RelayNetworkProtocol.RelayProtocolData* protocolData, ref NetworkSendInterface sendInterface, ref NetworkInterfaceSendHandle sendHandle, ref NetworkSendQueueHandle queueHandle)
		{
			if (protocolData->ServerData.IsSecure != 1 || protocolData->SecureState != RelayNetworkProtocol.SecuredRelayConnectionState.Secured)
			{
				return sendInterface.EndSendMessage.Ptr.Invoke(ref sendHandle, ref protocolData->ServerEndpoint, sendInterface.UserData, ref queueHandle);
			}
			SecureUserData* secureUserData = (SecureUserData*)((void*)protocolData->SecureClientState.ClientConfig->transportUserData);
			SecureNetworkProtocol.SetSecureUserData(IntPtr.Zero, 0, ref protocolData->ServerEndpoint, ref sendInterface, ref queueHandle, secureUserData);
			NativeArray<byte> nativeArray = new NativeArray<byte>(sendHandle.size, Allocator.Temp, NativeArrayOptions.ClearMemory);
			UnsafeUtility.MemCpy(nativeArray.GetUnsafePtr<byte>(), (void*)sendHandle.data, (long)sendHandle.size);
			sendInterface.AbortSendMessage.Ptr.Invoke(ref sendHandle, sendInterface.UserData);
			uint num = Binding.unitytls_client_send_data(protocolData->SecureClientState.ClientPtr, (byte*)nativeArray.GetUnsafePtr<byte>(), new UIntPtr((uint)nativeArray.Length));
			if (num != 0U)
			{
				Debug.LogError(string.Format("Secure send failed with result: {0}.", num));
				return -3;
			}
			return nativeArray.Length;
		}

		// Token: 0x06000297 RID: 663 RVA: 0x0000E904 File Offset: 0x0000CB04
		private unsafe static void SendRelayDisconnect(RelayNetworkProtocol.RelayProtocolData* protocolData, ref RelayAllocationId hostAllocationId, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle)
		{
			NetworkInterfaceSendHandle networkInterfaceSendHandle;
			if (sendInterface.BeginSendMessage.Ptr.Invoke(out networkInterfaceSendHandle, sendInterface.UserData, 36) != 0)
			{
				Debug.LogError("Failed to send Disconnect message to relay.");
				return;
			}
			byte* ptr = (byte*)((void*)networkInterfaceSendHandle.data);
			networkInterfaceSendHandle.size = 36;
			if (networkInterfaceSendHandle.size > networkInterfaceSendHandle.capacity)
			{
				sendInterface.AbortSendMessage.Ptr.Invoke(ref networkInterfaceSendHandle, sendInterface.UserData);
				Debug.LogError("Failed to send Disconnect message to relay.");
				return;
			}
			RelayMessageDisconnect* ptr2 = (RelayMessageDisconnect*)ptr;
			*ptr2 = RelayMessageDisconnect.Create(protocolData->ServerData.AllocationId, hostAllocationId);
			if (RelayNetworkProtocol.SendMessage(protocolData, ref sendInterface, ref networkInterfaceSendHandle, ref queueHandle) < 0)
			{
				Debug.LogError("Failed to send Disconnect message to relay.");
				return;
			}
		}

		// Token: 0x06000298 RID: 664 RVA: 0x0000E9C0 File Offset: 0x0000CBC0
		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(NetworkProtocol.ProcessSendDelegate))]
		public unsafe static int ProcessSend(ref NetworkDriver.Connection connection, bool hasPipeline, ref NetworkSendInterface sendInterface, ref NetworkInterfaceSendHandle sendHandle, ref NetworkSendQueueHandle queueHandle, IntPtr userData)
		{
			RelayNetworkProtocol.RelayProtocolData* ptr = (RelayNetworkProtocol.RelayProtocolData*)((void*)userData);
			ushort dataLength = (ushort)UnityTransportProtocol.WriteSendMessageHeader(ref connection, hasPipeline, ref sendHandle, 38);
			RelayMessageRelay* ptr2 = (RelayMessageRelay*)((void*)sendHandle.data);
			fixed (byte* ptr3 = &connection.Address.data.FixedElementField)
			{
				byte* ptr4 = ptr3;
				*ptr2 = RelayMessageRelay.Create(ptr->ServerData.AllocationId, *(RelayAllocationId*)ptr4, dataLength);
			}
			Interlocked.Exchange(ref ptr->LastSentTime, ptr->LastUpdateTime);
			return RelayNetworkProtocol.SendMessage(ptr, ref sendInterface, ref sendHandle, ref queueHandle);
		}

		// Token: 0x06000299 RID: 665 RVA: 0x0000EA40 File Offset: 0x0000CC40
		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(NetworkProtocol.ProcessSendConnectionAcceptDelegate))]
		public unsafe static void ProcessSendConnectionAccept(ref NetworkDriver.Connection connection, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IntPtr userData)
		{
			RelayNetworkProtocol.RelayProtocolData* ptr = (RelayNetworkProtocol.RelayProtocolData*)((void*)userData);
			RelayAllocationId toAllocationId = default(RelayAllocationId);
			fixed (byte* ptr2 = &connection.Address.data.FixedElementField)
			{
				toAllocationId = *(RelayAllocationId*)ptr2;
			}
			int num = 38 + UnityTransportProtocol.GetConnectionAcceptMessageMaxLength();
			NetworkInterfaceSendHandle networkInterfaceSendHandle;
			if (sendInterface.BeginSendMessage.Ptr.Invoke(out networkInterfaceSendHandle, sendInterface.UserData, num) != 0)
			{
				Debug.LogError("Failed to send a ConnectionRequest packet");
				return;
			}
			if (networkInterfaceSendHandle.capacity < num)
			{
				sendInterface.AbortSendMessage.Ptr.Invoke(ref networkInterfaceSendHandle, sendInterface.UserData);
				Debug.LogError("Failed to send a ConnectionAccept packet: size exceeds capacity");
				return;
			}
			byte* ptr3 = (byte*)((void*)networkInterfaceSendHandle.data);
			int num2 = UnityTransportProtocol.WriteConnectionAcceptMessage(ref connection, ptr3 + 38, networkInterfaceSendHandle.capacity - 38);
			if (num2 < 0)
			{
				sendInterface.AbortSendMessage.Ptr.Invoke(ref networkInterfaceSendHandle, sendInterface.UserData);
				Debug.LogError("Failed to send a ConnectionAccept packet");
				return;
			}
			networkInterfaceSendHandle.size = 38 + num2;
			RelayMessageRelay* ptr4 = (RelayMessageRelay*)ptr3;
			*ptr4 = RelayMessageRelay.Create(ptr->ServerData.AllocationId, toAllocationId, (ushort)num2);
			if (RelayNetworkProtocol.SendMessage(ptr, ref sendInterface, ref networkInterfaceSendHandle, ref queueHandle) < 0)
			{
				Debug.LogError("Failed to send Connection Accept message to host.");
				return;
			}
		}

		// Token: 0x0600029A RID: 666 RVA: 0x0000EB74 File Offset: 0x0000CD74
		private unsafe static int SendHeaderOnlyHostMessage(UdpCProtocol type, SessionIdToken token, RelayNetworkProtocol.RelayProtocolData* relayProtocolData, ref RelayAllocationId hostAllocationId, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle)
		{
			NetworkInterfaceSendHandle networkInterfaceSendHandle;
			if (sendInterface.BeginSendMessage.Ptr.Invoke(out networkInterfaceSendHandle, sendInterface.UserData, 48) != 0)
			{
				return -1;
			}
			byte* ptr = (byte*)((void*)networkInterfaceSendHandle.data);
			networkInterfaceSendHandle.size = 48;
			if (networkInterfaceSendHandle.size > networkInterfaceSendHandle.capacity)
			{
				sendInterface.AbortSendMessage.Ptr.Invoke(ref networkInterfaceSendHandle, sendInterface.UserData);
				return -1;
			}
			RelayMessageRelay* ptr2 = (RelayMessageRelay*)ptr;
			*ptr2 = RelayMessageRelay.Create(relayProtocolData->ServerData.AllocationId, hostAllocationId, 10);
			UdpCHeader* ptr3 = (UdpCHeader*)(ptr2 + 38 / sizeof(RelayMessageRelay));
			*ptr3 = new UdpCHeader
			{
				Type = (byte)type,
				SessionToken = token,
				Flags = (UdpCHeader.HeaderFlags)0
			};
			return RelayNetworkProtocol.SendMessage(relayProtocolData, ref sendInterface, ref networkInterfaceSendHandle, ref queueHandle);
		}

		// Token: 0x0600029B RID: 667 RVA: 0x0000EC44 File Offset: 0x0000CE44
		private unsafe static void SendConnectionRequestToRelay(RelayNetworkProtocol.RelayProtocolData* relayProtocolData, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle)
		{
			NetworkInterfaceSendHandle networkInterfaceSendHandle;
			if (sendInterface.BeginSendMessage.Ptr.Invoke(out networkInterfaceSendHandle, sendInterface.UserData, 276) != 0)
			{
				Debug.LogError("Failed to send ConnectRequest to relay.");
				return;
			}
			byte* ptr = (byte*)((void*)networkInterfaceSendHandle.data);
			networkInterfaceSendHandle.size = 276;
			if (networkInterfaceSendHandle.size > networkInterfaceSendHandle.capacity)
			{
				sendInterface.AbortSendMessage.Ptr.Invoke(ref networkInterfaceSendHandle, sendInterface.UserData);
				Debug.LogError("Failed to send ConnectRequest to relay.");
				return;
			}
			RelayMessageConnectRequest* ptr2 = (RelayMessageConnectRequest*)ptr;
			*ptr2 = RelayMessageConnectRequest.Create(relayProtocolData->ServerData.AllocationId, relayProtocolData->ServerData.HostConnectionData);
			if (RelayNetworkProtocol.SendMessage(relayProtocolData, ref sendInterface, ref networkInterfaceSendHandle, ref queueHandle) < 0)
			{
				Debug.LogError("Failed to send ConnectRequest to relay.");
				return;
			}
		}

		// Token: 0x0600029C RID: 668 RVA: 0x0000ED0C File Offset: 0x0000CF0C
		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(NetworkProtocol.ConnectDelegate))]
		public unsafe static void Connect(ref NetworkDriver.Connection connection, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IntPtr userData)
		{
			RelayNetworkProtocol.RelayProtocolData* ptr = (RelayNetworkProtocol.RelayProtocolData*)((void*)userData);
			ptr->ConnectionReceiveToken = connection.ReceiveToken;
			if (ptr->ConnectionState != RelayNetworkProtocol.RelayConnectionState.Bound)
			{
				ptr->ConnectOnBind = true;
				return;
			}
			if (ptr->HostAllocationId == default(RelayAllocationId))
			{
				RelayNetworkProtocol.SendConnectionRequestToRelay(ptr, ref sendInterface, ref queueHandle);
				return;
			}
			UdpCProtocol type = UdpCProtocol.ConnectionRequest;
			SessionIdToken connectionReceiveToken = ptr->ConnectionReceiveToken;
			if (RelayNetworkProtocol.SendHeaderOnlyHostMessage(type, connectionReceiveToken, ptr, ref ptr->HostAllocationId, ref sendInterface, ref queueHandle) < 0)
			{
				Debug.LogError("Failed to send Connection Request message to host.");
				return;
			}
		}

		// Token: 0x0600029D RID: 669 RVA: 0x0000ED84 File Offset: 0x0000CF84
		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(NetworkProtocol.DisconnectDelegate))]
		public unsafe static void Disconnect(ref NetworkDriver.Connection connection, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IntPtr userData)
		{
			RelayNetworkProtocol.RelayProtocolData* relayProtocolData = (RelayNetworkProtocol.RelayProtocolData*)((void*)userData);
			UdpCProtocol type = UdpCProtocol.Disconnect;
			SessionIdToken sendToken = connection.SendToken;
			if (RelayNetworkProtocol.SendHeaderOnlyHostMessage(type, sendToken, relayProtocolData, ref connection.Address.AsRelayAllocationId(), ref sendInterface, ref queueHandle) < 0)
			{
				Debug.LogError("Failed to send Disconnect message to host.");
				return;
			}
		}

		// Token: 0x0600029E RID: 670 RVA: 0x0000EDC4 File Offset: 0x0000CFC4
		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(NetworkProtocol.ProcessSendPingDelegate))]
		public unsafe static void ProcessSendPing(ref NetworkDriver.Connection connection, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IntPtr userData)
		{
			RelayNetworkProtocol.RelayProtocolData* relayProtocolData = (RelayNetworkProtocol.RelayProtocolData*)((void*)userData);
			UdpCProtocol type = UdpCProtocol.Ping;
			SessionIdToken sendToken = connection.SendToken;
			if (RelayNetworkProtocol.SendHeaderOnlyHostMessage(type, sendToken, relayProtocolData, ref connection.Address.AsRelayAllocationId(), ref sendInterface, ref queueHandle) < 0)
			{
				Debug.LogError("Failed to send Ping message to host.");
				return;
			}
		}

		// Token: 0x0600029F RID: 671 RVA: 0x0000EE04 File Offset: 0x0000D004
		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(NetworkProtocol.ProcessSendPingDelegate))]
		public unsafe static void ProcessSendPong(ref NetworkDriver.Connection connection, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IntPtr userData)
		{
			RelayNetworkProtocol.RelayProtocolData* relayProtocolData = (RelayNetworkProtocol.RelayProtocolData*)((void*)userData);
			UdpCProtocol type = UdpCProtocol.Pong;
			SessionIdToken sendToken = connection.SendToken;
			if (RelayNetworkProtocol.SendHeaderOnlyHostMessage(type, sendToken, relayProtocolData, ref connection.Address.AsRelayAllocationId(), ref sendInterface, ref queueHandle) < 0)
			{
				Debug.LogError("Failed to send Pong message to host.");
				return;
			}
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x0000EE44 File Offset: 0x0000D044
		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(NetworkProtocol.UpdateDelegate))]
		public unsafe static void Update(long updateTime, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IntPtr userData)
		{
			RelayNetworkProtocol.RelayProtocolData* ptr = (RelayNetworkProtocol.RelayProtocolData*)((void*)userData);
			switch (ptr->ConnectionState)
			{
			case RelayNetworkProtocol.RelayConnectionState.Handshake:
			{
				if (ptr->SecureClientState.ClientPtr == null)
				{
					Binding.unitytls_client_config* ptr2 = (Binding.unitytls_client_config*)UnsafeUtility.Malloc((long)UnsafeUtility.SizeOf<Binding.unitytls_client_config>(), UnsafeUtility.AlignOf<Binding.unitytls_client_config>(), Allocator.Persistent);
					*ptr2 = default(Binding.unitytls_client_config);
					Binding.unitytls_client_init_config(ptr2);
					ptr2->dataSendCB = ManagedSecureFunctions.s_SendCallback.Data.Value;
					ptr2->dataReceiveCB = ManagedSecureFunctions.s_RecvMethod.Data.Value;
					ptr2->clientAuth = 2U;
					ptr2->transportProtocol = 1U;
					ptr2->clientAuth = 1U;
					ptr2->ssl_read_timeout_ms = SecureNetworkProtocol.DefaultParameters.SSLReadTimeoutMs;
					ptr2->ssl_handshake_timeout_min = SecureNetworkProtocol.DefaultParameters.SSLHandshakeTimeoutMin;
					ptr2->ssl_handshake_timeout_max = SecureNetworkProtocol.DefaultParameters.SSLHandshakeTimeoutMax;
					ptr2->hostname = "relay".GetUnsafePtr();
					ptr2->psk = new Binding.unitytls_dataRef
					{
						dataPtr = &ptr->ServerData.HMACKey.Value.FixedElementField,
						dataLen = new UIntPtr(64U)
					};
					ptr2->pskIdentity = new Binding.unitytls_dataRef
					{
						dataPtr = &ptr->ServerData.AllocationId.Value.FixedElementField,
						dataLen = new UIntPtr(16U)
					};
					ptr->SecureClientState.ClientConfig = ptr2;
					ptr->SecureClientState.ClientPtr = Binding.unitytls_client_create(2U, ptr->SecureClientState.ClientConfig);
					IntPtr intPtr = (IntPtr)UnsafeUtility.Malloc((long)UnsafeUtility.SizeOf<SecureUserData>(), UnsafeUtility.AlignOf<SecureUserData>(), Allocator.Persistent);
					*(SecureUserData*)((void*)intPtr) = new SecureUserData
					{
						Interface = default(NetworkSendInterface),
						Remote = default(NetworkInterfaceEndPoint),
						QueueHandle = default(NetworkSendQueueHandle),
						StreamData = IntPtr.Zero,
						Size = 0,
						BytesProcessed = 0
					};
					ptr->SecureClientState.ClientConfig->transportUserData = intPtr;
					Binding.unitytls_client_init(ptr->SecureClientState.ClientPtr);
				}
				if (Binding.unitytls_client_get_state(ptr->SecureClientState.ClientPtr) == 2U)
				{
					return;
				}
				SecureUserData* secureUserData = (SecureUserData*)((void*)ptr->SecureClientState.ClientConfig->transportUserData);
				SecureNetworkProtocol.SetSecureUserData(IntPtr.Zero, 0, ref ptr->ServerEndpoint, ref sendInterface, ref queueHandle, secureUserData);
				SecureNetworkProtocol.SecureHandshakeStep(ref ptr->SecureClientState);
				break;
			}
			case RelayNetworkProtocol.RelayConnectionState.Binding:
				if (updateTime - ptr->LastConnectAttempt > (long)ptr->ConnectTimeoutMS || ptr->LastUpdateTime == 0L)
				{
					ptr->LastConnectAttempt = updateTime;
					ptr->LastSentTime = updateTime;
					NetworkInterfaceSendHandle networkInterfaceSendHandle;
					if (sendInterface.BeginSendMessage.Ptr.Invoke(out networkInterfaceSendHandle, sendInterface.UserData, 295) != 0)
					{
						Debug.LogError("Failed to send Bind message to relay.");
						return;
					}
					if (!RelayNetworkProtocol.WriteBindMessage(ref ptr->ServerEndpoint, ref networkInterfaceSendHandle, ref queueHandle, userData))
					{
						sendInterface.AbortSendMessage.Ptr.Invoke(ref networkInterfaceSendHandle, sendInterface.UserData);
						return;
					}
					if (RelayNetworkProtocol.SendMessage(ptr, ref sendInterface, ref networkInterfaceSendHandle, ref queueHandle) < 0)
					{
						Debug.LogError("Failed to send Bind message to relay.");
						return;
					}
				}
				break;
			case RelayNetworkProtocol.RelayConnectionState.Bound:
			case RelayNetworkProtocol.RelayConnectionState.Connected:
			{
				if (updateTime - ptr->LastSentTime >= (long)ptr->RelayConnectionTimeMS)
				{
					NetworkInterfaceSendHandle networkInterfaceSendHandle2;
					if (sendInterface.BeginSendMessage.Ptr.Invoke(out networkInterfaceSendHandle2, sendInterface.UserData, 22) != 0)
					{
						Debug.LogError("Failed to send a RelayPingMessage packet");
						return;
					}
					if (!RelayNetworkProtocol.WriteRelayPingMessage(ref ptr->ServerEndpoint, ref networkInterfaceSendHandle2, ref queueHandle, userData))
					{
						sendInterface.AbortSendMessage.Ptr.Invoke(ref networkInterfaceSendHandle2, sendInterface.UserData);
						return;
					}
					if (RelayNetworkProtocol.SendMessage(ptr, ref sendInterface, ref networkInterfaceSendHandle2, ref queueHandle) < 0)
					{
						Debug.LogError("Failed to send Ping message to relay.");
						return;
					}
					ptr->LastSentTime = updateTime;
				}
				int num = ptr->RelayConnectionTimeMS * 3;
				if (ptr->LastReceiveTime > 0L && updateTime - ptr->LastReceiveTime >= (long)num)
				{
					NetworkInterfaceSendHandle networkInterfaceSendHandle3;
					if (sendInterface.BeginSendMessage.Ptr.Invoke(out networkInterfaceSendHandle3, sendInterface.UserData, 22) != 0)
					{
						Debug.LogError("Failed to send Bind message to relay.");
						return;
					}
					if (!RelayNetworkProtocol.WriteBindMessage(ref ptr->ServerEndpoint, ref networkInterfaceSendHandle3, ref queueHandle, userData))
					{
						sendInterface.AbortSendMessage.Ptr.Invoke(ref networkInterfaceSendHandle3, sendInterface.UserData);
						return;
					}
					if (RelayNetworkProtocol.SendMessage(ptr, ref sendInterface, ref networkInterfaceSendHandle3, ref queueHandle) < 0)
					{
						Debug.LogError("Failed to send Bind message to relay.");
						return;
					}
					ptr->LastReceiveTime = updateTime;
				}
				break;
			}
			}
			ptr->LastUpdateTime = updateTime;
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x0000F28C File Offset: 0x0000D48C
		[BurstCompatible]
		private unsafe static bool WriteRelayPingMessage(ref NetworkInterfaceEndPoint serverEndpoint, ref NetworkInterfaceSendHandle sendHandle, ref NetworkSendQueueHandle queueHandle, IntPtr userData)
		{
			RelayNetworkProtocol.RelayProtocolData* ptr = (RelayNetworkProtocol.RelayProtocolData*)((void*)userData);
			byte* ptr2 = (byte*)((void*)sendHandle.data);
			sendHandle.size = 22;
			if (sendHandle.size > sendHandle.capacity)
			{
				Debug.LogError("Failed to send a RelayPingMessage packet");
				return false;
			}
			RelayMessagePing* ptr3 = (RelayMessagePing*)ptr2;
			*ptr3 = RelayMessagePing.Create(ptr->ServerData.AllocationId, 0);
			return true;
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x0000F2E8 File Offset: 0x0000D4E8
		[BurstCompatible]
		private unsafe static bool WriteBindMessage(ref NetworkInterfaceEndPoint serverEndpoint, ref NetworkInterfaceSendHandle sendHandle, ref NetworkSendQueueHandle queueHandle, IntPtr userData)
		{
			DataStreamWriter writer = RelayNetworkProtocol.WriterForSendBuffer(295, ref sendHandle);
			if (!writer.IsCreated)
			{
				Debug.LogError("Failed to send a RelayBindMessage packet");
				return false;
			}
			RelayNetworkProtocol.RelayProtocolData* ptr = (RelayNetworkProtocol.RelayProtocolData*)((void*)userData);
			RelayMessageBind.Write(writer, 0, ptr->ServerData.Nonce, &ptr->ServerData.ConnectionData.Value.FixedElementField, &ptr->ServerData.HMAC.FixedElementField);
			return true;
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x0000F358 File Offset: 0x0000D558
		private unsafe static DataStreamWriter WriterForSendBuffer(int requestSize, ref NetworkInterfaceSendHandle sendHandle)
		{
			if (requestSize <= sendHandle.capacity)
			{
				sendHandle.size = requestSize;
				return new DataStreamWriter((byte*)((void*)sendHandle.data), sendHandle.size);
			}
			return default(DataStreamWriter);
		}

		// Token: 0x04000201 RID: 513
		public IntPtr UserData;

		// Token: 0x0200009E RID: 158
		private enum RelayConnectionState : byte
		{
			// Token: 0x04000203 RID: 515
			Unbound,
			// Token: 0x04000204 RID: 516
			Handshake,
			// Token: 0x04000205 RID: 517
			Binding,
			// Token: 0x04000206 RID: 518
			Bound,
			// Token: 0x04000207 RID: 519
			Connected
		}

		// Token: 0x0200009F RID: 159
		private enum SecuredRelayConnectionState : byte
		{
			// Token: 0x04000209 RID: 521
			Unsecure,
			// Token: 0x0400020A RID: 522
			Secured
		}

		// Token: 0x020000A0 RID: 160
		private struct RelayProtocolData
		{
			// Token: 0x0400020B RID: 523
			public RelayNetworkProtocol.RelayConnectionState ConnectionState;

			// Token: 0x0400020C RID: 524
			public RelayNetworkProtocol.SecuredRelayConnectionState SecureState;

			// Token: 0x0400020D RID: 525
			public SessionIdToken ConnectionReceiveToken;

			// Token: 0x0400020E RID: 526
			public long LastConnectAttempt;

			// Token: 0x0400020F RID: 527
			public long LastUpdateTime;

			// Token: 0x04000210 RID: 528
			public long LastReceiveTime;

			// Token: 0x04000211 RID: 529
			public long LastSentTime;

			// Token: 0x04000212 RID: 530
			public int ConnectTimeoutMS;

			// Token: 0x04000213 RID: 531
			public int RelayConnectionTimeMS;

			// Token: 0x04000214 RID: 532
			public RelayAllocationId HostAllocationId;

			// Token: 0x04000215 RID: 533
			public NetworkInterfaceEndPoint ServerEndpoint;

			// Token: 0x04000216 RID: 534
			public RelayServerData ServerData;

			// Token: 0x04000217 RID: 535
			public SecureClientState SecureClientState;

			// Token: 0x04000218 RID: 536
			public bool ConnectOnBind;
		}
	}
}
