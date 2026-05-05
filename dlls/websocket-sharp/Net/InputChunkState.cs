using System;

namespace WebSocketSharp.Net
{
	// Token: 0x02000036 RID: 54
	internal enum InputChunkState
	{
		// Token: 0x0400018B RID: 395
		None,
		// Token: 0x0400018C RID: 396
		Data,
		// Token: 0x0400018D RID: 397
		DataEnded,
		// Token: 0x0400018E RID: 398
		Trailer,
		// Token: 0x0400018F RID: 399
		End
	}
}
