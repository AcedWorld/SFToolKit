using System;
using System.Collections.Generic;
using Unity.Collections;

namespace Unity.Netcode
{
	// Token: 0x0200009E RID: 158
	internal class ProxyRpcTargetGroup : BaseRpcTarget, IDisposable, IGroupRpcTarget
	{
		// Token: 0x1700007C RID: 124
		// (get) Token: 0x06000334 RID: 820 RVA: 0x0001007F File Offset: 0x0000E27F
		public BaseRpcTarget Target
		{
			get
			{
				return this;
			}
		}

		// Token: 0x06000335 RID: 821 RVA: 0x0001086C File Offset: 0x0000EA6C
		internal override void Send(NetworkBehaviour behaviour, ref RpcMessage message, NetworkDelivery delivery, RpcParams rpcParams)
		{
			ProxyMessage proxyMessage = new ProxyMessage
			{
				Delivery = delivery,
				TargetClientIds = this.TargetClientIds.AsArray(),
				WrappedMessage = message
			};
			behaviour.NetworkManager.MessageManager.SendMessage<ProxyMessage>(ref proxyMessage, delivery, 0UL);
			if (this.Ids.Contains(0UL))
			{
				this.m_ServerRpcTarget.Send(behaviour, ref message, delivery, rpcParams);
			}
			if (this.Ids.Contains(this.m_NetworkManager.LocalClientId))
			{
				this.m_LocalSendRpcTarget.Send(behaviour, ref message, delivery, rpcParams);
			}
		}

		// Token: 0x06000336 RID: 822 RVA: 0x00010907 File Offset: 0x0000EB07
		internal ProxyRpcTargetGroup(NetworkManager manager) : base(manager)
		{
			this.TargetClientIds = new NativeList<ulong>(Allocator.Persistent);
			this.m_ServerRpcTarget = new ServerRpcTarget(manager);
			this.m_LocalSendRpcTarget = new LocalSendRpcTarget(manager);
		}

		// Token: 0x06000337 RID: 823 RVA: 0x00010944 File Offset: 0x0000EB44
		public override void Dispose()
		{
			base.CheckLockBeforeDispose();
			if (!this.m_Disposed)
			{
				this.TargetClientIds.Dispose();
				this.m_Disposed = true;
				this.m_ServerRpcTarget.Dispose();
				this.m_LocalSendRpcTarget.Dispose();
			}
		}

		// Token: 0x06000338 RID: 824 RVA: 0x0001097C File Offset: 0x0000EB7C
		public void Add(ulong clientId)
		{
			if (!this.Ids.Contains(clientId))
			{
				this.Ids.Add(clientId);
				if (clientId != 0UL && clientId != this.m_NetworkManager.LocalClientId)
				{
					this.TargetClientIds.Add(clientId);
				}
			}
		}

		// Token: 0x06000339 RID: 825 RVA: 0x000109B8 File Offset: 0x0000EBB8
		public void Remove(ulong clientId)
		{
			this.Ids.Remove(clientId);
			for (int i = 0; i < this.TargetClientIds.Length; i++)
			{
				if (this.TargetClientIds[i] == clientId)
				{
					this.TargetClientIds.RemoveAt(i);
					return;
				}
			}
		}

		// Token: 0x0600033A RID: 826 RVA: 0x00010A04 File Offset: 0x0000EC04
		public void Clear()
		{
			this.Ids.Clear();
			this.TargetClientIds.Clear();
		}

		// Token: 0x040001D9 RID: 473
		private ServerRpcTarget m_ServerRpcTarget;

		// Token: 0x040001DA RID: 474
		private LocalSendRpcTarget m_LocalSendRpcTarget;

		// Token: 0x040001DB RID: 475
		private bool m_Disposed;

		// Token: 0x040001DC RID: 476
		public NativeList<ulong> TargetClientIds;

		// Token: 0x040001DD RID: 477
		internal HashSet<ulong> Ids = new HashSet<ulong>();
	}
}
