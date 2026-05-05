using System;

namespace Unity.Multiplayer.Tools.NetStats
{
	// Token: 0x0200001F RID: 31
	[AttributeUsage(AttributeTargets.Enum)]
	public class MetricTypeEnumAttribute : Attribute
	{
		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000085 RID: 133 RVA: 0x00002E73 File Offset: 0x00001073
		// (set) Token: 0x06000086 RID: 134 RVA: 0x00002E7B File Offset: 0x0000107B
		public string DisplayName { get; set; }
	}
}
