using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x020000FA RID: 250
	[UnitCategory("Math/Vector 2")]
	[UnitTitle("Modulo")]
	public sealed class Vector2Modulo : Modulo<Vector2>
	{
		// Token: 0x1700028E RID: 654
		// (get) Token: 0x06000721 RID: 1825 RVA: 0x0000DA64 File Offset: 0x0000BC64
		protected override Vector2 defaultDividend
		{
			get
			{
				return Vector2.zero;
			}
		}

		// Token: 0x1700028F RID: 655
		// (get) Token: 0x06000722 RID: 1826 RVA: 0x0000DA6B File Offset: 0x0000BC6B
		protected override Vector2 defaultDivisor
		{
			get
			{
				return Vector2.zero;
			}
		}

		// Token: 0x06000723 RID: 1827 RVA: 0x0000DA72 File Offset: 0x0000BC72
		public override Vector2 Operation(Vector2 a, Vector2 b)
		{
			return new Vector2(a.x % b.x, a.y % b.y);
		}
	}
}
