using System;
using Rewired;
using Rewired.Platforms.Microsoft.WindowsGamingInput;
using Rewired.Utils;

// Token: 0x020000AC RID: 172
internal abstract class khFtVaVlCxqEfcUymOxXQstyFBiL : cWYIDMjUnhAyDysKZVfQnpWFBosr, IDisposable
{
	// Token: 0x06000636 RID: 1590 RVA: 0x00034F44 File Offset: 0x00033144
	public khFtVaVlCxqEfcUymOxXQstyFBiL(WGIDeviceType A_1, CuHgYDcsmuVCqPRvftOBdYJksWUJ A_2, int A_3, int A_4, int A_5, int A_6)
	{
		this.IJXrXrUAignTOmVEcHgiQuAZpFsO = A_1;
		this.bfEAOhODjkXKwQGCHWSdfsNERJlP = A_2;
		this.PcuPNXiokmUxRjOfTojGDBBjCbPQ = A_3;
		this.dNTpCwKRDSsvaAkdjwIbphtvDnAn = A_4;
		this.hoLaaUhMcPErgoEBMofcjUsbVhBuA = A_5;
		this.mgdbLHMMtoVqVMYYzhKLENJgWOtO = A_6;
		riIeoyfcwQhGFHAQrUpyWJKecmGwA riIeoyfcwQhGFHAQrUpyWJKecmGwA = riIeoyfcwQhGFHAQrUpyWJKecmGwA.HeTcTicBjXMiDgnUkhtRKcBdbwHEe(A_2);
		if (riIeoyfcwQhGFHAQrUpyWJKecmGwA != null)
		{
			try
			{
				this.AYJsRoHveUQneGNBVMKsRDYNSeBQ = riIeoyfcwQhGFHAQrUpyWJKecmGwA.IehwoUacidIOAnrwGiTPNSNavhoj;
			}
			catch
			{
				this.AYJsRoHveUQneGNBVMKsRDYNSeBQ = "Gamepad";
			}
			try
			{
				this.IyEDfghvZQPxbAevHlEtnkMZtvie = new PidVid(riIeoyfcwQhGFHAQrUpyWJKecmGwA.zVSyANTgqubUUVoxYzvqCnbMaHws, riIeoyfcwQhGFHAQrUpyWJKecmGwA.HMjYVlXDFtHLHIAHvLbRsDnEwkOOA);
			}
			catch
			{
				this.IyEDfghvZQPxbAevHlEtnkMZtvie = new PidVid(654, 1118);
			}
			try
			{
				this.oXagbCJFIbRHyLmTWFfvpwsrbyjMA = riIeoyfcwQhGFHAQrUpyWJKecmGwA.gSiNYhwlFEOytkBFvhQnkmAcloOi;
			}
			catch
			{
				this.oXagbCJFIbRHyLmTWFfvpwsrbyjMA = string.Empty;
			}
			try
			{
				this.rGDGmrgypVmowsJgdFqbkDTnUvdO = riIeoyfcwQhGFHAQrUpyWJKecmGwA.rDhgyPEsOLOcWxeuodnHvDVezMEpA;
			}
			catch
			{
				this.rGDGmrgypVmowsJgdFqbkDTnUvdO = false;
			}
			if (riIeoyfcwQhGFHAQrUpyWJKecmGwA.KVpUooewgULkrffZyDUPzePFSONV(out this.ipfGoczIZMwYCJDwGrDJvEUfCoahA))
			{
				this.FGRodbQVkEvWjVgcSCjZqmiwyRNI = true;
				this.AYJsRoHveUQneGNBVMKsRDYNSeBQ = "Steam Controller";
			}
			riIeoyfcwQhGFHAQrUpyWJKecmGwA.YQzwgxBzHLjtmCUMFhglJaPLbqLl;
			riIeoyfcwQhGFHAQrUpyWJKecmGwA.WezAdwgrZNDCfMagrgrKKJXCfRjAb;
			riIeoyfcwQhGFHAQrUpyWJKecmGwA.QXOBvntUVpyTAKKNQCkqtExUlFrx;
			riIeoyfcwQhGFHAQrUpyWJKecmGwA.GUYtzgHLQVggrCxIzRYXKylefCDA();
		}
		else
		{
			this.AYJsRoHveUQneGNBVMKsRDYNSeBQ = "Gamepad";
			this.oXagbCJFIbRHyLmTWFfvpwsrbyjMA = string.Empty;
			this.IyEDfghvZQPxbAevHlEtnkMZtvie = new PidVid(654, 1118);
		}
		this.OPIkmQWEpVDyqfqhWvMIMCTfrDfB = ((A_2 is npeFzFFBQqrIoNKuecNDbCOHzNtgA) ? 5 : 4);
		this.HdvkbhaioglADrOgVoUGuaElRgmM = 1;
		this.lWgVAvSCbseHlIVXNrKkxjWfXPXq = MiscTools.CreateGuidHashSHA256(string.IsNullOrEmpty(this.oXagbCJFIbRHyLmTWFfvpwsrbyjMA) ? (this.NeigsMKNgqriBxadCuicSosqZZfUA + "_" + A_2.GetHashCode().ToString()) : this.oXagbCJFIbRHyLmTWFfvpwsrbyjMA);
		this.ETnQblZHaITlpEhxWxyDkFCkbCHG = (string.IsNullOrEmpty(this.oXagbCJFIbRHyLmTWFfvpwsrbyjMA) ? Guid.Empty : this.lWgVAvSCbseHlIVXNrKkxjWfXPXq);
		this.aAYTMxHaQIOqslmMyIbeUrzvHjkQ = new ButtonLoopSet(ReInput.configVars.updateLoop, A_4);
		this.XQHZAOnmVnoAjuuHFElzIXjyfCfQ = new khFtVaVlCxqEfcUymOxXQstyFBiL.OQmTQuhYdifEnbcDXeIeftyEGrEo[A_5];
		for (int i = 0; i < A_5; i++)
		{
			this.XQHZAOnmVnoAjuuHFElzIXjyfCfQ[i] = new khFtVaVlCxqEfcUymOxXQstyFBiL.OQmTQuhYdifEnbcDXeIeftyEGrEo();
		}
		this.nJkvpGHaxlhXjDpauJIIjDryoLJg = new WindowsGamingInputControllerExtension(this);
	}

	// Token: 0x1700012F RID: 303
	// (get) Token: 0x06000637 RID: 1591 RVA: 0x0001438A File Offset: 0x0001258A
	public IntPtr XVHvXppHcuRGHoTPtHIMCcZTQBvX
	{
		get
		{
			return this.bfEAOhODjkXKwQGCHWSdfsNERJlP.ThAqfwuYsYnEKSzFqJyOtFWlGuJh;
		}
	}

	// Token: 0x17000130 RID: 304
	// (get) Token: 0x06000638 RID: 1592 RVA: 0x00013FD9 File Offset: 0x000121D9
	public InputSource jrFvjbhhatDowbVakbuzQAagfLkSA
	{
		get
		{
			return InputSource.WindowsGamingInput;
		}
	}

	// Token: 0x17000131 RID: 305
	// (get) Token: 0x06000639 RID: 1593 RVA: 0x00014397 File Offset: 0x00012597
	public CuHgYDcsmuVCqPRvftOBdYJksWUJ AdLsLaEmLjQmvOMxMBQFptnoAijeA
	{
		get
		{
			return this.bfEAOhODjkXKwQGCHWSdfsNERJlP;
		}
	}

	// Token: 0x17000132 RID: 306
	// (get) Token: 0x0600063A RID: 1594 RVA: 0x0001439F File Offset: 0x0001259F
	public int pdDGLQcYxZlfgfzFTeYpTDKVmzAy
	{
		get
		{
			return this.PcuPNXiokmUxRjOfTojGDBBjCbPQ;
		}
	}

	// Token: 0x17000133 RID: 307
	// (get) Token: 0x0600063B RID: 1595 RVA: 0x000143A7 File Offset: 0x000125A7
	public string NeigsMKNgqriBxadCuicSosqZZfUA
	{
		get
		{
			return this.AYJsRoHveUQneGNBVMKsRDYNSeBQ;
		}
	}

	// Token: 0x17000134 RID: 308
	// (get) Token: 0x0600063C RID: 1596 RVA: 0x000143AF File Offset: 0x000125AF
	public Guid qutfHyBpippaAYryIwZDUHevSJOcb
	{
		get
		{
			return this.lWgVAvSCbseHlIVXNrKkxjWfXPXq;
		}
	}

	// Token: 0x17000135 RID: 309
	// (get) Token: 0x0600063D RID: 1597 RVA: 0x000143B7 File Offset: 0x000125B7
	public PidVid xYPClePOxdcHpMsZUAOYEwYaLEYUA
	{
		get
		{
			if (!this.FGRodbQVkEvWjVgcSCjZqmiwyRNI)
			{
				return this.IyEDfghvZQPxbAevHlEtnkMZtvie;
			}
			return this.ipfGoczIZMwYCJDwGrDJvEUfCoahA;
		}
	}

	// Token: 0x17000136 RID: 310
	// (get) Token: 0x0600063E RID: 1598 RVA: 0x000143CE File Offset: 0x000125CE
	public ushort VZZEZMHMYmDmOTlgPaWNDeGieSWBc
	{
		get
		{
			return this.OPIkmQWEpVDyqfqhWvMIMCTfrDfB;
		}
	}

	// Token: 0x17000137 RID: 311
	// (get) Token: 0x0600063F RID: 1599 RVA: 0x000143D6 File Offset: 0x000125D6
	public ushort gHQiCrjzGkFhUXcEQueROCxFvjtv
	{
		get
		{
			return this.HdvkbhaioglADrOgVoUGuaElRgmM;
		}
	}

	// Token: 0x17000138 RID: 312
	// (get) Token: 0x06000640 RID: 1600 RVA: 0x000143DE File Offset: 0x000125DE
	public Guid GxQWDnWFqTsRqvUacmcQUdquNytv
	{
		get
		{
			return this.ETnQblZHaITlpEhxWxyDkFCkbCHG;
		}
	}

	// Token: 0x17000139 RID: 313
	// (get) Token: 0x06000641 RID: 1601 RVA: 0x000143E6 File Offset: 0x000125E6
	public string YtGeBMQHdLuRTtWLxOQBgwCcsNgn
	{
		get
		{
			return this.oXagbCJFIbRHyLmTWFfvpwsrbyjMA;
		}
	}

	// Token: 0x1700013A RID: 314
	// (get) Token: 0x06000642 RID: 1602 RVA: 0x000143EE File Offset: 0x000125EE
	public int XutaxsEVhZSgtkDYtABhhFfylHap
	{
		get
		{
			return this.aAYTMxHaQIOqslmMyIbeUrzvHjkQ.buttonCount;
		}
	}

	// Token: 0x1700013B RID: 315
	// (get) Token: 0x06000643 RID: 1603 RVA: 0x000143FB File Offset: 0x000125FB
	public int JTikleOeSlGOoElynpFUVDzqpgfLA
	{
		get
		{
			return this.XQHZAOnmVnoAjuuHFElzIXjyfCfQ.Length;
		}
	}

	// Token: 0x1700013C RID: 316
	// (get) Token: 0x06000644 RID: 1604 RVA: 0x00014405 File Offset: 0x00012605
	public int ZHLcFNCBLFwHLLJVTBcSRIqDRZWNA
	{
		get
		{
			return this.mgdbLHMMtoVqVMYYzhKLENJgWOtO;
		}
	}

	// Token: 0x1700013D RID: 317
	// (get) Token: 0x06000645 RID: 1605 RVA: 0x0001164A File Offset: 0x0000F84A
	public bool UqDoGOJubVFOMFFeaaWYCbAcDauJA
	{
		get
		{
			return true;
		}
	}

	// Token: 0x1700013E RID: 318
	// (get) Token: 0x06000646 RID: 1606
	public abstract bool ORMogkZMylcNfXEHavwWfGxkNOdQ { get; }

	// Token: 0x1700013F RID: 319
	// (get) Token: 0x06000647 RID: 1607
	public abstract int qnMfhUBNGhcgORXYQQcdpJaknxJL { get; }

	// Token: 0x17000140 RID: 320
	// (get) Token: 0x06000648 RID: 1608 RVA: 0x0001440D File Offset: 0x0001260D
	public WGIDeviceType TSMfrUQJevmaGAlSJIgaOuzacxLE
	{
		get
		{
			return this.IJXrXrUAignTOmVEcHgiQuAZpFsO;
		}
	}

	// Token: 0x17000141 RID: 321
	// (get) Token: 0x06000649 RID: 1609 RVA: 0x00014415 File Offset: 0x00012615
	public bool EUyqCwHoAkxaWCtXJVidqHgtaQyW
	{
		get
		{
			return this.FGRodbQVkEvWjVgcSCjZqmiwyRNI;
		}
	}

	// Token: 0x17000142 RID: 322
	// (get) Token: 0x0600064A RID: 1610 RVA: 0x0001441D File Offset: 0x0001261D
	public bool wasEUKQTUvxVKJCemghPBnlHMpmM
	{
		get
		{
			return this.rGDGmrgypVmowsJgdFqbkDTnUvdO;
		}
	}

	// Token: 0x17000143 RID: 323
	// (get) Token: 0x0600064B RID: 1611 RVA: 0x00014425 File Offset: 0x00012625
	public Controller.Extension ZzoqxsTAAxAYHRIoOGcoxhtCqXje
	{
		get
		{
			return this.nJkvpGHaxlhXjDpauJIIjDryoLJg;
		}
	}

	// Token: 0x0600064C RID: 1612
	public abstract float kWYaeXSJtMdpplUsLpQSZAVEDdMo(int);

	// Token: 0x0600064D RID: 1613
	public abstract void EgGBgmYVkpUkWIuSUKuCQnULsuVT(int, float, bool);

	// Token: 0x0600064E RID: 1614
	public abstract void YFOxJaolxWZSruTORTIZSGBfsYNU();

	// Token: 0x0600064F RID: 1615 RVA: 0x0001442D File Offset: 0x0001262D
	public bool CTIExOeTaAMFNjLQYBrZJQHXbGDl(int A_1)
	{
		return A_1 >= 0 && A_1 < this.dNTpCwKRDSsvaAkdjwIbphtvDnAn && this.aAYTMxHaQIOqslmMyIbeUrzvHjkQ.Current.effectiveValue[A_1];
	}

	// Token: 0x06000650 RID: 1616 RVA: 0x00014450 File Offset: 0x00012650
	public float mzpDBuvtGERpCYxolscyIsxeuLIj(int A_1)
	{
		if (A_1 < 0 || A_1 >= this.hoLaaUhMcPErgoEBMofcjUsbVhBuA)
		{
			return 0f;
		}
		return this.XQHZAOnmVnoAjuuHFElzIXjyfCfQ[A_1].pnzEhrxirBFxtkpfXpxaLfCIetYm;
	}

	// Token: 0x06000651 RID: 1617 RVA: 0x00014472 File Offset: 0x00012672
	public int SKyWrTWOkvWNnonOZZlnVMRLAkcL(int A_1)
	{
		if (A_1 < 0 || A_1 >= this.XQHZAOnmVnoAjuuHFElzIXjyfCfQ.Length)
		{
			return 0;
		}
		return (int)this.XQHZAOnmVnoAjuuHFElzIXjyfCfQ[A_1].pnzEhrxirBFxtkpfXpxaLfCIetYm;
	}

	// Token: 0x06000652 RID: 1618 RVA: 0x00014493 File Offset: 0x00012693
	public int RUxsSTDBMWExNRTYcXeVOnEygnCL(int A_1)
	{
		return -1;
	}

	// Token: 0x06000653 RID: 1619 RVA: 0x000116E9 File Offset: 0x0000F8E9
	public virtual void qMSXekWEUnEOBhRisUeDQGziMnvN()
	{
	}

	// Token: 0x06000654 RID: 1620 RVA: 0x00035174 File Offset: 0x00033374
	public virtual void ujBFyXaFbxcLMUISMqtqiyMPHBEB(cWYIDMjUnhAyDysKZVfQnpWFBosr A_1)
	{
		khFtVaVlCxqEfcUymOxXQstyFBiL khFtVaVlCxqEfcUymOxXQstyFBiL = A_1 as khFtVaVlCxqEfcUymOxXQstyFBiL;
		if (khFtVaVlCxqEfcUymOxXQstyFBiL == null)
		{
			return;
		}
		this.bfEAOhODjkXKwQGCHWSdfsNERJlP = khFtVaVlCxqEfcUymOxXQstyFBiL.bfEAOhODjkXKwQGCHWSdfsNERJlP;
		this.PcuPNXiokmUxRjOfTojGDBBjCbPQ = khFtVaVlCxqEfcUymOxXQstyFBiL.PcuPNXiokmUxRjOfTojGDBBjCbPQ;
	}

	// Token: 0x06000655 RID: 1621 RVA: 0x00014496 File Offset: 0x00012696
	public virtual void HNOkLPGjTMelBuPoPqesvzLHXckm(UpdateLoopType A_1)
	{
		this.aAYTMxHaQIOqslmMyIbeUrzvHjkQ.SetUpdateLoop(A_1);
	}

	// Token: 0x06000656 RID: 1622 RVA: 0x000144A4 File Offset: 0x000126A4
	public virtual void HALUsRwEhCdXcaroUpyyKgQwPRBv()
	{
		this.aAYTMxHaQIOqslmMyIbeUrzvHjkQ.Current.ClearWasTrueThisFrame();
	}

	// Token: 0x06000657 RID: 1623 RVA: 0x000144B6 File Offset: 0x000126B6
	public void Dispose()
	{
		this.sxybqEfrlMKOTuGlKQTMuAVRKkhhA(true);
		GC.SuppressFinalize(this);
	}

	// Token: 0x06000658 RID: 1624 RVA: 0x000351A4 File Offset: 0x000333A4
	protected virtual void tYxayQmnykfHElGIyedwvrodzldb()
	{
		try
		{
			this.sxybqEfrlMKOTuGlKQTMuAVRKkhhA(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	// Token: 0x06000659 RID: 1625 RVA: 0x000144C6 File Offset: 0x000126C6
	protected virtual bool sxybqEfrlMKOTuGlKQTMuAVRKkhhA(bool A_1)
	{
		if (this.WqgZQYsIRdFnnFNKqBCgRBiXgUfTA)
		{
			return true;
		}
		this.WqgZQYsIRdFnnFNKqBCgRBiXgUfTA = true;
		return false;
	}

	// Token: 0x04000697 RID: 1687
	protected readonly WGIDeviceType IJXrXrUAignTOmVEcHgiQuAZpFsO;

	// Token: 0x04000698 RID: 1688
	private int PcuPNXiokmUxRjOfTojGDBBjCbPQ;

	// Token: 0x04000699 RID: 1689
	protected readonly Guid lWgVAvSCbseHlIVXNrKkxjWfXPXq;

	// Token: 0x0400069A RID: 1690
	protected readonly Guid ETnQblZHaITlpEhxWxyDkFCkbCHG;

	// Token: 0x0400069B RID: 1691
	protected readonly PidVid IyEDfghvZQPxbAevHlEtnkMZtvie;

	// Token: 0x0400069C RID: 1692
	protected readonly ushort OPIkmQWEpVDyqfqhWvMIMCTfrDfB;

	// Token: 0x0400069D RID: 1693
	protected readonly ushort HdvkbhaioglADrOgVoUGuaElRgmM;

	// Token: 0x0400069E RID: 1694
	protected readonly string AYJsRoHveUQneGNBVMKsRDYNSeBQ;

	// Token: 0x0400069F RID: 1695
	protected readonly string oXagbCJFIbRHyLmTWFfvpwsrbyjMA;

	// Token: 0x040006A0 RID: 1696
	protected readonly bool rGDGmrgypVmowsJgdFqbkDTnUvdO;

	// Token: 0x040006A1 RID: 1697
	private CuHgYDcsmuVCqPRvftOBdYJksWUJ bfEAOhODjkXKwQGCHWSdfsNERJlP;

	// Token: 0x040006A2 RID: 1698
	private Controller.Extension nJkvpGHaxlhXjDpauJIIjDryoLJg;

	// Token: 0x040006A3 RID: 1699
	protected readonly ButtonLoopSet aAYTMxHaQIOqslmMyIbeUrzvHjkQ;

	// Token: 0x040006A4 RID: 1700
	protected readonly khFtVaVlCxqEfcUymOxXQstyFBiL.OQmTQuhYdifEnbcDXeIeftyEGrEo[] XQHZAOnmVnoAjuuHFElzIXjyfCfQ;

	// Token: 0x040006A5 RID: 1701
	protected readonly int dNTpCwKRDSsvaAkdjwIbphtvDnAn;

	// Token: 0x040006A6 RID: 1702
	protected readonly int hoLaaUhMcPErgoEBMofcjUsbVhBuA;

	// Token: 0x040006A7 RID: 1703
	protected readonly int mgdbLHMMtoVqVMYYzhKLENJgWOtO;

	// Token: 0x040006A8 RID: 1704
	private readonly bool FGRodbQVkEvWjVgcSCjZqmiwyRNI;

	// Token: 0x040006A9 RID: 1705
	private readonly PidVid ipfGoczIZMwYCJDwGrDJvEUfCoahA;

	// Token: 0x040006AA RID: 1706
	private bool WqgZQYsIRdFnnFNKqBCgRBiXgUfTA;

	// Token: 0x020000AD RID: 173
	protected abstract class HqfhmsaJCoFAgbLdEFzChGMZTgsjA<\u0001>
	{
		// Token: 0x0600065A RID: 1626 RVA: 0x000114A8 File Offset: 0x0000F6A8
		public HqfhmsaJCoFAgbLdEFzChGMZTgsjA()
		{
		}

		// Token: 0x040006AB RID: 1707
		public \u0001 pnzEhrxirBFxtkpfXpxaLfCIetYm;
	}

	// Token: 0x020000AE RID: 174
	protected class WKSLUGhHfIDeCWDmCjauCRdSPKLu : khFtVaVlCxqEfcUymOxXQstyFBiL<bool>.HqfhmsaJCoFAgbLdEFzChGMZTgsjA
	{
	}

	// Token: 0x020000AF RID: 175
	protected class OQmTQuhYdifEnbcDXeIeftyEGrEo : khFtVaVlCxqEfcUymOxXQstyFBiL<float>.HqfhmsaJCoFAgbLdEFzChGMZTgsjA
	{
	}
}
