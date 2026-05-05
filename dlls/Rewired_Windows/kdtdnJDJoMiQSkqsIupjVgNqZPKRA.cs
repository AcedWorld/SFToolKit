using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Token: 0x0200018E RID: 398
internal class kdtdnJDJoMiQSkqsIupjVgNqZPKRA : bLQyAnEvRFuIpAmLSyoxHOsAZpLC
{
	// Token: 0x170001F9 RID: 505
	// (get) Token: 0x06000BB6 RID: 2998 RVA: 0x00018257 File Offset: 0x00016457
	// (set) Token: 0x06000BB7 RID: 2999 RVA: 0x0001825F File Offset: 0x0001645F
	public int UpWtGcakFEcoIFLgHPkdsnXuKnouA { get; set; }

	// Token: 0x170001FA RID: 506
	// (get) Token: 0x06000BB8 RID: 3000 RVA: 0x00018268 File Offset: 0x00016468
	// (set) Token: 0x06000BB9 RID: 3001 RVA: 0x00018270 File Offset: 0x00016470
	public int xijmVKJayhZSKkxewrVyeRniMHwS { get; set; }

	// Token: 0x170001FB RID: 507
	// (get) Token: 0x06000BBA RID: 3002 RVA: 0x00018279 File Offset: 0x00016479
	// (set) Token: 0x06000BBB RID: 3003 RVA: 0x00018281 File Offset: 0x00016481
	public int CtaNAJRfMZAIGcQclahBzkPPeoztA { get; set; }

	// Token: 0x170001FC RID: 508
	// (get) Token: 0x06000BBC RID: 3004 RVA: 0x0001828A File Offset: 0x0001648A
	// (set) Token: 0x06000BBD RID: 3005 RVA: 0x00018292 File Offset: 0x00016492
	public int[] vSTzughNXwKztTZMXZrEgycrDdVI { get; set; }

	// Token: 0x06000BBE RID: 3006 RVA: 0x0003EB54 File Offset: 0x0003CD54
	protected unsafe virtual bLQyAnEvRFuIpAmLSyoxHOsAZpLC WolcEjQTIQIEwjJEyMcSbiSovGMAA(int A_1, IntPtr A_2)
	{
		if (A_1 != sizeof(EkXUfBkdgRmxodQLhkdrqDEhDrAY))
		{
			return null;
		}
		this.UpWtGcakFEcoIFLgHPkdsnXuKnouA = ((EkXUfBkdgRmxodQLhkdrqDEhDrAY*)((void*)A_2))->jZWvxDwiTkJmrWMlKWJvElNRFVPN;
		this.xijmVKJayhZSKkxewrVyeRniMHwS = ((EkXUfBkdgRmxodQLhkdrqDEhDrAY*)((void*)A_2))->kQprrmkESxGGgAVeBhVHFCvJmPFrB;
		this.CtaNAJRfMZAIGcQclahBzkPPeoztA = ((EkXUfBkdgRmxodQLhkdrqDEhDrAY*)((void*)A_2))->EeKrsoHyWufUqcWmeJDjjtNGvggC;
		this.vSTzughNXwKztTZMXZrEgycrDdVI = new int[this.CtaNAJRfMZAIGcQclahBzkPPeoztA];
		int[] array;
		int* value;
		if ((array = this.vSTzughNXwKztTZMXZrEgycrDdVI) == null || array.Length == 0)
		{
			value = null;
		}
		else
		{
			value = &array[0];
		}
		HtGHfzvtpMNSxwkJwcWlhmdnZCmfA.bHAETBtKdLwdhZkJqcIebuAEEprdb((IntPtr)((void*)value), ((EkXUfBkdgRmxodQLhkdrqDEhDrAY*)((void*)A_2))->KARpklayJQeUeolRyeFNvwpyRhCc, this.vSTzughNXwKztTZMXZrEgycrDdVI.Length * sizeof(EkXUfBkdgRmxodQLhkdrqDEhDrAY));
		array = null;
		return this;
	}

	// Token: 0x06000BBF RID: 3007 RVA: 0x0003EBF8 File Offset: 0x0003CDF8
	internal unsafe virtual IntPtr AVsWcfrdcuPgZeMrXyfpSaguDYhdA()
	{
		IntPtr intPtr = Marshal.AllocHGlobal(this.DzXDrmbBRWtCQfDISINwkdhMporx);
		((EkXUfBkdgRmxodQLhkdrqDEhDrAY*)((void*)intPtr))->jZWvxDwiTkJmrWMlKWJvElNRFVPN = this.UpWtGcakFEcoIFLgHPkdsnXuKnouA;
		((EkXUfBkdgRmxodQLhkdrqDEhDrAY*)((void*)intPtr))->kQprrmkESxGGgAVeBhVHFCvJmPFrB = this.xijmVKJayhZSKkxewrVyeRniMHwS;
		((EkXUfBkdgRmxodQLhkdrqDEhDrAY*)((void*)intPtr))->EeKrsoHyWufUqcWmeJDjjtNGvggC = this.CtaNAJRfMZAIGcQclahBzkPPeoztA;
		IntPtr intPtr2 = Marshal.AllocHGlobal(this.vSTzughNXwKztTZMXZrEgycrDdVI.Length * 4);
		((EkXUfBkdgRmxodQLhkdrqDEhDrAY*)((void*)intPtr))->KARpklayJQeUeolRyeFNvwpyRhCc = intPtr2;
		int[] array;
		int* value;
		if ((array = this.vSTzughNXwKztTZMXZrEgycrDdVI) == null || array.Length == 0)
		{
			value = null;
		}
		else
		{
			value = &array[0];
		}
		HtGHfzvtpMNSxwkJwcWlhmdnZCmfA.bHAETBtKdLwdhZkJqcIebuAEEprdb(intPtr2, (IntPtr)((void*)value), this.vSTzughNXwKztTZMXZrEgycrDdVI.Length * 4);
		array = null;
		return intPtr;
	}

	// Token: 0x06000BC0 RID: 3008 RVA: 0x0001829B File Offset: 0x0001649B
	internal unsafe virtual void vjTCiBMgqlvRvKiLkdnUAlUUNYECb(IntPtr A_1)
	{
		base.nqfBNDUedFKbLQbUwlpZWZmwGurI(A_1);
		if (A_1 != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(((EkXUfBkdgRmxodQLhkdrqDEhDrAY*)((void*)A_1))->KARpklayJQeUeolRyeFNvwpyRhCc);
		}
	}

	// Token: 0x170001FD RID: 509
	// (get) Token: 0x06000BC1 RID: 3009 RVA: 0x000182C1 File Offset: 0x000164C1
	public override int DzXDrmbBRWtCQfDISINwkdhMporx
	{
		get
		{
			return HtGHfzvtpMNSxwkJwcWlhmdnZCmfA.OtegDtkLmarAmSgMcuCzwfGeriInA<EkXUfBkdgRmxodQLhkdrqDEhDrAY>();
		}
	}

	// Token: 0x040017FA RID: 6138
	[CompilerGenerated]
	private int LkHrNQDPeIrXrtwWxlcKefwodelr;

	// Token: 0x040017FB RID: 6139
	[CompilerGenerated]
	private int WzzpfiWCPoQIImVBaOGhcyspYUbm;

	// Token: 0x040017FC RID: 6140
	[CompilerGenerated]
	private int YXHwHKXcidFcWaLrNfSVcIAJcRpeA;

	// Token: 0x040017FD RID: 6141
	[CompilerGenerated]
	private int[] RvxHkFqlHzEfUJpXSqIMJrwSbpadb;
}
