using System;
using System.Collections;
using System.Collections.Generic;

namespace Unity.VisualScripting
{
	// Token: 0x0200016E RID: 366
	public interface IUnitPortCollection<TPort> : IKeyedCollection<string, TPort>, ICollection<TPort>, IEnumerable<TPort>, IEnumerable where TPort : IUnitPort
	{
		// Token: 0x06000972 RID: 2418
		TPort Single();
	}
}
