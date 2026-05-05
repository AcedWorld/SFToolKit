using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200011C RID: 284
	[UnitCategory("Math/Vector 4")]
	[UnitTitle("Dot Product")]
	public sealed class Vector4DotProduct : DotProduct<Vector4>
	{
		// Token: 0x06000787 RID: 1927 RVA: 0x0000E16E File Offset: 0x0000C36E
		public override float Operation(Vector4 a, Vector4 b)
		{
			return Vector4.Dot(a, b);
		}
	}
}
