using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x020000AF RID: 175
	[UnitCategory("Graphs/Graph Nodes")]
	public abstract class HasGraph<TGraph, TMacro, TMachine> : Unit where TGraph : class, IGraph, new() where TMacro : Macro<TGraph> where TMachine : Machine<TGraph, TMacro>
	{
		// Token: 0x170001EE RID: 494
		// (get) Token: 0x0600050D RID: 1293 RVA: 0x0000AB26 File Offset: 0x00008D26
		// (set) Token: 0x0600050E RID: 1294 RVA: 0x0000AB2E File Offset: 0x00008D2E
		[DoNotSerialize]
		[PortLabelHidden]
		public ControlInput enter { get; private set; }

		// Token: 0x170001EF RID: 495
		// (get) Token: 0x0600050F RID: 1295 RVA: 0x0000AB37 File Offset: 0x00008D37
		// (set) Token: 0x06000510 RID: 1296 RVA: 0x0000AB3F File Offset: 0x00008D3F
		[DoNotSerialize]
		[PortLabelHidden]
		[NullMeansSelf]
		public ValueInput target { get; private set; }

		// Token: 0x170001F0 RID: 496
		// (get) Token: 0x06000511 RID: 1297 RVA: 0x0000AB48 File Offset: 0x00008D48
		// (set) Token: 0x06000512 RID: 1298 RVA: 0x0000AB50 File Offset: 0x00008D50
		[DoNotSerialize]
		[PortLabel("Graph")]
		[PortLabelHidden]
		public ValueInput graphInput { get; private set; }

		// Token: 0x170001F1 RID: 497
		// (get) Token: 0x06000513 RID: 1299 RVA: 0x0000AB59 File Offset: 0x00008D59
		// (set) Token: 0x06000514 RID: 1300 RVA: 0x0000AB61 File Offset: 0x00008D61
		[DoNotSerialize]
		[PortLabel("Has Graph")]
		[PortLabelHidden]
		public ValueOutput hasGraphOutput { get; private set; }

		// Token: 0x170001F2 RID: 498
		// (get) Token: 0x06000515 RID: 1301 RVA: 0x0000AB6A File Offset: 0x00008D6A
		// (set) Token: 0x06000516 RID: 1302 RVA: 0x0000AB72 File Offset: 0x00008D72
		[DoNotSerialize]
		[PortLabelHidden]
		public ControlOutput exit { get; private set; }

		// Token: 0x170001F3 RID: 499
		// (get) Token: 0x06000517 RID: 1303
		protected abstract bool isGameObject { get; }

		// Token: 0x170001F4 RID: 500
		// (get) Token: 0x06000518 RID: 1304 RVA: 0x0000AB7B File Offset: 0x00008D7B
		private Type targetType
		{
			get
			{
				if (!this.isGameObject)
				{
					return typeof(TMachine);
				}
				return typeof(GameObject);
			}
		}

		// Token: 0x06000519 RID: 1305 RVA: 0x0000AB9C File Offset: 0x00008D9C
		protected override void Definition()
		{
			this.enter = base.ControlInput("enter", new Func<Flow, ControlOutput>(this.TriggerHasGraph));
			this.target = base.ValueInput(this.targetType, "target").NullMeansSelf();
			this.target.SetDefaultValue(this.targetType.PseudoDefault());
			this.graphInput = base.ValueInput<TMacro>("graphInput", default(TMacro));
			this.hasGraphOutput = base.ValueOutput<bool>("hasGraphOutput", new Func<Flow, bool>(this.OutputHasGraph));
			this.exit = base.ControlOutput("exit");
			base.Requirement(this.graphInput, this.enter);
			base.Assignment(this.enter, this.hasGraphOutput);
			base.Succession(this.enter, this.exit);
		}

		// Token: 0x0600051A RID: 1306 RVA: 0x0000AC76 File Offset: 0x00008E76
		private ControlOutput TriggerHasGraph(Flow flow)
		{
			flow.SetValue(this.hasGraphOutput, this.OutputHasGraph(flow));
			return this.exit;
		}

		// Token: 0x0600051B RID: 1307 RVA: 0x0000AC98 File Offset: 0x00008E98
		private bool OutputHasGraph(Flow flow)
		{
			TMacro macro = flow.GetValue<TMacro>(this.graphInput);
			GameObject gameObject = flow.GetValue(this.target, this.targetType) as GameObject;
			if (gameObject != null)
			{
				if (gameObject != null)
				{
					IEnumerable<TMachine> components = gameObject.GetComponents<TMachine>();
					macro = flow.GetValue<TMacro>(this.graphInput);
					return (from currentMachine in components
					where currentMachine != null
					select currentMachine).Any((TMachine currentMachine) => currentMachine.graph != null && currentMachine.graph.Equals(macro.graph));
				}
			}
			else
			{
				TMachine value = flow.GetValue<TMachine>(this.target);
				if (value.graph != null && value.graph.Equals(macro.graph))
				{
					return true;
				}
			}
			return false;
		}
	}
}
