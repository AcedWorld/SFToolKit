using System;

namespace Unity.VisualScripting
{
	// Token: 0x020000C9 RID: 201
	[UnitOrder(405)]
	[TypeIcon(typeof(Multiply<>))]
	public abstract class CrossProduct<T> : Unit
	{
		// Token: 0x17000240 RID: 576
		// (get) Token: 0x0600060F RID: 1551 RVA: 0x0000C4A6 File Offset: 0x0000A6A6
		// (set) Token: 0x06000610 RID: 1552 RVA: 0x0000C4AE File Offset: 0x0000A6AE
		[DoNotSerialize]
		public ValueInput a { get; private set; }

		// Token: 0x17000241 RID: 577
		// (get) Token: 0x06000611 RID: 1553 RVA: 0x0000C4B7 File Offset: 0x0000A6B7
		// (set) Token: 0x06000612 RID: 1554 RVA: 0x0000C4BF File Offset: 0x0000A6BF
		[DoNotSerialize]
		public ValueInput b { get; private set; }

		// Token: 0x17000242 RID: 578
		// (get) Token: 0x06000613 RID: 1555 RVA: 0x0000C4C8 File Offset: 0x0000A6C8
		// (set) Token: 0x06000614 RID: 1556 RVA: 0x0000C4D0 File Offset: 0x0000A6D0
		[DoNotSerialize]
		[PortLabel("A × B")]
		public ValueOutput crossProduct { get; private set; }

		// Token: 0x06000615 RID: 1557 RVA: 0x0000C4DC File Offset: 0x0000A6DC
		protected override void Definition()
		{
			this.a = base.ValueInput<T>("a");
			this.b = base.ValueInput<T>("b");
			this.crossProduct = base.ValueOutput<T>("crossProduct", new Func<Flow, T>(this.Operation)).Predictable();
			base.Requirement(this.a, this.crossProduct);
			base.Requirement(this.b, this.crossProduct);
		}

		// Token: 0x06000616 RID: 1558 RVA: 0x0000C551 File Offset: 0x0000A751
		private T Operation(Flow flow)
		{
			return this.Operation(flow.GetValue<T>(this.a), flow.GetValue<T>(this.b));
		}

		// Token: 0x06000617 RID: 1559
		public abstract T Operation(T a, T b);
	}
}
