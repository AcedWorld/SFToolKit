using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rewired;
using Rewired.Data;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Utils;

// Token: 0x020000A5 RID: 165
internal class PtyzRgDbfAwsKrNQvzaTCdKrMDEL : PlatformInputManager
{
	// Token: 0x060005C4 RID: 1476 RVA: 0x00032EE8 File Offset: 0x000310E8
	public PtyzRgDbfAwsKrNQvzaTCdKrMDEL(ConfigVars A_1, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> A_2, Func<int> A_3, Func<PidVid, bool> A_4)
	{
		try
		{
			this.iRbGmnyduzCaenEWzkBlmnBEhdfA = A_1;
			this.jmGRldHJaFMNIiETsaGZdsGWGOsn = A_2;
			this.YBNspDucZaMgAFOIuhnUdvQRcGEjb = A_3;
			this.YxycmpoIAVzoeAaCfUJMFRwrYEM = A_4;
			this.LHjDjVGKhajpCcViDvFwIGHeCMFmA = this;
			this.DVbZrZdxWzbrFuErIavaegZSovAh = new KoqnWHFwJPblbhUrpRFiXiyhTclN(A_1, true, false, false);
			this.DVbZrZdxWzbrFuErIavaegZSovAh.DeviceChangedEvent += this.SystemDeviceConnected;
			this.bJCMwJkbtINpjPTQQvtDVlppusQN = new Action<int, ControllerDataUpdater>(this.UpdateControllerData);
		}
		catch (Exception)
		{
			this.OnDestroy();
			throw;
		}
	}

	// Token: 0x1700011E RID: 286
	// (get) Token: 0x060005C5 RID: 1477 RVA: 0x00013FC1 File Offset: 0x000121C1
	[CustomObfuscation(rename = false)]
	public override int deviceCount
	{
		get
		{
			return this.CHPAFqCbPzdrcfhnFrhpLWRwdWtCA;
		}
	}

	// Token: 0x1700011F RID: 287
	// (get) Token: 0x060005C6 RID: 1478 RVA: 0x00013FC9 File Offset: 0x000121C9
	[CustomObfuscation(rename = false)]
	public override PlatformInputManager primaryInputManager
	{
		get
		{
			return this.LHjDjVGKhajpCcViDvFwIGHeCMFmA;
		}
	}

	// Token: 0x17000120 RID: 288
	// (get) Token: 0x060005C7 RID: 1479 RVA: 0x00013FD1 File Offset: 0x000121D1
	[CustomObfuscation(rename = false)]
	public override IInputSource inputSource
	{
		get
		{
			return this.DVbZrZdxWzbrFuErIavaegZSovAh;
		}
	}

	// Token: 0x17000121 RID: 289
	// (get) Token: 0x060005C8 RID: 1480 RVA: 0x00013FD9 File Offset: 0x000121D9
	[CustomObfuscation(rename = false)]
	public override InputSource inputSourceType
	{
		get
		{
			return InputSource.WindowsGamingInput;
		}
	}

	// Token: 0x060005C9 RID: 1481 RVA: 0x00013FDD File Offset: 0x000121DD
	[CustomObfuscation(rename = false)]
	public override void Initialize()
	{
		this.SPsntRAxnjJCLAACZwGdpjdiHImG = new PtyzRgDbfAwsKrNQvzaTCdKrMDEL.VzjtmVDcvZNZeRXuDWtoLaYtdEyf();
		this.DVbZrZdxWzbrFuErIavaegZSovAh.PXgUmyKEtzWjEhRUZeiVnEGamthg();
		this.CAqhhBhAHbCosLBpybAfaZDGPgQV();
	}

	// Token: 0x060005CA RID: 1482 RVA: 0x00032F74 File Offset: 0x00031174
	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		if (this.DVbZrZdxWzbrFuErIavaegZSovAh != null)
		{
			this.DVbZrZdxWzbrFuErIavaegZSovAh.Update();
		}
		if (this.PaSLCnfPtCCVxfQQnHrkVkMpIqPK)
		{
			this.BSlkciPrgctZJbqyYcQcNaRxEFhQ();
		}
		if (this.DVbZrZdxWzbrFuErIavaegZSovAh != null)
		{
			this.DVbZrZdxWzbrFuErIavaegZSovAh.UpdateDevices(updateLoop);
		}
		this.OKCbChDlrERAhUliEcQGEKEhaYiDA();
		if (this.DVbZrZdxWzbrFuErIavaegZSovAh != null)
		{
			this.DVbZrZdxWzbrFuErIavaegZSovAh.UpdateFinished();
		}
	}

	// Token: 0x060005CB RID: 1483 RVA: 0x00032FD0 File Offset: 0x000311D0
	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (this.OlWbSdARfrQMkcKlZtbBJCZgNmXTb != null)
		{
			int count = this.OlWbSdARfrQMkcKlZtbBJCZgNmXTb.Count;
			for (int i = 0; i < count; i++)
			{
				if (this.OlWbSdARfrQMkcKlZtbBJCZgNmXTb[i] != null)
				{
					this.OlWbSdARfrQMkcKlZtbBJCZgNmXTb[i].Dispose();
				}
			}
		}
		if (this.DVbZrZdxWzbrFuErIavaegZSovAh != null)
		{
			this.DVbZrZdxWzbrFuErIavaegZSovAh.Dispose();
		}
	}

	// Token: 0x060005CC RID: 1484 RVA: 0x00013FFB File Offset: 0x000121FB
	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return this.bJCMwJkbtINpjPTQQvtDVlppusQN;
	}

	// Token: 0x060005CD RID: 1485 RVA: 0x00033030 File Offset: 0x00031230
	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
	{
		for (int i = 0; i < this.CHPAFqCbPzdrcfhnFrhpLWRwdWtCA; i++)
		{
			if (this.OlWbSdARfrQMkcKlZtbBJCZgNmXTb[i].inputManagerId == inputManagerId)
			{
				this.OlWbSdARfrQMkcKlZtbBJCZgNmXTb[i].FillData(data);
				return;
			}
		}
		Logger.LogError("Invalid joystick Id " + inputManagerId.ToString() + "!");
	}

	// Token: 0x060005CE RID: 1486 RVA: 0x00014003 File Offset: 0x00012203
	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		this.PaSLCnfPtCCVxfQQnHrkVkMpIqPK = true;
		if (this._SystemDeviceConnectedEvent != null)
		{
			this._SystemDeviceConnectedEvent();
		}
	}

	// Token: 0x060005CF RID: 1487 RVA: 0x0001401F File Offset: 0x0001221F
	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		this.PaSLCnfPtCCVxfQQnHrkVkMpIqPK = true;
		if (this._SystemDeviceDisconnectedEvent != null)
		{
			this._SystemDeviceDisconnectedEvent();
		}
	}

	// Token: 0x060005D0 RID: 1488 RVA: 0x000116E9 File Offset: 0x0000F8E9
	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
	}

	// Token: 0x060005D1 RID: 1489 RVA: 0x0001403B File Offset: 0x0001223B
	[CustomObfuscation(rename = false)]
	public override IUnifiedMouseSource GetUnifiedMouseSource()
	{
		return this.DVbZrZdxWzbrFuErIavaegZSovAh.tnrubUCEScgFSYfAPXDptgyaQtRs;
	}

	// Token: 0x060005D2 RID: 1490 RVA: 0x00014048 File Offset: 0x00012248
	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		return this.DVbZrZdxWzbrFuErIavaegZSovAh.wqOMnLZmEGZzaMlNPadPwJDMzFEB;
	}

	// Token: 0x060005D3 RID: 1491 RVA: 0x00014055 File Offset: 0x00012255
	protected bool HMXFSAWAFRyVeMKgVYiqecRHWDds(PidVid A_1)
	{
		return this.YxycmpoIAVzoeAaCfUJMFRwrYEM(A_1);
	}

	// Token: 0x17000122 RID: 290
	// (get) Token: 0x060005D4 RID: 1492 RVA: 0x00013FD1 File Offset: 0x000121D1
	protected KoqnWHFwJPblbhUrpRFiXiyhTclN UjZGztDvAknWMDtffcBWjgqaYiKV
	{
		get
		{
			return this.DVbZrZdxWzbrFuErIavaegZSovAh;
		}
	}

	// Token: 0x060005D5 RID: 1493 RVA: 0x00014063 File Offset: 0x00012263
	private void CAqhhBhAHbCosLBpybAfaZDGPgQV()
	{
		this.UAEDmkHioxYhNytfRbNlaohSULvgA(this.AqaoZBOgKRaPQByFBSFzUvteCcES());
	}

	// Token: 0x060005D6 RID: 1494 RVA: 0x00033090 File Offset: 0x00031290
	private void UAEDmkHioxYhNytfRbNlaohSULvgA(IList<cWYIDMjUnhAyDysKZVfQnpWFBosr> A_1)
	{
		int num = 0;
		List<PtyzRgDbfAwsKrNQvzaTCdKrMDEL.rLLEpWNIdAmUAAQjsRqpLbKUfjzs> olWbSdARfrQMkcKlZtbBJCZgNmXTb = this.OlWbSdARfrQMkcKlZtbBJCZgNmXTb;
		int chpafqCbPzdrcfhnFrhpLWRwdWtCA = this.CHPAFqCbPzdrcfhnFrhpLWRwdWtCA;
		this.OlWbSdARfrQMkcKlZtbBJCZgNmXTb = new List<PtyzRgDbfAwsKrNQvzaTCdKrMDEL.rLLEpWNIdAmUAAQjsRqpLbKUfjzs>();
		int count = A_1.Count;
		for (int i = 0; i < count; i++)
		{
			if (A_1[i] != null)
			{
				cWYIDMjUnhAyDysKZVfQnpWFBosr cWYIDMjUnhAyDysKZVfQnpWFBosr = A_1[i];
				PtyzRgDbfAwsKrNQvzaTCdKrMDEL.rLLEpWNIdAmUAAQjsRqpLbKUfjzs rLLEpWNIdAmUAAQjsRqpLbKUfjzs = new PtyzRgDbfAwsKrNQvzaTCdKrMDEL.rLLEpWNIdAmUAAQjsRqpLbKUfjzs(this.jmGRldHJaFMNIiETsaGZdsGWGOsn);
				rLLEpWNIdAmUAAQjsRqpLbKUfjzs.jxGyiZparsCrgEvVAnMkAqappWZhA = cWYIDMjUnhAyDysKZVfQnpWFBosr;
				rLLEpWNIdAmUAAQjsRqpLbKUfjzs.lCcFvTtCrTkLZPGufgHVgPBpmeWk = cWYIDMjUnhAyDysKZVfQnpWFBosr.qutfHyBpippaAYryIwZDUHevSJOcb;
				rLLEpWNIdAmUAAQjsRqpLbKUfjzs.pmepseeoKJjtHcIAwcqMiXeBgVJK = cWYIDMjUnhAyDysKZVfQnpWFBosr.NeigsMKNgqriBxadCuicSosqZZfUA;
				rLLEpWNIdAmUAAQjsRqpLbKUfjzs.SjFvLyzDKNjSIinJDKKABtJvpqLY = cWYIDMjUnhAyDysKZVfQnpWFBosr.NeigsMKNgqriBxadCuicSosqZZfUA;
				rLLEpWNIdAmUAAQjsRqpLbKUfjzs.OGAVjbiZVtDsiykrejYcEcuhAxog = cWYIDMjUnhAyDysKZVfQnpWFBosr.xYPClePOxdcHpMsZUAOYEwYaLEYUA;
				rLLEpWNIdAmUAAQjsRqpLbKUfjzs.emCMAyxgnWOVMqwbFIQoWHfhcwUp = cWYIDMjUnhAyDysKZVfQnpWFBosr.pdDGLQcYxZlfgfzFTeYpTDKVmzAy;
				rLLEpWNIdAmUAAQjsRqpLbKUfjzs.vFyRIZZkqWhkSjMPogGJhhipvIrV = cWYIDMjUnhAyDysKZVfQnpWFBosr.JTikleOeSlGOoElynpFUVDzqpgfLA;
				rLLEpWNIdAmUAAQjsRqpLbKUfjzs.DTGJJDrKPnekpUZHMLLJUnmxFMHiA = cWYIDMjUnhAyDysKZVfQnpWFBosr.XutaxsEVhZSgtkDYtABhhFfylHap;
				rLLEpWNIdAmUAAQjsRqpLbKUfjzs.qgAeukdHfHLkchAkdLkUvoBExeirb = cWYIDMjUnhAyDysKZVfQnpWFBosr.ZHLcFNCBLFwHLLJVTBcSRIqDRZWNA;
				rLLEpWNIdAmUAAQjsRqpLbKUfjzs.uzOmYyxYymAlDdNSpDLmGJwSbsxZA = cWYIDMjUnhAyDysKZVfQnpWFBosr.ORMogkZMylcNfXEHavwWfGxkNOdQ;
				rLLEpWNIdAmUAAQjsRqpLbKUfjzs.xdXcoUsbRvAinkUgySjoOVyTWAsJA = cWYIDMjUnhAyDysKZVfQnpWFBosr.qnMfhUBNGhcgORXYQQcdpJaknxJL;
				rLLEpWNIdAmUAAQjsRqpLbKUfjzs.extension = cWYIDMjUnhAyDysKZVfQnpWFBosr.ZzoqxsTAAxAYHRIoOGcoxhtCqXje;
				rLLEpWNIdAmUAAQjsRqpLbKUfjzs.jxGyiZparsCrgEvVAnMkAqappWZhA = cWYIDMjUnhAyDysKZVfQnpWFBosr;
				rLLEpWNIdAmUAAQjsRqpLbKUfjzs.YIkmNQJTwkyBtNCqYiNPkJDWPJMs();
				this.OlWbSdARfrQMkcKlZtbBJCZgNmXTb.Add(rLLEpWNIdAmUAAQjsRqpLbKUfjzs);
				num++;
			}
		}
		this.CHPAFqCbPzdrcfhnFrhpLWRwdWtCA = num;
		this.RqySRZXKgkRfsCxcnYWnnsWdcETE(chpafqCbPzdrcfhnFrhpLWRwdWtCA, num, olWbSdARfrQMkcKlZtbBJCZgNmXTb, this.OlWbSdARfrQMkcKlZtbBJCZgNmXTb);
		for (int j = 0; j < num; j++)
		{
			if (this._UpdateControllerInfoEvent != null)
			{
				this._UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(this.OlWbSdARfrQMkcKlZtbBJCZgNmXTb[j]));
			}
		}
		this.msoiWhhmJXPqGAsmjJlaxgoThEnQ(olWbSdARfrQMkcKlZtbBJCZgNmXTb, this.OlWbSdARfrQMkcKlZtbBJCZgNmXTb, false);
		this.msoiWhhmJXPqGAsmjJlaxgoThEnQ(this.OlWbSdARfrQMkcKlZtbBJCZgNmXTb, olWbSdARfrQMkcKlZtbBJCZgNmXTb, true);
	}

	// Token: 0x060005D7 RID: 1495 RVA: 0x00033224 File Offset: 0x00031424
	private void OKCbChDlrERAhUliEcQGEKEhaYiDA()
	{
		for (int i = 0; i < this.CHPAFqCbPzdrcfhnFrhpLWRwdWtCA; i++)
		{
			PtyzRgDbfAwsKrNQvzaTCdKrMDEL.rLLEpWNIdAmUAAQjsRqpLbKUfjzs rLLEpWNIdAmUAAQjsRqpLbKUfjzs = this.OlWbSdARfrQMkcKlZtbBJCZgNmXTb[i];
			if (rLLEpWNIdAmUAAQjsRqpLbKUfjzs != null)
			{
				rLLEpWNIdAmUAAQjsRqpLbKUfjzs.Update();
			}
		}
	}

	// Token: 0x060005D8 RID: 1496 RVA: 0x00014071 File Offset: 0x00012271
	private IList<cWYIDMjUnhAyDysKZVfQnpWFBosr> AqaoZBOgKRaPQByFBSFzUvteCcES()
	{
		return this.DVbZrZdxWzbrFuErIavaegZSovAh.GetJoysticks<cWYIDMjUnhAyDysKZVfQnpWFBosr>();
	}

	// Token: 0x060005D9 RID: 1497 RVA: 0x00033258 File Offset: 0x00031458
	private void RqySRZXKgkRfsCxcnYWnnsWdcETE(int A_1, int A_2, List<PtyzRgDbfAwsKrNQvzaTCdKrMDEL.rLLEpWNIdAmUAAQjsRqpLbKUfjzs> A_3, List<PtyzRgDbfAwsKrNQvzaTCdKrMDEL.rLLEpWNIdAmUAAQjsRqpLbKUfjzs> A_4)
	{
		if (A_2 > 0)
		{
			A_4.Sort(new Comparison<PtyzRgDbfAwsKrNQvzaTCdKrMDEL.rLLEpWNIdAmUAAQjsRqpLbKUfjzs>(PtyzRgDbfAwsKrNQvzaTCdKrMDEL.rLLEpWNIdAmUAAQjsRqpLbKUfjzs.mWfDPpxkopCcwECdPBJzyVMfaOTq));
		}
		if (A_1 > 0 && A_2 > 0)
		{
			this.KxMtqtXQpglelBlnESgpsMiQUuao(A_2, A_4, A_1, A_3, PtyzRgDbfAwsKrNQvzaTCdKrMDEL.VzjtmVDcvZNZeRXuDWtoLaYtdEyf.ptylkjEigoIphfibXmIPaFxomLLhb.Exact);
			this.KxMtqtXQpglelBlnESgpsMiQUuao(A_2, A_4, A_1, A_3, PtyzRgDbfAwsKrNQvzaTCdKrMDEL.VzjtmVDcvZNZeRXuDWtoLaYtdEyf.ptylkjEigoIphfibXmIPaFxomLLhb.Approximate);
		}
		this.nEuDJaDCwdejVismihybewIrDkIr(A_2, A_4, PtyzRgDbfAwsKrNQvzaTCdKrMDEL.VzjtmVDcvZNZeRXuDWtoLaYtdEyf.ptylkjEigoIphfibXmIPaFxomLLhb.Exact);
		this.nEuDJaDCwdejVismihybewIrDkIr(A_2, A_4, PtyzRgDbfAwsKrNQvzaTCdKrMDEL.VzjtmVDcvZNZeRXuDWtoLaYtdEyf.ptylkjEigoIphfibXmIPaFxomLLhb.Approximate);
		for (int i = 0; i < A_2; i++)
		{
			PtyzRgDbfAwsKrNQvzaTCdKrMDEL.rLLEpWNIdAmUAAQjsRqpLbKUfjzs rLLEpWNIdAmUAAQjsRqpLbKUfjzs = A_4[i];
			if (rLLEpWNIdAmUAAQjsRqpLbKUfjzs != null && rLLEpWNIdAmUAAQjsRqpLbKUfjzs.inputManagerId < 0)
			{
				rLLEpWNIdAmUAAQjsRqpLbKUfjzs.inputManagerId = this.IScVarbivcyDJaQTVZUpHHuiVIDX(A_4);
				rLLEpWNIdAmUAAQjsRqpLbKUfjzs.rewiredId = this.YBNspDucZaMgAFOIuhnUdvQRcGEjb();
				this.SPsntRAxnjJCLAACZwGdpjdiHImG.UzVerTIqJjmPiNWUOPmlYOdJDJzd(rLLEpWNIdAmUAAQjsRqpLbKUfjzs);
			}
		}
		A_4.Sort(new Comparison<PtyzRgDbfAwsKrNQvzaTCdKrMDEL.rLLEpWNIdAmUAAQjsRqpLbKUfjzs>(PtyzRgDbfAwsKrNQvzaTCdKrMDEL.rLLEpWNIdAmUAAQjsRqpLbKUfjzs.TjmJVuENZRkyRwLbEGjSZJbgMMVI));
	}

	// Token: 0x060005DA RID: 1498 RVA: 0x00033314 File Offset: 0x00031514
	private void YImotQnRWesXMyEjoxwDKwIsHWUA(List<PtyzRgDbfAwsKrNQvzaTCdKrMDEL.rLLEpWNIdAmUAAQjsRqpLbKUfjzs> A_1, int A_2, int A_3)
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

	// Token: 0x060005DB RID: 1499 RVA: 0x00033360 File Offset: 0x00031560
	private bool YngCwKFQAliUhTkCXPMtilpyqcoKA(List<PtyzRgDbfAwsKrNQvzaTCdKrMDEL.rLLEpWNIdAmUAAQjsRqpLbKUfjzs> A_1, int A_2)
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

	// Token: 0x060005DC RID: 1500 RVA: 0x0003339C File Offset: 0x0003159C
	private int IScVarbivcyDJaQTVZUpHHuiVIDX(List<PtyzRgDbfAwsKrNQvzaTCdKrMDEL.rLLEpWNIdAmUAAQjsRqpLbKUfjzs> A_1)
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

	// Token: 0x060005DD RID: 1501 RVA: 0x000333E8 File Offset: 0x000315E8
	private bool NPzRLcDUUSQtqiKAqsNvEgnGFIJb(List<PtyzRgDbfAwsKrNQvzaTCdKrMDEL.rLLEpWNIdAmUAAQjsRqpLbKUfjzs> A_1, int A_2)
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

	// Token: 0x060005DE RID: 1502 RVA: 0x00033420 File Offset: 0x00031620
	private void KxMtqtXQpglelBlnESgpsMiQUuao(int A_1, List<PtyzRgDbfAwsKrNQvzaTCdKrMDEL.rLLEpWNIdAmUAAQjsRqpLbKUfjzs> A_2, int A_3, List<PtyzRgDbfAwsKrNQvzaTCdKrMDEL.rLLEpWNIdAmUAAQjsRqpLbKUfjzs> A_4, PtyzRgDbfAwsKrNQvzaTCdKrMDEL.VzjtmVDcvZNZeRXuDWtoLaYtdEyf.ptylkjEigoIphfibXmIPaFxomLLhb A_5)
	{
		int num = (A_5 == PtyzRgDbfAwsKrNQvzaTCdKrMDEL.VzjtmVDcvZNZeRXuDWtoLaYtdEyf.ptylkjEigoIphfibXmIPaFxomLLhb.Exact) ? 2 : 1;
		for (int i = 0; i < A_1; i++)
		{
			PtyzRgDbfAwsKrNQvzaTCdKrMDEL.rLLEpWNIdAmUAAQjsRqpLbKUfjzs rLLEpWNIdAmUAAQjsRqpLbKUfjzs = A_2[i];
			if (rLLEpWNIdAmUAAQjsRqpLbKUfjzs != null && rLLEpWNIdAmUAAQjsRqpLbKUfjzs.inputManagerId < 0)
			{
				for (int j = 0; j < A_3; j++)
				{
					PtyzRgDbfAwsKrNQvzaTCdKrMDEL.rLLEpWNIdAmUAAQjsRqpLbKUfjzs rLLEpWNIdAmUAAQjsRqpLbKUfjzs2 = A_4[j];
					if (rLLEpWNIdAmUAAQjsRqpLbKUfjzs2 != null && !this.NPzRLcDUUSQtqiKAqsNvEgnGFIJb(A_2, rLLEpWNIdAmUAAQjsRqpLbKUfjzs2.rewiredId) && rLLEpWNIdAmUAAQjsRqpLbKUfjzs.HzEmZgLpTQHtenNdaJdMLlkfBASo(rLLEpWNIdAmUAAQjsRqpLbKUfjzs2) >= num)
					{
						rLLEpWNIdAmUAAQjsRqpLbKUfjzs.VehvUykesMBMSVrTFmXaeKUuOERH(rLLEpWNIdAmUAAQjsRqpLbKUfjzs2);
						this.SPsntRAxnjJCLAACZwGdpjdiHImG.UzVerTIqJjmPiNWUOPmlYOdJDJzd(rLLEpWNIdAmUAAQjsRqpLbKUfjzs);
					}
				}
			}
		}
	}

	// Token: 0x060005DF RID: 1503 RVA: 0x000334A0 File Offset: 0x000316A0
	private void nEuDJaDCwdejVismihybewIrDkIr(int A_1, List<PtyzRgDbfAwsKrNQvzaTCdKrMDEL.rLLEpWNIdAmUAAQjsRqpLbKUfjzs> A_2, PtyzRgDbfAwsKrNQvzaTCdKrMDEL.VzjtmVDcvZNZeRXuDWtoLaYtdEyf.ptylkjEigoIphfibXmIPaFxomLLhb A_3)
	{
		for (int i = 0; i < A_1; i++)
		{
			PtyzRgDbfAwsKrNQvzaTCdKrMDEL.rLLEpWNIdAmUAAQjsRqpLbKUfjzs rLLEpWNIdAmUAAQjsRqpLbKUfjzs = A_2[i];
			if (rLLEpWNIdAmUAAQjsRqpLbKUfjzs != null && rLLEpWNIdAmUAAQjsRqpLbKUfjzs.inputManagerId < 0)
			{
				PtyzRgDbfAwsKrNQvzaTCdKrMDEL.VzjtmVDcvZNZeRXuDWtoLaYtdEyf.NPADjMSeAaYRGRnOuiZmXyslkyUd npadjMSeAaYRGRnOuiZmXyslkyUd = null;
				foreach (PtyzRgDbfAwsKrNQvzaTCdKrMDEL.VzjtmVDcvZNZeRXuDWtoLaYtdEyf.NPADjMSeAaYRGRnOuiZmXyslkyUd npadjMSeAaYRGRnOuiZmXyslkyUd2 in this.SPsntRAxnjJCLAACZwGdpjdiHImG.FtvqFKxMmnaLrJFIoGXpKkIUHTYX(rLLEpWNIdAmUAAQjsRqpLbKUfjzs, A_3))
				{
					if (!this.NPzRLcDUUSQtqiKAqsNvEgnGFIJb(A_2, npadjMSeAaYRGRnOuiZmXyslkyUd2.GvhibdsfSEyXkEHDkJKPTRPFPJOK) && npadjMSeAaYRGRnOuiZmXyslkyUd2.IbNVFfEaJVDzzIMTCpFMdmqXZEvU >= 0)
					{
						npadjMSeAaYRGRnOuiZmXyslkyUd = npadjMSeAaYRGRnOuiZmXyslkyUd2;
						break;
					}
				}
				if (npadjMSeAaYRGRnOuiZmXyslkyUd != null)
				{
					int num = npadjMSeAaYRGRnOuiZmXyslkyUd.IbNVFfEaJVDzzIMTCpFMdmqXZEvU;
					if (!this.YngCwKFQAliUhTkCXPMtilpyqcoKA(A_2, num))
					{
						num = this.IScVarbivcyDJaQTVZUpHHuiVIDX(A_2);
						npadjMSeAaYRGRnOuiZmXyslkyUd.IbNVFfEaJVDzzIMTCpFMdmqXZEvU = num;
					}
					rLLEpWNIdAmUAAQjsRqpLbKUfjzs.inputManagerId = num;
					rLLEpWNIdAmUAAQjsRqpLbKUfjzs.rewiredId = npadjMSeAaYRGRnOuiZmXyslkyUd.GvhibdsfSEyXkEHDkJKPTRPFPJOK;
					this.SPsntRAxnjJCLAACZwGdpjdiHImG.UzVerTIqJjmPiNWUOPmlYOdJDJzd(rLLEpWNIdAmUAAQjsRqpLbKUfjzs);
				}
			}
		}
	}

	// Token: 0x060005E0 RID: 1504 RVA: 0x00033584 File Offset: 0x00031784
	private void BSlkciPrgctZJbqyYcQcNaRxEFhQ()
	{
		this.DVbZrZdxWzbrFuErIavaegZSovAh.PXgUmyKEtzWjEhRUZeiVnEGamthg();
		IList<cWYIDMjUnhAyDysKZVfQnpWFBosr> list = this.AqaoZBOgKRaPQByFBSFzUvteCcES();
		if (this.HOInPmQWYpsWvDCeFletxnaDkxTS(list))
		{
			this.UAEDmkHioxYhNytfRbNlaohSULvgA(list);
		}
		this.PaSLCnfPtCCVxfQQnHrkVkMpIqPK = false;
	}

	// Token: 0x060005E1 RID: 1505 RVA: 0x000335BC File Offset: 0x000317BC
	private bool HOInPmQWYpsWvDCeFletxnaDkxTS(IList<cWYIDMjUnhAyDysKZVfQnpWFBosr> A_1)
	{
		int count = A_1.Count;
		for (int i = 0; i < count; i++)
		{
			if (A_1[i] != null && !this.KrLALXisxKxjikcZdhlKJuzpNyujA(A_1[i].qutfHyBpippaAYryIwZDUHevSJOcb))
			{
				return true;
			}
		}
		int count2 = this.OlWbSdARfrQMkcKlZtbBJCZgNmXTb.Count;
		for (int j = 0; j < count2; j++)
		{
			if (this.OlWbSdARfrQMkcKlZtbBJCZgNmXTb[j] != null && !this.mXDdcgBFQoDZtYSceVrPQPBXZRMtA(A_1, this.OlWbSdARfrQMkcKlZtbBJCZgNmXTb[j].lCcFvTtCrTkLZPGufgHVgPBpmeWk))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060005E2 RID: 1506 RVA: 0x00033640 File Offset: 0x00031840
	private bool KrLALXisxKxjikcZdhlKJuzpNyujA(Guid A_1)
	{
		int count = this.OlWbSdARfrQMkcKlZtbBJCZgNmXTb.Count;
		for (int i = 0; i < count; i++)
		{
			if (this.OlWbSdARfrQMkcKlZtbBJCZgNmXTb[i] != null && this.OlWbSdARfrQMkcKlZtbBJCZgNmXTb[i].lCcFvTtCrTkLZPGufgHVgPBpmeWk == A_1)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060005E3 RID: 1507 RVA: 0x00033690 File Offset: 0x00031890
	private bool mXDdcgBFQoDZtYSceVrPQPBXZRMtA(IList<cWYIDMjUnhAyDysKZVfQnpWFBosr> A_1, Guid A_2)
	{
		int count = A_1.Count;
		for (int i = 0; i < count; i++)
		{
			if (A_1[i] != null && A_1[i].qutfHyBpippaAYryIwZDUHevSJOcb == A_2)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060005E4 RID: 1508 RVA: 0x000336D0 File Offset: 0x000318D0
	private void msoiWhhmJXPqGAsmjJlaxgoThEnQ(List<PtyzRgDbfAwsKrNQvzaTCdKrMDEL.rLLEpWNIdAmUAAQjsRqpLbKUfjzs> A_1, List<PtyzRgDbfAwsKrNQvzaTCdKrMDEL.rLLEpWNIdAmUAAQjsRqpLbKUfjzs> A_2, bool A_3)
	{
		if (A_1 == null)
		{
			return;
		}
		int num = (A_1 != null) ? A_1.Count : 0;
		int num2 = (A_2 != null) ? A_2.Count : 0;
		for (int i = 0; i < num; i++)
		{
			PtyzRgDbfAwsKrNQvzaTCdKrMDEL.rLLEpWNIdAmUAAQjsRqpLbKUfjzs rLLEpWNIdAmUAAQjsRqpLbKUfjzs = A_1[i];
			if (rLLEpWNIdAmUAAQjsRqpLbKUfjzs != null)
			{
				bool flag = false;
				if (A_2 != null)
				{
					for (int j = 0; j < num2; j++)
					{
						PtyzRgDbfAwsKrNQvzaTCdKrMDEL.rLLEpWNIdAmUAAQjsRqpLbKUfjzs rLLEpWNIdAmUAAQjsRqpLbKUfjzs2 = A_2[j];
						if (rLLEpWNIdAmUAAQjsRqpLbKUfjzs2 != null && rLLEpWNIdAmUAAQjsRqpLbKUfjzs.lCcFvTtCrTkLZPGufgHVgPBpmeWk == rLLEpWNIdAmUAAQjsRqpLbKUfjzs2.lCcFvTtCrTkLZPGufgHVgPBpmeWk)
						{
							flag = true;
							break;
						}
					}
				}
				if (!flag)
				{
					this.fCSqOKaBTffBECcykrDKOKPYyuDuA(A_1[i], A_3);
				}
			}
		}
	}

	// Token: 0x060005E5 RID: 1509 RVA: 0x0001407E File Offset: 0x0001227E
	private void fCSqOKaBTffBECcykrDKOKPYyuDuA(PtyzRgDbfAwsKrNQvzaTCdKrMDEL.rLLEpWNIdAmUAAQjsRqpLbKUfjzs A_1, bool A_2)
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

	// Token: 0x04000647 RID: 1607
	private const bool vgoBMnIAvHYrVoSVJKlrcjLTKNqTA = true;

	// Token: 0x04000648 RID: 1608
	private KoqnWHFwJPblbhUrpRFiXiyhTclN DVbZrZdxWzbrFuErIavaegZSovAh;

	// Token: 0x04000649 RID: 1609
	private List<PtyzRgDbfAwsKrNQvzaTCdKrMDEL.rLLEpWNIdAmUAAQjsRqpLbKUfjzs> OlWbSdARfrQMkcKlZtbBJCZgNmXTb;

	// Token: 0x0400064A RID: 1610
	private int CHPAFqCbPzdrcfhnFrhpLWRwdWtCA;

	// Token: 0x0400064B RID: 1611
	private PtyzRgDbfAwsKrNQvzaTCdKrMDEL.VzjtmVDcvZNZeRXuDWtoLaYtdEyf SPsntRAxnjJCLAACZwGdpjdiHImG;

	// Token: 0x0400064C RID: 1612
	private bool PaSLCnfPtCCVxfQQnHrkVkMpIqPK;

	// Token: 0x0400064D RID: 1613
	private ConfigVars iRbGmnyduzCaenEWzkBlmnBEhdfA;

	// Token: 0x0400064E RID: 1614
	private Action<int, ControllerDataUpdater> bJCMwJkbtINpjPTQQvtDVlppusQN;

	// Token: 0x0400064F RID: 1615
	private PlatformInputManager LHjDjVGKhajpCcViDvFwIGHeCMFmA;

	// Token: 0x04000650 RID: 1616
	private readonly Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> jmGRldHJaFMNIiETsaGZdsGWGOsn;

	// Token: 0x04000651 RID: 1617
	private readonly Func<int> YBNspDucZaMgAFOIuhnUdvQRcGEjb;

	// Token: 0x04000652 RID: 1618
	private Func<PidVid, bool> YxycmpoIAVzoeAaCfUJMFRwrYEM;

	// Token: 0x020000A6 RID: 166
	private class rLLEpWNIdAmUAAQjsRqpLbKUfjzs : IInputManagerJoystick, IInputManagerJoystickPublic, IDisposable
	{
		// Token: 0x17000123 RID: 291
		// (get) Token: 0x060005E6 RID: 1510 RVA: 0x000140B6 File Offset: 0x000122B6
		// (set) Token: 0x060005E7 RID: 1511 RVA: 0x000140BE File Offset: 0x000122BE
		[CustomObfuscation(rename = false)]
		public int rewiredId
		{
			get
			{
				return this.xmJTMqbwVVJWavgHKmwjQcBZzEgy;
			}
			set
			{
				this.xmJTMqbwVVJWavgHKmwjQcBZzEgy = value;
			}
		}

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x060005E8 RID: 1512 RVA: 0x000140C7 File Offset: 0x000122C7
		// (set) Token: 0x060005E9 RID: 1513 RVA: 0x000140CF File Offset: 0x000122CF
		[CustomObfuscation(rename = false)]
		public int inputManagerId
		{
			get
			{
				return this.hnJxyTpAbDjwOVQnPAEMaTsFDjEFA;
			}
			set
			{
				this.hnJxyTpAbDjwOVQnPAEMaTsFDjEFA = value;
			}
		}

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x060005EA RID: 1514 RVA: 0x000140D8 File Offset: 0x000122D8
		[CustomObfuscation(rename = false)]
		public string name
		{
			get
			{
				if (!(this.wlBZTytcfTwCpHkcxYlEnZmFdZaE != "Unknown Controller"))
				{
					return this.SjFvLyzDKNjSIinJDKKABtJvpqLY;
				}
				return this.wlBZTytcfTwCpHkcxYlEnZmFdZaE;
			}
		}

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x060005EB RID: 1515 RVA: 0x00033764 File Offset: 0x00031964
		[CustomObfuscation(rename = false)]
		public long? systemId
		{
			get
			{
				if (this.hnJxyTpAbDjwOVQnPAEMaTsFDjEFA < 0)
				{
					return null;
				}
				return new long?((long)this.hnJxyTpAbDjwOVQnPAEMaTsFDjEFA);
			}
		}

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x060005EC RID: 1516 RVA: 0x00011826 File Offset: 0x0000FA26
		[CustomObfuscation(rename = false)]
		public int unityId
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x060005ED RID: 1517 RVA: 0x000140F9 File Offset: 0x000122F9
		[CustomObfuscation(rename = false)]
		public Guid instanceGuid
		{
			get
			{
				return this.lCcFvTtCrTkLZPGufgHVgPBpmeWk;
			}
		}

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x060005EE RID: 1518 RVA: 0x00014101 File Offset: 0x00012301
		[CustomObfuscation(rename = false)]
		public Guid persistentGuid
		{
			get
			{
				if (this.jxGyiZparsCrgEvVAnMkAqappWZhA == null)
				{
					return Guid.Empty;
				}
				return this.jxGyiZparsCrgEvVAnMkAqappWZhA.GxQWDnWFqTsRqvUacmcQUdquNytv;
			}
		}

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x060005EF RID: 1519 RVA: 0x0001411C File Offset: 0x0001231C
		// (set) Token: 0x060005F0 RID: 1520 RVA: 0x00014124 File Offset: 0x00012324
		[CustomObfuscation(rename = false)]
		public Controller.Extension extension { get; set; }

		// Token: 0x060005F1 RID: 1521 RVA: 0x0001412D File Offset: 0x0001232D
		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
			if (!this.uzOmYyxYymAlDdNSpDLmGJwSbsxZA)
			{
				return;
			}
			this.jxGyiZparsCrgEvVAnMkAqappWZhA.EgGBgmYVkpUkWIuSUKuCQnULsuVT(motorIndex, amount, false);
		}

		// Token: 0x060005F2 RID: 1522 RVA: 0x00014146 File Offset: 0x00012346
		[CustomObfuscation(rename = false)]
		public void StopVibration()
		{
			if (!this.uzOmYyxYymAlDdNSpDLmGJwSbsxZA)
			{
				return;
			}
			this.jxGyiZparsCrgEvVAnMkAqappWZhA.YFOxJaolxWZSruTORTIZSGBfsYNU();
		}

		// Token: 0x060005F3 RID: 1523 RVA: 0x0001415C File Offset: 0x0001235C
		public rLLEpWNIdAmUAAQjsRqpLbKUfjzs(Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> A_1)
		{
			this.ciEPBxjBqLYSnYMETIlhaGCvVkYIA = A_1;
			this.hnJxyTpAbDjwOVQnPAEMaTsFDjEFA = -1;
			this.xmJTMqbwVVJWavgHKmwjQcBZzEgy = -1;
		}

		// Token: 0x060005F4 RID: 1524 RVA: 0x00033790 File Offset: 0x00031990
		public void YIkmNQJTwkyBtNCqYiNPkJDWPJMs()
		{
			this.oCHvYlBEczYmxKysfztclnHBYpoc = MiscTools.CreateGuidHashSHA1(this.SjFvLyzDKNjSIinJDKKABtJvpqLY + this.OGAVjbiZVtDsiykrejYcEcuhAxog.ToProductGuid().ToString());
			this.ayCBXZlNExwrYiNhafxSiBfLNoPmA = this.vFyRIZZkqWhkSjMPogGJhhipvIrV;
			this.CRvgnvzYYscLVeVniHvDZLbTufNW = this.DTGJJDrKPnekpUZHMLLJUnmxFMHiA + this.qgAeukdHfHLkchAkdLkUvoBExeirb * 8;
			this.tVINJWhsloFwxwJtEBGcxtyxDPrK();
			this.zjkKVtqnwgAqaWXfjhaJCCUBsRed = this.NIKWSBIJxhFWxpkAkKQphefrDFwh.hardwareMapIdentifier.guid;
			this.wlBZTytcfTwCpHkcxYlEnZmFdZaE = this.NIKWSBIJxhFWxpkAkKQphefrDFwh.controllerName;
			this.cbsFjQHLjAwDVuKARNueODoeyuti = (this.zjkKVtqnwgAqaWXfjhaJCCUBsRed == Guid.Empty);
			this.mYxJWgqClItyHBgKwcjKKWqLzFvi = new float[this.ayCBXZlNExwrYiNhafxSiBfLNoPmA];
			this.sJNXkbJJdkesRrkpkScfxGxXeDzz = new float[this.CRvgnvzYYscLVeVniHvDZLbTufNW];
			this.LtqSkmamPWpaxkRYSOYBhWZdHBon = new bool[this.CRvgnvzYYscLVeVniHvDZLbTufNW];
			if (this.CRvgnvzYYscLVeVniHvDZLbTufNW > 0)
			{
				HardwareJoystickMap.Platform_WindowsWGI_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_WindowsWGI_Base)this.NIKWSBIJxhFWxpkAkKQphefrDFwh.map).Buttons_orig;
				if (buttons_orig != null)
				{
					for (int i = 0; i < buttons_orig.Length; i++)
					{
						this.LtqSkmamPWpaxkRYSOYBhWZdHBon[i] = buttons_orig[i].buttonInfo.isPressureSensitive;
					}
				}
			}
			this.Update();
		}

		// Token: 0x060005F5 RID: 1525 RVA: 0x000338B4 File Offset: 0x00031AB4
		public void VehvUykesMBMSVrTFmXaeKUuOERH(PtyzRgDbfAwsKrNQvzaTCdKrMDEL.rLLEpWNIdAmUAAQjsRqpLbKUfjzs A_1)
		{
			if (A_1 == null)
			{
				return;
			}
			this.hnJxyTpAbDjwOVQnPAEMaTsFDjEFA = A_1.hnJxyTpAbDjwOVQnPAEMaTsFDjEFA;
			this.xmJTMqbwVVJWavgHKmwjQcBZzEgy = A_1.xmJTMqbwVVJWavgHKmwjQcBZzEgy;
			for (int i = 0; i < MathTools.Min(this.sJNXkbJJdkesRrkpkScfxGxXeDzz.Length, A_1.sJNXkbJJdkesRrkpkScfxGxXeDzz.Length); i++)
			{
				this.sJNXkbJJdkesRrkpkScfxGxXeDzz[i] = A_1.sJNXkbJJdkesRrkpkScfxGxXeDzz[i];
			}
			for (int j = 0; j < MathTools.Min(this.LtqSkmamPWpaxkRYSOYBhWZdHBon.Length, A_1.LtqSkmamPWpaxkRYSOYBhWZdHBon.Length); j++)
			{
				this.LtqSkmamPWpaxkRYSOYBhWZdHBon[j] = A_1.LtqSkmamPWpaxkRYSOYBhWZdHBon[j];
			}
			for (int k = 0; k < MathTools.Min(this.mYxJWgqClItyHBgKwcjKKWqLzFvi.Length, A_1.mYxJWgqClItyHBgKwcjKKWqLzFvi.Length); k++)
			{
				this.mYxJWgqClItyHBgKwcjKKWqLzFvi[k] = A_1.mYxJWgqClItyHBgKwcjKKWqLzFvi[k];
			}
			this.KKJBqVWMigksNbEwFAQbsUnGVkEr = A_1.KKJBqVWMigksNbEwFAQbsUnGVkEr;
		}

		// Token: 0x060005F6 RID: 1526 RVA: 0x00014179 File Offset: 0x00012379
		[CustomObfuscation(rename = false)]
		public void Update()
		{
			this.RSlFAicNCftGkfCTeKtostVwPRYN();
			this.XebKGGBJOKoCpEDgwLERkCRfuyeD();
		}

		// Token: 0x060005F7 RID: 1527 RVA: 0x0003397C File Offset: 0x00031B7C
		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (this.ayCBXZlNExwrYiNhafxSiBfLNoPmA != dataUpdater.axisCount || this.CRvgnvzYYscLVeVniHvDZLbTufNW != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			for (int i = 0; i < this.ayCBXZlNExwrYiNhafxSiBfLNoPmA; i++)
			{
				dataUpdater.axisValues[i] = this.mYxJWgqClItyHBgKwcjKKWqLzFvi[i];
			}
			for (int j = 0; j < this.CRvgnvzYYscLVeVniHvDZLbTufNW; j++)
			{
				if (this.LtqSkmamPWpaxkRYSOYBhWZdHBon[j])
				{
					dataUpdater.buttonPressureValues[j] = this.sJNXkbJJdkesRrkpkScfxGxXeDzz[j];
				}
				else
				{
					dataUpdater.buttonValues[j] = ((this.sJNXkbJJdkesRrkpkScfxGxXeDzz[j] > 0f) ? true : false);
				}
			}
			if (this.KKJBqVWMigksNbEwFAQbsUnGVkEr && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		// Token: 0x060005F8 RID: 1528 RVA: 0x00033A30 File Offset: 0x00031C30
		public int HzEmZgLpTQHtenNdaJdMLlkfBASo(PtyzRgDbfAwsKrNQvzaTCdKrMDEL.rLLEpWNIdAmUAAQjsRqpLbKUfjzs A_1)
		{
			if (A_1.xmJTMqbwVVJWavgHKmwjQcBZzEgy == this.xmJTMqbwVVJWavgHKmwjQcBZzEgy)
			{
				return 2;
			}
			if (this.vFyRIZZkqWhkSjMPogGJhhipvIrV != A_1.vFyRIZZkqWhkSjMPogGJhhipvIrV)
			{
				return 0;
			}
			if (this.DTGJJDrKPnekpUZHMLLJUnmxFMHiA != A_1.DTGJJDrKPnekpUZHMLLJUnmxFMHiA)
			{
				return 0;
			}
			if (this.qgAeukdHfHLkchAkdLkUvoBExeirb != A_1.qgAeukdHfHLkchAkdLkUvoBExeirb)
			{
				return 0;
			}
			if (A_1.lCcFvTtCrTkLZPGufgHVgPBpmeWk == this.lCcFvTtCrTkLZPGufgHVgPBpmeWk)
			{
				return 2;
			}
			if (A_1.oCHvYlBEczYmxKysfztclnHBYpoc == this.oCHvYlBEczYmxKysfztclnHBYpoc)
			{
				return 1;
			}
			return 0;
		}

		// Token: 0x060005F9 RID: 1529 RVA: 0x00033AA8 File Offset: 0x00031CA8
		private BridgedControllerHWInfo KQxuNWZaxYFrvuctcgBPAtkBvVkgA()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			this.OilgttGEVgfMMyMPBDhfWrwlWMiFA(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		// Token: 0x060005FA RID: 1530 RVA: 0x00033AC4 File Offset: 0x00031CC4
		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			this.tXZUbpBZwPsaPLXIFzWPknYpykL(bridgedController);
			return bridgedController;
		}

		// Token: 0x060005FB RID: 1531 RVA: 0x00014187 File Offset: 0x00012387
		[CustomObfuscation(rename = false)]
		public ControllerDisconnectedEventArgs ToControllerDisconnectedEventArgs()
		{
			return new ControllerDisconnectedEventArgs(this.xmJTMqbwVVJWavgHKmwjQcBZzEgy);
		}

		// Token: 0x060005FC RID: 1532 RVA: 0x00033AE0 File Offset: 0x00031CE0
		private void RSlFAicNCftGkfCTeKtostVwPRYN()
		{
			if (this.ayCBXZlNExwrYiNhafxSiBfLNoPmA <= 0)
			{
				return;
			}
			HardwareJoystickMap.Platform_WindowsWGI_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_WindowsWGI_Base)this.NIKWSBIJxhFWxpkAkKQphefrDFwh.map).Axes_orig;
			if (axes_orig == null)
			{
				return;
			}
			for (int i = 0; i < axes_orig.Length; i++)
			{
				this.ZUkcWYzxZHUOKgPcsLzXVPYlyUzi(axes_orig[i], i);
			}
		}

		// Token: 0x060005FD RID: 1533 RVA: 0x00033B2C File Offset: 0x00031D2C
		private void XebKGGBJOKoCpEDgwLERkCRfuyeD()
		{
			if (this.CRvgnvzYYscLVeVniHvDZLbTufNW <= 0)
			{
				return;
			}
			HardwareJoystickMap.Platform_WindowsWGI_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_WindowsWGI_Base)this.NIKWSBIJxhFWxpkAkKQphefrDFwh.map).Buttons_orig;
			if (buttons_orig == null)
			{
				return;
			}
			for (int i = 0; i < buttons_orig.Length; i++)
			{
				this.AhFwTSYSznISarupkLCSShTDAdXU(buttons_orig[i], i);
			}
		}

		// Token: 0x060005FE RID: 1534 RVA: 0x00033B78 File Offset: 0x00031D78
		private void ZUkcWYzxZHUOKgPcsLzXVPYlyUzi(HardwareJoystickMap.Platform_WindowsWGI_Base.Axis A_1, int A_2)
		{
			if (A_2 >= this.ayCBXZlNExwrYiNhafxSiBfLNoPmA)
			{
				throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
			}
			this.mYxJWgqClItyHBgKwcjKKWqLzFvi[A_2] = this.ENScHDbARifJTnYPXZApAhsPVhBN(A_1);
			if (!this.KKJBqVWMigksNbEwFAQbsUnGVkEr && this.mYxJWgqClItyHBgKwcjKKWqLzFvi[A_2] != 0f)
			{
				this.KKJBqVWMigksNbEwFAQbsUnGVkEr = true;
			}
		}

		// Token: 0x060005FF RID: 1535 RVA: 0x00033BC8 File Offset: 0x00031DC8
		private void AhFwTSYSznISarupkLCSShTDAdXU(HardwareJoystickMap.Platform_WindowsWGI_Base.Button A_1, int A_2)
		{
			if (A_2 >= this.CRvgnvzYYscLVeVniHvDZLbTufNW)
			{
				throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
			}
			this.sJNXkbJJdkesRrkpkScfxGxXeDzz[A_2] = this.KBAwHzYaFSgPeIVAPCsHTEDwePnbb(A_1);
			if (!this.KKJBqVWMigksNbEwFAQbsUnGVkEr && this.sJNXkbJJdkesRrkpkScfxGxXeDzz[A_2] != 0f)
			{
				this.KKJBqVWMigksNbEwFAQbsUnGVkEr = true;
			}
		}

		// Token: 0x06000600 RID: 1536 RVA: 0x00033C18 File Offset: 0x00031E18
		private float ENScHDbARifJTnYPXZApAhsPVhBN(HardwareJoystickMap.Platform_WindowsWGI_Base.Axis A_1)
		{
			if (A_1.sourceType == 1)
			{
				int sourceAxis = A_1.sourceAxis;
				if (sourceAxis < 0)
				{
					return 0f;
				}
				return this.poAhUkfbifKywHOFYOcHbVPbWDXZB(sourceAxis);
			}
			else if (A_1.sourceType == 0)
			{
				int sourceButton = A_1.sourceButton;
				if (sourceButton < 0 || sourceButton >= this.DTGJJDrKPnekpUZHMLLJUnmxFMHiA || sourceButton >= 256)
				{
					return 0f;
				}
				if (!this.jxGyiZparsCrgEvVAnMkAqappWZhA.CTIExOeTaAMFNjLQYBrZJQHXbGDl(sourceButton))
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
				if (sourceHat < 0 || sourceHat >= this.qgAeukdHfHLkchAkdLkUvoBExeirb || sourceHat >= 4)
				{
					return 0f;
				}
				int num = this.jxGyiZparsCrgEvVAnMkAqappWZhA.RUxsSTDBMWExNRTYcXeVOnEygnCL(sourceHat);
				if (num < 0)
				{
					return 0f;
				}
				float num2;
				if (A_1.sourceHatDirection == AxisDirection.Horizontal)
				{
					num2 = this.IpBfqRjAqJtFNiFbbPpTeyVNZlVwA(num, AxisDirection.Horizontal);
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
					num2 = this.IpBfqRjAqJtFNiFbbPpTeyVNZlVwA(num, AxisDirection.Vertical);
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

		// Token: 0x06000601 RID: 1537 RVA: 0x00014194 File Offset: 0x00012394
		private float poAhUkfbifKywHOFYOcHbVPbWDXZB(int A_1)
		{
			if (A_1 < 0 || A_1 >= this.jxGyiZparsCrgEvVAnMkAqappWZhA.JTikleOeSlGOoElynpFUVDzqpgfLA)
			{
				return 0f;
			}
			return this.jxGyiZparsCrgEvVAnMkAqappWZhA.mzpDBuvtGERpCYxolscyIsxeuLIj(A_1);
		}

		// Token: 0x06000602 RID: 1538 RVA: 0x00033D78 File Offset: 0x00031F78
		private float KBAwHzYaFSgPeIVAPCsHTEDwePnbb(HardwareJoystickMap.Platform_WindowsWGI_Base.Button A_1)
		{
			if (A_1.sourceType == 0)
			{
				if (A_1.ignoreIfButtonsActive)
				{
					for (int i = 0; i < A_1.ignoreIfButtonsActiveButtons.Length; i++)
					{
						if (this.jxGyiZparsCrgEvVAnMkAqappWZhA.CTIExOeTaAMFNjLQYBrZJQHXbGDl(A_1.ignoreIfButtonsActiveButtons[i]))
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
						if (!this.jxGyiZparsCrgEvVAnMkAqappWZhA.CTIExOeTaAMFNjLQYBrZJQHXbGDl(A_1.requiredButtons[j]))
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
					if (sourceButton < 0 || sourceButton >= this.DTGJJDrKPnekpUZHMLLJUnmxFMHiA || sourceButton >= 256)
					{
						return 0f;
					}
					if (!this.jxGyiZparsCrgEvVAnMkAqappWZhA.CTIExOeTaAMFNjLQYBrZJQHXbGDl(sourceButton))
					{
						return 0f;
					}
					return 1f;
				}
			}
			else
			{
				if (A_1.sourceType != 1)
				{
					if (A_1.sourceType == 2)
					{
						int sourceHat = A_1.sourceHat;
						if (sourceHat < 0 || sourceHat >= this.qgAeukdHfHLkchAkdLkUvoBExeirb || sourceHat >= 4)
						{
							return 0f;
						}
						switch (A_1.sourceHatDirection)
						{
						case HatDirection.Up:
							return this.sBonYparlHgGbOXqIoSLYtRHfXJA(this.jxGyiZparsCrgEvVAnMkAqappWZhA.RUxsSTDBMWExNRTYcXeVOnEygnCL(sourceHat), 0, A_1.sourceHatType);
						case HatDirection.Right:
							return this.sBonYparlHgGbOXqIoSLYtRHfXJA(this.jxGyiZparsCrgEvVAnMkAqappWZhA.RUxsSTDBMWExNRTYcXeVOnEygnCL(sourceHat), 2, A_1.sourceHatType);
						case HatDirection.Down:
							return this.sBonYparlHgGbOXqIoSLYtRHfXJA(this.jxGyiZparsCrgEvVAnMkAqappWZhA.RUxsSTDBMWExNRTYcXeVOnEygnCL(sourceHat), 4, A_1.sourceHatType);
						case HatDirection.Left:
							return this.sBonYparlHgGbOXqIoSLYtRHfXJA(this.jxGyiZparsCrgEvVAnMkAqappWZhA.RUxsSTDBMWExNRTYcXeVOnEygnCL(sourceHat), 6, A_1.sourceHatType);
						case HatDirection.UpRight:
							return this.sBonYparlHgGbOXqIoSLYtRHfXJA(this.jxGyiZparsCrgEvVAnMkAqappWZhA.RUxsSTDBMWExNRTYcXeVOnEygnCL(sourceHat), 1, A_1.sourceHatType);
						case HatDirection.DownRight:
							return this.sBonYparlHgGbOXqIoSLYtRHfXJA(this.jxGyiZparsCrgEvVAnMkAqappWZhA.RUxsSTDBMWExNRTYcXeVOnEygnCL(sourceHat), 3, A_1.sourceHatType);
						case HatDirection.DownLeft:
							return this.sBonYparlHgGbOXqIoSLYtRHfXJA(this.jxGyiZparsCrgEvVAnMkAqappWZhA.RUxsSTDBMWExNRTYcXeVOnEygnCL(sourceHat), 5, A_1.sourceHatType);
						case HatDirection.UpLeft:
							return this.sBonYparlHgGbOXqIoSLYtRHfXJA(this.jxGyiZparsCrgEvVAnMkAqappWZhA.RUxsSTDBMWExNRTYcXeVOnEygnCL(sourceHat), 7, A_1.sourceHatType);
						}
					}
					return 0f;
				}
				int sourceAxis = A_1.sourceAxis;
				if (sourceAxis < 0)
				{
					return 0f;
				}
				float num = this.poAhUkfbifKywHOFYOcHbVPbWDXZB(sourceAxis);
				float num2 = MathTools.Abs(num);
				if (num2 <= A_1.axisDeadZone)
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
				return num2;
			}
		}

		// Token: 0x06000603 RID: 1539 RVA: 0x00033FF4 File Offset: 0x000321F4
		private float sBonYparlHgGbOXqIoSLYtRHfXJA(int A_1, int A_2, HatType A_3)
		{
			if (A_1 < 0)
			{
				return 0f;
			}
			if (this.NIKWSBIJxhFWxpkAkKQphefrDFwh.isUnknownController && !InputTools.HandleForced4WayHatsOnUnknownControllers(A_2, ref A_3))
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

		// Token: 0x06000604 RID: 1540 RVA: 0x000211DC File Offset: 0x0001F3DC
		private float IpBfqRjAqJtFNiFbbPpTeyVNZlVwA(int A_1, AxisDirection A_2)
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

		// Token: 0x06000605 RID: 1541 RVA: 0x00034084 File Offset: 0x00032284
		private void tVINJWhsloFwxwJtEBGcxtyxDPrK()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = this.KQxuNWZaxYFrvuctcgBPAtkBvVkgA();
			this.NIKWSBIJxhFWxpkAkKQphefrDFwh = this.ciEPBxjBqLYSnYMETIlhaGCvVkYIA(bridgedControllerHWInfo);
			bool flag = false;
			bool flag2 = false;
			if (this.NIKWSBIJxhFWxpkAkKQphefrDFwh == null || this.NIKWSBIJxhFWxpkAkKQphefrDFwh.hardwareMapIdentifier.guid == Consts.joystickGuid_unknownController)
			{
				if (this.jxGyiZparsCrgEvVAnMkAqappWZhA.EUyqCwHoAkxaWCtXJVidqHgtaQyW)
				{
					bridgedControllerHWInfo.hw_pidVid = new PidVid(4607, 10462);
					bridgedControllerHWInfo.hw_productId = (int)bridgedControllerHWInfo.hw_pidVid.productId;
					bridgedControllerHWInfo.hw_vendorId = (int)bridgedControllerHWInfo.hw_pidVid.vendorId;
					this.NIKWSBIJxhFWxpkAkKQphefrDFwh = this.ciEPBxjBqLYSnYMETIlhaGCvVkYIA(bridgedControllerHWInfo);
					flag2 = true;
				}
				if (this.NIKWSBIJxhFWxpkAkKQphefrDFwh == null || this.NIKWSBIJxhFWxpkAkKQphefrDFwh.hardwareMapIdentifier.guid == Consts.joystickGuid_unknownController)
				{
					bridgedControllerHWInfo.hw_pidVid = new PidVid(736, 1118);
					bridgedControllerHWInfo.hw_productId = (int)bridgedControllerHWInfo.hw_pidVid.productId;
					bridgedControllerHWInfo.hw_vendorId = (int)bridgedControllerHWInfo.hw_pidVid.vendorId;
					bridgedControllerHWInfo.definitionMatchTag = string.Empty;
					this.NIKWSBIJxhFWxpkAkKQphefrDFwh = this.ciEPBxjBqLYSnYMETIlhaGCvVkYIA(bridgedControllerHWInfo);
					flag = true;
				}
			}
			if (this.NIKWSBIJxhFWxpkAkKQphefrDFwh == null)
			{
				Logger.LogError("Default hardware map not found!");
				return;
			}
			if (flag)
			{
				string format = "{0}:{1}";
				PidVid pidVid = this.jxGyiZparsCrgEvVAnMkAqappWZhA.xYPClePOxdcHpMsZUAOYEwYaLEYUA;
				object arg = pidVid.vendorId.ToString("x4");
				pidVid = this.jxGyiZparsCrgEvVAnMkAqappWZhA.xYPClePOxdcHpMsZUAOYEwYaLEYUA;
				string text = string.Format(format, arg, pidVid.productId.ToString("x4"));
				string key = LocalizationManager.AppendToKeyAsPath("windows_gaming_input_gamepad", text);
				this.NIKWSBIJxhFWxpkAkKQphefrDFwh.deviceLocalizationInfo.InsertParentKey(0, key);
				this.NIKWSBIJxhFWxpkAkKQphefrDFwh.deviceLocalizationInfo.InsertParentKey(1, "windows_gaming_input_gamepad");
				this.NIKWSBIJxhFWxpkAkKQphefrDFwh.deviceLocalizationInfo.additionalIdentifyingInformation = string.Format("[{0}]", text);
			}
			else if (this.jxGyiZparsCrgEvVAnMkAqappWZhA.EUyqCwHoAkxaWCtXJVidqHgtaQyW && (flag2 || this.NIKWSBIJxhFWxpkAkKQphefrDFwh.hardwareMapIdentifier.guid == Consts.joystickGuid_steamController))
			{
				string format2 = "{0}:{1}";
				PidVid pidVid = this.jxGyiZparsCrgEvVAnMkAqappWZhA.xYPClePOxdcHpMsZUAOYEwYaLEYUA;
				object arg2 = pidVid.vendorId.ToString("x4");
				pidVid = this.jxGyiZparsCrgEvVAnMkAqappWZhA.xYPClePOxdcHpMsZUAOYEwYaLEYUA;
				string text2 = string.Format(format2, arg2, pidVid.productId.ToString("x4"));
				string key2 = LocalizationManager.AppendToKeyAsPath((this.NIKWSBIJxhFWxpkAkKQphefrDFwh.deviceLocalizationInfo.parentKeys.Count > 0 && !string.IsNullOrEmpty(this.NIKWSBIJxhFWxpkAkKQphefrDFwh.deviceLocalizationInfo.parentKeys[0])) ? this.NIKWSBIJxhFWxpkAkKQphefrDFwh.deviceLocalizationInfo.parentKeys[0] : "steam_controller", text2);
				this.NIKWSBIJxhFWxpkAkKQphefrDFwh.deviceLocalizationInfo.InsertParentKey(0, key2);
				this.NIKWSBIJxhFWxpkAkKQphefrDFwh.deviceLocalizationInfo.additionalIdentifyingInformation = string.Format("[{0}]", text2);
			}
			this.ayCBXZlNExwrYiNhafxSiBfLNoPmA = this.NIKWSBIJxhFWxpkAkKQphefrDFwh.axisCount;
			this.CRvgnvzYYscLVeVniHvDZLbTufNW = this.NIKWSBIJxhFWxpkAkKQphefrDFwh.buttonCount;
		}

		// Token: 0x06000606 RID: 1542 RVA: 0x00034384 File Offset: 0x00032584
		private string zKkZmMqmsBHFAKQSJelHkncNMPzWA()
		{
			return InputTools.FormatHardwareIdentifierString(string.Format("{0}{1}{2}{3}{4}", new object[]
			{
				ReInput.currentPlatform.ToString(),
				InputSource.WindowsGamingInput,
				this.jxGyiZparsCrgEvVAnMkAqappWZhA.TSMfrUQJevmaGAlSJIgaOuzacxLE,
				this.SjFvLyzDKNjSIinJDKKABtJvpqLY,
				this.OGAVjbiZVtDsiykrejYcEcuhAxog.ToString()
			}));
		}

		// Token: 0x06000607 RID: 1543 RVA: 0x000343F8 File Offset: 0x000325F8
		private void OilgttGEVgfMMyMPBDhfWrwlWMiFA(BridgedControllerHWInfo A_1)
		{
			A_1.inputManagerSource = InputSource.WindowsGamingInput;
			A_1.inputSource = this.jxGyiZparsCrgEvVAnMkAqappWZhA.jrFvjbhhatDowbVakbuzQAagfLkSA;
			A_1.deviceType = (ControlDeviceType)this.jxGyiZparsCrgEvVAnMkAqappWZhA.TSMfrUQJevmaGAlSJIgaOuzacxLE;
			A_1.hardwareIdentifier = this.zKkZmMqmsBHFAKQSJelHkncNMPzWA();
			A_1.hardwareAxisCount = this.vFyRIZZkqWhkSjMPogGJhhipvIrV;
			A_1.hardwareButtonCount = this.DTGJJDrKPnekpUZHMLLJUnmxFMHiA;
			A_1.hardwareHatCount = this.qgAeukdHfHLkchAkdLkUvoBExeirb;
			if (this.jxGyiZparsCrgEvVAnMkAqappWZhA.EUyqCwHoAkxaWCtXJVidqHgtaQyW)
			{
				A_1.definitionMatchTag = "[STEAMCONFIGURED]";
			}
			A_1.hw_productName = this.SjFvLyzDKNjSIinJDKKABtJvpqLY;
			A_1.hw_deviceGuid = this.lCcFvTtCrTkLZPGufgHVgPBpmeWk;
			A_1.hw_productId = (int)this.OGAVjbiZVtDsiykrejYcEcuhAxog.productId;
			A_1.hw_vendorId = (int)this.OGAVjbiZVtDsiykrejYcEcuhAxog.vendorId;
			A_1.hw_pidVid = this.OGAVjbiZVtDsiykrejYcEcuhAxog;
			A_1.hw_isBluetoothDevice = false;
			A_1.hw_bluetoothDeviceName = this.SjFvLyzDKNjSIinJDKKABtJvpqLY;
			A_1.hw_supportsVibration = this.uzOmYyxYymAlDdNSpDLmGJwSbsxZA;
			A_1.hw_localVibrationMotorCount = this.xdXcoUsbRvAinkUgySjoOVyTWAsJA;
		}

		// Token: 0x06000608 RID: 1544 RVA: 0x000344E8 File Offset: 0x000326E8
		private void tXZUbpBZwPsaPLXIFzWPknYpykL(BridgedController A_1)
		{
			this.OilgttGEVgfMMyMPBDhfWrwlWMiFA(A_1);
			A_1.sourceJoystick = this;
			A_1.gameHardwareMap = this.NIKWSBIJxhFWxpkAkKQphefrDFwh.ToGameHardwareControllerMap();
			A_1.instanceName = this.pmepseeoKJjtHcIAwcqMiXeBgVJK;
			A_1.productName = this.SjFvLyzDKNjSIinJDKKABtJvpqLY;
			A_1.axisCount = this.ayCBXZlNExwrYiNhafxSiBfLNoPmA;
			A_1.buttonCount = this.CRvgnvzYYscLVeVniHvDZLbTufNW;
			A_1.isButtonPressureSensitive = new bool[this.CRvgnvzYYscLVeVniHvDZLbTufNW];
			Array.Copy(this.LtqSkmamPWpaxkRYSOYBhWZdHBon, A_1.isButtonPressureSensitive, this.CRvgnvzYYscLVeVniHvDZLbTufNW);
			A_1.unknownControllerHats = this.IOSoBzTeZUBrlyCmtrMRqEycnZtV();
			A_1.controllerTypeGuid = this.zjkKVtqnwgAqaWXfjhaJCCUBsRed;
			A_1.controllerExtension = this.extension;
		}

		// Token: 0x06000609 RID: 1545 RVA: 0x00034590 File Offset: 0x00032790
		private void rejbKfTDCQlxMPdqdihqokybdMHp()
		{
			for (int i = 0; i < this.CRvgnvzYYscLVeVniHvDZLbTufNW; i++)
			{
				this.sJNXkbJJdkesRrkpkScfxGxXeDzz[i] = 0f;
			}
			for (int j = 0; j < this.ayCBXZlNExwrYiNhafxSiBfLNoPmA; j++)
			{
				this.mYxJWgqClItyHBgKwcjKKWqLzFvi[j] = 0f;
			}
		}

		// Token: 0x0600060A RID: 1546 RVA: 0x000345DC File Offset: 0x000327DC
		private UnknownControllerHat[] IOSoBzTeZUBrlyCmtrMRqEycnZtV()
		{
			if (!this.cbsFjQHLjAwDVuKARNueODoeyuti)
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

		// Token: 0x0600060B RID: 1547 RVA: 0x000141BA File Offset: 0x000123BA
		public void Dispose()
		{
			this.nZdWlZebBQzOLGGGsZKwgvaKuTpT(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x0600060C RID: 1548 RVA: 0x00034654 File Offset: 0x00032854
		protected virtual void mbtOiezViexCAFihhwuOOfVQLTTP()
		{
			try
			{
				this.nZdWlZebBQzOLGGGsZKwgvaKuTpT(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		// Token: 0x0600060D RID: 1549 RVA: 0x000141C9 File Offset: 0x000123C9
		protected virtual void nZdWlZebBQzOLGGGsZKwgvaKuTpT(bool A_1)
		{
			if (this.qvXcHZIlPxFDxeNFHewYRNOEsaCf)
			{
				return;
			}
			if (A_1 && this.jxGyiZparsCrgEvVAnMkAqappWZhA != null)
			{
				this.jxGyiZparsCrgEvVAnMkAqappWZhA.Dispose();
			}
			this.qvXcHZIlPxFDxeNFHewYRNOEsaCf = true;
		}

		// Token: 0x0600060E RID: 1550 RVA: 0x000141F1 File Offset: 0x000123F1
		public static int TjmJVuENZRkyRwLbEGjSZJbgMMVI(PtyzRgDbfAwsKrNQvzaTCdKrMDEL.rLLEpWNIdAmUAAQjsRqpLbKUfjzs A_0, PtyzRgDbfAwsKrNQvzaTCdKrMDEL.rLLEpWNIdAmUAAQjsRqpLbKUfjzs A_1)
		{
			if (A_0.hnJxyTpAbDjwOVQnPAEMaTsFDjEFA < A_1.hnJxyTpAbDjwOVQnPAEMaTsFDjEFA)
			{
				return -1;
			}
			if (A_0.hnJxyTpAbDjwOVQnPAEMaTsFDjEFA > A_1.hnJxyTpAbDjwOVQnPAEMaTsFDjEFA)
			{
				return 1;
			}
			return 0;
		}

		// Token: 0x0600060F RID: 1551 RVA: 0x00014214 File Offset: 0x00012414
		public static int mWfDPpxkopCcwECdPBJzyVMfaOTq(PtyzRgDbfAwsKrNQvzaTCdKrMDEL.rLLEpWNIdAmUAAQjsRqpLbKUfjzs A_0, PtyzRgDbfAwsKrNQvzaTCdKrMDEL.rLLEpWNIdAmUAAQjsRqpLbKUfjzs A_1)
		{
			if (A_0.emCMAyxgnWOVMqwbFIQoWHfhcwUp < A_1.emCMAyxgnWOVMqwbFIQoWHfhcwUp)
			{
				return -1;
			}
			if (A_0.emCMAyxgnWOVMqwbFIQoWHfhcwUp > A_1.emCMAyxgnWOVMqwbFIQoWHfhcwUp)
			{
				return 1;
			}
			return 0;
		}

		// Token: 0x04000653 RID: 1619
		private int xmJTMqbwVVJWavgHKmwjQcBZzEgy;

		// Token: 0x04000654 RID: 1620
		private int hnJxyTpAbDjwOVQnPAEMaTsFDjEFA;

		// Token: 0x04000655 RID: 1621
		public Guid zjkKVtqnwgAqaWXfjhaJCCUBsRed;

		// Token: 0x04000656 RID: 1622
		public string wlBZTytcfTwCpHkcxYlEnZmFdZaE;

		// Token: 0x04000657 RID: 1623
		public cWYIDMjUnhAyDysKZVfQnpWFBosr jxGyiZparsCrgEvVAnMkAqappWZhA;

		// Token: 0x04000658 RID: 1624
		public string pmepseeoKJjtHcIAwcqMiXeBgVJK;

		// Token: 0x04000659 RID: 1625
		public string SjFvLyzDKNjSIinJDKKABtJvpqLY;

		// Token: 0x0400065A RID: 1626
		public Guid lCcFvTtCrTkLZPGufgHVgPBpmeWk;

		// Token: 0x0400065B RID: 1627
		public PidVid OGAVjbiZVtDsiykrejYcEcuhAxog;

		// Token: 0x0400065C RID: 1628
		public Guid oCHvYlBEczYmxKysfztclnHBYpoc;

		// Token: 0x0400065D RID: 1629
		public int emCMAyxgnWOVMqwbFIQoWHfhcwUp;

		// Token: 0x0400065E RID: 1630
		public int ayCBXZlNExwrYiNhafxSiBfLNoPmA;

		// Token: 0x0400065F RID: 1631
		public int CRvgnvzYYscLVeVniHvDZLbTufNW;

		// Token: 0x04000660 RID: 1632
		public int vFyRIZZkqWhkSjMPogGJhhipvIrV;

		// Token: 0x04000661 RID: 1633
		public int DTGJJDrKPnekpUZHMLLJUnmxFMHiA;

		// Token: 0x04000662 RID: 1634
		public int qgAeukdHfHLkchAkdLkUvoBExeirb;

		// Token: 0x04000663 RID: 1635
		public bool uzOmYyxYymAlDdNSpDLmGJwSbsxZA;

		// Token: 0x04000664 RID: 1636
		public int xdXcoUsbRvAinkUgySjoOVyTWAsJA;

		// Token: 0x04000665 RID: 1637
		private float[] mYxJWgqClItyHBgKwcjKKWqLzFvi;

		// Token: 0x04000666 RID: 1638
		private float[] sJNXkbJJdkesRrkpkScfxGxXeDzz;

		// Token: 0x04000667 RID: 1639
		private bool[] LtqSkmamPWpaxkRYSOYBhWZdHBon;

		// Token: 0x04000668 RID: 1640
		private HardwareJoystickMap_InputManager NIKWSBIJxhFWxpkAkKQphefrDFwh;

		// Token: 0x04000669 RID: 1641
		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> ciEPBxjBqLYSnYMETIlhaGCvVkYIA;

		// Token: 0x0400066A RID: 1642
		private bool cbsFjQHLjAwDVuKARNueODoeyuti;

		// Token: 0x0400066B RID: 1643
		private bool KKJBqVWMigksNbEwFAQbsUnGVkEr;

		// Token: 0x0400066C RID: 1644
		[CompilerGenerated]
		private Controller.Extension sKbCHGRZQsuxzadWIWzsbVpvQSqW;

		// Token: 0x0400066D RID: 1645
		private bool qvXcHZIlPxFDxeNFHewYRNOEsaCf;
	}

	// Token: 0x020000A7 RID: 167
	private class VzjtmVDcvZNZeRXuDWtoLaYtdEyf
	{
		// Token: 0x06000610 RID: 1552 RVA: 0x00014237 File Offset: 0x00012437
		public VzjtmVDcvZNZeRXuDWtoLaYtdEyf()
		{
			this.zwXMkHYGrQGNVawTGlKxOBrWRJQwA = new List<PtyzRgDbfAwsKrNQvzaTCdKrMDEL.VzjtmVDcvZNZeRXuDWtoLaYtdEyf.NPADjMSeAaYRGRnOuiZmXyslkyUd>();
		}

		// Token: 0x06000611 RID: 1553 RVA: 0x00034684 File Offset: 0x00032884
		public void UzVerTIqJjmPiNWUOPmlYOdJDJzd(PtyzRgDbfAwsKrNQvzaTCdKrMDEL.rLLEpWNIdAmUAAQjsRqpLbKUfjzs A_1)
		{
			if (A_1 == null)
			{
				return;
			}
			int count = this.zwXMkHYGrQGNVawTGlKxOBrWRJQwA.Count;
			for (int i = 0; i < count; i++)
			{
				if (this.zwXMkHYGrQGNVawTGlKxOBrWRJQwA[i].hptTQYYTTsnlrqaxMEjjWDNpgXq(A_1, PtyzRgDbfAwsKrNQvzaTCdKrMDEL.VzjtmVDcvZNZeRXuDWtoLaYtdEyf.ptylkjEigoIphfibXmIPaFxomLLhb.Exact))
				{
					this.zwXMkHYGrQGNVawTGlKxOBrWRJQwA[i].GvhibdsfSEyXkEHDkJKPTRPFPJOK = A_1.rewiredId;
					this.zwXMkHYGrQGNVawTGlKxOBrWRJQwA[i].HkifRZdemzoiXgZJbbjwBMybHBGJb = A_1.lCcFvTtCrTkLZPGufgHVgPBpmeWk;
					this.zwXMkHYGrQGNVawTGlKxOBrWRJQwA[i].lAyffADLTYBiXXonsYbZeEhjANAPA = A_1.oCHvYlBEczYmxKysfztclnHBYpoc;
					this.zwXMkHYGrQGNVawTGlKxOBrWRJQwA[i].IbNVFfEaJVDzzIMTCpFMdmqXZEvU = A_1.inputManagerId;
					this.zwXMkHYGrQGNVawTGlKxOBrWRJQwA[i].juGQeXhZiiFpgzwoDtBHTCqYwyE = A_1.vFyRIZZkqWhkSjMPogGJhhipvIrV;
					this.zwXMkHYGrQGNVawTGlKxOBrWRJQwA[i].PAiIqKjHHRpkurgVWUKLmKqbftkJA = A_1.DTGJJDrKPnekpUZHMLLJUnmxFMHiA;
					this.zwXMkHYGrQGNVawTGlKxOBrWRJQwA[i].ayFuUqAqFGNYvNONAwvRamrYZGho = A_1.qgAeukdHfHLkchAkdLkUvoBExeirb;
					this.zwXMkHYGrQGNVawTGlKxOBrWRJQwA[i].HVRCzhemsfQeCLCVJbihXJDcBMqnA = A_1.CRvgnvzYYscLVeVniHvDZLbTufNW;
					this.zwXMkHYGrQGNVawTGlKxOBrWRJQwA[i].NrJeLvhCuAaiWOcxKmxhZyiSLBWSA = A_1.ayCBXZlNExwrYiNhafxSiBfLNoPmA;
					this.hIxOyvoHrRTMoHfkAwInzaRvieLe(A_1.rewiredId, A_1.lCcFvTtCrTkLZPGufgHVgPBpmeWk, i);
					return;
				}
			}
			this.zwXMkHYGrQGNVawTGlKxOBrWRJQwA.Add(new PtyzRgDbfAwsKrNQvzaTCdKrMDEL.VzjtmVDcvZNZeRXuDWtoLaYtdEyf.NPADjMSeAaYRGRnOuiZmXyslkyUd
			{
				GvhibdsfSEyXkEHDkJKPTRPFPJOK = A_1.rewiredId,
				HkifRZdemzoiXgZJbbjwBMybHBGJb = A_1.lCcFvTtCrTkLZPGufgHVgPBpmeWk,
				lAyffADLTYBiXXonsYbZeEhjANAPA = A_1.oCHvYlBEczYmxKysfztclnHBYpoc,
				IbNVFfEaJVDzzIMTCpFMdmqXZEvU = A_1.inputManagerId,
				juGQeXhZiiFpgzwoDtBHTCqYwyE = A_1.vFyRIZZkqWhkSjMPogGJhhipvIrV,
				PAiIqKjHHRpkurgVWUKLmKqbftkJA = A_1.DTGJJDrKPnekpUZHMLLJUnmxFMHiA,
				ayFuUqAqFGNYvNONAwvRamrYZGho = A_1.qgAeukdHfHLkchAkdLkUvoBExeirb,
				HVRCzhemsfQeCLCVJbihXJDcBMqnA = A_1.CRvgnvzYYscLVeVniHvDZLbTufNW,
				NrJeLvhCuAaiWOcxKmxhZyiSLBWSA = A_1.ayCBXZlNExwrYiNhafxSiBfLNoPmA
			});
			this.hIxOyvoHrRTMoHfkAwInzaRvieLe(A_1.rewiredId, A_1.lCcFvTtCrTkLZPGufgHVgPBpmeWk, this.zwXMkHYGrQGNVawTGlKxOBrWRJQwA.Count - 1);
		}

		// Token: 0x06000612 RID: 1554 RVA: 0x0003484C File Offset: 0x00032A4C
		public bool HvFygSYgnYKEKSNrZKAAzVkJHJtG(PtyzRgDbfAwsKrNQvzaTCdKrMDEL.rLLEpWNIdAmUAAQjsRqpLbKUfjzs A_1, PtyzRgDbfAwsKrNQvzaTCdKrMDEL.VzjtmVDcvZNZeRXuDWtoLaYtdEyf.ptylkjEigoIphfibXmIPaFxomLLhb A_2)
		{
			int count = this.zwXMkHYGrQGNVawTGlKxOBrWRJQwA.Count;
			for (int i = 0; i < count; i++)
			{
				if (this.zwXMkHYGrQGNVawTGlKxOBrWRJQwA[i].hptTQYYTTsnlrqaxMEjjWDNpgXq(A_1, A_2))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000613 RID: 1555 RVA: 0x0001424A File Offset: 0x0001244A
		public IEnumerable<PtyzRgDbfAwsKrNQvzaTCdKrMDEL.VzjtmVDcvZNZeRXuDWtoLaYtdEyf.NPADjMSeAaYRGRnOuiZmXyslkyUd> FtvqFKxMmnaLrJFIoGXpKkIUHTYX(PtyzRgDbfAwsKrNQvzaTCdKrMDEL.rLLEpWNIdAmUAAQjsRqpLbKUfjzs A_1, PtyzRgDbfAwsKrNQvzaTCdKrMDEL.VzjtmVDcvZNZeRXuDWtoLaYtdEyf.ptylkjEigoIphfibXmIPaFxomLLhb A_2)
		{
			int count = this.zwXMkHYGrQGNVawTGlKxOBrWRJQwA.Count;
			int num;
			for (int i = 0; i < count; i = num + 1)
			{
				if (this.zwXMkHYGrQGNVawTGlKxOBrWRJQwA[i].hptTQYYTTsnlrqaxMEjjWDNpgXq(A_1, A_2))
				{
					yield return this.zwXMkHYGrQGNVawTGlKxOBrWRJQwA[i];
				}
				num = i;
			}
			yield break;
		}

		// Token: 0x06000614 RID: 1556 RVA: 0x0003488C File Offset: 0x00032A8C
		private void hIxOyvoHrRTMoHfkAwInzaRvieLe(int A_1, Guid A_2, int A_3)
		{
			for (int i = this.zwXMkHYGrQGNVawTGlKxOBrWRJQwA.Count - 1; i >= 0; i--)
			{
				if (i != A_3 && (this.zwXMkHYGrQGNVawTGlKxOBrWRJQwA[i].GvhibdsfSEyXkEHDkJKPTRPFPJOK == A_1 || this.zwXMkHYGrQGNVawTGlKxOBrWRJQwA[i].HkifRZdemzoiXgZJbbjwBMybHBGJb == A_2))
				{
					this.zwXMkHYGrQGNVawTGlKxOBrWRJQwA.RemoveAt(i);
				}
			}
		}

		// Token: 0x0400066E RID: 1646
		private List<PtyzRgDbfAwsKrNQvzaTCdKrMDEL.VzjtmVDcvZNZeRXuDWtoLaYtdEyf.NPADjMSeAaYRGRnOuiZmXyslkyUd> zwXMkHYGrQGNVawTGlKxOBrWRJQwA;

		// Token: 0x020000A8 RID: 168
		public enum ptylkjEigoIphfibXmIPaFxomLLhb
		{
			// Token: 0x04000670 RID: 1648
			Exact,
			// Token: 0x04000671 RID: 1649
			Approximate
		}

		// Token: 0x020000A9 RID: 169
		public class NPADjMSeAaYRGRnOuiZmXyslkyUd
		{
			// Token: 0x06000615 RID: 1557 RVA: 0x000348F0 File Offset: 0x00032AF0
			public bool hptTQYYTTsnlrqaxMEjjWDNpgXq(PtyzRgDbfAwsKrNQvzaTCdKrMDEL.rLLEpWNIdAmUAAQjsRqpLbKUfjzs A_1, PtyzRgDbfAwsKrNQvzaTCdKrMDEL.VzjtmVDcvZNZeRXuDWtoLaYtdEyf.ptylkjEigoIphfibXmIPaFxomLLhb A_2)
			{
				if (this.juGQeXhZiiFpgzwoDtBHTCqYwyE != A_1.vFyRIZZkqWhkSjMPogGJhhipvIrV)
				{
					return false;
				}
				if (this.PAiIqKjHHRpkurgVWUKLmKqbftkJA != A_1.DTGJJDrKPnekpUZHMLLJUnmxFMHiA)
				{
					return false;
				}
				if (this.ayFuUqAqFGNYvNONAwvRamrYZGho != A_1.qgAeukdHfHLkchAkdLkUvoBExeirb)
				{
					return false;
				}
				if (this.HVRCzhemsfQeCLCVJbihXJDcBMqnA != A_1.CRvgnvzYYscLVeVniHvDZLbTufNW)
				{
					return false;
				}
				if (this.NrJeLvhCuAaiWOcxKmxhZyiSLBWSA != A_1.ayCBXZlNExwrYiNhafxSiBfLNoPmA)
				{
					return false;
				}
				if (A_1.rewiredId == this.GvhibdsfSEyXkEHDkJKPTRPFPJOK)
				{
					return true;
				}
				if (A_2 == PtyzRgDbfAwsKrNQvzaTCdKrMDEL.VzjtmVDcvZNZeRXuDWtoLaYtdEyf.ptylkjEigoIphfibXmIPaFxomLLhb.Exact)
				{
					return this.HkifRZdemzoiXgZJbbjwBMybHBGJb == A_1.lCcFvTtCrTkLZPGufgHVgPBpmeWk;
				}
				if (A_2 == PtyzRgDbfAwsKrNQvzaTCdKrMDEL.VzjtmVDcvZNZeRXuDWtoLaYtdEyf.ptylkjEigoIphfibXmIPaFxomLLhb.Approximate)
				{
					return this.lAyffADLTYBiXXonsYbZeEhjANAPA == A_1.oCHvYlBEczYmxKysfztclnHBYpoc;
				}
				throw new NotImplementedException();
			}

			// Token: 0x04000672 RID: 1650
			public int GvhibdsfSEyXkEHDkJKPTRPFPJOK;

			// Token: 0x04000673 RID: 1651
			public Guid HkifRZdemzoiXgZJbbjwBMybHBGJb;

			// Token: 0x04000674 RID: 1652
			public Guid lAyffADLTYBiXXonsYbZeEhjANAPA;

			// Token: 0x04000675 RID: 1653
			public int IbNVFfEaJVDzzIMTCpFMdmqXZEvU;

			// Token: 0x04000676 RID: 1654
			public int juGQeXhZiiFpgzwoDtBHTCqYwyE;

			// Token: 0x04000677 RID: 1655
			public int PAiIqKjHHRpkurgVWUKLmKqbftkJA;

			// Token: 0x04000678 RID: 1656
			public int ayFuUqAqFGNYvNONAwvRamrYZGho;

			// Token: 0x04000679 RID: 1657
			public int HVRCzhemsfQeCLCVJbihXJDcBMqnA;

			// Token: 0x0400067A RID: 1658
			public int NrJeLvhCuAaiWOcxKmxhZyiSLBWSA;
		}
	}
}
