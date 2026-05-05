using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000115 RID: 277
	[UnitCategory("Math/Vector 3")]
	[UnitTitle("Subtract")]
	public sealed class Vector3Subtract : Subtract<Vector3>
	{
		// Token: 0x170002A0 RID: 672
		// (get) Token: 0x06000771 RID: 1905 RVA: 0x0000DFB3 File Offset: 0x0000C1B3
		protected override Vector3 defaultMinuend
		{
			get
			{
				return Vector3.zero;
			}
		}

		// Token: 0x170002A1 RID: 673
		// (get) Token: 0x06000772 RID: 1906 RVA: 0x0000DFBA File Offset: 0x0000C1BA
		protected override Vector3 defaultSubtrahend
		{
			get
			{
				return Vector3.zero;
			}
		}

		// Token: 0x06000773 RID: 1907 RVA: 0x0000DFC1 File Offset: 0x0000C1C1
		public override Vector3 Operation(Vector3 a, Vector3 b)
		{
			return a - b;
		}
	}
}
