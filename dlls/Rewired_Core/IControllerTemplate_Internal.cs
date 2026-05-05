using System;
using Rewired.Internal.Localization;

namespace Rewired
{
	// Token: 0x02000098 RID: 152
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	internal interface IControllerTemplate_Internal : IControllerTemplate
	{
		// Token: 0x1700021D RID: 541
		// (get) Token: 0x06000622 RID: 1570
		DeviceLocalizationInfo deviceLocalizationInfo { get; }
	}
}
