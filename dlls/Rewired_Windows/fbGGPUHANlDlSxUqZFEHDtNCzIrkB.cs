using System;
using System.Runtime.CompilerServices;

// Token: 0x020000F9 RID: 249
internal abstract class fbGGPUHANlDlSxUqZFEHDtNCzIrkB : IDisposable
{
	// Token: 0x1400001B RID: 27
	// (add) Token: 0x060008B8 RID: 2232 RVA: 0x0003A404 File Offset: 0x00038604
	// (remove) Token: 0x060008B9 RID: 2233 RVA: 0x0003A43C File Offset: 0x0003863C
	public event EventHandler<EventArgs> lIEkovdguFluDjLulTbMvIWUYIxP;

	// Token: 0x1400001C RID: 28
	// (add) Token: 0x060008BA RID: 2234 RVA: 0x0003A474 File Offset: 0x00038674
	// (remove) Token: 0x060008BB RID: 2235 RVA: 0x0003A4AC File Offset: 0x000386AC
	public event EventHandler<EventArgs> qcTnZTsrOEVTnuGlnfblyMvctHTg;

	// Token: 0x060008BC RID: 2236 RVA: 0x0003A4E4 File Offset: 0x000386E4
	protected virtual void bljBKwShstSjJEdzwwdmdfSRcHDV()
	{
		try
		{
			this.OAUDmLuOrbCfiiBDABPaeDwqkXIQ(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	// Token: 0x1700019C RID: 412
	// (get) Token: 0x060008BD RID: 2237 RVA: 0x00016220 File Offset: 0x00014420
	// (set) Token: 0x060008BE RID: 2238 RVA: 0x00016228 File Offset: 0x00014428
	public bool vHJzkzWdQolOjEcNoiYAeLiMswyKA { get; private set; }

	// Token: 0x060008BF RID: 2239 RVA: 0x00016231 File Offset: 0x00014431
	public void Dispose()
	{
		this.OAUDmLuOrbCfiiBDABPaeDwqkXIQ(true);
	}

	// Token: 0x060008C0 RID: 2240 RVA: 0x0003A514 File Offset: 0x00038714
	private void OAUDmLuOrbCfiiBDABPaeDwqkXIQ(bool A_1)
	{
		if (!this.vHJzkzWdQolOjEcNoiYAeLiMswyKA)
		{
			EventHandler<EventArgs> eventHandler = this.lIEkovdguFluDjLulTbMvIWUYIxP;
			if (eventHandler != null)
			{
				eventHandler(this, EventArgs.Empty);
			}
			this.NYmvtFWuJoOFlWlVWOuhUInletDS(A_1);
			GC.SuppressFinalize(this);
			this.vHJzkzWdQolOjEcNoiYAeLiMswyKA = true;
			EventHandler<EventArgs> eventHandler2 = this.qcTnZTsrOEVTnuGlnfblyMvctHTg;
			if (eventHandler2 != null)
			{
				eventHandler2(this, EventArgs.Empty);
			}
		}
	}

	// Token: 0x060008C1 RID: 2241
	protected abstract void NYmvtFWuJoOFlWlVWOuhUInletDS(bool);

	// Token: 0x04000865 RID: 2149
	[CompilerGenerated]
	private bool KfAyBOTjZucRzksDjlQlmHAPLytMA;
}
