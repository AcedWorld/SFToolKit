using System;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020001B7 RID: 439
	public class AsyncHelpers
	{
		// Token: 0x06000A46 RID: 2630 RVA: 0x0000F707 File Offset: 0x0000D907
		public static XAsyncBlock WrapAsyncBlock(XTaskQueueHandle queue, XAsyncCompletionRoutine callback)
		{
			return new XAsyncBlock(queue, callback, IntPtr.Zero);
		}

		// Token: 0x06000A47 RID: 2631 RVA: 0x0000F715 File Offset: 0x0000D915
		internal static void CleanupAsyncBlock(XAsyncBlock block)
		{
			block.Dispose();
		}
	}
}
