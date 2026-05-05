using System;
using System.Threading.Tasks;

namespace Unity.Services.Qos.ErrorMitigation
{
	// Token: 0x02000070 RID: 112
	internal class RetryPolicyProvider : IRetryPolicyProvider
	{
		// Token: 0x06000212 RID: 530 RVA: 0x00007CCC File Offset: 0x00005ECC
		public IRetryPolicy<T> ForOperation<T>(Func<int, Task<T>> operation)
		{
			return RetryPolicy<T>.ForOperation(operation);
		}

		// Token: 0x06000213 RID: 531 RVA: 0x00007CD4 File Offset: 0x00005ED4
		public IRetryPolicy<T> ForOperation<T>(Func<Task<T>> operation)
		{
			return RetryPolicy<T>.ForOperation(operation);
		}
	}
}
