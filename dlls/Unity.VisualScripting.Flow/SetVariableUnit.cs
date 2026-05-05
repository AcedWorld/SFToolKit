using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000152 RID: 338
	[UnitShortTitle("Set Variable")]
	public abstract class SetVariableUnit : VariableUnit
	{
		// Token: 0x060008B3 RID: 2227 RVA: 0x00010019 File Offset: 0x0000E219
		protected SetVariableUnit()
		{
		}

		// Token: 0x060008B4 RID: 2228 RVA: 0x00010021 File Offset: 0x0000E221
		protected SetVariableUnit(string defaultName) : base(defaultName)
		{
		}

		// Token: 0x170002EB RID: 747
		// (get) Token: 0x060008B5 RID: 2229 RVA: 0x0001002A File Offset: 0x0000E22A
		// (set) Token: 0x060008B6 RID: 2230 RVA: 0x00010032 File Offset: 0x0000E232
		[DoNotSerialize]
		[PortLabelHidden]
		public ControlInput assign { get; set; }

		// Token: 0x170002EC RID: 748
		// (get) Token: 0x060008B7 RID: 2231 RVA: 0x0001003B File Offset: 0x0000E23B
		// (set) Token: 0x060008B8 RID: 2232 RVA: 0x00010043 File Offset: 0x0000E243
		[DoNotSerialize]
		[PortLabel("New Value")]
		[PortLabelHidden]
		public ValueInput input { get; private set; }

		// Token: 0x170002ED RID: 749
		// (get) Token: 0x060008B9 RID: 2233 RVA: 0x0001004C File Offset: 0x0000E24C
		// (set) Token: 0x060008BA RID: 2234 RVA: 0x00010054 File Offset: 0x0000E254
		[DoNotSerialize]
		[PortLabelHidden]
		public ControlOutput assigned { get; set; }

		// Token: 0x170002EE RID: 750
		// (get) Token: 0x060008BB RID: 2235 RVA: 0x0001005D File Offset: 0x0000E25D
		// (set) Token: 0x060008BC RID: 2236 RVA: 0x00010065 File Offset: 0x0000E265
		[DoNotSerialize]
		[PortLabel("Value")]
		[PortLabelHidden]
		public ValueOutput output { get; private set; }

		// Token: 0x060008BD RID: 2237 RVA: 0x00010070 File Offset: 0x0000E270
		protected override void Definition()
		{
			base.Definition();
			this.assign = base.ControlInput("assign", new Func<Flow, ControlOutput>(this.Assign));
			this.input = base.ValueInput<object>("input");
			this.output = base.ValueOutput<object>("output");
			this.assigned = base.ControlOutput("assigned");
			base.Requirement(this.input, this.assign);
			base.Requirement(base.name, this.assign);
			base.Assignment(this.assign, this.output);
			base.Succession(this.assign, this.assigned);
		}

		// Token: 0x060008BE RID: 2238 RVA: 0x0001011C File Offset: 0x0000E31C
		protected virtual ControlOutput Assign(Flow flow)
		{
			object value = flow.GetValue<object>(this.input);
			string value2 = flow.GetValue<string>(base.name);
			this.GetDeclarations(flow).Set(value2, value);
			flow.SetValue(this.output, value);
			return this.assigned;
		}
	}
}
