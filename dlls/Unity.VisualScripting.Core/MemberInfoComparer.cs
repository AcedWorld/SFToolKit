using System;
using System.Collections.Generic;
using System.Reflection;

namespace Unity.VisualScripting
{
	// Token: 0x020000D6 RID: 214
	public class MemberInfoComparer : EqualityComparer<MemberInfo>
	{
		// Token: 0x060005D1 RID: 1489 RVA: 0x0000EDC8 File Offset: 0x0000CFC8
		public override bool Equals(MemberInfo x, MemberInfo y)
		{
			int? num = (x != null) ? new int?(x.MetadataToken) : null;
			int? num2 = (y != null) ? new int?(y.MetadataToken) : null;
			return num.GetValueOrDefault() == num2.GetValueOrDefault() & num != null == (num2 != null);
		}

		// Token: 0x060005D2 RID: 1490 RVA: 0x0000EE2A File Offset: 0x0000D02A
		public override int GetHashCode(MemberInfo obj)
		{
			return obj.MetadataToken;
		}
	}
}
