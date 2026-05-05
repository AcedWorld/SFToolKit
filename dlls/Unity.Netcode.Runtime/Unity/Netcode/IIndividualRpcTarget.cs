using System;

namespace Unity.Netcode
{
	// Token: 0x02000097 RID: 151
	internal interface IIndividualRpcTarget
	{
		// Token: 0x06000321 RID: 801
		void SetClientId(ulong clientId);

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x06000322 RID: 802
		BaseRpcTarget Target { get; }
	}
}
