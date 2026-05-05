using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x020000F8 RID: 248
	[UnitCategory("Math/Vector 2")]
	[UnitTitle("Maximum")]
	public sealed class Vector2Maximum : Maximum<Vector2>
	{
		// Token: 0x0600071B RID: 1819 RVA: 0x0000D985 File Offset: 0x0000BB85
		public override Vector2 Operation(Vector2 a, Vector2 b)
		{
			return Vector2.Max(a, b);
		}

		// Token: 0x0600071C RID: 1820 RVA: 0x0000D990 File Offset: 0x0000BB90
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
					vector = Vector2.Max(vector, vector2);
				}
			}
			return vector;
		}
	}
}
