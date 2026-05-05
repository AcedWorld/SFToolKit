using System;

namespace Unity.VisualScripting
{
	// Token: 0x020000BA RID: 186
	[UnitCategory("Logic")]
	[UnitTitle("Equality Comparison")]
	[UnitSurtitle("Equality")]
	[UnitShortTitle("Comparison")]
	[UnitOrder(4)]
	[Obsolete("Use the Comparison node instead.")]
	public sealed class EqualityComparison : Unit
	{
		// Token: 0x1700021A RID: 538
		// (get) Token: 0x06000593 RID: 1427 RVA: 0x0000B972 File Offset: 0x00009B72
		// (set) Token: 0x06000594 RID: 1428 RVA: 0x0000B97A File Offset: 0x00009B7A
		[DoNotSerialize]
		public ValueInput a { get; private set; }

		// Token: 0x1700021B RID: 539
		// (get) Token: 0x06000595 RID: 1429 RVA: 0x0000B983 File Offset: 0x00009B83
		// (set) Token: 0x06000596 RID: 1430 RVA: 0x0000B98B File Offset: 0x00009B8B
		[DoNotSerialize]
		public ValueInput b { get; private set; }

		// Token: 0x1700021C RID: 540
		// (get) Token: 0x06000597 RID: 1431 RVA: 0x0000B994 File Offset: 0x00009B94
		// (set) Token: 0x06000598 RID: 1432 RVA: 0x0000B99C File Offset: 0x00009B9C
		[DoNotSerialize]
		[PortLabel("A = B")]
		public ValueOutput equal { get; private set; }

		// Token: 0x1700021D RID: 541
		// (get) Token: 0x06000599 RID: 1433 RVA: 0x0000B9A5 File Offset: 0x00009BA5
		// (set) Token: 0x0600059A RID: 1434 RVA: 0x0000B9AD File Offset: 0x00009BAD
		[DoNotSerialize]
		[PortLabel("A ≠ B")]
		public ValueOutput notEqual { get; private set; }

		// Token: 0x0600059B RID: 1435 RVA: 0x0000B9B8 File Offset: 0x00009BB8
		protected override void Definition()
		{
			this.a = base.ValueInput<object>("a").AllowsNull();
			this.b = base.ValueInput<object>("b").AllowsNull();
			this.equal = base.ValueOutput<bool>("equal", new Func<Flow, bool>(this.Equal)).Predictable();
			this.notEqual = base.ValueOutput<bool>("notEqual", new Func<Flow, bool>(this.NotEqual)).Predictable();
			base.Requirement(this.a, this.equal);
			base.Requirement(this.b, this.equal);
			base.Requirement(this.a, this.notEqual);
			base.Requirement(this.b, this.notEqual);
		}

		// Token: 0x0600059C RID: 1436 RVA: 0x0000BA7D File Offset: 0x00009C7D
		private bool Equal(Flow flow)
		{
			return OperatorUtility.Equal(flow.GetValue(this.a), flow.GetValue(this.b));
		}

		// Token: 0x0600059D RID: 1437 RVA: 0x0000BA9C File Offset: 0x00009C9C
		private bool NotEqual(Flow flow)
		{
			return OperatorUtility.NotEqual(flow.GetValue(this.a), flow.GetValue(this.b));
		}
	}
}
