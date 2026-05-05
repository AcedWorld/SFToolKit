using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000114 RID: 276
	[UnitCategory("Math/Vector 3")]
	[UnitTitle("Round")]
	public sealed class Vector3Round : Round<Vector3, Vector3>
	{
		// Token: 0x0600076D RID: 1901 RVA: 0x0000DF33 File Offset: 0x0000C133
		protected override Vector3 Floor(Vector3 input)
		{
			return new Vector3(Mathf.Floor(input.x), Mathf.Floor(input.y), Mathf.Floor(input.z));
		}

		// Token: 0x0600076E RID: 1902 RVA: 0x0000DF5B File Offset: 0x0000C15B
		protected override Vector3 AwayFromZero(Vector3 input)
		{
			return new Vector3(Mathf.Round(input.x), Mathf.Round(input.y), Mathf.Round(input.z));
		}

		// Token: 0x0600076F RID: 1903 RVA: 0x0000DF83 File Offset: 0x0000C183
		protected override Vector3 Ceiling(Vector3 input)
		{
			return new Vector3(Mathf.Ceil(input.x), Mathf.Ceil(input.y), Mathf.Ceil(input.z));
		}
	}
}
