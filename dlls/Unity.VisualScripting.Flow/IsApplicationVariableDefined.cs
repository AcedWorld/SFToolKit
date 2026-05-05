using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000144 RID: 324
	[UnitSurtitle("Application")]
	public sealed class IsApplicationVariableDefined : IsVariableDefinedUnit, IApplicationVariableUnit, IVariableUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
	{
		// Token: 0x0600087E RID: 2174 RVA: 0x0000FD53 File Offset: 0x0000DF53
		public IsApplicationVariableDefined()
		{
		}

		// Token: 0x0600087F RID: 2175 RVA: 0x0000FD5B File Offset: 0x0000DF5B
		public IsApplicationVariableDefined(string defaultName) : base(defaultName)
		{
		}

		// Token: 0x06000880 RID: 2176 RVA: 0x0000FD64 File Offset: 0x0000DF64
		protected override VariableDeclarations GetDeclarations(Flow flow)
		{
			return Variables.Application;
		}

		// Token: 0x06000881 RID: 2177 RVA: 0x0000FD6B File Offset: 0x0000DF6B
		FlowGraph IUnit.get_graph()
		{
			return base.graph;
		}
	}
}
