using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

// Token: 0x02000089 RID: 137
internal class FdQbBsfCWcVHOnPrmheJzorKWKWz : IUnifiedMouseSource, IGetSetEnabled, IDisposable
{
	// Token: 0x06000490 RID: 1168 RVA: 0x00030BB4 File Offset: 0x0002EDB4
	public FdQbBsfCWcVHOnPrmheJzorKWKWz(UpdateLoopSetting A_1)
	{
		this.gXIdcEPnPklBCKnToAjgmBwvNADY();
		this.WKiQcxGdRzKbyZwytxXaqJLDmqSb = new FdQbBsfCWcVHOnPrmheJzorKWKWz.NkNdOWixlFsZjkacNuqNDiSZauWl(true, 2f);
		this.rnWUxvRUNrBmBPFIgmITeQZaNIIp = new UpdateLoopDataSet<FdQbBsfCWcVHOnPrmheJzorKWKWz.WyiElhHoHUIxZevUqGAeZIdYLAZBA>(A_1);
		using (TempListPool.TList<UpdateLoopType> tlist = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tlist.list;
			EnumConverter.ToUpdateLoopTypes(A_1, list);
			for (int i = 0; i < list.Count; i++)
			{
				this.rnWUxvRUNrBmBPFIgmITeQZaNIIp[i] = new FdQbBsfCWcVHOnPrmheJzorKWKWz.WyiElhHoHUIxZevUqGAeZIdYLAZBA(this.WKiQcxGdRzKbyZwytxXaqJLDmqSb, list[i]);
			}
		}
		this.XEgZicJubuwzioIHDKTTphaoLkWw = ReInput.IsInputAllowed(ControllerType.Mouse);
		ReInput.ApplicationFocusChangedEvent += this.GUayijPPDSczAHqkYFyfKuVSpkuX;
		ReInput.ApplicationPauseChangedEvent += this.ebxFvhKQVUZSYinoJFCmeheXdBMY;
		this.enabled = true;
		ReInput.EditorPauseChangedEvent += this.PNiqtEJyzGiSQKYbYsKgbcGMfezw;
		ReInput.TimeScalePauseChangedEvent += this.roUUOnTTYRDnrsjPfuECdSinwesb;
		ReInput.UpdateEndedEvent += this.iSDsjlgmgvCsaYUiweTJtQEffZOY;
	}

	// Token: 0x06000491 RID: 1169 RVA: 0x00013845 File Offset: 0x00011A45
	public void BjWURhNYGQxLjiyTcWeKsLsEBRsH(UpdateLoopType A_1)
	{
		this.rnWUxvRUNrBmBPFIgmITeQZaNIIp.SetUpdateLoop(A_1);
		this.WKiQcxGdRzKbyZwytxXaqJLDmqSb.RIufgNKuxUqFtgnxDotBTPUZlMgG();
		this.XEgZicJubuwzioIHDKTTphaoLkWw = ReInput.IsInputAllowed(ControllerType.Mouse);
	}

	// Token: 0x06000492 RID: 1170 RVA: 0x00030CC0 File Offset: 0x0002EEC0
	public void dbMAJtHMZhSYLdfMIlItxNFqwHRA(bbYYonPTzAJNYZIOnIOVBePssTCgA A_1)
	{
		if (!this.XEgZicJubuwzioIHDKTTphaoLkWw)
		{
			return;
		}
		using (this.FdKkERCykRBkgfkVMXyxSUNHDOls.Lock())
		{
			int count = this.rnWUxvRUNrBmBPFIgmITeQZaNIIp.Count;
			for (int i = 0; i < count; i++)
			{
				this.rnWUxvRUNrBmBPFIgmITeQZaNIIp[i].jQkrzooQaWWvWNzKwamKRKzjjCEU(A_1);
			}
		}
	}

	// Token: 0x06000493 RID: 1171 RVA: 0x0001386A File Offset: 0x00011A6A
	public void BLoaPXEUJgxNGQROySNFGrnAEVakA(bool A_1)
	{
		this.IFKenwbIuFkGycLLaoiGkMkImqXLB();
	}

	// Token: 0x06000494 RID: 1172 RVA: 0x00013872 File Offset: 0x00011A72
	public void BytJGpUFJwIgimYgIGbNpkfSpwIG(bool A_1)
	{
		if (this.gXIdcEPnPklBCKnToAjgmBwvNADY() < 0)
		{
			this.IFKenwbIuFkGycLLaoiGkMkImqXLB();
		}
	}

	// Token: 0x06000495 RID: 1173 RVA: 0x00030D28 File Offset: 0x0002EF28
	private int gXIdcEPnPklBCKnToAjgmBwvNADY()
	{
		int num = this.gvYDKtohermEmZwfHsfwiAFugCCiA;
		int num2;
		if (wOInxLKDewlatLvQaXlNWuUFKXeD.HWGuuLNggmCSsIIYWoKyBLiGGoXc(OiWGlufNbZAVpTSvEHgxGrekNlFFA.Mouse, out num2))
		{
			this.gvYDKtohermEmZwfHsfwiAFugCCiA = num2;
		}
		else
		{
			this.gvYDKtohermEmZwfHsfwiAFugCCiA = ((wLURyKQfpGlmweDJGGSrwwzrDUJFA.SUFYDWJiTvXccbltGKLJRExHXHKr(KastMvGkvyaNUEWReDndMRsEYrtnA.DIdYcHdxMapxwTECbFCLqUIvCzxI) == 0) ? 0 : 1);
		}
		return this.gvYDKtohermEmZwfHsfwiAFugCCiA - num;
	}

	// Token: 0x06000496 RID: 1174 RVA: 0x00013883 File Offset: 0x00011A83
	private void GUayijPPDSczAHqkYFyfKuVSpkuX(bool A_1)
	{
		this.XEgZicJubuwzioIHDKTTphaoLkWw = ReInput.IsInputAllowed(ControllerType.Mouse);
		if (!A_1 && !this.XEgZicJubuwzioIHDKTTphaoLkWw)
		{
			this.IFKenwbIuFkGycLLaoiGkMkImqXLB();
		}
	}

	// Token: 0x06000497 RID: 1175 RVA: 0x000138A2 File Offset: 0x00011AA2
	private void ebxFvhKQVUZSYinoJFCmeheXdBMY(bool A_1)
	{
		this.XEgZicJubuwzioIHDKTTphaoLkWw = ReInput.IsInputAllowed(ControllerType.Mouse);
		if (!this.XEgZicJubuwzioIHDKTTphaoLkWw)
		{
			this.IFKenwbIuFkGycLLaoiGkMkImqXLB();
		}
	}

	// Token: 0x06000498 RID: 1176 RVA: 0x000116E9 File Offset: 0x0000F8E9
	private void PNiqtEJyzGiSQKYbYsKgbcGMfezw(bool A_1)
	{
	}

	// Token: 0x06000499 RID: 1177 RVA: 0x00030D70 File Offset: 0x0002EF70
	private void roUUOnTTYRDnrsjPfuECdSinwesb(bool A_1)
	{
		if ((ReInput.configVars.updateLoop & UpdateLoopSetting.FixedUpdate) == UpdateLoopSetting.None)
		{
			return;
		}
		this.XEgZicJubuwzioIHDKTTphaoLkWw = ReInput.IsInputAllowed(ControllerType.Mouse);
		using (this.FdKkERCykRBkgfkVMXyxSUNHDOls.Lock())
		{
			this.rnWUxvRUNrBmBPFIgmITeQZaNIIp[this.rnWUxvRUNrBmBPFIgmITeQZaNIIp.fixedUpdateSetIndex].ipZCtoKlqqcMClcEWCvaRBvtGdNA();
		}
	}

	// Token: 0x0600049A RID: 1178 RVA: 0x00030DDC File Offset: 0x0002EFDC
	private void iSDsjlgmgvCsaYUiweTJtQEffZOY(UpdateLoopType A_1)
	{
		using (this.FdKkERCykRBkgfkVMXyxSUNHDOls.Lock())
		{
			this.rnWUxvRUNrBmBPFIgmITeQZaNIIp.Get(A_1).YYQcNLisrFfGKgHdyOqGoNMzMCUEb();
		}
	}

	// Token: 0x0600049B RID: 1179 RVA: 0x00030E24 File Offset: 0x0002F024
	private void IFKenwbIuFkGycLLaoiGkMkImqXLB()
	{
		using (this.FdKkERCykRBkgfkVMXyxSUNHDOls.Lock())
		{
			int count = this.rnWUxvRUNrBmBPFIgmITeQZaNIIp.Count;
			for (int i = 0; i < count; i++)
			{
				this.rnWUxvRUNrBmBPFIgmITeQZaNIIp[i].rmRUeedEQYwDLAtuprRGLgDeAtUb();
			}
		}
	}

	// Token: 0x170000DE RID: 222
	// (get) Token: 0x0600049C RID: 1180 RVA: 0x000138BE File Offset: 0x00011ABE
	// (set) Token: 0x0600049D RID: 1181 RVA: 0x000138C6 File Offset: 0x00011AC6
	public bool enabled
	{
		get
		{
			return this.ztYmlrXehLebmtXjuRvtYPvRlwxo;
		}
		set
		{
			if (this.ztYmlrXehLebmtXjuRvtYPvRlwxo == value)
			{
				return;
			}
			this.ztYmlrXehLebmtXjuRvtYPvRlwxo = value;
			this.Clear();
			ThreadSafeUnityInput.mouse.Monitor(value);
		}
	}

	// Token: 0x170000DF RID: 223
	// (get) Token: 0x0600049E RID: 1182 RVA: 0x00011BB6 File Offset: 0x0000FDB6
	public InputSource inputSource
	{
		get
		{
			return InputSource.RawInput;
		}
	}

	// Token: 0x170000E0 RID: 224
	// (get) Token: 0x0600049F RID: 1183 RVA: 0x000138EA File Offset: 0x00011AEA
	public HardwareControllerMap_Game hardwareMap
	{
		get
		{
			if (this.rjmDysjgSRhMgytlvKkwiEaabpKu == null)
			{
				this.rjmDysjgSRhMgytlvKkwiEaabpKu = this.DeYtUBWNYgQlcAjjftWFhIQaaVmr();
			}
			return this.rjmDysjgSRhMgytlvKkwiEaabpKu;
		}
	}

	// Token: 0x170000E1 RID: 225
	// (get) Token: 0x060004A0 RID: 1184 RVA: 0x00011BB6 File Offset: 0x0000FDB6
	public int buttonCount
	{
		get
		{
			return 5;
		}
	}

	// Token: 0x170000E2 RID: 226
	// (get) Token: 0x060004A1 RID: 1185 RVA: 0x00013906 File Offset: 0x00011B06
	public int axisCount
	{
		get
		{
			return 4;
		}
	}

	// Token: 0x170000E3 RID: 227
	// (get) Token: 0x060004A2 RID: 1186 RVA: 0x00030E84 File Offset: 0x0002F084
	public Vector2 mousePosition
	{
		get
		{
			if (!this.ztYmlrXehLebmtXjuRvtYPvRlwxo)
			{
				return default(Vector2);
			}
			return ThreadSafeUnityInput.mouse.mousePosition;
		}
	}

	// Token: 0x170000E4 RID: 228
	// (get) Token: 0x060004A3 RID: 1187 RVA: 0x000116EB File Offset: 0x0000F8EB
	public Controller.Extension controllerExtension
	{
		get
		{
			return null;
		}
	}

	// Token: 0x060004A4 RID: 1188 RVA: 0x00013909 File Offset: 0x00011B09
	public void UpdateInputData(ControllerDataUpdater dataUpdater)
	{
		this.rnWUxvRUNrBmBPFIgmITeQZaNIIp.Current.cqtXDSEvlMGrLWYuMFuSaDGhOHom(dataUpdater);
	}

	// Token: 0x060004A5 RID: 1189 RVA: 0x0001386A File Offset: 0x00011A6A
	public void Clear()
	{
		this.IFKenwbIuFkGycLLaoiGkMkImqXLB();
	}

	// Token: 0x060004A6 RID: 1190 RVA: 0x00030EB4 File Offset: 0x0002F0B4
	private HardwareControllerMap_Game DeYtUBWNYgQlcAjjftWFhIQaaVmr()
	{
		ControllerElementIdentifier[] array = new ControllerElementIdentifier[Consts.rawInputUnifiedMouseElementIdentifiers.Count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = new ControllerElementIdentifier(Consts.rawInputUnifiedMouseElementIdentifiers[i]);
		}
		int[] array2 = new int[5];
		int[] array3 = new int[4];
		int num = 0;
		int num2 = 0;
		for (int j = 0; j < array.Length; j++)
		{
			if (array[j].elementType == ControllerElementType.Axis)
			{
				array3[num2++] = array[j].id;
			}
			else if (array[j].elementType == ControllerElementType.Button)
			{
				array2[num++] = array[j].id;
			}
		}
		AxisCalibrationData[] array4 = new AxisCalibrationData[4];
		AxisRange[] array5 = new AxisRange[4];
		HardwareAxisInfo[] array6 = new HardwareAxisInfo[4];
		HardwareButtonInfo[] array7 = new HardwareButtonInfo[5];
		for (int k = 0; k < 4; k++)
		{
			array4[k] = AxisCalibrationData.Raw;
			array5[k] = AxisRange.Full;
			float num3;
			if (k <= 1)
			{
				num3 = 100f;
			}
			else
			{
				num3 = 2f;
			}
			array6[k] = new HardwareAxisInfo(AxisCoordinateMode.Relative, false, num3, SpecialAxisType.None);
		}
		for (int l = 0; l < 5; l++)
		{
			array7[l] = new HardwareButtonInfo();
		}
		return new HardwareControllerMap_Game("Mouse", default(HardwareControllerMapIdentifier), array, array2, array3, array4, array5, array6, array7, null);
	}

	// Token: 0x060004A7 RID: 1191 RVA: 0x0001391C File Offset: 0x00011B1C
	public void Dispose()
	{
		this.uHwEmqNCUCkpikyjXpANAgkVTlHw(true);
		GC.SuppressFinalize(this);
	}

	// Token: 0x060004A8 RID: 1192 RVA: 0x00030FFC File Offset: 0x0002F1FC
	protected virtual void yaTebvmozyBUJJxLtCHxiApPLRzz()
	{
		try
		{
			this.uHwEmqNCUCkpikyjXpANAgkVTlHw(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	// Token: 0x060004A9 RID: 1193 RVA: 0x0003102C File Offset: 0x0002F22C
	protected virtual void uHwEmqNCUCkpikyjXpANAgkVTlHw(bool A_1)
	{
		if (this.NJvcfnbTVFcjtmeYoEXQdFCaNqBAA)
		{
			return;
		}
		ReInput.ApplicationFocusChangedEvent -= this.GUayijPPDSczAHqkYFyfKuVSpkuX;
		ReInput.ApplicationPauseChangedEvent -= this.ebxFvhKQVUZSYinoJFCmeheXdBMY;
		ReInput.EditorPauseChangedEvent -= this.PNiqtEJyzGiSQKYbYsKgbcGMfezw;
		ReInput.TimeScalePauseChangedEvent -= this.roUUOnTTYRDnrsjPfuECdSinwesb;
		ReInput.UpdateEndedEvent -= this.iSDsjlgmgvCsaYUiweTJtQEffZOY;
		if (A_1 && this.ztYmlrXehLebmtXjuRvtYPvRlwxo)
		{
			ThreadSafeUnityInput.mouse.Monitor(false);
		}
		this.NJvcfnbTVFcjtmeYoEXQdFCaNqBAA = true;
	}

	// Token: 0x040005CF RID: 1487
	private const int kPkKZSJiZRGjeFiKMmefZbGAoBvN = 5;

	// Token: 0x040005D0 RID: 1488
	private const int gFMcKbZsiHIIMNqgfuRXqFfpUrFx = 4;

	// Token: 0x040005D1 RID: 1489
	private readonly SpinLock FdKkERCykRBkgfkVMXyxSUNHDOls = new SpinLock();

	// Token: 0x040005D2 RID: 1490
	private UpdateLoopDataSet<FdQbBsfCWcVHOnPrmheJzorKWKWz.WyiElhHoHUIxZevUqGAeZIdYLAZBA> rnWUxvRUNrBmBPFIgmITeQZaNIIp;

	// Token: 0x040005D3 RID: 1491
	private HardwareControllerMap_Game rjmDysjgSRhMgytlvKkwiEaabpKu;

	// Token: 0x040005D4 RID: 1492
	private FdQbBsfCWcVHOnPrmheJzorKWKWz.NkNdOWixlFsZjkacNuqNDiSZauWl WKiQcxGdRzKbyZwytxXaqJLDmqSb;

	// Token: 0x040005D5 RID: 1493
	private bool XEgZicJubuwzioIHDKTTphaoLkWw;

	// Token: 0x040005D6 RID: 1494
	private int gvYDKtohermEmZwfHsfwiAFugCCiA;

	// Token: 0x040005D7 RID: 1495
	private bool ztYmlrXehLebmtXjuRvtYPvRlwxo;

	// Token: 0x040005D8 RID: 1496
	private const bool QfNiBKpDjtypUSFhMjdUUQEWEUcw = true;

	// Token: 0x040005D9 RID: 1497
	private const float PdWZZlfiQofYmkwRfKlTaHchCiGx = 2f;

	// Token: 0x040005DA RID: 1498
	private bool NJvcfnbTVFcjtmeYoEXQdFCaNqBAA;

	// Token: 0x0200008A RID: 138
	private class WyiElhHoHUIxZevUqGAeZIdYLAZBA
	{
		// Token: 0x060004AA RID: 1194 RVA: 0x0001392B File Offset: 0x00011B2B
		public WyiElhHoHUIxZevUqGAeZIdYLAZBA(FdQbBsfCWcVHOnPrmheJzorKWKWz.NkNdOWixlFsZjkacNuqNDiSZauWl A_1, UpdateLoopType A_2)
		{
			this.zKmrVtQeKuxmxwCYDegsqbZCsdJj = A_1;
			this.bgrNoLdEvZcFwdFANPwZGZYITqjjA = A_2;
			this.FKjNXyYeESTMRTBqELrtZKiIsyiE = new bool[5];
			this.zZtrcWWqBbVqPGspciTQvmetmoCx = new bool[5];
		}

		// Token: 0x060004AB RID: 1195 RVA: 0x000310B4 File Offset: 0x0002F2B4
		public void jQkrzooQaWWvWNzKwamKRKzjjCEU(bbYYonPTzAJNYZIOnIOVBePssTCgA A_1)
		{
			oktnYxWofnWBmqZNTHGZvSKFvLog oktnYxWofnWBmqZNTHGZvSKFvLog = A_1.QHGlrInHOpABvQcBNQNgsjmngHFjA;
			if (oktnYxWofnWBmqZNTHGZvSKFvLog != oktnYxWofnWBmqZNTHGZvSKFvLog.None)
			{
				if ((oktnYxWofnWBmqZNTHGZvSKFvLog & oktnYxWofnWBmqZNTHGZvSKFvLog.LeftButtonDown) != oktnYxWofnWBmqZNTHGZvSKFvLog.None || (oktnYxWofnWBmqZNTHGZvSKFvLog & oktnYxWofnWBmqZNTHGZvSKFvLog.RightButtonDown) != oktnYxWofnWBmqZNTHGZvSKFvLog.None)
				{
					IntPtr intPtr = wLURyKQfpGlmweDJGGSrwwzrDUJFA.NcNUORJAUceCejbICLHRcPTLEkhIb();
					if (wLURyKQfpGlmweDJGGSrwwzrDUJFA.kHdMXluFWqNCISYjLawcyAFHcKzW() == intPtr && FdQbBsfCWcVHOnPrmheJzorKWKWz.WyiElhHoHUIxZevUqGAeZIdYLAZBA.KhiKvrrKnxozHDEtexbkesGhbBBd(intPtr))
					{
						oktnYxWofnWBmqZNTHGZvSKFvLog &= ~oktnYxWofnWBmqZNTHGZvSKFvLog.LeftButtonDown;
						oktnYxWofnWBmqZNTHGZvSKFvLog &= ~oktnYxWofnWBmqZNTHGZvSKFvLog.RightButtonDown;
					}
				}
				int num = (int)oktnYxWofnWBmqZNTHGZvSKFvLog;
				if (this.zKmrVtQeKuxmxwCYDegsqbZCsdJj.CBeFMhRCCqiuiCvbIclYclKjRCfCc && this.zKmrVtQeKuxmxwCYDegsqbZCsdJj.ZNLMdZBSkPWbOsrZxpCHeeopfiBD)
				{
					this.AjxMaOrdfQlqoHZYhppSjqTeApVP(1, num, 1, 2);
					this.AjxMaOrdfQlqoHZYhppSjqTeApVP(0, num, 4, 8);
				}
				else
				{
					this.AjxMaOrdfQlqoHZYhppSjqTeApVP(0, num, 1, 2);
					this.AjxMaOrdfQlqoHZYhppSjqTeApVP(1, num, 4, 8);
				}
				this.AjxMaOrdfQlqoHZYhppSjqTeApVP(2, num, 16, 32);
				this.AjxMaOrdfQlqoHZYhppSjqTeApVP(3, num, 64, 128);
				this.AjxMaOrdfQlqoHZYhppSjqTeApVP(4, num, 256, 512);
			}
			this.ZHFVEjSPBRVZLAUieRpRouhyLYtJ = A_1.PkpcxeQMpDWSzoEKlJQYdwdmdxTg;
			this.TdiDyBtOfIwWtbKgMheuFixpIkm = A_1.fneQAbvuDCWrMEXCjcusqDaPBlZZ;
			pGGlAsbPKuYuxJnnqAztGzMsNKyBA vkScgaHjvAKzwmoFwSkKfPuLulGab = this.VkScgaHjvAKzwmoFwSkKfPuLulGab;
			this.VkScgaHjvAKzwmoFwSkKfPuLulGab = A_1.kPYrxBeGByjjvhsrslJqWbdgAIjg;
			if (this.VkScgaHjvAKzwmoFwSkKfPuLulGab != vkScgaHjvAKzwmoFwSkKfPuLulGab)
			{
				this.VpIXGxGJdMvjUqaevcXIsIyWBIqhA = false;
			}
			if (this.VkScgaHjvAKzwmoFwSkKfPuLulGab == pGGlAsbPKuYuxJnnqAztGzMsNKyBA.MoveRelative)
			{
				this.UoMCwnmuSTrfsdlBvellOpEkGTyO += (float)A_1.iqnKeRujxLqGVMrsXfFUKcPwNnrR * 0.5f;
				this.fdKfLEbxCyIyqsxoUkmKdemTezoMA += (float)A_1.DYhtGekDpIEKHaHSwojOxOydGkdp * 0.5f * -1f;
			}
			else if ((this.VkScgaHjvAKzwmoFwSkKfPuLulGab & pGGlAsbPKuYuxJnnqAztGzMsNKyBA.MoveAbsolute) != pGGlAsbPKuYuxJnnqAztGzMsNKyBA.MoveRelative)
			{
				bool flag = (this.VkScgaHjvAKzwmoFwSkKfPuLulGab & pGGlAsbPKuYuxJnnqAztGzMsNKyBA.VirtualDesktop) > pGGlAsbPKuYuxJnnqAztGzMsNKyBA.MoveRelative;
				int num2 = wLURyKQfpGlmweDJGGSrwwzrDUJFA.SUFYDWJiTvXccbltGKLJRExHXHKr(flag ? KastMvGkvyaNUEWReDndMRsEYrtnA.HIjrMDaGHIutRNgOUjZPivVrqcTaA : KastMvGkvyaNUEWReDndMRsEYrtnA.xaYPJqiVMzTAcYLhhdDGmdeURUb);
				int num3 = wLURyKQfpGlmweDJGGSrwwzrDUJFA.SUFYDWJiTvXccbltGKLJRExHXHKr(flag ? KastMvGkvyaNUEWReDndMRsEYrtnA.QhCgXnxDPUfHkenpIhFPhMFJtPhQA : KastMvGkvyaNUEWReDndMRsEYrtnA.DvJmwVlRDafwZYZxmoJwbcPPJqTE);
				int num4 = (int)((float)A_1.iqnKeRujxLqGVMrsXfFUKcPwNnrR / 65535f * (float)num2);
				int num5 = (int)((65535f - (float)A_1.DYhtGekDpIEKHaHSwojOxOydGkdp) / 65535f * (float)num3);
				if (!this.VpIXGxGJdMvjUqaevcXIsIyWBIqhA)
				{
					this.ocAYmloeXikLIuMEXuEEyRVsDtAT = num4;
					this.BoBGblcVAtUKKbtCNUgbypgTuqpQ = num5;
					this.VpIXGxGJdMvjUqaevcXIsIyWBIqhA = true;
				}
				this.UoMCwnmuSTrfsdlBvellOpEkGTyO += (float)(num4 - this.ocAYmloeXikLIuMEXuEEyRVsDtAT);
				this.fdKfLEbxCyIyqsxoUkmKdemTezoMA += (float)(num5 - this.BoBGblcVAtUKKbtCNUgbypgTuqpQ);
				this.ocAYmloeXikLIuMEXuEEyRVsDtAT = num4;
				this.BoBGblcVAtUKKbtCNUgbypgTuqpQ = num5;
			}
			else
			{
				this.UoMCwnmuSTrfsdlBvellOpEkGTyO = (float)A_1.iqnKeRujxLqGVMrsXfFUKcPwNnrR;
				this.fdKfLEbxCyIyqsxoUkmKdemTezoMA = (float)A_1.DYhtGekDpIEKHaHSwojOxOydGkdp;
			}
			if (A_1.DZhfQOAuxqpuksmXsaTBQkcHHYVpA != 0)
			{
				int num6 = (MathTools.Abs(A_1.DZhfQOAuxqpuksmXsaTBQkcHHYVpA) < 120) ? MathTools.Sign(A_1.DZhfQOAuxqpuksmXsaTBQkcHHYVpA) : (A_1.DZhfQOAuxqpuksmXsaTBQkcHHYVpA / 120);
				if ((oktnYxWofnWBmqZNTHGZvSKFvLog & oktnYxWofnWBmqZNTHGZvSKFvLog.MouseWheel) != oktnYxWofnWBmqZNTHGZvSKFvLog.None)
				{
					this.dddTOBboyisxzxSiUiedVWxkeRUQ += (float)num6;
					return;
				}
				if ((oktnYxWofnWBmqZNTHGZvSKFvLog & (oktnYxWofnWBmqZNTHGZvSKFvLog)2048) != oktnYxWofnWBmqZNTHGZvSKFvLog.None)
				{
					this.LfoqustLrIbDxGQedvFopiOxsGObA += (float)num6;
				}
			}
		}

		// Token: 0x060004AC RID: 1196 RVA: 0x00031340 File Offset: 0x0002F540
		public void cqtXDSEvlMGrLWYuMFuSaDGhOHom(ControllerDataUpdater A_1)
		{
			float[] axisValues = A_1.axisValues;
			axisValues[0] = this.UoMCwnmuSTrfsdlBvellOpEkGTyO;
			axisValues[1] = this.fdKfLEbxCyIyqsxoUkmKdemTezoMA;
			axisValues[2] = this.dddTOBboyisxzxSiUiedVWxkeRUQ;
			axisValues[3] = this.LfoqustLrIbDxGQedvFopiOxsGObA;
			bool[] buttonValues = A_1.buttonValues;
			for (int i = 0; i < 5; i++)
			{
				buttonValues[i] = (this.FKjNXyYeESTMRTBqELrtZKiIsyiE[i] || this.zZtrcWWqBbVqPGspciTQvmetmoCx[i]);
			}
			this.mZApsXXyNJjqNGpJSFUofXLWRCqrA();
		}

		// Token: 0x060004AD RID: 1197 RVA: 0x00013959 File Offset: 0x00011B59
		public void YYQcNLisrFfGKgHdyOqGoNMzMCUEb()
		{
			this.mZApsXXyNJjqNGpJSFUofXLWRCqrA();
		}

		// Token: 0x060004AE RID: 1198 RVA: 0x00013961 File Offset: 0x00011B61
		private void mZApsXXyNJjqNGpJSFUofXLWRCqrA()
		{
			if (this.HWczTKeniPoQNwqXZOmyrTAfCBuN == ReInput.absFrame)
			{
				return;
			}
			this.ipZCtoKlqqcMClcEWCvaRBvtGdNA();
			this.HWczTKeniPoQNwqXZOmyrTAfCBuN = ReInput.absFrame;
		}

		// Token: 0x060004AF RID: 1199 RVA: 0x000313A8 File Offset: 0x0002F5A8
		public void rmRUeedEQYwDLAtuprRGLgDeAtUb()
		{
			this.UoMCwnmuSTrfsdlBvellOpEkGTyO = 0f;
			this.fdKfLEbxCyIyqsxoUkmKdemTezoMA = 0f;
			this.TdiDyBtOfIwWtbKgMheuFixpIkm = 0U;
			this.VkScgaHjvAKzwmoFwSkKfPuLulGab = pGGlAsbPKuYuxJnnqAztGzMsNKyBA.MoveRelative;
			this.dddTOBboyisxzxSiUiedVWxkeRUQ = 0f;
			this.LfoqustLrIbDxGQedvFopiOxsGObA = 0f;
			Array.Clear(this.FKjNXyYeESTMRTBqELrtZKiIsyiE, 0, 5);
			Array.Clear(this.zZtrcWWqBbVqPGspciTQvmetmoCx, 0, 5);
			this.VpIXGxGJdMvjUqaevcXIsIyWBIqhA = false;
		}

		// Token: 0x060004B0 RID: 1200 RVA: 0x00013982 File Offset: 0x00011B82
		public void ipZCtoKlqqcMClcEWCvaRBvtGdNA()
		{
			this.UoMCwnmuSTrfsdlBvellOpEkGTyO = 0f;
			this.fdKfLEbxCyIyqsxoUkmKdemTezoMA = 0f;
			this.dddTOBboyisxzxSiUiedVWxkeRUQ = 0f;
			this.LfoqustLrIbDxGQedvFopiOxsGObA = 0f;
			Array.Clear(this.zZtrcWWqBbVqPGspciTQvmetmoCx, 0, 5);
		}

		// Token: 0x060004B1 RID: 1201 RVA: 0x00031410 File Offset: 0x0002F610
		private void AjxMaOrdfQlqoHZYhppSjqTeApVP(int A_1, int A_2, int A_3, int A_4)
		{
			FdQbBsfCWcVHOnPrmheJzorKWKWz.WyiElhHoHUIxZevUqGAeZIdYLAZBA.DMGcvfcQUwPZFNbtWmTqkndrViOF dmgcvfcQUwPZFNbtWmTqkndrViOF = FdQbBsfCWcVHOnPrmheJzorKWKWz.WyiElhHoHUIxZevUqGAeZIdYLAZBA.AdeqFoGFhGDGJugKcvBMjFlArPrM(A_2, A_3, A_4);
			if (this.FKjNXyYeESTMRTBqELrtZKiIsyiE[A_1])
			{
				if (dmgcvfcQUwPZFNbtWmTqkndrViOF == FdQbBsfCWcVHOnPrmheJzorKWKWz.WyiElhHoHUIxZevUqGAeZIdYLAZBA.DMGcvfcQUwPZFNbtWmTqkndrViOF.Up || dmgcvfcQUwPZFNbtWmTqkndrViOF == FdQbBsfCWcVHOnPrmheJzorKWKWz.WyiElhHoHUIxZevUqGAeZIdYLAZBA.DMGcvfcQUwPZFNbtWmTqkndrViOF.DownAndUp)
				{
					this.FKjNXyYeESTMRTBqELrtZKiIsyiE[A_1] = false;
				}
			}
			else if (dmgcvfcQUwPZFNbtWmTqkndrViOF == FdQbBsfCWcVHOnPrmheJzorKWKWz.WyiElhHoHUIxZevUqGAeZIdYLAZBA.DMGcvfcQUwPZFNbtWmTqkndrViOF.Down)
			{
				this.FKjNXyYeESTMRTBqELrtZKiIsyiE[A_1] = true;
			}
			if (dmgcvfcQUwPZFNbtWmTqkndrViOF == FdQbBsfCWcVHOnPrmheJzorKWKWz.WyiElhHoHUIxZevUqGAeZIdYLAZBA.DMGcvfcQUwPZFNbtWmTqkndrViOF.Down || dmgcvfcQUwPZFNbtWmTqkndrViOF == FdQbBsfCWcVHOnPrmheJzorKWKWz.WyiElhHoHUIxZevUqGAeZIdYLAZBA.DMGcvfcQUwPZFNbtWmTqkndrViOF.DownAndUp)
			{
				this.zZtrcWWqBbVqPGspciTQvmetmoCx[A_1] = true;
			}
		}

		// Token: 0x060004B2 RID: 1202 RVA: 0x000139BD File Offset: 0x00011BBD
		private static FdQbBsfCWcVHOnPrmheJzorKWKWz.WyiElhHoHUIxZevUqGAeZIdYLAZBA.DMGcvfcQUwPZFNbtWmTqkndrViOF AdeqFoGFhGDGJugKcvBMjFlArPrM(int A_0, int A_1, int A_2)
		{
			if ((A_0 & A_1) == A_1)
			{
				if ((A_0 & A_2) == A_2)
				{
					return FdQbBsfCWcVHOnPrmheJzorKWKWz.WyiElhHoHUIxZevUqGAeZIdYLAZBA.DMGcvfcQUwPZFNbtWmTqkndrViOF.DownAndUp;
				}
				return FdQbBsfCWcVHOnPrmheJzorKWKWz.WyiElhHoHUIxZevUqGAeZIdYLAZBA.DMGcvfcQUwPZFNbtWmTqkndrViOF.Down;
			}
			else
			{
				if ((A_0 & A_2) == A_2)
				{
					return FdQbBsfCWcVHOnPrmheJzorKWKWz.WyiElhHoHUIxZevUqGAeZIdYLAZBA.DMGcvfcQUwPZFNbtWmTqkndrViOF.Up;
				}
				return FdQbBsfCWcVHOnPrmheJzorKWKWz.WyiElhHoHUIxZevUqGAeZIdYLAZBA.DMGcvfcQUwPZFNbtWmTqkndrViOF.None;
			}
		}

		// Token: 0x060004B3 RID: 1203 RVA: 0x00031464 File Offset: 0x0002F664
		private static bool KhiKvrrKnxozHDEtexbkesGhbBBd(IntPtr A_0)
		{
			if (wLURyKQfpGlmweDJGGSrwwzrDUJFA.sFADiWsGqNrUaelLcePntrZxCOnR(0U, false, 0U) == IntPtr.Zero)
			{
				return false;
			}
			AnsNkVbhRzcaJCQtkxaNnQKKVYeU ansNkVbhRzcaJCQtkxaNnQKKVYeU;
			if (!wLURyKQfpGlmweDJGGSrwwzrDUJFA.NzMTTeEQAagKoEjRbneeFzNYlvSjA(A_0, out ansNkVbhRzcaJCQtkxaNnQKKVYeU))
			{
				return false;
			}
			AnsNkVbhRzcaJCQtkxaNnQKKVYeU ansNkVbhRzcaJCQtkxaNnQKKVYeU2;
			if (!wLURyKQfpGlmweDJGGSrwwzrDUJFA.RdrXZAoQXIpNKUMeMBicLsyQbdFm(out ansNkVbhRzcaJCQtkxaNnQKKVYeU2))
			{
				return false;
			}
			VhfyIGBvPvfSsIHuXvNsminyDaTdA vhfyIGBvPvfSsIHuXvNsminyDaTdA;
			if (!wLURyKQfpGlmweDJGGSrwwzrDUJFA.QAyepktPPBGtJJwunOSujMubbIuXA(A_0, out vhfyIGBvPvfSsIHuXvNsminyDaTdA))
			{
				return false;
			}
			int num = ansNkVbhRzcaJCQtkxaNnQKKVYeU2.HUKobsycsBxqxlQHKwQlaViuEDne - ansNkVbhRzcaJCQtkxaNnQKKVYeU.HUKobsycsBxqxlQHKwQlaViuEDne;
			int num2 = ansNkVbhRzcaJCQtkxaNnQKKVYeU2.kMAQjWopklEvquqxaEtmGQbcVarjA - ansNkVbhRzcaJCQtkxaNnQKKVYeU.kMAQjWopklEvquqxaEtmGQbcVarjA;
			VhfyIGBvPvfSsIHuXvNsminyDaTdA vhfyIGBvPvfSsIHuXvNsminyDaTdA2;
			return (num < 0 || num2 < 0 || num > vhfyIGBvPvfSsIHuXvNsminyDaTdA.lzeuksKPOKpFyMIsphnZSiPwsYWN || num2 > vhfyIGBvPvfSsIHuXvNsminyDaTdA.ydOEtkKYaUPnblUFXLvVEKtFvDMCA) && wLURyKQfpGlmweDJGGSrwwzrDUJFA.sJIqeXmLRzZwVRApCkmnpmSWmWGM(A_0, out vhfyIGBvPvfSsIHuXvNsminyDaTdA2) && (ansNkVbhRzcaJCQtkxaNnQKKVYeU2.HUKobsycsBxqxlQHKwQlaViuEDne >= vhfyIGBvPvfSsIHuXvNsminyDaTdA2.YiJNrytpHdgrkgJqWwxQgnTYocLdb && ansNkVbhRzcaJCQtkxaNnQKKVYeU2.HUKobsycsBxqxlQHKwQlaViuEDne <= vhfyIGBvPvfSsIHuXvNsminyDaTdA2.lzeuksKPOKpFyMIsphnZSiPwsYWN && ansNkVbhRzcaJCQtkxaNnQKKVYeU2.kMAQjWopklEvquqxaEtmGQbcVarjA >= vhfyIGBvPvfSsIHuXvNsminyDaTdA2.KVsojSkDBlBQVbcMdycCgLpRhdugb) && ansNkVbhRzcaJCQtkxaNnQKKVYeU2.kMAQjWopklEvquqxaEtmGQbcVarjA <= vhfyIGBvPvfSsIHuXvNsminyDaTdA2.ydOEtkKYaUPnblUFXLvVEKtFvDMCA;
		}

		// Token: 0x040005DB RID: 1499
		private const int BuyPpRbwjlJsXjniLxLFdFflRbSX = 120;

		// Token: 0x040005DC RID: 1500
		private const int rTPwSBruZfhcMcpGllHNBqsGagnk = 2048;

		// Token: 0x040005DD RID: 1501
		public readonly UpdateLoopType bgrNoLdEvZcFwdFANPwZGZYITqjjA;

		// Token: 0x040005DE RID: 1502
		public uint ZHFVEjSPBRVZLAUieRpRouhyLYtJ;

		// Token: 0x040005DF RID: 1503
		public uint TdiDyBtOfIwWtbKgMheuFixpIkm;

		// Token: 0x040005E0 RID: 1504
		public pGGlAsbPKuYuxJnnqAztGzMsNKyBA VkScgaHjvAKzwmoFwSkKfPuLulGab;

		// Token: 0x040005E1 RID: 1505
		public float UoMCwnmuSTrfsdlBvellOpEkGTyO;

		// Token: 0x040005E2 RID: 1506
		public float fdKfLEbxCyIyqsxoUkmKdemTezoMA;

		// Token: 0x040005E3 RID: 1507
		public float dddTOBboyisxzxSiUiedVWxkeRUQ;

		// Token: 0x040005E4 RID: 1508
		public float LfoqustLrIbDxGQedvFopiOxsGObA;

		// Token: 0x040005E5 RID: 1509
		private bool[] FKjNXyYeESTMRTBqELrtZKiIsyiE;

		// Token: 0x040005E6 RID: 1510
		private bool[] zZtrcWWqBbVqPGspciTQvmetmoCx;

		// Token: 0x040005E7 RID: 1511
		private FdQbBsfCWcVHOnPrmheJzorKWKWz.NkNdOWixlFsZjkacNuqNDiSZauWl zKmrVtQeKuxmxwCYDegsqbZCsdJj;

		// Token: 0x040005E8 RID: 1512
		private uint HWczTKeniPoQNwqXZOmyrTAfCBuN;

		// Token: 0x040005E9 RID: 1513
		private int ocAYmloeXikLIuMEXuEEyRVsDtAT;

		// Token: 0x040005EA RID: 1514
		private int BoBGblcVAtUKKbtCNUgbypgTuqpQ;

		// Token: 0x040005EB RID: 1515
		private bool VpIXGxGJdMvjUqaevcXIsIyWBIqhA;

		// Token: 0x0200008B RID: 139
		private enum DMGcvfcQUwPZFNbtWmTqkndrViOF
		{
			// Token: 0x040005ED RID: 1517
			None,
			// Token: 0x040005EE RID: 1518
			Down,
			// Token: 0x040005EF RID: 1519
			Up,
			// Token: 0x040005F0 RID: 1520
			DownAndUp
		}
	}

	// Token: 0x0200008C RID: 140
	private class NkNdOWixlFsZjkacNuqNDiSZauWl
	{
		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x060004B4 RID: 1204 RVA: 0x000139D8 File Offset: 0x00011BD8
		// (set) Token: 0x060004B5 RID: 1205 RVA: 0x000139E0 File Offset: 0x00011BE0
		public bool CBeFMhRCCqiuiCvbIclYclKjRCfCc
		{
			get
			{
				return this.jtvlqqauuflImgsvtFeiPfEbyugt;
			}
			set
			{
				if (value == this.jtvlqqauuflImgsvtFeiPfEbyugt)
				{
					return;
				}
				this.nlDDgZsOBUBWbYNeTlPYREPsmooE(true);
			}
		}

		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x060004B6 RID: 1206 RVA: 0x000139F3 File Offset: 0x00011BF3
		public bool ZNLMdZBSkPWbOsrZxpCHeeopfiBD
		{
			get
			{
				return this.viaGsvKIrKEJDgqINjfFcmtVxFCc;
			}
		}

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x060004B7 RID: 1207 RVA: 0x000139FB File Offset: 0x00011BFB
		// (set) Token: 0x060004B8 RID: 1208 RVA: 0x00013A03 File Offset: 0x00011C03
		public bool BEjfgBsAPOCTLBApyeEqNpZVhvbgb
		{
			get
			{
				return this.HUpWNtONZCOMjsccMhABaIyRyZLtA;
			}
			set
			{
				if (this.HUpWNtONZCOMjsccMhABaIyRyZLtA == value)
				{
					return;
				}
				this.HUpWNtONZCOMjsccMhABaIyRyZLtA = value;
				this.nlDDgZsOBUBWbYNeTlPYREPsmooE(true);
			}
		}

		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x060004B9 RID: 1209 RVA: 0x00013A1D File Offset: 0x00011C1D
		public int cuUSiOhoLEDuycjkcOEoaShggMBNA
		{
			get
			{
				return this.gyqIBmQITSICsGygCVDEWrLsttTb;
			}
		}

		// Token: 0x060004BA RID: 1210 RVA: 0x00013A25 File Offset: 0x00011C25
		public NkNdOWixlFsZjkacNuqNDiSZauWl(bool A_1, float A_2)
		{
			this.jtvlqqauuflImgsvtFeiPfEbyugt = A_1;
			this.JQZhbAKXagpqjeqsWtIyPsGgarag = A_2;
			this.nlDDgZsOBUBWbYNeTlPYREPsmooE(false);
		}

		// Token: 0x060004BB RID: 1211 RVA: 0x00013A4A File Offset: 0x00011C4A
		public void RIufgNKuxUqFtgnxDotBTPUZlMgG()
		{
			if (!this.jtvlqqauuflImgsvtFeiPfEbyugt)
			{
				return;
			}
			if (ReInput.realTime < this.xHNDACGIgjnliWwUWRSxhjraAIGW)
			{
				return;
			}
			this.nlDDgZsOBUBWbYNeTlPYREPsmooE(true);
		}

		// Token: 0x060004BC RID: 1212 RVA: 0x0003153C File Offset: 0x0002F73C
		private void nlDDgZsOBUBWbYNeTlPYREPsmooE(bool A_1)
		{
			if (this.HUpWNtONZCOMjsccMhABaIyRyZLtA)
			{
				wLURyKQfpGlmweDJGGSrwwzrDUJFA.rHcQbOVZpxknGrFzJJEtBOqKEBhcA(112U, 0U, ref this.gyqIBmQITSICsGygCVDEWrLsttTb, 0U);
			}
			this.viaGsvKIrKEJDgqINjfFcmtVxFCc = (wLURyKQfpGlmweDJGGSrwwzrDUJFA.SUFYDWJiTvXccbltGKLJRExHXHKr(KastMvGkvyaNUEWReDndMRsEYrtnA.UqsGpEbAGEajlQhkVUQqPslEnyLw) > 0);
			if (A_1)
			{
				this.xHNDACGIgjnliWwUWRSxhjraAIGW = ReInput.realTime + (double)this.JQZhbAKXagpqjeqsWtIyPsGgarag;
			}
		}

		// Token: 0x040005F1 RID: 1521
		private bool jtvlqqauuflImgsvtFeiPfEbyugt;

		// Token: 0x040005F2 RID: 1522
		private bool viaGsvKIrKEJDgqINjfFcmtVxFCc;

		// Token: 0x040005F3 RID: 1523
		private bool HUpWNtONZCOMjsccMhABaIyRyZLtA;

		// Token: 0x040005F4 RID: 1524
		private int gyqIBmQITSICsGygCVDEWrLsttTb = 10;

		// Token: 0x040005F5 RID: 1525
		private readonly float JQZhbAKXagpqjeqsWtIyPsGgarag;

		// Token: 0x040005F6 RID: 1526
		private double xHNDACGIgjnliWwUWRSxhjraAIGW;
	}
}
