using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections;
using UnityEngine;

namespace Unity.Netcode
{
	// Token: 0x02000068 RID: 104
	internal struct NetworkVariableDeltaMessage : INetworkMessage
	{
		// Token: 0x17000067 RID: 103
		// (get) Token: 0x06000285 RID: 645 RVA: 0x0000C36D File Offset: 0x0000A56D
		public int Version
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x06000286 RID: 646 RVA: 0x0000CEB8 File Offset: 0x0000B0B8
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void WriteNetworkVariable(ref FastBufferWriter writer, ref NetworkVariableBase networkVariable, bool ensureNetworkVariableLengthSafety, int nonfragmentedSize, int fragmentedSize)
		{
			if (!ensureNetworkVariableLengthSafety)
			{
				networkVariable.WriteDelta(writer);
				return;
			}
			FastBufferWriter writer2 = new FastBufferWriter(nonfragmentedSize, Allocator.Temp, fragmentedSize);
			networkVariable.WriteDelta(writer2);
			BytePacker.WriteValueBitPacked(writer, writer2.Length);
			if (!writer.TryBeginWrite(writer2.Length))
			{
				throw new OverflowException("Not enough space in the buffer to write NetworkVariableDeltaMessage");
			}
			writer2.CopyTo(writer);
		}

		// Token: 0x06000287 RID: 647 RVA: 0x0000CF24 File Offset: 0x0000B124
		public void Serialize(FastBufferWriter writer, int targetVersion)
		{
			if (!writer.TryBeginWrite(FastBufferWriter.GetWriteSize<ulong>(this.NetworkObjectId, default(FastBufferWriter.ForStructs)) + FastBufferWriter.GetWriteSize<ushort>(this.NetworkBehaviourIndex, default(FastBufferWriter.ForStructs))))
			{
				throw new OverflowException("Not enough space in the buffer to write NetworkVariableDeltaMessage");
			}
			NetworkObject networkObject = this.NetworkBehaviour.NetworkObject;
			NetworkManager networkManagerOwner = networkObject.NetworkManagerOwner;
			string networkBehaviourName = this.NetworkBehaviour.__getTypeName();
			int nonFragmentedMessageMaxSize = networkManagerOwner.MessageManager.NonFragmentedMessageMaxSize;
			int fragmentedMessageMaxSize = networkManagerOwner.MessageManager.FragmentedMessageMaxSize;
			bool ensureNetworkVariableLengthSafety = networkManagerOwner.NetworkConfig.EnsureNetworkVariableLengthSafety;
			BytePacker.WriteValueBitPacked(writer, this.NetworkObjectId);
			BytePacker.WriteValueBitPacked(writer, this.NetworkBehaviourIndex);
			if (targetVersion >= 1)
			{
				writer.WriteValueSafe<NetworkDelivery>(this.NetworkDelivery, default(FastBufferWriter.ForEnums));
				if (this.m_ForwardingMessage)
				{
					for (int i = 0; i < this.NetworkBehaviour.NetworkVariableFields.Count; i++)
					{
						int length = writer.Length;
						NetworkVariableBase networkVariableBase = this.NetworkBehaviour.NetworkVariableFields[i];
						bool flag = this.m_ForwardUpdates[this.TargetClientId].Contains(i);
						if (ensureNetworkVariableLengthSafety)
						{
							if (!flag)
							{
								BytePacker.WriteValueBitPacked(writer, 0);
							}
						}
						else
						{
							writer.WriteValueSafe<bool>(flag, default(FastBufferWriter.ForPrimitives));
						}
						if (flag)
						{
							this.WriteNetworkVariable(ref writer, ref networkVariableBase, ensureNetworkVariableLengthSafety, nonFragmentedMessageMaxSize, fragmentedMessageMaxSize);
							networkManagerOwner.NetworkMetrics.TrackNetworkVariableDeltaSent(this.TargetClientId, networkObject, networkVariableBase.Name, networkBehaviourName, (long)(writer.Length - length));
						}
					}
					return;
				}
			}
			for (int j = 0; j < this.NetworkBehaviour.NetworkVariableFields.Count; j++)
			{
				if (!this.DeliveryMappedNetworkVariableIndex.Contains(j))
				{
					if (ensureNetworkVariableLengthSafety)
					{
						BytePacker.WriteValueBitPacked(writer, 0);
					}
					else
					{
						bool flag2 = false;
						writer.WriteValueSafe<bool>(flag2, default(FastBufferWriter.ForPrimitives));
					}
				}
				else
				{
					int length2 = writer.Length;
					NetworkVariableBase networkVariableBase2 = this.NetworkBehaviour.NetworkVariableFields[j];
					bool flag3 = networkVariableBase2.IsDirty() && networkVariableBase2.CanClientRead(this.TargetClientId) && (networkManagerOwner.IsServer || networkVariableBase2.CanClientWrite(networkManagerOwner.LocalClientId)) && networkVariableBase2.CanSend();
					if (networkVariableBase2.WritePerm == NetworkVariableWritePermission.Owner && networkVariableBase2.OwnerClientId() == this.TargetClientId)
					{
						flag3 = false;
					}
					if (networkManagerOwner.SpawnManager.ObjectsToShowToClient.ContainsKey(this.TargetClientId) && networkManagerOwner.SpawnManager.ObjectsToShowToClient[this.TargetClientId].Contains(networkObject))
					{
						flag3 = false;
					}
					if (ensureNetworkVariableLengthSafety)
					{
						if (!flag3)
						{
							BytePacker.WriteValueBitPacked(writer, 0);
						}
					}
					else
					{
						writer.WriteValueSafe<bool>(flag3, default(FastBufferWriter.ForPrimitives));
					}
					if (flag3)
					{
						this.WriteNetworkVariable(ref writer, ref networkVariableBase2, ensureNetworkVariableLengthSafety, nonFragmentedMessageMaxSize, fragmentedMessageMaxSize);
						networkManagerOwner.NetworkMetrics.TrackNetworkVariableDeltaSent(this.TargetClientId, networkObject, networkVariableBase2.Name, networkBehaviourName, (long)(writer.Length - length2));
					}
				}
			}
		}

		// Token: 0x06000288 RID: 648 RVA: 0x0000D218 File Offset: 0x0000B418
		public bool Deserialize(FastBufferReader reader, ref NetworkContext context, int receivedMessageVersion)
		{
			this.m_ReceivedMessageVersion = receivedMessageVersion;
			ByteUnpacker.ReadValueBitPacked(reader, out this.NetworkObjectId);
			ByteUnpacker.ReadValueBitPacked(reader, out this.NetworkBehaviourIndex);
			if (receivedMessageVersion >= 1)
			{
				reader.ReadValueSafe<NetworkDelivery>(out this.NetworkDelivery, default(FastBufferWriter.ForEnums));
			}
			this.m_ReceivedNetworkVariableData = reader;
			return true;
		}

		// Token: 0x06000289 RID: 649 RVA: 0x0000D268 File Offset: 0x0000B468
		public void Handle(ref NetworkContext context)
		{
			NetworkManager networkManager = (NetworkManager)context.SystemOwner;
			NetworkObject networkObject;
			if (networkManager.SpawnManager.SpawnedObjects.TryGetValue(this.NetworkObjectId, out networkObject))
			{
				bool ensureNetworkVariableLengthSafety = networkManager.NetworkConfig.EnsureNetworkVariableLengthSafety;
				NetworkBehaviour networkBehaviourAtOrderIndex = networkObject.GetNetworkBehaviourAtOrderIndex(this.NetworkBehaviourIndex);
				bool flag = this.m_ReceivedMessageVersion >= 1 && networkManager.IsServer;
				bool keepDirtyDelta = this.m_ReceivedMessageVersion < 1 && networkManager.IsServer;
				this.m_UpdatedNetworkVariables = new List<int>();
				if (networkBehaviourAtOrderIndex == null)
				{
					if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
					{
						NetworkLog.LogWarning(string.Format("Network variable delta message received for a non-existent behaviour. {0}: {1}, {2}: {3}", new object[]
						{
							"NetworkObjectId",
							this.NetworkObjectId,
							"NetworkBehaviourIndex",
							this.NetworkBehaviourIndex
						}));
						return;
					}
					return;
				}
				else
				{
					if (flag)
					{
						this.m_ForwardUpdates = new Dictionary<ulong, List<int>>();
						foreach (ulong num in networkManager.ConnectedClientsIds)
						{
							if (num != context.SenderId && num != networkManager.LocalClientId && networkObject.Observers.Contains(num))
							{
								this.m_ForwardUpdates.Add(num, new List<int>());
							}
						}
					}
					int i = 0;
					while (i < networkBehaviourAtOrderIndex.NetworkVariableFields.Count)
					{
						int num2 = 0;
						NetworkVariableBase networkVariableBase = networkBehaviourAtOrderIndex.NetworkVariableFields[i];
						if (ensureNetworkVariableLengthSafety)
						{
							ByteUnpacker.ReadValueBitPacked(this.m_ReceivedNetworkVariableData, out num2);
							if (num2 != 0)
							{
								goto IL_18F;
							}
						}
						else
						{
							bool flag2;
							this.m_ReceivedNetworkVariableData.ReadValueSafe<bool>(out flag2, default(FastBufferWriter.ForPrimitives));
							if (flag2)
							{
								goto IL_18F;
							}
						}
						IL_543:
						i++;
						continue;
						IL_18F:
						if (networkManager.IsServer && !networkVariableBase.CanClientWrite(context.SenderId))
						{
							if (networkManager.NetworkConfig.EnsureNetworkVariableLengthSafety)
							{
								if (NetworkLog.CurrentLogLevel <= LogLevel.Developer)
								{
									NetworkLog.LogWarning(string.Format("Client wrote to {0} without permission. => {1}: {2} - {3}(): {4} - VariableIndex: {5}", new object[]
									{
										typeof(NetworkVariable<>).Name,
										"NetworkObjectId",
										this.NetworkObjectId,
										"GetNetworkBehaviourOrderIndex",
										networkObject.GetNetworkBehaviourOrderIndex(networkBehaviourAtOrderIndex),
										i
									}));
									NetworkLog.LogError("[" + networkVariableBase.GetType().Name + "]");
								}
								this.m_ReceivedNetworkVariableData.Seek(this.m_ReceivedNetworkVariableData.Position + num2);
								goto IL_543;
							}
							if (NetworkLog.CurrentLogLevel <= LogLevel.Developer)
							{
								NetworkLog.LogError(string.Format("Client wrote to {0} without permission. No more variables can be read. This is critical. => {1}: {2} - {3}(): {4} - VariableIndex: {5}", new object[]
								{
									typeof(NetworkVariable<>).Name,
									"NetworkObjectId",
									this.NetworkObjectId,
									"GetNetworkBehaviourOrderIndex",
									networkObject.GetNetworkBehaviourOrderIndex(networkBehaviourAtOrderIndex),
									i
								}));
								NetworkLog.LogError("[" + networkVariableBase.GetType().Name + "]");
							}
							return;
						}
						else
						{
							int position = this.m_ReceivedNetworkVariableData.Position;
							if (ensureNetworkVariableLengthSafety)
							{
								int num3 = this.m_ReceivedNetworkVariableData.Length - this.m_ReceivedNetworkVariableData.Position;
								if (num2 > num3)
								{
									Debug.LogError(string.Format("[{0}][Delta State Read Error] Expecting to read {1} but only {2} remains!", networkBehaviourAtOrderIndex.name, num2, num3));
									return;
								}
							}
							try
							{
								networkVariableBase.ReadDelta(this.m_ReceivedNetworkVariableData, keepDirtyDelta);
								this.m_UpdatedNetworkVariables.Add(i);
							}
							catch (Exception exception)
							{
								Debug.LogException(exception);
								return;
							}
							if (flag)
							{
								foreach (KeyValuePair<ulong, List<int>> keyValuePair in this.m_ForwardUpdates)
								{
									if (networkVariableBase.CanClientRead(keyValuePair.Key) && (!networkManager.SpawnManager.ObjectsToShowToClient.ContainsKey(keyValuePair.Key) || !networkManager.SpawnManager.ObjectsToShowToClient[keyValuePair.Key].Contains(networkObject)))
									{
										keyValuePair.Value.Add(i);
									}
								}
							}
							networkManager.NetworkMetrics.TrackNetworkVariableDeltaReceived(context.SenderId, networkObject, networkVariableBase.Name, networkBehaviourAtOrderIndex.__getTypeName(), (long)((ulong)context.MessageSize));
							if (!ensureNetworkVariableLengthSafety)
							{
								goto IL_543;
							}
							if (this.m_ReceivedNetworkVariableData.Position > position + num2)
							{
								if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
								{
									NetworkLog.LogWarning(string.Format("Var delta read too far. {0} bytes. => {1}: {2} - {3}(): {4} - VariableIndex: {5}", new object[]
									{
										this.m_ReceivedNetworkVariableData.Position - (position + num2),
										"NetworkObjectId",
										this.NetworkObjectId,
										"GetNetworkBehaviourOrderIndex",
										networkObject.GetNetworkBehaviourOrderIndex(networkBehaviourAtOrderIndex),
										i
									}));
								}
								this.m_ReceivedNetworkVariableData.Seek(position + num2);
								goto IL_543;
							}
							if (this.m_ReceivedNetworkVariableData.Position < position + num2)
							{
								if (NetworkLog.CurrentLogLevel <= LogLevel.Normal)
								{
									NetworkLog.LogWarning(string.Format("Var delta read too little. {0} bytes. => {1}: {2} - {3}(): {4} - VariableIndex: {5}", new object[]
									{
										position + num2 - this.m_ReceivedNetworkVariableData.Position,
										"NetworkObjectId",
										this.NetworkObjectId,
										"GetNetworkBehaviourOrderIndex",
										networkObject.GetNetworkBehaviourOrderIndex(networkBehaviourAtOrderIndex),
										i
									}));
								}
								this.m_ReceivedNetworkVariableData.Seek(position + num2);
								goto IL_543;
							}
							goto IL_543;
						}
					}
					if (flag)
					{
						NetworkVariableDeltaMessage networkVariableDeltaMessage = new NetworkVariableDeltaMessage
						{
							NetworkBehaviour = networkBehaviourAtOrderIndex,
							NetworkBehaviourIndex = this.NetworkBehaviourIndex,
							NetworkObjectId = this.NetworkObjectId,
							m_ForwardingMessage = true,
							m_ForwardUpdates = this.m_ForwardUpdates
						};
						foreach (KeyValuePair<ulong, List<int>> keyValuePair2 in this.m_ForwardUpdates)
						{
							if (keyValuePair2.Value.Count > 0)
							{
								networkVariableDeltaMessage.TargetClientId = keyValuePair2.Key;
								networkManager.ConnectionManager.SendMessage<NetworkVariableDeltaMessage>(ref networkVariableDeltaMessage, this.NetworkDelivery, keyValuePair2.Key);
							}
						}
					}
					using (List<int>.Enumerator enumerator3 = this.m_UpdatedNetworkVariables.GetEnumerator())
					{
						while (enumerator3.MoveNext())
						{
							int index = enumerator3.Current;
							networkBehaviourAtOrderIndex.NetworkVariableFields[index].PostDeltaRead();
						}
						return;
					}
				}
			}
			networkManager.DeferredMessageManager.DeferMessage(IDeferredNetworkMessageManager.TriggerType.OnSpawn, this.NetworkObjectId, this.m_ReceivedNetworkVariableData, ref context);
		}

		// Token: 0x0400014F RID: 335
		private const int k_ServerDeltaForwardingAndNetworkDelivery = 1;

		// Token: 0x04000150 RID: 336
		public ulong NetworkObjectId;

		// Token: 0x04000151 RID: 337
		public ushort NetworkBehaviourIndex;

		// Token: 0x04000152 RID: 338
		public HashSet<int> DeliveryMappedNetworkVariableIndex;

		// Token: 0x04000153 RID: 339
		public ulong TargetClientId;

		// Token: 0x04000154 RID: 340
		public NetworkBehaviour NetworkBehaviour;

		// Token: 0x04000155 RID: 341
		public NetworkDelivery NetworkDelivery;

		// Token: 0x04000156 RID: 342
		private FastBufferReader m_ReceivedNetworkVariableData;

		// Token: 0x04000157 RID: 343
		private bool m_ForwardingMessage;

		// Token: 0x04000158 RID: 344
		private int m_ReceivedMessageVersion;

		// Token: 0x04000159 RID: 345
		private const string k_Name = "NetworkVariableDeltaMessage";

		// Token: 0x0400015A RID: 346
		private Dictionary<ulong, List<int>> m_ForwardUpdates;

		// Token: 0x0400015B RID: 347
		private List<int> m_UpdatedNetworkVariables;
	}
}
