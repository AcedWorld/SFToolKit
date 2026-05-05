using System;

namespace Unity.VisualScripting
{
	// Token: 0x020000E7 RID: 231
	public sealed class InvalidOperatorException : OperatorException
	{
		// Token: 0x0600063B RID: 1595 RVA: 0x000177AC File Offset: 0x000159AC
		public InvalidOperatorException(string symbol, Type type) : base(string.Concat(new string[]
		{
			"Operator '",
			symbol,
			"' cannot be applied to operand of type '",
			((type != null) ? type.ToString() : null) ?? "null",
			"'."
		}))
		{
		}

		// Token: 0x0600063C RID: 1596 RVA: 0x00017800 File Offset: 0x00015A00
		public InvalidOperatorException(string symbol, Type leftType, Type rightType) : base(string.Concat(new string[]
		{
			"Operator '",
			symbol,
			"' cannot be applied to operands of type '",
			((leftType != null) ? leftType.ToString() : null) ?? "null",
			"' and '",
			((rightType != null) ? rightType.ToString() : null) ?? "null",
			"'."
		}))
		{
		}
	}
}
