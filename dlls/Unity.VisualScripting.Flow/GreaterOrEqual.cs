using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x020000BD RID: 189
	[UnitCategory("Logic")]
	[UnitOrder(12)]
	public sealed class GreaterOrEqual : BinaryComparisonUnit
	{
		// Token: 0x17000222 RID: 546
		// (get) Token: 0x060005AC RID: 1452 RVA: 0x0000BBAF File Offset: 0x00009DAF
		[PortLabel("A ≥ B")]
		public override ValueOutput comparison
		{
			get
			{
				return base.comparison;
			}
		}

		// Token: 0x060005AD RID: 1453 RVA: 0x0000BBB7 File Offset: 0x00009DB7
		protected override bool NumericComparison(float a, float b)
		{
			return a > b || Mathf.Approximately(a, b);
		}

		// Token: 0x060005AE RID: 1454 RVA: 0x0000BBC6 File Offset: 0x00009DC6
		protected override bool GenericComparison(object a, object b)
		{
			return OperatorUtility.GreaterThanOrEqual(a, b);
		}
	}
}
