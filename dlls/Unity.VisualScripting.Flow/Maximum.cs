using System;
using System.Collections.Generic;
using System.Linq;

namespace Unity.VisualScripting
{
	// Token: 0x020000D4 RID: 212
	[UnitOrder(302)]
	public abstract class Maximum<T> : MultiInputUnit<T>
	{
		// Token: 0x17000254 RID: 596
		// (get) Token: 0x06000654 RID: 1620 RVA: 0x0000CA25 File Offset: 0x0000AC25
		// (set) Token: 0x06000655 RID: 1621 RVA: 0x0000CA2D File Offset: 0x0000AC2D
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueOutput maximum { get; private set; }

		// Token: 0x06000656 RID: 1622 RVA: 0x0000CA38 File Offset: 0x0000AC38
		protected override void Definition()
		{
			base.Definition();
			this.maximum = base.ValueOutput<T>("maximum", new Func<Flow, T>(this.Operation)).Predictable();
			foreach (ValueInput source in base.multiInputs)
			{
				base.Requirement(source, this.maximum);
			}
		}

		// Token: 0x06000657 RID: 1623
		public abstract T Operation(T a, T b);

		// Token: 0x06000658 RID: 1624
		public abstract T Operation(IEnumerable<T> values);

		// Token: 0x06000659 RID: 1625 RVA: 0x0000CAB4 File Offset: 0x0000ACB4
		public T Operation(Flow flow)
		{
			if (this.inputCount == 2)
			{
				return this.Operation(flow.GetValue<T>(base.multiInputs[0]), flow.GetValue<T>(base.multiInputs[1]));
			}
			return this.Operation(base.multiInputs.Select(new Func<ValueInput, T>(flow.GetValue<T>)));
		}
	}
}
