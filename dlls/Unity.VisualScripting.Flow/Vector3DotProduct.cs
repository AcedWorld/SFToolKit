using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200010A RID: 266
	[UnitCategory("Math/Vector 3")]
	[UnitTitle("Dot Product")]
	public sealed class Vector3DotProduct : DotProduct<Vector3>
	{
		// Token: 0x06000750 RID: 1872 RVA: 0x0000DD4E File Offset: 0x0000BF4E
		public override float Operation(Vector3 a, Vector3 b)
		{
			return Vector3.Dot(a, b);
		}
	}
}
