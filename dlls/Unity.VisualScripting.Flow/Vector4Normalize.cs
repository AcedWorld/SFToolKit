using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000123 RID: 291
	[UnitCategory("Math/Vector 4")]
	[UnitTitle("Normalize")]
	public sealed class Vector4Normalize : Normalize<Vector4>
	{
		// Token: 0x0600079E RID: 1950 RVA: 0x0000E337 File Offset: 0x0000C537
		public override Vector4 Operation(Vector4 input)
		{
			return Vector4.Normalize(input);
		}
	}
}
