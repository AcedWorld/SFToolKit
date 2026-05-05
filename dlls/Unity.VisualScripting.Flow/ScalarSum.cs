using System;
using System.Collections.Generic;
using System.Linq;

namespace Unity.VisualScripting
{
	// Token: 0x020000ED RID: 237
	[UnitCategory("Math/Scalar")]
	[UnitTitle("Add")]
	public sealed class ScalarSum : Sum<float>, IDefaultValue<float>
	{
		// Token: 0x17000282 RID: 642
		// (get) Token: 0x060006EE RID: 1774 RVA: 0x0000D5BE File Offset: 0x0000B7BE
		[DoNotSerialize]
		public float defaultValue
		{
			get
			{
				return 1f;
			}
		}

		// Token: 0x060006EF RID: 1775 RVA: 0x0000D5C5 File Offset: 0x0000B7C5
		public override float Operation(float a, float b)
		{
			return a + b;
		}

		// Token: 0x060006F0 RID: 1776 RVA: 0x0000D5CA File Offset: 0x0000B7CA
		public override float Operation(IEnumerable<float> values)
		{
			return values.Sum();
		}
	}
}
