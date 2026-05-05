using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Rewired;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Libraries.SharpDX.XInput;
using Rewired.Platforms;
using Rewired.Platforms.Windows.XInput;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

// Token: 0x0200002C RID: 44
internal class hSuFwhjVGbqfsiEcUujmPPhLicCV : PlatformInputManager, xKKbjmIOHiqxZGRJDfbeyLuvTjMwB
{
	// Token: 0x060001BA RID: 442 RVA: 0x00027428 File Offset: 0x00025628
	public hSuFwhjVGbqfsiEcUujmPPhLicCV(bool A_1, UpdateLoopSetting A_2, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> A_3, Func<int> A_4, Func<PidVid, bool> A_5)
	{
		this.PpxNrZtVmAheWafvaAfpBipppxROA = A_1;
		this.eBxVfGSdDhRwFOvmiOJOTbJKWOdr = A_2;
		this.fzeawVzDkgxyRlbqPhJfMIveSyaR = A_5;
		this.zELgzUgnqQNeZRazHRZOpLMyfEQVA = true;
		try
		{
			KLhrBPBxbDKejmHpuavTKkWlmsVC klhrBPBxbDKejmHpuavTKkWlmsVC;
			string str;
			int num;
			if (!OJvftpuwMnDnTESHlcnafrsMzwYhA.RUIlIFsVSuzCNEQGwHajgepbPmJC(out klhrBPBxbDKejmHpuavTKkWlmsVC, out str, out num))
			{
				throw new Exception("XInput is not available.");
			}
			if (klhrBPBxbDKejmHpuavTKkWlmsVC < KLhrBPBxbDKejmHpuavTKkWlmsVC.XINPUT_1_3)
			{
				Logger.LogWarning("The version of XInput (" + str + ") detected on your system is out of date. Please update to the latest version of XInput. Input will still function, but all features may not be available. See the documentation for required dependencies.");
			}
			this.HRJqhhxbtpCeUQNGmnazYcnPOgcr = A_3;
			this.yvzCqHtXjjiKKgagjqKEgVyoTKAn = A_4;
			this.AHiHTwrtKrvUxEdntUYdeuQYvHCU = (UnityTools.platform == Platform.WindowsAppStore);
			using (TempListPool.TList<UpdateLoopType> tlist = TempListPool.GetTList<UpdateLoopType>(3))
			{
				List<UpdateLoopType> list = tlist.list;
				EnumConverter.ToUpdateLoopTypes(this.eBxVfGSdDhRwFOvmiOJOTbJKWOdr, list);
				int num2 = 0;
				if (num2 < list.Count)
				{
					this.HQNUGAZlhYypmoVfiKVMIKPnRnuJ = list[num2];
				}
			}
			this.IuoLgPJsNqBENxERYFwRBfywiXdK = new UHsWCAvrjUBCvVSiOhWZLujgvmAM<bool>(true, new Func<bool>(this.PTsoQfCtOAHnBCIaYLQZHQstOjTEb));
			this.mcOneWxeeKtuRiMHObyFKnuvqIdh = new bool[4];
			this.uuEzNqAjWsvZpmACwqzormysadju = new bool[4];
			this.UdCGnyxCbhUoMrSPJOptfNKWimgt = new Action<int, ControllerDataUpdater>(this.UpdateControllerData);
			if (this.AHiHTwrtKrvUxEdntUYdeuQYvHCU)
			{
				this.dCXgOTObTCBmKSYwpLwbchDykjHj();
			}
		}
		catch (Exception)
		{
			this.OnDestroy();
			throw;
		}
	}

	// Token: 0x17000044 RID: 68
	// (get) Token: 0x060001BB RID: 443 RVA: 0x00027570 File Offset: 0x00025770
	[CustomObfuscation(rename = false)]
	public override int deviceCount
	{
		get
		{
			int num = 0;
			for (int i = 0; i < 4; i++)
			{
				if (this.DzSQtcBGJvFpubHqYhFuMSFWQkRzA[i].NLeokKSzJrbPFrhnuMGYihSTanrA)
				{
					num++;
				}
			}
			return num;
		}
	}

	// Token: 0x17000045 RID: 69
	// (get) Token: 0x060001BC RID: 444 RVA: 0x00012237 File Offset: 0x00010437
	[CustomObfuscation(rename = false)]
	public override PlatformInputManager primaryInputManager
	{
		get
		{
			return this;
		}
	}

	// Token: 0x17000046 RID: 70
	// (get) Token: 0x060001BD RID: 445 RVA: 0x000116EB File Offset: 0x0000F8EB
	[CustomObfuscation(rename = false)]
	public override IInputSource inputSource
	{
		get
		{
			return null;
		}
	}

	// Token: 0x17000047 RID: 71
	// (get) Token: 0x060001BE RID: 446 RVA: 0x00012219 File Offset: 0x00010419
	[CustomObfuscation(rename = false)]
	public override InputSource inputSourceType
	{
		get
		{
			return InputSource.XInput;
		}
	}

	// Token: 0x060001BF RID: 447 RVA: 0x000275A0 File Offset: 0x000257A0
	[CustomObfuscation(rename = false)]
	public override void Initialize()
	{
		if (this.zELgzUgnqQNeZRazHRZOpLMyfEQVA)
		{
			this.uIGFLBmhPOONemnzaOLBJRrRhPfM = new hSuFwhjVGbqfsiEcUujmPPhLicCV.SrIoKJIqquGPaPtBDxPDjLmTjtKL(1f);
		}
		this.IWRIWnzxlUsvsLsbLITcAnpkVVXf = new hSuFwhjVGbqfsiEcUujmPPhLicCV.elCGeuXtEuUoGTINMbEsOPGHbHYX();
		if (this.DzSQtcBGJvFpubHqYhFuMSFWQkRzA == null)
		{
			this.DzSQtcBGJvFpubHqYhFuMSFWQkRzA = new hSuFwhjVGbqfsiEcUujmPPhLicCV.oqVsrVdnkBMTAeByHxtbCRBSjQDU[4];
			for (int i = 0; i < 4; i++)
			{
				hSuFwhjVGbqfsiEcUujmPPhLicCV.wNQAbVkCRIcHkgopPRXXdCObRbvg wNQAbVkCRIcHkgopPRXXdCObRbvg = new hSuFwhjVGbqfsiEcUujmPPhLicCV.wNQAbVkCRIcHkgopPRXXdCObRbvg(i, this.eBxVfGSdDhRwFOvmiOJOTbJKWOdr);
				jbcfMDoFeBFAQElVePZhKkwUdctNA.ZDYmSbdCWXNMZFZsjWAgCzkVkDMh.ThreadUpdateEvent += wNQAbVkCRIcHkgopPRXXdCObRbvg.NPyuLuJCFSHAukaKWIuNgXTtatiPA;
				jbcfMDoFeBFAQElVePZhKkwUdctNA.EqGdpsfqHLTddwKzexbHrfPVtYZPA.ThreadUpdateEvent += wNQAbVkCRIcHkgopPRXXdCObRbvg.TOwGJfFWkjkrGCfcjvJccSXhKimCb;
				this.DzSQtcBGJvFpubHqYhFuMSFWQkRzA[i] = new hSuFwhjVGbqfsiEcUujmPPhLicCV.oqVsrVdnkBMTAeByHxtbCRBSjQDU(i, this.AHiHTwrtKrvUxEdntUYdeuQYvHCU, wNQAbVkCRIcHkgopPRXXdCObRbvg, this.HRJqhhxbtpCeUQNGmnazYcnPOgcr, new Action(this.SystemDeviceDisconnected));
			}
		}
		this.fPFOEbuyCLLKJNhlVtMDlnwujNPK(true);
		this.Update(UpdateLoopType.Update);
	}

	// Token: 0x060001C0 RID: 448 RVA: 0x00027660 File Offset: 0x00025860
	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType currentUpdateLoop)
	{
		this.EEBwobFCGJKAnSWXVimXRyjROxoC = currentUpdateLoop;
		this.aMfWGvinPtOmPQjqFsdjspjlaxvy();
		for (int i = 0; i < 4; i++)
		{
			if (this.DzSQtcBGJvFpubHqYhFuMSFWQkRzA[i] != null && this.DzSQtcBGJvFpubHqYhFuMSFWQkRzA[i].NLeokKSzJrbPFrhnuMGYihSTanrA)
			{
				this.DzSQtcBGJvFpubHqYhFuMSFWQkRzA[i].Update();
			}
		}
	}

	// Token: 0x060001C1 RID: 449 RVA: 0x000276AC File Offset: 0x000258AC
	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (this.IuoLgPJsNqBENxERYFwRBfywiXdK != null)
		{
			this.IuoLgPJsNqBENxERYFwRBfywiXdK.eJRoAWWYCTmYLtClrCmkPPBxhWgT();
		}
		if (this.DzSQtcBGJvFpubHqYhFuMSFWQkRzA != null)
		{
			for (int i = 0; i < 4; i++)
			{
				if (this.DzSQtcBGJvFpubHqYhFuMSFWQkRzA[i] != null)
				{
					if (jbcfMDoFeBFAQElVePZhKkwUdctNA.ZDYmSbdCWXNMZFZsjWAgCzkVkDMh != null)
					{
						jbcfMDoFeBFAQElVePZhKkwUdctNA.ZDYmSbdCWXNMZFZsjWAgCzkVkDMh.ThreadUpdateEvent -= this.DzSQtcBGJvFpubHqYhFuMSFWQkRzA[i].cRpbtIKkCAwmLwSSWoezVPkLkBCab.NPyuLuJCFSHAukaKWIuNgXTtatiPA;
					}
					if (jbcfMDoFeBFAQElVePZhKkwUdctNA.EqGdpsfqHLTddwKzexbHrfPVtYZPA != null)
					{
						jbcfMDoFeBFAQElVePZhKkwUdctNA.EqGdpsfqHLTddwKzexbHrfPVtYZPA.ThreadUpdateEvent -= this.DzSQtcBGJvFpubHqYhFuMSFWQkRzA[i].cRpbtIKkCAwmLwSSWoezVPkLkBCab.TOwGJfFWkjkrGCfcjvJccSXhKimCb;
					}
					this.DzSQtcBGJvFpubHqYhFuMSFWQkRzA[i].Dispose();
				}
			}
		}
		OJvftpuwMnDnTESHlcnafrsMzwYhA.EnQueYRSpCaukQIYSMgIXVIElMjq();
	}

	// Token: 0x060001C2 RID: 450 RVA: 0x0001223A File Offset: 0x0001043A
	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return this.UdCGnyxCbhUoMrSPJOptfNKWimgt;
	}

	// Token: 0x060001C3 RID: 451 RVA: 0x00012242 File Offset: 0x00010442
	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int assignedControllerId, ControllerDataUpdater data)
	{
		this.DzSQtcBGJvFpubHqYhFuMSFWQkRzA[assignedControllerId].FillData(data);
	}

	// Token: 0x060001C4 RID: 452 RVA: 0x00012252 File Offset: 0x00010452
	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		this.fPFOEbuyCLLKJNhlVtMDlnwujNPK(true);
		this.hCfIdedoyyIiMjVbPUFOsqGgkwvRA();
		if (this._SystemDeviceConnectedEvent != null)
		{
			this._SystemDeviceConnectedEvent();
		}
	}

	// Token: 0x060001C5 RID: 453 RVA: 0x00012274 File Offset: 0x00010474
	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		this.fPFOEbuyCLLKJNhlVtMDlnwujNPK(true);
		this.hCfIdedoyyIiMjVbPUFOsqGgkwvRA();
		if (this._SystemDeviceDisconnectedEvent != null)
		{
			this._SystemDeviceDisconnectedEvent();
		}
	}

	// Token: 0x060001C6 RID: 454 RVA: 0x000116E9 File Offset: 0x0000F8E9
	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
	}

	// Token: 0x060001C7 RID: 455 RVA: 0x000116EB File Offset: 0x0000F8EB
	[CustomObfuscation(rename = false)]
	public override IUnifiedMouseSource GetUnifiedMouseSource()
	{
		return null;
	}

	// Token: 0x060001C8 RID: 456 RVA: 0x000116EB File Offset: 0x0000F8EB
	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		return null;
	}

	// Token: 0x17000048 RID: 72
	// (get) Token: 0x060001C9 RID: 457 RVA: 0x0001164A File Offset: 0x0000F84A
	BEzoLQEyeVcMuWZsryGeXRQqhkdd xKKbjmIOHiqxZGRJDfbeyLuvTjMwB.XvqNwgMOXksxjqDAiGvWVgpbHnoR
	{
		get
		{
			return BEzoLQEyeVcMuWZsryGeXRQqhkdd.XInput;
		}
	}

	// Token: 0x060001CA RID: 458 RVA: 0x00012296 File Offset: 0x00010496
	bool xKKbjmIOHiqxZGRJDfbeyLuvTjMwB.MT_HandlesController(string devicePath, string productName, string bluetoothName, PidVid pidVid)
	{
		return !this.fzeawVzDkgxyRlbqPhJfMIveSyaR(pidVid) && hSuFwhjVGbqfsiEcUujmPPhLicCV.vDpAPacjxaQHBggYcPjoqLUETxki(devicePath, productName, bluetoothName, MiscTools.CreateHIDProductGuid((int)pidVid.vendorId, (int)pidVid.productId));
	}

	// Token: 0x060001CB RID: 459 RVA: 0x000122C4 File Offset: 0x000104C4
	private bool BTXjaLlAXXSQrIGMSBUfHCixmiDjA()
	{
		if (this.EEBwobFCGJKAnSWXVimXRyjROxoC != this.HQNUGAZlhYypmoVfiKVMIKPnRnuJ)
		{
			return false;
		}
		bool flag = this.uIGFLBmhPOONemnzaOLBJRrRhPfM.uEQSqbVCDLUcYwZKxrfNvppNGuriA();
		if (flag)
		{
			this.fPFOEbuyCLLKJNhlVtMDlnwujNPK(true);
		}
		return flag;
	}

	// Token: 0x060001CC RID: 460 RVA: 0x000122EB File Offset: 0x000104EB
	private void fPFOEbuyCLLKJNhlVtMDlnwujNPK(bool A_1)
	{
		this.QCjYUvwketozzfaZHrmMnJwdvihQ = A_1;
		if (this.zELgzUgnqQNeZRazHRZOpLMyfEQVA)
		{
			this.uIGFLBmhPOONemnzaOLBJRrRhPfM.NUggdKtmmkHlqWLJhqDYzJCpgjRo();
		}
	}

	// Token: 0x060001CD RID: 461 RVA: 0x00012307 File Offset: 0x00010507
	private void hCfIdedoyyIiMjVbPUFOsqGgkwvRA()
	{
		if (this.IuoLgPJsNqBENxERYFwRBfywiXdK != null)
		{
			this.IuoLgPJsNqBENxERYFwRBfywiXdK.pHkBJvOWTdCtPUpRPohpUtkRjYrN();
		}
	}

	// Token: 0x060001CE RID: 462 RVA: 0x0001231C File Offset: 0x0001051C
	private void dCXgOTObTCBmKSYwpLwbchDykjHj()
	{
		new zmDlVAYpiICKEnvrtEDAeKCAYFkVA(BuNqfCrdVwfxylZCOMsUJLlUODmX.Any).LVxgaRzwsbUiJQpVodnOGQYqJQAJ;
	}

	// Token: 0x060001CF RID: 463 RVA: 0x00027750 File Offset: 0x00025950
	private void aMfWGvinPtOmPQjqFsdjspjlaxvy()
	{
		bool flag = false;
		if (this.zELgzUgnqQNeZRazHRZOpLMyfEQVA)
		{
			flag = this.BTXjaLlAXXSQrIGMSBUfHCixmiDjA();
		}
		if (!flag && this.QCjYUvwketozzfaZHrmMnJwdvihQ)
		{
			this.afbJJlnDKZFthioMUWXNlQgIbuWu(this.igEoTcjjorCbOtIFGZzTieGwTdoI());
			this.fPFOEbuyCLLKJNhlVtMDlnwujNPK(false);
			this.hCfIdedoyyIiMjVbPUFOsqGgkwvRA();
			return;
		}
		if (this.QCjYUvwketozzfaZHrmMnJwdvihQ)
		{
			this.XMQlVrsXbKLHLpFJqXHFpNCOEvHI();
		}
		if (this.IuoLgPJsNqBENxERYFwRBfywiXdK.dEuWrWEuMuRLEfvelqBlJqCXPzLm && this.IuoLgPJsNqBENxERYFwRBfywiXdK.tyWUOmZxIPUWAGNTSMzHnebuMTZT())
		{
			this.BWcSZkJbFaCeOQaRhWxJmEerFaNC();
		}
	}

	// Token: 0x060001D0 RID: 464 RVA: 0x0001232E File Offset: 0x0001052E
	private void XMQlVrsXbKLHLpFJqXHFpNCOEvHI()
	{
		this.QCjYUvwketozzfaZHrmMnJwdvihQ = false;
		if (this.IuoLgPJsNqBENxERYFwRBfywiXdK.dEuWrWEuMuRLEfvelqBlJqCXPzLm)
		{
			return;
		}
		this.IuoLgPJsNqBENxERYFwRBfywiXdK.VlWTpnOmouJNHovmWjtCiEYLYIbj();
	}

	// Token: 0x060001D1 RID: 465 RVA: 0x000277C4 File Offset: 0x000259C4
	private void BWcSZkJbFaCeOQaRhWxJmEerFaNC()
	{
		bool[] obj = this.mcOneWxeeKtuRiMHObyFKnuvqIdh;
		lock (obj)
		{
			Array.Copy(this.mcOneWxeeKtuRiMHObyFKnuvqIdh, this.uuEzNqAjWsvZpmACwqzormysadju, 4);
		}
		this.afbJJlnDKZFthioMUWXNlQgIbuWu(this.uuEzNqAjWsvZpmACwqzormysadju);
	}

	// Token: 0x060001D2 RID: 466 RVA: 0x0002781C File Offset: 0x00025A1C
	private bool PTsoQfCtOAHnBCIaYLQZHQstOjTEb()
	{
		bool[] obj = this.mcOneWxeeKtuRiMHObyFKnuvqIdh;
		lock (obj)
		{
			for (int i = 0; i < 4; i++)
			{
				if (this.DzSQtcBGJvFpubHqYhFuMSFWQkRzA[i] != null)
				{
					this.mcOneWxeeKtuRiMHObyFKnuvqIdh[i] = this.DzSQtcBGJvFpubHqYhFuMSFWQkRzA[i].ibLdsacJCQmAnMrEfFeXvnvlXCxUA(hSuFwhjVGbqfsiEcUujmPPhLicCV.jJBXEoZkAKXDTtNyqJfJoCFZbYrA.Synchronous);
				}
			}
		}
		return true;
	}

	// Token: 0x060001D3 RID: 467 RVA: 0x00027884 File Offset: 0x00025A84
	private bool[] igEoTcjjorCbOtIFGZzTieGwTdoI()
	{
		for (int i = 0; i < 4; i++)
		{
			this.uuEzNqAjWsvZpmACwqzormysadju[i] = this.DzSQtcBGJvFpubHqYhFuMSFWQkRzA[i].ibLdsacJCQmAnMrEfFeXvnvlXCxUA(hSuFwhjVGbqfsiEcUujmPPhLicCV.jJBXEoZkAKXDTtNyqJfJoCFZbYrA.Synchronous);
		}
		return this.uuEzNqAjWsvZpmACwqzormysadju;
	}

	// Token: 0x060001D4 RID: 468 RVA: 0x000278BC File Offset: 0x00025ABC
	private void afbJJlnDKZFthioMUWXNlQgIbuWu(bool[] A_1)
	{
		int num = 0;
		for (int i = 0; i < 4; i++)
		{
			if (this.DzSQtcBGJvFpubHqYhFuMSFWQkRzA[i] != null && this.DzSQtcBGJvFpubHqYhFuMSFWQkRzA[i].sHfXVWGYdCnMZePXaBuAdFeJsHOh)
			{
				bool flag = A_1[i];
				this.DzSQtcBGJvFpubHqYhFuMSFWQkRzA[i].kLAyQTVMarCICDETjTlXNCyDcmbU(flag);
				if (!flag)
				{
					this.QHNVhxyjrYneQbRPoNZDbMahVlwi(this.DzSQtcBGJvFpubHqYhFuMSFWQkRzA[i], false);
				}
			}
		}
		for (int j = 0; j < 4; j++)
		{
			if (this.DzSQtcBGJvFpubHqYhFuMSFWQkRzA[j] != null && !this.DzSQtcBGJvFpubHqYhFuMSFWQkRzA[j].sHfXVWGYdCnMZePXaBuAdFeJsHOh)
			{
				bool flag2 = A_1[j];
				this.DzSQtcBGJvFpubHqYhFuMSFWQkRzA[j].kLAyQTVMarCICDETjTlXNCyDcmbU(flag2);
				if (flag2 && !this.QHNVhxyjrYneQbRPoNZDbMahVlwi(this.DzSQtcBGJvFpubHqYhFuMSFWQkRzA[j], true))
				{
					num |= ((j == 0) ? 1 : (1 << j));
				}
			}
		}
		for (int k = 0; k < 4; k++)
		{
			if (this.DzSQtcBGJvFpubHqYhFuMSFWQkRzA[k] != null)
			{
				int num2 = (k == 0) ? 1 : (1 << k);
				if ((num & num2) != 1 << k)
				{
					this.DzSQtcBGJvFpubHqYhFuMSFWQkRzA[k].kjXOpNibcTEcHkdbJMIxecYnkmjGb(A_1[k]);
				}
			}
		}
	}

	// Token: 0x060001D5 RID: 469 RVA: 0x000279BC File Offset: 0x00025BBC
	private bool QHNVhxyjrYneQbRPoNZDbMahVlwi(hSuFwhjVGbqfsiEcUujmPPhLicCV.oqVsrVdnkBMTAeByHxtbCRBSjQDU A_1, bool A_2)
	{
		if (A_2)
		{
			A_1.pACJgxweNOfIidfHWfylVzcxVGCh();
			if (!A_1.kHhihlKJapsvCYhkQFtywTaFQegR)
			{
				return false;
			}
			int num = this.IWRIWnzxlUsvsLsbLITcAnpkVVXf.gdliFwnvfbEMbFHxlxdXlORULsXS(A_1.DhGHHanjxlOzCROeZTyewOdlamjH, false);
			if (num >= 0)
			{
				A_1.rewiredId = this.IWRIWnzxlUsvsLsbLITcAnpkVVXf.mmGCTFwfFzmtzfDPaQMrchVwSEzI(num);
				this.IWRIWnzxlUsvsLsbLITcAnpkVVXf.WlwAKyjYSbNjHLzimIjFeUEVDInhA(num, A_1, true);
			}
			else
			{
				A_1.rewiredId = this.yvzCqHtXjjiKKgagjqKEgVyoTKAn();
				this.IWRIWnzxlUsvsLsbLITcAnpkVVXf.RSVkZQOXhMQSfsOHRbNfHMnNJHQdA(A_1, true);
			}
			if (this._UpdateControllerInfoEvent != null)
			{
				this._UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(A_1));
			}
			BridgedController obj = A_1.ToBridgedController();
			if (this._DeviceConnectedEvent != null)
			{
				this._DeviceConnectedEvent(obj);
			}
		}
		else
		{
			int num2 = this.IWRIWnzxlUsvsLsbLITcAnpkVVXf.vIERyleYTFDKDOGNsTiAgNCNWoYP(A_1.rewiredId, A_1.DhGHHanjxlOzCROeZTyewOdlamjH, true);
			if (num2 >= 0)
			{
				this.IWRIWnzxlUsvsLsbLITcAnpkVVXf.fblezJTTQqHemxqbEGMiGFnvKzqf(num2, false);
			}
			ControllerDisconnectedEventArgs obj2 = A_1.ToControllerDisconnectedEventArgs();
			A_1.iaarRgfkJDMDUudNEmKAJjJShdOf();
			if (this._DeviceDisconnectedEvent != null)
			{
				this._DeviceDisconnectedEvent(obj2);
			}
		}
		return true;
	}

	// Token: 0x060001D7 RID: 471 RVA: 0x00027B18 File Offset: 0x00025D18
	public static bool vDpAPacjxaQHBggYcPjoqLUETxki(string A_0, string A_1, string A_2, Guid A_3)
	{
		if (ArrayTools.Contains<Guid>(hSuFwhjVGbqfsiEcUujmPPhLicCV.vZmCfzkFcpOtkxkMNIwTVJcKFJzAA, A_3))
		{
			return true;
		}
		if (!string.IsNullOrEmpty(A_1))
		{
			for (int i = 0; i < hSuFwhjVGbqfsiEcUujmPPhLicCV.bAQiTCMHnUIQEbDWGPFNthJDMowIb.Length; i++)
			{
				if (A_1.Equals(hSuFwhjVGbqfsiEcUujmPPhLicCV.bAQiTCMHnUIQEbDWGPFNthJDMowIb[i], StringComparison.OrdinalIgnoreCase))
				{
					return true;
				}
			}
		}
		if (!string.IsNullOrEmpty(A_2))
		{
			for (int j = 0; j < hSuFwhjVGbqfsiEcUujmPPhLicCV.eltSRnsHOfEbPUSbvstHxNRREHlj.Length; j++)
			{
				if (Regex.IsMatch(A_2, hSuFwhjVGbqfsiEcUujmPPhLicCV.eltSRnsHOfEbPUSbvstHxNRREHlj[j], RegexOptions.IgnoreCase))
				{
					return true;
				}
			}
		}
		A_0 = A_0.ToLower();
		int num = A_0.IndexOf("vid_");
		return num >= 0 && A_0.IndexOf("ig_") >= num;
	}

	// Token: 0x0400015C RID: 348
	public const int kdvrDLdHWMiBzgNrCbYxapEEtiYp = 4;

	// Token: 0x0400015D RID: 349
	public const int YFxoGWpAkZAaibmAuadqdqVhkHdVb = 32768;

	// Token: 0x0400015E RID: 350
	public const int QjZAgkcmNelPgrDjgmZTRLLyJTpn = -32768;

	// Token: 0x0400015F RID: 351
	public const int PipBfUKbRLVvArmWGpKLjfBDRRCSA = 255;

	// Token: 0x04000160 RID: 352
	public const int kDUISskihCOBTfKFdvoEAkadLckcE = 0;

	// Token: 0x04000161 RID: 353
	public const int TlMeExMpCLUKvxPwbTcQrrqBnsOK = 18;

	// Token: 0x04000162 RID: 354
	public const int CWxZrZyVlhZvoErYvexMKovAXLoj = 14;

	// Token: 0x04000163 RID: 355
	public const int NykYjKAJokTDqUyKuYrrTvmwecdE = 6;

	// Token: 0x04000164 RID: 356
	public const int gHXmXgkNyqBNBkOpVVIBeSVRaDUfA = 15;

	// Token: 0x04000165 RID: 357
	private hSuFwhjVGbqfsiEcUujmPPhLicCV.oqVsrVdnkBMTAeByHxtbCRBSjQDU[] DzSQtcBGJvFpubHqYhFuMSFWQkRzA;

	// Token: 0x04000166 RID: 358
	private bool QCjYUvwketozzfaZHrmMnJwdvihQ;

	// Token: 0x04000167 RID: 359
	private hSuFwhjVGbqfsiEcUujmPPhLicCV.SrIoKJIqquGPaPtBDxPDjLmTjtKL uIGFLBmhPOONemnzaOLBJRrRhPfM;

	// Token: 0x04000168 RID: 360
	private hSuFwhjVGbqfsiEcUujmPPhLicCV.elCGeuXtEuUoGTINMbEsOPGHbHYX IWRIWnzxlUsvsLsbLITcAnpkVVXf;

	// Token: 0x04000169 RID: 361
	private UHsWCAvrjUBCvVSiOhWZLujgvmAM<bool> IuoLgPJsNqBENxERYFwRBfywiXdK;

	// Token: 0x0400016A RID: 362
	private bool[] mcOneWxeeKtuRiMHObyFKnuvqIdh;

	// Token: 0x0400016B RID: 363
	private bool[] uuEzNqAjWsvZpmACwqzormysadju;

	// Token: 0x0400016C RID: 364
	private bool AHiHTwrtKrvUxEdntUYdeuQYvHCU;

	// Token: 0x0400016D RID: 365
	private readonly bool PpxNrZtVmAheWafvaAfpBipppxROA;

	// Token: 0x0400016E RID: 366
	private readonly UpdateLoopSetting eBxVfGSdDhRwFOvmiOJOTbJKWOdr;

	// Token: 0x0400016F RID: 367
	private UpdateLoopType EEBwobFCGJKAnSWXVimXRyjROxoC;

	// Token: 0x04000170 RID: 368
	private UpdateLoopType HQNUGAZlhYypmoVfiKVMIKPnRnuJ;

	// Token: 0x04000171 RID: 369
	private Action<int, ControllerDataUpdater> UdCGnyxCbhUoMrSPJOptfNKWimgt;

	// Token: 0x04000172 RID: 370
	private bool zELgzUgnqQNeZRazHRZOpLMyfEQVA;

	// Token: 0x04000173 RID: 371
	private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> HRJqhhxbtpCeUQNGmnazYcnPOgcr;

	// Token: 0x04000174 RID: 372
	private Func<int> yvzCqHtXjjiKKgagjqKEgVyoTKAn;

	// Token: 0x04000175 RID: 373
	private Func<PidVid, bool> fzeawVzDkgxyRlbqPhJfMIveSyaR;

	// Token: 0x04000176 RID: 374
	private static Guid[] vZmCfzkFcpOtkxkMNIwTVJcKFJzAA = new Guid[]
	{
		new Guid("72100955-0000-0000-0000-504944564944"),
		new Guid("02e0045e-0000-0000-0000-504944564944")
	};

	// Token: 0x04000177 RID: 375
	private static string[] bAQiTCMHnUIQEbDWGPFNthJDMowIb = new string[]
	{
		"Xbox Bluetooth Gamepad"
	};

	// Token: 0x04000178 RID: 376
	private static string[] eltSRnsHOfEbPUSbvstHxNRREHlj = new string[]
	{
		"Xbox Wireless Controller.*"
	};

	// Token: 0x0200002D RID: 45
	private class oqVsrVdnkBMTAeByHxtbCRBSjQDU : IInputManagerJoystick, IInputManagerJoystickPublic, ITryGetLocalizedName, IDisposable
	{
		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060001D8 RID: 472 RVA: 0x00027BB8 File Offset: 0x00025DB8
		public string kJncpphGLFDBMOngVeZENkJlcmEz
		{
			get
			{
				string text = this.YguMbBmrBstFJiLItJCTLufnFqGl;
				if (text == string.Empty)
				{
					return string.Empty;
				}
				return text + " " + this.vyHvlIbCuCCztihHzTUZfdEjsJqUA.ToString();
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060001D9 RID: 473 RVA: 0x00012351 File Offset: 0x00010551
		public string YguMbBmrBstFJiLItJCTLufnFqGl
		{
			get
			{
				if (!this.NLeokKSzJrbPFrhnuMGYihSTanrA)
				{
					return string.Empty;
				}
				return this.DhGHHanjxlOzCROeZTyewOdlamjH.ToString();
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060001DA RID: 474 RVA: 0x00012372 File Offset: 0x00010572
		public bool NLeokKSzJrbPFrhnuMGYihSTanrA
		{
			get
			{
				if (this.cRpbtIKkCAwmLwSSWoezVPkLkBCab == null || !this.kHhihlKJapsvCYhkQFtywTaFQegR)
				{
					return false;
				}
				if (this.EsPAExwvErbgxoxFcplkBeDycLWi && !this.yslgUhbLwsrxbMKRJbBSXHRHZHZI(hSuFwhjVGbqfsiEcUujmPPhLicCV.jJBXEoZkAKXDTtNyqJfJoCFZbYrA.Asynchronous))
				{
					this.HyROmekkcqBdPueLxYBfTlTRRruL();
				}
				return this.EsPAExwvErbgxoxFcplkBeDycLWi;
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060001DB RID: 475 RVA: 0x000123A3 File Offset: 0x000105A3
		// (set) Token: 0x060001DC RID: 476 RVA: 0x000123AB File Offset: 0x000105AB
		[CustomObfuscation(rename = false)]
		public int rewiredId
		{
			get
			{
				return this.YZSVRbuHvYbNDKcIJZFnzkyqfQsL;
			}
			set
			{
				this.YZSVRbuHvYbNDKcIJZFnzkyqfQsL = value;
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060001DD RID: 477 RVA: 0x000123B4 File Offset: 0x000105B4
		[CustomObfuscation(rename = false)]
		public int inputManagerId
		{
			get
			{
				return this.vyHvlIbCuCCztihHzTUZfdEjsJqUA;
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060001DE RID: 478 RVA: 0x000123BC File Offset: 0x000105BC
		[CustomObfuscation(rename = false)]
		public string name
		{
			get
			{
				return this.dyahjtcZMRsCjPWwPjjmEcDKtfXhA;
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060001DF RID: 479 RVA: 0x000123C4 File Offset: 0x000105C4
		[CustomObfuscation(rename = false)]
		public long? systemId
		{
			get
			{
				return new long?((long)this.vyHvlIbCuCCztihHzTUZfdEjsJqUA);
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060001E0 RID: 480 RVA: 0x00011826 File Offset: 0x0000FA26
		[CustomObfuscation(rename = false)]
		public int unityId
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060001E1 RID: 481 RVA: 0x000123D2 File Offset: 0x000105D2
		[CustomObfuscation(rename = false)]
		public Controller.Extension extension
		{
			get
			{
				if (this.cRpbtIKkCAwmLwSSWoezVPkLkBCab == null)
				{
					return null;
				}
				return this.cRpbtIKkCAwmLwSSWoezVPkLkBCab.bBtvKUuAcalBBzkJZgdArcFBLmso;
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060001E2 RID: 482 RVA: 0x000123E9 File Offset: 0x000105E9
		[CustomObfuscation(rename = false)]
		public Guid instanceGuid
		{
			get
			{
				return this.bLmyHbRcHvtiBHHqCrcOSggoCzCbA;
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060001E3 RID: 483 RVA: 0x000123F1 File Offset: 0x000105F1
		[CustomObfuscation(rename = false)]
		public Guid persistentGuid
		{
			get
			{
				return this.instanceGuid;
			}
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x000123F9 File Offset: 0x000105F9
		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
			this.cRpbtIKkCAwmLwSSWoezVPkLkBCab.VOUBzRMsjdjdjBrKXAqYriccsSGB(amount, motorIndex);
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x00012408 File Offset: 0x00010608
		[CustomObfuscation(rename = false)]
		public void StopVibration()
		{
			this.cRpbtIKkCAwmLwSSWoezVPkLkBCab.NaydyKbUkMRbqxKALptfLJVQgMpaA();
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x00027BF8 File Offset: 0x00025DF8
		bool ITryGetLocalizedName.TryGetLocalizedName(out string value)
		{
			if ((LocalizationManager.GetAndUpdateLocalizedString(this.zNXdfNLnZeVTfrDlJGJzGVGwTerIA, this.SnTnfXKEfCeMuZhpgBnVufDxTPzk.deviceLocalizationInfo.parentKeys, "controller", this.bVTBwzStIJPOPNeSMyCwioDaAhVgA, out value) & LocalizationManager.GetAndUpdateLocalizedStringResultFlags.Changed) != LocalizationManager.GetAndUpdateLocalizedStringResultFlags.None)
			{
				value = string.Format("{0} {1}", value, (this.vyHvlIbCuCCztihHzTUZfdEjsJqUA + 1).ToString());
				this.zNXdfNLnZeVTfrDlJGJzGVGwTerIA.cachedValue = value;
			}
			return true;
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x00027C5C File Offset: 0x00025E5C
		public oqVsrVdnkBMTAeByHxtbCRBSjQDU(int A_1, bool A_2, hSuFwhjVGbqfsiEcUujmPPhLicCV.wNQAbVkCRIcHkgopPRXXdCObRbvg A_3, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> A_4, Action A_5)
		{
			this.cRpbtIKkCAwmLwSSWoezVPkLkBCab = A_3;
			this.dXnGtSIHUMOTGjSdFLgcalTgwniCB = A_2;
			this.vyHvlIbCuCCztihHzTUZfdEjsJqUA = A_1;
			this.HUZRtMVIcdMUKSqcRmleviFgTgjQ = A_4;
			this.cVcJjuZeWCzRDsLTokAPBreuuaZt = A_5;
			this.YZSVRbuHvYbNDKcIJZFnzkyqfQsL = -1;
			this.TPVRdisIMNTDckkkWKYlESLXiRBv = 6;
			this.OscypnCEQfCmGVjpXRAqLDkhAYXP = 15;
			this.bEwPoamyVeieOTgHRkgPETTkwAFd = this.TPVRdisIMNTDckkkWKYlESLXiRBv;
			this.udweeNZaMBfOenzoWvVDOJVFdszDA = this.OscypnCEQfCmGVjpXRAqLDkhAYXP;
			this.kNsNjNKeApJMHiLerczBiWuglhtG = new float[this.TPVRdisIMNTDckkkWKYlESLXiRBv];
			this.akSaZcozMebGDNduNEaaJKdNrqdq = new bool[this.OscypnCEQfCmGVjpXRAqLDkhAYXP];
			this.zNXdfNLnZeVTfrDlJGJzGVGwTerIA = new LocalizedString();
			this.xnBRzVhUvObYOHzBTqtkjZdICKhp();
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x00027CF8 File Offset: 0x00025EF8
		[CustomObfuscation(rename = false)]
		public void Update()
		{
			this.cRpbtIKkCAwmLwSSWoezVPkLkBCab.CdaocvrLOAQhFXUhQxzbYTdPjGAG();
			bool[] array = this.cRpbtIKkCAwmLwSSWoezVPkLkBCab.wgDTYEXqAoIVBQrYpVqeLSEIjdrBA;
			this.bJGOACXAXPIQfDGIDCqazcxavhTE(array, ref this.cRpbtIKkCAwmLwSSWoezVPkLkBCab.oAnHbndTQTeuHDDvvRjesvJVrtVuA);
			this.HvfgHbBPTqaCkmWldThIYOfyPAWx(array, ref this.cRpbtIKkCAwmLwSSWoezVPkLkBCab.oAnHbndTQTeuHDDvvRjesvJVrtVuA);
			this.cRpbtIKkCAwmLwSSWoezVPkLkBCab.hGhEieAGYfqwZsqnuvpBpWIunjbkA();
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x00012415 File Offset: 0x00010615
		public void kjXOpNibcTEcHkdbJMIxecYnkmjGb(bool A_1)
		{
			if (this.cRpbtIKkCAwmLwSSWoezVPkLkBCab == null)
			{
				return;
			}
			this.sHfXVWGYdCnMZePXaBuAdFeJsHOh = A_1;
		}

		// Token: 0x060001EA RID: 490 RVA: 0x00012427 File Offset: 0x00010627
		public bool yslgUhbLwsrxbMKRJbBSXHRHZHZI(hSuFwhjVGbqfsiEcUujmPPhLicCV.jJBXEoZkAKXDTtNyqJfJoCFZbYrA A_1)
		{
			this.kLAyQTVMarCICDETjTlXNCyDcmbU(this.ibLdsacJCQmAnMrEfFeXvnvlXCxUA(A_1));
			return this.EsPAExwvErbgxoxFcplkBeDycLWi;
		}

		// Token: 0x060001EB RID: 491 RVA: 0x0001243C File Offset: 0x0001063C
		public bool ibLdsacJCQmAnMrEfFeXvnvlXCxUA(hSuFwhjVGbqfsiEcUujmPPhLicCV.jJBXEoZkAKXDTtNyqJfJoCFZbYrA A_1)
		{
			return this.cRpbtIKkCAwmLwSSWoezVPkLkBCab != null && this.cRpbtIKkCAwmLwSSWoezVPkLkBCab.bKPZiUErKXdPUPyKSODUhkkSOQLl(A_1);
		}

		// Token: 0x060001EC RID: 492 RVA: 0x00012454 File Offset: 0x00010654
		public void kLAyQTVMarCICDETjTlXNCyDcmbU(bool A_1)
		{
			this.EsPAExwvErbgxoxFcplkBeDycLWi = A_1;
		}

		// Token: 0x060001ED RID: 493 RVA: 0x0001245D File Offset: 0x0001065D
		public void pACJgxweNOfIidfHWfylVzcxVGCh()
		{
			if (!this.kHhihlKJapsvCYhkQFtywTaFQegR || this.KPmFYsPidfHaTByDvdtxnAlBQEve())
			{
				this.xnBRzVhUvObYOHzBTqtkjZdICKhp();
			}
			if (this.kHhihlKJapsvCYhkQFtywTaFQegR && this.EsPAExwvErbgxoxFcplkBeDycLWi)
			{
				this.cRpbtIKkCAwmLwSSWoezVPkLkBCab.EiImUypmGvHiXSsgmgcqKvaGMWgeA();
			}
		}

		// Token: 0x060001EE RID: 494 RVA: 0x00027D4C File Offset: 0x00025F4C
		public void iaarRgfkJDMDUudNEmKAJjJShdOf()
		{
			this.YZSVRbuHvYbNDKcIJZFnzkyqfQsL = -1;
			this.kHhihlKJapsvCYhkQFtywTaFQegR = false;
			this.cRpbtIKkCAwmLwSSWoezVPkLkBCab.qfvLPOLoPDpzgCQyfqHOwsucnvjI();
			Array.Clear(this.kNsNjNKeApJMHiLerczBiWuglhtG, 0, this.kNsNjNKeApJMHiLerczBiWuglhtG.Length);
			Array.Clear(this.akSaZcozMebGDNduNEaaJKdNrqdq, 0, this.akSaZcozMebGDNduNEaaJKdNrqdq.Length);
		}

		// Token: 0x060001EF RID: 495 RVA: 0x00027D9C File Offset: 0x00025F9C
		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (this.TPVRdisIMNTDckkkWKYlESLXiRBv != dataUpdater.axisCount || this.OscypnCEQfCmGVjpXRAqLDkhAYXP != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			for (int i = 0; i < this.TPVRdisIMNTDckkkWKYlESLXiRBv; i++)
			{
				dataUpdater.axisValues[i] = this.kNsNjNKeApJMHiLerczBiWuglhtG[i];
			}
			for (int j = 0; j < this.OscypnCEQfCmGVjpXRAqLDkhAYXP; j++)
			{
				dataUpdater.buttonValues[j] = this.akSaZcozMebGDNduNEaaJKdNrqdq[j];
			}
			if (this.AzMGDwvFiTlatmSqFjSyDfBmciuj && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		// Token: 0x060001F0 RID: 496 RVA: 0x00027E2C File Offset: 0x0002602C
		public BridgedControllerHWInfo yoSKPlymsEoDgkugbWQDnMyFrqMT()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			this.aasaEYTrKVVfTSjPYyVvgDaeQzZh(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		// Token: 0x060001F1 RID: 497 RVA: 0x00027E48 File Offset: 0x00026048
		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			this.RLYBefnopzcCFFmAdrpDRgAoDJYD(bridgedController);
			return bridgedController;
		}

		// Token: 0x060001F2 RID: 498 RVA: 0x00012490 File Offset: 0x00010690
		[CustomObfuscation(rename = false)]
		public ControllerDisconnectedEventArgs ToControllerDisconnectedEventArgs()
		{
			return new ControllerDisconnectedEventArgs(this.YZSVRbuHvYbNDKcIJZFnzkyqfQsL);
		}

		// Token: 0x060001F3 RID: 499 RVA: 0x00027E64 File Offset: 0x00026064
		private void xnBRzVhUvObYOHzBTqtkjZdICKhp()
		{
			if (this.cRpbtIKkCAwmLwSSWoezVPkLkBCab == null || !this.yslgUhbLwsrxbMKRJbBSXHRHZHZI(hSuFwhjVGbqfsiEcUujmPPhLicCV.jJBXEoZkAKXDTtNyqJfJoCFZbYrA.Synchronous))
			{
				return;
			}
			try
			{
				this.bEuYfdpOfkRJkogSDZwCjTxinPCf();
				CELrFAGlKnsjCYGBIIoGyEZcuGQi celrFAGlKnsjCYGBIIoGyEZcuGQi = this.cRpbtIKkCAwmLwSSWoezVPkLkBCab.YxhefCmxGIggoAMJkVFwlzXoLwY.MjDMbyQxLIUFNivnHlplKGAZSWbw(xWqjpLrDBXUZxgRusGkFwZRUWwEG.Any);
				this.cdjtvkqVkQUCBzHPhxuWnqEVHSCb = celrFAGlKnsjCYGBIIoGyEZcuGQi.xWAfJVwpvjMYHgMaDoEJksafFIer;
				this.DhGHHanjxlOzCROeZTyewOdlamjH = (XInputDeviceSubType)celrFAGlKnsjCYGBIIoGyEZcuGQi.ENpAZfUaqGHRZKihIEaRfWaZRSnp;
				ANKpkQVdjjJBZtpJglzmnbRRvFWL ankpkQVdjjJBZtpJglzmnbRRvFWL = default(ANKpkQVdjjJBZtpJglzmnbRRvFWL);
				if (this.cRpbtIKkCAwmLwSSWoezVPkLkBCab.YxhefCmxGIggoAMJkVFwlzXoLwY.IRjRVeCDdBiRFGbDNaXpxXUaPbZJA(ankpkQVdjjJBZtpJglzmnbRRvFWL).cmAlJDmWlhNROcQBSPrfMjLoBaAg)
				{
					this.koEfHLkMOEdTQUORYwqJhsMQIrIZ = true;
				}
				this.dWwEYYhJxvrSpTVBzoiFGoPCnypeb = ((celrFAGlKnsjCYGBIIoGyEZcuGQi.NIqRznhcdiWdhLTtdGNfYYyDyJdK & kwEmrfRIArfYHQSCoEsbGnofSwNy.VoiceSupported) == kwEmrfRIArfYHQSCoEsbGnofSwNy.VoiceSupported);
				this.LZrUiAdQalHJsmuWzssmXPQsJrpx();
				this.iVzSGJtiASOgkNDQTBrRtwMHyHdV = this.SnTnfXKEfCeMuZhpgBnVufDxTPzk.hardwareMapIdentifier.guid;
				if (this.dXnGtSIHUMOTGjSdFLgcalTgwniCB)
				{
					this.bVTBwzStIJPOPNeSMyCwioDaAhVgA = StringTools.AddSpacesToCamelCase(this.DhGHHanjxlOzCROeZTyewOdlamjH.ToString());
				}
				else
				{
					this.bVTBwzStIJPOPNeSMyCwioDaAhVgA = "XInput " + this.DhGHHanjxlOzCROeZTyewOdlamjH.ToString();
				}
				this.dyahjtcZMRsCjPWwPjjmEcDKtfXhA = string.Format("{0} {1}", this.bVTBwzStIJPOPNeSMyCwioDaAhVgA, (this.vyHvlIbCuCCztihHzTUZfdEjsJqUA + 1).ToString());
				string additionalIdentifyingInformation = LocalizationManager.FormatKey(this.DhGHHanjxlOzCROeZTyewOdlamjH.ToString());
				this.SnTnfXKEfCeMuZhpgBnVufDxTPzk.deviceLocalizationInfo.additionalIdentifyingInformation = additionalIdentifyingInformation;
				this.zNXdfNLnZeVTfrDlJGJzGVGwTerIA.Clear();
				this.cRpbtIKkCAwmLwSSWoezVPkLkBCab.EiImUypmGvHiXSsgmgcqKvaGMWgeA();
				this.bLmyHbRcHvtiBHHqCrcOSggoCzCbA = MiscTools.CreateGuidHashSHA1(this.cdjtvkqVkQUCBzHPhxuWnqEVHSCb + this.DhGHHanjxlOzCROeZTyewOdlamjH + this.vyHvlIbCuCCztihHzTUZfdEjsJqUA);
				this.kHhihlKJapsvCYhkQFtywTaFQegR = true;
			}
			catch (Exception)
			{
				this.kHhihlKJapsvCYhkQFtywTaFQegR = false;
				this.EsPAExwvErbgxoxFcplkBeDycLWi = false;
				this.bLmyHbRcHvtiBHHqCrcOSggoCzCbA = Guid.Empty;
			}
		}

		// Token: 0x060001F4 RID: 500 RVA: 0x0002802C File Offset: 0x0002622C
		private bool KPmFYsPidfHaTByDvdtxnAlBQEve()
		{
			try
			{
				if (this.DhGHHanjxlOzCROeZTyewOdlamjH != (XInputDeviceSubType)this.cRpbtIKkCAwmLwSSWoezVPkLkBCab.YxhefCmxGIggoAMJkVFwlzXoLwY.MjDMbyQxLIUFNivnHlplKGAZSWbw(xWqjpLrDBXUZxgRusGkFwZRUWwEG.Any).ENpAZfUaqGHRZKihIEaRfWaZRSnp)
				{
					return true;
				}
			}
			catch
			{
			}
			return false;
		}

		// Token: 0x060001F5 RID: 501 RVA: 0x0001249D File Offset: 0x0001069D
		private void bEuYfdpOfkRJkogSDZwCjTxinPCf()
		{
			this.dWwEYYhJxvrSpTVBzoiFGoPCnypeb = false;
			this.koEfHLkMOEdTQUORYwqJhsMQIrIZ = false;
			this.sHfXVWGYdCnMZePXaBuAdFeJsHOh = false;
			this.kHhihlKJapsvCYhkQFtywTaFQegR = false;
		}

		// Token: 0x060001F6 RID: 502 RVA: 0x000124BB File Offset: 0x000106BB
		private void HyROmekkcqBdPueLxYBfTlTRRruL()
		{
			if (this.cVcJjuZeWCzRDsLTokAPBreuuaZt != null)
			{
				this.cVcJjuZeWCzRDsLTokAPBreuuaZt();
			}
			this.cRpbtIKkCAwmLwSSWoezVPkLkBCab.qfvLPOLoPDpzgCQyfqHOwsucnvjI();
		}

		// Token: 0x060001F7 RID: 503 RVA: 0x00028074 File Offset: 0x00026274
		private void bJGOACXAXPIQfDGIDCqazcxavhTE(bool[] A_1, ref dmHvWETeAqDVNTDczCTgCpqgchOO A_2)
		{
			HardwareJoystickMap.Platform_XInput_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_XInput_Base)this.SnTnfXKEfCeMuZhpgBnVufDxTPzk.map).Axes_orig;
			if (axes_orig == null)
			{
				return;
			}
			for (int i = 0; i < axes_orig.Length; i++)
			{
				if (i >= this.TPVRdisIMNTDckkkWKYlESLXiRBv)
				{
					throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
				}
				this.kNsNjNKeApJMHiLerczBiWuglhtG[i] = this.BwPGXCdoKqjqrsppbYyeMWXrjSHQ(axes_orig[i], A_1, ref A_2);
				if (!this.AzMGDwvFiTlatmSqFjSyDfBmciuj && this.kNsNjNKeApJMHiLerczBiWuglhtG[i] != 0f)
				{
					this.AzMGDwvFiTlatmSqFjSyDfBmciuj = true;
				}
			}
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x000280F0 File Offset: 0x000262F0
		private void HvfgHbBPTqaCkmWldThIYOfyPAWx(bool[] A_1, ref dmHvWETeAqDVNTDczCTgCpqgchOO A_2)
		{
			HardwareJoystickMap.Platform_XInput_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_XInput_Base)this.SnTnfXKEfCeMuZhpgBnVufDxTPzk.map).Buttons_orig;
			if (buttons_orig == null)
			{
				return;
			}
			for (int i = 0; i < buttons_orig.Length; i++)
			{
				if (i >= this.OscypnCEQfCmGVjpXRAqLDkhAYXP)
				{
					throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
				}
				this.akSaZcozMebGDNduNEaaJKdNrqdq[i] = this.dhRIeIZotbBdVBcPFNOZbsQHWYGoA(buttons_orig[i], A_1, ref A_2);
				if (!this.AzMGDwvFiTlatmSqFjSyDfBmciuj && this.akSaZcozMebGDNduNEaaJKdNrqdq[i])
				{
					this.AzMGDwvFiTlatmSqFjSyDfBmciuj = true;
				}
			}
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x00028168 File Offset: 0x00026368
		private float BwPGXCdoKqjqrsppbYyeMWXrjSHQ(HardwareJoystickMap.Platform_XInput_Base.Axis A_1, bool[] A_2, ref dmHvWETeAqDVNTDczCTgCpqgchOO A_3)
		{
			if (A_1.sourceType == HardwareElementSourceType.Axis)
			{
				if (A_1.sourceAxis == XInputAxis.None)
				{
					return 0f;
				}
				return this.jdNamyXGdawQrzhfbQphFfHEZDUH(A_1.sourceAxis, ref A_3);
			}
			else
			{
				if (A_1.sourceType != HardwareElementSourceType.Button)
				{
					return 0f;
				}
				if (A_1.sourceButton == XInputButton.None)
				{
					return 0f;
				}
				if (!this.DknNIwZdJwBjLbxPSUTwTNqwrleLA(A_1.sourceButton, A_2))
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
		}

		// Token: 0x060001FA RID: 506 RVA: 0x000281E4 File Offset: 0x000263E4
		private float jdNamyXGdawQrzhfbQphFfHEZDUH(XInputAxis A_1, ref dmHvWETeAqDVNTDczCTgCpqgchOO A_2)
		{
			float result;
			switch (A_1)
			{
			case XInputAxis.LeftThumbX:
				result = hSuFwhjVGbqfsiEcUujmPPhLicCV.wNQAbVkCRIcHkgopPRXXdCObRbvg.zcVgSFAXlmFUsCelhndQIEPAvfopc((int)A_2.OGUiLWQFnXHErroZpEztgPpsOhCv);
				break;
			case XInputAxis.LeftThumbY:
				result = hSuFwhjVGbqfsiEcUujmPPhLicCV.wNQAbVkCRIcHkgopPRXXdCObRbvg.zcVgSFAXlmFUsCelhndQIEPAvfopc((int)A_2.rBBJpYeIlFicadQiCZnkJFDUXlbeB);
				break;
			case XInputAxis.RightThumbX:
				result = hSuFwhjVGbqfsiEcUujmPPhLicCV.wNQAbVkCRIcHkgopPRXXdCObRbvg.zcVgSFAXlmFUsCelhndQIEPAvfopc((int)A_2.KDLajuQtUeOxGWDBdEvaBfXtDIMYA);
				break;
			case XInputAxis.RightThumbY:
				result = hSuFwhjVGbqfsiEcUujmPPhLicCV.wNQAbVkCRIcHkgopPRXXdCObRbvg.zcVgSFAXlmFUsCelhndQIEPAvfopc((int)A_2.uuSHzCjBmoOeAKIfXzTuhrQMsSJP);
				break;
			case XInputAxis.LeftTrigger:
				result = hSuFwhjVGbqfsiEcUujmPPhLicCV.wNQAbVkCRIcHkgopPRXXdCObRbvg.OpNkEGTCAldhpXLQlYYYtbIvIeax((int)A_2.MVcLZUGquQThBbHpOHLoVtRZnUjn);
				break;
			case XInputAxis.RightTrigger:
				result = hSuFwhjVGbqfsiEcUujmPPhLicCV.wNQAbVkCRIcHkgopPRXXdCObRbvg.OpNkEGTCAldhpXLQlYYYtbIvIeax((int)A_2.ZkDNxPMbJFHhXTOvNSqOktzsjcsO);
				break;
			default:
				return 0f;
			}
			return result;
		}

		// Token: 0x060001FB RID: 507 RVA: 0x00028270 File Offset: 0x00026470
		private bool dhRIeIZotbBdVBcPFNOZbsQHWYGoA(HardwareJoystickMap.Platform_XInput_Base.Button A_1, bool[] A_2, ref dmHvWETeAqDVNTDczCTgCpqgchOO A_3)
		{
			if (A_1.sourceType == HardwareElementSourceType.Button)
			{
				return A_1.sourceButton != XInputButton.None && this.DknNIwZdJwBjLbxPSUTwTNqwrleLA(A_1.sourceButton, A_2);
			}
			if (A_1.sourceType != HardwareElementSourceType.Axis)
			{
				return false;
			}
			if (A_1.sourceAxis == XInputAxis.None)
			{
				return false;
			}
			float num = this.jdNamyXGdawQrzhfbQphFfHEZDUH(A_1.sourceAxis, ref A_3);
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

		// Token: 0x060001FC RID: 508 RVA: 0x000282F0 File Offset: 0x000264F0
		private bool DknNIwZdJwBjLbxPSUTwTNqwrleLA(XInputButton A_1, bool[] A_2)
		{
			switch (A_1)
			{
			case XInputButton.A:
				return A_2[11];
			case XInputButton.B:
				return A_2[12];
			case XInputButton.X:
				return A_2[13];
			case XInputButton.Y:
				return A_2[14];
			case XInputButton.LeftShoulder:
				return A_2[8];
			case XInputButton.RightShoulder:
				return A_2[9];
			case XInputButton.LeftThumb:
				return A_2[6];
			case XInputButton.RightThumb:
				return A_2[7];
			case XInputButton.Start:
				return A_2[4];
			case XInputButton.Back:
				return A_2[5];
			case XInputButton.DPadUp:
				return A_2[0];
			case XInputButton.DPadRight:
				return A_2[3];
			case XInputButton.DPadDown:
				return A_2[1];
			case XInputButton.DPadLeft:
				return A_2[2];
			case XInputButton.Guide:
				return A_2[10];
			default:
				return false;
			}
		}

		// Token: 0x060001FD RID: 509 RVA: 0x00028388 File Offset: 0x00026588
		private void LZrUiAdQalHJsmuWzssmXPQsJrpx()
		{
			this.SnTnfXKEfCeMuZhpgBnVufDxTPzk = this.HUZRtMVIcdMUKSqcRmleviFgTgjQ(this.yoSKPlymsEoDgkugbWQDnMyFrqMT());
			if (this.SnTnfXKEfCeMuZhpgBnVufDxTPzk == null)
			{
				Logger.LogError("Default hardware map not found!");
				return;
			}
			this.TPVRdisIMNTDckkkWKYlESLXiRBv = this.SnTnfXKEfCeMuZhpgBnVufDxTPzk.axisCount;
			this.OscypnCEQfCmGVjpXRAqLDkhAYXP = this.SnTnfXKEfCeMuZhpgBnVufDxTPzk.buttonCount;
		}

		// Token: 0x060001FE RID: 510 RVA: 0x000124DB File Offset: 0x000106DB
		private bool trAGEnILJUMsPsknresjAllkUCTlb(ref ANKpkQVdjjJBZtpJglzmnbRRvFWL A_1)
		{
			return A_1.ALCohoCDpTqPKeuYBtdgXgHmRcFE > 0 || A_1.LDmAtiQsVBhlIYUdxktlsfOUUvKo > 0;
		}

		// Token: 0x060001FF RID: 511 RVA: 0x000124F2 File Offset: 0x000106F2
		private void BGmlcTnZiHJGqOJjOMnHWfpxukeL(ref ANKpkQVdjjJBZtpJglzmnbRRvFWL A_1)
		{
			A_1.ALCohoCDpTqPKeuYBtdgXgHmRcFE = 0;
			A_1.LDmAtiQsVBhlIYUdxktlsfOUUvKo = 0;
		}

		// Token: 0x06000200 RID: 512 RVA: 0x00012502 File Offset: 0x00010702
		private void yskTnRmGMzrgPMGBaeCjegfxcmEeb(ref ANKpkQVdjjJBZtpJglzmnbRRvFWL A_1, ref ANKpkQVdjjJBZtpJglzmnbRRvFWL A_2)
		{
			A_2.ALCohoCDpTqPKeuYBtdgXgHmRcFE = A_1.ALCohoCDpTqPKeuYBtdgXgHmRcFE;
			A_2.LDmAtiQsVBhlIYUdxktlsfOUUvKo = A_1.LDmAtiQsVBhlIYUdxktlsfOUUvKo;
		}

		// Token: 0x06000201 RID: 513 RVA: 0x000283E4 File Offset: 0x000265E4
		private string GamdbRKvGjCArostnqFkAxngvMuEb()
		{
			return InputTools.FormatHardwareIdentifierString(string.Format("{0}{1}{2}{3}", new object[]
			{
				ReInput.currentPlatform.ToString(),
				InputSource.XInput.ToString(),
				this.cdjtvkqVkQUCBzHPhxuWnqEVHSCb.ToString(),
				this.DhGHHanjxlOzCROeZTyewOdlamjH.ToString()
			}));
		}

		// Token: 0x06000202 RID: 514 RVA: 0x00028458 File Offset: 0x00026658
		private void aasaEYTrKVVfTSjPYyVvgDaeQzZh(BridgedControllerHWInfo A_1)
		{
			A_1.inputManagerSource = InputSource.XInput;
			A_1.inputSource = A_1.inputManagerSource;
			A_1.deviceType = ControlDeviceType.Unknown;
			A_1.hardwareIdentifier = this.GamdbRKvGjCArostnqFkAxngvMuEb();
			A_1.hardwareAxisCount = this.bEwPoamyVeieOTgHRkgPETTkwAFd;
			A_1.hardwareButtonCount = this.udweeNZaMBfOenzoWvVDOJVFdszDA;
			A_1.hardwareHatCount = 0;
			A_1.hw_productName = this.YguMbBmrBstFJiLItJCTLufnFqGl;
			A_1.hw_supportsVoice = this.dWwEYYhJxvrSpTVBzoiFGoPCnypeb;
			A_1.hw_supportsVibration = this.koEfHLkMOEdTQUORYwqJhsMQIrIZ;
			A_1.hw_localVibrationMotorCount = (this.koEfHLkMOEdTQUORYwqJhsMQIrIZ ? 2 : 0);
			A_1.hw_xInputSubType = this.DhGHHanjxlOzCROeZTyewOdlamjH;
		}

		// Token: 0x06000203 RID: 515 RVA: 0x000284F0 File Offset: 0x000266F0
		private void RLYBefnopzcCFFmAdrpDRgAoDJYD(BridgedController A_1)
		{
			this.aasaEYTrKVVfTSjPYyVvgDaeQzZh(A_1);
			A_1.sourceJoystick = this;
			A_1.gameHardwareMap = this.SnTnfXKEfCeMuZhpgBnVufDxTPzk.ToGameHardwareControllerMap();
			A_1.instanceName = "XInput " + this.kJncpphGLFDBMOngVeZENkJlcmEz;
			A_1.productName = "XInput " + this.YguMbBmrBstFJiLItJCTLufnFqGl;
			A_1.isXInputDevice = true;
			A_1.axisCount = this.TPVRdisIMNTDckkkWKYlESLXiRBv;
			A_1.buttonCount = this.OscypnCEQfCmGVjpXRAqLDkhAYXP;
			A_1.controllerTypeGuid = this.iVzSGJtiASOgkNDQTBrRtwMHyHdV;
			A_1.controllerExtension = this.extension;
		}

		// Token: 0x06000204 RID: 516 RVA: 0x0001251C File Offset: 0x0001071C
		public void Dispose()
		{
			this.dVZFjRdBkJswKYWPYlXipREBqaVB(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06000205 RID: 517 RVA: 0x00028580 File Offset: 0x00026780
		protected virtual void avqIFOPsfOQbzclxjABQoIDdYvGV()
		{
			try
			{
				this.dVZFjRdBkJswKYWPYlXipREBqaVB(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		// Token: 0x06000206 RID: 518 RVA: 0x0001252B File Offset: 0x0001072B
		protected virtual void dVZFjRdBkJswKYWPYlXipREBqaVB(bool A_1)
		{
			if (this.kjmEXdHzwWtUIdGRaUAXUqYrMVIDA)
			{
				return;
			}
			if (A_1)
			{
				if (this.NLeokKSzJrbPFrhnuMGYihSTanrA)
				{
					this.cRpbtIKkCAwmLwSSWoezVPkLkBCab.OsxpZlIUdkSbfyJsnhfzvIICikFt();
				}
				if (this.cRpbtIKkCAwmLwSSWoezVPkLkBCab != null)
				{
					this.cRpbtIKkCAwmLwSSWoezVPkLkBCab.Dispose();
				}
			}
			this.kjmEXdHzwWtUIdGRaUAXUqYrMVIDA = true;
		}

		// Token: 0x04000179 RID: 377
		private bool dXnGtSIHUMOTGjSdFLgcalTgwniCB;

		// Token: 0x0400017A RID: 378
		private int YZSVRbuHvYbNDKcIJZFnzkyqfQsL;

		// Token: 0x0400017B RID: 379
		private readonly int vyHvlIbCuCCztihHzTUZfdEjsJqUA;

		// Token: 0x0400017C RID: 380
		public Guid iVzSGJtiASOgkNDQTBrRtwMHyHdV;

		// Token: 0x0400017D RID: 381
		public string bVTBwzStIJPOPNeSMyCwioDaAhVgA;

		// Token: 0x0400017E RID: 382
		public string dyahjtcZMRsCjPWwPjjmEcDKtfXhA;

		// Token: 0x0400017F RID: 383
		public Guid bLmyHbRcHvtiBHHqCrcOSggoCzCbA;

		// Token: 0x04000180 RID: 384
		public Rewired.Libraries.SharpDX.XInput.DeviceType cdjtvkqVkQUCBzHPhxuWnqEVHSCb;

		// Token: 0x04000181 RID: 385
		public XInputDeviceSubType DhGHHanjxlOzCROeZTyewOdlamjH;

		// Token: 0x04000182 RID: 386
		public bool koEfHLkMOEdTQUORYwqJhsMQIrIZ;

		// Token: 0x04000183 RID: 387
		public bool dWwEYYhJxvrSpTVBzoiFGoPCnypeb;

		// Token: 0x04000184 RID: 388
		public bool sHfXVWGYdCnMZePXaBuAdFeJsHOh;

		// Token: 0x04000185 RID: 389
		public bool kHhihlKJapsvCYhkQFtywTaFQegR;

		// Token: 0x04000186 RID: 390
		private int TPVRdisIMNTDckkkWKYlESLXiRBv;

		// Token: 0x04000187 RID: 391
		private int OscypnCEQfCmGVjpXRAqLDkhAYXP;

		// Token: 0x04000188 RID: 392
		private int bEwPoamyVeieOTgHRkgPETTkwAFd;

		// Token: 0x04000189 RID: 393
		private int udweeNZaMBfOenzoWvVDOJVFdszDA;

		// Token: 0x0400018A RID: 394
		private readonly float[] kNsNjNKeApJMHiLerczBiWuglhtG;

		// Token: 0x0400018B RID: 395
		private readonly bool[] akSaZcozMebGDNduNEaaJKdNrqdq;

		// Token: 0x0400018C RID: 396
		private HardwareJoystickMap_InputManager SnTnfXKEfCeMuZhpgBnVufDxTPzk;

		// Token: 0x0400018D RID: 397
		public readonly hSuFwhjVGbqfsiEcUujmPPhLicCV.wNQAbVkCRIcHkgopPRXXdCObRbvg cRpbtIKkCAwmLwSSWoezVPkLkBCab;

		// Token: 0x0400018E RID: 398
		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> HUZRtMVIcdMUKSqcRmleviFgTgjQ;

		// Token: 0x0400018F RID: 399
		private Action cVcJjuZeWCzRDsLTokAPBreuuaZt;

		// Token: 0x04000190 RID: 400
		private readonly LocalizedString zNXdfNLnZeVTfrDlJGJzGVGwTerIA;

		// Token: 0x04000191 RID: 401
		private bool EsPAExwvErbgxoxFcplkBeDycLWi;

		// Token: 0x04000192 RID: 402
		private bool AzMGDwvFiTlatmSqFjSyDfBmciuj;

		// Token: 0x04000193 RID: 403
		private bool kjmEXdHzwWtUIdGRaUAXUqYrMVIDA;
	}

	// Token: 0x0200002E RID: 46
	private class elCGeuXtEuUoGTINMbEsOPGHbHYX
	{
		// Token: 0x06000207 RID: 519 RVA: 0x00012566 File Offset: 0x00010766
		public elCGeuXtEuUoGTINMbEsOPGHbHYX()
		{
			this.qHgaxfqrBeulrJbkGECgaIHvJujJ = new List<hSuFwhjVGbqfsiEcUujmPPhLicCV.elCGeuXtEuUoGTINMbEsOPGHbHYX.OxbhHjFoLLCnUwVZOUSPCLnXydeaA>();
		}

		// Token: 0x06000208 RID: 520 RVA: 0x000285B0 File Offset: 0x000267B0
		public void RSVkZQOXhMQSfsOHRbNfHMnNJHQdA(hSuFwhjVGbqfsiEcUujmPPhLicCV.oqVsrVdnkBMTAeByHxtbCRBSjQDU A_1, bool A_2)
		{
			if (this.vIERyleYTFDKDOGNsTiAgNCNWoYP(A_1.rewiredId, A_1.DhGHHanjxlOzCROeZTyewOdlamjH, true) >= 0)
			{
				return;
			}
			hSuFwhjVGbqfsiEcUujmPPhLicCV.elCGeuXtEuUoGTINMbEsOPGHbHYX.OxbhHjFoLLCnUwVZOUSPCLnXydeaA oxbhHjFoLLCnUwVZOUSPCLnXydeaA = new hSuFwhjVGbqfsiEcUujmPPhLicCV.elCGeuXtEuUoGTINMbEsOPGHbHYX.OxbhHjFoLLCnUwVZOUSPCLnXydeaA(A_1.rewiredId, A_1.DhGHHanjxlOzCROeZTyewOdlamjH);
			oxbhHjFoLLCnUwVZOUSPCLnXydeaA.UoAswfrSHfwHxgKeTBBZMRceePOGA = A_2;
			this.qHgaxfqrBeulrJbkGECgaIHvJujJ.Add(oxbhHjFoLLCnUwVZOUSPCLnXydeaA);
		}

		// Token: 0x06000209 RID: 521 RVA: 0x00012579 File Offset: 0x00010779
		public void WlwAKyjYSbNjHLzimIjFeUEVDInhA(int A_1, hSuFwhjVGbqfsiEcUujmPPhLicCV.oqVsrVdnkBMTAeByHxtbCRBSjQDU A_2, bool A_3)
		{
			if (A_1 < 0 || A_1 >= this.qHgaxfqrBeulrJbkGECgaIHvJujJ.Count)
			{
				return;
			}
			this.qHgaxfqrBeulrJbkGECgaIHvJujJ[A_1].FbhBNWmekKGbSHrPVMIIxCrAgfdC(A_2, A_3);
		}

		// Token: 0x0600020A RID: 522 RVA: 0x000285FC File Offset: 0x000267FC
		public int gdliFwnvfbEMbFHxlxdXlORULsXS(XInputDeviceSubType A_1, bool A_2)
		{
			int count = this.qHgaxfqrBeulrJbkGECgaIHvJujJ.Count;
			for (int i = 0; i < count; i++)
			{
				if ((A_2 || !this.qHgaxfqrBeulrJbkGECgaIHvJujJ[i].UoAswfrSHfwHxgKeTBBZMRceePOGA) && this.qHgaxfqrBeulrJbkGECgaIHvJujJ[i].gbYdPwZKhVzLYBdUEPfmkdatDfll == A_1)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x0600020B RID: 523 RVA: 0x00028650 File Offset: 0x00026850
		public int vIERyleYTFDKDOGNsTiAgNCNWoYP(int A_1, XInputDeviceSubType A_2, bool A_3)
		{
			int count = this.qHgaxfqrBeulrJbkGECgaIHvJujJ.Count;
			for (int i = 0; i < count; i++)
			{
				if ((A_3 || !this.qHgaxfqrBeulrJbkGECgaIHvJujJ[i].UoAswfrSHfwHxgKeTBBZMRceePOGA) && this.qHgaxfqrBeulrJbkGECgaIHvJujJ[i].xPPvLzeaIrICcJNLPeYdfcchqSgdc == A_1 && this.qHgaxfqrBeulrJbkGECgaIHvJujJ[i].gbYdPwZKhVzLYBdUEPfmkdatDfll == A_2)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x0600020C RID: 524 RVA: 0x000125A1 File Offset: 0x000107A1
		public int mmGCTFwfFzmtzfDPaQMrchVwSEzI(int A_1)
		{
			if (A_1 < 0 || A_1 >= this.qHgaxfqrBeulrJbkGECgaIHvJujJ.Count)
			{
				throw new ArgumentOutOfRangeException();
			}
			return this.qHgaxfqrBeulrJbkGECgaIHvJujJ[A_1].xPPvLzeaIrICcJNLPeYdfcchqSgdc;
		}

		// Token: 0x0600020D RID: 525 RVA: 0x000125CC File Offset: 0x000107CC
		public void fblezJTTQqHemxqbEGMiGFnvKzqf(int A_1, bool A_2)
		{
			if (A_1 < 0 || A_1 >= this.qHgaxfqrBeulrJbkGECgaIHvJujJ.Count)
			{
				return;
			}
			this.qHgaxfqrBeulrJbkGECgaIHvJujJ[A_1].UoAswfrSHfwHxgKeTBBZMRceePOGA = A_2;
		}

		// Token: 0x04000194 RID: 404
		private List<hSuFwhjVGbqfsiEcUujmPPhLicCV.elCGeuXtEuUoGTINMbEsOPGHbHYX.OxbhHjFoLLCnUwVZOUSPCLnXydeaA> qHgaxfqrBeulrJbkGECgaIHvJujJ;

		// Token: 0x0200002F RID: 47
		private class OxbhHjFoLLCnUwVZOUSPCLnXydeaA
		{
			// Token: 0x0600020E RID: 526 RVA: 0x000125F3 File Offset: 0x000107F3
			public void FbhBNWmekKGbSHrPVMIIxCrAgfdC(hSuFwhjVGbqfsiEcUujmPPhLicCV.oqVsrVdnkBMTAeByHxtbCRBSjQDU A_1, bool A_2)
			{
				this.UoAswfrSHfwHxgKeTBBZMRceePOGA = A_2;
				this.xPPvLzeaIrICcJNLPeYdfcchqSgdc = A_1.rewiredId;
				this.gbYdPwZKhVzLYBdUEPfmkdatDfll = A_1.DhGHHanjxlOzCROeZTyewOdlamjH;
			}

			// Token: 0x0600020F RID: 527 RVA: 0x00012614 File Offset: 0x00010814
			public OxbhHjFoLLCnUwVZOUSPCLnXydeaA(int A_1, XInputDeviceSubType A_2)
			{
				this.xPPvLzeaIrICcJNLPeYdfcchqSgdc = A_1;
				this.gbYdPwZKhVzLYBdUEPfmkdatDfll = A_2;
			}

			// Token: 0x04000195 RID: 405
			public bool UoAswfrSHfwHxgKeTBBZMRceePOGA;

			// Token: 0x04000196 RID: 406
			public int xPPvLzeaIrICcJNLPeYdfcchqSgdc;

			// Token: 0x04000197 RID: 407
			public XInputDeviceSubType gbYdPwZKhVzLYBdUEPfmkdatDfll;
		}
	}

	// Token: 0x02000030 RID: 48
	private class SrIoKJIqquGPaPtBDxPDjLmTjtKL
	{
		// Token: 0x06000210 RID: 528 RVA: 0x000114A8 File Offset: 0x0000F6A8
		public SrIoKJIqquGPaPtBDxPDjLmTjtKL()
		{
		}

		// Token: 0x06000211 RID: 529 RVA: 0x0001262A File Offset: 0x0001082A
		public SrIoKJIqquGPaPtBDxPDjLmTjtKL(float A_1)
		{
			this.DxzVABFnhzGnNRYNcLhDYBlINgLc = A_1;
		}

		// Token: 0x06000212 RID: 530 RVA: 0x00012639 File Offset: 0x00010839
		public void NUggdKtmmkHlqWLJhqDYzJCpgjRo()
		{
			this.gOerFqnNLiUMzPglTikjAggUgxkgb = true;
			this.wdstcAvyCCpleBLMtrYzQXDhdHKX = (double)this.DxzVABFnhzGnNRYNcLhDYBlINgLc + ReInput.unscaledTime;
		}

		// Token: 0x06000213 RID: 531 RVA: 0x00012655 File Offset: 0x00010855
		public void MAtyCINUOoAcqDaRtlIEcCkFFQVdA(float A_1)
		{
			this.gOerFqnNLiUMzPglTikjAggUgxkgb = true;
			this.DxzVABFnhzGnNRYNcLhDYBlINgLc = A_1;
			this.wdstcAvyCCpleBLMtrYzQXDhdHKX = (double)this.DxzVABFnhzGnNRYNcLhDYBlINgLc + ReInput.unscaledTime;
		}

		// Token: 0x06000214 RID: 532 RVA: 0x00012678 File Offset: 0x00010878
		public bool uEQSqbVCDLUcYwZKxrfNvppNGuriA()
		{
			if (!this.gOerFqnNLiUMzPglTikjAggUgxkgb)
			{
				return false;
			}
			if (ReInput.unscaledTime >= this.wdstcAvyCCpleBLMtrYzQXDhdHKX)
			{
				this.gOerFqnNLiUMzPglTikjAggUgxkgb = false;
				return true;
			}
			return false;
		}

		// Token: 0x06000215 RID: 533 RVA: 0x0001269B File Offset: 0x0001089B
		public void lDdHrpLhbMORIaFsmaRzHsJcJRLq()
		{
			this.gOerFqnNLiUMzPglTikjAggUgxkgb = false;
			this.wdstcAvyCCpleBLMtrYzQXDhdHKX = 0.0;
		}

		// Token: 0x06000216 RID: 534 RVA: 0x000126B3 File Offset: 0x000108B3
		public void NPkEPrwhHLxOXCCJpglQeuPorhOi(float A_1)
		{
			this.DxzVABFnhzGnNRYNcLhDYBlINgLc = A_1;
		}

		// Token: 0x06000217 RID: 535 RVA: 0x000126BC File Offset: 0x000108BC
		public hSuFwhjVGbqfsiEcUujmPPhLicCV.SrIoKJIqquGPaPtBDxPDjLmTjtKL ScNpVIEzLpfXlnOmDMGCgMlVYHCj()
		{
			return (hSuFwhjVGbqfsiEcUujmPPhLicCV.SrIoKJIqquGPaPtBDxPDjLmTjtKL)base.MemberwiseClone();
		}

		// Token: 0x04000198 RID: 408
		public bool gOerFqnNLiUMzPglTikjAggUgxkgb;

		// Token: 0x04000199 RID: 409
		private double wdstcAvyCCpleBLMtrYzQXDhdHKX;

		// Token: 0x0400019A RID: 410
		public float DxzVABFnhzGnNRYNcLhDYBlINgLc;
	}

	// Token: 0x02000031 RID: 49
	public class wNQAbVkCRIcHkgopPRXXdCObRbvg : IDisposable
	{
		// Token: 0x17000054 RID: 84
		// (get) Token: 0x06000218 RID: 536 RVA: 0x000126C9 File Offset: 0x000108C9
		public Controller.Extension bBtvKUuAcalBBzkJZgdArcFBLmso
		{
			get
			{
				return this.EnXsSUGYTweBetzEXKrCjBOJPmQT;
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x06000219 RID: 537 RVA: 0x000126D1 File Offset: 0x000108D1
		public bool[] wgDTYEXqAoIVBQrYpVqeLSEIjdrBA
		{
			get
			{
				return this.ttGUArLFOTGPddiDjKafvjIbHKfn.Current.effectiveValue;
			}
		}

		// Token: 0x0600021A RID: 538 RVA: 0x000286B8 File Offset: 0x000268B8
		public wNQAbVkCRIcHkgopPRXXdCObRbvg(int A_1, UpdateLoopSetting A_2)
		{
			this.YxhefCmxGIggoAMJkVFwlzXoLwY = new zmDlVAYpiICKEnvrtEDAeKCAYFkVA((BuNqfCrdVwfxylZCOMsUJLlUODmX)A_1);
			this.ttGUArLFOTGPddiDjKafvjIbHKfn = new ButtonLoopSet(A_2, 15);
			this.gOWrkOCzPdxhuhfgcYkfOeczGRHq = new object();
			this.MzDpSEZAlPwdHiSzdOqymyaSpguO = new DualThreadLowLevelInputEventQueue((int)((float)jbcfMDoFeBFAQElVePZhKkwUdctNA.dHcfLGecBdWpOuQXknheqwKuIFtT * 0.25f), 15, 6, 0);
			this.EnXsSUGYTweBetzEXKrCjBOJPmQT = new XInputControllerExtension(this);
		}

		// Token: 0x0600021B RID: 539 RVA: 0x000126E3 File Offset: 0x000108E3
		public void CdaocvrLOAQhFXUhQxzbYTdPjGAG()
		{
			this.ttGUArLFOTGPddiDjKafvjIbHKfn.SetUpdateLoop(ReInput.currentUpdateLoop);
			this.bGHNSxvoFpwsXuoXMkLlgRTrfNFG(ref this.oAnHbndTQTeuHDDvvRjesvJVrtVuA);
		}

		// Token: 0x0600021C RID: 540 RVA: 0x00012701 File Offset: 0x00010901
		public void hGhEieAGYfqwZsqnuvpBpWIunjbkA()
		{
			this.KNybyFGGOVpVIMxNZqgdEqaxfdFBA();
			this.ttGUArLFOTGPddiDjKafvjIbHKfn.Current.ClearWasTrueThisFrame();
		}

		// Token: 0x0600021D RID: 541 RVA: 0x00012719 File Offset: 0x00010919
		public void EiImUypmGvHiXSsgmgcqKvaGMWgeA()
		{
			this.SdjExorqLhmYdppqrSPPSnngOGXD();
			this.WoseqKeaSRqPPKjyXEkNLhEvMxwcA = true;
			this.lAlhsoIbJUIlZxGGtKWWDHjTdelDb = this.YxhefCmxGIggoAMJkVFwlzXoLwY.LVxgaRzwsbUiJQpVodnOGQYqJQAJ;
		}

		// Token: 0x0600021E RID: 542 RVA: 0x00012739 File Offset: 0x00010939
		public void qfvLPOLoPDpzgCQyfqHOwsucnvjI()
		{
			this.WoseqKeaSRqPPKjyXEkNLhEvMxwcA = false;
			this.lAlhsoIbJUIlZxGGtKWWDHjTdelDb = false;
			this.SdjExorqLhmYdppqrSPPSnngOGXD();
		}

		// Token: 0x0600021F RID: 543 RVA: 0x00028748 File Offset: 0x00026948
		public bool bKPZiUErKXdPUPyKSODUhkkSOQLl(hSuFwhjVGbqfsiEcUujmPPhLicCV.jJBXEoZkAKXDTtNyqJfJoCFZbYrA A_1)
		{
			if (A_1 == hSuFwhjVGbqfsiEcUujmPPhLicCV.jJBXEoZkAKXDTtNyqJfJoCFZbYrA.Synchronous)
			{
				return this.lAlhsoIbJUIlZxGGtKWWDHjTdelDb = this.YxhefCmxGIggoAMJkVFwlzXoLwY.LVxgaRzwsbUiJQpVodnOGQYqJQAJ;
			}
			if (A_1 == hSuFwhjVGbqfsiEcUujmPPhLicCV.jJBXEoZkAKXDTtNyqJfJoCFZbYrA.Asynchronous)
			{
				return this.lAlhsoIbJUIlZxGGtKWWDHjTdelDb;
			}
			throw new NotImplementedException();
		}

		// Token: 0x06000220 RID: 544 RVA: 0x00028780 File Offset: 0x00026980
		public void VOUBzRMsjdjdjBrKXAqYriccsSGB(float A_1, int A_2)
		{
			if (A_2 == 0)
			{
				this.MVUXAwsXIdDdihXSFrzFQUNEkYHr.ALCohoCDpTqPKeuYBtdgXgHmRcFE = (ushort)(MathTools.Clamp01(A_1) * 65535f);
			}
			else if (A_2 == 1)
			{
				this.MVUXAwsXIdDdihXSFrzFQUNEkYHr.LDmAtiQsVBhlIYUdxktlsfOUUvKo = (ushort)(MathTools.Clamp01(A_1) * 65535f);
			}
			this.ihbqEtqeXpJEhCJOVxuyuxDutkDb();
		}

		// Token: 0x06000221 RID: 545 RVA: 0x0001274F File Offset: 0x0001094F
		public void NaydyKbUkMRbqxKALptfLJVQgMpaA()
		{
			this.MVUXAwsXIdDdihXSFrzFQUNEkYHr.ALCohoCDpTqPKeuYBtdgXgHmRcFE = 0;
			this.MVUXAwsXIdDdihXSFrzFQUNEkYHr.LDmAtiQsVBhlIYUdxktlsfOUUvKo = 0;
			this.ihbqEtqeXpJEhCJOVxuyuxDutkDb();
		}

		// Token: 0x06000222 RID: 546 RVA: 0x000287CC File Offset: 0x000269CC
		public void OsxpZlIUdkSbfyJsnhfzvIICikFt()
		{
			this.MVUXAwsXIdDdihXSFrzFQUNEkYHr.ALCohoCDpTqPKeuYBtdgXgHmRcFE = 0;
			this.MVUXAwsXIdDdihXSFrzFQUNEkYHr.LDmAtiQsVBhlIYUdxktlsfOUUvKo = 0;
			object obj = this.qqgDvPXNAcFvCLLUMnqNbYPFOxAA;
			lock (obj)
			{
				object jjDjvSfIEfHAvFPfyGZULQeTYUFKA = this.JjDjvSfIEfHAvFPfyGZULQeTYUFKA;
				lock (jjDjvSfIEfHAvFPfyGZULQeTYUFKA)
				{
					this.dOBbCMuBQicMEbEhvDwNxGMAMEMJ.Clear();
					this.XXAGGVOKsQLrwIejPVThaMCtgYsr.Clear();
					hSuFwhjVGbqfsiEcUujmPPhLicCV.wNQAbVkCRIcHkgopPRXXdCObRbvg.ziQrZeVZaQQdwvemZNDHNzHCMjwu(this.YxhefCmxGIggoAMJkVFwlzXoLwY, this.MVUXAwsXIdDdihXSFrzFQUNEkYHr, ref this.EyYMvABGXLpItgFGYHNThiBSHnioA);
				}
			}
		}

		// Token: 0x06000223 RID: 547 RVA: 0x00028874 File Offset: 0x00026A74
		public void NPyuLuJCFSHAukaKWIuNgXTtatiPA()
		{
			if (!this.WoseqKeaSRqPPKjyXEkNLhEvMxwcA)
			{
				return;
			}
			if (!this.lAlhsoIbJUIlZxGGtKWWDHjTdelDb)
			{
				return;
			}
			JmmDQfIwKOhQQnlqwKAZYIINwKqc jmmDQfIwKOhQQnlqwKAZYIINwKqc;
			double realTime;
			try
			{
				if (!this.YxhefCmxGIggoAMJkVFwlzXoLwY.VXMCiDnTlkpcUGEOmHEFliChSbgF(out jmmDQfIwKOhQQnlqwKAZYIINwKqc))
				{
					this.lAlhsoIbJUIlZxGGtKWWDHjTdelDb = false;
					return;
				}
				realTime = ReInput.realTime;
			}
			catch
			{
				this.lAlhsoIbJUIlZxGGtKWWDHjTdelDb = false;
				return;
			}
			object obj = this.gOWrkOCzPdxhuhfgcYkfOeczGRHq;
			lock (obj)
			{
				if (!hSuFwhjVGbqfsiEcUujmPPhLicCV.wNQAbVkCRIcHkgopPRXXdCObRbvg.ljkCnvbHSxtcCsCEWFWgAMthJfpOA(jmmDQfIwKOhQQnlqwKAZYIINwKqc.tQSTBzerBRDXcsiNSEWhipaKqlAy, this.pxyEKytUDLCWfokRAhZveCCEcQliA))
				{
					using (DualThreadLowLevelInputEventQueue.INewEventWrapper newEventWrapper = this.MzDpSEZAlPwdHiSzdOqymyaSpguO.T_CreateEvent())
					{
						this.RvxqkvkPsMdCZIJaVmisZGQXjMHDA(ref jmmDQfIwKOhQQnlqwKAZYIINwKqc.tQSTBzerBRDXcsiNSEWhipaKqlAy, realTime, newEventWrapper.Event);
					}
					this.pxyEKytUDLCWfokRAhZveCCEcQliA = jmmDQfIwKOhQQnlqwKAZYIINwKqc.tQSTBzerBRDXcsiNSEWhipaKqlAy;
				}
			}
		}

		// Token: 0x06000224 RID: 548 RVA: 0x00028954 File Offset: 0x00026B54
		public void TOwGJfFWkjkrGCfcjvJccSXhKimCb()
		{
			if (!this.WoseqKeaSRqPPKjyXEkNLhEvMxwcA)
			{
				return;
			}
			if (!this.lAlhsoIbJUIlZxGGtKWWDHjTdelDb)
			{
				return;
			}
			if (ReInput.realTime < this.EyYMvABGXLpItgFGYHNThiBSHnioA + 0.009999999776482582)
			{
				return;
			}
			object obj = this.qqgDvPXNAcFvCLLUMnqNbYPFOxAA;
			lock (obj)
			{
				object jjDjvSfIEfHAvFPfyGZULQeTYUFKA = this.JjDjvSfIEfHAvFPfyGZULQeTYUFKA;
				lock (jjDjvSfIEfHAvFPfyGZULQeTYUFKA)
				{
					MiscTools.Swap<RingBuffer<ANKpkQVdjjJBZtpJglzmnbRRvFWL>>(ref this.dOBbCMuBQicMEbEhvDwNxGMAMEMJ, ref this.XXAGGVOKsQLrwIejPVThaMCtgYsr);
				}
				hSuFwhjVGbqfsiEcUujmPPhLicCV.wNQAbVkCRIcHkgopPRXXdCObRbvg.PKedcHymkJlOqSOTVnaMAAqFGQiJA(this.XXAGGVOKsQLrwIejPVThaMCtgYsr, this.YxhefCmxGIggoAMJkVFwlzXoLwY, ref this.EyYMvABGXLpItgFGYHNThiBSHnioA);
			}
		}

		// Token: 0x06000225 RID: 549 RVA: 0x0001276F File Offset: 0x0001096F
		private void KNybyFGGOVpVIMxNZqgdEqaxfdFBA()
		{
			this.NyvFvKRZfHDmbUXSbNKkNzIPQvey();
		}

		// Token: 0x06000226 RID: 550 RVA: 0x00028A0C File Offset: 0x00026C0C
		private void NyvFvKRZfHDmbUXSbNKkNzIPQvey()
		{
			if (ReInput.realTime < this.EyYMvABGXLpItgFGYHNThiBSHnioA + 1.5)
			{
				return;
			}
			if (Mathf.Approximately((float)this.MVUXAwsXIdDdihXSFrzFQUNEkYHr.ALCohoCDpTqPKeuYBtdgXgHmRcFE, 0f) && Mathf.Approximately((float)this.MVUXAwsXIdDdihXSFrzFQUNEkYHr.LDmAtiQsVBhlIYUdxktlsfOUUvKo, 0f))
			{
				return;
			}
			this.ihbqEtqeXpJEhCJOVxuyuxDutkDb();
		}

		// Token: 0x06000227 RID: 551 RVA: 0x00028A68 File Offset: 0x00026C68
		private void ihbqEtqeXpJEhCJOVxuyuxDutkDb()
		{
			object jjDjvSfIEfHAvFPfyGZULQeTYUFKA = this.JjDjvSfIEfHAvFPfyGZULQeTYUFKA;
			lock (jjDjvSfIEfHAvFPfyGZULQeTYUFKA)
			{
				this.dOBbCMuBQicMEbEhvDwNxGMAMEMJ.Enqueue(this.MVUXAwsXIdDdihXSFrzFQUNEkYHr);
			}
		}

		// Token: 0x06000228 RID: 552 RVA: 0x00012777 File Offset: 0x00010977
		private static void PKedcHymkJlOqSOTVnaMAAqFGQiJA(RingBuffer<ANKpkQVdjjJBZtpJglzmnbRRvFWL> A_0, zmDlVAYpiICKEnvrtEDAeKCAYFkVA A_1, ref double A_2)
		{
			if (A_0.Count > 0)
			{
				hSuFwhjVGbqfsiEcUujmPPhLicCV.wNQAbVkCRIcHkgopPRXXdCObRbvg.ziQrZeVZaQQdwvemZNDHNzHCMjwu(A_1, A_0[A_0.Count - 1], ref A_2);
				A_0.Clear();
			}
		}

		// Token: 0x06000229 RID: 553 RVA: 0x00028AB4 File Offset: 0x00026CB4
		private static void ziQrZeVZaQQdwvemZNDHNzHCMjwu(zmDlVAYpiICKEnvrtEDAeKCAYFkVA A_0, ANKpkQVdjjJBZtpJglzmnbRRvFWL A_1, ref double A_2)
		{
			try
			{
				A_0.IRjRVeCDdBiRFGbDNaXpxXUaPbZJA(A_1);
			}
			catch
			{
			}
			A_2 = ReInput.realTime;
		}

		// Token: 0x0600022A RID: 554 RVA: 0x00028AE8 File Offset: 0x00026CE8
		private void bGHNSxvoFpwsXuoXMkLlgRTrfNFG(ref dmHvWETeAqDVNTDczCTgCpqgchOO A_1)
		{
			while (this.MzDpSEZAlPwdHiSzdOqymyaSpguO.ProcessNewEvents())
			{
				this.NXIXExTbNdCZzhAxxspGblrfzGJg(ref A_1, ref this.MzDpSEZAlPwdHiSzdOqymyaSpguO.currentEvent);
				for (int i = 0; i < 15; i++)
				{
					this.ttGUArLFOTGPddiDjKafvjIbHKfn.SetValue(i, hSuFwhjVGbqfsiEcUujmPPhLicCV.wNQAbVkCRIcHkgopPRXXdCObRbvg.PXwkocIJLDsczifjtIKzlYeuHvrX((int)A_1.ixAwkxyMsTtvbdVrzwrlWsikwxJT, i), this.MzDpSEZAlPwdHiSzdOqymyaSpguO.currentEvent.GetTimestamp());
				}
			}
		}

		// Token: 0x0600022B RID: 555 RVA: 0x00028B4C File Offset: 0x00026D4C
		private void RvxqkvkPsMdCZIJaVmisZGQXjMHDA(ref dmHvWETeAqDVNTDczCTgCpqgchOO A_1, double A_2, LowLevelInputEvent A_3)
		{
			A_3.SetTimestamp(A_2);
			int ixAwkxyMsTtvbdVrzwrlWsikwxJT = (int)A_1.ixAwkxyMsTtvbdVrzwrlWsikwxJT;
			A_3.SetButtonsBitMask((ixAwkxyMsTtvbdVrzwrlWsikwxJT & 2047) | (ixAwkxyMsTtvbdVrzwrlWsikwxJT & (ixAwkxyMsTtvbdVrzwrlWsikwxJT & -4096)) >> 1, 0);
			A_3.SetAxisValue(0, hSuFwhjVGbqfsiEcUujmPPhLicCV.wNQAbVkCRIcHkgopPRXXdCObRbvg.zcVgSFAXlmFUsCelhndQIEPAvfopc((int)A_1.OGUiLWQFnXHErroZpEztgPpsOhCv));
			A_3.SetAxisValue(1, hSuFwhjVGbqfsiEcUujmPPhLicCV.wNQAbVkCRIcHkgopPRXXdCObRbvg.zcVgSFAXlmFUsCelhndQIEPAvfopc((int)A_1.rBBJpYeIlFicadQiCZnkJFDUXlbeB));
			A_3.SetAxisValue(2, hSuFwhjVGbqfsiEcUujmPPhLicCV.wNQAbVkCRIcHkgopPRXXdCObRbvg.zcVgSFAXlmFUsCelhndQIEPAvfopc((int)A_1.KDLajuQtUeOxGWDBdEvaBfXtDIMYA));
			A_3.SetAxisValue(3, hSuFwhjVGbqfsiEcUujmPPhLicCV.wNQAbVkCRIcHkgopPRXXdCObRbvg.zcVgSFAXlmFUsCelhndQIEPAvfopc((int)A_1.uuSHzCjBmoOeAKIfXzTuhrQMsSJP));
			A_3.SetAxisValue(4, hSuFwhjVGbqfsiEcUujmPPhLicCV.wNQAbVkCRIcHkgopPRXXdCObRbvg.OpNkEGTCAldhpXLQlYYYtbIvIeax((int)A_1.MVcLZUGquQThBbHpOHLoVtRZnUjn));
			A_3.SetAxisValue(5, hSuFwhjVGbqfsiEcUujmPPhLicCV.wNQAbVkCRIcHkgopPRXXdCObRbvg.OpNkEGTCAldhpXLQlYYYtbIvIeax((int)A_1.ZkDNxPMbJFHhXTOvNSqOktzsjcsO));
		}

		// Token: 0x0600022C RID: 556 RVA: 0x00028BF8 File Offset: 0x00026DF8
		private void NXIXExTbNdCZzhAxxspGblrfzGJg(ref dmHvWETeAqDVNTDczCTgCpqgchOO A_1, ref LowLevelInputEvent A_2)
		{
			int buttonsBitMask = A_2.GetButtonsBitMask(0);
			A_1.ixAwkxyMsTtvbdVrzwrlWsikwxJT = (ibZtahtvWmapnbUIXggEwKXmKrDf)((buttonsBitMask & 2047) | (buttonsBitMask & (buttonsBitMask & -2048)) << 1);
			A_1.OGUiLWQFnXHErroZpEztgPpsOhCv = (short)(A_2.GetAxisValue(0) * 32768f);
			A_1.rBBJpYeIlFicadQiCZnkJFDUXlbeB = (short)(A_2.GetAxisValue(1) * 32768f);
			A_1.KDLajuQtUeOxGWDBdEvaBfXtDIMYA = (short)(A_2.GetAxisValue(2) * 32768f);
			A_1.uuSHzCjBmoOeAKIfXzTuhrQMsSJP = (short)(A_2.GetAxisValue(3) * 32768f);
			A_1.MVcLZUGquQThBbHpOHLoVtRZnUjn = (byte)(A_2.GetAxisValue(4) * 255f);
			A_1.ZkDNxPMbJFHhXTOvNSqOktzsjcsO = (byte)(A_2.GetAxisValue(5) * 255f);
		}

		// Token: 0x0600022D RID: 557 RVA: 0x0001279D File Offset: 0x0001099D
		private static bool PXwkocIJLDsczifjtIKzlYeuHvrX(int A_0, int A_1)
		{
			if (A_1 > 10)
			{
				A_1++;
			}
			return (A_0 & 1 << A_1) != 0;
		}

		// Token: 0x0600022E RID: 558 RVA: 0x00028CA0 File Offset: 0x00026EA0
		private void SdjExorqLhmYdppqrSPPSnngOGXD()
		{
			object obj = this.gOWrkOCzPdxhuhfgcYkfOeczGRHq;
			lock (obj)
			{
				this.oAnHbndTQTeuHDDvvRjesvJVrtVuA = default(dmHvWETeAqDVNTDczCTgCpqgchOO);
				this.pxyEKytUDLCWfokRAhZveCCEcQliA = default(dmHvWETeAqDVNTDczCTgCpqgchOO);
				this.ttGUArLFOTGPddiDjKafvjIbHKfn.Clear();
				this.MzDpSEZAlPwdHiSzdOqymyaSpguO.Clear();
			}
		}

		// Token: 0x0600022F RID: 559 RVA: 0x000127B4 File Offset: 0x000109B4
		public void Dispose()
		{
			this.lTftURFhSvaXCWaAghDVJMsUIspr(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06000230 RID: 560 RVA: 0x00028D08 File Offset: 0x00026F08
		protected virtual void ABnKYBCBHiPeWXGhXiCqFzwwCHwL()
		{
			try
			{
				this.lTftURFhSvaXCWaAghDVJMsUIspr(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		// Token: 0x06000231 RID: 561 RVA: 0x000127C3 File Offset: 0x000109C3
		protected virtual void lTftURFhSvaXCWaAghDVJMsUIspr(bool A_1)
		{
			if (this.vltehsCBevppZRrHnnsSaPOUbbDh)
			{
				return;
			}
			if (A_1)
			{
				this.MzDpSEZAlPwdHiSzdOqymyaSpguO.Dispose();
			}
			this.vltehsCBevppZRrHnnsSaPOUbbDh = true;
		}

		// Token: 0x06000232 RID: 562 RVA: 0x000127E3 File Offset: 0x000109E3
		public static float zcVgSFAXlmFUsCelhndQIEPAvfopc(int A_0)
		{
			if (A_0 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(A_0) / 32768f * (float)MathTools.Sign(A_0), -1f, 1f);
		}

		// Token: 0x06000233 RID: 563 RVA: 0x00012812 File Offset: 0x00010A12
		public static float OpNkEGTCAldhpXLQlYYYtbIvIeax(int A_0)
		{
			if (A_0 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(A_0) / 255f * (float)MathTools.Sign(A_0), -1f, 1f);
		}

		// Token: 0x06000234 RID: 564 RVA: 0x00028D38 File Offset: 0x00026F38
		private static bool ljkCnvbHSxtcCsCEWFWgAMthJfpOA(dmHvWETeAqDVNTDczCTgCpqgchOO A_0, dmHvWETeAqDVNTDczCTgCpqgchOO A_1)
		{
			return A_0.ixAwkxyMsTtvbdVrzwrlWsikwxJT == A_1.ixAwkxyMsTtvbdVrzwrlWsikwxJT && A_0.MVcLZUGquQThBbHpOHLoVtRZnUjn == A_1.MVcLZUGquQThBbHpOHLoVtRZnUjn && A_0.ZkDNxPMbJFHhXTOvNSqOktzsjcsO == A_1.ZkDNxPMbJFHhXTOvNSqOktzsjcsO && A_0.OGUiLWQFnXHErroZpEztgPpsOhCv == A_1.OGUiLWQFnXHErroZpEztgPpsOhCv && A_0.rBBJpYeIlFicadQiCZnkJFDUXlbeB == A_1.rBBJpYeIlFicadQiCZnkJFDUXlbeB && A_0.KDLajuQtUeOxGWDBdEvaBfXtDIMYA == A_1.KDLajuQtUeOxGWDBdEvaBfXtDIMYA && A_0.uuSHzCjBmoOeAKIfXzTuhrQMsSJP == A_1.uuSHzCjBmoOeAKIfXzTuhrQMsSJP;
		}

		// Token: 0x0400019B RID: 411
		public readonly zmDlVAYpiICKEnvrtEDAeKCAYFkVA YxhefCmxGIggoAMJkVFwlzXoLwY;

		// Token: 0x0400019C RID: 412
		private readonly Controller.Extension EnXsSUGYTweBetzEXKrCjBOJPmQT;

		// Token: 0x0400019D RID: 413
		public dmHvWETeAqDVNTDczCTgCpqgchOO oAnHbndTQTeuHDDvvRjesvJVrtVuA;

		// Token: 0x0400019E RID: 414
		private bool WoseqKeaSRqPPKjyXEkNLhEvMxwcA;

		// Token: 0x0400019F RID: 415
		private readonly ButtonLoopSet ttGUArLFOTGPddiDjKafvjIbHKfn;

		// Token: 0x040001A0 RID: 416
		private dmHvWETeAqDVNTDczCTgCpqgchOO pxyEKytUDLCWfokRAhZveCCEcQliA;

		// Token: 0x040001A1 RID: 417
		private bool lAlhsoIbJUIlZxGGtKWWDHjTdelDb;

		// Token: 0x040001A2 RID: 418
		private DualThreadLowLevelInputEventQueue MzDpSEZAlPwdHiSzdOqymyaSpguO;

		// Token: 0x040001A3 RID: 419
		private readonly object gOWrkOCzPdxhuhfgcYkfOeczGRHq;

		// Token: 0x040001A4 RID: 420
		private RingBuffer<ANKpkQVdjjJBZtpJglzmnbRRvFWL> dOBbCMuBQicMEbEhvDwNxGMAMEMJ = new RingBuffer<ANKpkQVdjjJBZtpJglzmnbRRvFWL>(5);

		// Token: 0x040001A5 RID: 421
		private RingBuffer<ANKpkQVdjjJBZtpJglzmnbRRvFWL> XXAGGVOKsQLrwIejPVThaMCtgYsr = new RingBuffer<ANKpkQVdjjJBZtpJglzmnbRRvFWL>(5);

		// Token: 0x040001A6 RID: 422
		private readonly object JjDjvSfIEfHAvFPfyGZULQeTYUFKA = new object();

		// Token: 0x040001A7 RID: 423
		private readonly object qqgDvPXNAcFvCLLUMnqNbYPFOxAA = new object();

		// Token: 0x040001A8 RID: 424
		private ANKpkQVdjjJBZtpJglzmnbRRvFWL MVUXAwsXIdDdihXSFrzFQUNEkYHr;

		// Token: 0x040001A9 RID: 425
		private double EyYMvABGXLpItgFGYHNThiBSHnioA;

		// Token: 0x040001AA RID: 426
		private bool vltehsCBevppZRrHnnsSaPOUbbDh;
	}

	// Token: 0x02000032 RID: 50
	public enum jJBXEoZkAKXDTtNyqJfJoCFZbYrA
	{
		// Token: 0x040001AC RID: 428
		Synchronous,
		// Token: 0x040001AD RID: 429
		Asynchronous
	}
}
