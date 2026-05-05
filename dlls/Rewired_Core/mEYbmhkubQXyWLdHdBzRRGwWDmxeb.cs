using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Config;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

// Token: 0x020000EC RID: 236
internal class mEYbmhkubQXyWLdHdBzRRGwWDmxeb
{
	// Token: 0x06000792 RID: 1938 RVA: 0x0003D2E8 File Offset: 0x0003B4E8
	public mEYbmhkubQXyWLdHdBzRRGwWDmxeb(UpdateLoopSetting A_1, Keyboard A_2)
	{
		this.CGjPoDdQDMDxMMyTxOGYGYcNqPuO = A_2;
		this.VCcaujHWrJZIDohzHGkNaxXigxHxB = new mEYbmhkubQXyWLdHdBzRRGwWDmxeb.MgEhtqvkVAgSJpEMEywRtybUAKxW[3];
		int num = 0;
		using (TempListPool.TList<UpdateLoopType> tlist = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tlist.list;
			EnumConverter.ToUpdateLoopTypes(A_1, list);
			for (int i = 0; i < list.Count; i++)
			{
				mEYbmhkubQXyWLdHdBzRRGwWDmxeb.MgEhtqvkVAgSJpEMEywRtybUAKxW mgEhtqvkVAgSJpEMEywRtybUAKxW = new mEYbmhkubQXyWLdHdBzRRGwWDmxeb.MgEhtqvkVAgSJpEMEywRtybUAKxW(A_2);
				this.VCcaujHWrJZIDohzHGkNaxXigxHxB[(int)list[i]] = mgEhtqvkVAgSJpEMEywRtybUAKxW;
				num++;
				if (num == 1)
				{
					this.PFkGloCvZyfXZmRxexDqMvyIYegcA = mgEhtqvkVAgSJpEMEywRtybUAKxW;
				}
			}
		}
	}

	// Token: 0x06000793 RID: 1939 RVA: 0x0000869C File Offset: 0x0000689C
	public void UCNOEjXTVKSEqDmaerbEPgbwvkOd(UpdateLoopType A_1)
	{
		if (this.lLncRZVQeyoLjtBdGUSTqkkUnJBc != A_1)
		{
			this.lLncRZVQeyoLjtBdGUSTqkkUnJBc = A_1;
			this.PFkGloCvZyfXZmRxexDqMvyIYegcA = this.VCcaujHWrJZIDohzHGkNaxXigxHxB[(int)A_1];
		}
		this.PFkGloCvZyfXZmRxexDqMvyIYegcA.YHQaEPEqkCyjXLYDXjhDdLhufSsO();
	}

	// Token: 0x06000794 RID: 1940 RVA: 0x0003D380 File Offset: 0x0003B580
	public void ZVSLnbArndtsfXTuWqihfYUNdeGx(KeyboardMap A_1)
	{
		if (A_1 == null)
		{
			return;
		}
		AList<ActionElementMap> alist = A_1.DWkEfFJRIhxezCgjNNPhQPxZoAPO;
		int count = alist._count;
		for (int i = 0; i < count; i++)
		{
			ActionElementMap actionElementMap = alist._items[i];
			if (actionElementMap.hasModifiers)
			{
				this.PFkGloCvZyfXZmRxexDqMvyIYegcA.hafWqUNoizbVsyNORJnvlDTjsrXG(actionElementMap);
			}
		}
	}

	// Token: 0x06000795 RID: 1941 RVA: 0x000086C7 File Offset: 0x000068C7
	public bool IMTFqCcQBQVQylvrJbOpyhZVZXgJA(KeyboardKeyCode A_1, ModifierKeyFlags A_2, mEYbmhkubQXyWLdHdBzRRGwWDmxeb.FOSlyratSZQvXdCFcHZgAztlltClA A_3, out bool A_4)
	{
		return this.PFkGloCvZyfXZmRxexDqMvyIYegcA.gSGSqKPrCAocknnnamecnxkYmXSe(A_1, A_2, A_3, out A_4);
	}

	// Token: 0x06000796 RID: 1942 RVA: 0x0003D3C8 File Offset: 0x0003B5C8
	public void zJJItFbZGXvHLIwbQvfaPNRmQLKA()
	{
		for (int i = 0; i < this.VCcaujHWrJZIDohzHGkNaxXigxHxB.Length; i++)
		{
			if (this.VCcaujHWrJZIDohzHGkNaxXigxHxB[i] != null)
			{
				this.VCcaujHWrJZIDohzHGkNaxXigxHxB[i].UKdGGdtcEnuUmmwnsJDEYksAiYSs();
			}
		}
	}

	// Token: 0x04000635 RID: 1589
	private readonly mEYbmhkubQXyWLdHdBzRRGwWDmxeb.MgEhtqvkVAgSJpEMEywRtybUAKxW[] VCcaujHWrJZIDohzHGkNaxXigxHxB;

	// Token: 0x04000636 RID: 1590
	private UpdateLoopType lLncRZVQeyoLjtBdGUSTqkkUnJBc;

	// Token: 0x04000637 RID: 1591
	private readonly Keyboard CGjPoDdQDMDxMMyTxOGYGYcNqPuO;

	// Token: 0x04000638 RID: 1592
	private mEYbmhkubQXyWLdHdBzRRGwWDmxeb.MgEhtqvkVAgSJpEMEywRtybUAKxW PFkGloCvZyfXZmRxexDqMvyIYegcA;

	// Token: 0x020000ED RID: 237
	public class MgEhtqvkVAgSJpEMEywRtybUAKxW
	{
		// Token: 0x06000797 RID: 1943 RVA: 0x000086D9 File Offset: 0x000068D9
		public MgEhtqvkVAgSJpEMEywRtybUAKxW(Keyboard A_1)
		{
			this.ialgZXQEAmdVKKJHkFFmFKBUmboWA = A_1;
			this.jLVPyLVCLEjSJJAwfSUCKIQhubse = ModifierKeyFlags.None;
			this.kxMYmKGweWouyfEvNrrCcLOexgbo = new ExpandableArray_DataContainer<mEYbmhkubQXyWLdHdBzRRGwWDmxeb.MgEhtqvkVAgSJpEMEywRtybUAKxW.FBsnTgiayFGFOwMTISpNwLWnEJKKA>(132, false, 132);
			this.PeEhSAABPexmPktaiLCKBakJJfcOA = new ExpandableArray_DataContainer<mEYbmhkubQXyWLdHdBzRRGwWDmxeb.MgEhtqvkVAgSJpEMEywRtybUAKxW.FBsnTgiayFGFOwMTISpNwLWnEJKKA>(5, false, 5);
		}

		// Token: 0x06000798 RID: 1944 RVA: 0x0003D400 File Offset: 0x0003B600
		public void YHQaEPEqkCyjXLYDXjhDdLhufSsO()
		{
			this.jLVPyLVCLEjSJJAwfSUCKIQhubse = ModifierKeyFlags.None;
			this.kxMYmKGweWouyfEvNrrCcLOexgbo.Clear();
			for (int i = this.PeEhSAABPexmPktaiLCKBakJJfcOA.Length - 1; i >= 0; i--)
			{
				mEYbmhkubQXyWLdHdBzRRGwWDmxeb.MgEhtqvkVAgSJpEMEywRtybUAKxW.FBsnTgiayFGFOwMTISpNwLWnEJKKA fbsnTgiayFGFOwMTISpNwLWnEJKKA = this.PeEhSAABPexmPktaiLCKBakJJfcOA[i];
				if (!this.ialgZXQEAmdVKKJHkFFmFKBUmboWA.dtbNfKRpqlPOUvoMhjRHJLMfDbGx(fbsnTgiayFGFOwMTISpNwLWnEJKKA.BLjaycNhNEwKPAxKqGtBQCiTyRDq))
				{
					this.PeEhSAABPexmPktaiLCKBakJJfcOA.RemoveAt(i);
				}
			}
		}

		// Token: 0x06000799 RID: 1945 RVA: 0x0003D464 File Offset: 0x0003B664
		public void hafWqUNoizbVsyNORJnvlDTjsrXG(ActionElementMap A_1)
		{
			if (A_1 == null)
			{
				return;
			}
			this.jLVPyLVCLEjSJJAwfSUCKIQhubse |= A_1.modifierKeyFlags;
			this.kxMYmKGweWouyfEvNrrCcLOexgbo.injector.kApeRpgoStomWrRoFWdOEoKrFgMC(A_1._keyboardKeyCode, A_1.modifierKeyFlags);
			this.kxMYmKGweWouyfEvNrrCcLOexgbo.Inject();
		}

		// Token: 0x0600079A RID: 1946 RVA: 0x0003D4B0 File Offset: 0x0003B6B0
		public bool gSGSqKPrCAocknnnamecnxkYmXSe(KeyboardKeyCode A_1, ModifierKeyFlags A_2, mEYbmhkubQXyWLdHdBzRRGwWDmxeb.FOSlyratSZQvXdCFcHZgAztlltClA A_3, out bool A_4)
		{
			A_4 = false;
			if (this.jLVPyLVCLEjSJJAwfSUCKIQhubse == ModifierKeyFlags.None && A_2 == ModifierKeyFlags.None)
			{
				return false;
			}
			int num = Keyboard.uhPnaQuSkkpXFbbpixqWvezwdZyfA(A_2);
			if (this.UWeDRxEjcnDaKrKaBjjqjLilGhTA(this.kxMYmKGweWouyfEvNrrCcLOexgbo, A_1, A_2, num, mEYbmhkubQXyWLdHdBzRRGwWDmxeb.MgEhtqvkVAgSJpEMEywRtybUAKxW.cXYjQtGIsaSxpopemrlavqfIqmdP.Map, A_3, ref A_4))
			{
				return true;
			}
			if (this.UWeDRxEjcnDaKrKaBjjqjLilGhTA(this.PeEhSAABPexmPktaiLCKBakJJfcOA, A_1, A_2, num, mEYbmhkubQXyWLdHdBzRRGwWDmxeb.MgEhtqvkVAgSJpEMEywRtybUAKxW.cXYjQtGIsaSxpopemrlavqfIqmdP.ActiveSet, A_3, ref A_4))
			{
				return true;
			}
			if (A_2 != ModifierKeyFlags.None)
			{
				this.PeEhSAABPexmPktaiLCKBakJJfcOA.injector.kApeRpgoStomWrRoFWdOEoKrFgMC(A_1, A_2);
				this.PeEhSAABPexmPktaiLCKBakJJfcOA.InjectIfUnique();
			}
			return false;
		}

		// Token: 0x0600079B RID: 1947 RVA: 0x0003D528 File Offset: 0x0003B728
		private bool UWeDRxEjcnDaKrKaBjjqjLilGhTA(ExpandableArray_DataContainer<mEYbmhkubQXyWLdHdBzRRGwWDmxeb.MgEhtqvkVAgSJpEMEywRtybUAKxW.FBsnTgiayFGFOwMTISpNwLWnEJKKA> A_1, KeyboardKeyCode A_2, ModifierKeyFlags A_3, int A_4, mEYbmhkubQXyWLdHdBzRRGwWDmxeb.MgEhtqvkVAgSJpEMEywRtybUAKxW.cXYjQtGIsaSxpopemrlavqfIqmdP A_5, mEYbmhkubQXyWLdHdBzRRGwWDmxeb.FOSlyratSZQvXdCFcHZgAztlltClA A_6, ref bool A_7)
		{
			bool flag = Keyboard.XqnjpppgtijCVhzfMBKTjWIDmjMD(A_2);
			int length = A_1.Length;
			for (int i = 0; i < length; i++)
			{
				mEYbmhkubQXyWLdHdBzRRGwWDmxeb.MgEhtqvkVAgSJpEMEywRtybUAKxW.FBsnTgiayFGFOwMTISpNwLWnEJKKA fbsnTgiayFGFOwMTISpNwLWnEJKKA = A_1[i];
				bool flag2 = fbsnTgiayFGFOwMTISpNwLWnEJKKA.BLjaycNhNEwKPAxKqGtBQCiTyRDq == A_2;
				if ((!flag2 || fbsnTgiayFGFOwMTISpNwLWnEJKKA.EcLjeqRRmCKSZQUptCSdFeSJfBFCA != A_3) && (flag2 || Keyboard.ModifierKeyFlagsContain(fbsnTgiayFGFOwMTISpNwLWnEJKKA.EcLjeqRRmCKSZQUptCSdFeSJfBFCA, (KeyCode)A_2) || MathTools.TbjaLqCGNEPkPcOzsOhAnVwrQMwI((int)fbsnTgiayFGFOwMTISpNwLWnEJKKA.EcLjeqRRmCKSZQUptCSdFeSJfBFCA, (int)A_3)))
				{
					if (!A_7)
					{
						A_7 = true;
					}
					if ((flag || fbsnTgiayFGFOwMTISpNwLWnEJKKA.BLjaycNhNEwKPAxKqGtBQCiTyRDq == A_2) && Keyboard.uhPnaQuSkkpXFbbpixqWvezwdZyfA(fbsnTgiayFGFOwMTISpNwLWnEJKKA.EcLjeqRRmCKSZQUptCSdFeSJfBFCA) > A_4)
					{
						bool flag3 = A_5 != mEYbmhkubQXyWLdHdBzRRGwWDmxeb.MgEhtqvkVAgSJpEMEywRtybUAKxW.cXYjQtGIsaSxpopemrlavqfIqmdP.Map || this.ialgZXQEAmdVKKJHkFFmFKBUmboWA.dokynBuAaDKzLWczKTaNWvdpJtZF(fbsnTgiayFGFOwMTISpNwLWnEJKKA.BLjaycNhNEwKPAxKqGtBQCiTyRDq, fbsnTgiayFGFOwMTISpNwLWnEJKKA.EcLjeqRRmCKSZQUptCSdFeSJfBFCA);
						if (A_6 == mEYbmhkubQXyWLdHdBzRRGwWDmxeb.FOSlyratSZQvXdCFcHZgAztlltClA.Normal)
						{
							return flag3;
						}
						if (A_6 == mEYbmhkubQXyWLdHdBzRRGwWDmxeb.FOSlyratSZQvXdCFcHZgAztlltClA.OverlapModifiers)
						{
							if (A_3 != ModifierKeyFlags.None)
							{
								return flag3;
							}
							if (flag3 && A_2 == fbsnTgiayFGFOwMTISpNwLWnEJKKA.BLjaycNhNEwKPAxKqGtBQCiTyRDq)
							{
								return true;
							}
						}
					}
				}
			}
			return false;
		}

		// Token: 0x0600079C RID: 1948 RVA: 0x00008713 File Offset: 0x00006913
		public void UKdGGdtcEnuUmmwnsJDEYksAiYSs()
		{
			this.jLVPyLVCLEjSJJAwfSUCKIQhubse = ModifierKeyFlags.None;
			this.kxMYmKGweWouyfEvNrrCcLOexgbo.Clear();
			this.PeEhSAABPexmPktaiLCKBakJJfcOA.Clear();
		}

		// Token: 0x04000639 RID: 1593
		private ModifierKeyFlags jLVPyLVCLEjSJJAwfSUCKIQhubse;

		// Token: 0x0400063A RID: 1594
		private ExpandableArray_DataContainer<mEYbmhkubQXyWLdHdBzRRGwWDmxeb.MgEhtqvkVAgSJpEMEywRtybUAKxW.FBsnTgiayFGFOwMTISpNwLWnEJKKA> kxMYmKGweWouyfEvNrrCcLOexgbo;

		// Token: 0x0400063B RID: 1595
		private ExpandableArray_DataContainer<mEYbmhkubQXyWLdHdBzRRGwWDmxeb.MgEhtqvkVAgSJpEMEywRtybUAKxW.FBsnTgiayFGFOwMTISpNwLWnEJKKA> PeEhSAABPexmPktaiLCKBakJJfcOA;

		// Token: 0x0400063C RID: 1596
		private Keyboard ialgZXQEAmdVKKJHkFFmFKBUmboWA;

		// Token: 0x020000EE RID: 238
		private class FBsnTgiayFGFOwMTISpNwLWnEJKKA : ExpandableArray_DataContainer<mEYbmhkubQXyWLdHdBzRRGwWDmxeb.MgEhtqvkVAgSJpEMEywRtybUAKxW.FBsnTgiayFGFOwMTISpNwLWnEJKKA>.YrNAypRzxYCVIPkxNBgtOjmHSnBK, IComparable<mEYbmhkubQXyWLdHdBzRRGwWDmxeb.MgEhtqvkVAgSJpEMEywRtybUAKxW.FBsnTgiayFGFOwMTISpNwLWnEJKKA>
		{
			// Token: 0x0600079D RID: 1949 RVA: 0x00008732 File Offset: 0x00006932
			public void kApeRpgoStomWrRoFWdOEoKrFgMC(KeyboardKeyCode A_1, ModifierKeyFlags A_2)
			{
				this.BLjaycNhNEwKPAxKqGtBQCiTyRDq = A_1;
				this.EcLjeqRRmCKSZQUptCSdFeSJfBFCA = A_2;
			}

			// Token: 0x0600079E RID: 1950 RVA: 0x00008742 File Offset: 0x00006942
			public void JOKgjfnihjaEWvzrVIYhLFWTOoei(mEYbmhkubQXyWLdHdBzRRGwWDmxeb.MgEhtqvkVAgSJpEMEywRtybUAKxW.FBsnTgiayFGFOwMTISpNwLWnEJKKA A_1)
			{
				this.BLjaycNhNEwKPAxKqGtBQCiTyRDq = A_1.BLjaycNhNEwKPAxKqGtBQCiTyRDq;
				this.EcLjeqRRmCKSZQUptCSdFeSJfBFCA = A_1.EcLjeqRRmCKSZQUptCSdFeSJfBFCA;
			}

			// Token: 0x0600079F RID: 1951 RVA: 0x0000875C File Offset: 0x0000695C
			public bool XgbYLXqMrKBTCxIlZYxCqcSvFsAq(mEYbmhkubQXyWLdHdBzRRGwWDmxeb.MgEhtqvkVAgSJpEMEywRtybUAKxW.FBsnTgiayFGFOwMTISpNwLWnEJKKA A_1)
			{
				return this.BLjaycNhNEwKPAxKqGtBQCiTyRDq == A_1.BLjaycNhNEwKPAxKqGtBQCiTyRDq && this.EcLjeqRRmCKSZQUptCSdFeSJfBFCA == A_1.EcLjeqRRmCKSZQUptCSdFeSJfBFCA;
			}

			// Token: 0x060007A0 RID: 1952 RVA: 0x0000877D File Offset: 0x0000697D
			public void lmduDFicYmoddDMwLCUqePmTamecb()
			{
				this.BLjaycNhNEwKPAxKqGtBQCiTyRDq = KeyboardKeyCode.None;
				this.EcLjeqRRmCKSZQUptCSdFeSJfBFCA = ModifierKeyFlags.None;
			}

			// Token: 0x060007A1 RID: 1953 RVA: 0x00003E2B File Offset: 0x0000202B
			public int CompareTo(mEYbmhkubQXyWLdHdBzRRGwWDmxeb.MgEhtqvkVAgSJpEMEywRtybUAKxW.FBsnTgiayFGFOwMTISpNwLWnEJKKA other)
			{
				return 0;
			}

			// Token: 0x0400063D RID: 1597
			public KeyboardKeyCode BLjaycNhNEwKPAxKqGtBQCiTyRDq;

			// Token: 0x0400063E RID: 1598
			public ModifierKeyFlags EcLjeqRRmCKSZQUptCSdFeSJfBFCA;
		}

		// Token: 0x020000EF RID: 239
		private enum cXYjQtGIsaSxpopemrlavqfIqmdP
		{
			// Token: 0x04000640 RID: 1600
			Map,
			// Token: 0x04000641 RID: 1601
			ActiveSet
		}
	}

	// Token: 0x020000F0 RID: 240
	public enum FOSlyratSZQvXdCFcHZgAztlltClA
	{
		// Token: 0x04000643 RID: 1603
		Normal,
		// Token: 0x04000644 RID: 1604
		OverlapModifiers
	}
}
