using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	// Token: 0x0200031C RID: 796
	public class RangeMaxSlider : Slider
	{
		// Token: 0x060010A6 RID: 4262 RVA: 0x000591E9 File Offset: 0x000573E9
		protected override void Start()
		{
			this.realValue = base.maxValue;
			base.Start();
		}

		// Token: 0x060010A7 RID: 4263 RVA: 0x00059200 File Offset: 0x00057400
		protected override void Set(float input, bool sendCallback)
		{
			if (this.minSlider == null)
			{
				this.minSlider = base.transform.parent.Find("Min Slider").GetComponent<RangeMinSlider>();
			}
			if (!this.assignedRealValue)
			{
				this.realValue = base.maxValue;
				this.assignedRealValue = true;
			}
			else
			{
				this.realValue = base.maxValue - input + base.minValue;
			}
			if (base.wholeNumbers)
			{
				this.realValue = Mathf.Round(this.realValue);
			}
			if (this.realValue <= this.minSlider.value)
			{
				return;
			}
			if (this.label != null)
			{
				this.label.text = this.realValue.ToString(this.numberFormat);
			}
			base.Set(input, sendCallback);
		}

		// Token: 0x060010A8 RID: 4264 RVA: 0x000592CC File Offset: 0x000574CC
		public void Refresh(float input)
		{
			this.Set(input, false);
		}

		// Token: 0x040015E0 RID: 5600
		public RangeMinSlider minSlider;

		// Token: 0x040015E1 RID: 5601
		public TextMeshProUGUI label;

		// Token: 0x040015E2 RID: 5602
		public string numberFormat;

		// Token: 0x040015E3 RID: 5603
		public float realValue;

		// Token: 0x040015E4 RID: 5604
		private bool assignedRealValue;
	}
}
