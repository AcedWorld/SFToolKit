using System;
using UnityEngine;

namespace Invector
{
	// Token: 0x02000349 RID: 841
	public class vAnimatorSetFloat : vAnimatorSetValue<float>
	{
		// Token: 0x06001143 RID: 4419 RVA: 0x0005D8A4 File Offset: 0x0005BAA4
		protected override float GetEnterValue()
		{
			float num;
			if (this.randomEnter)
			{
				num = Random.Range(base.GetEnterValue(), this.maxEnterValue);
				if (this.roundValue)
				{
					num = (float)Math.Round((double)num, this.roundDigits);
				}
			}
			else
			{
				num = base.GetEnterValue();
			}
			if (this.randomInvert && Random.Range(0, 100) > 50)
			{
				num *= -1f;
			}
			return num;
		}

		// Token: 0x06001144 RID: 4420 RVA: 0x0005D910 File Offset: 0x0005BB10
		protected override float GetExitValue()
		{
			float num;
			if (this.randomEnter)
			{
				num = Random.Range(base.GetExitValue(), this.maxEnterValue);
				if (this.roundValue)
				{
					num = (float)Math.Round((double)num, this.roundDigits);
				}
			}
			else
			{
				num = base.GetExitValue();
			}
			if (this.randomInvert && Random.Range(0, 100) > 50)
			{
				num *= -1f;
			}
			return num;
		}

		// Token: 0x04001726 RID: 5926
		[vHelpBox("Random Value between Default Value and Max Value", vHelpBoxAttribute.MessageType.None)]
		public bool randomEnter;

		// Token: 0x04001727 RID: 5927
		[vHideInInspector("randomEnter", false)]
		public float maxEnterValue;

		// Token: 0x04001728 RID: 5928
		public bool randomExit;

		// Token: 0x04001729 RID: 5929
		[vHideInInspector("randomExit", false)]
		public float maxExitValue;

		// Token: 0x0400172A RID: 5930
		[vHelpBox("Use this in <b>Random mode</b> to generat a rounded value", vHelpBoxAttribute.MessageType.None)]
		public bool roundValue;

		// Token: 0x0400172B RID: 5931
		[Tooltip("Digits after the comma")]
		[vHideInInspector("roundValue", false)]
		public int roundDigits = 1;

		// Token: 0x0400172C RID: 5932
		[Tooltip("Invert number randomly")]
		public bool randomInvert;
	}
}
