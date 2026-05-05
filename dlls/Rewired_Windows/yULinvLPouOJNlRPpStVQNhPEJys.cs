using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Rewired;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;

// Token: 0x02000093 RID: 147
internal class yULinvLPouOJNlRPpStVQNhPEJys : IDisposable
{
	// Token: 0x1400000B RID: 11
	// (add) Token: 0x060004DD RID: 1245 RVA: 0x00031C7C File Offset: 0x0002FE7C
	// (remove) Token: 0x060004DE RID: 1246 RVA: 0x00031CB4 File Offset: 0x0002FEB4
	public event Action TipzCAwbHkPgjiEGmedLdiCxWVJp;

	// Token: 0x060004DF RID: 1247 RVA: 0x00031CEC File Offset: 0x0002FEEC
	public yULinvLPouOJNlRPpStVQNhPEJys(Func<int> A_1)
	{
		this.oXtoefAimYHBNhQcZoFvWLJUjhNtA = A_1;
		this.dHhAHHEaXgbwtEzvhyWilaUNcqzqc = new Action<npeFzFFBQqrIoNKuecNDbCOHzNtgA, BnFiTEhittEzLCwZuNtphKZVBdZZA>(this.jHheevmikLBYYLlyjVODybZjpbtn);
		this.iCvaoSjihuEFjMmokhQBjqSGVEdw = new List<IbdfoVkCYOJkjATrURkAWolxdaurA>();
		this.xDAUijxMgIgUwbSYuXCoCSfUwhaMA = new List<IbdfoVkCYOJkjATrURkAWolxdaurA>();
		this.oBDCUcjbqwDlxAXUXEfjqAYfYDeQ = new ReadOnlyCollection<IbdfoVkCYOJkjATrURkAWolxdaurA>(this.iCvaoSjihuEFjMmokhQBjqSGVEdw);
		this.ZqEBlJNFXprOHoVCnRCCQJrZFrNs = new List<npeFzFFBQqrIoNKuecNDbCOHzNtgA>();
		this.agzBmYcJFmLLzImuDVieQJChUhIH = ReInput.IsInputAllowed(ControllerType.Joystick);
		int num = (int)(0.5f * (float)jbcfMDoFeBFAQElVePZhKkwUdctNA.dHcfLGecBdWpOuQXknheqwKuIFtT * 32f) + 1;
		this.zzeUjRHhzDgTOkyjmivNGRCdCZRd = new ThreadSafeObjectPool<yULinvLPouOJNlRPpStVQNhPEJys.GloBAbHSgCRenpPkPzXYafCMQIaoA>(num, new Func<yULinvLPouOJNlRPpStVQNhPEJys.GloBAbHSgCRenpPkPzXYafCMQIaoA>(yULinvLPouOJNlRPpStVQNhPEJys.vIdHFciaQRtjpQwFvdqDrHDUhwwY.<>9.QMIhiNbHfCzHECAJBtBaquNxgPrC), null);
		this.byYYGBRZqSxQkrMoRTNXewyTdVOi = new ThreadSafeObjectPool<yULinvLPouOJNlRPpStVQNhPEJys.uBDUztooTbghwvNMiOMKXvJYjjzc>(128, new Func<yULinvLPouOJNlRPpStVQNhPEJys.uBDUztooTbghwvNMiOMKXvJYjjzc>(yULinvLPouOJNlRPpStVQNhPEJys.vIdHFciaQRtjpQwFvdqDrHDUhwwY.<>9.LkSitkCZFTYYEPLryxiSPJJbZOpI), null);
		this.goJTPZcMipbfabTOqnzCcoNXPbiwA = new RingBuffer<yULinvLPouOJNlRPpStVQNhPEJys.GloBAbHSgCRenpPkPzXYafCMQIaoA>(num);
		this.FzpYCJvvRrXxvJRgTxDGdwOmHRqG = new RingBuffer<yULinvLPouOJNlRPpStVQNhPEJys.uBDUztooTbghwvNMiOMKXvJYjjzc>(128);
		this.JZUopGwfENZkqVHJirupKuBGFxuj = new RingBuffer<yULinvLPouOJNlRPpStVQNhPEJys.GloBAbHSgCRenpPkPzXYafCMQIaoA>(num);
		this.sTnIKuoWGalBPjFIIjdYcMoMpBxfb = new RingBuffer<yULinvLPouOJNlRPpStVQNhPEJys.uBDUztooTbghwvNMiOMKXvJYjjzc>(128);
		npeFzFFBQqrIoNKuecNDbCOHzNtgA.LMHpwZKjAsuoBEqSucSpLQCLOwQc += this.WLUmkMaORMFnaNFaVIheBZUWZDiqA;
		npeFzFFBQqrIoNKuecNDbCOHzNtgA.lWNIjKhjKrceFkllCrQTJGiynehb += this.CXUFEdamEClHPykbqojYZGRjuqO;
		jbcfMDoFeBFAQElVePZhKkwUdctNA.ZDYmSbdCWXNMZFZsjWAgCzkVkDMh.ThreadUpdateEvent += this.pJVcZcSyxHisgrgyxtCiULkQxYVN;
		jbcfMDoFeBFAQElVePZhKkwUdctNA.EqGdpsfqHLTddwKzexbHrfPVtYZPA.ThreadUpdateEvent += this.kIFstVtykgRTDAushjJAqfFHAAgG;
		ReInput.ApplicationFocusChangedEvent += this.fZMhdNvBzfalKfOjavPrQACAFVMiA;
		ReInput.ApplicationPauseChangedEvent += this.dciOOWoOEnQiaeaHJDMrjScZKoZFb;
		npeFzFFBQqrIoNKuecNDbCOHzNtgA.mEGFaQlJUenaWTWppoSpBxrcSCDJ();
		this.YkEQKyBRdJxJbesCDfqwtDMIXkLN();
	}

	// Token: 0x060004E0 RID: 1248 RVA: 0x00031E94 File Offset: 0x00030094
	public void tCrDCAEBeaiIRGpxADFJIJvDwFbJC()
	{
		bool flag = false;
		using (this.LbOfsSqBhmFkHhBZXuSoRusbIvTfA.Lock())
		{
			if (this.uZGpKeKxWSnAnjEcShNUClWNKvZgb)
			{
				this.uZGpKeKxWSnAnjEcShNUClWNKvZgb = false;
				flag = true;
			}
		}
		if (flag)
		{
			this.YkEQKyBRdJxJbesCDfqwtDMIXkLN();
		}
	}

	// Token: 0x060004E1 RID: 1249 RVA: 0x00031EE8 File Offset: 0x000300E8
	public void lQyhccrkfiUmqUnuzloevdXzxvJQ()
	{
		using (this.LbOfsSqBhmFkHhBZXuSoRusbIvTfA.Lock())
		{
			MiscTools.Swap<RingBuffer<yULinvLPouOJNlRPpStVQNhPEJys.GloBAbHSgCRenpPkPzXYafCMQIaoA>>(ref this.goJTPZcMipbfabTOqnzCcoNXPbiwA, ref this.JZUopGwfENZkqVHJirupKuBGFxuj);
			goto IL_6E;
		}
		IL_29:
		yULinvLPouOJNlRPpStVQNhPEJys.GloBAbHSgCRenpPkPzXYafCMQIaoA gloBAbHSgCRenpPkPzXYafCMQIaoA = this.goJTPZcMipbfabTOqnzCcoNXPbiwA.Dequeue();
		int num = yULinvLPouOJNlRPpStVQNhPEJys.xRdswwKyvIzhWuLWIhwodRpbQJUF(this.iCvaoSjihuEFjMmokhQBjqSGVEdw, gloBAbHSgCRenpPkPzXYafCMQIaoA.zNXWTDgAddtmddwopCTJCQseroDg);
		if (num >= 0)
		{
			this.iCvaoSjihuEFjMmokhQBjqSGVEdw[num].dePLTJRRyTLncmuCZWYVyBNNtYdl(gloBAbHSgCRenpPkPzXYafCMQIaoA.aMeaHrYISQacPcSDnCjBPvKwhbHP, gloBAbHSgCRenpPkPzXYafCMQIaoA.IodPuUauocpGZhaXzXFrOUbGFubP);
		}
		gloBAbHSgCRenpPkPzXYafCMQIaoA.Return();
		IL_6E:
		if (this.goJTPZcMipbfabTOqnzCcoNXPbiwA.Count <= 0)
		{
			return;
		}
		goto IL_29;
	}

	// Token: 0x060004E2 RID: 1250 RVA: 0x00031F84 File Offset: 0x00030184
	private void jHheevmikLBYYLlyjVODybZjpbtn(npeFzFFBQqrIoNKuecNDbCOHzNtgA A_1, BnFiTEhittEzLCwZuNtphKZVBdZZA A_2)
	{
		if (!this.agzBmYcJFmLLzImuDVieQJChUhIH)
		{
			return;
		}
		using (this.qYJlzdjsuYmUJUfbwxkGCKmRQpDL.Lock())
		{
			yULinvLPouOJNlRPpStVQNhPEJys.uBDUztooTbghwvNMiOMKXvJYjjzc uBDUztooTbghwvNMiOMKXvJYjjzc = this.byYYGBRZqSxQkrMoRTNXewyTdVOi.Get();
			uBDUztooTbghwvNMiOMKXvJYjjzc.qnSqJtgsdmcaniSqFKkwsHBxUeCn = A_1;
			uBDUztooTbghwvNMiOMKXvJYjjzc.qPiKCvljENntAKhlVUXWHVjFGchK = A_2;
			this.FzpYCJvvRrXxvJRgTxDGdwOmHRqG.Enqueue(uBDUztooTbghwvNMiOMKXvJYjjzc);
		}
	}

	// Token: 0x060004E3 RID: 1251 RVA: 0x00013AFC File Offset: 0x00011CFC
	public IList<IbdfoVkCYOJkjATrURkAWolxdaurA> qBwDYAnpKjyLiCiQpIAUfFlIgNijA()
	{
		return this.oBDCUcjbqwDlxAXUXEfjqAYfYDeQ;
	}

	// Token: 0x060004E4 RID: 1252 RVA: 0x00031FE8 File Offset: 0x000301E8
	private void YkEQKyBRdJxJbesCDfqwtDMIXkLN()
	{
		bool flag = false;
		List<npeFzFFBQqrIoNKuecNDbCOHzNtgA> zqEBlJNFXprOHoVCnRCCQJrZFrNs = this.ZqEBlJNFXprOHoVCnRCCQJrZFrNs;
		using (this.LbOfsSqBhmFkHhBZXuSoRusbIvTfA.Lock())
		{
			npeFzFFBQqrIoNKuecNDbCOHzNtgA.ziIbtFhsNmVAEciblpallAsVQgkhA(zqEBlJNFXprOHoVCnRCCQJrZFrNs);
			for (int i = this.xDAUijxMgIgUwbSYuXCoCSfUwhaMA.Count - 1; i >= 0; i--)
			{
				if (!yULinvLPouOJNlRPpStVQNhPEJys.BpHBuNeVnisyZDuzGDolaPVQlKVVA(zqEBlJNFXprOHoVCnRCCQJrZFrNs, this.xDAUijxMgIgUwbSYuXCoCSfUwhaMA[i].NZqziYepfEXXCdWsTKulipskmgzF))
				{
					this.xDAUijxMgIgUwbSYuXCoCSfUwhaMA[i].NZqziYepfEXXCdWsTKulipskmgzF.GUYtzgHLQVggrCxIzRYXKylefCDA();
					this.xDAUijxMgIgUwbSYuXCoCSfUwhaMA[i].Dispose();
					this.xDAUijxMgIgUwbSYuXCoCSfUwhaMA.RemoveAt(i);
					flag = true;
				}
			}
			for (int j = zqEBlJNFXprOHoVCnRCCQJrZFrNs.Count - 1; j >= 0; j--)
			{
				npeFzFFBQqrIoNKuecNDbCOHzNtgA npeFzFFBQqrIoNKuecNDbCOHzNtgA = zqEBlJNFXprOHoVCnRCCQJrZFrNs[j];
				if (npeFzFFBQqrIoNKuecNDbCOHzNtgA.vvNQHaCQVeDIevISkoFJcpDrCmIR(npeFzFFBQqrIoNKuecNDbCOHzNtgA, null))
				{
					zqEBlJNFXprOHoVCnRCCQJrZFrNs.RemoveAt(j);
				}
				else
				{
					int num = yULinvLPouOJNlRPpStVQNhPEJys.xRdswwKyvIzhWuLWIhwodRpbQJUF(this.xDAUijxMgIgUwbSYuXCoCSfUwhaMA, npeFzFFBQqrIoNKuecNDbCOHzNtgA);
					if (num >= 0)
					{
						zqEBlJNFXprOHoVCnRCCQJrZFrNs[j].GUYtzgHLQVggrCxIzRYXKylefCDA();
						zqEBlJNFXprOHoVCnRCCQJrZFrNs[j] = this.xDAUijxMgIgUwbSYuXCoCSfUwhaMA[num].NZqziYepfEXXCdWsTKulipskmgzF;
					}
					else
					{
						this.xDAUijxMgIgUwbSYuXCoCSfUwhaMA.Add(new IbdfoVkCYOJkjATrURkAWolxdaurA(npeFzFFBQqrIoNKuecNDbCOHzNtgA, this.oXtoefAimYHBNhQcZoFvWLJUjhNtA(), this.dHhAHHEaXgbwtEzvhyWilaUNcqzqc));
						flag = true;
					}
				}
			}
			for (int k = zqEBlJNFXprOHoVCnRCCQJrZFrNs.Count - 1; k >= 0; k--)
			{
				npeFzFFBQqrIoNKuecNDbCOHzNtgA npeFzFFBQqrIoNKuecNDbCOHzNtgA2 = zqEBlJNFXprOHoVCnRCCQJrZFrNs[k];
				int num2 = yULinvLPouOJNlRPpStVQNhPEJys.xRdswwKyvIzhWuLWIhwodRpbQJUF(this.xDAUijxMgIgUwbSYuXCoCSfUwhaMA, npeFzFFBQqrIoNKuecNDbCOHzNtgA2);
				if (num2 >= 0)
				{
					IbdfoVkCYOJkjATrURkAWolxdaurA item = this.xDAUijxMgIgUwbSYuXCoCSfUwhaMA[num2];
					this.xDAUijxMgIgUwbSYuXCoCSfUwhaMA.RemoveAt(num2);
					this.xDAUijxMgIgUwbSYuXCoCSfUwhaMA.Insert(0, item);
				}
			}
			this.iCvaoSjihuEFjMmokhQBjqSGVEdw.Clear();
			for (int l = 0; l < this.xDAUijxMgIgUwbSYuXCoCSfUwhaMA.Count; l++)
			{
				this.iCvaoSjihuEFjMmokhQBjqSGVEdw.Add(this.xDAUijxMgIgUwbSYuXCoCSfUwhaMA[l]);
			}
		}
		zqEBlJNFXprOHoVCnRCCQJrZFrNs.Clear();
		if (flag)
		{
			Action tipzCAwbHkPgjiEGmedLdiCxWVJp = this.TipzCAwbHkPgjiEGmedLdiCxWVJp;
			if (tipzCAwbHkPgjiEGmedLdiCxWVJp != null)
			{
				tipzCAwbHkPgjiEGmedLdiCxWVJp();
			}
		}
	}

	// Token: 0x060004E5 RID: 1253 RVA: 0x000321F4 File Offset: 0x000303F4
	private void fZMhdNvBzfalKfOjavPrQACAFVMiA(bool A_1)
	{
		this.agzBmYcJFmLLzImuDVieQJChUhIH = ReInput.IsInputAllowed(ControllerType.Joystick);
		if (!this.agzBmYcJFmLLzImuDVieQJChUhIH)
		{
			using (this.LbOfsSqBhmFkHhBZXuSoRusbIvTfA.Lock())
			{
				this.goJTPZcMipbfabTOqnzCcoNXPbiwA.Clear();
			}
		}
	}

	// Token: 0x060004E6 RID: 1254 RVA: 0x000321F4 File Offset: 0x000303F4
	private void dciOOWoOEnQiaeaHJDMrjScZKoZFb(bool A_1)
	{
		this.agzBmYcJFmLLzImuDVieQJChUhIH = ReInput.IsInputAllowed(ControllerType.Joystick);
		if (!this.agzBmYcJFmLLzImuDVieQJChUhIH)
		{
			using (this.LbOfsSqBhmFkHhBZXuSoRusbIvTfA.Lock())
			{
				this.goJTPZcMipbfabTOqnzCcoNXPbiwA.Clear();
			}
		}
	}

	// Token: 0x060004E7 RID: 1255 RVA: 0x00032248 File Offset: 0x00030448
	private void pJVcZcSyxHisgrgyxtCiULkQxYVN()
	{
		if (this.iNEjNXUmwqWFYexWuNXNvBKMnsir)
		{
			return;
		}
		if (!this.agzBmYcJFmLLzImuDVieQJChUhIH)
		{
			return;
		}
		using (this.LbOfsSqBhmFkHhBZXuSoRusbIvTfA.Lock())
		{
			int count = this.xDAUijxMgIgUwbSYuXCoCSfUwhaMA.Count;
			for (int i = 0; i < count; i++)
			{
				yULinvLPouOJNlRPpStVQNhPEJys.GloBAbHSgCRenpPkPzXYafCMQIaoA gloBAbHSgCRenpPkPzXYafCMQIaoA = this.zzeUjRHhzDgTOkyjmivNGRCdCZRd.Get();
				gloBAbHSgCRenpPkPzXYafCMQIaoA.zNXWTDgAddtmddwopCTJCQseroDg = this.xDAUijxMgIgUwbSYuXCoCSfUwhaMA[i].NZqziYepfEXXCdWsTKulipskmgzF;
				gloBAbHSgCRenpPkPzXYafCMQIaoA.aMeaHrYISQacPcSDnCjBPvKwhbHP = gloBAbHSgCRenpPkPzXYafCMQIaoA.zNXWTDgAddtmddwopCTJCQseroDg.iGOrXLXaxnySeIkvqHSlDpkDGiYv();
				gloBAbHSgCRenpPkPzXYafCMQIaoA.IodPuUauocpGZhaXzXFrOUbGFubP = ReInput.realTime;
				this.JZUopGwfENZkqVHJirupKuBGFxuj.Enqueue(gloBAbHSgCRenpPkPzXYafCMQIaoA);
			}
		}
	}

	// Token: 0x060004E8 RID: 1256 RVA: 0x000322F4 File Offset: 0x000304F4
	private void kIFstVtykgRTDAushjJAqfFHAAgG()
	{
		if (this.iNEjNXUmwqWFYexWuNXNvBKMnsir)
		{
			return;
		}
		using (this.qYJlzdjsuYmUJUfbwxkGCKmRQpDL.Lock())
		{
			MiscTools.Swap<RingBuffer<yULinvLPouOJNlRPpStVQNhPEJys.uBDUztooTbghwvNMiOMKXvJYjjzc>>(ref this.FzpYCJvvRrXxvJRgTxDGdwOmHRqG, ref this.sTnIKuoWGalBPjFIIjdYcMoMpBxfb);
			goto IL_5A;
		}
		IL_32:
		yULinvLPouOJNlRPpStVQNhPEJys.uBDUztooTbghwvNMiOMKXvJYjjzc uBDUztooTbghwvNMiOMKXvJYjjzc = this.sTnIKuoWGalBPjFIIjdYcMoMpBxfb.Dequeue();
		try
		{
			uBDUztooTbghwvNMiOMKXvJYjjzc.qnSqJtgsdmcaniSqFKkwsHBxUeCn.ZiKQowwNPrzYmPsOXmQdSiYUWxbU = uBDUztooTbghwvNMiOMKXvJYjjzc.qPiKCvljENntAKhlVUXWHVjFGchK;
		}
		catch
		{
		}
		uBDUztooTbghwvNMiOMKXvJYjjzc.Return();
		IL_5A:
		if (this.sTnIKuoWGalBPjFIIjdYcMoMpBxfb.Count <= 0)
		{
			return;
		}
		goto IL_32;
	}

	// Token: 0x060004E9 RID: 1257 RVA: 0x00032388 File Offset: 0x00030588
	private void WLUmkMaORMFnaNFaVIheBZUWZDiqA(npeFzFFBQqrIoNKuecNDbCOHzNtgA A_1)
	{
		A_1.GUYtzgHLQVggrCxIzRYXKylefCDA();
		if (this.iNEjNXUmwqWFYexWuNXNvBKMnsir)
		{
			return;
		}
		using (this.LbOfsSqBhmFkHhBZXuSoRusbIvTfA.Lock())
		{
			this.uZGpKeKxWSnAnjEcShNUClWNKvZgb = true;
		}
	}

	// Token: 0x060004EA RID: 1258 RVA: 0x00032388 File Offset: 0x00030588
	private void CXUFEdamEClHPykbqojYZGRjuqO(npeFzFFBQqrIoNKuecNDbCOHzNtgA A_1)
	{
		A_1.GUYtzgHLQVggrCxIzRYXKylefCDA();
		if (this.iNEjNXUmwqWFYexWuNXNvBKMnsir)
		{
			return;
		}
		using (this.LbOfsSqBhmFkHhBZXuSoRusbIvTfA.Lock())
		{
			this.uZGpKeKxWSnAnjEcShNUClWNKvZgb = true;
		}
	}

	// Token: 0x060004EB RID: 1259 RVA: 0x00013B04 File Offset: 0x00011D04
	public void Dispose()
	{
		this.KtuoHxWKjAfpoDhFTVMlxuqWrQQL(true);
		GC.SuppressFinalize(this);
	}

	// Token: 0x060004EC RID: 1260 RVA: 0x000323D4 File Offset: 0x000305D4
	protected virtual void gZgiXgNmMhTpERTDldQQEJcESEIS()
	{
		try
		{
			this.KtuoHxWKjAfpoDhFTVMlxuqWrQQL(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	// Token: 0x060004ED RID: 1261 RVA: 0x00032404 File Offset: 0x00030604
	protected virtual void KtuoHxWKjAfpoDhFTVMlxuqWrQQL(bool A_1)
	{
		if (this.iNEjNXUmwqWFYexWuNXNvBKMnsir)
		{
			return;
		}
		if (A_1)
		{
			ReInput.ApplicationFocusChangedEvent -= this.fZMhdNvBzfalKfOjavPrQACAFVMiA;
			ReInput.ApplicationPauseChangedEvent -= this.dciOOWoOEnQiaeaHJDMrjScZKoZFb;
			npeFzFFBQqrIoNKuecNDbCOHzNtgA.LMHpwZKjAsuoBEqSucSpLQCLOwQc -= this.WLUmkMaORMFnaNFaVIheBZUWZDiqA;
			npeFzFFBQqrIoNKuecNDbCOHzNtgA.lWNIjKhjKrceFkllCrQTJGiynehb -= this.CXUFEdamEClHPykbqojYZGRjuqO;
			jbcfMDoFeBFAQElVePZhKkwUdctNA.ZDYmSbdCWXNMZFZsjWAgCzkVkDMh.ThreadUpdateEvent -= this.pJVcZcSyxHisgrgyxtCiULkQxYVN;
			jbcfMDoFeBFAQElVePZhKkwUdctNA.EqGdpsfqHLTddwKzexbHrfPVtYZPA.ThreadUpdateEvent -= this.kIFstVtykgRTDAushjJAqfFHAAgG;
			using (this.LbOfsSqBhmFkHhBZXuSoRusbIvTfA.Lock())
			{
				for (int i = 0; i < this.xDAUijxMgIgUwbSYuXCoCSfUwhaMA.Count; i++)
				{
					try
					{
						this.xDAUijxMgIgUwbSYuXCoCSfUwhaMA[i].Dispose();
						this.xDAUijxMgIgUwbSYuXCoCSfUwhaMA[i].NZqziYepfEXXCdWsTKulipskmgzF.GUYtzgHLQVggrCxIzRYXKylefCDA();
					}
					catch
					{
					}
				}
				this.xDAUijxMgIgUwbSYuXCoCSfUwhaMA.Clear();
				this.iCvaoSjihuEFjMmokhQBjqSGVEdw.Clear();
			}
			try
			{
				npeFzFFBQqrIoNKuecNDbCOHzNtgA.UoPIVaDSgOwjzfDGwRsIjZbTbtxe();
			}
			catch
			{
			}
		}
		this.iNEjNXUmwqWFYexWuNXNvBKMnsir = true;
	}

	// Token: 0x060004EE RID: 1262 RVA: 0x00013B13 File Offset: 0x00011D13
	private static bool CIJQTPxpKKOiyJNZYGVUkDBFqVUr(IList<IbdfoVkCYOJkjATrURkAWolxdaurA> A_0, npeFzFFBQqrIoNKuecNDbCOHzNtgA A_1)
	{
		return yULinvLPouOJNlRPpStVQNhPEJys.xRdswwKyvIzhWuLWIhwodRpbQJUF(A_0, A_1) >= 0;
	}

	// Token: 0x060004EF RID: 1263 RVA: 0x00013B22 File Offset: 0x00011D22
	private static bool BpHBuNeVnisyZDuzGDolaPVQlKVVA(IList<npeFzFFBQqrIoNKuecNDbCOHzNtgA> A_0, npeFzFFBQqrIoNKuecNDbCOHzNtgA A_1)
	{
		return yULinvLPouOJNlRPpStVQNhPEJys.ljyADuqpuTVUerKRRsvimLHIjFJr(A_0, A_1) >= 0;
	}

	// Token: 0x060004F0 RID: 1264 RVA: 0x0003253C File Offset: 0x0003073C
	private static int xRdswwKyvIzhWuLWIhwodRpbQJUF(IList<IbdfoVkCYOJkjATrURkAWolxdaurA> A_0, npeFzFFBQqrIoNKuecNDbCOHzNtgA A_1)
	{
		if (A_0 == null || npeFzFFBQqrIoNKuecNDbCOHzNtgA.vvNQHaCQVeDIevISkoFJcpDrCmIR(A_1, null))
		{
			return -1;
		}
		for (int i = 0; i < A_0.Count; i++)
		{
			if (A_0[i] != null && npeFzFFBQqrIoNKuecNDbCOHzNtgA.vvNQHaCQVeDIevISkoFJcpDrCmIR(A_0[i].NZqziYepfEXXCdWsTKulipskmgzF, A_1))
			{
				return i;
			}
		}
		return -1;
	}

	// Token: 0x060004F1 RID: 1265 RVA: 0x00032588 File Offset: 0x00030788
	private static int ljyADuqpuTVUerKRRsvimLHIjFJr(IList<npeFzFFBQqrIoNKuecNDbCOHzNtgA> A_0, npeFzFFBQqrIoNKuecNDbCOHzNtgA A_1)
	{
		if (A_0 == null || npeFzFFBQqrIoNKuecNDbCOHzNtgA.vvNQHaCQVeDIevISkoFJcpDrCmIR(A_1, null))
		{
			return -1;
		}
		for (int i = 0; i < A_0.Count; i++)
		{
			if (!npeFzFFBQqrIoNKuecNDbCOHzNtgA.vvNQHaCQVeDIevISkoFJcpDrCmIR(A_0[i], null) && npeFzFFBQqrIoNKuecNDbCOHzNtgA.vvNQHaCQVeDIevISkoFJcpDrCmIR(A_0[i], A_1))
			{
				return i;
			}
		}
		return -1;
	}

	// Token: 0x060004F3 RID: 1267 RVA: 0x00032628 File Offset: 0x00030828
	public static bool ZPtnnEeRhyxNaSbIiWfPijbXHoUE(string A_0, string A_1, ushort A_2, ushort A_3)
	{
		if (string.IsNullOrEmpty(A_0))
		{
			return false;
		}
		if (!string.IsNullOrEmpty(A_1))
		{
			for (int i = 0; i < yULinvLPouOJNlRPpStVQNhPEJys.hIxGCBHsWODFkEfQuIgkikwCjohPc.Length; i++)
			{
				if (A_1.Equals(yULinvLPouOJNlRPpStVQNhPEJys.hIxGCBHsWODFkEfQuIgkikwCjohPc[i], StringComparison.OrdinalIgnoreCase))
				{
					return true;
				}
			}
			for (int j = 0; j < yULinvLPouOJNlRPpStVQNhPEJys.deujvDAbtMqdObeDkNJMiFGECrSeA.Length; j++)
			{
				if (Regex.IsMatch(A_1, yULinvLPouOJNlRPpStVQNhPEJys.deujvDAbtMqdObeDkNJMiFGECrSeA[j], RegexOptions.IgnoreCase))
				{
					return true;
				}
			}
		}
		string[] array = A_0.Split('#', StringSplitOptions.None);
		if (array.Length < 2)
		{
			return false;
		}
		for (int k = 0; k < array.Length; k++)
		{
			string text = array[k].ToLower();
			if (text.Contains("pid_"))
			{
				int num = text.IndexOf("vid_");
				if (num >= 0 && text.IndexOf("ig_") >= num)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x04000613 RID: 1555
	private readonly List<IbdfoVkCYOJkjATrURkAWolxdaurA> iCvaoSjihuEFjMmokhQBjqSGVEdw;

	// Token: 0x04000614 RID: 1556
	private readonly ReadOnlyCollection<IbdfoVkCYOJkjATrURkAWolxdaurA> oBDCUcjbqwDlxAXUXEfjqAYfYDeQ;

	// Token: 0x04000615 RID: 1557
	private readonly List<npeFzFFBQqrIoNKuecNDbCOHzNtgA> ZqEBlJNFXprOHoVCnRCCQJrZFrNs;

	// Token: 0x04000616 RID: 1558
	private readonly Func<int> oXtoefAimYHBNhQcZoFvWLJUjhNtA;

	// Token: 0x04000617 RID: 1559
	private readonly SpinLock LbOfsSqBhmFkHhBZXuSoRusbIvTfA = new SpinLock();

	// Token: 0x04000618 RID: 1560
	private readonly SpinLock qYJlzdjsuYmUJUfbwxkGCKmRQpDL = new SpinLock();

	// Token: 0x04000619 RID: 1561
	private RingBuffer<yULinvLPouOJNlRPpStVQNhPEJys.GloBAbHSgCRenpPkPzXYafCMQIaoA> goJTPZcMipbfabTOqnzCcoNXPbiwA;

	// Token: 0x0400061A RID: 1562
	private RingBuffer<yULinvLPouOJNlRPpStVQNhPEJys.uBDUztooTbghwvNMiOMKXvJYjjzc> FzpYCJvvRrXxvJRgTxDGdwOmHRqG;

	// Token: 0x0400061B RID: 1563
	private bool agzBmYcJFmLLzImuDVieQJChUhIH;

	// Token: 0x0400061C RID: 1564
	private readonly ThreadSafeObjectPool<yULinvLPouOJNlRPpStVQNhPEJys.GloBAbHSgCRenpPkPzXYafCMQIaoA> zzeUjRHhzDgTOkyjmivNGRCdCZRd;

	// Token: 0x0400061D RID: 1565
	private readonly ThreadSafeObjectPool<yULinvLPouOJNlRPpStVQNhPEJys.uBDUztooTbghwvNMiOMKXvJYjjzc> byYYGBRZqSxQkrMoRTNXewyTdVOi;

	// Token: 0x0400061E RID: 1566
	private readonly List<IbdfoVkCYOJkjATrURkAWolxdaurA> xDAUijxMgIgUwbSYuXCoCSfUwhaMA;

	// Token: 0x0400061F RID: 1567
	private RingBuffer<yULinvLPouOJNlRPpStVQNhPEJys.GloBAbHSgCRenpPkPzXYafCMQIaoA> JZUopGwfENZkqVHJirupKuBGFxuj;

	// Token: 0x04000620 RID: 1568
	private RingBuffer<yULinvLPouOJNlRPpStVQNhPEJys.uBDUztooTbghwvNMiOMKXvJYjjzc> sTnIKuoWGalBPjFIIjdYcMoMpBxfb;

	// Token: 0x04000621 RID: 1569
	private bool uZGpKeKxWSnAnjEcShNUClWNKvZgb;

	// Token: 0x04000622 RID: 1570
	private Action<npeFzFFBQqrIoNKuecNDbCOHzNtgA, BnFiTEhittEzLCwZuNtphKZVBdZZA> dHhAHHEaXgbwtEzvhyWilaUNcqzqc;

	// Token: 0x04000624 RID: 1572
	private bool iNEjNXUmwqWFYexWuNXNvBKMnsir;

	// Token: 0x04000625 RID: 1573
	private static Guid[] IFkHjrGOulfPYJNPgLpZeheEUQbNB = new Guid[]
	{
		new Guid("02e0045e-0000-0000-0000-504944564944")
	};

	// Token: 0x04000626 RID: 1574
	private static string[] hIxGCBHsWODFkEfQuIgkikwCjohPc = new string[]
	{
		"Xbox Bluetooth Gamepad"
	};

	// Token: 0x04000627 RID: 1575
	private static string[] deujvDAbtMqdObeDkNJMiFGECrSeA = new string[]
	{
		"Xbox Wireless Controller.*"
	};

	// Token: 0x02000094 RID: 148
	private abstract class fJPxelDXmRzQnKiHJHQNYpkBDNHr : IPoolableObject, IDisposable, IPoolableObject_Internal
	{
		// Token: 0x060004F4 RID: 1268
		protected abstract void Clear();

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x060004F5 RID: 1269 RVA: 0x00013B31 File Offset: 0x00011D31
		// (set) Token: 0x060004F6 RID: 1270 RVA: 0x00013B39 File Offset: 0x00011D39
		IObjectPool IPoolableObject_Internal.pool { get; set; }

		// Token: 0x060004F7 RID: 1271 RVA: 0x00013B42 File Offset: 0x00011D42
		void IPoolableObject_Internal.Clear()
		{
			this.Clear();
		}

		// Token: 0x060004F8 RID: 1272 RVA: 0x00013B4A File Offset: 0x00011D4A
		void IDisposable.Dispose()
		{
			this.Return();
		}

		// Token: 0x060004F9 RID: 1273 RVA: 0x000326F0 File Offset: 0x000308F0
		public void Return()
		{
			IObjectPool pool = ((IPoolableObject_Internal)this).pool;
			if (pool != null)
			{
				pool.Return(this);
			}
		}

		// Token: 0x04000628 RID: 1576
		[CompilerGenerated]
		private IObjectPool xnAFawjKiLCwjmyxpiUSpIICOrtE;
	}

	// Token: 0x02000095 RID: 149
	private class GloBAbHSgCRenpPkPzXYafCMQIaoA : yULinvLPouOJNlRPpStVQNhPEJys.fJPxelDXmRzQnKiHJHQNYpkBDNHr
	{
		// Token: 0x060004FB RID: 1275 RVA: 0x00013B52 File Offset: 0x00011D52
		protected virtual void IgBBgEnStoVXMsAoRDzRBfmHasadA()
		{
			this.zNXWTDgAddtmddwopCTJCQseroDg = null;
			this.aMeaHrYISQacPcSDnCjBPvKwhbHP = default(OYybvidAyFwiwrJXZnlYENlOguncA);
			this.IodPuUauocpGZhaXzXFrOUbGFubP = 0.0;
		}

		// Token: 0x04000629 RID: 1577
		public npeFzFFBQqrIoNKuecNDbCOHzNtgA zNXWTDgAddtmddwopCTJCQseroDg;

		// Token: 0x0400062A RID: 1578
		public OYybvidAyFwiwrJXZnlYENlOguncA aMeaHrYISQacPcSDnCjBPvKwhbHP;

		// Token: 0x0400062B RID: 1579
		public double IodPuUauocpGZhaXzXFrOUbGFubP;
	}

	// Token: 0x02000096 RID: 150
	private sealed class uBDUztooTbghwvNMiOMKXvJYjjzc : yULinvLPouOJNlRPpStVQNhPEJys.fJPxelDXmRzQnKiHJHQNYpkBDNHr
	{
		// Token: 0x060004FD RID: 1277 RVA: 0x00013B7E File Offset: 0x00011D7E
		protected void YPuBKMjdnzakLjWSSQASVTcHJfgcA()
		{
			this.qnSqJtgsdmcaniSqFKkwsHBxUeCn = null;
			this.qPiKCvljENntAKhlVUXWHVjFGchK = default(BnFiTEhittEzLCwZuNtphKZVBdZZA);
		}

		// Token: 0x0400062C RID: 1580
		public npeFzFFBQqrIoNKuecNDbCOHzNtgA qnSqJtgsdmcaniSqFKkwsHBxUeCn;

		// Token: 0x0400062D RID: 1581
		public BnFiTEhittEzLCwZuNtphKZVBdZZA qPiKCvljENntAKhlVUXWHVjFGchK;
	}

	// Token: 0x02000097 RID: 151
	[CompilerGenerated]
	[Serializable]
	private sealed class vIdHFciaQRtjpQwFvdqDrHDUhwwY
	{
		// Token: 0x06000501 RID: 1281 RVA: 0x00013B9F File Offset: 0x00011D9F
		internal yULinvLPouOJNlRPpStVQNhPEJys.GloBAbHSgCRenpPkPzXYafCMQIaoA QMIhiNbHfCzHECAJBtBaquNxgPrC()
		{
			return new yULinvLPouOJNlRPpStVQNhPEJys.GloBAbHSgCRenpPkPzXYafCMQIaoA();
		}

		// Token: 0x06000502 RID: 1282 RVA: 0x00013BA6 File Offset: 0x00011DA6
		internal yULinvLPouOJNlRPpStVQNhPEJys.uBDUztooTbghwvNMiOMKXvJYjjzc LkSitkCZFTYYEPLryxiSPJJbZOpI()
		{
			return new yULinvLPouOJNlRPpStVQNhPEJys.uBDUztooTbghwvNMiOMKXvJYjjzc();
		}

		// Token: 0x0400062E RID: 1582
		public static readonly yULinvLPouOJNlRPpStVQNhPEJys.vIdHFciaQRtjpQwFvdqDrHDUhwwY <>9 = new yULinvLPouOJNlRPpStVQNhPEJys.vIdHFciaQRtjpQwFvdqDrHDUhwwY();

		// Token: 0x0400062F RID: 1583
		public static Func<yULinvLPouOJNlRPpStVQNhPEJys.GloBAbHSgCRenpPkPzXYafCMQIaoA> <>9__19_0;

		// Token: 0x04000630 RID: 1584
		public static Func<yULinvLPouOJNlRPpStVQNhPEJys.uBDUztooTbghwvNMiOMKXvJYjjzc> <>9__19_1;
	}
}
