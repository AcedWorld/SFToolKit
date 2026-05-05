using System;
using System.Collections.Generic;

namespace Unity.Netcode
{
	// Token: 0x02000099 RID: 153
	internal class NotMeRpcTarget : BaseRpcTarget
	{
		// Token: 0x06000326 RID: 806 RVA: 0x000102A0 File Offset: 0x0000E4A0
		public override void Dispose()
		{
			this.m_ServerRpcTarget.Dispose();
			if (this.m_GroupSendTarget != null)
			{
				this.m_GroupSendTarget.Target.Dispose();
				this.m_GroupSendTarget = null;
			}
		}

		// Token: 0x06000327 RID: 807 RVA: 0x000102CC File Offset: 0x0000E4CC
		internal override void Send(NetworkBehaviour behaviour, ref RpcMessage message, NetworkDelivery delivery, RpcParams rpcParams)
		{
			if (this.m_GroupSendTarget == null)
			{
				if (behaviour.IsServer)
				{
					this.m_GroupSendTarget = new RpcTargetGroup(this.m_NetworkManager);
				}
				else
				{
					this.m_GroupSendTarget = new ProxyRpcTargetGroup(this.m_NetworkManager);
				}
			}
			this.m_GroupSendTarget.Clear();
			if (behaviour.IsServer)
			{
				using (HashSet<ulong>.Enumerator enumerator = behaviour.NetworkObject.Observers.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ulong num = enumerator.Current;
						if (num != behaviour.NetworkManager.LocalClientId)
						{
							this.m_GroupSendTarget.Add(num);
						}
					}
					goto IL_E0;
				}
			}
			foreach (ulong num2 in this.m_NetworkManager.ConnectedClientsIds)
			{
				if (num2 != behaviour.NetworkManager.LocalClientId && num2 != 0UL)
				{
					this.m_GroupSendTarget.Add(num2);
				}
			}
			IL_E0:
			this.m_GroupSendTarget.Target.Send(behaviour, ref message, delivery, rpcParams);
			if (!behaviour.IsServer)
			{
				this.m_ServerRpcTarget.Send(behaviour, ref message, delivery, rpcParams);
			}
		}

		// Token: 0x06000328 RID: 808 RVA: 0x00010404 File Offset: 0x0000E604
		internal NotMeRpcTarget(NetworkManager manager) : base(manager)
		{
			this.m_ServerRpcTarget = new ServerRpcTarget(manager);
		}

		// Token: 0x040001CF RID: 463
		private IGroupRpcTarget m_GroupSendTarget;

		// Token: 0x040001D0 RID: 464
		private ServerRpcTarget m_ServerRpcTarget;
	}
}
