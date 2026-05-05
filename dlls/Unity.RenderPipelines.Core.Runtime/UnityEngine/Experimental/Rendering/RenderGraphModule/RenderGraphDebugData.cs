using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace UnityEngine.Experimental.Rendering.RenderGraphModule
{
	// Token: 0x02000014 RID: 20
	internal class RenderGraphDebugData
	{
		// Token: 0x0600008C RID: 140 RVA: 0x000044C8 File Offset: 0x000026C8
		public void Clear()
		{
			this.passList.Clear();
			if (this.resourceLists[0] == null)
			{
				for (int i = 0; i < 2; i++)
				{
					this.resourceLists[i] = new List<RenderGraphDebugData.ResourceDebugData>();
				}
			}
			for (int j = 0; j < 2; j++)
			{
				this.resourceLists[j].Clear();
			}
		}

		// Token: 0x0400006C RID: 108
		public List<RenderGraphDebugData.PassDebugData> passList = new List<RenderGraphDebugData.PassDebugData>();

		// Token: 0x0400006D RID: 109
		public List<RenderGraphDebugData.ResourceDebugData>[] resourceLists = new List<RenderGraphDebugData.ResourceDebugData>[2];

		// Token: 0x02000145 RID: 325
		[DebuggerDisplay("PassDebug: {name}")]
		public struct PassDebugData
		{
			// Token: 0x040005B1 RID: 1457
			public string name;

			// Token: 0x040005B2 RID: 1458
			public List<int>[] resourceReadLists;

			// Token: 0x040005B3 RID: 1459
			public List<int>[] resourceWriteLists;

			// Token: 0x040005B4 RID: 1460
			public bool culled;

			// Token: 0x040005B5 RID: 1461
			public bool async;

			// Token: 0x040005B6 RID: 1462
			public int syncToPassIndex;

			// Token: 0x040005B7 RID: 1463
			public int syncFromPassIndex;

			// Token: 0x040005B8 RID: 1464
			public bool generateDebugData;
		}

		// Token: 0x02000146 RID: 326
		[DebuggerDisplay("ResourceDebug: {name} [{creationPassIndex}:{releasePassIndex}]")]
		public struct ResourceDebugData
		{
			// Token: 0x040005B9 RID: 1465
			public string name;

			// Token: 0x040005BA RID: 1466
			public bool imported;

			// Token: 0x040005BB RID: 1467
			public int creationPassIndex;

			// Token: 0x040005BC RID: 1468
			public int releasePassIndex;

			// Token: 0x040005BD RID: 1469
			public List<int> consumerList;

			// Token: 0x040005BE RID: 1470
			public List<int> producerList;
		}
	}
}
