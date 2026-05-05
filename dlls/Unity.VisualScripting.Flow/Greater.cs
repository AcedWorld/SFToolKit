using System;

namespace Unity.VisualScripting
{
	// Token: 0x020000BC RID: 188
	[UnitCategory("Logic")]
	[UnitOrder(11)]
	public sealed class Greater : BinaryComparisonUnit
	{
		// Token: 0x17000221 RID: 545
		// (get) Token: 0x060005A8 RID: 1448 RVA: 0x0000BB90 File Offset: 0x00009D90
		[PortLabel("A > B")]
		public override ValueOutput comparison
		{
			get
			{
				return base.comparison;
			}
		}

		// Token: 0x060005A9 RID: 1449 RVA: 0x0000BB98 File Offset: 0x00009D98
		protected override bool NumericComparison(float a, float b)
		{
			return a > b;
		}

		// Token: 0x060005AA RID: 1450 RVA: 0x0000BB9E File Offset: 0x00009D9E
		protected override bool GenericComparison(object a, object b)
		{
			return OperatorUtility.GreaterThan(a, b);
		}
	}
}
