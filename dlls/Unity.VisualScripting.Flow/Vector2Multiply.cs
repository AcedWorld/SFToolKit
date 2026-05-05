using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x020000FC RID: 252
	[UnitCategory("Math/Vector 2")]
	[UnitTitle("Multiply")]
	public sealed class Vector2Multiply : Multiply<Vector2>
	{
		// Token: 0x17000292 RID: 658
		// (get) Token: 0x06000729 RID: 1833 RVA: 0x0000DABB File Offset: 0x0000BCBB
		protected override Vector2 defaultB
		{
			get
			{
				return Vector2.zero;
			}
		}

		// Token: 0x0600072A RID: 1834 RVA: 0x0000DAC2 File Offset: 0x0000BCC2
		public override Vector2 Operation(Vector2 a, Vector2 b)
		{
			return new Vector2(a.x * b.x, a.y * b.y);
		}
	}
}
