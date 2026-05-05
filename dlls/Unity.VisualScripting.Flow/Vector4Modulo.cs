using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000120 RID: 288
	[UnitCategory("Math/Vector 4")]
	[UnitTitle("Modulo")]
	public sealed class Vector4Modulo : Modulo<Vector4>
	{
		// Token: 0x170002A8 RID: 680
		// (get) Token: 0x06000793 RID: 1939 RVA: 0x0000E27C File Offset: 0x0000C47C
		protected override Vector4 defaultDividend
		{
			get
			{
				return Vector4.zero;
			}
		}

		// Token: 0x170002A9 RID: 681
		// (get) Token: 0x06000794 RID: 1940 RVA: 0x0000E283 File Offset: 0x0000C483
		protected override Vector4 defaultDivisor
		{
			get
			{
				return Vector4.zero;
			}
		}

		// Token: 0x06000795 RID: 1941 RVA: 0x0000E28A File Offset: 0x0000C48A
		public override Vector4 Operation(Vector4 a, Vector4 b)
		{
			return new Vector4(a.x % b.x, a.y % b.y, a.z % b.z, a.w % b.w);
		}
	}
}
