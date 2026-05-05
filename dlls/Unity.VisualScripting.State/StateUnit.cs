using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200001A RID: 26
	[TypeIcon(typeof(StateGraph))]
	[UnitCategory("Nesting")]
	public sealed class StateUnit : NesterUnit<StateGraph, StateGraphAsset>
	{
		// Token: 0x060000A2 RID: 162 RVA: 0x000032AB File Offset: 0x000014AB
		public StateUnit()
		{
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x000032B3 File Offset: 0x000014B3
		public StateUnit(StateGraphAsset macro) : base(macro)
		{
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x060000A4 RID: 164 RVA: 0x000032BC File Offset: 0x000014BC
		// (set) Token: 0x060000A5 RID: 165 RVA: 0x000032C4 File Offset: 0x000014C4
		[DoNotSerialize]
		public ControlInput start { get; private set; }

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x060000A6 RID: 166 RVA: 0x000032CD File Offset: 0x000014CD
		// (set) Token: 0x060000A7 RID: 167 RVA: 0x000032D5 File Offset: 0x000014D5
		[DoNotSerialize]
		public ControlInput stop { get; private set; }

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x060000A8 RID: 168 RVA: 0x000032DE File Offset: 0x000014DE
		// (set) Token: 0x060000A9 RID: 169 RVA: 0x000032E6 File Offset: 0x000014E6
		[DoNotSerialize]
		public ControlOutput started { get; private set; }

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x060000AA RID: 170 RVA: 0x000032EF File Offset: 0x000014EF
		// (set) Token: 0x060000AB RID: 171 RVA: 0x000032F7 File Offset: 0x000014F7
		[DoNotSerialize]
		public ControlOutput stopped { get; private set; }

		// Token: 0x060000AC RID: 172 RVA: 0x00003300 File Offset: 0x00001500
		public static StateUnit WithStart()
		{
			return new StateUnit
			{
				nest = 
				{
					source = GraphSource.Embed
				},
				nest = 
				{
					embed = StateGraph.WithStart()
				}
			};
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00003324 File Offset: 0x00001524
		protected override void Definition()
		{
			this.start = base.ControlInput("start", new Func<Flow, ControlOutput>(this.Start));
			this.stop = base.ControlInput("stop", new Func<Flow, ControlOutput>(this.Stop));
			this.started = base.ControlOutput("started");
			this.stopped = base.ControlOutput("stopped");
			base.Succession(this.start, this.started);
			base.Succession(this.stop, this.stopped);
		}

		// Token: 0x060000AE RID: 174 RVA: 0x000033B1 File Offset: 0x000015B1
		private ControlOutput Start(Flow flow)
		{
			flow.stack.EnterParentElement(this);
			base.nest.graph.Start(flow);
			flow.stack.ExitParentElement();
			return this.started;
		}

		// Token: 0x060000AF RID: 175 RVA: 0x000033E1 File Offset: 0x000015E1
		private ControlOutput Stop(Flow flow)
		{
			flow.stack.EnterParentElement(this);
			base.nest.graph.Stop(flow);
			flow.stack.ExitParentElement();
			return this.stopped;
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x00003411 File Offset: 0x00001611
		public override StateGraph DefaultGraph()
		{
			return StateGraph.WithStart();
		}
	}
}
