using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000039 RID: 57
	[TypeIconPriority]
	public interface IBranchUnit : IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
	{
		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x06000238 RID: 568
		ControlInput enter { get; }
	}
}
