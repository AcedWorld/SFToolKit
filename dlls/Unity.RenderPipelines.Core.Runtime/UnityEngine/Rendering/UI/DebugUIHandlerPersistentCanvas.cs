using System;
using System.Collections.Generic;

namespace UnityEngine.Rendering.UI
{
	// Token: 0x02000132 RID: 306
	internal class DebugUIHandlerPersistentCanvas : MonoBehaviour
	{
		// Token: 0x0600091E RID: 2334 RVA: 0x00029E18 File Offset: 0x00028018
		internal void Toggle(DebugUI.Value widget, string displayName = null)
		{
			int num = this.m_Items.FindIndex((DebugUIHandlerValue x) => x.GetWidget() == widget);
			if (num > -1)
			{
				CoreUtils.Destroy(this.m_Items[num].gameObject);
				this.m_Items.RemoveAt(num);
				return;
			}
			DebugUIHandlerValue component = Object.Instantiate<RectTransform>(this.valuePrefab, this.panel, false).gameObject.GetComponent<DebugUIHandlerValue>();
			component.SetWidget(widget);
			component.nameLabel.text = (string.IsNullOrEmpty(displayName) ? widget.displayName : displayName);
			this.m_Items.Add(component);
		}

		// Token: 0x0600091F RID: 2335 RVA: 0x00029EC8 File Offset: 0x000280C8
		internal void Toggle(DebugUI.ValueTuple widget, int? forceTupleIndex = null)
		{
			DebugUI.ValueTuple valueTuple = this.m_ValueTupleWidgets.Find((DebugUI.ValueTuple x) => x == widget);
			int num = (valueTuple != null) ? valueTuple.pinnedElementIndex : -1;
			if (valueTuple != null)
			{
				this.m_ValueTupleWidgets.Remove(valueTuple);
				this.Toggle(widget.values[num], null);
			}
			if (forceTupleIndex != null)
			{
				num = forceTupleIndex.Value;
			}
			if (num + 1 < widget.numElements)
			{
				widget.pinnedElementIndex = num + 1;
				string text = widget.displayName;
				if (widget.parent is DebugUI.Foldout)
				{
					string[] columnLabels = (widget.parent as DebugUI.Foldout).columnLabels;
					if (columnLabels != null && widget.pinnedElementIndex < columnLabels.Length)
					{
						text = text + " (" + columnLabels[widget.pinnedElementIndex] + ")";
					}
				}
				this.Toggle(widget.values[widget.pinnedElementIndex], text);
				this.m_ValueTupleWidgets.Add(widget);
				return;
			}
			widget.pinnedElementIndex = -1;
		}

		// Token: 0x06000920 RID: 2336 RVA: 0x0002A002 File Offset: 0x00028202
		internal bool IsEmpty()
		{
			return this.m_Items.Count == 0;
		}

		// Token: 0x06000921 RID: 2337 RVA: 0x0002A014 File Offset: 0x00028214
		internal void Clear()
		{
			foreach (DebugUIHandlerValue debugUIHandlerValue in this.m_Items)
			{
				CoreUtils.Destroy(debugUIHandlerValue.gameObject);
			}
			this.m_Items.Clear();
		}

		// Token: 0x0400055A RID: 1370
		public RectTransform panel;

		// Token: 0x0400055B RID: 1371
		public RectTransform valuePrefab;

		// Token: 0x0400055C RID: 1372
		private List<DebugUIHandlerValue> m_Items = new List<DebugUIHandlerValue>();

		// Token: 0x0400055D RID: 1373
		private List<DebugUI.ValueTuple> m_ValueTupleWidgets = new List<DebugUI.ValueTuple>();
	}
}
