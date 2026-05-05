using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x020000F1 RID: 241
	[UnitCategory("Math/Vector 2")]
	[UnitTitle("Absolute")]
	public sealed class Vector2Absolute : Absolute<Vector2>
	{
		// Token: 0x06000708 RID: 1800 RVA: 0x0000D85A File Offset: 0x0000BA5A
		protected override Vector2 Operation(Vector2 input)
		{
			return new Vector2(Mathf.Abs(input.x), Mathf.Abs(input.y));
		}
	}
}
