using System;
using Unity.Multiplayer.Tools;

namespace Unity.Netcode
{
	// Token: 0x020000A8 RID: 168
	internal class NetworkMetricsManager
	{
		// Token: 0x17000081 RID: 129
		// (get) Token: 0x060003AB RID: 939 RVA: 0x00011FB3 File Offset: 0x000101B3
		// (set) Token: 0x060003AC RID: 940 RVA: 0x00011FBB File Offset: 0x000101BB
		internal INetworkMetrics NetworkMetrics { get; private set; }

		// Token: 0x060003AD RID: 941 RVA: 0x00011FC4 File Offset: 0x000101C4
		public void UpdateMetrics()
		{
			this.NetworkMetrics.UpdateNetworkObjectsCount(this.m_NetworkManager.SpawnManager.SpawnedObjects.Count);
			this.NetworkMetrics.UpdateConnectionsCount(this.m_NetworkManager.IsServer ? this.m_NetworkManager.ConnectionManager.ConnectedClients.Count : 1);
			this.NetworkMetrics.DispatchFrame();
		}

		// Token: 0x060003AE RID: 942 RVA: 0x0001202C File Offset: 0x0001022C
		public void Initialize(NetworkManager networkManager)
		{
			this.m_NetworkManager = networkManager;
			if (this.NetworkMetrics == null)
			{
				this.NetworkMetrics = new NetworkMetrics();
			}
			NetworkSolutionInterface.SetInterface(new NetworkSolutionInterfaceParameters
			{
				NetworkObjectProvider = new NetworkObjectProvider(networkManager)
			});
		}

		// Token: 0x04000221 RID: 545
		private NetworkManager m_NetworkManager;
	}
}
