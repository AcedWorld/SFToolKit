using System;
using JetBrains.Annotations;

namespace Unity.VisualScripting
{
	// Token: 0x0200001F RID: 31
	[TypeIcon(typeof(StateGraph))]
	public class SetStateGraph : SetGraph<StateGraph, StateGraphAsset, StateMachine>
	{
		// Token: 0x17000035 RID: 53
		// (get) Token: 0x060000C1 RID: 193 RVA: 0x00003564 File Offset: 0x00001764
		// (set) Token: 0x060000C2 RID: 194 RVA: 0x0000356C File Offset: 0x0000176C
		[Serialize]
		[Inspectable]
		[UnitHeaderInspectable]
		[UsedImplicitly]
		public StateGraphContainerType containerType { get; set; }

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x060000C3 RID: 195 RVA: 0x00003575 File Offset: 0x00001775
		protected override bool isGameObject
		{
			get
			{
				return this.containerType == StateGraphContainerType.GameObject;
			}
		}
	}
}
