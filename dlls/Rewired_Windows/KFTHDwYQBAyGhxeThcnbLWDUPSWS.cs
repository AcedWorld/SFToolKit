using System;
using System.Runtime.InteropServices;

// Token: 0x020000E8 RID: 232
internal class KFTHDwYQBAyGhxeThcnbLWDUPSWS<\u0001> : IDisposable where \u0001 : struct
{
	// Token: 0x17000192 RID: 402
	// (get) Token: 0x06000844 RID: 2116 RVA: 0x00015DBD File Offset: 0x00013FBD
	public rldBWJiPNwVWNAQGlSaZBtbmtjRwA UliKysXbcfYzEqXzsMIKufJRBCajA
	{
		get
		{
			return this.jUaZieNeRzMWpCroWFGJWBXNCnGfA;
		}
	}

	// Token: 0x17000193 RID: 403
	// (get) Token: 0x06000845 RID: 2117 RVA: 0x00015DC5 File Offset: 0x00013FC5
	public bool cYCVFYkAXpFNBIuOxxcyWVwJdIIO
	{
		get
		{
			return this.jUaZieNeRzMWpCroWFGJWBXNCnGfA != null && this.jUaZieNeRzMWpCroWFGJWBXNCnGfA.pTqePlWfDkrAVqwmLmietZbIwjOh != IntPtr.Zero;
		}
	}

	// Token: 0x17000194 RID: 404
	// (get) Token: 0x06000846 RID: 2118 RVA: 0x00015DE6 File Offset: 0x00013FE6
	// (set) Token: 0x06000847 RID: 2119 RVA: 0x00039758 File Offset: 0x00037958
	public unsafe \u0001 yhGPmgDenGPRTCkELQiifieEdkHq
	{
		get
		{
			this.HkJoRajJAcpEiCVkGNzfdQKUNVDX();
			return *(\u0001*)((void*)this.jUaZieNeRzMWpCroWFGJWBXNCnGfA.pTqePlWfDkrAVqwmLmietZbIwjOh);
		}
		set
		{
			this.HkJoRajJAcpEiCVkGNzfdQKUNVDX();
			\u0001* value2 = &value;
			this.jUaZieNeRzMWpCroWFGJWBXNCnGfA.ILqeDelcJbOjLKHzWCRsxUoLtXdc((IntPtr)((void*)value2), KFTHDwYQBAyGhxeThcnbLWDUPSWS<\u0001>.TaLNHxPKIYDFrpMpYHPKeymajIyA, KFTHDwYQBAyGhxeThcnbLWDUPSWS<\u0001>.TaLNHxPKIYDFrpMpYHPKeymajIyA, 0, 0);
		}
	}

	// Token: 0x06000848 RID: 2120 RVA: 0x00015E03 File Offset: 0x00014003
	public KFTHDwYQBAyGhxeThcnbLWDUPSWS()
	{
		this.jUaZieNeRzMWpCroWFGJWBXNCnGfA = new rldBWJiPNwVWNAQGlSaZBtbmtjRwA(KFTHDwYQBAyGhxeThcnbLWDUPSWS<\u0001>.TaLNHxPKIYDFrpMpYHPKeymajIyA);
	}

	// Token: 0x06000849 RID: 2121 RVA: 0x00015E1B File Offset: 0x0001401B
	private void XTYlltBhgcZmWDGUgCrmMjHZycfk()
	{
		if (this.jUaZieNeRzMWpCroWFGJWBXNCnGfA == null)
		{
			this.jUaZieNeRzMWpCroWFGJWBXNCnGfA.Dispose();
			this.jUaZieNeRzMWpCroWFGJWBXNCnGfA = null;
		}
	}

	// Token: 0x0600084A RID: 2122 RVA: 0x00015E37 File Offset: 0x00014037
	private void HkJoRajJAcpEiCVkGNzfdQKUNVDX()
	{
		if (!this.cYCVFYkAXpFNBIuOxxcyWVwJdIIO)
		{
			throw new Exception("Memory not allocated.");
		}
	}

	// Token: 0x0600084B RID: 2123 RVA: 0x00015E4C File Offset: 0x0001404C
	private void rRjXxhecYEMoFxeugJaiPLecBhly(bool A_1)
	{
		if (!this.QPorePTGMyRZcDhOkRUttKwDuYoG)
		{
			if (A_1)
			{
				this.XTYlltBhgcZmWDGUgCrmMjHZycfk();
			}
			this.QPorePTGMyRZcDhOkRUttKwDuYoG = true;
		}
	}

	// Token: 0x0600084C RID: 2124 RVA: 0x00015E66 File Offset: 0x00014066
	public void Dispose()
	{
		this.rRjXxhecYEMoFxeugJaiPLecBhly(true);
		GC.SuppressFinalize(this);
	}

	// Token: 0x04000850 RID: 2128
	private static readonly int TaLNHxPKIYDFrpMpYHPKeymajIyA = Marshal.SizeOf(typeof(\u0001));

	// Token: 0x04000851 RID: 2129
	private rldBWJiPNwVWNAQGlSaZBtbmtjRwA jUaZieNeRzMWpCroWFGJWBXNCnGfA;

	// Token: 0x04000852 RID: 2130
	private bool QPorePTGMyRZcDhOkRUttKwDuYoG;
}
