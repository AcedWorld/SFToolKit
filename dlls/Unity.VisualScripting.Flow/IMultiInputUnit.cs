using System;
using System.Collections.ObjectModel;

namespace Unity.VisualScripting
{
	// Token: 0x0200015C RID: 348
	public interface IMultiInputUnit : IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
	{
		// Token: 0x17000314 RID: 788
		// (get) Token: 0x06000907 RID: 2311
		// (set) Token: 0x06000908 RID: 2312
		int inputCount { get; set; }

		// Token: 0x17000315 RID: 789
		// (get) Token: 0x06000909 RID: 2313
		ReadOnlyCollection<ValueInput> multiInputs { get; }
	}
}
