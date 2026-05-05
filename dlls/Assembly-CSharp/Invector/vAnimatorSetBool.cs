using System;
using UnityEngine;

namespace Invector
{
	// Token: 0x02000348 RID: 840
	public class vAnimatorSetBool : vAnimatorSetValue<bool>
	{
		// Token: 0x06001140 RID: 4416 RVA: 0x0005D85F File Offset: 0x0005BA5F
		protected override bool GetEnterValue()
		{
			if (!this.randomEnter)
			{
				return base.GetEnterValue();
			}
			return Random.Range(0, 100) > 50;
		}

		// Token: 0x06001141 RID: 4417 RVA: 0x0005D87C File Offset: 0x0005BA7C
		protected override bool GetExitValue()
		{
			if (!this.randomExit)
			{
				return base.GetExitValue();
			}
			return Random.Range(0, 100) > 50;
		}

		// Token: 0x04001724 RID: 5924
		[vHelpBox("Random Value between True and False", vHelpBoxAttribute.MessageType.None)]
		public bool randomEnter;

		// Token: 0x04001725 RID: 5925
		public bool randomExit;
	}
}
