using System;

namespace Unity.Networking.Transport.TLS
{
	// Token: 0x02000081 RID: 129
	internal struct SecureUserData
	{
		// Token: 0x040001A7 RID: 423
		public IntPtr StreamData;

		// Token: 0x040001A8 RID: 424
		public NetworkSendInterface Interface;

		// Token: 0x040001A9 RID: 425
		public NetworkInterfaceEndPoint Remote;

		// Token: 0x040001AA RID: 426
		public NetworkSendQueueHandle QueueHandle;

		// Token: 0x040001AB RID: 427
		public int Size;

		// Token: 0x040001AC RID: 428
		public int BytesProcessed;
	}
}
