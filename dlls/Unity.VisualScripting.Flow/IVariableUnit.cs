using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200014C RID: 332
	public interface IVariableUnit : IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
	{
		// Token: 0x170002E9 RID: 745
		// (get) Token: 0x0600089B RID: 2203
		ValueInput name { get; }
	}
}
