using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000106 RID: 262
	[UnitCategory("Math/Vector 3")]
	[UnitTitle("Average")]
	public sealed class Vector3Average : Average<Vector3>
	{
		// Token: 0x06000745 RID: 1861 RVA: 0x0000DC6D File Offset: 0x0000BE6D
		public override Vector3 Operation(Vector3 a, Vector3 b)
		{
			return (a + b) / 2f;
		}

		// Token: 0x06000746 RID: 1862 RVA: 0x0000DC80 File Offset: 0x0000BE80
		public override Vector3 Operation(IEnumerable<Vector3> values)
		{
			Vector3 vector = Vector3.zero;
			int num = 0;
			foreach (Vector3 b in values)
			{
				vector += b;
				num++;
			}
			vector /= (float)num;
			return vector;
		}
	}
}
