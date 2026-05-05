using System;
using Rewired.Interfaces;

namespace Rewired.Data.Mapping
{
	// Token: 0x0200039A RID: 922
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = false)]
	internal interface IHardwareControllerTemplateMap_Internal
	{
		// Token: 0x170008BC RID: 2236
		// (get) Token: 0x0600255F RID: 9567
		string name { get; }

		// Token: 0x170008BD RID: 2237
		// (get) Token: 0x06002560 RID: 9568
		Guid typeGuid { get; }

		// Token: 0x170008BE RID: 2238
		// (get) Token: 0x06002561 RID: 9569
		string typeKey { get; }

		// Token: 0x06002562 RID: 9570
		int GetElementIdentifierCount();

		// Token: 0x06002563 RID: 9571
		IControllerTemplateElementIdentifier GetTemplateElementIdentifier(int index);

		// Token: 0x06002564 RID: 9572
		IControllerTemplateElementIdentifier GetTemplateElementIdentifierById(int elementIdentifierId);

		// Token: 0x06002565 RID: 9573
		IControllerTemplateMapSpecialElement_Internal GetSpecialTemplateElementByElementIdentifierId(int id);

		// Token: 0x06002566 RID: 9574
		zzIYMvAnMtpiMJyIjwvHCSyknhJk GetAxisTarget(Controller controller, int elementIdentifierId);

		// Token: 0x06002567 RID: 9575
		zzIYMvAnMtpiMJyIjwvHCSyknhJk GetButtonTarget(Controller controller, int elementIdentifierId);
	}
}
