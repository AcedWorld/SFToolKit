using System;
using System.Collections.Generic;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired.Utils
{
	// Token: 0x0200048D RID: 1165
	public static class ArrayTools
	{
		// Token: 0x06002DF7 RID: 11767 RVA: 0x000A0BD8 File Offset: 0x0009EDD8
		public static int[] ConvertToIntArray(Array array)
		{
			if (array == null || array.Length == 0)
			{
				return null;
			}
			int[] array2 = new int[array.Length];
			int num = 0;
			foreach (object value in array)
			{
				array2[num++] = Convert.ToInt32(value);
			}
			return array2;
		}

		// Token: 0x06002DF8 RID: 11768 RVA: 0x000A0C50 File Offset: 0x0009EE50
		public static T[] DeepClone<T>(T[] array) where T : class, IDeepCloneable
		{
			if (array == null)
			{
				return null;
			}
			T[] array2 = new T[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] != null)
				{
					array2[i] = (array[i].DeepClone() as T);
				}
			}
			return array2;
		}

		// Token: 0x06002DF9 RID: 11769 RVA: 0x000A0CAC File Offset: 0x0009EEAC
		public static T[] ShallowCopy<T>(T[] array)
		{
			if (array == null)
			{
				return null;
			}
			T[] array2 = new T[array.Length];
			Array.Copy(array, array2, array.Length);
			return array2;
		}

		// Token: 0x06002DFA RID: 11770 RVA: 0x000A0CD4 File Offset: 0x0009EED4
		public static void ShallowCopy<T>(T[] sourceArray, T[] targetArray)
		{
			if (sourceArray == null)
			{
				return;
			}
			if (targetArray == null)
			{
				return;
			}
			int length = Math.Min(sourceArray.Length, targetArray.Length);
			Array.Copy(sourceArray, targetArray, length);
		}

		// Token: 0x06002DFB RID: 11771 RVA: 0x000A0CD4 File Offset: 0x0009EED4
		public static void ShallowCopy(int[] sourceArray, int[] targetArray)
		{
			if (sourceArray == null)
			{
				return;
			}
			if (targetArray == null)
			{
				return;
			}
			int length = Math.Min(sourceArray.Length, targetArray.Length);
			Array.Copy(sourceArray, targetArray, length);
		}

		// Token: 0x06002DFC RID: 11772 RVA: 0x000A0CD4 File Offset: 0x0009EED4
		public static void ShallowCopy(float[] sourceArray, float[] targetArray)
		{
			if (sourceArray == null)
			{
				return;
			}
			if (targetArray == null)
			{
				return;
			}
			int length = Math.Min(sourceArray.Length, targetArray.Length);
			Array.Copy(sourceArray, targetArray, length);
		}

		// Token: 0x06002DFD RID: 11773 RVA: 0x000A0CD4 File Offset: 0x0009EED4
		public static void ShallowCopy(bool[] sourceArray, bool[] targetArray)
		{
			if (sourceArray == null)
			{
				return;
			}
			if (targetArray == null)
			{
				return;
			}
			int length = Math.Min(sourceArray.Length, targetArray.Length);
			Array.Copy(sourceArray, targetArray, length);
		}

		// Token: 0x06002DFE RID: 11774 RVA: 0x000A0D00 File Offset: 0x0009EF00
		public static byte[] CopyRange(byte[] inArray, int startPos, int length)
		{
			if (inArray == null || length < 1 || startPos < 0)
			{
				return null;
			}
			byte[] array = new byte[length];
			for (int i = 0; i < length; i++)
			{
				array[i] = inArray[startPos + i];
			}
			return array;
		}

		// Token: 0x06002DFF RID: 11775 RVA: 0x000A0D38 File Offset: 0x0009EF38
		public static int[] CopyRange(int[] inArray, int startPos, int length)
		{
			if (inArray == null || length < 1 || startPos < 0)
			{
				return null;
			}
			int[] array = new int[length];
			for (int i = 0; i < length; i++)
			{
				array[i] = inArray[startPos + i];
			}
			return array;
		}

		// Token: 0x06002E00 RID: 11776 RVA: 0x000A0D70 File Offset: 0x0009EF70
		public static float[] CopyRange(float[] inArray, int startPos, int length)
		{
			if (inArray == null || length < 1 || startPos < 0)
			{
				return null;
			}
			float[] array = new float[length];
			for (int i = 0; i < length; i++)
			{
				array[i] = inArray[startPos + i];
			}
			return array;
		}

		// Token: 0x06002E01 RID: 11777 RVA: 0x000A0DA8 File Offset: 0x0009EFA8
		public static string[] CopyRange(string[] inArray, int startPos, int length)
		{
			if (inArray == null || length < 1 || startPos < 0)
			{
				return null;
			}
			string[] array = new string[length];
			for (int i = 0; i < length; i++)
			{
				array[i] = inArray[startPos + i];
			}
			return array;
		}

		// Token: 0x06002E02 RID: 11778 RVA: 0x000A0DE0 File Offset: 0x0009EFE0
		public static byte[] Combine(byte[] inArray1, byte[] inArray2)
		{
			byte[] array = null;
			int num;
			if (inArray1 == null)
			{
				num = 0;
			}
			else
			{
				num = inArray1.Length;
			}
			int num2;
			if (inArray2 == null)
			{
				num2 = 0;
			}
			else
			{
				num2 = inArray2.Length;
			}
			if (num == 0 && num2 == 0)
			{
				return array;
			}
			array = new byte[num + num2];
			int num3 = 0;
			for (int i = 0; i < num; i++)
			{
				array[num3] = inArray1[i];
				num3++;
			}
			for (int j = 0; j < num2; j++)
			{
				array[num3] = inArray2[j];
				num3++;
			}
			return array;
		}

		// Token: 0x06002E03 RID: 11779 RVA: 0x000A0E50 File Offset: 0x0009F050
		public static int[] Combine(int[] inArray1, int[] inArray2)
		{
			int[] array = null;
			int num;
			if (inArray1 == null)
			{
				num = 0;
			}
			else
			{
				num = inArray1.Length;
			}
			int num2;
			if (inArray2 == null)
			{
				num2 = 0;
			}
			else
			{
				num2 = inArray2.Length;
			}
			if (num == 0 && num2 == 0)
			{
				return array;
			}
			array = new int[num + num2];
			int num3 = 0;
			for (int i = 0; i < num; i++)
			{
				array[num3] = inArray1[i];
				num3++;
			}
			for (int j = 0; j < num2; j++)
			{
				array[num3] = inArray2[j];
				num3++;
			}
			return array;
		}

		// Token: 0x06002E04 RID: 11780 RVA: 0x000A0EC0 File Offset: 0x0009F0C0
		public static float[] Combine(float[] inArray1, float[] inArray2)
		{
			float[] array = null;
			int num;
			if (inArray1 == null)
			{
				num = 0;
			}
			else
			{
				num = inArray1.Length;
			}
			int num2;
			if (inArray2 == null)
			{
				num2 = 0;
			}
			else
			{
				num2 = inArray2.Length;
			}
			if (num == 0 && num2 == 0)
			{
				return array;
			}
			array = new float[num + num2];
			int num3 = 0;
			for (int i = 0; i < num; i++)
			{
				array[num3] = inArray1[i];
				num3++;
			}
			for (int j = 0; j < num2; j++)
			{
				array[num3] = inArray2[j];
				num3++;
			}
			return array;
		}

		// Token: 0x06002E05 RID: 11781 RVA: 0x000A0F30 File Offset: 0x0009F130
		public static string[] Combine(string[] inArray1, string[] inArray2)
		{
			string[] array = null;
			int num;
			if (inArray1 == null)
			{
				num = 0;
			}
			else
			{
				num = inArray1.Length;
			}
			int num2;
			if (inArray2 == null)
			{
				num2 = 0;
			}
			else
			{
				num2 = inArray2.Length;
			}
			if (num == 0 && num2 == 0)
			{
				return array;
			}
			array = new string[num + num2];
			int num3 = 0;
			for (int i = 0; i < num; i++)
			{
				array[num3] = inArray1[i];
				num3++;
			}
			for (int j = 0; j < num2; j++)
			{
				array[num3] = inArray2[j];
				num3++;
			}
			return array;
		}

		// Token: 0x06002E06 RID: 11782 RVA: 0x000A0FA0 File Offset: 0x0009F1A0
		public static T[] ParseArray<T>(string line)
		{
			line = line.Replace("{", "");
			line = line.Replace("}", "");
			string[] array = line.Split(',', StringSplitOptions.None);
			int num = array.Length;
			T[] array2 = new T[num];
			if (num == 1)
			{
				string a = array[0].Trim().ToLower();
				if (a == "" || a == "null")
				{
					return null;
				}
			}
			for (int i = 0; i < num; i++)
			{
				string value = array[i].Trim();
				array2[i] = (T)((object)Convert.ChangeType(value, typeof(T)));
			}
			return array2;
		}

		// Token: 0x06002E07 RID: 11783 RVA: 0x000A1050 File Offset: 0x0009F250
		public static T[] SortAscending<T>(T[] array, out int[] sortedIndices) where T : IComparable<T>
		{
			if (array == null)
			{
				sortedIndices = null;
				return null;
			}
			int num = array.Length;
			if (num == 0)
			{
				sortedIndices = new int[0];
				return array;
			}
			if (num == 1)
			{
				sortedIndices = new int[1];
				return array;
			}
			T[] array2 = new T[num];
			sortedIndices = new int[num];
			bool[] array3 = new bool[num];
			for (int i = 0; i < num; i++)
			{
				T t = default(T);
				int num2 = -1;
				for (int j = 0; j < num; j++)
				{
					if (!array3[j])
					{
						T t2 = array[j];
						if (num2 == -1 || t2.CompareTo(t) < 0)
						{
							t = t2;
							num2 = j;
						}
					}
				}
				array2[i] = t;
				sortedIndices[i] = num2;
				array3[num2] = true;
			}
			return array2;
		}

		// Token: 0x06002E08 RID: 11784 RVA: 0x000A1050 File Offset: 0x0009F250
		public static T[] SortDescending<T>(T[] array, out int[] sortedIndices, bool ascending = true) where T : IComparable<T>
		{
			if (array == null)
			{
				sortedIndices = null;
				return null;
			}
			int num = array.Length;
			if (num == 0)
			{
				sortedIndices = new int[0];
				return array;
			}
			if (num == 1)
			{
				sortedIndices = new int[1];
				return array;
			}
			T[] array2 = new T[num];
			sortedIndices = new int[num];
			bool[] array3 = new bool[num];
			for (int i = 0; i < num; i++)
			{
				T t = default(T);
				int num2 = -1;
				for (int j = 0; j < num; j++)
				{
					if (!array3[j])
					{
						T t2 = array[j];
						if (num2 == -1 || t2.CompareTo(t) < 0)
						{
							t = t2;
							num2 = j;
						}
					}
				}
				array2[i] = t;
				sortedIndices[i] = num2;
				array3[num2] = true;
			}
			return array2;
		}

		// Token: 0x06002E09 RID: 11785 RVA: 0x000A1108 File Offset: 0x0009F308
		public static int Add<T>(ref T[] array, T item)
		{
			int num;
			if (array == null)
			{
				num = 0;
			}
			else
			{
				num = array.Length;
			}
			T[] array2 = new T[num + 1];
			int i;
			for (i = 0; i < num; i++)
			{
				array2[i] = array[i];
			}
			array2[i] = item;
			array = array2;
			return i;
		}

		// Token: 0x06002E0A RID: 11786 RVA: 0x0002369B File Offset: 0x0002189B
		public static int AddIfUnique<T>(ref T[] array, T item)
		{
			if (array == null || array.Length == 0 || !ArrayTools.Contains<T>(array, item))
			{
				return ArrayTools.Add<T>(ref array, item);
			}
			return -1;
		}

		// Token: 0x06002E0B RID: 11787 RVA: 0x000A1154 File Offset: 0x0009F354
		public static int Insert<T>(ref T[] array, int index, T item)
		{
			if (index < 0)
			{
				index = 0;
			}
			int num;
			if (array == null)
			{
				num = 0;
			}
			else
			{
				num = array.Length;
			}
			int num2 = num - 1;
			if (index > num2)
			{
				return ArrayTools.Add<T>(ref array, item);
			}
			int num3 = num + 1;
			T[] array2 = new T[num3];
			int i;
			for (i = 0; i < index; i++)
			{
				array2[i] = array[i];
			}
			array2[i] = item;
			int num4 = index;
			for (i++; i < num3; i++)
			{
				array2[i] = array[num4];
				num4++;
			}
			array = array2;
			return index;
		}

		// Token: 0x06002E0C RID: 11788 RVA: 0x000A11EC File Offset: 0x0009F3EC
		public static bool RemoveAt<T>(ref T[] array, int index)
		{
			if (array == null)
			{
				return false;
			}
			if (index < 0)
			{
				index = 0;
			}
			int num = array.Length;
			int num2 = num - 1;
			if (index > num2)
			{
				index = num2;
			}
			T[] array2 = new T[num - 1];
			for (int i = 0; i < index; i++)
			{
				array2[i] = array[i];
			}
			for (int i = index + 1; i < num; i++)
			{
				array2[i - 1] = array[i];
			}
			array = array2;
			return true;
		}

		// Token: 0x06002E0D RID: 11789 RVA: 0x000A1260 File Offset: 0x0009F460
		public static bool Remove<T>(ref T[] array, T item)
		{
			if (array == null)
			{
				return false;
			}
			int num = array.Length;
			for (int i = 0; i < num; i++)
			{
				if (EqualityComparer<T>.Default.Equals(array[i], item))
				{
					ArrayTools.RemoveAt<T>(ref array, i);
					return true;
				}
			}
			return false;
		}

		// Token: 0x06002E0E RID: 11790 RVA: 0x000A12A4 File Offset: 0x0009F4A4
		public static void Combine<T>(ref T[] array1, T[] array2)
		{
			if (array1 == null)
			{
				if (array2 == null)
				{
					return;
				}
				array1 = (T[])array2.Clone();
				return;
			}
			else
			{
				if (array1.Length == 0 && (array2 == null || array2.Length == 0))
				{
					return;
				}
				if (array2 == null || array2.Length == 0)
				{
					return;
				}
				int num = array1.Length;
				int num2 = array2.Length;
				T[] array3 = new T[num + num2];
				int num3 = 0;
				for (int i = 0; i < num; i++)
				{
					array3[num3++] = array1[i];
				}
				for (int j = 0; j < num2; j++)
				{
					array3[num3++] = array2[j];
				}
				array1 = array3;
				return;
			}
		}

		// Token: 0x06002E0F RID: 11791 RVA: 0x000A133C File Offset: 0x0009F53C
		public static T[] Add<T>(T[] array, T item)
		{
			int num;
			if (array == null)
			{
				num = 0;
			}
			else
			{
				num = array.Length;
			}
			T[] array2 = new T[num + 1];
			int i;
			for (i = 0; i < num; i++)
			{
				array2[i] = array[i];
			}
			array2[i] = item;
			return array2;
		}

		// Token: 0x06002E10 RID: 11792 RVA: 0x000236B9 File Offset: 0x000218B9
		public static T[] AddIfUnique<T>(T[] array, T item)
		{
			if (array == null || array.Length == 0 || !ArrayTools.Contains<T>(array, item))
			{
				return ArrayTools.Add<T>(array, item);
			}
			return array;
		}

		// Token: 0x06002E11 RID: 11793 RVA: 0x000A1380 File Offset: 0x0009F580
		public static T[] Insert<T>(T[] array, int index, T item)
		{
			if (index < 0)
			{
				index = 0;
			}
			int num;
			if (array == null)
			{
				num = 0;
			}
			else
			{
				num = array.Length;
			}
			int num2 = num - 1;
			if (index > num2)
			{
				return ArrayTools.Add<T>(array, item);
			}
			int num3 = num + 1;
			T[] array2 = new T[num3];
			int i;
			for (i = 0; i < index; i++)
			{
				array2[i] = array[i];
			}
			array2[i] = item;
			int num4 = index;
			for (i++; i < num3; i++)
			{
				array2[i] = array[num4];
				num4++;
			}
			return array2;
		}

		// Token: 0x06002E12 RID: 11794 RVA: 0x000A1410 File Offset: 0x0009F610
		public static T[] RemoveAt<T>(T[] array, int index)
		{
			if (array == null)
			{
				return null;
			}
			if (index < 0)
			{
				index = 0;
			}
			int num = array.Length;
			int num2 = num - 1;
			if (index > num2)
			{
				index = num2;
			}
			T[] array2 = new T[num - 1];
			for (int i = 0; i < index; i++)
			{
				array2[i] = array[i];
			}
			for (int i = index + 1; i < num; i++)
			{
				array2[i - 1] = array[i];
			}
			return array2;
		}

		// Token: 0x06002E13 RID: 11795 RVA: 0x000A147C File Offset: 0x0009F67C
		public static T[] Remove<T>(T[] array, T item)
		{
			if (array == null)
			{
				return array;
			}
			int num = array.Length;
			for (int i = 0; i < num; i++)
			{
				if (EqualityComparer<T>.Default.Equals(array[i], item))
				{
					return ArrayTools.RemoveAt<T>(array, i);
				}
			}
			return array;
		}

		// Token: 0x06002E14 RID: 11796 RVA: 0x000A14BC File Offset: 0x0009F6BC
		public static T[] Combine<T>(T[] array1, T[] array2)
		{
			if (array1 == null && array2 == null)
			{
				return null;
			}
			int num = (array1 != null) ? array1.Length : 0;
			int num2 = (array2 != null) ? array2.Length : 0;
			T[] array3 = new T[num + num2];
			int num3 = 0;
			for (int i = 0; i < num; i++)
			{
				array3[num3++] = array1[i];
			}
			for (int j = 0; j < num2; j++)
			{
				array3[num3++] = array2[j];
			}
			return array3;
		}

		// Token: 0x06002E15 RID: 11797 RVA: 0x000A1538 File Offset: 0x0009F738
		public static int IndexOf<T>(T[] array, T item)
		{
			if (array == null)
			{
				return -1;
			}
			int num = array.Length;
			for (int i = 0; i < num; i++)
			{
				if (EqualityComparer<T>.Default.Equals(array[i], item))
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06002E16 RID: 11798 RVA: 0x000A1574 File Offset: 0x0009F774
		public static bool Contains<T>(T[] array, T item)
		{
			if (array == null)
			{
				return false;
			}
			int num = array.Length;
			for (int i = 0; i < num; i++)
			{
				if (EqualityComparer<T>.Default.Equals(array[i], item))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06002E17 RID: 11799 RVA: 0x000A15B0 File Offset: 0x0009F7B0
		public static T Find<T>(T[] array, Predicate<T> predicate)
		{
			if (predicate == null)
			{
				throw new ArgumentNullException("predicate");
			}
			if (array == null)
			{
				return default(T);
			}
			int num = array.Length;
			for (int i = 0; i < num; i++)
			{
				if (predicate(array[i]))
				{
					return array[i];
				}
			}
			return default(T);
		}

		// Token: 0x06002E18 RID: 11800 RVA: 0x000A1608 File Offset: 0x0009F808
		public static bool SubArray<T>(ref T[] array, int startIndex)
		{
			if (array == null)
			{
				return false;
			}
			if (array.Length == 0)
			{
				return false;
			}
			if (startIndex < 0)
			{
				startIndex = 0;
			}
			int num = array.Length;
			int num2 = num - 1;
			if (startIndex >= num2)
			{
				return false;
			}
			T[] array2 = new T[num - startIndex];
			int num3 = 0;
			for (int i = startIndex; i < num; i++)
			{
				array2[num3++] = array[i];
			}
			array = array2;
			return true;
		}

		// Token: 0x06002E19 RID: 11801 RVA: 0x000A166C File Offset: 0x0009F86C
		public static bool SubArray<T>(ref T[] array, int startIndex, int count)
		{
			if (array == null)
			{
				return false;
			}
			if (array.Length == 0)
			{
				return false;
			}
			if (count <= 0)
			{
				return false;
			}
			if (startIndex < 0)
			{
				startIndex = 0;
			}
			int num = array.Length;
			if (startIndex >= num - 1)
			{
				return false;
			}
			if (count > num - startIndex)
			{
				count = num - startIndex;
			}
			T[] array2 = new T[count];
			int num2 = startIndex + count - 1;
			int num3 = 0;
			for (int i = startIndex; i <= num2; i++)
			{
				array2[num3++] = array[i];
			}
			array = array2;
			return true;
		}

		// Token: 0x06002E1A RID: 11802 RVA: 0x000A16E4 File Offset: 0x0009F8E4
		public static void Expand<T>(ref T[] array, int length)
		{
			if (length <= 0)
			{
				return;
			}
			int num;
			if (array == null)
			{
				num = 0;
			}
			else
			{
				num = array.Length;
			}
			T[] array2 = new T[num + length];
			if (num > 0)
			{
				Array.Copy(array, array2, num);
			}
			array = array2;
		}

		// Token: 0x06002E1B RID: 11803 RVA: 0x000A171C File Offset: 0x0009F91C
		public static void Trim(string[] array)
		{
			if (array == null)
			{
				return;
			}
			int num = array.Length;
			if (num == 0)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				array[i].Trim();
			}
		}

		// Token: 0x06002E1C RID: 11804 RVA: 0x000A174C File Offset: 0x0009F94C
		public static RaycastHit[] SortNearToFar(RaycastHit[] hits)
		{
			int num = hits.Length;
			if (hits == null || num == 0)
			{
				return null;
			}
			float[] array = new float[num];
			int[] array2 = new int[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = hits[i].distance;
			}
			for (int j = 0; j < num; j++)
			{
				bool flag = true;
				float num2 = -1f;
				int num3 = -1;
				for (int k = 0; k < num; k++)
				{
					float num4 = array[k];
					if (num4 >= 0f && (flag || num4 < num2))
					{
						if (flag)
						{
							flag = false;
						}
						num2 = num4;
						num3 = k;
					}
				}
				array2[j] = num3;
				array[num3] = -1f;
			}
			RaycastHit[] array3 = new RaycastHit[num];
			for (int l = 0; l < num; l++)
			{
				array3[l] = hits[array2[l]];
			}
			return array3;
		}

		// Token: 0x06002E1D RID: 11805 RVA: 0x000A1824 File Offset: 0x0009FA24
		public static void MoveEntryUp<T>(T[] array, int index)
		{
			if (array == null)
			{
				return;
			}
			int num = array.Length;
			if (num <= 1)
			{
				return;
			}
			if (index <= 0 || index >= num)
			{
				return;
			}
			int num2 = index - 1;
			T t = array[num2];
			array[num2] = array[index];
			array[index] = t;
		}

		// Token: 0x06002E1E RID: 11806 RVA: 0x000A186C File Offset: 0x0009FA6C
		public static void MoveEntryDown<T>(T[] array, int index)
		{
			if (array == null)
			{
				return;
			}
			int num = array.Length;
			if (num <= 1)
			{
				return;
			}
			if (index < 0 || index >= num - 1)
			{
				return;
			}
			int num2 = index + 1;
			T t = array[num2];
			array[num2] = array[index];
			array[index] = t;
		}

		// Token: 0x06002E1F RID: 11807 RVA: 0x000A18B4 File Offset: 0x0009FAB4
		public static void Compact<T>(ref T[] array) where T : class
		{
			int num = (array != null) ? array.Length : 0;
			if (num == 0)
			{
				return;
			}
			T[] array2 = null;
			for (int i = 0; i < num; i++)
			{
				if (array[i] != null)
				{
					ArrayTools.Add<T>(ref array2, array[i]);
				}
			}
			array = array2;
		}

		// Token: 0x06002E20 RID: 11808 RVA: 0x000A1904 File Offset: 0x0009FB04
		public static int IndexOf(int[] array, int value)
		{
			if (array == null)
			{
				return -1;
			}
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == value)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06002E21 RID: 11809 RVA: 0x000A1930 File Offset: 0x0009FB30
		public static int IndexOf(float[] array, float value)
		{
			if (array == null)
			{
				return -1;
			}
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == value)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06002E22 RID: 11810 RVA: 0x000A195C File Offset: 0x0009FB5C
		public static int IndexOf(short[] array, short value)
		{
			if (array == null)
			{
				return -1;
			}
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == value)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06002E23 RID: 11811 RVA: 0x000A1988 File Offset: 0x0009FB88
		public static int IndexOf(ushort[] array, ushort value)
		{
			if (array == null)
			{
				return -1;
			}
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == value)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06002E24 RID: 11812 RVA: 0x000A19B4 File Offset: 0x0009FBB4
		public static int IndexOf(uint[] array, uint value)
		{
			if (array == null)
			{
				return -1;
			}
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == value)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06002E25 RID: 11813 RVA: 0x000A19E0 File Offset: 0x0009FBE0
		public static int IndexOf(double[] array, double value)
		{
			if (array == null)
			{
				return -1;
			}
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == value)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06002E26 RID: 11814 RVA: 0x000A1A0C File Offset: 0x0009FC0C
		public static int IndexOf(bool[] array, bool value)
		{
			if (array == null)
			{
				return -1;
			}
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == value)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06002E27 RID: 11815 RVA: 0x000A1A38 File Offset: 0x0009FC38
		public static int IndexOf(string[] array, string value)
		{
			if (array == null)
			{
				return -1;
			}
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == value)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06002E28 RID: 11816 RVA: 0x000A1A68 File Offset: 0x0009FC68
		public static int IndexOf(string[] array, string value, StringComparison stringComparison)
		{
			if (array == null)
			{
				return -1;
			}
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].Equals(value, stringComparison))
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06002E29 RID: 11817 RVA: 0x000A1A98 File Offset: 0x0009FC98
		public static void Fill<T>(T[] array, T value)
		{
			if (array == null)
			{
				return;
			}
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = value;
			}
		}

		// Token: 0x06002E2A RID: 11818 RVA: 0x000A1AC0 File Offset: 0x0009FCC0
		public static void Fill<T>(T[] array, T value, int startIndex)
		{
			if (array == null)
			{
				return;
			}
			if (startIndex < 0 || startIndex >= array.Length)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			for (int i = startIndex; i < array.Length; i++)
			{
				array[i] = value;
			}
		}

		// Token: 0x06002E2B RID: 11819 RVA: 0x000A1AFC File Offset: 0x0009FCFC
		public static void Fill<T>(T[] array, T value, int startIndex, int length)
		{
			if (array == null)
			{
				return;
			}
			if (startIndex < 0 || startIndex >= array.Length)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			length = MathTools.Clamp(startIndex + length, 0, array.Length);
			for (int i = startIndex; i < array.Length; i++)
			{
				array[i] = value;
			}
		}

		// Token: 0x06002E2C RID: 11820 RVA: 0x000A1B48 File Offset: 0x0009FD48
		public static void Populate<T>(T[] array, int startIndex, int length, Func<T> instantiator)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (length <= 0)
			{
				return;
			}
			if (startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex must be >= 0");
			}
			if (startIndex >= length)
			{
				throw new ArgumentOutOfRangeException("startIndex must be < length");
			}
			if (length > array.Length)
			{
				throw new ArgumentOutOfRangeException("length must be <= array.Length");
			}
			if (startIndex + length > array.Length)
			{
				throw new ArgumentOutOfRangeException("startIndex + length must be <= array.Length");
			}
			for (int i = startIndex; i < startIndex + length; i++)
			{
				array[i] = instantiator();
			}
		}

		// Token: 0x06002E2D RID: 11821 RVA: 0x000A1BC8 File Offset: 0x0009FDC8
		public static void Populate<T>(T[] array, int startIndex, int length) where T : class, new()
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (length <= 0)
			{
				return;
			}
			if (startIndex < 0)
			{
				throw new ArgumentOutOfRangeException("startIndex must be >= 0");
			}
			if (startIndex >= length)
			{
				throw new ArgumentOutOfRangeException("startIndex must be < length");
			}
			if (length > array.Length)
			{
				throw new ArgumentOutOfRangeException("length must be <= array.Length");
			}
			if (startIndex + length > array.Length)
			{
				throw new ArgumentOutOfRangeException("startIndex + length must be <= array.Length");
			}
			for (int i = startIndex; i < startIndex + length; i++)
			{
				array[i] = Activator.CreateInstance<T>();
			}
		}

		// Token: 0x06002E2E RID: 11822 RVA: 0x000236D4 File Offset: 0x000218D4
		public static void Populate<T>(T[] array) where T : class, new()
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			ArrayTools.Populate<T>(array, 0, array.Length);
		}

		// Token: 0x06002E2F RID: 11823 RVA: 0x000236EE File Offset: 0x000218EE
		public static void Populate<T>(T[] array, Func<T> instantiator)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			ArrayTools.Populate<T>(array, 0, array.Length, instantiator);
		}

		// Token: 0x06002E30 RID: 11824 RVA: 0x000A1C44 File Offset: 0x0009FE44
		public static int Count<T>(T[] array, Predicate<T> predicate)
		{
			if (predicate == null)
			{
				throw new ArgumentNullException("predicate");
			}
			if (array == null)
			{
				return 0;
			}
			int num = 0;
			for (int i = 0; i < array.Length; i++)
			{
				if (predicate(array[i]))
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x06002E31 RID: 11825 RVA: 0x000A1C88 File Offset: 0x0009FE88
		public static bool IsEqual(byte[] a1, byte[] a2)
		{
			if (a1 == a2)
			{
				return true;
			}
			if (a1.Length != a2.Length)
			{
				return false;
			}
			for (int i = 0; i < a1.Length; i++)
			{
				if (a1[i] != a2[i])
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06002E32 RID: 11826 RVA: 0x000A1CC0 File Offset: 0x0009FEC0
		public static bool Contains(string[] array, string item, bool ignoreCase)
		{
			if (array == null)
			{
				return false;
			}
			int num = array.Length;
			for (int i = 0; i < num; i++)
			{
				if (ignoreCase)
				{
					if (array[i].Equals(item, StringComparison.OrdinalIgnoreCase))
					{
						return true;
					}
				}
				else if (array[i] == item)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06002E33 RID: 11827 RVA: 0x00023709 File Offset: 0x00021909
		public static int AddIfUnique(ref string[] array, string item, bool ignoreCase)
		{
			if (array == null || array.Length == 0 || !ArrayTools.Contains(array, item, ignoreCase))
			{
				return ArrayTools.Add<string>(ref array, item);
			}
			return -1;
		}

		// Token: 0x06002E34 RID: 11828 RVA: 0x000A1D04 File Offset: 0x0009FF04
		public static void RemoveDuplicates(ref string[] array, bool ignoreCase)
		{
			int num = (array != null) ? array.Length : 0;
			if (num == 0)
			{
				return;
			}
			string[] array2 = null;
			for (int i = 0; i < num; i++)
			{
				ArrayTools.AddIfUnique(ref array2, array[i], ignoreCase);
			}
			array = array2;
		}

		// Token: 0x06002E35 RID: 11829 RVA: 0x000A1D40 File Offset: 0x0009FF40
		public static bool Remove(ref string[] array, string item, bool ignoreCase)
		{
			if (array == null)
			{
				return false;
			}
			int num = array.Length;
			if (item == null)
			{
				for (int i = 0; i < num; i++)
				{
					if (array[i] == null)
					{
						ArrayTools.RemoveAt<string>(ref array, i);
						return true;
					}
				}
			}
			else
			{
				for (int j = 0; j < num; j++)
				{
					if (ignoreCase)
					{
						if (array[j] != null && array[j].Equals(item, StringComparison.OrdinalIgnoreCase))
						{
							ArrayTools.RemoveAt<string>(ref array, j);
							return true;
						}
					}
					else if (array[j] == item)
					{
						ArrayTools.RemoveAt<string>(ref array, j);
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06002E36 RID: 11830 RVA: 0x000A1DBC File Offset: 0x0009FFBC
		public static string[] ToLowerStripSpaces(string[] array)
		{
			if (array == null)
			{
				return null;
			}
			if (array.Length == 0)
			{
				return null;
			}
			string[] array2 = new string[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] != null)
				{
					array2[i] = array[i].ToLower().Replace(" ", "");
				}
			}
			return array2;
		}

		// Token: 0x06002E37 RID: 11831 RVA: 0x000A1E0C File Offset: 0x000A000C
		public static int ToBitmask(bool[] array, int startIndex, int count = 32)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (startIndex < 0 || startIndex >= array.Length)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}
			if (count <= 0 || startIndex + count > array.Length + 1)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if (count > 32)
			{
				throw new ArgumentOutOfRangeException("count must be <= 32");
			}
			int num = 0;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i])
				{
					num |= 1 << i;
				}
			}
			return num;
		}

		// Token: 0x06002E38 RID: 11832 RVA: 0x000A1E84 File Offset: 0x000A0084
		public static bool IsNullOrEmpty<T>(T[] array)
		{
			if (array == null)
			{
				return true;
			}
			if (array.Length == 0)
			{
				return true;
			}
			if (!typeof(T).IsClass)
			{
				return false;
			}
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] != null)
				{
					return false;
				}
			}
			return true;
		}
	}
}
