using System;
using Rewired.ControllerExtensions;

namespace Rewired.HID.Drivers
{
	// Token: 0x020001DF RID: 479
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	internal interface IDriver_NintendoSwitchController : IControllerDriver, IHIDControllerExtension
	{
		// Token: 0x170005EC RID: 1516
		// (get) Token: 0x060018A0 RID: 6304
		int vibrationMotorCount { get; }

		// Token: 0x060018A1 RID: 6305
		void GetVibration(int motorIndex, out float amplitudeLow, out float frequencyLow, out float amplitudeHigh, out float frequencyHigh);

		// Token: 0x060018A2 RID: 6306
		void SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh);

		// Token: 0x060018A3 RID: 6307
		void SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh, bool stopOtherMotors);

		// Token: 0x060018A4 RID: 6308
		void SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh, float duration);

		// Token: 0x060018A5 RID: 6309
		void SetVibration(int motorIndex, float amplitudeLow, float frequencyLow, float amplitudeHigh, float frequencyHigh, float duration, bool stopOtherMotors);

		// Token: 0x060018A6 RID: 6310
		void StopVibration(int motorIndex);

		// Token: 0x060018A7 RID: 6311
		void StopVibration();
	}
}
