using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200010D RID: 269
	[UnitCategory("Math/Vector 3")]
	[UnitTitle("Minimum")]
	public sealed class Vector3Minimum : Minimum<Vector3>
	{
		// Token: 0x06000759 RID: 1881 RVA: 0x0000DDEC File Offset: 0x0000BFEC
		public override Vector3 Operation(Vector3 a, Vector3 b)
		{
			return Vector3.Min(a, b);
		}

		// Token: 0x0600075A RID: 1882 RVA: 0x0000DDF8 File Offset: 0x0000BFF8
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
					vector = Vector3.Min(vector, vector2);
				}
			}
			return vector;
		}
	}
}
