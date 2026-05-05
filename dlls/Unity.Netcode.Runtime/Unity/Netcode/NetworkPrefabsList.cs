using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Unity.Netcode
{
	// Token: 0x0200000D RID: 13
	[CreateAssetMenu(fileName = "NetworkPrefabsList", menuName = "Netcode/Network Prefabs List")]
	public class NetworkPrefabsList : ScriptableObject
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000025 RID: 37 RVA: 0x000030BA File Offset: 0x000012BA
		public IReadOnlyList<NetworkPrefab> PrefabList
		{
			get
			{
				return this.List;
			}
		}

		// Token: 0x06000026 RID: 38 RVA: 0x000030C2 File Offset: 0x000012C2
		public void Add(NetworkPrefab prefab)
		{
			this.List.Add(prefab);
			NetworkPrefabsList.OnAddDelegate onAdd = this.OnAdd;
			if (onAdd == null)
			{
				return;
			}
			onAdd(prefab);
		}

		// Token: 0x06000027 RID: 39 RVA: 0x000030E1 File Offset: 0x000012E1
		public void Remove(NetworkPrefab prefab)
		{
			this.List.Remove(prefab);
			NetworkPrefabsList.OnRemoveDelegate onRemove = this.OnRemove;
			if (onRemove == null)
			{
				return;
			}
			onRemove(prefab);
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00003104 File Offset: 0x00001304
		public bool Contains(GameObject prefab)
		{
			for (int i = 0; i < this.List.Count; i++)
			{
				if (this.List[i].Prefab == prefab)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00003144 File Offset: 0x00001344
		public bool Contains(NetworkPrefab prefab)
		{
			for (int i = 0; i < this.List.Count; i++)
			{
				if (this.List[i].Equals(prefab))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x04000032 RID: 50
		internal NetworkPrefabsList.OnAddDelegate OnAdd;

		// Token: 0x04000033 RID: 51
		internal NetworkPrefabsList.OnRemoveDelegate OnRemove;

		// Token: 0x04000034 RID: 52
		[SerializeField]
		internal bool IsDefault;

		// Token: 0x04000035 RID: 53
		[FormerlySerializedAs("Prefabs")]
		[SerializeField]
		internal List<NetworkPrefab> List = new List<NetworkPrefab>();

		// Token: 0x0200000E RID: 14
		// (Invoke) Token: 0x0600002C RID: 44
		internal delegate void OnAddDelegate(NetworkPrefab prefab);

		// Token: 0x0200000F RID: 15
		// (Invoke) Token: 0x06000030 RID: 48
		internal delegate void OnRemoveDelegate(NetworkPrefab prefab);
	}
}
