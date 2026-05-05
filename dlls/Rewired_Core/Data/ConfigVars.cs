using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Config;
using Rewired.Platforms;
using Rewired.Platforms.Custom;
using Rewired.Utils;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Data;

namespace Rewired.Data
{
	// Token: 0x02000240 RID: 576
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	[Serializable]
	public sealed class ConfigVars : IConfigVars_Internal
	{
		// Token: 0x17000659 RID: 1625
		// (get) Token: 0x06001A43 RID: 6723 RVA: 0x000729C0 File Offset: 0x00070BC0
		private Dictionary<int, ConfigVars.oHaujoMelsDGsAFhGBqoddMGmvObB> platformVarsDict
		{
			get
			{
				Dictionary<int, ConfigVars.oHaujoMelsDGsAFhGBqoddMGmvObB> result;
				if ((result = this.__platformVarsDict) == null)
				{
					Dictionary<int, ConfigVars.oHaujoMelsDGsAFhGBqoddMGmvObB> dictionary = new Dictionary<int, ConfigVars.oHaujoMelsDGsAFhGBqoddMGmvObB>();
					dictionary.Add(1, new ConfigVars.oHaujoMelsDGsAFhGBqoddMGmvObB(() => this.GetOrCreatePlatformVars<ConfigVars.PlatformVars_WindowsStandalone>(ref this.platformVars_windowsStandalone), "platformVars_windowsStandalone"));
					dictionary.Add(29, new ConfigVars.oHaujoMelsDGsAFhGBqoddMGmvObB(() => this.GetOrCreatePlatformVars<ConfigVars.PlatformVars_WindowsUWP>(ref this.platformVars_windowsUWP), "platformVars_windowsUWP"));
					dictionary.Add(6, new ConfigVars.oHaujoMelsDGsAFhGBqoddMGmvObB(() => this.GetOrCreatePlatformVars<ConfigVars.PlatformVars_LinuxStandalone>(ref this.platformVars_linuxStandalone), "platformVars_linuxStandalone"));
					dictionary.Add(4, new ConfigVars.oHaujoMelsDGsAFhGBqoddMGmvObB(() => this.GetOrCreatePlatformVars<ConfigVars.PlatformVars_OSXStandalone>(ref this.platformVars_osxStandalone), "platformVars_osxStandalone"));
					dictionary.Add(5, new ConfigVars.oHaujoMelsDGsAFhGBqoddMGmvObB(() => this.GetOrCreatePlatformVars<ConfigVars.PlatformVars>(ref this.platformVars_iOS), "platformVars_iOS"));
					dictionary.Add(28, new ConfigVars.oHaujoMelsDGsAFhGBqoddMGmvObB(() => this.GetOrCreatePlatformVars<ConfigVars.PlatformVars>(ref this.platformVars_tvOS), "platformVars_tvOS"));
					dictionary.Add(13, new ConfigVars.oHaujoMelsDGsAFhGBqoddMGmvObB(() => this.GetOrCreatePlatformVars<ConfigVars.PlatformVars>(ref this.platformVars_ps4), "platformVars_ps4"));
					dictionary.Add(106, new ConfigVars.oHaujoMelsDGsAFhGBqoddMGmvObB(() => this.GetOrCreatePlatformVars<ConfigVars.PlatformVars_PS5>(ref this.platformVars_ps5), "platformVars_ps5"));
					dictionary.Add(15, new ConfigVars.oHaujoMelsDGsAFhGBqoddMGmvObB(() => this.GetOrCreatePlatformVars<ConfigVars.PlatformVars>(ref this.platformVars_psVita), "platformVars_psVita"));
					dictionary.Add(14, new ConfigVars.oHaujoMelsDGsAFhGBqoddMGmvObB(() => this.GetOrCreatePlatformVars<ConfigVars.PlatformVars>(ref this.platformVars_psVita), "platformVars_psVita"));
					dictionary.Add(32, new ConfigVars.oHaujoMelsDGsAFhGBqoddMGmvObB(() => this.GetOrCreatePlatformVars<ConfigVars.PlatformVars>(ref this.platformVars_switch), "platformVars_switch"));
					dictionary.Add(11, new ConfigVars.oHaujoMelsDGsAFhGBqoddMGmvObB(() => this.GetOrCreatePlatformVars<ConfigVars.PlatformVars>(ref this.platformVars_xboxOne), "platformVars_xboxOne"));
					dictionary.Add(104, new ConfigVars.oHaujoMelsDGsAFhGBqoddMGmvObB(() => this.GetOrCreatePlatformVars<ConfigVars.PlatformVars_GameCoreXboxOne>(ref this.platformVars_gameCoreXboxOne), "platformVars_gameCoreXboxOne"));
					dictionary.Add(105, new ConfigVars.oHaujoMelsDGsAFhGBqoddMGmvObB(() => this.GetOrCreatePlatformVars<ConfigVars.PlatformVars_GameCoreScarlett>(ref this.platformVars_gameCoreScarlett), "platformVars_gameCoreScarlett"));
					dictionary.Add(19, new ConfigVars.oHaujoMelsDGsAFhGBqoddMGmvObB(() => this.GetOrCreatePlatformVars<ConfigVars.PlatformVars>(ref this.platformVars_webGL), "platformVars_webGL"));
					dictionary.Add(7, new ConfigVars.oHaujoMelsDGsAFhGBqoddMGmvObB(() => this.GetOrCreatePlatformVars<ConfigVars.PlatformVars>(ref this.platformVars_android), "platformVars_android"));
					Dictionary<int, ConfigVars.oHaujoMelsDGsAFhGBqoddMGmvObB> dictionary2 = dictionary;
					this.__platformVarsDict = dictionary;
					result = dictionary2;
				}
				return result;
			}
		}

		// Token: 0x1700065A RID: 1626
		// (get) Token: 0x06001A44 RID: 6724 RVA: 0x00072BC4 File Offset: 0x00070DC4
		private Dictionary<int, ConfigVars.xkrWNOFqHQxqgrBDOvgPxAIhpwrP> getSetPlatformVariableDict
		{
			get
			{
				Dictionary<int, ConfigVars.xkrWNOFqHQxqgrBDOvgPxAIhpwrP> result;
				if ((result = this.__getSetPlatformVariableDict) == null)
				{
					Dictionary<int, ConfigVars.xkrWNOFqHQxqgrBDOvgPxAIhpwrP> dictionary = new Dictionary<int, ConfigVars.xkrWNOFqHQxqgrBDOvgPxAIhpwrP>();
					dictionary.Add(0, new ConfigVars.xkrWNOFqHQxqgrBDOvgPxAIhpwrP((Platform p) => this.GetPlatformVars(p).disableKeyboard, delegate(Platform platform, object value)
					{
						this.GetPlatformVars(platform).disableKeyboard = (bool)value;
					}));
					dictionary.Add(2, new ConfigVars.xkrWNOFqHQxqgrBDOvgPxAIhpwrP((Platform p) => this.GetPlatformVars(p).disableMouse, delegate(Platform platform, object value)
					{
						this.GetPlatformVars(platform).disableMouse = (bool)value;
					}));
					dictionary.Add(1, new ConfigVars.xkrWNOFqHQxqgrBDOvgPxAIhpwrP((Platform platform) => this.GetPlatformVars(platform).ignoreInputWhenAppNotInFocus, delegate(Platform platform, object value)
					{
						this.GetPlatformVars(platform).ignoreInputWhenAppNotInFocus = (bool)value;
					}));
					Dictionary<int, ConfigVars.xkrWNOFqHQxqgrBDOvgPxAIhpwrP> dictionary2 = dictionary;
					this.__getSetPlatformVariableDict = dictionary;
					result = dictionary2;
				}
				return result;
			}
		}

		// Token: 0x06001A45 RID: 6725 RVA: 0x00072C58 File Offset: 0x00070E58
		[Preserve]
		public ConfigVars()
		{
		}

		// Token: 0x06001A46 RID: 6726 RVA: 0x00072CD4 File Offset: 0x00070ED4
		internal bool DoesPlatformUseFallback(Platform platform, WebplayerPlatform webplayerPlatform, bool isEditor)
		{
			if (this.alwaysUseUnityInput)
			{
				return true;
			}
			if (!isEditor && webplayerPlatform != WebplayerPlatform.None)
			{
				return true;
			}
			if (platform <= Platform.Linux)
			{
				if (platform == Platform.Windows)
				{
					return this.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.Unity;
				}
				if (platform == Platform.OSX)
				{
					return this.osx_primaryInputSource == OSXStandalonePrimaryInputSource.Unity;
				}
				if (platform == Platform.Linux)
				{
					return this.linux_primaryInputSource == LinuxStandalonePrimaryInputSource.Unity;
				}
			}
			else if (platform <= Platform.PS4)
			{
				if (platform == Platform.XboxOne)
				{
					return this.xboxOne_primaryInputSource == XboxOnePrimaryInputSource.Unity;
				}
				if (platform == Platform.PS4)
				{
					return this.ps4_primaryInputSource == PS4PrimaryInputSource.Unity;
				}
			}
			else
			{
				if (platform == Platform.WebGL)
				{
					return this.webGL_primaryInputSource == WebGLPrimaryInputSource.Unity;
				}
				if (platform == Platform.WindowsUWP)
				{
					return this.windowsUWP_primaryInputSource == WindowsUWPPrimaryInputSource.Unity;
				}
			}
			return false;
		}

		// Token: 0x06001A47 RID: 6727 RVA: 0x00072D70 File Offset: 0x00070F70
		internal string GetDebugConfigSettings()
		{
			string text = "";
			Platform platform = UnityTools.platform;
			if (platform <= Platform.XboxOne)
			{
				if (platform <= Platform.OSX)
				{
					if (platform != Platform.Windows)
					{
						if (platform == Platform.OSX)
						{
							text = text + "Primary input source: " + this.osx_primaryInputSource.ToString() + "\n";
						}
					}
					else
					{
						text = text + "Primary input source: " + this.windowsStandalonePrimaryInputSource.ToString() + "\n";
						text = text + "Use XInput: " + this.useXInput.ToString() + "\n";
					}
				}
				else if (platform != Platform.Linux)
				{
					if (platform == Platform.XboxOne)
					{
						text = text + "Primary input source: " + this.xboxOne_primaryInputSource.ToString() + "\n";
					}
				}
				else
				{
					text = text + "Primary input source: " + this.linux_primaryInputSource.ToString() + "\n";
				}
			}
			else if (platform <= Platform.WebGL)
			{
				if (platform != Platform.PS4)
				{
					if (platform == Platform.WebGL)
					{
						text = text + "Primary input source: " + this.webGL_primaryInputSource.ToString() + "\n";
					}
				}
				else
				{
					text = text + "Primary input source: " + this.ps4_primaryInputSource.ToString() + "\n";
				}
			}
			else if (platform != Platform.WindowsUWP)
			{
				switch (platform)
				{
				case Platform.GameCoreXboxOne:
					text = text + "Primary input source: " + this.gameCoreXboxOne_primaryInputSource.ToString() + "\n";
					break;
				case Platform.GameCoreScarlett:
					text = text + "Primary input source: " + this.gameCoreScarlett_primaryInputSource.ToString() + "\n";
					break;
				case Platform.PS5:
					text = text + "Primary input source: " + this.ps5_primaryInputSource.ToString() + "\n";
					break;
				}
			}
			else
			{
				text = text + "Primary input source: " + this.windowsUWP_primaryInputSource.ToString() + "\n";
			}
			text = text + "Native mouse handling: " + this.GetPlatformVar_useNativeMouse().ToString() + "\n";
			text = text + "Enhanced device support: " + this.GetPlatformVar_useEnhancedDeviceSupport().ToString() + "\n";
			if (UnityTools.isAndroidPlatform)
			{
				text = text + "Android: Support Unknown Gamepads: " + this.android_supportUnknownGamepads.ToString() + "\n";
			}
			return text;
		}

		// Token: 0x06001A48 RID: 6728 RVA: 0x00015700 File Offset: 0x00013900
		[CustomObfuscation(rename = false)]
		internal string GetPlatformVarsRelPath(Platform platform)
		{
			if (this.platformVarsDict.ContainsKey((int)platform))
			{
				return this.platformVarsDict[(int)platform].tVgSJMfkfXOqxIlRGDhGgmToCdODb;
			}
			throw new NotImplementedException();
		}

		// Token: 0x06001A49 RID: 6729 RVA: 0x00072FE8 File Offset: 0x000711E8
		[CustomObfuscation(rename = false)]
		internal ConfigVars.PlatformVars GetPlatformVars(Platform platform)
		{
			ConfigVars.PlatformVars platformVars;
			if (platform == Platform.Custom && xApfUAgfQcPgXcXdmaKvwTZGIoxYA.GXntXWfLzMLrGpDuLwjFcqKwikHHA)
			{
				platformVars = xApfUAgfQcPgXcXdmaKvwTZGIoxYA.fhPwoQDVaCrGxJIrWVnEEYfkeXpd();
			}
			else if (this.platformVarsDict.ContainsKey((int)platform))
			{
				platformVars = this.platformVarsDict[(int)platform].zWtRhCfwaYdEKXLSUSvYOvkpruNF();
			}
			else
			{
				platformVars = this.GetOrCreatePlatformVars<ConfigVars.PlatformVars>(ref this.platformVars_unknown);
			}
			if (platformVars == null)
			{
				platformVars = new ConfigVars.PlatformVars();
			}
			return platformVars;
		}

		// Token: 0x06001A4A RID: 6730 RVA: 0x00015727 File Offset: 0x00013927
		[CustomObfuscation(rename = false)]
		internal T Editor_GetAllSerializedPlatformVar<T>(ConfigVars.AllPlatformVar var)
		{
			if (typeof(T) == typeof(MultiBoolValue))
			{
				return (T)((object)this.GetAllSerializedPlatformVar_multiBool(var));
			}
			throw new NotImplementedException();
		}

		// Token: 0x06001A4B RID: 6731 RVA: 0x0007304C File Offset: 0x0007124C
		[CustomObfuscation(rename = false)]
		internal void Editor_SetAllSerializedPlatformVar(ConfigVars.AllPlatformVar var, object value)
		{
			foreach (KeyValuePair<int, ConfigVars.oHaujoMelsDGsAFhGBqoddMGmvObB> keyValuePair in this.platformVarsDict)
			{
				if (this.getSetPlatformVariableDict.ContainsKey((int)var))
				{
					this.getSetPlatformVariableDict[(int)var].NgNkjDthobzGslcoqIXMcUYCyFic((Platform)keyValuePair.Key, value);
				}
			}
		}

		// Token: 0x06001A4C RID: 6732 RVA: 0x00015756 File Offset: 0x00013956
		internal bool GetPlatformVar_disableKeyboard()
		{
			return this.GetPlatformVars().disableKeyboard;
		}

		// Token: 0x06001A4D RID: 6733 RVA: 0x000730C4 File Offset: 0x000712C4
		internal bool SetPlatformVar_disableKeyboard(bool value)
		{
			this.GetPlatformVars().disableKeyboard = value;
			return value;
		}

		// Token: 0x06001A4E RID: 6734 RVA: 0x00015763 File Offset: 0x00013963
		internal bool GetPlatformVar_disableMouse()
		{
			return this.GetPlatformVars().disableMouse;
		}

		// Token: 0x06001A4F RID: 6735 RVA: 0x000730E0 File Offset: 0x000712E0
		internal bool SetPlatformVar_disableMouse(bool value)
		{
			this.GetPlatformVars().disableMouse = value;
			return value;
		}

		// Token: 0x06001A50 RID: 6736 RVA: 0x00015770 File Offset: 0x00013970
		internal bool GetPlatformVar_ignoreInputWhenAppNotInFocus()
		{
			return this.GetPlatformVars().ignoreInputWhenAppNotInFocus;
		}

		// Token: 0x06001A51 RID: 6737 RVA: 0x000730FC File Offset: 0x000712FC
		internal bool GetPlatformVar_useEnhancedDeviceSupport()
		{
			Platform effectivePlatform = UnityTools.effectivePlatform;
			ConfigVars.PlatformVars platformVars = this.GetPlatformVars(effectivePlatform);
			if (effectivePlatform == Platform.Windows)
			{
				return this.useEnhancedDeviceSupport;
			}
			if (effectivePlatform != Platform.OSX)
			{
				return effectivePlatform == Platform.Linux && platformVars is ConfigVars.PlatformVars_LinuxStandalone && (platformVars as ConfigVars.PlatformVars_LinuxStandalone).useEnhancedDeviceSupport;
			}
			return this.osxStandalone_useEnhancedDeviceSupport;
		}

		// Token: 0x06001A52 RID: 6738 RVA: 0x0007314C File Offset: 0x0007134C
		internal bool GetPlatformVar_useNativeMouse()
		{
			Platform effectivePlatform = UnityTools.effectivePlatform;
			ConfigVars.PlatformVars platformVars = this.GetPlatformVars(effectivePlatform);
			if (platformVars == null)
			{
				return false;
			}
			if (effectivePlatform != Platform.Windows)
			{
				return effectivePlatform == Platform.Custom && (!(platformVars is CustomPlatformConfigVars) || (platformVars as CustomPlatformConfigVars).useNativeMouse);
			}
			return this.useNativeMouse;
		}

		// Token: 0x06001A53 RID: 6739 RVA: 0x00073198 File Offset: 0x00071398
		internal bool GetPlatformVar_useNativeKeyboard()
		{
			Platform effectivePlatform = UnityTools.effectivePlatform;
			if (!ConfigVars.IsNativeKeyboardAllowed(effectivePlatform, this.unityUsePhysicalKeys))
			{
				return false;
			}
			ConfigVars.PlatformVars platformVars = this.GetPlatformVars(effectivePlatform);
			if (platformVars == null)
			{
				return false;
			}
			if (effectivePlatform != Platform.Windows)
			{
				return effectivePlatform == Platform.Custom && (!(platformVars is CustomPlatformConfigVars) || (platformVars as CustomPlatformConfigVars).useNativeKeyboard);
			}
			return !(platformVars is ConfigVars.PlatformVars_WindowsStandalone) || (platformVars as ConfigVars.PlatformVars_WindowsStandalone).useNativeKeyboard;
		}

		// Token: 0x06001A54 RID: 6740 RVA: 0x00073204 File Offset: 0x00071404
		internal int GetPlatformVar_joystickRefreshRate()
		{
			Platform effectivePlatform = UnityTools.effectivePlatform;
			ConfigVars.PlatformVars platformVars = this.GetPlatformVars(effectivePlatform);
			if (platformVars == null)
			{
				return 240;
			}
			if (effectivePlatform != Platform.Windows)
			{
				return 240;
			}
			if (!(platformVars is ConfigVars.PlatformVars_WindowsStandalone))
			{
				return 240;
			}
			return (platformVars as ConfigVars.PlatformVars_WindowsStandalone).joystickRefreshRate;
		}

		// Token: 0x06001A55 RID: 6741 RVA: 0x0007324C File Offset: 0x0007144C
		internal bool GetPlatformVar_assignJoysticksBySystemId()
		{
			Platform effectivePlatform = UnityTools.effectivePlatform;
			ConfigVars.PlatformVars platformVars = this.GetPlatformVars(effectivePlatform);
			if (platformVars == null)
			{
				return false;
			}
			if (effectivePlatform == Platform.OSX)
			{
				return platformVars is ConfigVars.PlatformVars_OSXStandalone && (platformVars as ConfigVars.PlatformVars_OSXStandalone).assignJoysticksByUserId;
			}
			if (effectivePlatform == Platform.PS4)
			{
				return this.ps4_assignJoysticksByPS4JoyId;
			}
			switch (effectivePlatform)
			{
			case Platform.GameCoreXboxOne:
				return platformVars is ConfigVars.PlatformVars_GameCoreXboxOne && (platformVars as ConfigVars.PlatformVars_GameCoreXboxOne).assignJoysticksByUserId;
			case Platform.GameCoreScarlett:
				return platformVars is ConfigVars.PlatformVars_GameCoreScarlett && (platformVars as ConfigVars.PlatformVars_GameCoreScarlett).assignJoysticksByUserId;
			case Platform.PS5:
				return platformVars is ConfigVars.PlatformVars_PS5 && (platformVars as ConfigVars.PlatformVars_PS5).assignJoysticksByPS5JoyId;
			default:
				return false;
			}
		}

		// Token: 0x06001A56 RID: 6742 RVA: 0x000732EC File Offset: 0x000714EC
		internal bool GetPlatformVar_useAppleGameController()
		{
			Platform effectivePlatform = UnityTools.effectivePlatform;
			ConfigVars.PlatformVars platformVars = this.GetPlatformVars(effectivePlatform);
			return platformVars != null && effectivePlatform == Platform.OSX && platformVars is ConfigVars.PlatformVars_OSXStandalone && (platformVars as ConfigVars.PlatformVars_OSXStandalone).useAppleGameController;
		}

		// Token: 0x06001A57 RID: 6743 RVA: 0x00073328 File Offset: 0x00071528
		internal bool GetPlatformVar_useWindowsGamingInput()
		{
			Platform effectivePlatform = UnityTools.effectivePlatform;
			ConfigVars.PlatformVars platformVars = this.GetPlatformVars(effectivePlatform);
			return platformVars != null && effectivePlatform == Platform.Windows && platformVars is ConfigVars.PlatformVars_WindowsStandalone && (platformVars as ConfigVars.PlatformVars_WindowsStandalone).useWindowsGamingInput;
		}

		// Token: 0x06001A58 RID: 6744 RVA: 0x00073364 File Offset: 0x00071564
		internal IList<EnhancedDeviceSupportDeviceType> GetPlatformVar_enhancedDeviceSupportExcludedDeviceTypes()
		{
			Platform effectivePlatform = UnityTools.effectivePlatform;
			ConfigVars.PlatformVars platformVars = this.GetPlatformVars(effectivePlatform);
			if (platformVars == null)
			{
				return EmptyObjects<EnhancedDeviceSupportDeviceType>.EmptyReadOnlyIListT;
			}
			List<EnhancedDeviceSupportDeviceType> list = null;
			if (effectivePlatform != Platform.Windows)
			{
				if (effectivePlatform != Platform.OSX)
				{
					if (effectivePlatform == Platform.Linux)
					{
						if (platformVars is ConfigVars.PlatformVars_LinuxStandalone)
						{
							list = (platformVars as ConfigVars.PlatformVars_LinuxStandalone).enhancedDeviceSupportExcludedDeviceTypes;
						}
					}
				}
				else if (platformVars is ConfigVars.PlatformVars_OSXStandalone)
				{
					list = (platformVars as ConfigVars.PlatformVars_OSXStandalone).enhancedDeviceSupportExcludedDeviceTypes;
				}
			}
			else if (platformVars is ConfigVars.PlatformVars_WindowsStandalone)
			{
				list = (platformVars as ConfigVars.PlatformVars_WindowsStandalone).enhancedDeviceSupportExcludedDeviceTypes;
			}
			if (list != null)
			{
				return new ReadOnlyCollection<EnhancedDeviceSupportDeviceType>(list);
			}
			return EmptyObjects<EnhancedDeviceSupportDeviceType>.EmptyReadOnlyIListT;
		}

		// Token: 0x06001A59 RID: 6745 RVA: 0x0001577D File Offset: 0x0001397D
		internal bool SetPlatformVar_ignoreInputWhenAppNotInFocus(bool value)
		{
			if (this.GetPlatformVars().ignoreInputWhenAppNotInFocus == value)
			{
				return false;
			}
			this.GetPlatformVars().ignoreInputWhenAppNotInFocus = value;
			return true;
		}

		// Token: 0x06001A5A RID: 6746 RVA: 0x000733E8 File Offset: 0x000715E8
		internal bool SetPlatformVar_useEnhancedDeviceSupport(bool value)
		{
			Platform effectivePlatform = UnityTools.effectivePlatform;
			ConfigVars.PlatformVars platformVars = this.GetPlatformVars(effectivePlatform);
			if (effectivePlatform != Platform.Windows)
			{
				if (effectivePlatform != Platform.OSX)
				{
					if (effectivePlatform != Platform.Linux)
					{
						return false;
					}
					if (platformVars is ConfigVars.PlatformVars_LinuxStandalone)
					{
						(platformVars as ConfigVars.PlatformVars_LinuxStandalone).useEnhancedDeviceSupport = value;
					}
					return true;
				}
				else
				{
					if (this.osxStandalone_useEnhancedDeviceSupport == value)
					{
						return false;
					}
					this.osxStandalone_useEnhancedDeviceSupport = value;
					return true;
				}
			}
			else
			{
				if (this.useEnhancedDeviceSupport == value)
				{
					return false;
				}
				this.useEnhancedDeviceSupport = value;
				return true;
			}
		}

		// Token: 0x06001A5B RID: 6747 RVA: 0x00073450 File Offset: 0x00071650
		internal bool SetPlatformVar_useNativeMouse(bool value)
		{
			Platform effectivePlatform = UnityTools.effectivePlatform;
			if (effectivePlatform != Platform.Windows)
			{
				if (effectivePlatform != Platform.Custom)
				{
					return false;
				}
				if (xApfUAgfQcPgXcXdmaKvwTZGIoxYA.GXntXWfLzMLrGpDuLwjFcqKwikHHA)
				{
					xApfUAgfQcPgXcXdmaKvwTZGIoxYA.fhPwoQDVaCrGxJIrWVnEEYfkeXpd().useNativeMouse = value;
					return true;
				}
				return false;
			}
			else
			{
				if (this.useNativeMouse == value)
				{
					return false;
				}
				this.useNativeMouse = value;
				return true;
			}
		}

		// Token: 0x06001A5C RID: 6748 RVA: 0x0007349C File Offset: 0x0007169C
		internal bool SetPlatformVar_useNativeKeyboard(bool value)
		{
			Platform effectivePlatform = UnityTools.effectivePlatform;
			if (!ConfigVars.IsNativeKeyboardAllowed(effectivePlatform, this.unityUsePhysicalKeys))
			{
				return false;
			}
			ConfigVars.PlatformVars platformVars = this.GetPlatformVars(effectivePlatform);
			if (platformVars == null)
			{
				return false;
			}
			if (effectivePlatform == Platform.Windows)
			{
				if (platformVars is ConfigVars.PlatformVars_WindowsStandalone)
				{
					(platformVars as ConfigVars.PlatformVars_WindowsStandalone).useNativeKeyboard = value;
				}
				return true;
			}
			if (effectivePlatform != Platform.Custom)
			{
				return false;
			}
			if (xApfUAgfQcPgXcXdmaKvwTZGIoxYA.GXntXWfLzMLrGpDuLwjFcqKwikHHA)
			{
				xApfUAgfQcPgXcXdmaKvwTZGIoxYA.fhPwoQDVaCrGxJIrWVnEEYfkeXpd().useNativeKeyboard = value;
				return true;
			}
			return false;
		}

		// Token: 0x06001A5D RID: 6749 RVA: 0x00073508 File Offset: 0x00071708
		internal bool SetPlatformVar_joystickRefreshRate(int value)
		{
			Platform effectivePlatform = UnityTools.effectivePlatform;
			ConfigVars.PlatformVars platformVars = this.GetPlatformVars(effectivePlatform);
			if (platformVars == null)
			{
				return false;
			}
			if (effectivePlatform == Platform.Windows)
			{
				if (platformVars is ConfigVars.PlatformVars_WindowsStandalone)
				{
					(platformVars as ConfigVars.PlatformVars_WindowsStandalone).joystickRefreshRate = value;
				}
				return true;
			}
			return false;
		}

		// Token: 0x06001A5E RID: 6750 RVA: 0x00073544 File Offset: 0x00071744
		internal bool SetPlatformVar_assignJoysticksBySystemId(bool value)
		{
			Platform effectivePlatform = UnityTools.effectivePlatform;
			ConfigVars.PlatformVars platformVars = this.GetPlatformVars(effectivePlatform);
			if (platformVars == null)
			{
				return false;
			}
			if (effectivePlatform == Platform.OSX)
			{
				if (platformVars is ConfigVars.PlatformVars_OSXStandalone)
				{
					(platformVars as ConfigVars.PlatformVars_OSXStandalone).assignJoysticksByUserId = value;
				}
				return true;
			}
			if (effectivePlatform == Platform.PS4)
			{
				this.ps4_assignJoysticksByPS4JoyId = value;
				return true;
			}
			switch (effectivePlatform)
			{
			case Platform.GameCoreXboxOne:
				if (platformVars is ConfigVars.PlatformVars_GameCoreXboxOne)
				{
					(platformVars as ConfigVars.PlatformVars_GameCoreXboxOne).assignJoysticksByUserId = value;
				}
				return false;
			case Platform.GameCoreScarlett:
				if (platformVars is ConfigVars.PlatformVars_GameCoreScarlett)
				{
					(platformVars as ConfigVars.PlatformVars_GameCoreScarlett).assignJoysticksByUserId = value;
				}
				return true;
			case Platform.PS5:
				if (platformVars is ConfigVars.PlatformVars_PS5)
				{
					(platformVars as ConfigVars.PlatformVars_PS5).assignJoysticksByPS5JoyId = value;
				}
				return true;
			default:
				return false;
			}
		}

		// Token: 0x06001A5F RID: 6751 RVA: 0x000735E8 File Offset: 0x000717E8
		internal bool SetPlatformVar_useAppleGameController(bool value)
		{
			Platform effectivePlatform = UnityTools.effectivePlatform;
			ConfigVars.PlatformVars platformVars = this.GetPlatformVars(effectivePlatform);
			if (platformVars == null)
			{
				return false;
			}
			if (effectivePlatform == Platform.OSX)
			{
				if (platformVars is ConfigVars.PlatformVars_OSXStandalone)
				{
					(platformVars as ConfigVars.PlatformVars_OSXStandalone).useAppleGameController = value;
				}
				return true;
			}
			return false;
		}

		// Token: 0x06001A60 RID: 6752 RVA: 0x00073624 File Offset: 0x00071824
		internal bool SetPlatformVar_useWindowsGamingInput(bool value)
		{
			Platform effectivePlatform = UnityTools.effectivePlatform;
			ConfigVars.PlatformVars platformVars = this.GetPlatformVars(effectivePlatform);
			if (platformVars == null)
			{
				return false;
			}
			if (effectivePlatform == Platform.Windows)
			{
				if (platformVars is ConfigVars.PlatformVars_WindowsStandalone)
				{
					(platformVars as ConfigVars.PlatformVars_WindowsStandalone).useWindowsGamingInput = value;
				}
				return true;
			}
			return false;
		}

		// Token: 0x06001A61 RID: 6753 RVA: 0x00073660 File Offset: 0x00071860
		internal bool SetPlatformVar_enhancedDeviceSupportExcludedDeviceTypes(IList<EnhancedDeviceSupportDeviceType> value)
		{
			Platform effectivePlatform = UnityTools.effectivePlatform;
			ConfigVars.PlatformVars platformVars = this.GetPlatformVars(effectivePlatform);
			if (platformVars == null)
			{
				return false;
			}
			if (effectivePlatform == Platform.Windows)
			{
				if (platformVars is ConfigVars.PlatformVars_WindowsStandalone)
				{
					(platformVars as ConfigVars.PlatformVars_WindowsStandalone).enhancedDeviceSupportExcludedDeviceTypes = ((value != null) ? new List<EnhancedDeviceSupportDeviceType>(value) : new List<EnhancedDeviceSupportDeviceType>());
				}
				return true;
			}
			if (effectivePlatform == Platform.OSX)
			{
				if (platformVars is ConfigVars.PlatformVars_OSXStandalone)
				{
					(platformVars as ConfigVars.PlatformVars_OSXStandalone).enhancedDeviceSupportExcludedDeviceTypes = ((value != null) ? new List<EnhancedDeviceSupportDeviceType>(value) : new List<EnhancedDeviceSupportDeviceType>());
				}
				return true;
			}
			if (effectivePlatform != Platform.Linux)
			{
				return false;
			}
			if (platformVars is ConfigVars.PlatformVars_LinuxStandalone)
			{
				(platformVars as ConfigVars.PlatformVars_LinuxStandalone).enhancedDeviceSupportExcludedDeviceTypes = ((value != null) ? new List<EnhancedDeviceSupportDeviceType>(value) : new List<EnhancedDeviceSupportDeviceType>());
			}
			return true;
		}

		// Token: 0x06001A62 RID: 6754 RVA: 0x00073700 File Offset: 0x00071900
		private ConfigVars.PlatformVars GetPlatformVars()
		{
			Platform platform = UnityTools.effectivePlatform;
			if (!UnityTools.isEditor && UnityTools.isAndroidPlatform)
			{
				platform = Platform.Android;
			}
			return this.GetPlatformVars(platform);
		}

		// Token: 0x06001A63 RID: 6755 RVA: 0x0001579C File Offset: 0x0001399C
		private T GetOrCreatePlatformVars<T>(ref T var) where T : ConfigVars.PlatformVars, new()
		{
			if (var == null)
			{
				var = Activator.CreateInstance<T>();
			}
			return var;
		}

		// Token: 0x06001A64 RID: 6756 RVA: 0x0007372C File Offset: 0x0007192C
		private MultiBoolValue GetAllSerializedPlatformVar_multiBool(ConfigVars.AllPlatformVar var)
		{
			bool flag = false;
			bool flag2 = true;
			foreach (KeyValuePair<int, ConfigVars.oHaujoMelsDGsAFhGBqoddMGmvObB> keyValuePair in this.platformVarsDict)
			{
				if (this.getSetPlatformVariableDict.ContainsKey((int)var))
				{
					object obj = this.getSetPlatformVariableDict[(int)var].JbpEoCgQnOIeSYRQobNUBQQiWSOqB((Platform)keyValuePair.Key);
					if (obj != null)
					{
						if (obj.GetType() != typeof(bool))
						{
							Logger.LogWarning("Incorrect type. Expecting bool, got " + obj.GetType().Name);
						}
						else
						{
							bool flag3 = (bool)obj;
							if (flag2)
							{
								flag = flag3;
								flag2 = false;
							}
							else if (flag3 != flag)
							{
								return MultiBoolValue.Mixed;
							}
						}
					}
				}
			}
			if (!flag)
			{
				return MultiBoolValue.Off;
			}
			return MultiBoolValue.On;
		}

		// Token: 0x06001A65 RID: 6757 RVA: 0x0007380C File Offset: 0x00071A0C
		internal bool IsEditModeInputSupported(ControllerType controllerType, EditorPlatform editorPlatform)
		{
			if (this.alwaysUseUnityInput)
			{
				return false;
			}
			if (controllerType == ControllerType.Keyboard || controllerType == ControllerType.Mouse)
			{
				switch (editorPlatform)
				{
				case EditorPlatform.OSX:
				case EditorPlatform.Linux:
					return false;
				case EditorPlatform.Windows:
					if (this.windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.RawInput && this.windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.DirectInput && this.windowsStandalonePrimaryInputSource != WindowsStandalonePrimaryInputSource.XInput)
					{
						return false;
					}
					if (controllerType != ControllerType.Keyboard)
					{
						return this.useNativeMouse;
					}
					return this.platformVars_windowsStandalone.useNativeKeyboard;
				default:
					return false;
				}
			}
			else
			{
				if (controllerType != ControllerType.Joystick)
				{
					return false;
				}
				switch (editorPlatform)
				{
				case EditorPlatform.OSX:
					return this.osx_primaryInputSource == OSXStandalonePrimaryInputSource.Native || this.osx_primaryInputSource == OSXStandalonePrimaryInputSource.GameController || this.osx_primaryInputSource == OSXStandalonePrimaryInputSource.SDL2;
				case EditorPlatform.Windows:
					return this.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.RawInput || this.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.DirectInput || this.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.XInput || this.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.SDL2;
				case EditorPlatform.Linux:
					return this.linux_primaryInputSource == LinuxStandalonePrimaryInputSource.Native || this.linux_primaryInputSource == LinuxStandalonePrimaryInputSource.SDL2;
				default:
					return false;
				}
			}
		}

		// Token: 0x06001A66 RID: 6758 RVA: 0x000157BC File Offset: 0x000139BC
		private static bool IsNativeKeyboardAllowed(Platform platform, bool unityUsePhysicalKeys)
		{
			return platform == Platform.Custom || !unityUsePhysicalKeys;
		}

		// Token: 0x1700065B RID: 1627
		// (get) Token: 0x06001A67 RID: 6759 RVA: 0x000157D0 File Offset: 0x000139D0
		KeyedGetSetValueStore<string> IConfigVars_Internal.values
		{
			get
			{
				if (this.__configVarsValues == null)
				{
					this.__configVarsValues = new KeyedGetSetValueStore<string>(this.valueDelegates, true);
				}
				return this.__configVarsValues;
			}
		}

		// Token: 0x1700065C RID: 1628
		// (get) Token: 0x06001A68 RID: 6760 RVA: 0x000738F0 File Offset: 0x00071AF0
		private Dictionary<string, object> valueDelegates
		{
			get
			{
				if (this.__valueDelegates == null)
				{
					this.__valueDelegates = new Dictionary<string, object>
					{
						{
							"updateLoop",
							new GetSetValue<UpdateLoopSetting>(() => this.updateLoop, delegate(UpdateLoopSetting x)
							{
								this.updateLoop = x;
							})
						},
						{
							"alwaysUseUnityInput",
							new GetSetValue<bool>(() => this.alwaysUseUnityInput, delegate(bool x)
							{
								this.alwaysUseUnityInput = x;
							})
						},
						{
							"windowsStandalonePrimaryInputSource",
							new GetSetValue<WindowsStandalonePrimaryInputSource>(() => this.windowsStandalonePrimaryInputSource, delegate(WindowsStandalonePrimaryInputSource x)
							{
								this.windowsStandalonePrimaryInputSource = x;
							})
						},
						{
							"osx_primaryInputSource",
							new GetSetValue<OSXStandalonePrimaryInputSource>(() => this.osx_primaryInputSource, delegate(OSXStandalonePrimaryInputSource x)
							{
								this.osx_primaryInputSource = x;
							})
						},
						{
							"linux_primaryInputSource",
							new GetSetValue<LinuxStandalonePrimaryInputSource>(() => this.linux_primaryInputSource, delegate(LinuxStandalonePrimaryInputSource x)
							{
								this.linux_primaryInputSource = x;
							})
						},
						{
							"windowsUWP_primaryInputSource",
							new GetSetValue<WindowsUWPPrimaryInputSource>(() => this.windowsUWP_primaryInputSource, delegate(WindowsUWPPrimaryInputSource x)
							{
								this.windowsUWP_primaryInputSource = x;
							})
						},
						{
							"xboxOne_primaryInputSource",
							new GetSetValue<XboxOnePrimaryInputSource>(() => this.xboxOne_primaryInputSource, delegate(XboxOnePrimaryInputSource x)
							{
								this.xboxOne_primaryInputSource = x;
							})
						},
						{
							"gameCoreXboxOne_primaryInputSource",
							new GetSetValue<GameCoreXboxOnePrimaryInputSource>(() => this.gameCoreXboxOne_primaryInputSource, delegate(GameCoreXboxOnePrimaryInputSource x)
							{
								this.gameCoreXboxOne_primaryInputSource = x;
							})
						},
						{
							"gameCoreScarlett_primaryInputSource",
							new GetSetValue<GameCoreScarlettPrimaryInputSource>(() => this.gameCoreScarlett_primaryInputSource, delegate(GameCoreScarlettPrimaryInputSource x)
							{
								this.gameCoreScarlett_primaryInputSource = x;
							})
						},
						{
							"ps4_primaryInputSource",
							new GetSetValue<PS4PrimaryInputSource>(() => this.ps4_primaryInputSource, delegate(PS4PrimaryInputSource x)
							{
								this.ps4_primaryInputSource = x;
							})
						},
						{
							"ps5_primaryInputSource",
							new GetSetValue<PS5PrimaryInputSource>(() => this.ps5_primaryInputSource, delegate(PS5PrimaryInputSource x)
							{
								this.ps5_primaryInputSource = x;
							})
						},
						{
							"webGL_primaryInputSource",
							new GetSetValue<WebGLPrimaryInputSource>(() => this.webGL_primaryInputSource, delegate(WebGLPrimaryInputSource x)
							{
								this.webGL_primaryInputSource = x;
							})
						},
						{
							"useXInput",
							new GetSetValue<bool>(() => this.useXInput, delegate(bool x)
							{
								this.useXInput = x;
							})
						},
						{
							"osxStandalone_useEnhancedDeviceSupport",
							new GetSetValue<bool>(() => this.osxStandalone_useEnhancedDeviceSupport, delegate(bool x)
							{
								this.osxStandalone_useEnhancedDeviceSupport = x;
							})
						},
						{
							"android_supportUnknownGamepads",
							new GetSetValue<bool>(() => this.android_supportUnknownGamepads, delegate(bool x)
							{
								this.android_supportUnknownGamepads = x;
							})
						},
						{
							"ps4_assignJoysticksByPS4JoyId",
							new GetSetValue<bool>(() => this.ps4_assignJoysticksByPS4JoyId, delegate(bool x)
							{
								this.ps4_assignJoysticksByPS4JoyId = x;
							})
						},
						{
							"useSteamControllerSupport",
							new GetSetValue<bool>(() => this.useSteamControllerSupport, delegate(bool x)
							{
								this.useSteamControllerSupport = x;
							})
						},
						{
							"logToScreen",
							new GetSetValue<bool>(() => this.logToScreen, delegate(bool x)
							{
								this.logToScreen = x;
							})
						},
						{
							"runInEditMode",
							new GetSetValue<bool>(() => this.runInEditMode, delegate(bool x)
							{
								this.runInEditMode = x;
							})
						},
						{
							"allowInputInEditorSceneView",
							new GetSetValue<bool>(() => this.allowInputInEditorSceneView, delegate(bool x)
							{
								this.allowInputInEditorSceneView = x;
							})
						},
						{
							"maxJoysticksPerPlayer",
							new GetSetValue<int>(() => this.maxJoysticksPerPlayer, delegate(int x)
							{
								this.maxJoysticksPerPlayer = x;
							})
						},
						{
							"autoAssignJoysticks",
							new GetSetValue<bool>(() => this.autoAssignJoysticks, delegate(bool x)
							{
								this.autoAssignJoysticks = x;
							})
						},
						{
							"assignJoysticksToPlayingPlayersOnly",
							new GetSetValue<bool>(() => this.assignJoysticksToPlayingPlayersOnly, delegate(bool x)
							{
								this.assignJoysticksToPlayingPlayersOnly = x;
							})
						},
						{
							"distributeJoysticksEvenly",
							new GetSetValue<bool>(() => this.distributeJoysticksEvenly, delegate(bool x)
							{
								this.distributeJoysticksEvenly = x;
							})
						},
						{
							"reassignJoystickToPreviousOwnerOnReconnect",
							new GetSetValue<bool>(() => this.reassignJoystickToPreviousOwnerOnReconnect, delegate(bool x)
							{
								this.reassignJoystickToPreviousOwnerOnReconnect = x;
							})
						},
						{
							"defaultJoystickAxis2DDeadZoneType",
							new GetSetValue<DeadZone2DType>(() => this.defaultJoystickAxis2DDeadZoneType, delegate(DeadZone2DType x)
							{
								this.defaultJoystickAxis2DDeadZoneType = x;
							})
						},
						{
							"defaultJoystickAxis2DSensitivityType",
							new GetSetValue<AxisSensitivity2DType>(() => this.defaultJoystickAxis2DSensitivityType, delegate(AxisSensitivity2DType x)
							{
								this.defaultJoystickAxis2DSensitivityType = x;
							})
						},
						{
							"defaultAxisSensitivityType",
							new GetSetValue<AxisSensitivityType>(() => this.defaultAxisSensitivityType, delegate(AxisSensitivityType x)
							{
								this.defaultAxisSensitivityType = x;
							})
						},
						{
							"force4WayHats",
							new GetSetValue<bool>(() => this.force4WayHats, delegate(bool x)
							{
								this.force4WayHats = x;
							})
						},
						{
							"throttleCalibrationMode",
							new GetSetValue<ThrottleCalibrationMode>(() => this.throttleCalibrationMode, delegate(ThrottleCalibrationMode x)
							{
								this.throttleCalibrationMode = x;
							})
						},
						{
							"activateActionButtonsOnNegativeValue",
							new GetSetValue<bool>(() => this.activateActionButtonsOnNegativeValue, delegate(bool x)
							{
								this.activateActionButtonsOnNegativeValue = x;
							})
						},
						{
							"deferControllerConnectedEventsOnStart",
							new GetSetValue<bool>(() => this.deferControllerConnectedEventsOnStart, delegate(bool x)
							{
								this.deferControllerConnectedEventsOnStart = x;
							})
						},
						{
							"logLevel",
							new GetSetValue<LogLevelFlags>(() => this.logLevel, delegate(LogLevelFlags x)
							{
								this.logLevel = x;
							})
						},
						{
							"disableKeyboard",
							new GetSetValue<bool>(() => this.GetPlatformVar_disableKeyboard(), delegate(bool x)
							{
								this.SetPlatformVar_disableKeyboard(x);
							})
						},
						{
							"disableMouse",
							new GetSetValue<bool>(() => this.GetPlatformVar_disableMouse(), delegate(bool x)
							{
								this.SetPlatformVar_disableMouse(x);
							})
						},
						{
							"ignoreInputWhenAppNotInFocus",
							new GetSetValue<bool>(() => this.GetPlatformVar_ignoreInputWhenAppNotInFocus(), delegate(bool x)
							{
								this.SetPlatformVar_ignoreInputWhenAppNotInFocus(x);
							})
						},
						{
							"useEnhancedDeviceSupport",
							new GetSetValue<bool>(() => this.GetPlatformVar_useEnhancedDeviceSupport(), delegate(bool x)
							{
								this.SetPlatformVar_useEnhancedDeviceSupport(x);
							})
						},
						{
							"useNativeMouse",
							new GetSetValue<bool>(() => this.GetPlatformVar_useNativeMouse(), delegate(bool x)
							{
								this.SetPlatformVar_useNativeMouse(x);
							})
						},
						{
							"useNativeKeyboard",
							new GetSetValue<bool>(() => this.GetPlatformVar_useNativeKeyboard(), delegate(bool x)
							{
								this.SetPlatformVar_useNativeKeyboard(x);
							})
						},
						{
							"joystickRefreshRate",
							new GetSetValue<int>(() => this.GetPlatformVar_joystickRefreshRate(), delegate(int x)
							{
								this.SetPlatformVar_joystickRefreshRate(x);
							})
						},
						{
							"assignJoysticksBySystemId",
							new GetSetValue<bool>(() => this.GetPlatformVar_assignJoysticksBySystemId(), delegate(bool x)
							{
								this.SetPlatformVar_assignJoysticksBySystemId(x);
							})
						}
					};
				}
				return this.__valueDelegates;
			}
		}

		// Token: 0x04000ED9 RID: 3801
		public UpdateMode updateMode;

		// Token: 0x04000EDA RID: 3802
		public UpdateLoopSetting updateLoop = UpdateLoopSetting.Update;

		// Token: 0x04000EDB RID: 3803
		public bool alwaysUseUnityInput;

		// Token: 0x04000EDC RID: 3804
		public WindowsStandalonePrimaryInputSource windowsStandalonePrimaryInputSource;

		// Token: 0x04000EDD RID: 3805
		public OSXStandalonePrimaryInputSource osx_primaryInputSource;

		// Token: 0x04000EDE RID: 3806
		public LinuxStandalonePrimaryInputSource linux_primaryInputSource;

		// Token: 0x04000EDF RID: 3807
		public WindowsUWPPrimaryInputSource windowsUWP_primaryInputSource;

		// Token: 0x04000EE0 RID: 3808
		public XboxOnePrimaryInputSource xboxOne_primaryInputSource;

		// Token: 0x04000EE1 RID: 3809
		public GameCoreXboxOnePrimaryInputSource gameCoreXboxOne_primaryInputSource;

		// Token: 0x04000EE2 RID: 3810
		public GameCoreScarlettPrimaryInputSource gameCoreScarlett_primaryInputSource;

		// Token: 0x04000EE3 RID: 3811
		public PS4PrimaryInputSource ps4_primaryInputSource;

		// Token: 0x04000EE4 RID: 3812
		public PS5PrimaryInputSource ps5_primaryInputSource;

		// Token: 0x04000EE5 RID: 3813
		public WebGLPrimaryInputSource webGL_primaryInputSource;

		// Token: 0x04000EE6 RID: 3814
		public bool useXInput = true;

		// Token: 0x04000EE7 RID: 3815
		public bool useNativeMouse = true;

		// Token: 0x04000EE8 RID: 3816
		public bool useEnhancedDeviceSupport = true;

		// Token: 0x04000EE9 RID: 3817
		public bool osxStandalone_useEnhancedDeviceSupport = true;

		// Token: 0x04000EEA RID: 3818
		public bool android_supportUnknownGamepads = true;

		// Token: 0x04000EEB RID: 3819
		public bool ps4_assignJoysticksByPS4JoyId = true;

		// Token: 0x04000EEC RID: 3820
		public bool useSteamControllerSupport = true;

		// Token: 0x04000EED RID: 3821
		public bool logToScreen;

		// Token: 0x04000EEE RID: 3822
		public bool runInEditMode;

		// Token: 0x04000EEF RID: 3823
		public bool allowInputInEditorSceneView;

		// Token: 0x04000EF0 RID: 3824
		public bool unityUsePhysicalKeys;

		// Token: 0x04000EF1 RID: 3825
		public KeyCombinationOverrideMode keyCombinationOverrideMode = KeyCombinationOverrideMode.Pause;

		// Token: 0x04000EF2 RID: 3826
		public bool generateKeyEventsOnKeyCombinationOverride;

		// Token: 0x04000EF3 RID: 3827
		public ConfigVars.PlatformVars_WindowsStandalone platformVars_windowsStandalone;

		// Token: 0x04000EF4 RID: 3828
		public ConfigVars.PlatformVars_LinuxStandalone platformVars_linuxStandalone;

		// Token: 0x04000EF5 RID: 3829
		public ConfigVars.PlatformVars_OSXStandalone platformVars_osxStandalone;

		// Token: 0x04000EF6 RID: 3830
		public ConfigVars.PlatformVars_WindowsUWP platformVars_windowsUWP;

		// Token: 0x04000EF7 RID: 3831
		public ConfigVars.PlatformVars platformVars_iOS;

		// Token: 0x04000EF8 RID: 3832
		public ConfigVars.PlatformVars platformVars_tvOS;

		// Token: 0x04000EF9 RID: 3833
		public ConfigVars.PlatformVars platformVars_android;

		// Token: 0x04000EFA RID: 3834
		public ConfigVars.PlatformVars platformVars_ps4;

		// Token: 0x04000EFB RID: 3835
		public ConfigVars.PlatformVars_PS5 platformVars_ps5;

		// Token: 0x04000EFC RID: 3836
		public ConfigVars.PlatformVars platformVars_psVita;

		// Token: 0x04000EFD RID: 3837
		public ConfigVars.PlatformVars platformVars_xboxOne;

		// Token: 0x04000EFE RID: 3838
		public ConfigVars.PlatformVars_GameCoreXboxOne platformVars_gameCoreXboxOne;

		// Token: 0x04000EFF RID: 3839
		public ConfigVars.PlatformVars_GameCoreScarlett platformVars_gameCoreScarlett;

		// Token: 0x04000F00 RID: 3840
		public ConfigVars.PlatformVars platformVars_switch;

		// Token: 0x04000F01 RID: 3841
		public ConfigVars.PlatformVars platformVars_webGL;

		// Token: 0x04000F02 RID: 3842
		[NonSerialized]
		private ConfigVars.PlatformVars platformVars_unknown;

		// Token: 0x04000F03 RID: 3843
		public int maxJoysticksPerPlayer = 1;

		// Token: 0x04000F04 RID: 3844
		public bool autoAssignJoysticks = true;

		// Token: 0x04000F05 RID: 3845
		public bool assignJoysticksToPlayingPlayersOnly;

		// Token: 0x04000F06 RID: 3846
		public bool distributeJoysticksEvenly = true;

		// Token: 0x04000F07 RID: 3847
		public bool reassignJoystickToPreviousOwnerOnReconnect = true;

		// Token: 0x04000F08 RID: 3848
		public DeadZone2DType defaultJoystickAxis2DDeadZoneType = DeadZone2DType.Radial;

		// Token: 0x04000F09 RID: 3849
		public AxisSensitivity2DType defaultJoystickAxis2DSensitivityType;

		// Token: 0x04000F0A RID: 3850
		public AxisSensitivityType defaultAxisSensitivityType;

		// Token: 0x04000F0B RID: 3851
		public bool force4WayHats;

		// Token: 0x04000F0C RID: 3852
		public ThrottleCalibrationMode throttleCalibrationMode;

		// Token: 0x04000F0D RID: 3853
		public bool activateActionButtonsOnNegativeValue;

		// Token: 0x04000F0E RID: 3854
		public bool deferControllerConnectedEventsOnStart;

		// Token: 0x04000F0F RID: 3855
		public LogLevelFlags logLevel = LogLevelFlags.Info | LogLevelFlags.Warning | LogLevelFlags.Error;

		// Token: 0x04000F10 RID: 3856
		public ConfigVars.EditorVars editorSettings;

		// Token: 0x04000F11 RID: 3857
		private Dictionary<int, ConfigVars.oHaujoMelsDGsAFhGBqoddMGmvObB> __platformVarsDict;

		// Token: 0x04000F12 RID: 3858
		private Dictionary<int, ConfigVars.xkrWNOFqHQxqgrBDOvgPxAIhpwrP> __getSetPlatformVariableDict;

		// Token: 0x04000F13 RID: 3859
		private KeyedGetSetValueStore<string> __configVarsValues;

		// Token: 0x04000F14 RID: 3860
		private Dictionary<string, object> __valueDelegates;

		// Token: 0x02000241 RID: 577
		private static class qpfdVDdssGHPPDTfhCypbOTYELgqb
		{
			// Token: 0x04000F15 RID: 3861
			public const string VsrDEFduuAVYDPsCyxeSQTMunbWd = "updateLoop";

			// Token: 0x04000F16 RID: 3862
			public const string trPSwAJlkyEcroGBqqsxlcEjyCte = "alwaysUseUnityInput";

			// Token: 0x04000F17 RID: 3863
			public const string SzYhVSfoTGCoBtdwJEiixtKAIeEK = "windowsStandalonePrimaryInputSource";

			// Token: 0x04000F18 RID: 3864
			public const string lKDtJaSzdELKRtUvJicKGCmAkQp = "osx_primaryInputSource";

			// Token: 0x04000F19 RID: 3865
			public const string ajHDyOLYUagLeIAMVEpqrNqnbuEm = "linux_primaryInputSource";

			// Token: 0x04000F1A RID: 3866
			public const string sRohNXUEvNfIiZMgSGHjDhVtQDSRA = "windowsUWP_primaryInputSource";

			// Token: 0x04000F1B RID: 3867
			public const string bfDbYrzjsZxefTLiXykjyFLypGFF = "xboxOne_primaryInputSource";

			// Token: 0x04000F1C RID: 3868
			public const string kBHWgIMCJimxrnCmUwHTbJDIZFfB = "gameCoreXboxOne_primaryInputSource";

			// Token: 0x04000F1D RID: 3869
			public const string CkKnIMRvojTtMLVsOAjMlFFFFEbl = "gameCoreScarlett_primaryInputSource";

			// Token: 0x04000F1E RID: 3870
			public const string sPylafSvlodGEfwhQWSaUyMjduAO = "ps4_primaryInputSource";

			// Token: 0x04000F1F RID: 3871
			public const string zlhnamVVnwYOLBsJgyKYtbtviiww = "ps5_primaryInputSource";

			// Token: 0x04000F20 RID: 3872
			public const string qkUInUobYneLjpgYsdfYcxqwmuzcA = "webGL_primaryInputSource";

			// Token: 0x04000F21 RID: 3873
			public const string bbNPndeGDXeOEKOaZjJmIkMFxvBf = "useXInput";

			// Token: 0x04000F22 RID: 3874
			public const string GMJdkmzjRXMpLFOxfuZkJywuiWHg = "windowsStandalone_useSteamRawInputControllerWorkaround";

			// Token: 0x04000F23 RID: 3875
			public const string tdPGgttHViAmfaFZmCdHGMfJdVmVA = "osxStandalone_useEnhancedDeviceSupport";

			// Token: 0x04000F24 RID: 3876
			public const string lNjArVeQVfVlhTviMoJTIwBrwZhkA = "android_supportUnknownGamepads";

			// Token: 0x04000F25 RID: 3877
			public const string iODplwqBRfTuVuBJjCgZgepoNdbZA = "ps4_assignJoysticksByPS4JoyId";

			// Token: 0x04000F26 RID: 3878
			public const string pUGnjdfXyStJQUnKhKtAhiSYQBRE = "useSteamControllerSupport";

			// Token: 0x04000F27 RID: 3879
			public const string EYELYleMwwrXHAOagXDhUMUXHHvJ = "logToScreen";

			// Token: 0x04000F28 RID: 3880
			public const string LmmyrFRJnZvKTLFVOZZLznstkjCU = "runInEditMode";

			// Token: 0x04000F29 RID: 3881
			public const string UmZlzvfGICCilLyWvIqznljdcKmL = "allowInputInEditorSceneView";

			// Token: 0x04000F2A RID: 3882
			public const string vMwCXXXCZEAkNbEwnFOGmvPXjMEB = "maxJoysticksPerPlayer";

			// Token: 0x04000F2B RID: 3883
			public const string rPCQSPXlOxFqmrYTJDxJMCPTGnDQ = "autoAssignJoysticks";

			// Token: 0x04000F2C RID: 3884
			public const string tRcMfLCaeUIPJwBnDvAtYilMiHSiA = "assignJoysticksToPlayingPlayersOnly";

			// Token: 0x04000F2D RID: 3885
			public const string sAuXNZAjNodIVLrqaDTUATUWOIZr = "distributeJoysticksEvenly";

			// Token: 0x04000F2E RID: 3886
			public const string jcRBcnUJPKillCmxkJPLfkdJIvbBB = "reassignJoystickToPreviousOwnerOnReconnect";

			// Token: 0x04000F2F RID: 3887
			public const string fyArPfDDKIEBkDPsQFRHayhBiwhEA = "defaultJoystickAxis2DDeadZoneType";

			// Token: 0x04000F30 RID: 3888
			public const string bqdZtEzbYxdNNTOetiVoSwoYEIYp = "defaultJoystickAxis2DSensitivityType";

			// Token: 0x04000F31 RID: 3889
			public const string FRFAHflGCmaJlIgwYBQRRSBNlgCN = "defaultAxisSensitivityType";

			// Token: 0x04000F32 RID: 3890
			public const string NrnfnIHZaeiNslLBQUIwaKFjpOdt = "force4WayHats";

			// Token: 0x04000F33 RID: 3891
			public const string WPsWidOsTuowxTBYbQhyBpBslXtf = "throttleCalibrationMode";

			// Token: 0x04000F34 RID: 3892
			public const string DBmcuyjzCvDPcJrSSGFJCiTseSsWA = "activateActionButtonsOnNegativeValue";

			// Token: 0x04000F35 RID: 3893
			public const string COHLGUgjeTDYulQJhJqNlPQeogCV = "deferControllerConnectedEventsOnStart";

			// Token: 0x04000F36 RID: 3894
			public const string GxKyLSPeJsEUEmRPjUzEcFKzLeyg = "logLevel";

			// Token: 0x04000F37 RID: 3895
			public const string EafznHFwZaKsZpJqikxxAeNyIrWbA = "disableKeyboard";

			// Token: 0x04000F38 RID: 3896
			public const string WEUmRhPOguYXRvjcmwwboaTdcXHQ = "disableMouse";

			// Token: 0x04000F39 RID: 3897
			public const string LxMdIyhwYdeRnFYiknvKYGOavbBfA = "ignoreInputWhenAppNotInFocus";

			// Token: 0x04000F3A RID: 3898
			public const string pcPHRLckCXRixRitbskQOFoSHgCzA = "useEnhancedDeviceSupport";

			// Token: 0x04000F3B RID: 3899
			public const string PqGoDPfmVmeRPbjEtWJSfeGczKdh = "useNativeMouse";

			// Token: 0x04000F3C RID: 3900
			public const string mEvUhzLhlpdbSOHzqfMZWFcdFNKW = "useNativeKeyboard";

			// Token: 0x04000F3D RID: 3901
			public const string LnkPuLEcEjJZyYZYYmziJMNRkIac = "joystickRefreshRate";

			// Token: 0x04000F3E RID: 3902
			public const string nmigEpmIQsrezoDwllXFYbeYRwmP = "assignJoysticksBySystemId";
		}

		// Token: 0x02000242 RID: 578
		[Serializable]
		public class PlatformVars
		{
			// Token: 0x04000F3F RID: 3903
			public bool disableKeyboard;

			// Token: 0x04000F40 RID: 3904
			public bool disableMouse;

			// Token: 0x04000F41 RID: 3905
			public bool ignoreInputWhenAppNotInFocus = true;
		}

		// Token: 0x02000243 RID: 579
		[Serializable]
		public class PlatformVars_WindowsStandalone : ConfigVars.PlatformVars
		{
			// Token: 0x04000F42 RID: 3906
			public bool useNativeKeyboard = true;

			// Token: 0x04000F43 RID: 3907
			public int joystickRefreshRate = 240;

			// Token: 0x04000F44 RID: 3908
			public bool useWindowsGamingInput;

			// Token: 0x04000F45 RID: 3909
			public List<EnhancedDeviceSupportDeviceType> enhancedDeviceSupportExcludedDeviceTypes;
		}

		// Token: 0x02000244 RID: 580
		[Serializable]
		public class PlatformVars_OSXStandalone : ConfigVars.PlatformVars
		{
			// Token: 0x04000F46 RID: 3910
			public bool useAppleGameController;

			// Token: 0x04000F47 RID: 3911
			public bool assignJoysticksByUserId;

			// Token: 0x04000F48 RID: 3912
			public List<EnhancedDeviceSupportDeviceType> enhancedDeviceSupportExcludedDeviceTypes;
		}

		// Token: 0x02000245 RID: 581
		[Serializable]
		public class PlatformVars_LinuxStandalone : ConfigVars.PlatformVars
		{
			// Token: 0x04000F49 RID: 3913
			public bool useEnhancedDeviceSupport = true;

			// Token: 0x04000F4A RID: 3914
			public List<EnhancedDeviceSupportDeviceType> enhancedDeviceSupportExcludedDeviceTypes;
		}

		// Token: 0x02000246 RID: 582
		[Serializable]
		public class PlatformVars_WindowsUWP : ConfigVars.PlatformVars
		{
			// Token: 0x04000F4B RID: 3915
			public bool useGamepadAPI = true;

			// Token: 0x04000F4C RID: 3916
			public bool useHIDAPI = true;
		}

		// Token: 0x02000247 RID: 583
		[Serializable]
		public class PlatformVars_GameCoreXboxOne : ConfigVars.PlatformVars
		{
			// Token: 0x04000F4D RID: 3917
			public bool assignJoysticksByUserId;
		}

		// Token: 0x02000248 RID: 584
		[Serializable]
		public class PlatformVars_GameCoreScarlett : ConfigVars.PlatformVars
		{
			// Token: 0x04000F4E RID: 3918
			public bool assignJoysticksByUserId;
		}

		// Token: 0x02000249 RID: 585
		[Serializable]
		public class PlatformVars_PS5 : ConfigVars.PlatformVars
		{
			// Token: 0x04000F4F RID: 3919
			public bool assignJoysticksByPS5JoyId = true;
		}

		// Token: 0x0200024A RID: 586
		[Serializable]
		public sealed class EditorVars
		{
			// Token: 0x04000F50 RID: 3920
			public bool exportConsts_useParentClass;

			// Token: 0x04000F51 RID: 3921
			public string exportConsts_parentClassName = "RewiredConsts";

			// Token: 0x04000F52 RID: 3922
			public bool exportConsts_useNamespace = true;

			// Token: 0x04000F53 RID: 3923
			public string exportConsts_namespace = "RewiredConsts";

			// Token: 0x04000F54 RID: 3924
			public bool exportConsts_actions = true;

			// Token: 0x04000F55 RID: 3925
			public string exportConsts_actionsClassName = "Action";

			// Token: 0x04000F56 RID: 3926
			public bool exportConsts_actionsIncludeActionCategory;

			// Token: 0x04000F57 RID: 3927
			public bool exportConsts_actionsCreateClassesForActionCategories;

			// Token: 0x04000F58 RID: 3928
			public bool exportConsts_mapCategories = true;

			// Token: 0x04000F59 RID: 3929
			public string exportConsts_mapCategoriesClassName = "Category";

			// Token: 0x04000F5A RID: 3930
			public bool exportConsts_layouts = true;

			// Token: 0x04000F5B RID: 3931
			public string exportConsts_layoutsClassName = "Layout";

			// Token: 0x04000F5C RID: 3932
			public bool exportConsts_players = true;

			// Token: 0x04000F5D RID: 3933
			public string exportConsts_playersClassName = "Player";

			// Token: 0x04000F5E RID: 3934
			public bool exportConsts_inputBehaviors;

			// Token: 0x04000F5F RID: 3935
			public string exportConsts_inputBehaviorsClassName = "InputBehavior";

			// Token: 0x04000F60 RID: 3936
			public bool exportConsts_customControllers = true;

			// Token: 0x04000F61 RID: 3937
			public string exportConsts_customControllersClassName = "CustomController";

			// Token: 0x04000F62 RID: 3938
			public string exportConsts_customControllersAxesClassName = "Axis";

			// Token: 0x04000F63 RID: 3939
			public string exportConsts_customControllersButtonsClassName = "Button";

			// Token: 0x04000F64 RID: 3940
			public bool exportConsts_layoutManagerRuleSets = true;

			// Token: 0x04000F65 RID: 3941
			public string exportConsts_layoutManagerRuleSetsClassName = "LayoutManagerRuleSet";

			// Token: 0x04000F66 RID: 3942
			public bool exportConsts_mapEnablerRuleSets = true;

			// Token: 0x04000F67 RID: 3943
			public string exportConsts_mapEnablerRuleSetsClassName = "MapEnablerRuleSet";

			// Token: 0x04000F68 RID: 3944
			public bool exportConsts_allCapsConstantNames;
		}

		// Token: 0x0200024B RID: 587
		private class oHaujoMelsDGsAFhGBqoddMGmvObB
		{
			// Token: 0x06001ADA RID: 6874 RVA: 0x00015C5F File Offset: 0x00013E5F
			public oHaujoMelsDGsAFhGBqoddMGmvObB(Func<ConfigVars.PlatformVars> A_1, string A_2)
			{
				this.zWtRhCfwaYdEKXLSUSvYOvkpruNF = A_1;
				this.tVgSJMfkfXOqxIlRGDhGgmToCdODb = A_2;
			}

			// Token: 0x04000F69 RID: 3945
			public Func<ConfigVars.PlatformVars> zWtRhCfwaYdEKXLSUSvYOvkpruNF;

			// Token: 0x04000F6A RID: 3946
			public string tVgSJMfkfXOqxIlRGDhGgmToCdODb;
		}

		// Token: 0x0200024C RID: 588
		private class xkrWNOFqHQxqgrBDOvgPxAIhpwrP
		{
			// Token: 0x06001ADB RID: 6875 RVA: 0x00015C75 File Offset: 0x00013E75
			public xkrWNOFqHQxqgrBDOvgPxAIhpwrP(Func<Platform, object> A_1, Action<Platform, object> A_2)
			{
				this.JbpEoCgQnOIeSYRQobNUBQQiWSOqB = A_1;
				this.NgNkjDthobzGslcoqIXMcUYCyFic = A_2;
			}

			// Token: 0x04000F6B RID: 3947
			public Func<Platform, object> JbpEoCgQnOIeSYRQobNUBQQiWSOqB;

			// Token: 0x04000F6C RID: 3948
			public Action<Platform, object> NgNkjDthobzGslcoqIXMcUYCyFic;
		}

		// Token: 0x0200024D RID: 589
		[CustomObfuscation(rename = false)]
		internal enum AllPlatformVar
		{
			// Token: 0x04000F6E RID: 3950
			[CustomObfuscation(rename = false)]
			DisableKeyboard,
			// Token: 0x04000F6F RID: 3951
			[CustomObfuscation(rename = false)]
			IgnoreInputWhenAppNotInFocus,
			// Token: 0x04000F70 RID: 3952
			[CustomObfuscation(rename = false)]
			DisableMouse
		}
	}
}
