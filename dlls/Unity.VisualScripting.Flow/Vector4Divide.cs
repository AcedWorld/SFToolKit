using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200011B RID: 283
	[UnitCategory("Math/Vector 4")]
	[UnitTitle("Divide")]
	public sealed class Vector4Divide : Divide<Vector4>
	{
		// Token: 0x170002A4 RID: 676
		// (get) Token: 0x06000783 RID: 1923 RVA: 0x0000E11D File Offset: 0x0000C31D
		protected override Vector4 defaultDividend
		{
			get
			{
				return Vector4.zero;
			}
		}

		// Token: 0x170002A5 RID: 677
		// (get) Token: 0x06000784 RID: 1924 RVA: 0x0000E124 File Offset: 0x0000C324
		protected override Vector4 defaultDivisor
		{
			get
			{
				return Vector4.zero;
			}
		}

		// Token: 0x06000785 RID: 1925 RVA: 0x0000E12B File Offset: 0x0000C32B
		public override Vector4 Operation(Vector4 a, Vector4 b)
		{
			return new Vector4(a.x / b.x, a.y / b.y, a.z / b.z, a.w / b.w);
		}
	}
}
