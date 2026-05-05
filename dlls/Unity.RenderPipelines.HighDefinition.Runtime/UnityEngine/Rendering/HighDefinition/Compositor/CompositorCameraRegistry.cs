using System;
using System.Collections.Generic;

namespace UnityEngine.Rendering.HighDefinition.Compositor
{
	// Token: 0x02000243 RID: 579
	internal class CompositorCameraRegistry
	{
		// Token: 0x06001092 RID: 4242 RVA: 0x0007F63F File Offset: 0x0007D83F
		public static CompositorCameraRegistry GetInstance()
		{
			CompositorCameraRegistry result;
			if ((result = CompositorCameraRegistry.s_CompositorCameraRegistry) == null)
			{
				result = (CompositorCameraRegistry.s_CompositorCameraRegistry = new CompositorCameraRegistry());
			}
			return result;
		}

		// Token: 0x06001093 RID: 4243 RVA: 0x0007F655 File Offset: 0x0007D855
		internal void RegisterInternalCamera(Camera camera)
		{
			CompositorCameraRegistry.s_CompositorManagedCameras.Add(camera);
		}

		// Token: 0x06001094 RID: 4244 RVA: 0x0007F662 File Offset: 0x0007D862
		internal void UnregisterInternalCamera(Camera camera)
		{
			CompositorCameraRegistry.s_CompositorManagedCameras.Remove(camera);
		}

		// Token: 0x06001095 RID: 4245 RVA: 0x0007F670 File Offset: 0x0007D870
		internal void CleanUpCameraOrphans(List<CompositorLayer> layers = null)
		{
			CompositorCameraRegistry.s_CompositorManagedCameras.RemoveAll((Camera x) => x == null);
			for (int i = CompositorCameraRegistry.s_CompositorManagedCameras.Count - 1; i >= 0; i--)
			{
				bool flag = false;
				if (layers != null)
				{
					foreach (CompositorLayer compositorLayer in layers)
					{
						if (CompositorCameraRegistry.s_CompositorManagedCameras[i].Equals(compositorLayer.camera))
						{
							flag = true;
							break;
						}
					}
				}
				if (!flag && CompositorCameraRegistry.s_CompositorManagedCameras[i] != null)
				{
					HDAdditionalCameraData component = CompositorCameraRegistry.s_CompositorManagedCameras[i].GetComponent<HDAdditionalCameraData>();
					if (component)
					{
						CoreUtils.Destroy(component);
					}
					CompositorCameraRegistry.s_CompositorManagedCameras[i].targetTexture = null;
					CoreUtils.Destroy(CompositorCameraRegistry.s_CompositorManagedCameras[i]);
					CompositorCameraRegistry.s_CompositorManagedCameras.RemoveAt(i);
				}
			}
			if (layers != null)
			{
				foreach (CompositorLayer compositorLayer2 in layers)
				{
					if (compositorLayer2 != null && !CompositorCameraRegistry.s_CompositorManagedCameras.Contains(compositorLayer2.camera))
					{
						CompositorCameraRegistry.s_CompositorManagedCameras.Add(compositorLayer2.camera);
					}
				}
			}
		}

		// Token: 0x06001096 RID: 4246 RVA: 0x0007F7E8 File Offset: 0x0007D9E8
		internal void PrinCameraIDs()
		{
			for (int i = CompositorCameraRegistry.s_CompositorManagedCameras.Count - 1; i >= 0; i--)
			{
				if (CompositorCameraRegistry.s_CompositorManagedCameras[i])
				{
					CompositorCameraRegistry.s_CompositorManagedCameras[i].GetInstanceID();
				}
			}
		}

		// Token: 0x040019BC RID: 6588
		private static List<Camera> s_CompositorManagedCameras = new List<Camera>();

		// Token: 0x040019BD RID: 6589
		private static CompositorCameraRegistry s_CompositorCameraRegistry;
	}
}
