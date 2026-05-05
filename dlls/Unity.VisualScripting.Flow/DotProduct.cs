using System;

namespace Unity.VisualScripting
{
	// Token: 0x020000CC RID: 204
	[UnitOrder(404)]
	public abstract class DotProduct<T> : Unit
	{
		// Token: 0x1700024B RID: 587
		// (get) Token: 0x0600062F RID: 1583 RVA: 0x0000C755 File Offset: 0x0000A955
		// (set) Token: 0x06000630 RID: 1584 RVA: 0x0000C75D File Offset: 0x0000A95D
		[DoNotSerialize]
		public ValueInput a { get; private set; }

		// Token: 0x1700024C RID: 588
		// (get) Token: 0x06000631 RID: 1585 RVA: 0x0000C766 File Offset: 0x0000A966
		// (set) Token: 0x06000632 RID: 1586 RVA: 0x0000C76E File Offset: 0x0000A96E
		[DoNotSerialize]
		public ValueInput b { get; private set; }

		// Token: 0x1700024D RID: 589
		// (get) Token: 0x06000633 RID: 1587 RVA: 0x0000C777 File Offset: 0x0000A977
		// (set) Token: 0x06000634 RID: 1588 RVA: 0x0000C77F File Offset: 0x0000A97F
		[DoNotSerialize]
		[PortLabel("A∙B")]
		public ValueOutput dotProduct { get; private set; }

		// Token: 0x06000635 RID: 1589 RVA: 0x0000C788 File Offset: 0x0000A988
		protected override void Definition()
		{
			this.a = base.ValueInput<T>("a");
			this.b = base.ValueInput<T>("b");
			this.dotProduct = base.ValueOutput<float>("dotProduct", new Func<Flow, float>(this.Operation)).Predictable();
			base.Requirement(this.a, this.dotProduct);
			base.Requirement(this.b, this.dotProduct);
		}

		// Token: 0x06000636 RID: 1590 RVA: 0x0000C7FD File Offset: 0x0000A9FD
		private float Operation(Flow flow)
		{
			return this.Operation(flow.GetValue<T>(this.a), flow.GetValue<T>(this.b));
		}

		// Token: 0x06000637 RID: 1591
		public abstract float Operation(T a, T b);
	}
}
