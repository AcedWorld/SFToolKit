using System;

namespace Rewired.Utils
{
	// Token: 0x02000490 RID: 1168
	public static class EnumTools
	{
		// Token: 0x06002E4C RID: 11852 RVA: 0x000A230C File Offset: 0x000A050C
		public static string GetName<TEnum>(TEnum value) where TEnum : struct, IComparable, IFormattable
		{
			string result;
			try
			{
				result = Enum.GetName(typeof(TEnum), value);
			}
			catch
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06002E4D RID: 11853 RVA: 0x000A2348 File Offset: 0x000A0548
		public static bool ConvertByName<TEnumFrom, TEnumTo>(TEnumFrom convertFrom, out TEnumTo value) where TEnumFrom : struct, IComparable, IFormattable where TEnumTo : struct, IComparable, IFormattable
		{
			if (!ReflectionTools.IsEnum(typeof(TEnumFrom)))
			{
				throw new ArgumentException("TEnumFrom must be an enumerated type.");
			}
			if (!ReflectionTools.IsEnum(typeof(TEnumTo)))
			{
				throw new ArgumentException("TEnumTo must be an enumerated type.");
			}
			string[] names = Enum.GetNames(typeof(TEnumTo));
			int num = Array.IndexOf<string>(names, convertFrom.ToString());
			if (num < 0)
			{
				value = default(TEnumTo);
				return false;
			}
			value = (TEnumTo)((object)Enum.Parse(typeof(TEnumTo), names[num]));
			return true;
		}

		// Token: 0x06002E4E RID: 11854 RVA: 0x000237E6 File Offset: 0x000219E6
		public static int[] GetIntValues(Type enumType)
		{
			return ArrayTools.ConvertToIntArray(Enum.GetValues(enumType));
		}

		// Token: 0x06002E4F RID: 11855 RVA: 0x000237F3 File Offset: 0x000219F3
		public static bool IsEnum(Type type)
		{
			return ReflectionTools.IsEnum(type);
		}

		// Token: 0x06002E50 RID: 11856 RVA: 0x000237FB File Offset: 0x000219FB
		public static Type GetUnderlyingType(Type type)
		{
			return ReflectionTools.GetUnderlyingEnumType(type);
		}

		// Token: 0x06002E51 RID: 11857 RVA: 0x000A23DC File Offset: 0x000A05DC
		public static bool IsValidUnderlyingType(Type underlyingType)
		{
			return underlyingType == typeof(int) || underlyingType == typeof(uint) || underlyingType == typeof(byte) || underlyingType == typeof(sbyte) || underlyingType == typeof(short) || underlyingType == typeof(ushort) || underlyingType == typeof(long) || underlyingType == typeof(ulong);
		}
	}
}
