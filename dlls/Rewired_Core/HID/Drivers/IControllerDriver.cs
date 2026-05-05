using System;

namespace Rewired.HID.Drivers
{
	// Token: 0x020001DB RID: 475
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	internal interface IControllerDriver
	{
		// Token: 0x170005BD RID: 1469
		// (get) Token: 0x06001844 RID: 6212
		int AxisCount { get; }

		// Token: 0x170005BE RID: 1470
		// (get) Token: 0x06001845 RID: 6213
		int ButtonCount { get; }

		// Token: 0x170005BF RID: 1471
		// (get) Token: 0x06001846 RID: 6214
		int HatCount { get; }

		// Token: 0x170005C0 RID: 1472
		// (get) Token: 0x06001847 RID: 6215
		int AccelerometerCount { get; }

		// Token: 0x170005C1 RID: 1473
		// (get) Token: 0x06001848 RID: 6216
		int GyroscopeCount { get; }

		// Token: 0x170005C2 RID: 1474
		// (get) Token: 0x06001849 RID: 6217
		int TouchpadCount { get; }

		// Token: 0x170005C3 RID: 1475
		// (get) Token: 0x0600184A RID: 6218
		int LightCount { get; }

		// Token: 0x170005C4 RID: 1476
		// (get) Token: 0x0600184B RID: 6219
		int VibrationMotorCount { get; }
	}
}
