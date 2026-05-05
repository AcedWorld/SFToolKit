using System;
using System.Collections.Generic;
using Unity.Collections;

namespace Unity.Netcode
{
	// Token: 0x020000A1 RID: 161
	public class RpcTarget
	{
		// Token: 0x0600033B RID: 827 RVA: 0x00010A1C File Offset: 0x0000EC1C
		internal RpcTarget(NetworkManager manager)
		{
			this.m_NetworkManager = manager;
			this.Everyone = new EveryoneRpcTarget(manager);
			this.Owner = new OwnerRpcTarget(manager);
			this.NotOwner = new NotOwnerRpcTarget(manager);
			this.Server = new ServerRpcTarget(manager);
			this.NotServer = new NotServerRpcTarget(manager);
			this.NotMe = new NotMeRpcTarget(manager);
			this.Me = new LocalSendRpcTarget(manager);
			this.ClientsAndHost = new ClientsAndHostRpcTarget(manager);
			this.m_CachedProxyRpcTargetGroup = new ProxyRpcTargetGroup(manager);
			this.m_CachedTargetGroup = new RpcTargetGroup(manager);
			this.m_CachedDirectSendTarget = new DirectSendRpcTarget(manager);
			this.m_CachedProxyRpcTarget = new ProxyRpcTarget(0UL, manager);
			this.m_CachedProxyRpcTargetGroup.Lock();
			this.m_CachedTargetGroup.Lock();
			this.m_CachedDirectSendTarget.Lock();
			this.m_CachedProxyRpcTarget.Lock();
		}

		// Token: 0x0600033C RID: 828 RVA: 0x00010AF4 File Offset: 0x0000ECF4
		public void Dispose()
		{
			this.Everyone.Dispose();
			this.Owner.Dispose();
			this.NotOwner.Dispose();
			this.Server.Dispose();
			this.NotServer.Dispose();
			this.NotMe.Dispose();
			this.Me.Dispose();
			this.ClientsAndHost.Dispose();
			this.m_CachedProxyRpcTargetGroup.Unlock();
			this.m_CachedTargetGroup.Unlock();
			this.m_CachedDirectSendTarget.Unlock();
			this.m_CachedProxyRpcTarget.Unlock();
			this.m_CachedProxyRpcTargetGroup.Dispose();
			this.m_CachedTargetGroup.Dispose();
			this.m_CachedDirectSendTarget.Dispose();
			this.m_CachedProxyRpcTarget.Dispose();
		}

		// Token: 0x0600033D RID: 829 RVA: 0x00010BB4 File Offset: 0x0000EDB4
		public BaseRpcTarget Single(ulong clientId, RpcTargetUse use)
		{
			if (clientId == this.m_NetworkManager.LocalClientId)
			{
				return this.Me;
			}
			if (this.m_NetworkManager.IsServer || clientId == 0UL)
			{
				if (use == RpcTargetUse.Persistent)
				{
					return new DirectSendRpcTarget(clientId, this.m_NetworkManager);
				}
				this.m_CachedDirectSendTarget.SetClientId(clientId);
				return this.m_CachedDirectSendTarget;
			}
			else
			{
				if (use == RpcTargetUse.Persistent)
				{
					return new ProxyRpcTarget(clientId, this.m_NetworkManager);
				}
				this.m_CachedProxyRpcTarget.SetClientId(clientId);
				return this.m_CachedProxyRpcTarget;
			}
		}

		// Token: 0x0600033E RID: 830 RVA: 0x00010C30 File Offset: 0x0000EE30
		public BaseRpcTarget Not(ulong excludedClientId, RpcTargetUse use)
		{
			IGroupRpcTarget groupRpcTarget;
			if (this.m_NetworkManager.IsServer)
			{
				if (use == RpcTargetUse.Persistent)
				{
					groupRpcTarget = new RpcTargetGroup(this.m_NetworkManager);
				}
				else
				{
					groupRpcTarget = this.m_CachedTargetGroup;
				}
			}
			else if (use == RpcTargetUse.Persistent)
			{
				groupRpcTarget = new ProxyRpcTargetGroup(this.m_NetworkManager);
			}
			else
			{
				groupRpcTarget = this.m_CachedProxyRpcTargetGroup;
			}
			groupRpcTarget.Clear();
			foreach (ulong num in this.m_NetworkManager.ConnectedClientsIds)
			{
				if (num != excludedClientId)
				{
					groupRpcTarget.Add(num);
				}
			}
			if (!this.m_NetworkManager.ServerIsHost && excludedClientId != 0UL)
			{
				groupRpcTarget.Add(0UL);
			}
			return groupRpcTarget.Target;
		}

		// Token: 0x0600033F RID: 831 RVA: 0x00010CEC File Offset: 0x0000EEEC
		public BaseRpcTarget Group(NativeArray<ulong> clientIds, RpcTargetUse use)
		{
			IGroupRpcTarget groupRpcTarget;
			if (this.m_NetworkManager.IsServer)
			{
				if (use == RpcTargetUse.Persistent)
				{
					groupRpcTarget = new RpcTargetGroup(this.m_NetworkManager);
				}
				else
				{
					groupRpcTarget = this.m_CachedTargetGroup;
				}
			}
			else if (use == RpcTargetUse.Persistent)
			{
				groupRpcTarget = new ProxyRpcTargetGroup(this.m_NetworkManager);
			}
			else
			{
				groupRpcTarget = this.m_CachedProxyRpcTargetGroup;
			}
			groupRpcTarget.Clear();
			foreach (ulong clientId in clientIds)
			{
				groupRpcTarget.Add(clientId);
			}
			return groupRpcTarget.Target;
		}

		// Token: 0x06000340 RID: 832 RVA: 0x00010D88 File Offset: 0x0000EF88
		public BaseRpcTarget Group(NativeList<ulong> clientIds, RpcTargetUse use)
		{
			NativeArray<ulong> clientIds2 = clientIds.AsArray();
			return this.Group(clientIds2, use);
		}

		// Token: 0x06000341 RID: 833 RVA: 0x00010DA5 File Offset: 0x0000EFA5
		public BaseRpcTarget Group(ulong[] clientIds, RpcTargetUse use)
		{
			return this.Group(new NativeArray<ulong>(clientIds, Allocator.Temp), use);
		}

		// Token: 0x06000342 RID: 834 RVA: 0x00010DB8 File Offset: 0x0000EFB8
		public BaseRpcTarget Group<T>(T clientIds, RpcTargetUse use) where T : IEnumerable<ulong>
		{
			IGroupRpcTarget groupRpcTarget;
			if (this.m_NetworkManager.IsServer)
			{
				if (use == RpcTargetUse.Persistent)
				{
					groupRpcTarget = new RpcTargetGroup(this.m_NetworkManager);
				}
				else
				{
					groupRpcTarget = this.m_CachedTargetGroup;
				}
			}
			else if (use == RpcTargetUse.Persistent)
			{
				groupRpcTarget = new ProxyRpcTargetGroup(this.m_NetworkManager);
			}
			else
			{
				groupRpcTarget = this.m_CachedProxyRpcTargetGroup;
			}
			groupRpcTarget.Clear();
			foreach (ulong clientId in clientIds)
			{
				groupRpcTarget.Add(clientId);
			}
			return groupRpcTarget.Target;
		}

		// Token: 0x06000343 RID: 835 RVA: 0x00010E54 File Offset: 0x0000F054
		public BaseRpcTarget Not(NativeArray<ulong> excludedClientIds, RpcTargetUse use)
		{
			IGroupRpcTarget groupRpcTarget;
			if (this.m_NetworkManager.IsServer)
			{
				if (use == RpcTargetUse.Persistent)
				{
					groupRpcTarget = new RpcTargetGroup(this.m_NetworkManager);
				}
				else
				{
					groupRpcTarget = this.m_CachedTargetGroup;
				}
			}
			else if (use == RpcTargetUse.Persistent)
			{
				groupRpcTarget = new ProxyRpcTargetGroup(this.m_NetworkManager);
			}
			else
			{
				groupRpcTarget = this.m_CachedProxyRpcTargetGroup;
			}
			groupRpcTarget.Clear();
			BaseRpcTarget target;
			using (NativeHashSet<ulong> nativeHashSet = new NativeHashSet<ulong>(excludedClientIds.Length, Allocator.Temp))
			{
				foreach (ulong item in excludedClientIds)
				{
					nativeHashSet.Add(item);
				}
				foreach (ulong num in this.m_NetworkManager.ConnectedClientsIds)
				{
					if (!nativeHashSet.Contains(num))
					{
						groupRpcTarget.Add(num);
					}
				}
				if (!this.m_NetworkManager.ServerIsHost && !nativeHashSet.Contains(0UL))
				{
					groupRpcTarget.Add(0UL);
				}
				target = groupRpcTarget.Target;
			}
			return target;
		}

		// Token: 0x06000344 RID: 836 RVA: 0x00010F9C File Offset: 0x0000F19C
		public BaseRpcTarget Not(NativeList<ulong> excludedClientIds, RpcTargetUse use)
		{
			NativeArray<ulong> excludedClientIds2 = excludedClientIds.AsArray();
			return this.Not(excludedClientIds2, use);
		}

		// Token: 0x06000345 RID: 837 RVA: 0x00010FB9 File Offset: 0x0000F1B9
		public BaseRpcTarget Not(ulong[] excludedClientIds, RpcTargetUse use)
		{
			return this.Not(new NativeArray<ulong>(excludedClientIds, Allocator.Temp), use);
		}

		// Token: 0x06000346 RID: 838 RVA: 0x00010FCC File Offset: 0x0000F1CC
		public BaseRpcTarget Not<T>(T excludedClientIds, RpcTargetUse use) where T : IEnumerable<ulong>
		{
			IGroupRpcTarget groupRpcTarget;
			if (this.m_NetworkManager.IsServer)
			{
				if (use == RpcTargetUse.Persistent)
				{
					groupRpcTarget = new RpcTargetGroup(this.m_NetworkManager);
				}
				else
				{
					groupRpcTarget = this.m_CachedTargetGroup;
				}
			}
			else if (use == RpcTargetUse.Persistent)
			{
				groupRpcTarget = new ProxyRpcTargetGroup(this.m_NetworkManager);
			}
			else
			{
				groupRpcTarget = this.m_CachedProxyRpcTargetGroup;
			}
			groupRpcTarget.Clear();
			BaseRpcTarget target;
			using (NativeHashSet<ulong> nativeHashSet = new NativeHashSet<ulong>(this.m_NetworkManager.ConnectedClientsIds.Count, Allocator.Temp))
			{
				foreach (ulong item in excludedClientIds)
				{
					nativeHashSet.Add(item);
				}
				foreach (ulong num in this.m_NetworkManager.ConnectedClientsIds)
				{
					if (!nativeHashSet.Contains(num))
					{
						groupRpcTarget.Add(num);
					}
				}
				if (!this.m_NetworkManager.ServerIsHost && !nativeHashSet.Contains(0UL))
				{
					groupRpcTarget.Add(0UL);
				}
				target = groupRpcTarget.Target;
			}
			return target;
		}

		// Token: 0x040001EB RID: 491
		private NetworkManager m_NetworkManager;

		// Token: 0x040001EC RID: 492
		public BaseRpcTarget Owner;

		// Token: 0x040001ED RID: 493
		public BaseRpcTarget NotOwner;

		// Token: 0x040001EE RID: 494
		public BaseRpcTarget Server;

		// Token: 0x040001EF RID: 495
		public BaseRpcTarget NotServer;

		// Token: 0x040001F0 RID: 496
		public BaseRpcTarget Me;

		// Token: 0x040001F1 RID: 497
		public BaseRpcTarget NotMe;

		// Token: 0x040001F2 RID: 498
		public BaseRpcTarget Everyone;

		// Token: 0x040001F3 RID: 499
		public BaseRpcTarget ClientsAndHost;

		// Token: 0x040001F4 RID: 500
		private ProxyRpcTargetGroup m_CachedProxyRpcTargetGroup;

		// Token: 0x040001F5 RID: 501
		private RpcTargetGroup m_CachedTargetGroup;

		// Token: 0x040001F6 RID: 502
		private DirectSendRpcTarget m_CachedDirectSendTarget;

		// Token: 0x040001F7 RID: 503
		private ProxyRpcTarget m_CachedProxyRpcTarget;
	}
}
