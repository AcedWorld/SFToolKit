using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime
{
	// Token: 0x020001AB RID: 427
	public class XUserGetTokenAndSignatureData
	{
		// Token: 0x06000A00 RID: 2560 RVA: 0x0000F387 File Offset: 0x0000D587
		internal XUserGetTokenAndSignatureData(XUserGetTokenAndSignatureData interop)
		{
			this.interop = interop;
		}

		// Token: 0x06000A01 RID: 2561 RVA: 0x0000F396 File Offset: 0x0000D596
		public XUserGetTokenAndSignatureData()
		{
			this.interop = default(XUserGetTokenAndSignatureData);
		}

		// Token: 0x170002ED RID: 749
		// (get) Token: 0x06000A02 RID: 2562 RVA: 0x0000F3AA File Offset: 0x0000D5AA
		// (set) Token: 0x06000A03 RID: 2563 RVA: 0x0000F3B7 File Offset: 0x0000D5B7
		public ulong TokenSize
		{
			get
			{
				return this.interop.tokenSize;
			}
			set
			{
				this.interop.tokenSize = value;
			}
		}

		// Token: 0x170002EE RID: 750
		// (get) Token: 0x06000A04 RID: 2564 RVA: 0x0000F3C5 File Offset: 0x0000D5C5
		// (set) Token: 0x06000A05 RID: 2565 RVA: 0x0000F3D2 File Offset: 0x0000D5D2
		public ulong SignatureSize
		{
			get
			{
				return this.interop.signatureSize;
			}
			set
			{
				this.interop.signatureSize = value;
			}
		}

		// Token: 0x170002EF RID: 751
		// (get) Token: 0x06000A06 RID: 2566 RVA: 0x0000F3E0 File Offset: 0x0000D5E0
		// (set) Token: 0x06000A07 RID: 2567 RVA: 0x0000F3ED File Offset: 0x0000D5ED
		public string Token
		{
			get
			{
				return this.interop.token;
			}
			set
			{
				this.interop.token = value;
			}
		}

		// Token: 0x170002F0 RID: 752
		// (get) Token: 0x06000A08 RID: 2568 RVA: 0x0000F3FB File Offset: 0x0000D5FB
		// (set) Token: 0x06000A09 RID: 2569 RVA: 0x0000F408 File Offset: 0x0000D608
		public string Signature
		{
			get
			{
				return this.interop.signature;
			}
			set
			{
				this.interop.signature = value;
			}
		}

		// Token: 0x040005CD RID: 1485
		internal XUserGetTokenAndSignatureData interop;
	}
}
