using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

// Token: 0x020001AF RID: 431
internal class qjOlQPQPBkoCTKMpwNFJznTgRTuU
{
	// Token: 0x06000CFD RID: 3325 RVA: 0x00018CD5 File Offset: 0x00016ED5
	public qjOlQPQPBkoCTKMpwNFJznTgRTuU()
	{
		this.hgujTceOxqQjYtTYafXmYPyqDLSP = new qjOlQPQPBkoCTKMpwNFJznTgRTuU.sIVpFFAJdGKOygAWFyNleEIPFfpI(qjOlQPQPBkoCTKMpwNFJznTgRTuU.TzQivNVSsiPpLSIcmLzOmEVDGixj);
		this.wFrcrxIiQitKjhHMCikWpAkusKFUA = Marshal.GetFunctionPointerForDelegate<qjOlQPQPBkoCTKMpwNFJznTgRTuU.sIVpFFAJdGKOygAWFyNleEIPFfpI>(this.hgujTceOxqQjYtTYafXmYPyqDLSP);
		this.waOgsciPqCPnFIWkaPGgFttOVYMHb = new List<jmOvgZjEMNEpmRYockwMSlOYcUzr>();
	}

	// Token: 0x17000233 RID: 563
	// (get) Token: 0x06000CFE RID: 3326 RVA: 0x00018D0B File Offset: 0x00016F0B
	public IntPtr NAWFpwtMQzcbuYHihQCzXUlyMVFx
	{
		get
		{
			return this.wFrcrxIiQitKjhHMCikWpAkusKFUA;
		}
	}

	// Token: 0x17000234 RID: 564
	// (get) Token: 0x06000CFF RID: 3327 RVA: 0x00018D13 File Offset: 0x00016F13
	// (set) Token: 0x06000D00 RID: 3328 RVA: 0x00018D1B File Offset: 0x00016F1B
	public List<jmOvgZjEMNEpmRYockwMSlOYcUzr> waOgsciPqCPnFIWkaPGgFttOVYMHb { get; private set; }

	// Token: 0x06000D01 RID: 3329 RVA: 0x00040938 File Offset: 0x0003EB38
	[MonoPInvokeCallback(typeof(qjOlQPQPBkoCTKMpwNFJznTgRTuU.sIVpFFAJdGKOygAWFyNleEIPFfpI))]
	private unsafe static int TzQivNVSsiPpLSIcmLzOmEVDGixj(void* A_0, IntPtr A_1)
	{
		uint instanceId = (uint)A_1.ToInt32();
		qjOlQPQPBkoCTKMpwNFJznTgRTuU qjOlQPQPBkoCTKMpwNFJznTgRTuU;
		if (!ObjectInstanceTracker.Default.TryGetInstance<qjOlQPQPBkoCTKMpwNFJznTgRTuU>(instanceId, out qjOlQPQPBkoCTKMpwNFJznTgRTuU))
		{
			return 1;
		}
		jmOvgZjEMNEpmRYockwMSlOYcUzr jmOvgZjEMNEpmRYockwMSlOYcUzr = new jmOvgZjEMNEpmRYockwMSlOYcUzr();
		jmOvgZjEMNEpmRYockwMSlOYcUzr.TgoAJyUruDFtwkfNtBdRLFFeEpEe(ref *(jmOvgZjEMNEpmRYockwMSlOYcUzr.PBwCbFwHmZApWfShTiDWgvTHIVhmB*)A_0);
		qjOlQPQPBkoCTKMpwNFJznTgRTuU.waOgsciPqCPnFIWkaPGgFttOVYMHb.Add(jmOvgZjEMNEpmRYockwMSlOYcUzr);
		return 1;
	}

	// Token: 0x04001DB7 RID: 7607
	private readonly IntPtr wFrcrxIiQitKjhHMCikWpAkusKFUA;

	// Token: 0x04001DB8 RID: 7608
	private readonly qjOlQPQPBkoCTKMpwNFJznTgRTuU.sIVpFFAJdGKOygAWFyNleEIPFfpI hgujTceOxqQjYtTYafXmYPyqDLSP;

	// Token: 0x04001DB9 RID: 7609
	[CompilerGenerated]
	private List<jmOvgZjEMNEpmRYockwMSlOYcUzr> sysgDHHIStpqtJIdDlidZEfnJPLA;

	// Token: 0x020001B0 RID: 432
	// (Invoke) Token: 0x06000D03 RID: 3331
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int sIVpFFAJdGKOygAWFyNleEIPFfpI(void* deviceInstance, IntPtr data);
}
