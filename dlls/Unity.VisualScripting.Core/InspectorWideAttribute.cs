using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000042 RID: 66
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	public sealed class InspectorWideAttribute : Attribute
	{
		// Token: 0x060001E1 RID: 481 RVA: 0x00004F24 File Offset: 0x00003124
		public InspectorWideAttribute()
		{
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x00004F2C File Offset: 0x0000312C
		public InspectorWideAttribute(bool toEdge)
		{
			this.toEdge = toEdge;
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x060001E3 RID: 483 RVA: 0x00004F3B File Offset: 0x0000313B
		// (set) Token: 0x060001E4 RID: 484 RVA: 0x00004F43 File Offset: 0x00003143
		public bool toEdge { get; private set; }
	}
}
