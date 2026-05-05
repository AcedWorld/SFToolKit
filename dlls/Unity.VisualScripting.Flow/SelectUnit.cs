using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000042 RID: 66
	[UnitCategory("Control")]
	[UnitTitle("Select")]
	[TypeIcon(typeof(ISelectUnit))]
	[UnitOrder(6)]
	public sealed class SelectUnit : Unit, ISelectUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
	{
		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x0600027B RID: 635 RVA: 0x000073DE File Offset: 0x000055DE
		// (set) Token: 0x0600027C RID: 636 RVA: 0x000073E6 File Offset: 0x000055E6
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueInput condition { get; private set; }

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x0600027D RID: 637 RVA: 0x000073EF File Offset: 0x000055EF
		// (set) Token: 0x0600027E RID: 638 RVA: 0x000073F7 File Offset: 0x000055F7
		[DoNotSerialize]
		[PortLabel("True")]
		public ValueInput ifTrue { get; private set; }

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x0600027F RID: 639 RVA: 0x00007400 File Offset: 0x00005600
		// (set) Token: 0x06000280 RID: 640 RVA: 0x00007408 File Offset: 0x00005608
		[DoNotSerialize]
		[PortLabel("False")]
		public ValueInput ifFalse { get; private set; }

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x06000281 RID: 641 RVA: 0x00007411 File Offset: 0x00005611
		// (set) Token: 0x06000282 RID: 642 RVA: 0x00007419 File Offset: 0x00005619
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueOutput selection { get; private set; }

		// Token: 0x06000283 RID: 643 RVA: 0x00007424 File Offset: 0x00005624
		protected override void Definition()
		{
			this.condition = base.ValueInput<bool>("condition");
			this.ifTrue = base.ValueInput<object>("ifTrue").AllowsNull();
			this.ifFalse = base.ValueInput<object>("ifFalse").AllowsNull();
			this.selection = base.ValueOutput<object>("selection", new Func<Flow, object>(this.Branch)).Predictable();
			base.Requirement(this.condition, this.selection);
			base.Requirement(this.ifTrue, this.selection);
			base.Requirement(this.ifFalse, this.selection);
		}

		// Token: 0x06000284 RID: 644 RVA: 0x000074C6 File Offset: 0x000056C6
		public object Branch(Flow flow)
		{
			return flow.GetValue(flow.GetValue<bool>(this.condition) ? this.ifTrue : this.ifFalse);
		}

		// Token: 0x06000286 RID: 646 RVA: 0x000074F2 File Offset: 0x000056F2
		FlowGraph IUnit.get_graph()
		{
			return base.graph;
		}
	}
}
