using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200012C RID: 300
	[UnitCategory("Nulls")]
	[TypeIcon(typeof(Null))]
	public sealed class NullCheck : Unit
	{
		// Token: 0x170002B5 RID: 693
		// (get) Token: 0x060007C2 RID: 1986 RVA: 0x0000E754 File Offset: 0x0000C954
		// (set) Token: 0x060007C3 RID: 1987 RVA: 0x0000E75C File Offset: 0x0000C95C
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueInput input { get; private set; }

		// Token: 0x170002B6 RID: 694
		// (get) Token: 0x060007C4 RID: 1988 RVA: 0x0000E765 File Offset: 0x0000C965
		// (set) Token: 0x060007C5 RID: 1989 RVA: 0x0000E76D File Offset: 0x0000C96D
		[DoNotSerialize]
		[PortLabelHidden]
		public ControlInput enter { get; private set; }

		// Token: 0x170002B7 RID: 695
		// (get) Token: 0x060007C6 RID: 1990 RVA: 0x0000E776 File Offset: 0x0000C976
		// (set) Token: 0x060007C7 RID: 1991 RVA: 0x0000E77E File Offset: 0x0000C97E
		[DoNotSerialize]
		[PortLabel("Not Null")]
		public ControlOutput ifNotNull { get; private set; }

		// Token: 0x170002B8 RID: 696
		// (get) Token: 0x060007C8 RID: 1992 RVA: 0x0000E787 File Offset: 0x0000C987
		// (set) Token: 0x060007C9 RID: 1993 RVA: 0x0000E78F File Offset: 0x0000C98F
		[DoNotSerialize]
		[PortLabel("Null")]
		public ControlOutput ifNull { get; private set; }

		// Token: 0x060007CA RID: 1994 RVA: 0x0000E798 File Offset: 0x0000C998
		protected override void Definition()
		{
			this.enter = base.ControlInput("enter", new Func<Flow, ControlOutput>(this.Enter));
			this.input = base.ValueInput<object>("input").AllowsNull();
			this.ifNotNull = base.ControlOutput("ifNotNull");
			this.ifNull = base.ControlOutput("ifNull");
			base.Requirement(this.input, this.enter);
			base.Succession(this.enter, this.ifNotNull);
			base.Succession(this.enter, this.ifNull);
		}

		// Token: 0x060007CB RID: 1995 RVA: 0x0000E830 File Offset: 0x0000CA30
		public ControlOutput Enter(Flow flow)
		{
			object value = flow.GetValue(this.input);
			bool flag;
			if (value is Object)
			{
				flag = ((Object)value == null);
			}
			else
			{
				flag = (value == null);
			}
			if (flag)
			{
				return this.ifNull;
			}
			return this.ifNotNull;
		}
	}
}
