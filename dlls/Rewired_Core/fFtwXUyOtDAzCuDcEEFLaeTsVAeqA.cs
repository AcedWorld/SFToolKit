using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Rewired;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

// Token: 0x02000109 RID: 265
internal class fFtwXUyOtDAzCuDcEEFLaeTsVAeqA : PlatformInputManager
{
	// Token: 0x06000933 RID: 2355 RVA: 0x00043190 File Offset: 0x00041390
	public fFtwXUyOtDAzCuDcEEFLaeTsVAeqA(UpdateLoopSetting A_1)
	{
		this.PyuVqsYipEDkVehDBJYCRLRVfgxcA = this;
		this.ZSsbUmXAARxFkTjvwvPtCfJaEQvhA = new UnityUnifiedKeyboardSource();
		this.hodyjfUtdayKRWAKmkTpOPbYXaVK = new UnityUnifiedMouseSource();
		using (TempListPool.TList<UpdateLoopType> tlist = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tlist.list;
			EnumConverter.ToUpdateLoopTypes(A_1, list);
			int num = 0;
			if (num < list.Count)
			{
				this.MnHKfbqTcofjVNADhonESzmGgGtS = list[num];
			}
		}
		this.LzDbpgWBMJetpADGDGyCtMISoUJEb = new string[0];
		this.QhPdTzMvdWilNjPIBwAPfuatVgcs = new Action<int, ControllerDataUpdater>(this.UpdateControllerData);
	}

	// Token: 0x170002BC RID: 700
	// (get) Token: 0x06000934 RID: 2356 RVA: 0x00009AE0 File Offset: 0x00007CE0
	[CustomObfuscation(rename = false)]
	public override int deviceCount
	{
		get
		{
			return this.AvZOQwbiAhAkweMQwhFpEARMoiwLA;
		}
	}

	// Token: 0x170002BD RID: 701
	// (get) Token: 0x06000935 RID: 2357 RVA: 0x00009AE8 File Offset: 0x00007CE8
	[CustomObfuscation(rename = false)]
	public override PlatformInputManager primaryInputManager
	{
		get
		{
			return this.PyuVqsYipEDkVehDBJYCRLRVfgxcA;
		}
	}

	// Token: 0x170002BE RID: 702
	// (get) Token: 0x06000936 RID: 2358 RVA: 0x000067FE File Offset: 0x000049FE
	[CustomObfuscation(rename = false)]
	public override IInputSource inputSource
	{
		get
		{
			return null;
		}
	}

	// Token: 0x170002BF RID: 703
	// (get) Token: 0x06000937 RID: 2359 RVA: 0x000057C4 File Offset: 0x000039C4
	[CustomObfuscation(rename = false)]
	public override InputSource inputSourceType
	{
		get
		{
			return InputSource.Fallback;
		}
	}

	// Token: 0x06000938 RID: 2360 RVA: 0x00043230 File Offset: 0x00041430
	[CustomObfuscation(rename = false)]
	public override void Initialize()
	{
		if (UnityTools.isAndroidPlatform && UnityTools.lRGJvbHYYtwJWseuIXpNcoFOvLDL != null)
		{
			UnityTools.lRGJvbHYYtwJWseuIXpNcoFOvLDL.DeviceChangedEvent += this.cTTXNEaILaQNraQgmQyWbjaxShZF;
		}
		this.OGnaLHKgdKtlOYbqikxwuxPXOzWF = new TimerAbs(1.0);
		this.BSpeUparoocLBYVUohsukmZaNaSJ = new fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.rpNpYaCjKlVCOvvfPAnMzAQXjmSI();
		this.pgYqNOsxXTBiResLgnuUHYUPjRRx();
		this.iNaIpFfwPqGvmiSzhPdivIXPWFAN = true;
		this.OGnaLHKgdKtlOYbqikxwuxPXOzWF.Start();
	}

	// Token: 0x06000939 RID: 2361 RVA: 0x00009AF0 File Offset: 0x00007CF0
	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		this.YyhKwuQfLANoXlJTKvNvaWKJVAyJ = updateLoop;
		this.kTRbyyQLcCeDzBMSiOQqpZgrvdxkA();
		if (this.iNaIpFfwPqGvmiSzhPdivIXPWFAN)
		{
			this.prfGbQGNoIKDbCXbfCtDfwsYwYwR();
		}
		this.HbHhoZhwuJPchWWHMfjuyzUkBrKNA(updateLoop);
	}

	// Token: 0x0600093A RID: 2362 RVA: 0x00043298 File Offset: 0x00041498
	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (UnityTools.isAndroidPlatform && UnityTools.lRGJvbHYYtwJWseuIXpNcoFOvLDL != null)
		{
			UnityTools.lRGJvbHYYtwJWseuIXpNcoFOvLDL.DeviceChangedEvent -= this.cTTXNEaILaQNraQgmQyWbjaxShZF;
		}
		(this.ZSsbUmXAARxFkTjvwvPtCfJaEQvhA as IDisposable).Dispose();
		(this.hodyjfUtdayKRWAKmkTpOPbYXaVK as IDisposable).Dispose();
	}

	// Token: 0x0600093B RID: 2363 RVA: 0x00009B14 File Offset: 0x00007D14
	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return this.QhPdTzMvdWilNjPIBwAPfuatVgcs;
	}

	// Token: 0x0600093C RID: 2364 RVA: 0x000432EC File Offset: 0x000414EC
	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int assignedControllerId, ControllerDataUpdater data)
	{
		for (int i = 0; i < this.AvZOQwbiAhAkweMQwhFpEARMoiwLA; i++)
		{
			if (this.iNhQfrgRUiEXjjGriaVyvQnpOIWt[i].inputManagerId == assignedControllerId)
			{
				this.iNhQfrgRUiEXjjGriaVyvQnpOIWt[i].FillData(data);
				return;
			}
		}
		Logger.LogError("Invalid joystick Id " + assignedControllerId.ToString() + "!");
	}

	// Token: 0x0600093D RID: 2365 RVA: 0x00009B1C File Offset: 0x00007D1C
	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		this.iNaIpFfwPqGvmiSzhPdivIXPWFAN = true;
		if (this._SystemDeviceConnectedEvent != null)
		{
			this._SystemDeviceConnectedEvent();
		}
	}

	// Token: 0x0600093E RID: 2366 RVA: 0x00009B38 File Offset: 0x00007D38
	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		this.iNaIpFfwPqGvmiSzhPdivIXPWFAN = true;
		if (this._SystemDeviceDisconnectedEvent != null)
		{
			this._SystemDeviceDisconnectedEvent();
		}
	}

	// Token: 0x0600093F RID: 2367 RVA: 0x00009B54 File Offset: 0x00007D54
	private void cTTXNEaILaQNraQgmQyWbjaxShZF()
	{
		this.iNaIpFfwPqGvmiSzhPdivIXPWFAN = true;
		this.rxYyzgSSJbknjucvLIJGiTrNdope = true;
	}

	// Token: 0x06000940 RID: 2368 RVA: 0x0004334C File Offset: 0x0004154C
	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
		for (int i = 0; i < this.iNhQfrgRUiEXjjGriaVyvQnpOIWt.Count; i++)
		{
			if (this.iNhQfrgRUiEXjjGriaVyvQnpOIWt[i].unityId == unityJoystickId)
			{
				this.iNhQfrgRUiEXjjGriaVyvQnpOIWt[i].JlFkceTwbDnPDNYxDmDcBBEtYcPo();
			}
		}
		for (int j = 0; j < this.iNhQfrgRUiEXjjGriaVyvQnpOIWt.Count; j++)
		{
			if (this.iNhQfrgRUiEXjjGriaVyvQnpOIWt[j].rewiredId == joystickId)
			{
				this.iNhQfrgRUiEXjjGriaVyvQnpOIWt[j].NNOuMjyIivXmXHjgWESpefANKpXf(unityJoystickId);
				return;
			}
		}
	}

	// Token: 0x06000941 RID: 2369 RVA: 0x00009B64 File Offset: 0x00007D64
	[CustomObfuscation(rename = false)]
	public override IUnifiedMouseSource GetUnifiedMouseSource()
	{
		return this.hodyjfUtdayKRWAKmkTpOPbYXaVK;
	}

	// Token: 0x06000942 RID: 2370 RVA: 0x00009B6C File Offset: 0x00007D6C
	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		return this.ZSsbUmXAARxFkTjvwvPtCfJaEQvhA;
	}

	// Token: 0x06000943 RID: 2371 RVA: 0x00009B74 File Offset: 0x00007D74
	private void pgYqNOsxXTBiResLgnuUHYUPjRRx()
	{
		this.gNbQGZgIalgSyinHkRVfSKduEoXLA(Input.GetJoystickNames());
	}

	// Token: 0x06000944 RID: 2372 RVA: 0x000433D4 File Offset: 0x000415D4
	private void gNbQGZgIalgSyinHkRVfSKduEoXLA(string[] A_1)
	{
		int num = 0;
		List<fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.oVUyOLUvUEGkvZsIaWwEHqTEUPNh> list = this.iNhQfrgRUiEXjjGriaVyvQnpOIWt;
		int avZOQwbiAhAkweMQwhFpEARMoiwLA = this.AvZOQwbiAhAkweMQwhFpEARMoiwLA;
		this.iNhQfrgRUiEXjjGriaVyvQnpOIWt = new List<fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.oVUyOLUvUEGkvZsIaWwEHqTEUPNh>();
		for (int i = 0; i < A_1.Length; i++)
		{
			string text = StringTools.SanitizeDeviceString(A_1[i]);
			if (UnityTools.IsValidUnityJoystickName(text))
			{
				fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.oVUyOLUvUEGkvZsIaWwEHqTEUPNh oVUyOLUvUEGkvZsIaWwEHqTEUPNh = new fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.oVUyOLUvUEGkvZsIaWwEHqTEUPNh();
				oVUyOLUvUEGkvZsIaWwEHqTEUPNh.XGCDgTCPVxWwDfFjrWmblOLHFTcpA = text;
				oVUyOLUvUEGkvZsIaWwEHqTEUPNh.RuRPjumrSdIiQWvAxhLlwCJVQcps = text;
				oVUyOLUvUEGkvZsIaWwEHqTEUPNh.flUEPFupfmQaRTaHZWoKvobKcLTIA = i;
				oVUyOLUvUEGkvZsIaWwEHqTEUPNh.unityId = i + 1;
				if (UnityTools.isAndroidPlatform && UnityTools.lRGJvbHYYtwJWseuIXpNcoFOvLDL != null)
				{
					oVUyOLUvUEGkvZsIaWwEHqTEUPNh.ZUFYTzmpbcggAOuQbfFkwUHyHMJr = UnityTools.lRGJvbHYYtwJWseuIXpNcoFOvLDL.GetUniqueDeviceIdentifier(text, i);
				}
				oVUyOLUvUEGkvZsIaWwEHqTEUPNh.APLJuxngDnwgyFsFGqwnonFbObvF();
				this.iNhQfrgRUiEXjjGriaVyvQnpOIWt.Add(oVUyOLUvUEGkvZsIaWwEHqTEUPNh);
				num++;
			}
		}
		this.AvZOQwbiAhAkweMQwhFpEARMoiwLA = num;
		this.OBGZpsutAJEmaqfaZBeGofYkiQIX(avZOQwbiAhAkweMQwhFpEARMoiwLA, num, list, this.iNhQfrgRUiEXjjGriaVyvQnpOIWt);
		for (int j = 0; j < num; j++)
		{
			if (this._UpdateControllerInfoEvent != null)
			{
				this._UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(this.iNhQfrgRUiEXjjGriaVyvQnpOIWt[j]));
			}
		}
		this.BcFTRyjmHsxJYaimjiJnadnvlIiKA(list, this.iNhQfrgRUiEXjjGriaVyvQnpOIWt, false);
		this.BcFTRyjmHsxJYaimjiJnadnvlIiKA(this.iNhQfrgRUiEXjjGriaVyvQnpOIWt, list, true);
		this.LzDbpgWBMJetpADGDGyCtMISoUJEb = A_1;
	}

	// Token: 0x06000945 RID: 2373 RVA: 0x000434F4 File Offset: 0x000416F4
	private void HbHhoZhwuJPchWWHMfjuyzUkBrKNA(UpdateLoopType A_1)
	{
		int count = this.iNhQfrgRUiEXjjGriaVyvQnpOIWt.Count;
		for (int i = 0; i < count; i++)
		{
			if (this.iNhQfrgRUiEXjjGriaVyvQnpOIWt[i] != null)
			{
				this.iNhQfrgRUiEXjjGriaVyvQnpOIWt[i].Update();
			}
		}
	}

	// Token: 0x06000946 RID: 2374 RVA: 0x00043538 File Offset: 0x00041738
	private void OBGZpsutAJEmaqfaZBeGofYkiQIX(int A_1, int A_2, List<fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.oVUyOLUvUEGkvZsIaWwEHqTEUPNh> A_3, List<fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.oVUyOLUvUEGkvZsIaWwEHqTEUPNh> A_4)
	{
		if (A_2 > 0)
		{
			A_4.Sort(new Comparison<fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.oVUyOLUvUEGkvZsIaWwEHqTEUPNh>(fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.oVUyOLUvUEGkvZsIaWwEHqTEUPNh.zWicITQtCbIJlIuKdidrgFsUEjOyA));
		}
		if (A_1 > 0 && A_2 > 0)
		{
			this.JUvnYbGsnlOnEOdMlvGFSDVoxArj(A_2, A_4, A_1, A_3, fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.rpNpYaCjKlVCOvvfPAnMzAQXjmSI.YiuxBCZaqVLXpOLWvdpUivYUZoEA.Exact);
			this.JUvnYbGsnlOnEOdMlvGFSDVoxArj(A_2, A_4, A_1, A_3, fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.rpNpYaCjKlVCOvvfPAnMzAQXjmSI.YiuxBCZaqVLXpOLWvdpUivYUZoEA.Approximate);
		}
		this.rKDNbbaFSVIPxYPgscovtljliPfo(A_2, A_4, fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.rpNpYaCjKlVCOvvfPAnMzAQXjmSI.YiuxBCZaqVLXpOLWvdpUivYUZoEA.Exact);
		this.rKDNbbaFSVIPxYPgscovtljliPfo(A_2, A_4, fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.rpNpYaCjKlVCOvvfPAnMzAQXjmSI.YiuxBCZaqVLXpOLWvdpUivYUZoEA.Approximate);
		for (int i = 0; i < A_2; i++)
		{
			fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.oVUyOLUvUEGkvZsIaWwEHqTEUPNh oVUyOLUvUEGkvZsIaWwEHqTEUPNh = A_4[i];
			if (oVUyOLUvUEGkvZsIaWwEHqTEUPNh != null && oVUyOLUvUEGkvZsIaWwEHqTEUPNh.inputManagerId < 0)
			{
				oVUyOLUvUEGkvZsIaWwEHqTEUPNh.inputManagerId = this.fOnGMfiPmtapHxWaRXLQHFbVnBpzA(A_4);
				oVUyOLUvUEGkvZsIaWwEHqTEUPNh.rewiredId = ReInput.GetNewJoystickId();
				this.BSpeUparoocLBYVUohsukmZaNaSJ.DzODbtlLrzaxZAnztvdHkpfOWwEu(oVUyOLUvUEGkvZsIaWwEHqTEUPNh);
			}
		}
		A_4.Sort(new Comparison<fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.oVUyOLUvUEGkvZsIaWwEHqTEUPNh>(fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.oVUyOLUvUEGkvZsIaWwEHqTEUPNh.OMQawECRYRHtXIFnPqZLJUnjzCNIA));
	}

	// Token: 0x06000947 RID: 2375 RVA: 0x000435F0 File Offset: 0x000417F0
	private void vNfrXAFBBDDJjhotZYWjAGdbYlwj(List<fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.oVUyOLUvUEGkvZsIaWwEHqTEUPNh> A_1, int A_2, int A_3)
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

	// Token: 0x06000948 RID: 2376 RVA: 0x0004363C File Offset: 0x0004183C
	private bool frEGkjaiRUQgRPDqVNpJinlRmMjFA(List<fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.oVUyOLUvUEGkvZsIaWwEHqTEUPNh> A_1, int A_2)
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

	// Token: 0x06000949 RID: 2377 RVA: 0x00043678 File Offset: 0x00041878
	private int fOnGMfiPmtapHxWaRXLQHFbVnBpzA(List<fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.oVUyOLUvUEGkvZsIaWwEHqTEUPNh> A_1)
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

	// Token: 0x0600094A RID: 2378 RVA: 0x000436C4 File Offset: 0x000418C4
	private bool WfczMYoFrmXBSERQrRPowQdPwMpS(List<fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.oVUyOLUvUEGkvZsIaWwEHqTEUPNh> A_1, int A_2)
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

	// Token: 0x0600094B RID: 2379 RVA: 0x000436FC File Offset: 0x000418FC
	private void JUvnYbGsnlOnEOdMlvGFSDVoxArj(int A_1, List<fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.oVUyOLUvUEGkvZsIaWwEHqTEUPNh> A_2, int A_3, List<fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.oVUyOLUvUEGkvZsIaWwEHqTEUPNh> A_4, fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.rpNpYaCjKlVCOvvfPAnMzAQXjmSI.YiuxBCZaqVLXpOLWvdpUivYUZoEA A_5)
	{
		int num = (A_5 == fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.rpNpYaCjKlVCOvvfPAnMzAQXjmSI.YiuxBCZaqVLXpOLWvdpUivYUZoEA.Exact) ? 2 : 1;
		for (int i = 0; i < A_1; i++)
		{
			fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.oVUyOLUvUEGkvZsIaWwEHqTEUPNh oVUyOLUvUEGkvZsIaWwEHqTEUPNh = A_2[i];
			if (oVUyOLUvUEGkvZsIaWwEHqTEUPNh != null && oVUyOLUvUEGkvZsIaWwEHqTEUPNh.inputManagerId < 0)
			{
				for (int j = 0; j < A_3; j++)
				{
					fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.oVUyOLUvUEGkvZsIaWwEHqTEUPNh oVUyOLUvUEGkvZsIaWwEHqTEUPNh2 = A_4[j];
					if (oVUyOLUvUEGkvZsIaWwEHqTEUPNh2 != null && !this.WfczMYoFrmXBSERQrRPowQdPwMpS(A_2, oVUyOLUvUEGkvZsIaWwEHqTEUPNh2.rewiredId) && oVUyOLUvUEGkvZsIaWwEHqTEUPNh.PSXvmQWsbVkUbjwwIhQMksUBgIVU(oVUyOLUvUEGkvZsIaWwEHqTEUPNh2) >= num)
					{
						oVUyOLUvUEGkvZsIaWwEHqTEUPNh.inputManagerId = oVUyOLUvUEGkvZsIaWwEHqTEUPNh2.inputManagerId;
						oVUyOLUvUEGkvZsIaWwEHqTEUPNh.rewiredId = oVUyOLUvUEGkvZsIaWwEHqTEUPNh2.rewiredId;
						if (ReInput.isWindowsStandaloneWebplayerOrEditorPlatform && !UnityTools.windowsJoystickNamesReturnsEmptyStringsIfJoystickNull)
						{
							oVUyOLUvUEGkvZsIaWwEHqTEUPNh.unityId = oVUyOLUvUEGkvZsIaWwEHqTEUPNh2.unityId;
						}
						this.BSpeUparoocLBYVUohsukmZaNaSJ.DzODbtlLrzaxZAnztvdHkpfOWwEu(oVUyOLUvUEGkvZsIaWwEHqTEUPNh);
					}
				}
			}
		}
	}

	// Token: 0x0600094C RID: 2380 RVA: 0x000437B0 File Offset: 0x000419B0
	private void rKDNbbaFSVIPxYPgscovtljliPfo(int A_1, List<fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.oVUyOLUvUEGkvZsIaWwEHqTEUPNh> A_2, fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.rpNpYaCjKlVCOvvfPAnMzAQXjmSI.YiuxBCZaqVLXpOLWvdpUivYUZoEA A_3)
	{
		for (int i = 0; i < A_1; i++)
		{
			fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.oVUyOLUvUEGkvZsIaWwEHqTEUPNh oVUyOLUvUEGkvZsIaWwEHqTEUPNh = A_2[i];
			if (oVUyOLUvUEGkvZsIaWwEHqTEUPNh != null && oVUyOLUvUEGkvZsIaWwEHqTEUPNh.inputManagerId < 0)
			{
				fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.rpNpYaCjKlVCOvvfPAnMzAQXjmSI.IWSglNMsKKXCXIszFMVrWJKGqpOx iwsglNMsKKXCXIszFMVrWJKGqpOx = null;
				foreach (fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.rpNpYaCjKlVCOvvfPAnMzAQXjmSI.IWSglNMsKKXCXIszFMVrWJKGqpOx iwsglNMsKKXCXIszFMVrWJKGqpOx2 in this.BSpeUparoocLBYVUohsukmZaNaSJ.paieoXAyWrPtcGzOItpsdqOtVngO(oVUyOLUvUEGkvZsIaWwEHqTEUPNh, A_3))
				{
					if (!this.WfczMYoFrmXBSERQrRPowQdPwMpS(A_2, iwsglNMsKKXCXIszFMVrWJKGqpOx2.XcxSraXfSmQRFImnoeSHalROMYxFA) && iwsglNMsKKXCXIszFMVrWJKGqpOx2.gJFhsQdyboVOqqfnZrFFyjyGJcGT >= 0)
					{
						iwsglNMsKKXCXIszFMVrWJKGqpOx = iwsglNMsKKXCXIszFMVrWJKGqpOx2;
						break;
					}
				}
				if (iwsglNMsKKXCXIszFMVrWJKGqpOx != null)
				{
					int num = iwsglNMsKKXCXIszFMVrWJKGqpOx.gJFhsQdyboVOqqfnZrFFyjyGJcGT;
					if (!this.frEGkjaiRUQgRPDqVNpJinlRmMjFA(A_2, num))
					{
						num = this.fOnGMfiPmtapHxWaRXLQHFbVnBpzA(A_2);
						iwsglNMsKKXCXIszFMVrWJKGqpOx.gJFhsQdyboVOqqfnZrFFyjyGJcGT = num;
					}
					oVUyOLUvUEGkvZsIaWwEHqTEUPNh.inputManagerId = num;
					oVUyOLUvUEGkvZsIaWwEHqTEUPNh.rewiredId = iwsglNMsKKXCXIszFMVrWJKGqpOx.XcxSraXfSmQRFImnoeSHalROMYxFA;
					this.BSpeUparoocLBYVUohsukmZaNaSJ.DzODbtlLrzaxZAnztvdHkpfOWwEu(oVUyOLUvUEGkvZsIaWwEHqTEUPNh);
				}
			}
		}
	}

	// Token: 0x0600094D RID: 2381 RVA: 0x00043894 File Offset: 0x00041A94
	private void prfGbQGNoIKDbCXbfCtDfwsYwYwR()
	{
		string[] joystickNames = Input.GetJoystickNames();
		if (this.rxYyzgSSJbknjucvLIJGiTrNdope || this.BNjzFYqwxRVNvNcJtMzTkGKXarqg(joystickNames))
		{
			this.gNbQGZgIalgSyinHkRVfSKduEoXLA(joystickNames);
		}
		this.iNaIpFfwPqGvmiSzhPdivIXPWFAN = false;
		if (this.rxYyzgSSJbknjucvLIJGiTrNdope)
		{
			this.rxYyzgSSJbknjucvLIJGiTrNdope = false;
		}
	}

	// Token: 0x0600094E RID: 2382 RVA: 0x000438D8 File Offset: 0x00041AD8
	private bool BNjzFYqwxRVNvNcJtMzTkGKXarqg(string[] A_1)
	{
		if (A_1.Length != this.LzDbpgWBMJetpADGDGyCtMISoUJEb.Length)
		{
			return true;
		}
		for (int i = 0; i < A_1.Length; i++)
		{
			if (!string.Equals(A_1[i], this.LzDbpgWBMJetpADGDGyCtMISoUJEb[i], StringComparison.Ordinal))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600094F RID: 2383 RVA: 0x00043918 File Offset: 0x00041B18
	private void BcFTRyjmHsxJYaimjiJnadnvlIiKA(List<fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.oVUyOLUvUEGkvZsIaWwEHqTEUPNh> A_1, List<fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.oVUyOLUvUEGkvZsIaWwEHqTEUPNh> A_2, bool A_3)
	{
		if (A_1 == null)
		{
			return;
		}
		int num = (A_1 != null) ? A_1.Count : 0;
		int num2 = (A_2 != null) ? A_2.Count : 0;
		for (int i = 0; i < num; i++)
		{
			fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.oVUyOLUvUEGkvZsIaWwEHqTEUPNh oVUyOLUvUEGkvZsIaWwEHqTEUPNh = A_1[i];
			if (oVUyOLUvUEGkvZsIaWwEHqTEUPNh != null)
			{
				bool flag = false;
				if (A_2 != null)
				{
					for (int j = 0; j < num2; j++)
					{
						fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.oVUyOLUvUEGkvZsIaWwEHqTEUPNh oVUyOLUvUEGkvZsIaWwEHqTEUPNh2 = A_2[j];
						if (oVUyOLUvUEGkvZsIaWwEHqTEUPNh2 != null && oVUyOLUvUEGkvZsIaWwEHqTEUPNh.rewiredId == oVUyOLUvUEGkvZsIaWwEHqTEUPNh2.rewiredId)
						{
							flag = true;
							break;
						}
					}
				}
				if (!flag)
				{
					this.moVBtiwWGHxgPZqlcTZCixZwrqOv(A_1[i], A_3);
				}
			}
		}
	}

	// Token: 0x06000950 RID: 2384 RVA: 0x00009B81 File Offset: 0x00007D81
	private void moVBtiwWGHxgPZqlcTZCixZwrqOv(fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.oVUyOLUvUEGkvZsIaWwEHqTEUPNh A_1, bool A_2)
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

	// Token: 0x06000951 RID: 2385 RVA: 0x00009BB9 File Offset: 0x00007DB9
	private void kTRbyyQLcCeDzBMSiOQqpZgrvdxkA()
	{
		if (this.YyhKwuQfLANoXlJTKvNvaWKJVAyJ != this.MnHKfbqTcofjVNADhonESzmGgGtS)
		{
			return;
		}
		if (this.OGnaLHKgdKtlOYbqikxwuxPXOzWF.Update())
		{
			this.iNaIpFfwPqGvmiSzhPdivIXPWFAN = true;
			this.OGnaLHKgdKtlOYbqikxwuxPXOzWF.Start();
		}
	}

	// Token: 0x040006FD RID: 1789
	private List<fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.oVUyOLUvUEGkvZsIaWwEHqTEUPNh> iNhQfrgRUiEXjjGriaVyvQnpOIWt;

	// Token: 0x040006FE RID: 1790
	private int AvZOQwbiAhAkweMQwhFpEARMoiwLA;

	// Token: 0x040006FF RID: 1791
	private fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.rpNpYaCjKlVCOvvfPAnMzAQXjmSI BSpeUparoocLBYVUohsukmZaNaSJ;

	// Token: 0x04000700 RID: 1792
	private bool iNaIpFfwPqGvmiSzhPdivIXPWFAN;

	// Token: 0x04000701 RID: 1793
	private bool rxYyzgSSJbknjucvLIJGiTrNdope;

	// Token: 0x04000702 RID: 1794
	private UpdateLoopType YyhKwuQfLANoXlJTKvNvaWKJVAyJ;

	// Token: 0x04000703 RID: 1795
	private UpdateLoopType MnHKfbqTcofjVNADhonESzmGgGtS;

	// Token: 0x04000704 RID: 1796
	private TimerAbs OGnaLHKgdKtlOYbqikxwuxPXOzWF;

	// Token: 0x04000705 RID: 1797
	private Action<int, ControllerDataUpdater> QhPdTzMvdWilNjPIBwAPfuatVgcs;

	// Token: 0x04000706 RID: 1798
	private PlatformInputManager PyuVqsYipEDkVehDBJYCRLRVfgxcA;

	// Token: 0x04000707 RID: 1799
	private readonly IUnifiedKeyboardSource ZSsbUmXAARxFkTjvwvPtCfJaEQvhA;

	// Token: 0x04000708 RID: 1800
	private readonly IUnifiedMouseSource hodyjfUtdayKRWAKmkTpOPbYXaVK;

	// Token: 0x04000709 RID: 1801
	private bool SVqcpKeWRJLCQiGTaDncNDCjJfjVA;

	// Token: 0x0400070A RID: 1802
	private string[] LzDbpgWBMJetpADGDGyCtMISoUJEb;

	// Token: 0x0200010A RID: 266
	private class oVUyOLUvUEGkvZsIaWwEHqTEUPNh : IInputManagerJoystick, IInputManagerJoystickPublic
	{
		// Token: 0x170002C0 RID: 704
		// (get) Token: 0x06000952 RID: 2386 RVA: 0x00009BE9 File Offset: 0x00007DE9
		// (set) Token: 0x06000953 RID: 2387 RVA: 0x00009BF1 File Offset: 0x00007DF1
		[CustomObfuscation(rename = false)]
		public int rewiredId
		{
			get
			{
				return this.madcIuGhHpPqMzbHrvzjNkbXlPHlA;
			}
			set
			{
				this.madcIuGhHpPqMzbHrvzjNkbXlPHlA = value;
			}
		}

		// Token: 0x170002C1 RID: 705
		// (get) Token: 0x06000954 RID: 2388 RVA: 0x00009BFA File Offset: 0x00007DFA
		// (set) Token: 0x06000955 RID: 2389 RVA: 0x00009C02 File Offset: 0x00007E02
		[CustomObfuscation(rename = false)]
		public int inputManagerId
		{
			get
			{
				return this.jQsrtMmFzxOTpxuthxmQDRdsBXKF;
			}
			set
			{
				this.jQsrtMmFzxOTpxuthxmQDRdsBXKF = value;
			}
		}

		// Token: 0x170002C2 RID: 706
		// (get) Token: 0x06000956 RID: 2390 RVA: 0x00009C0B File Offset: 0x00007E0B
		[CustomObfuscation(rename = false)]
		public string name
		{
			get
			{
				if (!(this.RuRPjumrSdIiQWvAxhLlwCJVQcps != "Unknown Controller"))
				{
					return this.XGCDgTCPVxWwDfFjrWmblOLHFTcpA;
				}
				return this.RuRPjumrSdIiQWvAxhLlwCJVQcps;
			}
		}

		// Token: 0x170002C3 RID: 707
		// (get) Token: 0x06000957 RID: 2391 RVA: 0x000439A4 File Offset: 0x00041BA4
		[CustomObfuscation(rename = false)]
		public long? systemId
		{
			get
			{
				if (this.rcTLEVxEgdKNEdsHOzYNOPbfQmlo < 1)
				{
					return null;
				}
				return new long?((long)this.rcTLEVxEgdKNEdsHOzYNOPbfQmlo);
			}
		}

		// Token: 0x170002C4 RID: 708
		// (get) Token: 0x06000958 RID: 2392 RVA: 0x00009C2C File Offset: 0x00007E2C
		// (set) Token: 0x06000959 RID: 2393 RVA: 0x00009C34 File Offset: 0x00007E34
		[CustomObfuscation(rename = false)]
		public int unityId
		{
			get
			{
				return this.rcTLEVxEgdKNEdsHOzYNOPbfQmlo;
			}
			set
			{
				this.rcTLEVxEgdKNEdsHOzYNOPbfQmlo = value;
			}
		}

		// Token: 0x170002C5 RID: 709
		// (get) Token: 0x0600095A RID: 2394 RVA: 0x000439D0 File Offset: 0x00041BD0
		[CustomObfuscation(rename = false)]
		public Guid instanceGuid
		{
			get
			{
				if ((ReInput.isWindowsStandaloneWebplayerOrEditorPlatform && !UnityTools.windowsJoystickNamesReturnsEmptyStringsIfJoystickNull) || UnityTools.effectivePlatform == Platform.OSX)
				{
					return MiscTools.CreateGuidHashSHA1(this.name);
				}
				if (UnityTools.isIOSPlatform)
				{
					return MiscTools.CreateGuidHashSHA1(this.XGCDgTCPVxWwDfFjrWmblOLHFTcpA);
				}
				return MiscTools.CreateGuidHashSHA1(this.name + "_" + this.rcTLEVxEgdKNEdsHOzYNOPbfQmlo.ToString());
			}
		}

		// Token: 0x170002C6 RID: 710
		// (get) Token: 0x0600095B RID: 2395 RVA: 0x00009C3D File Offset: 0x00007E3D
		[CustomObfuscation(rename = false)]
		public Guid persistentGuid
		{
			get
			{
				return this.instanceGuid;
			}
		}

		// Token: 0x170002C7 RID: 711
		// (get) Token: 0x0600095C RID: 2396 RVA: 0x000067FE File Offset: 0x000049FE
		[CustomObfuscation(rename = false)]
		public Controller.Extension extension
		{
			get
			{
				return null;
			}
		}

		// Token: 0x0600095D RID: 2397 RVA: 0x00002FF9 File Offset: 0x000011F9
		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
		}

		// Token: 0x0600095E RID: 2398 RVA: 0x00002FF9 File Offset: 0x000011F9
		[CustomObfuscation(rename = false)]
		public void StopVibration()
		{
		}

		// Token: 0x0600095F RID: 2399 RVA: 0x00009C45 File Offset: 0x00007E45
		public oVUyOLUvUEGkvZsIaWwEHqTEUPNh()
		{
			this.jQsrtMmFzxOTpxuthxmQDRdsBXKF = -1;
			this.madcIuGhHpPqMzbHrvzjNkbXlPHlA = -1;
			this.rcTLEVxEgdKNEdsHOzYNOPbfQmlo = 0;
		}

		// Token: 0x06000960 RID: 2400 RVA: 0x00043A34 File Offset: 0x00041C34
		public void APLJuxngDnwgyFsFGqwnonFbObvF()
		{
			this.yrEhlTHLDIiCHmxbWewutIMHBSpn();
			this.LjWgwOsRKqzoUdsbjfWLKULsGzPh = this.wtSFzoHlwKkPVUVDeMpFGElphait.hardwareMapIdentifier.guid;
			this.RuRPjumrSdIiQWvAxhLlwCJVQcps = this.wtSFzoHlwKkPVUVDeMpFGElphait.controllerName;
			this.nCTAQFshHJuwsTgWJRBlHtZWYjdi = new float[this.lmRUdoKeEPcUOAqxHIpegviYeCZBb];
			this.ywaKTPZVKjXipWBRlyVPQBQoygiK = new bool[this.qBVicUdZNTunScqOnNtvDzcjYsMIA];
			this.umhZIsYzbwuCMqquBrGCAoZJlkTr = new bool[this.lmRUdoKeEPcUOAqxHIpegviYeCZBb];
			this.ajzBuOMJhqFuTaKdOdVRPbqCPABAA = new bool[29];
			this.pFhCsiFxicaTLVvXNGjCfAqigvQOA = new float[29];
			this.Update();
		}

		// Token: 0x06000961 RID: 2401 RVA: 0x00009C72 File Offset: 0x00007E72
		[CustomObfuscation(rename = false)]
		public void Update()
		{
			if (this.rcTLEVxEgdKNEdsHOzYNOPbfQmlo <= 0)
			{
				return;
			}
			this.GCZQHTyBfGohOBIykcQFhqKaGHtvA();
			this.CCIDMAuSeesDvCisQHKUivVqfios();
			this.ApbQQoMQMRESDbWUHoIDGjxohGbn();
		}

		// Token: 0x06000962 RID: 2402 RVA: 0x00043AC4 File Offset: 0x00041CC4
		public int PSXvmQWsbVkUbjwwIhQMksUBgIVU(fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.oVUyOLUvUEGkvZsIaWwEHqTEUPNh A_1)
		{
			if ((!string.IsNullOrEmpty(this.ZUFYTzmpbcggAOuQbfFkwUHyHMJr) || !string.IsNullOrEmpty(A_1.ZUFYTzmpbcggAOuQbfFkwUHyHMJr)) && !string.Equals(this.ZUFYTzmpbcggAOuQbfFkwUHyHMJr, A_1.ZUFYTzmpbcggAOuQbfFkwUHyHMJr, StringComparison.Ordinal))
			{
				return 0;
			}
			if (A_1.XGCDgTCPVxWwDfFjrWmblOLHFTcpA == this.XGCDgTCPVxWwDfFjrWmblOLHFTcpA && A_1.flUEPFupfmQaRTaHZWoKvobKcLTIA == this.flUEPFupfmQaRTaHZWoKvobKcLTIA)
			{
				return 2;
			}
			if (A_1.XGCDgTCPVxWwDfFjrWmblOLHFTcpA == this.XGCDgTCPVxWwDfFjrWmblOLHFTcpA)
			{
				return 1;
			}
			return 0;
		}

		// Token: 0x06000963 RID: 2403 RVA: 0x00043B3C File Offset: 0x00041D3C
		private void eKAVmfVtOnkQHjrBMBzgVojhAxHl(BridgedControllerHWInfo A_1)
		{
			A_1.inputManagerSource = InputSource.Fallback;
			A_1.inputSource = this.TxrDyVbfGKskbbMKSCMUQtfmLgzW();
			A_1.hardwareIdentifier = this.FdBFDObsnbdsrmXHMsiXvgNBKOMl();
			A_1.hardwareAxisCount = 0;
			A_1.hardwareButtonCount = 0;
			A_1.hardwareHatCount = 0;
			A_1.hw_productName = this.XGCDgTCPVxWwDfFjrWmblOLHFTcpA;
		}

		// Token: 0x06000964 RID: 2404 RVA: 0x00043B8C File Offset: 0x00041D8C
		private void IDMYVwCDKngIjVXhsXTtYSnosNc(BridgedController A_1)
		{
			this.eKAVmfVtOnkQHjrBMBzgVojhAxHl(A_1);
			A_1.sourceJoystick = this;
			A_1.gameHardwareMap = this.wtSFzoHlwKkPVUVDeMpFGElphait.ToGameHardwareControllerMap();
			A_1.instanceName = this.XGCDgTCPVxWwDfFjrWmblOLHFTcpA;
			A_1.productName = this.XGCDgTCPVxWwDfFjrWmblOLHFTcpA;
			A_1.isXInputDevice = false;
			A_1.axisCount = this.lmRUdoKeEPcUOAqxHIpegviYeCZBb;
			A_1.buttonCount = this.qBVicUdZNTunScqOnNtvDzcjYsMIA;
			A_1.controllerTypeGuid = this.LjWgwOsRKqzoUdsbjfWLKULsGzPh;
		}

		// Token: 0x06000965 RID: 2405 RVA: 0x00043BFC File Offset: 0x00041DFC
		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (this.lmRUdoKeEPcUOAqxHIpegviYeCZBb != dataUpdater.axisCount || this.qBVicUdZNTunScqOnNtvDzcjYsMIA != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			float[] axisValues = dataUpdater.axisValues;
			bool[] axisHasBeenPressedOSXLinux = dataUpdater.axisHasBeenPressedOSXLinux;
			for (int i = 0; i < this.lmRUdoKeEPcUOAqxHIpegviYeCZBb; i++)
			{
				if (axisValues[i] != this.nCTAQFshHJuwsTgWJRBlHtZWYjdi[i])
				{
					axisValues[i] = this.nCTAQFshHJuwsTgWJRBlHtZWYjdi[i];
					if (axisHasBeenPressedOSXLinux[i] != this.umhZIsYzbwuCMqquBrGCAoZJlkTr[i])
					{
						axisHasBeenPressedOSXLinux[i] = this.umhZIsYzbwuCMqquBrGCAoZJlkTr[i];
					}
				}
			}
			bool[] buttonValues = dataUpdater.buttonValues;
			for (int j = 0; j < this.qBVicUdZNTunScqOnNtvDzcjYsMIA; j++)
			{
				if (buttonValues[j] != this.ywaKTPZVKjXipWBRlyVPQBQoygiK[j])
				{
					buttonValues[j] = this.ywaKTPZVKjXipWBRlyVPQBQoygiK[j];
				}
			}
			if (this.mWZdKEoWQbyhCGbCHUZCIZCXlcDX && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		// Token: 0x06000966 RID: 2406 RVA: 0x00009C90 File Offset: 0x00007E90
		public void NNOuMjyIivXmXHjgWESpefANKpXf(int A_1)
		{
			if (A_1 < 1 || A_1 > 16)
			{
				return;
			}
			this.unityId = A_1;
		}

		// Token: 0x06000967 RID: 2407 RVA: 0x00009CA3 File Offset: 0x00007EA3
		public void JlFkceTwbDnPDNYxDmDcBBEtYcPo()
		{
			this.rcTLEVxEgdKNEdsHOzYNOPbfQmlo = 0;
			this.nPkPGhncYIyidzmYPXnOUeKeDLrFA();
		}

		// Token: 0x06000968 RID: 2408 RVA: 0x00043CD0 File Offset: 0x00041ED0
		public BridgedControllerHWInfo ZTytvArcjkShazpvkWOKrBfsgGweA()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			this.eKAVmfVtOnkQHjrBMBzgVojhAxHl(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		// Token: 0x06000969 RID: 2409 RVA: 0x00043CEC File Offset: 0x00041EEC
		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			this.IDMYVwCDKngIjVXhsXTtYSnosNc(bridgedController);
			return bridgedController;
		}

		// Token: 0x0600096A RID: 2410 RVA: 0x00009CB2 File Offset: 0x00007EB2
		[CustomObfuscation(rename = false)]
		public ControllerDisconnectedEventArgs ToControllerDisconnectedEventArgs()
		{
			return new ControllerDisconnectedEventArgs(this.madcIuGhHpPqMzbHrvzjNkbXlPHlA);
		}

		// Token: 0x0600096B RID: 2411 RVA: 0x00043D08 File Offset: 0x00041F08
		private void GCZQHTyBfGohOBIykcQFhqKaGHtvA()
		{
			for (int i = 0; i < 29; i++)
			{
				float joystickAxisValueByJoystickId = UnityInputHelper.GetJoystickAxisValueByJoystickId(this.rcTLEVxEgdKNEdsHOzYNOPbfQmlo, i);
				if (this.pFhCsiFxicaTLVvXNGjCfAqigvQOA[i] != joystickAxisValueByJoystickId)
				{
					this.pFhCsiFxicaTLVvXNGjCfAqigvQOA[i] = joystickAxisValueByJoystickId;
					if (!this.ajzBuOMJhqFuTaKdOdVRPbqCPABAA[i] && joystickAxisValueByJoystickId != 0f)
					{
						this.ajzBuOMJhqFuTaKdOdVRPbqCPABAA[i] = true;
					}
				}
			}
		}

		// Token: 0x0600096C RID: 2412 RVA: 0x00043D60 File Offset: 0x00041F60
		private void CCIDMAuSeesDvCisQHKUivVqfios()
		{
			HardwareJoystickMap.Platform_Fallback_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_Fallback_Base)this.wtSFzoHlwKkPVUVDeMpFGElphait.map).Axes_orig;
			if (axes_orig == null)
			{
				return;
			}
			for (int i = 0; i < axes_orig.Length; i++)
			{
				if (axes_orig[i] != null)
				{
					if (i >= this.lmRUdoKeEPcUOAqxHIpegviYeCZBb)
					{
						throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
					}
					float num = this.ZXMiWWhBFJBbsECGwXsWoqTOIXcGA(axes_orig[i]);
					if (this.nCTAQFshHJuwsTgWJRBlHtZWYjdi[i] != num)
					{
						this.nCTAQFshHJuwsTgWJRBlHtZWYjdi[i] = num;
						if (!this.umhZIsYzbwuCMqquBrGCAoZJlkTr[i])
						{
							if (axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis)
							{
								float num2 = this.fWDZHgKgnGzwvNdSuAWqwQcEOepp(axes_orig[i].sourceAxis);
								this.umhZIsYzbwuCMqquBrGCAoZJlkTr[i] = (num2 != 0f);
							}
							else
							{
								this.umhZIsYzbwuCMqquBrGCAoZJlkTr[i] = true;
							}
						}
						if (!this.mWZdKEoWQbyhCGbCHUZCIZCXlcDX && this.nCTAQFshHJuwsTgWJRBlHtZWYjdi[i] != 0f)
						{
							this.mWZdKEoWQbyhCGbCHUZCIZCXlcDX = true;
						}
					}
				}
			}
		}

		// Token: 0x0600096D RID: 2413 RVA: 0x00043E38 File Offset: 0x00042038
		private void ApbQQoMQMRESDbWUHoIDGjxohGbn()
		{
			HardwareJoystickMap.Platform_Fallback_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_Fallback_Base)this.wtSFzoHlwKkPVUVDeMpFGElphait.map).Buttons_orig;
			if (buttons_orig == null)
			{
				return;
			}
			for (int i = 0; i < buttons_orig.Length; i++)
			{
				if (i >= this.qBVicUdZNTunScqOnNtvDzcjYsMIA)
				{
					throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
				}
				bool flag = this.fgwEiwmOlHqaFYTAoHqLoWpZgdZv(buttons_orig[i]);
				if (this.ywaKTPZVKjXipWBRlyVPQBQoygiK[i] != flag)
				{
					this.ywaKTPZVKjXipWBRlyVPQBQoygiK[i] = flag;
					if (!this.mWZdKEoWQbyhCGbCHUZCIZCXlcDX && this.ywaKTPZVKjXipWBRlyVPQBQoygiK[i])
					{
						this.mWZdKEoWQbyhCGbCHUZCIZCXlcDX = true;
					}
				}
			}
		}

		// Token: 0x0600096E RID: 2414 RVA: 0x00043EB8 File Offset: 0x000420B8
		private bool fgwEiwmOlHqaFYTAoHqLoWpZgdZv(HardwareJoystickMap.Platform_Fallback_Base.Button A_1)
		{
			if (A_1.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				if (A_1.ignoreIfButtonsActive)
				{
					for (int i = 0; i < A_1.ignoreIfButtonsActiveButtons.Length; i++)
					{
						if (this.shWJdrBjHDyBgPnSPLKHfeaWiuMZ(A_1.ignoreIfButtonsActiveButtons[i]))
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
						if (!this.shWJdrBjHDyBgPnSPLKHfeaWiuMZ(A_1.requiredButtons[j]))
						{
							return false;
						}
						result = true;
					}
					return result;
				}
				return A_1.sourceButton != UnityButton.None && this.shWJdrBjHDyBgPnSPLKHfeaWiuMZ(A_1.sourceButton);
			}
			else
			{
				if (A_1.sourceType != HardwareElementSourceTypeWithHat.Axis)
				{
					if (A_1.sourceType == HardwareElementSourceTypeWithHat.Hat)
					{
						if (A_1.unityHat_sourceAxis1 == UnityAxis.None || A_1.unityHat_sourceAxis2 == UnityAxis.None)
						{
							return false;
						}
						UnityAxis unityHat_sourceAxis = A_1.unityHat_sourceAxis1;
						UnityAxis unityHat_sourceAxis2 = A_1.unityHat_sourceAxis2;
						float num = this.fWDZHgKgnGzwvNdSuAWqwQcEOepp(unityHat_sourceAxis);
						float num2 = this.fWDZHgKgnGzwvNdSuAWqwQcEOepp(unityHat_sourceAxis2);
						float x;
						float y;
						if (A_1.unityHat_checkNeverPressed)
						{
							if (this.MFNIyfbzPGCgpUaIOezmTCCfbXvQ(unityHat_sourceAxis) || this.MFNIyfbzPGCgpUaIOezmTCCfbXvQ(unityHat_sourceAxis2))
							{
								x = A_1.unityHat_zeroValues.x;
								y = A_1.unityHat_zeroValues.y;
							}
							else
							{
								x = A_1.unityHat_neverPressedZeroValues.x;
								y = A_1.unityHat_neverPressedZeroValues.y;
							}
						}
						else
						{
							x = A_1.unityHat_zeroValues.x;
							y = A_1.unityHat_zeroValues.y;
						}
						if (MathTools.Approximately(num, x) && MathTools.Approximately(num2, y))
						{
							return false;
						}
						if (this.rWNFbNYXVzjyCIDBwWyCiybJZcfI(A_1.unityHat_isActiveAxisValues1.x, num) && this.rWNFbNYXVzjyCIDBwWyCiybJZcfI(A_1.unityHat_isActiveAxisValues1.y, num2))
						{
							return true;
						}
						if (this.rWNFbNYXVzjyCIDBwWyCiybJZcfI(A_1.unityHat_isActiveAxisValues2.x, num) && this.rWNFbNYXVzjyCIDBwWyCiybJZcfI(A_1.unityHat_isActiveAxisValues2.y, num2))
						{
							return true;
						}
						if (this.rWNFbNYXVzjyCIDBwWyCiybJZcfI(A_1.unityHat_isActiveAxisValues3.x, num) && this.rWNFbNYXVzjyCIDBwWyCiybJZcfI(A_1.unityHat_isActiveAxisValues3.y, num2))
						{
							return true;
						}
					}
					else
					{
						if (A_1.sourceType == HardwareElementSourceTypeWithHat.Key)
						{
							return A_1.sourceKeyCode != KeyCode.None && Input.GetKey(A_1.sourceKeyCode);
						}
						if (A_1.sourceType == HardwareElementSourceTypeWithHat.Custom)
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
							HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData[] customCalculationSourceData = A_1.customCalculationSourceData;
							if (customCalculationSourceData == null)
							{
								return false;
							}
							for (int k = 0; k < customCalculationSourceData.Length; k++)
							{
								if (customCalculationSourceData[k] != null)
								{
									switch (customCalculationSourceData[k].sourceType)
									{
									case 0:
									{
										bool flag;
										if (this.QJfTqeVtfECaoghQCQIyuKGNVZOu(customCalculationSourceData[k], out flag))
										{
											customCalculation.AddData(flag ? 1f : 0f);
										}
										break;
									}
									case 1:
									{
										float num3;
										if (this.ArpbjgFhyuNSMAiVCrDkmQcByyTHb(customCalculationSourceData[k], out num3))
										{
											customCalculation.AddData((num3 != 0f) ? 1f : 0f);
										}
										break;
									}
									case 3:
									{
										bool flag2;
										if (this.HdcZkTxlzPmxaUPqRvKJtbSXVILK(customCalculationSourceData[k], out flag2))
										{
											customCalculation.AddData(flag2 ? 1f : 0f);
										}
										break;
									}
									}
								}
							}
							return customCalculation.Process() && customCalculation.Result.type == TypeWrapper.DataType.Single && customCalculation.Result != 0f;
						}
					}
					return false;
				}
				if (A_1.sourceAxis == UnityAxis.None)
				{
					return false;
				}
				float num4 = this.fWDZHgKgnGzwvNdSuAWqwQcEOepp(A_1.sourceAxis);
				return MathTools.Abs(num4) > A_1.axisDeadZone && (A_1.sourceAxisPole != Pole.Positive || num4 >= 0f) && (A_1.sourceAxisPole != Pole.Negative || num4 <= 0f);
			}
		}

		// Token: 0x0600096F RID: 2415 RVA: 0x00009CBF File Offset: 0x00007EBF
		private bool rWNFbNYXVzjyCIDBwWyCiybJZcfI(float A_1, float A_2)
		{
			return MathTools.IsNear(A_2, A_1, 0.1f);
		}

		// Token: 0x06000970 RID: 2416 RVA: 0x0004424C File Offset: 0x0004244C
		private float ZXMiWWhBFJBbsECGwXsWoqTOIXcGA(HardwareJoystickMap.Platform_Fallback_Base.Axis A_1)
		{
			HardwareElementSourceTypeWithHat sourceType = A_1.sourceType;
			switch (sourceType)
			{
			case HardwareElementSourceTypeWithHat.Button:
			{
				if (A_1.sourceButton == UnityButton.None)
				{
					return 0f;
				}
				if (!this.shWJdrBjHDyBgPnSPLKHfeaWiuMZ(A_1.sourceButton))
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
			case HardwareElementSourceTypeWithHat.Axis:
				if (A_1.sourceAxis == UnityAxis.None)
				{
					return 0f;
				}
				if (!this.MFNIyfbzPGCgpUaIOezmTCCfbXvQ(A_1.sourceAxis))
				{
					return 0f;
				}
				return this.fWDZHgKgnGzwvNdSuAWqwQcEOepp(A_1.sourceAxis);
			case HardwareElementSourceTypeWithHat.Hat:
				break;
			case HardwareElementSourceTypeWithHat.Key:
			{
				if (A_1.sourceKeyCode == KeyCode.None)
				{
					return 0f;
				}
				if (!Input.GetKey(A_1.sourceKeyCode))
				{
					return 0f;
				}
				float result2;
				if (A_1.buttonAxisContribution == Pole.Positive)
				{
					result2 = 1f;
				}
				else
				{
					result2 = -1f;
				}
				return result2;
			}
			default:
				if (sourceType == HardwareElementSourceTypeWithHat.Custom)
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
					HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData[] customCalculationSourceData = A_1.customCalculationSourceData;
					if (customCalculationSourceData == null)
					{
						return 0f;
					}
					for (int i = 0; i < customCalculationSourceData.Length; i++)
					{
						float item;
						if (customCalculationSourceData[i] != null && customCalculationSourceData[i].sourceType == 1 && this.ArpbjgFhyuNSMAiVCrDkmQcByyTHb(customCalculationSourceData[i], out item))
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
				break;
			}
			return 0f;
		}

		// Token: 0x06000971 RID: 2417 RVA: 0x000443D0 File Offset: 0x000425D0
		private float fWDZHgKgnGzwvNdSuAWqwQcEOepp(UnityAxis A_1)
		{
			if (A_1 == UnityAxis.None)
			{
				return 0f;
			}
			int num = A_1 - UnityAxis.Axis0;
			return this.pFhCsiFxicaTLVvXNGjCfAqigvQOA[num];
		}

		// Token: 0x06000972 RID: 2418 RVA: 0x000443F4 File Offset: 0x000425F4
		private bool shWJdrBjHDyBgPnSPLKHfeaWiuMZ(UnityButton A_1)
		{
			int buttonIndex = A_1 - UnityButton.Button0;
			return UnityInputHelper.GetJoystickButtonValueByJoystickId(this.rcTLEVxEgdKNEdsHOzYNOPbfQmlo, buttonIndex);
		}

		// Token: 0x06000973 RID: 2419 RVA: 0x00044414 File Offset: 0x00042614
		private bool QJfTqeVtfECaoghQCQIyuKGNVZOu(HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData A_1, out bool A_2)
		{
			A_2 = false;
			if (A_1.sourceType != 0)
			{
				return false;
			}
			UnityButton sourceElement = (UnityButton)A_1.sourceElement;
			if (sourceElement == UnityButton.None)
			{
				return false;
			}
			A_2 = this.shWJdrBjHDyBgPnSPLKHfeaWiuMZ(sourceElement);
			return true;
		}

		// Token: 0x06000974 RID: 2420 RVA: 0x00044444 File Offset: 0x00042644
		private bool HdcZkTxlzPmxaUPqRvKJtbSXVILK(HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData A_1, out bool A_2)
		{
			A_2 = false;
			if (A_1.sourceType != 3)
			{
				return false;
			}
			KeyCode sourceElement = (KeyCode)A_1.sourceElement;
			if (sourceElement == KeyCode.None)
			{
				return false;
			}
			A_2 = Input.GetKey(sourceElement);
			return true;
		}

		// Token: 0x06000975 RID: 2421 RVA: 0x00044474 File Offset: 0x00042674
		private bool ArpbjgFhyuNSMAiVCrDkmQcByyTHb(HardwareJoystickMap.Platform_Fallback_Base.CustomCalculationSourceData A_1, out float A_2)
		{
			A_2 = 0f;
			if (A_1.sourceType != 1)
			{
				return false;
			}
			UnityAxis sourceElement = (UnityAxis)A_1.sourceElement;
			if (sourceElement == UnityAxis.None)
			{
				return false;
			}
			A_2 = this.fWDZHgKgnGzwvNdSuAWqwQcEOepp(sourceElement);
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
			if (A_1.deadzone > 0f && MathTools.Abs(A_2) <= A_1.deadzone)
			{
				A_2 = 0f;
			}
			if (A_1.invert)
			{
				A_2 *= -1f;
			}
			return true;
		}

		// Token: 0x06000976 RID: 2422 RVA: 0x00044510 File Offset: 0x00042710
		private bool MFNIyfbzPGCgpUaIOezmTCCfbXvQ(UnityAxis A_1)
		{
			int num = A_1 - UnityAxis.Axis0;
			return this.ajzBuOMJhqFuTaKdOdVRPbqCPABAA[num];
		}

		// Token: 0x06000977 RID: 2423 RVA: 0x0004452C File Offset: 0x0004272C
		private void yrEhlTHLDIiCHmxbWewutIMHBSpn()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = this.ZTytvArcjkShazpvkWOKrBfsgGweA();
			if (UnityTools.isAndroidPlatform)
			{
				if (Regex.IsMatch(this.XGCDgTCPVxWwDfFjrWmblOLHFTcpA, "Xbox Wireless Controller.*"))
				{
					List<int> list;
					List<int> list2;
					UnityTools.externalTools.GetDeviceVIDPIDs(out list, out list2);
					for (int i = 0; i < list.Count; i++)
					{
						if (list[i] == 1118 && list2[i] == 736)
						{
							bridgedControllerHWInfo.definitionMatchTag = "[FW1]";
							break;
						}
					}
				}
				else if (UnityTools.lRGJvbHYYtwJWseuIXpNcoFOvLDL != null)
				{
					IAndroidFallbackDS4Helper ds4Helper = UnityTools.lRGJvbHYYtwJWseuIXpNcoFOvLDL.ds4Helper;
					if (ds4Helper != null && ds4Helper.IsDS4(this.XGCDgTCPVxWwDfFjrWmblOLHFTcpA))
					{
						if (ds4Helper.IsDS4KeyMapped(this.flUEPFupfmQaRTaHZWoKvobKcLTIA))
						{
							bridgedControllerHWInfo.definitionMatchTag = "[KEYMAP]";
						}
						else
						{
							bridgedControllerHWInfo.definitionMatchTag = "[NOKEYMAP]";
						}
					}
				}
			}
			this.wtSFzoHlwKkPVUVDeMpFGElphait = ReInput.GetHardwareJoystickMap_InputManager(bridgedControllerHWInfo);
			if (this.wtSFzoHlwKkPVUVDeMpFGElphait == null)
			{
				Logger.LogError("Default hardware map not found!");
				return;
			}
			if (UnityTools.isIOSPlatform && this.wtSFzoHlwKkPVUVDeMpFGElphait.hardwareMapIdentifier.guid == Consts.joystickGuid_appleMFiController)
			{
				string text = fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.oVUyOLUvUEGkvZsIaWwEHqTEUPNh.fxwgIGdcJwjHYBIMUydHieCvLHLdA(this.XGCDgTCPVxWwDfFjrWmblOLHFTcpA);
				if (!string.IsNullOrEmpty(text))
				{
					this.wtSFzoHlwKkPVUVDeMpFGElphait.controllerName = text;
					if (this.wtSFzoHlwKkPVUVDeMpFGElphait.deviceLocalizationInfo.parentKeys.Count > 0 && !string.IsNullOrEmpty(this.wtSFzoHlwKkPVUVDeMpFGElphait.deviceLocalizationInfo.parentKeys[0]))
					{
						this.wtSFzoHlwKkPVUVDeMpFGElphait.deviceLocalizationInfo.InsertParentKey(0, LocalizationManager.AppendToKeyAsPath(this.wtSFzoHlwKkPVUVDeMpFGElphait.deviceLocalizationInfo.parentKeys[0], text));
					}
					this.wtSFzoHlwKkPVUVDeMpFGElphait.deviceLocalizationInfo.additionalIdentifyingInformation = text;
				}
			}
			else if (this.wtSFzoHlwKkPVUVDeMpFGElphait.useSystemName && !string.IsNullOrEmpty(this.XGCDgTCPVxWwDfFjrWmblOLHFTcpA))
			{
				string text2 = Regex.Replace(this.XGCDgTCPVxWwDfFjrWmblOLHFTcpA, "\\s+", " ");
				text2 = text2.Trim();
				if (!string.IsNullOrEmpty(text2))
				{
					this.wtSFzoHlwKkPVUVDeMpFGElphait.controllerName = text2;
					if (this.wtSFzoHlwKkPVUVDeMpFGElphait.deviceLocalizationInfo.parentKeys.Count > 0 && !string.IsNullOrEmpty(this.wtSFzoHlwKkPVUVDeMpFGElphait.deviceLocalizationInfo.parentKeys[0]))
					{
						this.wtSFzoHlwKkPVUVDeMpFGElphait.deviceLocalizationInfo.InsertParentKey(0, LocalizationManager.AppendToKeyAsPath(this.wtSFzoHlwKkPVUVDeMpFGElphait.deviceLocalizationInfo.parentKeys[0], text2));
					}
					this.wtSFzoHlwKkPVUVDeMpFGElphait.deviceLocalizationInfo.additionalIdentifyingInformation = text2;
				}
			}
			this.lmRUdoKeEPcUOAqxHIpegviYeCZBb = this.wtSFzoHlwKkPVUVDeMpFGElphait.axisCount;
			this.qBVicUdZNTunScqOnNtvDzcjYsMIA = this.wtSFzoHlwKkPVUVDeMpFGElphait.buttonCount;
		}

		// Token: 0x06000978 RID: 2424 RVA: 0x00009CCD File Offset: 0x00007ECD
		private void nPkPGhncYIyidzmYPXnOUeKeDLrFA()
		{
			Array.Clear(this.ywaKTPZVKjXipWBRlyVPQBQoygiK, 0, this.ywaKTPZVKjXipWBRlyVPQBQoygiK.Length);
			Array.Clear(this.nCTAQFshHJuwsTgWJRBlHtZWYjdi, 0, this.nCTAQFshHJuwsTgWJRBlHtZWYjdi.Length);
		}

		// Token: 0x06000979 RID: 2425 RVA: 0x000447CC File Offset: 0x000429CC
		private string FdBFDObsnbdsrmXHMsiXvgNBKOMl()
		{
			if (ReInput.currentPlatform == Platform.Webplayer)
			{
				return InputTools.FormatHardwareIdentifierString(string.Format("{0}{1}{2}{3}", new object[]
				{
					ReInput.currentPlatform.ToString(),
					ReInput.webplayerPlatform.ToString(),
					this.TxrDyVbfGKskbbMKSCMUQtfmLgzW().ToString(),
					this.XGCDgTCPVxWwDfFjrWmblOLHFTcpA
				}));
			}
			if (UnityTools.isIOSPlatform)
			{
				string arg = Regex.Replace(this.XGCDgTCPVxWwDfFjrWmblOLHFTcpA, "joystick [0-9]+ by ", "");
				return InputTools.FormatHardwareIdentifierString(string.Format("{0}{1}{2}", ReInput.currentPlatform.ToString(), this.TxrDyVbfGKskbbMKSCMUQtfmLgzW().ToString(), arg));
			}
			return InputTools.FormatHardwareIdentifierString(string.Format("{0}{1}{2}", ReInput.currentPlatform.ToString(), this.TxrDyVbfGKskbbMKSCMUQtfmLgzW().ToString(), this.XGCDgTCPVxWwDfFjrWmblOLHFTcpA));
		}

		// Token: 0x0600097A RID: 2426 RVA: 0x00009CF7 File Offset: 0x00007EF7
		private InputSource TxrDyVbfGKskbbMKSCMUQtfmLgzW()
		{
			if (UnityTools.platform == Platform.Linux && UnityTools.externalTools.LinuxInput_IsJoystickPreconfigured(this.XGCDgTCPVxWwDfFjrWmblOLHFTcpA))
			{
				return InputSource.Fallback_PreConfigured;
			}
			return InputSource.Fallback;
		}

		// Token: 0x0600097B RID: 2427 RVA: 0x00009D16 File Offset: 0x00007F16
		public static int OMQawECRYRHtXIFnPqZLJUnjzCNIA(fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.oVUyOLUvUEGkvZsIaWwEHqTEUPNh A_0, fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.oVUyOLUvUEGkvZsIaWwEHqTEUPNh A_1)
		{
			if (A_0.inputManagerId < A_1.inputManagerId)
			{
				return -1;
			}
			if (A_0.inputManagerId > A_1.inputManagerId)
			{
				return 1;
			}
			return 0;
		}

		// Token: 0x0600097C RID: 2428 RVA: 0x00009D39 File Offset: 0x00007F39
		public static int zWicITQtCbIJlIuKdidrgFsUEjOyA(fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.oVUyOLUvUEGkvZsIaWwEHqTEUPNh A_0, fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.oVUyOLUvUEGkvZsIaWwEHqTEUPNh A_1)
		{
			if (A_0.unityId < A_1.unityId)
			{
				return -1;
			}
			if (A_0.unityId > A_1.unityId)
			{
				return 1;
			}
			return 0;
		}

		// Token: 0x0600097D RID: 2429 RVA: 0x000448D8 File Offset: 0x00042AD8
		private static string fxwgIGdcJwjHYBIMUydHieCvLHLdA(string A_0)
		{
			string text = Regex.Replace(A_0, "\\[.*\\] joystick [0-9]+ by ", "");
			text = Regex.Replace(text, "\\s+", " ");
			if (!string.IsNullOrEmpty(text))
			{
				text = text.Trim();
			}
			return text;
		}

		// Token: 0x0400070B RID: 1803
		private int madcIuGhHpPqMzbHrvzjNkbXlPHlA;

		// Token: 0x0400070C RID: 1804
		private int jQsrtMmFzxOTpxuthxmQDRdsBXKF;

		// Token: 0x0400070D RID: 1805
		private int rcTLEVxEgdKNEdsHOzYNOPbfQmlo;

		// Token: 0x0400070E RID: 1806
		public Guid LjWgwOsRKqzoUdsbjfWLKULsGzPh;

		// Token: 0x0400070F RID: 1807
		public string RuRPjumrSdIiQWvAxhLlwCJVQcps;

		// Token: 0x04000710 RID: 1808
		public int flUEPFupfmQaRTaHZWoKvobKcLTIA;

		// Token: 0x04000711 RID: 1809
		public string XGCDgTCPVxWwDfFjrWmblOLHFTcpA;

		// Token: 0x04000712 RID: 1810
		public string ZUFYTzmpbcggAOuQbfFkwUHyHMJr;

		// Token: 0x04000713 RID: 1811
		private int lmRUdoKeEPcUOAqxHIpegviYeCZBb = 29;

		// Token: 0x04000714 RID: 1812
		private int qBVicUdZNTunScqOnNtvDzcjYsMIA = 20;

		// Token: 0x04000715 RID: 1813
		private float[] nCTAQFshHJuwsTgWJRBlHtZWYjdi;

		// Token: 0x04000716 RID: 1814
		private bool[] ywaKTPZVKjXipWBRlyVPQBQoygiK;

		// Token: 0x04000717 RID: 1815
		private bool[] umhZIsYzbwuCMqquBrGCAoZJlkTr;

		// Token: 0x04000718 RID: 1816
		private float[] pFhCsiFxicaTLVvXNGjCfAqigvQOA;

		// Token: 0x04000719 RID: 1817
		private bool[] ajzBuOMJhqFuTaKdOdVRPbqCPABAA;

		// Token: 0x0400071A RID: 1818
		private HardwareJoystickMap_InputManager wtSFzoHlwKkPVUVDeMpFGElphait;

		// Token: 0x0400071B RID: 1819
		private bool mWZdKEoWQbyhCGbCHUZCIZCXlcDX;
	}

	// Token: 0x0200010B RID: 267
	private class rpNpYaCjKlVCOvvfPAnMzAQXjmSI
	{
		// Token: 0x0600097E RID: 2430 RVA: 0x00009D5C File Offset: 0x00007F5C
		public rpNpYaCjKlVCOvvfPAnMzAQXjmSI()
		{
			this.dtcamwdVJwgTbbSotFQGTTLqtrHGA = new List<fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.rpNpYaCjKlVCOvvfPAnMzAQXjmSI.IWSglNMsKKXCXIszFMVrWJKGqpOx>();
		}

		// Token: 0x170002C8 RID: 712
		// (get) Token: 0x0600097F RID: 2431 RVA: 0x00009D6F File Offset: 0x00007F6F
		public int QmNedyxNEQbHtfEkgrpPTUYDvFlw
		{
			get
			{
				return this.dtcamwdVJwgTbbSotFQGTTLqtrHGA.Count;
			}
		}

		// Token: 0x06000980 RID: 2432 RVA: 0x00044918 File Offset: 0x00042B18
		public void DzODbtlLrzaxZAnztvdHkpfOWwEu(fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.oVUyOLUvUEGkvZsIaWwEHqTEUPNh A_1)
		{
			if (A_1 == null)
			{
				return;
			}
			int count = this.dtcamwdVJwgTbbSotFQGTTLqtrHGA.Count;
			for (int i = 0; i < count; i++)
			{
				if (this.dtcamwdVJwgTbbSotFQGTTLqtrHGA[i].vzWJCLlZkCBqQqjBsEGwXIzrGDCQ(A_1, fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.rpNpYaCjKlVCOvvfPAnMzAQXjmSI.YiuxBCZaqVLXpOLWvdpUivYUZoEA.Exact))
				{
					this.dtcamwdVJwgTbbSotFQGTTLqtrHGA[i].XcxSraXfSmQRFImnoeSHalROMYxFA = A_1.rewiredId;
					this.dtcamwdVJwgTbbSotFQGTTLqtrHGA[i].fSdPjLrsvTHtVMqiXsVyOyDKIAzX = A_1.XGCDgTCPVxWwDfFjrWmblOLHFTcpA;
					this.dtcamwdVJwgTbbSotFQGTTLqtrHGA[i].xlpjNHHukHnfxnJdSxWhtLKaWhcg = A_1.flUEPFupfmQaRTaHZWoKvobKcLTIA;
					this.dtcamwdVJwgTbbSotFQGTTLqtrHGA[i].gJFhsQdyboVOqqfnZrFFyjyGJcGT = A_1.inputManagerId;
					this.dtcamwdVJwgTbbSotFQGTTLqtrHGA[i].BnoOWZTykgMPHDcGzvadyNjDwBFp = A_1.ZUFYTzmpbcggAOuQbfFkwUHyHMJr;
					this.RCxkcyquIqdZNElUqBTwiIGQKmly(A_1.rewiredId, i);
					return;
				}
			}
			this.dtcamwdVJwgTbbSotFQGTTLqtrHGA.Add(new fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.rpNpYaCjKlVCOvvfPAnMzAQXjmSI.IWSglNMsKKXCXIszFMVrWJKGqpOx
			{
				XcxSraXfSmQRFImnoeSHalROMYxFA = A_1.rewiredId,
				fSdPjLrsvTHtVMqiXsVyOyDKIAzX = A_1.XGCDgTCPVxWwDfFjrWmblOLHFTcpA,
				xlpjNHHukHnfxnJdSxWhtLKaWhcg = A_1.flUEPFupfmQaRTaHZWoKvobKcLTIA,
				gJFhsQdyboVOqqfnZrFFyjyGJcGT = A_1.inputManagerId,
				BnoOWZTykgMPHDcGzvadyNjDwBFp = A_1.ZUFYTzmpbcggAOuQbfFkwUHyHMJr
			});
			this.RCxkcyquIqdZNElUqBTwiIGQKmly(A_1.rewiredId, this.dtcamwdVJwgTbbSotFQGTTLqtrHGA.Count - 1);
		}

		// Token: 0x06000981 RID: 2433 RVA: 0x00044A48 File Offset: 0x00042C48
		public bool NGJITJGFZCFZDLYbInowMoCVsSSi(fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.oVUyOLUvUEGkvZsIaWwEHqTEUPNh A_1, fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.rpNpYaCjKlVCOvvfPAnMzAQXjmSI.YiuxBCZaqVLXpOLWvdpUivYUZoEA A_2)
		{
			int count = this.dtcamwdVJwgTbbSotFQGTTLqtrHGA.Count;
			for (int i = 0; i < count; i++)
			{
				if (this.dtcamwdVJwgTbbSotFQGTTLqtrHGA[i].vzWJCLlZkCBqQqjBsEGwXIzrGDCQ(A_1, A_2))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000982 RID: 2434 RVA: 0x00009D7C File Offset: 0x00007F7C
		public IEnumerable<fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.rpNpYaCjKlVCOvvfPAnMzAQXjmSI.IWSglNMsKKXCXIszFMVrWJKGqpOx> paieoXAyWrPtcGzOItpsdqOtVngO(fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.oVUyOLUvUEGkvZsIaWwEHqTEUPNh A_1, fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.rpNpYaCjKlVCOvvfPAnMzAQXjmSI.YiuxBCZaqVLXpOLWvdpUivYUZoEA A_2)
		{
			int count = this.dtcamwdVJwgTbbSotFQGTTLqtrHGA.Count;
			int num;
			for (int i = 0; i < count; i = num + 1)
			{
				if (this.dtcamwdVJwgTbbSotFQGTTLqtrHGA[i].vzWJCLlZkCBqQqjBsEGwXIzrGDCQ(A_1, A_2))
				{
					yield return this.dtcamwdVJwgTbbSotFQGTTLqtrHGA[i];
				}
				num = i;
			}
			yield break;
		}

		// Token: 0x06000983 RID: 2435 RVA: 0x00044A88 File Offset: 0x00042C88
		public int JbyIHaFlDmpaiaboLgZDfJohHOyDb(fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.rpNpYaCjKlVCOvvfPAnMzAQXjmSI.IWSglNMsKKXCXIszFMVrWJKGqpOx A_1)
		{
			int count = this.dtcamwdVJwgTbbSotFQGTTLqtrHGA.Count;
			for (int i = 0; i < count; i++)
			{
				if (this.dtcamwdVJwgTbbSotFQGTTLqtrHGA[i] == A_1)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06000984 RID: 2436 RVA: 0x00044AC0 File Offset: 0x00042CC0
		private void RCxkcyquIqdZNElUqBTwiIGQKmly(int A_1, int A_2)
		{
			for (int i = this.dtcamwdVJwgTbbSotFQGTTLqtrHGA.Count - 1; i >= 0; i--)
			{
				if (i != A_2 && this.dtcamwdVJwgTbbSotFQGTTLqtrHGA[i].XcxSraXfSmQRFImnoeSHalROMYxFA == A_1)
				{
					this.dtcamwdVJwgTbbSotFQGTTLqtrHGA.RemoveAt(i);
				}
			}
		}

		// Token: 0x0400071C RID: 1820
		private List<fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.rpNpYaCjKlVCOvvfPAnMzAQXjmSI.IWSglNMsKKXCXIszFMVrWJKGqpOx> dtcamwdVJwgTbbSotFQGTTLqtrHGA;

		// Token: 0x0200010C RID: 268
		public enum YiuxBCZaqVLXpOLWvdpUivYUZoEA
		{
			// Token: 0x0400071E RID: 1822
			Exact,
			// Token: 0x0400071F RID: 1823
			Approximate
		}

		// Token: 0x0200010D RID: 269
		public class IWSglNMsKKXCXIszFMVrWJKGqpOx
		{
			// Token: 0x06000985 RID: 2437 RVA: 0x00044B0C File Offset: 0x00042D0C
			public bool vzWJCLlZkCBqQqjBsEGwXIzrGDCQ(fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.oVUyOLUvUEGkvZsIaWwEHqTEUPNh A_1, fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.rpNpYaCjKlVCOvvfPAnMzAQXjmSI.YiuxBCZaqVLXpOLWvdpUivYUZoEA A_2)
			{
				if (A_1.rewiredId == this.XcxSraXfSmQRFImnoeSHalROMYxFA)
				{
					return true;
				}
				if ((!string.IsNullOrEmpty(this.BnoOWZTykgMPHDcGzvadyNjDwBFp) || !string.IsNullOrEmpty(A_1.ZUFYTzmpbcggAOuQbfFkwUHyHMJr)) && !string.Equals(this.BnoOWZTykgMPHDcGzvadyNjDwBFp, A_1.ZUFYTzmpbcggAOuQbfFkwUHyHMJr, StringComparison.Ordinal))
				{
					return false;
				}
				if (A_2 == fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.rpNpYaCjKlVCOvvfPAnMzAQXjmSI.YiuxBCZaqVLXpOLWvdpUivYUZoEA.Exact)
				{
					return this.xlpjNHHukHnfxnJdSxWhtLKaWhcg == A_1.flUEPFupfmQaRTaHZWoKvobKcLTIA && this.fSdPjLrsvTHtVMqiXsVyOyDKIAzX == A_1.XGCDgTCPVxWwDfFjrWmblOLHFTcpA;
				}
				if (A_2 == fFtwXUyOtDAzCuDcEEFLaeTsVAeqA.rpNpYaCjKlVCOvvfPAnMzAQXjmSI.YiuxBCZaqVLXpOLWvdpUivYUZoEA.Approximate)
				{
					return this.fSdPjLrsvTHtVMqiXsVyOyDKIAzX == A_1.XGCDgTCPVxWwDfFjrWmblOLHFTcpA;
				}
				throw new NotImplementedException();
			}

			// Token: 0x04000720 RID: 1824
			public int XcxSraXfSmQRFImnoeSHalROMYxFA;

			// Token: 0x04000721 RID: 1825
			public int xlpjNHHukHnfxnJdSxWhtLKaWhcg;

			// Token: 0x04000722 RID: 1826
			public string fSdPjLrsvTHtVMqiXsVyOyDKIAzX;

			// Token: 0x04000723 RID: 1827
			public int gJFhsQdyboVOqqfnZrFFyjyGJcGT;

			// Token: 0x04000724 RID: 1828
			public string BnoOWZTykgMPHDcGzvadyNjDwBFp;
		}
	}
}
