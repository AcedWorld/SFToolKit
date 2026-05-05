using System;
using UnityEngine;

namespace Unity.Netcode
{
	// Token: 0x02000122 RID: 290
	public abstract class NetworkTransport : MonoBehaviour
	{
		// Token: 0x170000CA RID: 202
		// (get) Token: 0x06000924 RID: 2340
		public abstract ulong ServerClientId { get; }

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x06000925 RID: 2341 RVA: 0x0000C36D File Offset: 0x0000A56D
		public virtual bool IsSupported
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1400001F RID: 31
		// (add) Token: 0x06000926 RID: 2342 RVA: 0x00022E74 File Offset: 0x00021074
		// (remove) Token: 0x06000927 RID: 2343 RVA: 0x00022EAC File Offset: 0x000210AC
		public event NetworkTransport.TransportEventDelegate OnTransportEvent;

		// Token: 0x06000928 RID: 2344 RVA: 0x00022EE1 File Offset: 0x000210E1
		protected void InvokeOnTransportEvent(NetworkEvent eventType, ulong clientId, ArraySegment<byte> payload, float receiveTime)
		{
			NetworkTransport.TransportEventDelegate onTransportEvent = this.OnTransportEvent;
			if (onTransportEvent == null)
			{
				return;
			}
			onTransportEvent(eventType, clientId, payload, receiveTime);
		}

		// Token: 0x06000929 RID: 2345
		public abstract void Send(ulong clientId, ArraySegment<byte> payload, NetworkDelivery networkDelivery);

		// Token: 0x0600092A RID: 2346
		public abstract NetworkEvent PollEvent(out ulong clientId, out ArraySegment<byte> payload, out float receiveTime);

		// Token: 0x0600092B RID: 2347
		public abstract bool StartClient();

		// Token: 0x0600092C RID: 2348
		public abstract bool StartServer();

		// Token: 0x0600092D RID: 2349
		public abstract void DisconnectRemoteClient(ulong clientId);

		// Token: 0x0600092E RID: 2350
		public abstract void DisconnectLocalClient();

		// Token: 0x0600092F RID: 2351
		public abstract ulong GetCurrentRtt(ulong clientId);

		// Token: 0x06000930 RID: 2352
		public abstract void Shutdown();

		// Token: 0x06000931 RID: 2353
		public abstract void Initialize(NetworkManager networkManager = null);

		// Token: 0x0400037F RID: 895
		internal INetworkMetrics NetworkMetrics;

		// Token: 0x02000123 RID: 291
		// (Invoke) Token: 0x06000934 RID: 2356
		public delegate void TransportEventDelegate(NetworkEvent eventType, ulong clientId, ArraySegment<byte> payload, float receiveTime);
	}
}
