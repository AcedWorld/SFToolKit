using System;

namespace Rewired.Internal
{
	// Token: 0x0200042B RID: 1067
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal interface IInputManagerHardwareJoystickMapHandler
	{
		// Token: 0x06002AFD RID: 11005
		void InitializeHardwareJoystickMap(HardwareJoystickMap_InputManager hardwareMap);
	}
}
