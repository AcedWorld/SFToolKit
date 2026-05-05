using System;

namespace Unity.Netcode
{
	// Token: 0x0200009C RID: 156
	internal class OwnerRpcTarget : BaseRpcTarget
	{
		// Token: 0x0600032F RID: 815 RVA: 0x0001074D File Offset: 0x0000E94D
		public override void Dispose()
		{
			this.m_LocalRpcTarget.Dispose();
			if (this.m_UnderlyingTarget != null)
			{
				this.m_UnderlyingTarget.Target.Dispose();
				this.m_UnderlyingTarget = null;
			}
		}

		// Token: 0x06000330 RID: 816 RVA: 0x0001077C File Offset: 0x0000E97C
		internal override void Send(NetworkBehaviour behaviour, ref RpcMessage message, NetworkDelivery delivery, RpcParams rpcParams)
		{
			if (behaviour.OwnerClientId == behaviour.NetworkManager.LocalClientId)
			{
				this.m_LocalRpcTarget.Send(behaviour, ref message, delivery, rpcParams);
				return;
			}
			if (behaviour.OwnerClientId == 0UL)
			{
				this.m_ServerRpcTarget.Send(behaviour, ref message, delivery, rpcParams);
				return;
			}
			if (this.m_UnderlyingTarget == null)
			{
				if (behaviour.NetworkManager.IsServer)
				{
					this.m_UnderlyingTarget = new DirectSendRpcTarget(this.m_NetworkManager);
				}
				else
				{
					this.m_UnderlyingTarget = new ProxyRpcTarget(behaviour.OwnerClientId, this.m_NetworkManager);
				}
			}
			this.m_UnderlyingTarget.SetClientId(behaviour.OwnerClientId);
			this.m_UnderlyingTarget.Target.Send(behaviour, ref message, delivery, rpcParams);
		}

		// Token: 0x06000331 RID: 817 RVA: 0x0001082B File Offset: 0x0000EA2B
		internal OwnerRpcTarget(NetworkManager manager) : base(manager)
		{
			this.m_LocalRpcTarget = new LocalSendRpcTarget(manager);
			this.m_ServerRpcTarget = new ServerRpcTarget(manager);
		}

		// Token: 0x040001D6 RID: 470
		private IIndividualRpcTarget m_UnderlyingTarget;

		// Token: 0x040001D7 RID: 471
		private LocalSendRpcTarget m_LocalRpcTarget;

		// Token: 0x040001D8 RID: 472
		private ServerRpcTarget m_ServerRpcTarget;
	}
}
