using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop
{
	// Token: 0x020001B9 RID: 441
	public class DisposableBuffer : IDisposable
	{
		// Token: 0x06000A5B RID: 2651 RVA: 0x0000FBE7 File Offset: 0x0000DDE7
		public DisposableBuffer()
		{
			this.IntPtr = IntPtr.Zero;
			GC.SuppressFinalize(this);
		}

		// Token: 0x06000A5C RID: 2652 RVA: 0x0000FC00 File Offset: 0x0000DE00
		public DisposableBuffer(int size)
		{
			this.IntPtr = Marshal.AllocHGlobal(size);
			Marshal.Copy(new byte[size], 0, this.IntPtr, size);
		}

		// Token: 0x06000A5D RID: 2653 RVA: 0x0000FC27 File Offset: 0x0000DE27
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06000A5E RID: 2654 RVA: 0x0000FC36 File Offset: 0x0000DE36
		private void Dispose(bool isDisposing)
		{
			if (this.IntPtr != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(this.IntPtr);
				this.IntPtr = IntPtr.Zero;
			}
		}

		// Token: 0x06000A5F RID: 2655 RVA: 0x0000FC60 File Offset: 0x0000DE60
		~DisposableBuffer()
		{
			this.Dispose(false);
		}

		// Token: 0x17000301 RID: 769
		// (get) Token: 0x06000A60 RID: 2656 RVA: 0x0000FC90 File Offset: 0x0000DE90
		// (set) Token: 0x06000A61 RID: 2657 RVA: 0x0000FC98 File Offset: 0x0000DE98
		public IntPtr IntPtr { get; private set; }
	}
}
