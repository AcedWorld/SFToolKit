using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200000B RID: 11
	public interface IStateTransition : IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable, IConnection<IState, IState>
	{
		// Token: 0x06000030 RID: 48
		void Branch(Flow flow);

		// Token: 0x06000031 RID: 49
		void OnEnter(Flow flow);

		// Token: 0x06000032 RID: 50
		void OnExit(Flow flow);
	}
}
