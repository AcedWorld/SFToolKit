using System;

namespace Unity.Netcode
{
	// Token: 0x02000093 RID: 147
	internal class ClientsAndHostRpcTarget : BaseRpcTarget
	{
		// Token: 0x06000312 RID: 786 RVA: 0x00010017 File Offset: 0x0000E217
		public override void Dispose()
		{
			this.m_UnderlyingTarget = null;
		}

		// Token: 0x06000313 RID: 787 RVA: 0x00010020 File Offset: 0x0000E220
		internal override void Send(NetworkBehaviour behaviour, ref RpcMessage message, NetworkDelivery delivery, RpcParams rpcParams)
		{
			if (this.m_UnderlyingTarget == null)
			{
				if (behaviour.NetworkManager.ServerIsHost)
				{
					this.m_UnderlyingTarget = behaviour.RpcTarget.Everyone;
				}
				else
				{
					this.m_UnderlyingTarget = behaviour.RpcTarget.NotServer;
				}
			}
			this.m_UnderlyingTarget.Send(behaviour, ref message, delivery, rpcParams);
		}

		// Token: 0x06000314 RID: 788 RVA: 0x00010076 File Offset: 0x0000E276
		internal ClientsAndHostRpcTarget(NetworkManager manager) : base(manager)
		{
		}

		// Token: 0x040001CB RID: 459
		private BaseRpcTarget m_UnderlyingTarget;
	}
}
