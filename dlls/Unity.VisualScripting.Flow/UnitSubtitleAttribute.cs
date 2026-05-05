using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000014 RID: 20
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	public sealed class UnitSubtitleAttribute : Attribute
	{
		// Token: 0x06000068 RID: 104 RVA: 0x000028F5 File Offset: 0x00000AF5
		public UnitSubtitleAttribute(string subtitle)
		{
			this.subtitle = subtitle;
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000069 RID: 105 RVA: 0x00002904 File Offset: 0x00000B04
		// (set) Token: 0x0600006A RID: 106 RVA: 0x0000290C File Offset: 0x00000B0C
		public string subtitle { get; private set; }
	}
}
