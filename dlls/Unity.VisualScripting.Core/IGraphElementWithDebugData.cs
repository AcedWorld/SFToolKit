using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000073 RID: 115
	public interface IGraphElementWithDebugData : IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
	{
		// Token: 0x0600039A RID: 922
		IGraphElementDebugData CreateDebugData();
	}
}
