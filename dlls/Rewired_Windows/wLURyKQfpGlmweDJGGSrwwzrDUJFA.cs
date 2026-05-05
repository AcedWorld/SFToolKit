using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;
using Rewired.Utils;

// Token: 0x02000043 RID: 67
internal static class wLURyKQfpGlmweDJGGSrwwzrDUJFA
{
	// Token: 0x0600026C RID: 620
	[SuppressUnmanagedCodeSecurity]
	[DllImport("Kernel32.dll", EntryPoint = "GetLastError")]
	public static extern int ZNrGpbunKiAkRfcIGZPtdrKITPCe();

	// Token: 0x0600026D RID: 621
	[SuppressUnmanagedCodeSecurity]
	[DllImport("Kernel32.dll", EntryPoint = "GetCurrentProcess")]
	public static extern IntPtr uoHJZZakUBOmSfJyqHZZmXWOSBut();

	// Token: 0x0600026E RID: 622
	[SuppressUnmanagedCodeSecurity]
	[DllImport("Kernel32.dll", EntryPoint = "GetCurrentProcessId")]
	public static extern uint KNcpuShMqtWsZsPDuUfyTkqnsuhp();

	// Token: 0x0600026F RID: 623
	[SuppressUnmanagedCodeSecurity]
	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "WaitNamedPipe")]
	public static extern int NfktdSmrzOvtmqCcHuqdIIRgYTkm(string, int);

	// Token: 0x06000270 RID: 624
	[SuppressUnmanagedCodeSecurity]
	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "SetNamedPipeHandleState")]
	public static extern int xlLUaAUKHyEPPcvwGxHpqKGiuGgx(IntPtr, ref int, ref int, ref int);

	// Token: 0x06000271 RID: 625
	[SuppressUnmanagedCodeSecurity]
	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "SetNamedPipeHandleState")]
	public static extern int ezEdhQcsuVKRPjlCLhvfJOiTaEbE(IntPtr, ref int, IntPtr, IntPtr);

	// Token: 0x06000272 RID: 626
	[SuppressUnmanagedCodeSecurity]
	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "PeekNamedPipe")]
	public static extern bool FivWScZzQkhlncyAMkXKiUiHsMbH(IntPtr, byte[], int, out int, out int, out int);

	// Token: 0x06000273 RID: 627
	[SuppressUnmanagedCodeSecurity]
	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "HeapAlloc")]
	public static extern IntPtr puCBabgxYVAmFisaGFEDligDqTHU(IntPtr, int, UIntPtr);

	// Token: 0x06000274 RID: 628
	[SuppressUnmanagedCodeSecurity]
	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "HeapFree")]
	public static extern IntPtr xERiPfczHgQnILpUjgkfvwZZoQSdA(IntPtr, int, IntPtr);

	// Token: 0x06000275 RID: 629
	[SuppressUnmanagedCodeSecurity]
	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GetProcessHeap")]
	public static extern IntPtr OQvayKfUVbNZMnPVXemevpnTTEyc();

	// Token: 0x06000276 RID: 630
	[SuppressUnmanagedCodeSecurity]
	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GlobalAlloc")]
	public static extern IntPtr MIgLEAlVFHLtJxTYLJjIMNubiwxr(uint, UIntPtr);

	// Token: 0x06000277 RID: 631
	[SuppressUnmanagedCodeSecurity]
	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GlobalLock")]
	public static extern IntPtr dynieztYjDjcyJqYApiTmuvpucVT(IntPtr);

	// Token: 0x06000278 RID: 632
	[SuppressUnmanagedCodeSecurity]
	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GlobalUnlock")]
	public static extern bool ZXRFFtxCxyKrnDPFWgSfxmvgOlPH(IntPtr);

	// Token: 0x06000279 RID: 633
	[SuppressUnmanagedCodeSecurity]
	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GlobalFree")]
	public static extern IntPtr LNPQgJQjYUjQHIFpHHqgiZNHCBGW(IntPtr);

	// Token: 0x0600027A RID: 634
	[SuppressUnmanagedCodeSecurity]
	[DllImport("Kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GetCurrentThreadId")]
	public static extern int AErvhCafpnjjaVmrTnNIUgqgMJJb();

	// Token: 0x0600027B RID: 635
	[SuppressUnmanagedCodeSecurity]
	[DllImport("Kernel32.dll", EntryPoint = "IsWow64Process")]
	public static extern bool UVkhXtxlixlKvXdCCMSJuQWjNcys(IntPtr, out bool);

	// Token: 0x0600027C RID: 636
	[SuppressUnmanagedCodeSecurity]
	[DllImport("kernel32.dll", EntryPoint = "GetOverlappedResult", SetLastError = true)]
	internal static extern bool cdjqMHUpTyzGowUfvIcOPnUpEiDg(IntPtr, [In] ref NativeOverlapped, out uint, bool);

	// Token: 0x0600027D RID: 637
	[SuppressUnmanagedCodeSecurity]
	[DllImport("kernel32.dll", EntryPoint = "GetOverlappedResult", SetLastError = true)]
	internal static extern bool PLQcUSurcERuJrinQGIrXzomQuGb(IntPtr, IntPtr, out uint, bool);

	// Token: 0x0600027E RID: 638
	[SuppressUnmanagedCodeSecurity]
	[DllImport("user32.dll", CharSet = CharSet.Ansi, EntryPoint = "CreateWindowEx")]
	public static extern IntPtr zFODOlpswvIouTGsJxQBEOCDUQsp(int, string, string, int, int, int, int, int, IntPtr, IntPtr, IntPtr, IntPtr);

	// Token: 0x0600027F RID: 639
	[SuppressUnmanagedCodeSecurity]
	[DllImport("user32.dll", EntryPoint = "DestroyWindow")]
	public static extern IntPtr qNCGaiHGpDkCHpbsosKKQVRcaQNab(IntPtr);

	// Token: 0x06000280 RID: 640
	[SuppressUnmanagedCodeSecurity]
	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CallWindowProc")]
	public static extern IntPtr uxhXNqvhDhiFdnmZahNMiaEpReaiA(IntPtr, IntPtr, uint, IntPtr, IntPtr);

	// Token: 0x06000281 RID: 641
	[SuppressUnmanagedCodeSecurity]
	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "IsWindow")]
	public static extern bool ZSaFSQvRVBboXhmLkzWtKbIrkSMaA(IntPtr);

	// Token: 0x06000282 RID: 642
	[SuppressUnmanagedCodeSecurity]
	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetActiveWindow")]
	private static extern IntPtr eNsQBQQzXfLRKPsnnOLUBGMWvNcG();

	// Token: 0x06000283 RID: 643
	[SuppressUnmanagedCodeSecurity]
	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetFocus")]
	public static extern IntPtr eFgNKTAzQMirIyMhHTzFgRVPDTvb();

	// Token: 0x06000284 RID: 644
	[SuppressUnmanagedCodeSecurity]
	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetForegroundWindow")]
	public static extern IntPtr kHdMXluFWqNCISYjLawcyAFHcKzW();

	// Token: 0x06000285 RID: 645 RVA: 0x00012897 File Offset: 0x00010A97
	public static IntPtr JuOVCBsCjDiYAfraKqxXIUXUpmwgb(IntPtr A_0, int A_1)
	{
		if (IntPtr.Size == 4)
		{
			return wLURyKQfpGlmweDJGGSrwwzrDUJFA.OyXEUUjntjomMiWDvtOecnjFVZnE(A_0, A_1);
		}
		return wLURyKQfpGlmweDJGGSrwwzrDUJFA.CvNpkaUSSvIRFMzFiktLFnYIaDsQ(A_0, A_1);
	}

	// Token: 0x06000286 RID: 646
	[SuppressUnmanagedCodeSecurity]
	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongW")]
	private static extern IntPtr OyXEUUjntjomMiWDvtOecnjFVZnE(IntPtr, int);

	// Token: 0x06000287 RID: 647
	[SuppressUnmanagedCodeSecurity]
	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongPtrW")]
	private static extern IntPtr CvNpkaUSSvIRFMzFiktLFnYIaDsQ(IntPtr, int);

	// Token: 0x06000288 RID: 648 RVA: 0x000128B0 File Offset: 0x00010AB0
	public static IntPtr KDeHKerecLKIxHfgkBKciMXnBzub(IntPtr A_0, int A_1, IntPtr A_2)
	{
		if (IntPtr.Size == 4)
		{
			return wLURyKQfpGlmweDJGGSrwwzrDUJFA.PXvbxkHGUSEGOnSHbPIDZWtjwawVA(A_0, A_1, A_2);
		}
		return wLURyKQfpGlmweDJGGSrwwzrDUJFA.mLgbtncfzDKgVbhIxVuFcofYwOKAA(A_0, A_1, A_2);
	}

	// Token: 0x06000289 RID: 649
	[SuppressUnmanagedCodeSecurity]
	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLongPtrW")]
	private static extern IntPtr mLgbtncfzDKgVbhIxVuFcofYwOKAA(IntPtr, int, IntPtr);

	// Token: 0x0600028A RID: 650
	[SuppressUnmanagedCodeSecurity]
	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLongW")]
	private static extern IntPtr PXvbxkHGUSEGOnSHbPIDZWtjwawVA(IntPtr, int, IntPtr);

	// Token: 0x0600028B RID: 651
	[SuppressUnmanagedCodeSecurity]
	[DllImport("user32.dll", EntryPoint = "DefWindowProcW", SetLastError = true)]
	public static extern IntPtr sHEQLxSHakvVIZesWwnPhLRRpddh(IntPtr, uint, IntPtr, IntPtr);

	// Token: 0x0600028C RID: 652
	[SuppressUnmanagedCodeSecurity]
	[DllImport("User32.dll", EntryPoint = "EnumWindows")]
	private static extern bool UjJRLqCOeRbpsGXxcYWZfoQCsAKv(IntPtr, IntPtr);

	// Token: 0x0600028D RID: 653
	[SuppressUnmanagedCodeSecurity]
	[DllImport("User32.dll", EntryPoint = "GetWindowThreadProcessId")]
	private static extern uint BQAvKfxqUWlVPYKKzskSRpCtATWE(IntPtr, out uint);

	// Token: 0x0600028E RID: 654
	[SuppressUnmanagedCodeSecurity]
	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceList")]
	public static extern uint iKNaxaBdfLYvtPGDOQyGkilmkqXeb(IntPtr, ref uint, uint);

	// Token: 0x0600028F RID: 655
	[SuppressUnmanagedCodeSecurity]
	[DllImport("User32.dll", EntryPoint = "GetRegisteredRawInputDevices")]
	public static extern uint naueMUJQGLLkdkmFpqrreikaeTirb(IntPtr, ref uint, uint);

	// Token: 0x06000290 RID: 656
	[SuppressUnmanagedCodeSecurity]
	[DllImport("User32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceInfoW")]
	public static extern uint cFLDnMKKkyQlORZdIZLYMZZWHgFP(IntPtr, uint, IntPtr, out uint);

	// Token: 0x06000291 RID: 657
	[SuppressUnmanagedCodeSecurity]
	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputData")]
	public static extern int cAMKRMMUDCzSmIrBitGJlgImSDHI(IntPtr, uint, IntPtr, out uint, uint);

	// Token: 0x06000292 RID: 658
	[SuppressUnmanagedCodeSecurity]
	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputBuffer")]
	public static extern int yYFDbOrLJaQAhTBuFCXlGmedPFqIA(IntPtr, ref uint, uint);

	// Token: 0x06000293 RID: 659
	[SuppressUnmanagedCodeSecurity]
	[DllImport("User32.dll", EntryPoint = "SwapMouseButton")]
	public static extern bool oIBcUKhtDwKcqAMTHlZNIMpwaFdSB(bool);

	// Token: 0x06000294 RID: 660
	[SuppressUnmanagedCodeSecurity]
	[DllImport("User32.dll", EntryPoint = "SystemParametersInfo")]
	public static extern bool rHcQbOVZpxknGrFzJJEtBOqKEBhcA(uint, uint, ref int, uint);

	// Token: 0x06000295 RID: 661
	[SuppressUnmanagedCodeSecurity]
	[DllImport("User32.dll", EntryPoint = "GetSystemMetrics")]
	public static extern int SUFYDWJiTvXccbltGKLJRExHXHKr(int);

	// Token: 0x06000296 RID: 662
	[SuppressUnmanagedCodeSecurity]
	[DllImport("User32.dll", EntryPoint = "GetMessageW")]
	public static extern bool RPlIuVvhqrZrssCELQRRuUMPRtuT(IntPtr, IntPtr, uint, uint);

	// Token: 0x06000297 RID: 663
	[SuppressUnmanagedCodeSecurity]
	[DllImport("User32.dll", EntryPoint = "GetMessageW")]
	public unsafe static extern bool bExvEvisjuNrIWYpWHMaRzoBbMbL(void*, void*, uint, uint);

	// Token: 0x06000298 RID: 664
	[SuppressUnmanagedCodeSecurity]
	[DllImport("User32.dll", EntryPoint = "PeekMessageW")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public unsafe static extern bool KWXgpWEqTMIWhbNulhiIAovQXzTJ(void*, IntPtr, uint, uint, uint);

	// Token: 0x06000299 RID: 665
	[SuppressUnmanagedCodeSecurity]
	[DllImport("User32.dll", EntryPoint = "PeekMessageW")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool cDVfIsEbywqudHvuEBgohLkeccsyA(byte[], IntPtr, uint, uint, uint);

	// Token: 0x0600029A RID: 666
	[SuppressUnmanagedCodeSecurity]
	[DllImport("User32.dll", EntryPoint = "DispatchMessage")]
	public static extern IntPtr MggGZGaNBqdjDBlcJiCxokjdMWxO(byte[]);

	// Token: 0x0600029B RID: 667
	[SuppressUnmanagedCodeSecurity]
	[DllImport("User32.dll", EntryPoint = "DispatchMessage")]
	public unsafe static extern IntPtr GjQreUFuPzubFDkLNhuqaKtnyyuP(void*);

	// Token: 0x0600029C RID: 668
	[SuppressUnmanagedCodeSecurity]
	[DllImport("User32.dll", EntryPoint = "TranslateMessage")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool OTztJeErJgVhgEXBaahbgtCXsswR(byte[]);

	// Token: 0x0600029D RID: 669
	[SuppressUnmanagedCodeSecurity]
	[DllImport("User32.dll", EntryPoint = "TranslateMessage")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public unsafe static extern bool FIWusMScvJETiehFMCIzxNWdIdEDb(void*);

	// Token: 0x0600029E RID: 670
	[SuppressUnmanagedCodeSecurity]
	[DllImport("User32.dll", EntryPoint = "SendMessage")]
	public unsafe static extern void* ExvXHpxgBtlMaybUqgrIAwCEDfgzA(void*, uint, void*, void*);

	// Token: 0x0600029F RID: 671
	[SuppressUnmanagedCodeSecurity]
	[DllImport("User32.dll", EntryPoint = "SendMessage")]
	public static extern IntPtr eZeXlofibefApPvJFCMdKESNypAE(IntPtr, uint, IntPtr, IntPtr);

	// Token: 0x060002A0 RID: 672
	[SuppressUnmanagedCodeSecurity]
	[DllImport("User32.dll", EntryPoint = "SendMessageTimeout")]
	public static extern IntPtr wMWBuxgAbgKWrzudrvITaMUooVgqA(IntPtr, uint, IntPtr, IntPtr, uint, uint, IntPtr);

	// Token: 0x060002A1 RID: 673
	[SuppressUnmanagedCodeSecurity]
	[DllImport("User32.dll", EntryPoint = "PostMessage")]
	public static extern bool HHmSVnPaCGLuqtbDoMMxNnEqdxlDA(IntPtr, uint, IntPtr, IntPtr);

	// Token: 0x060002A2 RID: 674
	[SuppressUnmanagedCodeSecurity]
	[DllImport("User32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "PostThreadMessage")]
	public static extern bool gRDNgpdpIOXHTAohncgCfndVONMkA(int, uint, IntPtr, IntPtr);

	// Token: 0x060002A3 RID: 675
	[SuppressUnmanagedCodeSecurity]
	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "SetCursorPos")]
	public static extern bool iQIfJBcQcCHLccyqCEOVFsqeJUHxc(int, int);

	// Token: 0x060002A4 RID: 676
	[SuppressUnmanagedCodeSecurity]
	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetCursorPos")]
	public static extern bool RdrXZAoQXIpNKUMeMBicLsyQbdFm(out AnsNkVbhRzcaJCQtkxaNnQKKVYeU);

	// Token: 0x060002A5 RID: 677
	[SuppressUnmanagedCodeSecurity]
	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "OpenInputDesktop")]
	public static extern IntPtr sFADiWsGqNrUaelLcePntrZxCOnR(uint, bool, uint);

	// Token: 0x060002A6 RID: 678
	[SuppressUnmanagedCodeSecurity]
	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetKeyState")]
	public static extern short EHlPdORcdQAvbEVIJSKSDDKjCQfq(int);

	// Token: 0x060002A7 RID: 679
	[SuppressUnmanagedCodeSecurity]
	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetAsyncKeyState")]
	public static extern short BQnurNQQBkmpGZeACfRMDkAwFPwK(int);

	// Token: 0x060002A8 RID: 680
	[SuppressUnmanagedCodeSecurity]
	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetKeyboardState")]
	public static extern bool hBqoaftnPmGkocNbtDeEAhEfyZMl(IntPtr);

	// Token: 0x060002A9 RID: 681
	[SuppressUnmanagedCodeSecurity]
	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "ClientToScreen")]
	public static extern bool NzMTTeEQAagKoEjRbneeFzNYlvSjA(IntPtr, out AnsNkVbhRzcaJCQtkxaNnQKKVYeU);

	// Token: 0x060002AA RID: 682
	[SuppressUnmanagedCodeSecurity]
	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetClientRect")]
	public static extern bool QAyepktPPBGtJJwunOSujMubbIuXA(IntPtr, out VhfyIGBvPvfSsIHuXvNsminyDaTdA);

	// Token: 0x060002AB RID: 683
	[SuppressUnmanagedCodeSecurity]
	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetWindowRect")]
	public static extern bool sJIqeXmLRzZwVRApCkmnpmSWmWGM(IntPtr, out VhfyIGBvPvfSsIHuXvNsminyDaTdA);

	// Token: 0x060002AC RID: 684
	[SuppressUnmanagedCodeSecurity]
	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "MapVirtualKeyW")]
	public static extern uint oWwicRHsxJDDoNbIyZnVWXaUtNCf(uint, uint);

	// Token: 0x060002AD RID: 685
	[SuppressUnmanagedCodeSecurity]
	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "MapVirtualKeyExW")]
	public static extern uint mIKCtZmehfPdvtrtbKWHhThltpJq(uint, uint, IntPtr);

	// Token: 0x060002AE RID: 686
	[SuppressUnmanagedCodeSecurity]
	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetKeyboardLayout")]
	public static extern IntPtr DpVcDQOosfxTWcktJBPREdWHCrvU(int);

	// Token: 0x060002AF RID: 687
	[SuppressUnmanagedCodeSecurity]
	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, EntryPoint = "GetKeyboardLayoutNameW")]
	public static extern bool DxNcHLhJpaNyUCmiqmCcDCSHvVhp(IntPtr);

	// Token: 0x060002B0 RID: 688
	[SuppressUnmanagedCodeSecurity]
	[DllImport("msvcrt.dll", EntryPoint = "memcpy")]
	public unsafe static extern bool nluLBssElCaaWhCLckgKfjcLBHNQ(void*, void*, UIntPtr);

	// Token: 0x060002B1 RID: 689 RVA: 0x000128CB File Offset: 0x00010ACB
	public unsafe static bool MBbJkMtvinKWzCRAsbwuniKibMpB(void* A_0, void* A_1, int A_2)
	{
		return wLURyKQfpGlmweDJGGSrwwzrDUJFA.nluLBssElCaaWhCLckgKfjcLBHNQ(A_0, A_1, new UIntPtr((uint)A_2));
	}

	// Token: 0x060002B2 RID: 690 RVA: 0x000128DA File Offset: 0x00010ADA
	public static IntPtr NcNUORJAUceCejbICLHRcPTLEkhIb()
	{
		if (!UnityTools.isEditor && wLURyKQfpGlmweDJGGSrwwzrDUJFA.VCHPgRSeWKLOFysahqglqGNKmvmU != IntPtr.Zero)
		{
			return wLURyKQfpGlmweDJGGSrwwzrDUJFA.VCHPgRSeWKLOFysahqglqGNKmvmU;
		}
		return wLURyKQfpGlmweDJGGSrwwzrDUJFA.VCHPgRSeWKLOFysahqglqGNKmvmU = wLURyKQfpGlmweDJGGSrwwzrDUJFA.eNsQBQQzXfLRKPsnnOLUBGMWvNcG();
	}

	// Token: 0x060002B3 RID: 691 RVA: 0x00029820 File Offset: 0x00027A20
	public static bool bLkIwXzSrzHGTImgFdjHbxUPJnkHA()
	{
		try
		{
			if (wLURyKQfpGlmweDJGGSrwwzrDUJFA.GghDeMGIusKByfDeEslChqJNHShHc == 0)
			{
				bool flag;
				if (IntPtr.Size == 8)
				{
					wLURyKQfpGlmweDJGGSrwwzrDUJFA.GghDeMGIusKByfDeEslChqJNHShHc = 2;
				}
				else if (wLURyKQfpGlmweDJGGSrwwzrDUJFA.UVkhXtxlixlKvXdCCMSJuQWjNcys(wLURyKQfpGlmweDJGGSrwwzrDUJFA.uoHJZZakUBOmSfJyqHZZmXWOSBut(), out flag))
				{
					if (flag)
					{
						wLURyKQfpGlmweDJGGSrwwzrDUJFA.GghDeMGIusKByfDeEslChqJNHShHc = 2;
					}
					else
					{
						wLURyKQfpGlmweDJGGSrwwzrDUJFA.GghDeMGIusKByfDeEslChqJNHShHc = 1;
					}
				}
			}
		}
		catch
		{
			wLURyKQfpGlmweDJGGSrwwzrDUJFA.GghDeMGIusKByfDeEslChqJNHShHc = 1;
		}
		return wLURyKQfpGlmweDJGGSrwwzrDUJFA.GghDeMGIusKByfDeEslChqJNHShHc == 2;
	}

	// Token: 0x0400046B RID: 1131
	private static IntPtr VCHPgRSeWKLOFysahqglqGNKmvmU = IntPtr.Zero;

	// Token: 0x0400046C RID: 1132
	private static int GghDeMGIusKByfDeEslChqJNHShHc;

	// Token: 0x02000044 RID: 68
	// (Invoke) Token: 0x060002B6 RID: 694
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate bool vRtMRobknvOZVsGkQnwytfaQGqCA(IntPtr hwnd, IntPtr lParam);
}
