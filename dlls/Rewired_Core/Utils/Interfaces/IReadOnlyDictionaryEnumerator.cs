using System;

namespace Rewired.Utils.Interfaces
{
	// Token: 0x0200052E RID: 1326
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal interface IReadOnlyDictionaryEnumerator<TKey, TValue>
	{
		// Token: 0x17000C21 RID: 3105
		TValue this[TKey key]
		{
			get;
		}

		// Token: 0x0600365B RID: 13915
		bool ContainsKey(TKey key);

		// Token: 0x0600365C RID: 13916
		bool TryGetValue(TKey key, out TValue value);
	}
}
