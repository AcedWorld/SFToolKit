using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x020000B9 RID: 185
	[UnitCategory("Logic")]
	[UnitOrder(5)]
	public sealed class Equal : BinaryComparisonUnit
	{
		// Token: 0x0600058E RID: 1422 RVA: 0x0000B942 File Offset: 0x00009B42
		public Equal()
		{
			base.numeric = false;
		}

		// Token: 0x17000218 RID: 536
		// (get) Token: 0x0600058F RID: 1423 RVA: 0x0000B951 File Offset: 0x00009B51
		protected override string outputKey
		{
			get
			{
				return "equal";
			}
		}

		// Token: 0x17000219 RID: 537
		// (get) Token: 0x06000590 RID: 1424 RVA: 0x0000B958 File Offset: 0x00009B58
		[DoNotSerialize]
		[PortLabel("A = B")]
		[PortKey("equal")]
		public override ValueOutput comparison
		{
			get
			{
				return base.comparison;
			}
		}

		// Token: 0x06000591 RID: 1425 RVA: 0x0000B960 File Offset: 0x00009B60
		protected override bool NumericComparison(float a, float b)
		{
			return Mathf.Approximately(a, b);
		}

		// Token: 0x06000592 RID: 1426 RVA: 0x0000B969 File Offset: 0x00009B69
		protected override bool GenericComparison(object a, object b)
		{
			return OperatorUtility.Equal(a, b);
		}
	}
}
