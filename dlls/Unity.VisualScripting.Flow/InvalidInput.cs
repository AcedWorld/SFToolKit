using System;
using System.Collections.Generic;
using System.Linq;

namespace Unity.VisualScripting
{
	// Token: 0x02000164 RID: 356
	public sealed class InvalidInput : UnitPort<IUnitOutputPort, IUnitOutputPort, InvalidConnection>, IUnitInvalidPort, IUnitPort, IGraphItem, IUnitInputPort
	{
		// Token: 0x06000949 RID: 2377 RVA: 0x00010D8E File Offset: 0x0000EF8E
		public InvalidInput(string key) : base(key)
		{
		}

		// Token: 0x17000330 RID: 816
		// (get) Token: 0x0600094A RID: 2378 RVA: 0x00010D97 File Offset: 0x0000EF97
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
					enumerable = ((graph != null) ? graph.invalidConnections.WithDestination(this) : null);
				}
				return enumerable ?? Enumerable.Empty<InvalidConnection>();
			}
		}

		// Token: 0x17000331 RID: 817
		// (get) Token: 0x0600094B RID: 2379 RVA: 0x00010DC6 File Offset: 0x0000EFC6
		public override IEnumerable<InvalidConnection> invalidConnections
		{
			get
			{
				return Enumerable.Empty<InvalidConnection>();
			}
		}

		// Token: 0x17000332 RID: 818
		// (get) Token: 0x0600094C RID: 2380 RVA: 0x00010DCD File Offset: 0x0000EFCD
		public override IEnumerable<IUnitOutputPort> validConnectedPorts
		{
			get
			{
				return from c in this.validConnections
				select c.source;
			}
		}

		// Token: 0x17000333 RID: 819
		// (get) Token: 0x0600094D RID: 2381 RVA: 0x00010DF9 File Offset: 0x0000EFF9
		public override IEnumerable<IUnitOutputPort> invalidConnectedPorts
		{
			get
			{
				return from c in this.invalidConnections
				select c.source;
			}
		}

		// Token: 0x0600094E RID: 2382 RVA: 0x00010E25 File Offset: 0x0000F025
		public override bool CanConnectToValid(IUnitOutputPort port)
		{
			return false;
		}

		// Token: 0x0600094F RID: 2383 RVA: 0x00010E28 File Offset: 0x0000F028
		public override void ConnectToValid(IUnitOutputPort port)
		{
			base.ConnectInvalid(port, this);
		}

		// Token: 0x06000950 RID: 2384 RVA: 0x00010E32 File Offset: 0x0000F032
		public override void ConnectToInvalid(IUnitOutputPort port)
		{
			base.ConnectInvalid(port, this);
		}

		// Token: 0x06000951 RID: 2385 RVA: 0x00010E3C File Offset: 0x0000F03C
		public override void DisconnectFromValid(IUnitOutputPort port)
		{
			base.DisconnectInvalid(port, this);
		}

		// Token: 0x06000952 RID: 2386 RVA: 0x00010E46 File Offset: 0x0000F046
		public override void DisconnectFromInvalid(IUnitOutputPort port)
		{
			base.DisconnectInvalid(port, this);
		}

		// Token: 0x06000953 RID: 2387 RVA: 0x00010E50 File Offset: 0x0000F050
		public override IUnitPort CompatiblePort(IUnit unit)
		{
			return null;
		}
	}
}
