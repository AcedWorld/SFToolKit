using System;

namespace Unity.Netcode
{
	// Token: 0x02000120 RID: 288
	public enum NetworkDelivery
	{
		// Token: 0x04000374 RID: 884
		Unreliable,
		// Token: 0x04000375 RID: 885
		UnreliableSequenced,
		// Token: 0x04000376 RID: 886
		Reliable,
		// Token: 0x04000377 RID: 887
		ReliableSequenced,
		// Token: 0x04000378 RID: 888
		ReliableFragmentedSequenced
	}
}
