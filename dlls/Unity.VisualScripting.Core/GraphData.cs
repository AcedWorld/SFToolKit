using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.VisualScripting
{
	// Token: 0x0200005F RID: 95
	public class GraphData<TGraph> : IGraphData where TGraph : class, IGraph
	{
		// Token: 0x060002AC RID: 684 RVA: 0x00006AA4 File Offset: 0x00004CA4
		public GraphData(TGraph definition)
		{
			this.definition = definition;
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x060002AD RID: 685 RVA: 0x00006ADF File Offset: 0x00004CDF
		protected TGraph definition { get; }

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x060002AE RID: 686 RVA: 0x00006AE7 File Offset: 0x00004CE7
		protected Dictionary<IGraphElementWithData, IGraphElementData> elementsData { get; } = new Dictionary<IGraphElementWithData, IGraphElementData>();

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x060002AF RID: 687 RVA: 0x00006AEF File Offset: 0x00004CEF
		protected Dictionary<IGraphParentElement, IGraphData> childrenGraphsData { get; } = new Dictionary<IGraphParentElement, IGraphData>();

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x060002B0 RID: 688 RVA: 0x00006AF7 File Offset: 0x00004CF7
		protected Dictionary<Guid, IGraphElementData> phantomElementsData { get; } = new Dictionary<Guid, IGraphElementData>();

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x060002B1 RID: 689 RVA: 0x00006AFF File Offset: 0x00004CFF
		protected Dictionary<Guid, IGraphData> phantomChildrenGraphsData { get; } = new Dictionary<Guid, IGraphData>();

		// Token: 0x060002B2 RID: 690 RVA: 0x00006B07 File Offset: 0x00004D07
		public bool TryGetElementData(IGraphElementWithData element, out IGraphElementData data)
		{
			return this.elementsData.TryGetValue(element, out data);
		}

		// Token: 0x060002B3 RID: 691 RVA: 0x00006B16 File Offset: 0x00004D16
		public bool TryGetChildGraphData(IGraphParentElement element, out IGraphData data)
		{
			return this.childrenGraphsData.TryGetValue(element, out data);
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x00006B28 File Offset: 0x00004D28
		public IGraphElementData CreateElementData(IGraphElementWithData element)
		{
			if (this.elementsData.ContainsKey(element))
			{
				throw new InvalidOperationException(string.Format("Graph data already contains element data for {0}.", element));
			}
			IGraphElementData graphElementData;
			if (this.phantomElementsData.TryGetValue(element.guid, out graphElementData))
			{
				this.phantomElementsData.Remove(element.guid);
			}
			else
			{
				graphElementData = element.CreateData();
			}
			this.elementsData.Add(element, graphElementData);
			return graphElementData;
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x00006B94 File Offset: 0x00004D94
		public void FreeElementData(IGraphElementWithData element)
		{
			IGraphElementData value;
			if (this.elementsData.TryGetValue(element, out value))
			{
				this.elementsData.Remove(element);
				this.phantomElementsData.Add(element.guid, value);
				return;
			}
			Debug.LogWarning(string.Format("Graph data does not contain element data to free for {0}.", element));
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x00006BE4 File Offset: 0x00004DE4
		public IGraphData CreateChildGraphData(IGraphParentElement element)
		{
			if (this.childrenGraphsData.ContainsKey(element))
			{
				throw new InvalidOperationException(string.Format("Graph data already contains child graph data for {0}.", element));
			}
			IGraphData graphData;
			if (this.phantomChildrenGraphsData.TryGetValue(element.guid, out graphData))
			{
				this.phantomChildrenGraphsData.Remove(element.guid);
			}
			else
			{
				graphData = element.childGraph.CreateData();
			}
			this.childrenGraphsData.Add(element, graphData);
			return graphData;
		}

		// Token: 0x060002B7 RID: 695 RVA: 0x00006C54 File Offset: 0x00004E54
		public void FreeChildGraphData(IGraphParentElement element)
		{
			IGraphData value;
			if (this.childrenGraphsData.TryGetValue(element, out value))
			{
				this.childrenGraphsData.Remove(element);
				this.phantomChildrenGraphsData.Add(element.guid, value);
				return;
			}
			Debug.LogWarning(string.Format("Graph data does not contain child graph data to free for {0}.", element));
		}
	}
}
