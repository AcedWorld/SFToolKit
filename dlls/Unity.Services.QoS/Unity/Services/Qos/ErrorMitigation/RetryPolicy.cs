using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;

namespace Unity.Services.Qos.ErrorMitigation
{
	// Token: 0x02000071 RID: 113
	internal class RetryPolicy<T> : IRetryPolicy<T>
	{
		// Token: 0x17000081 RID: 129
		// (get) Token: 0x06000215 RID: 533 RVA: 0x00007CE4 File Offset: 0x00005EE4
		// (set) Token: 0x06000216 RID: 534 RVA: 0x00007CEC File Offset: 0x00005EEC
		private Func<int, Task<T>> CreateOperation { get; set; }

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x06000217 RID: 535 RVA: 0x00007CF5 File Offset: 0x00005EF5
		// (set) Token: 0x06000218 RID: 536 RVA: 0x00007CFD File Offset: 0x00005EFD
		private Func<T, Task<bool>> RetryCondition { get; set; }

		// Token: 0x06000219 RID: 537 RVA: 0x00007D06 File Offset: 0x00005F06
		private RetryPolicy(Func<int, Task<T>> createAsyncOp)
		{
			this.CreateOperation = createAsyncOp;
		}

		// Token: 0x0600021A RID: 538 RVA: 0x00007D20 File Offset: 0x00005F20
		private RetryPolicy(Func<Task<T>> createAsyncOp)
		{
			this.CreateOperation = ((int _) => createAsyncOp());
		}

		// Token: 0x0600021B RID: 539 RVA: 0x00007D5D File Offset: 0x00005F5D
		private static float AddJitter(float number, float magnitude)
		{
			return number + Random.value * magnitude;
		}

		// Token: 0x0600021C RID: 540 RVA: 0x00007D68 File Offset: 0x00005F68
		private static float Pow2(float exponent, float scale)
		{
			return (float)(Math.Pow(2.0, (double)exponent) * (double)scale);
		}

		// Token: 0x0600021D RID: 541 RVA: 0x00007D7E File Offset: 0x00005F7E
		private static float CalculateDelay(int attemptNumber, float maxDelayTime, float delayScale, float jitterMagnitude)
		{
			return Math.Min(RetryPolicy<T>.AddJitter(RetryPolicy<T>.Pow2((float)attemptNumber, delayScale), jitterMagnitude), maxDelayTime);
		}

		// Token: 0x0600021E RID: 542 RVA: 0x00007D94 File Offset: 0x00005F94
		public IRetryPolicy<T> WithJitterMagnitude(float magnitude)
		{
			this._retryPolicyConfig.JitterMagnitude = magnitude;
			return this;
		}

		// Token: 0x0600021F RID: 543 RVA: 0x00007DA3 File Offset: 0x00005FA3
		public IRetryPolicy<T> WithDelayScale(float scale)
		{
			this._retryPolicyConfig.DelayScale = scale;
			return this;
		}

		// Token: 0x06000220 RID: 544 RVA: 0x00007DB2 File Offset: 0x00005FB2
		public IRetryPolicy<T> WithMaxDelayTime(float time)
		{
			this._retryPolicyConfig.MaxDelayTime = time;
			return this;
		}

		// Token: 0x06000221 RID: 545 RVA: 0x00007DC1 File Offset: 0x00005FC1
		public static RetryPolicy<T> ForOperation(Func<int, Task<T>> operation)
		{
			return new RetryPolicy<T>(operation);
		}

		// Token: 0x06000222 RID: 546 RVA: 0x00007DC9 File Offset: 0x00005FC9
		public static RetryPolicy<T> ForOperation(Func<Task<T>> operation)
		{
			return new RetryPolicy<T>(operation);
		}

		// Token: 0x06000223 RID: 547 RVA: 0x00007DD1 File Offset: 0x00005FD1
		public IRetryPolicy<T> WithRetryCondition(Func<T, Task<bool>> shouldRetry)
		{
			this.RetryCondition = shouldRetry;
			return this;
		}

		// Token: 0x06000224 RID: 548 RVA: 0x00007DDB File Offset: 0x00005FDB
		public IRetryPolicy<T> UptoMaximumRetries(uint amount)
		{
			this._retryPolicyConfig.MaxRetries = amount;
			return this;
		}

		// Token: 0x06000225 RID: 549 RVA: 0x00007DEA File Offset: 0x00005FEA
		public IRetryPolicy<T> HandleException<TException>() where TException : Exception
		{
			this._retryPolicyConfig.HandleException<TException>();
			return this;
		}

		// Token: 0x06000226 RID: 550 RVA: 0x00007DF8 File Offset: 0x00005FF8
		public IRetryPolicy<T> HandleException<TException>(Func<TException, bool> condition) where TException : Exception
		{
			this._retryPolicyConfig.HandleException<TException>(condition);
			return this;
		}

		// Token: 0x06000227 RID: 551 RVA: 0x00007E08 File Offset: 0x00006008
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

		// Token: 0x040000DF RID: 223
		private RetryPolicyConfig _retryPolicyConfig = new RetryPolicyConfig();
	}
}
