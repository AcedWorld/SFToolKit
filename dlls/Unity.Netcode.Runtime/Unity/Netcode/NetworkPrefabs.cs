using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Unity.Netcode
{
	// Token: 0x0200000C RID: 12
	[Serializable]
	public class NetworkPrefabs
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000018 RID: 24 RVA: 0x00002ABD File Offset: 0x00000CBD
		public IReadOnlyList<NetworkPrefab> Prefabs
		{
			get
			{
				return this.m_Prefabs;
			}
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002AC5 File Offset: 0x00000CC5
		private void AddTriggeredByNetworkPrefabList(NetworkPrefab networkPrefab)
		{
			if (this.AddPrefabRegistration(networkPrefab))
			{
				this.m_Prefabs.Add(networkPrefab);
			}
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002ADC File Offset: 0x00000CDC
		private void RemoveTriggeredByNetworkPrefabList(NetworkPrefab networkPrefab)
		{
			this.m_Prefabs.Remove(networkPrefab);
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002AEC File Offset: 0x00000CEC
		~NetworkPrefabs()
		{
			this.Shutdown();
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002B18 File Offset: 0x00000D18
		internal void Shutdown()
		{
			foreach (NetworkPrefabsList networkPrefabsList in this.NetworkPrefabsLists)
			{
				networkPrefabsList.OnAdd = (NetworkPrefabsList.OnAddDelegate)Delegate.Remove(networkPrefabsList.OnAdd, new NetworkPrefabsList.OnAddDelegate(this.AddTriggeredByNetworkPrefabList));
				networkPrefabsList.OnRemove = (NetworkPrefabsList.OnRemoveDelegate)Delegate.Remove(networkPrefabsList.OnRemove, new NetworkPrefabsList.OnRemoveDelegate(this.RemoveTriggeredByNetworkPrefabList));
			}
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002BA8 File Offset: 0x00000DA8
		public void Initialize(bool warnInvalid = true)
		{
			this.m_Prefabs.Clear();
			foreach (NetworkPrefabsList networkPrefabsList in this.NetworkPrefabsLists)
			{
				networkPrefabsList.OnAdd = (NetworkPrefabsList.OnAddDelegate)Delegate.Combine(networkPrefabsList.OnAdd, new NetworkPrefabsList.OnAddDelegate(this.AddTriggeredByNetworkPrefabList));
				networkPrefabsList.OnRemove = (NetworkPrefabsList.OnRemoveDelegate)Delegate.Combine(networkPrefabsList.OnRemove, new NetworkPrefabsList.OnRemoveDelegate(this.RemoveTriggeredByNetworkPrefabList));
			}
			this.NetworkPrefabOverrideLinks.Clear();
			this.OverrideToNetworkPrefab.Clear();
			List<NetworkPrefab> list = new List<NetworkPrefab>();
			if (this.NetworkPrefabsLists.Count != 0)
			{
				foreach (NetworkPrefabsList networkPrefabsList2 in this.NetworkPrefabsLists)
				{
					foreach (NetworkPrefab item in networkPrefabsList2.PrefabList)
					{
						list.Add(item);
					}
				}
			}
			this.m_Prefabs = new List<NetworkPrefab>();
			List<NetworkPrefab> list2 = null;
			if (warnInvalid)
			{
				list2 = new List<NetworkPrefab>();
			}
			foreach (NetworkPrefab networkPrefab in list)
			{
				if (this.AddPrefabRegistration(networkPrefab))
				{
					this.m_Prefabs.Add(networkPrefab);
				}
				else if (list2 != null)
				{
					list2.Add(networkPrefab);
				}
			}
			foreach (NetworkPrefab networkPrefab2 in this.m_RuntimeAddedPrefabs)
			{
				if (this.AddPrefabRegistration(networkPrefab2))
				{
					this.m_Prefabs.Add(networkPrefab2);
				}
				else if (list2 != null)
				{
					list2.Add(networkPrefab2);
				}
			}
			if (list2 != null && list2.Count > 0 && NetworkLog.CurrentLogLevel <= LogLevel.Error)
			{
				StringBuilder stringBuilder = new StringBuilder("Removing invalid prefabs from Network Prefab registration: ");
				stringBuilder.Append(string.Join<NetworkPrefab>(", ", list2));
				NetworkLog.LogWarning(stringBuilder.ToString());
			}
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002DF0 File Offset: 0x00000FF0
		public bool Add(NetworkPrefab networkPrefab)
		{
			if (this.AddPrefabRegistration(networkPrefab))
			{
				this.m_Prefabs.Add(networkPrefab);
				this.m_RuntimeAddedPrefabs.Add(networkPrefab);
				return true;
			}
			return false;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002E18 File Offset: 0x00001018
		public void Remove(NetworkPrefab prefab)
		{
			if (prefab == null)
			{
				throw new ArgumentNullException("prefab");
			}
			this.m_Prefabs.Remove(prefab);
			this.m_RuntimeAddedPrefabs.Remove(prefab);
			this.OverrideToNetworkPrefab.Remove(prefab.TargetPrefabGlobalObjectIdHash);
			this.NetworkPrefabOverrideLinks.Remove(prefab.SourcePrefabGlobalObjectIdHash);
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002E74 File Offset: 0x00001074
		public void Remove(GameObject prefab)
		{
			if (prefab == null)
			{
				throw new ArgumentNullException("prefab");
			}
			for (int i = 0; i < this.m_Prefabs.Count; i++)
			{
				if (this.m_Prefabs[i].Prefab == prefab)
				{
					this.Remove(this.m_Prefabs[i]);
					return;
				}
			}
			for (int j = 0; j < this.m_RuntimeAddedPrefabs.Count; j++)
			{
				if (this.m_RuntimeAddedPrefabs[j].Prefab == prefab)
				{
					this.Remove(this.m_RuntimeAddedPrefabs[j]);
					return;
				}
			}
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002F1C File Offset: 0x0000111C
		public bool Contains(GameObject prefab)
		{
			for (int i = 0; i < this.m_Prefabs.Count; i++)
			{
				if (this.m_Prefabs[i].Prefab == prefab || this.m_Prefabs[i].SourcePrefabToOverride == prefab)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002F74 File Offset: 0x00001174
		public bool Contains(NetworkPrefab prefab)
		{
			for (int i = 0; i < this.m_Prefabs.Count; i++)
			{
				if (this.m_Prefabs[i].Equals(prefab))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002FB0 File Offset: 0x000011B0
		private bool AddPrefabRegistration(NetworkPrefab networkPrefab)
		{
			if (networkPrefab == null)
			{
				return false;
			}
			if (!networkPrefab.Validate(-1))
			{
				return false;
			}
			uint sourcePrefabGlobalObjectIdHash = networkPrefab.SourcePrefabGlobalObjectIdHash;
			uint targetPrefabGlobalObjectIdHash = networkPrefab.TargetPrefabGlobalObjectIdHash;
			if (this.NetworkPrefabOverrideLinks.ContainsKey(sourcePrefabGlobalObjectIdHash))
			{
				NetworkObject component = networkPrefab.Prefab.GetComponent<NetworkObject>();
				Debug.LogError(string.Format("{0} ({1}) has a duplicate {2} source entry value of: {3}!", new object[]
				{
					"NetworkPrefab",
					component.name,
					"GlobalObjectIdHash",
					sourcePrefabGlobalObjectIdHash
				}));
				return false;
			}
			if (networkPrefab.Override == NetworkPrefabOverride.None)
			{
				this.NetworkPrefabOverrideLinks.Add(sourcePrefabGlobalObjectIdHash, networkPrefab);
				return true;
			}
			NetworkPrefabOverride @override = networkPrefab.Override;
			if (@override - NetworkPrefabOverride.Prefab <= 1)
			{
				this.NetworkPrefabOverrideLinks.Add(sourcePrefabGlobalObjectIdHash, networkPrefab);
				if (!this.OverrideToNetworkPrefab.ContainsKey(targetPrefabGlobalObjectIdHash))
				{
					this.OverrideToNetworkPrefab.Add(targetPrefabGlobalObjectIdHash, sourcePrefabGlobalObjectIdHash);
				}
			}
			return true;
		}

		// Token: 0x0400002D RID: 45
		[SerializeField]
		public List<NetworkPrefabsList> NetworkPrefabsLists = new List<NetworkPrefabsList>();

		// Token: 0x0400002E RID: 46
		[NonSerialized]
		public Dictionary<uint, NetworkPrefab> NetworkPrefabOverrideLinks = new Dictionary<uint, NetworkPrefab>();

		// Token: 0x0400002F RID: 47
		[NonSerialized]
		public Dictionary<uint, uint> OverrideToNetworkPrefab = new Dictionary<uint, uint>();

		// Token: 0x04000030 RID: 48
		[NonSerialized]
		private List<NetworkPrefab> m_Prefabs = new List<NetworkPrefab>();

		// Token: 0x04000031 RID: 49
		[NonSerialized]
		private List<NetworkPrefab> m_RuntimeAddedPrefabs = new List<NetworkPrefab>();
	}
}
