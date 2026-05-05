using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections;

namespace Unity.Multiplayer.Tools.NetStats
{
	// Token: 0x0200000D RID: 13
	[Serializable]
	internal class EventMetric<[IsUnmanaged] TValue> : IEventMetric<TValue>, IEventMetric, IMetric, IResettable where TValue : struct, ValueType
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600002B RID: 43 RVA: 0x00002774 File Offset: 0x00000974
		public int Count
		{
			get
			{
				return this.m_Values.Count;
			}
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00002784 File Offset: 0x00000984
		public EventMetric(MetricId id)
		{
			this.Id = id;
			FixedString128Bytes fixedString128Bytes;
			if (EventMetricFactory.TryGetFactoryTypeName(typeof(TValue), out fixedString128Bytes))
			{
				this.FactoryTypeName = fixedString128Bytes;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600002D RID: 45 RVA: 0x000027D8 File Offset: 0x000009D8
		public string Name
		{
			get
			{
				return this.Id.ToString();
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600002E RID: 46 RVA: 0x000027F9 File Offset: 0x000009F9
		public MetricId Id { get; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600002F RID: 47 RVA: 0x00002801 File Offset: 0x00000A01
		public MetricContainerType MetricContainerType
		{
			get
			{
				return MetricContainerType.Event;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000030 RID: 48 RVA: 0x00002804 File Offset: 0x00000A04
		public FixedString128Bytes FactoryTypeName { get; }

		// Token: 0x06000031 RID: 49 RVA: 0x0000280C File Offset: 0x00000A0C
		public int GetWriteSize()
		{
			return 0 + FastBufferWriter.GetWriteSize<int>() + FastBufferWriter.GetWriteSize<TValue>() * this.m_Values.Count;
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00002828 File Offset: 0x00000A28
		public void Write(FastBufferWriter writer)
		{
			int count = this.m_Values.Count;
			writer.WriteValue<int>(count);
			for (int i = 0; i < this.m_Values.Count; i++)
			{
				TValue tvalue = this.m_Values[i];
				writer.WriteValue<TValue>(tvalue);
			}
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00002878 File Offset: 0x00000A78
		public void Read(FastBufferReader reader)
		{
			this.m_Values.Clear();
			int num;
			reader.ReadValueSafe<int>(out num);
			for (int i = 0; i < num; i++)
			{
				TValue item;
				reader.ReadValueSafe<TValue>(out item);
				this.m_Values.Add(item);
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000034 RID: 52 RVA: 0x000028BA File Offset: 0x00000ABA
		public IReadOnlyList<TValue> Values
		{
			get
			{
				return this.m_Values;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000035 RID: 53 RVA: 0x000028C2 File Offset: 0x00000AC2
		// (set) Token: 0x06000036 RID: 54 RVA: 0x000028CA File Offset: 0x00000ACA
		public bool ShouldResetOnDispatch { get; set; } = true;

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000037 RID: 55 RVA: 0x000028D3 File Offset: 0x00000AD3
		// (set) Token: 0x06000038 RID: 56 RVA: 0x000028DB File Offset: 0x00000ADB
		public int MaxNumberOfValues { get; set; } = 1000;

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000039 RID: 57 RVA: 0x000028E4 File Offset: 0x00000AE4
		// (set) Token: 0x0600003A RID: 58 RVA: 0x000028EC File Offset: 0x00000AEC
		public int NumberOfValuesReceived { get; private set; }

		// Token: 0x0600003B RID: 59 RVA: 0x000028F8 File Offset: 0x00000AF8
		public void Mark(TValue value)
		{
			int numberOfValuesReceived = this.NumberOfValuesReceived + 1;
			this.NumberOfValuesReceived = numberOfValuesReceived;
			if (this.m_Values.Count >= this.MaxNumberOfValues)
			{
				return;
			}
			this.m_Values.Add(value);
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00002935 File Offset: 0x00000B35
		public void Reset()
		{
			this.m_Values.Clear();
			this.NumberOfValuesReceived = 0;
		}

		// Token: 0x04000015 RID: 21
		private const int k_DefaultMaxNumberOfValues = 1000;

		// Token: 0x04000016 RID: 22
		private readonly List<TValue> m_Values = new List<TValue>();
	}
}
