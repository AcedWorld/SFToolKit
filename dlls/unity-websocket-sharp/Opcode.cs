using System;

namespace UnityWebSocketSharp
{
	// Token: 0x02000012 RID: 18
	internal enum Opcode : byte
	{
		// Token: 0x04000044 RID: 68
		Cont,
		// Token: 0x04000045 RID: 69
		Text,
		// Token: 0x04000046 RID: 70
		Binary,
		// Token: 0x04000047 RID: 71
		Close = 8,
		// Token: 0x04000048 RID: 72
		Ping,
		// Token: 0x04000049 RID: 73
		Pong
	}
}
