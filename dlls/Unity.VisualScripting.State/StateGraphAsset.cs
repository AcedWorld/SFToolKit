using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000016 RID: 22
	[TypeIcon(typeof(StateGraph))]
	[CreateAssetMenu(menuName = "Visual Scripting/State Graph", fileName = "New State Graph", order = 81)]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.visualscripting@latest/index.html?subfolder=/manual/vs-state-graphs-intro.html")]
	public sealed class StateGraphAsset : Macro<StateGraph>
	{
		// Token: 0x06000087 RID: 135 RVA: 0x00002F7D File Offset: 0x0000117D
		[ContextMenu("Show Data...")]
		protected override void ShowData()
		{
			base.ShowData();
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00002F85 File Offset: 0x00001185
		public override StateGraph DefaultGraph()
		{
			return StateGraph.WithStart();
		}
	}
}
