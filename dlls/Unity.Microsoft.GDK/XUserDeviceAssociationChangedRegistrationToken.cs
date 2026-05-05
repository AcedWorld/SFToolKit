using System;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime
{
	// Token: 0x020001B4 RID: 436
	public class XUserDeviceAssociationChangedRegistrationToken
	{
		// Token: 0x06000A38 RID: 2616 RVA: 0x0000F607 File Offset: 0x0000D807
		internal XUserDeviceAssociationChangedRegistrationToken(XUserDeviceAssociationChangedCallback callback, IntPtr context)
		{
			this.interop = new XUserDeviceAssociationChangedRegistrationToken(callback, context);
		}

		// Token: 0x170002FD RID: 765
		// (get) Token: 0x06000A39 RID: 2617 RVA: 0x0000F61C File Offset: 0x0000D81C
		public bool IsValid
		{
			get
			{
				return this.interop.IsValid;
			}
		}

		// Token: 0x170002FE RID: 766
		// (get) Token: 0x06000A3A RID: 2618 RVA: 0x0000F629 File Offset: 0x0000D829
		// (set) Token: 0x06000A3B RID: 2619 RVA: 0x0000F636 File Offset: 0x0000D836
		public ulong Token
		{
			get
			{
				return this.interop.Token;
			}
			set
			{
				this.interop.Token = value;
			}
		}

		// Token: 0x06000A3C RID: 2620 RVA: 0x0000F644 File Offset: 0x0000D844
		public bool Unregister(bool wait)
		{
			return this.interop.Unregister(wait);
		}

		// Token: 0x06000A3D RID: 2621 RVA: 0x0000F652 File Offset: 0x0000D852
		public void Dispose()
		{
			this.interop.Dispose();
		}

		// Token: 0x040005D3 RID: 1491
		internal XUserDeviceAssociationChangedRegistrationToken interop;
	}
}
