using System;

namespace Unity.Services.Qos.Helpers
{
	// Token: 0x0200006C RID: 108
	internal static class AsyncOpRetry
	{
		// Token: 0x060001F1 RID: 497 RVA: 0x00007BB4 File Offset: 0x00005DB4
		public static AsyncOpRetry<T> FromCreateAsync<T>(Func<int, T> op)
		{
			return AsyncOpRetry<T>.FromCreateAsync(op);
		}
	}
}
