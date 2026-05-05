using System;

namespace Unity.VisualScripting
{
	// Token: 0x020000DA RID: 218
	[UnitOrder(601)]
	public abstract class PerSecond<T> : Unit
	{
		// Token: 0x17000268 RID: 616
		// (get) Token: 0x06000691 RID: 1681 RVA: 0x0000D01E File Offset: 0x0000B21E
		// (set) Token: 0x06000692 RID: 1682 RVA: 0x0000D026 File Offset: 0x0000B226
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueInput input { get; private set; }

		// Token: 0x17000269 RID: 617
		// (get) Token: 0x06000693 RID: 1683 RVA: 0x0000D02F File Offset: 0x0000B22F
		// (set) Token: 0x06000694 RID: 1684 RVA: 0x0000D037 File Offset: 0x0000B237
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueOutput output { get; private set; }

		// Token: 0x06000695 RID: 1685 RVA: 0x0000D040 File Offset: 0x0000B240
		protected override void Definition()
		{
			this.input = base.ValueInput<T>("input", default(T));
			this.output = base.ValueOutput<T>("output", new Func<Flow, T>(this.Operation));
			base.Requirement(this.input, this.output);
		}

		// Token: 0x06000696 RID: 1686
		public abstract T Operation(T input);

		// Token: 0x06000697 RID: 1687 RVA: 0x0000D096 File Offset: 0x0000B296
		public T Operation(Flow flow)
		{
			return this.Operation(flow.GetValue<T>(this.input));
		}
	}
}
