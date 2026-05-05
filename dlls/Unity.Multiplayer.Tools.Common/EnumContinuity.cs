using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Unity.Multiplayer.Tools.Common
{
	// Token: 0x0200000F RID: 15
	internal static class EnumContinuity
	{
		// Token: 0x06000038 RID: 56 RVA: 0x00002480 File Offset: 0x00000680
		[return: TupleElementNames(new string[]
		{
			"min",
			"max",
			"uniqueValueCount"
		})]
		public static ValueTuple<int, int, int> GetMinMaxAndUniqueValueCount<TEnum>() where TEnum : Enum
		{
			TEnum[] values = EnumUtil.GetValues<TEnum>();
			int num = int.MinValue;
			int num2 = int.MaxValue;
			HashSet<int> hashSet = new HashSet<int>();
			TEnum[] array = values;
			for (int i = 0; i < array.Length; i++)
			{
				int num3 = Convert.ToInt32(array[i]);
				num = Math.Max(num, num3);
				num2 = Math.Min(num2, num3);
				hashSet.Add(num3);
			}
			return new ValueTuple<int, int, int>(num2, num, hashSet.Count);
		}

		// Token: 0x06000039 RID: 57 RVA: 0x000024F4 File Offset: 0x000006F4
		public static int ValidateEnumForEnumMap<[IsUnmanaged] TEnum, TValue>() where TEnum : struct, ValueType, Enum
		{
			if (Enum.GetUnderlyingType(typeof(TEnum)) != typeof(int))
			{
				throw new UnhandledEnumBackingTypeException<TEnum, TValue>();
			}
			ValueTuple<int, int, int> minMaxAndUniqueValueCount = EnumContinuity.GetMinMaxAndUniqueValueCount<TEnum>();
			int item = minMaxAndUniqueValueCount.Item1;
			int item2 = minMaxAndUniqueValueCount.Item2;
			int item3 = minMaxAndUniqueValueCount.Item3;
			if (item3 <= 0)
			{
				throw new EmptyEnumException<TEnum, TValue>();
			}
			if (item != 0)
			{
				throw new NonZeroEnumMinimumValueException<TEnum, TValue>();
			}
			if (item2 - item + 1 != item3)
			{
				throw new DiscontinuousEnumException<TEnum, TValue>();
			}
			return item3;
		}
	}
}
