using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired;
using Rewired.Config;
using Rewired.Data;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

// Token: 0x020000FC RID: 252
internal sealed class iWmRLdlDqgwSNYjkwtUZeqvQOyqs
{
	// Token: 0x0600080E RID: 2062 RVA: 0x0003E3A8 File Offset: 0x0003C5A8
	internal iWmRLdlDqgwSNYjkwtUZeqvQOyqs(int A_1, InputAction A_2, InputBehavior A_3, ConfigVars A_4)
	{
		this.grQLaDCoGckJoEhFwHgbebszQXIA = ReInput._id;
		iWmRLdlDqgwSNYjkwtUZeqvQOyqs.dFaxFlOasBUZzgcgcjkCEwllVeoZ = A_4;
		this.gXJUvoJEafjcKDtEeDnLNOIcxzbeA = A_1;
		this.nrhdAYZedZAtVEfTnqlPfrkEHCxob = A_2.id;
		this.jonnDVebvEGpPeggsRvHIZVsBTjWA = A_2.name;
		this.rJTXqhKmQofPKSWJGJwxytrnVozW = A_3;
		this.EfzniShYpznHExIiEDnVhtklrBaJA = new iWmRLdlDqgwSNYjkwtUZeqvQOyqs.vFRlHIZERiUepZIjRBsqmFqNEpvS(A_4.updateLoop, A_3);
		this.jjPovPtetSHbMSjORRJKMHTpfOzY = new ccTpHyuBLmqwaKhsPmaxvVJtLJHK[4];
		ArrayTools.Populate<ccTpHyuBLmqwaKhsPmaxvVJtLJHK>(this.jjPovPtetSHbMSjORRJKMHTpfOzY);
		this.ozEBRqhkACPNflMPraesEvZcPnRfB = new List<InputActionSourceData>();
		this.tCmvcGYbHxdleOTAiEQrJxvthmJY = new ReadOnlyCollection<InputActionSourceData>(this.ozEBRqhkACPNflMPraesEvZcPnRfB);
	}

	// Token: 0x0600080F RID: 2063 RVA: 0x00008D0D File Offset: 0x00006F0D
	internal static void SIsptHzTmROmfVAEbDdDcmhWoEah(ConfigVars A_0)
	{
		iWmRLdlDqgwSNYjkwtUZeqvQOyqs.zyKCinSdJxEAyzJGNjJDHOCtVKNU = new iWmRLdlDqgwSNYjkwtUZeqvQOyqs.WjdzkcSlJmaHWCXWmLVbvguSGYbF(A_0.updateLoop);
	}

	// Token: 0x06000810 RID: 2064 RVA: 0x00008D1F File Offset: 0x00006F1F
	internal static void mEmjwDicdQrGojXTvgKpBldpXqJE(UpdateLoopType A_0)
	{
		iWmRLdlDqgwSNYjkwtUZeqvQOyqs.OwjVJuTiPkEWVFyHYdmSJpRETjSI = A_0;
		iWmRLdlDqgwSNYjkwtUZeqvQOyqs.yAmVOKAzQbbmGgwQiXjbiiDizlpf = ReInput.unscaledTime;
		iWmRLdlDqgwSNYjkwtUZeqvQOyqs.MeSfMuugNEENLeckTfhpdKMrgqPnA = (float)ReInput.unscaledDeltaTime;
		iWmRLdlDqgwSNYjkwtUZeqvQOyqs.frbfpZwcOFYoVvZHeVhfeGZBtOQP = ReInput.absFrame;
		iWmRLdlDqgwSNYjkwtUZeqvQOyqs.zyKCinSdJxEAyzJGNjJDHOCtVKNU.rEOugKBotxolnhTZwmBnbWDbbXDo(A_0);
	}

	// Token: 0x06000811 RID: 2065 RVA: 0x00008D51 File Offset: 0x00006F51
	internal static void sjqxeIfowPwCZVIHkexDOhrzYmki()
	{
		iWmRLdlDqgwSNYjkwtUZeqvQOyqs.zyKCinSdJxEAyzJGNjJDHOCtVKNU.VhWfJNBOnBVHfCceDtivEFvbpraEA();
	}

	// Token: 0x06000812 RID: 2066 RVA: 0x0003E44C File Offset: 0x0003C64C
	private void qIUgBlVFgyImAHCjApfdsTSKWlRM()
	{
		this.EfzniShYpznHExIiEDnVhtklrBaJA.CcBAOPWxGfqAZbtIVQKpKoVsWsxL = iWmRLdlDqgwSNYjkwtUZeqvQOyqs.OwjVJuTiPkEWVFyHYdmSJpRETjSI;
		this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.LKTgToGaVCqnzcaNQaDKWSKRCPoAb();
		this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.flMaPUdHHQPjtaepKEnFWokhHXvWB();
		if (this.VaFSDsvOVqCMTcFMtSuUyfmlaqkc != 0f)
		{
			this.VaFSDsvOVqCMTcFMtSuUyfmlaqkc = 0f;
		}
		if (this.rMBhqGnNfagmBbcJOBteWopkYQRV != 0f)
		{
			this.rMBhqGnNfagmBbcJOBteWopkYQRV = 0f;
		}
		if (this.IiTKwDafEniDsGuzAWEvOkMMdpp != ButtonStateFlags.Off)
		{
			this.IiTKwDafEniDsGuzAWEvOkMMdpp = ButtonStateFlags.Off;
		}
		if (this.zrKaXNmwcmBTKTFrTvMxJGyZfgdM != ButtonStateFlags.Off)
		{
			this.zrKaXNmwcmBTKTFrTvMxJGyZfgdM = ButtonStateFlags.Off;
		}
		if (this.CaLDBRHvlNFXvZwABfurdANAvhznB != 0f)
		{
			this.CaLDBRHvlNFXvZwABfurdANAvhznB = 0f;
		}
		if (this.kQzxJVdVXAdMvxaIIVxDOuvECeOJ)
		{
			this.kQzxJVdVXAdMvxaIIVxDOuvECeOJ = false;
		}
		if (this.zJBSUQrnvxkynHsRXicmZPuwWTVU != 0f)
		{
			this.zJBSUQrnvxkynHsRXicmZPuwWTVU = 0f;
		}
		if (this.KqEGbYsGmEwuRqwPugliehFKmgs != 0f)
		{
			this.KqEGbYsGmEwuRqwPugliehFKmgs = 0f;
		}
		if (this.HsJszjooZfoMkIANvCWYEfVLFyWs != AxisCoordinateMode.Absolute)
		{
			this.HsJszjooZfoMkIANvCWYEfVLFyWs = AxisCoordinateMode.Absolute;
		}
		if (this.ZdbpEqJEdnFGyDmdHanWfJldRaqq != AxisCoordinateMode.Absolute)
		{
			this.ZdbpEqJEdnFGyDmdHanWfJldRaqq = AxisCoordinateMode.Absolute;
		}
		if (this.LktQdLgzjAhaaEfiaANGESLYEyQw > 0)
		{
			this.UdaVvjvaqLFoynuaxmefEBbIPjip();
		}
		if (this.pzJUUTODAnhhmdbzOIFrkzCFKICY.OtmtFBDRpRaatsUBcawnGPBqpNgCA)
		{
			this.pzJUUTODAnhhmdbzOIFrkzCFKICY.neLNINJxygNHYyqXiEcdEuevUEui();
		}
	}

	// Token: 0x06000813 RID: 2067 RVA: 0x0003E574 File Offset: 0x0003C774
	internal void nluXWdPInMuffiIXkYFVgBuDvMwm(bool A_1)
	{
		if (this.UTpDuunHtLEtGAaYEkIDRPdLPZDWA != iWmRLdlDqgwSNYjkwtUZeqvQOyqs.frbfpZwcOFYoVvZHeVhfeGZBtOQP)
		{
			this.UTpDuunHtLEtGAaYEkIDRPdLPZDWA = iWmRLdlDqgwSNYjkwtUZeqvQOyqs.frbfpZwcOFYoVvZHeVhfeGZBtOQP;
			if (this.jQnfIrgfITcEUlPeWOuZMMcIYHqFA != this.KtabwngytZNqqQLTKorCaAvKHyzX)
			{
				this.jQnfIrgfITcEUlPeWOuZMMcIYHqFA = this.KtabwngytZNqqQLTKorCaAvKHyzX;
			}
			if (this.FTSguAcJYczMlZkHpDdfJFjfzvIr)
			{
				this.qIUgBlVFgyImAHCjApfdsTSKWlRM();
			}
			else if (this.KtabwngytZNqqQLTKorCaAvKHyzX == iWmRLdlDqgwSNYjkwtUZeqvQOyqs.RMpfvDpfwUakDjETyOTCXnXoYFGU.Disabled)
			{
				this.KtabwngytZNqqQLTKorCaAvKHyzX = iWmRLdlDqgwSNYjkwtUZeqvQOyqs.RMpfvDpfwUakDjETyOTCXnXoYFGU.Idle;
			}
		}
		if (!A_1)
		{
			return;
		}
		if (this.yYLEHWciMjTZaQrepBiHsDioTnLMA != iWmRLdlDqgwSNYjkwtUZeqvQOyqs.frbfpZwcOFYoVvZHeVhfeGZBtOQP)
		{
			this.yYLEHWciMjTZaQrepBiHsDioTnLMA = iWmRLdlDqgwSNYjkwtUZeqvQOyqs.frbfpZwcOFYoVvZHeVhfeGZBtOQP;
			if (!this.FTSguAcJYczMlZkHpDdfJFjfzvIr)
			{
				this.WwYBZSAWstESwDWIhcKzArlTjEBH();
				this.qIUgBlVFgyImAHCjApfdsTSKWlRM();
			}
			this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.aMhwTdaihjfytqfieIrkjLzZPPbXA = iWmRLdlDqgwSNYjkwtUZeqvQOyqs.yAmVOKAzQbbmGgwQiXjbiiDizlpf;
		}
		JataafgUmrvbnTlMuiLhrcBTEPfd dgjVhstXQWqvCxiamNQKKHhbOocL = iWmRLdlDqgwSNYjkwtUZeqvQOyqs.DgjVhstXQWqvCxiamNQKKHhbOocL;
		int mRCBQDgzARDPVbNsvhiBadcDxEwTB = dgjVhstXQWqvCxiamNQKKHhbOocL.jMEqHZPiCdPoKLgzvxltMnUhaoSH.mRCBQDgzARDPVbNsvhiBadcDxEwTB;
		this.XBAYTLBUhMFSGaMtKyAyyGqTcTum(dgjVhstXQWqvCxiamNQKKHhbOocL.xadwTlbiqMnQJKpkbwcTSEJqFKyN, dgjVhstXQWqvCxiamNQKKHhbOocL.wwVloXlzGdiPzMmaSrTJsEEKVkzC, dgjVhstXQWqvCxiamNQKKHhbOocL.jMEqHZPiCdPoKLgzvxltMnUhaoSH);
		if (dgjVhstXQWqvCxiamNQKKHhbOocL.xqKIdHbHXOEZvhWKNQasyVhQmkIA == ControllerElementType.Button)
		{
			if (dgjVhstXQWqvCxiamNQKKHhbOocL.rNmnzBBvEKYTVyjrVykrUlpZDyAc)
			{
				if (dgjVhstXQWqvCxiamNQKKHhbOocL.jMEqHZPiCdPoKLgzvxltMnUhaoSH._axisContribution == Pole.Positive)
				{
					iWmRLdlDqgwSNYjkwtUZeqvQOyqs.BojyZKptYegswXilIAapBZtXlQyW(ref this.IiTKwDafEniDsGuzAWEvOkMMdpp, dgjVhstXQWqvCxiamNQKKHhbOocL.eyvxnJpMZeEZcENTKtcvIFJLyWAO);
				}
				else
				{
					iWmRLdlDqgwSNYjkwtUZeqvQOyqs.BojyZKptYegswXilIAapBZtXlQyW(ref this.zrKaXNmwcmBTKTFrTvMxJGyZfgdM, dgjVhstXQWqvCxiamNQKKHhbOocL.eyvxnJpMZeEZcENTKtcvIFJLyWAO);
				}
				if (this.HsJszjooZfoMkIANvCWYEfVLFyWs == AxisCoordinateMode.Absolute)
				{
					this.VaFSDsvOVqCMTcFMtSuUyfmlaqkc += dgjVhstXQWqvCxiamNQKKHhbOocL.utdxJIHkatoxBldAvWBbZTVbaFcl;
					return;
				}
			}
			else
			{
				if (dgjVhstXQWqvCxiamNQKKHhbOocL.jMEqHZPiCdPoKLgzvxltMnUhaoSH._axisContribution == Pole.Positive)
				{
					iWmRLdlDqgwSNYjkwtUZeqvQOyqs.BojyZKptYegswXilIAapBZtXlQyW(ref this.IiTKwDafEniDsGuzAWEvOkMMdpp, dgjVhstXQWqvCxiamNQKKHhbOocL.eyvxnJpMZeEZcENTKtcvIFJLyWAO);
				}
				else
				{
					iWmRLdlDqgwSNYjkwtUZeqvQOyqs.BojyZKptYegswXilIAapBZtXlQyW(ref this.zrKaXNmwcmBTKTFrTvMxJGyZfgdM, dgjVhstXQWqvCxiamNQKKHhbOocL.eyvxnJpMZeEZcENTKtcvIFJLyWAO);
				}
				if (dgjVhstXQWqvCxiamNQKKHhbOocL.utdxJIHkatoxBldAvWBbZTVbaFcl != 0f)
				{
					this.CaLDBRHvlNFXvZwABfurdANAvhznB += (float)((int)(1f * MathTools.Sign(dgjVhstXQWqvCxiamNQKKHhbOocL.utdxJIHkatoxBldAvWBbZTVbaFcl)));
					this.pzJUUTODAnhhmdbzOIFrkzCFKICY.felxCEZdogJfegKqSkmYNKvgydUX(dgjVhstXQWqvCxiamNQKKHhbOocL);
				}
				if ((dgjVhstXQWqvCxiamNQKKHhbOocL.eyvxnJpMZeEZcENTKtcvIFJLyWAO & ButtonStateFlags.On) != ButtonStateFlags.Off)
				{
					this.kQzxJVdVXAdMvxaIIVxDOuvECeOJ = true;
					return;
				}
			}
			return;
		}
		if (dgjVhstXQWqvCxiamNQKKHhbOocL.xqKIdHbHXOEZvhWKNQasyVhQmkIA != ControllerElementType.Axis)
		{
			throw new NotImplementedException();
		}
		ControllerType ngcWpJIBgJyvJEPNRloRpkQSpiZk = dgjVhstXQWqvCxiamNQKKHhbOocL.NgcWpJIBgJyvJEPNRloRpkQSpiZk;
		if (ngcWpJIBgJyvJEPNRloRpkQSpiZk != ControllerType.Mouse)
		{
			if (ngcWpJIBgJyvJEPNRloRpkQSpiZk == ControllerType.Joystick)
			{
				this.ntwdUtSjJLvprWDrvdraMIOoSTvV(dgjVhstXQWqvCxiamNQKKHhbOocL, this.rJTXqhKmQofPKSWJGJwxytrnVozW.joystickAxisSensitivity);
				return;
			}
			if (ngcWpJIBgJyvJEPNRloRpkQSpiZk != ControllerType.Custom)
			{
				throw new NotImplementedException();
			}
			this.ntwdUtSjJLvprWDrvdraMIOoSTvV(dgjVhstXQWqvCxiamNQKKHhbOocL, this.rJTXqhKmQofPKSWJGJwxytrnVozW.customControllerAxisSensitivity);
			return;
		}
		else
		{
			if ((mRCBQDgzARDPVbNsvhiBadcDxEwTB < 2 && this.rJTXqhKmQofPKSWJGJwxytrnVozW.mouseXYAxisMode == MouseXYAxisMode.DigitalAxis) || (mRCBQDgzARDPVbNsvhiBadcDxEwTB > 1 && this.rJTXqhKmQofPKSWJGJwxytrnVozW.mouseOtherAxisMode == MouseOtherAxisMode.DigitalAxis))
			{
				this.NJOKLdUyRBuIXQRfWauAuFgZiRjEA(dgjVhstXQWqvCxiamNQKKHhbOocL, 0f, true);
				return;
			}
			if (mRCBQDgzARDPVbNsvhiBadcDxEwTB < 2)
			{
				if (this.rJTXqhKmQofPKSWJGJwxytrnVozW.mouseXYAxisMode == MouseXYAxisMode.MouseAxis)
				{
					this.zJBSUQrnvxkynHsRXicmZPuwWTVU += dgjVhstXQWqvCxiamNQKKHhbOocL.utdxJIHkatoxBldAvWBbZTVbaFcl * this.rJTXqhKmQofPKSWJGJwxytrnVozW.mouseXYAxisSensitivity;
				}
				else if (this.rJTXqhKmQofPKSWJGJwxytrnVozW.mouseXYAxisMode == MouseXYAxisMode.ScreenPositionDelta || this.rJTXqhKmQofPKSWJGJwxytrnVozW.mouseXYAxisMode == MouseXYAxisMode.Speed)
				{
					float num;
					float num2;
					if (this.rJTXqhKmQofPKSWJGJwxytrnVozW.mouseXYAxisDeltaCalc == MouseXYAxisDeltaCalc.Normal)
					{
						num = (float)Screen.width;
						num2 = (float)Screen.height;
					}
					else if (this.rJTXqhKmQofPKSWJGJwxytrnVozW.mouseXYAxisDeltaCalc == MouseXYAxisDeltaCalc.ScreenWidth)
					{
						num = (float)Screen.width;
						num2 = num;
					}
					else
					{
						if (this.rJTXqhKmQofPKSWJGJwxytrnVozW.mouseXYAxisDeltaCalc != MouseXYAxisDeltaCalc.ScreenHeight)
						{
							throw new NotImplementedException();
						}
						num2 = (float)Screen.height;
						num = num2;
					}
					iWmRLdlDqgwSNYjkwtUZeqvQOyqs.WjdzkcSlJmaHWCXWmLVbvguSGYbF.szvmGeFdvMPfoVcraWGIUmfzjurk szvmGeFdvMPfoVcraWGIUmfzjurk = iWmRLdlDqgwSNYjkwtUZeqvQOyqs.zyKCinSdJxEAyzJGNjJDHOCtVKNU.OGYHILzArPasSbCLUkIZyVXBGDxZ;
					if (mRCBQDgzARDPVbNsvhiBadcDxEwTB == 0)
					{
						float x = szvmGeFdvMPfoVcraWGIUmfzjurk.ZdigNOZSasgLjJyDZsnYiLfXsJFbb.x;
						if (x != 0f)
						{
							float num3 = x / num;
							if (this.rJTXqhKmQofPKSWJGJwxytrnVozW.mouseXYAxisMode == MouseXYAxisMode.Speed)
							{
								num3 /= iWmRLdlDqgwSNYjkwtUZeqvQOyqs.MeSfMuugNEENLeckTfhpdKMrgqPnA;
							}
							this.zJBSUQrnvxkynHsRXicmZPuwWTVU += num3;
						}
					}
					else
					{
						float y = szvmGeFdvMPfoVcraWGIUmfzjurk.ZdigNOZSasgLjJyDZsnYiLfXsJFbb.y;
						if (y != 0f)
						{
							float num4 = y / num2;
							if (this.rJTXqhKmQofPKSWJGJwxytrnVozW.mouseXYAxisMode == MouseXYAxisMode.Speed)
							{
								num4 /= iWmRLdlDqgwSNYjkwtUZeqvQOyqs.MeSfMuugNEENLeckTfhpdKMrgqPnA;
							}
							this.zJBSUQrnvxkynHsRXicmZPuwWTVU += num4;
						}
					}
				}
			}
			else if (this.rJTXqhKmQofPKSWJGJwxytrnVozW.mouseOtherAxisMode == MouseOtherAxisMode.MouseAxis)
			{
				this.zJBSUQrnvxkynHsRXicmZPuwWTVU += dgjVhstXQWqvCxiamNQKKHhbOocL.utdxJIHkatoxBldAvWBbZTVbaFcl * this.rJTXqhKmQofPKSWJGJwxytrnVozW.mouseOtherAxisSensitivity;
			}
			this.NJOKLdUyRBuIXQRfWauAuFgZiRjEA(dgjVhstXQWqvCxiamNQKKHhbOocL, this.rJTXqhKmQofPKSWJGJwxytrnVozW.buttonDeadZone, false);
			return;
		}
	}

	// Token: 0x06000814 RID: 2068 RVA: 0x0003E94C File Offset: 0x0003CB4C
	private void ntwdUtSjJLvprWDrvdraMIOoSTvV(JataafgUmrvbnTlMuiLhrcBTEPfd A_1, float A_2)
	{
		float num = A_1.utdxJIHkatoxBldAvWBbZTVbaFcl * A_2;
		if (A_1.ZAGAxVhJMnqlgFyZHfBZxpIAGWyn)
		{
			if (A_1.nrfSpYJvAcmHkgaNAZuHtaMYillV == AxisCoordinateMode.Absolute)
			{
				if (this.HsJszjooZfoMkIANvCWYEfVLFyWs == AxisCoordinateMode.Absolute)
				{
					this.VaFSDsvOVqCMTcFMtSuUyfmlaqkc += num;
				}
			}
			else if (A_1.nrfSpYJvAcmHkgaNAZuHtaMYillV == AxisCoordinateMode.Relative)
			{
				if (this.HsJszjooZfoMkIANvCWYEfVLFyWs != AxisCoordinateMode.Relative)
				{
					this.VaFSDsvOVqCMTcFMtSuUyfmlaqkc = num;
					this.HsJszjooZfoMkIANvCWYEfVLFyWs = AxisCoordinateMode.Relative;
				}
				else
				{
					this.VaFSDsvOVqCMTcFMtSuUyfmlaqkc = MathTools.MaxMagnitude(this.VaFSDsvOVqCMTcFMtSuUyfmlaqkc, num);
				}
			}
		}
		else if (A_1.nrfSpYJvAcmHkgaNAZuHtaMYillV == AxisCoordinateMode.Absolute)
		{
			if (this.ZdbpEqJEdnFGyDmdHanWfJldRaqq == AxisCoordinateMode.Absolute && MathTools.Abs(num) > MathTools.Abs(this.rMBhqGnNfagmBbcJOBteWopkYQRV))
			{
				this.rMBhqGnNfagmBbcJOBteWopkYQRV = num;
			}
		}
		else if (A_1.nrfSpYJvAcmHkgaNAZuHtaMYillV == AxisCoordinateMode.Relative)
		{
			if (this.ZdbpEqJEdnFGyDmdHanWfJldRaqq != AxisCoordinateMode.Relative)
			{
				this.rMBhqGnNfagmBbcJOBteWopkYQRV = num;
				this.ZdbpEqJEdnFGyDmdHanWfJldRaqq = AxisCoordinateMode.Relative;
			}
			else if (MathTools.Abs(num) > MathTools.Abs(this.rMBhqGnNfagmBbcJOBteWopkYQRV))
			{
				this.rMBhqGnNfagmBbcJOBteWopkYQRV = num;
			}
		}
		this.NJOKLdUyRBuIXQRfWauAuFgZiRjEA(A_1, this.rJTXqhKmQofPKSWJGJwxytrnVozW.buttonDeadZone, false);
	}

	// Token: 0x06000815 RID: 2069 RVA: 0x0003EA44 File Offset: 0x0003CC44
	private void NJOKLdUyRBuIXQRfWauAuFgZiRjEA(JataafgUmrvbnTlMuiLhrcBTEPfd A_1, float A_2, bool A_3)
	{
		IOidQPQHzktCEcGgopnxdsRDcvvq oidQPQHzktCEcGgopnxdsRDcvvq = IOidQPQHzktCEcGgopnxdsRDcvvq.XibdfdZtlUwXUUgolpKbbUHaRmsf(A_1.jMEqHZPiCdPoKLgzvxltMnUhaoSH.pGMbotKVdjNowDvSSfgThIWDmLSHB, IOidQPQHzktCEcGgopnxdsRDcvvq.yzyMVcieauXZKOhYryvnItUhAnYh.pwUuMkkuJtgNOrmJwavvKzAoawxB);
		if (A_1.jMEqHZPiCdPoKLgzvxltMnUhaoSH._axisRange == AxisRange.Full)
		{
			if (MathTools.Abs(A_1.utdxJIHkatoxBldAvWBbZTVbaFcl) > A_2)
			{
				oidQPQHzktCEcGgopnxdsRDcvvq.WoPiVfbaaVgHNuIoQsEpNatNmfKA(iWmRLdlDqgwSNYjkwtUZeqvQOyqs.OwjVJuTiPkEWVFyHYdmSJpRETjSI, A_1.utdxJIHkatoxBldAvWBbZTVbaFcl > 0f);
			}
			ButtonStateFlags buttonStateFlags = oidQPQHzktCEcGgopnxdsRDcvvq.haEHqwIqltOagmdIACNqFKZYJluu(true);
			ButtonStateFlags buttonStateFlags2 = oidQPQHzktCEcGgopnxdsRDcvvq.haEHqwIqltOagmdIACNqFKZYJluu(false);
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs.BojyZKptYegswXilIAapBZtXlQyW(ref this.IiTKwDafEniDsGuzAWEvOkMMdpp, buttonStateFlags);
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs.BojyZKptYegswXilIAapBZtXlQyW(ref this.zrKaXNmwcmBTKTFrTvMxJGyZfgdM, buttonStateFlags2);
			if (A_3 && ((buttonStateFlags & ButtonStateFlags.On) != ButtonStateFlags.Off || (buttonStateFlags2 & ButtonStateFlags.On) != ButtonStateFlags.Off))
			{
				if (A_1.utdxJIHkatoxBldAvWBbZTVbaFcl != 0f)
				{
					this.CaLDBRHvlNFXvZwABfurdANAvhznB += (float)((int)(1f * MathTools.Sign(A_1.utdxJIHkatoxBldAvWBbZTVbaFcl)));
					this.pzJUUTODAnhhmdbzOIFrkzCFKICY.felxCEZdogJfegKqSkmYNKvgydUX(A_1);
				}
				this.kQzxJVdVXAdMvxaIIVxDOuvECeOJ = true;
				return;
			}
		}
		else
		{
			ButtonStateFlags buttonStateFlags3;
			if (A_1.jMEqHZPiCdPoKLgzvxltMnUhaoSH._axisContribution == Pole.Positive)
			{
				if (A_1.utdxJIHkatoxBldAvWBbZTVbaFcl > A_2)
				{
					oidQPQHzktCEcGgopnxdsRDcvvq.WoPiVfbaaVgHNuIoQsEpNatNmfKA(iWmRLdlDqgwSNYjkwtUZeqvQOyqs.OwjVJuTiPkEWVFyHYdmSJpRETjSI, true);
				}
				buttonStateFlags3 = oidQPQHzktCEcGgopnxdsRDcvvq.haEHqwIqltOagmdIACNqFKZYJluu(true);
				iWmRLdlDqgwSNYjkwtUZeqvQOyqs.BojyZKptYegswXilIAapBZtXlQyW(ref this.IiTKwDafEniDsGuzAWEvOkMMdpp, buttonStateFlags3);
			}
			else
			{
				if (MathTools.Abs(A_1.utdxJIHkatoxBldAvWBbZTVbaFcl) > A_2)
				{
					oidQPQHzktCEcGgopnxdsRDcvvq.WoPiVfbaaVgHNuIoQsEpNatNmfKA(iWmRLdlDqgwSNYjkwtUZeqvQOyqs.OwjVJuTiPkEWVFyHYdmSJpRETjSI, false);
				}
				buttonStateFlags3 = oidQPQHzktCEcGgopnxdsRDcvvq.haEHqwIqltOagmdIACNqFKZYJluu(false);
				iWmRLdlDqgwSNYjkwtUZeqvQOyqs.BojyZKptYegswXilIAapBZtXlQyW(ref this.zrKaXNmwcmBTKTFrTvMxJGyZfgdM, buttonStateFlags3);
			}
			if (A_3)
			{
				if (A_1.utdxJIHkatoxBldAvWBbZTVbaFcl != 0f)
				{
					this.CaLDBRHvlNFXvZwABfurdANAvhznB += (float)((int)(1f * MathTools.Sign(A_1.utdxJIHkatoxBldAvWBbZTVbaFcl)));
					this.pzJUUTODAnhhmdbzOIFrkzCFKICY.felxCEZdogJfegKqSkmYNKvgydUX(A_1);
				}
				if ((buttonStateFlags3 & ButtonStateFlags.On) != ButtonStateFlags.Off)
				{
					this.kQzxJVdVXAdMvxaIIVxDOuvECeOJ = true;
				}
			}
		}
	}

	// Token: 0x06000816 RID: 2070 RVA: 0x0003EBC8 File Offset: 0x0003CDC8
	internal void SryHCWZDGvcEkuqNcAcuwKQwIixe()
	{
		if (this.UTpDuunHtLEtGAaYEkIDRPdLPZDWA != iWmRLdlDqgwSNYjkwtUZeqvQOyqs.frbfpZwcOFYoVvZHeVhfeGZBtOQP)
		{
			this.eNQDLiAAFzrIXjhGNpAdWzGGgVgN(false);
			return;
		}
		if (this.KtabwngytZNqqQLTKorCaAvKHyzX == iWmRLdlDqgwSNYjkwtUZeqvQOyqs.RMpfvDpfwUakDjETyOTCXnXoYFGU.Idle)
		{
			return;
		}
		iWmRLdlDqgwSNYjkwtUZeqvQOyqs.vFRlHIZERiUepZIjRBsqmFqNEpvS.TtcoGRNwDfROcpFklhBuAtpfpesc iRrquiPiIMlLaxufvrKRVDrGeMneA = this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA;
		iRrquiPiIMlLaxufvrKRVDrGeMneA.KajzFKihNEjWuehiOXCCIxwYfdMwA = this.IiTKwDafEniDsGuzAWEvOkMMdpp;
		iRrquiPiIMlLaxufvrKRVDrGeMneA.qbhaOciqzCkNCIlwEwJKotfknFjBc = this.zrKaXNmwcmBTKTFrTvMxJGyZfgdM;
		if (this.zJBSUQrnvxkynHsRXicmZPuwWTVU != 0f)
		{
			iRrquiPiIMlLaxufvrKRVDrGeMneA.oasLTjvytYRRxCRrSpvqrPYskPEO = this.zJBSUQrnvxkynHsRXicmZPuwWTVU;
			iRrquiPiIMlLaxufvrKRVDrGeMneA.GfYitGKmPeEuZKGFmfzayTwXLoyWA = AxisCoordinateMode.Relative;
		}
		else if (this.rMBhqGnNfagmBbcJOBteWopkYQRV != 0f)
		{
			iRrquiPiIMlLaxufvrKRVDrGeMneA.oasLTjvytYRRxCRrSpvqrPYskPEO = this.rMBhqGnNfagmBbcJOBteWopkYQRV;
			iRrquiPiIMlLaxufvrKRVDrGeMneA.GfYitGKmPeEuZKGFmfzayTwXLoyWA = this.ZdbpEqJEdnFGyDmdHanWfJldRaqq;
		}
		else
		{
			float oasLTjvytYRRxCRrSpvqrPYskPEO = MathTools.Clamp(this.VaFSDsvOVqCMTcFMtSuUyfmlaqkc, -1f, 1f);
			iRrquiPiIMlLaxufvrKRVDrGeMneA.oasLTjvytYRRxCRrSpvqrPYskPEO = oasLTjvytYRRxCRrSpvqrPYskPEO;
			iRrquiPiIMlLaxufvrKRVDrGeMneA.GfYitGKmPeEuZKGFmfzayTwXLoyWA = this.HsJszjooZfoMkIANvCWYEfVLFyWs;
		}
		if (this.zqZovAamJSGDZJJxzcSXpvbJCtbZ)
		{
			iRrquiPiIMlLaxufvrKRVDrGeMneA.OVSBjVjnQvcgjKCJMlNGevEOAptj();
			this.zqZovAamJSGDZJJxzcSXpvbJCtbZ = false;
		}
		this.avPTLQbsoMRXSUmopCWrLJhOMkwh();
		iRrquiPiIMlLaxufvrKRVDrGeMneA.tLrdZzMmbMECFYdxLtNwVMqrGdJfA(iWmRLdlDqgwSNYjkwtUZeqvQOyqs.yAmVOKAzQbbmGgwQiXjbiiDizlpf);
		if (iRrquiPiIMlLaxufvrKRVDrGeMneA.FpjEdiSudHSPKLXGpTmqphnhZEku != null)
		{
			if (this.NfdapjazOYUspUPMBhuFaSOuWxZy())
			{
				iRrquiPiIMlLaxufvrKRVDrGeMneA.FpjEdiSudHSPKLXGpTmqphnhZEku.Start((double)this.rJTXqhKmQofPKSWJGJwxytrnVozW.buttonDownBuffer);
			}
			if (this.ztolEkmOiihSKfxJuZdYJygDdszAb())
			{
				iRrquiPiIMlLaxufvrKRVDrGeMneA.KtjcFUXwwpcTBjLUMfNcoBivcqnl.Start((double)this.rJTXqhKmQofPKSWJGJwxytrnVozW.buttonDownBuffer);
			}
		}
		iRrquiPiIMlLaxufvrKRVDrGeMneA.susueQDRPJeIJTWmihfITSgENdnX(this.cgnNvIBXdjcArepYxqVhcluOaiAF(), this.PLEzowLfRVYnmqUhFdELfVgtLRUU(), this.DEqKIDythebfGxHycCDdFiTYHWfF(), this.HWGpqzxmCQzoZIFrUhOuHScOhfbr());
		if (this.wKfHTGVDPIGADpQtOqmVPTTkalKs)
		{
			this.NmKugGBVLSpGmoUPfIJtYCGwzsGP();
		}
		if (this.yYLEHWciMjTZaQrepBiHsDioTnLMA != iWmRLdlDqgwSNYjkwtUZeqvQOyqs.frbfpZwcOFYoVvZHeVhfeGZBtOQP && this.EfzniShYpznHExIiEDnVhtklrBaJA.rMpgHImLfcivqQnRcfDJGxLefBOsA())
		{
			this.eNQDLiAAFzrIXjhGNpAdWzGGgVgN(true);
			return;
		}
	}

	// Token: 0x06000817 RID: 2071 RVA: 0x0003ED44 File Offset: 0x0003CF44
	internal void avPTLQbsoMRXSUmopCWrLJhOMkwh()
	{
		if (this.pzJUUTODAnhhmdbzOIFrkzCFKICY.OtmtFBDRpRaatsUBcawnGPBqpNgCA)
		{
			this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.KRiZMIqrZLcXVqVtFtKxlCODxQHc.kONYxvBQJlDLuguDQkgwtjZGSsaA(this.pzJUUTODAnhhmdbzOIFrkzCFKICY);
		}
		this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.tqrZORUfVoRNQtHUbKEdCOkcDqes = MathTools.Clamp(this.CaLDBRHvlNFXvZwABfurdANAvhznB, -1f, 1f);
		if (!this.rJTXqhKmQofPKSWJGJwxytrnVozW.digitalAxisSimulation)
		{
			this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.ryopNaHJTYcuRbBnPpNTlmNjQMYw = this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.tqrZORUfVoRNQtHUbKEdCOkcDqes;
			if (this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.KRiZMIqrZLcXVqVtFtKxlCODxQHc.OtmtFBDRpRaatsUBcawnGPBqpNgCA)
			{
				this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.KRiZMIqrZLcXVqVtFtKxlCODxQHc.neLNINJxygNHYyqXiEcdEuevUEui();
			}
			return;
		}
		if (!this.kQzxJVdVXAdMvxaIIVxDOuvECeOJ)
		{
			if (this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.ryopNaHJTYcuRbBnPpNTlmNjQMYw != 0f && this.rJTXqhKmQofPKSWJGJwxytrnVozW.digitalAxisGravity != 0f)
			{
				float num = this.rJTXqhKmQofPKSWJGJwxytrnVozW.digitalAxisGravity * iWmRLdlDqgwSNYjkwtUZeqvQOyqs.MeSfMuugNEENLeckTfhpdKMrgqPnA;
				if (MathTools.Abs(num) >= MathTools.Abs(this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.ryopNaHJTYcuRbBnPpNTlmNjQMYw))
				{
					this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.ryopNaHJTYcuRbBnPpNTlmNjQMYw = 0f;
					this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.KRiZMIqrZLcXVqVtFtKxlCODxQHc.neLNINJxygNHYyqXiEcdEuevUEui();
					return;
				}
				float num2 = (this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.ryopNaHJTYcuRbBnPpNTlmNjQMYw > 0f) ? -1f : 1f;
				this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.ryopNaHJTYcuRbBnPpNTlmNjQMYw = MathTools.Clamp(this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.ryopNaHJTYcuRbBnPpNTlmNjQMYw + num2 * num, -1f, 1f);
				ccTpHyuBLmqwaKhsPmaxvVJtLJHK kriZMIqrZLcXVqVtFtKxlCODxQHc = this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.KRiZMIqrZLcXVqVtFtKxlCODxQHc;
				this.XBAYTLBUhMFSGaMtKyAyyGqTcTum(kriZMIqrZLcXVqVtFtKxlCODxQHc.vUPtknPZXgiYgZbiabYfevsXxZQW, kriZMIqrZLcXVqVtFtKxlCODxQHc.RgVKpTFJJjWTjYwTmmaoSgwzKrYr, kriZMIqrZLcXVqVtFtKxlCODxQHc.iVNgfDiGatAWZcJBXeFAgVaADoNeb);
			}
			return;
		}
		float num3 = MathTools.Clamp(this.CaLDBRHvlNFXvZwABfurdANAvhznB, -1f, 1f);
		float num4 = (num3 != 0f) ? MathTools.Sign(num3) : 0f;
		float num5 = (this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.ryopNaHJTYcuRbBnPpNTlmNjQMYw != 0f) ? MathTools.Sign(this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.ryopNaHJTYcuRbBnPpNTlmNjQMYw) : 0f;
		float digitalAxisSensitivity = this.rJTXqhKmQofPKSWJGJwxytrnVozW.digitalAxisSensitivity;
		if (digitalAxisSensitivity > 0f)
		{
			num3 *= digitalAxisSensitivity * iWmRLdlDqgwSNYjkwtUZeqvQOyqs.MeSfMuugNEENLeckTfhpdKMrgqPnA;
		}
		if (this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.ryopNaHJTYcuRbBnPpNTlmNjQMYw != 0f)
		{
			if (num3 != 0f && num4 != num5)
			{
				if (this.rJTXqhKmQofPKSWJGJwxytrnVozW.digitalAxisInstantReverse)
				{
					num3 += -1f * this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.ryopNaHJTYcuRbBnPpNTlmNjQMYw;
				}
				else if (!this.rJTXqhKmQofPKSWJGJwxytrnVozW.digitalAxisSnap)
				{
					num3 += this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.ryopNaHJTYcuRbBnPpNTlmNjQMYw;
				}
			}
			else
			{
				num3 += this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.ryopNaHJTYcuRbBnPpNTlmNjQMYw;
			}
		}
		else
		{
			num3 += this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.ryopNaHJTYcuRbBnPpNTlmNjQMYw;
		}
		this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.ryopNaHJTYcuRbBnPpNTlmNjQMYw = MathTools.Clamp(num3, -1f, 1f);
	}

	// Token: 0x06000818 RID: 2072 RVA: 0x0003F050 File Offset: 0x0003D250
	public float ZPnnWnuioRHnHyXZXKWHKDyfDapAA()
	{
		if (!this.FTSguAcJYczMlZkHpDdfJFjfzvIr)
		{
			return 0f;
		}
		if (this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.GfYitGKmPeEuZKGFmfzayTwXLoyWA == AxisCoordinateMode.Relative)
		{
			return this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.oasLTjvytYRRxCRrSpvqrPYskPEO;
		}
		return MathTools.MaxMagnitude(this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.oasLTjvytYRRxCRrSpvqrPYskPEO, this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.ryopNaHJTYcuRbBnPpNTlmNjQMYw);
	}

	// Token: 0x06000819 RID: 2073 RVA: 0x0003F0B4 File Offset: 0x0003D2B4
	public float zeIvxBEyQDnSJZoRCukhvNlOQqPk()
	{
		if (!this.FTSguAcJYczMlZkHpDdfJFjfzvIr)
		{
			return 0f;
		}
		if (this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.LwLTiurhpQHchoddCwYjtwBvkfpd == AxisCoordinateMode.Relative)
		{
			return this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.sGGCzsEeoDSBtSrlxSKeHPBCsmKP;
		}
		return MathTools.MaxMagnitude(this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.sGGCzsEeoDSBtSrlxSKeHPBCsmKP, this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.iZHcfyoRntXaXezNLwLqfRMJEaTy);
	}

	// Token: 0x0600081A RID: 2074 RVA: 0x00008D5D File Offset: 0x00006F5D
	public float JcoMCwHbLcQrTzrfjEczXQEWhkKH()
	{
		if (!this.FTSguAcJYczMlZkHpDdfJFjfzvIr)
		{
			return 0f;
		}
		return this.ZPnnWnuioRHnHyXZXKWHKDyfDapAA() - this.zeIvxBEyQDnSJZoRCukhvNlOQqPk();
	}

	// Token: 0x0600081B RID: 2075 RVA: 0x00008D7A File Offset: 0x00006F7A
	public double MmHkSwRdUQtZMocqRgPXgzuSUrfe()
	{
		if (!this.FTSguAcJYczMlZkHpDdfJFjfzvIr)
		{
			return 0.0;
		}
		return this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.eXUEfyzBNhMGVqhAeAHRqBPWTERl;
	}

	// Token: 0x0600081C RID: 2076 RVA: 0x00008D9E File Offset: 0x00006F9E
	public double MyHSUivBytCndhknlCiBpZMblHfp()
	{
		if (!this.FTSguAcJYczMlZkHpDdfJFjfzvIr)
		{
			this.ZWuRJsJQhrwcKvHhUSaEVrlJXkcH();
		}
		return this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.TmwlXKjnVtmHKHQZXldiiZTKkasQ;
	}

	// Token: 0x0600081D RID: 2077 RVA: 0x0003F118 File Offset: 0x0003D318
	public AxisCoordinateMode WojBcNFKvgOvFnKvrgACEMevkdrI()
	{
		if (!this.FTSguAcJYczMlZkHpDdfJFjfzvIr)
		{
			return AxisCoordinateMode.Absolute;
		}
		if (MathTools.Abs(this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.oasLTjvytYRRxCRrSpvqrPYskPEO) >= MathTools.Abs(this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.ryopNaHJTYcuRbBnPpNTlmNjQMYw))
		{
			return this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.GfYitGKmPeEuZKGFmfzayTwXLoyWA;
		}
		return AxisCoordinateMode.Absolute;
	}

	// Token: 0x0600081E RID: 2078 RVA: 0x0003F170 File Offset: 0x0003D370
	public AxisCoordinateMode YXXRsKQIANjvEVswVdHbSLmqlDgX()
	{
		if (!this.FTSguAcJYczMlZkHpDdfJFjfzvIr)
		{
			return AxisCoordinateMode.Absolute;
		}
		if (MathTools.Abs(this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.sGGCzsEeoDSBtSrlxSKeHPBCsmKP) >= MathTools.Abs(this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.iZHcfyoRntXaXezNLwLqfRMJEaTy))
		{
			return this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.LwLTiurhpQHchoddCwYjtwBvkfpd;
		}
		return AxisCoordinateMode.Absolute;
	}

	// Token: 0x0600081F RID: 2079 RVA: 0x0003F1C8 File Offset: 0x0003D3C8
	public float KBRilOANCOjinFxICUYpQZAcnxarB()
	{
		if (!this.FTSguAcJYczMlZkHpDdfJFjfzvIr)
		{
			return 0f;
		}
		if (this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.GfYitGKmPeEuZKGFmfzayTwXLoyWA == AxisCoordinateMode.Relative)
		{
			return this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.oasLTjvytYRRxCRrSpvqrPYskPEO;
		}
		return MathTools.MaxMagnitude(this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.oasLTjvytYRRxCRrSpvqrPYskPEO, this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.tqrZORUfVoRNQtHUbKEdCOkcDqes);
	}

	// Token: 0x06000820 RID: 2080 RVA: 0x0003F22C File Offset: 0x0003D42C
	public float HkvMKqVfYwmAfauEGBultMpQzGWC()
	{
		if (!this.FTSguAcJYczMlZkHpDdfJFjfzvIr)
		{
			return 0f;
		}
		if (this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.LwLTiurhpQHchoddCwYjtwBvkfpd == AxisCoordinateMode.Relative)
		{
			return this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.sGGCzsEeoDSBtSrlxSKeHPBCsmKP;
		}
		return MathTools.MaxMagnitude(this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.sGGCzsEeoDSBtSrlxSKeHPBCsmKP, this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.fqfmqVuuCZMoAwfDtObWdbQyUtkc);
	}

	// Token: 0x06000821 RID: 2081 RVA: 0x00008DBE File Offset: 0x00006FBE
	public float UGtpNRqVtWAMlxZxOBPFuiVrahSbA()
	{
		if (!this.FTSguAcJYczMlZkHpDdfJFjfzvIr)
		{
			return 0f;
		}
		return this.KBRilOANCOjinFxICUYpQZAcnxarB() - this.HkvMKqVfYwmAfauEGBultMpQzGWC();
	}

	// Token: 0x06000822 RID: 2082 RVA: 0x00008DDB File Offset: 0x00006FDB
	public double XcsRNAtPMzwEhwLaMacWaPEAmzFAA()
	{
		if (!this.FTSguAcJYczMlZkHpDdfJFjfzvIr)
		{
			return 0.0;
		}
		return this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.jhADzFQPOvncBryxgbRXRfIrHgrA;
	}

	// Token: 0x06000823 RID: 2083 RVA: 0x00008DFF File Offset: 0x00006FFF
	public double yQYyLKQKnMfHmzMHuKICdnFYcLsf()
	{
		if (!this.FTSguAcJYczMlZkHpDdfJFjfzvIr)
		{
			this.ZWuRJsJQhrwcKvHhUSaEVrlJXkcH();
		}
		return this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.vgiTZDESwdOpkqlXsvkQhacfTPXV;
	}

	// Token: 0x06000824 RID: 2084 RVA: 0x0003F290 File Offset: 0x0003D490
	public AxisCoordinateMode igzeVXulKZrqUXFKfZkQvwwFHLSX()
	{
		if (!this.FTSguAcJYczMlZkHpDdfJFjfzvIr)
		{
			return AxisCoordinateMode.Absolute;
		}
		if (MathTools.Abs(this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.oasLTjvytYRRxCRrSpvqrPYskPEO) >= MathTools.Abs(this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.tqrZORUfVoRNQtHUbKEdCOkcDqes))
		{
			return this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.GfYitGKmPeEuZKGFmfzayTwXLoyWA;
		}
		return AxisCoordinateMode.Absolute;
	}

	// Token: 0x06000825 RID: 2085 RVA: 0x0003F2E8 File Offset: 0x0003D4E8
	public AxisCoordinateMode gJqeezRfNRnzoFsyAoiEtwoAjOmu()
	{
		if (!this.FTSguAcJYczMlZkHpDdfJFjfzvIr)
		{
			return AxisCoordinateMode.Absolute;
		}
		if (MathTools.Abs(this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.sGGCzsEeoDSBtSrlxSKeHPBCsmKP) >= MathTools.Abs(this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.fqfmqVuuCZMoAwfDtObWdbQyUtkc))
		{
			return this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.LwLTiurhpQHchoddCwYjtwBvkfpd;
		}
		return AxisCoordinateMode.Absolute;
	}

	// Token: 0x06000826 RID: 2086 RVA: 0x0003F340 File Offset: 0x0003D540
	public bool PLEzowLfRVYnmqUhFdELfVgtLRUU()
	{
		if (!this.FTSguAcJYczMlZkHpDdfJFjfzvIr)
		{
			return false;
		}
		if (!iWmRLdlDqgwSNYjkwtUZeqvQOyqs.dFaxFlOasBUZzgcgcjkCEwllVeoZ.activateActionButtonsOnNegativeValue)
		{
			return (this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.KajzFKihNEjWuehiOXCCIxwYfdMwA & ButtonStateFlags.On) > ButtonStateFlags.Off;
		}
		return (this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.KajzFKihNEjWuehiOXCCIxwYfdMwA & ButtonStateFlags.On) != ButtonStateFlags.Off || this.HWGpqzxmCQzoZIFrUhOuHScOhfbr();
	}

	// Token: 0x06000827 RID: 2087 RVA: 0x0003F398 File Offset: 0x0003D598
	public bool cgnNvIBXdjcArepYxqVhcluOaiAF()
	{
		if (!this.FTSguAcJYczMlZkHpDdfJFjfzvIr)
		{
			return false;
		}
		if (this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.FpjEdiSudHSPKLXGpTmqphnhZEku == null)
		{
			return this.NfdapjazOYUspUPMBhuFaSOuWxZy();
		}
		return this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.FpjEdiSudHSPKLXGpTmqphnhZEku.running || (iWmRLdlDqgwSNYjkwtUZeqvQOyqs.dFaxFlOasBUZzgcgcjkCEwllVeoZ.activateActionButtonsOnNegativeValue && this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.KtjcFUXwwpcTBjLUMfNcoBivcqnl.running);
	}

	// Token: 0x06000828 RID: 2088 RVA: 0x0003F408 File Offset: 0x0003D608
	public bool iqpRhWPPruMPiSurJSIiJhNgoOiO()
	{
		if (!this.FTSguAcJYczMlZkHpDdfJFjfzvIr)
		{
			return false;
		}
		if (!iWmRLdlDqgwSNYjkwtUZeqvQOyqs.dFaxFlOasBUZzgcgcjkCEwllVeoZ.activateActionButtonsOnNegativeValue)
		{
			return (this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.KajzFKihNEjWuehiOXCCIxwYfdMwA & ButtonStateFlags.Up) > ButtonStateFlags.Off;
		}
		return ((this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.KajzFKihNEjWuehiOXCCIxwYfdMwA & ButtonStateFlags.Up) != ButtonStateFlags.Off || (this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.qbhaOciqzCkNCIlwEwJKotfknFjBc & ButtonStateFlags.Up) != ButtonStateFlags.Off) && (this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.KajzFKihNEjWuehiOXCCIxwYfdMwA & ButtonStateFlags.On) == ButtonStateFlags.Off && (this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.qbhaOciqzCkNCIlwEwJKotfknFjBc & ButtonStateFlags.On) == ButtonStateFlags.Off;
	}

	// Token: 0x06000829 RID: 2089 RVA: 0x0003F498 File Offset: 0x0003D698
	public bool TtiHmMweSqotoAUWwlbDjsYVgpkcA()
	{
		if (!this.FTSguAcJYczMlZkHpDdfJFjfzvIr)
		{
			return false;
		}
		if (!iWmRLdlDqgwSNYjkwtUZeqvQOyqs.dFaxFlOasBUZzgcgcjkCEwllVeoZ.activateActionButtonsOnNegativeValue)
		{
			return this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.DvrckxzHAgNiAEXcdZPkHiPGYQdH.ZVBzlvCGQhhDCNOtxWndWlFExcim;
		}
		return this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.DvrckxzHAgNiAEXcdZPkHiPGYQdH.ZVBzlvCGQhhDCNOtxWndWlFExcim || this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.SfuePgCDzipirfiydWvBWgMdQIOEb.ZVBzlvCGQhhDCNOtxWndWlFExcim;
	}

	// Token: 0x0600082A RID: 2090 RVA: 0x0003F500 File Offset: 0x0003D700
	public bool LWbCfZDYbtngeYfwehddWnTHkZmL()
	{
		if (!this.FTSguAcJYczMlZkHpDdfJFjfzvIr)
		{
			return false;
		}
		if (!iWmRLdlDqgwSNYjkwtUZeqvQOyqs.dFaxFlOasBUZzgcgcjkCEwllVeoZ.activateActionButtonsOnNegativeValue)
		{
			return this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.DvrckxzHAgNiAEXcdZPkHiPGYQdH.nYhsmVQpZggepwhKVfkOHskzOqHzA;
		}
		bool flag = this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.DvrckxzHAgNiAEXcdZPkHiPGYQdH.nYhsmVQpZggepwhKVfkOHskzOqHzA;
		bool flag2 = this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.SfuePgCDzipirfiydWvBWgMdQIOEb.nYhsmVQpZggepwhKVfkOHskzOqHzA;
		return (flag || flag2) && (flag || !this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.DvrckxzHAgNiAEXcdZPkHiPGYQdH.ZVBzlvCGQhhDCNOtxWndWlFExcim) && (flag2 || !this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.SfuePgCDzipirfiydWvBWgMdQIOEb.ZVBzlvCGQhhDCNOtxWndWlFExcim);
	}

	// Token: 0x0600082B RID: 2091 RVA: 0x0003F5A8 File Offset: 0x0003D7A8
	public bool HfbBeghVKYofUBdMipStTLDWnePt()
	{
		if (!this.FTSguAcJYczMlZkHpDdfJFjfzvIr)
		{
			return false;
		}
		if (!iWmRLdlDqgwSNYjkwtUZeqvQOyqs.dFaxFlOasBUZzgcgcjkCEwllVeoZ.activateActionButtonsOnNegativeValue)
		{
			return this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.DvrckxzHAgNiAEXcdZPkHiPGYQdH.pydeHOTYsMNiAjHeoemkCRgxhyuU;
		}
		bool flag = this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.DvrckxzHAgNiAEXcdZPkHiPGYQdH.pydeHOTYsMNiAjHeoemkCRgxhyuU;
		bool flag2 = this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.SfuePgCDzipirfiydWvBWgMdQIOEb.pydeHOTYsMNiAjHeoemkCRgxhyuU;
		return (flag || flag2) && !this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.DvrckxzHAgNiAEXcdZPkHiPGYQdH.ZVBzlvCGQhhDCNOtxWndWlFExcim && !this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.SfuePgCDzipirfiydWvBWgMdQIOEb.ZVBzlvCGQhhDCNOtxWndWlFExcim;
	}

	// Token: 0x0600082C RID: 2092 RVA: 0x00008E1F File Offset: 0x0000701F
	public bool sEBvXkfbZucozKekmkmIhQQkTXwV()
	{
		return this.oZfcBbUtGNPizYqlKFKnHBYvkUFRA(0f);
	}

	// Token: 0x0600082D RID: 2093 RVA: 0x0003F648 File Offset: 0x0003D848
	public bool oZfcBbUtGNPizYqlKFKnHBYvkUFRA(float A_1)
	{
		if (!this.FTSguAcJYczMlZkHpDdfJFjfzvIr)
		{
			return false;
		}
		if (A_1 > 0f)
		{
			if (!iWmRLdlDqgwSNYjkwtUZeqvQOyqs.dFaxFlOasBUZzgcgcjkCEwllVeoZ.activateActionButtonsOnNegativeValue)
			{
				return this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.OUdUbxVCluiCMZwlIwaRveownPxj.dBSMuoTXNVdemVfLJdZrxvXJHQFH(A_1);
			}
			return this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.OUdUbxVCluiCMZwlIwaRveownPxj.dBSMuoTXNVdemVfLJdZrxvXJHQFH(A_1) || this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.IWPJaMtdUHbReRrCNEiBCXPsABvgb.dBSMuoTXNVdemVfLJdZrxvXJHQFH(A_1);
		}
		else
		{
			if (!iWmRLdlDqgwSNYjkwtUZeqvQOyqs.dFaxFlOasBUZzgcgcjkCEwllVeoZ.activateActionButtonsOnNegativeValue)
			{
				return this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.DvrckxzHAgNiAEXcdZPkHiPGYQdH.jMLGHMhjzxFqooNqMJwlpyFoeQcA;
			}
			return this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.DvrckxzHAgNiAEXcdZPkHiPGYQdH.jMLGHMhjzxFqooNqMJwlpyFoeQcA || this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.SfuePgCDzipirfiydWvBWgMdQIOEb.jMLGHMhjzxFqooNqMJwlpyFoeQcA;
		}
	}

	// Token: 0x0600082E RID: 2094 RVA: 0x00008E2C File Offset: 0x0000702C
	public bool RSbWzxTjULHvXrpzIasjWHbRcldG()
	{
		return this.tVtvoroswQXEnbdAENmIGAElmIBc(0f);
	}

	// Token: 0x0600082F RID: 2095 RVA: 0x0003F70C File Offset: 0x0003D90C
	public bool tVtvoroswQXEnbdAENmIGAElmIBc(float A_1)
	{
		if (!this.FTSguAcJYczMlZkHpDdfJFjfzvIr)
		{
			return false;
		}
		if (!this.cgnNvIBXdjcArepYxqVhcluOaiAF())
		{
			return false;
		}
		if (!iWmRLdlDqgwSNYjkwtUZeqvQOyqs.dFaxFlOasBUZzgcgcjkCEwllVeoZ.activateActionButtonsOnNegativeValue)
		{
			if (A_1 > 0f)
			{
				return this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.OUdUbxVCluiCMZwlIwaRveownPxj.dBSMuoTXNVdemVfLJdZrxvXJHQFH(A_1);
			}
			return this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.DvrckxzHAgNiAEXcdZPkHiPGYQdH.jMLGHMhjzxFqooNqMJwlpyFoeQcA;
		}
		else
		{
			if (A_1 > 0f)
			{
				return this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.OUdUbxVCluiCMZwlIwaRveownPxj.dBSMuoTXNVdemVfLJdZrxvXJHQFH(A_1) || this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.IWPJaMtdUHbReRrCNEiBCXPsABvgb.dBSMuoTXNVdemVfLJdZrxvXJHQFH(A_1);
			}
			return this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.DvrckxzHAgNiAEXcdZPkHiPGYQdH.jMLGHMhjzxFqooNqMJwlpyFoeQcA || this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.SfuePgCDzipirfiydWvBWgMdQIOEb.jMLGHMhjzxFqooNqMJwlpyFoeQcA;
		}
	}

	// Token: 0x06000830 RID: 2096 RVA: 0x00008E39 File Offset: 0x00007039
	public bool DfGBNrdfRKIGfnSMAUHPHhmyNkaRA()
	{
		return this.JZbmLwFjMyOqchpEzbxnChuSPPgo(0f);
	}

	// Token: 0x06000831 RID: 2097 RVA: 0x0003F7D8 File Offset: 0x0003D9D8
	public bool JZbmLwFjMyOqchpEzbxnChuSPPgo(float A_1)
	{
		if (!this.FTSguAcJYczMlZkHpDdfJFjfzvIr)
		{
			return false;
		}
		if (!this.iqpRhWPPruMPiSurJSIiJhNgoOiO())
		{
			return false;
		}
		if (!iWmRLdlDqgwSNYjkwtUZeqvQOyqs.dFaxFlOasBUZzgcgcjkCEwllVeoZ.activateActionButtonsOnNegativeValue)
		{
			if (A_1 > 0f)
			{
				return this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.OUdUbxVCluiCMZwlIwaRveownPxj.hrSFRNtMkvCiMquVRliUSgeFbIZd(A_1);
			}
			return this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.DvrckxzHAgNiAEXcdZPkHiPGYQdH.QYEZBeWYRHVkLyrvLIjFsgqOEQMc;
		}
		else
		{
			if (A_1 > 0f)
			{
				return this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.OUdUbxVCluiCMZwlIwaRveownPxj.hrSFRNtMkvCiMquVRliUSgeFbIZd(A_1) || this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.IWPJaMtdUHbReRrCNEiBCXPsABvgb.hrSFRNtMkvCiMquVRliUSgeFbIZd(A_1);
			}
			return this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.DvrckxzHAgNiAEXcdZPkHiPGYQdH.QYEZBeWYRHVkLyrvLIjFsgqOEQMc || this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.SfuePgCDzipirfiydWvBWgMdQIOEb.QYEZBeWYRHVkLyrvLIjFsgqOEQMc;
		}
	}

	// Token: 0x06000832 RID: 2098 RVA: 0x00008E46 File Offset: 0x00007046
	public bool lFfKVjBrZsizhLeVfpUllizsUYlB(float A_1)
	{
		return this.zpvDECrzpTCpSrBbeXUUgieFKOlg(A_1, 0f);
	}

	// Token: 0x06000833 RID: 2099 RVA: 0x0003F8A4 File Offset: 0x0003DAA4
	public bool zpvDECrzpTCpSrBbeXUUgieFKOlg(float A_1, float A_2)
	{
		if (!this.FTSguAcJYczMlZkHpDdfJFjfzvIr)
		{
			return false;
		}
		if (A_1 < 0f)
		{
			A_1 = 0f;
		}
		if (!this.PLEzowLfRVYnmqUhFdELfVgtLRUU())
		{
			return false;
		}
		double num = this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.SMyfKiHUsooSnNeKAJSXnPDRTEaLA;
		if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs.dFaxFlOasBUZzgcgcjkCEwllVeoZ.activateActionButtonsOnNegativeValue)
		{
			num = MathTools.Max(num, this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.XtsiUVDGrhkxEMBHyquCGnGFRyiU);
		}
		return num >= (double)A_1 && (A_2 <= 0f || num < (double)(A_1 + A_2));
	}

	// Token: 0x06000834 RID: 2100 RVA: 0x0003F924 File Offset: 0x0003DB24
	public bool aGvkASuRZjHXWXpVpTxDBOXESHpc(float A_1)
	{
		if (!this.FTSguAcJYczMlZkHpDdfJFjfzvIr)
		{
			return false;
		}
		if (A_1 <= 0f)
		{
			return this.NfdapjazOYUspUPMBhuFaSOuWxZy();
		}
		if (!this.PLEzowLfRVYnmqUhFdELfVgtLRUU())
		{
			return false;
		}
		if (!iWmRLdlDqgwSNYjkwtUZeqvQOyqs.dFaxFlOasBUZzgcgcjkCEwllVeoZ.activateActionButtonsOnNegativeValue)
		{
			ButtonStateRecorder oudUbxVCluiCMZwlIwaRveownPxj = this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.OUdUbxVCluiCMZwlIwaRveownPxj;
			return oudUbxVCluiCMZwlIwaRveownPxj.iYYBZEdZWjRNEowiokfAQtErJtQX >= (double)A_1 && ReInput.unscaledTimePrev - oudUbxVCluiCMZwlIwaRveownPxj.SjfqgewtjZwZHPaYDayNBevdxKykA < (double)A_1;
		}
		ButtonStateRecorder oudUbxVCluiCMZwlIwaRveownPxj2 = this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.OUdUbxVCluiCMZwlIwaRveownPxj;
		ButtonStateRecorder iwpjaMtdUHbReRrCNEiBCXPsABvgb = this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.IWPJaMtdUHbReRrCNEiBCXPsABvgb;
		return (oudUbxVCluiCMZwlIwaRveownPxj2.iYYBZEdZWjRNEowiokfAQtErJtQX >= (double)A_1 || iwpjaMtdUHbReRrCNEiBCXPsABvgb.iYYBZEdZWjRNEowiokfAQtErJtQX >= (double)A_1) && ReInput.unscaledTimePrev - oudUbxVCluiCMZwlIwaRveownPxj2.SjfqgewtjZwZHPaYDayNBevdxKykA < (double)A_1 && ReInput.unscaledTimePrev - iwpjaMtdUHbReRrCNEiBCXPsABvgb.SjfqgewtjZwZHPaYDayNBevdxKykA < (double)A_1;
	}

	// Token: 0x06000835 RID: 2101 RVA: 0x00008E54 File Offset: 0x00007054
	public bool iHLgJeKWAEmbydHMXVOnvzNplBzi(float A_1)
	{
		return this.DHssSjYakDuhVUAVpnowwTPiMpSE(A_1, 0f);
	}

	// Token: 0x06000836 RID: 2102 RVA: 0x0003F9EC File Offset: 0x0003DBEC
	public bool DHssSjYakDuhVUAVpnowwTPiMpSE(float A_1, float A_2)
	{
		if (!this.FTSguAcJYczMlZkHpDdfJFjfzvIr)
		{
			return false;
		}
		if (A_1 < 0f)
		{
			A_1 = 0f;
		}
		if (!this.iqpRhWPPruMPiSurJSIiJhNgoOiO())
		{
			return false;
		}
		if (!iWmRLdlDqgwSNYjkwtUZeqvQOyqs.dFaxFlOasBUZzgcgcjkCEwllVeoZ.activateActionButtonsOnNegativeValue)
		{
			double num = ReInput.unscaledTime - this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.OUdUbxVCluiCMZwlIwaRveownPxj.ifvFecldmcTjdzSGXFkVZbMLnGQS;
			return num >= (double)A_1 && (A_2 <= 0f || num < (double)(A_1 + A_2));
		}
		double num2 = ReInput.unscaledTime - MathTools.Max(this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.OUdUbxVCluiCMZwlIwaRveownPxj.ifvFecldmcTjdzSGXFkVZbMLnGQS, this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.IWPJaMtdUHbReRrCNEiBCXPsABvgb.ifvFecldmcTjdzSGXFkVZbMLnGQS);
		return num2 >= (double)A_1 && (A_2 <= 0f || num2 < (double)(A_1 + A_2));
	}

	// Token: 0x06000837 RID: 2103 RVA: 0x00008E62 File Offset: 0x00007062
	public bool DCYPHQBUQWTQyFmGGGYmeiAycAZR()
	{
		return this.zpvDECrzpTCpSrBbeXUUgieFKOlg(this.rJTXqhKmQofPKSWJGJwxytrnVozW.buttonShortPressTime, this.rJTXqhKmQofPKSWJGJwxytrnVozW.buttonShortPressExpiresIn);
	}

	// Token: 0x06000838 RID: 2104 RVA: 0x00008E80 File Offset: 0x00007080
	public bool HPuKJdCWHuCwPrBFJVtqnvtpQLnn()
	{
		return this.aGvkASuRZjHXWXpVpTxDBOXESHpc(this.rJTXqhKmQofPKSWJGJwxytrnVozW.buttonShortPressTime);
	}

	// Token: 0x06000839 RID: 2105 RVA: 0x00008E93 File Offset: 0x00007093
	public bool zyIWmXRVRLmtfjUGqPWKrVhOpplL()
	{
		return this.DHssSjYakDuhVUAVpnowwTPiMpSE(this.rJTXqhKmQofPKSWJGJwxytrnVozW.buttonShortPressTime, this.rJTXqhKmQofPKSWJGJwxytrnVozW.buttonShortPressExpiresIn);
	}

	// Token: 0x0600083A RID: 2106 RVA: 0x00008EB1 File Offset: 0x000070B1
	public bool QXrrgbvJsTRiAGESJowgdvzQClRh()
	{
		return this.zpvDECrzpTCpSrBbeXUUgieFKOlg(this.rJTXqhKmQofPKSWJGJwxytrnVozW.buttonLongPressTime, this.rJTXqhKmQofPKSWJGJwxytrnVozW.buttonLongPressExpiresIn);
	}

	// Token: 0x0600083B RID: 2107 RVA: 0x00008ECF File Offset: 0x000070CF
	public bool qTObevNNKnAiasvGCHaKAchXpabA()
	{
		return this.aGvkASuRZjHXWXpVpTxDBOXESHpc(this.rJTXqhKmQofPKSWJGJwxytrnVozW.buttonLongPressTime);
	}

	// Token: 0x0600083C RID: 2108 RVA: 0x00008EE2 File Offset: 0x000070E2
	public bool byeGARHXOEmjPxcQoTOUGzYnfkKu()
	{
		return this.DHssSjYakDuhVUAVpnowwTPiMpSE(this.rJTXqhKmQofPKSWJGJwxytrnVozW.buttonLongPressTime, this.rJTXqhKmQofPKSWJGJwxytrnVozW.buttonLongPressExpiresIn);
	}

	// Token: 0x0600083D RID: 2109 RVA: 0x0003FAB0 File Offset: 0x0003DCB0
	public bool bydTKFtJThpJiBleSRZzwDlRDOBL()
	{
		if (!this.FTSguAcJYczMlZkHpDdfJFjfzvIr)
		{
			return false;
		}
		if (!iWmRLdlDqgwSNYjkwtUZeqvQOyqs.dFaxFlOasBUZzgcgcjkCEwllVeoZ.activateActionButtonsOnNegativeValue)
		{
			return this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.lQORlLqHceBLlYnxCzyKsdzprFAS.VitgNbvBKdDXRiawbLGfFmydDFEmB;
		}
		return this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.lQORlLqHceBLlYnxCzyKsdzprFAS.VitgNbvBKdDXRiawbLGfFmydDFEmB || this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.CzUABhBolSgnjDZCiSwrbuZsNPcec.VitgNbvBKdDXRiawbLGfFmydDFEmB;
	}

	// Token: 0x0600083E RID: 2110 RVA: 0x0003FB18 File Offset: 0x0003DD18
	public bool oFwEbOzifvsGVUHSHODNgMNlGvzcA()
	{
		if (!this.FTSguAcJYczMlZkHpDdfJFjfzvIr)
		{
			return false;
		}
		if (!iWmRLdlDqgwSNYjkwtUZeqvQOyqs.dFaxFlOasBUZzgcgcjkCEwllVeoZ.activateActionButtonsOnNegativeValue)
		{
			return (this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.KOrCdgLQnDavzpHwTiQPalMvXzXS & ButtonStateFlags.On) > ButtonStateFlags.Off;
		}
		return (this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.KOrCdgLQnDavzpHwTiQPalMvXzXS & ButtonStateFlags.On) != ButtonStateFlags.Off || this.pJdNBJgzCniVonEUxixmJoDFVzqI();
	}

	// Token: 0x0600083F RID: 2111 RVA: 0x0003FB70 File Offset: 0x0003DD70
	public double gNempBrAyTbRDWwSleIwOdtmpVtw()
	{
		if (!this.FTSguAcJYczMlZkHpDdfJFjfzvIr)
		{
			return 0.0;
		}
		if (!iWmRLdlDqgwSNYjkwtUZeqvQOyqs.dFaxFlOasBUZzgcgcjkCEwllVeoZ.activateActionButtonsOnNegativeValue)
		{
			return this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.KCcNUcYdMiELMMugBAswJbZKvApnA;
		}
		return MathTools.Max(this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.KCcNUcYdMiELMMugBAswJbZKvApnA, this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.HDzGixUGlzZDYCpsVrxJPhgGbkGB);
	}

	// Token: 0x06000840 RID: 2112 RVA: 0x0003FBD4 File Offset: 0x0003DDD4
	public double VYQDnrrCLsVEwPSOvFIDtcDnhPkB()
	{
		if (!this.FTSguAcJYczMlZkHpDdfJFjfzvIr)
		{
			this.ZWuRJsJQhrwcKvHhUSaEVrlJXkcH();
		}
		if (!iWmRLdlDqgwSNYjkwtUZeqvQOyqs.dFaxFlOasBUZzgcgcjkCEwllVeoZ.activateActionButtonsOnNegativeValue)
		{
			return this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.WcbyQJMDXLmPoUSBZhfCVdXVvUKj;
		}
		return MathTools.Min(this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.WcbyQJMDXLmPoUSBZhfCVdXVvUKj, this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.tzpCYJCBUasUCyeYRdoBgQBaAjCOA);
	}

	// Token: 0x06000841 RID: 2113 RVA: 0x0003FC34 File Offset: 0x0003DE34
	private bool NfdapjazOYUspUPMBhuFaSOuWxZy()
	{
		if (!iWmRLdlDqgwSNYjkwtUZeqvQOyqs.dFaxFlOasBUZzgcgcjkCEwllVeoZ.activateActionButtonsOnNegativeValue)
		{
			return (this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.KajzFKihNEjWuehiOXCCIxwYfdMwA & ButtonStateFlags.Down) > ButtonStateFlags.Off;
		}
		return ((this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.KajzFKihNEjWuehiOXCCIxwYfdMwA & ButtonStateFlags.Down) != ButtonStateFlags.Off || (this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.qbhaOciqzCkNCIlwEwJKotfknFjBc & ButtonStateFlags.Down) != ButtonStateFlags.Off) && ((this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.KajzFKihNEjWuehiOXCCIxwYfdMwA & ButtonStateFlags.On) == ButtonStateFlags.Off || (this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.KajzFKihNEjWuehiOXCCIxwYfdMwA & ButtonStateFlags.Down) != ButtonStateFlags.Off) && ((this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.qbhaOciqzCkNCIlwEwJKotfknFjBc & ButtonStateFlags.On) == ButtonStateFlags.Off || (this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.qbhaOciqzCkNCIlwEwJKotfknFjBc & ButtonStateFlags.Down) != ButtonStateFlags.Off);
	}

	// Token: 0x06000842 RID: 2114 RVA: 0x00008F00 File Offset: 0x00007100
	public bool HWGpqzxmCQzoZIFrUhOuHScOhfbr()
	{
		return this.FTSguAcJYczMlZkHpDdfJFjfzvIr && (this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.qbhaOciqzCkNCIlwEwJKotfknFjBc & ButtonStateFlags.On) > ButtonStateFlags.Off;
	}

	// Token: 0x06000843 RID: 2115 RVA: 0x00008F21 File Offset: 0x00007121
	public bool DEqKIDythebfGxHycCDdFiTYHWfF()
	{
		if (!this.FTSguAcJYczMlZkHpDdfJFjfzvIr)
		{
			return false;
		}
		if (this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.KtjcFUXwwpcTBjLUMfNcoBivcqnl == null)
		{
			return this.ztolEkmOiihSKfxJuZdYJygDdszAb();
		}
		return this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.KtjcFUXwwpcTBjLUMfNcoBivcqnl.running;
	}

	// Token: 0x06000844 RID: 2116 RVA: 0x00008F60 File Offset: 0x00007160
	public bool YJetLbybKqkFHlIxOBMORKTNchaY()
	{
		return this.FTSguAcJYczMlZkHpDdfJFjfzvIr && (this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.qbhaOciqzCkNCIlwEwJKotfknFjBc & ButtonStateFlags.Up) > ButtonStateFlags.Off;
	}

	// Token: 0x06000845 RID: 2117 RVA: 0x00008F81 File Offset: 0x00007181
	public bool gKhqNfBJWPQCWmZgQkjzVxTeghGO()
	{
		return this.FTSguAcJYczMlZkHpDdfJFjfzvIr && this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.SfuePgCDzipirfiydWvBWgMdQIOEb.ZVBzlvCGQhhDCNOtxWndWlFExcim;
	}

	// Token: 0x06000846 RID: 2118 RVA: 0x00008FA2 File Offset: 0x000071A2
	public bool UobencRdPOsVfpqTAcwrMWBOlucv()
	{
		return this.FTSguAcJYczMlZkHpDdfJFjfzvIr && this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.SfuePgCDzipirfiydWvBWgMdQIOEb.nYhsmVQpZggepwhKVfkOHskzOqHzA;
	}

	// Token: 0x06000847 RID: 2119 RVA: 0x00008FC3 File Offset: 0x000071C3
	public bool AaTsVPLVcybQrrgogrjJLSkxuclV()
	{
		return this.FTSguAcJYczMlZkHpDdfJFjfzvIr && this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.SfuePgCDzipirfiydWvBWgMdQIOEb.pydeHOTYsMNiAjHeoemkCRgxhyuU;
	}

	// Token: 0x06000848 RID: 2120 RVA: 0x00008FE4 File Offset: 0x000071E4
	public bool ctPerYDLPkNtZNcEkHTGPyuPQoPVA()
	{
		return this.RTWkHLUpAmesTmkgELyVDjMemKUn(0f);
	}

	// Token: 0x06000849 RID: 2121 RVA: 0x00008FF1 File Offset: 0x000071F1
	public bool RTWkHLUpAmesTmkgELyVDjMemKUn(float A_1)
	{
		if (!this.FTSguAcJYczMlZkHpDdfJFjfzvIr)
		{
			return false;
		}
		if (A_1 > 0f)
		{
			return this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.IWPJaMtdUHbReRrCNEiBCXPsABvgb.dBSMuoTXNVdemVfLJdZrxvXJHQFH(A_1);
		}
		return this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.SfuePgCDzipirfiydWvBWgMdQIOEb.jMLGHMhjzxFqooNqMJwlpyFoeQcA;
	}

	// Token: 0x0600084A RID: 2122 RVA: 0x00009031 File Offset: 0x00007231
	public bool FPynyxlFTtjzbxhWpOkKlLwWLmVg()
	{
		return this.HiYmLLYxrhaYHiqeBOjtIGIuNpEQ(0f);
	}

	// Token: 0x0600084B RID: 2123 RVA: 0x0003FCE4 File Offset: 0x0003DEE4
	public bool HiYmLLYxrhaYHiqeBOjtIGIuNpEQ(float A_1)
	{
		if (!this.FTSguAcJYczMlZkHpDdfJFjfzvIr)
		{
			return false;
		}
		if (!this.DEqKIDythebfGxHycCDdFiTYHWfF())
		{
			return false;
		}
		if (A_1 > 0f)
		{
			return this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.IWPJaMtdUHbReRrCNEiBCXPsABvgb.dBSMuoTXNVdemVfLJdZrxvXJHQFH(A_1);
		}
		return this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.SfuePgCDzipirfiydWvBWgMdQIOEb.jMLGHMhjzxFqooNqMJwlpyFoeQcA;
	}

	// Token: 0x0600084C RID: 2124 RVA: 0x0000903E File Offset: 0x0000723E
	public bool wKndARlDimVggsXZnFfctkMgSEIA()
	{
		return this.hZDmLiEfhVfHuJFrpmbvWeZDliNEb(0f);
	}

	// Token: 0x0600084D RID: 2125 RVA: 0x0003FD3C File Offset: 0x0003DF3C
	public bool hZDmLiEfhVfHuJFrpmbvWeZDliNEb(float A_1)
	{
		if (!this.FTSguAcJYczMlZkHpDdfJFjfzvIr)
		{
			return false;
		}
		if (!this.YJetLbybKqkFHlIxOBMORKTNchaY())
		{
			return false;
		}
		if (A_1 > 0f)
		{
			return this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.IWPJaMtdUHbReRrCNEiBCXPsABvgb.hrSFRNtMkvCiMquVRliUSgeFbIZd(A_1);
		}
		return this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.SfuePgCDzipirfiydWvBWgMdQIOEb.QYEZBeWYRHVkLyrvLIjFsgqOEQMc;
	}

	// Token: 0x0600084E RID: 2126 RVA: 0x0000904B File Offset: 0x0000724B
	public bool VzGMJFqguOpyUQzDNiQCRcwPxHKw(float A_1)
	{
		return this.HJcCPAAxaZKAkATvymNFuNUGeixn(A_1, 0f);
	}

	// Token: 0x0600084F RID: 2127 RVA: 0x0003FD94 File Offset: 0x0003DF94
	public bool HJcCPAAxaZKAkATvymNFuNUGeixn(float A_1, float A_2)
	{
		if (!this.FTSguAcJYczMlZkHpDdfJFjfzvIr)
		{
			return false;
		}
		if (A_1 < 0f)
		{
			A_1 = 0f;
		}
		if (!this.HWGpqzxmCQzoZIFrUhOuHScOhfbr())
		{
			return false;
		}
		double num = this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.XtsiUVDGrhkxEMBHyquCGnGFRyiU;
		return num >= (double)A_1 && (A_2 <= 0f || num < (double)(A_1 + A_2));
	}

	// Token: 0x06000850 RID: 2128 RVA: 0x0003FDF0 File Offset: 0x0003DFF0
	public bool kxPJKadwjgTEVvjOoxRmKCjcGMshA(float A_1)
	{
		if (!this.FTSguAcJYczMlZkHpDdfJFjfzvIr)
		{
			return false;
		}
		if (A_1 <= 0f)
		{
			return this.ztolEkmOiihSKfxJuZdYJygDdszAb();
		}
		if (!this.HWGpqzxmCQzoZIFrUhOuHScOhfbr())
		{
			return false;
		}
		ButtonStateRecorder iwpjaMtdUHbReRrCNEiBCXPsABvgb = this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.IWPJaMtdUHbReRrCNEiBCXPsABvgb;
		return iwpjaMtdUHbReRrCNEiBCXPsABvgb.iYYBZEdZWjRNEowiokfAQtErJtQX >= (double)A_1 && ReInput.unscaledTimePrev - iwpjaMtdUHbReRrCNEiBCXPsABvgb.SjfqgewtjZwZHPaYDayNBevdxKykA < (double)A_1;
	}

	// Token: 0x06000851 RID: 2129 RVA: 0x00009059 File Offset: 0x00007259
	public bool MjxRqNpSrGmmffIcQhOHwziukgyJ(float A_1)
	{
		return this.VNMQdEPgUWpZCUdysrrlMBNQfMpq(A_1, 0f);
	}

	// Token: 0x06000852 RID: 2130 RVA: 0x0003FE50 File Offset: 0x0003E050
	public bool VNMQdEPgUWpZCUdysrrlMBNQfMpq(float A_1, float A_2)
	{
		if (!this.FTSguAcJYczMlZkHpDdfJFjfzvIr)
		{
			return false;
		}
		if (A_1 < 0f)
		{
			A_1 = 0f;
		}
		if (!this.YJetLbybKqkFHlIxOBMORKTNchaY())
		{
			return false;
		}
		double num = ReInput.unscaledTime - this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.IWPJaMtdUHbReRrCNEiBCXPsABvgb.ifvFecldmcTjdzSGXFkVZbMLnGQS;
		return num >= (double)A_1 && (A_2 <= 0f || num < (double)(A_1 + A_2));
	}

	// Token: 0x06000853 RID: 2131 RVA: 0x00009067 File Offset: 0x00007267
	public bool yekfXbpfvbVIhCPSOETpyFIXXvZI()
	{
		return this.HJcCPAAxaZKAkATvymNFuNUGeixn(this.rJTXqhKmQofPKSWJGJwxytrnVozW.buttonShortPressTime, this.rJTXqhKmQofPKSWJGJwxytrnVozW.buttonShortPressExpiresIn);
	}

	// Token: 0x06000854 RID: 2132 RVA: 0x00009085 File Offset: 0x00007285
	public bool mlPISDGCNvaJJTDdHhtCJbYKKcQL()
	{
		return this.kxPJKadwjgTEVvjOoxRmKCjcGMshA(this.rJTXqhKmQofPKSWJGJwxytrnVozW.buttonShortPressTime);
	}

	// Token: 0x06000855 RID: 2133 RVA: 0x00009098 File Offset: 0x00007298
	public bool JGiKRKJdtaebnxDHKwGTQnLkWoQE()
	{
		return this.VNMQdEPgUWpZCUdysrrlMBNQfMpq(this.rJTXqhKmQofPKSWJGJwxytrnVozW.buttonShortPressTime, this.rJTXqhKmQofPKSWJGJwxytrnVozW.buttonShortPressExpiresIn);
	}

	// Token: 0x06000856 RID: 2134 RVA: 0x000090B6 File Offset: 0x000072B6
	public bool MOMLKtzwDEKbkXbSyroGZcZPmBrg()
	{
		return this.HJcCPAAxaZKAkATvymNFuNUGeixn(this.rJTXqhKmQofPKSWJGJwxytrnVozW.buttonLongPressTime, this.rJTXqhKmQofPKSWJGJwxytrnVozW.buttonLongPressExpiresIn);
	}

	// Token: 0x06000857 RID: 2135 RVA: 0x000090D4 File Offset: 0x000072D4
	public bool gNKMpTVSjVbOBkSwBfMifjCrZDNH()
	{
		return this.kxPJKadwjgTEVvjOoxRmKCjcGMshA(this.rJTXqhKmQofPKSWJGJwxytrnVozW.buttonLongPressTime);
	}

	// Token: 0x06000858 RID: 2136 RVA: 0x000090E7 File Offset: 0x000072E7
	public bool VhxSlbANjTXbiijCgfOaJwIAMgygA()
	{
		return this.VNMQdEPgUWpZCUdysrrlMBNQfMpq(this.rJTXqhKmQofPKSWJGJwxytrnVozW.buttonLongPressTime, this.rJTXqhKmQofPKSWJGJwxytrnVozW.buttonLongPressExpiresIn);
	}

	// Token: 0x06000859 RID: 2137 RVA: 0x00009105 File Offset: 0x00007305
	public bool aXIfnVraJSaGrMGfbgfHhEprqwOnA()
	{
		return this.FTSguAcJYczMlZkHpDdfJFjfzvIr && this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.CzUABhBolSgnjDZCiSwrbuZsNPcec.VitgNbvBKdDXRiawbLGfFmydDFEmB;
	}

	// Token: 0x0600085A RID: 2138 RVA: 0x00009126 File Offset: 0x00007326
	public bool pJdNBJgzCniVonEUxixmJoDFVzqI()
	{
		return this.FTSguAcJYczMlZkHpDdfJFjfzvIr && (this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.qBCyQtIYqovqpZllKdBfaaYGidap & ButtonStateFlags.On) > ButtonStateFlags.Off;
	}

	// Token: 0x0600085B RID: 2139 RVA: 0x00009147 File Offset: 0x00007347
	public double mqvWHEuwnomGVOyodRZPEbJsWeit()
	{
		if (!this.FTSguAcJYczMlZkHpDdfJFjfzvIr)
		{
			return 0.0;
		}
		return this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.HDzGixUGlzZDYCpsVrxJPhgGbkGB;
	}

	// Token: 0x0600085C RID: 2140 RVA: 0x0000916B File Offset: 0x0000736B
	public double IgyWDwXEKwkniYMdFqRmkbavJkPO()
	{
		if (!this.FTSguAcJYczMlZkHpDdfJFjfzvIr)
		{
			this.ZWuRJsJQhrwcKvHhUSaEVrlJXkcH();
		}
		return this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.tzpCYJCBUasUCyeYRdoBgQBaAjCOA;
	}

	// Token: 0x0600085D RID: 2141 RVA: 0x0000918B File Offset: 0x0000738B
	private bool ztolEkmOiihSKfxJuZdYJygDdszAb()
	{
		return (this.EfzniShYpznHExIiEDnVhtklrBaJA.iRrquiPiIMlLaxufvrKRVDrGeMneA.qbhaOciqzCkNCIlwEwJKotfknFjBc & ButtonStateFlags.Down) > ButtonStateFlags.Off;
	}

	// Token: 0x0600085E RID: 2142 RVA: 0x0003FEB8 File Offset: 0x0003E0B8
	public void WVWimPiCvWgAilrVKZAvnWXKewI()
	{
		for (int i = 0; i < this.EfzniShYpznHExIiEDnVhtklrBaJA.lQEwNZsAkHirOeGMlLHfpvZhVIzi.Length; i++)
		{
			this.EfzniShYpznHExIiEDnVhtklrBaJA.lQEwNZsAkHirOeGMlLHfpvZhVIzi[i].FpjEdiSudHSPKLXGpTmqphnhZEku.Clear();
			this.EfzniShYpznHExIiEDnVhtklrBaJA.lQEwNZsAkHirOeGMlLHfpvZhVIzi[i].KtjcFUXwwpcTBjLUMfNcoBivcqnl.Clear();
		}
	}

	// Token: 0x0600085F RID: 2143 RVA: 0x000091A2 File Offset: 0x000073A2
	internal InputActionEventData HyjLngXpGsCKcToxwewWyYkRweJx(UpdateLoopType A_1)
	{
		return new InputActionEventData(this, this.gXJUvoJEafjcKDtEeDnLNOIcxzbeA, this.nrhdAYZedZAtVEfTnqlPfrkEHCxob, A_1);
	}

	// Token: 0x06000860 RID: 2144 RVA: 0x000091B7 File Offset: 0x000073B7
	public IList<InputActionSourceData> hZiPskALAXsUtBLlSarWzvOmmtg()
	{
		if (!this.wKfHTGVDPIGADpQtOqmVPTTkalKs)
		{
			this.NmKugGBVLSpGmoUPfIJtYCGwzsGP();
		}
		return this.tCmvcGYbHxdleOTAiEQrJxvthmJY;
	}

	// Token: 0x06000861 RID: 2145 RVA: 0x0003FF0C File Offset: 0x0003E10C
	public bool adFzUOgTCBtNzHOwtlssTlcJhXZw(ControllerType A_1)
	{
		if (!this.wKfHTGVDPIGADpQtOqmVPTTkalKs)
		{
			this.hZiPskALAXsUtBLlSarWzvOmmtg();
		}
		for (int i = 0; i < this.LktQdLgzjAhaaEfiaANGESLYEyQw; i++)
		{
			if (this.jjPovPtetSHbMSjORRJKMHTpfOzY[i].vUPtknPZXgiYgZbiabYfevsXxZQW.type == A_1)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000862 RID: 2146 RVA: 0x0003FF54 File Offset: 0x0003E154
	public bool onRntVgtimRSBUIRmCSKFoWcDZalA(ControllerType A_1, int A_2)
	{
		if (!this.wKfHTGVDPIGADpQtOqmVPTTkalKs)
		{
			this.hZiPskALAXsUtBLlSarWzvOmmtg();
		}
		for (int i = 0; i < this.LktQdLgzjAhaaEfiaANGESLYEyQw; i++)
		{
			Controller vUPtknPZXgiYgZbiabYfevsXxZQW = this.jjPovPtetSHbMSjORRJKMHTpfOzY[i].vUPtknPZXgiYgZbiabYfevsXxZQW;
			if (vUPtknPZXgiYgZbiabYfevsXxZQW.type == A_1 && vUPtknPZXgiYgZbiabYfevsXxZQW.id == A_2)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000863 RID: 2147 RVA: 0x0003FFA4 File Offset: 0x0003E1A4
	public bool fGcZYgmiFVldvaTpBCLSjlgpYnWm(Controller A_1)
	{
		if (!this.wKfHTGVDPIGADpQtOqmVPTTkalKs)
		{
			this.hZiPskALAXsUtBLlSarWzvOmmtg();
		}
		for (int i = 0; i < this.LktQdLgzjAhaaEfiaANGESLYEyQw; i++)
		{
			if (this.jjPovPtetSHbMSjORRJKMHTpfOzY[i].vUPtknPZXgiYgZbiabYfevsXxZQW == A_1)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000864 RID: 2148 RVA: 0x000091CD File Offset: 0x000073CD
	internal void qXVKaJieeCiewnUNZyuvdbpulTeg()
	{
		this.EfzniShYpznHExIiEDnVhtklrBaJA.EEBPLcRgxkhpEvHIuGRhIPmUOOVm();
	}

	// Token: 0x06000865 RID: 2149 RVA: 0x000091DA File Offset: 0x000073DA
	private void WwYBZSAWstESwDWIhcKzArlTjEBH()
	{
		if (this.jQnfIrgfITcEUlPeWOuZMMcIYHqFA == iWmRLdlDqgwSNYjkwtUZeqvQOyqs.RMpfvDpfwUakDjETyOTCXnXoYFGU.Disabled)
		{
			this.zqZovAamJSGDZJJxzcSXpvbJCtbZ = true;
		}
		this.KtabwngytZNqqQLTKorCaAvKHyzX = iWmRLdlDqgwSNYjkwtUZeqvQOyqs.RMpfvDpfwUakDjETyOTCXnXoYFGU.Active;
		this.FTSguAcJYczMlZkHpDdfJFjfzvIr = true;
	}

	// Token: 0x06000866 RID: 2150 RVA: 0x000091FA File Offset: 0x000073FA
	private void eNQDLiAAFzrIXjhGNpAdWzGGgVgN(bool A_1)
	{
		this.EfzniShYpznHExIiEDnVhtklrBaJA.NfFcNDSEgmKQntoCKkFPPNTNSCRr();
		if (this.LktQdLgzjAhaaEfiaANGESLYEyQw > 0)
		{
			this.UdaVvjvaqLFoynuaxmefEBbIPjip();
		}
		this.KtabwngytZNqqQLTKorCaAvKHyzX = (A_1 ? iWmRLdlDqgwSNYjkwtUZeqvQOyqs.RMpfvDpfwUakDjETyOTCXnXoYFGU.Idle : iWmRLdlDqgwSNYjkwtUZeqvQOyqs.RMpfvDpfwUakDjETyOTCXnXoYFGU.Disabled);
		this.FTSguAcJYczMlZkHpDdfJFjfzvIr = false;
	}

	// Token: 0x06000867 RID: 2151 RVA: 0x0000922A File Offset: 0x0000742A
	private void ZWuRJsJQhrwcKvHhUSaEVrlJXkcH()
	{
		this.EfzniShYpznHExIiEDnVhtklrBaJA.CcBAOPWxGfqAZbtIVQKpKoVsWsxL = iWmRLdlDqgwSNYjkwtUZeqvQOyqs.OwjVJuTiPkEWVFyHYdmSJpRETjSI;
	}

	// Token: 0x06000868 RID: 2152 RVA: 0x0000923C File Offset: 0x0000743C
	private void UdaVvjvaqLFoynuaxmefEBbIPjip()
	{
		this.LktQdLgzjAhaaEfiaANGESLYEyQw = 0;
		if (this.wKfHTGVDPIGADpQtOqmVPTTkalKs)
		{
			this.ozEBRqhkACPNflMPraesEvZcPnRfB.Clear();
		}
	}

	// Token: 0x06000869 RID: 2153 RVA: 0x0003FFE4 File Offset: 0x0003E1E4
	private void XBAYTLBUhMFSGaMtKyAyyGqTcTum(Controller A_1, ControllerMap A_2, ActionElementMap A_3)
	{
		if (this.LktQdLgzjAhaaEfiaANGESLYEyQw + 1 > this.jjPovPtetSHbMSjORRJKMHTpfOzY.Length)
		{
			this.oseNTFZqJTaemIVXTFOJkZjWDpDQ();
		}
		ccTpHyuBLmqwaKhsPmaxvVJtLJHK ccTpHyuBLmqwaKhsPmaxvVJtLJHK = this.jjPovPtetSHbMSjORRJKMHTpfOzY[this.LktQdLgzjAhaaEfiaANGESLYEyQw];
		ccTpHyuBLmqwaKhsPmaxvVJtLJHK.OtmtFBDRpRaatsUBcawnGPBqpNgCA = true;
		ccTpHyuBLmqwaKhsPmaxvVJtLJHK.vUPtknPZXgiYgZbiabYfevsXxZQW = A_1;
		ccTpHyuBLmqwaKhsPmaxvVJtLJHK.RgVKpTFJJjWTjYwTmmaoSgwzKrYr = A_2;
		ccTpHyuBLmqwaKhsPmaxvVJtLJHK.iVNgfDiGatAWZcJBXeFAgVaADoNeb = A_3;
		this.LktQdLgzjAhaaEfiaANGESLYEyQw++;
	}

	// Token: 0x0600086A RID: 2154 RVA: 0x00040040 File Offset: 0x0003E240
	private void oseNTFZqJTaemIVXTFOJkZjWDpDQ()
	{
		ArrayTools.Expand<ccTpHyuBLmqwaKhsPmaxvVJtLJHK>(ref this.jjPovPtetSHbMSjORRJKMHTpfOzY, 4);
		int num = this.LktQdLgzjAhaaEfiaANGESLYEyQw + 4;
		for (int i = this.LktQdLgzjAhaaEfiaANGESLYEyQw; i < num; i++)
		{
			this.jjPovPtetSHbMSjORRJKMHTpfOzY[i] = new ccTpHyuBLmqwaKhsPmaxvVJtLJHK();
		}
	}

	// Token: 0x0600086B RID: 2155 RVA: 0x00040080 File Offset: 0x0003E280
	private void NmKugGBVLSpGmoUPfIJtYCGwzsGP()
	{
		if (!this.wKfHTGVDPIGADpQtOqmVPTTkalKs)
		{
			this.wKfHTGVDPIGADpQtOqmVPTTkalKs = true;
		}
		for (int i = 0; i < this.LktQdLgzjAhaaEfiaANGESLYEyQw; i++)
		{
			this.ozEBRqhkACPNflMPraesEvZcPnRfB.Add(new InputActionSourceData(this.jjPovPtetSHbMSjORRJKMHTpfOzY[i]));
		}
	}

	// Token: 0x0600086C RID: 2156 RVA: 0x00009258 File Offset: 0x00007458
	private static void BojyZKptYegswXilIAapBZtXlQyW(ref ButtonStateFlags A_0, ButtonStateFlags A_1)
	{
		if (A_0 == ButtonStateFlags.Off)
		{
			A_0 = A_1;
			return;
		}
		if ((A_1 & ButtonStateFlags.Down) == ButtonStateFlags.Off)
		{
			if ((A_1 & ButtonStateFlags.On) != ButtonStateFlags.Off)
			{
				A_0 = ButtonStateFlags.On;
			}
			return;
		}
		if ((A_0 & ButtonStateFlags.On) != ButtonStateFlags.Off && (A_0 & ButtonStateFlags.Down) == ButtonStateFlags.Off)
		{
			return;
		}
		A_0 = (ButtonStateFlags.On | ButtonStateFlags.Down);
	}

	// Token: 0x0400066A RID: 1642
	internal readonly string jonnDVebvEGpPeggsRvHIZVsBTjWA;

	// Token: 0x0400066B RID: 1643
	internal readonly int nrhdAYZedZAtVEfTnqlPfrkEHCxob;

	// Token: 0x0400066C RID: 1644
	internal readonly int gXJUvoJEafjcKDtEeDnLNOIcxzbeA;

	// Token: 0x0400066D RID: 1645
	private readonly int grQLaDCoGckJoEhFwHgbebszQXIA;

	// Token: 0x0400066E RID: 1646
	private InputBehavior rJTXqhKmQofPKSWJGJwxytrnVozW;

	// Token: 0x0400066F RID: 1647
	private iWmRLdlDqgwSNYjkwtUZeqvQOyqs.vFRlHIZERiUepZIjRBsqmFqNEpvS EfzniShYpznHExIiEDnVhtklrBaJA;

	// Token: 0x04000670 RID: 1648
	private static ConfigVars dFaxFlOasBUZzgcgcjkCEwllVeoZ;

	// Token: 0x04000671 RID: 1649
	private static iWmRLdlDqgwSNYjkwtUZeqvQOyqs.WjdzkcSlJmaHWCXWmLVbvguSGYbF zyKCinSdJxEAyzJGNjJDHOCtVKNU;

	// Token: 0x04000672 RID: 1650
	private static UpdateLoopType OwjVJuTiPkEWVFyHYdmSJpRETjSI;

	// Token: 0x04000673 RID: 1651
	private static double yAmVOKAzQbbmGgwQiXjbiiDizlpf;

	// Token: 0x04000674 RID: 1652
	private static float MeSfMuugNEENLeckTfhpdKMrgqPnA;

	// Token: 0x04000675 RID: 1653
	private static uint frbfpZwcOFYoVvZHeVhfeGZBtOQP;

	// Token: 0x04000676 RID: 1654
	private float VaFSDsvOVqCMTcFMtSuUyfmlaqkc;

	// Token: 0x04000677 RID: 1655
	private float rMBhqGnNfagmBbcJOBteWopkYQRV;

	// Token: 0x04000678 RID: 1656
	private float zJBSUQrnvxkynHsRXicmZPuwWTVU;

	// Token: 0x04000679 RID: 1657
	private float KqEGbYsGmEwuRqwPugliehFKmgs;

	// Token: 0x0400067A RID: 1658
	private ButtonStateFlags IiTKwDafEniDsGuzAWEvOkMMdpp;

	// Token: 0x0400067B RID: 1659
	private ButtonStateFlags zrKaXNmwcmBTKTFrTvMxJGyZfgdM;

	// Token: 0x0400067C RID: 1660
	private float CaLDBRHvlNFXvZwABfurdANAvhznB;

	// Token: 0x0400067D RID: 1661
	private bool kQzxJVdVXAdMvxaIIVxDOuvECeOJ;

	// Token: 0x0400067E RID: 1662
	private AxisCoordinateMode HsJszjooZfoMkIANvCWYEfVLFyWs;

	// Token: 0x0400067F RID: 1663
	private AxisCoordinateMode ZdbpEqJEdnFGyDmdHanWfJldRaqq;

	// Token: 0x04000680 RID: 1664
	private readonly ccTpHyuBLmqwaKhsPmaxvVJtLJHK pzJUUTODAnhhmdbzOIFrkzCFKICY = new ccTpHyuBLmqwaKhsPmaxvVJtLJHK();

	// Token: 0x04000681 RID: 1665
	private uint UTpDuunHtLEtGAaYEkIDRPdLPZDWA;

	// Token: 0x04000682 RID: 1666
	private uint yYLEHWciMjTZaQrepBiHsDioTnLMA;

	// Token: 0x04000683 RID: 1667
	private bool zqZovAamJSGDZJJxzcSXpvbJCtbZ;

	// Token: 0x04000684 RID: 1668
	private iWmRLdlDqgwSNYjkwtUZeqvQOyqs.RMpfvDpfwUakDjETyOTCXnXoYFGU jQnfIrgfITcEUlPeWOuZMMcIYHqFA;

	// Token: 0x04000685 RID: 1669
	private const int iOgebrFyDKfycyGnwLVejksOIDTv = 4;

	// Token: 0x04000686 RID: 1670
	private int LktQdLgzjAhaaEfiaANGESLYEyQw;

	// Token: 0x04000687 RID: 1671
	private ccTpHyuBLmqwaKhsPmaxvVJtLJHK[] jjPovPtetSHbMSjORRJKMHTpfOzY;

	// Token: 0x04000688 RID: 1672
	private List<InputActionSourceData> ozEBRqhkACPNflMPraesEvZcPnRfB;

	// Token: 0x04000689 RID: 1673
	private ReadOnlyCollection<InputActionSourceData> tCmvcGYbHxdleOTAiEQrJxvthmJY;

	// Token: 0x0400068A RID: 1674
	private bool wKfHTGVDPIGADpQtOqmVPTTkalKs;

	// Token: 0x0400068B RID: 1675
	internal bool FTSguAcJYczMlZkHpDdfJFjfzvIr;

	// Token: 0x0400068C RID: 1676
	internal iWmRLdlDqgwSNYjkwtUZeqvQOyqs.RMpfvDpfwUakDjETyOTCXnXoYFGU KtabwngytZNqqQLTKorCaAvKHyzX = iWmRLdlDqgwSNYjkwtUZeqvQOyqs.RMpfvDpfwUakDjETyOTCXnXoYFGU.Disabled;

	// Token: 0x0400068D RID: 1677
	internal static readonly JataafgUmrvbnTlMuiLhrcBTEPfd DgjVhstXQWqvCxiamNQKKHhbOocL = new JataafgUmrvbnTlMuiLhrcBTEPfd();

	// Token: 0x020000FD RID: 253
	internal enum RMpfvDpfwUakDjETyOTCXnXoYFGU
	{
		// Token: 0x0400068F RID: 1679
		Active,
		// Token: 0x04000690 RID: 1680
		Idle,
		// Token: 0x04000691 RID: 1681
		Disabled
	}

	// Token: 0x020000FE RID: 254
	private class vFRlHIZERiUepZIjRBsqmFqNEpvS
	{
		// Token: 0x1700029C RID: 668
		// (set) Token: 0x0600086D RID: 2157 RVA: 0x00009280 File Offset: 0x00007480
		internal UpdateLoopType CcBAOPWxGfqAZbtIVQKpKoVsWsxL
		{
			set
			{
				this.YvfDEBBdRcCaoWigszGvlbJJnKHGb = this.awkXMBDIJPCTtIQfuvdNuZZGcUvJ[(int)value];
				this.iRrquiPiIMlLaxufvrKRVDrGeMneA = this.lQEwNZsAkHirOeGMlLHfpvZhVIzi[this.YvfDEBBdRcCaoWigszGvlbJJnKHGb];
			}
		}

		// Token: 0x0600086E RID: 2158 RVA: 0x000400C8 File Offset: 0x0003E2C8
		internal vFRlHIZERiUepZIjRBsqmFqNEpvS(UpdateLoopSetting A_1, InputBehavior A_2)
		{
			this.awkXMBDIJPCTtIQfuvdNuZZGcUvJ = new int[3];
			ArrayTools.Fill<int>(this.awkXMBDIJPCTtIQfuvdNuZZGcUvJ, -1);
			int num = 0;
			using (TempListPool.TList<UpdateLoopType> tlist = TempListPool.GetTList<UpdateLoopType>(3))
			{
				List<UpdateLoopType> list = tlist.list;
				EnumConverter.ToUpdateLoopTypes(A_1, list);
				for (int i = 0; i < list.Count; i++)
				{
					this.awkXMBDIJPCTtIQfuvdNuZZGcUvJ[(int)list[i]] = num;
					num++;
				}
			}
			this.lQEwNZsAkHirOeGMlLHfpvZhVIzi = new iWmRLdlDqgwSNYjkwtUZeqvQOyqs.vFRlHIZERiUepZIjRBsqmFqNEpvS.TtcoGRNwDfROcpFklhBuAtpfpesc[num];
			for (int j = 0; j < num; j++)
			{
				this.lQEwNZsAkHirOeGMlLHfpvZhVIzi[j] = new iWmRLdlDqgwSNYjkwtUZeqvQOyqs.vFRlHIZERiUepZIjRBsqmFqNEpvS.TtcoGRNwDfROcpFklhBuAtpfpesc(A_2);
			}
			this.iRrquiPiIMlLaxufvrKRVDrGeMneA = this.lQEwNZsAkHirOeGMlLHfpvZhVIzi[0];
		}

		// Token: 0x0600086F RID: 2159 RVA: 0x00040184 File Offset: 0x0003E384
		internal bool rMpgHImLfcivqQnRcfDJGxLefBOsA()
		{
			for (int i = 0; i < 3; i++)
			{
				if (this.awkXMBDIJPCTtIQfuvdNuZZGcUvJ[i] >= 0 && !this.lQEwNZsAkHirOeGMlLHfpvZhVIzi[this.awkXMBDIJPCTtIQfuvdNuZZGcUvJ[i]].KuHKldRbkYqOxLzQdOdHGWhwbHLE())
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000870 RID: 2160 RVA: 0x000401C4 File Offset: 0x0003E3C4
		internal void EEBPLcRgxkhpEvHIuGRhIPmUOOVm()
		{
			for (int i = 0; i < this.lQEwNZsAkHirOeGMlLHfpvZhVIzi.Length; i++)
			{
				this.lQEwNZsAkHirOeGMlLHfpvZhVIzi[i].fzSCplCPnZbQEZQUgchXULgJlqqV();
			}
		}

		// Token: 0x06000871 RID: 2161 RVA: 0x000401F4 File Offset: 0x0003E3F4
		internal void NfFcNDSEgmKQntoCKkFPPNTNSCRr()
		{
			for (int i = 0; i < this.lQEwNZsAkHirOeGMlLHfpvZhVIzi.Length; i++)
			{
				this.lQEwNZsAkHirOeGMlLHfpvZhVIzi[i].VDjwiQcEaCwJeAFFpfsHncZrfubd();
			}
		}

		// Token: 0x04000692 RID: 1682
		public iWmRLdlDqgwSNYjkwtUZeqvQOyqs.vFRlHIZERiUepZIjRBsqmFqNEpvS.TtcoGRNwDfROcpFklhBuAtpfpesc[] lQEwNZsAkHirOeGMlLHfpvZhVIzi;

		// Token: 0x04000693 RID: 1683
		private readonly int[] awkXMBDIJPCTtIQfuvdNuZZGcUvJ;

		// Token: 0x04000694 RID: 1684
		private int YvfDEBBdRcCaoWigszGvlbJJnKHGb;

		// Token: 0x04000695 RID: 1685
		internal iWmRLdlDqgwSNYjkwtUZeqvQOyqs.vFRlHIZERiUepZIjRBsqmFqNEpvS.TtcoGRNwDfROcpFklhBuAtpfpesc iRrquiPiIMlLaxufvrKRVDrGeMneA;

		// Token: 0x020000FF RID: 255
		internal class TtcoGRNwDfROcpFklhBuAtpfpesc
		{
			// Token: 0x1700029D RID: 669
			// (get) Token: 0x06000872 RID: 2162 RVA: 0x000092A3 File Offset: 0x000074A3
			internal double SMyfKiHUsooSnNeKAJSXnPDRTEaLA
			{
				get
				{
					return this.OUdUbxVCluiCMZwlIwaRveownPxj.iYYBZEdZWjRNEowiokfAQtErJtQX;
				}
			}

			// Token: 0x1700029E RID: 670
			// (get) Token: 0x06000873 RID: 2163 RVA: 0x000092B0 File Offset: 0x000074B0
			internal double DXAcRzngoIxKGfpklcpnChGCZsil
			{
				get
				{
					return this.OUdUbxVCluiCMZwlIwaRveownPxj.UoGphxgHptsNNoLrRKlCQxHyDDvy;
				}
			}

			// Token: 0x1700029F RID: 671
			// (get) Token: 0x06000874 RID: 2164 RVA: 0x000092BD File Offset: 0x000074BD
			internal double XtsiUVDGrhkxEMBHyquCGnGFRyiU
			{
				get
				{
					return this.IWPJaMtdUHbReRrCNEiBCXPsABvgb.iYYBZEdZWjRNEowiokfAQtErJtQX;
				}
			}

			// Token: 0x170002A0 RID: 672
			// (get) Token: 0x06000875 RID: 2165 RVA: 0x000092CA File Offset: 0x000074CA
			internal double HtywBLFWAfccCfntwrKOlmTgnSyl
			{
				get
				{
					return this.IWPJaMtdUHbReRrCNEiBCXPsABvgb.UoGphxgHptsNNoLrRKlCQxHyDDvy;
				}
			}

			// Token: 0x170002A1 RID: 673
			// (get) Token: 0x06000876 RID: 2166 RVA: 0x000092D7 File Offset: 0x000074D7
			internal double KCcNUcYdMiELMMugBAswJbZKvApnA
			{
				get
				{
					if ((this.KajzFKihNEjWuehiOXCCIxwYfdMwA & ButtonStateFlags.On) == ButtonStateFlags.Off && (this.KajzFKihNEjWuehiOXCCIxwYfdMwA & ButtonStateFlags.Down) == ButtonStateFlags.Off)
					{
						return 0.0;
					}
					return iWmRLdlDqgwSNYjkwtUZeqvQOyqs.yAmVOKAzQbbmGgwQiXjbiiDizlpf - this.fqOoVZmxXJkIXjLSCrqpnzmopFOS;
				}
			}

			// Token: 0x170002A2 RID: 674
			// (get) Token: 0x06000877 RID: 2167 RVA: 0x00009303 File Offset: 0x00007503
			internal double WcbyQJMDXLmPoUSBZhfCVdXVvUKj
			{
				get
				{
					if ((this.KajzFKihNEjWuehiOXCCIxwYfdMwA & ButtonStateFlags.On) != ButtonStateFlags.Off || (this.KajzFKihNEjWuehiOXCCIxwYfdMwA & ButtonStateFlags.Down) != ButtonStateFlags.Off)
					{
						return 0.0;
					}
					return iWmRLdlDqgwSNYjkwtUZeqvQOyqs.yAmVOKAzQbbmGgwQiXjbiiDizlpf - this.fqOoVZmxXJkIXjLSCrqpnzmopFOS;
				}
			}

			// Token: 0x170002A3 RID: 675
			// (get) Token: 0x06000878 RID: 2168 RVA: 0x0000932F File Offset: 0x0000752F
			internal double HDzGixUGlzZDYCpsVrxJPhgGbkGB
			{
				get
				{
					if ((this.qbhaOciqzCkNCIlwEwJKotfknFjBc & ButtonStateFlags.On) == ButtonStateFlags.Off && (this.qbhaOciqzCkNCIlwEwJKotfknFjBc & ButtonStateFlags.Down) == ButtonStateFlags.Off)
					{
						return 0.0;
					}
					return iWmRLdlDqgwSNYjkwtUZeqvQOyqs.yAmVOKAzQbbmGgwQiXjbiiDizlpf - this.sINqeaEGWWfQZJxTtWkQbJFXdScb;
				}
			}

			// Token: 0x170002A4 RID: 676
			// (get) Token: 0x06000879 RID: 2169 RVA: 0x0000935B File Offset: 0x0000755B
			internal double tzpCYJCBUasUCyeYRdoBgQBaAjCOA
			{
				get
				{
					if ((this.qbhaOciqzCkNCIlwEwJKotfknFjBc & ButtonStateFlags.On) != ButtonStateFlags.Off || (this.qbhaOciqzCkNCIlwEwJKotfknFjBc & ButtonStateFlags.Down) != ButtonStateFlags.Off)
					{
						return 0.0;
					}
					return iWmRLdlDqgwSNYjkwtUZeqvQOyqs.yAmVOKAzQbbmGgwQiXjbiiDizlpf - this.sINqeaEGWWfQZJxTtWkQbJFXdScb;
				}
			}

			// Token: 0x170002A5 RID: 677
			// (get) Token: 0x0600087A RID: 2170 RVA: 0x00040224 File Offset: 0x0003E424
			internal double eXUEfyzBNhMGVqhAeAHRqBPWTERl
			{
				get
				{
					if (this.oasLTjvytYRRxCRrSpvqrPYskPEO == 0f && this.ryopNaHJTYcuRbBnPpNTlmNjQMYw == 0f)
					{
						return 0.0;
					}
					double num = iWmRLdlDqgwSNYjkwtUZeqvQOyqs.yAmVOKAzQbbmGgwQiXjbiiDizlpf - this.dPDqMsXfFXDGwDSbydHgVeBVMAGt;
					if (num < 0.0)
					{
						num = 0.0;
					}
					return num;
				}
			}

			// Token: 0x170002A6 RID: 678
			// (get) Token: 0x0600087B RID: 2171 RVA: 0x0004027C File Offset: 0x0003E47C
			internal double TmwlXKjnVtmHKHQZXldiiZTKkasQ
			{
				get
				{
					if (this.oasLTjvytYRRxCRrSpvqrPYskPEO != 0f || this.ryopNaHJTYcuRbBnPpNTlmNjQMYw != 0f)
					{
						return 0.0;
					}
					double num = iWmRLdlDqgwSNYjkwtUZeqvQOyqs.yAmVOKAzQbbmGgwQiXjbiiDizlpf - this.dPDqMsXfFXDGwDSbydHgVeBVMAGt;
					if (num < 0.0)
					{
						num = 0.0;
					}
					return num;
				}
			}

			// Token: 0x170002A7 RID: 679
			// (get) Token: 0x0600087C RID: 2172 RVA: 0x000402D4 File Offset: 0x0003E4D4
			internal double jhADzFQPOvncBryxgbRXRfIrHgrA
			{
				get
				{
					if (this.oasLTjvytYRRxCRrSpvqrPYskPEO == 0f && this.tqrZORUfVoRNQtHUbKEdCOkcDqes == 0f)
					{
						return 0.0;
					}
					double num = iWmRLdlDqgwSNYjkwtUZeqvQOyqs.yAmVOKAzQbbmGgwQiXjbiiDizlpf - this.WiNEJPbkwaKTIyaDurzMQGTRrrfaA;
					if (num < 0.0)
					{
						num = 0.0;
					}
					return num;
				}
			}

			// Token: 0x170002A8 RID: 680
			// (get) Token: 0x0600087D RID: 2173 RVA: 0x0004032C File Offset: 0x0003E52C
			internal double vgiTZDESwdOpkqlXsvkQhacfTPXV
			{
				get
				{
					if (this.oasLTjvytYRRxCRrSpvqrPYskPEO != 0f || this.tqrZORUfVoRNQtHUbKEdCOkcDqes != 0f)
					{
						return 0.0;
					}
					double num = iWmRLdlDqgwSNYjkwtUZeqvQOyqs.yAmVOKAzQbbmGgwQiXjbiiDizlpf - this.WiNEJPbkwaKTIyaDurzMQGTRrrfaA;
					if (num < 0.0)
					{
						num = 0.0;
					}
					return num;
				}
			}

			// Token: 0x0600087E RID: 2174 RVA: 0x00040384 File Offset: 0x0003E584
			internal TtcoGRNwDfROcpFklhBuAtpfpesc(InputBehavior A_1)
			{
				this.YlRNihEsuSGDdslApCwbLwhqWlWK = A_1;
				if (A_1.buttonDownBuffer > 0f)
				{
					this.FpjEdiSudHSPKLXGpTmqphnhZEku = new TimerAbs((double)A_1.buttonDownBuffer);
					this.KtjcFUXwwpcTBjLUMfNcoBivcqnl = new TimerAbs((double)A_1.buttonDownBuffer);
				}
				this.OUdUbxVCluiCMZwlIwaRveownPxj = new ButtonStateRecorder();
				this.IWPJaMtdUHbReRrCNEiBCXPsABvgb = new ButtonStateRecorder();
				this.DvrckxzHAgNiAEXcdZPkHiPGYQdH = new yrvAdJcWjyNKnTjDkNBaBpxKQcjhb(A_1.buttonDoublePressSpeed);
				this.SfuePgCDzipirfiydWvBWgMdQIOEb = new yrvAdJcWjyNKnTjDkNBaBpxKQcjhb(A_1.buttonDoublePressSpeed);
				this.lQORlLqHceBLlYnxCzyKsdzprFAS = new lQHBTrpgrIfWMYfecjbiXlKojcrB(A_1.buttonRepeatDelay, A_1.buttonRepeatRate);
				this.CzUABhBolSgnjDZCiSwrbuZsNPcec = new lQHBTrpgrIfWMYfecjbiXlKojcrB(A_1.buttonRepeatDelay, A_1.buttonRepeatRate);
				this.fzSCplCPnZbQEZQUgchXULgJlqqV();
			}

			// Token: 0x0600087F RID: 2175 RVA: 0x00040448 File Offset: 0x0003E648
			internal void tLrdZzMmbMECFYdxLtNwVMqrGdJfA(double A_1)
			{
				if (this.oasLTjvytYRRxCRrSpvqrPYskPEO != 0f || this.ryopNaHJTYcuRbBnPpNTlmNjQMYw != 0f)
				{
					if (this.sGGCzsEeoDSBtSrlxSKeHPBCsmKP == 0f && this.iZHcfyoRntXaXezNLwLqfRMJEaTy == 0f)
					{
						this.dPDqMsXfFXDGwDSbydHgVeBVMAGt = iWmRLdlDqgwSNYjkwtUZeqvQOyqs.yAmVOKAzQbbmGgwQiXjbiiDizlpf;
					}
				}
				else if (this.sGGCzsEeoDSBtSrlxSKeHPBCsmKP != 0f || this.iZHcfyoRntXaXezNLwLqfRMJEaTy != 0f)
				{
					this.dPDqMsXfFXDGwDSbydHgVeBVMAGt = iWmRLdlDqgwSNYjkwtUZeqvQOyqs.yAmVOKAzQbbmGgwQiXjbiiDizlpf;
				}
				if (this.oasLTjvytYRRxCRrSpvqrPYskPEO != 0f || this.tqrZORUfVoRNQtHUbKEdCOkcDqes != 0f)
				{
					if (this.sGGCzsEeoDSBtSrlxSKeHPBCsmKP == 0f && this.fqfmqVuuCZMoAwfDtObWdbQyUtkc == 0f)
					{
						this.WiNEJPbkwaKTIyaDurzMQGTRrrfaA = iWmRLdlDqgwSNYjkwtUZeqvQOyqs.yAmVOKAzQbbmGgwQiXjbiiDizlpf;
					}
				}
				else if (this.sGGCzsEeoDSBtSrlxSKeHPBCsmKP != 0f || this.fqfmqVuuCZMoAwfDtObWdbQyUtkc != 0f)
				{
					this.WiNEJPbkwaKTIyaDurzMQGTRrrfaA = iWmRLdlDqgwSNYjkwtUZeqvQOyqs.yAmVOKAzQbbmGgwQiXjbiiDizlpf;
				}
				if (((this.KajzFKihNEjWuehiOXCCIxwYfdMwA & ButtonStateFlags.On) != ButtonStateFlags.Off || (this.KajzFKihNEjWuehiOXCCIxwYfdMwA & ButtonStateFlags.Down) > ButtonStateFlags.Off) != ((this.KOrCdgLQnDavzpHwTiQPalMvXzXS & ButtonStateFlags.On) != ButtonStateFlags.Off || (this.KOrCdgLQnDavzpHwTiQPalMvXzXS & ButtonStateFlags.Down) > ButtonStateFlags.Off))
				{
					this.fqOoVZmxXJkIXjLSCrqpnzmopFOS = iWmRLdlDqgwSNYjkwtUZeqvQOyqs.yAmVOKAzQbbmGgwQiXjbiiDizlpf;
				}
				if (((this.qbhaOciqzCkNCIlwEwJKotfknFjBc & ButtonStateFlags.On) != ButtonStateFlags.Off || (this.qbhaOciqzCkNCIlwEwJKotfknFjBc & ButtonStateFlags.Down) > ButtonStateFlags.Off) != ((this.qBCyQtIYqovqpZllKdBfaaYGidap & ButtonStateFlags.On) != ButtonStateFlags.Off || (this.qBCyQtIYqovqpZllKdBfaaYGidap & ButtonStateFlags.Down) > ButtonStateFlags.Off))
				{
					this.sINqeaEGWWfQZJxTtWkQbJFXdScb = iWmRLdlDqgwSNYjkwtUZeqvQOyqs.yAmVOKAzQbbmGgwQiXjbiiDizlpf;
				}
			}

			// Token: 0x06000880 RID: 2176 RVA: 0x0004059C File Offset: 0x0003E79C
			internal void LKTgToGaVCqnzcaNQaDKWSKRCPoAb()
			{
				if (this.sGGCzsEeoDSBtSrlxSKeHPBCsmKP != this.oasLTjvytYRRxCRrSpvqrPYskPEO)
				{
					this.sGGCzsEeoDSBtSrlxSKeHPBCsmKP = this.oasLTjvytYRRxCRrSpvqrPYskPEO;
				}
				if (this.KOrCdgLQnDavzpHwTiQPalMvXzXS != this.KajzFKihNEjWuehiOXCCIxwYfdMwA)
				{
					this.KOrCdgLQnDavzpHwTiQPalMvXzXS = this.KajzFKihNEjWuehiOXCCIxwYfdMwA;
				}
				if (this.qBCyQtIYqovqpZllKdBfaaYGidap != this.qbhaOciqzCkNCIlwEwJKotfknFjBc)
				{
					this.qBCyQtIYqovqpZllKdBfaaYGidap = this.qbhaOciqzCkNCIlwEwJKotfknFjBc;
				}
				if (this.iZHcfyoRntXaXezNLwLqfRMJEaTy != this.ryopNaHJTYcuRbBnPpNTlmNjQMYw)
				{
					this.iZHcfyoRntXaXezNLwLqfRMJEaTy = this.ryopNaHJTYcuRbBnPpNTlmNjQMYw;
				}
				if (this.fqfmqVuuCZMoAwfDtObWdbQyUtkc != this.tqrZORUfVoRNQtHUbKEdCOkcDqes)
				{
					this.fqfmqVuuCZMoAwfDtObWdbQyUtkc = this.tqrZORUfVoRNQtHUbKEdCOkcDqes;
				}
				if (this.LwLTiurhpQHchoddCwYjtwBvkfpd != this.GfYitGKmPeEuZKGFmfzayTwXLoyWA)
				{
					this.LwLTiurhpQHchoddCwYjtwBvkfpd = this.GfYitGKmPeEuZKGFmfzayTwXLoyWA;
				}
				if (this.GfYitGKmPeEuZKGFmfzayTwXLoyWA != AxisCoordinateMode.Absolute)
				{
					this.GfYitGKmPeEuZKGFmfzayTwXLoyWA = AxisCoordinateMode.Absolute;
				}
			}

			// Token: 0x06000881 RID: 2177 RVA: 0x00009387 File Offset: 0x00007587
			internal void flMaPUdHHQPjtaepKEnFWokhHXvWB()
			{
				if (this.FpjEdiSudHSPKLXGpTmqphnhZEku != null)
				{
					this.FpjEdiSudHSPKLXGpTmqphnhZEku.Update();
					this.KtjcFUXwwpcTBjLUMfNcoBivcqnl.Update();
				}
			}

			// Token: 0x06000882 RID: 2178 RVA: 0x00040654 File Offset: 0x0003E854
			internal void susueQDRPJeIJTWmihfITSgENdnX(bool A_1, bool A_2, bool A_3, bool A_4)
			{
				this.OUdUbxVCluiCMZwlIwaRveownPxj.YrWsQqYSgawNqBjZniXtogJhGqhs(A_1, A_2, iWmRLdlDqgwSNYjkwtUZeqvQOyqs.yAmVOKAzQbbmGgwQiXjbiiDizlpf);
				this.IWPJaMtdUHbReRrCNEiBCXPsABvgb.YrWsQqYSgawNqBjZniXtogJhGqhs(A_3, A_4, iWmRLdlDqgwSNYjkwtUZeqvQOyqs.yAmVOKAzQbbmGgwQiXjbiiDizlpf);
				float buttonDoublePressSpeed = this.YlRNihEsuSGDdslApCwbLwhqWlWK.buttonDoublePressSpeed;
				this.DvrckxzHAgNiAEXcdZPkHiPGYQdH.wslkHESJEInRjPPtzJOTPtKLxADI(buttonDoublePressSpeed, A_1, A_2);
				this.SfuePgCDzipirfiydWvBWgMdQIOEb.wslkHESJEInRjPPtzJOTPtKLxADI(buttonDoublePressSpeed, A_3, A_4);
				float buttonRepeatDelay = this.YlRNihEsuSGDdslApCwbLwhqWlWK.buttonRepeatDelay;
				float buttonRepeatRate = this.YlRNihEsuSGDdslApCwbLwhqWlWK.buttonRepeatRate;
				this.lQORlLqHceBLlYnxCzyKsdzprFAS.ganwulQNNwZAXbVrvLYRySvqCukj(A_1, A_2, buttonRepeatDelay, buttonRepeatRate, iWmRLdlDqgwSNYjkwtUZeqvQOyqs.yAmVOKAzQbbmGgwQiXjbiiDizlpf);
				this.CzUABhBolSgnjDZCiSwrbuZsNPcec.ganwulQNNwZAXbVrvLYRySvqCukj(A_3, A_4, buttonRepeatDelay, buttonRepeatRate, iWmRLdlDqgwSNYjkwtUZeqvQOyqs.yAmVOKAzQbbmGgwQiXjbiiDizlpf);
			}

			// Token: 0x06000883 RID: 2179 RVA: 0x000406F0 File Offset: 0x0003E8F0
			internal bool KuHKldRbkYqOxLzQdOdHGWhwbHLE()
			{
				return iWmRLdlDqgwSNYjkwtUZeqvQOyqs.yAmVOKAzQbbmGgwQiXjbiiDizlpf >= this.aMhwTdaihjfytqfieIrkjLzZPPbXA + (double)this.YlRNihEsuSGDdslApCwbLwhqWlWK.buttonDoublePressSpeed + 2.0 * (double)iWmRLdlDqgwSNYjkwtUZeqvQOyqs.MeSfMuugNEENLeckTfhpdKMrgqPnA && this.oasLTjvytYRRxCRrSpvqrPYskPEO == 0f && this.sGGCzsEeoDSBtSrlxSKeHPBCsmKP == 0f && this.KajzFKihNEjWuehiOXCCIxwYfdMwA != ButtonStateFlags.Off && this.KOrCdgLQnDavzpHwTiQPalMvXzXS != ButtonStateFlags.Off && this.qbhaOciqzCkNCIlwEwJKotfknFjBc != ButtonStateFlags.Off && this.qBCyQtIYqovqpZllKdBfaaYGidap != ButtonStateFlags.Off && this.ryopNaHJTYcuRbBnPpNTlmNjQMYw == 0f && this.iZHcfyoRntXaXezNLwLqfRMJEaTy == 0f && this.tqrZORUfVoRNQtHUbKEdCOkcDqes == 0f && this.fqfmqVuuCZMoAwfDtObWdbQyUtkc == 0f && (this.FpjEdiSudHSPKLXGpTmqphnhZEku == null || !this.FpjEdiSudHSPKLXGpTmqphnhZEku.running) && (this.KtjcFUXwwpcTBjLUMfNcoBivcqnl == null || !this.KtjcFUXwwpcTBjLUMfNcoBivcqnl.running);
			}

			// Token: 0x06000884 RID: 2180 RVA: 0x000093A9 File Offset: 0x000075A9
			internal void OVSBjVjnQvcgjKCJMlNGevEOAptj()
			{
				this.KajzFKihNEjWuehiOXCCIxwYfdMwA &= ~ButtonStateFlags.Down;
				this.qbhaOciqzCkNCIlwEwJKotfknFjBc &= ~ButtonStateFlags.Down;
			}

			// Token: 0x06000885 RID: 2181 RVA: 0x000407DC File Offset: 0x0003E9DC
			internal void VDjwiQcEaCwJeAFFpfsHncZrfubd()
			{
				if (this.oasLTjvytYRRxCRrSpvqrPYskPEO != 0f || this.ryopNaHJTYcuRbBnPpNTlmNjQMYw != 0f)
				{
					this.dPDqMsXfFXDGwDSbydHgVeBVMAGt = iWmRLdlDqgwSNYjkwtUZeqvQOyqs.yAmVOKAzQbbmGgwQiXjbiiDizlpf;
				}
				if (this.oasLTjvytYRRxCRrSpvqrPYskPEO != 0f || this.tqrZORUfVoRNQtHUbKEdCOkcDqes != 0f)
				{
					this.WiNEJPbkwaKTIyaDurzMQGTRrrfaA = iWmRLdlDqgwSNYjkwtUZeqvQOyqs.yAmVOKAzQbbmGgwQiXjbiiDizlpf;
				}
				if ((this.KajzFKihNEjWuehiOXCCIxwYfdMwA & ButtonStateFlags.On) != ButtonStateFlags.Off || (this.KajzFKihNEjWuehiOXCCIxwYfdMwA & ButtonStateFlags.Down) != ButtonStateFlags.Off)
				{
					this.fqOoVZmxXJkIXjLSCrqpnzmopFOS = iWmRLdlDqgwSNYjkwtUZeqvQOyqs.yAmVOKAzQbbmGgwQiXjbiiDizlpf;
				}
				if ((this.qbhaOciqzCkNCIlwEwJKotfknFjBc & ButtonStateFlags.On) != ButtonStateFlags.Off || (this.qbhaOciqzCkNCIlwEwJKotfknFjBc & ButtonStateFlags.Down) != ButtonStateFlags.Off)
				{
					this.sINqeaEGWWfQZJxTtWkQbJFXdScb = iWmRLdlDqgwSNYjkwtUZeqvQOyqs.yAmVOKAzQbbmGgwQiXjbiiDizlpf;
				}
				this.oasLTjvytYRRxCRrSpvqrPYskPEO = 0f;
				this.sGGCzsEeoDSBtSrlxSKeHPBCsmKP = 0f;
				this.GfYitGKmPeEuZKGFmfzayTwXLoyWA = AxisCoordinateMode.Absolute;
				this.KajzFKihNEjWuehiOXCCIxwYfdMwA = ButtonStateFlags.Off;
				this.KOrCdgLQnDavzpHwTiQPalMvXzXS = ButtonStateFlags.Off;
				this.qbhaOciqzCkNCIlwEwJKotfknFjBc = ButtonStateFlags.Off;
				this.qBCyQtIYqovqpZllKdBfaaYGidap = ButtonStateFlags.Off;
				this.ryopNaHJTYcuRbBnPpNTlmNjQMYw = 0f;
				this.iZHcfyoRntXaXezNLwLqfRMJEaTy = 0f;
				this.tqrZORUfVoRNQtHUbKEdCOkcDqes = 0f;
				this.fqfmqVuuCZMoAwfDtObWdbQyUtkc = 0f;
				if (this.FpjEdiSudHSPKLXGpTmqphnhZEku != null)
				{
					this.FpjEdiSudHSPKLXGpTmqphnhZEku.Clear();
					this.KtjcFUXwwpcTBjLUMfNcoBivcqnl.Clear();
				}
				this.DvrckxzHAgNiAEXcdZPkHiPGYQdH.VqzLdvgCGuyZsTDuMsMOtRjAyhlD();
				this.SfuePgCDzipirfiydWvBWgMdQIOEb.VqzLdvgCGuyZsTDuMsMOtRjAyhlD();
				this.OUdUbxVCluiCMZwlIwaRveownPxj.jqjRVVuCDXzuqwBLlRtHUPZyzpVG(iWmRLdlDqgwSNYjkwtUZeqvQOyqs.yAmVOKAzQbbmGgwQiXjbiiDizlpf);
				this.IWPJaMtdUHbReRrCNEiBCXPsABvgb.jqjRVVuCDXzuqwBLlRtHUPZyzpVG(iWmRLdlDqgwSNYjkwtUZeqvQOyqs.yAmVOKAzQbbmGgwQiXjbiiDizlpf);
				this.lQORlLqHceBLlYnxCzyKsdzprFAS.PLnHCankgTmKlGtEhilDuyiDstyL();
				this.CzUABhBolSgnjDZCiSwrbuZsNPcec.PLnHCankgTmKlGtEhilDuyiDstyL();
				this.KRiZMIqrZLcXVqVtFtKxlCODxQHc.neLNINJxygNHYyqXiEcdEuevUEui();
			}

			// Token: 0x06000886 RID: 2182 RVA: 0x0004094C File Offset: 0x0003EB4C
			internal void fzSCplCPnZbQEZQUgchXULgJlqqV()
			{
				this.VDjwiQcEaCwJeAFFpfsHncZrfubd();
				this.OUdUbxVCluiCMZwlIwaRveownPxj.cicvvIwPOZAVQAkdoSThHHSJFNdA();
				this.IWPJaMtdUHbReRrCNEiBCXPsABvgb.cicvvIwPOZAVQAkdoSThHHSJFNdA();
				this.dPDqMsXfFXDGwDSbydHgVeBVMAGt = iWmRLdlDqgwSNYjkwtUZeqvQOyqs.yAmVOKAzQbbmGgwQiXjbiiDizlpf;
				this.WiNEJPbkwaKTIyaDurzMQGTRrrfaA = iWmRLdlDqgwSNYjkwtUZeqvQOyqs.yAmVOKAzQbbmGgwQiXjbiiDizlpf;
				this.fqOoVZmxXJkIXjLSCrqpnzmopFOS = iWmRLdlDqgwSNYjkwtUZeqvQOyqs.yAmVOKAzQbbmGgwQiXjbiiDizlpf;
				this.sINqeaEGWWfQZJxTtWkQbJFXdScb = iWmRLdlDqgwSNYjkwtUZeqvQOyqs.yAmVOKAzQbbmGgwQiXjbiiDizlpf;
			}

			// Token: 0x04000696 RID: 1686
			internal double aMhwTdaihjfytqfieIrkjLzZPPbXA;

			// Token: 0x04000697 RID: 1687
			private InputBehavior YlRNihEsuSGDdslApCwbLwhqWlWK;

			// Token: 0x04000698 RID: 1688
			internal float oasLTjvytYRRxCRrSpvqrPYskPEO;

			// Token: 0x04000699 RID: 1689
			internal float sGGCzsEeoDSBtSrlxSKeHPBCsmKP;

			// Token: 0x0400069A RID: 1690
			internal AxisCoordinateMode GfYitGKmPeEuZKGFmfzayTwXLoyWA;

			// Token: 0x0400069B RID: 1691
			internal AxisCoordinateMode LwLTiurhpQHchoddCwYjtwBvkfpd;

			// Token: 0x0400069C RID: 1692
			internal ButtonStateFlags KajzFKihNEjWuehiOXCCIxwYfdMwA;

			// Token: 0x0400069D RID: 1693
			internal ButtonStateFlags KOrCdgLQnDavzpHwTiQPalMvXzXS;

			// Token: 0x0400069E RID: 1694
			internal ButtonStateFlags qbhaOciqzCkNCIlwEwJKotfknFjBc;

			// Token: 0x0400069F RID: 1695
			internal ButtonStateFlags qBCyQtIYqovqpZllKdBfaaYGidap;

			// Token: 0x040006A0 RID: 1696
			internal float ryopNaHJTYcuRbBnPpNTlmNjQMYw;

			// Token: 0x040006A1 RID: 1697
			internal float iZHcfyoRntXaXezNLwLqfRMJEaTy;

			// Token: 0x040006A2 RID: 1698
			internal float tqrZORUfVoRNQtHUbKEdCOkcDqes;

			// Token: 0x040006A3 RID: 1699
			internal float fqfmqVuuCZMoAwfDtObWdbQyUtkc;

			// Token: 0x040006A4 RID: 1700
			private double fqOoVZmxXJkIXjLSCrqpnzmopFOS;

			// Token: 0x040006A5 RID: 1701
			private double sINqeaEGWWfQZJxTtWkQbJFXdScb;

			// Token: 0x040006A6 RID: 1702
			private double dPDqMsXfFXDGwDSbydHgVeBVMAGt;

			// Token: 0x040006A7 RID: 1703
			private double WiNEJPbkwaKTIyaDurzMQGTRrrfaA;

			// Token: 0x040006A8 RID: 1704
			internal yrvAdJcWjyNKnTjDkNBaBpxKQcjhb DvrckxzHAgNiAEXcdZPkHiPGYQdH;

			// Token: 0x040006A9 RID: 1705
			internal yrvAdJcWjyNKnTjDkNBaBpxKQcjhb SfuePgCDzipirfiydWvBWgMdQIOEb;

			// Token: 0x040006AA RID: 1706
			internal ButtonStateRecorder OUdUbxVCluiCMZwlIwaRveownPxj;

			// Token: 0x040006AB RID: 1707
			internal ButtonStateRecorder IWPJaMtdUHbReRrCNEiBCXPsABvgb;

			// Token: 0x040006AC RID: 1708
			internal lQHBTrpgrIfWMYfecjbiXlKojcrB lQORlLqHceBLlYnxCzyKsdzprFAS;

			// Token: 0x040006AD RID: 1709
			internal lQHBTrpgrIfWMYfecjbiXlKojcrB CzUABhBolSgnjDZCiSwrbuZsNPcec;

			// Token: 0x040006AE RID: 1710
			internal TimerAbs FpjEdiSudHSPKLXGpTmqphnhZEku;

			// Token: 0x040006AF RID: 1711
			internal TimerAbs KtjcFUXwwpcTBjLUMfNcoBivcqnl;

			// Token: 0x040006B0 RID: 1712
			internal readonly ccTpHyuBLmqwaKhsPmaxvVJtLJHK KRiZMIqrZLcXVqVtFtKxlCODxQHc = new ccTpHyuBLmqwaKhsPmaxvVJtLJHK();
		}
	}

	// Token: 0x02000100 RID: 256
	private class WjdzkcSlJmaHWCXWmLVbvguSGYbF
	{
		// Token: 0x170002A9 RID: 681
		// (get) Token: 0x06000887 RID: 2183 RVA: 0x000093C9 File Offset: 0x000075C9
		internal iWmRLdlDqgwSNYjkwtUZeqvQOyqs.WjdzkcSlJmaHWCXWmLVbvguSGYbF.szvmGeFdvMPfoVcraWGIUmfzjurk OGYHILzArPasSbCLUkIZyVXBGDxZ
		{
			get
			{
				return this.nhGVoxiWBeRchAPelhlDcFjDILID;
			}
		}

		// Token: 0x06000888 RID: 2184 RVA: 0x000409A4 File Offset: 0x0003EBA4
		internal WjdzkcSlJmaHWCXWmLVbvguSGYbF(UpdateLoopSetting A_1)
		{
			this.nhGVoxiWBeRchAPelhlDcFjDILID = null;
			this.GuFGGLEjYkqxRcViTiJOkWxWEbwIA = new ADictionary<int, iWmRLdlDqgwSNYjkwtUZeqvQOyqs.WjdzkcSlJmaHWCXWmLVbvguSGYbF.szvmGeFdvMPfoVcraWGIUmfzjurk>();
			using (TempListPool.TList<UpdateLoopType> tlist = TempListPool.GetTList<UpdateLoopType>(3))
			{
				List<UpdateLoopType> list = tlist.list;
				EnumConverter.ToUpdateLoopTypes(A_1, list);
				for (int i = 0; i < list.Count; i++)
				{
					iWmRLdlDqgwSNYjkwtUZeqvQOyqs.WjdzkcSlJmaHWCXWmLVbvguSGYbF.szvmGeFdvMPfoVcraWGIUmfzjurk value = new iWmRLdlDqgwSNYjkwtUZeqvQOyqs.WjdzkcSlJmaHWCXWmLVbvguSGYbF.szvmGeFdvMPfoVcraWGIUmfzjurk();
					this.GuFGGLEjYkqxRcViTiJOkWxWEbwIA.Add((int)list[i], value);
					if (this.nhGVoxiWBeRchAPelhlDcFjDILID == null)
					{
						this.nhGVoxiWBeRchAPelhlDcFjDILID = value;
					}
				}
			}
		}

		// Token: 0x06000889 RID: 2185 RVA: 0x000093D1 File Offset: 0x000075D1
		internal void rEOugKBotxolnhTZwmBnbWDbbXDo(UpdateLoopType A_1)
		{
			if (this.DIkllspIxhEHsozDWArotcJJiujU != A_1)
			{
				this.DIkllspIxhEHsozDWArotcJJiujU = A_1;
			}
			this.nhGVoxiWBeRchAPelhlDcFjDILID = this.GuFGGLEjYkqxRcViTiJOkWxWEbwIA[(int)A_1];
			this.nhGVoxiWBeRchAPelhlDcFjDILID.AFOncfacylONgKliykuZMHQxGQUh();
		}

		// Token: 0x0600088A RID: 2186 RVA: 0x00009400 File Offset: 0x00007600
		internal void VhWfJNBOnBVHfCceDtivEFvbpraEA()
		{
			this.nhGVoxiWBeRchAPelhlDcFjDILID.BPVFnAQrJMVnRQqMDYPoAGNuYTVs();
		}

		// Token: 0x040006B1 RID: 1713
		private ADictionary<int, iWmRLdlDqgwSNYjkwtUZeqvQOyqs.WjdzkcSlJmaHWCXWmLVbvguSGYbF.szvmGeFdvMPfoVcraWGIUmfzjurk> GuFGGLEjYkqxRcViTiJOkWxWEbwIA;

		// Token: 0x040006B2 RID: 1714
		private iWmRLdlDqgwSNYjkwtUZeqvQOyqs.WjdzkcSlJmaHWCXWmLVbvguSGYbF.szvmGeFdvMPfoVcraWGIUmfzjurk nhGVoxiWBeRchAPelhlDcFjDILID;

		// Token: 0x040006B3 RID: 1715
		private UpdateLoopType DIkllspIxhEHsozDWArotcJJiujU;

		// Token: 0x02000101 RID: 257
		internal class szvmGeFdvMPfoVcraWGIUmfzjurk
		{
			// Token: 0x0600088B RID: 2187 RVA: 0x0000940D File Offset: 0x0000760D
			internal void AFOncfacylONgKliykuZMHQxGQUh()
			{
				this.NtYIsUlsdEBSYYCVLoHxXOpLlGQG = ReInput.controllers.Mouse.screenPosition;
				this.ZdigNOZSasgLjJyDZsnYiLfXsJFbb = this.NtYIsUlsdEBSYYCVLoHxXOpLlGQG - this.zrhDrCrHKjbkKiNykEIcBLejNvunc;
			}

			// Token: 0x0600088C RID: 2188 RVA: 0x00040A34 File Offset: 0x0003EC34
			internal void BPVFnAQrJMVnRQqMDYPoAGNuYTVs()
			{
				this.zrhDrCrHKjbkKiNykEIcBLejNvunc.x = this.NtYIsUlsdEBSYYCVLoHxXOpLlGQG.x;
				this.zrhDrCrHKjbkKiNykEIcBLejNvunc.y = this.NtYIsUlsdEBSYYCVLoHxXOpLlGQG.y;
				this.zrhDrCrHKjbkKiNykEIcBLejNvunc.z = this.NtYIsUlsdEBSYYCVLoHxXOpLlGQG.z;
			}

			// Token: 0x040006B4 RID: 1716
			internal Vector3 NtYIsUlsdEBSYYCVLoHxXOpLlGQG;

			// Token: 0x040006B5 RID: 1717
			internal Vector3 zrhDrCrHKjbkKiNykEIcBLejNvunc;

			// Token: 0x040006B6 RID: 1718
			internal Vector3 ZdigNOZSasgLjJyDZsnYiLfXsJFbb;
		}
	}
}
