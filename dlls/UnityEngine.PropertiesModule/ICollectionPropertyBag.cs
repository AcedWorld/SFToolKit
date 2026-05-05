using System;
using System.Collections.Generic;

namespace Unity.Properties
{
	// Token: 0x02000044 RID: 68
	public interface ICollectionPropertyBag<TCollection, TElement> : IPropertyBag<TCollection>, IPropertyBag, ICollectionPropertyBagAccept<!0> where TCollection : ICollection<TElement>
	{
	}
}
