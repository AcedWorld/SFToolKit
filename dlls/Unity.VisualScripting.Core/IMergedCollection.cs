using System;
using System.Collections;
using System.Collections.Generic;

namespace Unity.VisualScripting
{
	// Token: 0x02000018 RID: 24
	public interface IMergedCollection<T> : ICollection<T>, IEnumerable<!0>, IEnumerable
	{
		// Token: 0x06000095 RID: 149
		bool Includes<TI>() where TI : T;

		// Token: 0x06000096 RID: 150
		bool Includes(Type elementType);
	}
}
