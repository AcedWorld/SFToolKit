using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200010F RID: 271
	[UnitCategory("Math/Vector 3")]
	[UnitTitle("Move Towards")]
	public sealed class Vector3MoveTowards : MoveTowards<Vector3>
	{
		// Token: 0x1700029D RID: 669
		// (get) Token: 0x06000760 RID: 1888 RVA: 0x0000DEA0 File Offset: 0x0000C0A0
		protected override Vector3 defaultCurrent
		{
			get
			{
				return Vector3.zero;
			}
		}

		// Token: 0x1700029E RID: 670
		// (get) Token: 0x06000761 RID: 1889 RVA: 0x0000DEA7 File Offset: 0x0000C0A7
		protected override Vector3 defaultTarget
		{
			get
			{
				return Vector3.one;
			}
		}

		// Token: 0x06000762 RID: 1890 RVA: 0x0000DEAE File Offset: 0x0000C0AE
		public override Vector3 Operation(Vector3 current, Vector3 target, float maxDelta)
		{
			return Vector3.MoveTowards(current, target, maxDelta);
		}
	}
}
