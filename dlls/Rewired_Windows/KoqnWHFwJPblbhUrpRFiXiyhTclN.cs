using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired;
using Rewired.Data;
using Rewired.Interfaces;

// Token: 0x020000AB RID: 171
internal class KoqnWHFwJPblbhUrpRFiXiyhTclN : IInputSource, IDisposable
{
	// Token: 0x1400000C RID: 12
	// (add) Token: 0x0600061F RID: 1567 RVA: 0x00034A9C File Offset: 0x00032C9C
	// (remove) Token: 0x06000620 RID: 1568 RVA: 0x00034AD4 File Offset: 0x00032CD4
	private event Action nTvFFpKtnkTvsWompSEPTTPrsXai;

	// Token: 0x06000621 RID: 1569 RVA: 0x00034B0C File Offset: 0x00032D0C
	public KoqnWHFwJPblbhUrpRFiXiyhTclN(ConfigVars A_1, bool A_2, bool A_3, bool A_4)
	{
		try
		{
			this.RvBlJZXyyLTONWZrKeDidTazettR = A_1;
			this.eEHjYUtWpVjDMPHKLwCElmXvlAqO = A_2;
			this.hOkZwTAxheZfhyFOcaFWJfGwFibE = A_3;
			this.duqjJjKxzXkUrvBRaftjASxCJYUoA = A_4;
			if (A_3)
			{
				throw new NotImplementedException("WGI mouse input not implemented.");
			}
			if (A_4)
			{
				throw new NotImplementedException("WGI keyboard input not implemented.");
			}
			try
			{
				if (!OTylkQqSSfezJYDMKEvvfyLhOqsl.HpdeVuIkFqWPJzbJBbjHwPViSNTq())
				{
					Logger.LogWarning(KoqnWHFwJPblbhUrpRFiXiyhTclN.LRZIpBzMHEZCOFprrPJHiBGQWkxO + " Requires " + OTylkQqSSfezJYDMKEvvfyLhOqsl.lpUAFojSpGctSStyjkatEyCSWeWgb() + " or greater.");
					throw new Exception();
				}
			}
			catch (DllNotFoundException)
			{
				Logger.LogWarning(KoqnWHFwJPblbhUrpRFiXiyhTclN.LRZIpBzMHEZCOFprrPJHiBGQWkxO + " Either Rewired_WindowsGamingInput.dll is missing or this version of Windows does not meet the minimum version requirements for Windows Gaming Input support.");
				throw new Exception();
			}
			catch
			{
				Logger.LogWarning(KoqnWHFwJPblbhUrpRFiXiyhTclN.LRZIpBzMHEZCOFprrPJHiBGQWkxO);
				throw new Exception();
			}
			this.rGiSyDtGouALDvdxccmiUoTTphrg = true;
			if (this.sgBczqSSCAhNhFZHuYgNLpJHqHnQ)
			{
				this.jcPYbJXLLkePwbPXOCDGgIVMxMYiA = false;
			}
			if (this.rGiSyDtGouALDvdxccmiUoTTphrg)
			{
				KoqnWHFwJPblbhUrpRFiXiyhTclN.qQBeAYgqmVsqkZyLvURabgxxIGmG = new yULinvLPouOJNlRPpStVQNhPEJys(new Func<int>(this.SXFcdgtwWhocEANnCieGaGKwEGFv));
			}
			this.WICmHgiXFfgOkAHBoYkacOvmFdVHA = new List<cWYIDMjUnhAyDysKZVfQnpWFBosr>();
			this.gQyhtWJtoseTwDFdsLgjyloGumRA = new ReadOnlyCollection<cWYIDMjUnhAyDysKZVfQnpWFBosr>(this.WICmHgiXFfgOkAHBoYkacOvmFdVHA);
			if (this.rGiSyDtGouALDvdxccmiUoTTphrg)
			{
				KoqnWHFwJPblbhUrpRFiXiyhTclN.qQBeAYgqmVsqkZyLvURabgxxIGmG.TipzCAwbHkPgjiEGmedLdiCxWVJp += this.SMHlaXOwCgTheiDyqkwxZOqYJzvp;
			}
			if (A_2)
			{
				this.keEurSyYVKblQmGUwFrSGfmSMShC(true);
			}
			ReInput.ApplicationFocusChangedEvent += this.ZeTCFPlSeDRvHaHPjEVYveqgvVMd;
		}
		catch (Exception)
		{
			this.Dispose();
			throw;
		}
	}

	// Token: 0x06000622 RID: 1570 RVA: 0x00014292 File Offset: 0x00012492
	public void PXgUmyKEtzWjEhRUZeiVnEGamthg()
	{
		this.FXGKUWBmdwJzfgJwmKcciqSDfnPAA = false;
		this.keEurSyYVKblQmGUwFrSGfmSMShC(false);
	}

	// Token: 0x1700012D RID: 301
	// (get) Token: 0x06000623 RID: 1571 RVA: 0x000116EB File Offset: 0x0000F8EB
	public IUnifiedKeyboardSource wqOMnLZmEGZzaMlNPadPwJDMzFEB
	{
		get
		{
			return null;
		}
	}

	// Token: 0x1700012E RID: 302
	// (get) Token: 0x06000624 RID: 1572 RVA: 0x000116EB File Offset: 0x0000F8EB
	public IUnifiedMouseSource tnrubUCEScgFSYfAPXDptgyaQtRs
	{
		get
		{
			return null;
		}
	}

	// Token: 0x06000625 RID: 1573 RVA: 0x000142A2 File Offset: 0x000124A2
	public bool QgeBSiHFJiTohPCyWgobQLHPMLbjA(PidVid A_1)
	{
		return this.rGiSyDtGouALDvdxccmiUoTTphrg && npeFzFFBQqrIoNKuecNDbCOHzNtgA.lURAjCJXjiarAqNOrtslVmpaEgeD(A_1.vendorId, A_1.productId);
	}

	// Token: 0x1400000D RID: 13
	// (add) Token: 0x06000626 RID: 1574 RVA: 0x000142C2 File Offset: 0x000124C2
	// (remove) Token: 0x06000627 RID: 1575 RVA: 0x000142CB File Offset: 0x000124CB
	public event Action DeviceChangedEvent
	{
		add
		{
			this.nTvFFpKtnkTvsWompSEPTTPrsXai += value;
		}
		remove
		{
			this.nTvFFpKtnkTvsWompSEPTTPrsXai -= value;
		}
	}

	// Token: 0x06000628 RID: 1576 RVA: 0x000142D4 File Offset: 0x000124D4
	public void SystemDeviceDisconnected()
	{
		this.SMHlaXOwCgTheiDyqkwxZOqYJzvp();
	}

	// Token: 0x06000629 RID: 1577 RVA: 0x000142D4 File Offset: 0x000124D4
	public void SystemDeviceConnected()
	{
		this.SMHlaXOwCgTheiDyqkwxZOqYJzvp();
	}

	// Token: 0x0600062A RID: 1578 RVA: 0x000142DC File Offset: 0x000124DC
	public void Update()
	{
		if (this.AhKwhmZfZTsASpGcwjvPAEsyRcEBA)
		{
			this.SMHlaXOwCgTheiDyqkwxZOqYJzvp();
		}
		if (this.rGiSyDtGouALDvdxccmiUoTTphrg)
		{
			KoqnWHFwJPblbhUrpRFiXiyhTclN.qQBeAYgqmVsqkZyLvURabgxxIGmG.tCrDCAEBeaiIRGpxADFJIJvDwFbJC();
		}
	}

	// Token: 0x0600062B RID: 1579 RVA: 0x00034C98 File Offset: 0x00032E98
	public void UpdateDevices(UpdateLoopType updateLoop)
	{
		if (this.eEHjYUtWpVjDMPHKLwCElmXvlAqO)
		{
			for (int i = 0; i < this.WICmHgiXFfgOkAHBoYkacOvmFdVHA.Count; i++)
			{
				cWYIDMjUnhAyDysKZVfQnpWFBosr cWYIDMjUnhAyDysKZVfQnpWFBosr = this.WICmHgiXFfgOkAHBoYkacOvmFdVHA[i];
				if (cWYIDMjUnhAyDysKZVfQnpWFBosr != null)
				{
					cWYIDMjUnhAyDysKZVfQnpWFBosr.HNOkLPGjTMelBuPoPqesvzLHXckm(updateLoop);
				}
			}
			if (this.rGiSyDtGouALDvdxccmiUoTTphrg)
			{
				KoqnWHFwJPblbhUrpRFiXiyhTclN.qQBeAYgqmVsqkZyLvURabgxxIGmG.lQyhccrkfiUmqUnuzloevdXzxvJQ();
			}
		}
	}

	// Token: 0x0600062C RID: 1580 RVA: 0x00034CEC File Offset: 0x00032EEC
	public void UpdateFinished()
	{
		for (int i = 0; i < this.WICmHgiXFfgOkAHBoYkacOvmFdVHA.Count; i++)
		{
			cWYIDMjUnhAyDysKZVfQnpWFBosr cWYIDMjUnhAyDysKZVfQnpWFBosr = this.WICmHgiXFfgOkAHBoYkacOvmFdVHA[i];
			if (cWYIDMjUnhAyDysKZVfQnpWFBosr != null)
			{
				cWYIDMjUnhAyDysKZVfQnpWFBosr.HALUsRwEhCdXcaroUpyyKgQwPRBv();
			}
		}
	}

	// Token: 0x0600062D RID: 1581 RVA: 0x000142FE File Offset: 0x000124FE
	public IList<T> GetJoysticks<T>() where T : class
	{
		return this.gQyhtWJtoseTwDFdsLgjyloGumRA as IList<T>;
	}

	// Token: 0x0600062E RID: 1582 RVA: 0x00034D28 File Offset: 0x00032F28
	private void keEurSyYVKblQmGUwFrSGfmSMShC(bool A_1)
	{
		if (this.AhKwhmZfZTsASpGcwjvPAEsyRcEBA)
		{
			this.AhKwhmZfZTsASpGcwjvPAEsyRcEBA = false;
		}
		List<cWYIDMjUnhAyDysKZVfQnpWFBosr> list = new List<cWYIDMjUnhAyDysKZVfQnpWFBosr>();
		int num = 0;
		if (this.rGiSyDtGouALDvdxccmiUoTTphrg)
		{
			IList<IbdfoVkCYOJkjATrURkAWolxdaurA> list2 = KoqnWHFwJPblbhUrpRFiXiyhTclN.qQBeAYgqmVsqkZyLvURabgxxIGmG.qBwDYAnpKjyLiCiQpIAUfFlIgNijA();
			for (int i = 0; i < list2.Count; i++)
			{
				IbdfoVkCYOJkjATrURkAWolxdaurA ibdfoVkCYOJkjATrURkAWolxdaurA = list2[i];
				if (ibdfoVkCYOJkjATrURkAWolxdaurA != null)
				{
					list.Add(ibdfoVkCYOJkjATrURkAWolxdaurA);
					num++;
				}
			}
		}
		if (list.Count == 0)
		{
			this.WICmHgiXFfgOkAHBoYkacOvmFdVHA.Clear();
			return;
		}
		int count = list.Count;
		int count2 = this.WICmHgiXFfgOkAHBoYkacOvmFdVHA.Count;
		cWYIDMjUnhAyDysKZVfQnpWFBosr[] array = new cWYIDMjUnhAyDysKZVfQnpWFBosr[count];
		for (int j = 0; j < count; j++)
		{
			bool flag = false;
			for (int k = 0; k < count2; k++)
			{
				if (list[j] != null && this.WICmHgiXFfgOkAHBoYkacOvmFdVHA[k] != null && list[j].qutfHyBpippaAYryIwZDUHevSJOcb == this.WICmHgiXFfgOkAHBoYkacOvmFdVHA[k].qutfHyBpippaAYryIwZDUHevSJOcb)
				{
					array[j] = this.WICmHgiXFfgOkAHBoYkacOvmFdVHA[k];
					array[j].ujBFyXaFbxcLMUISMqtqiyMPHBEB(list[j]);
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				array[j] = list[j];
			}
		}
		this.WICmHgiXFfgOkAHBoYkacOvmFdVHA.Clear();
		for (int l = 0; l < count; l++)
		{
			if (array[l] != null)
			{
				this.WICmHgiXFfgOkAHBoYkacOvmFdVHA.Add(array[l]);
			}
		}
	}

	// Token: 0x0600062F RID: 1583 RVA: 0x0001430B File Offset: 0x0001250B
	private void SMHlaXOwCgTheiDyqkwxZOqYJzvp()
	{
		if (this.eEHjYUtWpVjDMPHKLwCElmXvlAqO)
		{
			this.FXGKUWBmdwJzfgJwmKcciqSDfnPAA = true;
		}
		if (this.nTvFFpKtnkTvsWompSEPTTPrsXai != null)
		{
			this.nTvFFpKtnkTvsWompSEPTTPrsXai();
		}
	}

	// Token: 0x06000630 RID: 1584 RVA: 0x0001432F File Offset: 0x0001252F
	private int SXFcdgtwWhocEANnCieGaGKwEGFv()
	{
		int result = this.kDtlRwTiwsRMkutGcCEEeaPdhRif;
		if (this.kDtlRwTiwsRMkutGcCEEeaPdhRif == 2147483647)
		{
			this.kDtlRwTiwsRMkutGcCEEeaPdhRif = 0;
			return result;
		}
		this.kDtlRwTiwsRMkutGcCEEeaPdhRif++;
		return result;
	}

	// Token: 0x06000631 RID: 1585 RVA: 0x0001435A File Offset: 0x0001255A
	private void ZeTCFPlSeDRvHaHPjEVYveqgvVMd(bool A_1)
	{
		if (!this.eEHjYUtWpVjDMPHKLwCElmXvlAqO)
		{
			return;
		}
		if (A_1)
		{
			this.AhKwhmZfZTsASpGcwjvPAEsyRcEBA = true;
		}
	}

	// Token: 0x06000632 RID: 1586 RVA: 0x0001436F File Offset: 0x0001256F
	public void Dispose()
	{
		this.PbgbZqosvtbeWQVdpnaqqnUTcjwe(true);
		GC.SuppressFinalize(this);
	}

	// Token: 0x06000633 RID: 1587 RVA: 0x00034E94 File Offset: 0x00033094
	protected virtual void bicagLepYaMVWDDCBPJvUhzRsgPCA()
	{
		try
		{
			this.PbgbZqosvtbeWQVdpnaqqnUTcjwe(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	// Token: 0x06000634 RID: 1588 RVA: 0x00034EC4 File Offset: 0x000330C4
	protected virtual void PbgbZqosvtbeWQVdpnaqqnUTcjwe(bool A_1)
	{
		if (this.hLNHGyRWcWsjKegPloFqpxItBKxb)
		{
			return;
		}
		if (A_1)
		{
			ReInput.ApplicationFocusChangedEvent -= this.ZeTCFPlSeDRvHaHPjEVYveqgvVMd;
			if (KoqnWHFwJPblbhUrpRFiXiyhTclN.qQBeAYgqmVsqkZyLvURabgxxIGmG != null)
			{
				KoqnWHFwJPblbhUrpRFiXiyhTclN.qQBeAYgqmVsqkZyLvURabgxxIGmG.Dispose();
			}
			if (this.WICmHgiXFfgOkAHBoYkacOvmFdVHA != null)
			{
				for (int i = 0; i < this.WICmHgiXFfgOkAHBoYkacOvmFdVHA.Count; i++)
				{
					if (this.WICmHgiXFfgOkAHBoYkacOvmFdVHA[i] != null)
					{
						this.WICmHgiXFfgOkAHBoYkacOvmFdVHA[i].Dispose();
					}
				}
			}
		}
		this.hLNHGyRWcWsjKegPloFqpxItBKxb = true;
	}

	// Token: 0x04000685 RID: 1669
	private static yULinvLPouOJNlRPpStVQNhPEJys qQBeAYgqmVsqkZyLvURabgxxIGmG;

	// Token: 0x04000686 RID: 1670
	private List<cWYIDMjUnhAyDysKZVfQnpWFBosr> WICmHgiXFfgOkAHBoYkacOvmFdVHA;

	// Token: 0x04000687 RID: 1671
	private ReadOnlyCollection<cWYIDMjUnhAyDysKZVfQnpWFBosr> gQyhtWJtoseTwDFdsLgjyloGumRA;

	// Token: 0x04000688 RID: 1672
	private ConfigVars RvBlJZXyyLTONWZrKeDidTazettR;

	// Token: 0x04000689 RID: 1673
	private readonly bool eEHjYUtWpVjDMPHKLwCElmXvlAqO;

	// Token: 0x0400068A RID: 1674
	private readonly bool hOkZwTAxheZfhyFOcaFWJfGwFibE;

	// Token: 0x0400068B RID: 1675
	private readonly bool duqjJjKxzXkUrvBRaftjASxCJYUoA;

	// Token: 0x0400068C RID: 1676
	private bool FXGKUWBmdwJzfgJwmKcciqSDfnPAA;

	// Token: 0x0400068E RID: 1678
	private readonly bool rGiSyDtGouALDvdxccmiUoTTphrg;

	// Token: 0x0400068F RID: 1679
	private readonly bool jcPYbJXLLkePwbPXOCDGgIVMxMYiA;

	// Token: 0x04000690 RID: 1680
	private readonly bool sgBczqSSCAhNhFZHuYgNLpJHqHnQ;

	// Token: 0x04000691 RID: 1681
	private bool WeOKvVIUvdchqoOTFvSdAzAooZeA;

	// Token: 0x04000692 RID: 1682
	private double RVjfIAkOhDOeYISAKbRlmBwqINhfB;

	// Token: 0x04000693 RID: 1683
	private int kDtlRwTiwsRMkutGcCEEeaPdhRif;

	// Token: 0x04000694 RID: 1684
	private bool AhKwhmZfZTsASpGcwjvPAEsyRcEBA;

	// Token: 0x04000695 RID: 1685
	private static readonly string LRZIpBzMHEZCOFprrPJHiBGQWkxO = "Rewired Windows Gaming Input support is not available on this system.";

	// Token: 0x04000696 RID: 1686
	private bool hLNHGyRWcWsjKegPloFqpxItBKxb;
}
