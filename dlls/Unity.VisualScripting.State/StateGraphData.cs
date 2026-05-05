using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000017 RID: 23
	public sealed class StateGraphData : GraphData<StateGraph>, IGraphEventListenerData, IGraphData
	{
		// Token: 0x1700002C RID: 44
		// (get) Token: 0x0600008A RID: 138 RVA: 0x00002F94 File Offset: 0x00001194
		// (set) Token: 0x0600008B RID: 139 RVA: 0x00002F9C File Offset: 0x0000119C
		public bool isListening { get; set; }

		// Token: 0x0600008C RID: 140 RVA: 0x00002FA5 File Offset: 0x000011A5
		public StateGraphData(StateGraph definition) : base(definition)
		{
		}
	}
}
