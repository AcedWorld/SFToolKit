using System;
using System.Collections.Generic;

namespace Unity.VisualScripting
{
	// Token: 0x0200006E RID: 110
	public interface IGraphElement : IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
	{
		// Token: 0x170000DA RID: 218
		// (get) Token: 0x0600038E RID: 910
		// (set) Token: 0x0600038F RID: 911
		IGraph graph { get; set; }

		// Token: 0x06000390 RID: 912
		bool HandleDependencies();

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x06000391 RID: 913
		int dependencyOrder { get; }

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x06000392 RID: 914
		// (set) Token: 0x06000393 RID: 915
		Guid guid { get; set; }

		// Token: 0x06000394 RID: 916
		void Instantiate(GraphReference instance);

		// Token: 0x06000395 RID: 917
		void Uninstantiate(GraphReference instance);

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x06000396 RID: 918
		IEnumerable<ISerializationDependency> deserializationDependencies { get; }
	}
}
