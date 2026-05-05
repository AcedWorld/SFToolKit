using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000118 RID: 280
	[UnitCategory("Math/Vector 4")]
	[UnitTitle("Absolute")]
	public sealed class Vector4Absolute : Absolute<Vector4>
	{
		// Token: 0x0600077C RID: 1916 RVA: 0x0000E054 File Offset: 0x0000C254
		protected override Vector4 Operation(Vector4 input)
		{
			return new Vector4(Mathf.Abs(input.x), Mathf.Abs(input.y), Mathf.Abs(input.z), Mathf.Abs(input.w));
		}
	}
}
