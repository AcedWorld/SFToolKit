using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using Rewired.Utils;

// Token: 0x020000E6 RID: 230
[DefaultMember("Item")]
internal class eJwThxqtVUOqVDeqWCSbjxgGOJtQA : IEnumerable<byte>, IEnumerable, IDisposable
{
	// Token: 0x1700018D RID: 397
	// (get) Token: 0x06000821 RID: 2081 RVA: 0x00015B62 File Offset: 0x00013D62
	public int MSxYnxllGqNnWcsVdrpFWfaCyBsw
	{
		get
		{
			return this.zuhdGRcuxqpZdhIJNTAeRbqHCNZJA;
		}
	}

	// Token: 0x1700018E RID: 398
	// (get) Token: 0x06000822 RID: 2082 RVA: 0x00015B6A File Offset: 0x00013D6A
	public bool sElVFEmLLWwWHmfsXdbfdamLlpiPA
	{
		get
		{
			return this.zuhdGRcuxqpZdhIJNTAeRbqHCNZJA <= 0 || this.XXIrNtEAPPiwIteKxihIdDXZuLQe != null;
		}
	}

	// Token: 0x1700018F RID: 399
	// (get) Token: 0x06000823 RID: 2083 RVA: 0x00015B84 File Offset: 0x00013D84
	// (set) Token: 0x06000824 RID: 2084 RVA: 0x00015BA2 File Offset: 0x00013DA2
	public unsafe byte MFniyRPnkzWHsmkKnvySgVeAQxBw
	{
		get
		{
			if (A_1 < 0 || A_1 >= this.zuhdGRcuxqpZdhIJNTAeRbqHCNZJA)
			{
				throw new IndexOutOfRangeException();
			}
			return this.XXIrNtEAPPiwIteKxihIdDXZuLQe[A_1];
		}
		set
		{
			if (A_1 < 0 || A_1 >= this.zuhdGRcuxqpZdhIJNTAeRbqHCNZJA)
			{
				throw new IndexOutOfRangeException();
			}
			this.XXIrNtEAPPiwIteKxihIdDXZuLQe[A_1] = value;
		}
	}

	// Token: 0x06000825 RID: 2085 RVA: 0x00015BC1 File Offset: 0x00013DC1
	public eJwThxqtVUOqVDeqWCSbjxgGOJtQA(int A_1)
	{
		this.eKNHxEeKibwmsobhwrFIpyeXtLjW(A_1);
	}

	// Token: 0x06000826 RID: 2086 RVA: 0x00015BD0 File Offset: 0x00013DD0
	public unsafe eJwThxqtVUOqVDeqWCSbjxgGOJtQA(params byte[] A_1) : this(A_1.Length)
	{
		Marshal.Copy(A_1, 0, (IntPtr)((void*)this.XXIrNtEAPPiwIteKxihIdDXZuLQe), A_1.Length);
	}

	// Token: 0x06000827 RID: 2087 RVA: 0x00015BF0 File Offset: 0x00013DF0
	public eJwThxqtVUOqVDeqWCSbjxgGOJtQA(eJwThxqtVUOqVDeqWCSbjxgGOJtQA A_1) : this(A_1.zuhdGRcuxqpZdhIJNTAeRbqHCNZJA)
	{
		A_1.BFsFEcArFeoAPqBWUoTuyfoVdikI(this, 0, A_1.zuhdGRcuxqpZdhIJNTAeRbqHCNZJA, true);
	}

	// Token: 0x06000828 RID: 2088 RVA: 0x00015C0E File Offset: 0x00013E0E
	public unsafe eJwThxqtVUOqVDeqWCSbjxgGOJtQA(byte* A_1, int A_2) : this(A_2)
	{
		rDYcHfJUMVKfEiJasMCndFkbsfgPB.hXvSugMYGJQmEjgQOnuPWwFRdqIC(A_1, this.XXIrNtEAPPiwIteKxihIdDXZuLQe, 0, 0, A_2);
	}

	// Token: 0x06000829 RID: 2089 RVA: 0x00039238 File Offset: 0x00037438
	public unsafe bool xXnpIgxsTmJjQPpTGzCCzmVvujzM(byte* A_1, int A_2, int A_3, int A_4, bool A_5 = true)
	{
		if (A_1 == null)
		{
			if (A_5)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		else if (A_3 < 0 || A_3 >= this.zuhdGRcuxqpZdhIJNTAeRbqHCNZJA || A_3 >= A_2)
		{
			if (A_5)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		else if (A_4 <= 0 || A_4 > this.zuhdGRcuxqpZdhIJNTAeRbqHCNZJA || A_4 > A_2)
		{
			if (A_5)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		else
		{
			int num = A_4 + A_3;
			if (num < this.zuhdGRcuxqpZdhIJNTAeRbqHCNZJA && num < A_2)
			{
				return rDYcHfJUMVKfEiJasMCndFkbsfgPB.hXvSugMYGJQmEjgQOnuPWwFRdqIC(this.XXIrNtEAPPiwIteKxihIdDXZuLQe, A_1, A_3, A_3, A_4);
			}
			if (A_5)
			{
				throw new ArgumentOutOfRangeException("startIndex + length must be < Length of either array");
			}
			return false;
		}
	}

	// Token: 0x0600082A RID: 2090 RVA: 0x00015C27 File Offset: 0x00013E27
	public bool BFsFEcArFeoAPqBWUoTuyfoVdikI(eJwThxqtVUOqVDeqWCSbjxgGOJtQA A_1, int A_2, int A_3, bool A_4 = true)
	{
		if (A_1 != null)
		{
			return this.xXnpIgxsTmJjQPpTGzCCzmVvujzM(A_1.XXIrNtEAPPiwIteKxihIdDXZuLQe, A_1.zuhdGRcuxqpZdhIJNTAeRbqHCNZJA, A_2, A_3, A_4);
		}
		if (A_4)
		{
			throw new ArgumentNullException("destination");
		}
		return false;
	}

	// Token: 0x0600082B RID: 2091 RVA: 0x000392D8 File Offset: 0x000374D8
	public unsafe bool WJCZORWPnyYnHldGXELDulofvJKA(byte[] A_1, int A_2, int A_3, bool A_4 = true)
	{
		if (A_1 == null)
		{
			if (A_4)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		else if (A_2 < 0 || A_2 >= this.zuhdGRcuxqpZdhIJNTAeRbqHCNZJA || A_2 >= A_1.Length)
		{
			if (A_4)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		else if (A_3 <= 0 || A_3 > this.zuhdGRcuxqpZdhIJNTAeRbqHCNZJA || A_3 > A_1.Length)
		{
			if (A_4)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		else
		{
			int num = A_3 + A_2;
			if (num < this.zuhdGRcuxqpZdhIJNTAeRbqHCNZJA && num < A_1.Length)
			{
				return NativeTools.CopyMemory((IntPtr)((void*)this.XXIrNtEAPPiwIteKxihIdDXZuLQe), A_1, A_2, A_2, A_3, A_4);
			}
			if (A_4)
			{
				throw new ArgumentOutOfRangeException("startIndex + length must be < Length of either array");
			}
			return false;
		}
	}

	// Token: 0x0600082C RID: 2092 RVA: 0x0003937C File Offset: 0x0003757C
	public unsafe bool zYwWNXTrYuEDYvvYDDLheGkblCxi(byte* A_1, int A_2, int A_3, int A_4, int A_5, bool A_6 = true)
	{
		if (A_1 == null)
		{
			if (A_6)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		else if (A_3 < 0 || A_3 >= this.zuhdGRcuxqpZdhIJNTAeRbqHCNZJA)
		{
			if (A_6)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		else if (A_4 < 0 || A_4 >= A_2)
		{
			if (A_6)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		else if (A_5 <= 0 || A_5 > this.zuhdGRcuxqpZdhIJNTAeRbqHCNZJA || A_5 > A_2)
		{
			if (A_6)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		else if (A_5 + A_3 >= this.zuhdGRcuxqpZdhIJNTAeRbqHCNZJA)
		{
			if (A_6)
			{
				throw new ArgumentOutOfRangeException("sourceStartIndex + length must be < source.Length");
			}
			return false;
		}
		else
		{
			if (A_5 + A_4 < A_2)
			{
				return rDYcHfJUMVKfEiJasMCndFkbsfgPB.hXvSugMYGJQmEjgQOnuPWwFRdqIC(this.XXIrNtEAPPiwIteKxihIdDXZuLQe, A_1, A_3, A_4, A_5);
			}
			if (A_6)
			{
				throw new ArgumentOutOfRangeException("destinationStartIndex + length must be < destination.Length");
			}
			return false;
		}
	}

	// Token: 0x0600082D RID: 2093 RVA: 0x00015C53 File Offset: 0x00013E53
	public bool PdfYJuXEDMHiAHpxUBSjvTSjNqZj(eJwThxqtVUOqVDeqWCSbjxgGOJtQA A_1, int A_2, int A_3, int A_4, bool A_5 = true)
	{
		if (A_1 != null)
		{
			return this.zYwWNXTrYuEDYvvYDDLheGkblCxi(A_1.XXIrNtEAPPiwIteKxihIdDXZuLQe, A_1.zuhdGRcuxqpZdhIJNTAeRbqHCNZJA, A_2, A_3, A_4, A_5);
		}
		if (A_5)
		{
			throw new ArgumentNullException("destination");
		}
		return false;
	}

	// Token: 0x0600082E RID: 2094 RVA: 0x00039444 File Offset: 0x00037644
	public unsafe bool isdFaiqkBiEoEwBvYdJOGgVlKfnVA(byte[] A_1, int A_2, int A_3, int A_4, bool A_5 = true)
	{
		if (A_1 == null)
		{
			if (A_5)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		else if (A_2 < 0 || A_2 >= this.zuhdGRcuxqpZdhIJNTAeRbqHCNZJA)
		{
			if (A_5)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		else if (A_3 < 0 || A_3 >= A_1.Length)
		{
			if (A_5)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		else if (A_4 <= 0 || A_4 > this.zuhdGRcuxqpZdhIJNTAeRbqHCNZJA || A_4 > A_1.Length)
		{
			if (A_5)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		else if (A_4 + A_2 >= this.zuhdGRcuxqpZdhIJNTAeRbqHCNZJA)
		{
			if (A_5)
			{
				throw new ArgumentOutOfRangeException("sourceStartIndex + length must be < source.Length");
			}
			return false;
		}
		else
		{
			if (A_4 + A_3 < A_1.Length)
			{
				return NativeTools.CopyMemory((IntPtr)((void*)this.XXIrNtEAPPiwIteKxihIdDXZuLQe), A_1, A_2, A_3, A_4, A_5);
			}
			if (A_5)
			{
				throw new ArgumentOutOfRangeException("destinationStartIndex + length must be < destination.Length");
			}
			return false;
		}
	}

	// Token: 0x0600082F RID: 2095 RVA: 0x00039514 File Offset: 0x00037714
	public unsafe bool HyDRHxbWecHhWlCkIgpHLGdQNokX(byte* A_1, int A_2, int A_3, int A_4)
	{
		if (A_1 == null)
		{
			return false;
		}
		if (A_3 >= this.zuhdGRcuxqpZdhIJNTAeRbqHCNZJA || A_3 >= A_2)
		{
			return false;
		}
		if (A_3 < 0)
		{
			A_3 = 0;
		}
		int num = A_4 + A_3;
		if (num >= this.zuhdGRcuxqpZdhIJNTAeRbqHCNZJA)
		{
			A_4 = this.zuhdGRcuxqpZdhIJNTAeRbqHCNZJA - A_3;
		}
		if (num >= A_2)
		{
			A_4 = A_2 - A_3;
		}
		return A_4 > 0 && rDYcHfJUMVKfEiJasMCndFkbsfgPB.hXvSugMYGJQmEjgQOnuPWwFRdqIC(this.XXIrNtEAPPiwIteKxihIdDXZuLQe, A_1, A_3, A_3, A_4);
	}

	// Token: 0x06000830 RID: 2096 RVA: 0x00015C81 File Offset: 0x00013E81
	public bool DQFzHYlHSgFbqrPeOwueSgdkabRN(eJwThxqtVUOqVDeqWCSbjxgGOJtQA A_1, int A_2, int A_3)
	{
		return A_1 != null && this.HyDRHxbWecHhWlCkIgpHLGdQNokX(A_1.XXIrNtEAPPiwIteKxihIdDXZuLQe, A_1.zuhdGRcuxqpZdhIJNTAeRbqHCNZJA, A_2, A_3);
	}

	// Token: 0x06000831 RID: 2097 RVA: 0x00039574 File Offset: 0x00037774
	public unsafe bool eUAjwejbXxzKQepDLfdZBUATuukB(byte[] A_1, int A_2, int A_3)
	{
		if (A_1 == null)
		{
			return false;
		}
		if (A_2 >= this.zuhdGRcuxqpZdhIJNTAeRbqHCNZJA || A_2 >= A_1.Length)
		{
			return false;
		}
		if (A_2 < 0)
		{
			A_2 = 0;
		}
		int num = A_3 + A_2;
		if (num >= this.zuhdGRcuxqpZdhIJNTAeRbqHCNZJA)
		{
			A_3 = this.zuhdGRcuxqpZdhIJNTAeRbqHCNZJA - A_2;
		}
		if (num >= A_1.Length)
		{
			A_3 = A_1.Length - A_2;
		}
		return A_3 > 0 && NativeTools.CopyMemory((IntPtr)((void*)this.XXIrNtEAPPiwIteKxihIdDXZuLQe), A_1, A_2, A_2, A_3, false);
	}

	// Token: 0x06000832 RID: 2098 RVA: 0x000395DC File Offset: 0x000377DC
	public unsafe bool lHOvVhJEBYPffEmezEggnOsnAjcQ(byte* A_1, int A_2, int A_3, int A_4, int A_5)
	{
		if (A_1 == null)
		{
			return false;
		}
		if (A_3 >= this.zuhdGRcuxqpZdhIJNTAeRbqHCNZJA)
		{
			return false;
		}
		if (A_4 >= A_2)
		{
			return false;
		}
		if (A_3 < 0)
		{
			A_3 = 0;
		}
		if (A_4 < 0)
		{
			A_4 = 0;
		}
		if (A_5 + A_3 >= this.zuhdGRcuxqpZdhIJNTAeRbqHCNZJA)
		{
			A_5 = this.zuhdGRcuxqpZdhIJNTAeRbqHCNZJA - A_3;
		}
		if (A_5 + A_4 >= A_2)
		{
			A_5 = A_2 - A_4;
		}
		return A_5 > 0 && rDYcHfJUMVKfEiJasMCndFkbsfgPB.hXvSugMYGJQmEjgQOnuPWwFRdqIC(this.XXIrNtEAPPiwIteKxihIdDXZuLQe, A_1, A_3, A_4, A_5);
	}

	// Token: 0x06000833 RID: 2099 RVA: 0x00015C9C File Offset: 0x00013E9C
	public bool GlvjZIEQugTGKWWHJGAumgBkDkwhA(eJwThxqtVUOqVDeqWCSbjxgGOJtQA A_1, int A_2, int A_3, int A_4)
	{
		return A_1 != null && this.lHOvVhJEBYPffEmezEggnOsnAjcQ(A_1.XXIrNtEAPPiwIteKxihIdDXZuLQe, A_1.zuhdGRcuxqpZdhIJNTAeRbqHCNZJA, A_2, A_3, A_4);
	}

	// Token: 0x06000834 RID: 2100 RVA: 0x00039650 File Offset: 0x00037850
	public unsafe bool PIeZpmsfXLNUNQInsHQigJHQRLyb(byte[] A_1, int A_2, int A_3, int A_4)
	{
		if (A_1 == null)
		{
			return false;
		}
		if (A_2 >= this.zuhdGRcuxqpZdhIJNTAeRbqHCNZJA)
		{
			return false;
		}
		if (A_3 >= A_1.Length)
		{
			return false;
		}
		if (A_2 < 0)
		{
			A_2 = 0;
		}
		if (A_3 < 0)
		{
			A_3 = 0;
		}
		if (A_4 + A_2 >= this.zuhdGRcuxqpZdhIJNTAeRbqHCNZJA)
		{
			A_4 = this.zuhdGRcuxqpZdhIJNTAeRbqHCNZJA - A_2;
		}
		if (A_4 + A_3 >= A_1.Length)
		{
			A_4 = A_1.Length - A_3;
		}
		return A_4 > 0 && NativeTools.CopyMemory((IntPtr)((void*)this.XXIrNtEAPPiwIteKxihIdDXZuLQe), A_1, A_2, A_3, A_4, false);
	}

	// Token: 0x06000835 RID: 2101 RVA: 0x00015CB9 File Offset: 0x00013EB9
	public void hUcKTfJhNSSqIGerTfRnMxFeVXTi(int A_1)
	{
		if (A_1 < 0)
		{
			throw new ArgumentOutOfRangeException("length must be >= 0");
		}
		if (this.zuhdGRcuxqpZdhIJNTAeRbqHCNZJA == A_1)
		{
			return;
		}
		this.eKNHxEeKibwmsobhwrFIpyeXtLjW(A_1);
	}

	// Token: 0x06000836 RID: 2102 RVA: 0x00015CDB File Offset: 0x00013EDB
	public void hznuKgRVdFKfHvUUiPsmqHjtZBgW()
	{
		if (this.zuhdGRcuxqpZdhIJNTAeRbqHCNZJA == 0)
		{
			return;
		}
		if (this.XXIrNtEAPPiwIteKxihIdDXZuLQe == null)
		{
			return;
		}
		rDYcHfJUMVKfEiJasMCndFkbsfgPB.SCyGjgOnlZPdVplOabQlJqZFNOkvA(this.XXIrNtEAPPiwIteKxihIdDXZuLQe, this.zuhdGRcuxqpZdhIJNTAeRbqHCNZJA);
	}

	// Token: 0x06000837 RID: 2103 RVA: 0x000396C8 File Offset: 0x000378C8
	private unsafe void eKNHxEeKibwmsobhwrFIpyeXtLjW(int A_1)
	{
		if (A_1 == this.zuhdGRcuxqpZdhIJNTAeRbqHCNZJA)
		{
			this.hznuKgRVdFKfHvUUiPsmqHjtZBgW();
			return;
		}
		if (this.zuhdGRcuxqpZdhIJNTAeRbqHCNZJA > 0)
		{
			this.cAnjGbTIWByrlCGWoGchqyhtiTPJ();
		}
		this.XXIrNtEAPPiwIteKxihIdDXZuLQe = (byte*)((void*)Marshal.AllocHGlobal(A_1));
		if (this.XXIrNtEAPPiwIteKxihIdDXZuLQe == null)
		{
			throw new Exception("Could not allocate memory for array.");
		}
		this.zuhdGRcuxqpZdhIJNTAeRbqHCNZJA = A_1;
		this.hznuKgRVdFKfHvUUiPsmqHjtZBgW();
	}

	// Token: 0x06000838 RID: 2104 RVA: 0x00015D02 File Offset: 0x00013F02
	private unsafe void cAnjGbTIWByrlCGWoGchqyhtiTPJ()
	{
		if (this.XXIrNtEAPPiwIteKxihIdDXZuLQe != null)
		{
			Marshal.FreeHGlobal((IntPtr)((void*)this.XXIrNtEAPPiwIteKxihIdDXZuLQe));
		}
		this.XXIrNtEAPPiwIteKxihIdDXZuLQe = null;
		this.zuhdGRcuxqpZdhIJNTAeRbqHCNZJA = 0;
	}

	// Token: 0x06000839 RID: 2105 RVA: 0x00015D2D File Offset: 0x00013F2D
	public void Dispose()
	{
		this.gYzCpRTGFYHdRuGlRwjpzSOncaoO(true);
		GC.SuppressFinalize(this);
	}

	// Token: 0x0600083A RID: 2106 RVA: 0x00039728 File Offset: 0x00037928
	protected virtual void zKEwLmkpMijDosLgmnItJNMXYPXb()
	{
		try
		{
			this.gYzCpRTGFYHdRuGlRwjpzSOncaoO(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	// Token: 0x0600083B RID: 2107 RVA: 0x00015D3C File Offset: 0x00013F3C
	protected void gYzCpRTGFYHdRuGlRwjpzSOncaoO(bool A_1)
	{
		this.cAnjGbTIWByrlCGWoGchqyhtiTPJ();
	}

	// Token: 0x0600083C RID: 2108 RVA: 0x00015D44 File Offset: 0x00013F44
	public IEnumerator<byte> GetEnumerator()
	{
		return new eJwThxqtVUOqVDeqWCSbjxgGOJtQA.MklcRMKfEaBBrAcWqmwSpNbMnajN(this);
	}

	// Token: 0x0600083D RID: 2109 RVA: 0x00015D44 File Offset: 0x00013F44
	IEnumerator IEnumerable.GetEnumerator()
	{
		return new eJwThxqtVUOqVDeqWCSbjxgGOJtQA.MklcRMKfEaBBrAcWqmwSpNbMnajN(this);
	}

	// Token: 0x0400084C RID: 2124
	private int zuhdGRcuxqpZdhIJNTAeRbqHCNZJA;

	// Token: 0x0400084D RID: 2125
	private unsafe byte* XXIrNtEAPPiwIteKxihIdDXZuLQe;

	// Token: 0x020000E7 RID: 231
	private struct MklcRMKfEaBBrAcWqmwSpNbMnajN : IEnumerator<byte>, IEnumerator, IDisposable
	{
		// Token: 0x0600083E RID: 2110 RVA: 0x00015D51 File Offset: 0x00013F51
		public MklcRMKfEaBBrAcWqmwSpNbMnajN(eJwThxqtVUOqVDeqWCSbjxgGOJtQA A_1)
		{
			this.VYMuXhLtplAYSoOAnQfeatWvGaKKA = A_1;
			this.uOIAhSbhEUjusAOWNGkxnDXrCiTU = -1;
		}

		// Token: 0x17000190 RID: 400
		// (get) Token: 0x0600083F RID: 2111 RVA: 0x00015D61 File Offset: 0x00013F61
		public byte Current
		{
			get
			{
				return this.VYMuXhLtplAYSoOAnQfeatWvGaKKA.ZKcvxBptQktdQbSSEXnVExNEHWcg(this.uOIAhSbhEUjusAOWNGkxnDXrCiTU);
			}
		}

		// Token: 0x17000191 RID: 401
		// (get) Token: 0x06000840 RID: 2112 RVA: 0x00015D74 File Offset: 0x00013F74
		object IEnumerator.Current
		{
			get
			{
				return this.VYMuXhLtplAYSoOAnQfeatWvGaKKA.ZKcvxBptQktdQbSSEXnVExNEHWcg(this.uOIAhSbhEUjusAOWNGkxnDXrCiTU);
			}
		}

		// Token: 0x06000841 RID: 2113 RVA: 0x000116E9 File Offset: 0x0000F8E9
		public void Dispose()
		{
		}

		// Token: 0x06000842 RID: 2114 RVA: 0x00015D8C File Offset: 0x00013F8C
		public bool MoveNext()
		{
			if (this.uOIAhSbhEUjusAOWNGkxnDXrCiTU >= this.VYMuXhLtplAYSoOAnQfeatWvGaKKA.zuhdGRcuxqpZdhIJNTAeRbqHCNZJA - 1)
			{
				return false;
			}
			this.uOIAhSbhEUjusAOWNGkxnDXrCiTU++;
			return true;
		}

		// Token: 0x06000843 RID: 2115 RVA: 0x00015DB4 File Offset: 0x00013FB4
		public void Reset()
		{
			this.uOIAhSbhEUjusAOWNGkxnDXrCiTU = 0;
		}

		// Token: 0x0400084E RID: 2126
		private eJwThxqtVUOqVDeqWCSbjxgGOJtQA VYMuXhLtplAYSoOAnQfeatWvGaKKA;

		// Token: 0x0400084F RID: 2127
		private int uOIAhSbhEUjusAOWNGkxnDXrCiTU;
	}
}
