using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

// Token: 0x020001AD RID: 429
internal class CTIlNtmJLcQnPYueLkDmwdCAojpn
{
	// Token: 0x06000CF4 RID: 3316 RVA: 0x00018C86 File Offset: 0x00016E86
	public CTIlNtmJLcQnPYueLkDmwdCAojpn()
	{
		this.qdNAXUPMrliNUPnjwthOCzQuBzWv = new CTIlNtmJLcQnPYueLkDmwdCAojpn.RwxRpiRqQxpCKaJIRCfjkirIMrlx(CTIlNtmJLcQnPYueLkDmwdCAojpn.VaGYBAjdLTjJOdDyVlpaesfdopRmB);
		this.UPRtgcasBpOeUedAOxqkpzoRvwRR = Marshal.GetFunctionPointerForDelegate<CTIlNtmJLcQnPYueLkDmwdCAojpn.RwxRpiRqQxpCKaJIRCfjkirIMrlx>(this.qdNAXUPMrliNUPnjwthOCzQuBzWv);
		this.BXiqCDMlunwyoinFkKGQouqMGEmR = new List<mViiFnmtZlCheppPklKaMLRpdXpfA>();
	}

	// Token: 0x17000231 RID: 561
	// (get) Token: 0x06000CF5 RID: 3317 RVA: 0x00018CBC File Offset: 0x00016EBC
	public IntPtr ghCOxKtEfKtJqTmOMUEdLEBAsqcj
	{
		get
		{
			return this.UPRtgcasBpOeUedAOxqkpzoRvwRR;
		}
	}

	// Token: 0x17000232 RID: 562
	// (get) Token: 0x06000CF6 RID: 3318 RVA: 0x00018CC4 File Offset: 0x00016EC4
	// (set) Token: 0x06000CF7 RID: 3319 RVA: 0x00018CCC File Offset: 0x00016ECC
	public List<mViiFnmtZlCheppPklKaMLRpdXpfA> BXiqCDMlunwyoinFkKGQouqMGEmR { get; private set; }

	// Token: 0x06000CF8 RID: 3320 RVA: 0x000408F8 File Offset: 0x0003EAF8
	[MonoPInvokeCallback(typeof(CTIlNtmJLcQnPYueLkDmwdCAojpn.RwxRpiRqQxpCKaJIRCfjkirIMrlx))]
	private unsafe static int VaGYBAjdLTjJOdDyVlpaesfdopRmB(void* A_0, IntPtr A_1)
	{
		uint instanceId = (uint)A_1.ToInt32();
		CTIlNtmJLcQnPYueLkDmwdCAojpn ctilNtmJLcQnPYueLkDmwdCAojpn;
		if (!ObjectInstanceTracker.Default.TryGetInstance<CTIlNtmJLcQnPYueLkDmwdCAojpn>(instanceId, out ctilNtmJLcQnPYueLkDmwdCAojpn))
		{
			return 1;
		}
		mViiFnmtZlCheppPklKaMLRpdXpfA mViiFnmtZlCheppPklKaMLRpdXpfA = new mViiFnmtZlCheppPklKaMLRpdXpfA();
		mViiFnmtZlCheppPklKaMLRpdXpfA.DsGeKZGWljaQdJCPmkdswHiVKhscA(ref *(mViiFnmtZlCheppPklKaMLRpdXpfA.nXMwUNLqShMwwnZxqoVYYTEKuUiI*)A_0);
		ctilNtmJLcQnPYueLkDmwdCAojpn.BXiqCDMlunwyoinFkKGQouqMGEmR.Add(mViiFnmtZlCheppPklKaMLRpdXpfA);
		return 1;
	}

	// Token: 0x04001DB4 RID: 7604
	private readonly IntPtr UPRtgcasBpOeUedAOxqkpzoRvwRR;

	// Token: 0x04001DB5 RID: 7605
	private readonly CTIlNtmJLcQnPYueLkDmwdCAojpn.RwxRpiRqQxpCKaJIRCfjkirIMrlx qdNAXUPMrliNUPnjwthOCzQuBzWv;

	// Token: 0x04001DB6 RID: 7606
	[CompilerGenerated]
	private List<mViiFnmtZlCheppPklKaMLRpdXpfA> WzTWLstmunjjySFduhJWkUVIdaKC;

	// Token: 0x020001AE RID: 430
	// (Invoke) Token: 0x06000CFA RID: 3322
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int RwxRpiRqQxpCKaJIRCfjkirIMrlx(void* deviceInstance, IntPtr data);
}
