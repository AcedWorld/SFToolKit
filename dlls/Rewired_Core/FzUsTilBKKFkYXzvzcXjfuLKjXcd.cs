using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired;
using Rewired.Utils.Classes.Data;

// Token: 0x02000102 RID: 258
internal class FzUsTilBKKFkYXzvzcXjfuLKjXcd
{
	// Token: 0x170002AA RID: 682
	// (get) Token: 0x0600088E RID: 2190 RVA: 0x00009440 File Offset: 0x00007640
	public IList<InputAction> qHlLGZqAmOchfaxcwteLsvTnFDpEb
	{
		get
		{
			return this.vZhcdfGxwvhckEaedKnGXmXEQUYBb;
		}
	}

	// Token: 0x170002AB RID: 683
	// (get) Token: 0x0600088F RID: 2191 RVA: 0x00009448 File Offset: 0x00007648
	public int gdtJMdYGqGLjogQUyQYoOeTeKURk
	{
		get
		{
			return this.focnZTIGKkfxmiQYfilRGQkasAaK;
		}
	}

	// Token: 0x170002AC RID: 684
	// (get) Token: 0x06000890 RID: 2192 RVA: 0x00009450 File Offset: 0x00007650
	public int nEoFXOvBRwYSCZduQDPLTLMHVBUo
	{
		get
		{
			return this.YWngPptGgbLKJGRLmbhBSVwhkXYg;
		}
	}

	// Token: 0x06000891 RID: 2193 RVA: 0x00040A84 File Offset: 0x0003EC84
	public FzUsTilBKKFkYXzvzcXjfuLKjXcd(List<InputAction> A_1)
	{
		this.pDfoLKkethgMFIQOobAAeDejuskIb = new List<string>();
		this.SzVdHzEffoPVxfsHXUCWgfBGgbCy = new List<int>();
		this.lhjvIKWgOsOgZLhsTGdHJHzkpLEy = A_1.ToArray();
		this.focnZTIGKkfxmiQYfilRGQkasAaK = this.lhjvIKWgOsOgZLhsTGdHJHzkpLEy.Length;
		int num = -1;
		for (int i = 0; i < this.focnZTIGKkfxmiQYfilRGQkasAaK; i++)
		{
			int id = this.lhjvIKWgOsOgZLhsTGdHJHzkpLEy[i].id;
			if (id > num)
			{
				num = id;
			}
		}
		this.YWngPptGgbLKJGRLmbhBSVwhkXYg = num;
		this.vYLwPuHiviYfOEvsAAKowOCmxXTL = new FzUsTilBKKFkYXzvzcXjfuLKjXcd.ZGjSaCkGNkpwMOeJBEQGfCJGiyVP[num + 1];
		for (int j = 0; j < this.focnZTIGKkfxmiQYfilRGQkasAaK; j++)
		{
			InputAction inputAction = this.lhjvIKWgOsOgZLhsTGdHJHzkpLEy[j];
			this.vYLwPuHiviYfOEvsAAKowOCmxXTL[inputAction.id] = new FzUsTilBKKFkYXzvzcXjfuLKjXcd.ZGjSaCkGNkpwMOeJBEQGfCJGiyVP(inputAction, j);
		}
		this.KIeAjXHWNeQAdWnAaWABasmFgEGvA = new ADictionary<string, FzUsTilBKKFkYXzvzcXjfuLKjXcd.ZGjSaCkGNkpwMOeJBEQGfCJGiyVP>(this.focnZTIGKkfxmiQYfilRGQkasAaK, StringComparer.OrdinalIgnoreCase);
		for (int k = 0; k < this.focnZTIGKkfxmiQYfilRGQkasAaK; k++)
		{
			InputAction inputAction2 = this.lhjvIKWgOsOgZLhsTGdHJHzkpLEy[k];
			try
			{
				this.KIeAjXHWNeQAdWnAaWABasmFgEGvA.Add(inputAction2.name, this.vYLwPuHiviYfOEvsAAKowOCmxXTL[inputAction2.id]);
			}
			catch
			{
				Logger.LogError("Duplicate Action name \"" + inputAction2.name + "\" found in Action list. Duplicate Action names are not allowed. If you have edited the data manually outside the Rewired Input Manager, remove any duplicate Actions.");
			}
		}
		this.vZhcdfGxwvhckEaedKnGXmXEQUYBb = new ReadOnlyCollection<InputAction>(this.lhjvIKWgOsOgZLhsTGdHJHzkpLEy);
	}

	// Token: 0x06000892 RID: 2194 RVA: 0x00040BCC File Offset: 0x0003EDCC
	public InputAction JXGGKcxGWRrQIExMBPoPspsDbQUdA(string A_1, bool A_2 = false)
	{
		if (string.IsNullOrEmpty(A_1))
		{
			return null;
		}
		FzUsTilBKKFkYXzvzcXjfuLKjXcd.ZGjSaCkGNkpwMOeJBEQGfCJGiyVP zgjSaCkGNkpwMOeJBEQGfCJGiyVP;
		if (!this.KIeAjXHWNeQAdWnAaWABasmFgEGvA.TryGetValue(A_1, out zgjSaCkGNkpwMOeJBEQGfCJGiyVP))
		{
			if (A_2)
			{
				this.AoUBCdESFpNQYxcEBHXQXFeUnzBK(A_1);
			}
			return null;
		}
		return zgjSaCkGNkpwMOeJBEQGfCJGiyVP.TZcfKpAviAbkVfPPYxdGVwEaasOQA;
	}

	// Token: 0x06000893 RID: 2195 RVA: 0x00009458 File Offset: 0x00007658
	public InputAction zBXmrejZuuEPoeoiDDZIaQYCoFmv(int A_1)
	{
		if (A_1 < 0)
		{
			return null;
		}
		if (A_1 > this.YWngPptGgbLKJGRLmbhBSVwhkXYg)
		{
			return null;
		}
		if (this.vYLwPuHiviYfOEvsAAKowOCmxXTL[A_1] == null)
		{
			return null;
		}
		return this.vYLwPuHiviYfOEvsAAKowOCmxXTL[A_1].TZcfKpAviAbkVfPPYxdGVwEaasOQA;
	}

	// Token: 0x06000894 RID: 2196 RVA: 0x00009484 File Offset: 0x00007684
	public InputAction puRZHYlwSvYOZmFNvWBfhhEpASWK(int A_1)
	{
		if (A_1 < 0 || A_1 >= this.focnZTIGKkfxmiQYfilRGQkasAaK)
		{
			return null;
		}
		return this.lhjvIKWgOsOgZLhsTGdHJHzkpLEy[A_1];
	}

	// Token: 0x06000895 RID: 2197 RVA: 0x00040C08 File Offset: 0x0003EE08
	public int RQShMPZqoxNyEuVIKrDaSdTQtHZy(string A_1, bool A_2 = false)
	{
		if (string.IsNullOrEmpty(A_1))
		{
			return -1;
		}
		FzUsTilBKKFkYXzvzcXjfuLKjXcd.ZGjSaCkGNkpwMOeJBEQGfCJGiyVP zgjSaCkGNkpwMOeJBEQGfCJGiyVP;
		if (!this.KIeAjXHWNeQAdWnAaWABasmFgEGvA.TryGetValue(A_1, out zgjSaCkGNkpwMOeJBEQGfCJGiyVP))
		{
			if (A_2)
			{
				this.AoUBCdESFpNQYxcEBHXQXFeUnzBK(A_1);
			}
			return -1;
		}
		return zgjSaCkGNkpwMOeJBEQGfCJGiyVP.RuRscFnMXtPymsrXYeZdNkRVndzQ;
	}

	// Token: 0x06000896 RID: 2198 RVA: 0x00040C44 File Offset: 0x0003EE44
	public int GgcLbqsjISfcSHJvzXzdOFrEcGwSA(int A_1, bool A_2 = false)
	{
		if (A_1 < 0 || A_1 > this.YWngPptGgbLKJGRLmbhBSVwhkXYg)
		{
			if (A_1 >= 0 && A_2)
			{
				this.JfQLzjnOwpFBUcxUpnbrGBnmnyTA(A_1);
			}
			return -1;
		}
		FzUsTilBKKFkYXzvzcXjfuLKjXcd.ZGjSaCkGNkpwMOeJBEQGfCJGiyVP zgjSaCkGNkpwMOeJBEQGfCJGiyVP = this.vYLwPuHiviYfOEvsAAKowOCmxXTL[A_1];
		if (zgjSaCkGNkpwMOeJBEQGfCJGiyVP == null)
		{
			if (A_2)
			{
				this.JfQLzjnOwpFBUcxUpnbrGBnmnyTA(A_1);
			}
			return -1;
		}
		return zgjSaCkGNkpwMOeJBEQGfCJGiyVP.RuRscFnMXtPymsrXYeZdNkRVndzQ;
	}

	// Token: 0x06000897 RID: 2199 RVA: 0x0000949D File Offset: 0x0000769D
	public bool xHwwSmGoXutgyhAkTPZtESfDEFEb(string A_1, bool A_2 = false)
	{
		if (string.IsNullOrEmpty(A_1))
		{
			return false;
		}
		if (!this.KIeAjXHWNeQAdWnAaWABasmFgEGvA.ContainsKey(A_1))
		{
			if (A_2)
			{
				this.AoUBCdESFpNQYxcEBHXQXFeUnzBK(A_1);
			}
			return false;
		}
		return true;
	}

	// Token: 0x06000898 RID: 2200 RVA: 0x000094C4 File Offset: 0x000076C4
	public bool HyTLAIQgcMyMlMmWHCgNRoCBGwh(int A_1)
	{
		return A_1 >= 0 && A_1 <= this.YWngPptGgbLKJGRLmbhBSVwhkXYg && this.vYLwPuHiviYfOEvsAAKowOCmxXTL[A_1] != null;
	}

	// Token: 0x06000899 RID: 2201 RVA: 0x00040C90 File Offset: 0x0003EE90
	public int qZRRqCqTLqxYFDLDCauSXNdaVpPA(string A_1, bool A_2 = false)
	{
		if (string.IsNullOrEmpty(A_1))
		{
			return -1;
		}
		FzUsTilBKKFkYXzvzcXjfuLKjXcd.ZGjSaCkGNkpwMOeJBEQGfCJGiyVP zgjSaCkGNkpwMOeJBEQGfCJGiyVP;
		if (!this.KIeAjXHWNeQAdWnAaWABasmFgEGvA.TryGetValue(A_1, out zgjSaCkGNkpwMOeJBEQGfCJGiyVP))
		{
			if (A_2)
			{
				this.AoUBCdESFpNQYxcEBHXQXFeUnzBK(A_1);
			}
			return -1;
		}
		return zgjSaCkGNkpwMOeJBEQGfCJGiyVP.MyPxBYuBSFZMtRCmguxchsjPDkNO;
	}

	// Token: 0x0600089A RID: 2202 RVA: 0x000094E0 File Offset: 0x000076E0
	private void AoUBCdESFpNQYxcEBHXQXFeUnzBK(string A_1)
	{
		if (this.pDfoLKkethgMFIQOobAAeDejuskIb.Contains(A_1))
		{
			return;
		}
		this.pDfoLKkethgMFIQOobAAeDejuskIb.Add(A_1);
		Logger.LogWarning("The Action \"" + A_1 + "\" does not exist. You can create Actions in the editor.");
	}

	// Token: 0x0600089B RID: 2203 RVA: 0x00009512 File Offset: 0x00007712
	private void JfQLzjnOwpFBUcxUpnbrGBnmnyTA(int A_1)
	{
		if (this.SzVdHzEffoPVxfsHXUCWgfBGgbCy.Contains(A_1))
		{
			return;
		}
		this.SzVdHzEffoPVxfsHXUCWgfBGgbCy.Add(A_1);
		Logger.LogWarning("No Action exists for Action Id " + A_1.ToString() + ". You can create Actions in the editor.");
	}

	// Token: 0x040006B7 RID: 1719
	private InputAction[] lhjvIKWgOsOgZLhsTGdHJHzkpLEy;

	// Token: 0x040006B8 RID: 1720
	private ADictionary<string, FzUsTilBKKFkYXzvzcXjfuLKjXcd.ZGjSaCkGNkpwMOeJBEQGfCJGiyVP> KIeAjXHWNeQAdWnAaWABasmFgEGvA;

	// Token: 0x040006B9 RID: 1721
	private FzUsTilBKKFkYXzvzcXjfuLKjXcd.ZGjSaCkGNkpwMOeJBEQGfCJGiyVP[] vYLwPuHiviYfOEvsAAKowOCmxXTL;

	// Token: 0x040006BA RID: 1722
	private ReadOnlyCollection<InputAction> vZhcdfGxwvhckEaedKnGXmXEQUYBb;

	// Token: 0x040006BB RID: 1723
	private int focnZTIGKkfxmiQYfilRGQkasAaK;

	// Token: 0x040006BC RID: 1724
	private int YWngPptGgbLKJGRLmbhBSVwhkXYg;

	// Token: 0x040006BD RID: 1725
	private List<string> pDfoLKkethgMFIQOobAAeDejuskIb;

	// Token: 0x040006BE RID: 1726
	private List<int> SzVdHzEffoPVxfsHXUCWgfBGgbCy;

	// Token: 0x02000103 RID: 259
	private class ZGjSaCkGNkpwMOeJBEQGfCJGiyVP
	{
		// Token: 0x0600089C RID: 2204 RVA: 0x0000954A File Offset: 0x0000774A
		public ZGjSaCkGNkpwMOeJBEQGfCJGiyVP(InputAction A_1, int A_2)
		{
			this.TZcfKpAviAbkVfPPYxdGVwEaasOQA = A_1;
			this.MyPxBYuBSFZMtRCmguxchsjPDkNO = A_1.id;
			this.RuRscFnMXtPymsrXYeZdNkRVndzQ = A_2;
		}

		// Token: 0x040006BF RID: 1727
		public readonly InputAction TZcfKpAviAbkVfPPYxdGVwEaasOQA;

		// Token: 0x040006C0 RID: 1728
		public readonly int MyPxBYuBSFZMtRCmguxchsjPDkNO;

		// Token: 0x040006C1 RID: 1729
		public readonly int RuRscFnMXtPymsrXYeZdNkRVndzQ;
	}
}
