using System;
using Rewired.Utils;

namespace Rewired
{
	// Token: 0x0200001C RID: 28
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal class UnknownControllerHat
	{
		// Token: 0x06000188 RID: 392 RVA: 0x000036B1 File Offset: 0x000018B1
		public UnknownControllerHat(UnknownControllerHat.HatButtons A_1)
		{
			this.dIcdEWvvQKNcNtcGDFSvOCdFMEqM = A_1;
		}

		// Token: 0x06000189 RID: 393 RVA: 0x0002CB10 File Offset: 0x0002AD10
		public bool ContainsButtonIndex(int index)
		{
			for (int i = 0; i < 8; i++)
			{
				if (this.dIcdEWvvQKNcNtcGDFSvOCdFMEqM.Contains(index))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600018A RID: 394 RVA: 0x0002CB3C File Offset: 0x0002AD3C
		public bool IsButtonIndexCardinal(int index)
		{
			for (int i = 0; i < 8; i++)
			{
				if (this.dIcdEWvvQKNcNtcGDFSvOCdFMEqM.IsCardinal(index))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600018B RID: 395 RVA: 0x000036C0 File Offset: 0x000018C0
		public UnknownControllerHat.HatButtons GetButtons()
		{
			return this.dIcdEWvvQKNcNtcGDFSvOCdFMEqM;
		}

		// Token: 0x04000097 RID: 151
		private UnknownControllerHat.HatButtons dIcdEWvvQKNcNtcGDFSvOCdFMEqM;

		// Token: 0x0200001D RID: 29
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		public class HatButtons
		{
			// Token: 0x17000073 RID: 115
			public int this[int index]
			{
				get
				{
					return this.vmxnKxxZgglvcSRcIFRnlfRqNQtH[index];
				}
			}

			// Token: 0x0600018D RID: 397 RVA: 0x000036D2 File Offset: 0x000018D2
			public HatButtons(int[] A_1)
			{
				this.vmxnKxxZgglvcSRcIFRnlfRqNQtH = A_1;
			}

			// Token: 0x0600018E RID: 398 RVA: 0x0002CB68 File Offset: 0x0002AD68
			public void GetNeighbors(int button, out int neighbor1, out int neighbor2)
			{
				int num = this.IndexOf(button);
				if (num < 0)
				{
					neighbor1 = -1;
					neighbor2 = -1;
					return;
				}
				if (num > 0)
				{
					neighbor1 = this.vmxnKxxZgglvcSRcIFRnlfRqNQtH[num - 1];
				}
				else
				{
					neighbor1 = this.vmxnKxxZgglvcSRcIFRnlfRqNQtH[this.vmxnKxxZgglvcSRcIFRnlfRqNQtH.Length - 1];
				}
				if (num >= this.vmxnKxxZgglvcSRcIFRnlfRqNQtH.Length - 1)
				{
					neighbor2 = this.vmxnKxxZgglvcSRcIFRnlfRqNQtH[0];
					return;
				}
				neighbor2 = this.vmxnKxxZgglvcSRcIFRnlfRqNQtH[num + 1];
			}

			// Token: 0x0600018F RID: 399 RVA: 0x0002CBD4 File Offset: 0x0002ADD4
			public bool IsCardinal(int button)
			{
				int num = this.IndexOf(button);
				return num >= 0 && MathTools.IsEven(num);
			}

			// Token: 0x06000190 RID: 400 RVA: 0x0002CBF8 File Offset: 0x0002ADF8
			public bool IsCorner(int button)
			{
				int num = this.IndexOf(button);
				return num >= 0 && !MathTools.IsEven(num);
			}

			// Token: 0x06000191 RID: 401 RVA: 0x0002CC1C File Offset: 0x0002AE1C
			public int IndexOf(int button)
			{
				for (int i = 0; i < this.vmxnKxxZgglvcSRcIFRnlfRqNQtH.Length; i++)
				{
					if (this.vmxnKxxZgglvcSRcIFRnlfRqNQtH[i] == button)
					{
						return i;
					}
				}
				return -1;
			}

			// Token: 0x06000192 RID: 402 RVA: 0x000036E1 File Offset: 0x000018E1
			public bool Contains(int button)
			{
				return this.IndexOf(button) >= 0;
			}

			// Token: 0x04000098 RID: 152
			private int[] vmxnKxxZgglvcSRcIFRnlfRqNQtH;
		}
	}
}
