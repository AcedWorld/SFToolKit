using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x020000F2 RID: 242
	[UnitCategory("Math/Vector 2")]
	[UnitTitle("Angle")]
	public sealed class Vector2Angle : Angle<Vector2>
	{
		// Token: 0x0600070A RID: 1802 RVA: 0x0000D87F File Offset: 0x0000BA7F
		public override float Operation(Vector2 a, Vector2 b)
		{
			return Vector2.Angle(a, b);
		}
	}
}
