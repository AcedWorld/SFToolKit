using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200013C RID: 316
	[UnitSurtitle("Graph")]
	public sealed class GetGraphVariable : GetVariableUnit, IGraphVariableUnit, IVariableUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
	{
		// Token: 0x06000864 RID: 2148 RVA: 0x0000FB7E File Offset: 0x0000DD7E
		public GetGraphVariable()
		{
		}

		// Token: 0x06000865 RID: 2149 RVA: 0x0000FB86 File Offset: 0x0000DD86
		public GetGraphVariable(string defaultName) : base(defaultName)
		{
		}

		// Token: 0x06000866 RID: 2150 RVA: 0x0000FB8F File Offset: 0x0000DD8F
		protected override VariableDeclarations GetDeclarations(Flow flow)
		{
			return Variables.Graph(flow.stack);
		}

		// Token: 0x06000867 RID: 2151 RVA: 0x0000FB9C File Offset: 0x0000DD9C
		FlowGraph IUnit.get_graph()
		{
			return base.graph;
		}
	}
}
