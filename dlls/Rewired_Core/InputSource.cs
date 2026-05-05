using System;

namespace Rewired
{
	// Token: 0x020000D7 RID: 215
	[CustomObfuscation(rename = false)]
	internal enum InputSource
	{
		// Token: 0x04000572 RID: 1394
		None,
		// Token: 0x04000573 RID: 1395
		DirectInput,
		// Token: 0x04000574 RID: 1396
		XInput,
		// Token: 0x04000575 RID: 1397
		OSX,
		// Token: 0x04000576 RID: 1398
		Fallback,
		// Token: 0x04000577 RID: 1399
		RawInput,
		// Token: 0x04000578 RID: 1400
		Fallback_PreConfigured,
		// Token: 0x04000579 RID: 1401
		Linux,
		// Token: 0x0400057A RID: 1402
		WindowsUWP,
		// Token: 0x0400057B RID: 1403
		WebGL,
		// Token: 0x0400057C RID: 1404
		Steam = 18,
		// Token: 0x0400057D RID: 1405
		SDL2,
		// Token: 0x0400057E RID: 1406
		Ouya,
		// Token: 0x0400057F RID: 1407
		XboxOne,
		// Token: 0x04000580 RID: 1408
		PS4,
		// Token: 0x04000581 RID: 1409
		NintendoSwitch = 24,
		// Token: 0x04000582 RID: 1410
		GameCoreXboxOne = 26,
		// Token: 0x04000583 RID: 1411
		GameCoreScarlett,
		// Token: 0x04000584 RID: 1412
		PS5,
		// Token: 0x04000585 RID: 1413
		AppleGameController,
		// Token: 0x04000586 RID: 1414
		WindowsGamingInput,
		// Token: 0x04000587 RID: 1415
		InternalDriver = 49,
		// Token: 0x04000588 RID: 1416
		UnityKeyboardAndMouse,
		// Token: 0x04000589 RID: 1417
		Custom = 100
	}
}
