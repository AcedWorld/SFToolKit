using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000217 RID: 535
	internal struct XblMultiplayerSessionReferenceUri
	{
		// Token: 0x06000DCD RID: 3533 RVA: 0x00011064 File Offset: 0x0000F264
		internal unsafe string GetValue()
		{
			fixed (byte* ptr = &this.value.FixedElementField)
			{
				return Converters.BytePointerToString(ptr, 284);
			}
		}

		// Token: 0x06000DCE RID: 3534 RVA: 0x0001108C File Offset: 0x0000F28C
		internal unsafe XblMultiplayerSessionReferenceUri(XblMultiplayerSessionReferenceUri publicObject)
		{
			fixed (byte* ptr = &this.value.FixedElementField)
			{
				byte* bytePointer = ptr;
				Converters.StringToNullTerminatedUTF8FixedPointer(publicObject.Value, bytePointer, 284);
			}
		}

		// Token: 0x0400076F RID: 1903
		[FixedBuffer(typeof(byte), 284)]
		private XblMultiplayerSessionReferenceUri.<value>e__FixedBuffer value;

		// Token: 0x02000342 RID: 834
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 284)]
		public struct <value>e__FixedBuffer
		{
			// Token: 0x040009C0 RID: 2496
			public byte FixedElementField;
		}
	}
}
