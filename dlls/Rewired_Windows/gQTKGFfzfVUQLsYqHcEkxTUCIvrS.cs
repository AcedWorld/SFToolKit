using System;
using System.Globalization;
using System.Runtime.CompilerServices;

// Token: 0x02000139 RID: 313
internal class gQTKGFfzfVUQLsYqHcEkxTUCIvrS
{
	// Token: 0x06000B13 RID: 2835 RVA: 0x000114A8 File Offset: 0x0000F6A8
	public gQTKGFfzfVUQLsYqHcEkxTUCIvrS()
	{
	}

	// Token: 0x06000B14 RID: 2836 RVA: 0x00017CF7 File Offset: 0x00015EF7
	internal gQTKGFfzfVUQLsYqHcEkxTUCIvrS(ref yYIItTkYxskbKoqMJlNZSvZnYSID A_1, string A_2, IntPtr A_3)
	{
		this.uzgDNalfgciXaPcKRPJtKaHpJTwI = A_2;
		this.FPNtdqIgjPgShixBYYTbeadhfqot = A_3;
		this.RuxEkEzlavDvHcJlGGFACRZdoLCUb = A_1.yZGCAdpDvZcrslhApGgDBSsGYjLBA;
	}

	// Token: 0x170001D7 RID: 471
	// (get) Token: 0x06000B15 RID: 2837 RVA: 0x00017D19 File Offset: 0x00015F19
	// (set) Token: 0x06000B16 RID: 2838 RVA: 0x00017D21 File Offset: 0x00015F21
	public string uzgDNalfgciXaPcKRPJtKaHpJTwI { get; set; }

	// Token: 0x170001D8 RID: 472
	// (get) Token: 0x06000B17 RID: 2839 RVA: 0x00017D2A File Offset: 0x00015F2A
	// (set) Token: 0x06000B18 RID: 2840 RVA: 0x00017D32 File Offset: 0x00015F32
	public OiWGlufNbZAVpTSvEHgxGrekNlFFA RuxEkEzlavDvHcJlGGFACRZdoLCUb { get; set; }

	// Token: 0x170001D9 RID: 473
	// (get) Token: 0x06000B19 RID: 2841 RVA: 0x00017D3B File Offset: 0x00015F3B
	// (set) Token: 0x06000B1A RID: 2842 RVA: 0x00017D43 File Offset: 0x00015F43
	public IntPtr FPNtdqIgjPgShixBYYTbeadhfqot { get; set; }

	// Token: 0x06000B1B RID: 2843 RVA: 0x0003D4D4 File Offset: 0x0003B6D4
	internal static gQTKGFfzfVUQLsYqHcEkxTUCIvrS UtjBgWopYtIwNXNIkGgutPKfwYKj(ref yYIItTkYxskbKoqMJlNZSvZnYSID A_0, string A_1, IntPtr A_2)
	{
		gQTKGFfzfVUQLsYqHcEkxTUCIvrS result;
		switch (A_0.yZGCAdpDvZcrslhApGgDBSsGYjLBA)
		{
		case OiWGlufNbZAVpTSvEHgxGrekNlFFA.Mouse:
			result = new aNzuUZuKTFLYciJUamYUFGKFFgQ(ref A_0, A_1, A_2);
			break;
		case OiWGlufNbZAVpTSvEHgxGrekNlFFA.Keyboard:
			result = new urCBRkLKMtFPTeUQYRFuIHjSZjkmA(ref A_0, A_1, A_2);
			break;
		case OiWGlufNbZAVpTSvEHgxGrekNlFFA.HumanInputDevice:
			result = new wuOZnvOfTnpCqMaNXGiLcIupgKiG(ref A_0, A_1, A_2);
			break;
		default:
			throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Unsupported Device Type [{0}]", (int)A_0.yZGCAdpDvZcrslhApGgDBSsGYjLBA));
		}
		return result;
	}

	// Token: 0x04000981 RID: 2433
	[CompilerGenerated]
	private string mWliGITozSDhoJVypyBGewdxblhM;

	// Token: 0x04000982 RID: 2434
	[CompilerGenerated]
	private OiWGlufNbZAVpTSvEHgxGrekNlFFA VIqrVReDqEMVVarePHXLeDSXAhZIA;

	// Token: 0x04000983 RID: 2435
	[CompilerGenerated]
	private IntPtr kRcKDpUNGfObRoTlbRSHrXrHUuhI;
}
