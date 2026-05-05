using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	// Token: 0x0200031D RID: 797
	public class RangeMinSlider : Slider
	{
		// Token: 0x060010AA RID: 4266 RVA: 0x000592E0 File Offset: 0x000574E0
		protected override void Set(float input, bool sendCallback)
		{
			if (this.maxSlider == null)
			{
				this.maxSlider = base.transform.parent.Find("Max Slider").GetComponent<RangeMaxSlider>();
			}
			float num = input;
			if (base.wholeNumbers)
			{
				num = Mathf.Round(num);
			}
			if (num >= this.maxSlider.realValue && this.maxSlider.realValue != this.maxSlider.minValue)
			{
				return;
			}
			if (this.label != null)
			{
				this.label.text = num.ToString(this.numberFormat);
			}
			base.Set(input, sendCallback);
		}

		// Token: 0x060010AB RID: 4267 RVA: 0x000592CC File Offset: 0x000574CC
		public void Refresh(float input)
		{
			this.Set(input, false);
		}

		// Token: 0x040015E5 RID: 5605
		[Header("RESOURCES")]
		public RangeMaxSlider maxSlider;

		// Token: 0x040015E6 RID: 5606
		public TextMeshProUGUI label;

		// Token: 0x040015E7 RID: 5607
		public string numberFormat;
	}
}
