using System;
using UnityEngine;

namespace Rewired.Utils.Classes.Utility
{
	// Token: 0x020004C3 RID: 1219
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[Serializable]
	internal class TimerAbs
	{
		// Token: 0x06003114 RID: 12564 RVA: 0x000033F4 File Offset: 0x000015F4
		public TimerAbs()
		{
		}

		// Token: 0x06003115 RID: 12565 RVA: 0x00025932 File Offset: 0x00023B32
		public TimerAbs(double A_1)
		{
			this.length = A_1;
		}

		// Token: 0x06003116 RID: 12566 RVA: 0x00025941 File Offset: 0x00023B41
		public void Start()
		{
			this.running = true;
			this.yzgOYPBDovWVliRJUJBCSfJLjjOR = this.length + ReInput.unscaledTime;
		}

		// Token: 0x06003117 RID: 12567 RVA: 0x0002595C File Offset: 0x00023B5C
		public void Start(double inLength)
		{
			this.running = true;
			this.length = inLength;
			this.yzgOYPBDovWVliRJUJBCSfJLjjOR = this.length + ReInput.unscaledTime;
		}

		// Token: 0x06003118 RID: 12568 RVA: 0x0002597E File Offset: 0x00023B7E
		public bool Update()
		{
			if (!this.running)
			{
				return false;
			}
			if (ReInput.unscaledTime >= this.yzgOYPBDovWVliRJUJBCSfJLjjOR)
			{
				this.running = false;
				return true;
			}
			return false;
		}

		// Token: 0x06003119 RID: 12569 RVA: 0x000259A1 File Offset: 0x00023BA1
		public void Clear()
		{
			this.running = false;
			this.yzgOYPBDovWVliRJUJBCSfJLjjOR = 0.0;
		}

		// Token: 0x0600311A RID: 12570 RVA: 0x000259B9 File Offset: 0x00023BB9
		public void SetLength(double inLength)
		{
			this.length = inLength;
		}

		// Token: 0x0600311B RID: 12571 RVA: 0x000259C2 File Offset: 0x00023BC2
		public TimerAbs Clone()
		{
			return (TimerAbs)base.MemberwiseClone();
		}

		// Token: 0x04001AEA RID: 6890
		public bool running;

		// Token: 0x04001AEB RID: 6891
		[SerializeField]
		private double yzgOYPBDovWVliRJUJBCSfJLjjOR;

		// Token: 0x04001AEC RID: 6892
		public double length;
	}
}
