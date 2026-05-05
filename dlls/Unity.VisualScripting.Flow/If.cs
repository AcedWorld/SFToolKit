using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200003A RID: 58
	[UnitCategory("Control")]
	[UnitOrder(0)]
	[RenamedFrom("Bolt.Branch")]
	[RenamedFrom("Unity.VisualScripting.Branch")]
	public sealed class If : Unit, IBranchUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
	{
		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x06000239 RID: 569 RVA: 0x00006DB6 File Offset: 0x00004FB6
		// (set) Token: 0x0600023A RID: 570 RVA: 0x00006DBE File Offset: 0x00004FBE
		[DoNotSerialize]
		[PortLabelHidden]
		public ControlInput enter { get; private set; }

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x0600023B RID: 571 RVA: 0x00006DC7 File Offset: 0x00004FC7
		// (set) Token: 0x0600023C RID: 572 RVA: 0x00006DCF File Offset: 0x00004FCF
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueInput condition { get; private set; }

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x0600023D RID: 573 RVA: 0x00006DD8 File Offset: 0x00004FD8
		// (set) Token: 0x0600023E RID: 574 RVA: 0x00006DE0 File Offset: 0x00004FE0
		[DoNotSerialize]
		[PortLabel("True")]
		public ControlOutput ifTrue { get; private set; }

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x0600023F RID: 575 RVA: 0x00006DE9 File Offset: 0x00004FE9
		// (set) Token: 0x06000240 RID: 576 RVA: 0x00006DF1 File Offset: 0x00004FF1
		[DoNotSerialize]
		[PortLabel("False")]
		public ControlOutput ifFalse { get; private set; }

		// Token: 0x06000241 RID: 577 RVA: 0x00006DFC File Offset: 0x00004FFC
		protected override void Definition()
		{
			this.enter = base.ControlInput("enter", new Func<Flow, ControlOutput>(this.Enter));
			this.condition = base.ValueInput<bool>("condition");
			this.ifTrue = base.ControlOutput("ifTrue");
			this.ifFalse = base.ControlOutput("ifFalse");
			base.Requirement(this.condition, this.enter);
			base.Succession(this.enter, this.ifTrue);
			base.Succession(this.enter, this.ifFalse);
		}

		// Token: 0x06000242 RID: 578 RVA: 0x00006E8F File Offset: 0x0000508F
		public ControlOutput Enter(Flow flow)
		{
			if (!flow.GetValue<bool>(this.condition))
			{
				return this.ifFalse;
			}
			return this.ifTrue;
		}

		// Token: 0x06000244 RID: 580 RVA: 0x00006EB4 File Offset: 0x000050B4
		FlowGraph IUnit.get_graph()
		{
			return base.graph;
		}
	}
}
