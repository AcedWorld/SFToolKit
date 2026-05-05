using System;
using Rewired.Data;

namespace Rewired.Platforms.Custom
{
	// Token: 0x02000224 RID: 548
	[Serializable]
	public class CustomPlatformConfigVars : ConfigVars.PlatformVars
	{
		// Token: 0x04000EAC RID: 3756
		public bool useNativeKeyboard = true;

		// Token: 0x04000EAD RID: 3757
		public bool useNativeMouse = true;
	}
}
