using System;

namespace UnityEngine.Rendering.LookDev
{
	// Token: 0x0200011C RID: 284
	public class StageRuntimeInterface
	{
		// Token: 0x0600087F RID: 2175 RVA: 0x00027953 File Offset: 0x00025B53
		public StageRuntimeInterface(Func<bool, GameObject> AddGameObject, Func<Camera> GetCamera, Func<Light> GetSunLight)
		{
			this.m_AddGameObject = AddGameObject;
			this.m_GetCamera = GetCamera;
			this.m_GetSunLight = GetSunLight;
		}

		// Token: 0x06000880 RID: 2176 RVA: 0x00027970 File Offset: 0x00025B70
		public GameObject AddGameObject(bool persistent = false)
		{
			Func<bool, GameObject> addGameObject = this.m_AddGameObject;
			if (addGameObject == null)
			{
				return null;
			}
			return addGameObject(persistent);
		}

		// Token: 0x17000144 RID: 324
		// (get) Token: 0x06000881 RID: 2177 RVA: 0x00027984 File Offset: 0x00025B84
		public Camera camera
		{
			get
			{
				Func<Camera> getCamera = this.m_GetCamera;
				if (getCamera == null)
				{
					return null;
				}
				return getCamera();
			}
		}

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x06000882 RID: 2178 RVA: 0x00027997 File Offset: 0x00025B97
		public Light sunLight
		{
			get
			{
				Func<Light> getSunLight = this.m_GetSunLight;
				if (getSunLight == null)
				{
					return null;
				}
				return getSunLight();
			}
		}

		// Token: 0x04000503 RID: 1283
		private Func<bool, GameObject> m_AddGameObject;

		// Token: 0x04000504 RID: 1284
		private Func<Camera> m_GetCamera;

		// Token: 0x04000505 RID: 1285
		private Func<Light> m_GetSunLight;

		// Token: 0x04000506 RID: 1286
		public object SRPData;
	}
}
