using System;
using System.Collections.Generic;

namespace UnityEngine.Rendering
{
	// Token: 0x0200006C RID: 108
	internal class BottleneckHistory
	{
		// Token: 0x06000384 RID: 900 RVA: 0x0000FB32 File Offset: 0x0000DD32
		public BottleneckHistory(int initialCapacity)
		{
			this.m_Bottlenecks.Capacity = initialCapacity;
		}

		// Token: 0x06000385 RID: 901 RVA: 0x0000FB51 File Offset: 0x0000DD51
		internal void DiscardOldSamples(int historySize)
		{
			while (this.m_Bottlenecks.Count >= historySize)
			{
				this.m_Bottlenecks.RemoveAt(0);
			}
			this.m_Bottlenecks.Capacity = historySize;
		}

		// Token: 0x06000386 RID: 902 RVA: 0x0000FB7C File Offset: 0x0000DD7C
		internal void AddBottleneckFromAveragedSample(FrameTimeSample frameHistorySampleAverage)
		{
			PerformanceBottleneck item = BottleneckHistory.DetermineBottleneck(frameHistorySampleAverage);
			this.m_Bottlenecks.Add(item);
		}

		// Token: 0x06000387 RID: 903 RVA: 0x0000FB9C File Offset: 0x0000DD9C
		internal void ComputeHistogram()
		{
			BottleneckHistogram histogram = default(BottleneckHistogram);
			for (int i = 0; i < this.m_Bottlenecks.Count; i++)
			{
				switch (this.m_Bottlenecks[i])
				{
				case PerformanceBottleneck.PresentLimited:
					histogram.PresentLimited += 1f;
					break;
				case PerformanceBottleneck.CPU:
					histogram.CPU += 1f;
					break;
				case PerformanceBottleneck.GPU:
					histogram.GPU += 1f;
					break;
				case PerformanceBottleneck.Balanced:
					histogram.Balanced += 1f;
					break;
				}
			}
			histogram.Balanced /= (float)this.m_Bottlenecks.Count;
			histogram.CPU /= (float)this.m_Bottlenecks.Count;
			histogram.GPU /= (float)this.m_Bottlenecks.Count;
			histogram.PresentLimited /= (float)this.m_Bottlenecks.Count;
			this.Histogram = histogram;
		}

		// Token: 0x06000388 RID: 904 RVA: 0x0000FC98 File Offset: 0x0000DE98
		private static PerformanceBottleneck DetermineBottleneck(FrameTimeSample s)
		{
			if (s.GPUFrameTime == 0f || s.MainThreadCPUFrameTime == 0f)
			{
				return PerformanceBottleneck.Indeterminate;
			}
			float num = 0.8f * s.FullFrameTime;
			if (s.GPUFrameTime > num && s.MainThreadCPUFrameTime < num && s.RenderThreadCPUFrameTime < num)
			{
				return PerformanceBottleneck.GPU;
			}
			if (s.GPUFrameTime < num && (s.MainThreadCPUFrameTime > num || s.RenderThreadCPUFrameTime > num))
			{
				return PerformanceBottleneck.CPU;
			}
			if (s.MainThreadCPUPresentWaitTime > 0.5f && s.GPUFrameTime < num && s.MainThreadCPUFrameTime < num && s.RenderThreadCPUFrameTime < num)
			{
				return PerformanceBottleneck.PresentLimited;
			}
			return PerformanceBottleneck.Balanced;
		}

		// Token: 0x06000389 RID: 905 RVA: 0x0000FD33 File Offset: 0x0000DF33
		internal void Clear()
		{
			this.m_Bottlenecks.Clear();
			this.Histogram = default(BottleneckHistogram);
		}

		// Token: 0x04000203 RID: 515
		private List<PerformanceBottleneck> m_Bottlenecks = new List<PerformanceBottleneck>();

		// Token: 0x04000204 RID: 516
		internal BottleneckHistogram Histogram;
	}
}
