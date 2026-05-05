using System;

namespace Unity.Services.Qos.V2.Helpers
{
	// Token: 0x0200003C RID: 60
	internal static class AsyncOpRetry
	{
		// Token: 0x060000F9 RID: 249 RVA: 0x000055E8 File Offset: 0x000037E8
		public static AsyncOpRetry<T> FromCreateAsync<T>(Func<int, T> op)
		{
			return AsyncOpRetry<T>.FromCreateAsync(op);
		}
	}
}
