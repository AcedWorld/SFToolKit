using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000013 RID: 19
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
	public sealed class UnitShortTitleAttribute : Attribute
	{
		// Token: 0x06000065 RID: 101 RVA: 0x000028D5 File Offset: 0x00000AD5
		public UnitShortTitleAttribute(string title)
		{
			this.title = title;
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000066 RID: 102 RVA: 0x000028E4 File Offset: 0x00000AE4
		// (set) Token: 0x06000067 RID: 103 RVA: 0x000028EC File Offset: 0x00000AEC
		public string title { get; private set; }
	}
}
