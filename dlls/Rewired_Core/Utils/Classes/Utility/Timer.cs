using System;
using UnityEngine;

namespace Rewired.Utils.Classes.Utility
{
	// Token: 0x020004C5 RID: 1221
	[CustomObfuscation(rename = false)]
	[Serializable]
	internal class Timer
	{
		// Token: 0x06003124 RID: 12580 RVA: 0x000033F4 File Offset: 0x000015F4
		public Timer()
		{
		}

		// Token: 0x06003125 RID: 12581 RVA: 0x00025A5F File Offset: 0x00023C5F
		public Timer(double A_1)
		{
			this.length = A_1;
		}

		// Token: 0x06003126 RID: 12582 RVA: 0x00025A6E File Offset: 0x00023C6E
		public void yvjGHLteBsTHpzgHlTOyZxGzddJq()
		{
			this.running = true;
			this.timer = this.length;
		}

		// Token: 0x06003127 RID: 12583 RVA: 0x00025A83 File Offset: 0x00023C83
		public void SyVddMqEGvwlWcfITeNIfzBbPfYQA(double A_1)
		{
			this.running = true;
			this.length = A_1;
			this.timer = this.length;
		}

		// Token: 0x06003128 RID: 12584 RVA: 0x00025A9F File Offset: 0x00023C9F
		public void VhgaSCEdDNAjEhTWcicpAHGSTXXoB()
		{
			this.eiECiVKQEsvycDWJQdMvsvqdhNldA();
			this.yvjGHLteBsTHpzgHlTOyZxGzddJq();
		}

		// Token: 0x06003129 RID: 12585 RVA: 0x00025AAD File Offset: 0x00023CAD
		public bool OdOgXXjoOSFxnHvoFhNDEXSatBIIc(double A_1)
		{
			if (!this.running)
			{
				return false;
			}
			this.timer -= A_1;
			if (this.timer <= 0.0)
			{
				this.running = false;
				return true;
			}
			return false;
		}

		// Token: 0x0600312A RID: 12586 RVA: 0x00025AE2 File Offset: 0x00023CE2
		public void eiECiVKQEsvycDWJQdMvsvqdhNldA()
		{
			this.running = false;
			this.timer = 0.0;
		}

		// Token: 0x0600312B RID: 12587 RVA: 0x00025AFA File Offset: 0x00023CFA
		public void NnpGSWSwcafsWRmhktISqIJACKvj(double A_1)
		{
			this.length = A_1;
		}

		// Token: 0x0600312C RID: 12588 RVA: 0x00025B03 File Offset: 0x00023D03
		public Timer AwZamYIAIvfmUsuBQflWWYsrOaPLA()
		{
			return (Timer)base.MemberwiseClone();
		}

		// Token: 0x04001AF0 RID: 6896
		public bool running;

		// Token: 0x04001AF1 RID: 6897
		[SerializeField]
		private double timer;

		// Token: 0x04001AF2 RID: 6898
		public double length;
	}
}
