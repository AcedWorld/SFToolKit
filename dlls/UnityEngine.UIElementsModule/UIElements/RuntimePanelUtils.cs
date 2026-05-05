using System;

namespace UnityEngine.UIElements
{
	// Token: 0x02000256 RID: 598
	public static class RuntimePanelUtils
	{
		// Token: 0x0600111E RID: 4382 RVA: 0x0003DBC0 File Offset: 0x0003BDC0
		public static Vector2 ScreenToPanel(IPanel panel, Vector2 screenPosition)
		{
			return ((BaseRuntimePanel)panel).ScreenToPanel(screenPosition);
		}

		// Token: 0x0600111F RID: 4383 RVA: 0x0003DBE0 File Offset: 0x0003BDE0
		public static Vector2 CameraTransformWorldToPanel(IPanel panel, Vector3 worldPosition, Camera camera)
		{
			Vector2 vector = camera.WorldToScreenPoint(worldPosition);
			vector.y = (float)Screen.height - vector.y;
			return ((BaseRuntimePanel)panel).ScreenToPanel(vector);
		}

		// Token: 0x06001120 RID: 4384 RVA: 0x0003DC20 File Offset: 0x0003BE20
		public static Rect CameraTransformWorldToPanelRect(IPanel panel, Vector3 worldPosition, Vector2 worldSize, Camera camera)
		{
			worldSize.y = -worldSize.y;
			Vector2 vector = RuntimePanelUtils.CameraTransformWorldToPanel(panel, worldPosition, camera);
			Vector3 worldPosition2 = worldPosition + camera.worldToCameraMatrix.MultiplyVector(worldSize);
			Vector2 a = RuntimePanelUtils.CameraTransformWorldToPanel(panel, worldPosition2, camera);
			return new Rect(vector, a - vector);
		}

		// Token: 0x06001121 RID: 4385 RVA: 0x0003DC7C File Offset: 0x0003BE7C
		public static void ResetDynamicAtlas(this IPanel panel)
		{
			BaseVisualElementPanel baseVisualElementPanel = panel as BaseVisualElementPanel;
			bool flag = baseVisualElementPanel == null;
			if (!flag)
			{
				DynamicAtlas dynamicAtlas = baseVisualElementPanel.atlas as DynamicAtlas;
				if (dynamicAtlas != null)
				{
					dynamicAtlas.Reset();
				}
			}
		}

		// Token: 0x06001122 RID: 4386 RVA: 0x0003DCB4 File Offset: 0x0003BEB4
		public static void SetTextureDirty(this IPanel panel, Texture2D texture)
		{
			BaseVisualElementPanel baseVisualElementPanel = panel as BaseVisualElementPanel;
			bool flag = baseVisualElementPanel == null;
			if (!flag)
			{
				DynamicAtlas dynamicAtlas = baseVisualElementPanel.atlas as DynamicAtlas;
				if (dynamicAtlas != null)
				{
					dynamicAtlas.SetDirty(texture);
				}
			}
		}
	}
}
