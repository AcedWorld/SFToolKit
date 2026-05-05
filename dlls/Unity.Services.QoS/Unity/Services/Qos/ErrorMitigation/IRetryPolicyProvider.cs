using System;
using System.Threading.Tasks;

namespace Unity.Services.Qos.ErrorMitigation
{
	// Token: 0x0200006E RID: 110
	internal interface IRetryPolicyProvider
	{
		// Token: 0x06000208 RID: 520
		IRetryPolicy<T> ForOperation<T>(Func<int, Task<T>> operation);

		// Token: 0x06000209 RID: 521
		IRetryPolicy<T> ForOperation<T>(Func<Task<T>> operation);
	}
}
