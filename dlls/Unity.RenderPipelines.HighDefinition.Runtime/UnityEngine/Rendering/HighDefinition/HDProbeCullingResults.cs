using System;
using System.Collections.Generic;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x020000A7 RID: 167
	internal class HDProbeCullingResults
	{
		// Token: 0x1700010D RID: 269
		// (get) Token: 0x060007BD RID: 1981 RVA: 0x00049547 File Offset: 0x00047747
		public IReadOnlyList<HDProbe> visibleProbes
		{
			get
			{
				return this.m_VisibleProbes;
			}
		}

		// Token: 0x060007BE RID: 1982 RVA: 0x0004954F File Offset: 0x0004774F
		internal void Reset()
		{
			this.m_VisibleProbes.Clear();
		}

		// Token: 0x060007BF RID: 1983 RVA: 0x0004955C File Offset: 0x0004775C
		internal void AddProbe(HDProbe visibleProbes)
		{
			this.m_VisibleProbes.Add(visibleProbes);
		}

		// Token: 0x0400078A RID: 1930
		private static readonly IReadOnlyList<HDProbe> s_EmptyList = new List<HDProbe>();

		// Token: 0x0400078B RID: 1931
		private List<HDProbe> m_VisibleProbes = new List<HDProbe>();
	}
}
