using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x02000216 RID: 534
	internal struct XblMultiplayerSessionReference
	{
		// Token: 0x06000DC9 RID: 3529 RVA: 0x00010F88 File Offset: 0x0000F188
		internal unsafe string GetScid()
		{
			fixed (byte* ptr = &this.Scid.FixedElementField)
			{
				return Converters.BytePointerToString(ptr, 40);
			}
		}

		// Token: 0x06000DCA RID: 3530 RVA: 0x00010FAC File Offset: 0x0000F1AC
		internal unsafe string GetSessionTemplateName()
		{
			fixed (byte* ptr = &this.SessionTemplateName.FixedElementField)
			{
				return Converters.BytePointerToString(ptr, 100);
			}
		}

		// Token: 0x06000DCB RID: 3531 RVA: 0x00010FD0 File Offset: 0x0000F1D0
		internal unsafe string GetSessionName()
		{
			fixed (byte* ptr = &this.SessionName.FixedElementField)
			{
				return Converters.BytePointerToString(ptr, 100);
			}
		}

		// Token: 0x06000DCC RID: 3532 RVA: 0x00010FF4 File Offset: 0x0000F1F4
		internal unsafe XblMultiplayerSessionReference(XblMultiplayerSessionReference publicObject)
		{
			fixed (byte* ptr = &this.Scid.FixedElementField)
			{
				byte* bytePointer = ptr;
				Converters.StringToNullTerminatedUTF8FixedPointer(publicObject.Scid, bytePointer, 40);
			}
			fixed (byte* ptr = &this.SessionTemplateName.FixedElementField)
			{
				byte* bytePointer2 = ptr;
				Converters.StringToNullTerminatedUTF8FixedPointer(publicObject.SessionTemplateName, bytePointer2, 100);
			}
			fixed (byte* ptr = &this.SessionName.FixedElementField)
			{
				byte* bytePointer3 = ptr;
				Converters.StringToNullTerminatedUTF8FixedPointer(publicObject.SessionName, bytePointer3, 100);
			}
		}

		// Token: 0x0400076C RID: 1900
		[FixedBuffer(typeof(byte), 40)]
		private XblMultiplayerSessionReference.<Scid>e__FixedBuffer Scid;

		// Token: 0x0400076D RID: 1901
		[FixedBuffer(typeof(byte), 100)]
		private XblMultiplayerSessionReference.<SessionTemplateName>e__FixedBuffer SessionTemplateName;

		// Token: 0x0400076E RID: 1902
		[FixedBuffer(typeof(byte), 100)]
		private XblMultiplayerSessionReference.<SessionName>e__FixedBuffer SessionName;

		// Token: 0x0200033F RID: 831
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 40)]
		public struct <Scid>e__FixedBuffer
		{
			// Token: 0x040009BD RID: 2493
			public byte FixedElementField;
		}

		// Token: 0x02000340 RID: 832
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 100)]
		public struct <SessionName>e__FixedBuffer
		{
			// Token: 0x040009BE RID: 2494
			public byte FixedElementField;
		}

		// Token: 0x02000341 RID: 833
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 100)]
		public struct <SessionTemplateName>e__FixedBuffer
		{
			// Token: 0x040009BF RID: 2495
			public byte FixedElementField;
		}
	}
}
