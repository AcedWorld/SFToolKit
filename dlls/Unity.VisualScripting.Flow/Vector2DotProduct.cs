using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x020000F6 RID: 246
	[UnitCategory("Math/Vector 2")]
	[UnitTitle("Dot Product")]
	public sealed class Vector2DotProduct : DotProduct<Vector2>
	{
		// Token: 0x06000715 RID: 1813 RVA: 0x0000D954 File Offset: 0x0000BB54
		public override float Operation(Vector2 a, Vector2 b)
		{
			return Vector2.Dot(a, b);
		}
	}
}
