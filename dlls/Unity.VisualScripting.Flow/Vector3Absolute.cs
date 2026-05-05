using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000104 RID: 260
	[UnitCategory("Math/Vector 3")]
	[UnitTitle("Absolute")]
	public sealed class Vector3Absolute : Absolute<Vector3>
	{
		// Token: 0x06000741 RID: 1857 RVA: 0x0000DC2C File Offset: 0x0000BE2C
		protected override Vector3 Operation(Vector3 input)
		{
			return new Vector3(Mathf.Abs(input.x), Mathf.Abs(input.y), Mathf.Abs(input.z));
		}
	}
}
