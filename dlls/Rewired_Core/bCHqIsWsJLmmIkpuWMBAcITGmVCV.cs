using System;
using Rewired.Internal.Localization;
using Rewired.Utils.Classes.Data;

// Token: 0x02000453 RID: 1107
internal sealed class bCHqIsWsJLmmIkpuWMBAcITGmVCV : qRARPoZhenAEzvKQshZvLFcmqQCG, IDisposable
{
	// Token: 0x06002C44 RID: 11332 RVA: 0x00021F72 File Offset: 0x00020172
	public bCHqIsWsJLmmIkpuWMBAcITGmVCV(Action A_1)
	{
		this.eMRDSqgRUSfQVXZwpjggiqRCLbWYA = A_1;
		this.XkIpjYFPKLRHRYjKdSanpltAwJkE = 0U;
		LocalizationManager.Add(this, ref this.XkIpjYFPKLRHRYjKdSanpltAwJkE);
	}

	// Token: 0x06002C45 RID: 11333 RVA: 0x00021F99 File Offset: 0x00020199
	void qRARPoZhenAEzvKQshZvLFcmqQCG.Localize()
	{
		this.eMRDSqgRUSfQVXZwpjggiqRCLbWYA();
	}

	// Token: 0x06002C46 RID: 11334 RVA: 0x00021FA6 File Offset: 0x000201A6
	private void QAXXBDmIYUcSUbmsoLvVfAsqKiIy(bool A_1)
	{
		if (!this.sqBBuBxRuPOqqhvmfTxVDylZFNsk)
		{
			if (A_1)
			{
				LocalizationManager.Remove(ref this.XkIpjYFPKLRHRYjKdSanpltAwJkE);
			}
			this.sqBBuBxRuPOqqhvmfTxVDylZFNsk = true;
		}
	}

	// Token: 0x06002C47 RID: 11335 RVA: 0x00021FC6 File Offset: 0x000201C6
	public void Dispose()
	{
		this.QAXXBDmIYUcSUbmsoLvVfAsqKiIy(true);
		GC.SuppressFinalize(this);
	}

	// Token: 0x04001922 RID: 6434
	private Action eMRDSqgRUSfQVXZwpjggiqRCLbWYA;

	// Token: 0x04001923 RID: 6435
	private Id XkIpjYFPKLRHRYjKdSanpltAwJkE;

	// Token: 0x04001924 RID: 6436
	private bool sqBBuBxRuPOqqhvmfTxVDylZFNsk;
}
