using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Token: 0x0200018B RID: 395
internal class fndeayEOpPHCfGNVpYfFliZgicJFA : bLQyAnEvRFuIpAmLSyoxHOsAZpLC
{
	// Token: 0x06000B9E RID: 2974 RVA: 0x0003E3C4 File Offset: 0x0003C5C4
	protected unsafe virtual bLQyAnEvRFuIpAmLSyoxHOsAZpLC QenfCzBXUVkEPYlyyFPdeWaiyaioA(int A_1, IntPtr A_2)
	{
		if (A_1 <= 0 || A_1 % sizeof(VrGcOvxQBLgACVMiNqKlmABwJGiK) != 0)
		{
			return null;
		}
		int num = A_1 / sizeof(VrGcOvxQBLgACVMiNqKlmABwJGiK);
		this.uesvwaITrRmPWzcYEcdeiSqvGVSVA = new VrGcOvxQBLgACVMiNqKlmABwJGiK[num];
		VrGcOvxQBLgACVMiNqKlmABwJGiK[] array;
		VrGcOvxQBLgACVMiNqKlmABwJGiK* value;
		if ((array = this.uesvwaITrRmPWzcYEcdeiSqvGVSVA) == null || array.Length == 0)
		{
			value = null;
		}
		else
		{
			value = &array[0];
		}
		HtGHfzvtpMNSxwkJwcWlhmdnZCmfA.bHAETBtKdLwdhZkJqcIebuAEEprdb((IntPtr)((void*)value), A_2, HtGHfzvtpMNSxwkJwcWlhmdnZCmfA.OtegDtkLmarAmSgMcuCzwfGeriInA<VrGcOvxQBLgACVMiNqKlmABwJGiK>() * this.uesvwaITrRmPWzcYEcdeiSqvGVSVA.Length);
		array = null;
		return this;
	}

	// Token: 0x06000B9F RID: 2975 RVA: 0x0003E430 File Offset: 0x0003C630
	internal unsafe virtual IntPtr XLqqjhcHYuoIWuGaqhiFeaUjjtZeA()
	{
		if (this.DzXDrmbBRWtCQfDISINwkdhMporx == 0)
		{
			return IntPtr.Zero;
		}
		IntPtr intPtr = Marshal.AllocHGlobal(this.DzXDrmbBRWtCQfDISINwkdhMporx);
		VrGcOvxQBLgACVMiNqKlmABwJGiK[] array;
		VrGcOvxQBLgACVMiNqKlmABwJGiK* value;
		if ((array = this.uesvwaITrRmPWzcYEcdeiSqvGVSVA) == null || array.Length == 0)
		{
			value = null;
		}
		else
		{
			value = &array[0];
		}
		HtGHfzvtpMNSxwkJwcWlhmdnZCmfA.bHAETBtKdLwdhZkJqcIebuAEEprdb(intPtr, (IntPtr)((void*)value), HtGHfzvtpMNSxwkJwcWlhmdnZCmfA.OtegDtkLmarAmSgMcuCzwfGeriInA<VrGcOvxQBLgACVMiNqKlmABwJGiK>() * this.uesvwaITrRmPWzcYEcdeiSqvGVSVA.Length);
		array = null;
		return intPtr;
	}

	// Token: 0x170001F5 RID: 501
	// (get) Token: 0x06000BA0 RID: 2976 RVA: 0x00018179 File Offset: 0x00016379
	// (set) Token: 0x06000BA1 RID: 2977 RVA: 0x00018181 File Offset: 0x00016381
	public VrGcOvxQBLgACVMiNqKlmABwJGiK[] uesvwaITrRmPWzcYEcdeiSqvGVSVA { get; set; }

	// Token: 0x170001F6 RID: 502
	// (get) Token: 0x06000BA2 RID: 2978 RVA: 0x0001818A File Offset: 0x0001638A
	public override int DzXDrmbBRWtCQfDISINwkdhMporx
	{
		get
		{
			if (this.uesvwaITrRmPWzcYEcdeiSqvGVSVA == null)
			{
				return 0;
			}
			return this.uesvwaITrRmPWzcYEcdeiSqvGVSVA.Length * sizeof(VrGcOvxQBLgACVMiNqKlmABwJGiK);
		}
	}

	// Token: 0x040017F5 RID: 6133
	[CompilerGenerated]
	private VrGcOvxQBLgACVMiNqKlmABwJGiK[] tdCTAMTgPHGLmtYSYgdDHEpLwuh;
}
