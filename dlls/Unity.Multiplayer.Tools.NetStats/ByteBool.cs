using System;
using System.Runtime.InteropServices;

namespace Unity.Multiplayer.Tools.NetStats
{
	// Token: 0x0200002D RID: 45
	[StructLayout(LayoutKind.Explicit)]
	internal struct ByteBool
	{
		// Token: 0x060000E7 RID: 231 RVA: 0x00003BB0 File Offset: 0x00001DB0
		public byte Collapse()
		{
			return this.ByteValue = (byte)((this.ByteValue >> 7 | this.ByteValue >> 6 | this.ByteValue >> 5 | this.ByteValue >> 4 | this.ByteValue >> 3 | this.ByteValue >> 2 | this.ByteValue >> 1 | (int)this.ByteValue) & 1);
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x00003C0E File Offset: 0x00001E0E
		public byte Collapse(bool b)
		{
			this.BoolValue = b;
			return this.Collapse();
		}

		// Token: 0x04000052 RID: 82
		[FieldOffset(0)]
		public bool BoolValue;

		// Token: 0x04000053 RID: 83
		[FieldOffset(0)]
		public byte ByteValue;
	}
}
