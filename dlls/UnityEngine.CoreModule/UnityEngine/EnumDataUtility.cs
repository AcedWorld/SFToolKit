using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace UnityEngine
{
	// Token: 0x02000241 RID: 577
	internal static class EnumDataUtility
	{
		// Token: 0x060018AF RID: 6319 RVA: 0x00028FCC File Offset: 0x000271CC
		public static EnumData GetCachedEnumData(Type enumType, EnumDataUtility.CachedType cachedType = EnumDataUtility.CachedType.IncludeObsoleteExceptErrors, Func<string, string> nicifyName = null)
		{
			EnumData enumData;
			bool flag = EnumDataUtility.s_EnumData.TryGetValue(new ValueTuple<EnumDataUtility.CachedType, Type>(cachedType, enumType), out enumData);
			EnumData result;
			if (flag)
			{
				result = enumData;
			}
			else
			{
				enumData = new EnumData
				{
					underlyingType = Enum.GetUnderlyingType(enumType)
				};
				enumData.unsigned = (enumData.underlyingType == typeof(byte) || enumData.underlyingType == typeof(ushort) || enumData.underlyingType == typeof(uint) || enumData.underlyingType == typeof(ulong));
				FieldInfo[] fields = enumType.GetFields(BindingFlags.Static | BindingFlags.Public);
				List<FieldInfo> list = new List<FieldInfo>();
				int num = fields.Length;
				for (int i = 0; i < num; i++)
				{
					bool flag2 = EnumDataUtility.CheckObsoleteAddition(fields[i], cachedType);
					if (flag2)
					{
						list.Add(fields[i]);
					}
				}
				bool flag3 = !list.Any<FieldInfo>();
				if (flag3)
				{
					string[] array = new string[]
					{
						""
					};
					Enum[] values = new Enum[0];
					int[] flagValues = new int[1];
					enumData.values = values;
					enumData.flagValues = flagValues;
					enumData.displayNames = array;
					enumData.names = array;
					enumData.tooltip = array;
					enumData.flags = true;
					enumData.serializable = true;
					result = enumData;
				}
				else
				{
					try
					{
						string location = list.First<FieldInfo>().Module.Assembly.Location;
						bool flag4 = !string.IsNullOrEmpty(location);
						if (flag4)
						{
							list = (from f in list
							orderby f.MetadataToken
							select f).ToList<FieldInfo>();
						}
					}
					catch
					{
					}
					enumData.displayNames = (from f in list
					select EnumDataUtility.EnumNameFromEnumField(f, nicifyName)).ToArray<string>();
					bool flag5 = enumData.displayNames.Distinct<string>().Count<string>() != enumData.displayNames.Length;
					if (flag5)
					{
						Debug.LogWarning("Enum " + enumType.Name + " has multiple entries with the same display name, this prevents selection in EnumPopup.");
					}
					enumData.tooltip = (from f in list
					select EnumDataUtility.EnumTooltipFromEnumField(f)).ToArray<string>();
					enumData.values = (from f in list
					select (Enum)f.GetValue(null)).ToArray<Enum>();
					int[] flagValues2;
					if (!enumData.unsigned)
					{
						flagValues2 = (from v in enumData.values
						select (int)Convert.ToInt64(v)).ToArray<int>();
					}
					else
					{
						flagValues2 = (from v in enumData.values
						select (int)Convert.ToUInt64(v)).ToArray<int>();
					}
					enumData.flagValues = flagValues2;
					enumData.names = new string[enumData.values.Length];
					for (int j = 0; j < list.Count; j++)
					{
						enumData.names[j] = list[j].Name;
					}
					bool flag6 = enumData.underlyingType == typeof(ushort);
					if (flag6)
					{
						int k = 0;
						int num2 = enumData.flagValues.Length;
						while (k < num2)
						{
							bool flag7 = (long)enumData.flagValues[k] == 65535L;
							if (flag7)
							{
								enumData.flagValues[k] = -1;
							}
							k++;
						}
					}
					else
					{
						bool flag8 = enumData.underlyingType == typeof(byte);
						if (flag8)
						{
							int l = 0;
							int num3 = enumData.flagValues.Length;
							while (l < num3)
							{
								bool flag9 = (long)enumData.flagValues[l] == 255L;
								if (flag9)
								{
									enumData.flagValues[l] = -1;
								}
								l++;
							}
						}
					}
					enumData.flags = enumType.IsDefined(typeof(FlagsAttribute), false);
					enumData.serializable = (enumData.underlyingType != typeof(long) && enumData.underlyingType != typeof(ulong));
					EnumDataUtility.HandleInspectorOrderAttribute(enumType, ref enumData);
					EnumDataUtility.s_EnumData[new ValueTuple<EnumDataUtility.CachedType, Type>(cachedType, enumType)] = enumData;
					result = enumData;
				}
			}
			return result;
		}

		// Token: 0x060018B0 RID: 6320 RVA: 0x00029460 File Offset: 0x00027660
		internal static int EnumFlagsToInt(EnumData enumData, Enum enumValue)
		{
			bool unsigned = enumData.unsigned;
			int result;
			if (unsigned)
			{
				bool flag = enumData.underlyingType == typeof(uint);
				if (flag)
				{
					result = (int)Convert.ToUInt32(enumValue);
				}
				else
				{
					bool flag2 = enumData.underlyingType == typeof(ushort);
					if (flag2)
					{
						ushort num = Convert.ToUInt16(enumValue);
						result = ((num == ushort.MaxValue) ? -1 : ((int)num));
					}
					else
					{
						byte b = Convert.ToByte(enumValue);
						result = ((b == byte.MaxValue) ? -1 : ((int)b));
					}
				}
			}
			else
			{
				result = Convert.ToInt32(enumValue);
			}
			return result;
		}

		// Token: 0x060018B1 RID: 6321 RVA: 0x000294F4 File Offset: 0x000276F4
		internal static Enum IntToEnumFlags(Type enumType, int value)
		{
			EnumData cachedEnumData = EnumDataUtility.GetCachedEnumData(enumType, EnumDataUtility.CachedType.IncludeObsoleteExceptErrors, null);
			bool unsigned = cachedEnumData.unsigned;
			Enum result;
			if (unsigned)
			{
				bool flag = cachedEnumData.underlyingType == typeof(uint);
				if (flag)
				{
					uint num = (uint)value;
					result = (Enum.Parse(enumType, num.ToString()) as Enum);
				}
				else
				{
					bool flag2 = cachedEnumData.underlyingType == typeof(ushort);
					if (flag2)
					{
						result = (Enum.Parse(enumType, ((ushort)value).ToString()) as Enum);
					}
					else
					{
						result = (Enum.Parse(enumType, ((byte)value).ToString()) as Enum);
					}
				}
			}
			else
			{
				result = (Enum.Parse(enumType, value.ToString()) as Enum);
			}
			return result;
		}

		// Token: 0x060018B2 RID: 6322 RVA: 0x000295B4 File Offset: 0x000277B4
		internal static void HandleInspectorOrderAttribute(Type enumType, ref EnumData enumData)
		{
			InspectorOrderAttribute inspectorOrderAttribute = Attribute.GetCustomAttribute(enumType, typeof(InspectorOrderAttribute)) as InspectorOrderAttribute;
			bool flag = inspectorOrderAttribute == null;
			if (!flag)
			{
				int num = enumData.displayNames.Length;
				int[] array = new int[num];
				for (int i = 0; i < num; i++)
				{
					array[i] = i;
				}
				InspectorSort inspectorSort = inspectorOrderAttribute.m_inspectorSort;
				InspectorSort inspectorSort2 = inspectorSort;
				if (inspectorSort2 != InspectorSort.ByValue)
				{
					string[] array2 = new string[num];
					Array.Copy(enumData.displayNames, array2, num);
					Array.Sort<string, int>(array2, array, StringComparer.Ordinal);
				}
				else
				{
					int[] array3 = new int[num];
					Array.Copy(enumData.flagValues, array3, num);
					Array.Sort<int, int>(array3, array);
				}
				bool flag2 = inspectorOrderAttribute.m_sortDirection == InspectorSortDirection.Descending;
				if (flag2)
				{
					Array.Reverse<int>(array);
				}
				Enum[] array4 = new Enum[num];
				int[] array5 = new int[num];
				string[] array6 = new string[num];
				string[] array7 = new string[num];
				string[] array8 = new string[num];
				for (int j = 0; j < num; j++)
				{
					int num2 = array[j];
					array4[j] = enumData.values[num2];
					array5[j] = enumData.flagValues[num2];
					array6[j] = enumData.displayNames[num2];
					array7[j] = enumData.names[num2];
					array8[j] = enumData.tooltip[num2];
				}
				enumData.values = array4;
				enumData.flagValues = array5;
				enumData.displayNames = array6;
				enumData.names = array7;
				enumData.tooltip = array8;
			}
		}

		// Token: 0x060018B3 RID: 6323 RVA: 0x00029738 File Offset: 0x00027938
		private static bool CheckObsoleteAddition(FieldInfo field, EnumDataUtility.CachedType cachedType)
		{
			object[] customAttributes = field.GetCustomAttributes(typeof(ObsoleteAttribute), false);
			bool flag = customAttributes.Length != 0;
			bool result;
			if (flag)
			{
				bool flag2 = cachedType == EnumDataUtility.CachedType.ExcludeObsolete;
				if (flag2)
				{
					result = false;
				}
				else
				{
					bool flag3 = cachedType == EnumDataUtility.CachedType.IncludeAllObsolete;
					result = (flag3 || !((ObsoleteAttribute)customAttributes.First<object>()).IsError);
				}
			}
			else
			{
				result = true;
			}
			return result;
		}

		// Token: 0x060018B4 RID: 6324 RVA: 0x00029798 File Offset: 0x00027998
		private static string EnumTooltipFromEnumField(FieldInfo field)
		{
			object[] customAttributes = field.GetCustomAttributes(typeof(TooltipAttribute), false);
			bool flag = customAttributes.Length != 0;
			string result;
			if (flag)
			{
				result = ((TooltipAttribute)customAttributes.First<object>()).tooltip;
			}
			else
			{
				result = string.Empty;
			}
			return result;
		}

		// Token: 0x060018B5 RID: 6325 RVA: 0x000297E0 File Offset: 0x000279E0
		private static string EnumNameFromEnumField(FieldInfo field, Func<string, string> nicifyName)
		{
			EnumDataUtility.<>c__DisplayClass8_0 CS$<>8__locals1;
			CS$<>8__locals1.nicifyName = nicifyName;
			CS$<>8__locals1.field = field;
			object[] customAttributes = CS$<>8__locals1.field.GetCustomAttributes(typeof(InspectorNameAttribute), false);
			bool flag = customAttributes.Length != 0;
			string result;
			if (flag)
			{
				result = ((InspectorNameAttribute)customAttributes.First<object>()).displayName;
			}
			else
			{
				bool flag2 = CS$<>8__locals1.field.IsDefined(typeof(ObsoleteAttribute), false);
				if (flag2)
				{
					result = EnumDataUtility.<EnumNameFromEnumField>g__NicifyName|8_0(ref CS$<>8__locals1) + " (Obsolete)";
				}
				else
				{
					result = EnumDataUtility.<EnumNameFromEnumField>g__NicifyName|8_0(ref CS$<>8__locals1);
				}
			}
			return result;
		}

		// Token: 0x060018B7 RID: 6327 RVA: 0x0002987C File Offset: 0x00027A7C
		[CompilerGenerated]
		internal static string <EnumNameFromEnumField>g__NicifyName|8_0(ref EnumDataUtility.<>c__DisplayClass8_0 A_0)
		{
			return (A_0.nicifyName == null) ? A_0.field.Name : A_0.nicifyName(A_0.field.Name);
		}

		// Token: 0x040008B0 RID: 2224
		private static readonly Dictionary<ValueTuple<EnumDataUtility.CachedType, Type>, EnumData> s_EnumData = new Dictionary<ValueTuple<EnumDataUtility.CachedType, Type>, EnumData>();

		// Token: 0x02000242 RID: 578
		public enum CachedType
		{
			// Token: 0x040008B2 RID: 2226
			ExcludeObsolete,
			// Token: 0x040008B3 RID: 2227
			IncludeObsoleteExceptErrors,
			// Token: 0x040008B4 RID: 2228
			IncludeAllObsolete
		}
	}
}
