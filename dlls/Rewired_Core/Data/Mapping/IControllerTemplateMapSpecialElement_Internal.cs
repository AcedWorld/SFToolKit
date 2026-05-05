using System;

namespace Rewired.Data.Mapping
{
	// Token: 0x0200039C RID: 924
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = false)]
	internal interface IControllerTemplateMapSpecialElement_Internal
	{
		// Token: 0x06002569 RID: 9577
		T GetMapping<T>() where T : ControllerTemplateSpecialElementMapping;
	}
}
