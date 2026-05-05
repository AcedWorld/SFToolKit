using System;

namespace Rewired.Platforms.XboxOne
{
	// Token: 0x02000214 RID: 532
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	internal interface IXboxOneInputSource
	{
		// Token: 0x06001928 RID: 6440
		int GetXboxOneUserIdFromUnityJoystick(int unityJoystickId);

		// Token: 0x06001929 RID: 6441
		bool SetXboxOneVibration(ulong xboxOneJoystickId, eSdkeiNbMcydmNPVeUBLWdxGyQBY vibration);

		// Token: 0x0600192A RID: 6442
		void PulseVibrateMotor(ulong xboxOneJoystickId, XboxOneGamepadMotorType motor, float startLevel, float endLevel, float duration);
	}
}
