using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Unity.Multiplayer.Tools.Common;

namespace Unity.Multiplayer.Tools.NetStats
{
	// Token: 0x02000023 RID: 35
	public static class MetricIdTypeLibrary
	{
		// Token: 0x1700002D RID: 45
		// (get) Token: 0x0600008C RID: 140 RVA: 0x00002EAD File Offset: 0x000010AD
		internal static IReadOnlyList<Type> Types
		{
			get
			{
				return MetricIdTypeLibrary.k_Types;
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x0600008D RID: 141 RVA: 0x00002EB4 File Offset: 0x000010B4
		internal static IReadOnlyList<string> TypeDisplayNames
		{
			get
			{
				return MetricIdTypeLibrary.k_TypeDisplayNames;
			}
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00002EBC File Offset: 0x000010BC
		static MetricIdTypeLibrary()
		{
			TypeRegistration.RunIfNeeded();
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00002F1E File Offset: 0x0000111E
		public static void RegisterType<TEnumType>()
		{
			MetricIdTypeLibrary.k_Types.Add(typeof(TEnumType));
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00002F34 File Offset: 0x00001134
		internal static void TypeRegistrationPostProcess()
		{
			MetricIdTypeLibrary.k_Types.Sort(delegate(Type a, Type b)
			{
				MetricTypeSortPriorityAttribute customAttribute2 = a.GetCustomAttribute<MetricTypeSortPriorityAttribute>();
				SortPriority sortPriority = (customAttribute2 != null) ? customAttribute2.SortPriority : SortPriority.Neutral;
				MetricTypeSortPriorityAttribute customAttribute3 = b.GetCustomAttribute<MetricTypeSortPriorityAttribute>();
				SortPriority sortPriority2 = (customAttribute3 != null) ? customAttribute3.SortPriority : SortPriority.Neutral;
				int num = sortPriority.CompareTo(sortPriority2);
				if (num != 0)
				{
					return num;
				}
				return StringComparer.InvariantCulture.Compare(a.FullName, b.FullName);
			});
			foreach (Type type in MetricIdTypeLibrary.k_Types)
			{
				MetricTypeEnumAttribute customAttribute = type.GetCustomAttribute<MetricTypeEnumAttribute>();
				string item = ((customAttribute != null) ? customAttribute.DisplayName : null) ?? type.Name;
				int[] array = type.GetEnumValues().Cast<int>().ToArray<int>();
				string[] enumNames = type.GetEnumNames();
				Array.Sort<string, int>(enumNames, array);
				string[] array2 = new string[array.Length];
				MetricKind[] array3 = new MetricKind[array.Length];
				BaseUnits[] array4 = new BaseUnits[array.Length];
				bool[] array5 = new bool[array.Length];
				for (int i = 0; i < array.Length; i++)
				{
					string text = enumNames[i];
					MemberInfo memberInfo = type.GetMember(text).FirstOrDefault<MemberInfo>();
					MetricMetadataAttribute metricMetadataAttribute = (memberInfo != null) ? memberInfo.GetCustomAttribute<MetricMetadataAttribute>() : null;
					if (metricMetadataAttribute != null)
					{
						array2[i] = (metricMetadataAttribute.DisplayName ?? StringUtil.AddSpacesToCamelCase(text));
						array3[i] = metricMetadataAttribute.MetricKind;
						array4[i] = metricMetadataAttribute.Units.GetBaseUnits();
						array5[i] = metricMetadataAttribute.DisplayAsPercentage;
					}
					ref string ptr = ref array2[i];
					if (ptr == null)
					{
						ptr = StringUtil.AddSpacesToCamelCase(text);
					}
					if (array3[i] == MetricKind.Counter)
					{
						BaseUnits baseUnits = array4[i];
						array4[i] = baseUnits.WithSeconds(baseUnits.SecondsExponent - 1);
					}
				}
				MetricIdTypeLibrary.k_TypeDisplayNames.Add(item);
				MetricIdTypeLibrary.k_EnumValues.Add(array);
				MetricIdTypeLibrary.k_EnumNames.Add(enumNames);
				MetricIdTypeLibrary.k_EnumDisplayNames.Add(array2);
				MetricIdTypeLibrary.k_MetricKinds.Add(array3);
				MetricIdTypeLibrary.k_Units.Add(array4);
				MetricIdTypeLibrary.k_DisplayAsPercentage.Add(array5);
			}
		}

		// Token: 0x06000091 RID: 145 RVA: 0x0000313C File Offset: 0x0000133C
		internal static bool IsValidTypeIndex(int index)
		{
			return 0 <= index && index < MetricIdTypeLibrary.k_Types.Count;
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00003151 File Offset: 0x00001351
		internal static int GetTypeIndex(Type type)
		{
			return MetricIdTypeLibrary.k_Types.IndexOf(type);
		}

		// Token: 0x06000093 RID: 147 RVA: 0x0000315E File Offset: 0x0000135E
		internal static Type GetType(int typeIndex)
		{
			return MetricIdTypeLibrary.k_Types[typeIndex];
		}

		// Token: 0x06000094 RID: 148 RVA: 0x0000316B File Offset: 0x0000136B
		internal static bool ContainsType(Type type)
		{
			return MetricIdTypeLibrary.k_Types.Contains(type);
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00003178 File Offset: 0x00001378
		internal static IReadOnlyList<int> GetEnumValues(int typeIndex)
		{
			return MetricIdTypeLibrary.k_EnumValues[typeIndex];
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00003185 File Offset: 0x00001385
		internal static IReadOnlyList<string> GetEnumNames(int typeIndex)
		{
			return MetricIdTypeLibrary.k_EnumNames[typeIndex];
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00003192 File Offset: 0x00001392
		[NotNull]
		internal static string GetEnumName(int typeIndex, int enumValue)
		{
			return MetricIdTypeLibrary.GetEnumMetadata<string>(MetricIdTypeLibrary.k_EnumNames, typeIndex, enumValue) ?? enumValue.ToString();
		}

		// Token: 0x06000098 RID: 152 RVA: 0x000031AB File Offset: 0x000013AB
		internal static MetricKind GetEnumMetricKind(int typeIndex, int enumValue)
		{
			return MetricIdTypeLibrary.GetEnumMetadata<MetricKind>(MetricIdTypeLibrary.k_MetricKinds, typeIndex, enumValue);
		}

		// Token: 0x06000099 RID: 153 RVA: 0x000031B9 File Offset: 0x000013B9
		internal static IReadOnlyList<string> GetEnumDisplayNames(int typeIndex)
		{
			return MetricIdTypeLibrary.k_EnumDisplayNames[typeIndex];
		}

		// Token: 0x0600009A RID: 154 RVA: 0x000031C6 File Offset: 0x000013C6
		[NotNull]
		internal static string GetEnumDisplayName(int typeIndex, int enumValue)
		{
			return MetricIdTypeLibrary.GetEnumMetadata<string>(MetricIdTypeLibrary.k_EnumDisplayNames, typeIndex, enumValue) ?? "";
		}

		// Token: 0x0600009B RID: 155 RVA: 0x000031DD File Offset: 0x000013DD
		internal static BaseUnits GetEnumUnit(int typeIndex, int enumValue)
		{
			return MetricIdTypeLibrary.GetEnumMetadata<BaseUnits>(MetricIdTypeLibrary.k_Units, typeIndex, enumValue);
		}

		// Token: 0x0600009C RID: 156 RVA: 0x000031EB File Offset: 0x000013EB
		internal static bool GetDisplayAsPercentage(int typeIndex, int enumValue)
		{
			return MetricIdTypeLibrary.GetEnumMetadata<bool>(MetricIdTypeLibrary.k_DisplayAsPercentage, typeIndex, enumValue);
		}

		// Token: 0x0600009D RID: 157 RVA: 0x000031FC File Offset: 0x000013FC
		private static T GetEnumMetadata<T>(List<T[]> data, int typeIndex, int enumValue)
		{
			if (typeIndex > MetricIdTypeLibrary.k_EnumValues.Count)
			{
				return default(T);
			}
			int num = Array.IndexOf<int>(MetricIdTypeLibrary.k_EnumValues[typeIndex], enumValue);
			if (num != -1)
			{
				return data[typeIndex][num];
			}
			return default(T);
		}

		// Token: 0x04000039 RID: 57
		private static readonly List<Type> k_Types = new List<Type>();

		// Token: 0x0400003A RID: 58
		private static readonly List<string> k_TypeDisplayNames = new List<string>();

		// Token: 0x0400003B RID: 59
		private static readonly List<int[]> k_EnumValues = new List<int[]>();

		// Token: 0x0400003C RID: 60
		private static readonly List<string[]> k_EnumNames = new List<string[]>();

		// Token: 0x0400003D RID: 61
		private static readonly List<string[]> k_EnumDisplayNames = new List<string[]>();

		// Token: 0x0400003E RID: 62
		private static readonly List<MetricKind[]> k_MetricKinds = new List<MetricKind[]>();

		// Token: 0x0400003F RID: 63
		private static readonly List<BaseUnits[]> k_Units = new List<BaseUnits[]>();

		// Token: 0x04000040 RID: 64
		private static readonly List<bool[]> k_DisplayAsPercentage = new List<bool[]>();
	}
}
