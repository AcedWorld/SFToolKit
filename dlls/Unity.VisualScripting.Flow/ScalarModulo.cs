using System;

namespace Unity.VisualScripting
{
	// Token: 0x020000E5 RID: 229
	[UnitCategory("Math/Scalar")]
	[UnitTitle("Modulo")]
	public sealed class ScalarModulo : Modulo<float>
	{
		// Token: 0x17000278 RID: 632
		// (get) Token: 0x060006CE RID: 1742 RVA: 0x0000D407 File Offset: 0x0000B607
		protected override float defaultDividend
		{
			get
			{
				return 1f;
			}
		}

		// Token: 0x17000279 RID: 633
		// (get) Token: 0x060006CF RID: 1743 RVA: 0x0000D40E File Offset: 0x0000B60E
		protected override float defaultDivisor
		{
			get
			{
				return 1f;
			}
		}

		// Token: 0x060006D0 RID: 1744 RVA: 0x0000D415 File Offset: 0x0000B615
		public override float Operation(float a, float b)
		{
			return a % b;
		}
	}
}
