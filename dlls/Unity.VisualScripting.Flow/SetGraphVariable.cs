using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200014E RID: 334
	[UnitSurtitle("Graph")]
	public sealed class SetGraphVariable : SetVariableUnit, IGraphVariableUnit, IVariableUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
	{
		// Token: 0x060008A0 RID: 2208 RVA: 0x0000FF17 File Offset: 0x0000E117
		public SetGraphVariable()
		{
		}

		// Token: 0x060008A1 RID: 2209 RVA: 0x0000FF1F File Offset: 0x0000E11F
		public SetGraphVariable(string defaultName) : base(defaultName)
		{
		}

		// Token: 0x060008A2 RID: 2210 RVA: 0x0000FF28 File Offset: 0x0000E128
		protected override VariableDeclarations GetDeclarations(Flow flow)
		{
			return Variables.Graph(flow.stack);
		}

		// Token: 0x060008A3 RID: 2211 RVA: 0x0000FF35 File Offset: 0x0000E135
		FlowGraph IUnit.get_graph()
		{
			return base.graph;
		}
	}
}
