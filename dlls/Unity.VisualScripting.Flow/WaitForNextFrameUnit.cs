using System;
using System.Collections;

namespace Unity.VisualScripting
{
	// Token: 0x02000133 RID: 307
	[UnitTitle("Wait For Next Frame")]
	[UnitOrder(4)]
	public class WaitForNextFrameUnit : WaitUnit
	{
		// Token: 0x06000835 RID: 2101 RVA: 0x0000F58E File Offset: 0x0000D78E
		protected override IEnumerator Await(Flow flow)
		{
			yield return null;
			yield return base.exit;
			yield break;
		}
	}
}
