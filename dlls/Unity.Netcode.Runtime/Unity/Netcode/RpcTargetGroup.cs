using System;
using System.Collections.Generic;

namespace Unity.Netcode
{
	// Token: 0x020000A2 RID: 162
	internal class RpcTargetGroup : BaseRpcTarget, IGroupRpcTarget
	{
		// Token: 0x1700007D RID: 125
		// (get) Token: 0x06000347 RID: 839 RVA: 0x0001007F File Offset: 0x0000E27F
		public BaseRpcTarget Target
		{
			get
			{
				return this;
			}
		}

		// Token: 0x06000348 RID: 840 RVA: 0x00011118 File Offset: 0x0000F318
		public override void Dispose()
		{
			base.CheckLockBeforeDispose();
			foreach (BaseRpcTarget baseRpcTarget in this.Targets)
			{
				baseRpcTarget.Dispose();
			}
			foreach (DirectSendRpcTarget directSendRpcTarget in this.m_TargetCache)
			{
				directSendRpcTarget.Dispose();
			}
			this.m_LocalSendRpcTarget.Dispose();
		}

		// Token: 0x06000349 RID: 841 RVA: 0x000111B8 File Offset: 0x0000F3B8
		internal override void Send(NetworkBehaviour behaviour, ref RpcMessage message, NetworkDelivery delivery, RpcParams rpcParams)
		{
			foreach (BaseRpcTarget baseRpcTarget in this.Targets)
			{
				baseRpcTarget.Send(behaviour, ref message, delivery, rpcParams);
			}
		}

		// Token: 0x0600034A RID: 842 RVA: 0x00011210 File Offset: 0x0000F410
		public void Add(ulong clientId)
		{
			if (!this.m_Ids.Contains(clientId))
			{
				this.m_Ids.Add(clientId);
				if (clientId == this.m_NetworkManager.LocalClientId)
				{
					this.Targets.Add(this.m_LocalSendRpcTarget);
					return;
				}
				if (this.m_TargetCache.Count == 0)
				{
					this.Targets.Add(new DirectSendRpcTarget(this.m_NetworkManager)
					{
						ClientId = clientId
					});
					return;
				}
				DirectSendRpcTarget directSendRpcTarget = this.m_TargetCache.Pop();
				directSendRpcTarget.ClientId = clientId;
				this.Targets.Add(directSendRpcTarget);
			}
		}

		// Token: 0x0600034B RID: 843 RVA: 0x000112A4 File Offset: 0x0000F4A4
		public void Clear()
		{
			this.m_Ids.Clear();
			foreach (BaseRpcTarget baseRpcTarget in this.Targets)
			{
				DirectSendRpcTarget directSendRpcTarget = baseRpcTarget as DirectSendRpcTarget;
				if (directSendRpcTarget != null)
				{
					this.m_TargetCache.Push(directSendRpcTarget);
				}
			}
			this.Targets.Clear();
		}

		// Token: 0x0600034C RID: 844 RVA: 0x0001131C File Offset: 0x0000F51C
		internal RpcTargetGroup(NetworkManager manager) : base(manager)
		{
			this.m_LocalSendRpcTarget = new LocalSendRpcTarget(manager);
		}

		// Token: 0x040001F8 RID: 504
		internal List<BaseRpcTarget> Targets = new List<BaseRpcTarget>();

		// Token: 0x040001F9 RID: 505
		private LocalSendRpcTarget m_LocalSendRpcTarget;

		// Token: 0x040001FA RID: 506
		private HashSet<ulong> m_Ids = new HashSet<ulong>();

		// Token: 0x040001FB RID: 507
		private Stack<DirectSendRpcTarget> m_TargetCache = new Stack<DirectSendRpcTarget>();
	}
}
