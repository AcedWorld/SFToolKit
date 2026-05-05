using System;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000A8 RID: 168
	internal struct HDProbeCullState
	{
		// Token: 0x1700010E RID: 270
		// (get) Token: 0x060007C2 RID: 1986 RVA: 0x00049589 File Offset: 0x00047789
		internal CullingGroup cullingGroup
		{
			get
			{
				return this.m_CullingGroup;
			}
		}

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x060007C3 RID: 1987 RVA: 0x00049591 File Offset: 0x00047791
		internal HDProbe[] hdProbes
		{
			get
			{
				return this.m_HDProbes;
			}
		}

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x060007C4 RID: 1988 RVA: 0x00049599 File Offset: 0x00047799
		internal Hash128 stateHash
		{
			get
			{
				return this.m_StateHash;
			}
		}

		// Token: 0x060007C5 RID: 1989 RVA: 0x000495A1 File Offset: 0x000477A1
		internal HDProbeCullState(CullingGroup cullingGroup, HDProbe[] hdProbes, Hash128 stateHash)
		{
			this.m_CullingGroup = cullingGroup;
			this.m_HDProbes = hdProbes;
			this.m_StateHash = stateHash;
		}

		// Token: 0x0400078C RID: 1932
		private CullingGroup m_CullingGroup;

		// Token: 0x0400078D RID: 1933
		private HDProbe[] m_HDProbes;

		// Token: 0x0400078E RID: 1934
		private Hash128 m_StateHash;
	}
}
