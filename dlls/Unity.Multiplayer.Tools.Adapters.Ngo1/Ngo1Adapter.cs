using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Multiplayer.Tools.NetStats;
using Unity.Netcode;
using UnityEngine;

namespace Unity.Multiplayer.Tools.Adapters.Ngo1
{
	// Token: 0x02000004 RID: 4
	internal class Ngo1Adapter : INetworkAdapter, IMetricCollectionEvent, IAdapterComponent, IGetBandwidth, IGetClientId, IGetGameObject, IGetObjectIds, IGetOwnership, IGetRpcCount
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000003 RID: 3 RVA: 0x000020BB File Offset: 0x000002BB
		private NetworkManager NetworkManager
		{
			get
			{
				return NetworkManager.Singleton;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000004 RID: 4 RVA: 0x000020C2 File Offset: 0x000002C2
		private NetworkSpawnManager SpawnManager
		{
			get
			{
				return this.NetworkManager.SpawnManager;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000005 RID: 5 RVA: 0x000020CF File Offset: 0x000002CF
		public AdapterMetadata Metadata { get; } = new AdapterMetadata
		{
			PackageInfo = new PackageInfo
			{
				PackageName = "com.unity.netcode.gameobjects",
				Version = new PackageVersion
				{
					Major = 1,
					Minor = 0,
					Patch = 0,
					PreRelease = ""
				}
			}
		};

		// Token: 0x06000006 RID: 6 RVA: 0x000020D7 File Offset: 0x000002D7
		public T GetComponent<T>() where T : class, IAdapterComponent
		{
			return this as T;
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000007 RID: 7 RVA: 0x000020E4 File Offset: 0x000002E4
		// (remove) Token: 0x06000008 RID: 8 RVA: 0x0000211C File Offset: 0x0000031C
		public event Action<MetricCollection> MetricCollectionEvent;

		// Token: 0x06000009 RID: 9 RVA: 0x00002151 File Offset: 0x00000351
		internal void OnMetricsReceived(MetricCollection metricCollection)
		{
			Action<MetricCollection> metricCollectionEvent = this.MetricCollectionEvent;
			if (metricCollectionEvent == null)
			{
				return;
			}
			metricCollectionEvent(metricCollection);
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002164 File Offset: 0x00000364
		public int GetBandwidthBytes(ObjectId objectId)
		{
			throw new NotImplementedException();
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000B RID: 11 RVA: 0x0000216B File Offset: 0x0000036B
		public ClientId LocalClientId
		{
			get
			{
				return (ClientId)this.NetworkManager.LocalClientId;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000C RID: 12 RVA: 0x00002178 File Offset: 0x00000378
		public ClientId ServerClientId
		{
			get
			{
				return (ClientId)0L;
			}
		}

		// Token: 0x0600000D RID: 13 RVA: 0x0000217C File Offset: 0x0000037C
		public GameObject GetGameObject(ObjectId objectId)
		{
			return this.SpawnManager.SpawnedObjects[(ulong)objectId].gameObject;
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600000E RID: 14 RVA: 0x00002194 File Offset: 0x00000394
		public IEnumerable<ObjectId> ObjectIds
		{
			get
			{
				return from ulongId in this.SpawnManager.SpawnedObjects.Keys
				select (ObjectId)ulongId;
			}
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000021CA File Offset: 0x000003CA
		public ClientId GetOwner(ObjectId objectId)
		{
			return (ClientId)this.SpawnManager.SpawnedObjects[(ulong)objectId].OwnerClientId;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002164 File Offset: 0x00000364
		public int GetRpcCount(ObjectId objectId)
		{
			throw new NotImplementedException();
		}
	}
}
