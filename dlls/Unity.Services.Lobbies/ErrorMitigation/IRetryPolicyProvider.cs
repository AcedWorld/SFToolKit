using System;
using System.Threading.Tasks;

namespace Unity.Services.Lobbies.ErrorMitigation
{
	// Token: 0x0200005E RID: 94
	internal interface IRetryPolicyProvider
	{
		// Token: 0x06000275 RID: 629
		IRetryPolicy<T> ForOperation<T>(Func<int, Task<T>> operation);

		// Token: 0x06000276 RID: 630
		IRetryPolicy<T> ForOperation<T>(Func<Task<T>> operation);
	}
}
