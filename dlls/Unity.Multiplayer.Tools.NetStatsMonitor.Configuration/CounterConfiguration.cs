using System;
using UnityEngine;

namespace Unity.Multiplayer.Tools.NetStatsMonitor
{
	// Token: 0x02000005 RID: 5
	[Serializable]
	public sealed class CounterConfiguration
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000003 RID: 3 RVA: 0x000020C0 File Offset: 0x000002C0
		// (set) Token: 0x06000004 RID: 4 RVA: 0x000020C8 File Offset: 0x000002C8
		public SmoothingMethod SmoothingMethod { get; set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000005 RID: 5 RVA: 0x000020D1 File Offset: 0x000002D1
		// (set) Token: 0x06000006 RID: 6 RVA: 0x000020D9 File Offset: 0x000002D9
		public AggregationMethod AggregationMethod { get; set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000007 RID: 7 RVA: 0x000020E2 File Offset: 0x000002E2
		// (set) Token: 0x06000008 RID: 8 RVA: 0x000020EA File Offset: 0x000002EA
		public int SignificantDigits
		{
			get
			{
				return this.m_SignificantDigits;
			}
			set
			{
				this.m_SignificantDigits = Mathf.Clamp(value, 1, 7);
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000009 RID: 9 RVA: 0x000020FA File Offset: 0x000002FA
		// (set) Token: 0x0600000A RID: 10 RVA: 0x00002102 File Offset: 0x00000302
		public float HighlightLowerBound { get; set; } = float.NegativeInfinity;

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000B RID: 11 RVA: 0x0000210B File Offset: 0x0000030B
		// (set) Token: 0x0600000C RID: 12 RVA: 0x00002113 File Offset: 0x00000313
		public float HighlightUpperBound { get; set; } = float.PositiveInfinity;

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600000D RID: 13 RVA: 0x0000211C File Offset: 0x0000031C
		// (set) Token: 0x0600000E RID: 14 RVA: 0x00002124 File Offset: 0x00000324
		public ExponentialMovingAverageParams ExponentialMovingAverageParams { get; set; } = new ExponentialMovingAverageParams();

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600000F RID: 15 RVA: 0x0000212D File Offset: 0x0000032D
		// (set) Token: 0x06000010 RID: 16 RVA: 0x00002135 File Offset: 0x00000335
		public SimpleMovingAverageParams SimpleMovingAverageParams { get; set; } = new SimpleMovingAverageParams();

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000011 RID: 17 RVA: 0x0000213E File Offset: 0x0000033E
		public int SampleCount
		{
			get
			{
				if (this.SmoothingMethod != SmoothingMethod.SimpleMovingAverage)
				{
					return 0;
				}
				return this.SimpleMovingAverageParams.SampleCount;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000012 RID: 18 RVA: 0x00002156 File Offset: 0x00000356
		internal SampleRate SampleRate
		{
			get
			{
				if (this.SmoothingMethod != SmoothingMethod.SimpleMovingAverage)
				{
					return SampleRate.PerFrame;
				}
				return this.SimpleMovingAverageParams.SampleRate;
			}
		}

		// Token: 0x06000013 RID: 19 RVA: 0x0000216E File Offset: 0x0000036E
		internal int ComputeHashCode()
		{
			return HashCode.Combine<int, int, int, float, float, int, int>((int)this.SmoothingMethod, (int)this.AggregationMethod, this.SignificantDigits, this.HighlightLowerBound, this.HighlightUpperBound, this.ExponentialMovingAverageParams.ComputeHashCode(), this.SimpleMovingAverageParams.ComputeHashCode());
		}

		// Token: 0x04000012 RID: 18
		[SerializeField]
		[Range(1f, 7f)]
		[Tooltip("The number of significant digits to display for this counter.")]
		private int m_SignificantDigits = 3;
	}
}
