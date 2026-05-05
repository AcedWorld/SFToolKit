using System;
using Rewired;
using Rewired.Platforms.Microsoft.WindowsGamingInput;

// Token: 0x020000A4 RID: 164
internal sealed class IbdfoVkCYOJkjATrURkAWolxdaurA : khFtVaVlCxqEfcUymOxXQstyFBiL
{
	// Token: 0x1700011B RID: 283
	// (get) Token: 0x060005B1 RID: 1457 RVA: 0x00013E6F File Offset: 0x0001206F
	public npeFzFFBQqrIoNKuecNDbCOHzNtgA NZqziYepfEXXCdWsTKulipskmgzF
	{
		get
		{
			return this.cluwHDNJthbckAwlKvdlgPfszphF;
		}
	}

	// Token: 0x060005B2 RID: 1458 RVA: 0x00013E77 File Offset: 0x00012077
	public IbdfoVkCYOJkjATrURkAWolxdaurA(npeFzFFBQqrIoNKuecNDbCOHzNtgA A_1, int A_2, Action<npeFzFFBQqrIoNKuecNDbCOHzNtgA, BnFiTEhittEzLCwZuNtphKZVBdZZA> A_3) : base(WGIDeviceType.Gamepad, A_1, A_2, 14, 6, 0)
	{
		if (npeFzFFBQqrIoNKuecNDbCOHzNtgA.vvNQHaCQVeDIevISkoFJcpDrCmIR(A_1, null))
		{
			throw new ArgumentNullException("gamepad");
		}
		if (A_3 == null)
		{
			throw new ArgumentNullException("commitVibrationDelegate");
		}
		this.cluwHDNJthbckAwlKvdlgPfszphF = A_1;
		this.cZmgaulIXOPJwsgNYCvSWaRZqvcW = A_3;
	}

	// Token: 0x060005B3 RID: 1459 RVA: 0x00032AA0 File Offset: 0x00030CA0
	public void dePLTJRRyTLncmuCZWYVyBNNtYdl(OYybvidAyFwiwrJXZnlYENlOguncA A_1, double A_2)
	{
		this.aAYTMxHaQIOqslmMyIbeUrzvHjkQ.SetValue(0, (A_1.apnbLyJEKtlNNjbwargINlZQfSQec & GamepadButtons.A) > GamepadButtons.None, A_2);
		this.aAYTMxHaQIOqslmMyIbeUrzvHjkQ.SetValue(1, (A_1.apnbLyJEKtlNNjbwargINlZQfSQec & GamepadButtons.B) > GamepadButtons.None, A_2);
		this.aAYTMxHaQIOqslmMyIbeUrzvHjkQ.SetValue(2, (A_1.apnbLyJEKtlNNjbwargINlZQfSQec & GamepadButtons.X) > GamepadButtons.None, A_2);
		this.aAYTMxHaQIOqslmMyIbeUrzvHjkQ.SetValue(3, (A_1.apnbLyJEKtlNNjbwargINlZQfSQec & GamepadButtons.Y) > GamepadButtons.None, A_2);
		this.aAYTMxHaQIOqslmMyIbeUrzvHjkQ.SetValue(4, (A_1.apnbLyJEKtlNNjbwargINlZQfSQec & GamepadButtons.LeftShoulder) > GamepadButtons.None, A_2);
		this.aAYTMxHaQIOqslmMyIbeUrzvHjkQ.SetValue(5, (A_1.apnbLyJEKtlNNjbwargINlZQfSQec & GamepadButtons.RightShoulder) > GamepadButtons.None, A_2);
		this.aAYTMxHaQIOqslmMyIbeUrzvHjkQ.SetValue(6, (A_1.apnbLyJEKtlNNjbwargINlZQfSQec & GamepadButtons.View) > GamepadButtons.None, A_2);
		this.aAYTMxHaQIOqslmMyIbeUrzvHjkQ.SetValue(7, (A_1.apnbLyJEKtlNNjbwargINlZQfSQec & GamepadButtons.Menu) > GamepadButtons.None, A_2);
		this.aAYTMxHaQIOqslmMyIbeUrzvHjkQ.SetValue(8, (A_1.apnbLyJEKtlNNjbwargINlZQfSQec & GamepadButtons.LeftThumbstick) > GamepadButtons.None, A_2);
		this.aAYTMxHaQIOqslmMyIbeUrzvHjkQ.SetValue(9, (A_1.apnbLyJEKtlNNjbwargINlZQfSQec & GamepadButtons.RightThumbstick) > GamepadButtons.None, A_2);
		this.aAYTMxHaQIOqslmMyIbeUrzvHjkQ.SetValue(10, (A_1.apnbLyJEKtlNNjbwargINlZQfSQec & GamepadButtons.DPadUp) > GamepadButtons.None, A_2);
		this.aAYTMxHaQIOqslmMyIbeUrzvHjkQ.SetValue(11, (A_1.apnbLyJEKtlNNjbwargINlZQfSQec & GamepadButtons.DPadRight) > GamepadButtons.None, A_2);
		this.aAYTMxHaQIOqslmMyIbeUrzvHjkQ.SetValue(12, (A_1.apnbLyJEKtlNNjbwargINlZQfSQec & GamepadButtons.DPadDown) > GamepadButtons.None, A_2);
		this.aAYTMxHaQIOqslmMyIbeUrzvHjkQ.SetValue(13, (A_1.apnbLyJEKtlNNjbwargINlZQfSQec & GamepadButtons.DPadLeft) > GamepadButtons.None, A_2);
		this.XQHZAOnmVnoAjuuHFElzIXjyfCfQ[0].pnzEhrxirBFxtkpfXpxaLfCIetYm = (float)A_1.vCUrofYSGcHJVEpUMRUJaSlSjSav;
		this.XQHZAOnmVnoAjuuHFElzIXjyfCfQ[1].pnzEhrxirBFxtkpfXpxaLfCIetYm = (float)A_1.zrznuQIWMZDwOWndxokPtjzyJBHb;
		this.XQHZAOnmVnoAjuuHFElzIXjyfCfQ[2].pnzEhrxirBFxtkpfXpxaLfCIetYm = (float)A_1.DQlJUcdtCMDRENTSfbIUPkdzLawd;
		this.XQHZAOnmVnoAjuuHFElzIXjyfCfQ[3].pnzEhrxirBFxtkpfXpxaLfCIetYm = (float)A_1.IDZsZhXFqIboWspgWHAWMqrRPCzu;
		this.XQHZAOnmVnoAjuuHFElzIXjyfCfQ[4].pnzEhrxirBFxtkpfXpxaLfCIetYm = (float)A_1.YCVhIgfhKgSflZcCYGVFMSGzszxR;
		this.XQHZAOnmVnoAjuuHFElzIXjyfCfQ[5].pnzEhrxirBFxtkpfXpxaLfCIetYm = (float)A_1.dKchtowqUEKUHblPxnJObOtjImqP;
	}

	// Token: 0x1700011C RID: 284
	// (get) Token: 0x060005B4 RID: 1460 RVA: 0x0001164A File Offset: 0x0000F84A
	public override bool ORMogkZMylcNfXEHavwWfGxkNOdQ
	{
		get
		{
			return true;
		}
	}

	// Token: 0x1700011D RID: 285
	// (get) Token: 0x060005B5 RID: 1461 RVA: 0x00013906 File Offset: 0x00011B06
	public override int qnMfhUBNGhcgORXYQQcdpJaknxJL
	{
		get
		{
			return 4;
		}
	}

	// Token: 0x060005B6 RID: 1462 RVA: 0x00013EB6 File Offset: 0x000120B6
	public void vKNXvaNMyjfDugdZnmOWRUysKZNy(UpdateLoopType A_1)
	{
		base.HNOkLPGjTMelBuPoPqesvzLHXckm(A_1);
		this.TtEZqfChGYeTIlVMZILdKAnWctXBb();
	}

	// Token: 0x060005B7 RID: 1463 RVA: 0x00032C9C File Offset: 0x00030E9C
	public void XnmbxGeSXfAurFHfbeCPmoZNbIIu(cWYIDMjUnhAyDysKZVfQnpWFBosr A_1)
	{
		base.ujBFyXaFbxcLMUISMqtqiyMPHBEB(A_1);
		IbdfoVkCYOJkjATrURkAWolxdaurA ibdfoVkCYOJkjATrURkAWolxdaurA = A_1 as IbdfoVkCYOJkjATrURkAWolxdaurA;
		if (ibdfoVkCYOJkjATrURkAWolxdaurA == null)
		{
			return;
		}
		this.cluwHDNJthbckAwlKvdlgPfszphF = ibdfoVkCYOJkjATrURkAWolxdaurA.cluwHDNJthbckAwlKvdlgPfszphF;
	}

	// Token: 0x060005B8 RID: 1464 RVA: 0x00032CC8 File Offset: 0x00030EC8
	public float NrBODiDdbtETrZZOWgwBnurXGgCX(int A_1)
	{
		BnFiTEhittEzLCwZuNtphKZVBdZZA bnFiTEhittEzLCwZuNtphKZVBdZZA = this.cluwHDNJthbckAwlKvdlgPfszphF.ZiKQowwNPrzYmPsOXmQdSiYUWxbU;
		switch (A_1)
		{
		case 0:
			return (float)bnFiTEhittEzLCwZuNtphKZVBdZZA.hOeWYATPdtUuwqiUasnhEsSlLouK;
		case 1:
			return (float)bnFiTEhittEzLCwZuNtphKZVBdZZA.HdmABgZwodlRHJNCouRtpINZsmCS;
		case 2:
			return (float)bnFiTEhittEzLCwZuNtphKZVBdZZA.xwGmMpvOLYDiQlgNsRAOkvAqChVG;
		case 3:
			return (float)bnFiTEhittEzLCwZuNtphKZVBdZZA.pcVNASyjIriEZjYyJAXrmLmZvfhH;
		default:
			return 0f;
		}
	}

	// Token: 0x060005B9 RID: 1465 RVA: 0x00032D20 File Offset: 0x00030F20
	public void ntkXXlYowgzIvaDERfbSBGQLxfXj(int A_1, float A_2, bool A_3)
	{
		if (A_1 < 0 || A_1 >= 4)
		{
			return;
		}
		if (A_2 < 0f)
		{
			A_2 = 0f;
		}
		else if (A_2 > 1f)
		{
			A_2 = 1f;
		}
		if (A_3)
		{
			this.VoMALdAtmDblkalArpJcVmkRiGfq(ref this.dvToqzEdIxcpPIULoRHCUztPMxHh);
		}
		switch (A_1)
		{
		case 0:
			this.dvToqzEdIxcpPIULoRHCUztPMxHh.hOeWYATPdtUuwqiUasnhEsSlLouK = (double)A_2;
			break;
		case 1:
			this.dvToqzEdIxcpPIULoRHCUztPMxHh.HdmABgZwodlRHJNCouRtpINZsmCS = (double)A_2;
			break;
		case 2:
			this.dvToqzEdIxcpPIULoRHCUztPMxHh.xwGmMpvOLYDiQlgNsRAOkvAqChVG = (double)A_2;
			break;
		case 3:
			this.dvToqzEdIxcpPIULoRHCUztPMxHh.pcVNASyjIriEZjYyJAXrmLmZvfhH = (double)A_2;
			break;
		}
		this.uVvjbLIrQVyDNtwhvIXQyDVTLswe(false);
	}

	// Token: 0x060005BA RID: 1466 RVA: 0x00013EC5 File Offset: 0x000120C5
	public void jjzNWBIdUPgHAHHWvIbMEaNDQbVpb()
	{
		this.VoMALdAtmDblkalArpJcVmkRiGfq(ref this.dvToqzEdIxcpPIULoRHCUztPMxHh);
		this.uVvjbLIrQVyDNtwhvIXQyDVTLswe(true);
	}

	// Token: 0x060005BB RID: 1467 RVA: 0x00013EDA File Offset: 0x000120DA
	private void TtEZqfChGYeTIlVMZILdKAnWctXBb()
	{
		if (this.OMIDRIDNsWLcKREPTEeSLfxtslmoA)
		{
			this.pJpvPjggHEYRZnmPfvBYKLVbLJeO();
		}
		this.FXlhdpMIGqOOccRqIIKuugHDGTsfA();
	}

	// Token: 0x060005BC RID: 1468 RVA: 0x00013EF0 File Offset: 0x000120F0
	private void FXlhdpMIGqOOccRqIIKuugHDGTsfA()
	{
		if (ReInput.unscaledTime < this.JukUFYVOrZxuMIGkOJEVgTTaoUex)
		{
			return;
		}
		if (!this.FhRexOOIfVAojByuXQFQrDunAZZzA(ref this.dvToqzEdIxcpPIULoRHCUztPMxHh))
		{
			return;
		}
		this.uVvjbLIrQVyDNtwhvIXQyDVTLswe(true);
	}

	// Token: 0x060005BD RID: 1469 RVA: 0x00013F16 File Offset: 0x00012116
	private void uVvjbLIrQVyDNtwhvIXQyDVTLswe(bool A_1)
	{
		this.OMIDRIDNsWLcKREPTEeSLfxtslmoA = true;
		if (A_1)
		{
			this.UwxsylNIwvvoYyJcIglxPwCoWDqJ();
		}
	}

	// Token: 0x060005BE RID: 1470 RVA: 0x00013F28 File Offset: 0x00012128
	private void pJpvPjggHEYRZnmPfvBYKLVbLJeO()
	{
		if (!this.OMIDRIDNsWLcKREPTEeSLfxtslmoA)
		{
			return;
		}
		if (ReInput.unscaledTime < this.fAMmxsTXtWMSUYsfEmzgZmoOSqUc + 0.009999999776482582)
		{
			return;
		}
		this.UwxsylNIwvvoYyJcIglxPwCoWDqJ();
	}

	// Token: 0x060005BF RID: 1471 RVA: 0x00032DC0 File Offset: 0x00030FC0
	private void UwxsylNIwvvoYyJcIglxPwCoWDqJ()
	{
		if (!this.FhRexOOIfVAojByuXQFQrDunAZZzA(ref this.dvToqzEdIxcpPIULoRHCUztPMxHh) && !this.FhRexOOIfVAojByuXQFQrDunAZZzA(ref this.wcZVeYqYPvCEILzimvIztztrXuSh))
		{
			this.OMIDRIDNsWLcKREPTEeSLfxtslmoA = false;
			return;
		}
		this.cZmgaulIXOPJwsgNYCvSWaRZqvcW(this.cluwHDNJthbckAwlKvdlgPfszphF, this.dvToqzEdIxcpPIULoRHCUztPMxHh);
		double unscaledTime = ReInput.unscaledTime;
		this.JukUFYVOrZxuMIGkOJEVgTTaoUex = unscaledTime + 1.5;
		this.fAMmxsTXtWMSUYsfEmzgZmoOSqUc = unscaledTime;
		this.PoVUQyndhybwzIQwiTSIFEBsBFbK(ref this.dvToqzEdIxcpPIULoRHCUztPMxHh, ref this.wcZVeYqYPvCEILzimvIztztrXuSh);
		this.OMIDRIDNsWLcKREPTEeSLfxtslmoA = false;
	}

	// Token: 0x060005C0 RID: 1472 RVA: 0x00032E40 File Offset: 0x00031040
	private bool FhRexOOIfVAojByuXQFQrDunAZZzA(ref BnFiTEhittEzLCwZuNtphKZVBdZZA A_1)
	{
		return A_1.hOeWYATPdtUuwqiUasnhEsSlLouK > 0.0 || A_1.HdmABgZwodlRHJNCouRtpINZsmCS > 0.0 || A_1.xwGmMpvOLYDiQlgNsRAOkvAqChVG > 0.0 || A_1.pcVNASyjIriEZjYyJAXrmLmZvfhH > 0.0;
	}

	// Token: 0x060005C1 RID: 1473 RVA: 0x00013F51 File Offset: 0x00012151
	private void VoMALdAtmDblkalArpJcVmkRiGfq(ref BnFiTEhittEzLCwZuNtphKZVBdZZA A_1)
	{
		A_1.hOeWYATPdtUuwqiUasnhEsSlLouK = 0.0;
		A_1.HdmABgZwodlRHJNCouRtpINZsmCS = 0.0;
		A_1.xwGmMpvOLYDiQlgNsRAOkvAqChVG = 0.0;
		A_1.pcVNASyjIriEZjYyJAXrmLmZvfhH = 0.0;
	}

	// Token: 0x060005C2 RID: 1474 RVA: 0x00013F8F File Offset: 0x0001218F
	private void PoVUQyndhybwzIQwiTSIFEBsBFbK(ref BnFiTEhittEzLCwZuNtphKZVBdZZA A_1, ref BnFiTEhittEzLCwZuNtphKZVBdZZA A_2)
	{
		A_2.hOeWYATPdtUuwqiUasnhEsSlLouK = A_1.hOeWYATPdtUuwqiUasnhEsSlLouK;
		A_2.HdmABgZwodlRHJNCouRtpINZsmCS = A_1.HdmABgZwodlRHJNCouRtpINZsmCS;
		A_2.xwGmMpvOLYDiQlgNsRAOkvAqChVG = A_1.xwGmMpvOLYDiQlgNsRAOkvAqChVG;
		A_2.pcVNASyjIriEZjYyJAXrmLmZvfhH = A_1.pcVNASyjIriEZjYyJAXrmLmZvfhH;
	}

	// Token: 0x060005C3 RID: 1475 RVA: 0x00032E94 File Offset: 0x00031094
	protected bool HvaaSaBDjDuuWJqEUYkdArZyXroHA(bool A_1)
	{
		if (base.sxybqEfrlMKOTuGlKQTMuAVRKkhhA(A_1))
		{
			return true;
		}
		if (A_1 && npeFzFFBQqrIoNKuecNDbCOHzNtgA.wzbxJnnyXZAZIidIBHbbjSEaVPFpA(this.cluwHDNJthbckAwlKvdlgPfszphF, null))
		{
			try
			{
				this.cluwHDNJthbckAwlKvdlgPfszphF.ZiKQowwNPrzYmPsOXmQdSiYUWxbU = default(BnFiTEhittEzLCwZuNtphKZVBdZZA);
			}
			catch
			{
			}
		}
		return false;
	}

	// Token: 0x0400063B RID: 1595
	private const int eyDLuPbiKqFgsiUmYOQCRbljCZsv = 14;

	// Token: 0x0400063C RID: 1596
	private const int wvnWSZPCdAGlkFckFoBcnHdYqHwbA = 6;

	// Token: 0x0400063D RID: 1597
	private const int MjsjrUXIKVxMsRpsWwFskpZsHwFt = 0;

	// Token: 0x0400063E RID: 1598
	private const int yRjjebxqGdFnKkDnUrubdJEsMDEaA = 4;

	// Token: 0x0400063F RID: 1599
	private const bool PVvGWfbsPkHzUFUVisqLeEcpTgHZB = true;

	// Token: 0x04000640 RID: 1600
	private npeFzFFBQqrIoNKuecNDbCOHzNtgA cluwHDNJthbckAwlKvdlgPfszphF;

	// Token: 0x04000641 RID: 1601
	private BnFiTEhittEzLCwZuNtphKZVBdZZA dvToqzEdIxcpPIULoRHCUztPMxHh;

	// Token: 0x04000642 RID: 1602
	private BnFiTEhittEzLCwZuNtphKZVBdZZA wcZVeYqYPvCEILzimvIztztrXuSh;

	// Token: 0x04000643 RID: 1603
	private double JukUFYVOrZxuMIGkOJEVgTTaoUex;

	// Token: 0x04000644 RID: 1604
	private bool OMIDRIDNsWLcKREPTEeSLfxtslmoA;

	// Token: 0x04000645 RID: 1605
	private double fAMmxsTXtWMSUYsfEmzgZmoOSqUc;

	// Token: 0x04000646 RID: 1606
	private Action<npeFzFFBQqrIoNKuecNDbCOHzNtgA, BnFiTEhittEzLCwZuNtphKZVBdZZA> cZmgaulIXOPJwsgNYCvSWaRZqvcW;
}
