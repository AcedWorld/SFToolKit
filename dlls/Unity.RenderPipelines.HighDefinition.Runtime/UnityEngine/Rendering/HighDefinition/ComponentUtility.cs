using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000022 RID: 34
	public static class ComponentUtility
	{
		// Token: 0x06000047 RID: 71 RVA: 0x000043B2 File Offset: 0x000025B2
		public static bool IsHDCamera(Camera camera)
		{
			return camera.GetComponent<HDAdditionalCameraData>() != null;
		}

		// Token: 0x06000048 RID: 72 RVA: 0x000043C0 File Offset: 0x000025C0
		public static bool IsHDLight(Light light)
		{
			return light.GetComponent<HDAdditionalLightData>() != null;
		}

		// Token: 0x06000049 RID: 73 RVA: 0x000043CE File Offset: 0x000025CE
		public static bool IsHDReflectionProbe(ReflectionProbe reflectionProbe)
		{
			return reflectionProbe.GetComponent<HDAdditionalReflectionData>() != null;
		}
	}
}
