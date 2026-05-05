using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000359 RID: 857
	internal static class StyleValueFunctionExtension
	{
		// Token: 0x06001CB8 RID: 7352 RVA: 0x0006F618 File Offset: 0x0006D818
		public static StyleValueFunction FromUssString(string ussValue)
		{
			ussValue = ussValue.ToLowerInvariant();
			string text = ussValue;
			string a = text;
			StyleValueFunction result;
			if (!(a == "var"))
			{
				if (!(a == "env"))
				{
					if (!(a == "linear-gradient"))
					{
						throw new ArgumentOutOfRangeException("ussValue", ussValue, "Unknown function name");
					}
					result = StyleValueFunction.LinearGradient;
				}
				else
				{
					result = StyleValueFunction.Env;
				}
			}
			else
			{
				result = StyleValueFunction.Var;
			}
			return result;
		}

		// Token: 0x06001CB9 RID: 7353 RVA: 0x0006F67C File Offset: 0x0006D87C
		public static string ToUssString(this StyleValueFunction svf)
		{
			string result;
			switch (svf)
			{
			case StyleValueFunction.Var:
				result = "var";
				break;
			case StyleValueFunction.Env:
				result = "env";
				break;
			case StyleValueFunction.LinearGradient:
				result = "linear-gradient";
				break;
			default:
				throw new ArgumentOutOfRangeException("svf", svf, "Unknown StyleValueFunction");
			}
			return result;
		}

		// Token: 0x04000BF5 RID: 3061
		public const string k_Var = "var";

		// Token: 0x04000BF6 RID: 3062
		public const string k_Env = "env";

		// Token: 0x04000BF7 RID: 3063
		public const string k_LinearGradient = "linear-gradient";
	}
}
