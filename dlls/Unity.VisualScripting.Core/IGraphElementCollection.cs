using System;
using System.Collections;
using System.Collections.Generic;

namespace Unity.VisualScripting
{
	// Token: 0x0200006F RID: 111
	public interface IGraphElementCollection<T> : IKeyedCollection<Guid, !0>, ICollection<T>, IEnumerable<!0>, IEnumerable, INotifyCollectionChanged<T> where T : IGraphElement
	{
	}
}
