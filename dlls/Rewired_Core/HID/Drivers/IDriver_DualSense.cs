using System;
using Rewired.ControllerExtensions;
using UnityEngine;

namespace Rewired.HID.Drivers
{
	// Token: 0x020001DD RID: 477
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	internal interface IDriver_DualSense : IControllerDriver, IHIDControllerExtension
	{
		// Token: 0x170005D6 RID: 1494
		// (get) Token: 0x0600186F RID: 6255
		float BatteryLevel { get; }

		// Token: 0x170005D7 RID: 1495
		// (get) Token: 0x06001870 RID: 6256
		bool BatteryCharging { get; }

		// Token: 0x170005D8 RID: 1496
		// (get) Token: 0x06001871 RID: 6257
		// (set) Token: 0x06001872 RID: 6258
		DualSenseVibrationMode vibrationMode { get; set; }

		// Token: 0x170005D9 RID: 1497
		// (get) Token: 0x06001873 RID: 6259
		// (set) Token: 0x06001874 RID: 6260
		float LeftMotor { get; set; }

		// Token: 0x170005DA RID: 1498
		// (get) Token: 0x06001875 RID: 6261
		// (set) Token: 0x06001876 RID: 6262
		float RightMotor { get; set; }

		// Token: 0x170005DB RID: 1499
		// (get) Token: 0x06001877 RID: 6263
		// (set) Token: 0x06001878 RID: 6264
		float LightColorR { get; set; }

		// Token: 0x170005DC RID: 1500
		// (get) Token: 0x06001879 RID: 6265
		// (set) Token: 0x0600187A RID: 6266
		float LightColorG { get; set; }

		// Token: 0x170005DD RID: 1501
		// (get) Token: 0x0600187B RID: 6267
		// (set) Token: 0x0600187C RID: 6268
		float LightColorB { get; set; }

		// Token: 0x170005DE RID: 1502
		// (get) Token: 0x0600187D RID: 6269
		// (set) Token: 0x0600187E RID: 6270
		float LightFlashOnDuration { get; set; }

		// Token: 0x170005DF RID: 1503
		// (get) Token: 0x0600187F RID: 6271
		// (set) Token: 0x06001880 RID: 6272
		float LightFlashOffDuration { get; set; }

		// Token: 0x170005E0 RID: 1504
		// (get) Token: 0x06001881 RID: 6273
		// (set) Token: 0x06001882 RID: 6274
		DualSenseMicrophoneLightMode microphoneLightMode { get; set; }

		// Token: 0x170005E1 RID: 1505
		// (get) Token: 0x06001883 RID: 6275
		// (set) Token: 0x06001884 RID: 6276
		DualSenseOtherLightBrightness otherLightBrightness { get; set; }

		// Token: 0x170005E2 RID: 1506
		// (get) Token: 0x06001885 RID: 6277
		// (set) Token: 0x06001886 RID: 6278
		DualSensePlayerLightFlags playerLights { get; set; }

		// Token: 0x170005E3 RID: 1507
		// (get) Token: 0x06001887 RID: 6279
		Vector3 AccelerometerValue { get; }

		// Token: 0x170005E4 RID: 1508
		// (get) Token: 0x06001888 RID: 6280
		Vector3 AccelerometerValueRaw { get; }

		// Token: 0x170005E5 RID: 1509
		// (get) Token: 0x06001889 RID: 6281
		Vector3 GyroscopeValue { get; }

		// Token: 0x170005E6 RID: 1510
		// (get) Token: 0x0600188A RID: 6282
		Vector3 GyroscopeValueRaw { get; }

		// Token: 0x170005E7 RID: 1511
		// (get) Token: 0x0600188B RID: 6283
		Vector3 LastGyroscopeValue { get; }

		// Token: 0x170005E8 RID: 1512
		// (get) Token: 0x0600188C RID: 6284
		Vector3 LastGyroscopeValueRaw { get; }

		// Token: 0x170005E9 RID: 1513
		// (get) Token: 0x0600188D RID: 6285
		Quaternion Orientation { get; }

		// Token: 0x0600188E RID: 6286
		void ResetOrientation();

		// Token: 0x170005EA RID: 1514
		// (get) Token: 0x0600188F RID: 6287
		int MaxTouches { get; }

		// Token: 0x06001890 RID: 6288
		int GetTouchCount();

		// Token: 0x06001891 RID: 6289
		bool IsTouchingAtTouchId(int touchId);

		// Token: 0x06001892 RID: 6290
		bool IsTouchingAtIndex(int index);

		// Token: 0x06001893 RID: 6291
		int GetTouchIdAtIndex(int index);

		// Token: 0x06001894 RID: 6292
		bool GetTouchPositionByIndex(int index, out Vector2 position);

		// Token: 0x06001895 RID: 6293
		bool GetTouchPositionByTouchId(int touchId, out Vector2 position);

		// Token: 0x06001896 RID: 6294
		bool GetTouchPositionAbsoluteByIndex(int index, out int positionX, out int positionY);

		// Token: 0x06001897 RID: 6295
		bool GetTouchPositionAbsoluteByTouchId(int touchId, out int positionX, out int positionY);

		// Token: 0x06001898 RID: 6296
		void StopLightFlash();

		// Token: 0x06001899 RID: 6297
		void StopVibration();

		// Token: 0x0600189A RID: 6298
		bool SetTriggerEffect(DualSenseTriggerType trigger, IDualSenseTriggerEffect effect);

		// Token: 0x0600189B RID: 6299
		DualSenseTriggerEffectStates GetTriggerEffectStates();
	}
}
