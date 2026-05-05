using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000207 RID: 519
	internal struct XblMultiplayerSessionTag
	{
		// Token: 0x06000DB7 RID: 3511 RVA: 0x00010B1C File Offset: 0x0000ED1C
		internal unsafe string GetValue()
		{
			fixed (byte* ptr = &this.value.FixedElementField)
			{
				return Converters.BytePointerToString(ptr, 100);
			}
		}

		// Token: 0x06000DB8 RID: 3512 RVA: 0x00010B40 File Offset: 0x0000ED40
		internal unsafe XblMultiplayerSessionTag(XblMultiplayerSessionTag publicObject)
		{
			fixed (byte* ptr = &this.value.FixedElementField)
			{
				byte* bytePointer = ptr;
				Converters.StringToNullTerminatedUTF8FixedPointer(publicObject.Value, bytePointer, 100);
			}
		}

		// Token: 0x0400071D RID: 1821
		[FixedBuffer(typeof(byte), 100)]
		private XblMultiplayerSessionTag.<value>e__FixedBuffer value;

		// Token: 0x0200033B RID: 827
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 100)]
		public struct <value>e__FixedBuffer
		{
			// Token: 0x040009B8 RID: 2488
			public byte FixedElementField;
		}
	}
}
