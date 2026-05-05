using System;
using Rewired.Internal;
using Rewired.Internal.Glyphs;
using Rewired.Utils.Classes.Data;

// Token: 0x0200046D RID: 1133
internal sealed class dsuEdngwoNruBIzguTitTUraCkOc : IPrefetch, IDisposable
{
	// Token: 0x06002D24 RID: 11556 RVA: 0x00022B6C File Offset: 0x00020D6C
	public dsuEdngwoNruBIzguTitTUraCkOc(Action A_1)
	{
		this.GANNpsFogeKNAxnUYOTMivNlVXaJ = A_1;
		this.aqZbMIQwUKcAlxMLsqLnlczLcfO = 0U;
		GlyphManager.Add(this, ref this.aqZbMIQwUKcAlxMLsqLnlczLcfO);
	}

	// Token: 0x06002D25 RID: 11557 RVA: 0x00022B93 File Offset: 0x00020D93
	void IPrefetch.Prefetch()
	{
		this.GANNpsFogeKNAxnUYOTMivNlVXaJ();
	}

	// Token: 0x06002D26 RID: 11558 RVA: 0x00022BA0 File Offset: 0x00020DA0
	private void SegKWYpdmIlDTzlXfoYtFtqvLnas(bool A_1)
	{
		if (!this.FPkkGKJTyjLDOXYvdsfCEDXXVkie)
		{
			if (A_1)
			{
				GlyphManager.Remove(ref this.aqZbMIQwUKcAlxMLsqLnlczLcfO);
			}
			this.FPkkGKJTyjLDOXYvdsfCEDXXVkie = true;
		}
	}

	// Token: 0x06002D27 RID: 11559 RVA: 0x00022BC0 File Offset: 0x00020DC0
	public void Dispose()
	{
		this.SegKWYpdmIlDTzlXfoYtFtqvLnas(true);
		GC.SuppressFinalize(this);
	}

	// Token: 0x0400196D RID: 6509
	private Action GANNpsFogeKNAxnUYOTMivNlVXaJ;

	// Token: 0x0400196E RID: 6510
	private Id aqZbMIQwUKcAlxMLsqLnlczLcfO;

	// Token: 0x0400196F RID: 6511
	private bool FPkkGKJTyjLDOXYvdsfCEDXXVkie;
}
