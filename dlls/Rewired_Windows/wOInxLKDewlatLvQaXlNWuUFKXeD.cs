using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Rewired;
using Rewired.Config;
using Rewired.Data;
using Rewired.HID.Drivers;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

// Token: 0x02000078 RID: 120
internal class wOInxLKDewlatLvQaXlNWuUFKXeD : IInputSource, IDisposable
{
	// Token: 0x170000C3 RID: 195
	// (get) Token: 0x060003D0 RID: 976 RVA: 0x0002CAF0 File Offset: 0x0002ACF0
	public static GUIText KPkZBddnSKnECSzMhPaEoHiRIlMY
	{
		get
		{
			if (wOInxLKDewlatLvQaXlNWuUFKXeD.BiTTaGdAoaIQrnjPMdOmPaHSJyir != null)
			{
				return wOInxLKDewlatLvQaXlNWuUFKXeD.BiTTaGdAoaIQrnjPMdOmPaHSJyir;
			}
			GameObject gameObject = GameObject.Find("DebugScreenLog");
			if (gameObject != null)
			{
				wOInxLKDewlatLvQaXlNWuUFKXeD.BiTTaGdAoaIQrnjPMdOmPaHSJyir = gameObject.GetComponent<GUIText>();
			}
			else
			{
				wOInxLKDewlatLvQaXlNWuUFKXeD.BiTTaGdAoaIQrnjPMdOmPaHSJyir = new GameObject("DebugScreenLog")
				{
					transform = 
					{
						position = Vector3.zero
					}
				}.AddComponent<GUIText>();
				wOInxLKDewlatLvQaXlNWuUFKXeD.BiTTaGdAoaIQrnjPMdOmPaHSJyir.anchor = TextAnchor.LowerLeft;
				wOInxLKDewlatLvQaXlNWuUFKXeD.BiTTaGdAoaIQrnjPMdOmPaHSJyir.alignment = TextAlignment.Left;
				wOInxLKDewlatLvQaXlNWuUFKXeD.BiTTaGdAoaIQrnjPMdOmPaHSJyir.pixelOffset = new Vector2(1200f, 0f);
			}
			return wOInxLKDewlatLvQaXlNWuUFKXeD.BiTTaGdAoaIQrnjPMdOmPaHSJyir;
		}
	}

	// Token: 0x170000C4 RID: 196
	// (get) Token: 0x060003D1 RID: 977 RVA: 0x000132FB File Offset: 0x000114FB
	// (set) Token: 0x060003D2 RID: 978 RVA: 0x00013303 File Offset: 0x00011503
	public xKKbjmIOHiqxZGRJDfbeyLuvTjMwB oQzxFwlcIcatZVsQxCfIuwzeBVMo
	{
		get
		{
			return this.VOXEPANloermVxmxCKXVPTVdufYF;
		}
		set
		{
			this.oQzxFwlcIcatZVsQxCfIuwzeBVMo = value;
		}
	}

	// Token: 0x060003D3 RID: 979 RVA: 0x0002CB8C File Offset: 0x0002AD8C
	public wOInxLKDewlatLvQaXlNWuUFKXeD(ConfigVars A_1, xKKbjmIOHiqxZGRJDfbeyLuvTjMwB A_2, bool A_3, bool A_4, FdQbBsfCWcVHOnPrmheJzorKWKWz A_5, LEiRbylTDtVrpnaZskyeFoLSqqLb A_6)
	{
		try
		{
			this.byzBIUJJDoWvgfkeWuusVKbxXOze = A_1;
			this.VOXEPANloermVxmxCKXVPTVdufYF = A_2;
			this.XiCvbepVuBGVOigDqJtHYRWjrRQe = A_1.updateLoop;
			this.zQevmraCUemJycjcpjreIFXDknaG = new ValueWatcher<IntPtr>(wLURyKQfpGlmweDJGGSrwwzrDUJFA.NcNUORJAUceCejbICLHRcPTLEkhIb(), new Func<IntPtr>(wLURyKQfpGlmweDJGGSrwwzrDUJFA.NcNUORJAUceCejbICLHRcPTLEkhIb), true);
			this.zQevmraCUemJycjcpjreIFXDknaG.ChangedEvent += this.NrSErvZUQSfRdrtTNYarPEmQFevc;
			this.dTTvbtaXrNYZVsRRzCSVLhknhAgi = new ValueWatcher[]
			{
				this.zQevmraCUemJycjcpjreIFXDknaG
			};
			this.avlBzQVOOmctrTpmEXHsrvYWsNTI = A_3;
			this.CbLbIBDreQeHPQDNNJCUfGWxISaOA = A_4;
			this.GUUroRNRLiezBPDFFGmhlWiSmoHL = A_5;
			this.gXVvryMkmbpClmcPKNxqhHppoQdo = A_6;
			this.pYWQLrMqbZxicddMdiGbfgukpRfg = (A_5 != null);
			this.gnaYFbRKchKCDvUQaJovVlrHNiC = (A_6 != null);
			this.PCIejCVVtKDeaxdrPCqsOfGdCdPJ = ((this.avlBzQVOOmctrTpmEXHsrvYWsNTI || this.pYWQLrMqbZxicddMdiGbfgukpRfg || this.gnaYFbRKchKCDvUQaJovVlrHNiC) && AfMbFsJstyiXPRpuLyuwQILIdQLv.FRZfFIdIDcdXyWzlJHopSpVsiLEeA);
			this.rTNnVqLbFSAxRQyXcoxqlsBoBPmw = new List<EnhancedDeviceSupportDeviceType>(A_1.GetPlatformVar_enhancedDeviceSupportExcludedDeviceTypes());
			this.ohhHLLilFLEnbfpQCbKOiiAJQDUkB = ReInput.applicationIsPaused;
			this.ioeTMnkQysQdidRcVfjtHDyRnpKL = ReInput.applicationIsFocused;
			AfMbFsJstyiXPRpuLyuwQILIdQLv.bnwEGZdnbSJOmzPPdZHiKJKOAqqN = new hBQcAwAetdQKZjGkFENcSNktvKpu<bool>(this.ybsAXrohdsnQdFllfMdQzwdFhCOh);
			this.ffkYtjjRvaFSHxGxPhNbvdnuYpCJ = ReInput.isEditor;
			this.gqfhhgwznGLRzmiNjYHEcqtjzOzq = new List<zOVftvsFbTAvLzuhvSRGfBOXFlHHA>();
			this.cDqDYMrVKRcMophnxGzUFVVuCqjk = new ReadOnlyCollection<zOVftvsFbTAvLzuhvSRGfBOXFlHHA>(this.gqfhhgwznGLRzmiNjYHEcqtjzOzq);
			this.FaqJQXJrsuIJDbMoyKdjTzteSzcC = new List<zOVftvsFbTAvLzuhvSRGfBOXFlHHA>();
			wOInxLKDewlatLvQaXlNWuUFKXeD.RQtbxjionSPSpBjLjzUxiOpfwirWB = new aZbrTJbdkEqNgMSlZADNlszSrpmR.AnIursTJiGuiIahXHibSRdYFdKfZ
			{
				OnJGzWMJOkxkATlpluSVlPnmrMIH = (uint)Marshal.SizeOf(typeof(aZbrTJbdkEqNgMSlZADNlszSrpmR.AnIursTJiGuiIahXHibSRdYFdKfZ)),
				GHNkjnBJUjplzLmywRadbNMWldFA = true,
				IdQtdOHFkZFQHtYTifxMEDStAZLB = true,
				UxYWMbUdjVSbIGFBRessNrffemhT = false,
				AplKVHuYukjdyoKgcEqKUHODyLzy = true,
				TemHGbdWzAXkpLQfGyOlqEjldWEvA = IntPtr.Zero
			};
			this.QKzAEzNTUnWYXWjSQsrTJtbRqrMg = aZbrTJbdkEqNgMSlZADNlszSrpmR.vCxDyydNFJNMDqHSEqWWufpOoHJUA.qjIByCWlgxekxDObTIDlPXbeauoB();
			this.COKcWHihCTjTEfutjLCgQiNdfUgab = new NativeBuffer((int)this.QKzAEzNTUnWYXWjSQsrTJtbRqrMg.JoJOgnnMFOFJfjMLWcwRlZpkptgUA);
			this.COKcWHihCTjTEfutjLCgQiNdfUgab.Write(this.QKzAEzNTUnWYXWjSQsrTJtbRqrMg.JoJOgnnMFOFJfjMLWcwRlZpkptgUA, 0);
			if (this.sXwLeordAktmuwEAZaWPKekWhBskA == CcbBkDoBwnFtqUaGWyRJqFJSOkwI.SharpDX)
			{
				this.QTPLVfRjQeuZVZHiubNkfoLfCGsM(new DLJMGaTLIFFDahvupJkOZBRJLNrj.osqZvvGFouEfTOmJrimLXBVCYjbl(this.bQigHQrORtDcMJSZhfGOfqWnuCzBA));
				this.hBOUKbdAqKjDYzNDKcYwPLLnPvCX();
			}
			if (A_3)
			{
				try
				{
					this.cisLLsPknlzYWHJEisFvDueNlFWV();
					wOInxLKDewlatLvQaXlNWuUFKXeD.qusBiZyjyfDVNeidhmejXkjssuVy(ref this.gqfhhgwznGLRzmiNjYHEcqtjzOzq, this.GCiIYWtxaRffrzPqGvNcFdISCQNO(true));
				}
				catch (Exception ex)
				{
					if (ex.Data != null && ex.Data.Contains(1) && ex.Data[1] as string == "sandbox")
					{
						Logger.LogWarning("Detected possible sandbox. Raw Input does not work correctly in a sandbox with default security settings.");
					}
					throw;
				}
			}
			this.zKxeoHiSWZCQqeeGLSrNABennkpkA();
			ReInput.ApplicationIsFullScreenChangedEvent += this.zJZUHbBxjuROzVpzAWHLPCgOjoyg;
			ReInput.ApplicationFullScreenModeChangedEvent += this.hFZFxMgudEokhbnUqWPCfHbTSARab;
			ReInput.ApplicationFocusChangedEvent += this.nPIbQjWYyOhWKSHjYYaVanveGEFm;
			ReInput.ApplicationPauseChangedEvent += this.gZTSwCAprClchmAABjyqHkWkJxeN;
		}
		catch (Exception)
		{
			this.Dispose();
			throw;
		}
	}

	// Token: 0x060003D4 RID: 980 RVA: 0x000116E9 File Offset: 0x0000F8E9
	public void cisLLsPknlzYWHJEisFvDueNlFWV()
	{
	}

	// Token: 0x060003D5 RID: 981 RVA: 0x0002CE88 File Offset: 0x0002B088
	public void VStpYFXpbmfvmwqthSuVyFwxYXgD()
	{
		if (this.avlBzQVOOmctrTpmEXHsrvYWsNTI)
		{
			object obj = this.fvWSismAsaUXmyHxiJukkIQtireq;
			lock (obj)
			{
				wOInxLKDewlatLvQaXlNWuUFKXeD.qusBiZyjyfDVNeidhmejXkjssuVy(ref this.gqfhhgwznGLRzmiNjYHEcqtjzOzq, this.FaqJQXJrsuIJDbMoyKdjTzteSzcC);
				this.FaqJQXJrsuIJDbMoyKdjTzteSzcC.Clear();
			}
		}
		if (this.gnaYFbRKchKCDvUQaJovVlrHNiC || this.PCIejCVVtKDeaxdrPCqsOfGdCdPJ)
		{
			this.lhGMHWnUNnTqcniXzyrohhsYgVEw();
		}
		this.JLzZoWISILHsQuFJXrjVrFLhgenkA = false;
	}

	// Token: 0x060003D6 RID: 982 RVA: 0x0002CF04 File Offset: 0x0002B104
	public bool rxjEIqjbpjPrYTwkutnBqbrcuXeFA()
	{
		object obj = this.fvWSismAsaUXmyHxiJukkIQtireq;
		bool result;
		lock (obj)
		{
			if (this.izHeYUSgjSiSCDXFzdbwqRtMlrROA())
			{
				Thread.Sleep(250);
			}
			if (this.avlBzQVOOmctrTpmEXHsrvYWsNTI)
			{
				this.FaqJQXJrsuIJDbMoyKdjTzteSzcC = this.GCiIYWtxaRffrzPqGvNcFdISCQNO(false);
			}
			else if (this.PCIejCVVtKDeaxdrPCqsOfGdCdPJ)
			{
				this.GWNeFTzIYUgxSHRMxZdKyxeMfszJ();
			}
			result = true;
		}
		return result;
	}

	// Token: 0x060003D7 RID: 983 RVA: 0x0002CF78 File Offset: 0x0002B178
	public bool LzAxMPcGXOwLzebwXNqQTFHmHZNgA()
	{
		int num = this.TXKqwJsbVkBjjXItSigNTepNbNDeA();
		if (num == this.HsvfrXPGUVtcBxVtDgDjDEOLqRDy)
		{
			return false;
		}
		this.HsvfrXPGUVtcBxVtDgDjDEOLqRDy = num;
		return true;
	}

	// Token: 0x060003D8 RID: 984 RVA: 0x0002CFA0 File Offset: 0x0002B1A0
	public bool izHeYUSgjSiSCDXFzdbwqRtMlrROA()
	{
		try
		{
			return hVaQpyMLtSMUpozCEslGMGuQGKOz.iPehqbpHJemsBVzgHDvrPhSCjRtW();
		}
		catch
		{
		}
		return false;
	}

	// Token: 0x060003D9 RID: 985 RVA: 0x0001330C File Offset: 0x0001150C
	public bool wJwRcfyujDrZJxaKmFmuXjHvYsoJ(bool A_1)
	{
		bool result = this.tTRWCjudTHdLbEXcLAgpFxERwIWaA;
		if (A_1)
		{
			this.tTRWCjudTHdLbEXcLAgpFxERwIWaA = false;
		}
		return result;
	}

	// Token: 0x14000008 RID: 8
	// (add) Token: 0x060003DA RID: 986 RVA: 0x0001331E File Offset: 0x0001151E
	// (remove) Token: 0x060003DB RID: 987 RVA: 0x0001331E File Offset: 0x0001151E
	public event Action DeviceChangedEvent
	{
		add
		{
			throw new NotImplementedException();
		}
		remove
		{
			throw new NotImplementedException();
		}
	}

	// Token: 0x060003DC RID: 988 RVA: 0x00013325 File Offset: 0x00011525
	public void SystemDeviceDisconnected()
	{
		if (this.avlBzQVOOmctrTpmEXHsrvYWsNTI)
		{
			this.JLzZoWISILHsQuFJXrjVrFLhgenkA = true;
		}
	}

	// Token: 0x060003DD RID: 989 RVA: 0x00013325 File Offset: 0x00011525
	public void SystemDeviceConnected()
	{
		if (this.avlBzQVOOmctrTpmEXHsrvYWsNTI)
		{
			this.JLzZoWISILHsQuFJXrjVrFLhgenkA = true;
		}
	}

	// Token: 0x060003DE RID: 990 RVA: 0x0002CFCC File Offset: 0x0002B1CC
	public void Update()
	{
		for (int i = 0; i < this.dTTvbtaXrNYZVsRRzCSVLhknhAgi.Length; i++)
		{
			this.dTTvbtaXrNYZVsRRzCSVLhknhAgi[i].Update();
		}
		if (this.NfGpJIgYzUOTDvYCQeGrBiBwcHdQ >= 0)
		{
			this.oCLSopbrRVspKTLhSAdKBZRcWtLZ();
		}
		if (this.ffkYtjjRvaFSHxGxPhNbvdnuYpCJ)
		{
			if (this.NfGpJIgYzUOTDvYCQeGrBiBwcHdQ < 0 && (this.gnaYFbRKchKCDvUQaJovVlrHNiC || this.pYWQLrMqbZxicddMdiGbfgukpRfg || this.PCIejCVVtKDeaxdrPCqsOfGdCdPJ))
			{
				this.ctynvvFRQLeVEqdOyDIeeAmBmPnfb();
				return;
			}
		}
		else if (this.gnaYFbRKchKCDvUQaJovVlrHNiC || this.pYWQLrMqbZxicddMdiGbfgukpRfg || this.PCIejCVVtKDeaxdrPCqsOfGdCdPJ)
		{
			this.ASrfimkxwwnrQSnCDVDoFORtpDxEb();
		}
	}

	// Token: 0x060003DF RID: 991 RVA: 0x0002D058 File Offset: 0x0002B258
	public void UpdateDevices(UpdateLoopType updateLoop)
	{
		if (!this.avlBzQVOOmctrTpmEXHsrvYWsNTI)
		{
			return;
		}
		int count = this.gqfhhgwznGLRzmiNjYHEcqtjzOzq.Count;
		for (int i = 0; i < count; i++)
		{
			wiIzvHRiukqjxVPnFrbFTKiAAbar wiIzvHRiukqjxVPnFrbFTKiAAbar = this.gqfhhgwznGLRzmiNjYHEcqtjzOzq[i];
			if (wiIzvHRiukqjxVPnFrbFTKiAAbar != null)
			{
				wiIzvHRiukqjxVPnFrbFTKiAAbar.PawKuuUFceCoNYoeEnArIghpmuvH(updateLoop);
			}
		}
	}

	// Token: 0x060003E0 RID: 992 RVA: 0x0002D0A0 File Offset: 0x0002B2A0
	public void UpdateFinished()
	{
		if (!this.avlBzQVOOmctrTpmEXHsrvYWsNTI)
		{
			return;
		}
		int count = this.gqfhhgwznGLRzmiNjYHEcqtjzOzq.Count;
		for (int i = 0; i < count; i++)
		{
			wiIzvHRiukqjxVPnFrbFTKiAAbar wiIzvHRiukqjxVPnFrbFTKiAAbar = this.gqfhhgwznGLRzmiNjYHEcqtjzOzq[i];
			if (wiIzvHRiukqjxVPnFrbFTKiAAbar != null)
			{
				wiIzvHRiukqjxVPnFrbFTKiAAbar.oSYdaCPoVpoNnLDVaZpldzzFOrXc();
			}
		}
	}

	// Token: 0x060003E1 RID: 993 RVA: 0x00013336 File Offset: 0x00011536
	public IList<T> GetJoysticks<T>() where T : class
	{
		return this.cDqDYMrVKRcMophnxGzUFVVuCqjk as IList<T>;
	}

	// Token: 0x060003E2 RID: 994 RVA: 0x0002D0E4 File Offset: 0x0002B2E4
	private List<zOVftvsFbTAvLzuhvSRGfBOXFlHHA> GCiIYWtxaRffrzPqGvNcFdISCQNO(bool A_1)
	{
		wOInxLKDewlatLvQaXlNWuUFKXeD.wGmOTuzHwFSApaLtIJVrScgddjCE wGmOTuzHwFSApaLtIJVrScgddjCE = new wOInxLKDewlatLvQaXlNWuUFKXeD.wGmOTuzHwFSApaLtIJVrScgddjCE();
		if (!this.avlBzQVOOmctrTpmEXHsrvYWsNTI)
		{
			return new List<zOVftvsFbTAvLzuhvSRGfBOXFlHHA>();
		}
		this.GWNeFTzIYUgxSHRMxZdKyxeMfszJ();
		List<gQTKGFfzfVUQLsYqHcEkxTUCIvrS> list = null;
		List<zOVftvsFbTAvLzuhvSRGfBOXFlHHA> list2 = new List<zOVftvsFbTAvLzuhvSRGfBOXFlHHA>();
		this.HsvfrXPGUVtcBxVtDgDjDEOLqRDy = this.IwaGJtlnBwTRKgadfuGtdqqiLQVI();
		if (!false)
		{
			list = AfMbFsJstyiXPRpuLyuwQILIdQLv.wvyrotMfAPZhyDRnAmSBvfIdGHTf(A_1);
		}
		if (list == null)
		{
			list = new List<gQTKGFfzfVUQLsYqHcEkxTUCIvrS>();
		}
		try
		{
			wGmOTuzHwFSApaLtIJVrScgddjCE.cxxCrvKSrjPrHVsUijgfALQUltybA = hVaQpyMLtSMUpozCEslGMGuQGKOz.XIdsBUUOcbARUtxlQaLttqvyKcxn();
		}
		catch (Exception ex)
		{
			wGmOTuzHwFSApaLtIJVrScgddjCE.cxxCrvKSrjPrHVsUijgfALQUltybA = new List<hVaQpyMLtSMUpozCEslGMGuQGKOz.UHslNClYbydtNrFHkmjroviMCtpA>();
			string str = "Exception getting HID device list.\n";
			Exception ex2 = ex;
			Logger.LogError(str + ((ex2 != null) ? ex2.ToString() : null));
		}
		List<string> list3 = new List<string>();
		int num = 0;
		for (int i = 0; i < list.Count; i++)
		{
			try
			{
				gQTKGFfzfVUQLsYqHcEkxTUCIvrS gQTKGFfzfVUQLsYqHcEkxTUCIvrS = list[i];
				if (list[i] != null)
				{
					if (gQTKGFfzfVUQLsYqHcEkxTUCIvrS.RuxEkEzlavDvHcJlGGFACRZdoLCUb == OiWGlufNbZAVpTSvEHgxGrekNlFFA.HumanInputDevice)
					{
						wuOZnvOfTnpCqMaNXGiLcIupgKiG wuOZnvOfTnpCqMaNXGiLcIupgKiG = gQTKGFfzfVUQLsYqHcEkxTUCIvrS as wuOZnvOfTnpCqMaNXGiLcIupgKiG;
						if (wuOZnvOfTnpCqMaNXGiLcIupgKiG != null)
						{
							zOVftvsFbTAvLzuhvSRGfBOXFlHHA zOVftvsFbTAvLzuhvSRGfBOXFlHHA = this.OaiFHdwuxqBLDBJXyqKXKjkzmrmHA(gQTKGFfzfVUQLsYqHcEkxTUCIvrS.FPNtdqIgjPgShixBYYTbeadhfqot, wuOZnvOfTnpCqMaNXGiLcIupgKiG, wGmOTuzHwFSApaLtIJVrScgddjCE.cxxCrvKSrjPrHVsUijgfALQUltybA, list3, num);
							if (zOVftvsFbTAvLzuhvSRGfBOXFlHHA != null)
							{
								list2.Add(zOVftvsFbTAvLzuhvSRGfBOXFlHHA);
								num++;
							}
						}
					}
				}
			}
			catch (Exception ex3)
			{
				Logger.LogError("An exception occurred while initializing HID device! This device will be non-functional.\n" + ex3.Message);
			}
		}
		if (this.oQzxFwlcIcatZVsQxCfIuwzeBVMo == null || (this.oQzxFwlcIcatZVsQxCfIuwzeBVMo.FPcmcApMcgfMMcFhtgEUQlTEawosA != BEzoLQEyeVcMuWZsryGeXRQqhkdd.XInput && this.oQzxFwlcIcatZVsQxCfIuwzeBVMo.FPcmcApMcgfMMcFhtgEUQlTEawosA != BEzoLQEyeVcMuWZsryGeXRQqhkdd.WindowsGamingInput))
		{
			wGmOTuzHwFSApaLtIJVrScgddjCE.QvqeIxeuCCsmqpTVkeAwFRiubUuMA = 0;
			while (wGmOTuzHwFSApaLtIJVrScgddjCE.QvqeIxeuCCsmqpTVkeAwFRiubUuMA < wGmOTuzHwFSApaLtIJVrScgddjCE.cxxCrvKSrjPrHVsUijgfALQUltybA.Count)
			{
				try
				{
					List<string> list4 = list3;
					Predicate<string> match;
					if ((match = wGmOTuzHwFSApaLtIJVrScgddjCE.iuruCJPNnUybnPfaebyGbJHPcGGR) == null)
					{
						match = (wGmOTuzHwFSApaLtIJVrScgddjCE.iuruCJPNnUybnPfaebyGbJHPcGGR = new Predicate<string>(wGmOTuzHwFSApaLtIJVrScgddjCE.xldDoasmQoOMQlWCECcFqKAvDXKDA));
					}
					if (string.IsNullOrEmpty(list4.Find(match)))
					{
						zOVftvsFbTAvLzuhvSRGfBOXFlHHA zOVftvsFbTAvLzuhvSRGfBOXFlHHA2 = this.IMIHfgBNSkCHzqbIxcCWzNZLcVVBA(wGmOTuzHwFSApaLtIJVrScgddjCE.cxxCrvKSrjPrHVsUijgfALQUltybA[wGmOTuzHwFSApaLtIJVrScgddjCE.QvqeIxeuCCsmqpTVkeAwFRiubUuMA], num);
						if (zOVftvsFbTAvLzuhvSRGfBOXFlHHA2 != null)
						{
							list2.Add(zOVftvsFbTAvLzuhvSRGfBOXFlHHA2);
							num++;
						}
					}
				}
				catch (Exception ex4)
				{
					Logger.LogError("An exception occurred while initializing HID device! This device will be non-functional.\n" + ex4.Message);
				}
				int qvqeIxeuCCsmqpTVkeAwFRiubUuMA = wGmOTuzHwFSApaLtIJVrScgddjCE.QvqeIxeuCCsmqpTVkeAwFRiubUuMA;
				wGmOTuzHwFSApaLtIJVrScgddjCE.QvqeIxeuCCsmqpTVkeAwFRiubUuMA = qvqeIxeuCCsmqpTVkeAwFRiubUuMA + 1;
			}
		}
		return list2;
	}

	// Token: 0x060003E3 RID: 995 RVA: 0x0002D314 File Offset: 0x0002B514
	private static void qusBiZyjyfDVNeidhmejXkjssuVy(ref List<zOVftvsFbTAvLzuhvSRGfBOXFlHHA> A_0, List<zOVftvsFbTAvLzuhvSRGfBOXFlHHA> A_1)
	{
		if (A_0 == null)
		{
			A_0 = new List<zOVftvsFbTAvLzuhvSRGfBOXFlHHA>();
		}
		if (A_1 == null)
		{
			A_1 = new List<zOVftvsFbTAvLzuhvSRGfBOXFlHHA>();
		}
		if (A_1.Count == 0)
		{
			A_0.ForEach(new Action<zOVftvsFbTAvLzuhvSRGfBOXFlHHA>(wOInxLKDewlatLvQaXlNWuUFKXeD.EZOytEZJoCIWJFyPcnnZreUwnJAFb.<>9.IIVpMytGJnGDeOQTgijYkgpyjLzU));
			A_0.Clear();
			return;
		}
		int count = A_1.Count;
		int count2 = A_0.Count;
		zOVftvsFbTAvLzuhvSRGfBOXFlHHA[] array = A_1.ToArray();
		if (array.Length != 0)
		{
			Array.Sort<zOVftvsFbTAvLzuhvSRGfBOXFlHHA>(array, new Comparison<zOVftvsFbTAvLzuhvSRGfBOXFlHHA>(wOInxLKDewlatLvQaXlNWuUFKXeD.RKJjHLutMpBsSEoPnOgBMVfsvVFR));
		}
		for (int i = 0; i < count2; i++)
		{
			wOInxLKDewlatLvQaXlNWuUFKXeD.fuynTgodjwtsjbgAdUCtPyslhInC fuynTgodjwtsjbgAdUCtPyslhInC = new wOInxLKDewlatLvQaXlNWuUFKXeD.fuynTgodjwtsjbgAdUCtPyslhInC();
			fuynTgodjwtsjbgAdUCtPyslhInC.GPfDnZDXiEYGvucMRGOnhSpbNtHQ = A_0[i];
			if (fuynTgodjwtsjbgAdUCtPyslhInC.GPfDnZDXiEYGvucMRGOnhSpbNtHQ != null && Array.Find<zOVftvsFbTAvLzuhvSRGfBOXFlHHA>(array, new Predicate<zOVftvsFbTAvLzuhvSRGfBOXFlHHA>(fuynTgodjwtsjbgAdUCtPyslhInC.kiGYefaoUOoXCZBlBwbzlwewvIPu)) == null)
			{
				fuynTgodjwtsjbgAdUCtPyslhInC.GPfDnZDXiEYGvucMRGOnhSpbNtHQ.Dispose();
			}
		}
		A_0.Clear();
		for (int j = 0; j < count; j++)
		{
			if (array[j] != null)
			{
				array[j].oseWaMMFmKPSMmsXpaJMWciNfywAA(j);
				A_0.Add(array[j]);
			}
		}
	}

	// Token: 0x060003E4 RID: 996 RVA: 0x0002D418 File Offset: 0x0002B618
	private List<gQTKGFfzfVUQLsYqHcEkxTUCIvrS> bQXceniXKJacDwmoHEsRtrBHvBWh()
	{
		List<gQTKGFfzfVUQLsYqHcEkxTUCIvrS> list = new List<gQTKGFfzfVUQLsYqHcEkxTUCIvrS>();
		try
		{
			foreach (gGETNRbPSWqlyBUigXMEkvuRFmnB gGETNRbPSWqlyBUigXMEkvuRFmnB in hVaQpyMLtSMUpozCEslGMGuQGKOz.ovckqmxbrLuQfRmmxZZSxyoQPCcu())
			{
				try
				{
					list.Add(new wuOZnvOfTnpCqMaNXGiLcIupgKiG
					{
						uzgDNalfgciXaPcKRPJtKaHpJTwI = AdSkHYvPxgeOVFEGslVOiHZEQBxjb.zntnSUJJitVdtJJQJKoubsHXrwF(gGETNRbPSWqlyBUigXMEkvuRFmnB.nyEfTKiBlpGrjhSHAOmjrGriiJiR),
						RuxEkEzlavDvHcJlGGFACRZdoLCUb = OiWGlufNbZAVpTSvEHgxGrekNlFFA.HumanInputDevice,
						FPNtdqIgjPgShixBYYTbeadhfqot = IntPtr.Zero,
						NyEWMarAhoYWFCJgplTmtAQDAYMO = gGETNRbPSWqlyBUigXMEkvuRFmnB.EbvtIjwOqlVUjYPaPgAizbpABXIw.yWhgKuXCSVHPWvYYnJRdryFUTekj,
						mgstcPbrjpSmlNrjrbnvTpfVyZys = gGETNRbPSWqlyBUigXMEkvuRFmnB.EbvtIjwOqlVUjYPaPgAizbpABXIw.NQEQBXVZUGlRQtHlwpaoFEPXdsHz,
						fXWSerSGvGkAYDDGpVrkjPqbmWy = gGETNRbPSWqlyBUigXMEkvuRFmnB.EbvtIjwOqlVUjYPaPgAizbpABXIw.iqDuKIugBhHARAfocOocIeCmsDULA,
						YFCcNPSKPomRKIHcgMCDFtwUpfaY = (kyyeJPAifzwsCJMsRzCRiCmfOgCIA)gGETNRbPSWqlyBUigXMEkvuRFmnB.uStAgDxEcOAbbgfjBKKeIdWrklZcb.cokBHYDpGjMULdyNCfUoWDZvhZIpA,
						lZZlPJRhTqIoSOAdPyojDoafFNot = (RAVOkNOPomjLLELffRNedOUcwUii)gGETNRbPSWqlyBUigXMEkvuRFmnB.uStAgDxEcOAbbgfjBKKeIdWrklZcb.tmpUyTjLkuZKfbsSAFjDQZhZBIfE
					});
				}
				catch
				{
				}
			}
		}
		catch
		{
		}
		return list;
	}

	// Token: 0x060003E5 RID: 997 RVA: 0x0002D510 File Offset: 0x0002B710
	private zOVftvsFbTAvLzuhvSRGfBOXFlHHA OaiFHdwuxqBLDBJXyqKXKjkzmrmHA(IntPtr A_1, wuOZnvOfTnpCqMaNXGiLcIupgKiG A_2, IList<hVaQpyMLtSMUpozCEslGMGuQGKOz.UHslNClYbydtNrFHkmjroviMCtpA> A_3, List<string> A_4, int A_5)
	{
		ushort num = (ushort)A_2.YFCcNPSKPomRKIHcgMCDFtwUpfaY;
		ushort num2 = (ushort)A_2.lZZlPJRhTqIoSOAdPyojDoafFNot;
		string text = A_2.uzgDNalfgciXaPcKRPJtKaHpJTwI;
		if (!this.fSLYrFPkbBGtUsiWmLVkEQnvkOon(num, num2))
		{
			return null;
		}
		string text2 = AdSkHYvPxgeOVFEGslVOiHZEQBxjb.zntnSUJJitVdtJJQJKoubsHXrwF(text);
		if (string.IsNullOrEmpty(text2))
		{
			return null;
		}
		A_4.Add(text2);
		UNUwlYTygIQzsQfFTWPgdoKuWLAh unuwlYTygIQzsQfFTWPgdoKuWLAh = hVaQpyMLtSMUpozCEslGMGuQGKOz.lnvdccdMVgTnljxVjTMcCZaFiPRb(A_3, text2, StringComparison.OrdinalIgnoreCase);
		if (unuwlYTygIQzsQfFTWPgdoKuWLAh == null)
		{
			unuwlYTygIQzsQfFTWPgdoKuWLAh = wOInxLKDewlatLvQaXlNWuUFKXeD.pIHDcrDscxxIBcviwGKasvZcCcqtA.jQRHvUzrzgGhXrFdNwsPUwevLcfH(A_1, text);
		}
		if (hBuWSCmGcOQpciLbksGnpuoZgfKL.XNYjZDiIVbrmdKmQXabQEVgXZVGv(InputSource.RawInput, (ushort)A_2.mgstcPbrjpSmlNrjrbnvTpfVyZys, (ushort)A_2.NyEWMarAhoYWFCJgplTmtAQDAYMO, unuwlYTygIQzsQfFTWPgdoKuWLAh.uHmffYhTWkNNUoSBeauUySsqVBCEA ? hBuWSCmGcOQpciLbksGnpuoZgfKL.LgQBOxfTJCrrfnygLkUBaMRumJbgA.Bluetooth : hBuWSCmGcOQpciLbksGnpuoZgfKL.LgQBOxfTJCrrfnygLkUBaMRumJbgA.USB))
		{
			return null;
		}
		if (num == 1 && (num2 == 4 || num2 == 5))
		{
			string text3 = unuwlYTygIQzsQfFTWPgdoKuWLAh.cOvNaQIzOlfzWiDaUJRCNBVgjRbh();
			string text4 = unuwlYTygIQzsQfFTWPgdoKuWLAh.svgWTFfTaOoHwzVJzcBrQWCRKqaj;
			if (hBuWSCmGcOQpciLbksGnpuoZgfKL.qXSZtztVLdKRkNcFcxvAGGTyPMAt(MiscTools.CreateHIDProductGuid(unuwlYTygIQzsQfFTWPgdoKuWLAh.EbvtIjwOqlVUjYPaPgAizbpABXIw.NQEQBXVZUGlRQtHlwpaoFEPXdsHz, unuwlYTygIQzsQfFTWPgdoKuWLAh.EbvtIjwOqlVUjYPaPgAizbpABXIw.yWhgKuXCSVHPWvYYnJRdryFUTekj), text3, text4))
			{
				A_4.RemoveAt(A_4.Count - 1);
				return null;
			}
		}
		return this.tbrChkIqCSYCqgWWsLIvIEiCHmsp(FxRFkHqAoYVwWnmGeGdaqipeCVP.RawInput, unuwlYTygIQzsQfFTWPgdoKuWLAh, A_1, num, num2, A_5);
	}

	// Token: 0x060003E6 RID: 998 RVA: 0x0002D5FC File Offset: 0x0002B7FC
	private zOVftvsFbTAvLzuhvSRGfBOXFlHHA IMIHfgBNSkCHzqbIxcCWzNZLcVVBA(hVaQpyMLtSMUpozCEslGMGuQGKOz.UHslNClYbydtNrFHkmjroviMCtpA A_1, int A_2)
	{
		gGETNRbPSWqlyBUigXMEkvuRFmnB gGETNRbPSWqlyBUigXMEkvuRFmnB = hVaQpyMLtSMUpozCEslGMGuQGKOz.skrJEAmJgzdQYFwBZcIKToFrPvhT(A_1);
		if (gGETNRbPSWqlyBUigXMEkvuRFmnB == null)
		{
			return null;
		}
		ushort num = (ushort)gGETNRbPSWqlyBUigXMEkvuRFmnB.uStAgDxEcOAbbgfjBKKeIdWrklZcb.cokBHYDpGjMULdyNCfUoWDZvhZIpA;
		ushort num2 = (ushort)gGETNRbPSWqlyBUigXMEkvuRFmnB.uStAgDxEcOAbbgfjBKKeIdWrklZcb.tmpUyTjLkuZKfbsSAFjDQZhZBIfE;
		if (!this.fSLYrFPkbBGtUsiWmLVkEQnvkOon(num, num2))
		{
			return null;
		}
		bool flag = false;
		if (num == 1 && (num2 == 4 || num2 == 5))
		{
			flag = hBuWSCmGcOQpciLbksGnpuoZgfKL.qXSZtztVLdKRkNcFcxvAGGTyPMAt(MiscTools.CreateHIDProductGuid(gGETNRbPSWqlyBUigXMEkvuRFmnB.EbvtIjwOqlVUjYPaPgAizbpABXIw.NQEQBXVZUGlRQtHlwpaoFEPXdsHz, gGETNRbPSWqlyBUigXMEkvuRFmnB.EbvtIjwOqlVUjYPaPgAizbpABXIw.yWhgKuXCSVHPWvYYnJRdryFUTekj), gGETNRbPSWqlyBUigXMEkvuRFmnB.yDlpKfYNRJPjFpkOawJepdPmqNqk(), gGETNRbPSWqlyBUigXMEkvuRFmnB.svgWTFfTaOoHwzVJzcBrQWCRKqaj);
		}
		if (!flag)
		{
			return null;
		}
		return this.tbrChkIqCSYCqgWWsLIvIEiCHmsp(FxRFkHqAoYVwWnmGeGdaqipeCVP.ManualHID, gGETNRbPSWqlyBUigXMEkvuRFmnB, IntPtr.Zero, num, num2, A_2);
	}

	// Token: 0x060003E7 RID: 999 RVA: 0x0002D68C File Offset: 0x0002B88C
	private zOVftvsFbTAvLzuhvSRGfBOXFlHHA tbrChkIqCSYCqgWWsLIvIEiCHmsp(FxRFkHqAoYVwWnmGeGdaqipeCVP A_1, UNUwlYTygIQzsQfFTWPgdoKuWLAh A_2, IntPtr A_3, ushort A_4, ushort A_5, int A_6)
	{
		bool flag = A_4 != 1 || !RLbkoaRPDXRzmKExBEtUQDSoURiR.nQeCISRjgnexBQgvhJFRzgSWpCKf.iplAcXOqXXjEoMerUqCToHczUTZm(A_5);
		if (this.VOXEPANloermVxmxCKXVPTVdufYF != null && A_4 == 1 && (A_5 == 4 || A_5 == 5) && this.VOXEPANloermVxmxCKXVPTVdufYF.XZVIPNtjsWKFpBxKFSKwHpIrwBWV(A_2.nyEfTKiBlpGrjhSHAOmjrGriiJiR, A_2.cOvNaQIzOlfzWiDaUJRCNBVgjRbh(), A_2.svgWTFfTaOoHwzVJzcBrQWCRKqaj, new PidVid((ushort)A_2.EbvtIjwOqlVUjYPaPgAizbpABXIw.yWhgKuXCSVHPWvYYnJRdryFUTekj, (ushort)A_2.EbvtIjwOqlVUjYPaPgAizbpABXIw.NQEQBXVZUGlRQtHlwpaoFEPXdsHz)))
		{
			return null;
		}
		zOVftvsFbTAvLzuhvSRGfBOXFlHHA zOVftvsFbTAvLzuhvSRGfBOXFlHHA = this.XsOcnoBuVGTunMXXnLlaudQirXVi(A_1, A_3, A_6, A_2, this.gqfhhgwznGLRzmiNjYHEcqtjzOzq, flag);
		if (zOVftvsFbTAvLzuhvSRGfBOXFlHHA == null || !zOVftvsFbTAvLzuhvSRGfBOXFlHHA.GZmyVoFCcDOJGKGBzcBcPUOXDtwX)
		{
			if (zOVftvsFbTAvLzuhvSRGfBOXFlHHA != null && !zOVftvsFbTAvLzuhvSRGfBOXFlHHA.GZmyVoFCcDOJGKGBzcBcPUOXDtwX)
			{
				zOVftvsFbTAvLzuhvSRGfBOXFlHHA.Dispose();
			}
			return null;
		}
		return zOVftvsFbTAvLzuhvSRGfBOXFlHHA;
	}

	// Token: 0x060003E8 RID: 1000 RVA: 0x0002D734 File Offset: 0x0002B934
	private bool fSLYrFPkbBGtUsiWmLVkEQnvkOon(ushort A_1, ushort A_2)
	{
		for (int i = 0; i < wOInxLKDewlatLvQaXlNWuUFKXeD.hhsEgrUYvBDIdSzGNSTABLOygAEIA.Length; i++)
		{
			if (wOInxLKDewlatLvQaXlNWuUFKXeD.hhsEgrUYvBDIdSzGNSTABLOygAEIA[i].KeDWeKHKNMDtGpjOqkkXSjHefuZO == A_1 && wOInxLKDewlatLvQaXlNWuUFKXeD.hhsEgrUYvBDIdSzGNSTABLOygAEIA[i].bVkkIEYQJGEcvgqHglIZEtIQSSXqA == A_2)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060003E9 RID: 1001 RVA: 0x0002D774 File Offset: 0x0002B974
	private int IwaGJtlnBwTRKgadfuGtdqqiLQVI()
	{
		int result;
		try
		{
			result = hVaQpyMLtSMUpozCEslGMGuQGKOz.GATPdGwuXXWcgIpclxWHZBNsKXDE();
		}
		catch
		{
			result = 0;
		}
		return result;
	}

	// Token: 0x060003EA RID: 1002 RVA: 0x0002D7A0 File Offset: 0x0002B9A0
	private int TXKqwJsbVkBjjXItSigNTepNbNDeA()
	{
		int result;
		try
		{
			result = hVaQpyMLtSMUpozCEslGMGuQGKOz.ujPsFjeHpPPlwkphybzwdVjrgbFhb(ref wOInxLKDewlatLvQaXlNWuUFKXeD.RQtbxjionSPSpBjLjzUxiOpfwirWB, this.COKcWHihCTjTEfutjLCgQiNdfUgab);
		}
		catch (Exception)
		{
			result = 0;
		}
		return result;
	}

	// Token: 0x060003EB RID: 1003 RVA: 0x0002D7D8 File Offset: 0x0002B9D8
	private zOVftvsFbTAvLzuhvSRGfBOXFlHHA XsOcnoBuVGTunMXXnLlaudQirXVi(FxRFkHqAoYVwWnmGeGdaqipeCVP A_1, IntPtr A_2, int A_3, UNUwlYTygIQzsQfFTWPgdoKuWLAh A_4, List<zOVftvsFbTAvLzuhvSRGfBOXFlHHA> A_5, bool A_6)
	{
		if (A_6 && !this.CbLbIBDreQeHPQDNNJCUfGWxISaOA)
		{
			return null;
		}
		try
		{
			if (this.CbLbIBDreQeHPQDNNJCUfGWxISaOA)
			{
				if (A_5 != null)
				{
					for (int i = 0; i < A_5.Count; i++)
					{
						szMajbesPjZtaStoBRqOiECwXHtE szMajbesPjZtaStoBRqOiECwXHtE = A_5[i] as szMajbesPjZtaStoBRqOiECwXHtE;
						if (szMajbesPjZtaStoBRqOiECwXHtE != null && szMajbesPjZtaStoBRqOiECwXHtE.tyAiqnJTfiEhtdOAyaqGhYQnJKbU != null && !(A_4.RoInVdEkWcIztboDcLpJMuMbhQIB != szMajbesPjZtaStoBRqOiECwXHtE.jvLgyhfwUUkKRMJtbBZuAOsivFLPB.RoInVdEkWcIztboDcLpJMuMbhQIB))
						{
							szMajbesPjZtaStoBRqOiECwXHtE.ULdZbAwQFmYCXhZbXZuloCQLcFTE(A_3);
							return szMajbesPjZtaStoBRqOiECwXHtE;
						}
					}
				}
				HIDDeviceDriver.DriverType driverType = HIDDeviceDriver.FindDriverId(A_4.EbvtIjwOqlVUjYPaPgAizbpABXIw.NQEQBXVZUGlRQtHlwpaoFEPXdsHz, A_4.EbvtIjwOqlVUjYPaPgAizbpABXIw.yWhgKuXCSVHPWvYYnJRdryFUTekj, this.rTNnVqLbFSAxRQyXcoxqlsBoBPmw);
				if (driverType != HIDDeviceDriver.DriverType.None)
				{
					qxfynNTzhcgKivFwRJjlHgrcRzob qxfynNTzhcgKivFwRJjlHgrcRzob = qxfynNTzhcgKivFwRJjlHgrcRzob.Overlapped;
					qxfynNTzhcgKivFwRJjlHgrcRzob qxfynNTzhcgKivFwRJjlHgrcRzob2 = qxfynNTzhcgKivFwRJjlHgrcRzob.Overlapped;
					hhPqsFbzywnSQVhdyrXfEDbDgBfaA hhPqsFbzywnSQVhdyrXfEDbDgBfaA = hhPqsFbzywnSQVhdyrXfEDbDgBfaA.ShareRead | hhPqsFbzywnSQVhdyrXfEDbDgBfaA.ShareWrite;
					if (driverType == HIDDeviceDriver.DriverType.DualShock4 && A_4.uHmffYhTWkNNUoSBeauUySsqVBCEA)
					{
						qxfynNTzhcgKivFwRJjlHgrcRzob = qxfynNTzhcgKivFwRJjlHgrcRzob.NonOverlapped;
						qxfynNTzhcgKivFwRJjlHgrcRzob2 = qxfynNTzhcgKivFwRJjlHgrcRzob.NonOverlapped;
					}
					A_4.uVPBHjvakOeSgAAwROmHrAhRuUouA(true, qxfynNTzhcgKivFwRJjlHgrcRzob, true, qxfynNTzhcgKivFwRJjlHgrcRzob2, hhPqsFbzywnSQVhdyrXfEDbDgBfaA);
					if (!A_4.nPQpkQBByBKglLzMtSwncbjmhvpd)
					{
						throw new Exception();
					}
					bCrPvFjWmsstplKHCuEMMNuBtNlb bCrPvFjWmsstplKHCuEMMNuBtNlb = new bCrPvFjWmsstplKHCuEMMNuBtNlb(new bCrPvFjWmsstplKHCuEMMNuBtNlb.yjFMfePbidWHUhfyjlFsaoEVPijd(A_4.JsOzJtYtutmTSoYuRdQKHmwEhpUy));
					HIDDeviceDriver driver = HIDDeviceDriver.GetDriver(driverType, new HIDDeviceDriver.InitArgs(this.XiCvbepVuBGVOigDqJtHYRWjrRQe, A_4.uHmffYhTWkNNUoSBeauUySsqVBCEA ? srhddSmbipxLrwlIqjetZPjyhATp.Bluetooth : srhddSmbipxLrwlIqjetZPjyhATp.USB, 65535, -65535, -1, 4500, new wOInxLKDewlatLvQaXlNWuUFKXeD.bDkGXbbOFPbPhNDUOtOKwGHPkkzfb(A_4, bCrPvFjWmsstplKHCuEMMNuBtNlb)));
					if (driver != null)
					{
						return new szMajbesPjZtaStoBRqOiECwXHtE(A_3, A_1, A_2, A_4, driver, bCrPvFjWmsstplKHCuEMMNuBtNlb, qxfynNTzhcgKivFwRJjlHgrcRzob, qxfynNTzhcgKivFwRJjlHgrcRzob2, hhPqsFbzywnSQVhdyrXfEDbDgBfaA);
					}
					A_4.TTKERvktiaSoYWqfrClYMFQcSmYo();
				}
				if (A_6)
				{
					return null;
				}
			}
		}
		catch
		{
			Logger.LogWarning("Exception creating custom driver joystick. Will fall back to normal HID joystick.");
			A_4.TTKERvktiaSoYWqfrClYMFQcSmYo();
		}
		zOVftvsFbTAvLzuhvSRGfBOXFlHHA result;
		try
		{
			if (A_5 != null)
			{
				for (int j = 0; j < A_5.Count; j++)
				{
					MYlXCVOJEGnqGqWVYCnPgvbkMRIL mylXCVOJEGnqGqWVYCnPgvbkMRIL = A_5[j] as MYlXCVOJEGnqGqWVYCnPgvbkMRIL;
					if (mylXCVOJEGnqGqWVYCnPgvbkMRIL != null && !(A_4.RoInVdEkWcIztboDcLpJMuMbhQIB != mylXCVOJEGnqGqWVYCnPgvbkMRIL.jvLgyhfwUUkKRMJtbBZuAOsivFLPB.RoInVdEkWcIztboDcLpJMuMbhQIB))
					{
						mylXCVOJEGnqGqWVYCnPgvbkMRIL.pAZBaxYZKMCHQFbUckcFpfOxajQU(A_3);
						return mylXCVOJEGnqGqWVYCnPgvbkMRIL;
					}
				}
			}
			result = new MYlXCVOJEGnqGqWVYCnPgvbkMRIL(A_3, A_1, A_2, A_4);
		}
		catch
		{
			result = null;
		}
		return result;
	}

	// Token: 0x060003EC RID: 1004 RVA: 0x0002D9E8 File Offset: 0x0002BBE8
	private zOVftvsFbTAvLzuhvSRGfBOXFlHHA lSxRQvgKDERKNIMtjZhVczGywlMP(FxRFkHqAoYVwWnmGeGdaqipeCVP A_1, IntPtr A_2)
	{
		if (this.gqfhhgwznGLRzmiNjYHEcqtjzOzq == null)
		{
			return null;
		}
		for (int i = 0; i < this.gqfhhgwznGLRzmiNjYHEcqtjzOzq.Count; i++)
		{
			zOVftvsFbTAvLzuhvSRGfBOXFlHHA zOVftvsFbTAvLzuhvSRGfBOXFlHHA = this.gqfhhgwznGLRzmiNjYHEcqtjzOzq[i];
			if (zOVftvsFbTAvLzuhvSRGfBOXFlHHA.MMyaVUZGjPiyMIfNDHckYSQSJitJ == A_1 && !(zOVftvsFbTAvLzuhvSRGfBOXFlHHA.aCbCjPbrDsLQiAeZMzgPciiOyrLMA != A_2))
			{
				return zOVftvsFbTAvLzuhvSRGfBOXFlHHA;
			}
		}
		return null;
	}

	// Token: 0x060003ED RID: 1005 RVA: 0x0002DA3C File Offset: 0x0002BC3C
	private unsafe zOVftvsFbTAvLzuhvSRGfBOXFlHHA XmvNyrNKWxMBMBGqRhbsXbilhmxt(IntPtr A_1)
	{
		uint num;
		wLURyKQfpGlmweDJGGSrwwzrDUJFA.cFLDnMKKkyQlORZdIZLYMZZWHgFP(A_1, 536870919U, IntPtr.Zero, out num);
		if (num <= 0U)
		{
			return null;
		}
		char* value = stackalloc char[checked(unchecked((UIntPtr)num) * 2)];
		wLURyKQfpGlmweDJGGSrwwzrDUJFA.cFLDnMKKkyQlORZdIZLYMZZWHgFP(A_1, 536870919U, new IntPtr((void*)value), out num);
		int length = (int)((num > 0U) ? (num - 1U) : 0U);
		string text = new string(value, 0, length);
		if (text.Length == 0)
		{
			text = string.Empty;
		}
		if (this.gqfhhgwznGLRzmiNjYHEcqtjzOzq == null)
		{
			return null;
		}
		text = AdSkHYvPxgeOVFEGslVOiHZEQBxjb.zntnSUJJitVdtJJQJKoubsHXrwF(text);
		for (int i = 0; i < this.gqfhhgwznGLRzmiNjYHEcqtjzOzq.Count; i++)
		{
			zOVftvsFbTAvLzuhvSRGfBOXFlHHA zOVftvsFbTAvLzuhvSRGfBOXFlHHA = this.gqfhhgwznGLRzmiNjYHEcqtjzOzq[i];
			if (zOVftvsFbTAvLzuhvSRGfBOXFlHHA.MMyaVUZGjPiyMIfNDHckYSQSJitJ == FxRFkHqAoYVwWnmGeGdaqipeCVP.RawInput && zOVftvsFbTAvLzuhvSRGfBOXFlHHA.jvLgyhfwUUkKRMJtbBZuAOsivFLPB.dnQHNEzctKOQigHseanNdTSZCLnB.Equals(text, StringComparison.OrdinalIgnoreCase))
			{
				zOVftvsFbTAvLzuhvSRGfBOXFlHHA.LJBWAWaztjArsZKcKUOCHWWsELaA(A_1);
				return zOVftvsFbTAvLzuhvSRGfBOXFlHHA;
			}
		}
		return null;
	}

	// Token: 0x060003EE RID: 1006 RVA: 0x0002DB04 File Offset: 0x0002BD04
	private static int RKJjHLutMpBsSEoPnOgBMVfsvVFR(zOVftvsFbTAvLzuhvSRGfBOXFlHHA A_0, zOVftvsFbTAvLzuhvSRGfBOXFlHHA A_1)
	{
		if (!A_0.jvLgyhfwUUkKRMJtbBZuAOsivFLPB.QzlfJYHQiKGPHlDdSYiClsfkXdLS)
		{
			return 1;
		}
		if (!A_1.jvLgyhfwUUkKRMJtbBZuAOsivFLPB.QzlfJYHQiKGPHlDdSYiClsfkXdLS)
		{
			return -1;
		}
		int num = A_0.jvLgyhfwUUkKRMJtbBZuAOsivFLPB.qcdWoDenISMIQEvQArHagxnrNzyd;
		int num2 = A_1.jvLgyhfwUUkKRMJtbBZuAOsivFLPB.qcdWoDenISMIQEvQArHagxnrNzyd;
		if (num < num2)
		{
			return -1;
		}
		if (num > num2)
		{
			return 1;
		}
		int num3 = A_0.jvLgyhfwUUkKRMJtbBZuAOsivFLPB.UGbxSSHetLbbZgjfzASKCkIosQbr;
		int num4 = A_1.jvLgyhfwUUkKRMJtbBZuAOsivFLPB.UGbxSSHetLbbZgjfzASKCkIosQbr;
		if (num3 < num4)
		{
			return -1;
		}
		if (num3 > num4)
		{
			return 1;
		}
		return 0;
	}

	// Token: 0x060003EF RID: 1007 RVA: 0x0002DB78 File Offset: 0x0002BD78
	private void GWNeFTzIYUgxSHRMxZdKyxeMfszJ()
	{
		wOInxLKDewlatLvQaXlNWuUFKXeD.UeFXSOrMPzTUSAtFbJdEOtQavMDm ueFXSOrMPzTUSAtFbJdEOtQavMDm = new wOInxLKDewlatLvQaXlNWuUFKXeD.UeFXSOrMPzTUSAtFbJdEOtQavMDm();
		ueFXSOrMPzTUSAtFbJdEOtQavMDm.EiFllmXwzUKIZljAudcetwPsdxJhA = this;
		if (this.sXwLeordAktmuwEAZaWPKekWhBskA != CcbBkDoBwnFtqUaGWyRJqFJSOkwI.SharpDX)
		{
			return;
		}
		ueFXSOrMPzTUSAtFbJdEOtQavMDm.QrZKQUAXOWzCFHsbeHvjlOVStiOm = false;
		this.xYBBDFKfLOeVJuZajDNdGwkrApKt(new Action(ueFXSOrMPzTUSAtFbJdEOtQavMDm.JorswbWZXbAKVlgvrMNakoFDpyyB), true);
		if (ueFXSOrMPzTUSAtFbJdEOtQavMDm.QrZKQUAXOWzCFHsbeHvjlOVStiOm)
		{
			Logger.LogError("Failed to register HID devices.", true);
		}
	}

	// Token: 0x060003F0 RID: 1008 RVA: 0x0002DBC8 File Offset: 0x0002BDC8
	private void wvlJQFccitmEHRGvdkgXHpCpUJuN()
	{
		wOInxLKDewlatLvQaXlNWuUFKXeD.bsWqUrOpNpeoBiXRSoNUFiRNMekUA bsWqUrOpNpeoBiXRSoNUFiRNMekUA = new wOInxLKDewlatLvQaXlNWuUFKXeD.bsWqUrOpNpeoBiXRSoNUFiRNMekUA();
		if (this.sXwLeordAktmuwEAZaWPKekWhBskA != CcbBkDoBwnFtqUaGWyRJqFJSOkwI.SharpDX)
		{
			return;
		}
		bsWqUrOpNpeoBiXRSoNUFiRNMekUA.YJaqqybBKpCdoxROVCvnvFDPdkMQ = false;
		this.xYBBDFKfLOeVJuZajDNdGwkrApKt(new Action(bsWqUrOpNpeoBiXRSoNUFiRNMekUA.WolTCprWaMPpcLLSvfFsBPYZMSIb), true);
		if (bsWqUrOpNpeoBiXRSoNUFiRNMekUA.YJaqqybBKpCdoxROVCvnvFDPdkMQ)
		{
			Logger.LogError("Failed to unregister HID devices.", true);
		}
	}

	// Token: 0x060003F1 RID: 1009 RVA: 0x0002DC14 File Offset: 0x0002BE14
	private void ctynvvFRQLeVEqdOyDIeeAmBmPnfb()
	{
		if (ReInput.isAllowedEditorWindowFocused)
		{
			if (this.sXwLeordAktmuwEAZaWPKekWhBskA == CcbBkDoBwnFtqUaGWyRJqFJSOkwI.SharpDX)
			{
				uint num;
				wOInxLKDewlatLvQaXlNWuUFKXeD.XmhFCkEZaMpEGnQzpGxVygBMFPrv(this.saIhGPItaSONUlGCfkQNgBnRmRjT, out num);
				if (this.pYWQLrMqbZxicddMdiGbfgukpRfg || this.PCIejCVVtKDeaxdrPCqsOfGdCdPJ)
				{
					IntPtr intPtr;
					bool flag = !this.OVEDnvdGgEAprjQBLrrZTZvmaaYbA(ControllerType.Mouse, this.saIhGPItaSONUlGCfkQNgBnRmRjT, num, out intPtr);
					if (!this.SbjYMHffAPfTytadhhMWQyuOMwIe || !flag)
					{
						if (intPtr == IntPtr.Zero)
						{
							intPtr = this.zBOqJQazNbeloaYjahKwZThqmDOA;
						}
						this.yTYXchWuLjltdEsUfdhkWnMhEtqH(intPtr);
					}
				}
				if (this.gnaYFbRKchKCDvUQaJovVlrHNiC || this.PCIejCVVtKDeaxdrPCqsOfGdCdPJ)
				{
					IntPtr hmQhEsdTnUVesFnmlbFzVWcbeZep;
					bool flag2 = !this.OVEDnvdGgEAprjQBLrrZTZvmaaYbA(ControllerType.Keyboard, this.saIhGPItaSONUlGCfkQNgBnRmRjT, num, out hmQhEsdTnUVesFnmlbFzVWcbeZep);
					if (!this.KajMnkePQOUoAmbeGTolQSoRBzLt || !flag2)
					{
						if (hmQhEsdTnUVesFnmlbFzVWcbeZep == IntPtr.Zero)
						{
							hmQhEsdTnUVesFnmlbFzVWcbeZep = this.HmQhEsdTnUVesFnmlbFzVWcbeZep;
						}
						this.WNVvOEGwDOtHgmMztpIVhtNlQHzy(hmQhEsdTnUVesFnmlbFzVWcbeZep);
						return;
					}
				}
			}
			else
			{
				if ((this.pYWQLrMqbZxicddMdiGbfgukpRfg || this.PCIejCVVtKDeaxdrPCqsOfGdCdPJ) && !this.SbjYMHffAPfTytadhhMWQyuOMwIe)
				{
					this.FQyPBtLBPGiJmVvyfnPtEftrFwvQ();
				}
				if ((this.gnaYFbRKchKCDvUQaJovVlrHNiC || this.PCIejCVVtKDeaxdrPCqsOfGdCdPJ) && !this.KajMnkePQOUoAmbeGTolQSoRBzLt)
				{
					this.lhGMHWnUNnTqcniXzyrohhsYgVEw();
					return;
				}
			}
		}
		else
		{
			if (this.SbjYMHffAPfTytadhhMWQyuOMwIe)
			{
				this.ApggMDwDYEMLnTFyzZFixKkzgKyd();
			}
			if (this.KajMnkePQOUoAmbeGTolQSoRBzLt)
			{
				this.xHkbwkeeNvwypaFLYfsUiMGyDSVi();
			}
		}
	}

	// Token: 0x060003F2 RID: 1010 RVA: 0x0002DD38 File Offset: 0x0002BF38
	private void ASrfimkxwwnrQSnCDVDoFORtpDxEb()
	{
		double realTime = ReInput.realTime;
		if (realTime < this.yJBAWPgaJyKZPpVRboxCYButwYAmA + 1.0)
		{
			return;
		}
		this.yJBAWPgaJyKZPpVRboxCYButwYAmA = realTime;
		if (this.sXwLeordAktmuwEAZaWPKekWhBskA == CcbBkDoBwnFtqUaGWyRJqFJSOkwI.SharpDX)
		{
			uint num;
			wOInxLKDewlatLvQaXlNWuUFKXeD.XmhFCkEZaMpEGnQzpGxVygBMFPrv(this.saIhGPItaSONUlGCfkQNgBnRmRjT, out num);
			if (this.pYWQLrMqbZxicddMdiGbfgukpRfg || this.PCIejCVVtKDeaxdrPCqsOfGdCdPJ)
			{
				IntPtr value;
				bool flag = !this.OVEDnvdGgEAprjQBLrrZTZvmaaYbA(ControllerType.Mouse, this.saIhGPItaSONUlGCfkQNgBnRmRjT, num, out value);
				if (!this.SbjYMHffAPfTytadhhMWQyuOMwIe || !flag)
				{
					if (value == IntPtr.Zero)
					{
						value = this.zBOqJQazNbeloaYjahKwZThqmDOA;
					}
					this.qtQHjiapOPQdMRtUDhmLgjjbHlME();
				}
			}
			if (this.gnaYFbRKchKCDvUQaJovVlrHNiC || this.PCIejCVVtKDeaxdrPCqsOfGdCdPJ)
			{
				IntPtr hmQhEsdTnUVesFnmlbFzVWcbeZep;
				bool flag2 = !this.OVEDnvdGgEAprjQBLrrZTZvmaaYbA(ControllerType.Keyboard, this.saIhGPItaSONUlGCfkQNgBnRmRjT, num, out hmQhEsdTnUVesFnmlbFzVWcbeZep);
				if (!this.KajMnkePQOUoAmbeGTolQSoRBzLt || !flag2)
				{
					if (hmQhEsdTnUVesFnmlbFzVWcbeZep == IntPtr.Zero)
					{
						hmQhEsdTnUVesFnmlbFzVWcbeZep = this.HmQhEsdTnUVesFnmlbFzVWcbeZep;
					}
					this.esteNMhuBSjTEMcyACbUFuDTCMGhA();
					return;
				}
			}
		}
		else
		{
			if ((this.pYWQLrMqbZxicddMdiGbfgukpRfg || this.PCIejCVVtKDeaxdrPCqsOfGdCdPJ) && !this.SbjYMHffAPfTytadhhMWQyuOMwIe)
			{
				this.FQyPBtLBPGiJmVvyfnPtEftrFwvQ();
			}
			if ((this.gnaYFbRKchKCDvUQaJovVlrHNiC || this.PCIejCVVtKDeaxdrPCqsOfGdCdPJ) && !this.KajMnkePQOUoAmbeGTolQSoRBzLt)
			{
				this.lhGMHWnUNnTqcniXzyrohhsYgVEw();
			}
		}
	}

	// Token: 0x060003F3 RID: 1011 RVA: 0x0002DE54 File Offset: 0x0002C054
	private void dCXRPMCsZaVmydJwTdzTJtmDIWbb()
	{
		if (this.sXwLeordAktmuwEAZaWPKekWhBskA == CcbBkDoBwnFtqUaGWyRJqFJSOkwI.SharpDX)
		{
			uint num;
			wOInxLKDewlatLvQaXlNWuUFKXeD.XmhFCkEZaMpEGnQzpGxVygBMFPrv(this.saIhGPItaSONUlGCfkQNgBnRmRjT, out num);
			IntPtr intPtr;
			if ((this.pYWQLrMqbZxicddMdiGbfgukpRfg || this.PCIejCVVtKDeaxdrPCqsOfGdCdPJ) && this.OVEDnvdGgEAprjQBLrrZTZvmaaYbA(ControllerType.Mouse, this.saIhGPItaSONUlGCfkQNgBnRmRjT, num, out intPtr))
			{
				if (this.SbjYMHffAPfTytadhhMWQyuOMwIe)
				{
					this.SbjYMHffAPfTytadhhMWQyuOMwIe = false;
					if (this.GUUroRNRLiezBPDFFGmhlWiSmoHL != null)
					{
						this.GUUroRNRLiezBPDFFGmhlWiSmoHL.BLoaPXEUJgxNGQROySNFGrnAEVakA(false);
					}
				}
				this.qtQHjiapOPQdMRtUDhmLgjjbHlME();
				return;
			}
		}
		else if ((this.pYWQLrMqbZxicddMdiGbfgukpRfg || this.PCIejCVVtKDeaxdrPCqsOfGdCdPJ) && !this.SbjYMHffAPfTytadhhMWQyuOMwIe)
		{
			this.FQyPBtLBPGiJmVvyfnPtEftrFwvQ();
		}
	}

	// Token: 0x060003F4 RID: 1012 RVA: 0x00013343 File Offset: 0x00011543
	private void ApggMDwDYEMLnTFyzZFixKkzgKyd()
	{
		if (this.sXwLeordAktmuwEAZaWPKekWhBskA == CcbBkDoBwnFtqUaGWyRJqFJSOkwI.SharpDX)
		{
			FDFnLHTuwYhpXLAmiYIcLCWeqTNb.MnTBisHipftEmSgrtGxOenWBMFRRA(false);
			this.QeLgTWgBBMWjiTzgERFRejOCXhoO();
		}
		this.SbjYMHffAPfTytadhhMWQyuOMwIe = false;
		if (this.GUUroRNRLiezBPDFFGmhlWiSmoHL != null)
		{
			this.GUUroRNRLiezBPDFFGmhlWiSmoHL.BLoaPXEUJgxNGQROySNFGrnAEVakA(false);
		}
	}

	// Token: 0x060003F5 RID: 1013 RVA: 0x0002DEE4 File Offset: 0x0002C0E4
	private void QeLgTWgBBMWjiTzgERFRejOCXhoO()
	{
		if ((!this.pYWQLrMqbZxicddMdiGbfgukpRfg && !this.PCIejCVVtKDeaxdrPCqsOfGdCdPJ) || this.sXwLeordAktmuwEAZaWPKekWhBskA != CcbBkDoBwnFtqUaGWyRJqFJSOkwI.SharpDX)
		{
			return;
		}
		IntPtr intPtr2;
		if (this.ffkYtjjRvaFSHxGxPhNbvdnuYpCJ)
		{
			uint num;
			wOInxLKDewlatLvQaXlNWuUFKXeD.XmhFCkEZaMpEGnQzpGxVygBMFPrv(this.saIhGPItaSONUlGCfkQNgBnRmRjT, out num);
			IntPtr intPtr;
			if (this.OVEDnvdGgEAprjQBLrrZTZvmaaYbA(ControllerType.Mouse, this.saIhGPItaSONUlGCfkQNgBnRmRjT, num, out intPtr))
			{
				this.zBOqJQazNbeloaYjahKwZThqmDOA = intPtr;
			}
			intPtr2 = this.zBOqJQazNbeloaYjahKwZThqmDOA;
		}
		else
		{
			intPtr2 = wLURyKQfpGlmweDJGGSrwwzrDUJFA.NcNUORJAUceCejbICLHRcPTLEkhIb();
		}
		if (intPtr2 != IntPtr.Zero)
		{
			bool flag = false;
			try
			{
				AfMbFsJstyiXPRpuLyuwQILIdQLv.COtgnZXAMsSruBpqkVLumczdHkty((kyyeJPAifzwsCJMsRzCRiCmfOgCIA)1, (RAVOkNOPomjLLELffRNedOUcwUii)2, qyhuAEUGhJrVUpIPbZkNEAPBOkzv.InputSink, intPtr2);
			}
			catch
			{
				flag = true;
			}
			if (flag)
			{
				Logger.LogError("Failed to unregister mouse.", true);
				return;
			}
		}
		else if (this.SbjYMHffAPfTytadhhMWQyuOMwIe)
		{
			wOInxLKDewlatLvQaXlNWuUFKXeD.UypFuchyaLnoJrEYUFKhcCxRCYoIA uypFuchyaLnoJrEYUFKhcCxRCYoIA = new wOInxLKDewlatLvQaXlNWuUFKXeD.UypFuchyaLnoJrEYUFKhcCxRCYoIA();
			uypFuchyaLnoJrEYUFKhcCxRCYoIA.VgCGKrcHcdIqmcirgKbQjRbceDerb = false;
			this.xYBBDFKfLOeVJuZajDNdGwkrApKt(new Action(uypFuchyaLnoJrEYUFKhcCxRCYoIA.brVafjaCSreWfKbBVndTqWgOuIqdA), true);
			if (uypFuchyaLnoJrEYUFKhcCxRCYoIA.VgCGKrcHcdIqmcirgKbQjRbceDerb)
			{
				Logger.LogError("Failed to unregister mouse.", true);
				return;
			}
		}
	}

	// Token: 0x060003F6 RID: 1014 RVA: 0x0002DFCC File Offset: 0x0002C1CC
	private void yTYXchWuLjltdEsUfdhkWnMhEtqH(IntPtr A_1)
	{
		if (this.sXwLeordAktmuwEAZaWPKekWhBskA != CcbBkDoBwnFtqUaGWyRJqFJSOkwI.SharpDX)
		{
			return;
		}
		this.FQyPBtLBPGiJmVvyfnPtEftrFwvQ();
		if (A_1 != IntPtr.Zero && A_1 != this.xKjavJEsSjoBQTjQpisUwQaMAIvTA.UradimpePZJbUJETzZGUOMPnDILu)
		{
			this.zBOqJQazNbeloaYjahKwZThqmDOA = A_1;
			FDFnLHTuwYhpXLAmiYIcLCWeqTNb.CwfkSIUCqkcPNIOjIODMeoPJEraub(this.zBOqJQazNbeloaYjahKwZThqmDOA, true);
		}
	}

	// Token: 0x060003F7 RID: 1015 RVA: 0x00013374 File Offset: 0x00011574
	private void qtQHjiapOPQdMRtUDhmLgjjbHlME()
	{
		if (this.sXwLeordAktmuwEAZaWPKekWhBskA != CcbBkDoBwnFtqUaGWyRJqFJSOkwI.SharpDX)
		{
			return;
		}
		this.FQyPBtLBPGiJmVvyfnPtEftrFwvQ();
		FDFnLHTuwYhpXLAmiYIcLCWeqTNb.CwfkSIUCqkcPNIOjIODMeoPJEraub(this.zQevmraCUemJycjcpjreIFXDknaG.value, true);
	}

	// Token: 0x060003F8 RID: 1016 RVA: 0x0002E01C File Offset: 0x0002C21C
	private void FQyPBtLBPGiJmVvyfnPtEftrFwvQ()
	{
		wOInxLKDewlatLvQaXlNWuUFKXeD.EHwyqjgrmlnEuMNAMvihbGbLeEZiA ehwyqjgrmlnEuMNAMvihbGbLeEZiA = new wOInxLKDewlatLvQaXlNWuUFKXeD.EHwyqjgrmlnEuMNAMvihbGbLeEZiA();
		ehwyqjgrmlnEuMNAMvihbGbLeEZiA.OJKyalRRVPhwvyKdUVBIZffblidq = this;
		if (this.sXwLeordAktmuwEAZaWPKekWhBskA == CcbBkDoBwnFtqUaGWyRJqFJSOkwI.SharpDX)
		{
			ehwyqjgrmlnEuMNAMvihbGbLeEZiA.ptmoqdqqyVUpstzhLHSolDGSgUmEA = false;
			this.xYBBDFKfLOeVJuZajDNdGwkrApKt(new Action(ehwyqjgrmlnEuMNAMvihbGbLeEZiA.NuAbMHKORMnOZxPNMJLKjUbbYToAA), true);
			if (ehwyqjgrmlnEuMNAMvihbGbLeEZiA.ptmoqdqqyVUpstzhLHSolDGSgUmEA)
			{
				Logger.LogError("Failed to register mouse.", true);
				this.SbjYMHffAPfTytadhhMWQyuOMwIe = false;
				if (this.GUUroRNRLiezBPDFFGmhlWiSmoHL != null)
				{
					this.GUUroRNRLiezBPDFFGmhlWiSmoHL.BLoaPXEUJgxNGQROySNFGrnAEVakA(false);
				}
				return;
			}
		}
		if (!this.SbjYMHffAPfTytadhhMWQyuOMwIe)
		{
			this.SbjYMHffAPfTytadhhMWQyuOMwIe = true;
			if (this.GUUroRNRLiezBPDFFGmhlWiSmoHL != null)
			{
				this.GUUroRNRLiezBPDFFGmhlWiSmoHL.BLoaPXEUJgxNGQROySNFGrnAEVakA(true);
			}
		}
	}

	// Token: 0x060003F9 RID: 1017 RVA: 0x0002E0AC File Offset: 0x0002C2AC
	public static bool XmhFCkEZaMpEGnQzpGxVygBMFPrv(zQCyBJwRZzSiLqPeefriktmkkwQOA A_0, out uint A_1)
	{
		A_1 = 0U;
		if (A_0 == null)
		{
			return false;
		}
		uint num = (uint)A_0.lKLtBAwDmxKjUPwTwgDpIvPufihR;
		A_1 = wLURyKQfpGlmweDJGGSrwwzrDUJFA.naueMUJQGLLkdkmFpqrreikaeTirb(A_0, ref num, (uint)A_0.rtOWidZEtGcYbeblDXMrDlaNyQvWA);
		return A_1 > 0U;
	}

	// Token: 0x060003FA RID: 1018 RVA: 0x0002E0E4 File Offset: 0x0002C2E4
	private unsafe bool OVEDnvdGgEAprjQBLrrZTZvmaaYbA(ControllerType A_1, zQCyBJwRZzSiLqPeefriktmkkwQOA A_2, uint A_3, out IntPtr A_4)
	{
		A_4 = IntPtr.Zero;
		if (A_2 == null)
		{
			return false;
		}
		int num = 0;
		while ((long)num < (long)((ulong)A_3))
		{
			FeQcrWBMxSGmDqIAgeblVHLmLAlL* ptr = (FeQcrWBMxSGmDqIAgeblVHLmLAlL*)((void*)A_2.GetPointer(num * A_2.rtOWidZEtGcYbeblDXMrDlaNyQvWA));
			if (A_1 != ControllerType.Keyboard)
			{
				if (A_1 == ControllerType.Mouse)
				{
					if (ptr->xJiXLxLfrBrQtnkpAbKOlIswvIuL == 1 && ptr->OoEKEZZUwVfnzYHhlWgkHNqzQduo == 2 && ptr->cFmreyZVMrQRHmoQFRInRqBOxhnl != IntPtr.Zero && ptr->cFmreyZVMrQRHmoQFRInRqBOxhnl != this.xKjavJEsSjoBQTjQpisUwQaMAIvTA.UradimpePZJbUJETzZGUOMPnDILu)
					{
						A_4 = ptr->cFmreyZVMrQRHmoQFRInRqBOxhnl;
						return true;
					}
				}
			}
			else if (ptr->xJiXLxLfrBrQtnkpAbKOlIswvIuL == 1 && ptr->OoEKEZZUwVfnzYHhlWgkHNqzQduo == 6 && ptr->cFmreyZVMrQRHmoQFRInRqBOxhnl != IntPtr.Zero && ptr->cFmreyZVMrQRHmoQFRInRqBOxhnl != this.xKjavJEsSjoBQTjQpisUwQaMAIvTA.UradimpePZJbUJETzZGUOMPnDILu)
			{
				A_4 = ptr->cFmreyZVMrQRHmoQFRInRqBOxhnl;
				return true;
			}
			num++;
		}
		return false;
	}

	// Token: 0x060003FB RID: 1019 RVA: 0x0002E1C4 File Offset: 0x0002C3C4
	private unsafe IntPtr JiYEGYiYewshNigxggVzGuAgMqMLA()
	{
		zQCyBJwRZzSiLqPeefriktmkkwQOA zQCyBJwRZzSiLqPeefriktmkkwQOA = null;
		IntPtr zero;
		try
		{
			zQCyBJwRZzSiLqPeefriktmkkwQOA = new zQCyBJwRZzSiLqPeefriktmkkwQOA(FeQcrWBMxSGmDqIAgeblVHLmLAlL.pdheLSuPWpxKDTNrqmdaHXHiPDYP, 100);
			uint num = (uint)zQCyBJwRZzSiLqPeefriktmkkwQOA.lKLtBAwDmxKjUPwTwgDpIvPufihR;
			uint num2 = wLURyKQfpGlmweDJGGSrwwzrDUJFA.naueMUJQGLLkdkmFpqrreikaeTirb(zQCyBJwRZzSiLqPeefriktmkkwQOA, ref num, (uint)zQCyBJwRZzSiLqPeefriktmkkwQOA.rtOWidZEtGcYbeblDXMrDlaNyQvWA);
			if (num2 == 0U)
			{
				zero = IntPtr.Zero;
			}
			else
			{
				int num3 = 0;
				while ((long)num3 < (long)((ulong)num2))
				{
					FeQcrWBMxSGmDqIAgeblVHLmLAlL* ptr = (FeQcrWBMxSGmDqIAgeblVHLmLAlL*)((void*)zQCyBJwRZzSiLqPeefriktmkkwQOA.GetPointer(num3 * zQCyBJwRZzSiLqPeefriktmkkwQOA.rtOWidZEtGcYbeblDXMrDlaNyQvWA));
					Logger.Log("RI DEVICE " + num3.ToString());
					Logger.Log("usage = " + ptr->OoEKEZZUwVfnzYHhlWgkHNqzQduo.ToString());
					Logger.Log("usagePage = " + ptr->xJiXLxLfrBrQtnkpAbKOlIswvIuL.ToString());
					Logger.Log("flags = " + ptr->ZAHPpvafudrEJLQjfWPuzbFoEGYEA.ToString());
					Logger.Log("target = " + ptr->cFmreyZVMrQRHmoQFRInRqBOxhnl.ToString());
					if (ptr->xJiXLxLfrBrQtnkpAbKOlIswvIuL == 1 && ptr->OoEKEZZUwVfnzYHhlWgkHNqzQduo == 2 && ptr->cFmreyZVMrQRHmoQFRInRqBOxhnl != IntPtr.Zero && ptr->cFmreyZVMrQRHmoQFRInRqBOxhnl != this.xKjavJEsSjoBQTjQpisUwQaMAIvTA.UradimpePZJbUJETzZGUOMPnDILu)
					{
						return ptr->cFmreyZVMrQRHmoQFRInRqBOxhnl;
					}
					num3++;
				}
				zero = IntPtr.Zero;
			}
		}
		catch
		{
			zero = IntPtr.Zero;
		}
		finally
		{
			if (zQCyBJwRZzSiLqPeefriktmkkwQOA != null)
			{
				zQCyBJwRZzSiLqPeefriktmkkwQOA.Dispose();
			}
		}
		return zero;
	}

	// Token: 0x060003FC RID: 1020 RVA: 0x00013396 File Offset: 0x00011596
	private void WNVvOEGwDOtHgmMztpIVhtNlQHzy(IntPtr A_1)
	{
		if (this.sXwLeordAktmuwEAZaWPKekWhBskA != CcbBkDoBwnFtqUaGWyRJqFJSOkwI.SharpDX)
		{
			return;
		}
		this.lhGMHWnUNnTqcniXzyrohhsYgVEw();
		if (A_1 != IntPtr.Zero && A_1 != this.xKjavJEsSjoBQTjQpisUwQaMAIvTA.UradimpePZJbUJETzZGUOMPnDILu)
		{
			this.HmQhEsdTnUVesFnmlbFzVWcbeZep = A_1;
		}
	}

	// Token: 0x060003FD RID: 1021 RVA: 0x000133CE File Offset: 0x000115CE
	private void esteNMhuBSjTEMcyACbUFuDTCMGhA()
	{
		if (this.sXwLeordAktmuwEAZaWPKekWhBskA != CcbBkDoBwnFtqUaGWyRJqFJSOkwI.SharpDX)
		{
			return;
		}
		this.lhGMHWnUNnTqcniXzyrohhsYgVEw();
	}

	// Token: 0x060003FE RID: 1022 RVA: 0x0002E354 File Offset: 0x0002C554
	private void lhGMHWnUNnTqcniXzyrohhsYgVEw()
	{
		wOInxLKDewlatLvQaXlNWuUFKXeD.luEWehzNmHBkrgeVOhwWBwsrfyShA luEWehzNmHBkrgeVOhwWBwsrfyShA = new wOInxLKDewlatLvQaXlNWuUFKXeD.luEWehzNmHBkrgeVOhwWBwsrfyShA();
		luEWehzNmHBkrgeVOhwWBwsrfyShA.YkLGVRGsqhqjqSapirKWUwqVvbzu = this;
		if (this.sXwLeordAktmuwEAZaWPKekWhBskA == CcbBkDoBwnFtqUaGWyRJqFJSOkwI.SharpDX)
		{
			luEWehzNmHBkrgeVOhwWBwsrfyShA.BBBcxeIWYVpAFlLwNnPnXcoOIGgGA = false;
			this.xYBBDFKfLOeVJuZajDNdGwkrApKt(new Action(luEWehzNmHBkrgeVOhwWBwsrfyShA.tnbtaldcuIEiPgrmdZKyQVfReQVBA), true);
			if (luEWehzNmHBkrgeVOhwWBwsrfyShA.BBBcxeIWYVpAFlLwNnPnXcoOIGgGA)
			{
				Logger.LogError("Failed to register keyboard.", true);
				this.KajMnkePQOUoAmbeGTolQSoRBzLt = false;
				if (this.gXVvryMkmbpClmcPKNxqhHppoQdo != null)
				{
					this.gXVvryMkmbpClmcPKNxqhHppoQdo.QdCFEOVUnZeTOgTKbqJAeLMFxSKi(false);
				}
				return;
			}
		}
		if (!this.KajMnkePQOUoAmbeGTolQSoRBzLt)
		{
			this.KajMnkePQOUoAmbeGTolQSoRBzLt = true;
			if (this.gXVvryMkmbpClmcPKNxqhHppoQdo != null)
			{
				this.gXVvryMkmbpClmcPKNxqhHppoQdo.QdCFEOVUnZeTOgTKbqJAeLMFxSKi(true);
			}
		}
	}

	// Token: 0x060003FF RID: 1023 RVA: 0x000133DF File Offset: 0x000115DF
	private void xHkbwkeeNvwypaFLYfsUiMGyDSVi()
	{
		if (this.sXwLeordAktmuwEAZaWPKekWhBskA == CcbBkDoBwnFtqUaGWyRJqFJSOkwI.SharpDX)
		{
			this.VEgFpUqmMPzbAuyepZGnQgIGQMiB();
		}
		this.KajMnkePQOUoAmbeGTolQSoRBzLt = false;
		if (this.gXVvryMkmbpClmcPKNxqhHppoQdo != null)
		{
			this.gXVvryMkmbpClmcPKNxqhHppoQdo.QdCFEOVUnZeTOgTKbqJAeLMFxSKi(false);
		}
	}

	// Token: 0x06000400 RID: 1024 RVA: 0x0002E3E4 File Offset: 0x0002C5E4
	private void VEgFpUqmMPzbAuyepZGnQgIGQMiB()
	{
		if ((!this.gnaYFbRKchKCDvUQaJovVlrHNiC && !this.PCIejCVVtKDeaxdrPCqsOfGdCdPJ) || this.sXwLeordAktmuwEAZaWPKekWhBskA != CcbBkDoBwnFtqUaGWyRJqFJSOkwI.SharpDX)
		{
			return;
		}
		IntPtr intPtr;
		if (this.ffkYtjjRvaFSHxGxPhNbvdnuYpCJ)
		{
			uint num;
			wOInxLKDewlatLvQaXlNWuUFKXeD.XmhFCkEZaMpEGnQzpGxVygBMFPrv(this.saIhGPItaSONUlGCfkQNgBnRmRjT, out num);
			IntPtr hmQhEsdTnUVesFnmlbFzVWcbeZep;
			if (this.OVEDnvdGgEAprjQBLrrZTZvmaaYbA(ControllerType.Keyboard, this.saIhGPItaSONUlGCfkQNgBnRmRjT, num, out hmQhEsdTnUVesFnmlbFzVWcbeZep))
			{
				this.HmQhEsdTnUVesFnmlbFzVWcbeZep = hmQhEsdTnUVesFnmlbFzVWcbeZep;
			}
			intPtr = this.HmQhEsdTnUVesFnmlbFzVWcbeZep;
		}
		else
		{
			intPtr = wLURyKQfpGlmweDJGGSrwwzrDUJFA.NcNUORJAUceCejbICLHRcPTLEkhIb();
		}
		if (intPtr != IntPtr.Zero)
		{
			bool flag = false;
			try
			{
				AfMbFsJstyiXPRpuLyuwQILIdQLv.COtgnZXAMsSruBpqkVLumczdHkty((kyyeJPAifzwsCJMsRzCRiCmfOgCIA)1, (RAVOkNOPomjLLELffRNedOUcwUii)6, qyhuAEUGhJrVUpIPbZkNEAPBOkzv.InputSink, intPtr);
			}
			catch
			{
				flag = true;
			}
			if (flag)
			{
				Logger.LogError("Failed to unregister keyboard.", true);
				return;
			}
		}
		else if (this.KajMnkePQOUoAmbeGTolQSoRBzLt)
		{
			wOInxLKDewlatLvQaXlNWuUFKXeD.lXUkMbTKnnPDGZTLfvxByZUKoBMQ lXUkMbTKnnPDGZTLfvxByZUKoBMQ = new wOInxLKDewlatLvQaXlNWuUFKXeD.lXUkMbTKnnPDGZTLfvxByZUKoBMQ();
			lXUkMbTKnnPDGZTLfvxByZUKoBMQ.wwCfSwAwYxuNzIEPIbVrquDrXeVd = false;
			this.xYBBDFKfLOeVJuZajDNdGwkrApKt(new Action(lXUkMbTKnnPDGZTLfvxByZUKoBMQ.xyeyfPIuzoqpKPGYecglmLrXykmo), true);
			if (lXUkMbTKnnPDGZTLfvxByZUKoBMQ.wwCfSwAwYxuNzIEPIbVrquDrXeVd)
			{
				Logger.LogError("Failed to unregister keyboard.", true);
				return;
			}
		}
	}

	// Token: 0x06000401 RID: 1025 RVA: 0x0002E4CC File Offset: 0x0002C6CC
	private void OzKJLZKoDrxivzQpZlqGRzWDtFKy()
	{
		if (this.sXwLeordAktmuwEAZaWPKekWhBskA == CcbBkDoBwnFtqUaGWyRJqFJSOkwI.SharpDX)
		{
			if (this.pYWQLrMqbZxicddMdiGbfgukpRfg || this.PCIejCVVtKDeaxdrPCqsOfGdCdPJ)
			{
				this.ApggMDwDYEMLnTFyzZFixKkzgKyd();
			}
			this.wvlJQFccitmEHRGvdkgXHpCpUJuN();
			if (this.gnaYFbRKchKCDvUQaJovVlrHNiC || this.PCIejCVVtKDeaxdrPCqsOfGdCdPJ)
			{
				this.xHkbwkeeNvwypaFLYfsUiMGyDSVi();
				return;
			}
		}
		else if (this.pYWQLrMqbZxicddMdiGbfgukpRfg || this.PCIejCVVtKDeaxdrPCqsOfGdCdPJ)
		{
			this.ApggMDwDYEMLnTFyzZFixKkzgKyd();
		}
	}

	// Token: 0x06000402 RID: 1026 RVA: 0x0002E52C File Offset: 0x0002C72C
	private void zKxeoHiSWZCQqeeGLSrNABennkpkA()
	{
		if (this.avlBzQVOOmctrTpmEXHsrvYWsNTI)
		{
			AfMbFsJstyiXPRpuLyuwQILIdQLv.kksMZTKGSvgMcAEimjJgMmSGmanx += this.PUpLmFBmSisBqNMjSfnzUWseSiei;
		}
		if (this.pYWQLrMqbZxicddMdiGbfgukpRfg)
		{
			AfMbFsJstyiXPRpuLyuwQILIdQLv.yGPwXLwgWpzejrfbWCmqDHgXWfOU += this.IfLmUbyNrVcakagyneYiEpxdARAeA;
		}
		if (this.gnaYFbRKchKCDvUQaJovVlrHNiC)
		{
			AfMbFsJstyiXPRpuLyuwQILIdQLv.sRGpSqbRYwsOyXEcfDErhHtyHAo += this.ylKYPLQwmOYVCXdNKWZYAIhJBNwi;
		}
		if (this.avlBzQVOOmctrTpmEXHsrvYWsNTI || this.pYWQLrMqbZxicddMdiGbfgukpRfg || this.gnaYFbRKchKCDvUQaJovVlrHNiC)
		{
			AfMbFsJstyiXPRpuLyuwQILIdQLv.kqYlqNwRoFirpnyXNQtaIUkWQMag += this.MCpJKBsgejwUdsQWhNuPhPmiXBKt;
			AfMbFsJstyiXPRpuLyuwQILIdQLv.vooTAkAYcOTlzAKuMUhapegAAZZr += this.ZoCvLPUEcfMmemmzPQESzLNKXKbp;
		}
	}

	// Token: 0x06000403 RID: 1027 RVA: 0x0002E5C0 File Offset: 0x0002C7C0
	private void YWlqUclDjADQMAUllzKSBDxzEemxA()
	{
		if (this.avlBzQVOOmctrTpmEXHsrvYWsNTI)
		{
			AfMbFsJstyiXPRpuLyuwQILIdQLv.kksMZTKGSvgMcAEimjJgMmSGmanx -= this.PUpLmFBmSisBqNMjSfnzUWseSiei;
		}
		if (this.pYWQLrMqbZxicddMdiGbfgukpRfg)
		{
			AfMbFsJstyiXPRpuLyuwQILIdQLv.yGPwXLwgWpzejrfbWCmqDHgXWfOU -= this.IfLmUbyNrVcakagyneYiEpxdARAeA;
		}
		if (this.gnaYFbRKchKCDvUQaJovVlrHNiC)
		{
			AfMbFsJstyiXPRpuLyuwQILIdQLv.sRGpSqbRYwsOyXEcfDErhHtyHAo -= this.ylKYPLQwmOYVCXdNKWZYAIhJBNwi;
		}
		if (this.avlBzQVOOmctrTpmEXHsrvYWsNTI || this.pYWQLrMqbZxicddMdiGbfgukpRfg || this.gnaYFbRKchKCDvUQaJovVlrHNiC)
		{
			AfMbFsJstyiXPRpuLyuwQILIdQLv.kqYlqNwRoFirpnyXNQtaIUkWQMag -= this.MCpJKBsgejwUdsQWhNuPhPmiXBKt;
			AfMbFsJstyiXPRpuLyuwQILIdQLv.vooTAkAYcOTlzAKuMUhapegAAZZr -= this.ZoCvLPUEcfMmemmzPQESzLNKXKbp;
		}
	}

	// Token: 0x06000404 RID: 1028 RVA: 0x0002E654 File Offset: 0x0002C854
	private void QTPLVfRjQeuZVZHiubNkfoLfCGsM(DLJMGaTLIFFDahvupJkOZBRJLNrj.osqZvvGFouEfTOmJrimLXBVCYjbl A_1)
	{
		wOInxLKDewlatLvQaXlNWuUFKXeD.RfvjfdukMLYDhodmgflMZyATabED rfvjfdukMLYDhodmgflMZyATabED = new wOInxLKDewlatLvQaXlNWuUFKXeD.RfvjfdukMLYDhodmgflMZyATabED();
		rfvjfdukMLYDhodmgflMZyATabED.MMlANBcxZSqYTjBHcQJyTjkoTeeEA = this;
		rfvjfdukMLYDhodmgflMZyATabED.IQjwdqDyLmruKyAcLMLfOreoxHgf = A_1;
		rfvjfdukMLYDhodmgflMZyATabED.uhXPOhvKmKtCBcvdaOQuEfmeRDqx = false;
		this.xYBBDFKfLOeVJuZajDNdGwkrApKt(new Action(rfvjfdukMLYDhodmgflMZyATabED.dUFkWXXxQUtmUOisFkRcuGYNfnbh), true);
		if (rfvjfdukMLYDhodmgflMZyATabED.uhXPOhvKmKtCBcvdaOQuEfmeRDqx)
		{
			throw new Exception("Error creating message window.");
		}
	}

	// Token: 0x06000405 RID: 1029 RVA: 0x0002E6A4 File Offset: 0x0002C8A4
	private static DLJMGaTLIFFDahvupJkOZBRJLNrj BrCENPOyxZlUaWpwhdZNeCDpurVTA(DLJMGaTLIFFDahvupJkOZBRJLNrj.osqZvvGFouEfTOmJrimLXBVCYjbl A_0)
	{
		DLJMGaTLIFFDahvupJkOZBRJLNrj dljmgaTLIFFDahvupJkOZBRJLNrj = new DLJMGaTLIFFDahvupJkOZBRJLNrj("RewiredMesssageWindow", true, A_0);
		if (dljmgaTLIFFDahvupJkOZBRJLNrj.UradimpePZJbUJETzZGUOMPnDILu == IntPtr.Zero)
		{
			dljmgaTLIFFDahvupJkOZBRJLNrj.Dispose();
			return null;
		}
		return dljmgaTLIFFDahvupJkOZBRJLNrj;
	}

	// Token: 0x06000406 RID: 1030 RVA: 0x0002E6DC File Offset: 0x0002C8DC
	private void hBOUKbdAqKjDYzNDKcYwPLLnPvCX()
	{
		if (this.sXwLeordAktmuwEAZaWPKekWhBskA != CcbBkDoBwnFtqUaGWyRJqFJSOkwI.SharpDX)
		{
			return;
		}
		FDFnLHTuwYhpXLAmiYIcLCWeqTNb.WQAwfQbJFIBjklRZjBxoiSDgBAdf();
		FDFnLHTuwYhpXLAmiYIcLCWeqTNb.IztvxWtjuasfpmSHHAQjrEPKcEap(new OiCANJEXJaMDWwirIYRUPVFMahRD(UnityTools.externalTools.WindowsStandalone_ForwardRawInput));
		if (this.avlBzQVOOmctrTpmEXHsrvYWsNTI || this.PCIejCVVtKDeaxdrPCqsOfGdCdPJ)
		{
			this.GWNeFTzIYUgxSHRMxZdKyxeMfszJ();
		}
		if (this.pYWQLrMqbZxicddMdiGbfgukpRfg || this.gnaYFbRKchKCDvUQaJovVlrHNiC || this.PCIejCVVtKDeaxdrPCqsOfGdCdPJ)
		{
			this.saIhGPItaSONUlGCfkQNgBnRmRjT = new zQCyBJwRZzSiLqPeefriktmkkwQOA(FeQcrWBMxSGmDqIAgeblVHLmLAlL.pdheLSuPWpxKDTNrqmdaHXHiPDYP, 100);
			if (this.ffkYtjjRvaFSHxGxPhNbvdnuYpCJ)
			{
				this.NfGpJIgYzUOTDvYCQeGrBiBwcHdQ = 1;
			}
			else
			{
				if (this.pYWQLrMqbZxicddMdiGbfgukpRfg || this.PCIejCVVtKDeaxdrPCqsOfGdCdPJ)
				{
					this.qtQHjiapOPQdMRtUDhmLgjjbHlME();
				}
				if (this.gnaYFbRKchKCDvUQaJovVlrHNiC || this.PCIejCVVtKDeaxdrPCqsOfGdCdPJ)
				{
					this.esteNMhuBSjTEMcyACbUFuDTCMGhA();
				}
			}
		}
		this.MJzUEMMCEwaVyNiIgfiGOVxEhqiT = FDFnLHTuwYhpXLAmiYIcLCWeqTNb.SeRPgGtYCYsqzNYGNqmzpfuBdXZo();
	}

	// Token: 0x06000407 RID: 1031 RVA: 0x0002E798 File Offset: 0x0002C998
	private void oCLSopbrRVspKTLhSAdKBZRcWtLZ()
	{
		if (!this.ffkYtjjRvaFSHxGxPhNbvdnuYpCJ)
		{
			return;
		}
		if (this.sXwLeordAktmuwEAZaWPKekWhBskA != CcbBkDoBwnFtqUaGWyRJqFJSOkwI.SharpDX)
		{
			return;
		}
		if (this.NfGpJIgYzUOTDvYCQeGrBiBwcHdQ > 0)
		{
			this.NfGpJIgYzUOTDvYCQeGrBiBwcHdQ--;
			return;
		}
		uint num;
		wOInxLKDewlatLvQaXlNWuUFKXeD.XmhFCkEZaMpEGnQzpGxVygBMFPrv(this.saIhGPItaSONUlGCfkQNgBnRmRjT, out num);
		if (this.pYWQLrMqbZxicddMdiGbfgukpRfg || this.PCIejCVVtKDeaxdrPCqsOfGdCdPJ)
		{
			IntPtr intPtr;
			this.OVEDnvdGgEAprjQBLrrZTZvmaaYbA(ControllerType.Mouse, this.saIhGPItaSONUlGCfkQNgBnRmRjT, num, out intPtr);
			this.yTYXchWuLjltdEsUfdhkWnMhEtqH(intPtr);
		}
		if (this.gnaYFbRKchKCDvUQaJovVlrHNiC || this.PCIejCVVtKDeaxdrPCqsOfGdCdPJ)
		{
			IntPtr intPtr2;
			this.OVEDnvdGgEAprjQBLrrZTZvmaaYbA(ControllerType.Keyboard, this.saIhGPItaSONUlGCfkQNgBnRmRjT, num, out intPtr2);
			this.WNVvOEGwDOtHgmMztpIVhtNlQHzy(intPtr2);
		}
		this.NfGpJIgYzUOTDvYCQeGrBiBwcHdQ = -1;
	}

	// Token: 0x06000408 RID: 1032 RVA: 0x0001340A File Offset: 0x0001160A
	private void zJZUHbBxjuROzVpzAWHLPCgOjoyg(bool A_1)
	{
		if (this.pYWQLrMqbZxicddMdiGbfgukpRfg || this.PCIejCVVtKDeaxdrPCqsOfGdCdPJ)
		{
			this.qtQHjiapOPQdMRtUDhmLgjjbHlME();
		}
		if (this.gnaYFbRKchKCDvUQaJovVlrHNiC || this.PCIejCVVtKDeaxdrPCqsOfGdCdPJ)
		{
			this.lhGMHWnUNnTqcniXzyrohhsYgVEw();
		}
	}

	// Token: 0x06000409 RID: 1033 RVA: 0x00013438 File Offset: 0x00011638
	private void nPIbQjWYyOhWKSHjYYaVanveGEFm(bool A_1)
	{
		this.ioeTMnkQysQdidRcVfjtHDyRnpKL = A_1;
	}

	// Token: 0x0600040A RID: 1034 RVA: 0x00013441 File Offset: 0x00011641
	private void gZTSwCAprClchmAABjyqHkWkJxeN(bool A_1)
	{
		this.ohhHLLilFLEnbfpQCbKOiiAJQDUkB = A_1;
	}

	// Token: 0x0600040B RID: 1035 RVA: 0x0001344A File Offset: 0x0001164A
	private void hFZFxMgudEokhbnUqWPCfHbTSARab(FullScreenMode A_1)
	{
		if (this.pYWQLrMqbZxicddMdiGbfgukpRfg || this.PCIejCVVtKDeaxdrPCqsOfGdCdPJ)
		{
			this.dCXRPMCsZaVmydJwTdzTJtmDIWbb();
		}
	}

	// Token: 0x0600040C RID: 1036 RVA: 0x00013462 File Offset: 0x00011662
	private void NrSErvZUQSfRdrtTNYarPEmQFevc(IntPtr A_1)
	{
		if (!this.ffkYtjjRvaFSHxGxPhNbvdnuYpCJ)
		{
			if (this.pYWQLrMqbZxicddMdiGbfgukpRfg || this.PCIejCVVtKDeaxdrPCqsOfGdCdPJ)
			{
				this.qtQHjiapOPQdMRtUDhmLgjjbHlME();
			}
			if (this.gnaYFbRKchKCDvUQaJovVlrHNiC || this.PCIejCVVtKDeaxdrPCqsOfGdCdPJ)
			{
				this.esteNMhuBSjTEMcyACbUFuDTCMGhA();
			}
		}
	}

	// Token: 0x0600040D RID: 1037 RVA: 0x00013498 File Offset: 0x00011698
	private IntPtr bQigHQrORtDcMJSZhfGOfqWnuCzBA(IntPtr A_1, uint A_2, IntPtr A_3, IntPtr A_4)
	{
		if (this.yUNqFolpiwMgMNMzdtVDlLlMgvVDA)
		{
			return IntPtr.Zero;
		}
		if (this.MJzUEMMCEwaVyNiIgfiGOVxEhqiT != null)
		{
			this.MJzUEMMCEwaVyNiIgfiGOVxEhqiT(A_1, A_2, A_3, A_4);
		}
		return IntPtr.Zero;
	}

	// Token: 0x0600040E RID: 1038 RVA: 0x000134C6 File Offset: 0x000116C6
	private void xYBBDFKfLOeVJuZajDNdGwkrApKt(Action A_1, bool A_2)
	{
		if (A_1 == null)
		{
			return;
		}
		A_1();
	}

	// Token: 0x0600040F RID: 1039 RVA: 0x0002E834 File Offset: 0x0002CA34
	private void PUpLmFBmSisBqNMjSfnzUWseSiei(vamjbSUoUdgRrEqRGQPJnVdfuFYE A_1, double A_2)
	{
		try
		{
			zOVftvsFbTAvLzuhvSRGfBOXFlHHA zOVftvsFbTAvLzuhvSRGfBOXFlHHA = this.lSxRQvgKDERKNIMtjZhVczGywlMP(FxRFkHqAoYVwWnmGeGdaqipeCVP.RawInput, A_1.WEWknRaeijaJJeuhUBexkhWQTzEJ);
			if (zOVftvsFbTAvLzuhvSRGfBOXFlHHA != null)
			{
				zOVftvsFbTAvLzuhvSRGfBOXFlHHA.SsmImBPnIEUNNgpaNEZVPQORNZxt(A_1.VKGPYjQvFSgixebXspbhjgmWxMZN, A_1.elejcnSCVfQebqripkIfupPGNZCe, A_1.QULTazTtGyiySPiuTDxmjaEnkmyc, A_1.RZfXjfrZFGqXntfIAbEysabgIGGl, A_2);
			}
		}
		catch
		{
		}
	}

	// Token: 0x06000410 RID: 1040 RVA: 0x000134D2 File Offset: 0x000116D2
	private void IfLmUbyNrVcakagyneYiEpxdARAeA(BsOCzKzGOtfXOMILYcMavzphNaEW A_1, double A_2)
	{
		this.lFTWqZcHUFKDTcMbEohjznkOkUHW.CugiVaDSGzNVQofuEFQffDkpLSvV(ref A_1);
		this.dDeHNeMocCecoqMoFQoDftxuYENd(this.lFTWqZcHUFKDTcMbEohjznkOkUHW, A_2);
	}

	// Token: 0x06000411 RID: 1041 RVA: 0x0002E88C File Offset: 0x0002CA8C
	private void dDeHNeMocCecoqMoFQoDftxuYENd(bbYYonPTzAJNYZIOnIOVBePssTCgA A_1, double A_2)
	{
		try
		{
			this.GUUroRNRLiezBPDFFGmhlWiSmoHL.dbMAJtHMZhSYLdfMIlItxNFqwHRA(A_1);
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000412 RID: 1042 RVA: 0x000134EE File Offset: 0x000116EE
	private void ylKYPLQwmOYVCXdNKWZYAIhJBNwi(exoiJSVGtadWpfMWSBsEnnAfLIbo A_1, double A_2)
	{
		this.lOOlqLqrNKcwMaWstPctAADCMjhE.JFNpsCKcYwFsXXQZxtBRDHRxeMNN(ref A_1);
		this.qdFAtRkKvlHnpdzIrmhjggiksLSUA(this.lOOlqLqrNKcwMaWstPctAADCMjhE, A_2);
	}

	// Token: 0x06000413 RID: 1043 RVA: 0x0002E8BC File Offset: 0x0002CABC
	private void qdFAtRkKvlHnpdzIrmhjggiksLSUA(WwSVhacABKVkeCFnEObUUluxAROM A_1, double A_2)
	{
		try
		{
			this.gXVvryMkmbpClmcPKNxqhHppoQdo.RxZbxiYcwtjCLdNAyhOzidqGejlS(A_1);
		}
		catch
		{
		}
	}

	// Token: 0x06000414 RID: 1044 RVA: 0x0001350A File Offset: 0x0001170A
	private void MCpJKBsgejwUdsQWhNuPhPmiXBKt(IntPtr A_1)
	{
		this.tTRWCjudTHdLbEXcLAgpFxERwIWaA = true;
	}

	// Token: 0x06000415 RID: 1045 RVA: 0x0001350A File Offset: 0x0001170A
	private void ZoCvLPUEcfMmemmzPQESzLNKXKbp()
	{
		this.tTRWCjudTHdLbEXcLAgpFxERwIWaA = true;
	}

	// Token: 0x06000416 RID: 1046 RVA: 0x00013513 File Offset: 0x00011713
	public void Dispose()
	{
		this.PCBNRlzpvQaQaDmEgMnnYQheqzxU(true);
		GC.SuppressFinalize(this);
	}

	// Token: 0x06000417 RID: 1047 RVA: 0x0002E8EC File Offset: 0x0002CAEC
	protected virtual void EswyKZlhQjMGWnSRISTapnMutnpF()
	{
		try
		{
			this.PCBNRlzpvQaQaDmEgMnnYQheqzxU(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	// Token: 0x06000418 RID: 1048 RVA: 0x0002E91C File Offset: 0x0002CB1C
	protected virtual void PCBNRlzpvQaQaDmEgMnnYQheqzxU(bool A_1)
	{
		if (this.yUNqFolpiwMgMNMzdtVDlLlMgvVDA)
		{
			return;
		}
		this.YWlqUclDjADQMAUllzKSBDxzEemxA();
		AfMbFsJstyiXPRpuLyuwQILIdQLv.bnwEGZdnbSJOmzPPdZHiKJKOAqqN = null;
		ReInput.ApplicationIsFullScreenChangedEvent -= this.zJZUHbBxjuROzVpzAWHLPCgOjoyg;
		ReInput.ApplicationFullScreenModeChangedEvent -= this.hFZFxMgudEokhbnUqWPCfHbTSARab;
		ReInput.ApplicationFocusChangedEvent -= this.nPIbQjWYyOhWKSHjYYaVanveGEFm;
		ReInput.ApplicationPauseChangedEvent -= this.gZTSwCAprClchmAABjyqHkWkJxeN;
		object obj = this.fvWSismAsaUXmyHxiJukkIQtireq;
		lock (obj)
		{
			if (A_1 && this.gqfhhgwznGLRzmiNjYHEcqtjzOzq != null)
			{
				for (int i = 0; i < this.gqfhhgwznGLRzmiNjYHEcqtjzOzq.Count; i++)
				{
					if (this.gqfhhgwznGLRzmiNjYHEcqtjzOzq[i] != null)
					{
						this.gqfhhgwznGLRzmiNjYHEcqtjzOzq[i].aLGLCNQlAGFbzfFShLCURNjpXQRLA();
						this.gqfhhgwznGLRzmiNjYHEcqtjzOzq[i].Dispose();
					}
				}
			}
			this.OzKJLZKoDrxivzQpZlqGRzWDtFKy();
			if (this.xKjavJEsSjoBQTjQpisUwQaMAIvTA != null)
			{
				this.xKjavJEsSjoBQTjQpisUwQaMAIvTA.Dispose();
				this.xKjavJEsSjoBQTjQpisUwQaMAIvTA = null;
			}
			if (this.pYWQLrMqbZxicddMdiGbfgukpRfg && this.GUUroRNRLiezBPDFFGmhlWiSmoHL != null)
			{
				this.GUUroRNRLiezBPDFFGmhlWiSmoHL.Dispose();
			}
			if (this.gnaYFbRKchKCDvUQaJovVlrHNiC && this.gXVvryMkmbpClmcPKNxqhHppoQdo != null)
			{
				this.gXVvryMkmbpClmcPKNxqhHppoQdo.Dispose();
			}
			FDFnLHTuwYhpXLAmiYIcLCWeqTNb.urtbwOSJPdLAkbBORqKSyFIoqHBB();
		}
		if (this.saIhGPItaSONUlGCfkQNgBnRmRjT != null)
		{
			this.saIhGPItaSONUlGCfkQNgBnRmRjT.Dispose();
		}
		this.yUNqFolpiwMgMNMzdtVDlLlMgvVDA = true;
	}

	// Token: 0x06000419 RID: 1049 RVA: 0x0002EA78 File Offset: 0x0002CC78
	public unsafe static bool HWGuuLNggmCSsIIYWoKyBLiGGoXc(OiWGlufNbZAVpTSvEHgxGrekNlFFA A_0, out int A_1)
	{
		A_1 = 0;
		uint num = 0U;
		wLURyKQfpGlmweDJGGSrwwzrDUJFA.iKNaxaBdfLYvtPGDOQyGkilmkqXeb(IntPtr.Zero, ref num, (uint)Marshal.SizeOf(typeof(IHjknSfzmxAOaKWaYMMNiIArARUq)));
		if (num == 0U)
		{
			return false;
		}
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		IHjknSfzmxAOaKWaYMMNiIArARUq* ptr = stackalloc IHjknSfzmxAOaKWaYMMNiIArARUq[checked(unchecked((UIntPtr)num) * (UIntPtr)sizeof(IHjknSfzmxAOaKWaYMMNiIArARUq))];
		wLURyKQfpGlmweDJGGSrwwzrDUJFA.iKNaxaBdfLYvtPGDOQyGkilmkqXeb((IntPtr)((void*)ptr), ref num, (uint)Marshal.SizeOf(typeof(IHjknSfzmxAOaKWaYMMNiIArARUq)));
		int num5 = 0;
		while ((long)num5 < (long)((ulong)num))
		{
			IntPtr kyELRZSqJtAwlJSvxcOtqtNfOMgi = ptr[num5].KyELRZSqJtAwlJSvxcOtqtNfOMgi;
			int num6 = 0;
			xSOZMZyIgwUNJGxbaunJqIAqJnsT.hryjfLFxJeJzKEAFyOlEwkIqFCBo(kyELRZSqJtAwlJSvxcOtqtNfOMgi, uYyVWuBOXcvoXobWFzSAukvLDpji.DeviceInfo, IntPtr.Zero, ref num6);
			if (num6 == 0)
			{
				num4++;
			}
			else
			{
				num3++;
				byte* ptr2 = stackalloc byte[(UIntPtr)num6];
				*(int*)ptr2 = num6;
				if (xSOZMZyIgwUNJGxbaunJqIAqJnsT.hryjfLFxJeJzKEAFyOlEwkIqFCBo(kyELRZSqJtAwlJSvxcOtqtNfOMgi, uYyVWuBOXcvoXobWFzSAukvLDpji.DeviceInfo, (IntPtr)((void*)ptr2), ref num6) >= 0 && ((yYIItTkYxskbKoqMJlNZSvZnYSID*)ptr2)->yZGCAdpDvZcrslhApGgDBSsGYjLBA == A_0)
				{
					num2++;
				}
			}
			num5++;
		}
		if (num4 > 0 && num3 == 0)
		{
			return false;
		}
		A_1 = num2;
		return true;
	}

	// Token: 0x0600041B RID: 1051 RVA: 0x00013558 File Offset: 0x00011758
	[CompilerGenerated]
	private bool ybsAXrohdsnQdFllfMdQzwdFhCOh()
	{
		return !this.ioeTMnkQysQdidRcVfjtHDyRnpKL || this.ohhHLLilFLEnbfpQCbKOiiAJQDUkB;
	}

	// Token: 0x04000558 RID: 1368
	private const float dcEfdVdIhqkEipKVTAvMFbqklXznB = 0.25f;

	// Token: 0x04000559 RID: 1369
	private const float UWXcJIhvDZOcscYSacwuLzynextOB = 1f;

	// Token: 0x0400055A RID: 1370
	private List<zOVftvsFbTAvLzuhvSRGfBOXFlHHA> gqfhhgwznGLRzmiNjYHEcqtjzOzq;

	// Token: 0x0400055B RID: 1371
	private List<zOVftvsFbTAvLzuhvSRGfBOXFlHHA> FaqJQXJrsuIJDbMoyKdjTzteSzcC;

	// Token: 0x0400055C RID: 1372
	private ReadOnlyCollection<zOVftvsFbTAvLzuhvSRGfBOXFlHHA> cDqDYMrVKRcMophnxGzUFVVuCqjk;

	// Token: 0x0400055D RID: 1373
	private FdQbBsfCWcVHOnPrmheJzorKWKWz GUUroRNRLiezBPDFFGmhlWiSmoHL;

	// Token: 0x0400055E RID: 1374
	private LEiRbylTDtVrpnaZskyeFoLSqqLb gXVvryMkmbpClmcPKNxqhHppoQdo;

	// Token: 0x0400055F RID: 1375
	private ConfigVars byzBIUJJDoWvgfkeWuusVKbxXOze;

	// Token: 0x04000560 RID: 1376
	private xKKbjmIOHiqxZGRJDfbeyLuvTjMwB VOXEPANloermVxmxCKXVPTVdufYF;

	// Token: 0x04000561 RID: 1377
	private UpdateLoopSetting XiCvbepVuBGVOigDqJtHYRWjrRQe;

	// Token: 0x04000562 RID: 1378
	private readonly bool ffkYtjjRvaFSHxGxPhNbvdnuYpCJ;

	// Token: 0x04000563 RID: 1379
	private readonly bool avlBzQVOOmctrTpmEXHsrvYWsNTI;

	// Token: 0x04000564 RID: 1380
	private readonly bool pYWQLrMqbZxicddMdiGbfgukpRfg;

	// Token: 0x04000565 RID: 1381
	private readonly bool gnaYFbRKchKCDvUQaJovVlrHNiC;

	// Token: 0x04000566 RID: 1382
	private readonly bool CbLbIBDreQeHPQDNNJCUfGWxISaOA;

	// Token: 0x04000567 RID: 1383
	public readonly bool PCIejCVVtKDeaxdrPCqsOfGdCdPJ;

	// Token: 0x04000568 RID: 1384
	private readonly List<EnhancedDeviceSupportDeviceType> rTNnVqLbFSAxRQyXcoxqlsBoBPmw;

	// Token: 0x04000569 RID: 1385
	private bool SbjYMHffAPfTytadhhMWQyuOMwIe;

	// Token: 0x0400056A RID: 1386
	private bool KajMnkePQOUoAmbeGTolQSoRBzLt;

	// Token: 0x0400056B RID: 1387
	private bool JLzZoWISILHsQuFJXrjVrFLhgenkA;

	// Token: 0x0400056C RID: 1388
	private bool tTRWCjudTHdLbEXcLAgpFxERwIWaA;

	// Token: 0x0400056D RID: 1389
	private int HsvfrXPGUVtcBxVtDgDjDEOLqRDy;

	// Token: 0x0400056E RID: 1390
	private readonly object fvWSismAsaUXmyHxiJukkIQtireq = new object();

	// Token: 0x0400056F RID: 1391
	private readonly CcbBkDoBwnFtqUaGWyRJqFJSOkwI sXwLeordAktmuwEAZaWPKekWhBskA;

	// Token: 0x04000570 RID: 1392
	private int NfGpJIgYzUOTDvYCQeGrBiBwcHdQ = -1;

	// Token: 0x04000571 RID: 1393
	private bool ioeTMnkQysQdidRcVfjtHDyRnpKL;

	// Token: 0x04000572 RID: 1394
	private bool ohhHLLilFLEnbfpQCbKOiiAJQDUkB;

	// Token: 0x04000573 RID: 1395
	private zQCyBJwRZzSiLqPeefriktmkkwQOA saIhGPItaSONUlGCfkQNgBnRmRjT;

	// Token: 0x04000574 RID: 1396
	private IntPtr zBOqJQazNbeloaYjahKwZThqmDOA;

	// Token: 0x04000575 RID: 1397
	private IntPtr HmQhEsdTnUVesFnmlbFzVWcbeZep;

	// Token: 0x04000576 RID: 1398
	private ValueWatcher<IntPtr> zQevmraCUemJycjcpjreIFXDknaG;

	// Token: 0x04000577 RID: 1399
	private ValueWatcher[] dTTvbtaXrNYZVsRRzCSVLhknhAgi;

	// Token: 0x04000578 RID: 1400
	private double yJBAWPgaJyKZPpVRboxCYButwYAmA;

	// Token: 0x04000579 RID: 1401
	private DLJMGaTLIFFDahvupJkOZBRJLNrj xKjavJEsSjoBQTjQpisUwQaMAIvTA;

	// Token: 0x0400057A RID: 1402
	private GPtcMmggNtHHoFiravQLFQSHGfSGB MJzUEMMCEwaVyNiIgfiGOVxEhqiT;

	// Token: 0x0400057B RID: 1403
	private static aZbrTJbdkEqNgMSlZADNlszSrpmR.AnIursTJiGuiIahXHibSRdYFdKfZ RQtbxjionSPSpBjLjzUxiOpfwirWB;

	// Token: 0x0400057C RID: 1404
	private aZbrTJbdkEqNgMSlZADNlszSrpmR.vCxDyydNFJNMDqHSEqWWufpOoHJUA QKzAEzNTUnWYXWjSQsrTJtbRqrMg;

	// Token: 0x0400057D RID: 1405
	private NativeBuffer COKcWHihCTjTEfutjLCgQiNdfUgab;

	// Token: 0x0400057E RID: 1406
	private static GUIText BiTTaGdAoaIQrnjPMdOmPaHSJyir;

	// Token: 0x0400057F RID: 1407
	private static wOInxLKDewlatLvQaXlNWuUFKXeD.JwhalIYArpGBNzVQZkMprMIzIgmA[] hhsEgrUYvBDIdSzGNSTABLOygAEIA = new wOInxLKDewlatLvQaXlNWuUFKXeD.JwhalIYArpGBNzVQZkMprMIzIgmA[]
	{
		new wOInxLKDewlatLvQaXlNWuUFKXeD.JwhalIYArpGBNzVQZkMprMIzIgmA(1, 4),
		new wOInxLKDewlatLvQaXlNWuUFKXeD.JwhalIYArpGBNzVQZkMprMIzIgmA(1, 5),
		new wOInxLKDewlatLvQaXlNWuUFKXeD.JwhalIYArpGBNzVQZkMprMIzIgmA(1, 8),
		new wOInxLKDewlatLvQaXlNWuUFKXeD.JwhalIYArpGBNzVQZkMprMIzIgmA(12, 1)
	};

	// Token: 0x04000580 RID: 1408
	private readonly bbYYonPTzAJNYZIOnIOVBePssTCgA lFTWqZcHUFKDTcMbEohjznkOkUHW = new bbYYonPTzAJNYZIOnIOVBePssTCgA();

	// Token: 0x04000581 RID: 1409
	private readonly WwSVhacABKVkeCFnEObUUluxAROM lOOlqLqrNKcwMaWstPctAADCMjhE = new WwSVhacABKVkeCFnEObUUluxAROM();

	// Token: 0x04000582 RID: 1410
	private bool yUNqFolpiwMgMNMzdtVDlLlMgvVDA;

	// Token: 0x02000079 RID: 121
	private class JwhalIYArpGBNzVQZkMprMIzIgmA
	{
		// Token: 0x0600041C RID: 1052 RVA: 0x0001356A File Offset: 0x0001176A
		public JwhalIYArpGBNzVQZkMprMIzIgmA(ushort A_1, ushort A_2)
		{
			this.KeDWeKHKNMDtGpjOqkkXSjHefuZO = A_1;
			this.bVkkIEYQJGEcvgqHglIZEtIQSSXqA = A_2;
		}

		// Token: 0x04000583 RID: 1411
		public ushort KeDWeKHKNMDtGpjOqkkXSjHefuZO;

		// Token: 0x04000584 RID: 1412
		public ushort bVkkIEYQJGEcvgqHglIZEtIQSSXqA;
	}

	// Token: 0x0200007A RID: 122
	internal class pIHDcrDscxxIBcviwGKasvZcCcqtA : UNUwlYTygIQzsQfFTWPgdoKuWLAh, IDisposable
	{
		// Token: 0x0600041D RID: 1053 RVA: 0x0002EB6C File Offset: 0x0002CD6C
		public static wOInxLKDewlatLvQaXlNWuUFKXeD.pIHDcrDscxxIBcviwGKasvZcCcqtA jQRHvUzrzgGhXrFdNwsPUwevLcfH(IntPtr A_0, string A_1)
		{
			return new wOInxLKDewlatLvQaXlNWuUFKXeD.pIHDcrDscxxIBcviwGKasvZcCcqtA(A_0, A_1, A_1, "", "", 0, 0, false, "");
		}

		// Token: 0x0600041E RID: 1054 RVA: 0x0002EB94 File Offset: 0x0002CD94
		public pIHDcrDscxxIBcviwGKasvZcCcqtA(IntPtr A_1, string A_2, string A_3, string A_4, string A_5, int A_6, int A_7, bool A_8, string A_9)
		{
			this.hPdoOBPGbalOHskftmamNFKeGnTJA = A_1;
			try
			{
				this.LUhoBWhafBKtOTcIgQfxeQWfbduD = A_2;
				this.ZCEcioGGjxYZJNAbOiuecvuXKZmM = AdSkHYvPxgeOVFEGslVOiHZEQBxjb.zntnSUJJitVdtJJQJKoubsHXrwF(A_2);
				this.JWmznKZerSqEoSTzFodxtHZGlVLq = A_3;
				this.LIGvjPLsdiFliIDTzJYvfBLdfhJc = StringTools.SanitizeDeviceString(A_4);
				this.AuuUJRqgxQlvqfZjAhBzIsdimuON = StringTools.SanitizeDeviceString(A_5);
				this.nUFYhUxcbPelAdvnqUukxJFkTCLN = A_6;
				this.hurgSPblriZnbEXWMAaHTNpYCUDR = A_7;
				this.mSWSBNDhPniuIFTiiqvMdboJWhZec = A_8;
				this.KllVsuOxyBYajyRCAZTMYHqHXzHc = StringTools.SanitizeDeviceString(A_9);
				if (!this.nPQpkQBByBKglLzMtSwncbjmhvpd)
				{
					this.JykQRHDIGCSrODCKBZXdwbkQrCxN = true;
					this.HQpEJQfNfwFFSCyUqWGkKopMFvSkA = A_1;
					this.nPQpkQBByBKglLzMtSwncbjmhvpd = true;
				}
				IntPtr hqpEJQfNfwFFSCyUqWGkKopMFvSkA = this.HQpEJQfNfwFFSCyUqWGkKopMFvSkA;
				this.bhjtvKzUJEGLaUASgBHcCjcMOgoh = gGETNRbPSWqlyBUigXMEkvuRFmnB.TakwfFHfYFPNBgAACGXcNIzJbVhZ(hqpEJQfNfwFFSCyUqWGkKopMFvSkA);
				this.nrFxUhOonytqZBApVsMWuKRLSpBB = gGETNRbPSWqlyBUigXMEkvuRFmnB.fHDodMLZYyqYpzsDjsuSDCvBsjpQ(hqpEJQfNfwFFSCyUqWGkKopMFvSkA);
				this.qmpTbAQnySgOyNexMrGIMRsACbmj = gGETNRbPSWqlyBUigXMEkvuRFmnB.TakwfFHfYFPNBgAACGXcNIzJbVhZ(hqpEJQfNfwFFSCyUqWGkKopMFvSkA);
				this.avJghxgFvzsjilBpAulUrjOpxbDk = gGETNRbPSWqlyBUigXMEkvuRFmnB.dEYyBugjCuUDIsbZeDkORdNPlipt(hqpEJQfNfwFFSCyUqWGkKopMFvSkA, 0, this.qmpTbAQnySgOyNexMrGIMRsACbmj.lLFyYWPKrDJvebPUylwpfbNzVoRn);
				this.LbChlxgNPTLINMPnfQPYgmHZLPqFb = gGETNRbPSWqlyBUigXMEkvuRFmnB.oZQBWYgjqOcpLsdmSDkafkxhLRGr(hqpEJQfNfwFFSCyUqWGkKopMFvSkA, 0, this.qmpTbAQnySgOyNexMrGIMRsACbmj.ArArcsvIxIXDVVldsTzbsFteIrXj);
				nMKuILhlKqiCXJYuGzaWdljEmVYk nMKuILhlKqiCXJYuGzaWdljEmVYk = this.nrFxUhOonytqZBApVsMWuKRLSpBB;
				RBgxLOqXDeBwgTCosGulaNJVoafUA rbgxLOqXDeBwgTCosGulaNJVoafUA = this.qmpTbAQnySgOyNexMrGIMRsACbmj;
				asQysbCLhjLumeAunxVmAMhzuxkO[] array = this.avJghxgFvzsjilBpAulUrjOpxbDk;
				LZSOfWeWYqbxLxzQJCslEUUQonPf[] lbChlxgNPTLINMPnfQPYgmHZLPqFb = this.LbChlxgNPTLINMPnfQPYgmHZLPqFb;
			}
			catch (Exception ex)
			{
				throw new Exception(string.Format("Error querying HID device \"{0}\" at location {1}.\nException Message: {2}\nStack Trace: {3}", new object[]
				{
					A_2,
					this.HQpEJQfNfwFFSCyUqWGkKopMFvSkA,
					ex.Message,
					ex.StackTrace
				}), ex);
			}
			finally
			{
				try
				{
					this.xxGfzkeAhxAnizWtXzwsXbvGXYK();
				}
				catch
				{
				}
			}
		}

		// Token: 0x14000009 RID: 9
		// (add) Token: 0x0600041F RID: 1055 RVA: 0x0002ED3C File Offset: 0x0002CF3C
		// (remove) Token: 0x06000420 RID: 1056 RVA: 0x0002ED74 File Offset: 0x0002CF74
		public event VBZdBZJTZUWnuIxzBijutMCAqeqi kbXABWsgujUdHJzifQPlkrxGucfi
		{
			[CompilerGenerated]
			add
			{
				VBZdBZJTZUWnuIxzBijutMCAqeqi vbzdBZJTZUWnuIxzBijutMCAqeqi = this.GbuiFCoHRkIODENGqjrECgnSUkcLA;
				VBZdBZJTZUWnuIxzBijutMCAqeqi vbzdBZJTZUWnuIxzBijutMCAqeqi2;
				do
				{
					vbzdBZJTZUWnuIxzBijutMCAqeqi2 = vbzdBZJTZUWnuIxzBijutMCAqeqi;
					VBZdBZJTZUWnuIxzBijutMCAqeqi value2 = (VBZdBZJTZUWnuIxzBijutMCAqeqi)Delegate.Combine(vbzdBZJTZUWnuIxzBijutMCAqeqi2, value);
					vbzdBZJTZUWnuIxzBijutMCAqeqi = Interlocked.CompareExchange<VBZdBZJTZUWnuIxzBijutMCAqeqi>(ref this.GbuiFCoHRkIODENGqjrECgnSUkcLA, value2, vbzdBZJTZUWnuIxzBijutMCAqeqi2);
				}
				while (vbzdBZJTZUWnuIxzBijutMCAqeqi != vbzdBZJTZUWnuIxzBijutMCAqeqi2);
			}
			[CompilerGenerated]
			remove
			{
				VBZdBZJTZUWnuIxzBijutMCAqeqi vbzdBZJTZUWnuIxzBijutMCAqeqi = this.GbuiFCoHRkIODENGqjrECgnSUkcLA;
				VBZdBZJTZUWnuIxzBijutMCAqeqi vbzdBZJTZUWnuIxzBijutMCAqeqi2;
				do
				{
					vbzdBZJTZUWnuIxzBijutMCAqeqi2 = vbzdBZJTZUWnuIxzBijutMCAqeqi;
					VBZdBZJTZUWnuIxzBijutMCAqeqi value2 = (VBZdBZJTZUWnuIxzBijutMCAqeqi)Delegate.Remove(vbzdBZJTZUWnuIxzBijutMCAqeqi2, value);
					vbzdBZJTZUWnuIxzBijutMCAqeqi = Interlocked.CompareExchange<VBZdBZJTZUWnuIxzBijutMCAqeqi>(ref this.GbuiFCoHRkIODENGqjrECgnSUkcLA, value2, vbzdBZJTZUWnuIxzBijutMCAqeqi2);
				}
				while (vbzdBZJTZUWnuIxzBijutMCAqeqi != vbzdBZJTZUWnuIxzBijutMCAqeqi2);
			}
		}

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x06000421 RID: 1057 RVA: 0x0002EDAC File Offset: 0x0002CFAC
		// (remove) Token: 0x06000422 RID: 1058 RVA: 0x0002EDE4 File Offset: 0x0002CFE4
		public event CWjfVJslYDdJBByQyyovBwMTsIwmA kEGYuOFeHzTrYUPDnMowfAjKRNll
		{
			[CompilerGenerated]
			add
			{
				CWjfVJslYDdJBByQyyovBwMTsIwmA cwjfVJslYDdJBByQyyovBwMTsIwmA = this.dXOGsBVrzZkpvknhiSgPpBRzkEhb;
				CWjfVJslYDdJBByQyyovBwMTsIwmA cwjfVJslYDdJBByQyyovBwMTsIwmA2;
				do
				{
					cwjfVJslYDdJBByQyyovBwMTsIwmA2 = cwjfVJslYDdJBByQyyovBwMTsIwmA;
					CWjfVJslYDdJBByQyyovBwMTsIwmA value2 = (CWjfVJslYDdJBByQyyovBwMTsIwmA)Delegate.Combine(cwjfVJslYDdJBByQyyovBwMTsIwmA2, value);
					cwjfVJslYDdJBByQyyovBwMTsIwmA = Interlocked.CompareExchange<CWjfVJslYDdJBByQyyovBwMTsIwmA>(ref this.dXOGsBVrzZkpvknhiSgPpBRzkEhb, value2, cwjfVJslYDdJBByQyyovBwMTsIwmA2);
				}
				while (cwjfVJslYDdJBByQyyovBwMTsIwmA != cwjfVJslYDdJBByQyyovBwMTsIwmA2);
			}
			[CompilerGenerated]
			remove
			{
				CWjfVJslYDdJBByQyyovBwMTsIwmA cwjfVJslYDdJBByQyyovBwMTsIwmA = this.dXOGsBVrzZkpvknhiSgPpBRzkEhb;
				CWjfVJslYDdJBByQyyovBwMTsIwmA cwjfVJslYDdJBByQyyovBwMTsIwmA2;
				do
				{
					cwjfVJslYDdJBByQyyovBwMTsIwmA2 = cwjfVJslYDdJBByQyyovBwMTsIwmA;
					CWjfVJslYDdJBByQyyovBwMTsIwmA value2 = (CWjfVJslYDdJBByQyyovBwMTsIwmA)Delegate.Remove(cwjfVJslYDdJBByQyyovBwMTsIwmA2, value);
					cwjfVJslYDdJBByQyyovBwMTsIwmA = Interlocked.CompareExchange<CWjfVJslYDdJBByQyyovBwMTsIwmA>(ref this.dXOGsBVrzZkpvknhiSgPpBRzkEhb, value2, cwjfVJslYDdJBByQyyovBwMTsIwmA2);
				}
				while (cwjfVJslYDdJBByQyyovBwMTsIwmA != cwjfVJslYDdJBByQyyovBwMTsIwmA2);
			}
		}

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x06000423 RID: 1059 RVA: 0x00013580 File Offset: 0x00011780
		public IntPtr nNEOnkDsaULOlpElKebSYChufHTd
		{
			get
			{
				return this.HQpEJQfNfwFFSCyUqWGkKopMFvSkA;
			}
		}

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x06000424 RID: 1060 RVA: 0x00013588 File Offset: 0x00011788
		public IntPtr wUshRbKcontFToeLOhhcoWckLDMW
		{
			get
			{
				return IntPtr.Zero;
			}
		}

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x06000425 RID: 1061 RVA: 0x0001358F File Offset: 0x0001178F
		// (set) Token: 0x06000426 RID: 1062 RVA: 0x00013597 File Offset: 0x00011797
		public bool nPQpkQBByBKglLzMtSwncbjmhvpd { get; private set; }

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x06000427 RID: 1063 RVA: 0x0001164A File Offset: 0x0000F84A
		public bool GRjaFvgfGDGwZBcbodEqOqRJHXClA
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x06000428 RID: 1064 RVA: 0x000135A0 File Offset: 0x000117A0
		public string EFYuWcfeHfiqKBGoJICOMKpLooof
		{
			get
			{
				return "";
			}
		}

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x06000429 RID: 1065 RVA: 0x000135A7 File Offset: 0x000117A7
		public RBgxLOqXDeBwgTCosGulaNJVoafUA uStAgDxEcOAbbgfjBKKeIdWrklZcb
		{
			get
			{
				return this.bhjtvKzUJEGLaUASgBHcCjcMOgoh;
			}
		}

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x0600042A RID: 1066 RVA: 0x000135AF File Offset: 0x000117AF
		public nMKuILhlKqiCXJYuGzaWdljEmVYk EbvtIjwOqlVUjYPaPgAizbpABXIw
		{
			get
			{
				return this.nrFxUhOonytqZBApVsMWuKRLSpBB;
			}
		}

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x0600042B RID: 1067 RVA: 0x000135B7 File Offset: 0x000117B7
		public string nyEfTKiBlpGrjhSHAOmjrGriiJiR
		{
			get
			{
				return this.LUhoBWhafBKtOTcIgQfxeQWfbduD;
			}
		}

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x0600042C RID: 1068 RVA: 0x00011826 File Offset: 0x0000FA26
		// (set) Token: 0x0600042D RID: 1069 RVA: 0x000116E9 File Offset: 0x0000F8E9
		public bool UefnKBAkkgeeaFfkfwKbmuIPGEhBA
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		// Token: 0x0600042E RID: 1070 RVA: 0x0002EE1C File Offset: 0x0002D01C
		public bool eFlMgRNvTUdXdxVfwTvLsBIfUAeh(bool A_1, qxfynNTzhcgKivFwRJjlHgrcRzob A_2, bool A_3, qxfynNTzhcgKivFwRJjlHgrcRzob A_4, hhPqsFbzywnSQVhdyrXfEDbDgBfaA A_5)
		{
			if (this.JykQRHDIGCSrODCKBZXdwbkQrCxN)
			{
				this.nPQpkQBByBKglLzMtSwncbjmhvpd = true;
				return true;
			}
			this.hldUymXtlcCpWvPJEwmCggMhSctB = A_2;
			this.xzwaXVECBZOUnrcqZkASCOEkeXvyB = A_4;
			this.BbHcDjktUOCoTkluAdRsgVasnXCn = A_5;
			if (!A_1 && !A_3)
			{
				this.xxGfzkeAhxAnizWtXzwsXbvGXYK();
				return false;
			}
			if (this.nPQpkQBByBKglLzMtSwncbjmhvpd)
			{
				return true;
			}
			if (A_1)
			{
				try
				{
					this.HQpEJQfNfwFFSCyUqWGkKopMFvSkA = gGETNRbPSWqlyBUigXMEkvuRFmnB.sUqCujHxPvhbAItZrECwKbPHnhi(this.LUhoBWhafBKtOTcIgQfxeQWfbduD, A_2, 2147483648U, A_5);
					if (this.HQpEJQfNfwFFSCyUqWGkKopMFvSkA.ToInt32() == -1)
					{
						this.HQpEJQfNfwFFSCyUqWGkKopMFvSkA = IntPtr.Zero;
						throw new Exception();
					}
				}
				catch (Exception innerException)
				{
					this.nPQpkQBByBKglLzMtSwncbjmhvpd = false;
					throw new Exception("Error opening HID device.", innerException);
				}
			}
			this.nPQpkQBByBKglLzMtSwncbjmhvpd = (this.HQpEJQfNfwFFSCyUqWGkKopMFvSkA != IntPtr.Zero);
			return this.nPQpkQBByBKglLzMtSwncbjmhvpd;
		}

		// Token: 0x0600042F RID: 1071 RVA: 0x0002EEE8 File Offset: 0x0002D0E8
		public void xxGfzkeAhxAnizWtXzwsXbvGXYK()
		{
			if (this.JykQRHDIGCSrODCKBZXdwbkQrCxN)
			{
				this.nPQpkQBByBKglLzMtSwncbjmhvpd = false;
				return;
			}
			if (!this.nPQpkQBByBKglLzMtSwncbjmhvpd)
			{
				return;
			}
			if (this.HQpEJQfNfwFFSCyUqWGkKopMFvSkA != IntPtr.Zero)
			{
				gGETNRbPSWqlyBUigXMEkvuRFmnB.rueNvfdHvncohpilHeKujGQKqlfiA(this.HQpEJQfNfwFFSCyUqWGkKopMFvSkA);
			}
			this.nPQpkQBByBKglLzMtSwncbjmhvpd = false;
			this.HQpEJQfNfwFFSCyUqWGkKopMFvSkA = IntPtr.Zero;
		}

		// Token: 0x06000430 RID: 1072 RVA: 0x000116EB File Offset: 0x0000F8EB
		public SUacMwOayTZKOyVCOmIAhOpIjuaFA nAVcvKfQHHQlwdkVXMctoSvKrwYIA()
		{
			return null;
		}

		// Token: 0x06000431 RID: 1073 RVA: 0x000116EB File Offset: 0x0000F8EB
		public SUacMwOayTZKOyVCOmIAhOpIjuaFA gmtLYjOShthVHYGiQoUHdZuaITBE(int A_1)
		{
			return null;
		}

		// Token: 0x06000432 RID: 1074 RVA: 0x00011826 File Offset: 0x0000FA26
		public bool bJzJsHXkhgWpZHfcUnsVUjComWzB(SUacMwOayTZKOyVCOmIAhOpIjuaFA A_1, int A_2)
		{
			return false;
		}

		// Token: 0x06000433 RID: 1075 RVA: 0x0002EF40 File Offset: 0x0002D140
		public bool IAUqJGaZpVKuzEduVpPWPeQXNSQp(out byte[] A_1, int A_2, byte A_3 = 0)
		{
			if (this.JykQRHDIGCSrODCKBZXdwbkQrCxN)
			{
				A_1 = null;
				return false;
			}
			if (A_2 <= 0)
			{
				A_1 = new byte[0];
				return false;
			}
			A_1 = new byte[A_2];
			byte[] array = wOInxLKDewlatLvQaXlNWuUFKXeD.pIHDcrDscxxIBcviwGKasvZcCcqtA.BmtDNXpcWPrKtMCbGEYlEEBSSdwh(A_2);
			array[0] = A_3;
			IntPtr intPtr = IntPtr.Zero;
			bool flag = false;
			try
			{
				if (this.nPQpkQBByBKglLzMtSwncbjmhvpd)
				{
					intPtr = this.HQpEJQfNfwFFSCyUqWGkKopMFvSkA;
				}
				else
				{
					intPtr = gGETNRbPSWqlyBUigXMEkvuRFmnB.sUqCujHxPvhbAItZrECwKbPHnhi(this.LUhoBWhafBKtOTcIgQfxeQWfbduD, this.hldUymXtlcCpWvPJEwmCggMhSctB, 0U, this.BbHcDjktUOCoTkluAdRsgVasnXCn);
					if (intPtr.ToInt32() == -1)
					{
						return false;
					}
				}
				flag = InwmSbStntxHshbqEcOpJBZJJqVi.ywUgbngQTTjWYshPnpiMOPBpPKEn(intPtr, array, array.Length);
				if (flag)
				{
					Array.Copy(array, 0, A_1, 0, Math.Min(A_1.Length, A_2));
				}
			}
			catch (Exception innerException)
			{
				throw new Exception(string.Format("Error accessing HID device '{0}'.", this.LUhoBWhafBKtOTcIgQfxeQWfbduD), innerException);
			}
			finally
			{
				if (!this.nPQpkQBByBKglLzMtSwncbjmhvpd && intPtr.ToInt32() != -1)
				{
					gGETNRbPSWqlyBUigXMEkvuRFmnB.rueNvfdHvncohpilHeKujGQKqlfiA(intPtr);
				}
			}
			return flag;
		}

		// Token: 0x06000434 RID: 1076 RVA: 0x0002F034 File Offset: 0x0002D234
		public string cvUmOCGwokcRwQdmRGXABPCuAywy()
		{
			if (this.JykQRHDIGCSrODCKBZXdwbkQrCxN)
			{
				return string.Empty;
			}
			string result;
			try
			{
				byte[] bytes;
				if (!this.pEAPaMiLEkIErXxguxAvkpXPHHyS(out bytes))
				{
					result = string.Empty;
				}
				else
				{
					result = StringTools.SanitizeDeviceString(StringTools.GetNullTerminatedUnicodeString(bytes));
				}
			}
			catch (Exception)
			{
				result = string.Empty;
			}
			return result;
		}

		// Token: 0x06000435 RID: 1077 RVA: 0x0002F08C File Offset: 0x0002D28C
		public unsafe bool pEAPaMiLEkIErXxguxAvkpXPHHyS(out byte[] A_1)
		{
			if (this.JykQRHDIGCSrODCKBZXdwbkQrCxN)
			{
				A_1 = null;
				return false;
			}
			A_1 = new byte[255];
			IntPtr intPtr = IntPtr.Zero;
			bool result = false;
			try
			{
				if (this.nPQpkQBByBKglLzMtSwncbjmhvpd)
				{
					intPtr = this.HQpEJQfNfwFFSCyUqWGkKopMFvSkA;
				}
				else
				{
					intPtr = gGETNRbPSWqlyBUigXMEkvuRFmnB.sUqCujHxPvhbAItZrECwKbPHnhi(this.LUhoBWhafBKtOTcIgQfxeQWfbduD, this.hldUymXtlcCpWvPJEwmCggMhSctB, 0U, this.BbHcDjktUOCoTkluAdRsgVasnXCn);
					if (intPtr.ToInt32() == -1)
					{
						return false;
					}
				}
				try
				{
					byte[] array;
					void* value;
					if ((array = A_1) == null || array.Length == 0)
					{
						value = null;
					}
					else
					{
						value = (void*)(&array[0]);
					}
					result = InwmSbStntxHshbqEcOpJBZJJqVi.zXjONJemTKhrFVgoHmWlbeXHvOEv(intPtr, (IntPtr)value, A_1.Length);
				}
				finally
				{
					byte[] array = null;
				}
			}
			catch (Exception innerException)
			{
				throw new Exception(string.Format("Error accessing HID device '{0}'.", this.LUhoBWhafBKtOTcIgQfxeQWfbduD), innerException);
			}
			finally
			{
				if (!this.nPQpkQBByBKglLzMtSwncbjmhvpd && intPtr.ToInt32() != -1)
				{
					gGETNRbPSWqlyBUigXMEkvuRFmnB.rueNvfdHvncohpilHeKujGQKqlfiA(intPtr);
				}
			}
			return result;
		}

		// Token: 0x06000436 RID: 1078 RVA: 0x0002F188 File Offset: 0x0002D388
		public string thFAOrGbNlelEtbezoOmnTfZWgxw()
		{
			if (this.JykQRHDIGCSrODCKBZXdwbkQrCxN)
			{
				return string.Empty;
			}
			byte[] bytes;
			this.uEvDsWRYZlSJufhgHZZvFUEJvGfM(out bytes);
			return StringTools.SanitizeDeviceString(StringTools.GetNullTerminatedUnicodeString(bytes));
		}

		// Token: 0x06000437 RID: 1079 RVA: 0x0002F1B8 File Offset: 0x0002D3B8
		public bool uEvDsWRYZlSJufhgHZZvFUEJvGfM(out byte[] A_1)
		{
			if (this.JykQRHDIGCSrODCKBZXdwbkQrCxN)
			{
				A_1 = null;
				return false;
			}
			A_1 = new byte[255];
			IntPtr intPtr = IntPtr.Zero;
			bool result = false;
			try
			{
				if (this.nPQpkQBByBKglLzMtSwncbjmhvpd)
				{
					intPtr = this.HQpEJQfNfwFFSCyUqWGkKopMFvSkA;
				}
				else
				{
					intPtr = gGETNRbPSWqlyBUigXMEkvuRFmnB.sUqCujHxPvhbAItZrECwKbPHnhi(this.LUhoBWhafBKtOTcIgQfxeQWfbduD, this.hldUymXtlcCpWvPJEwmCggMhSctB, 0U, this.BbHcDjktUOCoTkluAdRsgVasnXCn);
					if (intPtr.ToInt32() == -1)
					{
						return false;
					}
				}
				GCHandle gchandle = GCHandle.Alloc(A_1, GCHandleType.Pinned);
				result = InwmSbStntxHshbqEcOpJBZJJqVi.qSOdAtJzduBJEtbNvtJvmgAlJMFGA(intPtr, gchandle.AddrOfPinnedObject(), A_1.Length);
				GC.KeepAlive(gchandle);
				gchandle.Free();
			}
			catch (Exception innerException)
			{
				throw new Exception(string.Format("Error accessing HID device '{0}'.", this.LUhoBWhafBKtOTcIgQfxeQWfbduD), innerException);
			}
			finally
			{
				if (!this.nPQpkQBByBKglLzMtSwncbjmhvpd && intPtr.ToInt32() != -1)
				{
					gGETNRbPSWqlyBUigXMEkvuRFmnB.rueNvfdHvncohpilHeKujGQKqlfiA(intPtr);
				}
			}
			return result;
		}

		// Token: 0x06000438 RID: 1080 RVA: 0x0002F2A0 File Offset: 0x0002D4A0
		public string AyrZkabmCAGEJNWEReaKdJLkwzKl()
		{
			if (this.JykQRHDIGCSrODCKBZXdwbkQrCxN)
			{
				return string.Empty;
			}
			byte[] bytes;
			this.XwlPfoFpqEayzKxmbBWAlgxqNjei(out bytes);
			return StringTools.SanitizeDeviceString(StringTools.GetNullTerminatedUnicodeString(bytes));
		}

		// Token: 0x06000439 RID: 1081 RVA: 0x0002F2D0 File Offset: 0x0002D4D0
		public bool XwlPfoFpqEayzKxmbBWAlgxqNjei(out byte[] A_1)
		{
			if (this.JykQRHDIGCSrODCKBZXdwbkQrCxN)
			{
				A_1 = null;
				return false;
			}
			IntPtr intPtr = IntPtr.Zero;
			bool result = false;
			try
			{
				if (this.nPQpkQBByBKglLzMtSwncbjmhvpd)
				{
					intPtr = this.HQpEJQfNfwFFSCyUqWGkKopMFvSkA;
				}
				else
				{
					intPtr = gGETNRbPSWqlyBUigXMEkvuRFmnB.sUqCujHxPvhbAItZrECwKbPHnhi(this.LUhoBWhafBKtOTcIgQfxeQWfbduD, this.hldUymXtlcCpWvPJEwmCggMhSctB, 0U, this.BbHcDjktUOCoTkluAdRsgVasnXCn);
					if (intPtr.ToInt32() == -1)
					{
						A_1 = null;
						return false;
					}
				}
				result = gGETNRbPSWqlyBUigXMEkvuRFmnB.JoGJnckxMgCLMtYfAljprZndnlMw(intPtr, out A_1);
			}
			catch (Exception innerException)
			{
				throw new Exception(string.Format("Error accessing HID device '{0}'.", this.LUhoBWhafBKtOTcIgQfxeQWfbduD), innerException);
			}
			finally
			{
				if (!this.nPQpkQBByBKglLzMtSwncbjmhvpd && intPtr.ToInt32() != -1)
				{
					gGETNRbPSWqlyBUigXMEkvuRFmnB.rueNvfdHvncohpilHeKujGQKqlfiA(intPtr);
				}
			}
			return result;
		}

		// Token: 0x0600043A RID: 1082 RVA: 0x000135A0 File Offset: 0x000117A0
		public string weKnEubnjtLyeNULfmtaWGNTCdUGA()
		{
			return "";
		}

		// Token: 0x0600043B RID: 1083 RVA: 0x000135BF File Offset: 0x000117BF
		public bool LUfqdjsrZZripSWCMgNwmfDXIByK(out byte[] A_1)
		{
			A_1 = null;
			return false;
		}

		// Token: 0x0600043C RID: 1084 RVA: 0x00011826 File Offset: 0x0000FA26
		public bool ChUOBxWOOyjzWaLcPmWzTIxBxhAi(byte[] A_1)
		{
			return false;
		}

		// Token: 0x0600043D RID: 1085 RVA: 0x00011826 File Offset: 0x0000FA26
		public bool BFXmoClhrPMfQlqabbXGdiHHGGjGA(byte[] A_1, int A_2)
		{
			return false;
		}

		// Token: 0x0600043E RID: 1086 RVA: 0x000116EB File Offset: 0x0000F8EB
		public lvaNdjrANYKQfYbeZetpBGuhCoofb abFGhEeJlaMjUsPyGPdZPecHnSsW()
		{
			return null;
		}

		// Token: 0x0600043F RID: 1087 RVA: 0x00011826 File Offset: 0x0000FA26
		public bool csZoozmLxKtBskxZAqXmRZahFvEG(byte[] A_1, int A_2)
		{
			return false;
		}

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x06000440 RID: 1088 RVA: 0x000135C5 File Offset: 0x000117C5
		public asQysbCLhjLumeAunxVmAMhzuxkO[] FkTyAfATsMCltoLQBwQpsIApccSW
		{
			get
			{
				return this.avJghxgFvzsjilBpAulUrjOpxbDk;
			}
		}

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x06000441 RID: 1089 RVA: 0x000135CD File Offset: 0x000117CD
		public LZSOfWeWYqbxLxzQJCslEUUQonPf[] whviNDIeNbMZgKrXZyjWNpCsuJEJ
		{
			get
			{
				return this.LbChlxgNPTLINMPnfQPYgmHZLPqFb;
			}
		}

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x06000442 RID: 1090 RVA: 0x000135D5 File Offset: 0x000117D5
		public string dnQHNEzctKOQigHseanNdTSZCLnB
		{
			get
			{
				return this.ZCEcioGGjxYZJNAbOiuecvuXKZmM;
			}
		}

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x06000443 RID: 1091 RVA: 0x000135DD File Offset: 0x000117DD
		public string RoInVdEkWcIztboDcLpJMuMbhQIB
		{
			get
			{
				return this.JWmznKZerSqEoSTzFodxtHZGlVLq;
			}
		}

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x06000444 RID: 1092 RVA: 0x000135E5 File Offset: 0x000117E5
		public string KQkmzNTLTpkgMACBXpdfxKHheTfGA
		{
			get
			{
				return this.AuuUJRqgxQlvqfZjAhBzIsdimuON;
			}
		}

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x06000445 RID: 1093 RVA: 0x000135ED File Offset: 0x000117ED
		public int qcdWoDenISMIQEvQArHagxnrNzyd
		{
			get
			{
				return this.nUFYhUxcbPelAdvnqUukxJFkTCLN;
			}
		}

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x06000446 RID: 1094 RVA: 0x000135F5 File Offset: 0x000117F5
		public int UGbxSSHetLbbZgjfzASKCkIosQbr
		{
			get
			{
				return this.hurgSPblriZnbEXWMAaHTNpYCUDR;
			}
		}

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x06000447 RID: 1095 RVA: 0x000135FD File Offset: 0x000117FD
		public bool uHmffYhTWkNNUoSBeauUySsqVBCEA
		{
			get
			{
				return this.mSWSBNDhPniuIFTiiqvMdboJWhZec;
			}
		}

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x06000448 RID: 1096 RVA: 0x00013605 File Offset: 0x00011805
		public string svgWTFfTaOoHwzVJzcBrQWCRKqaj
		{
			get
			{
				return this.KllVsuOxyBYajyRCAZTMYHqHXzHc;
			}
		}

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x06000449 RID: 1097 RVA: 0x00011826 File Offset: 0x0000FA26
		public bool QzlfJYHQiKGPHlDdSYiClsfkXdLS
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0600044A RID: 1098 RVA: 0x000116E9 File Offset: 0x0000F8E9
		public void Dispose()
		{
		}

		// Token: 0x0600044B RID: 1099 RVA: 0x00011826 File Offset: 0x0000FA26
		public bool tLRLvLWkAgnuUigsXFxgBtGeEWoc(AWHWYMjOaGiEqJCCtAEpfhRJAtYq A_1, int A_2)
		{
			return false;
		}

		// Token: 0x0600044C RID: 1100 RVA: 0x0001360D File Offset: 0x0001180D
		private byte[] NxKZmPpfvdgSnehyyAxcMsPDHjcVA()
		{
			return wOInxLKDewlatLvQaXlNWuUFKXeD.pIHDcrDscxxIBcviwGKasvZcCcqtA.XTKSuMMJqKvbJmbSPqfvLhavWUhk((int)(this.uStAgDxEcOAbbgfjBKKeIdWrklZcb.DeFTMTiDmbeSCTBoAjIpfKKtFugCA - 1));
		}

		// Token: 0x0600044D RID: 1101 RVA: 0x00013621 File Offset: 0x00011821
		private byte[] uYMpwGJeqZSDgUZWKHqZvpJgSLmP()
		{
			return wOInxLKDewlatLvQaXlNWuUFKXeD.pIHDcrDscxxIBcviwGKasvZcCcqtA.XTKSuMMJqKvbJmbSPqfvLhavWUhk((int)(this.uStAgDxEcOAbbgfjBKKeIdWrklZcb.VHYGbFCVUXRyxKnodGcHQGYOxPzR - 1));
		}

		// Token: 0x0600044E RID: 1102 RVA: 0x00013635 File Offset: 0x00011835
		private static byte[] BmtDNXpcWPrKtMCbGEYlEEBSSdwh(int A_0)
		{
			return wOInxLKDewlatLvQaXlNWuUFKXeD.pIHDcrDscxxIBcviwGKasvZcCcqtA.XTKSuMMJqKvbJmbSPqfvLhavWUhk(A_0 - 1);
		}

		// Token: 0x0600044F RID: 1103 RVA: 0x0002F388 File Offset: 0x0002D588
		private static byte[] XTKSuMMJqKvbJmbSPqfvLhavWUhk(int A_0)
		{
			byte[] result = null;
			Array.Resize<byte>(ref result, A_0 + 1);
			return result;
		}

		// Token: 0x04000585 RID: 1413
		public const int ioBemRbxRJvDdcCNpzERwKvHXigrA = 255;

		// Token: 0x04000586 RID: 1414
		private IntPtr hPdoOBPGbalOHskftmamNFKeGnTJA;

		// Token: 0x04000587 RID: 1415
		private IntPtr HQpEJQfNfwFFSCyUqWGkKopMFvSkA;

		// Token: 0x04000588 RID: 1416
		private RBgxLOqXDeBwgTCosGulaNJVoafUA bhjtvKzUJEGLaUASgBHcCjcMOgoh;

		// Token: 0x04000589 RID: 1417
		private readonly string LIGvjPLsdiFliIDTzJYvfBLdfhJc;

		// Token: 0x0400058A RID: 1418
		private readonly string LUhoBWhafBKtOTcIgQfxeQWfbduD;

		// Token: 0x0400058B RID: 1419
		private readonly string ZCEcioGGjxYZJNAbOiuecvuXKZmM;

		// Token: 0x0400058C RID: 1420
		private readonly string JWmznKZerSqEoSTzFodxtHZGlVLq;

		// Token: 0x0400058D RID: 1421
		private readonly nMKuILhlKqiCXJYuGzaWdljEmVYk nrFxUhOonytqZBApVsMWuKRLSpBB;

		// Token: 0x0400058E RID: 1422
		private readonly string AuuUJRqgxQlvqfZjAhBzIsdimuON;

		// Token: 0x0400058F RID: 1423
		private readonly int nUFYhUxcbPelAdvnqUukxJFkTCLN;

		// Token: 0x04000590 RID: 1424
		private readonly int hurgSPblriZnbEXWMAaHTNpYCUDR;

		// Token: 0x04000591 RID: 1425
		private readonly bool mSWSBNDhPniuIFTiiqvMdboJWhZec;

		// Token: 0x04000592 RID: 1426
		private readonly string KllVsuOxyBYajyRCAZTMYHqHXzHc;

		// Token: 0x04000593 RID: 1427
		private readonly bool JykQRHDIGCSrODCKBZXdwbkQrCxN;

		// Token: 0x04000594 RID: 1428
		private readonly RBgxLOqXDeBwgTCosGulaNJVoafUA qmpTbAQnySgOyNexMrGIMRsACbmj;

		// Token: 0x04000595 RID: 1429
		private readonly asQysbCLhjLumeAunxVmAMhzuxkO[] avJghxgFvzsjilBpAulUrjOpxbDk;

		// Token: 0x04000596 RID: 1430
		private readonly LZSOfWeWYqbxLxzQJCslEUUQonPf[] LbChlxgNPTLINMPnfQPYgmHZLPqFb;

		// Token: 0x04000597 RID: 1431
		private qxfynNTzhcgKivFwRJjlHgrcRzob hldUymXtlcCpWvPJEwmCggMhSctB;

		// Token: 0x04000598 RID: 1432
		private qxfynNTzhcgKivFwRJjlHgrcRzob xzwaXVECBZOUnrcqZkASCOEkeXvyB;

		// Token: 0x04000599 RID: 1433
		private hhPqsFbzywnSQVhdyrXfEDbDgBfaA BbHcDjktUOCoTkluAdRsgVasnXCn = hhPqsFbzywnSQVhdyrXfEDbDgBfaA.ShareRead;

		// Token: 0x0400059A RID: 1434
		[CompilerGenerated]
		private VBZdBZJTZUWnuIxzBijutMCAqeqi GbuiFCoHRkIODENGqjrECgnSUkcLA;

		// Token: 0x0400059B RID: 1435
		[CompilerGenerated]
		private CWjfVJslYDdJBByQyyovBwMTsIwmA dXOGsBVrzZkpvknhiSgPpBRzkEhb;

		// Token: 0x0400059C RID: 1436
		[CompilerGenerated]
		private bool xewRcCBRQpFPrwrupAdDJMMtwxPW;
	}

	// Token: 0x0200007B RID: 123
	internal class bDkGXbbOFPbPhNDUOtOKwGHPkkzfb : HIDDeviceDriver.IHIDDevice
	{
		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x06000450 RID: 1104 RVA: 0x0001363F File Offset: 0x0001183F
		public HIDDeviceDriver.HIDProperties properties
		{
			get
			{
				return this.UAMZjsbFmheNSrXDJyjnjCRLKIhr;
			}
		}

		// Token: 0x06000451 RID: 1105 RVA: 0x0002F3A4 File Offset: 0x0002D5A4
		public bDkGXbbOFPbPhNDUOtOKwGHPkkzfb(UNUwlYTygIQzsQfFTWPgdoKuWLAh A_1, bCrPvFjWmsstplKHCuEMMNuBtNlb A_2)
		{
			this.nDeozEmBlDFSmVEpnQeqYmxxFYPj = A_1;
			this.UAMZjsbFmheNSrXDJyjnjCRLKIhr = new HIDDeviceDriver.HIDProperties((ushort)this.nDeozEmBlDFSmVEpnQeqYmxxFYPj.EbvtIjwOqlVUjYPaPgAizbpABXIw.NQEQBXVZUGlRQtHlwpaoFEPXdsHz, (ushort)this.nDeozEmBlDFSmVEpnQeqYmxxFYPj.EbvtIjwOqlVUjYPaPgAizbpABXIw.yWhgKuXCSVHPWvYYnJRdryFUTekj, this.nDeozEmBlDFSmVEpnQeqYmxxFYPj.cOvNaQIzOlfzWiDaUJRCNBVgjRbh(), this.nDeozEmBlDFSmVEpnQeqYmxxFYPj.KQkmzNTLTpkgMACBXpdfxKHheTfGA, (ushort)this.nDeozEmBlDFSmVEpnQeqYmxxFYPj.uStAgDxEcOAbbgfjBKKeIdWrklZcb.cokBHYDpGjMULdyNCfUoWDZvhZIpA, (ushort)this.nDeozEmBlDFSmVEpnQeqYmxxFYPj.uStAgDxEcOAbbgfjBKKeIdWrklZcb.tmpUyTjLkuZKfbsSAFjDQZhZBIfE, (int)this.nDeozEmBlDFSmVEpnQeqYmxxFYPj.uStAgDxEcOAbbgfjBKKeIdWrklZcb.DeFTMTiDmbeSCTBoAjIpfKKtFugCA, (int)this.nDeozEmBlDFSmVEpnQeqYmxxFYPj.uStAgDxEcOAbbgfjBKKeIdWrklZcb.VHYGbFCVUXRyxKnodGcHQGYOxPzR, (int)this.nDeozEmBlDFSmVEpnQeqYmxxFYPj.uStAgDxEcOAbbgfjBKKeIdWrklZcb.sOHFnupHcKtocgBXqNMmkoadUoUq);
			this.ieMVnWlczDSlBGjCLCtEJhvMjQHxA = A_2;
			this.wVntNMTGCzMSYwGdTkZRVtoCbVJT = new SUacMwOayTZKOyVCOmIAhOpIjuaFA(this.UAMZjsbFmheNSrXDJyjnjCRLKIhr.maxInputReportLength);
		}

		// Token: 0x06000452 RID: 1106 RVA: 0x0002F470 File Offset: 0x0002D670
		public byte[] GetHidFeatureData(byte reportId, int reportLength, int timeoutMs, int retryCount)
		{
			double num = ReInput.realTime + (double)timeoutMs * 0.001;
			for (;;)
			{
				byte[] result;
				bool flag = this.nDeozEmBlDFSmVEpnQeqYmxxFYPj.JZQbmvfLiDZJkSXAfEGZQZaJVsUn(out result, reportLength, reportId);
				retryCount--;
				if (timeoutMs > 0 && !flag && ReInput.realTime >= num)
				{
					break;
				}
				if (flag || retryCount < 0)
				{
					return result;
				}
			}
			return null;
		}

		// Token: 0x06000453 RID: 1107 RVA: 0x00013647 File Offset: 0x00011847
		public bool ReadSync(IntPtr buffer, int bytesToRead, int timeoutMs)
		{
			bool result = this.nDeozEmBlDFSmVEpnQeqYmxxFYPj.luWhJEUcAFCWKFEprSnRioWuDqwX(this.wVntNMTGCzMSYwGdTkZRVtoCbVJT, timeoutMs);
			Marshal.Copy(this.wVntNMTGCzMSYwGdTkZRVtoCbVJT.SnlFfMeLwJXFbUsWTtYFLqfBBGaXA, 0, buffer, Mathf.Min(this.wVntNMTGCzMSYwGdTkZRVtoCbVJT.SnlFfMeLwJXFbUsWTtYFLqfBBGaXA.Length, bytesToRead));
			return result;
		}

		// Token: 0x06000454 RID: 1108 RVA: 0x00013680 File Offset: 0x00011880
		public void WriteAsync(AWHWYMjOaGiEqJCCtAEpfhRJAtYq outputReport, int timeoutMs)
		{
			this.ieMVnWlczDSlBGjCLCtEJhvMjQHxA.YgWzttauTVbTBvpWnDGkkCSRyCub(outputReport, timeoutMs);
		}

		// Token: 0x06000455 RID: 1109 RVA: 0x0001368F File Offset: 0x0001188F
		public bool WriteSync(AWHWYMjOaGiEqJCCtAEpfhRJAtYq outputReport, int timeoutMs)
		{
			return this.nDeozEmBlDFSmVEpnQeqYmxxFYPj.JsOzJtYtutmTSoYuRdQKHmwEhpUy(outputReport, timeoutMs);
		}

		// Token: 0x0400059D RID: 1437
		private UNUwlYTygIQzsQfFTWPgdoKuWLAh nDeozEmBlDFSmVEpnQeqYmxxFYPj;

		// Token: 0x0400059E RID: 1438
		private HIDDeviceDriver.HIDProperties UAMZjsbFmheNSrXDJyjnjCRLKIhr;

		// Token: 0x0400059F RID: 1439
		private bCrPvFjWmsstplKHCuEMMNuBtNlb ieMVnWlczDSlBGjCLCtEJhvMjQHxA;

		// Token: 0x040005A0 RID: 1440
		private SUacMwOayTZKOyVCOmIAhOpIjuaFA wVntNMTGCzMSYwGdTkZRVtoCbVJT;
	}

	// Token: 0x0200007C RID: 124
	[CompilerGenerated]
	[Serializable]
	private sealed class EZOytEZJoCIWJFyPcnnZreUwnJAFb
	{
		// Token: 0x06000458 RID: 1112 RVA: 0x000136AA File Offset: 0x000118AA
		internal void IIVpMytGJnGDeOQTgijYkgpyjLzU(zOVftvsFbTAvLzuhvSRGfBOXFlHHA A_1)
		{
			A_1.Dispose();
		}

		// Token: 0x040005A1 RID: 1441
		public static readonly wOInxLKDewlatLvQaXlNWuUFKXeD.EZOytEZJoCIWJFyPcnnZreUwnJAFb <>9 = new wOInxLKDewlatLvQaXlNWuUFKXeD.EZOytEZJoCIWJFyPcnnZreUwnJAFb();

		// Token: 0x040005A2 RID: 1442
		public static Action<zOVftvsFbTAvLzuhvSRGfBOXFlHHA> <>9__63_0;
	}

	// Token: 0x0200007D RID: 125
	[CompilerGenerated]
	private sealed class wGmOTuzHwFSApaLtIJVrScgddjCE
	{
		// Token: 0x0600045A RID: 1114 RVA: 0x000136B2 File Offset: 0x000118B2
		internal bool xldDoasmQoOMQlWCECcFqKAvDXKDA(string A_1)
		{
			return A_1.Equals(this.cxxCrvKSrjPrHVsUijgfALQUltybA[this.QvqeIxeuCCsmqpTVkeAwFRiubUuMA].UtDuBqGKZydgwlrsrAtoYXSTKKYg, StringComparison.OrdinalIgnoreCase);
		}

		// Token: 0x040005A3 RID: 1443
		public IList<hVaQpyMLtSMUpozCEslGMGuQGKOz.UHslNClYbydtNrFHkmjroviMCtpA> cxxCrvKSrjPrHVsUijgfALQUltybA;

		// Token: 0x040005A4 RID: 1444
		public int QvqeIxeuCCsmqpTVkeAwFRiubUuMA;

		// Token: 0x040005A5 RID: 1445
		public Predicate<string> iuruCJPNnUybnPfaebyGbJHPcGGR;
	}

	// Token: 0x0200007E RID: 126
	[CompilerGenerated]
	private sealed class fuynTgodjwtsjbgAdUCtPyslhInC
	{
		// Token: 0x0600045C RID: 1116 RVA: 0x000136D1 File Offset: 0x000118D1
		internal bool kiGYefaoUOoXCZBlBwbzlwewvIPu(zOVftvsFbTAvLzuhvSRGfBOXFlHHA A_1)
		{
			return A_1.GNTLZGZMYteNfQShJMHVqmWwrOKR == this.GPfDnZDXiEYGvucMRGOnhSpbNtHQ.GNTLZGZMYteNfQShJMHVqmWwrOKR;
		}

		// Token: 0x040005A6 RID: 1446
		public zOVftvsFbTAvLzuhvSRGfBOXFlHHA GPfDnZDXiEYGvucMRGOnhSpbNtHQ;
	}

	// Token: 0x0200007F RID: 127
	[CompilerGenerated]
	private sealed class UeFXSOrMPzTUSAtFbJdEOtQavMDm
	{
		// Token: 0x0600045E RID: 1118 RVA: 0x0002F4C4 File Offset: 0x0002D6C4
		internal void JorswbWZXbAKVlgvrMNakoFDpyyB()
		{
			try
			{
				AfMbFsJstyiXPRpuLyuwQILIdQLv.COtgnZXAMsSruBpqkVLumczdHkty((kyyeJPAifzwsCJMsRzCRiCmfOgCIA)1, (RAVOkNOPomjLLELffRNedOUcwUii)4, qyhuAEUGhJrVUpIPbZkNEAPBOkzv.InputSink | qyhuAEUGhJrVUpIPbZkNEAPBOkzv.DeviceNotify, this.EiFllmXwzUKIZljAudcetwPsdxJhA.xKjavJEsSjoBQTjQpisUwQaMAIvTA.UradimpePZJbUJETzZGUOMPnDILu);
				AfMbFsJstyiXPRpuLyuwQILIdQLv.COtgnZXAMsSruBpqkVLumczdHkty((kyyeJPAifzwsCJMsRzCRiCmfOgCIA)1, (RAVOkNOPomjLLELffRNedOUcwUii)5, qyhuAEUGhJrVUpIPbZkNEAPBOkzv.InputSink | qyhuAEUGhJrVUpIPbZkNEAPBOkzv.DeviceNotify, this.EiFllmXwzUKIZljAudcetwPsdxJhA.xKjavJEsSjoBQTjQpisUwQaMAIvTA.UradimpePZJbUJETzZGUOMPnDILu);
				AfMbFsJstyiXPRpuLyuwQILIdQLv.COtgnZXAMsSruBpqkVLumczdHkty((kyyeJPAifzwsCJMsRzCRiCmfOgCIA)1, (RAVOkNOPomjLLELffRNedOUcwUii)8, qyhuAEUGhJrVUpIPbZkNEAPBOkzv.InputSink | qyhuAEUGhJrVUpIPbZkNEAPBOkzv.DeviceNotify, this.EiFllmXwzUKIZljAudcetwPsdxJhA.xKjavJEsSjoBQTjQpisUwQaMAIvTA.UradimpePZJbUJETzZGUOMPnDILu);
				AfMbFsJstyiXPRpuLyuwQILIdQLv.COtgnZXAMsSruBpqkVLumczdHkty((kyyeJPAifzwsCJMsRzCRiCmfOgCIA)12, (RAVOkNOPomjLLELffRNedOUcwUii)1, qyhuAEUGhJrVUpIPbZkNEAPBOkzv.InputSink | qyhuAEUGhJrVUpIPbZkNEAPBOkzv.DeviceNotify, this.EiFllmXwzUKIZljAudcetwPsdxJhA.xKjavJEsSjoBQTjQpisUwQaMAIvTA.UradimpePZJbUJETzZGUOMPnDILu);
			}
			catch
			{
				this.QrZKQUAXOWzCFHsbeHvjlOVStiOm = true;
			}
		}

		// Token: 0x040005A7 RID: 1447
		public wOInxLKDewlatLvQaXlNWuUFKXeD EiFllmXwzUKIZljAudcetwPsdxJhA;

		// Token: 0x040005A8 RID: 1448
		public bool QrZKQUAXOWzCFHsbeHvjlOVStiOm;
	}

	// Token: 0x02000080 RID: 128
	[CompilerGenerated]
	private sealed class bsWqUrOpNpeoBiXRSoNUFiRNMekUA
	{
		// Token: 0x06000460 RID: 1120 RVA: 0x0002F560 File Offset: 0x0002D760
		internal void WolTCprWaMPpcLLSvfFsBPYZMSIb()
		{
			try
			{
				AfMbFsJstyiXPRpuLyuwQILIdQLv.vRxonKWaQcEQWqWBpZGhskoZDKbeA((kyyeJPAifzwsCJMsRzCRiCmfOgCIA)1, (RAVOkNOPomjLLELffRNedOUcwUii)4);
				AfMbFsJstyiXPRpuLyuwQILIdQLv.vRxonKWaQcEQWqWBpZGhskoZDKbeA((kyyeJPAifzwsCJMsRzCRiCmfOgCIA)1, (RAVOkNOPomjLLELffRNedOUcwUii)5);
				AfMbFsJstyiXPRpuLyuwQILIdQLv.vRxonKWaQcEQWqWBpZGhskoZDKbeA((kyyeJPAifzwsCJMsRzCRiCmfOgCIA)1, (RAVOkNOPomjLLELffRNedOUcwUii)8);
				AfMbFsJstyiXPRpuLyuwQILIdQLv.vRxonKWaQcEQWqWBpZGhskoZDKbeA((kyyeJPAifzwsCJMsRzCRiCmfOgCIA)12, (RAVOkNOPomjLLELffRNedOUcwUii)1);
			}
			catch
			{
				this.YJaqqybBKpCdoxROVCvnvFDPdkMQ = true;
			}
		}

		// Token: 0x040005A9 RID: 1449
		public bool YJaqqybBKpCdoxROVCvnvFDPdkMQ;
	}

	// Token: 0x02000081 RID: 129
	[CompilerGenerated]
	private sealed class UypFuchyaLnoJrEYUFKhcCxRCYoIA
	{
		// Token: 0x06000462 RID: 1122 RVA: 0x0002F5A8 File Offset: 0x0002D7A8
		internal void brVafjaCSreWfKbBVndTqWgOuIqdA()
		{
			try
			{
				AfMbFsJstyiXPRpuLyuwQILIdQLv.vRxonKWaQcEQWqWBpZGhskoZDKbeA((kyyeJPAifzwsCJMsRzCRiCmfOgCIA)1, (RAVOkNOPomjLLELffRNedOUcwUii)2);
			}
			catch
			{
				this.VgCGKrcHcdIqmcirgKbQjRbceDerb = true;
			}
		}

		// Token: 0x040005AA RID: 1450
		public bool VgCGKrcHcdIqmcirgKbQjRbceDerb;
	}

	// Token: 0x02000082 RID: 130
	[CompilerGenerated]
	private sealed class EHwyqjgrmlnEuMNAMvihbGbLeEZiA
	{
		// Token: 0x06000464 RID: 1124 RVA: 0x0002F5D8 File Offset: 0x0002D7D8
		internal void NuAbMHKORMnOZxPNMJLKjUbbYToAA()
		{
			try
			{
				AfMbFsJstyiXPRpuLyuwQILIdQLv.COtgnZXAMsSruBpqkVLumczdHkty((kyyeJPAifzwsCJMsRzCRiCmfOgCIA)1, (RAVOkNOPomjLLELffRNedOUcwUii)2, qyhuAEUGhJrVUpIPbZkNEAPBOkzv.InputSink, this.OJKyalRRVPhwvyKdUVBIZffblidq.xKjavJEsSjoBQTjQpisUwQaMAIvTA.UradimpePZJbUJETzZGUOMPnDILu);
			}
			catch
			{
				this.ptmoqdqqyVUpstzhLHSolDGSgUmEA = true;
			}
		}

		// Token: 0x040005AB RID: 1451
		public wOInxLKDewlatLvQaXlNWuUFKXeD OJKyalRRVPhwvyKdUVBIZffblidq;

		// Token: 0x040005AC RID: 1452
		public bool ptmoqdqqyVUpstzhLHSolDGSgUmEA;
	}

	// Token: 0x02000083 RID: 131
	[CompilerGenerated]
	private sealed class luEWehzNmHBkrgeVOhwWBwsrfyShA
	{
		// Token: 0x06000466 RID: 1126 RVA: 0x0002F620 File Offset: 0x0002D820
		internal void tnbtaldcuIEiPgrmdZKyQVfReQVBA()
		{
			try
			{
				AfMbFsJstyiXPRpuLyuwQILIdQLv.COtgnZXAMsSruBpqkVLumczdHkty((kyyeJPAifzwsCJMsRzCRiCmfOgCIA)1, (RAVOkNOPomjLLELffRNedOUcwUii)6, qyhuAEUGhJrVUpIPbZkNEAPBOkzv.InputSink, this.YkLGVRGsqhqjqSapirKWUwqVvbzu.xKjavJEsSjoBQTjQpisUwQaMAIvTA.UradimpePZJbUJETzZGUOMPnDILu);
			}
			catch
			{
				this.BBBcxeIWYVpAFlLwNnPnXcoOIGgGA = true;
			}
		}

		// Token: 0x040005AD RID: 1453
		public wOInxLKDewlatLvQaXlNWuUFKXeD YkLGVRGsqhqjqSapirKWUwqVvbzu;

		// Token: 0x040005AE RID: 1454
		public bool BBBcxeIWYVpAFlLwNnPnXcoOIGgGA;
	}

	// Token: 0x02000084 RID: 132
	[CompilerGenerated]
	private sealed class lXUkMbTKnnPDGZTLfvxByZUKoBMQ
	{
		// Token: 0x06000468 RID: 1128 RVA: 0x0002F668 File Offset: 0x0002D868
		internal void xyeyfPIuzoqpKPGYecglmLrXykmo()
		{
			try
			{
				AfMbFsJstyiXPRpuLyuwQILIdQLv.vRxonKWaQcEQWqWBpZGhskoZDKbeA((kyyeJPAifzwsCJMsRzCRiCmfOgCIA)1, (RAVOkNOPomjLLELffRNedOUcwUii)6);
			}
			catch
			{
				this.wwCfSwAwYxuNzIEPIbVrquDrXeVd = true;
			}
		}

		// Token: 0x040005AF RID: 1455
		public bool wwCfSwAwYxuNzIEPIbVrquDrXeVd;
	}

	// Token: 0x02000085 RID: 133
	[CompilerGenerated]
	private sealed class RfvjfdukMLYDhodmgflMZyATabED
	{
		// Token: 0x0600046A RID: 1130 RVA: 0x0002F698 File Offset: 0x0002D898
		internal void dUFkWXXxQUtmUOisFkRcuGYNfnbh()
		{
			try
			{
				this.MMlANBcxZSqYTjBHcQJyTjkoTeeEA.xKjavJEsSjoBQTjQpisUwQaMAIvTA = wOInxLKDewlatLvQaXlNWuUFKXeD.BrCENPOyxZlUaWpwhdZNeCDpurVTA(this.IQjwdqDyLmruKyAcLMLfOreoxHgf);
				if (this.MMlANBcxZSqYTjBHcQJyTjkoTeeEA.xKjavJEsSjoBQTjQpisUwQaMAIvTA == null)
				{
					throw new Exception();
				}
			}
			catch
			{
				this.uhXPOhvKmKtCBcvdaOQuEfmeRDqx = true;
			}
		}

		// Token: 0x040005B0 RID: 1456
		public wOInxLKDewlatLvQaXlNWuUFKXeD MMlANBcxZSqYTjBHcQJyTjkoTeeEA;

		// Token: 0x040005B1 RID: 1457
		public DLJMGaTLIFFDahvupJkOZBRJLNrj.osqZvvGFouEfTOmJrimLXBVCYjbl IQjwdqDyLmruKyAcLMLfOreoxHgf;

		// Token: 0x040005B2 RID: 1458
		public bool uhXPOhvKmKtCBcvdaOQuEfmeRDqx;
	}
}
