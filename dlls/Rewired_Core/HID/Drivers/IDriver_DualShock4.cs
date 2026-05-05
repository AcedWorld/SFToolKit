using System;
using Rewired.ControllerExtensions;
using UnityEngine;

namespace Rewired.HID.Drivers
{
	// Token: 0x020001DC RID: 476
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	internal interface IDriver_DualShock4 : IControllerDriver, IHIDControllerExtension
	{
		// Token: 0x170005C5 RID: 1477
		// (get) Token: 0x0600184C RID: 6220
		float BatteryLevel { get; }

		// Token: 0x170005C6 RID: 1478
		// (get) Token: 0x0600184D RID: 6221
		bool BatteryCharging { get; }

		// Token: 0x170005C7 RID: 1479
		// (get) Token: 0x0600184E RID: 6222
		// (set) Token: 0x0600184F RID: 6223
		float LeftMotor { get; set; }

		// Token: 0x170005C8 RID: 1480
		// (get) Token: 0x06001850 RID: 6224
		// (set) Token: 0x06001851 RID: 6225
		float RightMotor { get; set; }

		// Token: 0x170005C9 RID: 1481
		// (get) Token: 0x06001852 RID: 6226
		// (set) Token: 0x06001853 RID: 6227
		float LightColorR { get; set; }

		// Token: 0x170005CA RID: 1482
		// (get) Token: 0x06001854 RID: 6228
		// (set) Token: 0x06001855 RID: 6229
		float LightColorG { get; set; }

		// Token: 0x170005CB RID: 1483
		// (get) Token: 0x06001856 RID: 6230
		// (set) Token: 0x06001857 RID: 6231
		float LightColorB { get; set; }

		// Token: 0x170005CC RID: 1484
		// (get) Token: 0x06001858 RID: 6232
		// (set) Token: 0x06001859 RID: 6233
		float LightFlashOnDuration { get; set; }

		// Token: 0x170005CD RID: 1485
		// (get) Token: 0x0600185A RID: 6234
		// (set) Token: 0x0600185B RID: 6235
		float LightFlashOffDuration { get; set; }

		// Token: 0x170005CE RID: 1486
		// (get) Token: 0x0600185C RID: 6236
		Vector3 AccelerometerValue { get; }

		// Token: 0x170005CF RID: 1487
		// (get) Token: 0x0600185D RID: 6237
		Vector3 AccelerometerValueRaw { get; }

		// Token: 0x170005D0 RID: 1488
		// (get) Token: 0x0600185E RID: 6238
		Vector3 GyroscopeValue { get; }

		// Token: 0x170005D1 RID: 1489
		// (get) Token: 0x0600185F RID: 6239
		Vector3 GyroscopeValueRaw { get; }

		// Token: 0x170005D2 RID: 1490
		// (get) Token: 0x06001860 RID: 6240
		Vector3 LastGyroscopeValue { get; }

		// Token: 0x170005D3 RID: 1491
		// (get) Token: 0x06001861 RID: 6241
		Vector3 LastGyroscopeValueRaw { get; }

		// Token: 0x170005D4 RID: 1492
		// (get) Token: 0x06001862 RID: 6242
		Quaternion Orientation { get; }

		// Token: 0x06001863 RID: 6243
		void ResetOrientation();

		// Token: 0x170005D5 RID: 1493
		// (get) Token: 0x06001864 RID: 6244
		int MaxTouches { get; }

		// Token: 0x06001865 RID: 6245
		int GetTouchCount();

		// Token: 0x06001866 RID: 6246
		bool IsTouchingAtTouchId(int touchId);

		// Token: 0x06001867 RID: 6247
		bool IsTouchingAtIndex(int index);

		// Token: 0x06001868 RID: 6248
		int GetTouchIdAtIndex(int index);

		// Token: 0x06001869 RID: 6249
		bool GetTouchPositionByIndex(int index, out Vector2 position);

		// Token: 0x0600186A RID: 6250
		bool GetTouchPositionByTouchId(int touchId, out Vector2 position);

		// Token: 0x0600186B RID: 6251
		bool GetTouchPositionAbsoluteByIndex(int index, out int positionX, out int positionY);

		// Token: 0x0600186C RID: 6252
		bool GetTouchPositionAbsoluteByTouchId(int touchId, out int positionX, out int positionY);

		// Token: 0x0600186D RID: 6253
		void StopLightFlash();

		// Token: 0x0600186E RID: 6254
		void StopVibration();
	}
}
