using System;
using System.Collections;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000131 RID: 305
	[UnitTitle("Wait For End of Frame")]
	[UnitOrder(5)]
	public class WaitForEndOfFrameUnit : WaitUnit
	{
		// Token: 0x06000822 RID: 2082 RVA: 0x0000F379 File Offset: 0x0000D579
		protected override IEnumerator Await(Flow flow)
		{
			yield return new WaitForEndOfFrame();
			yield return base.exit;
			yield break;
		}
	}
}
