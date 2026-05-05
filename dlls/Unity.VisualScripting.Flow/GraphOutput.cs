using System;
using System.Linq;

namespace Unity.VisualScripting
{
	// Token: 0x0200012A RID: 298
	[UnitCategory("Nesting")]
	[UnitOrder(2)]
	[UnitTitle("Output")]
	public sealed class GraphOutput : Unit
	{
		// Token: 0x170002B3 RID: 691
		// (get) Token: 0x060007B9 RID: 1977 RVA: 0x0000E5E0 File Offset: 0x0000C7E0
		public override bool canDefine
		{
			get
			{
				return base.graph != null;
			}
		}

		// Token: 0x060007BA RID: 1978 RVA: 0x0000E5EC File Offset: 0x0000C7EC
		protected override void Definition()
		{
			this.isControlRoot = true;
			foreach (ControlOutputDefinition controlOutputDefinition in base.graph.validPortDefinitions.OfType<ControlOutputDefinition>())
			{
				string key = controlOutputDefinition.key;
				base.ControlInput(key, delegate(Flow flow)
				{
					SubgraphUnit parent = flow.stack.GetParent<SubgraphUnit>();
					flow.stack.ExitParentElement();
					parent.EnsureDefined();
					return parent.controlOutputs[key];
				});
			}
			foreach (ValueOutputDefinition valueOutputDefinition in base.graph.validPortDefinitions.OfType<ValueOutputDefinition>())
			{
				string key2 = valueOutputDefinition.key;
				Type type = valueOutputDefinition.type;
				base.ValueInput(type, key2);
			}
		}

		// Token: 0x060007BB RID: 1979 RVA: 0x0000E6C8 File Offset: 0x0000C8C8
		protected override void AfterDefine()
		{
			base.graph.onPortDefinitionsChanged += this.Define;
		}

		// Token: 0x060007BC RID: 1980 RVA: 0x0000E6E2 File Offset: 0x0000C8E2
		protected override void BeforeUndefine()
		{
			base.graph.onPortDefinitionsChanged -= this.Define;
		}
	}
}
