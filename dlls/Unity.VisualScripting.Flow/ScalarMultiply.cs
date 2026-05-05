using System;

namespace Unity.VisualScripting
{
	// Token: 0x020000E7 RID: 231
	[UnitCategory("Math/Scalar")]
	[UnitTitle("Multiply")]
	public sealed class ScalarMultiply : Multiply<float>
	{
		// Token: 0x1700027C RID: 636
		// (get) Token: 0x060006D6 RID: 1750 RVA: 0x0000D442 File Offset: 0x0000B642
		protected override float defaultB
		{
			get
			{
				return 1f;
			}
		}

		// Token: 0x060006D7 RID: 1751 RVA: 0x0000D449 File Offset: 0x0000B649
		public override float Operation(float a, float b)
		{
			return a * b;
		}
	}
}
