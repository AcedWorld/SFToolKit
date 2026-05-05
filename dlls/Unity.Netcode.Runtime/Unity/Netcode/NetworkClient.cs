using System;
using System.Collections.Generic;

namespace Unity.Netcode
{
	// Token: 0x02000010 RID: 16
	public class NetworkClient
	{
		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000033 RID: 51 RVA: 0x00003191 File Offset: 0x00001391
		// (set) Token: 0x06000034 RID: 52 RVA: 0x00003199 File Offset: 0x00001399
		internal bool IsServer { get; set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000035 RID: 53 RVA: 0x000031A2 File Offset: 0x000013A2
		// (set) Token: 0x06000036 RID: 54 RVA: 0x000031AA File Offset: 0x000013AA
		internal bool IsClient { get; set; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000037 RID: 55 RVA: 0x000031B3 File Offset: 0x000013B3
		internal bool IsHost
		{
			get
			{
				return this.IsClient && this.IsServer;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000038 RID: 56 RVA: 0x000031C5 File Offset: 0x000013C5
		// (set) Token: 0x06000039 RID: 57 RVA: 0x000031CD File Offset: 0x000013CD
		internal bool IsConnected { get; set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600003A RID: 58 RVA: 0x000031D6 File Offset: 0x000013D6
		// (set) Token: 0x0600003B RID: 59 RVA: 0x000031DE File Offset: 0x000013DE
		internal bool IsApproved { get; set; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600003C RID: 60 RVA: 0x000031E7 File Offset: 0x000013E7
		public List<NetworkObject> OwnedObjects
		{
			get
			{
				if (!this.IsConnected)
				{
					return new List<NetworkObject>();
				}
				return this.SpawnManager.GetClientOwnedObjects(this.ClientId);
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600003D RID: 61 RVA: 0x00003208 File Offset: 0x00001408
		// (set) Token: 0x0600003E RID: 62 RVA: 0x00003210 File Offset: 0x00001410
		internal NetworkSpawnManager SpawnManager { get; private set; }

		// Token: 0x0600003F RID: 63 RVA: 0x0000321C File Offset: 0x0000141C
		internal void SetRole(bool isServer, bool isClient, NetworkManager networkManager = null)
		{
			this.IsServer = isServer;
			this.IsClient = isClient;
			if (!this.IsServer && !isClient)
			{
				this.PlayerObject = null;
				this.ClientId = 0UL;
				this.IsConnected = false;
				this.IsApproved = false;
			}
			if (networkManager != null)
			{
				this.SpawnManager = networkManager.SpawnManager;
			}
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00003274 File Offset: 0x00001474
		internal void AssignPlayerObject(ref NetworkObject networkObject)
		{
			this.PlayerObject = networkObject;
		}

		// Token: 0x0400003A RID: 58
		public ulong ClientId;

		// Token: 0x0400003B RID: 59
		public NetworkObject PlayerObject;
	}
}
