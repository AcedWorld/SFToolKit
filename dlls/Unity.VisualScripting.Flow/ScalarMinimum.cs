using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x020000E4 RID: 228
	[UnitCategory("Math/Scalar")]
	[UnitTitle("Minimum")]
	public sealed class ScalarMinimum : Minimum<float>
	{
		// Token: 0x060006CB RID: 1739 RVA: 0x0000D3EE File Offset: 0x0000B5EE
		public override float Operation(float a, float b)
		{
			return Mathf.Min(a, b);
		}

		// Token: 0x060006CC RID: 1740 RVA: 0x0000D3F7 File Offset: 0x0000B5F7
		public override float Operation(IEnumerable<float> values)
		{
			return values.Min();
		}
	}
}
