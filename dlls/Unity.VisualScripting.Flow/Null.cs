using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200012B RID: 299
	[UnitCategory("Nulls")]
	public sealed class Null : Unit
	{
		// Token: 0x170002B4 RID: 692
		// (get) Token: 0x060007BE RID: 1982 RVA: 0x0000E704 File Offset: 0x0000C904
		// (set) Token: 0x060007BF RID: 1983 RVA: 0x0000E70C File Offset: 0x0000C90C
		[DoNotSerialize]
		public ValueOutput @null { get; private set; }

		// Token: 0x060007C0 RID: 1984 RVA: 0x0000E715 File Offset: 0x0000C915
		protected override void Definition()
		{
			this.@null = base.ValueOutput<object>("null", (Flow recursion) => null).Predictable();
		}
	}
}
