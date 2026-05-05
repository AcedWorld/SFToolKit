using System;
using Rewired.Platforms;
using UnityEngine;

namespace Rewired.Data
{
	// Token: 0x02000256 RID: 598
	public class EditorPlatformData : ScriptableObject
	{
		// Token: 0x06001B46 RID: 6982 RVA: 0x0001604E File Offset: 0x0001424E
		public TextAsset[] GetLibraries(Rewired.Platforms.Platform platform, WebplayerPlatform webplayerPlatform, EditorPlatform editorPlatform)
		{
			return this.GetPlatform(platform, webplayerPlatform, editorPlatform).libraries;
		}

		// Token: 0x06001B47 RID: 6983 RVA: 0x00075848 File Offset: 0x00073A48
		public EditorPlatformData.Platform GetPlatform(Rewired.Platforms.Platform platform, WebplayerPlatform webplayerPlatform, EditorPlatform editorPlatform)
		{
			if (webplayerPlatform != WebplayerPlatform.None)
			{
				return this.webplayer;
			}
			switch (platform)
			{
			case Rewired.Platforms.Platform.Windows:
				return this.windowsStandalone;
			case Rewired.Platforms.Platform.WindowsAppStore:
				return this.windowsStore;
			case Rewired.Platforms.Platform.OSX:
				return this.osxStandalone;
			case Rewired.Platforms.Platform.Linux:
				return this.linuxStandalone;
			}
			return this.fallback;
		}

		// Token: 0x04000F9A RID: 3994
		[CustomObfuscation(rename = false)]
		public EditorPlatformData.Platform windowsStandalone;

		// Token: 0x04000F9B RID: 3995
		[CustomObfuscation(rename = false)]
		public EditorPlatformData.Platform windowsStore;

		// Token: 0x04000F9C RID: 3996
		[CustomObfuscation(rename = false)]
		public EditorPlatformData.Platform osxStandalone;

		// Token: 0x04000F9D RID: 3997
		[CustomObfuscation(rename = false)]
		public EditorPlatformData.Platform linuxStandalone;

		// Token: 0x04000F9E RID: 3998
		[CustomObfuscation(rename = false)]
		public EditorPlatformData.Platform webplayer;

		// Token: 0x04000F9F RID: 3999
		[CustomObfuscation(rename = false)]
		public EditorPlatformData.Platform fallback;

		// Token: 0x02000257 RID: 599
		[Serializable]
		public class Platform
		{
			// Token: 0x04000FA0 RID: 4000
			public TextAsset[] libraries;
		}
	}
}
