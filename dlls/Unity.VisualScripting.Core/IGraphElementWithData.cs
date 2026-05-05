using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000072 RID: 114
	public interface IGraphElementWithData : IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
	{
		// Token: 0x06000399 RID: 921
		IGraphElementData CreateData();
	}
}
