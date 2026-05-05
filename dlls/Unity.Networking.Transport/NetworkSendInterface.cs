using System;
using System.Runtime.InteropServices;
using Unity.Collections.LowLevel.Unsafe;

namespace Unity.Networking.Transport
{
	// Token: 0x0200001B RID: 27
	public struct NetworkSendInterface
	{
		// Token: 0x0400004E RID: 78
		public TransportFunctionPointer<NetworkSendInterface.BeginSendMessageDelegate> BeginSendMessage;

		// Token: 0x0400004F RID: 79
		public TransportFunctionPointer<NetworkSendInterface.EndSendMessageDelegate> EndSendMessage;

		// Token: 0x04000050 RID: 80
		public TransportFunctionPointer<NetworkSendInterface.AbortSendMessageDelegate> AbortSendMessage;

		// Token: 0x04000051 RID: 81
		[NativeDisableUnsafePtrRestriction]
		public IntPtr UserData;

		// Token: 0x0200001C RID: 28
		// (Invoke) Token: 0x060000A8 RID: 168
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int BeginSendMessageDelegate(out NetworkInterfaceSendHandle handle, IntPtr userData, int requiredPayloadSize);

		// Token: 0x0200001D RID: 29
		// (Invoke) Token: 0x060000AC RID: 172
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int EndSendMessageDelegate(ref NetworkInterfaceSendHandle handle, ref NetworkInterfaceEndPoint address, IntPtr userData, ref NetworkSendQueueHandle sendQueue);

		// Token: 0x0200001E RID: 30
		// (Invoke) Token: 0x060000B0 RID: 176
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void AbortSendMessageDelegate(ref NetworkInterfaceSendHandle handle, IntPtr userData);
	}
}
