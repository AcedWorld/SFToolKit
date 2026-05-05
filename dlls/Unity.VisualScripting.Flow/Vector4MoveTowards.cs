using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000121 RID: 289
	[UnitCategory("Math/Vector 4")]
	[UnitTitle("Move Towards")]
	public sealed class Vector4MoveTowards : MoveTowards<Vector4>
	{
		// Token: 0x170002AA RID: 682
		// (get) Token: 0x06000797 RID: 1943 RVA: 0x0000E2CD File Offset: 0x0000C4CD
		protected override Vector4 defaultCurrent
		{
			get
			{
				return Vector4.zero;
			}
		}

		// Token: 0x170002AB RID: 683
		// (get) Token: 0x06000798 RID: 1944 RVA: 0x0000E2D4 File Offset: 0x0000C4D4
		protected override Vector4 defaultTarget
		{
			get
			{
				return Vector4.one;
			}
		}

		// Token: 0x06000799 RID: 1945 RVA: 0x0000E2DB File Offset: 0x0000C4DB
		public override Vector4 Operation(Vector4 current, Vector4 target, float maxDelta)
		{
			return Vector4.MoveTowards(current, target, maxDelta);
		}
	}
}
