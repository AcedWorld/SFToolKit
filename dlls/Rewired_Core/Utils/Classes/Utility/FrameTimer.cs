using System;
using UnityEngine;

namespace Rewired.Utils.Classes.Utility
{
	// Token: 0x020004C6 RID: 1222
	[CustomObfuscation(rename = false)]
	[Serializable]
	internal class FrameTimer
	{
		// Token: 0x0600312D RID: 12589 RVA: 0x000033F4 File Offset: 0x000015F4
		public FrameTimer()
		{
		}

		// Token: 0x0600312E RID: 12590 RVA: 0x00025B10 File Offset: 0x00023D10
		public FrameTimer(double A_1)
		{
			this.length = A_1;
		}

		// Token: 0x0600312F RID: 12591 RVA: 0x00025B1F File Offset: 0x00023D1F
		public void ndlKMhXBAqpdoUbuvlqqLBsFnMQi()
		{
			this.running = true;
			this.timeRemaining = this.length;
		}

		// Token: 0x06003130 RID: 12592 RVA: 0x00025B34 File Offset: 0x00023D34
		public void qfiGrGXuucgoXmmLvewlLoRYVwbn(double A_1)
		{
			this.running = true;
			this.length = A_1;
			this.timeRemaining = this.length;
		}

		// Token: 0x06003131 RID: 12593 RVA: 0x000AB758 File Offset: 0x000A9958
		public bool IsgfWoaDfdACKfozSEdaotRbElgIA(double A_1, double A_2)
		{
			if (!this.running)
			{
				return false;
			}
			double num = (A_2 > 0.0) ? (this.timeRemaining / A_2) : this.timeRemaining;
			num -= A_1;
			if (this.overrunBuffer > 0.0)
			{
				num -= this.overrunBuffer;
			}
			if (num <= 0.0)
			{
				this.running = false;
				if (num < 0.0)
				{
					this.overrunBuffer = num * -1.0;
				}
				else
				{
					this.overrunBuffer = 0.0;
				}
				return true;
			}
			this.timeRemaining = num * A_2;
			this.overrunBuffer = 0.0;
			return false;
		}

		// Token: 0x06003132 RID: 12594 RVA: 0x00025B50 File Offset: 0x00023D50
		public void pILmkplYyDLJzOPodSqyyldQlRAW()
		{
			this.running = false;
			this.timeRemaining = 0.0;
			this.overrunBuffer = 0.0;
		}

		// Token: 0x06003133 RID: 12595 RVA: 0x00025B77 File Offset: 0x00023D77
		public void sXEBmADHLihxVFAvFrMrAwJjAVBfb(double A_1)
		{
			this.length = A_1;
		}

		// Token: 0x06003134 RID: 12596 RVA: 0x00025B80 File Offset: 0x00023D80
		public FrameTimer NDUcjETJSOUexRCCdGSMpmchtwIL()
		{
			return (FrameTimer)base.MemberwiseClone();
		}

		// Token: 0x04001AF3 RID: 6899
		public bool running;

		// Token: 0x04001AF4 RID: 6900
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private double timeRemaining;

		// Token: 0x04001AF5 RID: 6901
		public double length;

		// Token: 0x04001AF6 RID: 6902
		public double overrunBuffer;
	}
}
