using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000078 RID: 120
	public interface IGraphParent
	{
		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x060003AB RID: 939
		IGraph childGraph { get; }

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x060003AC RID: 940
		bool isSerializationRoot { get; }

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x060003AD RID: 941
		Object serializedObject { get; }

		// Token: 0x060003AE RID: 942
		IGraph DefaultGraph();
	}
}
