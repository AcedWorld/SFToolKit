using System;
using System.Threading;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

// Token: 0x02000262 RID: 610
internal class SHijchJBIXBKYGGwoAkdPqhpISMdb : IDisposable
{
	// Token: 0x06001019 RID: 4121 RVA: 0x00047474 File Offset: 0x00045674
	public SHijchJBIXBKYGGwoAkdPqhpISMdb(string A_1, int A_2, string A_3, SHijchJBIXBKYGGwoAkdPqhpISMdb.SkDekfgsoylvRbwFzVyeFuEatcGSb A_4)
	{
		if (string.IsNullOrEmpty(A_1))
		{
			throw new ArgumentNullException("hidDevicePath");
		}
		if (A_4 == null)
		{
			throw new ArgumentNullException("processReportDelegate");
		}
		this.kGhAnlzkFfgxDbrjcdfXvyLKxKonA = A_2;
		if (this.kGhAnlzkFfgxDbrjcdfXvyLKxKonA <= 0)
		{
			this.kGhAnlzkFfgxDbrjcdfXvyLKxKonA = 512;
		}
		this.VqIVkAYVpgWydjftUIVHmcqkBiGn = A_2 + 8;
		this.llMqSlInWCRBBdqLjqseYpjJknQC = A_3;
		this.OalzJXmkmGrSWzCtwyKmERRxUkWM = A_4;
		int num = this.VqIVkAYVpgWydjftUIVHmcqkBiGn * 60;
		if (num <= 0)
		{
			Logger.LogError("Invalid report buffer size. This device \"" + A_3 + "\" will not function.");
			throw new Exception();
		}
		try
		{
			this.AdvdWJxhthTwmpQLSpqcEHilWIOf = new SXzeyXYqAFvmtiXaUteubWFfCXrT(A_1, A_2, 250);
		}
		catch (Exception)
		{
			Logger.LogError("Out of memory. This device \"" + A_3 + "\" will not function.");
			throw;
		}
		try
		{
			this.vppeiHdxwwqTjFvDhkrZTOTczpTe = new bxLmBpBgWqThrxuxOJdyAmAMzBBF(num);
			this.YulXkMyXUohHmdNAtzDIbvdsjNww = new bxLmBpBgWqThrxuxOJdyAmAMzBBF(num);
			this.hLACZtjreCesiTllDcIOkcgPyFbbA = new byte[this.VqIVkAYVpgWydjftUIVHmcqkBiGn];
			this.KbNQvWfCdYopFVrJmBYxhcrvXYMDA = new byte[this.VqIVkAYVpgWydjftUIVHmcqkBiGn];
		}
		catch (Exception)
		{
			Logger.LogError("Out of memory. This device \"" + A_3 + "\" will not function.");
			throw;
		}
		try
		{
			this.rbpKEpnyIVBLhshvloyMGwDgITpg = ThreadHelper.Create(false, 100, false, 0);
			this.rbpKEpnyIVBLhshvloyMGwDgITpg.ThreadUpdateEvent += this.ZFnlQuQPgFwPQFoBuDsoIeAXkhtJA;
			this.rbpKEpnyIVBLhshvloyMGwDgITpg.Start(false);
		}
		catch (Exception)
		{
			Logger.LogError("Error creating thread. This device \"" + A_3 + "\" will not function.");
			throw;
		}
	}

	// Token: 0x0600101A RID: 4122 RVA: 0x00047600 File Offset: 0x00045800
	public unsafe void UDxJpuiKMhmBEoCxaLKGUpykXkvK()
	{
		try
		{
			if (!this.EgnptjJmaKZSglYRCBgnfxLAsSjC())
			{
				this.eUiwVsJpdhODPZCZiFqLKKuEMdLLA();
				int num = 0;
				byte[] array = this.hLACZtjreCesiTllDcIOkcgPyFbbA;
				try
				{
					byte[] array2;
					byte* ptr;
					if ((array2 = array) == null || array2.Length == 0)
					{
						ptr = null;
					}
					else
					{
						ptr = &array2[0];
					}
					while (this.vppeiHdxwwqTjFvDhkrZTOTczpTe.SNFcEniGfoalYxqjexfYaOXaHniaA(array, this.VqIVkAYVpgWydjftUIVHmcqkBiGn) > 0)
					{
						this.OalzJXmkmGrSWzCtwyKmERRxUkWM((IntPtr)((void*)ptr), this.kGhAnlzkFfgxDbrjcdfXvyLKxKonA, 1, *(double*)(ptr + this.kGhAnlzkFfgxDbrjcdfXvyLKxKonA));
						num++;
					}
				}
				finally
				{
					byte[] array2 = null;
				}
			}
		}
		catch
		{
		}
	}

	// Token: 0x0600101B RID: 4123 RVA: 0x000476A0 File Offset: 0x000458A0
	private void eUiwVsJpdhODPZCZiFqLKKuEMdLLA()
	{
		bxLmBpBgWqThrxuxOJdyAmAMzBBF obj = this.vppeiHdxwwqTjFvDhkrZTOTczpTe;
		lock (obj)
		{
			bxLmBpBgWqThrxuxOJdyAmAMzBBF yulXkMyXUohHmdNAtzDIbvdsjNww = this.YulXkMyXUohHmdNAtzDIbvdsjNww;
			lock (yulXkMyXUohHmdNAtzDIbvdsjNww)
			{
				MiscTools.Swap<bxLmBpBgWqThrxuxOJdyAmAMzBBF>(ref this.vppeiHdxwwqTjFvDhkrZTOTczpTe, ref this.YulXkMyXUohHmdNAtzDIbvdsjNww);
			}
		}
	}

	// Token: 0x0600101C RID: 4124 RVA: 0x00047714 File Offset: 0x00045914
	private void ZFnlQuQPgFwPQFoBuDsoIeAXkhtJA()
	{
		if (this.euANWdGftcjvaIspWmryGPccEiVJA != 0)
		{
			Thread.Sleep(500);
			return;
		}
		try
		{
			byte[] kbNQvWfCdYopFVrJmBYxhcrvXYMDA = this.KbNQvWfCdYopFVrJmBYxhcrvXYMDA;
			if (this.GTqoEQAVAqjVvUziWqKGAblWqVlg(kbNQvWfCdYopFVrJmBYxhcrvXYMDA))
			{
				bxLmBpBgWqThrxuxOJdyAmAMzBBF yulXkMyXUohHmdNAtzDIbvdsjNww = this.YulXkMyXUohHmdNAtzDIbvdsjNww;
				lock (yulXkMyXUohHmdNAtzDIbvdsjNww)
				{
					this.YulXkMyXUohHmdNAtzDIbvdsjNww.XLHYEPMGHughigtUHYbzyWaphkfCA(kbNQvWfCdYopFVrJmBYxhcrvXYMDA, kbNQvWfCdYopFVrJmBYxhcrvXYMDA.Length);
				}
			}
		}
		catch
		{
		}
	}

	// Token: 0x0600101D RID: 4125 RVA: 0x00047798 File Offset: 0x00045998
	private bool GTqoEQAVAqjVvUziWqKGAblWqVlg(byte[] A_1)
	{
		switch (this.AdvdWJxhthTwmpQLSpqcEHilWIOf.jQRXSNKSKFKlxvpbWFWAcsDcAnvKA(A_1))
		{
		case SXzeyXYqAFvmtiXaUteubWFfCXrT.hLKqhdqJnsrKzEqdeLJBmfrXFwQG.Success:
			return true;
		case SXzeyXYqAFvmtiXaUteubWFfCXrT.hLKqhdqJnsrKzEqdeLJBmfrXFwQG.Error:
			Thread.Sleep(500);
			break;
		case SXzeyXYqAFvmtiXaUteubWFfCXrT.hLKqhdqJnsrKzEqdeLJBmfrXFwQG.CriticalError:
			this.euANWdGftcjvaIspWmryGPccEiVJA = 1;
			break;
		}
		return false;
	}

	// Token: 0x0600101E RID: 4126 RVA: 0x000477E4 File Offset: 0x000459E4
	private bool EgnptjJmaKZSglYRCBgnfxLAsSjC()
	{
		if (this.euANWdGftcjvaIspWmryGPccEiVJA != 0)
		{
			if (this.euANWdGftcjvaIspWmryGPccEiVJA == 1)
			{
				Logger.LogError("Error communicating with HID device. This device \"" + this.llMqSlInWCRBBdqLjqseYpjJknQC + "\" will not function.");
				this.euANWdGftcjvaIspWmryGPccEiVJA = 2;
				try
				{
					this.rbpKEpnyIVBLhshvloyMGwDgITpg.Stop(false);
				}
				catch
				{
				}
			}
			return true;
		}
		return false;
	}

	// Token: 0x0600101F RID: 4127 RVA: 0x0001A15C File Offset: 0x0001835C
	public void Dispose()
	{
		this.lRBcoqBZxELLAgZzjgWdcWToqotlA(true);
		GC.SuppressFinalize(this);
	}

	// Token: 0x06001020 RID: 4128 RVA: 0x00047848 File Offset: 0x00045A48
	protected virtual void mTmVejFfLqGQJgVwsRHHdtHCqOmFA()
	{
		try
		{
			this.lRBcoqBZxELLAgZzjgWdcWToqotlA(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	// Token: 0x06001021 RID: 4129 RVA: 0x0001A16B File Offset: 0x0001836B
	protected virtual void lRBcoqBZxELLAgZzjgWdcWToqotlA(bool A_1)
	{
		if (this.kaNCmzpxMuoZLcNaSWWuklQtOWCV)
		{
			return;
		}
		if (A_1)
		{
			if (this.rbpKEpnyIVBLhshvloyMGwDgITpg != null)
			{
				this.rbpKEpnyIVBLhshvloyMGwDgITpg.Dispose();
			}
			if (this.AdvdWJxhthTwmpQLSpqcEHilWIOf != null)
			{
				this.AdvdWJxhthTwmpQLSpqcEHilWIOf.Dispose();
			}
		}
		this.kaNCmzpxMuoZLcNaSWWuklQtOWCV = true;
	}

	// Token: 0x04002AA7 RID: 10919
	private const int tIlCBBKdeNQYDcIMdMidnabAYfMGB = 512;

	// Token: 0x04002AA8 RID: 10920
	private const int XrHCxvdwxYGxardDpyiyaVdeIuXoA = 250;

	// Token: 0x04002AA9 RID: 10921
	private readonly SHijchJBIXBKYGGwoAkdPqhpISMdb.SkDekfgsoylvRbwFzVyeFuEatcGSb OalzJXmkmGrSWzCtwyKmERRxUkWM;

	// Token: 0x04002AAA RID: 10922
	private readonly SXzeyXYqAFvmtiXaUteubWFfCXrT AdvdWJxhthTwmpQLSpqcEHilWIOf;

	// Token: 0x04002AAB RID: 10923
	private readonly ThreadHelper rbpKEpnyIVBLhshvloyMGwDgITpg;

	// Token: 0x04002AAC RID: 10924
	private readonly int VqIVkAYVpgWydjftUIVHmcqkBiGn;

	// Token: 0x04002AAD RID: 10925
	private readonly int kGhAnlzkFfgxDbrjcdfXvyLKxKonA;

	// Token: 0x04002AAE RID: 10926
	private readonly string llMqSlInWCRBBdqLjqseYpjJknQC;

	// Token: 0x04002AAF RID: 10927
	private readonly byte[] hLACZtjreCesiTllDcIOkcgPyFbbA;

	// Token: 0x04002AB0 RID: 10928
	private readonly byte[] KbNQvWfCdYopFVrJmBYxhcrvXYMDA;

	// Token: 0x04002AB1 RID: 10929
	private int euANWdGftcjvaIspWmryGPccEiVJA;

	// Token: 0x04002AB2 RID: 10930
	private bxLmBpBgWqThrxuxOJdyAmAMzBBF vppeiHdxwwqTjFvDhkrZTOTczpTe;

	// Token: 0x04002AB3 RID: 10931
	private bxLmBpBgWqThrxuxOJdyAmAMzBBF YulXkMyXUohHmdNAtzDIbvdsjNww;

	// Token: 0x04002AB4 RID: 10932
	private bool kaNCmzpxMuoZLcNaSWWuklQtOWCV;

	// Token: 0x02000263 RID: 611
	// (Invoke) Token: 0x06001023 RID: 4131
	public delegate void SkDekfgsoylvRbwFzVyeFuEatcGSb(IntPtr reportPointer, int reportByteLength, int reportCount, double timestamp);
}
