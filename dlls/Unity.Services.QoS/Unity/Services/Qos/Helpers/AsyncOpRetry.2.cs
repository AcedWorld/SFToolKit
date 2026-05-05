using System;
using System.Collections;
using UnityEngine;

namespace Unity.Services.Qos.Helpers
{
	// Token: 0x0200006D RID: 109
	internal class AsyncOpRetry<T>
	{
		// Token: 0x1700007A RID: 122
		// (get) Token: 0x060001F2 RID: 498 RVA: 0x00007BBC File Offset: 0x00005DBC
		// (set) Token: 0x060001F3 RID: 499 RVA: 0x00007BC4 File Offset: 0x00005DC4
		private uint MaxRetries { get; set; } = 4U;

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x060001F4 RID: 500 RVA: 0x00007BCD File Offset: 0x00005DCD
		// (set) Token: 0x060001F5 RID: 501 RVA: 0x00007BD5 File Offset: 0x00005DD5
		private float JitterMagnitude { get; set; } = 1f;

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x060001F6 RID: 502 RVA: 0x00007BDE File Offset: 0x00005DDE
		// (set) Token: 0x060001F7 RID: 503 RVA: 0x00007BE6 File Offset: 0x00005DE6
		private float DelayScale { get; set; } = 1f;

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x060001F8 RID: 504 RVA: 0x00007BEF File Offset: 0x00005DEF
		// (set) Token: 0x060001F9 RID: 505 RVA: 0x00007BF7 File Offset: 0x00005DF7
		private float MaxDelayTime { get; set; } = 8f;

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x060001FA RID: 506 RVA: 0x00007C00 File Offset: 0x00005E00
		// (set) Token: 0x060001FB RID: 507 RVA: 0x00007C08 File Offset: 0x00005E08
		private Func<int, T> CreateOperation { get; set; }

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x060001FC RID: 508 RVA: 0x00007C11 File Offset: 0x00005E11
		// (set) Token: 0x060001FD RID: 509 RVA: 0x00007C19 File Offset: 0x00005E19
		private Func<T, bool> RetryCondition { get; set; }

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x060001FE RID: 510 RVA: 0x00007C22 File Offset: 0x00005E22
		// (set) Token: 0x060001FF RID: 511 RVA: 0x00007C2A File Offset: 0x00005E2A
		private Action<T> OnComplete { get; set; }

		// Token: 0x06000200 RID: 512 RVA: 0x00007C33 File Offset: 0x00005E33
		private AsyncOpRetry(Func<int, T> createAsyncOp)
		{
			this.CreateOperation = createAsyncOp;
		}

		// Token: 0x06000201 RID: 513 RVA: 0x00007C6A File Offset: 0x00005E6A
		private static float AddJitter(float number, float magnitude)
		{
			return number + Random.value * magnitude;
		}

		// Token: 0x06000202 RID: 514 RVA: 0x00007C75 File Offset: 0x00005E75
		private static float Pow2(float exponent, float scale)
		{
			return (float)(Math.Pow(2.0, (double)exponent) * (double)scale);
		}

		// Token: 0x06000203 RID: 515 RVA: 0x00007C8B File Offset: 0x00005E8B
		private static float CalculateDelay(int attemptNumber, float maxDelayTime, float delayScale, float jitterMagnitude)
		{
			return Math.Min(AsyncOpRetry<T>.AddJitter(AsyncOpRetry<T>.Pow2((float)attemptNumber, delayScale), jitterMagnitude), maxDelayTime);
		}

		// Token: 0x06000204 RID: 516 RVA: 0x00007CA1 File Offset: 0x00005EA1
		public static AsyncOpRetry<T> FromCreateAsync(Func<int, T> op)
		{
			return new AsyncOpRetry<T>(op);
		}

		// Token: 0x06000205 RID: 517 RVA: 0x00007CA9 File Offset: 0x00005EA9
		public AsyncOpRetry<T> WithRetryCondition(Func<T, bool> shouldRetry)
		{
			this.RetryCondition = shouldRetry;
			return this;
		}

		// Token: 0x06000206 RID: 518 RVA: 0x00007CB3 File Offset: 0x00005EB3
		public AsyncOpRetry<T> WhenComplete(Action<T> onComplete)
		{
			this.OnComplete = onComplete;
			return this;
		}

		// Token: 0x06000207 RID: 519 RVA: 0x00007CBD File Offset: 0x00005EBD
		public IEnumerator Run()
		{
			T asyncOp = default(T);
			int attempt = 0;
			while ((long)attempt <= (long)((ulong)this.MaxRetries))
			{
				asyncOp = this.CreateOperation(attempt + 1);
				yield return asyncOp;
				Func<T, bool> retryCondition = this.RetryCondition;
				if (retryCondition != null && !retryCondition(asyncOp))
				{
					break;
				}
				float time = AsyncOpRetry<T>.CalculateDelay(attempt, this.MaxDelayTime, this.DelayScale, this.JitterMagnitude);
				yield return new WaitForSecondsRealtime(time);
				int num = attempt + 1;
				attempt = num;
			}
			Action<T> onComplete = this.OnComplete;
			if (onComplete != null)
			{
				onComplete(asyncOp);
			}
			yield break;
		}
	}
}
