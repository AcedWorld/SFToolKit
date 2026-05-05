using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200007C RID: 124
	public interface IGameObjectEventUnit : IEventUnit, IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable, IGraphEventListener
	{
		// Token: 0x17000177 RID: 375
		// (get) Token: 0x06000404 RID: 1028
		Type MessageListenerType { get; }
	}
}
