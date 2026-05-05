using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Config;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

// Token: 0x020001CF RID: 463
internal class ykQBbCYXhmFNZdFinwXsPZYFmYFE
{
	// Token: 0x060017BE RID: 6078 RVA: 0x0006EEBC File Offset: 0x0006D0BC
	public ykQBbCYXhmFNZdFinwXsPZYFmYFE(UpdateLoopSetting A_1)
	{
		this.HvsqOsaQWYxQwQGahUtcnnYRQFYH = new IndexedDictionary<int, ykQBbCYXhmFNZdFinwXsPZYFmYFE.xHxaJcUPoeNmEhBiAwbpKuoFFcGN>();
		using (TempListPool.TList<UpdateLoopType> tlist = TempListPool.GetTList<UpdateLoopType>(3))
		{
			List<UpdateLoopType> list = tlist.list;
			EnumConverter.ToUpdateLoopTypes(A_1, list);
			for (int i = 0; i < list.Count; i++)
			{
				this.HvsqOsaQWYxQwQGahUtcnnYRQFYH.Add((int)list[i], new ykQBbCYXhmFNZdFinwXsPZYFmYFE.xHxaJcUPoeNmEhBiAwbpKuoFFcGN());
			}
		}
		this.OiUfyLDaALqdDiLoCPTVEaJrwRYob = UpdateLoopType.Update;
		this.bSWUcmUiJJcTbWwcKLFHennlMFYq = this.HvsqOsaQWYxQwQGahUtcnnYRQFYH.GetValue(0);
	}

	// Token: 0x060017BF RID: 6079 RVA: 0x00014483 File Offset: 0x00012683
	public void TCxEDFffruDjuxBbtWejNWEaJnnWA()
	{
		this.grcvMsKhIdKsLbaiBtRRhJCYKlhp(ReInput.currentUpdateLoop);
		this.bSWUcmUiJJcTbWwcKLFHennlMFYq.fmuktfuPUGzxmFLYIDDwgNleOAYc();
	}

	// Token: 0x060017C0 RID: 6080 RVA: 0x0001449B File Offset: 0x0001269B
	public void xRUbGtxWtCLMAUQJLhLcCBLWIjrDA(UpdateLoopType A_1)
	{
		this.grcvMsKhIdKsLbaiBtRRhJCYKlhp(A_1);
		this.bSWUcmUiJJcTbWwcKLFHennlMFYq.CPEHxgzxAEYKHielPFjifOGvXviH();
	}

	// Token: 0x060017C1 RID: 6081 RVA: 0x000144AF File Offset: 0x000126AF
	public bool aSNDuhfZxkjfCqCPFqHVYFFRrEPfA(int A_1, int A_2)
	{
		return this.bSWUcmUiJJcTbWwcKLFHennlMFYq.kGpeEBjipLDTMhhJHhfhVYlBDxKkA(A_1, A_2);
	}

	// Token: 0x060017C2 RID: 6082 RVA: 0x000144BE File Offset: 0x000126BE
	public bool ucOCSFGVELRdIplAMsPcelpIcQGDB(int A_1, int A_2)
	{
		return this.bSWUcmUiJJcTbWwcKLFHennlMFYq.klRsiofXNLdPLydEAJZOpmZgNpjn(A_1, A_2);
	}

	// Token: 0x060017C3 RID: 6083 RVA: 0x000144CD File Offset: 0x000126CD
	public bool HKAGDShqzGFlqxlRWwPbKPjSdtutA(int A_1, int A_2)
	{
		return this.bSWUcmUiJJcTbWwcKLFHennlMFYq.hUAlrjGqbbTJYHOFKGFftrRNlSMn(A_1, A_2);
	}

	// Token: 0x060017C4 RID: 6084 RVA: 0x000144DC File Offset: 0x000126DC
	public bool IcpjEEVpyxGTYRsuoVqBnaVmCgXBA(int A_1, int A_2, bool A_3)
	{
		return this.bSWUcmUiJJcTbWwcKLFHennlMFYq.vDUERFuKdMFIfrzOSNkCaoQbHTqU(A_1, A_2, A_3);
	}

	// Token: 0x060017C5 RID: 6085 RVA: 0x000144EC File Offset: 0x000126EC
	public bool fPaUAjnlkFQLbsHbmNOOUrAlwBbQ(int A_1)
	{
		return this.bSWUcmUiJJcTbWwcKLFHennlMFYq.UJEaSefpzsKbseuhcMrfwtrLNdiFA(A_1);
	}

	// Token: 0x060017C6 RID: 6086 RVA: 0x000144FA File Offset: 0x000126FA
	public bool htJemRXAxukGXCucflvjsrtTuyFb(int A_1)
	{
		return this.bSWUcmUiJJcTbWwcKLFHennlMFYq.bYWEmEEzcVqMiaDYhUHOiwwUaqJlA(A_1);
	}

	// Token: 0x060017C7 RID: 6087 RVA: 0x00014508 File Offset: 0x00012708
	public bool wOcdnwFpwOBKDNhjqaRzyadGFJHB(int A_1)
	{
		return this.bSWUcmUiJJcTbWwcKLFHennlMFYq.DUYagzOhRgpTWjwgqdIKRRCTFetu(A_1);
	}

	// Token: 0x060017C8 RID: 6088 RVA: 0x0006EF50 File Offset: 0x0006D150
	public void xYATigZDSCcJRqAZZXbuklDMbkks()
	{
		for (int i = 0; i < this.HvsqOsaQWYxQwQGahUtcnnYRQFYH.Count; i++)
		{
			this.HvsqOsaQWYxQwQGahUtcnnYRQFYH[i].IVWCtxOMDpSUwuLHWutjQgAmFbmDA();
		}
	}

	// Token: 0x060017C9 RID: 6089 RVA: 0x00014516 File Offset: 0x00012716
	private void grcvMsKhIdKsLbaiBtRRhJCYKlhp(UpdateLoopType A_1)
	{
		if (this.OiUfyLDaALqdDiLoCPTVEaJrwRYob != A_1)
		{
			this.OiUfyLDaALqdDiLoCPTVEaJrwRYob = A_1;
			this.bSWUcmUiJJcTbWwcKLFHennlMFYq = this.HvsqOsaQWYxQwQGahUtcnnYRQFYH.GetValue((int)A_1);
		}
	}

	// Token: 0x04000D0E RID: 3342
	private UpdateLoopType OiUfyLDaALqdDiLoCPTVEaJrwRYob;

	// Token: 0x04000D0F RID: 3343
	private ykQBbCYXhmFNZdFinwXsPZYFmYFE.xHxaJcUPoeNmEhBiAwbpKuoFFcGN bSWUcmUiJJcTbWwcKLFHennlMFYq;

	// Token: 0x04000D10 RID: 3344
	private IndexedDictionary<int, ykQBbCYXhmFNZdFinwXsPZYFmYFE.xHxaJcUPoeNmEhBiAwbpKuoFFcGN> HvsqOsaQWYxQwQGahUtcnnYRQFYH;

	// Token: 0x020001D0 RID: 464
	private class xHxaJcUPoeNmEhBiAwbpKuoFFcGN
	{
		// Token: 0x060017CA RID: 6090 RVA: 0x0006EF84 File Offset: 0x0006D184
		public xHxaJcUPoeNmEhBiAwbpKuoFFcGN()
		{
			this.VOuPWFIYsbhWKmxTrsSBRjwMaiEm = new ykQBbCYXhmFNZdFinwXsPZYFmYFE.xHxaJcUPoeNmEhBiAwbpKuoFFcGN.nrpatPGZCdKgVnhjzhpaskqfhKyJA[16];
			for (int i = 0; i < this.VOuPWFIYsbhWKmxTrsSBRjwMaiEm.Length; i++)
			{
				this.VOuPWFIYsbhWKmxTrsSBRjwMaiEm[i] = new ykQBbCYXhmFNZdFinwXsPZYFmYFE.xHxaJcUPoeNmEhBiAwbpKuoFFcGN.nrpatPGZCdKgVnhjzhpaskqfhKyJA(i);
			}
			this.lGSlTWtieuPrUSZKvufpIJvKiJUL = new ykQBbCYXhmFNZdFinwXsPZYFmYFE.xHxaJcUPoeNmEhBiAwbpKuoFFcGN.aDJacxRLpRsnPrmgFDslwPBAjbao();
		}

		// Token: 0x060017CB RID: 6091 RVA: 0x0006EFD0 File Offset: 0x0006D1D0
		public void fmuktfuPUGzxmFLYIDDwgNleOAYc()
		{
			for (int i = 0; i < this.VOuPWFIYsbhWKmxTrsSBRjwMaiEm.Length; i++)
			{
				this.VOuPWFIYsbhWKmxTrsSBRjwMaiEm[i].VCnKMKyDaZhbljCQWzDNmlYHKcbDb();
			}
		}

		// Token: 0x060017CC RID: 6092 RVA: 0x0006F000 File Offset: 0x0006D200
		public void CPEHxgzxAEYKHielPFjifOGvXviH()
		{
			for (int i = 0; i < this.VOuPWFIYsbhWKmxTrsSBRjwMaiEm.Length; i++)
			{
				this.VOuPWFIYsbhWKmxTrsSBRjwMaiEm[i].bCmNHkzepZjJiIFuxSKMDECgxfOt();
			}
			this.lGSlTWtieuPrUSZKvufpIJvKiJUL.lkVKgknVmNdZVTjoTAgNjCyDafnBA();
		}

		// Token: 0x060017CD RID: 6093 RVA: 0x0001453A File Offset: 0x0001273A
		public bool kGpeEBjipLDTMhhJHhfhVYlBDxKkA(int A_1, int A_2)
		{
			return A_1 >= 0 && A_1 < this.VOuPWFIYsbhWKmxTrsSBRjwMaiEm.Length && this.VOuPWFIYsbhWKmxTrsSBRjwMaiEm[A_1].bWbcWczwVKXLuZuZuUVkcoLAblJh(A_2);
		}

		// Token: 0x060017CE RID: 6094 RVA: 0x0001455B File Offset: 0x0001275B
		public bool klRsiofXNLdPLydEAJZOpmZgNpjn(int A_1, int A_2)
		{
			return A_1 >= 0 && A_1 < this.VOuPWFIYsbhWKmxTrsSBRjwMaiEm.Length && this.VOuPWFIYsbhWKmxTrsSBRjwMaiEm[A_1].KVOHUmTaEVcPEgYLgVTKbCSNfMZB(A_2);
		}

		// Token: 0x060017CF RID: 6095 RVA: 0x0001457C File Offset: 0x0001277C
		public bool hUAlrjGqbbTJYHOFKGFftrRNlSMn(int A_1, int A_2)
		{
			return A_1 >= 0 && A_1 < this.VOuPWFIYsbhWKmxTrsSBRjwMaiEm.Length && this.VOuPWFIYsbhWKmxTrsSBRjwMaiEm[A_1].cXzvVJhPonUcXEfFdTyhoRgSqkzo(A_2);
		}

		// Token: 0x060017D0 RID: 6096 RVA: 0x0001459D File Offset: 0x0001279D
		public bool vDUERFuKdMFIfrzOSNkCaoQbHTqU(int A_1, int A_2, bool A_3)
		{
			return A_1 >= 0 && A_1 < this.VOuPWFIYsbhWKmxTrsSBRjwMaiEm.Length && this.VOuPWFIYsbhWKmxTrsSBRjwMaiEm[A_1].oFyXdgwSPivRntCJfeFsJjKihehs(A_2, A_3);
		}

		// Token: 0x060017D1 RID: 6097 RVA: 0x000145BF File Offset: 0x000127BF
		public bool UJEaSefpzsKbseuhcMrfwtrLNdiFA(int A_1)
		{
			return this.lGSlTWtieuPrUSZKvufpIJvKiJUL.bcDoVSXopodrSLJvTbeRmQESwMqm(A_1);
		}

		// Token: 0x060017D2 RID: 6098 RVA: 0x000145CD File Offset: 0x000127CD
		public bool bYWEmEEzcVqMiaDYhUHOiwwUaqJlA(int A_1)
		{
			return this.lGSlTWtieuPrUSZKvufpIJvKiJUL.HMRVudAIaDduaFFBsFRKqmzLcXvsA(A_1);
		}

		// Token: 0x060017D3 RID: 6099 RVA: 0x000145DB File Offset: 0x000127DB
		public bool DUYagzOhRgpTWjwgqdIKRRCTFetu(int A_1)
		{
			return this.lGSlTWtieuPrUSZKvufpIJvKiJUL.iOYrLsiqiJsIcNuaRlHSHnyWDijr(A_1);
		}

		// Token: 0x060017D4 RID: 6100 RVA: 0x0006F038 File Offset: 0x0006D238
		public void IVWCtxOMDpSUwuLHWutjQgAmFbmDA()
		{
			for (int i = 0; i < this.VOuPWFIYsbhWKmxTrsSBRjwMaiEm.Length; i++)
			{
				this.VOuPWFIYsbhWKmxTrsSBRjwMaiEm[i].qWHiOcNSsLRbHEFxJixlLPstFmdX();
			}
			this.lGSlTWtieuPrUSZKvufpIJvKiJUL.htQYcpTPErSqTOVkiVeoJPuGGTzg();
		}

		// Token: 0x04000D11 RID: 3345
		private ykQBbCYXhmFNZdFinwXsPZYFmYFE.xHxaJcUPoeNmEhBiAwbpKuoFFcGN.nrpatPGZCdKgVnhjzhpaskqfhKyJA[] VOuPWFIYsbhWKmxTrsSBRjwMaiEm;

		// Token: 0x04000D12 RID: 3346
		private ykQBbCYXhmFNZdFinwXsPZYFmYFE.xHxaJcUPoeNmEhBiAwbpKuoFFcGN.aDJacxRLpRsnPrmgFDslwPBAjbao lGSlTWtieuPrUSZKvufpIJvKiJUL;

		// Token: 0x020001D1 RID: 465
		private class nrpatPGZCdKgVnhjzhpaskqfhKyJA
		{
			// Token: 0x060017D5 RID: 6101 RVA: 0x0006F070 File Offset: 0x0006D270
			public nrpatPGZCdKgVnhjzhpaskqfhKyJA(int A_1)
			{
				this.TWjMgjtkokaWlrjlDSNNVAovHTiw = A_1;
				this.skZruXZSATaxErCfPImqJQYtuNesA = new ykQBbCYXhmFNZdFinwXsPZYFmYFE.xHxaJcUPoeNmEhBiAwbpKuoFFcGN.fBxByAXuGJfdOCTUPPmLqauZIzsJA[20];
				for (int i = 0; i < this.skZruXZSATaxErCfPImqJQYtuNesA.Length; i++)
				{
					this.skZruXZSATaxErCfPImqJQYtuNesA[i] = new ykQBbCYXhmFNZdFinwXsPZYFmYFE.xHxaJcUPoeNmEhBiAwbpKuoFFcGN.fBxByAXuGJfdOCTUPPmLqauZIzsJA();
				}
				this.lAmMfjGvvCdTlPKusAEnTUiLHGgiA = new ykQBbCYXhmFNZdFinwXsPZYFmYFE.xHxaJcUPoeNmEhBiAwbpKuoFFcGN.gEyUjaLeTCaAakOxWyLRQnGpoyKU[29];
				for (int j = 0; j < this.lAmMfjGvvCdTlPKusAEnTUiLHGgiA.Length; j++)
				{
					this.lAmMfjGvvCdTlPKusAEnTUiLHGgiA[j] = new ykQBbCYXhmFNZdFinwXsPZYFmYFE.xHxaJcUPoeNmEhBiAwbpKuoFFcGN.gEyUjaLeTCaAakOxWyLRQnGpoyKU(j);
				}
			}

			// Token: 0x060017D6 RID: 6102 RVA: 0x0006F0E8 File Offset: 0x0006D2E8
			public void VCnKMKyDaZhbljCQWzDNmlYHKcbDb()
			{
				for (int i = 0; i < this.skZruXZSATaxErCfPImqJQYtuNesA.Length; i++)
				{
					bool joystickButtonValueByJoystickIndex = UnityInputHelper.GetJoystickButtonValueByJoystickIndex(this.TWjMgjtkokaWlrjlDSNNVAovHTiw, i);
					this.skZruXZSATaxErCfPImqJQYtuNesA[i].JwrEZZwJdIcLquMyJfaauCrMDLQp(joystickButtonValueByJoystickIndex);
				}
				for (int j = 0; j < this.lAmMfjGvvCdTlPKusAEnTUiLHGgiA.Length; j++)
				{
					float joystickAxisRawValueByJoystickIndex = UnityInputHelper.GetJoystickAxisRawValueByJoystickIndex(this.TWjMgjtkokaWlrjlDSNNVAovHTiw, j);
					this.lAmMfjGvvCdTlPKusAEnTUiLHGgiA[j].lapeTZIJmsOiWQZqTsEuvwckBIwhA(joystickAxisRawValueByJoystickIndex);
				}
			}

			// Token: 0x060017D7 RID: 6103 RVA: 0x0006F154 File Offset: 0x0006D354
			public void bCmNHkzepZjJiIFuxSKMDECgxfOt()
			{
				for (int i = 0; i < this.skZruXZSATaxErCfPImqJQYtuNesA.Length; i++)
				{
					this.skZruXZSATaxErCfPImqJQYtuNesA[i].TnImJXuitMBEzEoUFztLPqKElMTk = UnityInputHelper.GetJoystickButtonValueByJoystickIndex(this.TWjMgjtkokaWlrjlDSNNVAovHTiw, i);
				}
				for (int j = 0; j < this.lAmMfjGvvCdTlPKusAEnTUiLHGgiA.Length; j++)
				{
					this.lAmMfjGvvCdTlPKusAEnTUiLHGgiA[j].XbHVaBIBJdYCygZIlHzNORQNFAUw = UnityInputHelper.GetJoystickAxisRawValueByJoystickIndex(this.TWjMgjtkokaWlrjlDSNNVAovHTiw, j);
				}
			}

			// Token: 0x060017D8 RID: 6104 RVA: 0x000145E9 File Offset: 0x000127E9
			public bool bWbcWczwVKXLuZuZuUVkcoLAblJh(int A_1)
			{
				return A_1 >= 0 && A_1 < this.skZruXZSATaxErCfPImqJQYtuNesA.Length && this.skZruXZSATaxErCfPImqJQYtuNesA[A_1].TnImJXuitMBEzEoUFztLPqKElMTk;
			}

			// Token: 0x060017D9 RID: 6105 RVA: 0x00014609 File Offset: 0x00012809
			public bool KVOHUmTaEVcPEgYLgVTKbCSNfMZB(int A_1)
			{
				return A_1 >= 0 && A_1 < this.skZruXZSATaxErCfPImqJQYtuNesA.Length && this.skZruXZSATaxErCfPImqJQYtuNesA[A_1].ULkcRViuNHiEVRQkUqTXNFsNHKyv;
			}

			// Token: 0x060017DA RID: 6106 RVA: 0x00014629 File Offset: 0x00012829
			public bool cXzvVJhPonUcXEfFdTyhoRgSqkzo(int A_1)
			{
				return A_1 >= 0 && A_1 < this.skZruXZSATaxErCfPImqJQYtuNesA.Length && this.skZruXZSATaxErCfPImqJQYtuNesA[A_1].bvPzXmSWfIILCCttSvOqvBnSHLpY;
			}

			// Token: 0x060017DB RID: 6107 RVA: 0x00014649 File Offset: 0x00012849
			public float DQTGSSBmkszHWsLNwQAxEuvPTsauA(int A_1)
			{
				if (A_1 < 0 || A_1 >= this.lAmMfjGvvCdTlPKusAEnTUiLHGgiA.Length)
				{
					return 0f;
				}
				return this.lAmMfjGvvCdTlPKusAEnTUiLHGgiA[A_1].XbHVaBIBJdYCygZIlHzNORQNFAUw;
			}

			// Token: 0x060017DC RID: 6108 RVA: 0x0001466D File Offset: 0x0001286D
			public bool oFyXdgwSPivRntCJfeFsJjKihehs(int A_1, bool A_2)
			{
				return A_1 >= 0 && A_1 < this.lAmMfjGvvCdTlPKusAEnTUiLHGgiA.Length && this.lAmMfjGvvCdTlPKusAEnTUiLHGgiA[A_1].bdEXtsWugCgjovxjcUmyfwuQgrdR(A_2);
			}

			// Token: 0x060017DD RID: 6109 RVA: 0x0006F1BC File Offset: 0x0006D3BC
			public void qWHiOcNSsLRbHEFxJixlLPstFmdX()
			{
				for (int i = 0; i < this.skZruXZSATaxErCfPImqJQYtuNesA.Length; i++)
				{
					this.skZruXZSATaxErCfPImqJQYtuNesA[i].iSnBXUboVyhsuvadeooafAqNtxogA();
				}
				for (int j = 0; j < this.lAmMfjGvvCdTlPKusAEnTUiLHGgiA.Length; j++)
				{
					this.lAmMfjGvvCdTlPKusAEnTUiLHGgiA[j].lbyWFfEhtkOulOEeqDXdYLdfFEoE();
				}
			}

			// Token: 0x04000D13 RID: 3347
			private int TWjMgjtkokaWlrjlDSNNVAovHTiw;

			// Token: 0x04000D14 RID: 3348
			private ykQBbCYXhmFNZdFinwXsPZYFmYFE.xHxaJcUPoeNmEhBiAwbpKuoFFcGN.fBxByAXuGJfdOCTUPPmLqauZIzsJA[] skZruXZSATaxErCfPImqJQYtuNesA;

			// Token: 0x04000D15 RID: 3349
			private ykQBbCYXhmFNZdFinwXsPZYFmYFE.xHxaJcUPoeNmEhBiAwbpKuoFFcGN.gEyUjaLeTCaAakOxWyLRQnGpoyKU[] lAmMfjGvvCdTlPKusAEnTUiLHGgiA;
		}

		// Token: 0x020001D2 RID: 466
		private class aDJacxRLpRsnPrmgFDslwPBAjbao
		{
			// Token: 0x060017DE RID: 6110 RVA: 0x0006F20C File Offset: 0x0006D40C
			public aDJacxRLpRsnPrmgFDslwPBAjbao()
			{
				this.FOhlHMOcmbznQylypCaFeXvopjAeA = new ykQBbCYXhmFNZdFinwXsPZYFmYFE.xHxaJcUPoeNmEhBiAwbpKuoFFcGN.fBxByAXuGJfdOCTUPPmLqauZIzsJA[7];
				for (int i = 0; i < this.FOhlHMOcmbznQylypCaFeXvopjAeA.Length; i++)
				{
					this.FOhlHMOcmbznQylypCaFeXvopjAeA[i] = new ykQBbCYXhmFNZdFinwXsPZYFmYFE.xHxaJcUPoeNmEhBiAwbpKuoFFcGN.fBxByAXuGJfdOCTUPPmLqauZIzsJA();
				}
			}

			// Token: 0x060017DF RID: 6111 RVA: 0x0006F24C File Offset: 0x0006D44C
			public void lkVKgknVmNdZVTjoTAgNjCyDafnBA()
			{
				for (int i = 0; i < this.FOhlHMOcmbznQylypCaFeXvopjAeA.Length; i++)
				{
					this.FOhlHMOcmbznQylypCaFeXvopjAeA[i].TnImJXuitMBEzEoUFztLPqKElMTk = Input.GetButton("MouseButton" + i.ToString());
				}
			}

			// Token: 0x060017E0 RID: 6112 RVA: 0x0001468E File Offset: 0x0001288E
			public bool bcDoVSXopodrSLJvTbeRmQESwMqm(int A_1)
			{
				return A_1 >= 0 && A_1 < this.FOhlHMOcmbznQylypCaFeXvopjAeA.Length && this.FOhlHMOcmbznQylypCaFeXvopjAeA[A_1].TnImJXuitMBEzEoUFztLPqKElMTk;
			}

			// Token: 0x060017E1 RID: 6113 RVA: 0x000146AE File Offset: 0x000128AE
			public bool HMRVudAIaDduaFFBsFRKqmzLcXvsA(int A_1)
			{
				return A_1 >= 0 && A_1 < this.FOhlHMOcmbznQylypCaFeXvopjAeA.Length && this.FOhlHMOcmbznQylypCaFeXvopjAeA[A_1].ULkcRViuNHiEVRQkUqTXNFsNHKyv;
			}

			// Token: 0x060017E2 RID: 6114 RVA: 0x000146CE File Offset: 0x000128CE
			public bool iOYrLsiqiJsIcNuaRlHSHnyWDijr(int A_1)
			{
				return A_1 >= 0 && A_1 < this.FOhlHMOcmbznQylypCaFeXvopjAeA.Length && this.FOhlHMOcmbznQylypCaFeXvopjAeA[A_1].bvPzXmSWfIILCCttSvOqvBnSHLpY;
			}

			// Token: 0x060017E3 RID: 6115 RVA: 0x0006F290 File Offset: 0x0006D490
			public void htQYcpTPErSqTOVkiVeoJPuGGTzg()
			{
				for (int i = 0; i < this.FOhlHMOcmbznQylypCaFeXvopjAeA.Length; i++)
				{
					this.FOhlHMOcmbznQylypCaFeXvopjAeA[i].iSnBXUboVyhsuvadeooafAqNtxogA();
				}
			}

			// Token: 0x04000D16 RID: 3350
			private ykQBbCYXhmFNZdFinwXsPZYFmYFE.xHxaJcUPoeNmEhBiAwbpKuoFFcGN.fBxByAXuGJfdOCTUPPmLqauZIzsJA[] FOhlHMOcmbznQylypCaFeXvopjAeA;
		}

		// Token: 0x020001D3 RID: 467
		private class fBxByAXuGJfdOCTUPPmLqauZIzsJA
		{
			// Token: 0x170005A8 RID: 1448
			// (get) Token: 0x060017E4 RID: 6116 RVA: 0x000146EE File Offset: 0x000128EE
			// (set) Token: 0x060017E5 RID: 6117 RVA: 0x000146F6 File Offset: 0x000128F6
			public bool TnImJXuitMBEzEoUFztLPqKElMTk
			{
				get
				{
					return this.OYcAvFgDqllreVQgdwTVjMYfHNisA;
				}
				set
				{
					this.iPPRRznuAUVeXBuYZozKcJeCIFOi = this.OYcAvFgDqllreVQgdwTVjMYfHNisA;
					this.OYcAvFgDqllreVQgdwTVjMYfHNisA = value;
				}
			}

			// Token: 0x170005A9 RID: 1449
			// (get) Token: 0x060017E6 RID: 6118 RVA: 0x0001470B File Offset: 0x0001290B
			public bool ULkcRViuNHiEVRQkUqTXNFsNHKyv
			{
				get
				{
					return this.OYcAvFgDqllreVQgdwTVjMYfHNisA && !this.iPPRRznuAUVeXBuYZozKcJeCIFOi;
				}
			}

			// Token: 0x170005AA RID: 1450
			// (get) Token: 0x060017E7 RID: 6119 RVA: 0x00014720 File Offset: 0x00012920
			public bool bvPzXmSWfIILCCttSvOqvBnSHLpY
			{
				get
				{
					return this.iPPRRznuAUVeXBuYZozKcJeCIFOi && !this.OYcAvFgDqllreVQgdwTVjMYfHNisA;
				}
			}

			// Token: 0x060017E8 RID: 6120 RVA: 0x00014735 File Offset: 0x00012935
			public void JwrEZZwJdIcLquMyJfaauCrMDLQp(bool A_1)
			{
				this.OYcAvFgDqllreVQgdwTVjMYfHNisA = A_1;
				this.iPPRRznuAUVeXBuYZozKcJeCIFOi = A_1;
			}

			// Token: 0x060017E9 RID: 6121 RVA: 0x00014745 File Offset: 0x00012945
			public void iSnBXUboVyhsuvadeooafAqNtxogA()
			{
				this.OYcAvFgDqllreVQgdwTVjMYfHNisA = false;
				this.iPPRRznuAUVeXBuYZozKcJeCIFOi = false;
			}

			// Token: 0x04000D17 RID: 3351
			private bool OYcAvFgDqllreVQgdwTVjMYfHNisA;

			// Token: 0x04000D18 RID: 3352
			private bool iPPRRznuAUVeXBuYZozKcJeCIFOi;
		}

		// Token: 0x020001D4 RID: 468
		private class gEyUjaLeTCaAakOxWyLRQnGpoyKU
		{
			// Token: 0x170005AB RID: 1451
			// (get) Token: 0x060017EB RID: 6123 RVA: 0x00014755 File Offset: 0x00012955
			// (set) Token: 0x060017EC RID: 6124 RVA: 0x0001475D File Offset: 0x0001295D
			public float XbHVaBIBJdYCygZIlHzNORQNFAUw
			{
				get
				{
					return this.oefwqbRsvSGRJKmVoSNsCjprogNO;
				}
				set
				{
					this.oefwqbRsvSGRJKmVoSNsCjprogNO = value;
				}
			}

			// Token: 0x060017ED RID: 6125 RVA: 0x00014766 File Offset: 0x00012966
			public gEyUjaLeTCaAakOxWyLRQnGpoyKU(int A_1)
			{
				this.xoGmyqerqtgBLYMfGVMxwRRljfOG = A_1;
			}

			// Token: 0x060017EE RID: 6126 RVA: 0x00014775 File Offset: 0x00012975
			public void lapeTZIJmsOiWQZqTsEuvwckBIwhA(float A_1)
			{
				this.IgPFIcHVcWsTGfaswncrnmWLCWNt = A_1;
				this.oefwqbRsvSGRJKmVoSNsCjprogNO = A_1;
			}

			// Token: 0x060017EF RID: 6127 RVA: 0x0006F2C0 File Offset: 0x0006D4C0
			public bool bdEXtsWugCgjovxjcUmyfwuQgrdR(bool A_1)
			{
				float num = this.oefwqbRsvSGRJKmVoSNsCjprogNO - this.IgPFIcHVcWsTGfaswncrnmWLCWNt;
				return (!A_1 || num >= 0f) && MathTools.Abs(num) > 0.7f;
			}

			// Token: 0x060017F0 RID: 6128 RVA: 0x00014785 File Offset: 0x00012985
			public void lbyWFfEhtkOulOEeqDXdYLdfFEoE()
			{
				this.oefwqbRsvSGRJKmVoSNsCjprogNO = 0f;
				this.IgPFIcHVcWsTGfaswncrnmWLCWNt = 0f;
			}

			// Token: 0x04000D19 RID: 3353
			private int xoGmyqerqtgBLYMfGVMxwRRljfOG;

			// Token: 0x04000D1A RID: 3354
			private float oefwqbRsvSGRJKmVoSNsCjprogNO;

			// Token: 0x04000D1B RID: 3355
			private float IgPFIcHVcWsTGfaswncrnmWLCWNt;
		}
	}
}
