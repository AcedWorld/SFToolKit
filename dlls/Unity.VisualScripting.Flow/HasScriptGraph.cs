using System;
using JetBrains.Annotations;

namespace Unity.VisualScripting
{
	// Token: 0x020000B0 RID: 176
	[TypeIcon(typeof(FlowGraph))]
	[UnitCategory("Graphs/Graph Nodes")]
	public sealed class HasScriptGraph : HasGraph<FlowGraph, ScriptGraphAsset, ScriptMachine>
	{
		// Token: 0x170001F5 RID: 501
		// (get) Token: 0x0600051D RID: 1309 RVA: 0x0000AD88 File Offset: 0x00008F88
		// (set) Token: 0x0600051E RID: 1310 RVA: 0x0000AD90 File Offset: 0x00008F90
		[Serialize]
		[Inspectable]
		[UnitHeaderInspectable]
		[UsedImplicitly]
		public ScriptGraphContainerType containerType { get; set; }

		// Token: 0x170001F6 RID: 502
		// (get) Token: 0x0600051F RID: 1311 RVA: 0x0000AD99 File Offset: 0x00008F99
		protected override bool isGameObject
		{
			get
			{
				return this.containerType == ScriptGraphContainerType.GameObject;
			}
		}
	}
}
