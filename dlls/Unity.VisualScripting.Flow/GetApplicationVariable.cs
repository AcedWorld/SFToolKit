using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200013B RID: 315
	[UnitSurtitle("Application")]
	public sealed class GetApplicationVariable : GetVariableUnit, IApplicationVariableUnit, IVariableUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
	{
		// Token: 0x06000860 RID: 2144 RVA: 0x0000FB5E File Offset: 0x0000DD5E
		public GetApplicationVariable()
		{
		}

		// Token: 0x06000861 RID: 2145 RVA: 0x0000FB66 File Offset: 0x0000DD66
		public GetApplicationVariable(string defaultName) : base(defaultName)
		{
		}

		// Token: 0x06000862 RID: 2146 RVA: 0x0000FB6F File Offset: 0x0000DD6F
		protected override VariableDeclarations GetDeclarations(Flow flow)
		{
			return Variables.Application;
		}

		// Token: 0x06000863 RID: 2147 RVA: 0x0000FB76 File Offset: 0x0000DD76
		FlowGraph IUnit.get_graph()
		{
			return base.graph;
		}
	}
}
