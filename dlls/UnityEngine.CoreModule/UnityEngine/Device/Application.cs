using System;
using System.Threading;
using UnityEngine.Events;

namespace UnityEngine.Device
{
	// Token: 0x020004AF RID: 1199
	public static class Application
	{
		// Token: 0x170007A7 RID: 1959
		// (get) Token: 0x060029D3 RID: 10707 RVA: 0x00046EA4 File Offset: 0x000450A4
		public static string absoluteURL
		{
			get
			{
				return Application.absoluteURL;
			}
		}

		// Token: 0x170007A8 RID: 1960
		// (get) Token: 0x060029D4 RID: 10708 RVA: 0x00046EAB File Offset: 0x000450AB
		// (set) Token: 0x060029D5 RID: 10709 RVA: 0x00046EB2 File Offset: 0x000450B2
		public static ThreadPriority backgroundLoadingPriority
		{
			get
			{
				return Application.backgroundLoadingPriority;
			}
			set
			{
				Application.backgroundLoadingPriority = value;
			}
		}

		// Token: 0x170007A9 RID: 1961
		// (get) Token: 0x060029D6 RID: 10710 RVA: 0x00046EBB File Offset: 0x000450BB
		public static string buildGUID
		{
			get
			{
				return Application.buildGUID;
			}
		}

		// Token: 0x170007AA RID: 1962
		// (get) Token: 0x060029D7 RID: 10711 RVA: 0x00046EC2 File Offset: 0x000450C2
		public static string cloudProjectId
		{
			get
			{
				return Application.cloudProjectId;
			}
		}

		// Token: 0x170007AB RID: 1963
		// (get) Token: 0x060029D8 RID: 10712 RVA: 0x00046EC9 File Offset: 0x000450C9
		public static string companyName
		{
			get
			{
				return Application.companyName;
			}
		}

		// Token: 0x170007AC RID: 1964
		// (get) Token: 0x060029D9 RID: 10713 RVA: 0x00046ED0 File Offset: 0x000450D0
		public static string consoleLogPath
		{
			get
			{
				return Application.consoleLogPath;
			}
		}

		// Token: 0x170007AD RID: 1965
		// (get) Token: 0x060029DA RID: 10714 RVA: 0x00046ED7 File Offset: 0x000450D7
		public static string dataPath
		{
			get
			{
				return Application.dataPath;
			}
		}

		// Token: 0x170007AE RID: 1966
		// (get) Token: 0x060029DB RID: 10715 RVA: 0x00046EDE File Offset: 0x000450DE
		public static bool genuine
		{
			get
			{
				return Application.genuine;
			}
		}

		// Token: 0x170007AF RID: 1967
		// (get) Token: 0x060029DC RID: 10716 RVA: 0x00046EE5 File Offset: 0x000450E5
		public static bool genuineCheckAvailable
		{
			get
			{
				return Application.genuineCheckAvailable;
			}
		}

		// Token: 0x170007B0 RID: 1968
		// (get) Token: 0x060029DD RID: 10717 RVA: 0x00046EEC File Offset: 0x000450EC
		public static string identifier
		{
			get
			{
				return Application.identifier;
			}
		}

		// Token: 0x170007B1 RID: 1969
		// (get) Token: 0x060029DE RID: 10718 RVA: 0x00046EF3 File Offset: 0x000450F3
		public static string installerName
		{
			get
			{
				return Application.installerName;
			}
		}

		// Token: 0x170007B2 RID: 1970
		// (get) Token: 0x060029DF RID: 10719 RVA: 0x00046EFA File Offset: 0x000450FA
		public static ApplicationInstallMode installMode
		{
			get
			{
				return Application.installMode;
			}
		}

		// Token: 0x170007B3 RID: 1971
		// (get) Token: 0x060029E0 RID: 10720 RVA: 0x00046F01 File Offset: 0x00045101
		public static NetworkReachability internetReachability
		{
			get
			{
				return Application.internetReachability;
			}
		}

		// Token: 0x170007B4 RID: 1972
		// (get) Token: 0x060029E1 RID: 10721 RVA: 0x00046F08 File Offset: 0x00045108
		public static bool isBatchMode
		{
			get
			{
				return Application.isBatchMode;
			}
		}

		// Token: 0x170007B5 RID: 1973
		// (get) Token: 0x060029E2 RID: 10722 RVA: 0x00046F0F File Offset: 0x0004510F
		public static bool isConsolePlatform
		{
			get
			{
				return Application.isConsolePlatform;
			}
		}

		// Token: 0x170007B6 RID: 1974
		// (get) Token: 0x060029E3 RID: 10723 RVA: 0x00046F16 File Offset: 0x00045116
		public static bool isEditor
		{
			get
			{
				return Application.isEditor;
			}
		}

		// Token: 0x170007B7 RID: 1975
		// (get) Token: 0x060029E4 RID: 10724 RVA: 0x00046F1D File Offset: 0x0004511D
		public static bool isFocused
		{
			get
			{
				return Application.isFocused;
			}
		}

		// Token: 0x170007B8 RID: 1976
		// (get) Token: 0x060029E5 RID: 10725 RVA: 0x00046F24 File Offset: 0x00045124
		public static bool isMobilePlatform
		{
			get
			{
				return Application.isMobilePlatform;
			}
		}

		// Token: 0x170007B9 RID: 1977
		// (get) Token: 0x060029E6 RID: 10726 RVA: 0x00046F2B File Offset: 0x0004512B
		public static bool isPlaying
		{
			get
			{
				return Application.isPlaying;
			}
		}

		// Token: 0x170007BA RID: 1978
		// (get) Token: 0x060029E7 RID: 10727 RVA: 0x00046F32 File Offset: 0x00045132
		public static string persistentDataPath
		{
			get
			{
				return Application.persistentDataPath;
			}
		}

		// Token: 0x170007BB RID: 1979
		// (get) Token: 0x060029E8 RID: 10728 RVA: 0x00046F39 File Offset: 0x00045139
		public static RuntimePlatform platform
		{
			get
			{
				return Application.platform;
			}
		}

		// Token: 0x170007BC RID: 1980
		// (get) Token: 0x060029E9 RID: 10729 RVA: 0x00046F40 File Offset: 0x00045140
		public static string productName
		{
			get
			{
				return Application.productName;
			}
		}

		// Token: 0x170007BD RID: 1981
		// (get) Token: 0x060029EA RID: 10730 RVA: 0x00046F47 File Offset: 0x00045147
		// (set) Token: 0x060029EB RID: 10731 RVA: 0x00046F4E File Offset: 0x0004514E
		public static bool runInBackground
		{
			get
			{
				return Application.runInBackground;
			}
			set
			{
				Application.runInBackground = value;
			}
		}

		// Token: 0x170007BE RID: 1982
		// (get) Token: 0x060029EC RID: 10732 RVA: 0x00046F57 File Offset: 0x00045157
		public static ApplicationSandboxType sandboxType
		{
			get
			{
				return Application.sandboxType;
			}
		}

		// Token: 0x170007BF RID: 1983
		// (get) Token: 0x060029ED RID: 10733 RVA: 0x00046F5E File Offset: 0x0004515E
		public static string streamingAssetsPath
		{
			get
			{
				return Application.streamingAssetsPath;
			}
		}

		// Token: 0x170007C0 RID: 1984
		// (get) Token: 0x060029EE RID: 10734 RVA: 0x00046F65 File Offset: 0x00045165
		public static SystemLanguage systemLanguage
		{
			get
			{
				return Application.systemLanguage;
			}
		}

		// Token: 0x170007C1 RID: 1985
		// (get) Token: 0x060029EF RID: 10735 RVA: 0x00046F6C File Offset: 0x0004516C
		// (set) Token: 0x060029F0 RID: 10736 RVA: 0x00046F73 File Offset: 0x00045173
		public static int targetFrameRate
		{
			get
			{
				return Application.targetFrameRate;
			}
			set
			{
				Application.targetFrameRate = value;
			}
		}

		// Token: 0x170007C2 RID: 1986
		// (get) Token: 0x060029F1 RID: 10737 RVA: 0x00046F7C File Offset: 0x0004517C
		public static string temporaryCachePath
		{
			get
			{
				return Application.temporaryCachePath;
			}
		}

		// Token: 0x170007C3 RID: 1987
		// (get) Token: 0x060029F2 RID: 10738 RVA: 0x00046F83 File Offset: 0x00045183
		public static string unityVersion
		{
			get
			{
				return Application.unityVersion;
			}
		}

		// Token: 0x170007C4 RID: 1988
		// (get) Token: 0x060029F3 RID: 10739 RVA: 0x00046F8A File Offset: 0x0004518A
		public static string version
		{
			get
			{
				return Application.version;
			}
		}

		// Token: 0x14000039 RID: 57
		// (add) Token: 0x060029F4 RID: 10740 RVA: 0x00046F91 File Offset: 0x00045191
		// (remove) Token: 0x060029F5 RID: 10741 RVA: 0x00046F9A File Offset: 0x0004519A
		public static event Action<string> deepLinkActivated
		{
			add
			{
				Application.deepLinkActivated += value;
			}
			remove
			{
				Application.deepLinkActivated -= value;
			}
		}

		// Token: 0x1400003A RID: 58
		// (add) Token: 0x060029F6 RID: 10742 RVA: 0x00046FA3 File Offset: 0x000451A3
		// (remove) Token: 0x060029F7 RID: 10743 RVA: 0x00046FAC File Offset: 0x000451AC
		public static event Action<bool> focusChanged
		{
			add
			{
				Application.focusChanged += value;
			}
			remove
			{
				Application.focusChanged -= value;
			}
		}

		// Token: 0x1400003B RID: 59
		// (add) Token: 0x060029F8 RID: 10744 RVA: 0x00046FB5 File Offset: 0x000451B5
		// (remove) Token: 0x060029F9 RID: 10745 RVA: 0x00046FBE File Offset: 0x000451BE
		public static event Application.LogCallback logMessageReceived
		{
			add
			{
				Application.logMessageReceived += value;
			}
			remove
			{
				Application.logMessageReceived -= value;
			}
		}

		// Token: 0x1400003C RID: 60
		// (add) Token: 0x060029FA RID: 10746 RVA: 0x00046FC7 File Offset: 0x000451C7
		// (remove) Token: 0x060029FB RID: 10747 RVA: 0x00046FD0 File Offset: 0x000451D0
		public static event Application.LogCallback logMessageReceivedThreaded
		{
			add
			{
				Application.logMessageReceivedThreaded += value;
			}
			remove
			{
				Application.logMessageReceivedThreaded -= value;
			}
		}

		// Token: 0x1400003D RID: 61
		// (add) Token: 0x060029FC RID: 10748 RVA: 0x00046FD9 File Offset: 0x000451D9
		// (remove) Token: 0x060029FD RID: 10749 RVA: 0x00046FE2 File Offset: 0x000451E2
		public static event Application.LowMemoryCallback lowMemory
		{
			add
			{
				Application.lowMemory += value;
			}
			remove
			{
				Application.lowMemory -= value;
			}
		}

		// Token: 0x1400003E RID: 62
		// (add) Token: 0x060029FE RID: 10750 RVA: 0x00046FEB File Offset: 0x000451EB
		// (remove) Token: 0x060029FF RID: 10751 RVA: 0x00046FF4 File Offset: 0x000451F4
		public static event Application.MemoryUsageChangedCallback memoryUsageChanged
		{
			add
			{
				Application.memoryUsageChanged += value;
			}
			remove
			{
				Application.memoryUsageChanged -= value;
			}
		}

		// Token: 0x1400003F RID: 63
		// (add) Token: 0x06002A00 RID: 10752 RVA: 0x00046FFD File Offset: 0x000451FD
		// (remove) Token: 0x06002A01 RID: 10753 RVA: 0x00047006 File Offset: 0x00045206
		public static event UnityAction onBeforeRender
		{
			add
			{
				Application.onBeforeRender += value;
			}
			remove
			{
				Application.onBeforeRender -= value;
			}
		}

		// Token: 0x14000040 RID: 64
		// (add) Token: 0x06002A02 RID: 10754 RVA: 0x0004700F File Offset: 0x0004520F
		// (remove) Token: 0x06002A03 RID: 10755 RVA: 0x00047018 File Offset: 0x00045218
		public static event Action quitting
		{
			add
			{
				Application.quitting += value;
			}
			remove
			{
				Application.quitting -= value;
			}
		}

		// Token: 0x14000041 RID: 65
		// (add) Token: 0x06002A04 RID: 10756 RVA: 0x00047021 File Offset: 0x00045221
		// (remove) Token: 0x06002A05 RID: 10757 RVA: 0x0004702A File Offset: 0x0004522A
		public static event Func<bool> wantsToQuit
		{
			add
			{
				Application.wantsToQuit += value;
			}
			remove
			{
				Application.wantsToQuit -= value;
			}
		}

		// Token: 0x14000042 RID: 66
		// (add) Token: 0x06002A06 RID: 10758 RVA: 0x00047033 File Offset: 0x00045233
		// (remove) Token: 0x06002A07 RID: 10759 RVA: 0x0004703C File Offset: 0x0004523C
		public static event Action unloading
		{
			add
			{
				Application.unloading += value;
			}
			remove
			{
				Application.unloading -= value;
			}
		}

		// Token: 0x06002A08 RID: 10760 RVA: 0x00047048 File Offset: 0x00045248
		public static bool CanStreamedLevelBeLoaded(int levelIndex)
		{
			return Application.CanStreamedLevelBeLoaded(levelIndex);
		}

		// Token: 0x06002A09 RID: 10761 RVA: 0x00047060 File Offset: 0x00045260
		public static bool CanStreamedLevelBeLoaded(string levelName)
		{
			return Application.CanStreamedLevelBeLoaded(levelName);
		}

		// Token: 0x06002A0A RID: 10762 RVA: 0x00047078 File Offset: 0x00045278
		[Obsolete("Application.GetBuildTags is no longer supported and will be removed.", false)]
		public static string[] GetBuildTags()
		{
			return Application.GetBuildTags();
		}

		// Token: 0x06002A0B RID: 10763 RVA: 0x0004708F File Offset: 0x0004528F
		[Obsolete("Application.SetBuildTags is no longer supported and will be removed.", false)]
		public static void SetBuildTags(string[] buildTags)
		{
			Application.SetBuildTags(buildTags);
		}

		// Token: 0x06002A0C RID: 10764 RVA: 0x0004709C File Offset: 0x0004529C
		public static StackTraceLogType GetStackTraceLogType(LogType logType)
		{
			return Application.GetStackTraceLogType(logType);
		}

		// Token: 0x06002A0D RID: 10765 RVA: 0x000470B4 File Offset: 0x000452B4
		public static bool HasProLicense()
		{
			return Application.HasProLicense();
		}

		// Token: 0x06002A0E RID: 10766 RVA: 0x000470CC File Offset: 0x000452CC
		public static bool HasUserAuthorization(UserAuthorization mode)
		{
			return Application.HasUserAuthorization(mode);
		}

		// Token: 0x06002A0F RID: 10767 RVA: 0x000470E4 File Offset: 0x000452E4
		public static bool IsPlaying(Object obj)
		{
			return Application.IsPlaying(obj);
		}

		// Token: 0x06002A10 RID: 10768 RVA: 0x000470FC File Offset: 0x000452FC
		public static void OpenURL(string url)
		{
			Application.OpenURL(url);
		}

		// Token: 0x06002A11 RID: 10769 RVA: 0x00047106 File Offset: 0x00045306
		public static void Quit()
		{
			Application.Quit();
		}

		// Token: 0x06002A12 RID: 10770 RVA: 0x0004710F File Offset: 0x0004530F
		public static void Quit(int exitCode)
		{
			Application.Quit(exitCode);
		}

		// Token: 0x06002A13 RID: 10771 RVA: 0x0004711C File Offset: 0x0004531C
		public static bool RequestAdvertisingIdentifierAsync(Application.AdvertisingIdentifierCallback delegateMethod)
		{
			return Application.RequestAdvertisingIdentifierAsync(delegateMethod);
		}

		// Token: 0x06002A14 RID: 10772 RVA: 0x00047134 File Offset: 0x00045334
		public static AsyncOperation RequestUserAuthorization(UserAuthorization mode)
		{
			return Application.RequestUserAuthorization(mode);
		}

		// Token: 0x06002A15 RID: 10773 RVA: 0x0004714C File Offset: 0x0004534C
		public static void SetStackTraceLogType(LogType logType, StackTraceLogType stackTraceType)
		{
			Application.SetStackTraceLogType(logType, stackTraceType);
		}

		// Token: 0x06002A16 RID: 10774 RVA: 0x00047157 File Offset: 0x00045357
		public static void Unload()
		{
			Application.Unload();
		}

		// Token: 0x170007C5 RID: 1989
		// (get) Token: 0x06002A17 RID: 10775 RVA: 0x00047160 File Offset: 0x00045360
		public static CancellationToken exitCancellationToken
		{
			get
			{
				return Application.exitCancellationToken;
			}
		}
	}
}
