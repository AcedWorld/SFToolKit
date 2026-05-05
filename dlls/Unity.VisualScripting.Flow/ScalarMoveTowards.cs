using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x020000E6 RID: 230
	[UnitCategory("Math/Scalar")]
	[UnitTitle("Move Towards")]
	public sealed class ScalarMoveTowards : MoveTowards<float>
	{
		// Token: 0x1700027A RID: 634
		// (get) Token: 0x060006D2 RID: 1746 RVA: 0x0000D422 File Offset: 0x0000B622
		protected override float defaultCurrent
		{
			get
			{
				return 0f;
			}
		}

		// Token: 0x1700027B RID: 635
		// (get) Token: 0x060006D3 RID: 1747 RVA: 0x0000D429 File Offset: 0x0000B629
		protected override float defaultTarget
		{
			get
			{
				return 1f;
			}
		}

		// Token: 0x060006D4 RID: 1748 RVA: 0x0000D430 File Offset: 0x0000B630
		public override float Operation(float current, float target, float maxDelta)
		{
			return Mathf.MoveTowards(current, target, maxDelta);
		}
	}
}
