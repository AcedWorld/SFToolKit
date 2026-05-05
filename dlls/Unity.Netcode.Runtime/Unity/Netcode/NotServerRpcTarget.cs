using System;
using System.Collections.Generic;

namespace Unity.Netcode
{
	// Token: 0x0200009B RID: 155
	internal class NotServerRpcTarget : BaseRpcTarget
	{
		// Token: 0x0600032C RID: 812 RVA: 0x000105E1 File Offset: 0x0000E7E1
		public override void Dispose()
		{
			this.m_LocalSendRpcTarget.Dispose();
			if (this.m_GroupSendTarget != null)
			{
				this.m_GroupSendTarget.Target.Dispose();
				this.m_GroupSendTarget = null;
			}
		}

		// Token: 0x0600032D RID: 813 RVA: 0x00010610 File Offset: 0x0000E810
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
						if (num != 0UL)
						{
							this.m_GroupSendTarget.Add(num);
						}
					}
					goto IL_E7;
				}
			}
			foreach (ulong num2 in this.m_NetworkManager.ConnectedClientsIds)
			{
				if (num2 != 0UL)
				{
					if (num2 == behaviour.NetworkManager.LocalClientId)
					{
						this.m_LocalSendRpcTarget.Send(behaviour, ref message, delivery, rpcParams);
					}
					else
					{
						this.m_GroupSendTarget.Add(num2);
					}
				}
			}
			IL_E7:
			this.m_GroupSendTarget.Target.Send(behaviour, ref message, delivery, rpcParams);
		}

		// Token: 0x0600032E RID: 814 RVA: 0x00010738 File Offset: 0x0000E938
		internal NotServerRpcTarget(NetworkManager manager) : base(manager)
		{
			this.m_LocalSendRpcTarget = new LocalSendRpcTarget(manager);
		}

		// Token: 0x040001D4 RID: 468
		private IGroupRpcTarget m_GroupSendTarget;

		// Token: 0x040001D5 RID: 469
		private LocalSendRpcTarget m_LocalSendRpcTarget;
	}
}
