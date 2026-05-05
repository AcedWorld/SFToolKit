using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000110 RID: 272
	[UnitCategory("Math/Vector 3")]
	[UnitTitle("Multiply")]
	public sealed class Vector3Multiply : Multiply<Vector3>
	{
		// Token: 0x1700029F RID: 671
		// (get) Token: 0x06000764 RID: 1892 RVA: 0x0000DEC0 File Offset: 0x0000C0C0
		protected override Vector3 defaultB
		{
			get
			{
				return Vector3.zero;
			}
		}

		// Token: 0x06000765 RID: 1893 RVA: 0x0000DEC7 File Offset: 0x0000C0C7
		public override Vector3 Operation(Vector3 a, Vector3 b)
		{
			return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
		}
	}
}
