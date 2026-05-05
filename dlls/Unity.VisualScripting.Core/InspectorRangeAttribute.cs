using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200003F RID: 63
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
	public sealed class InspectorRangeAttribute : Attribute
	{
		// Token: 0x060001D4 RID: 468 RVA: 0x00004E8C File Offset: 0x0000308C
		public InspectorRangeAttribute(float min, float max)
		{
			this.min = min;
			this.max = max;
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x060001D5 RID: 469 RVA: 0x00004EA2 File Offset: 0x000030A2
		// (set) Token: 0x060001D6 RID: 470 RVA: 0x00004EAA File Offset: 0x000030AA
		public float min { get; private set; }

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x060001D7 RID: 471 RVA: 0x00004EB3 File Offset: 0x000030B3
		// (set) Token: 0x060001D8 RID: 472 RVA: 0x00004EBB File Offset: 0x000030BB
		public float max { get; private set; }
	}
}
