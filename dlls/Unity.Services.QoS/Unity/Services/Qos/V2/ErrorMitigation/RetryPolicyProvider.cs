using System;
using System.Threading.Tasks;

namespace Unity.Services.Qos.V2.ErrorMitigation
{
	// Token: 0x02000040 RID: 64
	internal class RetryPolicyProvider : IRetryPolicyProvider
	{
		// Token: 0x0600011A RID: 282 RVA: 0x00005700 File Offset: 0x00003900
		public IRetryPolicy<T> ForOperation<T>(Func<int, Task<T>> operation)
		{
			return RetryPolicy<T>.ForOperation(operation);
		}

		// Token: 0x0600011B RID: 283 RVA: 0x00005708 File Offset: 0x00003908
		public IRetryPolicy<T> ForOperation<T>(Func<Task<T>> operation)
		{
			return RetryPolicy<T>.ForOperation(operation);
		}
	}
}
