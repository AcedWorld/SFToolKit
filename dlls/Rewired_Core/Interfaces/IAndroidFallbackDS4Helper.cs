using System;

namespace Rewired.Interfaces
{
	// Token: 0x020001F4 RID: 500
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal interface IAndroidFallbackDS4Helper
	{
		// Token: 0x0600191C RID: 6428
		bool IsDS4KeyMapped(int unityJoystickArrayIndex);

		// Token: 0x0600191D RID: 6429
		bool IsDS4(string name);
	}
}
