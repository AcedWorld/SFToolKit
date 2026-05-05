using System;
using System.Diagnostics;

namespace Unity.Multiplayer.Tools.NetStats
{
	// Token: 0x02000025 RID: 37
	[Serializable]
	internal class Timer : Metric<TimeSpan>
	{
		// Token: 0x0600009F RID: 159 RVA: 0x00003276 File Offset: 0x00001476
		public Timer(MetricId metricId, TimeSpan defaultValue = default(TimeSpan)) : base(metricId, defaultValue)
		{
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00003280 File Offset: 0x00001480
		public void Set(TimeSpan value)
		{
			base.Value = value;
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00003289 File Offset: 0x00001489
		public Timer.TimerScope Time()
		{
			return new Timer.TimerScope(new Action<TimeSpan>(this.Set));
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x060000A2 RID: 162 RVA: 0x0000329C File Offset: 0x0000149C
		public override MetricContainerType MetricContainerType
		{
			get
			{
				return MetricContainerType.Timer;
			}
		}

		// Token: 0x02000043 RID: 67
		public readonly struct TimerScope : IDisposable
		{
			// Token: 0x0600016E RID: 366 RVA: 0x00005462 File Offset: 0x00003662
			internal TimerScope(Action<TimeSpan> callback)
			{
				this.m_Callback = callback;
				this.m_Stopwatch = new Stopwatch();
				this.m_Stopwatch.Start();
			}

			// Token: 0x0600016F RID: 367 RVA: 0x00005481 File Offset: 0x00003681
			public void Dispose()
			{
				Action<TimeSpan> callback = this.m_Callback;
				if (callback == null)
				{
					return;
				}
				callback(this.m_Stopwatch.Elapsed);
			}

			// Token: 0x0400008A RID: 138
			private readonly Action<TimeSpan> m_Callback;

			// Token: 0x0400008B RID: 139
			private readonly Stopwatch m_Stopwatch;
		}
	}
}
