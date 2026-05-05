using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

// Token: 0x020001B1 RID: 433
internal class dzGBEheidwiLxDJyFfTVCkQkPpjqc
{
	// Token: 0x06000D06 RID: 3334 RVA: 0x00018D24 File Offset: 0x00016F24
	public dzGBEheidwiLxDJyFfTVCkQkPpjqc()
	{
		this.HuPKVMUQyXBuwWiiNNetfatJsTkW = new dzGBEheidwiLxDJyFfTVCkQkPpjqc.hcSwldUyNPWJDsOHHWojTXNUVeyk(dzGBEheidwiLxDJyFfTVCkQkPpjqc.jJkQMIboHpLdnDyqPwWjFZZTTydJ);
		this.tjLCDCbchTaUVLMOCJiChweHBEiLA = Marshal.GetFunctionPointerForDelegate<dzGBEheidwiLxDJyFfTVCkQkPpjqc.hcSwldUyNPWJDsOHHWojTXNUVeyk>(this.HuPKVMUQyXBuwWiiNNetfatJsTkW);
		this.KhMWVqsBQyGdXIkXWiHrrgdgpJrE = new List<LyiAUWWzjPRwFcxvPTEgvdJUSkUA>();
	}

	// Token: 0x17000235 RID: 565
	// (get) Token: 0x06000D07 RID: 3335 RVA: 0x00018D5A File Offset: 0x00016F5A
	public IntPtr nvHushYzDUmiKmOHRFnHojfVgiVJA
	{
		get
		{
			return this.tjLCDCbchTaUVLMOCJiChweHBEiLA;
		}
	}

	// Token: 0x17000236 RID: 566
	// (get) Token: 0x06000D08 RID: 3336 RVA: 0x00018D62 File Offset: 0x00016F62
	// (set) Token: 0x06000D09 RID: 3337 RVA: 0x00018D6A File Offset: 0x00016F6A
	public List<LyiAUWWzjPRwFcxvPTEgvdJUSkUA> KhMWVqsBQyGdXIkXWiHrrgdgpJrE { get; private set; }

	// Token: 0x06000D0A RID: 3338 RVA: 0x00040978 File Offset: 0x0003EB78
	[MonoPInvokeCallback(typeof(dzGBEheidwiLxDJyFfTVCkQkPpjqc.hcSwldUyNPWJDsOHHWojTXNUVeyk))]
	private unsafe static int jJkQMIboHpLdnDyqPwWjFZZTTydJ(void* A_0, IntPtr A_1)
	{
		uint instanceId = (uint)A_1.ToInt32();
		dzGBEheidwiLxDJyFfTVCkQkPpjqc dzGBEheidwiLxDJyFfTVCkQkPpjqc;
		if (!ObjectInstanceTracker.Default.TryGetInstance<dzGBEheidwiLxDJyFfTVCkQkPpjqc>(instanceId, out dzGBEheidwiLxDJyFfTVCkQkPpjqc))
		{
			return 1;
		}
		LyiAUWWzjPRwFcxvPTEgvdJUSkUA lyiAUWWzjPRwFcxvPTEgvdJUSkUA = new LyiAUWWzjPRwFcxvPTEgvdJUSkUA();
		lyiAUWWzjPRwFcxvPTEgvdJUSkUA.UGFedGOBLhsetcuRzXBmjfEXFQOy(ref *(LyiAUWWzjPRwFcxvPTEgvdJUSkUA.iNlpvVJPVMgEyeRAEycJVVTRwbkh*)A_0);
		dzGBEheidwiLxDJyFfTVCkQkPpjqc.KhMWVqsBQyGdXIkXWiHrrgdgpJrE.Add(lyiAUWWzjPRwFcxvPTEgvdJUSkUA);
		return 1;
	}

	// Token: 0x04001DBA RID: 7610
	private readonly IntPtr tjLCDCbchTaUVLMOCJiChweHBEiLA;

	// Token: 0x04001DBB RID: 7611
	private readonly dzGBEheidwiLxDJyFfTVCkQkPpjqc.hcSwldUyNPWJDsOHHWojTXNUVeyk HuPKVMUQyXBuwWiiNNetfatJsTkW;

	// Token: 0x04001DBC RID: 7612
	[CompilerGenerated]
	private List<LyiAUWWzjPRwFcxvPTEgvdJUSkUA> QTogYoeWQSbpJpQmDIWztOnPLaFjA;

	// Token: 0x020001B2 RID: 434
	// (Invoke) Token: 0x06000D0C RID: 3340
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int hcSwldUyNPWJDsOHHWojTXNUVeyk(void* deviceInstance, IntPtr data);
}
