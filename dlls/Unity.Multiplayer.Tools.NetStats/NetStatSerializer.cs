using System;
using System.Collections.Generic;
using Unity.Collections;

namespace Unity.Multiplayer.Tools.NetStats
{
	// Token: 0x02000034 RID: 52
	internal class NetStatSerializer : INetStatSerializer
	{
		// Token: 0x0600014A RID: 330 RVA: 0x00004DC8 File Offset: 0x00002FC8
		public NativeArray<byte> Serialize(MetricCollection metricCollection)
		{
			int num = 0;
			for (int i = 0; i < metricCollection.Metrics.Count; i++)
			{
				IMetric metric = metricCollection.Metrics[i];
				num += FastBufferWriter.GetWriteSize<MetricHeader>();
				num += metric.GetWriteSize();
			}
			num += FastBufferWriter.GetWriteSize<ulong>();
			NativeArray<byte> result;
			using (FastBufferWriter writer = new FastBufferWriter(num, Allocator.Temp, int.MaxValue))
			{
				ulong connectionId = metricCollection.ConnectionId;
				writer.WriteValueSafe<ulong>(connectionId);
				int count = metricCollection.Metrics.Count;
				writer.WriteValueSafe<int>(count);
				for (int j = 0; j < metricCollection.Metrics.Count; j++)
				{
					IMetric metric2 = metricCollection.Metrics[j];
					MetricHeader metricHeader = new MetricHeader(metric2.FactoryTypeName, metric2.MetricContainerType, metric2.Id);
					writer.WriteValueSafe<MetricHeader>(metricHeader);
					writer.TryBeginWrite(metric2.GetWriteSize());
					metric2.Write(writer);
				}
				result = writer.ToNativeArray(Allocator.Temp);
			}
			return result;
		}

		// Token: 0x0600014B RID: 331 RVA: 0x00004EDC File Offset: 0x000030DC
		public MetricCollection Deserialize(NativeArray<byte> bytes)
		{
			List<IMetric> list = new List<IMetric>();
			ulong localConnectionId;
			using (FastBufferReader reader = new FastBufferReader(bytes, Allocator.Temp, -1, 0))
			{
				reader.ReadValueSafe<ulong>(out localConnectionId);
				int num;
				reader.ReadValueSafe<int>(out num);
				for (int i = 0; i < num; i++)
				{
					MetricHeader metricHeader;
					reader.ReadValueSafe<MetricHeader>(out metricHeader);
					IMetric metric;
					if (!this.m_MetricFactory.TryConstruct(metricHeader, out metric))
					{
						throw new InvalidOperationException(string.Format("Failed to construct metric from serialized data. Metric Header: {0}", metricHeader));
					}
					metric.Read(reader);
					list.Add(metric);
				}
			}
			return new MetricCollection(list, localConnectionId);
		}

		// Token: 0x04000059 RID: 89
		private MetricFactory m_MetricFactory = new MetricFactory();
	}
}
