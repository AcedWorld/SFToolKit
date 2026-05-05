using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;

namespace UnityEngine.Rendering.VirtualTexturing
{
	// Token: 0x02000007 RID: 7
	[NativeHeader("Modules/VirtualTexturing/Public/VirtualTextureResolver.h")]
	[StructLayout(LayoutKind.Sequential)]
	public class Resolver : IDisposable
	{
		// Token: 0x06000016 RID: 22 RVA: 0x0000208C File Offset: 0x0000028C
		public Resolver()
		{
			bool flag = !System.enabled;
			if (flag)
			{
				throw new InvalidOperationException("Virtual texturing is not enabled in the player settings.");
			}
			this.m_Ptr = Resolver.InitNative();
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000020D4 File Offset: 0x000002D4
		~Resolver()
		{
			this.Dispose(false);
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002108 File Offset: 0x00000308
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06000019 RID: 25 RVA: 0x0000211C File Offset: 0x0000031C
		protected virtual void Dispose(bool disposing)
		{
			bool flag = this.m_Ptr != IntPtr.Zero;
			if (flag)
			{
				this.Flush_Internal();
				Resolver.ReleaseNative(this.m_Ptr);
				this.m_Ptr = IntPtr.Zero;
			}
		}

		// Token: 0x0600001A RID: 26
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern IntPtr InitNative();

		// Token: 0x0600001B RID: 27
		[NativeMethod(IsThreadSafe = true)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ReleaseNative(IntPtr ptr);

		// Token: 0x0600001C RID: 28
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void Flush_Internal();

		// Token: 0x0600001D RID: 29
		[MethodImpl(MethodImplOptions.InternalCall)]
		private extern void Init_Internal(int width, int height);

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600001E RID: 30 RVA: 0x0000215E File Offset: 0x0000035E
		// (set) Token: 0x0600001F RID: 31 RVA: 0x00002166 File Offset: 0x00000366
		public int CurrentWidth { get; private set; } = 0;

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000020 RID: 32 RVA: 0x0000216F File Offset: 0x0000036F
		// (set) Token: 0x06000021 RID: 33 RVA: 0x00002177 File Offset: 0x00000377
		public int CurrentHeight { get; private set; } = 0;

		// Token: 0x06000022 RID: 34 RVA: 0x00002180 File Offset: 0x00000380
		public void UpdateSize(int width, int height)
		{
			bool flag = this.CurrentWidth != width || this.CurrentHeight != height;
			if (flag)
			{
				bool flag2 = width <= 0 || height <= 0;
				if (flag2)
				{
					throw new ArgumentException(string.Format("Zero sized dimensions are invalid (width: {0}, height: {1}.", width, height));
				}
				this.CurrentWidth = width;
				this.CurrentHeight = height;
				this.Flush_Internal();
				this.Init_Internal(this.CurrentWidth, this.CurrentHeight);
			}
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002208 File Offset: 0x00000408
		public void Process(CommandBuffer cmd, RenderTargetIdentifier rt)
		{
			this.Process(cmd, rt, 0, this.CurrentWidth, 0, this.CurrentHeight, 0, 0);
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00002230 File Offset: 0x00000430
		public void Process(CommandBuffer cmd, RenderTargetIdentifier rt, int x, int width, int y, int height, int mip, int slice)
		{
			bool flag = cmd == null;
			if (flag)
			{
				throw new ArgumentNullException("cmd");
			}
			cmd.ProcessVTFeedback(rt, this.m_Ptr, slice, x, width, y, height, mip);
		}

		// Token: 0x04000009 RID: 9
		internal IntPtr m_Ptr;
	}
}
