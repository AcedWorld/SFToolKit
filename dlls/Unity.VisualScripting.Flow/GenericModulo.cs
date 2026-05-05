using System;

namespace Unity.VisualScripting
{
	// Token: 0x020000CF RID: 207
	[UnitCategory("Math/Generic")]
	[UnitTitle("Modulo")]
	public sealed class GenericModulo : Modulo<object>
	{
		// Token: 0x0600063D RID: 1597 RVA: 0x0000C847 File Offset: 0x0000AA47
		public override object Operation(object a, object b)
		{
			return OperatorUtility.Modulo(a, b);
		}
	}
}
