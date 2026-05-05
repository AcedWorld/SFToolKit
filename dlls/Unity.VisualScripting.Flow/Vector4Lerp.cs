using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200011D RID: 285
	[UnitCategory("Math/Vector 4")]
	[UnitTitle("Lerp")]
	public sealed class Vector4Lerp : Lerp<Vector4>
	{
		// Token: 0x170002A6 RID: 678
		// (get) Token: 0x06000789 RID: 1929 RVA: 0x0000E17F File Offset: 0x0000C37F
		protected override Vector4 defaultA
		{
			get
			{
				return Vector4.zero;
			}
		}

		// Token: 0x170002A7 RID: 679
		// (get) Token: 0x0600078A RID: 1930 RVA: 0x0000E186 File Offset: 0x0000C386
		protected override Vector4 defaultB
		{
			get
			{
				return Vector4.one;
			}
		}

		// Token: 0x0600078B RID: 1931 RVA: 0x0000E18D File Offset: 0x0000C38D
		public override Vector4 Operation(Vector4 a, Vector4 b, float t)
		{
			return Vector4.Lerp(a, b, t);
		}
	}
}
