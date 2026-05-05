using System;
using System.Runtime.CompilerServices;
using Rewired;
using Rewired.Interfaces;
using Rewired.Utils.Classes.Utility;

// Token: 0x02000082 RID: 130
internal sealed class CQMiAtCKCBeBxcvQtMWaEstcdgFPA : IControllerElementTarget, IPoolableObject_Internal, IPoolableObject, IDisposable
{
	// Token: 0x060005A1 RID: 1441 RVA: 0x0000704A File Offset: 0x0000524A
	internal CQMiAtCKCBeBxcvQtMWaEstcdgFPA(Controller A_1, int A_2, AxisRange A_3)
	{
		this.fEJdELujKRFDzrRkjbLNuVDrBUtBA = A_1;
		this.mnVHfsymuYAnTwTAgfAcbNwMWMVC = A_2;
		this.OIkITJAJenEoFbshUbgQdDKKNOLDB = A_3;
	}

	// Token: 0x060005A2 RID: 1442 RVA: 0x00007067 File Offset: 0x00005267
	internal void APDSDvhgFWluVrTyzOYNEZxakpBm(ControllerElementTarget A_1)
	{
		this.fEJdELujKRFDzrRkjbLNuVDrBUtBA = A_1.controller;
		this.mnVHfsymuYAnTwTAgfAcbNwMWMVC = A_1.elementIdentifierId;
		this.OIkITJAJenEoFbshUbgQdDKKNOLDB = A_1.axisRange;
	}

	// Token: 0x060005A3 RID: 1443 RVA: 0x00007090 File Offset: 0x00005290
	internal void CKkVpnMcxnrjakBOhDKrubHPlFup(IControllerElementTarget A_1)
	{
		this.fEJdELujKRFDzrRkjbLNuVDrBUtBA = A_1.controller;
		this.mnVHfsymuYAnTwTAgfAcbNwMWMVC = A_1.elementIdentifierId;
		this.OIkITJAJenEoFbshUbgQdDKKNOLDB = A_1.axisRange;
	}

	// Token: 0x060005A4 RID: 1444 RVA: 0x000070B6 File Offset: 0x000052B6
	internal void iNdJQtnfxWVYIDwxtEsyiBhrNVBc(CQMiAtCKCBeBxcvQtMWaEstcdgFPA A_1)
	{
		this.CKkVpnMcxnrjakBOhDKrubHPlFup(A_1);
	}

	// Token: 0x170001B3 RID: 435
	// (get) Token: 0x060005A5 RID: 1445 RVA: 0x000070BF File Offset: 0x000052BF
	public int elementIdentifierId
	{
		get
		{
			return this.mnVHfsymuYAnTwTAgfAcbNwMWMVC;
		}
	}

	// Token: 0x170001B4 RID: 436
	// (get) Token: 0x060005A6 RID: 1446 RVA: 0x000070C7 File Offset: 0x000052C7
	public AxisRange axisRange
	{
		get
		{
			return this.OIkITJAJenEoFbshUbgQdDKKNOLDB;
		}
	}

	// Token: 0x170001B5 RID: 437
	// (get) Token: 0x060005A7 RID: 1447 RVA: 0x000070CF File Offset: 0x000052CF
	public bool hasTarget
	{
		get
		{
			return this.element != null;
		}
	}

	// Token: 0x170001B6 RID: 438
	// (get) Token: 0x060005A8 RID: 1448 RVA: 0x000070DA File Offset: 0x000052DA
	public ControllerElementType elementType
	{
		get
		{
			if (this.element == null)
			{
				return ControllerElementType.Axis;
			}
			return this.element.type;
		}
	}

	// Token: 0x170001B7 RID: 439
	// (get) Token: 0x060005A9 RID: 1449 RVA: 0x0003A128 File Offset: 0x00038328
	public string descriptiveName
	{
		get
		{
			if (this.fEJdELujKRFDzrRkjbLNuVDrBUtBA == null)
			{
				return string.Empty;
			}
			ControllerElementIdentifier elementIdentifierById = this.fEJdELujKRFDzrRkjbLNuVDrBUtBA.GetElementIdentifierById(this.mnVHfsymuYAnTwTAgfAcbNwMWMVC);
			if (elementIdentifierById == null)
			{
				return string.Empty;
			}
			Controller.Element elementById = this.fEJdELujKRFDzrRkjbLNuVDrBUtBA.GetElementById(this.mnVHfsymuYAnTwTAgfAcbNwMWMVC);
			if (elementById == null)
			{
				return string.Empty;
			}
			return elementIdentifierById.GetDisplayName(elementById.type, this.OIkITJAJenEoFbshUbgQdDKKNOLDB);
		}
	}

	// Token: 0x170001B8 RID: 440
	// (get) Token: 0x060005AA RID: 1450 RVA: 0x000070F1 File Offset: 0x000052F1
	public Controller controller
	{
		get
		{
			return this.fEJdELujKRFDzrRkjbLNuVDrBUtBA;
		}
	}

	// Token: 0x170001B9 RID: 441
	// (get) Token: 0x060005AB RID: 1451 RVA: 0x000070F9 File Offset: 0x000052F9
	public Controller.Element element
	{
		get
		{
			if (this.fEJdELujKRFDzrRkjbLNuVDrBUtBA == null)
			{
				return null;
			}
			if (this.fEJdELujKRFDzrRkjbLNuVDrBUtBA.GetElementIdentifierById(this.mnVHfsymuYAnTwTAgfAcbNwMWMVC) == null)
			{
				return null;
			}
			return this.fEJdELujKRFDzrRkjbLNuVDrBUtBA.GetElementById(this.mnVHfsymuYAnTwTAgfAcbNwMWMVC);
		}
	}

	// Token: 0x170001BA RID: 442
	// (get) Token: 0x060005AC RID: 1452 RVA: 0x0000712B File Offset: 0x0000532B
	public ControllerElementIdentifier SmufjMetXgnCpnXkRxLJtGrYqBMCA
	{
		get
		{
			if (this.fEJdELujKRFDzrRkjbLNuVDrBUtBA == null)
			{
				return null;
			}
			return this.fEJdELujKRFDzrRkjbLNuVDrBUtBA.GetElementIdentifierById(this.mnVHfsymuYAnTwTAgfAcbNwMWMVC);
		}
	}

	// Token: 0x170001BB RID: 443
	// (get) Token: 0x060005AD RID: 1453 RVA: 0x00007148 File Offset: 0x00005348
	// (set) Token: 0x060005AE RID: 1454 RVA: 0x00007150 File Offset: 0x00005350
	IObjectPool IPoolableObject_Internal.pool
	{
		get
		{
			return this.ToUAqAfjvTzMzPiBXlfRgQtqVfxTA;
		}
		set
		{
			this.ToUAqAfjvTzMzPiBXlfRgQtqVfxTA = value;
		}
	}

	// Token: 0x060005AF RID: 1455 RVA: 0x00007159 File Offset: 0x00005359
	void IPoolableObject_Internal.Clear()
	{
		this.fEJdELujKRFDzrRkjbLNuVDrBUtBA = null;
		this.mnVHfsymuYAnTwTAgfAcbNwMWMVC = -1;
		this.OIkITJAJenEoFbshUbgQdDKKNOLDB = AxisRange.Full;
	}

	// Token: 0x060005B0 RID: 1456 RVA: 0x00007170 File Offset: 0x00005370
	void IPoolableObject.Return()
	{
		if (this.ToUAqAfjvTzMzPiBXlfRgQtqVfxTA == null)
		{
			return;
		}
		this.ToUAqAfjvTzMzPiBXlfRgQtqVfxTA.Return(this);
	}

	// Token: 0x060005B1 RID: 1457 RVA: 0x00007188 File Offset: 0x00005388
	internal static CQMiAtCKCBeBxcvQtMWaEstcdgFPA FFyrXKsykSOHoJNuzPBxRovdupcA()
	{
		if (CQMiAtCKCBeBxcvQtMWaEstcdgFPA.XaEKvymJGHLyGsgHfGxYCSTYusuV == null)
		{
			CQMiAtCKCBeBxcvQtMWaEstcdgFPA.XaEKvymJGHLyGsgHfGxYCSTYusuV = new ObjectPool<CQMiAtCKCBeBxcvQtMWaEstcdgFPA>(new Func<CQMiAtCKCBeBxcvQtMWaEstcdgFPA>(CQMiAtCKCBeBxcvQtMWaEstcdgFPA.saYbDhCvxgfBNRdngIGRCoTnjPOI.<>9.khKayFXerPcQRJOFOSkuHKOHfqIuA));
		}
		return CQMiAtCKCBeBxcvQtMWaEstcdgFPA.XaEKvymJGHLyGsgHfGxYCSTYusuV.Get();
	}

	// Token: 0x060005B2 RID: 1458 RVA: 0x000071C4 File Offset: 0x000053C4
	internal static CQMiAtCKCBeBxcvQtMWaEstcdgFPA awUDFAvrkgZegheEODIWTzvDUnFG(ControllerElementTarget A_0)
	{
		CQMiAtCKCBeBxcvQtMWaEstcdgFPA cqmiAtCKCBeBxcvQtMWaEstcdgFPA = CQMiAtCKCBeBxcvQtMWaEstcdgFPA.FFyrXKsykSOHoJNuzPBxRovdupcA();
		cqmiAtCKCBeBxcvQtMWaEstcdgFPA.APDSDvhgFWluVrTyzOYNEZxakpBm(A_0);
		return cqmiAtCKCBeBxcvQtMWaEstcdgFPA;
	}

	// Token: 0x060005B3 RID: 1459 RVA: 0x000071D2 File Offset: 0x000053D2
	internal static void nCRlKMWMlcpJInXrvtLslXZSGRhP(CQMiAtCKCBeBxcvQtMWaEstcdgFPA A_0)
	{
		if (A_0 == null || CQMiAtCKCBeBxcvQtMWaEstcdgFPA.XaEKvymJGHLyGsgHfGxYCSTYusuV == null)
		{
			return;
		}
		CQMiAtCKCBeBxcvQtMWaEstcdgFPA.XaEKvymJGHLyGsgHfGxYCSTYusuV.Return(A_0);
	}

	// Token: 0x060005B4 RID: 1460 RVA: 0x000071EB File Offset: 0x000053EB
	internal static CQMiAtCKCBeBxcvQtMWaEstcdgFPA UIqjeqmzUiHebZMfbNoSZczTEyep()
	{
		return new CQMiAtCKCBeBxcvQtMWaEstcdgFPA(null, -1, AxisRange.Full);
	}

	// Token: 0x060005B5 RID: 1461 RVA: 0x000071F5 File Offset: 0x000053F5
	void IDisposable.Dispose()
	{
		this.ovmqLJLsIJspnpxVnnTsOjTdcqAG(true);
		GC.SuppressFinalize(this);
	}

	// Token: 0x060005B6 RID: 1462 RVA: 0x0003A18C File Offset: 0x0003838C
	protected void UZNlAuXInwFNMjHbfmjWhDNcIaBhA()
	{
		try
		{
			this.ovmqLJLsIJspnpxVnnTsOjTdcqAG(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	// Token: 0x060005B7 RID: 1463 RVA: 0x00007204 File Offset: 0x00005404
	private void ovmqLJLsIJspnpxVnnTsOjTdcqAG(bool A_1)
	{
		if (this.yiuFusGyrXnKPcJSGbNxyRRoDIEHb)
		{
			return;
		}
		if (A_1)
		{
			((IPoolableObject)this).Return();
		}
		this.yiuFusGyrXnKPcJSGbNxyRRoDIEHb = true;
	}

	// Token: 0x040003A9 RID: 937
	private static ObjectPool<CQMiAtCKCBeBxcvQtMWaEstcdgFPA> XaEKvymJGHLyGsgHfGxYCSTYusuV;

	// Token: 0x040003AA RID: 938
	private Controller fEJdELujKRFDzrRkjbLNuVDrBUtBA;

	// Token: 0x040003AB RID: 939
	private int mnVHfsymuYAnTwTAgfAcbNwMWMVC;

	// Token: 0x040003AC RID: 940
	private AxisRange OIkITJAJenEoFbshUbgQdDKKNOLDB;

	// Token: 0x040003AD RID: 941
	private IObjectPool ToUAqAfjvTzMzPiBXlfRgQtqVfxTA;

	// Token: 0x040003AE RID: 942
	private bool yiuFusGyrXnKPcJSGbNxyRRoDIEHb;

	// Token: 0x02000083 RID: 131
	[CompilerGenerated]
	[Serializable]
	private sealed class saYbDhCvxgfBNRdngIGRCoTnjPOI
	{
		// Token: 0x060005BA RID: 1466 RVA: 0x0000722B File Offset: 0x0000542B
		internal CQMiAtCKCBeBxcvQtMWaEstcdgFPA khKayFXerPcQRJOFOSkuHKOHfqIuA()
		{
			return CQMiAtCKCBeBxcvQtMWaEstcdgFPA.UIqjeqmzUiHebZMfbNoSZczTEyep();
		}

		// Token: 0x040003AF RID: 943
		public static readonly CQMiAtCKCBeBxcvQtMWaEstcdgFPA.saYbDhCvxgfBNRdngIGRCoTnjPOI <>9 = new CQMiAtCKCBeBxcvQtMWaEstcdgFPA.saYbDhCvxgfBNRdngIGRCoTnjPOI();

		// Token: 0x040003B0 RID: 944
		public static Func<CQMiAtCKCBeBxcvQtMWaEstcdgFPA> <>9__30_0;
	}
}
