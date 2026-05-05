using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000127 RID: 295
	[UnitCategory("Math/Vector 4")]
	[UnitTitle("Add")]
	public sealed class Vector4Sum : Sum<Vector4>, IDefaultValue<Vector4>
	{
		// Token: 0x170002AF RID: 687
		// (get) Token: 0x060007AA RID: 1962 RVA: 0x0000E41C File Offset: 0x0000C61C
		[DoNotSerialize]
		public Vector4 defaultValue
		{
			get
			{
				return Vector4.zero;
			}
		}

		// Token: 0x060007AB RID: 1963 RVA: 0x0000E423 File Offset: 0x0000C623
		public override Vector4 Operation(Vector4 a, Vector4 b)
		{
			return a + b;
		}

		// Token: 0x060007AC RID: 1964 RVA: 0x0000E42C File Offset: 0x0000C62C
		public override Vector4 Operation(IEnumerable<Vector4> values)
		{
			Vector4 vector = Vector4.zero;
			foreach (Vector4 b in values)
			{
				vector += b;
			}
			return vector;
		}
	}
}
