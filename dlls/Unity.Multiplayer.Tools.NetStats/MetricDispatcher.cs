using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using UnityEngine;

namespace Unity.Multiplayer.Tools.NetStats
{
	// Token: 0x02000009 RID: 9
	internal class MetricDispatcher : IMetricDispatcher
	{
		// Token: 0x0600001C RID: 28 RVA: 0x00002472 File Offset: 0x00000672
		internal MetricDispatcher(MetricCollection collection, IReadOnlyList<IResettable> resettables, IReadOnlyList<IEventMetric> eventMetrics)
		{
			this.m_Collection = collection;
			this.m_Resettables = resettables;
			this.m_EventMetrics = eventMetrics;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x0000249A File Offset: 0x0000069A
		public void RegisterObserver(IMetricObserver observer)
		{
			this.m_Observers.Add(observer);
		}

		// Token: 0x0600001E RID: 30 RVA: 0x000024A8 File Offset: 0x000006A8
		public void SetConnectionId(ulong connectionId)
		{
			this.m_Collection.ConnectionId = connectionId;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x000024B8 File Offset: 0x000006B8
		public void Dispatch()
		{
			for (int i = 0; i < this.m_EventMetrics.Count; i++)
			{
				IEventMetric metric = this.m_EventMetrics[i];
				if (metric.WentOverLimit())
				{
					if (this.m_OverLimitMessageStringBuilder == null)
					{
						this.m_OverLimitMessageStringBuilder = new StringBuilder();
					}
					this.m_OverLimitMessageStringBuilder.AppendLine(metric.WentOverLimitMessage());
				}
			}
			StringBuilder overLimitMessageStringBuilder = this.m_OverLimitMessageStringBuilder;
			if (overLimitMessageStringBuilder != null && overLimitMessageStringBuilder.Length > 0)
			{
				Debug.LogWarning(this.m_OverLimitMessageStringBuilder);
				this.m_OverLimitMessageStringBuilder.Clear();
			}
			for (int j = 0; j < this.m_Observers.Count; j++)
			{
				this.m_Observers[j].Observe(this.m_Collection);
			}
			for (int k = 0; k < this.m_Resettables.Count; k++)
			{
				IResettable resettable = this.m_Resettables[k];
				if (resettable.ShouldResetOnDispatch)
				{
					resettable.Reset();
				}
			}
		}

		// Token: 0x0400000B RID: 11
		private readonly MetricCollection m_Collection;

		// Token: 0x0400000C RID: 12
		private readonly IReadOnlyList<IResettable> m_Resettables;

		// Token: 0x0400000D RID: 13
		private readonly IReadOnlyList<IEventMetric> m_EventMetrics;

		// Token: 0x0400000E RID: 14
		private readonly IList<IMetricObserver> m_Observers = new List<IMetricObserver>();

		// Token: 0x0400000F RID: 15
		[CanBeNull]
		private StringBuilder m_OverLimitMessageStringBuilder;
	}
}
