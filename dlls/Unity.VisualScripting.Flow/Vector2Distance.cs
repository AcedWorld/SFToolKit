using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x020000F4 RID: 244
	[UnitCategory("Math/Vector 2")]
	[UnitTitle("Distance")]
	public sealed class Vector2Distance : Distance<Vector2>
	{
		// Token: 0x0600070F RID: 1807 RVA: 0x0000D90C File Offset: 0x0000BB0C
		public override float Operation(Vector2 a, Vector2 b)
		{
			return Vector2.Distance(a, b);
		}
	}
}
