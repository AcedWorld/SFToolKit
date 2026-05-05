using System;

namespace Unity.VisualScripting
{
	// Token: 0x020000D0 RID: 208
	[UnitCategory("Math/Generic")]
	[UnitTitle("Multiply")]
	public sealed class GenericMultiply : Multiply<object>
	{
		// Token: 0x0600063F RID: 1599 RVA: 0x0000C858 File Offset: 0x0000AA58
		public override object Operation(object a, object b)
		{
			return OperatorUtility.Multiply(a, b);
		}
	}
}
