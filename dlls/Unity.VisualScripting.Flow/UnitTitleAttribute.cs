using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000016 RID: 22
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
	public sealed class UnitTitleAttribute : Attribute
	{
		// Token: 0x0600006E RID: 110 RVA: 0x00002935 File Offset: 0x00000B35
		public UnitTitleAttribute(string title)
		{
			this.title = title;
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x0600006F RID: 111 RVA: 0x00002944 File Offset: 0x00000B44
		// (set) Token: 0x06000070 RID: 112 RVA: 0x0000294C File Offset: 0x00000B4C
		public string title { get; private set; }
	}
}
