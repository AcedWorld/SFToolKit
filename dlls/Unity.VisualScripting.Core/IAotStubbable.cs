using System;
using System.Collections.Generic;

namespace Unity.VisualScripting
{
	// Token: 0x020000BD RID: 189
	public interface IAotStubbable
	{
		// Token: 0x060004B5 RID: 1205
		IEnumerable<object> GetAotStubs(HashSet<object> visited);
	}
}
