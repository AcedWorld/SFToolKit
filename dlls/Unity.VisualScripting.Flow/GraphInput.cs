using System;
using System.Linq;

namespace Unity.VisualScripting
{
	// Token: 0x02000129 RID: 297
	[UnitCategory("Nesting")]
	[UnitOrder(1)]
	[UnitTitle("Input")]
	public sealed class GraphInput : Unit
	{
		// Token: 0x170002B2 RID: 690
		// (get) Token: 0x060007B4 RID: 1972 RVA: 0x0000E4B0 File Offset: 0x0000C6B0
		public override bool canDefine
		{
			get
			{
				return base.graph != null;
			}
		}

		// Token: 0x060007B5 RID: 1973 RVA: 0x0000E4BC File Offset: 0x0000C6BC
		protected override void Definition()
		{
			this.isControlRoot = true;
			foreach (ControlInputDefinition controlInputDefinition in base.graph.validPortDefinitions.OfType<ControlInputDefinition>())
			{
				base.ControlOutput(controlInputDefinition.key);
			}
			foreach (ValueInputDefinition valueInputDefinition in base.graph.validPortDefinitions.OfType<ValueInputDefinition>())
			{
				string key = valueInputDefinition.key;
				Type type = valueInputDefinition.type;
				base.ValueOutput(type, key, delegate(Flow flow)
				{
					SubgraphUnit parent = flow.stack.GetParent<SubgraphUnit>();
					if (flow.enableDebug)
					{
						IUnitDebugData elementDebugData = flow.stack.GetElementDebugData<IUnitDebugData>(parent);
						elementDebugData.lastInvokeFrame = EditorTimeBinding.frame;
						elementDebugData.lastInvokeTime = EditorTimeBinding.time;
					}
					flow.stack.ExitParentElement();
					parent.EnsureDefined();
					object value = flow.GetValue(parent.valueInputs[key], type);
					flow.stack.EnterParentElement(parent);
					return value;
				});
			}
		}

		// Token: 0x060007B6 RID: 1974 RVA: 0x0000E5A4 File Offset: 0x0000C7A4
		protected override void AfterDefine()
		{
			base.graph.onPortDefinitionsChanged += this.Define;
		}

		// Token: 0x060007B7 RID: 1975 RVA: 0x0000E5BE File Offset: 0x0000C7BE
		protected override void BeforeUndefine()
		{
			base.graph.onPortDefinitionsChanged -= this.Define;
		}
	}
}
