using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000113 RID: 275
	[UnitCategory("Math/Vector 3")]
	[UnitTitle("Project")]
	public sealed class Vector3Project : Project<Vector3>
	{
		// Token: 0x0600076B RID: 1899 RVA: 0x0000DF22 File Offset: 0x0000C122
		public override Vector3 Operation(Vector3 a, Vector3 b)
		{
			return Vector3.Project(a, b);
		}
	}
}
