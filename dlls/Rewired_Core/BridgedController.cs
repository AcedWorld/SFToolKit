using System;
using Rewired.Interfaces;
using Rewired.Platforms.Custom;

namespace Rewired
{
	// Token: 0x020000E1 RID: 225
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal class BridgedController : BridgedControllerHWInfo
	{
		// Token: 0x17000286 RID: 646
		// (get) Token: 0x06000752 RID: 1874 RVA: 0x0000835C File Offset: 0x0000655C
		public bool isUnknownController
		{
			get
			{
				return this.controllerTypeGuid == Guid.Empty;
			}
		}

		// Token: 0x040005F8 RID: 1528
		public IInputManagerJoystickPublic sourceJoystick;

		// Token: 0x040005F9 RID: 1529
		public HardwareControllerMap_Game gameHardwareMap;

		// Token: 0x040005FA RID: 1530
		public Guid controllerTypeGuid;

		// Token: 0x040005FB RID: 1531
		public Controller.Extension controllerExtension;

		// Token: 0x040005FC RID: 1532
		public string instanceName;

		// Token: 0x040005FD RID: 1533
		public string productName;

		// Token: 0x040005FE RID: 1534
		public bool isXInputDevice;

		// Token: 0x040005FF RID: 1535
		public int axisCount;

		// Token: 0x04000600 RID: 1536
		public int buttonCount;

		// Token: 0x04000601 RID: 1537
		public bool[] isButtonPressureSensitive;

		// Token: 0x04000602 RID: 1538
		public UnknownControllerHat[] unknownControllerHats;

		// Token: 0x04000603 RID: 1539
		public CustomInputSource customInputSource;
	}
}
