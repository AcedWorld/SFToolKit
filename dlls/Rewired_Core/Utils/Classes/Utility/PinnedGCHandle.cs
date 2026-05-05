using System;
using System.Runtime.InteropServices;

namespace Rewired.Utils.Classes.Utility
{
	// Token: 0x020004CA RID: 1226
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal struct PinnedGCHandle : IDisposable
	{
		// Token: 0x06003141 RID: 12609 RVA: 0x00025C7A File Offset: 0x00023E7A
		public PinnedGCHandle(object A_1)
		{
			this.MATVCbYPxFjrqsGDUSMdybAzxSgJ = GCHandle.Alloc(A_1, GCHandleType.Pinned);
		}

		// Token: 0x06003142 RID: 12610 RVA: 0x000AB808 File Offset: 0x000A9A08
		public void Dispose()
		{
			if (this.MATVCbYPxFjrqsGDUSMdybAzxSgJ.IsAllocated)
			{
				this.MATVCbYPxFjrqsGDUSMdybAzxSgJ.Free();
			}
		}

		// Token: 0x17000B2C RID: 2860
		// (get) Token: 0x06003143 RID: 12611 RVA: 0x000AB834 File Offset: 0x000A9A34
		public IntPtr Pointer
		{
			get
			{
				if (!this.MATVCbYPxFjrqsGDUSMdybAzxSgJ.IsAllocated)
				{
					return IntPtr.Zero;
				}
				return this.MATVCbYPxFjrqsGDUSMdybAzxSgJ.AddrOfPinnedObject();
			}
		}

		// Token: 0x06003144 RID: 12612 RVA: 0x00025C89 File Offset: 0x00023E89
		public static implicit operator IntPtr(PinnedGCHandle handle)
		{
			return handle.Pointer;
		}

		// Token: 0x04001AFE RID: 6910
		private readonly GCHandle MATVCbYPxFjrqsGDUSMdybAzxSgJ;
	}
}
