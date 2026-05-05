using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x020000FD RID: 253
	[UnitCategory("Math/Vector 2")]
	[UnitTitle("Normalize")]
	public sealed class Vector2Normalize : Normalize<Vector2>
	{
		// Token: 0x0600072C RID: 1836 RVA: 0x0000DAEB File Offset: 0x0000BCEB
		public override Vector2 Operation(Vector2 input)
		{
			return input.normalized;
		}
	}
}
