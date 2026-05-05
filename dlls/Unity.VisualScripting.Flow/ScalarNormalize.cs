using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x020000E8 RID: 232
	[UnitCategory("Math/Scalar")]
	[UnitTitle("Normalize")]
	public sealed class ScalarNormalize : Normalize<float>
	{
		// Token: 0x060006D9 RID: 1753 RVA: 0x0000D456 File Offset: 0x0000B656
		public override float Operation(float input)
		{
			if (input == 0f)
			{
				return 0f;
			}
			return input / Mathf.Abs(input);
		}
	}
}
