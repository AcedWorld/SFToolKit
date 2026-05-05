using System;
using System.Collections.Generic;
using System.Linq;

namespace Unity.VisualScripting
{
	// Token: 0x020000D5 RID: 213
	[UnitOrder(301)]
	public abstract class Minimum<T> : MultiInputUnit<T>
	{
		// Token: 0x17000255 RID: 597
		// (get) Token: 0x0600065B RID: 1627 RVA: 0x0000CB1A File Offset: 0x0000AD1A
		// (set) Token: 0x0600065C RID: 1628 RVA: 0x0000CB22 File Offset: 0x0000AD22
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueOutput minimum { get; private set; }

		// Token: 0x0600065D RID: 1629 RVA: 0x0000CB2C File Offset: 0x0000AD2C
		protected override void Definition()
		{
			base.Definition();
			this.minimum = base.ValueOutput<T>("minimum", new Func<Flow, T>(this.Operation)).Predictable();
			foreach (ValueInput source in base.multiInputs)
			{
				base.Requirement(source, this.minimum);
			}
		}

		// Token: 0x0600065E RID: 1630
		public abstract T Operation(T a, T b);

		// Token: 0x0600065F RID: 1631
		public abstract T Operation(IEnumerable<T> values);

		// Token: 0x06000660 RID: 1632 RVA: 0x0000CBA8 File Offset: 0x0000ADA8
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
