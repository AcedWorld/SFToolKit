using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x020000B8 RID: 184
	public interface IMachine : IGraphRoot, IGraphParent, IGraphNester, IAotStubbable
	{
		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x0600047A RID: 1146
		// (set) Token: 0x0600047B RID: 1147
		IGraphData graphData { get; set; }

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x0600047C RID: 1148
		GameObject threadSafeGameObject { get; }
	}
}
