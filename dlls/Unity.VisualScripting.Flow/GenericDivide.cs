using System;

namespace Unity.VisualScripting
{
	// Token: 0x020000CE RID: 206
	[UnitCategory("Math/Generic")]
	[UnitTitle("Divide")]
	public sealed class GenericDivide : Divide<object>
	{
		// Token: 0x0600063B RID: 1595 RVA: 0x0000C836 File Offset: 0x0000AA36
		public override object Operation(object a, object b)
		{
			return OperatorUtility.Divide(a, b);
		}
	}
}
