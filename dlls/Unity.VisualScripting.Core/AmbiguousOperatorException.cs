using System;

namespace Unity.VisualScripting
{
	// Token: 0x020000DB RID: 219
	public sealed class AmbiguousOperatorException : OperatorException
	{
		// Token: 0x06000624 RID: 1572 RVA: 0x00010CB8 File Offset: 0x0000EEB8
		public AmbiguousOperatorException(string symbol, Type leftType, Type rightType) : base(string.Concat(new string[]
		{
			"Ambiguous use of operator '",
			symbol,
			"' between types '",
			((leftType != null) ? leftType.ToString() : null) ?? "null",
			"' and '",
			((rightType != null) ? rightType.ToString() : null) ?? "null",
			"'."
		}))
		{
		}
	}
}
