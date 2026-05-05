using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Rewired.Utils
{
	// Token: 0x02000478 RID: 1144
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal static class EmptyObjects<T>
	{
		// Token: 0x17000ADE RID: 2782
		// (get) Token: 0x06002D76 RID: 11638 RVA: 0x000230DA File Offset: 0x000212DA
		public static T[] array
		{
			get
			{
				T[] result;
				if ((result = EmptyObjects<T>.VOEKjDXTByTwCaxknndCZIpHswro) == null)
				{
					result = (EmptyObjects<T>.VOEKjDXTByTwCaxknndCZIpHswro = new T[0]);
				}
				return result;
			}
		}

		// Token: 0x17000ADF RID: 2783
		// (get) Token: 0x06002D77 RID: 11639 RVA: 0x000230F1 File Offset: 0x000212F1
		public static IList<T> EmptyReadOnlyIListT
		{
			get
			{
				IList<T> result;
				if ((result = EmptyObjects<T>.WTbisVXqPEZiCYzeWUupZmTcpVkO) == null)
				{
					result = (EmptyObjects<T>.WTbisVXqPEZiCYzeWUupZmTcpVkO = new ReadOnlyCollection<T>(new List<T>()));
				}
				return result;
			}
		}

		// Token: 0x04001985 RID: 6533
		private static T[] VOEKjDXTByTwCaxknndCZIpHswro;

		// Token: 0x04001986 RID: 6534
		private static IList<T> WTbisVXqPEZiCYzeWUupZmTcpVkO;
	}
}
