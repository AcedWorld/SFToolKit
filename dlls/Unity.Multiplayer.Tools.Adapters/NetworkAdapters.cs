using System;
using System.Collections.Generic;

namespace Unity.Multiplayer.Tools.Adapters
{
	// Token: 0x0200001D RID: 29
	internal static class NetworkAdapters
	{
		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000030 RID: 48 RVA: 0x00002183 File Offset: 0x00000383
		public static IReadOnlyList<INetworkAdapter> Adapters
		{
			get
			{
				return NetworkAdapters.s_Adapters;
			}
		}

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000031 RID: 49 RVA: 0x0000218C File Offset: 0x0000038C
		// (remove) Token: 0x06000032 RID: 50 RVA: 0x000021C0 File Offset: 0x000003C0
		public static event Action<INetworkAdapter> OnAdapterAdded;

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06000033 RID: 51 RVA: 0x000021F4 File Offset: 0x000003F4
		// (remove) Token: 0x06000034 RID: 52 RVA: 0x00002228 File Offset: 0x00000428
		public static event Action<INetworkAdapter> OnAdapterRemoved;

		// Token: 0x06000035 RID: 53 RVA: 0x0000225B File Offset: 0x0000045B
		public static void AddAdapter(INetworkAdapter adapter)
		{
			if (!NetworkAdapters.s_Adapters.Contains(adapter))
			{
				NetworkAdapters.s_Adapters.Add(adapter);
				Action<INetworkAdapter> onAdapterAdded = NetworkAdapters.OnAdapterAdded;
				if (onAdapterAdded == null)
				{
					return;
				}
				onAdapterAdded(adapter);
			}
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00002285 File Offset: 0x00000485
		public static void RemoveAdapter(INetworkAdapter adapter)
		{
			if (NetworkAdapters.s_Adapters.Contains(adapter))
			{
				NetworkAdapters.s_Adapters.Remove(adapter);
				Action<INetworkAdapter> onAdapterRemoved = NetworkAdapters.OnAdapterRemoved;
				if (onAdapterRemoved == null)
				{
					return;
				}
				onAdapterRemoved(adapter);
			}
		}

		// Token: 0x06000037 RID: 55 RVA: 0x000022B0 File Offset: 0x000004B0
		public static UnsubscribeFromAllAdapters SubscribeToAll(Action<INetworkAdapter> subscribeToAdapter, Action<INetworkAdapter> unsubscribeFromAdapter)
		{
			NetworkAdapters.<>c__DisplayClass11_0 CS$<>8__locals1 = new NetworkAdapters.<>c__DisplayClass11_0();
			CS$<>8__locals1.unsubscribeFromAdapter = unsubscribeFromAdapter;
			CS$<>8__locals1.subscribeToAdapter = subscribeToAdapter;
			foreach (INetworkAdapter obj in NetworkAdapters.s_Adapters)
			{
				CS$<>8__locals1.subscribeToAdapter(obj);
			}
			NetworkAdapters.OnAdapterAdded += CS$<>8__locals1.subscribeToAdapter;
			NetworkAdapters.OnAdapterRemoved += CS$<>8__locals1.unsubscribeFromAdapter;
			return new UnsubscribeFromAllAdapters(CS$<>8__locals1.<SubscribeToAll>g__UnsubscribeFromAllAdapters|0);
		}

		// Token: 0x0400000E RID: 14
		private static readonly List<INetworkAdapter> s_Adapters = new List<INetworkAdapter>();
	}
}
