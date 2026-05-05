using System;
using System.Threading.Tasks;

namespace Unity.Services.Lobbies.ErrorMitigation
{
	// Token: 0x02000060 RID: 96
	internal class RetryPolicyProvider : IRetryPolicyProvider
	{
		// Token: 0x0600027F RID: 639 RVA: 0x00009405 File Offset: 0x00007605
		public IRetryPolicy<T> ForOperation<T>(Func<int, Task<T>> operation)
		{
			return RetryPolicy<T>.ForOperation(operation);
		}

		// Token: 0x06000280 RID: 640 RVA: 0x0000940D File Offset: 0x0000760D
		public IRetryPolicy<T> ForOperation<T>(Func<Task<T>> operation)
		{
			return RetryPolicy<T>.ForOperation(operation);
		}
	}
}
