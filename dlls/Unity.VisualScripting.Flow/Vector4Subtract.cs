using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000126 RID: 294
	[UnitCategory("Math/Vector 4")]
	[UnitTitle("Subtract")]
	public sealed class Vector4Subtract : Subtract<Vector4>
	{
		// Token: 0x170002AD RID: 685
		// (get) Token: 0x060007A6 RID: 1958 RVA: 0x0000E3FD File Offset: 0x0000C5FD
		protected override Vector4 defaultMinuend
		{
			get
			{
				return Vector4.zero;
			}
		}

		// Token: 0x170002AE RID: 686
		// (get) Token: 0x060007A7 RID: 1959 RVA: 0x0000E404 File Offset: 0x0000C604
		protected override Vector4 defaultSubtrahend
		{
			get
			{
				return Vector4.zero;
			}
		}

		// Token: 0x060007A8 RID: 1960 RVA: 0x0000E40B File Offset: 0x0000C60B
		public override Vector4 Operation(Vector4 a, Vector4 b)
		{
			return a - b;
		}
	}
}
