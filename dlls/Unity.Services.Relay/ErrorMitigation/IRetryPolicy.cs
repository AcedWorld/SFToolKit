using System;
using System.Threading.Tasks;

namespace Unity.Services.Relay.ErrorMitigation
{
	// Token: 0x02000045 RID: 69
	internal interface IRetryPolicy<T>
	{
		// Token: 0x0600012C RID: 300
		IRetryPolicy<T> WithJitterMagnitude(float magnitude);

		// Token: 0x0600012D RID: 301
		IRetryPolicy<T> WithDelayScale(float scale);

		// Token: 0x0600012E RID: 302
		IRetryPolicy<T> WithMaxDelayTime(float time);

		// Token: 0x0600012F RID: 303
		IRetryPolicy<T> WithRetryCondition(Func<T, Task<bool>> shouldRetry);

		// Token: 0x06000130 RID: 304
		IRetryPolicy<T> UptoMaximumRetries(uint amount);

		// Token: 0x06000131 RID: 305
		IRetryPolicy<T> HandleException<TException>() where TException : Exception;

		// Token: 0x06000132 RID: 306
		IRetryPolicy<T> HandleException<TException>(Func<TException, bool> condition) where TException : Exception;

		// Token: 0x06000133 RID: 307
		Task<T> RunAsync(RetryPolicyConfig retryPolicyConfig = null);
	}
}
