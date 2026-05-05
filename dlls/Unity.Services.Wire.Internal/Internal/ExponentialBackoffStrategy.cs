using System;

namespace Unity.Services.Wire.Internal
{
	// Token: 0x0200002A RID: 42
	internal class ExponentialBackoffStrategy : IBackoffStrategy
	{
		// Token: 0x060000A7 RID: 167 RVA: 0x00003B3F File Offset: 0x00001D3F
		public ExponentialBackoffStrategy()
		{
			this.m_Attempt = 0;
			this.m_Factor = 2f;
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00003B5C File Offset: 0x00001D5C
		private float GetDuration(int attempt)
		{
			float num = 0.1f * (float)Math.Pow((double)this.m_Factor, (double)attempt);
			if (num < 0.1f)
			{
				return 0.1f;
			}
			if (num <= 30f)
			{
				return num;
			}
			return 30f;
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00003B9C File Offset: 0x00001D9C
		public float GetNext()
		{
			float duration = this.GetDuration(this.m_Attempt);
			this.m_Attempt++;
			return duration;
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00003BB8 File Offset: 0x00001DB8
		public void Reset()
		{
			this.m_Attempt = 0;
		}

		// Token: 0x04000092 RID: 146
		private int m_Attempt;

		// Token: 0x04000093 RID: 147
		private float m_Factor;

		// Token: 0x04000094 RID: 148
		private const float k_Max = 30f;

		// Token: 0x04000095 RID: 149
		private const float k_Min = 0.1f;
	}
}
