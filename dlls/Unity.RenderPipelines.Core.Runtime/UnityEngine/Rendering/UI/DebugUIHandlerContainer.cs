using System;
using System.Collections.Generic;
using System.Linq;

namespace UnityEngine.Rendering.UI
{
	// Token: 0x02000122 RID: 290
	public class DebugUIHandlerContainer : MonoBehaviour
	{
		// Token: 0x060008BB RID: 2235 RVA: 0x00028A80 File Offset: 0x00026C80
		internal DebugUIHandlerWidget GetFirstItem()
		{
			if (this.contentHolder.childCount == 0)
			{
				return null;
			}
			List<DebugUIHandlerWidget> activeChildren = this.GetActiveChildren();
			if (activeChildren.Count == 0)
			{
				return null;
			}
			return activeChildren[0];
		}

		// Token: 0x060008BC RID: 2236 RVA: 0x00028AB4 File Offset: 0x00026CB4
		internal DebugUIHandlerWidget GetLastItem()
		{
			if (this.contentHolder.childCount == 0)
			{
				return null;
			}
			List<DebugUIHandlerWidget> activeChildren = this.GetActiveChildren();
			if (activeChildren.Count == 0)
			{
				return null;
			}
			return activeChildren[activeChildren.Count - 1];
		}

		// Token: 0x060008BD RID: 2237 RVA: 0x00028AF0 File Offset: 0x00026CF0
		internal bool IsDirectChild(DebugUIHandlerWidget widget)
		{
			return this.contentHolder.childCount != 0 && this.GetActiveChildren().Count((DebugUIHandlerWidget x) => x == widget) > 0;
		}

		// Token: 0x060008BE RID: 2238 RVA: 0x00028B34 File Offset: 0x00026D34
		private List<DebugUIHandlerWidget> GetActiveChildren()
		{
			List<DebugUIHandlerWidget> list = new List<DebugUIHandlerWidget>();
			foreach (object obj in this.contentHolder)
			{
				Transform transform = (Transform)obj;
				if (transform.gameObject.activeInHierarchy)
				{
					DebugUIHandlerWidget component = transform.GetComponent<DebugUIHandlerWidget>();
					if (component != null)
					{
						list.Add(component);
					}
				}
			}
			return list;
		}

		// Token: 0x04000521 RID: 1313
		[SerializeField]
		public RectTransform contentHolder;
	}
}
