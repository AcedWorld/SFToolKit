using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Platforms;
using Rewired.Platforms.Windows.DirectInput;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;

// Token: 0x0200000A RID: 10
internal class EegVRmhDzKlDwgeYQLLOXmqEZyWQ : PlatformInputManager, tzycxhCaFmhznyezTOQRNaGkykDIA
{
	// Token: 0x1700000B RID: 11
	// (get) Token: 0x06000053 RID: 83 RVA: 0x0001161C File Offset: 0x0000F81C
	// (set) Token: 0x06000054 RID: 84 RVA: 0x00011624 File Offset: 0x0000F824
	public xKKbjmIOHiqxZGRJDfbeyLuvTjMwB qbaspVnkVEWcLMRiajjuCAMzxLHi
	{
		get
		{
			return this.uCNgwGFeyJcAMfYKHimEBLrYcPBxB;
		}
		set
		{
			this.uCNgwGFeyJcAMfYKHimEBLrYcPBxB = value;
		}
	}

	// Token: 0x06000055 RID: 85 RVA: 0x0001F3EC File Offset: 0x0001D5EC
	public EegVRmhDzKlDwgeYQLLOXmqEZyWQ(UpdateLoopSetting A_1, xKKbjmIOHiqxZGRJDfbeyLuvTjMwB A_2, IntPtr A_3, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> A_4, Func<int> A_5)
	{
		try
		{
			this.PsPdnIEDAkAwlDCDVxErcOKCUTNhc = A_1;
			this.uCNgwGFeyJcAMfYKHimEBLrYcPBxB = A_2;
			this.cylyowOvSSaiZVuIAnKZcDqYIBHn = A_3;
			this.IoRdEmBmOUwWuhWpwHZntFGJNjECb = A_4;
			this.pHatMaldmmxnmyHIGDmPrMrvFepS = A_5;
			this.FVDByzSqkCpSnovdYlNuOaIEEwie = this;
			this.CnmGsnGhvZfbjHGrwtffhPSHnFhTA = new dksOLhBwLeCynZJmOfwlOOcWOZLI();
			this.RvuAuaQuywqVvbtoOvDueWPEnlt = new Action<int, ControllerDataUpdater>(this.UpdateControllerData);
			this.hhINLENVIkwlBYoAqcBIykXWbQfw = new EegVRmhDzKlDwgeYQLLOXmqEZyWQ.JXeosiJzHZtCjnOuUAKmKMkIbjpl();
			this.frqLMYqKStdCdbmIfoHjMmsukrHZ = new UHsWCAvrjUBCvVSiOhWZLujgvmAM<bool>(true, new Func<bool>(this.yonDUYcEvygJZZUIYBEGLNzIMqxyA));
			this.mIJCKHadPPbbpPiYIKwJFrShUHSe = new UHsWCAvrjUBCvVSiOhWZLujgvmAM<List<EegVRmhDzKlDwgeYQLLOXmqEZyWQ.gjEmKFEtFFvkzEDCLMkMaOflbYfHA>>(true, new Func<List<EegVRmhDzKlDwgeYQLLOXmqEZyWQ.gjEmKFEtFFvkzEDCLMkMaOflbYfHA>>(this.QbWtwstiOIuCkxdambpvhseynHQq));
			this.nyfSCGPcqrRCntrXAPaTXdshyyGc();
		}
		catch (Exception)
		{
			this.OnDestroy();
			throw;
		}
	}

	// Token: 0x1700000C RID: 12
	// (get) Token: 0x06000056 RID: 86 RVA: 0x0001162D File Offset: 0x0000F82D
	[CustomObfuscation(rename = false)]
	public override int deviceCount
	{
		get
		{
			return this.FeYGIfijfZlUMeQjTfwWLcKqiTLE;
		}
	}

	// Token: 0x1700000D RID: 13
	// (get) Token: 0x06000057 RID: 87 RVA: 0x00011635 File Offset: 0x0000F835
	[CustomObfuscation(rename = false)]
	public override PlatformInputManager primaryInputManager
	{
		get
		{
			return this.FVDByzSqkCpSnovdYlNuOaIEEwie;
		}
	}

	// Token: 0x1700000E RID: 14
	// (get) Token: 0x06000058 RID: 88 RVA: 0x0001163D File Offset: 0x0000F83D
	[CustomObfuscation(rename = false)]
	public override IInputSource inputSource
	{
		get
		{
			return new InputSourceWrapper<dksOLhBwLeCynZJmOfwlOOcWOZLI>(this.CnmGsnGhvZfbjHGrwtffhPSHnFhTA);
		}
	}

	// Token: 0x1700000F RID: 15
	// (get) Token: 0x06000059 RID: 89 RVA: 0x0001164A File Offset: 0x0000F84A
	[CustomObfuscation(rename = false)]
	public override InputSource inputSourceType
	{
		get
		{
			return InputSource.DirectInput;
		}
	}

	// Token: 0x0600005A RID: 90 RVA: 0x0001164D File Offset: 0x0000F84D
	[CustomObfuscation(rename = false)]
	public override void Initialize()
	{
		this.jNbAlbkaRRggxdpMFrelmNhGAHEkE = new EegVRmhDzKlDwgeYQLLOXmqEZyWQ.sOIlNQjlCZQqpGwxzRZguVCPvZdA();
		this.fFgAksVRvnDGqWJVTNOdPOzBfNcCA = new TimerRealTime(1.0);
		this.fFgAksVRvnDGqWJVTNOdPOzBfNcCA.Start();
		this.DWUwksQjJUnSQkOkXmCboswGxHoy();
	}

	// Token: 0x0600005B RID: 91 RVA: 0x0001167F File Offset: 0x0000F87F
	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		this.KEsodgutFCgFynjyGoAVgtENhCMh();
		this.jrAIVJlfmKpCwIiKrEDbDouKOasCb();
		this.ihhFtkQyqluOvGYKgELDZVBxCEeX();
	}

	// Token: 0x0600005C RID: 92 RVA: 0x0001F4B0 File Offset: 0x0001D6B0
	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (this.mIJCKHadPPbbpPiYIKwJFrShUHSe != null)
		{
			this.mIJCKHadPPbbpPiYIKwJFrShUHSe.eJRoAWWYCTmYLtClrCmkPPBxhWgT();
		}
		if (this.frqLMYqKStdCdbmIfoHjMmsukrHZ != null)
		{
			this.frqLMYqKStdCdbmIfoHjMmsukrHZ.eJRoAWWYCTmYLtClrCmkPPBxhWgT();
		}
		if (this.hhhkGXnLCgVAHguKOqGMZICCSOHd != null)
		{
			object obj = this.gTOVpaKLWvpeXQlxzgFLWmOPoBcR;
			lock (obj)
			{
				for (int i = 0; i < this.hhhkGXnLCgVAHguKOqGMZICCSOHd.Count; i++)
				{
					if (this.hhhkGXnLCgVAHguKOqGMZICCSOHd[i] != null)
					{
						this.hhhkGXnLCgVAHguKOqGMZICCSOHd[i].dwtAeYnlyxlpBJRMiAYgINMAYYwm();
						this.hhhkGXnLCgVAHguKOqGMZICCSOHd[i].vZEnfhtMlzetAJbqBxIxKygDXCjQA();
					}
				}
			}
		}
	}

	// Token: 0x0600005D RID: 93 RVA: 0x00011693 File Offset: 0x0000F893
	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return this.RvuAuaQuywqVvbtoOvDueWPEnlt;
	}

	// Token: 0x0600005E RID: 94 RVA: 0x0001F560 File Offset: 0x0001D760
	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
	{
		object obj = this.gTOVpaKLWvpeXQlxzgFLWmOPoBcR;
		lock (obj)
		{
			for (int i = 0; i < this.FeYGIfijfZlUMeQjTfwWLcKqiTLE; i++)
			{
				if (this.hhhkGXnLCgVAHguKOqGMZICCSOHd[i].inputManagerId == inputManagerId)
				{
					this.hhhkGXnLCgVAHguKOqGMZICCSOHd[i].FillData(data);
					return;
				}
			}
		}
		Logger.LogError("Invalid joystick Id " + inputManagerId.ToString() + "!");
	}

	// Token: 0x0600005F RID: 95 RVA: 0x0001169B File Offset: 0x0000F89B
	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		this.HurSbJUDSZtLROKBZtTKgxAEynTg = true;
		this.fFgAksVRvnDGqWJVTNOdPOzBfNcCA.Start();
		if (this._SystemDeviceConnectedEvent != null)
		{
			this._SystemDeviceConnectedEvent();
		}
	}

	// Token: 0x06000060 RID: 96 RVA: 0x000116C2 File Offset: 0x0000F8C2
	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		this.HurSbJUDSZtLROKBZtTKgxAEynTg = true;
		this.fFgAksVRvnDGqWJVTNOdPOzBfNcCA.Start();
		if (this._SystemDeviceDisconnectedEvent != null)
		{
			this._SystemDeviceDisconnectedEvent();
		}
	}

	// Token: 0x06000061 RID: 97 RVA: 0x000116E9 File Offset: 0x0000F8E9
	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
	}

	// Token: 0x06000062 RID: 98 RVA: 0x000116EB File Offset: 0x0000F8EB
	[CustomObfuscation(rename = false)]
	public override IUnifiedMouseSource GetUnifiedMouseSource()
	{
		return null;
	}

	// Token: 0x06000063 RID: 99 RVA: 0x000116EB File Offset: 0x0000F8EB
	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		return null;
	}

	// Token: 0x06000064 RID: 100 RVA: 0x0001F5F0 File Offset: 0x0001D7F0
	private void KEsodgutFCgFynjyGoAVgtENhCMh()
	{
		if (this.frqLMYqKStdCdbmIfoHjMmsukrHZ.dEuWrWEuMuRLEfvelqBlJqCXPzLm)
		{
			if (!this.frqLMYqKStdCdbmIfoHjMmsukrHZ.tyWUOmZxIPUWAGNTSMzHnebuMTZT())
			{
				return;
			}
			if (this.fFgAksVRvnDGqWJVTNOdPOzBfNcCA.running || this.mIJCKHadPPbbpPiYIKwJFrShUHSe.dEuWrWEuMuRLEfvelqBlJqCXPzLm)
			{
				return;
			}
			if (this.frqLMYqKStdCdbmIfoHjMmsukrHZ.jPEZROqMpmOrikUBVDIpnrJrIBJO)
			{
				this.HurSbJUDSZtLROKBZtTKgxAEynTg = true;
			}
			this.fFgAksVRvnDGqWJVTNOdPOzBfNcCA.Start();
			return;
		}
		else
		{
			if (!this.fFgAksVRvnDGqWJVTNOdPOzBfNcCA.running)
			{
				this.fFgAksVRvnDGqWJVTNOdPOzBfNcCA.Start();
				return;
			}
			if (this.fFgAksVRvnDGqWJVTNOdPOzBfNcCA.Update())
			{
				this.frqLMYqKStdCdbmIfoHjMmsukrHZ.VlWTpnOmouJNHovmWjtCiEYLYIbj();
			}
			return;
		}
	}

	// Token: 0x06000065 RID: 101 RVA: 0x0001F688 File Offset: 0x0001D888
	private List<EegVRmhDzKlDwgeYQLLOXmqEZyWQ.gjEmKFEtFFvkzEDCLMkMaOflbYfHA> jXFoinbODZRKURIZFJdSRVsymvDj()
	{
		List<EegVRmhDzKlDwgeYQLLOXmqEZyWQ.gjEmKFEtFFvkzEDCLMkMaOflbYfHA> list = new List<EegVRmhDzKlDwgeYQLLOXmqEZyWQ.gjEmKFEtFFvkzEDCLMkMaOflbYfHA>();
		IList<kvqducHUWPYYsnUhPdQAbkdahByH> list2 = this.IQEZKzsQqVPENzMhtOTeOJRbCNiO();
		int count = list2.Count;
		for (int i = 0; i < count; i++)
		{
			if (list2[i] != null)
			{
				try
				{
					kvqducHUWPYYsnUhPdQAbkdahByH kvqducHUWPYYsnUhPdQAbkdahByH = list2[i];
					Guid grRuyCwBfgeHmBsXOdUvfoKYTnYA = kvqducHUWPYYsnUhPdQAbkdahByH.GrRuyCwBfgeHmBsXOdUvfoKYTnYA;
					kgqhUexiHegpQmaRUvQyXXyfTECW kgqhUexiHegpQmaRUvQyXXyfTECW = new kgqhUexiHegpQmaRUvQyXXyfTECW(this.CnmGsnGhvZfbjHGrwtffhPSHnFhTA, grRuyCwBfgeHmBsXOdUvfoKYTnYA);
					BSJSvukspMhDBRCHMlHeUJpwHulEA bsjsvukspMhDBRCHMlHeUJpwHulEA = kgqhUexiHegpQmaRUvQyXXyfTECW.hvPlNSFhsvggEswPiOjjzbrDiKPI;
					if (this.uCNgwGFeyJcAMfYKHimEBLrYcPBxB != null)
					{
						string text = kvqducHUWPYYsnUhPdQAbkdahByH.mpinInATOSahiTvRyoVzQGzRrZhK.ToString();
						if (this.uCNgwGFeyJcAMfYKHimEBLrYcPBxB.XZVIPNtjsWKFpBxKFSKwHpIrwBWV(bsjsvukspMhDBRCHMlHeUJpwHulEA.xeNFXbZwkORyeFDHTthLmsyTxNVg, StringTools.SanitizeDeviceString(kvqducHUWPYYsnUhPdQAbkdahByH.tRSbereLEbOcuBSoHTMMJPLqjgRsB), string.Empty, new PidVid(Convert.ToUInt16(text.Substring(0, 4), 16), Convert.ToUInt16(text.Substring(4, 4), 16))))
						{
							goto IL_38A;
						}
					}
					if (!hBuWSCmGcOQpciLbksGnpuoZgfKL.XNYjZDiIVbrmdKmQXabQEVgXZVGv(InputSource.DirectInput, (ushort)bsjsvukspMhDBRCHMlHeUJpwHulEA.UEoJHVcHZVhwjFSkdZlJtXKTLZN, (ushort)bsjsvukspMhDBRCHMlHeUJpwHulEA.NtdCqAHaxHLesCTtePYdjHXgTAsYb, (hBuWSCmGcOQpciLbksGnpuoZgfKL.LgQBOxfTJCrrfnygLkUBaMRumJbgA)3))
					{
						Guid guid = (!string.IsNullOrEmpty(bsjsvukspMhDBRCHMlHeUJpwHulEA.xeNFXbZwkORyeFDHTthLmsyTxNVg)) ? MiscTools.CreateGuidHashSHA256(bsjsvukspMhDBRCHMlHeUJpwHulEA.xeNFXbZwkORyeFDHTthLmsyTxNVg) : kvqducHUWPYYsnUhPdQAbkdahByH.GrRuyCwBfgeHmBsXOdUvfoKYTnYA;
						bool flag = false;
						object obj = this.gTOVpaKLWvpeXQlxzgFLWmOPoBcR;
						lock (obj)
						{
							if (this.hhhkGXnLCgVAHguKOqGMZICCSOHd != null)
							{
								for (int j = 0; j < this.hhhkGXnLCgVAHguKOqGMZICCSOHd.Count; j++)
								{
									if (this.hhhkGXnLCgVAHguKOqGMZICCSOHd[j] != null && this.hhhkGXnLCgVAHguKOqGMZICCSOHd[j].RneUFkExkLizQtBJNpYaTkzLQsU == guid)
									{
										kgqhUexiHegpQmaRUvQyXXyfTECW = this.hhhkGXnLCgVAHguKOqGMZICCSOHd[j].lRryntOJyUEnpJIHHTjrRBhyyqWP.YYTkLtGvCcgvBVSkpDvBuasVgKSy;
										flag = true;
										break;
									}
								}
							}
						}
						EegVRmhDzKlDwgeYQLLOXmqEZyWQ.QdMZFMtlfQhQKDNMJyQwkIRbuYQaA qdMZFMtlfQhQKDNMJyQwkIRbuYQaA = new EegVRmhDzKlDwgeYQLLOXmqEZyWQ.QdMZFMtlfQhQKDNMJyQwkIRbuYQaA(new EegVRmhDzKlDwgeYQLLOXmqEZyWQ.uHXOkpavvZOKwXfuXypTJmiAJZgn(kgqhUexiHegpQmaRUvQyXXyfTECW, this.PsPdnIEDAkAwlDCDVxErcOKCUTNhc), this.IoRdEmBmOUwWuhWpwHZntFGJNjECb);
						qdMZFMtlfQhQKDNMJyQwkIRbuYQaA.cWHbgRrKgDVxjHhwTGXsQLJlbHTp = kvqducHUWPYYsnUhPdQAbkdahByH;
						qdMZFMtlfQhQKDNMJyQwkIRbuYQaA.hsLUMAyVuqppLwcQxJNOFpadnYlt = kvqducHUWPYYsnUhPdQAbkdahByH.jBlggXRihqfdoCjVRfoDjUlRPJmGb;
						qdMZFMtlfQhQKDNMJyQwkIRbuYQaA.RneUFkExkLizQtBJNpYaTkzLQsU = guid;
						qdMZFMtlfQhQKDNMJyQwkIRbuYQaA.SmHizIeggLjJaRsnWQQUDmrAUlYj = StringTools.SanitizeDeviceString(kvqducHUWPYYsnUhPdQAbkdahByH.tRSbereLEbOcuBSoHTMMJPLqjgRsB);
						qdMZFMtlfQhQKDNMJyQwkIRbuYQaA.fJYFdwkLuIyKjpVDFBezgMBcQYuYB = kvqducHUWPYYsnUhPdQAbkdahByH.mpinInATOSahiTvRyoVzQGzRrZhK;
						qdMZFMtlfQhQKDNMJyQwkIRbuYQaA.mLvtBhHmzhpjBduggYCiiNXqbJCG = (EegVRmhDzKlDwgeYQLLOXmqEZyWQ.bDaMPLbvtdjQzowjFMIFQhUBzvdN)kvqducHUWPYYsnUhPdQAbkdahByH.SFzavqABstyxKAPPhtfHxqkKcFBhA;
						ghZTOEuLbhLUtyLpoKRUJSykKPSF ghZTOEuLbhLUtyLpoKRUJSykKPSF = kgqhUexiHegpQmaRUvQyXXyfTECW.FnJHsCgCqMPxbvyMLANMPPhnVEgN;
						qdMZFMtlfQhQKDNMJyQwkIRbuYQaA.fnNibzxaahfglBRRAzaVnwQrEUpC = bsjsvukspMhDBRCHMlHeUJpwHulEA.NtdCqAHaxHLesCTtePYdjHXgTAsYb;
						qdMZFMtlfQhQKDNMJyQwkIRbuYQaA.bKURWVcjoWaxyVrpThCiSYdXaPIo = false;
						try
						{
							qdMZFMtlfQhQKDNMJyQwkIRbuYQaA.ddXGknhInIRfUwVIVxQCrMJecIdWA = bsjsvukspMhDBRCHMlHeUJpwHulEA.kkYLtEsqGUmpxJgyMDbSOtwtwHuN;
						}
						catch (Exception)
						{
							qdMZFMtlfQhQKDNMJyQwkIRbuYQaA.ddXGknhInIRfUwVIVxQCrMJecIdWA = 0;
						}
						qdMZFMtlfQhQKDNMJyQwkIRbuYQaA.ZxbHCNOJtQYRvuDnwItidmVnjdItA = ghZTOEuLbhLUtyLpoKRUJSykKPSF.MzbaDbxFLHHYVrsrGPOOLbXIstMV;
						qdMZFMtlfQhQKDNMJyQwkIRbuYQaA.RaZCtPmgczQBiZFTazHjfpnYLqsE = ghZTOEuLbhLUtyLpoKRUJSykKPSF.OwnJetHJpnnCxrjUGkvOqTDWveMb;
						qdMZFMtlfQhQKDNMJyQwkIRbuYQaA.KyzrzMlEAMdwJomPLzJAmmNTUDA = ghZTOEuLbhLUtyLpoKRUJSykKPSF.nBmohHyAGJEEIDssglbJGJKLXlyWA;
						qdMZFMtlfQhQKDNMJyQwkIRbuYQaA.PkcgYJOjsqdtCHnlgOMgAPhxLZZs = new DirectInputControllerExtension(kvqducHUWPYYsnUhPdQAbkdahByH, kgqhUexiHegpQmaRUvQyXXyfTECW);
						this.eavTaqwNCeysKDdTdejYFRRBHcttA(qdMZFMtlfQhQKDNMJyQwkIRbuYQaA, bsjsvukspMhDBRCHMlHeUJpwHulEA, out qdMZFMtlfQhQKDNMJyQwkIRbuYQaA.pbjudZilNlOsQGegGIIMIXpqjyeaA);
						try
						{
							string text2;
							try
							{
								text2 = bsjsvukspMhDBRCHMlHeUJpwHulEA.RerwfDFBMJnAvgaPpolLVFHnWoJx;
							}
							catch
							{
								text2 = qdMZFMtlfQhQKDNMJyQwkIRbuYQaA.SmHizIeggLjJaRsnWQQUDmrAUlYj;
							}
							int num;
							int num2;
							int num3;
							if (ZdNComFqslNiJEjPlWKZrDATRGNv.XTbaapEVymcglVQwyREaWOCBnNorA((ushort)bsjsvukspMhDBRCHMlHeUJpwHulEA.UEoJHVcHZVhwjFSkdZlJtXKTLZN, (ushort)bsjsvukspMhDBRCHMlHeUJpwHulEA.NtdCqAHaxHLesCTtePYdjHXgTAsYb, text2) && ZdNComFqslNiJEjPlWKZrDATRGNv.ZxvVkOqLoxiOZJPeIPPmItVAcrdX((ushort)bsjsvukspMhDBRCHMlHeUJpwHulEA.UEoJHVcHZVhwjFSkdZlJtXKTLZN, (ushort)bsjsvukspMhDBRCHMlHeUJpwHulEA.NtdCqAHaxHLesCTtePYdjHXgTAsYb, text2, out num, out num2, out num3))
							{
								qdMZFMtlfQhQKDNMJyQwkIRbuYQaA.lRryntOJyUEnpJIHHTjrRBhyyqWP.tgUdYHSqSHLTzvLYgFHtgacpVciO(num, num2, num3, ZdNComFqslNiJEjPlWKZrDATRGNv.iaqRHUaDdTigTGkghiDvpUxbBxRaA((ushort)bsjsvukspMhDBRCHMlHeUJpwHulEA.UEoJHVcHZVhwjFSkdZlJtXKTLZN, (ushort)bsjsvukspMhDBRCHMlHeUJpwHulEA.NtdCqAHaxHLesCTtePYdjHXgTAsYb, text2));
							}
						}
						catch (Exception)
						{
						}
						if (!flag)
						{
							IList<LyiAUWWzjPRwFcxvPTEgvdJUSkUA> list3 = kgqhUexiHegpQmaRUvQyXXyfTECW.qvxlvXlbItcexJtCOoREdDPFrrFqB();
							if (list3 != null)
							{
								for (int k = 0; k < list3.Count; k++)
								{
									if ((list3[k].bjWXMLfHRtGTECgaZOZSCAMQYuzAA.lbKBezcrYXWyPWPaNBDYahtKBlXB & rmFZIqnOsqENbRWsSmclbFIafHVW.Axis) != rmFZIqnOsqENbRWsSmclbFIafHVW.All)
									{
										kgqhUexiHegpQmaRUvQyXXyfTECW.hvPlNSFhsvggEswPiOjjzbrDiKPI.yaEXBaToYwMdgaylhOUXWYbEkjWs = new AWzvRDbHSYHwJyTtCqcXEDbhGjMG(-65535, 65535);
									}
								}
							}
							kgqhUexiHegpQmaRUvQyXXyfTECW.hvPlNSFhsvggEswPiOjjzbrDiKPI.QZofcHCnpzDkYdneTBSHbUjUBLoBb = OleAeJBdBTmGPQCQfMAoieMAfkpT.Absolute;
							kgqhUexiHegpQmaRUvQyXXyfTECW.VRCsuBBElHBZHDdEHBWicxapboYiA(this.cylyowOvSSaiZVuIAnKZcDqYIBHn, hCuHlWkNvEJLgFlbWArBXLYhoYJnA.NonExclusive | hCuHlWkNvEJLgFlbWArBXLYhoYJnA.Background);
							kgqhUexiHegpQmaRUvQyXXyfTECW.NlelwpaktkGsKPPBIiTDwUOUhcXIA();
						}
						list.Add(new EegVRmhDzKlDwgeYQLLOXmqEZyWQ.gjEmKFEtFFvkzEDCLMkMaOflbYfHA(qdMZFMtlfQhQKDNMJyQwkIRbuYQaA, kvqducHUWPYYsnUhPdQAbkdahByH));
					}
				}
				catch (Exception)
				{
				}
			}
			IL_38A:;
		}
		return list;
	}

	// Token: 0x06000066 RID: 102 RVA: 0x000116EE File Offset: 0x0000F8EE
	private void DWUwksQjJUnSQkOkXmCboswGxHoy()
	{
		this.tddTPwpOTzgVfrxCpiSlXBBeZZyj(this.jXFoinbODZRKURIZFJdSRVsymvDj());
	}

	// Token: 0x06000067 RID: 103 RVA: 0x0001FAA8 File Offset: 0x0001DCA8
	private void tddTPwpOTzgVfrxCpiSlXBBeZZyj(List<EegVRmhDzKlDwgeYQLLOXmqEZyWQ.gjEmKFEtFFvkzEDCLMkMaOflbYfHA> A_1)
	{
		List<EegVRmhDzKlDwgeYQLLOXmqEZyWQ.QdMZFMtlfQhQKDNMJyQwkIRbuYQaA> list = new List<EegVRmhDzKlDwgeYQLLOXmqEZyWQ.QdMZFMtlfQhQKDNMJyQwkIRbuYQaA>();
		this.BFbcLYMqrQkGQddyQOxnCaTdcDVfA = 0;
		int num = (A_1 != null) ? A_1.Count : 0;
		for (int i = 0; i < num; i++)
		{
			if (A_1[i] != null && A_1[i].dJbWicDeZmNWrpfusCNnqcXlEieI)
			{
				try
				{
					EegVRmhDzKlDwgeYQLLOXmqEZyWQ.QdMZFMtlfQhQKDNMJyQwkIRbuYQaA cNucNNEhNNaQqNAsTOlCILepcYriA = A_1[i].cNucNNEhNNaQqNAsTOlCILepcYriA;
					cNucNNEhNNaQqNAsTOlCILepcYriA.bmZIsmoUMdjWxTfTtPwKGVvweGtG();
					if (cNucNNEhNNaQqNAsTOlCILepcYriA.OVEfPPRIlXDbOgdxjdJgCvWYkKIab)
					{
						this.BFbcLYMqrQkGQddyQOxnCaTdcDVfA++;
					}
					list.Add(cNucNNEhNNaQqNAsTOlCILepcYriA);
				}
				catch (Exception)
				{
				}
			}
		}
		this.hhINLENVIkwlBYoAqcBIykXWbQfw.LXetPvfTwnUHTTOyXftnhEOdjRpC(this.BFbcLYMqrQkGQddyQOxnCaTdcDVfA);
		object obj = this.gTOVpaKLWvpeXQlxzgFLWmOPoBcR;
		lock (obj)
		{
			List<EegVRmhDzKlDwgeYQLLOXmqEZyWQ.QdMZFMtlfQhQKDNMJyQwkIRbuYQaA> list2 = this.hhhkGXnLCgVAHguKOqGMZICCSOHd;
			int feYGIfijfZlUMeQjTfwWLcKqiTLE = this.FeYGIfijfZlUMeQjTfwWLcKqiTLE;
			int count = list.Count;
			this.VcaSMXiDfpzjAyregmvejwgApIbb(feYGIfijfZlUMeQjTfwWLcKqiTLE, count, list2, list);
			for (int j = 0; j < count; j++)
			{
				if (this._UpdateControllerInfoEvent != null)
				{
					this._UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(list[j]));
				}
			}
			this.FGXrnMulImjhbNnKOzWQqURPJxag(list2, list, false);
			this.FGXrnMulImjhbNnKOzWQqURPJxag(list, list2, true);
			this.OAlMbWlpKkBVNfibSKyNVqDSCIkUA(list, list2);
			this.hhhkGXnLCgVAHguKOqGMZICCSOHd = list;
			this.FeYGIfijfZlUMeQjTfwWLcKqiTLE = list.Count;
		}
	}

	// Token: 0x06000068 RID: 104 RVA: 0x0001FC00 File Offset: 0x0001DE00
	private void eavTaqwNCeysKDdTdejYFRRBHcttA(EegVRmhDzKlDwgeYQLLOXmqEZyWQ.QdMZFMtlfQhQKDNMJyQwkIRbuYQaA A_1, BSJSvukspMhDBRCHMlHeUJpwHulEA A_2, out string A_3)
	{
		A_3 = string.Empty;
		if (A_1 == null || A_2 == null)
		{
			return;
		}
		string text = AdSkHYvPxgeOVFEGslVOiHZEQBxjb.zntnSUJJitVdtJJQJKoubsHXrwF(A_2.xeNFXbZwkORyeFDHTthLmsyTxNVg);
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		try
		{
			gGETNRbPSWqlyBUigXMEkvuRFmnB gGETNRbPSWqlyBUigXMEkvuRFmnB = hVaQpyMLtSMUpozCEslGMGuQGKOz.hmfexoafUrkDGdBwIqakEugEiKqE(text.ToLower(CultureInfo.InvariantCulture));
			if (gGETNRbPSWqlyBUigXMEkvuRFmnB != null)
			{
				A_1.OVEfPPRIlXDbOgdxjdJgCvWYkKIab = gGETNRbPSWqlyBUigXMEkvuRFmnB.uHmffYhTWkNNUoSBeauUySsqVBCEA;
				A_1.ddMieuZkzKEOwpAkfPVdGmrkbTkK = gGETNRbPSWqlyBUigXMEkvuRFmnB.svgWTFfTaOoHwzVJzcBrQWCRKqaj;
				A_3 = hBuWSCmGcOQpciLbksGnpuoZgfKL.KMKBsCYHrmkjpVAYJxIqfUXgAVNk(gGETNRbPSWqlyBUigXMEkvuRFmnB, A_1.fJYFdwkLuIyKjpVDFBezgMBcQYuYB, A_1.SmHizIeggLjJaRsnWQQUDmrAUlYj, A_1.ddMieuZkzKEOwpAkfPVdGmrkbTkK);
				gGETNRbPSWqlyBUigXMEkvuRFmnB.Dispose();
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000069 RID: 105 RVA: 0x0001FC94 File Offset: 0x0001DE94
	private void ihhFtkQyqluOvGYKgELDZVBxCEeX()
	{
		object obj = this.gTOVpaKLWvpeXQlxzgFLWmOPoBcR;
		lock (obj)
		{
			for (int i = 0; i < this.FeYGIfijfZlUMeQjTfwWLcKqiTLE; i++)
			{
				try
				{
					EegVRmhDzKlDwgeYQLLOXmqEZyWQ.QdMZFMtlfQhQKDNMJyQwkIRbuYQaA qdMZFMtlfQhQKDNMJyQwkIRbuYQaA = this.hhhkGXnLCgVAHguKOqGMZICCSOHd[i];
					if (qdMZFMtlfQhQKDNMJyQwkIRbuYQaA != null)
					{
						if (qdMZFMtlfQhQKDNMJyQwkIRbuYQaA.lobXUkAHQlxIccdhomWJuoDJmrVV())
						{
							if (this.qbaspVnkVEWcLMRiajjuCAMzxLHi == null || !qdMZFMtlfQhQKDNMJyQwkIRbuYQaA.bKURWVcjoWaxyVrpThCiSYdXaPIo)
							{
								qdMZFMtlfQhQKDNMJyQwkIRbuYQaA.Update();
							}
						}
					}
				}
				catch
				{
				}
			}
		}
	}

	// Token: 0x0600006A RID: 106 RVA: 0x0001FD28 File Offset: 0x0001DF28
	private IList<kvqducHUWPYYsnUhPdQAbkdahByH> IQEZKzsQqVPENzMhtOTeOJRbCNiO()
	{
		IList<kvqducHUWPYYsnUhPdQAbkdahByH> result;
		try
		{
			IList<kvqducHUWPYYsnUhPdQAbkdahByH> list = this.CnmGsnGhvZfbjHGrwtffhPSHnFhTA.QtGkuGIEojjgvWKUuasAddMRxzwl(SFbUwDPTMspCnXvMvungUBWLzgsP.GameControl, ygHzebjbxdKDQMBRjdWGjwNnmSHd.AttachedOnly);
			this.WinOfJpfUYiZqWkutlJfXdZAZHEt = ((list != null) ? list.Count : 0);
			result = list;
		}
		catch
		{
			Logger.LogError("Error getting devices from Direct Input!");
			this.WinOfJpfUYiZqWkutlJfXdZAZHEt = 0;
			result = EmptyObjects<kvqducHUWPYYsnUhPdQAbkdahByH>.EmptyReadOnlyIListT;
		}
		return result;
	}

	// Token: 0x0600006B RID: 107 RVA: 0x000116FC File Offset: 0x0000F8FC
	private void nyfSCGPcqrRCntrXAPaTXdshyyGc()
	{
		this.CnmGsnGhvZfbjHGrwtffhPSHnFhTA.ogXrcCRHRRiHAdWnzTxlvoimACoj();
	}

	// Token: 0x0600006C RID: 108 RVA: 0x0001FD84 File Offset: 0x0001DF84
	private void VcaSMXiDfpzjAyregmvejwgApIbb(int A_1, int A_2, List<EegVRmhDzKlDwgeYQLLOXmqEZyWQ.QdMZFMtlfQhQKDNMJyQwkIRbuYQaA> A_3, List<EegVRmhDzKlDwgeYQLLOXmqEZyWQ.QdMZFMtlfQhQKDNMJyQwkIRbuYQaA> A_4)
	{
		if (A_2 > 0)
		{
			A_4.Sort(new Comparison<EegVRmhDzKlDwgeYQLLOXmqEZyWQ.QdMZFMtlfQhQKDNMJyQwkIRbuYQaA>(EegVRmhDzKlDwgeYQLLOXmqEZyWQ.QdMZFMtlfQhQKDNMJyQwkIRbuYQaA.aoRqDlkPYYaMxjKcrbJqdlSNIKim));
		}
		if (A_1 > 0 && A_2 > 0)
		{
			this.cSzxOhAIgoKOPomfHGtihxIFdHfP(A_2, A_4, A_1, A_3, EegVRmhDzKlDwgeYQLLOXmqEZyWQ.sOIlNQjlCZQqpGwxzRZguVCPvZdA.URDmmhVnYuFiqjknGrmGiHQjqbHXA.Exact);
		}
		this.QzjwLyduxQhKNfgPsPrawBYvCOZBA(A_2, A_4, EegVRmhDzKlDwgeYQLLOXmqEZyWQ.sOIlNQjlCZQqpGwxzRZguVCPvZdA.URDmmhVnYuFiqjknGrmGiHQjqbHXA.Exact);
		for (int i = 0; i < A_2; i++)
		{
			EegVRmhDzKlDwgeYQLLOXmqEZyWQ.QdMZFMtlfQhQKDNMJyQwkIRbuYQaA qdMZFMtlfQhQKDNMJyQwkIRbuYQaA = A_4[i];
			if (qdMZFMtlfQhQKDNMJyQwkIRbuYQaA != null && qdMZFMtlfQhQKDNMJyQwkIRbuYQaA.inputManagerId < 0)
			{
				qdMZFMtlfQhQKDNMJyQwkIRbuYQaA.inputManagerId = this.hxsZczuyjMhkEdleCIAXaIBesWez(A_4);
				qdMZFMtlfQhQKDNMJyQwkIRbuYQaA.rewiredId = this.pHatMaldmmxnmyHIGDmPrMrvFepS();
				this.jNbAlbkaRRggxdpMFrelmNhGAHEkE.UGdokbizLfwJTGCviGhpfduDeGYAA(qdMZFMtlfQhQKDNMJyQwkIRbuYQaA);
			}
		}
		A_4.Sort(new Comparison<EegVRmhDzKlDwgeYQLLOXmqEZyWQ.QdMZFMtlfQhQKDNMJyQwkIRbuYQaA>(EegVRmhDzKlDwgeYQLLOXmqEZyWQ.QdMZFMtlfQhQKDNMJyQwkIRbuYQaA.tAHGOyWHqnEgarKHfuusVFvVqmIR));
	}

	// Token: 0x0600006D RID: 109 RVA: 0x0001FE2C File Offset: 0x0001E02C
	private void XlzVvafFqtfoUeADWPhQhtxNIDXdb(List<EegVRmhDzKlDwgeYQLLOXmqEZyWQ.QdMZFMtlfQhQKDNMJyQwkIRbuYQaA> A_1, int A_2, int A_3)
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

	// Token: 0x0600006E RID: 110 RVA: 0x0001FE78 File Offset: 0x0001E078
	private bool qttlMcWgbNJflxGZfOadoThYtviD(List<EegVRmhDzKlDwgeYQLLOXmqEZyWQ.QdMZFMtlfQhQKDNMJyQwkIRbuYQaA> A_1, int A_2)
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

	// Token: 0x0600006F RID: 111 RVA: 0x0001FEB4 File Offset: 0x0001E0B4
	private int hxsZczuyjMhkEdleCIAXaIBesWez(List<EegVRmhDzKlDwgeYQLLOXmqEZyWQ.QdMZFMtlfQhQKDNMJyQwkIRbuYQaA> A_1)
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

	// Token: 0x06000070 RID: 112 RVA: 0x0001FF00 File Offset: 0x0001E100
	private bool WpepAzJGPjAuVwiKyghWGHEShvceb(List<EegVRmhDzKlDwgeYQLLOXmqEZyWQ.QdMZFMtlfQhQKDNMJyQwkIRbuYQaA> A_1, int A_2)
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

	// Token: 0x06000071 RID: 113 RVA: 0x0001FF38 File Offset: 0x0001E138
	private void cSzxOhAIgoKOPomfHGtihxIFdHfP(int A_1, List<EegVRmhDzKlDwgeYQLLOXmqEZyWQ.QdMZFMtlfQhQKDNMJyQwkIRbuYQaA> A_2, int A_3, List<EegVRmhDzKlDwgeYQLLOXmqEZyWQ.QdMZFMtlfQhQKDNMJyQwkIRbuYQaA> A_4, EegVRmhDzKlDwgeYQLLOXmqEZyWQ.sOIlNQjlCZQqpGwxzRZguVCPvZdA.URDmmhVnYuFiqjknGrmGiHQjqbHXA A_5)
	{
		int num = (A_5 == EegVRmhDzKlDwgeYQLLOXmqEZyWQ.sOIlNQjlCZQqpGwxzRZguVCPvZdA.URDmmhVnYuFiqjknGrmGiHQjqbHXA.Exact) ? 2 : 1;
		for (int i = 0; i < A_1; i++)
		{
			EegVRmhDzKlDwgeYQLLOXmqEZyWQ.QdMZFMtlfQhQKDNMJyQwkIRbuYQaA qdMZFMtlfQhQKDNMJyQwkIRbuYQaA = A_2[i];
			if (qdMZFMtlfQhQKDNMJyQwkIRbuYQaA != null && qdMZFMtlfQhQKDNMJyQwkIRbuYQaA.inputManagerId < 0)
			{
				for (int j = 0; j < A_3; j++)
				{
					EegVRmhDzKlDwgeYQLLOXmqEZyWQ.QdMZFMtlfQhQKDNMJyQwkIRbuYQaA qdMZFMtlfQhQKDNMJyQwkIRbuYQaA2 = A_4[j];
					if (qdMZFMtlfQhQKDNMJyQwkIRbuYQaA2 != null && !this.WpepAzJGPjAuVwiKyghWGHEShvceb(A_2, qdMZFMtlfQhQKDNMJyQwkIRbuYQaA2.rewiredId) && qdMZFMtlfQhQKDNMJyQwkIRbuYQaA.gtVBdiwFHdPcIoWJBcZhOmhzOlES(qdMZFMtlfQhQKDNMJyQwkIRbuYQaA2) >= num)
					{
						qdMZFMtlfQhQKDNMJyQwkIRbuYQaA.QLuyokfgccRLVDJOWdnvUKneMlwE(qdMZFMtlfQhQKDNMJyQwkIRbuYQaA2);
						this.jNbAlbkaRRggxdpMFrelmNhGAHEkE.UGdokbizLfwJTGCviGhpfduDeGYAA(qdMZFMtlfQhQKDNMJyQwkIRbuYQaA);
					}
				}
			}
		}
	}

	// Token: 0x06000072 RID: 114 RVA: 0x0001FFB8 File Offset: 0x0001E1B8
	private void QzjwLyduxQhKNfgPsPrawBYvCOZBA(int A_1, List<EegVRmhDzKlDwgeYQLLOXmqEZyWQ.QdMZFMtlfQhQKDNMJyQwkIRbuYQaA> A_2, EegVRmhDzKlDwgeYQLLOXmqEZyWQ.sOIlNQjlCZQqpGwxzRZguVCPvZdA.URDmmhVnYuFiqjknGrmGiHQjqbHXA A_3)
	{
		for (int i = 0; i < A_1; i++)
		{
			EegVRmhDzKlDwgeYQLLOXmqEZyWQ.QdMZFMtlfQhQKDNMJyQwkIRbuYQaA qdMZFMtlfQhQKDNMJyQwkIRbuYQaA = A_2[i];
			if (qdMZFMtlfQhQKDNMJyQwkIRbuYQaA != null && qdMZFMtlfQhQKDNMJyQwkIRbuYQaA.inputManagerId < 0)
			{
				EegVRmhDzKlDwgeYQLLOXmqEZyWQ.sOIlNQjlCZQqpGwxzRZguVCPvZdA.qfiPwkxItqSfpsAEKkCrrzGgsfhX qfiPwkxItqSfpsAEKkCrrzGgsfhX = null;
				foreach (EegVRmhDzKlDwgeYQLLOXmqEZyWQ.sOIlNQjlCZQqpGwxzRZguVCPvZdA.qfiPwkxItqSfpsAEKkCrrzGgsfhX qfiPwkxItqSfpsAEKkCrrzGgsfhX2 in this.jNbAlbkaRRggxdpMFrelmNhGAHEkE.ygTdDuvQvayurANURgaBoKuheDgE(qdMZFMtlfQhQKDNMJyQwkIRbuYQaA, A_3))
				{
					if (!this.WpepAzJGPjAuVwiKyghWGHEShvceb(A_2, qfiPwkxItqSfpsAEKkCrrzGgsfhX2.MgWDBqxcpiJGrlGaGqodLbilbdbfA) && qfiPwkxItqSfpsAEKkCrrzGgsfhX2.TwFDDOcvkIlULXypJwcymdRfuUHEA >= 0)
					{
						qfiPwkxItqSfpsAEKkCrrzGgsfhX = qfiPwkxItqSfpsAEKkCrrzGgsfhX2;
						break;
					}
				}
				if (qfiPwkxItqSfpsAEKkCrrzGgsfhX != null)
				{
					int num = qfiPwkxItqSfpsAEKkCrrzGgsfhX.TwFDDOcvkIlULXypJwcymdRfuUHEA;
					if (!this.qttlMcWgbNJflxGZfOadoThYtviD(A_2, num))
					{
						num = this.hxsZczuyjMhkEdleCIAXaIBesWez(A_2);
						qfiPwkxItqSfpsAEKkCrrzGgsfhX.TwFDDOcvkIlULXypJwcymdRfuUHEA = num;
					}
					qdMZFMtlfQhQKDNMJyQwkIRbuYQaA.inputManagerId = num;
					qdMZFMtlfQhQKDNMJyQwkIRbuYQaA.rewiredId = qfiPwkxItqSfpsAEKkCrrzGgsfhX.MgWDBqxcpiJGrlGaGqodLbilbdbfA;
					this.jNbAlbkaRRggxdpMFrelmNhGAHEkE.UGdokbizLfwJTGCviGhpfduDeGYAA(qdMZFMtlfQhQKDNMJyQwkIRbuYQaA);
				}
			}
		}
	}

	// Token: 0x06000073 RID: 115 RVA: 0x0001170A File Offset: 0x0000F90A
	private void jrAIVJlfmKpCwIiKrEDbDouKOasCb()
	{
		if (this.HurSbJUDSZtLROKBZtTKgxAEynTg)
		{
			this.rNyXDKMMYdlJpfhmlUtejphnwhk();
		}
		if (this.mIJCKHadPPbbpPiYIKwJFrShUHSe.dEuWrWEuMuRLEfvelqBlJqCXPzLm && this.mIJCKHadPPbbpPiYIKwJFrShUHSe.tyWUOmZxIPUWAGNTSMzHnebuMTZT())
		{
			this.OTgHFAfjmUdrApGEJpKARYUDiqym(this.mIJCKHadPPbbpPiYIKwJFrShUHSe.jPEZROqMpmOrikUBVDIpnrJrIBJO);
		}
	}

	// Token: 0x06000074 RID: 116 RVA: 0x00011745 File Offset: 0x0000F945
	private void rNyXDKMMYdlJpfhmlUtejphnwhk()
	{
		this.HurSbJUDSZtLROKBZtTKgxAEynTg = false;
		if (this.mIJCKHadPPbbpPiYIKwJFrShUHSe.dEuWrWEuMuRLEfvelqBlJqCXPzLm)
		{
			return;
		}
		this.mIJCKHadPPbbpPiYIKwJFrShUHSe.VlWTpnOmouJNHovmWjtCiEYLYIbj();
	}

	// Token: 0x06000075 RID: 117 RVA: 0x00011768 File Offset: 0x0000F968
	private void OTgHFAfjmUdrApGEJpKARYUDiqym(List<EegVRmhDzKlDwgeYQLLOXmqEZyWQ.gjEmKFEtFFvkzEDCLMkMaOflbYfHA> A_1)
	{
		if (this.BYAAUpazFVrlxJFdQKKfdfhMdzsI(EegVRmhDzKlDwgeYQLLOXmqEZyWQ.gjEmKFEtFFvkzEDCLMkMaOflbYfHA.quJvFBwkngcsqAwHOIdfgwkzOJsAA(A_1)))
		{
			this.tddTPwpOTzgVfrxCpiSlXBBeZZyj(A_1);
		}
	}

	// Token: 0x06000076 RID: 118 RVA: 0x0002009C File Offset: 0x0001E29C
	private bool BYAAUpazFVrlxJFdQKKfdfhMdzsI(IList<kvqducHUWPYYsnUhPdQAbkdahByH> A_1)
	{
		object obj = this.gTOVpaKLWvpeXQlxzgFLWmOPoBcR;
		lock (obj)
		{
			int count = A_1.Count;
			for (int i = 0; i < count; i++)
			{
				if (A_1[i] != null && !this.BPdRxJoCPkzgdwEEqtPPwmivQWF(A_1[i].GrRuyCwBfgeHmBsXOdUvfoKYTnYA))
				{
					return true;
				}
			}
			int count2 = this.hhhkGXnLCgVAHguKOqGMZICCSOHd.Count;
			for (int j = 0; j < count2; j++)
			{
				if (this.hhhkGXnLCgVAHguKOqGMZICCSOHd[j] != null && !this.SZhvNdLAQTdHHfjRGnXmwePOjunC(A_1, this.hhhkGXnLCgVAHguKOqGMZICCSOHd[j].instanceGuid))
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06000077 RID: 119 RVA: 0x00020160 File Offset: 0x0001E360
	private bool BPdRxJoCPkzgdwEEqtPPwmivQWF(Guid A_1)
	{
		object obj = this.gTOVpaKLWvpeXQlxzgFLWmOPoBcR;
		lock (obj)
		{
			int count = this.hhhkGXnLCgVAHguKOqGMZICCSOHd.Count;
			for (int i = 0; i < count; i++)
			{
				if (this.hhhkGXnLCgVAHguKOqGMZICCSOHd[i] != null && this.hhhkGXnLCgVAHguKOqGMZICCSOHd[i].instanceGuid == A_1)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06000078 RID: 120 RVA: 0x000201E4 File Offset: 0x0001E3E4
	private bool SZhvNdLAQTdHHfjRGnXmwePOjunC(IList<kvqducHUWPYYsnUhPdQAbkdahByH> A_1, Guid A_2)
	{
		int count = A_1.Count;
		for (int i = 0; i < count; i++)
		{
			if (A_1[i] != null && A_1[i].GrRuyCwBfgeHmBsXOdUvfoKYTnYA == A_2)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000079 RID: 121 RVA: 0x00020224 File Offset: 0x0001E424
	private void FGXrnMulImjhbNnKOzWQqURPJxag(List<EegVRmhDzKlDwgeYQLLOXmqEZyWQ.QdMZFMtlfQhQKDNMJyQwkIRbuYQaA> A_1, List<EegVRmhDzKlDwgeYQLLOXmqEZyWQ.QdMZFMtlfQhQKDNMJyQwkIRbuYQaA> A_2, bool A_3)
	{
		if (A_1 == null)
		{
			return;
		}
		int num = (A_1 != null) ? A_1.Count : 0;
		int num2 = (A_2 != null) ? A_2.Count : 0;
		for (int i = 0; i < num; i++)
		{
			EegVRmhDzKlDwgeYQLLOXmqEZyWQ.QdMZFMtlfQhQKDNMJyQwkIRbuYQaA qdMZFMtlfQhQKDNMJyQwkIRbuYQaA = A_1[i];
			if (qdMZFMtlfQhQKDNMJyQwkIRbuYQaA != null)
			{
				bool flag = false;
				if (A_2 != null)
				{
					for (int j = 0; j < num2; j++)
					{
						EegVRmhDzKlDwgeYQLLOXmqEZyWQ.QdMZFMtlfQhQKDNMJyQwkIRbuYQaA qdMZFMtlfQhQKDNMJyQwkIRbuYQaA2 = A_2[j];
						if (qdMZFMtlfQhQKDNMJyQwkIRbuYQaA2 != null && qdMZFMtlfQhQKDNMJyQwkIRbuYQaA.instanceGuid == qdMZFMtlfQhQKDNMJyQwkIRbuYQaA2.instanceGuid)
						{
							flag = true;
							break;
						}
					}
				}
				if (!flag)
				{
					this.NlEnzqPUHxnYfjcAGFUOgfSdGrLh(A_1[i], A_3);
				}
			}
		}
	}

	// Token: 0x0600007A RID: 122 RVA: 0x0001177F File Offset: 0x0000F97F
	private void NlEnzqPUHxnYfjcAGFUOgfSdGrLh(EegVRmhDzKlDwgeYQLLOXmqEZyWQ.QdMZFMtlfQhQKDNMJyQwkIRbuYQaA A_1, bool A_2)
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

	// Token: 0x0600007B RID: 123 RVA: 0x000202B8 File Offset: 0x0001E4B8
	private bool yonDUYcEvygJZZUIYBEGLNzIMqxyA()
	{
		int num = this.CnmGsnGhvZfbjHGrwtffhPSHnFhTA.SerKKfYzathThHUDMrkDSWCwoEqe(SFbUwDPTMspCnXvMvungUBWLzgsP.GameControl, ygHzebjbxdKDQMBRjdWGjwNnmSHd.AttachedOnly);
		if (this.WinOfJpfUYiZqWkutlJfXdZAZHEt != num)
		{
			this.WinOfJpfUYiZqWkutlJfXdZAZHEt = num;
			return true;
		}
		return this.BFbcLYMqrQkGQddyQOxnCaTdcDVfA > 0 && this.hhINLENVIkwlBYoAqcBIykXWbQfw.JcdGaIKyfKrHBnyNverthqBwyExGA();
	}

	// Token: 0x0600007C RID: 124 RVA: 0x00020300 File Offset: 0x0001E500
	private void OAlMbWlpKkBVNfibSKyNVqDSCIkUA(List<EegVRmhDzKlDwgeYQLLOXmqEZyWQ.QdMZFMtlfQhQKDNMJyQwkIRbuYQaA> A_1, List<EegVRmhDzKlDwgeYQLLOXmqEZyWQ.QdMZFMtlfQhQKDNMJyQwkIRbuYQaA> A_2)
	{
		if (A_2 == null)
		{
			return;
		}
		for (int i = 0; i < A_2.Count; i++)
		{
			if (A_2[i] != null && (A_1 == null || !A_1.Contains(A_2[i])))
			{
				A_2[i].vZEnfhtMlzetAJbqBxIxKygDXCjQA();
			}
		}
	}

	// Token: 0x0600007D RID: 125 RVA: 0x000117B7 File Offset: 0x0000F9B7
	[Conditional("DEBUGTHIS")]
	private void tExDJUarJounxqvmDcUrCqEJriQbB(string A_1)
	{
		Logger.Log(A_1);
	}

	// Token: 0x0600007E RID: 126 RVA: 0x000117BF File Offset: 0x0000F9BF
	[CompilerGenerated]
	private List<EegVRmhDzKlDwgeYQLLOXmqEZyWQ.gjEmKFEtFFvkzEDCLMkMaOflbYfHA> QbWtwstiOIuCkxdambpvhseynHQq()
	{
		return this.jXFoinbODZRKURIZFJdSRVsymvDj();
	}

	// Token: 0x04000034 RID: 52
	private const SFbUwDPTMspCnXvMvungUBWLzgsP IfUVrbCaLSsrzgQcNELiIrXWMLdk = SFbUwDPTMspCnXvMvungUBWLzgsP.GameControl;

	// Token: 0x04000035 RID: 53
	private const ygHzebjbxdKDQMBRjdWGjwNnmSHd qPcHQgTMbRDlGNFihzlEoLGTmwKG = ygHzebjbxdKDQMBRjdWGjwNnmSHd.AttachedOnly;

	// Token: 0x04000036 RID: 54
	private IntPtr cylyowOvSSaiZVuIAnKZcDqYIBHn;

	// Token: 0x04000037 RID: 55
	private dksOLhBwLeCynZJmOfwlOOcWOZLI CnmGsnGhvZfbjHGrwtffhPSHnFhTA;

	// Token: 0x04000038 RID: 56
	private List<EegVRmhDzKlDwgeYQLLOXmqEZyWQ.QdMZFMtlfQhQKDNMJyQwkIRbuYQaA> hhhkGXnLCgVAHguKOqGMZICCSOHd;

	// Token: 0x04000039 RID: 57
	private int FeYGIfijfZlUMeQjTfwWLcKqiTLE;

	// Token: 0x0400003A RID: 58
	private EegVRmhDzKlDwgeYQLLOXmqEZyWQ.sOIlNQjlCZQqpGwxzRZguVCPvZdA jNbAlbkaRRggxdpMFrelmNhGAHEkE;

	// Token: 0x0400003B RID: 59
	private bool HurSbJUDSZtLROKBZtTKgxAEynTg;

	// Token: 0x0400003C RID: 60
	private xKKbjmIOHiqxZGRJDfbeyLuvTjMwB uCNgwGFeyJcAMfYKHimEBLrYcPBxB;

	// Token: 0x0400003D RID: 61
	private UpdateLoopSetting PsPdnIEDAkAwlDCDVxErcOKCUTNhc;

	// Token: 0x0400003E RID: 62
	private Action<int, ControllerDataUpdater> RvuAuaQuywqVvbtoOvDueWPEnlt;

	// Token: 0x0400003F RID: 63
	private PlatformInputManager FVDByzSqkCpSnovdYlNuOaIEEwie;

	// Token: 0x04000040 RID: 64
	private TimerRealTime fFgAksVRvnDGqWJVTNOdPOzBfNcCA;

	// Token: 0x04000041 RID: 65
	private UHsWCAvrjUBCvVSiOhWZLujgvmAM<bool> frqLMYqKStdCdbmIfoHjMmsukrHZ;

	// Token: 0x04000042 RID: 66
	private EegVRmhDzKlDwgeYQLLOXmqEZyWQ.JXeosiJzHZtCjnOuUAKmKMkIbjpl hhINLENVIkwlBYoAqcBIykXWbQfw;

	// Token: 0x04000043 RID: 67
	private int BFbcLYMqrQkGQddyQOxnCaTdcDVfA;

	// Token: 0x04000044 RID: 68
	private int WinOfJpfUYiZqWkutlJfXdZAZHEt;

	// Token: 0x04000045 RID: 69
	private UHsWCAvrjUBCvVSiOhWZLujgvmAM<List<EegVRmhDzKlDwgeYQLLOXmqEZyWQ.gjEmKFEtFFvkzEDCLMkMaOflbYfHA>> mIJCKHadPPbbpPiYIKwJFrShUHSe;

	// Token: 0x04000046 RID: 70
	private readonly object gTOVpaKLWvpeXQlxzgFLWmOPoBcR = new object();

	// Token: 0x04000047 RID: 71
	private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> IoRdEmBmOUwWuhWpwHZntFGJNjECb;

	// Token: 0x04000048 RID: 72
	private Func<int> pHatMaldmmxnmyHIGDmPrMrvFepS;

	// Token: 0x0200000B RID: 11
	private class QdMZFMtlfQhQKDNMJyQwkIRbuYQaA : IInputManagerJoystick, IInputManagerJoystickPublic
	{
		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600007F RID: 127 RVA: 0x000117C7 File Offset: 0x0000F9C7
		// (set) Token: 0x06000080 RID: 128 RVA: 0x000117CF File Offset: 0x0000F9CF
		[CustomObfuscation(rename = false)]
		public int rewiredId
		{
			get
			{
				return this.TUbxeTeGRpMirktkYWsBtiwfUxve;
			}
			set
			{
				this.TUbxeTeGRpMirktkYWsBtiwfUxve = value;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000081 RID: 129 RVA: 0x000117D8 File Offset: 0x0000F9D8
		// (set) Token: 0x06000082 RID: 130 RVA: 0x000117E0 File Offset: 0x0000F9E0
		[CustomObfuscation(rename = false)]
		public int inputManagerId
		{
			get
			{
				return this.kerjVeMXxTYVsdKJsJlBlAzFpVAP;
			}
			set
			{
				this.kerjVeMXxTYVsdKJsJlBlAzFpVAP = value;
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000083 RID: 131 RVA: 0x000117E9 File Offset: 0x0000F9E9
		[CustomObfuscation(rename = false)]
		public string name
		{
			get
			{
				if (this.zGKszhsxwpnJzbPNTBkmqUIOpPPT != "Unknown Controller")
				{
					return this.zGKszhsxwpnJzbPNTBkmqUIOpPPT;
				}
				if (this.OVEfPPRIlXDbOgdxjdJgCvWYkKIab && !string.IsNullOrEmpty(this.ddMieuZkzKEOwpAkfPVdGmrkbTkK))
				{
					return this.ddMieuZkzKEOwpAkfPVdGmrkbTkK;
				}
				return this.SmHizIeggLjJaRsnWQQUDmrAUlYj;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000084 RID: 132 RVA: 0x0002034C File Offset: 0x0001E54C
		[CustomObfuscation(rename = false)]
		public long? systemId
		{
			get
			{
				if (this.kerjVeMXxTYVsdKJsJlBlAzFpVAP < 0)
				{
					return null;
				}
				return new long?((long)this.kerjVeMXxTYVsdKJsJlBlAzFpVAP);
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000085 RID: 133 RVA: 0x00011826 File Offset: 0x0000FA26
		[CustomObfuscation(rename = false)]
		public int unityId
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000086 RID: 134 RVA: 0x00011829 File Offset: 0x0000FA29
		[CustomObfuscation(rename = false)]
		public Controller.Extension extension
		{
			get
			{
				return this.PkcgYJOjsqdtCHnlgOMgAPhxLZZs;
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000087 RID: 135 RVA: 0x00011831 File Offset: 0x0000FA31
		[CustomObfuscation(rename = false)]
		public Guid instanceGuid
		{
			get
			{
				return this.RneUFkExkLizQtBJNpYaTkzLQsU;
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000088 RID: 136 RVA: 0x00011839 File Offset: 0x0000FA39
		[CustomObfuscation(rename = false)]
		public Guid persistentGuid
		{
			get
			{
				return this.instanceGuid;
			}
		}

		// Token: 0x06000089 RID: 137 RVA: 0x000116E9 File Offset: 0x0000F8E9
		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
		}

		// Token: 0x0600008A RID: 138 RVA: 0x000116E9 File Offset: 0x0000F8E9
		[CustomObfuscation(rename = false)]
		public void StopVibration()
		{
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00011841 File Offset: 0x0000FA41
		public QdMZFMtlfQhQKDNMJyQwkIRbuYQaA(EegVRmhDzKlDwgeYQLLOXmqEZyWQ.uHXOkpavvZOKwXfuXypTJmiAJZgn A_1, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> A_2)
		{
			this.lRryntOJyUEnpJIHHTjrRBhyyqWP = A_1;
			this.ohoAZzJGtlcPvjOSObUycedltaldA = A_2;
			this.kerjVeMXxTYVsdKJsJlBlAzFpVAP = -1;
			this.TUbxeTeGRpMirktkYWsBtiwfUxve = -1;
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00020378 File Offset: 0x0001E578
		public void bmZIsmoUMdjWxTfTtPwKGVvweGtG()
		{
			string smHizIeggLjJaRsnWQQUDmrAUlYj = this.SmHizIeggLjJaRsnWQQUDmrAUlYj;
			Guid guid = this.fJYFdwkLuIyKjpVDFBezgMBcQYuYB;
			this.RZUnguYnAqioSHleZpmJBfjffmWrB = MiscTools.CreateGuidHashSHA1(smHizIeggLjJaRsnWQQUDmrAUlYj + guid.ToString());
			this.jptemwkqgUMZYuzyrCwEcjbhgGbi = this.ZxbHCNOJtQYRvuDnwItidmVnjdItA;
			this.SfutihFDfbviNpsMwkTrhJZeyNLw = this.RaZCtPmgczQBiZFTazHjfpnYLqsE + this.KyzrzMlEAMdwJomPLzJAmmNTUDA * 8;
			this.EGIuwMiWbIMfWURMxFsAcwxwBtqi();
			this.CIrmLfUVIqatGkslxgtzskOsXIZw = this.xmTzpFeHCToIGBHrzyrGKaNMvncg.hardwareMapIdentifier.guid;
			this.zGKszhsxwpnJzbPNTBkmqUIOpPPT = this.xmTzpFeHCToIGBHrzyrGKaNMvncg.controllerName;
			this.IsMjROLROOfEhSxwRbogtdurTMwj = (this.CIrmLfUVIqatGkslxgtzskOsXIZw == Guid.Empty);
			this.qkigRsvItDcmLBkcDwXcEriRAUmEA = new float[this.jptemwkqgUMZYuzyrCwEcjbhgGbi];
			this.DBJjJqcRhWQREkoaxsdEGdpobbUdb = new bool[this.SfutihFDfbviNpsMwkTrhJZeyNLw];
			this.lRryntOJyUEnpJIHHTjrRBhyyqWP.EwWQnIbwGkIImiuTATMxtVqjpkAe();
			this.Update();
		}

		// Token: 0x0600008D RID: 141 RVA: 0x0002044C File Offset: 0x0001E64C
		public void QLuyokfgccRLVDJOWdnvUKneMlwE(EegVRmhDzKlDwgeYQLLOXmqEZyWQ.QdMZFMtlfQhQKDNMJyQwkIRbuYQaA A_1)
		{
			if (A_1 == null)
			{
				return;
			}
			this.kerjVeMXxTYVsdKJsJlBlAzFpVAP = A_1.kerjVeMXxTYVsdKJsJlBlAzFpVAP;
			this.TUbxeTeGRpMirktkYWsBtiwfUxve = A_1.TUbxeTeGRpMirktkYWsBtiwfUxve;
			for (int i = 0; i < MathTools.Min(this.DBJjJqcRhWQREkoaxsdEGdpobbUdb.Length, A_1.DBJjJqcRhWQREkoaxsdEGdpobbUdb.Length); i++)
			{
				this.DBJjJqcRhWQREkoaxsdEGdpobbUdb[i] = A_1.DBJjJqcRhWQREkoaxsdEGdpobbUdb[i];
			}
			for (int j = 0; j < MathTools.Min(this.qkigRsvItDcmLBkcDwXcEriRAUmEA.Length, A_1.qkigRsvItDcmLBkcDwXcEriRAUmEA.Length); j++)
			{
				this.qkigRsvItDcmLBkcDwXcEriRAUmEA[j] = A_1.qkigRsvItDcmLBkcDwXcEriRAUmEA[j];
			}
			this.uqEeeVhRqNzimYVJEjICEIPqncBJ = A_1.uqEeeVhRqNzimYVJEjICEIPqncBJ;
			this.lRryntOJyUEnpJIHHTjrRBhyyqWP.EyCQvMoKQyIENCUHgpHuApnieOvGA(A_1.lRryntOJyUEnpJIHHTjrRBhyyqWP);
		}

		// Token: 0x0600008E RID: 142 RVA: 0x000204F4 File Offset: 0x0001E6F4
		[CustomObfuscation(rename = false)]
		public void Update()
		{
			this.lRryntOJyUEnpJIHHTjrRBhyyqWP.nyRjiQnetKGIYAqlGhEKFIapXgZoA();
			bool[] array = this.lRryntOJyUEnpJIHHTjrRBhyyqWP.XFRyGxhegdgwErpBaVPXxOioQbuO;
			int[] karmNfoTiicECFgoKUGkdVNfusoW = this.lRryntOJyUEnpJIHHTjrRBhyyqWP.uWSzngmoZSfoUCqQaBfrNtLTaLCSA.KARmNfoTiicECFgoKUGkdVNfusoW;
			this.DhLEBKJJnhJWnIvepyPcJPbmoXTTA(array, karmNfoTiicECFgoKUGkdVNfusoW);
			this.SqIbkGqEmslzCCkOSWGsPPGwcQTJ(array, karmNfoTiicECFgoKUGkdVNfusoW);
			this.lRryntOJyUEnpJIHHTjrRBhyyqWP.LEtQgdgxWVlIazrPOjNKOnhmUUhl();
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00020544 File Offset: 0x0001E744
		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (this.jptemwkqgUMZYuzyrCwEcjbhgGbi != dataUpdater.axisCount || this.SfutihFDfbviNpsMwkTrhJZeyNLw != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			for (int i = 0; i < this.jptemwkqgUMZYuzyrCwEcjbhgGbi; i++)
			{
				dataUpdater.axisValues[i] = this.qkigRsvItDcmLBkcDwXcEriRAUmEA[i];
			}
			for (int j = 0; j < this.SfutihFDfbviNpsMwkTrhJZeyNLw; j++)
			{
				dataUpdater.buttonValues[j] = this.DBJjJqcRhWQREkoaxsdEGdpobbUdb[j];
			}
			if (this.uqEeeVhRqNzimYVJEjICEIPqncBJ && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		// Token: 0x06000090 RID: 144 RVA: 0x000205D4 File Offset: 0x0001E7D4
		public int gtVBdiwFHdPcIoWJBcZhOmhzOlES(EegVRmhDzKlDwgeYQLLOXmqEZyWQ.QdMZFMtlfQhQKDNMJyQwkIRbuYQaA A_1)
		{
			if (A_1.TUbxeTeGRpMirktkYWsBtiwfUxve == this.TUbxeTeGRpMirktkYWsBtiwfUxve)
			{
				return 2;
			}
			if (this.ZxbHCNOJtQYRvuDnwItidmVnjdItA != A_1.ZxbHCNOJtQYRvuDnwItidmVnjdItA)
			{
				return 0;
			}
			if (this.RaZCtPmgczQBiZFTazHjfpnYLqsE != A_1.RaZCtPmgczQBiZFTazHjfpnYLqsE)
			{
				return 0;
			}
			if (this.KyzrzMlEAMdwJomPLzJAmmNTUDA != A_1.KyzrzMlEAMdwJomPLzJAmmNTUDA)
			{
				return 0;
			}
			if (A_1.instanceGuid == this.instanceGuid)
			{
				return 2;
			}
			if (A_1.RZUnguYnAqioSHleZpmJBfjffmWrB == this.RZUnguYnAqioSHleZpmJBfjffmWrB)
			{
				return 1;
			}
			return 0;
		}

		// Token: 0x06000091 RID: 145 RVA: 0x0002064C File Offset: 0x0001E84C
		private BridgedControllerHWInfo HUiDriNoRGcODFEzjKngrAofIues()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			this.OWQJgiibyXkQBuPdhEXxhkhRVxqTA(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00020668 File Offset: 0x0001E868
		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			this.NUHYgQPNnOqVttzEznziXHiyiGDH(bridgedController);
			return bridgedController;
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00011865 File Offset: 0x0000FA65
		[CustomObfuscation(rename = false)]
		public ControllerDisconnectedEventArgs ToControllerDisconnectedEventArgs()
		{
			return new ControllerDisconnectedEventArgs(this.TUbxeTeGRpMirktkYWsBtiwfUxve);
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00020684 File Offset: 0x0001E884
		public bool lobXUkAHQlxIccdhomWJuoDJmrVV()
		{
			bool result;
			try
			{
				this.lRryntOJyUEnpJIHHTjrRBhyyqWP.YYTkLtGvCcgvBVSkpDvBuasVgKSy.tFsssbGQIPkPHrLNdyPgBPzWVize();
				result = true;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000095 RID: 149 RVA: 0x000206BC File Offset: 0x0001E8BC
		public void SafKUfHeqkrCroSPxGwXAoScRvYq()
		{
			try
			{
				if (this.lRryntOJyUEnpJIHHTjrRBhyyqWP.YYTkLtGvCcgvBVSkpDvBuasVgKSy != null)
				{
					this.lRryntOJyUEnpJIHHTjrRBhyyqWP.YYTkLtGvCcgvBVSkpDvBuasVgKSy.NlelwpaktkGsKPPBIiTDwUOUhcXIA();
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000096 RID: 150 RVA: 0x000206FC File Offset: 0x0001E8FC
		public void dwtAeYnlyxlpBJRMiAYgINMAYYwm()
		{
			try
			{
				if (this.lRryntOJyUEnpJIHHTjrRBhyyqWP.YYTkLtGvCcgvBVSkpDvBuasVgKSy != null)
				{
					this.lRryntOJyUEnpJIHHTjrRBhyyqWP.YYTkLtGvCcgvBVSkpDvBuasVgKSy.azTjTWrVAOAlWADiYwJQncVvorTU();
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000097 RID: 151 RVA: 0x0002073C File Offset: 0x0001E93C
		private void DhLEBKJJnhJWnIvepyPcJPbmoXTTA(bool[] A_1, int[] A_2)
		{
			if (this.jptemwkqgUMZYuzyrCwEcjbhgGbi <= 0)
			{
				return;
			}
			InputPlatform platform = this.xmTzpFeHCToIGBHrzyrGKaNMvncg.map.platform;
			if (platform == InputPlatform.WindowsRawInput)
			{
				HardwareJoystickMap.Platform_RawInput_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_RawInput_Base)this.xmTzpFeHCToIGBHrzyrGKaNMvncg.map).Axes_orig;
				if (axes_orig == null)
				{
					return;
				}
				for (int i = 0; i < axes_orig.Length; i++)
				{
					this.hwpBHQHmMbYBwTGHtwRagFufPJag(axes_orig[i], i, A_1, A_2);
				}
				return;
			}
			else
			{
				if (platform != InputPlatform.WindowsDirectInput)
				{
					return;
				}
				HardwareJoystickMap.Platform_DirectInput_Base.Axis[] axes_orig2 = ((HardwareJoystickMap.Platform_DirectInput_Base)this.xmTzpFeHCToIGBHrzyrGKaNMvncg.map).Axes_orig;
				if (axes_orig2 == null)
				{
					return;
				}
				for (int j = 0; j < axes_orig2.Length; j++)
				{
					this.hwpBHQHmMbYBwTGHtwRagFufPJag(axes_orig2[j], j, A_1, A_2);
				}
				return;
			}
		}

		// Token: 0x06000098 RID: 152 RVA: 0x000207DC File Offset: 0x0001E9DC
		private void SqIbkGqEmslzCCkOSWGsPPGwcQTJ(bool[] A_1, int[] A_2)
		{
			if (this.SfutihFDfbviNpsMwkTrhJZeyNLw <= 0)
			{
				return;
			}
			InputPlatform platform = this.xmTzpFeHCToIGBHrzyrGKaNMvncg.map.platform;
			if (platform == InputPlatform.WindowsRawInput)
			{
				HardwareJoystickMap.Platform_RawInput_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_RawInput_Base)this.xmTzpFeHCToIGBHrzyrGKaNMvncg.map).Buttons_orig;
				if (buttons_orig == null)
				{
					return;
				}
				for (int i = 0; i < buttons_orig.Length; i++)
				{
					this.OwdLYuMjymVustYIoHZkqIMdnFNc(buttons_orig[i], i, A_1, A_2);
				}
				return;
			}
			else
			{
				if (platform != InputPlatform.WindowsDirectInput)
				{
					return;
				}
				HardwareJoystickMap.Platform_DirectInput_Base.Button[] buttons_orig2 = ((HardwareJoystickMap.Platform_DirectInput_Base)this.xmTzpFeHCToIGBHrzyrGKaNMvncg.map).Buttons_orig;
				if (buttons_orig2 == null)
				{
					return;
				}
				for (int j = 0; j < buttons_orig2.Length; j++)
				{
					this.OwdLYuMjymVustYIoHZkqIMdnFNc(buttons_orig2[j], j, A_1, A_2);
				}
				return;
			}
		}

		// Token: 0x06000099 RID: 153 RVA: 0x0002087C File Offset: 0x0001EA7C
		private void hwpBHQHmMbYBwTGHtwRagFufPJag(HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base A_1, int A_2, bool[] A_3, int[] A_4)
		{
			if (A_2 >= this.jptemwkqgUMZYuzyrCwEcjbhgGbi)
			{
				throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
			}
			this.qkigRsvItDcmLBkcDwXcEriRAUmEA[A_2] = this.EiPGiomrZgGWBOUugWZjcKKEwWfH(A_1, A_3, A_4);
			if (!this.uqEeeVhRqNzimYVJEjICEIPqncBJ && this.qkigRsvItDcmLBkcDwXcEriRAUmEA[A_2] != 0f)
			{
				this.uqEeeVhRqNzimYVJEjICEIPqncBJ = true;
			}
		}

		// Token: 0x0600009A RID: 154 RVA: 0x000208D0 File Offset: 0x0001EAD0
		private void OwdLYuMjymVustYIoHZkqIMdnFNc(HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base A_1, int A_2, bool[] A_3, int[] A_4)
		{
			if (A_2 >= this.SfutihFDfbviNpsMwkTrhJZeyNLw)
			{
				throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
			}
			this.DBJjJqcRhWQREkoaxsdEGdpobbUdb[A_2] = this.DaCrAqTjQIfGAkigQyEyjbXDYsumA(A_1, A_3, A_4);
			if (!this.uqEeeVhRqNzimYVJEjICEIPqncBJ && this.DBJjJqcRhWQREkoaxsdEGdpobbUdb[A_2])
			{
				this.uqEeeVhRqNzimYVJEjICEIPqncBJ = true;
			}
		}

		// Token: 0x0600009B RID: 155 RVA: 0x0002091C File Offset: 0x0001EB1C
		private float EiPGiomrZgGWBOUugWZjcKKEwWfH(HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base A_1, bool[] A_2, int[] A_3)
		{
			if (A_1.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				if (A_1.sourceAxis <= 0 || A_1.sourceAxis >= 32)
				{
					return 0f;
				}
				return this.oGIvCfBEGMUAALlCwrUtzyQBNNqq((DirectInputAxis)A_1.sourceAxis);
			}
			else if (A_1.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				int sourceButton = A_1.sourceButton;
				if (sourceButton < 0 || sourceButton >= this.RaZCtPmgczQBiZFTazHjfpnYLqsE || sourceButton >= 128)
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
				if (sourceHat < 0 || sourceHat >= this.KyzrzMlEAMdwJomPLzJAmmNTUDA || sourceHat >= 4)
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
					num2 = this.TRvEHcckgpPWydbquMNhEsPtSSTEA(num, AxisDirection.Horizontal);
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
					num2 = this.TRvEHcckgpPWydbquMNhEsPtSSTEA(num, AxisDirection.Vertical);
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
					if (customCalculationSourceData[i] != null && customCalculationSourceData[i].sourceType == 1 && this.EhDqjpgcSNRkJIhjrInAOdgJAYNU(customCalculationSourceData[i], out item))
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

		// Token: 0x0600009C RID: 156 RVA: 0x00020B2C File Offset: 0x0001ED2C
		private float oGIvCfBEGMUAALlCwrUtzyQBNNqq(DirectInputAxis A_1)
		{
			float result;
			switch (A_1)
			{
			case DirectInputAxis.X:
				result = this.lRryntOJyUEnpJIHHTjrRBhyyqWP.uWSzngmoZSfoUCqQaBfrNtLTaLCSA.csNhoLCceKSoLSCzsHQARKYuBOqHA;
				break;
			case DirectInputAxis.Y:
				result = this.lRryntOJyUEnpJIHHTjrRBhyyqWP.uWSzngmoZSfoUCqQaBfrNtLTaLCSA.HEFdmhNOcjPiwqKpOnPFVTcGOyZJ;
				break;
			case DirectInputAxis.Z:
				result = this.lRryntOJyUEnpJIHHTjrRBhyyqWP.uWSzngmoZSfoUCqQaBfrNtLTaLCSA.GfEOiDvakbKYfFhjATHIUQvEuOdV;
				break;
			case DirectInputAxis.RotationX:
				result = this.lRryntOJyUEnpJIHHTjrRBhyyqWP.uWSzngmoZSfoUCqQaBfrNtLTaLCSA.ufVGRPcwoncdAmOxfurPGcpzVzVC;
				break;
			case DirectInputAxis.RotationY:
				result = this.lRryntOJyUEnpJIHHTjrRBhyyqWP.uWSzngmoZSfoUCqQaBfrNtLTaLCSA.VkQVLxiKbsICyCTgADtESUZAHPBK;
				break;
			case DirectInputAxis.RotationZ:
				result = this.lRryntOJyUEnpJIHHTjrRBhyyqWP.uWSzngmoZSfoUCqQaBfrNtLTaLCSA.eFDCcqDpxvpLXMrHMfIXnxvEVrJDA;
				break;
			case DirectInputAxis.Slider0:
				result = this.lRryntOJyUEnpJIHHTjrRBhyyqWP.uWSzngmoZSfoUCqQaBfrNtLTaLCSA.LPKVgGNdyleGriFyiKhyYyFbQXKC[0];
				break;
			case DirectInputAxis.Slider1:
				result = this.lRryntOJyUEnpJIHHTjrRBhyyqWP.uWSzngmoZSfoUCqQaBfrNtLTaLCSA.LPKVgGNdyleGriFyiKhyYyFbQXKC[1];
				break;
			case DirectInputAxis.VelocityX:
				result = this.lRryntOJyUEnpJIHHTjrRBhyyqWP.uWSzngmoZSfoUCqQaBfrNtLTaLCSA.JOnaQBHvhDvcOqpRiFWqNYcLtOWKA;
				break;
			case DirectInputAxis.VelocityY:
				result = this.lRryntOJyUEnpJIHHTjrRBhyyqWP.uWSzngmoZSfoUCqQaBfrNtLTaLCSA.aXtXIHlAlXUctmHDvLkHjacbriS;
				break;
			case DirectInputAxis.VelocityZ:
				result = this.lRryntOJyUEnpJIHHTjrRBhyyqWP.uWSzngmoZSfoUCqQaBfrNtLTaLCSA.cBtQNbMRKJQIpvnXxyUeMCvtMdeb;
				break;
			case DirectInputAxis.AngularVelocityX:
				result = this.lRryntOJyUEnpJIHHTjrRBhyyqWP.uWSzngmoZSfoUCqQaBfrNtLTaLCSA.GZuusnBjeIwsNsBaigOIhqNrqwYpA;
				break;
			case DirectInputAxis.AngularVelocityY:
				result = this.lRryntOJyUEnpJIHHTjrRBhyyqWP.uWSzngmoZSfoUCqQaBfrNtLTaLCSA.mgqqwDUgchcCYjFtpzQAWamrlTzAb;
				break;
			case DirectInputAxis.AngularVelocityZ:
				result = this.lRryntOJyUEnpJIHHTjrRBhyyqWP.uWSzngmoZSfoUCqQaBfrNtLTaLCSA.RHrQGGmLHzxJgfjbcYxpsyJsjaoC;
				break;
			case DirectInputAxis.VelocitySlider0:
				result = this.lRryntOJyUEnpJIHHTjrRBhyyqWP.uWSzngmoZSfoUCqQaBfrNtLTaLCSA.CJJvnrocegtMKXFvvDjVKBmWOXZIA[0];
				break;
			case DirectInputAxis.VelocitySlider1:
				result = this.lRryntOJyUEnpJIHHTjrRBhyyqWP.uWSzngmoZSfoUCqQaBfrNtLTaLCSA.CJJvnrocegtMKXFvvDjVKBmWOXZIA[1];
				break;
			case DirectInputAxis.AccelerationX:
				result = this.lRryntOJyUEnpJIHHTjrRBhyyqWP.uWSzngmoZSfoUCqQaBfrNtLTaLCSA.fWFDiddsrvsQhcNPhsKfqiNqhyxMA;
				break;
			case DirectInputAxis.AccelerationY:
				result = this.lRryntOJyUEnpJIHHTjrRBhyyqWP.uWSzngmoZSfoUCqQaBfrNtLTaLCSA.nLVLYbCUXYFBdVwrOoryyhZiZrao;
				break;
			case DirectInputAxis.AccelerationZ:
				result = this.lRryntOJyUEnpJIHHTjrRBhyyqWP.uWSzngmoZSfoUCqQaBfrNtLTaLCSA.OttHwKqmmhEXiXCymsKAnCCvDtYA;
				break;
			case DirectInputAxis.AngularAccelerationX:
				result = this.lRryntOJyUEnpJIHHTjrRBhyyqWP.uWSzngmoZSfoUCqQaBfrNtLTaLCSA.samjFOXdeDhuyGEyDBtIlhhnnmLl;
				break;
			case DirectInputAxis.AngularAccelerationY:
				result = this.lRryntOJyUEnpJIHHTjrRBhyyqWP.uWSzngmoZSfoUCqQaBfrNtLTaLCSA.UniaeUQHNKoDqDHqCJEslWrrWpbM;
				break;
			case DirectInputAxis.AngularAccelerationZ:
				result = this.lRryntOJyUEnpJIHHTjrRBhyyqWP.uWSzngmoZSfoUCqQaBfrNtLTaLCSA.mImnJtiYOrbbfvyKfkTvlGVBkNGp;
				break;
			case DirectInputAxis.AccelerationSlider0:
				result = this.lRryntOJyUEnpJIHHTjrRBhyyqWP.uWSzngmoZSfoUCqQaBfrNtLTaLCSA.HrRmvXcbfMMbgboYgefJjzdgIAgC[0];
				break;
			case DirectInputAxis.AccelerationSlider1:
				result = this.lRryntOJyUEnpJIHHTjrRBhyyqWP.uWSzngmoZSfoUCqQaBfrNtLTaLCSA.HrRmvXcbfMMbgboYgefJjzdgIAgC[1];
				break;
			case DirectInputAxis.ForceX:
				result = this.lRryntOJyUEnpJIHHTjrRBhyyqWP.uWSzngmoZSfoUCqQaBfrNtLTaLCSA.PaWBBuhAWYGxFNzItrKVuBbUkCbhb;
				break;
			case DirectInputAxis.ForceY:
				result = this.lRryntOJyUEnpJIHHTjrRBhyyqWP.uWSzngmoZSfoUCqQaBfrNtLTaLCSA.RUvoEapOtoagOkHFlBkfpLBBiJzS;
				break;
			case DirectInputAxis.ForceZ:
				result = this.lRryntOJyUEnpJIHHTjrRBhyyqWP.uWSzngmoZSfoUCqQaBfrNtLTaLCSA.oYZzJcNVZcxhYwOLKCQkuscbTire;
				break;
			case DirectInputAxis.TorqueX:
				result = this.lRryntOJyUEnpJIHHTjrRBhyyqWP.uWSzngmoZSfoUCqQaBfrNtLTaLCSA.CZpFtEgWjchGtUgwWuDDPsuOXqNwA;
				break;
			case DirectInputAxis.TorqueY:
				result = this.lRryntOJyUEnpJIHHTjrRBhyyqWP.uWSzngmoZSfoUCqQaBfrNtLTaLCSA.CCmJYBCUXzLRfnoJMRYiECLZAdQI;
				break;
			case DirectInputAxis.TorqueZ:
				result = this.lRryntOJyUEnpJIHHTjrRBhyyqWP.uWSzngmoZSfoUCqQaBfrNtLTaLCSA.eWzXMQEHZsFwAcXvgklesQFTNldm;
				break;
			case DirectInputAxis.ForceSlider0:
				result = this.lRryntOJyUEnpJIHHTjrRBhyyqWP.uWSzngmoZSfoUCqQaBfrNtLTaLCSA.vbwwNpbOOvicnTFqKZmcKcxQiTGU[0];
				break;
			case DirectInputAxis.ForceSlider1:
				result = this.lRryntOJyUEnpJIHHTjrRBhyyqWP.uWSzngmoZSfoUCqQaBfrNtLTaLCSA.vbwwNpbOOvicnTFqKZmcKcxQiTGU[1];
				break;
			default:
				return 0f;
			}
			return result;
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00020E88 File Offset: 0x0001F088
		private bool DaCrAqTjQIfGAkigQyEyjbXDYsumA(HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base A_1, bool[] A_2, int[] A_3)
		{
			if (A_1.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				if (A_1.ignoreIfButtonsActive)
				{
					for (int i = 0; i < A_1.ignoreIfButtonsActiveButtons.Length; i++)
					{
						if (A_2[A_1.ignoreIfButtonsActiveButtons[i]])
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
						if (!A_2[A_1.requiredButtons[j]])
						{
							return false;
						}
						result = true;
					}
					return result;
				}
				int sourceButton = A_1.sourceButton;
				return sourceButton >= 0 && sourceButton < this.RaZCtPmgczQBiZFTazHjfpnYLqsE && sourceButton < 128 && A_2[sourceButton];
			}
			else
			{
				if (A_1.sourceType != HardwareElementSourceTypeWithHat.Axis)
				{
					if (A_1.sourceType == HardwareElementSourceTypeWithHat.Hat)
					{
						int sourceHat = A_1.sourceHat;
						if (sourceHat < 0 || sourceHat >= this.KyzrzMlEAMdwJomPLzJAmmNTUDA || sourceHat >= 4)
						{
							return false;
						}
						switch (A_1.sourceHatDirection)
						{
						case HatDirection.Up:
							return this.HULIHOlBbBrQRkyrekvhvEnecOve(A_3[sourceHat], 0, A_1.sourceHatType);
						case HatDirection.Right:
							return this.HULIHOlBbBrQRkyrekvhvEnecOve(A_3[sourceHat], 2, A_1.sourceHatType);
						case HatDirection.Down:
							return this.HULIHOlBbBrQRkyrekvhvEnecOve(A_3[sourceHat], 4, A_1.sourceHatType);
						case HatDirection.Left:
							return this.HULIHOlBbBrQRkyrekvhvEnecOve(A_3[sourceHat], 6, A_1.sourceHatType);
						case HatDirection.UpRight:
							return this.HULIHOlBbBrQRkyrekvhvEnecOve(A_3[sourceHat], 1, A_1.sourceHatType);
						case HatDirection.DownRight:
							return this.HULIHOlBbBrQRkyrekvhvEnecOve(A_3[sourceHat], 3, A_1.sourceHatType);
						case HatDirection.DownLeft:
							return this.HULIHOlBbBrQRkyrekvhvEnecOve(A_3[sourceHat], 5, A_1.sourceHatType);
						case HatDirection.UpLeft:
							return this.HULIHOlBbBrQRkyrekvhvEnecOve(A_3[sourceHat], 7, A_1.sourceHatType);
						}
					}
					else if (A_1.sourceType == HardwareElementSourceTypeWithHat.Custom)
					{
						CustomCalculation customCalculation = A_1.customCalculation;
						if (customCalculation == null)
						{
							return false;
						}
						if (customCalculation.ResultType != TypeWrapper.DataType.Single)
						{
							return false;
						}
						HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData[] customCalculationSourceData = A_1.customCalculationSourceData;
						if (customCalculationSourceData == null)
						{
							return false;
						}
						for (int k = 0; k < customCalculationSourceData.Length; k++)
						{
							if (customCalculationSourceData[k] != null)
							{
								HardwareElementSourceTypeWithHat sourceType = (HardwareElementSourceTypeWithHat)customCalculationSourceData[k].sourceType;
								bool flag;
								if (sourceType != HardwareElementSourceTypeWithHat.Button)
								{
									if (sourceType == HardwareElementSourceTypeWithHat.Axis)
									{
										float num;
										if (this.EhDqjpgcSNRkJIhjrInAOdgJAYNU(customCalculationSourceData[k], out num))
										{
											customCalculation.AddData((num != 0f) ? 1f : 0f);
										}
									}
								}
								else if (this.mfDdYYRjRjRVAroSeVaTbrhoFFjA(customCalculationSourceData[k], A_2, out flag))
								{
									customCalculation.AddData(flag ? 1f : 0f);
								}
							}
						}
						return customCalculation.Process() && customCalculation.Result.type == TypeWrapper.DataType.Single && customCalculation.Result != 0f;
					}
					return false;
				}
				if (A_1.sourceAxis <= 0 || A_1.sourceAxis > 32)
				{
					return false;
				}
				float num2 = this.oGIvCfBEGMUAALlCwrUtzyQBNNqq((DirectInputAxis)A_1.sourceAxis);
				if (MathTools.Abs(num2) <= A_1.axisDeadZone)
				{
					return false;
				}
				if (A_1.sourceAxisPole == Pole.Positive)
				{
					if (num2 < 0f)
					{
						return false;
					}
				}
				else if (num2 > 0f)
				{
					return false;
				}
				return true;
			}
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00021160 File Offset: 0x0001F360
		private bool HULIHOlBbBrQRkyrekvhvEnecOve(int A_1, int A_2, HatType A_3)
		{
			if (A_1 < 0)
			{
				return false;
			}
			if (this.xmTzpFeHCToIGBHrzyrGKaNMvncg.isUnknownController && !InputTools.HandleForced4WayHatsOnUnknownControllers(A_2, ref A_3))
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

		// Token: 0x0600009F RID: 159 RVA: 0x000211DC File Offset: 0x0001F3DC
		private float TRvEHcckgpPWydbquMNhEsPtSSTEA(int A_1, AxisDirection A_2)
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

		// Token: 0x060000A0 RID: 160 RVA: 0x00021250 File Offset: 0x0001F450
		private bool mfDdYYRjRjRVAroSeVaTbrhoFFjA(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData A_1, bool[] A_2, out bool A_3)
		{
			A_3 = false;
			if (A_1.sourceType != 0)
			{
				return false;
			}
			int sourceButton = A_1.sourceButton;
			if (sourceButton < 0 || sourceButton >= this.RaZCtPmgczQBiZFTazHjfpnYLqsE || sourceButton >= 128)
			{
				return false;
			}
			A_3 = A_2[sourceButton];
			return true;
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00021290 File Offset: 0x0001F490
		private bool EhDqjpgcSNRkJIhjrInAOdgJAYNU(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData A_1, out float A_2)
		{
			A_2 = 0f;
			if (A_1.sourceType != 1)
			{
				return false;
			}
			if (A_1.sourceAxis <= 0 || A_1.sourceAxis >= 32)
			{
				return false;
			}
			A_2 = this.oGIvCfBEGMUAALlCwrUtzyQBNNqq((DirectInputAxis)A_1.sourceAxis);
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

		// Token: 0x060000A2 RID: 162 RVA: 0x00011872 File Offset: 0x0000FA72
		private ControlDeviceType rZcqhONbauhBIzfDDMFVeghpjeTkA(EegVRmhDzKlDwgeYQLLOXmqEZyWQ.bDaMPLbvtdjQzowjFMIFQhUBzvdN A_1)
		{
			if (A_1 == EegVRmhDzKlDwgeYQLLOXmqEZyWQ.bDaMPLbvtdjQzowjFMIFQhUBzvdN.Keyboard)
			{
				return ControlDeviceType.Keyboard;
			}
			if (A_1 == EegVRmhDzKlDwgeYQLLOXmqEZyWQ.bDaMPLbvtdjQzowjFMIFQhUBzvdN.Joystick)
			{
				return ControlDeviceType.Joystick;
			}
			if (A_1 == EegVRmhDzKlDwgeYQLLOXmqEZyWQ.bDaMPLbvtdjQzowjFMIFQhUBzvdN.Gamepad)
			{
				return ControlDeviceType.Gamepad;
			}
			if (A_1 == EegVRmhDzKlDwgeYQLLOXmqEZyWQ.bDaMPLbvtdjQzowjFMIFQhUBzvdN.Mouse)
			{
				return ControlDeviceType.Mouse;
			}
			if (A_1 == EegVRmhDzKlDwgeYQLLOXmqEZyWQ.bDaMPLbvtdjQzowjFMIFQhUBzvdN.Flight)
			{
				return ControlDeviceType.Flight;
			}
			if (A_1 == EegVRmhDzKlDwgeYQLLOXmqEZyWQ.bDaMPLbvtdjQzowjFMIFQhUBzvdN.Driving)
			{
				return ControlDeviceType.Wheel;
			}
			return ControlDeviceType.Unknown;
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x000213A4 File Offset: 0x0001F5A4
		private void EGIuwMiWbIMfWURMxFsAcwxwBtqi()
		{
			this.xmTzpFeHCToIGBHrzyrGKaNMvncg = this.ohoAZzJGtlcPvjOSObUycedltaldA(this.HUiDriNoRGcODFEzjKngrAofIues());
			if (this.xmTzpFeHCToIGBHrzyrGKaNMvncg == null)
			{
				Logger.LogError("Default hardware map not found!");
				return;
			}
			this.jptemwkqgUMZYuzyrCwEcjbhgGbi = this.xmTzpFeHCToIGBHrzyrGKaNMvncg.axisCount;
			this.SfutihFDfbviNpsMwkTrhJZeyNLw = this.xmTzpFeHCToIGBHrzyrGKaNMvncg.buttonCount;
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x000116E9 File Offset: 0x0000F8E9
		private void mFUltohInZsthjiBzPKOnCqkLSCD()
		{
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00021400 File Offset: 0x0001F600
		private string zxWDWIUWkyXkywFaQjfeBYHOCTzvA()
		{
			return InputTools.FormatHardwareIdentifierString(string.Format("{0}{1}{2}{3}{4}", new object[]
			{
				ReInput.currentPlatform.ToString(),
				InputSource.DirectInput,
				(this.OVEfPPRIlXDbOgdxjdJgCvWYkKIab && !string.IsNullOrEmpty(this.ddMieuZkzKEOwpAkfPVdGmrkbTkK)) ? this.ddMieuZkzKEOwpAkfPVdGmrkbTkK : this.SmHizIeggLjJaRsnWQQUDmrAUlYj,
				this.fnNibzxaahfglBRRAzaVnwQrEUpC.ToString("X4"),
				new PidVid(this.fJYFdwkLuIyKjpVDFBezgMBcQYuYB).vendorId.ToString("X4")
			}));
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x0002149C File Offset: 0x0001F69C
		private void OWQJgiibyXkQBuPdhEXxhkhRVxqTA(BridgedControllerHWInfo A_1)
		{
			A_1.inputManagerSource = InputSource.DirectInput;
			A_1.inputSource = A_1.inputManagerSource;
			A_1.deviceType = this.rZcqhONbauhBIzfDDMFVeghpjeTkA(this.mLvtBhHmzhpjBduggYCiiNXqbJCG);
			A_1.hardwareIdentifier = this.zxWDWIUWkyXkywFaQjfeBYHOCTzvA();
			A_1.hardwareAxisCount = this.ZxbHCNOJtQYRvuDnwItidmVnjdItA;
			A_1.hardwareButtonCount = this.RaZCtPmgczQBiZFTazHjfpnYLqsE;
			A_1.hardwareHatCount = this.KyzrzMlEAMdwJomPLzJAmmNTUDA;
			A_1.hw_productName = this.SmHizIeggLjJaRsnWQQUDmrAUlYj;
			A_1.hw_deviceGuid = this.instanceGuid;
			A_1.hw_productId = this.fnNibzxaahfglBRRAzaVnwQrEUpC;
			A_1.hw_pidVid = new PidVid(this.fJYFdwkLuIyKjpVDFBezgMBcQYuYB);
			A_1.hw_isBluetoothDevice = this.OVEfPPRIlXDbOgdxjdJgCvWYkKIab;
			A_1.hw_bluetoothDeviceName = ((!string.IsNullOrEmpty(this.ddMieuZkzKEOwpAkfPVdGmrkbTkK)) ? this.ddMieuZkzKEOwpAkfPVdGmrkbTkK : string.Empty);
			A_1.definitionMatchTag = this.pbjudZilNlOsQGegGIIMIXpqjyeaA;
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x0002156C File Offset: 0x0001F76C
		private void NUHYgQPNnOqVttzEznziXHiyiGDH(BridgedController A_1)
		{
			this.OWQJgiibyXkQBuPdhEXxhkhRVxqTA(A_1);
			A_1.sourceJoystick = this;
			A_1.gameHardwareMap = this.xmTzpFeHCToIGBHrzyrGKaNMvncg.ToGameHardwareControllerMap();
			A_1.instanceName = this.hsLUMAyVuqppLwcQxJNOFpadnYlt;
			A_1.productName = this.SmHizIeggLjJaRsnWQQUDmrAUlYj;
			A_1.isXInputDevice = this.bKURWVcjoWaxyVrpThCiSYdXaPIo;
			A_1.axisCount = this.jptemwkqgUMZYuzyrCwEcjbhgGbi;
			A_1.buttonCount = this.SfutihFDfbviNpsMwkTrhJZeyNLw;
			A_1.unknownControllerHats = this.yxTWezzdrwLJYYorgVcAYbZQHbZQ();
			A_1.controllerTypeGuid = this.CIrmLfUVIqatGkslxgtzskOsXIZw;
			A_1.controllerExtension = this.extension;
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x000215F8 File Offset: 0x0001F7F8
		private void DlDiRjVXVghDTlJKxQExCYlPpgvq()
		{
			for (int i = 0; i < this.SfutihFDfbviNpsMwkTrhJZeyNLw; i++)
			{
				this.DBJjJqcRhWQREkoaxsdEGdpobbUdb[i] = false;
			}
			for (int j = 0; j < this.jptemwkqgUMZYuzyrCwEcjbhgGbi; j++)
			{
				this.qkigRsvItDcmLBkcDwXcEriRAUmEA[j] = 0f;
			}
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00021640 File Offset: 0x0001F840
		private UnknownControllerHat[] yxTWezzdrwLJYYorgVcAYbZQHbZQ()
		{
			if (!this.IsMjROLROOfEhSxwRbogtdurTMwj)
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

		// Token: 0x060000AA RID: 170 RVA: 0x000118A1 File Offset: 0x0000FAA1
		public void vZEnfhtMlzetAJbqBxIxKygDXCjQA()
		{
			this.XwcCsuKSxVrVljWMnksdHffswLCAA(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x060000AB RID: 171 RVA: 0x000216B8 File Offset: 0x0001F8B8
		protected virtual void OyveOxFxxMmOLHCTzIswckonouOW()
		{
			try
			{
				this.XwcCsuKSxVrVljWMnksdHffswLCAA(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		// Token: 0x060000AC RID: 172 RVA: 0x000118B0 File Offset: 0x0000FAB0
		protected virtual void XwcCsuKSxVrVljWMnksdHffswLCAA(bool A_1)
		{
			if (this.mJabiVMkqVlaupgRVTTxzhKEqCOS)
			{
				return;
			}
			if (A_1 && this.lRryntOJyUEnpJIHHTjrRBhyyqWP != null)
			{
				this.lRryntOJyUEnpJIHHTjrRBhyyqWP.Dispose();
			}
			this.mJabiVMkqVlaupgRVTTxzhKEqCOS = true;
		}

		// Token: 0x060000AD RID: 173 RVA: 0x000118D8 File Offset: 0x0000FAD8
		public static int tAHGOyWHqnEgarKHfuusVFvVqmIR(EegVRmhDzKlDwgeYQLLOXmqEZyWQ.QdMZFMtlfQhQKDNMJyQwkIRbuYQaA A_0, EegVRmhDzKlDwgeYQLLOXmqEZyWQ.QdMZFMtlfQhQKDNMJyQwkIRbuYQaA A_1)
		{
			if (A_0.kerjVeMXxTYVsdKJsJlBlAzFpVAP < A_1.kerjVeMXxTYVsdKJsJlBlAzFpVAP)
			{
				return -1;
			}
			if (A_0.kerjVeMXxTYVsdKJsJlBlAzFpVAP > A_1.kerjVeMXxTYVsdKJsJlBlAzFpVAP)
			{
				return 1;
			}
			return 0;
		}

		// Token: 0x060000AE RID: 174 RVA: 0x000118FB File Offset: 0x0000FAFB
		public static int aoRqDlkPYYaMxjKcrbJqdlSNIKim(EegVRmhDzKlDwgeYQLLOXmqEZyWQ.QdMZFMtlfQhQKDNMJyQwkIRbuYQaA A_0, EegVRmhDzKlDwgeYQLLOXmqEZyWQ.QdMZFMtlfQhQKDNMJyQwkIRbuYQaA A_1)
		{
			if (A_0.ddXGknhInIRfUwVIVxQCrMJecIdWA < A_1.ddXGknhInIRfUwVIVxQCrMJecIdWA)
			{
				return -1;
			}
			if (A_0.ddXGknhInIRfUwVIVxQCrMJecIdWA > A_1.ddXGknhInIRfUwVIVxQCrMJecIdWA)
			{
				return 1;
			}
			return 0;
		}

		// Token: 0x04000049 RID: 73
		private int TUbxeTeGRpMirktkYWsBtiwfUxve;

		// Token: 0x0400004A RID: 74
		private int kerjVeMXxTYVsdKJsJlBlAzFpVAP;

		// Token: 0x0400004B RID: 75
		public Guid CIrmLfUVIqatGkslxgtzskOsXIZw;

		// Token: 0x0400004C RID: 76
		public string zGKszhsxwpnJzbPNTBkmqUIOpPPT;

		// Token: 0x0400004D RID: 77
		public readonly EegVRmhDzKlDwgeYQLLOXmqEZyWQ.uHXOkpavvZOKwXfuXypTJmiAJZgn lRryntOJyUEnpJIHHTjrRBhyyqWP;

		// Token: 0x0400004E RID: 78
		public kvqducHUWPYYsnUhPdQAbkdahByH cWHbgRrKgDVxjHhwTGXsQLJlbHTp;

		// Token: 0x0400004F RID: 79
		public EegVRmhDzKlDwgeYQLLOXmqEZyWQ.bDaMPLbvtdjQzowjFMIFQhUBzvdN mLvtBhHmzhpjBduggYCiiNXqbJCG;

		// Token: 0x04000050 RID: 80
		public string hsLUMAyVuqppLwcQxJNOFpadnYlt;

		// Token: 0x04000051 RID: 81
		public string SmHizIeggLjJaRsnWQQUDmrAUlYj;

		// Token: 0x04000052 RID: 82
		public int fnNibzxaahfglBRRAzaVnwQrEUpC;

		// Token: 0x04000053 RID: 83
		public Guid RneUFkExkLizQtBJNpYaTkzLQsU;

		// Token: 0x04000054 RID: 84
		public Guid fJYFdwkLuIyKjpVDFBezgMBcQYuYB;

		// Token: 0x04000055 RID: 85
		public Guid RZUnguYnAqioSHleZpmJBfjffmWrB;

		// Token: 0x04000056 RID: 86
		public int ddXGknhInIRfUwVIVxQCrMJecIdWA;

		// Token: 0x04000057 RID: 87
		public bool OVEfPPRIlXDbOgdxjdJgCvWYkKIab;

		// Token: 0x04000058 RID: 88
		public string ddMieuZkzKEOwpAkfPVdGmrkbTkK;

		// Token: 0x04000059 RID: 89
		public string pbjudZilNlOsQGegGIIMIXpqjyeaA;

		// Token: 0x0400005A RID: 90
		public int jptemwkqgUMZYuzyrCwEcjbhgGbi;

		// Token: 0x0400005B RID: 91
		public int SfutihFDfbviNpsMwkTrhJZeyNLw;

		// Token: 0x0400005C RID: 92
		public int ZxbHCNOJtQYRvuDnwItidmVnjdItA;

		// Token: 0x0400005D RID: 93
		public int RaZCtPmgczQBiZFTazHjfpnYLqsE;

		// Token: 0x0400005E RID: 94
		public int KyzrzMlEAMdwJomPLzJAmmNTUDA;

		// Token: 0x0400005F RID: 95
		public bool bKURWVcjoWaxyVrpThCiSYdXaPIo;

		// Token: 0x04000060 RID: 96
		public Controller.Extension PkcgYJOjsqdtCHnlgOMgAPhxLZZs;

		// Token: 0x04000061 RID: 97
		private float[] qkigRsvItDcmLBkcDwXcEriRAUmEA;

		// Token: 0x04000062 RID: 98
		private bool[] DBJjJqcRhWQREkoaxsdEGdpobbUdb;

		// Token: 0x04000063 RID: 99
		private HardwareJoystickMap_InputManager xmTzpFeHCToIGBHrzyrGKaNMvncg;

		// Token: 0x04000064 RID: 100
		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> ohoAZzJGtlcPvjOSObUycedltaldA;

		// Token: 0x04000065 RID: 101
		private bool IsMjROLROOfEhSxwRbogtdurTMwj;

		// Token: 0x04000066 RID: 102
		private bool uqEeeVhRqNzimYVJEjICEIPqncBJ;

		// Token: 0x04000067 RID: 103
		private bool mJabiVMkqVlaupgRVTTxzhKEqCOS;
	}

	// Token: 0x0200000C RID: 12
	private class uHXOkpavvZOKwXfuXypTJmiAJZgn : IDisposable
	{
		// Token: 0x17000018 RID: 24
		// (get) Token: 0x060000AF RID: 175 RVA: 0x0001191E File Offset: 0x0000FB1E
		public bool[] XFRyGxhegdgwErpBaVPXxOioQbuO
		{
			get
			{
				return this.PkLlpsXwefMkJLsxiSgFXQLXwyrL.Current.effectiveValue;
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x060000B0 RID: 176 RVA: 0x00011930 File Offset: 0x0000FB30
		public EegVRmhDzKlDwgeYQLLOXmqEZyWQ.uHXOkpavvZOKwXfuXypTJmiAJZgn.mlXdlDcxlttCfBRCMjTxeyBoIrzN uWSzngmoZSfoUCqQaBfrNtLTaLCSA
		{
			get
			{
				return this.anYcIJrturhviTKOlZJRmXlEKXji;
			}
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x000216E8 File Offset: 0x0001F8E8
		public uHXOkpavvZOKwXfuXypTJmiAJZgn(kgqhUexiHegpQmaRUvQyXXyfTECW A_1, UpdateLoopSetting A_2)
		{
			this.YYTkLtGvCcgvBVSkpDvBuasVgKSy = A_1;
			this.RLbdNQMNOdtBNNtSworxHEDrzquv = A_1.FnJHsCgCqMPxbvyMLANMPPhnVEgN.OwnJetHJpnnCxrjUGkvOqTDWveMb;
			this.PkLlpsXwefMkJLsxiSgFXQLXwyrL = new ButtonLoopSet(A_2, this.RLbdNQMNOdtBNNtSworxHEDrzquv);
			this.rClnvHtDEQsEwrWfRECZVgJdvkvx = new DualThreadLowLevelInputEventQueue((int)((float)jbcfMDoFeBFAQElVePZhKkwUdctNA.dHcfLGecBdWpOuQXknheqwKuIFtT * 0.25f), 128, 32, 2);
			this.anYcIJrturhviTKOlZJRmXlEKXji = new EegVRmhDzKlDwgeYQLLOXmqEZyWQ.uHXOkpavvZOKwXfuXypTJmiAJZgn.mlXdlDcxlttCfBRCMjTxeyBoIrzN();
			this.TcssSADrvKSfAKGUAoueQJLtADDi = new YYJpESzECVBzlTQDCRWMYdxQsJmw();
			this.lHioYhlethcyeBssckDdQTgSBEgtA = new YYJpESzECVBzlTQDCRWMYdxQsJmw();
			this.AtMxxMEYXDqFqDrrxdonHTrDdIDO = new object();
			if (jbcfMDoFeBFAQElVePZhKkwUdctNA.ZDYmSbdCWXNMZFZsjWAgCzkVkDMh != null)
			{
				jbcfMDoFeBFAQElVePZhKkwUdctNA.ZDYmSbdCWXNMZFZsjWAgCzkVkDMh.ThreadUpdateEvent += this.UfddkzhXxGpfWFTMblilDIMngDeNA;
			}
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00011938 File Offset: 0x0000FB38
		public void nyRjiQnetKGIYAqlGhEKFIapXgZoA()
		{
			this.PkLlpsXwefMkJLsxiSgFXQLXwyrL.SetUpdateLoop(ReInput.currentUpdateLoop);
			this.vOkWVPyRJEGkQNdVlkHNUlBskdmQ();
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00011950 File Offset: 0x0000FB50
		public void LEtQgdgxWVlIazrPOjNKOnhmUUhl()
		{
			this.PkLlpsXwefMkJLsxiSgFXQLXwyrL.Current.ClearWasTrueThisFrame();
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00011962 File Offset: 0x0000FB62
		public void EwWQnIbwGkIImiuTATMxtVqjpkAe()
		{
			this.YfbKMSbJHWmQwkSymjJHwlAjICiJA();
			this.cjiBcgSVyrrxaZutVKMZJHwXwGtH = true;
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00011971 File Offset: 0x0000FB71
		public void xqCyHtUPzBEQXmjKRcokiaybAFqTA()
		{
			this.cjiBcgSVyrrxaZutVKMZJHwXwGtH = false;
			this.YfbKMSbJHWmQwkSymjJHwlAjICiJA();
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00021790 File Offset: 0x0001F990
		public void EyCQvMoKQyIENCUHgpHuApnieOvGA(EegVRmhDzKlDwgeYQLLOXmqEZyWQ.uHXOkpavvZOKwXfuXypTJmiAJZgn A_1)
		{
			if (A_1 == null)
			{
				return;
			}
			if (A_1 == this)
			{
				return;
			}
			if (A_1.RLbdNQMNOdtBNNtSworxHEDrzquv != this.RLbdNQMNOdtBNNtSworxHEDrzquv)
			{
				return;
			}
			double realTime = ReInput.realTime;
			object atMxxMEYXDqFqDrrxdonHTrDdIDO = this.AtMxxMEYXDqFqDrrxdonHTrDdIDO;
			lock (atMxxMEYXDqFqDrrxdonHTrDdIDO)
			{
				object atMxxMEYXDqFqDrrxdonHTrDdIDO2 = A_1.AtMxxMEYXDqFqDrrxdonHTrDdIDO;
				lock (atMxxMEYXDqFqDrrxdonHTrDdIDO2)
				{
					this.PkLlpsXwefMkJLsxiSgFXQLXwyrL.Import(A_1.PkLlpsXwefMkJLsxiSgFXQLXwyrL);
					this.anYcIJrturhviTKOlZJRmXlEKXji.YuhcPuHxRacbaZOyyLRWmJuYFvdZ(A_1.anYcIJrturhviTKOlZJRmXlEKXji);
					this.TcssSADrvKSfAKGUAoueQJLtADDi.kDFhuFBQvhuROMsHOCLpHHjIPiDmA(A_1.TcssSADrvKSfAKGUAoueQJLtADDi);
					this.lHioYhlethcyeBssckDdQTgSBEgtA.kDFhuFBQvhuROMsHOCLpHHjIPiDmA(A_1.lHioYhlethcyeBssckDdQTgSBEgtA);
					this.rClnvHtDEQsEwrWfRECZVgJdvkvx.ImportAll(A_1.rClnvHtDEQsEwrWfRECZVgJdvkvx);
					this.ODRsBeevaOmUJoGDMaxvsSgStjRC = EegVRmhDzKlDwgeYQLLOXmqEZyWQ.LuEePYLuYBFjPkHkwqNGPmKLNwrLA.TZHxhuRVSzkEfVvbtOCdOksMmVmR(A_1.ODRsBeevaOmUJoGDMaxvsSgStjRC, this.TcssSADrvKSfAKGUAoueQJLtADDi);
					this.cjiBcgSVyrrxaZutVKMZJHwXwGtH = A_1.cjiBcgSVyrrxaZutVKMZJHwXwGtH;
				}
			}
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00021888 File Offset: 0x0001FA88
		public void tgUdYHSqSHLTzvLYgFHtgacpVciO(int A_1, int A_2, int A_3, float A_4)
		{
			object atMxxMEYXDqFqDrrxdonHTrDdIDO = this.AtMxxMEYXDqFqDrrxdonHTrDdIDO;
			lock (atMxxMEYXDqFqDrrxdonHTrDdIDO)
			{
				this.ODRsBeevaOmUJoGDMaxvsSgStjRC = new EegVRmhDzKlDwgeYQLLOXmqEZyWQ.LuEePYLuYBFjPkHkwqNGPmKLNwrLA(this.TcssSADrvKSfAKGUAoueQJLtADDi, A_1, A_2, A_3, A_4);
			}
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x000218D8 File Offset: 0x0001FAD8
		private void UfddkzhXxGpfWFTMblilDIMngDeNA()
		{
			if (!this.cjiBcgSVyrrxaZutVKMZJHwXwGtH)
			{
				return;
			}
			double realTime;
			try
			{
				this.YYTkLtGvCcgvBVSkpDvBuasVgKSy.qmdXkeCEEOWBaWQkrKyUYAcxRurp(this.TcssSADrvKSfAKGUAoueQJLtADDi);
				realTime = ReInput.realTime;
			}
			catch
			{
				return;
			}
			object atMxxMEYXDqFqDrrxdonHTrDdIDO = this.AtMxxMEYXDqFqDrrxdonHTrDdIDO;
			lock (atMxxMEYXDqFqDrrxdonHTrDdIDO)
			{
				if (this.ODRsBeevaOmUJoGDMaxvsSgStjRC != null)
				{
					this.ODRsBeevaOmUJoGDMaxvsSgStjRC.SUtjJUJWrPLXRGzvUSgygbScOTBF(realTime);
				}
				if (!this.TcssSADrvKSfAKGUAoueQJLtADDi.SpfcKHuwYdfOYDQNMMOUYLwzAGtjb(this.lHioYhlethcyeBssckDdQTgSBEgtA))
				{
					using (DualThreadLowLevelInputEventQueue.INewEventWrapper newEventWrapper = this.rClnvHtDEQsEwrWfRECZVgJdvkvx.T_CreateEvent())
					{
						EegVRmhDzKlDwgeYQLLOXmqEZyWQ.uHXOkpavvZOKwXfuXypTJmiAJZgn.mlXdlDcxlttCfBRCMjTxeyBoIrzN.CSQKdFVLiTKfeZGsoGtPkwioDDEr(this.TcssSADrvKSfAKGUAoueQJLtADDi, realTime, newEventWrapper.Event);
					}
					this.lHioYhlethcyeBssckDdQTgSBEgtA.kDFhuFBQvhuROMsHOCLpHHjIPiDmA(this.TcssSADrvKSfAKGUAoueQJLtADDi);
				}
			}
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x000219B4 File Offset: 0x0001FBB4
		private void vOkWVPyRJEGkQNdVlkHNUlBskdmQ()
		{
			while (this.rClnvHtDEQsEwrWfRECZVgJdvkvx.ProcessNewEvents())
			{
				this.anYcIJrturhviTKOlZJRmXlEKXji.YYgXlswkyGdRAEcGIRCJnePEehat(ref this.rClnvHtDEQsEwrWfRECZVgJdvkvx.currentEvent);
				for (int i = 0; i < this.RLbdNQMNOdtBNNtSworxHEDrzquv; i++)
				{
					this.PkLlpsXwefMkJLsxiSgFXQLXwyrL.SetValue(i, this.anYcIJrturhviTKOlZJRmXlEKXji.aFliTDicBAviiSXuYoPUBCbYhGQiA[i], this.rClnvHtDEQsEwrWfRECZVgJdvkvx.currentEvent.GetTimestamp());
				}
			}
		}

		// Token: 0x060000BA RID: 186 RVA: 0x00021A20 File Offset: 0x0001FC20
		private void YfbKMSbJHWmQwkSymjJHwlAjICiJA()
		{
			this.anYcIJrturhviTKOlZJRmXlEKXji.mLUpTxMhHIceoVXDnbHWlAmCnyRC();
			object atMxxMEYXDqFqDrrxdonHTrDdIDO = this.AtMxxMEYXDqFqDrrxdonHTrDdIDO;
			lock (atMxxMEYXDqFqDrrxdonHTrDdIDO)
			{
				this.TcssSADrvKSfAKGUAoueQJLtADDi.prvyoehpzpeDjANBiExXsyoUyTyU();
				this.lHioYhlethcyeBssckDdQTgSBEgtA.prvyoehpzpeDjANBiExXsyoUyTyU();
				this.rClnvHtDEQsEwrWfRECZVgJdvkvx.Clear();
			}
			this.PkLlpsXwefMkJLsxiSgFXQLXwyrL.Clear();
		}

		// Token: 0x060000BB RID: 187 RVA: 0x00011980 File Offset: 0x0000FB80
		public void Dispose()
		{
			this.BIaUgsmlvcnEBNhUpELolFXTGZUHA(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00021A94 File Offset: 0x0001FC94
		protected virtual void SztrUauxOOSyvhidveZjfykbdXNS()
		{
			try
			{
				this.BIaUgsmlvcnEBNhUpELolFXTGZUHA(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00021AC4 File Offset: 0x0001FCC4
		protected virtual void BIaUgsmlvcnEBNhUpELolFXTGZUHA(bool A_1)
		{
			if (this.JRzCartOvEISjmyKiMtRDSijEfVy)
			{
				return;
			}
			if (A_1)
			{
				this.xqCyHtUPzBEQXmjKRcokiaybAFqTA();
				this.rClnvHtDEQsEwrWfRECZVgJdvkvx.Dispose();
			}
			if (jbcfMDoFeBFAQElVePZhKkwUdctNA.ZDYmSbdCWXNMZFZsjWAgCzkVkDMh != null)
			{
				jbcfMDoFeBFAQElVePZhKkwUdctNA.ZDYmSbdCWXNMZFZsjWAgCzkVkDMh.ThreadUpdateEvent -= this.UfddkzhXxGpfWFTMblilDIMngDeNA;
			}
			this.JRzCartOvEISjmyKiMtRDSijEfVy = true;
		}

		// Token: 0x060000BE RID: 190 RVA: 0x0001198F File Offset: 0x0000FB8F
		private static float fJlTLuXezXWYvEmbOGUvlMryqeQP(int A_0)
		{
			if (A_0 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(A_0) / 65535f * (float)MathTools.Sign(A_0), -1f, 1f);
		}

		// Token: 0x04000068 RID: 104
		private const int RojBKRUlkjBmlJsIWSwZzJxYGEFi = 2;

		// Token: 0x04000069 RID: 105
		private const int kibOHwwPUKCVKAvfopMhDAADkfNSb = 2;

		// Token: 0x0400006A RID: 106
		private const int osQbMZIwzhmgJTrnbIXLGZORpvzgb = 128;

		// Token: 0x0400006B RID: 107
		private const int StTVqnNcZEevrEjjQxPIRDRnQaLX = 32;

		// Token: 0x0400006C RID: 108
		private const int xtcTeTSPrYLLEBUbyGTEkDJISAHV = 0;

		// Token: 0x0400006D RID: 109
		private const int emrgmzEknqCGGxLTBErPrgHFmABZ = 264;

		// Token: 0x0400006E RID: 110
		private const int AQKhdLdBVxfSsuNABiNRQOEyNCBw = 272;

		// Token: 0x0400006F RID: 111
		private readonly int RLbdNQMNOdtBNNtSworxHEDrzquv;

		// Token: 0x04000070 RID: 112
		private readonly ButtonLoopSet PkLlpsXwefMkJLsxiSgFXQLXwyrL;

		// Token: 0x04000071 RID: 113
		private readonly DualThreadLowLevelInputEventQueue rClnvHtDEQsEwrWfRECZVgJdvkvx;

		// Token: 0x04000072 RID: 114
		private EegVRmhDzKlDwgeYQLLOXmqEZyWQ.LuEePYLuYBFjPkHkwqNGPmKLNwrLA ODRsBeevaOmUJoGDMaxvsSgStjRC;

		// Token: 0x04000073 RID: 115
		private readonly YYJpESzECVBzlTQDCRWMYdxQsJmw TcssSADrvKSfAKGUAoueQJLtADDi;

		// Token: 0x04000074 RID: 116
		private readonly YYJpESzECVBzlTQDCRWMYdxQsJmw lHioYhlethcyeBssckDdQTgSBEgtA;

		// Token: 0x04000075 RID: 117
		private readonly object AtMxxMEYXDqFqDrrxdonHTrDdIDO;

		// Token: 0x04000076 RID: 118
		private bool cjiBcgSVyrrxaZutVKMZJHwXwGtH;

		// Token: 0x04000077 RID: 119
		public readonly kgqhUexiHegpQmaRUvQyXXyfTECW YYTkLtGvCcgvBVSkpDvBuasVgKSy;

		// Token: 0x04000078 RID: 120
		private readonly EegVRmhDzKlDwgeYQLLOXmqEZyWQ.uHXOkpavvZOKwXfuXypTJmiAJZgn.mlXdlDcxlttCfBRCMjTxeyBoIrzN anYcIJrturhviTKOlZJRmXlEKXji;

		// Token: 0x04000079 RID: 121
		private bool JRzCartOvEISjmyKiMtRDSijEfVy;

		// Token: 0x0200000D RID: 13
		public class mlXdlDcxlttCfBRCMjTxeyBoIrzN
		{
			// Token: 0x060000BF RID: 191 RVA: 0x00021B14 File Offset: 0x0001FD14
			public mlXdlDcxlttCfBRCMjTxeyBoIrzN()
			{
				this.LPKVgGNdyleGriFyiKhyYyFbQXKC = new float[2];
				this.KARmNfoTiicECFgoKUGkdVNfusoW = new int[4];
				this.aFliTDicBAviiSXuYoPUBCbYhGQiA = new bool[128];
				this.CJJvnrocegtMKXFvvDjVKBmWOXZIA = new float[2];
				this.HrRmvXcbfMMbgboYgefJjzdgIAgC = new float[2];
				this.vbwwNpbOOvicnTFqKZmcKcxQiTGU = new float[2];
			}

			// Token: 0x060000C0 RID: 192 RVA: 0x00021B74 File Offset: 0x0001FD74
			public void mLUpTxMhHIceoVXDnbHWlAmCnyRC()
			{
				this.csNhoLCceKSoLSCzsHQARKYuBOqHA = 0f;
				this.HEFdmhNOcjPiwqKpOnPFVTcGOyZJ = 0f;
				this.GfEOiDvakbKYfFhjATHIUQvEuOdV = 0f;
				this.ufVGRPcwoncdAmOxfurPGcpzVzVC = 0f;
				this.VkQVLxiKbsICyCTgADtESUZAHPBK = 0f;
				this.eFDCcqDpxvpLXMrHMfIXnxvEVrJDA = 0f;
				for (int i = 0; i < this.LPKVgGNdyleGriFyiKhyYyFbQXKC.Length; i++)
				{
					this.LPKVgGNdyleGriFyiKhyYyFbQXKC[i] = 0f;
				}
				for (int j = 0; j < this.KARmNfoTiicECFgoKUGkdVNfusoW.Length; j++)
				{
					this.KARmNfoTiicECFgoKUGkdVNfusoW[j] = 0;
				}
				for (int k = 0; k < this.aFliTDicBAviiSXuYoPUBCbYhGQiA.Length; k++)
				{
					this.aFliTDicBAviiSXuYoPUBCbYhGQiA[k] = false;
				}
				this.JOnaQBHvhDvcOqpRiFWqNYcLtOWKA = 0f;
				this.aXtXIHlAlXUctmHDvLkHjacbriS = 0f;
				this.cBtQNbMRKJQIpvnXxyUeMCvtMdeb = 0f;
				this.GZuusnBjeIwsNsBaigOIhqNrqwYpA = 0f;
				this.mgqqwDUgchcCYjFtpzQAWamrlTzAb = 0f;
				this.RHrQGGmLHzxJgfjbcYxpsyJsjaoC = 0f;
				for (int l = 0; l < this.CJJvnrocegtMKXFvvDjVKBmWOXZIA.Length; l++)
				{
					this.CJJvnrocegtMKXFvvDjVKBmWOXZIA[l] = 0f;
				}
				this.fWFDiddsrvsQhcNPhsKfqiNqhyxMA = 0f;
				this.nLVLYbCUXYFBdVwrOoryyhZiZrao = 0f;
				this.OttHwKqmmhEXiXCymsKAnCCvDtYA = 0f;
				this.samjFOXdeDhuyGEyDBtIlhhnnmLl = 0f;
				this.UniaeUQHNKoDqDHqCJEslWrrWpbM = 0f;
				this.mImnJtiYOrbbfvyKfkTvlGVBkNGp = 0f;
				for (int m = 0; m < this.HrRmvXcbfMMbgboYgefJjzdgIAgC.Length; m++)
				{
					this.HrRmvXcbfMMbgboYgefJjzdgIAgC[m] = 0f;
				}
				this.PaWBBuhAWYGxFNzItrKVuBbUkCbhb = 0f;
				this.RUvoEapOtoagOkHFlBkfpLBBiJzS = 0f;
				this.oYZzJcNVZcxhYwOLKCQkuscbTire = 0f;
				this.CZpFtEgWjchGtUgwWuDDPsuOXqNwA = 0f;
				this.CCmJYBCUXzLRfnoJMRYiECLZAdQI = 0f;
				this.eWzXMQEHZsFwAcXvgklesQFTNldm = 0f;
				for (int n = 0; n < this.vbwwNpbOOvicnTFqKZmcKcxQiTGU.Length; n++)
				{
					this.vbwwNpbOOvicnTFqKZmcKcxQiTGU[n] = 0f;
				}
			}

			// Token: 0x060000C1 RID: 193 RVA: 0x00021D4C File Offset: 0x0001FF4C
			public void YuhcPuHxRacbaZOyyLRWmJuYFvdZ(EegVRmhDzKlDwgeYQLLOXmqEZyWQ.uHXOkpavvZOKwXfuXypTJmiAJZgn.mlXdlDcxlttCfBRCMjTxeyBoIrzN A_1)
			{
				this.csNhoLCceKSoLSCzsHQARKYuBOqHA = A_1.csNhoLCceKSoLSCzsHQARKYuBOqHA;
				this.HEFdmhNOcjPiwqKpOnPFVTcGOyZJ = A_1.HEFdmhNOcjPiwqKpOnPFVTcGOyZJ;
				this.GfEOiDvakbKYfFhjATHIUQvEuOdV = A_1.GfEOiDvakbKYfFhjATHIUQvEuOdV;
				this.ufVGRPcwoncdAmOxfurPGcpzVzVC = A_1.ufVGRPcwoncdAmOxfurPGcpzVzVC;
				this.VkQVLxiKbsICyCTgADtESUZAHPBK = A_1.VkQVLxiKbsICyCTgADtESUZAHPBK;
				this.eFDCcqDpxvpLXMrHMfIXnxvEVrJDA = A_1.eFDCcqDpxvpLXMrHMfIXnxvEVrJDA;
				for (int i = 0; i < this.LPKVgGNdyleGriFyiKhyYyFbQXKC.Length; i++)
				{
					this.LPKVgGNdyleGriFyiKhyYyFbQXKC[i] = A_1.LPKVgGNdyleGriFyiKhyYyFbQXKC[i];
				}
				for (int j = 0; j < this.KARmNfoTiicECFgoKUGkdVNfusoW.Length; j++)
				{
					this.KARmNfoTiicECFgoKUGkdVNfusoW[j] = A_1.KARmNfoTiicECFgoKUGkdVNfusoW[j];
				}
				for (int k = 0; k < this.aFliTDicBAviiSXuYoPUBCbYhGQiA.Length; k++)
				{
					this.aFliTDicBAviiSXuYoPUBCbYhGQiA[k] = A_1.aFliTDicBAviiSXuYoPUBCbYhGQiA[k];
				}
				this.JOnaQBHvhDvcOqpRiFWqNYcLtOWKA = A_1.JOnaQBHvhDvcOqpRiFWqNYcLtOWKA;
				this.aXtXIHlAlXUctmHDvLkHjacbriS = A_1.aXtXIHlAlXUctmHDvLkHjacbriS;
				this.cBtQNbMRKJQIpvnXxyUeMCvtMdeb = A_1.cBtQNbMRKJQIpvnXxyUeMCvtMdeb;
				this.GZuusnBjeIwsNsBaigOIhqNrqwYpA = A_1.GZuusnBjeIwsNsBaigOIhqNrqwYpA;
				this.mgqqwDUgchcCYjFtpzQAWamrlTzAb = A_1.mgqqwDUgchcCYjFtpzQAWamrlTzAb;
				this.RHrQGGmLHzxJgfjbcYxpsyJsjaoC = A_1.RHrQGGmLHzxJgfjbcYxpsyJsjaoC;
				for (int l = 0; l < this.CJJvnrocegtMKXFvvDjVKBmWOXZIA.Length; l++)
				{
					this.CJJvnrocegtMKXFvvDjVKBmWOXZIA[l] = A_1.CJJvnrocegtMKXFvvDjVKBmWOXZIA[l];
				}
				this.fWFDiddsrvsQhcNPhsKfqiNqhyxMA = A_1.fWFDiddsrvsQhcNPhsKfqiNqhyxMA;
				this.nLVLYbCUXYFBdVwrOoryyhZiZrao = A_1.nLVLYbCUXYFBdVwrOoryyhZiZrao;
				this.OttHwKqmmhEXiXCymsKAnCCvDtYA = A_1.OttHwKqmmhEXiXCymsKAnCCvDtYA;
				this.samjFOXdeDhuyGEyDBtIlhhnnmLl = A_1.samjFOXdeDhuyGEyDBtIlhhnnmLl;
				this.UniaeUQHNKoDqDHqCJEslWrrWpbM = A_1.UniaeUQHNKoDqDHqCJEslWrrWpbM;
				this.mImnJtiYOrbbfvyKfkTvlGVBkNGp = A_1.mImnJtiYOrbbfvyKfkTvlGVBkNGp;
				for (int m = 0; m < this.HrRmvXcbfMMbgboYgefJjzdgIAgC.Length; m++)
				{
					this.HrRmvXcbfMMbgboYgefJjzdgIAgC[m] = A_1.HrRmvXcbfMMbgboYgefJjzdgIAgC[m];
				}
				this.PaWBBuhAWYGxFNzItrKVuBbUkCbhb = A_1.PaWBBuhAWYGxFNzItrKVuBbUkCbhb;
				this.RUvoEapOtoagOkHFlBkfpLBBiJzS = A_1.RUvoEapOtoagOkHFlBkfpLBBiJzS;
				this.oYZzJcNVZcxhYwOLKCQkuscbTire = A_1.oYZzJcNVZcxhYwOLKCQkuscbTire;
				this.CZpFtEgWjchGtUgwWuDDPsuOXqNwA = A_1.CZpFtEgWjchGtUgwWuDDPsuOXqNwA;
				this.CCmJYBCUXzLRfnoJMRYiECLZAdQI = A_1.CCmJYBCUXzLRfnoJMRYiECLZAdQI;
				this.eWzXMQEHZsFwAcXvgklesQFTNldm = A_1.eWzXMQEHZsFwAcXvgklesQFTNldm;
				for (int n = 0; n < this.vbwwNpbOOvicnTFqKZmcKcxQiTGU.Length; n++)
				{
					this.vbwwNpbOOvicnTFqKZmcKcxQiTGU[n] = A_1.vbwwNpbOOvicnTFqKZmcKcxQiTGU[n];
				}
			}

			// Token: 0x060000C2 RID: 194 RVA: 0x00021F58 File Offset: 0x00020158
			public unsafe void YYgXlswkyGdRAEcGIRCJnePEehat(ref LowLevelInputEvent A_1)
			{
				for (int i = 0; i < 4; i++)
				{
					int num = *(int*)((byte*)((byte*)((void*)A_1._buffer) + A_1.byteIndex_buttonsStart) + i * 4);
					for (int j = 0; j < 32; j++)
					{
						this.aFliTDicBAviiSXuYoPUBCbYhGQiA[i * 32 + j] = ((num & 1 << j) != 0);
					}
				}
				float* ptr = (float*)((byte*)((void*)A_1._buffer) + A_1.byteIndex_axesStart);
				for (int k = 0; k < 2; k++)
				{
					this.HrRmvXcbfMMbgboYgefJjzdgIAgC[k] = *ptr;
					ptr++;
				}
				this.fWFDiddsrvsQhcNPhsKfqiNqhyxMA = *ptr;
				ptr++;
				this.nLVLYbCUXYFBdVwrOoryyhZiZrao = *ptr;
				ptr++;
				this.OttHwKqmmhEXiXCymsKAnCCvDtYA = *ptr;
				ptr++;
				this.samjFOXdeDhuyGEyDBtIlhhnnmLl = *ptr;
				ptr++;
				this.UniaeUQHNKoDqDHqCJEslWrrWpbM = *ptr;
				ptr++;
				this.mImnJtiYOrbbfvyKfkTvlGVBkNGp = *ptr;
				ptr++;
				this.GZuusnBjeIwsNsBaigOIhqNrqwYpA = *ptr;
				ptr++;
				this.mgqqwDUgchcCYjFtpzQAWamrlTzAb = *ptr;
				ptr++;
				this.RHrQGGmLHzxJgfjbcYxpsyJsjaoC = *ptr;
				ptr++;
				for (int l = 0; l < 2; l++)
				{
					this.vbwwNpbOOvicnTFqKZmcKcxQiTGU[l] = *ptr;
					ptr++;
				}
				this.PaWBBuhAWYGxFNzItrKVuBbUkCbhb = *ptr;
				ptr++;
				this.RUvoEapOtoagOkHFlBkfpLBBiJzS = *ptr;
				ptr++;
				this.oYZzJcNVZcxhYwOLKCQkuscbTire = *ptr;
				ptr++;
				this.ufVGRPcwoncdAmOxfurPGcpzVzVC = *ptr;
				ptr++;
				this.VkQVLxiKbsICyCTgADtESUZAHPBK = *ptr;
				ptr++;
				this.eFDCcqDpxvpLXMrHMfIXnxvEVrJDA = *ptr;
				ptr++;
				for (int m = 0; m < 2; m++)
				{
					this.LPKVgGNdyleGriFyiKhyYyFbQXKC[m] = *ptr;
					ptr++;
				}
				this.CZpFtEgWjchGtUgwWuDDPsuOXqNwA = *ptr;
				ptr++;
				this.CCmJYBCUXzLRfnoJMRYiECLZAdQI = *ptr;
				ptr++;
				this.eWzXMQEHZsFwAcXvgklesQFTNldm = *ptr;
				ptr++;
				for (int n = 0; n < 2; n++)
				{
					this.CJJvnrocegtMKXFvvDjVKBmWOXZIA[n] = *ptr;
					ptr++;
				}
				this.JOnaQBHvhDvcOqpRiFWqNYcLtOWKA = *ptr;
				ptr++;
				this.aXtXIHlAlXUctmHDvLkHjacbriS = *ptr;
				ptr++;
				this.cBtQNbMRKJQIpvnXxyUeMCvtMdeb = *ptr;
				ptr++;
				this.csNhoLCceKSoLSCzsHQARKYuBOqHA = *ptr;
				ptr++;
				this.HEFdmhNOcjPiwqKpOnPFVTcGOyZJ = *ptr;
				ptr++;
				this.GfEOiDvakbKYfFhjATHIUQvEuOdV = *ptr;
				ptr++;
				int* ptr2 = (int*)((byte*)((void*)A_1._buffer) + A_1.byteIndex_hatsStart);
				for (int num2 = 0; num2 < 2; num2++)
				{
					this.KARmNfoTiicECFgoKUGkdVNfusoW[num2] = *ptr2;
					ptr2++;
				}
			}

			// Token: 0x060000C3 RID: 195 RVA: 0x00022198 File Offset: 0x00020398
			public unsafe static void CSQKdFVLiTKfeZGsoGtPkwioDDEr(YYJpESzECVBzlTQDCRWMYdxQsJmw A_0, double A_1, LowLevelInputEvent A_2)
			{
				int[] array = A_0.UpLIdneJFMWOLFpxWPvqVMVbbxrT;
				int[] array2 = A_0.jVwKAvrEQhnOEbbmghZKgSxWMzWb;
				int[] array3 = A_0.iZAlvLSIlUBfemngabGpONTqHjBr;
				int[] array4 = A_0.AQhLmzfZMTQHPRLBUcEEMNbuKcNd;
				int[] array5 = A_0.FDRMiiddqimGjBvlYEcXYJBfUotl;
				*(double*)((byte*)((void*)A_2._buffer) + 4) = A_1;
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				for (int i = 0; i < 128; i++)
				{
					if (A_0.eNrbHJbOHpezkLYOAFIbOIIqegzX[i])
					{
						num |= 1 << num3;
					}
					num3++;
					if (num3 == 32)
					{
						*(int*)((byte*)((byte*)((void*)A_2._buffer) + A_2.byteIndex_buttonsStart) + num2 * 4) = num;
						num3 = 0;
						num = 0;
						num2++;
					}
				}
				float* ptr = (float*)((byte*)((void*)A_2._buffer) + A_2.byteIndex_axesStart);
				for (int j = 0; j < 2; j++)
				{
					*ptr = EegVRmhDzKlDwgeYQLLOXmqEZyWQ.uHXOkpavvZOKwXfuXypTJmiAJZgn.fJlTLuXezXWYvEmbOGUvlMryqeQP(array2[j]);
					ptr++;
				}
				*ptr = EegVRmhDzKlDwgeYQLLOXmqEZyWQ.uHXOkpavvZOKwXfuXypTJmiAJZgn.fJlTLuXezXWYvEmbOGUvlMryqeQP(A_0.DNiKfdUBbDbyYvNEIYQpIIuEkUOc);
				ptr++;
				*ptr = EegVRmhDzKlDwgeYQLLOXmqEZyWQ.uHXOkpavvZOKwXfuXypTJmiAJZgn.fJlTLuXezXWYvEmbOGUvlMryqeQP(A_0.SjIanMwRZanFxSPcWIasCtfeJUDLA);
				ptr++;
				*ptr = EegVRmhDzKlDwgeYQLLOXmqEZyWQ.uHXOkpavvZOKwXfuXypTJmiAJZgn.fJlTLuXezXWYvEmbOGUvlMryqeQP(A_0.UPFgOJsqTDXYLChvoCCopCmEhNkU);
				ptr++;
				*ptr = EegVRmhDzKlDwgeYQLLOXmqEZyWQ.uHXOkpavvZOKwXfuXypTJmiAJZgn.fJlTLuXezXWYvEmbOGUvlMryqeQP(A_0.BnnDwCVefHbLhAtdTFuZKMBKUCOaA);
				ptr++;
				*ptr = EegVRmhDzKlDwgeYQLLOXmqEZyWQ.uHXOkpavvZOKwXfuXypTJmiAJZgn.fJlTLuXezXWYvEmbOGUvlMryqeQP(A_0.OPSqgYfXYxMCGlXmkRGGYmlKbuwE);
				ptr++;
				*ptr = EegVRmhDzKlDwgeYQLLOXmqEZyWQ.uHXOkpavvZOKwXfuXypTJmiAJZgn.fJlTLuXezXWYvEmbOGUvlMryqeQP(A_0.IqXnDRnGhmmONzYryPcuCGPeLigb);
				ptr++;
				*ptr = EegVRmhDzKlDwgeYQLLOXmqEZyWQ.uHXOkpavvZOKwXfuXypTJmiAJZgn.fJlTLuXezXWYvEmbOGUvlMryqeQP(A_0.FUzIkIKzoqgZgkmFnoAukNBmRUoS);
				ptr++;
				*ptr = EegVRmhDzKlDwgeYQLLOXmqEZyWQ.uHXOkpavvZOKwXfuXypTJmiAJZgn.fJlTLuXezXWYvEmbOGUvlMryqeQP(A_0.AqmJYIgqEHBbfOXZPNRdijKrAuzcA);
				ptr++;
				*ptr = EegVRmhDzKlDwgeYQLLOXmqEZyWQ.uHXOkpavvZOKwXfuXypTJmiAJZgn.fJlTLuXezXWYvEmbOGUvlMryqeQP(A_0.HwrgKLGSLdmDOudMfeFLwpzRcrnMA);
				ptr++;
				for (int k = 0; k < 2; k++)
				{
					*ptr = EegVRmhDzKlDwgeYQLLOXmqEZyWQ.uHXOkpavvZOKwXfuXypTJmiAJZgn.fJlTLuXezXWYvEmbOGUvlMryqeQP(array3[k]);
					ptr++;
				}
				*ptr = EegVRmhDzKlDwgeYQLLOXmqEZyWQ.uHXOkpavvZOKwXfuXypTJmiAJZgn.fJlTLuXezXWYvEmbOGUvlMryqeQP(A_0.poVASmNsBSlAtTPnURPlgnNwTVek);
				ptr++;
				*ptr = EegVRmhDzKlDwgeYQLLOXmqEZyWQ.uHXOkpavvZOKwXfuXypTJmiAJZgn.fJlTLuXezXWYvEmbOGUvlMryqeQP(A_0.XkMBVQdmpNGnXqtLMjtjjQOgKxlo);
				ptr++;
				*ptr = EegVRmhDzKlDwgeYQLLOXmqEZyWQ.uHXOkpavvZOKwXfuXypTJmiAJZgn.fJlTLuXezXWYvEmbOGUvlMryqeQP(A_0.fRcuxBeAsTaTtMENjxmkXJOBBRWQ);
				ptr++;
				*ptr = EegVRmhDzKlDwgeYQLLOXmqEZyWQ.uHXOkpavvZOKwXfuXypTJmiAJZgn.fJlTLuXezXWYvEmbOGUvlMryqeQP(A_0.cokAOaqKaqBoLSFrtmZPXARddvtcA);
				ptr++;
				*ptr = EegVRmhDzKlDwgeYQLLOXmqEZyWQ.uHXOkpavvZOKwXfuXypTJmiAJZgn.fJlTLuXezXWYvEmbOGUvlMryqeQP(A_0.wSjjkJcaHRrAjnFdlfmmqMxOmcGC);
				ptr++;
				*ptr = EegVRmhDzKlDwgeYQLLOXmqEZyWQ.uHXOkpavvZOKwXfuXypTJmiAJZgn.fJlTLuXezXWYvEmbOGUvlMryqeQP(A_0.dWHwHiuJqgFQgbTcwGKWNgXyPXDLA);
				ptr++;
				for (int l = 0; l < 2; l++)
				{
					*ptr = EegVRmhDzKlDwgeYQLLOXmqEZyWQ.uHXOkpavvZOKwXfuXypTJmiAJZgn.fJlTLuXezXWYvEmbOGUvlMryqeQP(array4[l]);
					ptr++;
				}
				*ptr = EegVRmhDzKlDwgeYQLLOXmqEZyWQ.uHXOkpavvZOKwXfuXypTJmiAJZgn.fJlTLuXezXWYvEmbOGUvlMryqeQP(A_0.QtxcrLVuJlcuwnYvfiMLXZQrvYBP);
				ptr++;
				*ptr = EegVRmhDzKlDwgeYQLLOXmqEZyWQ.uHXOkpavvZOKwXfuXypTJmiAJZgn.fJlTLuXezXWYvEmbOGUvlMryqeQP(A_0.tjJfDPGccOQkrXYoKKFnmRixdssq);
				ptr++;
				*ptr = EegVRmhDzKlDwgeYQLLOXmqEZyWQ.uHXOkpavvZOKwXfuXypTJmiAJZgn.fJlTLuXezXWYvEmbOGUvlMryqeQP(A_0.bUNqDPnNoEBPhXXPLVGGkiyrqyqD);
				ptr++;
				for (int m = 0; m < 2; m++)
				{
					*ptr = EegVRmhDzKlDwgeYQLLOXmqEZyWQ.uHXOkpavvZOKwXfuXypTJmiAJZgn.fJlTLuXezXWYvEmbOGUvlMryqeQP(array5[m]);
					ptr++;
				}
				*ptr = EegVRmhDzKlDwgeYQLLOXmqEZyWQ.uHXOkpavvZOKwXfuXypTJmiAJZgn.fJlTLuXezXWYvEmbOGUvlMryqeQP(A_0.pSKxiDxLkWbwPahWieUAFKBnyVXOA);
				ptr++;
				*ptr = EegVRmhDzKlDwgeYQLLOXmqEZyWQ.uHXOkpavvZOKwXfuXypTJmiAJZgn.fJlTLuXezXWYvEmbOGUvlMryqeQP(A_0.BRqLbDVCIyhCIDEgyhWQarqLglHNA);
				ptr++;
				*ptr = EegVRmhDzKlDwgeYQLLOXmqEZyWQ.uHXOkpavvZOKwXfuXypTJmiAJZgn.fJlTLuXezXWYvEmbOGUvlMryqeQP(A_0.ErmEHXkpeZLQaxlStIhBatAEmNrVA);
				ptr++;
				*ptr = EegVRmhDzKlDwgeYQLLOXmqEZyWQ.uHXOkpavvZOKwXfuXypTJmiAJZgn.fJlTLuXezXWYvEmbOGUvlMryqeQP(A_0.OXsXEeZYYccDtQxaTmxEmzsaqftA);
				ptr++;
				*ptr = EegVRmhDzKlDwgeYQLLOXmqEZyWQ.uHXOkpavvZOKwXfuXypTJmiAJZgn.fJlTLuXezXWYvEmbOGUvlMryqeQP(A_0.jaMVMrxxLbLHYVkNUClAyqrYVgap);
				ptr++;
				*ptr = EegVRmhDzKlDwgeYQLLOXmqEZyWQ.uHXOkpavvZOKwXfuXypTJmiAJZgn.fJlTLuXezXWYvEmbOGUvlMryqeQP(A_0.cHIRwRHXXwEjYNxPpAjCbLhkLixH);
				ptr++;
				int* ptr2 = (int*)((byte*)((void*)A_2._buffer) + A_2.byteIndex_hatsStart);
				for (int n = 0; n < 2; n++)
				{
					*ptr2 = array[n];
					ptr2++;
				}
			}

			// Token: 0x0400007A RID: 122
			public float csNhoLCceKSoLSCzsHQARKYuBOqHA;

			// Token: 0x0400007B RID: 123
			public float HEFdmhNOcjPiwqKpOnPFVTcGOyZJ;

			// Token: 0x0400007C RID: 124
			public float GfEOiDvakbKYfFhjATHIUQvEuOdV;

			// Token: 0x0400007D RID: 125
			public float ufVGRPcwoncdAmOxfurPGcpzVzVC;

			// Token: 0x0400007E RID: 126
			public float VkQVLxiKbsICyCTgADtESUZAHPBK;

			// Token: 0x0400007F RID: 127
			public float eFDCcqDpxvpLXMrHMfIXnxvEVrJDA;

			// Token: 0x04000080 RID: 128
			public float[] LPKVgGNdyleGriFyiKhyYyFbQXKC;

			// Token: 0x04000081 RID: 129
			public readonly int[] KARmNfoTiicECFgoKUGkdVNfusoW;

			// Token: 0x04000082 RID: 130
			public readonly bool[] aFliTDicBAviiSXuYoPUBCbYhGQiA;

			// Token: 0x04000083 RID: 131
			public float JOnaQBHvhDvcOqpRiFWqNYcLtOWKA;

			// Token: 0x04000084 RID: 132
			public float aXtXIHlAlXUctmHDvLkHjacbriS;

			// Token: 0x04000085 RID: 133
			public float cBtQNbMRKJQIpvnXxyUeMCvtMdeb;

			// Token: 0x04000086 RID: 134
			public float GZuusnBjeIwsNsBaigOIhqNrqwYpA;

			// Token: 0x04000087 RID: 135
			public float mgqqwDUgchcCYjFtpzQAWamrlTzAb;

			// Token: 0x04000088 RID: 136
			public float RHrQGGmLHzxJgfjbcYxpsyJsjaoC;

			// Token: 0x04000089 RID: 137
			public readonly float[] CJJvnrocegtMKXFvvDjVKBmWOXZIA;

			// Token: 0x0400008A RID: 138
			public float fWFDiddsrvsQhcNPhsKfqiNqhyxMA;

			// Token: 0x0400008B RID: 139
			public float nLVLYbCUXYFBdVwrOoryyhZiZrao;

			// Token: 0x0400008C RID: 140
			public float OttHwKqmmhEXiXCymsKAnCCvDtYA;

			// Token: 0x0400008D RID: 141
			public float samjFOXdeDhuyGEyDBtIlhhnnmLl;

			// Token: 0x0400008E RID: 142
			public float UniaeUQHNKoDqDHqCJEslWrrWpbM;

			// Token: 0x0400008F RID: 143
			public float mImnJtiYOrbbfvyKfkTvlGVBkNGp;

			// Token: 0x04000090 RID: 144
			public readonly float[] HrRmvXcbfMMbgboYgefJjzdgIAgC;

			// Token: 0x04000091 RID: 145
			public float PaWBBuhAWYGxFNzItrKVuBbUkCbhb;

			// Token: 0x04000092 RID: 146
			public float RUvoEapOtoagOkHFlBkfpLBBiJzS;

			// Token: 0x04000093 RID: 147
			public float oYZzJcNVZcxhYwOLKCQkuscbTire;

			// Token: 0x04000094 RID: 148
			public float CZpFtEgWjchGtUgwWuDDPsuOXqNwA;

			// Token: 0x04000095 RID: 149
			public float CCmJYBCUXzLRfnoJMRYiECLZAdQI;

			// Token: 0x04000096 RID: 150
			public float eWzXMQEHZsFwAcXvgklesQFTNldm;

			// Token: 0x04000097 RID: 151
			public readonly float[] vbwwNpbOOvicnTFqKZmcKcxQiTGU;
		}
	}

	// Token: 0x0200000E RID: 14
	private class LuEePYLuYBFjPkHkwqNGPmKLNwrLA
	{
		// Token: 0x1700001A RID: 26
		// (get) Token: 0x060000C4 RID: 196 RVA: 0x000119BE File Offset: 0x0000FBBE
		public YYJpESzECVBzlTQDCRWMYdxQsJmw fawFjAftFhKwogZsTvdJIYXilvYt
		{
			get
			{
				return this.NeoYHOcyiEOcNlzGfMmSbveqzwWh;
			}
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x000119C6 File Offset: 0x0000FBC6
		public static EegVRmhDzKlDwgeYQLLOXmqEZyWQ.LuEePYLuYBFjPkHkwqNGPmKLNwrLA TZHxhuRVSzkEfVvbtOCdOksMmVmR(EegVRmhDzKlDwgeYQLLOXmqEZyWQ.LuEePYLuYBFjPkHkwqNGPmKLNwrLA A_0, YYJpESzECVBzlTQDCRWMYdxQsJmw A_1)
		{
			if (A_0 == null || A_1 == null)
			{
				return null;
			}
			return new EegVRmhDzKlDwgeYQLLOXmqEZyWQ.LuEePYLuYBFjPkHkwqNGPmKLNwrLA(A_0, A_1);
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x000119D7 File Offset: 0x0000FBD7
		public LuEePYLuYBFjPkHkwqNGPmKLNwrLA(YYJpESzECVBzlTQDCRWMYdxQsJmw A_1, int A_2, int A_3, int A_4, float A_5) : this(A_2, A_3, A_4, A_5)
		{
			this.BdAupgemjQXUBKSNvdcYZbCkCqZV = new EegVRmhDzKlDwgeYQLLOXmqEZyWQ.cklzZNoOhVlfNfEzaYtLHyCrGbqs(A_1);
			this.NeoYHOcyiEOcNlzGfMmSbveqzwWh = new YYJpESzECVBzlTQDCRWMYdxQsJmw();
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x000119FC File Offset: 0x0000FBFC
		private LuEePYLuYBFjPkHkwqNGPmKLNwrLA(EegVRmhDzKlDwgeYQLLOXmqEZyWQ.LuEePYLuYBFjPkHkwqNGPmKLNwrLA A_1, YYJpESzECVBzlTQDCRWMYdxQsJmw A_2) : this(A_2, A_1.KtJcJLgVbsvLXGfwbYzekfPWFLQw, A_1.MjCJTSpujLrvnCzSfJmnLNCfEpJE, A_1.ZoIUuTqIeUYCuffAmfCSBoTdiCBM, A_1.nFjirLZGxtrsZSQWBUxgsBhjaNfV)
		{
			this.ElhcpaBGGahOUafdiWTMqrOdKJspA(A_1);
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00011A24 File Offset: 0x0000FC24
		private LuEePYLuYBFjPkHkwqNGPmKLNwrLA(int A_1, int A_2, int A_3, float A_4)
		{
			this.KtJcJLgVbsvLXGfwbYzekfPWFLQw = A_1;
			this.MjCJTSpujLrvnCzSfJmnLNCfEpJE = A_2;
			this.ZoIUuTqIeUYCuffAmfCSBoTdiCBM = A_3;
			this.nFjirLZGxtrsZSQWBUxgsBhjaNfV = A_4;
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x000224F0 File Offset: 0x000206F0
		public void SUtjJUJWrPLXRGzvUSgygbScOTBF(double A_1)
		{
			this.BdAupgemjQXUBKSNvdcYZbCkCqZV.ERitXZvGJoEiiEfdLHAKSrezjyTn(A_1);
			if (!this.BdAupgemjQXUBKSNvdcYZbCkCqZV.IBQhouRnHPkmvVgMdPAzbwzcekkO)
			{
				if (A_1 >= this.BdAupgemjQXUBKSNvdcYZbCkCqZV.HMNwSJFUMHkBguqnPBMyhjNvDnmY + (double)this.nFjirLZGxtrsZSQWBUxgsBhjaNfV)
				{
					this.NeoYHOcyiEOcNlzGfMmSbveqzwWh.prvyoehpzpeDjANBiExXsyoUyTyU();
					return;
				}
			}
			else
			{
				YYJpESzECVBzlTQDCRWMYdxQsJmw yyjpESzECVBzlTQDCRWMYdxQsJmw = this.BdAupgemjQXUBKSNvdcYZbCkCqZV.YYoMyviGFVrnlTJDaWuvOkmHGlnJ;
				YYJpESzECVBzlTQDCRWMYdxQsJmw yyjpESzECVBzlTQDCRWMYdxQsJmw2 = this.BdAupgemjQXUBKSNvdcYZbCkCqZV.pcqZnVoSARUEWNlsxOqBjceAiJQs;
				this.NeoYHOcyiEOcNlzGfMmSbveqzwWh.OXsXEeZYYccDtQxaTmxEmzsaqftA = this.RwhUxJxbwwGZeWWPZMGikjwCefHm(yyjpESzECVBzlTQDCRWMYdxQsJmw.OXsXEeZYYccDtQxaTmxEmzsaqftA);
				this.NeoYHOcyiEOcNlzGfMmSbveqzwWh.jaMVMrxxLbLHYVkNUClAyqrYVgap = this.RwhUxJxbwwGZeWWPZMGikjwCefHm(yyjpESzECVBzlTQDCRWMYdxQsJmw.jaMVMrxxLbLHYVkNUClAyqrYVgap);
				this.NeoYHOcyiEOcNlzGfMmSbveqzwWh.cHIRwRHXXwEjYNxPpAjCbLhkLixH = this.RwhUxJxbwwGZeWWPZMGikjwCefHm(yyjpESzECVBzlTQDCRWMYdxQsJmw.cHIRwRHXXwEjYNxPpAjCbLhkLixH);
				this.NeoYHOcyiEOcNlzGfMmSbveqzwWh.cokAOaqKaqBoLSFrtmZPXARddvtcA = this.RwhUxJxbwwGZeWWPZMGikjwCefHm(yyjpESzECVBzlTQDCRWMYdxQsJmw.cokAOaqKaqBoLSFrtmZPXARddvtcA);
				this.NeoYHOcyiEOcNlzGfMmSbveqzwWh.wSjjkJcaHRrAjnFdlfmmqMxOmcGC = this.RwhUxJxbwwGZeWWPZMGikjwCefHm(yyjpESzECVBzlTQDCRWMYdxQsJmw.wSjjkJcaHRrAjnFdlfmmqMxOmcGC);
				this.NeoYHOcyiEOcNlzGfMmSbveqzwWh.dWHwHiuJqgFQgbTcwGKWNgXyPXDLA = this.RwhUxJxbwwGZeWWPZMGikjwCefHm(yyjpESzECVBzlTQDCRWMYdxQsJmw.dWHwHiuJqgFQgbTcwGKWNgXyPXDLA);
				for (int i = 0; i < this.NeoYHOcyiEOcNlzGfMmSbveqzwWh.AQhLmzfZMTQHPRLBUcEEMNbuKcNd.Length; i++)
				{
					this.NeoYHOcyiEOcNlzGfMmSbveqzwWh.AQhLmzfZMTQHPRLBUcEEMNbuKcNd[i] = this.RwhUxJxbwwGZeWWPZMGikjwCefHm(yyjpESzECVBzlTQDCRWMYdxQsJmw.AQhLmzfZMTQHPRLBUcEEMNbuKcNd[i]);
				}
				for (int j = 0; j < this.NeoYHOcyiEOcNlzGfMmSbveqzwWh.UpLIdneJFMWOLFpxWPvqVMVbbxrT.Length; j++)
				{
					this.NeoYHOcyiEOcNlzGfMmSbveqzwWh.UpLIdneJFMWOLFpxWPvqVMVbbxrT[j] = this.RwhUxJxbwwGZeWWPZMGikjwCefHm(yyjpESzECVBzlTQDCRWMYdxQsJmw.UpLIdneJFMWOLFpxWPvqVMVbbxrT[j]);
				}
				for (int k = 0; k < this.NeoYHOcyiEOcNlzGfMmSbveqzwWh.eNrbHJbOHpezkLYOAFIbOIIqegzX.Length; k++)
				{
					this.NeoYHOcyiEOcNlzGfMmSbveqzwWh.eNrbHJbOHpezkLYOAFIbOIIqegzX[k] = yyjpESzECVBzlTQDCRWMYdxQsJmw2.eNrbHJbOHpezkLYOAFIbOIIqegzX[k];
				}
				this.NeoYHOcyiEOcNlzGfMmSbveqzwWh.pSKxiDxLkWbwPahWieUAFKBnyVXOA = this.RwhUxJxbwwGZeWWPZMGikjwCefHm(yyjpESzECVBzlTQDCRWMYdxQsJmw.pSKxiDxLkWbwPahWieUAFKBnyVXOA);
				this.NeoYHOcyiEOcNlzGfMmSbveqzwWh.BRqLbDVCIyhCIDEgyhWQarqLglHNA = this.RwhUxJxbwwGZeWWPZMGikjwCefHm(yyjpESzECVBzlTQDCRWMYdxQsJmw.BRqLbDVCIyhCIDEgyhWQarqLglHNA);
				this.NeoYHOcyiEOcNlzGfMmSbveqzwWh.ErmEHXkpeZLQaxlStIhBatAEmNrVA = this.RwhUxJxbwwGZeWWPZMGikjwCefHm(yyjpESzECVBzlTQDCRWMYdxQsJmw.ErmEHXkpeZLQaxlStIhBatAEmNrVA);
				this.NeoYHOcyiEOcNlzGfMmSbveqzwWh.FUzIkIKzoqgZgkmFnoAukNBmRUoS = this.RwhUxJxbwwGZeWWPZMGikjwCefHm(yyjpESzECVBzlTQDCRWMYdxQsJmw.FUzIkIKzoqgZgkmFnoAukNBmRUoS);
				this.NeoYHOcyiEOcNlzGfMmSbveqzwWh.AqmJYIgqEHBbfOXZPNRdijKrAuzcA = this.RwhUxJxbwwGZeWWPZMGikjwCefHm(yyjpESzECVBzlTQDCRWMYdxQsJmw.AqmJYIgqEHBbfOXZPNRdijKrAuzcA);
				this.NeoYHOcyiEOcNlzGfMmSbveqzwWh.HwrgKLGSLdmDOudMfeFLwpzRcrnMA = this.RwhUxJxbwwGZeWWPZMGikjwCefHm(yyjpESzECVBzlTQDCRWMYdxQsJmw.HwrgKLGSLdmDOudMfeFLwpzRcrnMA);
				for (int l = 0; l < this.NeoYHOcyiEOcNlzGfMmSbveqzwWh.FDRMiiddqimGjBvlYEcXYJBfUotl.Length; l++)
				{
					this.NeoYHOcyiEOcNlzGfMmSbveqzwWh.FDRMiiddqimGjBvlYEcXYJBfUotl[l] = this.RwhUxJxbwwGZeWWPZMGikjwCefHm(yyjpESzECVBzlTQDCRWMYdxQsJmw.FDRMiiddqimGjBvlYEcXYJBfUotl[l]);
				}
				this.NeoYHOcyiEOcNlzGfMmSbveqzwWh.DNiKfdUBbDbyYvNEIYQpIIuEkUOc = this.RwhUxJxbwwGZeWWPZMGikjwCefHm(yyjpESzECVBzlTQDCRWMYdxQsJmw.DNiKfdUBbDbyYvNEIYQpIIuEkUOc);
				this.NeoYHOcyiEOcNlzGfMmSbveqzwWh.SjIanMwRZanFxSPcWIasCtfeJUDLA = this.RwhUxJxbwwGZeWWPZMGikjwCefHm(yyjpESzECVBzlTQDCRWMYdxQsJmw.SjIanMwRZanFxSPcWIasCtfeJUDLA);
				this.NeoYHOcyiEOcNlzGfMmSbveqzwWh.UPFgOJsqTDXYLChvoCCopCmEhNkU = this.RwhUxJxbwwGZeWWPZMGikjwCefHm(yyjpESzECVBzlTQDCRWMYdxQsJmw.UPFgOJsqTDXYLChvoCCopCmEhNkU);
				this.NeoYHOcyiEOcNlzGfMmSbveqzwWh.BnnDwCVefHbLhAtdTFuZKMBKUCOaA = this.RwhUxJxbwwGZeWWPZMGikjwCefHm(yyjpESzECVBzlTQDCRWMYdxQsJmw.BnnDwCVefHbLhAtdTFuZKMBKUCOaA);
				this.NeoYHOcyiEOcNlzGfMmSbveqzwWh.OPSqgYfXYxMCGlXmkRGGYmlKbuwE = this.RwhUxJxbwwGZeWWPZMGikjwCefHm(yyjpESzECVBzlTQDCRWMYdxQsJmw.OPSqgYfXYxMCGlXmkRGGYmlKbuwE);
				this.NeoYHOcyiEOcNlzGfMmSbveqzwWh.IqXnDRnGhmmONzYryPcuCGPeLigb = this.RwhUxJxbwwGZeWWPZMGikjwCefHm(yyjpESzECVBzlTQDCRWMYdxQsJmw.IqXnDRnGhmmONzYryPcuCGPeLigb);
				for (int m = 0; m < this.NeoYHOcyiEOcNlzGfMmSbveqzwWh.jVwKAvrEQhnOEbbmghZKgSxWMzWb.Length; m++)
				{
					this.NeoYHOcyiEOcNlzGfMmSbveqzwWh.jVwKAvrEQhnOEbbmghZKgSxWMzWb[m] = this.RwhUxJxbwwGZeWWPZMGikjwCefHm(yyjpESzECVBzlTQDCRWMYdxQsJmw.jVwKAvrEQhnOEbbmghZKgSxWMzWb[m]);
				}
				this.NeoYHOcyiEOcNlzGfMmSbveqzwWh.poVASmNsBSlAtTPnURPlgnNwTVek = this.RwhUxJxbwwGZeWWPZMGikjwCefHm(yyjpESzECVBzlTQDCRWMYdxQsJmw.poVASmNsBSlAtTPnURPlgnNwTVek);
				this.NeoYHOcyiEOcNlzGfMmSbveqzwWh.XkMBVQdmpNGnXqtLMjtjjQOgKxlo = this.RwhUxJxbwwGZeWWPZMGikjwCefHm(yyjpESzECVBzlTQDCRWMYdxQsJmw.XkMBVQdmpNGnXqtLMjtjjQOgKxlo);
				this.NeoYHOcyiEOcNlzGfMmSbveqzwWh.fRcuxBeAsTaTtMENjxmkXJOBBRWQ = this.RwhUxJxbwwGZeWWPZMGikjwCefHm(yyjpESzECVBzlTQDCRWMYdxQsJmw.fRcuxBeAsTaTtMENjxmkXJOBBRWQ);
				this.NeoYHOcyiEOcNlzGfMmSbveqzwWh.QtxcrLVuJlcuwnYvfiMLXZQrvYBP = this.RwhUxJxbwwGZeWWPZMGikjwCefHm(yyjpESzECVBzlTQDCRWMYdxQsJmw.QtxcrLVuJlcuwnYvfiMLXZQrvYBP);
				this.NeoYHOcyiEOcNlzGfMmSbveqzwWh.tjJfDPGccOQkrXYoKKFnmRixdssq = this.RwhUxJxbwwGZeWWPZMGikjwCefHm(yyjpESzECVBzlTQDCRWMYdxQsJmw.tjJfDPGccOQkrXYoKKFnmRixdssq);
				this.NeoYHOcyiEOcNlzGfMmSbveqzwWh.bUNqDPnNoEBPhXXPLVGGkiyrqyqD = this.RwhUxJxbwwGZeWWPZMGikjwCefHm(yyjpESzECVBzlTQDCRWMYdxQsJmw.bUNqDPnNoEBPhXXPLVGGkiyrqyqD);
				for (int n = 0; n < this.NeoYHOcyiEOcNlzGfMmSbveqzwWh.iZAlvLSIlUBfemngabGpONTqHjBr.Length; n++)
				{
					this.NeoYHOcyiEOcNlzGfMmSbveqzwWh.iZAlvLSIlUBfemngabGpONTqHjBr[n] = this.RwhUxJxbwwGZeWWPZMGikjwCefHm(yyjpESzECVBzlTQDCRWMYdxQsJmw.iZAlvLSIlUBfemngabGpONTqHjBr[n]);
				}
			}
		}

		// Token: 0x060000CA RID: 202 RVA: 0x000228C0 File Offset: 0x00020AC0
		public void ElhcpaBGGahOUafdiWTMqrOdKJspA(EegVRmhDzKlDwgeYQLLOXmqEZyWQ.LuEePYLuYBFjPkHkwqNGPmKLNwrLA A_1)
		{
			this.NeoYHOcyiEOcNlzGfMmSbveqzwWh.kDFhuFBQvhuROMsHOCLpHHjIPiDmA(A_1.NeoYHOcyiEOcNlzGfMmSbveqzwWh);
			this.BdAupgemjQXUBKSNvdcYZbCkCqZV.vTmFgbkpfsCKHZxLqoxdnfODDSTb(A_1.BdAupgemjQXUBKSNvdcYZbCkCqZV);
			this.KtJcJLgVbsvLXGfwbYzekfPWFLQw = A_1.KtJcJLgVbsvLXGfwbYzekfPWFLQw;
			this.MjCJTSpujLrvnCzSfJmnLNCfEpJE = A_1.MjCJTSpujLrvnCzSfJmnLNCfEpJE;
			this.ZoIUuTqIeUYCuffAmfCSBoTdiCBM = A_1.ZoIUuTqIeUYCuffAmfCSBoTdiCBM;
			this.nFjirLZGxtrsZSQWBUxgsBhjaNfV = A_1.nFjirLZGxtrsZSQWBUxgsBhjaNfV;
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00011A49 File Offset: 0x0000FC49
		private int RwhUxJxbwwGZeWWPZMGikjwCefHm(int A_1)
		{
			return MathTools.ValueInNewRange(A_1, this.KtJcJLgVbsvLXGfwbYzekfPWFLQw, this.MjCJTSpujLrvnCzSfJmnLNCfEpJE, -65535, 65535);
		}

		// Token: 0x04000098 RID: 152
		private YYJpESzECVBzlTQDCRWMYdxQsJmw NeoYHOcyiEOcNlzGfMmSbveqzwWh;

		// Token: 0x04000099 RID: 153
		private EegVRmhDzKlDwgeYQLLOXmqEZyWQ.cklzZNoOhVlfNfEzaYtLHyCrGbqs BdAupgemjQXUBKSNvdcYZbCkCqZV;

		// Token: 0x0400009A RID: 154
		private int KtJcJLgVbsvLXGfwbYzekfPWFLQw;

		// Token: 0x0400009B RID: 155
		private int MjCJTSpujLrvnCzSfJmnLNCfEpJE;

		// Token: 0x0400009C RID: 156
		private int ZoIUuTqIeUYCuffAmfCSBoTdiCBM;

		// Token: 0x0400009D RID: 157
		private float nFjirLZGxtrsZSQWBUxgsBhjaNfV;
	}

	// Token: 0x0200000F RID: 15
	private class cklzZNoOhVlfNfEzaYtLHyCrGbqs
	{
		// Token: 0x1700001B RID: 27
		// (get) Token: 0x060000CC RID: 204 RVA: 0x00011A67 File Offset: 0x0000FC67
		public YYJpESzECVBzlTQDCRWMYdxQsJmw pcqZnVoSARUEWNlsxOqBjceAiJQs
		{
			get
			{
				return this.ZiByCsqYZsGYmrKvdnmPzWzWZqmj;
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x060000CD RID: 205 RVA: 0x00011A6F File Offset: 0x0000FC6F
		public YYJpESzECVBzlTQDCRWMYdxQsJmw YYoMyviGFVrnlTJDaWuvOkmHGlnJ
		{
			get
			{
				return this.wbTPRrilgIVYGiHEeKnQiJGkyfyT;
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x060000CE RID: 206 RVA: 0x00011A77 File Offset: 0x0000FC77
		public bool IBQhouRnHPkmvVgMdPAzbwzcekkO
		{
			get
			{
				return this.xGFKrozBBvpPWvbImSgKLjtBLTov;
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x060000CF RID: 207 RVA: 0x00011A7F File Offset: 0x0000FC7F
		public double HMNwSJFUMHkBguqnPBMyhjNvDnmY
		{
			get
			{
				return this.rEHURPbWknzadeJiYXPzJcILXoFc;
			}
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x00011A87 File Offset: 0x0000FC87
		public cklzZNoOhVlfNfEzaYtLHyCrGbqs(YYJpESzECVBzlTQDCRWMYdxQsJmw A_1)
		{
			this.ZiByCsqYZsGYmrKvdnmPzWzWZqmj = A_1;
			this.URatVGnqSVdoexctiHmGrcFeAZVg = new YYJpESzECVBzlTQDCRWMYdxQsJmw();
			this.wbTPRrilgIVYGiHEeKnQiJGkyfyT = new YYJpESzECVBzlTQDCRWMYdxQsJmw();
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00022920 File Offset: 0x00020B20
		public void ERitXZvGJoEiiEfdLHAKSrezjyTn(double A_1)
		{
			this.FUPWoBmrTIswYZsMplqkZiFMSqtI = A_1;
			this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.OXsXEeZYYccDtQxaTmxEmzsaqftA = this.ZiByCsqYZsGYmrKvdnmPzWzWZqmj.OXsXEeZYYccDtQxaTmxEmzsaqftA - this.URatVGnqSVdoexctiHmGrcFeAZVg.OXsXEeZYYccDtQxaTmxEmzsaqftA;
			this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.jaMVMrxxLbLHYVkNUClAyqrYVgap = this.ZiByCsqYZsGYmrKvdnmPzWzWZqmj.jaMVMrxxLbLHYVkNUClAyqrYVgap - this.URatVGnqSVdoexctiHmGrcFeAZVg.jaMVMrxxLbLHYVkNUClAyqrYVgap;
			this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.cHIRwRHXXwEjYNxPpAjCbLhkLixH = this.ZiByCsqYZsGYmrKvdnmPzWzWZqmj.cHIRwRHXXwEjYNxPpAjCbLhkLixH - this.URatVGnqSVdoexctiHmGrcFeAZVg.cHIRwRHXXwEjYNxPpAjCbLhkLixH;
			this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.cokAOaqKaqBoLSFrtmZPXARddvtcA = this.ZiByCsqYZsGYmrKvdnmPzWzWZqmj.cokAOaqKaqBoLSFrtmZPXARddvtcA - this.URatVGnqSVdoexctiHmGrcFeAZVg.cokAOaqKaqBoLSFrtmZPXARddvtcA;
			this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.wSjjkJcaHRrAjnFdlfmmqMxOmcGC = this.ZiByCsqYZsGYmrKvdnmPzWzWZqmj.wSjjkJcaHRrAjnFdlfmmqMxOmcGC - this.URatVGnqSVdoexctiHmGrcFeAZVg.wSjjkJcaHRrAjnFdlfmmqMxOmcGC;
			this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.dWHwHiuJqgFQgbTcwGKWNgXyPXDLA = this.ZiByCsqYZsGYmrKvdnmPzWzWZqmj.dWHwHiuJqgFQgbTcwGKWNgXyPXDLA - this.URatVGnqSVdoexctiHmGrcFeAZVg.dWHwHiuJqgFQgbTcwGKWNgXyPXDLA;
			for (int i = 0; i < this.ZiByCsqYZsGYmrKvdnmPzWzWZqmj.AQhLmzfZMTQHPRLBUcEEMNbuKcNd.Length; i++)
			{
				this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.AQhLmzfZMTQHPRLBUcEEMNbuKcNd[i] = this.ZiByCsqYZsGYmrKvdnmPzWzWZqmj.AQhLmzfZMTQHPRLBUcEEMNbuKcNd[i] - this.URatVGnqSVdoexctiHmGrcFeAZVg.AQhLmzfZMTQHPRLBUcEEMNbuKcNd[i];
			}
			for (int j = 0; j < this.ZiByCsqYZsGYmrKvdnmPzWzWZqmj.UpLIdneJFMWOLFpxWPvqVMVbbxrT.Length; j++)
			{
				this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.UpLIdneJFMWOLFpxWPvqVMVbbxrT[j] = this.ZiByCsqYZsGYmrKvdnmPzWzWZqmj.UpLIdneJFMWOLFpxWPvqVMVbbxrT[j] - this.URatVGnqSVdoexctiHmGrcFeAZVg.UpLIdneJFMWOLFpxWPvqVMVbbxrT[j];
			}
			for (int k = 0; k < this.ZiByCsqYZsGYmrKvdnmPzWzWZqmj.eNrbHJbOHpezkLYOAFIbOIIqegzX.Length; k++)
			{
				this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.eNrbHJbOHpezkLYOAFIbOIIqegzX[k] = (this.ZiByCsqYZsGYmrKvdnmPzWzWZqmj.eNrbHJbOHpezkLYOAFIbOIIqegzX[k] != this.URatVGnqSVdoexctiHmGrcFeAZVg.eNrbHJbOHpezkLYOAFIbOIIqegzX[k]);
			}
			this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.pSKxiDxLkWbwPahWieUAFKBnyVXOA = this.ZiByCsqYZsGYmrKvdnmPzWzWZqmj.pSKxiDxLkWbwPahWieUAFKBnyVXOA - this.URatVGnqSVdoexctiHmGrcFeAZVg.pSKxiDxLkWbwPahWieUAFKBnyVXOA;
			this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.BRqLbDVCIyhCIDEgyhWQarqLglHNA = this.ZiByCsqYZsGYmrKvdnmPzWzWZqmj.BRqLbDVCIyhCIDEgyhWQarqLglHNA - this.URatVGnqSVdoexctiHmGrcFeAZVg.BRqLbDVCIyhCIDEgyhWQarqLglHNA;
			this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.ErmEHXkpeZLQaxlStIhBatAEmNrVA = this.ZiByCsqYZsGYmrKvdnmPzWzWZqmj.ErmEHXkpeZLQaxlStIhBatAEmNrVA - this.URatVGnqSVdoexctiHmGrcFeAZVg.ErmEHXkpeZLQaxlStIhBatAEmNrVA;
			this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.FUzIkIKzoqgZgkmFnoAukNBmRUoS = this.ZiByCsqYZsGYmrKvdnmPzWzWZqmj.FUzIkIKzoqgZgkmFnoAukNBmRUoS - this.URatVGnqSVdoexctiHmGrcFeAZVg.FUzIkIKzoqgZgkmFnoAukNBmRUoS;
			this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.AqmJYIgqEHBbfOXZPNRdijKrAuzcA = this.ZiByCsqYZsGYmrKvdnmPzWzWZqmj.AqmJYIgqEHBbfOXZPNRdijKrAuzcA - this.URatVGnqSVdoexctiHmGrcFeAZVg.AqmJYIgqEHBbfOXZPNRdijKrAuzcA;
			this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.HwrgKLGSLdmDOudMfeFLwpzRcrnMA = this.ZiByCsqYZsGYmrKvdnmPzWzWZqmj.HwrgKLGSLdmDOudMfeFLwpzRcrnMA - this.URatVGnqSVdoexctiHmGrcFeAZVg.HwrgKLGSLdmDOudMfeFLwpzRcrnMA;
			for (int l = 0; l < this.ZiByCsqYZsGYmrKvdnmPzWzWZqmj.FDRMiiddqimGjBvlYEcXYJBfUotl.Length; l++)
			{
				this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.FDRMiiddqimGjBvlYEcXYJBfUotl[l] = this.ZiByCsqYZsGYmrKvdnmPzWzWZqmj.FDRMiiddqimGjBvlYEcXYJBfUotl[l] - this.URatVGnqSVdoexctiHmGrcFeAZVg.FDRMiiddqimGjBvlYEcXYJBfUotl[l];
			}
			this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.DNiKfdUBbDbyYvNEIYQpIIuEkUOc = this.ZiByCsqYZsGYmrKvdnmPzWzWZqmj.DNiKfdUBbDbyYvNEIYQpIIuEkUOc - this.URatVGnqSVdoexctiHmGrcFeAZVg.DNiKfdUBbDbyYvNEIYQpIIuEkUOc;
			this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.SjIanMwRZanFxSPcWIasCtfeJUDLA = this.ZiByCsqYZsGYmrKvdnmPzWzWZqmj.SjIanMwRZanFxSPcWIasCtfeJUDLA - this.URatVGnqSVdoexctiHmGrcFeAZVg.SjIanMwRZanFxSPcWIasCtfeJUDLA;
			this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.UPFgOJsqTDXYLChvoCCopCmEhNkU = this.ZiByCsqYZsGYmrKvdnmPzWzWZqmj.UPFgOJsqTDXYLChvoCCopCmEhNkU - this.URatVGnqSVdoexctiHmGrcFeAZVg.UPFgOJsqTDXYLChvoCCopCmEhNkU;
			this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.BnnDwCVefHbLhAtdTFuZKMBKUCOaA = this.ZiByCsqYZsGYmrKvdnmPzWzWZqmj.BnnDwCVefHbLhAtdTFuZKMBKUCOaA - this.URatVGnqSVdoexctiHmGrcFeAZVg.BnnDwCVefHbLhAtdTFuZKMBKUCOaA;
			this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.OPSqgYfXYxMCGlXmkRGGYmlKbuwE = this.ZiByCsqYZsGYmrKvdnmPzWzWZqmj.OPSqgYfXYxMCGlXmkRGGYmlKbuwE - this.URatVGnqSVdoexctiHmGrcFeAZVg.OPSqgYfXYxMCGlXmkRGGYmlKbuwE;
			this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.IqXnDRnGhmmONzYryPcuCGPeLigb = this.ZiByCsqYZsGYmrKvdnmPzWzWZqmj.IqXnDRnGhmmONzYryPcuCGPeLigb - this.URatVGnqSVdoexctiHmGrcFeAZVg.IqXnDRnGhmmONzYryPcuCGPeLigb;
			for (int m = 0; m < this.ZiByCsqYZsGYmrKvdnmPzWzWZqmj.jVwKAvrEQhnOEbbmghZKgSxWMzWb.Length; m++)
			{
				this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.jVwKAvrEQhnOEbbmghZKgSxWMzWb[m] = this.ZiByCsqYZsGYmrKvdnmPzWzWZqmj.jVwKAvrEQhnOEbbmghZKgSxWMzWb[m] - this.URatVGnqSVdoexctiHmGrcFeAZVg.jVwKAvrEQhnOEbbmghZKgSxWMzWb[m];
			}
			this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.poVASmNsBSlAtTPnURPlgnNwTVek = this.ZiByCsqYZsGYmrKvdnmPzWzWZqmj.poVASmNsBSlAtTPnURPlgnNwTVek - this.URatVGnqSVdoexctiHmGrcFeAZVg.poVASmNsBSlAtTPnURPlgnNwTVek;
			this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.XkMBVQdmpNGnXqtLMjtjjQOgKxlo = this.ZiByCsqYZsGYmrKvdnmPzWzWZqmj.XkMBVQdmpNGnXqtLMjtjjQOgKxlo - this.URatVGnqSVdoexctiHmGrcFeAZVg.XkMBVQdmpNGnXqtLMjtjjQOgKxlo;
			this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.fRcuxBeAsTaTtMENjxmkXJOBBRWQ = this.ZiByCsqYZsGYmrKvdnmPzWzWZqmj.fRcuxBeAsTaTtMENjxmkXJOBBRWQ - this.URatVGnqSVdoexctiHmGrcFeAZVg.fRcuxBeAsTaTtMENjxmkXJOBBRWQ;
			this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.QtxcrLVuJlcuwnYvfiMLXZQrvYBP = this.ZiByCsqYZsGYmrKvdnmPzWzWZqmj.QtxcrLVuJlcuwnYvfiMLXZQrvYBP - this.URatVGnqSVdoexctiHmGrcFeAZVg.QtxcrLVuJlcuwnYvfiMLXZQrvYBP;
			this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.tjJfDPGccOQkrXYoKKFnmRixdssq = this.ZiByCsqYZsGYmrKvdnmPzWzWZqmj.tjJfDPGccOQkrXYoKKFnmRixdssq - this.URatVGnqSVdoexctiHmGrcFeAZVg.tjJfDPGccOQkrXYoKKFnmRixdssq;
			this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.bUNqDPnNoEBPhXXPLVGGkiyrqyqD = this.ZiByCsqYZsGYmrKvdnmPzWzWZqmj.bUNqDPnNoEBPhXXPLVGGkiyrqyqD - this.URatVGnqSVdoexctiHmGrcFeAZVg.bUNqDPnNoEBPhXXPLVGGkiyrqyqD;
			for (int n = 0; n < this.ZiByCsqYZsGYmrKvdnmPzWzWZqmj.iZAlvLSIlUBfemngabGpONTqHjBr.Length; n++)
			{
				this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.iZAlvLSIlUBfemngabGpONTqHjBr[n] = this.ZiByCsqYZsGYmrKvdnmPzWzWZqmj.iZAlvLSIlUBfemngabGpONTqHjBr[n] - this.URatVGnqSVdoexctiHmGrcFeAZVg.iZAlvLSIlUBfemngabGpONTqHjBr[n];
			}
			this.xGFKrozBBvpPWvbImSgKLjtBLTov = this.jNUJgmIWXcCMNpbgjIJMFnabegIhA();
			if (this.xGFKrozBBvpPWvbImSgKLjtBLTov)
			{
				this.rEHURPbWknzadeJiYXPzJcILXoFc = A_1;
				this.URatVGnqSVdoexctiHmGrcFeAZVg.kDFhuFBQvhuROMsHOCLpHHjIPiDmA(this.ZiByCsqYZsGYmrKvdnmPzWzWZqmj);
			}
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00011AAC File Offset: 0x0000FCAC
		public void vTmFgbkpfsCKHZxLqoxdnfODDSTb(EegVRmhDzKlDwgeYQLLOXmqEZyWQ.cklzZNoOhVlfNfEzaYtLHyCrGbqs A_1)
		{
			this.FUPWoBmrTIswYZsMplqkZiFMSqtI = A_1.FUPWoBmrTIswYZsMplqkZiFMSqtI;
			this.URatVGnqSVdoexctiHmGrcFeAZVg.kDFhuFBQvhuROMsHOCLpHHjIPiDmA(A_1.URatVGnqSVdoexctiHmGrcFeAZVg);
			this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.kDFhuFBQvhuROMsHOCLpHHjIPiDmA(A_1.wbTPRrilgIVYGiHEeKnQiJGkyfyT);
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x00022E24 File Offset: 0x00021024
		private bool jNUJgmIWXcCMNpbgjIJMFnabegIhA()
		{
			if (this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.jaMVMrxxLbLHYVkNUClAyqrYVgap != 0)
			{
				return true;
			}
			if (this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.cHIRwRHXXwEjYNxPpAjCbLhkLixH != 0)
			{
				return true;
			}
			if (this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.cokAOaqKaqBoLSFrtmZPXARddvtcA != 0)
			{
				return true;
			}
			if (this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.wSjjkJcaHRrAjnFdlfmmqMxOmcGC != 0)
			{
				return true;
			}
			if (this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.dWHwHiuJqgFQgbTcwGKWNgXyPXDLA != 0)
			{
				return true;
			}
			for (int i = 0; i < this.ZiByCsqYZsGYmrKvdnmPzWzWZqmj.AQhLmzfZMTQHPRLBUcEEMNbuKcNd.Length; i++)
			{
				if (this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.AQhLmzfZMTQHPRLBUcEEMNbuKcNd[i] != 0)
				{
					return true;
				}
			}
			for (int j = 0; j < this.ZiByCsqYZsGYmrKvdnmPzWzWZqmj.UpLIdneJFMWOLFpxWPvqVMVbbxrT.Length; j++)
			{
				if (this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.UpLIdneJFMWOLFpxWPvqVMVbbxrT[j] != 0)
				{
					return true;
				}
			}
			for (int k = 0; k < this.ZiByCsqYZsGYmrKvdnmPzWzWZqmj.eNrbHJbOHpezkLYOAFIbOIIqegzX.Length; k++)
			{
				if (this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.eNrbHJbOHpezkLYOAFIbOIIqegzX[k])
				{
					return true;
				}
			}
			if (this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.pSKxiDxLkWbwPahWieUAFKBnyVXOA != 0)
			{
				return true;
			}
			if (this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.BRqLbDVCIyhCIDEgyhWQarqLglHNA != 0)
			{
				return true;
			}
			if (this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.ErmEHXkpeZLQaxlStIhBatAEmNrVA != 0)
			{
				return true;
			}
			if (this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.FUzIkIKzoqgZgkmFnoAukNBmRUoS != 0)
			{
				return true;
			}
			if (this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.AqmJYIgqEHBbfOXZPNRdijKrAuzcA != 0)
			{
				return true;
			}
			if (this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.HwrgKLGSLdmDOudMfeFLwpzRcrnMA != 0)
			{
				return true;
			}
			for (int l = 0; l < this.ZiByCsqYZsGYmrKvdnmPzWzWZqmj.FDRMiiddqimGjBvlYEcXYJBfUotl.Length; l++)
			{
				if (this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.FDRMiiddqimGjBvlYEcXYJBfUotl[l] != 0)
				{
					return true;
				}
			}
			if (this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.DNiKfdUBbDbyYvNEIYQpIIuEkUOc != 0)
			{
				return true;
			}
			if (this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.SjIanMwRZanFxSPcWIasCtfeJUDLA != 0)
			{
				return true;
			}
			if (this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.UPFgOJsqTDXYLChvoCCopCmEhNkU != 0)
			{
				return true;
			}
			if (this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.BnnDwCVefHbLhAtdTFuZKMBKUCOaA != 0)
			{
				return true;
			}
			if (this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.OPSqgYfXYxMCGlXmkRGGYmlKbuwE != 0)
			{
				return true;
			}
			if (this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.IqXnDRnGhmmONzYryPcuCGPeLigb != 0)
			{
				return true;
			}
			for (int m = 0; m < this.ZiByCsqYZsGYmrKvdnmPzWzWZqmj.jVwKAvrEQhnOEbbmghZKgSxWMzWb.Length; m++)
			{
				this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.jVwKAvrEQhnOEbbmghZKgSxWMzWb[m] = this.ZiByCsqYZsGYmrKvdnmPzWzWZqmj.jVwKAvrEQhnOEbbmghZKgSxWMzWb[m] - this.URatVGnqSVdoexctiHmGrcFeAZVg.jVwKAvrEQhnOEbbmghZKgSxWMzWb[m];
			}
			if (this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.poVASmNsBSlAtTPnURPlgnNwTVek != 0)
			{
				return true;
			}
			if (this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.XkMBVQdmpNGnXqtLMjtjjQOgKxlo != 0)
			{
				return true;
			}
			if (this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.fRcuxBeAsTaTtMENjxmkXJOBBRWQ != 0)
			{
				return true;
			}
			if (this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.QtxcrLVuJlcuwnYvfiMLXZQrvYBP != 0)
			{
				return true;
			}
			if (this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.tjJfDPGccOQkrXYoKKFnmRixdssq != 0)
			{
				return true;
			}
			if (this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.bUNqDPnNoEBPhXXPLVGGkiyrqyqD != 0)
			{
				return true;
			}
			for (int n = 0; n < this.ZiByCsqYZsGYmrKvdnmPzWzWZqmj.iZAlvLSIlUBfemngabGpONTqHjBr.Length; n++)
			{
				if (this.wbTPRrilgIVYGiHEeKnQiJGkyfyT.iZAlvLSIlUBfemngabGpONTqHjBr[n] != 0)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0400009E RID: 158
		private double FUPWoBmrTIswYZsMplqkZiFMSqtI;

		// Token: 0x0400009F RID: 159
		private YYJpESzECVBzlTQDCRWMYdxQsJmw ZiByCsqYZsGYmrKvdnmPzWzWZqmj;

		// Token: 0x040000A0 RID: 160
		private YYJpESzECVBzlTQDCRWMYdxQsJmw URatVGnqSVdoexctiHmGrcFeAZVg;

		// Token: 0x040000A1 RID: 161
		private YYJpESzECVBzlTQDCRWMYdxQsJmw wbTPRrilgIVYGiHEeKnQiJGkyfyT;

		// Token: 0x040000A2 RID: 162
		private bool xGFKrozBBvpPWvbImSgKLjtBLTov;

		// Token: 0x040000A3 RID: 163
		private double rEHURPbWknzadeJiYXPzJcILXoFc;
	}

	// Token: 0x02000010 RID: 16
	private class sOIlNQjlCZQqpGwxzRZguVCPvZdA
	{
		// Token: 0x060000D4 RID: 212 RVA: 0x00011ADC File Offset: 0x0000FCDC
		public sOIlNQjlCZQqpGwxzRZguVCPvZdA()
		{
			this.FjpbujDhJDaIbAprkoAheebJZdpn = new List<EegVRmhDzKlDwgeYQLLOXmqEZyWQ.sOIlNQjlCZQqpGwxzRZguVCPvZdA.qfiPwkxItqSfpsAEKkCrrzGgsfhX>();
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x000230A4 File Offset: 0x000212A4
		public void UGdokbizLfwJTGCviGhpfduDeGYAA(EegVRmhDzKlDwgeYQLLOXmqEZyWQ.QdMZFMtlfQhQKDNMJyQwkIRbuYQaA A_1)
		{
			if (A_1 == null)
			{
				return;
			}
			int count = this.FjpbujDhJDaIbAprkoAheebJZdpn.Count;
			for (int i = 0; i < count; i++)
			{
				if (this.FjpbujDhJDaIbAprkoAheebJZdpn[i].FgXKywMDiKCCVcIWNFnopXwsgHNc(A_1, EegVRmhDzKlDwgeYQLLOXmqEZyWQ.sOIlNQjlCZQqpGwxzRZguVCPvZdA.URDmmhVnYuFiqjknGrmGiHQjqbHXA.Exact))
				{
					this.FjpbujDhJDaIbAprkoAheebJZdpn[i].MgWDBqxcpiJGrlGaGqodLbilbdbfA = A_1.rewiredId;
					this.FjpbujDhJDaIbAprkoAheebJZdpn[i].MEYdnBdYczEaGDJljdtTuxzhBBJic = A_1.instanceGuid;
					this.FjpbujDhJDaIbAprkoAheebJZdpn[i].YXwOCRKgYTZAehYgkuLmhplALUVb = A_1.RZUnguYnAqioSHleZpmJBfjffmWrB;
					this.FjpbujDhJDaIbAprkoAheebJZdpn[i].TwFDDOcvkIlULXypJwcymdRfuUHEA = A_1.inputManagerId;
					this.FjpbujDhJDaIbAprkoAheebJZdpn[i].GxPjyPeKujZoqptSgFEJBmENKCuh = A_1.ZxbHCNOJtQYRvuDnwItidmVnjdItA;
					this.FjpbujDhJDaIbAprkoAheebJZdpn[i].rzbaoEppkjLlEvdxZTCCgeRFuBYg = A_1.RaZCtPmgczQBiZFTazHjfpnYLqsE;
					this.FjpbujDhJDaIbAprkoAheebJZdpn[i].KWsDZJHeThxIJEkjWywvNTwHdClv = A_1.KyzrzMlEAMdwJomPLzJAmmNTUDA;
					this.GvZpEHhyjADtMVuJwMkUOXHMNtPJ(A_1.rewiredId, A_1.instanceGuid, i);
					return;
				}
			}
			this.FjpbujDhJDaIbAprkoAheebJZdpn.Add(new EegVRmhDzKlDwgeYQLLOXmqEZyWQ.sOIlNQjlCZQqpGwxzRZguVCPvZdA.qfiPwkxItqSfpsAEKkCrrzGgsfhX
			{
				MgWDBqxcpiJGrlGaGqodLbilbdbfA = A_1.rewiredId,
				MEYdnBdYczEaGDJljdtTuxzhBBJic = A_1.instanceGuid,
				YXwOCRKgYTZAehYgkuLmhplALUVb = A_1.RZUnguYnAqioSHleZpmJBfjffmWrB,
				TwFDDOcvkIlULXypJwcymdRfuUHEA = A_1.inputManagerId,
				GxPjyPeKujZoqptSgFEJBmENKCuh = A_1.ZxbHCNOJtQYRvuDnwItidmVnjdItA,
				rzbaoEppkjLlEvdxZTCCgeRFuBYg = A_1.RaZCtPmgczQBiZFTazHjfpnYLqsE,
				KWsDZJHeThxIJEkjWywvNTwHdClv = A_1.KyzrzMlEAMdwJomPLzJAmmNTUDA
			});
			this.GvZpEHhyjADtMVuJwMkUOXHMNtPJ(A_1.rewiredId, A_1.instanceGuid, this.FjpbujDhJDaIbAprkoAheebJZdpn.Count - 1);
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x00023224 File Offset: 0x00021424
		public bool ZfZLGmRduHxAJgBhajvOxLynPIhm(EegVRmhDzKlDwgeYQLLOXmqEZyWQ.QdMZFMtlfQhQKDNMJyQwkIRbuYQaA A_1, EegVRmhDzKlDwgeYQLLOXmqEZyWQ.sOIlNQjlCZQqpGwxzRZguVCPvZdA.URDmmhVnYuFiqjknGrmGiHQjqbHXA A_2)
		{
			int count = this.FjpbujDhJDaIbAprkoAheebJZdpn.Count;
			for (int i = 0; i < count; i++)
			{
				if (this.FjpbujDhJDaIbAprkoAheebJZdpn[i].FgXKywMDiKCCVcIWNFnopXwsgHNc(A_1, A_2))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x00011AEF File Offset: 0x0000FCEF
		public IEnumerable<EegVRmhDzKlDwgeYQLLOXmqEZyWQ.sOIlNQjlCZQqpGwxzRZguVCPvZdA.qfiPwkxItqSfpsAEKkCrrzGgsfhX> ygTdDuvQvayurANURgaBoKuheDgE(EegVRmhDzKlDwgeYQLLOXmqEZyWQ.QdMZFMtlfQhQKDNMJyQwkIRbuYQaA A_1, EegVRmhDzKlDwgeYQLLOXmqEZyWQ.sOIlNQjlCZQqpGwxzRZguVCPvZdA.URDmmhVnYuFiqjknGrmGiHQjqbHXA A_2)
		{
			int count = this.FjpbujDhJDaIbAprkoAheebJZdpn.Count;
			int num;
			for (int i = 0; i < count; i = num + 1)
			{
				if (this.FjpbujDhJDaIbAprkoAheebJZdpn[i].FgXKywMDiKCCVcIWNFnopXwsgHNc(A_1, A_2))
				{
					yield return this.FjpbujDhJDaIbAprkoAheebJZdpn[i];
				}
				num = i;
			}
			yield break;
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x00023264 File Offset: 0x00021464
		private void GvZpEHhyjADtMVuJwMkUOXHMNtPJ(int A_1, Guid A_2, int A_3)
		{
			for (int i = this.FjpbujDhJDaIbAprkoAheebJZdpn.Count - 1; i >= 0; i--)
			{
				if (i != A_3 && (this.FjpbujDhJDaIbAprkoAheebJZdpn[i].MgWDBqxcpiJGrlGaGqodLbilbdbfA == A_1 || this.FjpbujDhJDaIbAprkoAheebJZdpn[i].MEYdnBdYczEaGDJljdtTuxzhBBJic == A_2))
				{
					this.FjpbujDhJDaIbAprkoAheebJZdpn.RemoveAt(i);
				}
			}
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x000232C8 File Offset: 0x000214C8
		public virtual string ghnJtbJSLsqCcrGegFzpglaXlrkBA()
		{
			string text = "";
			text = text + "Joystick records: " + this.FjpbujDhJDaIbAprkoAheebJZdpn.Count.ToString() + "\n";
			for (int i = 0; i < this.FjpbujDhJDaIbAprkoAheebJZdpn.Count; i++)
			{
				text = text + "Record " + i.ToString() + ":\n";
				text = text + this.FjpbujDhJDaIbAprkoAheebJZdpn[i].ToString() + "\n\n";
			}
			return text;
		}

		// Token: 0x040000A4 RID: 164
		private List<EegVRmhDzKlDwgeYQLLOXmqEZyWQ.sOIlNQjlCZQqpGwxzRZguVCPvZdA.qfiPwkxItqSfpsAEKkCrrzGgsfhX> FjpbujDhJDaIbAprkoAheebJZdpn;

		// Token: 0x02000011 RID: 17
		public enum URDmmhVnYuFiqjknGrmGiHQjqbHXA
		{
			// Token: 0x040000A6 RID: 166
			Exact,
			// Token: 0x040000A7 RID: 167
			Approximate
		}

		// Token: 0x02000012 RID: 18
		public class qfiPwkxItqSfpsAEKkCrrzGgsfhX
		{
			// Token: 0x060000DA RID: 218 RVA: 0x0002334C File Offset: 0x0002154C
			public bool FgXKywMDiKCCVcIWNFnopXwsgHNc(EegVRmhDzKlDwgeYQLLOXmqEZyWQ.QdMZFMtlfQhQKDNMJyQwkIRbuYQaA A_1, EegVRmhDzKlDwgeYQLLOXmqEZyWQ.sOIlNQjlCZQqpGwxzRZguVCPvZdA.URDmmhVnYuFiqjknGrmGiHQjqbHXA A_2)
			{
				if (A_1.rewiredId == this.MgWDBqxcpiJGrlGaGqodLbilbdbfA)
				{
					return true;
				}
				if (this.GxPjyPeKujZoqptSgFEJBmENKCuh != A_1.ZxbHCNOJtQYRvuDnwItidmVnjdItA)
				{
					return false;
				}
				if (this.rzbaoEppkjLlEvdxZTCCgeRFuBYg != A_1.RaZCtPmgczQBiZFTazHjfpnYLqsE)
				{
					return false;
				}
				if (this.KWsDZJHeThxIJEkjWywvNTwHdClv != A_1.KyzrzMlEAMdwJomPLzJAmmNTUDA)
				{
					return false;
				}
				if (A_2 == EegVRmhDzKlDwgeYQLLOXmqEZyWQ.sOIlNQjlCZQqpGwxzRZguVCPvZdA.URDmmhVnYuFiqjknGrmGiHQjqbHXA.Exact)
				{
					return this.MEYdnBdYczEaGDJljdtTuxzhBBJic == A_1.instanceGuid;
				}
				if (A_2 == EegVRmhDzKlDwgeYQLLOXmqEZyWQ.sOIlNQjlCZQqpGwxzRZguVCPvZdA.URDmmhVnYuFiqjknGrmGiHQjqbHXA.Approximate)
				{
					return this.YXwOCRKgYTZAehYgkuLmhplALUVb == A_1.RZUnguYnAqioSHleZpmJBfjffmWrB;
				}
				throw new NotImplementedException();
			}

			// Token: 0x060000DB RID: 219 RVA: 0x000233CC File Offset: 0x000215CC
			public virtual string IRHeTByGGqqhHgqUyhtkEEwAxMOK()
			{
				string str = "" + "rewiredId = " + this.MgWDBqxcpiJGrlGaGqodLbilbdbfA.ToString() + "\n";
				string str2 = "instanceGuid = ";
				Guid guid = this.MEYdnBdYczEaGDJljdtTuxzhBBJic;
				string str3 = str + str2 + guid.ToString() + "\n";
				string str4 = "typeIdentifierGuid = ";
				guid = this.YXwOCRKgYTZAehYgkuLmhplALUVb;
				return str3 + str4 + guid.ToString() + "\n" + "lastInputManagerId = " + this.TwFDDOcvkIlULXypJwcymdRfuUHEA.ToString() + "\n" + "hardwareAxisCount = " + this.GxPjyPeKujZoqptSgFEJBmENKCuh.ToString() + "\n" + "hardwareButtonCount = " + this.rzbaoEppkjLlEvdxZTCCgeRFuBYg.ToString() + "\n" + "hardwareHatCount = " + this.KWsDZJHeThxIJEkjWywvNTwHdClv.ToString() + "\n";
			}

			// Token: 0x040000A8 RID: 168
			public int MgWDBqxcpiJGrlGaGqodLbilbdbfA;

			// Token: 0x040000A9 RID: 169
			public Guid MEYdnBdYczEaGDJljdtTuxzhBBJic;

			// Token: 0x040000AA RID: 170
			public Guid YXwOCRKgYTZAehYgkuLmhplALUVb;

			// Token: 0x040000AB RID: 171
			public int TwFDDOcvkIlULXypJwcymdRfuUHEA;

			// Token: 0x040000AC RID: 172
			public int GxPjyPeKujZoqptSgFEJBmENKCuh;

			// Token: 0x040000AD RID: 173
			public int rzbaoEppkjLlEvdxZTCCgeRFuBYg;

			// Token: 0x040000AE RID: 174
			public int KWsDZJHeThxIJEkjWywvNTwHdClv;
		}
	}

	// Token: 0x02000014 RID: 20
	private class gjEmKFEtFFvkzEDCLMkMaOflbYfHA
	{
		// Token: 0x17000021 RID: 33
		// (get) Token: 0x060000E5 RID: 229 RVA: 0x00011B3E File Offset: 0x0000FD3E
		public bool dJbWicDeZmNWrpfusCNnqcXlEieI
		{
			get
			{
				return this.cNucNNEhNNaQqNAsTOlCILepcYriA != null && this.seBZaSJniIwqYBAVCzeDgazXEptA != null;
			}
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00011B53 File Offset: 0x0000FD53
		public gjEmKFEtFFvkzEDCLMkMaOflbYfHA(EegVRmhDzKlDwgeYQLLOXmqEZyWQ.QdMZFMtlfQhQKDNMJyQwkIRbuYQaA A_1, kvqducHUWPYYsnUhPdQAbkdahByH A_2)
		{
			this.cNucNNEhNNaQqNAsTOlCILepcYriA = A_1;
			this.seBZaSJniIwqYBAVCzeDgazXEptA = A_2;
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x000235B4 File Offset: 0x000217B4
		public static List<kvqducHUWPYYsnUhPdQAbkdahByH> quJvFBwkngcsqAwHOIdfgwkzOJsAA(List<EegVRmhDzKlDwgeYQLLOXmqEZyWQ.gjEmKFEtFFvkzEDCLMkMaOflbYfHA> A_0)
		{
			if (A_0 == null)
			{
				return new List<kvqducHUWPYYsnUhPdQAbkdahByH>();
			}
			List<kvqducHUWPYYsnUhPdQAbkdahByH> list = new List<kvqducHUWPYYsnUhPdQAbkdahByH>();
			for (int i = 0; i < A_0.Count; i++)
			{
				if (A_0[i].dJbWicDeZmNWrpfusCNnqcXlEieI)
				{
					list.Add(A_0[i].seBZaSJniIwqYBAVCzeDgazXEptA);
				}
			}
			return list;
		}

		// Token: 0x040000B9 RID: 185
		public EegVRmhDzKlDwgeYQLLOXmqEZyWQ.QdMZFMtlfQhQKDNMJyQwkIRbuYQaA cNucNNEhNNaQqNAsTOlCILepcYriA;

		// Token: 0x040000BA RID: 186
		public kvqducHUWPYYsnUhPdQAbkdahByH seBZaSJniIwqYBAVCzeDgazXEptA;
	}

	// Token: 0x02000015 RID: 21
	private class jllQWdwdbqqkfIpnkHuaGEuZnMgjb
	{
		// Token: 0x060000E8 RID: 232 RVA: 0x00011B69 File Offset: 0x0000FD69
		public jllQWdwdbqqkfIpnkHuaGEuZnMgjb(kgqhUexiHegpQmaRUvQyXXyfTECW A_1)
		{
			this.SQJLJhItWamgELfsXHEzLmqeRUGJ = A_1;
		}

		// Token: 0x040000BB RID: 187
		public kgqhUexiHegpQmaRUvQyXXyfTECW SQJLJhItWamgELfsXHEzLmqeRUGJ;
	}

	// Token: 0x02000016 RID: 22
	private class JXeosiJzHZtCjnOuUAKmKMkIbjpl
	{
		// Token: 0x060000E9 RID: 233 RVA: 0x00023604 File Offset: 0x00021804
		public JXeosiJzHZtCjnOuUAKmKMkIbjpl()
		{
			this.dsctPFacChiTqJplRaQfeAbfHDZCb = new aZbrTJbdkEqNgMSlZADNlszSrpmR.AnIursTJiGuiIahXHibSRdYFdKfZ
			{
				OnJGzWMJOkxkATlpluSVlPnmrMIH = (uint)Marshal.SizeOf(typeof(aZbrTJbdkEqNgMSlZADNlszSrpmR.AnIursTJiGuiIahXHibSRdYFdKfZ)),
				GHNkjnBJUjplzLmywRadbNMWldFA = true,
				IdQtdOHFkZFQHtYTifxMEDStAZLB = true,
				UxYWMbUdjVSbIGFBRessNrffemhT = false,
				AplKVHuYukjdyoKgcEqKUHODyLzy = true,
				TemHGbdWzAXkpLQfGyOlqEjldWEvA = IntPtr.Zero
			};
			this.xuCdoOPOrRhGNqAMSGGNKbAVpNhK = aZbrTJbdkEqNgMSlZADNlszSrpmR.vCxDyydNFJNMDqHSEqWWufpOoHJUA.qjIByCWlgxekxDObTIDlPXbeauoB();
			this.HdMMiWzxSTDbomVRqlYepLcdkoWy = new NativeBuffer((int)this.xuCdoOPOrRhGNqAMSGGNKbAVpNhK.JoJOgnnMFOFJfjMLWcwRlZpkptgUA);
			this.HdMMiWzxSTDbomVRqlYepLcdkoWy.Write(this.xuCdoOPOrRhGNqAMSGGNKbAVpNhK.JoJOgnnMFOFJfjMLWcwRlZpkptgUA, 0);
		}

		// Token: 0x060000EA RID: 234 RVA: 0x000236A0 File Offset: 0x000218A0
		public bool JcdGaIKyfKrHBnyNverthqBwyExGA()
		{
			int num = this.gtJdVKeKahvVgeUIeRxheIdCfAJBb();
			if (num == this.aiODKbeCNXvFgSJBADTsdJRmbARFb)
			{
				return false;
			}
			this.aiODKbeCNXvFgSJBADTsdJRmbARFb = num;
			return true;
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00011B78 File Offset: 0x0000FD78
		public void LXetPvfTwnUHTTOyXftnhEOdjRpC(int A_1)
		{
			this.aiODKbeCNXvFgSJBADTsdJRmbARFb = A_1;
		}

		// Token: 0x060000EC RID: 236 RVA: 0x000236C8 File Offset: 0x000218C8
		private int gtJdVKeKahvVgeUIeRxheIdCfAJBb()
		{
			int result;
			try
			{
				result = hVaQpyMLtSMUpozCEslGMGuQGKOz.ujPsFjeHpPPlwkphybzwdVjrgbFhb(ref this.dsctPFacChiTqJplRaQfeAbfHDZCb, this.HdMMiWzxSTDbomVRqlYepLcdkoWy);
			}
			catch
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x040000BC RID: 188
		private aZbrTJbdkEqNgMSlZADNlszSrpmR.AnIursTJiGuiIahXHibSRdYFdKfZ dsctPFacChiTqJplRaQfeAbfHDZCb;

		// Token: 0x040000BD RID: 189
		private aZbrTJbdkEqNgMSlZADNlszSrpmR.vCxDyydNFJNMDqHSEqWWufpOoHJUA xuCdoOPOrRhGNqAMSGGNKbAVpNhK;

		// Token: 0x040000BE RID: 190
		private NativeBuffer HdMMiWzxSTDbomVRqlYepLcdkoWy;

		// Token: 0x040000BF RID: 191
		private int aiODKbeCNXvFgSJBADTsdJRmbARFb;
	}

	// Token: 0x02000017 RID: 23
	private enum bDaMPLbvtdjQzowjFMIFQhUBzvdN
	{
		// Token: 0x040000C1 RID: 193
		Device = 17,
		// Token: 0x040000C2 RID: 194
		Mouse,
		// Token: 0x040000C3 RID: 195
		Keyboard,
		// Token: 0x040000C4 RID: 196
		Joystick,
		// Token: 0x040000C5 RID: 197
		Gamepad,
		// Token: 0x040000C6 RID: 198
		Driving,
		// Token: 0x040000C7 RID: 199
		Flight,
		// Token: 0x040000C8 RID: 200
		FirstPerson,
		// Token: 0x040000C9 RID: 201
		ControlDevice,
		// Token: 0x040000CA RID: 202
		ScreenPointer,
		// Token: 0x040000CB RID: 203
		Remote,
		// Token: 0x040000CC RID: 204
		Supplemental
	}
}
