using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000202 RID: 514
	internal struct XblMultiplayerSessionNumberAttribute
	{
		// Token: 0x06000DAD RID: 3501 RVA: 0x000108C0 File Offset: 0x0000EAC0
		internal unsafe string GetName()
		{
			fixed (byte* ptr = &this.name.FixedElementField)
			{
				return Converters.BytePointerToString(ptr, 100);
			}
		}

		// Token: 0x06000DAE RID: 3502 RVA: 0x000108E4 File Offset: 0x0000EAE4
		internal unsafe XblMultiplayerSessionNumberAttribute(XblMultiplayerSessionNumberAttribute publicObject)
		{
			fixed (byte* ptr = &this.name.FixedElementField)
			{
				byte* bytePointer = ptr;
				Converters.StringToNullTerminatedUTF8FixedPointer(publicObject.Name, bytePointer, 100);
			}
			this.value = publicObject.Value;
		}

		// Token: 0x040006F4 RID: 1780
		[FixedBuffer(typeof(byte), 100)]
		private XblMultiplayerSessionNumberAttribute.<name>e__FixedBuffer name;

		// Token: 0x040006F5 RID: 1781
		internal readonly double value;

		// Token: 0x02000336 RID: 822
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 100)]
		public struct <name>e__FixedBuffer
		{
			// Token: 0x040009B0 RID: 2480
			public byte FixedElementField;
		}
	}
}
