using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Rewired;
using Rewired.Data;
using Rewired.Data.Mapping;
using Rewired.InputSources.SDL2;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Utils;

// Token: 0x020002C1 RID: 705
internal class SOdhOppsHkwNoqWKEsAKumLAEPWY : PlatformInputManager
{
	// Token: 0x060014A7 RID: 5287 RVA: 0x0004924C File Offset: 0x0004744C
	public SOdhOppsHkwNoqWKEsAKumLAEPWY(ConfigVars A_1, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> A_2, Func<int> A_3, bool A_4, bool A_5, bool A_6)
	{
		try
		{
			this.svResSuCuGNRpOZbgikUKLzfYaAn = A_2;
			this.sYxFRYDEfwEEEhHjeorROJeFlTGpD = A_3;
			this.ZebYhQOPBZaYCbdiYfxMGZfEBUts = A_4;
			this.LWazbafOBLoCwZLWSoHNdESqsZCL = A_5;
			this.BShQRDaSiqnLgNFLhLOdqqvjoTGS = A_6;
			this.wAqKIrxLGPEGOtmVGokUwhGhlMNr = this;
			this.eayKcEUkVYbwpESHeHFWKEBcQmogA = new SDL2InputSource(A_1.updateLoop, A_4, A_4, A_5, A_6);
			this.uFkDSykBpwoKEkPJQfwmjhtltcoOA = new Action<int, ControllerDataUpdater>(this.UpdateControllerData);
			this.eayKcEUkVYbwpESHeHFWKEBcQmogA.DeviceChangedEvent += this.OifLCzdhppTsJvQdRNvzCkIyFrraA;
		}
		catch (Exception)
		{
			this.OnDestroy();
			throw;
		}
	}

	// Token: 0x1700033B RID: 827
	// (get) Token: 0x060014A8 RID: 5288 RVA: 0x0001B98D File Offset: 0x00019B8D
	[CustomObfuscation(rename = false)]
	public override int deviceCount
	{
		get
		{
			return this.jqpZxIREdvqTXdBwmRrRgcjyEflH;
		}
	}

	// Token: 0x1700033C RID: 828
	// (get) Token: 0x060014A9 RID: 5289 RVA: 0x0001B995 File Offset: 0x00019B95
	[CustomObfuscation(rename = false)]
	public override PlatformInputManager primaryInputManager
	{
		get
		{
			return this.wAqKIrxLGPEGOtmVGokUwhGhlMNr;
		}
	}

	// Token: 0x1700033D RID: 829
	// (get) Token: 0x060014AA RID: 5290 RVA: 0x0001B99D File Offset: 0x00019B9D
	[CustomObfuscation(rename = false)]
	public override IInputSource inputSource
	{
		get
		{
			return this.eayKcEUkVYbwpESHeHFWKEBcQmogA;
		}
	}

	// Token: 0x1700033E RID: 830
	// (get) Token: 0x060014AB RID: 5291 RVA: 0x0001B9A5 File Offset: 0x00019BA5
	[CustomObfuscation(rename = false)]
	public override InputSource inputSourceType
	{
		get
		{
			return InputSource.SDL2;
		}
	}

	// Token: 0x060014AC RID: 5292 RVA: 0x0001B9A9 File Offset: 0x00019BA9
	[CustomObfuscation(rename = false)]
	public override void Initialize()
	{
		if (this.ZebYhQOPBZaYCbdiYfxMGZfEBUts)
		{
			this.TnoCEpCUTEvjGArtoNfjWBxUrgvSA = new SOdhOppsHkwNoqWKEsAKumLAEPWY.eQbacLZJTniCaSExlwvFVsMtiaKb();
			this.SojcagNmdiYEpNFXTfsTZmurcgfD();
		}
	}

	// Token: 0x060014AD RID: 5293 RVA: 0x000492EC File Offset: 0x000474EC
	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		if (this.eayKcEUkVYbwpESHeHFWKEBcQmogA != null)
		{
			this.eayKcEUkVYbwpESHeHFWKEBcQmogA.Update();
		}
		if (this.ZebYhQOPBZaYCbdiYfxMGZfEBUts)
		{
			if (this.mODBcEWilRcgZeSFAwBpQfhlZZGpA)
			{
				this.bYtRAxNjjpjpgkHmMtuqMAYpjbyY();
			}
			if (this.eayKcEUkVYbwpESHeHFWKEBcQmogA != null)
			{
				for (int i = 0; i < this.jqpZxIREdvqTXdBwmRrRgcjyEflH; i++)
				{
					SOdhOppsHkwNoqWKEsAKumLAEPWY.wjFGpzhPvGZUiYJRtvzzxtorJfIj wjFGpzhPvGZUiYJRtvzzxtorJfIj = this.bGXqqfaMPMwNmVNIrcNcfXMsblwdA[i];
					if (wjFGpzhPvGZUiYJRtvzzxtorJfIj != null)
					{
						wjFGpzhPvGZUiYJRtvzzxtorJfIj.XUCDpkjMbrfxCfonfmGqWlwzlHnhA.jhrjQWWIhyHFSgsZMpAkLybqogDvA(updateLoop);
					}
				}
				this.eayKcEUkVYbwpESHeHFWKEBcQmogA.UpdateDevices(updateLoop);
			}
			this.PwYjXAsQbVuhRWwpMRfcSvOsbOjf();
			if (this.eayKcEUkVYbwpESHeHFWKEBcQmogA != null)
			{
				this.eayKcEUkVYbwpESHeHFWKEBcQmogA.UpdateFinished();
				for (int j = 0; j < this.jqpZxIREdvqTXdBwmRrRgcjyEflH; j++)
				{
					SOdhOppsHkwNoqWKEsAKumLAEPWY.wjFGpzhPvGZUiYJRtvzzxtorJfIj wjFGpzhPvGZUiYJRtvzzxtorJfIj2 = this.bGXqqfaMPMwNmVNIrcNcfXMsblwdA[j];
					if (wjFGpzhPvGZUiYJRtvzzxtorJfIj2 != null)
					{
						wjFGpzhPvGZUiYJRtvzzxtorJfIj2.XUCDpkjMbrfxCfonfmGqWlwzlHnhA.BFWZNWbMSYBBaJhRACGnXookekEuA();
					}
				}
			}
		}
		bool lwazbafOBLoCwZLWSoHNdESqsZCL = this.LWazbafOBLoCwZLWSoHNdESqsZCL;
	}

	// Token: 0x060014AE RID: 5294 RVA: 0x000493B4 File Offset: 0x000475B4
	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (this.bGXqqfaMPMwNmVNIrcNcfXMsblwdA != null)
		{
			int count = this.bGXqqfaMPMwNmVNIrcNcfXMsblwdA.Count;
			for (int i = 0; i < count; i++)
			{
				if (this.bGXqqfaMPMwNmVNIrcNcfXMsblwdA[i] != null)
				{
					gAkEWbhxgbYyrIrsrBCPaLxymaOwA xucdpkjMbrfxCfonfmGqWlwzlHnhA = this.bGXqqfaMPMwNmVNIrcNcfXMsblwdA[i].XUCDpkjMbrfxCfonfmGqWlwzlHnhA;
					if (xucdpkjMbrfxCfonfmGqWlwzlHnhA != null)
					{
						xucdpkjMbrfxCfonfmGqWlwzlHnhA.uYqsDWdcfkvDBOqNPNNDGdKDCvwN();
					}
				}
			}
		}
		if (this.eayKcEUkVYbwpESHeHFWKEBcQmogA != null)
		{
			this.eayKcEUkVYbwpESHeHFWKEBcQmogA.Dispose();
		}
	}

	// Token: 0x060014AF RID: 5295 RVA: 0x0001B9C4 File Offset: 0x00019BC4
	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return this.uFkDSykBpwoKEkPJQfwmjhtltcoOA;
	}

	// Token: 0x060014B0 RID: 5296 RVA: 0x00049420 File Offset: 0x00047620
	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
	{
		if (!this.ZebYhQOPBZaYCbdiYfxMGZfEBUts)
		{
			return;
		}
		for (int i = 0; i < this.jqpZxIREdvqTXdBwmRrRgcjyEflH; i++)
		{
			if (this.bGXqqfaMPMwNmVNIrcNcfXMsblwdA[i].inputManagerId == inputManagerId)
			{
				this.bGXqqfaMPMwNmVNIrcNcfXMsblwdA[i].FillData(data);
				return;
			}
		}
	}

	// Token: 0x060014B1 RID: 5297 RVA: 0x0001B9CC File Offset: 0x00019BCC
	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		if (this.ZebYhQOPBZaYCbdiYfxMGZfEBUts)
		{
			this.mODBcEWilRcgZeSFAwBpQfhlZZGpA = true;
		}
		if (this._SystemDeviceConnectedEvent != null)
		{
			this._SystemDeviceConnectedEvent();
		}
	}

	// Token: 0x060014B2 RID: 5298 RVA: 0x0001B9F0 File Offset: 0x00019BF0
	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		if (this.ZebYhQOPBZaYCbdiYfxMGZfEBUts)
		{
			this.mODBcEWilRcgZeSFAwBpQfhlZZGpA = true;
		}
		if (this._SystemDeviceDisconnectedEvent != null)
		{
			this._SystemDeviceDisconnectedEvent();
		}
	}

	// Token: 0x060014B3 RID: 5299 RVA: 0x0001BA14 File Offset: 0x00019C14
	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
		bool zebYhQOPBZaYCbdiYfxMGZfEBUts = this.ZebYhQOPBZaYCbdiYfxMGZfEBUts;
	}

	// Token: 0x060014B4 RID: 5300 RVA: 0x000116EB File Offset: 0x0000F8EB
	[CustomObfuscation(rename = false)]
	public override IUnifiedMouseSource GetUnifiedMouseSource()
	{
		return null;
	}

	// Token: 0x060014B5 RID: 5301 RVA: 0x000116EB File Offset: 0x0000F8EB
	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		return null;
	}

	// Token: 0x060014B6 RID: 5302 RVA: 0x0001BA1D File Offset: 0x00019C1D
	private void SojcagNmdiYEpNFXTfsTZmurcgfD()
	{
		this.kekGCTvZpmMwbcfxcASiHfXhZkiB(this.BruNjVDGnrlJzvjEnBJJuhkQrFFQ());
	}

	// Token: 0x060014B7 RID: 5303 RVA: 0x00049470 File Offset: 0x00047670
	private void kekGCTvZpmMwbcfxcASiHfXhZkiB(IList<gAkEWbhxgbYyrIrsrBCPaLxymaOwA> A_1)
	{
		int num = 0;
		List<SOdhOppsHkwNoqWKEsAKumLAEPWY.wjFGpzhPvGZUiYJRtvzzxtorJfIj> list = this.bGXqqfaMPMwNmVNIrcNcfXMsblwdA;
		int num2 = this.jqpZxIREdvqTXdBwmRrRgcjyEflH;
		this.bGXqqfaMPMwNmVNIrcNcfXMsblwdA = new List<SOdhOppsHkwNoqWKEsAKumLAEPWY.wjFGpzhPvGZUiYJRtvzzxtorJfIj>();
		int count = A_1.Count;
		for (int i = 0; i < count; i++)
		{
			if (A_1[i] != null)
			{
				gAkEWbhxgbYyrIrsrBCPaLxymaOwA gAkEWbhxgbYyrIrsrBCPaLxymaOwA = A_1[i];
				SOdhOppsHkwNoqWKEsAKumLAEPWY.wjFGpzhPvGZUiYJRtvzzxtorJfIj wjFGpzhPvGZUiYJRtvzzxtorJfIj = new SOdhOppsHkwNoqWKEsAKumLAEPWY.wjFGpzhPvGZUiYJRtvzzxtorJfIj(this.svResSuCuGNRpOZbgikUKLzfYaAn);
				wjFGpzhPvGZUiYJRtvzzxtorJfIj.XUCDpkjMbrfxCfonfmGqWlwzlHnhA = gAkEWbhxgbYyrIrsrBCPaLxymaOwA;
				wjFGpzhPvGZUiYJRtvzzxtorJfIj.zSkjyGyleJHpnFakwerDkyVEQgfMA = gAkEWbhxgbYyrIrsrBCPaLxymaOwA.PfokuKhRExBXjqwNRFsFhtUEOIqk;
				wjFGpzhPvGZUiYJRtvzzxtorJfIj.GGOnnIVoRizSfgxiWPBsgjZwWaHj = gAkEWbhxgbYyrIrsrBCPaLxymaOwA.unZYaKznDCgLUnmQnPpLeEmszMjn;
				wjFGpzhPvGZUiYJRtvzzxtorJfIj.hmTbqrPKPzxmuIRROFoHJdumZKoE = gAkEWbhxgbYyrIrsrBCPaLxymaOwA.lxQFxkEwUnJIVapHQCjCxLAQPtFz;
				wjFGpzhPvGZUiYJRtvzzxtorJfIj.ImRfHTWKydcDlGXrWdwlrrinlYUS = gAkEWbhxgbYyrIrsrBCPaLxymaOwA.bgECXHIkOHjQKARwiIEGVpOlEqAD;
				wjFGpzhPvGZUiYJRtvzzxtorJfIj.VllEdkJBFREECFGrIvtwDGOehphSC = gAkEWbhxgbYyrIrsrBCPaLxymaOwA.HvSbzTGVAxGOwHNXWIqUZQgEjiSlA;
				wjFGpzhPvGZUiYJRtvzzxtorJfIj.MDaIfmELlHYxcLUaBViEdboPDMiwA = gAkEWbhxgbYyrIrsrBCPaLxymaOwA.uhXckWeZRYMsAQYYkWPpbOzmhTuX;
				wjFGpzhPvGZUiYJRtvzzxtorJfIj.HjWbMMNOHoKixJtQtKnjIGuiNYgh = gAkEWbhxgbYyrIrsrBCPaLxymaOwA.iyBMEgPsJKChrbMLumpLOIgcIDIjA;
				wjFGpzhPvGZUiYJRtvzzxtorJfIj.cfeRKUffURKBKeOCMyDnJtkOlUFC = gAkEWbhxgbYyrIrsrBCPaLxymaOwA.wRPKEIiIMIiVkFuDoAhjfeDkorcvB;
				wjFGpzhPvGZUiYJRtvzzxtorJfIj.hMpyylQdVKbgBPfPfiMWBfQzRMnG = gAkEWbhxgbYyrIrsrBCPaLxymaOwA.KCoPWTNCdmhpOfarIjSQwtNBOnGhb;
				wjFGpzhPvGZUiYJRtvzzxtorJfIj.jYfXZqaPxUpWStdGpTXslBdgizQeA = gAkEWbhxgbYyrIrsrBCPaLxymaOwA.aRRgiRVgPIFTpWYYFshJIMpuFgwP;
				wjFGpzhPvGZUiYJRtvzzxtorJfIj.fZfrSQNqWYAMIPUKQrPXlNmplWbb = gAkEWbhxgbYyrIrsrBCPaLxymaOwA.LvoZSYWOkcOyruNQCtYUOxHhDWw;
				wjFGpzhPvGZUiYJRtvzzxtorJfIj.MlavMGYOCvAwPMCAzuPjZZwKoftq = gAkEWbhxgbYyrIrsrBCPaLxymaOwA.qcsdXjybeTWgZfQMHiWLhJTmnsue;
				wjFGpzhPvGZUiYJRtvzzxtorJfIj.hDBvPTAAooiMAhKNSvdwMHigbncl = gAkEWbhxgbYyrIrsrBCPaLxymaOwA.SeYdqkLoQydEjCzfAzTgcjvypQMpA;
				wjFGpzhPvGZUiYJRtvzzxtorJfIj.mNUkhjxnaBrlwdZXBKGffCPKFPrKA = gAkEWbhxgbYyrIrsrBCPaLxymaOwA.JxRIBEsrIMhGRNlrzAEhnRyUbTVL;
				wjFGpzhPvGZUiYJRtvzzxtorJfIj.extension = gAkEWbhxgbYyrIrsrBCPaLxymaOwA.ySfzhFAznYniKHKeZhqYMZItcAxG;
				gAkEWbhxgbYyrIrsrBCPaLxymaOwA.yiTyAnDstqgDdSYBMIlisXELjikd();
				wjFGpzhPvGZUiYJRtvzzxtorJfIj.EQHAwlAmwjYThKhwONGfHOVbYqKv();
				this.bGXqqfaMPMwNmVNIrcNcfXMsblwdA.Add(wjFGpzhPvGZUiYJRtvzzxtorJfIj);
				num++;
			}
		}
		this.jqpZxIREdvqTXdBwmRrRgcjyEflH = num;
		this.byhogTvBLEAeqOyIeaxrKqjdGPCk(num2, num, list, this.bGXqqfaMPMwNmVNIrcNcfXMsblwdA);
		for (int j = 0; j < num; j++)
		{
			if (this._UpdateControllerInfoEvent != null)
			{
				this._UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(this.bGXqqfaMPMwNmVNIrcNcfXMsblwdA[j]));
			}
		}
		this.ZTpUPlXEoofyCDKpUpjYaQhjYXkWA(list, this.bGXqqfaMPMwNmVNIrcNcfXMsblwdA, false);
		this.ZTpUPlXEoofyCDKpUpjYaQhjYXkWA(this.bGXqqfaMPMwNmVNIrcNcfXMsblwdA, list, true);
	}

	// Token: 0x060014B8 RID: 5304 RVA: 0x0004963C File Offset: 0x0004783C
	private void PwYjXAsQbVuhRWwpMRfcSvOsbOjf()
	{
		for (int i = 0; i < this.jqpZxIREdvqTXdBwmRrRgcjyEflH; i++)
		{
			SOdhOppsHkwNoqWKEsAKumLAEPWY.wjFGpzhPvGZUiYJRtvzzxtorJfIj wjFGpzhPvGZUiYJRtvzzxtorJfIj = this.bGXqqfaMPMwNmVNIrcNcfXMsblwdA[i];
			if (wjFGpzhPvGZUiYJRtvzzxtorJfIj != null)
			{
				wjFGpzhPvGZUiYJRtvzzxtorJfIj.Update();
			}
		}
	}

	// Token: 0x060014B9 RID: 5305 RVA: 0x00049670 File Offset: 0x00047870
	private bool nawqWvpcjSsJWpVnMmfojpGOZPHb(QWwLqtkMlbiJnhExHgcNehpVJThK A_1)
	{
		bool result;
		try
		{
			result = A_1.lZxoAcunJRsmNxeTdGwustQczTgB();
		}
		catch
		{
			result = false;
		}
		return result;
	}

	// Token: 0x060014BA RID: 5306 RVA: 0x0001BA2B File Offset: 0x00019C2B
	private IList<gAkEWbhxgbYyrIrsrBCPaLxymaOwA> BruNjVDGnrlJzvjEnBJJuhkQrFFQ()
	{
		return this.eayKcEUkVYbwpESHeHFWKEBcQmogA.GetJoysticks<gAkEWbhxgbYyrIrsrBCPaLxymaOwA>();
	}

	// Token: 0x060014BB RID: 5307 RVA: 0x0004969C File Offset: 0x0004789C
	private void byhogTvBLEAeqOyIeaxrKqjdGPCk(int A_1, int A_2, List<SOdhOppsHkwNoqWKEsAKumLAEPWY.wjFGpzhPvGZUiYJRtvzzxtorJfIj> A_3, List<SOdhOppsHkwNoqWKEsAKumLAEPWY.wjFGpzhPvGZUiYJRtvzzxtorJfIj> A_4)
	{
		if (A_2 > 0)
		{
			A_4.Sort(new Comparison<SOdhOppsHkwNoqWKEsAKumLAEPWY.wjFGpzhPvGZUiYJRtvzzxtorJfIj>(SOdhOppsHkwNoqWKEsAKumLAEPWY.wjFGpzhPvGZUiYJRtvzzxtorJfIj.wusCvvCrZVqRxsULBQoYkOmgwQsmA));
		}
		if (A_1 > 0 && A_2 > 0)
		{
			this.dbtglfrofXZNrfDGRUgVWchslewN(A_2, A_4, A_1, A_3, SOdhOppsHkwNoqWKEsAKumLAEPWY.eQbacLZJTniCaSExlwvFVsMtiaKb.MkhVFYeRwqOLJBkgkFsqnUTqfmdhA.Exact);
			this.dbtglfrofXZNrfDGRUgVWchslewN(A_2, A_4, A_1, A_3, SOdhOppsHkwNoqWKEsAKumLAEPWY.eQbacLZJTniCaSExlwvFVsMtiaKb.MkhVFYeRwqOLJBkgkFsqnUTqfmdhA.Approximate);
		}
		this.YoKcbtiHgZmXUyHglshiaqEuXebp(A_2, A_4, SOdhOppsHkwNoqWKEsAKumLAEPWY.eQbacLZJTniCaSExlwvFVsMtiaKb.MkhVFYeRwqOLJBkgkFsqnUTqfmdhA.Exact);
		this.YoKcbtiHgZmXUyHglshiaqEuXebp(A_2, A_4, SOdhOppsHkwNoqWKEsAKumLAEPWY.eQbacLZJTniCaSExlwvFVsMtiaKb.MkhVFYeRwqOLJBkgkFsqnUTqfmdhA.Approximate);
		for (int i = 0; i < A_2; i++)
		{
			SOdhOppsHkwNoqWKEsAKumLAEPWY.wjFGpzhPvGZUiYJRtvzzxtorJfIj wjFGpzhPvGZUiYJRtvzzxtorJfIj = A_4[i];
			if (wjFGpzhPvGZUiYJRtvzzxtorJfIj != null && wjFGpzhPvGZUiYJRtvzzxtorJfIj.inputManagerId < 0)
			{
				wjFGpzhPvGZUiYJRtvzzxtorJfIj.inputManagerId = this.AfObGhjFBkDHqrlZLLLrYkmzHEqcb(A_4);
				wjFGpzhPvGZUiYJRtvzzxtorJfIj.rewiredId = this.sYxFRYDEfwEEEhHjeorROJeFlTGpD();
				this.TnoCEpCUTEvjGArtoNfjWBxUrgvSA.iSgSVUypTIeQaJfjTIvXHslmjbmdb(wjFGpzhPvGZUiYJRtvzzxtorJfIj);
			}
		}
		A_4.Sort(new Comparison<SOdhOppsHkwNoqWKEsAKumLAEPWY.wjFGpzhPvGZUiYJRtvzzxtorJfIj>(SOdhOppsHkwNoqWKEsAKumLAEPWY.wjFGpzhPvGZUiYJRtvzzxtorJfIj.ZpIWBpVgBhLCEROpbIAOqORhqjIN));
	}

	// Token: 0x060014BC RID: 5308 RVA: 0x00049758 File Offset: 0x00047958
	private void XVElHRonJArTvrHpBLkozWlMgOCw(List<SOdhOppsHkwNoqWKEsAKumLAEPWY.wjFGpzhPvGZUiYJRtvzzxtorJfIj> A_1, int A_2, int A_3)
	{
		int count = A_1.Count;
		for (int i = 0; i < count; i++)
		{
			if (i != A_2 && A_1[i] != null && A_1[i].inputManagerId == A_3)
			{
				A_1[i].inputManagerId = -1;
			}
		}
	}

	// Token: 0x060014BD RID: 5309 RVA: 0x000497A4 File Offset: 0x000479A4
	private bool sksrwfcAPuzCOZrOMqolrjuNokdr(List<SOdhOppsHkwNoqWKEsAKumLAEPWY.wjFGpzhPvGZUiYJRtvzzxtorJfIj> A_1, int A_2)
	{
		int count = A_1.Count;
		for (int i = 0; i < count; i++)
		{
			if (A_1[i] != null && A_1[i].inputManagerId == A_2)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x060014BE RID: 5310 RVA: 0x000497E0 File Offset: 0x000479E0
	private int AfObGhjFBkDHqrlZLLLrYkmzHEqcb(List<SOdhOppsHkwNoqWKEsAKumLAEPWY.wjFGpzhPvGZUiYJRtvzzxtorJfIj> A_1)
	{
		int num = 0;
		for (;;)
		{
			bool flag = false;
			int count = A_1.Count;
			for (int i = 0; i < count; i++)
			{
				if (A_1[i] != null && A_1[i].inputManagerId == num)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				break;
			}
			num++;
		}
		return num;
	}

	// Token: 0x060014BF RID: 5311 RVA: 0x0004982C File Offset: 0x00047A2C
	private bool XcAikGShmVBnFgjhBgLKZxMDNVxF(List<SOdhOppsHkwNoqWKEsAKumLAEPWY.wjFGpzhPvGZUiYJRtvzzxtorJfIj> A_1, int A_2)
	{
		if (A_1 == null)
		{
			return false;
		}
		for (int i = 0; i < A_1.Count; i++)
		{
			if (A_1[i].rewiredId == A_2)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060014C0 RID: 5312 RVA: 0x00049864 File Offset: 0x00047A64
	private void dbtglfrofXZNrfDGRUgVWchslewN(int A_1, List<SOdhOppsHkwNoqWKEsAKumLAEPWY.wjFGpzhPvGZUiYJRtvzzxtorJfIj> A_2, int A_3, List<SOdhOppsHkwNoqWKEsAKumLAEPWY.wjFGpzhPvGZUiYJRtvzzxtorJfIj> A_4, SOdhOppsHkwNoqWKEsAKumLAEPWY.eQbacLZJTniCaSExlwvFVsMtiaKb.MkhVFYeRwqOLJBkgkFsqnUTqfmdhA A_5)
	{
		int num = (A_5 == SOdhOppsHkwNoqWKEsAKumLAEPWY.eQbacLZJTniCaSExlwvFVsMtiaKb.MkhVFYeRwqOLJBkgkFsqnUTqfmdhA.Exact) ? 2 : 1;
		for (int i = 0; i < A_1; i++)
		{
			SOdhOppsHkwNoqWKEsAKumLAEPWY.wjFGpzhPvGZUiYJRtvzzxtorJfIj wjFGpzhPvGZUiYJRtvzzxtorJfIj = A_2[i];
			if (wjFGpzhPvGZUiYJRtvzzxtorJfIj != null && wjFGpzhPvGZUiYJRtvzzxtorJfIj.inputManagerId < 0)
			{
				for (int j = 0; j < A_3; j++)
				{
					SOdhOppsHkwNoqWKEsAKumLAEPWY.wjFGpzhPvGZUiYJRtvzzxtorJfIj wjFGpzhPvGZUiYJRtvzzxtorJfIj2 = A_4[j];
					if (wjFGpzhPvGZUiYJRtvzzxtorJfIj2 != null && !this.XcAikGShmVBnFgjhBgLKZxMDNVxF(A_2, wjFGpzhPvGZUiYJRtvzzxtorJfIj2.rewiredId) && wjFGpzhPvGZUiYJRtvzzxtorJfIj.IWYAmWmvQnngixlseAhqdYcwOao(wjFGpzhPvGZUiYJRtvzzxtorJfIj2) >= num)
					{
						wjFGpzhPvGZUiYJRtvzzxtorJfIj.eQXRyOBsjzmEyVUPUOFhLBAmEWSj(wjFGpzhPvGZUiYJRtvzzxtorJfIj2);
						this.TnoCEpCUTEvjGArtoNfjWBxUrgvSA.iSgSVUypTIeQaJfjTIvXHslmjbmdb(wjFGpzhPvGZUiYJRtvzzxtorJfIj);
					}
				}
			}
		}
	}

	// Token: 0x060014C1 RID: 5313 RVA: 0x000498E4 File Offset: 0x00047AE4
	private void YoKcbtiHgZmXUyHglshiaqEuXebp(int A_1, List<SOdhOppsHkwNoqWKEsAKumLAEPWY.wjFGpzhPvGZUiYJRtvzzxtorJfIj> A_2, SOdhOppsHkwNoqWKEsAKumLAEPWY.eQbacLZJTniCaSExlwvFVsMtiaKb.MkhVFYeRwqOLJBkgkFsqnUTqfmdhA A_3)
	{
		for (int i = 0; i < A_1; i++)
		{
			SOdhOppsHkwNoqWKEsAKumLAEPWY.wjFGpzhPvGZUiYJRtvzzxtorJfIj wjFGpzhPvGZUiYJRtvzzxtorJfIj = A_2[i];
			if (wjFGpzhPvGZUiYJRtvzzxtorJfIj != null && wjFGpzhPvGZUiYJRtvzzxtorJfIj.inputManagerId < 0)
			{
				SOdhOppsHkwNoqWKEsAKumLAEPWY.eQbacLZJTniCaSExlwvFVsMtiaKb.PSGVtTmDZaEbrJtmutKHqxqubvpUA psgvtTmDZaEbrJtmutKHqxqubvpUA = null;
				foreach (SOdhOppsHkwNoqWKEsAKumLAEPWY.eQbacLZJTniCaSExlwvFVsMtiaKb.PSGVtTmDZaEbrJtmutKHqxqubvpUA psgvtTmDZaEbrJtmutKHqxqubvpUA2 in this.TnoCEpCUTEvjGArtoNfjWBxUrgvSA.AySMoFhxtmRcwIpxzesicVrSKeOab(wjFGpzhPvGZUiYJRtvzzxtorJfIj, A_3))
				{
					if (!this.XcAikGShmVBnFgjhBgLKZxMDNVxF(A_2, psgvtTmDZaEbrJtmutKHqxqubvpUA2.dApPKzsOyzFNOBtjNZbOLBcteyDE) && psgvtTmDZaEbrJtmutKHqxqubvpUA2.GaIhjDJBCAkKKRvrvIXCTBFFmYWT >= 0)
					{
						psgvtTmDZaEbrJtmutKHqxqubvpUA = psgvtTmDZaEbrJtmutKHqxqubvpUA2;
						break;
					}
				}
				if (psgvtTmDZaEbrJtmutKHqxqubvpUA != null)
				{
					int num = psgvtTmDZaEbrJtmutKHqxqubvpUA.GaIhjDJBCAkKKRvrvIXCTBFFmYWT;
					if (!this.sksrwfcAPuzCOZrOMqolrjuNokdr(A_2, num))
					{
						num = this.AfObGhjFBkDHqrlZLLLrYkmzHEqcb(A_2);
						psgvtTmDZaEbrJtmutKHqxqubvpUA.GaIhjDJBCAkKKRvrvIXCTBFFmYWT = num;
					}
					wjFGpzhPvGZUiYJRtvzzxtorJfIj.inputManagerId = num;
					wjFGpzhPvGZUiYJRtvzzxtorJfIj.rewiredId = psgvtTmDZaEbrJtmutKHqxqubvpUA.dApPKzsOyzFNOBtjNZbOLBcteyDE;
					this.TnoCEpCUTEvjGArtoNfjWBxUrgvSA.iSgSVUypTIeQaJfjTIvXHslmjbmdb(wjFGpzhPvGZUiYJRtvzzxtorJfIj);
				}
			}
		}
	}

	// Token: 0x060014C2 RID: 5314 RVA: 0x000499C8 File Offset: 0x00047BC8
	private void bYtRAxNjjpjpgkHmMtuqMAYpjbyY()
	{
		IList<gAkEWbhxgbYyrIrsrBCPaLxymaOwA> list = this.BruNjVDGnrlJzvjEnBJJuhkQrFFQ();
		this.kekGCTvZpmMwbcfxcASiHfXhZkiB(list);
		this.mODBcEWilRcgZeSFAwBpQfhlZZGpA = false;
	}

	// Token: 0x060014C3 RID: 5315 RVA: 0x000499EC File Offset: 0x00047BEC
	private bool OOwOuOxCQnpdBJFGZafGVLNcxewp(IList<gAkEWbhxgbYyrIrsrBCPaLxymaOwA> A_1)
	{
		int count = A_1.Count;
		for (int i = 0; i < count; i++)
		{
			if (A_1[i] != null && !this.ahKgvJemZgBsuZVZlwgYnZKziHyGA(A_1[i].PfokuKhRExBXjqwNRFsFhtUEOIqk))
			{
				return true;
			}
		}
		int count2 = this.bGXqqfaMPMwNmVNIrcNcfXMsblwdA.Count;
		for (int j = 0; j < count2; j++)
		{
			if (this.bGXqqfaMPMwNmVNIrcNcfXMsblwdA[j] != null && !this.VGpeJBbMRsaVSvlhIRYZEXNZSRPrA(A_1, this.bGXqqfaMPMwNmVNIrcNcfXMsblwdA[j].zSkjyGyleJHpnFakwerDkyVEQgfMA))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060014C4 RID: 5316 RVA: 0x00049A70 File Offset: 0x00047C70
	private bool ahKgvJemZgBsuZVZlwgYnZKziHyGA(Guid A_1)
	{
		int count = this.bGXqqfaMPMwNmVNIrcNcfXMsblwdA.Count;
		for (int i = 0; i < count; i++)
		{
			if (this.bGXqqfaMPMwNmVNIrcNcfXMsblwdA[i] != null && this.bGXqqfaMPMwNmVNIrcNcfXMsblwdA[i].zSkjyGyleJHpnFakwerDkyVEQgfMA == A_1)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060014C5 RID: 5317 RVA: 0x00049AC0 File Offset: 0x00047CC0
	private bool VGpeJBbMRsaVSvlhIRYZEXNZSRPrA(IList<gAkEWbhxgbYyrIrsrBCPaLxymaOwA> A_1, Guid A_2)
	{
		int count = A_1.Count;
		for (int i = 0; i < count; i++)
		{
			if (A_1[i] != null && A_1[i].PfokuKhRExBXjqwNRFsFhtUEOIqk == A_2)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060014C6 RID: 5318 RVA: 0x00049B00 File Offset: 0x00047D00
	private void ZTpUPlXEoofyCDKpUpjYaQhjYXkWA(List<SOdhOppsHkwNoqWKEsAKumLAEPWY.wjFGpzhPvGZUiYJRtvzzxtorJfIj> A_1, List<SOdhOppsHkwNoqWKEsAKumLAEPWY.wjFGpzhPvGZUiYJRtvzzxtorJfIj> A_2, bool A_3)
	{
		if (A_1 == null)
		{
			return;
		}
		int num = (A_1 != null) ? A_1.Count : 0;
		int num2 = (A_2 != null) ? A_2.Count : 0;
		for (int i = 0; i < num; i++)
		{
			SOdhOppsHkwNoqWKEsAKumLAEPWY.wjFGpzhPvGZUiYJRtvzzxtorJfIj wjFGpzhPvGZUiYJRtvzzxtorJfIj = A_1[i];
			if (wjFGpzhPvGZUiYJRtvzzxtorJfIj != null)
			{
				bool flag = false;
				if (A_2 != null)
				{
					for (int j = 0; j < num2; j++)
					{
						SOdhOppsHkwNoqWKEsAKumLAEPWY.wjFGpzhPvGZUiYJRtvzzxtorJfIj wjFGpzhPvGZUiYJRtvzzxtorJfIj2 = A_2[j];
						if (wjFGpzhPvGZUiYJRtvzzxtorJfIj2 != null && wjFGpzhPvGZUiYJRtvzzxtorJfIj.zSkjyGyleJHpnFakwerDkyVEQgfMA == wjFGpzhPvGZUiYJRtvzzxtorJfIj2.zSkjyGyleJHpnFakwerDkyVEQgfMA)
						{
							flag = true;
							break;
						}
					}
				}
				if (!flag)
				{
					this.eaLZopvlRmDbYBqnWbazWFCyShd(A_1[i], A_3);
				}
			}
		}
	}

	// Token: 0x060014C7 RID: 5319 RVA: 0x0001BA38 File Offset: 0x00019C38
	private void eaLZopvlRmDbYBqnWbazWFCyShd(SOdhOppsHkwNoqWKEsAKumLAEPWY.wjFGpzhPvGZUiYJRtvzzxtorJfIj A_1, bool A_2)
	{
		if (A_2)
		{
			if (this._DeviceConnectedEvent != null)
			{
				this._DeviceConnectedEvent(A_1.ToBridgedController());
				return;
			}
		}
		else if (this._DeviceDisconnectedEvent != null)
		{
			this._DeviceDisconnectedEvent(A_1.ToControllerDisconnectedEventArgs());
		}
	}

	// Token: 0x060014C8 RID: 5320 RVA: 0x0001BA70 File Offset: 0x00019C70
	private void OifLCzdhppTsJvQdRNvzCkIyFrraA()
	{
		if (this.ZebYhQOPBZaYCbdiYfxMGZfEBUts)
		{
			this.mODBcEWilRcgZeSFAwBpQfhlZZGpA = true;
		}
		this.SystemDeviceConnected();
	}

	// Token: 0x04002E9D RID: 11933
	internal const bool VhYqkXYVrNJIrFmsfJpaMyJZlsNO = true;

	// Token: 0x04002E9E RID: 11934
	private IInputSource eayKcEUkVYbwpESHeHFWKEBcQmogA;

	// Token: 0x04002E9F RID: 11935
	private List<SOdhOppsHkwNoqWKEsAKumLAEPWY.wjFGpzhPvGZUiYJRtvzzxtorJfIj> bGXqqfaMPMwNmVNIrcNcfXMsblwdA;

	// Token: 0x04002EA0 RID: 11936
	private int jqpZxIREdvqTXdBwmRrRgcjyEflH;

	// Token: 0x04002EA1 RID: 11937
	private SOdhOppsHkwNoqWKEsAKumLAEPWY.eQbacLZJTniCaSExlwvFVsMtiaKb TnoCEpCUTEvjGArtoNfjWBxUrgvSA;

	// Token: 0x04002EA2 RID: 11938
	private bool mODBcEWilRcgZeSFAwBpQfhlZZGpA;

	// Token: 0x04002EA3 RID: 11939
	private Action<int, ControllerDataUpdater> uFkDSykBpwoKEkPJQfwmjhtltcoOA;

	// Token: 0x04002EA4 RID: 11940
	private PlatformInputManager wAqKIrxLGPEGOtmVGokUwhGhlMNr;

	// Token: 0x04002EA5 RID: 11941
	private readonly bool ZebYhQOPBZaYCbdiYfxMGZfEBUts;

	// Token: 0x04002EA6 RID: 11942
	private readonly bool LWazbafOBLoCwZLWSoHNdESqsZCL;

	// Token: 0x04002EA7 RID: 11943
	private readonly bool BShQRDaSiqnLgNFLhLOdqqvjoTGS;

	// Token: 0x04002EA8 RID: 11944
	private readonly Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> svResSuCuGNRpOZbgikUKLzfYaAn;

	// Token: 0x04002EA9 RID: 11945
	private readonly Func<int> sYxFRYDEfwEEEhHjeorROJeFlTGpD;

	// Token: 0x020002C2 RID: 706
	private class wjFGpzhPvGZUiYJRtvzzxtorJfIj : IInputManagerJoystick, IInputManagerJoystickPublic
	{
		// Token: 0x1700033F RID: 831
		// (get) Token: 0x060014C9 RID: 5321 RVA: 0x0001BA87 File Offset: 0x00019C87
		// (set) Token: 0x060014CA RID: 5322 RVA: 0x0001BA8F File Offset: 0x00019C8F
		[CustomObfuscation(rename = false)]
		public int rewiredId
		{
			get
			{
				return this.TCKPHgRCdjrQPorpBlBZthadYLqE;
			}
			set
			{
				this.TCKPHgRCdjrQPorpBlBZthadYLqE = value;
			}
		}

		// Token: 0x17000340 RID: 832
		// (get) Token: 0x060014CB RID: 5323 RVA: 0x0001BA98 File Offset: 0x00019C98
		// (set) Token: 0x060014CC RID: 5324 RVA: 0x0001BAA0 File Offset: 0x00019CA0
		[CustomObfuscation(rename = false)]
		public int inputManagerId
		{
			get
			{
				return this.uRLhtEgNvsdSlaIbryFMLdFKwRJMA;
			}
			set
			{
				this.uRLhtEgNvsdSlaIbryFMLdFKwRJMA = value;
			}
		}

		// Token: 0x17000341 RID: 833
		// (get) Token: 0x060014CD RID: 5325 RVA: 0x0001BAA9 File Offset: 0x00019CA9
		[CustomObfuscation(rename = false)]
		public string name
		{
			get
			{
				return this.QUYWVYkUjYvYsxcwsOHAkYWinYAA;
			}
		}

		// Token: 0x17000342 RID: 834
		// (get) Token: 0x060014CE RID: 5326 RVA: 0x00049B94 File Offset: 0x00047D94
		[CustomObfuscation(rename = false)]
		public long? systemId
		{
			get
			{
				if (this.uRLhtEgNvsdSlaIbryFMLdFKwRJMA < 0)
				{
					return null;
				}
				return new long?((long)this.uRLhtEgNvsdSlaIbryFMLdFKwRJMA);
			}
		}

		// Token: 0x17000343 RID: 835
		// (get) Token: 0x060014CF RID: 5327 RVA: 0x00011826 File Offset: 0x0000FA26
		[CustomObfuscation(rename = false)]
		public int unityId
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x17000344 RID: 836
		// (get) Token: 0x060014D0 RID: 5328 RVA: 0x0001BAB1 File Offset: 0x00019CB1
		[CustomObfuscation(rename = false)]
		public Guid instanceGuid
		{
			get
			{
				return this.zSkjyGyleJHpnFakwerDkyVEQgfMA;
			}
		}

		// Token: 0x17000345 RID: 837
		// (get) Token: 0x060014D1 RID: 5329 RVA: 0x0001BAB9 File Offset: 0x00019CB9
		[CustomObfuscation(rename = false)]
		public Guid persistentGuid
		{
			get
			{
				return this.instanceGuid;
			}
		}

		// Token: 0x17000346 RID: 838
		// (get) Token: 0x060014D2 RID: 5330 RVA: 0x0001BAC1 File Offset: 0x00019CC1
		// (set) Token: 0x060014D3 RID: 5331 RVA: 0x0001BAC9 File Offset: 0x00019CC9
		[CustomObfuscation(rename = false)]
		public Controller.Extension extension { get; set; }

		// Token: 0x060014D4 RID: 5332 RVA: 0x0001BAD2 File Offset: 0x00019CD2
		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
			this.XUCDpkjMbrfxCfonfmGqWlwzlHnhA.trMCFmcYtbaesTrNPtLeGQBdEViEb(motorIndex, amount, false);
		}

		// Token: 0x060014D5 RID: 5333 RVA: 0x000116E9 File Offset: 0x0000F8E9
		[CustomObfuscation(rename = false)]
		public void StopVibration()
		{
		}

		// Token: 0x060014D6 RID: 5334 RVA: 0x0001BAE2 File Offset: 0x00019CE2
		public wjFGpzhPvGZUiYJRtvzzxtorJfIj(Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> A_1)
		{
			this.iEifvsGHouIRDKVdruQaTyejtyJkA = A_1;
			this.uRLhtEgNvsdSlaIbryFMLdFKwRJMA = -1;
			this.TCKPHgRCdjrQPorpBlBZthadYLqE = -1;
		}

		// Token: 0x060014D7 RID: 5335 RVA: 0x00049BC0 File Offset: 0x00047DC0
		public void EQHAwlAmwjYThKhwONGfHOVbYqKv()
		{
			this.DqZyVEnuZExNIfCqnJpQkjdNIUDr = MiscTools.CreateGuidHashSHA1(this.GGOnnIVoRizSfgxiWPBsgjZwWaHj + this.ImRfHTWKydcDlGXrWdwlrrinlYUS.ToProductGuid().ToString());
			this.ZXysfjVJeSinrqTGZSABMvFxzOzF = this.hMpyylQdVKbgBPfPfiMWBfQzRMnG;
			this.wvoVYMLltpZIWpWZgPrrWSTAIdoE = this.jYfXZqaPxUpWStdGpTXslBdgizQeA + this.fZfrSQNqWYAMIPUKQrPXlNmplWbb * 8;
			this.ylKhhIysNdjTDxywBvumbUMexBHg();
			this.geviHcuBUxnOVpdWfqJfcWlqbHOP = this.HhLrkQAlHqumxOjjVdwzjzXRZXKg.hardwareMapIdentifier.guid;
			this.QUYWVYkUjYvYsxcwsOHAkYWinYAA = this.HhLrkQAlHqumxOjjVdwzjzXRZXKg.controllerName;
			this.DIBnKEJQKLZRkHOrHCRFyZSWzPBA = (this.geviHcuBUxnOVpdWfqJfcWlqbHOP == Guid.Empty);
			this.iTsoZSAxWkPtJTIOMfDiKVevLNLeb = new float[this.ZXysfjVJeSinrqTGZSABMvFxzOzF];
			this.gVTmFZoJdSCbsijgnWsGkCfHELxiA = new bool[this.wvoVYMLltpZIWpWZgPrrWSTAIdoE];
			this.Update();
		}

		// Token: 0x060014D8 RID: 5336 RVA: 0x00049C90 File Offset: 0x00047E90
		public void eQXRyOBsjzmEyVUPUOFhLBAmEWSj(SOdhOppsHkwNoqWKEsAKumLAEPWY.wjFGpzhPvGZUiYJRtvzzxtorJfIj A_1)
		{
			if (A_1 == null)
			{
				return;
			}
			this.uRLhtEgNvsdSlaIbryFMLdFKwRJMA = A_1.uRLhtEgNvsdSlaIbryFMLdFKwRJMA;
			this.TCKPHgRCdjrQPorpBlBZthadYLqE = A_1.TCKPHgRCdjrQPorpBlBZthadYLqE;
			for (int i = 0; i < MathTools.Min(this.gVTmFZoJdSCbsijgnWsGkCfHELxiA.Length, A_1.gVTmFZoJdSCbsijgnWsGkCfHELxiA.Length); i++)
			{
				this.gVTmFZoJdSCbsijgnWsGkCfHELxiA[i] = A_1.gVTmFZoJdSCbsijgnWsGkCfHELxiA[i];
			}
			for (int j = 0; j < MathTools.Min(this.iTsoZSAxWkPtJTIOMfDiKVevLNLeb.Length, A_1.iTsoZSAxWkPtJTIOMfDiKVevLNLeb.Length); j++)
			{
				this.iTsoZSAxWkPtJTIOMfDiKVevLNLeb[j] = A_1.iTsoZSAxWkPtJTIOMfDiKVevLNLeb[j];
			}
			this.EYkhHYQbmeqbAFOllbgivWLAflKR = A_1.EYkhHYQbmeqbAFOllbgivWLAflKR;
		}

		// Token: 0x060014D9 RID: 5337 RVA: 0x0001BAFF File Offset: 0x00019CFF
		[CustomObfuscation(rename = false)]
		public void Update()
		{
			this.sKxeLvafyqjKHBHCjFaPuRrlQUzD();
			this.bPSzLkmbelQTBJtBiXdKAhpFfkmf();
			if (!this.EYkhHYQbmeqbAFOllbgivWLAflKR && this.XUCDpkjMbrfxCfonfmGqWlwzlHnhA.FEcqYuiRLeUGPlsgxtjmPVTQMIYp)
			{
				this.EYkhHYQbmeqbAFOllbgivWLAflKR = true;
			}
		}

		// Token: 0x060014DA RID: 5338 RVA: 0x00049D28 File Offset: 0x00047F28
		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (this.ZXysfjVJeSinrqTGZSABMvFxzOzF != dataUpdater.axisCount || this.wvoVYMLltpZIWpWZgPrrWSTAIdoE != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			for (int i = 0; i < this.ZXysfjVJeSinrqTGZSABMvFxzOzF; i++)
			{
				dataUpdater.axisValues[i] = this.iTsoZSAxWkPtJTIOMfDiKVevLNLeb[i];
			}
			for (int j = 0; j < this.wvoVYMLltpZIWpWZgPrrWSTAIdoE; j++)
			{
				dataUpdater.buttonValues[j] = this.gVTmFZoJdSCbsijgnWsGkCfHELxiA[j];
			}
			if (this.EYkhHYQbmeqbAFOllbgivWLAflKR && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		// Token: 0x060014DB RID: 5339 RVA: 0x00049DB8 File Offset: 0x00047FB8
		public int IWYAmWmvQnngixlseAhqdYcwOao(SOdhOppsHkwNoqWKEsAKumLAEPWY.wjFGpzhPvGZUiYJRtvzzxtorJfIj A_1)
		{
			if (A_1.TCKPHgRCdjrQPorpBlBZthadYLqE == this.TCKPHgRCdjrQPorpBlBZthadYLqE)
			{
				return 2;
			}
			if (this.hMpyylQdVKbgBPfPfiMWBfQzRMnG != A_1.hMpyylQdVKbgBPfPfiMWBfQzRMnG)
			{
				return 0;
			}
			if (this.jYfXZqaPxUpWStdGpTXslBdgizQeA != A_1.jYfXZqaPxUpWStdGpTXslBdgizQeA)
			{
				return 0;
			}
			if (this.fZfrSQNqWYAMIPUKQrPXlNmplWbb != A_1.fZfrSQNqWYAMIPUKQrPXlNmplWbb)
			{
				return 0;
			}
			if (A_1.zSkjyGyleJHpnFakwerDkyVEQgfMA == this.zSkjyGyleJHpnFakwerDkyVEQgfMA)
			{
				return 2;
			}
			if (A_1.DqZyVEnuZExNIfCqnJpQkjdNIUDr == this.DqZyVEnuZExNIfCqnJpQkjdNIUDr)
			{
				return 1;
			}
			return 0;
		}

		// Token: 0x060014DC RID: 5340 RVA: 0x00049E30 File Offset: 0x00048030
		private BridgedControllerHWInfo exJklWtFDqsvYAHaoqIyUyOldGqJ()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			this.NvHAsbIfMpkeHEeRAMyfpwsTLYAOb(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		// Token: 0x060014DD RID: 5341 RVA: 0x00049E4C File Offset: 0x0004804C
		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			this.nlvXjjsbKYDqLYMwAusoNwbRfpBs(bridgedController);
			return bridgedController;
		}

		// Token: 0x060014DE RID: 5342 RVA: 0x0001BB29 File Offset: 0x00019D29
		[CustomObfuscation(rename = false)]
		public ControllerDisconnectedEventArgs ToControllerDisconnectedEventArgs()
		{
			return new ControllerDisconnectedEventArgs(this.TCKPHgRCdjrQPorpBlBZthadYLqE);
		}

		// Token: 0x060014DF RID: 5343 RVA: 0x00049E68 File Offset: 0x00048068
		private void sKxeLvafyqjKHBHCjFaPuRrlQUzD()
		{
			if (this.ZXysfjVJeSinrqTGZSABMvFxzOzF <= 0)
			{
				return;
			}
			if (this.HhLrkQAlHqumxOjjVdwzjzXRZXKg.map.platform != InputPlatform.SDL2)
			{
				return;
			}
			HardwareJoystickMap.Platform_SDL2_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_SDL2_Base)this.HhLrkQAlHqumxOjjVdwzjzXRZXKg.map).Axes_orig;
			if (axes_orig == null)
			{
				return;
			}
			for (int i = 0; i < axes_orig.Length; i++)
			{
				this.sHwOJiAzAaNjgibKkOguQsoTkzmQ(axes_orig[i], i);
			}
		}

		// Token: 0x060014E0 RID: 5344 RVA: 0x00049EC8 File Offset: 0x000480C8
		private void bPSzLkmbelQTBJtBiXdKAhpFfkmf()
		{
			if (this.wvoVYMLltpZIWpWZgPrrWSTAIdoE <= 0)
			{
				return;
			}
			HardwareJoystickMap.Platform_SDL2_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_SDL2_Base)this.HhLrkQAlHqumxOjjVdwzjzXRZXKg.map).Buttons_orig;
			if (buttons_orig == null)
			{
				return;
			}
			for (int i = 0; i < buttons_orig.Length; i++)
			{
				this.BAQTqrtOEtEuNvwXDOBYeRNSiSDO(buttons_orig[i], i);
			}
		}

		// Token: 0x060014E1 RID: 5345 RVA: 0x0001BB36 File Offset: 0x00019D36
		private void sHwOJiAzAaNjgibKkOguQsoTkzmQ(HardwareJoystickMap.Platform_SDL2_Base.Axis A_1, int A_2)
		{
			if (A_2 >= this.ZXysfjVJeSinrqTGZSABMvFxzOzF)
			{
				throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
			}
			this.iTsoZSAxWkPtJTIOMfDiKVevLNLeb[A_2] = this.chyheQhUFdidceHbEYffEiPGEYjC(A_1);
		}

		// Token: 0x060014E2 RID: 5346 RVA: 0x0001BB5B File Offset: 0x00019D5B
		private void BAQTqrtOEtEuNvwXDOBYeRNSiSDO(HardwareJoystickMap.Platform_SDL2_Base.Button A_1, int A_2)
		{
			if (A_2 >= this.wvoVYMLltpZIWpWZgPrrWSTAIdoE)
			{
				throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
			}
			this.gVTmFZoJdSCbsijgnWsGkCfHELxiA[A_2] = this.dnLNxVYeFxRmGliqQUxBWuZTgMXG(A_1);
		}

		// Token: 0x060014E3 RID: 5347 RVA: 0x00049F14 File Offset: 0x00048114
		private float chyheQhUFdidceHbEYffEiPGEYjC(HardwareJoystickMap.Platform_SDL2_Base.Axis A_1)
		{
			if (A_1.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				int sourceAxis = A_1.sourceAxis;
				if (sourceAxis < 0 || sourceAxis >= this.hMpyylQdVKbgBPfPfiMWBfQzRMnG || sourceAxis >= 56)
				{
					return 0f;
				}
				return this.XUCDpkjMbrfxCfonfmGqWlwzlHnhA.ZWiXJWjqmdWCtbiIONNYdLuPuUOT(sourceAxis);
			}
			else if (A_1.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				int sourceButton = A_1.sourceButton;
				if (sourceButton < 0 || sourceButton >= this.jYfXZqaPxUpWStdGpTXslBdgizQeA || sourceButton >= 256)
				{
					return 0f;
				}
				if (!this.XUCDpkjMbrfxCfonfmGqWlwzlHnhA.BLhrHvfnwHXxAXmkRmbyakCTwbbI(sourceButton))
				{
					return 0f;
				}
				float result;
				if (A_1.buttonAxisContribution == Pole.Positive)
				{
					result = 1f;
				}
				else
				{
					result = -1f;
				}
				return result;
			}
			else
			{
				if (A_1.sourceType != HardwareElementSourceTypeWithHat.Hat)
				{
					return 0f;
				}
				int sourceHat = A_1.sourceHat;
				if (sourceHat < 0 || sourceHat >= this.fZfrSQNqWYAMIPUKQrPXlNmplWbb || sourceHat >= 4)
				{
					return 0f;
				}
				int num = this.XUCDpkjMbrfxCfonfmGqWlwzlHnhA.fVmGnSMDTrcONaLnvArQpyRmBIqJ(sourceHat);
				if (num < 0)
				{
					return 0f;
				}
				float num2;
				if (A_1.sourceHatDirection == AxisDirection.Horizontal)
				{
					num2 = this.EvqXrCrNbcEHgcHPyJVdLRpUMlSs(num, AxisDirection.Horizontal);
					if (A_1.sourceHatRange != AxisRange.Full)
					{
						if (A_1.sourceHatRange == AxisRange.Positive)
						{
							if (num2 < 0f)
							{
								return 0f;
							}
						}
						else if (num2 > 0f)
						{
							return 0f;
						}
					}
				}
				else
				{
					num2 = this.EvqXrCrNbcEHgcHPyJVdLRpUMlSs(num, AxisDirection.Vertical);
					if (A_1.sourceHatRange != AxisRange.Full)
					{
						if (A_1.sourceHatRange == AxisRange.Positive)
						{
							if (num2 < 0f)
							{
								return 0f;
							}
						}
						else if (num2 > 0f)
						{
							return 0f;
						}
					}
				}
				if (A_1.invert)
				{
					num2 *= -1f;
				}
				return num2;
			}
		}

		// Token: 0x060014E4 RID: 5348 RVA: 0x0004A088 File Offset: 0x00048288
		private bool dnLNxVYeFxRmGliqQUxBWuZTgMXG(HardwareJoystickMap.Platform_SDL2_Base.Button A_1)
		{
			if (A_1.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				if (A_1.ignoreIfButtonsActive)
				{
					for (int i = 0; i < A_1.ignoreIfButtonsActiveButtons.Length; i++)
					{
						if (this.XUCDpkjMbrfxCfonfmGqWlwzlHnhA.BLhrHvfnwHXxAXmkRmbyakCTwbbI(A_1.ignoreIfButtonsActiveButtons[i]))
						{
							return false;
						}
					}
				}
				if (A_1.requireMultipleButtons)
				{
					bool result = false;
					for (int j = 0; j < A_1.requiredButtons.Length; j++)
					{
						if (!this.XUCDpkjMbrfxCfonfmGqWlwzlHnhA.BLhrHvfnwHXxAXmkRmbyakCTwbbI(A_1.requiredButtons[j]))
						{
							return false;
						}
						result = true;
					}
					return result;
				}
				int sourceButton = A_1.sourceButton;
				return sourceButton >= 0 && sourceButton < this.jYfXZqaPxUpWStdGpTXslBdgizQeA && sourceButton < 256 && this.XUCDpkjMbrfxCfonfmGqWlwzlHnhA.BLhrHvfnwHXxAXmkRmbyakCTwbbI(sourceButton);
			}
			else
			{
				if (A_1.sourceType != HardwareElementSourceTypeWithHat.Axis)
				{
					if (A_1.sourceType == HardwareElementSourceTypeWithHat.Hat)
					{
						int sourceHat = A_1.sourceHat;
						if (sourceHat < 0 || sourceHat >= this.fZfrSQNqWYAMIPUKQrPXlNmplWbb || sourceHat >= 4)
						{
							return false;
						}
						switch (A_1.sourceHatDirection)
						{
						case HatDirection.Up:
							return this.HjhVhPFLPGOVJmSEEumXQeXkCHZp(this.XUCDpkjMbrfxCfonfmGqWlwzlHnhA.fVmGnSMDTrcONaLnvArQpyRmBIqJ(sourceHat), 0, A_1.sourceHatType);
						case HatDirection.Right:
							return this.HjhVhPFLPGOVJmSEEumXQeXkCHZp(this.XUCDpkjMbrfxCfonfmGqWlwzlHnhA.fVmGnSMDTrcONaLnvArQpyRmBIqJ(sourceHat), 2, A_1.sourceHatType);
						case HatDirection.Down:
							return this.HjhVhPFLPGOVJmSEEumXQeXkCHZp(this.XUCDpkjMbrfxCfonfmGqWlwzlHnhA.fVmGnSMDTrcONaLnvArQpyRmBIqJ(sourceHat), 4, A_1.sourceHatType);
						case HatDirection.Left:
							return this.HjhVhPFLPGOVJmSEEumXQeXkCHZp(this.XUCDpkjMbrfxCfonfmGqWlwzlHnhA.fVmGnSMDTrcONaLnvArQpyRmBIqJ(sourceHat), 6, A_1.sourceHatType);
						case HatDirection.UpRight:
							return this.HjhVhPFLPGOVJmSEEumXQeXkCHZp(this.XUCDpkjMbrfxCfonfmGqWlwzlHnhA.fVmGnSMDTrcONaLnvArQpyRmBIqJ(sourceHat), 1, A_1.sourceHatType);
						case HatDirection.DownRight:
							return this.HjhVhPFLPGOVJmSEEumXQeXkCHZp(this.XUCDpkjMbrfxCfonfmGqWlwzlHnhA.fVmGnSMDTrcONaLnvArQpyRmBIqJ(sourceHat), 3, A_1.sourceHatType);
						case HatDirection.DownLeft:
							return this.HjhVhPFLPGOVJmSEEumXQeXkCHZp(this.XUCDpkjMbrfxCfonfmGqWlwzlHnhA.fVmGnSMDTrcONaLnvArQpyRmBIqJ(sourceHat), 5, A_1.sourceHatType);
						case HatDirection.UpLeft:
							return this.HjhVhPFLPGOVJmSEEumXQeXkCHZp(this.XUCDpkjMbrfxCfonfmGqWlwzlHnhA.fVmGnSMDTrcONaLnvArQpyRmBIqJ(sourceHat), 7, A_1.sourceHatType);
						}
					}
					return false;
				}
				int sourceAxis = A_1.sourceAxis;
				if (sourceAxis <= 0 || sourceAxis >= this.hMpyylQdVKbgBPfPfiMWBfQzRMnG || sourceAxis >= 56)
				{
					return false;
				}
				float num = this.XUCDpkjMbrfxCfonfmGqWlwzlHnhA.ZWiXJWjqmdWCtbiIONNYdLuPuUOT(sourceAxis);
				if (MathTools.Abs(num) <= A_1.axisDeadZone)
				{
					return false;
				}
				if (A_1.sourceAxisPole == Pole.Positive)
				{
					if (num < 0f)
					{
						return false;
					}
				}
				else if (num > 0f)
				{
					return false;
				}
				return true;
			}
		}

		// Token: 0x060014E5 RID: 5349 RVA: 0x0004A2DC File Offset: 0x000484DC
		private bool HjhVhPFLPGOVJmSEEumXQeXkCHZp(int A_1, int A_2, HatType A_3)
		{
			if (A_1 < 0)
			{
				return false;
			}
			if (this.HhLrkQAlHqumxOjjVdwzjzXRZXKg.isUnknownController && !InputTools.HandleForced4WayHatsOnUnknownControllers(A_2, ref A_3))
			{
				return false;
			}
			int num = 4500 * A_2;
			if (A_3 == HatType.EightWay && A_1 != num)
			{
				return false;
			}
			int num2;
			int num3;
			if (A_3 == HatType.EightWay)
			{
				num2 = 31500;
				num3 = 4500;
			}
			else
			{
				num2 = 27000;
				num3 = 9000;
			}
			if (A_2 == 0 && A_1 > num2)
			{
				A_1 -= 36000;
			}
			return A_1 < num + num3 && A_1 > num - num3;
		}

		// Token: 0x060014E6 RID: 5350 RVA: 0x000211DC File Offset: 0x0001F3DC
		private float EvqXrCrNbcEHgcHPyJVdLRpUMlSs(int A_1, AxisDirection A_2)
		{
			if (A_1 < 0)
			{
				return 0f;
			}
			if (A_2 == AxisDirection.Vertical)
			{
				if (A_1 > 27000 || A_1 < 9000)
				{
					return 1f;
				}
				if (A_1 < 27000 && A_1 > 9000)
				{
					return -1f;
				}
				return 0f;
			}
			else
			{
				if (A_1 > 0 && A_1 < 18000)
				{
					return 1f;
				}
				if (A_1 > 18000)
				{
					return -1f;
				}
				return 0f;
			}
		}

		// Token: 0x060014E7 RID: 5351 RVA: 0x0001BB80 File Offset: 0x00019D80
		private ControlDeviceType sArBoJVnVUdLjeBXwEmEvDmAEEux(SzWWiHinPorZtqFgAFYWHHdeStfC A_1)
		{
			if (A_1 == SzWWiHinPorZtqFgAFYWHHdeStfC.Joystick)
			{
				return ControlDeviceType.Joystick;
			}
			if (A_1 == SzWWiHinPorZtqFgAFYWHHdeStfC.Gamepad)
			{
				return ControlDeviceType.Gamepad;
			}
			if (A_1 == SzWWiHinPorZtqFgAFYWHHdeStfC.Keyboard)
			{
				return ControlDeviceType.Keyboard;
			}
			if (A_1 == SzWWiHinPorZtqFgAFYWHHdeStfC.Mouse)
			{
				return ControlDeviceType.Mouse;
			}
			return ControlDeviceType.Unknown;
		}

		// Token: 0x060014E8 RID: 5352 RVA: 0x0004A358 File Offset: 0x00048558
		private void ylKhhIysNdjTDxywBvumbUMexBHg()
		{
			this.HhLrkQAlHqumxOjjVdwzjzXRZXKg = this.iEifvsGHouIRDKVdruQaTyejtyJkA(this.exJklWtFDqsvYAHaoqIyUyOldGqJ());
			if (this.HhLrkQAlHqumxOjjVdwzjzXRZXKg == null)
			{
				Logger.LogError("Default hardware map not found!");
				return;
			}
			if (this.HhLrkQAlHqumxOjjVdwzjzXRZXKg.useSystemName)
			{
				if (!string.IsNullOrEmpty(this.hmTbqrPKPzxmuIRROFoHJdumZKoE))
				{
					string text = Regex.Replace(this.hmTbqrPKPzxmuIRROFoHJdumZKoE, "\\s+", " ");
					text = text.Trim();
					if (!string.IsNullOrEmpty(text))
					{
						this.HhLrkQAlHqumxOjjVdwzjzXRZXKg.controllerName = text;
					}
				}
				if (this.HhLrkQAlHqumxOjjVdwzjzXRZXKg.deviceLocalizationInfo.parentKeys.Count > 0 && !string.IsNullOrEmpty(this.HhLrkQAlHqumxOjjVdwzjzXRZXKg.deviceLocalizationInfo.parentKeys[0]))
				{
					string a = this.HhLrkQAlHqumxOjjVdwzjzXRZXKg.deviceLocalizationInfo.parentKeys[0];
					string format = "{0}:{1}";
					PidVid pidVid = this.XUCDpkjMbrfxCfonfmGqWlwzlHnhA.bgECXHIkOHjQKARwiIEGVpOlEqAD;
					object arg = pidVid.vendorId.ToString("x4");
					pidVid = this.XUCDpkjMbrfxCfonfmGqWlwzlHnhA.bgECXHIkOHjQKARwiIEGVpOlEqAD;
					string text2 = string.Format(format, arg, pidVid.productId.ToString("x4"));
					this.HhLrkQAlHqumxOjjVdwzjzXRZXKg.deviceLocalizationInfo.InsertParentKey(0, LocalizationManager.AppendToKeyAsPath(a, text2));
					if (!string.IsNullOrEmpty(this.XUCDpkjMbrfxCfonfmGqWlwzlHnhA.unZYaKznDCgLUnmQnPpLeEmszMjn))
					{
						this.HhLrkQAlHqumxOjjVdwzjzXRZXKg.deviceLocalizationInfo.InsertParentKey(1, LocalizationManager.AppendToKeyAsPath(a, this.XUCDpkjMbrfxCfonfmGqWlwzlHnhA.unZYaKznDCgLUnmQnPpLeEmszMjn));
					}
					if (!string.IsNullOrEmpty(this.XUCDpkjMbrfxCfonfmGqWlwzlHnhA.unZYaKznDCgLUnmQnPpLeEmszMjn))
					{
						this.HhLrkQAlHqumxOjjVdwzjzXRZXKg.deviceLocalizationInfo.additionalIdentifyingInformation = string.Format("{0} [{1}]", this.XUCDpkjMbrfxCfonfmGqWlwzlHnhA.unZYaKznDCgLUnmQnPpLeEmszMjn, text2);
					}
					else
					{
						this.HhLrkQAlHqumxOjjVdwzjzXRZXKg.deviceLocalizationInfo.additionalIdentifyingInformation = string.Format("[{0}]", text2);
					}
				}
			}
			this.ZXysfjVJeSinrqTGZSABMvFxzOzF = this.HhLrkQAlHqumxOjjVdwzjzXRZXKg.axisCount;
			this.wvoVYMLltpZIWpWZgPrrWSTAIdoE = this.HhLrkQAlHqumxOjjVdwzjzXRZXKg.buttonCount;
		}

		// Token: 0x060014E9 RID: 5353 RVA: 0x0004A538 File Offset: 0x00048738
		private string yGQbCYhIzWyMzlORflsPlAdracQzA()
		{
			return InputTools.FormatHardwareIdentifierString(string.Format("{0}{1}{2}{3}{4}", new object[]
			{
				ReInput.currentPlatform.ToString(),
				this.XUCDpkjMbrfxCfonfmGqWlwzlHnhA.seDogDOvnVvWEUwimMlEDLfvKjSl,
				this.GGOnnIVoRizSfgxiWPBsgjZwWaHj,
				this.VllEdkJBFREECFGrIvtwDGOehphSC,
				this.ImRfHTWKydcDlGXrWdwlrrinlYUS.ToProductGuid()
			}));
		}

		// Token: 0x060014EA RID: 5354 RVA: 0x0004A5B0 File Offset: 0x000487B0
		private void NvHAsbIfMpkeHEeRAMyfpwsTLYAOb(BridgedControllerHWInfo A_1)
		{
			A_1.inputManagerSource = InputSource.SDL2;
			A_1.inputSource = this.XUCDpkjMbrfxCfonfmGqWlwzlHnhA.seDogDOvnVvWEUwimMlEDLfvKjSl;
			A_1.deviceType = this.sArBoJVnVUdLjeBXwEmEvDmAEEux(this.HjWbMMNOHoKixJtQtKnjIGuiNYgh);
			A_1.hardwareIdentifier = this.yGQbCYhIzWyMzlORflsPlAdracQzA();
			A_1.hardwareAxisCount = this.hMpyylQdVKbgBPfPfiMWBfQzRMnG;
			A_1.hardwareButtonCount = this.jYfXZqaPxUpWStdGpTXslBdgizQeA;
			A_1.hardwareHatCount = this.fZfrSQNqWYAMIPUKQrPXlNmplWbb;
			A_1.hw_productName = this.GGOnnIVoRizSfgxiWPBsgjZwWaHj;
			A_1.hw_deviceGuid = this.zSkjyGyleJHpnFakwerDkyVEQgfMA;
			A_1.hw_productId = this.VllEdkJBFREECFGrIvtwDGOehphSC;
			A_1.hw_pidVid = this.ImRfHTWKydcDlGXrWdwlrrinlYUS;
			A_1.hw_isBluetoothDevice = this.MlavMGYOCvAwPMCAzuPjZZwKoftq;
			A_1.hw_bluetoothDeviceName = this.GGOnnIVoRizSfgxiWPBsgjZwWaHj;
			A_1.hw_systemDeviceName = this.GGOnnIVoRizSfgxiWPBsgjZwWaHj;
			A_1.hw_supportsVibration = this.hDBvPTAAooiMAhKNSvdwMHigbncl;
			A_1.hw_isSDL2Gamepad = (this.XUCDpkjMbrfxCfonfmGqWlwzlHnhA.iyBMEgPsJKChrbMLumpLOIgcIDIjA == SzWWiHinPorZtqFgAFYWHHdeStfC.Gamepad);
			A_1.hw_localVibrationMotorCount = this.mNUkhjxnaBrlwdZXBKGffCPKFPrKA;
		}

		// Token: 0x060014EB RID: 5355 RVA: 0x0004A698 File Offset: 0x00048898
		private void nlvXjjsbKYDqLYMwAusoNwbRfpBs(BridgedController A_1)
		{
			this.NvHAsbIfMpkeHEeRAMyfpwsTLYAOb(A_1);
			A_1.sourceJoystick = this;
			A_1.gameHardwareMap = this.HhLrkQAlHqumxOjjVdwzjzXRZXKg.ToGameHardwareControllerMap();
			A_1.instanceName = this.GGOnnIVoRizSfgxiWPBsgjZwWaHj;
			A_1.productName = this.GGOnnIVoRizSfgxiWPBsgjZwWaHj;
			A_1.axisCount = this.ZXysfjVJeSinrqTGZSABMvFxzOzF;
			A_1.buttonCount = this.wvoVYMLltpZIWpWZgPrrWSTAIdoE;
			A_1.unknownControllerHats = this.wBrEoniRHSfLUOhDWBsIgLfEEUqgb();
			A_1.controllerTypeGuid = this.geviHcuBUxnOVpdWfqJfcWlqbHOP;
			A_1.controllerExtension = this.extension;
		}

		// Token: 0x060014EC RID: 5356 RVA: 0x0004A718 File Offset: 0x00048918
		private void LivfICvmReZfmINdmhQvTMxjJWvs()
		{
			for (int i = 0; i < this.wvoVYMLltpZIWpWZgPrrWSTAIdoE; i++)
			{
				this.gVTmFZoJdSCbsijgnWsGkCfHELxiA[i] = false;
			}
			for (int j = 0; j < this.ZXysfjVJeSinrqTGZSABMvFxzOzF; j++)
			{
				this.iTsoZSAxWkPtJTIOMfDiKVevLNLeb[j] = 0f;
			}
		}

		// Token: 0x060014ED RID: 5357 RVA: 0x0004A760 File Offset: 0x00048960
		private UnknownControllerHat[] wBrEoniRHSfLUOhDWBsIgLfEEUqgb()
		{
			if (!this.DIBnKEJQKLZRkHOrHCRFyZSWzPBA)
			{
				return null;
			}
			UnknownControllerHat[] array = new UnknownControllerHat[2];
			for (int i = 0; i < 2; i++)
			{
				int num = 128 + i * 8;
				UnknownControllerHat.HatButtons hatButtons = new UnknownControllerHat.HatButtons(new int[]
				{
					num,
					num + 1,
					num + 2,
					num + 3,
					num + 4,
					num + 5,
					num + 6,
					num + 7
				});
				array[i] = new UnknownControllerHat(hatButtons);
			}
			return array;
		}

		// Token: 0x060014EE RID: 5358 RVA: 0x0001BB9B File Offset: 0x00019D9B
		public static int ZpIWBpVgBhLCEROpbIAOqORhqjIN(SOdhOppsHkwNoqWKEsAKumLAEPWY.wjFGpzhPvGZUiYJRtvzzxtorJfIj A_0, SOdhOppsHkwNoqWKEsAKumLAEPWY.wjFGpzhPvGZUiYJRtvzzxtorJfIj A_1)
		{
			if (A_0.uRLhtEgNvsdSlaIbryFMLdFKwRJMA < A_1.uRLhtEgNvsdSlaIbryFMLdFKwRJMA)
			{
				return -1;
			}
			if (A_0.uRLhtEgNvsdSlaIbryFMLdFKwRJMA > A_1.uRLhtEgNvsdSlaIbryFMLdFKwRJMA)
			{
				return 1;
			}
			return 0;
		}

		// Token: 0x060014EF RID: 5359 RVA: 0x0001BBBE File Offset: 0x00019DBE
		public static int wusCvvCrZVqRxsULBQoYkOmgwQsmA(SOdhOppsHkwNoqWKEsAKumLAEPWY.wjFGpzhPvGZUiYJRtvzzxtorJfIj A_0, SOdhOppsHkwNoqWKEsAKumLAEPWY.wjFGpzhPvGZUiYJRtvzzxtorJfIj A_1)
		{
			if (A_0.cfeRKUffURKBKeOCMyDnJtkOlUFC < A_1.cfeRKUffURKBKeOCMyDnJtkOlUFC)
			{
				return -1;
			}
			if (A_0.cfeRKUffURKBKeOCMyDnJtkOlUFC > A_1.cfeRKUffURKBKeOCMyDnJtkOlUFC)
			{
				return 1;
			}
			return 0;
		}

		// Token: 0x04002EAA RID: 11946
		private int TCKPHgRCdjrQPorpBlBZthadYLqE;

		// Token: 0x04002EAB RID: 11947
		private int uRLhtEgNvsdSlaIbryFMLdFKwRJMA;

		// Token: 0x04002EAC RID: 11948
		public Guid geviHcuBUxnOVpdWfqJfcWlqbHOP;

		// Token: 0x04002EAD RID: 11949
		public string QUYWVYkUjYvYsxcwsOHAkYWinYAA;

		// Token: 0x04002EAE RID: 11950
		public gAkEWbhxgbYyrIrsrBCPaLxymaOwA XUCDpkjMbrfxCfonfmGqWlwzlHnhA;

		// Token: 0x04002EAF RID: 11951
		public SzWWiHinPorZtqFgAFYWHHdeStfC HjWbMMNOHoKixJtQtKnjIGuiNYgh;

		// Token: 0x04002EB0 RID: 11952
		public string GGOnnIVoRizSfgxiWPBsgjZwWaHj;

		// Token: 0x04002EB1 RID: 11953
		public string hmTbqrPKPzxmuIRROFoHJdumZKoE;

		// Token: 0x04002EB2 RID: 11954
		public int VllEdkJBFREECFGrIvtwDGOehphSC;

		// Token: 0x04002EB3 RID: 11955
		public int MDaIfmELlHYxcLUaBViEdboPDMiwA;

		// Token: 0x04002EB4 RID: 11956
		public Guid zSkjyGyleJHpnFakwerDkyVEQgfMA;

		// Token: 0x04002EB5 RID: 11957
		public PidVid ImRfHTWKydcDlGXrWdwlrrinlYUS;

		// Token: 0x04002EB6 RID: 11958
		public Guid DqZyVEnuZExNIfCqnJpQkjdNIUDr;

		// Token: 0x04002EB7 RID: 11959
		public int cfeRKUffURKBKeOCMyDnJtkOlUFC;

		// Token: 0x04002EB8 RID: 11960
		public int ZXysfjVJeSinrqTGZSABMvFxzOzF;

		// Token: 0x04002EB9 RID: 11961
		public int wvoVYMLltpZIWpWZgPrrWSTAIdoE;

		// Token: 0x04002EBA RID: 11962
		public int hMpyylQdVKbgBPfPfiMWBfQzRMnG;

		// Token: 0x04002EBB RID: 11963
		public int jYfXZqaPxUpWStdGpTXslBdgizQeA;

		// Token: 0x04002EBC RID: 11964
		public int fZfrSQNqWYAMIPUKQrPXlNmplWbb;

		// Token: 0x04002EBD RID: 11965
		public bool MlavMGYOCvAwPMCAzuPjZZwKoftq;

		// Token: 0x04002EBE RID: 11966
		public bool hDBvPTAAooiMAhKNSvdwMHigbncl;

		// Token: 0x04002EBF RID: 11967
		public int mNUkhjxnaBrlwdZXBKGffCPKFPrKA;

		// Token: 0x04002EC0 RID: 11968
		private float[] iTsoZSAxWkPtJTIOMfDiKVevLNLeb;

		// Token: 0x04002EC1 RID: 11969
		private bool[] gVTmFZoJdSCbsijgnWsGkCfHELxiA;

		// Token: 0x04002EC2 RID: 11970
		private HardwareJoystickMap_InputManager HhLrkQAlHqumxOjjVdwzjzXRZXKg;

		// Token: 0x04002EC3 RID: 11971
		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> iEifvsGHouIRDKVdruQaTyejtyJkA;

		// Token: 0x04002EC4 RID: 11972
		private bool DIBnKEJQKLZRkHOrHCRFyZSWzPBA;

		// Token: 0x04002EC5 RID: 11973
		private bool EYkhHYQbmeqbAFOllbgivWLAflKR;

		// Token: 0x04002EC6 RID: 11974
		[CompilerGenerated]
		private Controller.Extension HnJHgxkvgeQeeIjfvNwohbZFjQTj;
	}

	// Token: 0x020002C3 RID: 707
	private class eQbacLZJTniCaSExlwvFVsMtiaKb
	{
		// Token: 0x060014F0 RID: 5360 RVA: 0x0001BBE1 File Offset: 0x00019DE1
		public eQbacLZJTniCaSExlwvFVsMtiaKb()
		{
			this.IQLqRPGKolSyuewolepgVvgXSHkN = new List<SOdhOppsHkwNoqWKEsAKumLAEPWY.eQbacLZJTniCaSExlwvFVsMtiaKb.PSGVtTmDZaEbrJtmutKHqxqubvpUA>();
		}

		// Token: 0x060014F1 RID: 5361 RVA: 0x0004A7D8 File Offset: 0x000489D8
		public void iSgSVUypTIeQaJfjTIvXHslmjbmdb(SOdhOppsHkwNoqWKEsAKumLAEPWY.wjFGpzhPvGZUiYJRtvzzxtorJfIj A_1)
		{
			if (A_1 == null)
			{
				return;
			}
			int count = this.IQLqRPGKolSyuewolepgVvgXSHkN.Count;
			for (int i = 0; i < count; i++)
			{
				if (this.IQLqRPGKolSyuewolepgVvgXSHkN[i].DHbbWUSLIeJKyehGTwIqVyLqdPTP(A_1, SOdhOppsHkwNoqWKEsAKumLAEPWY.eQbacLZJTniCaSExlwvFVsMtiaKb.MkhVFYeRwqOLJBkgkFsqnUTqfmdhA.Exact))
				{
					this.IQLqRPGKolSyuewolepgVvgXSHkN[i].dApPKzsOyzFNOBtjNZbOLBcteyDE = A_1.rewiredId;
					this.IQLqRPGKolSyuewolepgVvgXSHkN[i].mgkjgtDMExnNiCFUIcxlagvEbaNBb = A_1.zSkjyGyleJHpnFakwerDkyVEQgfMA;
					this.IQLqRPGKolSyuewolepgVvgXSHkN[i].PopAkxCqWpRbWoBVsYflMCbgeWtB = A_1.DqZyVEnuZExNIfCqnJpQkjdNIUDr;
					this.IQLqRPGKolSyuewolepgVvgXSHkN[i].GaIhjDJBCAkKKRvrvIXCTBFFmYWT = A_1.inputManagerId;
					this.IQLqRPGKolSyuewolepgVvgXSHkN[i].WmwcDEGLHZFwSmCNWCGJIipDDXIoc = A_1.hMpyylQdVKbgBPfPfiMWBfQzRMnG;
					this.IQLqRPGKolSyuewolepgVvgXSHkN[i].HhyWglIXykDOaBIoimuDptoxmcNJ = A_1.jYfXZqaPxUpWStdGpTXslBdgizQeA;
					this.IQLqRPGKolSyuewolepgVvgXSHkN[i].QRRXEDQLIyBkDfBkimSraRCePauhA = A_1.fZfrSQNqWYAMIPUKQrPXlNmplWbb;
					this.WqpqHTJyoESlJSHGWzufCflpBKKCA(A_1.rewiredId, A_1.zSkjyGyleJHpnFakwerDkyVEQgfMA, i);
					return;
				}
			}
			this.IQLqRPGKolSyuewolepgVvgXSHkN.Add(new SOdhOppsHkwNoqWKEsAKumLAEPWY.eQbacLZJTniCaSExlwvFVsMtiaKb.PSGVtTmDZaEbrJtmutKHqxqubvpUA
			{
				dApPKzsOyzFNOBtjNZbOLBcteyDE = A_1.rewiredId,
				mgkjgtDMExnNiCFUIcxlagvEbaNBb = A_1.zSkjyGyleJHpnFakwerDkyVEQgfMA,
				PopAkxCqWpRbWoBVsYflMCbgeWtB = A_1.DqZyVEnuZExNIfCqnJpQkjdNIUDr,
				GaIhjDJBCAkKKRvrvIXCTBFFmYWT = A_1.inputManagerId,
				WmwcDEGLHZFwSmCNWCGJIipDDXIoc = A_1.hMpyylQdVKbgBPfPfiMWBfQzRMnG,
				HhyWglIXykDOaBIoimuDptoxmcNJ = A_1.jYfXZqaPxUpWStdGpTXslBdgizQeA,
				QRRXEDQLIyBkDfBkimSraRCePauhA = A_1.fZfrSQNqWYAMIPUKQrPXlNmplWbb
			});
			this.WqpqHTJyoESlJSHGWzufCflpBKKCA(A_1.rewiredId, A_1.zSkjyGyleJHpnFakwerDkyVEQgfMA, this.IQLqRPGKolSyuewolepgVvgXSHkN.Count - 1);
		}

		// Token: 0x060014F2 RID: 5362 RVA: 0x0004A958 File Offset: 0x00048B58
		public bool wtdrGYXhMcCDiZEuOMFZVdlyXMfy(SOdhOppsHkwNoqWKEsAKumLAEPWY.wjFGpzhPvGZUiYJRtvzzxtorJfIj A_1, SOdhOppsHkwNoqWKEsAKumLAEPWY.eQbacLZJTniCaSExlwvFVsMtiaKb.MkhVFYeRwqOLJBkgkFsqnUTqfmdhA A_2)
		{
			int count = this.IQLqRPGKolSyuewolepgVvgXSHkN.Count;
			for (int i = 0; i < count; i++)
			{
				if (this.IQLqRPGKolSyuewolepgVvgXSHkN[i].DHbbWUSLIeJKyehGTwIqVyLqdPTP(A_1, A_2))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060014F3 RID: 5363 RVA: 0x0001BBF4 File Offset: 0x00019DF4
		public IEnumerable<SOdhOppsHkwNoqWKEsAKumLAEPWY.eQbacLZJTniCaSExlwvFVsMtiaKb.PSGVtTmDZaEbrJtmutKHqxqubvpUA> AySMoFhxtmRcwIpxzesicVrSKeOab(SOdhOppsHkwNoqWKEsAKumLAEPWY.wjFGpzhPvGZUiYJRtvzzxtorJfIj A_1, SOdhOppsHkwNoqWKEsAKumLAEPWY.eQbacLZJTniCaSExlwvFVsMtiaKb.MkhVFYeRwqOLJBkgkFsqnUTqfmdhA A_2)
		{
			int count = this.IQLqRPGKolSyuewolepgVvgXSHkN.Count;
			int num;
			for (int i = 0; i < count; i = num + 1)
			{
				if (this.IQLqRPGKolSyuewolepgVvgXSHkN[i].DHbbWUSLIeJKyehGTwIqVyLqdPTP(A_1, A_2))
				{
					yield return this.IQLqRPGKolSyuewolepgVvgXSHkN[i];
				}
				num = i;
			}
			yield break;
		}

		// Token: 0x060014F4 RID: 5364 RVA: 0x0004A998 File Offset: 0x00048B98
		private void WqpqHTJyoESlJSHGWzufCflpBKKCA(int A_1, Guid A_2, int A_3)
		{
			for (int i = this.IQLqRPGKolSyuewolepgVvgXSHkN.Count - 1; i >= 0; i--)
			{
				if (i != A_3 && (this.IQLqRPGKolSyuewolepgVvgXSHkN[i].dApPKzsOyzFNOBtjNZbOLBcteyDE == A_1 || this.IQLqRPGKolSyuewolepgVvgXSHkN[i].mgkjgtDMExnNiCFUIcxlagvEbaNBb == A_2))
				{
					this.IQLqRPGKolSyuewolepgVvgXSHkN.RemoveAt(i);
				}
			}
		}

		// Token: 0x04002EC7 RID: 11975
		private List<SOdhOppsHkwNoqWKEsAKumLAEPWY.eQbacLZJTniCaSExlwvFVsMtiaKb.PSGVtTmDZaEbrJtmutKHqxqubvpUA> IQLqRPGKolSyuewolepgVvgXSHkN;

		// Token: 0x020002C4 RID: 708
		public enum MkhVFYeRwqOLJBkgkFsqnUTqfmdhA
		{
			// Token: 0x04002EC9 RID: 11977
			Exact,
			// Token: 0x04002ECA RID: 11978
			Approximate
		}

		// Token: 0x020002C5 RID: 709
		public class PSGVtTmDZaEbrJtmutKHqxqubvpUA
		{
			// Token: 0x060014F5 RID: 5365 RVA: 0x0004A9FC File Offset: 0x00048BFC
			public bool DHbbWUSLIeJKyehGTwIqVyLqdPTP(SOdhOppsHkwNoqWKEsAKumLAEPWY.wjFGpzhPvGZUiYJRtvzzxtorJfIj A_1, SOdhOppsHkwNoqWKEsAKumLAEPWY.eQbacLZJTniCaSExlwvFVsMtiaKb.MkhVFYeRwqOLJBkgkFsqnUTqfmdhA A_2)
			{
				if (A_1.rewiredId == this.dApPKzsOyzFNOBtjNZbOLBcteyDE)
				{
					return true;
				}
				if (this.WmwcDEGLHZFwSmCNWCGJIipDDXIoc != A_1.hMpyylQdVKbgBPfPfiMWBfQzRMnG)
				{
					return false;
				}
				if (this.HhyWglIXykDOaBIoimuDptoxmcNJ != A_1.jYfXZqaPxUpWStdGpTXslBdgizQeA)
				{
					return false;
				}
				if (this.QRRXEDQLIyBkDfBkimSraRCePauhA != A_1.fZfrSQNqWYAMIPUKQrPXlNmplWbb)
				{
					return false;
				}
				if (A_2 == SOdhOppsHkwNoqWKEsAKumLAEPWY.eQbacLZJTniCaSExlwvFVsMtiaKb.MkhVFYeRwqOLJBkgkFsqnUTqfmdhA.Exact)
				{
					return this.mgkjgtDMExnNiCFUIcxlagvEbaNBb == A_1.zSkjyGyleJHpnFakwerDkyVEQgfMA;
				}
				if (A_2 == SOdhOppsHkwNoqWKEsAKumLAEPWY.eQbacLZJTniCaSExlwvFVsMtiaKb.MkhVFYeRwqOLJBkgkFsqnUTqfmdhA.Approximate)
				{
					return this.PopAkxCqWpRbWoBVsYflMCbgeWtB == A_1.DqZyVEnuZExNIfCqnJpQkjdNIUDr;
				}
				throw new NotImplementedException();
			}

			// Token: 0x04002ECB RID: 11979
			public int dApPKzsOyzFNOBtjNZbOLBcteyDE;

			// Token: 0x04002ECC RID: 11980
			public Guid mgkjgtDMExnNiCFUIcxlagvEbaNBb;

			// Token: 0x04002ECD RID: 11981
			public Guid PopAkxCqWpRbWoBVsYflMCbgeWtB;

			// Token: 0x04002ECE RID: 11982
			public int GaIhjDJBCAkKKRvrvIXCTBFFmYWT;

			// Token: 0x04002ECF RID: 11983
			public int WmwcDEGLHZFwSmCNWCGJIipDDXIoc;

			// Token: 0x04002ED0 RID: 11984
			public int HhyWglIXykDOaBIoimuDptoxmcNJ;

			// Token: 0x04002ED1 RID: 11985
			public int QRRXEDQLIyBkDfBkimSraRCePauhA;
		}
	}
}
