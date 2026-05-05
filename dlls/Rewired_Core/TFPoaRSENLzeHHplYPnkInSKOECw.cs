using System;
using System.Collections.Generic;
using Rewired.Internal;
using Rewired.Internal.Glyphs;
using Rewired.Utils.Classes.Data;

// Token: 0x0200045E RID: 1118
internal abstract class TFPoaRSENLzeHHplYPnkInSKOECw : IPrefetch
{
	// Token: 0x17000A8B RID: 2699
	// (get) Token: 0x06002C87 RID: 11399 RVA: 0x0002240D File Offset: 0x0002060D
	protected bool pWCCxlQVEwhpjZTNrWMHtlTAMDZP
	{
		get
		{
			return this.JUdHVKLSlYoYYGQBoGaBNTOtWLvc;
		}
	}

	// Token: 0x17000A8C RID: 2700
	// (get) Token: 0x06002C88 RID: 11400
	public abstract object RrcQSnGZhLUWaACyTfIVqhfeHwoH { get; }

	// Token: 0x17000A8D RID: 2701
	// (get) Token: 0x06002C89 RID: 11401
	public abstract string IbkdqazTmRJXXakoWTyynULrgVYm { get; }

	// Token: 0x06002C8A RID: 11402 RVA: 0x00022415 File Offset: 0x00020615
	protected TFPoaRSENLzeHHplYPnkInSKOECw()
	{
		this.XjrfoUeXiWLRoamZcAlTqwGZSWoH = new KeyedGlyph();
		this.trLhbXpBFPLOCiElcdTHYqRWlsSA = new Dictionary<int, List<TFPoaRSENLzeHHplYPnkInSKOECw.VopXKeeDjecXqtQeUIkqAaTempZhA>>();
	}

	// Token: 0x06002C8B RID: 11403 RVA: 0x00022433 File Offset: 0x00020633
	protected TFPoaRSENLzeHHplYPnkInSKOECw(VHSvqsZIGaGVcFIeminrliAGzvFf A_1) : this()
	{
		if (A_1 == null)
		{
			throw new ArgumentNullException("dataSource");
		}
		this.ZmRmscTdYlfQYPqgFVvBwemnuBVc = A_1;
	}

	// Token: 0x06002C8C RID: 11404 RVA: 0x00022450 File Offset: 0x00020650
	public void VonfsNNhffgVmDYVOTLRZMSNCVKB()
	{
		this.AZgjeyqHMRUsPeYFhNeaPGmxjuIc();
		if (GlyphManager.isEnabled && GlyphManager.autoPrefetch)
		{
			this.xuMENlQEOEMCefvbjwDRaFpEABmR();
		}
	}

	// Token: 0x06002C8D RID: 11405 RVA: 0x0002246C File Offset: 0x0002066C
	protected virtual void AZgjeyqHMRUsPeYFhNeaPGmxjuIc()
	{
		this.DhLQNhOahWcQHUeZBRaETvpvEevU();
		this.yrSfLBkTQUOscnVsBhvoTyPxAQsEA();
		GlyphManager.Add(this, ref this.tHwfMmWIWFFAfCoIVbmPTvxdIvTU);
		this.JUdHVKLSlYoYYGQBoGaBNTOtWLvc = true;
	}

	// Token: 0x06002C8E RID: 11406 RVA: 0x0002248D File Offset: 0x0002068D
	public virtual void DhLQNhOahWcQHUeZBRaETvpvEevU()
	{
		this.zradpZDucgfMQxKhFkYPWKDLEtPD();
		GlyphManager.Remove(ref this.tHwfMmWIWFFAfCoIVbmPTvxdIvTU);
		this.JUdHVKLSlYoYYGQBoGaBNTOtWLvc = false;
	}

	// Token: 0x06002C8F RID: 11407 RVA: 0x000224A8 File Offset: 0x000206A8
	public virtual void IDyLDaZuVIdksxRfLlDpFQVrSiiJ(VHSvqsZIGaGVcFIeminrliAGzvFf A_1)
	{
		if (A_1 == null)
		{
			throw new ArgumentNullException("value");
		}
		if (A_1 == this.ZmRmscTdYlfQYPqgFVvBwemnuBVc)
		{
			return;
		}
		if (this.ZmRmscTdYlfQYPqgFVvBwemnuBVc != null)
		{
			this.zradpZDucgfMQxKhFkYPWKDLEtPD();
		}
		this.ZmRmscTdYlfQYPqgFVvBwemnuBVc = A_1;
		this.VonfsNNhffgVmDYVOTLRZMSNCVKB();
	}

	// Token: 0x06002C90 RID: 11408 RVA: 0x000224DD File Offset: 0x000206DD
	public virtual void vBtcSijWmpiiYTCICnbNCMJRfeeR()
	{
		this.XjrfoUeXiWLRoamZcAlTqwGZSWoH.Clear();
	}

	// Token: 0x06002C91 RID: 11409 RVA: 0x0009EAAC File Offset: 0x0009CCAC
	public virtual bool cHdOpXaaqJiUOiddewfaYZgEgMev(TFPoaRSENLzeHHplYPnkInSKOECw A_1)
	{
		return A_1 != null && object.Equals(base.GetType(), A_1.GetType()) && this.ZmRmscTdYlfQYPqgFVvBwemnuBVc == null == (A_1.ZmRmscTdYlfQYPqgFVvBwemnuBVc == null) && (this.ZmRmscTdYlfQYPqgFVvBwemnuBVc == null || (string.Equals(this.ZmRmscTdYlfQYPqgFVvBwemnuBVc.keyCategory, A_1.ZmRmscTdYlfQYPqgFVvBwemnuBVc.keyCategory, StringComparison.Ordinal) && string.Equals(this.ZmRmscTdYlfQYPqgFVvBwemnuBVc.key, A_1.ZmRmscTdYlfQYPqgFVvBwemnuBVc.key, StringComparison.Ordinal)));
	}

	// Token: 0x06002C92 RID: 11410 RVA: 0x000224EA File Offset: 0x000206EA
	protected virtual void zradpZDucgfMQxKhFkYPWKDLEtPD()
	{
		this.XjrfoUeXiWLRoamZcAlTqwGZSWoH.Clear();
		this.trLhbXpBFPLOCiElcdTHYqRWlsSA.Clear();
	}

	// Token: 0x06002C93 RID: 11411 RVA: 0x00022502 File Offset: 0x00020702
	protected VHSvqsZIGaGVcFIeminrliAGzvFf wOnDgRshfvlQwxPdILsSAFMpaTmR()
	{
		return this.ZmRmscTdYlfQYPqgFVvBwemnuBVc;
	}

	// Token: 0x06002C94 RID: 11412 RVA: 0x0002250A File Offset: 0x0002070A
	protected virtual void xuMENlQEOEMCefvbjwDRaFpEABmR()
	{
		this.RrcQSnGZhLUWaACyTfIVqhfeHwoH;
	}

	// Token: 0x06002C95 RID: 11413 RVA: 0x00022513 File Offset: 0x00020713
	void IPrefetch.Prefetch()
	{
		this.xuMENlQEOEMCefvbjwDRaFpEABmR();
	}

	// Token: 0x06002C96 RID: 11414 RVA: 0x00002FF9 File Offset: 0x000011F9
	protected virtual void oBmxbKUNHcsovoREdIYhiDuwqVDw(int A_1)
	{
	}

	// Token: 0x06002C97 RID: 11415 RVA: 0x00002FF9 File Offset: 0x000011F9
	protected virtual void yrSfLBkTQUOscnVsBhvoTyPxAQsEA()
	{
	}

	// Token: 0x06002C98 RID: 11416 RVA: 0x0009EB30 File Offset: 0x0009CD30
	protected virtual void ngYxyAHpOoApsAMpVxqZyfKtQxUS(int A_1, TFPoaRSENLzeHHplYPnkInSKOECw.VopXKeeDjecXqtQeUIkqAaTempZhA A_2)
	{
		for (int i = 0; i < 32; i++)
		{
			int num = 1 << i;
			if ((A_1 & num) != 0)
			{
				List<TFPoaRSENLzeHHplYPnkInSKOECw.VopXKeeDjecXqtQeUIkqAaTempZhA> list;
				if (!this.trLhbXpBFPLOCiElcdTHYqRWlsSA.TryGetValue(num, out list))
				{
					list = new List<TFPoaRSENLzeHHplYPnkInSKOECw.VopXKeeDjecXqtQeUIkqAaTempZhA>();
					this.trLhbXpBFPLOCiElcdTHYqRWlsSA[num] = list;
				}
				if (!list.Contains(A_2))
				{
					list.Add(A_2);
				}
			}
		}
	}

	// Token: 0x06002C99 RID: 11417 RVA: 0x0009EB8C File Offset: 0x0009CD8C
	protected virtual void LOfikzukNwFwnKSfZljoUHGxeVSQ(int A_1, TFPoaRSENLzeHHplYPnkInSKOECw.VopXKeeDjecXqtQeUIkqAaTempZhA A_2)
	{
		for (int i = 0; i < 32; i++)
		{
			int num = 1 << i;
			List<TFPoaRSENLzeHHplYPnkInSKOECw.VopXKeeDjecXqtQeUIkqAaTempZhA> list;
			if ((A_1 & num) != 0 && this.trLhbXpBFPLOCiElcdTHYqRWlsSA.TryGetValue(num, out list))
			{
				for (int j = list.Count - 1; j >= 0; j--)
				{
					if (TFPoaRSENLzeHHplYPnkInSKOECw.VopXKeeDjecXqtQeUIkqAaTempZhA.lZfkoiRfNiNYcUpIGncTPTGvFWos(list[j], A_2))
					{
						list.RemoveAt(j);
					}
				}
			}
		}
	}

	// Token: 0x06002C9A RID: 11418 RVA: 0x0009EBEC File Offset: 0x0009CDEC
	protected virtual void EJakARZExsClnFVNlruQGBEQqzXd(int A_1)
	{
		for (int i = 0; i < 32; i++)
		{
			int num = 1 << i;
			List<TFPoaRSENLzeHHplYPnkInSKOECw.VopXKeeDjecXqtQeUIkqAaTempZhA> list;
			if ((A_1 & num) != 0 && this.trLhbXpBFPLOCiElcdTHYqRWlsSA.TryGetValue(num, out list))
			{
				int count = list.Count;
				for (int j = 0; j < count; j++)
				{
					if (list[j].LplDRUHxQfhcxerrNmLWKXiZvPsmA != 0)
					{
						this.oBmxbKUNHcsovoREdIYhiDuwqVDw(list[j].LplDRUHxQfhcxerrNmLWKXiZvPsmA);
					}
					if (list[j].rOWqNdymEvFHzaAdtUfKAtyBAsDh != null)
					{
						list[j].rOWqNdymEvFHzaAdtUfKAtyBAsDh.Clear();
					}
				}
			}
		}
	}

	// Token: 0x04001952 RID: 6482
	private VHSvqsZIGaGVcFIeminrliAGzvFf ZmRmscTdYlfQYPqgFVvBwemnuBVc;

	// Token: 0x04001953 RID: 6483
	protected readonly KeyedGlyph XjrfoUeXiWLRoamZcAlTqwGZSWoH;

	// Token: 0x04001954 RID: 6484
	private Id tHwfMmWIWFFAfCoIVbmPTvxdIvTU;

	// Token: 0x04001955 RID: 6485
	private readonly Dictionary<int, List<TFPoaRSENLzeHHplYPnkInSKOECw.VopXKeeDjecXqtQeUIkqAaTempZhA>> trLhbXpBFPLOCiElcdTHYqRWlsSA;

	// Token: 0x04001956 RID: 6486
	private bool JUdHVKLSlYoYYGQBoGaBNTOtWLvc;

	// Token: 0x0200045F RID: 1119
	protected struct VopXKeeDjecXqtQeUIkqAaTempZhA : IEquatable<TFPoaRSENLzeHHplYPnkInSKOECw.VopXKeeDjecXqtQeUIkqAaTempZhA>
	{
		// Token: 0x06002C9B RID: 11419 RVA: 0x0002251B File Offset: 0x0002071B
		public VopXKeeDjecXqtQeUIkqAaTempZhA(KeyedGlyph A_1, int A_2)
		{
			this.rOWqNdymEvFHzaAdtUfKAtyBAsDh = A_1;
			this.LplDRUHxQfhcxerrNmLWKXiZvPsmA = A_2;
		}

		// Token: 0x06002C9C RID: 11420 RVA: 0x0009EC7C File Offset: 0x0009CE7C
		public bool ILGlKBdBMpCTjOWaWhsOTntuGuJcA(object A_1)
		{
			if (!(A_1 is TFPoaRSENLzeHHplYPnkInSKOECw.VopXKeeDjecXqtQeUIkqAaTempZhA))
			{
				return false;
			}
			TFPoaRSENLzeHHplYPnkInSKOECw.VopXKeeDjecXqtQeUIkqAaTempZhA vopXKeeDjecXqtQeUIkqAaTempZhA = (TFPoaRSENLzeHHplYPnkInSKOECw.VopXKeeDjecXqtQeUIkqAaTempZhA)A_1;
			return vopXKeeDjecXqtQeUIkqAaTempZhA.rOWqNdymEvFHzaAdtUfKAtyBAsDh == this.rOWqNdymEvFHzaAdtUfKAtyBAsDh && vopXKeeDjecXqtQeUIkqAaTempZhA.LplDRUHxQfhcxerrNmLWKXiZvPsmA == this.LplDRUHxQfhcxerrNmLWKXiZvPsmA;
		}

		// Token: 0x06002C9D RID: 11421 RVA: 0x0002252B File Offset: 0x0002072B
		public int HPpIvBBgiMiiWEqJfpyHGQxyeEOZ()
		{
			return (17 * 29 + this.rOWqNdymEvFHzaAdtUfKAtyBAsDh.GetHashCode()) * 29 + this.LplDRUHxQfhcxerrNmLWKXiZvPsmA.GetHashCode();
		}

		// Token: 0x06002C9E RID: 11422 RVA: 0x0002254D File Offset: 0x0002074D
		public bool Equals(TFPoaRSENLzeHHplYPnkInSKOECw.VopXKeeDjecXqtQeUIkqAaTempZhA other)
		{
			return this.rOWqNdymEvFHzaAdtUfKAtyBAsDh == other.rOWqNdymEvFHzaAdtUfKAtyBAsDh && this.LplDRUHxQfhcxerrNmLWKXiZvPsmA == other.LplDRUHxQfhcxerrNmLWKXiZvPsmA;
		}

		// Token: 0x06002C9F RID: 11423 RVA: 0x0002256D File Offset: 0x0002076D
		public static bool lZfkoiRfNiNYcUpIGncTPTGvFWos(TFPoaRSENLzeHHplYPnkInSKOECw.VopXKeeDjecXqtQeUIkqAaTempZhA A_0, TFPoaRSENLzeHHplYPnkInSKOECw.VopXKeeDjecXqtQeUIkqAaTempZhA A_1)
		{
			return A_0.Equals(A_1);
		}

		// Token: 0x06002CA0 RID: 11424 RVA: 0x00022577 File Offset: 0x00020777
		public static bool NegZISDIxlSBqWpkadwTdNEcOCXK(TFPoaRSENLzeHHplYPnkInSKOECw.VopXKeeDjecXqtQeUIkqAaTempZhA A_0, TFPoaRSENLzeHHplYPnkInSKOECw.VopXKeeDjecXqtQeUIkqAaTempZhA A_1)
		{
			return !A_0.Equals(A_1);
		}

		// Token: 0x04001957 RID: 6487
		public KeyedGlyph rOWqNdymEvFHzaAdtUfKAtyBAsDh;

		// Token: 0x04001958 RID: 6488
		public int LplDRUHxQfhcxerrNmLWKXiZvPsmA;
	}
}
