using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000005 RID: 5
	public interface IUnitConnection : IConnection<IUnitOutputPort, IUnitInputPort>, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
	{
		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000021 RID: 33
		FlowGraph graph { get; }
	}
}
