using System;
using System.Threading.Tasks;

namespace Unity.Services.Qos.ErrorMitigation
{
	// Token: 0x0200006F RID: 111
	internal interface IRetryPolicy<T>
	{
		// Token: 0x0600020A RID: 522
		IRetryPolicy<T> WithJitterMagnitude(float magnitude);

		// Token: 0x0600020B RID: 523
		IRetryPolicy<T> WithDelayScale(float scale);

		// Token: 0x0600020C RID: 524
		IRetryPolicy<T> WithMaxDelayTime(float time);

		// Token: 0x0600020D RID: 525
		IRetryPolicy<T> WithRetryCondition(Func<T, Task<bool>> shouldRetry);

		// Token: 0x0600020E RID: 526
		IRetryPolicy<T> UptoMaximumRetries(uint amount);

		// Token: 0x0600020F RID: 527
		IRetryPolicy<T> HandleException<TException>() where TException : Exception;

		// Token: 0x06000210 RID: 528
		IRetryPolicy<T> HandleException<TException>(Func<TException, bool> condition) where TException : Exception;

		// Token: 0x06000211 RID: 529
		Task<T> RunAsync(RetryPolicyConfig retryPolicyConfig = null);
	}
}
