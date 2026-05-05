using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x020000FB RID: 251
	[UnitCategory("Math/Vector 2")]
	[UnitTitle("Move Towards")]
	public sealed class Vector2MoveTowards : MoveTowards<Vector2>
	{
		// Token: 0x17000290 RID: 656
		// (get) Token: 0x06000725 RID: 1829 RVA: 0x0000DA9B File Offset: 0x0000BC9B
		protected override Vector2 defaultCurrent
		{
			get
			{
				return Vector2.zero;
			}
		}

		// Token: 0x17000291 RID: 657
		// (get) Token: 0x06000726 RID: 1830 RVA: 0x0000DAA2 File Offset: 0x0000BCA2
		protected override Vector2 defaultTarget
		{
			get
			{
				return Vector2.one;
			}
		}

		// Token: 0x06000727 RID: 1831 RVA: 0x0000DAA9 File Offset: 0x0000BCA9
		public override Vector2 Operation(Vector2 current, Vector2 target, float maxDelta)
		{
			return Vector2.MoveTowards(current, target, maxDelta);
		}
	}
}
