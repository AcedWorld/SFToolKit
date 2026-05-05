using System;

namespace Unity.Netcode
{
	// Token: 0x0200009D RID: 157
	internal class ProxyRpcTarget : ProxyRpcTargetGroup, IIndividualRpcTarget
	{
		// Token: 0x06000332 RID: 818 RVA: 0x0001084C File Offset: 0x0000EA4C
		internal ProxyRpcTarget(ulong clientId, NetworkManager manager) : base(manager)
		{
			base.Add(clientId);
		}

		// Token: 0x06000333 RID: 819 RVA: 0x0001085C File Offset: 0x0000EA5C
		public void SetClientId(ulong clientId)
		{
			base.Clear();
			base.Add(clientId);
		}
	}
}
