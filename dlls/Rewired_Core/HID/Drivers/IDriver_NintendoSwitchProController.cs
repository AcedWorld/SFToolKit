using System;
using Rewired.ControllerExtensions;

namespace Rewired.HID.Drivers
{
	// Token: 0x020001E1 RID: 481
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	internal interface IDriver_NintendoSwitchProController : IDriver_NintendoSwitchController, IControllerDriver, IHIDControllerExtension
	{
	}
}
