using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000117 RID: 279
	[UnitCategory("Math/Vector 4")]
	[UnitTitle("Add")]
	[Obsolete("Use the new \"Add (Math/Vector 4)\" instead.")]
	[RenamedFrom("Bolt.Vector4Add")]
	[RenamedFrom("Unity.VisualScripting.Vector4Add")]
	public sealed class DeprecatedVector4Add : Add<Vector4>
	{
		// Token: 0x170002A3 RID: 675
		// (get) Token: 0x06000779 RID: 1913 RVA: 0x0000E03C File Offset: 0x0000C23C
		protected override Vector4 defaultB
		{
			get
			{
				return Vector4.zero;
			}
		}

		// Token: 0x0600077A RID: 1914 RVA: 0x0000E043 File Offset: 0x0000C243
		public override Vector4 Operation(Vector4 a, Vector4 b)
		{
			return a + b;
		}
	}
}
