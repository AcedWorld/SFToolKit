using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x020000C2 RID: 194
	[UnitCategory("Logic")]
	[UnitOrder(6)]
	public sealed class NotEqual : BinaryComparisonUnit
	{
		// Token: 0x060005C8 RID: 1480 RVA: 0x0000BD84 File Offset: 0x00009F84
		public NotEqual()
		{
			base.numeric = false;
		}

		// Token: 0x1700022A RID: 554
		// (get) Token: 0x060005C9 RID: 1481 RVA: 0x0000BD93 File Offset: 0x00009F93
		protected override string outputKey
		{
			get
			{
				return "notEqual";
			}
		}

		// Token: 0x1700022B RID: 555
		// (get) Token: 0x060005CA RID: 1482 RVA: 0x0000BD9A File Offset: 0x00009F9A
		[DoNotSerialize]
		[PortLabel("A ≠ B")]
		[PortKey("notEqual")]
		public override ValueOutput comparison
		{
			get
			{
				return base.comparison;
			}
		}

		// Token: 0x060005CB RID: 1483 RVA: 0x0000BDA2 File Offset: 0x00009FA2
		protected override bool NumericComparison(float a, float b)
		{
			return !Mathf.Approximately(a, b);
		}

		// Token: 0x060005CC RID: 1484 RVA: 0x0000BDAE File Offset: 0x00009FAE
		protected override bool GenericComparison(object a, object b)
		{
			return OperatorUtility.NotEqual(a, b);
		}
	}
}
