using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200006B RID: 107
	public interface IGraph : IDisposable, IPrewarmable, IAotStubbable, ISerializationDepender, ISerializationCallbackReceiver
	{
		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x0600037A RID: 890
		// (set) Token: 0x0600037B RID: 891
		Vector2 pan { get; set; }

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x0600037C RID: 892
		// (set) Token: 0x0600037D RID: 893
		float zoom { get; set; }

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x0600037E RID: 894
		MergedGraphElementCollection elements { get; }

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x0600037F RID: 895
		string title { get; }

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x06000380 RID: 896
		string summary { get; }

		// Token: 0x06000381 RID: 897
		IGraphData CreateData();

		// Token: 0x06000382 RID: 898
		IGraphDebugData CreateDebugData();

		// Token: 0x06000383 RID: 899
		void Instantiate(GraphReference instance);

		// Token: 0x06000384 RID: 900
		void Uninstantiate(GraphReference instance);
	}
}
