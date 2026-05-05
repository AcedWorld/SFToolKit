using System;
using Rewired.Platforms.Custom;
using UnityEngine;

namespace Rewired.Demos.CustomPlatform
{
	// Token: 0x020002D2 RID: 722
	public sealed class CustomPlatformManager : MonoBehaviour, ICustomPlatformInitializer
	{
		// Token: 0x06000F42 RID: 3906 RVA: 0x00051C58 File Offset: 0x0004FE58
		public CustomPlatformInitOptions GetCustomPlatformInitOptions()
		{
			CustomPlatformInitOptions customPlatformInitOptions = new CustomPlatformInitOptions();
			customPlatformInitOptions.platformId = 0;
			customPlatformInitOptions.platformIdentifierString = "MyPlatform";
			customPlatformInitOptions.hardwareJoystickMapCustomPlatformMapProvider = this.mapProvider;
			CustomPlatformConfigVars configVars = new CustomPlatformConfigVars
			{
				ignoreInputWhenAppNotInFocus = true,
				useNativeKeyboard = true,
				useNativeMouse = true
			};
			customPlatformInitOptions.inputSource = new MyPlatformInputSource(configVars);
			return customPlatformInitOptions;
		}

		// Token: 0x040013F2 RID: 5106
		public CustomPlatformHardwareJoystickMapProvider mapProvider;
	}
}
