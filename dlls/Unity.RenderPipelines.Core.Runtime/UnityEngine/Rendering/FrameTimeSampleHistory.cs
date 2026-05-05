using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace UnityEngine.Rendering
{
	// Token: 0x0200006E RID: 110
	internal class FrameTimeSampleHistory
	{
		// Token: 0x0600038B RID: 907 RVA: 0x0000FD78 File Offset: 0x0000DF78
		public FrameTimeSampleHistory(int initialCapacity)
		{
			this.m_Samples.Capacity = initialCapacity;
		}

		// Token: 0x0600038C RID: 908 RVA: 0x0000FD97 File Offset: 0x0000DF97
		internal void Add(FrameTimeSample sample)
		{
			this.m_Samples.Add(sample);
		}

		// Token: 0x0600038D RID: 909 RVA: 0x0000FDA8 File Offset: 0x0000DFA8
		internal void ComputeAggregateValues()
		{
			FrameTimeSample sampleAverage = default(FrameTimeSample);
			FrameTimeSample sampleMin = new FrameTimeSample(float.MaxValue);
			FrameTimeSample sampleMax = new FrameTimeSample(float.MinValue);
			FrameTimeSample sample = default(FrameTimeSample);
			for (int i = 0; i < this.m_Samples.Count; i++)
			{
				FrameTimeSample sample2 = this.m_Samples[i];
				FrameTimeSampleHistory.<ComputeAggregateValues>g__ForEachSampleMember|12_0(ref sampleMin, sample2, FrameTimeSampleHistory.s_SampleValueMin);
				FrameTimeSampleHistory.<ComputeAggregateValues>g__ForEachSampleMember|12_0(ref sampleMax, sample2, FrameTimeSampleHistory.s_SampleValueMax);
				FrameTimeSampleHistory.<ComputeAggregateValues>g__ForEachSampleMember|12_0(ref sampleAverage, sample2, FrameTimeSampleHistory.s_SampleValueAdd);
				FrameTimeSampleHistory.<ComputeAggregateValues>g__ForEachSampleMember|12_0(ref sample, sample2, FrameTimeSampleHistory.s_SampleValueCountValid);
			}
			FrameTimeSampleHistory.<ComputeAggregateValues>g__ForEachSampleMember|12_0(ref sampleMin, sample, FrameTimeSampleHistory.s_SampleValueEnsureValid);
			FrameTimeSampleHistory.<ComputeAggregateValues>g__ForEachSampleMember|12_0(ref sampleMax, sample, FrameTimeSampleHistory.s_SampleValueEnsureValid);
			FrameTimeSampleHistory.<ComputeAggregateValues>g__ForEachSampleMember|12_0(ref sampleAverage, sample, FrameTimeSampleHistory.s_SampleValueDivide);
			this.SampleAverage = sampleAverage;
			this.SampleMin = sampleMin;
			this.SampleMax = sampleMax;
		}

		// Token: 0x0600038E RID: 910 RVA: 0x0000FE7A File Offset: 0x0000E07A
		internal void DiscardOldSamples(int sampleHistorySize)
		{
			while (this.m_Samples.Count >= sampleHistorySize)
			{
				this.m_Samples.RemoveAt(0);
			}
			this.m_Samples.Capacity = sampleHistorySize;
		}

		// Token: 0x0600038F RID: 911 RVA: 0x0000FEA4 File Offset: 0x0000E0A4
		internal void Clear()
		{
			this.m_Samples.Clear();
		}

		// Token: 0x06000391 RID: 913 RVA: 0x0000FF40 File Offset: 0x0000E140
		[CompilerGenerated]
		internal static void <ComputeAggregateValues>g__ForEachSampleMember|12_0(ref FrameTimeSample aggregate, FrameTimeSample sample, Func<float, float, float> func)
		{
			aggregate.FramesPerSecond = func(aggregate.FramesPerSecond, sample.FramesPerSecond);
			aggregate.FullFrameTime = func(aggregate.FullFrameTime, sample.FullFrameTime);
			aggregate.MainThreadCPUFrameTime = func(aggregate.MainThreadCPUFrameTime, sample.MainThreadCPUFrameTime);
			aggregate.MainThreadCPUPresentWaitTime = func(aggregate.MainThreadCPUPresentWaitTime, sample.MainThreadCPUPresentWaitTime);
			aggregate.RenderThreadCPUFrameTime = func(aggregate.RenderThreadCPUFrameTime, sample.RenderThreadCPUFrameTime);
			aggregate.GPUFrameTime = func(aggregate.GPUFrameTime, sample.GPUFrameTime);
		}

		// Token: 0x0400020B RID: 523
		private List<FrameTimeSample> m_Samples = new List<FrameTimeSample>();

		// Token: 0x0400020C RID: 524
		internal FrameTimeSample SampleAverage;

		// Token: 0x0400020D RID: 525
		internal FrameTimeSample SampleMin;

		// Token: 0x0400020E RID: 526
		internal FrameTimeSample SampleMax;

		// Token: 0x0400020F RID: 527
		private static Func<float, float, float> s_SampleValueAdd = (float value, float other) => value + other;

		// Token: 0x04000210 RID: 528
		private static Func<float, float, float> s_SampleValueMin = delegate(float value, float other)
		{
			if (other <= 0f)
			{
				return value;
			}
			return Mathf.Min(value, other);
		};

		// Token: 0x04000211 RID: 529
		private static Func<float, float, float> s_SampleValueMax = (float value, float other) => Mathf.Max(value, other);

		// Token: 0x04000212 RID: 530
		private static Func<float, float, float> s_SampleValueCountValid = delegate(float value, float other)
		{
			if (other <= 0f)
			{
				return value;
			}
			return value + 1f;
		};

		// Token: 0x04000213 RID: 531
		private static Func<float, float, float> s_SampleValueEnsureValid = delegate(float value, float other)
		{
			if (other <= 0f)
			{
				return 0f;
			}
			return value;
		};

		// Token: 0x04000214 RID: 532
		private static Func<float, float, float> s_SampleValueDivide = delegate(float value, float other)
		{
			if (other <= 0f)
			{
				return 0f;
			}
			return value / other;
		};
	}
}
