using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000047 RID: 71
	[AttributeUsage(AttributeTargets.Interface, AllowMultiple = false, Inherited = false)]
	public sealed class TypeIconPriorityAttribute : Attribute
	{
		// Token: 0x060001EA RID: 490 RVA: 0x00004F8B File Offset: 0x0000318B
		public TypeIconPriorityAttribute(int priority)
		{
			this.priority = priority;
		}

		// Token: 0x060001EB RID: 491 RVA: 0x00004F9A File Offset: 0x0000319A
		public TypeIconPriorityAttribute()
		{
			this.priority = 0;
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x060001EC RID: 492 RVA: 0x00004FA9 File Offset: 0x000031A9
		public int priority { get; }
	}
}
