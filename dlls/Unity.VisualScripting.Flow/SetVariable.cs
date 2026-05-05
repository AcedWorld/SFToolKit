using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000155 RID: 341
	[UnitShortTitle("Set Variable")]
	public sealed class SetVariable : UnifiedVariableUnit
	{
		// Token: 0x170002F3 RID: 755
		// (get) Token: 0x060008CE RID: 2254 RVA: 0x00010267 File Offset: 0x0000E467
		// (set) Token: 0x060008CF RID: 2255 RVA: 0x0001026F File Offset: 0x0000E46F
		[DoNotSerialize]
		[PortLabelHidden]
		public ControlInput assign { get; set; }

		// Token: 0x170002F4 RID: 756
		// (get) Token: 0x060008D0 RID: 2256 RVA: 0x00010278 File Offset: 0x0000E478
		// (set) Token: 0x060008D1 RID: 2257 RVA: 0x00010280 File Offset: 0x0000E480
		[DoNotSerialize]
		[PortLabel("New Value")]
		[PortLabelHidden]
		public ValueInput input { get; private set; }

		// Token: 0x170002F5 RID: 757
		// (get) Token: 0x060008D2 RID: 2258 RVA: 0x00010289 File Offset: 0x0000E489
		// (set) Token: 0x060008D3 RID: 2259 RVA: 0x00010291 File Offset: 0x0000E491
		[DoNotSerialize]
		[PortLabelHidden]
		public ControlOutput assigned { get; set; }

		// Token: 0x170002F6 RID: 758
		// (get) Token: 0x060008D4 RID: 2260 RVA: 0x0001029A File Offset: 0x0000E49A
		// (set) Token: 0x060008D5 RID: 2261 RVA: 0x000102A2 File Offset: 0x0000E4A2
		[DoNotSerialize]
		[PortLabel("Value")]
		[PortLabelHidden]
		public ValueOutput output { get; private set; }

		// Token: 0x060008D6 RID: 2262 RVA: 0x000102AC File Offset: 0x0000E4AC
		protected override void Definition()
		{
			base.Definition();
			this.assign = base.ControlInput("assign", new Func<Flow, ControlOutput>(this.Assign));
			this.input = base.ValueInput<object>("input").AllowsNull();
			this.output = base.ValueOutput<object>("output");
			this.assigned = base.ControlOutput("assigned");
			base.Requirement(base.name, this.assign);
			base.Requirement(this.input, this.assign);
			base.Assignment(this.assign, this.output);
			base.Succession(this.assign, this.assigned);
			if (base.kind == VariableKind.Object)
			{
				base.Requirement(base.@object, this.assign);
			}
		}

		// Token: 0x060008D7 RID: 2263 RVA: 0x00010378 File Offset: 0x0000E578
		private ControlOutput Assign(Flow flow)
		{
			string value = flow.GetValue<string>(base.name);
			object value2 = flow.GetValue(this.input);
			switch (base.kind)
			{
			case VariableKind.Flow:
				flow.variables.Set(value, value2);
				break;
			case VariableKind.Graph:
				Variables.Graph(flow.stack).Set(value, value2);
				break;
			case VariableKind.Object:
				Variables.Object(flow.GetValue<GameObject>(base.@object)).Set(value, value2);
				break;
			case VariableKind.Scene:
				Variables.Scene(flow.stack.scene).Set(value, value2);
				break;
			case VariableKind.Application:
				Variables.Application.Set(value, value2);
				break;
			case VariableKind.Saved:
				Variables.Saved.Set(value, value2);
				break;
			default:
				throw new UnexpectedEnumValueException<VariableKind>(base.kind);
			}
			flow.SetValue(this.output, value2);
			return this.assigned;
		}
	}
}
