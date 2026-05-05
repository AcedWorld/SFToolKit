using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

namespace Unity.Netcode
{
	// Token: 0x0200006B RID: 107
	internal static class RpcMessageHelpers
	{
		// Token: 0x06000298 RID: 664 RVA: 0x0000DDCC File Offset: 0x0000BFCC
		public static void Serialize(ref FastBufferWriter writer, ref RpcMetadata metadata, ref FastBufferWriter payload)
		{
			BytePacker.WriteValueBitPacked(writer, metadata.NetworkObjectId);
			BytePacker.WriteValueBitPacked(writer, metadata.NetworkBehaviourId);
			BytePacker.WriteValueBitPacked(writer, metadata.NetworkRpcMethodId);
			writer.WriteBytesSafe(payload.GetUnsafePtr(), payload.Length, 0);
		}

		// Token: 0x06000299 RID: 665 RVA: 0x0000DE20 File Offset: 0x0000C020
		public static bool Deserialize(ref FastBufferReader reader, ref NetworkContext context, ref RpcMetadata metadata, ref FastBufferReader payload)
		{
			ByteUnpacker.ReadValueBitPacked(reader, out metadata.NetworkObjectId);
			ByteUnpacker.ReadValueBitPacked(reader, out metadata.NetworkBehaviourId);
			ByteUnpacker.ReadValueBitPacked(reader, out metadata.NetworkRpcMethodId);
			NetworkManager networkManager = (NetworkManager)context.SystemOwner;
			if (!networkManager.SpawnManager.SpawnedObjects.ContainsKey(metadata.NetworkObjectId))
			{
				networkManager.DeferredMessageManager.DeferMessage(IDeferredNetworkMessageManager.TriggerType.OnSpawn, metadata.NetworkObjectId, reader, ref context);
				return false;
			}
			NetworkObject networkObject = networkManager.SpawnManager.SpawnedObjects[metadata.NetworkObjectId];
			NetworkBehaviour networkBehaviourAtOrderIndex = networkManager.SpawnManager.SpawnedObjects[metadata.NetworkObjectId].GetNetworkBehaviourAtOrderIndex(metadata.NetworkBehaviourId);
			if (networkBehaviourAtOrderIndex == null)
			{
				return false;
			}
			if (!NetworkBehaviour.__rpc_func_table[networkBehaviourAtOrderIndex.GetType()].ContainsKey(metadata.NetworkRpcMethodId))
			{
				return false;
			}
			payload = new FastBufferReader(reader.GetUnsafePtrAtCurrentPosition(), Allocator.None, reader.Length - reader.Position, 0, Allocator.Temp);
			return true;
		}

		// Token: 0x0600029A RID: 666 RVA: 0x0000DF24 File Offset: 0x0000C124
		public static void Handle(ref NetworkContext context, ref RpcMetadata metadata, ref FastBufferReader payload, ref __RpcParams rpcParams)
		{
			NetworkManager networkManager = (NetworkManager)context.SystemOwner;
			NetworkObject networkObject;
			if (!networkManager.SpawnManager.SpawnedObjects.TryGetValue(metadata.NetworkObjectId, out networkObject))
			{
				if (networkManager.LogLevel == LogLevel.Developer)
				{
					NetworkLog.LogWarning(string.Format("[{0}, {1}, {2}] An RPC called on a {3} that is not in the spawned objects list. Please make sure the {4} is spawned before calling RPCs.", new object[]
					{
						metadata.NetworkObjectId,
						metadata.NetworkBehaviourId,
						metadata.NetworkRpcMethodId,
						"NetworkObject",
						"NetworkObject"
					}));
				}
				return;
			}
			NetworkBehaviour networkBehaviourAtOrderIndex = networkObject.GetNetworkBehaviourAtOrderIndex(metadata.NetworkBehaviourId);
			try
			{
				NetworkBehaviour.__rpc_func_table[networkBehaviourAtOrderIndex.GetType()][metadata.NetworkRpcMethodId](networkBehaviourAtOrderIndex, payload, rpcParams);
			}
			catch (Exception innerException)
			{
				Debug.LogException(new Exception("Unhandled RPC exception!", innerException));
				if (networkManager.LogLevel == LogLevel.Developer)
				{
					Debug.Log("RPC Table Contents");
					foreach (KeyValuePair<uint, NetworkBehaviour.RpcReceiveHandler> keyValuePair in NetworkBehaviour.__rpc_func_table[networkBehaviourAtOrderIndex.GetType()])
					{
						Debug.Log(string.Format("{0} | {1}", keyValuePair.Key, keyValuePair.Value.Method.Name));
					}
				}
			}
		}
	}
}
