using System;

namespace UnityWebSocketSharp.Net
{
	// Token: 0x02000042 RID: 66
	internal enum InputChunkState
	{
		// Token: 0x0400022E RID: 558
		None,
		// Token: 0x0400022F RID: 559
		Data,
		// Token: 0x04000230 RID: 560
		DataEnded,
		// Token: 0x04000231 RID: 561
		Trailer,
		// Token: 0x04000232 RID: 562
		End
	}
}
