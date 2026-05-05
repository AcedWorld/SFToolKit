using System;
using System.Collections.Generic;
using Rewired.Interfaces;

namespace Rewired.Data.Mapping
{
	// Token: 0x02000399 RID: 921
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = false)]
	internal interface IHardwareControllerMap_Internal
	{
		// Token: 0x170008B7 RID: 2231
		// (get) Token: 0x06002559 RID: 9561
		string name { get; }

		// Token: 0x170008B8 RID: 2232
		// (get) Token: 0x0600255A RID: 9562
		Guid typeGuid { get; }

		// Token: 0x170008B9 RID: 2233
		// (get) Token: 0x0600255B RID: 9563
		string typeKey { get; }

		// Token: 0x170008BA RID: 2234
		// (get) Token: 0x0600255C RID: 9564
		ControllerType controllerType { get; }

		// Token: 0x170008BB RID: 2235
		// (get) Token: 0x0600255D RID: 9565
		IEnumerable<IControllerElementIdentifierCommon_Internal> ElementIdentifiers { get; }

		// Token: 0x0600255E RID: 9566
		IControllerElementIdentifierCommon_Internal GetElementIdentifier(int id);
	}
}
