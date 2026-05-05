using System;
using System.Collections.Generic;

namespace Unity.VisualScripting
{
	// Token: 0x02000060 RID: 96
	public class GraphDebugData : IGraphDebugData
	{
		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x060002B8 RID: 696 RVA: 0x00006CA1 File Offset: 0x00004EA1
		protected Dictionary<IGraphElementWithDebugData, IGraphElementDebugData> elementsData { get; } = new Dictionary<IGraphElementWithDebugData, IGraphElementDebugData>();

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x060002B9 RID: 697 RVA: 0x00006CA9 File Offset: 0x00004EA9
		protected Dictionary<IGraphParentElement, IGraphDebugData> childrenGraphsData { get; } = new Dictionary<IGraphParentElement, IGraphDebugData>();

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x060002BA RID: 698 RVA: 0x00006CB1 File Offset: 0x00004EB1
		IEnumerable<IGraphElementDebugData> IGraphDebugData.elementsData
		{
			get
			{
				return this.elementsData.Values;
			}
		}

		// Token: 0x060002BB RID: 699 RVA: 0x00006CBE File Offset: 0x00004EBE
		public GraphDebugData(IGraph definition)
		{
		}

		// Token: 0x060002BC RID: 700 RVA: 0x00006CDC File Offset: 0x00004EDC
		public IGraphElementDebugData GetOrCreateElementData(IGraphElementWithDebugData element)
		{
			IGraphElementDebugData graphElementDebugData;
			if (!this.elementsData.TryGetValue(element, out graphElementDebugData))
			{
				graphElementDebugData = element.CreateDebugData();
				this.elementsData.Add(element, graphElementDebugData);
			}
			return graphElementDebugData;
		}

		// Token: 0x060002BD RID: 701 RVA: 0x00006D10 File Offset: 0x00004F10
		public IGraphDebugData GetOrCreateChildGraphData(IGraphParentElement element)
		{
			IGraphDebugData graphDebugData;
			if (!this.childrenGraphsData.TryGetValue(element, out graphDebugData))
			{
				graphDebugData = new GraphDebugData(element.childGraph);
				this.childrenGraphsData.Add(element, graphDebugData);
			}
			return graphDebugData;
		}
	}
}
