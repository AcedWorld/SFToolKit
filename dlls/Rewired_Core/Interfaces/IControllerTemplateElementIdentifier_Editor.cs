using System;

namespace Rewired.Interfaces
{
	// Token: 0x020001ED RID: 493
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	internal interface IControllerTemplateElementIdentifier_Editor : IControllerTemplateElementIdentifier, IControllerElementIdentifierCommon_Internal
	{
		// Token: 0x17000616 RID: 1558
		// (get) Token: 0x060018EB RID: 6379
		string scriptingName { get; }

		// Token: 0x17000617 RID: 1559
		// (get) Token: 0x060018EC RID: 6380
		string alternateScriptingName { get; }
	}
}
