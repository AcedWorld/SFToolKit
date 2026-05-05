using System;

namespace Unity.VisualScripting
{
	// Token: 0x020000CA RID: 202
	[UnitOrder(402)]
	public abstract class Distance<T> : Unit
	{
		// Token: 0x17000243 RID: 579
		// (get) Token: 0x06000619 RID: 1561 RVA: 0x0000C579 File Offset: 0x0000A779
		// (set) Token: 0x0600061A RID: 1562 RVA: 0x0000C581 File Offset: 0x0000A781
		[DoNotSerialize]
		public ValueInput a { get; private set; }

		// Token: 0x17000244 RID: 580
		// (get) Token: 0x0600061B RID: 1563 RVA: 0x0000C58A File Offset: 0x0000A78A
		// (set) Token: 0x0600061C RID: 1564 RVA: 0x0000C592 File Offset: 0x0000A792
		[DoNotSerialize]
		public ValueInput b { get; private set; }

		// Token: 0x17000245 RID: 581
		// (get) Token: 0x0600061D RID: 1565 RVA: 0x0000C59B File Offset: 0x0000A79B
		// (set) Token: 0x0600061E RID: 1566 RVA: 0x0000C5A3 File Offset: 0x0000A7A3
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueOutput distance { get; private set; }

		// Token: 0x0600061F RID: 1567 RVA: 0x0000C5AC File Offset: 0x0000A7AC
		protected override void Definition()
		{
			this.a = base.ValueInput<T>("a");
			this.b = base.ValueInput<T>("b");
			this.distance = base.ValueOutput<float>("distance", new Func<Flow, float>(this.Operation)).Predictable();
			base.Requirement(this.a, this.distance);
			base.Requirement(this.b, this.distance);
		}

		// Token: 0x06000620 RID: 1568 RVA: 0x0000C621 File Offset: 0x0000A821
		private float Operation(Flow flow)
		{
			return this.Operation(flow.GetValue<T>(this.a), flow.GetValue<T>(this.b));
		}

		// Token: 0x06000621 RID: 1569
		public abstract float Operation(T a, T b);
	}
}
