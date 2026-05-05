using System;
using System.Threading.Tasks;

namespace Unity.Services.Relay.ErrorMitigation
{
	// Token: 0x02000044 RID: 68
	internal interface IRetryPolicyProvider
	{
		// Token: 0x0600012A RID: 298
		IRetryPolicy<T> ForOperation<T>(Func<int, Task<T>> operation);

		// Token: 0x0600012B RID: 299
		IRetryPolicy<T> ForOperation<T>(Func<Task<T>> operation);
	}
}
