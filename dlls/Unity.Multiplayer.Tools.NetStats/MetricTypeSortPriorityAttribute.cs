using System;

namespace Unity.Multiplayer.Tools.NetStats
{
	// Token: 0x02000022 RID: 34
	[AttributeUsage(AttributeTargets.Enum)]
	internal class MetricTypeSortPriorityAttribute : Attribute
	{
		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000089 RID: 137 RVA: 0x00002E94 File Offset: 0x00001094
		// (set) Token: 0x0600008A RID: 138 RVA: 0x00002E9C File Offset: 0x0000109C
		public SortPriority SortPriority { get; set; }
	}
}
