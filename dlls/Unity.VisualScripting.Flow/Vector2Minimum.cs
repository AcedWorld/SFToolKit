using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x020000F9 RID: 249
	[UnitCategory("Math/Vector 2")]
	[UnitTitle("Minimum")]
	public sealed class Vector2Minimum : Minimum<Vector2>
	{
		// Token: 0x0600071E RID: 1822 RVA: 0x0000D9F4 File Offset: 0x0000BBF4
		public override Vector2 Operation(Vector2 a, Vector2 b)
		{
			return Vector2.Min(a, b);
		}

		// Token: 0x0600071F RID: 1823 RVA: 0x0000DA00 File Offset: 0x0000BC00
		public override Vector2 Operation(IEnumerable<Vector2> values)
		{
			bool flag = false;
			Vector2 vector = Vector2.zero;
			foreach (Vector2 vector2 in values)
			{
				if (!flag)
				{
					vector = vector2;
					flag = true;
				}
				else
				{
					vector = Vector2.Min(vector, vector2);
				}
			}
			return vector;
		}
	}
}
