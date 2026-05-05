using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000150 RID: 336
	[UnitSurtitle("Save")]
	public sealed class SetSavedVariable : SetVariableUnit, ISavedVariableUnit, IVariableUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
	{
		// Token: 0x060008AB RID: 2219 RVA: 0x0000FFAB File Offset: 0x0000E1AB
		public SetSavedVariable()
		{
		}

		// Token: 0x060008AC RID: 2220 RVA: 0x0000FFB3 File Offset: 0x0000E1B3
		public SetSavedVariable(string defaultName) : base(defaultName)
		{
		}

		// Token: 0x060008AD RID: 2221 RVA: 0x0000FFBC File Offset: 0x0000E1BC
		protected override VariableDeclarations GetDeclarations(Flow flow)
		{
			return Variables.Saved;
		}

		// Token: 0x060008AE RID: 2222 RVA: 0x0000FFC3 File Offset: 0x0000E1C3
		FlowGraph IUnit.get_graph()
		{
			return base.graph;
		}
	}
}
