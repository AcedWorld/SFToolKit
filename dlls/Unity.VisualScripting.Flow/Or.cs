using System;

namespace Unity.VisualScripting
{
	// Token: 0x020000C4 RID: 196
	[UnitCategory("Logic")]
	[UnitOrder(1)]
	public sealed class Or : Unit
	{
		// Token: 0x17000233 RID: 563
		// (get) Token: 0x060005E2 RID: 1506 RVA: 0x0000C08C File Offset: 0x0000A28C
		// (set) Token: 0x060005E3 RID: 1507 RVA: 0x0000C094 File Offset: 0x0000A294
		[DoNotSerialize]
		public ValueInput a { get; private set; }

		// Token: 0x17000234 RID: 564
		// (get) Token: 0x060005E4 RID: 1508 RVA: 0x0000C09D File Offset: 0x0000A29D
		// (set) Token: 0x060005E5 RID: 1509 RVA: 0x0000C0A5 File Offset: 0x0000A2A5
		[DoNotSerialize]
		public ValueInput b { get; private set; }

		// Token: 0x17000235 RID: 565
		// (get) Token: 0x060005E6 RID: 1510 RVA: 0x0000C0AE File Offset: 0x0000A2AE
		// (set) Token: 0x060005E7 RID: 1511 RVA: 0x0000C0B6 File Offset: 0x0000A2B6
		[DoNotSerialize]
		[PortLabel("A | B")]
		public ValueOutput result { get; private set; }

		// Token: 0x060005E8 RID: 1512 RVA: 0x0000C0C0 File Offset: 0x0000A2C0
		protected override void Definition()
		{
			this.a = base.ValueInput<bool>("a");
			this.b = base.ValueInput<bool>("b");
			this.result = base.ValueOutput<bool>("result", new Func<Flow, bool>(this.Operation)).Predictable();
			base.Requirement(this.a, this.result);
			base.Requirement(this.b, this.result);
		}

		// Token: 0x060005E9 RID: 1513 RVA: 0x0000C135 File Offset: 0x0000A335
		public bool Operation(Flow flow)
		{
			return flow.GetValue<bool>(this.a) || flow.GetValue<bool>(this.b);
		}
	}
}
