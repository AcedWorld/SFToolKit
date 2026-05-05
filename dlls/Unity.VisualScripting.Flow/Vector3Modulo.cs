using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200010E RID: 270
	[UnitCategory("Math/Vector 3")]
	[UnitTitle("Modulo")]
	public sealed class Vector3Modulo : Modulo<Vector3>
	{
		// Token: 0x1700029B RID: 667
		// (get) Token: 0x0600075C RID: 1884 RVA: 0x0000DE5C File Offset: 0x0000C05C
		protected override Vector3 defaultDividend
		{
			get
			{
				return Vector3.zero;
			}
		}

		// Token: 0x1700029C RID: 668
		// (get) Token: 0x0600075D RID: 1885 RVA: 0x0000DE63 File Offset: 0x0000C063
		protected override Vector3 defaultDivisor
		{
			get
			{
				return Vector3.zero;
			}
		}

		// Token: 0x0600075E RID: 1886 RVA: 0x0000DE6A File Offset: 0x0000C06A
		public override Vector3 Operation(Vector3 a, Vector3 b)
		{
			return new Vector3(a.x % b.x, a.y % b.y, a.z % b.z);
		}
	}
}
