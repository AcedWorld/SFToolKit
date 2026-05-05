using System;

namespace Rewired.Interfaces
{
	// Token: 0x020001E3 RID: 483
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = false)]
	internal interface IInputManagerJoystick : IInputManagerJoystickPublic
	{
		// Token: 0x060018AC RID: 6316
		void Update();

		// Token: 0x060018AD RID: 6317
		void FillData(ControllerDataUpdater dataUpdater);

		// Token: 0x060018AE RID: 6318
		BridgedController ToBridgedController();

		// Token: 0x060018AF RID: 6319
		ControllerDisconnectedEventArgs ToControllerDisconnectedEventArgs();
	}
}
