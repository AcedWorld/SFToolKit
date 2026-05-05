using System;

namespace Unity.Services.Lobbies.Helpers
{
	// Token: 0x0200005C RID: 92
	internal static class AsyncOpRetry
	{
		// Token: 0x0600025E RID: 606 RVA: 0x000092ED File Offset: 0x000074ED
		public static AsyncOpRetry<T> FromCreateAsync<T>(Func<int, T> op)
		{
			return AsyncOpRetry<T>.FromCreateAsync(op);
		}
	}
}
