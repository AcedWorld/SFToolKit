using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000019 RID: 25
	public sealed class FlowGraphData : GraphData<FlowGraph>, IGraphDataWithVariables, IGraphData, IGraphEventListenerData
	{
		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060000CB RID: 203 RVA: 0x00003A28 File Offset: 0x00001C28
		public VariableDeclarations variables { get; }

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060000CC RID: 204 RVA: 0x00003A30 File Offset: 0x00001C30
		// (set) Token: 0x060000CD RID: 205 RVA: 0x00003A38 File Offset: 0x00001C38
		public bool isListening { get; set; }

		// Token: 0x060000CE RID: 206 RVA: 0x00003A41 File Offset: 0x00001C41
		public FlowGraphData(FlowGraph definition) : base(definition)
		{
			this.variables = definition.variables.CloneViaFakeSerialization<VariableDeclarations>();
		}
	}
}
