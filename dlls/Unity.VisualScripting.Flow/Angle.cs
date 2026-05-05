using System;

namespace Unity.VisualScripting
{
	// Token: 0x020000C7 RID: 199
	[UnitOrder(403)]
	public abstract class Angle<T> : Unit
	{
		// Token: 0x1700023C RID: 572
		// (get) Token: 0x060005FE RID: 1534 RVA: 0x0000C2DF File Offset: 0x0000A4DF
		// (set) Token: 0x060005FF RID: 1535 RVA: 0x0000C2E7 File Offset: 0x0000A4E7
		[DoNotSerialize]
		public ValueInput a { get; private set; }

		// Token: 0x1700023D RID: 573
		// (get) Token: 0x06000600 RID: 1536 RVA: 0x0000C2F0 File Offset: 0x0000A4F0
		// (set) Token: 0x06000601 RID: 1537 RVA: 0x0000C2F8 File Offset: 0x0000A4F8
		[DoNotSerialize]
		public ValueInput b { get; private set; }

		// Token: 0x1700023E RID: 574
		// (get) Token: 0x06000602 RID: 1538 RVA: 0x0000C301 File Offset: 0x0000A501
		// (set) Token: 0x06000603 RID: 1539 RVA: 0x0000C309 File Offset: 0x0000A509
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueOutput angle { get; private set; }

		// Token: 0x06000604 RID: 1540 RVA: 0x0000C314 File Offset: 0x0000A514
		protected override void Definition()
		{
			this.a = base.ValueInput<T>("a");
			this.b = base.ValueInput<T>("b");
			this.angle = base.ValueOutput<float>("angle", new Func<Flow, float>(this.Operation)).Predictable();
			base.Requirement(this.a, this.angle);
			base.Requirement(this.b, this.angle);
		}

		// Token: 0x06000605 RID: 1541 RVA: 0x0000C389 File Offset: 0x0000A589
		private float Operation(Flow flow)
		{
			return this.Operation(flow.GetValue<T>(this.a), flow.GetValue<T>(this.b));
		}

		// Token: 0x06000606 RID: 1542
		public abstract float Operation(T a, T b);
	}
}
