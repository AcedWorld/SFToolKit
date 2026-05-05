using System;
using System.Collections.Generic;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200017C RID: 380
	internal class HDRayTracingLights
	{
		// Token: 0x06000C65 RID: 3173 RVA: 0x000676BC File Offset: 0x000658BC
		internal void Reset()
		{
			this.hdDirectionalLightArray.Clear();
			this.hdPointLightArray.Clear();
			this.hdLineLightArray.Clear();
			this.hdRectLightArray.Clear();
			this.hdLightEntityArray.Clear();
			this.reflectionProbeArray.Clear();
			this.lightCount = 0;
		}

		// Token: 0x0400133B RID: 4923
		public List<HDLightRenderEntity> hdPointLightArray = new List<HDLightRenderEntity>();

		// Token: 0x0400133C RID: 4924
		public List<HDLightRenderEntity> hdLineLightArray = new List<HDLightRenderEntity>();

		// Token: 0x0400133D RID: 4925
		public List<HDLightRenderEntity> hdRectLightArray = new List<HDLightRenderEntity>();

		// Token: 0x0400133E RID: 4926
		public List<HDLightRenderEntity> hdLightEntityArray = new List<HDLightRenderEntity>();

		// Token: 0x0400133F RID: 4927
		public List<HDAdditionalLightData> hdDirectionalLightArray = new List<HDAdditionalLightData>();

		// Token: 0x04001340 RID: 4928
		public List<HDProbe> reflectionProbeArray = new List<HDProbe>();

		// Token: 0x04001341 RID: 4929
		public int lightCount;
	}
}
