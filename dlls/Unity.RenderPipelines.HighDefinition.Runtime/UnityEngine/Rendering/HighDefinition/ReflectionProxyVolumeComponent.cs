using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000B1 RID: 177
	[AddComponentMenu("Rendering/Reflection Proxy Volume")]
	public class ReflectionProxyVolumeComponent : MonoBehaviour
	{
		// Token: 0x17000135 RID: 309
		// (get) Token: 0x0600084E RID: 2126 RVA: 0x0004B923 File Offset: 0x00049B23
		public ProxyVolume proxyVolume
		{
			get
			{
				return this.m_ProxyVolume;
			}
		}

		// Token: 0x040007E9 RID: 2025
		[SerializeField]
		private ProxyVolume m_ProxyVolume = new ProxyVolume();
	}
}
