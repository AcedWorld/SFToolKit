using System;

namespace Unity.VisualScripting
{
	// Token: 0x020000D1 RID: 209
	[UnitCategory("Math/Generic")]
	[UnitTitle("Subtract")]
	public sealed class GenericSubtract : Subtract<object>
	{
		// Token: 0x06000641 RID: 1601 RVA: 0x0000C869 File Offset: 0x0000AA69
		public override object Operation(object a, object b)
		{
			return OperatorUtility.Subtract(a, b);
		}
	}
}
