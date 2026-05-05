using System;
using System.Collections.Generic;

namespace Unity.Netcode
{
	// Token: 0x0200009A RID: 154
	internal class NotOwnerRpcTarget : BaseRpcTarget
	{
		// Token: 0x06000329 RID: 809 RVA: 0x00010419 File Offset: 0x0000E619
		public override void Dispose()
		{
			this.m_ServerRpcTarget.Dispose();
			this.m_LocalSendRpcTarget.Dispose();
			if (this.m_GroupSendTarget != null)
			{
				this.m_GroupSendTarget.Target.Dispose();
				this.m_GroupSendTarget = null;
			}
		}

		// Token: 0x0600032A RID: 810 RVA: 0x00010450 File Offset: 0x0000E650
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
						if (num != behaviour.OwnerClientId && num != 0UL)
						{
							if (num == behaviour.NetworkManager.LocalClientId)
							{
								this.m_LocalSendRpcTarget.Send(behaviour, ref message, delivery, rpcParams);
							}
							else
							{
								this.m_GroupSendTarget.Add(num);
							}
						}
					}
					goto IL_119;
				}
			}
			foreach (ulong num2 in this.m_NetworkManager.ConnectedClientsIds)
			{
				if (num2 != behaviour.OwnerClientId && num2 != 0UL)
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
			IL_119:
			this.m_GroupSendTarget.Target.Send(behaviour, ref message, delivery, rpcParams);
			if (behaviour.OwnerClientId != 0UL)
			{
				this.m_ServerRpcTarget.Send(behaviour, ref message, delivery, rpcParams);
			}
		}

		// Token: 0x0600032B RID: 811 RVA: 0x000105C0 File Offset: 0x0000E7C0
		internal NotOwnerRpcTarget(NetworkManager manager) : base(manager)
		{
			this.m_ServerRpcTarget = new ServerRpcTarget(manager);
			this.m_LocalSendRpcTarget = new LocalSendRpcTarget(manager);
		}

		// Token: 0x040001D1 RID: 465
		private IGroupRpcTarget m_GroupSendTarget;

		// Token: 0x040001D2 RID: 466
		private ServerRpcTarget m_ServerRpcTarget;

		// Token: 0x040001D3 RID: 467
		private LocalSendRpcTarget m_LocalSendRpcTarget;
	}
}
