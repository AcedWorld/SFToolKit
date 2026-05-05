using System;
using System.Threading.Tasks;

namespace Unity.Services.Qos.V2.ErrorMitigation
{
	// Token: 0x0200003F RID: 63
	internal interface IRetryPolicy<T>
	{
		// Token: 0x06000112 RID: 274
		IRetryPolicy<T> WithJitterMagnitude(float magnitude);

		// Token: 0x06000113 RID: 275
		IRetryPolicy<T> WithDelayScale(float scale);

		// Token: 0x06000114 RID: 276
		IRetryPolicy<T> WithMaxDelayTime(float time);

		// Token: 0x06000115 RID: 277
		IRetryPolicy<T> WithRetryCondition(Func<T, Task<bool>> shouldRetry);

		// Token: 0x06000116 RID: 278
		IRetryPolicy<T> UptoMaximumRetries(uint amount);

		// Token: 0x06000117 RID: 279
		IRetryPolicy<T> HandleException<TException>() where TException : Exception;

		// Token: 0x06000118 RID: 280
		IRetryPolicy<T> HandleException<TException>(Func<TException, bool> condition) where TException : Exception;

		// Token: 0x06000119 RID: 281
		Task<T> RunAsync(RetryPolicyConfig retryPolicyConfig = null);
	}
}
