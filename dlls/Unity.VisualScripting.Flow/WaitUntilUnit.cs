using System;
using System.Collections;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000136 RID: 310
	[UnitTitle("Wait Until")]
	[UnitShortTitle("Wait Until")]
	[UnitOrder(2)]
	public class WaitUntilUnit : WaitUnit
	{
		// Token: 0x170002DD RID: 733
		// (get) Token: 0x06000845 RID: 2117 RVA: 0x0000F6BE File Offset: 0x0000D8BE
		// (set) Token: 0x06000846 RID: 2118 RVA: 0x0000F6C6 File Offset: 0x0000D8C6
		[DoNotSerialize]
		public ValueInput condition { get; private set; }

		// Token: 0x06000847 RID: 2119 RVA: 0x0000F6CF File Offset: 0x0000D8CF
		protected override void Definition()
		{
			base.Definition();
			this.condition = base.ValueInput<bool>("condition");
			base.Requirement(this.condition, base.enter);
		}

		// Token: 0x06000848 RID: 2120 RVA: 0x0000F6FA File Offset: 0x0000D8FA
		protected override IEnumerator Await(Flow flow)
		{
			yield return new WaitUntil(() => flow.GetValue<bool>(this.condition));
			yield return base.exit;
			yield break;
		}
	}
}
