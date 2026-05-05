using System;
using System.Runtime.InteropServices;
using Rewired.Utils;

// Token: 0x0200004D RID: 77
internal static class dbFxJTqcdtfDszZoTWNEROjxsYlL
{
	// Token: 0x060002D5 RID: 725 RVA: 0x00029C44 File Offset: 0x00027E44
	public static string lcwawEgdEZhLdHQsgfStEPFTRpLKA(IntPtr A_0, int A_1)
	{
		if (A_1 <= 0)
		{
			return null;
		}
		if (A_1 < 2 || Marshal.ReadByte(A_0, A_1 - 1) != 0 || Marshal.ReadByte(A_0, A_1 - 2) != 0)
		{
			IntPtr intPtr = Marshal.AllocHGlobal(A_1 + 2);
			NativeTools.CopyMemory(A_0, intPtr, 0, 0, A_1, true);
			Marshal.WriteInt16(intPtr, A_1, 0);
			string result = Marshal.PtrToStringUni(intPtr);
			Marshal.FreeHGlobal(intPtr);
			return result;
		}
		return dbFxJTqcdtfDszZoTWNEROjxsYlL.rdGSjpAlIVHowaJSsomserbqkJlab(Marshal.PtrToStringUni(A_0));
	}

	// Token: 0x060002D6 RID: 726 RVA: 0x00012AF2 File Offset: 0x00010CF2
	public static string jHaLMmheeRBUcURIlppoWGQzIrtt(IntPtr A_0, int A_1)
	{
		return dbFxJTqcdtfDszZoTWNEROjxsYlL.rdGSjpAlIVHowaJSsomserbqkJlab(Marshal.PtrToStringUni(A_0, A_1));
	}

	// Token: 0x060002D7 RID: 727 RVA: 0x00012B00 File Offset: 0x00010D00
	public static string rdGSjpAlIVHowaJSsomserbqkJlab(string A_0)
	{
		if (string.IsNullOrEmpty(A_0))
		{
			return A_0;
		}
		if (A_0.Length == 0)
		{
			return A_0;
		}
		if (A_0[A_0.Length - 1] != '\0')
		{
			return A_0;
		}
		return A_0.Substring(0, A_0.Length - 1);
	}
}
