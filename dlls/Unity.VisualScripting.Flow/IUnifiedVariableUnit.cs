using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200013A RID: 314
	public interface IUnifiedVariableUnit : IUnit, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
	{
		// Token: 0x170002E3 RID: 739
		// (get) Token: 0x0600085E RID: 2142
		VariableKind kind { get; }

		// Token: 0x170002E4 RID: 740
		// (get) Token: 0x0600085F RID: 2143
		ValueInput name { get; }
	}
}
