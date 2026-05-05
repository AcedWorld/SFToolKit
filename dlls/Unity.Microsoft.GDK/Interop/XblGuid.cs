using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x0200020B RID: 523
	internal struct XblGuid
	{
		// Token: 0x06000DBD RID: 3517 RVA: 0x00010C58 File Offset: 0x0000EE58
		internal unsafe string GetValue()
		{
			fixed (byte* ptr = &this.value.FixedElementField)
			{
				return Converters.BytePointerToString(ptr, 40);
			}
		}

		// Token: 0x06000DBE RID: 3518 RVA: 0x00010C7C File Offset: 0x0000EE7C
		internal unsafe XblGuid(XblGuid publicObject)
		{
			fixed (byte* ptr = &this.value.FixedElementField)
			{
				byte* bytePointer = ptr;
				Converters.StringToNullTerminatedUTF8FixedPointer(publicObject.Value, bytePointer, 40);
			}
		}

		// Token: 0x04000728 RID: 1832
		[FixedBuffer(typeof(byte), 40)]
		private XblGuid.<value>e__FixedBuffer value;

		// Token: 0x0200033D RID: 829
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 40)]
		public struct <value>e__FixedBuffer
		{
			// Token: 0x040009BA RID: 2490
			public byte FixedElementField;
		}
	}
}
