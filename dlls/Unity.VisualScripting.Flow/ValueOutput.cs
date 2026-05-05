using System;
using System.Collections.Generic;
using System.Linq;

namespace Unity.VisualScripting
{
	// Token: 0x02000178 RID: 376
	public sealed class ValueOutput : UnitPort<ValueInput, IUnitInputPort, ValueConnection>, IUnitValuePort, IUnitPort, IGraphItem, IUnitOutputPort
	{
		// Token: 0x060009D5 RID: 2517 RVA: 0x000118A7 File Offset: 0x0000FAA7
		public ValueOutput(string key, Type type, Func<Flow, object> getValue) : base(key)
		{
			Ensure.That("type").IsNotNull<Type>(type);
			Ensure.That("getValue").IsNotNull<Func<Flow, object>>(getValue);
			this.type = type;
			this.getValue = getValue;
		}

		// Token: 0x060009D6 RID: 2518 RVA: 0x000118DE File Offset: 0x0000FADE
		public ValueOutput(string key, Type type) : base(key)
		{
			Ensure.That("type").IsNotNull<Type>(type);
			this.type = type;
		}

		// Token: 0x1700036D RID: 877
		// (get) Token: 0x060009D7 RID: 2519 RVA: 0x000118FE File Offset: 0x0000FAFE
		public bool supportsPrediction
		{
			get
			{
				return this.canPredictValue != null;
			}
		}

		// Token: 0x1700036E RID: 878
		// (get) Token: 0x060009D8 RID: 2520 RVA: 0x00011909 File Offset: 0x0000FB09
		public bool supportsFetch
		{
			get
			{
				return this.getValue != null;
			}
		}

		// Token: 0x1700036F RID: 879
		// (get) Token: 0x060009D9 RID: 2521 RVA: 0x00011914 File Offset: 0x0000FB14
		public Type type { get; }

		// Token: 0x17000370 RID: 880
		// (get) Token: 0x060009DA RID: 2522 RVA: 0x0001191C File Offset: 0x0000FB1C
		public override IEnumerable<ValueConnection> validConnections
		{
			get
			{
				IUnit unit = base.unit;
				IEnumerable<ValueConnection> enumerable;
				if (unit == null)
				{
					enumerable = null;
				}
				else
				{
					FlowGraph graph = unit.graph;
					enumerable = ((graph != null) ? graph.valueConnections.WithSource(this) : null);
				}
				return enumerable ?? Enumerable.Empty<ValueConnection>();
			}
		}

		// Token: 0x17000371 RID: 881
		// (get) Token: 0x060009DB RID: 2523 RVA: 0x0001194B File Offset: 0x0000FB4B
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

		// Token: 0x17000372 RID: 882
		// (get) Token: 0x060009DC RID: 2524 RVA: 0x0001197A File Offset: 0x0000FB7A
		public override IEnumerable<ValueInput> validConnectedPorts
		{
			get
			{
				return from c in this.validConnections
				select c.destination;
			}
		}

		// Token: 0x17000373 RID: 883
		// (get) Token: 0x060009DD RID: 2525 RVA: 0x000119A6 File Offset: 0x0000FBA6
		public override IEnumerable<IUnitInputPort> invalidConnectedPorts
		{
			get
			{
				return from c in this.invalidConnections
				select c.destination;
			}
		}

		// Token: 0x060009DE RID: 2526 RVA: 0x000119D4 File Offset: 0x0000FBD4
		public override bool CanConnectToValid(ValueInput port)
		{
			return this.type.IsConvertibleTo(port.type, false);
		}

		// Token: 0x060009DF RID: 2527 RVA: 0x000119F8 File Offset: 0x0000FBF8
		public override void ConnectToValid(ValueInput port)
		{
			port.Disconnect();
			base.unit.graph.valueConnections.Add(new ValueConnection(this, port));
		}

		// Token: 0x060009E0 RID: 2528 RVA: 0x00011A2B File Offset: 0x0000FC2B
		public override void ConnectToInvalid(IUnitInputPort port)
		{
			base.ConnectInvalid(this, port);
		}

		// Token: 0x060009E1 RID: 2529 RVA: 0x00011A38 File Offset: 0x0000FC38
		public override void DisconnectFromValid(ValueInput port)
		{
			ValueConnection valueConnection = this.validConnections.SingleOrDefault((ValueConnection c) => c.destination == port);
			if (valueConnection != null)
			{
				base.unit.graph.valueConnections.Remove(valueConnection);
			}
		}

		// Token: 0x060009E2 RID: 2530 RVA: 0x00011A84 File Offset: 0x0000FC84
		public override void DisconnectFromInvalid(IUnitInputPort port)
		{
			base.DisconnectInvalid(this, port);
		}

		// Token: 0x060009E3 RID: 2531 RVA: 0x00011A8E File Offset: 0x0000FC8E
		public ValueOutput PredictableIf(Func<Flow, bool> condition)
		{
			Ensure.That("condition").IsNotNull<Func<Flow, bool>>(condition);
			this.canPredictValue = condition;
			return this;
		}

		// Token: 0x060009E4 RID: 2532 RVA: 0x00011AA8 File Offset: 0x0000FCA8
		public ValueOutput Predictable()
		{
			this.canPredictValue = ((Flow flow) => true);
			return this;
		}

		// Token: 0x060009E5 RID: 2533 RVA: 0x00011AD0 File Offset: 0x0000FCD0
		public override IUnitPort CompatiblePort(IUnit unit)
		{
			if (unit == base.unit)
			{
				return null;
			}
			return unit.CompatibleValueInput(this.type);
		}

		// Token: 0x0400020E RID: 526
		internal readonly Func<Flow, object> getValue;

		// Token: 0x0400020F RID: 527
		internal Func<Flow, bool> canPredictValue;
	}
}
