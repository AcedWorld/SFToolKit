using System;
using UnityEngine.UI;

namespace UnityEngine.Rendering.UI
{
	// Token: 0x02000139 RID: 313
	public class DebugUIHandlerValueTuple : DebugUIHandlerWidget
	{
		// Token: 0x0600094A RID: 2378 RVA: 0x0002A93A File Offset: 0x00028B3A
		protected override void OnEnable()
		{
			this.m_Timer = 0f;
		}

		// Token: 0x0600094B RID: 2379 RVA: 0x0002A947 File Offset: 0x00028B47
		public override bool OnSelection(bool fromNext, DebugUIHandlerWidget previous)
		{
			this.nameLabel.color = this.colorSelected;
			return true;
		}

		// Token: 0x0600094C RID: 2380 RVA: 0x0002A95B File Offset: 0x00028B5B
		public override void OnDeselection()
		{
			this.nameLabel.color = this.colorDefault;
		}

		// Token: 0x0600094D RID: 2381 RVA: 0x0002A970 File Offset: 0x00028B70
		internal override void SetWidget(DebugUI.Widget widget)
		{
			this.m_Widget = widget;
			this.m_Field = base.CastWidget<DebugUI.ValueTuple>();
			this.nameLabel.text = this.m_Field.displayName;
			int numElements = this.m_Field.numElements;
			this.valueElements = new Text[numElements];
			this.valueElements[0] = this.valueLabel;
			float num = 230f / (float)numElements;
			for (int i = 1; i < numElements; i++)
			{
				GameObject gameObject = Object.Instantiate<GameObject>(this.valueLabel.gameObject, base.transform);
				gameObject.AddComponent<LayoutElement>().ignoreLayout = true;
				RectTransform rectTransform = gameObject.transform as RectTransform;
				RectTransform rectTransform2 = this.nameLabel.transform as RectTransform;
				Vector2 vector = new Vector2(0f, 1f);
				rectTransform.anchorMin = vector;
				rectTransform.anchorMax = vector;
				rectTransform.sizeDelta = new Vector2(100f, 26f);
				Vector3 v = rectTransform2.anchoredPosition;
				v.x += (float)(i + 1) * num + 200f;
				rectTransform.anchoredPosition = v;
				rectTransform.pivot = new Vector2(0f, 1f);
				this.valueElements[i] = gameObject.GetComponent<Text>();
			}
		}

		// Token: 0x0600094E RID: 2382 RVA: 0x0002AAB4 File Offset: 0x00028CB4
		internal virtual void UpdateValueLabels()
		{
			for (int i = 0; i < this.m_Field.numElements; i++)
			{
				if (i < this.valueElements.Length && this.valueElements[i] != null)
				{
					object value = this.m_Field.values[i].GetValue();
					this.valueElements[i].text = this.m_Field.values[i].FormatString(value);
					if (value is float)
					{
						this.valueElements[i].color = (((float)value == 0f) ? DebugUIHandlerValueTuple.k_ZeroColor : this.colorDefault);
					}
				}
			}
		}

		// Token: 0x0600094F RID: 2383 RVA: 0x0002AB5C File Offset: 0x00028D5C
		private void Update()
		{
			if (this.m_Field != null && this.m_Timer >= this.m_Field.refreshRate)
			{
				this.UpdateValueLabels();
				this.m_Timer -= this.m_Field.refreshRate;
			}
			this.m_Timer += Time.deltaTime;
		}

		// Token: 0x04000572 RID: 1394
		public Text nameLabel;

		// Token: 0x04000573 RID: 1395
		public Text valueLabel;

		// Token: 0x04000574 RID: 1396
		protected internal DebugUI.ValueTuple m_Field;

		// Token: 0x04000575 RID: 1397
		protected internal Text[] valueElements;

		// Token: 0x04000576 RID: 1398
		private const float k_XOffset = 230f;

		// Token: 0x04000577 RID: 1399
		private float m_Timer;

		// Token: 0x04000578 RID: 1400
		private static readonly Color k_ZeroColor = Color.gray;
	}
}
