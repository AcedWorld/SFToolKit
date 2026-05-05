using System;

namespace Unity.Multiplayer.Tools.Common
{
	// Token: 0x0200000D RID: 13
	internal class ContinuousExponentialMovingAverage
	{
		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600001B RID: 27 RVA: 0x000021DC File Offset: 0x000003DC
		// (set) Token: 0x0600001C RID: 28 RVA: 0x000021E4 File Offset: 0x000003E4
		public double DecayConstant { get; private set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600001D RID: 29 RVA: 0x000021ED File Offset: 0x000003ED
		// (set) Token: 0x0600001E RID: 30 RVA: 0x000021F5 File Offset: 0x000003F5
		public double LastValue { get; private set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600001F RID: 31 RVA: 0x000021FE File Offset: 0x000003FE
		// (set) Token: 0x06000020 RID: 32 RVA: 0x00002206 File Offset: 0x00000406
		public double LastTime { get; private set; }

		// Token: 0x06000021 RID: 33 RVA: 0x0000220F File Offset: 0x0000040F
		public static ContinuousExponentialMovingAverage CreateWithHalfLife(double halfLife)
		{
			return new ContinuousExponentialMovingAverage(ContinuousExponentialMovingAverage.GetDecayConstantForHalfLife(halfLife), 0.0, double.NegativeInfinity);
		}

		// Token: 0x06000022 RID: 34 RVA: 0x0000222E File Offset: 0x0000042E
		public static double GetDecayConstantForHalfLife(double halfLife)
		{
			return ContinuousExponentialMovingAverage.k_ln2 / halfLife;
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002238 File Offset: 0x00000438
		public ContinuousExponentialMovingAverage(double decayConstant, double value = 0.0, double time = double.NegativeInfinity)
		{
			if (decayConstant < 0.0)
			{
				throw new ArgumentException(string.Format("ContinuousExponentialMovingAverage decay constant {0} should be >= 0; ", decayConstant) + "otherwise it will grow exponentially over time.");
			}
			this.DecayConstant = decayConstant;
			this.LastValue = value;
			this.LastTime = time;
		}

		// Token: 0x06000024 RID: 36 RVA: 0x0000228C File Offset: 0x0000048C
		public void Reset()
		{
			this.DecayConstant = 0.0;
			this.LastValue = 0.0;
			this.LastTime = double.NegativeInfinity;
		}

		// Token: 0x06000025 RID: 37 RVA: 0x000022BB File Offset: 0x000004BB
		public void ClearValueAndTime()
		{
			this.LastValue = 0.0;
			this.LastTime = double.NegativeInfinity;
		}

		// Token: 0x06000026 RID: 38 RVA: 0x000022DC File Offset: 0x000004DC
		public void AddSampleForGauge(double sample, double time)
		{
			double num = Math.Exp(-(time - this.LastTime) * this.DecayConstant);
			double num2 = 1.0 - num;
			this.LastValue += num2 * (sample - this.LastValue);
			this.LastTime = time;
		}

		// Token: 0x06000027 RID: 39 RVA: 0x0000232C File Offset: 0x0000052C
		public void AddSampleForCounter(double sample, double time)
		{
			double num = time - this.LastTime;
			double num2 = sample / num;
			double num3 = Math.Exp(-num * this.DecayConstant);
			double num4 = 1.0 - num3;
			this.LastValue += num4 * (num2 - this.LastValue);
			this.LastTime = time;
		}

		// Token: 0x06000028 RID: 40 RVA: 0x0000237F File Offset: 0x0000057F
		public double GetGaugeValue()
		{
			return this.LastValue;
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00002388 File Offset: 0x00000588
		public double GetCounterValue(double time)
		{
			double num = Math.Exp(-(time - this.LastTime) * this.DecayConstant);
			return this.LastValue * num;
		}

		// Token: 0x0400000A RID: 10
		private const double k_DefaultInitialTime = double.NegativeInfinity;

		// Token: 0x0400000B RID: 11
		public static readonly double k_ln2 = Math.Log(2.0);
	}
}
