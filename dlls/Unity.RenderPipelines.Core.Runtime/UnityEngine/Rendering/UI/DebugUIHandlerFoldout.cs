using System;
using UnityEngine.UI;

namespace UnityEngine.Rendering.UI
{
	// Token: 0x02000127 RID: 295
	public class DebugUIHandlerFoldout : DebugUIHandlerWidget
	{
		// Token: 0x060008D7 RID: 2263 RVA: 0x000291A8 File Offset: 0x000273A8
		internal override void SetWidget(DebugUI.Widget widget)
		{
			base.SetWidget(widget);
			this.m_Field = base.CastWidget<DebugUI.Foldout>();
			this.m_Container = base.GetComponent<DebugUIHandlerContainer>();
			this.nameLabel.text = this.m_Field.displayName;
			string[] columnLabels = this.m_Field.columnLabels;
			int num = (columnLabels != null) ? columnLabels.Length : 0;
			float num2 = (num > 0) ? (230f / (float)num) : 0f;
			for (int i = 0; i < num; i++)
			{
				GameObject gameObject = Object.Instantiate<GameObject>(this.nameLabel.gameObject, base.GetComponent<DebugUIHandlerContainer>().contentHolder);
				gameObject.AddComponent<LayoutElement>().ignoreLayout = true;
				RectTransform rectTransform = gameObject.transform as RectTransform;
				RectTransform rectTransform2 = this.nameLabel.transform as RectTransform;
				Vector2 vector = new Vector2(0f, 1f);
				rectTransform.anchorMin = vector;
				rectTransform.anchorMax = vector;
				rectTransform.sizeDelta = new Vector2(100f, 26f);
				Vector3 v = rectTransform2.anchoredPosition;
				v.x += (float)(i + 1) * num2 + 215f;
				rectTransform.anchoredPosition = v;
				rectTransform.pivot = new Vector2(0f, 0.5f);
				rectTransform.eulerAngles = new Vector3(0f, 0f, 13f);
				Text component = gameObject.GetComponent<Text>();
				component.fontSize = 15;
				component.text = this.m_Field.columnLabels[i];
			}
			this.UpdateValue();
		}

		// Token: 0x060008D8 RID: 2264 RVA: 0x00029324 File Offset: 0x00027524
		public override bool OnSelection(bool fromNext, DebugUIHandlerWidget previous)
		{
			if (fromNext || !this.valueToggle.isOn)
			{
				this.nameLabel.color = this.colorSelected;
			}
			else if (this.valueToggle.isOn)
			{
				if (this.m_Container.IsDirectChild(previous))
				{
					this.nameLabel.color = this.colorSelected;
				}
				else
				{
					DebugUIHandlerWidget lastItem = this.m_Container.GetLastItem();
					DebugManager.instance.ChangeSelection(lastItem, false);
				}
			}
			return true;
		}

		// Token: 0x060008D9 RID: 2265 RVA: 0x0002939B File Offset: 0x0002759B
		public override void OnDeselection()
		{
			this.nameLabel.color = this.colorDefault;
		}

		// Token: 0x060008DA RID: 2266 RVA: 0x000293AE File Offset: 0x000275AE
		public override void OnIncrement(bool fast)
		{
			this.m_Field.SetValue(true);
			this.UpdateValue();
		}

		// Token: 0x060008DB RID: 2267 RVA: 0x000293C2 File Offset: 0x000275C2
		public override void OnDecrement(bool fast)
		{
			this.m_Field.SetValue(false);
			this.UpdateValue();
		}

		// Token: 0x060008DC RID: 2268 RVA: 0x000293D8 File Offset: 0x000275D8
		public override void OnAction()
		{
			bool value = !this.m_Field.GetValue();
			this.m_Field.SetValue(value);
			this.UpdateValue();
		}

		// Token: 0x060008DD RID: 2269 RVA: 0x00029406 File Offset: 0x00027606
		private void UpdateValue()
		{
			this.valueToggle.isOn = this.m_Field.GetValue();
		}

		// Token: 0x060008DE RID: 2270 RVA: 0x00029420 File Offset: 0x00027620
		public override DebugUIHandlerWidget Next()
		{
			if (!this.m_Field.GetValue() || this.m_Container == null)
			{
				return base.Next();
			}
			DebugUIHandlerWidget firstItem = this.m_Container.GetFirstItem();
			if (firstItem == null)
			{
				return base.Next();
			}
			return firstItem;
		}

		// Token: 0x0400052C RID: 1324
		public Text nameLabel;

		// Token: 0x0400052D RID: 1325
		public UIFoldout valueToggle;

		// Token: 0x0400052E RID: 1326
		private DebugUI.Foldout m_Field;

		// Token: 0x0400052F RID: 1327
		private DebugUIHandlerContainer m_Container;

		// Token: 0x04000530 RID: 1328
		private const float k_FoldoutXOffset = 215f;

		// Token: 0x04000531 RID: 1329
		private const float k_XOffset = 230f;
	}
}
