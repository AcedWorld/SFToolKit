using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200003B RID: 59
	[TypeIconPriority]
	public interface ISelectUnit : IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
	{
		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x06000245 RID: 581
		ValueOutput selection { get; }
	}
}
