using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200013D RID: 317
	[UnitSurtitle("Object")]
	public sealed class GetObjectVariable : GetVariableUnit, IObjectVariableUnit, IVariableUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
	{
		// Token: 0x06000868 RID: 2152 RVA: 0x0000FBA4 File Offset: 0x0000DDA4
		public GetObjectVariable()
		{
		}

		// Token: 0x06000869 RID: 2153 RVA: 0x0000FBAC File Offset: 0x0000DDAC
		public GetObjectVariable(string name) : base(name)
		{
		}

		// Token: 0x170002E5 RID: 741
		// (get) Token: 0x0600086A RID: 2154 RVA: 0x0000FBB5 File Offset: 0x0000DDB5
		// (set) Token: 0x0600086B RID: 2155 RVA: 0x0000FBBD File Offset: 0x0000DDBD
		[DoNotSerialize]
		[PortLabelHidden]
		[NullMeansSelf]
		public ValueInput source { get; private set; }

		// Token: 0x0600086C RID: 2156 RVA: 0x0000FBC6 File Offset: 0x0000DDC6
		protected override void Definition()
		{
			this.source = base.ValueInput<GameObject>("source", null).NullMeansSelf();
			base.Definition();
			base.Requirement(this.source, base.value);
		}

		// Token: 0x0600086D RID: 2157 RVA: 0x0000FBF7 File Offset: 0x0000DDF7
		protected override VariableDeclarations GetDeclarations(Flow flow)
		{
			return Variables.Object(flow.GetValue<GameObject>(this.source));
		}

		// Token: 0x0600086E RID: 2158 RVA: 0x0000FC0A File Offset: 0x0000DE0A
		FlowGraph IUnit.get_graph()
		{
			return base.graph;
		}
	}
}
