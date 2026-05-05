using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000E2 RID: 226
	internal class VolumeRenderingUtils
	{
		// Token: 0x0600094D RID: 2381 RVA: 0x00051FCC File Offset: 0x000501CC
		public static float MeanFreePathFromExtinction(float extinction)
		{
			return 1f / extinction;
		}

		// Token: 0x0600094E RID: 2382 RVA: 0x00051FD5 File Offset: 0x000501D5
		public static float ExtinctionFromMeanFreePath(float meanFreePath)
		{
			return 1f / meanFreePath;
		}

		// Token: 0x0600094F RID: 2383 RVA: 0x00051FDE File Offset: 0x000501DE
		public static Vector3 AbsorptionFromExtinctionAndScattering(float extinction, Vector3 scattering)
		{
			return new Vector3(extinction, extinction, extinction) - scattering;
		}

		// Token: 0x06000950 RID: 2384 RVA: 0x00051FEE File Offset: 0x000501EE
		public static Vector3 ScatteringFromExtinctionAndAlbedo(float extinction, Vector3 albedo)
		{
			return extinction * albedo;
		}

		// Token: 0x06000951 RID: 2385 RVA: 0x00051FF7 File Offset: 0x000501F7
		public static Vector3 AlbedoFromMeanFreePathAndScattering(float meanFreePath, Vector3 scattering)
		{
			return meanFreePath * scattering;
		}
	}
}
