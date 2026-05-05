using System;

namespace Unity.VisualScripting
{
	// Token: 0x02000003 RID: 3
	public sealed class ControlConnection : UnitConnection<ControlOutput, ControlInput>, IUnitConnection, IConnection<IUnitOutputPort, IUnitInputPort>, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
	{
		// Token: 0x06000003 RID: 3 RVA: 0x000020C6 File Offset: 0x000002C6
		[Obsolete("This parameterless constructor is only made public for serialization. Use another constructor instead.")]
		public ControlConnection()
		{
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000020CE File Offset: 0x000002CE
		public ControlConnection(ControlOutput source, ControlInput destination) : base(source, destination)
		{
			if (source.hasValidConnection)
			{
				throw new InvalidConnectionException("Control output ports do not support multiple connections.");
			}
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000005 RID: 5 RVA: 0x000020EB File Offset: 0x000002EB
		public override ControlOutput source
		{
			get
			{
				return base.sourceUnit.controlOutputs[base.sourceKey];
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000006 RID: 6 RVA: 0x00002103 File Offset: 0x00000303
		public override ControlInput destination
		{
			get
			{
				return base.destinationUnit.controlInputs[base.destinationKey];
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000007 RID: 7 RVA: 0x0000211B File Offset: 0x0000031B
		IUnitOutputPort IConnection<IUnitOutputPort, IUnitInputPort>.source
		{
			get
			{
				return this.source;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000008 RID: 8 RVA: 0x00002123 File Offset: 0x00000323
		IUnitInputPort IConnection<IUnitOutputPort, IUnitInputPort>.destination
		{
			get
			{
				return this.destination;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000009 RID: 9 RVA: 0x0000212B File Offset: 0x0000032B
		public override bool sourceExists
		{
			get
			{
				return base.sourceUnit.controlOutputs.Contains(base.sourceKey);
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600000A RID: 10 RVA: 0x00002143 File Offset: 0x00000343
		public override bool destinationExists
		{
			get
			{
				return base.destinationUnit.controlInputs.Contains(base.destinationKey);
			}
		}

		// Token: 0x0600000B RID: 11 RVA: 0x0000215B File Offset: 0x0000035B
		FlowGraph IUnitConnection.get_graph()
		{
			return base.graph;
		}
	}
}
