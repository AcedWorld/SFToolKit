using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200013E RID: 318
	[UnitSurtitle("Save")]
	public sealed class GetSavedVariable : GetVariableUnit, ISavedVariableUnit, IVariableUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
	{
		// Token: 0x0600086F RID: 2159 RVA: 0x0000FC12 File Offset: 0x0000DE12
		public GetSavedVariable()
		{
		}

		// Token: 0x06000870 RID: 2160 RVA: 0x0000FC1A File Offset: 0x0000DE1A
		public GetSavedVariable(string defaultName) : base(defaultName)
		{
		}

		// Token: 0x06000871 RID: 2161 RVA: 0x0000FC23 File Offset: 0x0000DE23
		protected override VariableDeclarations GetDeclarations(Flow flow)
		{
			return Variables.Saved;
		}

		// Token: 0x06000872 RID: 2162 RVA: 0x0000FC2A File Offset: 0x0000DE2A
		FlowGraph IUnit.get_graph()
		{
			return base.graph;
		}
	}
}
