using System;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Unity.Networking.Transport
{
	// Token: 0x0200001A RID: 26
	public struct NetworkSendQueueHandle
	{
		// Token: 0x060000A5 RID: 165 RVA: 0x00004690 File Offset: 0x00002890
		internal unsafe static NetworkSendQueueHandle ToTempHandle(NativeQueue<QueuedSendMessage>.ParallelWriter sendQueue)
		{
			void* ptr = UnsafeUtility.Malloc((long)UnsafeUtility.SizeOf<NativeQueue<QueuedSendMessage>.ParallelWriter>(), UnsafeUtility.AlignOf<NativeQueue<QueuedSendMessage>.ParallelWriter>(), Allocator.Temp);
			UnsafeUtility.WriteArrayElement<NativeQueue<QueuedSendMessage>.ParallelWriter>(ptr, 0, sendQueue);
			return new NetworkSendQueueHandle
			{
				handle = (IntPtr)ptr
			};
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x000046CD File Offset: 0x000028CD
		public unsafe NativeQueue<QueuedSendMessage>.ParallelWriter FromHandle()
		{
			return UnsafeUtility.ReadArrayElement<NativeQueue<QueuedSendMessage>.ParallelWriter>((void*)this.handle, 0);
		}

		// Token: 0x0400004D RID: 77
		private IntPtr handle;
	}
}
