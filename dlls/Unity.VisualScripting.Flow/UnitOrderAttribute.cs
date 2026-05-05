using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000012 RID: 18
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
	public sealed class UnitOrderAttribute : Attribute
	{
		// Token: 0x06000062 RID: 98 RVA: 0x000028B5 File Offset: 0x00000AB5
		public UnitOrderAttribute(int order)
		{
			this.order = order;
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000063 RID: 99 RVA: 0x000028C4 File Offset: 0x00000AC4
		// (set) Token: 0x06000064 RID: 100 RVA: 0x000028CC File Offset: 0x00000ACC
		public int order { get; private set; }
	}
}
