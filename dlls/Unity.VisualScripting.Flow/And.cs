using System;

namespace Unity.VisualScripting
{
	// Token: 0x020000B5 RID: 181
	[UnitCategory("Logic")]
	[UnitOrder(0)]
	public sealed class And : Unit
	{
		// Token: 0x17000204 RID: 516
		// (get) Token: 0x06000541 RID: 1345 RVA: 0x0000B0CF File Offset: 0x000092CF
		// (set) Token: 0x06000542 RID: 1346 RVA: 0x0000B0D7 File Offset: 0x000092D7
		[DoNotSerialize]
		public ValueInput a { get; private set; }

		// Token: 0x17000205 RID: 517
		// (get) Token: 0x06000543 RID: 1347 RVA: 0x0000B0E0 File Offset: 0x000092E0
		// (set) Token: 0x06000544 RID: 1348 RVA: 0x0000B0E8 File Offset: 0x000092E8
		[DoNotSerialize]
		public ValueInput b { get; private set; }

		// Token: 0x17000206 RID: 518
		// (get) Token: 0x06000545 RID: 1349 RVA: 0x0000B0F1 File Offset: 0x000092F1
		// (set) Token: 0x06000546 RID: 1350 RVA: 0x0000B0F9 File Offset: 0x000092F9
		[DoNotSerialize]
		[PortLabel("A & B")]
		public ValueOutput result { get; private set; }

		// Token: 0x06000547 RID: 1351 RVA: 0x0000B104 File Offset: 0x00009304
		protected override void Definition()
		{
			this.a = base.ValueInput<bool>("a");
			this.b = base.ValueInput<bool>("b");
			this.result = base.ValueOutput<bool>("result", new Func<Flow, bool>(this.Operation)).Predictable();
			base.Requirement(this.a, this.result);
			base.Requirement(this.b, this.result);
		}

		// Token: 0x06000548 RID: 1352 RVA: 0x0000B179 File Offset: 0x00009379
		public bool Operation(Flow flow)
		{
			return flow.GetValue<bool>(this.a) && flow.GetValue<bool>(this.b);
		}
	}
}
