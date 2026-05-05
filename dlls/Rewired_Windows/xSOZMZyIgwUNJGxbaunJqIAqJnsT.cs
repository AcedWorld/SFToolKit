using System;
using System.Runtime.InteropServices;
using System.Security;

// Token: 0x02000142 RID: 322
internal static class xSOZMZyIgwUNJGxbaunJqIAqJnsT
{
	// Token: 0x06000B1C RID: 2844 RVA: 0x0003D540 File Offset: 0x0003B740
	public unsafe static int psJwxiCIocrPdCpOCaoSqamOIZYB(IHjknSfzmxAOaKWaYMMNiIArARUq[] A_0, ref int A_1, int A_2)
	{
		int result;
		fixed (IHjknSfzmxAOaKWaYMMNiIArARUq[] array = A_0)
		{
			void* ptr;
			if (A_0 == null || array.Length == 0)
			{
				ptr = null;
			}
			else
			{
				ptr = (void*)(&array[0]);
			}
			fixed (int* ptr2 = &A_1)
			{
				void* ptr3 = (void*)ptr2;
				result = xSOZMZyIgwUNJGxbaunJqIAqJnsT.gDTjIusUnMEQqDrRnMOOpuGKBqTC(ptr, ptr3, A_2);
			}
		}
		return result;
	}

	// Token: 0x06000B1D RID: 2845
	[SuppressUnmanagedCodeSecurity]
	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceList")]
	private unsafe static extern int gDTjIusUnMEQqDrRnMOOpuGKBqTC(void*, void*, int);

	// Token: 0x06000B1E RID: 2846 RVA: 0x0003D578 File Offset: 0x0003B778
	public unsafe static int rAuUqrdKMsFYHGSrFJFyuiTZJBPY(ALCNEBxFbeXYHuttdAnDwwiEVchj[] A_0, ref int A_1, int A_2)
	{
		int result;
		fixed (ALCNEBxFbeXYHuttdAnDwwiEVchj[] array = A_0)
		{
			void* ptr;
			if (A_0 == null || array.Length == 0)
			{
				ptr = null;
			}
			else
			{
				ptr = (void*)(&array[0]);
			}
			fixed (int* ptr2 = &A_1)
			{
				void* ptr3 = (void*)ptr2;
				result = xSOZMZyIgwUNJGxbaunJqIAqJnsT.VVkBQOHaKdcWrMOGmkLsQAcZwcAI(ptr, ptr3, A_2);
			}
		}
		return result;
	}

	// Token: 0x06000B1F RID: 2847
	[SuppressUnmanagedCodeSecurity]
	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRegisteredRawInputDevices")]
	private unsafe static extern int VVkBQOHaKdcWrMOGmkLsQAcZwcAI(void*, void*, int);

	// Token: 0x06000B20 RID: 2848 RVA: 0x0003D5B0 File Offset: 0x0003B7B0
	public unsafe static int hryjfLFxJeJzKEAFyOlEwkIqFCBo(IntPtr A_0, uYyVWuBOXcvoXobWFzSAukvLDpji A_1, IntPtr A_2, ref int A_3)
	{
		int result;
		fixed (int* ptr = &A_3)
		{
			void* ptr2 = (void*)ptr;
			result = xSOZMZyIgwUNJGxbaunJqIAqJnsT.ZyujyeAakTUslFPccfvHMdeHdsKc((void*)A_0, (int)A_1, (void*)A_2, ptr2);
		}
		return result;
	}

	// Token: 0x06000B21 RID: 2849
	[SuppressUnmanagedCodeSecurity]
	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputDeviceInfoW")]
	private unsafe static extern int ZyujyeAakTUslFPccfvHMdeHdsKc(void*, int, void*, void*);

	// Token: 0x06000B22 RID: 2850 RVA: 0x0003D5D8 File Offset: 0x0003B7D8
	public unsafe static ycPNoWIqyMTmKlpivOlkjvCiRrXq qUUflGtYXtgEFucQjwKbdQHFgKeO(ALCNEBxFbeXYHuttdAnDwwiEVchj[] A_0, int A_1, int A_2)
	{
		ycPNoWIqyMTmKlpivOlkjvCiRrXq result;
		fixed (ALCNEBxFbeXYHuttdAnDwwiEVchj[] array = A_0)
		{
			void* ptr;
			if (A_0 == null || array.Length == 0)
			{
				ptr = null;
			}
			else
			{
				ptr = (void*)(&array[0]);
			}
			result = xSOZMZyIgwUNJGxbaunJqIAqJnsT.xupIMmFOCWHIDHCEGfHuYeNtDbWjb(ptr, A_1, A_2);
		}
		return result;
	}

	// Token: 0x06000B23 RID: 2851
	[SuppressUnmanagedCodeSecurity]
	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "RegisterRawInputDevices")]
	private unsafe static extern ycPNoWIqyMTmKlpivOlkjvCiRrXq xupIMmFOCWHIDHCEGfHuYeNtDbWjb(void*, int, int);

	// Token: 0x06000B24 RID: 2852 RVA: 0x0003D608 File Offset: 0x0003B808
	public unsafe static int DgWnItSQvYsINQJlATiLcFiesveJ(kElCtFzCydaZDyFGuNZLqslYlQZW[] A_0, ref int A_1, int A_2)
	{
		int result;
		fixed (kElCtFzCydaZDyFGuNZLqslYlQZW[] array = A_0)
		{
			void* ptr;
			if (A_0 == null || array.Length == 0)
			{
				ptr = null;
			}
			else
			{
				ptr = (void*)(&array[0]);
			}
			fixed (int* ptr2 = &A_1)
			{
				void* ptr3 = (void*)ptr2;
				result = xSOZMZyIgwUNJGxbaunJqIAqJnsT.bYyakTxnyNBYFDcBWXhbOMsXUyGAA(ptr, ptr3, A_2);
			}
		}
		return result;
	}

	// Token: 0x06000B25 RID: 2853
	[SuppressUnmanagedCodeSecurity]
	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputBuffer")]
	private unsafe static extern int bYyakTxnyNBYFDcBWXhbOMsXUyGAA(void*, void*, int);

	// Token: 0x06000B26 RID: 2854 RVA: 0x0003D640 File Offset: 0x0003B840
	public unsafe static int clYPfssLczIiMlrNtcNbHWVUpPzL(IntPtr A_0, nBJtoafaLUVsNPnOxKfzOoajMSgx A_1, IntPtr A_2, ref int A_3, int A_4)
	{
		int result;
		fixed (int* ptr = &A_3)
		{
			void* ptr2 = (void*)ptr;
			result = xSOZMZyIgwUNJGxbaunJqIAqJnsT.RpRIoKUnCRQQDzfVsfBzBgAOPzUT((void*)A_0, (int)A_1, (void*)A_2, ptr2, A_4);
		}
		return result;
	}

	// Token: 0x06000B27 RID: 2855
	[SuppressUnmanagedCodeSecurity]
	[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "GetRawInputData")]
	private unsafe static extern int RpRIoKUnCRQQDzfVsfBzBgAOPzUT(void*, int, void*, void*, int);
}
