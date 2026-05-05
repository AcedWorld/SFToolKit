using System;
using System.Collections;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000134 RID: 308
	[UnitTitle("Wait For Seconds")]
	[UnitOrder(1)]
	public class WaitForSecondsUnit : WaitUnit
	{
		// Token: 0x170002D9 RID: 729
		// (get) Token: 0x06000837 RID: 2103 RVA: 0x0000F5A5 File Offset: 0x0000D7A5
		// (set) Token: 0x06000838 RID: 2104 RVA: 0x0000F5AD File Offset: 0x0000D7AD
		[DoNotSerialize]
		[PortLabel("Delay")]
		public ValueInput seconds { get; private set; }

		// Token: 0x170002DA RID: 730
		// (get) Token: 0x06000839 RID: 2105 RVA: 0x0000F5B6 File Offset: 0x0000D7B6
		// (set) Token: 0x0600083A RID: 2106 RVA: 0x0000F5BE File Offset: 0x0000D7BE
		[DoNotSerialize]
		[PortLabel("Unscaled")]
		public ValueInput unscaledTime { get; private set; }

		// Token: 0x0600083B RID: 2107 RVA: 0x0000F5C8 File Offset: 0x0000D7C8
		protected override void Definition()
		{
			base.Definition();
			this.seconds = base.ValueInput<float>("seconds", 0f);
			this.unscaledTime = base.ValueInput<bool>("unscaledTime", false);
			base.Requirement(this.seconds, base.enter);
			base.Requirement(this.unscaledTime, base.enter);
		}

		// Token: 0x0600083C RID: 2108 RVA: 0x0000F627 File Offset: 0x0000D827
		protected override IEnumerator Await(Flow flow)
		{
			float value = flow.GetValue<float>(this.seconds);
			if (flow.GetValue<bool>(this.unscaledTime))
			{
				yield return new WaitForSecondsRealtime(value);
			}
			else
			{
				yield return new WaitForSeconds(value);
			}
			yield return base.exit;
			yield break;
		}
	}
}
