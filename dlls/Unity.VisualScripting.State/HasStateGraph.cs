using System;
using JetBrains.Annotations;

namespace Unity.VisualScripting
{
	// Token: 0x02000006 RID: 6
	[TypeIcon(typeof(StateGraph))]
	[UnitCategory("Graphs/Graph Nodes")]
	public sealed class HasStateGraph : HasGraph<StateGraph, StateGraphAsset, StateMachine>
	{
		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600001B RID: 27 RVA: 0x0000256D File Offset: 0x0000076D
		// (set) Token: 0x0600001C RID: 28 RVA: 0x00002575 File Offset: 0x00000775
		[Serialize]
		[Inspectable]
		[UnitHeaderInspectable]
		[UsedImplicitly]
		public StateGraphContainerType containerType { get; set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600001D RID: 29 RVA: 0x0000257E File Offset: 0x0000077E
		protected override bool isGameObject
		{
			get
			{
				return this.containerType == StateGraphContainerType.GameObject;
			}
		}
	}
}
