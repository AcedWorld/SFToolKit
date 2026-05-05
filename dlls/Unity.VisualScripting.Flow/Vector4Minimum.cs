using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200011F RID: 287
	[UnitCategory("Math/Vector 4")]
	[UnitTitle("Minimum")]
	public sealed class Vector4Minimum : Minimum<Vector4>
	{
		// Token: 0x06000790 RID: 1936 RVA: 0x0000E20C File Offset: 0x0000C40C
		public override Vector4 Operation(Vector4 a, Vector4 b)
		{
			return Vector4.Min(a, b);
		}

		// Token: 0x06000791 RID: 1937 RVA: 0x0000E218 File Offset: 0x0000C418
		public override Vector4 Operation(IEnumerable<Vector4> values)
		{
			bool flag = false;
			Vector4 vector = Vector4.zero;
			foreach (Vector4 vector2 in values)
			{
				if (!flag)
				{
					vector = vector2;
					flag = true;
				}
				else
				{
					vector = Vector4.Min(vector, vector2);
				}
			}
			return vector;
		}
	}
}
