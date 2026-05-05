using System;

// Token: 0x020000A1 RID: 161
internal struct CSdTAxmcdEqsJycjIssPCexJQcDP : IEquatable<CSdTAxmcdEqsJycjIssPCexJQcDP>
{
	// Token: 0x17000118 RID: 280
	// (get) Token: 0x0600059F RID: 1439 RVA: 0x00013CF6 File Offset: 0x00011EF6
	public bool ayMhkOUmzXKyTnydkQCYJxMWLQZP
	{
		get
		{
			return this.bSpbrrqmwZiUieQwcIjJFgWqXeXJ != IntPtr.Zero;
		}
	}

	// Token: 0x060005A0 RID: 1440 RVA: 0x00013D08 File Offset: 0x00011F08
	public CSdTAxmcdEqsJycjIssPCexJQcDP(IntPtr A_1)
	{
		this.bSpbrrqmwZiUieQwcIjJFgWqXeXJ = A_1;
	}

	// Token: 0x060005A1 RID: 1441 RVA: 0x00013D11 File Offset: 0x00011F11
	public CSdTAxmcdEqsJycjIssPCexJQcDP(tAZOAUSqNiGMUGbgZXbKxgMiCPZRA A_1)
	{
		this.bSpbrrqmwZiUieQwcIjJFgWqXeXJ = A_1.ZrbWtJlvDpCfrrAaJDuKAordpvVlA;
	}

	// Token: 0x060005A2 RID: 1442 RVA: 0x00013D20 File Offset: 0x00011F20
	public void WLKUJIjCfgWmSUADPNBYURVtmQxe()
	{
		if (this.bSpbrrqmwZiUieQwcIjJFgWqXeXJ == IntPtr.Zero)
		{
			return;
		}
		OTylkQqSSfezJYDMKEvvfyLhOqsl.KZulFwSnbQcIOgYOVWyJFMZkIJpT(this.bSpbrrqmwZiUieQwcIjJFgWqXeXJ);
		this.bSpbrrqmwZiUieQwcIjJFgWqXeXJ = IntPtr.Zero;
	}

	// Token: 0x060005A3 RID: 1443 RVA: 0x00013D4C File Offset: 0x00011F4C
	public static IntPtr xiXPkdKsQlbjxPUYZoBlxzlGhIml(CSdTAxmcdEqsJycjIssPCexJQcDP A_0)
	{
		return A_0.bSpbrrqmwZiUieQwcIjJFgWqXeXJ;
	}

	// Token: 0x060005A4 RID: 1444 RVA: 0x00013D54 File Offset: 0x00011F54
	public bool bANDoeBBfobKrsjntJhpOfmLFulL(object A_1)
	{
		return A_1 is CSdTAxmcdEqsJycjIssPCexJQcDP && ((CSdTAxmcdEqsJycjIssPCexJQcDP)A_1).bSpbrrqmwZiUieQwcIjJFgWqXeXJ == this.bSpbrrqmwZiUieQwcIjJFgWqXeXJ;
	}

	// Token: 0x060005A5 RID: 1445 RVA: 0x00013D76 File Offset: 0x00011F76
	public int NNuoSXszfZgrJhOlUHfTIjIiJkwfb()
	{
		return base.GetHashCode();
	}

	// Token: 0x060005A6 RID: 1446 RVA: 0x00013D88 File Offset: 0x00011F88
	public bool Equals(CSdTAxmcdEqsJycjIssPCexJQcDP other)
	{
		return this.bSpbrrqmwZiUieQwcIjJFgWqXeXJ == other.bSpbrrqmwZiUieQwcIjJFgWqXeXJ;
	}

	// Token: 0x060005A7 RID: 1447 RVA: 0x00013D9B File Offset: 0x00011F9B
	public static bool jeGmTWNgobSMjdzfhOuwgJMzQLSA(CSdTAxmcdEqsJycjIssPCexJQcDP A_0, CSdTAxmcdEqsJycjIssPCexJQcDP A_1)
	{
		return A_0.Equals(A_1);
	}

	// Token: 0x060005A8 RID: 1448 RVA: 0x00013DA5 File Offset: 0x00011FA5
	public static bool WCpbomCjVaPRdJbRlqnghBDTipPAA(CSdTAxmcdEqsJycjIssPCexJQcDP A_0, CSdTAxmcdEqsJycjIssPCexJQcDP A_1)
	{
		return !A_0.Equals(A_1);
	}

	// Token: 0x04000636 RID: 1590
	public IntPtr bSpbrrqmwZiUieQwcIjJFgWqXeXJ;
}
