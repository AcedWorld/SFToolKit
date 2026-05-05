using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200017B RID: 379
	[TypeIcon(typeof(FlowGraph))]
	[CreateAssetMenu(menuName = "Visual Scripting/Script Graph", fileName = "New Script Graph", order = 81)]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.visualscripting@latest/index.html?subfolder=/manual/vs-script-graphs-intro.html")]
	public sealed class ScriptGraphAsset : Macro<FlowGraph>
	{
		// Token: 0x060009ED RID: 2541 RVA: 0x00011B33 File Offset: 0x0000FD33
		[ContextMenu("Show Data...")]
		protected override void ShowData()
		{
			base.ShowData();
		}

		// Token: 0x060009EE RID: 2542 RVA: 0x00011B3B File Offset: 0x0000FD3B
		public override FlowGraph DefaultGraph()
		{
			return FlowGraph.WithInputOutput();
		}
	}
}
