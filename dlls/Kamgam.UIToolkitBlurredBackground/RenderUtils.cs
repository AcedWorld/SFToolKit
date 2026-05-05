using System;
using UnityEngine;

namespace Kamgam.UGUIBlurredBackground
{
	// Token: 0x02000015 RID: 21
	public static class RenderUtils
	{
		// Token: 0x060000D4 RID: 212 RVA: 0x00004C5C File Offset: 0x00002E5C
		public static Camera GetGameViewCamera(BlurredBackgroundImage image = null)
		{
			Camera camera = Camera.main;
			if (image != null && image.GetRenderMode() != RenderMode.ScreenSpaceOverlay && image.canvas != null && image.canvas.worldCamera != null && image.canvas.worldCamera.cameraType == CameraType.Game)
			{
				camera = image.canvas.worldCamera;
			}
			if (image != null && image.CameraOverride != null)
			{
				camera = image.CameraOverride;
			}
			if (camera == null)
			{
				int allCamerasCount = Camera.allCamerasCount;
				if (allCamerasCount > RenderUtils._tmpAllCameras.Length)
				{
					RenderUtils._tmpAllCameras = new Camera[allCamerasCount + 5];
				}
				Camera.GetAllCameras(RenderUtils._tmpAllCameras);
				float num = float.MinValue;
				for (int i = RenderUtils._tmpAllCameras.Length - 1; i >= 0; i--)
				{
					if (i >= allCamerasCount)
					{
						RenderUtils._tmpAllCameras[i] = null;
					}
					else
					{
						Camera camera2 = RenderUtils._tmpAllCameras[i];
						if (camera2.isActiveAndEnabled && camera2.depth > num && camera2.targetTexture == null && camera2.rect.width >= 1f && camera2.rect.height >= 1f)
						{
							num = camera2.depth;
							camera = camera2;
						}
					}
				}
			}
			if (camera != null && camera.cameraType == CameraType.Game)
			{
				RenderUtils._cachedGameViewCam = camera;
			}
			if (camera == null)
			{
				return RenderUtils._cachedGameViewCam;
			}
			return camera;
		}

		// Token: 0x04000064 RID: 100
		private static Camera _cachedGameViewCam;

		// Token: 0x04000065 RID: 101
		private static Camera[] _tmpAllCameras = new Camera[10];
	}
}
