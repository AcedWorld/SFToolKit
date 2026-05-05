using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;

namespace Unity.Services.Relay.ErrorMitigation
{
	// Token: 0x02000047 RID: 71
	internal class RetryPolicy<T> : IRetryPolicy<T>
	{
		// Token: 0x1700005A RID: 90
		// (get) Token: 0x06000137 RID: 311 RVA: 0x00004D84 File Offset: 0x00002F84
		// (set) Token: 0x06000138 RID: 312 RVA: 0x00004D8C File Offset: 0x00002F8C
		private Func<int, Task<T>> CreateOperation { get; set; }

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x06000139 RID: 313 RVA: 0x00004D95 File Offset: 0x00002F95
		// (set) Token: 0x0600013A RID: 314 RVA: 0x00004D9D File Offset: 0x00002F9D
		private Func<T, Task<bool>> RetryCondition { get; set; }

		// Token: 0x0600013B RID: 315 RVA: 0x00004DA6 File Offset: 0x00002FA6
		private RetryPolicy(Func<int, Task<T>> createAsyncOp)
		{
			this.CreateOperation = createAsyncOp;
		}

		// Token: 0x0600013C RID: 316 RVA: 0x00004DC0 File Offset: 0x00002FC0
		private RetryPolicy(Func<Task<T>> createAsyncOp)
		{
			this.CreateOperation = ((int _) => createAsyncOp());
		}

		// Token: 0x0600013D RID: 317 RVA: 0x00004DFD File Offset: 0x00002FFD
		private static float AddJitter(float number, float magnitude)
		{
			return number + Random.value * magnitude;
		}

		// Token: 0x0600013E RID: 318 RVA: 0x00004E08 File Offset: 0x00003008
		private static float Pow2(float exponent, float scale)
		{
			return (float)(Math.Pow(2.0, (double)exponent) * (double)scale);
		}

		// Token: 0x0600013F RID: 319 RVA: 0x00004E1E File Offset: 0x0000301E
		private static float CalculateDelay(int attemptNumber, float maxDelayTime, float delayScale, float jitterMagnitude)
		{
			return Math.Min(RetryPolicy<T>.AddJitter(RetryPolicy<T>.Pow2((float)attemptNumber, delayScale), jitterMagnitude), maxDelayTime);
		}

		// Token: 0x06000140 RID: 320 RVA: 0x00004E34 File Offset: 0x00003034
		public IRetryPolicy<T> WithJitterMagnitude(float magnitude)
		{
			this._retryPolicyConfig.JitterMagnitude = magnitude;
			return this;
		}

		// Token: 0x06000141 RID: 321 RVA: 0x00004E43 File Offset: 0x00003043
		public IRetryPolicy<T> WithDelayScale(float scale)
		{
			this._retryPolicyConfig.DelayScale = scale;
			return this;
		}

		// Token: 0x06000142 RID: 322 RVA: 0x00004E52 File Offset: 0x00003052
		public IRetryPolicy<T> WithMaxDelayTime(float time)
		{
			this._retryPolicyConfig.MaxDelayTime = time;
			return this;
		}

		// Token: 0x06000143 RID: 323 RVA: 0x00004E61 File Offset: 0x00003061
		public static RetryPolicy<T> ForOperation(Func<int, Task<T>> operation)
		{
			return new RetryPolicy<T>(operation);
		}

		// Token: 0x06000144 RID: 324 RVA: 0x00004E69 File Offset: 0x00003069
		public static RetryPolicy<T> ForOperation(Func<Task<T>> operation)
		{
			return new RetryPolicy<T>(operation);
		}

		// Token: 0x06000145 RID: 325 RVA: 0x00004E71 File Offset: 0x00003071
		public IRetryPolicy<T> WithRetryCondition(Func<T, Task<bool>> shouldRetry)
		{
			this.RetryCondition = shouldRetry;
			return this;
		}

		// Token: 0x06000146 RID: 326 RVA: 0x00004E7B File Offset: 0x0000307B
		public IRetryPolicy<T> UptoMaximumRetries(uint amount)
		{
			this._retryPolicyConfig.MaxRetries = amount;
			return this;
		}

		// Token: 0x06000147 RID: 327 RVA: 0x00004E8A File Offset: 0x0000308A
		public IRetryPolicy<T> HandleException<TException>() where TException : Exception
		{
			this._retryPolicyConfig.HandleException<TException>();
			return this;
		}

		// Token: 0x06000148 RID: 328 RVA: 0x00004E98 File Offset: 0x00003098
		public IRetryPolicy<T> HandleException<TException>(Func<TException, bool> condition) where TException : Exception
		{
			this._retryPolicyConfig.HandleException<TException>(condition);
			return this;
		}

		// Token: 0x06000149 RID: 329 RVA: 0x00004EA8 File Offset: 0x000030A8
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

		// Token: 0x0400009F RID: 159
		private RetryPolicyConfig _retryPolicyConfig = new RetryPolicyConfig();
	}
}
