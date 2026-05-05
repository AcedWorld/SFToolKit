using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200010B RID: 267
	[UnitCategory("Math/Vector 3")]
	[UnitTitle("Lerp")]
	public sealed class Vector3Lerp : Lerp<Vector3>
	{
		// Token: 0x17000299 RID: 665
		// (get) Token: 0x06000752 RID: 1874 RVA: 0x0000DD5F File Offset: 0x0000BF5F
		protected override Vector3 defaultA
		{
			get
			{
				return Vector3.zero;
			}
		}

		// Token: 0x1700029A RID: 666
		// (get) Token: 0x06000753 RID: 1875 RVA: 0x0000DD66 File Offset: 0x0000BF66
		protected override Vector3 defaultB
		{
			get
			{
				return Vector3.one;
			}
		}

		// Token: 0x06000754 RID: 1876 RVA: 0x0000DD6D File Offset: 0x0000BF6D
		public override Vector3 Operation(Vector3 a, Vector3 b, float t)
		{
			return Vector3.Lerp(a, b, t);
		}
	}
}
