using System;
using AOT;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Networking.Transport.Protocols;
using Unity.TLS.LowLevel;
using UnityEngine;

namespace Unity.Networking.Transport.TLS
{
	// Token: 0x02000084 RID: 132
	[BurstCompile]
	internal struct SecureNetworkProtocol : INetworkProtocol, IDisposable
	{
		// Token: 0x06000241 RID: 577 RVA: 0x0000C518 File Offset: 0x0000A718
		private unsafe static void CreateSecureClient(uint role, SecureClientState* state)
		{
			Binding.unitytls_client* clientPtr = Binding.unitytls_client_create(role, state->ClientConfig);
			state->ClientPtr = clientPtr;
		}

		// Token: 0x06000242 RID: 578 RVA: 0x0000C53C File Offset: 0x0000A73C
		private unsafe static Binding.unitytls_client_config* GetSecureClientConfig(SecureNetworkProtocolData* protocolData)
		{
			Binding.unitytls_client_config* ptr = (Binding.unitytls_client_config*)UnsafeUtility.Malloc((long)UnsafeUtility.SizeOf<Binding.unitytls_client_config>(), UnsafeUtility.AlignOf<Binding.unitytls_client_config>(), Allocator.Persistent);
			*ptr = default(Binding.unitytls_client_config);
			Binding.unitytls_client_init_config(ptr);
			ptr->dataSendCB = ManagedSecureFunctions.s_SendCallback.Data.Value;
			ptr->dataReceiveCB = ManagedSecureFunctions.s_RecvMethod.Data.Value;
			ptr->logCallback = IntPtr.Zero;
			ptr->clientAuth = 0U;
			ptr->transportProtocol = protocolData->Protocol;
			ptr->clientAuth = protocolData->ClientAuth;
			ptr->ssl_read_timeout_ms = protocolData->SSLReadTimeoutMs;
			ptr->ssl_handshake_timeout_min = protocolData->SSLHandshakeTimeoutMin;
			ptr->ssl_handshake_timeout_max = protocolData->SSLHandshakeTimeoutMax;
			return ptr;
		}

		// Token: 0x06000243 RID: 579 RVA: 0x0000C5E4 File Offset: 0x0000A7E4
		public unsafe void Initialize(NetworkSettings settings)
		{
			ManagedSecureFunctions.Initialize();
			SecureNetworkProtocolParameter secureParameters = ref settings.GetSecureParameters();
			this.UserData = (IntPtr)UnsafeUtility.Malloc((long)UnsafeUtility.SizeOf<SecureNetworkProtocolData>(), UnsafeUtility.AlignOf<SecureNetworkProtocolData>(), Allocator.Persistent);
			*(SecureNetworkProtocolData*)((void*)this.UserData) = new SecureNetworkProtocolData
			{
				SecureClients = new UnsafeHashMap<NetworkInterfaceEndPoint, SecureClientState>(1, Allocator.Persistent),
				Rsa = secureParameters.Rsa,
				RsaKey = secureParameters.RsaKey,
				Pem = secureParameters.Pem,
				Hostname = secureParameters.Hostname,
				Protocol = (uint)secureParameters.Protocol,
				SSLReadTimeoutMs = secureParameters.SSLReadTimeoutMs,
				SSLHandshakeTimeoutMin = secureParameters.SSLHandshakeTimeoutMin,
				SSLHandshakeTimeoutMax = secureParameters.SSLHandshakeTimeoutMax,
				ClientAuth = (uint)secureParameters.ClientAuthenticationPolicy
			};
		}

		// Token: 0x06000244 RID: 580 RVA: 0x0000C6BC File Offset: 0x0000A8BC
		public unsafe static void DisposeSecureClient(ref SecureClientState state)
		{
			if (state.ClientConfig->transportUserData.ToPointer() != null)
			{
				UnsafeUtility.Free(state.ClientConfig->transportUserData.ToPointer(), Allocator.Persistent);
			}
			if (state.ClientConfig != null)
			{
				UnsafeUtility.Free((void*)state.ClientConfig, Allocator.Persistent);
			}
			state.ClientConfig = null;
			if (state.ClientPtr != null)
			{
				Binding.unitytls_client_destroy(state.ClientPtr);
			}
		}

		// Token: 0x06000245 RID: 581 RVA: 0x0000C728 File Offset: 0x0000A928
		public unsafe void Dispose()
		{
			SecureNetworkProtocolData* ptr = (SecureNetworkProtocolData*)((void*)this.UserData);
			NativeArray<NetworkInterfaceEndPoint> keyArray = ptr->SecureClients.GetKeyArray(Allocator.Temp);
			for (int i = 0; i < keyArray.Length; i++)
			{
				SecureClientState secureClientState = ptr->SecureClients[keyArray[i]];
				SecureNetworkProtocol.DisposeSecureClient(ref secureClientState);
				ptr->SecureClients.Remove(keyArray[i]);
			}
			if (this.UserData != (IntPtr)0)
			{
				UnsafeUtility.Free(this.UserData.ToPointer(), Allocator.Persistent);
			}
			this.UserData = 0;
		}

		// Token: 0x06000246 RID: 582 RVA: 0x0000C7C0 File Offset: 0x0000A9C0
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

		// Token: 0x06000247 RID: 583 RVA: 0x0000BCCE File Offset: 0x00009ECE
		public int Bind(INetworkInterface networkInterface, ref NetworkInterfaceEndPoint localEndPoint)
		{
			if (networkInterface.Bind(localEndPoint) != 0)
			{
				return -1;
			}
			return 0;
		}

		// Token: 0x06000248 RID: 584 RVA: 0x0000BCE1 File Offset: 0x00009EE1
		public int CreateConnectionAddress(INetworkInterface networkInterface, NetworkEndPoint remoteEndpoint, out NetworkInterfaceEndPoint remoteAddress)
		{
			remoteAddress = default(NetworkInterfaceEndPoint);
			return networkInterface.CreateInterfaceEndPoint(remoteEndpoint, out remoteAddress);
		}

		// Token: 0x06000249 RID: 585 RVA: 0x0000BCF2 File Offset: 0x00009EF2
		public NetworkEndPoint GetRemoteEndPoint(INetworkInterface networkInterface, NetworkInterfaceEndPoint address)
		{
			return networkInterface.GetGenericEndPoint(address);
		}

		// Token: 0x0600024A RID: 586 RVA: 0x0000C7FD File Offset: 0x0000A9FD
		public int Listen(INetworkInterface networkInterface)
		{
			return networkInterface.Listen();
		}

		// Token: 0x0600024B RID: 587 RVA: 0x0000C808 File Offset: 0x0000AA08
		public NetworkProtocol CreateProtocolInterface()
		{
			return new NetworkProtocol(new TransportFunctionPointer<NetworkProtocol.ComputePacketOverheadDelegate>(new NetworkProtocol.ComputePacketOverheadDelegate(SecureNetworkProtocol.ComputePacketOverhead)), new TransportFunctionPointer<NetworkProtocol.ProcessReceiveDelegate>(new NetworkProtocol.ProcessReceiveDelegate(SecureNetworkProtocol.ProcessReceive)), new TransportFunctionPointer<NetworkProtocol.ProcessSendDelegate>(new NetworkProtocol.ProcessSendDelegate(SecureNetworkProtocol.ProcessSend)), new TransportFunctionPointer<NetworkProtocol.ProcessSendConnectionAcceptDelegate>(new NetworkProtocol.ProcessSendConnectionAcceptDelegate(SecureNetworkProtocol.ProcessSendConnectionAccept)), new TransportFunctionPointer<NetworkProtocol.ConnectDelegate>(new NetworkProtocol.ConnectDelegate(SecureNetworkProtocol.Connect)), new TransportFunctionPointer<NetworkProtocol.DisconnectDelegate>(new NetworkProtocol.DisconnectDelegate(SecureNetworkProtocol.Disconnect)), new TransportFunctionPointer<NetworkProtocol.ProcessSendPingDelegate>(new NetworkProtocol.ProcessSendPingDelegate(SecureNetworkProtocol.ProcessSendPing)), new TransportFunctionPointer<NetworkProtocol.ProcessSendPongDelegate>(new NetworkProtocol.ProcessSendPongDelegate(SecureNetworkProtocol.ProcessSendPong)), new TransportFunctionPointer<NetworkProtocol.UpdateDelegate>(new NetworkProtocol.UpdateDelegate(SecureNetworkProtocol.Update)), true, this.UserData, 10, 8);
		}

		// Token: 0x0600024C RID: 588 RVA: 0x0000C8BD File Offset: 0x0000AABD
		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(NetworkProtocol.ComputePacketOverheadDelegate))]
		public static int ComputePacketOverhead(ref NetworkDriver.Connection connection, out int dataOffset)
		{
			return UnityTransportProtocol.ComputePacketOverhead(ref connection, out dataOffset);
		}

		// Token: 0x0600024D RID: 589 RVA: 0x0000C8C6 File Offset: 0x0000AAC6
		public static bool ServerShouldStep(uint currentState)
		{
			return currentState <= 6U || currentState - 12U <= 4U;
		}

		// Token: 0x0600024E RID: 590 RVA: 0x0000C8D8 File Offset: 0x0000AAD8
		private static bool ClientShouldStep(uint currentState)
		{
			switch (currentState)
			{
			case 0U:
			case 1U:
				return true;
			case 2U:
			case 3U:
			case 4U:
			case 5U:
				return false;
			case 6U:
			case 7U:
			case 8U:
			case 9U:
			case 10U:
			case 11U:
			case 14U:
			case 15U:
			case 16U:
				return true;
			}
			return false;
		}

		// Token: 0x0600024F RID: 591 RVA: 0x0000C938 File Offset: 0x0000AB38
		internal unsafe static void SetSecureUserData(IntPtr inStream, int size, ref NetworkInterfaceEndPoint remote, ref NetworkSendInterface networkSendInterface, ref NetworkSendQueueHandle queueHandle, SecureUserData* secureUserData)
		{
			secureUserData->Interface = networkSendInterface;
			secureUserData->Remote = remote;
			secureUserData->QueueHandle = queueHandle;
			secureUserData->Size = size;
			secureUserData->StreamData = inStream;
			secureUserData->BytesProcessed = 0;
		}

		// Token: 0x06000250 RID: 592 RVA: 0x0000C988 File Offset: 0x0000AB88
		private unsafe static bool CreateNewSecureClientState(ref NetworkInterfaceEndPoint endpoint, uint tlsRole, SecureNetworkProtocolData* protocolData, SessionIdToken receiveToken = default(SessionIdToken))
		{
			if (protocolData->SecureClients.TryAdd(endpoint, default(SecureClientState)))
			{
				SecureClientState secureClientState = protocolData->SecureClients[endpoint];
				secureClientState.ClientConfig = SecureNetworkProtocol.GetSecureClientConfig(protocolData);
				secureClientState.ReceiveToken = receiveToken;
				SecureNetworkProtocol.CreateSecureClient(tlsRole, &secureClientState);
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
				secureClientState.ClientConfig->transportUserData = intPtr;
				FixedString32Bytes fixedString32Bytes = default(FixedString32Bytes);
				if (protocolData->Hostname != fixedString32Bytes)
				{
					secureClientState.ClientConfig->hostname = protocolData->Hostname.GetUnsafePtr();
				}
				else
				{
					secureClientState.ClientConfig->hostname = null;
				}
				fixedString32Bytes = default(FixedString32Bytes);
				if (protocolData->Pem != fixedString32Bytes)
				{
					secureClientState.ClientConfig->caPEM = new Binding.unitytls_dataRef
					{
						dataPtr = protocolData->Pem.GetUnsafePtr(),
						dataLen = new UIntPtr((uint)protocolData->Pem.Length)
					};
				}
				else
				{
					secureClientState.ClientConfig->caPEM = new Binding.unitytls_dataRef
					{
						dataPtr = null,
						dataLen = new UIntPtr(0U)
					};
				}
				fixedString32Bytes = default(FixedString32Bytes);
				if (protocolData->Rsa != fixedString32Bytes)
				{
					FixedString32Bytes fixedString32Bytes2 = default(FixedString32Bytes);
					if (protocolData->RsaKey != fixedString32Bytes2)
					{
						secureClientState.ClientConfig->serverPEM = new Binding.unitytls_dataRef
						{
							dataPtr = protocolData->Rsa.GetUnsafePtr(),
							dataLen = new UIntPtr((uint)protocolData->Rsa.Length)
						};
						secureClientState.ClientConfig->privateKeyPEM = new Binding.unitytls_dataRef
						{
							dataPtr = protocolData->RsaKey.GetUnsafePtr(),
							dataLen = new UIntPtr((uint)protocolData->RsaKey.Length)
						};
						goto IL_288;
					}
				}
				secureClientState.ClientConfig->serverPEM = new Binding.unitytls_dataRef
				{
					dataPtr = null,
					dataLen = new UIntPtr(0U)
				};
				secureClientState.ClientConfig->privateKeyPEM = new Binding.unitytls_dataRef
				{
					dataPtr = null,
					dataLen = new UIntPtr(0U)
				};
				IL_288:
				Binding.unitytls_client_init(secureClientState.ClientPtr);
				protocolData->SecureClients[endpoint] = secureClientState;
			}
			return false;
		}

		// Token: 0x06000251 RID: 593 RVA: 0x0000CC3C File Offset: 0x0000AE3C
		internal static uint SecureHandshakeStep(ref SecureClientState clientAgent)
		{
			bool flag = Binding.unitytls_client_get_role(clientAgent.ClientPtr) == 1U;
			bool flag2;
			uint num;
			do
			{
				flag2 = false;
				num = Binding.unitytls_client_handshake(clientAgent.ClientPtr);
				if (num == 1048584U)
				{
					uint currentState = Binding.unitytls_client_get_handshake_state(clientAgent.ClientPtr);
					flag2 = (flag ? SecureNetworkProtocol.ServerShouldStep(currentState) : SecureNetworkProtocol.ClientShouldStep(currentState));
				}
			}
			while (flag2);
			return num;
		}

		// Token: 0x06000252 RID: 594 RVA: 0x0000CC98 File Offset: 0x0000AE98
		private unsafe static uint UpdateSecureHandshakeState(SecureNetworkProtocolData* protocolData, ref NetworkInterfaceEndPoint endpoint)
		{
			SecureClientState value = protocolData->SecureClients[endpoint];
			value.LastHandshakeUpdate = protocolData->LastUpdate;
			protocolData->SecureClients[endpoint] = value;
			return SecureNetworkProtocol.SecureHandshakeStep(ref value);
		}

		// Token: 0x06000253 RID: 595 RVA: 0x0000CCE0 File Offset: 0x0000AEE0
		private unsafe static void PruneHalfOpenConnections(SecureNetworkProtocolData* protocolData)
		{
			NativeArray<NetworkInterfaceEndPoint> keyArray = protocolData->SecureClients.GetKeyArray(Allocator.Temp);
			bool flag = false;
			for (int i = 0; i < keyArray.Length; i++)
			{
				SecureClientState secureClientState = protocolData->SecureClients[keyArray[i]];
				if (Binding.unitytls_client_get_state(secureClientState.ClientPtr) == 2U && secureClientState.LastHandshakeUpdate > 0L && protocolData->LastUpdate - secureClientState.LastHandshakeUpdate > (long)((ulong)protocolData->SSLHandshakeTimeoutMax))
				{
					SecureNetworkProtocol.DisposeSecureClient(ref secureClientState);
					protocolData->SecureClients.Remove(keyArray[i]);
					flag = true;
				}
			}
			if (flag)
			{
				Debug.LogError("Had to prune half-open connections (clients with unfinished TLS handshakes).");
			}
			keyArray.Dispose();
		}

		// Token: 0x06000254 RID: 596 RVA: 0x0000CD88 File Offset: 0x0000AF88
		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(NetworkProtocol.ProcessReceiveDelegate))]
		public unsafe static void ProcessReceive(IntPtr stream, ref NetworkInterfaceEndPoint endpoint, int size, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IntPtr userData, ref ProcessPacketCommand command)
		{
			SecureNetworkProtocolData* ptr = (SecureNetworkProtocolData*)((void*)userData);
			SecureNetworkProtocol.CreateNewSecureClientState(ref endpoint, 1U, ptr, default(SessionIdToken));
			SecureClientState secureClientState = ptr->SecureClients[endpoint];
			SecureUserData* ptr2 = (SecureUserData*)((void*)secureClientState.ClientConfig->transportUserData);
			SecureNetworkProtocol.SetSecureUserData(stream, size, ref endpoint, ref sendInterface, ref queueHandle, ptr2);
			uint num = Binding.unitytls_client_get_state(secureClientState.ClientPtr);
			uint num2 = 0U;
			if (num == 2U || num == 1U)
			{
				do
				{
					num2 = SecureNetworkProtocol.UpdateSecureHandshakeState(ptr, ref endpoint);
					num = Binding.unitytls_client_get_state(secureClientState.ClientPtr);
				}
				while (size != 0 && ptr2->BytesProcessed == 0 && num == 2U);
				if (Binding.unitytls_client_get_role(secureClientState.ClientPtr) == 2U && num == 3U)
				{
					SecureNetworkProtocol.SendConnectionRequest(secureClientState.ReceiveToken, secureClientState, ref endpoint, ref sendInterface, ref queueHandle);
				}
				command.Type = ProcessPacketCommandType.Drop;
			}
			else if (num == 3U)
			{
				NativeArray<byte> nativeArray = new NativeArray<byte>(1472, Allocator.Temp, NativeArrayOptions.ClearMemory);
				UIntPtr uintPtr = 0;
				if (Binding.unitytls_client_read_data(secureClientState.ClientPtr, (byte*)nativeArray.GetUnsafePtr<byte>(), new UIntPtr(1472U), &uintPtr) != 0U)
				{
					command.Type = ProcessPacketCommandType.Drop;
					return;
				}
				UnsafeUtility.MemCpy((void*)stream, nativeArray.GetUnsafePtr<byte>(), (long)((ulong)uintPtr.ToUInt32()));
				UnityTransportProtocol.ProcessReceive(stream, ref endpoint, (int)uintPtr.ToUInt32(), ref sendInterface, ref queueHandle, IntPtr.Zero, ref command);
				if (command.Type == ProcessPacketCommandType.Disconnect)
				{
					SecureNetworkProtocol.DisposeSecureClient(ref secureClientState);
					ptr->SecureClients.Remove(endpoint);
					return;
				}
			}
			num = Binding.unitytls_client_get_state(secureClientState.ClientPtr);
			if (num == 64U)
			{
				if (num2 == 13U)
				{
					Debug.LogError("Secure handshake failure (likely caused by certificate validation failure).");
				}
				command.Type = ProcessPacketCommandType.Drop;
				SecureNetworkProtocol.DisposeSecureClient(ref secureClientState);
				ptr->SecureClients.Remove(endpoint);
			}
		}

		// Token: 0x06000255 RID: 597 RVA: 0x0000CF34 File Offset: 0x0000B134
		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(NetworkProtocol.ProcessSendDelegate))]
		public unsafe static int ProcessSend(ref NetworkDriver.Connection connection, bool hasPipeline, ref NetworkSendInterface sendInterface, ref NetworkInterfaceSendHandle sendHandle, ref NetworkSendQueueHandle queueHandle, IntPtr userData)
		{
			SecureNetworkProtocolData* ptr = (SecureNetworkProtocolData*)((void*)userData);
			SecureNetworkProtocol.CreateNewSecureClientState(ref connection.Address, 1U, ptr, default(SessionIdToken));
			SecureClientState secureClientState = ptr->SecureClients[connection.Address];
			SecureUserData* secureUserData = (SecureUserData*)((void*)secureClientState.ClientConfig->transportUserData);
			SecureNetworkProtocol.SetSecureUserData(IntPtr.Zero, 0, ref connection.Address, ref sendInterface, ref queueHandle, secureUserData);
			UnityTransportProtocol.WriteSendMessageHeader(ref connection, hasPipeline, ref sendHandle, 0);
			NativeArray<byte> nativeArray = new NativeArray<byte>(sendHandle.size, Allocator.Temp, NativeArrayOptions.ClearMemory);
			UnsafeUtility.MemCpy(nativeArray.GetUnsafePtr<byte>(), (void*)sendHandle.data, (long)sendHandle.size);
			sendInterface.AbortSendMessage.Ptr.Invoke(ref sendHandle, sendInterface.UserData);
			uint num = Binding.unitytls_client_send_data(secureClientState.ClientPtr, (byte*)nativeArray.GetUnsafePtr<byte>(), new UIntPtr((uint)nativeArray.Length));
			if (num != 0U)
			{
				Debug.LogError(string.Format("Secure Send failed with result {0}", num));
				return -3;
			}
			return nativeArray.Length;
		}

		// Token: 0x06000256 RID: 598 RVA: 0x0000D02C File Offset: 0x0000B22C
		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(NetworkProtocol.ProcessSendConnectionAcceptDelegate))]
		public unsafe static void ProcessSendConnectionAccept(ref NetworkDriver.Connection connection, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IntPtr userData)
		{
			SecureNetworkProtocolData* ptr = (SecureNetworkProtocolData*)((void*)userData);
			SecureClientState secureClientState = ptr->SecureClients[connection.Address];
			NativeArray<byte> nativeArray = new NativeArray<byte>(18, Allocator.Temp, NativeArrayOptions.ClearMemory);
			if (SecureNetworkProtocol.WriteConnectionAcceptMessage(ref connection, (byte*)nativeArray.GetUnsafePtr<byte>(), nativeArray.Length) < 0)
			{
				Debug.LogError("Failed to send a ConnectionAccept packet");
				return;
			}
			SecureUserData* secureUserData = (SecureUserData*)((void*)secureClientState.ClientConfig->transportUserData);
			SecureNetworkProtocol.SetSecureUserData(IntPtr.Zero, 0, ref connection.Address, ref sendInterface, ref queueHandle, secureUserData);
			uint num = Binding.unitytls_client_send_data(secureClientState.ClientPtr, (byte*)nativeArray.GetUnsafePtr<byte>(), new UIntPtr((uint)nativeArray.Length));
			if (num != 0U)
			{
				Debug.LogError(string.Format("Secure Send failed with result {0}", num));
			}
		}

		// Token: 0x06000257 RID: 599 RVA: 0x0000D0DC File Offset: 0x0000B2DC
		[BurstCompile(DisableDirectCall = true)]
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
			((UdpCHeader*)packet)->Type = 2;
			((UdpCHeader*)packet)->SessionToken = connection.SendToken;
			((UdpCHeader*)packet)->Flags = (UdpCHeader.HeaderFlags)0;
			if (connection.DidReceiveData == 0)
			{
				((UdpCHeader*)packet)->Flags = (((UdpCHeader*)packet)->Flags | UdpCHeader.HeaderFlags.HasConnectToken);
				*(SessionIdToken*)(packet + 10) = connection.ReceiveToken;
			}
			return num;
		}

		// Token: 0x06000258 RID: 600 RVA: 0x0000D148 File Offset: 0x0000B348
		private unsafe static void SendConnectionRequest(SessionIdToken token, SecureClientState secureClient, ref NetworkInterfaceEndPoint address, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle)
		{
			NativeArray<byte> nativeArray = new NativeArray<byte>(10, Allocator.Temp, NativeArrayOptions.ClearMemory);
			UdpCHeader* unsafePtr = (UdpCHeader*)nativeArray.GetUnsafePtr<byte>();
			unsafePtr->Type = 0;
			unsafePtr->SessionToken = token;
			unsafePtr->Flags = (UdpCHeader.HeaderFlags)0;
			SecureUserData* secureUserData = (SecureUserData*)((void*)secureClient.ClientConfig->transportUserData);
			SecureNetworkProtocol.SetSecureUserData(IntPtr.Zero, 0, ref address, ref sendInterface, ref queueHandle, secureUserData);
			if (Binding.unitytls_client_send_data(secureClient.ClientPtr, (byte*)nativeArray.GetUnsafePtr<byte>(), new UIntPtr((uint)nativeArray.Length)) != 0U)
			{
				Debug.LogError("We have failed to Send Encrypted SendConnectionRequest");
			}
		}

		// Token: 0x06000259 RID: 601 RVA: 0x0000D1C8 File Offset: 0x0000B3C8
		private unsafe static uint SendHeaderOnlyMessage(UdpCProtocol type, SessionIdToken token, SecureClientState secureClient, ref NetworkDriver.Connection connection, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle)
		{
			NativeArray<byte> nativeArray = new NativeArray<byte>(10, Allocator.Temp, NativeArrayOptions.ClearMemory);
			UdpCHeader* unsafePtr = (UdpCHeader*)nativeArray.GetUnsafePtr<byte>();
			unsafePtr->Type = (byte)type;
			unsafePtr->SessionToken = token;
			unsafePtr->Flags = (UdpCHeader.HeaderFlags)0;
			SecureUserData* secureUserData = (SecureUserData*)((void*)secureClient.ClientConfig->transportUserData);
			SecureNetworkProtocol.SetSecureUserData(IntPtr.Zero, 0, ref connection.Address, ref sendInterface, ref queueHandle, secureUserData);
			return Binding.unitytls_client_send_data(secureClient.ClientPtr, (byte*)nativeArray.GetUnsafePtr<byte>(), new UIntPtr((uint)nativeArray.Length));
		}

		// Token: 0x0600025A RID: 602 RVA: 0x0000D244 File Offset: 0x0000B444
		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(NetworkProtocol.ConnectDelegate))]
		public unsafe static void Connect(ref NetworkDriver.Connection connection, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IntPtr userData)
		{
			SecureNetworkProtocolData* ptr = (SecureNetworkProtocolData*)((void*)userData);
			SecureNetworkProtocol.CreateNewSecureClientState(ref connection.Address, 2U, ptr, connection.ReceiveToken);
			SecureClientState secureClientState = ptr->SecureClients[connection.Address];
			SecureUserData* secureUserData = (SecureUserData*)((void*)secureClientState.ClientConfig->transportUserData);
			SecureNetworkProtocol.SetSecureUserData(IntPtr.Zero, 0, ref connection.Address, ref sendInterface, ref queueHandle, secureUserData);
			if (Binding.unitytls_client_get_state(secureClientState.ClientPtr) == 3U)
			{
				SecureNetworkProtocol.SendConnectionRequest(connection.ReceiveToken, secureClientState, ref connection.Address, ref sendInterface, ref queueHandle);
				return;
			}
			uint num = SecureNetworkProtocol.UpdateSecureHandshakeState(ptr, ref connection.Address);
			if (Binding.unitytls_client_get_state(secureClientState.ClientPtr) == 64U)
			{
				Debug.LogError(string.Format("Handshake failed with result {0}", num));
				SecureNetworkProtocol.DisposeSecureClient(ref secureClientState);
				ptr->SecureClients.Remove(connection.Address);
			}
		}

		// Token: 0x0600025B RID: 603 RVA: 0x0000D310 File Offset: 0x0000B510
		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(NetworkProtocol.DisconnectDelegate))]
		public unsafe static void Disconnect(ref NetworkDriver.Connection connection, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IntPtr userData)
		{
			SecureNetworkProtocolData* ptr = (SecureNetworkProtocolData*)((void*)userData);
			SecureClientState secureClient = ptr->SecureClients[connection.Address];
			if (connection.State == NetworkConnection.State.Connected)
			{
				UdpCProtocol type = UdpCProtocol.Disconnect;
				SessionIdToken sendToken = connection.SendToken;
				uint num = SecureNetworkProtocol.SendHeaderOnlyMessage(type, sendToken, secureClient, ref connection, ref sendInterface, ref queueHandle);
				if (num != 0U)
				{
					Debug.LogError(string.Format("Failed to send secure Disconnect message (result: {0})", num));
				}
			}
			SecureNetworkProtocol.DisposeSecureClient(ref secureClient);
			ptr->SecureClients.Remove(connection.Address);
		}

		// Token: 0x0600025C RID: 604 RVA: 0x0000D384 File Offset: 0x0000B584
		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(NetworkProtocol.ProcessSendPingDelegate))]
		public unsafe static void ProcessSendPing(ref NetworkDriver.Connection connection, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IntPtr userData)
		{
			SecureNetworkProtocolData* ptr = (SecureNetworkProtocolData*)((void*)userData);
			SecureClientState secureClient = ptr->SecureClients[connection.Address];
			UdpCProtocol type = UdpCProtocol.Ping;
			SessionIdToken sendToken = connection.SendToken;
			uint num = SecureNetworkProtocol.SendHeaderOnlyMessage(type, sendToken, secureClient, ref connection, ref sendInterface, ref queueHandle);
			if (num != 0U)
			{
				Debug.LogError(string.Format("Failed to send secure Ping message (result: {0})", num));
			}
		}

		// Token: 0x0600025D RID: 605 RVA: 0x0000D3D8 File Offset: 0x0000B5D8
		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(NetworkProtocol.ProcessSendPongDelegate))]
		public unsafe static void ProcessSendPong(ref NetworkDriver.Connection connection, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IntPtr userData)
		{
			SecureNetworkProtocolData* ptr = (SecureNetworkProtocolData*)((void*)userData);
			SecureClientState secureClient = ptr->SecureClients[connection.Address];
			UdpCProtocol type = UdpCProtocol.Pong;
			SessionIdToken sendToken = connection.SendToken;
			uint num = SecureNetworkProtocol.SendHeaderOnlyMessage(type, sendToken, secureClient, ref connection, ref sendInterface, ref queueHandle);
			if (num != 0U)
			{
				Debug.LogError(string.Format("Failed to send secure Pong message (result: {0})", num));
			}
		}

		// Token: 0x0600025E RID: 606 RVA: 0x0000D42C File Offset: 0x0000B62C
		[BurstCompile(DisableDirectCall = true)]
		[MonoPInvokeCallback(typeof(NetworkProtocol.UpdateDelegate))]
		public unsafe static void Update(long updateTime, ref NetworkSendInterface sendInterface, ref NetworkSendQueueHandle queueHandle, IntPtr userData)
		{
			SecureNetworkProtocolData* ptr = (SecureNetworkProtocolData*)((void*)userData);
			ptr->LastUpdate = updateTime;
			if (updateTime - ptr->LastHalfOpenPrune > (long)((ulong)ptr->SSLHandshakeTimeoutMin))
			{
				SecureNetworkProtocol.PruneHalfOpenConnections(ptr);
				ptr->LastHalfOpenPrune = updateTime;
			}
		}

		// Token: 0x040001B4 RID: 436
		public IntPtr UserData;

		// Token: 0x040001B5 RID: 437
		public static readonly SecureNetworkProtocolParameter DefaultParameters = new SecureNetworkProtocolParameter
		{
			Protocol = SecureTransportProtocol.DTLS,
			SSLReadTimeoutMs = 0U,
			SSLHandshakeTimeoutMin = 1000U,
			SSLHandshakeTimeoutMax = 60000U,
			ClientAuthenticationPolicy = SecureClientAuthPolicy.Optional
		};
	}
}
