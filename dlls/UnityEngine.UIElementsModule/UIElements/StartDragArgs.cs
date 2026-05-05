using System;
using System.Collections;
using System.Collections.Generic;

namespace UnityEngine.UIElements
{
	// Token: 0x02000170 RID: 368
	internal struct StartDragArgs
	{
		// Token: 0x06000BD8 RID: 3032 RVA: 0x0002E477 File Offset: 0x0002C677
		public StartDragArgs(string title, DragVisualMode visualMode)
		{
			this.title = title;
			this.visualMode = visualMode;
			this.genericData = null;
			this.unityObjectReferences = null;
		}

		// Token: 0x06000BD9 RID: 3033 RVA: 0x0002E498 File Offset: 0x0002C698
		internal StartDragArgs(string title, object target)
		{
			this.title = title;
			this.visualMode = 2;
			this.genericData = null;
			this.unityObjectReferences = null;
			this.SetGenericData("__unity-drag-and-drop__source-view", target);
		}

		// Token: 0x17000262 RID: 610
		// (get) Token: 0x06000BDA RID: 3034 RVA: 0x0002E4C6 File Offset: 0x0002C6C6
		public readonly string title { get; }

		// Token: 0x17000263 RID: 611
		// (get) Token: 0x06000BDB RID: 3035 RVA: 0x0002E4CE File Offset: 0x0002C6CE
		public readonly DragVisualMode visualMode { get; }

		// Token: 0x17000264 RID: 612
		// (get) Token: 0x06000BDC RID: 3036 RVA: 0x0002E4D6 File Offset: 0x0002C6D6
		// (set) Token: 0x06000BDD RID: 3037 RVA: 0x0002E4DE File Offset: 0x0002C6DE
		internal Hashtable genericData { readonly get; private set; }

		// Token: 0x17000265 RID: 613
		// (get) Token: 0x06000BDE RID: 3038 RVA: 0x0002E4E7 File Offset: 0x0002C6E7
		// (set) Token: 0x06000BDF RID: 3039 RVA: 0x0002E4EF File Offset: 0x0002C6EF
		internal IEnumerable<Object> unityObjectReferences { readonly get; private set; }

		// Token: 0x06000BE0 RID: 3040 RVA: 0x0002E4F8 File Offset: 0x0002C6F8
		public void SetGenericData(string key, object data)
		{
			if (this.genericData == null)
			{
				this.genericData = new Hashtable();
			}
			this.genericData[key] = data;
		}

		// Token: 0x06000BE1 RID: 3041 RVA: 0x0002E52A File Offset: 0x0002C72A
		public void SetUnityObjectReferences(IEnumerable<Object> references)
		{
			this.unityObjectReferences = references;
		}
	}
}
