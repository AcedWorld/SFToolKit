using System;
using System.Globalization;
using System.Runtime.CompilerServices;

// Token: 0x0200021F RID: 543
internal class cvqNjRlEiJzcmUmkMIwIbBEPgDzA : tFNOPzyrRPIZzozOnLxpVcObMonq<UBsnuxCUybokyXlUwtANvFNCSPsO, XWBIgSXgTMgUPPJsliNdLQKcRzgv>
{
	// Token: 0x06000DD4 RID: 3540 RVA: 0x000191E0 File Offset: 0x000173E0
	public cvqNjRlEiJzcmUmkMIwIbBEPgDzA()
	{
		this.CFqjbzifsIitEfxZbAYHnpxFcmIhA = new bool[8];
	}

	// Token: 0x1700026A RID: 618
	// (get) Token: 0x06000DD5 RID: 3541 RVA: 0x000191F4 File Offset: 0x000173F4
	// (set) Token: 0x06000DD6 RID: 3542 RVA: 0x000191FC File Offset: 0x000173FC
	public int lNdfrwpJMToOSMmoQAwNNaglQLzo { get; set; }

	// Token: 0x1700026B RID: 619
	// (get) Token: 0x06000DD7 RID: 3543 RVA: 0x00019205 File Offset: 0x00017405
	// (set) Token: 0x06000DD8 RID: 3544 RVA: 0x0001920D File Offset: 0x0001740D
	public int zXXIApjNNhEfqYkwwvSitvmKGzyh { get; set; }

	// Token: 0x1700026C RID: 620
	// (get) Token: 0x06000DD9 RID: 3545 RVA: 0x00019216 File Offset: 0x00017416
	// (set) Token: 0x06000DDA RID: 3546 RVA: 0x0001921E File Offset: 0x0001741E
	public int DtGiaHLjKpYoutTajIKVTkaqgHLd { get; set; }

	// Token: 0x1700026D RID: 621
	// (get) Token: 0x06000DDB RID: 3547 RVA: 0x00019227 File Offset: 0x00017427
	// (set) Token: 0x06000DDC RID: 3548 RVA: 0x0001922F File Offset: 0x0001742F
	public bool[] CFqjbzifsIitEfxZbAYHnpxFcmIhA { get; private set; }

	// Token: 0x06000DDD RID: 3549 RVA: 0x000427A4 File Offset: 0x000409A4
	public void sexgWUOknUQIqwJuxGkqoODGvHvK(XWBIgSXgTMgUPPJsliNdLQKcRzgv A_1)
	{
		int num = A_1.badAEkKaVcBGVFDNvGeCukObALeEA;
		DJBBEkVPAZAGXOhBNQXuetQhnqFg djbbekVPAZAGXOhBNQXuetQhnqFg = A_1.vvOTnFgkCNbgzcRnPsNTQNAjDJfDb;
		if (djbbekVPAZAGXOhBNQXuetQhnqFg == DJBBEkVPAZAGXOhBNQXuetQhnqFg.X)
		{
			this.lNdfrwpJMToOSMmoQAwNNaglQLzo = num;
			return;
		}
		if (djbbekVPAZAGXOhBNQXuetQhnqFg == DJBBEkVPAZAGXOhBNQXuetQhnqFg.Y)
		{
			this.zXXIApjNNhEfqYkwwvSitvmKGzyh = num;
			return;
		}
		if (djbbekVPAZAGXOhBNQXuetQhnqFg != DJBBEkVPAZAGXOhBNQXuetQhnqFg.Z)
		{
			int num2 = A_1.vvOTnFgkCNbgzcRnPsNTQNAjDJfDb - DJBBEkVPAZAGXOhBNQXuetQhnqFg.Buttons0;
			if (num2 >= 0 && num2 < 8)
			{
				this.CFqjbzifsIitEfxZbAYHnpxFcmIhA[num2] = ((num & 128) != 0);
			}
			return;
		}
		this.DtGiaHLjKpYoutTajIKVTkaqgHLd = num;
	}

	// Token: 0x06000DDE RID: 3550 RVA: 0x0004280C File Offset: 0x00040A0C
	public unsafe void ZbKdoIacYmQNDwPhFGgmyRMVNzxk(IntPtr A_1)
	{
		UBsnuxCUybokyXlUwtANvFNCSPsO* ptr = (UBsnuxCUybokyXlUwtANvFNCSPsO*)((void*)A_1);
		this.lNdfrwpJMToOSMmoQAwNNaglQLzo = ptr->TvjboxIgCkoKujftAlRfIwKiJtiCb;
		this.zXXIApjNNhEfqYkwwvSitvmKGzyh = ptr->gQEYICMuvidTzhaiGDfmSaycwdmw;
		this.DtGiaHLjKpYoutTajIKVTkaqgHLd = ptr->jamJmdLDwZBjFzrpeFTSBSeMPxXCb;
		void* ptr2 = (void*)(&ptr->VCjGFGsczZaOTAhJkdIQpxBcgmcHA);
		bool[] array;
		bool* ptr3;
		if ((array = this.CFqjbzifsIitEfxZbAYHnpxFcmIhA) == null || array.Length == 0)
		{
			ptr3 = null;
		}
		else
		{
			ptr3 = &array[0];
		}
		for (int i = 0; i < 8; i++)
		{
			ptr3[i] = ((((byte*)ptr2)[i] & 128) > 0);
		}
		array = null;
	}

	// Token: 0x06000DDF RID: 3551 RVA: 0x00042890 File Offset: 0x00040A90
	public virtual string VxTfTRJUgWUbtCJMxlfaVCcEOkWfb()
	{
		return string.Format(CultureInfo.InvariantCulture, "X: {0}, Y: {1}, Z: {2}, Buttons: {3}", new object[]
		{
			this.lNdfrwpJMToOSMmoQAwNNaglQLzo,
			this.zXXIApjNNhEfqYkwwvSitvmKGzyh,
			this.DtGiaHLjKpYoutTajIKVTkaqgHLd,
			HtGHfzvtpMNSxwkJwcWlhmdnZCmfA.laIEOdATqftJyTsuGTSxMCOFMMUOA<bool>(";", this.CFqjbzifsIitEfxZbAYHnpxFcmIhA)
		});
	}

	// Token: 0x040028AA RID: 10410
	[CompilerGenerated]
	private int tvsMiVqbLgaszZueHIrIaffNneGIA;

	// Token: 0x040028AB RID: 10411
	[CompilerGenerated]
	private int reXlvwKQnCGUuzoFjyoxiNwaMaTc;

	// Token: 0x040028AC RID: 10412
	[CompilerGenerated]
	private int ioFVqnVzAGOzKzoiXjDhdRXvFTpc;

	// Token: 0x040028AD RID: 10413
	[CompilerGenerated]
	private bool[] fIkTygcIkjieaTPTlGAaGuVFOuhGb;
}
