using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000149 RID: 329
	[UnitSurtitle("Save")]
	public sealed class IsSavedVariableDefined : IsVariableDefinedUnit, ISavedVariableUnit, IVariableUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
	{
		// Token: 0x0600088D RID: 2189 RVA: 0x0000FE07 File Offset: 0x0000E007
		public IsSavedVariableDefined()
		{
		}

		// Token: 0x0600088E RID: 2190 RVA: 0x0000FE0F File Offset: 0x0000E00F
		public IsSavedVariableDefined(string defaultName) : base(defaultName)
		{
		}

		// Token: 0x0600088F RID: 2191 RVA: 0x0000FE18 File Offset: 0x0000E018
		protected override VariableDeclarations GetDeclarations(Flow flow)
		{
			return Variables.Saved;
		}

		// Token: 0x06000890 RID: 2192 RVA: 0x0000FE1F File Offset: 0x0000E01F
		FlowGraph IUnit.get_graph()
		{
			return base.graph;
		}
	}
}
