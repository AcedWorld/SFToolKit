using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x020000E3 RID: 227
	[UnitCategory("Math/Scalar")]
	[UnitTitle("Maximum")]
	public sealed class ScalarMaximum : Maximum<float>
	{
		// Token: 0x060006C8 RID: 1736 RVA: 0x0000D3D5 File Offset: 0x0000B5D5
		public override float Operation(float a, float b)
		{
			return Mathf.Max(a, b);
		}

		// Token: 0x060006C9 RID: 1737 RVA: 0x0000D3DE File Offset: 0x0000B5DE
		public override float Operation(IEnumerable<float> values)
		{
			return values.Max();
		}
	}
}
