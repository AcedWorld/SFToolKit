using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000156 RID: 342
	[SpecialUnit]
	public abstract class UnifiedVariableUnit : Unit, IUnifiedVariableUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
	{
		// Token: 0x170002F7 RID: 759
		// (get) Token: 0x060008D9 RID: 2265 RVA: 0x0001045F File Offset: 0x0000E65F
		// (set) Token: 0x060008DA RID: 2266 RVA: 0x00010467 File Offset: 0x0000E667
		[Serialize]
		[Inspectable]
		[UnitHeaderInspectable]
		public VariableKind kind { get; set; }

		// Token: 0x170002F8 RID: 760
		// (get) Token: 0x060008DB RID: 2267 RVA: 0x00010470 File Offset: 0x0000E670
		// (set) Token: 0x060008DC RID: 2268 RVA: 0x00010478 File Offset: 0x0000E678
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueInput name { get; private set; }

		// Token: 0x170002F9 RID: 761
		// (get) Token: 0x060008DD RID: 2269 RVA: 0x00010481 File Offset: 0x0000E681
		// (set) Token: 0x060008DE RID: 2270 RVA: 0x00010489 File Offset: 0x0000E689
		[DoNotSerialize]
		[PortLabelHidden]
		[NullMeansSelf]
		public ValueInput @object { get; private set; }

		// Token: 0x060008DF RID: 2271 RVA: 0x00010492 File Offset: 0x0000E692
		protected override void Definition()
		{
			this.name = base.ValueInput<string>("name", string.Empty);
			if (this.kind == VariableKind.Object)
			{
				this.@object = base.ValueInput<GameObject>("object", null).NullMeansSelf();
			}
		}

		// Token: 0x060008E1 RID: 2273 RVA: 0x000104D2 File Offset: 0x0000E6D2
		FlowGraph IUnit.get_graph()
		{
			return base.graph;
		}
	}
}
