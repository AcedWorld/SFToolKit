using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x020000DE RID: 222
	[UnitCategory("Math/Scalar")]
	[UnitTitle("Absolute")]
	public sealed class ScalarAbsolute : Absolute<float>
	{
		// Token: 0x060006B2 RID: 1714 RVA: 0x0000D29B File Offset: 0x0000B49B
		protected override float Operation(float input)
		{
			return Mathf.Abs(input);
		}
	}
}
