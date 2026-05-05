using System;
using System.Runtime.InteropServices;
using Rewired.Platforms.Microsoft.WindowsGamingInput;

// Token: 0x02000099 RID: 153
internal static class OTylkQqSSfezJYDMKEvvfyLhOqsl
{
	// Token: 0x06000521 RID: 1313
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "IUnknown_Release")]
	private static extern ulong SnLPAvRNQsNVKJaLWjrEIPzgoXbH(IntPtr);

	// Token: 0x06000522 RID: 1314 RVA: 0x00013BAD File Offset: 0x00011DAD
	public static ulong KZulFwSnbQcIOgYOVWyJFMZkIJpT(IntPtr A_0)
	{
		if (A_0 == IntPtr.Zero)
		{
			return 0UL;
		}
		return OTylkQqSSfezJYDMKEvvfyLhOqsl.SnLPAvRNQsNVKJaLWjrEIPzgoXbH(A_0);
	}

	// Token: 0x06000523 RID: 1315
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "IUnknown_AddRef")]
	private static extern ulong jjhclNeCOrmOLMTgIlElJxcRaemvA(IntPtr);

	// Token: 0x06000524 RID: 1316 RVA: 0x00013BC5 File Offset: 0x00011DC5
	public static ulong qVJeBYciqiTudgBtJbcDVWRwdkTeb(IntPtr A_0)
	{
		if (A_0 == IntPtr.Zero)
		{
			return 0UL;
		}
		return OTylkQqSSfezJYDMKEvvfyLhOqsl.jjhclNeCOrmOLMTgIlElJxcRaemvA(A_0);
	}

	// Token: 0x06000525 RID: 1317
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Core_IsAPISupported")]
	[return: MarshalAs(UnmanagedType.I1)]
	public static extern bool HpdeVuIkFqWPJzbJBbjHwPViSNTq();

	// Token: 0x06000526 RID: 1318
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Core_GetMinimumRequiredWindowsVersionString")]
	private static extern IntPtr LWdhhiArLErxzsoovaiYJwzhdJlIA();

	// Token: 0x06000527 RID: 1319 RVA: 0x00032710 File Offset: 0x00030910
	public static string lpUAFojSpGctSStyjkatEyCSWeWgb()
	{
		IntPtr intPtr = OTylkQqSSfezJYDMKEvvfyLhOqsl.LWdhhiArLErxzsoovaiYJwzhdJlIA();
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		return Marshal.PtrToStringUni(intPtr);
	}

	// Token: 0x06000528 RID: 1320
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetGamepads")]
	public static extern tAZOAUSqNiGMUGbgZXbKxgMiCPZRA zyCErkJPnCIPPGgPhKimWODNmumjc();

	// Token: 0x06000529 RID: 1321
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetGamepadCount")]
	public static extern uint utXMsLemWGIbbqvjUfHFqKrcUTD(IntPtr);

	// Token: 0x0600052A RID: 1322
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetGamepad")]
	public static extern tAZOAUSqNiGMUGbgZXbKxgMiCPZRA joAiKcnmZguNjHyqjFMDKAmASkUq(IntPtr, uint);

	// Token: 0x0600052B RID: 1323
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetCurrentReading")]
	public static extern bool EiiZNIRSArdtZmQdBRrckvoVkVvy(IntPtr, ref OYybvidAyFwiwrJXZnlYENlOguncA);

	// Token: 0x0600052C RID: 1324
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetVibration")]
	public static extern bool yszalCjSiwjKrVytBntOlGmdufubA(IntPtr, ref BnFiTEhittEzLCwZuNtphKZVBdZZA);

	// Token: 0x0600052D RID: 1325
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_SetVibration")]
	public static extern void lvmcqXgWyjyBRslojYGhRJyxYjzp(IntPtr, [MarshalAs(UnmanagedType.Struct)] [In] BnFiTEhittEzLCwZuNtphKZVBdZZA);

	// Token: 0x0600052E RID: 1326
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetUser")]
	private static extern IntPtr cJKyrQQeBLEBtrlWZkOzwtFPQPEL(IntPtr);

	// Token: 0x0600052F RID: 1327 RVA: 0x00032738 File Offset: 0x00030938
	public static foZpnAigfwHUebOyotkboVTdBGmvA ouoQmVWXvjSMDLugwfrYqZdHSKsC(IntPtr A_0)
	{
		IntPtr intPtr = OTylkQqSSfezJYDMKEvvfyLhOqsl.cJKyrQQeBLEBtrlWZkOzwtFPQPEL(A_0);
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		return new foZpnAigfwHUebOyotkboVTdBGmvA(new CSdTAxmcdEqsJycjIssPCexJQcDP(intPtr));
	}

	// Token: 0x06000530 RID: 1328
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_IsGamepad")]
	public static extern bool AscrMCHkUpPwJXTlAVizfCgjXqeD(IntPtr);

	// Token: 0x06000531 RID: 1329
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_FromGameController")]
	public static extern tAZOAUSqNiGMUGbgZXbKxgMiCPZRA ogLKLrkefBHOupiiaEYNfulmygAK(IntPtr);

	// Token: 0x06000532 RID: 1330
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_GetButtonLabel")]
	public static extern vfAEkZGepuMjeIOTSGrJsumxepKZA JHXMEvFdVQRlTkBhwfgreXjODQCPA(IntPtr, GamepadButtons);

	// Token: 0x06000533 RID: 1331
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_ListenForEvents")]
	public static extern void KAqDAiJEEOYYeOVVypeLjtxDwuKDA();

	// Token: 0x06000534 RID: 1332
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_StopListeningForEvents")]
	public static extern void vflLkHpkZbdDxeQCeOeGjwcKAGCZ();

	// Token: 0x06000535 RID: 1333
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_SetEventListener_GamepadAdded")]
	public static extern void rtgHYMCRydeVSYBQmgIDdNXUOlwi(OTylkQqSSfezJYDMKEvvfyLhOqsl.gHopSeoOtPcvqGoIWPeDIlGyLuySA);

	// Token: 0x06000536 RID: 1334
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "Gamepad_SetEventListener_GamepadRemoved")]
	public static extern void AreriQmTyLgXmLaGHxmGNYKJUbrl(OTylkQqSSfezJYDMKEvvfyLhOqsl.ZAitvOrRGQmVXEaBSPxpgBJABHIl);

	// Token: 0x06000537 RID: 1335
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetRawGameControllerCount")]
	public static extern uint BQRUWCXIndRRTtmWTExcjwJDtxEN(IntPtr);

	// Token: 0x06000538 RID: 1336
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetRawGameControllers")]
	public static extern tAZOAUSqNiGMUGbgZXbKxgMiCPZRA pxMSUttbMBcIQFLJsbTGHJdiDTO();

	// Token: 0x06000539 RID: 1337
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetRawGameController")]
	public static extern tAZOAUSqNiGMUGbgZXbKxgMiCPZRA GKeAVidnJFGNshszJszHQveOhHsOB(IntPtr, uint);

	// Token: 0x0600053A RID: 1338
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetCurrentReading")]
	private static extern ulong gnLfnXGafrFbELYEfStILMOpHiuG(IntPtr, bool[], uint, RusnSqoKMHpCQIijqSFCKFFyiPvX[], uint, double[], uint);

	// Token: 0x0600053B RID: 1339 RVA: 0x00013BDD File Offset: 0x00011DDD
	public static ulong nETKpjJBsCbCTfiqAZUJauqLiTnRA(IntPtr A_0, bool[] A_1, RusnSqoKMHpCQIijqSFCKFFyiPvX[] A_2, double[] A_3)
	{
		return OTylkQqSSfezJYDMKEvvfyLhOqsl.gnLfnXGafrFbELYEfStILMOpHiuG(A_0, A_1, (uint)A_1.Length, A_2, (uint)A_2.Length, A_3, (uint)A_3.Length);
	}

	// Token: 0x0600053C RID: 1340
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetIsWireless")]
	public static extern bool ibeehKJmIFWBTRHnNmXLeHMWVvtq(IntPtr);

	// Token: 0x0600053D RID: 1341
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetSimpleHapticsControllers")]
	public static extern tAZOAUSqNiGMUGbgZXbKxgMiCPZRA vgxqysCBfSZFljVnwOrsoTeRetnv(IntPtr);

	// Token: 0x0600053E RID: 1342
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetSimpleHapticsControllerCount")]
	public static extern uint xOOVAqgdZnrwSUtHlxfMXYCrjRXv(IntPtr);

	// Token: 0x0600053F RID: 1343
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetUser")]
	public static extern tAZOAUSqNiGMUGbgZXbKxgMiCPZRA HtucVlDfHCCqriRyMgSAXHvlwXfp(IntPtr);

	// Token: 0x06000540 RID: 1344
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetButtonCount")]
	public static extern int gEkHWqVLiMheQbvYSyKvXPunPMRW(IntPtr);

	// Token: 0x06000541 RID: 1345
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetSwitchCount")]
	public static extern int SrGOqAiCLGbndrgZuwagJDZBoKzw(IntPtr);

	// Token: 0x06000542 RID: 1346
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetAxisCount")]
	public static extern int ekAmqKwTMjutmWNjHqPuHmgUSODC(IntPtr);

	// Token: 0x06000543 RID: 1347
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetDisplayName")]
	private static extern IntPtr preLWOJylPPvnHglaQHBppaJglEfA(IntPtr);

	// Token: 0x06000544 RID: 1348 RVA: 0x00032768 File Offset: 0x00030968
	public static string tdtJsCGPntqkmrGwRmUJyIdTkucf(IntPtr A_0)
	{
		IntPtr intPtr = OTylkQqSSfezJYDMKEvvfyLhOqsl.preLWOJylPPvnHglaQHBppaJglEfA(A_0);
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		return Marshal.PtrToStringUni(intPtr);
	}

	// Token: 0x06000545 RID: 1349
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetForceFeedbackMotors")]
	public static extern tAZOAUSqNiGMUGbgZXbKxgMiCPZRA ydRSiGoPMXDwDAonTkyoEpoeHtKab(IntPtr);

	// Token: 0x06000546 RID: 1350
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetForceFeedbackMotorCount")]
	public static extern uint oWLfNziaCNKLeCODzEqGYuJovVKfA(IntPtr);

	// Token: 0x06000547 RID: 1351
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetButtonLabel")]
	public static extern vfAEkZGepuMjeIOTSGrJsumxepKZA qiAneCztYOWMMnBFbuDkkKmYYFxi(IntPtr, int);

	// Token: 0x06000548 RID: 1352
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetSwitchKind")]
	public static extern eBdpeEGEopBitGCUarHieKhbNlJR CuiuXrncOCnlSzxNHlcMdHIFwHgi(IntPtr, int);

	// Token: 0x06000549 RID: 1353
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetHardwareVendorId")]
	public static extern ushort dcDxvUOSiUkpDAtdooXvVZiLrFNt(IntPtr);

	// Token: 0x0600054A RID: 1354
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetHardwareProductId")]
	public static extern ushort VbxYeGKZWUgYQHcJrKWkCSwaEPRS(IntPtr);

	// Token: 0x0600054B RID: 1355
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_TryGetBatteryReport")]
	public static extern tAZOAUSqNiGMUGbgZXbKxgMiCPZRA iIuzwwWqqkQSxJCfPBDEVvnOBoEGA(IntPtr);

	// Token: 0x0600054C RID: 1356
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetNonRoamableId")]
	public static extern IntPtr EavqBRUjcRurZvObtKnOIMOttloF(IntPtr);

	// Token: 0x0600054D RID: 1357 RVA: 0x00032794 File Offset: 0x00030994
	public static string QGiSmAZtCTLVEPxDaHyBxDksPXZS(IntPtr A_0)
	{
		IntPtr intPtr = OTylkQqSSfezJYDMKEvvfyLhOqsl.EavqBRUjcRurZvObtKnOIMOttloF(A_0);
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		return Marshal.PtrToStringUni(intPtr);
	}

	// Token: 0x0600054E RID: 1358
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_GetHeadset")]
	public static extern tAZOAUSqNiGMUGbgZXbKxgMiCPZRA UvqcSvJADvmZNjcQYEBctjJrUlKvA(IntPtr);

	// Token: 0x0600054F RID: 1359
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_IsRawGameController")]
	public static extern bool ZuMBpvsYkrIJcJdYJYtMQIvTDQQt(IntPtr);

	// Token: 0x06000550 RID: 1360
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_FromGameController")]
	public static extern tAZOAUSqNiGMUGbgZXbKxgMiCPZRA HkimXJAHEGprtLFUfkmdxsbUlgSn(IntPtr);

	// Token: 0x06000551 RID: 1361
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_ListenForEvents")]
	public static extern void gEZhLOhLXYDlQmGdcqVqhDzfJIRI();

	// Token: 0x06000552 RID: 1362
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_StopListeningForEvents")]
	public static extern void KXbABOeRgtoozuxHEGHLrZzTKBdgA();

	// Token: 0x06000553 RID: 1363
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_SetEventListener_RawGameControllerAdded")]
	public static extern void EbCzYQLNHSgdDrLHWFwVAczUEgXfb(OTylkQqSSfezJYDMKEvvfyLhOqsl.avucubfkdHzspMHBzRSjiwEUuSlkA);

	// Token: 0x06000554 RID: 1364
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "RawGameController_SetEventListener_RawGameControllerRemoved")]
	public static extern void YWaaQJHarYxwMrvwYuBZVjBQateO(OTylkQqSSfezJYDMKEvvfyLhOqsl.acILCLJixyPKcobZtfpYSreTOScE);

	// Token: 0x06000555 RID: 1365
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "User_GetType")]
	private static extern int ktAtXQSGTeakFCtmBOvTYzEMUGvi(IntPtr);

	// Token: 0x06000556 RID: 1366 RVA: 0x00013BF1 File Offset: 0x00011DF1
	public static HvgfMrFulMIoGYnynqCYXdyqmmvjA RPDdtdqkBImnbcqeFeQsoefRTeUb(IntPtr A_0)
	{
		if (A_0 == IntPtr.Zero)
		{
			return HvgfMrFulMIoGYnynqCYXdyqmmvjA.LocalUser;
		}
		return (HvgfMrFulMIoGYnynqCYXdyqmmvjA)OTylkQqSSfezJYDMKEvvfyLhOqsl.ktAtXQSGTeakFCtmBOvTYzEMUGvi(A_0);
	}

	// Token: 0x06000557 RID: 1367
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "User_GetNonRoamableId")]
	private static extern IntPtr ryeLqWoBOrWwSlczHaHXFMuzfAznA(IntPtr);

	// Token: 0x06000558 RID: 1368 RVA: 0x000327C0 File Offset: 0x000309C0
	public static string NBFDDfXdTSccqOUieMTnypqccPvo(IntPtr A_0)
	{
		IntPtr intPtr = OTylkQqSSfezJYDMKEvvfyLhOqsl.ryeLqWoBOrWwSlczHaHXFMuzfAznA(A_0);
		if (intPtr == IntPtr.Zero)
		{
			return null;
		}
		return Marshal.PtrToStringUni(intPtr);
	}

	// Token: 0x06000559 RID: 1369
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_GetMainCoreWindow")]
	private static extern tAZOAUSqNiGMUGbgZXbKxgMiCPZRA LfdHwwvjBCrdMucxPTjwdgJzFcni();

	// Token: 0x0600055A RID: 1370 RVA: 0x00013C08 File Offset: 0x00011E08
	public static tAZOAUSqNiGMUGbgZXbKxgMiCPZRA EilxIfwQDDHkebZqJqTiDcFJPjXN()
	{
		return OTylkQqSSfezJYDMKEvvfyLhOqsl.LfdHwwvjBCrdMucxPTjwdgJzFcni();
	}

	// Token: 0x0600055B RID: 1371
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_AddEventListener_KeyUp")]
	private static extern IntPtr vqFmgFgolBGQNfADCxewgafMNsHjA(IntPtr);

	// Token: 0x0600055C RID: 1372 RVA: 0x000327EC File Offset: 0x000309EC
	public static MHahaBmdMIfViGEbjnMJMMDhHLBTA wRaPTRkQTOrIMYTgWaXyvscAvBzS(IntPtr A_0)
	{
		if (A_0 == IntPtr.Zero)
		{
			return null;
		}
		MHahaBmdMIfViGEbjnMJMMDhHLBTA result;
		try
		{
			IntPtr intPtr = OTylkQqSSfezJYDMKEvvfyLhOqsl.vqFmgFgolBGQNfADCxewgafMNsHjA(A_0);
			if (intPtr == IntPtr.Zero)
			{
				result = null;
			}
			else
			{
				result = new MHahaBmdMIfViGEbjnMJMMDhHLBTA(intPtr);
			}
		}
		catch (Exception)
		{
			result = null;
		}
		return result;
	}

	// Token: 0x0600055D RID: 1373
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_AddEventListener_KeyDown")]
	private static extern IntPtr PprDyeWCLUOnQUBdpIYzrMrZanHv(IntPtr);

	// Token: 0x0600055E RID: 1374 RVA: 0x00032840 File Offset: 0x00030A40
	public static MHahaBmdMIfViGEbjnMJMMDhHLBTA OeJIgvuhDDnmRZSsUIMhdbKgKUgU(IntPtr A_0)
	{
		if (A_0 == IntPtr.Zero)
		{
			return null;
		}
		MHahaBmdMIfViGEbjnMJMMDhHLBTA result;
		try
		{
			IntPtr intPtr = OTylkQqSSfezJYDMKEvvfyLhOqsl.PprDyeWCLUOnQUBdpIYzrMrZanHv(A_0);
			if (intPtr == IntPtr.Zero)
			{
				result = null;
			}
			else
			{
				result = new MHahaBmdMIfViGEbjnMJMMDhHLBTA(intPtr);
			}
		}
		catch (Exception)
		{
			result = null;
		}
		return result;
	}

	// Token: 0x0600055F RID: 1375
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_RemoveEventListener_KeyUp")]
	private static extern void NHeKkcrqjKDXHAnPtyIUWCHADCEH(IntPtr, IntPtr);

	// Token: 0x06000560 RID: 1376 RVA: 0x00013C0F File Offset: 0x00011E0F
	public static void coouaBFwIGUJmZXgkJhzIXMUNtbc(IntPtr A_0, MHahaBmdMIfViGEbjnMJMMDhHLBTA A_1)
	{
		if (A_0 == IntPtr.Zero)
		{
			return;
		}
		if (WktzxpTwfQRpFnSASyyslwPFpaDl.mdLlXvkWnwOUrtNUsszTyRBCHdmN(A_1, null))
		{
			return;
		}
		OTylkQqSSfezJYDMKEvvfyLhOqsl.NHeKkcrqjKDXHAnPtyIUWCHADCEH(A_0, A_1.xTnEyWcUvjrbwceGKuWjarIZSzlu);
	}

	// Token: 0x06000561 RID: 1377
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_RemoveEventListener_KeyDown")]
	private static extern void TuZvRcuFCPBublBRHlfoWjKkEbThA(IntPtr, IntPtr);

	// Token: 0x06000562 RID: 1378 RVA: 0x00013C35 File Offset: 0x00011E35
	public static void NRPTOfudVJNGUHMTAxWwxCtrQPYO(IntPtr A_0, MHahaBmdMIfViGEbjnMJMMDhHLBTA A_1)
	{
		if (A_0 == IntPtr.Zero)
		{
			return;
		}
		if (WktzxpTwfQRpFnSASyyslwPFpaDl.mdLlXvkWnwOUrtNUsszTyRBCHdmN(A_1, null))
		{
			return;
		}
		OTylkQqSSfezJYDMKEvvfyLhOqsl.TuZvRcuFCPBublBRHlfoWjKkEbThA(A_0, A_1.xTnEyWcUvjrbwceGKuWjarIZSzlu);
	}

	// Token: 0x06000563 RID: 1379
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_SetUniversalEventListener_KeyUp")]
	private static extern void piRqteWVHGiglpdhSnqqDXzGYMyf(OTylkQqSSfezJYDMKEvvfyLhOqsl.gymPFvjzwWPbbfyjiMFmCDAQbFFz);

	// Token: 0x06000564 RID: 1380 RVA: 0x00013C5B File Offset: 0x00011E5B
	public static void CAmnyGaAthNSYOQRAlJVmXupKqBG(OTylkQqSSfezJYDMKEvvfyLhOqsl.gymPFvjzwWPbbfyjiMFmCDAQbFFz A_0)
	{
		OTylkQqSSfezJYDMKEvvfyLhOqsl.piRqteWVHGiglpdhSnqqDXzGYMyf(A_0);
	}

	// Token: 0x06000565 RID: 1381
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_ClearUniversalEventListener_KeyUp")]
	private static extern void XyxmwVGBSwghklKLgALKaVIQGBTvA();

	// Token: 0x06000566 RID: 1382 RVA: 0x00013C63 File Offset: 0x00011E63
	public static void XmVsXonzufCYoqpYvoQoCQdLUhiP()
	{
		OTylkQqSSfezJYDMKEvvfyLhOqsl.XyxmwVGBSwghklKLgALKaVIQGBTvA();
	}

	// Token: 0x06000567 RID: 1383
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_SetUniversalEventListener_KeyDown")]
	private static extern void NCYbvEZndjbSTsFgIlFPgidccxCl(OTylkQqSSfezJYDMKEvvfyLhOqsl.gymPFvjzwWPbbfyjiMFmCDAQbFFz);

	// Token: 0x06000568 RID: 1384 RVA: 0x00013C6A File Offset: 0x00011E6A
	public static void pQzEaTDaMhCQmFtYLUCdHBcGzyKDA(OTylkQqSSfezJYDMKEvvfyLhOqsl.gymPFvjzwWPbbfyjiMFmCDAQbFFz A_0)
	{
		OTylkQqSSfezJYDMKEvvfyLhOqsl.NCYbvEZndjbSTsFgIlFPgidccxCl(A_0);
	}

	// Token: 0x06000569 RID: 1385
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreWindow_ClearUniversalEventListener_KeyDown")]
	private static extern void jcNFGxsgiLAQlCxbLGCJfUFSzQTVA();

	// Token: 0x0600056A RID: 1386 RVA: 0x00013C72 File Offset: 0x00011E72
	public static void FznSTUdXFyqeowiLYHNsyVMFvPcC()
	{
		OTylkQqSSfezJYDMKEvvfyLhOqsl.jcNFGxsgiLAQlCxbLGCJfUFSzQTVA();
	}

	// Token: 0x0600056B RID: 1387 RVA: 0x00032894 File Offset: 0x00030A94
	public static kAaDefoAWYDLSOHpRgwqurtmaDAX CJPTjduQUuDvEeBmVfsItKaTqSqxA(IntPtr A_0)
	{
		if (A_0 == IntPtr.Zero)
		{
			return default(kAaDefoAWYDLSOHpRgwqurtmaDAX);
		}
		return new kAaDefoAWYDLSOHpRgwqurtmaDAX(OTylkQqSSfezJYDMKEvvfyLhOqsl.UZXuOJGSKSdvNKdNpBsPWWfgySAd(A_0), OTylkQqSSfezJYDMKEvvfyLhOqsl.XhAePMJYDPaazHTKIbSliMKjCCZQb(A_0), OTylkQqSSfezJYDMKEvvfyLhOqsl.JPkACvEWERYKjLjVWZmyupFusMQoA(A_0));
	}

	// Token: 0x0600056C RID: 1388
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "KeyEventArgs_GetHandled")]
	private static extern bool UZXuOJGSKSdvNKdNpBsPWWfgySAd(IntPtr);

	// Token: 0x0600056D RID: 1389
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "KeyEventArgs_GetVirtualKey")]
	private static extern DPNOrvTkdgTIjOfKUihUEbdEuLUx JPkACvEWERYKjLjVWZmyupFusMQoA(IntPtr);

	// Token: 0x0600056E RID: 1390
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "KeyEventArgs_GetKeyStatus")]
	private static extern IntPtr LhMFOmeZxoWATdbDpQmhHYTiGPDEb(IntPtr);

	// Token: 0x0600056F RID: 1391 RVA: 0x000328D0 File Offset: 0x00030AD0
	private static kVGnyeyHEFvTEbCIzxKzonQsRKzv XhAePMJYDPaazHTKIbSliMKjCCZQb(IntPtr A_0)
	{
		if (A_0 == IntPtr.Zero)
		{
			return default(kVGnyeyHEFvTEbCIzxKzonQsRKzv);
		}
		IntPtr intPtr = OTylkQqSSfezJYDMKEvvfyLhOqsl.LhMFOmeZxoWATdbDpQmhHYTiGPDEb(A_0);
		if (intPtr == IntPtr.Zero)
		{
			return default(kVGnyeyHEFvTEbCIzxKzonQsRKzv);
		}
		kVGnyeyHEFvTEbCIzxKzonQsRKzv result = OTylkQqSSfezJYDMKEvvfyLhOqsl.HMicrvURGpMMxynsUWYASnlsndcV(intPtr);
		OTylkQqSSfezJYDMKEvvfyLhOqsl.wGtURDnhDWHyUdVnUlhvrCtOTmrx(intPtr);
		return result;
	}

	// Token: 0x06000570 RID: 1392
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreDispatcher_GetMainCoreDispatcher")]
	private static extern tAZOAUSqNiGMUGbgZXbKxgMiCPZRA doFcMLIIYDqRXMhFZjvhzqinefuD();

	// Token: 0x06000571 RID: 1393 RVA: 0x00013C79 File Offset: 0x00011E79
	public static tAZOAUSqNiGMUGbgZXbKxgMiCPZRA LNvymFHCogandFueICrtJRTBWeMjA()
	{
		return OTylkQqSSfezJYDMKEvvfyLhOqsl.doFcMLIIYDqRXMhFZjvhzqinefuD();
	}

	// Token: 0x06000572 RID: 1394
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreDispatcher_AddEventListener_AcceleratorKeyActivated")]
	private static extern IntPtr jzoQPdUtArKQnYVFyGmwKKKRBKHD(IntPtr);

	// Token: 0x06000573 RID: 1395 RVA: 0x00032924 File Offset: 0x00030B24
	public static MHahaBmdMIfViGEbjnMJMMDhHLBTA wjmQfvueYaPHBaUnnjPzYubeaiVp(IntPtr A_0)
	{
		MHahaBmdMIfViGEbjnMJMMDhHLBTA result;
		try
		{
			IntPtr intPtr = OTylkQqSSfezJYDMKEvvfyLhOqsl.jzoQPdUtArKQnYVFyGmwKKKRBKHD(A_0);
			if (intPtr == IntPtr.Zero)
			{
				result = null;
			}
			else
			{
				result = new MHahaBmdMIfViGEbjnMJMMDhHLBTA(intPtr);
			}
		}
		catch (Exception)
		{
			result = null;
		}
		return result;
	}

	// Token: 0x06000574 RID: 1396
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreDispatcher_RemoveEventListener_AcceleratorKeyActivated")]
	private static extern void qnpKETLZfjGqugxZeRJFdYXKPUBw(IntPtr, IntPtr);

	// Token: 0x06000575 RID: 1397 RVA: 0x00013C80 File Offset: 0x00011E80
	public static void fuMiksjwItKPueWIMpsnrhTejfxs(IntPtr A_0, MHahaBmdMIfViGEbjnMJMMDhHLBTA A_1)
	{
		if (WktzxpTwfQRpFnSASyyslwPFpaDl.mdLlXvkWnwOUrtNUsszTyRBCHdmN(A_1, null))
		{
			return;
		}
		OTylkQqSSfezJYDMKEvvfyLhOqsl.qnpKETLZfjGqugxZeRJFdYXKPUBw(A_0, A_1.xTnEyWcUvjrbwceGKuWjarIZSzlu);
	}

	// Token: 0x06000576 RID: 1398
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreDispatcher_SetUniversalEventListener_AcceleratorKeyActivated")]
	private static extern void dwGKHdmsGxHKIbcVVomaiatzVwnGA(OTylkQqSSfezJYDMKEvvfyLhOqsl.NXocYThFugaIcVGgvViGwZbtlzTKA);

	// Token: 0x06000577 RID: 1399 RVA: 0x00013C98 File Offset: 0x00011E98
	public static void SrBEYAajNlAWmreylHvniwHFwbUR(OTylkQqSSfezJYDMKEvvfyLhOqsl.NXocYThFugaIcVGgvViGwZbtlzTKA A_0)
	{
		OTylkQqSSfezJYDMKEvvfyLhOqsl.dwGKHdmsGxHKIbcVVomaiatzVwnGA(A_0);
	}

	// Token: 0x06000578 RID: 1400
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "CoreDispatcher_ClearUniversalEventListener_AcceleratorKeyActivated")]
	private static extern void OyjvFnNrVsRxmJPqnDfjeVFPIddL();

	// Token: 0x06000579 RID: 1401 RVA: 0x00013CA0 File Offset: 0x00011EA0
	public static void LfeKqTAMVxcVtzuaYFQCfUUjbjUzA()
	{
		OTylkQqSSfezJYDMKEvvfyLhOqsl.OyjvFnNrVsRxmJPqnDfjeVFPIddL();
	}

	// Token: 0x0600057A RID: 1402 RVA: 0x00032968 File Offset: 0x00030B68
	public static BvMJGKntZqaCBuJcEnSLTRubwaRA gAeCpEIVTMfrqOXWlJIemkFyBXHj(IntPtr A_0)
	{
		if (A_0 == IntPtr.Zero)
		{
			return default(BvMJGKntZqaCBuJcEnSLTRubwaRA);
		}
		return new BvMJGKntZqaCBuJcEnSLTRubwaRA(OTylkQqSSfezJYDMKEvvfyLhOqsl.PtDophrsofUsTIkGAInbYRzrnLhy(A_0), OTylkQqSSfezJYDMKEvvfyLhOqsl.HztwKYGMCSEkFkUDUCYbwArzlMMK(A_0), OTylkQqSSfezJYDMKEvvfyLhOqsl.PDtvXdRrXGNUcdkJOLiRndJUHgxu(A_0), OTylkQqSSfezJYDMKEvvfyLhOqsl.gqkcbycQyKvbVqKhYKoZFWFCUpdGA(A_0));
	}

	// Token: 0x0600057B RID: 1403
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "AcceleratorKeyEventArgs_GetEventType")]
	private static extern ZnKpLIPqQSOvxIsErQWYUhQstFOL PtDophrsofUsTIkGAInbYRzrnLhy(IntPtr);

	// Token: 0x0600057C RID: 1404
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "AcceleratorKeyEventArgs_GetHandled")]
	private static extern bool HztwKYGMCSEkFkUDUCYbwArzlMMK(IntPtr);

	// Token: 0x0600057D RID: 1405
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "AcceleratorKeyEventArgs_GetVirtualKey")]
	private static extern DPNOrvTkdgTIjOfKUihUEbdEuLUx gqkcbycQyKvbVqKhYKoZFWFCUpdGA(IntPtr);

	// Token: 0x0600057E RID: 1406
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "AcceleratorKeyEventArgs_GetKeyStatus")]
	private static extern IntPtr knkluLJosnBbocFzXMloaUZpUmGQA(IntPtr);

	// Token: 0x0600057F RID: 1407 RVA: 0x000329AC File Offset: 0x00030BAC
	private static kVGnyeyHEFvTEbCIzxKzonQsRKzv PDtvXdRrXGNUcdkJOLiRndJUHgxu(IntPtr A_0)
	{
		if (A_0 == IntPtr.Zero)
		{
			return default(kVGnyeyHEFvTEbCIzxKzonQsRKzv);
		}
		IntPtr intPtr = OTylkQqSSfezJYDMKEvvfyLhOqsl.knkluLJosnBbocFzXMloaUZpUmGQA(A_0);
		if (intPtr == IntPtr.Zero)
		{
			return default(kVGnyeyHEFvTEbCIzxKzonQsRKzv);
		}
		kVGnyeyHEFvTEbCIzxKzonQsRKzv result = OTylkQqSSfezJYDMKEvvfyLhOqsl.HMicrvURGpMMxynsUWYASnlsndcV(intPtr);
		OTylkQqSSfezJYDMKEvvfyLhOqsl.wGtURDnhDWHyUdVnUlhvrCtOTmrx(intPtr);
		return result;
	}

	// Token: 0x06000580 RID: 1408
	[DllImport("Rewired_WindowsGamingInput", CallingConvention = CallingConvention.StdCall, EntryPoint = "SCorePhysicalKeyStatus_Free")]
	private static extern tAZOAUSqNiGMUGbgZXbKxgMiCPZRA wGtURDnhDWHyUdVnUlhvrCtOTmrx(IntPtr);

	// Token: 0x06000581 RID: 1409 RVA: 0x00032A00 File Offset: 0x00030C00
	private static kVGnyeyHEFvTEbCIzxKzonQsRKzv HMicrvURGpMMxynsUWYASnlsndcV(IntPtr A_0)
	{
		if (A_0 == IntPtr.Zero)
		{
			return default(kVGnyeyHEFvTEbCIzxKzonQsRKzv);
		}
		return new kVGnyeyHEFvTEbCIzxKzonQsRKzv
		{
			yrxeJKBDZHfKNEsQAwWbiaYvycUG = (Marshal.ReadByte(A_0, 0) > 0),
			XAVEvyDJaCRVvTyhszayDqOzgJqm = (Marshal.ReadByte(A_0, 1) > 0),
			tICsEqzpotHSwDZSYTHdWrPmlinK = (Marshal.ReadByte(A_0, 2) > 0),
			clyZrLrIHmxRgJqzCfCgZsgRvmyi = (uint)Marshal.ReadInt32(A_0, 4),
			OaqJntiHXnFFkIAJgBvBRVjpsbVj = (uint)Marshal.ReadInt32(A_0, 8),
			HpQwgvWfOWEpybFIaItwfOmvKRiXA = (Marshal.ReadByte(A_0, 12) > 0)
		};
	}

	// Token: 0x04000631 RID: 1585
	public const string ocOAQZgprVoHjFDyiwissfekCdueA = "Rewired_WindowsGamingInput";

	// Token: 0x04000632 RID: 1586
	private const CallingConvention uizTUPibSaPiaikYNglSEJXGVwjO = CallingConvention.StdCall;

	// Token: 0x04000633 RID: 1587
	private const CallingConvention DuKfKrMwIHRsGsAQVeyruHvCNJoe = CallingConvention.StdCall;

	// Token: 0x04000634 RID: 1588
	private const UnmanagedType bvMdZDhXZmFeZWxuwBFbFRtSevrr = UnmanagedType.LPWStr;

	// Token: 0x0200009A RID: 154
	// (Invoke) Token: 0x06000583 RID: 1411
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void gHopSeoOtPcvqGoIWPeDIlGyLuySA(tAZOAUSqNiGMUGbgZXbKxgMiCPZRA pGamepad);

	// Token: 0x0200009B RID: 155
	// (Invoke) Token: 0x06000587 RID: 1415
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void ZAitvOrRGQmVXEaBSPxpgBJABHIl(tAZOAUSqNiGMUGbgZXbKxgMiCPZRA pGamepad);

	// Token: 0x0200009C RID: 156
	// (Invoke) Token: 0x0600058B RID: 1419
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void avucubfkdHzspMHBzRSjiwEUuSlkA(tAZOAUSqNiGMUGbgZXbKxgMiCPZRA pRawGameController);

	// Token: 0x0200009D RID: 157
	// (Invoke) Token: 0x0600058F RID: 1423
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void acILCLJixyPKcobZtfpYSreTOScE(tAZOAUSqNiGMUGbgZXbKxgMiCPZRA pRawGameController);

	// Token: 0x0200009E RID: 158
	// (Invoke) Token: 0x06000593 RID: 1427
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void gymPFvjzwWPbbfyjiMFmCDAQbFFz(tAZOAUSqNiGMUGbgZXbKxgMiCPZRA coreWindow, tAZOAUSqNiGMUGbgZXbKxgMiCPZRA keyEventArgs);

	// Token: 0x0200009F RID: 159
	// (Invoke) Token: 0x06000597 RID: 1431
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void NXocYThFugaIcVGgvViGwZbtlzTKA(tAZOAUSqNiGMUGbgZXbKxgMiCPZRA coreDispatcher, tAZOAUSqNiGMUGbgZXbKxgMiCPZRA acceleratorKeyEventArgs);
}
