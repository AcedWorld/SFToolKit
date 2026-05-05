using System;

namespace Rewired.Platforms.Custom
{
	// Token: 0x02000223 RID: 547
	public sealed class CustomPlatformInitOptions
	{
		// Token: 0x060019AB RID: 6571 RVA: 0x000150A3 File Offset: 0x000132A3
		public CustomPlatformInitOptions()
		{
		}

		// Token: 0x060019AC RID: 6572 RVA: 0x00071958 File Offset: 0x0006FB58
		public CustomPlatformInitOptions(CustomPlatformInitOptions A_1)
		{
			if (A_1 == null)
			{
				throw new ArgumentNullException("other");
			}
			this.platformId = A_1.platformId;
			this.platformIdentifierString = A_1.platformIdentifierString;
			this.inputSource = A_1.inputSource;
			this.hardwareJoystickMapCustomPlatformMapProvider = A_1.hardwareJoystickMapCustomPlatformMapProvider;
			this.configVars = ((A_1.configVars != null) ? A_1.configVars : null);
		}

		// Token: 0x04000EA6 RID: 3750
		internal const int htigUSWGXVDbedNywaBDUucekCPJA = -1;

		// Token: 0x04000EA7 RID: 3751
		public int platformId = -1;

		// Token: 0x04000EA8 RID: 3752
		public string platformIdentifierString;

		// Token: 0x04000EA9 RID: 3753
		public CustomInputSource inputSource;

		// Token: 0x04000EAA RID: 3754
		public IHardwareJoystickMapCustomPlatformMapProvider hardwareJoystickMapCustomPlatformMapProvider;

		// Token: 0x04000EAB RID: 3755
		public CustomPlatformConfigVars configVars = new CustomPlatformConfigVars();
	}
}
