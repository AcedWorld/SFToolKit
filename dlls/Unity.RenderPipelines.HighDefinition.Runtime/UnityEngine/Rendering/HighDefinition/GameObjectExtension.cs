using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020001CE RID: 462
	public static class GameObjectExtension
	{
		// Token: 0x06000E4C RID: 3660 RVA: 0x00071DB7 File Offset: 0x0006FFB7
		public static HDAdditionalLightData AddHDLight(this GameObject gameObject, HDLightTypeAndShape lightTypeAndShape)
		{
			HDAdditionalLightData hdadditionalLightData = gameObject.AddComponent<HDAdditionalLightData>();
			HDAdditionalLightData.InitDefaultHDAdditionalLightData(hdadditionalLightData);
			hdadditionalLightData.enableSpotReflector = false;
			hdadditionalLightData.SetLightTypeAndShape(lightTypeAndShape);
			return hdadditionalLightData;
		}

		// Token: 0x06000E4D RID: 3661 RVA: 0x00071DD3 File Offset: 0x0006FFD3
		public static void RemoveHDLight(this GameObject gameObject)
		{
			Object component = gameObject.GetComponent<Light>();
			CoreUtils.Destroy(gameObject.GetComponent<HDAdditionalLightData>());
			CoreUtils.Destroy(component);
		}
	}
}
