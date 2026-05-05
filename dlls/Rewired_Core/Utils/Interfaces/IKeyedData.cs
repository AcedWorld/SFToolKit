using System;

namespace Rewired.Utils.Interfaces
{
	// Token: 0x0200052A RID: 1322
	public interface IKeyedData<TKey>
	{
		// Token: 0x0600364C RID: 13900
		bool TryGetValue<T>(TKey key, out T value);

		// Token: 0x0600364D RID: 13901
		bool TrySetValue<T>(TKey key, T value);
	}
}
