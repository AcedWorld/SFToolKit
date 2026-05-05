using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

// Token: 0x02000111 RID: 273
internal static class HtGHfzvtpMNSxwkJwcWlhmdnZCmfA
{
	// Token: 0x060009E9 RID: 2537
	[SuppressUnmanagedCodeSecurity]
	[DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "memcpy")]
	private unsafe static extern void* IfYIWUtHpyKVUQIIkCLMCvDcIeZY(void*, void*, UIntPtr);

	// Token: 0x060009EA RID: 2538
	[SuppressUnmanagedCodeSecurity]
	[DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "memset")]
	private unsafe static extern void* rsIByBUcEZrxFKtxzEUQZhHbUJVg(void*, int, UIntPtr);

	// Token: 0x060009EB RID: 2539 RVA: 0x0001735C File Offset: 0x0001555C
	private unsafe static void* BRTLJhmxIJthYHhKfmhpxrfcSvVs(void* A_0, void* A_1, int A_2)
	{
		return HtGHfzvtpMNSxwkJwcWlhmdnZCmfA.IfYIWUtHpyKVUQIIkCLMCvDcIeZY(A_0, A_1, new UIntPtr((uint)A_2));
	}

	// Token: 0x060009EC RID: 2540 RVA: 0x0001736B File Offset: 0x0001556B
	private unsafe static void* ChpbjDEfDOHBkRyKgqwYSLthfNnw(void* A_0, byte A_1, int A_2)
	{
		return HtGHfzvtpMNSxwkJwcWlhmdnZCmfA.rsIByBUcEZrxFKtxzEUQZhHbUJVg(A_0, (int)A_1, new UIntPtr((uint)A_2));
	}

	// Token: 0x060009ED RID: 2541 RVA: 0x0001737A File Offset: 0x0001557A
	public unsafe static void bHAETBtKdLwdhZkJqcIebuAEEprdb(IntPtr A_0, IntPtr A_1, int A_2)
	{
		HtGHfzvtpMNSxwkJwcWlhmdnZCmfA.BRTLJhmxIJthYHhKfmhpxrfcSvVs((void*)A_0, (void*)A_1, A_2);
	}

	// Token: 0x060009EE RID: 2542 RVA: 0x0003B48C File Offset: 0x0003968C
	public unsafe static bool rShCfrjVVtBCSTqizTjhNsdmAhXUA(IntPtr A_0, IntPtr A_1, int A_2)
	{
		byte* ptr = (byte*)((void*)A_0);
		byte* ptr2 = (byte*)((void*)A_1);
		for (int i = A_2 >> 3; i > 0; i--)
		{
			if (*(long*)ptr != *(long*)ptr2)
			{
				return false;
			}
			ptr += 8;
			ptr2 += 8;
		}
		for (int i = A_2 & 7; i > 0; i--)
		{
			if (*ptr != *ptr2)
			{
				return false;
			}
			ptr++;
			ptr2++;
		}
		return true;
	}

	// Token: 0x060009EF RID: 2543 RVA: 0x0001738F File Offset: 0x0001558F
	public unsafe static void bNplJurvmJkVgdtzBDgoFsHkQJmC(IntPtr A_0, byte A_1, int A_2)
	{
		HtGHfzvtpMNSxwkJwcWlhmdnZCmfA.ChpbjDEfDOHBkRyKgqwYSLthfNnw((void*)A_0, A_1, A_2);
	}

	// Token: 0x060009F0 RID: 2544 RVA: 0x0001739F File Offset: 0x0001559F
	public static int OtegDtkLmarAmSgMcuCzwfGeriInA<\u0001>() where \u0001 : struct
	{
		return Marshal.SizeOf(typeof(\u0001));
	}

	// Token: 0x060009F1 RID: 2545 RVA: 0x000173B0 File Offset: 0x000155B0
	public static int JlPvsDqlPzGAQLcmuItIDVmtSRcw<\u0001>(\u0001[] A_0) where \u0001 : struct
	{
		if (A_0 != null)
		{
			return A_0.Length * Marshal.SizeOf(typeof(\u0001));
		}
		return 0;
	}

	// Token: 0x060009F2 RID: 2546 RVA: 0x0003B4E4 File Offset: 0x000396E4
	public static void vWJWSkbuJJSxfopLruvAtoaTSKIc<\u0001>(ref \u0001 A_0, Action<IntPtr> A_1) where \u0001 : struct
	{
		GCHandle gchandle = GCHandle.Alloc(A_0, GCHandleType.Pinned);
		A_1(gchandle.AddrOfPinnedObject());
		GC.KeepAlive(gchandle);
		gchandle.Free();
	}

	// Token: 0x060009F3 RID: 2547 RVA: 0x0003B524 File Offset: 0x00039724
	public static void TjXybSjVYKrpADCfGZUMJkceqHNP<\u0001>(\u0001[] A_0, Action<IntPtr> A_1) where \u0001 : struct
	{
		if (A_0 == null)
		{
			A_1(IntPtr.Zero);
			return;
		}
		GCHandle gchandle = GCHandle.Alloc(A_0, GCHandleType.Pinned);
		A_1(gchandle.AddrOfPinnedObject());
		GC.KeepAlive(gchandle);
		gchandle.Free();
	}

	// Token: 0x060009F4 RID: 2548 RVA: 0x000173CA File Offset: 0x000155CA
	public static Guid GvhcvCTcTAFKTTeLHDNLioRSPkvbA(Type A_0)
	{
		return A_0.GUID;
	}

	// Token: 0x060009F5 RID: 2549 RVA: 0x0003B568 File Offset: 0x00039768
	public unsafe static string OVBDmzcmbIGyIUlFucpaGetfjgjKc(IntPtr A_0, int A_1)
	{
		byte* ptr = (byte*)((void*)A_0);
		for (int i = 0; i < A_1; i++)
		{
			if (*(ptr++) == 0)
			{
				return new string((sbyte*)((void*)A_0));
			}
		}
		return new string((sbyte*)((void*)A_0), 0, A_1);
	}

	// Token: 0x060009F6 RID: 2550 RVA: 0x0003B5AC File Offset: 0x000397AC
	public unsafe static string IxntdFlHBxCIucfEqTtqKViuKUAE(IntPtr A_0, int A_1)
	{
		char* ptr = (char*)((void*)A_0);
		for (int i = 0; i < A_1; i++)
		{
			if (*(ptr++) == '\0')
			{
				return new string((char*)((void*)A_0));
			}
		}
		return new string((char*)((void*)A_0), 0, A_1);
	}

	// Token: 0x060009F7 RID: 2551 RVA: 0x000173D2 File Offset: 0x000155D2
	public static IntPtr QvKradPHJkwsNoGcShAFaFhCzBFLA(string A_0)
	{
		return Marshal.StringToHGlobalUni(A_0);
	}

	// Token: 0x060009F8 RID: 2552 RVA: 0x0003B5F0 File Offset: 0x000397F0
	public static string laIEOdATqftJyTsuGTSxMCOFMMUOA<\u0001>(string A_0, \u0001[] A_1)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (A_1 != null)
		{
			for (int i = 0; i < A_1.Length; i++)
			{
				if (i > 0)
				{
					stringBuilder.Append(A_0);
				}
				stringBuilder.Append(A_1[i]);
			}
		}
		return stringBuilder.ToString();
	}

	// Token: 0x060009F9 RID: 2553 RVA: 0x0003B63C File Offset: 0x0003983C
	public static string CGGLiqYFwkkJLIdQtykVffayuzcN(string A_0, IEnumerable A_1)
	{
		List<string> list = new List<string>();
		foreach (object obj in A_1)
		{
			list.Add(obj.ToString());
		}
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < list.Count; i++)
		{
			string value = list[i];
			if (i > 0)
			{
				stringBuilder.Append(A_0);
			}
			stringBuilder.Append(value);
		}
		return stringBuilder.ToString();
	}

	// Token: 0x060009FA RID: 2554 RVA: 0x0003B6DC File Offset: 0x000398DC
	public static string JvclAPiVUEdKEwMRagiFkApJeismA(string A_0, IEnumerator A_1)
	{
		List<string> list = new List<string>();
		while (A_1.MoveNext())
		{
			object obj = A_1.Current;
			list.Add(obj.ToString());
		}
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < list.Count; i++)
		{
			string value = list[i];
			if (i > 0)
			{
				stringBuilder.Append(A_0);
			}
			stringBuilder.Append(value);
		}
		return stringBuilder.ToString();
	}

	// Token: 0x060009FB RID: 2555 RVA: 0x000173DA File Offset: 0x000155DA
	public static bool CeoMKAWkXhBKnjEhIcVevNxhIRPfb(Type A_0)
	{
		return A_0.IsEnum;
	}

	// Token: 0x060009FC RID: 2556 RVA: 0x000173E2 File Offset: 0x000155E2
	public static bool WqzdGefpcNsSwZshHQKdDPqpFRQgb(Type A_0)
	{
		return A_0.IsValueType;
	}
}
