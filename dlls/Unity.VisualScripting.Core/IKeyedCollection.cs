using System;
using System.Collections;
using System.Collections.Generic;

namespace Unity.VisualScripting
{
	// Token: 0x02000017 RID: 23
	public interface IKeyedCollection<TKey, TItem> : ICollection<TItem>, IEnumerable<TItem>, IEnumerable
	{
		// Token: 0x1700001E RID: 30
		TItem this[TKey key]
		{
			get;
		}

		// Token: 0x1700001F RID: 31
		TItem this[int index]
		{
			get;
		}

		// Token: 0x06000092 RID: 146
		bool TryGetValue(TKey key, out TItem value);

		// Token: 0x06000093 RID: 147
		bool Contains(TKey key);

		// Token: 0x06000094 RID: 148
		bool Remove(TKey key);
	}
}
