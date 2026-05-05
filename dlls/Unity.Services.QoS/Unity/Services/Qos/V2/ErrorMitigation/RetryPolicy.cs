using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;

namespace Unity.Services.Qos.V2.ErrorMitigation
{
	// Token: 0x02000041 RID: 65
	internal class RetryPolicy<T> : IRetryPolicy<T>
	{
		// Token: 0x17000051 RID: 81
		// (get) Token: 0x0600011D RID: 285 RVA: 0x00005718 File Offset: 0x00003918
		// (set) Token: 0x0600011E RID: 286 RVA: 0x00005720 File Offset: 0x00003920
		private Func<int, Task<T>> CreateOperation { get; set; }

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x0600011F RID: 287 RVA: 0x00005729 File Offset: 0x00003929
		// (set) Token: 0x06000120 RID: 288 RVA: 0x00005731 File Offset: 0x00003931
		private Func<T, Task<bool>> RetryCondition { get; set; }

		// Token: 0x06000121 RID: 289 RVA: 0x0000573A File Offset: 0x0000393A
		private RetryPolicy(Func<int, Task<T>> createAsyncOp)
		{
			this.CreateOperation = createAsyncOp;
		}

		// Token: 0x06000122 RID: 290 RVA: 0x00005754 File Offset: 0x00003954
		private RetryPolicy(Func<Task<T>> createAsyncOp)
		{
			this.CreateOperation = ((int _) => createAsyncOp());
		}

		// Token: 0x06000123 RID: 291 RVA: 0x00005791 File Offset: 0x00003991
		private static float AddJitter(float number, float magnitude)
		{
			return number + Random.value * magnitude;
		}

		// Token: 0x06000124 RID: 292 RVA: 0x0000579C File Offset: 0x0000399C
		private static float Pow2(float exponent, float scale)
		{
			return (float)(Math.Pow(2.0, (double)exponent) * (double)scale);
		}

		// Token: 0x06000125 RID: 293 RVA: 0x000057B2 File Offset: 0x000039B2
		private static float CalculateDelay(int attemptNumber, float maxDelayTime, float delayScale, float jitterMagnitude)
		{
			return Math.Min(RetryPolicy<T>.AddJitter(RetryPolicy<T>.Pow2((float)attemptNumber, delayScale), jitterMagnitude), maxDelayTime);
		}

		// Token: 0x06000126 RID: 294 RVA: 0x000057C8 File Offset: 0x000039C8
		public IRetryPolicy<T> WithJitterMagnitude(float magnitude)
		{
			this._retryPolicyConfig.JitterMagnitude = magnitude;
			return this;
		}

		// Token: 0x06000127 RID: 295 RVA: 0x000057D7 File Offset: 0x000039D7
		public IRetryPolicy<T> WithDelayScale(float scale)
		{
			this._retryPolicyConfig.DelayScale = scale;
			return this;
		}

		// Token: 0x06000128 RID: 296 RVA: 0x000057E6 File Offset: 0x000039E6
		public IRetryPolicy<T> WithMaxDelayTime(float time)
		{
			this._retryPolicyConfig.MaxDelayTime = time;
			return this;
		}

		// Token: 0x06000129 RID: 297 RVA: 0x000057F5 File Offset: 0x000039F5
		public static RetryPolicy<T> ForOperation(Func<int, Task<T>> operation)
		{
			return new RetryPolicy<T>(operation);
		}

		// Token: 0x0600012A RID: 298 RVA: 0x000057FD File Offset: 0x000039FD
		public static RetryPolicy<T> ForOperation(Func<Task<T>> operation)
		{
			return new RetryPolicy<T>(operation);
		}

		// Token: 0x0600012B RID: 299 RVA: 0x00005805 File Offset: 0x00003A05
		public IRetryPolicy<T> WithRetryCondition(Func<T, Task<bool>> shouldRetry)
		{
			this.RetryCondition = shouldRetry;
			return this;
		}

		// Token: 0x0600012C RID: 300 RVA: 0x0000580F File Offset: 0x00003A0F
		public IRetryPolicy<T> UptoMaximumRetries(uint amount)
		{
			this._retryPolicyConfig.MaxRetries = amount;
			return this;
		}

		// Token: 0x0600012D RID: 301 RVA: 0x0000581E File Offset: 0x00003A1E
		public IRetryPolicy<T> HandleException<TException>() where TException : Exception
		{
			this._retryPolicyConfig.HandleException<TException>();
			return this;
		}

		// Token: 0x0600012E RID: 302 RVA: 0x0000582C File Offset: 0x00003A2C
		public IRetryPolicy<T> HandleException<TException>(Func<TException, bool> condition) where TException : Exception
		{
			this._retryPolicyConfig.HandleException<TException>(condition);
			return this;
		}

		// Token: 0x0600012F RID: 303 RVA: 0x0000583C File Offset: 0x00003A3C
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

		// Token: 0x0400009B RID: 155
		private RetryPolicyConfig _retryPolicyConfig = new RetryPolicyConfig();
	}
}
