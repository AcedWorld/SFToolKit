using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace Unity.Netcode
{
	// Token: 0x0200007A RID: 122
	internal class NetworkMessageManager : IDisposable
	{
		// Token: 0x17000074 RID: 116
		// (get) Token: 0x060002CA RID: 714 RVA: 0x0000E70A File Offset: 0x0000C90A
		internal Type[] MessageTypes
		{
			get
			{
				return this.m_ReverseTypeMap;
			}
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x060002CB RID: 715 RVA: 0x0000E712 File Offset: 0x0000C912
		internal NetworkMessageManager.MessageHandler[] MessageHandlers
		{
			get
			{
				return this.m_MessageHandlers;
			}
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x060002CC RID: 716 RVA: 0x0000E71A File Offset: 0x0000C91A
		internal uint MessageHandlerCount
		{
			get
			{
				return this.m_HighMessageType;
			}
		}

		// Token: 0x060002CD RID: 717 RVA: 0x0000E722 File Offset: 0x0000C922
		internal uint GetMessageType(Type t)
		{
			return this.m_MessageTypes[t];
		}

		// Token: 0x060002CE RID: 718 RVA: 0x0000E730 File Offset: 0x0000C930
		internal object GetOwner()
		{
			return this.m_Owner;
		}

		// Token: 0x060002CF RID: 719 RVA: 0x0000E738 File Offset: 0x0000C938
		internal void SetLocalClientId(ulong id)
		{
			this.m_LocalClientId = id;
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x0000E744 File Offset: 0x0000C944
		internal List<NetworkMessageManager.MessageWithHandler> PrioritizeMessageOrder(List<NetworkMessageManager.MessageWithHandler> allowedTypes)
		{
			List<NetworkMessageManager.MessageWithHandler> list = new List<NetworkMessageManager.MessageWithHandler>();
			foreach (NetworkMessageManager.MessageWithHandler messageWithHandler in allowedTypes)
			{
				if (messageWithHandler.MessageType.FullName == typeof(ConnectionRequestMessage).FullName || messageWithHandler.MessageType.FullName == typeof(ConnectionApprovedMessage).FullName)
				{
					list.Add(messageWithHandler);
				}
			}
			foreach (NetworkMessageManager.MessageWithHandler messageWithHandler2 in allowedTypes)
			{
				if (messageWithHandler2.MessageType.FullName != typeof(ConnectionRequestMessage).FullName && messageWithHandler2.MessageType.FullName != typeof(ConnectionApprovedMessage).FullName)
				{
					list.Add(messageWithHandler2);
				}
			}
			return list;
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x0000E85C File Offset: 0x0000CA5C
		public NetworkMessageManager(INetworkMessageSender sender, object owner, INetworkMessageProvider provider = null)
		{
			try
			{
				this.m_Sender = sender;
				this.m_Owner = owner;
				if (provider == null)
				{
					provider = default(ILPPMessageProvider);
				}
				List<NetworkMessageManager.MessageWithHandler> list = provider.GetMessages();
				list.Sort((NetworkMessageManager.MessageWithHandler a, NetworkMessageManager.MessageWithHandler b) => string.CompareOrdinal(a.MessageType.FullName, b.MessageType.FullName));
				list = this.PrioritizeMessageOrder(list);
				foreach (NetworkMessageManager.MessageWithHandler messageWithHandler in list)
				{
					this.RegisterMessageType(messageWithHandler);
				}
			}
			catch (Exception)
			{
				this.Dispose();
				throw;
			}
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x0000E9B8 File Offset: 0x0000CBB8
		public void Dispose()
		{
			if (this.m_Disposed)
			{
				return;
			}
			foreach (KeyValuePair<ulong, NativeList<NetworkMessageManager.SendQueueItem>> keyValuePair in this.m_SendQueues)
			{
				this.ClientDisconnected(keyValuePair.Key);
			}
			this.CleanupDisconnectedClients();
			for (int i = 0; i < this.m_IncomingMessageQueue.Length; i++)
			{
				this.m_IncomingMessageQueue.ElementAt(i).Reader.Dispose();
			}
			this.m_IncomingMessageQueue.Dispose();
			this.m_Disposed = true;
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x0000EA60 File Offset: 0x0000CC60
		~NetworkMessageManager()
		{
			this.Dispose();
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x0000EA8C File Offset: 0x0000CC8C
		public void Hook(INetworkHooks hooks)
		{
			this.m_Hooks.Add(hooks);
		}

		// Token: 0x060002D5 RID: 725 RVA: 0x0000EA9A File Offset: 0x0000CC9A
		public void Unhook(INetworkHooks hooks)
		{
			this.m_Hooks.Remove(hooks);
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x0000EAAC File Offset: 0x0000CCAC
		private void RegisterMessageType(NetworkMessageManager.MessageWithHandler messageWithHandler)
		{
			if ((ulong)this.m_HighMessageType == (ulong)((long)this.m_MessageHandlers.Length))
			{
				Array.Resize<NetworkMessageManager.MessageHandler>(ref this.m_MessageHandlers, 2 * this.m_MessageHandlers.Length);
				Array.Resize<Type>(ref this.m_ReverseTypeMap, 2 * this.m_ReverseTypeMap.Length);
			}
			this.m_MessageHandlers[(int)this.m_HighMessageType] = messageWithHandler.Handler;
			this.m_ReverseTypeMap[(int)this.m_HighMessageType] = messageWithHandler.MessageType;
			this.m_MessagesByHash[messageWithHandler.MessageType.FullName.Hash32()] = messageWithHandler.MessageType;
			Dictionary<Type, uint> messageTypes = this.m_MessageTypes;
			Type messageType = messageWithHandler.MessageType;
			uint highMessageType = this.m_HighMessageType;
			this.m_HighMessageType = highMessageType + 1U;
			messageTypes[messageType] = highMessageType;
			this.m_LocalVersions[messageWithHandler.MessageType] = messageWithHandler.GetVersion();
		}

		// Token: 0x060002D7 RID: 727 RVA: 0x0000EB7A File Offset: 0x0000CD7A
		public int GetLocalVersion(Type messageType)
		{
			return this.m_LocalVersions[messageType];
		}

		// Token: 0x060002D8 RID: 728 RVA: 0x0000EB88 File Offset: 0x0000CD88
		internal static string ByteArrayToString(byte[] ba, int offset, int count)
		{
			StringBuilder stringBuilder = new StringBuilder(ba.Length * 2);
			for (int i = offset; i < offset + count; i++)
			{
				stringBuilder.AppendFormat("{0:x2} ", ba[i]);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x0000EBC8 File Offset: 0x0000CDC8
		internal unsafe void HandleIncomingData(ulong clientId, ArraySegment<byte> data, float receiveTime)
		{
			byte[] array;
			byte* ptr;
			if ((array = data.Array) == null || array.Length == 0)
			{
				ptr = null;
			}
			else
			{
				ptr = &array[0];
			}
			FastBufferReader reader = new FastBufferReader(ptr + data.Offset, Allocator.None, data.Count, 0, Allocator.Temp);
			if (!reader.TryBeginRead(sizeof(NetworkBatchHeader)))
			{
				NetworkLog.LogError("Received a packet too small to contain a BatchHeader. Ignoring it.");
				return;
			}
			NetworkBatchHeader networkBatchHeader;
			reader.ReadValue<NetworkBatchHeader>(out networkBatchHeader, default(FastBufferWriter.ForStructs));
			if (networkBatchHeader.Magic != 4448)
			{
				NetworkLog.LogError(string.Format("Received a packet with an invalid Magic Value. Please report this to the Netcode for GameObjects team at https://github.com/Unity-Technologies/com.unity.netcode.gameobjects/issues and include the following data: Offset: {0}, Size: {1}, Full receive array: {2}", data.Offset, data.Count, NetworkMessageManager.ByteArrayToString(data.Array, 0, data.Array.Length)));
				return;
			}
			if (networkBatchHeader.BatchSize != data.Count)
			{
				NetworkLog.LogError(string.Format("Received a packet with an invalid Batch Size Value. Please report this to the Netcode for GameObjects team at https://github.com/Unity-Technologies/com.unity.netcode.gameobjects/issues and include the following data: Offset: {0}, Size: {1}, Expected Size: {2}, Full receive array: {3}", new object[]
				{
					data.Offset,
					data.Count,
					networkBatchHeader.BatchSize,
					NetworkMessageManager.ByteArrayToString(data.Array, 0, data.Array.Length)
				}));
				return;
			}
			ulong num = XXHash.Hash64(reader.GetUnsafePtrAtCurrentPosition(), reader.Length - reader.Position, 0U);
			if (num != networkBatchHeader.BatchHash)
			{
				NetworkLog.LogError(string.Format("Received a packet with an invalid Hash Value. Please report this to the Netcode for GameObjects team at https://github.com/Unity-Technologies/com.unity.netcode.gameobjects/issues and include the following data: Received Hash: {0}, Calculated Hash: {1}, Offset: {2}, Size: {3}, Full receive array: {4}", new object[]
				{
					networkBatchHeader.BatchHash,
					num,
					data.Offset,
					data.Count,
					NetworkMessageManager.ByteArrayToString(data.Array, 0, data.Array.Length)
				}));
				return;
			}
			for (int i = 0; i < this.m_Hooks.Count; i++)
			{
				this.m_Hooks[i].OnBeforeReceiveBatch(clientId, (int)networkBatchHeader.BatchCount, reader.Length);
			}
			for (int j = 0; j < (int)networkBatchHeader.BatchCount; j++)
			{
				NetworkMessageHeader networkMessageHeader = default(NetworkMessageHeader);
				int position = reader.Position;
				try
				{
					ByteUnpacker.ReadValueBitPacked(reader, out networkMessageHeader.MessageType);
					ByteUnpacker.ReadValueBitPacked(reader, out networkMessageHeader.MessageSize);
				}
				catch (OverflowException)
				{
					NetworkLog.LogError("Received a batch that didn't have enough data for all of its batches, ending early!");
					throw;
				}
				int messageHeaderSerializedSize = reader.Position - position;
				if (!reader.TryBeginRead((int)networkMessageHeader.MessageSize))
				{
					NetworkLog.LogError("Received a message that claimed a size larger than the packet, ending early!");
					return;
				}
				NetworkMessageManager.ReceiveQueueItem receiveQueueItem = default(NetworkMessageManager.ReceiveQueueItem);
				receiveQueueItem.Header = networkMessageHeader;
				receiveQueueItem.SenderId = clientId;
				receiveQueueItem.Timestamp = receiveTime;
				receiveQueueItem.Reader = new FastBufferReader(reader.GetUnsafePtrAtCurrentPosition(), Allocator.TempJob, (int)networkMessageHeader.MessageSize, 0, Allocator.Temp);
				receiveQueueItem.MessageHeaderSerializedSize = messageHeaderSerializedSize;
				this.m_IncomingMessageQueue.Add(receiveQueueItem);
				reader.Seek(reader.Position + (int)networkMessageHeader.MessageSize);
			}
			for (int k = 0; k < this.m_Hooks.Count; k++)
			{
				this.m_Hooks[k].OnAfterReceiveBatch(clientId, (int)networkBatchHeader.BatchCount, reader.Length);
			}
			array = null;
		}

		// Token: 0x060002DA RID: 730 RVA: 0x0000EEE8 File Offset: 0x0000D0E8
		private bool CanReceive(ulong clientId, Type messageType, FastBufferReader messageContent, ref NetworkContext context)
		{
			for (int i = 0; i < this.m_Hooks.Count; i++)
			{
				if (!this.m_Hooks[i].OnVerifyCanReceive(clientId, messageType, messageContent, ref context))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x060002DB RID: 731 RVA: 0x0000EF26 File Offset: 0x0000D126
		internal Type GetMessageForHash(uint messageHash)
		{
			if (!this.m_MessagesByHash.ContainsKey(messageHash))
			{
				return null;
			}
			return this.m_MessagesByHash[messageHash];
		}

		// Token: 0x060002DC RID: 732 RVA: 0x0000EF44 File Offset: 0x0000D144
		internal void SetVersion(ulong clientId, uint messageHash, int version)
		{
			if (!this.m_MessagesByHash.ContainsKey(messageHash))
			{
				return;
			}
			Type key = this.m_MessagesByHash[messageHash];
			if (!this.m_PerClientMessageVersions.ContainsKey(clientId))
			{
				this.m_PerClientMessageVersions[clientId] = new Dictionary<Type, int>();
			}
			this.m_PerClientMessageVersions[clientId][key] = version;
		}

		// Token: 0x060002DD RID: 733 RVA: 0x0000EFA0 File Offset: 0x0000D1A0
		internal void SetServerMessageOrder(NativeArray<uint> messagesInIdOrder)
		{
			NetworkMessageManager.MessageHandler[] messageHandlers = this.m_MessageHandlers;
			Dictionary<Type, uint> messageTypes = this.m_MessageTypes;
			this.m_ReverseTypeMap = new Type[messagesInIdOrder.Length];
			this.m_MessageHandlers = new NetworkMessageManager.MessageHandler[messagesInIdOrder.Length];
			this.m_MessageTypes = new Dictionary<Type, uint>();
			for (int i = 0; i < messagesInIdOrder.Length; i++)
			{
				if (this.m_MessagesByHash.ContainsKey(messagesInIdOrder[i]))
				{
					Type type = this.m_MessagesByHash[messagesInIdOrder[i]];
					uint num = messageTypes[type];
					NetworkMessageManager.MessageHandler messageHandler = messageHandlers[(int)num];
					uint num2 = (uint)i;
					this.m_MessageTypes[type] = num2;
					this.m_MessageHandlers[(int)num2] = messageHandler;
					this.m_ReverseTypeMap[(int)num2] = type;
				}
			}
		}

		// Token: 0x060002DE RID: 734 RVA: 0x0000F05C File Offset: 0x0000D25C
		public void HandleMessage(in NetworkMessageHeader header, FastBufferReader reader, ulong senderId, float timestamp, int serializedHeaderSize)
		{
			using (reader)
			{
				if (header.MessageType >= this.m_HighMessageType)
				{
					Debug.LogWarning(string.Format("Received a message with invalid message type value {0}", header.MessageType));
				}
				else
				{
					NetworkContext networkContext = new NetworkContext
					{
						SystemOwner = this.m_Owner,
						SenderId = senderId,
						Timestamp = timestamp,
						Header = header,
						SerializedHeaderSize = serializedHeaderSize,
						MessageSize = header.MessageSize
					};
					Type messageType = this.m_ReverseTypeMap[(int)header.MessageType];
					if (this.CanReceive(senderId, messageType, reader, ref networkContext))
					{
						NetworkMessageManager.MessageHandler messageHandler = this.m_MessageHandlers[(int)header.MessageType];
						for (int i = 0; i < this.m_Hooks.Count; i++)
						{
							this.m_Hooks[i].OnBeforeReceiveMessage(senderId, messageType, reader.Length + FastBufferWriter.GetWriteSize<NetworkMessageHeader>());
						}
						if (messageHandler == null)
						{
							Debug.LogException(new HandlerNotRegisteredException(header.MessageType.ToString()));
						}
						else
						{
							try
							{
								messageHandler(reader, ref networkContext, this);
							}
							catch (Exception exception)
							{
								Debug.LogException(exception);
							}
						}
						for (int j = 0; j < this.m_Hooks.Count; j++)
						{
							this.m_Hooks[j].OnAfterReceiveMessage(senderId, messageType, reader.Length + FastBufferWriter.GetWriteSize<NetworkMessageHeader>());
						}
					}
				}
			}
		}

		// Token: 0x060002DF RID: 735 RVA: 0x0000F1FC File Offset: 0x0000D3FC
		internal void ProcessIncomingMessageQueue()
		{
			if (this.StopProcessing)
			{
				return;
			}
			for (int i = 0; i < this.m_IncomingMessageQueue.Length; i++)
			{
				ref NetworkMessageManager.ReceiveQueueItem ptr = ref this.m_IncomingMessageQueue.ElementAt(i);
				this.HandleMessage(ptr.Header, ptr.Reader, ptr.SenderId, ptr.Timestamp, ptr.MessageHeaderSerializedSize);
				if (this.m_Disposed)
				{
					return;
				}
			}
			this.m_IncomingMessageQueue.Clear();
		}

		// Token: 0x060002E0 RID: 736 RVA: 0x0000F26D File Offset: 0x0000D46D
		internal void ClientConnected(ulong clientId)
		{
			if (this.m_SendQueues.ContainsKey(clientId))
			{
				return;
			}
			this.m_SendQueues[clientId] = new NativeList<NetworkMessageManager.SendQueueItem>(16, Allocator.Persistent);
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x0000F297 File Offset: 0x0000D497
		internal void ClientDisconnected(ulong clientId)
		{
			this.m_DisconnectedClients.Add(clientId);
		}

		// Token: 0x060002E2 RID: 738 RVA: 0x0000F2A8 File Offset: 0x0000D4A8
		private void CleanupDisconnectedClient(ulong clientId)
		{
			if (!this.m_SendQueues.ContainsKey(clientId))
			{
				return;
			}
			NativeList<NetworkMessageManager.SendQueueItem> nativeList = this.m_SendQueues[clientId];
			for (int i = 0; i < nativeList.Length; i++)
			{
				nativeList.ElementAt(i).Writer.Dispose();
			}
			nativeList.Dispose();
			this.m_SendQueues.Remove(clientId);
			this.m_PerClientMessageVersions.Remove(clientId);
			this.PeerMTUSizes.Remove(clientId);
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x0000F324 File Offset: 0x0000D524
		internal void CleanupDisconnectedClients()
		{
			foreach (ulong clientId in this.m_DisconnectedClients)
			{
				this.CleanupDisconnectedClient(clientId);
			}
			this.m_DisconnectedClients.Clear();
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x0000F384 File Offset: 0x0000D584
		public static int CreateMessageAndGetVersion<T>() where T : INetworkMessage, new()
		{
			T t = Activator.CreateInstance<T>();
			return t.Version;
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x0000F3A4 File Offset: 0x0000D5A4
		internal int GetMessageVersion(Type type, ulong clientId, bool forReceive = false)
		{
			Dictionary<Type, int> dictionary;
			if (!this.m_PerClientMessageVersions.TryGetValue(clientId, out dictionary))
			{
				NetworkManager singleton = NetworkManager.Singleton;
				if (singleton != null && singleton.LogLevel == LogLevel.Developer)
				{
					if (forReceive)
					{
						NetworkLog.LogWarning(string.Format("Trying to receive {0} from client {1} which is not in a connected state.", type.Name, clientId));
					}
					else
					{
						NetworkLog.LogWarning(string.Format("Trying to send {0} to client {1} which is not in a connected state.", type.Name, clientId));
					}
				}
				return -1;
			}
			int result;
			if (!dictionary.TryGetValue(type, out result))
			{
				return -1;
			}
			return result;
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x0000F424 File Offset: 0x0000D624
		public static void ReceiveMessage<T>(FastBufferReader reader, ref NetworkContext context, NetworkMessageManager manager) where T : INetworkMessage, new()
		{
			T t = Activator.CreateInstance<T>();
			int num = 0;
			if (typeof(T) != typeof(ConnectionRequestMessage) && typeof(T) != typeof(ConnectionApprovedMessage) && typeof(T) != typeof(DisconnectReasonMessage) && context.SenderId != manager.m_LocalClientId)
			{
				num = manager.GetMessageVersion(typeof(T), context.SenderId, true);
				if (num < 0)
				{
					return;
				}
			}
			if (t.Deserialize(reader, ref context, num))
			{
				for (int i = 0; i < manager.m_Hooks.Count; i++)
				{
					manager.m_Hooks[i].OnBeforeHandleMessage<T>(ref t, ref context);
				}
				t.Handle(ref context);
				for (int j = 0; j < manager.m_Hooks.Count; j++)
				{
					manager.m_Hooks[j].OnAfterHandleMessage<T>(ref t, ref context);
				}
			}
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x0000F52C File Offset: 0x0000D72C
		private bool CanSend(ulong clientId, Type messageType, NetworkDelivery delivery)
		{
			for (int i = 0; i < this.m_Hooks.Count; i++)
			{
				if (!this.m_Hooks[i].OnVerifyCanSend(clientId, messageType, delivery))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x060002E8 RID: 744 RVA: 0x0000F568 File Offset: 0x0000D768
		internal int SendMessage<TMessageType, TClientIdListType>(ref TMessageType message, NetworkDelivery delivery, in TClientIdListType clientIds) where TMessageType : INetworkMessage where TClientIdListType : IReadOnlyList<ulong>
		{
			TClientIdListType tclientIdListType = clientIds;
			if (tclientIdListType.Count == 0)
			{
				return 0;
			}
			int num = 0;
			tclientIdListType = clientIds;
			NativeHashSet<int> nativeHashSet = new NativeHashSet<int>(tclientIdListType.Count, Allocator.Temp);
			int num2 = 0;
			for (;;)
			{
				int num3 = num2;
				tclientIdListType = clientIds;
				if (num3 >= tclientIdListType.Count)
				{
					break;
				}
				int num4 = 0;
				if (!(typeof(TMessageType) != typeof(ConnectionRequestMessage)))
				{
					goto IL_90;
				}
				Type typeFromHandle = typeof(TMessageType);
				tclientIdListType = clientIds;
				num4 = this.GetMessageVersion(typeFromHandle, tclientIdListType[num2], false);
				if (num4 >= 0)
				{
					goto IL_90;
				}
				IL_122:
				num2++;
				continue;
				IL_90:
				if (!nativeHashSet.Contains(num4))
				{
					nativeHashSet.Add(num4);
					int num5 = (delivery == NetworkDelivery.ReliableFragmentedSequenced) ? this.FragmentedMessageMaxSize : this.NonFragmentedMessageMaxSize;
					FastBufferWriter writer = new FastBufferWriter(this.NonFragmentedMessageMaxSize - FastBufferWriter.GetWriteSize<NetworkMessageHeader>(), Allocator.Temp, num5 - FastBufferWriter.GetWriteSize<NetworkMessageHeader>());
					try
					{
						message.Serialize(writer, num4);
						int maxSize = num5;
						IReadOnlyList<ulong> readOnlyList = clientIds;
						int num6 = this.SendPreSerializedMessage<TMessageType>(writer, maxSize, ref message, delivery, readOnlyList, num4);
						num = ((num6 > num) ? num6 : num);
					}
					finally
					{
						((IDisposable)writer).Dispose();
					}
					goto IL_122;
				}
				goto IL_122;
			}
			nativeHashSet.Dispose();
			return num;
		}

		// Token: 0x060002E9 RID: 745 RVA: 0x0000F6D0 File Offset: 0x0000D8D0
		internal unsafe int SendPreSerializedMessage<TMessageType>(in FastBufferWriter tmpSerializer, int maxSize, ref TMessageType message, NetworkDelivery delivery, in IReadOnlyList<ulong> clientIds, int messageVersionFilter) where TMessageType : INetworkMessage
		{
			int result;
			using (FastBufferWriter writer = new FastBufferWriter(FastBufferWriter.GetWriteSize<NetworkMessageHeader>(), Allocator.Temp, -1))
			{
				NetworkMessageHeader networkMessageHeader = default(NetworkMessageHeader);
				FastBufferWriter fastBufferWriter = tmpSerializer;
				networkMessageHeader.MessageSize = (uint)fastBufferWriter.Length;
				networkMessageHeader.MessageType = this.m_MessageTypes[typeof(TMessageType)];
				NetworkMessageHeader networkMessageHeader2 = networkMessageHeader;
				BytePacker.WriteValueBitPacked(writer, networkMessageHeader2.MessageType);
				BytePacker.WriteValueBitPacked(writer, networkMessageHeader2.MessageSize);
				for (int i = 0; i < clientIds.Count; i++)
				{
					if (!this.m_DisconnectedClients.Contains(clientIds[i]))
					{
						if (typeof(TMessageType) != typeof(ConnectionRequestMessage))
						{
							int messageVersion = this.GetMessageVersion(typeof(TMessageType), clientIds[i], false);
							if (messageVersion < 0 || messageVersion != messageVersionFilter)
							{
								goto IL_375;
							}
						}
						ulong num = clientIds[i];
						if (this.CanSend(num, typeof(TMessageType), delivery))
						{
							int writerSize = this.NonFragmentedMessageMaxSize;
							if (delivery != NetworkDelivery.ReliableFragmentedSequenced)
							{
								int num2;
								if (this.PeerMTUSizes.TryGetValue(num, out num2))
								{
									maxSize = num2;
								}
								writerSize = maxSize;
								fastBufferWriter = tmpSerializer;
								if (fastBufferWriter.Position >= maxSize)
								{
									Debug.LogError(string.Format("MTU size for {0} is too small to contain a message of type {1}", num, typeof(TMessageType).FullName));
									goto IL_375;
								}
							}
							for (int j = 0; j < this.m_Hooks.Count; j++)
							{
								this.m_Hooks[j].OnBeforeSendMessage<TMessageType>(num, ref message, delivery);
							}
							NativeList<NetworkMessageManager.SendQueueItem> nativeList = this.m_SendQueues[num];
							if (nativeList.Length == 0)
							{
								NetworkMessageManager.SendQueueItem sendQueueItem = new NetworkMessageManager.SendQueueItem(delivery, writerSize, Allocator.TempJob, maxSize);
								nativeList.Add(sendQueueItem);
								nativeList.ElementAt(0).Writer.Seek(sizeof(NetworkBatchHeader));
							}
							else
							{
								ref NetworkMessageManager.SendQueueItem ptr = ref nativeList.ElementAt(nativeList.Length - 1);
								if (ptr.NetworkDelivery == delivery)
								{
									int num3 = ptr.Writer.MaxCapacity - ptr.Writer.Position;
									fastBufferWriter = tmpSerializer;
									if (num3 >= fastBufferWriter.Length + writer.Length)
									{
										goto IL_251;
									}
								}
								NetworkMessageManager.SendQueueItem sendQueueItem = new NetworkMessageManager.SendQueueItem(delivery, writerSize, Allocator.TempJob, maxSize);
								nativeList.Add(sendQueueItem);
								nativeList.ElementAt(nativeList.Length - 1).Writer.Seek(sizeof(NetworkBatchHeader));
							}
							IL_251:
							ref NetworkMessageManager.SendQueueItem ptr2 = ref nativeList.ElementAt(nativeList.Length - 1);
							ref NetworkMessageManager.SendQueueItem ptr3 = ref ptr2;
							fastBufferWriter = tmpSerializer;
							if (!ptr3.Writer.TryBeginWrite(fastBufferWriter.Length + writer.Length))
							{
								string format = "Not enough space to write message, size={0} space used={1} total size={2}";
								fastBufferWriter = tmpSerializer;
								Debug.LogError(string.Format(format, fastBufferWriter.Length + writer.Length, ptr2.Writer.Position, ptr2.Writer.Capacity));
							}
							else
							{
								ptr2.Writer.WriteBytes(writer.GetUnsafePtr(), writer.Length, 0);
								ref NetworkMessageManager.SendQueueItem ptr4 = ref ptr2;
								fastBufferWriter = tmpSerializer;
								byte* unsafePtr = fastBufferWriter.GetUnsafePtr();
								fastBufferWriter = tmpSerializer;
								ptr4.Writer.WriteBytes(unsafePtr, fastBufferWriter.Length, 0);
								ref NetworkMessageManager.SendQueueItem ptr5 = ref ptr2;
								ptr5.BatchHeader.BatchCount = ptr5.BatchHeader.BatchCount + 1;
								for (int k = 0; k < this.m_Hooks.Count; k++)
								{
									INetworkHooks networkHooks = this.m_Hooks[k];
									ulong clientId = num;
									fastBufferWriter = tmpSerializer;
									networkHooks.OnAfterSendMessage<TMessageType>(clientId, ref message, delivery, fastBufferWriter.Length + writer.Length);
								}
							}
						}
					}
					IL_375:;
				}
				fastBufferWriter = tmpSerializer;
				result = fastBufferWriter.Length + writer.Length;
			}
			return result;
		}

		// Token: 0x060002EA RID: 746 RVA: 0x0000FAB0 File Offset: 0x0000DCB0
		internal unsafe int SendPreSerializedMessage<TMessageType>(in FastBufferWriter tmpSerializer, int maxSize, ref TMessageType message, NetworkDelivery delivery, ulong clientId) where TMessageType : INetworkMessage
		{
			int num = 0;
			if (typeof(TMessageType) != typeof(ConnectionRequestMessage))
			{
				num = this.GetMessageVersion(typeof(TMessageType), clientId, false);
				if (num < 0)
				{
					return 0;
				}
			}
			IntPtr intPtr = stackalloc byte[(UIntPtr)8];
			*intPtr = (long)clientId;
			ulong* ptr = intPtr;
			IReadOnlyList<ulong> readOnlyList = new NetworkMessageManager.PointerListWrapper<ulong>(ptr, 1);
			return this.SendPreSerializedMessage<TMessageType>(tmpSerializer, maxSize, ref message, delivery, readOnlyList, num);
		}

		// Token: 0x060002EB RID: 747 RVA: 0x0000FB18 File Offset: 0x0000DD18
		internal unsafe int SendMessage<T>(ref T message, NetworkDelivery delivery, ulong* clientIds, int numClientIds) where T : INetworkMessage
		{
			NetworkMessageManager.PointerListWrapper<ulong> pointerListWrapper = new NetworkMessageManager.PointerListWrapper<ulong>(clientIds, numClientIds);
			return this.SendMessage<T, NetworkMessageManager.PointerListWrapper<ulong>>(ref message, delivery, pointerListWrapper);
		}

		// Token: 0x060002EC RID: 748 RVA: 0x0000FB38 File Offset: 0x0000DD38
		internal unsafe int SendMessage<T>(ref T message, NetworkDelivery delivery, ulong clientId) where T : INetworkMessage
		{
			IntPtr intPtr = stackalloc byte[(UIntPtr)8];
			*intPtr = (long)clientId;
			ulong* ptr = intPtr;
			NetworkMessageManager.PointerListWrapper<ulong> pointerListWrapper = new NetworkMessageManager.PointerListWrapper<ulong>(ptr, 1);
			return this.SendMessage<T, NetworkMessageManager.PointerListWrapper<ulong>>(ref message, delivery, pointerListWrapper);
		}

		// Token: 0x060002ED RID: 749 RVA: 0x0000FB60 File Offset: 0x0000DD60
		internal unsafe int SendMessage<T>(ref T message, NetworkDelivery delivery, in NativeArray<ulong> clientIds) where T : INetworkMessage
		{
			ulong* unsafePtr = (ulong*)clientIds.GetUnsafePtr<ulong>();
			NativeArray<ulong> nativeArray = clientIds;
			NetworkMessageManager.PointerListWrapper<ulong> pointerListWrapper = new NetworkMessageManager.PointerListWrapper<ulong>(unsafePtr, nativeArray.Length);
			return this.SendMessage<T, NetworkMessageManager.PointerListWrapper<ulong>>(ref message, delivery, pointerListWrapper);
		}

		// Token: 0x060002EE RID: 750 RVA: 0x0000FB98 File Offset: 0x0000DD98
		internal unsafe int SendMessage<T>(ref T message, NetworkDelivery delivery, in NativeList<ulong> clientIds) where T : INetworkMessage
		{
			ulong* unsafePtr = (ulong*)clientIds.GetUnsafePtr<ulong>();
			NativeList<ulong> nativeList = clientIds;
			NetworkMessageManager.PointerListWrapper<ulong> pointerListWrapper = new NetworkMessageManager.PointerListWrapper<ulong>(unsafePtr, nativeList.Length);
			return this.SendMessage<T, NetworkMessageManager.PointerListWrapper<ulong>>(ref message, delivery, pointerListWrapper);
		}

		// Token: 0x060002EF RID: 751 RVA: 0x0000FBD0 File Offset: 0x0000DDD0
		internal void ProcessSendQueues()
		{
			if (this.StopProcessing)
			{
				return;
			}
			foreach (KeyValuePair<ulong, NativeList<NetworkMessageManager.SendQueueItem>> keyValuePair in this.m_SendQueues)
			{
				ulong key = keyValuePair.Key;
				NativeList<NetworkMessageManager.SendQueueItem> value = keyValuePair.Value;
				for (int i = 0; i < value.Length; i++)
				{
					ref NetworkMessageManager.SendQueueItem ptr = ref value.ElementAt(i);
					if (this.m_DisconnectedClients.Contains(key))
					{
						ptr.Writer.Dispose();
					}
					else if (ptr.BatchHeader.BatchCount == 0)
					{
						ptr.Writer.Dispose();
					}
					else
					{
						for (int j = 0; j < this.m_Hooks.Count; j++)
						{
							this.m_Hooks[j].OnBeforeSendBatch(key, (int)ptr.BatchHeader.BatchCount, ptr.Writer.Length, ptr.NetworkDelivery);
						}
						ptr.Writer.Seek(0);
						int num = ptr.Writer.Length + 7 & -8;
						ptr.Writer.TryBeginWrite(num);
						ptr.BatchHeader.BatchHash = XXHash.Hash64(ptr.Writer.GetUnsafePtr() + sizeof(NetworkBatchHeader), num - sizeof(NetworkBatchHeader), 0U);
						ptr.BatchHeader.BatchSize = num;
						ptr.Writer.WriteValue<NetworkBatchHeader>(ptr.BatchHeader, default(FastBufferWriter.ForStructs));
						ptr.Writer.Seek(num);
						try
						{
							this.m_Sender.Send(key, ptr.NetworkDelivery, ptr.Writer);
							for (int k = 0; k < this.m_Hooks.Count; k++)
							{
								this.m_Hooks[k].OnAfterSendBatch(key, (int)ptr.BatchHeader.BatchCount, ptr.Writer.Length, ptr.NetworkDelivery);
							}
						}
						finally
						{
							ptr.Writer.Dispose();
						}
					}
				}
				value.Clear();
			}
		}

		// Token: 0x04000187 RID: 391
		public bool StopProcessing;

		// Token: 0x04000188 RID: 392
		private NativeList<NetworkMessageManager.ReceiveQueueItem> m_IncomingMessageQueue = new NativeList<NetworkMessageManager.ReceiveQueueItem>(16, Allocator.Persistent);

		// Token: 0x04000189 RID: 393
		private NetworkMessageManager.MessageHandler[] m_MessageHandlers = new NetworkMessageManager.MessageHandler[4];

		// Token: 0x0400018A RID: 394
		private Type[] m_ReverseTypeMap = new Type[4];

		// Token: 0x0400018B RID: 395
		private Dictionary<Type, uint> m_MessageTypes = new Dictionary<Type, uint>();

		// Token: 0x0400018C RID: 396
		private Dictionary<ulong, NativeList<NetworkMessageManager.SendQueueItem>> m_SendQueues = new Dictionary<ulong, NativeList<NetworkMessageManager.SendQueueItem>>();

		// Token: 0x0400018D RID: 397
		private HashSet<ulong> m_DisconnectedClients = new HashSet<ulong>();

		// Token: 0x0400018E RID: 398
		private Dictionary<ulong, Dictionary<Type, int>> m_PerClientMessageVersions = new Dictionary<ulong, Dictionary<Type, int>>();

		// Token: 0x0400018F RID: 399
		private Dictionary<uint, Type> m_MessagesByHash = new Dictionary<uint, Type>();

		// Token: 0x04000190 RID: 400
		private Dictionary<Type, int> m_LocalVersions = new Dictionary<Type, int>();

		// Token: 0x04000191 RID: 401
		private List<INetworkHooks> m_Hooks = new List<INetworkHooks>();

		// Token: 0x04000192 RID: 402
		private uint m_HighMessageType;

		// Token: 0x04000193 RID: 403
		private object m_Owner;

		// Token: 0x04000194 RID: 404
		private INetworkMessageSender m_Sender;

		// Token: 0x04000195 RID: 405
		private bool m_Disposed;

		// Token: 0x04000196 RID: 406
		private ulong m_LocalClientId;

		// Token: 0x04000197 RID: 407
		public const int DefaultNonFragmentedMessageMaxSize = 1296;

		// Token: 0x04000198 RID: 408
		public int NonFragmentedMessageMaxSize = 1296;

		// Token: 0x04000199 RID: 409
		public int FragmentedMessageMaxSize = int.MaxValue;

		// Token: 0x0400019A RID: 410
		public Dictionary<ulong, int> PeerMTUSizes = new Dictionary<ulong, int>();

		// Token: 0x0200007B RID: 123
		private struct ReceiveQueueItem
		{
			// Token: 0x0400019B RID: 411
			public FastBufferReader Reader;

			// Token: 0x0400019C RID: 412
			public NetworkMessageHeader Header;

			// Token: 0x0400019D RID: 413
			public ulong SenderId;

			// Token: 0x0400019E RID: 414
			public float Timestamp;

			// Token: 0x0400019F RID: 415
			public int MessageHeaderSerializedSize;
		}

		// Token: 0x0200007C RID: 124
		private struct SendQueueItem
		{
			// Token: 0x060002F0 RID: 752 RVA: 0x0000FE24 File Offset: 0x0000E024
			public SendQueueItem(NetworkDelivery delivery, int writerSize, Allocator writerAllocator, int maxWriterSize = -1)
			{
				this.Writer = new FastBufferWriter(writerSize, writerAllocator, maxWriterSize);
				this.NetworkDelivery = delivery;
				this.BatchHeader = new NetworkBatchHeader
				{
					Magic = 4448
				};
			}

			// Token: 0x040001A0 RID: 416
			public NetworkBatchHeader BatchHeader;

			// Token: 0x040001A1 RID: 417
			public FastBufferWriter Writer;

			// Token: 0x040001A2 RID: 418
			public readonly NetworkDelivery NetworkDelivery;
		}

		// Token: 0x0200007D RID: 125
		// (Invoke) Token: 0x060002F2 RID: 754
		internal delegate void MessageHandler(FastBufferReader reader, ref NetworkContext context, NetworkMessageManager manager);

		// Token: 0x0200007E RID: 126
		// (Invoke) Token: 0x060002F6 RID: 758
		internal delegate int VersionGetter();

		// Token: 0x0200007F RID: 127
		internal struct MessageWithHandler
		{
			// Token: 0x040001A3 RID: 419
			public Type MessageType;

			// Token: 0x040001A4 RID: 420
			public NetworkMessageManager.MessageHandler Handler;

			// Token: 0x040001A5 RID: 421
			public NetworkMessageManager.VersionGetter GetVersion;
		}

		// Token: 0x02000080 RID: 128
		private struct PointerListWrapper<[IsUnmanaged] T> : IReadOnlyList<T>, IEnumerable<T>, IEnumerable, IReadOnlyCollection<T> where T : struct, ValueType
		{
			// Token: 0x060002F9 RID: 761 RVA: 0x0000FE62 File Offset: 0x0000E062
			internal unsafe PointerListWrapper(T* ptr, int length)
			{
				this.m_Value = ptr;
				this.m_Length = length;
			}

			// Token: 0x17000077 RID: 119
			// (get) Token: 0x060002FA RID: 762 RVA: 0x0000FE72 File Offset: 0x0000E072
			public int Count
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get
				{
					return this.m_Length;
				}
			}

			// Token: 0x17000078 RID: 120
			public unsafe T this[int index]
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get
				{
					return this.m_Value[(IntPtr)index * (IntPtr)sizeof(T) / (IntPtr)sizeof(T)];
				}
			}

			// Token: 0x060002FC RID: 764 RVA: 0x0000FE91 File Offset: 0x0000E091
			public IEnumerator<T> GetEnumerator()
			{
				throw new NotImplementedException();
			}

			// Token: 0x060002FD RID: 765 RVA: 0x0000FE98 File Offset: 0x0000E098
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.GetEnumerator();
			}

			// Token: 0x040001A6 RID: 422
			private unsafe T* m_Value;

			// Token: 0x040001A7 RID: 423
			private int m_Length;
		}
	}
}
