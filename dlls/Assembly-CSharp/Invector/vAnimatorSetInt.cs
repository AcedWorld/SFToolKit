using System;

namespace Invector
{
	// Token: 0x0200034A RID: 842
	public class vAnimatorSetInt : vAnimatorSetValue<int>
	{
		// Token: 0x06001146 RID: 4422 RVA: 0x0005D989 File Offset: 0x0005BB89
		protected override int GetEnterValue()
		{
			if (!this.randomEnter)
			{
				return base.GetEnterValue();
			}
			return this.random.Range(base.GetEnterValue(), this.maxEnterValue);
		}

		// Token: 0x06001147 RID: 4423 RVA: 0x0005D9B1 File Offset: 0x0005BBB1
		protected override int GetExitValue()
		{
			if (!this.randomExit)
			{
				return base.GetExitValue();
			}
			return this.random.Range(base.GetExitValue(), this.maxExitValue);
		}

		// Token: 0x0400172D RID: 5933
		private vFisherYatesRandom random = new vFisherYatesRandom();

		// Token: 0x0400172E RID: 5934
		[vHelpBox("Random Value between Default Value and Max Value", vHelpBoxAttribute.MessageType.None)]
		public bool randomEnter;

		// Token: 0x0400172F RID: 5935
		[vHideInInspector("randomEnter", false)]
		public int maxEnterValue;

		// Token: 0x04001730 RID: 5936
		public bool randomExit;

		// Token: 0x04001731 RID: 5937
		[vHideInInspector("randomExit", false)]
		public int maxExitValue;
	}
}
