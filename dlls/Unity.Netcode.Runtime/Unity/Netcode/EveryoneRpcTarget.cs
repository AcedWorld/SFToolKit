using System;

namespace Unity.Netcode
{
	// Token: 0x02000095 RID: 149
	internal class EveryoneRpcTarget : BaseRpcTarget
	{
		// Token: 0x0600031B RID: 795 RVA: 0x000100B4 File Offset: 0x0000E2B4
		public override void Dispose()
		{
			this.m_NotServerRpcTarget.Dispose();
			this.m_ServerRpcTarget.Dispose();
		}

		// Token: 0x0600031C RID: 796 RVA: 0x000100CC File Offset: 0x0000E2CC
		internal override void Send(NetworkBehaviour behaviour, ref RpcMessage message, NetworkDelivery delivery, RpcParams rpcParams)
		{
			this.m_NotServerRpcTarget.Send(behaviour, ref message, delivery, rpcParams);
			this.m_ServerRpcTarget.Send(behaviour, ref message, delivery, rpcParams);
		}

		// Token: 0x0600031D RID: 797 RVA: 0x000100EE File Offset: 0x0000E2EE
		internal EveryoneRpcTarget(NetworkManager manager) : base(manager)
		{
			this.m_NotServerRpcTarget = new NotServerRpcTarget(manager);
			this.m_ServerRpcTarget = new ServerRpcTarget(manager);
		}

		// Token: 0x040001CD RID: 461
		private NotServerRpcTarget m_NotServerRpcTarget;

		// Token: 0x040001CE RID: 462
		private ServerRpcTarget m_ServerRpcTarget;
	}
}
