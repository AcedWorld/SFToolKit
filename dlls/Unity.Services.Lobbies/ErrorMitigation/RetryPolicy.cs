using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;

namespace Unity.Services.Lobbies.ErrorMitigation
{
	// Token: 0x02000061 RID: 97
	internal class RetryPolicy<T> : IRetryPolicy<T>
	{
		// Token: 0x170000CA RID: 202
		// (get) Token: 0x06000282 RID: 642 RVA: 0x0000941D File Offset: 0x0000761D
		// (set) Token: 0x06000283 RID: 643 RVA: 0x00009425 File Offset: 0x00007625
		private Func<int, Task<T>> CreateOperation { get; set; }

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x06000284 RID: 644 RVA: 0x0000942E File Offset: 0x0000762E
		// (set) Token: 0x06000285 RID: 645 RVA: 0x00009436 File Offset: 0x00007636
		private Func<T, Task<bool>> RetryCondition { get; set; }

		// Token: 0x06000286 RID: 646 RVA: 0x0000943F File Offset: 0x0000763F
		private RetryPolicy(Func<int, Task<T>> createAsyncOp)
		{
			this.CreateOperation = createAsyncOp;
		}

		// Token: 0x06000287 RID: 647 RVA: 0x0000945C File Offset: 0x0000765C
		private RetryPolicy(Func<Task<T>> createAsyncOp)
		{
			this.CreateOperation = ((int _) => createAsyncOp());
		}

		// Token: 0x06000288 RID: 648 RVA: 0x00009499 File Offset: 0x00007699
		private static float AddJitter(float number, float magnitude)
		{
			return number + Random.value * magnitude;
		}

		// Token: 0x06000289 RID: 649 RVA: 0x000094A4 File Offset: 0x000076A4
		private static float Pow2(float exponent, float scale)
		{
			return (float)(Math.Pow(2.0, (double)exponent) * (double)scale);
		}

		// Token: 0x0600028A RID: 650 RVA: 0x000094BA File Offset: 0x000076BA
		private static float CalculateDelay(int attemptNumber, float maxDelayTime, float delayScale, float jitterMagnitude)
		{
			return Math.Min(RetryPolicy<T>.AddJitter(RetryPolicy<T>.Pow2((float)attemptNumber, delayScale), jitterMagnitude), maxDelayTime);
		}

		// Token: 0x0600028B RID: 651 RVA: 0x000094D0 File Offset: 0x000076D0
		public IRetryPolicy<T> WithJitterMagnitude(float magnitude)
		{
			this._retryPolicyConfig.JitterMagnitude = magnitude;
			return this;
		}

		// Token: 0x0600028C RID: 652 RVA: 0x000094DF File Offset: 0x000076DF
		public IRetryPolicy<T> WithDelayScale(float scale)
		{
			this._retryPolicyConfig.DelayScale = scale;
			return this;
		}

		// Token: 0x0600028D RID: 653 RVA: 0x000094EE File Offset: 0x000076EE
		public IRetryPolicy<T> WithMaxDelayTime(float time)
		{
			this._retryPolicyConfig.MaxDelayTime = time;
			return this;
		}

		// Token: 0x0600028E RID: 654 RVA: 0x000094FD File Offset: 0x000076FD
		public static RetryPolicy<T> ForOperation(Func<int, Task<T>> operation)
		{
			return new RetryPolicy<T>(operation);
		}

		// Token: 0x0600028F RID: 655 RVA: 0x00009505 File Offset: 0x00007705
		public static RetryPolicy<T> ForOperation(Func<Task<T>> operation)
		{
			return new RetryPolicy<T>(operation);
		}

		// Token: 0x06000290 RID: 656 RVA: 0x0000950D File Offset: 0x0000770D
		public IRetryPolicy<T> WithRetryCondition(Func<T, Task<bool>> shouldRetry)
		{
			this.RetryCondition = shouldRetry;
			return this;
		}

		// Token: 0x06000291 RID: 657 RVA: 0x00009517 File Offset: 0x00007717
		public IRetryPolicy<T> UptoMaximumRetries(uint amount)
		{
			this._retryPolicyConfig.MaxRetries = amount;
			return this;
		}

		// Token: 0x06000292 RID: 658 RVA: 0x00009526 File Offset: 0x00007726
		public IRetryPolicy<T> HandleException<TException>() where TException : Exception
		{
			this._retryPolicyConfig.HandleException<TException>();
			return this;
		}

		// Token: 0x06000293 RID: 659 RVA: 0x00009534 File Offset: 0x00007734
		public IRetryPolicy<T> HandleException<TException>(Func<TException, bool> condition) where TException : Exception
		{
			this._retryPolicyConfig.HandleException<TException>(condition);
			return this;
		}

		// Token: 0x06000294 RID: 660 RVA: 0x00009544 File Offset: 0x00007744
		public Task<T> RunAsync(RetryPolicyConfig retryPolicyConfig = null)
		{
			RetryPolicy<T>.<RunAsync>d__23 <RunAsync>d__;
			<RunAsync>d__.<>t__builder = AsyncTaskMethodBuilder<T>.Create();
			<RunAsync>d__.<>4__this = this;
			<RunAsync>d__.retryPolicyConfig = retryPolicyConfig;
			<RunAsync>d__.<>1__state = -1;
			<RunAsync>d__.<>t__builder.Start<RetryPolicy<T>.<RunAsync>d__23>(ref <RunAsync>d__);
			return <RunAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0400012A RID: 298
		private RetryPolicyConfig _retryPolicyConfig = new RetryPolicyConfig();
	}
}
