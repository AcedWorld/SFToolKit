using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Rewired.Interfaces;
using Rewired.Platforms;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired.Utils
{
	// Token: 0x0200049B RID: 1179
	public static class UnityTools
	{
		// Token: 0x17000AEF RID: 2799
		// (get) Token: 0x06002F97 RID: 12183 RVA: 0x000243F5 File Offset: 0x000225F5
		[CustomObfuscation(rename = false)]
		internal static UnityTools.UnityVersionClass unityVersionObj
		{
			get
			{
				if (!UnityTools.TeBVErRLvmBnpLFUKWgCkaNrhipy)
				{
					return null;
				}
				return UnityTools.GKphzqwOhaugHxbtRLRFWRiDckVf;
			}
		}

		// Token: 0x17000AF0 RID: 2800
		// (get) Token: 0x06002F98 RID: 12184 RVA: 0x00024405 File Offset: 0x00022605
		public static UnityTools.UnityVersion unityVersion
		{
			get
			{
				if (!UnityTools.TeBVErRLvmBnpLFUKWgCkaNrhipy)
				{
					return UnityTools.UnityVersion.Unknown;
				}
				return UnityTools.hIgIGkmnuTEQuMvXztzTFPtkqHIC;
			}
		}

		// Token: 0x17000AF1 RID: 2801
		// (get) Token: 0x06002F99 RID: 12185 RVA: 0x00024419 File Offset: 0x00022619
		public static string unityVersionString
		{
			get
			{
				if (!UnityTools.TeBVErRLvmBnpLFUKWgCkaNrhipy)
				{
					return string.Empty;
				}
				return UnityTools.pYkRgFzmljIOaTHSzpvswAkWyCqg;
			}
		}

		// Token: 0x17000AF2 RID: 2802
		// (get) Token: 0x06002F9A RID: 12186 RVA: 0x0002442D File Offset: 0x0002262D
		public static Platform platform
		{
			get
			{
				if (!UnityTools.TeBVErRLvmBnpLFUKWgCkaNrhipy)
				{
					return Platform.Unknown;
				}
				return UnityTools.VGEdpOHQVjBjMVXteEGMWcUleyMH;
			}
		}

		// Token: 0x17000AF3 RID: 2803
		// (get) Token: 0x06002F9B RID: 12187 RVA: 0x000A6700 File Offset: 0x000A4900
		[CustomObfuscation(rename = false)]
		internal static Platform effectivePlatform
		{
			get
			{
				if (!UnityTools.TeBVErRLvmBnpLFUKWgCkaNrhipy)
				{
					return Platform.Unknown;
				}
				if (!UnityTools.fzybjvzaRzuUHlwpGfScijnxUgQi)
				{
					return UnityTools.VGEdpOHQVjBjMVXteEGMWcUleyMH;
				}
				switch (UnityTools.TMTxgoNYrgAmuBdAwgPQygozfTQF)
				{
				case EditorPlatform.OSX:
					return Platform.OSX;
				case EditorPlatform.Windows:
					return Platform.Windows;
				case EditorPlatform.Linux:
					return Platform.Linux;
				default:
					return UnityTools.VGEdpOHQVjBjMVXteEGMWcUleyMH;
				}
			}
		}

		// Token: 0x17000AF4 RID: 2804
		// (get) Token: 0x06002F9C RID: 12188 RVA: 0x0002443D File Offset: 0x0002263D
		public static EditorPlatform editorPlatform
		{
			get
			{
				if (!UnityTools.TeBVErRLvmBnpLFUKWgCkaNrhipy)
				{
					return EditorPlatform.None;
				}
				return UnityTools.TMTxgoNYrgAmuBdAwgPQygozfTQF;
			}
		}

		// Token: 0x17000AF5 RID: 2805
		// (get) Token: 0x06002F9D RID: 12189 RVA: 0x0002444D File Offset: 0x0002264D
		public static bool isEditor
		{
			get
			{
				return UnityTools.TeBVErRLvmBnpLFUKWgCkaNrhipy && UnityTools.fzybjvzaRzuUHlwpGfScijnxUgQi;
			}
		}

		// Token: 0x17000AF6 RID: 2806
		// (get) Token: 0x06002F9E RID: 12190 RVA: 0x0002445D File Offset: 0x0002265D
		public static bool isPlaying
		{
			get
			{
				return UnityTools.CuDTQIThAyMOBEJeVFLVWLymxvvm;
			}
		}

		// Token: 0x17000AF7 RID: 2807
		// (get) Token: 0x06002F9F RID: 12191 RVA: 0x00024464 File Offset: 0x00022664
		public static bool isDebugBuild
		{
			get
			{
				return UnityTools.TeBVErRLvmBnpLFUKWgCkaNrhipy && UnityTools.iJqJlQRpyMDMKcIizPKvDFHdevOCB;
			}
		}

		// Token: 0x17000AF8 RID: 2808
		// (get) Token: 0x06002FA0 RID: 12192 RVA: 0x00024474 File Offset: 0x00022674
		public static WebplayerPlatform webplayerPlatform
		{
			get
			{
				if (!UnityTools.TeBVErRLvmBnpLFUKWgCkaNrhipy)
				{
					return WebplayerPlatform.None;
				}
				return UnityTools.ohgQeGghabDpGVctuhSnhLgzYULt;
			}
		}

		// Token: 0x17000AF9 RID: 2809
		// (get) Token: 0x06002FA1 RID: 12193 RVA: 0x000A674C File Offset: 0x000A494C
		public static bool logToDebugLog
		{
			get
			{
				if (!UnityTools.TeBVErRLvmBnpLFUKWgCkaNrhipy)
				{
					return true;
				}
				if (UnityTools.fzybjvzaRzuUHlwpGfScijnxUgQi || Application.isEditor)
				{
					return true;
				}
				if (UnityTools.isAndroidPlatform)
				{
					return true;
				}
				Platform vgedpOHQVjBjMVXteEGMWcUleyMH = UnityTools.VGEdpOHQVjBjMVXteEGMWcUleyMH;
				if (vgedpOHQVjBjMVXteEGMWcUleyMH <= Platform.OSX)
				{
					if (vgedpOHQVjBjMVXteEGMWcUleyMH != Platform.Windows && vgedpOHQVjBjMVXteEGMWcUleyMH != Platform.OSX)
					{
						goto IL_5C;
					}
				}
				else if (vgedpOHQVjBjMVXteEGMWcUleyMH != Platform.Linux)
				{
					if (vgedpOHQVjBjMVXteEGMWcUleyMH == Platform.XboxOne)
					{
						return true;
					}
					if (vgedpOHQVjBjMVXteEGMWcUleyMH != Platform.Switch)
					{
						goto IL_5C;
					}
					return true;
				}
				return UnityTools.iJqJlQRpyMDMKcIizPKvDFHdevOCB || UnityTools.UnVCySiTaGFvYapCKVMaQwOJvuSzB == ScriptingBackend.IL2CPP;
				IL_5C:
				return UnityTools.iJqJlQRpyMDMKcIizPKvDFHdevOCB;
			}
		}

		// Token: 0x17000AFA RID: 2810
		// (get) Token: 0x06002FA2 RID: 12194 RVA: 0x000A67C0 File Offset: 0x000A49C0
		[CustomObfuscation(rename = false)]
		internal static bool editorPlatformMatchesBuildPlatform
		{
			get
			{
				if (!UnityTools.TeBVErRLvmBnpLFUKWgCkaNrhipy)
				{
					return false;
				}
				if (!UnityTools.fzybjvzaRzuUHlwpGfScijnxUgQi)
				{
					return true;
				}
				switch (UnityTools.TMTxgoNYrgAmuBdAwgPQygozfTQF)
				{
				case EditorPlatform.OSX:
					return UnityTools.VGEdpOHQVjBjMVXteEGMWcUleyMH == Platform.OSX;
				case EditorPlatform.Windows:
					return UnityTools.VGEdpOHQVjBjMVXteEGMWcUleyMH == Platform.Windows;
				case EditorPlatform.Linux:
					return UnityTools.VGEdpOHQVjBjMVXteEGMWcUleyMH == Platform.Linux;
				default:
					return true;
				}
			}
		}

		// Token: 0x17000AFB RID: 2811
		// (get) Token: 0x06002FA3 RID: 12195 RVA: 0x00024484 File Offset: 0x00022684
		public static bool isSupportedVersion3
		{
			get
			{
				return UnityTools.TeBVErRLvmBnpLFUKWgCkaNrhipy && UnityTools.TFDuHlVEekpbJKttHGqHACziYqLt;
			}
		}

		// Token: 0x17000AFC RID: 2812
		// (get) Token: 0x06002FA4 RID: 12196 RVA: 0x00024494 File Offset: 0x00022694
		public static bool isSupportedVersion4
		{
			get
			{
				return UnityTools.TeBVErRLvmBnpLFUKWgCkaNrhipy && UnityTools.EAzuFTVhKAwSsrjGXoMWSmSyLLio;
			}
		}

		// Token: 0x17000AFD RID: 2813
		// (get) Token: 0x06002FA5 RID: 12197 RVA: 0x000244A4 File Offset: 0x000226A4
		public static bool supports2DColliders
		{
			get
			{
				return UnityTools.TeBVErRLvmBnpLFUKWgCkaNrhipy && UnityTools.hIgIGkmnuTEQuMvXztzTFPtkqHIC >= UnityTools.UnityVersion.UNITY_4_3;
			}
		}

		// Token: 0x17000AFE RID: 2814
		// (get) Token: 0x06002FA6 RID: 12198 RVA: 0x000244A4 File Offset: 0x000226A4
		public static bool supportsSortingLayers
		{
			get
			{
				return UnityTools.TeBVErRLvmBnpLFUKWgCkaNrhipy && UnityTools.hIgIGkmnuTEQuMvXztzTFPtkqHIC >= UnityTools.UnityVersion.UNITY_4_3;
			}
		}

		// Token: 0x17000AFF RID: 2815
		// (get) Token: 0x06002FA7 RID: 12199 RVA: 0x000244BB File Offset: 0x000226BB
		public static bool supportsUnityUI
		{
			get
			{
				return UnityTools.TeBVErRLvmBnpLFUKWgCkaNrhipy && UnityTools.hIgIGkmnuTEQuMvXztzTFPtkqHIC >= UnityTools.UnityVersion.UNITY_4_6;
			}
		}

		// Token: 0x17000B00 RID: 2816
		// (get) Token: 0x06002FA8 RID: 12200 RVA: 0x000244D2 File Offset: 0x000226D2
		public static bool supportsTouchControls
		{
			get
			{
				return UnityTools.TeBVErRLvmBnpLFUKWgCkaNrhipy && UnityTools.hIgIGkmnuTEQuMvXztzTFPtkqHIC >= UnityTools.UnityVersion.UNITY_5_0;
			}
		}

		// Token: 0x17000B01 RID: 2817
		// (get) Token: 0x06002FA9 RID: 12201 RVA: 0x000244E9 File Offset: 0x000226E9
		public static bool supportsPhysicalKeys
		{
			get
			{
				return UnityTools.TeBVErRLvmBnpLFUKWgCkaNrhipy && UnityTools.hIgIGkmnuTEQuMvXztzTFPtkqHIC >= UnityTools.UnityVersion.UNITY_2021_2;
			}
		}

		// Token: 0x17000B02 RID: 2818
		// (get) Token: 0x06002FAA RID: 12202 RVA: 0x00024500 File Offset: 0x00022700
		public static bool isAndroidPlatform
		{
			get
			{
				return UnityTools.TeBVErRLvmBnpLFUKWgCkaNrhipy && (UnityTools.VGEdpOHQVjBjMVXteEGMWcUleyMH == Platform.Android || UnityTools.VGEdpOHQVjBjMVXteEGMWcUleyMH == Platform.Ouya || UnityTools.VGEdpOHQVjBjMVXteEGMWcUleyMH == Platform.AmazonFireTV || UnityTools.VGEdpOHQVjBjMVXteEGMWcUleyMH == Platform.RazerForgeTV);
			}
		}

		// Token: 0x17000B03 RID: 2819
		// (get) Token: 0x06002FAB RID: 12203 RVA: 0x00024530 File Offset: 0x00022730
		public static bool isIOSPlatform
		{
			get
			{
				return UnityTools.TeBVErRLvmBnpLFUKWgCkaNrhipy && (UnityTools.VGEdpOHQVjBjMVXteEGMWcUleyMH == Platform.iOS || UnityTools.VGEdpOHQVjBjMVXteEGMWcUleyMH == Platform.tvOS);
			}
		}

		// Token: 0x17000B04 RID: 2820
		// (get) Token: 0x06002FAC RID: 12204 RVA: 0x0002454E File Offset: 0x0002274E
		public static bool isStandalonePlatform
		{
			get
			{
				return UnityTools.TeBVErRLvmBnpLFUKWgCkaNrhipy && (UnityTools.VGEdpOHQVjBjMVXteEGMWcUleyMH == Platform.Windows || UnityTools.VGEdpOHQVjBjMVXteEGMWcUleyMH == Platform.Linux || UnityTools.VGEdpOHQVjBjMVXteEGMWcUleyMH == Platform.OSX);
			}
		}

		// Token: 0x17000B05 RID: 2821
		// (get) Token: 0x06002FAD RID: 12205 RVA: 0x00024573 File Offset: 0x00022773
		public static bool windowsJoystickNamesReturnsEmptyStringsIfJoystickNull
		{
			get
			{
				return UnityTools.TeBVErRLvmBnpLFUKWgCkaNrhipy && UnityTools.kRHYcljAhypnvdQEfnereSpyQnDk;
			}
		}

		// Token: 0x17000B06 RID: 2822
		// (get) Token: 0x06002FAE RID: 12206 RVA: 0x00024583 File Offset: 0x00022783
		public static bool supportsUnityUIGraphicRaycastTarget
		{
			get
			{
				return UnityTools.TeBVErRLvmBnpLFUKWgCkaNrhipy && UnityTools.hIgIGkmnuTEQuMvXztzTFPtkqHIC >= UnityTools.UnityVersion.UNITY_5_2;
			}
		}

		// Token: 0x17000B07 RID: 2823
		// (get) Token: 0x06002FAF RID: 12207 RVA: 0x0002459A File Offset: 0x0002279A
		public static bool supportsNestedPrefabs
		{
			get
			{
				return UnityTools.TeBVErRLvmBnpLFUKWgCkaNrhipy && UnityTools.hIgIGkmnuTEQuMvXztzTFPtkqHIC >= UnityTools.UnityVersion.UNITY_2018_3;
			}
		}

		// Token: 0x17000B08 RID: 2824
		// (get) Token: 0x06002FB0 RID: 12208 RVA: 0x000245B1 File Offset: 0x000227B1
		public static bool supportsWindowsAppStore
		{
			get
			{
				return UnityTools.TeBVErRLvmBnpLFUKWgCkaNrhipy && (UnityTools.hIgIGkmnuTEQuMvXztzTFPtkqHIC < UnityTools.UnityVersion.UNITY_5_0 || UnityTools.hIgIGkmnuTEQuMvXztzTFPtkqHIC >= UnityTools.UnityVersion.UNITY_5_0_1);
			}
		}

		// Token: 0x17000B09 RID: 2825
		// (get) Token: 0x06002FB1 RID: 12209 RVA: 0x00024583 File Offset: 0x00022783
		public static bool supportsWindowsUWP
		{
			get
			{
				return UnityTools.TeBVErRLvmBnpLFUKWgCkaNrhipy && UnityTools.hIgIGkmnuTEQuMvXztzTFPtkqHIC >= UnityTools.UnityVersion.UNITY_5_2;
			}
		}

		// Token: 0x17000B0A RID: 2826
		// (get) Token: 0x06002FB2 RID: 12210 RVA: 0x000245D3 File Offset: 0x000227D3
		public static bool supportsWindowsUWP_IL2CPP
		{
			get
			{
				return UnityTools.TeBVErRLvmBnpLFUKWgCkaNrhipy && UnityTools.hIgIGkmnuTEQuMvXztzTFPtkqHIC >= UnityTools.UnityVersion.UNITY_5_3;
			}
		}

		// Token: 0x17000B0B RID: 2827
		// (get) Token: 0x06002FB3 RID: 12211 RVA: 0x000245EA File Offset: 0x000227EA
		public static bool supportsXboxOne
		{
			get
			{
				return UnityTools.TeBVErRLvmBnpLFUKWgCkaNrhipy && UnityTools.hIgIGkmnuTEQuMvXztzTFPtkqHIC >= UnityTools.UnityVersion.UNITY_4_5;
			}
		}

		// Token: 0x17000B0C RID: 2828
		// (get) Token: 0x06002FB4 RID: 12212 RVA: 0x00024601 File Offset: 0x00022801
		public static bool windowsStandalone_supportsRawInputForwarding
		{
			get
			{
				return UnityTools.TeBVErRLvmBnpLFUKWgCkaNrhipy && UnityTools.bmswVZhIlrqttGHbtDXgfFcmFNsHb;
			}
		}

		// Token: 0x17000B0D RID: 2829
		// (get) Token: 0x06002FB5 RID: 12213 RVA: 0x00024611 File Offset: 0x00022811
		[CustomObfuscation(rename = false)]
		internal static ScriptingBackend scriptingBackend
		{
			get
			{
				return UnityTools.UnVCySiTaGFvYapCKVMaQwOJvuSzB;
			}
		}

		// Token: 0x17000B0E RID: 2830
		// (get) Token: 0x06002FB6 RID: 12214 RVA: 0x00024618 File Offset: 0x00022818
		[CustomObfuscation(rename = false)]
		internal static ScriptingAPILevel scriptingAPILevel
		{
			get
			{
				return UnityTools.BRcKWlskLBqwgYdAbBDzHqTEoSVH;
			}
		}

		// Token: 0x17000B0F RID: 2831
		// (get) Token: 0x06002FB7 RID: 12215 RVA: 0x0002461F File Offset: 0x0002281F
		public static IExternalTools externalTools
		{
			get
			{
				if (!UnityTools.TeBVErRLvmBnpLFUKWgCkaNrhipy)
				{
					return null;
				}
				return UnityTools.suanviZxuKynKPlwmwTpiBOZmPiL;
			}
		}

		// Token: 0x17000B10 RID: 2832
		// (get) Token: 0x06002FB8 RID: 12216 RVA: 0x0002462F File Offset: 0x0002282F
		// (set) Token: 0x06002FB9 RID: 12217 RVA: 0x00024636 File Offset: 0x00022836
		internal static IAndroidFallbackPlatformHelper lRGJvbHYYtwJWseuIXpNcoFOvLDL { get; set; }

		// Token: 0x17000B11 RID: 2833
		// (get) Token: 0x06002FBA RID: 12218 RVA: 0x0002463E File Offset: 0x0002283E
		[CustomObfuscation(rename = false)]
		internal static bool isInitialized
		{
			get
			{
				return UnityTools.GQUiEiWpUaiuPDnTQXtEPymnnnEx;
			}
		}

		// Token: 0x17000B12 RID: 2834
		// (get) Token: 0x06002FBB RID: 12219 RVA: 0x00024645 File Offset: 0x00022845
		private static bool TeBVErRLvmBnpLFUKWgCkaNrhipy
		{
			get
			{
				return UnityTools.DVtZdfdufzkIavyGFSfQqlayLOet();
			}
		}

		// Token: 0x06002FBC RID: 12220 RVA: 0x000A6818 File Offset: 0x000A4A18
		private static bool DVtZdfdufzkIavyGFSfQqlayLOet()
		{
			if (UnityTools.GQUiEiWpUaiuPDnTQXtEPymnnnEx)
			{
				return true;
			}
			try
			{
				UnityTools.pYkRgFzmljIOaTHSzpvswAkWyCqg = Application.unityVersion;
				UnityTools.GKphzqwOhaugHxbtRLRFWRiDckVf = new UnityTools.UnityVersionClass(UnityTools.pYkRgFzmljIOaTHSzpvswAkWyCqg);
				UnityTools.LpkECHICHWjQVGVhXrplTrJUSZLK();
				UnityTools.GQUiEiWpUaiuPDnTQXtEPymnnnEx = true;
			}
			catch
			{
				Logger.LogError("Could not determine Unity version.");
			}
			return UnityTools.GQUiEiWpUaiuPDnTQXtEPymnnnEx;
		}

		// Token: 0x06002FBD RID: 12221 RVA: 0x000A6878 File Offset: 0x000A4A78
		internal static void lrutRDBRTqRQPWEynTmVnBSYKYnJ(UnityTools.YlequFlwSpDLySjTazqSoKcKCanv A_0)
		{
			if (!UnityTools.TeBVErRLvmBnpLFUKWgCkaNrhipy)
			{
				return;
			}
			if (A_0.PUBMBpURbtrqwjMzKnkdubHBAasQ == Platform.Windows81Store)
			{
				A_0.PUBMBpURbtrqwjMzKnkdubHBAasQ = Platform.WindowsUWP;
			}
			UnityTools.VGEdpOHQVjBjMVXteEGMWcUleyMH = A_0.PUBMBpURbtrqwjMzKnkdubHBAasQ;
			UnityTools.TMTxgoNYrgAmuBdAwgPQygozfTQF = A_0.DDtpBOjtOpADRjqPsRYiTmiWmpVm;
			UnityTools.fzybjvzaRzuUHlwpGfScijnxUgQi = A_0.CKUceEEUAQLrrMLRlPobKmQzKuuBA;
			UnityTools.ohgQeGghabDpGVctuhSnhLgzYULt = A_0.kzWArcCGSwWIHywpausYDnllCKan;
			UnityTools.UnVCySiTaGFvYapCKVMaQwOJvuSzB = A_0.OCFelIhndgWWedQMiDnFcAAtqUdQ;
			UnityTools.BRcKWlskLBqwgYdAbBDzHqTEoSVH = A_0.JWrfRNwYcvNDYPcLPfRNMnjHmqMR;
			if (UnityTools.suanviZxuKynKPlwmwTpiBOZmPiL != null)
			{
				UnityTools.suanviZxuKynKPlwmwTpiBOZmPiL.Destroy();
			}
			UnityTools.suanviZxuKynKPlwmwTpiBOZmPiL = A_0.QaEqUDBGtOeJsDUQHquCEbLEMUzxA;
			UnityTools.iJqJlQRpyMDMKcIizPKvDFHdevOCB = Debug.isDebugBuild;
			UnityTools.CuDTQIThAyMOBEJeVFLVWLymxvvm = true;
			UnityTools.OFNeCUEfsngVktJtaIFnwJNgmTibb();
		}

		// Token: 0x06002FBE RID: 12222 RVA: 0x00003E2B File Offset: 0x0000202B
		public static WebplayerPlatform DetermineWebplayerPlatformType(Platform platform, EditorPlatform editorPlatform)
		{
			return WebplayerPlatform.None;
		}

		// Token: 0x06002FBF RID: 12223 RVA: 0x000A6914 File Offset: 0x000A4B14
		public static bool IsUnityVersionInRange(string minVersionStr, string maxVersionStr)
		{
			if (!UnityTools.TeBVErRLvmBnpLFUKWgCkaNrhipy)
			{
				return false;
			}
			if (!string.IsNullOrEmpty(minVersionStr))
			{
				minVersionStr = Regex.Replace(minVersionStr, "[^0-9\\.a-zA-Z]", "", RegexOptions.IgnoreCase);
			}
			if (!string.IsNullOrEmpty(maxVersionStr))
			{
				maxVersionStr = Regex.Replace(maxVersionStr, "[^0-9\\.a-zA-Z]", "", RegexOptions.IgnoreCase);
			}
			int num;
			UnityTools.YUyyMCUhjCiKOnjhStkGRCCLYHjP(minVersionStr, out num);
			int num2;
			UnityTools.YUyyMCUhjCiKOnjhStkGRCCLYHjP(maxVersionStr, out num2);
			if (num > 0)
			{
				minVersionStr = num.ToString() + ".0.0b0";
			}
			if (num2 > 0)
			{
				maxVersionStr = (num2 + 1).ToString() + ".0.0b0";
			}
			bool flag = num > 0 || UnityTools.UnityVersionClass.IsValidVersionString(minVersionStr);
			bool flag2 = num2 > 0 || UnityTools.UnityVersionClass.IsValidVersionString(maxVersionStr);
			if (flag && UnityTools.GKphzqwOhaugHxbtRLRFWRiDckVf < new UnityTools.UnityVersionClass(minVersionStr))
			{
				return false;
			}
			if (num2 > 0)
			{
				if (flag2 && UnityTools.GKphzqwOhaugHxbtRLRFWRiDckVf >= new UnityTools.UnityVersionClass(maxVersionStr))
				{
					return false;
				}
			}
			else if (flag2 && UnityTools.GKphzqwOhaugHxbtRLRFWRiDckVf > new UnityTools.UnityVersionClass(maxVersionStr))
			{
				return false;
			}
			return true;
		}

		// Token: 0x06002FC0 RID: 12224 RVA: 0x000A6A08 File Offset: 0x000A4C08
		private static bool YUyyMCUhjCiKOnjhStkGRCCLYHjP(string A_0, out int A_1)
		{
			A_1 = 0;
			if (string.IsNullOrEmpty(A_0))
			{
				return false;
			}
			Match match = Regex.Match(A_0, "([0-9]+)[.]*[xX]");
			return match.Success && int.TryParse(match.Groups[1].Value, out A_1);
		}

		// Token: 0x06002FC1 RID: 12225 RVA: 0x0002464C File Offset: 0x0002284C
		private static void LpkECHICHWjQVGVhXrplTrJUSZLK()
		{
			UnityTools.hIgIGkmnuTEQuMvXztzTFPtkqHIC = UnityTools.pMxCJdfikCzJIejbbazWQcCythjaA(Application.unityVersion);
			if (UnityTools.hIgIGkmnuTEQuMvXztzTFPtkqHIC >= UnityTools.UnityVersion.UNITY_3_5 && UnityTools.hIgIGkmnuTEQuMvXztzTFPtkqHIC < UnityTools.UnityVersion.UNITY_4_0)
			{
				UnityTools.TFDuHlVEekpbJKttHGqHACziYqLt = true;
				return;
			}
			if (UnityTools.hIgIGkmnuTEQuMvXztzTFPtkqHIC >= UnityTools.UnityVersion.UNITY_4_0)
			{
				UnityTools.EAzuFTVhKAwSsrjGXoMWSmSyLLio = true;
			}
		}

		// Token: 0x06002FC2 RID: 12226 RVA: 0x000A6A54 File Offset: 0x000A4C54
		private static UnityTools.UnityVersion pMxCJdfikCzJIejbbazWQcCythjaA(string A_0)
		{
			if (string.IsNullOrEmpty(A_0))
			{
				return UnityTools.UnityVersion.Unknown;
			}
			string[] array = A_0.Split(new char[]
			{
				'.'
			});
			int num = array.Length;
			if (num >= 2)
			{
				int num2 = -1;
				string text = string.Empty;
				int num3;
				int.TryParse(array[0], out num3);
				int num4;
				int.TryParse(array[1], out num4);
				bool flag = false;
				int num5 = 0;
				if (num >= 3)
				{
					text = array[2];
					if (text.IndexOf('p', 0) >= 1)
					{
						flag = true;
					}
					if (!flag)
					{
						if (text != string.Empty)
						{
							int.TryParse(text[0].ToString() ?? "", out num2);
						}
					}
					else
					{
						string[] array2 = text.Split('p', StringSplitOptions.None);
						if (array2.Length != 0)
						{
							int.TryParse(array2[0][0].ToString() ?? "", out num2);
						}
						if (array2.Length > 1)
						{
							int.TryParse(array2[1][0].ToString() ?? "", out num5);
						}
					}
				}
				if (num3 == 2)
				{
					if (num4 == 6)
					{
						if (num2 == 1)
						{
							return UnityTools.UnityVersion.UNITY_2_6_1;
						}
						return UnityTools.UnityVersion.UNITY_2_6;
					}
				}
				else if (num3 == 3)
				{
					if (num4 == 0)
					{
						if (num2 == 0)
						{
							return UnityTools.UnityVersion.UNITY_3_0_0;
						}
						return UnityTools.UnityVersion.UNITY_3_0;
					}
					else
					{
						if (num4 == 1)
						{
							return UnityTools.UnityVersion.UNITY_3_1;
						}
						if (num4 == 2)
						{
							return UnityTools.UnityVersion.UNITY_3_2;
						}
						if (num4 == 3)
						{
							return UnityTools.UnityVersion.UNITY_3_3;
						}
						if (num4 == 4)
						{
							return UnityTools.UnityVersion.UNITY_3_4;
						}
						if (num4 != 5)
						{
							return UnityTools.UnityVersion.UNITY_3_5_7;
						}
						if (num2 == 2)
						{
							return UnityTools.UnityVersion.UNITY_3_5_2;
						}
						if (num2 == 7)
						{
							return UnityTools.UnityVersion.UNITY_3_5_7;
						}
						return UnityTools.UnityVersion.UNITY_3_5;
					}
				}
				else if (num3 == 4)
				{
					if (num4 == 0)
					{
						if (num2 == 1)
						{
							return UnityTools.UnityVersion.UNITY_4_0_1;
						}
						return UnityTools.UnityVersion.UNITY_4_0;
					}
					else
					{
						if (num4 == 1)
						{
							return UnityTools.UnityVersion.UNITY_4_1;
						}
						if (num4 == 2)
						{
							return UnityTools.UnityVersion.UNITY_4_2;
						}
						if (num4 == 3)
						{
							return UnityTools.UnityVersion.UNITY_4_3;
						}
						if (num4 == 4)
						{
							return UnityTools.UnityVersion.UNITY_4_4;
						}
						if (num4 == 5)
						{
							return UnityTools.UnityVersion.UNITY_4_5;
						}
						if (num4 == 6)
						{
							if (num2 == 3)
							{
								if (flag && num5 == 1)
								{
									return UnityTools.UnityVersion.UNITY_4_6_3p1;
								}
							}
							else if (num2 > 3)
							{
								return UnityTools.UnityVersion.UNITY_4_6_3p1Plus;
							}
							return UnityTools.UnityVersion.UNITY_4_6;
						}
						if (num4 == 7)
						{
							return UnityTools.UnityVersion.UNITY_4_7;
						}
						if (num4 == 8)
						{
							return UnityTools.UnityVersion.UNITY_4_8;
						}
						if (num4 == 9)
						{
							return UnityTools.UnityVersion.UNITY_4_9;
						}
						return UnityTools.UnityVersion.UNITY_4_0;
					}
				}
				else if (num3 == 5)
				{
					if (num4 == 0)
					{
						if (num2 == 0)
						{
							if (flag)
							{
								if (num5 == 1)
								{
									return UnityTools.UnityVersion.UNITY_5_0_0p1;
								}
								return UnityTools.UnityVersion.UNITY_5_0_0p1Plus;
							}
						}
						else
						{
							if (num2 == 1)
							{
								return UnityTools.UnityVersion.UNITY_5_0_1;
							}
							if (num2 == 2)
							{
								return UnityTools.UnityVersion.UNITY_5_0_2;
							}
						}
						return UnityTools.UnityVersion.UNITY_5_0;
					}
					if (num4 == 1)
					{
						return UnityTools.UnityVersion.UNITY_5_1;
					}
					if (num4 == 2)
					{
						return UnityTools.UnityVersion.UNITY_5_2;
					}
					if (num4 == 3)
					{
						return UnityTools.UnityVersion.UNITY_5_3;
					}
					if (num4 == 4)
					{
						return UnityTools.UnityVersion.UNITY_5_4;
					}
					if (num4 == 5)
					{
						return UnityTools.UnityVersion.UNITY_5_5;
					}
					if (num4 == 6)
					{
						return UnityTools.UnityVersion.UNITY_5_6;
					}
					if (num4 == 7)
					{
						return UnityTools.UnityVersion.UNITY_5_7;
					}
					if (num4 == 8)
					{
						return UnityTools.UnityVersion.UNITY_5_8;
					}
					if (num4 == 9)
					{
						return UnityTools.UnityVersion.UNITY_5_9;
					}
					return UnityTools.UnityVersion.UNITY_5_0;
				}
				else if (num3 == 2017)
				{
					if (num4 == 0)
					{
						return UnityTools.UnityVersion.UNITY_2017_0;
					}
					if (num4 == 1)
					{
						return UnityTools.UnityVersion.UNITY_2017_1;
					}
					if (num4 == 2)
					{
						return UnityTools.UnityVersion.UNITY_2017_2;
					}
					if (num4 == 3)
					{
						return UnityTools.UnityVersion.UNITY_2017_3;
					}
					if (num4 == 4)
					{
						return UnityTools.UnityVersion.UNITY_2017_4;
					}
					if (num4 == 5)
					{
						return UnityTools.UnityVersion.UNITY_2017_5;
					}
					if (num4 == 6)
					{
						return UnityTools.UnityVersion.UNITY_2017_6;
					}
					if (num4 == 7)
					{
						return UnityTools.UnityVersion.UNITY_2017_7;
					}
					if (num4 == 8)
					{
						return UnityTools.UnityVersion.UNITY_2017_8;
					}
					if (num4 == 9)
					{
						return UnityTools.UnityVersion.UNITY_2017_9;
					}
					return UnityTools.UnityVersion.UNITY_2017_0;
				}
				else if (num3 == 2018)
				{
					if (num4 == 0)
					{
						return UnityTools.UnityVersion.UNITY_2018_0;
					}
					if (num4 == 1)
					{
						return UnityTools.UnityVersion.UNITY_2018_1;
					}
					if (num4 == 2)
					{
						return UnityTools.UnityVersion.UNITY_2018_2;
					}
					if (num4 == 3)
					{
						return UnityTools.UnityVersion.UNITY_2018_3;
					}
					if (num4 == 4)
					{
						return UnityTools.UnityVersion.UNITY_2018_4;
					}
					if (num4 == 5)
					{
						return UnityTools.UnityVersion.UNITY_2018_5;
					}
					if (num4 == 6)
					{
						return UnityTools.UnityVersion.UNITY_2018_6;
					}
					if (num4 == 7)
					{
						return UnityTools.UnityVersion.UNITY_2018_7;
					}
					if (num4 == 8)
					{
						return UnityTools.UnityVersion.UNITY_2018_8;
					}
					if (num4 == 9)
					{
						return UnityTools.UnityVersion.UNITY_2018_9;
					}
					return UnityTools.UnityVersion.UNITY_2018_0;
				}
				else if (num3 == 2019)
				{
					if (num4 == 0)
					{
						return UnityTools.UnityVersion.UNITY_2019_0;
					}
					if (num4 == 1)
					{
						return UnityTools.UnityVersion.UNITY_2019_1;
					}
					if (num4 == 2)
					{
						return UnityTools.UnityVersion.UNITY_2019_2;
					}
					if (num4 == 3)
					{
						return UnityTools.UnityVersion.UNITY_2019_3;
					}
					if (num4 == 4)
					{
						return UnityTools.UnityVersion.UNITY_2019_4;
					}
					if (num4 == 5)
					{
						return UnityTools.UnityVersion.UNITY_2019_5;
					}
					if (num4 == 6)
					{
						return UnityTools.UnityVersion.UNITY_2019_6;
					}
					if (num4 == 7)
					{
						return UnityTools.UnityVersion.UNITY_2019_7;
					}
					if (num4 == 8)
					{
						return UnityTools.UnityVersion.UNITY_2019_8;
					}
					if (num4 == 9)
					{
						return UnityTools.UnityVersion.UNITY_2019_9;
					}
					return UnityTools.UnityVersion.UNITY_2019_0;
				}
				else if (num3 == 2020)
				{
					if (num4 == 0)
					{
						return UnityTools.UnityVersion.UNITY_2020_0;
					}
					if (num4 == 1)
					{
						return UnityTools.UnityVersion.UNITY_2020_1;
					}
					if (num4 == 2)
					{
						return UnityTools.UnityVersion.UNITY_2020_2;
					}
					if (num4 == 3)
					{
						return UnityTools.UnityVersion.UNITY_2020_3;
					}
					if (num4 == 4)
					{
						return UnityTools.UnityVersion.UNITY_2020_4;
					}
					if (num4 == 5)
					{
						return UnityTools.UnityVersion.UNITY_2020_5;
					}
					if (num4 == 6)
					{
						return UnityTools.UnityVersion.UNITY_2020_6;
					}
					if (num4 == 7)
					{
						return UnityTools.UnityVersion.UNITY_2020_7;
					}
					if (num4 == 8)
					{
						return UnityTools.UnityVersion.UNITY_2020_8;
					}
					if (num4 == 9)
					{
						return UnityTools.UnityVersion.UNITY_2020_9;
					}
					return UnityTools.UnityVersion.UNITY_2020_0;
				}
				else if (num3 == 2021)
				{
					if (num4 == 0)
					{
						return UnityTools.UnityVersion.UNITY_2021_0;
					}
					if (num4 == 1)
					{
						return UnityTools.UnityVersion.UNITY_2021_1;
					}
					if (num4 == 2)
					{
						return UnityTools.UnityVersion.UNITY_2021_2;
					}
					if (num4 == 3)
					{
						return UnityTools.UnityVersion.UNITY_2021_3;
					}
					if (num4 == 4)
					{
						return UnityTools.UnityVersion.UNITY_2021_4;
					}
					if (num4 == 5)
					{
						return UnityTools.UnityVersion.UNITY_2021_5;
					}
					if (num4 == 6)
					{
						return UnityTools.UnityVersion.UNITY_2021_6;
					}
					if (num4 == 7)
					{
						return UnityTools.UnityVersion.UNITY_2021_7;
					}
					if (num4 == 8)
					{
						return UnityTools.UnityVersion.UNITY_2021_8;
					}
					if (num4 == 9)
					{
						return UnityTools.UnityVersion.UNITY_2021_9;
					}
					return UnityTools.UnityVersion.UNITY_2021_0;
				}
				else if (num3 == 2022)
				{
					if (num4 == 0)
					{
						return UnityTools.UnityVersion.UNITY_2022_0;
					}
					if (num4 == 1)
					{
						return UnityTools.UnityVersion.UNITY_2022_1;
					}
					if (num4 == 2)
					{
						return UnityTools.UnityVersion.UNITY_2022_2;
					}
					if (num4 == 3)
					{
						return UnityTools.UnityVersion.UNITY_2022_3;
					}
					if (num4 == 4)
					{
						return UnityTools.UnityVersion.UNITY_2022_4;
					}
					if (num4 == 5)
					{
						return UnityTools.UnityVersion.UNITY_2022_5;
					}
					if (num4 == 6)
					{
						return UnityTools.UnityVersion.UNITY_2022_6;
					}
					if (num4 == 7)
					{
						return UnityTools.UnityVersion.UNITY_2022_7;
					}
					if (num4 == 8)
					{
						return UnityTools.UnityVersion.UNITY_2022_8;
					}
					if (num4 == 9)
					{
						return UnityTools.UnityVersion.UNITY_2022_9;
					}
					return UnityTools.UnityVersion.UNITY_2022_0;
				}
				else if (num3 == 2023)
				{
					if (num4 == 0)
					{
						return UnityTools.UnityVersion.UNITY_2023_0;
					}
					if (num4 == 1)
					{
						return UnityTools.UnityVersion.UNITY_2023_1;
					}
					if (num4 == 2)
					{
						return UnityTools.UnityVersion.UNITY_2023_2;
					}
					if (num4 == 3)
					{
						return UnityTools.UnityVersion.UNITY_2023_3;
					}
					if (num4 == 4)
					{
						return UnityTools.UnityVersion.UNITY_2023_4;
					}
					if (num4 == 5)
					{
						return UnityTools.UnityVersion.UNITY_2023_5;
					}
					if (num4 == 6)
					{
						return UnityTools.UnityVersion.UNITY_2023_6;
					}
					if (num4 == 7)
					{
						return UnityTools.UnityVersion.UNITY_2023_7;
					}
					if (num4 == 8)
					{
						return UnityTools.UnityVersion.UNITY_2023_8;
					}
					if (num4 == 9)
					{
						return UnityTools.UnityVersion.UNITY_2023_9;
					}
					return UnityTools.UnityVersion.UNITY_2023_0;
				}
				else if (num3 == 6000)
				{
					if (num4 == 0)
					{
						return UnityTools.UnityVersion.UNITY_6000_0;
					}
					if (num4 == 1)
					{
						return UnityTools.UnityVersion.UNITY_6000_1;
					}
					if (num4 == 2)
					{
						return UnityTools.UnityVersion.UNITY_6000_2;
					}
					if (num4 == 3)
					{
						return UnityTools.UnityVersion.UNITY_6000_3;
					}
					if (num4 == 4)
					{
						return UnityTools.UnityVersion.UNITY_6000_4;
					}
					if (num4 == 5)
					{
						return UnityTools.UnityVersion.UNITY_6000_5;
					}
					if (num4 == 6)
					{
						return UnityTools.UnityVersion.UNITY_6000_6;
					}
					if (num4 == 7)
					{
						return UnityTools.UnityVersion.UNITY_6000_7;
					}
					if (num4 == 8)
					{
						return UnityTools.UnityVersion.UNITY_6000_8;
					}
					if (num4 == 9)
					{
						return UnityTools.UnityVersion.UNITY_6000_9;
					}
					return UnityTools.UnityVersion.UNITY_6000_0;
				}
				else if (num3 == 7000)
				{
					if (num4 == 0)
					{
						return UnityTools.UnityVersion.UNITY_7000_0;
					}
					if (num4 == 1)
					{
						return UnityTools.UnityVersion.UNITY_7000_1;
					}
					if (num4 == 2)
					{
						return UnityTools.UnityVersion.UNITY_7000_2;
					}
					if (num4 == 3)
					{
						return UnityTools.UnityVersion.UNITY_7000_3;
					}
					if (num4 == 4)
					{
						return UnityTools.UnityVersion.UNITY_7000_4;
					}
					if (num4 == 5)
					{
						return UnityTools.UnityVersion.UNITY_7000_5;
					}
					if (num4 == 6)
					{
						return UnityTools.UnityVersion.UNITY_7000_6;
					}
					if (num4 == 7)
					{
						return UnityTools.UnityVersion.UNITY_7000_7;
					}
					if (num4 == 8)
					{
						return UnityTools.UnityVersion.UNITY_7000_8;
					}
					if (num4 == 9)
					{
						return UnityTools.UnityVersion.UNITY_7000_9;
					}
					return UnityTools.UnityVersion.UNITY_7000_0;
				}
				else if (num3 == 8000)
				{
					if (num4 == 0)
					{
						return UnityTools.UnityVersion.UNITY_8000_0;
					}
					if (num4 == 1)
					{
						return UnityTools.UnityVersion.UNITY_8000_1;
					}
					if (num4 == 2)
					{
						return UnityTools.UnityVersion.UNITY_8000_2;
					}
					if (num4 == 3)
					{
						return UnityTools.UnityVersion.UNITY_8000_3;
					}
					if (num4 == 4)
					{
						return UnityTools.UnityVersion.UNITY_8000_4;
					}
					if (num4 == 5)
					{
						return UnityTools.UnityVersion.UNITY_8000_5;
					}
					if (num4 == 6)
					{
						return UnityTools.UnityVersion.UNITY_8000_6;
					}
					if (num4 == 7)
					{
						return UnityTools.UnityVersion.UNITY_8000_7;
					}
					if (num4 == 8)
					{
						return UnityTools.UnityVersion.UNITY_8000_8;
					}
					if (num4 == 9)
					{
						return UnityTools.UnityVersion.UNITY_8000_9;
					}
					return UnityTools.UnityVersion.UNITY_8000_0;
				}
				else if (num3 == 9000)
				{
					if (num4 == 0)
					{
						return UnityTools.UnityVersion.UNITY_9000_0;
					}
					if (num4 == 1)
					{
						return UnityTools.UnityVersion.UNITY_9000_1;
					}
					if (num4 == 2)
					{
						return UnityTools.UnityVersion.UNITY_9000_2;
					}
					if (num4 == 3)
					{
						return UnityTools.UnityVersion.UNITY_9000_3;
					}
					if (num4 == 4)
					{
						return UnityTools.UnityVersion.UNITY_9000_4;
					}
					if (num4 == 5)
					{
						return UnityTools.UnityVersion.UNITY_9000_5;
					}
					if (num4 == 6)
					{
						return UnityTools.UnityVersion.UNITY_9000_6;
					}
					if (num4 == 7)
					{
						return UnityTools.UnityVersion.UNITY_9000_7;
					}
					if (num4 == 8)
					{
						return UnityTools.UnityVersion.UNITY_9000_8;
					}
					if (num4 == 9)
					{
						return UnityTools.UnityVersion.UNITY_9000_9;
					}
					return UnityTools.UnityVersion.UNITY_9000_0;
				}
			}
			return UnityTools.UnityVersion.Unknown;
		}

		// Token: 0x06002FC3 RID: 12227 RVA: 0x000A707C File Offset: 0x000A527C
		private static UnityTools.UnityVersion WfjyZTVbilfJbThswCJlAIrlOmVeb(int A_0)
		{
			if (A_0 <= 6000)
			{
				switch (A_0)
				{
				case 3:
					return UnityTools.UnityVersion.UNITY_3_0;
				case 4:
					return UnityTools.UnityVersion.UNITY_4_0;
				case 5:
					return UnityTools.UnityVersion.UNITY_5_0;
				default:
					switch (A_0)
					{
					case 2017:
						return UnityTools.UnityVersion.UNITY_2017_0;
					case 2018:
						return UnityTools.UnityVersion.UNITY_2018_0;
					case 2019:
						return UnityTools.UnityVersion.UNITY_2019_0;
					case 2020:
						return UnityTools.UnityVersion.UNITY_2020_0;
					case 2021:
						return UnityTools.UnityVersion.UNITY_2021_0;
					case 2022:
						return UnityTools.UnityVersion.UNITY_2022_0;
					case 2023:
						return UnityTools.UnityVersion.UNITY_2023_0;
					default:
						if (A_0 == 6000)
						{
							return UnityTools.UnityVersion.UNITY_6000_0;
						}
						break;
					}
					break;
				}
			}
			else
			{
				if (A_0 == 7000)
				{
					return UnityTools.UnityVersion.UNITY_7000_0;
				}
				if (A_0 == 8000)
				{
					return UnityTools.UnityVersion.UNITY_8000_0;
				}
				if (A_0 == 9000)
				{
					return UnityTools.UnityVersion.UNITY_9000_0;
				}
			}
			return UnityTools.UnityVersion.Unknown;
		}

		// Token: 0x06002FC4 RID: 12228 RVA: 0x000A7128 File Offset: 0x000A5328
		private static UnityTools.UnityVersion lXgOpvyPzhAEMeZIgMJtktZehWKy(int A_0)
		{
			if (A_0 <= 6000)
			{
				switch (A_0)
				{
				case 3:
					return UnityTools.UnityVersion.UNITY_3_MAX;
				case 4:
					return UnityTools.UnityVersion.UNITY_4_MAX;
				case 5:
					return UnityTools.UnityVersion.UNITY_5_MAX;
				default:
					switch (A_0)
					{
					case 2017:
						return UnityTools.UnityVersion.UNITY_2017_MAX;
					case 2018:
						return UnityTools.UnityVersion.UNITY_2018_MAX;
					case 2019:
						return UnityTools.UnityVersion.UNITY_2019_MAX;
					case 2020:
						return UnityTools.UnityVersion.UNITY_2020_MAX;
					case 2021:
						return UnityTools.UnityVersion.UNITY_2021_MAX;
					case 2022:
						return UnityTools.UnityVersion.UNITY_2022_MAX;
					case 2023:
						return UnityTools.UnityVersion.UNITY_2023_MAX;
					default:
						if (A_0 == 6000)
						{
							return UnityTools.UnityVersion.UNITY_6000_MAX;
						}
						break;
					}
					break;
				}
			}
			else
			{
				if (A_0 == 7000)
				{
					return UnityTools.UnityVersion.UNITY_7000_MAX;
				}
				if (A_0 == 8000)
				{
					return UnityTools.UnityVersion.UNITY_8000_MAX;
				}
				if (A_0 == 9000)
				{
					return UnityTools.UnityVersion.UNITY_9000_MAX;
				}
			}
			return UnityTools.UnityVersion.Unknown;
		}

		// Token: 0x06002FC5 RID: 12229 RVA: 0x000A71D8 File Offset: 0x000A53D8
		private static void OFNeCUEfsngVktJtaIFnwJNgmTibb()
		{
			Platform vgedpOHQVjBjMVXteEGMWcUleyMH = UnityTools.VGEdpOHQVjBjMVXteEGMWcUleyMH;
			if (vgedpOHQVjBjMVXteEGMWcUleyMH <= Platform.Linux)
			{
				if (vgedpOHQVjBjMVXteEGMWcUleyMH != Platform.Windows)
				{
					if (vgedpOHQVjBjMVXteEGMWcUleyMH == Platform.Linux)
					{
						UnityTools.wrqFejyuClBnIajkStauqiBLhRWi = true;
					}
				}
				else if ((UnityTools.hIgIGkmnuTEQuMvXztzTFPtkqHIC >= UnityTools.UnityVersion.UNITY_4_6_3p1 && UnityTools.hIgIGkmnuTEQuMvXztzTFPtkqHIC < UnityTools.UnityVersion.UNITY_5_0) || UnityTools.hIgIGkmnuTEQuMvXztzTFPtkqHIC >= UnityTools.UnityVersion.UNITY_5_0_0p1)
				{
					UnityTools.kRHYcljAhypnvdQEfnereSpyQnDk = true;
					UnityTools.ZmzfqNnonvVqzIzfmazzUSfkkrGl = true;
				}
			}
			else
			{
				if (vgedpOHQVjBjMVXteEGMWcUleyMH != Platform.Android)
				{
					if (vgedpOHQVjBjMVXteEGMWcUleyMH == Platform.PS4)
					{
						UnityTools.ZmzfqNnonvVqzIzfmazzUSfkkrGl = true;
						UnityTools.mbhPamKrjmxDtAsVaIdHnnhhbPBf = "Empty";
						UnityTools.rLtYqQbkgqhxolczdfCkMJzKMXCn = true;
						goto IL_79;
					}
					if (vgedpOHQVjBjMVXteEGMWcUleyMH - Platform.AmazonFireTV > 1)
					{
						goto IL_79;
					}
				}
				UnityTools.ZmzfqNnonvVqzIzfmazzUSfkkrGl = true;
				UnityTools.wrqFejyuClBnIajkStauqiBLhRWi = true;
			}
			IL_79:
			if (UnityTools.fzybjvzaRzuUHlwpGfScijnxUgQi && UnityTools.TMTxgoNYrgAmuBdAwgPQygozfTQF == EditorPlatform.Windows && ((UnityTools.hIgIGkmnuTEQuMvXztzTFPtkqHIC >= UnityTools.UnityVersion.UNITY_4_6_3p1 && UnityTools.hIgIGkmnuTEQuMvXztzTFPtkqHIC < UnityTools.UnityVersion.UNITY_5_0) || UnityTools.hIgIGkmnuTEQuMvXztzTFPtkqHIC >= UnityTools.UnityVersion.UNITY_5_0_0p1))
			{
				UnityTools.kRHYcljAhypnvdQEfnereSpyQnDk = true;
				UnityTools.ZmzfqNnonvVqzIzfmazzUSfkkrGl = true;
			}
			if ((!UnityTools.fzybjvzaRzuUHlwpGfScijnxUgQi && UnityTools.VGEdpOHQVjBjMVXteEGMWcUleyMH == Platform.Windows) || (UnityTools.fzybjvzaRzuUHlwpGfScijnxUgQi && UnityTools.TMTxgoNYrgAmuBdAwgPQygozfTQF == EditorPlatform.Windows))
			{
				UnityTools.bmswVZhIlrqttGHbtDXgfFcmFNsHb = (UnityTools.hIgIGkmnuTEQuMvXztzTFPtkqHIC >= UnityTools.UnityVersion.UNITY_2021_2);
			}
		}

		// Token: 0x06002FC6 RID: 12230 RVA: 0x00024684 File Offset: 0x00022884
		internal static Type eoYEJDGmpkyUHDEPvxUXMNqVGtxYA(XppZCucuJPakkgxZycZuSSJmDiLR A_0)
		{
			if (!UnityTools.TeBVErRLvmBnpLFUKWgCkaNrhipy)
			{
				return null;
			}
			if (UnityTools.hIgIGkmnuTEQuMvXztzTFPtkqHIC >= UnityTools.UnityVersion.UNITY_4_3)
			{
				return UnityTools.piKElPHKFvgCnjPkoFgtQIeXpOSh(A_0);
			}
			return null;
		}

		// Token: 0x06002FC7 RID: 12231 RVA: 0x000A72C4 File Offset: 0x000A54C4
		private static Type piKElPHKFvgCnjPkoFgtQIeXpOSh(XppZCucuJPakkgxZycZuSSJmDiLR A_0)
		{
			if (A_0 == XppZCucuJPakkgxZycZuSSJmDiLR.RigidbodyInterpolation2D)
			{
				return typeof(RigidbodyInterpolation2D);
			}
			if (A_0 == XppZCucuJPakkgxZycZuSSJmDiLR.RigidbodySleepMode2D)
			{
				return typeof(RigidbodySleepMode2D);
			}
			if (A_0 == XppZCucuJPakkgxZycZuSSJmDiLR.CollisionDetectionMode2D)
			{
				return typeof(CollisionDetectionMode2D);
			}
			if (A_0 == XppZCucuJPakkgxZycZuSSJmDiLR.PhysicsMaterial2D)
			{
				return typeof(PhysicsMaterial2D);
			}
			if (A_0 == XppZCucuJPakkgxZycZuSSJmDiLR.Collider2D)
			{
				return typeof(Collider2D);
			}
			return null;
		}

		// Token: 0x06002FC8 RID: 12232 RVA: 0x000A731C File Offset: 0x000A551C
		public static List<string> GetCurrentPlatformResourecesDLLPaths()
		{
			if (!UnityTools.TeBVErRLvmBnpLFUKWgCkaNrhipy)
			{
				return null;
			}
			List<string> list = new List<string>();
			Platform platform = UnityTools.platform;
			if (platform != Platform.Windows)
			{
				if (platform != Platform.OSX)
				{
					if (platform == Platform.Linux)
					{
						list.Add("Libs/Rewired_Linux");
					}
				}
				else
				{
					list.Add("Libs/Rewired_OSX");
				}
			}
			else
			{
				list.Add("Libs/Rewired_Windows");
			}
			return list;
		}

		// Token: 0x06002FC9 RID: 12233 RVA: 0x000A7374 File Offset: 0x000A5574
		public static Transform FindTransformInChildren(Transform transform, string name)
		{
			if (transform == null)
			{
				return null;
			}
			int childCount = transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				Transform child = transform.GetChild(i);
				if (child.name == name)
				{
					return child;
				}
				Transform transform2 = UnityTools.FindTransformInChildren(child, name);
				if (transform2 != null)
				{
					return transform2;
				}
			}
			return null;
		}

		// Token: 0x06002FCA RID: 12234 RVA: 0x000246A0 File Offset: 0x000228A0
		public static Transform FindTransformInChildren(GameObject gameObject, string name)
		{
			if (gameObject == null)
			{
				return null;
			}
			return UnityTools.FindTransformInChildren(gameObject.transform, name);
		}

		// Token: 0x06002FCB RID: 12235 RVA: 0x000A73CC File Offset: 0x000A55CC
		public static GameObject FindGameObjectInChildren(GameObject gameObject, string name)
		{
			if (gameObject == null)
			{
				return null;
			}
			Transform transform = UnityTools.FindTransformInChildren(gameObject.transform, name);
			if (!(transform != null))
			{
				return null;
			}
			return transform.gameObject;
		}

		// Token: 0x06002FCC RID: 12236 RVA: 0x000A7404 File Offset: 0x000A5604
		public static GameObject FindGameObjectInChildren(Transform transform, string name)
		{
			if (transform == null)
			{
				return null;
			}
			Transform transform2 = UnityTools.FindTransformInChildren(transform, name);
			if (transform2 == null)
			{
				return null;
			}
			return transform2.gameObject;
		}

		// Token: 0x06002FCD RID: 12237 RVA: 0x000A7438 File Offset: 0x000A5638
		public static T GetComponent<T>(Transform transform) where T : class
		{
			if (transform == null)
			{
				return default(T);
			}
			return UnityTools.GetComponent<T>(transform.gameObject);
		}

		// Token: 0x06002FCE RID: 12238 RVA: 0x000A7438 File Offset: 0x000A5638
		public static T GetComponent<T>(Component component) where T : class
		{
			if (component == null)
			{
				return default(T);
			}
			return UnityTools.GetComponent<T>(component.gameObject);
		}

		// Token: 0x06002FCF RID: 12239 RVA: 0x000A7464 File Offset: 0x000A5664
		public static T GetComponent<T>(GameObject gameObject) where T : class
		{
			if (gameObject == null)
			{
				return default(T);
			}
			return UnityTools.qgFcUKuZIHGdmJlzPfmViRMAImwj<T>(gameObject.GetComponent(typeof(T)) as T);
		}

		// Token: 0x06002FD0 RID: 12240 RVA: 0x000A74A4 File Offset: 0x000A56A4
		public static T GetComponent<T>(Transform transform, bool includeDisabledComponents) where T : class
		{
			if (transform == null)
			{
				return default(T);
			}
			return UnityTools.GetComponent<T>(transform.gameObject, includeDisabledComponents);
		}

		// Token: 0x06002FD1 RID: 12241 RVA: 0x000A74A4 File Offset: 0x000A56A4
		public static T GetComponent<T>(Component component, bool includeDisabledComponents) where T : class
		{
			if (component == null)
			{
				return default(T);
			}
			return UnityTools.GetComponent<T>(component.gameObject, includeDisabledComponents);
		}

		// Token: 0x06002FD2 RID: 12242 RVA: 0x000A74D0 File Offset: 0x000A56D0
		public static T GetComponent<T>(GameObject gameObject, bool includeDisabledComponents) where T : class
		{
			if (gameObject == null)
			{
				return default(T);
			}
			using (TempListPool.TList<Component> tlist = TempListPool.GetTList<Component>())
			{
				List<Component> list = tlist.list;
				UnityTools.GetComponents(gameObject, list, false);
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					T t = list[i] as T;
					if (!UnityTools.IsNullOrDestroyed<T>(t) && (includeDisabledComponents || UnityTools.IsEnabled(list[i])))
					{
						return t;
					}
				}
			}
			return default(T);
		}

		// Token: 0x06002FD3 RID: 12243 RVA: 0x000246B9 File Offset: 0x000228B9
		public static Component GetComponent(Transform transform, Type type, bool includeDisabledComponents)
		{
			if (transform == null)
			{
				return null;
			}
			return UnityTools.GetComponent(transform.gameObject, type, includeDisabledComponents);
		}

		// Token: 0x06002FD4 RID: 12244 RVA: 0x000246B9 File Offset: 0x000228B9
		public static Component GetComponent(Component component, Type type, bool includeDisabledComponents)
		{
			if (component == null)
			{
				return null;
			}
			return UnityTools.GetComponent(component.gameObject, type, includeDisabledComponents);
		}

		// Token: 0x06002FD5 RID: 12245 RVA: 0x000A757C File Offset: 0x000A577C
		public static Component GetComponent(GameObject gameObject, Type type, bool includeDisabledComponents)
		{
			if (gameObject == null)
			{
				return null;
			}
			using (TempListPool.TList<Component> tlist = TempListPool.GetTList<Component>())
			{
				List<Component> list = tlist.list;
				UnityTools.GetComponents(gameObject, list, false);
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					if (ReflectionTools.DoesTypeImplement(list[i].GetType(), type) && (includeDisabledComponents || UnityTools.IsEnabled(list[i])))
					{
						return list[i];
					}
				}
			}
			return null;
		}

		// Token: 0x06002FD6 RID: 12246 RVA: 0x000246D3 File Offset: 0x000228D3
		public static Component GetComponent(Transform transform, Type type)
		{
			if (transform == null)
			{
				return null;
			}
			return UnityTools.GetComponent(transform.gameObject, type);
		}

		// Token: 0x06002FD7 RID: 12247 RVA: 0x000246D3 File Offset: 0x000228D3
		public static Component GetComponent(Component component, Type type)
		{
			if (component == null)
			{
				return null;
			}
			return UnityTools.GetComponent(component.gameObject, type);
		}

		// Token: 0x06002FD8 RID: 12248 RVA: 0x000A7610 File Offset: 0x000A5810
		public static Component GetComponent(GameObject gameObject, Type type)
		{
			if (gameObject == null)
			{
				return null;
			}
			using (TempListPool.TList<Component> tlist = TempListPool.GetTList<Component>())
			{
				List<Component> list = tlist.list;
				UnityTools.GetComponents(gameObject, list, false);
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					if (ReflectionTools.DoesTypeImplement(list[i].GetType(), type))
					{
						return list[i];
					}
				}
			}
			return null;
		}

		// Token: 0x06002FD9 RID: 12249 RVA: 0x000A7690 File Offset: 0x000A5890
		public static T GetComponentInChildren<T>(GameObject gameObject) where T : class
		{
			if (gameObject == null)
			{
				return default(T);
			}
			return UnityTools.GetComponentInChildren<T>(gameObject.transform);
		}

		// Token: 0x06002FDA RID: 12250 RVA: 0x000A76BC File Offset: 0x000A58BC
		public static T GetComponentInChildren<T>(Component component) where T : class
		{
			if (component == null)
			{
				return default(T);
			}
			return UnityTools.GetComponentInChildren<T>(component.transform);
		}

		// Token: 0x06002FDB RID: 12251 RVA: 0x000A76E8 File Offset: 0x000A58E8
		public static T GetComponentInChildren<T>(Transform transform) where T : class
		{
			if (transform == null)
			{
				return default(T);
			}
			int childCount = transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				Transform child = transform.GetChild(i);
				T component = UnityTools.GetComponent<T>(child);
				if (!UnityTools.IsNullOrDestroyed<T>(component))
				{
					return component;
				}
				T componentInChildren = UnityTools.GetComponentInChildren<T>(child);
				if (!UnityTools.IsNullOrDestroyed<T>(componentInChildren))
				{
					return componentInChildren;
				}
			}
			return default(T);
		}

		// Token: 0x06002FDC RID: 12252 RVA: 0x000A7754 File Offset: 0x000A5954
		public static T GetComponentInChildren<T>(GameObject gameObject, UnityTools.GetComponentFlags options) where T : class
		{
			if (gameObject == null)
			{
				return default(T);
			}
			return UnityTools.GetComponentInChildren<T>(gameObject.transform, options);
		}

		// Token: 0x06002FDD RID: 12253 RVA: 0x000A7780 File Offset: 0x000A5980
		public static T GetComponentInChildren<T>(Component component, UnityTools.GetComponentFlags options) where T : class
		{
			if (component == null)
			{
				return default(T);
			}
			return UnityTools.GetComponentInChildren<T>(component.transform, options);
		}

		// Token: 0x06002FDE RID: 12254 RVA: 0x000A77AC File Offset: 0x000A59AC
		public static T GetComponentInChildren<T>(Transform transform, UnityTools.GetComponentFlags options) where T : class
		{
			if (transform == null)
			{
				return default(T);
			}
			int childCount = transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				Transform child = transform.GetChild(i);
				if (!(child == null) && ((options & UnityTools.GetComponentFlags.SkipInactiveGameObjectRelatives) == UnityTools.GetComponentFlags.None || child.gameObject.activeSelf))
				{
					T component = UnityTools.GetComponent<T>(child, (options & UnityTools.GetComponentFlags.SkipDisabledComponents) == UnityTools.GetComponentFlags.None);
					if (!UnityTools.IsNullOrDestroyed<T>(component))
					{
						return component;
					}
					T componentInChildren = UnityTools.GetComponentInChildren<T>(child, options);
					if (!UnityTools.IsNullOrDestroyed<T>(componentInChildren))
					{
						return componentInChildren;
					}
				}
			}
			return default(T);
		}

		// Token: 0x06002FDF RID: 12255 RVA: 0x000246EC File Offset: 0x000228EC
		public static Component GetComponentInChildren(GameObject gameObject, Type type)
		{
			if (gameObject == null)
			{
				return null;
			}
			return UnityTools.GetComponentInChildren(gameObject.transform, type);
		}

		// Token: 0x06002FE0 RID: 12256 RVA: 0x00024705 File Offset: 0x00022905
		public static Component GetComponentInChildren(Component component, Type type)
		{
			if (component == null)
			{
				return null;
			}
			return UnityTools.GetComponentInChildren(component.transform, type);
		}

		// Token: 0x06002FE1 RID: 12257 RVA: 0x000A783C File Offset: 0x000A5A3C
		public static Component GetComponentInChildren(Transform transform, Type type)
		{
			if (transform == null)
			{
				return null;
			}
			int childCount = transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				Transform child = transform.GetChild(i);
				Component component = UnityTools.GetComponent(child, type);
				if (!UnityTools.IsNullOrDestroyed<Component>(component))
				{
					return component;
				}
				Component componentInChildren = UnityTools.GetComponentInChildren(child, type);
				if (!UnityTools.IsNullOrDestroyed<Component>(componentInChildren))
				{
					return componentInChildren;
				}
			}
			return null;
		}

		// Token: 0x06002FE2 RID: 12258 RVA: 0x0002471E File Offset: 0x0002291E
		public static Component GetComponentInChildren(GameObject gameObject, Type type, UnityTools.GetComponentFlags options)
		{
			if (gameObject == null)
			{
				return null;
			}
			return UnityTools.GetComponentInChildren(gameObject.transform, type, options);
		}

		// Token: 0x06002FE3 RID: 12259 RVA: 0x00024738 File Offset: 0x00022938
		public static Component GetComponentInChildren(Component component, Type type, UnityTools.GetComponentFlags options)
		{
			if (component == null)
			{
				return null;
			}
			return UnityTools.GetComponentInChildren(component.transform, type, options);
		}

		// Token: 0x06002FE4 RID: 12260 RVA: 0x000A7898 File Offset: 0x000A5A98
		public static Component GetComponentInChildren(Transform transform, Type type, UnityTools.GetComponentFlags options)
		{
			if (transform == null)
			{
				return null;
			}
			int childCount = transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				Transform child = transform.GetChild(i);
				if (!(child == null) && ((options & UnityTools.GetComponentFlags.SkipInactiveGameObjectRelatives) == UnityTools.GetComponentFlags.None || child.gameObject.activeSelf))
				{
					Component component = UnityTools.GetComponent(child, type, (options & UnityTools.GetComponentFlags.SkipDisabledComponents) == UnityTools.GetComponentFlags.None);
					if (!UnityTools.IsNullOrDestroyed<Component>(component))
					{
						return component;
					}
					Component componentInChildren = UnityTools.GetComponentInChildren(child, type);
					if (!UnityTools.IsNullOrDestroyed<Component>(componentInChildren))
					{
						return componentInChildren;
					}
				}
			}
			return null;
		}

		// Token: 0x06002FE5 RID: 12261 RVA: 0x000A7914 File Offset: 0x000A5B14
		public static T GetComponentInSelfOrChildren<T>(Transform transform) where T : class
		{
			if (transform == null)
			{
				return default(T);
			}
			return UnityTools.GetComponentInSelfOrChildren<T>(transform.gameObject);
		}

		// Token: 0x06002FE6 RID: 12262 RVA: 0x000A7914 File Offset: 0x000A5B14
		public static T GetComponentInSelfOrChildren<T>(Component component) where T : class
		{
			if (component == null)
			{
				return default(T);
			}
			return UnityTools.GetComponentInSelfOrChildren<T>(component.gameObject);
		}

		// Token: 0x06002FE7 RID: 12263 RVA: 0x000A7940 File Offset: 0x000A5B40
		public static T GetComponentInSelfOrChildren<T>(GameObject gameObject) where T : class
		{
			if (gameObject == null)
			{
				return default(T);
			}
			T component = UnityTools.GetComponent<T>(gameObject);
			if (UnityTools.IsNullOrDestroyed<T>(component))
			{
				return UnityTools.GetComponentInChildren<T>(gameObject);
			}
			return component;
		}

		// Token: 0x06002FE8 RID: 12264 RVA: 0x000A7978 File Offset: 0x000A5B78
		public static T GetComponentInSelfOrChildren<T>(Transform transform, UnityTools.GetComponentFlags options) where T : class
		{
			if (transform == null)
			{
				return default(T);
			}
			return UnityTools.GetComponentInSelfOrChildren<T>(transform.gameObject, options);
		}

		// Token: 0x06002FE9 RID: 12265 RVA: 0x000A7978 File Offset: 0x000A5B78
		public static T GetComponentInSelfOrChildren<T>(Component component, UnityTools.GetComponentFlags options) where T : class
		{
			if (component == null)
			{
				return default(T);
			}
			return UnityTools.GetComponentInSelfOrChildren<T>(component.gameObject, options);
		}

		// Token: 0x06002FEA RID: 12266 RVA: 0x000A79A4 File Offset: 0x000A5BA4
		public static T GetComponentInSelfOrChildren<T>(GameObject gameObject, UnityTools.GetComponentFlags options) where T : class
		{
			if (gameObject == null)
			{
				return default(T);
			}
			T component = UnityTools.GetComponent<T>(gameObject, (options & UnityTools.GetComponentFlags.SkipDisabledComponents) == UnityTools.GetComponentFlags.None);
			if (UnityTools.IsNullOrDestroyed<T>(component))
			{
				return UnityTools.GetComponentInChildren<T>(gameObject, options);
			}
			return component;
		}

		// Token: 0x06002FEB RID: 12267 RVA: 0x000A79E4 File Offset: 0x000A5BE4
		public static T GetComponentInParents<T>(GameObject gameObject) where T : class
		{
			if (gameObject == null)
			{
				return default(T);
			}
			return UnityTools.GetComponentInParents<T>(gameObject.transform);
		}

		// Token: 0x06002FEC RID: 12268 RVA: 0x000A7A10 File Offset: 0x000A5C10
		public static T GetComponentInParents<T>(Component component) where T : class
		{
			if (component == null)
			{
				return default(T);
			}
			return UnityTools.GetComponentInParents<T>(component.transform);
		}

		// Token: 0x06002FED RID: 12269 RVA: 0x000A7A3C File Offset: 0x000A5C3C
		public static T GetComponentInParents<T>(Transform transform) where T : class
		{
			if (transform == null)
			{
				return default(T);
			}
			while ((transform = transform.parent) != null)
			{
				T t = transform.GetComponent(typeof(T)) as T;
				if (!UnityTools.IsNullOrDestroyed<T>(t))
				{
					return t;
				}
			}
			return default(T);
		}

		// Token: 0x06002FEE RID: 12270 RVA: 0x000A7A9C File Offset: 0x000A5C9C
		public static T GetComponentInSelfOrParents<T>(GameObject gameObject) where T : class
		{
			if (gameObject == null)
			{
				return default(T);
			}
			return UnityTools.GetComponentInSelfOrParents<T>(gameObject.transform);
		}

		// Token: 0x06002FEF RID: 12271 RVA: 0x000A7AC8 File Offset: 0x000A5CC8
		public static T GetComponentInSelfOrParents<T>(Component component) where T : class
		{
			if (component == null)
			{
				return default(T);
			}
			return UnityTools.GetComponentInSelfOrParents<T>(component.transform);
		}

		// Token: 0x06002FF0 RID: 12272 RVA: 0x000A7AF4 File Offset: 0x000A5CF4
		public static T GetComponentInSelfOrParents<T>(Transform transform) where T : class
		{
			if (transform == null)
			{
				return default(T);
			}
			T t = transform.GetComponent(typeof(T)) as T;
			if (!UnityTools.IsNullOrDestroyed<T>(t))
			{
				return t;
			}
			while ((transform = transform.parent) != null)
			{
				t = (transform.GetComponent(typeof(T)) as T);
				if (!UnityTools.IsNullOrDestroyed<T>(t))
				{
					return t;
				}
			}
			return default(T);
		}

		// Token: 0x06002FF1 RID: 12273 RVA: 0x00024752 File Offset: 0x00022952
		public static List<T> GetComponents<T>(Transform transform) where T : class
		{
			if (transform == null)
			{
				return new List<T>();
			}
			return UnityTools.GetComponents<T>(transform.gameObject);
		}

		// Token: 0x06002FF2 RID: 12274 RVA: 0x00024752 File Offset: 0x00022952
		public static List<T> GetComponents<T>(Component component) where T : class
		{
			if (component == null)
			{
				return new List<T>();
			}
			return UnityTools.GetComponents<T>(component.gameObject);
		}

		// Token: 0x06002FF3 RID: 12275 RVA: 0x000A7B78 File Offset: 0x000A5D78
		public static List<T> GetComponents<T>(GameObject gameObject) where T : class
		{
			List<T> list = new List<T>();
			if (gameObject == null)
			{
				return list;
			}
			Component[] components = gameObject.GetComponents(typeof(Component));
			if (components == null)
			{
				return list;
			}
			for (int i = 0; i < components.Length; i++)
			{
				if (!UnityTools.IsNullOrDestroyed<T>(components[i] as T))
				{
					list.Add(components[i] as T);
				}
			}
			return list;
		}

		// Token: 0x06002FF4 RID: 12276 RVA: 0x0002476E File Offset: 0x0002296E
		public static List<T> GetComponents<T>(Transform transform, bool includeDisabledComponents) where T : class
		{
			if (transform == null)
			{
				return new List<T>();
			}
			return UnityTools.GetComponents<T>(transform.gameObject, includeDisabledComponents);
		}

		// Token: 0x06002FF5 RID: 12277 RVA: 0x0002476E File Offset: 0x0002296E
		public static List<T> GetComponents<T>(Component component, bool includeDisabledComponents) where T : class
		{
			if (component == null)
			{
				return new List<T>();
			}
			return UnityTools.GetComponents<T>(component.gameObject, includeDisabledComponents);
		}

		// Token: 0x06002FF6 RID: 12278 RVA: 0x000A7BE4 File Offset: 0x000A5DE4
		public static List<T> GetComponents<T>(GameObject gameObject, bool includeDisabledComponents) where T : class
		{
			List<T> list = new List<T>();
			if (gameObject == null)
			{
				return list;
			}
			Component[] components = gameObject.GetComponents(typeof(Component));
			if (components == null)
			{
				return list;
			}
			for (int i = 0; i < components.Length; i++)
			{
				if (!UnityTools.IsNullOrDestroyed<T>(components[i] as T) && (includeDisabledComponents || UnityTools.IsEnabled(components[i])))
				{
					list.Add(components[i] as T);
				}
			}
			return list;
		}

		// Token: 0x06002FF7 RID: 12279 RVA: 0x0002478B File Offset: 0x0002298B
		public static List<Component> GetComponents(Transform transform, Type type)
		{
			if (transform == null)
			{
				return new List<Component>();
			}
			return UnityTools.GetComponents(transform.gameObject, type);
		}

		// Token: 0x06002FF8 RID: 12280 RVA: 0x0002478B File Offset: 0x0002298B
		public static List<Component> GetComponents(Component component, Type type)
		{
			if (component == null)
			{
				return new List<Component>();
			}
			return UnityTools.GetComponents(component.gameObject, type);
		}

		// Token: 0x06002FF9 RID: 12281 RVA: 0x000A7C5C File Offset: 0x000A5E5C
		public static List<Component> GetComponents(GameObject gameObject, Type type)
		{
			List<Component> list = new List<Component>();
			if (gameObject == null)
			{
				return list;
			}
			Component[] components = gameObject.GetComponents(type);
			if (components == null)
			{
				return list;
			}
			list.AddRange(components);
			return list;
		}

		// Token: 0x06002FFA RID: 12282 RVA: 0x000247A8 File Offset: 0x000229A8
		public static List<Component> GetComponents(Transform transform, Type type, bool includeDisabledComponents)
		{
			if (transform == null)
			{
				return new List<Component>();
			}
			return UnityTools.GetComponents(transform.gameObject, type, includeDisabledComponents);
		}

		// Token: 0x06002FFB RID: 12283 RVA: 0x000247A8 File Offset: 0x000229A8
		public static List<Component> GetComponents(Component component, Type type, bool includeDisabledComponents)
		{
			if (component == null)
			{
				return new List<Component>();
			}
			return UnityTools.GetComponents(component.gameObject, type, includeDisabledComponents);
		}

		// Token: 0x06002FFC RID: 12284 RVA: 0x000A7C90 File Offset: 0x000A5E90
		public static List<Component> GetComponents(GameObject gameObject, Type type, bool includeDisabledComponents)
		{
			List<Component> list = new List<Component>();
			if (gameObject == null)
			{
				return list;
			}
			Component[] components = gameObject.GetComponents(type);
			if (components == null)
			{
				return list;
			}
			for (int i = 0; i < components.Length; i++)
			{
				if (includeDisabledComponents || UnityTools.IsEnabled(components[i]))
				{
					list.Add(components[i]);
				}
			}
			return list;
		}

		// Token: 0x06002FFD RID: 12285 RVA: 0x000A7CE0 File Offset: 0x000A5EE0
		public static List<T> GetComponentsInChildren<T>(Transform transform) where T : class
		{
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
			}
			List<T> list = new List<T>();
			int childCount = transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				UnityTools.GetComponentsInSelfAndChildren<T>(transform.GetChild(i), list, true);
			}
			return list;
		}

		// Token: 0x06002FFE RID: 12286 RVA: 0x000247C6 File Offset: 0x000229C6
		public static List<T> GetComponentsInChildren<T>(Component component) where T : class
		{
			if (component == null)
			{
				throw new ArgumentNullException("component");
			}
			return UnityTools.GetComponentsInChildren<T>(component.transform);
		}

		// Token: 0x06002FFF RID: 12287 RVA: 0x000247E7 File Offset: 0x000229E7
		public static List<T> GetComponentsInChildren<T>(GameObject gameObject) where T : class
		{
			if (gameObject == null)
			{
				throw new ArgumentNullException("gameObject");
			}
			return UnityTools.GetComponentsInChildren<T>(gameObject.transform);
		}

		// Token: 0x06003000 RID: 12288 RVA: 0x000A7D2C File Offset: 0x000A5F2C
		public static List<T> GetComponentsInChildren<T>(Transform transform, UnityTools.GetComponentFlags options) where T : class
		{
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
			}
			List<T> list = new List<T>();
			int childCount = transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				UnityTools.GetComponentsInSelfAndChildren<T>(transform.GetChild(i), options, list, true);
			}
			return list;
		}

		// Token: 0x06003001 RID: 12289 RVA: 0x00024808 File Offset: 0x00022A08
		public static List<T> GetComponentsInChildren<T>(Component component, UnityTools.GetComponentFlags options) where T : class
		{
			if (component == null)
			{
				throw new ArgumentNullException("component");
			}
			return UnityTools.GetComponentsInChildren<T>(component.transform, options);
		}

		// Token: 0x06003002 RID: 12290 RVA: 0x0002482A File Offset: 0x00022A2A
		public static List<T> GetComponentsInChildren<T>(GameObject gameObject, UnityTools.GetComponentFlags options) where T : class
		{
			if (gameObject == null)
			{
				throw new ArgumentNullException("gameObject");
			}
			return UnityTools.GetComponentsInChildren<T>(gameObject.transform, options);
		}

		// Token: 0x06003003 RID: 12291 RVA: 0x000A7D78 File Offset: 0x000A5F78
		public static List<Component> GetComponentsInChildren(Transform transform)
		{
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
			}
			List<Component> list = new List<Component>();
			int childCount = transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				UnityTools.GetComponentsInSelfAndChildren(transform.GetChild(i), list, true);
			}
			return list;
		}

		// Token: 0x06003004 RID: 12292 RVA: 0x0002484C File Offset: 0x00022A4C
		public static List<Component> GetComponentsInChildren(Component component)
		{
			if (component == null)
			{
				throw new ArgumentNullException("component");
			}
			return UnityTools.GetComponentsInChildren(component.transform);
		}

		// Token: 0x06003005 RID: 12293 RVA: 0x0002486D File Offset: 0x00022A6D
		public static List<Component> GetComponentsInChildren(GameObject gameObject)
		{
			if (gameObject == null)
			{
				throw new ArgumentNullException("gameObject");
			}
			return UnityTools.GetComponentsInChildren(gameObject.transform);
		}

		// Token: 0x06003006 RID: 12294 RVA: 0x0002488E File Offset: 0x00022A8E
		public static List<T> GetComponentsInSelfAndChildren<T>(Transform transform) where T : class
		{
			if (transform == null)
			{
				return new List<T>();
			}
			return UnityTools.GetComponentsInSelfAndChildren<T>(transform.gameObject);
		}

		// Token: 0x06003007 RID: 12295 RVA: 0x0002488E File Offset: 0x00022A8E
		public static List<T> GetComponentsInSelfAndChildren<T>(Component component) where T : class
		{
			if (component == null)
			{
				return new List<T>();
			}
			return UnityTools.GetComponentsInSelfAndChildren<T>(component.gameObject);
		}

		// Token: 0x06003008 RID: 12296 RVA: 0x000A7DC4 File Offset: 0x000A5FC4
		public static List<T> GetComponentsInSelfAndChildren<T>(GameObject gameObject) where T : class
		{
			List<T> list = new List<T>();
			if (gameObject == null)
			{
				return list;
			}
			Component[] componentsInChildren = gameObject.GetComponentsInChildren(typeof(Component), true);
			if (componentsInChildren == null)
			{
				return list;
			}
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				if (!UnityTools.IsNullOrDestroyed<T>(componentsInChildren[i] as T))
				{
					list.Add(componentsInChildren[i] as T);
				}
			}
			return list;
		}

		// Token: 0x06003009 RID: 12297 RVA: 0x000A7E30 File Offset: 0x000A6030
		public static List<T> GetComponentsInParents<T>(Transform transform) where T : class
		{
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
			}
			List<T> list = new List<T>();
			Transform transform2 = transform;
			while ((transform2 = transform2.parent) != null)
			{
				UnityTools.GetComponents<T>(transform2, list, true);
			}
			return list;
		}

		// Token: 0x0600300A RID: 12298 RVA: 0x000248AA File Offset: 0x00022AAA
		public static List<T> GetComponentsInParents<T>(Component component) where T : class
		{
			if (component == null)
			{
				throw new ArgumentNullException("component");
			}
			return UnityTools.GetComponentsInParents<T>(component.transform);
		}

		// Token: 0x0600300B RID: 12299 RVA: 0x000248CB File Offset: 0x00022ACB
		public static List<T> GetComponentsInParents<T>(GameObject gameObject) where T : class
		{
			if (gameObject == null)
			{
				throw new ArgumentNullException("gameObject");
			}
			return UnityTools.GetComponentsInParents<T>(gameObject.transform);
		}

		// Token: 0x0600300C RID: 12300 RVA: 0x000A7E78 File Offset: 0x000A6078
		public static List<Component> GetComponentsInParents(Transform transform)
		{
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
			}
			List<Component> list = new List<Component>();
			Transform transform2 = transform;
			while ((transform2 = transform2.parent) != null)
			{
				UnityTools.GetComponents(transform2, list, true);
			}
			return list;
		}

		// Token: 0x0600300D RID: 12301 RVA: 0x000248EC File Offset: 0x00022AEC
		public static List<Component> GetComponentsInParents(Component component)
		{
			if (component == null)
			{
				throw new ArgumentNullException("component");
			}
			return UnityTools.GetComponentsInParents(component.transform);
		}

		// Token: 0x0600300E RID: 12302 RVA: 0x0002490D File Offset: 0x00022B0D
		public static List<Component> GetComponentsInParents(GameObject gameObject)
		{
			if (gameObject == null)
			{
				throw new ArgumentNullException("gameObject");
			}
			return UnityTools.GetComponentsInParents(gameObject.transform);
		}

		// Token: 0x0600300F RID: 12303 RVA: 0x0002492E File Offset: 0x00022B2E
		public static int GetComponents<T>(Transform transform, List<T> results, bool append) where T : class
		{
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
			}
			return UnityTools.GetComponents<T>(transform.gameObject, results, append);
		}

		// Token: 0x06003010 RID: 12304 RVA: 0x00024951 File Offset: 0x00022B51
		public static int GetComponents<T>(Component component, List<T> results, bool append) where T : class
		{
			if (component == null)
			{
				throw new ArgumentNullException("component");
			}
			return UnityTools.GetComponents<T>(component.gameObject, results, append);
		}

		// Token: 0x06003011 RID: 12305 RVA: 0x000A7EC0 File Offset: 0x000A60C0
		public static int GetComponents<T>(GameObject gameObject, List<T> results, bool append) where T : class
		{
			if (gameObject == null)
			{
				throw new ArgumentNullException("gameObject");
			}
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			if (!append)
			{
				results.Clear();
			}
			using (TempListPool.TList<Component> tlist = TempListPool.GetTList<Component>())
			{
				List<Component> list = tlist.list;
				gameObject.GetComponents<Component>(list);
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					T t = list[i] as T;
					if (!UnityTools.IsNullOrDestroyed<T>(t))
					{
						results.Add(t);
					}
				}
			}
			return results.Count;
		}

		// Token: 0x06003012 RID: 12306 RVA: 0x00024974 File Offset: 0x00022B74
		public static int GetComponents<T>(Transform transform, bool includeDisabledComponents, List<T> results, bool append) where T : class
		{
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
			}
			return UnityTools.GetComponents<T>(transform.gameObject, includeDisabledComponents, results, append);
		}

		// Token: 0x06003013 RID: 12307 RVA: 0x00024998 File Offset: 0x00022B98
		public static int GetComponents<T>(Component component, bool includeDisabledComponents, List<T> results, bool append) where T : class
		{
			if (component == null)
			{
				throw new ArgumentNullException("component");
			}
			return UnityTools.GetComponents<T>(component.gameObject, includeDisabledComponents, results, append);
		}

		// Token: 0x06003014 RID: 12308 RVA: 0x000A7F68 File Offset: 0x000A6168
		public static int GetComponents<T>(GameObject gameObject, bool includeDisabledComponents, List<T> results, bool append) where T : class
		{
			if (gameObject == null)
			{
				throw new ArgumentNullException("gameObject");
			}
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			if (!append)
			{
				results.Clear();
			}
			using (TempListPool.TList<Component> tlist = TempListPool.GetTList<Component>())
			{
				List<Component> list = tlist.list;
				gameObject.GetComponents<Component>(list);
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					T t = list[i] as T;
					if (!UnityTools.IsNullOrDestroyed<T>(t) && (includeDisabledComponents || UnityTools.IsEnabled(list[i])))
					{
						results.Add(t);
					}
				}
			}
			return results.Count;
		}

		// Token: 0x06003015 RID: 12309 RVA: 0x000249BC File Offset: 0x00022BBC
		public static int GetComponents(Transform transform, List<Component> results, bool append)
		{
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
			}
			return UnityTools.GetComponents(transform.gameObject, results, append);
		}

		// Token: 0x06003016 RID: 12310 RVA: 0x000249DF File Offset: 0x00022BDF
		public static int GetComponents(Component component, List<Component> results, bool append)
		{
			if (component == null)
			{
				throw new ArgumentNullException("component");
			}
			return UnityTools.GetComponents(component.gameObject, results, append);
		}

		// Token: 0x06003017 RID: 12311 RVA: 0x000A8020 File Offset: 0x000A6220
		public static int GetComponents(GameObject gameObject, List<Component> results, bool append)
		{
			if (gameObject == null)
			{
				throw new ArgumentNullException("gameObject");
			}
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			if (!append)
			{
				results.Clear();
			}
			using (TempListPool.TList<Component> tlist = TempListPool.GetTList<Component>())
			{
				List<Component> list = tlist.list;
				gameObject.GetComponents<Component>(list);
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					Component component = list[i];
					if (!(component == null))
					{
						results.Add(component);
					}
				}
			}
			return results.Count;
		}

		// Token: 0x06003018 RID: 12312 RVA: 0x00024A02 File Offset: 0x00022C02
		public static int GetComponents(Transform transform, Type type, List<Component> results, bool append)
		{
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
			}
			return UnityTools.GetComponents(transform.gameObject, type, results, append);
		}

		// Token: 0x06003019 RID: 12313 RVA: 0x00024A26 File Offset: 0x00022C26
		public static int GetComponents(Component component, Type type, List<Component> results, bool append)
		{
			if (component == null)
			{
				throw new ArgumentNullException("component");
			}
			return UnityTools.GetComponents(component.gameObject, type, results, append);
		}

		// Token: 0x0600301A RID: 12314 RVA: 0x000A80BC File Offset: 0x000A62BC
		public static int GetComponents(GameObject gameObject, Type type, List<Component> results, bool append)
		{
			if (gameObject == null)
			{
				throw new ArgumentNullException("gameObject");
			}
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			if (!append)
			{
				results.Clear();
			}
			using (TempListPool.TList<Component> tlist = TempListPool.GetTList<Component>())
			{
				List<Component> list = tlist.list;
				gameObject.GetComponents(type, list);
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					Component component = list[i];
					if (!(component == null))
					{
						results.Add(component);
					}
				}
			}
			return results.Count;
		}

		// Token: 0x0600301B RID: 12315 RVA: 0x000A815C File Offset: 0x000A635C
		public static int GetComponentsInSelfAndChildren(Transform transform, List<Component> results, bool append)
		{
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
			}
			if (!append)
			{
				results.Clear();
			}
			using (TempListPool.TList<Component> tlist = TempListPool.GetTList<Component>())
			{
				List<Component> list = tlist.list;
				transform.GetComponents<Component>(list);
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					Component component = list[i];
					if (!(component == null))
					{
						results.Add(component);
					}
				}
			}
			int childCount = transform.childCount;
			for (int j = 0; j < childCount; j++)
			{
				UnityTools.GetComponentsInSelfAndChildren(transform.GetChild(j), results, true);
			}
			return results.Count;
		}

		// Token: 0x0600301C RID: 12316 RVA: 0x00024A4A File Offset: 0x00022C4A
		public static int GetComponentsInSelfAndChildren(Component component, List<Component> results, bool append)
		{
			if (component == null)
			{
				throw new ArgumentNullException("component");
			}
			return UnityTools.GetComponentsInSelfAndChildren(component.transform, results, append);
		}

		// Token: 0x0600301D RID: 12317 RVA: 0x00024A6D File Offset: 0x00022C6D
		public static int GetComponentsInSelfAndChildren(GameObject gameObject, List<Component> results, bool append)
		{
			if (gameObject == null)
			{
				throw new ArgumentNullException("gameObject");
			}
			return UnityTools.GetComponentsInSelfAndChildren(gameObject.transform, results, append);
		}

		// Token: 0x0600301E RID: 12318 RVA: 0x000A8224 File Offset: 0x000A6424
		public static int GetComponentsInSelfAndChildren<T>(Transform transform, List<T> results, bool append) where T : class
		{
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
			}
			if (!append)
			{
				results.Clear();
			}
			using (TempListPool.TList<Component> tlist = TempListPool.GetTList<Component>())
			{
				List<Component> list = tlist.list;
				transform.GetComponents<Component>(list);
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					T t = list[i] as T;
					if (!UnityTools.IsNullOrDestroyed<T>(t))
					{
						results.Add(t);
					}
				}
			}
			int childCount = transform.childCount;
			for (int j = 0; j < childCount; j++)
			{
				UnityTools.GetComponentsInSelfAndChildren<T>(transform.GetChild(j), results, true);
			}
			return results.Count;
		}

		// Token: 0x0600301F RID: 12319 RVA: 0x00024A90 File Offset: 0x00022C90
		public static int GetComponentsInSelfAndChildren<T>(Component component, List<T> results, bool append) where T : class
		{
			if (component == null)
			{
				throw new ArgumentNullException("component");
			}
			return UnityTools.GetComponentsInSelfAndChildren<T>(component.transform, results, append);
		}

		// Token: 0x06003020 RID: 12320 RVA: 0x00024AB3 File Offset: 0x00022CB3
		public static int GetComponentsInSelfAndChildren<T>(GameObject gameObject, List<T> results, bool append) where T : class
		{
			if (gameObject == null)
			{
				throw new ArgumentNullException("gameObject");
			}
			return UnityTools.GetComponentsInSelfAndChildren<T>(gameObject.transform, results, append);
		}

		// Token: 0x06003021 RID: 12321 RVA: 0x000A82F8 File Offset: 0x000A64F8
		public static int GetComponentsInSelfAndChildren<T>(Transform transform, UnityTools.GetComponentFlags options, List<T> results, bool append) where T : class
		{
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
			}
			if (!append)
			{
				results.Clear();
			}
			using (TempListPool.TList<Component> tlist = TempListPool.GetTList<Component>())
			{
				List<Component> list = tlist.list;
				transform.GetComponents<Component>(list);
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					T t = list[i] as T;
					if (!UnityTools.IsNullOrDestroyed<T>(t) && ((options & UnityTools.GetComponentFlags.SkipDisabledComponents) == UnityTools.GetComponentFlags.None || UnityTools.IsEnabled(list[i])))
					{
						results.Add(t);
					}
				}
			}
			int childCount = transform.childCount;
			for (int j = 0; j < childCount; j++)
			{
				Transform child = transform.GetChild(j);
				if (!(child == null) && ((options & UnityTools.GetComponentFlags.SkipInactiveGameObjectRelatives) == UnityTools.GetComponentFlags.None || child.gameObject.activeSelf))
				{
					UnityTools.GetComponentsInSelfAndChildren<T>(child, options, results, true);
				}
			}
			return results.Count;
		}

		// Token: 0x06003022 RID: 12322 RVA: 0x00024AD6 File Offset: 0x00022CD6
		public static int GetComponentsInSelfAndChildren<T>(Component component, UnityTools.GetComponentFlags options, List<T> results, bool append) where T : class
		{
			if (component == null)
			{
				throw new ArgumentNullException("component");
			}
			return UnityTools.GetComponentsInSelfAndChildren<T>(component.transform, options, results, append);
		}

		// Token: 0x06003023 RID: 12323 RVA: 0x00024AFA File Offset: 0x00022CFA
		public static int GetComponentsInSelfAndChildren<T>(GameObject gameObject, UnityTools.GetComponentFlags options, List<T> results, bool append) where T : class
		{
			if (gameObject == null)
			{
				throw new ArgumentNullException("gameObject");
			}
			return UnityTools.GetComponentsInSelfAndChildren<T>(gameObject.transform, options, results, append);
		}

		// Token: 0x06003024 RID: 12324 RVA: 0x000A8400 File Offset: 0x000A6600
		public static int GetComponentsInChildren<T>(Transform transform, List<T> results, bool append) where T : class
		{
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
			}
			if (!append)
			{
				results.Clear();
			}
			int childCount = transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				UnityTools.GetComponentsInSelfAndChildren<T>(transform.GetChild(i), results, true);
			}
			return results.Count;
		}

		// Token: 0x06003025 RID: 12325 RVA: 0x00024B1E File Offset: 0x00022D1E
		public static int GetComponentsInChildren<T>(Component component, List<T> results, bool append) where T : class
		{
			if (component == null)
			{
				throw new ArgumentNullException("component");
			}
			return UnityTools.GetComponentsInChildren<T>(component.transform, results, append);
		}

		// Token: 0x06003026 RID: 12326 RVA: 0x00024B41 File Offset: 0x00022D41
		public static int GetComponentsInChildren<T>(GameObject gameObject, List<T> results, bool append) where T : class
		{
			if (gameObject == null)
			{
				throw new ArgumentNullException("gameObject");
			}
			return UnityTools.GetComponentsInChildren<T>(gameObject.transform, results, append);
		}

		// Token: 0x06003027 RID: 12327 RVA: 0x000A8460 File Offset: 0x000A6660
		public static int GetComponentsInChildren<T>(Transform transform, UnityTools.GetComponentFlags options, List<T> results, bool append) where T : class
		{
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
			}
			if (!append)
			{
				results.Clear();
			}
			int childCount = transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				UnityTools.GetComponentsInSelfAndChildren<T>(transform.GetChild(i), options, results, true);
			}
			return results.Count;
		}

		// Token: 0x06003028 RID: 12328 RVA: 0x00024B64 File Offset: 0x00022D64
		public static int GetComponentsInChildren<T>(Component component, UnityTools.GetComponentFlags options, List<T> results, bool append) where T : class
		{
			if (component == null)
			{
				throw new ArgumentNullException("component");
			}
			return UnityTools.GetComponentsInChildren<T>(component.transform, options, results, append);
		}

		// Token: 0x06003029 RID: 12329 RVA: 0x00024B88 File Offset: 0x00022D88
		public static int GetComponentsInChildren<T>(GameObject gameObject, UnityTools.GetComponentFlags options, List<T> results, bool append) where T : class
		{
			if (gameObject == null)
			{
				throw new ArgumentNullException("gameObject");
			}
			return UnityTools.GetComponentsInChildren<T>(gameObject.transform, options, results, append);
		}

		// Token: 0x0600302A RID: 12330 RVA: 0x000A84C4 File Offset: 0x000A66C4
		public static int GetComponentsInChildren(Transform transform, List<Component> results, bool append)
		{
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
			}
			if (!append)
			{
				results.Clear();
			}
			int childCount = transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				UnityTools.GetComponentsInSelfAndChildren(transform.GetChild(i), results, true);
			}
			return results.Count;
		}

		// Token: 0x0600302B RID: 12331 RVA: 0x00024BAC File Offset: 0x00022DAC
		public static int GetComponentsInChildren(Component component, List<Component> results, bool append)
		{
			if (component == null)
			{
				throw new ArgumentNullException("component");
			}
			return UnityTools.GetComponentsInChildren(component.transform, results, append);
		}

		// Token: 0x0600302C RID: 12332 RVA: 0x00024BCF File Offset: 0x00022DCF
		public static int GetComponentsInChildren(GameObject gameObject, List<Component> results, bool append)
		{
			if (gameObject == null)
			{
				throw new ArgumentNullException("gameObject");
			}
			return UnityTools.GetComponentsInChildren(gameObject.transform, results, append);
		}

		// Token: 0x0600302D RID: 12333 RVA: 0x00024BF2 File Offset: 0x00022DF2
		public static int GetComponentsInParents<T>(Transform transform, List<T> results, bool append) where T : class
		{
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
			}
			return UnityTools.GetComponentsInParents<T>(transform.gameObject, results, append);
		}

		// Token: 0x0600302E RID: 12334 RVA: 0x00024C15 File Offset: 0x00022E15
		public static int GetComponentsInParents<T>(Component component, List<T> results, bool append) where T : class
		{
			if (component == null)
			{
				throw new ArgumentNullException("component");
			}
			return UnityTools.GetComponentsInParents<T>(component.gameObject, results, append);
		}

		// Token: 0x0600302F RID: 12335 RVA: 0x000A8524 File Offset: 0x000A6724
		public static int GetComponentsInParents<T>(GameObject gameObject, List<T> results, bool append) where T : class
		{
			if (gameObject == null)
			{
				throw new ArgumentNullException("gameObject");
			}
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			if (!append)
			{
				results.Clear();
			}
			Transform parent = gameObject.transform.parent;
			while ((parent = parent.parent) != null)
			{
				UnityTools.GetComponents<T>(parent, results, true);
			}
			return results.Count;
		}

		// Token: 0x06003030 RID: 12336 RVA: 0x00024C38 File Offset: 0x00022E38
		public static int GetComponentsInParents(Transform transform, List<Component> results, bool append)
		{
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
			}
			return UnityTools.GetComponentsInParents(transform.gameObject, results, append);
		}

		// Token: 0x06003031 RID: 12337 RVA: 0x00024C5B File Offset: 0x00022E5B
		public static int GetComponentsInParents(Component component, List<Component> results, bool append)
		{
			if (component == null)
			{
				throw new ArgumentNullException("component");
			}
			return UnityTools.GetComponentsInParents(component.gameObject, results, append);
		}

		// Token: 0x06003032 RID: 12338 RVA: 0x000A858C File Offset: 0x000A678C
		public static int GetComponentsInParents(GameObject gameObject, List<Component> results, bool append)
		{
			if (gameObject == null)
			{
				throw new ArgumentNullException("gameObject");
			}
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			if (!append)
			{
				results.Clear();
			}
			Transform parent = gameObject.transform.parent;
			while ((parent = parent.parent) != null)
			{
				UnityTools.GetComponents(parent, results, true);
			}
			return results.Count;
		}

		// Token: 0x06003033 RID: 12339 RVA: 0x000A85F4 File Offset: 0x000A67F4
		public static void ForEachComponent<T>(Transform transform, Action<T> @delegate, bool includeChildren) where T : class
		{
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
			}
			if (@delegate == null)
			{
				throw new ArgumentNullException("@delegate");
			}
			using (TempListPool.TList<Component> tlist = TempListPool.GetTList<Component>())
			{
				List<Component> list = tlist.list;
				transform.GetComponents<Component>(list);
				int count = list.Count;
				for (int i = 0; i < count; i++)
				{
					T t = list[i] as T;
					if (!UnityTools.IsNullOrDestroyed<T>(t))
					{
						@delegate(t);
					}
				}
			}
			if (includeChildren)
			{
				int childCount = transform.childCount;
				for (int j = 0; j < childCount; j++)
				{
					UnityTools.ForEachComponent<T>(transform.GetChild(j), @delegate, includeChildren);
				}
			}
		}

		// Token: 0x06003034 RID: 12340 RVA: 0x00024C7E File Offset: 0x00022E7E
		public static void ForEachComponent<T>(Transform transform, Action<T> @delegate) where T : class
		{
			UnityTools.ForEachComponent<T>(transform, @delegate, false);
		}

		// Token: 0x06003035 RID: 12341 RVA: 0x00024C88 File Offset: 0x00022E88
		public static void ForEachComponent<T>(Component component, Action<T> @delegate, bool includeChildren) where T : class
		{
			UnityTools.ForEachComponent<T>(component.transform, @delegate, includeChildren);
		}

		// Token: 0x06003036 RID: 12342 RVA: 0x00024C97 File Offset: 0x00022E97
		public static void ForEachComponent<T>(Component component, Action<T> @delegate) where T : class
		{
			UnityTools.ForEachComponent<T>(component.transform, @delegate, false);
		}

		// Token: 0x06003037 RID: 12343 RVA: 0x00024CA6 File Offset: 0x00022EA6
		public static void ForEachComponent<T>(GameObject gameObject, Action<T> @delegate, bool includeChildren) where T : class
		{
			UnityTools.ForEachComponent<T>(gameObject.transform, @delegate, includeChildren);
		}

		// Token: 0x06003038 RID: 12344 RVA: 0x00024CB5 File Offset: 0x00022EB5
		public static void ForEachComponent<T>(GameObject gameObject, Action<T> @delegate) where T : class
		{
			UnityTools.ForEachComponent<T>(gameObject.transform, @delegate, false);
		}

		// Token: 0x06003039 RID: 12345 RVA: 0x000A86B8 File Offset: 0x000A68B8
		public static void ForEachComponentInChildren<T>(Transform transform, Action<T> @delegate) where T : class
		{
			if (transform == null)
			{
				throw new ArgumentNullException("transform");
			}
			if (@delegate == null)
			{
				throw new ArgumentNullException("@delegate");
			}
			int childCount = transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				UnityTools.ForEachComponent<T>(transform.GetChild(i), @delegate, true);
			}
		}

		// Token: 0x0600303A RID: 12346 RVA: 0x00024CC4 File Offset: 0x00022EC4
		public static void ForEachComponentInChildren<T>(Component component, Action<T> @delegate) where T : class
		{
			if (component == null)
			{
				throw new ArgumentNullException("component");
			}
			UnityTools.ForEachComponentInChildren<T>(component.transform, @delegate);
		}

		// Token: 0x0600303B RID: 12347 RVA: 0x00024CE6 File Offset: 0x00022EE6
		public static void ForEachComponentInChildren<T>(GameObject gameObject, Action<T> @delegate) where T : class
		{
			if (gameObject == null)
			{
				throw new ArgumentNullException("gameObject");
			}
			UnityTools.ForEachComponentInChildren<T>(gameObject.transform, @delegate);
		}

		// Token: 0x0600303C RID: 12348 RVA: 0x000A8708 File Offset: 0x000A6908
		public static bool IsEnabled(Component component)
		{
			if (component == null)
			{
				return false;
			}
			Behaviour behaviour = component as Behaviour;
			return !(behaviour != null) || behaviour.enabled;
		}

		// Token: 0x0600303D RID: 12349 RVA: 0x000A873C File Offset: 0x000A693C
		public static bool IsActiveAndEnabled(Component component)
		{
			if (component == null)
			{
				return false;
			}
			Behaviour behaviour = component as Behaviour;
			if (behaviour != null)
			{
				return behaviour.isActiveAndEnabled;
			}
			return component.gameObject.activeInHierarchy;
		}

		// Token: 0x0600303E RID: 12350 RVA: 0x00024D08 File Offset: 0x00022F08
		public static Object Instantiate(Object original, Transform parent, bool instantiateInWorldSpace)
		{
			return UnityTools.Instantiate<Object>(original, Vector3.zero, Quaternion.identity, parent, instantiateInWorldSpace);
		}

		// Token: 0x0600303F RID: 12351 RVA: 0x00024D1C File Offset: 0x00022F1C
		public static Object Instantiate(Object original, Vector3 position, Quaternion rotation, Transform parent, bool instantiateInWorldSpace)
		{
			return UnityTools.Instantiate<Object>(original, position, rotation, parent, instantiateInWorldSpace);
		}

		// Token: 0x06003040 RID: 12352 RVA: 0x00024D29 File Offset: 0x00022F29
		public static T Instantiate<T>(Object original, Transform parent, bool instantiateInWorldSpace) where T : Object
		{
			return UnityTools.Instantiate<T>(original, Vector3.zero, Quaternion.identity, parent, instantiateInWorldSpace);
		}

		// Token: 0x06003041 RID: 12353 RVA: 0x000A877C File Offset: 0x000A697C
		public static T Instantiate<T>(Object original, Vector3 position, Quaternion rotation, Transform parent, bool instantiateInWorldSpace) where T : Object
		{
			if (original == null)
			{
				return default(T);
			}
			Object @object = Object.Instantiate(original);
			if (parent != null)
			{
				Transform transform = null;
				if (@object as Component != null)
				{
					transform = (@object as Component).transform;
				}
				else if (@object as GameObject != null)
				{
					transform = (@object as GameObject).transform;
				}
				else if (@object as Transform != null)
				{
					transform = (@object as Transform);
				}
				if (transform != null)
				{
					if (!instantiateInWorldSpace)
					{
						Vector3 localScale = transform.localScale;
						transform.parent = parent;
						transform.localPosition = position;
						transform.localRotation = rotation;
						transform.localScale = localScale;
					}
					else
					{
						transform.position = position;
						transform.rotation = rotation;
						transform.parent = parent;
					}
				}
			}
			if (UnityTools.IsNullOrDestroyed<T>(@object as T))
			{
				if (@object as GameObject != null)
				{
					return UnityTools.qgFcUKuZIHGdmJlzPfmViRMAImwj<T>((@object as GameObject).GetComponent(typeof(T)) as T);
				}
				if (@object as Transform != null)
				{
					return UnityTools.qgFcUKuZIHGdmJlzPfmViRMAImwj<T>((@object as Transform).GetComponent(typeof(T)) as T);
				}
			}
			return UnityTools.qgFcUKuZIHGdmJlzPfmViRMAImwj<T>(@object as T);
		}

		// Token: 0x06003042 RID: 12354 RVA: 0x000A88D0 File Offset: 0x000A6AD0
		public static Vector3 TransformPoint(Transform from, Transform to, Vector3 point)
		{
			Vector3 vector = (from != null) ? from.TransformPoint(point) : point;
			if (to == null)
			{
				return vector;
			}
			return to.InverseTransformPoint(vector);
		}

		// Token: 0x06003043 RID: 12355 RVA: 0x00024D3D File Offset: 0x00022F3D
		public static Vector3 TransformPoint(Transform from, Transform to)
		{
			return UnityTools.TransformPoint(from, to, Vector3.zero);
		}

		// Token: 0x06003044 RID: 12356 RVA: 0x000A8904 File Offset: 0x000A6B04
		public static Vector3 TransformDirection(Transform from, Transform to, Vector3 direction)
		{
			Vector3 vector = (from != null) ? from.TransformDirection(direction) : direction;
			if (to == null)
			{
				return vector;
			}
			return to.InverseTransformDirection(vector);
		}

		// Token: 0x06003045 RID: 12357 RVA: 0x00024D4B File Offset: 0x00022F4B
		public static Vector3 TransformDirection(Transform from, Transform to)
		{
			return UnityTools.TransformDirection(from, to, Vector3.zero);
		}

		// Token: 0x06003046 RID: 12358 RVA: 0x000A8938 File Offset: 0x000A6B38
		public static Vector3 TransformVector(Transform from, Transform to, Vector3 vector)
		{
			Vector3 vector2 = (from != null) ? (from.TransformPoint(vector) - from.position) : Vector3.zero;
			if (to == null)
			{
				return vector2;
			}
			return to.InverseTransformPoint(vector2 + to.position);
		}

		// Token: 0x06003047 RID: 12359 RVA: 0x00024D59 File Offset: 0x00022F59
		public static Vector3 TransformVector(Transform from, Transform to)
		{
			return UnityTools.TransformVector(from, to, Vector3.zero);
		}

		// Token: 0x06003048 RID: 12360 RVA: 0x000A8988 File Offset: 0x000A6B88
		public static Rect TransformRect(Transform from, Transform to, Rect rect)
		{
			Vector3 vector;
			Vector3 vector2;
			Vector3 vector3;
			if (from != null)
			{
				vector = from.TransformPoint(new Vector2(rect.xMin, rect.yMin));
				vector2 = from.TransformPoint(new Vector2(rect.xMin, rect.yMax));
				vector3 = from.TransformPoint(new Vector2(rect.xMax, rect.yMin));
			}
			else
			{
				vector = new Vector2(rect.xMin, rect.yMin);
				vector2 = new Vector2(rect.xMin, rect.yMax);
				vector3 = new Vector2(rect.xMax, rect.yMin);
			}
			if (to != null)
			{
				vector = to.InverseTransformPoint(vector);
				vector2 = to.InverseTransformPoint(vector2);
				vector3 = to.InverseTransformPoint(vector3);
			}
			return new Rect(vector.x, vector.y, vector3.x - vector.x, vector.y - vector2.y);
		}

		// Token: 0x06003049 RID: 12361 RVA: 0x000A8A94 File Offset: 0x000A6C94
		public static void DebugDrawCross(Vector3 position, float length, Color color)
		{
			Debug.DrawLine(position - Vector3.up * length * 0.5f, position + Vector3.up * length * 0.5f, color);
			Debug.DrawLine(position - Vector3.right * length * 0.5f, position + Vector3.right * length * 0.5f, color);
			Debug.DrawLine(position - Vector3.forward * length * 0.5f, position + Vector3.forward * length * 0.5f, color);
		}

		// Token: 0x0600304A RID: 12362 RVA: 0x000A8B58 File Offset: 0x000A6D58
		public static void DebugDrawCross(Vector3 position, float length, Color color, float duration)
		{
			Debug.DrawLine(position - Vector3.up * length * 0.5f, position + Vector3.up * length * 0.5f, color, duration);
			Debug.DrawLine(position - Vector3.right * length * 0.5f, position + Vector3.right * length * 0.5f, color, duration);
			Debug.DrawLine(position - Vector3.forward * length * 0.5f, position + Vector3.forward * length * 0.5f, color, duration);
		}

		// Token: 0x0600304B RID: 12363 RVA: 0x000A8C1C File Offset: 0x000A6E1C
		[CustomObfuscation(rename = false)]
		internal static bool IsObjectInScene<T>(T @object) where T : Object
		{
			T[] array = Object.FindObjectsOfType<T>();
			if (array == null)
			{
				return false;
			}
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == @object)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600304C RID: 12364 RVA: 0x00024D67 File Offset: 0x00022F67
		public static string GetUnityInputAxisName(int unityJoystickIndex, int axisIndex)
		{
			return UnityTools.GetUnityInputAxisNameByJoystickId(unityJoystickIndex + 1, axisIndex);
		}

		// Token: 0x0600304D RID: 12365 RVA: 0x000A8C60 File Offset: 0x000A6E60
		public static string GetUnityInputAxisNameByJoystickId(int unityJoystickId, int axisIndex)
		{
			return "Joy" + unityJoystickId.ToString() + "Axis" + (axisIndex + 1).ToString();
		}

		// Token: 0x0600304E RID: 12366 RVA: 0x00024D72 File Offset: 0x00022F72
		public static string GetUnityInputButtonName(int unityJoystickIndex, int buttonIndex)
		{
			return UnityTools.GetUnityInputButtonNameByJoystickId(unityJoystickIndex + 1, buttonIndex);
		}

		// Token: 0x0600304F RID: 12367 RVA: 0x00024D7D File Offset: 0x00022F7D
		public static string GetUnityInputButtonNameByJoystickId(int unityJoystickId, int buttonIndex)
		{
			return "Joy" + unityJoystickId.ToString() + "Button" + buttonIndex.ToString();
		}

		// Token: 0x06003050 RID: 12368 RVA: 0x000A8C90 File Offset: 0x000A6E90
		public static bool IsValidUnityJoystickName(string name)
		{
			if (string.IsNullOrEmpty(name))
			{
				if (ReInput.isWindowsStandaloneWebplayerOrEditorPlatform && UnityTools.kRHYcljAhypnvdQEfnereSpyQnDk)
				{
					return false;
				}
				if (UnityTools.ZmzfqNnonvVqzIzfmazzUSfkkrGl)
				{
					return false;
				}
			}
			else
			{
				if (UnityTools.rLtYqQbkgqhxolczdfCkMJzKMXCn && name.Equals(UnityTools.mbhPamKrjmxDtAsVaIdHnnhhbPBf, StringComparison.OrdinalIgnoreCase))
				{
					return false;
				}
				if (UnityTools.wrqFejyuClBnIajkStauqiBLhRWi && name.IndexOf("keyboard", 0, StringComparison.OrdinalIgnoreCase) >= 0)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06003051 RID: 12369 RVA: 0x000A8CF0 File Offset: 0x000A6EF0
		public static AnimationCurve Copy(AnimationCurve orig)
		{
			if (orig == null)
			{
				return null;
			}
			Keyframe[] keys = orig.keys;
			AnimationCurve animationCurve;
			if (keys != null)
			{
				animationCurve = new AnimationCurve(keys);
			}
			else
			{
				animationCurve = new AnimationCurve();
			}
			animationCurve.postWrapMode = orig.postWrapMode;
			animationCurve.preWrapMode = orig.preWrapMode;
			return animationCurve;
		}

		// Token: 0x06003052 RID: 12370 RVA: 0x00024D9C File Offset: 0x00022F9C
		public static bool IsNullOrDestroyed(object @object)
		{
			return @object == null || (@object is Object && @object as Object == null);
		}

		// Token: 0x06003053 RID: 12371 RVA: 0x00024DB9 File Offset: 0x00022FB9
		public static bool IsNullOrDestroyed<T>(T @object) where T : class
		{
			return @object == null || (@object is Object && @object as Object == null);
		}

		// Token: 0x06003054 RID: 12372 RVA: 0x000A8D34 File Offset: 0x000A6F34
		private static \u0001 qgFcUKuZIHGdmJlzPfmViRMAImwj<\u0001>(\u0001 A_0) where \u0001 : class
		{
			if (A_0 == null)
			{
				return default(\u0001);
			}
			if (A_0 is Object && A_0 as Object == null)
			{
				return default(\u0001);
			}
			return A_0;
		}

		// Token: 0x06003055 RID: 12373 RVA: 0x000A8D80 File Offset: 0x000A6F80
		internal static ButtonStateFlags xVGXYZESADRDdsLGYeNQeteskUpD(KeyCode A_0)
		{
			ButtonStateFlags buttonStateFlags = Input.GetKey(A_0) ? ButtonStateFlags.On : ButtonStateFlags.Off;
			if (Input.GetKeyDown(A_0))
			{
				buttonStateFlags |= ButtonStateFlags.Down;
			}
			if (Input.GetKeyUp(A_0))
			{
				buttonStateFlags |= ButtonStateFlags.Up;
			}
			return buttonStateFlags;
		}

		// Token: 0x06003056 RID: 12374 RVA: 0x000A8DB4 File Offset: 0x000A6FB4
		internal static ButtonStateFlags BNABEjESSgyZCNFCLNOoQCUylnZbb(string A_0)
		{
			ButtonStateFlags buttonStateFlags = Input.GetButton(A_0) ? ButtonStateFlags.On : ButtonStateFlags.Off;
			if (Input.GetButtonDown(A_0))
			{
				buttonStateFlags |= ButtonStateFlags.Down;
			}
			if (Input.GetButtonUp(A_0))
			{
				buttonStateFlags |= ButtonStateFlags.Up;
			}
			return buttonStateFlags;
		}

		// Token: 0x040019C8 RID: 6600
		private const UnityTools.UnityVersion hQIAJzMqiUmjEtBUvnOrCvJxXiEA = UnityTools.UnityVersion.UNITY_5_0;

		// Token: 0x040019C9 RID: 6601
		private static UnityTools.UnityVersionClass GKphzqwOhaugHxbtRLRFWRiDckVf;

		// Token: 0x040019CA RID: 6602
		private static UnityTools.UnityVersion hIgIGkmnuTEQuMvXztzTFPtkqHIC = UnityTools.UnityVersion.Unknown;

		// Token: 0x040019CB RID: 6603
		private static string pYkRgFzmljIOaTHSzpvswAkWyCqg;

		// Token: 0x040019CC RID: 6604
		private static Platform VGEdpOHQVjBjMVXteEGMWcUleyMH;

		// Token: 0x040019CD RID: 6605
		private static EditorPlatform TMTxgoNYrgAmuBdAwgPQygozfTQF;

		// Token: 0x040019CE RID: 6606
		private static bool fzybjvzaRzuUHlwpGfScijnxUgQi;

		// Token: 0x040019CF RID: 6607
		private static bool CuDTQIThAyMOBEJeVFLVWLymxvvm;

		// Token: 0x040019D0 RID: 6608
		private static bool iJqJlQRpyMDMKcIizPKvDFHdevOCB;

		// Token: 0x040019D1 RID: 6609
		private static WebplayerPlatform ohgQeGghabDpGVctuhSnhLgzYULt;

		// Token: 0x040019D2 RID: 6610
		private static bool TFDuHlVEekpbJKttHGqHACziYqLt;

		// Token: 0x040019D3 RID: 6611
		private static bool EAzuFTVhKAwSsrjGXoMWSmSyLLio;

		// Token: 0x040019D4 RID: 6612
		private static bool kRHYcljAhypnvdQEfnereSpyQnDk;

		// Token: 0x040019D5 RID: 6613
		private static bool ZmzfqNnonvVqzIzfmazzUSfkkrGl;

		// Token: 0x040019D6 RID: 6614
		private static bool wrqFejyuClBnIajkStauqiBLhRWi;

		// Token: 0x040019D7 RID: 6615
		private static bool rLtYqQbkgqhxolczdfCkMJzKMXCn;

		// Token: 0x040019D8 RID: 6616
		private static string mbhPamKrjmxDtAsVaIdHnnhhbPBf;

		// Token: 0x040019D9 RID: 6617
		private static ScriptingBackend UnVCySiTaGFvYapCKVMaQwOJvuSzB;

		// Token: 0x040019DA RID: 6618
		private static ScriptingAPILevel BRcKWlskLBqwgYdAbBDzHqTEoSVH;

		// Token: 0x040019DB RID: 6619
		private static bool bmswVZhIlrqttGHbtDXgfFcmFNsHb;

		// Token: 0x040019DC RID: 6620
		private static IExternalTools suanviZxuKynKPlwmwTpiBOZmPiL;

		// Token: 0x040019DD RID: 6621
		[CompilerGenerated]
		private static IAndroidFallbackPlatformHelper DcvFgFVgBdDMhzwGmKtpczzbJWUE;

		// Token: 0x040019DE RID: 6622
		private static bool GQUiEiWpUaiuPDnTQXtEPymnnnEx;

		// Token: 0x0200049C RID: 1180
		internal struct YlequFlwSpDLySjTazqSoKcKCanv
		{
			// Token: 0x06003058 RID: 12376 RVA: 0x00024DF1 File Offset: 0x00022FF1
			public YlequFlwSpDLySjTazqSoKcKCanv(Platform A_1, Platform A_2, EditorPlatform A_3, bool A_4, WebplayerPlatform A_5, ScriptingBackend A_6, ScriptingAPILevel A_7, IExternalTools A_8)
			{
				this.bOIbQlcqVEmVTpWLmZRfnqguPHenA = A_1;
				this.PUBMBpURbtrqwjMzKnkdubHBAasQ = A_2;
				this.DDtpBOjtOpADRjqPsRYiTmiWmpVm = A_3;
				this.CKUceEEUAQLrrMLRlPobKmQzKuuBA = A_4;
				this.kzWArcCGSwWIHywpausYDnllCKan = A_5;
				this.OCFelIhndgWWedQMiDnFcAAtqUdQ = A_6;
				this.JWrfRNwYcvNDYPcLPfRNMnjHmqMR = A_7;
				this.QaEqUDBGtOeJsDUQHquCEbLEMUzxA = A_8;
			}

			// Token: 0x040019DF RID: 6623
			public Platform bOIbQlcqVEmVTpWLmZRfnqguPHenA;

			// Token: 0x040019E0 RID: 6624
			public Platform PUBMBpURbtrqwjMzKnkdubHBAasQ;

			// Token: 0x040019E1 RID: 6625
			public EditorPlatform DDtpBOjtOpADRjqPsRYiTmiWmpVm;

			// Token: 0x040019E2 RID: 6626
			public bool CKUceEEUAQLrrMLRlPobKmQzKuuBA;

			// Token: 0x040019E3 RID: 6627
			public WebplayerPlatform kzWArcCGSwWIHywpausYDnllCKan;

			// Token: 0x040019E4 RID: 6628
			public ScriptingBackend OCFelIhndgWWedQMiDnFcAAtqUdQ;

			// Token: 0x040019E5 RID: 6629
			public ScriptingAPILevel JWrfRNwYcvNDYPcLPfRNMnjHmqMR;

			// Token: 0x040019E6 RID: 6630
			public IExternalTools QaEqUDBGtOeJsDUQHquCEbLEMUzxA;
		}

		// Token: 0x0200049D RID: 1181
		public enum UnityVersion
		{
			// Token: 0x040019E8 RID: 6632
			UNITY_2_6,
			// Token: 0x040019E9 RID: 6633
			UNITY_2_6_1,
			// Token: 0x040019EA RID: 6634
			UNITY_3_0,
			// Token: 0x040019EB RID: 6635
			UNITY_3_0_0,
			// Token: 0x040019EC RID: 6636
			UNITY_3_1,
			// Token: 0x040019ED RID: 6637
			UNITY_3_2,
			// Token: 0x040019EE RID: 6638
			UNITY_3_3,
			// Token: 0x040019EF RID: 6639
			UNITY_3_4,
			// Token: 0x040019F0 RID: 6640
			UNITY_3_5,
			// Token: 0x040019F1 RID: 6641
			UNITY_3_5_2,
			// Token: 0x040019F2 RID: 6642
			UNITY_3_5_7,
			// Token: 0x040019F3 RID: 6643
			UNITY_3_MAX,
			// Token: 0x040019F4 RID: 6644
			UNITY_4_0,
			// Token: 0x040019F5 RID: 6645
			UNITY_4_0_1,
			// Token: 0x040019F6 RID: 6646
			UNITY_4_1,
			// Token: 0x040019F7 RID: 6647
			UNITY_4_2,
			// Token: 0x040019F8 RID: 6648
			UNITY_4_3,
			// Token: 0x040019F9 RID: 6649
			UNITY_4_4,
			// Token: 0x040019FA RID: 6650
			UNITY_4_5,
			// Token: 0x040019FB RID: 6651
			UNITY_4_6,
			// Token: 0x040019FC RID: 6652
			UNITY_4_6_3p1,
			// Token: 0x040019FD RID: 6653
			UNITY_4_6_3p1Plus,
			// Token: 0x040019FE RID: 6654
			UNITY_4_7,
			// Token: 0x040019FF RID: 6655
			UNITY_4_8,
			// Token: 0x04001A00 RID: 6656
			UNITY_4_9,
			// Token: 0x04001A01 RID: 6657
			UNITY_4_MAX,
			// Token: 0x04001A02 RID: 6658
			UNITY_5_0,
			// Token: 0x04001A03 RID: 6659
			UNITY_5_0_0p1,
			// Token: 0x04001A04 RID: 6660
			UNITY_5_0_0p1Plus,
			// Token: 0x04001A05 RID: 6661
			UNITY_5_0_1,
			// Token: 0x04001A06 RID: 6662
			UNITY_5_0_2,
			// Token: 0x04001A07 RID: 6663
			UNITY_5_1,
			// Token: 0x04001A08 RID: 6664
			UNITY_5_2,
			// Token: 0x04001A09 RID: 6665
			UNITY_5_3,
			// Token: 0x04001A0A RID: 6666
			UNITY_5_4,
			// Token: 0x04001A0B RID: 6667
			UNITY_5_5,
			// Token: 0x04001A0C RID: 6668
			UNITY_5_6,
			// Token: 0x04001A0D RID: 6669
			UNITY_5_7,
			// Token: 0x04001A0E RID: 6670
			UNITY_5_8,
			// Token: 0x04001A0F RID: 6671
			UNITY_5_9,
			// Token: 0x04001A10 RID: 6672
			UNITY_5_MAX,
			// Token: 0x04001A11 RID: 6673
			UNITY_2017_0,
			// Token: 0x04001A12 RID: 6674
			UNITY_2017_1,
			// Token: 0x04001A13 RID: 6675
			UNITY_2017_2,
			// Token: 0x04001A14 RID: 6676
			UNITY_2017_3,
			// Token: 0x04001A15 RID: 6677
			UNITY_2017_4,
			// Token: 0x04001A16 RID: 6678
			UNITY_2017_5,
			// Token: 0x04001A17 RID: 6679
			UNITY_2017_6,
			// Token: 0x04001A18 RID: 6680
			UNITY_2017_7,
			// Token: 0x04001A19 RID: 6681
			UNITY_2017_8,
			// Token: 0x04001A1A RID: 6682
			UNITY_2017_9,
			// Token: 0x04001A1B RID: 6683
			UNITY_2017_MAX,
			// Token: 0x04001A1C RID: 6684
			UNITY_2018_0,
			// Token: 0x04001A1D RID: 6685
			UNITY_2018_1,
			// Token: 0x04001A1E RID: 6686
			UNITY_2018_2,
			// Token: 0x04001A1F RID: 6687
			UNITY_2018_3,
			// Token: 0x04001A20 RID: 6688
			UNITY_2018_4,
			// Token: 0x04001A21 RID: 6689
			UNITY_2018_5,
			// Token: 0x04001A22 RID: 6690
			UNITY_2018_6,
			// Token: 0x04001A23 RID: 6691
			UNITY_2018_7,
			// Token: 0x04001A24 RID: 6692
			UNITY_2018_8,
			// Token: 0x04001A25 RID: 6693
			UNITY_2018_9,
			// Token: 0x04001A26 RID: 6694
			UNITY_2018_MAX,
			// Token: 0x04001A27 RID: 6695
			UNITY_2019_0,
			// Token: 0x04001A28 RID: 6696
			UNITY_2019_1,
			// Token: 0x04001A29 RID: 6697
			UNITY_2019_2,
			// Token: 0x04001A2A RID: 6698
			UNITY_2019_3,
			// Token: 0x04001A2B RID: 6699
			UNITY_2019_4,
			// Token: 0x04001A2C RID: 6700
			UNITY_2019_5,
			// Token: 0x04001A2D RID: 6701
			UNITY_2019_6,
			// Token: 0x04001A2E RID: 6702
			UNITY_2019_7,
			// Token: 0x04001A2F RID: 6703
			UNITY_2019_8,
			// Token: 0x04001A30 RID: 6704
			UNITY_2019_9,
			// Token: 0x04001A31 RID: 6705
			UNITY_2019_MAX,
			// Token: 0x04001A32 RID: 6706
			UNITY_2020_0,
			// Token: 0x04001A33 RID: 6707
			UNITY_2020_1,
			// Token: 0x04001A34 RID: 6708
			UNITY_2020_2,
			// Token: 0x04001A35 RID: 6709
			UNITY_2020_3,
			// Token: 0x04001A36 RID: 6710
			UNITY_2020_4,
			// Token: 0x04001A37 RID: 6711
			UNITY_2020_5,
			// Token: 0x04001A38 RID: 6712
			UNITY_2020_6,
			// Token: 0x04001A39 RID: 6713
			UNITY_2020_7,
			// Token: 0x04001A3A RID: 6714
			UNITY_2020_8,
			// Token: 0x04001A3B RID: 6715
			UNITY_2020_9,
			// Token: 0x04001A3C RID: 6716
			UNITY_2020_MAX,
			// Token: 0x04001A3D RID: 6717
			UNITY_2021_0,
			// Token: 0x04001A3E RID: 6718
			UNITY_2021_1,
			// Token: 0x04001A3F RID: 6719
			UNITY_2021_2,
			// Token: 0x04001A40 RID: 6720
			UNITY_2021_3,
			// Token: 0x04001A41 RID: 6721
			UNITY_2021_4,
			// Token: 0x04001A42 RID: 6722
			UNITY_2021_5,
			// Token: 0x04001A43 RID: 6723
			UNITY_2021_6,
			// Token: 0x04001A44 RID: 6724
			UNITY_2021_7,
			// Token: 0x04001A45 RID: 6725
			UNITY_2021_8,
			// Token: 0x04001A46 RID: 6726
			UNITY_2021_9,
			// Token: 0x04001A47 RID: 6727
			UNITY_2021_MAX,
			// Token: 0x04001A48 RID: 6728
			UNITY_2022_0,
			// Token: 0x04001A49 RID: 6729
			UNITY_2022_1,
			// Token: 0x04001A4A RID: 6730
			UNITY_2022_2,
			// Token: 0x04001A4B RID: 6731
			UNITY_2022_3,
			// Token: 0x04001A4C RID: 6732
			UNITY_2022_4,
			// Token: 0x04001A4D RID: 6733
			UNITY_2022_5,
			// Token: 0x04001A4E RID: 6734
			UNITY_2022_6,
			// Token: 0x04001A4F RID: 6735
			UNITY_2022_7,
			// Token: 0x04001A50 RID: 6736
			UNITY_2022_8,
			// Token: 0x04001A51 RID: 6737
			UNITY_2022_9,
			// Token: 0x04001A52 RID: 6738
			UNITY_2022_MAX,
			// Token: 0x04001A53 RID: 6739
			UNITY_2023_0,
			// Token: 0x04001A54 RID: 6740
			UNITY_2023_1,
			// Token: 0x04001A55 RID: 6741
			UNITY_2023_2,
			// Token: 0x04001A56 RID: 6742
			UNITY_2023_3,
			// Token: 0x04001A57 RID: 6743
			UNITY_2023_4,
			// Token: 0x04001A58 RID: 6744
			UNITY_2023_5,
			// Token: 0x04001A59 RID: 6745
			UNITY_2023_6,
			// Token: 0x04001A5A RID: 6746
			UNITY_2023_7,
			// Token: 0x04001A5B RID: 6747
			UNITY_2023_8,
			// Token: 0x04001A5C RID: 6748
			UNITY_2023_9,
			// Token: 0x04001A5D RID: 6749
			UNITY_2023_MAX,
			// Token: 0x04001A5E RID: 6750
			UNITY_6000_0,
			// Token: 0x04001A5F RID: 6751
			UNITY_6000_1,
			// Token: 0x04001A60 RID: 6752
			UNITY_6000_2,
			// Token: 0x04001A61 RID: 6753
			UNITY_6000_3,
			// Token: 0x04001A62 RID: 6754
			UNITY_6000_4,
			// Token: 0x04001A63 RID: 6755
			UNITY_6000_5,
			// Token: 0x04001A64 RID: 6756
			UNITY_6000_6,
			// Token: 0x04001A65 RID: 6757
			UNITY_6000_7,
			// Token: 0x04001A66 RID: 6758
			UNITY_6000_8,
			// Token: 0x04001A67 RID: 6759
			UNITY_6000_9,
			// Token: 0x04001A68 RID: 6760
			UNITY_6000_MAX,
			// Token: 0x04001A69 RID: 6761
			UNITY_7000_0,
			// Token: 0x04001A6A RID: 6762
			UNITY_7000_1,
			// Token: 0x04001A6B RID: 6763
			UNITY_7000_2,
			// Token: 0x04001A6C RID: 6764
			UNITY_7000_3,
			// Token: 0x04001A6D RID: 6765
			UNITY_7000_4,
			// Token: 0x04001A6E RID: 6766
			UNITY_7000_5,
			// Token: 0x04001A6F RID: 6767
			UNITY_7000_6,
			// Token: 0x04001A70 RID: 6768
			UNITY_7000_7,
			// Token: 0x04001A71 RID: 6769
			UNITY_7000_8,
			// Token: 0x04001A72 RID: 6770
			UNITY_7000_9,
			// Token: 0x04001A73 RID: 6771
			UNITY_7000_MAX,
			// Token: 0x04001A74 RID: 6772
			UNITY_8000_0,
			// Token: 0x04001A75 RID: 6773
			UNITY_8000_1,
			// Token: 0x04001A76 RID: 6774
			UNITY_8000_2,
			// Token: 0x04001A77 RID: 6775
			UNITY_8000_3,
			// Token: 0x04001A78 RID: 6776
			UNITY_8000_4,
			// Token: 0x04001A79 RID: 6777
			UNITY_8000_5,
			// Token: 0x04001A7A RID: 6778
			UNITY_8000_6,
			// Token: 0x04001A7B RID: 6779
			UNITY_8000_7,
			// Token: 0x04001A7C RID: 6780
			UNITY_8000_8,
			// Token: 0x04001A7D RID: 6781
			UNITY_8000_9,
			// Token: 0x04001A7E RID: 6782
			UNITY_8000_MAX,
			// Token: 0x04001A7F RID: 6783
			UNITY_9000_0,
			// Token: 0x04001A80 RID: 6784
			UNITY_9000_1,
			// Token: 0x04001A81 RID: 6785
			UNITY_9000_2,
			// Token: 0x04001A82 RID: 6786
			UNITY_9000_3,
			// Token: 0x04001A83 RID: 6787
			UNITY_9000_4,
			// Token: 0x04001A84 RID: 6788
			UNITY_9000_5,
			// Token: 0x04001A85 RID: 6789
			UNITY_9000_6,
			// Token: 0x04001A86 RID: 6790
			UNITY_9000_7,
			// Token: 0x04001A87 RID: 6791
			UNITY_9000_8,
			// Token: 0x04001A88 RID: 6792
			UNITY_9000_9,
			// Token: 0x04001A89 RID: 6793
			UNITY_9000_MAX,
			// Token: 0x04001A8A RID: 6794
			Unknown = 1000
		}

		// Token: 0x0200049E RID: 1182
		[Flags]
		public enum GetComponentFlags
		{
			// Token: 0x04001A8C RID: 6796
			None = 0,
			// Token: 0x04001A8D RID: 6797
			SkipInactiveGameObjectRelatives = 1,
			// Token: 0x04001A8E RID: 6798
			SkipDisabledComponents = 2
		}

		// Token: 0x0200049F RID: 1183
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
		internal class UnityVersionClass
		{
			// Token: 0x06003059 RID: 12377 RVA: 0x000A8DE8 File Offset: 0x000A6FE8
			public UnityVersionClass(string A_1)
			{
				this.type = UnityTools.UnityVersionClass.qQGMOrnNThGcpashhYUHBtQoKFmp.Normal;
				string[] array = A_1.Split('.', StringSplitOptions.None);
				string text = array[array.Length - 1];
				if (Regex.IsMatch(text, ".*[a-zA-Z]+.*"))
				{
					if (Regex.IsMatch(text, ".*[bB]+.*", RegexOptions.IgnoreCase))
					{
						this.type = UnityTools.UnityVersionClass.qQGMOrnNThGcpashhYUHBtQoKFmp.Beta;
					}
					else if (Regex.IsMatch(text, ".*[pP]+.*", RegexOptions.IgnoreCase))
					{
						this.type = UnityTools.UnityVersionClass.qQGMOrnNThGcpashhYUHBtQoKFmp.Patch;
					}
					text = Regex.Replace(text, "[a-zA-Z]", "|");
					if (text.Contains("|"))
					{
						string[] array2 = text.Split('|', StringSplitOptions.None);
						if (array2.Length != 0)
						{
							int.TryParse(array2[0], out this.maintenance);
						}
						if (array2.Length > 1)
						{
							int.TryParse(array2[1], out this.build);
						}
					}
					else
					{
						int.TryParse(text, out this.maintenance);
					}
					Array.Resize<string>(ref array, array.Length - 1);
				}
				else
				{
					int.TryParse(text, out this.maintenance);
				}
				if (array.Length != 0)
				{
					int.TryParse(array[0], out this.major);
				}
				if (array.Length > 1)
				{
					int.TryParse(array[1], out this.minor);
				}
			}

			// Token: 0x0600305A RID: 12378 RVA: 0x000A8EF4 File Offset: 0x000A70F4
			public override string ToString()
			{
				return string.Concat(new string[]
				{
					this.major.ToString(),
					".",
					this.minor.ToString(),
					".",
					this.maintenance.ToString(),
					this.aPXhYBIlEWADgqMqoNPvVTRQUZhC(this.type),
					this.build.ToString()
				});
			}

			// Token: 0x0600305B RID: 12379 RVA: 0x00024E30 File Offset: 0x00023030
			private string aPXhYBIlEWADgqMqoNPvVTRQUZhC(UnityTools.UnityVersionClass.qQGMOrnNThGcpashhYUHBtQoKFmp A_1)
			{
				switch (A_1)
				{
				case UnityTools.UnityVersionClass.qQGMOrnNThGcpashhYUHBtQoKFmp.Normal:
					return "f";
				case UnityTools.UnityVersionClass.qQGMOrnNThGcpashhYUHBtQoKFmp.Beta:
					return "b";
				case UnityTools.UnityVersionClass.qQGMOrnNThGcpashhYUHBtQoKFmp.Patch:
					return "p";
				default:
					throw new NotImplementedException();
				}
			}

			// Token: 0x0600305C RID: 12380 RVA: 0x00024E5D File Offset: 0x0002305D
			public override bool Equals(object obj)
			{
				return obj is UnityTools.UnityVersionClass && this == (UnityTools.UnityVersionClass)obj;
			}

			// Token: 0x0600305D RID: 12381 RVA: 0x00024E75 File Offset: 0x00023075
			public override int GetHashCode()
			{
				return base.GetHashCode();
			}

			// Token: 0x0600305E RID: 12382 RVA: 0x00024E7D File Offset: 0x0002307D
			public static bool operator <(UnityTools.UnityVersionClass a, UnityTools.UnityVersionClass b)
			{
				return UnityTools.UnityVersionClass.Comparison(a, b) < 0;
			}

			// Token: 0x0600305F RID: 12383 RVA: 0x00024E89 File Offset: 0x00023089
			public static bool operator >(UnityTools.UnityVersionClass a, UnityTools.UnityVersionClass b)
			{
				return UnityTools.UnityVersionClass.Comparison(a, b) > 0;
			}

			// Token: 0x06003060 RID: 12384 RVA: 0x00024E95 File Offset: 0x00023095
			public static bool operator >=(UnityTools.UnityVersionClass a, UnityTools.UnityVersionClass b)
			{
				return UnityTools.UnityVersionClass.Comparison(a, b) >= 0;
			}

			// Token: 0x06003061 RID: 12385 RVA: 0x00024EA4 File Offset: 0x000230A4
			public static bool operator <=(UnityTools.UnityVersionClass a, UnityTools.UnityVersionClass b)
			{
				return UnityTools.UnityVersionClass.Comparison(a, b) <= 0;
			}

			// Token: 0x06003062 RID: 12386 RVA: 0x00024EB3 File Offset: 0x000230B3
			public static bool operator ==(UnityTools.UnityVersionClass a, UnityTools.UnityVersionClass b)
			{
				return UnityTools.UnityVersionClass.Comparison(a, b) == 0;
			}

			// Token: 0x06003063 RID: 12387 RVA: 0x00024EBF File Offset: 0x000230BF
			public static bool operator !=(UnityTools.UnityVersionClass a, UnityTools.UnityVersionClass b)
			{
				return UnityTools.UnityVersionClass.Comparison(a, b) != 0;
			}

			// Token: 0x06003064 RID: 12388 RVA: 0x000A8F70 File Offset: 0x000A7170
			public static int Comparison(UnityTools.UnityVersionClass a, UnityTools.UnityVersionClass b)
			{
				if (object.Equals(a, null) && object.Equals(b, null))
				{
					return 0;
				}
				if (object.Equals(a, null))
				{
					return -1;
				}
				if (object.Equals(b, null))
				{
					return 1;
				}
				if (a.major > b.major)
				{
					return 1;
				}
				if (a.major < b.major)
				{
					return -1;
				}
				if (a.minor > b.minor)
				{
					return 1;
				}
				if (a.minor < b.minor)
				{
					return -1;
				}
				if (a.maintenance > b.maintenance)
				{
					return 1;
				}
				if (a.maintenance < b.maintenance)
				{
					return -1;
				}
				if (UnityTools.UnityVersionClass.nsZSIuonnWfvADoPnoftMuhCwgey(a.type) > UnityTools.UnityVersionClass.nsZSIuonnWfvADoPnoftMuhCwgey(b.type))
				{
					return 1;
				}
				if (UnityTools.UnityVersionClass.nsZSIuonnWfvADoPnoftMuhCwgey(a.type) < UnityTools.UnityVersionClass.nsZSIuonnWfvADoPnoftMuhCwgey(b.type))
				{
					return -1;
				}
				if (a.build > b.build)
				{
					return 1;
				}
				if (a.build < b.build)
				{
					return -1;
				}
				return 0;
			}

			// Token: 0x06003065 RID: 12389 RVA: 0x000A905C File Offset: 0x000A725C
			public static bool IsValidVersionString(string versionString)
			{
				if (string.IsNullOrEmpty(versionString))
				{
					return false;
				}
				if (!versionString.Contains("."))
				{
					return false;
				}
				string[] array = versionString.Split('.', StringSplitOptions.None);
				int num;
				return array.Length >= 3 && Regex.IsMatch(array[0], "^[0-9]+$") && Regex.IsMatch(array[1], "^[0-9]+$") && int.TryParse(array[0], out num) && int.TryParse(array[1], out num) && Regex.IsMatch(array[2], "^[0-9]+");
			}

			// Token: 0x06003066 RID: 12390 RVA: 0x00024ECB File Offset: 0x000230CB
			private static int nsZSIuonnWfvADoPnoftMuhCwgey(UnityTools.UnityVersionClass.qQGMOrnNThGcpashhYUHBtQoKFmp A_0)
			{
				switch (A_0)
				{
				case UnityTools.UnityVersionClass.qQGMOrnNThGcpashhYUHBtQoKFmp.Normal:
					return 10;
				case UnityTools.UnityVersionClass.qQGMOrnNThGcpashhYUHBtQoKFmp.Beta:
					return 0;
				case UnityTools.UnityVersionClass.qQGMOrnNThGcpashhYUHBtQoKFmp.Patch:
					return 100;
				default:
					throw new NotImplementedException();
				}
			}

			// Token: 0x04001A8F RID: 6799
			public readonly int major;

			// Token: 0x04001A90 RID: 6800
			public readonly int minor;

			// Token: 0x04001A91 RID: 6801
			public readonly int maintenance;

			// Token: 0x04001A92 RID: 6802
			public readonly UnityTools.UnityVersionClass.qQGMOrnNThGcpashhYUHBtQoKFmp type;

			// Token: 0x04001A93 RID: 6803
			public readonly int build;

			// Token: 0x020004A0 RID: 1184
			public enum qQGMOrnNThGcpashhYUHBtQoKFmp
			{
				// Token: 0x04001A95 RID: 6805
				Normal,
				// Token: 0x04001A96 RID: 6806
				Beta,
				// Token: 0x04001A97 RID: 6807
				Patch
			}
		}
	}
}
