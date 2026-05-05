using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000119 RID: 281
	[UnitCategory("Math/Vector 4")]
	[UnitTitle("Average")]
	public sealed class Vector4Average : Average<Vector4>
	{
		// Token: 0x0600077E RID: 1918 RVA: 0x0000E08F File Offset: 0x0000C28F
		public override Vector4 Operation(Vector4 a, Vector4 b)
		{
			return (a + b) / 2f;
		}

		// Token: 0x0600077F RID: 1919 RVA: 0x0000E0A4 File Offset: 0x0000C2A4
		public override Vector4 Operation(IEnumerable<Vector4> values)
		{
			Vector4 vector = Vector4.zero;
			int num = 0;
			foreach (Vector4 b in values)
			{
				vector += b;
				num++;
			}
			vector /= (float)num;
			return vector;
		}
	}
}
