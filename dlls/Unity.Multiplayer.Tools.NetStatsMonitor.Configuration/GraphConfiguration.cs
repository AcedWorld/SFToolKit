using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.Multiplayer.Tools.NetStatsMonitor
{
	// Token: 0x0200000B RID: 11
	[Serializable]
	public sealed class GraphConfiguration
	{
		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000039 RID: 57 RVA: 0x00002830 File Offset: 0x00000A30
		// (set) Token: 0x0600003A RID: 58 RVA: 0x00002838 File Offset: 0x00000A38
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

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600003B RID: 59 RVA: 0x0000284C File Offset: 0x00000A4C
		// (set) Token: 0x0600003C RID: 60 RVA: 0x00002854 File Offset: 0x00000A54
		[Tooltip("The sample rate of the graph. If the sample rate is Per Second then each point in the graph corresponds to data collected over a full second, whereas if the sample rate is Per Frame then each point in the graph corresponds to data collected within a single frame.")]
		public SampleRate SampleRate { get; set; } = SampleRate.PerSecond;

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600003D RID: 61 RVA: 0x0000285D File Offset: 0x00000A5D
		// (set) Token: 0x0600003E RID: 62 RVA: 0x00002865 File Offset: 0x00000A65
		public List<Color> VariableColors { get; set; } = new List<Color>();

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x0600003F RID: 63 RVA: 0x0000286E File Offset: 0x00000A6E
		// (set) Token: 0x06000040 RID: 64 RVA: 0x00002876 File Offset: 0x00000A76
		public GraphXAxisType XAxisType { get; set; }

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000041 RID: 65 RVA: 0x0000287F File Offset: 0x00000A7F
		// (set) Token: 0x06000042 RID: 66 RVA: 0x00002887 File Offset: 0x00000A87
		public LineGraphConfiguration LineGraphConfiguration { get; set; } = new LineGraphConfiguration();

		// Token: 0x06000043 RID: 67 RVA: 0x00002890 File Offset: 0x00000A90
		internal int ComputeHashCode()
		{
			int num = HashCode.Combine<int, int, int, int>(this.SampleCount, (int)this.SampleRate, (int)this.XAxisType, this.LineGraphConfiguration.ComputeHashCode());
			if (this.VariableColors != null)
			{
				foreach (Color value in this.VariableColors)
				{
					num = HashCode.Combine<int, Color>(num, value);
				}
			}
			return num;
		}

		// Token: 0x0400002B RID: 43
		[SerializeField]
		[Tooltip("The number of samples that are maintained for the purpose of graphing. The value is clamped to the range [8, 4096].")]
		[Range(8f, 4096f)]
		private int m_SampleCount = 256;
	}
}
