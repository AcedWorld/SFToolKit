using System;
using Rewired.Interfaces;

namespace Rewired
{
	// Token: 0x020000E6 RID: 230
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal class UpdateControllerInfoEventArgs : EventArgs
	{
		// Token: 0x0600075B RID: 1883 RVA: 0x0000838D File Offset: 0x0000658D
		public UpdateControllerInfoEventArgs(IInputManagerJoystickPublic A_1)
		{
			this.sourceJoystick = A_1;
		}

		// Token: 0x0400061A RID: 1562
		public readonly IInputManagerJoystickPublic sourceJoystick;
	}
}
