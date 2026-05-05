using System;
using UnityEngine;
using UnityEngine.UI;

namespace Invector
{
	// Token: 0x0200039E RID: 926
	public class vSliderSizeControl : MonoBehaviour
	{
		// Token: 0x060012A3 RID: 4771 RVA: 0x00062668 File Offset: 0x00060868
		private void OnDrawGizmosSelected()
		{
			this.UpdateScale();
		}

		// Token: 0x060012A4 RID: 4772 RVA: 0x00062670 File Offset: 0x00060870
		public void UpdateScale()
		{
			if (this.rectTransform && this.slider && this.slider.maxValue != this.oldMaxValue)
			{
				Vector2 sizeDelta = this.rectTransform.sizeDelta;
				sizeDelta.x = this.slider.maxValue * this.multipScale;
				this.rectTransform.sizeDelta = sizeDelta;
				this.oldMaxValue = this.slider.maxValue;
			}
		}

		// Token: 0x04001860 RID: 6240
		public Slider slider;

		// Token: 0x04001861 RID: 6241
		public RectTransform rectTransform;

		// Token: 0x04001862 RID: 6242
		public float multipScale = 0.1f;

		// Token: 0x04001863 RID: 6243
		private float oldMaxValue;
	}
}
