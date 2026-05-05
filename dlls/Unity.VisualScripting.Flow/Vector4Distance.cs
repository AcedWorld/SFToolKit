using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200011A RID: 282
	[UnitCategory("Math/Vector 4")]
	[UnitTitle("Distance")]
	public sealed class Vector4Distance : Distance<Vector4>
	{
		// Token: 0x06000781 RID: 1921 RVA: 0x0000E10C File Offset: 0x0000C30C
		public override float Operation(Vector4 a, Vector4 b)
		{
			return Vector4.Distance(a, b);
		}
	}
}
