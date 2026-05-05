using System;
using System.Collections.Generic;

namespace Unity.Multiplayer.Tools.Common
{
	// Token: 0x0200001C RID: 28
	internal static class ReadOnlyListExtensions
	{
		// Token: 0x06000086 RID: 134 RVA: 0x00002E44 File Offset: 0x00001044
		public static int IndexOf<T>(this IReadOnlyList<T> list, T elementToFind) where T : IEquatable<T>
		{
			int num = 0;
			foreach (T t in list)
			{
				if (t.Equals(elementToFind))
				{
					return num;
				}
				num++;
			}
			return -1;
		}
	}
}
