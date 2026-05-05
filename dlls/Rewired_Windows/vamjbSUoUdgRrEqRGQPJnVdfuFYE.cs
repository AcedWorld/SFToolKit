using System;

// Token: 0x0200014F RID: 335
internal struct vamjbSUoUdgRrEqRGQPJnVdfuFYE
{
	// Token: 0x06000B34 RID: 2868 RVA: 0x0003D6D8 File Offset: 0x0003B8D8
	internal unsafe vamjbSUoUdgRrEqRGQPJnVdfuFYE(ref kElCtFzCydaZDyFGuNZLqslYlQZW A_1, mVKvxHfvubEgmTsBFFRaJHKNjmcv A_2)
	{
		this.WEWknRaeijaJJeuhUBexkhWQTzEJ = A_1.PcFBGwGlcqUwthPHvoGnDqpxiomIA.jyBKLAbBYjFKqqFTJvRTweMYgXRcA;
		this.QULTazTtGyiySPiuTDxmjaEnkmyc = A_1.KgdDRHgUxVWHuCNmgSXDIvCXmMVs.HHGHoQudegpqVumZzAxHJEsMqeXq.ulCkAWuEwVqgIFPGAafMaMEBPOdrA;
		this.RZfXjfrZFGqXntfIAbEysabgIGGl = A_1.KgdDRHgUxVWHuCNmgSXDIvCXmMVs.HHGHoQudegpqVumZzAxHJEsMqeXq.shqUwayPZqiLdZGivsRtOrkwmYzT;
		this.hxTJasgXvuRrrZbBJRwSdumRvIXH = this.QULTazTtGyiySPiuTDxmjaEnkmyc * this.RZfXjfrZFGqXntfIAbEysabgIGGl;
		if (this.hxTJasgXvuRrrZbBJRwSdumRvIXH > 0)
		{
			fixed (int* ptr = &A_1.KgdDRHgUxVWHuCNmgSXDIvCXmMVs.HHGHoQudegpqVumZzAxHJEsMqeXq.VOEzlydaLjAcHivIGEpVeSuZrGvY)
			{
				void* ptr2 = (void*)ptr;
				this.SSNGPdJtGIGUKHHMovWuhQGwhGSLA = A_2.hUSjnslKtHBXtaEQJEMyAyNaeVZyA((uint)this.hxTJasgXvuRrrZbBJRwSdumRvIXH, ptr2);
			}
			return;
		}
		this.SSNGPdJtGIGUKHHMovWuhQGwhGSLA = IntPtr.Zero;
	}

	// Token: 0x170001DF RID: 479
	// (get) Token: 0x06000B35 RID: 2869 RVA: 0x00017DA9 File Offset: 0x00015FA9
	internal bool DTpXjPojZbZcurZeewyDLEMyBuIY
	{
		get
		{
			return this.hxTJasgXvuRrrZbBJRwSdumRvIXH > 0 && this.SSNGPdJtGIGUKHHMovWuhQGwhGSLA != IntPtr.Zero;
		}
	}

	// Token: 0x170001E0 RID: 480
	// (get) Token: 0x06000B36 RID: 2870 RVA: 0x00017DC6 File Offset: 0x00015FC6
	public IntPtr VKGPYjQvFSgixebXspbhjgmWxMZN
	{
		get
		{
			return this.SSNGPdJtGIGUKHHMovWuhQGwhGSLA;
		}
	}

	// Token: 0x170001E1 RID: 481
	// (get) Token: 0x06000B37 RID: 2871 RVA: 0x00017DCE File Offset: 0x00015FCE
	public int elejcnSCVfQebqripkIfupPGNZCe
	{
		get
		{
			return this.hxTJasgXvuRrrZbBJRwSdumRvIXH;
		}
	}

	// Token: 0x040009F8 RID: 2552
	public IntPtr WEWknRaeijaJJeuhUBexkhWQTzEJ;

	// Token: 0x040009F9 RID: 2553
	private IntPtr SSNGPdJtGIGUKHHMovWuhQGwhGSLA;

	// Token: 0x040009FA RID: 2554
	private int hxTJasgXvuRrrZbBJRwSdumRvIXH;

	// Token: 0x040009FB RID: 2555
	public int QULTazTtGyiySPiuTDxmjaEnkmyc;

	// Token: 0x040009FC RID: 2556
	public int RZfXjfrZFGqXntfIAbEysabgIGGl;
}
