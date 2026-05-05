using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000147 RID: 327
	[UnitSurtitle("Graph")]
	public sealed class IsGraphVariableDefined : IsVariableDefinedUnit, IGraphVariableUnit, IVariableUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
	{
		// Token: 0x06000882 RID: 2178 RVA: 0x0000FD73 File Offset: 0x0000DF73
		public IsGraphVariableDefined()
		{
		}

		// Token: 0x06000883 RID: 2179 RVA: 0x0000FD7B File Offset: 0x0000DF7B
		public IsGraphVariableDefined(string defaultName) : base(defaultName)
		{
		}

		// Token: 0x06000884 RID: 2180 RVA: 0x0000FD84 File Offset: 0x0000DF84
		protected override VariableDeclarations GetDeclarations(Flow flow)
		{
			return Variables.Graph(flow.stack);
		}

		// Token: 0x06000885 RID: 2181 RVA: 0x0000FD91 File Offset: 0x0000DF91
		FlowGraph IUnit.get_graph()
		{
			return base.graph;
		}
	}
}
