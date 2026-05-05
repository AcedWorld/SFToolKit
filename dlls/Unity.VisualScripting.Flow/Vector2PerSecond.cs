using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x020000FE RID: 254
	[UnitCategory("Math/Vector 2")]
	[UnitTitle("Per Second")]
	public sealed class Vector2PerSecond : PerSecond<Vector2>
	{
		// Token: 0x0600072E RID: 1838 RVA: 0x0000DAFC File Offset: 0x0000BCFC
		public override Vector2 Operation(Vector2 input)
		{
			return input * Time.deltaTime;
		}
	}
}
