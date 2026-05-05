using System;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine.Bindings;

namespace UnityEngine.Apple
{
	// Token: 0x020004F8 RID: 1272
	[NativeConditional("PLATFORM_APPLE")]
	[NativeHeader("Runtime/Export/Apple/FrameCaptureMetalScriptBindings.h")]
	public class FrameCapture
	{
		// Token: 0x06002C68 RID: 11368 RVA: 0x00009E2F File Offset: 0x0000802F
		private FrameCapture()
		{
		}

		// Token: 0x06002C69 RID: 11369
		[FreeFunction("FrameCaptureMetalScripting::IsDestinationSupported")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern bool IsDestinationSupportedImpl(FrameCaptureDestination dest);

		// Token: 0x06002C6A RID: 11370
		[FreeFunction("FrameCaptureMetalScripting::BeginCapture")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void BeginCaptureImpl(FrameCaptureDestination dest, string path);

		// Token: 0x06002C6B RID: 11371
		[FreeFunction("FrameCaptureMetalScripting::EndCapture")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void EndCaptureImpl();

		// Token: 0x06002C6C RID: 11372
		[FreeFunction("FrameCaptureMetalScripting::CaptureNextFrame")]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void CaptureNextFrameImpl(FrameCaptureDestination dest, string path);

		// Token: 0x06002C6D RID: 11373 RVA: 0x0004A96C File Offset: 0x00048B6C
		public static bool IsDestinationSupported(FrameCaptureDestination dest)
		{
			bool flag = dest != FrameCaptureDestination.DevTools && dest != FrameCaptureDestination.GPUTraceDocument;
			if (flag)
			{
				throw new ArgumentException("dest", "Argument dest has bad value (not one of FrameCaptureDestination enum values)");
			}
			return FrameCapture.IsDestinationSupportedImpl(dest);
		}

		// Token: 0x06002C6E RID: 11374 RVA: 0x0004A9A8 File Offset: 0x00048BA8
		public static void BeginCaptureToXcode()
		{
			bool flag = !FrameCapture.IsDestinationSupported(FrameCaptureDestination.DevTools);
			if (flag)
			{
				throw new InvalidOperationException("Frame Capture with DevTools is not supported.");
			}
			FrameCapture.BeginCaptureImpl(FrameCaptureDestination.DevTools, null);
		}

		// Token: 0x06002C6F RID: 11375 RVA: 0x0004A9D8 File Offset: 0x00048BD8
		public static void BeginCaptureToFile(string path)
		{
			bool flag = !FrameCapture.IsDestinationSupported(FrameCaptureDestination.GPUTraceDocument);
			if (flag)
			{
				throw new InvalidOperationException("Frame Capture to file is not supported.");
			}
			bool flag2 = string.IsNullOrEmpty(path);
			if (flag2)
			{
				throw new ArgumentException("path", "Path must be supplied when capture destination is GPUTraceDocument.");
			}
			bool flag3 = Path.GetExtension(path) != ".gputrace";
			if (flag3)
			{
				throw new ArgumentException("path", "Destination file should have .gputrace extension.");
			}
			FrameCapture.BeginCaptureImpl(FrameCaptureDestination.GPUTraceDocument, new Uri(path).AbsoluteUri);
		}

		// Token: 0x06002C70 RID: 11376 RVA: 0x0004AA4E File Offset: 0x00048C4E
		public static void EndCapture()
		{
			FrameCapture.EndCaptureImpl();
		}

		// Token: 0x06002C71 RID: 11377 RVA: 0x0004AA58 File Offset: 0x00048C58
		public static void CaptureNextFrameToXcode()
		{
			bool flag = !FrameCapture.IsDestinationSupported(FrameCaptureDestination.DevTools);
			if (flag)
			{
				throw new InvalidOperationException("Frame Capture with DevTools is not supported.");
			}
			FrameCapture.CaptureNextFrameImpl(FrameCaptureDestination.DevTools, null);
		}

		// Token: 0x06002C72 RID: 11378 RVA: 0x0004AA88 File Offset: 0x00048C88
		public static void CaptureNextFrameToFile(string path)
		{
			bool flag = !FrameCapture.IsDestinationSupported(FrameCaptureDestination.GPUTraceDocument);
			if (flag)
			{
				throw new InvalidOperationException("Frame Capture to file is not supported.");
			}
			bool flag2 = string.IsNullOrEmpty(path);
			if (flag2)
			{
				throw new ArgumentException("path", "Path must be supplied when capture destination is GPUTraceDocument.");
			}
			bool flag3 = Path.GetExtension(path) != ".gputrace";
			if (flag3)
			{
				throw new ArgumentException("path", "Destination file should have .gputrace extension.");
			}
			FrameCapture.CaptureNextFrameImpl(FrameCaptureDestination.GPUTraceDocument, new Uri(path).AbsoluteUri);
		}
	}
}
