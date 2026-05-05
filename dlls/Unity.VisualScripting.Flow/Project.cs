using System;

namespace Unity.VisualScripting
{
	// Token: 0x020000DB RID: 219
	[UnitOrder(406)]
	public abstract class Project<T> : Unit
	{
		// Token: 0x1700026A RID: 618
		// (get) Token: 0x06000699 RID: 1689 RVA: 0x0000D0B2 File Offset: 0x0000B2B2
		// (set) Token: 0x0600069A RID: 1690 RVA: 0x0000D0BA File Offset: 0x0000B2BA
		[DoNotSerialize]
		public ValueInput a { get; private set; }

		// Token: 0x1700026B RID: 619
		// (get) Token: 0x0600069B RID: 1691 RVA: 0x0000D0C3 File Offset: 0x0000B2C3
		// (set) Token: 0x0600069C RID: 1692 RVA: 0x0000D0CB File Offset: 0x0000B2CB
		[DoNotSerialize]
		public ValueInput b { get; private set; }

		// Token: 0x1700026C RID: 620
		// (get) Token: 0x0600069D RID: 1693 RVA: 0x0000D0D4 File Offset: 0x0000B2D4
		// (set) Token: 0x0600069E RID: 1694 RVA: 0x0000D0DC File Offset: 0x0000B2DC
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueOutput projection { get; private set; }

		// Token: 0x0600069F RID: 1695 RVA: 0x0000D0E8 File Offset: 0x0000B2E8
		protected override void Definition()
		{
			this.a = base.ValueInput<T>("a");
			this.b = base.ValueInput<T>("b");
			this.projection = base.ValueOutput<T>("projection", new Func<Flow, T>(this.Operation)).Predictable();
			base.Requirement(this.a, this.projection);
			base.Requirement(this.b, this.projection);
		}

		// Token: 0x060006A0 RID: 1696 RVA: 0x0000D15D File Offset: 0x0000B35D
		private T Operation(Flow flow)
		{
			return this.Operation(flow.GetValue<T>(this.a), flow.GetValue<T>(this.b));
		}

		// Token: 0x060006A1 RID: 1697
		public abstract T Operation(T a, T b);
	}
}
