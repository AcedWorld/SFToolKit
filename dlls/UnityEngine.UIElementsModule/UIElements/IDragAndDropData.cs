using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
	// Token: 0x02000166 RID: 358
	internal interface IDragAndDropData
	{
		// Token: 0x06000BAB RID: 2987
		object GetGenericData(string key);

		// Token: 0x17000249 RID: 585
		// (get) Token: 0x06000BAC RID: 2988
		object userData { get; }

		// Token: 0x1700024A RID: 586
		// (get) Token: 0x06000BAD RID: 2989
		IEnumerable<Object> unityObjectReferences { get; }
	}
}
