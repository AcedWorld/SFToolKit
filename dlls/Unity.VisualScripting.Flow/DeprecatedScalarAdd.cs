using System;

namespace Unity.VisualScripting
{
	// Token: 0x020000DD RID: 221
	[UnitCategory("Math/Scalar")]
	[UnitTitle("Add")]
	[Obsolete("Use the new \"Add (Math/Scalar)\" node instead.")]
	[RenamedFrom("Bolt.ScalarAdd")]
	[RenamedFrom("Unity.VisualScripting.ScalarAdd")]
	public sealed class DeprecatedScalarAdd : Add<float>
	{
		// Token: 0x17000270 RID: 624
		// (get) Token: 0x060006AF RID: 1711 RVA: 0x0000D287 File Offset: 0x0000B487
		protected override float defaultB
		{
			get
			{
				return 1f;
			}
		}

		// Token: 0x060006B0 RID: 1712 RVA: 0x0000D28E File Offset: 0x0000B48E
		public override float Operation(float a, float b)
		{
			return a + b;
		}
	}
}
