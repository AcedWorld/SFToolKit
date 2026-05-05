using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000111 RID: 273
	[UnitCategory("Math/Vector 3")]
	[UnitTitle("Normalize")]
	public sealed class Vector3Normalize : Normalize<Vector3>
	{
		// Token: 0x06000767 RID: 1895 RVA: 0x0000DEFD File Offset: 0x0000C0FD
		public override Vector3 Operation(Vector3 input)
		{
			return Vector3.Normalize(input);
		}
	}
}
