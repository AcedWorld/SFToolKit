using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Unity.Netcode
{
	// Token: 0x020000F0 RID: 240
	internal class SceneEventData : IDisposable
	{
		// Token: 0x060005D8 RID: 1496 RVA: 0x00019CF6 File Offset: 0x00017EF6
		internal void AddSceneToSynchronize(uint sceneHash, int sceneHandle)
		{
			this.ScenesToSynchronize.Enqueue(sceneHash);
			this.SceneHandlesToSynchronize.Enqueue((uint)sceneHandle);
		}

		// Token: 0x060005D9 RID: 1497 RVA: 0x00019D10 File Offset: 0x00017F10
		internal uint GetNextSceneSynchronizationHash()
		{
			return this.ScenesToSynchronize.Dequeue();
		}

		// Token: 0x060005DA RID: 1498 RVA: 0x00019D1D File Offset: 0x00017F1D
		internal int GetNextSceneSynchronizationHandle()
		{
			return (int)this.SceneHandlesToSynchronize.Dequeue();
		}

		// Token: 0x060005DB RID: 1499 RVA: 0x00019D2C File Offset: 0x00017F2C
		internal bool IsDoneWithSynchronization()
		{
			if (this.ScenesToSynchronize.Count == 0 && this.SceneHandlesToSynchronize.Count == 0)
			{
				return true;
			}
			if (this.ScenesToSynchronize.Count != this.SceneHandlesToSynchronize.Count)
			{
				throw new Exception("[SceneEventData-Internal Mismatch Error] ScenesToSynchronize count != SceneHandlesToSynchronize count!");
			}
			return false;
		}

		// Token: 0x060005DC RID: 1500 RVA: 0x00019D7C File Offset: 0x00017F7C
		internal void InitializeForSynch()
		{
			if (this.m_SceneNetworkObjects == null)
			{
				this.m_SceneNetworkObjects = new Dictionary<uint, List<NetworkObject>>();
			}
			else
			{
				this.m_SceneNetworkObjects.Clear();
			}
			if (this.ScenesToSynchronize == null)
			{
				this.ScenesToSynchronize = new Queue<uint>();
			}
			else
			{
				this.ScenesToSynchronize.Clear();
			}
			if (this.SceneHandlesToSynchronize == null)
			{
				this.SceneHandlesToSynchronize = new Queue<uint>();
				return;
			}
			this.SceneHandlesToSynchronize.Clear();
		}

		// Token: 0x060005DD RID: 1501 RVA: 0x00019DE8 File Offset: 0x00017FE8
		private int SortChildrenNetworkObjects(NetworkObject first, NetworkObject second)
		{
			Transform cachedParent = first.GetCachedParent();
			NetworkObject x = (cachedParent != null) ? cachedParent.GetComponent<NetworkObject>() : null;
			if (x != null && x == second)
			{
				return 1;
			}
			Transform cachedParent2 = second.GetCachedParent();
			NetworkObject x2 = (cachedParent2 != null) ? cachedParent2.GetComponent<NetworkObject>() : null;
			if (x2 != null && x2 == first)
			{
				return -1;
			}
			return 0;
		}

		// Token: 0x060005DE RID: 1502 RVA: 0x00019E44 File Offset: 0x00018044
		private void SortParentedNetworkObjects()
		{
			foreach (NetworkObject networkObject in this.m_NetworkObjectsSync.ToList<NetworkObject>())
			{
				if (networkObject.transform.childCount > 0 && networkObject.transform.parent == null)
				{
					List<NetworkObject> list = networkObject.GetComponentsInChildren<NetworkObject>().ToList<NetworkObject>();
					list.Sort(new Comparison<NetworkObject>(this.SortChildrenNetworkObjects));
					list.Remove(networkObject);
					foreach (NetworkObject item in list)
					{
						this.m_NetworkObjectsSync.Remove(item);
					}
					int num = this.m_NetworkObjectsSync.IndexOf(networkObject) + 1;
					if (num == this.m_NetworkObjectsSync.Count)
					{
						this.m_NetworkObjectsSync.AddRange(list);
					}
					else
					{
						this.m_NetworkObjectsSync.InsertRange(num, list);
					}
				}
			}
		}

		// Token: 0x060005DF RID: 1503 RVA: 0x00019F68 File Offset: 0x00018168
		internal void AddSpawnedNetworkObjects()
		{
			this.m_NetworkObjectsSync.Clear();
			foreach (NetworkObject networkObject in this.m_NetworkManager.SpawnManager.SpawnedObjectsList)
			{
				if (networkObject.Observers.Contains(this.TargetClientId))
				{
					this.m_NetworkObjectsSync.Add(networkObject);
				}
			}
			this.m_NetworkObjectsSync.Sort(new Comparison<NetworkObject>(this.SortNetworkObjects));
			this.SortParentedNetworkObjects();
			if (SceneEventData.LogSerializationOrder && this.m_NetworkManager.LogLevel == LogLevel.Developer)
			{
				StringBuilder stringBuilder = new StringBuilder(65535);
				stringBuilder.AppendLine("[Server-Side Client-Synchronization] NetworkObject serialization order:");
				foreach (NetworkObject networkObject2 in this.m_NetworkObjectsSync)
				{
					stringBuilder.AppendLine(networkObject2.name ?? "");
				}
				NetworkLog.LogInfo(stringBuilder.ToString());
			}
		}

		// Token: 0x060005E0 RID: 1504 RVA: 0x0001A090 File Offset: 0x00018290
		internal void AddDespawnedInSceneNetworkObjects()
		{
			this.m_DespawnedInSceneObjectsSync.Clear();
			foreach (NetworkObject networkObject in from c in Object.FindObjectsOfType<NetworkObject>(true)
			where c.NetworkManager == this.m_NetworkManager
			select c)
			{
				if (networkObject.IsSceneObject != null && networkObject.IsSceneObject.Value && !networkObject.IsSpawned)
				{
					this.m_DespawnedInSceneObjectsSync.Add(networkObject);
				}
			}
		}

		// Token: 0x060005E1 RID: 1505 RVA: 0x0001A128 File Offset: 0x00018328
		internal void AddNetworkObjectForSynch(uint sceneIndex, NetworkObject networkObject)
		{
			if (!this.m_SceneNetworkObjects.ContainsKey(sceneIndex))
			{
				this.m_SceneNetworkObjects.Add(sceneIndex, new List<NetworkObject>());
			}
			this.m_SceneNetworkObjects[sceneIndex].Add(networkObject);
		}

		// Token: 0x060005E2 RID: 1506 RVA: 0x0001A15C File Offset: 0x0001835C
		internal bool IsSceneEventClientSide()
		{
			SceneEventType sceneEventType = this.SceneEventType;
			return sceneEventType <= SceneEventType.UnloadEventCompleted || sceneEventType - SceneEventType.ActiveSceneChanged <= 1;
		}

		// Token: 0x060005E3 RID: 1507 RVA: 0x0001A180 File Offset: 0x00018380
		private int SortNetworkObjects(NetworkObject first, NetworkObject second)
		{
			bool flag = this.m_NetworkManager.PrefabHandler.ContainsHandler(first);
			bool flag2 = this.m_NetworkManager.PrefabHandler.ContainsHandler(second);
			if (flag == flag2)
			{
				return 0;
			}
			if (flag)
			{
				return 1;
			}
			return -1;
		}

		// Token: 0x060005E4 RID: 1508 RVA: 0x0001A1C0 File Offset: 0x000183C0
		internal void Serialize(FastBufferWriter writer)
		{
			writer.WriteValueSafe<SceneEventType>(this.SceneEventType, default(FastBufferWriter.ForEnums));
			if (this.SceneEventType == SceneEventType.ActiveSceneChanged)
			{
				writer.WriteValueSafe<uint>(this.ActiveSceneHash, default(FastBufferWriter.ForPrimitives));
				return;
			}
			if (this.SceneEventType == SceneEventType.ObjectSceneChanged)
			{
				this.SerializeObjectsMovedIntoNewScene(writer);
				return;
			}
			byte b = (byte)this.LoadSceneMode;
			writer.WriteValueSafe<byte>(b, default(FastBufferWriter.ForPrimitives));
			if (this.SceneEventType != SceneEventType.Synchronize)
			{
				writer.WriteValueSafe<ForceNetworkSerializeByMemcpy<Guid>>(this.SceneEventProgressId, default(FastBufferWriter.ForStructs));
			}
			else
			{
				writer.WriteValueSafe<LoadSceneMode>(this.ClientSynchronizationMode, default(FastBufferWriter.ForEnums));
			}
			writer.WriteValueSafe<uint>(this.SceneHash, default(FastBufferWriter.ForPrimitives));
			writer.WriteValueSafe<int>(this.SceneHandle, default(FastBufferWriter.ForPrimitives));
			switch (this.SceneEventType)
			{
			case SceneEventType.Load:
				this.SerializeScenePlacedObjects(writer);
				return;
			case SceneEventType.Unload:
			case SceneEventType.LoadComplete:
			case SceneEventType.UnloadComplete:
				break;
			case SceneEventType.Synchronize:
				writer.WriteValueSafe<uint>(this.ActiveSceneHash, default(FastBufferWriter.ForPrimitives));
				this.WriteSceneSynchronizationData(writer);
				return;
			case SceneEventType.ReSynchronize:
				this.WriteClientReSynchronizationData(writer);
				return;
			case SceneEventType.LoadEventCompleted:
			case SceneEventType.UnloadEventCompleted:
				this.WriteSceneEventProgressDone(writer);
				break;
			case SceneEventType.SynchronizeComplete:
				this.WriteClientSynchronizationResults(writer);
				return;
			default:
				return;
			}
		}

		// Token: 0x060005E5 RID: 1509 RVA: 0x0001A304 File Offset: 0x00018504
		internal void WriteSceneSynchronizationData(FastBufferWriter writer)
		{
			writer.WriteValueSafe<uint>(this.ScenesToSynchronize.ToArray(), default(FastBufferWriter.ForPrimitives));
			writer.WriteValueSafe<uint>(this.SceneHandlesToSynchronize.ToArray(), default(FastBufferWriter.ForPrimitives));
			int position = writer.Position;
			int num = 0;
			writer.WriteValueSafe<int>(num, default(FastBufferWriter.ForPrimitives));
			int num2 = 0;
			num = this.m_NetworkObjectsSync.Count;
			writer.WriteValueSafe<int>(num, default(FastBufferWriter.ForPrimitives));
			for (int i = 0; i < this.m_NetworkObjectsSync.Count; i++)
			{
				int position2 = writer.Position;
				this.m_NetworkObjectsSync[i].GetMessageSceneObject(this.TargetClientId).Serialize(writer);
				int position3 = writer.Position;
				num2 += position3 - position2;
			}
			num = this.m_DespawnedInSceneObjectsSync.Count;
			writer.WriteValueSafe<int>(num, default(FastBufferWriter.ForPrimitives));
			for (int j = 0; j < this.m_DespawnedInSceneObjectsSync.Count; j++)
			{
				int position4 = writer.Position;
				num = this.m_DespawnedInSceneObjectsSync[j].GetSceneOriginHandle();
				writer.WriteValueSafe<int>(num, default(FastBufferWriter.ForPrimitives));
				writer.WriteValueSafe<uint>(this.m_DespawnedInSceneObjectsSync[j].GlobalObjectIdHash, default(FastBufferWriter.ForPrimitives));
				int position5 = writer.Position;
				num2 += position5 - position4;
			}
			int position6 = writer.Position;
			uint num3 = (uint)(position6 - (position + 4));
			writer.Seek(position);
			writer.WriteValueSafe<uint>(num3, default(FastBufferWriter.ForPrimitives));
			writer.Seek(position6);
		}

		// Token: 0x060005E6 RID: 1510 RVA: 0x0001A4B0 File Offset: 0x000186B0
		internal void SerializeScenePlacedObjects(FastBufferWriter writer)
		{
			ushort num = 0;
			int position = writer.Position;
			ushort num2 = 0;
			writer.WriteValueSafe<ushort>(num2, default(FastBufferWriter.ForPrimitives));
			foreach (KeyValuePair<uint, Dictionary<int, NetworkObject>> keyValuePair in this.m_NetworkManager.SceneManager.ScenePlacedObjects)
			{
				foreach (KeyValuePair<int, NetworkObject> keyValuePair2 in keyValuePair.Value)
				{
					if (keyValuePair2.Value.Observers.Contains(this.TargetClientId))
					{
						keyValuePair2.Value.GetMessageSceneObject(this.TargetClientId).Serialize(writer);
						num += 1;
					}
				}
			}
			int num3 = this.m_DespawnedInSceneObjectsSync.Count;
			writer.WriteValueSafe<int>(num3, default(FastBufferWriter.ForPrimitives));
			for (int i = 0; i < this.m_DespawnedInSceneObjectsSync.Count; i++)
			{
				num3 = this.m_DespawnedInSceneObjectsSync[i].GetSceneOriginHandle();
				writer.WriteValueSafe<int>(num3, default(FastBufferWriter.ForPrimitives));
				writer.WriteValueSafe<uint>(this.m_DespawnedInSceneObjectsSync[i].GlobalObjectIdHash, default(FastBufferWriter.ForPrimitives));
			}
			int position2 = writer.Position;
			writer.Seek(position);
			writer.WriteValueSafe<ushort>(num, default(FastBufferWriter.ForPrimitives));
			writer.Seek(position2);
		}

		// Token: 0x060005E7 RID: 1511 RVA: 0x0001A650 File Offset: 0x00018850
		internal void Deserialize(FastBufferReader reader)
		{
			reader.ReadValueSafe<SceneEventType>(out this.SceneEventType, default(FastBufferWriter.ForEnums));
			if (this.SceneEventType == SceneEventType.ActiveSceneChanged)
			{
				reader.ReadValueSafe<uint>(out this.ActiveSceneHash, default(FastBufferWriter.ForPrimitives));
				return;
			}
			if (this.SceneEventType != SceneEventType.ObjectSceneChanged)
			{
				byte loadSceneMode;
				reader.ReadValueSafe<byte>(out loadSceneMode, default(FastBufferWriter.ForPrimitives));
				this.LoadSceneMode = (LoadSceneMode)loadSceneMode;
				if (this.SceneEventType != SceneEventType.Synchronize)
				{
					reader.ReadValueSafe<ForceNetworkSerializeByMemcpy<Guid>>(out this.SceneEventProgressId, default(FastBufferWriter.ForStructs));
				}
				else
				{
					reader.ReadValueSafe<LoadSceneMode>(out this.ClientSynchronizationMode, default(FastBufferWriter.ForEnums));
				}
				reader.ReadValueSafe<uint>(out this.SceneHash, default(FastBufferWriter.ForPrimitives));
				reader.ReadValueSafe<int>(out this.SceneHandle, default(FastBufferWriter.ForPrimitives));
				switch (this.SceneEventType)
				{
				case SceneEventType.Load:
					this.m_HasInternalBuffer = true;
					this.InternalBuffer = new FastBufferReader(reader.GetUnsafePtrAtCurrentPosition(), Allocator.Persistent, reader.Length - reader.Position, 0, Allocator.Temp);
					return;
				case SceneEventType.Unload:
				case SceneEventType.LoadComplete:
				case SceneEventType.UnloadComplete:
					break;
				case SceneEventType.Synchronize:
					reader.ReadValueSafe<uint>(out this.ActiveSceneHash, default(FastBufferWriter.ForPrimitives));
					this.CopySceneSynchronizationData(reader);
					return;
				case SceneEventType.ReSynchronize:
					this.ReadClientReSynchronizationData(reader);
					return;
				case SceneEventType.LoadEventCompleted:
				case SceneEventType.UnloadEventCompleted:
					this.ReadSceneEventProgressDone(reader);
					break;
				case SceneEventType.SynchronizeComplete:
					this.CheckClientSynchronizationResults(reader);
					return;
				default:
					return;
				}
				return;
			}
			if (!this.m_NetworkManager.IsConnectedClient)
			{
				this.DeferObjectsMovedIntoNewScene(reader);
				return;
			}
			this.DeserializeObjectsMovedIntoNewScene(reader);
		}

		// Token: 0x060005E8 RID: 1512 RVA: 0x0001A7CC File Offset: 0x000189CC
		internal void CopySceneSynchronizationData(FastBufferReader reader)
		{
			this.m_NetworkObjectsSync.Clear();
			uint[] collection;
			reader.ReadValueSafe<uint>(out collection, default(FastBufferWriter.ForPrimitives));
			uint[] collection2;
			reader.ReadValueSafe<uint>(out collection2, default(FastBufferWriter.ForPrimitives));
			this.ScenesToSynchronize = new Queue<uint>(collection);
			this.SceneHandlesToSynchronize = new Queue<uint>(collection2);
			int num;
			reader.ReadValueSafe<int>(out num, default(FastBufferWriter.ForPrimitives));
			if (!reader.TryBeginRead(num))
			{
				throw new OverflowException("Not enough space in the buffer to read recorded synchronization data size.");
			}
			this.m_HasInternalBuffer = true;
			this.InternalBuffer = new FastBufferReader(reader.GetUnsafePtrAtCurrentPosition(), Allocator.Persistent, num, 0, Allocator.Temp);
		}

		// Token: 0x060005E9 RID: 1513 RVA: 0x0001A864 File Offset: 0x00018A64
		internal void DeserializeScenePlacedObjects()
		{
			try
			{
				ushort num;
				this.InternalBuffer.ReadValueSafe<ushort>(out num, default(FastBufferWriter.ForPrimitives));
				List<NetworkObject> list = new List<NetworkObject>();
				for (ushort num2 = 0; num2 < num; num2 += 1)
				{
					NetworkObject.SceneObject sceneObject = default(NetworkObject.SceneObject);
					sceneObject.Deserialize(this.InternalBuffer);
					if (sceneObject.IsSceneObject)
					{
						this.m_NetworkManager.SceneManager.SetTheSceneBeingSynchronized(sceneObject.NetworkSceneHandle);
					}
					NetworkObject item = NetworkObject.AddSceneObject(sceneObject, this.InternalBuffer, this.m_NetworkManager);
					if (sceneObject.IsSceneObject)
					{
						list.Add(item);
					}
				}
				this.DeserializeDespawnedInScenePlacedNetworkObjects();
				foreach (NetworkObject networkObject in list)
				{
					networkObject.InternalInSceneNetworkObjectsSpawned();
				}
			}
			finally
			{
				this.InternalBuffer.Dispose();
				this.m_HasInternalBuffer = false;
			}
		}

		// Token: 0x060005EA RID: 1514 RVA: 0x0001A95C File Offset: 0x00018B5C
		internal void ReadClientReSynchronizationData(FastBufferReader reader)
		{
			uint[] array;
			reader.ReadValueSafe<uint>(out array, default(FastBufferWriter.ForPrimitives));
			if (array.Length != 0)
			{
				NetworkObject[] array2 = Object.FindObjectsOfType<NetworkObject>();
				Dictionary<ulong, NetworkObject> dictionary = new Dictionary<ulong, NetworkObject>();
				foreach (NetworkObject networkObject in array2)
				{
					if (!dictionary.ContainsKey(networkObject.NetworkObjectId))
					{
						dictionary.Add(networkObject.NetworkObjectId, networkObject);
					}
				}
				foreach (uint num in array)
				{
					if (dictionary.ContainsKey((ulong)num))
					{
						NetworkObject networkObject2 = dictionary[(ulong)num];
						dictionary.Remove((ulong)num);
						networkObject2.IsSpawned = false;
						if (this.m_NetworkManager.PrefabHandler.ContainsHandler(networkObject2))
						{
							if (this.m_NetworkManager.SpawnManager.SpawnedObjects.ContainsKey((ulong)num))
							{
								this.m_NetworkManager.SpawnManager.SpawnedObjects.Remove((ulong)num);
							}
							if (this.m_NetworkManager.SpawnManager.SpawnedObjectsList.Contains(networkObject2))
							{
								this.m_NetworkManager.SpawnManager.SpawnedObjectsList.Remove(networkObject2);
							}
							NetworkManager.Singleton.PrefabHandler.HandleNetworkPrefabDestroy(networkObject2);
						}
						else
						{
							Object.DestroyImmediate(networkObject2.gameObject);
						}
					}
				}
			}
		}

		// Token: 0x060005EB RID: 1515 RVA: 0x0001AAAC File Offset: 0x00018CAC
		internal void WriteClientReSynchronizationData(FastBufferWriter writer)
		{
			writer.WriteValueSafe<ulong>(this.m_NetworkObjectsToBeRemoved.ToArray(), default(FastBufferWriter.ForPrimitives));
		}

		// Token: 0x060005EC RID: 1516 RVA: 0x0001AAD4 File Offset: 0x00018CD4
		internal bool ClientNeedsReSynchronization()
		{
			return this.m_NetworkObjectsToBeRemoved.Count > 0;
		}

		// Token: 0x060005ED RID: 1517 RVA: 0x0001AAE4 File Offset: 0x00018CE4
		internal void CheckClientSynchronizationResults(FastBufferReader reader)
		{
			this.m_NetworkObjectsToBeRemoved.Clear();
			uint num;
			reader.ReadValueSafe<uint>(out num, default(FastBufferWriter.ForPrimitives));
			int num2 = 0;
			while ((long)num2 < (long)((ulong)num))
			{
				uint num3;
				reader.ReadValueSafe<uint>(out num3, default(FastBufferWriter.ForPrimitives));
				if (!this.m_NetworkManager.SpawnManager.SpawnedObjects.ContainsKey((ulong)num3))
				{
					this.m_NetworkObjectsToBeRemoved.Add((ulong)num3);
				}
				num2++;
			}
		}

		// Token: 0x060005EE RID: 1518 RVA: 0x0001AB54 File Offset: 0x00018D54
		internal void WriteClientSynchronizationResults(FastBufferWriter writer)
		{
			uint num = (uint)this.m_NetworkObjectsSync.Count;
			writer.WriteValueSafe<uint>(num, default(FastBufferWriter.ForPrimitives));
			foreach (NetworkObject networkObject in this.m_NetworkObjectsSync)
			{
				num = (uint)networkObject.NetworkObjectId;
				writer.WriteValueSafe<uint>(num, default(FastBufferWriter.ForPrimitives));
			}
		}

		// Token: 0x060005EF RID: 1519 RVA: 0x0001ABD8 File Offset: 0x00018DD8
		private void DeserializeDespawnedInScenePlacedNetworkObjects()
		{
			this.m_DespawnedInSceneObjects.Clear();
			int num;
			this.InternalBuffer.ReadValueSafe<int>(out num, default(FastBufferWriter.ForPrimitives));
			Dictionary<int, Dictionary<uint, NetworkObject>> dictionary = new Dictionary<int, Dictionary<uint, NetworkObject>>();
			for (int i = 0; i < num; i++)
			{
				int num2;
				this.InternalBuffer.ReadValueSafe<int>(out num2, default(FastBufferWriter.ForPrimitives));
				uint num3;
				this.InternalBuffer.ReadValueSafe<uint>(out num3, default(FastBufferWriter.ForPrimitives));
				Dictionary<uint, NetworkObject> dictionary2 = new Dictionary<uint, NetworkObject>();
				if (!dictionary.ContainsKey(num2))
				{
					if (this.m_NetworkManager.SceneManager.ServerSceneHandleToClientSceneHandle.ContainsKey(num2))
					{
						int localSceneHandle = this.m_NetworkManager.SceneManager.ServerSceneHandleToClientSceneHandle[num2];
						if (this.m_NetworkManager.SceneManager.ScenesLoaded.ContainsKey(localSceneHandle))
						{
							Scene scene = this.m_NetworkManager.SceneManager.ScenesLoaded[localSceneHandle];
							foreach (NetworkObject networkObject in Object.FindObjectsOfType<NetworkObject>(true).Where(delegate(NetworkObject c)
							{
								if (c.GetSceneOriginHandle() == localSceneHandle)
								{
									bool? isSceneObject = c.IsSceneObject;
									bool flag = false;
									return !(isSceneObject.GetValueOrDefault() == flag & isSceneObject != null);
								}
								return false;
							}).ToList<NetworkObject>())
							{
								if (!dictionary2.ContainsKey(networkObject.GlobalObjectIdHash))
								{
									dictionary2.Add(networkObject.GlobalObjectIdHash, networkObject);
								}
							}
							dictionary.Add(num2, dictionary2);
						}
						else
						{
							Debug.LogError(string.Format("In-Scene NetworkObject GlobalObjectIdHash ({0}) cannot find its relative local scene handle {1}!", num3, localSceneHandle));
						}
					}
					else
					{
						Debug.LogError(string.Format("In-Scene NetworkObject GlobalObjectIdHash ({0}) cannot find its relative NetworkSceneHandle {1}!", num3, num2));
					}
				}
				else
				{
					dictionary2 = dictionary[num2];
				}
				if (dictionary2.ContainsKey(num3))
				{
					dictionary2[num3].InvokeBehaviourNetworkDespawn();
					if (!this.m_NetworkManager.SceneManager.ScenePlacedObjects.ContainsKey(num3))
					{
						this.m_NetworkManager.SceneManager.ScenePlacedObjects.Add(num3, new Dictionary<int, NetworkObject>());
					}
					if (!this.m_NetworkManager.SceneManager.ScenePlacedObjects[num3].ContainsKey(dictionary2[num3].GetSceneOriginHandle()))
					{
						this.m_NetworkManager.SceneManager.ScenePlacedObjects[num3].Add(dictionary2[num3].GetSceneOriginHandle(), dictionary2[num3]);
					}
				}
				else
				{
					Debug.LogError(string.Format("In-Scene NetworkObject GlobalObjectIdHash ({0}) could not be found!", num3));
				}
			}
		}

		// Token: 0x060005F0 RID: 1520 RVA: 0x0001AE78 File Offset: 0x00019078
		internal void SynchronizeSceneNetworkObjects(NetworkManager networkManager)
		{
			try
			{
				int num;
				this.InternalBuffer.ReadValueSafe<int>(out num, default(FastBufferWriter.ForPrimitives));
				for (int i = 0; i < num; i++)
				{
					NetworkObject.SceneObject sceneObject = default(NetworkObject.SceneObject);
					sceneObject.Deserialize(this.InternalBuffer);
					if (sceneObject.IsSceneObject)
					{
						this.m_NetworkManager.SceneManager.SetTheSceneBeingSynchronized(sceneObject.NetworkSceneHandle);
					}
					NetworkObject networkObject = NetworkObject.AddSceneObject(sceneObject, this.InternalBuffer, networkManager);
					if (networkObject != null && !this.m_NetworkObjectsSync.Contains(networkObject))
					{
						this.m_NetworkObjectsSync.Add(networkObject);
					}
				}
				foreach (NetworkObject networkObject2 in this.m_NetworkObjectsSync)
				{
					if (networkObject2.IsSceneObject != null && networkObject2.IsSceneObject.Value)
					{
						networkObject2.InternalInSceneNetworkObjectsSpawned();
					}
				}
				this.DeserializeDespawnedInScenePlacedNetworkObjects();
			}
			finally
			{
				this.InternalBuffer.Dispose();
				this.m_HasInternalBuffer = false;
			}
		}

		// Token: 0x060005F1 RID: 1521 RVA: 0x0001AFA4 File Offset: 0x000191A4
		internal void WriteSceneEventProgressDone(FastBufferWriter writer)
		{
			ushort num = (ushort)this.ClientsCompleted.Count;
			writer.WriteValueSafe<ushort>(num, default(FastBufferWriter.ForPrimitives));
			foreach (ulong num2 in this.ClientsCompleted)
			{
				writer.WriteValueSafe<ulong>(num2, default(FastBufferWriter.ForPrimitives));
			}
			num = (ushort)this.ClientsTimedOut.Count;
			writer.WriteValueSafe<ushort>(num, default(FastBufferWriter.ForPrimitives));
			foreach (ulong num3 in this.ClientsTimedOut)
			{
				writer.WriteValueSafe<ulong>(num3, default(FastBufferWriter.ForPrimitives));
			}
		}

		// Token: 0x060005F2 RID: 1522 RVA: 0x0001B090 File Offset: 0x00019290
		internal void ReadSceneEventProgressDone(FastBufferReader reader)
		{
			ushort num;
			reader.ReadValueSafe<ushort>(out num, default(FastBufferWriter.ForPrimitives));
			this.ClientsCompleted = new List<ulong>();
			for (int i = 0; i < (int)num; i++)
			{
				ulong item;
				reader.ReadValueSafe<ulong>(out item, default(FastBufferWriter.ForPrimitives));
				this.ClientsCompleted.Add(item);
			}
			ushort num2;
			reader.ReadValueSafe<ushort>(out num2, default(FastBufferWriter.ForPrimitives));
			this.ClientsTimedOut = new List<ulong>();
			for (int j = 0; j < (int)num2; j++)
			{
				ulong item2;
				reader.ReadValueSafe<ulong>(out item2, default(FastBufferWriter.ForPrimitives));
				this.ClientsTimedOut.Add(item2);
			}
		}

		// Token: 0x060005F3 RID: 1523 RVA: 0x0001B134 File Offset: 0x00019334
		private void SerializeObjectsMovedIntoNewScene(FastBufferWriter writer)
		{
			NetworkSceneManager sceneManager = this.m_NetworkManager.SceneManager;
			int num = sceneManager.ObjectsMigratedIntoNewScene.Count;
			writer.WriteValueSafe<int>(num, default(FastBufferWriter.ForPrimitives));
			foreach (KeyValuePair<int, List<NetworkObject>> keyValuePair in sceneManager.ObjectsMigratedIntoNewScene)
			{
				num = keyValuePair.Key;
				writer.WriteValueSafe<int>(num, default(FastBufferWriter.ForPrimitives));
				num = keyValuePair.Value.Count;
				writer.WriteValueSafe<int>(num, default(FastBufferWriter.ForPrimitives));
				foreach (NetworkObject networkObject in keyValuePair.Value)
				{
					ulong networkObjectId = networkObject.NetworkObjectId;
					writer.WriteValueSafe<ulong>(networkObjectId, default(FastBufferWriter.ForPrimitives));
				}
			}
			sceneManager.ObjectsMigratedIntoNewScene.Clear();
		}

		// Token: 0x060005F4 RID: 1524 RVA: 0x0001B250 File Offset: 0x00019450
		private void DeserializeObjectsMovedIntoNewScene(FastBufferReader reader)
		{
			NetworkSceneManager sceneManager = this.m_NetworkManager.SceneManager;
			NetworkSpawnManager spawnManager = this.m_NetworkManager.SpawnManager;
			sceneManager.ObjectsMigratedIntoNewScene.Clear();
			int num = 0;
			int key = 0;
			int num2 = 0;
			ulong num3 = 0UL;
			reader.ReadValueSafe<int>(out num, default(FastBufferWriter.ForPrimitives));
			for (int i = 0; i < num; i++)
			{
				reader.ReadValueSafe<int>(out key, default(FastBufferWriter.ForPrimitives));
				sceneManager.ObjectsMigratedIntoNewScene.Add(key, new List<NetworkObject>());
				reader.ReadValueSafe<int>(out num2, default(FastBufferWriter.ForPrimitives));
				for (int j = 0; j < num2; j++)
				{
					reader.ReadValueSafe<ulong>(out num3, default(FastBufferWriter.ForPrimitives));
					if (!spawnManager.SpawnedObjects.ContainsKey(num3))
					{
						NetworkLog.LogError(string.Format("[Object Scene Migration] Trying to synchronize NetworkObjectId ({0}) but it was not spawned or no longer exists!!", num3));
					}
					else
					{
						sceneManager.ObjectsMigratedIntoNewScene[key].Add(spawnManager.SpawnedObjects[num3]);
					}
				}
			}
		}

		// Token: 0x060005F5 RID: 1525 RVA: 0x0001B354 File Offset: 0x00019554
		private void DeferObjectsMovedIntoNewScene(FastBufferReader reader)
		{
			NetworkSceneManager sceneManager = this.m_NetworkManager.SceneManager;
			NetworkSpawnManager spawnManager = this.m_NetworkManager.SpawnManager;
			int num = 0;
			int key = 0;
			int num2 = 0;
			ulong item = 0UL;
			NetworkSceneManager.DeferredObjectsMovedEvent deferredObjectsMovedEvent = new NetworkSceneManager.DeferredObjectsMovedEvent
			{
				ObjectsMigratedTable = new Dictionary<int, List<ulong>>()
			};
			reader.ReadValueSafe<int>(out num, default(FastBufferWriter.ForPrimitives));
			for (int i = 0; i < num; i++)
			{
				reader.ReadValueSafe<int>(out key, default(FastBufferWriter.ForPrimitives));
				deferredObjectsMovedEvent.ObjectsMigratedTable.Add(key, new List<ulong>());
				reader.ReadValueSafe<int>(out num2, default(FastBufferWriter.ForPrimitives));
				for (int j = 0; j < num2; j++)
				{
					reader.ReadValueSafe<ulong>(out item, default(FastBufferWriter.ForPrimitives));
					deferredObjectsMovedEvent.ObjectsMigratedTable[key].Add(item);
				}
			}
			sceneManager.DeferredObjectsMovedEvents.Add(deferredObjectsMovedEvent);
		}

		// Token: 0x060005F6 RID: 1526 RVA: 0x0001B43C File Offset: 0x0001963C
		internal void ProcessDeferredObjectSceneChangedEvents()
		{
			NetworkSceneManager sceneManager = this.m_NetworkManager.SceneManager;
			NetworkSpawnManager spawnManager = this.m_NetworkManager.SpawnManager;
			if (sceneManager.DeferredObjectsMovedEvents.Count == 0)
			{
				return;
			}
			foreach (NetworkSceneManager.DeferredObjectsMovedEvent deferredObjectsMovedEvent in sceneManager.DeferredObjectsMovedEvents)
			{
				foreach (KeyValuePair<int, List<ulong>> keyValuePair in deferredObjectsMovedEvent.ObjectsMigratedTable)
				{
					if (!sceneManager.ObjectsMigratedIntoNewScene.ContainsKey(keyValuePair.Key))
					{
						sceneManager.ObjectsMigratedIntoNewScene.Add(keyValuePair.Key, new List<NetworkObject>());
					}
					foreach (ulong num in keyValuePair.Value)
					{
						if (!spawnManager.SpawnedObjects.ContainsKey(num))
						{
							NetworkLog.LogWarning(string.Format("[Deferred][Object Scene Migration] Trying to synchronize NetworkObjectId ({0}) but it was not spawned or no longer exists!", num));
						}
						else
						{
							NetworkObject item = spawnManager.SpawnedObjects[num];
							if (!sceneManager.ObjectsMigratedIntoNewScene[keyValuePair.Key].Contains(item))
							{
								sceneManager.ObjectsMigratedIntoNewScene[keyValuePair.Key].Add(item);
							}
						}
					}
				}
				deferredObjectsMovedEvent.ObjectsMigratedTable.Clear();
			}
			sceneManager.DeferredObjectsMovedEvents.Clear();
			if (sceneManager.ObjectsMigratedIntoNewScene.Count > 0)
			{
				sceneManager.MigrateNetworkObjectsIntoScenes();
			}
		}

		// Token: 0x060005F7 RID: 1527 RVA: 0x0001B618 File Offset: 0x00019818
		public void Dispose()
		{
			if (this.m_HasInternalBuffer)
			{
				this.InternalBuffer.Dispose();
				this.m_HasInternalBuffer = false;
			}
		}

		// Token: 0x060005F8 RID: 1528 RVA: 0x0001B634 File Offset: 0x00019834
		internal SceneEventData(NetworkManager networkManager)
		{
			this.m_NetworkManager = networkManager;
			this.SceneEventId = Guid.NewGuid().ToString().Hash32();
		}

		// Token: 0x040002C3 RID: 707
		internal SceneEventType SceneEventType;

		// Token: 0x040002C4 RID: 708
		internal LoadSceneMode LoadSceneMode;

		// Token: 0x040002C5 RID: 709
		internal ForceNetworkSerializeByMemcpy<Guid> SceneEventProgressId;

		// Token: 0x040002C6 RID: 710
		internal uint SceneEventId;

		// Token: 0x040002C7 RID: 711
		internal uint ActiveSceneHash;

		// Token: 0x040002C8 RID: 712
		internal uint SceneHash;

		// Token: 0x040002C9 RID: 713
		internal int SceneHandle;

		// Token: 0x040002CA RID: 714
		internal uint ClientSceneHash;

		// Token: 0x040002CB RID: 715
		internal int NetworkSceneHandle;

		// Token: 0x040002CC RID: 716
		internal ulong TargetClientId;

		// Token: 0x040002CD RID: 717
		private Dictionary<uint, List<NetworkObject>> m_SceneNetworkObjects;

		// Token: 0x040002CE RID: 718
		private Dictionary<uint, long> m_SceneNetworkObjectDataOffsets;

		// Token: 0x040002CF RID: 719
		private List<NetworkObject> m_NetworkObjectsSync = new List<NetworkObject>();

		// Token: 0x040002D0 RID: 720
		private List<NetworkObject> m_DespawnedInSceneObjectsSync = new List<NetworkObject>();

		// Token: 0x040002D1 RID: 721
		private Dictionary<int, List<uint>> m_DespawnedInSceneObjects = new Dictionary<int, List<uint>>();

		// Token: 0x040002D2 RID: 722
		private List<ulong> m_NetworkObjectsToBeRemoved = new List<ulong>();

		// Token: 0x040002D3 RID: 723
		private bool m_HasInternalBuffer;

		// Token: 0x040002D4 RID: 724
		internal FastBufferReader InternalBuffer;

		// Token: 0x040002D5 RID: 725
		private NetworkManager m_NetworkManager;

		// Token: 0x040002D6 RID: 726
		internal List<ulong> ClientsCompleted;

		// Token: 0x040002D7 RID: 727
		internal List<ulong> ClientsTimedOut;

		// Token: 0x040002D8 RID: 728
		internal Queue<uint> ScenesToSynchronize;

		// Token: 0x040002D9 RID: 729
		internal Queue<uint> SceneHandlesToSynchronize;

		// Token: 0x040002DA RID: 730
		internal LoadSceneMode ClientSynchronizationMode;

		// Token: 0x040002DB RID: 731
		internal static bool LogSerializationOrder;
	}
}
