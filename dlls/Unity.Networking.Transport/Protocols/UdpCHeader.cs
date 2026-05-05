using System;

namespace Unity.Networking.Transport.Protocols
{
	// Token: 0x020000A6 RID: 166
	internal struct UdpCHeader
	{
		// Token: 0x0400022C RID: 556
		public const int Length = 10;

		// Token: 0x0400022D RID: 557
		public byte Type;

		// Token: 0x0400022E RID: 558
		public UdpCHeader.HeaderFlags Flags;

		// Token: 0x0400022F RID: 559
		public SessionIdToken SessionToken;

		// Token: 0x020000A7 RID: 167
		[Flags]
		public enum HeaderFlags : byte
		{
			// Token: 0x04000231 RID: 561
			HasConnectToken = 1,
			// Token: 0x04000232 RID: 562
			HasPipeline = 2
		}
	}
}
