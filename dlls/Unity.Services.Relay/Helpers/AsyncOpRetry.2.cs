using System;
using System.Collections;
using UnityEngine;

namespace Unity.Services.Relay.Helpers
{
	// Token: 0x02000043 RID: 67
	internal class AsyncOpRetry<T>
	{
		// Token: 0x17000053 RID: 83
		// (get) Token: 0x06000114 RID: 276 RVA: 0x00004C5C File Offset: 0x00002E5C
		// (set) Token: 0x06000115 RID: 277 RVA: 0x00004C64 File Offset: 0x00002E64
		private uint MaxRetries { get; set; } = 4U;

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x06000116 RID: 278 RVA: 0x00004C6D File Offset: 0x00002E6D
		// (set) Token: 0x06000117 RID: 279 RVA: 0x00004C75 File Offset: 0x00002E75
		private float JitterMagnitude { get; set; } = 1f;

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x06000118 RID: 280 RVA: 0x00004C7E File Offset: 0x00002E7E
		// (set) Token: 0x06000119 RID: 281 RVA: 0x00004C86 File Offset: 0x00002E86
		private float DelayScale { get; set; } = 1f;

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x0600011A RID: 282 RVA: 0x00004C8F File Offset: 0x00002E8F
		// (set) Token: 0x0600011B RID: 283 RVA: 0x00004C97 File Offset: 0x00002E97
		private float MaxDelayTime { get; set; } = 8f;

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x0600011C RID: 284 RVA: 0x00004CA0 File Offset: 0x00002EA0
		// (set) Token: 0x0600011D RID: 285 RVA: 0x00004CA8 File Offset: 0x00002EA8
		private Func<int, T> CreateOperation { get; set; }

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x0600011E RID: 286 RVA: 0x00004CB1 File Offset: 0x00002EB1
		// (set) Token: 0x0600011F RID: 287 RVA: 0x00004CB9 File Offset: 0x00002EB9
		private Func<T, bool> RetryCondition { get; set; }

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x06000120 RID: 288 RVA: 0x00004CC2 File Offset: 0x00002EC2
		// (set) Token: 0x06000121 RID: 289 RVA: 0x00004CCA File Offset: 0x00002ECA
		private Action<T> OnComplete { get; set; }

		// Token: 0x06000122 RID: 290 RVA: 0x00004CD3 File Offset: 0x00002ED3
		private AsyncOpRetry(Func<int, T> createAsyncOp)
		{
			this.CreateOperation = createAsyncOp;
		}

		// Token: 0x06000123 RID: 291 RVA: 0x00004D0A File Offset: 0x00002F0A
		private static float AddJitter(float number, float magnitude)
		{
			return number + Random.value * magnitude;
		}

		// Token: 0x06000124 RID: 292 RVA: 0x00004D15 File Offset: 0x00002F15
		private static float Pow2(float exponent, float scale)
		{
			return (float)(Math.Pow(2.0, (double)exponent) * (double)scale);
		}

		// Token: 0x06000125 RID: 293 RVA: 0x00004D2B File Offset: 0x00002F2B
		private static float CalculateDelay(int attemptNumber, float maxDelayTime, float delayScale, float jitterMagnitude)
		{
			return Math.Min(AsyncOpRetry<T>.AddJitter(AsyncOpRetry<T>.Pow2((float)attemptNumber, delayScale), jitterMagnitude), maxDelayTime);
		}

		// Token: 0x06000126 RID: 294 RVA: 0x00004D41 File Offset: 0x00002F41
		public static AsyncOpRetry<T> FromCreateAsync(Func<int, T> op)
		{
			return new AsyncOpRetry<T>(op);
		}

		// Token: 0x06000127 RID: 295 RVA: 0x00004D49 File Offset: 0x00002F49
		public AsyncOpRetry<T> WithRetryCondition(Func<T, bool> shouldRetry)
		{
			this.RetryCondition = shouldRetry;
			return this;
		}

		// Token: 0x06000128 RID: 296 RVA: 0x00004D53 File Offset: 0x00002F53
		public AsyncOpRetry<T> WhenComplete(Action<T> onComplete)
		{
			this.OnComplete = onComplete;
			return this;
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00004D5D File Offset: 0x00002F5D
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
