using System;

namespace UnityEngine
{
	// Token: 0x02000296 RID: 662
	internal static class UINumericFieldsUtils
	{
		// Token: 0x06001C0F RID: 7183 RVA: 0x0002E730 File Offset: 0x0002C930
		public static bool TryConvertStringToDouble(string str, out double value)
		{
			ExpressionEvaluator.Expression expression;
			return UINumericFieldsUtils.TryConvertStringToDouble(str, out value, out expression);
		}

		// Token: 0x06001C10 RID: 7184 RVA: 0x0002E74C File Offset: 0x0002C94C
		public static bool TryConvertStringToDouble(string str, out double value, out ExpressionEvaluator.Expression expr)
		{
			expr = null;
			string text = str.ToLower();
			string text2 = text;
			string a = text2;
			if (!(a == "inf") && !(a == "infinity"))
			{
				if (!(a == "-inf") && !(a == "-infinity"))
				{
					if (!(a == "nan"))
					{
						return ExpressionEvaluator.Evaluate<double>(str, out value, out expr);
					}
					value = double.NaN;
				}
				else
				{
					value = double.NegativeInfinity;
				}
			}
			else
			{
				value = double.PositiveInfinity;
			}
			return true;
		}

		// Token: 0x06001C11 RID: 7185 RVA: 0x0002E7E4 File Offset: 0x0002C9E4
		public static bool TryConvertStringToDouble(string str, string initialValueAsString, out double value)
		{
			ExpressionEvaluator.Expression expression;
			bool flag = UINumericFieldsUtils.TryConvertStringToDouble(str, out value, out expression);
			bool flag2 = !flag && expression != null && !string.IsNullOrEmpty(initialValueAsString);
			if (flag2)
			{
				double num;
				ExpressionEvaluator.Expression expression2;
				bool flag3 = UINumericFieldsUtils.TryConvertStringToDouble(initialValueAsString, out num, out expression2);
				if (flag3)
				{
					value = num;
					flag = expression.Evaluate<double>(ref value, 0, 1);
				}
			}
			return flag;
		}

		// Token: 0x06001C12 RID: 7186 RVA: 0x0002E83C File Offset: 0x0002CA3C
		public static bool TryConvertStringToFloat(string str, string initialValueAsString, out float value)
		{
			double value2;
			bool result = UINumericFieldsUtils.TryConvertStringToDouble(str, initialValueAsString, out value2);
			value = Mathf.ClampToFloat(value2);
			return result;
		}

		// Token: 0x06001C13 RID: 7187 RVA: 0x0002E864 File Offset: 0x0002CA64
		public static bool TryConvertStringToLong(string str, out long value)
		{
			ExpressionEvaluator.Expression expression;
			return ExpressionEvaluator.Evaluate<long>(str, out value, out expression);
		}

		// Token: 0x06001C14 RID: 7188 RVA: 0x0002E880 File Offset: 0x0002CA80
		public static bool TryConvertStringToLong(string str, out long value, out ExpressionEvaluator.Expression expr)
		{
			return ExpressionEvaluator.Evaluate<long>(str, out value, out expr);
		}

		// Token: 0x06001C15 RID: 7189 RVA: 0x0002E89C File Offset: 0x0002CA9C
		public static bool TryConvertStringToLong(string str, string initialValueAsString, out long value)
		{
			ExpressionEvaluator.Expression expression;
			bool flag = UINumericFieldsUtils.TryConvertStringToLong(str, out value, out expression);
			bool flag2 = !flag && expression != null && !string.IsNullOrEmpty(initialValueAsString);
			if (flag2)
			{
				long num;
				ExpressionEvaluator.Expression expression2;
				bool flag3 = UINumericFieldsUtils.TryConvertStringToLong(initialValueAsString, out num, out expression2);
				if (flag3)
				{
					value = num;
					flag = expression.Evaluate<long>(ref value, 0, 1);
				}
			}
			return flag;
		}

		// Token: 0x06001C16 RID: 7190 RVA: 0x0002E8F4 File Offset: 0x0002CAF4
		public static bool TryConvertStringToULong(string str, out ulong value, out ExpressionEvaluator.Expression expr)
		{
			return ExpressionEvaluator.Evaluate<ulong>(str, out value, out expr);
		}

		// Token: 0x06001C17 RID: 7191 RVA: 0x0002E910 File Offset: 0x0002CB10
		public static bool TryConvertStringToULong(string str, string initialValueAsString, out ulong value)
		{
			ExpressionEvaluator.Expression expression;
			bool flag = UINumericFieldsUtils.TryConvertStringToULong(str, out value, out expression);
			bool flag2 = !flag && expression != null && !string.IsNullOrEmpty(initialValueAsString);
			if (flag2)
			{
				ulong num;
				ExpressionEvaluator.Expression expression2;
				bool flag3 = UINumericFieldsUtils.TryConvertStringToULong(initialValueAsString, out num, out expression2);
				if (flag3)
				{
					value = num;
					flag = expression.Evaluate<ulong>(ref value, 0, 1);
				}
			}
			return flag;
		}

		// Token: 0x06001C18 RID: 7192 RVA: 0x0002E968 File Offset: 0x0002CB68
		public static bool TryConvertStringToInt(string str, string initialValueAsString, out int value)
		{
			long value2;
			bool result = UINumericFieldsUtils.TryConvertStringToLong(str, initialValueAsString, out value2);
			value = Mathf.ClampToInt(value2);
			return result;
		}

		// Token: 0x06001C19 RID: 7193 RVA: 0x0002E990 File Offset: 0x0002CB90
		public static bool TryConvertStringToUInt(string str, string initialValueAsString, out uint value)
		{
			long value2;
			bool result = UINumericFieldsUtils.TryConvertStringToLong(str, initialValueAsString, out value2);
			value = Mathf.ClampToUInt(value2);
			return result;
		}

		// Token: 0x04000967 RID: 2407
		public static readonly string k_AllowedCharactersForFloat = "inftynaeINFTYNAE0123456789.,-*/+%^()cosqrludxvRL=pP#";

		// Token: 0x04000968 RID: 2408
		public static readonly string k_AllowedCharactersForInt = "0123456789-*/+%^()cosintaqrtelfundxvRL,=pPI#";

		// Token: 0x04000969 RID: 2409
		public static readonly string k_DoubleFieldFormatString = "R";

		// Token: 0x0400096A RID: 2410
		public static readonly string k_FloatFieldFormatString = "g7";

		// Token: 0x0400096B RID: 2411
		public static readonly string k_IntFieldFormatString = "#######0";
	}
}
