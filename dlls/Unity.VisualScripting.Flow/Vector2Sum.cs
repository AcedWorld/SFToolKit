using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000102 RID: 258
	[UnitCategory("Math/Vector 2")]
	[UnitTitle("Add")]
	public sealed class Vector2Sum : Sum<Vector2>, IDefaultValue<Vector2>
	{
		// Token: 0x17000295 RID: 661
		// (get) Token: 0x0600073A RID: 1850 RVA: 0x0000DBAC File Offset: 0x0000BDAC
		[DoNotSerialize]
		public Vector2 defaultValue
		{
			get
			{
				return Vector2.zero;
			}
		}

		// Token: 0x0600073B RID: 1851 RVA: 0x0000DBB3 File Offset: 0x0000BDB3
		public override Vector2 Operation(Vector2 a, Vector2 b)
		{
			return a + b;
		}

		// Token: 0x0600073C RID: 1852 RVA: 0x0000DBBC File Offset: 0x0000BDBC
		public override Vector2 Operation(IEnumerable<Vector2> values)
		{
			Vector2 vector = Vector2.zero;
			foreach (Vector2 b in values)
			{
				vector += b;
			}
			return vector;
		}
	}
}
