using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x0200020A RID: 522
	internal struct XblDeviceToken
	{
		// Token: 0x06000DBB RID: 3515 RVA: 0x00010C04 File Offset: 0x0000EE04
		internal unsafe string GetValue()
		{
			fixed (byte* ptr = &this.Value.FixedElementField)
			{
				return Converters.BytePointerToString(ptr, 40);
			}
		}

		// Token: 0x06000DBC RID: 3516 RVA: 0x00010C28 File Offset: 0x0000EE28
		internal unsafe XblDeviceToken(XblDeviceToken publicObject)
		{
			fixed (byte* ptr = &this.Value.FixedElementField)
			{
				byte* bytePointer = ptr;
				Converters.StringToNullTerminatedUTF8FixedPointer(publicObject.Value, bytePointer, 40);
			}
		}

		// Token: 0x04000727 RID: 1831
		[FixedBuffer(typeof(byte), 40)]
		private XblDeviceToken.<Value>e__FixedBuffer Value;

		// Token: 0x0200033C RID: 828
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 40)]
		public struct <Value>e__FixedBuffer
		{
			// Token: 0x040009B9 RID: 2489
			public byte FixedElementField;
		}
	}
}
