using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000206 RID: 518
	internal struct XblMultiplayerSessionStringAttribute
	{
		// Token: 0x06000DB4 RID: 3508 RVA: 0x00010A84 File Offset: 0x0000EC84
		internal unsafe string GetName()
		{
			fixed (byte* ptr = &this.name.FixedElementField)
			{
				return Converters.BytePointerToString(ptr, 100);
			}
		}

		// Token: 0x06000DB5 RID: 3509 RVA: 0x00010AA8 File Offset: 0x0000ECA8
		internal unsafe string GetValue()
		{
			fixed (byte* ptr = &this.value.FixedElementField)
			{
				return Converters.BytePointerToString(ptr, 100);
			}
		}

		// Token: 0x06000DB6 RID: 3510 RVA: 0x00010ACC File Offset: 0x0000ECCC
		internal unsafe XblMultiplayerSessionStringAttribute(XblMultiplayerSessionStringAttribute publicObject)
		{
			fixed (byte* ptr = &this.name.FixedElementField)
			{
				byte* bytePointer = ptr;
				Converters.StringToNullTerminatedUTF8FixedPointer(publicObject.Name, bytePointer, 100);
			}
			fixed (byte* ptr = &this.value.FixedElementField)
			{
				byte* bytePointer2 = ptr;
				Converters.StringToNullTerminatedUTF8FixedPointer(publicObject.Value, bytePointer2, 100);
			}
		}

		// Token: 0x0400071B RID: 1819
		[FixedBuffer(typeof(byte), 100)]
		private XblMultiplayerSessionStringAttribute.<name>e__FixedBuffer name;

		// Token: 0x0400071C RID: 1820
		[FixedBuffer(typeof(byte), 100)]
		private XblMultiplayerSessionStringAttribute.<value>e__FixedBuffer value;

		// Token: 0x02000339 RID: 825
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 100)]
		public struct <name>e__FixedBuffer
		{
			// Token: 0x040009B6 RID: 2486
			public byte FixedElementField;
		}

		// Token: 0x0200033A RID: 826
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 100)]
		public struct <value>e__FixedBuffer
		{
			// Token: 0x040009B7 RID: 2487
			public byte FixedElementField;
		}
	}
}
