using System;
using System.Collections.Generic;

namespace Unity.Properties
{
	// Token: 0x02000047 RID: 71
	public interface IDictionaryPropertyBag<TDictionary, TKey, TValue> : ICollectionPropertyBag<TDictionary, KeyValuePair<TKey, TValue>>, IPropertyBag<TDictionary>, IPropertyBag, ICollectionPropertyBagAccept<!0>, IDictionaryPropertyBagAccept<TDictionary>, IDictionaryPropertyAccept<TDictionary>, IKeyedProperties<TDictionary, object> where TDictionary : IDictionary<TKey, TValue>
	{
	}
}
