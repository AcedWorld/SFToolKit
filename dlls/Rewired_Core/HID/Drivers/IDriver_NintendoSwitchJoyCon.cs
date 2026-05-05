using System;
using Rewired.ControllerExtensions;
using Rewired.Interfaces;

namespace Rewired.HID.Drivers
{
	// Token: 0x020001E0 RID: 480
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	internal interface IDriver_NintendoSwitchJoyCon : IDriver_NintendoSwitchController, IControllerDriver, IHIDControllerExtension, IAxisCalibrationIndexMap
	{
		// Token: 0x170005ED RID: 1517
		// (get) Token: 0x060018A8 RID: 6312
		NintendoSwitchJoyConType joyConType { get; }

		// Token: 0x170005EE RID: 1518
		// (get) Token: 0x060018A9 RID: 6313
		// (set) Token: 0x060018AA RID: 6314
		NintendoSwitchJoyConGripStyle joyConGripStyle { get; set; }
	}
}
