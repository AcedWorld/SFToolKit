using System;
using System.Collections.Generic;

namespace Unity.VisualScripting
{
	// Token: 0x0200006D RID: 109
	public interface IGraphDebugData
	{
		// Token: 0x0600038B RID: 907
		IGraphElementDebugData GetOrCreateElementData(IGraphElementWithDebugData element);

		// Token: 0x0600038C RID: 908
		IGraphDebugData GetOrCreateChildGraphData(IGraphParentElement element);

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x0600038D RID: 909
		IEnumerable<IGraphElementDebugData> elementsData { get; }
	}
}
