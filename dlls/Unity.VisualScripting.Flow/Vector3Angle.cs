using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000105 RID: 261
	[UnitCategory("Math/Vector 3")]
	[UnitTitle("Angle")]
	public sealed class Vector3Angle : Angle<Vector3>
	{
		// Token: 0x06000743 RID: 1859 RVA: 0x0000DC5C File Offset: 0x0000BE5C
		public override float Operation(Vector3 a, Vector3 b)
		{
			return Vector3.Angle(a, b);
		}
	}
}
