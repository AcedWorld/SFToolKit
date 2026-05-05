using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000148 RID: 328
	[UnitSurtitle("Object")]
	public sealed class IsObjectVariableDefined : IsVariableDefinedUnit, IObjectVariableUnit, IVariableUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
	{
		// Token: 0x06000886 RID: 2182 RVA: 0x0000FD99 File Offset: 0x0000DF99
		public IsObjectVariableDefined()
		{
		}

		// Token: 0x06000887 RID: 2183 RVA: 0x0000FDA1 File Offset: 0x0000DFA1
		public IsObjectVariableDefined(string name) : base(name)
		{
		}

		// Token: 0x170002E7 RID: 743
		// (get) Token: 0x06000888 RID: 2184 RVA: 0x0000FDAA File Offset: 0x0000DFAA
		// (set) Token: 0x06000889 RID: 2185 RVA: 0x0000FDB2 File Offset: 0x0000DFB2
		[DoNotSerialize]
		[PortLabelHidden]
		[NullMeansSelf]
		public ValueInput source { get; private set; }

		// Token: 0x0600088A RID: 2186 RVA: 0x0000FDBB File Offset: 0x0000DFBB
		protected override void Definition()
		{
			this.source = base.ValueInput<GameObject>("source", null).NullMeansSelf();
			base.Definition();
			base.Requirement(this.source, base.isDefined);
		}

		// Token: 0x0600088B RID: 2187 RVA: 0x0000FDEC File Offset: 0x0000DFEC
		protected override VariableDeclarations GetDeclarations(Flow flow)
		{
			return Variables.Object(flow.GetValue<GameObject>(this.source));
		}

		// Token: 0x0600088C RID: 2188 RVA: 0x0000FDFF File Offset: 0x0000DFFF
		FlowGraph IUnit.get_graph()
		{
			return base.graph;
		}
	}
}
