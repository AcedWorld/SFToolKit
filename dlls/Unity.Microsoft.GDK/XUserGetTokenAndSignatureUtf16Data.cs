using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime
{
	// Token: 0x020001AD RID: 429
	[MovedFrom("Unity.GameCore")]
	public class XUserGetTokenAndSignatureUtf16Data
	{
		// Token: 0x06000A10 RID: 2576 RVA: 0x0000F46F File Offset: 0x0000D66F
		internal XUserGetTokenAndSignatureUtf16Data(XUserGetTokenAndSignatureUtf16Data interop)
		{
			this.interop = interop;
		}

		// Token: 0x06000A11 RID: 2577 RVA: 0x0000F47E File Offset: 0x0000D67E
		public XUserGetTokenAndSignatureUtf16Data()
		{
			this.interop = default(XUserGetTokenAndSignatureUtf16Data);
		}

		// Token: 0x170002F3 RID: 755
		// (get) Token: 0x06000A12 RID: 2578 RVA: 0x0000F492 File Offset: 0x0000D692
		// (set) Token: 0x06000A13 RID: 2579 RVA: 0x0000F49F File Offset: 0x0000D69F
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

		// Token: 0x170002F4 RID: 756
		// (get) Token: 0x06000A14 RID: 2580 RVA: 0x0000F4AD File Offset: 0x0000D6AD
		// (set) Token: 0x06000A15 RID: 2581 RVA: 0x0000F4BA File Offset: 0x0000D6BA
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

		// Token: 0x170002F5 RID: 757
		// (get) Token: 0x06000A16 RID: 2582 RVA: 0x0000F4C8 File Offset: 0x0000D6C8
		// (set) Token: 0x06000A17 RID: 2583 RVA: 0x0000F4D5 File Offset: 0x0000D6D5
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

		// Token: 0x170002F6 RID: 758
		// (get) Token: 0x06000A18 RID: 2584 RVA: 0x0000F4E3 File Offset: 0x0000D6E3
		// (set) Token: 0x06000A19 RID: 2585 RVA: 0x0000F4F0 File Offset: 0x0000D6F0
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

		// Token: 0x040005CF RID: 1487
		internal XUserGetTokenAndSignatureUtf16Data interop;
	}
}
