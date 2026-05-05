using System;

namespace Kamgam.UGUIBlurredBackground
{
	// Token: 0x02000009 RID: 9
	public class Installer
	{
		// Token: 0x0600000E RID: 14 RVA: 0x0000239E File Offset: 0x0000059E
		public static Version GetVersion()
		{
			return new Version("1.2.0");
		}

		// Token: 0x04000011 RID: 17
		public const string AssetName = "UGUI Blurred Background";

		// Token: 0x04000012 RID: 18
		public const string Version = "1.2.0";

		// Token: 0x04000013 RID: 19
		public const string Define = "KAMGAM_UGUI_BLURRED_BACKGROUND";

		// Token: 0x04000014 RID: 20
		public const string ManualUrl = "https://kamgam.com/unity/UGUIBlurredBackgroundManual.pdf";

		// Token: 0x04000015 RID: 21
		public const string AssetLink = "https://assetstore.unity.com/packages/slug/260862";

		// Token: 0x04000016 RID: 22
		public static string AssetRootPath = "Assets/Kamgam/UGUIBlurredBackground/";

		// Token: 0x04000017 RID: 23
		public static string ExamplePath = Installer.AssetRootPath + "Examples/UGUIBlurredBackgroundDemo.unity";
	}
}
