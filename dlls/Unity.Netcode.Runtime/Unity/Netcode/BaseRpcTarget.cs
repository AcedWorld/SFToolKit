using System;

namespace Unity.Netcode
{
	// Token: 0x02000092 RID: 146
	public abstract class BaseRpcTarget : IDisposable
	{
		// Token: 0x0600030B RID: 779 RVA: 0x0000FFBA File Offset: 0x0000E1BA
		internal void Lock()
		{
			this.m_Locked = true;
		}

		// Token: 0x0600030C RID: 780 RVA: 0x0000FFC3 File Offset: 0x0000E1C3
		internal void Unlock()
		{
			this.m_Locked = false;
		}

		// Token: 0x0600030D RID: 781 RVA: 0x0000FFCC File Offset: 0x0000E1CC
		internal BaseRpcTarget(NetworkManager manager)
		{
			this.m_NetworkManager = manager;
		}

		// Token: 0x0600030E RID: 782 RVA: 0x0000FFDB File Offset: 0x0000E1DB
		protected void CheckLockBeforeDispose()
		{
			if (this.m_Locked)
			{
				throw new Exception(string.Format("RPC targets obtained through {0}.{1} may not be disposed.", "RpcTargetUse", RpcTargetUse.Temp));
			}
		}

		// Token: 0x0600030F RID: 783
		public abstract void Dispose();

		// Token: 0x06000310 RID: 784
		internal abstract void Send(NetworkBehaviour behaviour, ref RpcMessage message, NetworkDelivery delivery, RpcParams rpcParams);

		// Token: 0x06000311 RID: 785 RVA: 0x00010000 File Offset: 0x0000E200
		private protected void SendMessageToClient(NetworkBehaviour behaviour, ulong clientId, ref RpcMessage message, NetworkDelivery delivery)
		{
			behaviour.NetworkManager.MessageManager.SendMessage<RpcMessage>(ref message, delivery, clientId);
		}

		// Token: 0x040001C9 RID: 457
		protected NetworkManager m_NetworkManager;

		// Token: 0x040001CA RID: 458
		private bool m_Locked;
	}
}
