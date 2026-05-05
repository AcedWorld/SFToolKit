using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

// Token: 0x020001A9 RID: 425
internal class raYdnDSSGIdEehNSIAxsvjkCvjjt
{
	// Token: 0x06000CE2 RID: 3298 RVA: 0x00018BE8 File Offset: 0x00016DE8
	public raYdnDSSGIdEehNSIAxsvjkCvjjt()
	{
		this.pCoRsLplcCJkYYWRspSNfWOABkVi = new raYdnDSSGIdEehNSIAxsvjkCvjjt.ggrCjveuXwQUkcePGZUiIUusLoKh(raYdnDSSGIdEehNSIAxsvjkCvjjt.ErJsxkAGKMhcwwufgxJZQSStQwAJ);
		this.nhrAMUbZWVHvykhMaSKBKqmGFAMkA = Marshal.GetFunctionPointerForDelegate<raYdnDSSGIdEehNSIAxsvjkCvjjt.ggrCjveuXwQUkcePGZUiIUusLoKh>(this.pCoRsLplcCJkYYWRspSNfWOABkVi);
		this.qeViyPyBnpKHeEfUoMwumAcQeXsS = new List<aFwZgiMsIVKisUSxzPdssbKbhERK>();
	}

	// Token: 0x1700022D RID: 557
	// (get) Token: 0x06000CE3 RID: 3299 RVA: 0x00018C1E File Offset: 0x00016E1E
	public IntPtr TvEtzLkalLkWuOcXLRNPMILqdDveA
	{
		get
		{
			return this.nhrAMUbZWVHvykhMaSKBKqmGFAMkA;
		}
	}

	// Token: 0x1700022E RID: 558
	// (get) Token: 0x06000CE4 RID: 3300 RVA: 0x00018C26 File Offset: 0x00016E26
	// (set) Token: 0x06000CE5 RID: 3301 RVA: 0x00018C2E File Offset: 0x00016E2E
	public List<aFwZgiMsIVKisUSxzPdssbKbhERK> qeViyPyBnpKHeEfUoMwumAcQeXsS { get; private set; }

	// Token: 0x06000CE6 RID: 3302 RVA: 0x00040878 File Offset: 0x0003EA78
	[MonoPInvokeCallback(typeof(raYdnDSSGIdEehNSIAxsvjkCvjjt.ggrCjveuXwQUkcePGZUiIUusLoKh))]
	private unsafe static int ErJsxkAGKMhcwwufgxJZQSStQwAJ(void* A_0, IntPtr A_1)
	{
		uint instanceId = (uint)A_1.ToInt32();
		raYdnDSSGIdEehNSIAxsvjkCvjjt raYdnDSSGIdEehNSIAxsvjkCvjjt;
		if (!ObjectInstanceTracker.Default.TryGetInstance<raYdnDSSGIdEehNSIAxsvjkCvjjt>(instanceId, out raYdnDSSGIdEehNSIAxsvjkCvjjt))
		{
			return 1;
		}
		aFwZgiMsIVKisUSxzPdssbKbhERK item = new aFwZgiMsIVKisUSxzPdssbKbhERK((IntPtr)A_0);
		raYdnDSSGIdEehNSIAxsvjkCvjjt.qeViyPyBnpKHeEfUoMwumAcQeXsS.Add(item);
		return 1;
	}

	// Token: 0x04001DAE RID: 7598
	private readonly IntPtr nhrAMUbZWVHvykhMaSKBKqmGFAMkA;

	// Token: 0x04001DAF RID: 7599
	private readonly raYdnDSSGIdEehNSIAxsvjkCvjjt.ggrCjveuXwQUkcePGZUiIUusLoKh pCoRsLplcCJkYYWRspSNfWOABkVi;

	// Token: 0x04001DB0 RID: 7600
	[CompilerGenerated]
	private List<aFwZgiMsIVKisUSxzPdssbKbhERK> oXrBEPAvtVcHttxBuAoVdMJEMgCYA;

	// Token: 0x020001AA RID: 426
	// (Invoke) Token: 0x06000CE8 RID: 3304
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int ggrCjveuXwQUkcePGZUiIUusLoKh(void* deviceInstance, IntPtr data);
}
