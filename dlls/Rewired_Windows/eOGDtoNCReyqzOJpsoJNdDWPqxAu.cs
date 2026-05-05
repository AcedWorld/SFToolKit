using System;
using System.Runtime.InteropServices;
using System.Security;

// Token: 0x02000129 RID: 297
internal static class eOGDtoNCReyqzOJpsoJNdDWPqxAu
{
	// Token: 0x06000AA3 RID: 2723 RVA: 0x0003C508 File Offset: 0x0003A708
	public unsafe static int iHCsRDqQbIoKlVYnzwMhFGlcYiLw(int A_0, int A_1, out bekUNyisTxEtrabunpHlsAxmxUtd A_2)
	{
		if (OJvftpuwMnDnTESHlcnafrsMzwYhA.cmAgyLchycuFDpnGufCCvYLwCLbm >= KLhrBPBxbDKejmHpuavTKkWlmsVC.XINPUT_1_4)
		{
			A_2 = default(bekUNyisTxEtrabunpHlsAxmxUtd);
			return 0;
		}
		A_2 = default(bekUNyisTxEtrabunpHlsAxmxUtd);
		int result;
		fixed (bekUNyisTxEtrabunpHlsAxmxUtd* ptr = &A_2)
		{
			void* ptr2 = (void*)ptr;
			result = eOGDtoNCReyqzOJpsoJNdDWPqxAu.JJPSixDnLXdmmJYRruoCvzsjKeeHA(A_0, A_1, ptr2);
		}
		return result;
	}

	// Token: 0x06000AA4 RID: 2724 RVA: 0x0003C540 File Offset: 0x0003A740
	private unsafe static int JJPSixDnLXdmmJYRruoCvzsjKeeHA(int A_0, int A_1, void* A_2)
	{
		switch (OJvftpuwMnDnTESHlcnafrsMzwYhA.cmAgyLchycuFDpnGufCCvYLwCLbm)
		{
		case KLhrBPBxbDKejmHpuavTKkWlmsVC.XINPUT_9_1_0:
			return eOGDtoNCReyqzOJpsoJNdDWPqxAu.OQEMWJfLFCuRoNIMCiBMrSHCnmis(A_0, A_1, A_2);
		case KLhrBPBxbDKejmHpuavTKkWlmsVC.XINPUT_1_1:
			return eOGDtoNCReyqzOJpsoJNdDWPqxAu.zwiEwAErSlWwfuTCFMpWRchjaClJA(A_0, A_1, A_2);
		case KLhrBPBxbDKejmHpuavTKkWlmsVC.XINPUT_1_2:
			return eOGDtoNCReyqzOJpsoJNdDWPqxAu.YEKatUyAZWYpuZxzldmtCrKpRQHh(A_0, A_1, A_2);
		case KLhrBPBxbDKejmHpuavTKkWlmsVC.XINPUT_1_3:
			return eOGDtoNCReyqzOJpsoJNdDWPqxAu.gbUvpSBsCscsVhTWZMZZTKbPHDhU(A_0, A_1, A_2);
		default:
			return 0;
		}
	}

	// Token: 0x06000AA5 RID: 2725
	[SuppressUnmanagedCodeSecurity]
	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	private unsafe static extern int OQEMWJfLFCuRoNIMCiBMrSHCnmis(int, int, void*);

	// Token: 0x06000AA6 RID: 2726
	[SuppressUnmanagedCodeSecurity]
	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	private unsafe static extern int zwiEwAErSlWwfuTCFMpWRchjaClJA(int, int, void*);

	// Token: 0x06000AA7 RID: 2727
	[SuppressUnmanagedCodeSecurity]
	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	private unsafe static extern int YEKatUyAZWYpuZxzldmtCrKpRQHh(int, int, void*);

	// Token: 0x06000AA8 RID: 2728
	[SuppressUnmanagedCodeSecurity]
	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetKeystroke")]
	private unsafe static extern int gbUvpSBsCscsVhTWZMZZTKbPHDhU(int, int, void*);

	// Token: 0x06000AA9 RID: 2729 RVA: 0x00017A61 File Offset: 0x00015C61
	public unsafe static int qXxFdDbDMfVQZtJduzohrvOaMdCcA(int A_0, ANKpkQVdjjJBZtpJglzmnbRRvFWL A_1)
	{
		return eOGDtoNCReyqzOJpsoJNdDWPqxAu.DvZSCvNvfPZkRDJSSwTYWTkuVhCh(A_0, (void*)(&A_1));
	}

	// Token: 0x06000AAA RID: 2730 RVA: 0x0003C594 File Offset: 0x0003A794
	private unsafe static int DvZSCvNvfPZkRDJSSwTYWTkuVhCh(int A_0, void* A_1)
	{
		switch (OJvftpuwMnDnTESHlcnafrsMzwYhA.cmAgyLchycuFDpnGufCCvYLwCLbm)
		{
		case KLhrBPBxbDKejmHpuavTKkWlmsVC.XINPUT_9_1_0:
			return eOGDtoNCReyqzOJpsoJNdDWPqxAu.KeCECBKIqDIFHjepmuEzGvLLxnzwA(A_0, A_1);
		case KLhrBPBxbDKejmHpuavTKkWlmsVC.XINPUT_1_1:
			return eOGDtoNCReyqzOJpsoJNdDWPqxAu.WaHlREQlHYSHhAhDrdBHEucdpWDEb(A_0, A_1);
		case KLhrBPBxbDKejmHpuavTKkWlmsVC.XINPUT_1_2:
			return eOGDtoNCReyqzOJpsoJNdDWPqxAu.vDoDqQLBlBJtjWunMqrxqlzSpqKx(A_0, A_1);
		case KLhrBPBxbDKejmHpuavTKkWlmsVC.XINPUT_1_3:
			return eOGDtoNCReyqzOJpsoJNdDWPqxAu.eNhAmhWpfzeZTdMSvNdXbvOrvuniA(A_0, A_1);
		case KLhrBPBxbDKejmHpuavTKkWlmsVC.XINPUT_1_4:
			return eOGDtoNCReyqzOJpsoJNdDWPqxAu.AditEoscuiSEVgLCCwcUGvLvPQSp(A_0, A_1);
		default:
			return 0;
		}
	}

	// Token: 0x06000AAB RID: 2731
	[SuppressUnmanagedCodeSecurity]
	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	private unsafe static extern int KeCECBKIqDIFHjepmuEzGvLLxnzwA(int, void*);

	// Token: 0x06000AAC RID: 2732
	[SuppressUnmanagedCodeSecurity]
	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	private unsafe static extern int WaHlREQlHYSHhAhDrdBHEucdpWDEb(int, void*);

	// Token: 0x06000AAD RID: 2733
	[SuppressUnmanagedCodeSecurity]
	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	private unsafe static extern int vDoDqQLBlBJtjWunMqrxqlzSpqKx(int, void*);

	// Token: 0x06000AAE RID: 2734
	[SuppressUnmanagedCodeSecurity]
	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	private unsafe static extern int eNhAmhWpfzeZTdMSvNdXbvOrvuniA(int, void*);

	// Token: 0x06000AAF RID: 2735
	[SuppressUnmanagedCodeSecurity]
	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputSetState")]
	private unsafe static extern int AditEoscuiSEVgLCCwcUGvLvPQSp(int, void*);

	// Token: 0x06000AB0 RID: 2736 RVA: 0x0003C5F0 File Offset: 0x0003A7F0
	public unsafe static int YXoibEthAZafmYYEiOrnkeXFxQTX(int A_0, out Guid A_1, out Guid A_2)
	{
		A_1 = default(Guid);
		A_2 = default(Guid);
		int result;
		fixed (Guid* ptr = &A_1)
		{
			void* ptr2 = (void*)ptr;
			fixed (Guid* ptr3 = &A_2)
			{
				void* ptr4 = (void*)ptr3;
				result = eOGDtoNCReyqzOJpsoJNdDWPqxAu.ogtTjhrhaELTKokDqvvRqeAcNqCf(A_0, ptr2, ptr4);
			}
		}
		return result;
	}

	// Token: 0x06000AB1 RID: 2737 RVA: 0x0003C624 File Offset: 0x0003A824
	private unsafe static int ogtTjhrhaELTKokDqvvRqeAcNqCf(int A_0, void* A_1, void* A_2)
	{
		switch (OJvftpuwMnDnTESHlcnafrsMzwYhA.cmAgyLchycuFDpnGufCCvYLwCLbm)
		{
		case KLhrBPBxbDKejmHpuavTKkWlmsVC.XINPUT_9_1_0:
			return eOGDtoNCReyqzOJpsoJNdDWPqxAu.EQjerBDQawYMklUhOJcIeuksFCxEb(A_0, A_1, A_2);
		case KLhrBPBxbDKejmHpuavTKkWlmsVC.XINPUT_1_1:
			return eOGDtoNCReyqzOJpsoJNdDWPqxAu.DKtmnFUDdooaApxDmvIqKEmJuwzs(A_0, A_1, A_2);
		case KLhrBPBxbDKejmHpuavTKkWlmsVC.XINPUT_1_2:
			return eOGDtoNCReyqzOJpsoJNdDWPqxAu.xXognIllqSaVWzqkImOOwgXdpnuR(A_0, A_1, A_2);
		case KLhrBPBxbDKejmHpuavTKkWlmsVC.XINPUT_1_3:
			return eOGDtoNCReyqzOJpsoJNdDWPqxAu.XoQiJchDHujyOdIYAPLooNXLeVvOA(A_0, A_1, A_2);
		default:
			return 0;
		}
	}

	// Token: 0x06000AB2 RID: 2738
	[SuppressUnmanagedCodeSecurity]
	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	private unsafe static extern int EQjerBDQawYMklUhOJcIeuksFCxEb(int, void*, void*);

	// Token: 0x06000AB3 RID: 2739
	[SuppressUnmanagedCodeSecurity]
	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	private unsafe static extern int DKtmnFUDdooaApxDmvIqKEmJuwzs(int, void*, void*);

	// Token: 0x06000AB4 RID: 2740
	[SuppressUnmanagedCodeSecurity]
	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	private unsafe static extern int xXognIllqSaVWzqkImOOwgXdpnuR(int, void*, void*);

	// Token: 0x06000AB5 RID: 2741
	[SuppressUnmanagedCodeSecurity]
	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetDSoundAudioDeviceGuids")]
	private unsafe static extern int XoQiJchDHujyOdIYAPLooNXLeVvOA(int, void*, void*);

	// Token: 0x06000AB6 RID: 2742 RVA: 0x0003C678 File Offset: 0x0003A878
	[SuppressUnmanagedCodeSecurity]
	public unsafe static int SukpdCtjUqGRiokrVFwGhzzTBrQnA(int A_0, out JmmDQfIwKOhQQnlqwKAZYIINwKqc A_1)
	{
		A_1 = default(JmmDQfIwKOhQQnlqwKAZYIINwKqc);
		int result;
		fixed (JmmDQfIwKOhQQnlqwKAZYIINwKqc* ptr = &A_1)
		{
			void* ptr2 = (void*)ptr;
			result = eOGDtoNCReyqzOJpsoJNdDWPqxAu.rJFFFeBnlBJVXyLWhQOFRTpWlUowA(A_0, ptr2);
		}
		return result;
	}

	// Token: 0x06000AB7 RID: 2743 RVA: 0x0003C69C File Offset: 0x0003A89C
	private unsafe static int rJFFFeBnlBJVXyLWhQOFRTpWlUowA(int A_0, void* A_1)
	{
		if (OJvftpuwMnDnTESHlcnafrsMzwYhA.UTgEXEROhlXVHyJQYREqLzDpPRZx && OJvftpuwMnDnTESHlcnafrsMzwYhA.ACKdYfflxgnrmahGgWwUsZkMRajmB != null)
		{
			return OJvftpuwMnDnTESHlcnafrsMzwYhA.ACKdYfflxgnrmahGgWwUsZkMRajmB(A_0, A_1);
		}
		switch (OJvftpuwMnDnTESHlcnafrsMzwYhA.cmAgyLchycuFDpnGufCCvYLwCLbm)
		{
		case KLhrBPBxbDKejmHpuavTKkWlmsVC.XINPUT_9_1_0:
			return eOGDtoNCReyqzOJpsoJNdDWPqxAu.lStfhUUtJoikJchRwLjjEaqpLyAe(A_0, A_1);
		case KLhrBPBxbDKejmHpuavTKkWlmsVC.XINPUT_1_1:
			return eOGDtoNCReyqzOJpsoJNdDWPqxAu.ParhsxqbvaSNrqiaNIVxAgoldimY(A_0, A_1);
		case KLhrBPBxbDKejmHpuavTKkWlmsVC.XINPUT_1_2:
			return eOGDtoNCReyqzOJpsoJNdDWPqxAu.BBfHXZCarOaspCGmHOJJUKxbEZSXb(A_0, A_1);
		case KLhrBPBxbDKejmHpuavTKkWlmsVC.XINPUT_1_3:
			return eOGDtoNCReyqzOJpsoJNdDWPqxAu.dXFagMCVhFzmTwXzOTxtsQqRXdUIA(A_0, A_1);
		case KLhrBPBxbDKejmHpuavTKkWlmsVC.XINPUT_1_4:
			return eOGDtoNCReyqzOJpsoJNdDWPqxAu.BIhCmuKgorPnVOdMhIvziiyZUfzJ(A_0, A_1);
		default:
			return 0;
		}
	}

	// Token: 0x06000AB8 RID: 2744
	[SuppressUnmanagedCodeSecurity]
	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	private unsafe static extern int lStfhUUtJoikJchRwLjjEaqpLyAe(int, void*);

	// Token: 0x06000AB9 RID: 2745
	[SuppressUnmanagedCodeSecurity]
	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	private unsafe static extern int ParhsxqbvaSNrqiaNIVxAgoldimY(int, void*);

	// Token: 0x06000ABA RID: 2746
	[SuppressUnmanagedCodeSecurity]
	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	private unsafe static extern int BBfHXZCarOaspCGmHOJJUKxbEZSXb(int, void*);

	// Token: 0x06000ABB RID: 2747
	[SuppressUnmanagedCodeSecurity]
	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	private unsafe static extern int dXFagMCVhFzmTwXzOTxtsQqRXdUIA(int, void*);

	// Token: 0x06000ABC RID: 2748
	[SuppressUnmanagedCodeSecurity]
	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetState")]
	private unsafe static extern int BIhCmuKgorPnVOdMhIvziiyZUfzJ(int, void*);

	// Token: 0x06000ABD RID: 2749 RVA: 0x0003C714 File Offset: 0x0003A914
	public unsafe static int UpoDPzcosJeAEvhOkVFbsEsPEcXib(int A_0, xWqjpLrDBXUZxgRusGkFwZRUWwEG A_1, out CELrFAGlKnsjCYGBIIoGyEZcuGQi A_2)
	{
		A_2 = default(CELrFAGlKnsjCYGBIIoGyEZcuGQi);
		int result;
		fixed (CELrFAGlKnsjCYGBIIoGyEZcuGQi* ptr = &A_2)
		{
			void* ptr2 = (void*)ptr;
			result = eOGDtoNCReyqzOJpsoJNdDWPqxAu.szyGGKuDfJKKKEPhPewmovMWcFxn(A_0, (int)A_1, ptr2);
		}
		return result;
	}

	// Token: 0x06000ABE RID: 2750 RVA: 0x0003C738 File Offset: 0x0003A938
	private unsafe static int szyGGKuDfJKKKEPhPewmovMWcFxn(int A_0, int A_1, void* A_2)
	{
		switch (OJvftpuwMnDnTESHlcnafrsMzwYhA.cmAgyLchycuFDpnGufCCvYLwCLbm)
		{
		case KLhrBPBxbDKejmHpuavTKkWlmsVC.XINPUT_9_1_0:
			return eOGDtoNCReyqzOJpsoJNdDWPqxAu.HMrThnBJSFqMPWwkrXfhRDktIRTX(A_0, A_1, A_2);
		case KLhrBPBxbDKejmHpuavTKkWlmsVC.XINPUT_1_1:
			return eOGDtoNCReyqzOJpsoJNdDWPqxAu.qFIuIRlzVzJPSUOHRaSVyyNNelHJ(A_0, A_1, A_2);
		case KLhrBPBxbDKejmHpuavTKkWlmsVC.XINPUT_1_2:
			return eOGDtoNCReyqzOJpsoJNdDWPqxAu.yJLDJBHEaxYPjvHaCCbyfLrFkfIib(A_0, A_1, A_2);
		case KLhrBPBxbDKejmHpuavTKkWlmsVC.XINPUT_1_3:
			return eOGDtoNCReyqzOJpsoJNdDWPqxAu.nHHTQjIeZuOBwnwDmVRsDoGLCkSI(A_0, A_1, A_2);
		case KLhrBPBxbDKejmHpuavTKkWlmsVC.XINPUT_1_4:
			return eOGDtoNCReyqzOJpsoJNdDWPqxAu.JZJWYBwGnviwbnqCKgFmEmhbbiuj(A_0, A_1, A_2);
		default:
			return 0;
		}
	}

	// Token: 0x06000ABF RID: 2751
	[SuppressUnmanagedCodeSecurity]
	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	private unsafe static extern int HMrThnBJSFqMPWwkrXfhRDktIRTX(int, int, void*);

	// Token: 0x06000AC0 RID: 2752
	[SuppressUnmanagedCodeSecurity]
	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	private unsafe static extern int qFIuIRlzVzJPSUOHRaSVyyNNelHJ(int, int, void*);

	// Token: 0x06000AC1 RID: 2753
	[SuppressUnmanagedCodeSecurity]
	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	private unsafe static extern int yJLDJBHEaxYPjvHaCCbyfLrFkfIib(int, int, void*);

	// Token: 0x06000AC2 RID: 2754
	[SuppressUnmanagedCodeSecurity]
	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	private unsafe static extern int nHHTQjIeZuOBwnwDmVRsDoGLCkSI(int, int, void*);

	// Token: 0x06000AC3 RID: 2755
	[SuppressUnmanagedCodeSecurity]
	[DllImport("xinput1_4.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetCapabilities")]
	private unsafe static extern int JZJWYBwGnviwbnqCKgFmEmhbbiuj(int, int, void*);

	// Token: 0x06000AC4 RID: 2756 RVA: 0x0003C798 File Offset: 0x0003A998
	public unsafe static int HGmMFPvLBNDvCGsPUKQcEyRBApgI(int A_0, SuUyYZraeDspZQqcySKWjkcYuhlK A_1, out FJCtWdXxGFTlSZIHCEkrAvBMayjXA A_2)
	{
		A_2 = default(FJCtWdXxGFTlSZIHCEkrAvBMayjXA);
		int result;
		fixed (FJCtWdXxGFTlSZIHCEkrAvBMayjXA* ptr = &A_2)
		{
			void* ptr2 = (void*)ptr;
			result = eOGDtoNCReyqzOJpsoJNdDWPqxAu.VaRlGWgUjOWpXsDsOdTzQfSyesdF(A_0, (int)A_1, ptr2);
		}
		return result;
	}

	// Token: 0x06000AC5 RID: 2757 RVA: 0x0003C7BC File Offset: 0x0003A9BC
	private unsafe static int VaRlGWgUjOWpXsDsOdTzQfSyesdF(int A_0, int A_1, void* A_2)
	{
		switch (OJvftpuwMnDnTESHlcnafrsMzwYhA.cmAgyLchycuFDpnGufCCvYLwCLbm)
		{
		case KLhrBPBxbDKejmHpuavTKkWlmsVC.XINPUT_9_1_0:
			return eOGDtoNCReyqzOJpsoJNdDWPqxAu.ULVjCLMCkpDSTAlpMIlwTxWvGiecA(A_0, A_1, A_2);
		case KLhrBPBxbDKejmHpuavTKkWlmsVC.XINPUT_1_1:
			return eOGDtoNCReyqzOJpsoJNdDWPqxAu.pXIqXmxuEbJiiPsjzHeVDLtGCofg(A_0, A_1, A_2);
		case KLhrBPBxbDKejmHpuavTKkWlmsVC.XINPUT_1_2:
			return eOGDtoNCReyqzOJpsoJNdDWPqxAu.kVRDSoKdpqgcqqUKZOjAYamIrTggA(A_0, A_1, A_2);
		case KLhrBPBxbDKejmHpuavTKkWlmsVC.XINPUT_1_3:
			return eOGDtoNCReyqzOJpsoJNdDWPqxAu.YRkKMYyoqXDZycapoPHFyMknYbdo(A_0, A_1, A_2);
		default:
			return 0;
		}
	}

	// Token: 0x06000AC6 RID: 2758
	[SuppressUnmanagedCodeSecurity]
	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	private unsafe static extern int ULVjCLMCkpDSTAlpMIlwTxWvGiecA(int, int, void*);

	// Token: 0x06000AC7 RID: 2759
	[SuppressUnmanagedCodeSecurity]
	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	private unsafe static extern int pXIqXmxuEbJiiPsjzHeVDLtGCofg(int, int, void*);

	// Token: 0x06000AC8 RID: 2760
	[SuppressUnmanagedCodeSecurity]
	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	private unsafe static extern int kVRDSoKdpqgcqqUKZOjAYamIrTggA(int, int, void*);

	// Token: 0x06000AC9 RID: 2761
	[SuppressUnmanagedCodeSecurity]
	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputGetBatteryInformation")]
	private unsafe static extern int YRkKMYyoqXDZycapoPHFyMknYbdo(int, int, void*);

	// Token: 0x06000ACA RID: 2762 RVA: 0x00017A6C File Offset: 0x00015C6C
	public static void MwCFadiGLQhmHfoULaOkuuoLkeiAb(ycPNoWIqyMTmKlpivOlkjvCiRrXq A_0)
	{
		eOGDtoNCReyqzOJpsoJNdDWPqxAu.hlqtDvpNhvdpzwrWxVuuIsMjgBNp(A_0);
	}

	// Token: 0x06000ACB RID: 2763 RVA: 0x0003C810 File Offset: 0x0003AA10
	private static void hlqtDvpNhvdpzwrWxVuuIsMjgBNp(ycPNoWIqyMTmKlpivOlkjvCiRrXq A_0)
	{
		switch (OJvftpuwMnDnTESHlcnafrsMzwYhA.cmAgyLchycuFDpnGufCCvYLwCLbm)
		{
		case KLhrBPBxbDKejmHpuavTKkWlmsVC.XINPUT_9_1_0:
			eOGDtoNCReyqzOJpsoJNdDWPqxAu.FCLUuXlVhRrbkERwoAkhYhiLMfYF(A_0);
			return;
		case KLhrBPBxbDKejmHpuavTKkWlmsVC.XINPUT_1_1:
			eOGDtoNCReyqzOJpsoJNdDWPqxAu.LlDijmPKMutbvLtiJDCzJPJCZyyE(A_0);
			return;
		case KLhrBPBxbDKejmHpuavTKkWlmsVC.XINPUT_1_2:
			eOGDtoNCReyqzOJpsoJNdDWPqxAu.KkiDUOMZIgAGZRQHbsOJbOmJnipq(A_0);
			return;
		case KLhrBPBxbDKejmHpuavTKkWlmsVC.XINPUT_1_3:
			eOGDtoNCReyqzOJpsoJNdDWPqxAu.MbUUmZhJGGMHWVczhDxOLRvsUxPG(A_0);
			return;
		default:
			return;
		}
	}

	// Token: 0x06000ACC RID: 2764
	[SuppressUnmanagedCodeSecurity]
	[DllImport("xinput9_1_0.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	private static extern void FCLUuXlVhRrbkERwoAkhYhiLMfYF(ycPNoWIqyMTmKlpivOlkjvCiRrXq);

	// Token: 0x06000ACD RID: 2765
	[SuppressUnmanagedCodeSecurity]
	[DllImport("xinput1_1.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	private static extern void LlDijmPKMutbvLtiJDCzJPJCZyyE(ycPNoWIqyMTmKlpivOlkjvCiRrXq);

	// Token: 0x06000ACE RID: 2766
	[SuppressUnmanagedCodeSecurity]
	[DllImport("xinput1_2.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	private static extern void KkiDUOMZIgAGZRQHbsOJbOmJnipq(ycPNoWIqyMTmKlpivOlkjvCiRrXq);

	// Token: 0x06000ACF RID: 2767
	[SuppressUnmanagedCodeSecurity]
	[DllImport("xinput1_3.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "XInputEnable")]
	private static extern void MbUUmZhJGGMHWVczhDxOLRvsUxPG(ycPNoWIqyMTmKlpivOlkjvCiRrXq);
}
