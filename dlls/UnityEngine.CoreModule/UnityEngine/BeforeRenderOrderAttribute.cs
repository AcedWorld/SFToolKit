using System;

namespace UnityEngine
{
	// Token: 0x02000138 RID: 312
	[AttributeUsage(AttributeTargets.Method)]
	public class BeforeRenderOrderAttribute : Attribute
	{
		// Token: 0x170001DE RID: 478
		// (get) Token: 0x060008A4 RID: 2212 RVA: 0x0000DE97 File Offset: 0x0000C097
		// (set) Token: 0x060008A5 RID: 2213 RVA: 0x0000DE9F File Offset: 0x0000C09F
		public int order { get; private set; }

		// Token: 0x060008A6 RID: 2214 RVA: 0x0000DEA8 File Offset: 0x0000C0A8
		public BeforeRenderOrderAttribute(int order)
		{
			this.order = order;
		}
	}
}
