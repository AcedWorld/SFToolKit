using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200015E RID: 350
	public static class HDDynamicResolutionPlatformCapabilities
	{
		// Token: 0x170001E0 RID: 480
		// (get) Token: 0x06000BD2 RID: 3026 RVA: 0x0005FE5D File Offset: 0x0005E05D
		public static bool DLSSDetected
		{
			get
			{
				return HDDynamicResolutionPlatformCapabilities.m_DLSSDetected;
			}
		}

		// Token: 0x06000BD3 RID: 3027 RVA: 0x0005FE64 File Offset: 0x0005E064
		internal static void ActivateDLSS()
		{
			HDDynamicResolutionPlatformCapabilities.m_DLSSDetected = true;
		}

		// Token: 0x04000D2D RID: 3373
		private static bool m_DLSSDetected;
	}
}
