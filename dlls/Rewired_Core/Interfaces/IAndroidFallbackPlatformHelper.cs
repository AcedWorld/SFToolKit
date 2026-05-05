using System;

namespace Rewired.Interfaces
{
	// Token: 0x020001F5 RID: 501
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal interface IAndroidFallbackPlatformHelper
	{
		// Token: 0x14000032 RID: 50
		// (add) Token: 0x0600191E RID: 6430
		// (remove) Token: 0x0600191F RID: 6431
		event Action DeviceChangedEvent;

		// Token: 0x1700061C RID: 1564
		// (get) Token: 0x06001920 RID: 6432
		IAndroidFallbackDS4Helper ds4Helper { get; }

		// Token: 0x06001921 RID: 6433
		string GetUniqueDeviceIdentifier(string unityJoystickName, int unityArrayIndex);
	}
}
