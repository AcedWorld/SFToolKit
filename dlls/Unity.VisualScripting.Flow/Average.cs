using System;
using System.Collections.Generic;
using System.Linq;

namespace Unity.VisualScripting
{
	// Token: 0x020000C8 RID: 200
	[UnitOrder(304)]
	public abstract class Average<T> : MultiInputUnit<T>
	{
		// Token: 0x1700023F RID: 575
		// (get) Token: 0x06000608 RID: 1544 RVA: 0x0000C3B1 File Offset: 0x0000A5B1
		// (set) Token: 0x06000609 RID: 1545 RVA: 0x0000C3B9 File Offset: 0x0000A5B9
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueOutput average { get; private set; }

		// Token: 0x0600060A RID: 1546 RVA: 0x0000C3C4 File Offset: 0x0000A5C4
		protected override void Definition()
		{
			base.Definition();
			this.average = base.ValueOutput<T>("average", new Func<Flow, T>(this.Operation)).Predictable();
			foreach (ValueInput source in base.multiInputs)
			{
				base.Requirement(source, this.average);
			}
		}

		// Token: 0x0600060B RID: 1547
		public abstract T Operation(T a, T b);

		// Token: 0x0600060C RID: 1548
		public abstract T Operation(IEnumerable<T> values);

		// Token: 0x0600060D RID: 1549 RVA: 0x0000C440 File Offset: 0x0000A640
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
