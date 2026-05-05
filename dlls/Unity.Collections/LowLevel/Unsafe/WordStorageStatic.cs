using System;

namespace Unity.Collections.LowLevel.Unsafe
{
	// Token: 0x020000E4 RID: 228
	[Obsolete("This storage will no longer be used. (RemovedAfter 2021-06-01)")]
	internal sealed class WordStorageStatic
	{
		// Token: 0x06000922 RID: 2338 RVA: 0x000020C3 File Offset: 0x000002C3
		private WordStorageStatic()
		{
		}

		// Token: 0x04000326 RID: 806
		public static WordStorageStatic.Thing Ref;

		// Token: 0x020000E5 RID: 229
		public struct Thing
		{
			// Token: 0x04000327 RID: 807
			public WordStorage Data;
		}
	}
}
