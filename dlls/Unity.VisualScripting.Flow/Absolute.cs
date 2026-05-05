using System;

namespace Unity.VisualScripting
{
	// Token: 0x020000C5 RID: 197
	[UnitOrder(201)]
	public abstract class Absolute<TInput> : Unit
	{
		// Token: 0x17000236 RID: 566
		// (get) Token: 0x060005EB RID: 1515 RVA: 0x0000C15B File Offset: 0x0000A35B
		// (set) Token: 0x060005EC RID: 1516 RVA: 0x0000C163 File Offset: 0x0000A363
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueInput input { get; private set; }

		// Token: 0x17000237 RID: 567
		// (get) Token: 0x060005ED RID: 1517 RVA: 0x0000C16C File Offset: 0x0000A36C
		// (set) Token: 0x060005EE RID: 1518 RVA: 0x0000C174 File Offset: 0x0000A374
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueOutput output { get; private set; }

		// Token: 0x060005EF RID: 1519 RVA: 0x0000C180 File Offset: 0x0000A380
		protected override void Definition()
		{
			this.input = base.ValueInput<TInput>("input");
			this.output = base.ValueOutput<TInput>("output", new Func<Flow, TInput>(this.Operation)).Predictable();
			base.Requirement(this.input, this.output);
		}

		// Token: 0x060005F0 RID: 1520
		protected abstract TInput Operation(TInput input);

		// Token: 0x060005F1 RID: 1521 RVA: 0x0000C1D2 File Offset: 0x0000A3D2
		public TInput Operation(Flow flow)
		{
			return this.Operation(flow.GetValue<TInput>(this.input));
		}
	}
}
