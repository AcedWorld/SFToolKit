using System;
using System.Collections.Generic;

namespace Rewired.Utils
{
	// Token: 0x02000493 RID: 1171
	public static class ListTools
	{
		// Token: 0x06002E64 RID: 11876 RVA: 0x000A291C File Offset: 0x000A0B1C
		public static bool OffsetAtIndex<T>(IList<T> list, int index, bool offsetDown, bool offsetNow = true)
		{
			if (list == null)
			{
				return false;
			}
			int count = list.Count;
			if (index < 0 || index >= count)
			{
				return false;
			}
			if (index == count - 1 && offsetDown)
			{
				return false;
			}
			if (index == 0 && !offsetDown)
			{
				return false;
			}
			if (!offsetNow)
			{
				return true;
			}
			T item = list[index];
			list.RemoveAt(index);
			int num = offsetDown ? 1 : -1;
			if (offsetDown && index + num >= count)
			{
				list.Add(item);
				return true;
			}
			list.Insert(index + num, item);
			return true;
		}

		// Token: 0x06002E65 RID: 11877 RVA: 0x000A298C File Offset: 0x000A0B8C
		public static List<T> ShallowCopy<T>(List<T> list)
		{
			if (list == null)
			{
				return null;
			}
			int count = list.Count;
			List<T> list2 = new List<T>(count);
			for (int i = 0; i < count; i++)
			{
				list2.Add(list[i]);
			}
			return list2;
		}

		// Token: 0x06002E66 RID: 11878 RVA: 0x000238B5 File Offset: 0x00021AB5
		public static bool CopyTo<T>(IList<T> fromList, IList<T> toList)
		{
			return ListTools.CopyTo<T>(fromList, toList, 0, -1);
		}

		// Token: 0x06002E67 RID: 11879 RVA: 0x000238C0 File Offset: 0x00021AC0
		public static bool CopyTo<T>(IList<T> fromList, IList<T> toList, int fromListStartIndex)
		{
			return ListTools.CopyTo<T>(fromList, toList, fromListStartIndex, -1);
		}

		// Token: 0x06002E68 RID: 11880 RVA: 0x000A29C8 File Offset: 0x000A0BC8
		public static bool CopyTo<T>(IList<T> fromList, IList<T> toList, int fromListStartIndex, int count)
		{
			if (fromList == null || toList == null)
			{
				return false;
			}
			int count2 = fromList.Count;
			if (fromListStartIndex < 0)
			{
				fromListStartIndex = 0;
			}
			if (fromListStartIndex >= count2)
			{
				return false;
			}
			if (count <= 0)
			{
				count = count2 - fromListStartIndex;
			}
			for (int i = fromListStartIndex; i < count; i++)
			{
				toList.Add(fromList[i]);
			}
			return true;
		}

		// Token: 0x06002E69 RID: 11881 RVA: 0x000A2A14 File Offset: 0x000A0C14
		public static T[] ToArray<T>(IList<T> list)
		{
			if (list == null)
			{
				return null;
			}
			int count = list.Count;
			T[] array = new T[count];
			for (int i = 0; i < count; i++)
			{
				array[i] = list[i];
			}
			return array;
		}

		// Token: 0x06002E6A RID: 11882 RVA: 0x000A2A50 File Offset: 0x000A0C50
		public static List<T> Combine<T>(IList<T> list1, IList<T> list2)
		{
			int num = (list1 != null) ? list1.Count : 0;
			int num2 = (list2 != null) ? list2.Count : 0;
			List<T> list3 = new List<T>(num + num2);
			for (int i = 0; i < num; i++)
			{
				list3.Add(list1[i]);
			}
			for (int j = 0; j < num2; j++)
			{
				list3.Add(list2[j]);
			}
			return list3;
		}

		// Token: 0x06002E6B RID: 11883 RVA: 0x000A2AB8 File Offset: 0x000A0CB8
		public static bool IsNullOrEmpty<T>(IList<T> list)
		{
			if (list == null)
			{
				return true;
			}
			int count = list.Count;
			if (count == 0)
			{
				return true;
			}
			if (!typeof(T).IsClass)
			{
				return false;
			}
			for (int i = 0; i < count; i++)
			{
				if (list[i] != null)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06002E6C RID: 11884 RVA: 0x000A2B08 File Offset: 0x000A0D08
		public static List<object> ConvertToObjeclist<T>(IList<T> list)
		{
			List<object> list2 = new List<object>(list.Count);
			for (int i = 0; i < list.Count; i++)
			{
				list2.Add(list[i]);
			}
			return list2;
		}

		// Token: 0x06002E6D RID: 11885 RVA: 0x000A2B48 File Offset: 0x000A0D48
		public static void Concat<T>(IList<T> list1, IList<T> list2)
		{
			if (list1 == null || list2 == null)
			{
				return;
			}
			for (int i = 0; i < list2.Count; i++)
			{
				list1.Add(list2[i]);
			}
		}

		// Token: 0x06002E6E RID: 11886 RVA: 0x000238CB File Offset: 0x00021ACB
		public static bool AddIfUnique<T>(IList<T> list, T item)
		{
			if (list == null)
			{
				return false;
			}
			if (list.Contains(item))
			{
				return false;
			}
			list.Add(item);
			return true;
		}

		// Token: 0x06002E6F RID: 11887 RVA: 0x000A2B7C File Offset: 0x000A0D7C
		public static int Count<T>(IList<T> list, Predicate<T> predicate)
		{
			if (list == null)
			{
				return 0;
			}
			int count = list.Count;
			int num = 0;
			for (int i = 0; i < count; i++)
			{
				if (predicate(list[i]))
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x06002E70 RID: 11888 RVA: 0x000238E5 File Offset: 0x00021AE5
		public static void TryClear<T>(IList<T> list)
		{
			if (list == null)
			{
				return;
			}
			list.Clear();
		}

		// Token: 0x06002E71 RID: 11889 RVA: 0x000238F1 File Offset: 0x00021AF1
		private static bool JqvCEmqKnjnxqhSAobjoFmkgnPGk<\u0001>(IList<\u0001> A_0, \u0001 A_1)
		{
			if (A_0 == null)
			{
				return false;
			}
			A_0.Add(A_1);
			return true;
		}

		// Token: 0x06002E72 RID: 11890 RVA: 0x00023900 File Offset: 0x00021B00
		public static int AddAndCreateList<T>(ref IList<T> list, T item)
		{
			if (list == null)
			{
				list = new List<T>();
			}
			list.Add(item);
			return list.Count - 1;
		}

		// Token: 0x06002E73 RID: 11891 RVA: 0x000A2BB8 File Offset: 0x000A0DB8
		public static T Find<T>(IList<T> list, Predicate<T> predicate)
		{
			if (list == null || predicate == null)
			{
				return default(T);
			}
			int count = list.Count;
			for (int i = 0; i < count; i++)
			{
				if (predicate(list[i]))
				{
					return list[i];
				}
			}
			return default(T);
		}

		// Token: 0x06002E74 RID: 11892 RVA: 0x000A2C08 File Offset: 0x000A0E08
		public static int FindIndex<T>(IList<T> list, Predicate<T> predicate)
		{
			if (list == null || predicate == null)
			{
				return -1;
			}
			int count = list.Count;
			for (int i = 0; i < count; i++)
			{
				if (predicate(list[i]))
				{
					return i;
				}
			}
			return -1;
		}
	}
}
