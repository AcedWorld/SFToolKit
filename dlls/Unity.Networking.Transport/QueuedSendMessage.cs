using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Unity.Networking.Transport
{
	// Token: 0x0200002D RID: 45
	public struct QueuedSendMessage
	{
		// Token: 0x0400007A RID: 122
		[FixedBuffer(typeof(byte), 1472)]
		public QueuedSendMessage.<Data>e__FixedBuffer Data;

		// Token: 0x0400007B RID: 123
		public NetworkInterfaceEndPoint Dest;

		// Token: 0x0400007C RID: 124
		public int DataLength;

		// Token: 0x0200002E RID: 46
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 1472)]
		public struct <Data>e__FixedBuffer
		{
			// Token: 0x0400007D RID: 125
			public byte FixedElementField;
		}
	}
}
