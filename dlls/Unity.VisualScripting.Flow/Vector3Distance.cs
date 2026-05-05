using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000108 RID: 264
	[UnitCategory("Math/Vector 3")]
	[UnitTitle("Distance")]
	public sealed class Vector3Distance : Distance<Vector3>
	{
		// Token: 0x0600074A RID: 1866 RVA: 0x0000DCF9 File Offset: 0x0000BEF9
		public override float Operation(Vector3 a, Vector3 b)
		{
			return Vector3.Distance(a, b);
		}
	}
}
