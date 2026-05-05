using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;

// Token: 0x02000113 RID: 275
internal class uitplPRhckGBhhlYaUyojtnOjBkuA
{
	// Token: 0x06000A52 RID: 2642
	[SuppressUnmanagedCodeSecurity]
	[DllImport("user32.dll", EntryPoint = "PeekMessage")]
	public static extern int hnyToYkLRmYuzcOikJqTtBTKQIBy(out jbQGppeggypGyVyjgKIwntcAjLnP, IntPtr, int, int, int);

	// Token: 0x06000A53 RID: 2643
	[SuppressUnmanagedCodeSecurity]
	[DllImport("user32.dll", EntryPoint = "GetMessage")]
	public static extern int DQISaqHQBUWejVdZqJCXkEgkXTlr(out jbQGppeggypGyVyjgKIwntcAjLnP, IntPtr, int, int);

	// Token: 0x06000A54 RID: 2644
	[SuppressUnmanagedCodeSecurity]
	[DllImport("user32.dll", EntryPoint = "TranslateMessage")]
	public static extern int KGtXMhhoGSeRQbNFiASugChFAtZSA(ref jbQGppeggypGyVyjgKIwntcAjLnP);

	// Token: 0x06000A55 RID: 2645
	[SuppressUnmanagedCodeSecurity]
	[DllImport("user32.dll", EntryPoint = "DispatchMessage")]
	public static extern int FDbdkLskeQnZSVEgqAUKztMnuEKN(ref jbQGppeggypGyVyjgKIwntcAjLnP);

	// Token: 0x06000A56 RID: 2646 RVA: 0x00017949 File Offset: 0x00015B49
	public static IntPtr zgElyhGKCeQnICwBYTolZpDbWWRD(HandleRef A_0, uitplPRhckGBhhlYaUyojtnOjBkuA.NXVKXkoIHibiQOXcUsqJyYOvedEp A_1)
	{
		if (IntPtr.Size == 4)
		{
			return uitplPRhckGBhhlYaUyojtnOjBkuA.goxbbSQHqIqZIgZwAYvWSWjcoplK(A_0, A_1);
		}
		return uitplPRhckGBhhlYaUyojtnOjBkuA.TXwtLzzfMPfmtJVgCypzIjYGHnAlA(A_0, A_1);
	}

	// Token: 0x06000A57 RID: 2647
	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetFocus")]
	public static extern IntPtr YFTBooQXyWRScleqdnIgwZYUnKje();

	// Token: 0x06000A58 RID: 2648
	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLong")]
	private static extern IntPtr goxbbSQHqIqZIgZwAYvWSWjcoplK(HandleRef, uitplPRhckGBhhlYaUyojtnOjBkuA.NXVKXkoIHibiQOXcUsqJyYOvedEp);

	// Token: 0x06000A59 RID: 2649
	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongPtr")]
	private static extern IntPtr TXwtLzzfMPfmtJVgCypzIjYGHnAlA(HandleRef, uitplPRhckGBhhlYaUyojtnOjBkuA.NXVKXkoIHibiQOXcUsqJyYOvedEp);

	// Token: 0x06000A5A RID: 2650 RVA: 0x00017962 File Offset: 0x00015B62
	public static IntPtr thxyJZBNhvdVJUIpreJSmtikzOoJ(HandleRef A_0, uitplPRhckGBhhlYaUyojtnOjBkuA.NXVKXkoIHibiQOXcUsqJyYOvedEp A_1, IntPtr A_2)
	{
		if (IntPtr.Size == 4)
		{
			return uitplPRhckGBhhlYaUyojtnOjBkuA.dHhMOYsJfLjIOKfWjtWHmOuTaOZxA(A_0, A_1, A_2);
		}
		return uitplPRhckGBhhlYaUyojtnOjBkuA.lImlnsWLaXToNjchzhmgaNEzPNdcb(A_0, A_1, A_2);
	}

	// Token: 0x06000A5B RID: 2651
	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetParent")]
	public static extern IntPtr UXdTVDcTtbnxHVcdWWDPwmmtHBvJA(HandleRef, IntPtr);

	// Token: 0x06000A5C RID: 2652
	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLong")]
	private static extern IntPtr dHhMOYsJfLjIOKfWjtWHmOuTaOZxA(HandleRef, uitplPRhckGBhhlYaUyojtnOjBkuA.NXVKXkoIHibiQOXcUsqJyYOvedEp, IntPtr);

	// Token: 0x06000A5D RID: 2653 RVA: 0x0001797D File Offset: 0x00015B7D
	public static bool jKklkpENjRSGdddMHglTGPZLPNEuA(HandleRef A_0, bool A_1)
	{
		return uitplPRhckGBhhlYaUyojtnOjBkuA.baVrFBcISxNuJRDbzmQSiAWvaNHE(A_0, A_1 ? 1 : 0);
	}

	// Token: 0x06000A5E RID: 2654
	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ShowWindow")]
	private static extern bool baVrFBcISxNuJRDbzmQSiAWvaNHE(HandleRef, int);

	// Token: 0x06000A5F RID: 2655
	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowLongPtr")]
	private static extern IntPtr lImlnsWLaXToNjchzhmgaNEzPNdcb(HandleRef, uitplPRhckGBhhlYaUyojtnOjBkuA.NXVKXkoIHibiQOXcUsqJyYOvedEp, IntPtr);

	// Token: 0x06000A60 RID: 2656
	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CallWindowProc")]
	public static extern IntPtr SSAgzjoBKNgYVbSKGomlSViFcdDF(IntPtr, IntPtr, int, IntPtr, IntPtr);

	// Token: 0x06000A61 RID: 2657
	[DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetModuleHandle")]
	public static extern IntPtr fEaALvfQZKyBMqMquwySDOOfwdWKA(string);

	// Token: 0x06000A62 RID: 2658 RVA: 0x0001798C File Offset: 0x00015B8C
	public static IntPtr RsTezJgDtoHIufFYrtKlAFzjaLsOB(IntPtr A_0, uitplPRhckGBhhlYaUyojtnOjBkuA.NXVKXkoIHibiQOXcUsqJyYOvedEp A_1)
	{
		if (IntPtr.Size == 4)
		{
			return uitplPRhckGBhhlYaUyojtnOjBkuA.YKMAgxyzkjCPxENbMmuBSMfEXRfp(A_0, A_1);
		}
		return uitplPRhckGBhhlYaUyojtnOjBkuA.JXkObtOZegcIxkzIoHgfcYXXSlID(A_0, A_1);
	}

	// Token: 0x06000A63 RID: 2659
	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLong")]
	private static extern IntPtr YKMAgxyzkjCPxENbMmuBSMfEXRfp(IntPtr, uitplPRhckGBhhlYaUyojtnOjBkuA.NXVKXkoIHibiQOXcUsqJyYOvedEp);

	// Token: 0x06000A64 RID: 2660
	[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongPtr")]
	private static extern IntPtr JXkObtOZegcIxkzIoHgfcYXXSlID(IntPtr, uitplPRhckGBhhlYaUyojtnOjBkuA.NXVKXkoIHibiQOXcUsqJyYOvedEp);

	// Token: 0x06000A65 RID: 2661
	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "IsWindow")]
	public static extern bool HgdSlFeRWjFRTFfRJPLCEeRFlebvb(IntPtr);

	// Token: 0x06000A66 RID: 2662
	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetActiveWindow")]
	private static extern IntPtr WYPCxHABPxHjVccYOuaGEXfQTvAV();

	// Token: 0x06000A67 RID: 2663
	[DllImport("Kernel32", EntryPoint = "GetCurrentProcessId")]
	private static extern uint hiPPHfmbFsGNkKGcVpMidMsEAXuFb();

	// Token: 0x06000A68 RID: 2664
	[DllImport("User32.dll", EntryPoint = "EnumWindows")]
	private static extern bool ZIFlERhacosdpmjxtGCxTfTkEwEH(IntPtr, IntPtr);

	// Token: 0x06000A69 RID: 2665 RVA: 0x0003BFA4 File Offset: 0x0003A1A4
	private static bool JumAzbDnkzPDdtAaTuMgbxrSAoDAA(IntPtr A_0, IntPtr A_1)
	{
		List<IntPtr> nnjqUVlPtrXvMEgpFqWHqMTvfVNP = uitplPRhckGBhhlYaUyojtnOjBkuA.NNJqUVlPtrXvMEgpFqWHqMTvfVNP;
		lock (nnjqUVlPtrXvMEgpFqWHqMTvfVNP)
		{
			uitplPRhckGBhhlYaUyojtnOjBkuA.NNJqUVlPtrXvMEgpFqWHqMTvfVNP.Add(A_0);
		}
		return true;
	}

	// Token: 0x06000A6A RID: 2666
	[DllImport("User32.dll", EntryPoint = "GetWindowThreadProcessId")]
	private static extern uint BTQLzTYkTplpghdbIVMIMScPseyv(IntPtr, out uint);

	// Token: 0x06000A6B RID: 2667 RVA: 0x0003BFEC File Offset: 0x0003A1EC
	public static IntPtr xceYjOsDhvYCnqDTEfSfGojWvPBK()
	{
		if (uitplPRhckGBhhlYaUyojtnOjBkuA.qwzIukTPrtbfubRXUCdSLMRbWgcG != IntPtr.Zero)
		{
			return uitplPRhckGBhhlYaUyojtnOjBkuA.qwzIukTPrtbfubRXUCdSLMRbWgcG;
		}
		uitplPRhckGBhhlYaUyojtnOjBkuA.NNJqUVlPtrXvMEgpFqWHqMTvfVNP = new List<IntPtr>();
		uint num = uitplPRhckGBhhlYaUyojtnOjBkuA.hiPPHfmbFsGNkKGcVpMidMsEAXuFb();
		uitplPRhckGBhhlYaUyojtnOjBkuA.gLfEfQLRPnfhOWZmfGHaXLuIpefh gLfEfQLRPnfhOWZmfGHaXLuIpefh = new uitplPRhckGBhhlYaUyojtnOjBkuA.gLfEfQLRPnfhOWZmfGHaXLuIpefh(uitplPRhckGBhhlYaUyojtnOjBkuA.JumAzbDnkzPDdtAaTuMgbxrSAoDAA);
		IntPtr functionPointerForDelegate = Marshal.GetFunctionPointerForDelegate<uitplPRhckGBhhlYaUyojtnOjBkuA.gLfEfQLRPnfhOWZmfGHaXLuIpefh>(gLfEfQLRPnfhOWZmfGHaXLuIpefh);
		uitplPRhckGBhhlYaUyojtnOjBkuA.ZIFlERhacosdpmjxtGCxTfTkEwEH(functionPointerForDelegate, IntPtr.Zero);
		GC.KeepAlive(gLfEfQLRPnfhOWZmfGHaXLuIpefh);
		GC.KeepAlive(functionPointerForDelegate);
		for (int i = 0; i < uitplPRhckGBhhlYaUyojtnOjBkuA.NNJqUVlPtrXvMEgpFqWHqMTvfVNP.Count; i++)
		{
			if (uitplPRhckGBhhlYaUyojtnOjBkuA.HgdSlFeRWjFRTFfRJPLCEeRFlebvb(uitplPRhckGBhhlYaUyojtnOjBkuA.NNJqUVlPtrXvMEgpFqWHqMTvfVNP[i]))
			{
				uint num2;
				uitplPRhckGBhhlYaUyojtnOjBkuA.BTQLzTYkTplpghdbIVMIMScPseyv(uitplPRhckGBhhlYaUyojtnOjBkuA.NNJqUVlPtrXvMEgpFqWHqMTvfVNP[i], out num2);
				if (num2 == num)
				{
					uitplPRhckGBhhlYaUyojtnOjBkuA.qwzIukTPrtbfubRXUCdSLMRbWgcG = uitplPRhckGBhhlYaUyojtnOjBkuA.NNJqUVlPtrXvMEgpFqWHqMTvfVNP[i];
					uitplPRhckGBhhlYaUyojtnOjBkuA.NNJqUVlPtrXvMEgpFqWHqMTvfVNP.Clear();
					return uitplPRhckGBhhlYaUyojtnOjBkuA.qwzIukTPrtbfubRXUCdSLMRbWgcG;
				}
			}
		}
		return uitplPRhckGBhhlYaUyojtnOjBkuA.WYPCxHABPxHjVccYOuaGEXfQTvAV();
	}

	// Token: 0x040008A9 RID: 2217
	private static IntPtr qwzIukTPrtbfubRXUCdSLMRbWgcG = IntPtr.Zero;

	// Token: 0x040008AA RID: 2218
	private static List<IntPtr> NNJqUVlPtrXvMEgpFqWHqMTvfVNP;

	// Token: 0x02000114 RID: 276
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal class kOopAgginRDkhyNhRetxiFBOLdsuA
	{
		// Token: 0x040008AB RID: 2219
		public int NjbCQEHPRoPPUFfuvjiGvTAYUNuCA;

		// Token: 0x040008AC RID: 2220
		public int DChGJSIHeuhCzlvWzDFYnPGrqhtLA;

		// Token: 0x040008AD RID: 2221
		public int aadZmDLefOLbMmIeurdZyvjHuZrM;

		// Token: 0x040008AE RID: 2222
		public int DfjcEdainEeBYfqkyjrCxoZJHkxaA;

		// Token: 0x040008AF RID: 2223
		public int PnMPSsWYsIycNyaqSalEYhHSJlaO;

		// Token: 0x040008B0 RID: 2224
		public byte sRjJmjPNYKOKmsOcFEiUmXyhgRhO;

		// Token: 0x040008B1 RID: 2225
		public byte clLPMqfEIooAJdrqZSlTmmNuqqAx;

		// Token: 0x040008B2 RID: 2226
		public byte KXmszwECOkqNpgbwYqmFEZpaoflj;

		// Token: 0x040008B3 RID: 2227
		public byte esejqpdUSspiFEMIZcCBFTcwQSEbA;

		// Token: 0x040008B4 RID: 2228
		public byte CkaGjEhnqVgHTLcEIaTGdAlNxclzA;

		// Token: 0x040008B5 RID: 2229
		public byte diipTJSVBeXkLlcKrXYVgkYUQSQf;

		// Token: 0x040008B6 RID: 2230
		public byte xbRmTIRQgeKqgWqDOyFWqdVfDgwkA;

		// Token: 0x040008B7 RID: 2231
		public byte RPmkVvSGqwgilindrQClPEyxAXoEA;

		// Token: 0x040008B8 RID: 2232
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string IJvcKCeXejvjrjYzqyESZLuobIR;
	}

	// Token: 0x02000115 RID: 277
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal struct PWNnUyENsplSvhxcVKAPcvyZodDq
	{
		// Token: 0x040008B9 RID: 2233
		public int fLoJwdAEfiZpHkDDBFCKEqkGAYlH;

		// Token: 0x040008BA RID: 2234
		public int LwpgFjWWHEiGQQFNnYpEZvjYiHgc;

		// Token: 0x040008BB RID: 2235
		public int KBsJdLjaEZWnGWmEgtiLggdUFoyBA;

		// Token: 0x040008BC RID: 2236
		public int EXJHJImkXbyvrOvoXwGYUCprweqD;

		// Token: 0x040008BD RID: 2237
		public int zstGrOFpsvcMMSaukKSEajKTvRTU;

		// Token: 0x040008BE RID: 2238
		public int FEoFrDUyFXKZOHlwvBefOevJnOJu;

		// Token: 0x040008BF RID: 2239
		public int MZErNNrECyRynoUDInxXNkHYpDFl;

		// Token: 0x040008C0 RID: 2240
		public int ePoWaJDxasPVrWdlBdOvEpzxyNuX;

		// Token: 0x040008C1 RID: 2241
		public int JZPDcfABwvzsUHCzKtfNWDapPHdi;

		// Token: 0x040008C2 RID: 2242
		public int cbZseszniLgBRAVpzpTQdEDSrfeHb;

		// Token: 0x040008C3 RID: 2243
		public int EBLHkNZalMwTBKPfNBWivbUfvcZe;

		// Token: 0x040008C4 RID: 2244
		public char JNrqUOoonfuflboqDhblFPdrCBHYA;

		// Token: 0x040008C5 RID: 2245
		public char xneKqGqhzNKFxexWCPkSfJzTFcREA;

		// Token: 0x040008C6 RID: 2246
		public char BzcCkvEczyiyGYdxAUfQcYKbVwFeA;

		// Token: 0x040008C7 RID: 2247
		public char aQlWtyIJIbEmHTnhmhBjqvZXfgTG;

		// Token: 0x040008C8 RID: 2248
		public byte PbsiXwLfkYRXWkcquRxJlajoFkto;

		// Token: 0x040008C9 RID: 2249
		public byte TfNyeRSzpHmQvQwuMsDACRWmHhvO;

		// Token: 0x040008CA RID: 2250
		public byte ydxevvdOsqcbxdwscozKmhxFvmELd;

		// Token: 0x040008CB RID: 2251
		public byte OYnENjeexMNEIalPXDrLuxLBnYtIA;

		// Token: 0x040008CC RID: 2252
		public byte iVnHnQAAftNyPGBIaWjgxiFlzKZy;
	}

	// Token: 0x02000116 RID: 278
	internal enum NXVKXkoIHibiQOXcUsqJyYOvedEp
	{
		// Token: 0x040008CE RID: 2254
		WndProc = -4,
		// Token: 0x040008CF RID: 2255
		HInstance = -6,
		// Token: 0x040008D0 RID: 2256
		HwndParent = -8,
		// Token: 0x040008D1 RID: 2257
		Style = -16,
		// Token: 0x040008D2 RID: 2258
		ExtendedStyle = -20,
		// Token: 0x040008D3 RID: 2259
		UserData = -21,
		// Token: 0x040008D4 RID: 2260
		Id = -12
	}

	// Token: 0x02000117 RID: 279
	// (Invoke) Token: 0x06000A70 RID: 2672
	internal delegate IntPtr WZockpjuMPHzgbSxigsaJFRpiCTuA(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

	// Token: 0x02000118 RID: 280
	// (Invoke) Token: 0x06000A74 RID: 2676
	private delegate bool gLfEfQLRPnfhOWZmfGHaXLuIpefh(IntPtr hwnd, IntPtr lParam);
}
