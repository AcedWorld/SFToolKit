using System;
using System.Collections.Generic;
using System.Linq;

namespace Unity.VisualScripting
{
	// Token: 0x02000161 RID: 353
	public sealed class ControlOutput : UnitPort<ControlInput, IUnitInputPort, ControlConnection>, IUnitControlPort, IUnitPort, IGraphItem, IUnitOutputPort
	{
		// Token: 0x06000937 RID: 2359 RVA: 0x00010A86 File Offset: 0x0000EC86
		public ControlOutput(string key) : base(key)
		{
		}

		// Token: 0x17000328 RID: 808
		// (get) Token: 0x06000938 RID: 2360 RVA: 0x00010A8F File Offset: 0x0000EC8F
		public override IEnumerable<ControlConnection> validConnections
		{
			get
			{
				IUnit unit = base.unit;
				IEnumerable<ControlConnection> enumerable;
				if (unit == null)
				{
					enumerable = null;
				}
				else
				{
					FlowGraph graph = unit.graph;
					enumerable = ((graph != null) ? graph.controlConnections.WithSource(this) : null);
				}
				return enumerable ?? Enumerable.Empty<ControlConnection>();
			}
		}

		// Token: 0x17000329 RID: 809
		// (get) Token: 0x06000939 RID: 2361 RVA: 0x00010ABE File Offset: 0x0000ECBE
		public override IEnumerable<InvalidConnection> invalidConnections
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

		// Token: 0x1700032A RID: 810
		// (get) Token: 0x0600093A RID: 2362 RVA: 0x00010AED File Offset: 0x0000ECED
		public override IEnumerable<ControlInput> validConnectedPorts
		{
			get
			{
				return from c in this.validConnections
				select c.destination;
			}
		}

		// Token: 0x1700032B RID: 811
		// (get) Token: 0x0600093B RID: 2363 RVA: 0x00010B19 File Offset: 0x0000ED19
		public override IEnumerable<IUnitInputPort> invalidConnectedPorts
		{
			get
			{
				return from c in this.invalidConnections
				select c.destination;
			}
		}

		// Token: 0x1700032C RID: 812
		// (get) Token: 0x0600093C RID: 2364 RVA: 0x00010B48 File Offset: 0x0000ED48
		public bool isPredictable
		{
			get
			{
				bool result;
				using (Recursion recursion = Recursion.New(1))
				{
					result = this.IsPredictable(recursion);
				}
				return result;
			}
		}

		// Token: 0x0600093D RID: 2365 RVA: 0x00010B84 File Offset: 0x0000ED84
		public bool IsPredictable(Recursion recursion)
		{
			if (base.unit.isControlRoot)
			{
				return true;
			}
			Recursion recursion2 = recursion;
			if (recursion2 != null && !recursion2.TryEnter(this))
			{
				return false;
			}
			bool result = (from r in base.unit.relations.WithDestination(this)
			where r.source is ControlInput
			select r).All((IUnitRelation r) => ((ControlInput)r.source).IsPredictable(recursion));
			Recursion recursion3 = recursion;
			if (recursion3 == null)
			{
				return result;
			}
			recursion3.Exit(this);
			return result;
		}

		// Token: 0x1700032D RID: 813
		// (get) Token: 0x0600093E RID: 2366 RVA: 0x00010C20 File Offset: 0x0000EE20
		public bool couldBeEntered
		{
			get
			{
				if (!this.isPredictable)
				{
					throw new NotSupportedException();
				}
				if (base.unit.isControlRoot)
				{
					return true;
				}
				return (from r in base.unit.relations.WithDestination(this)
				where r.source is ControlInput
				select r).Any((IUnitRelation r) => ((ControlInput)r.source).couldBeEntered);
			}
		}

		// Token: 0x1700032E RID: 814
		// (get) Token: 0x0600093F RID: 2367 RVA: 0x00010CA3 File Offset: 0x0000EEA3
		public ControlConnection connection
		{
			get
			{
				FlowGraph graph = base.unit.graph;
				if (graph == null)
				{
					return null;
				}
				return graph.controlConnections.SingleOrDefaultWithSource(this);
			}
		}

		// Token: 0x1700032F RID: 815
		// (get) Token: 0x06000940 RID: 2368 RVA: 0x00010CC1 File Offset: 0x0000EEC1
		public override bool hasValidConnection
		{
			get
			{
				return this.connection != null;
			}
		}

		// Token: 0x06000941 RID: 2369 RVA: 0x00010CCC File Offset: 0x0000EECC
		public override bool CanConnectToValid(ControlInput port)
		{
			return true;
		}

		// Token: 0x06000942 RID: 2370 RVA: 0x00010CD0 File Offset: 0x0000EED0
		public override void ConnectToValid(ControlInput port)
		{
			this.Disconnect();
			base.unit.graph.controlConnections.Add(new ControlConnection(this, port));
		}

		// Token: 0x06000943 RID: 2371 RVA: 0x00010D03 File Offset: 0x0000EF03
		public override void ConnectToInvalid(IUnitInputPort port)
		{
			base.ConnectInvalid(this, port);
		}

		// Token: 0x06000944 RID: 2372 RVA: 0x00010D10 File Offset: 0x0000EF10
		public override void DisconnectFromValid(ControlInput port)
		{
			ControlConnection controlConnection = this.validConnections.SingleOrDefault((ControlConnection c) => c.destination == port);
			if (controlConnection != null)
			{
				base.unit.graph.controlConnections.Remove(controlConnection);
			}
		}

		// Token: 0x06000945 RID: 2373 RVA: 0x00010D5C File Offset: 0x0000EF5C
		public override void DisconnectFromInvalid(IUnitInputPort port)
		{
			base.DisconnectInvalid(this, port);
		}

		// Token: 0x06000946 RID: 2374 RVA: 0x00010D66 File Offset: 0x0000EF66
		public override IUnitPort CompatiblePort(IUnit unit)
		{
			if (unit == base.unit)
			{
				return null;
			}
			return unit.controlInputs.FirstOrDefault<ControlInput>();
		}
	}
}
