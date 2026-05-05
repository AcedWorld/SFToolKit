using System;
using System.Collections.Generic;
using System.Linq;

namespace Unity.VisualScripting
{
	// Token: 0x020000DF RID: 223
	[UnitCategory("Math/Scalar")]
	[UnitTitle("Average")]
	public sealed class ScalarAverage : Average<float>
	{
		// Token: 0x060006B4 RID: 1716 RVA: 0x0000D2AB File Offset: 0x0000B4AB
		public override float Operation(float a, float b)
		{
			return (a + b) / 2f;
		}

		// Token: 0x060006B5 RID: 1717 RVA: 0x0000D2B6 File Offset: 0x0000B4B6
		public override float Operation(IEnumerable<float> values)
		{
			return values.Average();
		}
	}
}
