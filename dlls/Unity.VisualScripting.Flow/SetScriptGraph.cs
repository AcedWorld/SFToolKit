using System;
using JetBrains.Annotations;

namespace Unity.VisualScripting
{
	// Token: 0x020000B3 RID: 179
	[TypeIcon(typeof(FlowGraph))]
	public sealed class SetScriptGraph : SetGraph<FlowGraph, ScriptGraphAsset, ScriptMachine>
	{
		// Token: 0x170001FE RID: 510
		// (get) Token: 0x06000530 RID: 1328 RVA: 0x0000AF75 File Offset: 0x00009175
		// (set) Token: 0x06000531 RID: 1329 RVA: 0x0000AF7D File Offset: 0x0000917D
		[Serialize]
		[Inspectable]
		[UnitHeaderInspectable]
		[UsedImplicitly]
		public ScriptGraphContainerType containerType { get; set; }

		// Token: 0x170001FF RID: 511
		// (get) Token: 0x06000532 RID: 1330 RVA: 0x0000AF86 File Offset: 0x00009186
		protected override bool isGameObject
		{
			get
			{
				return this.containerType == ScriptGraphContainerType.GameObject;
			}
		}
	}
}
