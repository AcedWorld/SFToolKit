using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

// Token: 0x020001AB RID: 427
internal class cDpTWcNusFLSWAlNsDnzsIVunKNy
{
	// Token: 0x06000CEB RID: 3307 RVA: 0x00018C37 File Offset: 0x00016E37
	public cDpTWcNusFLSWAlNsDnzsIVunKNy()
	{
		this.FHBttApmyZvjLDauWXgYAtxiNCop = new cDpTWcNusFLSWAlNsDnzsIVunKNy.ZqWbQjWyoUuSmftRkoqSdSlvNaJd(cDpTWcNusFLSWAlNsDnzsIVunKNy.fuUAekikfaMLDvXKmKhQxlwYFWfeA);
		this.TsNWeYkRdJJeFgdsDqGHWgUlRrYA = Marshal.GetFunctionPointerForDelegate<cDpTWcNusFLSWAlNsDnzsIVunKNy.ZqWbQjWyoUuSmftRkoqSdSlvNaJd>(this.FHBttApmyZvjLDauWXgYAtxiNCop);
		this.WVJRSbrOPPgBHiMwSTOCPYEjNdBR = new List<kvqducHUWPYYsnUhPdQAbkdahByH>();
	}

	// Token: 0x1700022F RID: 559
	// (get) Token: 0x06000CEC RID: 3308 RVA: 0x00018C6D File Offset: 0x00016E6D
	public IntPtr kiCgfGgsHKbOrdUynftaxAuAfWgEA
	{
		get
		{
			return this.TsNWeYkRdJJeFgdsDqGHWgUlRrYA;
		}
	}

	// Token: 0x17000230 RID: 560
	// (get) Token: 0x06000CED RID: 3309 RVA: 0x00018C75 File Offset: 0x00016E75
	// (set) Token: 0x06000CEE RID: 3310 RVA: 0x00018C7D File Offset: 0x00016E7D
	public List<kvqducHUWPYYsnUhPdQAbkdahByH> WVJRSbrOPPgBHiMwSTOCPYEjNdBR { get; private set; }

	// Token: 0x06000CEF RID: 3311 RVA: 0x000408B8 File Offset: 0x0003EAB8
	[MonoPInvokeCallback(typeof(cDpTWcNusFLSWAlNsDnzsIVunKNy.ZqWbQjWyoUuSmftRkoqSdSlvNaJd))]
	private unsafe static int fuUAekikfaMLDvXKmKhQxlwYFWfeA(void* A_0, IntPtr A_1)
	{
		uint instanceId = (uint)A_1.ToInt32();
		cDpTWcNusFLSWAlNsDnzsIVunKNy cDpTWcNusFLSWAlNsDnzsIVunKNy;
		if (!ObjectInstanceTracker.Default.TryGetInstance<cDpTWcNusFLSWAlNsDnzsIVunKNy>(instanceId, out cDpTWcNusFLSWAlNsDnzsIVunKNy))
		{
			return 1;
		}
		kvqducHUWPYYsnUhPdQAbkdahByH kvqducHUWPYYsnUhPdQAbkdahByH = new kvqducHUWPYYsnUhPdQAbkdahByH();
		kvqducHUWPYYsnUhPdQAbkdahByH.mSFRSBXSEwSBdetUKjTbHfogRvwW(ref *(kvqducHUWPYYsnUhPdQAbkdahByH.lnAoBkZlUuabFyLoLiLMHCBdQCBSA*)A_0);
		cDpTWcNusFLSWAlNsDnzsIVunKNy.WVJRSbrOPPgBHiMwSTOCPYEjNdBR.Add(kvqducHUWPYYsnUhPdQAbkdahByH);
		return 1;
	}

	// Token: 0x04001DB1 RID: 7601
	private readonly IntPtr TsNWeYkRdJJeFgdsDqGHWgUlRrYA;

	// Token: 0x04001DB2 RID: 7602
	private readonly cDpTWcNusFLSWAlNsDnzsIVunKNy.ZqWbQjWyoUuSmftRkoqSdSlvNaJd FHBttApmyZvjLDauWXgYAtxiNCop;

	// Token: 0x04001DB3 RID: 7603
	[CompilerGenerated]
	private List<kvqducHUWPYYsnUhPdQAbkdahByH> goeijNRMqpcDXrWlVUhyNnPMzuqG;

	// Token: 0x020001AC RID: 428
	// (Invoke) Token: 0x06000CF1 RID: 3313
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int ZqWbQjWyoUuSmftRkoqSdSlvNaJd(void* deviceInstance, IntPtr data);
}
