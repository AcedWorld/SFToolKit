using System;
using System.Runtime.InteropServices;

namespace Rewired
{
	// Token: 0x02000042 RID: 66
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal struct LowLevelInputEvent
	{
		// Token: 0x17000091 RID: 145
		// (get) Token: 0x06000274 RID: 628 RVA: 0x00004144 File Offset: 0x00002344
		public bool isValid
		{
			get
			{
				return this._buffer != IntPtr.Zero;
			}
		}

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x06000275 RID: 629 RVA: 0x00004156 File Offset: 0x00002356
		public int buttonCount
		{
			get
			{
				return this.UjIOuTeUKtWudmKoZMkuxfSZQATS;
			}
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x06000276 RID: 630 RVA: 0x0000415E File Offset: 0x0000235E
		public int axisCount
		{
			get
			{
				return this.gyVDTZtBJysjUmYbiTiQVbWNYoeV;
			}
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x06000277 RID: 631 RVA: 0x00004166 File Offset: 0x00002366
		public int byteIndex_axesStart
		{
			get
			{
				return this.AvleGarplmwJyTBtjvwYtwVTfqMn;
			}
		}

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x06000278 RID: 632 RVA: 0x0000416E File Offset: 0x0000236E
		public int byteIndex_buttonsStart
		{
			get
			{
				return this.KGKYdeyegIBFBcQfhIrNddFkLBxXb;
			}
		}

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x06000279 RID: 633 RVA: 0x00004176 File Offset: 0x00002376
		public int byteIndex_hatsStart
		{
			get
			{
				return this.tEEAstHDirqHBnBeEnnbFFPglFVfb;
			}
		}

		// Token: 0x0600027A RID: 634 RVA: 0x0002ED1C File Offset: 0x0002CF1C
		public LowLevelInputEvent(IntPtr A_1, int A_2, int A_3, int A_4)
		{
			if (A_2 == 0 && A_3 == 0)
			{
				throw new ArgumentOutOfRangeException("No elements defined in event.");
			}
			this._buffer = A_1;
			this.UjIOuTeUKtWudmKoZMkuxfSZQATS = A_2;
			this.gyVDTZtBJysjUmYbiTiQVbWNYoeV = A_3;
			this.KGKYdeyegIBFBcQfhIrNddFkLBxXb = 12;
			this.AvleGarplmwJyTBtjvwYtwVTfqMn = this.KGKYdeyegIBFBcQfhIrNddFkLBxXb + ((A_2 > 0) ? (((A_2 - 1) / 32 + 1) * 4) : 0);
			this.tEEAstHDirqHBnBeEnnbFFPglFVfb = this.AvleGarplmwJyTBtjvwYtwVTfqMn + A_3 * 4;
			this.CTquLmXmmKjanZdqcQxQEVdXRYLP = LowLevelInputEvent.GetReportSize(A_2, A_3, A_4);
		}

		// Token: 0x0600027B RID: 635 RVA: 0x0000417E File Offset: 0x0000237E
		public void SetButtonsBitMask(int bitMask, int startButtonIndex)
		{
			if (this.CTquLmXmmKjanZdqcQxQEVdXRYLP <= 0)
			{
				return;
			}
			if (startButtonIndex % 32 != 0)
			{
				throw new Exception("startIndex must be divisible by 32.");
			}
			Marshal.WriteInt32(this._buffer, this.KGKYdeyegIBFBcQfhIrNddFkLBxXb + startButtonIndex / 4, bitMask);
		}

		// Token: 0x0600027C RID: 636 RVA: 0x000041B1 File Offset: 0x000023B1
		public void SetAxisValue(int index, float value)
		{
			if (this.CTquLmXmmKjanZdqcQxQEVdXRYLP <= 0)
			{
				return;
			}
			Marshal.WriteInt32(this._buffer, this.AvleGarplmwJyTBtjvwYtwVTfqMn + index * 4, new cBnrCZPjrfcGOwVKjgzRdKUFjlmb(value).DtrheSheBzorShiEebSNdIJKUXCKA);
		}

		// Token: 0x0600027D RID: 637 RVA: 0x000041DD File Offset: 0x000023DD
		public void SetId(uint id)
		{
			if (this.CTquLmXmmKjanZdqcQxQEVdXRYLP <= 0)
			{
				return;
			}
			Marshal.WriteInt32(this._buffer, 0, (int)id);
		}

		// Token: 0x0600027E RID: 638 RVA: 0x000041F6 File Offset: 0x000023F6
		public void SetTimestamp(double value)
		{
			if (this.CTquLmXmmKjanZdqcQxQEVdXRYLP <= 0)
			{
				return;
			}
			Marshal.WriteInt64(this._buffer, 4, new lxvmMviVZarnaVRghbodFCHtJiYZA(value).NxhhjggYkKIxGarfbRPEJXrULDus);
		}

		// Token: 0x0600027F RID: 639 RVA: 0x0002ED94 File Offset: 0x0002CF94
		public bool GetButtonValue(int index)
		{
			if (this.CTquLmXmmKjanZdqcQxQEVdXRYLP <= 0)
			{
				return false;
			}
			if (this.buttonCount == 0)
			{
				return false;
			}
			int num = index / 32;
			int num2 = (index - num * 32) / 8;
			int num3 = index % 8;
			return ((int)Marshal.ReadByte(this._buffer, this.KGKYdeyegIBFBcQfhIrNddFkLBxXb + num * 4 + num2) & 1 << num3) != 0;
		}

		// Token: 0x06000280 RID: 640 RVA: 0x00004219 File Offset: 0x00002419
		public int GetButtonsBitMask(int startButtonIndex)
		{
			if (this.CTquLmXmmKjanZdqcQxQEVdXRYLP <= 0)
			{
				return 0;
			}
			if (startButtonIndex % 32 != 0)
			{
				throw new Exception("startIndex must be divisible by 32.");
			}
			return Marshal.ReadInt32(this._buffer, this.KGKYdeyegIBFBcQfhIrNddFkLBxXb + startButtonIndex / 4);
		}

		// Token: 0x06000281 RID: 641 RVA: 0x0000424C File Offset: 0x0000244C
		public float GetAxisValue(int index)
		{
			if (this.CTquLmXmmKjanZdqcQxQEVdXRYLP <= 0)
			{
				return 0f;
			}
			return new cBnrCZPjrfcGOwVKjgzRdKUFjlmb(Marshal.ReadInt32(this._buffer, this.AvleGarplmwJyTBtjvwYtwVTfqMn + index * 4)).vOriVOiVMJMZPqMMgnyprpRZvQZL;
		}

		// Token: 0x06000282 RID: 642 RVA: 0x0000427C File Offset: 0x0000247C
		public uint GetId()
		{
			if (this.CTquLmXmmKjanZdqcQxQEVdXRYLP <= 0)
			{
				return 0U;
			}
			return (uint)Marshal.ReadInt32(this._buffer, 0);
		}

		// Token: 0x06000283 RID: 643 RVA: 0x00004295 File Offset: 0x00002495
		public double GetTimestamp()
		{
			if (this.CTquLmXmmKjanZdqcQxQEVdXRYLP <= 0)
			{
				return 0.0;
			}
			return new lxvmMviVZarnaVRghbodFCHtJiYZA(Marshal.ReadInt64(this._buffer, 4)).MUSoEXEPcyNCmnpNOvfxKpNfrcfI;
		}

		// Token: 0x06000284 RID: 644 RVA: 0x000042C0 File Offset: 0x000024C0
		public static int GetReportSize(int buttonCount, int axisCount, int hatCount)
		{
			return 12 + ((buttonCount > 0) ? (((buttonCount - 1) / 32 + 1) * 4) : 0) + axisCount * 4 + hatCount * 4;
		}

		// Token: 0x04000122 RID: 290
		private const int mBRKQHQgvBOXkQzfNgGpktsOqvDU = 4;

		// Token: 0x04000123 RID: 291
		private const int WyUGDsCvZUizMNeQDkzRoTKSKErab = 8;

		// Token: 0x04000124 RID: 292
		private const int OHpxgeHHlFHuSfhDNotnAuygMuHAB = 12;

		// Token: 0x04000125 RID: 293
		public const int buttonsPerPage = 32;

		// Token: 0x04000126 RID: 294
		public const int bytesPerButtonPage = 4;

		// Token: 0x04000127 RID: 295
		private const int oHFQeOOKMbXzkCnsktTpukVrmXAL = 4;

		// Token: 0x04000128 RID: 296
		private const int wqttFIxBUHGFbZARHTGEBroEmJJm = 4;

		// Token: 0x04000129 RID: 297
		public const int byteIndex_id = 0;

		// Token: 0x0400012A RID: 298
		public const int byteIndex_timestamp = 4;

		// Token: 0x0400012B RID: 299
		public const int byteIndex_elementsStart = 12;

		// Token: 0x0400012C RID: 300
		public IntPtr _buffer;

		// Token: 0x0400012D RID: 301
		private int CTquLmXmmKjanZdqcQxQEVdXRYLP;

		// Token: 0x0400012E RID: 302
		private int UjIOuTeUKtWudmKoZMkuxfSZQATS;

		// Token: 0x0400012F RID: 303
		private int gyVDTZtBJysjUmYbiTiQVbWNYoeV;

		// Token: 0x04000130 RID: 304
		private int AvleGarplmwJyTBtjvwYtwVTfqMn;

		// Token: 0x04000131 RID: 305
		private int KGKYdeyegIBFBcQfhIrNddFkLBxXb;

		// Token: 0x04000132 RID: 306
		private int tEEAstHDirqHBnBeEnnbFFPglFVfb;
	}
}
