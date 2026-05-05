using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x020000B2 RID: 178
	[UnitCategory("Graphs/Graph Nodes")]
	public abstract class SetGraph<TGraph, TMacro, TMachine> : Unit where TGraph : class, IGraph, new() where TMacro : Macro<TGraph> where TMachine : Machine<TGraph, TMacro>
	{
		// Token: 0x170001F7 RID: 503
		// (get) Token: 0x06000521 RID: 1313 RVA: 0x0000ADAC File Offset: 0x00008FAC
		// (set) Token: 0x06000522 RID: 1314 RVA: 0x0000ADB4 File Offset: 0x00008FB4
		[DoNotSerialize]
		[PortLabelHidden]
		public ControlInput enter { get; protected set; }

		// Token: 0x170001F8 RID: 504
		// (get) Token: 0x06000523 RID: 1315 RVA: 0x0000ADBD File Offset: 0x00008FBD
		// (set) Token: 0x06000524 RID: 1316 RVA: 0x0000ADC5 File Offset: 0x00008FC5
		[DoNotSerialize]
		[PortLabelHidden]
		[NullMeansSelf]
		public ValueInput target { get; protected set; }

		// Token: 0x170001F9 RID: 505
		// (get) Token: 0x06000525 RID: 1317 RVA: 0x0000ADCE File Offset: 0x00008FCE
		// (set) Token: 0x06000526 RID: 1318 RVA: 0x0000ADD6 File Offset: 0x00008FD6
		[DoNotSerialize]
		[PortLabel("Graph")]
		[PortLabelHidden]
		public ValueInput graphInput { get; protected set; }

		// Token: 0x170001FA RID: 506
		// (get) Token: 0x06000527 RID: 1319 RVA: 0x0000ADDF File Offset: 0x00008FDF
		// (set) Token: 0x06000528 RID: 1320 RVA: 0x0000ADE7 File Offset: 0x00008FE7
		[DoNotSerialize]
		[PortLabel("Graph")]
		[PortLabelHidden]
		public ValueOutput graphOutput { get; protected set; }

		// Token: 0x170001FB RID: 507
		// (get) Token: 0x06000529 RID: 1321 RVA: 0x0000ADF0 File Offset: 0x00008FF0
		// (set) Token: 0x0600052A RID: 1322 RVA: 0x0000ADF8 File Offset: 0x00008FF8
		[DoNotSerialize]
		[PortLabelHidden]
		public ControlOutput exit { get; protected set; }

		// Token: 0x170001FC RID: 508
		// (get) Token: 0x0600052B RID: 1323
		protected abstract bool isGameObject { get; }

		// Token: 0x170001FD RID: 509
		// (get) Token: 0x0600052C RID: 1324 RVA: 0x0000AE01 File Offset: 0x00009001
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

		// Token: 0x0600052D RID: 1325 RVA: 0x0000AE20 File Offset: 0x00009020
		protected override void Definition()
		{
			this.enter = base.ControlInput("enter", new Func<Flow, ControlOutput>(this.SetMacro));
			this.target = base.ValueInput(this.targetType, "target").NullMeansSelf();
			this.target.SetDefaultValue(this.targetType.PseudoDefault());
			this.graphInput = base.ValueInput<TMacro>("graphInput", default(TMacro));
			this.graphOutput = base.ValueOutput<TMacro>("graphOutput");
			this.exit = base.ControlOutput("exit");
			base.Requirement(this.graphInput, this.enter);
			base.Assignment(this.enter, this.graphOutput);
			base.Succession(this.enter, this.exit);
		}

		// Token: 0x0600052E RID: 1326 RVA: 0x0000AEF0 File Offset: 0x000090F0
		private ControlOutput SetMacro(Flow flow)
		{
			TMacro value = flow.GetValue<TMacro>(this.graphInput);
			object value2 = flow.GetValue(this.target, this.targetType);
			GameObject gameObject = value2 as GameObject;
			if (gameObject != null)
			{
				gameObject.GetComponent<TMachine>().nest.SwitchToMacro(value);
			}
			else
			{
				((TMachine)((object)value2)).nest.SwitchToMacro(value);
			}
			flow.SetValue(this.graphOutput, value);
			return this.exit;
		}
	}
}
