using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired;
using Rewired.Config;
using Rewired.Data;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Platforms;
using Rewired.Platforms.Windows.RawInput;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;

// Token: 0x02000019 RID: 25
internal class CNVeZFjzzLebAIeziISIZlyPJSYp : PlatformInputManager, tzycxhCaFmhznyezTOQRNaGkykDIA
{
	// Token: 0x17000023 RID: 35
	// (get) Token: 0x060000EF RID: 239 RVA: 0x00011B81 File Offset: 0x0000FD81
	// (set) Token: 0x060000F0 RID: 240 RVA: 0x00011B89 File Offset: 0x0000FD89
	public xKKbjmIOHiqxZGRJDfbeyLuvTjMwB qbaspVnkVEWcLMRiajjuCAMzxLHi
	{
		get
		{
			return this.IvIVeyNCdGsTxwwBstcLtQkSboJS;
		}
		set
		{
			this.qbaspVnkVEWcLMRiajjuCAMzxLHi = value;
			this.xCWCOreulhlkYpnoEEnENjWmIpvFb.oQzxFwlcIcatZVsQxCfIuwzeBVMo = value;
		}
	}

	// Token: 0x060000F1 RID: 241 RVA: 0x00023700 File Offset: 0x00021900
	public CNVeZFjzzLebAIeziISIZlyPJSYp(ConfigVars A_1, xKKbjmIOHiqxZGRJDfbeyLuvTjMwB A_2, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> A_3, Func<int> A_4, bool A_5, bool A_6, bool A_7, bool A_8)
	{
		try
		{
			this.aXEjebxGLwyXmDCYNFJRDHYEvPAv = A_1;
			this.IvIVeyNCdGsTxwwBstcLtQkSboJS = A_2;
			this.bDMigIRDcAKGTfXixCswIKbReWqn = A_3;
			this.LFfbRgBFGLRgpTuoUJAxTByfLshF = A_4;
			this.mWxENYiEREDzNbTnHpHcKrOZAcCLB = A_5;
			this.DwEmDXbRoPJkbOyBvCSvxbRDmuLf = A_6;
			this.INjOOzuoZOdTGHhFshEekuGDiyCY = A_7;
			this.jNWUoElfaOEdEbRAjqoeQgQVjOsJA = this;
			UpdateLoopSetting updateLoop = A_1.updateLoop;
			if (A_7)
			{
				this.uIKfnpBYHczxRqmFAGQMJrCWAhNTA = new LEiRbylTDtVrpnaZskyeFoLSqqLb(updateLoop);
			}
			if (A_6)
			{
				this.cPzcFCKmQHIlcFRtfAZjoAWJNMBPB = new FdQbBsfCWcVHOnPrmheJzorKWKWz(updateLoop);
			}
			this.xCWCOreulhlkYpnoEEnENjWmIpvFb = new wOInxLKDewlatLvQaXlNWuUFKXeD(A_1, A_2, A_5, A_8, this.cPzcFCKmQHIlcFRtfAZjoAWJNMBPB, this.uIKfnpBYHczxRqmFAGQMJrCWAhNTA);
			this.zqXWauNWQnMnHoPuaoZWlcUHjYEw = new Action<int, ControllerDataUpdater>(this.UpdateControllerData);
			this.PltCtvHTiBvYCgfuWMWqRCRHFAOgA = new UHsWCAvrjUBCvVSiOhWZLujgvmAM<bool>(true, new Func<bool>(this.XEpuOMiMXSadodgtdfSbxKXCnyrZA));
			this.JsbgKZzOPiQSixJMAqRYUtGirbyu = new UHsWCAvrjUBCvVSiOhWZLujgvmAM<bool>(true, new Func<bool>(this.xCWCOreulhlkYpnoEEnENjWmIpvFb.rxjEIqjbpjPrYTwkutnBqbrcuXeFA));
		}
		catch (Exception)
		{
			this.OnDestroy();
			throw;
		}
	}

	// Token: 0x17000024 RID: 36
	// (get) Token: 0x060000F2 RID: 242 RVA: 0x00011B9E File Offset: 0x0000FD9E
	[CustomObfuscation(rename = false)]
	public override int deviceCount
	{
		get
		{
			return this.YqYyocwfLXbFaxpiROWQZGtThBlV;
		}
	}

	// Token: 0x17000025 RID: 37
	// (get) Token: 0x060000F3 RID: 243 RVA: 0x00011BA6 File Offset: 0x0000FDA6
	[CustomObfuscation(rename = false)]
	public override PlatformInputManager primaryInputManager
	{
		get
		{
			return this.jNWUoElfaOEdEbRAjqoeQgQVjOsJA;
		}
	}

	// Token: 0x17000026 RID: 38
	// (get) Token: 0x060000F4 RID: 244 RVA: 0x00011BAE File Offset: 0x0000FDAE
	[CustomObfuscation(rename = false)]
	public override IInputSource inputSource
	{
		get
		{
			return this.xCWCOreulhlkYpnoEEnENjWmIpvFb;
		}
	}

	// Token: 0x17000027 RID: 39
	// (get) Token: 0x060000F5 RID: 245 RVA: 0x00011BB6 File Offset: 0x0000FDB6
	[CustomObfuscation(rename = false)]
	public override InputSource inputSourceType
	{
		get
		{
			return InputSource.RawInput;
		}
	}

	// Token: 0x060000F6 RID: 246 RVA: 0x000237F8 File Offset: 0x000219F8
	[CustomObfuscation(rename = false)]
	public override void Initialize()
	{
		if (this.mWxENYiEREDzNbTnHpHcKrOZAcCLB || this.xCWCOreulhlkYpnoEEnENjWmIpvFb.PCIejCVVtKDeaxdrPCqsOfGdCdPJ)
		{
			this.RLgWaYTpxYpscDYaNvpFnRfbwmIv = new TimerRealTime(1.0);
			this.RLgWaYTpxYpscDYaNvpFnRfbwmIv.Start();
		}
		if (this.mWxENYiEREDzNbTnHpHcKrOZAcCLB)
		{
			this.VWXDDHKiCSGzwoucGYwHCmEBGSTXA = new CNVeZFjzzLebAIeziISIZlyPJSYp.sJcDUhDYViyFPlCVdxFJkCszZdoqA();
			this.BkDdAHEqOXYCOJPpbNHimTxSMLnab();
		}
	}

	// Token: 0x060000F7 RID: 247 RVA: 0x00023854 File Offset: 0x00021A54
	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		if (this.mWxENYiEREDzNbTnHpHcKrOZAcCLB || this.xCWCOreulhlkYpnoEEnENjWmIpvFb.PCIejCVVtKDeaxdrPCqsOfGdCdPJ)
		{
			this.ezFcBGccicGGbqQqyqzmctKtpqEr();
		}
		if (this.xCWCOreulhlkYpnoEEnENjWmIpvFb != null)
		{
			this.xCWCOreulhlkYpnoEEnENjWmIpvFb.Update();
		}
		this.FDVjqgofmTVpXxGjRnYPXpuPakdV();
		if (this.mWxENYiEREDzNbTnHpHcKrOZAcCLB)
		{
			if (this.xCWCOreulhlkYpnoEEnENjWmIpvFb != null)
			{
				this.xCWCOreulhlkYpnoEEnENjWmIpvFb.UpdateDevices(updateLoop);
			}
			this.xAFzupPIKifBZHGLcxhHtesiDOamA();
			if (this.xCWCOreulhlkYpnoEEnENjWmIpvFb != null)
			{
				this.xCWCOreulhlkYpnoEEnENjWmIpvFb.UpdateFinished();
			}
		}
		if (this.DwEmDXbRoPJkbOyBvCSvxbRDmuLf)
		{
			this.cPzcFCKmQHIlcFRtfAZjoAWJNMBPB.BjWURhNYGQxLjiyTcWeKsLsEBRsH(updateLoop);
		}
		if (this.INjOOzuoZOdTGHhFshEekuGDiyCY)
		{
			this.uIKfnpBYHczxRqmFAGQMJrCWAhNTA.fpQBTkhQAnLDhPBxlsoktJfJDLAuA(updateLoop);
		}
	}

	// Token: 0x060000F8 RID: 248 RVA: 0x000238F4 File Offset: 0x00021AF4
	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (this.JsbgKZzOPiQSixJMAqRYUtGirbyu != null)
		{
			this.JsbgKZzOPiQSixJMAqRYUtGirbyu.eJRoAWWYCTmYLtClrCmkPPBxhWgT();
		}
		if (this.PltCtvHTiBvYCgfuWMWqRCRHFAOgA != null)
		{
			this.PltCtvHTiBvYCgfuWMWqRCRHFAOgA.eJRoAWWYCTmYLtClrCmkPPBxhWgT();
		}
		if (this.tKCCBxTaamCBbXZOJQZSBHAbNZiC != null)
		{
			int count = this.tKCCBxTaamCBbXZOJQZSBHAbNZiC.Count;
			for (int i = 0; i < count; i++)
			{
				if (this.tKCCBxTaamCBbXZOJQZSBHAbNZiC[i] != null)
				{
					this.tKCCBxTaamCBbXZOJQZSBHAbNZiC[i].BFCoUBDQuBWuVZqMsTMGuliBuwjQ();
				}
			}
		}
		if (this.uIKfnpBYHczxRqmFAGQMJrCWAhNTA != null)
		{
			this.uIKfnpBYHczxRqmFAGQMJrCWAhNTA.Dispose();
		}
		if (this.cPzcFCKmQHIlcFRtfAZjoAWJNMBPB != null)
		{
			this.cPzcFCKmQHIlcFRtfAZjoAWJNMBPB.Dispose();
		}
		if (this.xCWCOreulhlkYpnoEEnENjWmIpvFb != null)
		{
			this.xCWCOreulhlkYpnoEEnENjWmIpvFb.Dispose();
		}
	}

	// Token: 0x060000F9 RID: 249 RVA: 0x00011BB9 File Offset: 0x0000FDB9
	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return this.zqXWauNWQnMnHoPuaoZWlcUHjYEw;
	}

	// Token: 0x060000FA RID: 250 RVA: 0x000239A0 File Offset: 0x00021BA0
	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
	{
		if (!this.mWxENYiEREDzNbTnHpHcKrOZAcCLB)
		{
			return;
		}
		for (int i = 0; i < this.YqYyocwfLXbFaxpiROWQZGtThBlV; i++)
		{
			if (this.tKCCBxTaamCBbXZOJQZSBHAbNZiC[i].inputManagerId == inputManagerId)
			{
				this.tKCCBxTaamCBbXZOJQZSBHAbNZiC[i].FillData(data);
				return;
			}
		}
		Logger.LogError("Invalid joystick Id " + inputManagerId.ToString() + "!");
	}

	// Token: 0x060000FB RID: 251 RVA: 0x00023A0C File Offset: 0x00021C0C
	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		this.xCWCOreulhlkYpnoEEnENjWmIpvFb.SystemDeviceConnected();
		this.uIoJgihGQYcdBfNDTtaErQaOlTKOA = true;
		if (this.mWxENYiEREDzNbTnHpHcKrOZAcCLB || this.xCWCOreulhlkYpnoEEnENjWmIpvFb.PCIejCVVtKDeaxdrPCqsOfGdCdPJ)
		{
			this.RLgWaYTpxYpscDYaNvpFnRfbwmIv.Start();
		}
		if (this.INjOOzuoZOdTGHhFshEekuGDiyCY)
		{
			this.uIKfnpBYHczxRqmFAGQMJrCWAhNTA.GIYUwiSQNBuyUKiPhSkyEqmfjUwj(true);
		}
		if (this.DwEmDXbRoPJkbOyBvCSvxbRDmuLf)
		{
			this.cPzcFCKmQHIlcFRtfAZjoAWJNMBPB.BytJGpUFJwIgimYgIGbNpkfSpwIG(true);
		}
		if (this._SystemDeviceConnectedEvent != null)
		{
			this._SystemDeviceConnectedEvent();
		}
	}

	// Token: 0x060000FC RID: 252 RVA: 0x00023A88 File Offset: 0x00021C88
	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		this.xCWCOreulhlkYpnoEEnENjWmIpvFb.SystemDeviceDisconnected();
		this.uIoJgihGQYcdBfNDTtaErQaOlTKOA = true;
		if (this.mWxENYiEREDzNbTnHpHcKrOZAcCLB || this.xCWCOreulhlkYpnoEEnENjWmIpvFb.PCIejCVVtKDeaxdrPCqsOfGdCdPJ)
		{
			this.RLgWaYTpxYpscDYaNvpFnRfbwmIv.Start();
		}
		if (this.INjOOzuoZOdTGHhFshEekuGDiyCY)
		{
			this.uIKfnpBYHczxRqmFAGQMJrCWAhNTA.GIYUwiSQNBuyUKiPhSkyEqmfjUwj(false);
		}
		if (this.DwEmDXbRoPJkbOyBvCSvxbRDmuLf)
		{
			this.cPzcFCKmQHIlcFRtfAZjoAWJNMBPB.BytJGpUFJwIgimYgIGbNpkfSpwIG(false);
		}
		if (this._SystemDeviceDisconnectedEvent != null)
		{
			this._SystemDeviceDisconnectedEvent();
		}
	}

	// Token: 0x060000FD RID: 253 RVA: 0x00011BC1 File Offset: 0x0000FDC1
	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
		bool flag = this.mWxENYiEREDzNbTnHpHcKrOZAcCLB;
	}

	// Token: 0x060000FE RID: 254 RVA: 0x00011BCA File Offset: 0x0000FDCA
	[CustomObfuscation(rename = false)]
	public override IUnifiedMouseSource GetUnifiedMouseSource()
	{
		return this.cPzcFCKmQHIlcFRtfAZjoAWJNMBPB;
	}

	// Token: 0x060000FF RID: 255 RVA: 0x00011BD2 File Offset: 0x0000FDD2
	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		return this.uIKfnpBYHczxRqmFAGQMJrCWAhNTA;
	}

	// Token: 0x06000100 RID: 256 RVA: 0x00011BDA File Offset: 0x0000FDDA
	public void rkMJMQFJvlHAtoNgYhrnfzzhDyOi(hrpcZZIqnmZSMLjZjTNAXapJJkbG A_1, TmQtHAjIIZspIrcxTKZYytluTRan A_2)
	{
	}

	// Token: 0x06000101 RID: 257 RVA: 0x00023B04 File Offset: 0x00021D04
	private void ezFcBGccicGGbqQqyqzmctKtpqEr()
	{
		if (this.PltCtvHTiBvYCgfuWMWqRCRHFAOgA.dEuWrWEuMuRLEfvelqBlJqCXPzLm)
		{
			if (!this.PltCtvHTiBvYCgfuWMWqRCRHFAOgA.tyWUOmZxIPUWAGNTSMzHnebuMTZT())
			{
				return;
			}
			if (this.RLgWaYTpxYpscDYaNvpFnRfbwmIv.running || this.JsbgKZzOPiQSixJMAqRYUtGirbyu.dEuWrWEuMuRLEfvelqBlJqCXPzLm)
			{
				return;
			}
			if (this.PltCtvHTiBvYCgfuWMWqRCRHFAOgA.jPEZROqMpmOrikUBVDIpnrJrIBJO)
			{
				this.uIoJgihGQYcdBfNDTtaErQaOlTKOA = true;
			}
			this.RLgWaYTpxYpscDYaNvpFnRfbwmIv.Start();
			return;
		}
		else
		{
			if (!this.RLgWaYTpxYpscDYaNvpFnRfbwmIv.running)
			{
				this.RLgWaYTpxYpscDYaNvpFnRfbwmIv.Start();
				return;
			}
			if (this.RLgWaYTpxYpscDYaNvpFnRfbwmIv.Update())
			{
				this.PltCtvHTiBvYCgfuWMWqRCRHFAOgA.VlWTpnOmouJNHovmWjtCiEYLYIbj();
			}
			return;
		}
	}

	// Token: 0x06000102 RID: 258 RVA: 0x00011BDE File Offset: 0x0000FDDE
	private void BkDdAHEqOXYCOJPpbNHimTxSMLnab()
	{
		this.JePIPGLGiSWYTsOFthcLKBQRjyZV(this.yTHsRccokqmHeajOuLsbIwquVBaK());
	}

	// Token: 0x06000103 RID: 259 RVA: 0x00023B9C File Offset: 0x00021D9C
	private void JePIPGLGiSWYTsOFthcLKBQRjyZV(IList<zOVftvsFbTAvLzuhvSRGfBOXFlHHA> A_1)
	{
		int num = 0;
		List<CNVeZFjzzLebAIeziISIZlyPJSYp.YlqzBvZkVxRXSgZCOLBuUiBmFFIM> list = this.tKCCBxTaamCBbXZOJQZSBHAbNZiC;
		int num2 = this.YqYyocwfLXbFaxpiROWQZGtThBlV;
		this.tKCCBxTaamCBbXZOJQZSBHAbNZiC = new List<CNVeZFjzzLebAIeziISIZlyPJSYp.YlqzBvZkVxRXSgZCOLBuUiBmFFIM>();
		this.XvazNTgILJbqsufnqINpiHDJJFopA = 0;
		List<CNVeZFjzzLebAIeziISIZlyPJSYp.YlqzBvZkVxRXSgZCOLBuUiBmFFIM> list2 = new List<CNVeZFjzzLebAIeziISIZlyPJSYp.YlqzBvZkVxRXSgZCOLBuUiBmFFIM>();
		for (int i = num2 - 1; i >= 0; i--)
		{
			if (list[i] != null && !list[i].hheXvMPJReEDDkQNDnTCFurdNdeCA)
			{
				list2.Add(list[i]);
				list.RemoveAt(i);
			}
		}
		num2 = ((list != null) ? list.Count : 0);
		int count = A_1.Count;
		for (int j = 0; j < count; j++)
		{
			if (A_1[j] != null)
			{
				zOVftvsFbTAvLzuhvSRGfBOXFlHHA zOVftvsFbTAvLzuhvSRGfBOXFlHHA = A_1[j];
				if (zOVftvsFbTAvLzuhvSRGfBOXFlHHA != null)
				{
					CNVeZFjzzLebAIeziISIZlyPJSYp.YlqzBvZkVxRXSgZCOLBuUiBmFFIM ylqzBvZkVxRXSgZCOLBuUiBmFFIM = new CNVeZFjzzLebAIeziISIZlyPJSYp.YlqzBvZkVxRXSgZCOLBuUiBmFFIM(zOVftvsFbTAvLzuhvSRGfBOXFlHHA, zOVftvsFbTAvLzuhvSRGfBOXFlHHA.BlgUDNeotKGCVXkuubuQsIWeKoTq, this.bDMigIRDcAKGTfXixCswIKbReWqn);
					ylqzBvZkVxRXSgZCOLBuUiBmFFIM.QZpBuNCZbrXOBPeZIsKLkqnEiYCM = zOVftvsFbTAvLzuhvSRGfBOXFlHHA.GNTLZGZMYteNfQShJMHVqmWwrOKR;
					ylqzBvZkVxRXSgZCOLBuUiBmFFIM.nmjgzFgYhQhWjySorJibJlefPZuB = zOVftvsFbTAvLzuhvSRGfBOXFlHHA.aNWLXhLWGmlNwNjarBtbGFEZsCcjb;
					ylqzBvZkVxRXSgZCOLBuUiBmFFIM.RbShfEhwCDRxlQlnNIgzAabGofUo = zOVftvsFbTAvLzuhvSRGfBOXFlHHA.aNWLXhLWGmlNwNjarBtbGFEZsCcjb;
					ylqzBvZkVxRXSgZCOLBuUiBmFFIM.aGYEhbcpcAvttFkyNSFMAWobsbmTA = zOVftvsFbTAvLzuhvSRGfBOXFlHHA.GWbIxeTfbRipYnHifgKzkkVPynigA;
					ylqzBvZkVxRXSgZCOLBuUiBmFFIM.sdRvWgdxGsWZMSXXvhueboThNJNn = zOVftvsFbTAvLzuhvSRGfBOXFlHHA.gQKqCyxHcQWSYcLHtQkBxKYVGOOeA;
					ylqzBvZkVxRXSgZCOLBuUiBmFFIM.jHuKmjKhVLQFojcgfuODCsbysDBm = zOVftvsFbTAvLzuhvSRGfBOXFlHHA.iYEmfoJliEcUkzCqcvRxHanukpuq;
					ylqzBvZkVxRXSgZCOLBuUiBmFFIM.WERnrjuiRULxkuvoZtagkCGPYmyI = zOVftvsFbTAvLzuhvSRGfBOXFlHHA.yMElyrIaKwwjIrvhCAqYRaPPdOojA;
					ylqzBvZkVxRXSgZCOLBuUiBmFFIM.IfQidsDjnCqPQAXhaXLmDYreQIfrd = zOVftvsFbTAvLzuhvSRGfBOXFlHHA.NzkgnaOHNqJCxeRsdSSRrdNSukjE;
					ylqzBvZkVxRXSgZCOLBuUiBmFFIM.haYkWADMIUsnuaWoAcnigKCbcsTj = zOVftvsFbTAvLzuhvSRGfBOXFlHHA.lbnsFjoMSpFiAcHWbdCvUiitnKIcA;
					ylqzBvZkVxRXSgZCOLBuUiBmFFIM.pSNZLlcfOykgkwKOKvuJRJpNDvM = zOVftvsFbTAvLzuhvSRGfBOXFlHHA.LbGTYYxaCCdgIaBoxCQhECxBrFji;
					ylqzBvZkVxRXSgZCOLBuUiBmFFIM.tfIULvCtiOhsPgetTzSSyUpYrHwk = false;
					ylqzBvZkVxRXSgZCOLBuUiBmFFIM.xErTcVOYeKhcFudMIFTpJhEtUuErA = zOVftvsFbTAvLzuhvSRGfBOXFlHHA.sSEwpwqkxLufRnCodfVriXMzECJm;
					ylqzBvZkVxRXSgZCOLBuUiBmFFIM.oQmVFwwpSVhQckqpMqdbpcgAmsdT = zOVftvsFbTAvLzuhvSRGfBOXFlHHA.xgLtCGMbIZFiPgINPDaFQATjyGnb;
					ylqzBvZkVxRXSgZCOLBuUiBmFFIM.MMReLrBzXbjyNdFTkSMJJHhyWTYjA = zOVftvsFbTAvLzuhvSRGfBOXFlHHA.SxJeaFRvaqSIfIBOHeolEfkOnjLl;
					ylqzBvZkVxRXSgZCOLBuUiBmFFIM.eJSwKIfgnTanckexcqhXbtGiGhmmb = zOVftvsFbTAvLzuhvSRGfBOXFlHHA.zbFwepVSfIGHmzLiVemPUGzVopXo;
					ylqzBvZkVxRXSgZCOLBuUiBmFFIM.extension = zOVftvsFbTAvLzuhvSRGfBOXFlHHA.YiEwWqjNaSmyOGhcwoOEsDxwsUCp;
					zOVftvsFbTAvLzuhvSRGfBOXFlHHA.KdgtFiNynTGrzMSLaREzsijtfvXB();
					ylqzBvZkVxRXSgZCOLBuUiBmFFIM.HFXMXcLisBqGOiqwkbYEQTEpbsPCA();
					this.tKCCBxTaamCBbXZOJQZSBHAbNZiC.Add(ylqzBvZkVxRXSgZCOLBuUiBmFFIM);
					num++;
					if (ylqzBvZkVxRXSgZCOLBuUiBmFFIM.xErTcVOYeKhcFudMIFTpJhEtUuErA)
					{
						this.XvazNTgILJbqsufnqINpiHDJJFopA++;
					}
				}
			}
		}
		this.YqYyocwfLXbFaxpiROWQZGtThBlV = num;
		this.rvyHDDPfSVsxqRheuehnnXsLLtDe(num2, num, list, this.tKCCBxTaamCBbXZOJQZSBHAbNZiC);
		for (int k = 0; k < num; k++)
		{
			if (this._UpdateControllerInfoEvent != null)
			{
				this._UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(this.tKCCBxTaamCBbXZOJQZSBHAbNZiC[k]));
			}
		}
		list2.ForEach(new Action<CNVeZFjzzLebAIeziISIZlyPJSYp.YlqzBvZkVxRXSgZCOLBuUiBmFFIM>(this.yUFyEOHRAFAutDdHJiBiHEHClGkjb));
		this.cvhtYrOIvnrqKkdwgJdnhIyQnWHE(list, this.tKCCBxTaamCBbXZOJQZSBHAbNZiC, false);
		this.cvhtYrOIvnrqKkdwgJdnhIyQnWHE(this.tKCCBxTaamCBbXZOJQZSBHAbNZiC, list, true);
	}

	// Token: 0x06000104 RID: 260 RVA: 0x00023DFC File Offset: 0x00021FFC
	private void xAFzupPIKifBZHGLcxhHtesiDOamA()
	{
		for (int i = 0; i < this.YqYyocwfLXbFaxpiROWQZGtThBlV; i++)
		{
			CNVeZFjzzLebAIeziISIZlyPJSYp.YlqzBvZkVxRXSgZCOLBuUiBmFFIM ylqzBvZkVxRXSgZCOLBuUiBmFFIM = this.tKCCBxTaamCBbXZOJQZSBHAbNZiC[i];
			if (ylqzBvZkVxRXSgZCOLBuUiBmFFIM != null && (this.IvIVeyNCdGsTxwwBstcLtQkSboJS == null || !ylqzBvZkVxRXSgZCOLBuUiBmFFIM.tfIULvCtiOhsPgetTzSSyUpYrHwk))
			{
				ylqzBvZkVxRXSgZCOLBuUiBmFFIM.Update();
			}
		}
	}

	// Token: 0x06000105 RID: 261 RVA: 0x00023E40 File Offset: 0x00022040
	private bool jeJTKxbsnKvJORnyqYCaVZjlBLCM(MYlXCVOJEGnqGqWVYCnPgvbkMRIL A_1)
	{
		bool result;
		try
		{
			result = A_1.hWRaKJmiXGcUUsMmSXBNrKsyQuYi();
		}
		catch
		{
			result = false;
		}
		return result;
	}

	// Token: 0x06000106 RID: 262 RVA: 0x00011BEC File Offset: 0x0000FDEC
	private IList<zOVftvsFbTAvLzuhvSRGfBOXFlHHA> yTHsRccokqmHeajOuLsbIwquVBaK()
	{
		return this.xCWCOreulhlkYpnoEEnENjWmIpvFb.GetJoysticks<zOVftvsFbTAvLzuhvSRGfBOXFlHHA>();
	}

	// Token: 0x06000107 RID: 263 RVA: 0x00023E6C File Offset: 0x0002206C
	private void rvyHDDPfSVsxqRheuehnnXsLLtDe(int A_1, int A_2, List<CNVeZFjzzLebAIeziISIZlyPJSYp.YlqzBvZkVxRXSgZCOLBuUiBmFFIM> A_3, List<CNVeZFjzzLebAIeziISIZlyPJSYp.YlqzBvZkVxRXSgZCOLBuUiBmFFIM> A_4)
	{
		if (A_2 > 0)
		{
			A_4.Sort(new Comparison<CNVeZFjzzLebAIeziISIZlyPJSYp.YlqzBvZkVxRXSgZCOLBuUiBmFFIM>(CNVeZFjzzLebAIeziISIZlyPJSYp.YlqzBvZkVxRXSgZCOLBuUiBmFFIM.bkYLGsdPGEOteuchIFWbQRygeXN));
		}
		if (A_1 > 0 && A_2 > 0)
		{
			this.hPahbcSmahmcBRolDHcxLsivOawk(A_2, A_4, A_1, A_3, CNVeZFjzzLebAIeziISIZlyPJSYp.sJcDUhDYViyFPlCVdxFJkCszZdoqA.SznNvkhvjTrrYhKjdqZaFllieRnA.Exact);
		}
		this.rFuRaUPMFrKAwaXdkBNuVmZpvaUv(A_2, A_4, CNVeZFjzzLebAIeziISIZlyPJSYp.sJcDUhDYViyFPlCVdxFJkCszZdoqA.SznNvkhvjTrrYhKjdqZaFllieRnA.Exact);
		for (int i = 0; i < A_2; i++)
		{
			CNVeZFjzzLebAIeziISIZlyPJSYp.YlqzBvZkVxRXSgZCOLBuUiBmFFIM ylqzBvZkVxRXSgZCOLBuUiBmFFIM = A_4[i];
			if (ylqzBvZkVxRXSgZCOLBuUiBmFFIM != null && ylqzBvZkVxRXSgZCOLBuUiBmFFIM.inputManagerId < 0)
			{
				ylqzBvZkVxRXSgZCOLBuUiBmFFIM.inputManagerId = this.xLMgMmHHTctLrnhnVZRrCjFaQtUXA(A_4);
				ylqzBvZkVxRXSgZCOLBuUiBmFFIM.rewiredId = this.LFfbRgBFGLRgpTuoUJAxTByfLshF();
				this.VWXDDHKiCSGzwoucGYwHCmEBGSTXA.UehIqXiQxFXUIaYstQeQESpecyoDb(ylqzBvZkVxRXSgZCOLBuUiBmFFIM);
			}
		}
		A_4.Sort(new Comparison<CNVeZFjzzLebAIeziISIZlyPJSYp.YlqzBvZkVxRXSgZCOLBuUiBmFFIM>(CNVeZFjzzLebAIeziISIZlyPJSYp.YlqzBvZkVxRXSgZCOLBuUiBmFFIM.wtjZUNUzfZgNVzvhLPrpFPjjlErr));
	}

	// Token: 0x06000108 RID: 264 RVA: 0x00023F14 File Offset: 0x00022114
	private void lUBOXunwlAdFwmVqPPkaTTPhMwvC(List<CNVeZFjzzLebAIeziISIZlyPJSYp.YlqzBvZkVxRXSgZCOLBuUiBmFFIM> A_1, int A_2, int A_3)
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

	// Token: 0x06000109 RID: 265 RVA: 0x00023F60 File Offset: 0x00022160
	private bool gBzrxYannCmUpAkmMzZhHJrUYQkB(List<CNVeZFjzzLebAIeziISIZlyPJSYp.YlqzBvZkVxRXSgZCOLBuUiBmFFIM> A_1, int A_2)
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

	// Token: 0x0600010A RID: 266 RVA: 0x00023F9C File Offset: 0x0002219C
	private int xLMgMmHHTctLrnhnVZRrCjFaQtUXA(List<CNVeZFjzzLebAIeziISIZlyPJSYp.YlqzBvZkVxRXSgZCOLBuUiBmFFIM> A_1)
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

	// Token: 0x0600010B RID: 267 RVA: 0x00023FE8 File Offset: 0x000221E8
	private bool JiImcFUrVjCgEbujozOPvdNOHnPAA(List<CNVeZFjzzLebAIeziISIZlyPJSYp.YlqzBvZkVxRXSgZCOLBuUiBmFFIM> A_1, int A_2)
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

	// Token: 0x0600010C RID: 268 RVA: 0x00024020 File Offset: 0x00022220
	private void hPahbcSmahmcBRolDHcxLsivOawk(int A_1, List<CNVeZFjzzLebAIeziISIZlyPJSYp.YlqzBvZkVxRXSgZCOLBuUiBmFFIM> A_2, int A_3, List<CNVeZFjzzLebAIeziISIZlyPJSYp.YlqzBvZkVxRXSgZCOLBuUiBmFFIM> A_4, CNVeZFjzzLebAIeziISIZlyPJSYp.sJcDUhDYViyFPlCVdxFJkCszZdoqA.SznNvkhvjTrrYhKjdqZaFllieRnA A_5)
	{
		int num = (A_5 == CNVeZFjzzLebAIeziISIZlyPJSYp.sJcDUhDYViyFPlCVdxFJkCszZdoqA.SznNvkhvjTrrYhKjdqZaFllieRnA.Exact) ? 2 : 1;
		for (int i = 0; i < A_1; i++)
		{
			CNVeZFjzzLebAIeziISIZlyPJSYp.YlqzBvZkVxRXSgZCOLBuUiBmFFIM ylqzBvZkVxRXSgZCOLBuUiBmFFIM = A_2[i];
			if (ylqzBvZkVxRXSgZCOLBuUiBmFFIM != null && ylqzBvZkVxRXSgZCOLBuUiBmFFIM.inputManagerId < 0)
			{
				for (int j = 0; j < A_3; j++)
				{
					CNVeZFjzzLebAIeziISIZlyPJSYp.YlqzBvZkVxRXSgZCOLBuUiBmFFIM ylqzBvZkVxRXSgZCOLBuUiBmFFIM2 = A_4[j];
					if (ylqzBvZkVxRXSgZCOLBuUiBmFFIM2 != null && !this.JiImcFUrVjCgEbujozOPvdNOHnPAA(A_2, ylqzBvZkVxRXSgZCOLBuUiBmFFIM2.rewiredId) && ylqzBvZkVxRXSgZCOLBuUiBmFFIM.XRyUumpdKIiRuBDVccOSPxgqChHw(ylqzBvZkVxRXSgZCOLBuUiBmFFIM2) >= num)
					{
						ylqzBvZkVxRXSgZCOLBuUiBmFFIM.UVpRxUWQWrApRzbKtCFxuEokgGdjA(ylqzBvZkVxRXSgZCOLBuUiBmFFIM2);
						this.VWXDDHKiCSGzwoucGYwHCmEBGSTXA.UehIqXiQxFXUIaYstQeQESpecyoDb(ylqzBvZkVxRXSgZCOLBuUiBmFFIM);
					}
				}
			}
		}
	}

	// Token: 0x0600010D RID: 269 RVA: 0x000240A0 File Offset: 0x000222A0
	private void rFuRaUPMFrKAwaXdkBNuVmZpvaUv(int A_1, List<CNVeZFjzzLebAIeziISIZlyPJSYp.YlqzBvZkVxRXSgZCOLBuUiBmFFIM> A_2, CNVeZFjzzLebAIeziISIZlyPJSYp.sJcDUhDYViyFPlCVdxFJkCszZdoqA.SznNvkhvjTrrYhKjdqZaFllieRnA A_3)
	{
		for (int i = 0; i < A_1; i++)
		{
			CNVeZFjzzLebAIeziISIZlyPJSYp.YlqzBvZkVxRXSgZCOLBuUiBmFFIM ylqzBvZkVxRXSgZCOLBuUiBmFFIM = A_2[i];
			if (ylqzBvZkVxRXSgZCOLBuUiBmFFIM != null && ylqzBvZkVxRXSgZCOLBuUiBmFFIM.inputManagerId < 0)
			{
				CNVeZFjzzLebAIeziISIZlyPJSYp.sJcDUhDYViyFPlCVdxFJkCszZdoqA.EGyRyrzWcMoiSzWsyNQnyPbwmdpm egyRyrzWcMoiSzWsyNQnyPbwmdpm = null;
				foreach (CNVeZFjzzLebAIeziISIZlyPJSYp.sJcDUhDYViyFPlCVdxFJkCszZdoqA.EGyRyrzWcMoiSzWsyNQnyPbwmdpm egyRyrzWcMoiSzWsyNQnyPbwmdpm2 in this.VWXDDHKiCSGzwoucGYwHCmEBGSTXA.XISescxkKLUUpaFKmNqSKJysdIzo(ylqzBvZkVxRXSgZCOLBuUiBmFFIM, A_3))
				{
					if (!this.JiImcFUrVjCgEbujozOPvdNOHnPAA(A_2, egyRyrzWcMoiSzWsyNQnyPbwmdpm2.nquOcgYNFeFcZENGQiQUZoWhnrcBA) && egyRyrzWcMoiSzWsyNQnyPbwmdpm2.ZrXYuEaKvtgwxBXjkmNRFiZaifRo >= 0)
					{
						egyRyrzWcMoiSzWsyNQnyPbwmdpm = egyRyrzWcMoiSzWsyNQnyPbwmdpm2;
						break;
					}
				}
				if (egyRyrzWcMoiSzWsyNQnyPbwmdpm != null)
				{
					int num = egyRyrzWcMoiSzWsyNQnyPbwmdpm.ZrXYuEaKvtgwxBXjkmNRFiZaifRo;
					if (!this.gBzrxYannCmUpAkmMzZhHJrUYQkB(A_2, num))
					{
						num = this.xLMgMmHHTctLrnhnVZRrCjFaQtUXA(A_2);
						egyRyrzWcMoiSzWsyNQnyPbwmdpm.ZrXYuEaKvtgwxBXjkmNRFiZaifRo = num;
					}
					ylqzBvZkVxRXSgZCOLBuUiBmFFIM.inputManagerId = num;
					ylqzBvZkVxRXSgZCOLBuUiBmFFIM.rewiredId = egyRyrzWcMoiSzWsyNQnyPbwmdpm.nquOcgYNFeFcZENGQiQUZoWhnrcBA;
					this.VWXDDHKiCSGzwoucGYwHCmEBGSTXA.UehIqXiQxFXUIaYstQeQESpecyoDb(ylqzBvZkVxRXSgZCOLBuUiBmFFIM);
				}
			}
		}
	}

	// Token: 0x0600010E RID: 270 RVA: 0x00024184 File Offset: 0x00022384
	private void FDVjqgofmTVpXxGjRnYPXpuPakdV()
	{
		if (this.xCWCOreulhlkYpnoEEnENjWmIpvFb.wJwRcfyujDrZJxaKmFmuXjHvYsoJ(true))
		{
			this.uIoJgihGQYcdBfNDTtaErQaOlTKOA = true;
		}
		if (this.uIoJgihGQYcdBfNDTtaErQaOlTKOA)
		{
			this.qjHdZhVSebyhsSKZGBUKQhZXEOCBA();
		}
		if ((this.mWxENYiEREDzNbTnHpHcKrOZAcCLB || this.xCWCOreulhlkYpnoEEnENjWmIpvFb.PCIejCVVtKDeaxdrPCqsOfGdCdPJ) && this.JsbgKZzOPiQSixJMAqRYUtGirbyu.dEuWrWEuMuRLEfvelqBlJqCXPzLm && this.JsbgKZzOPiQSixJMAqRYUtGirbyu.tyWUOmZxIPUWAGNTSMzHnebuMTZT())
		{
			this.JoRhjgxoQWTNdgbWIWEyGpbLEnMDA();
		}
	}

	// Token: 0x0600010F RID: 271 RVA: 0x00011BF9 File Offset: 0x0000FDF9
	private void qjHdZhVSebyhsSKZGBUKQhZXEOCBA()
	{
		this.uIoJgihGQYcdBfNDTtaErQaOlTKOA = false;
		if (this.JsbgKZzOPiQSixJMAqRYUtGirbyu.dEuWrWEuMuRLEfvelqBlJqCXPzLm)
		{
			return;
		}
		this.xCWCOreulhlkYpnoEEnENjWmIpvFb.cisLLsPknlzYWHJEisFvDueNlFWV();
		this.JsbgKZzOPiQSixJMAqRYUtGirbyu.VlWTpnOmouJNHovmWjtCiEYLYIbj();
	}

	// Token: 0x06000110 RID: 272 RVA: 0x000241EC File Offset: 0x000223EC
	private void JoRhjgxoQWTNdgbWIWEyGpbLEnMDA()
	{
		this.xCWCOreulhlkYpnoEEnENjWmIpvFb.VStpYFXpbmfvmwqthSuVyFwxYXgD();
		if (this.mWxENYiEREDzNbTnHpHcKrOZAcCLB)
		{
			IList<zOVftvsFbTAvLzuhvSRGfBOXFlHHA> list = this.yTHsRccokqmHeajOuLsbIwquVBaK();
			if (this.fNxEongCdvQnacKGPqwrBpqsDEOdA(list))
			{
				this.JePIPGLGiSWYTsOFthcLKBQRjyZV(list);
			}
		}
	}

	// Token: 0x06000111 RID: 273 RVA: 0x00024224 File Offset: 0x00022424
	private bool fNxEongCdvQnacKGPqwrBpqsDEOdA(IList<zOVftvsFbTAvLzuhvSRGfBOXFlHHA> A_1)
	{
		for (int i = 0; i < this.tKCCBxTaamCBbXZOJQZSBHAbNZiC.Count; i++)
		{
			if (this.tKCCBxTaamCBbXZOJQZSBHAbNZiC[i] != null && !this.tKCCBxTaamCBbXZOJQZSBHAbNZiC[i].hheXvMPJReEDDkQNDnTCFurdNdeCA)
			{
				return true;
			}
		}
		int count = A_1.Count;
		for (int j = 0; j < count; j++)
		{
			if (A_1[j] != null && !this.vOuoKAICqnVBBNGMuENDOGzdhtLDA(A_1[j].GNTLZGZMYteNfQShJMHVqmWwrOKR))
			{
				return true;
			}
		}
		int count2 = this.tKCCBxTaamCBbXZOJQZSBHAbNZiC.Count;
		for (int k = 0; k < count2; k++)
		{
			if (this.tKCCBxTaamCBbXZOJQZSBHAbNZiC[k] != null && !this.xKWwIJjrqtmjkWGohNExybJkengw(A_1, this.tKCCBxTaamCBbXZOJQZSBHAbNZiC[k].instanceGuid))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000112 RID: 274 RVA: 0x000242E8 File Offset: 0x000224E8
	private bool vOuoKAICqnVBBNGMuENDOGzdhtLDA(Guid A_1)
	{
		int count = this.tKCCBxTaamCBbXZOJQZSBHAbNZiC.Count;
		for (int i = 0; i < count; i++)
		{
			if (this.tKCCBxTaamCBbXZOJQZSBHAbNZiC[i] != null && this.tKCCBxTaamCBbXZOJQZSBHAbNZiC[i].instanceGuid == A_1)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000113 RID: 275 RVA: 0x00024338 File Offset: 0x00022538
	private bool xKWwIJjrqtmjkWGohNExybJkengw(IList<zOVftvsFbTAvLzuhvSRGfBOXFlHHA> A_1, Guid A_2)
	{
		int count = A_1.Count;
		for (int i = 0; i < count; i++)
		{
			if (A_1[i] != null && A_1[i].GNTLZGZMYteNfQShJMHVqmWwrOKR == A_2)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000114 RID: 276 RVA: 0x00024378 File Offset: 0x00022578
	private void cvhtYrOIvnrqKkdwgJdnhIyQnWHE(List<CNVeZFjzzLebAIeziISIZlyPJSYp.YlqzBvZkVxRXSgZCOLBuUiBmFFIM> A_1, List<CNVeZFjzzLebAIeziISIZlyPJSYp.YlqzBvZkVxRXSgZCOLBuUiBmFFIM> A_2, bool A_3)
	{
		if (A_1 == null)
		{
			return;
		}
		int num = (A_1 != null) ? A_1.Count : 0;
		int num2 = (A_2 != null) ? A_2.Count : 0;
		for (int i = 0; i < num; i++)
		{
			CNVeZFjzzLebAIeziISIZlyPJSYp.YlqzBvZkVxRXSgZCOLBuUiBmFFIM ylqzBvZkVxRXSgZCOLBuUiBmFFIM = A_1[i];
			if (ylqzBvZkVxRXSgZCOLBuUiBmFFIM != null)
			{
				bool flag = false;
				if (A_2 != null)
				{
					for (int j = 0; j < num2; j++)
					{
						CNVeZFjzzLebAIeziISIZlyPJSYp.YlqzBvZkVxRXSgZCOLBuUiBmFFIM ylqzBvZkVxRXSgZCOLBuUiBmFFIM2 = A_2[j];
						if (ylqzBvZkVxRXSgZCOLBuUiBmFFIM2 != null && ylqzBvZkVxRXSgZCOLBuUiBmFFIM.instanceGuid == ylqzBvZkVxRXSgZCOLBuUiBmFFIM2.instanceGuid)
						{
							flag = true;
							break;
						}
					}
				}
				if (!flag)
				{
					this.MiQkgSpMxSGCVpDAtakTAiMACgRl(A_1[i], A_3);
				}
			}
		}
	}

	// Token: 0x06000115 RID: 277 RVA: 0x00011C27 File Offset: 0x0000FE27
	private void MiQkgSpMxSGCVpDAtakTAiMACgRl(CNVeZFjzzLebAIeziISIZlyPJSYp.YlqzBvZkVxRXSgZCOLBuUiBmFFIM A_1, bool A_2)
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

	// Token: 0x06000116 RID: 278 RVA: 0x0002440C File Offset: 0x0002260C
	private bool XEpuOMiMXSadodgtdfSbxKXCnyrZA()
	{
		try
		{
			int num = 0;
			xSOZMZyIgwUNJGxbaunJqIAqJnsT.psJwxiCIocrPdCpOCaoSqamOIZYB(null, ref num, HtGHfzvtpMNSxwkJwcWlhmdnZCmfA.OtegDtkLmarAmSgMcuCzwfGeriInA<IHjknSfzmxAOaKWaYMMNiIArARUq>());
			if (this.BwYlEoHkaZbDCKUZfiIOcTwWEUpfb != num)
			{
				this.BwYlEoHkaZbDCKUZfiIOcTwWEUpfb = num;
				return true;
			}
		}
		catch (Exception ex)
		{
			string str = "Exception getting Raw Input Device List.\n";
			Exception ex2 = ex;
			Logger.Log(str + ((ex2 != null) ? ex2.ToString() : null));
		}
		return this.XvazNTgILJbqsufnqINpiHDJJFopA > 0 && this.xCWCOreulhlkYpnoEEnENjWmIpvFb.LzAxMPcGXOwLzebwXNqQTFHmHZNgA();
	}

	// Token: 0x06000117 RID: 279 RVA: 0x000117B7 File Offset: 0x0000F9B7
	[Conditional("DEBUGTHIS")]
	private void EIYKCOqMzeaLGlETCYyfmYGUWvmI(string A_1)
	{
		Logger.Log(A_1);
	}

	// Token: 0x06000118 RID: 280 RVA: 0x00011C5F File Offset: 0x0000FE5F
	[CompilerGenerated]
	private void yUFyEOHRAFAutDdHJiBiHEHClGkjb(CNVeZFjzzLebAIeziISIZlyPJSYp.YlqzBvZkVxRXSgZCOLBuUiBmFFIM A_1)
	{
		this.MiQkgSpMxSGCVpDAtakTAiMACgRl(A_1, false);
	}

	// Token: 0x040000CD RID: 205
	private wOInxLKDewlatLvQaXlNWuUFKXeD xCWCOreulhlkYpnoEEnENjWmIpvFb;

	// Token: 0x040000CE RID: 206
	private List<CNVeZFjzzLebAIeziISIZlyPJSYp.YlqzBvZkVxRXSgZCOLBuUiBmFFIM> tKCCBxTaamCBbXZOJQZSBHAbNZiC;

	// Token: 0x040000CF RID: 207
	private int YqYyocwfLXbFaxpiROWQZGtThBlV;

	// Token: 0x040000D0 RID: 208
	private CNVeZFjzzLebAIeziISIZlyPJSYp.sJcDUhDYViyFPlCVdxFJkCszZdoqA VWXDDHKiCSGzwoucGYwHCmEBGSTXA;

	// Token: 0x040000D1 RID: 209
	private bool uIoJgihGQYcdBfNDTtaErQaOlTKOA;

	// Token: 0x040000D2 RID: 210
	private TimerRealTime RLgWaYTpxYpscDYaNvpFnRfbwmIv;

	// Token: 0x040000D3 RID: 211
	private UHsWCAvrjUBCvVSiOhWZLujgvmAM<bool> PltCtvHTiBvYCgfuWMWqRCRHFAOgA;

	// Token: 0x040000D4 RID: 212
	private UHsWCAvrjUBCvVSiOhWZLujgvmAM<bool> JsbgKZzOPiQSixJMAqRYUtGirbyu;

	// Token: 0x040000D5 RID: 213
	private int XvazNTgILJbqsufnqINpiHDJJFopA;

	// Token: 0x040000D6 RID: 214
	private int BwYlEoHkaZbDCKUZfiIOcTwWEUpfb;

	// Token: 0x040000D7 RID: 215
	private ConfigVars aXEjebxGLwyXmDCYNFJRDHYEvPAv;

	// Token: 0x040000D8 RID: 216
	private xKKbjmIOHiqxZGRJDfbeyLuvTjMwB IvIVeyNCdGsTxwwBstcLtQkSboJS;

	// Token: 0x040000D9 RID: 217
	private Action<int, ControllerDataUpdater> zqXWauNWQnMnHoPuaoZWlcUHjYEw;

	// Token: 0x040000DA RID: 218
	private PlatformInputManager jNWUoElfaOEdEbRAjqoeQgQVjOsJA;

	// Token: 0x040000DB RID: 219
	private readonly FdQbBsfCWcVHOnPrmheJzorKWKWz cPzcFCKmQHIlcFRtfAZjoAWJNMBPB;

	// Token: 0x040000DC RID: 220
	private readonly LEiRbylTDtVrpnaZskyeFoLSqqLb uIKfnpBYHczxRqmFAGQMJrCWAhNTA;

	// Token: 0x040000DD RID: 221
	private readonly bool mWxENYiEREDzNbTnHpHcKrOZAcCLB;

	// Token: 0x040000DE RID: 222
	private readonly bool DwEmDXbRoPJkbOyBvCSvxbRDmuLf;

	// Token: 0x040000DF RID: 223
	private readonly bool INjOOzuoZOdTGHhFshEekuGDiyCY;

	// Token: 0x040000E0 RID: 224
	private readonly Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> bDMigIRDcAKGTfXixCswIKbReWqn;

	// Token: 0x040000E1 RID: 225
	private readonly Func<int> LFfbRgBFGLRgpTuoUJAxTByfLshF;

	// Token: 0x0200001A RID: 26
	private class YlqzBvZkVxRXSgZCOLBuUiBmFFIM : IInputManagerJoystick, IInputManagerJoystickPublic
	{
		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000119 RID: 281 RVA: 0x00011C69 File Offset: 0x0000FE69
		public bool HPMNuIotKTVbszXPNIKjUijNaqyF
		{
			get
			{
				return this.nzTdsQfHNPwqClyQJkPHJfysmuTc != null && this.nzTdsQfHNPwqClyQJkPHJfysmuTc.tyAiqnJTfiEhtdOAyaqGhYQnJKbU != null;
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x0600011A RID: 282 RVA: 0x00011C83 File Offset: 0x0000FE83
		// (set) Token: 0x0600011B RID: 283 RVA: 0x00011C8B File Offset: 0x0000FE8B
		[CustomObfuscation(rename = false)]
		public int rewiredId
		{
			get
			{
				return this.CIdVIJgfTRXfTUaWOlZQdAeGJCmN;
			}
			set
			{
				this.CIdVIJgfTRXfTUaWOlZQdAeGJCmN = value;
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x0600011C RID: 284 RVA: 0x00011C94 File Offset: 0x0000FE94
		// (set) Token: 0x0600011D RID: 285 RVA: 0x00011C9C File Offset: 0x0000FE9C
		[CustomObfuscation(rename = false)]
		public int inputManagerId
		{
			get
			{
				return this.wJApJdVamolSnIDPmDihhGobOsYl;
			}
			set
			{
				this.wJApJdVamolSnIDPmDihhGobOsYl = value;
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x0600011E RID: 286 RVA: 0x00011CA5 File Offset: 0x0000FEA5
		[CustomObfuscation(rename = false)]
		public string name
		{
			get
			{
				if (this.pgWfNDrKWBxQjVnXBdatvWXBylwN != "Unknown Controller")
				{
					return this.pgWfNDrKWBxQjVnXBdatvWXBylwN;
				}
				if (this.xErTcVOYeKhcFudMIFTpJhEtUuErA && !string.IsNullOrEmpty(this.oQmVFwwpSVhQckqpMqdbpcgAmsdT))
				{
					return this.oQmVFwwpSVhQckqpMqdbpcgAmsdT;
				}
				return this.RbShfEhwCDRxlQlnNIgzAabGofUo;
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x0600011F RID: 287 RVA: 0x0002448C File Offset: 0x0002268C
		[CustomObfuscation(rename = false)]
		public long? systemId
		{
			get
			{
				if (this.wJApJdVamolSnIDPmDihhGobOsYl < 0)
				{
					return null;
				}
				return new long?((long)this.wJApJdVamolSnIDPmDihhGobOsYl);
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000120 RID: 288 RVA: 0x00011826 File Offset: 0x0000FA26
		[CustomObfuscation(rename = false)]
		public int unityId
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000121 RID: 289 RVA: 0x00011CE2 File Offset: 0x0000FEE2
		// (set) Token: 0x06000122 RID: 290 RVA: 0x00011CEA File Offset: 0x0000FEEA
		[CustomObfuscation(rename = false)]
		public Controller.Extension extension { get; set; }

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000123 RID: 291 RVA: 0x00011CF3 File Offset: 0x0000FEF3
		[CustomObfuscation(rename = false)]
		public Guid instanceGuid
		{
			get
			{
				return this.QZpBuNCZbrXOBPeZIsKLkqnEiYCM;
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000124 RID: 292 RVA: 0x00011CFB File Offset: 0x0000FEFB
		[CustomObfuscation(rename = false)]
		public Guid persistentGuid
		{
			get
			{
				return this.instanceGuid;
			}
		}

		// Token: 0x06000125 RID: 293 RVA: 0x00011D03 File Offset: 0x0000FF03
		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
			this.hheXvMPJReEDDkQNDnTCFurdNdeCA;
		}

		// Token: 0x06000126 RID: 294 RVA: 0x00011D03 File Offset: 0x0000FF03
		[CustomObfuscation(rename = false)]
		public void StopVibration()
		{
			this.hheXvMPJReEDDkQNDnTCFurdNdeCA;
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000127 RID: 295 RVA: 0x00011D0C File Offset: 0x0000FF0C
		public bool hheXvMPJReEDDkQNDnTCFurdNdeCA
		{
			get
			{
				return !this.ehVmIMPwjcaYheiaBSJEWepGgUxaA && this.nzTdsQfHNPwqClyQJkPHJfysmuTc != null && this.nzTdsQfHNPwqClyQJkPHJfysmuTc.hOycTUkWgTXLaImoBKxNxTkDBjoDb;
			}
		}

		// Token: 0x06000128 RID: 296 RVA: 0x00011D2B File Offset: 0x0000FF2B
		public YlqzBvZkVxRXSgZCOLBuUiBmFFIM(zOVftvsFbTAvLzuhvSRGfBOXFlHHA A_1, DeviceType A_2, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> A_3)
		{
			this.nzTdsQfHNPwqClyQJkPHJfysmuTc = A_1;
			this.JFABfyJzvFeNKttBEbBVEoiYAuNZ = A_2;
			this.jGNYHPjRXjLiLsJxwQfxFUYrJYyp = A_3;
			this.wJApJdVamolSnIDPmDihhGobOsYl = -1;
			this.CIdVIJgfTRXfTUaWOlZQdAeGJCmN = -1;
		}

		// Token: 0x06000129 RID: 297 RVA: 0x000244B8 File Offset: 0x000226B8
		public void HFXMXcLisBqGOiqwkbYEQTEpbsPCA()
		{
			if (!this.hheXvMPJReEDDkQNDnTCFurdNdeCA)
			{
				return;
			}
			string str = (!string.IsNullOrEmpty(this.oQmVFwwpSVhQckqpMqdbpcgAmsdT)) ? this.oQmVFwwpSVhQckqpMqdbpcgAmsdT : this.RbShfEhwCDRxlQlnNIgzAabGofUo;
			Guid guid = this.aGYEhbcpcAvttFkyNSFMAWobsbmTA;
			this.cKMfLUfONERXypnGOOCUbyKpeIdTA = MiscTools.CreateGuidHashSHA1(str + guid.ToString());
			this.frYuFrxbYOpWDQlobHCxJlqfpyyF = this.IfQidsDjnCqPQAXhaXLmDYreQIfrd;
			this.bOjutFXzYOCnmKEhhaetGQOxbwiZ = this.haYkWADMIUsnuaWoAcnigKCbcsTj + this.pSNZLlcfOykgkwKOKvuJRJpNDvM * 8;
			this.dqJRbvajtZbusTsKxzWZAHQKfYAh();
			this.rcuyASDyaTwSDfmktUCNYIgjCZUaA = this.lvfqsNmNNullempSBzESOfQOBdoO.hardwareMapIdentifier.guid;
			this.pgWfNDrKWBxQjVnXBdatvWXBylwN = this.lvfqsNmNNullempSBzESOfQOBdoO.controllerName;
			this.HlHxlMwJJcyECoCzMOyVSbhrmqXx = (this.rcuyASDyaTwSDfmktUCNYIgjCZUaA == Guid.Empty);
			this.LayqWGfBOKMwtJsqsiZmmMXVuzu = new float[this.frYuFrxbYOpWDQlobHCxJlqfpyyF];
			this.BalfGvZjQzufvZzyBQBuxJhcjhSh = new float[this.bOjutFXzYOCnmKEhhaetGQOxbwiZ];
			this.QbiOwowjVGKqTXLmgDwSiluPlSYL = new bool[this.bOjutFXzYOCnmKEhhaetGQOxbwiZ];
			if (this.lvfqsNmNNullempSBzESOfQOBdoO != null && this.bOjutFXzYOCnmKEhhaetGQOxbwiZ > 0)
			{
				InputPlatform platform = this.lvfqsNmNNullempSBzESOfQOBdoO.map.platform;
				if (platform == InputPlatform.WindowsRawInput)
				{
					HardwareJoystickMap.Platform_RawInput_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_RawInput_Base)this.lvfqsNmNNullempSBzESOfQOBdoO.map).Buttons_orig;
					if (buttons_orig != null)
					{
						for (int i = 0; i < buttons_orig.Length; i++)
						{
							this.QbiOwowjVGKqTXLmgDwSiluPlSYL[i] = buttons_orig[i].buttonInfo.isPressureSensitive;
						}
					}
				}
				else if (platform == InputPlatform.WindowsDirectInput)
				{
					HardwareJoystickMap.Platform_DirectInput_Base.Button[] buttons_orig2 = ((HardwareJoystickMap.Platform_DirectInput_Base)this.lvfqsNmNNullempSBzESOfQOBdoO.map).Buttons_orig;
					if (buttons_orig2 != null)
					{
						for (int j = 0; j < buttons_orig2.Length; j++)
						{
							this.QbiOwowjVGKqTXLmgDwSiluPlSYL[j] = buttons_orig2[j].buttonInfo.isPressureSensitive;
						}
					}
				}
			}
			this.HLZLGpJXUNbpdNbUvethdHaOftuA = this.nzTdsQfHNPwqClyQJkPHJfysmuTc.CjqyIMsBbXiZyfJCwEMIozoxkqNo;
			this.Update();
		}

		// Token: 0x0600012A RID: 298 RVA: 0x00024678 File Offset: 0x00022878
		public void UVpRxUWQWrApRzbKtCFxuEokgGdjA(CNVeZFjzzLebAIeziISIZlyPJSYp.YlqzBvZkVxRXSgZCOLBuUiBmFFIM A_1)
		{
			if (!this.hheXvMPJReEDDkQNDnTCFurdNdeCA)
			{
				return;
			}
			if (A_1 == null)
			{
				return;
			}
			this.wJApJdVamolSnIDPmDihhGobOsYl = A_1.wJApJdVamolSnIDPmDihhGobOsYl;
			this.CIdVIJgfTRXfTUaWOlZQdAeGJCmN = A_1.CIdVIJgfTRXfTUaWOlZQdAeGJCmN;
			for (int i = 0; i < MathTools.Min(this.BalfGvZjQzufvZzyBQBuxJhcjhSh.Length, A_1.BalfGvZjQzufvZzyBQBuxJhcjhSh.Length); i++)
			{
				this.BalfGvZjQzufvZzyBQBuxJhcjhSh[i] = A_1.BalfGvZjQzufvZzyBQBuxJhcjhSh[i];
			}
			for (int j = 0; j < MathTools.Min(this.QbiOwowjVGKqTXLmgDwSiluPlSYL.Length, A_1.QbiOwowjVGKqTXLmgDwSiluPlSYL.Length); j++)
			{
				this.QbiOwowjVGKqTXLmgDwSiluPlSYL[j] = A_1.QbiOwowjVGKqTXLmgDwSiluPlSYL[j];
			}
			for (int k = 0; k < MathTools.Min(this.LayqWGfBOKMwtJsqsiZmmMXVuzu.Length, A_1.LayqWGfBOKMwtJsqsiZmmMXVuzu.Length); k++)
			{
				this.LayqWGfBOKMwtJsqsiZmmMXVuzu[k] = A_1.LayqWGfBOKMwtJsqsiZmmMXVuzu[k];
			}
			this.gXnlJydNdeiHCeFStJTxdJzTvDrI = A_1.gXnlJydNdeiHCeFStJTxdJzTvDrI;
		}

		// Token: 0x0600012B RID: 299 RVA: 0x00024748 File Offset: 0x00022948
		[CustomObfuscation(rename = false)]
		public void Update()
		{
			if (!this.hheXvMPJReEDDkQNDnTCFurdNdeCA)
			{
				return;
			}
			bool[] array = this.nzTdsQfHNPwqClyQJkPHJfysmuTc.SBIpSMfhMbXHumLUWAoDaLzlfPgb;
			int[] array2 = this.nzTdsQfHNPwqClyQJkPHJfysmuTc.ZezovXXwJbxiiihgGbekVKdzZEpH;
			this.tWpWSLzFSUFplDtHxgDMAjWJwwIiB(array, array2);
			this.eznDQVcPkzJsdahPDPSwkrCDfueOD(array, array2);
		}

		// Token: 0x0600012C RID: 300 RVA: 0x00024788 File Offset: 0x00022988
		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (!this.hheXvMPJReEDDkQNDnTCFurdNdeCA)
			{
				return;
			}
			if (this.frYuFrxbYOpWDQlobHCxJlqfpyyF != dataUpdater.axisCount || this.bOjutFXzYOCnmKEhhaetGQOxbwiZ != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			for (int i = 0; i < this.frYuFrxbYOpWDQlobHCxJlqfpyyF; i++)
			{
				dataUpdater.axisValues[i] = this.LayqWGfBOKMwtJsqsiZmmMXVuzu[i];
			}
			for (int j = 0; j < this.bOjutFXzYOCnmKEhhaetGQOxbwiZ; j++)
			{
				if (this.QbiOwowjVGKqTXLmgDwSiluPlSYL[j])
				{
					dataUpdater.buttonPressureValues[j] = this.BalfGvZjQzufvZzyBQBuxJhcjhSh[j];
				}
				else
				{
					dataUpdater.buttonValues[j] = ((this.BalfGvZjQzufvZzyBQBuxJhcjhSh[j] > 0f) ? true : false);
				}
			}
			if (this.gXnlJydNdeiHCeFStJTxdJzTvDrI && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		// Token: 0x0600012D RID: 301 RVA: 0x00024848 File Offset: 0x00022A48
		public int XRyUumpdKIiRuBDVccOSPxgqChHw(CNVeZFjzzLebAIeziISIZlyPJSYp.YlqzBvZkVxRXSgZCOLBuUiBmFFIM A_1)
		{
			if (!this.hheXvMPJReEDDkQNDnTCFurdNdeCA)
			{
				return 0;
			}
			if (A_1.CIdVIJgfTRXfTUaWOlZQdAeGJCmN == this.CIdVIJgfTRXfTUaWOlZQdAeGJCmN)
			{
				return 2;
			}
			if (this.IfQidsDjnCqPQAXhaXLmDYreQIfrd != A_1.IfQidsDjnCqPQAXhaXLmDYreQIfrd)
			{
				return 0;
			}
			if (this.haYkWADMIUsnuaWoAcnigKCbcsTj != A_1.haYkWADMIUsnuaWoAcnigKCbcsTj)
			{
				return 0;
			}
			if (this.pSNZLlcfOykgkwKOKvuJRJpNDvM != A_1.pSNZLlcfOykgkwKOKvuJRJpNDvM)
			{
				return 0;
			}
			if (this.HPMNuIotKTVbszXPNIKjUijNaqyF != A_1.HPMNuIotKTVbszXPNIKjUijNaqyF)
			{
				return 0;
			}
			if (A_1.instanceGuid == this.instanceGuid)
			{
				return 2;
			}
			if (A_1.cKMfLUfONERXypnGOOCUbyKpeIdTA == this.cKMfLUfONERXypnGOOCUbyKpeIdTA)
			{
				return 1;
			}
			return 0;
		}

		// Token: 0x0600012E RID: 302 RVA: 0x000248DC File Offset: 0x00022ADC
		private BridgedControllerHWInfo yWIorveQNFmnBzjNOSpYbqyLdFAh()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			this.QsYxktrAOQnFAeMgIDPUBxqJBCmk(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		// Token: 0x0600012F RID: 303 RVA: 0x000248F8 File Offset: 0x00022AF8
		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			if (!this.hheXvMPJReEDDkQNDnTCFurdNdeCA)
			{
				return null;
			}
			BridgedController bridgedController = new BridgedController();
			this.BpgaVXZwaKDbVBRCrGmxxcKmYhDW(bridgedController);
			return bridgedController;
		}

		// Token: 0x06000130 RID: 304 RVA: 0x00011D56 File Offset: 0x0000FF56
		[CustomObfuscation(rename = false)]
		public ControllerDisconnectedEventArgs ToControllerDisconnectedEventArgs()
		{
			return new ControllerDisconnectedEventArgs(this.CIdVIJgfTRXfTUaWOlZQdAeGJCmN);
		}

		// Token: 0x06000131 RID: 305 RVA: 0x00024920 File Offset: 0x00022B20
		private void tWpWSLzFSUFplDtHxgDMAjWJwwIiB(bool[] A_1, int[] A_2)
		{
			if (this.frYuFrxbYOpWDQlobHCxJlqfpyyF <= 0)
			{
				return;
			}
			InputPlatform platform = this.lvfqsNmNNullempSBzESOfQOBdoO.map.platform;
			if (platform == InputPlatform.WindowsRawInput)
			{
				HardwareJoystickMap.Platform_RawInput_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_RawInput_Base)this.lvfqsNmNNullempSBzESOfQOBdoO.map).Axes_orig;
				if (axes_orig == null)
				{
					return;
				}
				for (int i = 0; i < axes_orig.Length; i++)
				{
					this.dTBOQXBYDBcXMHaHDipmxxDHIFwCA(axes_orig[i], i, A_1, A_2);
				}
				return;
			}
			else if (platform == InputPlatform.WindowsDirectInput)
			{
				HardwareJoystickMap.Platform_DirectInput_Base.Axis[] axes_orig2 = ((HardwareJoystickMap.Platform_DirectInput_Base)this.lvfqsNmNNullempSBzESOfQOBdoO.map).Axes_orig;
				if (axes_orig2 == null)
				{
					return;
				}
				for (int j = 0; j < axes_orig2.Length; j++)
				{
					this.dTBOQXBYDBcXMHaHDipmxxDHIFwCA(axes_orig2[j], j, A_1, A_2);
				}
				return;
			}
			else
			{
				if (platform != InputPlatform.InternalDriver)
				{
					return;
				}
				HardwareJoystickMap.Platform_InternalDriver_Base.Axis[] axes_orig3 = ((HardwareJoystickMap.Platform_InternalDriver_Base)this.lvfqsNmNNullempSBzESOfQOBdoO.map).Axes_orig;
				if (axes_orig3 == null)
				{
					return;
				}
				for (int k = 0; k < axes_orig3.Length; k++)
				{
					this.PJJOtHxvzThzSIIlDDpmISTTXaz(axes_orig3[k], k, A_1, A_2);
				}
				return;
			}
		}

		// Token: 0x06000132 RID: 306 RVA: 0x00024A04 File Offset: 0x00022C04
		private void eznDQVcPkzJsdahPDPSwkrCDfueOD(bool[] A_1, int[] A_2)
		{
			if (this.bOjutFXzYOCnmKEhhaetGQOxbwiZ <= 0)
			{
				return;
			}
			InputPlatform platform = this.lvfqsNmNNullempSBzESOfQOBdoO.map.platform;
			if (platform == InputPlatform.WindowsRawInput)
			{
				HardwareJoystickMap.Platform_RawInput_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_RawInput_Base)this.lvfqsNmNNullempSBzESOfQOBdoO.map).Buttons_orig;
				if (buttons_orig == null)
				{
					return;
				}
				for (int i = 0; i < buttons_orig.Length; i++)
				{
					this.InFkUtQPaLvhDuUqfBrTsghOFZqD(buttons_orig[i], i, A_1, A_2);
				}
				return;
			}
			else if (platform == InputPlatform.WindowsDirectInput)
			{
				HardwareJoystickMap.Platform_DirectInput_Base.Button[] buttons_orig2 = ((HardwareJoystickMap.Platform_DirectInput_Base)this.lvfqsNmNNullempSBzESOfQOBdoO.map).Buttons_orig;
				if (buttons_orig2 == null)
				{
					return;
				}
				for (int j = 0; j < buttons_orig2.Length; j++)
				{
					this.InFkUtQPaLvhDuUqfBrTsghOFZqD(buttons_orig2[j], j, A_1, A_2);
				}
				return;
			}
			else
			{
				if (platform != InputPlatform.InternalDriver)
				{
					return;
				}
				HardwareJoystickMap.Platform_InternalDriver_Base.Button[] buttons_orig3 = ((HardwareJoystickMap.Platform_InternalDriver_Base)this.lvfqsNmNNullempSBzESOfQOBdoO.map).Buttons_orig;
				if (buttons_orig3 == null)
				{
					return;
				}
				for (int k = 0; k < buttons_orig3.Length; k++)
				{
					this.kFRjkzDEPzdQbQEevBBOypEGSgmr(buttons_orig3[k], k, A_1, A_2);
				}
				return;
			}
		}

		// Token: 0x06000133 RID: 307 RVA: 0x00024AE8 File Offset: 0x00022CE8
		private void dTBOQXBYDBcXMHaHDipmxxDHIFwCA(HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base A_1, int A_2, bool[] A_3, int[] A_4)
		{
			if (A_2 >= this.frYuFrxbYOpWDQlobHCxJlqfpyyF)
			{
				throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
			}
			this.LayqWGfBOKMwtJsqsiZmmMXVuzu[A_2] = this.yndOkScQWjcotmoRHBkFKGDrSRgr(A_1, A_3, A_4);
			if (!this.gXnlJydNdeiHCeFStJTxdJzTvDrI && this.LayqWGfBOKMwtJsqsiZmmMXVuzu[A_2] != 0f)
			{
				this.gXnlJydNdeiHCeFStJTxdJzTvDrI = true;
			}
		}

		// Token: 0x06000134 RID: 308 RVA: 0x00024B3C File Offset: 0x00022D3C
		private void InFkUtQPaLvhDuUqfBrTsghOFZqD(HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base A_1, int A_2, bool[] A_3, int[] A_4)
		{
			if (A_2 >= this.bOjutFXzYOCnmKEhhaetGQOxbwiZ)
			{
				throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
			}
			this.BalfGvZjQzufvZzyBQBuxJhcjhSh[A_2] = this.eQRAyOZTMjLgdeHDyGHsczOPmfedA(A_1, A_3, A_4);
			if (!this.gXnlJydNdeiHCeFStJTxdJzTvDrI && this.BalfGvZjQzufvZzyBQBuxJhcjhSh[A_2] != 0f)
			{
				this.gXnlJydNdeiHCeFStJTxdJzTvDrI = true;
			}
		}

		// Token: 0x06000135 RID: 309 RVA: 0x00024B90 File Offset: 0x00022D90
		private float yndOkScQWjcotmoRHBkFKGDrSRgr(HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base A_1, bool[] A_2, int[] A_3)
		{
			if (A_1.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				int sourceAxis = A_1.sourceAxis;
				if (sourceAxis == 0)
				{
					return 0f;
				}
				int num;
				if (sourceAxis >= 1 && sourceAxis <= 11)
				{
					num = 0;
				}
				else
				{
					if (sourceAxis != 1000)
					{
						return 0f;
					}
					HardwareJoystickMap.Platform_RawInput_Base.Axis axis = A_1 as HardwareJoystickMap.Platform_RawInput_Base.Axis;
					if (axis == null)
					{
						return 0f;
					}
					num = axis.sourceOtherAxis;
				}
				return this.YNoFyksPhHhvwiVduYCUvhKzjVJY((RawInputAxis)sourceAxis, num);
			}
			else if (A_1.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				int sourceButton = A_1.sourceButton;
				if (sourceButton < 0 || sourceButton >= this.haYkWADMIUsnuaWoAcnigKCbcsTj || sourceButton >= 256)
				{
					return 0f;
				}
				if (!A_2[sourceButton])
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
			else if (A_1.sourceType == HardwareElementSourceTypeWithHat.Hat)
			{
				int sourceHat = A_1.sourceHat;
				if (sourceHat < 0 || sourceHat >= this.pSNZLlcfOykgkwKOKvuJRJpNDvM || sourceHat >= 4)
				{
					return 0f;
				}
				int num2 = A_3[sourceHat];
				if (num2 < 0)
				{
					return 0f;
				}
				float num3;
				if (A_1.sourceHatDirection == AxisDirection.Horizontal)
				{
					num3 = this.LoLwIqtoifjyZyrLbJytedaKdjbl(num2, AxisDirection.Horizontal);
					if (A_1.sourceHatRange != AxisRange.Full)
					{
						if (A_1.sourceHatRange == AxisRange.Positive)
						{
							if (num3 < 0f)
							{
								return 0f;
							}
						}
						else if (num3 > 0f)
						{
							return 0f;
						}
					}
				}
				else
				{
					num3 = this.LoLwIqtoifjyZyrLbJytedaKdjbl(num2, AxisDirection.Vertical);
					if (A_1.sourceHatRange != AxisRange.Full)
					{
						if (A_1.sourceHatRange == AxisRange.Positive)
						{
							if (num3 < 0f)
							{
								return 0f;
							}
						}
						else if (num3 > 0f)
						{
							return 0f;
						}
					}
				}
				if (A_1.invert)
				{
					num3 *= -1f;
				}
				return num3;
			}
			else
			{
				if (A_1.sourceType != HardwareElementSourceTypeWithHat.Custom)
				{
					return 0f;
				}
				CustomCalculation customCalculation = A_1.customCalculation;
				if (customCalculation == null)
				{
					return 0f;
				}
				if (customCalculation.ResultType != TypeWrapper.DataType.Single)
				{
					return 0f;
				}
				HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData[] customCalculationSourceData = A_1.customCalculationSourceData;
				if (customCalculationSourceData == null)
				{
					return 0f;
				}
				for (int i = 0; i < customCalculationSourceData.Length; i++)
				{
					float item;
					if (customCalculationSourceData[i] != null && customCalculationSourceData[i].sourceType == 1 && this.gdkCPoUxMOopScCpHAaheiwaOWxtA(customCalculationSourceData[i], out item))
					{
						customCalculation.AddData(item);
					}
				}
				if (!customCalculation.Process())
				{
					return 0f;
				}
				if (customCalculation.Result.type != TypeWrapper.DataType.Single)
				{
					return 0f;
				}
				return customCalculation.Result;
			}
		}

		// Token: 0x06000136 RID: 310 RVA: 0x00011D63 File Offset: 0x0000FF63
		private float YNoFyksPhHhvwiVduYCUvhKzjVJY(RawInputAxis A_1, int A_2)
		{
			return this.uaxdkeYOtgySPiOuUSqdLPQUtqdL((this.HLZLGpJXUNbpdNbUvethdHaOftuA as IPSdCZFUYRXiSCWqVVaWtTkwblCIA).QjITHNilndtaIBZTPJBvqPhisJty(A_1, A_2));
		}

		// Token: 0x06000137 RID: 311 RVA: 0x00024DD4 File Offset: 0x00022FD4
		private float eQRAyOZTMjLgdeHDyGHsczOPmfedA(HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base A_1, bool[] A_2, int[] A_3)
		{
			if (A_1.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				if (A_1.ignoreIfButtonsActive)
				{
					for (int i = 0; i < A_1.ignoreIfButtonsActiveButtons.Length; i++)
					{
						if (A_2[A_1.ignoreIfButtonsActiveButtons[i]])
						{
							return 0f;
						}
					}
				}
				if (A_1.requireMultipleButtons)
				{
					bool flag = false;
					for (int j = 0; j < A_1.requiredButtons.Length; j++)
					{
						if (!A_2[A_1.requiredButtons[j]])
						{
							return 0f;
						}
						flag = true;
					}
					if (flag)
					{
						return 1f;
					}
					return 0f;
				}
				else
				{
					int sourceButton = A_1.sourceButton;
					if (sourceButton < 0 || sourceButton >= this.haYkWADMIUsnuaWoAcnigKCbcsTj || sourceButton >= 256)
					{
						return 0f;
					}
					if (!A_2[sourceButton])
					{
						return 0f;
					}
					return 1f;
				}
			}
			else
			{
				if (A_1.sourceType != HardwareElementSourceTypeWithHat.Axis)
				{
					if (A_1.sourceType == HardwareElementSourceTypeWithHat.Hat)
					{
						int sourceHat = A_1.sourceHat;
						if (sourceHat < 0 || sourceHat >= this.pSNZLlcfOykgkwKOKvuJRJpNDvM || sourceHat >= 4)
						{
							return 0f;
						}
						switch (A_1.sourceHatDirection)
						{
						case HatDirection.Up:
							return this.qKUVTHuemsmGEdlrzgGSlgnmASJw(A_3[sourceHat], 0, A_1.sourceHatType);
						case HatDirection.Right:
							return this.qKUVTHuemsmGEdlrzgGSlgnmASJw(A_3[sourceHat], 2, A_1.sourceHatType);
						case HatDirection.Down:
							return this.qKUVTHuemsmGEdlrzgGSlgnmASJw(A_3[sourceHat], 4, A_1.sourceHatType);
						case HatDirection.Left:
							return this.qKUVTHuemsmGEdlrzgGSlgnmASJw(A_3[sourceHat], 6, A_1.sourceHatType);
						case HatDirection.UpRight:
							return this.qKUVTHuemsmGEdlrzgGSlgnmASJw(A_3[sourceHat], 1, A_1.sourceHatType);
						case HatDirection.DownRight:
							return this.qKUVTHuemsmGEdlrzgGSlgnmASJw(A_3[sourceHat], 3, A_1.sourceHatType);
						case HatDirection.DownLeft:
							return this.qKUVTHuemsmGEdlrzgGSlgnmASJw(A_3[sourceHat], 5, A_1.sourceHatType);
						case HatDirection.UpLeft:
							return this.qKUVTHuemsmGEdlrzgGSlgnmASJw(A_3[sourceHat], 7, A_1.sourceHatType);
						}
					}
					else if (A_1.sourceType == HardwareElementSourceTypeWithHat.Custom)
					{
						CustomCalculation customCalculation = A_1.customCalculation;
						if (customCalculation == null)
						{
							return 0f;
						}
						if (customCalculation.ResultType != TypeWrapper.DataType.Single)
						{
							return 0f;
						}
						HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData[] customCalculationSourceData = A_1.customCalculationSourceData;
						if (customCalculationSourceData == null)
						{
							return 0f;
						}
						for (int k = 0; k < customCalculationSourceData.Length; k++)
						{
							if (customCalculationSourceData[k] != null)
							{
								HardwareElementSourceTypeWithHat sourceType = (HardwareElementSourceTypeWithHat)customCalculationSourceData[k].sourceType;
								bool flag2;
								if (sourceType != HardwareElementSourceTypeWithHat.Button)
								{
									if (sourceType == HardwareElementSourceTypeWithHat.Axis)
									{
										float num;
										if (this.gdkCPoUxMOopScCpHAaheiwaOWxtA(customCalculationSourceData[k], out num))
										{
											customCalculation.AddData((num != 0f) ? 1f : 0f);
										}
									}
								}
								else if (this.inmZDcvCQBFOndOUxLScnLiaiCoi(customCalculationSourceData[k], A_2, out flag2))
								{
									customCalculation.AddData(flag2 ? 1f : 0f);
								}
							}
						}
						if (!customCalculation.Process())
						{
							return 0f;
						}
						if (customCalculation.Result.type != TypeWrapper.DataType.Single)
						{
							return 0f;
						}
						if (customCalculation.Result == 0f)
						{
							return 0f;
						}
						return 1f;
					}
					return 0f;
				}
				int sourceAxis = A_1.sourceAxis;
				if (sourceAxis == 0)
				{
					return 0f;
				}
				int num2;
				if (sourceAxis >= 1 && sourceAxis <= 11)
				{
					num2 = 0;
				}
				else
				{
					if (sourceAxis != 1000)
					{
						return 0f;
					}
					HardwareJoystickMap.Platform_RawInput_Base.Button button = A_1 as HardwareJoystickMap.Platform_RawInput_Base.Button;
					if (button == null)
					{
						return 0f;
					}
					num2 = button.sourceOtherAxis;
				}
				float num3 = this.YNoFyksPhHhvwiVduYCUvhKzjVJY((RawInputAxis)sourceAxis, num2);
				float num4 = MathTools.Abs(num3);
				if (num4 <= A_1.axisDeadZone)
				{
					return 0f;
				}
				if (A_1.sourceAxisPole == Pole.Positive)
				{
					if (num3 < 0f)
					{
						return 0f;
					}
				}
				else if (num3 > 0f)
				{
					return 0f;
				}
				return num4;
			}
		}

		// Token: 0x06000138 RID: 312 RVA: 0x00011464 File Offset: 0x0000F664
		private float uaxdkeYOtgySPiOuUSqdLPQUtqdL(int A_1)
		{
			if (A_1 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(A_1) / 65535f * (float)MathTools.Sign(A_1), -1f, 1f);
		}

		// Token: 0x06000139 RID: 313 RVA: 0x00025140 File Offset: 0x00023340
		private float qKUVTHuemsmGEdlrzgGSlgnmASJw(int A_1, int A_2, HatType A_3)
		{
			if (A_1 < 0)
			{
				return 0f;
			}
			if (this.lvfqsNmNNullempSBzESOfQOBdoO.isUnknownController && !InputTools.HandleForced4WayHatsOnUnknownControllers(A_2, ref A_3))
			{
				return 0f;
			}
			int num = 4500 * A_2;
			if (A_3 == HatType.EightWay && A_1 != num)
			{
				return 0f;
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
			if (A_1 < num + num3 && A_1 > num - num3)
			{
				return 1f;
			}
			return 0f;
		}

		// Token: 0x0600013A RID: 314 RVA: 0x000211DC File Offset: 0x0001F3DC
		private float LoLwIqtoifjyZyrLbJytedaKdjbl(int A_1, AxisDirection A_2)
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

		// Token: 0x0600013B RID: 315 RVA: 0x000251D0 File Offset: 0x000233D0
		private bool inmZDcvCQBFOndOUxLScnLiaiCoi(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData A_1, bool[] A_2, out bool A_3)
		{
			A_3 = false;
			if (A_1.sourceType != 0)
			{
				return false;
			}
			int sourceButton = A_1.sourceButton;
			if (sourceButton < 0 || sourceButton >= this.haYkWADMIUsnuaWoAcnigKCbcsTj || sourceButton >= 256)
			{
				return false;
			}
			A_3 = A_2[sourceButton];
			return true;
		}

		// Token: 0x0600013C RID: 316 RVA: 0x00025210 File Offset: 0x00023410
		private bool gdkCPoUxMOopScCpHAaheiwaOWxtA(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData A_1, out float A_2)
		{
			A_2 = 0f;
			if (A_1.sourceType != 1)
			{
				return false;
			}
			if (A_1.sourceAxis == 0)
			{
				return false;
			}
			A_2 = this.YNoFyksPhHhvwiVduYCUvhKzjVJY((RawInputAxis)A_1.sourceAxis, A_1.sourceOtherAxis);
			AxisRange sourceAxisRange = A_1.sourceAxisRange;
			if (sourceAxisRange != AxisRange.Positive)
			{
				if (sourceAxisRange == AxisRange.Negative && A_2 > 0f)
				{
					A_2 = 0f;
				}
			}
			else if (A_2 < 0f)
			{
				A_2 = 0f;
			}
			if (A_1.axisCalibrationType == AxisCalibrationType.Default)
			{
				A_2 = InputTools.GetCalibratedAxisValueClamped(A_2, A_1.axisZero, -1f, 1f, A_1.axisDeadZone, A_1.invert, false, AxisSensitivityType.Multiplier, 1f, null);
			}
			else if (A_1.axisCalibrationType == AxisCalibrationType.Custom)
			{
				A_2 = InputTools.GetCalibratedAxisValueClamped(A_2, A_1.axisZero, A_1.axisMin, A_1.axisMax, A_1.axisDeadZone, A_1.invert, false, AxisSensitivityType.Multiplier, 1f, null);
			}
			else if (A_1.axisCalibrationType == AxisCalibrationType.Uncalibrated && A_1.axisDeadZone > 0f && MathTools.Abs(A_2) <= A_1.axisDeadZone)
			{
				A_2 = 0f;
			}
			return true;
		}

		// Token: 0x0600013D RID: 317 RVA: 0x00011D7D File Offset: 0x0000FF7D
		private ControlDeviceType nhdEwvfQgHigwzNcgsgCqosQAjWGb(DeviceType A_1)
		{
			if (A_1 == DeviceType.Keyboard)
			{
				return ControlDeviceType.Keyboard;
			}
			if (A_1 == DeviceType.Joystick)
			{
				return ControlDeviceType.Joystick;
			}
			if (A_1 == DeviceType.Gamepad)
			{
				return ControlDeviceType.Gamepad;
			}
			if (A_1 == DeviceType.Mouse)
			{
				return ControlDeviceType.Mouse;
			}
			if (A_1 == DeviceType.MultiAxisController)
			{
				return ControlDeviceType.Joystick;
			}
			return ControlDeviceType.Unknown;
		}

		// Token: 0x0600013E RID: 318 RVA: 0x0002531C File Offset: 0x0002351C
		private void PJJOtHxvzThzSIIlDDpmISTTXaz(HardwareJoystickMap.Platform_InternalDriver_Base.Axis A_1, int A_2, bool[] A_3, int[] A_4)
		{
			if (A_2 >= this.frYuFrxbYOpWDQlobHCxJlqfpyyF)
			{
				throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
			}
			this.LayqWGfBOKMwtJsqsiZmmMXVuzu[A_2] = this.AqhZEzvbchnUiyHCHGOHFbdVsyodb(A_1, A_3, A_4);
			if (!this.gXnlJydNdeiHCeFStJTxdJzTvDrI && this.LayqWGfBOKMwtJsqsiZmmMXVuzu[A_2] != 0f)
			{
				this.gXnlJydNdeiHCeFStJTxdJzTvDrI = true;
			}
		}

		// Token: 0x0600013F RID: 319 RVA: 0x00025370 File Offset: 0x00023570
		private void kFRjkzDEPzdQbQEevBBOypEGSgmr(HardwareJoystickMap.Platform_InternalDriver_Base.Button A_1, int A_2, bool[] A_3, int[] A_4)
		{
			if (A_2 >= this.bOjutFXzYOCnmKEhhaetGQOxbwiZ)
			{
				throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
			}
			this.BalfGvZjQzufvZzyBQBuxJhcjhSh[A_2] = this.lDDSVOZGuqpGnjeCFTxipyXmaNeC(A_1, A_3, A_4);
			if (!this.gXnlJydNdeiHCeFStJTxdJzTvDrI && this.BalfGvZjQzufvZzyBQBuxJhcjhSh[A_2] != 0f)
			{
				this.gXnlJydNdeiHCeFStJTxdJzTvDrI = true;
			}
		}

		// Token: 0x06000140 RID: 320 RVA: 0x000253C4 File Offset: 0x000235C4
		private float AqhZEzvbchnUiyHCHGOHFbdVsyodb(HardwareJoystickMap.Platform_InternalDriver_Base.Axis A_1, bool[] A_2, int[] A_3)
		{
			if (A_1.sourceType == 1)
			{
				int sourceAxis = A_1.sourceAxis;
				if (sourceAxis < 0 || sourceAxis >= this.IfQidsDjnCqPQAXhaXLmDYreQIfrd || sourceAxis >= 56)
				{
					return 0f;
				}
				return this.viLiQxzaRJnUaVbRbTRhApyHgTyn(sourceAxis);
			}
			else if (A_1.sourceType == 0)
			{
				int sourceButton = A_1.sourceButton;
				if (sourceButton < 0 || sourceButton >= this.haYkWADMIUsnuaWoAcnigKCbcsTj || sourceButton >= 256)
				{
					return 0f;
				}
				if (!A_2[sourceButton])
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
				if (A_1.sourceType != 2)
				{
					return 0f;
				}
				int sourceHat = A_1.sourceHat;
				if (sourceHat < 0 || sourceHat >= this.pSNZLlcfOykgkwKOKvuJRJpNDvM || sourceHat >= 4)
				{
					return 0f;
				}
				int num = A_3[sourceHat];
				if (num < 0)
				{
					return 0f;
				}
				float num2;
				if (A_1.sourceHatDirection == AxisDirection.Horizontal)
				{
					num2 = this.LoLwIqtoifjyZyrLbJytedaKdjbl(num, AxisDirection.Horizontal);
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
					num2 = this.LoLwIqtoifjyZyrLbJytedaKdjbl(num, AxisDirection.Vertical);
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

		// Token: 0x06000141 RID: 321 RVA: 0x00011D9E File Offset: 0x0000FF9E
		private float viLiQxzaRJnUaVbRbTRhApyHgTyn(int A_1)
		{
			return (this.HLZLGpJXUNbpdNbUvethdHaOftuA as HcYEnccIjPAYPjznhnzOXfyNmtcA).wYoiXYUrBndvPuoILfVoGOgkslQ(A_1);
		}

		// Token: 0x06000142 RID: 322 RVA: 0x00025520 File Offset: 0x00023720
		private float lDDSVOZGuqpGnjeCFTxipyXmaNeC(HardwareJoystickMap.Platform_InternalDriver_Base.Button A_1, bool[] A_2, int[] A_3)
		{
			if (A_1.sourceType == 0)
			{
				int sourceButton = A_1.sourceButton;
				if (sourceButton < 0 || sourceButton >= this.haYkWADMIUsnuaWoAcnigKCbcsTj || sourceButton >= 256)
				{
					return 0f;
				}
				if (!A_2[sourceButton])
				{
					return 0f;
				}
				return 1f;
			}
			else
			{
				if (A_1.sourceType != 1)
				{
					if (A_1.sourceType == 2)
					{
						int sourceHat = A_1.sourceHat;
						if (sourceHat < 0 || sourceHat >= this.pSNZLlcfOykgkwKOKvuJRJpNDvM || sourceHat >= 4)
						{
							return 0f;
						}
						switch (A_1.sourceHatDirection)
						{
						case HatDirection.Up:
							return this.qKUVTHuemsmGEdlrzgGSlgnmASJw(A_3[sourceHat], 0, A_1.sourceHatType);
						case HatDirection.Right:
							return this.qKUVTHuemsmGEdlrzgGSlgnmASJw(A_3[sourceHat], 2, A_1.sourceHatType);
						case HatDirection.Down:
							return this.qKUVTHuemsmGEdlrzgGSlgnmASJw(A_3[sourceHat], 4, A_1.sourceHatType);
						case HatDirection.Left:
							return this.qKUVTHuemsmGEdlrzgGSlgnmASJw(A_3[sourceHat], 6, A_1.sourceHatType);
						case HatDirection.UpRight:
							return this.qKUVTHuemsmGEdlrzgGSlgnmASJw(A_3[sourceHat], 1, A_1.sourceHatType);
						case HatDirection.DownRight:
							return this.qKUVTHuemsmGEdlrzgGSlgnmASJw(A_3[sourceHat], 3, A_1.sourceHatType);
						case HatDirection.DownLeft:
							return this.qKUVTHuemsmGEdlrzgGSlgnmASJw(A_3[sourceHat], 5, A_1.sourceHatType);
						case HatDirection.UpLeft:
							return this.qKUVTHuemsmGEdlrzgGSlgnmASJw(A_3[sourceHat], 7, A_1.sourceHatType);
						}
					}
					return 0f;
				}
				int sourceAxis = A_1.sourceAxis;
				if (sourceAxis < 0 || sourceAxis >= this.IfQidsDjnCqPQAXhaXLmDYreQIfrd || sourceAxis >= 56)
				{
					return 0f;
				}
				float num = this.viLiQxzaRJnUaVbRbTRhApyHgTyn(sourceAxis);
				if (MathTools.Abs(num) <= A_1.axisDeadZone)
				{
					return 0f;
				}
				if (A_1.sourceAxisPole == Pole.Positive)
				{
					if (num < 0f)
					{
						return 0f;
					}
				}
				else if (num > 0f)
				{
					return 0f;
				}
				return 1f;
			}
		}

		// Token: 0x06000143 RID: 323 RVA: 0x000256C4 File Offset: 0x000238C4
		private bool vzrNiuwwMWnvaNTqifqAxUxdoFBA(int A_1, int A_2, HatType A_3)
		{
			if (A_1 < 0)
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

		// Token: 0x06000144 RID: 324 RVA: 0x000211DC File Offset: 0x0001F3DC
		private float JAzAewbMwLfSMiJlduGvTRdWTMvH(int A_1, AxisDirection A_2)
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

		// Token: 0x06000145 RID: 325 RVA: 0x00025728 File Offset: 0x00023928
		private void dqJRbvajtZbusTsKxzWZAHQKfYAh()
		{
			this.lvfqsNmNNullempSBzESOfQOBdoO = this.jGNYHPjRXjLiLsJxwQfxFUYrJYyp(this.yWIorveQNFmnBzjNOSpYbqyLdFAh());
			if (this.lvfqsNmNNullempSBzESOfQOBdoO == null)
			{
				Logger.LogError("Default hardware map not found!");
				return;
			}
			this.frYuFrxbYOpWDQlobHCxJlqfpyyF = this.lvfqsNmNNullempSBzESOfQOBdoO.axisCount;
			this.bOjutFXzYOCnmKEhhaetGQOxbwiZ = this.lvfqsNmNNullempSBzESOfQOBdoO.buttonCount;
		}

		// Token: 0x06000146 RID: 326 RVA: 0x00025784 File Offset: 0x00023984
		private string xTwcXbTVECsxBIANAGywMLeLhfLC()
		{
			return InputTools.FormatHardwareIdentifierString(string.Format("{0}{1}{2}{3}{4}", new object[]
			{
				ReInput.currentPlatform.ToString(),
				this.nzTdsQfHNPwqClyQJkPHJfysmuTc.IyeqldGQoDdXwdXkwrSBJhaqzEcI,
				(this.xErTcVOYeKhcFudMIFTpJhEtUuErA && !string.IsNullOrEmpty(this.oQmVFwwpSVhQckqpMqdbpcgAmsdT)) ? this.oQmVFwwpSVhQckqpMqdbpcgAmsdT : this.RbShfEhwCDRxlQlnNIgzAabGofUo,
				this.sdRvWgdxGsWZMSXXvhueboThNJNn.ToString("X4"),
				this.jHuKmjKhVLQFojcgfuODCsbysDBm.ToString("X4")
			}));
		}

		// Token: 0x06000147 RID: 327 RVA: 0x0002581C File Offset: 0x00023A1C
		private void QsYxktrAOQnFAeMgIDPUBxqJBCmk(BridgedControllerHWInfo A_1)
		{
			A_1.inputManagerSource = InputSource.RawInput;
			A_1.inputSource = this.nzTdsQfHNPwqClyQJkPHJfysmuTc.IyeqldGQoDdXwdXkwrSBJhaqzEcI;
			A_1.deviceType = this.nhdEwvfQgHigwzNcgsgCqosQAjWGb(this.JFABfyJzvFeNKttBEbBVEoiYAuNZ);
			A_1.hardwareIdentifier = this.xTwcXbTVECsxBIANAGywMLeLhfLC();
			A_1.hardwareAxisCount = this.IfQidsDjnCqPQAXhaXLmDYreQIfrd;
			A_1.hardwareButtonCount = this.haYkWADMIUsnuaWoAcnigKCbcsTj;
			A_1.hardwareHatCount = this.pSNZLlcfOykgkwKOKvuJRJpNDvM;
			A_1.hw_productName = this.RbShfEhwCDRxlQlnNIgzAabGofUo;
			A_1.hw_deviceGuid = this.instanceGuid;
			A_1.hw_vendorId = this.jHuKmjKhVLQFojcgfuODCsbysDBm;
			A_1.hw_productId = this.sdRvWgdxGsWZMSXXvhueboThNJNn;
			A_1.hw_pidVid = new PidVid(this.aGYEhbcpcAvttFkyNSFMAWobsbmTA);
			A_1.hw_isBluetoothDevice = this.xErTcVOYeKhcFudMIFTpJhEtUuErA;
			A_1.hw_bluetoothDeviceName = this.oQmVFwwpSVhQckqpMqdbpcgAmsdT;
			A_1.hw_supportsVibration = this.MMReLrBzXbjyNdFTkSMJJHhyWTYjA;
			A_1.hw_localVibrationMotorCount = this.eJSwKIfgnTanckexcqhXbtGiGhmmb;
			A_1.definitionMatchTag = this.nzTdsQfHNPwqClyQJkPHJfysmuTc.jXfnlDoFeRonrCodCfHjZCgeVudx;
		}

		// Token: 0x06000148 RID: 328 RVA: 0x00025908 File Offset: 0x00023B08
		private void BpgaVXZwaKDbVBRCrGmxxcKmYhDW(BridgedController A_1)
		{
			this.QsYxktrAOQnFAeMgIDPUBxqJBCmk(A_1);
			A_1.sourceJoystick = this;
			A_1.gameHardwareMap = this.lvfqsNmNNullempSBzESOfQOBdoO.ToGameHardwareControllerMap();
			A_1.instanceName = this.nmjgzFgYhQhWjySorJibJlefPZuB;
			A_1.productName = this.RbShfEhwCDRxlQlnNIgzAabGofUo;
			A_1.isXInputDevice = this.tfIULvCtiOhsPgetTzSSyUpYrHwk;
			A_1.axisCount = this.frYuFrxbYOpWDQlobHCxJlqfpyyF;
			A_1.buttonCount = this.bOjutFXzYOCnmKEhhaetGQOxbwiZ;
			A_1.isButtonPressureSensitive = new bool[this.bOjutFXzYOCnmKEhhaetGQOxbwiZ];
			Array.Copy(this.QbiOwowjVGKqTXLmgDwSiluPlSYL, A_1.isButtonPressureSensitive, this.bOjutFXzYOCnmKEhhaetGQOxbwiZ);
			A_1.unknownControllerHats = this.kiujRvWeXwVADINpQNTxdHSypKSs();
			A_1.controllerTypeGuid = this.rcuyASDyaTwSDfmktUCNYIgjCZUaA;
			A_1.controllerExtension = this.extension;
		}

		// Token: 0x06000149 RID: 329 RVA: 0x000259BC File Offset: 0x00023BBC
		private void BSnRbqyPRtLjxyoPMJanKElhUMLR()
		{
			for (int i = 0; i < this.bOjutFXzYOCnmKEhhaetGQOxbwiZ; i++)
			{
				this.BalfGvZjQzufvZzyBQBuxJhcjhSh[i] = 0f;
			}
			for (int j = 0; j < this.frYuFrxbYOpWDQlobHCxJlqfpyyF; j++)
			{
				this.LayqWGfBOKMwtJsqsiZmmMXVuzu[j] = 0f;
			}
		}

		// Token: 0x0600014A RID: 330 RVA: 0x00025A08 File Offset: 0x00023C08
		private UnknownControllerHat[] kiujRvWeXwVADINpQNTxdHSypKSs()
		{
			if (!this.HlHxlMwJJcyECoCzMOyVSbhrmqXx)
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

		// Token: 0x0600014B RID: 331 RVA: 0x00011DB1 File Offset: 0x0000FFB1
		public void BFCoUBDQuBWuVZqMsTMGuliBuwjQ()
		{
			this.GbSoYjRtSggYfBdsdOicrbYdSdFu(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x0600014C RID: 332 RVA: 0x00025A80 File Offset: 0x00023C80
		protected virtual void tveVowvcZiyziEDwXZrXxIlgTOx()
		{
			try
			{
				this.GbSoYjRtSggYfBdsdOicrbYdSdFu(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		// Token: 0x0600014D RID: 333 RVA: 0x00011DC0 File Offset: 0x0000FFC0
		protected virtual void GbSoYjRtSggYfBdsdOicrbYdSdFu(bool A_1)
		{
			if (this.ehVmIMPwjcaYheiaBSJEWepGgUxaA)
			{
				return;
			}
			this.ehVmIMPwjcaYheiaBSJEWepGgUxaA = true;
		}

		// Token: 0x0600014E RID: 334 RVA: 0x00011DD4 File Offset: 0x0000FFD4
		public static int wtjZUNUzfZgNVzvhLPrpFPjjlErr(CNVeZFjzzLebAIeziISIZlyPJSYp.YlqzBvZkVxRXSgZCOLBuUiBmFFIM A_0, CNVeZFjzzLebAIeziISIZlyPJSYp.YlqzBvZkVxRXSgZCOLBuUiBmFFIM A_1)
		{
			if (A_0.wJApJdVamolSnIDPmDihhGobOsYl < A_1.wJApJdVamolSnIDPmDihhGobOsYl)
			{
				return -1;
			}
			if (A_0.wJApJdVamolSnIDPmDihhGobOsYl > A_1.wJApJdVamolSnIDPmDihhGobOsYl)
			{
				return 1;
			}
			return 0;
		}

		// Token: 0x0600014F RID: 335 RVA: 0x00011DF7 File Offset: 0x0000FFF7
		public static int bkYLGsdPGEOteuchIFWbQRygeXN(CNVeZFjzzLebAIeziISIZlyPJSYp.YlqzBvZkVxRXSgZCOLBuUiBmFFIM A_0, CNVeZFjzzLebAIeziISIZlyPJSYp.YlqzBvZkVxRXSgZCOLBuUiBmFFIM A_1)
		{
			if (A_0.WERnrjuiRULxkuvoZtagkCGPYmyI < A_1.WERnrjuiRULxkuvoZtagkCGPYmyI)
			{
				return -1;
			}
			if (A_0.WERnrjuiRULxkuvoZtagkCGPYmyI > A_1.WERnrjuiRULxkuvoZtagkCGPYmyI)
			{
				return 1;
			}
			return 0;
		}

		// Token: 0x040000E2 RID: 226
		private int CIdVIJgfTRXfTUaWOlZQdAeGJCmN;

		// Token: 0x040000E3 RID: 227
		private int wJApJdVamolSnIDPmDihhGobOsYl;

		// Token: 0x040000E4 RID: 228
		public Guid rcuyASDyaTwSDfmktUCNYIgjCZUaA;

		// Token: 0x040000E5 RID: 229
		public string pgWfNDrKWBxQjVnXBdatvWXBylwN;

		// Token: 0x040000E6 RID: 230
		private readonly zOVftvsFbTAvLzuhvSRGfBOXFlHHA nzTdsQfHNPwqClyQJkPHJfysmuTc;

		// Token: 0x040000E7 RID: 231
		private readonly DeviceType JFABfyJzvFeNKttBEbBVEoiYAuNZ;

		// Token: 0x040000E8 RID: 232
		public string nmjgzFgYhQhWjySorJibJlefPZuB;

		// Token: 0x040000E9 RID: 233
		public string RbShfEhwCDRxlQlnNIgzAabGofUo;

		// Token: 0x040000EA RID: 234
		public string oQmVFwwpSVhQckqpMqdbpcgAmsdT;

		// Token: 0x040000EB RID: 235
		public int sdRvWgdxGsWZMSXXvhueboThNJNn;

		// Token: 0x040000EC RID: 236
		public int jHuKmjKhVLQFojcgfuODCsbysDBm;

		// Token: 0x040000ED RID: 237
		public Guid QZpBuNCZbrXOBPeZIsKLkqnEiYCM;

		// Token: 0x040000EE RID: 238
		public Guid aGYEhbcpcAvttFkyNSFMAWobsbmTA;

		// Token: 0x040000EF RID: 239
		public Guid cKMfLUfONERXypnGOOCUbyKpeIdTA;

		// Token: 0x040000F0 RID: 240
		public int WERnrjuiRULxkuvoZtagkCGPYmyI;

		// Token: 0x040000F1 RID: 241
		public int frYuFrxbYOpWDQlobHCxJlqfpyyF;

		// Token: 0x040000F2 RID: 242
		public int bOjutFXzYOCnmKEhhaetGQOxbwiZ;

		// Token: 0x040000F3 RID: 243
		public int IfQidsDjnCqPQAXhaXLmDYreQIfrd;

		// Token: 0x040000F4 RID: 244
		public int haYkWADMIUsnuaWoAcnigKCbcsTj;

		// Token: 0x040000F5 RID: 245
		public int pSNZLlcfOykgkwKOKvuJRJpNDvM;

		// Token: 0x040000F6 RID: 246
		public bool tfIULvCtiOhsPgetTzSSyUpYrHwk;

		// Token: 0x040000F7 RID: 247
		public bool xErTcVOYeKhcFudMIFTpJhEtUuErA;

		// Token: 0x040000F8 RID: 248
		public bool MMReLrBzXbjyNdFTkSMJJHhyWTYjA;

		// Token: 0x040000F9 RID: 249
		public int eJSwKIfgnTanckexcqhXbtGiGhmmb;

		// Token: 0x040000FA RID: 250
		private float[] LayqWGfBOKMwtJsqsiZmmMXVuzu;

		// Token: 0x040000FB RID: 251
		private float[] BalfGvZjQzufvZzyBQBuxJhcjhSh;

		// Token: 0x040000FC RID: 252
		private bool[] QbiOwowjVGKqTXLmgDwSiluPlSYL;

		// Token: 0x040000FD RID: 253
		private HardwareJoystickMap_InputManager lvfqsNmNNullempSBzESOfQOBdoO;

		// Token: 0x040000FE RID: 254
		private ltTfAQarXGuyOkgVdzmGsTLJYqWh HLZLGpJXUNbpdNbUvethdHaOftuA;

		// Token: 0x040000FF RID: 255
		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> jGNYHPjRXjLiLsJxwQfxFUYrJYyp;

		// Token: 0x04000100 RID: 256
		private bool HlHxlMwJJcyECoCzMOyVSbhrmqXx;

		// Token: 0x04000101 RID: 257
		private bool gXnlJydNdeiHCeFStJTxdJzTvDrI;

		// Token: 0x04000102 RID: 258
		[CompilerGenerated]
		private Controller.Extension djcdEeZrvqCBidiMLgkmWmQAVNBQA;

		// Token: 0x04000103 RID: 259
		private bool ehVmIMPwjcaYheiaBSJEWepGgUxaA;
	}

	// Token: 0x0200001B RID: 27
	private class sJcDUhDYViyFPlCVdxFJkCszZdoqA
	{
		// Token: 0x06000150 RID: 336 RVA: 0x00011E1A File Offset: 0x0001001A
		public sJcDUhDYViyFPlCVdxFJkCszZdoqA()
		{
			this.fOBufWXXnMWHMZiIFvVkpQCzlDnW = new List<CNVeZFjzzLebAIeziISIZlyPJSYp.sJcDUhDYViyFPlCVdxFJkCszZdoqA.EGyRyrzWcMoiSzWsyNQnyPbwmdpm>();
		}

		// Token: 0x06000151 RID: 337 RVA: 0x00025AB0 File Offset: 0x00023CB0
		public void UehIqXiQxFXUIaYstQeQESpecyoDb(CNVeZFjzzLebAIeziISIZlyPJSYp.YlqzBvZkVxRXSgZCOLBuUiBmFFIM A_1)
		{
			if (A_1 == null)
			{
				return;
			}
			int count = this.fOBufWXXnMWHMZiIFvVkpQCzlDnW.Count;
			for (int i = 0; i < count; i++)
			{
				if (this.fOBufWXXnMWHMZiIFvVkpQCzlDnW[i].uZKlaaLDuszqhGnJAgbQiFxfWcFwA(A_1, CNVeZFjzzLebAIeziISIZlyPJSYp.sJcDUhDYViyFPlCVdxFJkCszZdoqA.SznNvkhvjTrrYhKjdqZaFllieRnA.Exact))
				{
					this.fOBufWXXnMWHMZiIFvVkpQCzlDnW[i].nquOcgYNFeFcZENGQiQUZoWhnrcBA = A_1.rewiredId;
					this.fOBufWXXnMWHMZiIFvVkpQCzlDnW[i].zlLSzUWjpmJoPubSQVkTlZMoogSp = A_1.instanceGuid;
					this.fOBufWXXnMWHMZiIFvVkpQCzlDnW[i].ILRBGHYucIomNBijBFtxbOiaLfIi = A_1.cKMfLUfONERXypnGOOCUbyKpeIdTA;
					this.fOBufWXXnMWHMZiIFvVkpQCzlDnW[i].ZrXYuEaKvtgwxBXjkmNRFiZaifRo = A_1.inputManagerId;
					this.fOBufWXXnMWHMZiIFvVkpQCzlDnW[i].eVFDqMfsNtvXQcUgXVZLPsqwWrGk = A_1.IfQidsDjnCqPQAXhaXLmDYreQIfrd;
					this.fOBufWXXnMWHMZiIFvVkpQCzlDnW[i].ICYWiqZaCitLifMgprHIgooruXib = A_1.haYkWADMIUsnuaWoAcnigKCbcsTj;
					this.fOBufWXXnMWHMZiIFvVkpQCzlDnW[i].LVBCUZRIKhRQhMcoAUUrnAsfnUTr = A_1.pSNZLlcfOykgkwKOKvuJRJpNDvM;
					this.fOBufWXXnMWHMZiIFvVkpQCzlDnW[i].lwxAHtwzWNpIRGDADOgYmCyBinDN = A_1.bOjutFXzYOCnmKEhhaetGQOxbwiZ;
					this.fOBufWXXnMWHMZiIFvVkpQCzlDnW[i].KFAInarghWAsmkRKsPiWMnLXEXWY = A_1.frYuFrxbYOpWDQlobHCxJlqfpyyF;
					this.fOBufWXXnMWHMZiIFvVkpQCzlDnW[i].kEIuMDZYRjfRANETrusCkPxdeLiZ = A_1.HPMNuIotKTVbszXPNIKjUijNaqyF;
					this.dRiCtpefTrkwYfnzfiXOWseIyevj(A_1.rewiredId, A_1.instanceGuid, i);
					return;
				}
			}
			this.fOBufWXXnMWHMZiIFvVkpQCzlDnW.Add(new CNVeZFjzzLebAIeziISIZlyPJSYp.sJcDUhDYViyFPlCVdxFJkCszZdoqA.EGyRyrzWcMoiSzWsyNQnyPbwmdpm
			{
				nquOcgYNFeFcZENGQiQUZoWhnrcBA = A_1.rewiredId,
				zlLSzUWjpmJoPubSQVkTlZMoogSp = A_1.instanceGuid,
				ILRBGHYucIomNBijBFtxbOiaLfIi = A_1.cKMfLUfONERXypnGOOCUbyKpeIdTA,
				ZrXYuEaKvtgwxBXjkmNRFiZaifRo = A_1.inputManagerId,
				eVFDqMfsNtvXQcUgXVZLPsqwWrGk = A_1.IfQidsDjnCqPQAXhaXLmDYreQIfrd,
				ICYWiqZaCitLifMgprHIgooruXib = A_1.haYkWADMIUsnuaWoAcnigKCbcsTj,
				LVBCUZRIKhRQhMcoAUUrnAsfnUTr = A_1.pSNZLlcfOykgkwKOKvuJRJpNDvM,
				lwxAHtwzWNpIRGDADOgYmCyBinDN = A_1.bOjutFXzYOCnmKEhhaetGQOxbwiZ,
				KFAInarghWAsmkRKsPiWMnLXEXWY = A_1.frYuFrxbYOpWDQlobHCxJlqfpyyF,
				kEIuMDZYRjfRANETrusCkPxdeLiZ = A_1.HPMNuIotKTVbszXPNIKjUijNaqyF
			});
			this.dRiCtpefTrkwYfnzfiXOWseIyevj(A_1.rewiredId, A_1.instanceGuid, this.fOBufWXXnMWHMZiIFvVkpQCzlDnW.Count - 1);
		}

		// Token: 0x06000152 RID: 338 RVA: 0x00025C98 File Offset: 0x00023E98
		public bool dsGYMFHhtlKNafHEFxIuRjDmfUQq(CNVeZFjzzLebAIeziISIZlyPJSYp.YlqzBvZkVxRXSgZCOLBuUiBmFFIM A_1, CNVeZFjzzLebAIeziISIZlyPJSYp.sJcDUhDYViyFPlCVdxFJkCszZdoqA.SznNvkhvjTrrYhKjdqZaFllieRnA A_2)
		{
			int count = this.fOBufWXXnMWHMZiIFvVkpQCzlDnW.Count;
			for (int i = 0; i < count; i++)
			{
				if (this.fOBufWXXnMWHMZiIFvVkpQCzlDnW[i].uZKlaaLDuszqhGnJAgbQiFxfWcFwA(A_1, A_2))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000153 RID: 339 RVA: 0x00011E2D File Offset: 0x0001002D
		public IEnumerable<CNVeZFjzzLebAIeziISIZlyPJSYp.sJcDUhDYViyFPlCVdxFJkCszZdoqA.EGyRyrzWcMoiSzWsyNQnyPbwmdpm> XISescxkKLUUpaFKmNqSKJysdIzo(CNVeZFjzzLebAIeziISIZlyPJSYp.YlqzBvZkVxRXSgZCOLBuUiBmFFIM A_1, CNVeZFjzzLebAIeziISIZlyPJSYp.sJcDUhDYViyFPlCVdxFJkCszZdoqA.SznNvkhvjTrrYhKjdqZaFllieRnA A_2)
		{
			int count = this.fOBufWXXnMWHMZiIFvVkpQCzlDnW.Count;
			int num;
			for (int i = 0; i < count; i = num + 1)
			{
				if (this.fOBufWXXnMWHMZiIFvVkpQCzlDnW[i].uZKlaaLDuszqhGnJAgbQiFxfWcFwA(A_1, A_2))
				{
					yield return this.fOBufWXXnMWHMZiIFvVkpQCzlDnW[i];
				}
				num = i;
			}
			yield break;
		}

		// Token: 0x06000154 RID: 340 RVA: 0x00025CD8 File Offset: 0x00023ED8
		private void dRiCtpefTrkwYfnzfiXOWseIyevj(int A_1, Guid A_2, int A_3)
		{
			for (int i = this.fOBufWXXnMWHMZiIFvVkpQCzlDnW.Count - 1; i >= 0; i--)
			{
				if (i != A_3 && (this.fOBufWXXnMWHMZiIFvVkpQCzlDnW[i].nquOcgYNFeFcZENGQiQUZoWhnrcBA == A_1 || this.fOBufWXXnMWHMZiIFvVkpQCzlDnW[i].zlLSzUWjpmJoPubSQVkTlZMoogSp == A_2))
				{
					this.fOBufWXXnMWHMZiIFvVkpQCzlDnW.RemoveAt(i);
				}
			}
		}

		// Token: 0x06000155 RID: 341 RVA: 0x00025D3C File Offset: 0x00023F3C
		public virtual string mWfUVeDPaDcUDXMQCSlkhGYIZLge()
		{
			string text = "";
			text = text + "Joystick records: " + this.fOBufWXXnMWHMZiIFvVkpQCzlDnW.Count.ToString() + "\n";
			for (int i = 0; i < this.fOBufWXXnMWHMZiIFvVkpQCzlDnW.Count; i++)
			{
				text = text + "Record " + i.ToString() + ":\n";
				text = text + this.fOBufWXXnMWHMZiIFvVkpQCzlDnW[i].ToString() + "\n\n";
			}
			return text;
		}

		// Token: 0x04000104 RID: 260
		private List<CNVeZFjzzLebAIeziISIZlyPJSYp.sJcDUhDYViyFPlCVdxFJkCszZdoqA.EGyRyrzWcMoiSzWsyNQnyPbwmdpm> fOBufWXXnMWHMZiIFvVkpQCzlDnW;

		// Token: 0x0200001C RID: 28
		public enum SznNvkhvjTrrYhKjdqZaFllieRnA
		{
			// Token: 0x04000106 RID: 262
			Exact,
			// Token: 0x04000107 RID: 263
			Approximate
		}

		// Token: 0x0200001D RID: 29
		public class EGyRyrzWcMoiSzWsyNQnyPbwmdpm
		{
			// Token: 0x06000156 RID: 342 RVA: 0x00025DC0 File Offset: 0x00023FC0
			public bool uZKlaaLDuszqhGnJAgbQiFxfWcFwA(CNVeZFjzzLebAIeziISIZlyPJSYp.YlqzBvZkVxRXSgZCOLBuUiBmFFIM A_1, CNVeZFjzzLebAIeziISIZlyPJSYp.sJcDUhDYViyFPlCVdxFJkCszZdoqA.SznNvkhvjTrrYhKjdqZaFllieRnA A_2)
			{
				if (this.eVFDqMfsNtvXQcUgXVZLPsqwWrGk != A_1.IfQidsDjnCqPQAXhaXLmDYreQIfrd)
				{
					return false;
				}
				if (this.ICYWiqZaCitLifMgprHIgooruXib != A_1.haYkWADMIUsnuaWoAcnigKCbcsTj)
				{
					return false;
				}
				if (this.LVBCUZRIKhRQhMcoAUUrnAsfnUTr != A_1.pSNZLlcfOykgkwKOKvuJRJpNDvM)
				{
					return false;
				}
				if (this.lwxAHtwzWNpIRGDADOgYmCyBinDN != A_1.bOjutFXzYOCnmKEhhaetGQOxbwiZ)
				{
					return false;
				}
				if (this.KFAInarghWAsmkRKsPiWMnLXEXWY != A_1.frYuFrxbYOpWDQlobHCxJlqfpyyF)
				{
					return false;
				}
				if (this.kEIuMDZYRjfRANETrusCkPxdeLiZ != A_1.HPMNuIotKTVbszXPNIKjUijNaqyF)
				{
					return false;
				}
				if (A_1.rewiredId == this.nquOcgYNFeFcZENGQiQUZoWhnrcBA)
				{
					return true;
				}
				if (A_2 == CNVeZFjzzLebAIeziISIZlyPJSYp.sJcDUhDYViyFPlCVdxFJkCszZdoqA.SznNvkhvjTrrYhKjdqZaFllieRnA.Exact)
				{
					return this.zlLSzUWjpmJoPubSQVkTlZMoogSp == A_1.instanceGuid;
				}
				if (A_2 == CNVeZFjzzLebAIeziISIZlyPJSYp.sJcDUhDYViyFPlCVdxFJkCszZdoqA.SznNvkhvjTrrYhKjdqZaFllieRnA.Approximate)
				{
					return this.ILRBGHYucIomNBijBFtxbOiaLfIi == A_1.cKMfLUfONERXypnGOOCUbyKpeIdTA;
				}
				throw new NotImplementedException();
			}

			// Token: 0x06000157 RID: 343 RVA: 0x00025E70 File Offset: 0x00024070
			public virtual string XwBwQSLEtSvzjzRHBGySElgrAiyQ()
			{
				string str = "" + "rewiredId = " + this.nquOcgYNFeFcZENGQiQUZoWhnrcBA.ToString() + "\n";
				string str2 = "instanceGuid = ";
				Guid ilrbghyucIomNBijBFtxbOiaLfIi = this.zlLSzUWjpmJoPubSQVkTlZMoogSp;
				string str3 = str + str2 + ilrbghyucIomNBijBFtxbOiaLfIi.ToString() + "\n";
				string str4 = "typeIdentifierGuid = ";
				ilrbghyucIomNBijBFtxbOiaLfIi = this.ILRBGHYucIomNBijBFtxbOiaLfIi;
				return str3 + str4 + ilrbghyucIomNBijBFtxbOiaLfIi.ToString() + "\n" + "lastInputManagerId = " + this.ZrXYuEaKvtgwxBXjkmNRFiZaifRo.ToString() + "\n" + "hardwareAxisCount = " + this.eVFDqMfsNtvXQcUgXVZLPsqwWrGk.ToString() + "\n" + "hardwareButtonCount = " + this.ICYWiqZaCitLifMgprHIgooruXib.ToString() + "\n" + "hardwareHatCount = " + this.LVBCUZRIKhRQhMcoAUUrnAsfnUTr.ToString() + "\n" + "gameButtonCount = " + this.lwxAHtwzWNpIRGDADOgYmCyBinDN.ToString() + "\n" + "gameAxisCount = " + this.KFAInarghWAsmkRKsPiWMnLXEXWY.ToString() + "\n" + "hasDriver = " + this.kEIuMDZYRjfRANETrusCkPxdeLiZ.ToString() + "\n";
			}

			// Token: 0x04000108 RID: 264
			public int nquOcgYNFeFcZENGQiQUZoWhnrcBA;

			// Token: 0x04000109 RID: 265
			public Guid zlLSzUWjpmJoPubSQVkTlZMoogSp;

			// Token: 0x0400010A RID: 266
			public Guid ILRBGHYucIomNBijBFtxbOiaLfIi;

			// Token: 0x0400010B RID: 267
			public int ZrXYuEaKvtgwxBXjkmNRFiZaifRo;

			// Token: 0x0400010C RID: 268
			public int eVFDqMfsNtvXQcUgXVZLPsqwWrGk;

			// Token: 0x0400010D RID: 269
			public int ICYWiqZaCitLifMgprHIgooruXib;

			// Token: 0x0400010E RID: 270
			public int LVBCUZRIKhRQhMcoAUUrnAsfnUTr;

			// Token: 0x0400010F RID: 271
			public int lwxAHtwzWNpIRGDADOgYmCyBinDN;

			// Token: 0x04000110 RID: 272
			public int KFAInarghWAsmkRKsPiWMnLXEXWY;

			// Token: 0x04000111 RID: 273
			public bool kEIuMDZYRjfRANETrusCkPxdeLiZ;
		}
	}
}
