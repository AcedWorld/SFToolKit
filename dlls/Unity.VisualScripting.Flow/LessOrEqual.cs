using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x020000BF RID: 191
	[UnitCategory("Logic")]
	[UnitOrder(10)]
	public sealed class LessOrEqual : BinaryComparisonUnit
	{
		// Token: 0x17000224 RID: 548
		// (get) Token: 0x060005B4 RID: 1460 RVA: 0x0000BBF6 File Offset: 0x00009DF6
		[PortLabel("A ≤ B")]
		public override ValueOutput comparison
		{
			get
			{
				return base.comparison;
			}
		}

		// Token: 0x060005B5 RID: 1461 RVA: 0x0000BBFE File Offset: 0x00009DFE
		protected override bool NumericComparison(float a, float b)
		{
			return a < b || Mathf.Approximately(a, b);
		}

		// Token: 0x060005B6 RID: 1462 RVA: 0x0000BC0D File Offset: 0x00009E0D
		protected override bool GenericComparison(object a, object b)
		{
			return OperatorUtility.LessThanOrEqual(a, b);
		}
	}
}
