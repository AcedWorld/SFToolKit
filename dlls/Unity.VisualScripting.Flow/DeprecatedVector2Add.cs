using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x020000F0 RID: 240
	[UnitCategory("Math/Vector 2")]
	[UnitTitle("Add")]
	[Obsolete("Use the new \"Add (Math/Vector 2)\" node instead.")]
	[RenamedFrom("Bolt.Vector2Add")]
	[RenamedFrom("Unity.VisualScripting.Vector2Add")]
	public sealed class DeprecatedVector2Add : Add<Vector2>
	{
		// Token: 0x17000289 RID: 649
		// (get) Token: 0x06000705 RID: 1797 RVA: 0x0000D842 File Offset: 0x0000BA42
		protected override Vector2 defaultB
		{
			get
			{
				return Vector2.zero;
			}
		}

		// Token: 0x06000706 RID: 1798 RVA: 0x0000D849 File Offset: 0x0000BA49
		public override Vector2 Operation(Vector2 a, Vector2 b)
		{
			return a + b;
		}
	}
}
