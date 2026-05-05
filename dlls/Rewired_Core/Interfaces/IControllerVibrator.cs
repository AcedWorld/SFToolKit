using System;

namespace Rewired.Interfaces
{
	// Token: 0x020001EE RID: 494
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = false)]
	public interface IControllerVibrator
	{
		// Token: 0x17000618 RID: 1560
		// (get) Token: 0x060018ED RID: 6381
		int vibrationMotorCount { get; }

		// Token: 0x060018EE RID: 6382
		void SetVibration(int motorIndex, float motorLevel);

		// Token: 0x060018EF RID: 6383
		void SetVibration(int motorIndex, float motorLevel, float duration);

		// Token: 0x060018F0 RID: 6384
		void SetVibration(int motorIndex, float motorLevel, bool stopOtherMotors);

		// Token: 0x060018F1 RID: 6385
		void SetVibration(int motorIndex, float motorLevel, float duration, bool stopOtherMotors);

		// Token: 0x060018F2 RID: 6386
		float GetVibration(int motorIndex);

		// Token: 0x060018F3 RID: 6387
		void StopVibration();
	}
}
