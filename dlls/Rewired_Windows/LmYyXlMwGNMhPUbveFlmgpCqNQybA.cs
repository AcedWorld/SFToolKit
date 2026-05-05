using System;
using System.Runtime.InteropServices;

// Token: 0x0200004B RID: 75
internal class LmYyXlMwGNMhPUbveFlmgpCqNQybA : IDisposable
{
	// Token: 0x1700005A RID: 90
	// (get) Token: 0x060002C5 RID: 709 RVA: 0x000129CB File Offset: 0x00010BCB
	public int ygbiWvOfUeCdiDjpgzEOfAotfBQI
	{
		get
		{
			return this.UCUviiQeiJamhESamGPVLiaefvIf;
		}
	}

	// Token: 0x060002C6 RID: 710 RVA: 0x000129D3 File Offset: 0x00010BD3
	public unsafe LmYyXlMwGNMhPUbveFlmgpCqNQybA(int A_1)
	{
		if (A_1 <= 0)
		{
			throw new Exception("size must be > 0!");
		}
		this.UCUviiQeiJamhESamGPVLiaefvIf = A_1;
		this.ljYfpHKzJJCBwFcjloimuRfhvcXbA = 0U;
		this.IFTGOdNjVwPNFJKCmPxceZVjnHBY = (byte*)((void*)Marshal.AllocHGlobal(A_1));
	}

	// Token: 0x060002C7 RID: 711 RVA: 0x000299D0 File Offset: 0x00027BD0
	public unsafe bool lOpyFjdrsfQbnGFkaLjAQBAdRiGr(IntPtr A_1, int A_2, out LmYyXlMwGNMhPUbveFlmgpCqNQybA.GbeOncEdaoRujuDlvgdBCBuZbxpEA A_3)
	{
		if (this.IFTGOdNjVwPNFJKCmPxceZVjnHBY == null || A_2 <= 0)
		{
			A_3 = default(LmYyXlMwGNMhPUbveFlmgpCqNQybA.GbeOncEdaoRujuDlvgdBCBuZbxpEA);
			return false;
		}
		if (A_2 > this.UCUviiQeiJamhESamGPVLiaefvIf)
		{
			throw new Exception("Length is larger than the buffer.");
		}
		if ((ulong)(this.ljYfpHKzJJCBwFcjloimuRfhvcXbA + (uint)A_2) > (ulong)((long)this.UCUviiQeiJamhESamGPVLiaefvIf))
		{
			this.ljYfpHKzJJCBwFcjloimuRfhvcXbA = 0U;
			if (this.ILcgPlhMlShlNxKfOtYYRKBesnIzA == 254)
			{
				this.ILcgPlhMlShlNxKfOtYYRKBesnIzA = 0;
				this.gzWdwpahUzOPgYiIsWejFhnUZWYi = true;
			}
			else
			{
				this.ILcgPlhMlShlNxKfOtYYRKBesnIzA += 1;
			}
		}
		wLURyKQfpGlmweDJGGSrwwzrDUJFA.nluLBssElCaaWhCLckgKfjcLBHNQ((void*)(this.IFTGOdNjVwPNFJKCmPxceZVjnHBY + this.ljYfpHKzJJCBwFcjloimuRfhvcXbA), (void*)A_1, new UIntPtr((uint)A_2));
		A_3 = new LmYyXlMwGNMhPUbveFlmgpCqNQybA.GbeOncEdaoRujuDlvgdBCBuZbxpEA(this.ILcgPlhMlShlNxKfOtYYRKBesnIzA, this.ljYfpHKzJJCBwFcjloimuRfhvcXbA, A_2);
		this.ljYfpHKzJJCBwFcjloimuRfhvcXbA += (uint)A_2;
		return true;
	}

	// Token: 0x060002C8 RID: 712 RVA: 0x00029A94 File Offset: 0x00027C94
	public int JEuIHiBbWJiVUBDyDLrMcwojoFuyb(LmYyXlMwGNMhPUbveFlmgpCqNQybA.GbeOncEdaoRujuDlvgdBCBuZbxpEA A_1, byte[] A_2)
	{
		if (A_2 == null)
		{
			throw new ArgumentNullException("buffer");
		}
		if (A_2.Length < A_1.YRlLLstrQNjAOIpCAgVExoAxjFHFA)
		{
			throw new Exception("Buffer is not large enough to hold the data.");
		}
		if (!this.cqfnpxCTQDJbEuNJPxSKMgiDiDJX(ref A_1))
		{
			return -1;
		}
		Marshal.Copy(this.XOfXzBVBEMDWYpiMdqHEZaSNvEKR(A_1), A_2, 0, A_1.YRlLLstrQNjAOIpCAgVExoAxjFHFA);
		return A_1.YRlLLstrQNjAOIpCAgVExoAxjFHFA;
	}

	// Token: 0x060002C9 RID: 713 RVA: 0x00029AF0 File Offset: 0x00027CF0
	public unsafe int bcTwpCqrzekyjZWpnWNomnCyCwGR(LmYyXlMwGNMhPUbveFlmgpCqNQybA.GbeOncEdaoRujuDlvgdBCBuZbxpEA A_1, IntPtr A_2, int A_3)
	{
		if (A_2 == IntPtr.Zero)
		{
			throw new Exception("Buffer pointer is invalid.");
		}
		if (A_3 <= 0)
		{
			return -1;
		}
		if (A_3 < A_1.YRlLLstrQNjAOIpCAgVExoAxjFHFA)
		{
			throw new Exception("Buffer is not large enough to hold the data.");
		}
		if (!this.cqfnpxCTQDJbEuNJPxSKMgiDiDJX(ref A_1))
		{
			return -1;
		}
		wLURyKQfpGlmweDJGGSrwwzrDUJFA.nluLBssElCaaWhCLckgKfjcLBHNQ((void*)A_2, (void*)this.XOfXzBVBEMDWYpiMdqHEZaSNvEKR(A_1), new UIntPtr((uint)A_1.YRlLLstrQNjAOIpCAgVExoAxjFHFA));
		return A_1.YRlLLstrQNjAOIpCAgVExoAxjFHFA;
	}

	// Token: 0x060002CA RID: 714 RVA: 0x00012A09 File Offset: 0x00010C09
	public unsafe IntPtr XOfXzBVBEMDWYpiMdqHEZaSNvEKR(LmYyXlMwGNMhPUbveFlmgpCqNQybA.GbeOncEdaoRujuDlvgdBCBuZbxpEA A_1)
	{
		if (this.IFTGOdNjVwPNFJKCmPxceZVjnHBY == null || !this.cqfnpxCTQDJbEuNJPxSKMgiDiDJX(ref A_1))
		{
			return IntPtr.Zero;
		}
		return (IntPtr)((void*)(this.IFTGOdNjVwPNFJKCmPxceZVjnHBY + A_1.DwqhhJYUWvBWqXMtocwceXMNScWS));
	}

	// Token: 0x060002CB RID: 715 RVA: 0x00012A39 File Offset: 0x00010C39
	public unsafe bool KmbHkPkfQPEKSHwCcbNmHqfdHbCpB(LmYyXlMwGNMhPUbveFlmgpCqNQybA.GbeOncEdaoRujuDlvgdBCBuZbxpEA A_1, out IntPtr A_2)
	{
		if (this.IFTGOdNjVwPNFJKCmPxceZVjnHBY == null || !this.cqfnpxCTQDJbEuNJPxSKMgiDiDJX(ref A_1))
		{
			A_2 = IntPtr.Zero;
			return false;
		}
		A_2 = (IntPtr)((void*)(this.IFTGOdNjVwPNFJKCmPxceZVjnHBY + A_1.DwqhhJYUWvBWqXMtocwceXMNScWS));
		return true;
	}

	// Token: 0x060002CC RID: 716 RVA: 0x00029B68 File Offset: 0x00027D68
	private bool cqfnpxCTQDJbEuNJPxSKMgiDiDJX(ref LmYyXlMwGNMhPUbveFlmgpCqNQybA.GbeOncEdaoRujuDlvgdBCBuZbxpEA A_1)
	{
		int num = A_1.YRlLLstrQNjAOIpCAgVExoAxjFHFA;
		if (num <= 0)
		{
			return false;
		}
		uint num2 = (uint)A_1.xxbdZiELOXoKpxOcmstXdkliRfhwB;
		if (num2 > 254U)
		{
			return false;
		}
		if (num2 != (uint)this.ILcgPlhMlShlNxKfOtYYRKBesnIzA)
		{
			if (!this.gzWdwpahUzOPgYiIsWejFhnUZWYi)
			{
				if (num2 + 1U != (uint)this.ILcgPlhMlShlNxKfOtYYRKBesnIzA)
				{
					return false;
				}
			}
			else if (num2 > (uint)this.ILcgPlhMlShlNxKfOtYYRKBesnIzA)
			{
				if (this.ILcgPlhMlShlNxKfOtYYRKBesnIzA != 0 || num2 != 254U)
				{
					return false;
				}
			}
			else if (num2 + 1U != (uint)this.ILcgPlhMlShlNxKfOtYYRKBesnIzA)
			{
				return false;
			}
			if (A_1.DwqhhJYUWvBWqXMtocwceXMNScWS < this.ljYfpHKzJJCBwFcjloimuRfhvcXbA)
			{
				return false;
			}
		}
		else if ((ulong)A_1.DwqhhJYUWvBWqXMtocwceXMNScWS + (ulong)((long)num) > (ulong)this.ljYfpHKzJJCBwFcjloimuRfhvcXbA)
		{
			return false;
		}
		return (ulong)A_1.DwqhhJYUWvBWqXMtocwceXMNScWS + (ulong)((long)num) <= (ulong)((long)this.UCUviiQeiJamhESamGPVLiaefvIf);
	}

	// Token: 0x060002CD RID: 717 RVA: 0x00012A6F File Offset: 0x00010C6F
	public void Dispose()
	{
		this.fnKyvZsCexfiuBeQLKZtItwWwYuCA(true);
		GC.SuppressFinalize(this);
	}

	// Token: 0x060002CE RID: 718 RVA: 0x00029C14 File Offset: 0x00027E14
	protected virtual void NtjFPOITyhluQOLZrNWPtmytuatoA()
	{
		try
		{
			this.fnKyvZsCexfiuBeQLKZtItwWwYuCA(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	// Token: 0x060002CF RID: 719 RVA: 0x00012A7E File Offset: 0x00010C7E
	protected unsafe virtual void fnKyvZsCexfiuBeQLKZtItwWwYuCA(bool A_1)
	{
		if (this.qfTEPCuJMzSGpaTTgtaqYCRKlyOT)
		{
			return;
		}
		if (this.IFTGOdNjVwPNFJKCmPxceZVjnHBY != null)
		{
			Marshal.FreeHGlobal((IntPtr)((void*)this.IFTGOdNjVwPNFJKCmPxceZVjnHBY));
		}
		this.qfTEPCuJMzSGpaTTgtaqYCRKlyOT = true;
	}

	// Token: 0x04000488 RID: 1160
	private const byte VzsNNRxSoZxHUVuuVretlHacEztC = 254;

	// Token: 0x04000489 RID: 1161
	private uint ljYfpHKzJJCBwFcjloimuRfhvcXbA;

	// Token: 0x0400048A RID: 1162
	private int UCUviiQeiJamhESamGPVLiaefvIf;

	// Token: 0x0400048B RID: 1163
	private unsafe byte* IFTGOdNjVwPNFJKCmPxceZVjnHBY;

	// Token: 0x0400048C RID: 1164
	private byte ILcgPlhMlShlNxKfOtYYRKBesnIzA;

	// Token: 0x0400048D RID: 1165
	private bool gzWdwpahUzOPgYiIsWejFhnUZWYi;

	// Token: 0x0400048E RID: 1166
	private bool qfTEPCuJMzSGpaTTgtaqYCRKlyOT;

	// Token: 0x0200004C RID: 76
	public struct GbeOncEdaoRujuDlvgdBCBuZbxpEA
	{
		// Token: 0x1700005B RID: 91
		// (get) Token: 0x060002D0 RID: 720 RVA: 0x00012AAC File Offset: 0x00010CAC
		public byte xxbdZiELOXoKpxOcmstXdkliRfhwB
		{
			get
			{
				return this.bbXQhHjGUCYizJzpbEYmyryWiDdr;
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x060002D1 RID: 721 RVA: 0x00012AB4 File Offset: 0x00010CB4
		public uint DwqhhJYUWvBWqXMtocwceXMNScWS
		{
			get
			{
				return this.ROSmqlhncjGtDfcIEnWUFZUKeGleA;
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x060002D2 RID: 722 RVA: 0x00012ABC File Offset: 0x00010CBC
		public int YRlLLstrQNjAOIpCAgVExoAxjFHFA
		{
			get
			{
				return this.mONaprHxIIRsGFaeUdyRXYBlOrHA;
			}
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x00012AC4 File Offset: 0x00010CC4
		public GbeOncEdaoRujuDlvgdBCBuZbxpEA(byte A_1, uint A_2, int A_3)
		{
			this.bbXQhHjGUCYizJzpbEYmyryWiDdr = A_1;
			this.ROSmqlhncjGtDfcIEnWUFZUKeGleA = A_2;
			this.mONaprHxIIRsGFaeUdyRXYBlOrHA = A_3;
			if (this.mONaprHxIIRsGFaeUdyRXYBlOrHA < 0)
			{
				this.mONaprHxIIRsGFaeUdyRXYBlOrHA = 0;
			}
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x060002D4 RID: 724 RVA: 0x00012AEB File Offset: 0x00010CEB
		public static LmYyXlMwGNMhPUbveFlmgpCqNQybA.GbeOncEdaoRujuDlvgdBCBuZbxpEA kQhDBDdqBSDFHtoyBOWSKaSisYlhA
		{
			get
			{
				return LmYyXlMwGNMhPUbveFlmgpCqNQybA.GbeOncEdaoRujuDlvgdBCBuZbxpEA.xvECddyiWihxzQUWUmCydwRlVBJc;
			}
		}

		// Token: 0x0400048F RID: 1167
		private byte bbXQhHjGUCYizJzpbEYmyryWiDdr;

		// Token: 0x04000490 RID: 1168
		private uint ROSmqlhncjGtDfcIEnWUFZUKeGleA;

		// Token: 0x04000491 RID: 1169
		private int mONaprHxIIRsGFaeUdyRXYBlOrHA;

		// Token: 0x04000492 RID: 1170
		private static LmYyXlMwGNMhPUbveFlmgpCqNQybA.GbeOncEdaoRujuDlvgdBCBuZbxpEA xvECddyiWihxzQUWUmCydwRlVBJc;
	}
}
