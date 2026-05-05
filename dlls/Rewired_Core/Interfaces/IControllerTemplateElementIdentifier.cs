using System;

namespace Rewired.Interfaces
{
	// Token: 0x020001EC RID: 492
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	internal interface IControllerTemplateElementIdentifier : IControllerElementIdentifierCommon_Internal
	{
		// Token: 0x17000615 RID: 1557
		// (get) Token: 0x060018EA RID: 6378
		ControllerTemplateElementType elementType { get; }
	}
}
