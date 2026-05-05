using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200010C RID: 268
	[UnitCategory("Math/Vector 3")]
	[UnitTitle("Maximum")]
	public sealed class Vector3Maximum : Maximum<Vector3>
	{
		// Token: 0x06000756 RID: 1878 RVA: 0x0000DD7F File Offset: 0x0000BF7F
		public override Vector3 Operation(Vector3 a, Vector3 b)
		{
			return Vector3.Max(a, b);
		}

		// Token: 0x06000757 RID: 1879 RVA: 0x0000DD88 File Offset: 0x0000BF88
		public override Vector3 Operation(IEnumerable<Vector3> values)
		{
			bool flag = false;
			Vector3 vector = Vector3.zero;
			foreach (Vector3 vector2 in values)
			{
				if (!flag)
				{
					vector = vector2;
					flag = true;
				}
				else
				{
					vector = Vector3.Max(vector, vector2);
				}
			}
			return vector;
		}
	}
}
