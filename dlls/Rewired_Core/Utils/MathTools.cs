using System;
using UnityEngine;

namespace Rewired.Utils
{
	// Token: 0x02000494 RID: 1172
	public class MathTools
	{
		// Token: 0x06002E75 RID: 11893 RVA: 0x0002391E File Offset: 0x00021B1E
		public static sbyte Abs(sbyte value)
		{
			if (value >= 0)
			{
				return value;
			}
			if (value == -128)
			{
				throw new OverflowException("Cannot compute absolute value of sbyte.MinValue");
			}
			return -value;
		}

		// Token: 0x06002E76 RID: 11894 RVA: 0x00023939 File Offset: 0x00021B39
		public static short Abs(short value)
		{
			if (value >= 0)
			{
				return value;
			}
			if (value == -32768)
			{
				throw new OverflowException("Cannot compute absolute value of short.MinValue");
			}
			return -value;
		}

		// Token: 0x06002E77 RID: 11895 RVA: 0x00023957 File Offset: 0x00021B57
		public static int Abs(int value)
		{
			if (value >= 0)
			{
				return value;
			}
			if (value == -2147483648)
			{
				throw new OverflowException("Cannot compute absolute value of int.MinValue");
			}
			return -value;
		}

		// Token: 0x06002E78 RID: 11896 RVA: 0x00023974 File Offset: 0x00021B74
		public static long Abs(long value)
		{
			if (value >= 0L)
			{
				return value;
			}
			if (value == -9223372036854775808L)
			{
				throw new OverflowException("Cannot compute absolute value of long.MinValue");
			}
			return -value;
		}

		// Token: 0x06002E79 RID: 11897 RVA: 0x00023996 File Offset: 0x00021B96
		public static float Abs(float value)
		{
			if (value >= 0f)
			{
				return value;
			}
			if (value == float.NaN)
			{
				throw new OverflowException("Cannot compute absolute value of float.NaN");
			}
			return -value;
		}

		// Token: 0x06002E7A RID: 11898 RVA: 0x000239B8 File Offset: 0x00021BB8
		public static double Abs(double value)
		{
			if (value >= 0.0)
			{
				return value;
			}
			if (value == double.NaN)
			{
				throw new OverflowException("Cannot compute absolute value of double.NaN");
			}
			return -value;
		}

		// Token: 0x06002E7B RID: 11899 RVA: 0x000A2C44 File Offset: 0x000A0E44
		public static bool Approximately(float a, float b)
		{
			if (a == b)
			{
				return true;
			}
			float num = b - a;
			if (num < 0f)
			{
				num = -num;
			}
			if (a < 0f)
			{
				a = -a;
			}
			if (b < 0f)
			{
				b = -b;
			}
			float num2 = ((a > b) ? a : b) * 1E-06f;
			return num < ((num2 > 1.1E-44f) ? num2 : 1.1E-44f);
		}

		// Token: 0x06002E7C RID: 11900 RVA: 0x000A2CA0 File Offset: 0x000A0EA0
		public static bool ApproximatelyZero(float a)
		{
			if (a == 0f)
			{
				return true;
			}
			float num = (a < 0f) ? (-a) : a;
			float num2 = num * 1E-06f;
			return num < ((num2 > 1.1E-44f) ? num2 : 1.1E-44f);
		}

		// Token: 0x06002E7D RID: 11901 RVA: 0x000239E2 File Offset: 0x00021BE2
		public static bool IsZero(float value)
		{
			if (value < 0f)
			{
				value = -value;
			}
			return value < 1E-10f;
		}

		// Token: 0x06002E7E RID: 11902 RVA: 0x000239F8 File Offset: 0x00021BF8
		public static bool IsZero(float value, float threshold)
		{
			if (threshold < 0f)
			{
				threshold = -threshold;
			}
			if (value < 0f)
			{
				value = -value;
			}
			return value < threshold;
		}

		// Token: 0x06002E7F RID: 11903 RVA: 0x00023A16 File Offset: 0x00021C16
		public static bool IsZero(double value)
		{
			if (value < 0.0)
			{
				value = -value;
			}
			return value < 1E-10;
		}

		// Token: 0x06002E80 RID: 11904 RVA: 0x00023A34 File Offset: 0x00021C34
		public static bool IsZero(double value, double threshold)
		{
			if (threshold < 0.0)
			{
				threshold = -threshold;
			}
			if (value < 0.0)
			{
				value = -value;
			}
			return value < threshold;
		}

		// Token: 0x06002E81 RID: 11905 RVA: 0x00023A5A File Offset: 0x00021C5A
		public static bool IsExactlyEqual(float a, float b)
		{
			return a >= b - float.Epsilon && a <= b + float.Epsilon;
		}

		// Token: 0x06002E82 RID: 11906 RVA: 0x00023A73 File Offset: 0x00021C73
		public static bool IsExactlyEqual(double a, double b)
		{
			return a >= b - double.Epsilon && a <= b + double.Epsilon;
		}

		// Token: 0x06002E83 RID: 11907 RVA: 0x000A2CE0 File Offset: 0x000A0EE0
		public static bool IsNear(float value, float targetValue)
		{
			float num = value - targetValue;
			if (num >= 0f)
			{
				return num <= 0.0001f;
			}
			return -num <= 0.0001f;
		}

		// Token: 0x06002E84 RID: 11908 RVA: 0x000A2D14 File Offset: 0x000A0F14
		public static bool IsNear(float value, float targetValue, float threshold)
		{
			if (threshold < 0f)
			{
				threshold = -threshold;
			}
			float num = value - targetValue;
			if (num >= 0f)
			{
				return num <= threshold;
			}
			return -num <= threshold;
		}

		// Token: 0x06002E85 RID: 11909 RVA: 0x00023A94 File Offset: 0x00021C94
		public static bool IsNearZero(float value)
		{
			if (value >= 0f)
			{
				return value <= 0.0001f;
			}
			return -value <= 0.0001f;
		}

		// Token: 0x06002E86 RID: 11910 RVA: 0x00023AB6 File Offset: 0x00021CB6
		public static bool IsNearZero(float value, float threshold)
		{
			if (threshold < 0f)
			{
				threshold = -threshold;
			}
			if (value >= 0f)
			{
				return value <= threshold;
			}
			return -value <= threshold;
		}

		// Token: 0x06002E87 RID: 11911 RVA: 0x000A2D4C File Offset: 0x000A0F4C
		public static bool IsNearOrWholeNumber(float value)
		{
			float num = (value < 0f) ? (-value) : value;
			return MathTools.Ceil(num) - num <= 0.0001f;
		}

		// Token: 0x06002E88 RID: 11912 RVA: 0x000A2D7C File Offset: 0x000A0F7C
		public static bool IsNearOrWholeNumber(float value, float threshold)
		{
			if (threshold < 0f)
			{
				threshold = -threshold;
			}
			float num = (value < 0f) ? (-value) : value;
			return MathTools.Ceil(num) - num <= threshold;
		}

		// Token: 0x06002E89 RID: 11913 RVA: 0x000A2DB4 File Offset: 0x000A0FB4
		public static bool IsNearOrWholeNumber(float value, out int number)
		{
			float num = (value < 0f) ? (value *= -1f) : value;
			int num2 = MathTools.RoundToInt(num);
			float num3 = num - (float)num2;
			if (num3 < 0f)
			{
				num3 *= -1f;
			}
			number = ((value < 0f) ? (num2 * -1) : num2);
			return num3 <= 0.0001f;
		}

		// Token: 0x06002E8A RID: 11914 RVA: 0x000A2E0C File Offset: 0x000A100C
		public static bool IsNearOrWholeNumber(float value, out int number, float threshold)
		{
			if (threshold < 0f)
			{
				threshold = -threshold;
			}
			float num = (value < 0f) ? (value *= -1f) : value;
			int num2 = MathTools.RoundToInt(num);
			float num3 = num - (float)num2;
			if (num3 < 0f)
			{
				num3 *= -1f;
			}
			number = ((value < 0f) ? (num2 * -1) : num2);
			return num3 <= threshold;
		}

		// Token: 0x06002E8B RID: 11915 RVA: 0x00023ADC File Offset: 0x00021CDC
		public static float RoundOffIfNearWholeNumber(float value)
		{
			if (MathTools.IsNearOrWholeNumber(value))
			{
				return MathTools.Round(value);
			}
			return value;
		}

		// Token: 0x06002E8C RID: 11916 RVA: 0x00023AEE File Offset: 0x00021CEE
		public static float RoundOffIfNearWholeNumber(float value, float threshold)
		{
			if (threshold < 0f)
			{
				threshold = -threshold;
			}
			if (MathTools.IsNearOrWholeNumber(value, threshold))
			{
				return MathTools.Round(value);
			}
			return value;
		}

		// Token: 0x06002E8D RID: 11917 RVA: 0x00023B0D File Offset: 0x00021D0D
		public static bool IsEven(int value)
		{
			return value % 2 == 0;
		}

		// Token: 0x06002E8E RID: 11918 RVA: 0x000A2E6C File Offset: 0x000A106C
		public static float ValueInNewRange(float oldValue, float oldMin, float oldMax, float newMin, float newMax)
		{
			if (oldValue < oldMin)
			{
				oldValue = oldMin;
			}
			else if (oldValue > oldMax)
			{
				oldValue = oldMax;
			}
			float num = oldMax - oldMin;
			float result;
			if (MathTools.Approximately(num, 0f))
			{
				result = newMin;
			}
			else
			{
				float num2 = newMax - newMin;
				result = (oldValue - oldMin) * num2 / num + newMin;
			}
			return result;
		}

		// Token: 0x06002E8F RID: 11919 RVA: 0x000A2EB0 File Offset: 0x000A10B0
		public static int ValueInNewRange(int oldValue, int oldMin, int oldMax, int newMin, int newMax)
		{
			if (oldValue < oldMin)
			{
				oldValue = oldMin;
			}
			else if (oldValue > oldMax)
			{
				oldValue = oldMax;
			}
			int num = oldMax - oldMin;
			int result;
			if (num == 0)
			{
				result = newMin;
			}
			else
			{
				int num2 = newMax - newMin;
				result = (oldValue - oldMin) * num2 / num + newMin;
			}
			return result;
		}

		// Token: 0x06002E90 RID: 11920 RVA: 0x00023B17 File Offset: 0x00021D17
		public static sbyte Max(sbyte a, sbyte b)
		{
			if (a < b)
			{
				return b;
			}
			return a;
		}

		// Token: 0x06002E91 RID: 11921 RVA: 0x00023B17 File Offset: 0x00021D17
		public static byte Max(byte a, byte b)
		{
			if (a < b)
			{
				return b;
			}
			return a;
		}

		// Token: 0x06002E92 RID: 11922 RVA: 0x00023B17 File Offset: 0x00021D17
		public static short Max(short a, short b)
		{
			if (a < b)
			{
				return b;
			}
			return a;
		}

		// Token: 0x06002E93 RID: 11923 RVA: 0x00023B17 File Offset: 0x00021D17
		public static ushort Max(ushort a, ushort b)
		{
			if (a < b)
			{
				return b;
			}
			return a;
		}

		// Token: 0x06002E94 RID: 11924 RVA: 0x00023B17 File Offset: 0x00021D17
		public static int Max(int a, int b)
		{
			if (a < b)
			{
				return b;
			}
			return a;
		}

		// Token: 0x06002E95 RID: 11925 RVA: 0x00023B20 File Offset: 0x00021D20
		public static uint Max(uint a, uint b)
		{
			if (a < b)
			{
				return b;
			}
			return a;
		}

		// Token: 0x06002E96 RID: 11926 RVA: 0x00023B17 File Offset: 0x00021D17
		public static long Max(long a, long b)
		{
			if (a < b)
			{
				return b;
			}
			return a;
		}

		// Token: 0x06002E97 RID: 11927 RVA: 0x00023B20 File Offset: 0x00021D20
		public static ulong Max(ulong a, ulong b)
		{
			if (a < b)
			{
				return b;
			}
			return a;
		}

		// Token: 0x06002E98 RID: 11928 RVA: 0x00023B17 File Offset: 0x00021D17
		public static float Max(float a, float b)
		{
			if (a < b)
			{
				return b;
			}
			return a;
		}

		// Token: 0x06002E99 RID: 11929 RVA: 0x00023B17 File Offset: 0x00021D17
		public static double Max(double a, double b)
		{
			if (a < b)
			{
				return b;
			}
			return a;
		}

		// Token: 0x06002E9A RID: 11930 RVA: 0x00023B29 File Offset: 0x00021D29
		public static sbyte Min(sbyte a, sbyte b)
		{
			if (a > b)
			{
				return b;
			}
			return a;
		}

		// Token: 0x06002E9B RID: 11931 RVA: 0x00023B29 File Offset: 0x00021D29
		public static byte Min(byte a, byte b)
		{
			if (a > b)
			{
				return b;
			}
			return a;
		}

		// Token: 0x06002E9C RID: 11932 RVA: 0x00023B29 File Offset: 0x00021D29
		public static short Min(short a, short b)
		{
			if (a > b)
			{
				return b;
			}
			return a;
		}

		// Token: 0x06002E9D RID: 11933 RVA: 0x00023B29 File Offset: 0x00021D29
		public static ushort Min(ushort a, ushort b)
		{
			if (a > b)
			{
				return b;
			}
			return a;
		}

		// Token: 0x06002E9E RID: 11934 RVA: 0x00023B29 File Offset: 0x00021D29
		public static int Min(int a, int b)
		{
			if (a > b)
			{
				return b;
			}
			return a;
		}

		// Token: 0x06002E9F RID: 11935 RVA: 0x00023B32 File Offset: 0x00021D32
		public static uint Min(uint a, uint b)
		{
			if (a > b)
			{
				return b;
			}
			return a;
		}

		// Token: 0x06002EA0 RID: 11936 RVA: 0x00023B29 File Offset: 0x00021D29
		public static long Min(long a, long b)
		{
			if (a > b)
			{
				return b;
			}
			return a;
		}

		// Token: 0x06002EA1 RID: 11937 RVA: 0x00023B32 File Offset: 0x00021D32
		public static ulong Min(ulong a, ulong b)
		{
			if (a > b)
			{
				return b;
			}
			return a;
		}

		// Token: 0x06002EA2 RID: 11938 RVA: 0x00023B29 File Offset: 0x00021D29
		public static float Min(float a, float b)
		{
			if (a > b)
			{
				return b;
			}
			return a;
		}

		// Token: 0x06002EA3 RID: 11939 RVA: 0x00023B29 File Offset: 0x00021D29
		public static double Min(double a, double b)
		{
			if (a > b)
			{
				return b;
			}
			return a;
		}

		// Token: 0x06002EA4 RID: 11940 RVA: 0x000A2EE8 File Offset: 0x000A10E8
		public static sbyte MaxMagnitude(sbyte a, sbyte b)
		{
			sbyte b2 = (a < 0) ? (-a) : a;
			sbyte b3 = (b < 0) ? (-b) : b;
			if (b2 < b3)
			{
				return b;
			}
			return a;
		}

		// Token: 0x06002EA5 RID: 11941 RVA: 0x00023B17 File Offset: 0x00021D17
		public static byte MaxMagnitude(byte a, byte b)
		{
			if (a < b)
			{
				return b;
			}
			return a;
		}

		// Token: 0x06002EA6 RID: 11942 RVA: 0x000A2F10 File Offset: 0x000A1110
		public static short MaxMagnitude(short a, short b)
		{
			short num = (a < 0) ? (-a) : a;
			short num2 = (b < 0) ? (-b) : b;
			if (num < num2)
			{
				return b;
			}
			return a;
		}

		// Token: 0x06002EA7 RID: 11943 RVA: 0x00023B17 File Offset: 0x00021D17
		public static ushort MaxMagnitude(ushort a, ushort b)
		{
			if (a < b)
			{
				return b;
			}
			return a;
		}

		// Token: 0x06002EA8 RID: 11944 RVA: 0x000A2F38 File Offset: 0x000A1138
		public static int MaxMagnitude(int a, int b)
		{
			int num = (a < 0) ? (-a) : a;
			int num2 = (b < 0) ? (-b) : b;
			if (num < num2)
			{
				return b;
			}
			return a;
		}

		// Token: 0x06002EA9 RID: 11945 RVA: 0x00023B20 File Offset: 0x00021D20
		public static uint MaxMagnitude(uint a, uint b)
		{
			if (a < b)
			{
				return b;
			}
			return a;
		}

		// Token: 0x06002EAA RID: 11946 RVA: 0x000A2F60 File Offset: 0x000A1160
		public static long MaxMagnitude(long a, long b)
		{
			long num = (a < 0L) ? (-a) : a;
			long num2 = (b < 0L) ? (-b) : b;
			if (num < num2)
			{
				return b;
			}
			return a;
		}

		// Token: 0x06002EAB RID: 11947 RVA: 0x00023B20 File Offset: 0x00021D20
		public static ulong MaxMagnitude(ulong a, ulong b)
		{
			if (a < b)
			{
				return b;
			}
			return a;
		}

		// Token: 0x06002EAC RID: 11948 RVA: 0x000A2F88 File Offset: 0x000A1188
		public static float MaxMagnitude(float a, float b)
		{
			float num = (a < 0f) ? (-a) : a;
			float num2 = (b < 0f) ? (-b) : b;
			if (num < num2)
			{
				return b;
			}
			return a;
		}

		// Token: 0x06002EAD RID: 11949 RVA: 0x000A2FB8 File Offset: 0x000A11B8
		public static double MaxMagnitude(double a, double b)
		{
			double num = (a < 0.0) ? (-a) : a;
			double num2 = (b < 0.0) ? (-b) : b;
			if (num < num2)
			{
				return b;
			}
			return a;
		}

		// Token: 0x06002EAE RID: 11950 RVA: 0x000A2FF0 File Offset: 0x000A11F0
		public static sbyte MinMagnitude(sbyte a, sbyte b)
		{
			sbyte b2 = (a < 0) ? (-a) : a;
			sbyte b3 = (b < 0) ? (-b) : b;
			if (b2 > b3)
			{
				return b;
			}
			return a;
		}

		// Token: 0x06002EAF RID: 11951 RVA: 0x00023B29 File Offset: 0x00021D29
		public static byte MinMagnitude(byte a, byte b)
		{
			if (a > b)
			{
				return b;
			}
			return a;
		}

		// Token: 0x06002EB0 RID: 11952 RVA: 0x000A3018 File Offset: 0x000A1218
		public static short MinMagnitude(short a, short b)
		{
			short num = (a < 0) ? (-a) : a;
			short num2 = (b < 0) ? (-b) : b;
			if (num > num2)
			{
				return b;
			}
			return a;
		}

		// Token: 0x06002EB1 RID: 11953 RVA: 0x00023B29 File Offset: 0x00021D29
		public static ushort MinMagnitude(ushort a, ushort b)
		{
			if (a > b)
			{
				return b;
			}
			return a;
		}

		// Token: 0x06002EB2 RID: 11954 RVA: 0x000A3040 File Offset: 0x000A1240
		public static int MinMagnitude(int a, int b)
		{
			int num = (a < 0) ? (-a) : a;
			int num2 = (b < 0) ? (-b) : b;
			if (num > num2)
			{
				return b;
			}
			return a;
		}

		// Token: 0x06002EB3 RID: 11955 RVA: 0x00023B32 File Offset: 0x00021D32
		public static uint MinMagnitude(uint a, uint b)
		{
			if (a > b)
			{
				return b;
			}
			return a;
		}

		// Token: 0x06002EB4 RID: 11956 RVA: 0x000A3068 File Offset: 0x000A1268
		public static long MinMagnitude(long a, long b)
		{
			long num = (a < 0L) ? (-a) : a;
			long num2 = (b < 0L) ? (-b) : b;
			if (num > num2)
			{
				return b;
			}
			return a;
		}

		// Token: 0x06002EB5 RID: 11957 RVA: 0x00023B32 File Offset: 0x00021D32
		public static ulong MinMagnitude(ulong a, ulong b)
		{
			if (a > b)
			{
				return b;
			}
			return a;
		}

		// Token: 0x06002EB6 RID: 11958 RVA: 0x000A3090 File Offset: 0x000A1290
		public static float MinMagnitude(float a, float b)
		{
			float num = (a < 0f) ? (-a) : a;
			float num2 = (b < 0f) ? (-b) : b;
			if (num > num2)
			{
				return b;
			}
			return a;
		}

		// Token: 0x06002EB7 RID: 11959 RVA: 0x000A30C0 File Offset: 0x000A12C0
		public static double MinMagnitude(double a, double b)
		{
			double num = (a < 0.0) ? (-a) : a;
			double num2 = (b < 0.0) ? (-b) : b;
			if (num > num2)
			{
				return b;
			}
			return a;
		}

		// Token: 0x06002EB8 RID: 11960 RVA: 0x00023B3B File Offset: 0x00021D3B
		public static bool IsMoreMagnitudeOrEqual(sbyte a, sbyte b)
		{
			if (a < 0)
			{
				a = -a;
			}
			if (b < 0)
			{
				b = -b;
			}
			return a >= b;
		}

		// Token: 0x06002EB9 RID: 11961 RVA: 0x00023B56 File Offset: 0x00021D56
		public static bool IsMoreMagnitudeOrEqual(byte a, byte b)
		{
			return a >= b;
		}

		// Token: 0x06002EBA RID: 11962 RVA: 0x00023B5F File Offset: 0x00021D5F
		public static bool IsMoreMagnitudeOrEqual(short a, short b)
		{
			if (a < 0)
			{
				a = -a;
			}
			if (b < 0)
			{
				b = -b;
			}
			return a >= b;
		}

		// Token: 0x06002EBB RID: 11963 RVA: 0x00023B56 File Offset: 0x00021D56
		public static bool IsMoreMagnitudeOrEqual(ushort a, ushort b)
		{
			return a >= b;
		}

		// Token: 0x06002EBC RID: 11964 RVA: 0x00023B7A File Offset: 0x00021D7A
		public static bool IsMoreMagnitudeOrEqual(int a, int b)
		{
			if (a < 0)
			{
				a = -a;
			}
			if (b < 0)
			{
				b = -b;
			}
			return a >= b;
		}

		// Token: 0x06002EBD RID: 11965 RVA: 0x00023B93 File Offset: 0x00021D93
		public static bool IsMoreMagnitudeOrEqual(uint a, uint b)
		{
			return a >= b;
		}

		// Token: 0x06002EBE RID: 11966 RVA: 0x00023B9C File Offset: 0x00021D9C
		public static bool IsMoreMagnitudeOrEqual(long a, long b)
		{
			if (a < 0L)
			{
				a = -a;
			}
			if (b < 0L)
			{
				b = -b;
			}
			return a >= b;
		}

		// Token: 0x06002EBF RID: 11967 RVA: 0x00023B93 File Offset: 0x00021D93
		public static bool IsMoreMagnitudeOrEqual(ulong a, ulong b)
		{
			return a >= b;
		}

		// Token: 0x06002EC0 RID: 11968 RVA: 0x00023BB7 File Offset: 0x00021DB7
		public static bool IsMoreMagnitudeOrEqual(float a, float b)
		{
			if (a < 0f)
			{
				a = -a;
			}
			if (b < 0f)
			{
				b = -b;
			}
			return a >= b;
		}

		// Token: 0x06002EC1 RID: 11969 RVA: 0x00023BD8 File Offset: 0x00021DD8
		public static bool IsMoreMagnitudeOrEqual(double a, double b)
		{
			if (a < 0.0)
			{
				a = -a;
			}
			if (b < 0.0)
			{
				b = -b;
			}
			return a >= b;
		}

		// Token: 0x06002EC2 RID: 11970 RVA: 0x00023C01 File Offset: 0x00021E01
		public static bool IsLessMagnitudeOrEqual(sbyte a, sbyte b)
		{
			if (a < 0)
			{
				a = -a;
			}
			if (b < 0)
			{
				b = -b;
			}
			return a <= b;
		}

		// Token: 0x06002EC3 RID: 11971 RVA: 0x00023C1C File Offset: 0x00021E1C
		public static bool IsLessMagnitudeOrEqual(byte a, byte b)
		{
			return a <= b;
		}

		// Token: 0x06002EC4 RID: 11972 RVA: 0x00023C25 File Offset: 0x00021E25
		public static bool IsLessMagnitudeOrEqual(short a, short b)
		{
			if (a < 0)
			{
				a = -a;
			}
			if (b < 0)
			{
				b = -b;
			}
			return a <= b;
		}

		// Token: 0x06002EC5 RID: 11973 RVA: 0x00023C1C File Offset: 0x00021E1C
		public static bool IsLessMagnitudeOrEqual(ushort a, ushort b)
		{
			return a <= b;
		}

		// Token: 0x06002EC6 RID: 11974 RVA: 0x00023C40 File Offset: 0x00021E40
		public static bool IsLessMagnitudeOrEqual(int a, int b)
		{
			if (a < 0)
			{
				a = -a;
			}
			if (b < 0)
			{
				b = -b;
			}
			return a <= b;
		}

		// Token: 0x06002EC7 RID: 11975 RVA: 0x00023C59 File Offset: 0x00021E59
		public static bool IsLessMagnitudeOrEqual(uint a, uint b)
		{
			return a <= b;
		}

		// Token: 0x06002EC8 RID: 11976 RVA: 0x00023C62 File Offset: 0x00021E62
		public static bool IsLessMagnitudeOrEqual(long a, long b)
		{
			if (a < 0L)
			{
				a = -a;
			}
			if (b < 0L)
			{
				b = -b;
			}
			return a <= b;
		}

		// Token: 0x06002EC9 RID: 11977 RVA: 0x00023C59 File Offset: 0x00021E59
		public static bool IsLessMagnitudeOrEqual(ulong a, ulong b)
		{
			return a <= b;
		}

		// Token: 0x06002ECA RID: 11978 RVA: 0x00023C7D File Offset: 0x00021E7D
		public static bool IsLessMagnitudeOrEqual(float a, float b)
		{
			if (a < 0f)
			{
				a = -a;
			}
			if (b < 0f)
			{
				b = -b;
			}
			return a <= b;
		}

		// Token: 0x06002ECB RID: 11979 RVA: 0x00023C9E File Offset: 0x00021E9E
		public static bool IsLessMagnitudeOrEqual(double a, double b)
		{
			if (a < 0.0)
			{
				a = -a;
			}
			if (b < 0.0)
			{
				b = -b;
			}
			return a <= b;
		}

		// Token: 0x06002ECC RID: 11980 RVA: 0x00023CC7 File Offset: 0x00021EC7
		public static byte Clamp(byte value, byte min, byte max)
		{
			if (value < min)
			{
				value = min;
			}
			else if (value > max)
			{
				return max;
			}
			return value;
		}

		// Token: 0x06002ECD RID: 11981 RVA: 0x00023CC7 File Offset: 0x00021EC7
		public static sbyte Clamp(sbyte value, sbyte min, sbyte max)
		{
			if (value < min)
			{
				value = min;
			}
			else if (value > max)
			{
				return max;
			}
			return value;
		}

		// Token: 0x06002ECE RID: 11982 RVA: 0x00023CC7 File Offset: 0x00021EC7
		public static short Clamp(short value, short min, short max)
		{
			if (value < min)
			{
				value = min;
			}
			else if (value > max)
			{
				return max;
			}
			return value;
		}

		// Token: 0x06002ECF RID: 11983 RVA: 0x00023CC7 File Offset: 0x00021EC7
		public static ushort Clamp(ushort value, ushort min, ushort max)
		{
			if (value < min)
			{
				value = min;
			}
			else if (value > max)
			{
				return max;
			}
			return value;
		}

		// Token: 0x06002ED0 RID: 11984 RVA: 0x00023CC7 File Offset: 0x00021EC7
		public static int Clamp(int value, int min, int max)
		{
			if (value < min)
			{
				value = min;
			}
			else if (value > max)
			{
				return max;
			}
			return value;
		}

		// Token: 0x06002ED1 RID: 11985 RVA: 0x00023CD9 File Offset: 0x00021ED9
		public static uint Clamp(uint value, uint min, uint max)
		{
			if (value < min)
			{
				value = min;
			}
			else if (value > max)
			{
				return max;
			}
			return value;
		}

		// Token: 0x06002ED2 RID: 11986 RVA: 0x00023CC7 File Offset: 0x00021EC7
		public static long Clamp(long value, long min, long max)
		{
			if (value < min)
			{
				value = min;
			}
			else if (value > max)
			{
				return max;
			}
			return value;
		}

		// Token: 0x06002ED3 RID: 11987 RVA: 0x00023CD9 File Offset: 0x00021ED9
		public static ulong Clamp(ulong value, ulong min, ulong max)
		{
			if (value < min)
			{
				value = min;
			}
			else if (value > max)
			{
				return max;
			}
			return value;
		}

		// Token: 0x06002ED4 RID: 11988 RVA: 0x00023CD9 File Offset: 0x00021ED9
		public static float Clamp(float value, float min, float max)
		{
			if (value < min)
			{
				value = min;
			}
			else if (value > max)
			{
				return max;
			}
			return value;
		}

		// Token: 0x06002ED5 RID: 11989 RVA: 0x00023CD9 File Offset: 0x00021ED9
		public static double Clamp(double value, double min, double max)
		{
			if (value < min)
			{
				value = min;
			}
			else if (value > max)
			{
				return max;
			}
			return value;
		}

		// Token: 0x06002ED6 RID: 11990 RVA: 0x00023CEB File Offset: 0x00021EEB
		public static float Clamp01(float value)
		{
			if (value < 0f)
			{
				return 0f;
			}
			if (value > 1f)
			{
				return 1f;
			}
			return value;
		}

		// Token: 0x06002ED7 RID: 11991 RVA: 0x000A30F8 File Offset: 0x000A12F8
		public static float ClampAngle360(float angle)
		{
			float num = MathTools.Abs(angle);
			if (num >= 360f)
			{
				float num2 = num / 360f;
				float num3 = MathTools.Floor(num2);
				num2 -= num3;
				if (num2 == 0f)
				{
					return 0f;
				}
				if (num2 > 0f)
				{
					angle = (num - num3 * 360f) * MathTools.Sign(angle);
				}
			}
			if (angle < 0f)
			{
				angle = 360f + angle;
			}
			return angle;
		}

		// Token: 0x06002ED8 RID: 11992 RVA: 0x00023D0A File Offset: 0x00021F0A
		public static float ReverseAngleRotationDirection(float angle)
		{
			if (angle == 0f)
			{
				return 180f;
			}
			if (angle == 180f)
			{
				return 0f;
			}
			return 360f - angle + 180f;
		}

		// Token: 0x06002ED9 RID: 11993 RVA: 0x00023D35 File Offset: 0x00021F35
		public static bool AngleIsNear(float angle, float targetAngle, float threshold)
		{
			if (threshold < 0f)
			{
				threshold = Mathf.Abs(threshold);
			}
			return MathTools.AngleIsBetween(angle, targetAngle - threshold, targetAngle + threshold);
		}

		// Token: 0x06002EDA RID: 11994 RVA: 0x00023D53 File Offset: 0x00021F53
		public static bool AngleIsBetween(float angle, float min, float max)
		{
			angle = MathTools.ClampAngle360(angle);
			min = MathTools.ClampAngle360(min);
			max = MathTools.ClampAngle360(max);
			if (min < max)
			{
				return min <= angle && angle <= max;
			}
			return min <= angle || angle <= max;
		}

		// Token: 0x06002EDB RID: 11995 RVA: 0x00023D8C File Offset: 0x00021F8C
		internal static bool TbjaLqCGNEPkPcOzsOhAnVwrQMwI(int A_0, int A_1)
		{
			return (A_0 != 0 || A_1 != 0) && (A_0 & A_1) != 0;
		}

		// Token: 0x06002EDC RID: 11996 RVA: 0x000A3164 File Offset: 0x000A1364
		public static int IntPow(int x, uint pow)
		{
			int num = 1;
			while (pow != 0U)
			{
				if ((pow & 1U) == 1U)
				{
					num *= x;
				}
				x *= x;
				pow >>= 1;
			}
			return num;
		}

		// Token: 0x06002EDD RID: 11997 RVA: 0x00023D9C File Offset: 0x00021F9C
		public static uint RoundUpToPowerOf2(uint value)
		{
			if (value == 0U)
			{
				return 1U;
			}
			value -= 1U;
			value |= value >> 1;
			value |= value >> 2;
			value |= value >> 4;
			value |= value >> 8;
			value |= value >> 16;
			value += 1U;
			return value;
		}

		// Token: 0x06002EDE RID: 11998 RVA: 0x00023DD2 File Offset: 0x00021FD2
		public static float BooleanToSign(bool b)
		{
			if (b)
			{
				return 1f;
			}
			return -1f;
		}

		// Token: 0x06002EDF RID: 11999 RVA: 0x00023DE2 File Offset: 0x00021FE2
		public static bool SignToBoolean(float sign)
		{
			return sign >= 1f;
		}

		// Token: 0x06002EE0 RID: 12000 RVA: 0x00023DEF File Offset: 0x00021FEF
		public static float Sin(float value)
		{
			return (float)Math.Sin((double)value);
		}

		// Token: 0x06002EE1 RID: 12001 RVA: 0x00023DF9 File Offset: 0x00021FF9
		public static float Cos(float value)
		{
			return (float)Math.Cos((double)value);
		}

		// Token: 0x06002EE2 RID: 12002 RVA: 0x00023E03 File Offset: 0x00022003
		public static float Tan(float value)
		{
			return (float)Math.Tan((double)value);
		}

		// Token: 0x06002EE3 RID: 12003 RVA: 0x00023E0D File Offset: 0x0002200D
		public static float Asin(float value)
		{
			return (float)Math.Asin((double)value);
		}

		// Token: 0x06002EE4 RID: 12004 RVA: 0x00023E17 File Offset: 0x00022017
		public static float Acos(float value)
		{
			return (float)Math.Acos((double)value);
		}

		// Token: 0x06002EE5 RID: 12005 RVA: 0x00023E21 File Offset: 0x00022021
		public static float Atan(float value)
		{
			return (float)Math.Atan((double)value);
		}

		// Token: 0x06002EE6 RID: 12006 RVA: 0x00023E2B File Offset: 0x0002202B
		public static float Atan2(float y, float x)
		{
			return (float)Math.Atan2((double)y, (double)x);
		}

		// Token: 0x06002EE7 RID: 12007 RVA: 0x00023E37 File Offset: 0x00022037
		public static float Sqrt(float value)
		{
			return (float)Math.Sqrt((double)value);
		}

		// Token: 0x06002EE8 RID: 12008 RVA: 0x00023E41 File Offset: 0x00022041
		public static float Pow(float value, float p)
		{
			return (float)Math.Pow((double)value, (double)p);
		}

		// Token: 0x06002EE9 RID: 12009 RVA: 0x00023E4D File Offset: 0x0002204D
		public static float Exp(float power)
		{
			return (float)Math.Exp((double)power);
		}

		// Token: 0x06002EEA RID: 12010 RVA: 0x00023E57 File Offset: 0x00022057
		public static float Log(float value, float p)
		{
			return (float)Math.Log((double)value, (double)p);
		}

		// Token: 0x06002EEB RID: 12011 RVA: 0x00023E63 File Offset: 0x00022063
		public static float Log(float value)
		{
			return (float)Math.Log((double)value);
		}

		// Token: 0x06002EEC RID: 12012 RVA: 0x00023E6D File Offset: 0x0002206D
		public static float Log10(float value)
		{
			return (float)Math.Log10((double)value);
		}

		// Token: 0x06002EED RID: 12013 RVA: 0x00023E77 File Offset: 0x00022077
		public static float Ceil(float value)
		{
			return (float)Math.Ceiling((double)value);
		}

		// Token: 0x06002EEE RID: 12014 RVA: 0x00023E81 File Offset: 0x00022081
		public static float Floor(float value)
		{
			return (float)Math.Floor((double)value);
		}

		// Token: 0x06002EEF RID: 12015 RVA: 0x00023E8B File Offset: 0x0002208B
		public static float Round(float value)
		{
			return (float)Math.Round((double)value);
		}

		// Token: 0x06002EF0 RID: 12016 RVA: 0x00023E95 File Offset: 0x00022095
		public static int CeilToInt(float value)
		{
			return (int)Math.Ceiling((double)value);
		}

		// Token: 0x06002EF1 RID: 12017 RVA: 0x00023E9F File Offset: 0x0002209F
		public static int FloorToInt(float value)
		{
			return (int)Math.Floor((double)value);
		}

		// Token: 0x06002EF2 RID: 12018 RVA: 0x00023EA9 File Offset: 0x000220A9
		public static int RoundToInt(float value)
		{
			return (int)Math.Round((double)value);
		}

		// Token: 0x06002EF3 RID: 12019 RVA: 0x00023EB3 File Offset: 0x000220B3
		public static float Sign(float value)
		{
			if (value >= 0f)
			{
				return 1f;
			}
			return -1f;
		}

		// Token: 0x06002EF4 RID: 12020 RVA: 0x00023EC8 File Offset: 0x000220C8
		public static int Sign(int value)
		{
			if (value >= 0)
			{
				return 1;
			}
			return -1;
		}

		// Token: 0x06002EF5 RID: 12021 RVA: 0x00023ED1 File Offset: 0x000220D1
		public static float Repeat(float t, float length)
		{
			return t - MathTools.Floor(t / length) * length;
		}

		// Token: 0x06002EF6 RID: 12022 RVA: 0x000A3190 File Offset: 0x000A1390
		public static float DeltaAngle(float current, float target)
		{
			float num = MathTools.Repeat(target - current, 360f);
			if (num > 180f)
			{
				num -= 360f;
			}
			return num;
		}

		// Token: 0x06002EF7 RID: 12023 RVA: 0x000A31BC File Offset: 0x000A13BC
		public static Vector2 MaxMagnitude(Vector2 a, Vector2 b)
		{
			float sqrMagnitude = a.sqrMagnitude;
			float sqrMagnitude2 = b.sqrMagnitude;
			if (sqrMagnitude >= sqrMagnitude2)
			{
				return a;
			}
			return b;
		}

		// Token: 0x06002EF8 RID: 12024 RVA: 0x000A31E0 File Offset: 0x000A13E0
		public static Vector3 MaxMagnitude(Vector3 a, Vector3 b)
		{
			float sqrMagnitude = a.sqrMagnitude;
			float sqrMagnitude2 = b.sqrMagnitude;
			if (sqrMagnitude >= sqrMagnitude2)
			{
				return a;
			}
			return b;
		}

		// Token: 0x06002EF9 RID: 12025 RVA: 0x000A3204 File Offset: 0x000A1404
		public static Vector2 MinMagnitude(Vector2 a, Vector2 b)
		{
			float sqrMagnitude = a.sqrMagnitude;
			float sqrMagnitude2 = b.sqrMagnitude;
			if (sqrMagnitude <= sqrMagnitude2)
			{
				return a;
			}
			return b;
		}

		// Token: 0x06002EFA RID: 12026 RVA: 0x000A3228 File Offset: 0x000A1428
		public static Vector3 MinMagnitude(Vector3 a, Vector3 b)
		{
			float sqrMagnitude = a.sqrMagnitude;
			float sqrMagnitude2 = b.sqrMagnitude;
			if (sqrMagnitude <= sqrMagnitude2)
			{
				return a;
			}
			return b;
		}

		// Token: 0x06002EFB RID: 12027 RVA: 0x000A324C File Offset: 0x000A144C
		public static Vector2 Clamp(Vector2 value, Vector2 min, Vector2 max)
		{
			return new Vector2((value.x < min.x) ? min.x : ((value.x > max.x) ? max.x : value.x), (value.y < min.y) ? min.y : ((value.y > max.y) ? max.y : value.y));
		}

		// Token: 0x06002EFC RID: 12028 RVA: 0x000A32C4 File Offset: 0x000A14C4
		public static Vector2 Clamp(Vector2 value, float min, float max)
		{
			return new Vector2((value.x < min) ? min : ((value.x > max) ? max : value.x), (value.y < min) ? min : ((value.y > max) ? max : value.y));
		}

		// Token: 0x06002EFD RID: 12029 RVA: 0x000A3314 File Offset: 0x000A1514
		public static Vector2 Clamp(Vector3 value, Vector3 min, Vector3 max)
		{
			return new Vector3((value.x < min.x) ? min.x : ((value.x > max.x) ? max.x : value.x), (value.y < min.y) ? min.y : ((value.y > max.y) ? max.y : value.y), (value.z < min.z) ? min.z : ((value.z > max.z) ? max.z : value.z));
		}

		// Token: 0x06002EFE RID: 12030 RVA: 0x000A33C4 File Offset: 0x000A15C4
		public static Vector2 Clamp(Vector3 value, float min, float max)
		{
			return new Vector3((value.x < min) ? min : ((value.x > max) ? max : value.x), (value.y < min) ? min : ((value.y > max) ? max : value.y), (value.z < min) ? min : ((value.z > max) ? max : value.z));
		}

		// Token: 0x06002EFF RID: 12031 RVA: 0x00023EDF File Offset: 0x000220DF
		public static float Cross(Vector2 a, Vector2 b)
		{
			return a.x * b.y - a.y * b.x;
		}

		// Token: 0x06002F00 RID: 12032 RVA: 0x00023EFC File Offset: 0x000220FC
		public static float Multiply(Vector2 a, Vector2 b)
		{
			return a.x * b.x + a.y * b.y;
		}

		// Token: 0x06002F01 RID: 12033 RVA: 0x000A3438 File Offset: 0x000A1638
		public static bool RectContains(Rect rect, Vector2 pos, float rotation = 0f)
		{
			if (rotation == 0f)
			{
				return rect.Contains(pos);
			}
			Vector2 point = MathTools.RotateWorldPoint(pos, rect.center, -rotation);
			return rect.Contains(point);
		}

		// Token: 0x06002F02 RID: 12034 RVA: 0x000A3470 File Offset: 0x000A1670
		public static Vector2 RotateWorldPoint(Vector2 point, Vector2 center, float angle)
		{
			float num = point.x - center.x;
			float num2 = point.y - center.y;
			float value = 0.017453292f * MathTools.ClampAngle360(angle);
			float num3 = MathTools.Cos(value);
			float num4 = MathTools.Sin(value);
			float num5 = num * num3 - num2 * num4;
			float num6 = num * num4 + num2 * num3;
			return new Vector2(center.x + num5, center.y + num6);
		}

		// Token: 0x06002F03 RID: 12035 RVA: 0x000A34D8 File Offset: 0x000A16D8
		public static Vector2 RotateLocalPoint(Vector2 point, float angle)
		{
			float x = point.x;
			float y = point.y;
			float value = 0.017453292f * MathTools.ClampAngle360(angle);
			float num = MathTools.Cos(value);
			float num2 = MathTools.Sin(value);
			float x2 = x * num - y * num2;
			float y2 = x * num2 + y * num;
			return new Vector2(x2, y2);
		}

		// Token: 0x06002F04 RID: 12036 RVA: 0x000A3524 File Offset: 0x000A1724
		public static bool LineIntersectsRect(Vector2 point1, Vector2 point2, Rect rect, out float sqrMagnitude)
		{
			sqrMagnitude = float.PositiveInfinity;
			if (rect.Contains(point1) || rect.Contains(point2))
			{
				sqrMagnitude = 0f;
				return true;
			}
			Vector2 a;
			bool flag = MathTools.LineSegementsIntersect(point1, point2, new Vector2(rect.xMin, rect.yMin), new Vector2(rect.xMin, rect.yMax), out a, true);
			Vector2 a2;
			bool flag2 = MathTools.LineSegementsIntersect(point1, point2, new Vector2(rect.xMax, rect.yMin), new Vector2(rect.xMax, rect.yMax), out a2, true);
			Vector2 a3;
			bool flag3 = MathTools.LineSegementsIntersect(point1, point2, new Vector2(rect.xMin, rect.yMax), new Vector2(rect.xMax, rect.yMax), out a3, true);
			Vector2 a4;
			bool flag4 = MathTools.LineSegementsIntersect(point1, point2, new Vector2(rect.xMin, rect.yMin), new Vector2(rect.xMax, rect.yMax), out a4, true);
			if (!flag && !flag2 && !flag3 && !flag4)
			{
				return false;
			}
			if (flag)
			{
				sqrMagnitude = ((sqrMagnitude != float.PositiveInfinity) ? MathTools.Min(sqrMagnitude, (a - point1).sqrMagnitude) : (a - point1).sqrMagnitude);
			}
			if (flag2)
			{
				sqrMagnitude = ((sqrMagnitude != float.PositiveInfinity) ? MathTools.Min(sqrMagnitude, (a2 - point1).sqrMagnitude) : (a2 - point1).sqrMagnitude);
			}
			if (flag3)
			{
				sqrMagnitude = ((sqrMagnitude != float.PositiveInfinity) ? MathTools.Min(sqrMagnitude, (a3 - point1).sqrMagnitude) : (a3 - point1).sqrMagnitude);
			}
			if (flag4)
			{
				sqrMagnitude = ((sqrMagnitude != float.PositiveInfinity) ? MathTools.Min(sqrMagnitude, (a4 - point1).sqrMagnitude) : (a4 - point1).sqrMagnitude);
			}
			return true;
		}

		// Token: 0x06002F05 RID: 12037 RVA: 0x000A3710 File Offset: 0x000A1910
		public static bool LineSegementsIntersect(Vector2 line1p1, Vector2 line1p2, Vector2 line2p1, Vector2 line2p2, out Vector2 intersection, bool collinearIntersects = false)
		{
			intersection = default(Vector2);
			Vector2 vector = line1p2 - line1p1;
			Vector2 vector2 = line2p2 - line2p1;
			float num = MathTools.Cross(vector, vector2);
			float value = MathTools.Cross(line2p1 - line1p1, vector);
			if (MathTools.IsZero(num) && MathTools.IsZero(value))
			{
				return collinearIntersects && ((0f <= MathTools.Multiply(line2p1 - line1p1, vector) && MathTools.Multiply(line2p1 - line1p1, vector) <= MathTools.Multiply(vector, vector)) || (0f <= MathTools.Multiply(line1p1 - line2p1, vector2) && MathTools.Multiply(line1p1 - line2p1, vector2) <= MathTools.Multiply(vector2, vector2)));
			}
			if (MathTools.IsZero(num) && !MathTools.IsZero(value))
			{
				return false;
			}
			float num2 = MathTools.Cross(line2p1 - line1p1, vector2) / num;
			float num3 = MathTools.Cross(line2p1 - line1p1, vector) / num;
			if (!MathTools.IsZero(num) && 0f <= num2 && num2 <= 1f && 0f <= num3 && num3 <= 1f)
			{
				intersection = line1p1 + num2 * vector;
				return true;
			}
			return false;
		}

		// Token: 0x06002F06 RID: 12038 RVA: 0x000A3830 File Offset: 0x000A1A30
		private static bool NncOJeeiRdcckMwVjBXDqpJnySOc(Vector2 A_0, Vector2 A_1, Vector2 A_2, Vector2 A_3, out Vector2 A_4)
		{
			float num = A_1.y - A_0.y;
			float num2 = A_0.x - A_1.x;
			float num3 = num * A_0.x + num2 * A_0.y;
			float num4 = A_3.y - A_2.y;
			float num5 = A_2.x - A_3.x;
			float num6 = num4 * A_2.x + num5 * A_2.y;
			float num7 = num * num5 - num4 * num2;
			if (num7 == 0f)
			{
				A_4 = Vector2.zero;
				return false;
			}
			A_4 = new Vector2((num5 * num3 - num2 * num6) / num7, (num * num6 - num4 * num3) / num7);
			return true;
		}

		// Token: 0x06002F07 RID: 12039 RVA: 0x000A38E4 File Offset: 0x000A1AE4
		public static bool RectContains(Rect container, Rect child)
		{
			return child.xMin >= container.xMin && child.xMax <= container.xMax && child.yMin >= container.yMin && child.yMax <= container.yMax;
		}

		// Token: 0x06002F08 RID: 12040 RVA: 0x000A393C File Offset: 0x000A1B3C
		public static bool GetOffsetToContainRect(Rect container, Rect child, out Vector2 offset)
		{
			offset = default(Vector2);
			if (container.width < child.width || container.height < child.height)
			{
				return false;
			}
			if (child.xMin < container.xMin)
			{
				offset.x += container.xMin - child.xMin;
			}
			if (child.xMax > container.xMax)
			{
				offset.x += container.xMax - child.xMax;
			}
			if (child.yMin < container.yMin)
			{
				offset.y += container.yMin - child.yMin;
			}
			if (child.yMax > container.yMax)
			{
				offset.y += container.yMax - child.yMax;
			}
			return true;
		}

		// Token: 0x06002F09 RID: 12041 RVA: 0x00023F19 File Offset: 0x00022119
		public static Matrix4x4 TransformTo(Transform from, Transform to)
		{
			return to.worldToLocalMatrix * from.localToWorldMatrix;
		}

		// Token: 0x06002F0A RID: 12042 RVA: 0x000A3A18 File Offset: 0x000A1C18
		public static Rect TransformRect(Rect fromRect, Transform from, Transform to)
		{
			Matrix4x4 matrix4x = MathTools.TransformTo(from, to);
			Vector3 vector = new Vector2(fromRect.xMin, fromRect.yMin);
			Vector3 vector2 = new Vector2(fromRect.xMax, fromRect.yMax);
			vector = matrix4x.MultiplyPoint(vector);
			vector2 = matrix4x.MultiplyPoint(vector2);
			fromRect.xMin = vector.x;
			fromRect.yMin = vector.y;
			fromRect.xMax = vector2.x;
			fromRect.yMax = vector2.y;
			return fromRect;
		}

		// Token: 0x06002F0B RID: 12043 RVA: 0x000A3AA8 File Offset: 0x000A1CA8
		public static Vector2 SnapVectorToNearestAngle(Vector2 vector, float angle)
		{
			float num = Vector2.Angle(vector, Vector3.up);
			if (num < angle / 2f)
			{
				return Vector2.up * vector.magnitude;
			}
			if (num > 180f - angle / 2f)
			{
				return -Vector2.up * vector.magnitude;
			}
			float angle2 = Mathf.Round(num / angle) * angle - num;
			Vector3 axis = Vector3.Cross(Vector3.up, vector);
			return Quaternion.AngleAxis(angle2, axis) * vector;
		}

		// Token: 0x06002F0C RID: 12044 RVA: 0x000A3B3C File Offset: 0x000A1D3C
		public static float SignedAngle(Vector3 from, Vector3 to, Vector3 axis)
		{
			float num = Vector3.Angle(from, to);
			float num2 = from.y * to.z - from.z * to.y;
			float num3 = from.z * to.x - from.x * to.z;
			float num4 = from.x * to.y - from.y * to.x;
			float num5 = Mathf.Sign(axis.x * num2 + axis.y * num3 + axis.z * num4);
			return num * num5;
		}

		// Token: 0x040019AF RID: 6575
		private const float JzEXbQnvOvTKBmHELjLLEFYcMjHnA = 1E-10f;

		// Token: 0x040019B0 RID: 6576
		private const double UzWceaUevPsrkxUSenQnTczRMoTJ = 1E-10;

		// Token: 0x040019B1 RID: 6577
		private const float SLlezwLYpCcoWfMpQsJOBjECOmjK = 0.0001f;

		// Token: 0x040019B2 RID: 6578
		public const float PI = 3.1415927f;

		// Token: 0x040019B3 RID: 6579
		public const float Infinity = float.PositiveInfinity;

		// Token: 0x040019B4 RID: 6580
		public const float NegativeInfinity = float.NegativeInfinity;

		// Token: 0x040019B5 RID: 6581
		public const float Deg2Rad = 0.017453292f;

		// Token: 0x040019B6 RID: 6582
		public const float Rad2Deg = 57.29578f;

		// Token: 0x040019B7 RID: 6583
		public const float Epsilon = 1E-45f;
	}
}
