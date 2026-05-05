using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x020000F5 RID: 245
	[UnitCategory("Math/Vector 2")]
	[UnitTitle("Divide")]
	public sealed class Vector2Divide : Divide<Vector2>
	{
		// Token: 0x1700028A RID: 650
		// (get) Token: 0x06000711 RID: 1809 RVA: 0x0000D91D File Offset: 0x0000BB1D
		protected override Vector2 defaultDividend
		{
			get
			{
				return Vector2.zero;
			}
		}

		// Token: 0x1700028B RID: 651
		// (get) Token: 0x06000712 RID: 1810 RVA: 0x0000D924 File Offset: 0x0000BB24
		protected override Vector2 defaultDivisor
		{
			get
			{
				return Vector2.zero;
			}
		}

		// Token: 0x06000713 RID: 1811 RVA: 0x0000D92B File Offset: 0x0000BB2B
		public override Vector2 Operation(Vector2 a, Vector2 b)
		{
			return new Vector2(a.x / b.x, a.y / b.y);
		}
	}
}
