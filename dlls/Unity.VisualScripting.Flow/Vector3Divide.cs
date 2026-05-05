using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000109 RID: 265
	[UnitCategory("Math/Vector 3")]
	[UnitTitle("Divide")]
	public sealed class Vector3Divide : Divide<Vector3>
	{
		// Token: 0x17000297 RID: 663
		// (get) Token: 0x0600074C RID: 1868 RVA: 0x0000DD0A File Offset: 0x0000BF0A
		protected override Vector3 defaultDividend
		{
			get
			{
				return Vector3.zero;
			}
		}

		// Token: 0x17000298 RID: 664
		// (get) Token: 0x0600074D RID: 1869 RVA: 0x0000DD11 File Offset: 0x0000BF11
		protected override Vector3 defaultDivisor
		{
			get
			{
				return Vector3.zero;
			}
		}

		// Token: 0x0600074E RID: 1870 RVA: 0x0000DD18 File Offset: 0x0000BF18
		public override Vector3 Operation(Vector3 a, Vector3 b)
		{
			return new Vector3(a.x / b.x, a.y / b.y, a.z / b.z);
		}
	}
}
