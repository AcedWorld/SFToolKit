using System;

namespace Unity.VisualScripting
{
	// Token: 0x0200000B RID: 11
	public sealed class ValueConnection : UnitConnection<ValueOutput, ValueInput>, IUnitConnection, IConnection<IUnitOutputPort, IUnitInputPort>, IGraphElementWithDebugData, IGraphElement, IGraphItem, INotifiedCollectionItem, IDisposable, IPrewarmable, IAotStubbable, IIdentifiable, IAnalyticsIdentifiable
	{
		// Token: 0x06000043 RID: 67 RVA: 0x000026F2 File Offset: 0x000008F2
		public override IGraphElementDebugData CreateDebugData()
		{
			return new ValueConnection.DebugData();
		}

		// Token: 0x06000044 RID: 68 RVA: 0x000026F9 File Offset: 0x000008F9
		[Obsolete("This parameterless constructor is only made public for serialization. Use another constructor instead.")]
		public ValueConnection()
		{
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00002704 File Offset: 0x00000904
		public ValueConnection(ValueOutput source, ValueInput destination) : base(source, destination)
		{
			if (destination.hasValidConnection)
			{
				throw new InvalidConnectionException("Value input ports do not support multiple connections.");
			}
			if (!source.type.IsConvertibleTo(destination.type, false))
			{
				throw new InvalidConnectionException(string.Format("Cannot convert from '{0}' to '{1}'.", source.type, destination.type));
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000046 RID: 70 RVA: 0x0000275C File Offset: 0x0000095C
		public override ValueOutput source
		{
			get
			{
				return base.sourceUnit.valueOutputs[base.sourceKey];
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000047 RID: 71 RVA: 0x00002774 File Offset: 0x00000974
		public override ValueInput destination
		{
			get
			{
				return base.destinationUnit.valueInputs[base.destinationKey];
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000048 RID: 72 RVA: 0x0000278C File Offset: 0x0000098C
		IUnitOutputPort IConnection<IUnitOutputPort, IUnitInputPort>.source
		{
			get
			{
				return this.source;
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000049 RID: 73 RVA: 0x00002794 File Offset: 0x00000994
		IUnitInputPort IConnection<IUnitOutputPort, IUnitInputPort>.destination
		{
			get
			{
				return this.destination;
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x0600004A RID: 74 RVA: 0x0000279C File Offset: 0x0000099C
		public override bool sourceExists
		{
			get
			{
				return base.sourceUnit.valueOutputs.Contains(base.sourceKey);
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600004B RID: 75 RVA: 0x000027B4 File Offset: 0x000009B4
		public override bool destinationExists
		{
			get
			{
				return base.destinationUnit.valueInputs.Contains(base.destinationKey);
			}
		}

		// Token: 0x0600004C RID: 76 RVA: 0x000027CC File Offset: 0x000009CC
		FlowGraph IUnitConnection.get_graph()
		{
			return base.graph;
		}

		// Token: 0x0200019B RID: 411
		public class DebugData : UnitConnectionDebugData
		{
			// Token: 0x170003B4 RID: 948
			// (get) Token: 0x06000B5C RID: 2908 RVA: 0x0001A1D4 File Offset: 0x000183D4
			// (set) Token: 0x06000B5D RID: 2909 RVA: 0x0001A1DC File Offset: 0x000183DC
			public object lastValue { get; set; }

			// Token: 0x170003B5 RID: 949
			// (get) Token: 0x06000B5E RID: 2910 RVA: 0x0001A1E5 File Offset: 0x000183E5
			// (set) Token: 0x06000B5F RID: 2911 RVA: 0x0001A1ED File Offset: 0x000183ED
			public bool assignedLastValue { get; set; }
		}
	}
}
