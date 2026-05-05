using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200011E RID: 286
	[UnitCategory("Math/Vector 4")]
	[UnitTitle("Maximum")]
	public sealed class Vector4Maximum : Maximum<Vector4>
	{
		// Token: 0x0600078D RID: 1933 RVA: 0x0000E19F File Offset: 0x0000C39F
		public override Vector4 Operation(Vector4 a, Vector4 b)
		{
			return Vector4.Max(a, b);
		}

		// Token: 0x0600078E RID: 1934 RVA: 0x0000E1A8 File Offset: 0x0000C3A8
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
					vector = Vector4.Max(vector, vector2);
				}
			}
			return vector;
		}
	}
}
