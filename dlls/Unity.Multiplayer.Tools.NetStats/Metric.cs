using System;
using System.Runtime.CompilerServices;
using Unity.Collections;

namespace Unity.Multiplayer.Tools.NetStats
{
	// Token: 0x02000018 RID: 24
	[Serializable]
	internal abstract class Metric<[IsUnmanaged] TValue> : IMetric<TValue>, IMetric, IResettable where TValue : struct, ValueType
	{
		// Token: 0x06000059 RID: 89 RVA: 0x00002AE7 File Offset: 0x00000CE7
		protected Metric(MetricId metricId, TValue defaultValue = default(TValue))
		{
			this.Id = metricId;
			this.DefaultValue = defaultValue;
			this.Value = defaultValue;
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600005A RID: 90 RVA: 0x00002B0C File Offset: 0x00000D0C
		public string Name
		{
			get
			{
				return this.Id.ToString();
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600005B RID: 91 RVA: 0x00002B2D File Offset: 0x00000D2D
		public MetricId Id { get; }

		// Token: 0x0600005C RID: 92 RVA: 0x00002B35 File Offset: 0x00000D35
		public int GetWriteSize()
		{
			return FastBufferWriter.GetWriteSize<TValue>();
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00002B3C File Offset: 0x00000D3C
		public void Write(FastBufferWriter writer)
		{
			TValue value = this.Value;
			writer.TryBeginWriteValue<TValue>(value);
			value = this.Value;
			writer.WriteValue<TValue>(value);
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00002B6C File Offset: 0x00000D6C
		public void Read(FastBufferReader reader)
		{
			TValue tvalue = default(TValue);
			reader.TryBeginReadValue<TValue>(tvalue);
			TValue value;
			reader.ReadValue<TValue>(out value);
			this.Value = value;
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600005F RID: 95
		public abstract MetricContainerType MetricContainerType { get; }

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000060 RID: 96 RVA: 0x00002B9C File Offset: 0x00000D9C
		public FixedString128Bytes FactoryTypeName
		{
			get
			{
				return default(FixedString128Bytes);
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000061 RID: 97 RVA: 0x00002BB2 File Offset: 0x00000DB2
		// (set) Token: 0x06000062 RID: 98 RVA: 0x00002BBA File Offset: 0x00000DBA
		public TValue Value { get; protected set; }

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000063 RID: 99 RVA: 0x00002BC3 File Offset: 0x00000DC3
		protected TValue DefaultValue { get; }

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000064 RID: 100 RVA: 0x00002BCB File Offset: 0x00000DCB
		// (set) Token: 0x06000065 RID: 101 RVA: 0x00002BD3 File Offset: 0x00000DD3
		public bool ShouldResetOnDispatch { get; set; } = true;

		// Token: 0x06000066 RID: 102 RVA: 0x00002BDC File Offset: 0x00000DDC
		public void Reset()
		{
			this.Value = this.DefaultValue;
		}
	}
}
