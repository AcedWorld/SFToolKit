using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace UnityEngine.Rendering.HighDefinition
{
	// Token: 0x0200019A RID: 410
	public class AOVRequestDataCollection : IEnumerable<AOVRequestData>, IEnumerable, IDisposable
	{
		// Token: 0x06000CB3 RID: 3251 RVA: 0x00068E68 File Offset: 0x00067068
		public AOVRequestDataCollection(List<AOVRequestData> aovRequestData)
		{
			this.m_AOVRequestData = aovRequestData;
		}

		// Token: 0x06000CB4 RID: 3252 RVA: 0x00068E78 File Offset: 0x00067078
		public IEnumerator<AOVRequestData> GetEnumerator()
		{
			IEnumerable<AOVRequestData> aovrequestData = this.m_AOVRequestData;
			return (aovrequestData ?? Enumerable.Empty<AOVRequestData>()).GetEnumerator();
		}

		// Token: 0x06000CB5 RID: 3253 RVA: 0x00068E9B File Offset: 0x0006709B
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x06000CB6 RID: 3254 RVA: 0x00068EA3 File Offset: 0x000670A3
		public void Dispose()
		{
			if (this.m_AOVRequestData == null)
			{
				return;
			}
			ListPool<AOVRequestData>.Release(this.m_AOVRequestData);
			this.m_AOVRequestData = null;
		}

		// Token: 0x040013C3 RID: 5059
		private List<AOVRequestData> m_AOVRequestData;
	}
}
