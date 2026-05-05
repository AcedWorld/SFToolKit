using System;
using System.Collections.Generic;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x02000158 RID: 344
	internal class CullingGroupManager
	{
		// Token: 0x170001DE RID: 478
		// (get) Token: 0x06000BC2 RID: 3010 RVA: 0x0005F3BE File Offset: 0x0005D5BE
		public static CullingGroupManager instance
		{
			get
			{
				if (CullingGroupManager.m_Instance == null)
				{
					CullingGroupManager.m_Instance = new CullingGroupManager();
				}
				return CullingGroupManager.m_Instance;
			}
		}

		// Token: 0x06000BC3 RID: 3011 RVA: 0x0005F3D8 File Offset: 0x0005D5D8
		public CullingGroup Alloc()
		{
			CullingGroup cullingGroup;
			if (this.m_FreeList.Count > 0)
			{
				cullingGroup = this.m_FreeList.Pop();
				cullingGroup.enabled = true;
			}
			else
			{
				cullingGroup = new CullingGroup();
			}
			return cullingGroup;
		}

		// Token: 0x06000BC4 RID: 3012 RVA: 0x0005F40F File Offset: 0x0005D60F
		public void Free(CullingGroup group)
		{
			group.enabled = false;
			this.m_FreeList.Push(group);
		}

		// Token: 0x06000BC5 RID: 3013 RVA: 0x0005F424 File Offset: 0x0005D624
		public void Cleanup()
		{
			foreach (CullingGroup cullingGroup in this.m_FreeList)
			{
				cullingGroup.Dispose();
			}
			this.m_FreeList.Clear();
		}

		// Token: 0x04000CF1 RID: 3313
		private static CullingGroupManager m_Instance;

		// Token: 0x04000CF2 RID: 3314
		private Stack<CullingGroup> m_FreeList = new Stack<CullingGroup>();
	}
}
