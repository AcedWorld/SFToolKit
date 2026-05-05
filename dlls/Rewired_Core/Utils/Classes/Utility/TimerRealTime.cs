using System;
using UnityEngine;

namespace Rewired.Utils.Classes.Utility
{
	// Token: 0x020004C4 RID: 1220
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[Serializable]
	internal class TimerRealTime
	{
		// Token: 0x0600311C RID: 12572 RVA: 0x000033F4 File Offset: 0x000015F4
		public TimerRealTime()
		{
		}

		// Token: 0x0600311D RID: 12573 RVA: 0x000259CF File Offset: 0x00023BCF
		public TimerRealTime(double A_1)
		{
			this.length = A_1;
		}

		// Token: 0x0600311E RID: 12574 RVA: 0x000259DE File Offset: 0x00023BDE
		public void Start()
		{
			this.running = true;
			this.FVrtXwJGtqcTKLlbUrGFjKTVDNtd = this.length + ReInput.realTime;
		}

		// Token: 0x0600311F RID: 12575 RVA: 0x000259F9 File Offset: 0x00023BF9
		public void Start(double inLength)
		{
			this.running = true;
			this.length = inLength;
			this.FVrtXwJGtqcTKLlbUrGFjKTVDNtd = this.length + ReInput.realTime;
		}

		// Token: 0x06003120 RID: 12576 RVA: 0x00025A1B File Offset: 0x00023C1B
		public bool Update()
		{
			if (!this.running)
			{
				return false;
			}
			if (ReInput.realTime >= this.FVrtXwJGtqcTKLlbUrGFjKTVDNtd)
			{
				this.running = false;
				return true;
			}
			return false;
		}

		// Token: 0x06003121 RID: 12577 RVA: 0x00025A3E File Offset: 0x00023C3E
		public void Clear()
		{
			this.running = false;
			this.FVrtXwJGtqcTKLlbUrGFjKTVDNtd = 0.0;
		}

		// Token: 0x06003122 RID: 12578 RVA: 0x00025A56 File Offset: 0x00023C56
		public void SetLength(double inLength)
		{
			this.length = inLength;
		}

		// Token: 0x06003123 RID: 12579 RVA: 0x000259C2 File Offset: 0x00023BC2
		public TimerAbs Clone()
		{
			return (TimerAbs)base.MemberwiseClone();
		}

		// Token: 0x04001AED RID: 6893
		public bool running;

		// Token: 0x04001AEE RID: 6894
		[SerializeField]
		private double FVrtXwJGtqcTKLlbUrGFjKTVDNtd;

		// Token: 0x04001AEF RID: 6895
		public double length;
	}
}
