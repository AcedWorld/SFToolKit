using System;
using System.Collections;
using UnityEngine;

namespace Unity.Services.Qos.V2.Helpers
{
	// Token: 0x0200003D RID: 61
	internal class AsyncOpRetry<T>
	{
		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060000FA RID: 250 RVA: 0x000055F0 File Offset: 0x000037F0
		// (set) Token: 0x060000FB RID: 251 RVA: 0x000055F8 File Offset: 0x000037F8
		private uint MaxRetries { get; set; } = 4U;

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060000FC RID: 252 RVA: 0x00005601 File Offset: 0x00003801
		// (set) Token: 0x060000FD RID: 253 RVA: 0x00005609 File Offset: 0x00003809
		private float JitterMagnitude { get; set; } = 1f;

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060000FE RID: 254 RVA: 0x00005612 File Offset: 0x00003812
		// (set) Token: 0x060000FF RID: 255 RVA: 0x0000561A File Offset: 0x0000381A
		private float DelayScale { get; set; } = 1f;

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x06000100 RID: 256 RVA: 0x00005623 File Offset: 0x00003823
		// (set) Token: 0x06000101 RID: 257 RVA: 0x0000562B File Offset: 0x0000382B
		private float MaxDelayTime { get; set; } = 8f;

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x06000102 RID: 258 RVA: 0x00005634 File Offset: 0x00003834
		// (set) Token: 0x06000103 RID: 259 RVA: 0x0000563C File Offset: 0x0000383C
		private Func<int, T> CreateOperation { get; set; }

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x06000104 RID: 260 RVA: 0x00005645 File Offset: 0x00003845
		// (set) Token: 0x06000105 RID: 261 RVA: 0x0000564D File Offset: 0x0000384D
		private Func<T, bool> RetryCondition { get; set; }

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x06000106 RID: 262 RVA: 0x00005656 File Offset: 0x00003856
		// (set) Token: 0x06000107 RID: 263 RVA: 0x0000565E File Offset: 0x0000385E
		private Action<T> OnComplete { get; set; }

		// Token: 0x06000108 RID: 264 RVA: 0x00005667 File Offset: 0x00003867
		private AsyncOpRetry(Func<int, T> createAsyncOp)
		{
			this.CreateOperation = createAsyncOp;
		}

		// Token: 0x06000109 RID: 265 RVA: 0x0000569E File Offset: 0x0000389E
		private static float AddJitter(float number, float magnitude)
		{
			return number + Random.value * magnitude;
		}

		// Token: 0x0600010A RID: 266 RVA: 0x000056A9 File Offset: 0x000038A9
		private static float Pow2(float exponent, float scale)
		{
			return (float)(Math.Pow(2.0, (double)exponent) * (double)scale);
		}

		// Token: 0x0600010B RID: 267 RVA: 0x000056BF File Offset: 0x000038BF
		private static float CalculateDelay(int attemptNumber, float maxDelayTime, float delayScale, float jitterMagnitude)
		{
			return Math.Min(AsyncOpRetry<T>.AddJitter(AsyncOpRetry<T>.Pow2((float)attemptNumber, delayScale), jitterMagnitude), maxDelayTime);
		}

		// Token: 0x0600010C RID: 268 RVA: 0x000056D5 File Offset: 0x000038D5
		public static AsyncOpRetry<T> FromCreateAsync(Func<int, T> op)
		{
			return new AsyncOpRetry<T>(op);
		}

		// Token: 0x0600010D RID: 269 RVA: 0x000056DD File Offset: 0x000038DD
		public AsyncOpRetry<T> WithRetryCondition(Func<T, bool> shouldRetry)
		{
			this.RetryCondition = shouldRetry;
			return this;
		}

		// Token: 0x0600010E RID: 270 RVA: 0x000056E7 File Offset: 0x000038E7
		public AsyncOpRetry<T> WhenComplete(Action<T> onComplete)
		{
			this.OnComplete = onComplete;
			return this;
		}

		// Token: 0x0600010F RID: 271 RVA: 0x000056F1 File Offset: 0x000038F1
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
