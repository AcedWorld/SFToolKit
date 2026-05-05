using System;

namespace Rewired.Utils
{
	// Token: 0x020004AF RID: 1199
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal static class PlatformTools
	{
		// Token: 0x060030B5 RID: 12469 RVA: 0x000A92EC File Offset: 0x000A74EC
		public static bool IsSysVersionInRange(string min, string max)
		{
			bool flag = !string.IsNullOrEmpty(min);
			bool flag2 = !string.IsNullOrEmpty(max);
			if (!flag && !flag2)
			{
				return true;
			}
			if (UnityTools.isAndroidPlatform)
			{
				if (flag)
				{
					try
					{
						int num = int.Parse(min);
						if (UnityTools.externalTools.GetAndroidAPILevel() < num)
						{
							return false;
						}
					}
					catch
					{
						Logger.LogError("Error parsing minimum OS version.");
					}
				}
				if (flag2)
				{
					try
					{
						int num2 = int.Parse(max);
						if (UnityTools.externalTools.GetAndroidAPILevel() > num2)
						{
							return false;
						}
					}
					catch
					{
						Logger.LogError("Error parsing maximum OS version.");
					}
					return true;
				}
				return true;
			}
			return true;
		}
	}
}
