using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Unity.XGamingRuntime.Interop;

namespace Unity.XGamingRuntime
{
	// Token: 0x0200002D RID: 45
	public class XAsyncBlock : IDisposable
	{
		// Token: 0x06000317 RID: 791 RVA: 0x00009244 File Offset: 0x00007444
		[MonoPInvokeCallback(typeof(XAsyncCompletionRoutineInterop))]
		private static void OnXAsyncBlockCompletion(IntPtr asyncBlock)
		{
			(GCHandle.FromIntPtr(((XAsyncBlock.XAsyncBlockInterop)Marshal.PtrToStructure(asyncBlock, typeof(XAsyncBlock.XAsyncBlockInterop))).context).Target as XAsyncBlock).DoCompletionCallback();
		}

		// Token: 0x06000318 RID: 792 RVA: 0x00009284 File Offset: 0x00007484
		public XAsyncBlock(XTaskQueueHandle queue, XAsyncCompletionRoutine callback, IntPtr context)
		{
			this.Queue = queue;
			this.Context = context;
			this.Callback = callback;
			this.Interop = new XAsyncBlock.XAsyncBlockInterop
			{
				queue = ((queue != null) ? queue.Handle : IntPtr.Zero)
			};
			if (callback != null)
			{
				this.callbackObjHandle = GCHandle.Alloc(this);
				this.Interop.context = GCHandle.ToIntPtr(this.callbackObjHandle);
				this.Interop.callback = Marshal.GetFunctionPointerForDelegate<XAsyncCompletionRoutineInterop>(XAsyncBlock.InteropCallback);
			}
			this.interopHandle = GCHandle.Alloc(this.Interop, GCHandleType.Pinned);
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x06000319 RID: 793 RVA: 0x00009329 File Offset: 0x00007529
		// (set) Token: 0x0600031A RID: 794 RVA: 0x00009331 File Offset: 0x00007531
		public bool IsCompleted { get; private set; }

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x0600031B RID: 795 RVA: 0x0000933A File Offset: 0x0000753A
		public IntPtr InteropPtr
		{
			get
			{
				return this.interopHandle.AddrOfPinnedObject();
			}
		}

		// Token: 0x0600031C RID: 796 RVA: 0x00009348 File Offset: 0x00007548
		private void DoCompletionCallback()
		{
			this.Callback(this);
			this.IsCompleted = true;
			if (this.callbackObjHandle.IsAllocated)
			{
				this.callbackObjHandle.Free();
			}
			if (this.interopHandle.IsAllocated)
			{
				this.interopHandle.Free();
			}
		}

		// Token: 0x0600031D RID: 797 RVA: 0x00009398 File Offset: 0x00007598
		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposedValue)
			{
				if (this.callbackObjHandle.IsAllocated)
				{
					this.callbackObjHandle.Free();
				}
				if (this.interopHandle.IsAllocated)
				{
					this.interopHandle.Free();
				}
				this.disposedValue = true;
			}
		}

		// Token: 0x0600031E RID: 798 RVA: 0x000093E4 File Offset: 0x000075E4
		~XAsyncBlock()
		{
			this.Dispose(false);
		}

		// Token: 0x0600031F RID: 799 RVA: 0x00009414 File Offset: 0x00007614
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x040000BC RID: 188
		public XTaskQueueHandle Queue;

		// Token: 0x040000BD RID: 189
		public IntPtr Context;

		// Token: 0x040000BE RID: 190
		public XAsyncCompletionRoutine Callback;

		// Token: 0x040000BF RID: 191
		public XAsyncBlock.XAsyncBlockInterop Interop;

		// Token: 0x040000C0 RID: 192
		private GCHandle callbackObjHandle;

		// Token: 0x040000C1 RID: 193
		private GCHandle interopHandle;

		// Token: 0x040000C2 RID: 194
		private static XAsyncCompletionRoutineInterop InteropCallback = new XAsyncCompletionRoutineInterop(XAsyncBlock.OnXAsyncBlockCompletion);

		// Token: 0x040000C3 RID: 195
		private bool disposedValue;

		// Token: 0x02000312 RID: 786
		public struct XAsyncBlockInterop
		{
			// Token: 0x04000968 RID: 2408
			public IntPtr queue;

			// Token: 0x04000969 RID: 2409
			public IntPtr context;

			// Token: 0x0400096A RID: 2410
			public IntPtr callback;

			// Token: 0x0400096B RID: 2411
			[FixedBuffer(typeof(byte), 32)]
			public XAsyncBlock.XAsyncBlockInterop.<reserved>e__FixedBuffer reserved;

			// Token: 0x020003BC RID: 956
			[CompilerGenerated]
			[UnsafeValueType]
			[StructLayout(LayoutKind.Sequential, Size = 32)]
			public struct <reserved>e__FixedBuffer
			{
				// Token: 0x04000A5D RID: 2653
				public byte FixedElementField;
			}
		}
	}
}
