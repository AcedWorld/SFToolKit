using System;
using System.Threading.Tasks;

namespace Unity.Services.Qos.V2.ErrorMitigation
{
	// Token: 0x0200003E RID: 62
	internal interface IRetryPolicyProvider
	{
		// Token: 0x06000110 RID: 272
		IRetryPolicy<T> ForOperation<T>(Func<int, Task<T>> operation);

		// Token: 0x06000111 RID: 273
		IRetryPolicy<T> ForOperation<T>(Func<Task<T>> operation);
	}
}
