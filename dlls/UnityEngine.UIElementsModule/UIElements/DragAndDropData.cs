using System;
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
	// Token: 0x02000167 RID: 359
	internal abstract class DragAndDropData : IDragAndDropData
	{
		// Token: 0x06000BAE RID: 2990
		public abstract object GetGenericData(string key);

		// Token: 0x1700024B RID: 587
		// (get) Token: 0x06000BAF RID: 2991 RVA: 0x0002DAE3 File Offset: 0x0002BCE3
		object IDragAndDropData.userData
		{
			get
			{
				return this.GetGenericData("__unity-drag-and-drop__source-view");
			}
		}

		// Token: 0x06000BB0 RID: 2992
		public abstract void SetGenericData(string key, object data);

		// Token: 0x1700024C RID: 588
		// (get) Token: 0x06000BB1 RID: 2993
		public abstract object source { get; }

		// Token: 0x1700024D RID: 589
		// (get) Token: 0x06000BB2 RID: 2994
		public abstract DragVisualMode visualMode { get; }

		// Token: 0x1700024E RID: 590
		// (get) Token: 0x06000BB3 RID: 2995
		public abstract IEnumerable<Object> unityObjectReferences { get; }

		// Token: 0x0400057B RID: 1403
		internal const string dragSourceKey = "__unity-drag-and-drop__source-view";
	}
}
