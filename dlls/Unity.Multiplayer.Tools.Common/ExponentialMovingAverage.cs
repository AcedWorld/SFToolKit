using System;

namespace Unity.Multiplayer.Tools.Common
{
	// Token: 0x02000014 RID: 20
	internal class ExponentialMovingAverage
	{
		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600003E RID: 62 RVA: 0x000025BE File Offset: 0x000007BE
		// (set) Token: 0x0600003F RID: 63 RVA: 0x000025C6 File Offset: 0x000007C6
		public float Parameter { get; private set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000040 RID: 64 RVA: 0x000025CF File Offset: 0x000007CF
		// (set) Token: 0x06000041 RID: 65 RVA: 0x000025D7 File Offset: 0x000007D7
		public float Value { get; private set; }

		// Token: 0x06000042 RID: 66 RVA: 0x000025E0 File Offset: 0x000007E0
		public static ExponentialMovingAverage ApproximatingSimpleMovingAverage(int sampleCount)
		{
			return new ExponentialMovingAverage(ExponentialMovingAverage.GetParameterApproximatingSimpleMovingAverage(sampleCount), 0f);
		}

		// Token: 0x06000043 RID: 67 RVA: 0x000025F2 File Offset: 0x000007F2
		public static float GetParameterApproximatingSimpleMovingAverage(int sampleCount)
		{
			return 2f / (float)(sampleCount + 1);
		}

		// Token: 0x06000044 RID: 68 RVA: 0x000025FE File Offset: 0x000007FE
		public ExponentialMovingAverage(float parameter, float value = 0f)
		{
			if (0f > parameter || parameter > 1f)
			{
				throw new ArgumentException(string.Format("ExponentialMovingAverage parameter {0} should be in range [0, 1]", parameter));
			}
			this.Parameter = parameter;
			this.Value = value;
		}

		// Token: 0x06000045 RID: 69 RVA: 0x0000263A File Offset: 0x0000083A
		public void ClearValue()
		{
			this.Value = 0f;
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00002647 File Offset: 0x00000847
		public void ClearValueAndParameter()
		{
			this.Parameter = 0f;
			this.Value = 0f;
		}

		// Token: 0x06000047 RID: 71 RVA: 0x0000265F File Offset: 0x0000085F
		public void AddSample(float x)
		{
			this.Value = this.Parameter * x + (1f - this.Parameter) * this.Value;
		}
	}
}
