using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x020000FF RID: 255
	[UnitCategory("Math/Vector 2")]
	[UnitTitle("Project")]
	public sealed class Vector2Project : Project<Vector2>
	{
		// Token: 0x06000730 RID: 1840 RVA: 0x0000DB11 File Offset: 0x0000BD11
		public override Vector2 Operation(Vector2 a, Vector2 b)
		{
			return Vector2.Dot(a, b) * b.normalized;
		}
	}
}
