using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000156 RID: 342
	public static class HashUtility
	{
		// Token: 0x06000922 RID: 2338 RVA: 0x00027BAE File Offset: 0x00025DAE
		public static int GetHashCode<T>(T a)
		{
			if (a == null)
			{
				return 0;
			}
			return a.GetHashCode();
		}

		// Token: 0x06000923 RID: 2339 RVA: 0x00027BC7 File Offset: 0x00025DC7
		public static int GetHashCode<T1, T2>(T1 a, T2 b)
		{
			return (17 * 23 + ((a != null) ? a.GetHashCode() : 0)) * 23 + ((b != null) ? b.GetHashCode() : 0);
		}

		// Token: 0x06000924 RID: 2340 RVA: 0x00027C04 File Offset: 0x00025E04
		public static int GetHashCode<T1, T2, T3>(T1 a, T2 b, T3 c)
		{
			return ((17 * 23 + ((a != null) ? a.GetHashCode() : 0)) * 23 + ((b != null) ? b.GetHashCode() : 0)) * 23 + ((c != null) ? c.GetHashCode() : 0);
		}

		// Token: 0x06000925 RID: 2341 RVA: 0x00027C68 File Offset: 0x00025E68
		public static int GetHashCode<T1, T2, T3, T4>(T1 a, T2 b, T3 c, T4 d)
		{
			return (((17 * 23 + ((a != null) ? a.GetHashCode() : 0)) * 23 + ((b != null) ? b.GetHashCode() : 0)) * 23 + ((c != null) ? c.GetHashCode() : 0)) * 23 + ((d != null) ? d.GetHashCode() : 0);
		}

		// Token: 0x06000926 RID: 2342 RVA: 0x00027CE8 File Offset: 0x00025EE8
		public static int GetHashCode<T1, T2, T3, T4, T5>(T1 a, T2 b, T3 c, T4 d, T5 e)
		{
			return ((((17 * 23 + ((a != null) ? a.GetHashCode() : 0)) * 23 + ((b != null) ? b.GetHashCode() : 0)) * 23 + ((c != null) ? c.GetHashCode() : 0)) * 23 + ((d != null) ? d.GetHashCode() : 0)) * 23 + ((e != null) ? e.GetHashCode() : 0);
		}

		// Token: 0x06000927 RID: 2343 RVA: 0x00027D84 File Offset: 0x00025F84
		public static int GetHashCodeAlloc(params object[] values)
		{
			int num = 17;
			foreach (object obj in values)
			{
				num = num * 23 + ((obj != null) ? obj.GetHashCode() : 0);
			}
			return num;
		}
	}
}
