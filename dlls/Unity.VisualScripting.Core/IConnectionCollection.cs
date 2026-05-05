using System;
using System.Collections;
using System.Collections.Generic;

namespace Unity.VisualScripting
{
	// Token: 0x0200002D RID: 45
	public interface IConnectionCollection<TConnection, TSource, TDestination> : ICollection<TConnection>, IEnumerable<!0>, IEnumerable where TConnection : IConnection<TSource, TDestination>
	{
		// Token: 0x17000050 RID: 80
		IEnumerable<TConnection> this[TSource source]
		{
			get;
		}

		// Token: 0x17000051 RID: 81
		IEnumerable<TConnection> this[TDestination destination]
		{
			get;
		}

		// Token: 0x060001A8 RID: 424
		IEnumerable<TConnection> WithSource(TSource source);

		// Token: 0x060001A9 RID: 425
		IEnumerable<TConnection> WithDestination(TDestination destination);
	}
}
