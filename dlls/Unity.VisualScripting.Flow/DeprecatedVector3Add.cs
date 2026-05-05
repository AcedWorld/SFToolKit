using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000103 RID: 259
	[UnitCategory("Math/Vector 3")]
	[UnitTitle("Add")]
	[Obsolete("Use the new \"Add (Math/Vector 3)\" instead.")]
	[RenamedFrom("Bolt.Vector3Add")]
	[RenamedFrom("Unity.VisualScripting.Vector3Add")]
	public sealed class DeprecatedVector3Add : Add<Vector3>
	{
		// Token: 0x17000296 RID: 662
		// (get) Token: 0x0600073E RID: 1854 RVA: 0x0000DC14 File Offset: 0x0000BE14
		protected override Vector3 defaultB
		{
			get
			{
				return Vector3.zero;
			}
		}

		// Token: 0x0600073F RID: 1855 RVA: 0x0000DC1B File Offset: 0x0000BE1B
		public override Vector3 Operation(Vector3 a, Vector3 b)
		{
			return a + b;
		}
	}
}
