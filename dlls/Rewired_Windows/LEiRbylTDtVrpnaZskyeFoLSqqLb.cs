using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using Rewired;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Libraries.SharpDX.RawInput;
using Rewired.Libraries.SharpDX.Windows.Forms;
using Rewired.Utils;
using UnityEngine;

// Token: 0x02000086 RID: 134
internal class LEiRbylTDtVrpnaZskyeFoLSqqLb : IUnifiedKeyboardSource, IGetSetEnabled, IDisposable
{
	// Token: 0x0600046B RID: 1131 RVA: 0x0002F6EC File Offset: 0x0002D8EC
	static LEiRbylTDtVrpnaZskyeFoLSqqLb()
	{
		int[] keyboardKeyValues = Consts._keyboardKeyValues;
		int num = keyboardKeyValues.Length;
		for (int i = 0; i < num; i++)
		{
			if (keyboardKeyValues[i] > LEiRbylTDtVrpnaZskyeFoLSqqLb.FevLLaXfUbgFGanUGDOSsuhIiQvSA)
			{
				LEiRbylTDtVrpnaZskyeFoLSqqLb.FevLLaXfUbgFGanUGDOSsuhIiQvSA = keyboardKeyValues[i];
			}
		}
		LEiRbylTDtVrpnaZskyeFoLSqqLb.woodKbZjyrEuFqNWytdIVvKTSsbi = new int[LEiRbylTDtVrpnaZskyeFoLSqqLb.FevLLaXfUbgFGanUGDOSsuhIiQvSA + 1];
		ArrayTools.Fill<int>(LEiRbylTDtVrpnaZskyeFoLSqqLb.woodKbZjyrEuFqNWytdIVvKTSsbi, -1);
		for (int j = 0; j < num; j++)
		{
			LEiRbylTDtVrpnaZskyeFoLSqqLb.woodKbZjyrEuFqNWytdIVvKTSsbi[keyboardKeyValues[j]] = j;
		}
	}

	// Token: 0x0600046C RID: 1132 RVA: 0x0002F8C4 File Offset: 0x0002DAC4
	public LEiRbylTDtVrpnaZskyeFoLSqqLb(UpdateLoopSetting A_1)
	{
		this.VeEsJIutzEEbUxPWXLnDHDjKrSYC();
		this.dpMGmWpMBiKDVyQlufObotnPuoyI = new UpdateLoopDataSet<LEiRbylTDtVrpnaZskyeFoLSqqLb.wfvbjlcJzegfbgclDjsqZXArcoJeb>(A_1);
		using (TempListPool.TList<UpdateLoopType> tlist = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tlist.list;
			EnumConverter.ToUpdateLoopTypes(A_1, list);
			for (int i = 0; i < list.Count; i++)
			{
				this.dpMGmWpMBiKDVyQlufObotnPuoyI[i] = new LEiRbylTDtVrpnaZskyeFoLSqqLb.wfvbjlcJzegfbgclDjsqZXArcoJeb(list[i]);
			}
		}
		this.FPkxLXnvERgoTXfJtErkgtRIbGgS = ReInput.IsInputAllowed(ControllerType.Keyboard);
		this.enabled = true;
		ReInput.ApplicationFocusChangedEvent += this.IgsQJhvLNYNtnQTqvvPAzIEPmihk;
		ReInput.ApplicationPauseChangedEvent += this.gyNAtefOQUmblbgnIXaLEyZfmgaW;
		ReInput.EditorPauseChangedEvent += this.XSTxGWaHHEXxVstuxszYWCTfDPUiA;
		ReInput.UpdateEndedEvent += this.obCVlULGPicGhdJEdJdCYXllrsteA;
		ReInput.TimeScalePauseChangedEvent += this.xbELargVnMuEmAhuMXGAHORReIjs;
	}

	// Token: 0x0600046D RID: 1133 RVA: 0x0002F9D4 File Offset: 0x0002DBD4
	public unsafe void fpQBTkhQAnLDhPBxlsoktJfJDLAuA(UpdateLoopType A_1)
	{
		this.dpMGmWpMBiKDVyQlufObotnPuoyI.SetUpdateLoop(A_1);
		this.FPkxLXnvERgoTXfJtErkgtRIbGgS = ReInput.IsInputAllowed(ControllerType.Keyboard);
		object xcaopnZLnfeZdKKCCCNTIPjYRccx = this.XCAOPnZLnfeZdKKCCCNTIPjYRccx;
		lock (xcaopnZLnfeZdKKCCCNTIPjYRccx)
		{
			try
			{
				byte* ptr = stackalloc byte[(UIntPtr)256];
				if (wLURyKQfpGlmweDJGGSrwwzrDUJFA.hBqoaftnPmGkocNbtDeEAhEfyZMl((IntPtr)((void*)ptr)))
				{
					int i = 0;
					while (i < 256)
					{
						if (i <= 6)
						{
							if (i - 1 > 1 && i - 4 > 2)
							{
								goto IL_81;
							}
						}
						else if (i - 16 > 2 && i != 65536 && i != 131072)
						{
							goto IL_81;
						}
						IL_19D:
						i++;
						continue;
						IL_81:
						if ((ptr[i] & 128) <= 0)
						{
							if (this.mcfFkoOhkGLPEWSSVYbmNqFsuzNt[i])
							{
								this.FYADInJrhPhWtfCyrPBMzuojZZYjA.uPbGwdNMzhXFdtmjIkGQZojJwJjn();
								this.FYADInJrhPhWtfCyrPBMzuojZZYjA.VxPbjGaSTCrpoPQUqNKkmZbReHtAb = ReInput.realTime;
								this.FYADInJrhPhWtfCyrPBMzuojZZYjA.cVJGYlcqZnZDShmWixTZBuxwEeUMA = IntPtr.Zero;
								this.FYADInJrhPhWtfCyrPBMzuojZZYjA.yYAYiULVNQeFVFYWSNpWbClKJKUD = (Keys)i;
								this.FYADInJrhPhWtfCyrPBMzuojZZYjA.SZGVJknVDbNAFWoOdqSVMAUYUvMd = 0;
								this.FYADInJrhPhWtfCyrPBMzuojZZYjA.JeShZeGfwyXxRdUCUFbbiEsKjTiic = ScanCodeFlags.Break;
								this.FYADInJrhPhWtfCyrPBMzuojZZYjA.xAAirmvFunTGYVBazPfKfnAjfGST = KeyState.KeyUp;
								this.FYADInJrhPhWtfCyrPBMzuojZZYjA.RSPpYHsoawfhZsjUoYtNpUWAiAaU = 0;
								this.RxZbxiYcwtjCLdNAyhOzidqGejlS(this.FYADInJrhPhWtfCyrPBMzuojZZYjA);
								goto IL_19D;
							}
							goto IL_19D;
						}
						else
						{
							if (!this.mcfFkoOhkGLPEWSSVYbmNqFsuzNt[i])
							{
								this.FYADInJrhPhWtfCyrPBMzuojZZYjA.uPbGwdNMzhXFdtmjIkGQZojJwJjn();
								this.FYADInJrhPhWtfCyrPBMzuojZZYjA.VxPbjGaSTCrpoPQUqNKkmZbReHtAb = ReInput.realTime;
								this.FYADInJrhPhWtfCyrPBMzuojZZYjA.cVJGYlcqZnZDShmWixTZBuxwEeUMA = IntPtr.Zero;
								this.FYADInJrhPhWtfCyrPBMzuojZZYjA.yYAYiULVNQeFVFYWSNpWbClKJKUD = (Keys)i;
								this.FYADInJrhPhWtfCyrPBMzuojZZYjA.SZGVJknVDbNAFWoOdqSVMAUYUvMd = 0;
								this.FYADInJrhPhWtfCyrPBMzuojZZYjA.JeShZeGfwyXxRdUCUFbbiEsKjTiic = ScanCodeFlags.Make;
								this.FYADInJrhPhWtfCyrPBMzuojZZYjA.xAAirmvFunTGYVBazPfKfnAjfGST = KeyState.KeyFirst;
								this.FYADInJrhPhWtfCyrPBMzuojZZYjA.RSPpYHsoawfhZsjUoYtNpUWAiAaU = 0;
								this.RxZbxiYcwtjCLdNAyhOzidqGejlS(this.FYADInJrhPhWtfCyrPBMzuojZZYjA);
								goto IL_19D;
							}
							goto IL_19D;
						}
					}
				}
			}
			catch
			{
			}
		}
	}

	// Token: 0x0600046E RID: 1134 RVA: 0x0002FBD0 File Offset: 0x0002DDD0
	public void RxZbxiYcwtjCLdNAyhOzidqGejlS(WwSVhacABKVkeCFnEObUUluxAROM A_1)
	{
		if (!this.FPkxLXnvERgoTXfJtErkgtRIbGgS)
		{
			return;
		}
		switch (A_1.yYAYiULVNQeFVFYWSNpWbClKJKUD)
		{
		case Keys.ShiftKey:
			A_1.yYAYiULVNQeFVFYWSNpWbClKJKUD = (Keys)wLURyKQfpGlmweDJGGSrwwzrDUJFA.oWwicRHsxJDDoNbIyZnVWXaUtNCf((uint)A_1.SZGVJknVDbNAFWoOdqSVMAUYUvMd, KastMvGkvyaNUEWReDndMRsEYrtnA.rGQaFWziwXWKlByhMfBKnJOSusLv);
			if (A_1.yYAYiULVNQeFVFYWSNpWbClKJKUD != Keys.LShiftKey && A_1.yYAYiULVNQeFVFYWSNpWbClKJKUD != Keys.RShiftKey)
			{
				KeyState xAAirmvFunTGYVBazPfKfnAjfGST = A_1.xAAirmvFunTGYVBazPfKfnAjfGST;
				bool flag = xAAirmvFunTGYVBazPfKfnAjfGST == KeyState.KeyFirst || xAAirmvFunTGYVBazPfKfnAjfGST == KeyState.SystemKeyDown || xAAirmvFunTGYVBazPfKfnAjfGST == KeyState.KeyLast;
				bool flag2 = ((int)wLURyKQfpGlmweDJGGSrwwzrDUJFA.EHlPdORcdQAvbEVIJSKSDDKjCQfq(160) & 32768) != 0;
				bool flag3 = ((int)wLURyKQfpGlmweDJGGSrwwzrDUJFA.EHlPdORcdQAvbEVIJSKSDDKjCQfq(161) & 32768) != 0;
				if (flag)
				{
					bool flag4 = ((int)wLURyKQfpGlmweDJGGSrwwzrDUJFA.BQnurNQQBkmpGZeACfRMDkAwFPwK(160) & 32768) != 0;
					bool flag5 = ((int)wLURyKQfpGlmweDJGGSrwwzrDUJFA.BQnurNQQBkmpGZeACfRMDkAwFPwK(161) & 32768) != 0;
					if (flag4)
					{
						A_1.yYAYiULVNQeFVFYWSNpWbClKJKUD = Keys.LShiftKey;
						this.RxZbxiYcwtjCLdNAyhOzidqGejlS(A_1);
					}
					if (flag5)
					{
						A_1.yYAYiULVNQeFVFYWSNpWbClKJKUD = Keys.RShiftKey;
						this.RxZbxiYcwtjCLdNAyhOzidqGejlS(A_1);
					}
					return;
				}
				if (flag2 && flag3)
				{
					return;
				}
				if (flag2)
				{
					A_1.yYAYiULVNQeFVFYWSNpWbClKJKUD = Keys.LShiftKey;
				}
				else
				{
					if (!flag3)
					{
						A_1.yYAYiULVNQeFVFYWSNpWbClKJKUD = Keys.LShiftKey;
						this.RxZbxiYcwtjCLdNAyhOzidqGejlS(A_1);
						A_1.yYAYiULVNQeFVFYWSNpWbClKJKUD = Keys.RShiftKey;
						this.RxZbxiYcwtjCLdNAyhOzidqGejlS(A_1);
						return;
					}
					A_1.yYAYiULVNQeFVFYWSNpWbClKJKUD = Keys.RShiftKey;
				}
			}
			break;
		case Keys.ControlKey:
		{
			Keys keys = (Keys)wLURyKQfpGlmweDJGGSrwwzrDUJFA.oWwicRHsxJDDoNbIyZnVWXaUtNCf((uint)A_1.SZGVJknVDbNAFWoOdqSVMAUYUvMd, KastMvGkvyaNUEWReDndMRsEYrtnA.rGQaFWziwXWKlByhMfBKnJOSusLv);
			if (keys != Keys.LControlKey && keys != Keys.RControlKey)
			{
				return;
			}
			A_1.yYAYiULVNQeFVFYWSNpWbClKJKUD = (((A_1.JeShZeGfwyXxRdUCUFbbiEsKjTiic & ScanCodeFlags.E0) != ScanCodeFlags.Make) ? Keys.RControlKey : Keys.LControlKey);
			break;
		}
		case Keys.Menu:
			A_1.yYAYiULVNQeFVFYWSNpWbClKJKUD = (((A_1.JeShZeGfwyXxRdUCUFbbiEsKjTiic & ScanCodeFlags.E0) != ScanCodeFlags.Make) ? Keys.RMenu : Keys.LMenu);
			break;
		}
		object xcaopnZLnfeZdKKCCCNTIPjYRccx = this.XCAOPnZLnfeZdKKCCCNTIPjYRccx;
		lock (xcaopnZLnfeZdKKCCCNTIPjYRccx)
		{
			KeyState xAAirmvFunTGYVBazPfKfnAjfGST = A_1.xAAirmvFunTGYVBazPfKfnAjfGST;
			if (xAAirmvFunTGYVBazPfKfnAjfGST == KeyState.KeyFirst || xAAirmvFunTGYVBazPfKfnAjfGST == KeyState.SystemKeyDown)
			{
				this.mcfFkoOhkGLPEWSSVYbmNqFsuzNt[(int)A_1.yYAYiULVNQeFVFYWSNpWbClKJKUD] = true;
			}
			else
			{
				this.mcfFkoOhkGLPEWSSVYbmNqFsuzNt[(int)A_1.yYAYiULVNQeFVFYWSNpWbClKJKUD] = false;
			}
			int count = this.dpMGmWpMBiKDVyQlufObotnPuoyI.Count;
			for (int i = 0; i < count; i++)
			{
				this.dpMGmWpMBiKDVyQlufObotnPuoyI[i].rrxUWhGlKWAAFLYoFgezpPOrYPVi(A_1);
			}
		}
	}

	// Token: 0x0600046F RID: 1135 RVA: 0x000136E9 File Offset: 0x000118E9
	public void QdCFEOVUnZeTOgTKbqJAeLMFxSKi(bool A_1)
	{
		this.EKpRmzlUdWssCZNjmjzTljfHmBbk();
	}

	// Token: 0x06000470 RID: 1136 RVA: 0x000136F1 File Offset: 0x000118F1
	public void GIYUwiSQNBuyUKiPhSkyEqmfjUwj(bool A_1)
	{
		if (this.VeEsJIutzEEbUxPWXLnDHDjKrSYC() < 0)
		{
			this.EKpRmzlUdWssCZNjmjzTljfHmBbk();
		}
	}

	// Token: 0x06000471 RID: 1137 RVA: 0x0002FE34 File Offset: 0x0002E034
	private int VeEsJIutzEEbUxPWXLnDHDjKrSYC()
	{
		int num = this.ugzGlDcwwnFFwafedkInFKVUzBFl;
		int num2;
		if (wOInxLKDewlatLvQaXlNWuUFKXeD.HWGuuLNggmCSsIIYWoKyBLiGGoXc(OiWGlufNbZAVpTSvEHgxGrekNlFFA.Keyboard, out num2))
		{
			this.ugzGlDcwwnFFwafedkInFKVUzBFl = num2;
		}
		else
		{
			this.ugzGlDcwwnFFwafedkInFKVUzBFl = 1;
		}
		return this.ugzGlDcwwnFFwafedkInFKVUzBFl - num;
	}

	// Token: 0x06000472 RID: 1138 RVA: 0x00013702 File Offset: 0x00011902
	private void IgsQJhvLNYNtnQTqvvPAzIEPmihk(bool A_1)
	{
		this.FPkxLXnvERgoTXfJtErkgtRIbGgS = ReInput.IsInputAllowed(ControllerType.Keyboard);
		if (!A_1 && !this.FPkxLXnvERgoTXfJtErkgtRIbGgS)
		{
			this.EKpRmzlUdWssCZNjmjzTljfHmBbk();
		}
	}

	// Token: 0x06000473 RID: 1139 RVA: 0x00013721 File Offset: 0x00011921
	private void gyNAtefOQUmblbgnIXaLEyZfmgaW(bool A_1)
	{
		this.FPkxLXnvERgoTXfJtErkgtRIbGgS = ReInput.IsInputAllowed(ControllerType.Mouse);
		if (!this.FPkxLXnvERgoTXfJtErkgtRIbGgS)
		{
			this.EKpRmzlUdWssCZNjmjzTljfHmBbk();
		}
	}

	// Token: 0x06000474 RID: 1140 RVA: 0x000116E9 File Offset: 0x0000F8E9
	private void XSTxGWaHHEXxVstuxszYWCTfDPUiA(bool A_1)
	{
	}

	// Token: 0x06000475 RID: 1141 RVA: 0x0002FE6C File Offset: 0x0002E06C
	private void xbELargVnMuEmAhuMXGAHORReIjs(bool A_1)
	{
		if ((ReInput.configVars.updateLoop & UpdateLoopSetting.FixedUpdate) == UpdateLoopSetting.None)
		{
			return;
		}
		this.FPkxLXnvERgoTXfJtErkgtRIbGgS = ReInput.IsInputAllowed(ControllerType.Keyboard);
		object xcaopnZLnfeZdKKCCCNTIPjYRccx = this.XCAOPnZLnfeZdKKCCCNTIPjYRccx;
		lock (xcaopnZLnfeZdKKCCCNTIPjYRccx)
		{
			this.dpMGmWpMBiKDVyQlufObotnPuoyI[this.dpMGmWpMBiKDVyQlufObotnPuoyI.fixedUpdateSetIndex].QLHcryaJuHdLKPXQdFuASWwoBvzgb();
		}
	}

	// Token: 0x06000476 RID: 1142 RVA: 0x0002FEDC File Offset: 0x0002E0DC
	private void obCVlULGPicGhdJEdJdCYXllrsteA(UpdateLoopType A_1)
	{
		object xcaopnZLnfeZdKKCCCNTIPjYRccx = this.XCAOPnZLnfeZdKKCCCNTIPjYRccx;
		lock (xcaopnZLnfeZdKKCCCNTIPjYRccx)
		{
			this.dpMGmWpMBiKDVyQlufObotnPuoyI.Get(A_1).vDyHlAdDwgVhcmxlybidCcViMisJB();
		}
	}

	// Token: 0x06000477 RID: 1143 RVA: 0x0002FF28 File Offset: 0x0002E128
	private void EKpRmzlUdWssCZNjmjzTljfHmBbk()
	{
		object xcaopnZLnfeZdKKCCCNTIPjYRccx = this.XCAOPnZLnfeZdKKCCCNTIPjYRccx;
		lock (xcaopnZLnfeZdKKCCCNTIPjYRccx)
		{
			int count = this.dpMGmWpMBiKDVyQlufObotnPuoyI.Count;
			for (int i = 0; i < count; i++)
			{
				this.dpMGmWpMBiKDVyQlufObotnPuoyI[i].BFvBkkfMokSKdpjkxySYhnTRPyfv();
			}
		}
	}

	// Token: 0x170000D9 RID: 217
	// (get) Token: 0x06000478 RID: 1144 RVA: 0x0001373D File Offset: 0x0001193D
	// (set) Token: 0x06000479 RID: 1145 RVA: 0x00013745 File Offset: 0x00011945
	public bool enabled
	{
		get
		{
			return this.BkpSKWZOdXpccUkbDwmCveOjDKLcA;
		}
		set
		{
			if (this.BkpSKWZOdXpccUkbDwmCveOjDKLcA == value)
			{
				return;
			}
			this.BkpSKWZOdXpccUkbDwmCveOjDKLcA = value;
		}
	}

	// Token: 0x170000DA RID: 218
	// (get) Token: 0x0600047A RID: 1146 RVA: 0x00011BB6 File Offset: 0x0000FDB6
	public InputSource inputSource
	{
		get
		{
			return InputSource.RawInput;
		}
	}

	// Token: 0x170000DB RID: 219
	// (get) Token: 0x0600047B RID: 1147 RVA: 0x00013758 File Offset: 0x00011958
	public HardwareControllerMap_Game hardwareMap
	{
		get
		{
			if (this.ObnGqQGxGqJGpHRlVuMgsWHHAApDb == null)
			{
				this.ObnGqQGxGqJGpHRlVuMgsWHHAApDb = LEiRbylTDtVrpnaZskyeFoLSqqLb.FgSoNBoGYZTjsarZRCzVTqKTcUHq();
			}
			return this.ObnGqQGxGqJGpHRlVuMgsWHHAApDb;
		}
	}

	// Token: 0x170000DC RID: 220
	// (get) Token: 0x0600047C RID: 1148 RVA: 0x00013773 File Offset: 0x00011973
	public int buttonCount
	{
		get
		{
			return 132;
		}
	}

	// Token: 0x170000DD RID: 221
	// (get) Token: 0x0600047D RID: 1149 RVA: 0x000116EB File Offset: 0x0000F8EB
	public Controller.Extension controllerExtension
	{
		get
		{
			return null;
		}
	}

	// Token: 0x0600047E RID: 1150 RVA: 0x0001377A File Offset: 0x0001197A
	public void UpdateInputData(ControllerDataUpdater dataUpdater)
	{
		this.dpMGmWpMBiKDVyQlufObotnPuoyI.Current.yaaHxNWjfcboPBWvcClGKJbXoTecA(dataUpdater);
	}

	// Token: 0x0600047F RID: 1151 RVA: 0x000136E9 File Offset: 0x000118E9
	public void Clear()
	{
		this.EKpRmzlUdWssCZNjmjzTljfHmBbk();
	}

	// Token: 0x06000480 RID: 1152 RVA: 0x0002FF8C File Offset: 0x0002E18C
	private static HardwareControllerMap_Game FgSoNBoGYZTjsarZRCzVTqKTcUHq()
	{
		ControllerElementIdentifier[] array = new ControllerElementIdentifier[132];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = new ControllerElementIdentifier(i, Consts.keyboardKeyNames[i], Consts.keyboardKeyNames[i], string.Empty, ControllerElementType.Button, true);
		}
		int[] array2 = new int[132];
		for (int j = 0; j < 132; j++)
		{
			array2[j] = array[j].id;
		}
		HardwareButtonInfo[] array3 = new HardwareButtonInfo[132];
		for (int k = 0; k < 132; k++)
		{
			array3[k] = new HardwareButtonInfo();
		}
		return new HardwareControllerMap_Game("Keyboard", default(HardwareControllerMapIdentifier), array, array2, new int[0], new AxisCalibrationData[0], new AxisRange[0], new HardwareAxisInfo[0], array3, null);
	}

	// Token: 0x06000481 RID: 1153 RVA: 0x0001378D File Offset: 0x0001198D
	public void Dispose()
	{
		this.KvPZsJnnIoEsoyPomElOpJtVWqtW(true);
		GC.SuppressFinalize(this);
	}

	// Token: 0x06000482 RID: 1154 RVA: 0x0003005C File Offset: 0x0002E25C
	protected virtual void fIAlGvHInHuNbozpANHGMBBYHZss()
	{
		try
		{
			this.KvPZsJnnIoEsoyPomElOpJtVWqtW(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	// Token: 0x06000483 RID: 1155 RVA: 0x0003008C File Offset: 0x0002E28C
	protected virtual void KvPZsJnnIoEsoyPomElOpJtVWqtW(bool A_1)
	{
		if (this.HLZaJOtOtkYWffFzMhJwkprTXiGA)
		{
			return;
		}
		ReInput.ApplicationFocusChangedEvent -= this.IgsQJhvLNYNtnQTqvvPAzIEPmihk;
		ReInput.ApplicationPauseChangedEvent -= this.gyNAtefOQUmblbgnIXaLEyZfmgaW;
		ReInput.EditorPauseChangedEvent -= this.XSTxGWaHHEXxVstuxszYWCTfDPUiA;
		ReInput.UpdateEndedEvent -= this.obCVlULGPicGhdJEdJdCYXllrsteA;
		ReInput.TimeScalePauseChangedEvent -= this.xbELargVnMuEmAhuMXGAHORReIjs;
		this.HLZaJOtOtkYWffFzMhJwkprTXiGA = true;
	}

	// Token: 0x06000484 RID: 1156 RVA: 0x00030100 File Offset: 0x0002E300
	public static int ghzaJiDmnqHARurBoQqJwgsoLWBUA(WwSVhacABKVkeCFnEObUUluxAROM A_0, KeyCode[] A_1)
	{
		Keys yYAYiULVNQeFVFYWSNpWbClKJKUD = A_0.yYAYiULVNQeFVFYWSNpWbClKJKUD;
		int result = 0;
		KastMvGkvyaNUEWReDndMRsEYrtnA.OhlkKcqKvcGknchIKaLAwnuZvNqj ohlkKcqKvcGknchIKaLAwnuZvNqj = LEiRbylTDtVrpnaZskyeFoLSqqLb.kFJNyPEWbgfsfltDPHwMMBSUMfnN();
		IntPtr intPtr = LEiRbylTDtVrpnaZskyeFoLSqqLb.cluTrzmjtcfHLRQwxCufYZLeJPOC;
		wLURyKQfpGlmweDJGGSrwwzrDUJFA.oWwicRHsxJDDoNbIyZnVWXaUtNCf((uint)A_0.yYAYiULVNQeFVFYWSNpWbClKJKUD, KastMvGkvyaNUEWReDndMRsEYrtnA.WqedmPEpYLTIlOtbWRYIfIEJTWMtA);
		if (LEiRbylTDtVrpnaZskyeFoLSqqLb.bBsoZxVCmlOMxQFlqmmcLYGePJXt(yYAYiULVNQeFVFYWSNpWbClKJKUD))
		{
			KeyCode keyCode;
			if (LEiRbylTDtVrpnaZskyeFoLSqqLb.kgDmNlMjPBGRsuFYVGYynTjGmGNb(yYAYiULVNQeFVFYWSNpWbClKJKUD, ohlkKcqKvcGknchIKaLAwnuZvNqj, out keyCode))
			{
				A_1[result++] = keyCode;
			}
		}
		else
		{
			switch (yYAYiULVNQeFVFYWSNpWbClKJKUD)
			{
			case Keys.None:
				A_1[result++] = KeyCode.None;
				break;
			case Keys.Back:
				A_1[result++] = KeyCode.Backspace;
				break;
			case Keys.Tab:
				A_1[result++] = KeyCode.Tab;
				break;
			case Keys.Clear:
				A_1[result++] = KeyCode.Clear;
				break;
			case Keys.Return:
				if ((A_0.JeShZeGfwyXxRdUCUFbbiEsKjTiic & ScanCodeFlags.E0) != ScanCodeFlags.Make)
				{
					A_1[result++] = KeyCode.KeypadEnter;
				}
				else
				{
					A_1[result++] = KeyCode.Return;
				}
				break;
			case Keys.Pause:
				A_1[result++] = KeyCode.Pause;
				break;
			case Keys.Capital:
				A_1[result++] = KeyCode.CapsLock;
				break;
			case Keys.Escape:
				A_1[result++] = KeyCode.Escape;
				break;
			case Keys.Space:
				A_1[result++] = KeyCode.Space;
				break;
			case Keys.Prior:
				A_1[result++] = KeyCode.PageUp;
				break;
			case Keys.Next:
				A_1[result++] = KeyCode.PageDown;
				break;
			case Keys.End:
				A_1[result++] = KeyCode.End;
				break;
			case Keys.Home:
				A_1[result++] = KeyCode.Home;
				break;
			case Keys.Left:
				A_1[result++] = KeyCode.LeftArrow;
				break;
			case Keys.Up:
				A_1[result++] = KeyCode.UpArrow;
				break;
			case Keys.Right:
				A_1[result++] = KeyCode.RightArrow;
				break;
			case Keys.Down:
				A_1[result++] = KeyCode.DownArrow;
				break;
			case Keys.Print:
				A_1[result++] = KeyCode.Print;
				break;
			case Keys.Insert:
				A_1[result++] = KeyCode.Insert;
				break;
			case Keys.Delete:
				A_1[result++] = KeyCode.Delete;
				break;
			case Keys.Help:
				A_1[result++] = KeyCode.Help;
				break;
			case Keys.D0:
				A_1[result++] = KeyCode.Alpha0;
				break;
			case Keys.D1:
				A_1[result++] = KeyCode.Alpha1;
				break;
			case Keys.D2:
				A_1[result++] = KeyCode.Alpha2;
				break;
			case Keys.D3:
				A_1[result++] = KeyCode.Alpha3;
				break;
			case Keys.D4:
				A_1[result++] = KeyCode.Alpha4;
				break;
			case Keys.D5:
				A_1[result++] = KeyCode.Alpha5;
				break;
			case Keys.D6:
				A_1[result++] = KeyCode.Alpha6;
				break;
			case Keys.D7:
				A_1[result++] = KeyCode.Alpha7;
				break;
			case Keys.D8:
				A_1[result++] = KeyCode.Alpha8;
				break;
			case Keys.D9:
				A_1[result++] = KeyCode.Alpha9;
				break;
			case Keys.A:
				A_1[result++] = KeyCode.A;
				break;
			case Keys.B:
				A_1[result++] = KeyCode.B;
				break;
			case Keys.C:
				A_1[result++] = KeyCode.C;
				break;
			case Keys.D:
				A_1[result++] = KeyCode.D;
				break;
			case Keys.E:
				A_1[result++] = KeyCode.E;
				break;
			case Keys.F:
				A_1[result++] = KeyCode.F;
				break;
			case Keys.G:
				A_1[result++] = KeyCode.G;
				break;
			case Keys.H:
				A_1[result++] = KeyCode.H;
				break;
			case Keys.I:
				A_1[result++] = KeyCode.I;
				break;
			case Keys.J:
				A_1[result++] = KeyCode.J;
				break;
			case Keys.K:
				A_1[result++] = KeyCode.K;
				break;
			case Keys.L:
				A_1[result++] = KeyCode.L;
				break;
			case Keys.M:
				A_1[result++] = KeyCode.M;
				break;
			case Keys.N:
				A_1[result++] = KeyCode.N;
				break;
			case Keys.O:
				A_1[result++] = KeyCode.O;
				break;
			case Keys.P:
				A_1[result++] = KeyCode.P;
				break;
			case Keys.Q:
				A_1[result++] = KeyCode.Q;
				break;
			case Keys.R:
				A_1[result++] = KeyCode.R;
				break;
			case Keys.S:
				A_1[result++] = KeyCode.S;
				break;
			case Keys.T:
				A_1[result++] = KeyCode.T;
				break;
			case Keys.U:
				A_1[result++] = KeyCode.U;
				break;
			case Keys.V:
				A_1[result++] = KeyCode.V;
				break;
			case Keys.W:
				A_1[result++] = KeyCode.W;
				break;
			case Keys.X:
				A_1[result++] = KeyCode.X;
				break;
			case Keys.Y:
				A_1[result++] = KeyCode.Y;
				break;
			case Keys.Z:
				A_1[result++] = KeyCode.Z;
				break;
			case Keys.LWin:
				A_1[result++] = KeyCode.LeftMeta;
				break;
			case Keys.RWin:
				A_1[result++] = KeyCode.RightMeta;
				break;
			case Keys.Apps:
				A_1[result++] = KeyCode.Menu;
				break;
			case Keys.NumPad0:
				A_1[result++] = KeyCode.Keypad0;
				break;
			case Keys.NumPad1:
				A_1[result++] = KeyCode.Keypad1;
				break;
			case Keys.NumPad2:
				A_1[result++] = KeyCode.Keypad2;
				break;
			case Keys.NumPad3:
				A_1[result++] = KeyCode.Keypad3;
				break;
			case Keys.NumPad4:
				A_1[result++] = KeyCode.Keypad4;
				break;
			case Keys.NumPad5:
				A_1[result++] = KeyCode.Keypad5;
				break;
			case Keys.NumPad6:
				A_1[result++] = KeyCode.Keypad6;
				break;
			case Keys.NumPad7:
				A_1[result++] = KeyCode.Keypad7;
				break;
			case Keys.NumPad8:
				A_1[result++] = KeyCode.Keypad8;
				break;
			case Keys.NumPad9:
				A_1[result++] = KeyCode.Keypad9;
				break;
			case Keys.Multiply:
				A_1[result++] = KeyCode.KeypadMultiply;
				break;
			case Keys.Add:
				A_1[result++] = KeyCode.KeypadPlus;
				break;
			case Keys.Subtract:
				A_1[result++] = KeyCode.KeypadMinus;
				break;
			case Keys.Decimal:
				A_1[result++] = KeyCode.KeypadPeriod;
				break;
			case Keys.Divide:
				A_1[result++] = KeyCode.KeypadDivide;
				break;
			case Keys.F1:
				A_1[result++] = KeyCode.F1;
				break;
			case Keys.F2:
				A_1[result++] = KeyCode.F2;
				break;
			case Keys.F3:
				A_1[result++] = KeyCode.F3;
				break;
			case Keys.F4:
				A_1[result++] = KeyCode.F4;
				break;
			case Keys.F5:
				A_1[result++] = KeyCode.F5;
				break;
			case Keys.F6:
				A_1[result++] = KeyCode.F6;
				break;
			case Keys.F7:
				A_1[result++] = KeyCode.F7;
				break;
			case Keys.F8:
				A_1[result++] = KeyCode.F8;
				break;
			case Keys.F9:
				A_1[result++] = KeyCode.F9;
				break;
			case Keys.F10:
				A_1[result++] = KeyCode.F10;
				break;
			case Keys.F11:
				A_1[result++] = KeyCode.F11;
				break;
			case Keys.F12:
				A_1[result++] = KeyCode.F12;
				break;
			case Keys.F13:
				A_1[result++] = KeyCode.F13;
				break;
			case Keys.F14:
				A_1[result++] = KeyCode.F14;
				break;
			case Keys.F15:
				A_1[result++] = KeyCode.F15;
				break;
			case Keys.NumLock:
				A_1[result++] = KeyCode.Numlock;
				break;
			case Keys.Scroll:
				A_1[result++] = KeyCode.ScrollLock;
				break;
			case Keys.LShiftKey:
				A_1[result++] = KeyCode.LeftShift;
				break;
			case Keys.RShiftKey:
				A_1[result++] = KeyCode.RightShift;
				break;
			case Keys.LControlKey:
				A_1[result++] = KeyCode.LeftControl;
				break;
			case Keys.RControlKey:
				A_1[result++] = KeyCode.RightControl;
				break;
			case Keys.LMenu:
				A_1[result++] = KeyCode.LeftAlt;
				break;
			case Keys.RMenu:
				A_1[result++] = KeyCode.AltGr;
				A_1[result++] = KeyCode.RightAlt;
				break;
			}
		}
		return result;
	}

	// Token: 0x06000485 RID: 1157 RVA: 0x00030A00 File Offset: 0x0002EC00
	private unsafe static KastMvGkvyaNUEWReDndMRsEYrtnA.OhlkKcqKvcGknchIKaLAwnuZvNqj kFJNyPEWbgfsfltDPHwMMBSUMfnN()
	{
		IntPtr value = wLURyKQfpGlmweDJGGSrwwzrDUJFA.DpVcDQOosfxTWcktJBPREdWHCrvU(0);
		if (value == LEiRbylTDtVrpnaZskyeFoLSqqLb.cluTrzmjtcfHLRQwxCufYZLeJPOC)
		{
			return LEiRbylTDtVrpnaZskyeFoLSqqLb.dfSGaJhzRewOmphtYoKutvgyojsfb;
		}
		KastMvGkvyaNUEWReDndMRsEYrtnA.OhlkKcqKvcGknchIKaLAwnuZvNqj result = KastMvGkvyaNUEWReDndMRsEYrtnA.OhlkKcqKvcGknchIKaLAwnuZvNqj.United_States_English;
		IntPtr value2 = stackalloc byte[(UIntPtr)128];
		wLURyKQfpGlmweDJGGSrwwzrDUJFA.DxNcHLhJpaNyUCmiqmCcDCSHvVhp((IntPtr)value2);
		int value3;
		if (int.TryParse(Marshal.PtrToStringUni((IntPtr)value2), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out value3))
		{
			int num = ArrayTools.IndexOf(LEiRbylTDtVrpnaZskyeFoLSqqLb.ggGyWUwelRKozdWfPXKbdGKyyrs, value3);
			if (num >= 0)
			{
				result = (KastMvGkvyaNUEWReDndMRsEYrtnA.OhlkKcqKvcGknchIKaLAwnuZvNqj)LEiRbylTDtVrpnaZskyeFoLSqqLb.ggGyWUwelRKozdWfPXKbdGKyyrs[num];
			}
		}
		LEiRbylTDtVrpnaZskyeFoLSqqLb.cluTrzmjtcfHLRQwxCufYZLeJPOC = value;
		LEiRbylTDtVrpnaZskyeFoLSqqLb.dfSGaJhzRewOmphtYoKutvgyojsfb = result;
		return result;
	}

	// Token: 0x06000486 RID: 1158 RVA: 0x00030A84 File Offset: 0x0002EC84
	private static bool kgDmNlMjPBGRsuFYVGYynTjGmGNb(Keys A_0, KastMvGkvyaNUEWReDndMRsEYrtnA.OhlkKcqKvcGknchIKaLAwnuZvNqj A_1, out KeyCode A_2)
	{
		A_2 = KeyCode.None;
		Dictionary<int, KeyCode> dictionary;
		if (!LEiRbylTDtVrpnaZskyeFoLSqqLb.GMRcHFodMyRrAFqyETlOcoZthLXl.TryGetValue((int)A_1, out dictionary))
		{
			dictionary = LEiRbylTDtVrpnaZskyeFoLSqqLb.GMRcHFodMyRrAFqyETlOcoZthLXl[1033];
		}
		bool flag = dictionary.TryGetValue((int)A_0, out A_2);
		if (!flag && A_1 != KastMvGkvyaNUEWReDndMRsEYrtnA.OhlkKcqKvcGknchIKaLAwnuZvNqj.United_States_English)
		{
			dictionary = LEiRbylTDtVrpnaZskyeFoLSqqLb.GMRcHFodMyRrAFqyETlOcoZthLXl[1033];
			flag = dictionary.TryGetValue((int)A_0, out A_2);
		}
		return flag;
	}

	// Token: 0x06000487 RID: 1159 RVA: 0x0001379C File Offset: 0x0001199C
	private static bool bBsoZxVCmlOMxQFlqmmcLYGePJXt(Keys A_0)
	{
		return ArrayTools.Contains<int>(LEiRbylTDtVrpnaZskyeFoLSqqLb.wDMpIhsmGjTJRsfozLEtGAQqgQKaA, (int)A_0);
	}

	// Token: 0x040005B3 RID: 1459
	private const int hkpJcEbrZSnuTPNBorJoKcqjMJJW = 132;

	// Token: 0x040005B4 RID: 1460
	private const int aBiUCEJNklNymPfTDEONrkLLKngK = 256;

	// Token: 0x040005B5 RID: 1461
	private readonly object XCAOPnZLnfeZdKKCCCNTIPjYRccx = new object();

	// Token: 0x040005B6 RID: 1462
	private UpdateLoopDataSet<LEiRbylTDtVrpnaZskyeFoLSqqLb.wfvbjlcJzegfbgclDjsqZXArcoJeb> dpMGmWpMBiKDVyQlufObotnPuoyI;

	// Token: 0x040005B7 RID: 1463
	private HardwareControllerMap_Game ObnGqQGxGqJGpHRlVuMgsWHHAApDb;

	// Token: 0x040005B8 RID: 1464
	private bool FPkxLXnvERgoTXfJtErkgtRIbGgS;

	// Token: 0x040005B9 RID: 1465
	private int ugzGlDcwwnFFwafedkInFKVUzBFl;

	// Token: 0x040005BA RID: 1466
	private bool[] mcfFkoOhkGLPEWSSVYbmNqFsuzNt = new bool[256];

	// Token: 0x040005BB RID: 1467
	private readonly WwSVhacABKVkeCFnEObUUluxAROM FYADInJrhPhWtfCyrPBMzuojZZYjA = new WwSVhacABKVkeCFnEObUUluxAROM();

	// Token: 0x040005BC RID: 1468
	private bool BkpSKWZOdXpccUkbDwmCveOjDKLcA;

	// Token: 0x040005BD RID: 1469
	private static readonly int[] woodKbZjyrEuFqNWytdIVvKTSsbi;

	// Token: 0x040005BE RID: 1470
	private static readonly int FevLLaXfUbgFGanUGDOSsuhIiQvSA;

	// Token: 0x040005BF RID: 1471
	private bool HLZaJOtOtkYWffFzMhJwkprTXiGA;

	// Token: 0x040005C0 RID: 1472
	private static IntPtr cluTrzmjtcfHLRQwxCufYZLeJPOC;

	// Token: 0x040005C1 RID: 1473
	private static KastMvGkvyaNUEWReDndMRsEYrtnA.OhlkKcqKvcGknchIKaLAwnuZvNqj dfSGaJhzRewOmphtYoKutvgyojsfb = KastMvGkvyaNUEWReDndMRsEYrtnA.OhlkKcqKvcGknchIKaLAwnuZvNqj.United_States_English;

	// Token: 0x040005C2 RID: 1474
	private static readonly int[] ggGyWUwelRKozdWfPXKbdGKyyrs = (int[])Enum.GetValues(typeof(KastMvGkvyaNUEWReDndMRsEYrtnA.OhlkKcqKvcGknchIKaLAwnuZvNqj));

	// Token: 0x040005C3 RID: 1475
	private static Dictionary<int, Dictionary<int, KeyCode>> GMRcHFodMyRrAFqyETlOcoZthLXl = new Dictionary<int, Dictionary<int, KeyCode>>
	{
		{
			1033,
			new Dictionary<int, KeyCode>
			{
				{
					222,
					KeyCode.Quote
				},
				{
					188,
					KeyCode.Comma
				},
				{
					189,
					KeyCode.Minus
				},
				{
					190,
					KeyCode.Period
				},
				{
					191,
					KeyCode.Slash
				},
				{
					186,
					KeyCode.Semicolon
				},
				{
					187,
					KeyCode.Equals
				},
				{
					219,
					KeyCode.LeftBracket
				},
				{
					220,
					KeyCode.Backslash
				},
				{
					221,
					KeyCode.RightBracket
				},
				{
					192,
					KeyCode.BackQuote
				},
				{
					223,
					KeyCode.BackQuote
				}
			}
		},
		{
			2057,
			new Dictionary<int, KeyCode>
			{
				{
					223,
					KeyCode.BackQuote
				},
				{
					192,
					KeyCode.Quote
				}
			}
		},
		{
			1106,
			new Dictionary<int, KeyCode>
			{
				{
					223,
					KeyCode.BackQuote
				},
				{
					192,
					KeyCode.Quote
				}
			}
		},
		{
			1031,
			new Dictionary<int, KeyCode>
			{
				{
					219,
					KeyCode.Backslash
				},
				{
					221,
					KeyCode.BackQuote
				}
			}
		}
	};

	// Token: 0x040005C4 RID: 1476
	private static readonly int[] wDMpIhsmGjTJRsfozLEtGAQqgQKaA = new int[]
	{
		186,
		191,
		192,
		219,
		220,
		221,
		222,
		223,
		226,
		226,
		254,
		221,
		188,
		189,
		219,
		190,
		220,
		187,
		191,
		222,
		186,
		192
	};

	// Token: 0x02000087 RID: 135
	private class wfvbjlcJzegfbgclDjsqZXArcoJeb
	{
		// Token: 0x06000488 RID: 1160 RVA: 0x000137A9 File Offset: 0x000119A9
		public wfvbjlcJzegfbgclDjsqZXArcoJeb(UpdateLoopType A_1)
		{
			this.CvTMEzAQFJciFkaKOWJCuRbeNwzR = A_1;
			this.QxqHAFZtDDdBweduFgwnyOMjJoFB = new bool[132];
			this.FhSJHXiKVEgRFFOsBZPJDaoqfUQBb = new bool[132];
		}

		// Token: 0x06000489 RID: 1161 RVA: 0x00030AE4 File Offset: 0x0002ECE4
		public void rrxUWhGlKWAAFLYoFgezpPOrYPVi(WwSVhacABKVkeCFnEObUUluxAROM A_1)
		{
			int num = LEiRbylTDtVrpnaZskyeFoLSqqLb.ghzaJiDmnqHARurBoQqJwgsoLWBUA(A_1, LEiRbylTDtVrpnaZskyeFoLSqqLb.wfvbjlcJzegfbgclDjsqZXArcoJeb.YhicKNgJCnkkJPsUhyKHEaFFJwVeA);
			for (int i = 0; i < num; i++)
			{
				int num2 = (int)LEiRbylTDtVrpnaZskyeFoLSqqLb.wfvbjlcJzegfbgclDjsqZXArcoJeb.YhicKNgJCnkkJPsUhyKHEaFFJwVeA[i];
				if (num2 >= 0 && num2 < LEiRbylTDtVrpnaZskyeFoLSqqLb.woodKbZjyrEuFqNWytdIVvKTSsbi.Length)
				{
					KeyState xAAirmvFunTGYVBazPfKfnAjfGST = A_1.xAAirmvFunTGYVBazPfKfnAjfGST;
					bool flag = xAAirmvFunTGYVBazPfKfnAjfGST == KeyState.KeyFirst || xAAirmvFunTGYVBazPfKfnAjfGST == KeyState.SystemKeyDown;
					int num3 = LEiRbylTDtVrpnaZskyeFoLSqqLb.woodKbZjyrEuFqNWytdIVvKTSsbi[num2];
					int num4 = this.QxqHAFZtDDdBweduFgwnyOMjJoFB[num3] ? 1 : 0;
					this.QxqHAFZtDDdBweduFgwnyOMjJoFB[num3] = flag;
					if (num4 == 0 && flag)
					{
						this.FhSJHXiKVEgRFFOsBZPJDaoqfUQBb[num3] = true;
					}
				}
			}
		}

		// Token: 0x0600048A RID: 1162 RVA: 0x00030B70 File Offset: 0x0002ED70
		public void yaaHxNWjfcboPBWvcClGKJbXoTecA(ControllerDataUpdater A_1)
		{
			bool[] buttonValues = A_1.buttonValues;
			for (int i = 0; i < 132; i++)
			{
				buttonValues[i] = (this.QxqHAFZtDDdBweduFgwnyOMjJoFB[i] || this.FhSJHXiKVEgRFFOsBZPJDaoqfUQBb[i]);
			}
			this.mnRzosWNEFEWIYLrmYcaTcxCZhYd();
		}

		// Token: 0x0600048B RID: 1163 RVA: 0x000137D8 File Offset: 0x000119D8
		public void vDyHlAdDwgVhcmxlybidCcViMisJB()
		{
			this.mnRzosWNEFEWIYLrmYcaTcxCZhYd();
		}

		// Token: 0x0600048C RID: 1164 RVA: 0x000137E0 File Offset: 0x000119E0
		private void mnRzosWNEFEWIYLrmYcaTcxCZhYd()
		{
			if (this.BuvmaAzekaaYIZtILzEbAtmEZpOP == ReInput.absFrame)
			{
				return;
			}
			this.QLHcryaJuHdLKPXQdFuASWwoBvzgb();
			this.BuvmaAzekaaYIZtILzEbAtmEZpOP = ReInput.absFrame;
		}

		// Token: 0x0600048D RID: 1165 RVA: 0x00013801 File Offset: 0x00011A01
		public void QLHcryaJuHdLKPXQdFuASWwoBvzgb()
		{
			Array.Clear(this.FhSJHXiKVEgRFFOsBZPJDaoqfUQBb, 0, 132);
		}

		// Token: 0x0600048E RID: 1166 RVA: 0x00013814 File Offset: 0x00011A14
		public void BFvBkkfMokSKdpjkxySYhnTRPyfv()
		{
			Array.Clear(this.QxqHAFZtDDdBweduFgwnyOMjJoFB, 0, 132);
			Array.Clear(this.FhSJHXiKVEgRFFOsBZPJDaoqfUQBb, 0, 132);
		}

		// Token: 0x040005C5 RID: 1477
		private const int gAfhQmHGklNFjtZzAslWEzWtjtzeA = 2;

		// Token: 0x040005C6 RID: 1478
		private static readonly KeyCode[] YhicKNgJCnkkJPsUhyKHEaFFJwVeA = new KeyCode[2];

		// Token: 0x040005C7 RID: 1479
		private readonly UpdateLoopType CvTMEzAQFJciFkaKOWJCuRbeNwzR;

		// Token: 0x040005C8 RID: 1480
		private bool[] QxqHAFZtDDdBweduFgwnyOMjJoFB;

		// Token: 0x040005C9 RID: 1481
		private bool[] FhSJHXiKVEgRFFOsBZPJDaoqfUQBb;

		// Token: 0x040005CA RID: 1482
		private uint BuvmaAzekaaYIZtILzEbAtmEZpOP;

		// Token: 0x02000088 RID: 136
		private enum TZZGZkkoIFznpEPSNfRibhcLtxOC
		{
			// Token: 0x040005CC RID: 1484
			None,
			// Token: 0x040005CD RID: 1485
			Down,
			// Token: 0x040005CE RID: 1486
			Up
		}
	}
}
