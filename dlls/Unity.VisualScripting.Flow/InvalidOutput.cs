using System;
using System.Collections.Generic;
using System.Linq;

namespace Unity.VisualScripting
{
	// Token: 0x02000165 RID: 357
	public sealed class InvalidOutput : UnitPort<IUnitInputPort, IUnitInputPort, InvalidConnection>, IUnitInvalidPort, IUnitPort, IGraphItem, IUnitOutputPort
	{
		// Token: 0x06000954 RID: 2388 RVA: 0x00010E53 File Offset: 0x0000F053
		public InvalidOutput(string key) : base(key)
		{
		}

		// Token: 0x17000334 RID: 820
		// (get) Token: 0x06000955 RID: 2389 RVA: 0x00010E5C File Offset: 0x0000F05C
		public override IEnumerable<InvalidConnection> validConnections
		{
			get
			{
				IUnit unit = base.unit;
				IEnumerable<InvalidConnection> enumerable;
				if (unit == null)
				{
					enumerable = null;
				}
				else
				{
					FlowGraph graph = unit.graph;
					enumerable = ((graph != null) ? graph.invalidConnections.WithSource(this) : null);
				}
				return enumerable ?? Enumerable.Empty<InvalidConnection>();
			}
		}

		// Token: 0x17000335 RID: 821
		// (get) Token: 0x06000956 RID: 2390 RVA: 0x00010E8B File Offset: 0x0000F08B
		public override IEnumerable<InvalidConnection> invalidConnections
		{
			get
			{
				return Enumerable.Empty<InvalidConnection>();
			}
		}

		// Token: 0x17000336 RID: 822
		// (get) Token: 0x06000957 RID: 2391 RVA: 0x00010E92 File Offset: 0x0000F092
		public override IEnumerable<IUnitInputPort> validConnectedPorts
		{
			get
			{
				return from c in this.validConnections
				select c.destination;
			}
		}

		// Token: 0x17000337 RID: 823
		// (get) Token: 0x06000958 RID: 2392 RVA: 0x00010EBE File Offset: 0x0000F0BE
		public override IEnumerable<IUnitInputPort> invalidConnectedPorts
		{
			get
			{
				return from c in this.invalidConnections
				select c.destination;
			}
		}

		// Token: 0x06000959 RID: 2393 RVA: 0x00010EEA File Offset: 0x0000F0EA
		public override bool CanConnectToValid(IUnitInputPort port)
		{
			return false;
		}

		// Token: 0x0600095A RID: 2394 RVA: 0x00010EED File Offset: 0x0000F0ED
		public override void ConnectToValid(IUnitInputPort port)
		{
			base.ConnectInvalid(this, port);
		}

		// Token: 0x0600095B RID: 2395 RVA: 0x00010EF7 File Offset: 0x0000F0F7
		public override void ConnectToInvalid(IUnitInputPort port)
		{
			base.ConnectInvalid(this, port);
		}

		// Token: 0x0600095C RID: 2396 RVA: 0x00010F01 File Offset: 0x0000F101
		public override void DisconnectFromValid(IUnitInputPort port)
		{
			base.DisconnectInvalid(this, port);
		}

		// Token: 0x0600095D RID: 2397 RVA: 0x00010F0B File Offset: 0x0000F10B
		public override void DisconnectFromInvalid(IUnitInputPort port)
		{
			base.DisconnectInvalid(this, port);
		}

		// Token: 0x0600095E RID: 2398 RVA: 0x00010F15 File Offset: 0x0000F115
		public override IUnitPort CompatiblePort(IUnit unit)
		{
			return null;
		}
	}
}
