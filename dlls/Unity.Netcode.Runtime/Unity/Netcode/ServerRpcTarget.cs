using System;

namespace Unity.Netcode
{
	// Token: 0x020000A3 RID: 163
	internal class ServerRpcTarget : BaseRpcTarget
	{
		// Token: 0x0600034D RID: 845 RVA: 0x00011352 File Offset: 0x0000F552
		public override void Dispose()
		{
			if (this.m_UnderlyingTarget != null)
			{
				this.m_UnderlyingTarget.Dispose();
				this.m_UnderlyingTarget = null;
			}
		}

		// Token: 0x0600034E RID: 846 RVA: 0x00011370 File Offset: 0x0000F570
		internal override void Send(NetworkBehaviour behaviour, ref RpcMessage message, NetworkDelivery delivery, RpcParams rpcParams)
		{
			if (this.m_UnderlyingTarget == null)
			{
				if (behaviour.NetworkManager.IsServer)
				{
					this.m_UnderlyingTarget = new LocalSendRpcTarget(this.m_NetworkManager);
				}
				else
				{
					this.m_UnderlyingTarget = new DirectSendRpcTarget(this.m_NetworkManager)
					{
						ClientId = 0UL
					};
				}
			}
			this.m_UnderlyingTarget.Send(behaviour, ref message, delivery, rpcParams);
		}

		// Token: 0x0600034F RID: 847 RVA: 0x00010076 File Offset: 0x0000E276
		internal ServerRpcTarget(NetworkManager manager) : base(manager)
		{
		}

		// Token: 0x040001FC RID: 508
		private BaseRpcTarget m_UnderlyingTarget;
	}
}
