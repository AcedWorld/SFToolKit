using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired;
using Rewired.Config;
using Rewired.Data;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

// Token: 0x02000104 RID: 260
internal sealed class HEnwyLWfnrHknWieEccXGXTAawGsA : IDisposable
{
	// Token: 0x14000010 RID: 16
	// (add) Token: 0x0600089D RID: 2205 RVA: 0x0000956C File Offset: 0x0000776C
	// (remove) Token: 0x0600089E RID: 2206 RVA: 0x00009585 File Offset: 0x00007785
	public event Action<ControllerStatusChangedEventArgs> pDwLWQkBOFqFfqBGYCghPLcMsdAS
	{
		add
		{
			this.lQkbyfzBUbSxAISNiwEbPjbzfmWQ = (Action<ControllerStatusChangedEventArgs>)Delegate.Combine(this.lQkbyfzBUbSxAISNiwEbPjbzfmWQ, value);
		}
		remove
		{
			this.lQkbyfzBUbSxAISNiwEbPjbzfmWQ = (Action<ControllerStatusChangedEventArgs>)Delegate.Remove(this.lQkbyfzBUbSxAISNiwEbPjbzfmWQ, value);
		}
	}

	// Token: 0x14000011 RID: 17
	// (add) Token: 0x0600089F RID: 2207 RVA: 0x0000959E File Offset: 0x0000779E
	// (remove) Token: 0x060008A0 RID: 2208 RVA: 0x000095B7 File Offset: 0x000077B7
	public event Action<ControllerType, int> LtPhTCapaWOKhCGpZiSRAxvvkCdRA
	{
		add
		{
			this.FhsDKOndKmDeNLaHPEwpBBFWHSgUA = (Action<ControllerType, int>)Delegate.Combine(this.FhsDKOndKmDeNLaHPEwpBBFWHSgUA, value);
		}
		remove
		{
			this.FhsDKOndKmDeNLaHPEwpBBFWHSgUA = (Action<ControllerType, int>)Delegate.Remove(this.FhsDKOndKmDeNLaHPEwpBBFWHSgUA, value);
		}
	}

	// Token: 0x060008A1 RID: 2209 RVA: 0x00040CCC File Offset: 0x0003EECC
	public HEnwyLWfnrHknWieEccXGXTAawGsA(ConfigVars A_1, PlatformInputManager A_2)
	{
		this.HqZpEmBsNwuTnbacnIotwOqnKfTp = A_1;
		this.yQkfGpRvhkghPjMdVidnIowWWwFg = 0;
		this.UewCmdpRVVwdmfcVccVBYJYbWfSK = UnityTools.isAndroidPlatform;
		this.atgdJIInhyKudGsJgWEjzPkJWxsA = new List<Controller>(10);
		this.cdJAHwaJgeWdSGBRVkoZdzRUZfufA = new ReadOnlyCollection<Controller>(this.atgdJIInhyKudGsJgWEjzPkJWxsA);
		IUnifiedKeyboardSource unifiedKeyboardSource = A_2.GetUnifiedKeyboardSource();
		if (unifiedKeyboardSource == null)
		{
			unifiedKeyboardSource = new UnityUnifiedKeyboardSource();
			this.vmDLkaAYWRDTujFiAkNWylMcBFey = unifiedKeyboardSource;
		}
		this.SdKRHvJEjjZeHhCFxmZraUcsapNp = new Keyboard("Keyboard", unifiedKeyboardSource);
		this.atgdJIInhyKudGsJgWEjzPkJWxsA.Add(this.SdKRHvJEjjZeHhCFxmZraUcsapNp);
		IUnifiedMouseSource unifiedMouseSource = A_2.GetUnifiedMouseSource();
		if (unifiedMouseSource == null)
		{
			unifiedMouseSource = new UnityUnifiedMouseSource();
			this.bQDuYGBHgPzFQqadFeiDVQEVZBkL = unifiedMouseSource;
		}
		this.zLnHuARWczJYSeFmlVDbGirTcMwf = new Mouse("Mouse", unifiedMouseSource);
		this.atgdJIInhyKudGsJgWEjzPkJWxsA.Add(this.zLnHuARWczJYSeFmlVDbGirTcMwf);
		this.PanoIILHaUdGmkxoeFTsAzzMdTMx = new mEYbmhkubQXyWLdHdBzRRGwWDmxeb(A_1.updateLoop, this.SdKRHvJEjjZeHhCFxmZraUcsapNp);
		this.SdKRHvJEjjZeHhCFxmZraUcsapNp.MXqoczOdcBQjivZZflSxxfhRAvjCA += this.URorGKDFUVTczDVVQuGVDctGeRKN;
		this.SdKRHvJEjjZeHhCFxmZraUcsapNp.enabled = !A_1.GetPlatformVar_disableKeyboard();
		this.zLnHuARWczJYSeFmlVDbGirTcMwf.enabled = !A_1.GetPlatformVar_disableMouse();
		IOidQPQHzktCEcGgopnxdsRDcvvq.IhLxVghCXYhNXXvtbAuwqxvCAbIe();
		this.kCXvUIWYymbXvGdUklSrMIHzfawAA = new RXwELUeslTkclmlgxEgZCHffugOj(UnityTools.externalTools.GetControllerTemplateTypes(), UnityTools.externalTools.GetControllerTemplateInterfaceTypes());
		this.kCXvUIWYymbXvGdUklSrMIHzfawAA.zasBhsaAvoJpxZfKGoCjaYtFpigYB(this.SdKRHvJEjjZeHhCFxmZraUcsapNp);
		this.kCXvUIWYymbXvGdUklSrMIHzfawAA.zasBhsaAvoJpxZfKGoCjaYtFpigYB(this.zLnHuARWczJYSeFmlVDbGirTcMwf);
		ReInput.ApplicationFocusChangedEvent += this.StLQHEsupecGILHCrTzoJkAyGInC;
	}

	// Token: 0x170002AD RID: 685
	// (get) Token: 0x060008A2 RID: 2210 RVA: 0x000095D0 File Offset: 0x000077D0
	public IList<Joystick> pVKHDMxRDSNXQLeLUHNMTPLdCAPB
	{
		get
		{
			return this.vWecKCEQQBDkWSvtTltMphHdYlQmA;
		}
	}

	// Token: 0x170002AE RID: 686
	// (get) Token: 0x060008A3 RID: 2211 RVA: 0x000095D8 File Offset: 0x000077D8
	public List<Joystick> fqEvQQaBKLqEubxwxJMWRvHmBQPh
	{
		get
		{
			return this.UbwRgnOnrybDDRQGflveHOxETQxK;
		}
	}

	// Token: 0x170002AF RID: 687
	// (get) Token: 0x060008A4 RID: 2212 RVA: 0x000095E0 File Offset: 0x000077E0
	public int pkIsaLuBqwgPYsBLElovjkUtIZeo
	{
		get
		{
			return this.UbwRgnOnrybDDRQGflveHOxETQxK.Count;
		}
	}

	// Token: 0x170002B0 RID: 688
	// (get) Token: 0x060008A5 RID: 2213 RVA: 0x000095ED File Offset: 0x000077ED
	public Mouse XNgqEHDojgJjHnQkfggodEGufgWj
	{
		get
		{
			return this.zLnHuARWczJYSeFmlVDbGirTcMwf;
		}
	}

	// Token: 0x170002B1 RID: 689
	// (get) Token: 0x060008A6 RID: 2214 RVA: 0x000095F5 File Offset: 0x000077F5
	public Keyboard TaTrTHwUgSOiWrsYvUpTqAIgrPne
	{
		get
		{
			return this.SdKRHvJEjjZeHhCFxmZraUcsapNp;
		}
	}

	// Token: 0x170002B2 RID: 690
	// (get) Token: 0x060008A7 RID: 2215 RVA: 0x000095FD File Offset: 0x000077FD
	public IList<CustomController> ZdOnxkFcYHFlRBGFPcjfEWrunVkab
	{
		get
		{
			return this.zUSvEBgGkGUZOMjzscoKRGPnnVEq;
		}
	}

	// Token: 0x170002B3 RID: 691
	// (get) Token: 0x060008A8 RID: 2216 RVA: 0x00009605 File Offset: 0x00007805
	public List<CustomController> beJsISUNtIZeXuyDkBuhKBhAIxFp
	{
		get
		{
			return this.IjvYEbGJscNPgzZqTUAgbsHenfTr;
		}
	}

	// Token: 0x170002B4 RID: 692
	// (get) Token: 0x060008A9 RID: 2217 RVA: 0x0000960D File Offset: 0x0000780D
	public int EwaeQdbfxfQyCoKtMMZzrkzzXzav
	{
		get
		{
			return this.IjvYEbGJscNPgzZqTUAgbsHenfTr.Count;
		}
	}

	// Token: 0x060008AA RID: 2218 RVA: 0x0000961A File Offset: 0x0000781A
	public void okXfhEGQWJdcDOXIKcVCPRmxhajLA(Action<int, ControllerDataUpdater> A_1, List<InputBehavior> A_2)
	{
		this.qmvHlpKUStAEIqrItmRrKZSDebpe = A_1;
		this.IaSLoOJwKkaiUxpGjnXZZclhcFvx(A_2);
	}

	// Token: 0x060008AB RID: 2219 RVA: 0x00040E38 File Offset: 0x0003F038
	public void YueHljkoyTNDfTFawXsQRxgAFJOH(UpdateLoopType A_1)
	{
		IOidQPQHzktCEcGgopnxdsRDcvvq.HjKbQnyNoliBrnmJPOlKZCLlFEDg(A_1);
		if (this.SdKRHvJEjjZeHhCFxmZraUcsapNp.enabled)
		{
			this.PanoIILHaUdGmkxoeFTsAzzMdTMx.UCNOEjXTVKSEqDmaerbEPgbwvkOd(A_1);
		}
		this.sQNGOtCnqljathWNmBarbEnXRpROA(A_1);
		this.WDUmoVyWyyhuUkGKWiWxxRwZpikt(A_1);
		IOidQPQHzktCEcGgopnxdsRDcvvq.RivFzFVoJqaZVXoHSLNTwhNePzIu(A_1, ReInput.currentFrame);
		if (this.BqofeAJDdKsupXkLyIJNptjwMCxR)
		{
			this.NXPSWsQqbFgXfFbbBVpslOSEmsqU();
		}
	}

	// Token: 0x060008AC RID: 2220 RVA: 0x00040E8C File Offset: 0x0003F08C
	public iWmRLdlDqgwSNYjkwtUZeqvQOyqs fiLGJJdVcENVGgSJAtPxuPWNyVxq(int A_1, string A_2, bool A_3)
	{
		int num = this.duMGvhBQWmQOaNghmuoCtxbyHqRiA.RQShMPZqoxNyEuVIKrDaSdTQtHZy(A_2, A_3);
		if (num < 0)
		{
			return null;
		}
		if (A_1 == 9999999)
		{
			return this.UQCwBVDCQDdcEoJdAgkWSDLTzmNG[num];
		}
		if (A_1 < 0 || A_1 >= this.uwdJDUjGnCEspMlnHLCzeqqwGzYo)
		{
			return null;
		}
		return this.HgHEfKyJmTGNqsBkTNrgJKOPAwlBA[A_1, num];
	}

	// Token: 0x060008AD RID: 2221 RVA: 0x00040EDC File Offset: 0x0003F0DC
	public iWmRLdlDqgwSNYjkwtUZeqvQOyqs LkKjRklxnAokVkoNYSqTVxjiDyEd(int A_1, int A_2, bool A_3)
	{
		int num = this.duMGvhBQWmQOaNghmuoCtxbyHqRiA.GgcLbqsjISfcSHJvzXzdOFrEcGwSA(A_2, A_3);
		if (num < 0)
		{
			return null;
		}
		if (A_1 == 9999999)
		{
			return this.UQCwBVDCQDdcEoJdAgkWSDLTzmNG[num];
		}
		return this.HgHEfKyJmTGNqsBkTNrgJKOPAwlBA[A_1, num];
	}

	// Token: 0x060008AE RID: 2222 RVA: 0x00040F1C File Offset: 0x0003F11C
	public void EIdqjxTbBjDdvrJvmaWRQaGtrdPs(UpdateControllerInfoEventArgs A_1)
	{
		if (A_1 == null)
		{
			return;
		}
		if (A_1.sourceJoystick == null)
		{
			return;
		}
		HEnwyLWfnrHknWieEccXGXTAawGsA.KHCbyofpALMYVppWHChAOTYYCOJbb khcbyofpALMYVppWHChAOTYYCOJbb = HEnwyLWfnrHknWieEccXGXTAawGsA.KHCbyofpALMYVppWHChAOTYYCOJbb.Connected;
		int num = this.JlCdJQcivrExAbPrBEdlOYnesofSb(A_1.sourceJoystick.rewiredId, khcbyofpALMYVppWHChAOTYYCOJbb);
		if (num < 0)
		{
			khcbyofpALMYVppWHChAOTYYCOJbb = HEnwyLWfnrHknWieEccXGXTAawGsA.KHCbyofpALMYVppWHChAOTYYCOJbb.Disconnected;
			num = this.JlCdJQcivrExAbPrBEdlOYnesofSb(A_1.sourceJoystick.rewiredId, khcbyofpALMYVppWHChAOTYYCOJbb);
		}
		if (num < 0)
		{
			return;
		}
		((khcbyofpALMYVppWHChAOTYYCOJbb == HEnwyLWfnrHknWieEccXGXTAawGsA.KHCbyofpALMYVppWHChAOTYYCOJbb.Connected) ? this.UbwRgnOnrybDDRQGflveHOxETQxK[num] : this.rrwshdvoiWQuWIBqDKDLUyFIhZag[num]).IJOhYxqRBOGjaKvVYvqaHjEEAbAx(A_1);
	}

	// Token: 0x060008AF RID: 2223 RVA: 0x0000962A File Offset: 0x0000782A
	public bool GdeoUkoblZcOqjTtDczPzklLfMkgA(int A_1, HEnwyLWfnrHknWieEccXGXTAawGsA.KHCbyofpALMYVppWHChAOTYYCOJbb A_2)
	{
		return this.JlCdJQcivrExAbPrBEdlOYnesofSb(A_1, A_2) >= 0;
	}

	// Token: 0x060008B0 RID: 2224 RVA: 0x00040F8C File Offset: 0x0003F18C
	public int JlCdJQcivrExAbPrBEdlOYnesofSb(int A_1, HEnwyLWfnrHknWieEccXGXTAawGsA.KHCbyofpALMYVppWHChAOTYYCOJbb A_2)
	{
		if (A_2 == HEnwyLWfnrHknWieEccXGXTAawGsA.KHCbyofpALMYVppWHChAOTYYCOJbb.Connected)
		{
			int count = this.UbwRgnOnrybDDRQGflveHOxETQxK.Count;
			for (int i = 0; i < count; i++)
			{
				if (this.UbwRgnOnrybDDRQGflveHOxETQxK[i].id == A_1)
				{
					return i;
				}
			}
		}
		else if (A_2 == HEnwyLWfnrHknWieEccXGXTAawGsA.KHCbyofpALMYVppWHChAOTYYCOJbb.Disconnected)
		{
			int count2 = this.rrwshdvoiWQuWIBqDKDLUyFIhZag.Count;
			for (int j = 0; j < count2; j++)
			{
				if (this.rrwshdvoiWQuWIBqDKDLUyFIhZag[j].id == A_1)
				{
					return j;
				}
			}
		}
		return -1;
	}

	// Token: 0x060008B1 RID: 2225 RVA: 0x00041000 File Offset: 0x0003F200
	public int AwnuRROujGHelIRMCLPYCZEVmUGf(Guid A_1, HEnwyLWfnrHknWieEccXGXTAawGsA.KHCbyofpALMYVppWHChAOTYYCOJbb A_2)
	{
		if (A_2 == HEnwyLWfnrHknWieEccXGXTAawGsA.KHCbyofpALMYVppWHChAOTYYCOJbb.Connected)
		{
			int count = this.UbwRgnOnrybDDRQGflveHOxETQxK.Count;
			for (int i = 0; i < count; i++)
			{
				if (this.UbwRgnOnrybDDRQGflveHOxETQxK[i].deviceInstanceGuid == A_1)
				{
					return i;
				}
			}
		}
		else if (A_2 == HEnwyLWfnrHknWieEccXGXTAawGsA.KHCbyofpALMYVppWHChAOTYYCOJbb.Disconnected)
		{
			int count2 = this.rrwshdvoiWQuWIBqDKDLUyFIhZag.Count;
			for (int j = 0; j < count2; j++)
			{
				if (this.rrwshdvoiWQuWIBqDKDLUyFIhZag[j].deviceInstanceGuid == A_1)
				{
					return j;
				}
			}
		}
		return -1;
	}

	// Token: 0x060008B2 RID: 2226 RVA: 0x0000963A File Offset: 0x0000783A
	public bool ZlRACXdmflHUqACQXSWDLEHsAyVDA(int A_1)
	{
		return this.PBLKIEsDquLrztnzcdWvsuYXgYNp(A_1) >= 0;
	}

	// Token: 0x060008B3 RID: 2227 RVA: 0x00041080 File Offset: 0x0003F280
	public int PBLKIEsDquLrztnzcdWvsuYXgYNp(int A_1)
	{
		int count = this.IjvYEbGJscNPgzZqTUAgbsHenfTr.Count;
		for (int i = 0; i < count; i++)
		{
			if (this.IjvYEbGJscNPgzZqTUAgbsHenfTr[i].id == A_1)
			{
				return i;
			}
		}
		return -1;
	}

	// Token: 0x060008B4 RID: 2228 RVA: 0x000410BC File Offset: 0x0003F2BC
	public int GcYabZdFWRePnFTEiwvptcwbvIpCB(Guid A_1)
	{
		int count = this.IjvYEbGJscNPgzZqTUAgbsHenfTr.Count;
		for (int i = 0; i < count; i++)
		{
			if (this.IjvYEbGJscNPgzZqTUAgbsHenfTr[i].deviceInstanceGuid == A_1)
			{
				return i;
			}
		}
		return -1;
	}

	// Token: 0x060008B5 RID: 2229 RVA: 0x00009649 File Offset: 0x00007849
	public void aVioCFgQATfLSKSkCmWndqXWTaIU(BridgedController A_1)
	{
		this.lXZMupegzkfTfwnXVymiovlzRuPi(A_1);
	}

	// Token: 0x060008B6 RID: 2230 RVA: 0x00041100 File Offset: 0x0003F300
	public void bVMrllFgpwASiaOczVElCvZULZhQ(int A_1)
	{
		int num = this.JlCdJQcivrExAbPrBEdlOYnesofSb(A_1, HEnwyLWfnrHknWieEccXGXTAawGsA.KHCbyofpALMYVppWHChAOTYYCOJbb.Connected);
		this.wHjpRBCDSlCjiZfCkSAYsElAfxyf(num);
	}

	// Token: 0x060008B7 RID: 2231 RVA: 0x00041120 File Offset: 0x0003F320
	public int UOrjphQQxuWXARuoHlDOpjFNKtDf()
	{
		int num = this.yQkfGpRvhkghPjMdVidnIowWWwFg;
		this.yQkfGpRvhkghPjMdVidnIowWWwFg = num + 1;
		return num;
	}

	// Token: 0x060008B8 RID: 2232 RVA: 0x00009652 File Offset: 0x00007852
	public IList<InputBehavior> GQKrzCeHKYCGeeITLHuwkPHlAsjfA(int A_1)
	{
		if (!this.HofFVyzjUTYvxnDPlQfqEOFMQhhK.ContainsKey(A_1))
		{
			return new List<InputBehavior>();
		}
		return this.HofFVyzjUTYvxnDPlQfqEOFMQhhK[A_1].hYgdawDgHAudLSApZeXDPepHjMhtA;
	}

	// Token: 0x060008B9 RID: 2233 RVA: 0x00041140 File Offset: 0x0003F340
	public InputBehavior FWPTsWMVwaoDtMaEHkKjEPcsctDH(int A_1, string A_2)
	{
		if (A_2 == null || A_2 == string.Empty)
		{
			return null;
		}
		int inputBehaviorId = ReInput.mapping.GetInputBehaviorId(A_2);
		return this.EpjSylEaBjOfajGuxXTwARPJWJVB(A_1, inputBehaviorId);
	}

	// Token: 0x060008BA RID: 2234 RVA: 0x00041174 File Offset: 0x0003F374
	public InputBehavior EpjSylEaBjOfajGuxXTwARPJWJVB(int A_1, int A_2)
	{
		if (!this.HofFVyzjUTYvxnDPlQfqEOFMQhhK.ContainsKey(A_1))
		{
			return null;
		}
		IList<InputBehavior> hYgdawDgHAudLSApZeXDPepHjMhtA = this.HofFVyzjUTYvxnDPlQfqEOFMQhhK[A_1].hYgdawDgHAudLSApZeXDPepHjMhtA;
		for (int i = 0; i < hYgdawDgHAudLSApZeXDPepHjMhtA.Count; i++)
		{
			if (hYgdawDgHAudLSApZeXDPepHjMhtA[i].id == A_2)
			{
				return hYgdawDgHAudLSApZeXDPepHjMhtA[i];
			}
		}
		return null;
	}

	// Token: 0x060008BB RID: 2235 RVA: 0x000411CC File Offset: 0x0003F3CC
	public Joystick oyUTQmcDwKIecWNjUFSrDrvyaWIt(int A_1, bool A_2 = false)
	{
		int num = this.JlCdJQcivrExAbPrBEdlOYnesofSb(A_1, HEnwyLWfnrHknWieEccXGXTAawGsA.KHCbyofpALMYVppWHChAOTYYCOJbb.Connected);
		if (num >= 0)
		{
			return this.UbwRgnOnrybDDRQGflveHOxETQxK[num];
		}
		if (A_2)
		{
			num = this.JlCdJQcivrExAbPrBEdlOYnesofSb(A_1, HEnwyLWfnrHknWieEccXGXTAawGsA.KHCbyofpALMYVppWHChAOTYYCOJbb.Disconnected);
			if (num >= 0)
			{
				return this.rrwshdvoiWQuWIBqDKDLUyFIhZag[num];
			}
		}
		return null;
	}

	// Token: 0x060008BC RID: 2236 RVA: 0x00041214 File Offset: 0x0003F414
	public Joystick dbsJiAJLltaKkIUaZyEBKkVcyQFCA(Guid A_1, bool A_2 = false)
	{
		int num = this.AwnuRROujGHelIRMCLPYCZEVmUGf(A_1, HEnwyLWfnrHknWieEccXGXTAawGsA.KHCbyofpALMYVppWHChAOTYYCOJbb.Connected);
		if (num >= 0)
		{
			return this.UbwRgnOnrybDDRQGflveHOxETQxK[num];
		}
		if (A_2)
		{
			num = this.AwnuRROujGHelIRMCLPYCZEVmUGf(A_1, HEnwyLWfnrHknWieEccXGXTAawGsA.KHCbyofpALMYVppWHChAOTYYCOJbb.Disconnected);
			if (num >= 0)
			{
				return this.rrwshdvoiWQuWIBqDKDLUyFIhZag[num];
			}
		}
		return null;
	}

	// Token: 0x060008BD RID: 2237 RVA: 0x0004125C File Offset: 0x0003F45C
	public Joystick[] yLbSGGoPvwCuldbCkgQpouEcpNpAb()
	{
		int count = this.UbwRgnOnrybDDRQGflveHOxETQxK.Count;
		if (count == 0)
		{
			return EmptyObjects<Joystick>.array;
		}
		Joystick[] array = new Joystick[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = this.UbwRgnOnrybDDRQGflveHOxETQxK[i];
		}
		return array;
	}

	// Token: 0x060008BE RID: 2238 RVA: 0x000412A4 File Offset: 0x0003F4A4
	public string[] lWPGwIAhPvlPfCpbNiDcjgnnmDUi()
	{
		int count = this.UbwRgnOnrybDDRQGflveHOxETQxK.Count;
		if (count == 0)
		{
			return EmptyObjects<string>.array;
		}
		string[] array = new string[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = this.UbwRgnOnrybDDRQGflveHOxETQxK[i].name;
		}
		return array;
	}

	// Token: 0x060008BF RID: 2239 RVA: 0x000412F0 File Offset: 0x0003F4F0
	public CustomController CGFeZCblefkjIqYPzeUZrCOWCLtIA(int A_1)
	{
		int num = this.PBLKIEsDquLrztnzcdWvsuYXgYNp(A_1);
		if (num < 0)
		{
			return null;
		}
		return this.IjvYEbGJscNPgzZqTUAgbsHenfTr[num];
	}

	// Token: 0x060008C0 RID: 2240 RVA: 0x00041318 File Offset: 0x0003F518
	public CustomController PwLksqwODQHEybJuOmCaEEFtdTUd(Guid A_1)
	{
		int num = this.GcYabZdFWRePnFTEiwvptcwbvIpCB(A_1);
		if (num < 0)
		{
			return null;
		}
		return this.IjvYEbGJscNPgzZqTUAgbsHenfTr[num];
	}

	// Token: 0x060008C1 RID: 2241 RVA: 0x00041340 File Offset: 0x0003F540
	public CustomController[] BYLibMWgPJjjYfhcNFYVLPrpULQe()
	{
		int count = this.IjvYEbGJscNPgzZqTUAgbsHenfTr.Count;
		if (count == 0)
		{
			return EmptyObjects<CustomController>.array;
		}
		CustomController[] array = new CustomController[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = this.IjvYEbGJscNPgzZqTUAgbsHenfTr[i];
		}
		return array;
	}

	// Token: 0x060008C2 RID: 2242 RVA: 0x00041388 File Offset: 0x0003F588
	public string[] oYWYwumVaYkisWvtAOnkYcmcPdyN()
	{
		int count = this.IjvYEbGJscNPgzZqTUAgbsHenfTr.Count;
		if (count == 0)
		{
			return EmptyObjects<string>.array;
		}
		string[] array = new string[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = this.IjvYEbGJscNPgzZqTUAgbsHenfTr[i].name;
		}
		return array;
	}

	// Token: 0x060008C3 RID: 2243 RVA: 0x000413D4 File Offset: 0x0003F5D4
	public CustomController GtyAkWaziVlXmbaLqdOfAXlIROxMA(int A_1)
	{
		CustomController_Editor customControllerById = ReInput.UserData.GetCustomControllerById(A_1);
		if (customControllerById == null)
		{
			return null;
		}
		int hLdPkfJRBFIEOylPSwjSHXgpJjZK = this.GouGdvwOusEAihzGhYGvFOritjiG;
		CustomController customController = new CustomController(new huKiUXRfzpflYKKFNfZwEZCsaovIA
		{
			eOjfuHGRNiEwMvKMPnUoKrWRvQpY = InputSource.Custom,
			LrwDvShgEYSPEQswkNIZNFclDllr = customControllerById.descriptiveName,
			tHjBcYVSIYHuOUCvErhaIVHtCHNu = customControllerById.name,
			pViHeOXfMSLVoXztWupQWkZsWoUJ = customControllerById.axisCount,
			WLxxhKczmNfUGgARybzRCRnnRTuy = customControllerById.buttonCount,
			hLdPkfJRBFIEOylPSwjSHXgpJjZK = hLdPkfJRBFIEOylPSwjSHXgpJjZK,
			hXCjOcePxRDXAsQsmHmdSBGfeEeM = customControllerById.id,
			GdeEcpYTyFmSyouxkAegmkkymLxv = customControllerById.typeGuid,
			zQkfhPnLEnhuTMVsjblBIgueOrUd = customControllerById.id.ToString(),
			QbdCPGYevrtvtZZczPLgqboMFqPi = customControllerById.CreateGameHardwareMap()
		});
		this.EhCBQPlANWJfMtOqBDHLWAOrYmtW(customController);
		return customController;
	}

	// Token: 0x060008C4 RID: 2244 RVA: 0x00009679 File Offset: 0x00007879
	public bool bKGqngQuVXuCHtSngfDCwbrgHwFU(CustomController A_1)
	{
		return A_1 != null && this.EJikfdtgHrbfjjHeLYtjUNtGblFRA(A_1);
	}

	// Token: 0x060008C5 RID: 2245 RVA: 0x00041484 File Offset: 0x0003F684
	public CustomController xbSeuEzjzKWIfvLmTlQMeaaBueGX(int A_1)
	{
		int count = this.IjvYEbGJscNPgzZqTUAgbsHenfTr.Count;
		for (int i = 0; i < count; i++)
		{
			if (this.IjvYEbGJscNPgzZqTUAgbsHenfTr[i].sourceControllerId == A_1)
			{
				return this.IjvYEbGJscNPgzZqTUAgbsHenfTr[i];
			}
		}
		return null;
	}

	// Token: 0x060008C6 RID: 2246 RVA: 0x000414CC File Offset: 0x0003F6CC
	public CustomController YJMzGtLfMvrehGccWRPVUKZwjSFX(string A_1)
	{
		int count = this.IjvYEbGJscNPgzZqTUAgbsHenfTr.Count;
		for (int i = 0; i < count; i++)
		{
			if (this.IjvYEbGJscNPgzZqTUAgbsHenfTr[i].tag.Equals(A_1, StringComparison.OrdinalIgnoreCase))
			{
				return this.IjvYEbGJscNPgzZqTUAgbsHenfTr[i];
			}
		}
		return null;
	}

	// Token: 0x060008C7 RID: 2247 RVA: 0x00009687 File Offset: 0x00007887
	public IEnumerable<CustomController> mpDdGICtDtaisRbOrJVeQjCytZwDA(int A_1)
	{
		int count = this.IjvYEbGJscNPgzZqTUAgbsHenfTr.Count;
		int num;
		for (int i = 0; i < count; i = num + 1)
		{
			if (this.IjvYEbGJscNPgzZqTUAgbsHenfTr[i].sourceControllerId == A_1)
			{
				yield return this.IjvYEbGJscNPgzZqTUAgbsHenfTr[i];
			}
			num = i;
		}
		yield break;
	}

	// Token: 0x060008C8 RID: 2248 RVA: 0x0000969E File Offset: 0x0000789E
	public IEnumerable<CustomController> tSioixiCRqEaynCegcRpxfHUajOjA(string A_1)
	{
		int count = this.IjvYEbGJscNPgzZqTUAgbsHenfTr.Count;
		int num;
		for (int i = 0; i < count; i = num + 1)
		{
			if (this.IjvYEbGJscNPgzZqTUAgbsHenfTr[i].tag.Equals(A_1, StringComparison.OrdinalIgnoreCase))
			{
				yield return this.IjvYEbGJscNPgzZqTUAgbsHenfTr[i];
			}
			num = i;
		}
		yield break;
	}

	// Token: 0x170002B5 RID: 693
	// (get) Token: 0x060008C9 RID: 2249 RVA: 0x000096B5 File Offset: 0x000078B5
	public IList<Controller> wqkFZhZtKTLgLqQSMELHGRiyilJQ
	{
		get
		{
			return this.cdJAHwaJgeWdSGBRVkoZdzRUZfufA;
		}
	}

	// Token: 0x170002B6 RID: 694
	// (get) Token: 0x060008CA RID: 2250 RVA: 0x000096BD File Offset: 0x000078BD
	public int idDeJRYPRYBhwNhBGaLmQNoVmrev
	{
		get
		{
			return this.atgdJIInhyKudGsJgWEjzPkJWxsA.Count;
		}
	}

	// Token: 0x060008CB RID: 2251 RVA: 0x000096CA File Offset: 0x000078CA
	public Controller YCdAacShUnGEqBEtkCPIWZicyHmg(ControllerType A_1, int A_2, bool A_3 = false)
	{
		switch (A_1)
		{
		case ControllerType.Keyboard:
			return this.SdKRHvJEjjZeHhCFxmZraUcsapNp;
		case ControllerType.Mouse:
			return this.zLnHuARWczJYSeFmlVDbGirTcMwf;
		case ControllerType.Joystick:
			return this.oyUTQmcDwKIecWNjUFSrDrvyaWIt(A_2, A_3);
		default:
			if (A_1 != ControllerType.Custom)
			{
				throw new NotImplementedException();
			}
			return this.CGFeZCblefkjIqYPzeUZrCOWCLtIA(A_2);
		}
	}

	// Token: 0x060008CC RID: 2252 RVA: 0x0004151C File Offset: 0x0003F71C
	public Controller GjbnKwfEMhCIAztPvPYKgnLKAipL(ControllerIdentifier A_1, bool A_2 = false)
	{
		if (A_1.deviceInstanceGuid != Guid.Empty)
		{
			return this.rgGJEyBvSdpmYgASycYruCWouOjc(A_1.deviceInstanceGuid, false);
		}
		if (A_1.controllerId >= 0)
		{
			return this.YCdAacShUnGEqBEtkCPIWZicyHmg(A_1.controllerType, A_1.controllerId, A_2);
		}
		return null;
	}

	// Token: 0x060008CD RID: 2253 RVA: 0x0004156C File Offset: 0x0003F76C
	public Controller rgGJEyBvSdpmYgASycYruCWouOjc(Guid A_1, bool A_2 = false)
	{
		if (A_1 == Guid.Empty)
		{
			return null;
		}
		if (this.SdKRHvJEjjZeHhCFxmZraUcsapNp.deviceInstanceGuid == A_1)
		{
			return this.SdKRHvJEjjZeHhCFxmZraUcsapNp;
		}
		if (this.zLnHuARWczJYSeFmlVDbGirTcMwf.deviceInstanceGuid == A_1)
		{
			return this.zLnHuARWczJYSeFmlVDbGirTcMwf;
		}
		Controller result;
		if ((result = this.dbsJiAJLltaKkIUaZyEBKkVcyQFCA(A_1, A_2)) != null)
		{
			return result;
		}
		if ((result = this.PwLksqwODQHEybJuOmCaEEFtdTUd(A_1)) != null)
		{
			return result;
		}
		return null;
	}

	// Token: 0x060008CE RID: 2254 RVA: 0x000415D8 File Offset: 0x0003F7D8
	public Controller[] bYOYutLrOOZASZuCWCqcJTuqJnoh(ControllerType A_1)
	{
		switch (A_1)
		{
		case ControllerType.Keyboard:
			return new Controller[]
			{
				this.SdKRHvJEjjZeHhCFxmZraUcsapNp
			};
		case ControllerType.Mouse:
			return new Controller[]
			{
				this.zLnHuARWczJYSeFmlVDbGirTcMwf
			};
		case ControllerType.Joystick:
			return this.yLbSGGoPvwCuldbCkgQpouEcpNpAb();
		default:
			if (A_1 != ControllerType.Custom)
			{
				throw new NotImplementedException();
			}
			return this.BYLibMWgPJjjYfhcNFYVLPrpULQe();
		}
	}

	// Token: 0x060008CF RID: 2255 RVA: 0x00041638 File Offset: 0x0003F838
	public string[] lGzUuGUXGNMDDbWKiZEwjLHOjzt(ControllerType A_1)
	{
		switch (A_1)
		{
		case ControllerType.Keyboard:
			return new string[]
			{
				this.SdKRHvJEjjZeHhCFxmZraUcsapNp.name
			};
		case ControllerType.Mouse:
			return new string[]
			{
				this.zLnHuARWczJYSeFmlVDbGirTcMwf.name
			};
		case ControllerType.Joystick:
			return this.lWPGwIAhPvlPfCpbNiDcjgnnmDUi();
		default:
			if (A_1 != ControllerType.Custom)
			{
				throw new NotImplementedException();
			}
			return this.oYWYwumVaYkisWvtAOnkYcmcPdyN();
		}
	}

	// Token: 0x060008D0 RID: 2256 RVA: 0x0004169C File Offset: 0x0003F89C
	public void vTnbusDrRofmNosKerOafyqkdkApA(int A_1, Action<InputActionEventData> A_2, UpdateLoopType A_3)
	{
		if (!this.PHTphyfeVEZEPCHwKVXYfBXaJwCB)
		{
			this.PHTphyfeVEZEPCHwKVXYfBXaJwCB = true;
		}
		EDsbfoobWXwcKBvvNHVrQUZhEIkn edsbfoobWXwcKBvvNHVrQUZhEIkn = this.dwdExKMowWCjiiUyErsovVpheypcA(A_1);
		if (edsbfoobWXwcKBvvNHVrQUZhEIkn == null)
		{
			return;
		}
		edsbfoobWXwcKBvvNHVrQUZhEIkn.fNhbpLEVNSnTCKazlPYfPXCmHhBW(A_2, A_3, InputActionEventType.Update, null);
	}

	// Token: 0x060008D1 RID: 2257 RVA: 0x000416D0 File Offset: 0x0003F8D0
	public void HcrCEzfnUdPbIymfGHEFHHdjKgvxA(int A_1, Action<InputActionEventData> A_2, UpdateLoopType A_3, int A_4)
	{
		if (!this.PHTphyfeVEZEPCHwKVXYfBXaJwCB)
		{
			this.PHTphyfeVEZEPCHwKVXYfBXaJwCB = true;
		}
		EDsbfoobWXwcKBvvNHVrQUZhEIkn edsbfoobWXwcKBvvNHVrQUZhEIkn = this.dwdExKMowWCjiiUyErsovVpheypcA(A_1);
		if (edsbfoobWXwcKBvvNHVrQUZhEIkn == null)
		{
			return;
		}
		edsbfoobWXwcKBvvNHVrQUZhEIkn.TcNARvDvKIxGffnLFhDNJGHZhBzY(A_2, A_3, InputActionEventType.Update, A_4, null);
	}

	// Token: 0x060008D2 RID: 2258 RVA: 0x00041704 File Offset: 0x0003F904
	public void XRPTjevOvOaXiPbHLCgWHPAzntOg(int A_1, Action<InputActionEventData> A_2, UpdateLoopType A_3, string A_4)
	{
		if (!this.PHTphyfeVEZEPCHwKVXYfBXaJwCB)
		{
			this.PHTphyfeVEZEPCHwKVXYfBXaJwCB = true;
		}
		int num = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(A_4, false);
		if (num < 0)
		{
			return;
		}
		this.HcrCEzfnUdPbIymfGHEFHHdjKgvxA(A_1, A_2, A_3, num);
	}

	// Token: 0x060008D3 RID: 2259 RVA: 0x00041740 File Offset: 0x0003F940
	public void NGJWVZRCNKHNwXgxiGvYcKCOeKAW(int A_1, Action<InputActionEventData> A_2, UpdateLoopType A_3, InputActionEventType A_4, object[] A_5)
	{
		if (!this.PHTphyfeVEZEPCHwKVXYfBXaJwCB)
		{
			this.PHTphyfeVEZEPCHwKVXYfBXaJwCB = true;
		}
		EDsbfoobWXwcKBvvNHVrQUZhEIkn edsbfoobWXwcKBvvNHVrQUZhEIkn = this.dwdExKMowWCjiiUyErsovVpheypcA(A_1);
		if (edsbfoobWXwcKBvvNHVrQUZhEIkn == null)
		{
			return;
		}
		edsbfoobWXwcKBvvNHVrQUZhEIkn.fNhbpLEVNSnTCKazlPYfPXCmHhBW(A_2, A_3, A_4, A_5);
	}

	// Token: 0x060008D4 RID: 2260 RVA: 0x00041774 File Offset: 0x0003F974
	public void MfGHPrfwRvhfpRvBcAEVSURLbbpc(int A_1, Action<InputActionEventData> A_2, UpdateLoopType A_3, InputActionEventType A_4, int A_5, object[] A_6)
	{
		if (!this.PHTphyfeVEZEPCHwKVXYfBXaJwCB)
		{
			this.PHTphyfeVEZEPCHwKVXYfBXaJwCB = true;
		}
		EDsbfoobWXwcKBvvNHVrQUZhEIkn edsbfoobWXwcKBvvNHVrQUZhEIkn = this.dwdExKMowWCjiiUyErsovVpheypcA(A_1);
		if (edsbfoobWXwcKBvvNHVrQUZhEIkn == null)
		{
			return;
		}
		edsbfoobWXwcKBvvNHVrQUZhEIkn.TcNARvDvKIxGffnLFhDNJGHZhBzY(A_2, A_3, A_4, A_5, A_6);
	}

	// Token: 0x060008D5 RID: 2261 RVA: 0x000417AC File Offset: 0x0003F9AC
	public void JXSxmWCBEIGYsrCwhDyLuGfcrQqH(int A_1, Action<InputActionEventData> A_2, UpdateLoopType A_3, InputActionEventType A_4, string A_5, object[] A_6)
	{
		if (!this.PHTphyfeVEZEPCHwKVXYfBXaJwCB)
		{
			this.PHTphyfeVEZEPCHwKVXYfBXaJwCB = true;
		}
		int num = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(A_5, false);
		if (num < 0)
		{
			return;
		}
		this.MfGHPrfwRvhfpRvBcAEVSURLbbpc(A_1, A_2, A_3, A_4, num, A_6);
	}

	// Token: 0x060008D6 RID: 2262 RVA: 0x000417EC File Offset: 0x0003F9EC
	public void BhKaSrCZQHKgxCsCjmQxCVSAaYFi(int A_1, Action<InputActionEventData> A_2)
	{
		EDsbfoobWXwcKBvvNHVrQUZhEIkn edsbfoobWXwcKBvvNHVrQUZhEIkn = this.dwdExKMowWCjiiUyErsovVpheypcA(A_1);
		if (edsbfoobWXwcKBvvNHVrQUZhEIkn == null)
		{
			return;
		}
		edsbfoobWXwcKBvvNHVrQUZhEIkn.aKlPrLhWNDpBllATLzxbtoiGoeMD(A_2);
	}

	// Token: 0x060008D7 RID: 2263 RVA: 0x0004180C File Offset: 0x0003FA0C
	public void ZYghHiKYAMGgVAwEsmxTpYNEaHaQ(int A_1, Action<InputActionEventData> A_2, int A_3)
	{
		EDsbfoobWXwcKBvvNHVrQUZhEIkn edsbfoobWXwcKBvvNHVrQUZhEIkn = this.dwdExKMowWCjiiUyErsovVpheypcA(A_1);
		if (edsbfoobWXwcKBvvNHVrQUZhEIkn == null)
		{
			return;
		}
		edsbfoobWXwcKBvvNHVrQUZhEIkn.sXWgAQJblgqZOPXEzLnjLKQmLywbb(A_2, A_3);
	}

	// Token: 0x060008D8 RID: 2264 RVA: 0x00041830 File Offset: 0x0003FA30
	public void isWuAWGKMQzcspWAnWhvVcTVPCqI(int A_1, Action<InputActionEventData> A_2, string A_3)
	{
		int num = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(A_3, false);
		if (num < 0)
		{
			return;
		}
		this.ZYghHiKYAMGgVAwEsmxTpYNEaHaQ(A_1, A_2, num);
	}

	// Token: 0x060008D9 RID: 2265 RVA: 0x00041858 File Offset: 0x0003FA58
	public void zaLyovAUdvqWrEPMoEfyNOTEtdQA(int A_1, Action<InputActionEventData> A_2, UpdateLoopType A_3)
	{
		EDsbfoobWXwcKBvvNHVrQUZhEIkn edsbfoobWXwcKBvvNHVrQUZhEIkn = this.dwdExKMowWCjiiUyErsovVpheypcA(A_1);
		if (edsbfoobWXwcKBvvNHVrQUZhEIkn == null)
		{
			return;
		}
		edsbfoobWXwcKBvvNHVrQUZhEIkn.ghUGCTAKryLQFcvSzFIafGwncrWR(A_2, A_3);
	}

	// Token: 0x060008DA RID: 2266 RVA: 0x0004187C File Offset: 0x0003FA7C
	public void gWNOxxzpPutiFCdDdhQsKiFxmDeOA(int A_1, Action<InputActionEventData> A_2, InputActionEventType A_3)
	{
		EDsbfoobWXwcKBvvNHVrQUZhEIkn edsbfoobWXwcKBvvNHVrQUZhEIkn = this.dwdExKMowWCjiiUyErsovVpheypcA(A_1);
		if (edsbfoobWXwcKBvvNHVrQUZhEIkn == null)
		{
			return;
		}
		edsbfoobWXwcKBvvNHVrQUZhEIkn.dRqvjvEIijZaajZZtJtWeThJtxjr(A_2, A_3);
	}

	// Token: 0x060008DB RID: 2267 RVA: 0x000418A0 File Offset: 0x0003FAA0
	public void EyyHLKOFulGcGVGEOdWNcGKpjYrL(int A_1, Action<InputActionEventData> A_2, UpdateLoopType A_3, int A_4)
	{
		EDsbfoobWXwcKBvvNHVrQUZhEIkn edsbfoobWXwcKBvvNHVrQUZhEIkn = this.dwdExKMowWCjiiUyErsovVpheypcA(A_1);
		if (edsbfoobWXwcKBvvNHVrQUZhEIkn == null)
		{
			return;
		}
		edsbfoobWXwcKBvvNHVrQUZhEIkn.fWaXpZQfEjIMvrMtiixwKVBOAIwG(A_2, A_3, A_4);
	}

	// Token: 0x060008DC RID: 2268 RVA: 0x000418C4 File Offset: 0x0003FAC4
	public void dcoyODgVDzPeJvHzwNoZDwckeqxW(int A_1, Action<InputActionEventData> A_2, UpdateLoopType A_3, string A_4)
	{
		int num = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(A_4, false);
		if (num < 0)
		{
			return;
		}
		this.EyyHLKOFulGcGVGEOdWNcGKpjYrL(A_1, A_2, A_3, num);
	}

	// Token: 0x060008DD RID: 2269 RVA: 0x000418F0 File Offset: 0x0003FAF0
	public void kZPGIGDqNztslErkuJqpsdHjpyvN(int A_1, Action<InputActionEventData> A_2, InputActionEventType A_3, int A_4)
	{
		EDsbfoobWXwcKBvvNHVrQUZhEIkn edsbfoobWXwcKBvvNHVrQUZhEIkn = this.dwdExKMowWCjiiUyErsovVpheypcA(A_1);
		if (edsbfoobWXwcKBvvNHVrQUZhEIkn == null)
		{
			return;
		}
		edsbfoobWXwcKBvvNHVrQUZhEIkn.NhRaRtGtbOtwKsMEefGXFbcUHutMA(A_2, A_3, A_4);
	}

	// Token: 0x060008DE RID: 2270 RVA: 0x00041914 File Offset: 0x0003FB14
	public void lOnmzWvdoUMMCOkjsLrobnkkLVvA(int A_1, Action<InputActionEventData> A_2, InputActionEventType A_3, string A_4)
	{
		int num = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(A_4, false);
		if (num < 0)
		{
			return;
		}
		this.kZPGIGDqNztslErkuJqpsdHjpyvN(A_1, A_2, A_3, num);
	}

	// Token: 0x060008DF RID: 2271 RVA: 0x00041940 File Offset: 0x0003FB40
	public void yKepZpVEJCWdrmTcCxzrocEgCxXu(int A_1, Action<InputActionEventData> A_2, UpdateLoopType A_3, InputActionEventType A_4)
	{
		EDsbfoobWXwcKBvvNHVrQUZhEIkn edsbfoobWXwcKBvvNHVrQUZhEIkn = this.dwdExKMowWCjiiUyErsovVpheypcA(A_1);
		if (edsbfoobWXwcKBvvNHVrQUZhEIkn == null)
		{
			return;
		}
		edsbfoobWXwcKBvvNHVrQUZhEIkn.JsNNOYtGIYKigpakEbftqksoiwwA(A_2, A_3, A_4);
	}

	// Token: 0x060008E0 RID: 2272 RVA: 0x00041964 File Offset: 0x0003FB64
	public void mPviolknEDCXUoMTcFNZAZhtrDrtA(int A_1, Action<InputActionEventData> A_2, UpdateLoopType A_3, InputActionEventType A_4, int A_5)
	{
		EDsbfoobWXwcKBvvNHVrQUZhEIkn edsbfoobWXwcKBvvNHVrQUZhEIkn = this.dwdExKMowWCjiiUyErsovVpheypcA(A_1);
		if (edsbfoobWXwcKBvvNHVrQUZhEIkn == null)
		{
			return;
		}
		edsbfoobWXwcKBvvNHVrQUZhEIkn.hoSpDQKBahNwaMaqNcaQciMEUzTy(A_2, A_3, A_4, A_5);
	}

	// Token: 0x060008E1 RID: 2273 RVA: 0x0004198C File Offset: 0x0003FB8C
	public void KiIDnwnlnMXLubunaNfIfclKNqbX(int A_1, Action<InputActionEventData> A_2, UpdateLoopType A_3, InputActionEventType A_4, string A_5)
	{
		int num = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc.qZRRqCqTLqxYFDLDCauSXNdaVpPA(A_5, false);
		if (num < 0)
		{
			return;
		}
		this.mPviolknEDCXUoMTcFNZAZhtrDrtA(A_1, A_2, A_3, A_4, num);
	}

	// Token: 0x060008E2 RID: 2274 RVA: 0x000419B8 File Offset: 0x0003FBB8
	public void KYmAypTqYCeCpNZfpglURgHIzmcw(int A_1)
	{
		EDsbfoobWXwcKBvvNHVrQUZhEIkn edsbfoobWXwcKBvvNHVrQUZhEIkn = this.dwdExKMowWCjiiUyErsovVpheypcA(A_1);
		if (edsbfoobWXwcKBvvNHVrQUZhEIkn == null)
		{
			return;
		}
		edsbfoobWXwcKBvvNHVrQUZhEIkn.StdAWPUyotLZUXBheXfqknuHIBxn();
	}

	// Token: 0x060008E3 RID: 2275 RVA: 0x000419D8 File Offset: 0x0003FBD8
	public bool xggYPWOMwlNTEiiisWdhOrrivnfC(int A_1)
	{
		if (A_1 == 9999999)
		{
			for (int i = 0; i < this.UQCwBVDCQDdcEoJdAgkWSDLTzmNG.Length; i++)
			{
				if (this.UQCwBVDCQDdcEoJdAgkWSDLTzmNG[i].PLEzowLfRVYnmqUhFdELfVgtLRUU())
				{
					return true;
				}
			}
			return false;
		}
		if (A_1 < 0 || A_1 >= this.uwdJDUjGnCEspMlnHLCzeqqwGzYo)
		{
			return false;
		}
		int num = this.duMGvhBQWmQOaNghmuoCtxbyHqRiA.gdtJMdYGqGLjogQUyQYoOeTeKURk;
		for (int j = 0; j < num; j++)
		{
			if (this.HgHEfKyJmTGNqsBkTNrgJKOPAwlBA[A_1, j].PLEzowLfRVYnmqUhFdELfVgtLRUU())
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060008E4 RID: 2276 RVA: 0x00041A54 File Offset: 0x0003FC54
	public bool dOltNIBvxPYKMWlPDYIPInIopgMA(int A_1)
	{
		if (A_1 == 9999999)
		{
			for (int i = 0; i < this.UQCwBVDCQDdcEoJdAgkWSDLTzmNG.Length; i++)
			{
				if (this.UQCwBVDCQDdcEoJdAgkWSDLTzmNG[i].cgnNvIBXdjcArepYxqVhcluOaiAF())
				{
					return true;
				}
			}
			return false;
		}
		if (A_1 < 0 || A_1 >= this.uwdJDUjGnCEspMlnHLCzeqqwGzYo)
		{
			return false;
		}
		int num = this.duMGvhBQWmQOaNghmuoCtxbyHqRiA.gdtJMdYGqGLjogQUyQYoOeTeKURk;
		for (int j = 0; j < num; j++)
		{
			if (this.HgHEfKyJmTGNqsBkTNrgJKOPAwlBA[A_1, j].cgnNvIBXdjcArepYxqVhcluOaiAF())
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060008E5 RID: 2277 RVA: 0x00041AD0 File Offset: 0x0003FCD0
	public bool iHobkAoxVdbulWoOzszNZfmhHRQX(int A_1)
	{
		if (A_1 == 9999999)
		{
			for (int i = 0; i < this.UQCwBVDCQDdcEoJdAgkWSDLTzmNG.Length; i++)
			{
				if (this.UQCwBVDCQDdcEoJdAgkWSDLTzmNG[i].iqpRhWPPruMPiSurJSIiJhNgoOiO())
				{
					return true;
				}
			}
			return false;
		}
		if (A_1 < 0 || A_1 >= this.uwdJDUjGnCEspMlnHLCzeqqwGzYo)
		{
			return false;
		}
		int num = this.duMGvhBQWmQOaNghmuoCtxbyHqRiA.gdtJMdYGqGLjogQUyQYoOeTeKURk;
		for (int j = 0; j < num; j++)
		{
			if (this.HgHEfKyJmTGNqsBkTNrgJKOPAwlBA[A_1, j].iqpRhWPPruMPiSurJSIiJhNgoOiO())
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060008E6 RID: 2278 RVA: 0x00041B4C File Offset: 0x0003FD4C
	public bool svsbnusNGPDJEwchqwzDgakkASfM(int A_1)
	{
		if (A_1 == 9999999)
		{
			for (int i = 0; i < this.UQCwBVDCQDdcEoJdAgkWSDLTzmNG.Length; i++)
			{
				if (this.UQCwBVDCQDdcEoJdAgkWSDLTzmNG[i].oFwEbOzifvsGVUHSHODNgMNlGvzcA())
				{
					return true;
				}
			}
			return false;
		}
		if (A_1 < 0 || A_1 >= this.uwdJDUjGnCEspMlnHLCzeqqwGzYo)
		{
			return false;
		}
		int num = this.duMGvhBQWmQOaNghmuoCtxbyHqRiA.gdtJMdYGqGLjogQUyQYoOeTeKURk;
		for (int j = 0; j < num; j++)
		{
			if (this.HgHEfKyJmTGNqsBkTNrgJKOPAwlBA[A_1, j].oFwEbOzifvsGVUHSHODNgMNlGvzcA())
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060008E7 RID: 2279 RVA: 0x00041BC8 File Offset: 0x0003FDC8
	public bool kuhkDAnKdcHRkjBNxLuLGcDAdtkS(int A_1)
	{
		if (A_1 == 9999999)
		{
			for (int i = 0; i < this.UQCwBVDCQDdcEoJdAgkWSDLTzmNG.Length; i++)
			{
				if (this.UQCwBVDCQDdcEoJdAgkWSDLTzmNG[i].HWGpqzxmCQzoZIFrUhOuHScOhfbr())
				{
					return true;
				}
			}
			return false;
		}
		if (A_1 < 0 || A_1 >= this.uwdJDUjGnCEspMlnHLCzeqqwGzYo)
		{
			return false;
		}
		int num = this.duMGvhBQWmQOaNghmuoCtxbyHqRiA.gdtJMdYGqGLjogQUyQYoOeTeKURk;
		for (int j = 0; j < num; j++)
		{
			if (this.HgHEfKyJmTGNqsBkTNrgJKOPAwlBA[A_1, j].HWGpqzxmCQzoZIFrUhOuHScOhfbr())
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060008E8 RID: 2280 RVA: 0x00041C44 File Offset: 0x0003FE44
	public bool zEMPHBGiNgGXnWNQGHsQCOUnhJeC(int A_1)
	{
		if (A_1 == 9999999)
		{
			for (int i = 0; i < this.UQCwBVDCQDdcEoJdAgkWSDLTzmNG.Length; i++)
			{
				if (this.UQCwBVDCQDdcEoJdAgkWSDLTzmNG[i].DEqKIDythebfGxHycCDdFiTYHWfF())
				{
					return true;
				}
			}
			return false;
		}
		if (A_1 < 0 || A_1 >= this.uwdJDUjGnCEspMlnHLCzeqqwGzYo)
		{
			return false;
		}
		int num = this.duMGvhBQWmQOaNghmuoCtxbyHqRiA.gdtJMdYGqGLjogQUyQYoOeTeKURk;
		for (int j = 0; j < num; j++)
		{
			if (this.HgHEfKyJmTGNqsBkTNrgJKOPAwlBA[A_1, j].DEqKIDythebfGxHycCDdFiTYHWfF())
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060008E9 RID: 2281 RVA: 0x00041CC0 File Offset: 0x0003FEC0
	public bool pNkCqTBJooMzzELsONmDFoOyeHRrA(int A_1)
	{
		if (A_1 == 9999999)
		{
			for (int i = 0; i < this.UQCwBVDCQDdcEoJdAgkWSDLTzmNG.Length; i++)
			{
				if (this.UQCwBVDCQDdcEoJdAgkWSDLTzmNG[i].YJetLbybKqkFHlIxOBMORKTNchaY())
				{
					return true;
				}
			}
			return false;
		}
		if (A_1 < 0 || A_1 >= this.uwdJDUjGnCEspMlnHLCzeqqwGzYo)
		{
			return false;
		}
		int num = this.duMGvhBQWmQOaNghmuoCtxbyHqRiA.gdtJMdYGqGLjogQUyQYoOeTeKURk;
		for (int j = 0; j < num; j++)
		{
			if (this.HgHEfKyJmTGNqsBkTNrgJKOPAwlBA[A_1, j].YJetLbybKqkFHlIxOBMORKTNchaY())
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060008EA RID: 2282 RVA: 0x00041D3C File Offset: 0x0003FF3C
	public bool EkxkKklKQKOJdyFjLBtpdDvvxFIC(int A_1)
	{
		if (A_1 == 9999999)
		{
			for (int i = 0; i < this.UQCwBVDCQDdcEoJdAgkWSDLTzmNG.Length; i++)
			{
				if (this.UQCwBVDCQDdcEoJdAgkWSDLTzmNG[i].pJdNBJgzCniVonEUxixmJoDFVzqI())
				{
					return true;
				}
			}
			return false;
		}
		if (A_1 < 0 || A_1 >= this.uwdJDUjGnCEspMlnHLCzeqqwGzYo)
		{
			return false;
		}
		int num = this.duMGvhBQWmQOaNghmuoCtxbyHqRiA.gdtJMdYGqGLjogQUyQYoOeTeKURk;
		for (int j = 0; j < num; j++)
		{
			if (this.HgHEfKyJmTGNqsBkTNrgJKOPAwlBA[A_1, j].pJdNBJgzCniVonEUxixmJoDFVzqI())
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060008EB RID: 2283 RVA: 0x00009709 File Offset: 0x00007909
	public bool FRBdsaSKhNDXuArVlzZPneOlYcZh()
	{
		return this.aHHJbZMQufKuRfANsHriAkDBLGCAb(this.zLnHuARWczJYSeFmlVDbGirTcMwf) || this.OVuoEpEkOvfeTkReWYQaApxJhhyEb<Joystick>(this.UbwRgnOnrybDDRQGflveHOxETQxK) || this.aHHJbZMQufKuRfANsHriAkDBLGCAb(this.SdKRHvJEjjZeHhCFxmZraUcsapNp) || this.OVuoEpEkOvfeTkReWYQaApxJhhyEb<CustomController>(this.IjvYEbGJscNPgzZqTUAgbsHenfTr);
	}

	// Token: 0x060008EC RID: 2284 RVA: 0x00041DB8 File Offset: 0x0003FFB8
	public bool qYwhdRZzdLdSmcczraAAHoRuyactA(ControllerType A_1)
	{
		switch (A_1)
		{
		case ControllerType.Keyboard:
			return this.aHHJbZMQufKuRfANsHriAkDBLGCAb(this.SdKRHvJEjjZeHhCFxmZraUcsapNp);
		case ControllerType.Mouse:
			return this.aHHJbZMQufKuRfANsHriAkDBLGCAb(this.zLnHuARWczJYSeFmlVDbGirTcMwf);
		case ControllerType.Joystick:
			return this.OVuoEpEkOvfeTkReWYQaApxJhhyEb<Joystick>(this.UbwRgnOnrybDDRQGflveHOxETQxK);
		default:
			if (A_1 != ControllerType.Custom)
			{
				throw new NotImplementedException();
			}
			return this.OVuoEpEkOvfeTkReWYQaApxJhhyEb<CustomController>(this.IjvYEbGJscNPgzZqTUAgbsHenfTr);
		}
	}

	// Token: 0x060008ED RID: 2285 RVA: 0x00009743 File Offset: 0x00007943
	public bool czGjZJoPxfbWBlRobbsAcfNJiScgA()
	{
		return this.kDHMhecsswEZdNyXmTOdRqQYqusu(this.zLnHuARWczJYSeFmlVDbGirTcMwf) || this.iihPohjZsjOdlAXDIUJamWVfagPQ<Joystick>(this.UbwRgnOnrybDDRQGflveHOxETQxK) || this.kDHMhecsswEZdNyXmTOdRqQYqusu(this.SdKRHvJEjjZeHhCFxmZraUcsapNp) || this.iihPohjZsjOdlAXDIUJamWVfagPQ<CustomController>(this.IjvYEbGJscNPgzZqTUAgbsHenfTr);
	}

	// Token: 0x060008EE RID: 2286 RVA: 0x00041E18 File Offset: 0x00040018
	public bool xshsiejjTvwsxBGfhwNdPLmvquoe(ControllerType A_1)
	{
		switch (A_1)
		{
		case ControllerType.Keyboard:
			return this.kDHMhecsswEZdNyXmTOdRqQYqusu(this.SdKRHvJEjjZeHhCFxmZraUcsapNp);
		case ControllerType.Mouse:
			return this.kDHMhecsswEZdNyXmTOdRqQYqusu(this.zLnHuARWczJYSeFmlVDbGirTcMwf);
		case ControllerType.Joystick:
			return this.iihPohjZsjOdlAXDIUJamWVfagPQ<Joystick>(this.UbwRgnOnrybDDRQGflveHOxETQxK);
		default:
			if (A_1 != ControllerType.Custom)
			{
				throw new NotImplementedException();
			}
			return this.iihPohjZsjOdlAXDIUJamWVfagPQ<CustomController>(this.IjvYEbGJscNPgzZqTUAgbsHenfTr);
		}
	}

	// Token: 0x060008EF RID: 2287 RVA: 0x0000977D File Offset: 0x0000797D
	public bool VpcexcbzIPgusgIEdKgsNgUTiMvz()
	{
		return this.cTfkvhJdpjzrczFWjGdapAbzBqqN(this.zLnHuARWczJYSeFmlVDbGirTcMwf) || this.FitPFVIBKjCoQNlmWQAjOmCJYzPl<Joystick>(this.UbwRgnOnrybDDRQGflveHOxETQxK) || this.cTfkvhJdpjzrczFWjGdapAbzBqqN(this.SdKRHvJEjjZeHhCFxmZraUcsapNp) || this.FitPFVIBKjCoQNlmWQAjOmCJYzPl<CustomController>(this.IjvYEbGJscNPgzZqTUAgbsHenfTr);
	}

	// Token: 0x060008F0 RID: 2288 RVA: 0x00041E78 File Offset: 0x00040078
	public bool jZXzpDfTbdEPBrSTLcMkvOMZcsNj(ControllerType A_1)
	{
		switch (A_1)
		{
		case ControllerType.Keyboard:
			return this.cTfkvhJdpjzrczFWjGdapAbzBqqN(this.SdKRHvJEjjZeHhCFxmZraUcsapNp);
		case ControllerType.Mouse:
			return this.cTfkvhJdpjzrczFWjGdapAbzBqqN(this.zLnHuARWczJYSeFmlVDbGirTcMwf);
		case ControllerType.Joystick:
			return this.FitPFVIBKjCoQNlmWQAjOmCJYzPl<Joystick>(this.UbwRgnOnrybDDRQGflveHOxETQxK);
		default:
			if (A_1 != ControllerType.Custom)
			{
				throw new NotImplementedException();
			}
			return this.FitPFVIBKjCoQNlmWQAjOmCJYzPl<CustomController>(this.IjvYEbGJscNPgzZqTUAgbsHenfTr);
		}
	}

	// Token: 0x060008F1 RID: 2289 RVA: 0x000097B7 File Offset: 0x000079B7
	public bool QhSRvxrkIaSPKbLARYPCczCjWzFV()
	{
		return this.YReZvSTsnwQuLDzHoaQSqWnkBJef(this.zLnHuARWczJYSeFmlVDbGirTcMwf) || this.czPOVcMlUUKjUWTabPIkyZHkRQfT<Joystick>(this.UbwRgnOnrybDDRQGflveHOxETQxK) || this.YReZvSTsnwQuLDzHoaQSqWnkBJef(this.SdKRHvJEjjZeHhCFxmZraUcsapNp) || this.czPOVcMlUUKjUWTabPIkyZHkRQfT<CustomController>(this.IjvYEbGJscNPgzZqTUAgbsHenfTr);
	}

	// Token: 0x060008F2 RID: 2290 RVA: 0x00041ED8 File Offset: 0x000400D8
	public bool RHeuRhgfztjNLOUNZcHLNniDiLHAA(ControllerType A_1)
	{
		switch (A_1)
		{
		case ControllerType.Keyboard:
			return this.YReZvSTsnwQuLDzHoaQSqWnkBJef(this.SdKRHvJEjjZeHhCFxmZraUcsapNp);
		case ControllerType.Mouse:
			return this.YReZvSTsnwQuLDzHoaQSqWnkBJef(this.zLnHuARWczJYSeFmlVDbGirTcMwf);
		case ControllerType.Joystick:
			return this.czPOVcMlUUKjUWTabPIkyZHkRQfT<Joystick>(this.UbwRgnOnrybDDRQGflveHOxETQxK);
		default:
			if (A_1 != ControllerType.Custom)
			{
				throw new NotImplementedException();
			}
			return this.czPOVcMlUUKjUWTabPIkyZHkRQfT<CustomController>(this.IjvYEbGJscNPgzZqTUAgbsHenfTr);
		}
	}

	// Token: 0x060008F3 RID: 2291 RVA: 0x000097F1 File Offset: 0x000079F1
	public bool jEinJXlMkoARTkYzYAmcDRiLtyif()
	{
		return this.jWfncLWWhagQDDaXgWqjlaHyBRgp(this.zLnHuARWczJYSeFmlVDbGirTcMwf) || this.XbaNgxLSpjbVkCWoggIwmxsiLjRI<Joystick>(this.UbwRgnOnrybDDRQGflveHOxETQxK) || this.jWfncLWWhagQDDaXgWqjlaHyBRgp(this.SdKRHvJEjjZeHhCFxmZraUcsapNp) || this.XbaNgxLSpjbVkCWoggIwmxsiLjRI<CustomController>(this.IjvYEbGJscNPgzZqTUAgbsHenfTr);
	}

	// Token: 0x060008F4 RID: 2292 RVA: 0x00041F38 File Offset: 0x00040138
	public bool ivSlJMctRyKtWMyKNXtsYqiJMZcd(ControllerType A_1)
	{
		switch (A_1)
		{
		case ControllerType.Keyboard:
			return this.jWfncLWWhagQDDaXgWqjlaHyBRgp(this.SdKRHvJEjjZeHhCFxmZraUcsapNp);
		case ControllerType.Mouse:
			return this.jWfncLWWhagQDDaXgWqjlaHyBRgp(this.zLnHuARWczJYSeFmlVDbGirTcMwf);
		case ControllerType.Joystick:
			return this.XbaNgxLSpjbVkCWoggIwmxsiLjRI<Joystick>(this.UbwRgnOnrybDDRQGflveHOxETQxK);
		default:
			if (A_1 != ControllerType.Custom)
			{
				throw new NotImplementedException();
			}
			return this.XbaNgxLSpjbVkCWoggIwmxsiLjRI<CustomController>(this.IjvYEbGJscNPgzZqTUAgbsHenfTr);
		}
	}

	// Token: 0x060008F5 RID: 2293 RVA: 0x00041F98 File Offset: 0x00040198
	private bool OVuoEpEkOvfeTkReWYQaApxJhhyEb<\u0001>(IList<\u0001> A_1) where \u0001 : Controller
	{
		if (A_1 == null)
		{
			return false;
		}
		int count = A_1.Count;
		for (int i = 0; i < count; i++)
		{
			\u0001 u = A_1[i];
			if (u != null && u.GetAnyButton())
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060008F6 RID: 2294 RVA: 0x0000982B File Offset: 0x00007A2B
	private bool aHHJbZMQufKuRfANsHriAkDBLGCAb(Controller A_1)
	{
		return A_1 != null && A_1.GetAnyButton();
	}

	// Token: 0x060008F7 RID: 2295 RVA: 0x00041FE0 File Offset: 0x000401E0
	private bool iihPohjZsjOdlAXDIUJamWVfagPQ<\u0001>(IList<\u0001> A_1) where \u0001 : Controller
	{
		if (A_1 == null)
		{
			return false;
		}
		int count = A_1.Count;
		for (int i = 0; i < count; i++)
		{
			\u0001 u = A_1[i];
			if (u != null && u.GetAnyButtonDown())
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060008F8 RID: 2296 RVA: 0x00009838 File Offset: 0x00007A38
	private bool kDHMhecsswEZdNyXmTOdRqQYqusu(Controller A_1)
	{
		return A_1 != null && A_1.GetAnyButtonDown();
	}

	// Token: 0x060008F9 RID: 2297 RVA: 0x00042028 File Offset: 0x00040228
	private bool FitPFVIBKjCoQNlmWQAjOmCJYzPl<\u0001>(IList<\u0001> A_1) where \u0001 : Controller
	{
		if (A_1 == null)
		{
			return false;
		}
		int count = A_1.Count;
		for (int i = 0; i < count; i++)
		{
			\u0001 u = A_1[i];
			if (u != null && u.GetAnyButtonUp())
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060008FA RID: 2298 RVA: 0x00009845 File Offset: 0x00007A45
	private bool cTfkvhJdpjzrczFWjGdapAbzBqqN(Controller A_1)
	{
		return A_1 != null && A_1.GetAnyButtonUp();
	}

	// Token: 0x060008FB RID: 2299 RVA: 0x00042070 File Offset: 0x00040270
	private bool czPOVcMlUUKjUWTabPIkyZHkRQfT<\u0001>(IList<\u0001> A_1) where \u0001 : Controller
	{
		if (A_1 == null)
		{
			return false;
		}
		int count = A_1.Count;
		for (int i = 0; i < count; i++)
		{
			\u0001 u = A_1[i];
			if (u != null && u.GetAnyButtonChanged())
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060008FC RID: 2300 RVA: 0x00009852 File Offset: 0x00007A52
	private bool YReZvSTsnwQuLDzHoaQSqWnkBJef(Controller A_1)
	{
		return A_1 != null && A_1.GetAnyButtonChanged();
	}

	// Token: 0x060008FD RID: 2301 RVA: 0x000420B8 File Offset: 0x000402B8
	private bool XbaNgxLSpjbVkCWoggIwmxsiLjRI<\u0001>(IList<\u0001> A_1) where \u0001 : Controller
	{
		if (A_1 == null)
		{
			return false;
		}
		int count = A_1.Count;
		for (int i = 0; i < count; i++)
		{
			\u0001 u = A_1[i];
			if (u != null && u.GetAnyButtonPrev())
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060008FE RID: 2302 RVA: 0x0000985F File Offset: 0x00007A5F
	private bool jWfncLWWhagQDDaXgWqjlaHyBRgp(Controller A_1)
	{
		return A_1 != null && A_1.GetAnyButtonPrev();
	}

	// Token: 0x060008FF RID: 2303 RVA: 0x00042100 File Offset: 0x00040300
	public Controller AsGNwYheTIbQQBmkStCdrvgLMFkdb()
	{
		Controller controller = null;
		double num = 0.0;
		InputTools.CompareLastActiveController(this.zLnHuARWczJYSeFmlVDbGirTcMwf, ref controller, ref num);
		InputTools.CompareLastActiveController(this.SdKRHvJEjjZeHhCFxmZraUcsapNp, ref controller, ref num);
		IList<Joystick> ubwRgnOnrybDDRQGflveHOxETQxK = this.UbwRgnOnrybDDRQGflveHOxETQxK;
		for (int i = 0; i < this.pkIsaLuBqwgPYsBLElovjkUtIZeo; i++)
		{
			InputTools.CompareLastActiveController(ubwRgnOnrybDDRQGflveHOxETQxK[i], ref controller, ref num);
		}
		IList<CustomController> ijvYEbGJscNPgzZqTUAgbsHenfTr = this.IjvYEbGJscNPgzZqTUAgbsHenfTr;
		for (int j = 0; j < this.EwaeQdbfxfQyCoKtMMZzrkzzXzav; j++)
		{
			InputTools.CompareLastActiveController(ijvYEbGJscNPgzZqTUAgbsHenfTr[j], ref controller, ref num);
		}
		if (controller == null)
		{
			controller = this.SdKRHvJEjjZeHhCFxmZraUcsapNp;
		}
		return controller;
	}

	// Token: 0x06000900 RID: 2304 RVA: 0x0004219C File Offset: 0x0004039C
	public Controller gbaAjLiHNYSJBiYjkmpSqUcXvmjoA(ControllerType A_1)
	{
		Controller result = null;
		double num = 0.0;
		switch (A_1)
		{
		case ControllerType.Keyboard:
			return this.TaTrTHwUgSOiWrsYvUpTqAIgrPne;
		case ControllerType.Mouse:
			return this.XNgqEHDojgJjHnQkfggodEGufgWj;
		case ControllerType.Joystick:
		{
			int count = this.UbwRgnOnrybDDRQGflveHOxETQxK.Count;
			for (int i = 0; i < count; i++)
			{
				InputTools.CompareLastActiveController(this.UbwRgnOnrybDDRQGflveHOxETQxK[i], ref result, ref num);
			}
			break;
		}
		default:
		{
			if (A_1 != ControllerType.Custom)
			{
				throw new NotImplementedException();
			}
			int count = this.IjvYEbGJscNPgzZqTUAgbsHenfTr.Count;
			for (int j = 0; j < count; j++)
			{
				InputTools.CompareLastActiveController(this.IjvYEbGJscNPgzZqTUAgbsHenfTr[j], ref result, ref num);
			}
			break;
		}
		}
		return result;
	}

	// Token: 0x06000901 RID: 2305 RVA: 0x00042248 File Offset: 0x00040448
	public \u0001 AsGNwYheTIbQQBmkStCdrvgLMFkdb<\u0001>() where \u0001 : Controller
	{
		Type typeFromHandle = typeof(\u0001);
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Joystick)))
		{
			return this.gbaAjLiHNYSJBiYjkmpSqUcXvmjoA(ControllerType.Joystick) as \u0001;
		}
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Keyboard)))
		{
			return this.gbaAjLiHNYSJBiYjkmpSqUcXvmjoA(ControllerType.Keyboard) as \u0001;
		}
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(CustomController)))
		{
			return this.gbaAjLiHNYSJBiYjkmpSqUcXvmjoA(ControllerType.Custom) as \u0001;
		}
		if (ReflectionTools.DoesTypeImplement(typeFromHandle, typeof(Mouse)))
		{
			return this.gbaAjLiHNYSJBiYjkmpSqUcXvmjoA(ControllerType.Mouse) as \u0001;
		}
		throw new NotImplementedException();
	}

	// Token: 0x06000902 RID: 2306 RVA: 0x000422F8 File Offset: 0x000404F8
	public ControllerType svIelaGFeMDuMeedqyuOJLQvGGppA()
	{
		Controller controller = this.AsGNwYheTIbQQBmkStCdrvgLMFkdb();
		if (controller != null)
		{
			return controller.type;
		}
		return ControllerType.Keyboard;
	}

	// Token: 0x06000903 RID: 2307 RVA: 0x0000986C File Offset: 0x00007A6C
	public void owMHCzymuFPqadYOjuEBSbwfmAYW(ActiveControllerChangedDelegate A_1)
	{
		if (A_1 == null)
		{
			return;
		}
		this.BqofeAJDdKsupXkLyIJNptjwMCxR = true;
		this.VclFijsSinGOdUpHLRUGgAMzPJAu.FHcLWBLBZjiNAIPGGdcHYiFvjETS(A_1);
	}

	// Token: 0x06000904 RID: 2308 RVA: 0x00009885 File Offset: 0x00007A85
	public void CVboItgwVLLNnOpxxWpJlXqugVAE(ActiveControllerChangedDelegate A_1, ControllerType A_2)
	{
		if (A_1 == null)
		{
			return;
		}
		this.BqofeAJDdKsupXkLyIJNptjwMCxR = true;
		this.VclFijsSinGOdUpHLRUGgAMzPJAu.WtdsCdxbTlObbfPHhiunnwOzTaGf(A_1, A_2);
	}

	// Token: 0x06000905 RID: 2309 RVA: 0x0000989F File Offset: 0x00007A9F
	public void BitpXAiHuRQTUmaHbgbymVGpvvDR(ActiveControllerChangedDelegate A_1)
	{
		if (A_1 == null)
		{
			return;
		}
		this.VclFijsSinGOdUpHLRUGgAMzPJAu.qOuJmuxbRbxPqrtxPHLNNofytkGb(A_1);
	}

	// Token: 0x06000906 RID: 2310 RVA: 0x000098B1 File Offset: 0x00007AB1
	public void QZPAFYyTpwOkRoQLEbHWDuXeEqzw(ActiveControllerChangedDelegate A_1, ControllerType A_2)
	{
		if (A_1 == null)
		{
			return;
		}
		this.VclFijsSinGOdUpHLRUGgAMzPJAu.nwtGcmCpJlBWcyyeTCugEtTjeTsU(A_1, A_2);
	}

	// Token: 0x06000907 RID: 2311 RVA: 0x000098C4 File Offset: 0x00007AC4
	public void sKQpoaYDpnkkyOHHttqtDHZWIhBp()
	{
		this.VclFijsSinGOdUpHLRUGgAMzPJAu.exUxIFArxSFhXCGDunDgQxDfkCph();
	}

	// Token: 0x06000908 RID: 2312 RVA: 0x000098D1 File Offset: 0x00007AD1
	public void WXDlgPzWNhwmyOycMStAzPJIpchm(int A_1, PlayerActiveControllerChangedDelegate A_2)
	{
		if (A_2 == null)
		{
			return;
		}
		if (A_1 == 9999999)
		{
			this.eEpRtwLXpFNSpCeVCNtfxkdzhKny.FHcLWBLBZjiNAIPGGdcHYiFvjETS(A_2);
		}
		else
		{
			if (A_1 >= this.uwdJDUjGnCEspMlnHLCzeqqwGzYo)
			{
				return;
			}
			this.oGjwilvccNRqpYhhgJAgjCCbpHRF[A_1].FHcLWBLBZjiNAIPGGdcHYiFvjETS(A_2);
		}
		this.BqofeAJDdKsupXkLyIJNptjwMCxR = true;
	}

	// Token: 0x06000909 RID: 2313 RVA: 0x0000990C File Offset: 0x00007B0C
	public void hSabLTULPhLufVUYuiWGZoxxaFxm(int A_1, PlayerActiveControllerChangedDelegate A_2, ControllerType A_3)
	{
		if (A_2 == null)
		{
			return;
		}
		if (A_1 == 9999999)
		{
			this.eEpRtwLXpFNSpCeVCNtfxkdzhKny.WtdsCdxbTlObbfPHhiunnwOzTaGf(A_2, A_3);
		}
		else
		{
			if (A_1 >= this.uwdJDUjGnCEspMlnHLCzeqqwGzYo)
			{
				return;
			}
			this.oGjwilvccNRqpYhhgJAgjCCbpHRF[A_1].WtdsCdxbTlObbfPHhiunnwOzTaGf(A_2, A_3);
		}
		this.BqofeAJDdKsupXkLyIJNptjwMCxR = true;
	}

	// Token: 0x0600090A RID: 2314 RVA: 0x00009949 File Offset: 0x00007B49
	public void TmEUhRTxWLbjlIzlQghfhnduHtCU(int A_1, PlayerActiveControllerChangedDelegate A_2)
	{
		if (A_2 == null)
		{
			return;
		}
		if (A_1 == 9999999)
		{
			this.eEpRtwLXpFNSpCeVCNtfxkdzhKny.qOuJmuxbRbxPqrtxPHLNNofytkGb(A_2);
			return;
		}
		if (A_1 >= this.uwdJDUjGnCEspMlnHLCzeqqwGzYo)
		{
			return;
		}
		this.oGjwilvccNRqpYhhgJAgjCCbpHRF[A_1].qOuJmuxbRbxPqrtxPHLNNofytkGb(A_2);
	}

	// Token: 0x0600090B RID: 2315 RVA: 0x0000997C File Offset: 0x00007B7C
	public void RRnqvcihuSGtfLtfSLytLxXpwcIA(int A_1, PlayerActiveControllerChangedDelegate A_2, ControllerType A_3)
	{
		if (A_2 == null)
		{
			return;
		}
		if (A_1 == 9999999)
		{
			this.eEpRtwLXpFNSpCeVCNtfxkdzhKny.nwtGcmCpJlBWcyyeTCugEtTjeTsU(A_2, A_3);
			return;
		}
		if (A_1 >= this.uwdJDUjGnCEspMlnHLCzeqqwGzYo)
		{
			return;
		}
		this.oGjwilvccNRqpYhhgJAgjCCbpHRF[A_1].nwtGcmCpJlBWcyyeTCugEtTjeTsU(A_2, A_3);
	}

	// Token: 0x0600090C RID: 2316 RVA: 0x000099B1 File Offset: 0x00007BB1
	public void YxMDeBOfdjgbTgaGqbbZQXjDZBbC(int A_1)
	{
		if (A_1 == 9999999)
		{
			this.eEpRtwLXpFNSpCeVCNtfxkdzhKny.exUxIFArxSFhXCGDunDgQxDfkCph();
			return;
		}
		if (A_1 >= this.uwdJDUjGnCEspMlnHLCzeqqwGzYo)
		{
			return;
		}
		this.oGjwilvccNRqpYhhgJAgjCCbpHRF[A_1].exUxIFArxSFhXCGDunDgQxDfkCph();
	}

	// Token: 0x0600090D RID: 2317 RVA: 0x00042318 File Offset: 0x00040518
	private void NXPSWsQqbFgXfFbbBVpslOSEmsqU()
	{
		if (this.VclFijsSinGOdUpHLRUGgAMzPJAu.BxwiSDfJWDacFHAGugxXsGPOpQOwA > 0)
		{
			this.VclFijsSinGOdUpHLRUGgAMzPJAu.BOQhFiKCIMlxBfXFSUfCrQgHhXp(-1, this.AsGNwYheTIbQQBmkStCdrvgLMFkdb(), this.gbaAjLiHNYSJBiYjkmpSqUcXvmjoA(ControllerType.Joystick), this.gbaAjLiHNYSJBiYjkmpSqUcXvmjoA(ControllerType.Custom));
		}
		if (this.eEpRtwLXpFNSpCeVCNtfxkdzhKny.BxwiSDfJWDacFHAGugxXsGPOpQOwA > 0)
		{
			Player.ControllerHelper controllers = this.wEwcfmITTSquheyvVLbSeCbDfKcu.CrofyrlIxqANhJbwPluHBcmsknBDA().controllers;
			this.eEpRtwLXpFNSpCeVCNtfxkdzhKny.BOQhFiKCIMlxBfXFSUfCrQgHhXp(9999999, controllers.GetLastActiveController(), controllers.GetLastActiveController(ControllerType.Joystick), controllers.GetLastActiveController(ControllerType.Custom));
		}
		for (int i = 0; i < this.uwdJDUjGnCEspMlnHLCzeqqwGzYo; i++)
		{
			if (this.oGjwilvccNRqpYhhgJAgjCCbpHRF[i].BxwiSDfJWDacFHAGugxXsGPOpQOwA != 0)
			{
				Player.ControllerHelper controllers2 = this.wEwcfmITTSquheyvVLbSeCbDfKcu.TORorJrYCuHeKlTGuMSHCpgsllYX[i].controllers;
				this.oGjwilvccNRqpYhhgJAgjCCbpHRF[i].BOQhFiKCIMlxBfXFSUfCrQgHhXp(i, controllers2.GetLastActiveController(), controllers2.GetLastActiveController(ControllerType.Joystick), controllers2.GetLastActiveController(ControllerType.Custom));
			}
		}
	}

	// Token: 0x0600090E RID: 2318 RVA: 0x000423F0 File Offset: 0x000405F0
	public void rqoljScvYHDAsqjHNKsoyVkIaMop(ThrottleCalibrationMode A_1)
	{
		for (int i = 0; i < this.UbwRgnOnrybDDRQGflveHOxETQxK.Count; i++)
		{
			if (this.UbwRgnOnrybDDRQGflveHOxETQxK[i] != null)
			{
				this.SbuMzVmFoCeLuvKrmgADQVjlFRmc(this.UbwRgnOnrybDDRQGflveHOxETQxK[i], A_1);
			}
		}
		for (int j = 0; j < this.rrwshdvoiWQuWIBqDKDLUyFIhZag.Count; j++)
		{
			if (this.rrwshdvoiWQuWIBqDKDLUyFIhZag[j] != null)
			{
				this.SbuMzVmFoCeLuvKrmgADQVjlFRmc(this.rrwshdvoiWQuWIBqDKDLUyFIhZag[j], A_1);
			}
		}
		for (int k = 0; k < this.EwaeQdbfxfQyCoKtMMZzrkzzXzav; k++)
		{
			if (this.IjvYEbGJscNPgzZqTUAgbsHenfTr[k] != null)
			{
				this.SbuMzVmFoCeLuvKrmgADQVjlFRmc(this.IjvYEbGJscNPgzZqTUAgbsHenfTr[k], A_1);
			}
		}
		this.SbuMzVmFoCeLuvKrmgADQVjlFRmc(this.zLnHuARWczJYSeFmlVDbGirTcMwf, A_1);
	}

	// Token: 0x0600090F RID: 2319 RVA: 0x000424AC File Offset: 0x000406AC
	private void SbuMzVmFoCeLuvKrmgADQVjlFRmc(ControllerWithAxes A_1, ThrottleCalibrationMode A_2)
	{
		IList<Controller.Axis> axes = A_1.Axes;
		for (int i = 0; i < A_1.axisCount; i++)
		{
			if (axes[i].fzzkLLIistIuAlLCPzLMFEPVKHOk._specialAxisType == SpecialAxisType.Throttle)
			{
				A_1.calibrationMap.Axes[i].calibrationMode = EnumConverter.ToAlternateAxisCalibrationType(A_2);
			}
		}
	}

	// Token: 0x06000910 RID: 2320 RVA: 0x000099DE File Offset: 0x00007BDE
	public IList<\u0001> ERmWOdiERTUJxFGZRPEEocZABjPB<\u0001>() where \u0001 : IControllerTemplate
	{
		return this.kCXvUIWYymbXvGdUklSrMIHzfawAA.FfJfewQUzyHPsLUFqdkzTuUdQThm<\u0001>();
	}

	// Token: 0x170002B7 RID: 695
	// (get) Token: 0x06000911 RID: 2321 RVA: 0x000099EB File Offset: 0x00007BEB
	private int GouGdvwOusEAihzGhYGvFOritjiG
	{
		get
		{
			int pbcYOeYqjAASCHMmfsHZsLwQnnhd = this.PBcYOeYqjAASCHMmfsHZsLwQnnhd;
			this.PBcYOeYqjAASCHMmfsHZsLwQnnhd++;
			if (this.PBcYOeYqjAASCHMmfsHZsLwQnnhd >= 2147483647)
			{
				this.PBcYOeYqjAASCHMmfsHZsLwQnnhd = 0;
			}
			return pbcYOeYqjAASCHMmfsHZsLwQnnhd;
		}
	}

	// Token: 0x06000912 RID: 2322 RVA: 0x00042504 File Offset: 0x00040704
	private void IaSLoOJwKkaiUxpGjnXZZclhcFvx(List<InputBehavior> A_1)
	{
		this.duMGvhBQWmQOaNghmuoCtxbyHqRiA = ReInput.qvonQHVNxGPvrzuISSMkVECyMEGc;
		this.wEwcfmITTSquheyvVLbSeCbDfKcu = ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA;
		this.UbwRgnOnrybDDRQGflveHOxETQxK = new List<Joystick>();
		this.rrwshdvoiWQuWIBqDKDLUyFIhZag = new List<Joystick>();
		this.IjvYEbGJscNPgzZqTUAgbsHenfTr = new List<CustomController>();
		this.TawUCoDrBIQqyYaxHLlDpJguMKDR = this.duMGvhBQWmQOaNghmuoCtxbyHqRiA.gdtJMdYGqGLjogQUyQYoOeTeKURk;
		this.uwdJDUjGnCEspMlnHLCzeqqwGzYo = this.wEwcfmITTSquheyvVLbSeCbDfKcu.JZZMSdwQmzZLUZnhPHsPBtaOBmXm;
		this.BpuluexJKhpezrffQCgkAgqyTWQB = new Action<bool, int, int>(this.GMXybSgUjzQACtTgrZhAwNUBKxjC);
		this.PBcYOeYqjAASCHMmfsHZsLwQnnhd = 0;
		this.HofFVyzjUTYvxnDPlQfqEOFMQhhK = new ADictionary<int, HEnwyLWfnrHknWieEccXGXTAawGsA.FJAwtONIirCNRRTzIggcsIbkgUBl>();
		this.HofFVyzjUTYvxnDPlQfqEOFMQhhK.Add(ReInput.players.GetSystemPlayer().id, new HEnwyLWfnrHknWieEccXGXTAawGsA.FJAwtONIirCNRRTzIggcsIbkgUBl(A_1));
		IList<Player> players = ReInput.players.Players;
		for (int i = 0; i < players.Count; i++)
		{
			this.HofFVyzjUTYvxnDPlQfqEOFMQhhK.Add(players[i].id, new HEnwyLWfnrHknWieEccXGXTAawGsA.FJAwtONIirCNRRTzIggcsIbkgUBl(A_1));
		}
		this.vWecKCEQQBDkWSvtTltMphHdYlQmA = new ReadOnlyCollection<Joystick>(this.UbwRgnOnrybDDRQGflveHOxETQxK);
		this.zUSvEBgGkGUZOMjzscoKRGPnnVEq = new ReadOnlyCollection<CustomController>(this.IjvYEbGJscNPgzZqTUAgbsHenfTr);
		iWmRLdlDqgwSNYjkwtUZeqvQOyqs.SIsptHzTmROmfVAEbDdDcmhWoEah(this.HqZpEmBsNwuTnbacnIotwOqnKfTp);
		this.tVBaITMhyygqGaLyzKGMqoFSdLHB = new iWmRLdlDqgwSNYjkwtUZeqvQOyqs[(this.uwdJDUjGnCEspMlnHLCzeqqwGzYo + 1) * this.TawUCoDrBIQqyYaxHLlDpJguMKDR];
		int num = 0;
		this.UQCwBVDCQDdcEoJdAgkWSDLTzmNG = new iWmRLdlDqgwSNYjkwtUZeqvQOyqs[this.TawUCoDrBIQqyYaxHLlDpJguMKDR];
		for (int j = 0; j < this.TawUCoDrBIQqyYaxHLlDpJguMKDR; j++)
		{
			InputAction inputAction = this.duMGvhBQWmQOaNghmuoCtxbyHqRiA.puRZHYlwSvYOZmFNvWBfhhEpASWK(j);
			InputBehavior inputBehavior = this.HofFVyzjUTYvxnDPlQfqEOFMQhhK[9999999].qQSyQYCncuFxltXFcCFxwWYdpfev(inputAction.behaviorId);
			iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = new iWmRLdlDqgwSNYjkwtUZeqvQOyqs(9999999, inputAction, inputBehavior, this.HqZpEmBsNwuTnbacnIotwOqnKfTp);
			this.UQCwBVDCQDdcEoJdAgkWSDLTzmNG[j] = iWmRLdlDqgwSNYjkwtUZeqvQOyqs;
			this.tVBaITMhyygqGaLyzKGMqoFSdLHB[num] = iWmRLdlDqgwSNYjkwtUZeqvQOyqs;
			num++;
		}
		this.HgHEfKyJmTGNqsBkTNrgJKOPAwlBA = new iWmRLdlDqgwSNYjkwtUZeqvQOyqs[this.uwdJDUjGnCEspMlnHLCzeqqwGzYo, this.TawUCoDrBIQqyYaxHLlDpJguMKDR];
		for (int k = 0; k < this.uwdJDUjGnCEspMlnHLCzeqqwGzYo; k++)
		{
			for (int l = 0; l < this.TawUCoDrBIQqyYaxHLlDpJguMKDR; l++)
			{
				InputAction inputAction2 = this.duMGvhBQWmQOaNghmuoCtxbyHqRiA.puRZHYlwSvYOZmFNvWBfhhEpASWK(l);
				InputBehavior inputBehavior2 = this.HofFVyzjUTYvxnDPlQfqEOFMQhhK[players[k].id].qQSyQYCncuFxltXFcCFxwWYdpfev(inputAction2.behaviorId);
				iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs2 = new iWmRLdlDqgwSNYjkwtUZeqvQOyqs(k, inputAction2, inputBehavior2, this.HqZpEmBsNwuTnbacnIotwOqnKfTp);
				this.HgHEfKyJmTGNqsBkTNrgJKOPAwlBA[k, l] = iWmRLdlDqgwSNYjkwtUZeqvQOyqs2;
				this.tVBaITMhyygqGaLyzKGMqoFSdLHB[num] = iWmRLdlDqgwSNYjkwtUZeqvQOyqs2;
				num++;
			}
		}
		IList<Player_Editor> list = ReInput.UserData.VnvGwsIqlyaVDfkMStriDwUKMMSo;
		if (list == null)
		{
			throw new ArgumentNullException("Players cannot be null!");
		}
		for (int m = 0; m < list.Count; m++)
		{
			List<Player_Editor.CreateControllerInfo> startingCustomControllers = list[m].startingCustomControllers;
			if (startingCustomControllers != null)
			{
				for (int n = 0; n < startingCustomControllers.Count; n++)
				{
					CustomController customController = this.GtyAkWaziVlXmbaLqdOfAXlIROxMA(startingCustomControllers[n].sourceId);
					if (customController != null)
					{
						customController.tag = startingCustomControllers[n].tag;
						int num2 = (m == 0) ? 9999999 : (m - 1);
						Player player = this.wEwcfmITTSquheyvVLbSeCbDfKcu.VtObDEzKPQDiJEMzgQRElYBEdxnC(num2);
						if (player != null)
						{
							player.controllers.kxwIeJTjxOkmVbqsvaSqCGtGUKAY(customController, false);
						}
					}
				}
			}
		}
		this.eiWSDTiITSSWViKCpmTnteGgZtDe = new EDsbfoobWXwcKBvvNHVrQUZhEIkn();
		this.mEaguLUTSqWIWzEiCYWUBHWcidpT = new EDsbfoobWXwcKBvvNHVrQUZhEIkn[this.uwdJDUjGnCEspMlnHLCzeqqwGzYo];
		for (int num3 = 0; num3 < this.uwdJDUjGnCEspMlnHLCzeqqwGzYo; num3++)
		{
			this.mEaguLUTSqWIWzEiCYWUBHWcidpT[num3] = new EDsbfoobWXwcKBvvNHVrQUZhEIkn();
		}
		this.VclFijsSinGOdUpHLRUGgAMzPJAu = new asNHovBJNGfzQvNtBHQlZZahaCpW<ActiveControllerChangedDelegate>();
		this.eEpRtwLXpFNSpCeVCNtfxkdzhKny = new asNHovBJNGfzQvNtBHQlZZahaCpW<PlayerActiveControllerChangedDelegate>();
		this.oGjwilvccNRqpYhhgJAgjCCbpHRF = new asNHovBJNGfzQvNtBHQlZZahaCpW<PlayerActiveControllerChangedDelegate>[this.wEwcfmITTSquheyvVLbSeCbDfKcu.JZZMSdwQmzZLUZnhPHsPBtaOBmXm];
		ArrayTools.Populate<asNHovBJNGfzQvNtBHQlZZahaCpW<PlayerActiveControllerChangedDelegate>>(this.oGjwilvccNRqpYhhgJAgjCCbpHRF);
	}

	// Token: 0x06000913 RID: 2323 RVA: 0x00042898 File Offset: 0x00040A98
	private void sQNGOtCnqljathWNmBarbEnXRpROA(UpdateLoopType A_1)
	{
		int count = this.UbwRgnOnrybDDRQGflveHOxETQxK.Count;
		for (int i = 0; i < count; i++)
		{
			Joystick joystick = this.UbwRgnOnrybDDRQGflveHOxETQxK[i];
			if (joystick.enabled)
			{
				this.qmvHlpKUStAEIqrItmRrKZSDebpe(joystick.BjZIwCQrVZKIGHzYAESmJWHyVhwq, joystick.ydAtmTGPnVEBcanqXjmfnQCYnoGgb);
				joystick.FQTBjLASwKIywYemFGwowQCkCzxHA(A_1);
			}
		}
		if (this.SdKRHvJEjjZeHhCFxmZraUcsapNp.enabled)
		{
			this.SdKRHvJEjjZeHhCFxmZraUcsapNp.FQTBjLASwKIywYemFGwowQCkCzxHA(A_1);
		}
		else if (this.UewCmdpRVVwdmfcVccVBYJYbWfSK)
		{
			this.SdKRHvJEjjZeHhCFxmZraUcsapNp.MKKcvYIJUiNkQqdmOLKxseeMfOYbA(A_1);
		}
		if (this.zLnHuARWczJYSeFmlVDbGirTcMwf.enabled)
		{
			this.zLnHuARWczJYSeFmlVDbGirTcMwf.FQTBjLASwKIywYemFGwowQCkCzxHA(A_1);
		}
		int count2 = this.IjvYEbGJscNPgzZqTUAgbsHenfTr.Count;
		for (int j = 0; j < count2; j++)
		{
			CustomController customController = this.IjvYEbGJscNPgzZqTUAgbsHenfTr[j];
			if (customController.enabled)
			{
				customController.imQEMIFlJSzXxTzPdPBsQDHzJfsnA();
				customController.FQTBjLASwKIywYemFGwowQCkCzxHA(A_1);
			}
		}
	}

	// Token: 0x06000914 RID: 2324 RVA: 0x0004297C File Offset: 0x00040B7C
	private void WDUmoVyWyyhuUkGKWiWxxRwZpikt(UpdateLoopType A_1)
	{
		iWmRLdlDqgwSNYjkwtUZeqvQOyqs.mEmjwDicdQrGojXTvgKpBldpXqJE(A_1);
		Player[] array = this.wEwcfmITTSquheyvVLbSeCbDfKcu.QyodWyQUNwBmszApNAfRKZHwWtCUA;
		int num = array.Length;
		bool enabled = this.SdKRHvJEjjZeHhCFxmZraUcsapNp.enabled;
		if (enabled)
		{
			for (int i = 0; i < num; i++)
			{
				IList<KeyboardMap> maps = array[i].controllers.maps.GetMaps<KeyboardMap>(0);
				int count = maps.Count;
				for (int j = 0; j < count; j++)
				{
					if (maps[j].enabled)
					{
						this.PanoIILHaUdGmkxoeFTsAzzMdTMx.ZVSLnbArndtsfXTuWqihfYUNdeGx(maps[j]);
					}
				}
			}
		}
		bool enabled2 = this.zLnHuARWczJYSeFmlVDbGirTcMwf.enabled;
		for (int k = 0; k < num; k++)
		{
			Player.ControllerHelper controllers = array[k].controllers;
			controllers.fcfYFvtvyNgMwmCuwTafAZghMTMA(this.BpuluexJKhpezrffQCgkAgqyTWQB);
			if (enabled || this.UewCmdpRVVwdmfcVccVBYJYbWfSK)
			{
				controllers.YlAbzLhIKpIkDaPbkjtLweTSwfkbc(this.SdKRHvJEjjZeHhCFxmZraUcsapNp, this.PanoIILHaUdGmkxoeFTsAzzMdTMx, this.BpuluexJKhpezrffQCgkAgqyTWQB);
			}
			if (enabled2)
			{
				controllers.UEyYnwOYSlFKXyqeDJDmUdNaPrf(this.zLnHuARWczJYSeFmlVDbGirTcMwf, this.BpuluexJKhpezrffQCgkAgqyTWQB);
			}
			controllers.OEUZQdUOoJhHDSKzawvsJFgYeyrCA(this.BpuluexJKhpezrffQCgkAgqyTWQB);
		}
		for (int l = 0; l < this.tVBaITMhyygqGaLyzKGMqoFSdLHB.Length; l++)
		{
			if (this.tVBaITMhyygqGaLyzKGMqoFSdLHB[l].KtabwngytZNqqQLTKorCaAvKHyzX != iWmRLdlDqgwSNYjkwtUZeqvQOyqs.RMpfvDpfwUakDjETyOTCXnXoYFGU.Disabled)
			{
				this.tVBaITMhyygqGaLyzKGMqoFSdLHB[l].SryHCWZDGvcEkuqNcAcuwKQwIixe();
			}
		}
		iWmRLdlDqgwSNYjkwtUZeqvQOyqs.sjqxeIfowPwCZVIHkexDOhrzYmki();
		if (this.PHTphyfeVEZEPCHwKVXYfBXaJwCB)
		{
			if (this.eiWSDTiITSSWViKCpmTnteGgZtDe.dvrNpBCudvGHLNbZbdfKCDuHtjMlA > 0)
			{
				for (int m = 0; m < this.TawUCoDrBIQqyYaxHLlDpJguMKDR; m++)
				{
					iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs = this.UQCwBVDCQDdcEoJdAgkWSDLTzmNG[m];
					if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs.KtabwngytZNqqQLTKorCaAvKHyzX != iWmRLdlDqgwSNYjkwtUZeqvQOyqs.RMpfvDpfwUakDjETyOTCXnXoYFGU.Disabled)
					{
						this.eiWSDTiITSSWViKCpmTnteGgZtDe.oflwYiaDYKXvuXodiKZyLupBEZNq(iWmRLdlDqgwSNYjkwtUZeqvQOyqs, A_1);
					}
				}
			}
			for (int n = 0; n < this.uwdJDUjGnCEspMlnHLCzeqqwGzYo; n++)
			{
				EDsbfoobWXwcKBvvNHVrQUZhEIkn edsbfoobWXwcKBvvNHVrQUZhEIkn = this.mEaguLUTSqWIWzEiCYWUBHWcidpT[n];
				if (edsbfoobWXwcKBvvNHVrQUZhEIkn.dvrNpBCudvGHLNbZbdfKCDuHtjMlA != 0)
				{
					for (int num2 = 0; num2 < this.TawUCoDrBIQqyYaxHLlDpJguMKDR; num2++)
					{
						iWmRLdlDqgwSNYjkwtUZeqvQOyqs iWmRLdlDqgwSNYjkwtUZeqvQOyqs2 = this.HgHEfKyJmTGNqsBkTNrgJKOPAwlBA[n, num2];
						if (iWmRLdlDqgwSNYjkwtUZeqvQOyqs2.KtabwngytZNqqQLTKorCaAvKHyzX != iWmRLdlDqgwSNYjkwtUZeqvQOyqs.RMpfvDpfwUakDjETyOTCXnXoYFGU.Disabled)
						{
							edsbfoobWXwcKBvvNHVrQUZhEIkn.oflwYiaDYKXvuXodiKZyLupBEZNq(iWmRLdlDqgwSNYjkwtUZeqvQOyqs2, A_1);
						}
					}
				}
			}
		}
	}

	// Token: 0x06000915 RID: 2325 RVA: 0x00042B7C File Offset: 0x00040D7C
	private void GMXybSgUjzQACtTgrZhAwNUBKxjC(bool A_1, int A_2, int A_3)
	{
		int num = this.duMGvhBQWmQOaNghmuoCtxbyHqRiA.GgcLbqsjISfcSHJvzXzdOFrEcGwSA(A_3, false);
		if (num < 0)
		{
			return;
		}
		if (A_2 == 9999999)
		{
			this.UQCwBVDCQDdcEoJdAgkWSDLTzmNG[num].nluXWdPInMuffiIXkYFVgBuDvMwm(A_1);
			return;
		}
		this.HgHEfKyJmTGNqsBkTNrgJKOPAwlBA[A_2, num].nluXWdPInMuffiIXkYFVgBuDvMwm(A_1);
	}

	// Token: 0x06000916 RID: 2326 RVA: 0x00042BC8 File Offset: 0x00040DC8
	private void lXZMupegzkfTfwnXVymiovlzRuPi(BridgedController A_1)
	{
		int num = this.JlCdJQcivrExAbPrBEdlOYnesofSb(A_1.sourceJoystick.rewiredId, HEnwyLWfnrHknWieEccXGXTAawGsA.KHCbyofpALMYVppWHChAOTYYCOJbb.Connected);
		if (num >= 0)
		{
			Logger.LogError("Controller was already in connected list!");
			return;
		}
		num = this.JlCdJQcivrExAbPrBEdlOYnesofSb(A_1.sourceJoystick.rewiredId, HEnwyLWfnrHknWieEccXGXTAawGsA.KHCbyofpALMYVppWHChAOTYYCOJbb.Disconnected);
		Joystick joystick;
		if (num >= 0)
		{
			joystick = this.rrwshdvoiWQuWIBqDKDLUyFIhZag[num];
			this.rrwshdvoiWQuWIBqDKDLUyFIhZag.RemoveAt(num);
			joystick.RapssdIPKSTuZrgyibatSKSDlRgh(A_1);
			joystick.isConnected = true;
		}
		else
		{
			joystick = new Joystick(A_1);
		}
		this.UbwRgnOnrybDDRQGflveHOxETQxK.Add(joystick);
		this.atgdJIInhyKudGsJgWEjzPkJWxsA.Add(joystick);
		this.UbwRgnOnrybDDRQGflveHOxETQxK.Sort(new Comparison<Joystick>(Joystick.gJHZVvczEoCkCxKFlcmJagyCMvjZ));
		this.kCXvUIWYymbXvGdUklSrMIHzfawAA.zasBhsaAvoJpxZfKGoCjaYtFpigYB(joystick);
	}

	// Token: 0x06000917 RID: 2327 RVA: 0x00042C7C File Offset: 0x00040E7C
	private void wHjpRBCDSlCjiZfCkSAYsElAfxyf(int A_1)
	{
		if (A_1 < 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		if (A_1 >= this.UbwRgnOnrybDDRQGflveHOxETQxK.Count)
		{
			Logger.LogError("Device was not in connected list! Cannot remove!");
			return;
		}
		Joystick joystick = this.UbwRgnOnrybDDRQGflveHOxETQxK[A_1];
		joystick.isConnected = false;
		if (this.lQkbyfzBUbSxAISNiwEbPjbzfmWQ != null)
		{
			this.lQkbyfzBUbSxAISNiwEbPjbzfmWQ(new ControllerStatusChangedEventArgs(joystick.name, joystick.id, joystick.type));
		}
		if (this.FhsDKOndKmDeNLaHPEwpBBFWHSgUA != null)
		{
			this.FhsDKOndKmDeNLaHPEwpBBFWHSgUA(joystick.type, joystick.id);
		}
		this.UbwRgnOnrybDDRQGflveHOxETQxK.RemoveAt(A_1);
		this.rrwshdvoiWQuWIBqDKDLUyFIhZag.Add(joystick);
		this.atgdJIInhyKudGsJgWEjzPkJWxsA.Remove(joystick);
		this.kCXvUIWYymbXvGdUklSrMIHzfawAA.QvDjjGLIVKsQuJmOzAqldvnCtsBH(joystick);
		joystick.teTpHyJcIRafhlIJVTCUfrhAktlq();
	}

	// Token: 0x06000918 RID: 2328 RVA: 0x00042D40 File Offset: 0x00040F40
	private void bfBoEPOdrVdItPEJaFODeSXRbpEtA()
	{
		for (int i = this.UbwRgnOnrybDDRQGflveHOxETQxK.Count - 1; i >= 0; i--)
		{
			this.wHjpRBCDSlCjiZfCkSAYsElAfxyf(i);
		}
	}

	// Token: 0x06000919 RID: 2329 RVA: 0x00042D6C File Offset: 0x00040F6C
	private bool EhCBQPlANWJfMtOqBDHLWAOrYmtW(CustomController A_1)
	{
		if (A_1 == null)
		{
			return false;
		}
		for (int i = 0; i < this.IjvYEbGJscNPgzZqTUAgbsHenfTr.Count; i++)
		{
			if (this.IjvYEbGJscNPgzZqTUAgbsHenfTr[i] == A_1)
			{
				return true;
			}
		}
		this.IjvYEbGJscNPgzZqTUAgbsHenfTr.Add(A_1);
		this.atgdJIInhyKudGsJgWEjzPkJWxsA.Add(A_1);
		this.kCXvUIWYymbXvGdUklSrMIHzfawAA.zasBhsaAvoJpxZfKGoCjaYtFpigYB(A_1);
		return true;
	}

	// Token: 0x0600091A RID: 2330 RVA: 0x00009A15 File Offset: 0x00007C15
	private bool EJikfdtgHrbfjjHeLYtjUNtGblFRA(CustomController A_1)
	{
		if (A_1 == null)
		{
			return false;
		}
		this.kCXvUIWYymbXvGdUklSrMIHzfawAA.QvDjjGLIVKsQuJmOzAqldvnCtsBH(A_1);
		this.atgdJIInhyKudGsJgWEjzPkJWxsA.Remove(A_1);
		return this.IjvYEbGJscNPgzZqTUAgbsHenfTr.Remove(A_1);
	}

	// Token: 0x0600091B RID: 2331 RVA: 0x00009A41 File Offset: 0x00007C41
	private EDsbfoobWXwcKBvvNHVrQUZhEIkn dwdExKMowWCjiiUyErsovVpheypcA(int A_1)
	{
		if (A_1 == 9999999)
		{
			return this.eiWSDTiITSSWViKCpmTnteGgZtDe;
		}
		if (A_1 < 0 || A_1 >= ReInput.UPtFMqdgwQOSKZUNRJVvcmXsLnZIA.JZZMSdwQmzZLUZnhPHsPBtaOBmXm)
		{
			return null;
		}
		return this.mEaguLUTSqWIWzEiCYWUBHWcidpT[A_1];
	}

	// Token: 0x0600091C RID: 2332 RVA: 0x00009A6D File Offset: 0x00007C6D
	private void URorGKDFUVTczDVVQuGVDctGeRKN(bool A_1)
	{
		if (!A_1)
		{
			this.PanoIILHaUdGmkxoeFTsAzzMdTMx.zJJItFbZGXvHLIwbQvfaPNRmQLKA();
		}
	}

	// Token: 0x0600091D RID: 2333 RVA: 0x00042DCC File Offset: 0x00040FCC
	private void StLQHEsupecGILHCrTzoJkAyGInC(bool A_1)
	{
		this.SdKRHvJEjjZeHhCFxmZraUcsapNp.traDKlHspaXCdfNvtkwAFzPfEhYY(A_1);
		this.zLnHuARWczJYSeFmlVDbGirTcMwf.traDKlHspaXCdfNvtkwAFzPfEhYY(A_1);
		for (int i = 0; i < this.UbwRgnOnrybDDRQGflveHOxETQxK.Count; i++)
		{
			this.UbwRgnOnrybDDRQGflveHOxETQxK[i].traDKlHspaXCdfNvtkwAFzPfEhYY(A_1);
		}
		for (int j = 0; j < this.IjvYEbGJscNPgzZqTUAgbsHenfTr.Count; j++)
		{
			this.IjvYEbGJscNPgzZqTUAgbsHenfTr[j].traDKlHspaXCdfNvtkwAFzPfEhYY(A_1);
		}
	}

	// Token: 0x0600091E RID: 2334 RVA: 0x00009A7D File Offset: 0x00007C7D
	public void Dispose()
	{
		this.wOnnWHaNEGudtyHOwQalElKKqlUM(true);
		GC.SuppressFinalize(this);
	}

	// Token: 0x0600091F RID: 2335 RVA: 0x00042E44 File Offset: 0x00041044
	protected void WmipenjWpUEDRxTaPaIKJkLYqluG()
	{
		try
		{
			this.wOnnWHaNEGudtyHOwQalElKKqlUM(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	// Token: 0x06000920 RID: 2336 RVA: 0x00042E74 File Offset: 0x00041074
	private void wOnnWHaNEGudtyHOwQalElKKqlUM(bool A_1)
	{
		if (this.zocKAyTmTQYuEfjdVxuXeDsoazeiA)
		{
			return;
		}
		if (A_1)
		{
			if (this.vmDLkaAYWRDTujFiAkNWylMcBFey is IDisposable)
			{
				(this.vmDLkaAYWRDTujFiAkNWylMcBFey as IDisposable).Dispose();
			}
			if (this.bQDuYGBHgPzFQqadFeiDVQEVZBkL is IDisposable)
			{
				(this.bQDuYGBHgPzFQqadFeiDVQEVZBkL as IDisposable).Dispose();
			}
		}
		this.zocKAyTmTQYuEfjdVxuXeDsoazeiA = true;
	}

	// Token: 0x040006C2 RID: 1730
	private List<Joystick> UbwRgnOnrybDDRQGflveHOxETQxK;

	// Token: 0x040006C3 RID: 1731
	private List<Joystick> rrwshdvoiWQuWIBqDKDLUyFIhZag;

	// Token: 0x040006C4 RID: 1732
	private List<CustomController> IjvYEbGJscNPgzZqTUAgbsHenfTr;

	// Token: 0x040006C5 RID: 1733
	private List<Controller> atgdJIInhyKudGsJgWEjzPkJWxsA;

	// Token: 0x040006C6 RID: 1734
	private ReadOnlyCollection<Controller> cdJAHwaJgeWdSGBRVkoZdzRUZfufA;

	// Token: 0x040006C7 RID: 1735
	private Keyboard SdKRHvJEjjZeHhCFxmZraUcsapNp;

	// Token: 0x040006C8 RID: 1736
	private Mouse zLnHuARWczJYSeFmlVDbGirTcMwf;

	// Token: 0x040006C9 RID: 1737
	private ConfigVars HqZpEmBsNwuTnbacnIotwOqnKfTp;

	// Token: 0x040006CA RID: 1738
	private iWmRLdlDqgwSNYjkwtUZeqvQOyqs[] tVBaITMhyygqGaLyzKGMqoFSdLHB;

	// Token: 0x040006CB RID: 1739
	private iWmRLdlDqgwSNYjkwtUZeqvQOyqs[] UQCwBVDCQDdcEoJdAgkWSDLTzmNG;

	// Token: 0x040006CC RID: 1740
	private iWmRLdlDqgwSNYjkwtUZeqvQOyqs[,] HgHEfKyJmTGNqsBkTNrgJKOPAwlBA;

	// Token: 0x040006CD RID: 1741
	private mEYbmhkubQXyWLdHdBzRRGwWDmxeb PanoIILHaUdGmkxoeFTsAzzMdTMx;

	// Token: 0x040006CE RID: 1742
	private EDsbfoobWXwcKBvvNHVrQUZhEIkn eiWSDTiITSSWViKCpmTnteGgZtDe;

	// Token: 0x040006CF RID: 1743
	private EDsbfoobWXwcKBvvNHVrQUZhEIkn[] mEaguLUTSqWIWzEiCYWUBHWcidpT;

	// Token: 0x040006D0 RID: 1744
	private asNHovBJNGfzQvNtBHQlZZahaCpW<ActiveControllerChangedDelegate> VclFijsSinGOdUpHLRUGgAMzPJAu;

	// Token: 0x040006D1 RID: 1745
	private asNHovBJNGfzQvNtBHQlZZahaCpW<PlayerActiveControllerChangedDelegate> eEpRtwLXpFNSpCeVCNtfxkdzhKny;

	// Token: 0x040006D2 RID: 1746
	private asNHovBJNGfzQvNtBHQlZZahaCpW<PlayerActiveControllerChangedDelegate>[] oGjwilvccNRqpYhhgJAgjCCbpHRF;

	// Token: 0x040006D3 RID: 1747
	private ADictionary<int, HEnwyLWfnrHknWieEccXGXTAawGsA.FJAwtONIirCNRRTzIggcsIbkgUBl> HofFVyzjUTYvxnDPlQfqEOFMQhhK;

	// Token: 0x040006D4 RID: 1748
	private readonly RXwELUeslTkclmlgxEgZCHffugOj kCXvUIWYymbXvGdUklSrMIHzfawAA;

	// Token: 0x040006D5 RID: 1749
	private IList<Joystick> vWecKCEQQBDkWSvtTltMphHdYlQmA;

	// Token: 0x040006D6 RID: 1750
	private IList<CustomController> zUSvEBgGkGUZOMjzscoKRGPnnVEq;

	// Token: 0x040006D7 RID: 1751
	private int yQkfGpRvhkghPjMdVidnIowWWwFg;

	// Token: 0x040006D8 RID: 1752
	private bool UewCmdpRVVwdmfcVccVBYJYbWfSK;

	// Token: 0x040006D9 RID: 1753
	private bool PHTphyfeVEZEPCHwKVXYfBXaJwCB;

	// Token: 0x040006DA RID: 1754
	private bool BqofeAJDdKsupXkLyIJNptjwMCxR;

	// Token: 0x040006DB RID: 1755
	private IUnifiedKeyboardSource vmDLkaAYWRDTujFiAkNWylMcBFey;

	// Token: 0x040006DC RID: 1756
	private IUnifiedMouseSource bQDuYGBHgPzFQqadFeiDVQEVZBkL;

	// Token: 0x040006DD RID: 1757
	private int PBcYOeYqjAASCHMmfsHZsLwQnnhd;

	// Token: 0x040006DE RID: 1758
	private FzUsTilBKKFkYXzvzcXjfuLKjXcd duMGvhBQWmQOaNghmuoCtxbyHqRiA;

	// Token: 0x040006DF RID: 1759
	private lNiLuHSggoLjokYLQforkkbXwySd wEwcfmITTSquheyvVLbSeCbDfKcu;

	// Token: 0x040006E0 RID: 1760
	private int uwdJDUjGnCEspMlnHLCzeqqwGzYo;

	// Token: 0x040006E1 RID: 1761
	private int TawUCoDrBIQqyYaxHLlDpJguMKDR;

	// Token: 0x040006E2 RID: 1762
	private Action<int, ControllerDataUpdater> qmvHlpKUStAEIqrItmRrKZSDebpe;

	// Token: 0x040006E3 RID: 1763
	private Action<bool, int, int> BpuluexJKhpezrffQCgkAgqyTWQB;

	// Token: 0x040006E4 RID: 1764
	private Action<ControllerStatusChangedEventArgs> lQkbyfzBUbSxAISNiwEbPjbzfmWQ;

	// Token: 0x040006E5 RID: 1765
	private Action<ControllerType, int> FhsDKOndKmDeNLaHPEwpBBFWHSgUA;

	// Token: 0x040006E6 RID: 1766
	private bool zocKAyTmTQYuEfjdVxuXeDsoazeiA;

	// Token: 0x02000105 RID: 261
	public enum KHCbyofpALMYVppWHChAOTYYCOJbb
	{
		// Token: 0x040006E8 RID: 1768
		Connected,
		// Token: 0x040006E9 RID: 1769
		Disconnected
	}

	// Token: 0x02000106 RID: 262
	private class FJAwtONIirCNRRTzIggcsIbkgUBl
	{
		// Token: 0x06000921 RID: 2337 RVA: 0x00042ED0 File Offset: 0x000410D0
		public FJAwtONIirCNRRTzIggcsIbkgUBl(List<InputBehavior> A_1)
		{
			this.mbxrQRSMXUgbDXRRjtvMHCKAekfE = new List<InputBehavior>(A_1.Count);
			this.OUAMITcAdcKJppCqAjdyJhxMUVFu = new ADictionary<int, InputBehavior>();
			int num = 0;
			for (int i = 0; i < A_1.Count; i++)
			{
				InputBehavior inputBehavior = A_1[i].Clone();
				this.OUAMITcAdcKJppCqAjdyJhxMUVFu.Add(A_1[i].id, inputBehavior);
				this.mbxrQRSMXUgbDXRRjtvMHCKAekfE.Add(inputBehavior);
				num++;
			}
			this.hYgdawDgHAudLSApZeXDPepHjMhtA = new ReadOnlyCollection<InputBehavior>(this.mbxrQRSMXUgbDXRRjtvMHCKAekfE);
		}

		// Token: 0x06000922 RID: 2338 RVA: 0x00042F58 File Offset: 0x00041158
		public InputBehavior qQSyQYCncuFxltXFcCFxwWYdpfev(int A_1)
		{
			if (this.mbxrQRSMXUgbDXRRjtvMHCKAekfE.Count == 0)
			{
				return null;
			}
			InputBehavior inputBehavior;
			this.OUAMITcAdcKJppCqAjdyJhxMUVFu.TryGetValue(A_1, out inputBehavior);
			if (inputBehavior == null)
			{
				return this.mbxrQRSMXUgbDXRRjtvMHCKAekfE[0];
			}
			return inputBehavior;
		}

		// Token: 0x040006EA RID: 1770
		public ADictionary<int, InputBehavior> OUAMITcAdcKJppCqAjdyJhxMUVFu;

		// Token: 0x040006EB RID: 1771
		public List<InputBehavior> mbxrQRSMXUgbDXRRjtvMHCKAekfE;

		// Token: 0x040006EC RID: 1772
		public IList<InputBehavior> hYgdawDgHAudLSApZeXDPepHjMhtA;
	}
}
