using System;

namespace Unity.Services.Relay.Helpers
{
	// Token: 0x02000042 RID: 66
	internal static class AsyncOpRetry
	{
		// Token: 0x06000113 RID: 275 RVA: 0x00004C54 File Offset: 0x00002E54
		public static AsyncOpRetry<T> FromCreateAsync<T>(Func<int, T> op)
		{
			return AsyncOpRetry<T>.FromCreateAsync(op);
		}
	}
}
