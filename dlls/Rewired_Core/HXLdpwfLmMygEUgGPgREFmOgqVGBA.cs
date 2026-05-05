using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

// Token: 0x0200051D RID: 1309
internal sealed class HXLdpwfLmMygEUgGPgREFmOgqVGBA<\u0001> where \u0001 : class
{
	// Token: 0x17000C13 RID: 3091
	// (get) Token: 0x060035FB RID: 13819 RVA: 0x0002A413 File Offset: 0x00028613
	// (set) Token: 0x060035FC RID: 13820 RVA: 0x0002A41B File Offset: 0x0002861B
	public float yBvxoWOBRmRigdhgWbxqxZNoDqSs
	{
		get
		{
			return this.JHAsxqegtAorNdeqtQKKhlWmzcpX;
		}
		set
		{
			if (value < 0f)
			{
				value = 0f;
			}
			this.JHAsxqegtAorNdeqtQKKhlWmzcpX = value;
		}
	}

	// Token: 0x060035FD RID: 13821 RVA: 0x0002A433 File Offset: 0x00028633
	public HXLdpwfLmMygEUgGPgREFmOgqVGBA(Func<\u0001, \u0001, bool> A_1)
	{
		if (A_1 == null)
		{
			throw new ArgumentNullException();
		}
		this.nHgDRBeFhZZskJTXsYetIAOSZKxAA = A_1;
		this.JHAsxqegtAorNdeqtQKKhlWmzcpX = 60f;
		this.TSdAuWEllVzFcKBEkrXrHhLpopCsA = new IndexedDictionary<Bytes20, List<WeakReference>>();
		this.TSdAuWEllVzFcKBEkrXrHhLpopCsA.KeyComparer = EqualityComparerNoAlloc<Bytes20>.Default;
	}

	// Token: 0x060035FE RID: 13822 RVA: 0x000B60A8 File Offset: 0x000B42A8
	public \u0001 sisRxTizeCHHRjalSIxsvtVNWHCD(Bytes20 A_1, \u0001 A_2)
	{
		\u0001 result;
		if (this.AhbcNOVImFriqRufyBzueptQIzFU(A_1, A_2, out result))
		{
			return result;
		}
		this.xnbsxOCSckNIIyZiKiFycySIFrRr(A_1, A_2);
		return A_2;
	}

	// Token: 0x060035FF RID: 13823 RVA: 0x000B60CC File Offset: 0x000B42CC
	public bool AhbcNOVImFriqRufyBzueptQIzFU(Bytes20 A_1, \u0001 A_2, out \u0001 A_3)
	{
		if (A_2 == null)
		{
			A_3 = default(\u0001);
			return false;
		}
		this.bwOvnPChizYDffwuhqExcsswdUlk();
		List<WeakReference> list;
		if (!this.TSdAuWEllVzFcKBEkrXrHhLpopCsA.TryGetValue(A_1, out list))
		{
			A_3 = default(\u0001);
			return false;
		}
		for (int i = list.Count - 1; i >= 0; i--)
		{
			\u0001 u;
			if ((u = (list[i].Target as \u0001)) == null)
			{
				list.RemoveAt(i);
			}
			else if (this.nHgDRBeFhZZskJTXsYetIAOSZKxAA(A_2, u))
			{
				A_3 = u;
				return true;
			}
		}
		A_3 = default(\u0001);
		return false;
	}

	// Token: 0x06003600 RID: 13824 RVA: 0x000B6164 File Offset: 0x000B4364
	public void xnbsxOCSckNIIyZiKiFycySIFrRr(Bytes20 A_1, \u0001 A_2)
	{
		if (A_2 == null)
		{
			return;
		}
		this.bwOvnPChizYDffwuhqExcsswdUlk();
		List<WeakReference> list;
		if (!this.TSdAuWEllVzFcKBEkrXrHhLpopCsA.TryGetValue(A_1, out list))
		{
			list = new List<WeakReference>();
			this.TSdAuWEllVzFcKBEkrXrHhLpopCsA.Add(A_1, list);
		}
		list.Add(new WeakReference(A_2, false));
	}

	// Token: 0x06003601 RID: 13825 RVA: 0x000B61B8 File Offset: 0x000B43B8
	public void TFxvHtUeJlkIfNsqNiClRLEITXcl()
	{
		for (int i = this.TSdAuWEllVzFcKBEkrXrHhLpopCsA.Count - 1; i >= 0; i--)
		{
			List<WeakReference> list = this.TSdAuWEllVzFcKBEkrXrHhLpopCsA[i];
			for (int j = list.Count - 1; j >= 0; j--)
			{
				if (!list[j].IsAlive)
				{
					list.RemoveAt(j);
				}
			}
			if (list.Count == 0)
			{
				this.TSdAuWEllVzFcKBEkrXrHhLpopCsA.RemoveAt(i);
			}
		}
		this.NvLlToGiJUyjsTniPwYyCQKWDkUH = ReInput.unscaledTime + (double)this.yBvxoWOBRmRigdhgWbxqxZNoDqSs;
	}

	// Token: 0x06003602 RID: 13826 RVA: 0x0002A471 File Offset: 0x00028671
	private void bwOvnPChizYDffwuhqExcsswdUlk()
	{
		if (this.JHAsxqegtAorNdeqtQKKhlWmzcpX == 0f)
		{
			return;
		}
		if (ReInput.unscaledTime < this.NvLlToGiJUyjsTniPwYyCQKWDkUH)
		{
			return;
		}
		this.TFxvHtUeJlkIfNsqNiClRLEITXcl();
	}

	// Token: 0x04001C71 RID: 7281
	private const float rIWEPBUGVoPlqaQRBhbWutxgbTbq = 60f;

	// Token: 0x04001C72 RID: 7282
	private readonly IndexedDictionary<Bytes20, List<WeakReference>> TSdAuWEllVzFcKBEkrXrHhLpopCsA;

	// Token: 0x04001C73 RID: 7283
	private float JHAsxqegtAorNdeqtQKKhlWmzcpX;

	// Token: 0x04001C74 RID: 7284
	private double NvLlToGiJUyjsTniPwYyCQKWDkUH;

	// Token: 0x04001C75 RID: 7285
	private Func<\u0001, \u0001, bool> nHgDRBeFhZZskJTXsYetIAOSZKxAA;
}
