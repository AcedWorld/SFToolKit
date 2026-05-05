using System;

namespace Unity.Netcode
{
	// Token: 0x02000094 RID: 148
	internal class DirectSendRpcTarget : BaseRpcTarget, IIndividualRpcTarget
	{
		// Token: 0x17000079 RID: 121
		// (get) Token: 0x06000315 RID: 789 RVA: 0x0001007F File Offset: 0x0000E27F
		public BaseRpcTarget Target
		{
			get
			{
				return this;
			}
		}

		// Token: 0x06000316 RID: 790 RVA: 0x00010082 File Offset: 0x0000E282
		public override void Dispose()
		{
			base.CheckLockBeforeDispose();
		}

		// Token: 0x06000317 RID: 791 RVA: 0x0001008A File Offset: 0x0000E28A
		internal override void Send(NetworkBehaviour behaviour, ref RpcMessage message, NetworkDelivery delivery, RpcParams rpcParams)
		{
			base.SendMessageToClient(behaviour, this.ClientId, ref message, delivery);
		}

		// Token: 0x06000318 RID: 792 RVA: 0x0001009B File Offset: 0x0000E29B
		public void SetClientId(ulong clientId)
		{
			this.ClientId = clientId;
		}

		// Token: 0x06000319 RID: 793 RVA: 0x00010076 File Offset: 0x0000E276
		internal DirectSendRpcTarget(NetworkManager manager) : base(manager)
		{
		}

		// Token: 0x0600031A RID: 794 RVA: 0x000100A4 File Offset: 0x0000E2A4
		internal DirectSendRpcTarget(ulong clientId, NetworkManager manager) : base(manager)
		{
			this.ClientId = clientId;
		}

		// Token: 0x040001CC RID: 460
		internal ulong ClientId;
	}
}
