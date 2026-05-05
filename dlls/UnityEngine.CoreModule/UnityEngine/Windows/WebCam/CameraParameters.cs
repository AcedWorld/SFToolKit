using System;
using System.Linq;
using UnityEngine.Bindings;
using UnityEngine.Scripting;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEngine.Windows.WebCam
{
	// Token: 0x020002F0 RID: 752
	[UsedByNativeCode]
	[MovedFrom("UnityEngine.XR.WSA.WebCam")]
	[NativeHeader("PlatformDependent/Win/Webcam/CameraParameters.h")]
	public struct CameraParameters
	{
		// Token: 0x1700060E RID: 1550
		// (get) Token: 0x06001F42 RID: 8002 RVA: 0x000333F4 File Offset: 0x000315F4
		// (set) Token: 0x06001F43 RID: 8003 RVA: 0x0003340C File Offset: 0x0003160C
		public float hologramOpacity
		{
			get
			{
				return this.m_HologramOpacity;
			}
			set
			{
				this.m_HologramOpacity = value;
			}
		}

		// Token: 0x1700060F RID: 1551
		// (get) Token: 0x06001F44 RID: 8004 RVA: 0x00033418 File Offset: 0x00031618
		// (set) Token: 0x06001F45 RID: 8005 RVA: 0x00033430 File Offset: 0x00031630
		public float frameRate
		{
			get
			{
				return this.m_FrameRate;
			}
			set
			{
				this.m_FrameRate = value;
			}
		}

		// Token: 0x17000610 RID: 1552
		// (get) Token: 0x06001F46 RID: 8006 RVA: 0x0003343C File Offset: 0x0003163C
		// (set) Token: 0x06001F47 RID: 8007 RVA: 0x00033454 File Offset: 0x00031654
		public int cameraResolutionWidth
		{
			get
			{
				return this.m_CameraResolutionWidth;
			}
			set
			{
				this.m_CameraResolutionWidth = value;
			}
		}

		// Token: 0x17000611 RID: 1553
		// (get) Token: 0x06001F48 RID: 8008 RVA: 0x00033460 File Offset: 0x00031660
		// (set) Token: 0x06001F49 RID: 8009 RVA: 0x00033478 File Offset: 0x00031678
		public int cameraResolutionHeight
		{
			get
			{
				return this.m_CameraResolutionHeight;
			}
			set
			{
				this.m_CameraResolutionHeight = value;
			}
		}

		// Token: 0x17000612 RID: 1554
		// (get) Token: 0x06001F4A RID: 8010 RVA: 0x00033484 File Offset: 0x00031684
		// (set) Token: 0x06001F4B RID: 8011 RVA: 0x0003349C File Offset: 0x0003169C
		public CapturePixelFormat pixelFormat
		{
			get
			{
				return this.m_PixelFormat;
			}
			set
			{
				this.m_PixelFormat = value;
			}
		}

		// Token: 0x06001F4C RID: 8012 RVA: 0x000334A8 File Offset: 0x000316A8
		public CameraParameters(WebCamMode webCamMode)
		{
			this.m_HologramOpacity = 1f;
			this.m_PixelFormat = CapturePixelFormat.BGRA32;
			this.m_FrameRate = 0f;
			this.m_CameraResolutionWidth = 0;
			this.m_CameraResolutionHeight = 0;
			bool flag = webCamMode == WebCamMode.PhotoMode;
			if (flag)
			{
				Resolution resolution = (from res in PhotoCapture.SupportedResolutions
				orderby res.width * res.height descending
				select res).First<Resolution>();
				this.m_CameraResolutionWidth = resolution.width;
				this.m_CameraResolutionHeight = resolution.height;
			}
			else
			{
				bool flag2 = webCamMode == WebCamMode.VideoMode;
				if (flag2)
				{
					Resolution resolution2 = (from res in VideoCapture.SupportedResolutions
					orderby res.width * res.height descending
					select res).First<Resolution>();
					float frameRate = (from fps in VideoCapture.GetSupportedFrameRatesForResolution(resolution2)
					orderby fps descending
					select fps).First<float>();
					this.m_CameraResolutionWidth = resolution2.width;
					this.m_CameraResolutionHeight = resolution2.height;
					this.m_FrameRate = frameRate;
				}
			}
		}

		// Token: 0x04000A4B RID: 2635
		private float m_HologramOpacity;

		// Token: 0x04000A4C RID: 2636
		private float m_FrameRate;

		// Token: 0x04000A4D RID: 2637
		private int m_CameraResolutionWidth;

		// Token: 0x04000A4E RID: 2638
		private int m_CameraResolutionHeight;

		// Token: 0x04000A4F RID: 2639
		private CapturePixelFormat m_PixelFormat;
	}
}
