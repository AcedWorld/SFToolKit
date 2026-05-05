using System;
using System.Runtime.InteropServices;

// Token: 0x02000045 RID: 69
[StructLayout(LayoutKind.Explicit, Pack = 1)]
internal struct kZdMVYdrJYnBIKqGOBfzblDVLyEjA
{
	// Token: 0x060002B9 RID: 697 RVA: 0x00012911 File Offset: 0x00010B11
	static kZdMVYdrJYnBIKqGOBfzblDVLyEjA()
	{
		kZdMVYdrJYnBIKqGOBfzblDVLyEjA.VYLUbHFjFThjekGQXignZEGMomHNA = (kZdMVYdrJYnBIKqGOBfzblDVLyEjA.kUKmuWfsqEQBWKgIAMkBwlinzjIc == 8);
	}

	// Token: 0x060002BA RID: 698 RVA: 0x00029888 File Offset: 0x00027A88
	public static kZdMVYdrJYnBIKqGOBfzblDVLyEjA HXPphJERgMCHaXSEgCFFHrhVJVwu(byte[] A_0, int A_1)
	{
		kZdMVYdrJYnBIKqGOBfzblDVLyEjA kZdMVYdrJYnBIKqGOBfzblDVLyEjA = default(kZdMVYdrJYnBIKqGOBfzblDVLyEjA);
		if (kZdMVYdrJYnBIKqGOBfzblDVLyEjA.VYLUbHFjFThjekGQXignZEGMomHNA)
		{
			kZdMVYdrJYnBIKqGOBfzblDVLyEjA.vaYJIqaUDhRGBfNHxiZcusFmFtRv = BitConverter.ToInt64(A_0, A_1);
			kZdMVYdrJYnBIKqGOBfzblDVLyEjA.OEDofURUDvAMSGeyitCoSkXhkHat = new IntPtr(kZdMVYdrJYnBIKqGOBfzblDVLyEjA.vaYJIqaUDhRGBfNHxiZcusFmFtRv);
		}
		else
		{
			kZdMVYdrJYnBIKqGOBfzblDVLyEjA.wFnWywiairIMRJFSXVgjtqeggfsTA = BitConverter.ToInt32(A_0, A_1);
			kZdMVYdrJYnBIKqGOBfzblDVLyEjA.OEDofURUDvAMSGeyitCoSkXhkHat = new IntPtr(kZdMVYdrJYnBIKqGOBfzblDVLyEjA.wFnWywiairIMRJFSXVgjtqeggfsTA);
		}
		return kZdMVYdrJYnBIKqGOBfzblDVLyEjA;
	}

	// Token: 0x060002BB RID: 699 RVA: 0x000298E8 File Offset: 0x00027AE8
	public static kZdMVYdrJYnBIKqGOBfzblDVLyEjA ADkZRkXLIFGYzhPpEyjtmJlwpNIPA(IntPtr A_0)
	{
		kZdMVYdrJYnBIKqGOBfzblDVLyEjA result = default(kZdMVYdrJYnBIKqGOBfzblDVLyEjA);
		result.OEDofURUDvAMSGeyitCoSkXhkHat = A_0;
		if (kZdMVYdrJYnBIKqGOBfzblDVLyEjA.VYLUbHFjFThjekGQXignZEGMomHNA)
		{
			result.vaYJIqaUDhRGBfNHxiZcusFmFtRv = A_0.ToInt64();
		}
		else
		{
			result.wFnWywiairIMRJFSXVgjtqeggfsTA = A_0.ToInt32();
		}
		return result;
	}

	// Token: 0x060002BC RID: 700 RVA: 0x0001292A File Offset: 0x00010B2A
	public static IntPtr OQRvHBAFMCxTJPYalufDKrvfaMFh(kZdMVYdrJYnBIKqGOBfzblDVLyEjA A_0)
	{
		return A_0.OEDofURUDvAMSGeyitCoSkXhkHat;
	}

	// Token: 0x060002BD RID: 701 RVA: 0x00012932 File Offset: 0x00010B32
	public string eAaHbAhAczuAYTqFdCeNGmZIKUGHb()
	{
		if (kZdMVYdrJYnBIKqGOBfzblDVLyEjA.VYLUbHFjFThjekGQXignZEGMomHNA)
		{
			return this.vaYJIqaUDhRGBfNHxiZcusFmFtRv.ToString();
		}
		return this.wFnWywiairIMRJFSXVgjtqeggfsTA.ToString();
	}

	// Token: 0x0400046D RID: 1133
	[FieldOffset(0)]
	private int wFnWywiairIMRJFSXVgjtqeggfsTA;

	// Token: 0x0400046E RID: 1134
	[FieldOffset(0)]
	private long vaYJIqaUDhRGBfNHxiZcusFmFtRv;

	// Token: 0x0400046F RID: 1135
	[FieldOffset(0)]
	private IntPtr OEDofURUDvAMSGeyitCoSkXhkHat;

	// Token: 0x04000470 RID: 1136
	private static readonly bool VYLUbHFjFThjekGQXignZEGMomHNA;

	// Token: 0x04000471 RID: 1137
	public static readonly int kUKmuWfsqEQBWKgIAMkBwlinzjIc = IntPtr.Size;
}
