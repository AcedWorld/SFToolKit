using System;
using System.Collections.Generic;
using Rewired.Internal.Localization;
using Rewired.Utils.Classes.Data;

// Token: 0x0200043C RID: 1084
internal abstract class NQZrJYyIfrsTaVgTuJTwbwduHHZF : qRARPoZhenAEzvKQshZvLFcmqQCG
{
	// Token: 0x17000A55 RID: 2645
	// (get) Token: 0x06002B98 RID: 11160 RVA: 0x00021750 File Offset: 0x0001F950
	protected bool HRSPcGZKkuaOkhVkJNJZUXXeBeGMA
	{
		get
		{
			return this.tVSvuGIkoYaItCKbeFNfmRXbeppGb;
		}
	}

	// Token: 0x17000A56 RID: 2646
	// (get) Token: 0x06002B99 RID: 11161
	public abstract string QGZglKMnBTLJKJKOPknbgTZKPbAO { get; }

	// Token: 0x06002B9A RID: 11162 RVA: 0x00021758 File Offset: 0x0001F958
	protected NQZrJYyIfrsTaVgTuJTwbwduHHZF()
	{
		this.uubDSofrIpUZxAZHdyfXGFjMsyeQA = new LocalizedString();
		this.lFTBckJrphccDhPSjIEqHYGTPkyXB = new Dictionary<int, List<NQZrJYyIfrsTaVgTuJTwbwduHHZF.EGBzchAhewhpCrKddGQjLwFnEIPQ>>();
	}

	// Token: 0x06002B9B RID: 11163 RVA: 0x00021776 File Offset: 0x0001F976
	protected NQZrJYyIfrsTaVgTuJTwbwduHHZF(lcAibZuWMerLyEDicYNSneVLTvsj A_1) : this()
	{
		if (A_1 == null)
		{
			throw new ArgumentNullException("dataSource");
		}
		this.IcsDeLdjtuFPaSDdILPwCLgBrdAIc = A_1;
	}

	// Token: 0x06002B9C RID: 11164 RVA: 0x00021793 File Offset: 0x0001F993
	public void xMfMePLzqTSjhGUqGxmRgKZjDaigA()
	{
		this.JHnqJMbvGwQvungcRzXxSxEERvHT();
		if (LocalizationManager.isEnabled && LocalizationManager.autoPrefetch)
		{
			this.kYYiwYRDFqXuOawzHkdIQMRjCpuI();
		}
	}

	// Token: 0x06002B9D RID: 11165 RVA: 0x000217AF File Offset: 0x0001F9AF
	protected virtual void JHnqJMbvGwQvungcRzXxSxEERvHT()
	{
		this.TzVBdykRoTgbtBaaPwKWZjcgDRyT();
		this.gXTVNypHZfdBWIUJDeuwjkfgUjVcA();
		LocalizationManager.Add(this, ref this.xJbabBbCVmSuNNDtrIIVwLZJeZOtA);
		this.tVSvuGIkoYaItCKbeFNfmRXbeppGb = true;
	}

	// Token: 0x06002B9E RID: 11166 RVA: 0x000217D0 File Offset: 0x0001F9D0
	public virtual void TzVBdykRoTgbtBaaPwKWZjcgDRyT()
	{
		this.cANIeNjhlRiBgKlUspvGjmCXEmUGA();
		LocalizationManager.Remove(ref this.xJbabBbCVmSuNNDtrIIVwLZJeZOtA);
		this.tVSvuGIkoYaItCKbeFNfmRXbeppGb = false;
	}

	// Token: 0x06002B9F RID: 11167 RVA: 0x000217EB File Offset: 0x0001F9EB
	public virtual void PZWBGaYSuZufYilwbeAEIstyhayX(lcAibZuWMerLyEDicYNSneVLTvsj A_1)
	{
		if (A_1 == null)
		{
			throw new ArgumentNullException("value");
		}
		if (A_1 == this.IcsDeLdjtuFPaSDdILPwCLgBrdAIc)
		{
			return;
		}
		if (this.IcsDeLdjtuFPaSDdILPwCLgBrdAIc != null)
		{
			this.cANIeNjhlRiBgKlUspvGjmCXEmUGA();
		}
		this.IcsDeLdjtuFPaSDdILPwCLgBrdAIc = A_1;
		this.xMfMePLzqTSjhGUqGxmRgKZjDaigA();
	}

	// Token: 0x06002BA0 RID: 11168 RVA: 0x00021820 File Offset: 0x0001FA20
	public virtual void arHuKiMTAYIZtlKcEernIkmXCLMl()
	{
		this.uubDSofrIpUZxAZHdyfXGFjMsyeQA.Clear();
	}

	// Token: 0x06002BA1 RID: 11169 RVA: 0x00021820 File Offset: 0x0001FA20
	public virtual void humgPpaprOCTJdMoIVXMnKxZPobtb()
	{
		this.uubDSofrIpUZxAZHdyfXGFjMsyeQA.Clear();
	}

	// Token: 0x06002BA2 RID: 11170 RVA: 0x00021820 File Offset: 0x0001FA20
	public virtual void OlcAFIbuEHvUomQdyRvLXKoljCWJ()
	{
		this.uubDSofrIpUZxAZHdyfXGFjMsyeQA.Clear();
	}

	// Token: 0x06002BA3 RID: 11171 RVA: 0x0009CCF8 File Offset: 0x0009AEF8
	public virtual bool BlTKThqPfnWgppHXaUsFTRxHgLOL(NQZrJYyIfrsTaVgTuJTwbwduHHZF A_1, bool A_2)
	{
		if (A_1 == null)
		{
			return false;
		}
		if (!object.Equals(base.GetType(), A_1.GetType()))
		{
			return false;
		}
		if (this.IcsDeLdjtuFPaSDdILPwCLgBrdAIc == null != (A_1.IcsDeLdjtuFPaSDdILPwCLgBrdAIc == null))
		{
			return false;
		}
		if (this.IcsDeLdjtuFPaSDdILPwCLgBrdAIc != null)
		{
			if (!string.Equals(this.IcsDeLdjtuFPaSDdILPwCLgBrdAIc.keyCategory, A_1.IcsDeLdjtuFPaSDdILPwCLgBrdAIc.keyCategory, StringComparison.Ordinal) || !string.Equals(this.IcsDeLdjtuFPaSDdILPwCLgBrdAIc.scriptingName, A_1.IcsDeLdjtuFPaSDdILPwCLgBrdAIc.scriptingName, StringComparison.Ordinal) || !string.Equals(this.IcsDeLdjtuFPaSDdILPwCLgBrdAIc.key, A_1.IcsDeLdjtuFPaSDdILPwCLgBrdAIc.key, StringComparison.Ordinal))
			{
				return false;
			}
			if (A_2 && !string.Equals(this.IcsDeLdjtuFPaSDdILPwCLgBrdAIc.nonLocalizedDescriptiveName, A_1.IcsDeLdjtuFPaSDdILPwCLgBrdAIc.nonLocalizedDescriptiveName, StringComparison.Ordinal))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06002BA4 RID: 11172 RVA: 0x0002182D File Offset: 0x0001FA2D
	protected virtual void cANIeNjhlRiBgKlUspvGjmCXEmUGA()
	{
		this.uubDSofrIpUZxAZHdyfXGFjMsyeQA.Clear();
		this.lFTBckJrphccDhPSjIEqHYGTPkyXB.Clear();
	}

	// Token: 0x06002BA5 RID: 11173 RVA: 0x00021845 File Offset: 0x0001FA45
	protected lcAibZuWMerLyEDicYNSneVLTvsj xbbWXoCQKxOHngdZGOTYOmmzCnhCA()
	{
		return this.IcsDeLdjtuFPaSDdILPwCLgBrdAIc;
	}

	// Token: 0x06002BA6 RID: 11174 RVA: 0x0002184D File Offset: 0x0001FA4D
	protected virtual void kYYiwYRDFqXuOawzHkdIQMRjCpuI()
	{
		this.QGZglKMnBTLJKJKOPknbgTZKPbAO;
	}

	// Token: 0x06002BA7 RID: 11175 RVA: 0x00021856 File Offset: 0x0001FA56
	void qRARPoZhenAEzvKQshZvLFcmqQCG.Localize()
	{
		this.kYYiwYRDFqXuOawzHkdIQMRjCpuI();
	}

	// Token: 0x06002BA8 RID: 11176 RVA: 0x00002FF9 File Offset: 0x000011F9
	protected virtual void vBjNjTqgTsRHejvVcOVHdjfbfXEW(int A_1)
	{
	}

	// Token: 0x06002BA9 RID: 11177 RVA: 0x00002FF9 File Offset: 0x000011F9
	protected virtual void gXTVNypHZfdBWIUJDeuwjkfgUjVcA()
	{
	}

	// Token: 0x06002BAA RID: 11178 RVA: 0x0009CDC0 File Offset: 0x0009AFC0
	protected virtual void gqpcPKtUOiXOvrMUQHHfwoyseJskA(int A_1, NQZrJYyIfrsTaVgTuJTwbwduHHZF.EGBzchAhewhpCrKddGQjLwFnEIPQ A_2)
	{
		for (int i = 0; i < 32; i++)
		{
			int num = 1 << i;
			if ((A_1 & num) != 0)
			{
				List<NQZrJYyIfrsTaVgTuJTwbwduHHZF.EGBzchAhewhpCrKddGQjLwFnEIPQ> list;
				if (!this.lFTBckJrphccDhPSjIEqHYGTPkyXB.TryGetValue(num, out list))
				{
					list = new List<NQZrJYyIfrsTaVgTuJTwbwduHHZF.EGBzchAhewhpCrKddGQjLwFnEIPQ>();
					this.lFTBckJrphccDhPSjIEqHYGTPkyXB[num] = list;
				}
				if (!list.Contains(A_2))
				{
					list.Add(A_2);
				}
			}
		}
	}

	// Token: 0x06002BAB RID: 11179 RVA: 0x0009CE1C File Offset: 0x0009B01C
	protected virtual void qmnszfSVVyFVQbdBbKOwxUbabaZK(int A_1, NQZrJYyIfrsTaVgTuJTwbwduHHZF.EGBzchAhewhpCrKddGQjLwFnEIPQ A_2)
	{
		for (int i = 0; i < 32; i++)
		{
			int num = 1 << i;
			List<NQZrJYyIfrsTaVgTuJTwbwduHHZF.EGBzchAhewhpCrKddGQjLwFnEIPQ> list;
			if ((A_1 & num) != 0 && this.lFTBckJrphccDhPSjIEqHYGTPkyXB.TryGetValue(num, out list))
			{
				for (int j = list.Count - 1; j >= 0; j--)
				{
					if (NQZrJYyIfrsTaVgTuJTwbwduHHZF.EGBzchAhewhpCrKddGQjLwFnEIPQ.QPBzgnBuJQJvCqmgxHvVhafGqprYA(list[j], A_2))
					{
						list.RemoveAt(j);
					}
				}
			}
		}
	}

	// Token: 0x06002BAC RID: 11180 RVA: 0x0009CE7C File Offset: 0x0009B07C
	protected virtual void EIkuXICcIAFYZGyejhTzuxVFxklg(int A_1)
	{
		for (int i = 0; i < 32; i++)
		{
			int num = 1 << i;
			List<NQZrJYyIfrsTaVgTuJTwbwduHHZF.EGBzchAhewhpCrKddGQjLwFnEIPQ> list;
			if ((A_1 & num) != 0 && this.lFTBckJrphccDhPSjIEqHYGTPkyXB.TryGetValue(num, out list))
			{
				int count = list.Count;
				for (int j = 0; j < count; j++)
				{
					if (list[j].reATftxmOOPeWIfWHXVmxchIcGliA != 0)
					{
						this.vBjNjTqgTsRHejvVcOVHdjfbfXEW(list[j].reATftxmOOPeWIfWHXVmxchIcGliA);
					}
					if (list[j].WiPbCtmSOFwAmhbzWHNhKOCqUosg != null)
					{
						list[j].WiPbCtmSOFwAmhbzWHNhKOCqUosg.Clear();
					}
				}
			}
		}
	}

	// Token: 0x040018CC RID: 6348
	private lcAibZuWMerLyEDicYNSneVLTvsj IcsDeLdjtuFPaSDdILPwCLgBrdAIc;

	// Token: 0x040018CD RID: 6349
	protected readonly LocalizedString uubDSofrIpUZxAZHdyfXGFjMsyeQA;

	// Token: 0x040018CE RID: 6350
	private Id xJbabBbCVmSuNNDtrIIVwLZJeZOtA;

	// Token: 0x040018CF RID: 6351
	private readonly Dictionary<int, List<NQZrJYyIfrsTaVgTuJTwbwduHHZF.EGBzchAhewhpCrKddGQjLwFnEIPQ>> lFTBckJrphccDhPSjIEqHYGTPkyXB;

	// Token: 0x040018D0 RID: 6352
	private bool tVSvuGIkoYaItCKbeFNfmRXbeppGb;

	// Token: 0x0200043D RID: 1085
	protected struct EGBzchAhewhpCrKddGQjLwFnEIPQ : IEquatable<NQZrJYyIfrsTaVgTuJTwbwduHHZF.EGBzchAhewhpCrKddGQjLwFnEIPQ>
	{
		// Token: 0x06002BAD RID: 11181 RVA: 0x0002185E File Offset: 0x0001FA5E
		public EGBzchAhewhpCrKddGQjLwFnEIPQ(LocalizedString A_1, int A_2)
		{
			this.WiPbCtmSOFwAmhbzWHNhKOCqUosg = A_1;
			this.reATftxmOOPeWIfWHXVmxchIcGliA = A_2;
		}

		// Token: 0x06002BAE RID: 11182 RVA: 0x0009CF0C File Offset: 0x0009B10C
		public bool BVVykyxXlutXCtrCuHqoVfErcgxV(object A_1)
		{
			if (!(A_1 is NQZrJYyIfrsTaVgTuJTwbwduHHZF.EGBzchAhewhpCrKddGQjLwFnEIPQ))
			{
				return false;
			}
			NQZrJYyIfrsTaVgTuJTwbwduHHZF.EGBzchAhewhpCrKddGQjLwFnEIPQ egbzchAhewhpCrKddGQjLwFnEIPQ = (NQZrJYyIfrsTaVgTuJTwbwduHHZF.EGBzchAhewhpCrKddGQjLwFnEIPQ)A_1;
			return egbzchAhewhpCrKddGQjLwFnEIPQ.WiPbCtmSOFwAmhbzWHNhKOCqUosg == this.WiPbCtmSOFwAmhbzWHNhKOCqUosg && egbzchAhewhpCrKddGQjLwFnEIPQ.reATftxmOOPeWIfWHXVmxchIcGliA == this.reATftxmOOPeWIfWHXVmxchIcGliA;
		}

		// Token: 0x06002BAF RID: 11183 RVA: 0x0002186E File Offset: 0x0001FA6E
		public int EXsIgpXSGPwyDTwcYqTmeIkgcxeB()
		{
			return (17 * 29 + this.WiPbCtmSOFwAmhbzWHNhKOCqUosg.GetHashCode()) * 29 + this.reATftxmOOPeWIfWHXVmxchIcGliA.GetHashCode();
		}

		// Token: 0x06002BB0 RID: 11184 RVA: 0x00021890 File Offset: 0x0001FA90
		public bool Equals(NQZrJYyIfrsTaVgTuJTwbwduHHZF.EGBzchAhewhpCrKddGQjLwFnEIPQ other)
		{
			return this.WiPbCtmSOFwAmhbzWHNhKOCqUosg == other.WiPbCtmSOFwAmhbzWHNhKOCqUosg && this.reATftxmOOPeWIfWHXVmxchIcGliA == other.reATftxmOOPeWIfWHXVmxchIcGliA;
		}

		// Token: 0x06002BB1 RID: 11185 RVA: 0x000218B0 File Offset: 0x0001FAB0
		public static bool QPBzgnBuJQJvCqmgxHvVhafGqprYA(NQZrJYyIfrsTaVgTuJTwbwduHHZF.EGBzchAhewhpCrKddGQjLwFnEIPQ A_0, NQZrJYyIfrsTaVgTuJTwbwduHHZF.EGBzchAhewhpCrKddGQjLwFnEIPQ A_1)
		{
			return A_0.Equals(A_1);
		}

		// Token: 0x06002BB2 RID: 11186 RVA: 0x000218BA File Offset: 0x0001FABA
		public static bool kfAYGlTQoMeoajylRMvLSxpCKUTg(NQZrJYyIfrsTaVgTuJTwbwduHHZF.EGBzchAhewhpCrKddGQjLwFnEIPQ A_0, NQZrJYyIfrsTaVgTuJTwbwduHHZF.EGBzchAhewhpCrKddGQjLwFnEIPQ A_1)
		{
			return !A_0.Equals(A_1);
		}

		// Token: 0x040018D1 RID: 6353
		public LocalizedString WiPbCtmSOFwAmhbzWHNhKOCqUosg;

		// Token: 0x040018D2 RID: 6354
		public int reATftxmOOPeWIfWHXVmxchIcGliA;
	}
}
