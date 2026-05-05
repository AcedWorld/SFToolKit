using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000125 RID: 293
	[UnitCategory("Math/Vector 4")]
	[UnitTitle("Round")]
	public sealed class Vector4Round : Round<Vector4, Vector4>
	{
		// Token: 0x060007A2 RID: 1954 RVA: 0x0000E35C File Offset: 0x0000C55C
		protected override Vector4 Floor(Vector4 input)
		{
			return new Vector4(Mathf.Floor(input.x), Mathf.Floor(input.y), Mathf.Floor(input.z), Mathf.Floor(input.w));
		}

		// Token: 0x060007A3 RID: 1955 RVA: 0x0000E38F File Offset: 0x0000C58F
		protected override Vector4 AwayFromZero(Vector4 input)
		{
			return new Vector4(Mathf.Round(input.x), Mathf.Round(input.y), Mathf.Round(input.z), Mathf.Round(input.w));
		}

		// Token: 0x060007A4 RID: 1956 RVA: 0x0000E3C2 File Offset: 0x0000C5C2
		protected override Vector4 Ceiling(Vector4 input)
		{
			return new Vector4(Mathf.Ceil(input.x), Mathf.Ceil(input.y), Mathf.Ceil(input.z), Mathf.Ceil(input.w));
		}
	}
}
