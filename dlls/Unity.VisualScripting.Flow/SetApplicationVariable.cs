using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200014D RID: 333
	[UnitSurtitle("Application")]
	public sealed class SetApplicationVariable : SetVariableUnit, IApplicationVariableUnit, IVariableUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
	{
		// Token: 0x0600089C RID: 2204 RVA: 0x0000FEF7 File Offset: 0x0000E0F7
		public SetApplicationVariable()
		{
		}

		// Token: 0x0600089D RID: 2205 RVA: 0x0000FEFF File Offset: 0x0000E0FF
		public SetApplicationVariable(string defaultName) : base(defaultName)
		{
		}

		// Token: 0x0600089E RID: 2206 RVA: 0x0000FF08 File Offset: 0x0000E108
		protected override VariableDeclarations GetDeclarations(Flow flow)
		{
			return Variables.Application;
		}

		// Token: 0x0600089F RID: 2207 RVA: 0x0000FF0F File Offset: 0x0000E10F
		FlowGraph IUnit.get_graph()
		{
			return base.graph;
		}
	}
}
