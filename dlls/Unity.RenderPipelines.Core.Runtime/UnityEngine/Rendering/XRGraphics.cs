using System;
using UnityEngine.XR;

namespace UnityEngine.Rendering
{
	// Token: 0x0200005A RID: 90
	[Serializable]
	public class XRGraphics
	{
		// Token: 0x17000054 RID: 84
		// (get) Token: 0x060002D9 RID: 729 RVA: 0x0000C898 File Offset: 0x0000AA98
		// (set) Token: 0x060002DA RID: 730 RVA: 0x0000C8AC File Offset: 0x0000AAAC
		public static float eyeTextureResolutionScale
		{
			get
			{
				if (XRGraphics.enabled)
				{
					return XRSettings.eyeTextureResolutionScale;
				}
				return 1f;
			}
			set
			{
				XRSettings.eyeTextureResolutionScale = value;
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x060002DB RID: 731 RVA: 0x0000C8B4 File Offset: 0x0000AAB4
		public static float renderViewportScale
		{
			get
			{
				if (XRGraphics.enabled)
				{
					return XRSettings.renderViewportScale;
				}
				return 1f;
			}
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x060002DC RID: 732 RVA: 0x0000C8C8 File Offset: 0x0000AAC8
		public static bool enabled
		{
			get
			{
				return XRSettings.enabled;
			}
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x060002DD RID: 733 RVA: 0x0000C8CF File Offset: 0x0000AACF
		public static bool isDeviceActive
		{
			get
			{
				return XRGraphics.enabled && XRSettings.isDeviceActive;
			}
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x060002DE RID: 734 RVA: 0x0000C8DF File Offset: 0x0000AADF
		public static string loadedDeviceName
		{
			get
			{
				if (XRGraphics.enabled)
				{
					return XRSettings.loadedDeviceName;
				}
				return "No XR device loaded";
			}
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x060002DF RID: 735 RVA: 0x0000C8F3 File Offset: 0x0000AAF3
		public static string[] supportedDevices
		{
			get
			{
				if (XRGraphics.enabled)
				{
					return XRSettings.supportedDevices;
				}
				return new string[1];
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x060002E0 RID: 736 RVA: 0x0000C908 File Offset: 0x0000AB08
		public static XRGraphics.StereoRenderingMode stereoRenderingMode
		{
			get
			{
				if (XRGraphics.enabled)
				{
					return (XRGraphics.StereoRenderingMode)XRSettings.stereoRenderingMode;
				}
				return XRGraphics.StereoRenderingMode.SinglePass;
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x060002E1 RID: 737 RVA: 0x0000C918 File Offset: 0x0000AB18
		public static RenderTextureDescriptor eyeTextureDesc
		{
			get
			{
				if (XRGraphics.enabled)
				{
					return XRSettings.eyeTextureDesc;
				}
				return new RenderTextureDescriptor(0, 0);
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x060002E2 RID: 738 RVA: 0x0000C92E File Offset: 0x0000AB2E
		public static int eyeTextureWidth
		{
			get
			{
				if (XRGraphics.enabled)
				{
					return XRSettings.eyeTextureWidth;
				}
				return 0;
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x060002E3 RID: 739 RVA: 0x0000C93E File Offset: 0x0000AB3E
		public static int eyeTextureHeight
		{
			get
			{
				if (XRGraphics.enabled)
				{
					return XRSettings.eyeTextureHeight;
				}
				return 0;
			}
		}

		// Token: 0x02000161 RID: 353
		public enum StereoRenderingMode
		{
			// Token: 0x040005F5 RID: 1525
			MultiPass,
			// Token: 0x040005F6 RID: 1526
			SinglePass,
			// Token: 0x040005F7 RID: 1527
			SinglePassInstanced,
			// Token: 0x040005F8 RID: 1528
			SinglePassMultiView
		}
	}
}
