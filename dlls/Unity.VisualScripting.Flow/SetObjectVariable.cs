using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200014F RID: 335
	[UnitSurtitle("Object")]
	public sealed class SetObjectVariable : SetVariableUnit, IObjectVariableUnit, IVariableUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
	{
		// Token: 0x060008A4 RID: 2212 RVA: 0x0000FF3D File Offset: 0x0000E13D
		public SetObjectVariable()
		{
		}

		// Token: 0x060008A5 RID: 2213 RVA: 0x0000FF45 File Offset: 0x0000E145
		public SetObjectVariable(string name) : base(name)
		{
		}

		// Token: 0x170002EA RID: 746
		// (get) Token: 0x060008A6 RID: 2214 RVA: 0x0000FF4E File Offset: 0x0000E14E
		// (set) Token: 0x060008A7 RID: 2215 RVA: 0x0000FF56 File Offset: 0x0000E156
		[DoNotSerialize]
		[PortLabelHidden]
		[NullMeansSelf]
		public ValueInput source { get; private set; }

		// Token: 0x060008A8 RID: 2216 RVA: 0x0000FF5F File Offset: 0x0000E15F
		protected override void Definition()
		{
			this.source = base.ValueInput<GameObject>("source", null).NullMeansSelf();
			base.Definition();
			base.Requirement(this.source, base.assign);
		}

		// Token: 0x060008A9 RID: 2217 RVA: 0x0000FF90 File Offset: 0x0000E190
		protected override VariableDeclarations GetDeclarations(Flow flow)
		{
			return Variables.Object(flow.GetValue<GameObject>(this.source));
		}

		// Token: 0x060008AA RID: 2218 RVA: 0x0000FFA3 File Offset: 0x0000E1A3
		FlowGraph IUnit.get_graph()
		{
			return base.graph;
		}
	}
}
