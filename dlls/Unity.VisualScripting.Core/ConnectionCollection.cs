using System;
using System.Collections.Generic;

namespace Unity.VisualScripting
{
	// Token: 0x02000029 RID: 41
	public class ConnectionCollection<TConnection, TSource, TDestination> : ConnectionCollectionBase<TConnection, TSource, TDestination, List<TConnection>> where TConnection : IConnection<TSource, TDestination>
	{
		// Token: 0x0600017B RID: 379 RVA: 0x00004713 File Offset: 0x00002913
		public ConnectionCollection() : base(new List<TConnection>())
		{
		}
	}
}
