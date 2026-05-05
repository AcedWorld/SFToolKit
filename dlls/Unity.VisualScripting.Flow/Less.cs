using System;

namespace Unity.VisualScripting
{
	// Token: 0x020000BE RID: 190
	[UnitCategory("Logic")]
	[UnitOrder(9)]
	public sealed class Less : BinaryComparisonUnit
	{
		// Token: 0x17000223 RID: 547
		// (get) Token: 0x060005B0 RID: 1456 RVA: 0x0000BBD7 File Offset: 0x00009DD7
		[PortLabel("A < B")]
		public override ValueOutput comparison
		{
			get
			{
				return base.comparison;
			}
		}

		// Token: 0x060005B1 RID: 1457 RVA: 0x0000BBDF File Offset: 0x00009DDF
		protected override bool NumericComparison(float a, float b)
		{
			return a < b;
		}

		// Token: 0x060005B2 RID: 1458 RVA: 0x0000BBE5 File Offset: 0x00009DE5
		protected override bool GenericComparison(object a, object b)
		{
			return OperatorUtility.LessThan(a, b);
		}
	}
}
