using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace Unity.Netcode
{
	// Token: 0x02000007 RID: 7
	[Serializable]
	public class NetworkConfig
	{
		// Token: 0x06000005 RID: 5 RVA: 0x000020D0 File Offset: 0x000002D0
		public string ToBase64()
		{
			FastBufferWriter fastBufferWriter = new FastBufferWriter(1024, Allocator.Temp, -1);
			string result;
			using (fastBufferWriter)
			{
				fastBufferWriter.WriteValueSafe<ushort>(this.ProtocolVersion, default(FastBufferWriter.ForPrimitives));
				fastBufferWriter.WriteValueSafe<uint>(this.TickRate, default(FastBufferWriter.ForPrimitives));
				fastBufferWriter.WriteValueSafe<int>(this.ClientConnectionBufferTimeout, default(FastBufferWriter.ForPrimitives));
				fastBufferWriter.WriteValueSafe<bool>(this.ConnectionApproval, default(FastBufferWriter.ForPrimitives));
				fastBufferWriter.WriteValueSafe<int>(this.LoadSceneTimeOut, default(FastBufferWriter.ForPrimitives));
				fastBufferWriter.WriteValueSafe<bool>(this.EnableTimeResync, default(FastBufferWriter.ForPrimitives));
				fastBufferWriter.WriteValueSafe<bool>(this.EnsureNetworkVariableLengthSafety, default(FastBufferWriter.ForPrimitives));
				fastBufferWriter.WriteValueSafe<HashSize>(this.RpcHashSize, default(FastBufferWriter.ForEnums));
				fastBufferWriter.WriteValueSafe<bool>(this.ForceSamePrefabs, default(FastBufferWriter.ForPrimitives));
				fastBufferWriter.WriteValueSafe<bool>(this.EnableSceneManagement, default(FastBufferWriter.ForPrimitives));
				fastBufferWriter.WriteValueSafe<bool>(this.RecycleNetworkIds, default(FastBufferWriter.ForPrimitives));
				fastBufferWriter.WriteValueSafe<float>(this.NetworkIdRecycleDelay, default(FastBufferWriter.ForPrimitives));
				fastBufferWriter.WriteValueSafe<bool>(this.EnableNetworkLogs, default(FastBufferWriter.ForPrimitives));
				result = Convert.ToBase64String(fastBufferWriter.ToArray());
			}
			return result;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x0000224C File Offset: 0x0000044C
		public void FromBase64(string base64)
		{
			byte[] buffer = Convert.FromBase64String(base64);
			using (FastBufferReader fastBufferReader = new FastBufferReader(buffer, Allocator.Temp, -1, 0))
			{
				using (fastBufferReader)
				{
					fastBufferReader.ReadValueSafe<ushort>(out this.ProtocolVersion, default(FastBufferWriter.ForPrimitives));
					fastBufferReader.ReadValueSafe<uint>(out this.TickRate, default(FastBufferWriter.ForPrimitives));
					fastBufferReader.ReadValueSafe<int>(out this.ClientConnectionBufferTimeout, default(FastBufferWriter.ForPrimitives));
					fastBufferReader.ReadValueSafe<bool>(out this.ConnectionApproval, default(FastBufferWriter.ForPrimitives));
					fastBufferReader.ReadValueSafe<int>(out this.LoadSceneTimeOut, default(FastBufferWriter.ForPrimitives));
					fastBufferReader.ReadValueSafe<bool>(out this.EnableTimeResync, default(FastBufferWriter.ForPrimitives));
					fastBufferReader.ReadValueSafe<bool>(out this.EnsureNetworkVariableLengthSafety, default(FastBufferWriter.ForPrimitives));
					fastBufferReader.ReadValueSafe<HashSize>(out this.RpcHashSize, default(FastBufferWriter.ForEnums));
					fastBufferReader.ReadValueSafe<bool>(out this.ForceSamePrefabs, default(FastBufferWriter.ForPrimitives));
					fastBufferReader.ReadValueSafe<bool>(out this.EnableSceneManagement, default(FastBufferWriter.ForPrimitives));
					fastBufferReader.ReadValueSafe<bool>(out this.RecycleNetworkIds, default(FastBufferWriter.ForPrimitives));
					fastBufferReader.ReadValueSafe<float>(out this.NetworkIdRecycleDelay, default(FastBufferWriter.ForPrimitives));
					fastBufferReader.ReadValueSafe<bool>(out this.EnableNetworkLogs, default(FastBufferWriter.ForPrimitives));
				}
			}
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000023EC File Offset: 0x000005EC
		internal void ClearConfigHash()
		{
			this.m_ConfigHash = null;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000023FC File Offset: 0x000005FC
		public ulong GetConfig(bool cache = true)
		{
			if (this.m_ConfigHash != null && cache)
			{
				return this.m_ConfigHash.Value;
			}
			FastBufferWriter fastBufferWriter = new FastBufferWriter(1024, Allocator.Temp, int.MaxValue);
			ulong result;
			using (fastBufferWriter)
			{
				fastBufferWriter.WriteValueSafe<ushort>(this.ProtocolVersion, default(FastBufferWriter.ForPrimitives));
				fastBufferWriter.WriteValueSafe("15.0.0", false);
				if (this.ForceSamePrefabs)
				{
					foreach (KeyValuePair<uint, NetworkPrefab> keyValuePair in from x in this.Prefabs.NetworkPrefabOverrideLinks
					orderby x.Key
					select x)
					{
						uint key = keyValuePair.Key;
						fastBufferWriter.WriteValueSafe<uint>(key, default(FastBufferWriter.ForPrimitives));
					}
				}
				fastBufferWriter.WriteValueSafe<uint>(this.TickRate, default(FastBufferWriter.ForPrimitives));
				fastBufferWriter.WriteValueSafe<bool>(this.ConnectionApproval, default(FastBufferWriter.ForPrimitives));
				fastBufferWriter.WriteValueSafe<bool>(this.ForceSamePrefabs, default(FastBufferWriter.ForPrimitives));
				fastBufferWriter.WriteValueSafe<bool>(this.EnableSceneManagement, default(FastBufferWriter.ForPrimitives));
				fastBufferWriter.WriteValueSafe<bool>(this.EnsureNetworkVariableLengthSafety, default(FastBufferWriter.ForPrimitives));
				fastBufferWriter.WriteValueSafe<HashSize>(this.RpcHashSize, default(FastBufferWriter.ForEnums));
				if (cache)
				{
					this.m_ConfigHash = new ulong?(fastBufferWriter.ToArray().Hash64());
					result = this.m_ConfigHash.Value;
				}
				else
				{
					result = fastBufferWriter.ToArray().Hash64();
				}
			}
			return result;
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000025D4 File Offset: 0x000007D4
		public bool CompareConfig(ulong hash)
		{
			return hash == this.GetConfig(true);
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000025E0 File Offset: 0x000007E0
		internal void InitializePrefabs()
		{
			if (this.HasOldPrefabList())
			{
				this.MigrateOldNetworkPrefabsToNetworkPrefabsList();
			}
			this.Prefabs.Initialize(true);
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000025FD File Offset: 0x000007FD
		private void WarnOldPrefabList()
		{
			if (!this.m_DidWarnOldPrefabList)
			{
				Debug.LogWarning("Using Legacy Network Prefab List. Consider Migrating.");
				this.m_DidWarnOldPrefabList = true;
			}
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002618 File Offset: 0x00000818
		internal bool HasOldPrefabList()
		{
			List<NetworkPrefab> oldPrefabList = this.OldPrefabList;
			return oldPrefabList != null && oldPrefabList.Count > 0;
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002630 File Offset: 0x00000830
		internal NetworkPrefabsList MigrateOldNetworkPrefabsToNetworkPrefabsList()
		{
			if (this.OldPrefabList == null || this.OldPrefabList.Count == 0)
			{
				return null;
			}
			if (this.Prefabs == null)
			{
				throw new Exception("Prefabs field is null.");
			}
			this.Prefabs.NetworkPrefabsLists.Add(ScriptableObject.CreateInstance<NetworkPrefabsList>());
			List<NetworkPrefab> oldPrefabList = this.OldPrefabList;
			if (oldPrefabList != null && oldPrefabList.Count > 0)
			{
				foreach (NetworkPrefab prefab in this.OldPrefabList)
				{
					this.Prefabs.NetworkPrefabsLists[this.Prefabs.NetworkPrefabsLists.Count - 1].Add(prefab);
				}
			}
			this.OldPrefabList = null;
			return this.Prefabs.NetworkPrefabsLists[this.Prefabs.NetworkPrefabsLists.Count - 1];
		}

		// Token: 0x04000009 RID: 9
		[Tooltip("Use this to make two builds incompatible with each other")]
		public ushort ProtocolVersion;

		// Token: 0x0400000A RID: 10
		[Tooltip("The NetworkTransport to use")]
		public NetworkTransport NetworkTransport;

		// Token: 0x0400000B RID: 11
		[Tooltip("When set, NetworkManager will automatically create and spawn the assigned player prefab. This can be overridden by adding it to the NetworkPrefabs list and selecting override.")]
		public GameObject PlayerPrefab;

		// Token: 0x0400000C RID: 12
		[SerializeField]
		public NetworkPrefabs Prefabs = new NetworkPrefabs();

		// Token: 0x0400000D RID: 13
		[Tooltip("The tickrate. This value controls how often netcode runs user code and sends out data. The value is in 'ticks per seconds' which means a value of 50 will result in 50 ticks being executed per second or a fixed delta time of 0.02.")]
		public uint TickRate = 30U;

		// Token: 0x0400000E RID: 14
		[Tooltip("The amount of seconds for the server to wait for the connection approval handshake to complete before the client is disconnected")]
		public int ClientConnectionBufferTimeout = 10;

		// Token: 0x0400000F RID: 15
		[Tooltip("Whether or not to force clients to be approved before they connect")]
		public bool ConnectionApproval;

		// Token: 0x04000010 RID: 16
		[Tooltip("The connection data sent along with connection requests")]
		public byte[] ConnectionData = new byte[0];

		// Token: 0x04000011 RID: 17
		[Tooltip("Enable this to re-sync the NetworkTime after the initial sync")]
		public bool EnableTimeResync;

		// Token: 0x04000012 RID: 18
		[Tooltip("The amount of seconds between re-syncs of NetworkTime, if enabled")]
		public int TimeResyncInterval = 30;

		// Token: 0x04000013 RID: 19
		[Tooltip("Ensures that NetworkVariables can be read even if a client accidental writes where its not allowed to. This will cost some CPU time and bandwidth")]
		public bool EnsureNetworkVariableLengthSafety;

		// Token: 0x04000014 RID: 20
		[Tooltip("Enables scene management. This will allow network scene switches and automatic scene difference corrections upon connect.\nSoftSynced scene objects wont work with this disabled. That means that disabling SceneManagement also enables PrefabSync.")]
		public bool EnableSceneManagement = true;

		// Token: 0x04000015 RID: 21
		[Tooltip("Whether or not the netcode should check for differences in the prefab lists at connection")]
		public bool ForceSamePrefabs = true;

		// Token: 0x04000016 RID: 22
		[Tooltip("If true, NetworkIds will be reused after the NetworkIdRecycleDelay")]
		public bool RecycleNetworkIds = true;

		// Token: 0x04000017 RID: 23
		[Tooltip("The amount of seconds a NetworkId has to unused in order for it to be reused")]
		public float NetworkIdRecycleDelay = 120f;

		// Token: 0x04000018 RID: 24
		[Tooltip("The maximum amount of bytes to use for RPC messages.")]
		public HashSize RpcHashSize;

		// Token: 0x04000019 RID: 25
		[Tooltip("The amount of seconds to wait for all clients to load or unload a requested scene (only when EnableSceneManagement is enabled)")]
		public int LoadSceneTimeOut = 120;

		// Token: 0x0400001A RID: 26
		[Tooltip("The amount of time a message should be buffered if the asset or object needed to process it doesn't exist yet. If the asset is not added/object is not spawned within this time, it will be dropped")]
		public float SpawnTimeout = 10f;

		// Token: 0x0400001B RID: 27
		public bool EnableNetworkLogs = true;

		// Token: 0x0400001C RID: 28
		public const int RttAverageSamples = 5;

		// Token: 0x0400001D RID: 29
		public const int RttWindowSize = 64;

		// Token: 0x0400001E RID: 30
		private ulong? m_ConfigHash;

		// Token: 0x0400001F RID: 31
		[NonSerialized]
		private bool m_DidWarnOldPrefabList;

		// Token: 0x04000020 RID: 32
		[FormerlySerializedAs("NetworkPrefabs")]
		[SerializeField]
		internal List<NetworkPrefab> OldPrefabList;
	}
}
