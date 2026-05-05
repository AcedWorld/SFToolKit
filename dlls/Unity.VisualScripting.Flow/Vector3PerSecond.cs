using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000112 RID: 274
	[UnitCategory("Math/Vector 3")]
	[UnitTitle("Per Second")]
	public sealed class Vector3PerSecond : PerSecond<Vector3>
	{
		// Token: 0x06000769 RID: 1897 RVA: 0x0000DF0D File Offset: 0x0000C10D
		public override Vector3 Operation(Vector3 input)
		{
			return input * Time.deltaTime;
		}
	}
}
