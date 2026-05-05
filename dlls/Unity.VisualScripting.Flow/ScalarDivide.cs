using System;

namespace Unity.VisualScripting
{
	// Token: 0x020000E0 RID: 224
	[UnitCategory("Math/Scalar")]
	[UnitTitle("Divide")]
	public sealed class ScalarDivide : Divide<float>
	{
		// Token: 0x17000271 RID: 625
		// (get) Token: 0x060006B7 RID: 1719 RVA: 0x0000D2C6 File Offset: 0x0000B4C6
		protected override float defaultDividend
		{
			get
			{
				return 1f;
			}
		}

		// Token: 0x17000272 RID: 626
		// (get) Token: 0x060006B8 RID: 1720 RVA: 0x0000D2CD File Offset: 0x0000B4CD
		protected override float defaultDivisor
		{
			get
			{
				return 1f;
			}
		}

		// Token: 0x060006B9 RID: 1721 RVA: 0x0000D2D4 File Offset: 0x0000B4D4
		public override float Operation(float a, float b)
		{
			return a / b;
		}
	}
}
