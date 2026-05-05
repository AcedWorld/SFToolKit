using System;
using System.Collections.Generic;

namespace Unity.VisualScripting
{
	// Token: 0x0200016D RID: 365
	public interface IUnitPort : IGraphItem
	{
		// Token: 0x1700033A RID: 826
		// (get) Token: 0x06000961 RID: 2401
		// (set) Token: 0x06000962 RID: 2402
		IUnit unit { get; set; }

		// Token: 0x1700033B RID: 827
		// (get) Token: 0x06000963 RID: 2403
		string key { get; }

		// Token: 0x1700033C RID: 828
		// (get) Token: 0x06000964 RID: 2404
		IEnumerable<IUnitRelation> relations { get; }

		// Token: 0x1700033D RID: 829
		// (get) Token: 0x06000965 RID: 2405
		IEnumerable<IUnitConnection> validConnections { get; }

		// Token: 0x1700033E RID: 830
		// (get) Token: 0x06000966 RID: 2406
		IEnumerable<InvalidConnection> invalidConnections { get; }

		// Token: 0x1700033F RID: 831
		// (get) Token: 0x06000967 RID: 2407
		IEnumerable<IUnitConnection> connections { get; }

		// Token: 0x17000340 RID: 832
		// (get) Token: 0x06000968 RID: 2408
		IEnumerable<IUnitPort> connectedPorts { get; }

		// Token: 0x17000341 RID: 833
		// (get) Token: 0x06000969 RID: 2409
		bool hasAnyConnection { get; }

		// Token: 0x17000342 RID: 834
		// (get) Token: 0x0600096A RID: 2410
		bool hasValidConnection { get; }

		// Token: 0x17000343 RID: 835
		// (get) Token: 0x0600096B RID: 2411
		bool hasInvalidConnection { get; }

		// Token: 0x0600096C RID: 2412
		bool CanInvalidlyConnectTo(IUnitPort port);

		// Token: 0x0600096D RID: 2413
		bool CanValidlyConnectTo(IUnitPort port);

		// Token: 0x0600096E RID: 2414
		void InvalidlyConnectTo(IUnitPort port);

		// Token: 0x0600096F RID: 2415
		void ValidlyConnectTo(IUnitPort port);

		// Token: 0x06000970 RID: 2416
		void Disconnect();

		// Token: 0x06000971 RID: 2417
		IUnitPort CompatiblePort(IUnit unit);
	}
}
