using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Michsky.UI.ModernUIPack
{
	// Token: 0x0200031E RID: 798
	public class RangeSlider : MonoBehaviour
	{
		// Token: 0x17000332 RID: 818
		// (get) Token: 0x060010AD RID: 4269 RVA: 0x00059381 File Offset: 0x00057581
		public float CurrentLowerValue
		{
			get
			{
				return this.minSlider.value;
			}
		}

		// Token: 0x17000333 RID: 819
		// (get) Token: 0x060010AE RID: 4270 RVA: 0x0005938E File Offset: 0x0005758E
		public float CurrentUpperValue
		{
			get
			{
				return this.maxSlider.realValue;
			}
		}

		// Token: 0x060010AF RID: 4271 RVA: 0x0005939C File Offset: 0x0005759C
		private void Awake()
		{
			if (this.minSlider == null || this.maxSlider == null)
			{
				return;
			}
			if (this.showLabels)
			{
				this.minSlider.label = this.minSliderLabel;
				this.minSlider.numberFormat = "n" + this.decimalPlaces.ToString();
				this.maxSlider.label = this.maxSliderLabel;
				this.maxSlider.numberFormat = "n" + this.decimalPlaces.ToString();
			}
			else
			{
				this.minSliderLabel.gameObject.SetActive(false);
				this.maxSliderLabel.gameObject.SetActive(false);
			}
			if (this.useWholeNumbers)
			{
				this.minSlider.wholeNumbers = false;
				this.maxSlider.wholeNumbers = false;
			}
			this.minSlider.minValue = this.minValue;
			this.minSlider.maxValue = this.maxValue;
			this.minSlider.onValueChanged.AddListener(new UnityAction<float>(this.CheckForMinState));
			this.maxSlider.minValue = this.minValue;
			this.maxSlider.maxValue = this.maxValue;
		}

		// Token: 0x060010B0 RID: 4272 RVA: 0x000594D4 File Offset: 0x000576D4
		public void CheckForMinState(float value)
		{
			if (this.minSlider.value >= this.maxSlider.realValue)
			{
				this.maxSlider.realValue = this.minSlider.value;
				this.minSlider.value = this.maxSlider.realValue - 1f;
			}
		}

		// Token: 0x040015E8 RID: 5608
		[Header("SETTINGS")]
		[Range(0f, 2f)]
		public int decimalPlaces;

		// Token: 0x040015E9 RID: 5609
		public float minValue;

		// Token: 0x040015EA RID: 5610
		public float maxValue = 1f;

		// Token: 0x040015EB RID: 5611
		public bool showLabels = true;

		// Token: 0x040015EC RID: 5612
		public bool useWholeNumbers = true;

		// Token: 0x040015ED RID: 5613
		[Header("MIN SLIDER")]
		public RangeMinSlider minSlider;

		// Token: 0x040015EE RID: 5614
		public TextMeshProUGUI minSliderLabel;

		// Token: 0x040015EF RID: 5615
		[Header("MAX SLIDER")]
		public RangeMaxSlider maxSlider;

		// Token: 0x040015F0 RID: 5616
		public TextMeshProUGUI maxSliderLabel;
	}
}
