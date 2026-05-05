using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000213 RID: 531
	internal static class TypeInfo
	{
		// Token: 0x06000FB1 RID: 4017 RVA: 0x00079FFA File Offset: 0x000781FA
		public static TEnum[] GetEnumValues<TEnum>() where TEnum : struct, IConvertible
		{
			return TypeInfo.EnumInfoJITCache<TEnum>.values;
		}

		// Token: 0x06000FB2 RID: 4018 RVA: 0x0007A001 File Offset: 0x00078201
		public static int GetEnumLength<TEnum>() where TEnum : struct, IConvertible
		{
			return TypeInfo.EnumInfoJITCache<TEnum>.length;
		}

		// Token: 0x06000FB3 RID: 4019 RVA: 0x0007A008 File Offset: 0x00078208
		public static string[] GetEnumNames<TEnum>() where TEnum : struct, IConvertible
		{
			return TypeInfo.EnumInfoJITCache<TEnum>.names;
		}

		// Token: 0x06000FB4 RID: 4020 RVA: 0x0007A00F File Offset: 0x0007820F
		public static TEnum GetEnumLastValue<TEnum>() where TEnum : struct, IConvertible
		{
			return TypeInfo.GetEnumValues<TEnum>()[TypeInfo.GetEnumLength<TEnum>() - 1];
		}

		// Token: 0x0200044A RID: 1098
		private struct EnumInfoJITCache<TEnum> where TEnum : struct, IConvertible
		{
			// Token: 0x0600144E RID: 5198 RVA: 0x00099548 File Offset: 0x00097748
			static EnumInfoJITCache()
			{
				if (!typeof(TEnum).IsEnum)
				{
					throw new InvalidOperationException(string.Format("{0} must be an enum type.", typeof(TEnum)));
				}
				TypeInfo.EnumInfoJITCache<TEnum>.names = Enum.GetNames(typeof(TEnum));
				TypeInfo.EnumInfoJITCache<TEnum>.length = TypeInfo.EnumInfoJITCache<TEnum>.names.Length;
				TypeInfo.EnumInfoJITCache<TEnum>.values = new TEnum[TypeInfo.EnumInfoJITCache<TEnum>.length];
				Array array = Enum.GetValues(typeof(TEnum));
				for (int i = 0; i < TypeInfo.EnumInfoJITCache<TEnum>.values.Length; i++)
				{
					TypeInfo.EnumInfoJITCache<TEnum>.values[i] = (TEnum)((object)array.GetValue(i));
				}
			}

			// Token: 0x040029A5 RID: 10661
			public static readonly TEnum[] values;

			// Token: 0x040029A6 RID: 10662
			public static readonly string[] names;

			// Token: 0x040029A7 RID: 10663
			public static readonly int length;
		}
	}
}
