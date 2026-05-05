using System;

namespace UnityEngine.SceneManagement
{
	// Token: 0x02000326 RID: 806
	[Serializable]
	public struct LoadSceneParameters
	{
		// Token: 0x1700063E RID: 1598
		// (get) Token: 0x060020C1 RID: 8385 RVA: 0x0003656C File Offset: 0x0003476C
		// (set) Token: 0x060020C2 RID: 8386 RVA: 0x00036584 File Offset: 0x00034784
		public LoadSceneMode loadSceneMode
		{
			get
			{
				return this.m_LoadSceneMode;
			}
			set
			{
				this.m_LoadSceneMode = value;
			}
		}

		// Token: 0x1700063F RID: 1599
		// (get) Token: 0x060020C3 RID: 8387 RVA: 0x00036590 File Offset: 0x00034790
		// (set) Token: 0x060020C4 RID: 8388 RVA: 0x000365A8 File Offset: 0x000347A8
		public LocalPhysicsMode localPhysicsMode
		{
			get
			{
				return this.m_LocalPhysicsMode;
			}
			set
			{
				this.m_LocalPhysicsMode = value;
			}
		}

		// Token: 0x060020C5 RID: 8389 RVA: 0x000365B2 File Offset: 0x000347B2
		public LoadSceneParameters(LoadSceneMode mode)
		{
			this.m_LoadSceneMode = mode;
			this.m_LocalPhysicsMode = LocalPhysicsMode.None;
		}

		// Token: 0x060020C6 RID: 8390 RVA: 0x000365C3 File Offset: 0x000347C3
		public LoadSceneParameters(LoadSceneMode mode, LocalPhysicsMode physicsMode)
		{
			this.m_LoadSceneMode = mode;
			this.m_LocalPhysicsMode = physicsMode;
		}

		// Token: 0x04000AC4 RID: 2756
		[SerializeField]
		private LoadSceneMode m_LoadSceneMode;

		// Token: 0x04000AC5 RID: 2757
		[SerializeField]
		private LocalPhysicsMode m_LocalPhysicsMode;
	}
}
