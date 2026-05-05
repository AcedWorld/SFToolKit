using System;

namespace Unity.VisualScripting
{
	// Token: 0x020000BB RID: 187
	[UnitCategory("Logic")]
	[UnitOrder(2)]
	public sealed class ExclusiveOr : Unit
	{
		// Token: 0x1700021E RID: 542
		// (get) Token: 0x0600059F RID: 1439 RVA: 0x0000BAC3 File Offset: 0x00009CC3
		// (set) Token: 0x060005A0 RID: 1440 RVA: 0x0000BACB File Offset: 0x00009CCB
		[DoNotSerialize]
		public ValueInput a { get; private set; }

		// Token: 0x1700021F RID: 543
		// (get) Token: 0x060005A1 RID: 1441 RVA: 0x0000BAD4 File Offset: 0x00009CD4
		// (set) Token: 0x060005A2 RID: 1442 RVA: 0x0000BADC File Offset: 0x00009CDC
		[DoNotSerialize]
		public ValueInput b { get; private set; }

		// Token: 0x17000220 RID: 544
		// (get) Token: 0x060005A3 RID: 1443 RVA: 0x0000BAE5 File Offset: 0x00009CE5
		// (set) Token: 0x060005A4 RID: 1444 RVA: 0x0000BAED File Offset: 0x00009CED
		[DoNotSerialize]
		[PortLabel("A ⊕ B")]
		public ValueOutput result { get; private set; }

		// Token: 0x060005A5 RID: 1445 RVA: 0x0000BAF8 File Offset: 0x00009CF8
		protected override void Definition()
		{
			this.a = base.ValueInput<bool>("a");
			this.b = base.ValueInput<bool>("b");
			this.result = base.ValueOutput<bool>("result", new Func<Flow, bool>(this.Operation)).Predictable();
			base.Requirement(this.a, this.result);
			base.Requirement(this.b, this.result);
		}

		// Token: 0x060005A6 RID: 1446 RVA: 0x0000BB6D File Offset: 0x00009D6D
		public bool Operation(Flow flow)
		{
			return flow.GetValue<bool>(this.a) ^ flow.GetValue<bool>(this.b);
		}
	}
}
