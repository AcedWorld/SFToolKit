using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000101 RID: 257
	[UnitCategory("Math/Vector 2")]
	[UnitTitle("Subtract")]
	public sealed class Vector2Subtract : Subtract<Vector2>
	{
		// Token: 0x17000293 RID: 659
		// (get) Token: 0x06000736 RID: 1846 RVA: 0x0000DB8D File Offset: 0x0000BD8D
		protected override Vector2 defaultMinuend
		{
			get
			{
				return Vector2.zero;
			}
		}

		// Token: 0x17000294 RID: 660
		// (get) Token: 0x06000737 RID: 1847 RVA: 0x0000DB94 File Offset: 0x0000BD94
		protected override Vector2 defaultSubtrahend
		{
			get
			{
				return Vector2.zero;
			}
		}

		// Token: 0x06000738 RID: 1848 RVA: 0x0000DB9B File Offset: 0x0000BD9B
		public override Vector2 Operation(Vector2 a, Vector2 b)
		{
			return a - b;
		}
	}
}
