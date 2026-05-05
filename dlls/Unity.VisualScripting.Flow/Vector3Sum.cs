using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x02000116 RID: 278
	[UnitCategory("Math/Vector 3")]
	[UnitTitle("Add")]
	public sealed class Vector3Sum : Sum<Vector3>, IDefaultValue<Vector3>
	{
		// Token: 0x170002A2 RID: 674
		// (get) Token: 0x06000775 RID: 1909 RVA: 0x0000DFD2 File Offset: 0x0000C1D2
		[DoNotSerialize]
		public Vector3 defaultValue
		{
			get
			{
				return Vector3.zero;
			}
		}

		// Token: 0x06000776 RID: 1910 RVA: 0x0000DFD9 File Offset: 0x0000C1D9
		public override Vector3 Operation(Vector3 a, Vector3 b)
		{
			return a + b;
		}

		// Token: 0x06000777 RID: 1911 RVA: 0x0000DFE4 File Offset: 0x0000C1E4
		public override Vector3 Operation(IEnumerable<Vector3> values)
		{
			Vector3 vector = Vector3.zero;
			foreach (Vector3 b in values)
			{
				vector += b;
			}
			return vector;
		}
	}
}
