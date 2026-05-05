using System;
using System.Runtime.InteropServices;

namespace Unity.Netcode
{
	// Token: 0x0200010E RID: 270
	[StructLayout(LayoutKind.Explicit)]
	internal struct ByteBool
	{
		// Token: 0x06000882 RID: 2178 RVA: 0x0001FE14 File Offset: 0x0001E014
		public byte Collapse()
		{
			return this.ByteValue = (byte)((this.ByteValue >> 7 | this.ByteValue >> 6 | this.ByteValue >> 5 | this.ByteValue >> 4 | this.ByteValue >> 3 | this.ByteValue >> 2 | this.ByteValue >> 1 | (int)this.ByteValue) & 1);
		}

		// Token: 0x06000883 RID: 2179 RVA: 0x0001FE72 File Offset: 0x0001E072
		public byte Collapse(bool b)
		{
			this.BoolValue = b;
			return this.Collapse();
		}

		// Token: 0x04000328 RID: 808
		[FieldOffset(0)]
		public bool BoolValue;

		// Token: 0x04000329 RID: 809
		[FieldOffset(0)]
		public byte ByteValue;
	}
}
