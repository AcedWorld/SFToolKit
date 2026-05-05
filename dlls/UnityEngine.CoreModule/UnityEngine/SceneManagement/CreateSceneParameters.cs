using System;

namespace UnityEngine.SceneManagement
{
	// Token: 0x02000327 RID: 807
	[Serializable]
	public struct CreateSceneParameters
	{
		// Token: 0x17000640 RID: 1600
		// (get) Token: 0x060020C7 RID: 8391 RVA: 0x000365D4 File Offset: 0x000347D4
		// (set) Token: 0x060020C8 RID: 8392 RVA: 0x000365EC File Offset: 0x000347EC
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

		// Token: 0x060020C9 RID: 8393 RVA: 0x000365EC File Offset: 0x000347EC
		public CreateSceneParameters(LocalPhysicsMode physicsMode)
		{
			this.m_LocalPhysicsMode = physicsMode;
		}

		// Token: 0x04000AC6 RID: 2758
		[SerializeField]
		private LocalPhysicsMode m_LocalPhysicsMode;
	}
}
