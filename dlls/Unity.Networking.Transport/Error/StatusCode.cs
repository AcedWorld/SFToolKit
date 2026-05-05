using System;

namespace Unity.Networking.Transport.Error
{
	// Token: 0x020000A9 RID: 169
	public enum StatusCode
	{
		// Token: 0x0400023A RID: 570
		Success,
		// Token: 0x0400023B RID: 571
		NetworkIdMismatch = -1,
		// Token: 0x0400023C RID: 572
		NetworkVersionMismatch = -2,
		// Token: 0x0400023D RID: 573
		NetworkStateMismatch = -3,
		// Token: 0x0400023E RID: 574
		NetworkPacketOverflow = -4,
		// Token: 0x0400023F RID: 575
		NetworkSendQueueFull = -5,
		// Token: 0x04000240 RID: 576
		NetworkHeaderInvalid = -6,
		// Token: 0x04000241 RID: 577
		NetworkDriverParallelForErr = -7,
		// Token: 0x04000242 RID: 578
		NetworkSendHandleInvalid = -8,
		// Token: 0x04000243 RID: 579
		NetworkArgumentMismatch = -9,
		// Token: 0x04000244 RID: 580
		NetworkSocketError = -10
	}
}
