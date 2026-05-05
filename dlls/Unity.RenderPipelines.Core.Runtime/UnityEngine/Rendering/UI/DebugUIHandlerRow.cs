using System;
using UnityEngine.UI;

namespace UnityEngine.Rendering.UI
{
	// Token: 0x02000134 RID: 308
	public class DebugUIHandlerRow : DebugUIHandlerFoldout
	{
		// Token: 0x0600092A RID: 2346 RVA: 0x0002A1AA File Offset: 0x000283AA
		protected override void OnEnable()
		{
			this.m_Timer = 0f;
		}

		// Token: 0x0600092B RID: 2347 RVA: 0x0002A1B8 File Offset: 0x000283B8
		private GameObject GetChild(int index)
		{
			if (index < 0)
			{
				return null;
			}
			if (base.gameObject.transform != null)
			{
				Transform child = base.gameObject.transform.GetChild(1);
				if (child != null && child.childCount > index)
				{
					return child.GetChild(index).gameObject;
				}
			}
			return null;
		}

		// Token: 0x0600092C RID: 2348 RVA: 0x0002A210 File Offset: 0x00028410
		private bool TryGetChild(int index, out GameObject child)
		{
			child = this.GetChild(index);
			return child != null;
		}

		// Token: 0x0600092D RID: 2349 RVA: 0x0002A224 File Offset: 0x00028424
		private bool IsActive(DebugUI.Table table, int index, GameObject child)
		{
			if (!table.GetColumnVisibility(index))
			{
				return false;
			}
			Transform transform = child.transform.Find("Value");
			Text text;
			return !(transform != null) || !transform.TryGetComponent<Text>(out text) || !string.IsNullOrEmpty(text.text);
		}

		// Token: 0x0600092E RID: 2350 RVA: 0x0002A270 File Offset: 0x00028470
		protected void Update()
		{
			DebugUI.Table.Row row = base.CastWidget<DebugUI.Table.Row>();
			DebugUI.Table table = row.parent as DebugUI.Table;
			float num = 0.1f;
			bool flag = this.m_Timer >= num;
			if (flag)
			{
				this.m_Timer -= num;
			}
			this.m_Timer += Time.deltaTime;
			for (int i = 0; i < row.children.Count; i++)
			{
				GameObject gameObject;
				if (this.TryGetChild(i, out gameObject))
				{
					bool flag2 = this.IsActive(table, i, gameObject);
					if (gameObject != null)
					{
						gameObject.SetActive(flag2);
					}
					if (flag2 && flag)
					{
						DebugUIHandlerColor debugUIHandlerColor;
						if (gameObject.TryGetComponent<DebugUIHandlerColor>(out debugUIHandlerColor))
						{
							debugUIHandlerColor.UpdateColor();
						}
						DebugUIHandlerToggle debugUIHandlerToggle;
						if (gameObject.TryGetComponent<DebugUIHandlerToggle>(out debugUIHandlerToggle))
						{
							debugUIHandlerToggle.UpdateValueLabel();
						}
						DebugUIHandlerObjectList debugUIHandlerObjectList;
						if (gameObject.TryGetComponent<DebugUIHandlerObjectList>(out debugUIHandlerObjectList))
						{
							debugUIHandlerObjectList.UpdateValueLabel();
						}
					}
				}
			}
			DebugUIHandlerWidget debugUIHandlerWidget = this.GetChild(0).GetComponent<DebugUIHandlerWidget>();
			DebugUIHandlerWidget previousUIHandler = null;
			for (int j = 0; j < row.children.Count; j++)
			{
				debugUIHandlerWidget.previousUIHandler = previousUIHandler;
				GameObject gameObject2;
				if (this.TryGetChild(j, out gameObject2))
				{
					if (this.IsActive(table, j, gameObject2))
					{
						previousUIHandler = debugUIHandlerWidget;
					}
					bool flag3 = false;
					for (int k = j + 1; k < row.children.Count; k++)
					{
						GameObject child;
						if (this.TryGetChild(k, out child) && this.IsActive(table, k, child))
						{
							DebugUIHandlerWidget component = gameObject2.GetComponent<DebugUIHandlerWidget>();
							debugUIHandlerWidget.nextUIHandler = component;
							debugUIHandlerWidget = component;
							j = k - 1;
							flag3 = true;
							break;
						}
					}
					if (!flag3)
					{
						debugUIHandlerWidget.nextUIHandler = null;
						return;
					}
				}
			}
		}

		// Token: 0x04000563 RID: 1379
		private float m_Timer;
	}
}
