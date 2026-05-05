using System;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000100 RID: 256
	[UnitCategory("Math/Vector 2")]
	[UnitTitle("Round")]
	public sealed class Vector2Round : Round<Vector2, Vector2>
	{
		// Token: 0x06000732 RID: 1842 RVA: 0x0000DB2E File Offset: 0x0000BD2E
		protected override Vector2 Floor(Vector2 input)
		{
			return new Vector2(Mathf.Floor(input.x), Mathf.Floor(input.y));
		}

		// Token: 0x06000733 RID: 1843 RVA: 0x0000DB4B File Offset: 0x0000BD4B
		protected override Vector2 AwayFromZero(Vector2 input)
		{
			return new Vector2(Mathf.Round(input.x), Mathf.Round(input.y));
		}

		// Token: 0x06000734 RID: 1844 RVA: 0x0000DB68 File Offset: 0x0000BD68
		protected override Vector2 Ceiling(Vector2 input)
		{
			return new Vector2(Mathf.Ceil(input.x), Mathf.Ceil(input.y));
		}
	}
}
