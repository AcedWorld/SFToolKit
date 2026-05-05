using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using Rewired;

// Token: 0x02000141 RID: 321
[DefaultMember("Item")]
internal sealed class VgBeEuhSJyCTDoLCtPBvlHeZIRyMA<\u0001> : dBWjOjXnFJmUROzCVhQpynliVgPI, IEnumerable<\u0001>, IEnumerable where \u0001 : ControllerMap
{
	// Token: 0x170003CB RID: 971
	// (get) Token: 0x06000D72 RID: 3442 RVA: 0x0000CAF1 File Offset: 0x0000ACF1
	ControllerMap dBWjOjXnFJmUROzCVhQpynliVgPI.AASmTaBfpYytuKFQeSoBFCHOBYZW
	{
		get
		{
			return this.ukaefAVfyLBvWzKRhEniDUaMMtoX[index];
		}
	}

	// Token: 0x170003CC RID: 972
	// (get) Token: 0x06000D73 RID: 3443 RVA: 0x0000CAFF File Offset: 0x0000ACFF
	IList<ControllerMap> dBWjOjXnFJmUROzCVhQpynliVgPI.BYpfpVdFvePXfVntYtmvDGwQjtHJA
	{
		get
		{
			return this.oQRGryhthDbYyppiYYEfarJBekTe;
		}
	}

	// Token: 0x06000D74 RID: 3444 RVA: 0x0000CB07 File Offset: 0x0000AD07
	IEnumerable<ControllerMap> dBWjOjXnFJmUROzCVhQpynliVgPI.IterateMapsInCategory_ControllerMap(int categoryId)
	{
		if (categoryId < 0)
		{
			yield break;
		}
		int num;
		for (int i = 0; i < this.ukaefAVfyLBvWzKRhEniDUaMMtoX.Count; i = num + 1)
		{
			if (this.ukaefAVfyLBvWzKRhEniDUaMMtoX[i].categoryId == categoryId)
			{
				yield return this.ukaefAVfyLBvWzKRhEniDUaMMtoX[i];
			}
			num = i;
		}
		yield break;
	}

	// Token: 0x06000D75 RID: 3445 RVA: 0x0000CB1E File Offset: 0x0000AD1E
	void dBWjOjXnFJmUROzCVhQpynliVgPI.Add(ControllerMap map, BoolOption startEnabled)
	{
		this.wfwrNzIlaolziFcmVeutgrLdVwHs((\u0001)((object)map), startEnabled);
	}

	// Token: 0x06000D76 RID: 3446 RVA: 0x0000CB2D File Offset: 0x0000AD2D
	void dBWjOjXnFJmUROzCVhQpynliVgPI.Remove(ControllerMap map)
	{
		this.BWrJIDKJiVtHOzwVzxWkVtuAwElB((\u0001)((object)map));
	}

	// Token: 0x06000D77 RID: 3447 RVA: 0x0000CB3B File Offset: 0x0000AD3B
	ControllerMap dBWjOjXnFJmUROzCVhQpynliVgPI.GetMap(int mapId)
	{
		return this.vxcxinndKwKGOUanstRrzOWhinRE(mapId);
	}

	// Token: 0x06000D78 RID: 3448 RVA: 0x0000CB49 File Offset: 0x0000AD49
	ControllerMap dBWjOjXnFJmUROzCVhQpynliVgPI.GetMap(int categoryId, int layoutId)
	{
		return this.XCveuBhhtuQCYFkflMggDofjUZX(categoryId, layoutId);
	}

	// Token: 0x06000D79 RID: 3449 RVA: 0x0000CB58 File Offset: 0x0000AD58
	ControllerMap dBWjOjXnFJmUROzCVhQpynliVgPI.GetMapByCategory(int categoryId)
	{
		return this.xsvSCcQCSpFbneJOSHhRVuqIMPoAb(categoryId);
	}

	// Token: 0x06000D7A RID: 3450 RVA: 0x0000CB66 File Offset: 0x0000AD66
	ControllerMap[] dBWjOjXnFJmUROzCVhQpynliVgPI.GetMaps()
	{
		return this.ukaefAVfyLBvWzKRhEniDUaMMtoX.ToArray();
	}

	// Token: 0x06000D7B RID: 3451 RVA: 0x00050B7C File Offset: 0x0004ED7C
	int dBWjOjXnFJmUROzCVhQpynliVgPI.GetMaps(List<ControllerMap> results, bool appendResults)
	{
		if (results == null)
		{
			return 0;
		}
		int num = 0;
		if (!appendResults)
		{
			results.Clear();
		}
		else
		{
			num = results.Count;
		}
		for (int i = 0; i < this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb.Count; i++)
		{
			results.Add(this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb[i]);
		}
		return results.Count - num;
	}

	// Token: 0x06000D7C RID: 3452 RVA: 0x00050BD8 File Offset: 0x0004EDD8
	ControllerMap[] dBWjOjXnFJmUROzCVhQpynliVgPI.GetMapsByCategory(int categoryId)
	{
		List<ControllerMap> list = new List<ControllerMap>();
		for (int i = 0; i < this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb.Count; i++)
		{
			if (this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb[i].categoryId == categoryId)
			{
				list.Add(this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb[i]);
			}
		}
		return list.ToArray();
	}

	// Token: 0x06000D7D RID: 3453 RVA: 0x00050C38 File Offset: 0x0004EE38
	int dBWjOjXnFJmUROzCVhQpynliVgPI.GetMapsByCategory(int categoryId, List<ControllerMap> results, bool appendResults)
	{
		if (results == null)
		{
			return 0;
		}
		int num = 0;
		if (!appendResults)
		{
			results.Clear();
		}
		else
		{
			num = results.Count;
		}
		for (int i = 0; i < this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb.Count; i++)
		{
			if (this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb[i].categoryId == categoryId)
			{
				results.Add(this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb[i]);
			}
		}
		return results.Count - num;
	}

	// Token: 0x06000D7E RID: 3454 RVA: 0x0000CB73 File Offset: 0x0000AD73
	IList<T> dBWjOjXnFJmUROzCVhQpynliVgPI.GetMaps<T>()
	{
		return (IList<T>)this.wCRnZwUAqMdZoAutjYyMLyPcSmHJA;
	}

	// Token: 0x06000D7F RID: 3455 RVA: 0x00050CAC File Offset: 0x0004EEAC
	int dBWjOjXnFJmUROzCVhQpynliVgPI.GetMapsByCategory<T>(int categoryId, List<T> results, bool appendResults)
	{
		if (results == null)
		{
			return 0;
		}
		int num = 0;
		if (!appendResults)
		{
			results.Clear();
		}
		else
		{
			num = results.Count;
		}
		for (int i = 0; i < this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb.Count; i++)
		{
			T t = this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb[i] as T;
			if (t != null && t.categoryId == categoryId)
			{
				results.Add(t);
			}
		}
		return results.Count - num;
	}

	// Token: 0x06000D80 RID: 3456 RVA: 0x00050D2C File Offset: 0x0004EF2C
	int dBWjOjXnFJmUROzCVhQpynliVgPI.GetMaps<T>(List<T> results, bool appendResults)
	{
		if (results == null)
		{
			return 0;
		}
		int num = 0;
		if (!appendResults)
		{
			results.Clear();
		}
		else
		{
			num = results.Count;
		}
		for (int i = 0; i < this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb.Count; i++)
		{
			T t = this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb[i] as T;
			if (t != null)
			{
				results.Add(t);
			}
		}
		return results.Count - num;
	}

	// Token: 0x170003CD RID: 973
	// (get) Token: 0x06000D81 RID: 3457 RVA: 0x0000CB80 File Offset: 0x0000AD80
	public IList<\u0001> NamUnBtSbAtGJuypAIbbCcKCfklt
	{
		get
		{
			return this.wCRnZwUAqMdZoAutjYyMLyPcSmHJA;
		}
	}

	// Token: 0x170003CE RID: 974
	// (get) Token: 0x06000D82 RID: 3458 RVA: 0x0000CB88 File Offset: 0x0000AD88
	public int sSEkNHPvFzDptlNqDocRnDXFEYyY
	{
		get
		{
			if (this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb == null)
			{
				return 0;
			}
			return this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb.Count;
		}
	}

	// Token: 0x170003CF RID: 975
	// (get) Token: 0x06000D83 RID: 3459 RVA: 0x0000CB9F File Offset: 0x0000AD9F
	// (set) Token: 0x06000D84 RID: 3460 RVA: 0x0000CBAD File Offset: 0x0000ADAD
	public \u0001 kcThSbhmddmUZTDSAKfLWYmXBpLg
	{
		get
		{
			return this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb[A_1];
		}
		set
		{
			this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb[A_1] = value;
			this.ukaefAVfyLBvWzKRhEniDUaMMtoX[A_1] = value;
		}
	}

	// Token: 0x06000D85 RID: 3461 RVA: 0x00050D9C File Offset: 0x0004EF9C
	public VgBeEuhSJyCTDoLCtPBvlHeZIRyMA(int A_1)
	{
		this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb = new List<\u0001>();
		this.wCRnZwUAqMdZoAutjYyMLyPcSmHJA = new ReadOnlyCollection<\u0001>(this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb);
		this.baweSEZorBjrsZVDarLaYYtlgwFd = gRvITEHjKMrWaeGYEmAHofbpCtEU.NTwdBfHkicvibCAGyJFAyEMSqBcIb(typeof(\u0001));
		this.ZtVaFxeeCTfzmPbgkdxhaRAwAovb = A_1;
		this.ukaefAVfyLBvWzKRhEniDUaMMtoX = new List<ControllerMap>();
		this.oQRGryhthDbYyppiYYEfarJBekTe = new ReadOnlyCollection<ControllerMap>(this.ukaefAVfyLBvWzKRhEniDUaMMtoX);
	}

	// Token: 0x06000D86 RID: 3462 RVA: 0x00050E04 File Offset: 0x0004F004
	public void wfwrNzIlaolziFcmVeutgrLdVwHs(\u0001 A_1, BoolOption A_2)
	{
		int num = this.QFNljxEDgQEFmhvoCFoHjPvIyJjac(A_1.categoryId, A_1.layoutId);
		if (A_2 == BoolOption.True)
		{
			A_1.enabled = true;
		}
		else if (A_2 == BoolOption.False)
		{
			A_1.enabled = false;
		}
		if (num >= 0)
		{
			if (A_2 == BoolOption.Default)
			{
				A_1.enabled = this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb[num].enabled;
			}
			this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb[num] = A_1;
			this.ukaefAVfyLBvWzKRhEniDUaMMtoX[num] = A_1;
			return;
		}
		this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb.Add(A_1);
		this.ukaefAVfyLBvWzKRhEniDUaMMtoX.Add(A_1);
	}

	// Token: 0x06000D87 RID: 3463 RVA: 0x0000CBCE File Offset: 0x0000ADCE
	public void JrFxtWSTftVpWeYvGQhTwgYCDcqK(int A_1)
	{
		if (A_1 < 0 || A_1 >= this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb.Count)
		{
			return;
		}
		this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb.RemoveAt(A_1);
		this.ukaefAVfyLBvWzKRhEniDUaMMtoX.RemoveAt(A_1);
	}

	// Token: 0x06000D88 RID: 3464 RVA: 0x0000CBFB File Offset: 0x0000ADFB
	public void BWrJIDKJiVtHOzwVzxWkVtuAwElB(\u0001 A_1)
	{
		this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb.Remove(A_1);
		this.ukaefAVfyLBvWzKRhEniDUaMMtoX.Remove(A_1);
	}

	// Token: 0x06000D89 RID: 3465 RVA: 0x00050EB8 File Offset: 0x0004F0B8
	public void lGbFReDeAoNfNqxYLZPRPhsNRlJaA(int A_1, int A_2)
	{
		if (A_1 < 0 || A_2 < 0)
		{
			return;
		}
		for (int i = this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb.Count - 1; i >= 0; i--)
		{
			if (this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb[i].categoryId == A_1 && this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb[i].layoutId == A_2)
			{
				this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb.RemoveAt(i);
				this.ukaefAVfyLBvWzKRhEniDUaMMtoX.RemoveAt(i);
			}
		}
	}

	// Token: 0x06000D8A RID: 3466 RVA: 0x00050F30 File Offset: 0x0004F130
	public void HXsqgNBkOCEKyBRrsMyeGpgieDatc(int A_1)
	{
		for (int i = this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb.Count - 1; i >= 0; i--)
		{
			if (this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb[i].id == A_1)
			{
				this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb.RemoveAt(i);
				this.ukaefAVfyLBvWzKRhEniDUaMMtoX.RemoveAt(i);
			}
		}
	}

	// Token: 0x06000D8B RID: 3467 RVA: 0x00050F88 File Offset: 0x0004F188
	public int VsqmbtLmqlxsKPDFbiBsxfgRmgGE(int A_1)
	{
		for (int i = 0; i < this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb.Count; i++)
		{
			if (this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb[i].id == A_1)
			{
				return i;
			}
		}
		return -1;
	}

	// Token: 0x06000D8C RID: 3468 RVA: 0x00050FC8 File Offset: 0x0004F1C8
	public int QFNljxEDgQEFmhvoCFoHjPvIyJjac(int A_1, int A_2)
	{
		if (A_1 < 0 || A_2 < 0)
		{
			return -1;
		}
		for (int i = 0; i < this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb.Count; i++)
		{
			if (this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb[i].categoryId == A_1 && this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb[i].layoutId == A_2)
			{
				return i;
			}
		}
		return -1;
	}

	// Token: 0x06000D8D RID: 3469 RVA: 0x0000CC1C File Offset: 0x0000AE1C
	public bool SFZCIUDpKOkqwKCuIFOvsVqmHXVkA(int A_1)
	{
		return this.VsqmbtLmqlxsKPDFbiBsxfgRmgGE(A_1) >= 0;
	}

	// Token: 0x06000D8E RID: 3470 RVA: 0x0000CC2B File Offset: 0x0000AE2B
	public bool FWEWVZfpBhihBvibVHWCLrLaJjpaA(int A_1, int A_2)
	{
		return this.QFNljxEDgQEFmhvoCFoHjPvIyJjac(A_1, A_2) >= 0;
	}

	// Token: 0x06000D8F RID: 3471 RVA: 0x0005102C File Offset: 0x0004F22C
	public void tmBRdtPykIReQLInHLQFKwDnAwME(bool A_1)
	{
		if (!A_1)
		{
			this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb.Clear();
			this.ukaefAVfyLBvWzKRhEniDUaMMtoX.Clear();
			return;
		}
		for (int i = this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb.Count - 1; i >= 0; i--)
		{
			int categoryId = this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb[i].categoryId;
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(categoryId);
			if (mapCategory == null || mapCategory.userAssignable)
			{
				this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb.RemoveAt(i);
				this.ukaefAVfyLBvWzKRhEniDUaMMtoX.RemoveAt(i);
			}
		}
	}

	// Token: 0x06000D90 RID: 3472 RVA: 0x000510B4 File Offset: 0x0004F2B4
	public void CdahLjgQcoVcFLHVnApKIpUuwWfFb(int A_1, bool A_2)
	{
		InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(A_1);
		if (mapCategory == null)
		{
			return;
		}
		if (A_2 && !mapCategory.userAssignable)
		{
			return;
		}
		for (int i = this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb.Count - 1; i >= 0; i--)
		{
			int categoryId = this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb[i].categoryId;
			if (A_1 == categoryId)
			{
				this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb.RemoveAt(i);
				this.ukaefAVfyLBvWzKRhEniDUaMMtoX.RemoveAt(i);
			}
		}
	}

	// Token: 0x06000D91 RID: 3473 RVA: 0x00051128 File Offset: 0x0004F328
	public void xNGVEfxaHwDVUkojACnQhYmsCkQsA(int A_1, bool A_2)
	{
		for (int i = this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb.Count - 1; i >= 0; i--)
		{
			int categoryId = this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb[i].categoryId;
			if (A_1 == this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb[i].layoutId)
			{
				if (A_2)
				{
					InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(categoryId);
					if (mapCategory != null && !mapCategory.userAssignable)
					{
						goto IL_72;
					}
				}
				this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb.RemoveAt(i);
				this.ukaefAVfyLBvWzKRhEniDUaMMtoX.RemoveAt(i);
			}
			IL_72:;
		}
	}

	// Token: 0x06000D92 RID: 3474 RVA: 0x0000CC3B File Offset: 0x0000AE3B
	public IEnumerator<\u0001> GetEnumerator()
	{
		if (this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb == null)
		{
			yield break;
		}
		int num;
		for (int i = 0; i < this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb.Count; i = num + 1)
		{
			yield return this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb[i];
			num = i;
		}
		yield break;
	}

	// Token: 0x06000D93 RID: 3475 RVA: 0x0000CC4A File Offset: 0x0000AE4A
	IEnumerator IEnumerable.GetEnumerator()
	{
		return this.GetEnumerator();
	}

	// Token: 0x06000D94 RID: 3476 RVA: 0x000511B0 File Offset: 0x0004F3B0
	public \u0001 vxcxinndKwKGOUanstRrzOWhinRE(int A_1)
	{
		if (A_1 < 0)
		{
			return default(\u0001);
		}
		for (int i = 0; i < this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb.Count; i++)
		{
			if (this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb[i].id == A_1)
			{
				return this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb[i];
			}
		}
		return default(\u0001);
	}

	// Token: 0x06000D95 RID: 3477 RVA: 0x00051210 File Offset: 0x0004F410
	public \u0001 XCveuBhhtuQCYFkflMggDofjUZX(int A_1, int A_2)
	{
		if (A_1 < 0 || A_2 < 0)
		{
			return default(\u0001);
		}
		for (int i = 0; i < this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb.Count; i++)
		{
			if (this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb[i].categoryId == A_1 && this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb[i].layoutId == A_2)
			{
				return this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb[i];
			}
		}
		return default(\u0001);
	}

	// Token: 0x06000D96 RID: 3478 RVA: 0x00051290 File Offset: 0x0004F490
	public \u0001 xsvSCcQCSpFbneJOSHhRVuqIMPoAb(int A_1)
	{
		for (int i = 0; i < this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb.Count; i++)
		{
			if (this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb[i].categoryId == A_1)
			{
				return this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb[i];
			}
		}
		return default(\u0001);
	}

	// Token: 0x06000D97 RID: 3479 RVA: 0x000512E4 File Offset: 0x0004F4E4
	public bool yLosVWlxMbYvTbZyfeTJRnFKuODB(int A_1)
	{
		if (A_1 < 0)
		{
			return false;
		}
		int count = this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb.Count;
		for (int i = 0; i < count; i++)
		{
			if (this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb[i].categoryId == A_1)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000D98 RID: 3480 RVA: 0x0005132C File Offset: 0x0004F52C
	public int bZBYpowKuOwVJzmJhQhSoceXOIGW(bool A_1)
	{
		int count = this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb.Count;
		int num = 0;
		for (int i = 0; i < count; i++)
		{
			\u0001 u = this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb[i];
			if (u != null && u.enabled != A_1)
			{
				u.enabled = A_1;
				num++;
			}
		}
		return num;
	}

	// Token: 0x06000D99 RID: 3481 RVA: 0x00051388 File Offset: 0x0004F588
	public int BZufQbigMMdrdARAHXjyFnrqKpsUb(bool A_1, int A_2)
	{
		int count = this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb.Count;
		int num = 0;
		for (int i = 0; i < count; i++)
		{
			\u0001 u = this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb[i];
			if (u != null && u.categoryId == A_2 && u.enabled != A_1)
			{
				u.enabled = A_1;
				num++;
			}
		}
		return num;
	}

	// Token: 0x06000D9A RID: 3482 RVA: 0x000513F4 File Offset: 0x0004F5F4
	public int ceKXfmgfXAWsBOieuoPNcUhtJmkl(bool A_1, int A_2, int A_3)
	{
		int count = this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb.Count;
		int num = 0;
		for (int i = 0; i < count; i++)
		{
			\u0001 u = this.AIPGgngvXMXPoDyOBdFbjsQkxcyMb[i];
			if (u != null && u.categoryId == A_2 && u.layoutId == A_3 && u.enabled != A_1)
			{
				u.enabled = A_1;
				num++;
			}
		}
		return num;
	}

	// Token: 0x04000862 RID: 2146
	private readonly List<ControllerMap> ukaefAVfyLBvWzKRhEniDUaMMtoX;

	// Token: 0x04000863 RID: 2147
	private readonly IList<ControllerMap> oQRGryhthDbYyppiYYEfarJBekTe;

	// Token: 0x04000864 RID: 2148
	public readonly ControllerType baweSEZorBjrsZVDarLaYYtlgwFd;

	// Token: 0x04000865 RID: 2149
	public readonly int ZtVaFxeeCTfzmPbgkdxhaRAwAovb;

	// Token: 0x04000866 RID: 2150
	private readonly List<\u0001> AIPGgngvXMXPoDyOBdFbjsQkxcyMb;

	// Token: 0x04000867 RID: 2151
	private readonly IList<\u0001> wCRnZwUAqMdZoAutjYyMLyPcSmHJA;
}
