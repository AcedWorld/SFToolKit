using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000166 RID: 358
	public interface IUnitControlPort : IUnitPort, IGraphItem
	{
		// Token: 0x17000338 RID: 824
		// (get) Token: 0x0600095F RID: 2399
		bool isPredictable { get; }

		// Token: 0x17000339 RID: 825
		// (get) Token: 0x06000960 RID: 2400
		bool couldBeEntered { get; }
	}
}
