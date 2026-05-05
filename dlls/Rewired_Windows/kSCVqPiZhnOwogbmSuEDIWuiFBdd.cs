using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

// Token: 0x020000D2 RID: 210
[DefaultMember("Item")]
internal class kSCVqPiZhnOwogbmSuEDIWuiFBdd<\u0001> : gJnxonEFbDOjDsVjTjdRLDyOABFn, ICollection<\u0001>, IEnumerable<\u0001>, IEnumerable, YMCuMBXszieSrxmHiyVqzbCVajwc<!0>, DOTChjSAdMIaBKisoADNVWqVHbrW<!0> where \u0001 : xHELJppslUhfqfJUjeWUgelmcqYcA
{
	// Token: 0x060006FC RID: 1788 RVA: 0x00014B89 File Offset: 0x00012D89
	public kSCVqPiZhnOwogbmSuEDIWuiFBdd(CSdTAxmcdEqsJycjIssPCexJQcDP A_1, Func<IntPtr, uint> A_2, Func<IntPtr, uint, \u0001> A_3) : base(A_1)
	{
		this.xmTIvodXzRhtjOQMyLaigblBbALL = A_2;
		this.kovJPKRYMrmERofdYwGgIYLeRqjt = A_3;
	}

	// Token: 0x060006FD RID: 1789 RVA: 0x00036628 File Offset: 0x00034828
	public int zyPSSNURwphCSUerGNkHDKZGZuxq(\u0001 A_1)
	{
		int count = this.Count;
		for (int i = 0; i < count; i++)
		{
			\u0001 x = this.CYGOwSmrEZYHftHgWfRSJsUVBBGL(i);
			bool flag = EqualityComparer<\u0001>.Default.Equals(x, A_1);
			x.GUYtzgHLQVggrCxIzRYXKylefCDA();
			if (flag)
			{
				return i;
			}
		}
		return -1;
	}

	// Token: 0x060006FE RID: 1790 RVA: 0x00014BA0 File Offset: 0x00012DA0
	public void Add(\u0001 item)
	{
		throw new NotImplementedException("Collection is read-only!");
	}

	// Token: 0x060006FF RID: 1791 RVA: 0x00014BA0 File Offset: 0x00012DA0
	public void Clear()
	{
		throw new NotImplementedException("Collection is read-only!");
	}

	// Token: 0x06000700 RID: 1792 RVA: 0x00014BAC File Offset: 0x00012DAC
	public bool Contains(\u0001 item)
	{
		return this.zyPSSNURwphCSUerGNkHDKZGZuxq(item) >= 0;
	}

	// Token: 0x06000701 RID: 1793 RVA: 0x00036670 File Offset: 0x00034870
	public void CopyTo(\u0001[] array, int arrayIndex)
	{
		if (array == null)
		{
			throw new ArgumentNullException("array");
		}
		if (arrayIndex < 0 || arrayIndex >= array.Length)
		{
			throw new ArgumentOutOfRangeException("arrayIndex");
		}
		int count = this.Count;
		for (int i = 0; i < count; i++)
		{
			array[i + arrayIndex] = this.CYGOwSmrEZYHftHgWfRSJsUVBBGL(i);
		}
	}

	// Token: 0x17000171 RID: 369
	// (get) Token: 0x06000702 RID: 1794 RVA: 0x00014BBB File Offset: 0x00012DBB
	public int Count
	{
		get
		{
			if (!this.PtyBOyddJtqYbCNjnqkyAVHZDMfO.ayMhkOUmzXKyTnydkQCYJxMWLQZP)
			{
				return 0;
			}
			return (int)this.xmTIvodXzRhtjOQMyLaigblBbALL(this.PtyBOyddJtqYbCNjnqkyAVHZDMfO.bSpbrrqmwZiUieQwcIjJFgWqXeXJ);
		}
	}

	// Token: 0x17000172 RID: 370
	// (get) Token: 0x06000703 RID: 1795 RVA: 0x0001164A File Offset: 0x0000F84A
	public bool IsReadOnly
	{
		get
		{
			return true;
		}
	}

	// Token: 0x06000704 RID: 1796 RVA: 0x00014BA0 File Offset: 0x00012DA0
	public bool Remove(\u0001 item)
	{
		throw new NotImplementedException("Collection is read-only!");
	}

	// Token: 0x06000705 RID: 1797 RVA: 0x00014BE2 File Offset: 0x00012DE2
	public IEnumerator<\u0001> GetEnumerator()
	{
		return new kSCVqPiZhnOwogbmSuEDIWuiFBdd<\u0001>.UfFlYuJAnALiAEZqEVPumnSxytqS(this);
	}

	// Token: 0x06000706 RID: 1798 RVA: 0x00014BEF File Offset: 0x00012DEF
	IEnumerator IEnumerable.GetEnumerator()
	{
		return this.GetEnumerator();
	}

	// Token: 0x06000707 RID: 1799 RVA: 0x00014BA0 File Offset: 0x00012DA0
	public void SxcXyHFelcSrnLBfQFIwcdKsljNT(int A_1, \u0001 A_2)
	{
		throw new NotImplementedException("Collection is read-only!");
	}

	// Token: 0x06000708 RID: 1800 RVA: 0x00014BA0 File Offset: 0x00012DA0
	public void pPHmILmYUitqGJYmevQvHcllBLGg(int A_1)
	{
		throw new NotImplementedException("Collection is read-only!");
	}

	// Token: 0x17000173 RID: 371
	// (get) Token: 0x06000709 RID: 1801 RVA: 0x000366C4 File Offset: 0x000348C4
	// (set) Token: 0x0600070A RID: 1802 RVA: 0x00014BA0 File Offset: 0x00012DA0
	public \u0001 eJQsBEJOSeGHUzdvLeTquwyYDSiAA
	{
		get
		{
			if (A_1 < 0 || A_1 >= this.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (!this.PtyBOyddJtqYbCNjnqkyAVHZDMfO.ayMhkOUmzXKyTnydkQCYJxMWLQZP)
			{
				return default(\u0001);
			}
			return this.kovJPKRYMrmERofdYwGgIYLeRqjt(this.PtyBOyddJtqYbCNjnqkyAVHZDMfO.bSpbrrqmwZiUieQwcIjJFgWqXeXJ, (uint)A_1);
		}
		set
		{
			throw new NotImplementedException("Collection is read-only!");
		}
	}

	// Token: 0x040007FF RID: 2047
	private Func<IntPtr, uint> xmTIvodXzRhtjOQMyLaigblBbALL;

	// Token: 0x04000800 RID: 2048
	private Func<IntPtr, uint, \u0001> kovJPKRYMrmERofdYwGgIYLeRqjt;

	// Token: 0x020000D3 RID: 211
	public struct UfFlYuJAnALiAEZqEVPumnSxytqS : IEnumerator<\u0001>, IEnumerator, IDisposable
	{
		// Token: 0x0600070B RID: 1803 RVA: 0x00014BF7 File Offset: 0x00012DF7
		internal UfFlYuJAnALiAEZqEVPumnSxytqS(kSCVqPiZhnOwogbmSuEDIWuiFBdd<\u0001> A_1)
		{
			this.CLIGjKaMMYSGtDCRoDazhptEhpBlc = A_1;
			this.hPmqvQbYDXGZOQMXwKXyhNfCDhHe = 0;
			this.skQAPXMGyhXPPftUAukyeJUfvBkj = default(\u0001);
		}

		// Token: 0x0600070C RID: 1804 RVA: 0x000116E9 File Offset: 0x0000F8E9
		public void Dispose()
		{
		}

		// Token: 0x0600070D RID: 1805 RVA: 0x00036718 File Offset: 0x00034918
		public bool MoveNext()
		{
			kSCVqPiZhnOwogbmSuEDIWuiFBdd<\u0001> cligjKaMMYSGtDCRoDazhptEhpBlc = this.CLIGjKaMMYSGtDCRoDazhptEhpBlc;
			if (this.hPmqvQbYDXGZOQMXwKXyhNfCDhHe < cligjKaMMYSGtDCRoDazhptEhpBlc.Count)
			{
				this.skQAPXMGyhXPPftUAukyeJUfvBkj = cligjKaMMYSGtDCRoDazhptEhpBlc.CYGOwSmrEZYHftHgWfRSJsUVBBGL(this.hPmqvQbYDXGZOQMXwKXyhNfCDhHe);
				this.hPmqvQbYDXGZOQMXwKXyhNfCDhHe++;
				return true;
			}
			return this.JZKTQpJplDuCagLVrOGlWpoHazZcA();
		}

		// Token: 0x0600070E RID: 1806 RVA: 0x00014C13 File Offset: 0x00012E13
		private bool JZKTQpJplDuCagLVrOGlWpoHazZcA()
		{
			this.hPmqvQbYDXGZOQMXwKXyhNfCDhHe = this.CLIGjKaMMYSGtDCRoDazhptEhpBlc.Count + 1;
			this.skQAPXMGyhXPPftUAukyeJUfvBkj = default(\u0001);
			return false;
		}

		// Token: 0x17000174 RID: 372
		// (get) Token: 0x0600070F RID: 1807 RVA: 0x00014C35 File Offset: 0x00012E35
		public \u0001 Current
		{
			get
			{
				return this.skQAPXMGyhXPPftUAukyeJUfvBkj;
			}
		}

		// Token: 0x17000175 RID: 373
		// (get) Token: 0x06000710 RID: 1808 RVA: 0x00014C3D File Offset: 0x00012E3D
		object IEnumerator.Current
		{
			get
			{
				if (this.hPmqvQbYDXGZOQMXwKXyhNfCDhHe == 0 || this.hPmqvQbYDXGZOQMXwKXyhNfCDhHe == this.CLIGjKaMMYSGtDCRoDazhptEhpBlc.Count + 1)
				{
					throw new InvalidOperationException();
				}
				return this.Current;
			}
		}

		// Token: 0x06000711 RID: 1809 RVA: 0x00014C6D File Offset: 0x00012E6D
		void IEnumerator.Reset()
		{
			this.hPmqvQbYDXGZOQMXwKXyhNfCDhHe = 0;
			this.skQAPXMGyhXPPftUAukyeJUfvBkj = default(\u0001);
		}

		// Token: 0x04000801 RID: 2049
		private kSCVqPiZhnOwogbmSuEDIWuiFBdd<\u0001> CLIGjKaMMYSGtDCRoDazhptEhpBlc;

		// Token: 0x04000802 RID: 2050
		private int hPmqvQbYDXGZOQMXwKXyhNfCDhHe;

		// Token: 0x04000803 RID: 2051
		private \u0001 skQAPXMGyhXPPftUAukyeJUfvBkj;
	}
}
