using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000036 RID: 54
	[UnitCategory("Control")]
	[UnitOrder(15)]
	public sealed class Cache : Unit
	{
		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x0600020D RID: 525 RVA: 0x000067AD File Offset: 0x000049AD
		// (set) Token: 0x0600020E RID: 526 RVA: 0x000067B5 File Offset: 0x000049B5
		[DoNotSerialize]
		[PortLabelHidden]
		public ControlInput enter { get; private set; }

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x0600020F RID: 527 RVA: 0x000067BE File Offset: 0x000049BE
		// (set) Token: 0x06000210 RID: 528 RVA: 0x000067C6 File Offset: 0x000049C6
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueInput input { get; private set; }

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x06000211 RID: 529 RVA: 0x000067CF File Offset: 0x000049CF
		// (set) Token: 0x06000212 RID: 530 RVA: 0x000067D7 File Offset: 0x000049D7
		[DoNotSerialize]
		[PortLabel("Cached")]
		[PortLabelHidden]
		public ValueOutput output { get; private set; }

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x06000213 RID: 531 RVA: 0x000067E0 File Offset: 0x000049E0
		// (set) Token: 0x06000214 RID: 532 RVA: 0x000067E8 File Offset: 0x000049E8
		[DoNotSerialize]
		[PortLabelHidden]
		public ControlOutput exit { get; private set; }

		// Token: 0x06000215 RID: 533 RVA: 0x000067F4 File Offset: 0x000049F4
		protected override void Definition()
		{
			this.enter = base.ControlInput("enter", new Func<Flow, ControlOutput>(this.Store));
			this.input = base.ValueInput<object>("input");
			this.output = base.ValueOutput<object>("output");
			this.exit = base.ControlOutput("exit");
			base.Requirement(this.input, this.enter);
			base.Assignment(this.enter, this.output);
			base.Succession(this.enter, this.exit);
		}

		// Token: 0x06000216 RID: 534 RVA: 0x00006887 File Offset: 0x00004A87
		private ControlOutput Store(Flow flow)
		{
			flow.SetValue(this.output, flow.GetValue(this.input));
			return this.exit;
		}
	}
}
