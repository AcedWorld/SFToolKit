using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;

// Token: 0x0200021B RID: 539
internal class PrHMQUkikdfDDgaeHcWNXdziixtgb : tFNOPzyrRPIZzozOnLxpVcObMonq<mRYGtqRYEKghjhYdeqJaXyHYUdGq, ALIdmGdkSEnDyGhCdijctsweZbRCc>
{
	// Token: 0x06000DBC RID: 3516 RVA: 0x000425FC File Offset: 0x000407FC
	static PrHMQUkikdfDDgaeHcWNXdziixtgb()
	{
		foreach (object obj in Enum.GetValues(typeof(sYJvyflcGbkmlQzIsrWtdzLSllNs)))
		{
			PrHMQUkikdfDDgaeHcWNXdziixtgb.bZwijMnkGQEQOnelPTBOLUxEwbvB.Add((sYJvyflcGbkmlQzIsrWtdzLSllNs)obj);
		}
	}

	// Token: 0x06000DBD RID: 3517 RVA: 0x000190E4 File Offset: 0x000172E4
	public PrHMQUkikdfDDgaeHcWNXdziixtgb()
	{
		this.kyPzEQkUNfBfTlmjQDWeCXMfjyfn = new List<sYJvyflcGbkmlQzIsrWtdzLSllNs>(16);
	}

	// Token: 0x17000261 RID: 609
	// (get) Token: 0x06000DBE RID: 3518 RVA: 0x000190F9 File Offset: 0x000172F9
	public List<sYJvyflcGbkmlQzIsrWtdzLSllNs> cCvKTGrUxeMQbrpWwJNUlFdhwXSi
	{
		get
		{
			return PrHMQUkikdfDDgaeHcWNXdziixtgb.bZwijMnkGQEQOnelPTBOLUxEwbvB;
		}
	}

	// Token: 0x17000262 RID: 610
	// (get) Token: 0x06000DBF RID: 3519 RVA: 0x00019100 File Offset: 0x00017300
	// (set) Token: 0x06000DC0 RID: 3520 RVA: 0x00019108 File Offset: 0x00017308
	public List<sYJvyflcGbkmlQzIsrWtdzLSllNs> kyPzEQkUNfBfTlmjQDWeCXMfjyfn { get; private set; }

	// Token: 0x06000DC1 RID: 3521 RVA: 0x00019111 File Offset: 0x00017311
	public bool gjjSSTyFaYxCOpNVUUOKMxGkHdDp(sYJvyflcGbkmlQzIsrWtdzLSllNs A_1)
	{
		return this.kyPzEQkUNfBfTlmjQDWeCXMfjyfn.Contains(A_1);
	}

	// Token: 0x06000DC2 RID: 3522 RVA: 0x00042674 File Offset: 0x00040874
	public void IJokkuyKvgICvgWyydqnQyYPdCV(ALIdmGdkSEnDyGhCdijctsweZbRCc A_1)
	{
		if (A_1.yHbpgNKUsWZoHLAKweImzhRnbKdS == sYJvyflcGbkmlQzIsrWtdzLSllNs.Unknown)
		{
			return;
		}
		bool flag = this.gjjSSTyFaYxCOpNVUUOKMxGkHdDp(A_1.yHbpgNKUsWZoHLAKweImzhRnbKdS);
		if (A_1.jjwwNfmRAYaXwNcRrCsmtfpVbwjd && !flag)
		{
			this.kyPzEQkUNfBfTlmjQDWeCXMfjyfn.Add(A_1.yHbpgNKUsWZoHLAKweImzhRnbKdS);
			return;
		}
		if (A_1.iIQbiFrIQzRzGgxKdluJaClAkDfi && flag)
		{
			this.kyPzEQkUNfBfTlmjQDWeCXMfjyfn.Remove(A_1.yHbpgNKUsWZoHLAKweImzhRnbKdS);
		}
	}

	// Token: 0x06000DC3 RID: 3523 RVA: 0x000426D8 File Offset: 0x000408D8
	public unsafe void VmwDCwkbXvzLfuUSTPEWuYbZwerO(IntPtr A_1)
	{
		this.kyPzEQkUNfBfTlmjQDWeCXMfjyfn.Clear();
		mRYGtqRYEKghjhYdeqJaXyHYUdGq* ptr = (mRYGtqRYEKghjhYdeqJaXyHYUdGq*)((void*)A_1);
		ALIdmGdkSEnDyGhCdijctsweZbRCc alidmGdkSEnDyGhCdijctsweZbRCc = default(ALIdmGdkSEnDyGhCdijctsweZbRCc);
		byte* ptr2 = &ptr->LRbUounubjFZzHYtdmSERxjtVUvc.gwNUfMvLEKQdXwieBKaYFkpxyNqD;
		for (int i = 0; i < 256; i++)
		{
			alidmGdkSEnDyGhCdijctsweZbRCc.SnUzQABiBeOZZBRPARxXVhYnJRlX = i;
			alidmGdkSEnDyGhCdijctsweZbRCc.QdBbtjtCKftAjyafBiPGXBlnCrZF = (int)ptr2[i];
			if (alidmGdkSEnDyGhCdijctsweZbRCc.jjwwNfmRAYaXwNcRrCsmtfpVbwjd)
			{
				this.kyPzEQkUNfBfTlmjQDWeCXMfjyfn.Add(alidmGdkSEnDyGhCdijctsweZbRCc.yHbpgNKUsWZoHLAKweImzhRnbKdS);
			}
		}
	}

	// Token: 0x06000DC4 RID: 3524 RVA: 0x0001911F File Offset: 0x0001731F
	public virtual string sYlTGKjUlPoGJuHEDwywPHyzXICC()
	{
		return string.Format(CultureInfo.InvariantCulture, "PressedKeys: {0}", HtGHfzvtpMNSxwkJwcWlhmdnZCmfA.CGGLiqYFwkkJLIdQtykVffayuzcN(",", this.kyPzEQkUNfBfTlmjQDWeCXMfjyfn));
	}

	// Token: 0x04002898 RID: 10392
	private static readonly List<sYJvyflcGbkmlQzIsrWtdzLSllNs> bZwijMnkGQEQOnelPTBOLUxEwbvB = new List<sYJvyflcGbkmlQzIsrWtdzLSllNs>(256);

	// Token: 0x04002899 RID: 10393
	[CompilerGenerated]
	private List<sYJvyflcGbkmlQzIsrWtdzLSllNs> IhAEPqBpCTGaUlSXXPjhqOxOCyNi;
}
