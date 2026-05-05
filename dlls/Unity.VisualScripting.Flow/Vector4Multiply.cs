using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000122 RID: 290
	[UnitCategory("Math/Vector 4")]
	[UnitTitle("Multiply")]
	public sealed class Vector4Multiply : Multiply<Vector4>
	{
		// Token: 0x170002AC RID: 684
		// (get) Token: 0x0600079B RID: 1947 RVA: 0x0000E2ED File Offset: 0x0000C4ED
		protected override Vector4 defaultB
		{
			get
			{
				return Vector4.zero;
			}
		}

		// Token: 0x0600079C RID: 1948 RVA: 0x0000E2F4 File Offset: 0x0000C4F4
		public override Vector4 Operation(Vector4 a, Vector4 b)
		{
			return new Vector4(a.x * b.x, a.y * b.y, a.z * b.z, a.w * b.w);
		}
	}
}
