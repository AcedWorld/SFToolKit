using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Unity.VisualScripting
{
	// Token: 0x02000154 RID: 340
	public static class EnumUtility
	{
		// Token: 0x0600091E RID: 2334 RVA: 0x00027A5C File Offset: 0x00025C5C
		public static bool HasFlag(this Enum value, Enum flag)
		{
			long num = Convert.ToInt64(value);
			long num2 = Convert.ToInt64(flag);
			return (num & num2) == num2;
		}

		// Token: 0x0600091F RID: 2335 RVA: 0x00027A7C File Offset: 0x00025C7C
		public static Dictionary<string, Enum> ValuesByNames(Type enumType, bool obsolete = false)
		{
			Ensure.That("enumType").IsNotNull<Type>(enumType);
			IEnumerable<FieldInfo> source = enumType.GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			if (!obsolete)
			{
				source = from f in source
				where !f.IsDefined(typeof(ObsoleteAttribute), false)
				select f;
			}
			return source.ToDictionary((FieldInfo f) => f.Name, (FieldInfo f) => (Enum)f.GetValue(null));
		}

		// Token: 0x06000920 RID: 2336 RVA: 0x00027B10 File Offset: 0x00025D10
		public static Dictionary<string, T> ValuesByNames<T>(bool obsolete = false)
		{
			IEnumerable<FieldInfo> source = typeof(T).GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			if (!obsolete)
			{
				source = from f in source
				where !f.IsDefined(typeof(ObsoleteAttribute), false)
				select f;
			}
			return source.ToDictionary((FieldInfo f) => f.Name, (FieldInfo f) => (T)((object)f.GetValue(null)));
		}
	}
}
