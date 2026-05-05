using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

// Token: 0x020000B5 RID: 181
[DefaultMember("Item")]
internal sealed class sdyBkQbVNgTvqQIRQLDqmAVyHybcb<\u0001> : YMCuMBXszieSrxmHiyVqzbCVajwc<\u0001>, IEnumerable<\u0001>, IEnumerable, DOTChjSAdMIaBKisoADNVWqVHbrW<\u0001>
{
	// Token: 0x06000671 RID: 1649 RVA: 0x00014559 File Offset: 0x00012759
	public sdyBkQbVNgTvqQIRQLDqmAVyHybcb()
	{
		this.GfdeUHQeuJZmYYLoWAUWNoReakQn = new List<\u0001>();
	}

	// Token: 0x06000672 RID: 1650 RVA: 0x0001456C File Offset: 0x0001276C
	public sdyBkQbVNgTvqQIRQLDqmAVyHybcb(int A_1)
	{
		this.GfdeUHQeuJZmYYLoWAUWNoReakQn = new List<\u0001>(A_1);
	}

	// Token: 0x06000673 RID: 1651 RVA: 0x00014580 File Offset: 0x00012780
	public sdyBkQbVNgTvqQIRQLDqmAVyHybcb(ICollection<\u0001> A_1)
	{
		this.GfdeUHQeuJZmYYLoWAUWNoReakQn = new List<\u0001>(A_1);
	}

	// Token: 0x17000152 RID: 338
	// (get) Token: 0x06000674 RID: 1652 RVA: 0x00014594 File Offset: 0x00012794
	public \u0001 eJQsBEJOSeGHUzdvLeTquwyYDSiAA
	{
		get
		{
			return this.GfdeUHQeuJZmYYLoWAUWNoReakQn[A_1];
		}
	}

	// Token: 0x06000675 RID: 1653 RVA: 0x000145A2 File Offset: 0x000127A2
	public IEnumerator<\u0001> GetEnumerator()
	{
		return this.GfdeUHQeuJZmYYLoWAUWNoReakQn.GetEnumerator();
	}

	// Token: 0x06000676 RID: 1654 RVA: 0x000145A2 File Offset: 0x000127A2
	IEnumerator IEnumerable.GetEnumerator()
	{
		return this.GfdeUHQeuJZmYYLoWAUWNoReakQn.GetEnumerator();
	}

	// Token: 0x17000153 RID: 339
	// (get) Token: 0x06000677 RID: 1655 RVA: 0x000145B4 File Offset: 0x000127B4
	public int Count
	{
		get
		{
			return this.GfdeUHQeuJZmYYLoWAUWNoReakQn.Count;
		}
	}

	// Token: 0x040006B2 RID: 1714
	private readonly List<\u0001> GfdeUHQeuJZmYYLoWAUWNoReakQn;
}
