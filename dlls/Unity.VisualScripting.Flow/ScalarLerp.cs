using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x020000E2 RID: 226
	[UnitCategory("Math/Scalar")]
	[UnitTitle("Lerp")]
	public sealed class ScalarLerp : Lerp<float>
	{
		// Token: 0x17000276 RID: 630
		// (get) Token: 0x060006C4 RID: 1732 RVA: 0x0000D3B5 File Offset: 0x0000B5B5
		protected override float defaultA
		{
			get
			{
				return 0f;
			}
		}

		// Token: 0x17000277 RID: 631
		// (get) Token: 0x060006C5 RID: 1733 RVA: 0x0000D3BC File Offset: 0x0000B5BC
		protected override float defaultB
		{
			get
			{
				return 1f;
			}
		}

		// Token: 0x060006C6 RID: 1734 RVA: 0x0000D3C3 File Offset: 0x0000B5C3
		public override float Operation(float a, float b, float t)
		{
			return Mathf.Lerp(a, b, t);
		}
	}
}
