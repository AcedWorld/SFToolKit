using System;
using System.Collections;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000137 RID: 311
	[UnitTitle("Wait While")]
	[UnitShortTitle("Wait While")]
	[UnitOrder(3)]
	public class WaitWhileUnit : WaitUnit
	{
		// Token: 0x170002DE RID: 734
		// (get) Token: 0x0600084A RID: 2122 RVA: 0x0000F718 File Offset: 0x0000D918
		// (set) Token: 0x0600084B RID: 2123 RVA: 0x0000F720 File Offset: 0x0000D920
		[DoNotSerialize]
		public ValueInput condition { get; private set; }

		// Token: 0x0600084C RID: 2124 RVA: 0x0000F729 File Offset: 0x0000D929
		protected override void Definition()
		{
			base.Definition();
			this.condition = base.ValueInput<bool>("condition");
			base.Requirement(this.condition, base.enter);
		}

		// Token: 0x0600084D RID: 2125 RVA: 0x0000F754 File Offset: 0x0000D954
		protected override IEnumerator Await(Flow flow)
		{
			yield return new WaitWhile(() => flow.GetValue<bool>(this.condition));
			yield return base.exit;
			yield break;
		}
	}
}
