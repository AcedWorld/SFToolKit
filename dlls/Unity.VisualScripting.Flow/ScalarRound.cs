using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x020000EB RID: 235
	[UnitCategory("Math/Scalar")]
	[UnitTitle("Round")]
	public sealed class ScalarRound : Round<float, int>
	{
		// Token: 0x060006E6 RID: 1766 RVA: 0x0000D583 File Offset: 0x0000B783
		protected override int Floor(float input)
		{
			return Mathf.FloorToInt(input);
		}

		// Token: 0x060006E7 RID: 1767 RVA: 0x0000D58B File Offset: 0x0000B78B
		protected override int AwayFromZero(float input)
		{
			return Mathf.RoundToInt(input);
		}

		// Token: 0x060006E8 RID: 1768 RVA: 0x0000D593 File Offset: 0x0000B793
		protected override int Ceiling(float input)
		{
			return Mathf.CeilToInt(input);
		}
	}
}
