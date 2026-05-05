using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000A3 RID: 163
	public static class HDAdditionalReflectionDataExtensions
	{
		// Token: 0x0600075D RID: 1885 RVA: 0x00048738 File Offset: 0x00046938
		public static void RequestRenderNextUpdate(this ReflectionProbe probe)
		{
			HDAdditionalReflectionData component = probe.GetComponent<HDAdditionalReflectionData>();
			if (component != null && !component.Equals(null))
			{
				component.RequestRenderNextUpdate();
			}
		}
	}
}
