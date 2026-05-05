using System;
using Rewired.Data;
using Rewired.Interfaces;
using Rewired.Platforms;
using Rewired.Utils;

namespace Rewired.InputManagers
{
	// Token: 0x02000007 RID: 7
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class Initializer : PlatformInitializer
	{
		// Token: 0x0600004F RID: 79 RVA: 0x000115D3 File Offset: 0x0000F7D3
		public static PlatformInitializer GetPlatformInitializer()
		{
			if (Initializer.AKLdsBiHTMrsPLEIuIwDuYkxanPHA == null)
			{
				Initializer.AKLdsBiHTMrsPLEIuIwDuYkxanPHA = new Initializer();
			}
			return Initializer.AKLdsBiHTMrsPLEIuIwDuYkxanPHA;
		}

		// Token: 0x06000050 RID: 80 RVA: 0x0001F328 File Offset: 0x0001D528
		public override object Initialize(IConfigVars_Internal configVars)
		{
			if (UnityTools.platform == Platform.Windows || UnityTools.platform == Platform.WindowsAppStore)
			{
				ConfigVars configVars2 = (ConfigVars)configVars;
				if (UnityTools.platform == Platform.Windows && configVars2.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.SDL2)
				{
					try
					{
						if (new SOdhOppsHkwNoqWKEsAKumLAEPWY(configVars2, new Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager>(ReInput.GetHardwareJoystickMap_InputManager), new Func<int>(ReInput.GetNewJoystickId), true, false, false) == null)
						{
							throw new Exception();
						}
					}
					catch
					{
						Logger.LogError("SDL2 could not be initialized! Make sure you have the SDL2 library installed. Please see the documentation for more information. Rewired will fall back to Unity input. Certain features may not be available.");
					}
					return null;
				}
				try
				{
					return new EkItUYYjGtvsdLcnstyvwdtfuVNn(configVars2, new Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager>(ReInput.GetHardwareJoystickMap_InputManager), new Func<int>(ReInput.GetNewJoystickId));
				}
				catch (Exception)
				{
					Logger.LogWarning("Rewired will fall back to Unity input. Certain features may not be available.\n");
					return null;
				}
			}
			return null;
		}

		// Token: 0x06000051 RID: 81 RVA: 0x000115EB File Offset: 0x0000F7EB
		public override IElementIdentifierTool CreateTool(string inputSourceString)
		{
			if (inputSourceString == "DirectInput")
			{
				return new pzElsceLvSicVpPEwgrJPAdtHgme();
			}
			if (inputSourceString == "RawInput")
			{
				return new JqUKKiwhYOELBracduSEHlaDBJSA();
			}
			return null;
		}

		// Token: 0x04000028 RID: 40
		internal const string initErrorMsg = "";

		// Token: 0x04000029 RID: 41
		private static PlatformInitializer AKLdsBiHTMrsPLEIuIwDuYkxanPHA;
	}
}
