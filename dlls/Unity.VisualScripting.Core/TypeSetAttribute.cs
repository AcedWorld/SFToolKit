using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000049 RID: 73
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class TypeSetAttribute : Attribute
	{
		// Token: 0x060001ED RID: 493 RVA: 0x00004FB1 File Offset: 0x000031B1
		public TypeSetAttribute(TypeSet typeSet)
		{
			this.typeSet = typeSet;
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x060001EE RID: 494 RVA: 0x00004FC0 File Offset: 0x000031C0
		public TypeSet typeSet { get; }
	}
}
