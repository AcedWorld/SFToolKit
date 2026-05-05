using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x020000F3 RID: 243
	[UnitCategory("Math/Vector 2")]
	[UnitTitle("Average")]
	public sealed class Vector2Average : Average<Vector2>
	{
		// Token: 0x0600070C RID: 1804 RVA: 0x0000D890 File Offset: 0x0000BA90
		public override Vector2 Operation(Vector2 a, Vector2 b)
		{
			return (a + b) / 2f;
		}

		// Token: 0x0600070D RID: 1805 RVA: 0x0000D8A4 File Offset: 0x0000BAA4
		public override Vector2 Operation(IEnumerable<Vector2> values)
		{
			Vector2 vector = Vector2.zero;
			int num = 0;
			foreach (Vector2 b in values)
			{
				vector += b;
				num++;
			}
			vector /= (float)num;
			return vector;
		}
	}
}
