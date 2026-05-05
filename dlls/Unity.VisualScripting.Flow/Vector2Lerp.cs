using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x020000F7 RID: 247
	[UnitCategory("Math/Vector 2")]
	[UnitTitle("Lerp")]
	public sealed class Vector2Lerp : Lerp<Vector2>
	{
		// Token: 0x1700028C RID: 652
		// (get) Token: 0x06000717 RID: 1815 RVA: 0x0000D965 File Offset: 0x0000BB65
		protected override Vector2 defaultA
		{
			get
			{
				return Vector2.zero;
			}
		}

		// Token: 0x1700028D RID: 653
		// (get) Token: 0x06000718 RID: 1816 RVA: 0x0000D96C File Offset: 0x0000BB6C
		protected override Vector2 defaultB
		{
			get
			{
				return Vector2.one;
			}
		}

		// Token: 0x06000719 RID: 1817 RVA: 0x0000D973 File Offset: 0x0000BB73
		public override Vector2 Operation(Vector2 a, Vector2 b, float t)
		{
			return Vector2.Lerp(a, b, t);
		}
	}
}
