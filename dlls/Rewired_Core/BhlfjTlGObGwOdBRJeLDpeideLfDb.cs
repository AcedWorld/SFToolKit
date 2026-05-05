using System;
using Rewired;
using Rewired.Platforms.Custom;

// Token: 0x0200023D RID: 573
internal abstract class BhlfjTlGObGwOdBRJeLDpeideLfDb : IDisposable
{
	// Token: 0x06001A35 RID: 6709 RVA: 0x0001562B File Offset: 0x0001382B
	public BhlfjTlGObGwOdBRJeLDpeideLfDb(CustomPlatformUnifiedControllerSource A_1, HardwareControllerMap_Game A_2)
	{
		this.SMfjVbxMEJEZMpylRcGtwXfQinVT = A_1;
		this.CddHHvRIygdVLWJbWuLMuXPRABAO = A_2;
	}

	// Token: 0x17000653 RID: 1619
	// (get) Token: 0x06001A36 RID: 6710 RVA: 0x00015641 File Offset: 0x00013841
	public InputSource MjIfIlICOXSVyGBfYkqLGFPFKPdQb
	{
		get
		{
			return InputSource.Custom;
		}
	}

	// Token: 0x17000654 RID: 1620
	// (get) Token: 0x06001A37 RID: 6711 RVA: 0x00015645 File Offset: 0x00013845
	public HardwareControllerMap_Game WeLVInsBNRjBVivjcwoGhoYlRbYW
	{
		get
		{
			return this.CddHHvRIygdVLWJbWuLMuXPRABAO;
		}
	}

	// Token: 0x17000655 RID: 1621
	// (get) Token: 0x06001A38 RID: 6712 RVA: 0x0001564D File Offset: 0x0001384D
	public int wBpjKuUtgKHhQcffmlqBphwSOBpHb
	{
		get
		{
			return this.SMfjVbxMEJEZMpylRcGtwXfQinVT.axisCount;
		}
	}

	// Token: 0x17000656 RID: 1622
	// (get) Token: 0x06001A39 RID: 6713 RVA: 0x0001565A File Offset: 0x0001385A
	public int MxpPIsvImsLodyVaohDrpiaOgQAd
	{
		get
		{
			return this.SMfjVbxMEJEZMpylRcGtwXfQinVT.buttonCount;
		}
	}

	// Token: 0x17000657 RID: 1623
	// (get) Token: 0x06001A3A RID: 6714 RVA: 0x00015667 File Offset: 0x00013867
	public Controller.Extension ToriJHeDQpmRcIDoKlSbfGSyvlMb
	{
		get
		{
			return this.SMfjVbxMEJEZMpylRcGtwXfQinVT.controllerExtension;
		}
	}

	// Token: 0x06001A3B RID: 6715 RVA: 0x00015674 File Offset: 0x00013874
	public void Clear()
	{
		this.SMfjVbxMEJEZMpylRcGtwXfQinVT.qoqWwYtbzmvNYDwKOzCDSSNJRJvg();
	}

	// Token: 0x06001A3C RID: 6716 RVA: 0x00015681 File Offset: 0x00013881
	public void UpdateInputData(ControllerDataUpdater dataUpdater)
	{
		this.SMfjVbxMEJEZMpylRcGtwXfQinVT.DiokwKRKPsufUdtRbXpjKgStBxli(dataUpdater);
	}

	// Token: 0x06001A3D RID: 6717 RVA: 0x0001568F File Offset: 0x0001388F
	public void jzakiAASggtqZIjGFuGTPlrIDHnkA()
	{
		this.SMfjVbxMEJEZMpylRcGtwXfQinVT.luUCqwDxiPWMUkHqPIkyHphHcmjj();
	}

	// Token: 0x06001A3E RID: 6718 RVA: 0x0001569C File Offset: 0x0001389C
	protected virtual void ZpLZrvuZQEqJBUjkIteMDxgszqhJ(bool A_1)
	{
		if (!this.WVgWPHLIowhZsyHPgAeZXQbfClIAA)
		{
			if (A_1 && this.SMfjVbxMEJEZMpylRcGtwXfQinVT != null)
			{
				((IDisposable)this.SMfjVbxMEJEZMpylRcGtwXfQinVT).Dispose();
			}
			this.WVgWPHLIowhZsyHPgAeZXQbfClIAA = true;
		}
	}

	// Token: 0x06001A3F RID: 6719 RVA: 0x000156C3 File Offset: 0x000138C3
	void IDisposable.Dispose()
	{
		this.ZpLZrvuZQEqJBUjkIteMDxgszqhJ(true);
		GC.SuppressFinalize(this);
	}

	// Token: 0x04000ED5 RID: 3797
	protected readonly CustomPlatformUnifiedControllerSource SMfjVbxMEJEZMpylRcGtwXfQinVT;

	// Token: 0x04000ED6 RID: 3798
	private readonly HardwareControllerMap_Game CddHHvRIygdVLWJbWuLMuXPRABAO;

	// Token: 0x04000ED7 RID: 3799
	private bool XSRblsKwDVSeefWXiqnFWTIGFTldb;

	// Token: 0x04000ED8 RID: 3800
	private bool WVgWPHLIowhZsyHPgAeZXQbfClIAA;
}
