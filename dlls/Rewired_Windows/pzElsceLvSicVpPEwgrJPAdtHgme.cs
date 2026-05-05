using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

// Token: 0x02000005 RID: 5
internal sealed class pzElsceLvSicVpPEwgrJPAdtHgme : IElementIdentifierTool
{
	// Token: 0x06000034 RID: 52 RVA: 0x000113CD File Offset: 0x0000F5CD
	public void Initialize(GUIText text)
	{
		this.knVGIsnyDhWoxbpsYVwEwcPlnVd = text;
	}

	// Token: 0x06000035 RID: 53 RVA: 0x0001DC68 File Offset: 0x0001BE68
	public void Start()
	{
		if (ReInput.isEditor && ReInput.editorPlatform != EditorPlatform.Windows)
		{
			Logger.LogError("Direct Input cannot be run on this platform. You must be running the editor in Windows.");
			return;
		}
		if (ReInput.currentPlatform != Platform.Windows)
		{
			Logger.LogError("Direct Input cannot be run on this build target. Be sure Unity's build target is set to Windows Standalone.");
			return;
		}
		InputSourceWrapper<dksOLhBwLeCynZJmOfwlOOcWOZLI> inputSourceWrapper = ReInput.primaryInputManager.inputSource as InputSourceWrapper<dksOLhBwLeCynZJmOfwlOOcWOZLI>;
		if (inputSourceWrapper == null || inputSourceWrapper.source == null)
		{
			Logger.LogError("Unable to initialize Direct Input! You must add a Rewired Input Manager to the scene and set the input mode to Direct Input.");
			return;
		}
		this.IVdbUQgevHcYOeePuwHWjuUayBxvb = inputSourceWrapper.source;
		ReInput.primaryInputManager.SystemDeviceConnectedEvent += this.CMlnVTvOraysdHzhRRjTouMKkxyv;
		ReInput.primaryInputManager.SystemDeviceDisconnectedEvent += this.KQAZILkJXGwQFsJsPEBUdttsxbZpA;
		this.ePrAHanEaKSfWaipNLpCxbkXtIeY = new TimerRealTime(1.0);
		this.ePrAHanEaKSfWaipNLpCxbkXtIeY.Start();
		this.WoOeKNpRWYvgRuxsIMWGWDqYeAvL();
		this.uioaZFFQdVyLpcQdeXgVHFSRgyrJA = true;
	}

	// Token: 0x06000036 RID: 54 RVA: 0x0001DD2C File Offset: 0x0001BF2C
	public void Update()
	{
		if (!this.uioaZFFQdVyLpcQdeXgVHFSRgyrJA)
		{
			return;
		}
		this.LQCalMHbXMoRiSoHLYzrENxwnkPH = "Direct Input Joystick Element Identifier\n\n";
		this.knVGIsnyDhWoxbpsYVwEwcPlnVd.text = this.LQCalMHbXMoRiSoHLYzrENxwnkPH;
		if (Input.GetKeyDown(KeyCode.A))
		{
			this.kSngspdnqzrBwGMRYTAPortqKlDGA = !this.kSngspdnqzrBwGMRYTAPortqKlDGA;
		}
		if (this.kSngspdnqzrBwGMRYTAPortqKlDGA)
		{
			GUIText guitext = this.knVGIsnyDhWoxbpsYVwEwcPlnVd;
			guitext.text += "All Devices:\n";
			foreach (kvqducHUWPYYsnUhPdQAbkdahByH kvqducHUWPYYsnUhPdQAbkdahByH in this.dJqzZVHfOmoYPZBcsxThLjZVZglO)
			{
				GUIText guitext2 = this.knVGIsnyDhWoxbpsYVwEwcPlnVd;
				guitext2.text = string.Concat(new string[]
				{
					guitext2.text,
					kvqducHUWPYYsnUhPdQAbkdahByH.tRSbereLEbOcuBSoHTMMJPLqjgRsB,
					", ",
					kvqducHUWPYYsnUhPdQAbkdahByH.XZeKnFBCjDoYyombSakLueSbkodK.ToString(),
					", ",
					new PidVid(kvqducHUWPYYsnUhPdQAbkdahByH.mpinInATOSahiTvRyoVzQGzRrZhK).ToString(),
					", ",
					kvqducHUWPYYsnUhPdQAbkdahByH.FmgOkcSqQpMhGnthDkBUKiekcsxcA.ToString(),
					", ",
					kvqducHUWPYYsnUhPdQAbkdahByH.YZkxvYGxcfzMJxmsOEekeomXLTfc.ToString(),
					", ",
					kvqducHUWPYYsnUhPdQAbkdahByH.oyBiqhPDqjctCAUjTDfJfaIoBLcP.ToString(),
					"\n"
				});
			}
			GUIText guitext3 = this.knVGIsnyDhWoxbpsYVwEwcPlnVd;
			guitext3.text += "\n";
		}
		int num = this.mxLJJpXEMEAUbcQSMLkGSaaBibaJb;
		Guid ejhbrGDnFpAPBfysaVphRuOIXQvnA = this.EJHbrGDnFpAPBfysaVphRuOIXQvnA;
		if (ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Equals) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Plus) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.KeypadPlus))
		{
			this.mxLJJpXEMEAUbcQSMLkGSaaBibaJb++;
		}
		if (ReInput.controllers.Keyboard.GetKeyDown(KeyCode.KeypadMinus) || ReInput.controllers.Keyboard.GetKeyDown(KeyCode.Minus))
		{
			this.mxLJJpXEMEAUbcQSMLkGSaaBibaJb--;
		}
		if (this.ePrAHanEaKSfWaipNLpCxbkXtIeY.Update())
		{
			int num2 = this.IVdbUQgevHcYOeePuwHWjuUayBxvb.SerKKfYzathThHUDMrkDSWCwoEqe(SFbUwDPTMspCnXvMvungUBWLzgsP.All, ygHzebjbxdKDQMBRjdWGjwNnmSHd.AttachedOnly);
			if (num2 != this.MACRlubYcPpxzgywQGkEdnFxYLam)
			{
				this.MACRlubYcPpxzgywQGkEdnFxYLam = num2;
				this.wStIpbXLihkcoEGYfdDThjhSqFHw = true;
			}
			this.ePrAHanEaKSfWaipNLpCxbkXtIeY.Start();
		}
		if (this.wStIpbXLihkcoEGYfdDThjhSqFHw)
		{
			this.WoOeKNpRWYvgRuxsIMWGWDqYeAvL();
			this.wStIpbXLihkcoEGYfdDThjhSqFHw = false;
		}
		int num3 = (this.hZTVVBogSvBQWgjpoSadVQliPRVpA != null) ? this.hZTVVBogSvBQWgjpoSadVQliPRVpA.Count : 0;
		if (num3 == 0)
		{
			return;
		}
		if (this.mxLJJpXEMEAUbcQSMLkGSaaBibaJb < 0)
		{
			this.mxLJJpXEMEAUbcQSMLkGSaaBibaJb = num3 - 1;
		}
		else if (this.mxLJJpXEMEAUbcQSMLkGSaaBibaJb >= num3)
		{
			this.mxLJJpXEMEAUbcQSMLkGSaaBibaJb = 0;
		}
		this.EJHbrGDnFpAPBfysaVphRuOIXQvnA = this.hZTVVBogSvBQWgjpoSadVQliPRVpA[this.mxLJJpXEMEAUbcQSMLkGSaaBibaJb].GrRuyCwBfgeHmBsXOdUvfoKYTnYA;
		bool flag = false;
		if (num != this.mxLJJpXEMEAUbcQSMLkGSaaBibaJb || ejhbrGDnFpAPBfysaVphRuOIXQvnA != this.EJHbrGDnFpAPBfysaVphRuOIXQvnA)
		{
			flag = true;
		}
		if (this.CeRWlOxFxdMeGpztaaZVoqpudFuL == null || flag)
		{
			if (this.CeRWlOxFxdMeGpztaaZVoqpudFuL != null)
			{
				this.CeRWlOxFxdMeGpztaaZVoqpudFuL.azTjTWrVAOAlWADiYwJQncVvorTU();
			}
			this.CeRWlOxFxdMeGpztaaZVoqpudFuL = new kgqhUexiHegpQmaRUvQyXXyfTECW(this.IVdbUQgevHcYOeePuwHWjuUayBxvb, this.hZTVVBogSvBQWgjpoSadVQliPRVpA[this.mxLJJpXEMEAUbcQSMLkGSaaBibaJb].GrRuyCwBfgeHmBsXOdUvfoKYTnYA);
			if (this.CeRWlOxFxdMeGpztaaZVoqpudFuL == null)
			{
				return;
			}
			IList<LyiAUWWzjPRwFcxvPTEgvdJUSkUA> list = this.CeRWlOxFxdMeGpztaaZVoqpudFuL.qvxlvXlbItcexJtCOoREdDPFrrFqB();
			if (list != null)
			{
				for (int i = 0; i < list.Count; i++)
				{
					if ((list[i].bjWXMLfHRtGTECgaZOZSCAMQYuzAA.lbKBezcrYXWyPWPaNBDYahtKBlXB & rmFZIqnOsqENbRWsSmclbFIafHVW.Axis) != rmFZIqnOsqENbRWsSmclbFIafHVW.All)
					{
						this.CeRWlOxFxdMeGpztaaZVoqpudFuL.hvPlNSFhsvggEswPiOjjzbrDiKPI.yaEXBaToYwMdgaylhOUXWYbEkjWs = new AWzvRDbHSYHwJyTtCqcXEDbhGjMG(-65535, 65535);
					}
				}
			}
			this.CeRWlOxFxdMeGpztaaZVoqpudFuL.NlelwpaktkGsKPPBIiTDwUOUhcXIA();
		}
		YYJpESzECVBzlTQDCRWMYdxQsJmw yyjpESzECVBzlTQDCRWMYdxQsJmw;
		try
		{
			yyjpESzECVBzlTQDCRWMYdxQsJmw = this.CeRWlOxFxdMeGpztaaZVoqpudFuL.YZDduEATbZPhiZrMqhfqFQogzZXyB();
		}
		catch
		{
			yyjpESzECVBzlTQDCRWMYdxQsJmw = null;
		}
		if (yyjpESzECVBzlTQDCRWMYdxQsJmw == null)
		{
			return;
		}
		if (num3 > 0)
		{
			this.LQCalMHbXMoRiSoHLYzrENxwnkPH = this.LQCalMHbXMoRiSoHLYzrENxwnkPH + num3.ToString() + " connected devices:\n";
		}
		for (int j = 0; j < num3; j++)
		{
			this.LQCalMHbXMoRiSoHLYzrENxwnkPH = this.LQCalMHbXMoRiSoHLYzrENxwnkPH + this.hZTVVBogSvBQWgjpoSadVQliPRVpA[j].tRSbereLEbOcuBSoHTMMJPLqjgRsB + "\n";
		}
		this.LQCalMHbXMoRiSoHLYzrENxwnkPH += "\n";
		this.LQCalMHbXMoRiSoHLYzrENxwnkPH = string.Concat(new string[]
		{
			this.LQCalMHbXMoRiSoHLYzrENxwnkPH,
			"Current DI device ",
			this.mxLJJpXEMEAUbcQSMLkGSaaBibaJb.ToString(),
			": ",
			this.hZTVVBogSvBQWgjpoSadVQliPRVpA[this.mxLJJpXEMEAUbcQSMLkGSaaBibaJb].tRSbereLEbOcuBSoHTMMJPLqjgRsB,
			"\n"
		});
		this.LQCalMHbXMoRiSoHLYzrENxwnkPH += "(Press + or - to change monitored device id.)\n\n";
		this.wcnbFvNpZtHiVhTKZcAIuffMIRPeA("Identifier", new PidVid(this.CeRWlOxFxdMeGpztaaZVoqpudFuL.jIOEeiOCGxpOZYItdaNzBWfyfjPyA.mpinInATOSahiTvRyoVzQGzRrZhK));
		this.wcnbFvNpZtHiVhTKZcAIuffMIRPeA("Instance GUID", this.CeRWlOxFxdMeGpztaaZVoqpudFuL.jIOEeiOCGxpOZYItdaNzBWfyfjPyA.GrRuyCwBfgeHmBsXOdUvfoKYTnYA);
		this.wcnbFvNpZtHiVhTKZcAIuffMIRPeA("Product Id", this.CeRWlOxFxdMeGpztaaZVoqpudFuL.hvPlNSFhsvggEswPiOjjzbrDiKPI.NtdCqAHaxHLesCTtePYdjHXgTAsYb);
		this.wcnbFvNpZtHiVhTKZcAIuffMIRPeA("Device Type", this.CeRWlOxFxdMeGpztaaZVoqpudFuL.FnJHsCgCqMPxbvyMLANMPPhnVEgN.DqDbmOuNNyotSjoqgSTQmyWZoAVd.ToString());
		this.LQCalMHbXMoRiSoHLYzrENxwnkPH += "\n";
		this.wcnbFvNpZtHiVhTKZcAIuffMIRPeA("Axis Count", this.CeRWlOxFxdMeGpztaaZVoqpudFuL.FnJHsCgCqMPxbvyMLANMPPhnVEgN.MzbaDbxFLHHYVrsrGPOOLbXIstMV);
		this.wcnbFvNpZtHiVhTKZcAIuffMIRPeA("Button Count", this.CeRWlOxFxdMeGpztaaZVoqpudFuL.FnJHsCgCqMPxbvyMLANMPPhnVEgN.OwnJetHJpnnCxrjUGkvOqTDWveMb);
		this.wcnbFvNpZtHiVhTKZcAIuffMIRPeA("Hat Count", this.CeRWlOxFxdMeGpztaaZVoqpudFuL.FnJHsCgCqMPxbvyMLANMPPhnVEgN.nBmohHyAGJEEIDssglbJGJKLXlyWA);
		this.LQCalMHbXMoRiSoHLYzrENxwnkPH += "\n";
		if (flag)
		{
			Logger.Log("Device Name: \"" + this.hZTVVBogSvBQWgjpoSadVQliPRVpA[this.mxLJJpXEMEAUbcQSMLkGSaaBibaJb].tRSbereLEbOcuBSoHTMMJPLqjgRsB + "\"");
			Logger.Log("Identifier: " + new PidVid(this.CeRWlOxFxdMeGpztaaZVoqpudFuL.jIOEeiOCGxpOZYItdaNzBWfyfjPyA.mpinInATOSahiTvRyoVzQGzRrZhK).ToString());
		}
		for (int k = 0; k < 32; k++)
		{
			int num4 = this.VlrPXYjiMiLxfDgvslfiWryjNZFS((DirectInputAxis)k, yyjpESzECVBzlTQDCRWMYdxQsJmw);
			DirectInputAxis directInputAxis = (DirectInputAxis)k;
			string text = directInputAxis.ToString();
			this.wcnbFvNpZtHiVhTKZcAIuffMIRPeA(text, num4.ToString() + " (" + this.OFCcFcizKgZMEuOsUBLAIStUFoez(num4).ToString() + ")");
		}
		int[] array = yyjpESzECVBzlTQDCRWMYdxQsJmw.UpLIdneJFMWOLFpxWPvqVMVbbxrT;
		for (int l = 0; l < 4; l++)
		{
			int num5 = array[l];
			string text2 = "Hat " + l.ToString();
			this.wcnbFvNpZtHiVhTKZcAIuffMIRPeA(text2, num5);
		}
		bool[] array2 = yyjpESzECVBzlTQDCRWMYdxQsJmw.eNrbHJbOHpezkLYOAFIbOIIqegzX;
		string text3 = "";
		for (int m = 0; m < 128; m++)
		{
			if (array2[m])
			{
				if (text3 != "")
				{
					text3 += ", ";
				}
				text3 += m.ToString();
			}
		}
		this.wcnbFvNpZtHiVhTKZcAIuffMIRPeA("Buttons ", text3);
		this.knVGIsnyDhWoxbpsYVwEwcPlnVd.text = this.LQCalMHbXMoRiSoHLYzrENxwnkPH;
	}

	// Token: 0x06000037 RID: 55 RVA: 0x0001E46C File Offset: 0x0001C66C
	private void WoOeKNpRWYvgRuxsIMWGWDqYeAvL()
	{
		this.hZTVVBogSvBQWgjpoSadVQliPRVpA = this.IVdbUQgevHcYOeePuwHWjuUayBxvb.QtGkuGIEojjgvWKUuasAddMRxzwl(SFbUwDPTMspCnXvMvungUBWLzgsP.GameControl, ygHzebjbxdKDQMBRjdWGjwNnmSHd.AttachedOnly);
		this.dJqzZVHfOmoYPZBcsxThLjZVZglO = this.IVdbUQgevHcYOeePuwHWjuUayBxvb.QtGkuGIEojjgvWKUuasAddMRxzwl(SFbUwDPTMspCnXvMvungUBWLzgsP.All, ygHzebjbxdKDQMBRjdWGjwNnmSHd.AttachedOnly);
		this.MACRlubYcPpxzgywQGkEdnFxYLam = ((this.dJqzZVHfOmoYPZBcsxThLjZVZglO != null) ? this.dJqzZVHfOmoYPZBcsxThLjZVZglO.Count : 0);
	}

	// Token: 0x06000038 RID: 56 RVA: 0x000113D6 File Offset: 0x0000F5D6
	private void CMlnVTvOraysdHzhRRjTouMKkxyv()
	{
		this.qVumLtUMTigmyMVbLwVrcoVYGBTv();
	}

	// Token: 0x06000039 RID: 57 RVA: 0x000113D6 File Offset: 0x0000F5D6
	private void KQAZILkJXGwQFsJsPEBUdttsxbZpA()
	{
		this.qVumLtUMTigmyMVbLwVrcoVYGBTv();
	}

	// Token: 0x0600003A RID: 58 RVA: 0x000113DE File Offset: 0x0000F5DE
	private void qVumLtUMTigmyMVbLwVrcoVYGBTv()
	{
		this.KRzlCrQgHjLUwqzXsXayUkdIgKPe();
		this.wStIpbXLihkcoEGYfdDThjhSqFHw = true;
	}

	// Token: 0x0600003B RID: 59 RVA: 0x000113ED File Offset: 0x0000F5ED
	private void KRzlCrQgHjLUwqzXsXayUkdIgKPe()
	{
		this.mxLJJpXEMEAUbcQSMLkGSaaBibaJb = 0;
		this.CeRWlOxFxdMeGpztaaZVoqpudFuL = null;
		this.EJHbrGDnFpAPBfysaVphRuOIXQvnA = Guid.Empty;
		this.hZTVVBogSvBQWgjpoSadVQliPRVpA = null;
		this.dJqzZVHfOmoYPZBcsxThLjZVZglO = null;
		this.kSngspdnqzrBwGMRYTAPortqKlDGA = false;
		this.wStIpbXLihkcoEGYfdDThjhSqFHw = false;
		this.MACRlubYcPpxzgywQGkEdnFxYLam = 0;
	}

	// Token: 0x0600003C RID: 60 RVA: 0x0001142B File Offset: 0x0000F62B
	private void wcnbFvNpZtHiVhTKZcAIuffMIRPeA(string A_1, object A_2)
	{
		this.LQCalMHbXMoRiSoHLYzrENxwnkPH = string.Concat(new string[]
		{
			this.LQCalMHbXMoRiSoHLYzrENxwnkPH,
			A_1,
			" = ",
			A_2.ToString(),
			"\n"
		});
	}

	// Token: 0x0600003D RID: 61 RVA: 0x0001E4BC File Offset: 0x0001C6BC
	private int VlrPXYjiMiLxfDgvslfiWryjNZFS(DirectInputAxis A_1, YYJpESzECVBzlTQDCRWMYdxQsJmw A_2)
	{
		int result;
		switch (A_1)
		{
		case DirectInputAxis.X:
			result = A_2.OXsXEeZYYccDtQxaTmxEmzsaqftA;
			break;
		case DirectInputAxis.Y:
			result = A_2.jaMVMrxxLbLHYVkNUClAyqrYVgap;
			break;
		case DirectInputAxis.Z:
			result = A_2.cHIRwRHXXwEjYNxPpAjCbLhkLixH;
			break;
		case DirectInputAxis.RotationX:
			result = A_2.cokAOaqKaqBoLSFrtmZPXARddvtcA;
			break;
		case DirectInputAxis.RotationY:
			result = A_2.wSjjkJcaHRrAjnFdlfmmqMxOmcGC;
			break;
		case DirectInputAxis.RotationZ:
			result = A_2.dWHwHiuJqgFQgbTcwGKWNgXyPXDLA;
			break;
		case DirectInputAxis.Slider0:
			result = A_2.AQhLmzfZMTQHPRLBUcEEMNbuKcNd[0];
			break;
		case DirectInputAxis.Slider1:
			result = A_2.AQhLmzfZMTQHPRLBUcEEMNbuKcNd[1];
			break;
		case DirectInputAxis.VelocityX:
			result = A_2.pSKxiDxLkWbwPahWieUAFKBnyVXOA;
			break;
		case DirectInputAxis.VelocityY:
			result = A_2.BRqLbDVCIyhCIDEgyhWQarqLglHNA;
			break;
		case DirectInputAxis.VelocityZ:
			result = A_2.ErmEHXkpeZLQaxlStIhBatAEmNrVA;
			break;
		case DirectInputAxis.AngularVelocityX:
			result = A_2.FUzIkIKzoqgZgkmFnoAukNBmRUoS;
			break;
		case DirectInputAxis.AngularVelocityY:
			result = A_2.AqmJYIgqEHBbfOXZPNRdijKrAuzcA;
			break;
		case DirectInputAxis.AngularVelocityZ:
			result = A_2.HwrgKLGSLdmDOudMfeFLwpzRcrnMA;
			break;
		case DirectInputAxis.VelocitySlider0:
			result = A_2.FDRMiiddqimGjBvlYEcXYJBfUotl[0];
			break;
		case DirectInputAxis.VelocitySlider1:
			result = A_2.FDRMiiddqimGjBvlYEcXYJBfUotl[1];
			break;
		case DirectInputAxis.AccelerationX:
			result = A_2.DNiKfdUBbDbyYvNEIYQpIIuEkUOc;
			break;
		case DirectInputAxis.AccelerationY:
			result = A_2.SjIanMwRZanFxSPcWIasCtfeJUDLA;
			break;
		case DirectInputAxis.AccelerationZ:
			result = A_2.UPFgOJsqTDXYLChvoCCopCmEhNkU;
			break;
		case DirectInputAxis.AngularAccelerationX:
			result = A_2.BnnDwCVefHbLhAtdTFuZKMBKUCOaA;
			break;
		case DirectInputAxis.AngularAccelerationY:
			result = A_2.OPSqgYfXYxMCGlXmkRGGYmlKbuwE;
			break;
		case DirectInputAxis.AngularAccelerationZ:
			result = A_2.IqXnDRnGhmmONzYryPcuCGPeLigb;
			break;
		case DirectInputAxis.AccelerationSlider0:
			result = A_2.jVwKAvrEQhnOEbbmghZKgSxWMzWb[0];
			break;
		case DirectInputAxis.AccelerationSlider1:
			result = A_2.jVwKAvrEQhnOEbbmghZKgSxWMzWb[1];
			break;
		case DirectInputAxis.ForceX:
			result = A_2.poVASmNsBSlAtTPnURPlgnNwTVek;
			break;
		case DirectInputAxis.ForceY:
			result = A_2.XkMBVQdmpNGnXqtLMjtjjQOgKxlo;
			break;
		case DirectInputAxis.ForceZ:
			result = A_2.fRcuxBeAsTaTtMENjxmkXJOBBRWQ;
			break;
		case DirectInputAxis.TorqueX:
			result = A_2.QtxcrLVuJlcuwnYvfiMLXZQrvYBP;
			break;
		case DirectInputAxis.TorqueY:
			result = A_2.tjJfDPGccOQkrXYoKKFnmRixdssq;
			break;
		case DirectInputAxis.TorqueZ:
			result = A_2.bUNqDPnNoEBPhXXPLVGGkiyrqyqD;
			break;
		case DirectInputAxis.ForceSlider0:
			result = A_2.iZAlvLSIlUBfemngabGpONTqHjBr[0];
			break;
		case DirectInputAxis.ForceSlider1:
			result = A_2.iZAlvLSIlUBfemngabGpONTqHjBr[1];
			break;
		default:
			return 0;
		}
		return result;
	}

	// Token: 0x0600003E RID: 62 RVA: 0x00011464 File Offset: 0x0000F664
	private float OFCcFcizKgZMEuOsUBLAIStUFoez(int A_1)
	{
		if (A_1 == 0)
		{
			return 0f;
		}
		return MathTools.Clamp((float)MathTools.Abs(A_1) / 65535f * (float)MathTools.Sign(A_1), -1f, 1f);
	}

	// Token: 0x0600003F RID: 63 RVA: 0x00011493 File Offset: 0x0000F693
	public void OnDestroy()
	{
		if (this.CeRWlOxFxdMeGpztaaZVoqpudFuL != null)
		{
			this.CeRWlOxFxdMeGpztaaZVoqpudFuL.azTjTWrVAOAlWADiYwJQncVvorTU();
		}
	}

	// Token: 0x0400000F RID: 15
	private GUIText knVGIsnyDhWoxbpsYVwEwcPlnVd;

	// Token: 0x04000010 RID: 16
	private string LQCalMHbXMoRiSoHLYzrENxwnkPH;

	// Token: 0x04000011 RID: 17
	private int mxLJJpXEMEAUbcQSMLkGSaaBibaJb;

	// Token: 0x04000012 RID: 18
	private dksOLhBwLeCynZJmOfwlOOcWOZLI IVdbUQgevHcYOeePuwHWjuUayBxvb;

	// Token: 0x04000013 RID: 19
	private kgqhUexiHegpQmaRUvQyXXyfTECW CeRWlOxFxdMeGpztaaZVoqpudFuL;

	// Token: 0x04000014 RID: 20
	private Guid EJHbrGDnFpAPBfysaVphRuOIXQvnA;

	// Token: 0x04000015 RID: 21
	private IList<kvqducHUWPYYsnUhPdQAbkdahByH> hZTVVBogSvBQWgjpoSadVQliPRVpA;

	// Token: 0x04000016 RID: 22
	private IList<kvqducHUWPYYsnUhPdQAbkdahByH> dJqzZVHfOmoYPZBcsxThLjZVZglO;

	// Token: 0x04000017 RID: 23
	private bool kSngspdnqzrBwGMRYTAPortqKlDGA;

	// Token: 0x04000018 RID: 24
	private bool wStIpbXLihkcoEGYfdDThjhSqFHw;

	// Token: 0x04000019 RID: 25
	private bool uioaZFFQdVyLpcQdeXgVHFSRgyrJA;

	// Token: 0x0400001A RID: 26
	private int MACRlubYcPpxzgywQGkEdnFxYLam;

	// Token: 0x0400001B RID: 27
	private TimerRealTime ePrAHanEaKSfWaipNLpCxbkXtIeY;
}
