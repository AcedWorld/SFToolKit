using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000139 RID: 313
	[UnitTitle("Has Variable")]
	public sealed class IsVariableDefined : UnifiedVariableUnit
	{
		// Token: 0x170002E2 RID: 738
		// (get) Token: 0x06000859 RID: 2137 RVA: 0x0000FA30 File Offset: 0x0000DC30
		// (set) Token: 0x0600085A RID: 2138 RVA: 0x0000FA38 File Offset: 0x0000DC38
		[DoNotSerialize]
		[PortLabel("Defined")]
		[PortLabelHidden]
		[PortKey("isDefined")]
		public ValueOutput isVariableDefined { get; private set; }

		// Token: 0x0600085B RID: 2139 RVA: 0x0000FA44 File Offset: 0x0000DC44
		protected override void Definition()
		{
			base.Definition();
			this.isVariableDefined = base.ValueOutput<bool>("isDefined", new Func<Flow, bool>(this.IsDefined));
			base.Requirement(base.name, this.isVariableDefined);
			if (base.kind == VariableKind.Object)
			{
				base.Requirement(base.@object, this.isVariableDefined);
			}
		}

		// Token: 0x0600085C RID: 2140 RVA: 0x0000FAA4 File Offset: 0x0000DCA4
		private bool IsDefined(Flow flow)
		{
			string value = flow.GetValue<string>(base.name);
			switch (base.kind)
			{
			case VariableKind.Flow:
				return flow.variables.IsDefined(value);
			case VariableKind.Graph:
				return Variables.Graph(flow.stack).IsDefined(value);
			case VariableKind.Object:
				return Variables.Object(flow.GetValue<GameObject>(base.@object)).IsDefined(value);
			case VariableKind.Scene:
				return Variables.Scene(flow.stack.scene).IsDefined(value);
			case VariableKind.Application:
				return Variables.Application.IsDefined(value);
			case VariableKind.Saved:
				return Variables.Saved.IsDefined(value);
			default:
				throw new UnexpectedEnumValueException<VariableKind>(base.kind);
			}
		}
	}
}
