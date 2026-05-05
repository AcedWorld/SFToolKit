using System;
using System.Globalization;
using System.Runtime.InteropServices;

// Token: 0x0200019B RID: 411
[StructLayout(LayoutKind.Sequential, Size = 4)]
internal struct BFoLdVmrAcpkpmLKBEeXUokPDnBW
{
	// Token: 0x06000C51 RID: 3153 RVA: 0x000186E9 File Offset: 0x000168E9
	public BFoLdVmrAcpkpmLKBEeXUokPDnBW(rmFZIqnOsqENbRWsSmclbFIafHVW A_1, int A_2)
	{
		this = default(BFoLdVmrAcpkpmLKBEeXUokPDnBW);
		this.zDTDArMzMkTsEjyNmXhwXRgeHpFC = (int)((A_1 & ~rmFZIqnOsqENbRWsSmclbFIafHVW.AnyInstance) | (rmFZIqnOsqENbRWsSmclbFIafHVW)((A_2 < 0 | A_2 > 65534) ? 0 : ((A_2 & 65535) << 8)));
	}

	// Token: 0x1700020F RID: 527
	// (get) Token: 0x06000C52 RID: 3154 RVA: 0x0001871B File Offset: 0x0001691B
	public rmFZIqnOsqENbRWsSmclbFIafHVW lbKBezcrYXWyPWPaNBDYahtKBlXB
	{
		get
		{
			return (rmFZIqnOsqENbRWsSmclbFIafHVW)(this.zDTDArMzMkTsEjyNmXhwXRgeHpFC & -16776961);
		}
	}

	// Token: 0x17000210 RID: 528
	// (get) Token: 0x06000C53 RID: 3155 RVA: 0x00018729 File Offset: 0x00016929
	public int rbhDNaXwARcgKsrNUzmlwNuLPZbn
	{
		get
		{
			return this.zDTDArMzMkTsEjyNmXhwXRgeHpFC >> 8 & 65535;
		}
	}

	// Token: 0x06000C54 RID: 3156 RVA: 0x00018739 File Offset: 0x00016939
	public static int dwYEvrkrwkWJmxxrHuvmOKSWfUHc(BFoLdVmrAcpkpmLKBEeXUokPDnBW A_0)
	{
		return A_0.zDTDArMzMkTsEjyNmXhwXRgeHpFC;
	}

	// Token: 0x06000C55 RID: 3157 RVA: 0x00018741 File Offset: 0x00016941
	public bool jcfNMGzJmtAknexpUtGkhTSEvCVWA(BFoLdVmrAcpkpmLKBEeXUokPDnBW A_1)
	{
		return A_1.zDTDArMzMkTsEjyNmXhwXRgeHpFC == this.zDTDArMzMkTsEjyNmXhwXRgeHpFC;
	}

	// Token: 0x06000C56 RID: 3158 RVA: 0x00018751 File Offset: 0x00016951
	public bool dFHoJROpYeISrTfGMHkQFZIQFlED(object A_1)
	{
		return A_1 != null && !(A_1.GetType() != typeof(BFoLdVmrAcpkpmLKBEeXUokPDnBW)) && this.jcfNMGzJmtAknexpUtGkhTSEvCVWA((BFoLdVmrAcpkpmLKBEeXUokPDnBW)A_1);
	}

	// Token: 0x06000C57 RID: 3159 RVA: 0x00018739 File Offset: 0x00016939
	public int tmpQhSmFFGMCFNIOBRdnaywLJVio()
	{
		return this.zDTDArMzMkTsEjyNmXhwXRgeHpFC;
	}

	// Token: 0x06000C58 RID: 3160 RVA: 0x0001877D File Offset: 0x0001697D
	public string xHUzMewKhRnfYQnvQDMSAyNGApxT()
	{
		return string.Format(CultureInfo.InvariantCulture, "Flags: {0} InstanceNumber: {1} RawId: 0x{2:X8}", this.lbKBezcrYXWyPWPaNBDYahtKBlXB, this.rbhDNaXwARcgKsrNUzmlwNuLPZbn, this.zDTDArMzMkTsEjyNmXhwXRgeHpFC);
	}

	// Token: 0x04001A4C RID: 6732
	private int zDTDArMzMkTsEjyNmXhwXRgeHpFC;

	// Token: 0x04001A4D RID: 6733
	private const int uCOkmaCtLzzRfJUdsIZqVbewagIJA = 65534;

	// Token: 0x04001A4E RID: 6734
	private const int NWNeUGQQQNruuyQWyAHqFcgpSRYo = 16776960;
}
