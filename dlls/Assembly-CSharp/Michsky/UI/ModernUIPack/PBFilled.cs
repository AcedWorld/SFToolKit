using System;
using TMPro;
using UnityEngine;

namespace Michsky.UI.ModernUIPack
{
	// Token: 0x02000313 RID: 787
	public class PBFilled : MonoBehaviour
	{
		// Token: 0x06001070 RID: 4208 RVA: 0x00057BDC File Offset: 0x00055DDC
		private void Start()
		{
			this.progressBar = base.gameObject.GetComponent<ProgressBar>();
			this.barAnimatior = base.gameObject.GetComponent<Animator>();
			this.minLabel.color = this.minColor;
			this.maxLabel.color = this.maxColor;
		}

		// Token: 0x06001071 RID: 4209 RVA: 0x00057C30 File Offset: 0x00055E30
		private void Update()
		{
			if (this.progressBar.currentPercent >= (float)this.transitionAfter)
			{
				this.barAnimatior.Play("Radial PB Filled");
			}
			if (this.progressBar.currentPercent <= (float)this.transitionAfter)
			{
				this.barAnimatior.Play("Radial PB Empty");
			}
			this.maxLabel.text = this.minLabel.text;
		}

		// Token: 0x040015A6 RID: 5542
		[Header("RESOURCES")]
		public TextMeshProUGUI minLabel;

		// Token: 0x040015A7 RID: 5543
		public TextMeshProUGUI maxLabel;

		// Token: 0x040015A8 RID: 5544
		[Header("SETTINGS")]
		[Range(0f, 100f)]
		public int transitionAfter = 50;

		// Token: 0x040015A9 RID: 5545
		public Color minColor = new Color(0f, 0f, 0f, 255f);

		// Token: 0x040015AA RID: 5546
		public Color maxColor = new Color(255f, 255f, 255f, 255f);

		// Token: 0x040015AB RID: 5547
		private ProgressBar progressBar;

		// Token: 0x040015AC RID: 5548
		private Animator barAnimatior;
	}
}
