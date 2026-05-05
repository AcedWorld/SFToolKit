using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	// Token: 0x02000314 RID: 788
	public class ProgressBar : MonoBehaviour
	{
		// Token: 0x06001073 RID: 4211 RVA: 0x00057CF8 File Offset: 0x00055EF8
		private void Start()
		{
			if (!this.isOn)
			{
				this.loadingBar.fillAmount = this.currentPercent / this.maxValue;
				this.textPercent.text = ((int)this.currentPercent).ToString("F0") + "%";
			}
		}

		// Token: 0x06001074 RID: 4212 RVA: 0x00057D50 File Offset: 0x00055F50
		private void Update()
		{
			if (this.isOn)
			{
				if (this.currentPercent <= this.maxValue && !this.invert)
				{
					this.currentPercent += (float)this.speed * Time.deltaTime;
				}
				else if (this.currentPercent >= 0f && this.invert)
				{
					this.currentPercent -= (float)this.speed * Time.deltaTime;
				}
				if (this.currentPercent >= this.maxValue && this.speed != 0 && this.restart && !this.invert)
				{
					this.currentPercent = 0f;
				}
				else if (this.currentPercent <= 0f && this.speed != 0 && this.restart && this.invert)
				{
					this.currentPercent = this.maxValue;
				}
				this.loadingBar.fillAmount = this.currentPercent / this.maxValue;
				if (this.isPercent)
				{
					this.textPercent.text = ((int)this.currentPercent).ToString("F0") + "%";
					return;
				}
				this.textPercent.text = ((int)this.currentPercent).ToString("F0");
			}
		}

		// Token: 0x06001075 RID: 4213 RVA: 0x00057E98 File Offset: 0x00056098
		public void UpdateUI()
		{
			this.loadingBar.fillAmount = this.currentPercent / this.maxValue;
			if (this.isPercent)
			{
				this.textPercent.text = ((int)this.currentPercent).ToString("F0") + "%";
				return;
			}
			this.textPercent.text = ((int)this.currentPercent).ToString("F0");
		}

		// Token: 0x040015AD RID: 5549
		public float currentPercent;

		// Token: 0x040015AE RID: 5550
		[Range(0f, 100f)]
		public int speed;

		// Token: 0x040015AF RID: 5551
		public float maxValue = 100f;

		// Token: 0x040015B0 RID: 5552
		public Image loadingBar;

		// Token: 0x040015B1 RID: 5553
		public TextMeshProUGUI textPercent;

		// Token: 0x040015B2 RID: 5554
		public bool isOn;

		// Token: 0x040015B3 RID: 5555
		public bool restart;

		// Token: 0x040015B4 RID: 5556
		public bool invert;

		// Token: 0x040015B5 RID: 5557
		public bool isPercent = true;
	}
}
