using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

// Token: 0x02000159 RID: 345
internal class IACtPnxQBtPGwZjFdnDWTKLCTFol
{
	// Token: 0x06000B57 RID: 2903 RVA: 0x00017EB2 File Offset: 0x000160B2
	public IACtPnxQBtPGwZjFdnDWTKLCTFol(DateTime A_1, ttVRlsKWObTjefpmeeKUvTYTQZRU A_2, string A_3)
	{
		this.NEOvxxVJqmQbEWthZSCSNpvZDjvQ = A_1;
		this.QtRnmVzmpDUoUKwsQMCxGMPokbvw = new WeakReference(A_2, true);
		this.APtdZVINrxrWuEKglbAnbOKIRRM = A_3;
	}

	// Token: 0x170001ED RID: 493
	// (get) Token: 0x06000B58 RID: 2904 RVA: 0x00017ED5 File Offset: 0x000160D5
	// (set) Token: 0x06000B59 RID: 2905 RVA: 0x00017EDD File Offset: 0x000160DD
	public DateTime NEOvxxVJqmQbEWthZSCSNpvZDjvQ { get; private set; }

	// Token: 0x170001EE RID: 494
	// (get) Token: 0x06000B5A RID: 2906 RVA: 0x00017EE6 File Offset: 0x000160E6
	// (set) Token: 0x06000B5B RID: 2907 RVA: 0x00017EEE File Offset: 0x000160EE
	public WeakReference QtRnmVzmpDUoUKwsQMCxGMPokbvw { get; private set; }

	// Token: 0x170001EF RID: 495
	// (get) Token: 0x06000B5C RID: 2908 RVA: 0x00017EF7 File Offset: 0x000160F7
	// (set) Token: 0x06000B5D RID: 2909 RVA: 0x00017EFF File Offset: 0x000160FF
	public string APtdZVINrxrWuEKglbAnbOKIRRM { get; private set; }

	// Token: 0x170001F0 RID: 496
	// (get) Token: 0x06000B5E RID: 2910 RVA: 0x00017F08 File Offset: 0x00016108
	public bool NGnlJoFsplzkuZrGuEoLrWGjZHjB
	{
		get
		{
			return this.QtRnmVzmpDUoUKwsQMCxGMPokbvw.IsAlive;
		}
	}

	// Token: 0x06000B5F RID: 2911 RVA: 0x0003D9A0 File Offset: 0x0003BBA0
	public virtual string dIfpdltqgSfgyFwjyjMMQVNEFVluA()
	{
		ttVRlsKWObTjefpmeeKUvTYTQZRU ttVRlsKWObTjefpmeeKUvTYTQZRU = this.QtRnmVzmpDUoUKwsQMCxGMPokbvw.Target as ttVRlsKWObTjefpmeeKUvTYTQZRU;
		if (ttVRlsKWObTjefpmeeKUvTYTQZRU == null)
		{
			return "";
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "Active COM Object: [0x{0:X}] Class: [{1}] Time [{2}] Stack:\r\n{3}", new object[]
		{
			ttVRlsKWObTjefpmeeKUvTYTQZRU.FXEBIagcuThOcOepHwiWojXacofZA.ToInt64(),
			ttVRlsKWObTjefpmeeKUvTYTQZRU.GetType().FullName,
			this.NEOvxxVJqmQbEWthZSCSNpvZDjvQ,
			this.APtdZVINrxrWuEKglbAnbOKIRRM
		}).AppendLine();
		return stringBuilder.ToString();
	}

	// Token: 0x04000A23 RID: 2595
	[CompilerGenerated]
	private DateTime AKPvhBqjgrvhcIoJipfFBsViREA;

	// Token: 0x04000A24 RID: 2596
	[CompilerGenerated]
	private WeakReference AOqlvFfnzlooUQmPxHkMkYpUBZFTA;

	// Token: 0x04000A25 RID: 2597
	[CompilerGenerated]
	private string XFFhUgcXXVyIpMlOxLzlJbxpbeujb;
}
