using System;
using System.Threading.Tasks;

namespace Unity.Services.Lobbies.ErrorMitigation
{
	// Token: 0x0200005F RID: 95
	internal interface IRetryPolicy<T>
	{
		// Token: 0x06000277 RID: 631
		IRetryPolicy<T> WithJitterMagnitude(float magnitude);

		// Token: 0x06000278 RID: 632
		IRetryPolicy<T> WithDelayScale(float scale);

		// Token: 0x06000279 RID: 633
		IRetryPolicy<T> WithMaxDelayTime(float time);

		// Token: 0x0600027A RID: 634
		IRetryPolicy<T> WithRetryCondition(Func<T, Task<bool>> shouldRetry);

		// Token: 0x0600027B RID: 635
		IRetryPolicy<T> UptoMaximumRetries(uint amount);

		// Token: 0x0600027C RID: 636
		IRetryPolicy<T> HandleException<TException>() where TException : Exception;

		// Token: 0x0600027D RID: 637
		IRetryPolicy<T> HandleException<TException>(Func<TException, bool> condition) where TException : Exception;

		// Token: 0x0600027E RID: 638
		Task<T> RunAsync(RetryPolicyConfig retryPolicyConfig = null);
	}
}
