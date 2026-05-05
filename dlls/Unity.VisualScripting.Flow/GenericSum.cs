using System;
using System.Collections.Generic;
using System.Linq;

namespace Unity.VisualScripting
{
	// Token: 0x020000D2 RID: 210
	[UnitCategory("Math/Generic")]
	[UnitTitle("Add")]
	public sealed class GenericSum : Sum<object>
	{
		// Token: 0x06000643 RID: 1603 RVA: 0x0000C87A File Offset: 0x0000AA7A
		public override object Operation(object a, object b)
		{
			return OperatorUtility.Add(a, b);
		}

		// Token: 0x06000644 RID: 1604 RVA: 0x0000C884 File Offset: 0x0000AA84
		public override object Operation(IEnumerable<object> values)
		{
			List<object> list = values.ToList<object>();
			object obj = OperatorUtility.Add(list[0], list[1]);
			for (int i = 2; i < list.Count; i++)
			{
				obj = OperatorUtility.Add(obj, list[i]);
			}
			return obj;
		}
	}
}
