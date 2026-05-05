using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000039 RID: 57
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public sealed class InspectableIfAttribute : Attribute, IInspectableAttribute
	{
		// Token: 0x060001C0 RID: 448 RVA: 0x00004DBC File Offset: 0x00002FBC
		public InspectableIfAttribute(string conditionMember)
		{
			this.conditionMember = conditionMember;
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x060001C1 RID: 449 RVA: 0x00004DCB File Offset: 0x00002FCB
		// (set) Token: 0x060001C2 RID: 450 RVA: 0x00004DD3 File Offset: 0x00002FD3
		public int order { get; set; }

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x060001C3 RID: 451 RVA: 0x00004DDC File Offset: 0x00002FDC
		public string conditionMember { get; }
	}
}
