using System;
using UnityEngine;

namespace Unity.Multiplayer.Tools.NetStatsMonitor
{
	// Token: 0x02000007 RID: 7
	[Serializable]
	public sealed class SimpleMovingAverageParams
	{
		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000019 RID: 25 RVA: 0x00002236 File Offset: 0x00000436
		// (set) Token: 0x0600001A RID: 26 RVA: 0x0000223E File Offset: 0x0000043E
		public int SampleCount
		{
			get
			{
				return this.m_SampleCount;
			}
			set
			{
				this.m_SampleCount = Mathf.Clamp(value, 8, 4096);
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600001B RID: 27 RVA: 0x00002252 File Offset: 0x00000452
		// (set) Token: 0x0600001C RID: 28 RVA: 0x0000225A File Offset: 0x0000045A
		[Tooltip("The sample rate of the counter. If the sample rate is Per Second then each sample in the counter is collected over a full second, whereas if the sample rate is Per Frame then each sample in the counter is collected during a single frame.")]
		public SampleRate SampleRate { get; set; }

		// Token: 0x0600001D RID: 29 RVA: 0x00002263 File Offset: 0x00000463
		internal int ComputeHashCode()
		{
			return HashCode.Combine<int, SampleRate>(this.SampleCount, this.SampleRate);
		}

		// Token: 0x04000018 RID: 24
		[SerializeField]
		[Min(1f)]
		[Tooltip("The number of samples that are maintained for the purpose of smoothing.The value is clamped to the range [8, 4096].")]
		[Range(8f, 4096f)]
		private int m_SampleCount = 64;
	}
}
