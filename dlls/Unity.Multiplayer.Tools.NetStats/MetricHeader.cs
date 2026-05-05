using System;
using Unity.Collections;

namespace Unity.Multiplayer.Tools.NetStats
{
	// Token: 0x02000033 RID: 51
	internal struct MetricHeader
	{
		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000143 RID: 323 RVA: 0x00004D7E File Offset: 0x00002F7E
		// (set) Token: 0x06000144 RID: 324 RVA: 0x00004D86 File Offset: 0x00002F86
		public FixedString128Bytes EventFactoryTypeName { readonly get; set; }

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000145 RID: 325 RVA: 0x00004D8F File Offset: 0x00002F8F
		// (set) Token: 0x06000146 RID: 326 RVA: 0x00004D97 File Offset: 0x00002F97
		public MetricContainerType MetricContainerType { readonly get; set; }

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000147 RID: 327 RVA: 0x00004DA0 File Offset: 0x00002FA0
		// (set) Token: 0x06000148 RID: 328 RVA: 0x00004DA8 File Offset: 0x00002FA8
		public MetricId MetricId { readonly get; set; }

		// Token: 0x06000149 RID: 329 RVA: 0x00004DB1 File Offset: 0x00002FB1
		public MetricHeader(FixedString128Bytes eventFactoryTypeName, MetricContainerType metricContainerType, MetricId metricId)
		{
			this.EventFactoryTypeName = eventFactoryTypeName;
			this.MetricContainerType = metricContainerType;
			this.MetricId = metricId;
		}
	}
}
