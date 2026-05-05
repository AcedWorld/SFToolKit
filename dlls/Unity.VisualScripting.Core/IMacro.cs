using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x020000BA RID: 186
	public interface IMacro : IGraphRoot, IGraphParent, ISerializationDependency, ISerializationCallbackReceiver, IAotStubbable
	{
		// Token: 0x170000FF RID: 255
		// (get) Token: 0x0600049D RID: 1181
		// (set) Token: 0x0600049E RID: 1182
		IGraph graph { get; set; }
	}
}
