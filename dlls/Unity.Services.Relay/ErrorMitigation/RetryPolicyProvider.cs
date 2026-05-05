using System;
using System.Threading.Tasks;

namespace Unity.Services.Relay.ErrorMitigation
{
	// Token: 0x02000046 RID: 70
	internal class RetryPolicyProvider : IRetryPolicyProvider
	{
		// Token: 0x06000134 RID: 308 RVA: 0x00004D6C File Offset: 0x00002F6C
		public IRetryPolicy<T> ForOperation<T>(Func<int, Task<T>> operation)
		{
			return RetryPolicy<T>.ForOperation(operation);
		}

		// Token: 0x06000135 RID: 309 RVA: 0x00004D74 File Offset: 0x00002F74
		public IRetryPolicy<T> ForOperation<T>(Func<Task<T>> operation)
		{
			return RetryPolicy<T>.ForOperation(operation);
		}
	}
}
