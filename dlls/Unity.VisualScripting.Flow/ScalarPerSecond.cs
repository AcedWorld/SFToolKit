using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x020000E9 RID: 233
	[UnitCategory("Math/Scalar")]
	[UnitTitle("Per Second")]
	public sealed class ScalarPerSecond : PerSecond<float>
	{
		// Token: 0x060006DB RID: 1755 RVA: 0x0000D476 File Offset: 0x0000B676
		public override float Operation(float input)
		{
			return input * Time.deltaTime;
		}
	}
}
