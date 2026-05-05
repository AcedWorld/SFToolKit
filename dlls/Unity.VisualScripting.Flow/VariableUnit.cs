using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000153 RID: 339
	[SpecialUnit]
	[Obsolete("Use the new unified variable nodes instead.")]
	public abstract class VariableUnit : Unit, IVariableUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
	{
		// Token: 0x060008BF RID: 2239 RVA: 0x00010164 File Offset: 0x0000E364
		protected VariableUnit()
		{
		}

		// Token: 0x060008C0 RID: 2240 RVA: 0x00010177 File Offset: 0x0000E377
		protected VariableUnit(string defaultName)
		{
			Ensure.That("defaultName").IsNotNull(defaultName);
			this.defaultName = defaultName;
		}

		// Token: 0x170002EF RID: 751
		// (get) Token: 0x060008C1 RID: 2241 RVA: 0x000101A1 File Offset: 0x0000E3A1
		[DoNotSerialize]
		public string defaultName { get; } = string.Empty;

		// Token: 0x170002F0 RID: 752
		// (get) Token: 0x060008C2 RID: 2242 RVA: 0x000101A9 File Offset: 0x0000E3A9
		// (set) Token: 0x060008C3 RID: 2243 RVA: 0x000101B1 File Offset: 0x0000E3B1
		[DoNotSerialize]
		[PortLabelHidden]
		public ValueInput name { get; private set; }

		// Token: 0x060008C4 RID: 2244
		protected abstract VariableDeclarations GetDeclarations(Flow flow);

		// Token: 0x060008C5 RID: 2245 RVA: 0x000101BA File Offset: 0x0000E3BA
		protected override void Definition()
		{
			this.name = base.ValueInput<string>("name", this.defaultName);
		}

		// Token: 0x060008C6 RID: 2246 RVA: 0x000101D3 File Offset: 0x0000E3D3
		FlowGraph IUnit.get_graph()
		{
			return base.graph;
		}
	}
}
