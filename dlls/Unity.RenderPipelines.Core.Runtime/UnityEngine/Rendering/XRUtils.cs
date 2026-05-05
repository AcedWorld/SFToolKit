using System;

namespace UnityEngine.Rendering
{
	// Token: 0x020000E4 RID: 228
	public static class XRUtils
	{
		// Token: 0x06000792 RID: 1938 RVA: 0x00024E00 File Offset: 0x00023000
		public static void DrawOcclusionMesh(CommandBuffer cmd, Camera camera, bool stereoEnabled = true)
		{
			if (!XRGraphics.enabled || !camera.stereoEnabled || !stereoEnabled)
			{
				return;
			}
			RectInt normalizedCamViewport = new RectInt(0, 0, camera.pixelWidth, camera.pixelHeight);
			cmd.DrawOcclusionMesh(normalizedCamViewport);
		}
	}
}
