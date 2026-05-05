using System;

namespace Unity.VisualScripting
{
	// Token: 0x020000EC RID: 236
	[UnitCategory("Math/Scalar")]
	[UnitTitle("Subtract")]
	public sealed class ScalarSubtract : Subtract<float>
	{
		// Token: 0x17000280 RID: 640
		// (get) Token: 0x060006EA RID: 1770 RVA: 0x0000D5A3 File Offset: 0x0000B7A3
		protected override float defaultMinuend
		{
			get
			{
				return 1f;
			}
		}

		// Token: 0x17000281 RID: 641
		// (get) Token: 0x060006EB RID: 1771 RVA: 0x0000D5AA File Offset: 0x0000B7AA
		protected override float defaultSubtrahend
		{
			get
			{
				return 1f;
			}
		}

		// Token: 0x060006EC RID: 1772 RVA: 0x0000D5B1 File Offset: 0x0000B7B1
		public override float Operation(float a, float b)
		{
			return a - b;
		}
	}
}
