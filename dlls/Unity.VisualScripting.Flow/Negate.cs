using System;

namespace Unity.VisualScripting
{
	// Token: 0x020000C0 RID: 192
	[UnitCategory("Logic")]
	[UnitOrder(3)]
	public sealed class Negate : Unit
	{
		// Token: 0x17000225 RID: 549
		// (get) Token: 0x060005B8 RID: 1464 RVA: 0x0000BC1E File Offset: 0x00009E1E
		// (set) Token: 0x060005B9 RID: 1465 RVA: 0x0000BC26 File Offset: 0x00009E26
		[DoNotSerialize]
		[PortLabel("X")]
		public ValueInput input { get; private set; }

		// Token: 0x17000226 RID: 550
		// (get) Token: 0x060005BA RID: 1466 RVA: 0x0000BC2F File Offset: 0x00009E2F
		// (set) Token: 0x060005BB RID: 1467 RVA: 0x0000BC37 File Offset: 0x00009E37
		[DoNotSerialize]
		[PortLabel("~X")]
		public ValueOutput output { get; private set; }

		// Token: 0x060005BC RID: 1468 RVA: 0x0000BC40 File Offset: 0x00009E40
		protected override void Definition()
		{
			this.input = base.ValueInput<bool>("input");
			this.output = base.ValueOutput<bool>("output", new Func<Flow, bool>(this.Operation)).Predictable();
			base.Requirement(this.input, this.output);
		}

		// Token: 0x060005BD RID: 1469 RVA: 0x0000BC92 File Offset: 0x00009E92
		public bool Operation(Flow flow)
		{
			return !flow.GetValue<bool>(this.input);
		}
	}
}
