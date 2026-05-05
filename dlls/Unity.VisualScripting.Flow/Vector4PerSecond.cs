using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000124 RID: 292
	[UnitCategory("Math/Vector 4")]
	[UnitTitle("Per Second")]
	public sealed class Vector4PerSecond : PerSecond<Vector4>
	{
		// Token: 0x060007A0 RID: 1952 RVA: 0x0000E347 File Offset: 0x0000C547
		public override Vector4 Operation(Vector4 input)
		{
			return input * Time.deltaTime;
		}
	}
}
