using System;
using System.Runtime.CompilerServices;
using Rewired;
using Rewired.Config;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

// Token: 0x020002DF RID: 735
internal class TDbKvyrtcOKmakPyYMqLcuNLqPbe : JGFbzxrKsMtqJZQTcBBDYcUaYRLl
{
	// Token: 0x1700036D RID: 877
	// (get) Token: 0x0600159E RID: 5534 RVA: 0x0001C1EA File Offset: 0x0001A3EA
	public float[] oxrAVCGYVAsFpNwvvghIcKXCXRPLA
	{
		get
		{
			return (this.InZtVzhOMxUowYlAfTZXwgYyTApB as TDbKvyrtcOKmakPyYMqLcuNLqPbe.apTwCAsOXRWjAhYOLonrQcmWFnBc).IRltsURPZqnkfqBWMhwIImtLrjIR;
		}
	}

	// Token: 0x1700036E RID: 878
	// (get) Token: 0x0600159F RID: 5535 RVA: 0x0001C1FC File Offset: 0x0001A3FC
	public RingBuffer<TDbKvyrtcOKmakPyYMqLcuNLqPbe.TFPARbbNAvPzQuJwQCaWGkjzhFcEA> CxhCZOFOLzfwwTtqOruQEcpotRwP
	{
		get
		{
			return (this.InZtVzhOMxUowYlAfTZXwgYyTApB as TDbKvyrtcOKmakPyYMqLcuNLqPbe.apTwCAsOXRWjAhYOLonrQcmWFnBc).cNpqcTVnTdbjVRfRUzBHxwJTRzOp;
		}
	}

	// Token: 0x060015A0 RID: 5536 RVA: 0x0004BF48 File Offset: 0x0004A148
	public TDbKvyrtcOKmakPyYMqLcuNLqPbe(UpdateLoopSetting A_1, byte A_2, zHTBvVyhFGDLpEJMFINchPNfqnfnb.HIDInfo A_3, int A_4, int A_5, Action<byte[], float[]> A_6, Func<float> A_7) : base(new TDbKvyrtcOKmakPyYMqLcuNLqPbe.apTwCAsOXRWjAhYOLonrQcmWFnBc(A_1, A_4, A_5), A_2, A_3)
	{
		this.CvrbxMijQOqoNixNBrBUtnnxddHhb = A_4;
		this.BfspaAOcgyaBQZLdJDgqUXniaxvO = A_6;
		this.rIziXoyEcrjPZmbpCdQYYZkInnjG = A_7;
		this.IBHfhfkVQFRnlCTeMMDggrGvUgYz = ((A_3.bitSize > 0) ? ((A_3.bitSize + 8 - 1) / 8) : 0);
		this.KndrWGhRCAfhjpyHJwZqVBuratTFA = A_3.dataIndex;
		this.bokDCAXjHrsBLvIKSRHpdgSPrVSc = new byte[this.IBHfhfkVQFRnlCTeMMDggrGvUgYz];
		this.WTmpLsKEsZPOCVdvZSfRJABFFlMGA = new float[A_4];
		this.dcPcKZhVzOuuuyblktasXCrYPsIq = new float[A_4];
	}

	// Token: 0x060015A1 RID: 5537 RVA: 0x0004BFD4 File Offset: 0x0004A1D4
	public virtual void LodhgUiNLoldpNryJViDlzJRSTrJ(NativeBuffer A_1, double A_2)
	{
		if (A_1 == null)
		{
			return;
		}
		if (A_1[0] != this.ZEmAzjmzLpNGaBBQPUjRDHfQsujS)
		{
			return;
		}
		this.ELyLxStcQJWOPbdaGzbkIWpNGteU = A_2;
		for (int i = 0; i < this.IBHfhfkVQFRnlCTeMMDggrGvUgYz; i++)
		{
			this.bokDCAXjHrsBLvIKSRHpdgSPrVSc[i] = A_1[this.KndrWGhRCAfhjpyHJwZqVBuratTFA + i];
		}
		if (this.BfspaAOcgyaBQZLdJDgqUXniaxvO != null)
		{
			this.BfspaAOcgyaBQZLdJDgqUXniaxvO(this.bokDCAXjHrsBLvIKSRHpdgSPrVSc, this.WTmpLsKEsZPOCVdvZSfRJABFFlMGA);
		}
		float num = (this.rIziXoyEcrjPZmbpCdQYYZkInnjG != null) ? this.rIziXoyEcrjPZmbpCdQYYZkInnjG() : 0f;
		(this.InZtVzhOMxUowYlAfTZXwgYyTApB as TDbKvyrtcOKmakPyYMqLcuNLqPbe.apTwCAsOXRWjAhYOLonrQcmWFnBc).fwwWfwCQcMYsRTxKrRJaqorUYTbl(this.WTmpLsKEsZPOCVdvZSfRJABFFlMGA, num);
		for (int j = 0; j < this.CvrbxMijQOqoNixNBrBUtnnxddHhb; j++)
		{
			this.dcPcKZhVzOuuuyblktasXCrYPsIq[j] = this.WTmpLsKEsZPOCVdvZSfRJABFFlMGA[j];
		}
	}

	// Token: 0x060015A2 RID: 5538 RVA: 0x0004C098 File Offset: 0x0004A298
	public void bgrtYtzRBpKqXdaZnddkIldxWWvq(float[] A_1, double A_2)
	{
		this.ELyLxStcQJWOPbdaGzbkIWpNGteU = A_2;
		float num = (this.rIziXoyEcrjPZmbpCdQYYZkInnjG != null) ? this.rIziXoyEcrjPZmbpCdQYYZkInnjG() : 0f;
		for (int i = 0; i < this.CvrbxMijQOqoNixNBrBUtnnxddHhb; i++)
		{
			this.WTmpLsKEsZPOCVdvZSfRJABFFlMGA[i] = A_1[i];
		}
		(this.InZtVzhOMxUowYlAfTZXwgYyTApB as TDbKvyrtcOKmakPyYMqLcuNLqPbe.apTwCAsOXRWjAhYOLonrQcmWFnBc).fwwWfwCQcMYsRTxKrRJaqorUYTbl(this.WTmpLsKEsZPOCVdvZSfRJABFFlMGA, num);
		for (int j = 0; j < this.CvrbxMijQOqoNixNBrBUtnnxddHhb; j++)
		{
			this.dcPcKZhVzOuuuyblktasXCrYPsIq[j] = this.WTmpLsKEsZPOCVdvZSfRJABFFlMGA[j];
		}
	}

	// Token: 0x04002F37 RID: 12087
	public double ELyLxStcQJWOPbdaGzbkIWpNGteU;

	// Token: 0x04002F38 RID: 12088
	public readonly float[] dcPcKZhVzOuuuyblktasXCrYPsIq;

	// Token: 0x04002F39 RID: 12089
	public readonly int CvrbxMijQOqoNixNBrBUtnnxddHhb;

	// Token: 0x04002F3A RID: 12090
	private readonly byte[] bokDCAXjHrsBLvIKSRHpdgSPrVSc;

	// Token: 0x04002F3B RID: 12091
	private readonly float[] WTmpLsKEsZPOCVdvZSfRJABFFlMGA;

	// Token: 0x04002F3C RID: 12092
	private readonly int IBHfhfkVQFRnlCTeMMDggrGvUgYz;

	// Token: 0x04002F3D RID: 12093
	private readonly int KndrWGhRCAfhjpyHJwZqVBuratTFA;

	// Token: 0x04002F3E RID: 12094
	private readonly Action<byte[], float[]> BfspaAOcgyaBQZLdJDgqUXniaxvO;

	// Token: 0x04002F3F RID: 12095
	private readonly Func<float> rIziXoyEcrjPZmbpCdQYYZkInnjG;

	// Token: 0x020002E0 RID: 736
	internal class apTwCAsOXRWjAhYOLonrQcmWFnBc : JGFbzxrKsMtqJZQTcBBDYcUaYRLl.UxTPMCWPXdPGmxJSAAiaIMUGYnZDA
	{
		// Token: 0x1700036F RID: 879
		// (get) Token: 0x060015A3 RID: 5539 RVA: 0x0001C20E File Offset: 0x0001A40E
		public float[] IRltsURPZqnkfqBWMhwIImtLrjIR
		{
			get
			{
				return (this.uQOLOCSMTTRLHAPKrDnqcKqBEOxeb as TDbKvyrtcOKmakPyYMqLcuNLqPbe.VPcdHEJSUhEdeRLRqMjkRMqTJRtgA).aYXUOjbgHLChuzEJNbohLdNpkcmi;
			}
		}

		// Token: 0x17000370 RID: 880
		// (get) Token: 0x060015A4 RID: 5540 RVA: 0x0001C220 File Offset: 0x0001A420
		public RingBuffer<TDbKvyrtcOKmakPyYMqLcuNLqPbe.TFPARbbNAvPzQuJwQCaWGkjzhFcEA> cNpqcTVnTdbjVRfRUzBHxwJTRzOp
		{
			get
			{
				return (this.uQOLOCSMTTRLHAPKrDnqcKqBEOxeb as TDbKvyrtcOKmakPyYMqLcuNLqPbe.VPcdHEJSUhEdeRLRqMjkRMqTJRtgA).gPzecieKfpjMMIlXzOPlNeTgCvB;
			}
		}

		// Token: 0x060015A5 RID: 5541 RVA: 0x0001C232 File Offset: 0x0001A432
		public apTwCAsOXRWjAhYOLonrQcmWFnBc(UpdateLoopSetting A_1, int A_2, int A_3)
		{
			this.gxUGNhbnbTZEkDvbfSUnFaCrriBG = A_2;
			this.XByawnitRphLWYTLcPgzEdemMBLxA = A_3;
			base.pFtGBKZfLwRqlkbLeQwHWGIbkJgx(A_1, new Func<UpdateLoopType, JGFbzxrKsMtqJZQTcBBDYcUaYRLl.yPBPgWtSRCZnxqcPhEOyFjuHDOLO>(this.nmmzkvIgBJRFeFWznGDHHcEddTmY));
		}

		// Token: 0x060015A6 RID: 5542 RVA: 0x0001C25B File Offset: 0x0001A45B
		public virtual void YexRRSAUUurhlRtRmpRqgJbWEfNp(UpdateLoopType A_1)
		{
			base.wVeLnxGFPrfeFduhlOubnjkXiPCEb(A_1);
			(this.uQOLOCSMTTRLHAPKrDnqcKqBEOxeb as TDbKvyrtcOKmakPyYMqLcuNLqPbe.VPcdHEJSUhEdeRLRqMjkRMqTJRtgA).KSiCVscAWLBLsMsvVyHPkPQxnqSj();
		}

		// Token: 0x060015A7 RID: 5543 RVA: 0x0004C11C File Offset: 0x0004A31C
		public void fwwWfwCQcMYsRTxKrRJaqorUYTbl(float[] A_1, float A_2)
		{
			for (int i = 0; i < this.sodTncZlIGFzNBOAdyDpfHjSzgzsA.Length; i++)
			{
				(this.sodTncZlIGFzNBOAdyDpfHjSzgzsA[i] as TDbKvyrtcOKmakPyYMqLcuNLqPbe.VPcdHEJSUhEdeRLRqMjkRMqTJRtgA).YNMSvUNZYHgASWkqvqZCNVPcQsAW(A_1, A_2);
			}
		}

		// Token: 0x060015A8 RID: 5544 RVA: 0x0001C274 File Offset: 0x0001A474
		private JGFbzxrKsMtqJZQTcBBDYcUaYRLl.yPBPgWtSRCZnxqcPhEOyFjuHDOLO nmmzkvIgBJRFeFWznGDHHcEddTmY(UpdateLoopType A_1)
		{
			return new TDbKvyrtcOKmakPyYMqLcuNLqPbe.VPcdHEJSUhEdeRLRqMjkRMqTJRtgA(A_1, this.gxUGNhbnbTZEkDvbfSUnFaCrriBG, this.XByawnitRphLWYTLcPgzEdemMBLxA);
		}

		// Token: 0x04002F40 RID: 12096
		private int gxUGNhbnbTZEkDvbfSUnFaCrriBG;

		// Token: 0x04002F41 RID: 12097
		private int XByawnitRphLWYTLcPgzEdemMBLxA;
	}

	// Token: 0x020002E1 RID: 737
	internal class VPcdHEJSUhEdeRLRqMjkRMqTJRtgA : JGFbzxrKsMtqJZQTcBBDYcUaYRLl.yPBPgWtSRCZnxqcPhEOyFjuHDOLO
	{
		// Token: 0x060015A9 RID: 5545 RVA: 0x0004C150 File Offset: 0x0004A350
		public VPcdHEJSUhEdeRLRqMjkRMqTJRtgA(UpdateLoopType A_1, int A_2, int A_3) : base(A_1)
		{
			this.aYXUOjbgHLChuzEJNbohLdNpkcmi = new float[A_2];
			this.haTJuSEBCIrcVSlWvJfFhdkjlcdb = new float[A_2];
			this.gPzecieKfpjMMIlXzOPlNeTgCvB = new RingBuffer<TDbKvyrtcOKmakPyYMqLcuNLqPbe.TFPARbbNAvPzQuJwQCaWGkjzhFcEA>(A_3);
			this.ndKcCwGtIeWbmfUaklLrzKLYqBSbA = new RingBuffer<TDbKvyrtcOKmakPyYMqLcuNLqPbe.TFPARbbNAvPzQuJwQCaWGkjzhFcEA>(A_3);
			this.dDCeeyFTjozsDjfxkOtmhxdfPQhz = new ObjectPool<TDbKvyrtcOKmakPyYMqLcuNLqPbe.TFPARbbNAvPzQuJwQCaWGkjzhFcEA>(A_3, new Func<TDbKvyrtcOKmakPyYMqLcuNLqPbe.TFPARbbNAvPzQuJwQCaWGkjzhFcEA>(TDbKvyrtcOKmakPyYMqLcuNLqPbe.VPcdHEJSUhEdeRLRqMjkRMqTJRtgA.ZuPLspAnJdwTZHUCqtzhZdPPyVZQ.<>9.prsIOZzTOgEakNfxKtHeTLBbAEZbA), null);
		}

		// Token: 0x060015AA RID: 5546 RVA: 0x0004C1C0 File Offset: 0x0004A3C0
		public void KSiCVscAWLBLsMsvVyHPkPQxnqSj()
		{
			for (int i = 0; i < this.haTJuSEBCIrcVSlWvJfFhdkjlcdb.Length; i++)
			{
				this.aYXUOjbgHLChuzEJNbohLdNpkcmi[i] = this.haTJuSEBCIrcVSlWvJfFhdkjlcdb[i];
				this.haTJuSEBCIrcVSlWvJfFhdkjlcdb[i] = 0f;
			}
			CollectionTools.Clear<TDbKvyrtcOKmakPyYMqLcuNLqPbe.TFPARbbNAvPzQuJwQCaWGkjzhFcEA>(this.dDCeeyFTjozsDjfxkOtmhxdfPQhz, this.gPzecieKfpjMMIlXzOPlNeTgCvB);
			int count = this.ndKcCwGtIeWbmfUaklLrzKLYqBSbA.Count;
			for (int j = 0; j < count; j++)
			{
				TDbKvyrtcOKmakPyYMqLcuNLqPbe.TFPARbbNAvPzQuJwQCaWGkjzhFcEA tfparbbNAvPzQuJwQCaWGkjzhFcEA = this.dDCeeyFTjozsDjfxkOtmhxdfPQhz.Get();
				tfparbbNAvPzQuJwQCaWGkjzhFcEA.RvsaapwmVgWRIgYyWDvadpiqFsnfA(this.ndKcCwGtIeWbmfUaklLrzKLYqBSbA[j]);
				bool flag;
				CollectionTools.Enqueue<TDbKvyrtcOKmakPyYMqLcuNLqPbe.TFPARbbNAvPzQuJwQCaWGkjzhFcEA>(this.dDCeeyFTjozsDjfxkOtmhxdfPQhz, this.gPzecieKfpjMMIlXzOPlNeTgCvB, tfparbbNAvPzQuJwQCaWGkjzhFcEA, out flag);
			}
			CollectionTools.Clear<TDbKvyrtcOKmakPyYMqLcuNLqPbe.TFPARbbNAvPzQuJwQCaWGkjzhFcEA>(this.dDCeeyFTjozsDjfxkOtmhxdfPQhz, this.ndKcCwGtIeWbmfUaklLrzKLYqBSbA);
		}

		// Token: 0x060015AB RID: 5547 RVA: 0x0004C26C File Offset: 0x0004A46C
		public void YNMSvUNZYHgASWkqvqZCNVPcQsAW(float[] A_1, float A_2)
		{
			for (int i = 0; i < this.haTJuSEBCIrcVSlWvJfFhdkjlcdb.Length; i++)
			{
				this.haTJuSEBCIrcVSlWvJfFhdkjlcdb[i] += A_1[i];
			}
			TDbKvyrtcOKmakPyYMqLcuNLqPbe.TFPARbbNAvPzQuJwQCaWGkjzhFcEA tfparbbNAvPzQuJwQCaWGkjzhFcEA = this.dDCeeyFTjozsDjfxkOtmhxdfPQhz.Get();
			tfparbbNAvPzQuJwQCaWGkjzhFcEA.zpsgBGexIcYEiadJsdfuENXhENQrB(A_1, A_2);
			bool flag;
			CollectionTools.Enqueue<TDbKvyrtcOKmakPyYMqLcuNLqPbe.TFPARbbNAvPzQuJwQCaWGkjzhFcEA>(this.dDCeeyFTjozsDjfxkOtmhxdfPQhz, this.ndKcCwGtIeWbmfUaklLrzKLYqBSbA, tfparbbNAvPzQuJwQCaWGkjzhFcEA, out flag);
		}

		// Token: 0x060015AC RID: 5548 RVA: 0x0001C288 File Offset: 0x0001A488
		public virtual void JPeZmMmyffqoYaeAUSMzvzchaWaL()
		{
			Array.Clear(this.aYXUOjbgHLChuzEJNbohLdNpkcmi, 0, this.aYXUOjbgHLChuzEJNbohLdNpkcmi.Length);
			CollectionTools.Clear<TDbKvyrtcOKmakPyYMqLcuNLqPbe.TFPARbbNAvPzQuJwQCaWGkjzhFcEA>(this.dDCeeyFTjozsDjfxkOtmhxdfPQhz, this.ndKcCwGtIeWbmfUaklLrzKLYqBSbA);
			CollectionTools.Clear<TDbKvyrtcOKmakPyYMqLcuNLqPbe.TFPARbbNAvPzQuJwQCaWGkjzhFcEA>(this.dDCeeyFTjozsDjfxkOtmhxdfPQhz, this.gPzecieKfpjMMIlXzOPlNeTgCvB);
		}

		// Token: 0x04002F42 RID: 12098
		private float[] haTJuSEBCIrcVSlWvJfFhdkjlcdb;

		// Token: 0x04002F43 RID: 12099
		public float[] aYXUOjbgHLChuzEJNbohLdNpkcmi;

		// Token: 0x04002F44 RID: 12100
		public RingBuffer<TDbKvyrtcOKmakPyYMqLcuNLqPbe.TFPARbbNAvPzQuJwQCaWGkjzhFcEA> gPzecieKfpjMMIlXzOPlNeTgCvB;

		// Token: 0x04002F45 RID: 12101
		private RingBuffer<TDbKvyrtcOKmakPyYMqLcuNLqPbe.TFPARbbNAvPzQuJwQCaWGkjzhFcEA> ndKcCwGtIeWbmfUaklLrzKLYqBSbA;

		// Token: 0x04002F46 RID: 12102
		private ObjectPool<TDbKvyrtcOKmakPyYMqLcuNLqPbe.TFPARbbNAvPzQuJwQCaWGkjzhFcEA> dDCeeyFTjozsDjfxkOtmhxdfPQhz;

		// Token: 0x020002E2 RID: 738
		[CompilerGenerated]
		[Serializable]
		private sealed class ZuPLspAnJdwTZHUCqtzhZdPPyVZQ
		{
			// Token: 0x060015AF RID: 5551 RVA: 0x0001C2CC File Offset: 0x0001A4CC
			internal TDbKvyrtcOKmakPyYMqLcuNLqPbe.TFPARbbNAvPzQuJwQCaWGkjzhFcEA prsIOZzTOgEakNfxKtHeTLBbAEZbA()
			{
				return new TDbKvyrtcOKmakPyYMqLcuNLqPbe.TFPARbbNAvPzQuJwQCaWGkjzhFcEA();
			}

			// Token: 0x04002F47 RID: 12103
			public static readonly TDbKvyrtcOKmakPyYMqLcuNLqPbe.VPcdHEJSUhEdeRLRqMjkRMqTJRtgA.ZuPLspAnJdwTZHUCqtzhZdPPyVZQ <>9 = new TDbKvyrtcOKmakPyYMqLcuNLqPbe.VPcdHEJSUhEdeRLRqMjkRMqTJRtgA.ZuPLspAnJdwTZHUCqtzhZdPPyVZQ();

			// Token: 0x04002F48 RID: 12104
			public static Func<TDbKvyrtcOKmakPyYMqLcuNLqPbe.TFPARbbNAvPzQuJwQCaWGkjzhFcEA> <>9__5_0;
		}
	}

	// Token: 0x020002E3 RID: 739
	public class TFPARbbNAvPzQuJwQCaWGkjzhFcEA
	{
		// Token: 0x060015B0 RID: 5552 RVA: 0x000114A8 File Offset: 0x0000F6A8
		public TFPARbbNAvPzQuJwQCaWGkjzhFcEA()
		{
		}

		// Token: 0x060015B1 RID: 5553 RVA: 0x0001C2D3 File Offset: 0x0001A4D3
		public TFPARbbNAvPzQuJwQCaWGkjzhFcEA(float[] A_1, float A_2)
		{
			this.zpsgBGexIcYEiadJsdfuENXhENQrB(A_1, A_2);
		}

		// Token: 0x060015B2 RID: 5554 RVA: 0x0004C2C8 File Offset: 0x0004A4C8
		public void zpsgBGexIcYEiadJsdfuENXhENQrB(float[] A_1, float A_2)
		{
			int num = MathTools.Min(A_1.Length, 3);
			for (int i = 0; i < num; i++)
			{
				this.pvLAGAwFJrHGOyvACtaBXkmQbXxf[i] = A_1[i];
			}
			this.LXxeqTTliOIfyvHMKPvmZGvcuGex = A_2;
		}

		// Token: 0x060015B3 RID: 5555 RVA: 0x0001C2E3 File Offset: 0x0001A4E3
		public void RvsaapwmVgWRIgYyWDvadpiqFsnfA(TDbKvyrtcOKmakPyYMqLcuNLqPbe.TFPARbbNAvPzQuJwQCaWGkjzhFcEA A_1)
		{
			this.pvLAGAwFJrHGOyvACtaBXkmQbXxf = A_1.pvLAGAwFJrHGOyvACtaBXkmQbXxf;
			this.LXxeqTTliOIfyvHMKPvmZGvcuGex = A_1.LXxeqTTliOIfyvHMKPvmZGvcuGex;
		}

		// Token: 0x060015B4 RID: 5556 RVA: 0x0001C2E3 File Offset: 0x0001A4E3
		public void vxUbQNNFGfwXNYhvXBrVRsXqbvkG(TDbKvyrtcOKmakPyYMqLcuNLqPbe.TFPARbbNAvPzQuJwQCaWGkjzhFcEA A_1)
		{
			this.pvLAGAwFJrHGOyvACtaBXkmQbXxf = A_1.pvLAGAwFJrHGOyvACtaBXkmQbXxf;
			this.LXxeqTTliOIfyvHMKPvmZGvcuGex = A_1.LXxeqTTliOIfyvHMKPvmZGvcuGex;
		}

		// Token: 0x060015B5 RID: 5557 RVA: 0x0001C2FD File Offset: 0x0001A4FD
		public bool tqjEaKZqJZqRgCkYMDrkVdVbaSSK(TDbKvyrtcOKmakPyYMqLcuNLqPbe.TFPARbbNAvPzQuJwQCaWGkjzhFcEA A_1)
		{
			return this.LXxeqTTliOIfyvHMKPvmZGvcuGex == A_1.LXxeqTTliOIfyvHMKPvmZGvcuGex && this.pvLAGAwFJrHGOyvACtaBXkmQbXxf == A_1.pvLAGAwFJrHGOyvACtaBXkmQbXxf;
		}

		// Token: 0x060015B6 RID: 5558 RVA: 0x0001C320 File Offset: 0x0001A520
		public void sbjZgEeLWgbDehZglvDdPuPIKxkr()
		{
			this.pvLAGAwFJrHGOyvACtaBXkmQbXxf.x = 0f;
			this.pvLAGAwFJrHGOyvACtaBXkmQbXxf.y = 0f;
			this.pvLAGAwFJrHGOyvACtaBXkmQbXxf.z = 0f;
			this.LXxeqTTliOIfyvHMKPvmZGvcuGex = 0f;
		}

		// Token: 0x04002F49 RID: 12105
		public Vector3 pvLAGAwFJrHGOyvACtaBXkmQbXxf;

		// Token: 0x04002F4A RID: 12106
		public float LXxeqTTliOIfyvHMKPvmZGvcuGex;
	}
}
