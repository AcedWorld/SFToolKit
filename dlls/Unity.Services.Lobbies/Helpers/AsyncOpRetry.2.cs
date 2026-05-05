using System;
using System.Collections;
using UnityEngine;

namespace Unity.Services.Lobbies.Helpers
{
	// Token: 0x0200005D RID: 93
	internal class AsyncOpRetry<T>
	{
		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x0600025F RID: 607 RVA: 0x000092F5 File Offset: 0x000074F5
		// (set) Token: 0x06000260 RID: 608 RVA: 0x000092FD File Offset: 0x000074FD
		private uint MaxRetries { get; set; } = 4U;

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x06000261 RID: 609 RVA: 0x00009306 File Offset: 0x00007506
		// (set) Token: 0x06000262 RID: 610 RVA: 0x0000930E File Offset: 0x0000750E
		private float JitterMagnitude { get; set; } = 1f;

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x06000263 RID: 611 RVA: 0x00009317 File Offset: 0x00007517
		// (set) Token: 0x06000264 RID: 612 RVA: 0x0000931F File Offset: 0x0000751F
		private float DelayScale { get; set; } = 1f;

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x06000265 RID: 613 RVA: 0x00009328 File Offset: 0x00007528
		// (set) Token: 0x06000266 RID: 614 RVA: 0x00009330 File Offset: 0x00007530
		private float MaxDelayTime { get; set; } = 8f;

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x06000267 RID: 615 RVA: 0x00009339 File Offset: 0x00007539
		// (set) Token: 0x06000268 RID: 616 RVA: 0x00009341 File Offset: 0x00007541
		private Func<int, T> CreateOperation { get; set; }

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x06000269 RID: 617 RVA: 0x0000934A File Offset: 0x0000754A
		// (set) Token: 0x0600026A RID: 618 RVA: 0x00009352 File Offset: 0x00007552
		private Func<T, bool> RetryCondition { get; set; }

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x0600026B RID: 619 RVA: 0x0000935B File Offset: 0x0000755B
		// (set) Token: 0x0600026C RID: 620 RVA: 0x00009363 File Offset: 0x00007563
		private Action<T> OnComplete { get; set; }

		// Token: 0x0600026D RID: 621 RVA: 0x0000936C File Offset: 0x0000756C
		private AsyncOpRetry(Func<int, T> createAsyncOp)
		{
			this.CreateOperation = createAsyncOp;
		}

		// Token: 0x0600026E RID: 622 RVA: 0x000093A3 File Offset: 0x000075A3
		private static float AddJitter(float number, float magnitude)
		{
			return number + Random.value * magnitude;
		}

		// Token: 0x0600026F RID: 623 RVA: 0x000093AE File Offset: 0x000075AE
		private static float Pow2(float exponent, float scale)
		{
			return (float)(Math.Pow(2.0, (double)exponent) * (double)scale);
		}

		// Token: 0x06000270 RID: 624 RVA: 0x000093C4 File Offset: 0x000075C4
		private static float CalculateDelay(int attemptNumber, float maxDelayTime, float delayScale, float jitterMagnitude)
		{
			return Math.Min(AsyncOpRetry<T>.AddJitter(AsyncOpRetry<T>.Pow2((float)attemptNumber, delayScale), jitterMagnitude), maxDelayTime);
		}

		// Token: 0x06000271 RID: 625 RVA: 0x000093DA File Offset: 0x000075DA
		public static AsyncOpRetry<T> FromCreateAsync(Func<int, T> op)
		{
			return new AsyncOpRetry<T>(op);
		}

		// Token: 0x06000272 RID: 626 RVA: 0x000093E2 File Offset: 0x000075E2
		public AsyncOpRetry<T> WithRetryCondition(Func<T, bool> shouldRetry)
		{
			this.RetryCondition = shouldRetry;
			return this;
		}

		// Token: 0x06000273 RID: 627 RVA: 0x000093EC File Offset: 0x000075EC
		public AsyncOpRetry<T> WhenComplete(Action<T> onComplete)
		{
			this.OnComplete = onComplete;
			return this;
		}

		// Token: 0x06000274 RID: 628 RVA: 0x000093F6 File Offset: 0x000075F6
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
