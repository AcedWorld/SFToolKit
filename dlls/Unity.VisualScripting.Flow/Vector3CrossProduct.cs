using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000107 RID: 263
	[UnitCategory("Math/Vector 3")]
	[UnitTitle("Cross Product")]
	public sealed class Vector3CrossProduct : CrossProduct<Vector3>
	{
		// Token: 0x06000748 RID: 1864 RVA: 0x0000DCE8 File Offset: 0x0000BEE8
		public override Vector3 Operation(Vector3 a, Vector3 b)
		{
			return Vector3.Cross(a, b);
		}
	}
}
