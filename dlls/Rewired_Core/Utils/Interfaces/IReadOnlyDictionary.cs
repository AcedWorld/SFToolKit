using System;
using System.Collections;
using System.Collections.Generic;

namespace Rewired.Utils.Interfaces
{
	// Token: 0x0200052D RID: 1325
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal interface IReadOnlyDictionary<TKey, TValue> : ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable
	{
		// Token: 0x17000C1E RID: 3102
		TValue this[TKey key]
		{
			get;
		}

		// Token: 0x17000C1F RID: 3103
		// (get) Token: 0x06003656 RID: 13910
		ICollection<TKey> Keys { get; }

		// Token: 0x17000C20 RID: 3104
		// (get) Token: 0x06003657 RID: 13911
		ICollection<TValue> Values { get; }

		// Token: 0x06003658 RID: 13912
		bool ContainsKey(TKey key);

		// Token: 0x06003659 RID: 13913
		bool TryGetValue(TKey key, out TValue value);
	}
}
